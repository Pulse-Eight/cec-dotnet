/*
 * This file is part of the libCEC(R) library.
 *
 * libCEC(R) is Copyright (C) 2011-2013 Pulse-Eight Limited.  All rights reserved.
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
 */

using System;
using System.Windows.Forms;
using CecSharp;
using System.IO;
using LibCECTray.Properties;
using LibCECTray.controller;
using LibCECTray.controller.applications;
using LibCECTray.settings;
using Microsoft.Win32;
using System.Threading;
using System.Text;
using System.Diagnostics;

namespace LibCECTray.ui
{
  /// <summary>
  /// Main LibCecTray GUI
  /// </summary>
  partial class CECTray : AsyncForm
  {
    public CECTray()
    {
      Text = Resources.app_name;
      InitializeComponent();
      VisibleChanged += delegate
                       {
                         if (!Visible)
                           OnHide();
                         else
                           OnShow();
                       };
      SystemIdleMonitor.Instance.ScreensaverActivated += ScreenSaverActivated;
      SystemIdleMonitor.Instance.PowerStatusChanged += SystemPowerChanged;
      SystemIdleMonitor.Instance.SystemActivity += SystemActivity;
      SystemIdleMonitor.Instance.SystemIdle += SystemIdle;
      SystemEvents.SessionEnding += new SessionEndingEventHandler(OnSessionEnding);
    }

    private void SystemIdle(object sender, IdleChange e)
    {
      if (e.Idle)
      {
        Controller.CECActions.SendStandby(CecLogicalAddress.Broadcast);
      } else
      {
        Controller.CECActions.ActivateSource();
      }
    }

    private void SystemActivity(object sender, IdleTimeChange e)
    {
      SetIdleTime(e.IdleTimeSeconds, e.IdleTimeoutSeconds);
    }

    private void SetIdleTime(int idleTimeSeconds, int idleTimeoutSeconds)
    {
      if (pbIdleTime.InvokeRequired)
      {
        SetIdleTimeCallback cb = SetIdleTime;
        try
        {
          pbIdleTime.Invoke(cb, new object[] { idleTimeSeconds, idleTimeoutSeconds });
        }
        catch { }
      }
      else
      {
        if (idleTimeSeconds >= idleTimeoutSeconds)
          pbIdleTime.Value = 100;
        else if (idleTimeSeconds <= 0)
          pbIdleTime.Value = 0;
        else
          pbIdleTime.Value = (idleTimeSeconds * 100) / idleTimeoutSeconds;
      }
    }
    private delegate void SetIdleTimeCallback(int idleTimeSeconds, int idleTimeoutSeconds);

    private void SystemPowerChanged(object sender, SystemPowerChange e)
    {
      switch (e.State)
      {
        case SystemPowerState.Wake:
          OnWake();
          break;
        case SystemPowerState.Standby:
          OnSleep();
          break;
        case SystemPowerState.AwayEnter:
          Controller.CECActions.SendStandby(CecLogicalAddress.Broadcast);
          break;
          case SystemPowerState.AwayExit:
          // do _not_ wake the pc when away mode is deactivated
          break;
      }
    }

    private void ScreenSaverActivated(object sender, ScreensaverChange e)
    {
      if (e.Active)
      {
        Controller.CECActions.SendStandby(CecLogicalAddress.Broadcast);
      } else
      {
        Controller.CECActions.ActivateSource();
      }
    }

    protected override void SetVisibleCore(bool value)
    {
      if (Controller.Settings.StartHidden.Value && !this.IsHandleCreated)
      {
        value = false;
        CreateHandle();
      }
      base.SetVisibleCore(value);
    }

    public void OnSessionEnding(object sender, SessionEndingEventArgs e)
    {
      OnExit();
    }

    /// <summary>
    /// Check for power state changes, and pass up when it's something we don't care about
    /// </summary>
    /// <param name="msg">The incoming window message</param>
    protected override void WndProc(ref Message msg)
    {
      if (!SystemIdleMonitor.Instance.WndProc(ref msg))
      {
        // pass up if not handled
        base.WndProc(ref msg);
      }
    }

    private void OnWake()
    {
      Controller.Initialise();
    }

    private void OnSleep()
    {
      Controller.CECActions.SuppressUpdates = true;
      AsyncDisconnect dc = new AsyncDisconnect(Controller);
      (new Thread(dc.Process)).Start();
    }

