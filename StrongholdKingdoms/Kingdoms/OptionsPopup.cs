using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Dotnetrix_Samples;
using Kingdoms.Properties;
using StatTracking;

namespace Kingdoms
{
	// Token: 0x0200025F RID: 607
	public partial class OptionsPopup : MyFormBase
	{
		// Token: 0x06001AAC RID: 6828 RVA: 0x0001AA4B File Offset: 0x00018C4B
		public OptionsPopup()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06001AAD RID: 6829 RVA: 0x0001AA80 File Offset: 0x00018C80
		public static void registerCallback(OptionsPopup.ResolutionChangeCallback newResolutionChangeCallback)
		{
			OptionsPopup.resolutionChangeCallback = newResolutionChangeCallback;
		}

		// Token: 0x06001AAE RID: 6830 RVA: 0x0001AA88 File Offset: 0x00018C88
		public static void openSettings()
		{
			if (OptionsPopup.popup == null || !OptionsPopup.popup.Created)
			{
				OptionsPopup.popup = new OptionsPopup();
			}
			OptionsPopup.popup.setup(0);
			OptionsPopup.popup.Show(InterfaceMgr.Instance.ParentForm);
		}

		// Token: 0x06001AAF RID: 6831 RVA: 0x001A5B98 File Offset: 0x001A3D98
		public static void openSettingsLogin()
		{
			if (OptionsPopup.popup == null || !OptionsPopup.popup.Created)
			{
				OptionsPopup.popup = new OptionsPopup();
			}
			OptionsPopup.popup.setup(0);
			OptionsPopup.popup.ShowDialog(Program.profileLogin);
			OptionsPopup.popup.Dispose();
		}

		// Token: 0x06001AB0 RID: 6832 RVA: 0x0001AAC6 File Offset: 0x00018CC6
		public static void openSettings(int tabID)
		{
			if (OptionsPopup.popup == null || !OptionsPopup.popup.Created)
			{
				OptionsPopup.popup = new OptionsPopup();
			}
			OptionsPopup.popup.setup(tabID);
			OptionsPopup.popup.Show(InterfaceMgr.Instance.ParentForm);
		}

		// Token: 0x06001AB1 RID: 6833 RVA: 0x001A5BE8 File Offset: 0x001A3DE8
		private void addLanguage(string name, string id)
		{
			this.listBoxLanguages.Items.Add(name);
			this.languageIDs.Add(id);
			if ((id == Program.mySettings.LanguageIdent || (id == "en" && Program.mySettings.LanguageIdent.Length == 0)) && this.initialLanguageIndex == -1)
			{
				this.initialLanguageIndex = this.languageIDs.Count - 1;
				this.listBoxLanguages.SelectedIndex = this.initialLanguageIndex;
			}
		}

