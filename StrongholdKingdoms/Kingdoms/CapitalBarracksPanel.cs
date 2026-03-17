using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020000F7 RID: 247
	public class CapitalBarracksPanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x0600077A RID: 1914 RVA: 0x0000C3C1 File Offset: 0x0000A5C1
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x0600077B RID: 1915 RVA: 0x0000C3D1 File Offset: 0x0000A5D1
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x0600077C RID: 1916 RVA: 0x0000C3E1 File Offset: 0x0000A5E1
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x0600077D RID: 1917 RVA: 0x0000C3F3 File Offset: 0x0000A5F3
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x0600077E RID: 1918 RVA: 0x0000C400 File Offset: 0x0000A600
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closeDisbandPopup();
		}

		// Token: 0x0600077F RID: 1919 RVA: 0x0000C41A File Offset: 0x0000A61A
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06000780 RID: 1920 RVA: 0x0000C427 File Offset: 0x0000A627
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06000781 RID: 1921 RVA: 0x0000C434 File Offset: 0x0000A634
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000782 RID: 1922 RVA: 0x0009C8D4 File Offset: 0x0009AAD4
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.MaximumSize = new Size(992, 566);
			this.MinimumSize = new Size(992, 566);
			base.Name = "CapitalBarracksPanel";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x06000783 RID: 1923 RVA: 0x0009C940 File Offset: 0x0009AB40
		public CapitalBarracksPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06000784 RID: 1924 RVA: 0x0009CD28 File Offset: 0x0009AF28
		public void init()
		{
			CapitalBarracksPanel.instance = this;
			base.clearControls();
			this.mainBackgroundImage.Image = GFXLibrary.barracks_background;
			this.mainBackgroundImage.Position = new Point(0, 0);
			base.addControl(this.mainBackgroundImage);
			this.mainBackgroundArea.Position = new Point(0, 0);
			this.mainBackgroundArea.Size = new Size(992, 566);
			this.mainBackgroundImage.addControl(this.mainBackgroundArea);
			InterfaceMgr.Instance.setVillageHeading(SK.Text("CapitalBarracksPanel_Mercenaries", "Mercenaries"));
			this.closeButton.ImageNorm = GFXLibrary.int_button_close_normal;
			this.closeButton.ImageOver = GFXLibrary.int_button_close_over;
			this.closeButton.ImageClick = GFXLibrary.int_button_close_in;
			this.closeButton.Position = new Point(948, 10);
			this.closeButton.CustomTooltipID = 601;
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "CapitalBarracksPanel_close");
			this.mainBackgroundArea.addControl(this.closeButton);
			CustomSelfDrawPanel.WikiLinkControl.init(this.mainBackgroundArea, 13, new Point(898, 10));
			this.troopsMade1Disband.ImageNorm = GFXLibrary.barracks_little_button_normal;
			this.troopsMade1Disband.ImageOver = GFXLibrary.barracks_little_button_over;
			this.troopsMade1Disband.Position = new Point(109, 46);
			this.troopsMade1Disband.Text.Text = "0";
			this.troopsMade1Disband.Text.Color = global::ARGBColors.Black;
			this.troopsMade1Disband.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopsMade1Disband.TextYOffset = 0;
			this.troopsMade1Disband.Data = 70;
			this.troopsMade1Disband.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.disbandTroopsClick), "CapitalBarracksPanel_disband_peasants");
			this.troopsMade1Disband.CustomTooltipID = 600;
			this.mainBackgroundArea.addControl(this.troopsMade1Disband);
			this.troop1Image.Image = GFXLibrary.barracks_unit_peasant;
			this.troop1Image.Position = new Point(12, 12);
			this.mainBackgroundArea.addControl(this.troop1Image);
			this.troopGoldCost1Label.Text = "0";
			this.troopGoldCost1Label.Color = Color.FromArgb(208, 165, 102);
			this.troopGoldCost1Label.Position = new Point(69, 165);
			this.troopGoldCost1Label.Size = new Size(44, 47);
			this.troopGoldCost1Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopGoldCost1Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.troop1Image.addControl(this.troopGoldCost1Label);
			int y = 231;
			this.troopMake1Button1.ImageNorm = GFXLibrary.button3comp_left_normal;
			this.troopMake1Button1.ImageOver = GFXLibrary.button3comp_left_over;
			this.troopMake1Button1.ImageClick = GFXLibrary.button3comp_left_pressed;
			this.troopMake1Button1.Position = new Point(10, y);
			this.troopMake1Button1.Text.Text = "1";
			this.troopMake1Button1.TextYOffset = 1;
			this.troopMake1Button1.Text.Size = new Size(this.troopMake1Button1.Width - 5, this.troopMake1Button1.Height);
			this.troopMake1Button1.Text.Position = new Point(5, 0);
			this.troopMake1Button1.Text.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.troopMake1Button1.Text.Color = global::ARGBColors.Black;
			this.troopMake1Button1.Data = 70;
			this.troopMake1Button1.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake1Button1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick), "CapitalBarracksPanel_make_peasants");
			this.troop1Image.addControl(this.troopMake1Button1);
			this.troopMake1Button5.ImageNorm = GFXLibrary.button3comp_mid_normal;
			this.troopMake1Button5.ImageOver = GFXLibrary.button3comp_mid_over;
			this.troopMake1Button5.ImageClick = GFXLibrary.button3comp_mid_pushed;
			this.troopMake1Button5.Position = new Point(60, y);
			this.troopMake1Button5.Text.Text = "5";
			this.troopMake1Button5.TextYOffset = 1;
			this.troopMake1Button5.Text.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.troopMake1Button5.Text.Color = global::ARGBColors.Black;
			this.troopMake1Button5.Data = 1070;
			this.troopMake1Button5.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake1Button5.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick), "CapitalBarracksPanel_make_peasants");
			this.troop1Image.addControl(this.troopMake1Button5);
			this.troopMake1Button20.ImageNorm = GFXLibrary.button3comp_right_normal;
			this.troopMake1Button20.ImageOver = GFXLibrary.button3comp_right_over;
			this.troopMake1Button20.ImageClick = GFXLibrary.button3comp_right_pushed;
			this.troopMake1Button20.Position = new Point(108, y);
			this.troopMake1Button20.Text.Text = "20";
			this.troopMake1Button20.TextYOffset = 1;
			this.troopMake1Button20.Text.Size = new Size(this.troopMake1Button20.Width - 5, this.troopMake1Button20.Height);
			this.troopMake1Button20.Text.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.troopMake1Button20.Text.Color = global::ARGBColors.Black;
			this.troopMake1Button20.Data = 2070;
			this.troopMake1Button20.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake1Button20.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick), "CapitalBarracksPanel_make_peasants");
			this.troop1Image.addControl(this.troopMake1Button20);
			this.troopGold1Image.Image = GFXLibrary.com_32_money;
			this.troopGold1Image.Position = new Point(117, 173);
			this.troop1Image.addControl(this.troopGold1Image);
			this.troopsMade2Disband.ImageNorm = GFXLibrary.barracks_little_button_normal;
			this.troopsMade2Disband.ImageOver = GFXLibrary.barracks_little_button_over;
			this.troopsMade2Disband.Position = new Point(270, 46);
			this.troopsMade2Disband.Text.Text = "0";
			this.troopsMade2Disband.Text.Color = global::ARGBColors.Black;
			this.troopsMade2Disband.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopsMade2Disband.Data = 72;
			this.troopsMade2Disband.TextYOffset = 0;
			this.troopsMade2Disband.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.disbandTroopsClick), "CapitalBarracksPanel_disband_archers");
			this.troopsMade2Disband.CustomTooltipID = 600;
			this.mainBackgroundArea.addControl(this.troopsMade2Disband);
			this.troop2Image.Image = GFXLibrary.barracks_unit_archer;
			this.troop2Image.Position = new Point(173, 12);
			this.mainBackgroundArea.addControl(this.troop2Image);
			this.troopGoldCost2Label.Text = "0";
			this.troopGoldCost2Label.Color = Color.FromArgb(208, 165, 102);
			this.troopGoldCost2Label.Position = new Point(69, 165);
			this.troopGoldCost2Label.Size = new Size(44, 47);
			this.troopGoldCost2Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopGoldCost2Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.troop2Image.addControl(this.troopGoldCost2Label);
			this.troopMake2Button1.ImageNorm = GFXLibrary.button3comp_left_normal;
			this.troopMake2Button1.ImageOver = GFXLibrary.button3comp_left_over;
			this.troopMake2Button1.ImageClick = GFXLibrary.button3comp_left_pressed;
			this.troopMake2Button1.Position = new Point(10, y);
			this.troopMake2Button1.Text.Text = "1";
			this.troopMake2Button1.TextYOffset = 1;
			this.troopMake2Button1.Text.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.troopMake2Button1.Text.Color = global::ARGBColors.Black;
			this.troopMake2Button1.Text.Size = new Size(this.troopMake2Button1.Width - 5, this.troopMake2Button1.Height);
			this.troopMake2Button1.Text.Position = new Point(5, 0);
			this.troopMake2Button1.Data = 72;
			this.troopMake2Button1.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake2Button1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick), "CapitalBarracksPanel_make_archers");
			this.troop2Image.addControl(this.troopMake2Button1);
			this.troopMake2Button5.ImageNorm = GFXLibrary.button3comp_mid_normal;
			this.troopMake2Button5.ImageOver = GFXLibrary.button3comp_mid_over;
			this.troopMake2Button5.ImageClick = GFXLibrary.button3comp_mid_pushed;
			this.troopMake2Button5.Position = new Point(60, y);
			this.troopMake2Button5.Text.Text = "5";
			this.troopMake2Button5.TextYOffset = 1;
			this.troopMake2Button5.Text.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.troopMake2Button5.Text.Color = global::ARGBColors.Black;
			this.troopMake2Button5.Data = 1072;
			this.troopMake2Button5.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake2Button5.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick), "CapitalBarracksPanel_make_archers");
			this.troop2Image.addControl(this.troopMake2Button5);
			this.troopMake2Button20.ImageNorm = GFXLibrary.button3comp_right_normal;
			this.troopMake2Button20.ImageOver = GFXLibrary.button3comp_right_over;
			this.troopMake2Button20.ImageClick = GFXLibrary.button3comp_right_pushed;
			this.troopMake2Button20.Position = new Point(108, y);
			this.troopMake2Button20.Text.Text = "20";
			this.troopMake2Button20.TextYOffset = 1;
			this.troopMake2Button20.Text.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.troopMake2Button20.Text.Color = global::ARGBColors.Black;
			this.troopMake2Button20.Text.Size = new Size(this.troopMake2Button20.Width - 5, this.troopMake2Button20.Height);
			this.troopMake2Button20.Data = 2072;
			this.troopMake2Button20.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake2Button20.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick), "CapitalBarracksPanel_make_archers");
			this.troop2Image.addControl(this.troopMake2Button20);
			this.troopGold2Image.Image = GFXLibrary.com_32_money;
			this.troopGold2Image.Position = new Point(117, 173);
			this.troop2Image.addControl(this.troopGold2Image);
			this.troopsMade3Disband.ImageNorm = GFXLibrary.barracks_little_button_normal;
			this.troopsMade3Disband.ImageOver = GFXLibrary.barracks_little_button_over;
			this.troopsMade3Disband.Position = new Point(431, 46);
			this.troopsMade3Disband.Text.Text = "0";
			this.troopsMade3Disband.Text.Color = global::ARGBColors.Black;
			this.troopsMade3Disband.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopsMade3Disband.TextYOffset = 0;
			this.troopsMade3Disband.Data = 73;
			this.troopsMade3Disband.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.disbandTroopsClick), "CapitalBarracksPanel_disband_pikemen");
			this.troopsMade3Disband.CustomTooltipID = 600;
			this.mainBackgroundArea.addControl(this.troopsMade3Disband);
			this.troop3Image.Image = GFXLibrary.barracks_unit_pikemen;
			this.troop3Image.Position = new Point(334, 12);
			this.mainBackgroundArea.addControl(this.troop3Image);
			this.troopGoldCost3Label.Text = "0";
			this.troopGoldCost3Label.Color = Color.FromArgb(208, 165, 102);
			this.troopGoldCost3Label.Position = new Point(69, 165);
			this.troopGoldCost3Label.Size = new Size(44, 47);
			this.troopGoldCost3Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopGoldCost3Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.troop3Image.addControl(this.troopGoldCost3Label);
			this.troopMake3Button1.ImageNorm = GFXLibrary.button3comp_left_normal;
			this.troopMake3Button1.ImageOver = GFXLibrary.button3comp_left_over;
			this.troopMake3Button1.ImageClick = GFXLibrary.button3comp_left_pressed;
			this.troopMake3Button1.Position = new Point(10, y);
			this.troopMake3Button1.Text.Text = "1";
			this.troopMake3Button1.TextYOffset = 1;
			this.troopMake3Button1.Text.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.troopMake3Button1.Text.Color = global::ARGBColors.Black;
			this.troopMake3Button1.Text.Size = new Size(this.troopMake3Button1.Width - 5, this.troopMake3Button1.Height);
			this.troopMake3Button1.Text.Position = new Point(5, 0);
			this.troopMake3Button1.Data = 73;
			this.troopMake3Button1.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake3Button1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick), "CapitalBarracksPanel_make_pikemen");
			this.troop3Image.addControl(this.troopMake3Button1);
			this.troopMake3Button5.ImageNorm = GFXLibrary.button3comp_mid_normal;
			this.troopMake3Button5.ImageOver = GFXLibrary.button3comp_mid_over;
			this.troopMake3Button5.ImageClick = GFXLibrary.button3comp_mid_pushed;
			this.troopMake3Button5.Position = new Point(60, y);
			this.troopMake3Button5.Text.Text = "5";
			this.troopMake3Button5.TextYOffset = 1;
			this.troopMake3Button5.Text.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.troopMake3Button5.Text.Color = global::ARGBColors.Black;
			this.troopMake3Button5.Data = 1073;
			this.troopMake3Button5.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake3Button5.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick), "CapitalBarracksPanel_make_pikemen");
			this.troop3Image.addControl(this.troopMake3Button5);
			this.troopMake3Button20.ImageNorm = GFXLibrary.button3comp_right_normal;
			this.troopMake3Button20.ImageOver = GFXLibrary.button3comp_right_over;
			this.troopMake3Button20.ImageClick = GFXLibrary.button3comp_right_pushed;
			this.troopMake3Button20.Position = new Point(108, y);
			this.troopMake3Button20.Text.Text = "20";
			this.troopMake3Button20.TextYOffset = 1;
			this.troopMake3Button20.Text.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.troopMake3Button20.Text.Color = global::ARGBColors.Black;
			this.troopMake3Button20.Text.Size = new Size(this.troopMake3Button20.Width - 5, this.troopMake3Button20.Height);
			this.troopMake3Button20.Data = 2073;
			this.troopMake3Button20.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake3Button20.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick), "CapitalBarracksPanel_make_pikemen");
			this.troop3Image.addControl(this.troopMake3Button20);
			this.troopGold3Image.Image = GFXLibrary.com_32_money;
			this.troopGold3Image.Position = new Point(117, 173);
			this.troop3Image.addControl(this.troopGold3Image);
			this.troopsMade4Disband.ImageNorm = GFXLibrary.barracks_little_button_normal;
			this.troopsMade4Disband.ImageOver = GFXLibrary.barracks_little_button_over;
			this.troopsMade4Disband.Position = new Point(592, 46);
			this.troopsMade4Disband.Text.Text = "0";
			this.troopsMade4Disband.Text.Color = global::ARGBColors.Black;
			this.troopsMade4Disband.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopsMade4Disband.TextYOffset = 0;
			this.troopsMade4Disband.Data = 71;
			this.troopsMade4Disband.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.disbandTroopsClick), "CapitalBarracksPanel_disband_swordsmen");
			this.troopsMade4Disband.CustomTooltipID = 600;
			this.mainBackgroundArea.addControl(this.troopsMade4Disband);
			this.troop4Image.Image = GFXLibrary.barracks_unit_swordsman;
			this.troop4Image.Position = new Point(495, 12);
			this.mainBackgroundArea.addControl(this.troop4Image);
			this.troopGoldCost4Label.Text = "0";
			this.troopGoldCost4Label.Color = Color.FromArgb(208, 165, 102);
			this.troopGoldCost4Label.Position = new Point(69, 165);
			this.troopGoldCost4Label.Size = new Size(44, 47);
			this.troopGoldCost4Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopGoldCost4Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.troop4Image.addControl(this.troopGoldCost4Label);
			this.troopMake4Button1.ImageNorm = GFXLibrary.button3comp_left_normal;
			this.troopMake4Button1.ImageOver = GFXLibrary.button3comp_left_over;
			this.troopMake4Button1.ImageClick = GFXLibrary.button3comp_left_pressed;
			this.troopMake4Button1.Position = new Point(10, y);
			this.troopMake4Button1.Text.Text = "1";
			this.troopMake4Button1.TextYOffset = 1;
			this.troopMake4Button1.Text.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.troopMake4Button1.Text.Color = global::ARGBColors.Black;
			this.troopMake4Button1.Text.Size = new Size(this.troopMake4Button1.Width - 5, this.troopMake4Button1.Height);
			this.troopMake4Button1.Text.Position = new Point(5, 0);
			this.troopMake4Button1.Data = 71;
			this.troopMake4Button1.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake4Button1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick), "CapitalBarracksPanel_make_swordsmen");
			this.troop4Image.addControl(this.troopMake4Button1);
			this.troopMake4Button5.ImageNorm = GFXLibrary.button3comp_mid_normal;
			this.troopMake4Button5.ImageOver = GFXLibrary.button3comp_mid_over;
			this.troopMake4Button5.ImageClick = GFXLibrary.button3comp_mid_pushed;
			this.troopMake4Button5.Position = new Point(60, y);
			this.troopMake4Button5.Text.Text = "5";
			this.troopMake4Button5.TextYOffset = 1;
			this.troopMake4Button5.Text.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.troopMake4Button5.Text.Color = global::ARGBColors.Black;
			this.troopMake4Button5.Data = 1071;
			this.troopMake4Button5.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake4Button5.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick), "CapitalBarracksPanel_make_swordsmen");
			this.troop4Image.addControl(this.troopMake4Button5);
			this.troopMake4Button20.ImageNorm = GFXLibrary.button3comp_right_normal;
			this.troopMake4Button20.ImageOver = GFXLibrary.button3comp_right_over;
			this.troopMake4Button20.ImageClick = GFXLibrary.button3comp_right_pushed;
			this.troopMake4Button20.Position = new Point(108, y);
			this.troopMake4Button20.Text.Text = "20";
			this.troopMake4Button20.TextYOffset = 1;
			this.troopMake4Button20.Text.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.troopMake4Button20.Text.Color = global::ARGBColors.Black;
			this.troopMake4Button20.Text.Size = new Size(this.troopMake4Button20.Width - 5, this.troopMake4Button20.Height);
			this.troopMake4Button20.Data = 2071;
			this.troopMake4Button20.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake4Button20.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick), "CapitalBarracksPanel_make_swordsmen");
			this.troop4Image.addControl(this.troopMake4Button20);
			this.troopGold4Image.Image = GFXLibrary.com_32_money;
			this.troopGold4Image.Position = new Point(117, 173);
			this.troop4Image.addControl(this.troopGold4Image);
			this.troopsMade5Disband.ImageNorm = GFXLibrary.barracks_little_button_normal;
			this.troopsMade5Disband.ImageOver = GFXLibrary.barracks_little_button_over;
			this.troopsMade5Disband.Position = new Point(753, 46);
			this.troopsMade5Disband.Text.Text = "0";
			this.troopsMade5Disband.Text.Color = global::ARGBColors.Black;
			this.troopsMade5Disband.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopsMade5Disband.TextYOffset = 0;
			this.troopsMade5Disband.Data = 74;
			this.troopsMade5Disband.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.disbandTroopsClick), "CapitalBarracksPanel_disband_catapults");
			this.troopsMade5Disband.CustomTooltipID = 600;
			this.mainBackgroundArea.addControl(this.troopsMade5Disband);
			this.troop5Image.Image = GFXLibrary.barracks_unit_catapult;
			this.troop5Image.Position = new Point(656, 12);
			this.mainBackgroundArea.addControl(this.troop5Image);
			this.troopGoldCost5Label.Text = "0";
			this.troopGoldCost5Label.Color = Color.FromArgb(208, 165, 102);
			this.troopGoldCost5Label.Position = new Point(69, 165);
			this.troopGoldCost5Label.Size = new Size(44, 47);
			this.troopGoldCost5Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopGoldCost5Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.troop5Image.addControl(this.troopGoldCost5Label);
			this.troopMake5Button1.ImageNorm = GFXLibrary.button3comp_left_normal;
			this.troopMake5Button1.ImageOver = GFXLibrary.button3comp_left_over;
			this.troopMake5Button1.ImageClick = GFXLibrary.button3comp_left_pressed;
			this.troopMake5Button1.Position = new Point(10, y);
			this.troopMake5Button1.Text.Text = "1";
			this.troopMake5Button1.TextYOffset = 1;
			this.troopMake5Button1.Text.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.troopMake5Button1.Text.Color = global::ARGBColors.Black;
			this.troopMake5Button1.Text.Size = new Size(this.troopMake5Button1.Width - 5, this.troopMake5Button1.Height);
			this.troopMake5Button1.Text.Position = new Point(5, 0);
			this.troopMake5Button1.Data = 74;
			this.troopMake5Button1.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake5Button1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick), "CapitalBarracksPanel_make_catapults");
			this.troop5Image.addControl(this.troopMake5Button1);
			this.troopMake5Button5.ImageNorm = GFXLibrary.button3comp_mid_normal;
			this.troopMake5Button5.ImageOver = GFXLibrary.button3comp_mid_over;
			this.troopMake5Button5.ImageClick = GFXLibrary.button3comp_mid_pushed;
			this.troopMake5Button5.Position = new Point(60, y);
			this.troopMake5Button5.Text.Text = "5";
			this.troopMake5Button5.TextYOffset = 1;
			this.troopMake5Button5.Text.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.troopMake5Button5.Text.Color = global::ARGBColors.Black;
			this.troopMake5Button5.Data = 1074;
			this.troopMake5Button5.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake5Button5.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick), "CapitalBarracksPanel_make_catapults");
			this.troop5Image.addControl(this.troopMake5Button5);
			this.troopMake5Button20.ImageNorm = GFXLibrary.button3comp_right_normal;
			this.troopMake5Button20.ImageOver = GFXLibrary.button3comp_right_over;
			this.troopMake5Button20.ImageClick = GFXLibrary.button3comp_right_pushed;
			this.troopMake5Button20.Position = new Point(108, y);
			this.troopMake5Button20.Text.Text = "20";
			this.troopMake5Button20.TextYOffset = 1;
			this.troopMake5Button20.Text.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.troopMake5Button20.Text.Color = global::ARGBColors.Black;
			this.troopMake5Button20.Text.Size = new Size(this.troopMake5Button20.Width - 5, this.troopMake5Button20.Height);
			this.troopMake5Button20.Data = 2074;
			this.troopMake5Button20.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake5Button20.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick), "CapitalBarracksPanel_make_catapults");
			this.troop5Image.addControl(this.troopMake5Button20);
			this.troopGold5Image.Image = GFXLibrary.com_32_money;
			this.troopGold5Image.Position = new Point(117, 173);
			this.troop5Image.addControl(this.troopGold5Image);
			int num = 73;
			this.goldImage.Image = GFXLibrary.com_32_money;
			this.goldImage.Position = new Point(num + 7, 340);
			this.mainBackgroundArea.addControl(this.goldImage);
			this.goldLabel.Text = "0";
			this.goldLabel.Color = global::ARGBColors.Black;
			this.goldLabel.Position = new Point(num + 7 + 32, 340);
			this.goldLabel.Size = new Size(300, this.goldImage.Image.Height);
			this.goldLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.goldLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.mainBackgroundArea.addControl(this.goldLabel);
			this.CurrentTroopsLabel.Text = SK.Text("BARRACKS_Troops", "Troops") + ": 0";
			this.CurrentTroopsLabel.Color = global::ARGBColors.Black;
			this.CurrentTroopsLabel.Position = new Point(560, 347);
			this.CurrentTroopsLabel.Size = new Size(200, 20);
			this.CurrentTroopsLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.CurrentTroopsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.mainBackgroundArea.addControl(this.CurrentTroopsLabel);
			this.MaxLabelLabel.Text = SK.Text("CapitalBarracksPanel_Max_Army_Size", "Max Army Size") + ": 0";
			this.MaxLabelLabel.Color = global::ARGBColors.Black;
			this.MaxLabelLabel.Position = new Point(770, 357);
			this.MaxLabelLabel.Size = new Size(200, 20);
			this.MaxLabelLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.MaxLabelLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.mainBackgroundArea.addControl(this.MaxLabelLabel);
			this.fullBar.setImages(GFXLibrary.barracks_fillbar_back, GFXLibrary.barracks_fillbar_fill_left, GFXLibrary.barracks_fillbar_fill_mid, GFXLibrary.barracks_fillbar_fill_right, GFXLibrary.barracks_fillbar_back, GFXLibrary.barracks_fillbar_fill_left, GFXLibrary.barracks_fillbar_fill_mid, GFXLibrary.barracks_fillbar_fill_right);
			this.fullBar.SetMargin(2, 2, 2, 3);
			this.fullBar.Number = 0.0;
			this.fullBar.MaxValue = 9.0;
			this.fullBar.Position = new Point(770, 339);
			this.mainBackgroundArea.addControl(this.fullBar);
			int num2 = 442;
			this.BottomHeaderLabel.Text = SK.Text("BARRACKS_Troop_Information", "Troop Information");
			this.BottomHeaderLabel.Color = Color.FromArgb(242, 202, 118);
			this.BottomHeaderLabel.DropShadowColor = global::ARGBColors.Black;
			this.BottomHeaderLabel.Position = new Point(54, 402);
			this.BottomHeaderLabel.Size = new Size(226, 27);
			this.BottomHeaderLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.BottomHeaderLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.mainBackgroundArea.addControl(this.BottomHeaderLabel);
			int num3 = 25;
			this.LocalLabel.Text = SK.Text("BARRACKS_In_Barracks", "In Barracks");
			this.LocalLabel.Color = global::ARGBColors.Black;
			this.LocalLabel.Position = new Point(79, num2);
			this.LocalLabel.Size = new Size(226, 27);
			this.LocalLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.LocalLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.mainBackgroundArea.addControl(this.LocalLabel);
			this.InCastleLabel.Text = SK.Text("BARRACKS_In_Castle", "In Castle");
			this.InCastleLabel.Color = global::ARGBColors.Black;
			this.InCastleLabel.Position = new Point(79, num2 + num3);
			this.InCastleLabel.Size = new Size(226, 27);
			this.InCastleLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.InCastleLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.mainBackgroundArea.addControl(this.InCastleLabel);
			this.AttackingLabel.Text = SK.Text("GENERIC_Attacking", "Attacking");
			this.AttackingLabel.Color = global::ARGBColors.Black;
			this.AttackingLabel.Position = new Point(79, num2 + 2 * num3);
			this.AttackingLabel.Size = new Size(226, 27);
			this.AttackingLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.AttackingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.mainBackgroundArea.addControl(this.AttackingLabel);
			this.ReinforcingLabel.Text = SK.Text("BARRACKS_Reinforcing", "Reinforcing");
			this.ReinforcingLabel.Color = global::ARGBColors.Black;
			this.ReinforcingLabel.Position = new Point(79, num2 + 3 * num3);
			this.ReinforcingLabel.Size = new Size(226, 27);
			this.ReinforcingLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.ReinforcingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.mainBackgroundArea.addControl(this.ReinforcingLabel);
			this.smallPeasantImage.Image = GFXLibrary.barracks_screen_bottom_units;
			this.smallPeasantImage.Position = new Point(370, 394);
			this.mainBackgroundArea.addControl(this.smallPeasantImage);
			int num4 = 85;
			int num5 = 344;
			this.localPeasantsLabel.Text = "0";
			this.localPeasantsLabel.Color = global::ARGBColors.Black;
			this.localPeasantsLabel.Position = new Point(num5, num2);
			this.localPeasantsLabel.Size = new Size(50, 27);
			this.localPeasantsLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.localPeasantsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.mainBackgroundArea.addControl(this.localPeasantsLabel);
			this.localArchersLabel.Text = "0";
			this.localArchersLabel.Color = global::ARGBColors.Black;
			this.localArchersLabel.Position = new Point(num5 + num4, num2);
			this.localArchersLabel.Size = new Size(50, 27);
			this.localArchersLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.localArchersLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.mainBackgroundArea.addControl(this.localArchersLabel);
			this.localPikmenLabel.Text = "0";
			this.localPikmenLabel.Color = global::ARGBColors.Black;
			this.localPikmenLabel.Position = new Point(num5 + 2 * num4, num2);
			this.localPikmenLabel.Size = new Size(50, 27);
			this.localPikmenLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.localPikmenLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.mainBackgroundArea.addControl(this.localPikmenLabel);
			this.localSwordsmenLabel.Text = "0";
			this.localSwordsmenLabel.Color = global::ARGBColors.Black;
			this.localSwordsmenLabel.Position = new Point(num5 + 3 * num4, num2);
			this.localSwordsmenLabel.Size = new Size(50, 27);
			this.localSwordsmenLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.localSwordsmenLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.mainBackgroundArea.addControl(this.localSwordsmenLabel);
			this.localCatapultsLabel.Text = "0";
			this.localCatapultsLabel.Color = global::ARGBColors.Black;
			this.localCatapultsLabel.Position = new Point(num5 + 4 * num4, num2);
			this.localCatapultsLabel.Size = new Size(50, 27);
			this.localCatapultsLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.localCatapultsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.mainBackgroundArea.addControl(this.localCatapultsLabel);
			this.localCaptainsLabel.Text = "0";
			this.localCaptainsLabel.Color = global::ARGBColors.Black;
			this.localCaptainsLabel.Position = new Point(num5 + 5 * num4, num2);
			this.localCaptainsLabel.Size = new Size(50, 27);
			this.localCaptainsLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.localCaptainsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.mainBackgroundArea.addControl(this.localCaptainsLabel);
			this.inCastlePeasantsLabel.Text = "0";
			this.inCastlePeasantsLabel.Color = global::ARGBColors.Black;
			this.inCastlePeasantsLabel.Position = new Point(num5, num2 + num3);
			this.inCastlePeasantsLabel.Size = new Size(50, 27);
			this.inCastlePeasantsLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.inCastlePeasantsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.mainBackgroundArea.addControl(this.inCastlePeasantsLabel);
			this.inCastleArchersLabel.Text = "0";
			this.inCastleArchersLabel.Color = global::ARGBColors.Black;
			this.inCastleArchersLabel.Position = new Point(num5 + num4, num2 + num3);
			this.inCastleArchersLabel.Size = new Size(50, 27);
			this.inCastleArchersLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.inCastleArchersLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.mainBackgroundArea.addControl(this.inCastleArchersLabel);
			this.inCastlePikmenLabel.Text = "0";
			this.inCastlePikmenLabel.Color = global::ARGBColors.Black;
			this.inCastlePikmenLabel.Position = new Point(num5 + 2 * num4, num2 + num3);
			this.inCastlePikmenLabel.Size = new Size(50, 27);
			this.inCastlePikmenLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.inCastlePikmenLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.mainBackgroundArea.addControl(this.inCastlePikmenLabel);
			this.inCastleSwordsmenLabel.Text = "0";
			this.inCastleSwordsmenLabel.Color = global::ARGBColors.Black;
			this.inCastleSwordsmenLabel.Position = new Point(num5 + 3 * num4, num2 + num3);
			this.inCastleSwordsmenLabel.Size = new Size(50, 27);
			this.inCastleSwordsmenLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.inCastleSwordsmenLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.mainBackgroundArea.addControl(this.inCastleSwordsmenLabel);
			this.inCastleCatapultsLabel.Text = "0";
			this.inCastleCatapultsLabel.Color = global::ARGBColors.Black;
			this.inCastleCatapultsLabel.Position = new Point(num5 + 4 * num4, num2 + num3);
			this.inCastleCatapultsLabel.Size = new Size(50, 27);
			this.inCastleCatapultsLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.inCastleCatapultsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.mainBackgroundArea.addControl(this.inCastleCatapultsLabel);
			this.inCastleCaptainsLabel.Text = "0";
			this.inCastleCaptainsLabel.Color = global::ARGBColors.Black;
			this.inCastleCaptainsLabel.Position = new Point(num5 + 5 * num4, num2 + num3);
			this.inCastleCaptainsLabel.Size = new Size(50, 27);
			this.inCastleCaptainsLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.inCastleCaptainsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.mainBackgroundArea.addControl(this.inCastleCaptainsLabel);
			this.attackingPeasantsLabel.Text = "0";
			this.attackingPeasantsLabel.Color = global::ARGBColors.Black;
			this.attackingPeasantsLabel.Position = new Point(num5, num2 + 2 * num3);
			this.attackingPeasantsLabel.Size = new Size(50, 27);
			this.attackingPeasantsLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.attackingPeasantsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.mainBackgroundArea.addControl(this.attackingPeasantsLabel);
			this.attackingArchersLabel.Text = "0";
			this.attackingArchersLabel.Color = global::ARGBColors.Black;
			this.attackingArchersLabel.Position = new Point(num5 + num4, num2 + 2 * num3);
			this.attackingArchersLabel.Size = new Size(50, 27);
			this.attackingArchersLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.attackingArchersLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.mainBackgroundArea.addControl(this.attackingArchersLabel);
			this.attackingPikmenLabel.Text = "0";
			this.attackingPikmenLabel.Color = global::ARGBColors.Black;
			this.attackingPikmenLabel.Position = new Point(num5 + 2 * num4, num2 + 2 * num3);
			this.attackingPikmenLabel.Size = new Size(50, 27);
			this.attackingPikmenLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.attackingPikmenLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.mainBackgroundArea.addControl(this.attackingPikmenLabel);
			this.attackingSwordsmenLabel.Text = "0";
			this.attackingSwordsmenLabel.Color = global::ARGBColors.Black;
			this.attackingSwordsmenLabel.Position = new Point(num5 + 3 * num4, num2 + 2 * num3);
			this.attackingSwordsmenLabel.Size = new Size(50, 27);
			this.attackingSwordsmenLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.attackingSwordsmenLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.mainBackgroundArea.addControl(this.attackingSwordsmenLabel);
			this.attackingCatapultsLabel.Text = "0";
			this.attackingCatapultsLabel.Color = global::ARGBColors.Black;
			this.attackingCatapultsLabel.Position = new Point(num5 + 4 * num4, num2 + 2 * num3);
			this.attackingCatapultsLabel.Size = new Size(50, 27);
			this.attackingCatapultsLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.attackingCatapultsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.mainBackgroundArea.addControl(this.attackingCatapultsLabel);
			this.attackingCaptainsLabel.Text = "0";
			this.attackingCaptainsLabel.Color = global::ARGBColors.Black;
			this.attackingCaptainsLabel.Position = new Point(num5 + 5 * num4, num2 + 2 * num3);
			this.attackingCaptainsLabel.Size = new Size(50, 27);
			this.attackingCaptainsLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.attackingCaptainsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.mainBackgroundArea.addControl(this.attackingCaptainsLabel);
			this.reinforcingPeasantsLabel.Text = "0";
			this.reinforcingPeasantsLabel.Color = global::ARGBColors.Black;
			this.reinforcingPeasantsLabel.Position = new Point(num5, num2 + 3 * num3);
			this.reinforcingPeasantsLabel.Size = new Size(50, 27);
			this.reinforcingPeasantsLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.reinforcingPeasantsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.mainBackgroundArea.addControl(this.reinforcingPeasantsLabel);
			this.reinforcingArchersLabel.Text = "0";
			this.reinforcingArchersLabel.Color = global::ARGBColors.Black;
			this.reinforcingArchersLabel.Position = new Point(num5 + num4, num2 + 3 * num3);
			this.reinforcingArchersLabel.Size = new Size(50, 27);
			this.reinforcingArchersLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.reinforcingArchersLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.mainBackgroundArea.addControl(this.reinforcingArchersLabel);
			this.reinforcingPikmenLabel.Text = "0";
			this.reinforcingPikmenLabel.Color = global::ARGBColors.Black;
			this.reinforcingPikmenLabel.Position = new Point(num5 + 2 * num4, num2 + 3 * num3);
			this.reinforcingPikmenLabel.Size = new Size(50, 27);
			this.reinforcingPikmenLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.reinforcingPikmenLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.mainBackgroundArea.addControl(this.reinforcingPikmenLabel);
			this.reinforcingSwordsmenLabel.Text = "0";
			this.reinforcingSwordsmenLabel.Color = global::ARGBColors.Black;
			this.reinforcingSwordsmenLabel.Position = new Point(num5 + 3 * num4, num2 + 3 * num3);
			this.reinforcingSwordsmenLabel.Size = new Size(50, 27);
			this.reinforcingSwordsmenLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.reinforcingSwordsmenLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.mainBackgroundArea.addControl(this.reinforcingSwordsmenLabel);
			this.reinforcingCatapultsLabel.Text = "0";
			this.reinforcingCatapultsLabel.Color = global::ARGBColors.Black;
			this.reinforcingCatapultsLabel.Position = new Point(num5 + 4 * num4, num2 + 3 * num3);
			this.reinforcingCatapultsLabel.Size = new Size(50, 27);
			this.reinforcingCatapultsLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.reinforcingCatapultsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.mainBackgroundArea.addControl(this.reinforcingCatapultsLabel);
			this.reinforcingCaptainsLabel.Text = "0";
			this.reinforcingCaptainsLabel.Color = global::ARGBColors.Black;
			this.reinforcingCaptainsLabel.Position = new Point(num5 + 5 * num4, num2 + 3 * num3);
			this.reinforcingCaptainsLabel.Size = new Size(50, 27);
			this.reinforcingCaptainsLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.reinforcingCaptainsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.mainBackgroundArea.addControl(this.reinforcingCaptainsLabel);
			this.reinforcementInfoButton.ImageNorm = GFXLibrary.barracks_i_button_normal;
			this.reinforcementInfoButton.ImageOver = GFXLibrary.barracks_i_button_over;
			this.reinforcementInfoButton.Position = new Point(865, num2 + 3 * num3 - 1);
			this.reinforcementInfoButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.reinforcementInfoClick), "CapitalBarracksPanel_view_reinforcements");
			this.mainBackgroundArea.addControl(this.reinforcementInfoButton);
			this.update();
		}

		// Token: 0x06000785 RID: 1925 RVA: 0x0000C453 File Offset: 0x0000A653
		public void update()
		{
			this.updateValues();
		}

		// Token: 0x06000786 RID: 1926 RVA: 0x0000B71E File Offset: 0x0000991E
		public void closeClick()
		{
			InterfaceMgr.Instance.setVillageTabSubMode(-1);
		}

		// Token: 0x06000787 RID: 1927 RVA: 0x0009FCAC File Offset: 0x0009DEAC
		public void updateValues()
		{
			NumberFormatInfo nfi = GameEngine.NFI;
			WorldData localWorldData = GameEngine.Instance.LocalWorldData;
			VillageMap village = GameEngine.Instance.Village;
			CastleMap castle = GameEngine.Instance.Castle;
			if (village == null || castle == null)
			{
				return;
			}
			int locallyMade_Peasants = village.LocallyMade_Peasants;
			int locallyMade_Archers = village.LocallyMade_Archers;
			int locallyMade_Pikemen = village.LocallyMade_Pikemen;
			int locallyMade_Swordsmen = village.LocallyMade_Swordsmen;
			int locallyMade_Catapults = village.LocallyMade_Catapults;
			int num = locallyMade_Swordsmen + locallyMade_Pikemen + locallyMade_Peasants + locallyMade_Catapults + locallyMade_Archers;
			VillageMap.ArmouryLevels levels = new VillageMap.ArmouryLevels();
			village.getArmouryLevels(levels);
			int num2 = (int)village.m_capitalGold;
			int num3 = localWorldData.Barracks_GoldCost_Peasant * localWorldData.MercenaryCostMultiplier;
			int num4 = localWorldData.Barracks_GoldCost_Archer * localWorldData.MercenaryCostMultiplier;
			int num5 = localWorldData.Barracks_GoldCost_Pikeman * localWorldData.MercenaryCostMultiplier;
			int num6 = localWorldData.Barracks_GoldCost_Swordsman * localWorldData.MercenaryCostMultiplier;
			int num7 = localWorldData.Barracks_GoldCost_Catapult * localWorldData.MercenaryCostMultiplier;
			if (GameEngine.Instance.World.SixthAgeWorld)
			{
				num3 /= 2;
				num4 /= 2;
				num5 /= 2;
				num6 /= 2;
				num7 /= 2;
			}
			num2 -= locallyMade_Peasants * num3;
			num2 -= locallyMade_Archers * num4;
			num2 -= locallyMade_Pikemen * num5;
			num2 -= locallyMade_Swordsmen * num6;
			num2 -= locallyMade_Catapults * num7;
			int num8 = num2 / num3;
			int num9 = num2 / num4;
			int num10 = num2 / num5;
			int num11 = num2 / num6;
			int num12 = num2 / num7;
			int num13 = 0;
			if (GameEngine.Instance.World.isCapital(village.VillageID))
			{
				num13 = (int)((village.m_parishCapitalResearchData.Research_Command + 1) * 25);
			}
			int num14 = village.calcTotalTroops() + num;
			int num15 = num14;
			this.goldLabel.Text = num2.ToString();
			this.CurrentTroopsLabel.Text = SK.Text("BARRACKS_Troops", "Troops") + ": " + num14.ToString("N", nfi);
			this.MaxLabelLabel.Text = SK.Text("BARRACKS_Max_Army_Size", "Max Army Size") + ": " + num13.ToString("N", nfi);
			int num16 = num13 - num14;
			if (num8 > num16)
			{
				num8 = num16;
			}
			if (num9 > num16)
			{
				num9 = num16;
			}
			if (num10 > num16)
			{
				num10 = num16;
			}
			if (num11 > num16)
			{
				num11 = num16;
			}
			if (num12 > num16)
			{
				num12 = num16;
			}
			if (num14 >= num13)
			{
				num8 = 0;
				num9 = 0;
				num10 = 0;
				num11 = 0;
				num12 = 0;
			}
			ResearchData researchDataForCurrentVillage = GameEngine.Instance.World.GetResearchDataForCurrentVillage();
			if (researchDataForCurrentVillage.Research_Conscription == 0)
			{
				num8 = 0;
				this.troop1Image.Visible = false;
			}
			else
			{
				this.troop1Image.Visible = true;
			}
			if (researchDataForCurrentVillage.Research_LongBow == 0)
			{
				num9 = 0;
				this.troop2Image.Visible = false;
			}
			else
			{
				this.troop2Image.Visible = true;
			}
			if (researchDataForCurrentVillage.Research_Pike == 0)
			{
				num10 = 0;
				this.troop3Image.Visible = false;
			}
			else
			{
				this.troop3Image.Visible = true;
			}
			if (researchDataForCurrentVillage.Research_Sword == 0)
			{
				num11 = 0;
				this.troop4Image.Visible = false;
			}
			else
			{
				this.troop4Image.Visible = true;
			}
			if (researchDataForCurrentVillage.Research_Catapult == 0)
			{
				num12 = 0;
				this.troop5Image.Visible = false;
			}
			else
			{
				this.troop5Image.Visible = true;
			}
			this.troopsMade1Disband.Visible = this.troop1Image.Visible;
			this.troopsMade2Disband.Visible = this.troop2Image.Visible;
			this.troopsMade3Disband.Visible = this.troop3Image.Visible;
			this.troopsMade4Disband.Visible = this.troop4Image.Visible;
			this.troopsMade5Disband.Visible = this.troop5Image.Visible;
			this.makePeasants = num8;
			this.makeArchers = num9;
			this.makePikemen = num10;
			this.makeSwordsmen = num11;
			this.makeCatapults = num12;
			bool flag = true;
			if (!GameEngine.Instance.World.isUserVillage(InterfaceMgr.Instance.getSelectedMenuVillage()))
			{
				flag = false;
			}
			this.troopMake1Button1.invalidate();
			this.troopMake1Button1.Active = false;
			this.troopMake1Button1.Text.Color = Color.FromArgb(151, 134, 108);
			this.troopMake1Button5.Active = false;
			this.troopMake1Button5.Text.Color = Color.FromArgb(151, 134, 108);
			this.troopMake1Button20.Active = false;
			this.troopMake1Button20.Text.Color = Color.FromArgb(151, 134, 108);
			int num17 = this.calcMidSize(num8);
			if (num8 > 0)
			{
				if (flag)
				{
					this.troopMake1Button1.Active = true;
					this.troopMake1Button1.Text.Color = global::ARGBColors.Black;
				}
				if (num8 >= num17)
				{
					this.troopMake1Button5.Text.Text = num17.ToString();
					if (flag)
					{
						this.troopMake1Button5.Active = true;
						this.troopMake1Button5.Text.Color = global::ARGBColors.Black;
					}
				}
				if (num8 > 1)
				{
					this.troopMake1Button20.Text.Text = num8.ToString();
					if (flag)
					{
						this.troopMake1Button20.Active = true;
						this.troopMake1Button20.Text.Color = global::ARGBColors.Black;
					}
				}
			}
			this.troopMake2Button1.invalidate();
			this.troopMake2Button1.Active = false;
			this.troopMake2Button1.Text.Color = Color.FromArgb(151, 134, 108);
			this.troopMake2Button5.Active = false;
			this.troopMake2Button5.Text.Color = Color.FromArgb(151, 134, 108);
			this.troopMake2Button20.Active = false;
			this.troopMake2Button20.Text.Color = Color.FromArgb(151, 134, 108);
			int num18 = this.calcMidSize(num9);
			if (num9 > 0)
			{
				if (flag)
				{
					this.troopMake2Button1.Active = true;
					this.troopMake2Button1.Text.Color = global::ARGBColors.Black;
				}
				if (num9 >= num18)
				{
					this.troopMake2Button5.Text.Text = num18.ToString();
					if (flag)
					{
						this.troopMake2Button5.Active = true;
						this.troopMake2Button5.Text.Color = global::ARGBColors.Black;
					}
				}
				if (num9 > 1)
				{
					this.troopMake2Button20.Text.Text = num9.ToString();
					if (flag)
					{
						this.troopMake2Button20.Active = true;
						this.troopMake2Button20.Text.Color = global::ARGBColors.Black;
					}
				}
			}
			this.troopMake3Button1.invalidate();
			this.troopMake3Button1.Active = false;
			this.troopMake3Button1.Text.Color = Color.FromArgb(151, 134, 108);
			this.troopMake3Button5.Active = false;
			this.troopMake3Button5.Text.Color = Color.FromArgb(151, 134, 108);
			this.troopMake3Button20.Active = false;
			this.troopMake3Button20.Text.Color = Color.FromArgb(151, 134, 108);
			int num19 = this.calcMidSize(num10);
			if (num10 > 0)
			{
				if (flag)
				{
					this.troopMake3Button1.Active = true;
					this.troopMake3Button1.Text.Color = global::ARGBColors.Black;
				}
				if (num10 >= num19)
				{
					this.troopMake3Button5.Text.Text = num19.ToString();
					if (flag)
					{
						this.troopMake3Button5.Active = true;
						this.troopMake3Button5.Text.Color = global::ARGBColors.Black;
					}
				}
				if (num10 > 1)
				{
					this.troopMake3Button20.Text.Text = num10.ToString();
					if (flag)
					{
						this.troopMake3Button20.Active = true;
						this.troopMake3Button20.Text.Color = global::ARGBColors.Black;
					}
				}
			}
			this.troopMake4Button1.invalidate();
			this.troopMake4Button1.Active = false;
			this.troopMake4Button1.Text.Color = Color.FromArgb(151, 134, 108);
			this.troopMake4Button5.Active = false;
			this.troopMake4Button5.Text.Color = Color.FromArgb(151, 134, 108);
			this.troopMake4Button20.Active = false;
			this.troopMake4Button20.Text.Color = Color.FromArgb(151, 134, 108);
			int num20 = this.calcMidSize(num11);
			if (num11 > 0 && flag)
			{
				if (flag)
				{
					this.troopMake4Button1.Active = true;
					this.troopMake4Button1.Text.Color = global::ARGBColors.Black;
				}
				if (num11 >= num20)
				{
					this.troopMake4Button5.Text.Text = num20.ToString();
					if (flag)
					{
						this.troopMake4Button5.Active = true;
						this.troopMake4Button5.Text.Color = global::ARGBColors.Black;
					}
				}
				if (num11 > 1)
				{
					this.troopMake4Button20.Text.Text = num11.ToString();
					if (flag)
					{
						this.troopMake4Button20.Active = true;
						this.troopMake4Button20.Text.Color = global::ARGBColors.Black;
					}
				}
			}
			this.troopMake5Button1.invalidate();
			this.troopMake5Button1.Active = false;
			this.troopMake5Button1.Text.Color = Color.FromArgb(151, 134, 108);
			this.troopMake5Button5.Active = false;
			this.troopMake5Button5.Text.Color = Color.FromArgb(151, 134, 108);
			this.troopMake5Button20.Active = false;
			this.troopMake5Button20.Text.Color = Color.FromArgb(151, 134, 108);
			int num21 = this.calcMidSize(num12);
			if (num12 > 0 && flag)
			{
				if (flag)
				{
					this.troopMake5Button1.Active = true;
					this.troopMake5Button1.Text.Color = global::ARGBColors.Black;
				}
				if (num12 >= num21)
				{
					this.troopMake5Button5.Text.Text = num21.ToString();
					if (flag)
					{
						this.troopMake5Button5.Active = true;
						this.troopMake5Button5.Text.Color = global::ARGBColors.Black;
					}
				}
				if (num12 > 1)
				{
					this.troopMake5Button20.Text.Text = num12.ToString();
					if (flag)
					{
						this.troopMake5Button20.Active = true;
						this.troopMake5Button20.Text.Color = global::ARGBColors.Black;
					}
				}
			}
			int num22 = 0;
			int num23 = 0;
			int num24 = 0;
			int num25 = 0;
			int num26 = 0;
			int num27 = 0;
			int num28 = 0;
			int num29 = 0;
			int num30 = 0;
			int num31 = 0;
			int num32 = 0;
			int num33 = 0;
			GameEngine.Instance.World.getTotalTroopsOutOfVillage(village.VillageID, ref num22, ref num23, ref num24, ref num25, ref num26, ref num27, ref num28, ref num29, ref num30, ref num31, ref num32, ref num33);
			int num34 = 0;
			int num35 = 0;
			int num36 = 0;
			int num37 = 0;
			int num38 = 0;
			castle.countOwnPlacedTroopTypes(ref num34, ref num35, ref num36, ref num37, ref num38);
			this.inCastlePeasantsLabel.Text = num34.ToString("N", nfi);
			this.inCastleArchersLabel.Text = num35.ToString("N", nfi);
			this.inCastlePikmenLabel.Text = num36.ToString("N", nfi);
			this.inCastleSwordsmenLabel.Text = num37.ToString("N", nfi);
			this.attackingPeasantsLabel.Text = num22.ToString("N", nfi);
			this.attackingArchersLabel.Text = num23.ToString("N", nfi);
			this.attackingPikmenLabel.Text = num24.ToString("N", nfi);
			this.attackingSwordsmenLabel.Text = num25.ToString("N", nfi);
			this.attackingCatapultsLabel.Text = num26.ToString("N", nfi);
			this.reinforcingPeasantsLabel.Text = num28.ToString("N", nfi);
			this.reinforcingArchersLabel.Text = num29.ToString("N", nfi);
			this.reinforcingPikmenLabel.Text = num30.ToString("N", nfi);
			this.reinforcingSwordsmenLabel.Text = num31.ToString("N", nfi);
			this.reinforcingCatapultsLabel.Text = num32.ToString("N", nfi);
			num22 += village.m_numPeasants + locallyMade_Peasants;
			num22 += num34;
			num22 += num28;
			num23 += village.m_numArchers + locallyMade_Archers;
			num23 += num35;
			num23 += num29;
			num24 += village.m_numPikemen + locallyMade_Pikemen;
			num24 += num36;
			num24 += num30;
			num25 += village.m_numSwordsmen + locallyMade_Swordsmen;
			num25 += num37;
			num25 += num31;
			num26 += village.m_numCatapults + locallyMade_Catapults;
			num26 += num32;
			this.troopsMade1Disband.Text.Text = num22.ToString("N", nfi);
			this.troopsMade2Disband.Text.Text = num23.ToString("N", nfi);
			this.troopsMade3Disband.Text.Text = num24.ToString("N", nfi);
			this.troopsMade4Disband.Text.Text = num25.ToString("N", nfi);
			this.troopsMade5Disband.Text.Text = num26.ToString("N", nfi);
			this.localPeasantsLabel.Text = (village.m_numPeasants + locallyMade_Peasants).ToString("N", nfi);
			this.localArchersLabel.Text = (village.m_numArchers + locallyMade_Archers).ToString("N", nfi);
			this.localPikmenLabel.Text = (village.m_numPikemen + locallyMade_Pikemen).ToString("N", nfi);
			this.localSwordsmenLabel.Text = (village.m_numSwordsmen + locallyMade_Swordsmen).ToString("N", nfi);
			this.localCatapultsLabel.Text = (village.m_numCatapults + locallyMade_Catapults).ToString("N", nfi);
			this.troopGoldCost1Label.Text = num3.ToString();
			this.troopGoldCost2Label.Text = num4.ToString();
			this.troopGoldCost3Label.Text = num5.ToString();
			this.troopGoldCost4Label.Text = num6.ToString();
			this.troopGoldCost5Label.Text = num7.ToString();
			if (num2 < num3)
			{
				this.troopGold1Image.Colorise = Color.FromArgb(255, 128, 128);
			}
			else
			{
				this.troopGold1Image.Colorise = global::ARGBColors.White;
			}
			if (num2 < num4)
			{
				this.troopGold2Image.Colorise = Color.FromArgb(255, 128, 128);
			}
			else
			{
				this.troopGold2Image.Colorise = global::ARGBColors.White;
			}
			if (num2 < num5)
			{
				this.troopGold3Image.Colorise = Color.FromArgb(255, 128, 128);
			}
			else
			{
				this.troopGold3Image.Colorise = global::ARGBColors.White;
			}
			if (num2 < num6)
			{
				this.troopGold4Image.Colorise = Color.FromArgb(255, 128, 128);
			}
			else
			{
				this.troopGold4Image.Colorise = global::ARGBColors.White;
			}
			if (num2 < num7)
			{
				this.troopGold5Image.Colorise = Color.FromArgb(255, 128, 128);
			}
			else
			{
				this.troopGold5Image.Colorise = global::ARGBColors.White;
			}
			this.fullBar.MaxValue = (double)GameEngine.Instance.LocalWorldData.Village_UnitCapacity;
			if (num15 < GameEngine.Instance.LocalWorldData.Village_UnitCapacity)
			{
				this.fullBar.Number = (double)num15;
				return;
			}
			this.fullBar.Number = (double)GameEngine.Instance.LocalWorldData.Village_UnitCapacity;
		}

		// Token: 0x06000788 RID: 1928 RVA: 0x0000B72B File Offset: 0x0000992B
		private int calcMidSize(int numTroops)
		{
			if (numTroops < 6)
			{
				return 999999;
			}
			if (numTroops < 30)
			{
				return 5;
			}
			return 10;
		}

		// Token: 0x06000789 RID: 1929 RVA: 0x000A0C5C File Offset: 0x0009EE5C
		private void makeTroopClick()
		{
			if (this.OverControl != null)
			{
				try
				{
					CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.OverControl;
					if (csdbutton.Active && csdbutton.Visible)
					{
						int num = csdbutton.Data;
						VillageMap village = GameEngine.Instance.Village;
						if (village != null)
						{
							int num2 = 1;
							int num3 = 0;
							switch (num % 1000)
							{
							case 70:
								num3 = this.makePeasants;
								break;
							case 71:
								num3 = this.makeSwordsmen;
								break;
							case 72:
								num3 = this.makeArchers;
								break;
							case 73:
								num3 = this.makePikemen;
								break;
							case 74:
								num3 = this.makeCatapults;
								break;
							}
							if (num >= 2000)
							{
								num2 = num3;
								num -= 2000;
							}
							else if (num >= 1000)
							{
								num2 = this.calcMidSize(num3);
								if (num2 > 10000)
								{
									goto IL_F4;
								}
								num -= 1000;
							}
							bool quickSend = false;
							if (num2 == num3)
							{
								quickSend = true;
							}
							village.makeTroops(num, num2, quickSend);
							this.updateValues();
						}
					}
					IL_F4:;
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x0600078A RID: 1930 RVA: 0x000A0D74 File Offset: 0x0009EF74
		private void makeTroopOver()
		{
			if (this.OverControl != null)
			{
				CustomSelfDrawPanel.CSDControl overControl = this.OverControl;
				int data = overControl.Data;
				this.mouseOver = data % 1000;
			}
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x0000C45B File Offset: 0x0000A65B
		private void makeTroopLeave()
		{
			this.mouseOver = -1;
		}

		// Token: 0x0600078C RID: 1932 RVA: 0x000A0DA4 File Offset: 0x0009EFA4
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
					this.m_disbandPopup = new DisbandTroopsPopup();
					this.m_disbandPopup.init(data);
					this.m_disbandPopup.Show();
				}
			}
		}

		// Token: 0x0600078D RID: 1933 RVA: 0x0000C464 File Offset: 0x0000A664
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

		// Token: 0x0600078E RID: 1934 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void attackInfoClick()
		{
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x0000B77F File Offset: 0x0000997F
		private void reinforcementInfoClick()
		{
			InterfaceMgr.Instance.setVillageTabSubMode(6);
		}

		// Token: 0x04000A2A RID: 2602
		private DockableControl dockableControl;

		// Token: 0x04000A2B RID: 2603
		private IContainer components;

		// Token: 0x04000A2C RID: 2604
		public static CapitalBarracksPanel instance;

		// Token: 0x04000A2D RID: 2605
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000A2E RID: 2606
		private CustomSelfDrawPanel.CSDArea mainBackgroundArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000A2F RID: 2607
		private CustomSelfDrawPanel.CSDLabel barracksLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A30 RID: 2608
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000A31 RID: 2609
		private CustomSelfDrawPanel.CSDImage troop1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000A32 RID: 2610
		private CustomSelfDrawPanel.CSDImage troop2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000A33 RID: 2611
		private CustomSelfDrawPanel.CSDImage troop3Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000A34 RID: 2612
		private CustomSelfDrawPanel.CSDImage troop4Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000A35 RID: 2613
		private CustomSelfDrawPanel.CSDImage troop5Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000A36 RID: 2614
		private CustomSelfDrawPanel.CSDButton troopsMade1Disband = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000A37 RID: 2615
		private CustomSelfDrawPanel.CSDButton troopsMade2Disband = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000A38 RID: 2616
		private CustomSelfDrawPanel.CSDButton troopsMade3Disband = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000A39 RID: 2617
		private CustomSelfDrawPanel.CSDButton troopsMade4Disband = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000A3A RID: 2618
		private CustomSelfDrawPanel.CSDButton troopsMade5Disband = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000A3B RID: 2619
		private CustomSelfDrawPanel.CSDLabel troopGoldCost1Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A3C RID: 2620
		private CustomSelfDrawPanel.CSDLabel troopGoldCost2Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A3D RID: 2621
		private CustomSelfDrawPanel.CSDLabel troopGoldCost3Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A3E RID: 2622
		private CustomSelfDrawPanel.CSDLabel troopGoldCost4Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A3F RID: 2623
		private CustomSelfDrawPanel.CSDLabel troopGoldCost5Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A40 RID: 2624
		private CustomSelfDrawPanel.CSDButton troopMake1Button1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000A41 RID: 2625
		private CustomSelfDrawPanel.CSDButton troopMake2Button1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000A42 RID: 2626
		private CustomSelfDrawPanel.CSDButton troopMake3Button1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000A43 RID: 2627
		private CustomSelfDrawPanel.CSDButton troopMake4Button1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000A44 RID: 2628
		private CustomSelfDrawPanel.CSDButton troopMake5Button1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000A45 RID: 2629
		private CustomSelfDrawPanel.CSDButton troopMake1Button5 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000A46 RID: 2630
		private CustomSelfDrawPanel.CSDButton troopMake2Button5 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000A47 RID: 2631
		private CustomSelfDrawPanel.CSDButton troopMake3Button5 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000A48 RID: 2632
		private CustomSelfDrawPanel.CSDButton troopMake4Button5 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000A49 RID: 2633
		private CustomSelfDrawPanel.CSDButton troopMake5Button5 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000A4A RID: 2634
		private CustomSelfDrawPanel.CSDButton troopMake1Button20 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000A4B RID: 2635
		private CustomSelfDrawPanel.CSDButton troopMake2Button20 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000A4C RID: 2636
		private CustomSelfDrawPanel.CSDButton troopMake3Button20 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000A4D RID: 2637
		private CustomSelfDrawPanel.CSDButton troopMake4Button20 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000A4E RID: 2638
		private CustomSelfDrawPanel.CSDButton troopMake5Button20 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000A4F RID: 2639
		private CustomSelfDrawPanel.CSDImage troopGold1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000A50 RID: 2640
		private CustomSelfDrawPanel.CSDImage troopGold2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000A51 RID: 2641
		private CustomSelfDrawPanel.CSDImage troopGold3Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000A52 RID: 2642
		private CustomSelfDrawPanel.CSDImage troopGold4Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000A53 RID: 2643
		private CustomSelfDrawPanel.CSDImage troopGold5Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000A54 RID: 2644
		private CustomSelfDrawPanel.CSDLabel troopCtrl1Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A55 RID: 2645
		private CustomSelfDrawPanel.CSDLabel troopCtrl2Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A56 RID: 2646
		private CustomSelfDrawPanel.CSDLabel troopCtrl3Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A57 RID: 2647
		private CustomSelfDrawPanel.CSDLabel troopCtrl4Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A58 RID: 2648
		private CustomSelfDrawPanel.CSDLabel troopCtrl5Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A59 RID: 2649
		private CustomSelfDrawPanel.CSDImage goldImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000A5A RID: 2650
		private CustomSelfDrawPanel.CSDLabel goldLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A5B RID: 2651
		private CustomSelfDrawPanel.CSDLabel CurrentTroopsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A5C RID: 2652
		private CustomSelfDrawPanel.CSDLabel SpaceLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A5D RID: 2653
		private CustomSelfDrawPanel.CSDLabel MaxLabelLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A5E RID: 2654
		private CustomSelfDrawPanel.CSDColorBar fullBar = new CustomSelfDrawPanel.CSDColorBar();

		// Token: 0x04000A5F RID: 2655
		private CustomSelfDrawPanel.CSDLabel BottomHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A60 RID: 2656
		private CustomSelfDrawPanel.CSDLabel LocalLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A61 RID: 2657
		private CustomSelfDrawPanel.CSDLabel InCastleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A62 RID: 2658
		private CustomSelfDrawPanel.CSDLabel AttackingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A63 RID: 2659
		private CustomSelfDrawPanel.CSDLabel ReinforcingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A64 RID: 2660
		private CustomSelfDrawPanel.CSDImage smallPeasantImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000A65 RID: 2661
		private CustomSelfDrawPanel.CSDLabel localPeasantsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A66 RID: 2662
		private CustomSelfDrawPanel.CSDLabel localArchersLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A67 RID: 2663
		private CustomSelfDrawPanel.CSDLabel localPikmenLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A68 RID: 2664
		private CustomSelfDrawPanel.CSDLabel localSwordsmenLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A69 RID: 2665
		private CustomSelfDrawPanel.CSDLabel localCatapultsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A6A RID: 2666
		private CustomSelfDrawPanel.CSDLabel localCaptainsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A6B RID: 2667
		private CustomSelfDrawPanel.CSDLabel inCastlePeasantsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A6C RID: 2668
		private CustomSelfDrawPanel.CSDLabel inCastleArchersLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A6D RID: 2669
		private CustomSelfDrawPanel.CSDLabel inCastlePikmenLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A6E RID: 2670
		private CustomSelfDrawPanel.CSDLabel inCastleSwordsmenLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A6F RID: 2671
		private CustomSelfDrawPanel.CSDLabel inCastleCatapultsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A70 RID: 2672
		private CustomSelfDrawPanel.CSDLabel inCastleCaptainsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A71 RID: 2673
		private CustomSelfDrawPanel.CSDLabel attackingPeasantsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A72 RID: 2674
		private CustomSelfDrawPanel.CSDLabel attackingArchersLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A73 RID: 2675
		private CustomSelfDrawPanel.CSDLabel attackingPikmenLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A74 RID: 2676
		private CustomSelfDrawPanel.CSDLabel attackingSwordsmenLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A75 RID: 2677
		private CustomSelfDrawPanel.CSDLabel attackingCatapultsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A76 RID: 2678
		private CustomSelfDrawPanel.CSDLabel attackingCaptainsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A77 RID: 2679
		private CustomSelfDrawPanel.CSDLabel reinforcingPeasantsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A78 RID: 2680
		private CustomSelfDrawPanel.CSDLabel reinforcingArchersLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A79 RID: 2681
		private CustomSelfDrawPanel.CSDLabel reinforcingPikmenLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A7A RID: 2682
		private CustomSelfDrawPanel.CSDLabel reinforcingSwordsmenLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A7B RID: 2683
		private CustomSelfDrawPanel.CSDLabel reinforcingCatapultsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A7C RID: 2684
		private CustomSelfDrawPanel.CSDLabel reinforcingCaptainsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A7D RID: 2685
		private CustomSelfDrawPanel.CSDButton attackInfoButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000A7E RID: 2686
		private CustomSelfDrawPanel.CSDButton reinforcementInfoButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000A7F RID: 2687
		private int makePeasants = 10;

		// Token: 0x04000A80 RID: 2688
		private int makeArchers = 10;

		// Token: 0x04000A81 RID: 2689
		private int makePikemen = 10;

		// Token: 0x04000A82 RID: 2690
		private int makeSwordsmen = 10;

		// Token: 0x04000A83 RID: 2691
		private int makeCatapults = 10;

		// Token: 0x04000A84 RID: 2692
		private int mouseOver = -1;

		// Token: 0x04000A85 RID: 2693
		private DisbandTroopsPopup m_disbandPopup;
	}
}