    private void OnExit()
    {
      OnSleep();
      SystemIdleMonitor.Instance.Stop();
      Controller.CECActions.SuppressUpdates = true;
      Controller.Close();
      SetShowInTaskbar(false);
    }

    public override sealed string Text
    {
      get { return base.Text; }
      set { base.Text = value; }
    }

    public void Initialise()
    {
      Controller.Initialise();
    }

    protected override void Dispose(bool disposing)
    {
      Hide();
      if (disposing)
      {
        OnExit();
      }
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Configuration tab
    /// <summary>
    /// Replaces the gui controls by the ones that are bound to the settings.
    /// this is a fugly way to do it, but the gui designer doesn't allow us to ref CECSettings, since it uses symbols from LibCecSharp
    /// </summary>
    public void InitialiseSettingsComponent(CECSettings settings)
    {
      settings.OverridePhysicalAddress.ReplaceControls(this, Configuration.Controls, cbOverrideAddress);
      settings.OverrideTVVendor.ReplaceControls(this, Configuration.Controls, cbVendorOverride);
      settings.PhysicalAddress.ReplaceControls(this, Configuration.Controls, tbPhysicalAddress);
      settings.DetectPhysicalAddress.ReplaceControls(this, Configuration.Controls, cbDetectAddress);
      settings.HDMIPort.ReplaceControls(this, Configuration.Controls, lPortNumber, cbPortNumber);
      settings.ConnectedDevice.ReplaceControls(this, Configuration.Controls, lConnectedDevice, cbConnectedDevice);
      settings.DeviceType.ReplaceControls(this, Configuration.Controls, lDeviceType, cbDeviceType);
      settings.TVVendor.ReplaceControls(this, Configuration.Controls, cbVendorId);
      settings.StartHidden.ReplaceControls(this, Configuration.Controls, cbStartMinimised);

      settings.WakeDevices.ReplaceControls(this, powerTab.Controls, lWakeDevices, cbWakeDevices);
      settings.PowerOffDevices.ReplaceControls(this, powerTab.Controls, lPowerOff, cbPowerOffDevices);
      settings.ActivateSource.ReplaceControls(this, powerTab.Controls, cbActivateSource);
      settings.StopTvStandby.ReplaceControls(this, powerTab.Controls, cbStopTvStandby);
      settings.StandbyScreen.ReplaceControls(this, powerTab.Controls, lStandbyScreen, cbStandbyScreen);
      settings.TVAutoPowerOn.ReplaceControls(this, powerTab.Controls, cbTVAutoPowerOn);

      var idleTimeSetting = settings.StandbyScreen.AsSettingIdleTime;
      var cbIdleTime = (idleTimeSetting.ValueControl as ComboBox);
      cbIdleTime.SelectedValueChanged += delegate
      {
        SetControlVisible(pbIdleTime, (cbIdleTime.SelectedIndex > 0));
      };
      if (idleTimeSetting.TimeoutEnabled)
        SetControlVisible(pbIdleTime, true);
      SetControlVisible(settings.TVAutoPowerOn.ValueControl, false);
    }

    private void BSaveClick(object sender, EventArgs e)
    {
      Controller.SaveSettings();
    }
   
    private void BReloadConfigClick(object sender, EventArgs e)
    {
      Controller.ResetDefaultSettings();
    }
    #endregion

    #region CEC Tester tab
    delegate void SetActiveDevicesCallback(string[] activeDevices);
    public void SetActiveDevices(string[] activeDevices)
    {
      if (cbCommandDestination.InvokeRequired)
      {
        SetActiveDevicesCallback d = SetActiveDevices;
        try
        {
          Invoke(d, new object[] { activeDevices });
        }
        catch (Exception) { }
      }
      else
      {
        cbCommandDestination.Items.Clear();
        foreach (string item in activeDevices)
          cbCommandDestination.Items.Add(item);
      }
    }

    delegate CecLogicalAddress GetTargetDeviceCallback();
    private CecLogicalAddress GetTargetDevice()
    {
      if (cbCommandDestination.InvokeRequired)
      {
        GetTargetDeviceCallback d = GetTargetDevice;
        CecLogicalAddress retval = CecLogicalAddress.Unknown;
        try
        {
          retval = (CecLogicalAddress)Invoke(d, new object[] { });
        }
        catch (Exception) { }
        return retval;
      }

      return CECSettingLogicalAddresses.GetLogicalAddressFromString(cbCommandDestination.Text);
    }

    private void BSendImageViewOnClick(object sender, EventArgs e)
    {
      Controller.CECActions.SendImageViewOn(GetTargetDevice());
    }

    private void BStandbyClick(object sender, EventArgs e)
    {
      Controller.CECActions.SendStandby(GetTargetDevice());
    }

    private void BScanClick(object sender, EventArgs e)
    {
      Controller.CECActions.ShowDeviceInfo(GetTargetDevice());
    }

    private void BActivateSourceClick(object sender, EventArgs e)
    {
      Controller.CECActions.SetStreamPath(GetTargetDevice());
    }

    private void CbCommandDestinationSelectedIndexChanged(object sender, EventArgs e)
    {
      bool enableVolumeButtons = (GetTargetDevice() == CecLogicalAddress.AudioSystem);
      bVolUp.Enabled = enableVolumeButtons;
      bVolDown.Enabled = enableVolumeButtons;
      bMute.Enabled = enableVolumeButtons;
      bActivateSource.Enabled = (GetTargetDevice() != CecLogicalAddress.Broadcast);
      bScan.Enabled = (GetTargetDevice() != CecLogicalAddress.Broadcast);
    }

    private void BVolUpClick(object sender, EventArgs e)
    {
      Controller.Lib.VolumeUp(true);
    }

    private void BVolDownClick(object sender, EventArgs e)
    {
      Controller.Lib.VolumeDown(true);
    }

    private void BMuteClick(object sender, EventArgs e)
    {
      Controller.Lib.MuteAudio();
    }

    private void BRescanDevicesClick(object sender, EventArgs e)
    {
      Controller.CECActions.RescanDevices();
    }
    #endregion

    #region Log tab
    delegate void UpdateLogCallback();
    private void UpdateLog()
    {
      if (tbLog.InvokeRequired)
      {
        UpdateLogCallback d = UpdateLog;
        try
        {
          Invoke(d, new object[] { });
        }
        catch (Exception) { }
      }
      else
      {
        tbLog.Text = _log.ToString();
        tbLog.Select(tbLog.Text.Length, 0);
        tbLog.ScrollToCaret();
      }
    }

    public void AddLogMessage(CecLogMessage message)
    {
      string strLevel = "";
      bool display = false;
      switch (message.Level)
      {
        case CecLogLevel.Error:
          strLevel = "ERROR:   ";
          display = cbLogError.Checked;
          break;
        case CecLogLevel.Warning:
          strLevel = "WARNING: ";
          display = cbLogWarning.Checked;
          break;
        case CecLogLevel.Notice:
          strLevel = "NOTICE:  ";
          display = cbLogNotice.Checked;
          break;
        case CecLogLevel.Traffic:
          strLevel = "TRAFFIC: ";
          display = cbLogTraffic.Checked;
          break;
        case CecLogLevel.Debug:
          strLevel = "DEBUG:   ";
          display = cbLogDebug.Checked;
          break;
      }

      if (display)
      {
        string strLog = string.Format("{0} {1,16} {2}", strLevel, message.Time, message.Message) + Environment.NewLine;
        AddLogMessage(strLog);
      }
    }

    public void AddLogMessage(string message)
    {
      _log.Append(message);
      if (_log.Length > MaxLogLength)
      {
        _log.Remove(0, _log.Length - MaxLogLength);
      }

      if (_selectedTab == ConfigTab.Log)
        UpdateLog();
    }

    private void BClearLogClick(object sender, EventArgs e)
    {
      _log = new StringBuilder();
      UpdateLog();
    }

    private void BSaveLogClick(object sender, EventArgs e)
    {
      SaveFileDialog dialog = new SaveFileDialog
      {
        Title = Resources.where_do_you_want_to_store_the_log,
        InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        FileName = Resources.cec_log_filename,
        Filter = Resources.cec_log_filter,
        FilterIndex = 1
      };

      if (dialog.ShowDialog() == DialogResult.OK)
      {
        FileStream fs = (FileStream)dialog.OpenFile();
        if (!fs.CanWrite)
        {
          MessageBox.Show(string.Format(Resources.cannot_open_for_writing, dialog.FileName), Resources.app_name, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
          StreamWriter writer = new StreamWriter(fs);
          writer.Write(_log.ToString());
          writer.Close();
          fs.Close();
          fs.Dispose();
          MessageBox.Show(string.Format(Resources.log_stored_as, dialog.FileName), Resources.app_name, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      }
    }
    #endregion

    #region Tray icon and window controls
    private void HideToolStripMenuItemClick(object sender, EventArgs e)
    {
      ShowHideToggle();
    }

    private void CloseToolStripMenuItemClick(object sender, EventArgs e)
    {
      Dispose();
    }

    private void AboutToolStripMenuItemClick(object sender, EventArgs e)
    {
      (new About(Controller.LibServerVersion, Controller.LibClientVersion, Controller.LibInfo)).ShowDialog();
    }

    private void AdvancedModeToolStripMenuItemClick(object sender, EventArgs e)
    {
      Controller.Settings.AdvancedMode.Value = !advancedModeToolStripMenuItem.Checked;
      ShowHideAdvanced(!advancedModeToolStripMenuItem.Checked);
    }

    private void BCancelClick(object sender, EventArgs e)
    {
      Dispose();
    }

    private void TrayIconClick(object sender, EventArgs e)
    {
      if (e is MouseEventArgs && (e as MouseEventArgs).Button == MouseButtons.Left)
        ShowHideToggle();
    }

    public void OnHide()
    {
      ShowInTaskbar = false;
      Visible = false;
      tsMenuShowHide.Text = Resources.show;
    }

    public void OnShow()
    {
      ShowInTaskbar = true;
      WindowState = FormWindowState.Normal;
      Activate();
      tsMenuShowHide.Text = Resources.hide;
    }

    private void ShowHideToggle()
    {
      if (Visible && WindowState != FormWindowState.Minimized)
      {
        Hide();
      }
      else
      {
        Show();
      }
    }

    private void TsMenuCloseClick(object sender, EventArgs e)
    {
      Dispose();
    }

    private void CECTrayResize(object sender, EventArgs e)
    {
      if (WindowState == FormWindowState.Minimized)
        Hide();
      else
        Show();
    }

    private void TsMenuShowHideClick(object sender, EventArgs e)
    {
      ShowHideToggle();
    }

    public void ShowHideAdvanced(bool setTo)
    {
      if (setTo)
      {
        tsAdvanced.Checked = true;
        advancedModeToolStripMenuItem.Checked = true;
        SuspendLayout();
        if (!tabPanel.Controls.Contains(tbTestCommands))
          TabControls.Add(tbTestCommands);
        if (!tabPanel.Controls.Contains(LogOutput))
          TabControls.Add(LogOutput);
        ResumeLayout();
      }
      else
      {
        tsAdvanced.Checked = false;
        advancedModeToolStripMenuItem.Checked = false;
        SuspendLayout();
        tabPanel.Controls.Remove(tbTestCommands);
        tabPanel.Controls.Remove(LogOutput);
        ResumeLayout();
      }
    }

    private void TsAdvancedClick(object sender, EventArgs e)
    {
      Controller.Settings.AdvancedMode.Value = !tsAdvanced.Checked;
      ShowHideAdvanced(!tsAdvanced.Checked);
    }

    public void SetStatusText(string status)
    {
      SetControlText(lStatus, status);
    }

    public void SetProgressBar(int progress, bool visible)
    {
      SetControlVisible(pProgress, visible);
      SetProgressValue(pProgress, progress);
    }

    public void SetControlsEnabled(bool val)
    {
      //main tab
      SetControlEnabled(bReloadConfig, val);

      //power config tab
      SetControlEnabled(bReloadConfig2, val);

      //tester tab
      SetControlEnabled(bRescanDevices, val);
      SetControlEnabled(bSendImageViewOn, val);
      SetControlEnabled(bStandby, val);
      SetControlEnabled(bActivateSource, val);
      SetControlEnabled(bScan, val);

      bool enableVolumeButtons = (GetTargetDevice() == CecLogicalAddress.AudioSystem) && val;
      SetControlEnabled(bVolUp, enableVolumeButtons);
      SetControlEnabled(bVolDown, enableVolumeButtons);
      SetControlEnabled(bMute, enableVolumeButtons);
    }

    private void SelectedTabChanged(object sender, EventArgs e)
    {
      switch (tabPanel.TabPages[tabPanel.SelectedIndex].Name)
      {
        case "tbTestCommands":
          _selectedTab = ConfigTab.Tester;
          break;
        case "LogOutput":
          _selectedTab = ConfigTab.Log;
          UpdateLog();
          break;
        default:
          _selectedTab = ConfigTab.Configuration;
          break;
      }
    }
    #endregion

    #region Class members
    private ConfigTab _selectedTab = ConfigTab.Configuration;
    private StringBuilder _log = new StringBuilder();
    private static readonly int MaxLogLength = 100 * 1024;

    private CECController _controller;
    public CECController Controller
    {
      get
      {
        return _controller ?? (_controller = new CECController(this));
      }
    }
    public Control.ControlCollection TabControls
    {
      get { return tabPanel.Controls; }
    }
    public string SelectedTabName
    {
      get { return GetSelectedTabName(tabPanel, tabPanel.TabPages); }
    }

    #endregion

    private void AddNewApplicationToolStripMenuItemClick(object sender, EventArgs e)
    {
      ConfigureApplication appConfig = new ConfigureApplication(Controller.Settings, Controller);
      Controller.DisplayDialog(appConfig, false);
    }

    private void bFirmwareUpgradeClick(object sender, EventArgs e)
    {
      try
      {
        SetControlEnabled(bFirmwareUpgrade, false);
        using (var proc = new Process())
        {
          _controller.Lib.StartBootloader();
          _controller.Close();
          proc.StartInfo.FileName = CECController.FirmwareUpgradeExe;
          proc.StartInfo.UseShellExecute = true;
          proc.StartInfo.RedirectStandardOutput = false;
          proc.Start();
          proc.WaitForExit();
        }
      } catch { }
      finally
      {
        _controller.Open();
        SetControlEnabled(bFirmwareUpgrade, true);
      }
    }

    private void pbAlertClick(object sender, EventArgs e)
    {
      var wr = _controller.CecWarnings.First.Value;
      switch (wr)
      {
        case CecAlert.ServiceDevice:
          MessageBox.Show(Resources.alert_service_device, Resources.cec_alert, MessageBoxButtons.OK, MessageBoxIcon.Warning);
          break;
        case CecAlert.ConnectionLost:
          MessageBox.Show(Resources.alert_connection_lost, Resources.cec_alert, MessageBoxButtons.OK, MessageBoxIcon.Warning);
          break;
        case CecAlert.PermissionError:
          MessageBox.Show(Resources.alert_permission_error, Resources.cec_alert, MessageBoxButtons.OK, MessageBoxIcon.Warning);
          break;
        case CecAlert.PortBusy:
          MessageBox.Show(Resources.alert_port_busy, Resources.cec_alert, MessageBoxButtons.OK, MessageBoxIcon.Warning);
          break;
        case CecAlert.PhysicalAddressError:
          MessageBox.Show(Resources.alert_physical_address_error, Resources.cec_alert, MessageBoxButtons.OK, MessageBoxIcon.Warning);
          break;
        case CecAlert.TVPollFailed:
          MessageBox.Show(Resources.alert_tv_poll_failed, Resources.cec_alert, MessageBoxButtons.OK, MessageBoxIcon.Warning);
          break;
      }
    }
  }

  /// <summary>
  /// The tab pages in this application
  /// </summary>
  internal enum ConfigTab
        private void button_RawCommand_Click(object sender, EventArgs e)
        {
            var hexCommand = textBox_RawCommand.Text;

            Controller.CECActions.SendRawCommand(hexCommand);
        }

        private bool IsValidRawCommandFormat(string command)
        {
            // Accepts exactly 4 bytes in "xx:xx:xx:xx" (hex pairs separated by colon) format
            if (string.IsNullOrWhiteSpace(command))
                return false;

            var parts = command.Split(':');
            if (parts.Length != 4)
                return false;

            foreach (var part in parts)
            {
                if (part.Length != 2)
                    return false;
                for (int i = 0; i < 2; i++)
                {
                    char c = part[i];
                    if (!((c >= '0' && c <= '9') ||
                          (c >= 'a' && c <= 'f') ||
                          (c >= 'A' && c <= 'F')))
                        return false;
                }
            }
            return true;
        }

        private void textBox_RawCommand_TextChanged(object sender, EventArgs e)
        {
            button_RawCommand.Enabled = IsValidRawCommandFormat((string)textBox_RawCommand.Text);
        }
    }
  {
    Configuration,
    KeyConfiguration,
    Tester,
    Log,
    WMC,
    XBMC
  }

  class AsyncDisconnect
  {
    public AsyncDisconnect(CECController controller)
    {
      _controller = controller;
    }

    public void Process()
    {
      _controller.Close();
    }

    private CECController _controller;
  }
}
