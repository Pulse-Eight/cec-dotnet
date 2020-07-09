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

using System.Windows.Forms;
using CecSharp;
using System.Collections.Generic;
using LibCECTray.Properties;
using Microsoft.Win32;

namespace LibCECTray.settings
{
  class CECSettings
  {
    #region Key names
    public static string KeyHDMIPort = "global_hdmi_port";
    public static string KeyConnectedToHDMIDevice = "global_connected_to_hdmi_device";
    public static string KeyActivateSource = "global_activate_source";
    public static string KeyAdvancedMode = "global_advanced_mode";
    public static string KeyPhysicalAddress = "global_physical_address";
    public static string KeyOverridePhysicalAddress = "global_override_physical_address";
    public static string KeyDeviceType = "global_device_type";
    public static string KeyTVVendor = "global_tv_vendor";
    public static string KeyOverrideTVVendor = "global_override_tv_vendor";
    public static string KeyWakeDevices = "global_wake_devices";
    public static string KeyPowerOffDevices = "global_standby_devices";
    public static string KeyStartHidden = "global_start_hidden";
    public static string KeyStopTvStandby = "global_stop_tv_standby";
    public static string KeyStandbyScreen = "global_standby_screen";
    public static string KeyTVAutoPowerOn = "global_tv_auto_power_on";
    public static string KeyDetectPhysicalAddress = "global_detect_physical_address";
    #endregion

    public CECSettings(CECSetting.SettingChangedHandler changedHandler)
    {
      _changedHandler = changedHandler;
      Load();
    }

    /// <summary>
    /// Resets all settings to their default values
    /// </summary>
    public void SetDefaultValues()
    {
      foreach (var setting in _settings.Values)
        setting.ResetDefaultValue();
    }

    /// <summary>
    /// Loads all known settings from the registry
    /// </summary>
    private void Load()
    {
      foreach (var setting in _settings.Values)
        setting.Load();
    }

    /// <summary>
    /// Save all settings in the registry
    /// </summary>
    /// <returns>True when persisted, false otherwise</returns>
    public bool Save()
    {
      foreach (var setting in _settings.Values)
        setting.Save();
      return true;
    }

    private bool EnableHDMIPortSetting(CECSetting setting, bool value)
    {
      return value && !OverridePhysicalAddress.Value &&
        !DetectPhysicalAddress.Value;
    }

    private bool EnablePhysicalAddressSetting(CECSetting setting, bool value)
    {
      return value &&
        OverridePhysicalAddress.Value &&
        !DetectPhysicalAddress.Value;
    }

    private bool EnableDetectAddressSetting(CECSetting setting, bool value)
    {
      return value && !OverridePhysicalAddress.Value;
    }

    private bool EnableSettingTVVendor(CECSetting setting, bool value)
    {
      return value && OverrideTVVendor.Value;
    }

    private void OnSettingChanged(CECSetting setting, object oldValue, object newValue)
    {
      SettingChanged?.Invoke(setting, oldValue, newValue);
    }

    #region Global settings
    public CECSettingByte HDMIPort {
      get {
        if (!_settings.ContainsKey(KeyHDMIPort))
        {
          string label = string.Format(Resources.global_hdmi_port, CECSettingLogicalAddress.FormatValue((int)ConnectedDevice.Value));
          CECSettingByte setting = new CECSettingByte(KeyHDMIPort, label, 1, _changedHandler) { LowerLimit = 1, UpperLimit = 15, EnableSetting = EnableHDMIPortSetting };
          setting.Format += delegate (object sender, ListControlConvertEventArgs args)
          {
            if (ushort.TryParse((string)args.Value, out ushort tmp))
              args.Value = "HDMI " + args.Value;
          };
          _settings[KeyHDMIPort] = setting;
          setting.Load();
          setting.SettingChanged += OnSettingChanged;
        }
        return _settings[KeyHDMIPort].AsSettingByte;
      }
    }

    public CECSettingLogicalAddress ConnectedDevice {
      get {
        if (!_settings.ContainsKey(KeyConnectedToHDMIDevice))
        {
          CecLogicalAddresses allowedMask = new CecLogicalAddresses();
          allowedMask.Set(CecLogicalAddress.Tv); allowedMask.Set(CecLogicalAddress.AudioSystem);
          CECSettingLogicalAddress setting = new CECSettingLogicalAddress(KeyConnectedToHDMIDevice,
                                                                          Resources.global_connected_to_hdmi_device,
                                                                          CecLogicalAddress.Tv, _changedHandler)
          {
            AllowedAddressMask = allowedMask,
            EnableSetting = EnableHDMIPortSetting
          };
          _settings[KeyConnectedToHDMIDevice] = setting;
          setting.Load();
          setting.SettingChanged += OnSettingChanged;
        }
        return _settings[KeyConnectedToHDMIDevice].AsSettingLogicalAddress;
      }
    }

