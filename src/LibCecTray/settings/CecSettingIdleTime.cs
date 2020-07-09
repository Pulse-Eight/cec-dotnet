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

using System.Collections.Generic;
using System.Windows.Forms;

namespace LibCECTray.settings
{
  /// <summary>
  /// A setting of type TimeoutSetting that can be saved in the registry
  /// </summary>
  class CECSettingIdleTime : CECSettingNumeric
  {
    public CECSettingIdleTime(string keyName, string friendlyName, TimeoutSetting.Setting defaultValue, SettingChangedHandler changedHandler) :
      base(CECSettingType.Numeric, keyName, friendlyName, (int)defaultValue, changedHandler, OnFormat)
    {
      LowerLimit = (int)TimeoutSetting.Setting.Disabled;
      UpperLimit = (int)TimeoutSetting.Setting.Hr6;
    }

    private static void OnFormat(object sender, ListControlConvertEventArgs listControlConvertEventArgs)
    {
      int iValue;
      if (int.TryParse((string)listControlConvertEventArgs.Value, out iValue))
        listControlConvertEventArgs.Value = FormatValue(iValue);
    }

    public bool TimeoutEnabled {
      get {
        return Value.Seconds > 0;
      }
    }

    public new TimeoutSetting Value {
      get { return new TimeoutSetting((TimeoutSetting.Setting)base.Value); }
      set {
        if (base.Value != (int)value.Value)
          base.Value = (int)value.Value;
      }
    }

    public new TimeoutSetting DefaultValue {
      get { return new TimeoutSetting((TimeoutSetting.Setting)base.DefaultValue); }
      set { base.DefaultValue = (int)value.Value; }
    }

    private static string FormatValue(int value)
    {
      return new TimeoutSetting((TimeoutSetting.Setting)value).Label;
    }
  }

  public class TimeoutSettings : LinkedList<TimeoutSetting>
  {
    public TimeoutSettings()
    {
      AddLast(new TimeoutSetting(TimeoutSetting.Setting.Disabled));
      AddLast(new TimeoutSetting(TimeoutSetting.Setting.Min1));
      AddLast(new TimeoutSetting(TimeoutSetting.Setting.Min2));
      AddLast(new TimeoutSetting(TimeoutSetting.Setting.Min5));
      AddLast(new TimeoutSetting(TimeoutSetting.Setting.Min10));
      AddLast(new TimeoutSetting(TimeoutSetting.Setting.Min15));
      AddLast(new TimeoutSetting(TimeoutSetting.Setting.Min30));
      AddLast(new TimeoutSetting(TimeoutSetting.Setting.Hr1));
      AddLast(new TimeoutSetting(TimeoutSetting.Setting.Hr2));
      AddLast(new TimeoutSetting(TimeoutSetting.Setting.Hr3));
      AddLast(new TimeoutSetting(TimeoutSetting.Setting.Hr6));
    }
  }

  public class TimeoutSetting
  {
    public enum Setting
    {
      Disabled,
      Min1,
      Min2,
      Min5,
      Min10,
      Min15,
      Min30,
      Hr1,
      Hr2,
      Hr3,
      Hr6,
    }

    public TimeoutSetting(Setting setting)
    {
      Value = setting;
      switch (setting)
      {
        case Setting.Disabled:
          Label = "Disabled";
          Seconds = -1;
          break;
        case Setting.Min1:
          Label = "1 minute";
          Seconds = 60;
          break;
        case Setting.Min2:
          Label = "2 minutes";
          Seconds = 2 * 60;
          break;
        case Setting.Min5:
          Label = "5 minutes";
          Seconds = 5 * 60;
          break;
        case Setting.Min10:
          Label = "10 minutes";
          Seconds = 10 * 60;
          break;
        case Setting.Min15:
          Label = "15 minutes";
          Seconds = 15 * 60;
          break;
        case Setting.Min30:
          Label = "30 minutes";
          Seconds = 30 * 60;
          break;
        case Setting.Hr1:
          Label = "1 hour";
          Seconds = 60 * 60;
          break;
        case Setting.Hr2:
          Label = "2 hours";
          Seconds = 2 * 60 * 60;
          break;
        case Setting.Hr3:
          Label = "3 hours";
          Seconds = 3 * 60 * 60;
          break;
        case Setting.Hr6:
          Label = "6 hours";
          Seconds = 6 * 60 * 60;
          break;
      }
    }
    public Setting Value { get; private set; }
    public string Label { get; private set; }
    public int Seconds { get; private set; }
  }
}
