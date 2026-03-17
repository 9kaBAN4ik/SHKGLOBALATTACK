using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x0200046D RID: 1133
	public class ReportCapturePanel : CustomSelfDrawPanel
	{
		// Token: 0x060028E2 RID: 10466 RVA: 0x0001E2C3 File Offset: 0x0001C4C3
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060028E3 RID: 10467 RVA: 0x001EFDDC File Offset: 0x001EDFDC
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.White;
			base.Name = "ReportCapturePanel";
			base.Size = new Size(600, 55);
			base.ResumeLayout(false);
		}

		// Token: 0x060028E4 RID: 10468 RVA: 0x001EFE3C File Offset: 0x001EE03C
		public ReportCapturePanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x060028E5 RID: 10469 RVA: 0x001EFF80 File Offset: 0x001EE180
		public void init(int mode, ReportCapturePopup parent)
		{
			this.m_mode = mode;
			base.clearControls();
			this.backgroundImage.Image = GFXLibrary.popup_background_01;
			this.backgroundImage.Position = new Point(0, 0);
			base.addControl(this.backgroundImage);
			bool flag = false;
			if (mode == 0)
			{
				this.captureLabel.Text = SK.Text("Report_Capturing", "Report Capturing");
				flag = true;
			}
			else
			{
				this.captureLabel.Text = SK.Text("Report_Filtering", "Report Filtering");
			}
			this.captureLabel.Color = global::ARGBColors.White;
			this.captureLabel.Position = new Point(13, 7);
			this.captureLabel.Size = new Size(335, 20);
			this.captureLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.captureLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.backgroundImage.addControl(this.captureLabel);
			this.okButton.ImageNorm = GFXLibrary.button_blue_01_normal;
			this.okButton.ImageOver = GFXLibrary.button_blue_01_over;
			this.okButton.ImageClick = GFXLibrary.button_blue_01_in;
			this.okButton.Position = new Point(240, 325);
			this.okButton.Text.Text = SK.Text("GENERIC_OK", "OK");
			this.okButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.okButton.Text.Color = global::ARGBColors.Black;
			this.okButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.okClicked), "ReportCapturePanel_ok");
			this.backgroundImage.addControl(this.okButton);
			this.cancelButton.ImageNorm = GFXLibrary.button_blue_01_normal;
			this.cancelButton.ImageOver = GFXLibrary.button_blue_01_over;
			this.cancelButton.ImageClick = GFXLibrary.button_blue_01_in;
			this.cancelButton.Position = new Point(124, 325);
			this.cancelButton.Text.Text = SK.Text("GENERIC_Cancel", "Cancel");
			this.cancelButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.cancelButton.Text.Color = global::ARGBColors.Black;
			this.cancelButton.setClickDelegate(delegate()
			{
				InterfaceMgr.Instance.closeReportCaptureWindow();
				InterfaceMgr.Instance.ParentForm.TopMost = true;
				InterfaceMgr.Instance.ParentForm.TopMost = false;
			}, "ReportCapturePanel_cancel");
			this.cancelButton.Visible = flag;
			this.backgroundImage.addControl(this.cancelButton);
			ReportFilterList reportFilterList = (!flag) ? ReportsPanel.Instance.reportsManager.Filters : RemoteServices.Instance.ReportFilters;
			int num = 25;
			int num2 = 55;
			int num3 = 45;
			int num4 = 210;
			if (!flag)
			{
				num2 -= 12;
				num = 22;
			}
			if (Program.mySettings.LanguageIdent == "de")
			{
				num3 -= 20;
				num4 += 20;
			}
			this.attackCheck.CheckedImage = GFXLibrary.reports_checkbox_checked;
			this.attackCheck.UncheckedImage = GFXLibrary.reports_checkbox_empty;
			this.attackCheck.Position = new Point(num3, num2);
			this.attackCheck.Checked = reportFilterList.attacks;
			this.attackCheck.CBLabel.Text = SK.Text("ReportFilter_Attacks", "Attacks");
			this.attackCheck.CBLabel.Color = global::ARGBColors.Black;
			this.attackCheck.CBLabel.Position = new Point(20, -1);
			this.attackCheck.CBLabel.Size = new Size(170, 25);
			this.attackCheck.CBLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.attackCheck.Data = 0;
			this.attackCheck.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.checkToggled));
			this.backgroundImage.addControl(this.attackCheck);
			this.defenceCheck.CheckedImage = GFXLibrary.reports_checkbox_checked;
			this.defenceCheck.UncheckedImage = GFXLibrary.reports_checkbox_empty;
			this.defenceCheck.Position = new Point(num3, num2 + num);
			this.defenceCheck.Checked = reportFilterList.defense;
			this.defenceCheck.CBLabel.Text = SK.Text("ReportFilter_Defense", "Defense");
			this.defenceCheck.CBLabel.Color = global::ARGBColors.Black;
			this.defenceCheck.CBLabel.Position = new Point(20, -1);
			this.defenceCheck.CBLabel.Size = new Size(170, 25);
			this.defenceCheck.CBLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.defenceCheck.Data = 1;
			this.defenceCheck.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.checkToggled));
			this.backgroundImage.addControl(this.defenceCheck);
			this.enemyCheck.CheckedImage = GFXLibrary.reports_checkbox_checked;
			this.enemyCheck.UncheckedImage = GFXLibrary.reports_checkbox_empty;
			this.enemyCheck.Position = new Point(num3, num2 + 2 * num);
			this.enemyCheck.Checked = reportFilterList.enemyWarnings;
			this.enemyCheck.CBLabel.Text = SK.Text("ReportFilter_Enemy_Attacks", "Enemy Attacks");
			this.enemyCheck.CBLabel.Color = global::ARGBColors.Black;
			this.enemyCheck.CBLabel.Position = new Point(20, -1);
			this.enemyCheck.CBLabel.Size = new Size(170, 25);
			this.enemyCheck.CBLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.enemyCheck.Data = 2;
			this.enemyCheck.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.checkToggled));
			this.backgroundImage.addControl(this.enemyCheck);
			this.reinforceCheck.CheckedImage = GFXLibrary.reports_checkbox_checked;
			this.reinforceCheck.UncheckedImage = GFXLibrary.reports_checkbox_empty;
			this.reinforceCheck.Position = new Point(num3, num2 + 3 * num);
			this.reinforceCheck.Checked = reportFilterList.reinforcements;
			this.reinforceCheck.CBLabel.Text = SK.Text("ReportFilter_Reinforcements", "Reinforcements");
			this.reinforceCheck.CBLabel.Color = global::ARGBColors.Black;
			this.reinforceCheck.CBLabel.Position = new Point(20, -1);
			this.reinforceCheck.CBLabel.Size = new Size(190, 25);
			this.reinforceCheck.CBLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.reinforceCheck.Data = 3;
			this.reinforceCheck.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.checkToggled));
			this.backgroundImage.addControl(this.reinforceCheck);
			this.scoutingCheck.CheckedImage = GFXLibrary.reports_checkbox_checked;
			this.scoutingCheck.UncheckedImage = GFXLibrary.reports_checkbox_empty;
			this.scoutingCheck.Position = new Point(num3, num2 + 4 * num);
			this.scoutingCheck.Checked = reportFilterList.scouting;
			this.scoutingCheck.CBLabel.Text = SK.Text("ReportFilter_Scouting", "Scouting");
			this.scoutingCheck.CBLabel.Color = global::ARGBColors.Black;
			this.scoutingCheck.CBLabel.Position = new Point(20, -1);
			this.scoutingCheck.CBLabel.Size = new Size(170, 25);
			if (Program.mySettings.LanguageIdent == "pt")
			{
				this.scoutingCheck.CBLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			}
			else
			{
				this.scoutingCheck.CBLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			}
			this.scoutingCheck.Data = 4;
			this.scoutingCheck.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.checkToggled));
			this.backgroundImage.addControl(this.scoutingCheck);
			this.foragingCheck.CheckedImage = GFXLibrary.reports_checkbox_checked;
			this.foragingCheck.UncheckedImage = GFXLibrary.reports_checkbox_empty;
			this.foragingCheck.Position = new Point(num3, num2 + 5 * num);
			this.foragingCheck.Checked = reportFilterList.foraging;
			this.foragingCheck.CBLabel.Text = SK.Text("ReportFilter_Foraging", "Foraging");
			this.foragingCheck.CBLabel.Color = global::ARGBColors.Black;
			this.foragingCheck.CBLabel.Position = new Point(20, -1);
			this.foragingCheck.CBLabel.Size = new Size(170, 25);
			this.foragingCheck.CBLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.foragingCheck.Data = 5;
			this.foragingCheck.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.checkToggled));
			this.backgroundImage.addControl(this.foragingCheck);
			this.tradeCheck.CheckedImage = GFXLibrary.reports_checkbox_checked;
			this.tradeCheck.UncheckedImage = GFXLibrary.reports_checkbox_empty;
			this.tradeCheck.Position = new Point(num3, num2 + 6 * num);
			this.tradeCheck.Checked = reportFilterList.trade;
			this.tradeCheck.CBLabel.Text = SK.Text("ReportFilter_Trade", "Trade");
			this.tradeCheck.CBLabel.Color = global::ARGBColors.Black;
			this.tradeCheck.CBLabel.Position = new Point(20, -1);
			this.tradeCheck.CBLabel.Size = new Size(170, 25);
			this.tradeCheck.CBLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.tradeCheck.Data = 6;
			this.tradeCheck.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.checkToggled));
			this.backgroundImage.addControl(this.tradeCheck);
			this.vassalsCheck.CheckedImage = GFXLibrary.reports_checkbox_checked;
			this.vassalsCheck.UncheckedImage = GFXLibrary.reports_checkbox_empty;
			this.vassalsCheck.Position = new Point(num4, num2);
			this.vassalsCheck.Checked = reportFilterList.vassals;
			this.vassalsCheck.CBLabel.Text = SK.Text("ReportFilter_Vassals", "Vassals");
			this.vassalsCheck.CBLabel.Color = global::ARGBColors.Black;
			this.vassalsCheck.CBLabel.Position = new Point(20, -1);
			this.vassalsCheck.CBLabel.Size = new Size(170, 25);
			this.vassalsCheck.CBLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.vassalsCheck.Data = 7;
			this.vassalsCheck.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.checkToggled));
			this.backgroundImage.addControl(this.vassalsCheck);
			this.religionCheck.CheckedImage = GFXLibrary.reports_checkbox_checked;
			this.religionCheck.UncheckedImage = GFXLibrary.reports_checkbox_empty;
			this.religionCheck.Position = new Point(num4, num2 + num);
			this.religionCheck.Checked = reportFilterList.religion;
			this.religionCheck.CBLabel.Text = SK.Text("ReportFilter_Religion", "Religion");
			this.religionCheck.CBLabel.Color = global::ARGBColors.Black;
			this.religionCheck.CBLabel.Position = new Point(20, -1);
			this.religionCheck.CBLabel.Size = new Size(170, 25);
			this.religionCheck.CBLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.religionCheck.Data = 8;
			this.religionCheck.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.checkToggled));
			this.backgroundImage.addControl(this.religionCheck);
			this.researchCheck.CheckedImage = GFXLibrary.reports_checkbox_checked;
			this.researchCheck.UncheckedImage = GFXLibrary.reports_checkbox_empty;
			this.researchCheck.Position = new Point(num4, num2 + 2 * num);
			this.researchCheck.Checked = reportFilterList.research;
			this.researchCheck.CBLabel.Text = SK.Text("ReportFilter_Research", "Research");
			this.researchCheck.CBLabel.Color = global::ARGBColors.Black;
			this.researchCheck.CBLabel.Position = new Point(20, -1);
			this.researchCheck.CBLabel.Size = new Size(170, 25);
			this.researchCheck.CBLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.researchCheck.Data = 9;
			this.researchCheck.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.checkToggled));
			this.backgroundImage.addControl(this.researchCheck);
			this.electionsCheck.CheckedImage = GFXLibrary.reports_checkbox_checked;
			this.electionsCheck.UncheckedImage = GFXLibrary.reports_checkbox_empty;
			this.electionsCheck.Position = new Point(num4, num2 + 3 * num);
			this.electionsCheck.Checked = reportFilterList.elections;
			this.electionsCheck.CBLabel.Text = SK.Text("ReportFilter_Elections", "Elections");
			this.electionsCheck.CBLabel.Color = global::ARGBColors.Black;
			this.electionsCheck.CBLabel.Position = new Point(20, -1);
			this.electionsCheck.CBLabel.Size = new Size(170, 25);
			this.electionsCheck.CBLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.electionsCheck.Data = 10;
			this.electionsCheck.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.checkToggled));
			this.backgroundImage.addControl(this.electionsCheck);
			this.factionsCheck.CheckedImage = GFXLibrary.reports_checkbox_checked;
			this.factionsCheck.UncheckedImage = GFXLibrary.reports_checkbox_empty;
			this.factionsCheck.Position = new Point(num4, num2 + 4 * num);
			this.factionsCheck.Checked = reportFilterList.factions;
			this.factionsCheck.CBLabel.Text = SK.Text("ReportFilter_Factions", "Factions");
			this.factionsCheck.CBLabel.Color = global::ARGBColors.Black;
			this.factionsCheck.CBLabel.Position = new Point(20, -1);
			this.factionsCheck.CBLabel.Size = new Size(170, 25);
			this.factionsCheck.CBLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.factionsCheck.Data = 11;
			this.factionsCheck.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.checkToggled));
			this.backgroundImage.addControl(this.factionsCheck);
			this.cardsCheck.CheckedImage = GFXLibrary.reports_checkbox_checked;
			this.cardsCheck.UncheckedImage = GFXLibrary.reports_checkbox_empty;
			this.cardsCheck.Position = new Point(num4, num2 + 5 * num);
			this.cardsCheck.Checked = reportFilterList.cards;
			this.cardsCheck.CBLabel.Text = SK.Text("ReportFilter_Cards", "Cards");
			this.cardsCheck.CBLabel.Color = global::ARGBColors.Black;
			this.cardsCheck.CBLabel.Position = new Point(20, -1);
			this.cardsCheck.CBLabel.Size = new Size(170, 25);
			this.cardsCheck.CBLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.cardsCheck.Data = 12;
			this.cardsCheck.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.checkToggled));
			this.backgroundImage.addControl(this.cardsCheck);
			this.achievementsCheck.CheckedImage = GFXLibrary.reports_checkbox_checked;
			this.achievementsCheck.UncheckedImage = GFXLibrary.reports_checkbox_empty;
			this.achievementsCheck.Position = new Point(num4, num2 + 6 * num);
			this.achievementsCheck.Checked = reportFilterList.achievements;
			this.achievementsCheck.CBLabel.Text = SK.Text("GENERIC_Achievements", "Achievements");
			this.achievementsCheck.CBLabel.Color = global::ARGBColors.Black;
			this.achievementsCheck.CBLabel.Position = new Point(20, -1);
			this.achievementsCheck.CBLabel.Size = new Size(170, 25);
			this.achievementsCheck.CBLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.achievementsCheck.Data = 13;
			this.achievementsCheck.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.checkToggled));
			this.backgroundImage.addControl(this.achievementsCheck);
			this.buyVillagesCheck.CheckedImage = GFXLibrary.reports_checkbox_checked;
			this.buyVillagesCheck.UncheckedImage = GFXLibrary.reports_checkbox_empty;
			this.buyVillagesCheck.Position = new Point(num3, num2 + 7 * num);
			this.buyVillagesCheck.Checked = reportFilterList.buyVillages;
			this.buyVillagesCheck.CBLabel.Text = SK.Text("ReportFilter_Village_Charter", "Village Charter");
			this.buyVillagesCheck.CBLabel.Color = global::ARGBColors.Black;
			this.buyVillagesCheck.CBLabel.Position = new Point(20, -1);
			this.buyVillagesCheck.CBLabel.Size = new Size(170, 25);
			if (Program.mySettings.LanguageIdent == "it")
			{
				this.buyVillagesCheck.CBLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
			}
			else
			{
				this.buyVillagesCheck.CBLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			}
			this.buyVillagesCheck.Data = 14;
			this.buyVillagesCheck.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.checkToggled));
			this.backgroundImage.addControl(this.buyVillagesCheck);
			this.questsCheck.CheckedImage = GFXLibrary.reports_checkbox_checked;
			this.questsCheck.UncheckedImage = GFXLibrary.reports_checkbox_empty;
			this.questsCheck.Position = new Point(num4, num2 + 7 * num);
			this.questsCheck.Checked = reportFilterList.quests;
			this.questsCheck.CBLabel.Text = SK.Text("GENERIC_Quests", "Quests");
			this.questsCheck.CBLabel.Color = global::ARGBColors.Black;
			this.questsCheck.CBLabel.Position = new Point(20, -1);
			this.questsCheck.CBLabel.Size = new Size(170, 25);
			this.questsCheck.CBLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.questsCheck.Data = 15;
			this.questsCheck.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.checkToggled));
			this.backgroundImage.addControl(this.questsCheck);
			this.capitalAttackCheck.CheckedImage = GFXLibrary.reports_checkbox_checked;
			this.capitalAttackCheck.UncheckedImage = GFXLibrary.reports_checkbox_empty;
			this.capitalAttackCheck.Position = new Point(num3, num2 + 8 * num);
			this.capitalAttackCheck.Checked = ReportsPanel.Instance.reportsManager.ShowParishAttacks;
			this.capitalAttackCheck.CBLabel.Text = SK.Text("ReportFilter_Capital_Attacks", "Capital Attacks");
			this.capitalAttackCheck.CBLabel.Color = global::ARGBColors.Black;
			this.capitalAttackCheck.CBLabel.Position = new Point(20, -1);
			this.capitalAttackCheck.CBLabel.Size = new Size(170, 25);
			this.capitalAttackCheck.CBLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.capitalAttackCheck.Data = -2;
			this.capitalAttackCheck.Visible = !flag;
			this.capitalAttackCheck.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.checkToggled));
			this.backgroundImage.addControl(this.capitalAttackCheck);
			this.spinsCheck.CheckedImage = GFXLibrary.reports_checkbox_checked;
			this.spinsCheck.UncheckedImage = GFXLibrary.reports_checkbox_empty;
			this.spinsCheck.Position = new Point(num4, num2 + 8 * num);
			this.spinsCheck.Checked = reportFilterList.spins;
			this.spinsCheck.CBLabel.Text = SK.Text("GENERIC_Prizes", "Prizes");
			this.spinsCheck.CBLabel.Color = global::ARGBColors.Black;
			this.spinsCheck.CBLabel.Position = new Point(20, -1);
			this.spinsCheck.CBLabel.Size = new Size(170, 25);
			this.spinsCheck.CBLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.spinsCheck.Data = 16;
			this.spinsCheck.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.checkToggled));
			this.backgroundImage.addControl(this.spinsCheck);
			int num5 = flag ? 8 : 9;
			this.houseCheck.CheckedImage = GFXLibrary.reports_checkbox_checked;
			this.houseCheck.UncheckedImage = GFXLibrary.reports_checkbox_empty;
			this.houseCheck.Position = new Point(num3, num2 + num5 * num);
			this.houseCheck.Checked = reportFilterList.house;
			this.houseCheck.CBLabel.Text = SK.Text("ReportFilter_House", "House");
			this.houseCheck.CBLabel.Color = global::ARGBColors.Black;
			this.houseCheck.CBLabel.Position = new Point(20, -1);
			this.houseCheck.CBLabel.Size = new Size(170, 25);
			this.houseCheck.CBLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.houseCheck.Data = 17;
			this.houseCheck.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.checkToggled));
			this.backgroundImage.addControl(this.houseCheck);
			this.villageLostCheck.CheckedImage = GFXLibrary.reports_checkbox_checked;
			this.villageLostCheck.UncheckedImage = GFXLibrary.reports_checkbox_empty;
			this.villageLostCheck.Position = new Point(num4, num2 + 9 * num);
			this.villageLostCheck.Checked = ReportsPanel.Instance.reportsManager.ShowVillageLost;
			this.villageLostCheck.CBLabel.Text = SK.Text("Reports_VillageLost", "Village Lost");
			this.villageLostCheck.CBLabel.Color = global::ARGBColors.Black;
			this.villageLostCheck.CBLabel.Position = new Point(20, -1);
			this.villageLostCheck.CBLabel.Size = new Size(170, 25);
			this.villageLostCheck.CBLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.villageLostCheck.Data = -4;
			this.villageLostCheck.Visible = !flag;
			this.villageLostCheck.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.checkToggled));
			this.backgroundImage.addControl(this.villageLostCheck);
			CustomSelfDrawPanel.CSDButton csdbutton = new CustomSelfDrawPanel.CSDButton();
			csdbutton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
			csdbutton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
			csdbutton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
			csdbutton.Position = new Point(30, 270);
			csdbutton.Text.Text = SK.Text("ReportFilter_Select_All", "Select All");
			csdbutton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			csdbutton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			csdbutton.TextYOffset = -3;
			csdbutton.Text.Color = global::ARGBColors.Black;
			csdbutton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.selectAllClicked), "ReportCapturePanel_select_all");
			csdbutton.Visible = !flag;
			this.backgroundImage.addControl(csdbutton);
			CustomSelfDrawPanel.CSDButton csdbutton2 = new CustomSelfDrawPanel.CSDButton();
			csdbutton2.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
			csdbutton2.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
			csdbutton2.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
			csdbutton2.Position = new Point(192, 270);
			csdbutton2.Text.Text = SK.Text("ReportFilter_Select_None", "Select None");
			csdbutton2.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			csdbutton2.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			csdbutton2.TextYOffset = -3;
			csdbutton2.Text.Color = global::ARGBColors.Black;
			csdbutton2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.selectNoneClicked), "ReportCapturePanel_select_none");
			csdbutton2.Visible = !flag;
			this.backgroundImage.addControl(csdbutton2);
			this.readMessagesCheck.CheckedImage = GFXLibrary.reports_checkbox_checked;
			this.readMessagesCheck.UncheckedImage = GFXLibrary.reports_checkbox_empty;
			if (Program.mySettings.LanguageIdent == "pl")
			{
				this.readMessagesCheck.Position = new Point(num3 - 20, 330);
			}
			else
			{
				this.readMessagesCheck.Position = new Point(num3, 330);
			}
			this.readMessagesCheck.Checked = ReportsPanel.Instance.reportsManager.ShowReadMessages;
			this.readMessagesCheck.CBLabel.Text = SK.Text("ReportFilter_Show_Read_Messages", "Show Read Messages");
			this.readMessagesCheck.CBLabel.Color = global::ARGBColors.Black;
			if (Program.mySettings.LanguageIdent == "de")
			{
				this.readMessagesCheck.CBLabel.Position = new Point(10, -1);
			}
			else
			{
				this.readMessagesCheck.CBLabel.Position = new Point(20, -1);
			}
			this.readMessagesCheck.CBLabel.Size = new Size(310, 25);
			this.readMessagesCheck.CBLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.readMessagesCheck.Data = -1;
			this.readMessagesCheck.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.checkToggled));
			this.readMessagesCheck.Visible = !flag;
			this.backgroundImage.addControl(this.readMessagesCheck);
			this.forwardedOnlyCheck.CheckedImage = GFXLibrary.reports_checkbox_checked;
			this.forwardedOnlyCheck.UncheckedImage = GFXLibrary.reports_checkbox_empty;
			if (Program.mySettings.LanguageIdent == "pl")
			{
				this.forwardedOnlyCheck.Position = new Point(num3 - 20, 305);
			}
			else
			{
				this.forwardedOnlyCheck.Position = new Point(num3, 305);
			}
			this.forwardedOnlyCheck.Checked = ReportsPanel.Instance.reportsManager.ShowForwardedMessagesOnly;
			this.forwardedOnlyCheck.CBLabel.Text = SK.Text("ReportFilter_Show_Forwarded_Only_Messages", "Show Forwarded Messages Only");
			this.forwardedOnlyCheck.CBLabel.Color = global::ARGBColors.Black;
			this.forwardedOnlyCheck.CBLabel.Position = new Point(20, -1);
			this.forwardedOnlyCheck.CBLabel.Size = new Size(310, 25);
			this.forwardedOnlyCheck.CBLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.forwardedOnlyCheck.Data = -3;
			this.forwardedOnlyCheck.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.checkToggled));
			this.forwardedOnlyCheck.Visible = !flag;
			this.backgroundImage.addControl(this.forwardedOnlyCheck);
			parent.Size = this.backgroundImage.Size;
			base.Invalidate();
			parent.Invalidate();
		}

		// Token: 0x060028E6 RID: 10470 RVA: 0x001F1D28 File Offset: 0x001EFF28
		public void okClicked()
		{
			if (this.m_mode == 1)
			{
				InterfaceMgr.Instance.closeReportCaptureWindow();
				InterfaceMgr.Instance.ParentForm.TopMost = true;
				InterfaceMgr.Instance.ParentForm.TopMost = false;
				return;
			}
			ReportFilterList reportFilters = RemoteServices.Instance.ReportFilters;
			bool flag = false;
			if (reportFilters.attacks != this.attackCheck.Checked)
			{
				flag = true;
				reportFilters.attacks = this.attackCheck.Checked;
			}
			if (reportFilters.defense != this.defenceCheck.Checked)
			{
				flag = true;
				reportFilters.defense = this.defenceCheck.Checked;
			}
			if (reportFilters.vassals != this.vassalsCheck.Checked)
			{
				flag = true;
				reportFilters.vassals = this.vassalsCheck.Checked;
			}
			if (reportFilters.reinforcements != this.reinforceCheck.Checked)
			{
				flag = true;
				reportFilters.reinforcements = this.reinforceCheck.Checked;
			}
			if (reportFilters.research != this.researchCheck.Checked)
			{
				flag = true;
				reportFilters.research = this.researchCheck.Checked;
			}
			if (reportFilters.scouting != this.scoutingCheck.Checked)
			{
				flag = true;
				reportFilters.scouting = this.scoutingCheck.Checked;
			}
			if (reportFilters.foraging != this.foragingCheck.Checked)
			{
				flag = true;
				reportFilters.foraging = this.foragingCheck.Checked;
			}
			if (reportFilters.elections != this.electionsCheck.Checked)
			{
				flag = true;
				reportFilters.elections = this.electionsCheck.Checked;
			}
			if (reportFilters.factions != this.factionsCheck.Checked)
			{
				flag = true;
				reportFilters.factions = this.factionsCheck.Checked;
			}
			if (reportFilters.religion != this.religionCheck.Checked)
			{
				flag = true;
				reportFilters.religion = this.religionCheck.Checked;
			}
			if (reportFilters.trade != this.tradeCheck.Checked)
			{
				flag = true;
				reportFilters.trade = this.tradeCheck.Checked;
			}
			if (reportFilters.cards != this.cardsCheck.Checked)
			{
				flag = true;
				reportFilters.cards = this.cardsCheck.Checked;
			}
			if (reportFilters.achievements != this.achievementsCheck.Checked)
			{
				flag = true;
				reportFilters.achievements = this.achievementsCheck.Checked;
			}
			if (reportFilters.buyVillages != this.buyVillagesCheck.Checked)
			{
				flag = true;
				reportFilters.buyVillages = this.buyVillagesCheck.Checked;
			}
			if (reportFilters.enemyWarnings != this.enemyCheck.Checked)
			{
				flag = true;
				reportFilters.enemyWarnings = this.enemyCheck.Checked;
			}
			if (reportFilters.quests != this.questsCheck.Checked)
			{
				flag = true;
				reportFilters.quests = this.questsCheck.Checked;
			}
			if (reportFilters.spins != this.spinsCheck.Checked)
			{
				flag = true;
				reportFilters.spins = this.spinsCheck.Checked;
			}
			if (reportFilters.house != this.houseCheck.Checked)
			{
				flag = true;
				reportFilters.house = this.houseCheck.Checked;
			}
			if (flag)
			{
				RemoteServices.Instance.UpdateReportFilters(reportFilters);
			}
			InterfaceMgr.Instance.closeReportCaptureWindow();
			InterfaceMgr.Instance.ParentForm.TopMost = true;
			InterfaceMgr.Instance.ParentForm.TopMost = false;
		}

		// Token: 0x060028E7 RID: 10471 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x060028E8 RID: 10472 RVA: 0x001F205C File Offset: 0x001F025C
		public void selectAllClicked()
		{
			if (this.m_mode == 1)
			{
				ReportsPanel.Instance.reportsManager.Filters.attacks = true;
				ReportsPanel.Instance.reportsManager.Filters.defense = true;
				ReportsPanel.Instance.reportsManager.Filters.enemyWarnings = true;
				ReportsPanel.Instance.reportsManager.Filters.reinforcements = true;
				ReportsPanel.Instance.reportsManager.Filters.scouting = true;
				ReportsPanel.Instance.reportsManager.Filters.foraging = true;
				ReportsPanel.Instance.reportsManager.Filters.trade = true;
				ReportsPanel.Instance.reportsManager.Filters.vassals = true;
				ReportsPanel.Instance.reportsManager.Filters.religion = true;
				ReportsPanel.Instance.reportsManager.Filters.research = true;
				ReportsPanel.Instance.reportsManager.Filters.elections = true;
				ReportsPanel.Instance.reportsManager.Filters.factions = true;
				ReportsPanel.Instance.reportsManager.Filters.cards = true;
				ReportsPanel.Instance.reportsManager.Filters.achievements = true;
				ReportsPanel.Instance.reportsManager.Filters.buyVillages = true;
				ReportsPanel.Instance.reportsManager.ShowParishAttacks = true;
				ReportsPanel.Instance.reportsManager.ShowForwardedMessagesOnly = false;
				ReportsPanel.Instance.reportsManager.ShowVillageLost = true;
				ReportsPanel.Instance.reportsManager.Filters.quests = true;
				ReportsPanel.Instance.reportsManager.Filters.spins = true;
				ReportsPanel.Instance.reportsManager.Filters.house = true;
				ReportsPanel.Instance.updateFilters();
				this.attackCheck.Checked = true;
				this.defenceCheck.Checked = true;
				this.enemyCheck.Checked = true;
				this.reinforceCheck.Checked = true;
				this.scoutingCheck.Checked = true;
				this.foragingCheck.Checked = true;
				this.tradeCheck.Checked = true;
				this.vassalsCheck.Checked = true;
				this.religionCheck.Checked = true;
				this.researchCheck.Checked = true;
				this.electionsCheck.Checked = true;
				this.factionsCheck.Checked = true;
				this.cardsCheck.Checked = true;
				this.achievementsCheck.Checked = true;
				this.buyVillagesCheck.Checked = true;
				this.capitalAttackCheck.Checked = true;
				this.forwardedOnlyCheck.Checked = false;
				this.villageLostCheck.Checked = true;
				this.questsCheck.Checked = true;
				this.spinsCheck.Checked = true;
				this.houseCheck.Checked = true;
			}
		}

		// Token: 0x060028E9 RID: 10473 RVA: 0x001F2328 File Offset: 0x001F0528
		public void selectNoneClicked()
		{
			if (this.m_mode == 1)
			{
				ReportsPanel.Instance.reportsManager.Filters.attacks = false;
				ReportsPanel.Instance.reportsManager.Filters.defense = false;
				ReportsPanel.Instance.reportsManager.Filters.enemyWarnings = false;
				ReportsPanel.Instance.reportsManager.Filters.reinforcements = false;
				ReportsPanel.Instance.reportsManager.Filters.scouting = false;
				ReportsPanel.Instance.reportsManager.Filters.foraging = false;
				ReportsPanel.Instance.reportsManager.Filters.trade = false;
				ReportsPanel.Instance.reportsManager.Filters.vassals = false;
				ReportsPanel.Instance.reportsManager.Filters.religion = false;
				ReportsPanel.Instance.reportsManager.Filters.research = false;
				ReportsPanel.Instance.reportsManager.Filters.elections = false;
				ReportsPanel.Instance.reportsManager.Filters.factions = false;
				ReportsPanel.Instance.reportsManager.Filters.cards = false;
				ReportsPanel.Instance.reportsManager.Filters.achievements = false;
				ReportsPanel.Instance.reportsManager.Filters.buyVillages = false;
				ReportsPanel.Instance.reportsManager.ShowParishAttacks = false;
				ReportsPanel.Instance.reportsManager.ShowForwardedMessagesOnly = false;
				ReportsPanel.Instance.reportsManager.ShowVillageLost = false;
				ReportsPanel.Instance.reportsManager.Filters.quests = false;
				ReportsPanel.Instance.reportsManager.Filters.spins = false;
				ReportsPanel.Instance.reportsManager.Filters.house = false;
				ReportsPanel.Instance.updateFilters();
				this.attackCheck.Checked = false;
				this.defenceCheck.Checked = false;
				this.enemyCheck.Checked = false;
				this.reinforceCheck.Checked = false;
				this.scoutingCheck.Checked = false;
				this.foragingCheck.Checked = false;
				this.tradeCheck.Checked = false;
				this.vassalsCheck.Checked = false;
				this.religionCheck.Checked = false;
				this.researchCheck.Checked = false;
				this.electionsCheck.Checked = false;
				this.factionsCheck.Checked = false;
				this.cardsCheck.Checked = false;
				this.achievementsCheck.Checked = false;
				this.buyVillagesCheck.Checked = false;
				this.capitalAttackCheck.Checked = false;
				this.forwardedOnlyCheck.Checked = false;
				this.villageLostCheck.Checked = false;
				this.questsCheck.Checked = false;
				this.spinsCheck.Checked = false;
				this.houseCheck.Checked = false;
			}
		}

		// Token: 0x060028EA RID: 10474 RVA: 0x001F25F4 File Offset: 0x001F07F4
		public void checkToggled()
		{
			if (this.m_mode != 1)
			{
				return;
			}
			CustomSelfDrawPanel.CSDControl clickedControl = this.ClickedControl;
			if (clickedControl != null)
			{
				switch (clickedControl.Data)
				{
				case -4:
					ReportsPanel.Instance.reportsManager.ShowVillageLost = !ReportsPanel.Instance.reportsManager.ShowVillageLost;
					ReportsPanel.Instance.updateFilters();
					return;
				case -3:
					ReportsPanel.Instance.reportsManager.ShowForwardedMessagesOnly = !ReportsPanel.Instance.reportsManager.ShowForwardedMessagesOnly;
					ReportsPanel.Instance.updateFilters();
					return;
				case -2:
					ReportsPanel.Instance.reportsManager.ShowParishAttacks = !ReportsPanel.Instance.reportsManager.ShowParishAttacks;
					ReportsPanel.Instance.updateFilters();
					return;
				case -1:
					ReportsPanel.Instance.reportsManager.ShowReadMessages = !ReportsPanel.Instance.reportsManager.ShowReadMessages;
					ReportsPanel.Instance.updateFilters();
					return;
				case 0:
					ReportsPanel.Instance.reportsManager.Filters.attacks = this.attackCheck.Checked;
					ReportsPanel.Instance.updateFilters();
					return;
				case 1:
					ReportsPanel.Instance.reportsManager.Filters.defense = this.defenceCheck.Checked;
					ReportsPanel.Instance.updateFilters();
					return;
				case 2:
					ReportsPanel.Instance.reportsManager.Filters.enemyWarnings = this.enemyCheck.Checked;
					ReportsPanel.Instance.updateFilters();
					return;
				case 3:
					ReportsPanel.Instance.reportsManager.Filters.reinforcements = this.reinforceCheck.Checked;
					ReportsPanel.Instance.updateFilters();
					return;
				case 4:
					ReportsPanel.Instance.reportsManager.Filters.scouting = this.scoutingCheck.Checked;
					ReportsPanel.Instance.updateFilters();
					return;
				case 5:
					ReportsPanel.Instance.reportsManager.Filters.foraging = this.foragingCheck.Checked;
					ReportsPanel.Instance.updateFilters();
					return;
				case 6:
					ReportsPanel.Instance.reportsManager.Filters.trade = this.tradeCheck.Checked;
					ReportsPanel.Instance.updateFilters();
					return;
				case 7:
					ReportsPanel.Instance.reportsManager.Filters.vassals = this.vassalsCheck.Checked;
					ReportsPanel.Instance.updateFilters();
					return;
				case 8:
					ReportsPanel.Instance.reportsManager.Filters.religion = this.religionCheck.Checked;
					ReportsPanel.Instance.updateFilters();
					return;
				case 9:
					ReportsPanel.Instance.reportsManager.Filters.research = this.researchCheck.Checked;
					ReportsPanel.Instance.updateFilters();
					return;
				case 10:
					ReportsPanel.Instance.reportsManager.Filters.elections = this.electionsCheck.Checked;
					ReportsPanel.Instance.updateFilters();
					return;
				case 11:
					ReportsPanel.Instance.reportsManager.Filters.factions = this.factionsCheck.Checked;
					ReportsPanel.Instance.updateFilters();
					return;
				case 12:
					ReportsPanel.Instance.reportsManager.Filters.cards = this.cardsCheck.Checked;
					ReportsPanel.Instance.updateFilters();
					return;
				case 13:
					ReportsPanel.Instance.reportsManager.Filters.achievements = this.achievementsCheck.Checked;
					ReportsPanel.Instance.updateFilters();
					return;
				case 14:
					ReportsPanel.Instance.reportsManager.Filters.buyVillages = this.buyVillagesCheck.Checked;
					ReportsPanel.Instance.updateFilters();
					return;
				case 15:
					ReportsPanel.Instance.reportsManager.Filters.quests = this.questsCheck.Checked;
					ReportsPanel.Instance.updateFilters();
					return;
				case 16:
					ReportsPanel.Instance.reportsManager.Filters.spins = this.spinsCheck.Checked;
					ReportsPanel.Instance.updateFilters();
					return;
				case 17:
					ReportsPanel.Instance.reportsManager.Filters.house = this.houseCheck.Checked;
					ReportsPanel.Instance.updateFilters();
					break;
				default:
					return;
				}
			}
		}

		// Token: 0x040031FB RID: 12795
		private IContainer components;

		// Token: 0x040031FC RID: 12796
		private CustomSelfDrawPanel.CSDLabel captureLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040031FD RID: 12797
		private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040031FE RID: 12798
		private CustomSelfDrawPanel.CSDButton okButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040031FF RID: 12799
		private CustomSelfDrawPanel.CSDButton cancelButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003200 RID: 12800
		private CustomSelfDrawPanel.CSDCheckBox attackCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x04003201 RID: 12801
		private CustomSelfDrawPanel.CSDCheckBox defenceCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x04003202 RID: 12802
		private CustomSelfDrawPanel.CSDCheckBox enemyCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x04003203 RID: 12803
		private CustomSelfDrawPanel.CSDCheckBox reinforceCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x04003204 RID: 12804
		private CustomSelfDrawPanel.CSDCheckBox scoutingCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x04003205 RID: 12805
		private CustomSelfDrawPanel.CSDCheckBox foragingCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x04003206 RID: 12806
		private CustomSelfDrawPanel.CSDCheckBox tradeCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x04003207 RID: 12807
		private CustomSelfDrawPanel.CSDCheckBox vassalsCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x04003208 RID: 12808
		private CustomSelfDrawPanel.CSDCheckBox religionCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x04003209 RID: 12809
		private CustomSelfDrawPanel.CSDCheckBox researchCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x0400320A RID: 12810
		private CustomSelfDrawPanel.CSDCheckBox electionsCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x0400320B RID: 12811
		private CustomSelfDrawPanel.CSDCheckBox factionsCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x0400320C RID: 12812
		private CustomSelfDrawPanel.CSDCheckBox houseCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x0400320D RID: 12813
		private CustomSelfDrawPanel.CSDCheckBox cardsCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x0400320E RID: 12814
		private CustomSelfDrawPanel.CSDCheckBox achievementsCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x0400320F RID: 12815
		private CustomSelfDrawPanel.CSDCheckBox buyVillagesCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x04003210 RID: 12816
		private CustomSelfDrawPanel.CSDCheckBox questsCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x04003211 RID: 12817
		private CustomSelfDrawPanel.CSDCheckBox spinsCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x04003212 RID: 12818
		private CustomSelfDrawPanel.CSDCheckBox readMessagesCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x04003213 RID: 12819
		private CustomSelfDrawPanel.CSDCheckBox forwardedOnlyCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x04003214 RID: 12820
		private CustomSelfDrawPanel.CSDCheckBox capitalAttackCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x04003215 RID: 12821
		private CustomSelfDrawPanel.CSDCheckBox villageLostCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x04003216 RID: 12822
		private int m_mode;

		// Token: 0x04003217 RID: 12823
		[CompilerGenerated]
		private static CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate _003C_003E9__CachedAnonymousMethodDelegate1;
	}
}
