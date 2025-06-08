namespace LibCECTray.ui
{
  partial class CECTray
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CECTray));
            this.pProgress = new System.Windows.Forms.ProgressBar();
            this.lStatus = new System.Windows.Forms.Label();
            this.helpPortNumber = new System.Windows.Forms.ToolTip(this.components);
            this.cbPortNumber = new System.Windows.Forms.ComboBox();
            this.cbStandbyScreen = new System.Windows.Forms.ComboBox();
            this.helpConnectedHDMIDevice = new System.Windows.Forms.ToolTip(this.components);
            this.cbConnectedDevice = new System.Windows.Forms.ComboBox();
            this.helpPhysicalAddress = new System.Windows.Forms.ToolTip(this.components);
            this.tbPhysicalAddress = new System.Windows.Forms.TextBox();
            this.helpDeviceType = new System.Windows.Forms.ToolTip(this.components);
            this.cbDeviceType = new System.Windows.Forms.ComboBox();
            this.cbVendorId = new System.Windows.Forms.ComboBox();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsAdvanced = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuShowHide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsMenuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.LogOutput = new System.Windows.Forms.TabPage();
            this.bSaveLog = new System.Windows.Forms.Button();
            this.bClearLog = new System.Windows.Forms.Button();
            this.cbLogDebug = new System.Windows.Forms.CheckBox();
            this.cbLogTraffic = new System.Windows.Forms.CheckBox();
            this.cbLogNotice = new System.Windows.Forms.CheckBox();
            this.cbLogWarning = new System.Windows.Forms.CheckBox();
            this.cbLogError = new System.Windows.Forms.CheckBox();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.tbTestCommands = new System.Windows.Forms.TabPage();
            this.textBox_RawCommand = new System.Windows.Forms.TextBox();
            this.button_RawCommand = new System.Windows.Forms.Button();
            this.bRescanDevices = new System.Windows.Forms.Button();
            this.bMute = new System.Windows.Forms.Button();
            this.bVolDown = new System.Windows.Forms.Button();
            this.bVolUp = new System.Windows.Forms.Button();
            this.bActivateSource = new System.Windows.Forms.Button();
            this.bScan = new System.Windows.Forms.Button();
            this.bStandby = new System.Windows.Forms.Button();
            this.bSendImageViewOn = new System.Windows.Forms.Button();
            this.lDestination = new System.Windows.Forms.Label();
            this.cbCommandDestination = new System.Windows.Forms.ComboBox();
            this.Configuration = new System.Windows.Forms.TabPage();
            this.cbDetectAddress = new System.Windows.Forms.CheckBox();
            this.bFirmwareUpgrade = new System.Windows.Forms.Button();
            this.lFirmwareVersion = new System.Windows.Forms.Label();
            this.pbFirmwareUpgrade = new System.Windows.Forms.PictureBox();
            this.lFirmware = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbHDMI = new System.Windows.Forms.PictureBox();
            this.cbStartMinimised = new System.Windows.Forms.CheckBox();
            this.cbOverrideAddress = new System.Windows.Forms.CheckBox();
            this.bReloadConfig = new System.Windows.Forms.Button();
            this.cbVendorOverride = new System.Windows.Forms.CheckBox();
            this.lPlayerConfig = new System.Windows.Forms.Label();
            this.lAdapterConfig = new System.Windows.Forms.Label();
            this.lDeviceType = new System.Windows.Forms.Label();
            this.lConnectedDevice = new System.Windows.Forms.Label();
            this.lPortNumber = new System.Windows.Forms.Label();
            this.tabPanel = new System.Windows.Forms.TabControl();
            this.powerTab = new System.Windows.Forms.TabPage();
            this.bReloadConfig2 = new System.Windows.Forms.Button();
            this.cbTVAutoPowerOn = new System.Windows.Forms.CheckBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbIdleTime = new System.Windows.Forms.ProgressBar();
            this.lStandbyScreen = new System.Windows.Forms.Label();
            this.cbStopTvStandby = new System.Windows.Forms.CheckBox();
            this.lPowerOff = new System.Windows.Forms.Label();
            this.cbPowerOffDevices = new System.Windows.Forms.CheckedListBox();
            this.lWakeDevices = new System.Windows.Forms.Label();
            this.cbWakeDevices = new System.Windows.Forms.CheckedListBox();
            this.cbActivateSource = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbAlert = new System.Windows.Forms.PictureBox();
            this.trayIconMenu.SuspendLayout();
            this.LogOutput.SuspendLayout();
            this.tbTestCommands.SuspendLayout();
            this.Configuration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirmwareUpgrade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHDMI)).BeginInit();
            this.tabPanel.SuspendLayout();
            this.powerTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlert)).BeginInit();
            this.SuspendLayout();
            // 
            // pProgress
            // 
            this.pProgress.Location = new System.Drawing.Point(314, 407);
            this.pProgress.Name = "pProgress";
            this.pProgress.Size = new System.Drawing.Size(298, 23);
            this.pProgress.TabIndex = 1;
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = true;
            this.lStatus.Location = new System.Drawing.Point(42, 414);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(61, 13);
            this.lStatus.TabIndex = 2;
            this.lStatus.Text = "Initialising...";
            // 
            // cbPortNumber
            // 
            this.cbPortNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbPortNumber.Enabled = false;
            this.cbPortNumber.FormattingEnabled = true;
            this.cbPortNumber.Location = new System.Drawing.Point(199, 60);
            this.cbPortNumber.Name = "cbPortNumber";
            this.cbPortNumber.Size = new System.Drawing.Size(133, 21);
            this.cbPortNumber.TabIndex = 11;
            this.cbPortNumber.Text = "global_hdmi_port";
            this.helpPortNumber.SetToolTip(this.cbPortNumber, "The HDMI port number, to which you connected your USB-CEC adapter.");
            // 
            // cbStandbyScreen
            // 
            this.cbStandbyScreen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbStandbyScreen.Enabled = false;
            this.cbStandbyScreen.FormattingEnabled = true;
            this.cbStandbyScreen.Location = new System.Drawing.Point(40, 267);
            this.cbStandbyScreen.Name = "cbStandbyScreen";
            this.cbStandbyScreen.Size = new System.Drawing.Size(123, 21);
            this.cbStandbyScreen.TabIndex = 43;
            this.cbStandbyScreen.Text = "global_standby_screen";
            this.helpPortNumber.SetToolTip(this.cbStandbyScreen, "The HDMI port number, to which you connected your USB-CEC adapter.");
            // 
            // cbConnectedDevice
            // 
            this.cbConnectedDevice.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbConnectedDevice.Enabled = false;
            this.cbConnectedDevice.FormattingEnabled = true;
            this.cbConnectedDevice.Location = new System.Drawing.Point(199, 33);
            this.cbConnectedDevice.Name = "cbConnectedDevice";
            this.cbConnectedDevice.Size = new System.Drawing.Size(133, 21);
            this.cbConnectedDevice.TabIndex = 5;
            this.cbConnectedDevice.Text = "global_connected_to_hdmi_device";
            this.helpConnectedHDMIDevice.SetToolTip(this.cbConnectedDevice, "The HDMI device to which the USB-CEC adapter is connected");
            // 
            // tbPhysicalAddress
            // 
            this.tbPhysicalAddress.Enabled = false;
            this.tbPhysicalAddress.Location = new System.Drawing.Point(199, 87);
            this.tbPhysicalAddress.MaxLength = 4;
            this.tbPhysicalAddress.Name = "tbPhysicalAddress";
            this.tbPhysicalAddress.Size = new System.Drawing.Size(38, 20);
            this.tbPhysicalAddress.TabIndex = 6;
            this.tbPhysicalAddress.Text = "global_override_physical_address";
            this.helpPhysicalAddress.SetToolTip(this.tbPhysicalAddress, "The physical address of the adapter. Leave this untouched if you want to autodete" +
        "ct this value.");
            // 
            // cbDeviceType
            // 
            this.cbDeviceType.Enabled = false;
            this.cbDeviceType.FormattingEnabled = true;
            this.cbDeviceType.Location = new System.Drawing.Point(199, 113);
            this.cbDeviceType.Name = "cbDeviceType";
            this.cbDeviceType.Size = new System.Drawing.Size(133, 21);
            this.cbDeviceType.TabIndex = 14;
            this.cbDeviceType.Text = "global_device_type";
            this.helpDeviceType.SetToolTip(this.cbDeviceType, "Set this to \'Player\' when your TV is having problems with \'Recorder\'");
            // 
            // cbVendorId
            // 
            this.cbVendorId.Enabled = false;
            this.cbVendorId.FormattingEnabled = true;
            this.cbVendorId.Location = new System.Drawing.Point(199, 140);
            this.cbVendorId.Name = "cbVendorId";
            this.cbVendorId.Size = new System.Drawing.Size(133, 21);
            this.cbVendorId.TabIndex = 28;
            this.cbVendorId.Text = "global_override_tv_vendor";
            this.helpDeviceType.SetToolTip(this.cbVendorId, "Only set this value when autodetection isn\'t working");
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayIconMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "Pulse-Eight USB-CEC Adapter";
            this.trayIcon.Visible = true;
            this.trayIcon.Click += new System.EventHandler(this.TrayIconClick);
            // 
            // trayIconMenu
            // 
            this.trayIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAdvanced,
            this.tsMenuShowHide,
            this.toolStripSeparator1,
            this.tsMenuClose});
            this.trayIconMenu.Name = "trayIconMenu";
            this.trayIconMenu.Size = new System.Drawing.Size(162, 76);
            // 
            // tsAdvanced
            // 
            this.tsAdvanced.Name = "tsAdvanced";
            this.tsAdvanced.Size = new System.Drawing.Size(161, 22);
            this.tsAdvanced.Text = "Advanced mode";
            this.tsAdvanced.Click += new System.EventHandler(this.TsAdvancedClick);
            // 
            // tsMenuShowHide
            // 
            this.tsMenuShowHide.Name = "tsMenuShowHide";
            this.tsMenuShowHide.Size = new System.Drawing.Size(161, 22);
            this.tsMenuShowHide.Text = "Hide";
            this.tsMenuShowHide.Click += new System.EventHandler(this.TsMenuShowHideClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(158, 6);
            // 
            // tsMenuClose
            // 
            this.tsMenuClose.Name = "tsMenuClose";
            this.tsMenuClose.Size = new System.Drawing.Size(161, 22);
            this.tsMenuClose.Text = "Exit";
            this.tsMenuClose.Click += new System.EventHandler(this.TsMenuCloseClick);
            // 
            // LogOutput
            // 
            this.LogOutput.Controls.Add(this.bSaveLog);
            this.LogOutput.Controls.Add(this.bClearLog);
            this.LogOutput.Controls.Add(this.cbLogDebug);
            this.LogOutput.Controls.Add(this.cbLogTraffic);
            this.LogOutput.Controls.Add(this.cbLogNotice);
            this.LogOutput.Controls.Add(this.cbLogWarning);
            this.LogOutput.Controls.Add(this.cbLogError);
            this.LogOutput.Controls.Add(this.tbLog);
            this.LogOutput.Location = new System.Drawing.Point(4, 22);
            this.LogOutput.Name = "LogOutput";
            this.LogOutput.Padding = new System.Windows.Forms.Padding(3);
            this.LogOutput.Size = new System.Drawing.Size(592, 344);
            this.LogOutput.TabIndex = 1;
            this.LogOutput.Text = "Log Output";
            this.LogOutput.UseVisualStyleBackColor = true;
            // 
            // bSaveLog
            // 
            this.bSaveLog.Location = new System.Drawing.Point(429, 318);
            this.bSaveLog.Name = "bSaveLog";
            this.bSaveLog.Size = new System.Drawing.Size(75, 23);
            this.bSaveLog.TabIndex = 7;
            this.bSaveLog.Text = "Save";
            this.bSaveLog.UseVisualStyleBackColor = true;
            this.bSaveLog.Click += new System.EventHandler(this.BSaveLogClick);
            // 
            // bClearLog
            // 
            this.bClearLog.Location = new System.Drawing.Point(510, 318);
            this.bClearLog.Name = "bClearLog";
            this.bClearLog.Size = new System.Drawing.Size(75, 23);
            this.bClearLog.TabIndex = 6;
            this.bClearLog.Text = "Clear";
            this.bClearLog.UseVisualStyleBackColor = true;
            this.bClearLog.Click += new System.EventHandler(this.BClearLogClick);
            // 
            // cbLogDebug
            // 
            this.cbLogDebug.AutoSize = true;
            this.cbLogDebug.Checked = true;
            this.cbLogDebug.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLogDebug.Location = new System.Drawing.Point(268, 324);
            this.cbLogDebug.Name = "cbLogDebug";
            this.cbLogDebug.Size = new System.Drawing.Size(58, 17);
            this.cbLogDebug.TabIndex = 5;
            this.cbLogDebug.Text = "Debug";
            this.cbLogDebug.UseVisualStyleBackColor = true;
            // 
            // cbLogTraffic
            // 
            this.cbLogTraffic.AutoSize = true;
            this.cbLogTraffic.Checked = true;
            this.cbLogTraffic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLogTraffic.Location = new System.Drawing.Point(206, 324);
            this.cbLogTraffic.Name = "cbLogTraffic";
            this.cbLogTraffic.Size = new System.Drawing.Size(56, 17);
            this.cbLogTraffic.TabIndex = 4;
            this.cbLogTraffic.Text = "Traffic";
            this.cbLogTraffic.UseVisualStyleBackColor = true;
            // 
            // cbLogNotice
            // 
            this.cbLogNotice.AutoSize = true;
            this.cbLogNotice.Checked = true;
            this.cbLogNotice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLogNotice.Location = new System.Drawing.Point(137, 324);
            this.cbLogNotice.Name = "cbLogNotice";
            this.cbLogNotice.Size = new System.Drawing.Size(62, 17);
            this.cbLogNotice.TabIndex = 3;
            this.cbLogNotice.Text = "Notices";
            this.cbLogNotice.UseVisualStyleBackColor = true;
            // 
            // cbLogWarning
            // 
            this.cbLogWarning.AutoSize = true;
            this.cbLogWarning.Checked = true;
            this.cbLogWarning.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLogWarning.Location = new System.Drawing.Point(65, 324);
            this.cbLogWarning.Name = "cbLogWarning";
            this.cbLogWarning.Size = new System.Drawing.Size(66, 17);
            this.cbLogWarning.TabIndex = 2;
            this.cbLogWarning.Text = "Warning";
            this.cbLogWarning.UseVisualStyleBackColor = true;
            // 
            // cbLogError
            // 
            this.cbLogError.AutoSize = true;
            this.cbLogError.Checked = true;
            this.cbLogError.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLogError.Location = new System.Drawing.Point(6, 324);
            this.cbLogError.Name = "cbLogError";
            this.cbLogError.Size = new System.Drawing.Size(53, 17);
            this.cbLogError.TabIndex = 1;
            this.cbLogError.Text = "Errors";
            this.cbLogError.UseVisualStyleBackColor = true;
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(6, 0);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(580, 312);
            this.tbLog.TabIndex = 0;
            // 
            // tbTestCommands
            // 
            this.tbTestCommands.Controls.Add(this.textBox_RawCommand);
            this.tbTestCommands.Controls.Add(this.button_RawCommand);
            this.tbTestCommands.Controls.Add(this.bRescanDevices);
            this.tbTestCommands.Controls.Add(this.bMute);
            this.tbTestCommands.Controls.Add(this.bVolDown);
            this.tbTestCommands.Controls.Add(this.bVolUp);
            this.tbTestCommands.Controls.Add(this.bActivateSource);
            this.tbTestCommands.Controls.Add(this.bScan);
            this.tbTestCommands.Controls.Add(this.bStandby);
            this.tbTestCommands.Controls.Add(this.bSendImageViewOn);
            this.tbTestCommands.Controls.Add(this.lDestination);
            this.tbTestCommands.Controls.Add(this.cbCommandDestination);
            this.tbTestCommands.Location = new System.Drawing.Point(4, 22);
            this.tbTestCommands.Name = "tbTestCommands";
            this.tbTestCommands.Padding = new System.Windows.Forms.Padding(3);
            this.tbTestCommands.Size = new System.Drawing.Size(592, 344);
            this.tbTestCommands.TabIndex = 3;
            this.tbTestCommands.Text = "CEC tester";
            this.tbTestCommands.UseVisualStyleBackColor = true;
            // 
            // textBox_RawCommand
            // 
            this.textBox_RawCommand.Location = new System.Drawing.Point(164, 177);
            this.textBox_RawCommand.Name = "textBox_RawCommand";
            this.textBox_RawCommand.Size = new System.Drawing.Size(100, 20);
            this.textBox_RawCommand.TabIndex = 11;
            this.textBox_RawCommand.TextChanged += new System.EventHandler(this.textBox_RawCommand_TextChanged);
            // 
            // button_RawCommand
            // 
            this.button_RawCommand.Enabled = false;
            this.button_RawCommand.Location = new System.Drawing.Point(8, 175);
            this.button_RawCommand.Name = "button_RawCommand";
            this.button_RawCommand.Size = new System.Drawing.Size(150, 23);
            this.button_RawCommand.TabIndex = 10;
            this.button_RawCommand.Text = "Send raw command";
            this.button_RawCommand.UseVisualStyleBackColor = true;
            this.button_RawCommand.Click += new System.EventHandler(this.button_RawCommand_Click);
            // 
            // bRescanDevices
            // 
            this.bRescanDevices.Enabled = false;
            this.bRescanDevices.Location = new System.Drawing.Point(424, 65);
            this.bRescanDevices.Name = "bRescanDevices";
            this.bRescanDevices.Size = new System.Drawing.Size(150, 23);
            this.bRescanDevices.TabIndex = 9;
            this.bRescanDevices.Text = "Re-scan devices";
            this.bRescanDevices.UseVisualStyleBackColor = true;
            this.bRescanDevices.Click += new System.EventHandler(this.BRescanDevicesClick);
            // 
            // bMute
            // 
            this.bMute.Enabled = false;
            this.bMute.Location = new System.Drawing.Point(164, 65);
            this.bMute.Name = "bMute";
            this.bMute.Size = new System.Drawing.Size(150, 23);
            this.bMute.TabIndex = 8;
            this.bMute.Text = "Mute";
            this.bMute.UseVisualStyleBackColor = true;
            this.bMute.Click += new System.EventHandler(this.BMuteClick);
            // 
            // bVolDown
            // 
            this.bVolDown.Enabled = false;
            this.bVolDown.Location = new System.Drawing.Point(164, 36);
            this.bVolDown.Name = "bVolDown";
            this.bVolDown.Size = new System.Drawing.Size(150, 23);
            this.bVolDown.TabIndex = 7;
            this.bVolDown.Text = "Volume down";
            this.bVolDown.UseVisualStyleBackColor = true;
            this.bVolDown.Click += new System.EventHandler(this.BVolDownClick);
            // 
            // bVolUp
            // 
            this.bVolUp.Enabled = false;
            this.bVolUp.Location = new System.Drawing.Point(164, 7);
            this.bVolUp.Name = "bVolUp";
            this.bVolUp.Size = new System.Drawing.Size(150, 23);
            this.bVolUp.TabIndex = 6;
            this.bVolUp.Text = "Volume up";
            this.bVolUp.UseVisualStyleBackColor = true;
            this.bVolUp.Click += new System.EventHandler(this.BVolUpClick);
            // 
            // bActivateSource
            // 
            this.bActivateSource.Enabled = false;
            this.bActivateSource.Location = new System.Drawing.Point(8, 65);
            this.bActivateSource.Name = "bActivateSource";
            this.bActivateSource.Size = new System.Drawing.Size(150, 23);
            this.bActivateSource.TabIndex = 5;
            this.bActivateSource.Text = "Make device active";
            this.bActivateSource.UseVisualStyleBackColor = true;
            this.bActivateSource.Click += new System.EventHandler(this.BActivateSourceClick);
            // 
            // bScan
            // 
            this.bScan.Enabled = false;
            this.bScan.Location = new System.Drawing.Point(8, 94);
            this.bScan.Name = "bScan";
            this.bScan.Size = new System.Drawing.Size(150, 23);
            this.bScan.TabIndex = 4;
            this.bScan.Text = "Device information";
            this.bScan.UseVisualStyleBackColor = true;
            this.bScan.Click += new System.EventHandler(this.BScanClick);
            // 
            // bStandby
            // 
            this.bStandby.Enabled = false;
            this.bStandby.Location = new System.Drawing.Point(8, 36);
            this.bStandby.Name = "bStandby";
            this.bStandby.Size = new System.Drawing.Size(150, 23);
            this.bStandby.TabIndex = 3;
            this.bStandby.Text = "Put device in standby";
            this.bStandby.UseVisualStyleBackColor = true;
            this.bStandby.Click += new System.EventHandler(this.BStandbyClick);
            // 
            // bSendImageViewOn
            // 
            this.bSendImageViewOn.Enabled = false;
            this.bSendImageViewOn.Location = new System.Drawing.Point(8, 7);
            this.bSendImageViewOn.Name = "bSendImageViewOn";
            this.bSendImageViewOn.Size = new System.Drawing.Size(150, 23);
            this.bSendImageViewOn.TabIndex = 2;
            this.bSendImageViewOn.Text = "Power on device";
            this.bSendImageViewOn.UseVisualStyleBackColor = true;
            this.bSendImageViewOn.Click += new System.EventHandler(this.BSendImageViewOnClick);
            // 
            // lDestination
            // 
            this.lDestination.AutoSize = true;
            this.lDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDestination.Location = new System.Drawing.Point(420, 3);
            this.lDestination.Name = "lDestination";
            this.lDestination.Size = new System.Drawing.Size(138, 24);
            this.lDestination.TabIndex = 1;
            this.lDestination.Text = "Target device";
            // 
            // cbCommandDestination
            // 
            this.cbCommandDestination.FormattingEnabled = true;
            this.cbCommandDestination.Items.AddRange(new object[] {
            "0: TV",
            "F: Broadcast"});
            this.cbCommandDestination.Location = new System.Drawing.Point(437, 30);
            this.cbCommandDestination.Name = "cbCommandDestination";
            this.cbCommandDestination.Size = new System.Drawing.Size(121, 21);
            this.cbCommandDestination.TabIndex = 0;
            this.cbCommandDestination.Text = "0: TV";
            this.cbCommandDestination.SelectedIndexChanged += new System.EventHandler(this.CbCommandDestinationSelectedIndexChanged);
            // 
            // Configuration
            // 
            this.Configuration.Controls.Add(this.cbDetectAddress);
            this.Configuration.Controls.Add(this.bFirmwareUpgrade);
            this.Configuration.Controls.Add(this.lFirmwareVersion);
            this.Configuration.Controls.Add(this.pbFirmwareUpgrade);
            this.Configuration.Controls.Add(this.lFirmware);
            this.Configuration.Controls.Add(this.pictureBox1);
            this.Configuration.Controls.Add(this.pbHDMI);
            this.Configuration.Controls.Add(this.cbStartMinimised);
            this.Configuration.Controls.Add(this.cbOverrideAddress);
            this.Configuration.Controls.Add(this.bReloadConfig);
            this.Configuration.Controls.Add(this.cbVendorOverride);
            this.Configuration.Controls.Add(this.cbVendorId);
            this.Configuration.Controls.Add(this.lPlayerConfig);
            this.Configuration.Controls.Add(this.lAdapterConfig);
            this.Configuration.Controls.Add(this.cbDeviceType);
            this.Configuration.Controls.Add(this.cbPortNumber);
            this.Configuration.Controls.Add(this.tbPhysicalAddress);
            this.Configuration.Controls.Add(this.cbConnectedDevice);
            this.Configuration.Controls.Add(this.lDeviceType);
            this.Configuration.Controls.Add(this.lConnectedDevice);
            this.Configuration.Controls.Add(this.lPortNumber);
            this.Configuration.Location = new System.Drawing.Point(4, 22);
            this.Configuration.Name = "Configuration";
            this.Configuration.Padding = new System.Windows.Forms.Padding(3);
            this.Configuration.Size = new System.Drawing.Size(592, 344);
            this.Configuration.TabIndex = 0;
            this.Configuration.Text = "Configuration";
            this.Configuration.UseVisualStyleBackColor = true;
            // 
            // cbDetectAddress
            // 
            this.cbDetectAddress.AutoSize = true;
            this.cbDetectAddress.Location = new System.Drawing.Point(358, 35);
            this.cbDetectAddress.Name = "cbDetectAddress";
            this.cbDetectAddress.Size = new System.Drawing.Size(177, 17);
            this.cbDetectAddress.TabIndex = 39;
            this.cbDetectAddress.Text = "global_detect_physical_address";
            this.cbDetectAddress.UseVisualStyleBackColor = true;
            // 
            // bFirmwareUpgrade
            // 
            this.bFirmwareUpgrade.Enabled = false;
            this.bFirmwareUpgrade.Location = new System.Drawing.Point(199, 265);
            this.bFirmwareUpgrade.Name = "bFirmwareUpgrade";
            this.bFirmwareUpgrade.Size = new System.Drawing.Size(125, 23);
            this.bFirmwareUpgrade.TabIndex = 38;
            this.bFirmwareUpgrade.Text = "Upgrade";
            this.bFirmwareUpgrade.UseVisualStyleBackColor = true;
            this.bFirmwareUpgrade.Visible = false;
            this.bFirmwareUpgrade.Click += new System.EventHandler(this.bFirmwareUpgradeClick);
            // 
            // lFirmwareVersion
            // 
            this.lFirmwareVersion.AutoSize = true;
            this.lFirmwareVersion.Location = new System.Drawing.Point(37, 270);
            this.lFirmwareVersion.Name = "lFirmwareVersion";
            this.lFirmwareVersion.Size = new System.Drawing.Size(94, 13);
            this.lFirmwareVersion.TabIndex = 37;
            this.lFirmwareVersion.Text = "(unknown version)";
            this.lFirmwareVersion.Visible = false;
            // 
            // pbFirmwareUpgrade
            // 
            this.pbFirmwareUpgrade.BackgroundImage = global::LibCECTray.Properties.Resources.settings;
            this.pbFirmwareUpgrade.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbFirmwareUpgrade.Location = new System.Drawing.Point(6, 237);
            this.pbFirmwareUpgrade.Name = "pbFirmwareUpgrade";
            this.pbFirmwareUpgrade.Size = new System.Drawing.Size(24, 24);
            this.pbFirmwareUpgrade.TabIndex = 36;
            this.pbFirmwareUpgrade.TabStop = false;
            this.pbFirmwareUpgrade.Visible = false;
            // 
            // lFirmware
            // 
            this.lFirmware.AutoSize = true;
            this.lFirmware.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFirmware.Location = new System.Drawing.Point(36, 237);
            this.lFirmware.Name = "lFirmware";
            this.lFirmware.Size = new System.Drawing.Size(97, 24);
            this.lFirmware.TabIndex = 35;
            this.lFirmware.Text = "Firmware";
            this.lFirmware.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::LibCECTray.Properties.Resources.computer;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(6, 172);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // pbHDMI
            // 
            this.pbHDMI.BackgroundImage = global::LibCECTray.Properties.Resources.hdmi;
            this.pbHDMI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbHDMI.Location = new System.Drawing.Point(6, 6);
            this.pbHDMI.Name = "pbHDMI";
            this.pbHDMI.Size = new System.Drawing.Size(24, 24);
            this.pbHDMI.TabIndex = 33;
            this.pbHDMI.TabStop = false;
            // 
            // cbStartMinimised
            // 
            this.cbStartMinimised.AutoSize = true;
            this.cbStartMinimised.Enabled = false;
            this.cbStartMinimised.Location = new System.Drawing.Point(40, 208);
            this.cbStartMinimised.Name = "cbStartMinimised";
            this.cbStartMinimised.Size = new System.Drawing.Size(118, 17);
            this.cbStartMinimised.TabIndex = 32;
            this.cbStartMinimised.Text = "global_start_hidden";
            this.cbStartMinimised.UseVisualStyleBackColor = true;
            // 
            // cbOverrideAddress
            // 
            this.cbOverrideAddress.AutoSize = true;
            this.cbOverrideAddress.Enabled = false;
            this.cbOverrideAddress.Location = new System.Drawing.Point(40, 89);
            this.cbOverrideAddress.Name = "cbOverrideAddress";
            this.cbOverrideAddress.Size = new System.Drawing.Size(151, 17);
            this.cbOverrideAddress.TabIndex = 31;
            this.cbOverrideAddress.Text = "override_physical_address";
            this.cbOverrideAddress.UseVisualStyleBackColor = true;
            // 
            // bReloadConfig
            // 
            this.bReloadConfig.Enabled = false;
            this.bReloadConfig.Location = new System.Drawing.Point(461, 315);
            this.bReloadConfig.Name = "bReloadConfig";
            this.bReloadConfig.Size = new System.Drawing.Size(125, 23);
            this.bReloadConfig.TabIndex = 30;
            this.bReloadConfig.Text = "Reset configuration";
            this.bReloadConfig.UseVisualStyleBackColor = true;
            this.bReloadConfig.Click += new System.EventHandler(this.BReloadConfigClick);
            // 
            // cbVendorOverride
            // 
            this.cbVendorOverride.AutoSize = true;
            this.cbVendorOverride.Enabled = false;
            this.cbVendorOverride.Location = new System.Drawing.Point(40, 142);
            this.cbVendorOverride.Name = "cbVendorOverride";
            this.cbVendorOverride.Size = new System.Drawing.Size(118, 17);
            this.cbVendorOverride.TabIndex = 29;
            this.cbVendorOverride.Text = "override_tv_vendor";
            this.cbVendorOverride.UseVisualStyleBackColor = true;
            // 
            // lPlayerConfig
            // 
            this.lPlayerConfig.AutoSize = true;
            this.lPlayerConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPlayerConfig.Location = new System.Drawing.Point(36, 172);
            this.lPlayerConfig.Name = "lPlayerConfig";
            this.lPlayerConfig.Size = new System.Drawing.Size(114, 24);
            this.lPlayerConfig.TabIndex = 16;
            this.lPlayerConfig.Text = "Application";
            // 
            // lAdapterConfig
            // 
            this.lAdapterConfig.AutoSize = true;
            this.lAdapterConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAdapterConfig.Location = new System.Drawing.Point(36, 6);
            this.lAdapterConfig.Name = "lAdapterConfig";
            this.lAdapterConfig.Size = new System.Drawing.Size(61, 24);
            this.lAdapterConfig.TabIndex = 15;
            this.lAdapterConfig.Text = "HDMI";
            // 
            // lDeviceType
            // 
            this.lDeviceType.AutoSize = true;
            this.lDeviceType.Location = new System.Drawing.Point(37, 116);
            this.lDeviceType.Name = "lDeviceType";
            this.lDeviceType.Size = new System.Drawing.Size(65, 13);
            this.lDeviceType.TabIndex = 3;
            this.lDeviceType.Text = "device_type";
            // 
            // lConnectedDevice
            // 
            this.lConnectedDevice.AutoSize = true;
            this.lConnectedDevice.Location = new System.Drawing.Point(37, 36);
            this.lConnectedDevice.Name = "lConnectedDevice";
            this.lConnectedDevice.Size = new System.Drawing.Size(139, 13);
            this.lConnectedDevice.TabIndex = 1;
            this.lConnectedDevice.Text = "connected_to_hdmi_device";
            // 
            // lPortNumber
            // 
            this.lPortNumber.AutoSize = true;
            this.lPortNumber.Location = new System.Drawing.Point(37, 63);
            this.lPortNumber.Name = "lPortNumber";
            this.lPortNumber.Size = new System.Drawing.Size(53, 13);
            this.lPortNumber.TabIndex = 0;
            this.lPortNumber.Text = "hdmi_port";
            // 
            // tabPanel
            // 
            this.tabPanel.Controls.Add(this.Configuration);
            this.tabPanel.Controls.Add(this.powerTab);
            this.tabPanel.Controls.Add(this.tbTestCommands);
            this.tabPanel.Controls.Add(this.LogOutput);
            this.tabPanel.Location = new System.Drawing.Point(12, 27);
            this.tabPanel.Name = "tabPanel";
            this.tabPanel.SelectedIndex = 0;
            this.tabPanel.Size = new System.Drawing.Size(600, 370);
            this.tabPanel.TabIndex = 0;
            this.tabPanel.SelectedIndexChanged += new System.EventHandler(this.SelectedTabChanged);
            // 
            // powerTab
            // 
            this.powerTab.Controls.Add(this.bReloadConfig2);
            this.powerTab.Controls.Add(this.cbTVAutoPowerOn);
            this.powerTab.Controls.Add(this.pictureBox3);
            this.powerTab.Controls.Add(this.label2);
            this.powerTab.Controls.Add(this.pictureBox2);
            this.powerTab.Controls.Add(this.label1);
            this.powerTab.Controls.Add(this.pbIdleTime);
            this.powerTab.Controls.Add(this.lStandbyScreen);
            this.powerTab.Controls.Add(this.cbStandbyScreen);
            this.powerTab.Controls.Add(this.cbStopTvStandby);
            this.powerTab.Controls.Add(this.lPowerOff);
            this.powerTab.Controls.Add(this.cbPowerOffDevices);
            this.powerTab.Controls.Add(this.lWakeDevices);
            this.powerTab.Controls.Add(this.cbWakeDevices);
            this.powerTab.Controls.Add(this.cbActivateSource);
            this.powerTab.Location = new System.Drawing.Point(4, 22);
            this.powerTab.Name = "powerTab";
            this.powerTab.Padding = new System.Windows.Forms.Padding(3);
            this.powerTab.Size = new System.Drawing.Size(592, 344);
            this.powerTab.TabIndex = 4;
            this.powerTab.Text = "Power Control";
            this.powerTab.UseVisualStyleBackColor = true;
            // 
            // bReloadConfig2
            // 
            this.bReloadConfig2.Enabled = false;
            this.bReloadConfig2.Location = new System.Drawing.Point(461, 315);
            this.bReloadConfig2.Name = "bReloadConfig2";
            this.bReloadConfig2.Size = new System.Drawing.Size(125, 23);
            this.bReloadConfig2.TabIndex = 51;
            this.bReloadConfig2.Text = "Reset configuration";
            this.bReloadConfig2.UseVisualStyleBackColor = true;
            this.bReloadConfig2.Click += new System.EventHandler(this.BReloadConfigClick);
            // 
            // cbTVAutoPowerOn
            // 
            this.cbTVAutoPowerOn.AutoSize = true;
            this.cbTVAutoPowerOn.Enabled = false;
            this.cbTVAutoPowerOn.Location = new System.Drawing.Point(40, 198);
            this.cbTVAutoPowerOn.Name = "cbTVAutoPowerOn";
            this.cbTVAutoPowerOn.Size = new System.Drawing.Size(149, 17);
            this.cbTVAutoPowerOn.TabIndex = 49;
            this.cbTVAutoPowerOn.Text = "global_tv_auto_power_on";
            this.cbTVAutoPowerOn.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::LibCECTray.Properties.Resources.power;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(6, 218);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 24);
            this.pictureBox3.TabIndex = 48;
            this.pictureBox3.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 24);
            this.label2.TabIndex = 47;
            this.label2.Text = "Screensaver";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::LibCECTray.Properties.Resources.tv;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(6, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.TabIndex = 46;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 24);
            this.label1.TabIndex = 45;
            this.label1.Text = "HDMI Devices";
            // 
            // pbIdleTime
            // 
            this.pbIdleTime.Location = new System.Drawing.Point(188, 267);
            this.pbIdleTime.Name = "pbIdleTime";
            this.pbIdleTime.Size = new System.Drawing.Size(371, 23);
            this.pbIdleTime.TabIndex = 36;
            this.pbIdleTime.Visible = false;
            // 
            // lStandbyScreen
            // 
            this.lStandbyScreen.AutoSize = true;
            this.lStandbyScreen.Location = new System.Drawing.Point(37, 251);
            this.lStandbyScreen.Name = "lStandbyScreen";
            this.lStandbyScreen.Size = new System.Drawing.Size(82, 13);
            this.lStandbyScreen.TabIndex = 44;
            this.lStandbyScreen.Text = "standby_screen";
            // 
            // cbStopTvStandby
            // 
            this.cbStopTvStandby.AutoSize = true;
            this.cbStopTvStandby.Enabled = false;
            this.cbStopTvStandby.Location = new System.Drawing.Point(40, 152);
            this.cbStopTvStandby.Name = "cbStopTvStandby";
            this.cbStopTvStandby.Size = new System.Drawing.Size(138, 17);
            this.cbStopTvStandby.TabIndex = 42;
            this.cbStopTvStandby.Text = "global_stop_tv_standby";
            this.cbStopTvStandby.UseVisualStyleBackColor = true;
            // 
            // lPowerOff
            // 
            this.lPowerOff.AutoSize = true;
            this.lPowerOff.Location = new System.Drawing.Point(279, 36);
            this.lPowerOff.Name = "lPowerOff";
            this.lPowerOff.Size = new System.Drawing.Size(87, 13);
            this.lPowerOff.TabIndex = 41;
            this.lPowerOff.Text = "standby_devices";
            // 
            // cbPowerOffDevices
            // 
            this.cbPowerOffDevices.Enabled = false;
            this.cbPowerOffDevices.FormattingEnabled = true;
            this.cbPowerOffDevices.Items.AddRange(new object[] {
            "global_standby_devices"});
            this.cbPowerOffDevices.Location = new System.Drawing.Point(282, 52);
            this.cbPowerOffDevices.Name = "cbPowerOffDevices";
            this.cbPowerOffDevices.Size = new System.Drawing.Size(118, 94);
            this.cbPowerOffDevices.TabIndex = 40;
            // 
            // lWakeDevices
            // 
            this.lWakeDevices.AutoSize = true;
            this.lWakeDevices.Location = new System.Drawing.Point(37, 36);
            this.lWakeDevices.Name = "lWakeDevices";
            this.lWakeDevices.Size = new System.Drawing.Size(76, 13);
            this.lWakeDevices.TabIndex = 39;
            this.lWakeDevices.Text = "wake_devices";
            // 
            // cbWakeDevices
            // 
            this.cbWakeDevices.Enabled = false;
            this.cbWakeDevices.FormattingEnabled = true;
            this.cbWakeDevices.Items.AddRange(new object[] {
            "global_wake_devices"});
            this.cbWakeDevices.Location = new System.Drawing.Point(40, 52);
            this.cbWakeDevices.Name = "cbWakeDevices";
            this.cbWakeDevices.Size = new System.Drawing.Size(118, 94);
            this.cbWakeDevices.TabIndex = 38;
            // 
            // cbActivateSource
            // 
            this.cbActivateSource.AutoSize = true;
            this.cbActivateSource.Enabled = false;
            this.cbActivateSource.Location = new System.Drawing.Point(40, 175);
            this.cbActivateSource.Name = "cbActivateSource";
            this.cbActivateSource.Size = new System.Drawing.Size(136, 17);
            this.cbActivateSource.TabIndex = 37;
            this.cbActivateSource.Text = "global_activate_source";
            this.cbActivateSource.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.applicationsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(624, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideToolStripMenuItem,
            this.advancedModeToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.HideToolStripMenuItemClick);
            // 
            // advancedModeToolStripMenuItem
            // 
            this.advancedModeToolStripMenuItem.Name = "advancedModeToolStripMenuItem";
            this.advancedModeToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.advancedModeToolStripMenuItem.Text = "Advanced mode";
            this.advancedModeToolStripMenuItem.Click += new System.EventHandler(this.AdvancedModeToolStripMenuItemClick);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItemClick);
            // 
            // applicationsToolStripMenuItem
            // 
            this.applicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewApplicationToolStripMenuItem});
            this.applicationsToolStripMenuItem.Name = "applicationsToolStripMenuItem";
            this.applicationsToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.applicationsToolStripMenuItem.Text = "Applications";
            this.applicationsToolStripMenuItem.Visible = false;
            // 
            // addNewApplicationToolStripMenuItem
            // 
            this.addNewApplicationToolStripMenuItem.Name = "addNewApplicationToolStripMenuItem";
            this.addNewApplicationToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.addNewApplicationToolStripMenuItem.Text = "Add new application";
            this.addNewApplicationToolStripMenuItem.Click += new System.EventHandler(this.AddNewApplicationToolStripMenuItemClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
            // 
            // pbAlert
            // 
            this.pbAlert.BackgroundImage = global::LibCECTray.Properties.Resources.warning;
            this.pbAlert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbAlert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAlert.Location = new System.Drawing.Point(16, 407);
            this.pbAlert.Name = "pbAlert";
            this.pbAlert.Size = new System.Drawing.Size(20, 20);
            this.pbAlert.TabIndex = 39;
            this.pbAlert.TabStop = false;
            this.pbAlert.Visible = false;
            this.pbAlert.Click += new System.EventHandler(this.pbAlertClick);
            // 
            // CECTray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.pbAlert);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lStatus);
            this.Controls.Add(this.pProgress);
            this.Controls.Add(this.tabPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "CECTray";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Resize += new System.EventHandler(this.CECTrayResize);
            this.trayIconMenu.ResumeLayout(false);
            this.LogOutput.ResumeLayout(false);
            this.LogOutput.PerformLayout();
            this.tbTestCommands.ResumeLayout(false);
            this.tbTestCommands.PerformLayout();
            this.Configuration.ResumeLayout(false);
            this.Configuration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirmwareUpgrade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHDMI)).EndInit();
            this.tabPanel.ResumeLayout(false);
            this.powerTab.ResumeLayout(false);
            this.powerTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlert)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ProgressBar pProgress;
    public System.Windows.Forms.Label lStatus;
    private System.Windows.Forms.ToolTip helpPortNumber;
    private System.Windows.Forms.ToolTip helpConnectedHDMIDevice;
    private System.Windows.Forms.ToolTip helpDeviceType;
    private System.Windows.Forms.ToolTip helpPhysicalAddress;
    private System.Windows.Forms.NotifyIcon trayIcon;
    private System.Windows.Forms.ContextMenuStrip trayIconMenu;
    private System.Windows.Forms.ToolStripMenuItem tsMenuClose;
    private System.Windows.Forms.ToolStripMenuItem tsMenuShowHide;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem tsAdvanced;
    private System.Windows.Forms.TabPage LogOutput;
    private System.Windows.Forms.Button bSaveLog;
    private System.Windows.Forms.Button bClearLog;
    private System.Windows.Forms.CheckBox cbLogDebug;
    private System.Windows.Forms.CheckBox cbLogTraffic;
    private System.Windows.Forms.CheckBox cbLogNotice;
    private System.Windows.Forms.CheckBox cbLogWarning;
    private System.Windows.Forms.CheckBox cbLogError;
    private System.Windows.Forms.TextBox tbLog;
    private System.Windows.Forms.TabPage tbTestCommands;
    private System.Windows.Forms.Button bRescanDevices;
    private System.Windows.Forms.Button bMute;
    private System.Windows.Forms.Button bVolDown;
    private System.Windows.Forms.Button bVolUp;
    private System.Windows.Forms.Button bActivateSource;
    private System.Windows.Forms.Button bScan;
    private System.Windows.Forms.Button bStandby;
    private System.Windows.Forms.Button bSendImageViewOn;
    private System.Windows.Forms.Label lDestination;
    private System.Windows.Forms.ComboBox cbCommandDestination;
    private System.Windows.Forms.TabPage Configuration;
    private System.Windows.Forms.CheckBox cbOverrideAddress;
    private System.Windows.Forms.Button bReloadConfig;
    private System.Windows.Forms.CheckBox cbVendorOverride;
    private System.Windows.Forms.ComboBox cbVendorId;
    private System.Windows.Forms.Label lPlayerConfig;
    private System.Windows.Forms.Label lAdapterConfig;
    private System.Windows.Forms.ComboBox cbDeviceType;
    private System.Windows.Forms.ComboBox cbPortNumber;
    private System.Windows.Forms.TextBox tbPhysicalAddress;
    private System.Windows.Forms.ComboBox cbConnectedDevice;
    private System.Windows.Forms.Label lDeviceType;
    private System.Windows.Forms.Label lConnectedDevice;
    private System.Windows.Forms.Label lPortNumber;
    private System.Windows.Forms.TabControl tabPanel;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem advancedModeToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem applicationsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem addNewApplicationToolStripMenuItem;
    private System.Windows.Forms.CheckBox cbStartMinimised;
    private System.Windows.Forms.TabPage powerTab;
    private System.Windows.Forms.ProgressBar pbIdleTime;
    private System.Windows.Forms.Label lStandbyScreen;
    private System.Windows.Forms.ComboBox cbStandbyScreen;
    private System.Windows.Forms.CheckBox cbStopTvStandby;
    private System.Windows.Forms.Label lPowerOff;
    private System.Windows.Forms.CheckedListBox cbPowerOffDevices;
    private System.Windows.Forms.Label lWakeDevices;
    private System.Windows.Forms.CheckedListBox cbWakeDevices;
    private System.Windows.Forms.CheckBox cbActivateSource;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.PictureBox pbHDMI;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.PictureBox pictureBox2;
    private System.Windows.Forms.PictureBox pictureBox3;
    private System.Windows.Forms.Label label2;
    public System.Windows.Forms.Button bFirmwareUpgrade;
    public System.Windows.Forms.Label lFirmwareVersion;
    public System.Windows.Forms.PictureBox pbFirmwareUpgrade;
    public System.Windows.Forms.Label lFirmware;
    public System.Windows.Forms.PictureBox pbAlert;
    private System.Windows.Forms.CheckBox cbTVAutoPowerOn;
    private System.Windows.Forms.Button bReloadConfig2;
    private System.Windows.Forms.CheckBox cbDetectAddress;
        private System.Windows.Forms.Button button_RawCommand;
        private System.Windows.Forms.TextBox textBox_RawCommand;
    }
}