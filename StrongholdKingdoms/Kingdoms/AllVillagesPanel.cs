using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020000CC RID: 204
	public class AllVillagesPanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x060005B0 RID: 1456 RVA: 0x0000B014 File Offset: 0x00009214
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x0000B024 File Offset: 0x00009224
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x0000B034 File Offset: 0x00009234
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x060005B3 RID: 1459 RVA: 0x0000B046 File Offset: 0x00009246
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x060005B4 RID: 1460 RVA: 0x0000B053 File Offset: 0x00009253
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closing();
		}

		// Token: 0x060005B5 RID: 1461 RVA: 0x0000B06D File Offset: 0x0000926D
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x060005B6 RID: 1462 RVA: 0x0000B07A File Offset: 0x0000927A
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x060005B7 RID: 1463 RVA: 0x0000B087 File Offset: 0x00009287
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060005B8 RID: 1464 RVA: 0x0006E70C File Offset: 0x0006C90C
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.MaximumSize = new Size(992, 10000);
			this.MinimumSize = new Size(992, 566);
			base.Name = "AllVillagesPanel";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x060005B9 RID: 1465 RVA: 0x0006E778 File Offset: 0x0006C978
		public AllVillagesPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x0006E984 File Offset: 0x0006CB84
		public void init(bool resized)
		{
			int height = base.Height;
			AllVillagesPanel.instance = this;
			base.clearControls();
			if (!resized)
			{
				this.pageMode = 0;
			}
			this.mainBackgroundImage.FillColor = Color.FromArgb(134, 153, 165);
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = new Size(base.Width, height);
			base.addControl(this.mainBackgroundImage);
			this.backgroundFade.Image = GFXLibrary.background_top;
			this.backgroundFade.Position = new Point(0, 0);
			this.backgroundFade.Size = new Size(base.Width, this.backgroundFade.Image.Height);
			this.mainBackgroundImage.addControl(this.backgroundFade);
			this.titleLabel.Text = SK.Text("AllVillages_village_overview", "Villages Overview");
			this.titleLabel.Color = global::ARGBColors.Black;
			this.titleLabel.Position = new Point(5, 5);
			this.titleLabel.Size = new Size(323, 30);
			this.titleLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.titleLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainBackgroundImage.addControl(this.titleLabel);
			CustomSelfDrawPanel.WikiLinkControl.init(this.mainBackgroundImage, 43, new Point(base.Width - 44, 3));
			this.borderImage.Size = new Size(970, height - 38 - 7);
			this.borderImage.Position = new Point(10, 38);
			this.mainBackgroundImage.addControl(this.borderImage);
			this.borderImage.Create(GFXLibrary.parishwall_village_center_tab_outline_top_left, GFXLibrary.parishwall_village_center_tab_outline_top_middle, GFXLibrary.parishwall_village_center_tab_outline_top_right, GFXLibrary.parishwall_village_center_tab_outline_middle_left, null, GFXLibrary.parishwall_village_center_tab_outline_middle_right, GFXLibrary.parishwall_village_center_tab_outline_bottom_left, GFXLibrary.parishwall_village_center_tab_outline_bottom_middle, GFXLibrary.parishwall_village_center_tab_outline_bottom_right);
			int num = 135;
			this.tabBtnAll.ImageNorm = GFXLibrary.villageOverTab_down;
			this.tabBtnAll.ImageOver = GFXLibrary.villageOverTab_down;
			this.tabBtnAll.ImageClick = GFXLibrary.villageOverTab_down;
			this.tabBtnAll.Position = new Point(235 + num, 12);
			this.tabBtnAll.Text.Text = SK.Text("ALLVillages_Overview_Alt", "Overview");
			this.tabBtnAll.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.tabBtnAll.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.tabBtnAll.TextYOffset = 0;
			this.tabBtnAll.Text.Color = global::ARGBColors.Black;
			this.tabBtnAll.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tabAllClicked));
			this.tabBtnAll.Active = true;
			this.mainBackgroundImage.addControl(this.tabBtnAll);
			this.tabBtnTroops.ImageNorm = GFXLibrary.villageOverTab_down;
			this.tabBtnTroops.ImageOver = GFXLibrary.villageOverTab_down;
			this.tabBtnTroops.ImageClick = GFXLibrary.villageOverTab_down;
			this.tabBtnTroops.Position = new Point(370 + num, 12);
			this.tabBtnTroops.Text.Text = SK.Text("SelectArmyPanel_Troops", "Troops");
			this.tabBtnTroops.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.tabBtnTroops.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.tabBtnTroops.TextYOffset = 0;
			this.tabBtnTroops.Text.Color = global::ARGBColors.Black;
			this.tabBtnTroops.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tabTroopsClicked));
			this.tabBtnTroops.Active = true;
			this.mainBackgroundImage.addControl(this.tabBtnTroops);
			this.tabBtnUnits.ImageNorm = GFXLibrary.villageOverTab_down;
			this.tabBtnUnits.ImageOver = GFXLibrary.villageOverTab_down;
			this.tabBtnUnits.ImageClick = GFXLibrary.villageOverTab_down;
			this.tabBtnUnits.Position = new Point(505 + num, 12);
			this.tabBtnUnits.Text.Text = SK.Text("UnitsPanel_Units", "Units");
			this.tabBtnUnits.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.tabBtnUnits.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.tabBtnUnits.TextYOffset = 0;
			this.tabBtnUnits.Text.Color = global::ARGBColors.Black;
			this.tabBtnUnits.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tabUnitsClicked));
			this.tabBtnUnits.Active = true;
			this.mainBackgroundImage.addControl(this.tabBtnUnits);
			this.tabBtnVillage.ImageNorm = GFXLibrary.villageOverTab_down;
			this.tabBtnVillage.ImageOver = GFXLibrary.villageOverTab_down;
			this.tabBtnVillage.ImageClick = GFXLibrary.villageOverTab_down;
			this.tabBtnVillage.Position = new Point(640 + num, 12);
			this.tabBtnVillage.Text.Text = SK.Text("GENERIC_Village", "Village");
			this.tabBtnVillage.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.tabBtnVillage.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.tabBtnVillage.TextYOffset = 0;
			this.tabBtnVillage.Text.Color = global::ARGBColors.Black;
			this.tabBtnVillage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tabVillageClicked));
			this.tabBtnVillage.Active = true;
			this.mainBackgroundImage.addControl(this.tabBtnVillage);
			this.headerLabelsImage.Size = new Size(base.Width - 25 - 23, -19);
			this.headerLabelsImage.Position = new Point(25, 56);
			this.mainBackgroundImage.addControl(this.headerLabelsImage);
			this.headerLabelsImage.Create(GFXLibrary.mail2_field_bar_mail_left, GFXLibrary.mail2_field_bar_mail_middle, GFXLibrary.mail2_field_bar_mail_right);
			this.divider1Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
			this.divider1Image.Position = new Point(290, 0);
			this.headerLabelsImage.addControl(this.divider1Image);
			this.villageLabel.Text = SK.Text("GENERIC_Village", "Village");
			this.villageLabel.Color = global::ARGBColors.Black;
			this.villageLabel.Position = new Point(15, -3);
			this.villageLabel.Size = new Size(323, this.headerLabelsImage.Height);
			this.villageLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.villageLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.villageLabel);
			if (this.pageMode == 0)
			{
				this.tabBtnAll.Active = false;
				this.tabBtnAll.ImageNorm = GFXLibrary.villageOverTab_up;
				this.tabBtnAll.ImageOver = GFXLibrary.villageOverTab_up;
				this.tabBtnAll.ImageClick = GFXLibrary.villageOverTab_up;
				this.tabBtnAll.TextYOffset = -3;
				this.divider2Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
				this.divider2Image.Position = new Point(375, 0);
				this.headerLabelsImage.addControl(this.divider2Image);
				this.divider3Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
				this.divider3Image.Position = new Point(460, 0);
				this.headerLabelsImage.addControl(this.divider3Image);
				this.divider4Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
				this.divider4Image.Position = new Point(545, 0);
				this.headerLabelsImage.addControl(this.divider4Image);
				this.divider5Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
				this.divider5Image.Position = new Point(630, 0);
				this.headerLabelsImage.addControl(this.divider5Image);
				this.divider6Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
				this.divider6Image.Position = new Point(715, 0);
				this.headerLabelsImage.addControl(this.divider6Image);
				this.divider7Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
				this.divider7Image.Position = new Point(800, 0);
				this.headerLabelsImage.addControl(this.divider7Image);
				this.headerImage1.Image = GFXLibrary.villageOverviewIcons[0];
				this.headerImage1.Position = new Point(290, -17);
				this.headerLabelsImage.addControl(this.headerImage1);
				this.headerImage2.Image = GFXLibrary.villageOverviewIcons[7];
				this.headerImage2.Position = new Point(375, -17);
				this.headerLabelsImage.addControl(this.headerImage2);
				this.headerImage3.Image = GFXLibrary.villageOverviewIcons[8];
				this.headerImage3.Position = new Point(460, -17);
				this.headerLabelsImage.addControl(this.headerImage3);
				this.headerImage4.Image = GFXLibrary.villageOverviewIcons[6];
				this.headerImage4.Position = new Point(545, -17);
				this.headerLabelsImage.addControl(this.headerImage4);
				this.headerImage5.Image = GFXLibrary.villageOverviewIcons[18];
				this.headerImage5.Position = new Point(630, -17);
				this.headerLabelsImage.addControl(this.headerImage5);
				this.headerImage6.Image = GFXLibrary.villageOverviewIcons[9];
				this.headerImage6.Position = new Point(715, -17);
				this.headerLabelsImage.addControl(this.headerImage6);
				this.rolloverArea1.Position = this.divider1Image.Position;
				this.rolloverArea1.Size = new Size(this.divider2Image.Position.X - this.divider1Image.Position.X, this.headerLabelsImage.Size.Height);
				this.rolloverArea1.CustomTooltipID = 4100;
				this.headerLabelsImage.addControl(this.rolloverArea1);
				this.rolloverArea2.Position = this.divider2Image.Position;
				this.rolloverArea2.Size = new Size(this.divider3Image.Position.X - this.divider2Image.Position.X, this.headerLabelsImage.Size.Height);
				this.rolloverArea2.CustomTooltipID = 4101;
				this.headerLabelsImage.addControl(this.rolloverArea2);
				this.rolloverArea3.Position = this.divider3Image.Position;
				this.rolloverArea3.Size = new Size(this.divider4Image.Position.X - this.divider3Image.Position.X, this.headerLabelsImage.Size.Height);
				this.rolloverArea3.CustomTooltipID = 4102;
				this.headerLabelsImage.addControl(this.rolloverArea3);
				this.rolloverArea4.Position = this.divider4Image.Position;
				this.rolloverArea4.Size = new Size(this.divider5Image.Position.X - this.divider4Image.Position.X, this.headerLabelsImage.Size.Height);
				this.rolloverArea4.CustomTooltipID = 4103;
				this.headerLabelsImage.addControl(this.rolloverArea4);
				this.rolloverArea5.Position = this.divider5Image.Position;
				this.rolloverArea5.Size = new Size(this.divider6Image.Position.X - this.divider5Image.Position.X, this.headerLabelsImage.Size.Height);
				this.rolloverArea5.CustomTooltipID = 4104;
				this.headerLabelsImage.addControl(this.rolloverArea5);
				this.rolloverArea6.Position = this.divider6Image.Position;
				this.rolloverArea6.Size = new Size(this.divider7Image.Position.X - this.divider6Image.Position.X, this.headerLabelsImage.Size.Height);
				this.rolloverArea6.CustomTooltipID = 4105;
				this.headerLabelsImage.addControl(this.rolloverArea6);
			}
			else if (this.pageMode == 1)
			{
				this.tabBtnTroops.Active = false;
				this.tabBtnTroops.ImageNorm = GFXLibrary.villageOverTab_up;
				this.tabBtnTroops.ImageOver = GFXLibrary.villageOverTab_up;
				this.tabBtnTroops.ImageClick = GFXLibrary.villageOverTab_up;
				this.tabBtnTroops.TextYOffset = -3;
				this.divider2Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
				this.divider2Image.Position = new Point(375, 0);
				this.headerLabelsImage.addControl(this.divider2Image);
				this.divider3Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
				this.divider3Image.Position = new Point(460, 0);
				this.headerLabelsImage.addControl(this.divider3Image);
				this.divider4Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
				this.divider4Image.Position = new Point(545, 0);
				this.headerLabelsImage.addControl(this.divider4Image);
				this.divider5Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
				this.divider5Image.Position = new Point(630, 0);
				this.headerLabelsImage.addControl(this.divider5Image);
				this.divider6Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
				this.divider6Image.Position = new Point(715, 0);
				this.headerLabelsImage.addControl(this.divider6Image);
				this.headerImage1.Image = GFXLibrary.villageOverviewIcons[0];
				this.headerImage1.Position = new Point(290, -17);
				this.headerLabelsImage.addControl(this.headerImage1);
				this.headerImage2.Image = GFXLibrary.villageOverviewIcons[1];
				this.headerImage2.Position = new Point(375, -17);
				this.headerLabelsImage.addControl(this.headerImage2);
				this.headerImage3.Image = GFXLibrary.villageOverviewIcons[2];
				this.headerImage3.Position = new Point(460, -17);
				this.headerLabelsImage.addControl(this.headerImage3);
				this.headerImage4.Image = GFXLibrary.villageOverviewIcons[3];
				this.headerImage4.Position = new Point(545, -17);
				this.headerLabelsImage.addControl(this.headerImage4);
				this.headerImage5.Image = GFXLibrary.villageOverviewIcons[5];
				this.headerImage5.Position = new Point(630, -17);
				this.headerLabelsImage.addControl(this.headerImage5);
				this.headerImage6.Image = GFXLibrary.villageOverviewIcons[4];
				this.headerImage6.Position = new Point(715, -17);
				this.headerLabelsImage.addControl(this.headerImage6);
				this.rolloverArea1.Position = this.divider1Image.Position;
				this.rolloverArea1.Size = new Size(this.divider2Image.Position.X - this.divider1Image.Position.X, this.headerLabelsImage.Size.Height);
				this.rolloverArea1.CustomTooltipID = 4108;
				this.headerLabelsImage.addControl(this.rolloverArea1);
				this.rolloverArea2.Position = this.divider2Image.Position;
				this.rolloverArea2.Size = new Size(this.divider3Image.Position.X - this.divider2Image.Position.X, this.headerLabelsImage.Size.Height);
				this.rolloverArea2.CustomTooltipID = 4109;
				this.headerLabelsImage.addControl(this.rolloverArea2);
				this.rolloverArea3.Position = this.divider3Image.Position;
				this.rolloverArea3.Size = new Size(this.divider4Image.Position.X - this.divider3Image.Position.X, this.headerLabelsImage.Size.Height);
				this.rolloverArea3.CustomTooltipID = 4110;
				this.headerLabelsImage.addControl(this.rolloverArea3);
				this.rolloverArea4.Position = this.divider4Image.Position;
				this.rolloverArea4.Size = new Size(this.divider5Image.Position.X - this.divider4Image.Position.X, this.headerLabelsImage.Size.Height);
				this.rolloverArea4.CustomTooltipID = 4111;
				this.headerLabelsImage.addControl(this.rolloverArea4);
				this.rolloverArea5.Position = this.divider5Image.Position;
				this.rolloverArea5.Size = new Size(this.divider6Image.Position.X - this.divider5Image.Position.X, this.headerLabelsImage.Size.Height);
				this.rolloverArea5.CustomTooltipID = 4112;
				this.headerLabelsImage.addControl(this.rolloverArea5);
				this.rolloverArea6.Position = this.divider6Image.Position;
				this.rolloverArea6.Size = this.rolloverArea1.Size;
				this.rolloverArea6.CustomTooltipID = 4113;
				this.headerLabelsImage.addControl(this.rolloverArea6);
			}
			else if (this.pageMode == 2)
			{
				this.tabBtnUnits.Active = false;
				this.tabBtnUnits.ImageNorm = GFXLibrary.villageOverTab_up;
				this.tabBtnUnits.ImageOver = GFXLibrary.villageOverTab_up;
				this.tabBtnUnits.ImageClick = GFXLibrary.villageOverTab_up;
				this.tabBtnUnits.TextYOffset = -3;
				this.divider3Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
				this.divider3Image.Position = new Point(460, 0);
				this.headerLabelsImage.addControl(this.divider3Image);
				this.divider5Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
				this.divider5Image.Position = new Point(630, 0);
				this.headerLabelsImage.addControl(this.divider5Image);
				this.headerImage1.Image = GFXLibrary.villageOverviewIcons[7];
				this.headerImage1.Position = new Point(330, -17);
				this.headerLabelsImage.addControl(this.headerImage1);
				this.headerImage2.Image = GFXLibrary.villageOverviewIcons[8];
				this.headerImage2.Position = new Point(500, -17);
				this.headerLabelsImage.addControl(this.headerImage2);
				this.headerImage3.Image = GFXLibrary.villageOverviewIcons[6];
				this.headerImage3.Position = new Point(670, -17);
				this.headerLabelsImage.addControl(this.headerImage3);
				this.rolloverArea1.Position = this.divider1Image.Position;
				this.rolloverArea1.Size = new Size(this.divider3Image.Position.X - this.divider1Image.Position.X, this.headerLabelsImage.Size.Height);
				this.rolloverArea1.CustomTooltipID = 4116;
				this.headerLabelsImage.addControl(this.rolloverArea1);
				this.rolloverArea2.Position = this.divider3Image.Position;
				this.rolloverArea2.Size = new Size(this.divider5Image.Position.X - this.divider3Image.Position.X, this.headerLabelsImage.Size.Height);
				this.rolloverArea2.CustomTooltipID = 4117;
				this.headerLabelsImage.addControl(this.rolloverArea2);
				this.rolloverArea3.Position = this.divider5Image.Position;
				this.rolloverArea3.Size = new Size(840 - this.divider5Image.Position.X, this.headerLabelsImage.Size.Height);
				this.rolloverArea3.CustomTooltipID = 4118;
				this.headerLabelsImage.addControl(this.rolloverArea3);
			}
			else if (this.pageMode == 3)
			{
				this.tabBtnVillage.Active = false;
				this.tabBtnVillage.ImageNorm = GFXLibrary.villageOverTab_up;
				this.tabBtnVillage.ImageOver = GFXLibrary.villageOverTab_up;
				this.tabBtnVillage.ImageClick = GFXLibrary.villageOverTab_up;
				this.tabBtnVillage.TextYOffset = -3;
				this.divider2Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
				this.divider2Image.Position = new Point(375, 0);
				this.headerLabelsImage.addControl(this.divider2Image);
				this.divider3Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
				this.divider3Image.Position = new Point(460, 0);
				this.headerLabelsImage.addControl(this.divider3Image);
				this.divider4Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
				this.divider4Image.Position = new Point(545, 0);
				this.headerLabelsImage.addControl(this.divider4Image);
				this.divider5Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
				this.divider5Image.Position = new Point(650, 0);
				this.headerLabelsImage.addControl(this.divider5Image);
				this.divider6Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
				this.divider6Image.Position = new Point(735, 0);
				this.headerLabelsImage.addControl(this.divider6Image);
				this.divider7Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
				this.divider7Image.Position = new Point(820, 0);
				this.headerLabelsImage.addControl(this.divider7Image);
				this.headerImage1.Image = GFXLibrary.villageOverviewIcons[13];
				this.headerImage1.Position = new Point(290, -17);
				this.headerLabelsImage.addControl(this.headerImage1);
				this.headerImage2.Image = GFXLibrary.villageOverviewIcons[12];
				this.headerImage2.Position = new Point(375, -17);
				this.headerLabelsImage.addControl(this.headerImage2);
				this.headerImage3.Image = GFXLibrary.villageOverviewIcons[14];
				this.headerImage3.Position = new Point(460, -17);
				this.headerLabelsImage.addControl(this.headerImage3);
				this.headerImage4.Image = GFXLibrary.villageOverviewIcons[15];
				this.headerImage4.Position = new Point(555, -17);
				this.headerLabelsImage.addControl(this.headerImage4);
				this.headerImage5.Image = GFXLibrary.villageOverviewIcons[18];
				this.headerImage5.Position = new Point(650, -17);
				this.headerLabelsImage.addControl(this.headerImage5);
				this.headerImage6.Image = GFXLibrary.villageOverviewIcons[9];
				this.headerImage6.Position = new Point(735, -17);
				this.headerLabelsImage.addControl(this.headerImage6);
				this.rolloverArea1.Position = this.divider1Image.Position;
				this.rolloverArea1.Size = new Size(this.divider2Image.Position.X - this.divider1Image.Position.X, this.headerLabelsImage.Size.Height);
				this.rolloverArea1.CustomTooltipID = 4119;
				this.headerLabelsImage.addControl(this.rolloverArea1);
				this.rolloverArea2.Position = this.divider2Image.Position;
				this.rolloverArea2.Size = new Size(this.divider3Image.Position.X - this.divider2Image.Position.X, this.headerLabelsImage.Size.Height);
				this.rolloverArea2.CustomTooltipID = 4120;
				this.headerLabelsImage.addControl(this.rolloverArea2);
				this.rolloverArea3.Position = this.divider3Image.Position;
				this.rolloverArea3.Size = new Size(this.divider4Image.Position.X - this.divider3Image.Position.X, this.headerLabelsImage.Size.Height);
				this.rolloverArea3.CustomTooltipID = 4121;
				this.headerLabelsImage.addControl(this.rolloverArea3);
				this.rolloverArea4.Position = this.divider4Image.Position;
				this.rolloverArea4.Size = new Size(this.divider5Image.Position.X - this.divider4Image.Position.X, this.headerLabelsImage.Size.Height);
				this.rolloverArea4.CustomTooltipID = 4122;
				this.headerLabelsImage.addControl(this.rolloverArea4);
				this.rolloverArea5.Position = this.divider5Image.Position;
				this.rolloverArea5.Size = new Size(this.divider6Image.Position.X - this.divider5Image.Position.X, this.headerLabelsImage.Size.Height);
				this.rolloverArea5.CustomTooltipID = 4104;
				this.headerLabelsImage.addControl(this.rolloverArea5);
				this.rolloverArea6.Position = this.divider6Image.Position;
				this.rolloverArea6.Size = new Size(this.divider7Image.Position.X - this.divider6Image.Position.X, this.headerLabelsImage.Size.Height);
				this.rolloverArea6.CustomTooltipID = 4105;
				this.headerLabelsImage.addControl(this.rolloverArea6);
			}
			else if (this.pageMode == 4)
			{
				this.tabBtnResrouce.Active = false;
				this.tabBtnResrouce.ImageNorm = GFXLibrary.villageOverTab_up;
				this.tabBtnResrouce.ImageOver = GFXLibrary.villageOverTab_up;
				this.tabBtnResrouce.ImageClick = GFXLibrary.villageOverTab_up;
				this.tabBtnResrouce.TextYOffset = -3;
				this.divider2Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
				this.divider2Image.Position = new Point(375, 0);
				this.headerLabelsImage.addControl(this.divider2Image);
				this.divider3Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
				this.divider3Image.Position = new Point(460, 0);
				this.headerLabelsImage.addControl(this.divider3Image);
				this.divider4Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
				this.divider4Image.Position = new Point(545, 0);
				this.headerLabelsImage.addControl(this.divider4Image);
				this.divider5Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
				this.divider5Image.Position = new Point(650, 0);
				this.headerLabelsImage.addControl(this.divider5Image);
				this.divider6Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
				this.divider6Image.Position = new Point(735, 0);
				this.headerLabelsImage.addControl(this.divider6Image);
				this.divider7Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
				this.divider7Image.Position = new Point(820, 0);
				this.headerLabelsImage.addControl(this.divider7Image);
				this.headerImage1.Image = GFXLibrary.donate_type_food;
				this.headerImage1.setSizeToImage();
				this.headerImage1.Position = new Point(this.divider1Image.X + (this.divider2Image.X - this.divider1Image.X) / 2 - this.headerImage1.Width / 2, -20);
				this.headerLabelsImage.addControl(this.headerImage1);
				this.headerImage2.Image = GFXLibrary.com_32_ale_DS;
				this.headerImage2.setSizeToImage();
				this.headerImage2.Position = new Point(this.divider2Image.X + (this.divider3Image.X - this.divider2Image.X) / 2 - this.headerImage2.Width / 2, -8);
				this.headerLabelsImage.addControl(this.headerImage2);
				this.headerImage3.Image = GFXLibrary.com_32_wood_DS;
				this.headerImage3.setSizeToImage();
				this.headerImage3.Position = new Point(this.divider3Image.X + (this.divider4Image.X - this.divider3Image.X) / 2 - this.headerImage3.Width / 2, -8);
				this.headerLabelsImage.addControl(this.headerImage3);
				this.headerImage4.Image = GFXLibrary.com_32_stone_DS;
				this.headerImage4.setSizeToImage();
				this.headerImage4.Position = new Point(this.divider4Image.X + (this.divider5Image.X - this.divider4Image.X) / 2 - this.headerImage4.Width / 2, -8);
				this.headerLabelsImage.addControl(this.headerImage4);
				this.headerImage5.Image = GFXLibrary.com_32_iron_DS;
				this.headerImage5.setSizeToImage();
				this.headerImage5.Position = new Point(this.divider5Image.X + (this.divider6Image.X - this.divider5Image.X) / 2 - this.headerImage5.Width / 2, -8);
				this.headerLabelsImage.addControl(this.headerImage5);
				this.headerImage6.Image = GFXLibrary.com_32_pitch_DS;
				this.headerImage6.setSizeToImage();
				this.headerImage6.Position = new Point(this.divider6Image.X + (this.divider7Image.X - this.divider6Image.X) / 2 - this.headerImage6.Width / 2, -8);
				this.headerLabelsImage.addControl(this.headerImage6);
				this.rolloverArea1.Position = this.divider1Image.Position;
				this.rolloverArea1.Size = new Size(this.divider2Image.Position.X - this.divider1Image.Position.X, this.headerLabelsImage.Size.Height);
				this.rolloverArea1.CustomTooltipID = 144;
				this.headerLabelsImage.addControl(this.rolloverArea1);
				this.rolloverArea2.Position = this.divider2Image.Position;
				this.rolloverArea2.Size = new Size(this.divider3Image.Position.X - this.divider2Image.Position.X, this.headerLabelsImage.Size.Height);
				this.rolloverArea2.CustomTooltipID = 4121;
				this.headerLabelsImage.addControl(this.rolloverArea2);
				this.rolloverArea3.Position = this.divider3Image.Position;
				this.rolloverArea3.Size = new Size(this.divider4Image.Position.X - this.divider3Image.Position.X, this.headerLabelsImage.Size.Height);
				this.rolloverArea3.CustomTooltipID = 142;
				this.headerLabelsImage.addControl(this.rolloverArea3);
				this.rolloverArea4.Position = this.divider4Image.Position;
				this.rolloverArea4.Size = new Size(this.divider5Image.Position.X - this.divider4Image.Position.X, this.headerLabelsImage.Size.Height);
				this.rolloverArea4.CustomTooltipID = 143;
				this.headerLabelsImage.addControl(this.rolloverArea4);
				this.rolloverArea5.Position = this.divider5Image.Position;
				this.rolloverArea5.Size = new Size(this.divider6Image.Position.X - this.divider5Image.Position.X, this.headerLabelsImage.Size.Height);
				this.rolloverArea5.CustomTooltipID = 4127;
				this.headerLabelsImage.addControl(this.rolloverArea5);
				this.rolloverArea6.Position = this.divider6Image.Position;
				this.rolloverArea6.Size = new Size(this.divider7Image.Position.X - this.divider6Image.Position.X, this.headerLabelsImage.Size.Height);
				this.rolloverArea6.CustomTooltipID = 4128;
				this.headerLabelsImage.addControl(this.rolloverArea6);
			}
			this.wallScrollArea.Position = new Point(25, 85);
			this.wallScrollArea.Size = new Size(906, height - 85 - 9);
			this.wallScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(905, height - 85 - 10));
			this.mainBackgroundImage.addControl(this.wallScrollArea);
			this.mouseWheelOverlay.Position = this.wallScrollArea.Position;
			this.mouseWheelOverlay.Size = this.wallScrollArea.Size;
			this.mouseWheelOverlay.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mouseWheelMoved));
			this.mainBackgroundImage.addControl(this.mouseWheelOverlay);
			int value = this.wallScrollBar.Value;
			this.wallScrollBar.Position = new Point(933, 85);
			this.wallScrollBar.Size = new Size(24, height - 85 - 9);
			this.mainBackgroundImage.addControl(this.wallScrollBar);
			this.wallScrollBar.Value = 0;
			this.wallScrollBar.Max = 100;
			this.wallScrollBar.NumVisibleLines = 25;
			this.wallScrollBar.Create(null, null, null, GFXLibrary._24wide_thumb_top, GFXLibrary._24wide_thumb_middle, GFXLibrary._24wide_thumb_bottom);
			this.wallScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.wallScrollBarMoved));
			if (!resized)
			{
				if (GameEngine.Instance.World.isAccountPremium())
				{
					if ((DateTime.Now - AllVillagesPanel.lastUpdate).TotalSeconds > 30.0)
					{
						AllVillagesPanel.lastUpdate = DateTime.Now;
						RemoteServices.Instance.set_PremiumOverview_UserCallBack(new RemoteServices.PremiumOverview_UserCallBack(this.PremiumOverview_callback));
						RemoteServices.Instance.PremiumOverview();
					}
				}
				else
				{
					this.allVillageData.Clear();
					List<int> userVillageIDList = GameEngine.Instance.World.getUserVillageIDList();
					foreach (int villageID in userVillageIDList)
					{
						VillageSummaryData villageSummaryData = new VillageSummaryData();
						villageSummaryData.villageID = villageID;
						villageSummaryData.fake = true;
						this.allVillageData.Add(villageSummaryData);
					}
				}
			}
			this.addVillages();
		}

		// Token: 0x060005BB RID: 1467 RVA: 0x00071070 File Offset: 0x0006F270
		private void clearExpand()
		{
			foreach (VillageSummaryData villageSummaryData in this.allVillageData)
			{
				villageSummaryData.expanded = false;
			}
		}

		// Token: 0x060005BC RID: 1468 RVA: 0x0000B0A6 File Offset: 0x000092A6
		public static void travellersChanged()
		{
			AllVillagesPanel.lastUpdate = DateTime.MinValue;
		}

		// Token: 0x060005BD RID: 1469 RVA: 0x000710C4 File Offset: 0x0006F2C4
		private void PremiumOverview_callback(PremiumOverview_ReturnType returnData)
		{
			if (returnData.Success && returnData.summaryData != null)
			{
				this.allVillageData = returnData.summaryData;
				this.allVillageData.Sort(this.nameComparer);
				foreach (VillageSummaryData villageSummaryData in this.allVillageData)
				{
					GameEngine.Instance.World.getTotalTroopsOutOfVillage(villageSummaryData.villageID, ref villageSummaryData.numAttackingPeasants, ref villageSummaryData.numAttackingArchers, ref villageSummaryData.numAttackingPikemen, ref villageSummaryData.numAttackingSwordsmen, ref villageSummaryData.numAttackingCatapults, ref villageSummaryData.numAttackingCaptains, ref villageSummaryData.numReinforcingPeasants, ref villageSummaryData.numReinforcingArchers, ref villageSummaryData.numReinforcingPikemen, ref villageSummaryData.numReinforcingSwordsmen, ref villageSummaryData.numReinforcingCatapults, ref villageSummaryData.numReinforcingCaptains);
					villageSummaryData.numAttackingScouts = GameEngine.Instance.World.countYourArmyScouts(villageSummaryData.villageID);
					villageSummaryData.numTravellingMerchants = GameEngine.Instance.World.getTotalMerchantsFromVillage(villageSummaryData.villageID);
					int num = 0;
					int num2 = GameEngine.Instance.World.countVillagePeople(villageSummaryData.villageID, 4, ref num);
					villageSummaryData.numTravellingMonks = num2 - num;
					villageSummaryData.numMonks = num2;
				}
				using (List<VillageResourceReturnData>.Enumerator enumerator2 = returnData.resourceData.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						VillageResourceReturnData item = enumerator2.Current;
						AllVillagesPanel.resourceReturnData.Add(item);
					}
					goto IL_16E;
				}
			}
			this.allVillageData.Clear();
			IL_16E:
			this.addVillages();
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x0000B0B2 File Offset: 0x000092B2
		private void tabAllClicked()
		{
			this.pageMode = 0;
			this.init(true);
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x0000B0C2 File Offset: 0x000092C2
		private void tabTroopsClicked()
		{
			this.pageMode = 1;
			this.init(true);
		}

		// Token: 0x060005C0 RID: 1472 RVA: 0x0000B0D2 File Offset: 0x000092D2
		private void tabUnitsClicked()
		{
			this.pageMode = 2;
			this.init(true);
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x0000B0E2 File Offset: 0x000092E2
		private void tabVillageClicked()
		{
			this.pageMode = 3;
			this.init(true);
		}

		// Token: 0x060005C2 RID: 1474 RVA: 0x0000B0F2 File Offset: 0x000092F2
		private void tabResourceClicked()
		{
			this.pageMode = 4;
			this.init(true);
		}

		// Token: 0x060005C3 RID: 1475 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x0000B102 File Offset: 0x00009302
		public void logout()
		{
			this.allVillageData.Clear();
		}

		// Token: 0x060005C5 RID: 1477 RVA: 0x00071264 File Offset: 0x0006F464
		private void wallScrollBarMoved()
		{
			int value = this.wallScrollBar.Value;
			this.wallScrollArea.Position = new Point(this.wallScrollArea.X, 85 - value);
			this.wallScrollArea.ClipRect = new Rectangle(this.wallScrollArea.ClipRect.X, value, this.wallScrollArea.ClipRect.Width, this.wallScrollArea.ClipRect.Height);
			this.wallScrollArea.invalidate();
			this.wallScrollBar.invalidate();
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x0000B10F File Offset: 0x0000930F
		private void mouseWheelMoved(int delta)
		{
			if (this.wallScrollBar.Visible)
			{
				if (delta < 0)
				{
					this.wallScrollBar.scrollDown(40);
					return;
				}
				if (delta > 0)
				{
					this.wallScrollBar.scrollUp(40);
				}
			}
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x0000ADE9 File Offset: 0x00008FE9
		public void closing()
		{
			InterfaceMgr.Instance.closeDonatePopup();
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x000712FC File Offset: 0x0006F4FC
		public static string getTooltipDate(int id)
		{
			if (id >= 0 && id < AllVillagesPanel.tooltipDates.Count)
			{
				DateTime dateTime = AllVillagesPanel.tooltipDates[id];
				DateTime currentServerTime = VillageMap.getCurrentServerTime();
				if (dateTime > currentServerTime)
				{
					int secsLeft = (int)(dateTime - currentServerTime).TotalSeconds;
					return SK.Text("TOOLTIP_DATE_ends", "Ends") + " : " + VillageMap.createBuildTimeString(secsLeft);
				}
			}
			return "";
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x0000B141 File Offset: 0x00009341
		public int addTooltipDate(DateTime date)
		{
			AllVillagesPanel.tooltipDates.Add(date);
			return AllVillagesPanel.tooltipDates.Count - 1;
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x0007136C File Offset: 0x0006F56C
		public void addVillages()
		{
			this.wallScrollArea.clearControls();
			AllVillagesPanel.tooltipDates.Clear();
			int num = 0;
			this.lineList.Clear();
			int num2 = 0;
			foreach (VillageSummaryData villageSummaryData in this.allVillageData)
			{
				AllVillagesPanel.VillageOverviewLine villageOverviewLine = new AllVillagesPanel.VillageOverviewLine();
				if (num != 0)
				{
					num += 5;
				}
				villageOverviewLine.Position = new Point(0, num);
				villageOverviewLine.init(villageSummaryData, num2, this.pageMode, villageSummaryData.expanded, this);
				this.wallScrollArea.addControl(villageOverviewLine);
				num += villageOverviewLine.Height;
				this.lineList.Add(villageOverviewLine);
				num2++;
			}
			this.wallScrollArea.Size = new Size(this.wallScrollArea.Width, num);
			if (num < this.wallScrollBar.Height)
			{
				this.wallScrollBar.Value = 0;
				this.wallScrollBarMoved();
				this.wallScrollBar.Visible = false;
			}
			else
			{
				this.wallScrollBar.Visible = true;
				this.wallScrollBar.NumVisibleLines = this.wallScrollBar.Height;
				this.wallScrollBar.Max = num - this.wallScrollBar.Height;
			}
			this.wallScrollArea.invalidate();
			this.wallScrollBar.invalidate();
			this.update();
			base.Invalidate();
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x000714DC File Offset: 0x0006F6DC
		public void expand(int villageID)
		{
			foreach (VillageSummaryData villageSummaryData in this.allVillageData)
			{
				if (villageSummaryData.villageID == villageID)
				{
					villageSummaryData.expanded = !villageSummaryData.expanded;
					break;
				}
			}
			this.addVillages();
		}

		// Token: 0x04000706 RID: 1798
		private const int HEADER_SIZE = 47;

		// Token: 0x04000707 RID: 1799
		private DockableControl dockableControl;

		// Token: 0x04000708 RID: 1800
		private IContainer components;

		// Token: 0x04000709 RID: 1801
		public static AllVillagesPanel instance = null;

		// Token: 0x0400070A RID: 1802
		private static DateTime lastUpdate = DateTime.MinValue;

		// Token: 0x0400070B RID: 1803
		private CustomSelfDrawPanel.CSDFill mainBackgroundImage = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x0400070C RID: 1804
		private CustomSelfDrawPanel.CSDImage backgroundFade = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400070D RID: 1805
		private CustomSelfDrawPanel.CSDExtendingPanel borderImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x0400070E RID: 1806
		private CustomSelfDrawPanel.CSDLabel titleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400070F RID: 1807
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04000710 RID: 1808
		private CustomSelfDrawPanel.CSDImage divider1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000711 RID: 1809
		private CustomSelfDrawPanel.CSDImage divider2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000712 RID: 1810
		private CustomSelfDrawPanel.CSDImage divider3Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000713 RID: 1811
		private CustomSelfDrawPanel.CSDImage divider4Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000714 RID: 1812
		private CustomSelfDrawPanel.CSDImage divider5Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000715 RID: 1813
		private CustomSelfDrawPanel.CSDImage divider6Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000716 RID: 1814
		private CustomSelfDrawPanel.CSDImage divider7Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000717 RID: 1815
		private CustomSelfDrawPanel.CSDImage divider8Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000718 RID: 1816
		private CustomSelfDrawPanel.CSDArea rolloverArea1 = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000719 RID: 1817
		private CustomSelfDrawPanel.CSDArea rolloverArea2 = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400071A RID: 1818
		private CustomSelfDrawPanel.CSDArea rolloverArea3 = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400071B RID: 1819
		private CustomSelfDrawPanel.CSDArea rolloverArea4 = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400071C RID: 1820
		private CustomSelfDrawPanel.CSDArea rolloverArea5 = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400071D RID: 1821
		private CustomSelfDrawPanel.CSDArea rolloverArea6 = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400071E RID: 1822
		private CustomSelfDrawPanel.CSDArea rolloverArea7 = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400071F RID: 1823
		private CustomSelfDrawPanel.CSDArea rolloverArea8 = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000720 RID: 1824
		private CustomSelfDrawPanel.CSDLabel villageLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000721 RID: 1825
		private CustomSelfDrawPanel.CSDImage headerImage1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000722 RID: 1826
		private CustomSelfDrawPanel.CSDImage headerImage2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000723 RID: 1827
		private CustomSelfDrawPanel.CSDImage headerImage3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000724 RID: 1828
		private CustomSelfDrawPanel.CSDImage headerImage4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000725 RID: 1829
		private CustomSelfDrawPanel.CSDImage headerImage5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000726 RID: 1830
		private CustomSelfDrawPanel.CSDImage headerImage6 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000727 RID: 1831
		private CustomSelfDrawPanel.CSDImage headerImage7 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000728 RID: 1832
		private CustomSelfDrawPanel.CSDButton tabBtnAll = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000729 RID: 1833
		private CustomSelfDrawPanel.CSDButton tabBtnTroops = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400072A RID: 1834
		private CustomSelfDrawPanel.CSDButton tabBtnUnits = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400072B RID: 1835
		private CustomSelfDrawPanel.CSDButton tabBtnVillage = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400072C RID: 1836
		private CustomSelfDrawPanel.CSDButton tabBtnResrouce = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400072D RID: 1837
		private CustomSelfDrawPanel.CSDLabel playersLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400072E RID: 1838
		private CustomSelfDrawPanel.CSDLabel pointsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400072F RID: 1839
		private CustomSelfDrawPanel.CSDLabel membershipLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000730 RID: 1840
		private CustomSelfDrawPanel.CSDVertScrollBar wallScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04000731 RID: 1841
		private CustomSelfDrawPanel.CSDArea wallScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000732 RID: 1842
		private CustomSelfDrawPanel.CSDControl mouseWheelOverlay = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x04000733 RID: 1843
		private int pageMode;

		// Token: 0x04000734 RID: 1844
		private List<VillageSummaryData> allVillageData = new List<VillageSummaryData>();

		// Token: 0x04000735 RID: 1845
		private static List<DateTime> tooltipDates = new List<DateTime>();

		// Token: 0x04000736 RID: 1846
		public static List<VillageResourceReturnData> resourceReturnData = new List<VillageResourceReturnData>();

		// Token: 0x04000737 RID: 1847
		private List<AllVillagesPanel.VillageOverviewLine> lineList = new List<AllVillagesPanel.VillageOverviewLine>();

		// Token: 0x04000738 RID: 1848
		private AllVillagesPanel.NameComparer nameComparer = new AllVillagesPanel.NameComparer();

		// Token: 0x020000CD RID: 205
		public class VillageOverviewLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x060005CD RID: 1485 RVA: 0x00071548 File Offset: 0x0006F748
			public void init(VillageSummaryData vsd, int position, int pageMode, bool expanded, AllVillagesPanel parent)
			{
				this.m_parent = parent;
				this.m_position = position;
				this.ClipVisible = true;
				this.m_vsd = vsd;
				this.clearControls();
				if ((position & 1) == 0)
				{
					this.backgroundImage.Image = GFXLibrary.lineitem_strip_02_light;
				}
				else
				{
					this.backgroundImage.Image = GFXLibrary.lineitem_strip_02_dark;
				}
				this.backgroundImage.Position = new Point(10, 0);
				base.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
				base.addControl(this.backgroundImage);
				this.Size = new Size(890, this.backgroundImage.Size.Height);
				int height = GFXLibrary.lineitem_strip_02_light.Height;
				NumberFormatInfo nfi = GameEngine.NFI;
				this.villageName.Text = GameEngine.Instance.World.getVillageName(vsd.villageID);
				this.villageName.Color = global::ARGBColors.Black;
				this.villageName.Position = new Point(19, 0);
				this.villageName.Size = new Size(220, height);
				this.villageName.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				this.villageName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				base.addControl(this.villageName);
				int num = 275;
				switch (pageMode)
				{
				case 0:
				{
					int num2 = vsd.numAttackingArchers + vsd.numAttackingCaptains + vsd.numAttackingCatapults + vsd.numAttackingPeasants + vsd.numAttackingPikemen + vsd.numAttackingSwordsmen;
					num2 += vsd.numLocalArchers + vsd.numLocalCaptains + vsd.numLocalCatapults + vsd.numLocalPeasants + vsd.numLocalPikemen + vsd.numLocalSwordsmen;
					num2 += vsd.numPlacedArchers + vsd.numPlacedCaptains + vsd.numPlacedPeasants + vsd.numPlacedPikemen + vsd.numPlacedSwordsmen;
					num2 += vsd.numReinforcingArchers + vsd.numReinforcingCaptains + vsd.numReinforcingCatapults + vsd.numReinforcingPeasants + vsd.numReinforcingPikemen + vsd.numReinforcingSwordsmen;
					this.value1Label.Text = num2.ToString();
					if (vsd.fake)
					{
						this.value1Label.Text = "?";
					}
					this.value1Label.Color = global::ARGBColors.Black;
					this.value1Label.Position = new Point(num + 5, 0);
					this.value1Label.Size = new Size(70, height);
					this.value1Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
					this.value1Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
					base.addControl(this.value1Label);
					int num3 = vsd.numAttackingScouts + vsd.numLocalScouts;
					this.value2Label.Text = num3.ToString();
					if (vsd.fake)
					{
						this.value2Label.Text = "?";
					}
					this.value2Label.Color = global::ARGBColors.Black;
					this.value2Label.Position = new Point(num + 85 + 5, 0);
					this.value2Label.Size = new Size(60, height);
					this.value2Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
					this.value2Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
					base.addControl(this.value2Label);
					int num4 = vsd.numMerchantsAtHome + vsd.numTravellingMerchants;
					this.value3Label.Text = num4.ToString();
					if (vsd.fake)
					{
						this.value3Label.Text = "?";
					}
					this.value3Label.Color = global::ARGBColors.Black;
					this.value3Label.Position = new Point(num + 170 + 5, 0);
					this.value3Label.Size = new Size(60, height);
					this.value3Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
					this.value3Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
					base.addControl(this.value3Label);
					int numMonks = vsd.numMonks;
					this.value4Label.Text = numMonks.ToString();
					if (vsd.fake)
					{
						this.value4Label.Text = "?";
					}
					this.value4Label.Color = global::ARGBColors.Black;
					this.value4Label.Position = new Point(num + 255 + 5, 0);
					this.value4Label.Size = new Size(60, height);
					this.value4Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
					this.value4Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
					base.addControl(this.value4Label);
					int popularityLevel = vsd.popularityLevel;
					this.value5Label.Text = popularityLevel.ToString();
					if (vsd.fake)
					{
						this.value5Label.Text = "?";
					}
					this.value5Label.Color = global::ARGBColors.Black;
					if (popularityLevel < 0)
					{
						this.value5Label.Color = Color.FromArgb(170, 0, 0);
					}
					this.value5Label.Position = new Point(num + 340 + 5, 0);
					this.value5Label.Size = new Size(60, height);
					this.value5Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
					this.value5Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
					base.addControl(this.value5Label);
					int numBuildings = vsd.numBuildings;
					this.value6Label.Text = numBuildings.ToString();
					if (vsd.fake)
					{
						this.value6Label.Text = "?";
					}
					this.value6Label.Color = global::ARGBColors.Black;
					this.value6Label.Position = new Point(num + 425 + 5, 0);
					this.value6Label.Size = new Size(60, height);
					this.value6Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
					this.value6Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
					base.addControl(this.value6Label);
					if (!vsd.fake)
					{
						if (vsd.enclosedKeep)
						{
							this.enclosedImage.Image = GFXLibrary.villageOverviewIcons[10];
							this.idRollover.CustomTooltipID = 4106;
							this.enclosedImage.Position = new Point(num + 510, -15);
						}
						else
						{
							this.enclosedImage.Image = GFXLibrary.villageOverviewIcons[11];
							this.idRollover.CustomTooltipID = 4107;
							this.enclosedImage.Position = new Point(num + 510 + 2, -15);
						}
						base.addControl(this.enclosedImage);
						this.idRollover.Size = new Size(25, 25);
						this.idRollover.Position = new Point(num + 510 + 29, 4);
						base.addControl(this.idRollover);
						this.enclosedImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedCastle));
					}
					if (vsd.castleDamaged)
					{
						this.damageImage.Image = GFXLibrary.castle_damage;
						this.damageImage.setSizeToImage();
						this.damageImage.Position = new Point(num + 595 - 20, -6);
						this.damageImage.CustomTooltipID = 4140;
						this.damageImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedCastle));
						base.addControl(this.damageImage);
					}
					break;
				}
				case 1:
				{
					int num5 = vsd.numAttackingPeasants + vsd.numLocalPeasants + vsd.numPlacedPeasants + vsd.numReinforcingPeasants;
					this.value1Label.Text = num5.ToString();
					if (vsd.fake)
					{
						this.value1Label.Text = "?";
					}
					this.value1Label.Color = global::ARGBColors.Black;
					this.value1Label.Position = new Point(num + 5, 0);
					this.value1Label.Size = new Size(70, height);
					this.value1Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
					this.value1Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
					base.addControl(this.value1Label);
					int num6 = vsd.numAttackingArchers + vsd.numLocalArchers + vsd.numPlacedArchers + vsd.numReinforcingArchers;
					this.value2Label.Text = num6.ToString();
					if (vsd.fake)
					{
						this.value2Label.Text = "?";
					}
					this.value2Label.Color = global::ARGBColors.Black;
					this.value2Label.Position = new Point(num + 85 + 5, 0);
					this.value2Label.Size = new Size(60, height);
					this.value2Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
					this.value2Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
					base.addControl(this.value2Label);
					int num7 = vsd.numAttackingPikemen + vsd.numLocalPikemen + vsd.numPlacedPikemen + vsd.numReinforcingPikemen;
					this.value3Label.Text = num7.ToString();
					if (vsd.fake)
					{
						this.value3Label.Text = "?";
					}
					this.value3Label.Color = global::ARGBColors.Black;
					this.value3Label.Position = new Point(num + 170 + 5, 0);
					this.value3Label.Size = new Size(60, height);
					this.value3Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
					this.value3Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
					base.addControl(this.value3Label);
					int num8 = vsd.numAttackingSwordsmen + vsd.numLocalSwordsmen + vsd.numPlacedSwordsmen + vsd.numReinforcingSwordsmen;
					this.value4Label.Text = num8.ToString();
					if (vsd.fake)
					{
						this.value4Label.Text = "?";
					}
					this.value4Label.Color = global::ARGBColors.Black;
					this.value4Label.Position = new Point(num + 255 + 5, 0);
					this.value4Label.Size = new Size(60, height);
					this.value4Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
					this.value4Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
					base.addControl(this.value4Label);
					int num9 = vsd.numAttackingCatapults + vsd.numLocalCatapults + vsd.numReinforcingCatapults;
					this.value5Label.Text = num9.ToString();
					if (vsd.fake)
					{
						this.value5Label.Text = "?";
					}
					this.value5Label.Color = global::ARGBColors.Black;
					this.value5Label.Position = new Point(num + 340 + 5, 0);
					this.value5Label.Size = new Size(60, height);
					this.value5Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
					this.value5Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
					base.addControl(this.value5Label);
					int num10 = vsd.numAttackingCaptains + vsd.numLocalCaptains + vsd.numReinforcingCaptains + vsd.numPlacedCaptains;
					this.value6Label.Text = num10.ToString();
					if (vsd.fake)
					{
						this.value6Label.Text = "?";
					}
					this.value6Label.Color = global::ARGBColors.Black;
					this.value6Label.Position = new Point(num + 425 + 5, 0);
					this.value6Label.Size = new Size(60, height);
					this.value6Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
					this.value6Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
					base.addControl(this.value6Label);
					if (!vsd.fake)
					{
						if (expanded)
						{
							this.Size = new Size(890, this.backgroundImage.Size.Height + 100);
							this.barracksLabel.Text = SK.Text("BARRACKS_In_Barracks", "In Barracks");
							this.barracksLabel.Color = global::ARGBColors.Black;
							this.barracksLabel.Position = new Point(0, 26);
							this.barracksLabel.Size = new Size(295, height);
							this.barracksLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
							this.barracksLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.barracksLabel);
							this.value1aLabel.Text = vsd.numLocalPeasants.ToString();
							this.value1aLabel.Color = global::ARGBColors.Black;
							this.value1aLabel.Position = new Point(num + 5, 26);
							this.value1aLabel.Size = new Size(70, height);
							this.value1aLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
							this.value1aLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.value1aLabel);
							this.value2aLabel.Text = vsd.numLocalArchers.ToString();
							this.value2aLabel.Color = global::ARGBColors.Black;
							this.value2aLabel.Position = new Point(num + 85 + 5, 26);
							this.value2aLabel.Size = new Size(60, height);
							this.value2aLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
							this.value2aLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.value2aLabel);
							this.value3aLabel.Text = vsd.numLocalPikemen.ToString();
							this.value3aLabel.Color = global::ARGBColors.Black;
							this.value3aLabel.Position = new Point(num + 170 + 5, 26);
							this.value3aLabel.Size = new Size(60, height);
							this.value3aLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
							this.value3aLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.value3aLabel);
							this.value4aLabel.Text = vsd.numLocalSwordsmen.ToString();
							this.value4aLabel.Color = global::ARGBColors.Black;
							this.value4aLabel.Position = new Point(num + 255 + 5, 26);
							this.value4aLabel.Size = new Size(60, height);
							this.value4aLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
							this.value4aLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.value4aLabel);
							this.value5aLabel.Text = vsd.numLocalCatapults.ToString();
							this.value5aLabel.Color = global::ARGBColors.Black;
							this.value5aLabel.Position = new Point(num + 340 + 5, 26);
							this.value5aLabel.Size = new Size(60, height);
							this.value5aLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
							this.value5aLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.value5aLabel);
							this.value6aLabel.Text = vsd.numLocalCaptains.ToString();
							this.value6aLabel.Color = global::ARGBColors.Black;
							this.value6aLabel.Position = new Point(num + 425 + 5, 26);
							this.value6aLabel.Size = new Size(60, height);
							this.value6aLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
							this.value6aLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.value6aLabel);
							this.placedLabel.Text = SK.Text("BARRACKS_In_Castle", "In Castle");
							this.placedLabel.Color = global::ARGBColors.Black;
							this.placedLabel.Position = new Point(0, 51);
							this.placedLabel.Size = new Size(295, height);
							this.placedLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
							this.placedLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.placedLabel);
							this.value1bLabel.Text = vsd.numPlacedPeasants.ToString();
							this.value1bLabel.Color = global::ARGBColors.Black;
							this.value1bLabel.Position = new Point(num + 5, 51);
							this.value1bLabel.Size = new Size(70, height);
							this.value1bLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
							this.value1bLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.value1bLabel);
							this.value2bLabel.Text = vsd.numPlacedArchers.ToString();
							this.value2bLabel.Color = global::ARGBColors.Black;
							this.value2bLabel.Position = new Point(num + 85 + 5, 51);
							this.value2bLabel.Size = new Size(60, height);
							this.value2bLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
							this.value2bLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.value2bLabel);
							this.value3bLabel.Text = vsd.numPlacedPikemen.ToString();
							this.value3bLabel.Color = global::ARGBColors.Black;
							this.value3bLabel.Position = new Point(num + 170 + 5, 51);
							this.value3bLabel.Size = new Size(60, height);
							this.value3bLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
							this.value3bLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.value3bLabel);
							this.value4bLabel.Text = vsd.numPlacedSwordsmen.ToString();
							this.value4bLabel.Color = global::ARGBColors.Black;
							this.value4bLabel.Position = new Point(num + 255 + 5, 51);
							this.value4bLabel.Size = new Size(60, height);
							this.value4bLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
							this.value4bLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.value4bLabel);
							this.value6bLabel.Text = vsd.numPlacedCaptains.ToString();
							this.value6bLabel.Color = global::ARGBColors.Black;
							this.value6bLabel.Position = new Point(num + 425 + 5, 51);
							this.value6bLabel.Size = new Size(60, height);
							this.value6bLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
							this.value6bLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.value6bLabel);
							this.attackingLabel.Text = SK.Text("GENERIC_Attacking", "Attacking");
							this.attackingLabel.Color = global::ARGBColors.Black;
							this.attackingLabel.Position = new Point(0, 76);
							this.attackingLabel.Size = new Size(295, height);
							this.attackingLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
							this.attackingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.attackingLabel);
							this.value1cLabel.Text = vsd.numAttackingPeasants.ToString();
							this.value1cLabel.Color = global::ARGBColors.Black;
							this.value1cLabel.Position = new Point(num + 5, 76);
							this.value1cLabel.Size = new Size(70, height);
							this.value1cLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
							this.value1cLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.value1cLabel);
							this.value2cLabel.Text = vsd.numAttackingArchers.ToString();
							this.value2cLabel.Color = global::ARGBColors.Black;
							this.value2cLabel.Position = new Point(num + 85 + 5, 76);
							this.value2cLabel.Size = new Size(60, height);
							this.value2cLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
							this.value2cLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.value2cLabel);
							this.value3cLabel.Text = vsd.numAttackingPikemen.ToString();
							this.value3cLabel.Color = global::ARGBColors.Black;
							this.value3cLabel.Position = new Point(num + 170 + 5, 76);
							this.value3cLabel.Size = new Size(60, height);
							this.value3cLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
							this.value3cLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.value3cLabel);
							this.value4cLabel.Text = vsd.numAttackingSwordsmen.ToString();
							this.value4cLabel.Color = global::ARGBColors.Black;
							this.value4cLabel.Position = new Point(num + 255 + 5, 76);
							this.value4cLabel.Size = new Size(60, height);
							this.value4cLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
							this.value4cLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.value4cLabel);
							this.value5cLabel.Text = vsd.numAttackingCatapults.ToString();
							this.value5cLabel.Color = global::ARGBColors.Black;
							this.value5cLabel.Position = new Point(num + 340 + 5, 76);
							this.value5cLabel.Size = new Size(60, height);
							this.value5cLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
							this.value5cLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.value5cLabel);
							this.value6cLabel.Text = vsd.numAttackingCaptains.ToString();
							this.value6cLabel.Color = global::ARGBColors.Black;
							this.value6cLabel.Position = new Point(num + 425 + 5, 76);
							this.value6cLabel.Size = new Size(60, height);
							this.value6cLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
							this.value6cLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.value6cLabel);
							this.reinforcingLabel.Text = SK.Text("BARRACKS_Reinforcing", "Reinforcing");
							this.reinforcingLabel.Color = global::ARGBColors.Black;
							this.reinforcingLabel.Position = new Point(0, 101);
							this.reinforcingLabel.Size = new Size(295, height);
							this.reinforcingLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
							this.reinforcingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.reinforcingLabel);
							this.value1dLabel.Text = vsd.numReinforcingPeasants.ToString();
							this.value1dLabel.Color = global::ARGBColors.Black;
							this.value1dLabel.Position = new Point(num + 5, 101);
							this.value1dLabel.Size = new Size(70, height);
							this.value1dLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
							this.value1dLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.value1dLabel);
							this.value2dLabel.Text = vsd.numReinforcingArchers.ToString();
							this.value2dLabel.Color = global::ARGBColors.Black;
							this.value2dLabel.Position = new Point(num + 85 + 5, 101);
							this.value2dLabel.Size = new Size(60, height);
							this.value2dLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
							this.value2dLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.value2dLabel);
							this.value3dLabel.Text = vsd.numReinforcingPikemen.ToString();
							this.value3dLabel.Color = global::ARGBColors.Black;
							this.value3dLabel.Position = new Point(num + 170 + 5, 101);
							this.value3dLabel.Size = new Size(60, height);
							this.value3dLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
							this.value3dLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.value3dLabel);
							this.value4dLabel.Text = vsd.numReinforcingSwordsmen.ToString();
							this.value4dLabel.Color = global::ARGBColors.Black;
							this.value4dLabel.Position = new Point(num + 255 + 5, 101);
							this.value4dLabel.Size = new Size(60, height);
							this.value4dLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
							this.value4dLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.value4dLabel);
							this.value5dLabel.Text = vsd.numReinforcingCatapults.ToString();
							this.value5dLabel.Color = global::ARGBColors.Black;
							this.value5dLabel.Position = new Point(num + 340 + 5, 101);
							this.value5dLabel.Size = new Size(60, height);
							this.value5dLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
							this.value5dLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.value5dLabel);
							this.expandButton.ImageNorm = GFXLibrary.blue_screen_button_array[1];
							this.expandButton.ImageOver = GFXLibrary.blue_screen_button_array[3];
							this.expandButton.ImageClick = GFXLibrary.blue_screen_button_array[5];
							this.expandButton.Position = new Point(840, 2);
							this.expandButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.expandClick));
							base.addControl(this.expandButton);
						}
						else
						{
							this.expandButton.ImageNorm = GFXLibrary.blue_screen_button_array[0];
							this.expandButton.ImageOver = GFXLibrary.blue_screen_button_array[2];
							this.expandButton.ImageClick = GFXLibrary.blue_screen_button_array[4];
							this.expandButton.Position = new Point(840, 2);
							this.expandButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.expandClick));
							base.addControl(this.expandButton);
						}
					}
					break;
				}
				case 2:
				{
					int numAttackingScouts = vsd.numAttackingScouts;
					int numLocalScouts = vsd.numLocalScouts;
					this.value1Label.Text = (numAttackingScouts + numLocalScouts).ToString();
					if (vsd.fake)
					{
						this.value1Label.Text = "?";
					}
					this.value1Label.Color = global::ARGBColors.Black;
					this.value1Label.Position = new Point(304, 0);
					this.value1Label.Size = new Size(70, height);
					this.value1Label.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
					this.value1Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
					base.addControl(this.value1Label);
					if (numAttackingScouts > 0 && !vsd.fake)
					{
						this.value2Label.Text = "(" + numAttackingScouts.ToString() + ")";
						this.value2Label.Color = global::ARGBColors.Black;
						this.value2Label.Position = new Point(379, 0);
						this.value2Label.Size = new Size(70, height);
						this.value2Label.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
						this.value2Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
						base.addControl(this.value2Label);
					}
					int numTravellingMerchants = vsd.numTravellingMerchants;
					int numMerchantsAtHome = vsd.numMerchantsAtHome;
					this.value3Label.Text = (numTravellingMerchants + numMerchantsAtHome).ToString();
					if (vsd.fake)
					{
						this.value3Label.Text = "?";
					}
					this.value3Label.Color = global::ARGBColors.Black;
					this.value3Label.Position = new Point(474, 0);
					this.value3Label.Size = new Size(70, height);
					this.value3Label.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
					this.value3Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
					base.addControl(this.value3Label);
					if (numTravellingMerchants > 0 && !vsd.fake)
					{
						this.value4Label.Text = "(" + numTravellingMerchants.ToString() + ")";
						this.value4Label.Color = global::ARGBColors.Black;
						this.value4Label.Position = new Point(549, 0);
						this.value4Label.Size = new Size(70, height);
						this.value4Label.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
						this.value4Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
						base.addControl(this.value4Label);
					}
					int numTravellingMonks = vsd.numTravellingMonks;
					int numMonks2 = vsd.numMonks;
					this.value5Label.Text = numMonks2.ToString();
					if (vsd.fake)
					{
						this.value5Label.Text = "?";
					}
					this.value5Label.Color = global::ARGBColors.Black;
					this.value5Label.Position = new Point(644, 0);
					this.value5Label.Size = new Size(70, height);
					this.value5Label.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
					this.value5Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
					base.addControl(this.value5Label);
					if (numTravellingMonks > 0 && !vsd.fake)
					{
						this.value6Label.Text = "(" + numTravellingMonks.ToString() + ")";
						this.value6Label.Color = global::ARGBColors.Black;
						this.value6Label.Position = new Point(719, 0);
						this.value6Label.Size = new Size(70, height);
						this.value6Label.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
						this.value6Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
						base.addControl(this.value6Label);
					}
					break;
				}
				case 3:
				{
					int num11 = vsd.totalPeople;
					if (vsd.housingCapacity < vsd.totalPeople)
					{
						num11 = vsd.housingCapacity;
					}
					double num12 = (double)num11 * VillageBuildingsData.getTaxIncomeLevel(vsd.setTaxLevel, GameEngine.Instance.cardsManager.UserCardData) * GameEngine.Instance.LocalWorldData.goldIncomeRate;
					this.value1Label.Color = global::ARGBColors.Black;
					string text;
					if (num12 > 0.0)
					{
						text = "+" + ((int)num12).ToString("N", nfi);
					}
					else if (num12 < 0.0)
					{
						text = ((int)num12).ToString("N", nfi);
						this.value1Label.Color = Color.FromArgb(255, 200, 0);
					}
					else
					{
						text = "0";
					}
					this.value1Label.Text = text;
					if (vsd.fake)
					{
						this.value1Label.Text = "?";
					}
					this.value1Label.Position = new Point(num + 5, 0);
					this.value1Label.Size = new Size(70, height);
					this.value1Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
					this.value1Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
					base.addControl(this.value1Label);
					text = "";
					string str = (vsd.currentRationsLevel >= 6.0) ? "x4" : ((vsd.currentRationsLevel >= 5.0) ? "x3" : ((vsd.currentRationsLevel >= 4.0) ? "x2" : ((vsd.currentRationsLevel >= 3.0) ? "x1" : ((vsd.currentRationsLevel >= 2.0) ? "1/2" : ((vsd.currentRationsLevel < 1.0) ? "0" : "1/4")))));
					text += str;
					this.value2Label.Text = text;
					if (vsd.fake)
					{
						this.value2Label.Text = "?";
					}
					this.value2Label.Color = global::ARGBColors.Black;
					if ((double)vsd.setRationsLevel != vsd.currentRationsLevel)
					{
						this.value2Label.Color = Color.FromArgb(170, 0, 0);
					}
					this.value2Label.Position = new Point(num + 85 + 5, 0);
					this.value2Label.Size = new Size(60, height);
					this.value2Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
					this.value2Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
					base.addControl(this.value2Label);
					text = "";
					str = ((vsd.currentAleLevel >= 4.0) ? "x4" : ((vsd.currentAleLevel >= 3.0) ? "x3" : ((vsd.currentAleLevel >= 2.0) ? "x2" : ((vsd.currentAleLevel < 1.0) ? "0" : "x1"))));
					text += str;
					this.value3Label.Text = text;
					if (vsd.fake)
					{
						this.value3Label.Text = "?";
					}
					this.value3Label.Color = global::ARGBColors.Black;
					if ((double)vsd.setAleLevel != vsd.currentAleLevel)
					{
						this.value3Label.Color = Color.FromArgb(170, 0, 0);
					}
					this.value3Label.Position = new Point(num + 170 + 5, 0);
					this.value3Label.Size = new Size(60, height);
					this.value3Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
					this.value3Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
					base.addControl(this.value3Label);
					this.value4Label.Text = vsd.totalPeople.ToString() + " / " + vsd.housingCapacity.ToString() + " ";
					if (vsd.fake)
					{
						this.value4Label.Text = "?";
					}
					this.value4Label.Color = global::ARGBColors.Black;
					this.value4Label.Position = new Point(num + 255 + 5, 0);
					this.value4Label.Size = new Size(75, height);
					this.value4Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
					this.value4Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
					base.addControl(this.value4Label);
					this.value4aLabel.Text = vsd.sparePeople.ToString();
					if (vsd.fake)
					{
						this.value4aLabel.Text = "?";
					}
					this.value4aLabel.Color = global::ARGBColors.Black;
					this.value4aLabel.Position = new Point(num + 255 + 5 + 11 + 20, 0);
					this.value4aLabel.Size = new Size(80, height);
					this.value4aLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
					this.value4aLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
					base.addControl(this.value4aLabel);
					int popularityLevel2 = vsd.popularityLevel;
					this.value5Label.Text = popularityLevel2.ToString();
					if (vsd.fake)
					{
						this.value5Label.Text = "?";
					}
					this.value5Label.Color = global::ARGBColors.Black;
					if (popularityLevel2 < 0)
					{
						this.value5Label.Color = Color.FromArgb(170, 0, 0);
					}
					this.value5Label.Position = new Point(num + 340 + 5 + 20, 0);
					this.value5Label.Size = new Size(70, height);
					this.value5Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
					this.value5Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
					base.addControl(this.value5Label);
					int numBuildings2 = vsd.numBuildings;
					this.value6Label.Text = numBuildings2.ToString();
					if (vsd.fake)
					{
						this.value6Label.Text = "?";
					}
					this.value6Label.Color = global::ARGBColors.Black;
					this.value6Label.Position = new Point(num + 425 + 5 + 20, 0);
					this.value6Label.Size = new Size(60, height);
					this.value6Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
					this.value6Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
					base.addControl(this.value6Label);
					if (!vsd.fake)
					{
						int num13 = num + 510 + 20;
						int num14 = num + 510 + 20 + 15;
						if (vsd.interdictProtectionEndTime > VillageMap.getCurrentServerTime())
						{
							this.idImage.Image = GFXLibrary.villageOverviewIcons[16];
							this.idImage.Position = new Point((int)((double)num13 / 0.6), -2);
							this.idImage.setScale(0.6);
							base.addControl(this.idImage);
							num13 += 29;
							this.idRollover.Size = new Size(22, 22);
							this.idRollover.Position = new Point(num14, 4);
							this.idRollover.CustomTooltipID = 4123;
							this.idRollover.CustomTooltipData = parent.addTooltipDate(vsd.interdictProtectionEndTime);
							base.addControl(this.idRollover);
							num14 += 29;
						}
						if (vsd.excommunicationEndTime > VillageMap.getCurrentServerTime())
						{
							this.excomdImage.Image = GFXLibrary.villageOverviewIcons[17];
							this.excomdImage.Position = new Point((int)((double)num13 / 0.6), -2);
							this.excomdImage.setScale(0.6);
							base.addControl(this.excomdImage);
							num13 += 29;
							this.excomRollover.Size = new Size(22, 22);
							this.excomRollover.Position = new Point(num14, 4);
							this.excomRollover.CustomTooltipID = 4124;
							this.excomRollover.CustomTooltipData = parent.addTooltipDate(vsd.excommunicationEndTime);
							base.addControl(this.excomRollover);
							num14 += 29;
						}
						if (vsd.peaceTimeEndTime > VillageMap.getCurrentServerTime())
						{
							this.peaceImage.Image = GFXLibrary.villageOverviewIcons[19];
							this.peaceImage.Position = new Point((int)((double)num13 / 0.6), -2);
							this.peaceImage.setScale(0.6);
							base.addControl(this.peaceImage);
							num13 += 29;
							this.peaceRollover.Size = new Size(22, 22);
							this.peaceRollover.Position = new Point(num14, 4);
							this.peaceRollover.CustomTooltipID = 4125;
							this.peaceRollover.CustomTooltipData = parent.addTooltipDate(vsd.peaceTimeEndTime);
							base.addControl(this.peaceRollover);
							num14 += 29;
						}
					}
					break;
				}
				case 4:
					foreach (VillageResourceReturnData villageResourceReturnData in AllVillagesPanel.resourceReturnData)
					{
						if (vsd.villageID == villageResourceReturnData.villageID)
						{
							double d = villageResourceReturnData.applesLevel + villageResourceReturnData.breadLevel + villageResourceReturnData.cheeseLevel + villageResourceReturnData.fishLevel + villageResourceReturnData.meatLevel + villageResourceReturnData.vegLevel;
							this.value1Label.Text = Math.Max(0, Convert.ToInt32(Math.Floor(d))).ToString();
							this.value1Label.Color = global::ARGBColors.Black;
							this.value1Label.Position = new Point(num + 5, 0);
							this.value1Label.Size = new Size(70, height);
							this.value1Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
							this.value1Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.value1Label);
							this.value2Label.Text = villageResourceReturnData.aleLevel.ToString();
							this.value2Label.Color = global::ARGBColors.Black;
							this.value2Label.Position = new Point(num + 85 + 5, 0);
							this.value2Label.Size = new Size(60, height);
							this.value2Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
							this.value2Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.value2Label);
							this.value3Label.Text = villageResourceReturnData.woodLevel.ToString();
							this.value3Label.Color = global::ARGBColors.Black;
							this.value3Label.Position = new Point(num + 170 + 5, 0);
							this.value3Label.Size = new Size(60, height);
							this.value3Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
							this.value3Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.value3Label);
							this.value4Label.Text = villageResourceReturnData.stoneLevel.ToString();
							this.value4Label.Color = global::ARGBColors.Black;
							this.value4Label.Position = new Point(num + 255 + 5, 0);
							this.value4Label.Size = new Size(75, height);
							this.value4Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
							this.value4Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.value4Label);
							this.value5Label.Text = villageResourceReturnData.ironLevel.ToString();
							this.value5Label.Color = global::ARGBColors.Black;
							this.value5Label.Position = new Point(num + 340 + 5 + 20, 0);
							this.value5Label.Size = new Size(70, height);
							this.value5Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
							this.value5Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.value5Label);
							this.value6Label.Text = villageResourceReturnData.pitchLevel.ToString();
							this.value6Label.Color = global::ARGBColors.Black;
							this.value6Label.Position = new Point(num + 425 + 5 + 20, 0);
							this.value6Label.Size = new Size(60, height);
							this.value6Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
							this.value6Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
							base.addControl(this.value6Label);
						}
					}
					break;
				}
				this.clickArea.Position = new Point(0, 0);
				this.clickArea.Size = new Size(790, this.backgroundImage.Height);
				this.clickArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
				if (vsd.fake)
				{
					this.clickArea.CustomTooltipID = 4126;
				}
				else
				{
					this.clickArea.CustomTooltipID = 0;
				}
				base.addControl(this.clickArea);
				base.invalidate();
			}

			// Token: 0x060005CE RID: 1486 RVA: 0x00007CE0 File Offset: 0x00005EE0
			public void update()
			{
			}

			// Token: 0x060005CF RID: 1487 RVA: 0x0000B180 File Offset: 0x00009380
			private void expandClick()
			{
				if (this.m_parent != null)
				{
					this.m_parent.expand(this.m_vsd.villageID);
				}
			}

			// Token: 0x060005D0 RID: 1488 RVA: 0x00074168 File Offset: 0x00072368
			public void clickedLine()
			{
				if (this.m_vsd != null)
				{
					GameEngine.Instance.playInterfaceSound("UserinfoScreenLine_village");
					Point villageLocation = GameEngine.Instance.World.getVillageLocation(this.m_vsd.villageID);
					GameEngine.Instance.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_WORLD;
					InterfaceMgr.Instance.closeParishPanel();
					InterfaceMgr.Instance.getMainTabBar().changeTab(0);
					GameEngine.Instance.World.startMultiStageZoom(10000.0, (double)villageLocation.X, (double)villageLocation.Y);
					InterfaceMgr.Instance.displaySelectedVillagePanel(this.m_vsd.villageID, false, true, true, false);
				}
			}

			// Token: 0x060005D1 RID: 1489 RVA: 0x00074210 File Offset: 0x00072410
			public void clickedCastle()
			{
				InterfaceMgr.Instance.closeParishPanel();
				InterfaceMgr.Instance.displaySelectedVillagePanel(this.m_vsd.villageID, false, true, true, false);
				GameEngine.Instance.SkipVillageTab();
				InterfaceMgr.Instance.getMainTabBar().changeTab(1);
				InterfaceMgr.Instance.getVillageTabBar().changeTab(1);
			}

			// Token: 0x04000739 RID: 1849
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x0400073A RID: 1850
			private CustomSelfDrawPanel.CSDLabel villageName = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400073B RID: 1851
			private CustomSelfDrawPanel.CSDLabel value1Label = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400073C RID: 1852
			private CustomSelfDrawPanel.CSDLabel value2Label = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400073D RID: 1853
			private CustomSelfDrawPanel.CSDLabel value3Label = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400073E RID: 1854
			private CustomSelfDrawPanel.CSDLabel value4Label = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400073F RID: 1855
			private CustomSelfDrawPanel.CSDLabel value5Label = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000740 RID: 1856
			private CustomSelfDrawPanel.CSDLabel value6Label = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000741 RID: 1857
			private CustomSelfDrawPanel.CSDLabel value1aLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000742 RID: 1858
			private CustomSelfDrawPanel.CSDLabel value2aLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000743 RID: 1859
			private CustomSelfDrawPanel.CSDLabel value3aLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000744 RID: 1860
			private CustomSelfDrawPanel.CSDLabel value4aLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000745 RID: 1861
			private CustomSelfDrawPanel.CSDLabel value5aLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000746 RID: 1862
			private CustomSelfDrawPanel.CSDLabel value6aLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000747 RID: 1863
			private CustomSelfDrawPanel.CSDLabel value1bLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000748 RID: 1864
			private CustomSelfDrawPanel.CSDLabel value2bLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000749 RID: 1865
			private CustomSelfDrawPanel.CSDLabel value3bLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400074A RID: 1866
			private CustomSelfDrawPanel.CSDLabel value4bLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400074B RID: 1867
			private CustomSelfDrawPanel.CSDLabel value5bLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400074C RID: 1868
			private CustomSelfDrawPanel.CSDLabel value6bLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400074D RID: 1869
			private CustomSelfDrawPanel.CSDLabel value1cLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400074E RID: 1870
			private CustomSelfDrawPanel.CSDLabel value2cLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400074F RID: 1871
			private CustomSelfDrawPanel.CSDLabel value3cLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000750 RID: 1872
			private CustomSelfDrawPanel.CSDLabel value4cLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000751 RID: 1873
			private CustomSelfDrawPanel.CSDLabel value5cLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000752 RID: 1874
			private CustomSelfDrawPanel.CSDLabel value6cLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000753 RID: 1875
			private CustomSelfDrawPanel.CSDLabel value1dLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000754 RID: 1876
			private CustomSelfDrawPanel.CSDLabel value2dLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000755 RID: 1877
			private CustomSelfDrawPanel.CSDLabel value3dLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000756 RID: 1878
			private CustomSelfDrawPanel.CSDLabel value4dLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000757 RID: 1879
			private CustomSelfDrawPanel.CSDLabel value5dLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000758 RID: 1880
			private CustomSelfDrawPanel.CSDLabel value6dLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000759 RID: 1881
			private CustomSelfDrawPanel.CSDLabel barracksLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400075A RID: 1882
			private CustomSelfDrawPanel.CSDLabel placedLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400075B RID: 1883
			private CustomSelfDrawPanel.CSDLabel attackingLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400075C RID: 1884
			private CustomSelfDrawPanel.CSDLabel reinforcingLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400075D RID: 1885
			private CustomSelfDrawPanel.CSDImage enclosedImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x0400075E RID: 1886
			private CustomSelfDrawPanel.CSDImage damageImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x0400075F RID: 1887
			private CustomSelfDrawPanel.CSDImage idImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04000760 RID: 1888
			private CustomSelfDrawPanel.CSDImage excomdImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04000761 RID: 1889
			private CustomSelfDrawPanel.CSDImage peaceImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04000762 RID: 1890
			private CustomSelfDrawPanel.CSDButton expandButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x04000763 RID: 1891
			private CustomSelfDrawPanel.CSDArea idRollover = new CustomSelfDrawPanel.CSDArea();

			// Token: 0x04000764 RID: 1892
			private CustomSelfDrawPanel.CSDArea peaceRollover = new CustomSelfDrawPanel.CSDArea();

			// Token: 0x04000765 RID: 1893
			private CustomSelfDrawPanel.CSDArea excomRollover = new CustomSelfDrawPanel.CSDArea();

			// Token: 0x04000766 RID: 1894
			private CustomSelfDrawPanel.CSDArea clickArea = new CustomSelfDrawPanel.CSDArea();

			// Token: 0x04000767 RID: 1895
			private int m_position = -1000;

			// Token: 0x04000768 RID: 1896
			private VillageSummaryData m_vsd;

			// Token: 0x04000769 RID: 1897
			private AllVillagesPanel m_parent;
		}

		// Token: 0x020000CE RID: 206
		public class NameComparer : IComparer<VillageSummaryData>
		{
			// Token: 0x060005D3 RID: 1491 RVA: 0x00074484 File Offset: 0x00072684
			public int Compare(VillageSummaryData x, VillageSummaryData y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return 0;
					}
					return -1;
				}
				else
				{
					if (y == null)
					{
						return 1;
					}
					string text = GameEngine.Instance.World.getVillageName(x.villageID).ToLowerInvariant();
					string strB = GameEngine.Instance.World.getVillageName(y.villageID).ToLowerInvariant();
					int num = text.CompareTo(strB);
					if (num != 0)
					{
						return num;
					}
					if (x.villageID < y.villageID)
					{
						return -1;
					}
					if (x.villageID > y.villageID)
					{
						return 1;
					}
					return 0;
				}
			}
		}
	}
}
