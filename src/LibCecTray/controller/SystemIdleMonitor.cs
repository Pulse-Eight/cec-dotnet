/*
* This file is part of the libCEC(R) library.
*
* libCEC(R) is Copyright (C) 2011-2020 Pulse-Eight Limited.  All rights reserved.
* libCEC(R) is an original work, containing original code.
*
* libCEC(R) is a trademark of Pulse-Eight Limited.
*
* This program is dual-licensed; you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation; either version 2 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this program; if not, write to the Free Software
* Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.
*
*
* Alternatively, you can license this library under a commercial license,
* please contact Pulse-Eight Licensing for more information.
*
* For more information contact:
* Pulse-Eight Licensing       <license@pulse-eight.com>
*     http://www.pulse-eight.com/
*     http://www.pulse-eight.net/
*
* Author: Lars Op den Kamp <lars@opdenkamp.eu>
*
*/

using System;
using System.Runtime.InteropServices;
using System.Threading;
using LibCECTray.controller.applications;

namespace LibCECTray.controller
{
  public class SystemIdleMonitor
  {
    private SystemIdleMonitor()
    {
      _eventFired = false;
      _refreshThread = new Thread(Refresh);
      _refreshThread.Start();
    }

    ~SystemIdleMonitor()
    {
      Stop();
    }

    public void Stop()
    {
      _stopMonitor = true;
      _refreshThread = null;
    }

    private void OnScreensaverActivated(bool active)
    {
      if (active != ScreensaverActive)
      {
        ScreensaverActive = active;
        if (!active)
        {
          ScreensaverActivated?.Invoke(this, new ScreensaverChange(false));
        }
        else if ((DateTime.Now - _lastScreensaverActivated).TotalSeconds > 60)
        {
          // guard against screensaver failing, and resulting in power up and down spam to the tv
          _lastScreensaverActivated = DateTime.Now;
          ScreensaverActivated?.Invoke(this, new ScreensaverChange(true));
        }
      }
    }

    public bool WndProc(ref System.Windows.Forms.Message msg)
    {
      if ((msg.Msg == WindowsAPI.WM_SYSCOMMAND) &&
        (msg.WParam.ToInt32() & 0xfff0) == WindowsAPI.SC_SCREENSAVE)
      {
        // there's no event for screensaver exit
        OnScreensaverActivated(true);
      }
      else if (msg.Msg == WindowsAPI.WM_POWERBROADCAST)
      {
        switch (msg.WParam.ToInt32())
        {
          case WindowsAPI.PBT_APMSUSPEND:
            PowerStatusChanged?.Invoke(this, new SystemPowerChange(SystemPowerState.Standby));
            return true;

          case WindowsAPI.PBT_APMRESUMESUSPEND:
          case WindowsAPI.PBT_APMRESUMECRITICAL:
          case WindowsAPI.PBT_APMRESUMEAUTOMATIC:
            PowerStatusChanged?.Invoke(this, new SystemPowerChange(SystemPowerState.Wake));
            return true;

          case WindowsAPI.PBT_POWERSETTINGCHANGE:
            {
              WindowsAPI.POWERBROADCAST_SETTING pwr = (WindowsAPI.POWERBROADCAST_SETTING)Marshal.PtrToStructure(msg.LParam, typeof(WindowsAPI.POWERBROADCAST_SETTING));
              if (pwr.PowerSetting == WindowsAPI.GUID_SYSTEM_AWAYMODE && pwr.DataLength == Marshal.SizeOf(typeof(Int32)))
              {
                switch (pwr.Data)
                {
                  case 0:
                    PowerStatusChanged?.Invoke(this, new SystemPowerChange(SystemPowerState.AwayExit));
                    return true;
                  case 1:
                    PowerStatusChanged?.Invoke(this, new SystemPowerChange(SystemPowerState.AwayEnter));
                    return true;
                  default:
                    break;
                }
              }
            }
            break;
          default:
            break;
        }
      }

      // pass up when not handled
      return false;
    }

    private void Refresh()
    {
      while (!_stopMonitor)
      {
        if (!Suspended)
        {
          RefreshIdleTime();
          RefreshScreensaver();
          Thread.Sleep(100);
        }
      }
    }

    private void RefreshScreensaver()
    {
      bool active = WindowsAPI.ScreensaverActive();
      OnScreensaverActivated(active);
    }

    private void RefreshIdleTime()
    {
      int lastIdleTimeSeconds = IdleTimeSeconds;
      IdleTimeSeconds = WindowsAPI.SystemIdleSeconds();
      if (IdleTimeoutSeconds <= 0)
      {
        return;
      }
      IdleTimeChange change = new IdleTimeChange(IdleTimeSeconds, IdleTimeoutSeconds);
      SystemActivity?.Invoke(this, change);

      if (IdleTimeSeconds < lastIdleTimeSeconds && _eventFired)
      {
        SystemIdle?.Invoke(this, new IdleChange(false));
        _eventFired = false;
      }
      else if ((IdleTimeSeconds > lastIdleTimeSeconds) && (IdleTimeSeconds >= IdleTimeoutSeconds) && !_eventFired)
      {
        SystemIdle?.Invoke(this, new IdleChange(true));
        _eventFired = true;
      }
    }

    /// <summary>
    /// Idle time in seconds
    /// </summary>
    public int IdleTimeSeconds {
      get;
      private set;
    }

    public int IdleTimeoutSeconds {
      get {
        return Program.Instance.Controller.Settings.StandbyScreen.AsSettingIdleTime.Value.Seconds;
      }
    }

    /// <summary>
    /// True while the screensaver is active
    /// </summary>
    public bool ScreensaverActive {
      private set;
      get;
    }

    /// <summary>
    /// Singleton instance of the idle time checker
    /// </summary>
    public static SystemIdleMonitor Instance {
      get {
        if (_instance == null)
          _instance = new SystemIdleMonitor();
        return _instance;
      }
    }

    public event EventHandler<IdleChange> SystemIdle;
    public event EventHandler<IdleTimeChange> SystemActivity;
    public event EventHandler<ScreensaverChange> ScreensaverActivated;
    public event EventHandler<SystemPowerChange> PowerStatusChanged;

    private bool _eventFired;
    private static SystemIdleMonitor _instance = null;
    private bool _stopMonitor = false;
    private Thread _refreshThread = null;
    private System.Windows.Forms.Timer _sstimer = new System.Windows.Forms.Timer();
    private DateTime _lastScreensaverActivated;
    public bool Suspended = true;
  }

  public enum SystemPowerState
  {
    Standby,
    Wake,
    AwayEnter,
    AwayExit
  }

  public class SystemPowerChange : EventArgs
  {
    public SystemPowerChange(SystemPowerState state)
    {
      State = state;
    }

    public SystemPowerState State { private set; get; }
  }

  public class ScreensaverChange : EventArgs
  {
    public ScreensaverChange(bool active)
    {
      Active = active;
    }

    public bool Active { private set; get; }
  }

  public class IdleChange : EventArgs
  {
    public IdleChange(bool idle)
    {
      Idle = idle;
    }

    public bool Idle {
      get;
      private set;
    }
  }
  
  public class IdleTimeChange : EventArgs
  {
    public IdleTimeChange(int idleTimeSeconds, int idleTimeoutSeconds)
    {
      IdleTimeSeconds = idleTimeSeconds;
      IdleTimeoutSeconds = idleTimeoutSeconds;
    }

    /// <summary>
    /// Idle time in seconds
    /// </summary>
    public int IdleTimeSeconds { get; private set; }
    public int IdleTimeoutSeconds { get; private set; }
  }
}