    public CECSettingBool ActivateSource {
      get {
        if (!_settings.ContainsKey(KeyActivateSource))
        {
          CECSettingBool setting = new CECSettingBool(KeyActivateSource, Resources.global_activate_source, true,
                                                      _changedHandler)
          { Enabled = false };
          _settings[KeyActivateSource] = setting;
          setting.Load();
          setting.SettingChanged += OnSettingChanged;
        }
        return _settings[KeyActivateSource].AsSettingBool;
      }
    }

    public CECSettingBool AdvancedMode {
      get {
        if (!_settings.ContainsKey(KeyAdvancedMode))
        {
          CECSettingBool setting = new CECSettingBool(KeyAdvancedMode, Resources.global_advanced_mode, false,
                                                      _changedHandler)
          { Enabled = false };
          _settings[KeyAdvancedMode] = setting;
          setting.Load();
          setting.SettingChanged += OnSettingChanged;
        }
        return _settings[KeyAdvancedMode].AsSettingBool;
      }
    }

    public CECSettingUShort PhysicalAddress {
      get {
        if (!_settings.ContainsKey(KeyPhysicalAddress))
        {
          CECSettingUShort setting = new CECSettingUShort(KeyPhysicalAddress, Resources.global_physical_address, 0xFFFF, _changedHandler) { Enabled = false, EnableSetting = EnablePhysicalAddressSetting };
          _settings[KeyPhysicalAddress] = setting;
          setting.StoreInRegistry = false; // use eeprom value
          setting.SettingChanged += OnSettingChanged;
        }
        return _settings[KeyPhysicalAddress].AsSettingUShort;
      }
    }

    public CECSettingBool DetectPhysicalAddress {
      get {
        if (!_settings.ContainsKey(KeyDetectPhysicalAddress))
        {
          CECSettingBool setting = new CECSettingBool(KeyDetectPhysicalAddress,
                                                      Resources.global_detect_physical_address, true, _changedHandler)
          {
            EnableSetting = EnableDetectAddressSetting
          };
          _settings[KeyDetectPhysicalAddress] = setting;
          setting.StoreInRegistry = false; // use libCEC's value
          setting.SettingChanged += OnSettingChanged;
        }
        return _settings[KeyDetectPhysicalAddress].AsSettingBool;
      }
    }

    public CECSettingBool OverridePhysicalAddress {
      get {
        if (!_settings.ContainsKey(KeyOverridePhysicalAddress))
        {
          CECSettingBool setting = new CECSettingBool(KeyOverridePhysicalAddress,
                                                      Resources.global_override_physical_address, false, _changedHandler);
          _settings[KeyOverridePhysicalAddress] = setting;
          setting.Load();
          setting.SettingChanged += OnSettingChanged;
        }
        return _settings[KeyOverridePhysicalAddress].AsSettingBool;
      }
    }

    public CECSettingDeviceType DeviceType {
      get {
        if (!_settings.ContainsKey(KeyDeviceType))
        {
          CecDeviceTypeList allowedTypes = new CecDeviceTypeList();
          allowedTypes.Types[(int)CecDeviceType.RecordingDevice] = CecDeviceType.RecordingDevice;
          allowedTypes.Types[(int)CecDeviceType.PlaybackDevice] = CecDeviceType.PlaybackDevice;

          CECSettingDeviceType setting = new CECSettingDeviceType(KeyDeviceType, Resources.global_device_type,
                                                                  CecDeviceType.RecordingDevice, _changedHandler)
          { Enabled = false, AllowedTypeMask = allowedTypes };
          _settings[KeyDeviceType] = setting;
          setting.StoreInRegistry = false; // use eeprom value
          setting.SettingChanged += OnSettingChanged;
        }
        return _settings[KeyDeviceType].AsSettingDeviceType;
      }
    }

    public CECSettingVendorId TVVendor {
      get {
        if (!_settings.ContainsKey(KeyTVVendor))
        {
          CECSettingVendorId setting = new CECSettingVendorId(KeyTVVendor, Resources.global_tv_vendor,
                                                              CecVendorId.Unknown, _changedHandler)
          { Enabled = false, EnableSetting = EnableSettingTVVendor };
          _settings[KeyTVVendor] = setting;
          setting.Load();
          setting.SettingChanged += OnSettingChanged;
        }
        return _settings[KeyTVVendor].AsSettingVendorId;
      }
    }

    public CECSettingBool OverrideTVVendor {
      get {
        if (!_settings.ContainsKey(KeyOverrideTVVendor))
        {
          CECSettingBool setting = new CECSettingBool(KeyOverrideTVVendor, Resources.global_override_tv_vendor, false,
                                                      _changedHandler)
          { Enabled = false };
          _settings[KeyOverrideTVVendor] = setting;
          setting.Load();
          setting.SettingChanged += OnSettingChanged;
        }
        return _settings[KeyOverrideTVVendor].AsSettingBool;
      }
    }