		// Token: 0x06001AB2 RID: 6834 RVA: 0x001A5C70 File Offset: 0x001A3E70
		public void initLabels()
		{
			this.tpageDisplay.Text = SK.Text("Options_Settings", "Settings");
			this.btnResumeTutorial.Text = SK.Text("Options_Resume_Tutorial", "Resume Tutorial");
			this.btnDebugInfo.Text = SK.Text("Options_Debug_Info", "Debug Info");
			this.cbTooltips.Text = SK.Text("Options_Tooltips", "Tooltips");
			this.cbInstantTooltips.Text = SK.Text("Options_Instant_Tooltips", "Instant Tooltips");
			this.cbConfirmCards.Text = SK.Text("Options_ConfirmCards", "Confirm Playing Cards");
			this.cbConfirmBuyMultiple.Text = SK.Text("Options_ConfirmCardsBuy", "Buy Multiple Card Packs");
			this.cbConfirmOpenMultiple.Text = SK.Text("Options_ConfirmCardsOpen", "Open Multiple Card Packs");
			this.cbProfanityFilter.Text = SK.Text("Options_Profanity_Filter", "Profanity Filter");
			this.btnApply.Text = SK.Text("Options_Apply", "Apply");
			this.btnCancel.Text = SK.Text("GENERIC_Cancel", "Cancel");
			string text = this.Text = (base.Title = SK.Text("Options_Settings", "Settings"));
			this.btnOK.Text = SK.Text("GENERIC_OK", "OK");
			this.label1.Text = SK.Text("Options_Available_Languages", "Available Languages");
			this.tabPage3.Text = SK.Text("Options_Audio", "Audio / Visual");
			this.cbMusic.Text = SK.Text("Options_Music", "Music");
			this.cbGraphicsCompatibility.Text = SK.Text("Options_Graphics_Compatibility", "Graphics Compatibility Mode");
			this.tabPage1.Text = SK.Text("Options_Languages", "Languages");
			this.cbSFX.Text = SK.Text("Options_SFX", "Sound FX");
			this.cbEnvironmentals.Text = SK.Text("Options_Environmentals", "Ambient Sounds");
			this.cbBattleSFX.Text = SK.Text("Options_BattleSFX", "Battle Sound FX");
			this.lblVolumes.Text = SK.Text("Options_Volumne", "Volume");
			this.btnRestoreDefaultVolumes.Text = SK.Text("Options_RestoreDefaultVolume", "Restore Defaults");
			this.lblAdvanced.Text = SK.Text("Options_AdvancedOptions", "Advanced Options");
			this.cbVillageIDs.Text = SK.Text("Options_VillageIDs", "View Village IDs");
			this.cbCapitalIDs.Text = SK.Text("Options_CapitalIDs", "View Capital IDs");
			this.cbSeasonalFX.Text = SK.Text("Options_show_Seasonal_FX2", "Show Snow Effect");
			this.cbWinterLandscape.Text = SK.Text("Options_show_Winter", "Show Winter Landscape");
			this.cbFlashingTaskbarAttack.Text = SK.Text("Options_Flashing_Taskbar_Attack", "Flash Taskbar Icon When Attacked");
			this.cbProductionInfo.Text = SK.Text("Options_Production_Info", "Production Indicators in the Village Map");
			this.cbWhiteTextBox.Text = SK.Text("Options_White_Backgrounds", "Show White Background on Parish Names");
		}

