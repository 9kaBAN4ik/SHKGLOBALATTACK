namespace Kingdoms
{
	// Token: 0x0200025F RID: 607
	public partial class OptionsPopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x06001AD7 RID: 6871 RVA: 0x0001ACD7 File Offset: 0x00018ED7
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001AD8 RID: 6872 RVA: 0x001A6A7C File Offset: 0x001A4C7C
		private void InitializeComponent()
		{
			this.tabOptions = new global::Dotnetrix_Samples.TabControlEx();
			this.tpageDisplay = new global::System.Windows.Forms.TabPage();
			this.cbCapitalIDs = new global::System.Windows.Forms.CheckBox();
			this.cbProductionInfo = new global::System.Windows.Forms.CheckBox();
			this.cbFlashingTaskbarAttack = new global::System.Windows.Forms.CheckBox();
			this.lblAdvanced = new global::System.Windows.Forms.Label();
			this.cbVillageIDs = new global::System.Windows.Forms.CheckBox();
			this.cbConfirmOpenMultiple = new global::System.Windows.Forms.CheckBox();
			this.cbConfirmBuyMultiple = new global::System.Windows.Forms.CheckBox();
			this.btnResumeTutorial = new global::Kingdoms.BitmapButton();
			this.btnDebugInfo = new global::Kingdoms.BitmapButton();
			this.cbTooltips = new global::System.Windows.Forms.CheckBox();
			this.cbInstantTooltips = new global::System.Windows.Forms.CheckBox();
			this.cbConfirmCards = new global::System.Windows.Forms.CheckBox();
			this.cbProfanityFilter = new global::System.Windows.Forms.CheckBox();
			this.cbWhiteTextBox = new global::System.Windows.Forms.CheckBox();
			this.tabPage3 = new global::System.Windows.Forms.TabPage();
			this.cbWinterLandscape = new global::System.Windows.Forms.CheckBox();
			this.cbSeasonalFX = new global::System.Windows.Forms.CheckBox();
			this.cbBattleSFX = new global::System.Windows.Forms.CheckBox();
			this.btnRestoreDefaultVolumes = new global::Kingdoms.BitmapButton();
			this.lblVolumes = new global::System.Windows.Forms.Label();
			this.trackBarEnvironmentals = new global::System.Windows.Forms.TrackBar();
			this.cbEnvironmentals = new global::System.Windows.Forms.CheckBox();
			this.trackBarSFX = new global::System.Windows.Forms.TrackBar();
			this.cbSFX = new global::System.Windows.Forms.CheckBox();
			this.cbGraphicsCompatibility = new global::System.Windows.Forms.CheckBox();
			this.trackBarMusicVolume = new global::System.Windows.Forms.TrackBar();
			this.cbMusic = new global::System.Windows.Forms.CheckBox();
			this.tabPage1 = new global::System.Windows.Forms.TabPage();
			this.label1 = new global::System.Windows.Forms.Label();
			this.listBoxLanguages = new global::System.Windows.Forms.ListBox();
			this.btnApply = new global::Kingdoms.BitmapButton();
			this.btnCancel = new global::Kingdoms.BitmapButton();
			this.btnOK = new global::Kingdoms.BitmapButton();
			this.pnlWikiHelp = new global::System.Windows.Forms.Panel();
			this.tabOptions.SuspendLayout();
			this.tpageDisplay.SuspendLayout();
			this.tabPage3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.trackBarEnvironmentals).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.trackBarSFX).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.trackBarMusicVolume).BeginInit();
			this.tabPage1.SuspendLayout();
			base.SuspendLayout();
			this.tabOptions.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.tabOptions.BackColor = global::System.Drawing.Color.FromArgb(96, 109, 118);
			this.tabOptions.Controls.Add(this.tpageDisplay);
			this.tabOptions.Controls.Add(this.tabPage3);
			this.tabOptions.Controls.Add(this.tabPage1);
			this.tabOptions.ItemSize = new global::System.Drawing.Size(110, 21);
			this.tabOptions.Location = new global::System.Drawing.Point(9, 37);
			this.tabOptions.Name = "tabOptions";
			this.tabOptions.SelectedIndex = 0;
			this.tabOptions.Size = new global::System.Drawing.Size(335, 309);
			this.tabOptions.SizeMode = global::System.Windows.Forms.TabSizeMode.Fixed;
			this.tabOptions.TabIndex = 0;
			this.tabOptions.SelectedIndexChanged += new global::System.EventHandler(this.tabOptions_SelectedIndexChanged);
			this.tpageDisplay.BackColor = global::System.Drawing.Color.FromArgb(159, 180, 193);
			this.tpageDisplay.Controls.Add(this.cbCapitalIDs);
			this.tpageDisplay.Controls.Add(this.cbProductionInfo);
			this.tpageDisplay.Controls.Add(this.cbFlashingTaskbarAttack);
			this.tpageDisplay.Controls.Add(this.lblAdvanced);
			this.tpageDisplay.Controls.Add(this.cbVillageIDs);
			this.tpageDisplay.Controls.Add(this.cbConfirmOpenMultiple);
			this.tpageDisplay.Controls.Add(this.cbConfirmBuyMultiple);
			this.tpageDisplay.Controls.Add(this.btnResumeTutorial);
			this.tpageDisplay.Controls.Add(this.btnDebugInfo);
			this.tpageDisplay.Controls.Add(this.cbTooltips);
			this.tpageDisplay.Controls.Add(this.cbInstantTooltips);
			this.tpageDisplay.Controls.Add(this.cbConfirmCards);
			this.tpageDisplay.Controls.Add(this.cbProfanityFilter);
			this.tpageDisplay.Controls.Add(this.cbWhiteTextBox);
			this.tpageDisplay.ForeColor = global::ARGBColors.Black;
			this.tpageDisplay.Location = new global::System.Drawing.Point(4, 25);
			this.tpageDisplay.Name = "tpageDisplay";
			this.tpageDisplay.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpageDisplay.Size = new global::System.Drawing.Size(327, 280);
			this.tpageDisplay.TabIndex = 0;
			this.tpageDisplay.Text = "Settings";
			this.cbCapitalIDs.AutoSize = true;
			this.cbCapitalIDs.Location = new global::System.Drawing.Point(23, 257);
			this.cbCapitalIDs.Name = "cbCapitalIDs";
			this.cbCapitalIDs.Size = new global::System.Drawing.Size(103, 17);
			this.cbCapitalIDs.TabIndex = 25;
			this.cbCapitalIDs.Text = "View Capital IDs";
			this.cbCapitalIDs.UseVisualStyleBackColor = true;
			this.cbCapitalIDs.CheckedChanged += new global::System.EventHandler(this.cbCapitalIDs_CheckedChanged);
			this.cbProductionInfo.AutoSize = true;
			this.cbProductionInfo.Location = new global::System.Drawing.Point(23, 171);
			this.cbProductionInfo.Name = "cbProductionInfo";
			this.cbProductionInfo.Size = new global::System.Drawing.Size(213, 17);
			this.cbProductionInfo.TabIndex = 24;
			this.cbProductionInfo.Text = "Production Indicators in the Village Map";
			this.cbProductionInfo.UseVisualStyleBackColor = true;
			this.cbProductionInfo.CheckedChanged += new global::System.EventHandler(this.cbProductionInfo_CheckedChanged);
			this.cbFlashingTaskbarAttack.AutoSize = true;
			this.cbFlashingTaskbarAttack.Location = new global::System.Drawing.Point(23, 149);
			this.cbFlashingTaskbarAttack.Name = "cbFlashingTaskbarAttack";
			this.cbFlashingTaskbarAttack.Size = new global::System.Drawing.Size(195, 17);
			this.cbFlashingTaskbarAttack.TabIndex = 23;
			this.cbFlashingTaskbarAttack.Text = "Flash Taskbar Icon When Attacked";
			this.cbFlashingTaskbarAttack.UseVisualStyleBackColor = true;
			this.cbFlashingTaskbarAttack.CheckedChanged += new global::System.EventHandler(this.cbFlashingTaskbarAttack_CheckedChanged);
			this.lblAdvanced.AutoSize = true;
			this.lblAdvanced.Location = new global::System.Drawing.Point(6, 214);
			this.lblAdvanced.Name = "lblAdvanced";
			this.lblAdvanced.Size = new global::System.Drawing.Size(95, 13);
			this.lblAdvanced.TabIndex = 22;
			this.lblAdvanced.Text = "Advanced Options";
			this.cbVillageIDs.AutoSize = true;
			this.cbVillageIDs.Location = new global::System.Drawing.Point(23, 234);
			this.cbVillageIDs.Name = "cbVillageIDs";
			this.cbVillageIDs.Size = new global::System.Drawing.Size(102, 17);
			this.cbVillageIDs.TabIndex = 21;
			this.cbVillageIDs.Text = "View Village IDs";
			this.cbVillageIDs.UseVisualStyleBackColor = true;
			this.cbVillageIDs.CheckedChanged += new global::System.EventHandler(this.cbVillageIDs_CheckedChanged);
			this.cbConfirmOpenMultiple.AutoSize = true;
			this.cbConfirmOpenMultiple.Location = new global::System.Drawing.Point(23, 127);
			this.cbConfirmOpenMultiple.Name = "cbConfirmOpenMultiple";
			this.cbConfirmOpenMultiple.Size = new global::System.Drawing.Size(149, 17);
			this.cbConfirmOpenMultiple.TabIndex = 20;
			this.cbConfirmOpenMultiple.Text = "Open Multiple Card Packs";
			this.cbConfirmOpenMultiple.UseVisualStyleBackColor = true;
			this.cbConfirmOpenMultiple.CheckedChanged += new global::System.EventHandler(this.cbConfirmOpenMultiple_CheckedChanged);
			this.cbConfirmBuyMultiple.AutoSize = true;
			this.cbConfirmBuyMultiple.Location = new global::System.Drawing.Point(23, 105);
			this.cbConfirmBuyMultiple.Name = "cbConfirmBuyMultiple";
			this.cbConfirmBuyMultiple.Size = new global::System.Drawing.Size(141, 17);
			this.cbConfirmBuyMultiple.TabIndex = 19;
			this.cbConfirmBuyMultiple.Text = "Buy Multiple Card Packs";
			this.cbConfirmBuyMultiple.UseVisualStyleBackColor = true;
			this.cbConfirmBuyMultiple.CheckedChanged += new global::System.EventHandler(this.cbConfirmBuyMultiple_CheckedChanged);
			this.btnResumeTutorial.BackColor = global::System.Drawing.Color.FromArgb(203, 215, 223);
			this.btnResumeTutorial.BorderColor = global::System.Drawing.Color.FromArgb(0, 0, 139);
			this.btnResumeTutorial.BorderDrawing = true;
			this.btnResumeTutorial.FocusRectangleEnabled = false;
			this.btnResumeTutorial.Image = null;
			this.btnResumeTutorial.ImageBorderColor = global::System.Drawing.Color.FromArgb(210, 105, 30);
			this.btnResumeTutorial.ImageBorderEnabled = true;
			this.btnResumeTutorial.ImageDropShadow = true;
			this.btnResumeTutorial.ImageFocused = null;
			this.btnResumeTutorial.ImageInactive = null;
			this.btnResumeTutorial.ImageMouseOver = null;
			this.btnResumeTutorial.ImageNormal = null;
			this.btnResumeTutorial.ImagePressed = null;
			this.btnResumeTutorial.InnerBorderColor = global::System.Drawing.Color.FromArgb(211, 211, 211);
			this.btnResumeTutorial.InnerBorderColor_Focus = global::System.Drawing.Color.FromArgb(173, 216, 230);
			this.btnResumeTutorial.InnerBorderColor_MouseOver = global::System.Drawing.Color.FromArgb(255, 215, 0);
			this.btnResumeTutorial.Location = new global::System.Drawing.Point(194, 236);
			this.btnResumeTutorial.Name = "btnResumeTutorial";
			this.btnResumeTutorial.OffsetPressedContent = true;
			this.btnResumeTutorial.Padding2 = 5;
			this.btnResumeTutorial.Size = new global::System.Drawing.Size(118, 23);
			this.btnResumeTutorial.StretchImage = false;
			this.btnResumeTutorial.TabIndex = 18;
			this.btnResumeTutorial.Text = "Resume Tutorial";
			this.btnResumeTutorial.TextDropShadow = false;
			this.btnResumeTutorial.UseVisualStyleBackColor = false;
			this.btnResumeTutorial.Visible = false;
			this.btnResumeTutorial.Click += new global::System.EventHandler(this.btnResumeTutorial_Click);
			this.btnDebugInfo.BackColor = global::System.Drawing.Color.FromArgb(203, 215, 223);
			this.btnDebugInfo.BorderColor = global::System.Drawing.Color.FromArgb(0, 0, 139);
			this.btnDebugInfo.BorderDrawing = true;
			this.btnDebugInfo.FocusRectangleEnabled = false;
			this.btnDebugInfo.Image = null;
			this.btnDebugInfo.ImageBorderColor = global::System.Drawing.Color.FromArgb(210, 105, 30);
			this.btnDebugInfo.ImageBorderEnabled = true;
			this.btnDebugInfo.ImageDropShadow = true;
			this.btnDebugInfo.ImageFocused = null;
			this.btnDebugInfo.ImageInactive = null;
			this.btnDebugInfo.ImageMouseOver = null;
			this.btnDebugInfo.ImageNormal = null;
			this.btnDebugInfo.ImagePressed = null;
			this.btnDebugInfo.InnerBorderColor = global::System.Drawing.Color.FromArgb(211, 211, 211);
			this.btnDebugInfo.InnerBorderColor_Focus = global::System.Drawing.Color.FromArgb(173, 216, 230);
			this.btnDebugInfo.InnerBorderColor_MouseOver = global::System.Drawing.Color.FromArgb(255, 215, 0);
			this.btnDebugInfo.Location = new global::System.Drawing.Point(194, 217);
			this.btnDebugInfo.Name = "btnDebugInfo";
			this.btnDebugInfo.OffsetPressedContent = true;
			this.btnDebugInfo.Padding2 = 5;
			this.btnDebugInfo.Size = new global::System.Drawing.Size(118, 23);
			this.btnDebugInfo.StretchImage = false;
			this.btnDebugInfo.TabIndex = 17;
			this.btnDebugInfo.Text = "Debug Info";
			this.btnDebugInfo.TextDropShadow = false;
			this.btnDebugInfo.UseVisualStyleBackColor = false;
			this.btnDebugInfo.Click += new global::System.EventHandler(this.btnDebugInfo_Click);
			this.cbTooltips.AutoSize = true;
			this.cbTooltips.Location = new global::System.Drawing.Point(23, 39);
			this.cbTooltips.Name = "cbTooltips";
			this.cbTooltips.Size = new global::System.Drawing.Size(63, 17);
			this.cbTooltips.TabIndex = 16;
			this.cbTooltips.Text = "Tooltips";
			this.cbTooltips.UseVisualStyleBackColor = true;
			this.cbTooltips.CheckedChanged += new global::System.EventHandler(this.cbTooltips_CheckedChanged);
			this.cbInstantTooltips.AutoSize = true;
			this.cbInstantTooltips.Location = new global::System.Drawing.Point(23, 61);
			this.cbInstantTooltips.Name = "cbInstantTooltips";
			this.cbInstantTooltips.Size = new global::System.Drawing.Size(98, 17);
			this.cbInstantTooltips.TabIndex = 15;
			this.cbInstantTooltips.Text = "Instant Tooltips";
			this.cbInstantTooltips.UseVisualStyleBackColor = true;
			this.cbInstantTooltips.CheckedChanged += new global::System.EventHandler(this.cbInstantTooltips_CheckedChanged);
			this.cbConfirmCards.AutoSize = true;
			this.cbConfirmCards.Location = new global::System.Drawing.Point(23, 83);
			this.cbConfirmCards.Name = "cbConfirmCards";
			this.cbConfirmCards.Size = new global::System.Drawing.Size(128, 17);
			this.cbConfirmCards.TabIndex = 14;
			this.cbConfirmCards.Text = "Confirm Playing Cards";
			this.cbConfirmCards.UseVisualStyleBackColor = true;
			this.cbConfirmCards.CheckedChanged += new global::System.EventHandler(this.cbConfirmCards_CheckedChanged);
			this.cbProfanityFilter.AutoSize = true;
			this.cbProfanityFilter.Location = new global::System.Drawing.Point(23, 17);
			this.cbProfanityFilter.Name = "cbProfanityFilter";
			this.cbProfanityFilter.Size = new global::System.Drawing.Size(159, 17);
			this.cbProfanityFilter.TabIndex = 13;
			this.cbProfanityFilter.Text = "Profanity Filter (English Only)";
			this.cbProfanityFilter.UseVisualStyleBackColor = true;
			this.cbProfanityFilter.CheckedChanged += new global::System.EventHandler(this.cbProfanityFilter_CheckedChanged);
			this.cbWhiteTextBox.AutoSize = true;
			this.cbWhiteTextBox.Location = new global::System.Drawing.Point(23, 193);
			this.cbWhiteTextBox.Name = "cbWhiteTextBox";
			this.cbWhiteTextBox.Size = new global::System.Drawing.Size(228, 17);
			this.cbWhiteTextBox.TabIndex = 24;
			this.cbWhiteTextBox.Text = "Show White Background on Parish Names";
			this.cbWhiteTextBox.UseVisualStyleBackColor = true;
			this.cbWhiteTextBox.CheckedChanged += new global::System.EventHandler(this.cbWhiteTextBox_CheckedChanged);
			this.tabPage3.BackColor = global::System.Drawing.Color.FromArgb(159, 180, 193);
			this.tabPage3.Controls.Add(this.cbWinterLandscape);
			this.tabPage3.Controls.Add(this.cbSeasonalFX);
			this.tabPage3.Controls.Add(this.cbBattleSFX);
			this.tabPage3.Controls.Add(this.btnRestoreDefaultVolumes);
			this.tabPage3.Controls.Add(this.lblVolumes);
			this.tabPage3.Controls.Add(this.trackBarEnvironmentals);
			this.tabPage3.Controls.Add(this.cbEnvironmentals);
			this.tabPage3.Controls.Add(this.trackBarSFX);
			this.tabPage3.Controls.Add(this.cbSFX);
			this.tabPage3.Controls.Add(this.cbGraphicsCompatibility);
			this.tabPage3.Controls.Add(this.trackBarMusicVolume);
			this.tabPage3.Controls.Add(this.cbMusic);
			this.tabPage3.Location = new global::System.Drawing.Point(4, 25);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new global::System.Drawing.Size(327, 280);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Audio";
			this.cbWinterLandscape.AutoSize = true;
			this.cbWinterLandscape.ForeColor = global::ARGBColors.Black;
			this.cbWinterLandscape.Location = new global::System.Drawing.Point(20, 223);
			this.cbWinterLandscape.Name = "cbWinterLandscape";
			this.cbWinterLandscape.Size = new global::System.Drawing.Size(143, 17);
			this.cbWinterLandscape.TabIndex = 25;
			this.cbWinterLandscape.Text = "Show Winter Landscape";
			this.cbWinterLandscape.UseVisualStyleBackColor = true;
			this.cbWinterLandscape.CheckedChanged += new global::System.EventHandler(this.cbWinterLandscape_CheckedChanged);
			this.cbSeasonalFX.AutoSize = true;
			this.cbSeasonalFX.ForeColor = global::ARGBColors.Black;
			this.cbSeasonalFX.Location = new global::System.Drawing.Point(20, 203);
			this.cbSeasonalFX.Name = "cbSeasonalFX";
			this.cbSeasonalFX.Size = new global::System.Drawing.Size(116, 17);
			this.cbSeasonalFX.TabIndex = 24;
			this.cbSeasonalFX.Text = "Show Seasonal FX";
			this.cbSeasonalFX.UseVisualStyleBackColor = true;
			this.cbSeasonalFX.CheckedChanged += new global::System.EventHandler(this.cbSeasonalFX_CheckedChanged);
			this.cbBattleSFX.AutoSize = true;
			this.cbBattleSFX.ForeColor = global::ARGBColors.Black;
			this.cbBattleSFX.Location = new global::System.Drawing.Point(20, 99);
			this.cbBattleSFX.Name = "cbBattleSFX";
			this.cbBattleSFX.Size = new global::System.Drawing.Size(103, 17);
			this.cbBattleSFX.TabIndex = 11;
			this.cbBattleSFX.Text = "Battle Sound FX";
			this.cbBattleSFX.UseVisualStyleBackColor = true;
			this.cbBattleSFX.CheckedChanged += new global::System.EventHandler(this.cbBattleSFX_CheckedChanged);
			this.btnRestoreDefaultVolumes.BackColor = global::System.Drawing.Color.FromArgb(203, 215, 223);
			this.btnRestoreDefaultVolumes.BorderColor = global::System.Drawing.Color.FromArgb(0, 0, 139);
			this.btnRestoreDefaultVolumes.BorderDrawing = true;
			this.btnRestoreDefaultVolumes.FocusRectangleEnabled = false;
			this.btnRestoreDefaultVolumes.Image = null;
			this.btnRestoreDefaultVolumes.ImageBorderColor = global::System.Drawing.Color.FromArgb(210, 105, 30);
			this.btnRestoreDefaultVolumes.ImageBorderEnabled = true;
			this.btnRestoreDefaultVolumes.ImageDropShadow = true;
			this.btnRestoreDefaultVolumes.ImageFocused = null;
			this.btnRestoreDefaultVolumes.ImageInactive = null;
			this.btnRestoreDefaultVolumes.ImageMouseOver = null;
			this.btnRestoreDefaultVolumes.ImageNormal = null;
			this.btnRestoreDefaultVolumes.ImagePressed = null;
			this.btnRestoreDefaultVolumes.InnerBorderColor = global::System.Drawing.Color.FromArgb(211, 211, 211);
			this.btnRestoreDefaultVolumes.InnerBorderColor_Focus = global::System.Drawing.Color.FromArgb(173, 216, 230);
			this.btnRestoreDefaultVolumes.InnerBorderColor_MouseOver = global::System.Drawing.Color.FromArgb(255, 215, 0);
			this.btnRestoreDefaultVolumes.Location = new global::System.Drawing.Point(134, 167);
			this.btnRestoreDefaultVolumes.Name = "btnRestoreDefaultVolumes";
			this.btnRestoreDefaultVolumes.OffsetPressedContent = true;
			this.btnRestoreDefaultVolumes.Padding2 = 5;
			this.btnRestoreDefaultVolumes.Size = new global::System.Drawing.Size(167, 23);
			this.btnRestoreDefaultVolumes.StretchImage = false;
			this.btnRestoreDefaultVolumes.TabIndex = 10;
			this.btnRestoreDefaultVolumes.Text = "Restore Defaults";
			this.btnRestoreDefaultVolumes.TextDropShadow = false;
			this.btnRestoreDefaultVolumes.UseVisualStyleBackColor = false;
			this.btnRestoreDefaultVolumes.Click += new global::System.EventHandler(this.btnRestoreDefaultVolumes_Click);
			this.lblVolumes.ForeColor = global::ARGBColors.Black;
			this.lblVolumes.Location = new global::System.Drawing.Point(131, 10);
			this.lblVolumes.Name = "lblVolumes";
			this.lblVolumes.Size = new global::System.Drawing.Size(170, 13);
			this.lblVolumes.TabIndex = 9;
			this.lblVolumes.Text = "Volume";
			this.lblVolumes.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.trackBarEnvironmentals.BackColor = global::System.Drawing.Color.FromArgb(159, 180, 193);
			this.trackBarEnvironmentals.Location = new global::System.Drawing.Point(131, 126);
			this.trackBarEnvironmentals.Maximum = 100;
			this.trackBarEnvironmentals.Minimum = 1;
			this.trackBarEnvironmentals.Name = "trackBarEnvironmentals";
			this.trackBarEnvironmentals.Size = new global::System.Drawing.Size(170, 45);
			this.trackBarEnvironmentals.TabIndex = 8;
			this.trackBarEnvironmentals.TickFrequency = 5;
			this.trackBarEnvironmentals.Value = 1;
			this.trackBarEnvironmentals.ValueChanged += new global::System.EventHandler(this.trackBarEnvironmentals_ValueChanged);
			this.cbEnvironmentals.AutoSize = true;
			this.cbEnvironmentals.ForeColor = global::ARGBColors.Black;
			this.cbEnvironmentals.Location = new global::System.Drawing.Point(20, 132);
			this.cbEnvironmentals.Name = "cbEnvironmentals";
			this.cbEnvironmentals.Size = new global::System.Drawing.Size(98, 17);
			this.cbEnvironmentals.TabIndex = 7;
			this.cbEnvironmentals.Text = "Environmentals";
			this.cbEnvironmentals.UseVisualStyleBackColor = true;
			this.cbEnvironmentals.CheckedChanged += new global::System.EventHandler(this.cbEnvironmentals_CheckedChanged);
			this.trackBarSFX.BackColor = global::System.Drawing.Color.FromArgb(159, 180, 193);
			this.trackBarSFX.Location = new global::System.Drawing.Point(131, 76);
			this.trackBarSFX.Maximum = 100;
			this.trackBarSFX.Minimum = 1;
			this.trackBarSFX.Name = "trackBarSFX";
			this.trackBarSFX.Size = new global::System.Drawing.Size(170, 45);
			this.trackBarSFX.TabIndex = 5;
			this.trackBarSFX.TickFrequency = 5;
			this.trackBarSFX.Value = 1;
			this.trackBarSFX.ValueChanged += new global::System.EventHandler(this.trackBarSFX_ValueChanged);
			this.cbSFX.AutoSize = true;
			this.cbSFX.ForeColor = global::ARGBColors.Black;
			this.cbSFX.Location = new global::System.Drawing.Point(20, 76);
			this.cbSFX.Name = "cbSFX";
			this.cbSFX.Size = new global::System.Drawing.Size(73, 17);
			this.cbSFX.TabIndex = 4;
			this.cbSFX.Text = "Sound FX";
			this.cbSFX.UseVisualStyleBackColor = true;
			this.cbSFX.CheckedChanged += new global::System.EventHandler(this.cbSFX_CheckedChanged);
			this.cbGraphicsCompatibility.AutoSize = true;
			this.cbGraphicsCompatibility.ForeColor = global::ARGBColors.Black;
			this.cbGraphicsCompatibility.Location = new global::System.Drawing.Point(20, 244);
			this.cbGraphicsCompatibility.Name = "cbGraphicsCompatibility";
			this.cbGraphicsCompatibility.Size = new global::System.Drawing.Size(159, 17);
			this.cbGraphicsCompatibility.TabIndex = 3;
			this.cbGraphicsCompatibility.Text = "Graphics Compatibility Mode";
			this.cbGraphicsCompatibility.UseVisualStyleBackColor = true;
			this.cbGraphicsCompatibility.CheckedChanged += new global::System.EventHandler(this.cbGraphicsCompatibility_CheckedChanged);
			this.trackBarMusicVolume.BackColor = global::System.Drawing.Color.FromArgb(159, 180, 193);
			this.trackBarMusicVolume.Location = new global::System.Drawing.Point(131, 26);
			this.trackBarMusicVolume.Maximum = 100;
			this.trackBarMusicVolume.Minimum = 1;
			this.trackBarMusicVolume.Name = "trackBarMusicVolume";
			this.trackBarMusicVolume.Size = new global::System.Drawing.Size(170, 45);
			this.trackBarMusicVolume.TabIndex = 1;
			this.trackBarMusicVolume.TickFrequency = 5;
			this.trackBarMusicVolume.Value = 1;
			this.trackBarMusicVolume.ValueChanged += new global::System.EventHandler(this.trackBarMusicVolume_ValueChanged);
			this.cbMusic.AutoSize = true;
			this.cbMusic.ForeColor = global::ARGBColors.Black;
			this.cbMusic.Location = new global::System.Drawing.Point(20, 32);
			this.cbMusic.Name = "cbMusic";
			this.cbMusic.Size = new global::System.Drawing.Size(54, 17);
			this.cbMusic.TabIndex = 0;
			this.cbMusic.Text = "Music";
			this.cbMusic.UseVisualStyleBackColor = true;
			this.cbMusic.CheckedChanged += new global::System.EventHandler(this.cbMusic_CheckedChanged);
			this.tabPage1.BackColor = global::System.Drawing.Color.FromArgb(159, 180, 193);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.listBoxLanguages);
			this.tabPage1.ForeColor = global::ARGBColors.Black;
			this.tabPage1.Location = new global::System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new global::System.Drawing.Size(327, 280);
			this.tabPage1.TabIndex = 3;
			this.tabPage1.Text = "Languages";
			this.label1.AutoSize = true;
			this.label1.ForeColor = global::ARGBColors.Black;
			this.label1.Location = new global::System.Drawing.Point(105, 12);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(106, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Available Languages";
			this.listBoxLanguages.BackColor = global::ARGBColors.White;
			this.listBoxLanguages.ForeColor = global::ARGBColors.Black;
			this.listBoxLanguages.FormattingEnabled = true;
			this.listBoxLanguages.Location = new global::System.Drawing.Point(60, 35);
			this.listBoxLanguages.Name = "listBoxLanguages";
			this.listBoxLanguages.Size = new global::System.Drawing.Size(201, 173);
			this.listBoxLanguages.TabIndex = 0;
			this.listBoxLanguages.SelectedIndexChanged += new global::System.EventHandler(this.listBoxLanguages_SelectedIndexChanged);
			this.btnApply.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnApply.BackColor = global::System.Drawing.Color.FromArgb(203, 215, 223);
			this.btnApply.BorderColor = global::System.Drawing.Color.FromArgb(0, 0, 139);
			this.btnApply.BorderDrawing = true;
			this.btnApply.Enabled = false;
			this.btnApply.FocusRectangleEnabled = false;
			this.btnApply.Image = null;
			this.btnApply.ImageBorderColor = global::System.Drawing.Color.FromArgb(210, 105, 30);
			this.btnApply.ImageBorderEnabled = true;
			this.btnApply.ImageDropShadow = true;
			this.btnApply.ImageFocused = null;
			this.btnApply.ImageInactive = null;
			this.btnApply.ImageMouseOver = null;
			this.btnApply.ImageNormal = null;
			this.btnApply.ImagePressed = null;
			this.btnApply.InnerBorderColor = global::System.Drawing.Color.FromArgb(211, 211, 211);
			this.btnApply.InnerBorderColor_Focus = global::System.Drawing.Color.FromArgb(173, 216, 230);
			this.btnApply.InnerBorderColor_MouseOver = global::System.Drawing.Color.FromArgb(255, 215, 0);
			this.btnApply.Location = new global::System.Drawing.Point(251, 352);
			this.btnApply.Name = "btnApply";
			this.btnApply.OffsetPressedContent = true;
			this.btnApply.Padding2 = 5;
			this.btnApply.Size = new global::System.Drawing.Size(90, 26);
			this.btnApply.StretchImage = false;
			this.btnApply.TabIndex = 1;
			this.btnApply.Text = "Apply";
			this.btnApply.TextDropShadow = false;
			this.btnApply.UseVisualStyleBackColor = false;
			this.btnApply.Click += new global::System.EventHandler(this.btnApply_Click);
			this.btnCancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnCancel.BackColor = global::System.Drawing.Color.FromArgb(203, 215, 223);
			this.btnCancel.BorderColor = global::System.Drawing.Color.FromArgb(0, 0, 139);
			this.btnCancel.BorderDrawing = true;
			this.btnCancel.FocusRectangleEnabled = false;
			this.btnCancel.Image = null;
			this.btnCancel.ImageBorderColor = global::System.Drawing.Color.FromArgb(210, 105, 30);
			this.btnCancel.ImageBorderEnabled = true;
			this.btnCancel.ImageDropShadow = true;
			this.btnCancel.ImageFocused = null;
			this.btnCancel.ImageInactive = null;
			this.btnCancel.ImageMouseOver = null;
			this.btnCancel.ImageNormal = null;
			this.btnCancel.ImagePressed = null;
			this.btnCancel.InnerBorderColor = global::System.Drawing.Color.FromArgb(211, 211, 211);
			this.btnCancel.InnerBorderColor_Focus = global::System.Drawing.Color.FromArgb(173, 216, 230);
			this.btnCancel.InnerBorderColor_MouseOver = global::System.Drawing.Color.FromArgb(255, 215, 0);
			this.btnCancel.Location = new global::System.Drawing.Point(155, 352);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.OffsetPressedContent = true;
			this.btnCancel.Padding2 = 5;
			this.btnCancel.Size = new global::System.Drawing.Size(90, 26);
			this.btnCancel.StretchImage = false;
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.TextDropShadow = false;
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnOK.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnOK.BackColor = global::System.Drawing.Color.FromArgb(203, 215, 223);
			this.btnOK.BorderColor = global::System.Drawing.Color.FromArgb(0, 0, 139);
			this.btnOK.BorderDrawing = true;
			this.btnOK.FocusRectangleEnabled = false;
			this.btnOK.Image = null;
			this.btnOK.ImageBorderColor = global::System.Drawing.Color.FromArgb(210, 105, 30);
			this.btnOK.ImageBorderEnabled = true;
			this.btnOK.ImageDropShadow = true;
			this.btnOK.ImageFocused = null;
			this.btnOK.ImageInactive = null;
			this.btnOK.ImageMouseOver = null;
			this.btnOK.ImageNormal = null;
			this.btnOK.ImagePressed = null;
			this.btnOK.InnerBorderColor = global::System.Drawing.Color.FromArgb(211, 211, 211);
			this.btnOK.InnerBorderColor_Focus = global::System.Drawing.Color.FromArgb(173, 216, 230);
			this.btnOK.InnerBorderColor_MouseOver = global::System.Drawing.Color.FromArgb(255, 215, 0);
			this.btnOK.Location = new global::System.Drawing.Point(59, 352);
			this.btnOK.Name = "btnOK";
			this.btnOK.OffsetPressedContent = true;
			this.btnOK.Padding2 = 5;
			this.btnOK.Size = new global::System.Drawing.Size(90, 26);
			this.btnOK.StretchImage = false;
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "OK";
			this.btnOK.TextDropShadow = false;
			this.btnOK.UseVisualStyleBackColor = false;
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.pnlWikiHelp.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.pnlWikiHelp.Location = new global::System.Drawing.Point(14, 348);
			this.pnlWikiHelp.Name = "pnlWikiHelp";
			this.pnlWikiHelp.Size = new global::System.Drawing.Size(35, 35);
			this.pnlWikiHelp.TabIndex = 14;
			this.pnlWikiHelp.MouseLeave += new global::System.EventHandler(this.pnlWikiHelp_MouseLeave);
			this.pnlWikiHelp.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.pnlWikiHelp_MouseClick);
			this.pnlWikiHelp.MouseEnter += new global::System.EventHandler(this.pnlWikiHelp_MouseEnter);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(353, 386);
			base.Controls.Add(this.pnlWikiHelp);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnApply);
			base.Controls.Add(this.tabOptions);
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "OptionsPopup";
			base.ShowBar = true;
			base.ShowClose = true;
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Settings";
			base.Controls.SetChildIndex(this.tabOptions, 0);
			base.Controls.SetChildIndex(this.btnApply, 0);
			base.Controls.SetChildIndex(this.btnCancel, 0);
			base.Controls.SetChildIndex(this.btnOK, 0);
			base.Controls.SetChildIndex(this.pnlWikiHelp, 0);
			this.tabOptions.ResumeLayout(false);
			this.tpageDisplay.ResumeLayout(false);
			this.tpageDisplay.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.trackBarEnvironmentals).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.trackBarSFX).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.trackBarMusicVolume).EndInit();
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04002B99 RID: 11161
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04002B9A RID: 11162
		private global::Dotnetrix_Samples.TabControlEx tabOptions;

		// Token: 0x04002B9B RID: 11163
		private global::System.Windows.Forms.TabPage tpageDisplay;

		// Token: 0x04002B9C RID: 11164
		private global::Kingdoms.BitmapButton btnApply;

		// Token: 0x04002B9D RID: 11165
		private global::Kingdoms.BitmapButton btnCancel;

		// Token: 0x04002B9E RID: 11166
		private global::Kingdoms.BitmapButton btnOK;

		// Token: 0x04002B9F RID: 11167
		private global::System.Windows.Forms.TabPage tabPage3;

		// Token: 0x04002BA0 RID: 11168
		private global::System.Windows.Forms.CheckBox cbProfanityFilter;

		// Token: 0x04002BA1 RID: 11169
		private global::System.Windows.Forms.CheckBox cbInstantTooltips;

		// Token: 0x04002BA2 RID: 11170
		private global::System.Windows.Forms.CheckBox cbConfirmCards;

		// Token: 0x04002BA3 RID: 11171
		private global::System.Windows.Forms.CheckBox cbTooltips;

		// Token: 0x04002BA4 RID: 11172
		private global::Kingdoms.BitmapButton btnDebugInfo;

		// Token: 0x04002BA5 RID: 11173
		private global::Kingdoms.BitmapButton btnResumeTutorial;

		// Token: 0x04002BA6 RID: 11174
		private global::System.Windows.Forms.TabPage tabPage1;

		// Token: 0x04002BA7 RID: 11175
		private global::System.Windows.Forms.ListBox listBoxLanguages;

		// Token: 0x04002BA8 RID: 11176
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04002BA9 RID: 11177
		private global::System.Windows.Forms.CheckBox cbConfirmOpenMultiple;

		// Token: 0x04002BAA RID: 11178
		private global::System.Windows.Forms.CheckBox cbConfirmBuyMultiple;

		// Token: 0x04002BAB RID: 11179
		private global::System.Windows.Forms.CheckBox cbMusic;

		// Token: 0x04002BAC RID: 11180
		private global::System.Windows.Forms.TrackBar trackBarMusicVolume;

		// Token: 0x04002BAD RID: 11181
		private global::System.Windows.Forms.CheckBox cbGraphicsCompatibility;

		// Token: 0x04002BAE RID: 11182
		private global::System.Windows.Forms.TrackBar trackBarSFX;

		// Token: 0x04002BAF RID: 11183
		private global::System.Windows.Forms.CheckBox cbSFX;

		// Token: 0x04002BB0 RID: 11184
		private global::System.Windows.Forms.Label lblVolumes;

		// Token: 0x04002BB1 RID: 11185
		private global::System.Windows.Forms.TrackBar trackBarEnvironmentals;

		// Token: 0x04002BB2 RID: 11186
		private global::System.Windows.Forms.CheckBox cbEnvironmentals;

		// Token: 0x04002BB3 RID: 11187
		private global::Kingdoms.BitmapButton btnRestoreDefaultVolumes;

		// Token: 0x04002BB4 RID: 11188
		private global::System.Windows.Forms.CheckBox cbBattleSFX;

		// Token: 0x04002BB5 RID: 11189
		private global::System.Windows.Forms.Label lblAdvanced;

		// Token: 0x04002BB6 RID: 11190
		private global::System.Windows.Forms.CheckBox cbVillageIDs;

		// Token: 0x04002BB7 RID: 11191
		private global::System.Windows.Forms.CheckBox cbSeasonalFX;

		// Token: 0x04002BB8 RID: 11192
		private global::System.Windows.Forms.Panel pnlWikiHelp;

		// Token: 0x04002BB9 RID: 11193
		private global::System.Windows.Forms.CheckBox cbFlashingTaskbarAttack;

		// Token: 0x04002BBA RID: 11194
		private global::System.Windows.Forms.CheckBox cbProductionInfo;

		// Token: 0x04002BBB RID: 11195
		private global::System.Windows.Forms.CheckBox cbCapitalIDs;

		// Token: 0x04002BBC RID: 11196
		private global::System.Windows.Forms.CheckBox cbWinterLandscape;

		// Token: 0x04002BBD RID: 11197
		private global::System.Windows.Forms.CheckBox cbWhiteTextBox;
	}
}