    public CECSettingLogicalAddresses WakeDevices {
      get {
        if (!_settings.ContainsKey(KeyWakeDevices))
        {
          CecLogicalAddresses defaultDeviceList = new CecLogicalAddresses();
          defaultDeviceList.Set(CecLogicalAddress.Tv);
          CECSettingLogicalAddresses setting = new CECSettingLogicalAddresses(KeyWakeDevices,
                                                                              Resources.global_wake_devices,
                                                                              defaultDeviceList, _changedHandler)
          { Enabled = false };
          _settings[KeyWakeDevices] = setting;
          setting.Load();
          setting.SettingChanged += OnSettingChanged;
        }
        return _settings[KeyWakeDevices].AsSettingLogicalAddresses;
      }
    }

    public CECSettingLogicalAddresses PowerOffDevices {
      get {
        if (!_settings.ContainsKey(KeyPowerOffDevices))
        {
          CecLogicalAddresses defaultDeviceList = new CecLogicalAddresses();
          defaultDeviceList.Set(CecLogicalAddress.Tv);
          CECSettingLogicalAddresses setting = new CECSettingLogicalAddresses(KeyPowerOffDevices,
                                                                              Resources.global_standby_devices,
                                                                              defaultDeviceList,
                                                                              _changedHandler)
          { Enabled = false };
          _settings[KeyPowerOffDevices] = setting;
          setting.Load();
          setting.SettingChanged += OnSettingChanged;
        }
        return _settings[KeyPowerOffDevices].AsSettingLogicalAddresses;
      }
    }

    public CECSettingBool StartHidden {
      get {
        if (!_settings.ContainsKey(KeyStartHidden))
        {
          CECSettingBool setting = new CECSettingBool(KeyStartHidden, Resources.global_start_hidden, false, _changedHandler);
          _settings[KeyStartHidden] = setting;
          setting.Load();
          setting.SettingChanged += OnSettingChanged;
        }
        return _settings[KeyStartHidden].AsSettingBool;
      }
    }

    public CECSettingBool StopTvStandby {
      get {
        if (!_settings.ContainsKey(KeyStopTvStandby))
        {
          CECSettingBool setting = new CECSettingBool(KeyStopTvStandby, Resources.global_stop_tv_standby, true, _changedHandler);
          _settings[KeyStopTvStandby] = setting;
          setting.Load();
          setting.SettingChanged += OnSettingChanged;

        }
        return _settings[KeyStopTvStandby].AsSettingBool;
      }
    }

    public CECSettingBool TVAutoPowerOn {
      get {
        if (!_settings.ContainsKey(KeyTVAutoPowerOn))
        {
          CECSettingBool setting = new CECSettingBool(KeyTVAutoPowerOn, Resources.global_tv_auto_power_on, true, _changedHandler);
          _settings[KeyTVAutoPowerOn] = setting;
          setting.StoreInRegistry = false; // use eeprom value
          setting.SettingChanged += OnSettingChanged;
        }
        return _settings[KeyTVAutoPowerOn].AsSettingBool;
      }
    }

    public CECSettingIdleTime StandbyScreen {
      get {
        if (!_settings.ContainsKey(KeyStandbyScreen))
        {
          CECSettingIdleTime setting = new CECSettingIdleTime(KeyStandbyScreen, Resources.global_standby_screen, TimeoutSetting.Setting.Disabled, _changedHandler);
          _settings[KeyStandbyScreen] = setting;
          setting.Load();
          setting.SettingChanged += OnSettingChanged;
        }
        return _settings[KeyStandbyScreen].AsSettingIdleTime;
      }
    }
    #endregion

    public bool ContainsKey(string key)
    {
      return _settings.ContainsKey(key);
    }

    public void SetVendorName(CecLogicalAddress address, CecVendorId vendorId, string vendorName)
    {
      VendorNames[(int)address] = vendorName;

      if (address == CecLogicalAddress.Tv && vendorId == CecVendorId.Panasonic)
      {
        DeviceType.AllowedTypeMask = new CecDeviceTypeList {Types = new[] {CecDeviceType.PlaybackDevice}};
      }

      foreach (var setting in _settings)
      {
        if (setting.Value.SettingType == CECSettingType.LogicalAddress)
          setting.Value.AsSettingLogicalAddress.ResetItems(true);
      }
    }

    public bool Enabled
    {
      set
      {
        foreach (var setting in _settings)
          if (setting.Value != null)
            setting.Value.Enabled = value;
      }
      get
      {
        var enabled = true;
        foreach (var setting in _settings)
          enabled &= setting.Value.Enabled;
        return enabled;
      }
    }

    /// <summary>
    /// Read or write one of the settings, given it's key
    /// </summary>
    /// <param name="key">The key of the setting</param>
    /// <returns>The setting</returns>
    public CECSetting this[string key]
    {
      get { return _settings.ContainsKey(key) ? _settings[key] : null; }
      set {_settings[key] = value; }
    }

    private readonly Dictionary<string, CECSetting> _settings = new Dictionary<string, CECSetting>();

    private readonly CECSetting.SettingChangedHandler _changedHandler;
    public event CECSetting.SettingChangedHandler SettingChanged;

    public static readonly string[] VendorNames = new string[15]; // one for every device on the bus
  }
}