		// Token: 0x06001AB3 RID: 6835 RVA: 0x001A5FAC File Offset: 0x001A41AC
		public void setup(int tabID)
		{
			this.playSounds = false;
			this.initLabels();
			this.initialLanguageIndex = -1;
			this.listBoxLanguages.Items.Clear();
			this.languageIDs.Clear();
			this.addLanguage("English", "en");
			this.addLanguage("Deutsch", "de");
			this.addLanguage("Francais", "fr");
			this.addLanguage("Русский", "ru");
			this.addLanguage("Espanol", "es");
			this.addLanguage("Polski", "pl");
			this.addLanguage("Turkce", "tr");
			this.addLanguage("Italiano", "it");
			this.addLanguage("Portugues do Brasil", "pt");
			this.addLanguage("????", "zh");
			this.addLanguage("????", "zhhk");
			this.addLanguage("???", "ko");
			this.addLanguage("???", "jp");
			foreach (SKLang sklang in Program.communityLangs)
			{
				bool flag = true;
				if (sklang.id == "en" || sklang.id == "de" || sklang.id == "fr" || sklang.id == "ru" || sklang.id == "es" || sklang.id == "pl" || sklang.id == "tr" || sklang.id == "it" || sklang.id == "pt")
				{
					flag = false;
				}
				if (flag)
				{
					this.addLanguage(sklang.name + "   (" + SK.Text("OptionsPopup_CommunityLanguage", "Community Translation") + ")", sklang.id);
				}
			}
			this.cbSeasonalFX.Visible = Program.ShowSeasonalFXOption;
			this.cbWinterLandscape.Visible = Program.ShowSeasonalFXOption;
			this.pnlWikiHelp.BackgroundImage = GFXLibrary.int_button_Q_normal;
			CustomTooltipManager.addTooltipToSystemControl(this.pnlWikiHelp, 4402);
			this.btnResumeTutorial.Visible = false;
			RemoteServices.Instance.set_UpdateReportFilters_UserCallBack(new RemoteServices.UpdateReportFilters_UserCallBack(this.updateReportFiltersCallback));
			this.cbProfanityFilter.Checked = RemoteServices.Instance.UserOptions.profanityFilter;
			this.cbConfirmCards.Checked = Program.mySettings.ConfirmPlayCard;
			this.cbConfirmOpenMultiple.Checked = Program.mySettings.OpenMultipleCardPacks;
			this.cbConfirmBuyMultiple.Checked = Program.mySettings.BuyMultipleCardPacks;
			this.cbInstantTooltips.Checked = Program.mySettings.SETTINGS_instantTooltips;
			this.cbTooltips.Checked = Program.mySettings.SETTINGS_showTooltips;
			this.cbVillageIDs.Checked = Program.mySettings.viewVillageIDs;
			this.cbCapitalIDs.Checked = Program.mySettings.viewCapitalIDs;
			this.cbSeasonalFX.Checked = Program.mySettings.SeasonalSpecialFX;
			this.cbWinterLandscape.Checked = Program.mySettings.SeasonalWinterLandscape;
			this.cbFlashingTaskbarAttack.Checked = Program.mySettings.FlashingTaskbarAttack;
			this.cbProductionInfo.Checked = Program.mySettings.ShowProductionInfo;
			this.cbWhiteTextBox.Checked = Program.mySettings.UseMapTextBorders;
			this.cbMusic.Checked = Program.mySettings.Music;
			int num = Program.mySettings.MusicVolume;
			if (num < this.trackBarMusicVolume.Minimum)
			{
				num = this.trackBarMusicVolume.Minimum;
			}
			if (num > this.trackBarMusicVolume.Maximum)
			{
				num = this.trackBarMusicVolume.Maximum;
			}
			this.trackBarMusicVolume.Value = num;
			this.cbSFX.Checked = Program.mySettings.SFX;
			this.cbBattleSFX.Checked = Program.mySettings.BattleSFX;
			int num2 = Program.mySettings.SFXVolume;
			if (num2 < this.trackBarSFX.Minimum)
			{
				num2 = this.trackBarSFX.Minimum;
			}
			if (num2 > this.trackBarSFX.Maximum)
			{
				num2 = this.trackBarSFX.Maximum;
			}
			this.trackBarSFX.Value = num2;
			this.cbEnvironmentals.Checked = Program.mySettings.Environmentals;
			int num3 = Program.mySettings.EnvironmentalVolume;
			if (num3 < this.trackBarEnvironmentals.Minimum)
			{
				num3 = this.trackBarEnvironmentals.Minimum;
			}
			if (num3 > this.trackBarEnvironmentals.Maximum)
			{
				num3 = this.trackBarEnvironmentals.Maximum;
			}
			this.trackBarEnvironmentals.Value = num3;
			if (Program.mySettings.AAMode == 1)
			{
				this.cbGraphicsCompatibility.Checked = true;
			}
			else
			{
				this.cbGraphicsCompatibility.Checked = false;
			}
			this.musicVolumeChanged = false;
			this.soundfxVolumeChanged = false;
			this.environmentalVolumeChanged = false;
			if (tabID != 0)
			{
				if (tabID == 1)
				{
					this.tabOptions.SelectTab("tpageReports");
				}
			}
			else
			{
				this.tabOptions.SelectTab("tpageDisplay");
			}
			this.btnApply.Enabled = false;
			this.playSounds = true;
			StatTrackingClient.Instance().ActivateTrigger(28, Program.mySettings.UseMapTextBorders);
		}

		// Token: 0x06001AB4 RID: 6836 RVA: 0x0001AB04 File Offset: 0x00018D04
		private void updateReportFiltersCallback(UpdateReportFilters_ReturnType returnData)
		{
			bool success = returnData.Success;
		}

		// Token: 0x06001AB5 RID: 6837 RVA: 0x001A6540 File Offset: 0x001A4740
		private void btnOK_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("OptionsPopup_ok");
			bool flag = false;
			if (Program.mySettings.SeasonalWinterLandscape != this.cbWinterLandscape.Checked)
			{
				flag = true;
			}
			this.applySettings();
			StatTrackingClient.Instance().ActivateTrigger(29, Program.mySettings.UseMapTextBorders);
			base.Close();
			InterfaceMgr.Instance.reactiveMainWindow();
			if (flag)
			{
				GFXLibrary.Instance.flushSnowGFX();
			}
		}

