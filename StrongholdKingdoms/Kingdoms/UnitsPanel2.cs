using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020004AC RID: 1196
	public class UnitsPanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06002BB2 RID: 11186 RVA: 0x0002017C File Offset: 0x0001E37C
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06002BB3 RID: 11187 RVA: 0x0002018C File Offset: 0x0001E38C
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06002BB4 RID: 11188 RVA: 0x0002019C File Offset: 0x0001E39C
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06002BB5 RID: 11189 RVA: 0x000201AE File Offset: 0x0001E3AE
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06002BB6 RID: 11190 RVA: 0x000201BB File Offset: 0x0001E3BB
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closeDisbandPopup();
		}

		// Token: 0x06002BB7 RID: 11191 RVA: 0x000201D5 File Offset: 0x0001E3D5
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06002BB8 RID: 11192 RVA: 0x000201E2 File Offset: 0x0001E3E2
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06002BB9 RID: 11193 RVA: 0x000201EF File Offset: 0x0001E3EF
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002BBA RID: 11194 RVA: 0x0022738C File Offset: 0x0022558C
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			base.Name = "UnitsPanel2";
			this.MaximumSize = new Size(992, 566);
			this.MinimumSize = new Size(992, 566);
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x06002BBB RID: 11195 RVA: 0x002273F8 File Offset: 0x002255F8
		public UnitsPanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06002BBC RID: 11196 RVA: 0x002276D8 File Offset: 0x002258D8
		public void init()
		{
			UnitsPanel2.instance = this;
			base.clearControls();
			this.mainBackgroundImage.Image = GFXLibrary.people_background;
			this.mainBackgroundImage.Position = new Point(0, 0);
			base.addControl(this.mainBackgroundImage);
			this.mainBackgroundArea.Position = new Point(0, 0);
			this.mainBackgroundArea.Size = new Size(992, 566);
			this.mainBackgroundImage.addControl(this.mainBackgroundArea);
			InterfaceMgr.Instance.setVillageHeading(SK.Text("UnitsPanel_Units", "Units"));
			this.closeButton.ImageNorm = GFXLibrary.int_button_close_normal;
			this.closeButton.ImageOver = GFXLibrary.int_button_close_over;
			this.closeButton.ImageClick = GFXLibrary.int_button_close_in;
			this.closeButton.Position = new Point(948, 10);
			this.closeButton.CustomTooltipID = 701;
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "UnitsPanel2_close");
			this.mainBackgroundImage.addControl(this.closeButton);
			CustomSelfDrawPanel.WikiLinkControl.init(this.mainBackgroundArea, 6, new Point(898, 10));
			this.troop1Image.Image = GFXLibrary.people_01;
			this.troop1Image.Position = new Point(140, 48);
			this.mainBackgroundArea.addControl(this.troop1Image);
			this.troopsMade1Label.Text = "0";
			this.troopsMade1Label.Color = Color.FromArgb(208, 165, 102);
			this.troopsMade1Label.Position = new Point(67, 5);
			this.troopsMade1Label.Size = new Size(87, 28);
			this.troopsMade1Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopsMade1Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.troop1Image.addControl(this.troopsMade1Label);
			this.troopsMade1Disband.Position = new Point(0, 0);
			this.troopsMade1Disband.Size = this.troopsMade1Label.Size;
			this.troopsMade1Disband.Data = 1;
			this.troopsMade1Disband.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.disbandTroopsClick), "UnitsPanel2_disband_monks");
			this.troopsMade1Disband.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.disbandTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.disbandTroopLeave));
			this.troopsMade1Disband.CustomTooltipID = 600;
			this.troopsMade1Label.addControl(this.troopsMade1Disband);
			this.troopGoldCost1Label.Text = "0";
			this.troopGoldCost1Label.Color = Color.FromArgb(208, 165, 102);
			this.troopGoldCost1Label.Position = new Point(59, 137);
			this.troopGoldCost1Label.Size = new Size(44, 47);
			this.troopGoldCost1Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopGoldCost1Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.troop1Image.addControl(this.troopGoldCost1Label);
			this.troopMake1Button.ImageNorm = GFXLibrary.int_but_delete_norm;
			this.troopMake1Button.ImageOver = GFXLibrary.int_but_delete_over;
			this.troopMake1Button.Position = new Point(10, 189);
			this.troopMake1Button.Text.Text = "0";
			this.troopMake1Button.TextYOffset = 1;
			this.troopMake1Button.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopMake1Button.Text.Color = global::ARGBColors.Black;
			this.troopMake1Button.Data = 1;
			this.troopMake1Button.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake1Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
			this.troopMake1ButtonA.ImageNorm = GFXLibrary.button3comp_left_normal;
			this.troopMake1ButtonA.ImageOver = GFXLibrary.button3comp_left_over;
			this.troopMake1ButtonA.ImageClick = GFXLibrary.button3comp_left_pressed;
			this.troopMake1ButtonA.Position = new Point(10, 195);
			this.troopMake1ButtonA.Text.Text = "0";
			this.troopMake1ButtonA.TextYOffset = 1;
			this.troopMake1ButtonA.Text.Size = new Size(this.troopMake1ButtonA.Width - 5, this.troopMake1ButtonA.Height);
			this.troopMake1ButtonA.Text.Position = new Point(5, 0);
			this.troopMake1ButtonA.Text.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.troopMake1ButtonA.Text.Color = global::ARGBColors.Black;
			this.troopMake1ButtonA.Data = 1;
			this.troopMake1ButtonA.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake1ButtonA.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
			this.troop1Image.addControl(this.troopMake1ButtonA);
			this.troopMake1ButtonX.ImageNorm = GFXLibrary.button3comp_mid_normal;
			this.troopMake1ButtonX.ImageOver = GFXLibrary.button3comp_mid_over;
			this.troopMake1ButtonX.ImageClick = GFXLibrary.button3comp_mid_pushed;
			this.troopMake1ButtonX.Position = new Point(60, 195);
			this.troopMake1ButtonX.Text.Text = "0";
			this.troopMake1ButtonX.TextYOffset = 1;
			this.troopMake1ButtonX.Text.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.troopMake1ButtonX.Text.Color = global::ARGBColors.Black;
			this.troopMake1ButtonX.Data = 11;
			this.troopMake1ButtonX.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake1ButtonX.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
			this.troop1Image.addControl(this.troopMake1ButtonX);
			this.troopMake1ButtonB.ImageNorm = GFXLibrary.button3comp_right_normal;
			this.troopMake1ButtonB.ImageOver = GFXLibrary.button3comp_right_over;
			this.troopMake1ButtonB.ImageClick = GFXLibrary.button3comp_right_pushed;
			this.troopMake1ButtonB.Position = new Point(108, 195);
			this.troopMake1ButtonB.Text.Text = "0";
			this.troopMake1ButtonB.TextYOffset = 1;
			this.troopMake1ButtonB.Text.Size = new Size(this.troopMake1ButtonB.Width - 5, this.troopMake1ButtonB.Height);
			this.troopMake1ButtonB.Text.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.troopMake1ButtonB.Text.Color = global::ARGBColors.Black;
			this.troopMake1ButtonB.Data = 21;
			this.troopMake1ButtonB.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake1ButtonB.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
			this.troop1Image.addControl(this.troopMake1ButtonB);
			this.troopGold1Image.Image = GFXLibrary.com_32_money;
			this.troopGold1Image.Position = new Point(107, 145);
			this.troop1Image.addControl(this.troopGold1Image);
			this.troop1WeaponImage.Image = GFXLibrary.people_unitspace_icon_01;
			this.troop1WeaponImage.Position = new Point(107, 113);
			this.troop1WeaponImage.CustomTooltipID = 702;
			this.troop1Image.addControl(this.troop1WeaponImage);
			this.troopUnitSize1Label.Text = "0";
			this.troopUnitSize1Label.Color = Color.FromArgb(208, 165, 102);
			this.troopUnitSize1Label.Position = new Point(59, 107);
			this.troopUnitSize1Label.Size = new Size(44, 47);
			this.troopUnitSize1Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopUnitSize1Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.troop1Image.addControl(this.troopUnitSize1Label);
			this.troop2Image.Image = GFXLibrary.people_02;
			this.troop2Image.Position = new Point(410, 48);
			this.mainBackgroundArea.addControl(this.troop2Image);
			this.troopsMade2Label.Text = "0";
			this.troopsMade2Label.Color = Color.FromArgb(208, 165, 102);
			this.troopsMade2Label.Position = new Point(67, 5);
			this.troopsMade2Label.Size = new Size(87, 28);
			this.troopsMade2Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopsMade2Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.troop2Image.addControl(this.troopsMade2Label);
			this.troopsMade2Disband.Position = new Point(0, 0);
			this.troopsMade2Disband.Size = this.troopsMade2Label.Size;
			this.troopsMade2Disband.Data = 2;
			this.troopsMade2Disband.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.disbandTroopsClick), "UnitsPanel2_disband_traders");
			this.troopsMade2Disband.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.disbandTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.disbandTroopLeave));
			this.troopsMade2Disband.CustomTooltipID = 600;
			this.troopsMade2Label.addControl(this.troopsMade2Disband);
			this.troopGoldCost2Label.Text = "0";
			this.troopGoldCost2Label.Color = Color.FromArgb(208, 165, 102);
			this.troopGoldCost2Label.Position = new Point(59, 137);
			this.troopGoldCost2Label.Size = new Size(44, 47);
			this.troopGoldCost2Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopGoldCost2Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.troop2Image.addControl(this.troopGoldCost2Label);
			this.troopMake2Button.ImageNorm = GFXLibrary.int_but_delete_norm;
			this.troopMake2Button.ImageOver = GFXLibrary.int_but_delete_over;
			this.troopMake2Button.Position = new Point(10, 189);
			this.troopMake2Button.Text.Text = "0";
			this.troopMake2Button.TextYOffset = 1;
			this.troopMake2Button.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopMake2Button.Text.Color = global::ARGBColors.Black;
			this.troopMake2Button.Data = 2;
			this.troopMake2Button.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake2Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
			this.troopMake2ButtonA.ImageNorm = GFXLibrary.button3comp_left_normal;
			this.troopMake2ButtonA.ImageOver = GFXLibrary.button3comp_left_over;
			this.troopMake2ButtonA.ImageClick = GFXLibrary.button3comp_left_pressed;
			this.troopMake2ButtonA.Position = new Point(10, 195);
			this.troopMake2ButtonA.Text.Text = "0";
			this.troopMake2ButtonA.TextYOffset = 1;
			this.troopMake2ButtonA.Text.Size = new Size(this.troopMake2ButtonA.Width - 5, this.troopMake2ButtonA.Height);
			this.troopMake2ButtonA.Text.Position = new Point(5, 0);
			this.troopMake2ButtonA.Text.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.troopMake2ButtonA.Text.Color = global::ARGBColors.Black;
			this.troopMake2ButtonA.Data = 2;
			this.troopMake2ButtonA.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake2ButtonA.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
			this.troop2Image.addControl(this.troopMake2ButtonA);
			this.troopMake2ButtonX.ImageNorm = GFXLibrary.button3comp_mid_normal;
			this.troopMake2ButtonX.ImageOver = GFXLibrary.button3comp_mid_over;
			this.troopMake2ButtonX.ImageClick = GFXLibrary.button3comp_mid_pushed;
			this.troopMake2ButtonX.Position = new Point(60, 195);
			this.troopMake2ButtonX.Text.Text = "0";
			this.troopMake2ButtonX.TextYOffset = 1;
			this.troopMake2ButtonX.Text.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.troopMake2ButtonX.Text.Color = global::ARGBColors.Black;
			this.troopMake2ButtonX.Data = 12;
			this.troopMake2ButtonX.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake2ButtonX.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
			this.troop2Image.addControl(this.troopMake2ButtonX);
			this.troopMake2ButtonB.ImageNorm = GFXLibrary.button3comp_right_normal;
			this.troopMake2ButtonB.ImageOver = GFXLibrary.button3comp_right_over;
			this.troopMake2ButtonB.ImageClick = GFXLibrary.button3comp_right_pushed;
			this.troopMake2ButtonB.Position = new Point(108, 195);
			this.troopMake2ButtonB.Text.Text = "0";
			this.troopMake2ButtonB.TextYOffset = 1;
			this.troopMake2ButtonB.Text.Size = new Size(this.troopMake2ButtonB.Width - 5, this.troopMake2ButtonB.Height);
			this.troopMake2ButtonB.Text.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.troopMake2ButtonB.Text.Color = global::ARGBColors.Black;
			this.troopMake2ButtonB.Data = 22;
			this.troopMake2ButtonB.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake2ButtonB.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
			this.troop2Image.addControl(this.troopMake2ButtonB);
			this.troopGold2Image.Image = GFXLibrary.com_32_money;
			this.troopGold2Image.Position = new Point(107, 145);
			this.troop2Image.addControl(this.troopGold2Image);
			this.troop2WeaponImage.Image = GFXLibrary.people_unitspace_icon_02;
			this.troop2WeaponImage.Position = new Point(107, 113);
			this.troop2WeaponImage.CustomTooltipID = 702;
			this.troop2Image.addControl(this.troop2WeaponImage);
			this.troopUnitSize2Label.Text = "0";
			this.troopUnitSize2Label.Color = Color.FromArgb(208, 165, 102);
			this.troopUnitSize2Label.Position = new Point(59, 107);
			this.troopUnitSize2Label.Size = new Size(44, 47);
			this.troopUnitSize2Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopUnitSize2Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.troop2Image.addControl(this.troopUnitSize2Label);
			this.troop3Image.Image = GFXLibrary.people_03;
			this.troop3Image.Position = new Point(410, 48);
			this.mainBackgroundArea.addControl(this.troop3Image);
			this.troopsMade3Label.Text = "0";
			this.troopsMade3Label.Color = Color.FromArgb(208, 165, 102);
			this.troopsMade3Label.Position = new Point(67, 5);
			this.troopsMade3Label.Size = new Size(87, 28);
			this.troopsMade3Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopsMade3Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.troop3Image.addControl(this.troopsMade3Label);
			this.troopsMade3Disband.Position = new Point(0, 0);
			this.troopsMade3Disband.Size = this.troopsMade3Label.Size;
			this.troopsMade3Disband.Data = 3;
			this.troopsMade3Disband.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.disbandTroopsClick));
			this.troopsMade3Disband.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.disbandTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.disbandTroopLeave));
			this.troopsMade3Disband.CustomTooltipID = 600;
			this.troopsMade3Label.addControl(this.troopsMade3Disband);
			this.troopGoldCost3Label.Text = "0";
			this.troopGoldCost3Label.Color = Color.FromArgb(208, 165, 102);
			this.troopGoldCost3Label.Position = new Point(59, 137);
			this.troopGoldCost3Label.Size = new Size(44, 47);
			this.troopGoldCost3Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopGoldCost3Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.troop3Image.addControl(this.troopGoldCost3Label);
			this.troopMake3Button.ImageNorm = GFXLibrary.int_but_delete_norm;
			this.troopMake3Button.ImageOver = GFXLibrary.int_but_delete_over;
			this.troopMake3Button.Position = new Point(10, 189);
			this.troopMake3Button.Text.Text = "0";
			this.troopMake3Button.TextYOffset = 1;
			this.troopMake3Button.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopMake3Button.Text.Color = global::ARGBColors.Black;
			this.troopMake3Button.Data = 3;
			this.troopMake3Button.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake3Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
			this.troop3Image.addControl(this.troopMake3Button);
			this.troopGold3Image.Image = GFXLibrary.com_32_money;
			this.troopGold3Image.Position = new Point(107, 145);
			this.troop3Image.addControl(this.troopGold3Image);
			this.troop3WeaponImage.Image = GFXLibrary.people_unitspace_icon_03;
			this.troop3WeaponImage.Position = new Point(107, 113);
			this.troop3WeaponImage.CustomTooltipID = 702;
			this.troop3Image.addControl(this.troop3WeaponImage);
			this.troopUnitSize3Label.Text = "0";
			this.troopUnitSize3Label.Color = Color.FromArgb(208, 165, 102);
			this.troopUnitSize3Label.Position = new Point(59, 107);
			this.troopUnitSize3Label.Size = new Size(44, 47);
			this.troopUnitSize3Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopUnitSize3Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.troop3Image.addControl(this.troopUnitSize3Label);
			this.troop4Image.Image = GFXLibrary.people_04;
			this.troop4Image.Position = new Point(680, 48);
			this.mainBackgroundArea.addControl(this.troop4Image);
			this.troopsMade4Label.Text = "0";
			this.troopsMade4Label.Color = Color.FromArgb(208, 165, 102);
			this.troopsMade4Label.Position = new Point(67, 5);
			this.troopsMade4Label.Size = new Size(87, 28);
			this.troopsMade4Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopsMade4Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.troop4Image.addControl(this.troopsMade4Label);
			this.troopsMade4Disband.Position = new Point(0, 0);
			this.troopsMade4Disband.Size = this.troopsMade4Label.Size;
			this.troopsMade4Disband.Data = 4;
			this.troopsMade4Disband.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.disbandTroopsClick), "UnitsPanel2_disband_scouts");
			this.troopsMade4Disband.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.disbandTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.disbandTroopLeave));
			this.troopsMade4Disband.CustomTooltipID = 600;
			this.troopsMade4Label.addControl(this.troopsMade4Disband);
			this.troopGoldCost4Label.Text = "0";
			this.troopGoldCost4Label.Color = Color.FromArgb(208, 165, 102);
			this.troopGoldCost4Label.Position = new Point(59, 137);
			this.troopGoldCost4Label.Size = new Size(44, 47);
			this.troopGoldCost4Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopGoldCost4Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.troop4Image.addControl(this.troopGoldCost4Label);
			this.troopMake4Button.ImageNorm = GFXLibrary.int_but_delete_norm;
			this.troopMake4Button.ImageOver = GFXLibrary.int_but_delete_over;
			this.troopMake4Button.Position = new Point(10, 193);
			this.troopMake4Button.Text.Text = "0";
			this.troopMake4Button.TextYOffset = 1;
			this.troopMake4Button.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopMake4Button.Text.Color = global::ARGBColors.Black;
			this.troopMake4Button.Data = 4;
			this.troopMake4Button.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake4Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
			this.troopMake4ButtonA.ImageNorm = GFXLibrary.button3comp_left_normal;
			this.troopMake4ButtonA.ImageOver = GFXLibrary.button3comp_left_over;
			this.troopMake4ButtonA.ImageClick = GFXLibrary.button3comp_left_pressed;
			this.troopMake4ButtonA.Position = new Point(10, 195);
			this.troopMake4ButtonA.Text.Text = "0";
			this.troopMake4ButtonA.TextYOffset = 1;
			this.troopMake4ButtonA.Text.Size = new Size(this.troopMake4ButtonA.Width - 5, this.troopMake4ButtonA.Height);
			this.troopMake4ButtonA.Text.Position = new Point(5, 0);
			this.troopMake4ButtonA.Text.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.troopMake4ButtonA.Text.Color = global::ARGBColors.Black;
			this.troopMake4ButtonA.Data = 4;
			this.troopMake4ButtonA.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake4ButtonA.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
			this.troop4Image.addControl(this.troopMake4ButtonA);
			this.troopMake4ButtonX.ImageNorm = GFXLibrary.button3comp_mid_normal;
			this.troopMake4ButtonX.ImageOver = GFXLibrary.button3comp_mid_over;
			this.troopMake4ButtonX.ImageClick = GFXLibrary.button3comp_mid_pushed;
			this.troopMake4ButtonX.Position = new Point(60, 195);
			this.troopMake4ButtonX.Text.Text = "0";
			this.troopMake4ButtonX.TextYOffset = 1;
			this.troopMake4ButtonX.Text.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.troopMake4ButtonX.Text.Color = global::ARGBColors.Black;
			this.troopMake4ButtonX.Data = 14;
			this.troopMake4ButtonX.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake4ButtonX.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
			this.troop4Image.addControl(this.troopMake4ButtonX);
			this.troopMake4ButtonB.ImageNorm = GFXLibrary.button3comp_right_normal;
			this.troopMake4ButtonB.ImageOver = GFXLibrary.button3comp_right_over;
			this.troopMake4ButtonB.ImageClick = GFXLibrary.button3comp_right_pushed;
			this.troopMake4ButtonB.Position = new Point(108, 195);
			this.troopMake4ButtonB.Text.Text = "0";
			this.troopMake4ButtonB.TextYOffset = 1;
			this.troopMake4ButtonB.Text.Size = new Size(this.troopMake4ButtonB.Width - 5, this.troopMake4ButtonB.Height);
			this.troopMake4ButtonB.Text.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.troopMake4ButtonB.Text.Color = global::ARGBColors.Black;
			this.troopMake4ButtonB.Data = 24;
			this.troopMake4ButtonB.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake4ButtonB.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
			this.troop4Image.addControl(this.troopMake4ButtonB);
			this.troopGold4Image.Image = GFXLibrary.com_32_money;
			this.troopGold4Image.Position = new Point(107, 145);
			this.troop4Image.addControl(this.troopGold4Image);
			this.troop4WeaponImage.Image = GFXLibrary.people_unitspace_icon_04;
			this.troop4WeaponImage.Position = new Point(107, 113);
			this.troop4WeaponImage.CustomTooltipID = 702;
			this.troop4Image.addControl(this.troop4WeaponImage);
			this.troopUnitSize4Label.Text = "0";
			this.troopUnitSize4Label.Color = Color.FromArgb(208, 165, 102);
			this.troopUnitSize4Label.Position = new Point(59, 107);
			this.troopUnitSize4Label.Size = new Size(44, 47);
			this.troopUnitSize4Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopUnitSize4Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.troop4Image.addControl(this.troopUnitSize4Label);
			this.troop5Image.Image = GFXLibrary.people_05;
			this.troop5Image.Position = new Point(770, 48);
			this.mainBackgroundArea.addControl(this.troop5Image);
			this.troopsMade5Label.Text = "0";
			this.troopsMade5Label.Color = Color.FromArgb(208, 165, 102);
			this.troopsMade5Label.Position = new Point(67, 5);
			this.troopsMade5Label.Size = new Size(87, 28);
			this.troopsMade5Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopsMade5Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.troop5Image.addControl(this.troopsMade5Label);
			this.troopsMade5Disband.Position = new Point(0, 0);
			this.troopsMade5Disband.Size = this.troopsMade5Label.Size;
			this.troopsMade5Disband.Data = 5;
			this.troopsMade5Disband.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.disbandTroopsClick));
			this.troopsMade5Disband.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.disbandTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.disbandTroopLeave));
			this.troopsMade5Disband.CustomTooltipID = 600;
			this.troopsMade5Label.addControl(this.troopsMade5Disband);
			this.troopGoldCost5Label.Text = "0";
			this.troopGoldCost5Label.Color = Color.FromArgb(208, 165, 102);
			this.troopGoldCost5Label.Position = new Point(59, 137);
			this.troopGoldCost5Label.Size = new Size(44, 47);
			this.troopGoldCost5Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopGoldCost5Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.troop5Image.addControl(this.troopGoldCost5Label);
			this.troopMake5Button.ImageNorm = GFXLibrary.int_but_delete_norm;
			this.troopMake5Button.ImageOver = GFXLibrary.int_but_delete_over;
			this.troopMake5Button.Position = new Point(10, 189);
			this.troopMake5Button.Text.Text = "0";
			this.troopMake5Button.TextYOffset = 1;
			this.troopMake5Button.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopMake5Button.Text.Color = global::ARGBColors.Black;
			this.troopMake5Button.Data = 5;
			this.troopMake5Button.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake5Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
			this.troop5Image.addControl(this.troopMake5Button);
			this.troopGold5Image.Image = GFXLibrary.com_32_money;
			this.troopGold5Image.Position = new Point(107, 145);
			this.troop5Image.addControl(this.troopGold5Image);
			this.troop5WeaponImage.Image = GFXLibrary.people_unitspace_icon_05;
			this.troop5WeaponImage.Position = new Point(107, 113);
			this.troop5WeaponImage.CustomTooltipID = 702;
			this.troop5Image.addControl(this.troop5WeaponImage);
			this.troopUnitSize5Label.Text = "0";
			this.troopUnitSize5Label.Color = Color.FromArgb(208, 165, 102);
			this.troopUnitSize5Label.Position = new Point(59, 107);
			this.troopUnitSize5Label.Size = new Size(44, 47);
			this.troopUnitSize5Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopUnitSize5Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.troop5Image.addControl(this.troopUnitSize5Label);
			int num = 73;
			this.item1Image.Image = GFXLibrary.com_32_people;
			this.item1Image.Position = new Point(num + 7, 310);
			this.mainBackgroundArea.addControl(this.item1Image);
			this.item1AmountLabel.Text = "0";
			this.item1AmountLabel.Color = global::ARGBColors.Black;
			this.item1AmountLabel.Position = new Point(num - 3, 352);
			this.item1AmountLabel.Size = new Size(50, 20);
			this.item1AmountLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.item1AmountLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.mainBackgroundArea.addControl(this.item1AmountLabel);
			this.typeLabel.Text = "";
			this.typeLabel.Color = global::ARGBColors.Black;
			this.typeLabel.Position = new Point(num + 80, 348);
			this.typeLabel.Size = new Size(250, 20);
			this.typeLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.typeLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.mainBackgroundArea.addControl(this.typeLabel);
			this.SpaceLabel.Text = SK.Text("BARRACKS_Spare_Unit_Space", "Spare Unit Space") + ": 0";
			this.SpaceLabel.Color = global::ARGBColors.Black;
			this.SpaceLabel.Position = new Point(560, 334);
			if (Program.mySettings.LanguageIdent == "pl" || Program.mySettings.LanguageIdent == "it" || Program.mySettings.LanguageIdent == "pt")
			{
				this.SpaceLabel.Size = new Size(420, 20);
			}
			else
			{
				this.SpaceLabel.Size = new Size(220, 20);
			}
			this.SpaceLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.SpaceLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.mainBackgroundArea.addControl(this.SpaceLabel);
			this.fullBar.setImages(GFXLibrary.barracks_fillbar_back, GFXLibrary.barracks_fillbar_fill_left, GFXLibrary.barracks_fillbar_fill_mid, GFXLibrary.barracks_fillbar_fill_right, GFXLibrary.barracks_fillbar_back, GFXLibrary.barracks_fillbar_fill_left, GFXLibrary.barracks_fillbar_fill_mid, GFXLibrary.barracks_fillbar_fill_right);
			this.fullBar.Number = 0.0;
			this.fullBar.MaxValue = 9.0;
			this.fullBar.SetMargin(2, 2, 2, 3);
			if (Program.mySettings.LanguageIdent == "pl" || Program.mySettings.LanguageIdent == "it" || Program.mySettings.LanguageIdent == "pt")
			{
				this.fullBar.Position = new Point(770, 359);
			}
			else
			{
				this.fullBar.Position = new Point(770, 339);
			}
			this.mainBackgroundArea.addControl(this.fullBar);
			this.troop3Image.Visible = false;
			this.troop5Image.Visible = false;
			this.troop1Image.Alpha = 0.3f;
			this.troop2Image.Alpha = 0.3f;
			this.troop4Image.Alpha = 0.3f;
			this.cardbar.Position = new Point(0, 0);
			this.mainBackgroundImage.addControl(this.cardbar);
			this.cardbar.init(5);
			byte research_Ordination = GameEngine.Instance.World.UserResearchData.Research_Ordination;
			byte research_Merchant_Guilds = GameEngine.Instance.World.UserResearchData.Research_Merchant_Guilds;
			byte research_Scouts = GameEngine.Instance.World.UserResearchData.Research_Scouts;
			this.update();
		}

		// Token: 0x06002BBD RID: 11197 RVA: 0x0002020E File Offset: 0x0001E40E
		public void update()
		{
			this.updateValues();
			this.cardbar.update();
		}

		// Token: 0x06002BBE RID: 11198 RVA: 0x0000B71E File Offset: 0x0000991E
		public void closeClick()
		{
			InterfaceMgr.Instance.setVillageTabSubMode(-1);
		}

		// Token: 0x06002BBF RID: 11199 RVA: 0x00229A18 File Offset: 0x00227C18
		public void updateValues()
		{
			NumberFormatInfo nfi = GameEngine.NFI;
			WorldData localWorldData = GameEngine.Instance.LocalWorldData;
			VillageMap village = GameEngine.Instance.Village;
			CastleMap castle = GameEngine.Instance.Castle;
			if (village != null && castle != null)
			{
				int locallyMade_Scouts = village.LocallyMade_Scouts;
				int num = village.m_spareWorkers - locallyMade_Scouts;
				this.item1AmountLabel.Text = num.ToString("N", nfi);
				if (num == 0 && this.mouseOver >= 0)
				{
					this.item1Image.Colorise = Color.FromArgb(255, 128, 128);
				}
				else
				{
					this.item1Image.Colorise = global::ARGBColors.White;
				}
				int num2 = (int)GameEngine.Instance.World.getCurrentGold();
				num2 -= locallyMade_Scouts * localWorldData.ScoutGoldCost;
				village.calcTotalTroops();
				int num3 = village.calcUnitUsages() + locallyMade_Scouts * GameEngine.Instance.LocalWorldData.UnitSize_Scout;
				int num4 = village.calcTotalTraders();
				int num5 = village.calcTotalMonks();
				int num6 = village.calcTotalScouts() + locallyMade_Scouts;
				this.numMonk = Math.Min(num, num2 / localWorldData.getMonkCost(num5));
				this.numTrader = Math.Min(num, num2 / localWorldData.TraderGoldCost);
				this.numScouts = Math.Min(num, num2 / localWorldData.ScoutGoldCost);
				this.numSpies = 0;
				int num7 = ResearchData.scoutResearchScoutsLevels[(int)GameEngine.Instance.World.userResearchData.Research_Scouts];
				int num8 = village.countWorkingMarkets() * ResearchData.numMerchantGuildsTraders[(int)GameEngine.Instance.World.userResearchData.Research_Merchant_Guilds];
				int num9 = ResearchData.ordinationResearchMonkLevels[(int)GameEngine.Instance.World.userResearchData.Research_Ordination];
				if (this.numScouts > num7)
				{
					this.numScouts = num7;
				}
				if (this.numTrader > num8)
				{
					this.numTrader = num8;
				}
				if (this.numMonk > num9)
				{
					this.numMonk = num9;
				}
				if (num8 - num4 < this.numTrader)
				{
					this.numTrader = num8 - num4;
				}
				if (num7 - num6 < this.numScouts)
				{
					this.numScouts = num7 - num6;
				}
				if (num9 - num5 < this.numMonk)
				{
					this.numMonk = num9 - num5;
				}
				if (this.numTrader < 0)
				{
					this.numTrader = 0;
				}
				if (this.numScouts < 0)
				{
					this.numScouts = 0;
				}
				if (this.numMonk < 0)
				{
					this.numMonk = 0;
				}
				this.SpaceLabel.Text = SK.Text("BARRACKS_Spare_Unit_Space", "Spare Unit Space") + ": " + Math.Max(GameEngine.Instance.LocalWorldData.Village_UnitCapacity - num3, 0).ToString("N", nfi);
				this.troopUnitSize1Label.Text = GameEngine.Instance.LocalWorldData.UnitSize_Priests.ToString();
				this.troopUnitSize2Label.Text = GameEngine.Instance.LocalWorldData.UnitSize_Trader.ToString();
				this.troopUnitSize3Label.Text = GameEngine.Instance.LocalWorldData.UnitSize_Spies.ToString();
				this.troopUnitSize4Label.Text = GameEngine.Instance.LocalWorldData.UnitSize_Scout.ToString();
				this.troop1WeaponImage.CustomTooltipData = GameEngine.Instance.LocalWorldData.UnitSize_Priests;
				this.troop2WeaponImage.CustomTooltipData = GameEngine.Instance.LocalWorldData.UnitSize_Trader;
				this.troop3WeaponImage.CustomTooltipData = GameEngine.Instance.LocalWorldData.UnitSize_Spies;
				this.troop4WeaponImage.CustomTooltipData = GameEngine.Instance.LocalWorldData.UnitSize_Scout;
				while (this.numMonk > 0)
				{
					if (num3 + GameEngine.Instance.LocalWorldData.UnitSize_Priests * this.numMonk <= GameEngine.Instance.LocalWorldData.Village_UnitCapacity)
					{
						break;
					}
					this.numMonk--;
				}
				while (this.numTrader > 0 && num3 + GameEngine.Instance.LocalWorldData.UnitSize_Trader * this.numTrader > GameEngine.Instance.LocalWorldData.Village_UnitCapacity)
				{
					this.numTrader--;
				}
				if (num3 + GameEngine.Instance.LocalWorldData.UnitSize_Spies > GameEngine.Instance.LocalWorldData.Village_UnitCapacity)
				{
					this.numSpies = 0;
				}
				while (this.numScouts > 0 && num3 + GameEngine.Instance.LocalWorldData.UnitSize_Scout * this.numScouts > GameEngine.Instance.LocalWorldData.Village_UnitCapacity)
				{
					this.numScouts--;
				}
				if (num3 >= GameEngine.Instance.LocalWorldData.Village_UnitCapacity)
				{
					this.numMonk = 0;
					this.numScouts = 0;
					this.numSpies = 0;
					this.numTrader = 0;
				}
				if (GameEngine.Instance.World.UserResearchData.Research_Ordination == 0)
				{
					this.numMonk = 0;
					this.troop1Image.Alpha = 0.3f;
					this.troopMake1ButtonA.Visible = false;
					this.troopMake1ButtonB.Visible = false;
					this.troopMake1ButtonX.Visible = false;
					this.troop1Image.CustomTooltipID = 707;
					this.troopsMade1Disband.Visible = false;
				}
				else
				{
					this.troop1Image.Alpha = 1f;
					this.troopMake1ButtonA.Visible = true;
					this.troopMake1ButtonB.Visible = true;
					this.troopMake1ButtonX.Visible = true;
					this.troop1Image.CustomTooltipID = 704;
					this.troopsMade1Disband.Visible = true;
				}
				if (GameEngine.Instance.World.UserResearchData.Research_Merchant_Guilds == 0)
				{
					this.numTrader = 0;
					this.troop2Image.Alpha = 0.3f;
					this.troopMake2ButtonA.Visible = false;
					this.troopMake2ButtonB.Visible = false;
					this.troopMake2ButtonX.Visible = false;
					this.troop2Image.CustomTooltipID = 706;
					this.troopsMade2Disband.Visible = false;
				}
				else
				{
					this.troop2Image.Alpha = 1f;
					this.troopMake2ButtonA.Visible = true;
					this.troopMake2ButtonB.Visible = true;
					this.troopMake2ButtonX.Visible = true;
					this.troop2Image.CustomTooltipID = 703;
					this.troopsMade2Disband.Visible = true;
				}
				this.numSpies = 0;
				this.troop3Image.Visible = false;
				if (GameEngine.Instance.World.UserResearchData.Research_Scouts == 0)
				{
					this.numScouts = 0;
					this.troop4Image.Alpha = 0.3f;
					this.troopMake4ButtonA.Visible = false;
					this.troopMake4ButtonB.Visible = false;
					this.troopMake4ButtonX.Visible = false;
					this.troop4Image.CustomTooltipID = 708;
					this.troopsMade4Disband.Visible = false;
				}
				else
				{
					this.troop4Image.Alpha = 1f;
					this.troopMake4ButtonA.Visible = true;
					this.troopMake4ButtonB.Visible = true;
					this.troopMake4ButtonX.Visible = true;
					this.troop4Image.CustomTooltipID = 705;
					this.troopsMade4Disband.Visible = true;
				}
				this.troop5Image.Visible = false;
				if (this.numMonk > 0)
				{
					this.troopMake1Button.Active = true;
					this.troopMake1Button.Alpha = 1f;
					this.troopMake1ButtonA.Active = true;
					this.troopMake1ButtonA.Alpha = 1f;
					this.troopMake1ButtonB.Active = true;
					this.troopMake1ButtonB.Alpha = 1f;
					this.troopMake1ButtonX.Active = true;
					this.troopMake1ButtonX.Alpha = 1f;
					this.troopMake1Button.CustomTooltipID = 0;
					this.troopMake1ButtonA.CustomTooltipID = 0;
					this.troopMake1ButtonB.CustomTooltipID = 0;
					this.troopMake1ButtonX.CustomTooltipID = 0;
				}
				else
				{
					this.troopMake1Button.Active = false;
					this.troopMake1Button.Alpha = 0.5f;
					this.troopMake1ButtonA.Active = false;
					this.troopMake1ButtonA.Alpha = 0.5f;
					this.troopMake1ButtonB.Active = false;
					this.troopMake1ButtonB.Alpha = 0.5f;
					this.troopMake1ButtonX.Active = false;
					this.troopMake1ButtonX.Alpha = 0.5f;
					int num10 = 0;
					if (num == 0)
					{
						num10 |= 1;
					}
					if (num2 < localWorldData.getMonkCost(num5))
					{
						num10 |= 2;
					}
					if (num9 - num5 <= 0)
					{
						num10 |= 8;
					}
					if (num3 + GameEngine.Instance.LocalWorldData.UnitSize_Priests > GameEngine.Instance.LocalWorldData.Village_UnitCapacity)
					{
						num10 |= 4;
					}
					this.troopMake1Button.CustomTooltipID = 2700;
					this.troopMake1ButtonA.CustomTooltipID = 2700;
					this.troopMake1ButtonB.CustomTooltipID = 2700;
					this.troopMake1ButtonX.CustomTooltipID = 2700;
					this.troopMake1Button.CustomTooltipData = num10;
					this.troopMake1ButtonA.CustomTooltipData = num10;
					this.troopMake1ButtonB.CustomTooltipData = num10;
					this.troopMake1ButtonX.CustomTooltipData = num10;
				}
				if (this.numTrader > 0)
				{
					this.troopMake2Button.Active = true;
					this.troopMake2Button.Alpha = 1f;
					this.troopMake2ButtonA.Active = true;
					this.troopMake2ButtonA.Alpha = 1f;
					this.troopMake2ButtonB.Active = true;
					this.troopMake2ButtonB.Alpha = 1f;
					this.troopMake2ButtonX.Active = true;
					this.troopMake2ButtonX.Alpha = 1f;
					this.troopMake2Button.CustomTooltipID = 0;
					this.troopMake2ButtonA.CustomTooltipID = 0;
					this.troopMake2ButtonB.CustomTooltipID = 0;
					this.troopMake2ButtonX.CustomTooltipID = 0;
				}
				else
				{
					this.troopMake2Button.Active = false;
					this.troopMake2Button.Alpha = 0.5f;
					this.troopMake2ButtonA.Active = false;
					this.troopMake2ButtonA.Alpha = 0.5f;
					this.troopMake2ButtonB.Active = false;
					this.troopMake2ButtonB.Alpha = 0.5f;
					this.troopMake2ButtonX.Active = false;
					this.troopMake2ButtonX.Alpha = 0.5f;
					int num11 = 0;
					if (num == 0)
					{
						num11 |= 1;
					}
					if (num2 < localWorldData.TraderGoldCost)
					{
						num11 |= 2;
					}
					if (num8 - num4 <= 0)
					{
						num11 |= 8;
					}
					if (num3 + GameEngine.Instance.LocalWorldData.UnitSize_Trader > GameEngine.Instance.LocalWorldData.Village_UnitCapacity)
					{
						num11 |= 4;
					}
					this.troopMake2Button.CustomTooltipID = 2700;
					this.troopMake2ButtonA.CustomTooltipID = 2700;
					this.troopMake2ButtonB.CustomTooltipID = 2700;
					this.troopMake2ButtonX.CustomTooltipID = 2700;
					this.troopMake2Button.CustomTooltipData = num11;
					this.troopMake2ButtonA.CustomTooltipData = num11;
					this.troopMake2ButtonB.CustomTooltipData = num11;
					this.troopMake2ButtonX.CustomTooltipData = num11;
				}
				if (this.numSpies > 0)
				{
					this.troopMake3Button.Active = true;
					this.troopMake3Button.Alpha = 1f;
				}
				else
				{
					this.troopMake3Button.Active = false;
					this.troopMake3Button.Alpha = 0.5f;
				}
				if (this.numScouts > 0)
				{
					this.troopMake4Button.Active = true;
					this.troopMake4Button.Alpha = 1f;
					this.troopMake4ButtonA.Active = true;
					this.troopMake4ButtonA.Alpha = 1f;
					this.troopMake4ButtonB.Active = true;
					this.troopMake4ButtonB.Alpha = 1f;
					this.troopMake4ButtonX.Active = true;
					this.troopMake4ButtonX.Alpha = 1f;
					this.troopMake4Button.CustomTooltipID = 0;
					this.troopMake4ButtonA.CustomTooltipID = 0;
					this.troopMake4ButtonB.CustomTooltipID = 0;
					this.troopMake4ButtonX.CustomTooltipID = 0;
				}
				else
				{
					this.troopMake4Button.Active = false;
					this.troopMake4Button.Alpha = 0.5f;
					this.troopMake4ButtonA.Active = false;
					this.troopMake4ButtonA.Alpha = 0.5f;
					this.troopMake4ButtonB.Active = false;
					this.troopMake4ButtonB.Alpha = 0.5f;
					this.troopMake4ButtonX.Active = false;
					this.troopMake4ButtonX.Alpha = 0.5f;
					int num12 = 0;
					if (num == 0)
					{
						num12 |= 1;
					}
					if (num2 < localWorldData.ScoutGoldCost)
					{
						num12 |= 2;
					}
					if (num7 - num6 <= 0)
					{
						num12 |= 8;
					}
					if (num3 + GameEngine.Instance.LocalWorldData.UnitSize_Scout > GameEngine.Instance.LocalWorldData.Village_UnitCapacity)
					{
						num12 |= 4;
					}
					this.troopMake4Button.CustomTooltipID = 2700;
					this.troopMake4ButtonA.CustomTooltipID = 2700;
					this.troopMake4ButtonB.CustomTooltipID = 2700;
					this.troopMake4ButtonX.CustomTooltipID = 2700;
					this.troopMake4Button.CustomTooltipData = num12;
					this.troopMake4ButtonA.CustomTooltipData = num12;
					this.troopMake4ButtonB.CustomTooltipData = num12;
					this.troopMake4ButtonX.CustomTooltipData = num12;
				}
				this.troopsMade1Label.Text = num5.ToString("N", nfi) + " / " + num9.ToString("N", nfi);
				this.troopsMade2Label.Text = num4.ToString("N", nfi) + " / " + num8.ToString("N", nfi);
				this.troopsMade3Label.Text = "0";
				this.troopsMade4Label.Text = num6.ToString("N", nfi) + " / " + num7.ToString("N", nfi);
				this.troopMake1Button.Text.Text = this.numMonk.ToString("N", nfi);
				this.troopMake1ButtonB.Text.Text = this.numMonk.ToString("N", nfi);
				if (this.numMonk > 0)
				{
					this.troopMake1ButtonA.Text.Text = "1";
					if (this.numMonk >= 4)
					{
						this.troopMake1ButtonX.Text.Text = "4";
					}
					else
					{
						this.troopMake1ButtonX.Text.Text = this.numMonk.ToString("N", nfi);
					}
				}
				else
				{
					this.troopMake1ButtonA.Text.Text = "0";
					this.troopMake1ButtonX.Text.Text = "0";
				}
				this.troopMake2Button.Text.Text = this.numTrader.ToString("N", nfi);
				this.troopMake2ButtonB.Text.Text = this.numTrader.ToString("N", nfi);
				if (this.numTrader > 0)
				{
					this.troopMake2ButtonA.Text.Text = "1";
					if (this.numTrader >= 4)
					{
						this.troopMake2ButtonX.Text.Text = "4";
					}
					else
					{
						this.troopMake2ButtonX.Text.Text = this.numTrader.ToString("N", nfi);
					}
				}
				else
				{
					this.troopMake2ButtonA.Text.Text = "0";
					this.troopMake2ButtonX.Text.Text = "0";
				}
				this.troopMake3Button.Text.Text = this.numSpies.ToString("N", nfi);
				this.troopMake4Button.Text.Text = this.numScouts.ToString("N", nfi);
				this.troopMake4ButtonB.Text.Text = this.numScouts.ToString("N", nfi);
				if (this.numScouts > 0)
				{
					this.troopMake4ButtonA.Text.Text = "1";
					if (this.numScouts >= 4)
					{
						this.troopMake4ButtonX.Text.Text = "4";
					}
					else
					{
						this.troopMake4ButtonX.Text.Text = this.numScouts.ToString("N", nfi);
					}
				}
				else
				{
					this.troopMake4ButtonA.Text.Text = "0";
					this.troopMake4ButtonX.Text.Text = "0";
				}
				this.troopGoldCost1Label.Text = localWorldData.getMonkCost(num5).ToString();
				this.troopGoldCost2Label.Text = localWorldData.TraderGoldCost.ToString();
				this.troopGoldCost3Label.Text = "0";
				this.troopGoldCost4Label.Text = localWorldData.ScoutGoldCost.ToString();
				if (num2 < localWorldData.getMonkCost(num5))
				{
					this.troopGold1Image.Colorise = Color.FromArgb(255, 128, 128);
				}
				else
				{
					this.troopGold1Image.Colorise = global::ARGBColors.White;
				}
				if (num2 < localWorldData.TraderGoldCost)
				{
					this.troopGold2Image.Colorise = Color.FromArgb(255, 128, 128);
				}
				else
				{
					this.troopGold2Image.Colorise = global::ARGBColors.White;
				}
				if (num2 < 0)
				{
					this.troopGold3Image.Colorise = Color.FromArgb(255, 128, 128);
				}
				else
				{
					this.troopGold3Image.Colorise = global::ARGBColors.White;
				}
				if (num2 < localWorldData.ScoutGoldCost)
				{
					this.troopGold4Image.Colorise = Color.FromArgb(255, 128, 128);
				}
				else
				{
					this.troopGold4Image.Colorise = global::ARGBColors.White;
				}
				this.fullBar.MaxValue = (double)GameEngine.Instance.LocalWorldData.Village_UnitCapacity;
				if (num3 < GameEngine.Instance.LocalWorldData.Village_UnitCapacity)
				{
					this.fullBar.Number = (double)num3;
				}
				else
				{
					this.fullBar.Number = (double)GameEngine.Instance.LocalWorldData.Village_UnitCapacity;
				}
				if (this.mouseOver >= 0 && GameEngine.Instance.LocalWorldData.Village_UnitCapacity - num3 <= 0)
				{
					this.SpaceLabel.Color = Color.FromArgb(255, 64, 64);
				}
				else
				{
					this.SpaceLabel.Color = global::ARGBColors.Black;
				}
			}
			if (GameEngine.Instance.World.WorldEnded)
			{
				this.troopMake1ButtonA.Visible = false;
				this.troopMake1ButtonB.Visible = false;
				this.troopMake1ButtonX.Visible = false;
				this.troopsMade1Disband.Visible = false;
				this.troopMake2ButtonA.Visible = false;
				this.troopMake2ButtonB.Visible = false;
				this.troopMake2ButtonX.Visible = false;
				this.troopsMade2Disband.Visible = false;
				this.troopMake4ButtonA.Visible = false;
				this.troopMake4ButtonB.Visible = false;
				this.troopMake4ButtonX.Visible = false;
				this.troopsMade4Disband.Visible = false;
			}
		}

		// Token: 0x06002BC0 RID: 11200 RVA: 0x0022ACD0 File Offset: 0x00228ED0
		private void makeTroopClick()
		{
			if (this.OverControl != null)
			{
				try
				{
					CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.OverControl;
					int data = csdbutton.Data;
					VillageMap village = GameEngine.Instance.Village;
					if (village != null && csdbutton.Active)
					{
						switch (data)
						{
						case 1:
							GameEngine.Instance.playInterfaceSound("UnitsPanel2_make_monks");
							village.makePeople(4);
							break;
						case 2:
							GameEngine.Instance.playInterfaceSound("UnitsPanel2_make_traders");
							village.makeTroops(-5);
							break;
						case 3:
							break;
						case 4:
							GameEngine.Instance.playInterfaceSound("UnitsPanel2_make_scouts");
							village.makeTroops(76, 1, false);
							break;
						default:
							switch (data)
							{
							case 11:
								if (this.numMonk > 0)
								{
									GameEngine.Instance.playInterfaceSound("UnitsPanel2_make_monks");
									if (this.numMonk >= 4)
									{
										village.makePeople(1004);
									}
									else
									{
										village.makePeople(1000 + this.numMonk);
									}
								}
								else
								{
									GameEngine.Instance.playInterfaceSound("UnitsPanel2_make_failed");
								}
								break;
							case 12:
								if (this.numTrader > 0)
								{
									GameEngine.Instance.playInterfaceSound("UnitsPanel2_make_traders");
									if (this.numTrader >= 4)
									{
										village.makeTroops(-5, 4, false);
									}
									else
									{
										village.makeTroops(-5, this.numTrader, false);
									}
								}
								else
								{
									GameEngine.Instance.playInterfaceSound("UnitsPanel2_make_failed");
								}
								break;
							case 13:
								break;
							case 14:
								if (this.numScouts > 0)
								{
									GameEngine.Instance.playInterfaceSound("UnitsPanel2_make_scouts");
									if (this.numScouts >= 4)
									{
										village.makeTroops(76, 4, false);
									}
									else
									{
										village.makeTroops(76, this.numScouts, false);
									}
								}
								else
								{
									GameEngine.Instance.playInterfaceSound("UnitsPanel2_make_failed");
								}
								break;
							default:
								switch (data)
								{
								case 21:
									if (this.numMonk > 0)
									{
										GameEngine.Instance.playInterfaceSound("UnitsPanel2_make_monks");
										village.makePeople(1000 + this.numMonk);
									}
									else
									{
										GameEngine.Instance.playInterfaceSound("UnitsPanel2_make_failed");
									}
									break;
								case 22:
									if (this.numTrader > 0)
									{
										GameEngine.Instance.playInterfaceSound("UnitsPanel2_make_traders");
										village.makeTroops(-5, this.numTrader, false);
									}
									else
									{
										GameEngine.Instance.playInterfaceSound("UnitsPanel2_make_failed");
									}
									break;
								case 24:
									if (this.numScouts > 0)
									{
										GameEngine.Instance.playInterfaceSound("UnitsPanel2_make_scouts");
										village.makeTroops(76, this.numScouts, false);
									}
									else
									{
										GameEngine.Instance.playInterfaceSound("UnitsPanel2_make_failed");
									}
									break;
								}
								break;
							}
							break;
						}
					}
					else
					{
						GameEngine.Instance.playInterfaceSound("UnitsPanel2_make_failed");
					}
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x06002BC1 RID: 11201 RVA: 0x0022AFAC File Offset: 0x002291AC
		private void makeTroopOver()
		{
			if (this.OverControl != null)
			{
				CustomSelfDrawPanel.CSDControl overControl = this.OverControl;
				int num = this.mouseOver = overControl.Data;
				switch (num)
				{
				case 1:
					break;
				case 2:
					goto IL_88;
				case 3:
					this.typeLabel.Text = SK.Text("UnitsPanel_Spies", "Spies");
					return;
				case 4:
					goto IL_BE;
				default:
					switch (num)
					{
					case 11:
						break;
					case 12:
						goto IL_88;
					case 13:
						return;
					case 14:
						goto IL_BE;
					default:
						switch (num)
						{
						case 21:
							break;
						case 22:
							goto IL_88;
						case 23:
							return;
						case 24:
							goto IL_BE;
						default:
							return;
						}
						break;
					}
					break;
				}
				this.typeLabel.Text = SK.Text("UnitsPanel_Monks", "Monks");
				return;
				IL_88:
				this.typeLabel.Text = SK.Text("UnitsPanel_Traders", "Traders");
				return;
				IL_BE:
				this.typeLabel.Text = SK.Text("UnitsPanel_Scouts", "Scouts");
			}
		}

		// Token: 0x06002BC2 RID: 11202 RVA: 0x00020222 File Offset: 0x0001E422
		private void makeTroopLeave()
		{
			this.mouseOver = -1;
			this.typeLabel.Text = "";
		}

		// Token: 0x06002BC3 RID: 11203 RVA: 0x0022B094 File Offset: 0x00229294
		private void disbandTroopsClick()
		{
			if (this.OverControl != null)
			{
				CustomSelfDrawPanel.CSDControl overControl = this.OverControl;
				int data = overControl.Data;
				VillageMap village = GameEngine.Instance.Village;
				if (village != null)
				{
					this.closeDisbandPopup();
					this.m_disbandPopup = new DisbandUnitsPopup();
					this.m_disbandPopup.init(data);
					this.m_disbandPopup.Show();
				}
			}
		}

		// Token: 0x06002BC4 RID: 11204 RVA: 0x0002023B File Offset: 0x0001E43B
		public void closeDisbandPopup()
		{
			if (this.m_disbandPopup != null)
			{
				if (this.m_disbandPopup.Created)
				{
					this.m_disbandPopup.Close();
				}
				this.m_disbandPopup = null;
			}
		}

		// Token: 0x06002BC5 RID: 11205 RVA: 0x0022B0F0 File Offset: 0x002292F0
		private void disbandTroopOver()
		{
			if (this.OverControl != null)
			{
				CustomSelfDrawPanel.CSDControl overControl = this.OverControl;
				int num = this.disbandOver = overControl.Data;
				switch (this.disbandOver)
				{
				case 1:
					this.troopsMade1Label.Color = global::ARGBColors.Red;
					return;
				case 2:
					this.troopsMade2Label.Color = global::ARGBColors.Red;
					return;
				case 3:
					this.troopsMade3Label.Color = global::ARGBColors.Red;
					return;
				case 4:
					this.troopsMade4Label.Color = global::ARGBColors.Red;
					break;
				default:
					return;
				}
			}
		}

		// Token: 0x06002BC6 RID: 11206 RVA: 0x0022B180 File Offset: 0x00229380
		private void disbandTroopLeave()
		{
			switch (this.disbandOver)
			{
			case 1:
				this.troopsMade1Label.Color = Color.FromArgb(208, 165, 102);
				break;
			case 2:
				this.troopsMade2Label.Color = Color.FromArgb(208, 165, 102);
				break;
			case 3:
				this.troopsMade3Label.Color = Color.FromArgb(208, 165, 102);
				break;
			case 4:
				this.troopsMade4Label.Color = Color.FromArgb(208, 165, 102);
				break;
			}
			this.disbandOver = -1;
		}

		// Token: 0x06002BC7 RID: 11207 RVA: 0x0000B772 File Offset: 0x00009972
		private void attackInfoClick()
		{
			InterfaceMgr.Instance.setVillageTabSubMode(7);
		}

		// Token: 0x06002BC8 RID: 11208 RVA: 0x0000B77F File Offset: 0x0000997F
		private void reinforcementInfoClick()
		{
			InterfaceMgr.Instance.setVillageTabSubMode(6);
		}

		// Token: 0x0400364F RID: 13903
		private DockableControl dockableControl;

		// Token: 0x04003650 RID: 13904
		private IContainer components;

		// Token: 0x04003651 RID: 13905
		public static UnitsPanel2 instance;

		// Token: 0x04003652 RID: 13906
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003653 RID: 13907
		private CustomSelfDrawPanel.CSDArea mainBackgroundArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003654 RID: 13908
		private CustomSelfDrawPanel.CSDLabel barracksLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003655 RID: 13909
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003656 RID: 13910
		private CustomSelfDrawPanel.CSDImage troop1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003657 RID: 13911
		private CustomSelfDrawPanel.CSDImage troop2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003658 RID: 13912
		private CustomSelfDrawPanel.CSDImage troop3Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003659 RID: 13913
		private CustomSelfDrawPanel.CSDImage troop4Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400365A RID: 13914
		private CustomSelfDrawPanel.CSDImage troop5Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400365B RID: 13915
		private CustomSelfDrawPanel.CSDArea troopsMade1Disband = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400365C RID: 13916
		private CustomSelfDrawPanel.CSDArea troopsMade2Disband = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400365D RID: 13917
		private CustomSelfDrawPanel.CSDArea troopsMade3Disband = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400365E RID: 13918
		private CustomSelfDrawPanel.CSDArea troopsMade4Disband = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400365F RID: 13919
		private CustomSelfDrawPanel.CSDArea troopsMade5Disband = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003660 RID: 13920
		private CustomSelfDrawPanel.CSDLabel troopsMade1Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003661 RID: 13921
		private CustomSelfDrawPanel.CSDLabel troopsMade2Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003662 RID: 13922
		private CustomSelfDrawPanel.CSDLabel troopsMade3Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003663 RID: 13923
		private CustomSelfDrawPanel.CSDLabel troopsMade4Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003664 RID: 13924
		private CustomSelfDrawPanel.CSDLabel troopsMade5Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003665 RID: 13925
		private CustomSelfDrawPanel.CSDLabel troopGoldCost1Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003666 RID: 13926
		private CustomSelfDrawPanel.CSDLabel troopGoldCost2Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003667 RID: 13927
		private CustomSelfDrawPanel.CSDLabel troopGoldCost3Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003668 RID: 13928
		private CustomSelfDrawPanel.CSDLabel troopGoldCost4Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003669 RID: 13929
		private CustomSelfDrawPanel.CSDLabel troopGoldCost5Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400366A RID: 13930
		private CustomSelfDrawPanel.CSDButton troopMake1Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400366B RID: 13931
		private CustomSelfDrawPanel.CSDButton troopMake1ButtonA = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400366C RID: 13932
		private CustomSelfDrawPanel.CSDButton troopMake1ButtonB = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400366D RID: 13933
		private CustomSelfDrawPanel.CSDButton troopMake1ButtonX = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400366E RID: 13934
		private CustomSelfDrawPanel.CSDButton troopMake2Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400366F RID: 13935
		private CustomSelfDrawPanel.CSDButton troopMake2ButtonA = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003670 RID: 13936
		private CustomSelfDrawPanel.CSDButton troopMake2ButtonB = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003671 RID: 13937
		private CustomSelfDrawPanel.CSDButton troopMake2ButtonX = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003672 RID: 13938
		private CustomSelfDrawPanel.CSDButton troopMake3Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003673 RID: 13939
		private CustomSelfDrawPanel.CSDButton troopMake4Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003674 RID: 13940
		private CustomSelfDrawPanel.CSDButton troopMake4ButtonA = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003675 RID: 13941
		private CustomSelfDrawPanel.CSDButton troopMake4ButtonB = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003676 RID: 13942
		private CustomSelfDrawPanel.CSDButton troopMake4ButtonX = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003677 RID: 13943
		private CustomSelfDrawPanel.CSDButton troopMake5Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003678 RID: 13944
		private CustomSelfDrawPanel.CSDLabel troopUnitSize1Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003679 RID: 13945
		private CustomSelfDrawPanel.CSDLabel troopUnitSize2Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400367A RID: 13946
		private CustomSelfDrawPanel.CSDLabel troopUnitSize3Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400367B RID: 13947
		private CustomSelfDrawPanel.CSDLabel troopUnitSize4Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400367C RID: 13948
		private CustomSelfDrawPanel.CSDLabel troopUnitSize5Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400367D RID: 13949
		private CustomSelfDrawPanel.CSDImage troopGold1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400367E RID: 13950
		private CustomSelfDrawPanel.CSDImage troopGold2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400367F RID: 13951
		private CustomSelfDrawPanel.CSDImage troopGold3Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003680 RID: 13952
		private CustomSelfDrawPanel.CSDImage troopGold4Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003681 RID: 13953
		private CustomSelfDrawPanel.CSDImage troopGold5Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003682 RID: 13954
		private CustomSelfDrawPanel.CSDImage troop1WeaponImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003683 RID: 13955
		private CustomSelfDrawPanel.CSDImage troop2WeaponImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003684 RID: 13956
		private CustomSelfDrawPanel.CSDImage troop3WeaponImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003685 RID: 13957
		private CustomSelfDrawPanel.CSDImage troop4WeaponImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003686 RID: 13958
		private CustomSelfDrawPanel.CSDImage troop5WeaponImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003687 RID: 13959
		private CustomSelfDrawPanel.CSDLabel typeLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003688 RID: 13960
		private CustomSelfDrawPanel.CSDImage item1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003689 RID: 13961
		private CustomSelfDrawPanel.CSDLabel item1AmountLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400368A RID: 13962
		private CustomSelfDrawPanel.CSDLabel SpaceLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400368B RID: 13963
		private CustomSelfDrawPanel.CSDColorBar fullBar = new CustomSelfDrawPanel.CSDColorBar();

		// Token: 0x0400368C RID: 13964
		private CustomSelfDrawPanel.CSDExtendingPanel noResearchWindow = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x0400368D RID: 13965
		private CustomSelfDrawPanel.CSDLabel noResearchText = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400368E RID: 13966
		private CardBarGDI cardbar = new CardBarGDI();

		// Token: 0x0400368F RID: 13967
		private int numMonk;

		// Token: 0x04003690 RID: 13968
		private int numTrader;

		// Token: 0x04003691 RID: 13969
		private int numScouts;

		// Token: 0x04003692 RID: 13970
		private int numSpies;

		// Token: 0x04003693 RID: 13971
		private int mouseOver = -1;

		// Token: 0x04003694 RID: 13972
		private DisbandUnitsPopup m_disbandPopup;

		// Token: 0x04003695 RID: 13973
		private int disbandOver = -1;
	}
}