		// Token: 0x06001AB6 RID: 6838 RVA: 0x001A65B8 File Offset: 0x001A47B8
		private void btnCancel_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("OptionsPopup_cancel");
			if (this.musicVolumeChanged)
			{
				GameEngine.Instance.AudioEngine.setMP3MasterVolume((float)Program.mySettings.MusicVolume / 100f, 0);
			}
			if (this.soundfxVolumeChanged)
			{
				GameEngine.Instance.AudioEngine.setSFXMasterVolume((float)Program.mySettings.SFXVolume / 100f);
			}
			if (this.environmentalVolumeChanged)
			{
				GameEngine.Instance.AudioEngine.setEnvironmentalMasterVolume((float)Program.mySettings.EnvironmentalVolume / 100f);
			}
			base.Close();
			InterfaceMgr.Instance.reactiveMainWindow();
		}

		// Token: 0x06001AB7 RID: 6839 RVA: 0x001A6660 File Offset: 0x001A4860
		private void btnApply_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("OptionsPopup_apply");
			bool flag = false;
			if (Program.mySettings.SeasonalWinterLandscape != this.cbWinterLandscape.Checked)
			{
				flag = true;
			}
			this.applySettings();
			this.btnApply.Enabled = false;
			if (flag)
			{
				GFXLibrary.Instance.flushSnowGFX();
			}
		}

		// Token: 0x06001AB8 RID: 6840 RVA: 0x001A66B8 File Offset: 0x001A48B8
		private void applySettings()
		{
			bool flag = false;
			if (RemoteServices.Instance.UserOptions.profanityFilter != this.cbProfanityFilter.Checked)
			{
				flag = true;
				RemoteServices.Instance.UserOptions.profanityFilter = this.cbProfanityFilter.Checked;
			}
			if (this.initialLanguageIndex != this.listBoxLanguages.SelectedIndex)
			{
				this.initialLanguageIndex = this.listBoxLanguages.SelectedIndex;
				string languageIdent = this.languageIDs[this.initialLanguageIndex];
				Program.mySettings.LanguageIdent = languageIdent;
				SKLocalization.LoadLocalization(Application.StartupPath + "\\Localization\\", Program.mySettings.LanguageIdent);
				if (!SKLocalization.Instance.valid)
				{
					MyMessageBox.Show(SK.Text("OptionsPopup_Community_Language_main", "You have selected a language that was created by members of the Stronghold Kingdoms community and is not directly supported by Firefly, therefore we cannot guarantee the accuracy of any translations."), SK.Text("OptionsPopup_CommunityLanguage", "Community Translation"));
					string langsPath = GameEngine.getLangsPath();
					SKLocalization.LoadLocalization(langsPath, Program.mySettings.LanguageIdent);
				}
				this.initLabels();
				MyMessageBox.Show(SK.Text("OptionsPopup_ChangeLanguage_Restart", "It is recommended that you reload the client after changing the language."), SK.Text("OptionsPopup_ChangeLanguage", "Change Language"));
				GameEngine.Instance.World.updateRegionsNamesBasedOnLanguage();
			}
			if (flag)
			{
				RemoteServices.Instance.UpdateUserOptions(RemoteServices.Instance.UserOptions);
			}
			Program.mySettings.SETTINGS_instantTooltips = this.cbInstantTooltips.Checked;
			Program.mySettings.ConfirmPlayCard = this.cbConfirmCards.Checked;
			Program.mySettings.SETTINGS_showTooltips = this.cbTooltips.Checked;
			Program.mySettings.OpenMultipleCardPacks = this.cbConfirmOpenMultiple.Checked;
			Program.mySettings.BuyMultipleCardPacks = this.cbConfirmBuyMultiple.Checked;
			Program.mySettings.viewVillageIDs = this.cbVillageIDs.Checked;
			Program.mySettings.viewCapitalIDs = this.cbCapitalIDs.Checked;
			Program.mySettings.Music = this.cbMusic.Checked;
			Program.mySettings.MusicVolume = this.trackBarMusicVolume.Value;
			Sound.setMusicState(Program.mySettings.Music);
			Program.mySettings.SFX = this.cbSFX.Checked;
			Program.mySettings.SFXVolume = this.trackBarSFX.Value;
			Sound.setSFXState(Program.mySettings.SFX);
			Program.mySettings.BattleSFX = this.cbBattleSFX.Checked;
			Sound.setBattleSFXState(Program.mySettings.BattleSFX);
			Program.mySettings.Environmentals = this.cbEnvironmentals.Checked;
			Program.mySettings.EnvironmentalVolume = this.trackBarEnvironmentals.Value;
			Sound.setEnvironmentalState(Program.mySettings.Environmentals);
			GameEngine.Instance.AudioEngine.setMP3MasterVolume((float)Program.mySettings.MusicVolume / 100f, 0);
			GameEngine.Instance.AudioEngine.setSFXMasterVolume((float)Program.mySettings.SFXVolume / 100f);
			GameEngine.Instance.AudioEngine.setEnvironmentalMasterVolume((float)Program.mySettings.EnvironmentalVolume / 100f);
			int num = 2;
			if (this.cbGraphicsCompatibility.Checked)
			{
				num = 1;
			}
			if (num != Program.mySettings.AAMode)
			{
				Program.mySettings.AAMode = num;
				MyMessageBox.Show(SK.Text("OptionsPopup_Restart_Required_Main", "You need to restart Stronghold Kingdoms for these changes to take place."), SK.Text("OptionsPopup_Restart_Required", "Restart Required"));
			}
			Program.mySettings.SeasonalSpecialFX = this.cbSeasonalFX.Checked;
			Program.mySettings.SeasonalWinterLandscape = this.cbWinterLandscape.Checked;
			Program.mySettings.FlashingTaskbarAttack = this.cbFlashingTaskbarAttack.Checked;
			Program.mySettings.ShowProductionInfo = this.cbProductionInfo.Checked;
			Program.mySettings.UseMapTextBorders = this.cbWhiteTextBox.Checked;
			Program.mySettings.Save();
		}

		// Token: 0x06001AB9 RID: 6841 RVA: 0x0001AB0D File Offset: 0x00018D0D
		private void cbReportFilter_CheckedChanged(object sender, EventArgs e)
		{
			this.btnApply.Enabled = true;
			if (this.playSounds)
			{
				GameEngine.Instance.playInterfaceSound("Options_checkbox_toggled");
			}
		}

		// Token: 0x06001ABA RID: 6842 RVA: 0x0001AB0D File Offset: 0x00018D0D
		private void cbProfanityFilter_CheckedChanged(object sender, EventArgs e)
		{
			this.btnApply.Enabled = true;
			if (this.playSounds)
			{
				GameEngine.Instance.playInterfaceSound("Options_checkbox_toggled");
			}
		}

		// Token: 0x06001ABB RID: 6843 RVA: 0x0001AB0D File Offset: 0x00018D0D
		private void cbConfirmCards_CheckedChanged(object sender, EventArgs e)
		{
			this.btnApply.Enabled = true;
			if (this.playSounds)
			{
				GameEngine.Instance.playInterfaceSound("Options_checkbox_toggled");
			}
		}

		// Token: 0x06001ABC RID: 6844 RVA: 0x0001AB0D File Offset: 0x00018D0D
		private void cbInstantTooltips_CheckedChanged(object sender, EventArgs e)
		{
			this.btnApply.Enabled = true;
			if (this.playSounds)
			{
				GameEngine.Instance.playInterfaceSound("Options_checkbox_toggled");
			}
		}

		// Token: 0x06001ABD RID: 6845 RVA: 0x0001AB0D File Offset: 0x00018D0D
		private void cbTooltips_CheckedChanged(object sender, EventArgs e)
		{
			this.btnApply.Enabled = true;
			if (this.playSounds)
			{
				GameEngine.Instance.playInterfaceSound("Options_checkbox_toggled");
			}
		}

		// Token: 0x06001ABE RID: 6846 RVA: 0x0001AB32 File Offset: 0x00018D32
		private void btnDebugInfo_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.toggleDebugPopup();
		}

		// Token: 0x06001ABF RID: 6847 RVA: 0x0001AB3E File Offset: 0x00018D3E
		private void btnResumeTutorial_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("Options_resume_tutorial");
			GameEngine.Instance.World.resumeTutorial();
			this.btnResumeTutorial.Visible = false;
		}

		// Token: 0x06001AC0 RID: 6848 RVA: 0x0001AB6A File Offset: 0x00018D6A
		private void listBoxLanguages_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.playSounds)
			{
				GameEngine.Instance.playInterfaceSound("Options_language_selected");
			}
			this.btnApply.Enabled = true;
		}

		// Token: 0x06001AC1 RID: 6849 RVA: 0x0001AB0D File Offset: 0x00018D0D
		private void cbConfirmBuyMultiple_CheckedChanged(object sender, EventArgs e)
		{
			this.btnApply.Enabled = true;
			if (this.playSounds)
			{
				GameEngine.Instance.playInterfaceSound("Options_checkbox_toggled");
			}
		}

		// Token: 0x06001AC2 RID: 6850 RVA: 0x0001AB0D File Offset: 0x00018D0D
		private void cbConfirmOpenMultiple_CheckedChanged(object sender, EventArgs e)
		{
			this.btnApply.Enabled = true;
			if (this.playSounds)
			{
				GameEngine.Instance.playInterfaceSound("Options_checkbox_toggled");
			}
		}

		// Token: 0x06001AC3 RID: 6851 RVA: 0x0001AB0D File Offset: 0x00018D0D
		private void cbMusic_CheckedChanged(object sender, EventArgs e)
		{
			this.btnApply.Enabled = true;
			if (this.playSounds)
			{
				GameEngine.Instance.playInterfaceSound("Options_checkbox_toggled");
			}
		}

		// Token: 0x06001AC4 RID: 6852 RVA: 0x0001AB8F File Offset: 0x00018D8F
		private void trackBarMusicVolume_ValueChanged(object sender, EventArgs e)
		{
			GameEngine.Instance.AudioEngine.setMP3MasterVolume((float)this.trackBarMusicVolume.Value / 100f, 0);
			this.btnApply.Enabled = true;
			this.musicVolumeChanged = true;
		}

		// Token: 0x06001AC5 RID: 6853 RVA: 0x0001AB0D File Offset: 0x00018D0D
		private void cbGraphicsCompatibility_CheckedChanged(object sender, EventArgs e)
		{
			this.btnApply.Enabled = true;
			if (this.playSounds)
			{
				GameEngine.Instance.playInterfaceSound("Options_checkbox_toggled");
			}
		}

		// Token: 0x06001AC6 RID: 6854 RVA: 0x0001AB0D File Offset: 0x00018D0D
		private void cbSFX_CheckedChanged(object sender, EventArgs e)
		{
			this.btnApply.Enabled = true;
			if (this.playSounds)
			{
				GameEngine.Instance.playInterfaceSound("Options_checkbox_toggled");
			}
		}

		// Token: 0x06001AC7 RID: 6855 RVA: 0x0001ABC6 File Offset: 0x00018DC6
		private void trackBarSFX_ValueChanged(object sender, EventArgs e)
		{
			GameEngine.Instance.AudioEngine.setSFXMasterVolume((float)this.trackBarSFX.Value / 100f);
			this.btnApply.Enabled = true;
			this.soundfxVolumeChanged = true;
		}

		// Token: 0x06001AC8 RID: 6856 RVA: 0x0001ABFC File Offset: 0x00018DFC
		private void cbEnvironmentals_CheckedChanged(object sender, EventArgs e)
		{
			if (this.playSounds)
			{
				GameEngine.Instance.playInterfaceSound("Options_checkbox_toggled");
			}
			this.btnApply.Enabled = true;
			this.environmentalVolumeChanged = true;
		}

		// Token: 0x06001AC9 RID: 6857 RVA: 0x0001AC28 File Offset: 0x00018E28
		private void trackBarEnvironmentals_ValueChanged(object sender, EventArgs e)
		{
			GameEngine.Instance.AudioEngine.setEnvironmentalMasterVolume((float)this.trackBarEnvironmentals.Value / 100f);
			this.btnApply.Enabled = true;
			this.environmentalVolumeChanged = true;
		}

		// Token: 0x06001ACA RID: 6858 RVA: 0x0001AC5E File Offset: 0x00018E5E
		private void tabOptions_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.playSounds)
			{
				GameEngine.Instance.playInterfaceSound("Options_tab_changed");
			}
		}

		// Token: 0x06001ACB RID: 6859 RVA: 0x0001AC77 File Offset: 0x00018E77
		private void btnRestoreDefaultVolumes_Click(object sender, EventArgs e)
		{
			this.trackBarMusicVolume.Value = 13;
			this.trackBarSFX.Value = 100;
			this.trackBarEnvironmentals.Value = 34;
		}

		// Token: 0x06001ACC RID: 6860 RVA: 0x0001AB0D File Offset: 0x00018D0D
		private void cbBattleSFX_CheckedChanged(object sender, EventArgs e)
		{
			this.btnApply.Enabled = true;
			if (this.playSounds)
			{
				GameEngine.Instance.playInterfaceSound("Options_checkbox_toggled");
			}
		}

		// Token: 0x06001ACD RID: 6861 RVA: 0x0001AB0D File Offset: 0x00018D0D
		private void cbVillageIDs_CheckedChanged(object sender, EventArgs e)
		{
			this.btnApply.Enabled = true;
			if (this.playSounds)
			{
				GameEngine.Instance.playInterfaceSound("Options_checkbox_toggled");
			}
		}

		// Token: 0x06001ACE RID: 6862 RVA: 0x0001AB0D File Offset: 0x00018D0D
		private void cbSeasonalFX_CheckedChanged(object sender, EventArgs e)
		{
			this.btnApply.Enabled = true;
			if (this.playSounds)
			{
				GameEngine.Instance.playInterfaceSound("Options_checkbox_toggled");
			}
		}

		// Token: 0x06001ACF RID: 6863 RVA: 0x0001ACA0 File Offset: 0x00018EA0
		private void pnlWikiHelp_MouseEnter(object sender, EventArgs e)
		{
			this.pnlWikiHelp.BackgroundImage = GFXLibrary.int_button_Q_over;
		}

		// Token: 0x06001AD0 RID: 6864 RVA: 0x0001ACB7 File Offset: 0x00018EB7
		private void pnlWikiHelp_MouseLeave(object sender, EventArgs e)
		{
			this.pnlWikiHelp.BackgroundImage = GFXLibrary.int_button_Q_normal;
		}

		// Token: 0x06001AD1 RID: 6865 RVA: 0x0001ACCE File Offset: 0x00018ECE
		private void pnlWikiHelp_MouseClick(object sender, MouseEventArgs e)
		{
			CustomSelfDrawPanel.WikiLinkControl.openHelpLink(30);
		}

		// Token: 0x06001AD2 RID: 6866 RVA: 0x0001AB0D File Offset: 0x00018D0D
		private void cbFlashingTaskbarAttack_CheckedChanged(object sender, EventArgs e)
		{
			this.btnApply.Enabled = true;
			if (this.playSounds)
			{
				GameEngine.Instance.playInterfaceSound("Options_checkbox_toggled");
			}
		}

		// Token: 0x06001AD3 RID: 6867 RVA: 0x0001AB0D File Offset: 0x00018D0D
		private void cbProductionInfo_CheckedChanged(object sender, EventArgs e)
		{
			this.btnApply.Enabled = true;
			if (this.playSounds)
			{
				GameEngine.Instance.playInterfaceSound("Options_checkbox_toggled");
			}
		}

		// Token: 0x06001AD4 RID: 6868 RVA: 0x0001AB0D File Offset: 0x00018D0D
		private void cbWhiteTextBox_CheckedChanged(object sender, EventArgs e)
		{
			this.btnApply.Enabled = true;
			if (this.playSounds)
			{
				GameEngine.Instance.playInterfaceSound("Options_checkbox_toggled");
			}
		}

		// Token: 0x06001AD5 RID: 6869 RVA: 0x0001AB0D File Offset: 0x00018D0D
		private void cbCapitalIDs_CheckedChanged(object sender, EventArgs e)
		{
			this.btnApply.Enabled = true;
			if (this.playSounds)
			{
				GameEngine.Instance.playInterfaceSound("Options_checkbox_toggled");
			}
		}

		// Token: 0x06001AD6 RID: 6870 RVA: 0x0001AB0D File Offset: 0x00018D0D
		private void cbWinterLandscape_CheckedChanged(object sender, EventArgs e)
		{
			this.btnApply.Enabled = true;
			if (this.playSounds)
			{
				GameEngine.Instance.playInterfaceSound("Options_checkbox_toggled");
			}
		}

		// Token: 0x04002B8F RID: 11151
		public const int SETTINGS_TAB_DISPLAY = 0;

		// Token: 0x04002B90 RID: 11152
		public const int SETTINGS_REPORTS_DISPLAY = 1;

		// Token: 0x04002B91 RID: 11153
		private static OptionsPopup.ResolutionChangeCallback resolutionChangeCallback;

		// Token: 0x04002B92 RID: 11154
		private static OptionsPopup popup;

		// Token: 0x04002B93 RID: 11155
		private bool musicVolumeChanged;

		// Token: 0x04002B94 RID: 11156
		private bool soundfxVolumeChanged;

		// Token: 0x04002B95 RID: 11157
		private bool environmentalVolumeChanged;

		// Token: 0x04002B96 RID: 11158
		private bool playSounds;

		// Token: 0x04002B97 RID: 11159
		private int initialLanguageIndex = -1;

		// Token: 0x04002B98 RID: 11160
		private List<string> languageIDs = new List<string>();

		// Token: 0x02000260 RID: 608
		// (Invoke) Token: 0x06001ADA RID: 6874
		public delegate void ResolutionChangeCallback(int newRes);
	}
}
