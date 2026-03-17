using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020000DE RID: 222
	public class BarracksPanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600066E RID: 1646 RVA: 0x0000B66A File Offset: 0x0000986A
		public static List<WorldMap.VillageNameItem> ExchangeHistory
		{
			get
			{
				return BarracksPanel.exchangeHistory;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600066F RID: 1647 RVA: 0x0000B671 File Offset: 0x00009871
		public static List<WorldMap.VillageNameItem> ExchangeFavourites
		{
			get
			{
				return BarracksPanel.exchangeFavourites;
			}
		}

		// Token: 0x06000670 RID: 1648 RVA: 0x0000B678 File Offset: 0x00009878
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06000671 RID: 1649 RVA: 0x0000B688 File Offset: 0x00009888
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06000672 RID: 1650 RVA: 0x0000B698 File Offset: 0x00009898
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06000673 RID: 1651 RVA: 0x0000B6AA File Offset: 0x000098AA
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06000674 RID: 1652 RVA: 0x0000B6B7 File Offset: 0x000098B7
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closeDisbandPopup();
		}

		// Token: 0x06000675 RID: 1653 RVA: 0x0000B6D1 File Offset: 0x000098D1
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06000676 RID: 1654 RVA: 0x0000B6DE File Offset: 0x000098DE
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06000677 RID: 1655 RVA: 0x0000B6EB File Offset: 0x000098EB
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000678 RID: 1656 RVA: 0x000845E0 File Offset: 0x000827E0
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			base.Name = "BarracksPanel";
			this.MaximumSize = new Size(992, 566);
			this.MinimumSize = new Size(992, 566);
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x06000679 RID: 1657 RVA: 0x0008464C File Offset: 0x0008284C
		public static void addHistory(GenericVillageHistoryData[] newData)
		{
			BarracksPanel.exchangeHistory.Clear();
			if (newData == null)
			{
				return;
			}
			foreach (GenericVillageHistoryData genericVillageHistoryData in newData)
			{
				WorldMap.VillageNameItem villageNameItem = new WorldMap.VillageNameItem();
				if (GameEngine.Instance.World.isCapital(genericVillageHistoryData.villageID))
				{
					villageNameItem.villageID = genericVillageHistoryData.villageID;
					BarracksPanel.exchangeHistory.Add(villageNameItem);
				}
			}
		}

		// Token: 0x0600067A RID: 1658 RVA: 0x000846B0 File Offset: 0x000828B0
		public static void addFavourites(GenericVillageHistoryData[] newData)
		{
			BarracksPanel.exchangeFavourites.Clear();
			if (newData == null)
			{
				return;
			}
			foreach (GenericVillageHistoryData genericVillageHistoryData in newData)
			{
				WorldMap.VillageNameItem villageNameItem = new WorldMap.VillageNameItem();
				if (GameEngine.Instance.World.isCapital(genericVillageHistoryData.villageID))
				{
					villageNameItem.villageID = genericVillageHistoryData.villageID;
					BarracksPanel.exchangeFavourites.Add(villageNameItem);
				}
			}
		}

		// Token: 0x0600067B RID: 1659 RVA: 0x00084714 File Offset: 0x00082914
		public BarracksPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x0600067C RID: 1660 RVA: 0x00084C0C File Offset: 0x00082E0C
		public void init()
		{
			BarracksPanel.instance = this;
			base.clearControls();
			this.mainBackgroundImage.Image = GFXLibrary.barracks_background;
			this.mainBackgroundImage.Position = new Point(0, 0);
			base.addControl(this.mainBackgroundImage);
			this.mainBackgroundArea.Position = new Point(0, 0);
			this.mainBackgroundArea.Size = new Size(992, 566);
			this.mainBackgroundImage.addControl(this.mainBackgroundArea);
			InterfaceMgr.Instance.setVillageHeading(SK.Text("BarracksScreen_Barracks", "Barracks"));
			this.troopsMade1Disband.ImageNorm = GFXLibrary.barracks_little_button_normal;
			this.troopsMade1Disband.ImageOver = GFXLibrary.barracks_little_button_over;
			this.troopsMade1Disband.Position = new Point(109, 46);
			this.troopsMade1Disband.Text.Text = "0";
			this.troopsMade1Disband.Text.Color = global::ARGBColors.Black;
			this.troopsMade1Disband.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopsMade1Disband.TextYOffset = 0;
			this.troopsMade1Disband.Data = 70;
			this.troopsMade1Disband.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.disbandTroopsClick), "BarracksPanel_disband_peasants");
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
			this.troopMake1Button1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
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
			this.troopMake1Button5.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
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
			this.troopMake1Button20.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
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
			this.troopsMade2Disband.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.disbandTroopsClick), "BarracksPanel_disband_archer");
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
			this.troopMake2Button1.Text.Size = new Size(this.troopMake2Button1.Width - 5, this.troopMake2Button1.Height);
			this.troopMake2Button1.Text.Position = new Point(5, 0);
			this.troopMake2Button1.TextYOffset = 1;
			this.troopMake2Button1.Position = new Point(10, y);
			this.troopMake2Button1.Text.Text = "1";
			this.troopMake2Button1.Text.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.troopMake2Button1.Text.Color = global::ARGBColors.Black;
			this.troopMake2Button1.Data = 72;
			this.troopMake2Button1.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake2Button1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
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
			this.troopMake2Button5.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
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
			this.troopMake2Button20.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
			this.troop2Image.addControl(this.troopMake2Button20);
			this.troopGold2Image.Image = GFXLibrary.com_32_money;
			this.troopGold2Image.Position = new Point(117, 173);
			this.troop2Image.addControl(this.troopGold2Image);
			this.troop2Weapon1Image.Image = GFXLibrary.com_32_bows_DS;
			this.troop2Weapon1Image.Position = new Point(112, 123);
			this.troop2Image.addControl(this.troop2Weapon1Image);
			this.troopsMade3Disband.ImageNorm = GFXLibrary.barracks_little_button_normal;
			this.troopsMade3Disband.ImageOver = GFXLibrary.barracks_little_button_over;
			this.troopsMade3Disband.Position = new Point(431, 46);
			this.troopsMade3Disband.Text.Text = "0";
			this.troopsMade3Disband.Text.Color = global::ARGBColors.Black;
			this.troopsMade3Disband.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopsMade3Disband.TextYOffset = 0;
			this.troopsMade3Disband.Data = 73;
			this.troopsMade3Disband.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.disbandTroopsClick), "BarracksPanel_disband_pikemen");
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
			this.troopMake3Button1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
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
			this.troopMake3Button5.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
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
			this.troopMake3Button20.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
			this.troop3Image.addControl(this.troopMake3Button20);
			this.troopGold3Image.Image = GFXLibrary.com_32_money;
			this.troopGold3Image.Position = new Point(117, 173);
			this.troop3Image.addControl(this.troopGold3Image);
			this.troop3Weapon1Image.Image = GFXLibrary.com_32_pikes_DS;
			this.troop3Weapon1Image.Position = new Point(112, 123);
			this.troop3Image.addControl(this.troop3Weapon1Image);
			this.troop3Weapon2Image.Image = GFXLibrary.com_32_armour_DS;
			this.troop3Weapon2Image.Position = new Point(112, 78);
			this.troop3Image.addControl(this.troop3Weapon2Image);
			this.troopsMade4Disband.ImageNorm = GFXLibrary.barracks_little_button_normal;
			this.troopsMade4Disband.ImageOver = GFXLibrary.barracks_little_button_over;
			this.troopsMade4Disband.Position = new Point(592, 46);
			this.troopsMade4Disband.Text.Text = "0";
			this.troopsMade4Disband.Text.Color = global::ARGBColors.Black;
			this.troopsMade4Disband.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopsMade4Disband.TextYOffset = 0;
			this.troopsMade4Disband.Data = 71;
			this.troopsMade4Disband.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.disbandTroopsClick), "BarracksPanel_disband_swordsmen");
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
			this.troopMake4Button1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
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
			this.troopMake4Button5.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
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
			this.troopMake4Button20.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
			this.troop4Image.addControl(this.troopMake4Button20);
			this.troopGold4Image.Image = GFXLibrary.com_32_money;
			this.troopGold4Image.Position = new Point(117, 173);
			this.troop4Image.addControl(this.troopGold4Image);
			this.troop4Weapon1Image.Image = GFXLibrary.com_32_swords_DS;
			this.troop4Weapon1Image.Position = new Point(112, 123);
			this.troop4Image.addControl(this.troop4Weapon1Image);
			this.troop4Weapon2Image.Image = GFXLibrary.com_32_armour_DS;
			this.troop4Weapon2Image.Position = new Point(112, 78);
			this.troop4Image.addControl(this.troop4Weapon2Image);
			this.troopsMade5Disband.ImageNorm = GFXLibrary.barracks_little_button_normal;
			this.troopsMade5Disband.ImageOver = GFXLibrary.barracks_little_button_over;
			this.troopsMade5Disband.Position = new Point(753, 46);
			this.troopsMade5Disband.Text.Text = "0";
			this.troopsMade5Disband.Text.Color = global::ARGBColors.Black;
			this.troopsMade5Disband.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopsMade5Disband.TextYOffset = 0;
			this.troopsMade5Disband.Data = 74;
			this.troopsMade5Disband.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.disbandTroopsClick), "BarracksPanel_disband_catapults");
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
			this.troopMake5Button1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
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
			this.troopMake5Button5.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
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
			this.troopMake5Button20.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
			this.troop5Image.addControl(this.troopMake5Button20);
			this.troopGold5Image.Image = GFXLibrary.com_32_money;
			this.troopGold5Image.Position = new Point(117, 173);
			this.troop5Image.addControl(this.troopGold5Image);
			this.troop5Weapon1Image.Image = GFXLibrary.com_32_catapults_DS;
			this.troop5Weapon1Image.Position = new Point(112, 123);
			this.troop5Image.addControl(this.troop5Weapon1Image);
			this.troopsMade6Disband.ImageNorm = GFXLibrary.barracks_little_button_normal;
			this.troopsMade6Disband.ImageOver = GFXLibrary.barracks_little_button_over;
			this.troopsMade6Disband.Position = new Point(914, 46);
			this.troopsMade6Disband.Text.Text = "0";
			this.troopsMade6Disband.Text.Color = global::ARGBColors.Black;
			this.troopsMade6Disband.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopsMade6Disband.TextYOffset = 0;
			this.troopsMade6Disband.Data = 100;
			this.troopsMade6Disband.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.disbandTroopsClick), "BarracksPanel_disband_captain");
			this.troopsMade6Disband.CustomTooltipID = 600;
			this.mainBackgroundArea.addControl(this.troopsMade6Disband);
			this.troop6Image.Image = GFXLibrary.barracks_unit_captain;
			this.troop6Image.Position = new Point(817, 12);
			this.mainBackgroundArea.addControl(this.troop6Image);
			this.troopGoldCost6Label.Text = "0";
			this.troopGoldCost6Label.Color = Color.FromArgb(208, 165, 102);
			this.troopGoldCost6Label.Position = new Point(69, 165);
			this.troopGoldCost6Label.Size = new Size(44, 47);
			this.troopGoldCost6Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.troopGoldCost6Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.troop6Image.addControl(this.troopGoldCost6Label);
			this.troopMake6Button1.ImageNorm = GFXLibrary.button3comp_left_normal;
			this.troopMake6Button1.ImageOver = GFXLibrary.button3comp_left_over;
			this.troopMake6Button1.ImageClick = GFXLibrary.button3comp_left_pressed;
			this.troopMake6Button1.Position = new Point(10, y);
			this.troopMake6Button1.Text.Text = "1";
			this.troopMake6Button1.TextYOffset = 1;
			this.troopMake6Button1.Text.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.troopMake6Button1.Text.Color = global::ARGBColors.Black;
			this.troopMake6Button1.Text.Size = new Size(this.troopMake6Button1.Width - 5, this.troopMake6Button1.Height);
			this.troopMake6Button1.Text.Position = new Point(5, 0);
			this.troopMake6Button1.Data = 100;
			this.troopMake6Button1.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake6Button1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
			this.troop6Image.addControl(this.troopMake6Button1);
			this.troopMake6Button5.ImageNorm = GFXLibrary.button3comp_mid_normal;
			this.troopMake6Button5.ImageOver = GFXLibrary.button3comp_mid_over;
			this.troopMake6Button5.ImageClick = GFXLibrary.button3comp_mid_pushed;
			this.troopMake6Button5.Position = new Point(60, y);
			this.troopMake6Button5.Text.Text = "5";
			this.troopMake6Button5.TextYOffset = 1;
			this.troopMake6Button5.Text.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.troopMake6Button5.Text.Color = global::ARGBColors.Black;
			this.troopMake6Button5.Data = 1100;
			this.troopMake6Button5.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake6Button5.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
			this.troop6Image.addControl(this.troopMake6Button5);
			this.troopMake6Button20.ImageNorm = GFXLibrary.button3comp_right_normal;
			this.troopMake6Button20.ImageOver = GFXLibrary.button3comp_right_over;
			this.troopMake6Button20.ImageClick = GFXLibrary.button3comp_right_pushed;
			this.troopMake6Button20.Position = new Point(108, y);
			this.troopMake6Button20.Text.Text = "20";
			this.troopMake6Button20.TextYOffset = 1;
			this.troopMake6Button20.Text.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.troopMake6Button20.Text.Color = global::ARGBColors.Black;
			this.troopMake6Button20.Text.Size = new Size(this.troopMake6Button20.Width - 5, this.troopMake6Button20.Height);
			this.troopMake6Button20.Data = 2100;
			this.troopMake6Button20.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.makeTroopLeave));
			this.troopMake6Button20.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.makeTroopClick));
			this.troop6Image.addControl(this.troopMake6Button20);
			this.troopGold6Image.Image = GFXLibrary.com_32_money;
			this.troopGold6Image.Position = new Point(117, 173);
			this.troop6Image.addControl(this.troopGold6Image);
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
			this.item2Image.Image = GFXLibrary.com_32_bows_DS;
			this.item2Image.Position = new Point(num + 75, 310);
			this.mainBackgroundArea.addControl(this.item2Image);
			this.item2AmountLabel.Text = "0";
			this.item2AmountLabel.Color = global::ARGBColors.Black;
			this.item2AmountLabel.Position = new Point(num - 3 + 75, 352);
			this.item2AmountLabel.Size = new Size(50, 20);
			this.item2AmountLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.item2AmountLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.mainBackgroundArea.addControl(this.item2AmountLabel);
			this.item3Image.Image = GFXLibrary.com_32_armour_DS;
			this.item3Image.Position = new Point(num + 150, 310);
			this.mainBackgroundArea.addControl(this.item3Image);
			this.item3AmountLabel.Text = "0";
			this.item3AmountLabel.Color = global::ARGBColors.Black;
			this.item3AmountLabel.Position = new Point(num - 3 + 150, 352);
			this.item3AmountLabel.Size = new Size(50, 20);
			this.item3AmountLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.item3AmountLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.mainBackgroundArea.addControl(this.item3AmountLabel);
			this.item4Image.Image = GFXLibrary.com_32_pikes_DS;
			this.item4Image.Position = new Point(num + 225, 310);
			this.mainBackgroundArea.addControl(this.item4Image);
			this.item4AmountLabel.Text = "0";
			this.item4AmountLabel.Color = global::ARGBColors.Black;
			this.item4AmountLabel.Position = new Point(num - 3 + 225, 352);
			this.item4AmountLabel.Size = new Size(50, 20);
			this.item4AmountLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.item4AmountLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.mainBackgroundArea.addControl(this.item4AmountLabel);
			this.item5Image.Image = GFXLibrary.com_32_swords_DS;
			this.item5Image.Position = new Point(num + 300, 310);
			this.mainBackgroundArea.addControl(this.item5Image);
			this.item5AmountLabel.Text = "0";
			this.item5AmountLabel.Color = global::ARGBColors.Black;
			this.item5AmountLabel.Position = new Point(num - 3 + 300, 352);
			this.item5AmountLabel.Size = new Size(50, 20);
			this.item5AmountLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.item5AmountLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.mainBackgroundArea.addControl(this.item5AmountLabel);
			this.item6Image.Image = GFXLibrary.com_32_catapults_DS;
			this.item6Image.Position = new Point(num + 375, 310);
			this.mainBackgroundArea.addControl(this.item6Image);
			this.item6AmountLabel.Text = "0";
			this.item6AmountLabel.Color = global::ARGBColors.Black;
			this.item6AmountLabel.Position = new Point(num - 3 + 375, 352);
			this.item6AmountLabel.Size = new Size(50, 20);
			this.item6AmountLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.item6AmountLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.mainBackgroundArea.addControl(this.item6AmountLabel);
			this.CurrentTroopsLabel.Text = SK.Text("BARRACKS_Troops", "Troops") + ": 0";
			this.CurrentTroopsLabel.Color = global::ARGBColors.Black;
			if (Program.mySettings.LanguageIdent == "pl" || Program.mySettings.LanguageIdent == "it" || Program.mySettings.LanguageIdent == "pt")
			{
				this.CurrentTroopsLabel.Position = new Point(560, 362);
			}
			else
			{
				this.CurrentTroopsLabel.Position = new Point(560, 357);
			}
			this.CurrentTroopsLabel.Size = new Size(200, 20);
			this.CurrentTroopsLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.CurrentTroopsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.mainBackgroundArea.addControl(this.CurrentTroopsLabel);
			this.SpaceLabel.Text = SK.Text("BARRACKS_Spare_Unit_Space", "Spare Unit Space") + ": 0";
			this.SpaceLabel.Color = global::ARGBColors.Black;
			if (Program.mySettings.LanguageIdent == "pl" || Program.mySettings.LanguageIdent == "it" || Program.mySettings.LanguageIdent == "pt")
			{
				this.SpaceLabel.Position = new Point(560, 329);
				this.SpaceLabel.Size = new Size(416, 20);
			}
			else
			{
				this.SpaceLabel.Position = new Point(560, 334);
				this.SpaceLabel.Size = new Size(216, 20);
			}
			this.SpaceLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.SpaceLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.mainBackgroundArea.addControl(this.SpaceLabel);
			this.MaxLabelLabel.Text = SK.Text("BARRACKS_Max_Army_Size", "Max Army Size") + ": 0";
			this.MaxLabelLabel.Color = global::ARGBColors.Black;
			if (Program.mySettings.LanguageIdent == "it" || Program.mySettings.LanguageIdent == "pt")
			{
				this.MaxLabelLabel.Position = new Point(700, 362);
			}
			else if (Program.mySettings.LanguageIdent == "pl")
			{
				this.MaxLabelLabel.Position = new Point(770, 362);
			}
			else
			{
				this.MaxLabelLabel.Position = new Point(770, 357);
			}
			this.MaxLabelLabel.Size = new Size(270, 20);
			this.MaxLabelLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.MaxLabelLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.mainBackgroundArea.addControl(this.MaxLabelLabel);
			this.fullBar.setImages(GFXLibrary.barracks_fillbar_back, GFXLibrary.barracks_fillbar_fill_left, GFXLibrary.barracks_fillbar_fill_mid, GFXLibrary.barracks_fillbar_fill_right, GFXLibrary.barracks_fillbar_back, GFXLibrary.barracks_fillbar_fill_left, GFXLibrary.barracks_fillbar_fill_mid, GFXLibrary.barracks_fillbar_fill_right);
			this.fullBar.Number = 0.0;
			this.fullBar.MaxValue = 9.0;
			this.fullBar.SetMargin(2, 2, 2, 3);
			if (Program.mySettings.LanguageIdent == "pl" || Program.mySettings.LanguageIdent == "it" || Program.mySettings.LanguageIdent == "pt")
			{
				this.fullBar.Position = new Point(770, 349);
			}
			else
			{
				this.fullBar.Position = new Point(770, 339);
			}
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
			this.attackInfoButton.ImageNorm = GFXLibrary.barracks_i_button_normal;
			this.attackInfoButton.ImageOver = GFXLibrary.barracks_i_button_over;
			this.attackInfoButton.Position = new Point(865, num2 + 2 * num3 - 1);
			this.attackInfoButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.attackInfoClick), "BarracksPanel_attack_info");
			this.mainBackgroundArea.addControl(this.attackInfoButton);
			this.reinforcementInfoButton.ImageNorm = GFXLibrary.barracks_i_button_normal;
			this.reinforcementInfoButton.ImageOver = GFXLibrary.barracks_i_button_over;
			this.reinforcementInfoButton.Position = new Point(865, num2 + 3 * num3 - 1);
			this.reinforcementInfoButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.reinforcementInfoClick), "BarracksPanel_reinforcements_info");
			this.mainBackgroundArea.addControl(this.reinforcementInfoButton);
			this.closeButton.ImageNorm = GFXLibrary.int_button_close_normal;
			this.closeButton.ImageOver = GFXLibrary.int_button_close_over;
			this.closeButton.ImageClick = GFXLibrary.int_button_close_in;
			this.closeButton.Position = new Point(948, 10);
			this.closeButton.CustomTooltipID = 601;
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "BarracksPanel_close");
			this.mainBackgroundArea.addControl(this.closeButton);
			CustomSelfDrawPanel.WikiLinkControl.init(this.mainBackgroundArea, 5, new Point(898, 10));
			this.cardbar.Position = new Point(0, 0);
			this.mainBackgroundArea.addControl(this.cardbar);
			this.cardbar.init(2);
			this.update();
		}

		// Token: 0x0600067D RID: 1661 RVA: 0x0000B70A File Offset: 0x0000990A
		public void update()
		{
			this.updateValues();
			this.cardbar.update();
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x0000B71E File Offset: 0x0000991E
		public void closeClick()
		{
			InterfaceMgr.Instance.setVillageTabSubMode(-1);
		}

		// Token: 0x0600067F RID: 1663 RVA: 0x000888CC File Offset: 0x00086ACC
		public void updateValues()
		{
			NumberFormatInfo nfi = GameEngine.NFI;
			WorldData localWorldData = GameEngine.Instance.LocalWorldData;
			VillageMap village = GameEngine.Instance.Village;
			CastleMap castle = GameEngine.Instance.Castle;
			if (village != null && castle != null)
			{
				int locallyMade_Peasants = village.LocallyMade_Peasants;
				int locallyMade_Archers = village.LocallyMade_Archers;
				int locallyMade_Pikemen = village.LocallyMade_Pikemen;
				int locallyMade_Swordsmen = village.LocallyMade_Swordsmen;
				int locallyMade_Catapults = village.LocallyMade_Catapults;
				int locallyMade_Captains = village.LocallyMade_Captains;
				int num = locallyMade_Swordsmen + locallyMade_Pikemen + locallyMade_Peasants + locallyMade_Catapults + locallyMade_Archers + locallyMade_Captains;
				VillageMap.ArmouryLevels armouryLevels = new VillageMap.ArmouryLevels();
				village.getArmouryLevels(armouryLevels);
				int num2 = (int)armouryLevels.bowsLevel - locallyMade_Archers;
				int num3 = (int)armouryLevels.pikesLevel - locallyMade_Pikemen;
				int num4 = (int)armouryLevels.swordsLevel - locallyMade_Swordsmen;
				int val = (int)armouryLevels.armourLevel - locallyMade_Pikemen - locallyMade_Swordsmen;
				int num5 = (int)armouryLevels.catapultsLevel - locallyMade_Catapults;
				this.item2AmountLabel.Text = num2.ToString("N", nfi);
				this.item4AmountLabel.Text = num3.ToString("N", nfi);
				this.item5AmountLabel.Text = num4.ToString("N", nfi);
				this.item3AmountLabel.Text = val.ToString("N", nfi);
				this.item6AmountLabel.Text = num5.ToString("N", nfi);
				int num6 = village.m_spareWorkers - num;
				this.item1AmountLabel.Text = num6.ToString("N", nfi);
				if (num6 == 0 && this.mouseOver >= 0)
				{
					this.item1Image.Colorise = Color.FromArgb(255, 128, 128);
				}
				else
				{
					this.item1Image.Colorise = global::ARGBColors.White;
				}
				int num7 = (int)GameEngine.Instance.World.getCurrentGold();
				num7 -= locallyMade_Peasants * localWorldData.Barracks_GoldCost_Peasant;
				num7 -= locallyMade_Archers * localWorldData.Barracks_GoldCost_Archer;
				num7 -= locallyMade_Pikemen * localWorldData.Barracks_GoldCost_Pikeman;
				num7 -= locallyMade_Swordsmen * localWorldData.Barracks_GoldCost_Swordsman;
				num7 -= locallyMade_Catapults * localWorldData.Barracks_GoldCost_Catapult;
				int num8 = CardTypes.adjustTroopCost(GameEngine.Instance.cardsManager.UserCardData, localWorldData.Barracks_GoldCost_Peasant);
				int num9 = CardTypes.adjustTroopCost(GameEngine.Instance.cardsManager.UserCardData, localWorldData.Barracks_GoldCost_Archer);
				int num10 = CardTypes.adjustTroopCost(GameEngine.Instance.cardsManager.UserCardData, localWorldData.Barracks_GoldCost_Pikeman);
				int num11 = CardTypes.adjustTroopCost(GameEngine.Instance.cardsManager.UserCardData, localWorldData.Barracks_GoldCost_Swordsman);
				int num12 = CardTypes.adjustTroopCost(GameEngine.Instance.cardsManager.UserCardData, localWorldData.Barracks_GoldCost_Catapult);
				int num13 = localWorldData.CaptainGoldCost * GameEngine.Instance.World.getNumMadeCaptains();
				int num14 = Math.Min(num6, num7 / num8);
				int num15 = Math.Min(Math.Min(num6, num7 / num9), num2);
				int num16 = Math.Min(Math.Min(Math.Min(num6, num7 / num10), num3), val);
				int num17 = Math.Min(Math.Min(Math.Min(num6, num7 / num11), num4), val);
				int num18 = Math.Min(Math.Min(num6, num7 / num12), num5);
				int num19 = Math.Min(num6, num7 / num13);
				if (num19 > 1)
				{
					num19 = 1;
				}
				int num20 = village.calcTotalTroops() + num;
				int num21 = village.calcUnitUsages() + num;
				this.CurrentTroopsLabel.Text = SK.Text("BARRACKS_Troops", "Troops") + ": " + num20.ToString("N", nfi);
				int num22 = ResearchData.commandResearchTroopLevels[(int)GameEngine.Instance.World.userResearchData.Research_Command];
				this.MaxLabelLabel.Text = SK.Text("BARRACKS_Max_Army_Size", "Max Army Size") + ": " + num22.ToString("N", nfi);
				int num23 = Math.Max(GameEngine.Instance.LocalWorldData.Village_UnitCapacity - num21, 0);
				this.SpaceLabel.Text = SK.Text("BARRACKS_Spare_Unit_Space", "Spare Unit Space") + ": " + num23.ToString("N", nfi);
				if (num14 > num23)
				{
					num14 = num23;
				}
				if (num15 > num23)
				{
					num15 = num23;
				}
				if (num16 > num23)
				{
					num16 = num23;
				}
				if (num17 > num23)
				{
					num17 = num23;
				}
				if (num18 > num23)
				{
					num18 = num23;
				}
				if (num19 > num23)
				{
					num19 = num23;
				}
				int num24 = village.m_numCaptains;
				num24 += GameEngine.Instance.World.countYourArmyCaptains(village.VillageID);
				num24 += castle.countOwnPlacedCaptains();
				this.troopsMade6Disband.Text.Text = num24.ToString("N", nfi);
				int num25 = ResearchData.captainsResearchCaptainsLevels[(int)GameEngine.Instance.World.userResearchData.Research_Captains];
				bool flag;
				if (num25 > 0)
				{
					flag = true;
					if (num24 >= num25)
					{
						num19 = 0;
					}
				}
				else
				{
					flag = false;
				}
				this.troopsMade6Disband.Visible = flag;
				if (num20 >= num22 || num21 >= GameEngine.Instance.LocalWorldData.Village_UnitCapacity)
				{
					num14 = 0;
					num15 = 0;
					num16 = 0;
					num17 = 0;
					num18 = 0;
					num19 = 0;
				}
				if (GameEngine.Instance.World.UserResearchData.Research_Conscription == 0)
				{
					num14 = 0;
					this.troop1Image.Visible = false;
				}
				else
				{
					this.troop1Image.Visible = true;
				}
				bool flag2;
				if (GameEngine.Instance.World.UserResearchData.Research_LongBow == 0)
				{
					num15 = 0;
					flag2 = false;
				}
				else
				{
					flag2 = true;
				}
				bool flag3;
				if (GameEngine.Instance.World.UserResearchData.Research_Pike == 0)
				{
					num16 = 0;
					flag3 = false;
				}
				else
				{
					flag3 = true;
				}
				bool flag4;
				if (GameEngine.Instance.World.UserResearchData.Research_Sword == 0)
				{
					num17 = 0;
					flag4 = false;
				}
				else
				{
					flag4 = true;
				}
				bool flag5;
				if (GameEngine.Instance.World.UserResearchData.Research_Catapult == 0)
				{
					num18 = 0;
					flag5 = false;
				}
				else
				{
					flag5 = true;
				}
				this.troopsMade1Disband.Visible = this.troop1Image.Visible;
				this.troopsMade2Disband.Visible = flag2;
				this.troopsMade3Disband.Visible = flag3;
				this.troopsMade4Disband.Visible = flag4;
				this.troopsMade5Disband.Visible = flag5;
				this.makePeasants = num14;
				this.makeArchers = num15;
				this.makePikemen = num16;
				this.makeSwordsmen = num17;
				this.makeCatapults = num18;
				this.makeCaptains = num19;
				this.troopMake1Button1.invalidate();
				this.troopMake1Button1.Active = false;
				this.troopMake1Button1.Text.Color = Color.FromArgb(151, 134, 108);
				this.troopMake1Button5.Active = false;
				this.troopMake1Button5.Text.Color = Color.FromArgb(151, 134, 108);
				this.troopMake1Button20.Active = false;
				this.troopMake1Button20.Text.Color = Color.FromArgb(151, 134, 108);
				int num26 = this.calcMidSize(num14);
				if (num14 > 0)
				{
					this.troopMake1Button1.Active = true;
					this.troopMake1Button1.Text.Color = global::ARGBColors.Black;
					if (num14 >= num26)
					{
						this.troopMake1Button5.Text.Text = num26.ToString();
						this.troopMake1Button5.Active = true;
						this.troopMake1Button5.Text.Color = global::ARGBColors.Black;
					}
					if (num14 > 1)
					{
						this.troopMake1Button20.Text.Text = num14.ToString();
						this.troopMake1Button20.Active = true;
						this.troopMake1Button20.Text.Color = global::ARGBColors.Black;
					}
				}
				if (this.troopMake1Button1.Active)
				{
					this.troopMake1Button1.CustomTooltipID = 0;
					this.troopMake1Button5.CustomTooltipID = 0;
					this.troopMake1Button20.CustomTooltipID = 0;
				}
				else
				{
					int num27 = 0;
					if (num6 == 0)
					{
						num27 |= 1;
					}
					if (num7 < localWorldData.Barracks_GoldCost_Peasant)
					{
						num27 |= 2;
					}
					if (num20 >= num22)
					{
						num27 |= 32;
					}
					if (num21 >= GameEngine.Instance.LocalWorldData.Village_UnitCapacity)
					{
						num27 |= 4;
					}
					this.troopMake1Button1.CustomTooltipID = 2700;
					this.troopMake1Button5.CustomTooltipID = 2700;
					this.troopMake1Button20.CustomTooltipID = 2700;
					this.troopMake1Button1.CustomTooltipData = num27;
					this.troopMake1Button5.CustomTooltipData = num27;
					this.troopMake1Button20.CustomTooltipData = num27;
				}
				this.troopMake2Button1.invalidate();
				this.troopMake2Button1.Active = false;
				this.troopMake2Button1.Text.Color = Color.FromArgb(151, 134, 108);
				this.troopMake2Button5.Active = false;
				this.troopMake2Button5.Text.Color = Color.FromArgb(151, 134, 108);
				this.troopMake2Button20.Active = false;
				this.troopMake2Button20.Text.Color = Color.FromArgb(151, 134, 108);
				int num28 = this.calcMidSize(num15);
				if (num15 > 0)
				{
					this.troopMake2Button1.Active = true;
					this.troopMake2Button1.Text.Color = global::ARGBColors.Black;
					if (num15 >= num28)
					{
						this.troopMake2Button5.Text.Text = num28.ToString();
						this.troopMake2Button5.Active = true;
						this.troopMake2Button5.Text.Color = global::ARGBColors.Black;
					}
					if (num15 > 1)
					{
						this.troopMake2Button20.Text.Text = num15.ToString();
						this.troopMake2Button20.Active = true;
						this.troopMake2Button20.Text.Color = global::ARGBColors.Black;
					}
				}
				if (this.troopMake2Button1.Active)
				{
					this.troopMake2Button1.CustomTooltipID = 0;
					this.troopMake2Button5.CustomTooltipID = 0;
					this.troopMake2Button20.CustomTooltipID = 0;
				}
				else
				{
					int num29 = 0;
					if (num6 == 0)
					{
						num29 |= 1;
					}
					if (num7 < localWorldData.Barracks_GoldCost_Archer)
					{
						num29 |= 2;
					}
					if (num20 >= num22)
					{
						num29 |= 32;
					}
					if (num21 >= GameEngine.Instance.LocalWorldData.Village_UnitCapacity)
					{
						num29 |= 4;
					}
					if (num2 <= 0)
					{
						num29 |= 16;
					}
					this.troopMake2Button1.CustomTooltipID = 2700;
					this.troopMake2Button5.CustomTooltipID = 2700;
					this.troopMake2Button20.CustomTooltipID = 2700;
					this.troopMake2Button1.CustomTooltipData = num29;
					this.troopMake2Button5.CustomTooltipData = num29;
					this.troopMake2Button20.CustomTooltipData = num29;
				}
				this.troopMake3Button1.invalidate();
				this.troopMake3Button1.Active = false;
				this.troopMake3Button1.Text.Color = Color.FromArgb(151, 134, 108);
				this.troopMake3Button5.Active = false;
				this.troopMake3Button5.Text.Color = Color.FromArgb(151, 134, 108);
				this.troopMake3Button20.Active = false;
				this.troopMake3Button20.Text.Color = Color.FromArgb(151, 134, 108);
				int num30 = this.calcMidSize(num16);
				if (num16 > 0)
				{
					this.troopMake3Button1.Active = true;
					this.troopMake3Button1.Text.Color = global::ARGBColors.Black;
					if (num16 >= num30)
					{
						this.troopMake3Button5.Text.Text = num30.ToString();
						this.troopMake3Button5.Active = true;
						this.troopMake3Button5.Text.Color = global::ARGBColors.Black;
					}
					if (num16 > 1)
					{
						this.troopMake3Button20.Text.Text = num16.ToString();
						this.troopMake3Button20.Active = true;
						this.troopMake3Button20.Text.Color = global::ARGBColors.Black;
					}
				}
				if (this.troopMake3Button1.Active)
				{
					this.troopMake3Button1.CustomTooltipID = 0;
					this.troopMake3Button5.CustomTooltipID = 0;
					this.troopMake3Button20.CustomTooltipID = 0;
				}
				else
				{
					int num31 = 0;
					if (num6 == 0)
					{
						num31 |= 1;
					}
					if (num7 < localWorldData.Barracks_GoldCost_Pikeman)
					{
						num31 |= 2;
					}
					if (num20 >= num22)
					{
						num31 |= 32;
					}
					if (num21 >= GameEngine.Instance.LocalWorldData.Village_UnitCapacity)
					{
						num31 |= 4;
					}
					if (num3 <= 0)
					{
						num31 |= 16;
					}
					this.troopMake3Button1.CustomTooltipID = 2700;
					this.troopMake3Button5.CustomTooltipID = 2700;
					this.troopMake3Button20.CustomTooltipID = 2700;
					this.troopMake3Button1.CustomTooltipData = num31;
					this.troopMake3Button5.CustomTooltipData = num31;
					this.troopMake3Button20.CustomTooltipData = num31;
				}
				this.troopMake4Button1.invalidate();
				this.troopMake4Button1.Active = false;
				this.troopMake4Button1.Text.Color = Color.FromArgb(151, 134, 108);
				this.troopMake4Button5.Active = false;
				this.troopMake4Button5.Text.Color = Color.FromArgb(151, 134, 108);
				this.troopMake4Button20.Active = false;
				this.troopMake4Button20.Text.Color = Color.FromArgb(151, 134, 108);
				int num32 = this.calcMidSize(num17);
				if (num17 > 0)
				{
					this.troopMake4Button1.Active = true;
					this.troopMake4Button1.Text.Color = global::ARGBColors.Black;
					if (num17 >= num32)
					{
						this.troopMake4Button5.Text.Text = num32.ToString();
						this.troopMake4Button5.Active = true;
						this.troopMake4Button5.Text.Color = global::ARGBColors.Black;
					}
					if (num17 > 1)
					{
						this.troopMake4Button20.Text.Text = num17.ToString();
						this.troopMake4Button20.Active = true;
						this.troopMake4Button20.Text.Color = global::ARGBColors.Black;
					}
				}
				if (this.troopMake4Button1.Active)
				{
					this.troopMake4Button1.CustomTooltipID = 0;
					this.troopMake4Button5.CustomTooltipID = 0;
					this.troopMake4Button20.CustomTooltipID = 0;
				}
				else
				{
					int num33 = 0;
					if (num6 == 0)
					{
						num33 |= 1;
					}
					if (num7 < localWorldData.Barracks_GoldCost_Swordsman)
					{
						num33 |= 2;
					}
					if (num20 >= num22)
					{
						num33 |= 32;
					}
					if (num21 >= GameEngine.Instance.LocalWorldData.Village_UnitCapacity)
					{
						num33 |= 4;
					}
					if (num4 <= 0)
					{
						num33 |= 16;
					}
					this.troopMake4Button1.CustomTooltipID = 2700;
					this.troopMake4Button5.CustomTooltipID = 2700;
					this.troopMake4Button20.CustomTooltipID = 2700;
					this.troopMake4Button1.CustomTooltipData = num33;
					this.troopMake4Button5.CustomTooltipData = num33;
					this.troopMake4Button20.CustomTooltipData = num33;
				}
				this.troopMake5Button1.invalidate();
				this.troopMake5Button1.Active = false;
				this.troopMake5Button1.Text.Color = Color.FromArgb(151, 134, 108);
				this.troopMake5Button5.Active = false;
				this.troopMake5Button5.Text.Color = Color.FromArgb(151, 134, 108);
				this.troopMake5Button20.Active = false;
				this.troopMake5Button20.Text.Color = Color.FromArgb(151, 134, 108);
				int num34 = this.calcMidSize(num18);
				if (num18 > 0)
				{
					this.troopMake5Button1.Active = true;
					this.troopMake5Button1.Text.Color = global::ARGBColors.Black;
					if (num18 >= num34)
					{
						this.troopMake5Button5.Text.Text = num34.ToString();
						this.troopMake5Button5.Active = true;
						this.troopMake5Button5.Text.Color = global::ARGBColors.Black;
					}
					if (num18 > 1)
					{
						this.troopMake5Button20.Text.Text = num18.ToString();
						this.troopMake5Button20.Active = true;
						this.troopMake5Button20.Text.Color = global::ARGBColors.Black;
					}
				}
				if (this.troopMake5Button1.Active)
				{
					this.troopMake5Button1.CustomTooltipID = 0;
					this.troopMake5Button5.CustomTooltipID = 0;
					this.troopMake5Button20.CustomTooltipID = 0;
				}
				else
				{
					int num35 = 0;
					if (num6 == 0)
					{
						num35 |= 1;
					}
					if (num7 < localWorldData.Barracks_GoldCost_Catapult)
					{
						num35 |= 2;
					}
					if (num20 >= num22)
					{
						num35 |= 32;
					}
					if (num21 >= GameEngine.Instance.LocalWorldData.Village_UnitCapacity)
					{
						num35 |= 4;
					}
					if (num5 <= 0)
					{
						num35 |= 16;
					}
					this.troopMake5Button1.CustomTooltipID = 2700;
					this.troopMake5Button5.CustomTooltipID = 2700;
					this.troopMake5Button20.CustomTooltipID = 2700;
					this.troopMake5Button1.CustomTooltipData = num35;
					this.troopMake5Button5.CustomTooltipData = num35;
					this.troopMake5Button20.CustomTooltipData = num35;
				}
				this.troopMake6Button1.invalidate();
				this.troopMake6Button1.Active = false;
				this.troopMake6Button1.Text.Color = Color.FromArgb(151, 134, 108);
				this.troopMake6Button5.Active = false;
				this.troopMake6Button5.Text.Color = Color.FromArgb(151, 134, 108);
				this.troopMake6Button20.Active = false;
				this.troopMake6Button20.Text.Color = Color.FromArgb(151, 134, 108);
				int num36 = this.calcMidSize(num19);
				if (num19 > 0)
				{
					this.troopMake6Button1.Active = true;
					this.troopMake6Button1.Text.Color = global::ARGBColors.Black;
					if (num19 >= num36)
					{
						this.troopMake6Button5.Text.Text = num36.ToString();
						this.troopMake6Button5.Active = true;
						this.troopMake6Button5.Text.Color = global::ARGBColors.Black;
					}
					if (num19 > 1)
					{
						this.troopMake6Button20.Text.Text = num19.ToString();
						this.troopMake6Button20.Active = true;
						this.troopMake6Button20.Text.Color = global::ARGBColors.Black;
					}
				}
				if (this.troopMake6Button1.Active)
				{
					this.troopMake6Button1.CustomTooltipID = 0;
					this.troopMake6Button5.CustomTooltipID = 0;
					this.troopMake6Button20.CustomTooltipID = 0;
				}
				else
				{
					int num37 = 0;
					if (num6 == 0)
					{
						num37 |= 1;
					}
					if (num7 < num13)
					{
						num37 |= 2;
					}
					if (num20 >= num22)
					{
						num37 |= 32;
					}
					if (num21 >= GameEngine.Instance.LocalWorldData.Village_UnitCapacity)
					{
						num37 |= 4;
					}
					if (num24 >= num25)
					{
						num37 |= 8;
					}
					this.troopMake6Button1.CustomTooltipID = 2700;
					this.troopMake6Button5.CustomTooltipID = 2700;
					this.troopMake6Button20.CustomTooltipID = 2700;
					this.troopMake6Button1.CustomTooltipData = num37;
					this.troopMake6Button5.CustomTooltipData = num37;
					this.troopMake6Button20.CustomTooltipData = num37;
				}
				int num38 = 0;
				int num39 = 0;
				int num40 = 0;
				int num41 = 0;
				int num42 = 0;
				int num43 = 0;
				int num44 = 0;
				int num45 = 0;
				int num46 = 0;
				int num47 = 0;
				int num48 = 0;
				int num49 = 0;
				GameEngine.Instance.World.getTotalTroopsOutOfVillage(village.VillageID, ref num38, ref num39, ref num40, ref num41, ref num42, ref num43, ref num44, ref num45, ref num46, ref num47, ref num48, ref num49);
				int num50 = 0;
				int num51 = 0;
				int num52 = 0;
				int num53 = 0;
				int num54 = 0;
				castle.countOwnPlacedTroopTypes(ref num50, ref num51, ref num52, ref num53, ref num54);
				this.inCastlePeasantsLabel.Text = num50.ToString("N", nfi);
				this.inCastleArchersLabel.Text = num51.ToString("N", nfi);
				this.inCastlePikmenLabel.Text = num52.ToString("N", nfi);
				this.inCastleSwordsmenLabel.Text = num53.ToString("N", nfi);
				this.inCastleCaptainsLabel.Text = num54.ToString("N", nfi);
				this.attackingPeasantsLabel.Text = num38.ToString("N", nfi);
				this.attackingArchersLabel.Text = num39.ToString("N", nfi);
				this.attackingPikmenLabel.Text = num40.ToString("N", nfi);
				this.attackingSwordsmenLabel.Text = num41.ToString("N", nfi);
				this.attackingCatapultsLabel.Text = num42.ToString("N", nfi);
				this.attackingCaptainsLabel.Text = num43.ToString("N", nfi);
				this.reinforcingPeasantsLabel.Text = num44.ToString("N", nfi);
				this.reinforcingArchersLabel.Text = num45.ToString("N", nfi);
				this.reinforcingPikmenLabel.Text = num46.ToString("N", nfi);
				this.reinforcingSwordsmenLabel.Text = num47.ToString("N", nfi);
				this.reinforcingCatapultsLabel.Text = num48.ToString("N", nfi);
				this.reinforcingCaptainsLabel.Text = num49.ToString("N", nfi);
				num38 += village.m_numPeasants + locallyMade_Peasants;
				num38 += num50;
				num38 += num44;
				num39 += village.m_numArchers + locallyMade_Archers;
				num39 += num51;
				num39 += num45;
				num40 += village.m_numPikemen + locallyMade_Pikemen;
				num40 += num52;
				num40 += num46;
				num41 += village.m_numSwordsmen + locallyMade_Swordsmen;
				num41 += num53;
				num41 += num47;
				num42 += village.m_numCatapults + locallyMade_Catapults;
				num42 += num48;
				num43 += village.m_numCaptains;
				num43 += num54;
				num43 += num49;
				this.troopsMade1Disband.Text.Text = num38.ToString("N", nfi);
				this.troopsMade2Disband.Text.Text = num39.ToString("N", nfi);
				this.troopsMade3Disband.Text.Text = num40.ToString("N", nfi);
				this.troopsMade4Disband.Text.Text = num41.ToString("N", nfi);
				this.troopsMade5Disband.Text.Text = num42.ToString("N", nfi);
				this.localPeasantsLabel.Text = (village.m_numPeasants + locallyMade_Peasants).ToString("N", nfi);
				this.localArchersLabel.Text = (village.m_numArchers + locallyMade_Archers).ToString("N", nfi);
				this.localPikmenLabel.Text = (village.m_numPikemen + locallyMade_Pikemen).ToString("N", nfi);
				this.localSwordsmenLabel.Text = (village.m_numSwordsmen + locallyMade_Swordsmen).ToString("N", nfi);
				this.localCatapultsLabel.Text = (village.m_numCatapults + locallyMade_Catapults).ToString("N", nfi);
				this.localCaptainsLabel.Text = village.m_numCaptains.ToString("N", nfi);
				this.troopGoldCost1Label.Text = num8.ToString();
				this.troopGoldCost2Label.Text = num9.ToString();
				this.troopGoldCost3Label.Text = num10.ToString();
				this.troopGoldCost4Label.Text = num11.ToString();
				this.troopGoldCost5Label.Text = num12.ToString();
				this.troopGoldCost6Label.Text = num13.ToString();
				if (num7 < num8)
				{
					this.troopGold1Image.Colorise = Color.FromArgb(255, 128, 128);
				}
				else
				{
					this.troopGold1Image.Colorise = global::ARGBColors.White;
				}
				if (num7 < num9)
				{
					this.troopGold2Image.Colorise = Color.FromArgb(255, 128, 128);
				}
				else
				{
					this.troopGold2Image.Colorise = global::ARGBColors.White;
				}
				if (num7 < num10)
				{
					this.troopGold3Image.Colorise = Color.FromArgb(255, 128, 128);
				}
				else
				{
					this.troopGold3Image.Colorise = global::ARGBColors.White;
				}
				if (num7 < num11)
				{
					this.troopGold4Image.Colorise = Color.FromArgb(255, 128, 128);
				}
				else
				{
					this.troopGold4Image.Colorise = global::ARGBColors.White;
				}
				if (num7 < num12)
				{
					this.troopGold5Image.Colorise = Color.FromArgb(255, 128, 128);
				}
				else
				{
					this.troopGold5Image.Colorise = global::ARGBColors.White;
				}
				if (num7 < num13)
				{
					this.troopGold6Image.Colorise = Color.FromArgb(255, 128, 128);
				}
				else
				{
					this.troopGold6Image.Colorise = global::ARGBColors.White;
				}
				if (armouryLevels.bowsLevel == 0.0 && this.mouseOver == 72)
				{
					this.troop2Weapon1Image.Colorise = Color.FromArgb(255, 128, 128);
					this.item2Image.Colorise = Color.FromArgb(255, 128, 128);
				}
				else if (armouryLevels.bowsLevel == 0.0)
				{
					this.troop2Weapon1Image.Colorise = Color.FromArgb(255, 128, 128);
					this.item2Image.Colorise = global::ARGBColors.White;
				}
				else
				{
					this.troop2Weapon1Image.Colorise = global::ARGBColors.White;
					this.item2Image.Colorise = global::ARGBColors.White;
				}
				if (armouryLevels.pikesLevel == 0.0 && this.mouseOver == 73)
				{
					this.troop3Weapon1Image.Colorise = Color.FromArgb(255, 128, 128);
					this.item4Image.Colorise = Color.FromArgb(255, 128, 128);
				}
				else if (armouryLevels.pikesLevel == 0.0)
				{
					this.troop3Weapon1Image.Colorise = Color.FromArgb(255, 128, 128);
					this.item4Image.Colorise = global::ARGBColors.White;
				}
				else
				{
					this.troop3Weapon1Image.Colorise = global::ARGBColors.White;
					this.item4Image.Colorise = global::ARGBColors.White;
				}
				if (armouryLevels.swordsLevel == 0.0 && this.mouseOver == 71)
				{
					this.troop4Weapon1Image.Colorise = Color.FromArgb(255, 128, 128);
					this.item5Image.Colorise = Color.FromArgb(255, 128, 128);
				}
				else if (armouryLevels.swordsLevel == 0.0)
				{
					this.troop4Weapon1Image.Colorise = Color.FromArgb(255, 128, 128);
					this.item5Image.Colorise = global::ARGBColors.White;
				}
				else
				{
					this.troop4Weapon1Image.Colorise = global::ARGBColors.White;
					this.item5Image.Colorise = global::ARGBColors.White;
				}
				if (armouryLevels.armourLevel == 0.0 && (this.mouseOver == 73 || this.mouseOver == 71))
				{
					this.troop3Weapon2Image.Colorise = Color.FromArgb(255, 128, 128);
					this.troop4Weapon2Image.Colorise = Color.FromArgb(255, 128, 128);
					this.item3Image.Colorise = Color.FromArgb(255, 128, 128);
				}
				else if (armouryLevels.armourLevel == 0.0)
				{
					this.troop3Weapon2Image.Colorise = Color.FromArgb(255, 128, 128);
					this.troop4Weapon2Image.Colorise = Color.FromArgb(255, 128, 128);
					this.item3Image.Colorise = global::ARGBColors.White;
				}
				else
				{
					this.troop3Weapon2Image.Colorise = global::ARGBColors.White;
					this.troop4Weapon2Image.Colorise = global::ARGBColors.White;
					this.item3Image.Colorise = global::ARGBColors.White;
				}
				if (armouryLevels.catapultsLevel == 0.0 && this.mouseOver == 74)
				{
					this.troop5Weapon1Image.Colorise = Color.FromArgb(255, 128, 128);
					this.item6Image.Colorise = Color.FromArgb(255, 128, 128);
				}
				else if (armouryLevels.catapultsLevel == 0.0)
				{
					this.troop5Weapon1Image.Colorise = Color.FromArgb(255, 128, 128);
					this.item6Image.Colorise = global::ARGBColors.White;
				}
				else
				{
					this.troop5Weapon1Image.Colorise = global::ARGBColors.White;
					this.item6Image.Colorise = global::ARGBColors.White;
				}
				this.fullBar.MaxValue = (double)GameEngine.Instance.LocalWorldData.Village_UnitCapacity;
				if (num21 < GameEngine.Instance.LocalWorldData.Village_UnitCapacity)
				{
					this.fullBar.Number = (double)num21;
				}
				else
				{
					this.fullBar.Number = (double)GameEngine.Instance.LocalWorldData.Village_UnitCapacity;
				}
				if (this.mouseOver >= 0 && GameEngine.Instance.LocalWorldData.Village_UnitCapacity - num21 <= 0)
				{
					this.SpaceLabel.Color = Color.FromArgb(255, 64, 64);
				}
				else
				{
					this.SpaceLabel.Color = global::ARGBColors.Black;
				}
				this.troop1Image.CustomTooltipID = 602;
				if (flag2)
				{
					this.troop2Image.CustomTooltipID = 603;
					this.troopMake2Button1.Visible = true;
					this.troopMake2Button20.Visible = true;
					this.troopMake2Button5.Visible = true;
					this.troop2Image.Alpha = 1f;
				}
				else
				{
					this.troop2Image.CustomTooltipID = 608;
					this.troopMake2Button1.Visible = false;
					this.troopMake2Button20.Visible = false;
					this.troopMake2Button5.Visible = false;
					this.troop2Image.Alpha = 0.3f;
				}
				if (flag5)
				{
					this.troop5Image.CustomTooltipID = 606;
					this.troopMake5Button1.Visible = true;
					this.troopMake5Button20.Visible = true;
					this.troopMake5Button5.Visible = true;
					this.troop5Image.Alpha = 1f;
				}
				else
				{
					this.troop5Image.CustomTooltipID = 611;
					this.troopMake5Button1.Visible = false;
					this.troopMake5Button20.Visible = false;
					this.troopMake5Button5.Visible = false;
					this.troop5Image.Alpha = 0.3f;
				}
				if (flag4)
				{
					this.troop4Image.CustomTooltipID = 605;
					this.troopMake4Button1.Visible = true;
					this.troopMake4Button20.Visible = true;
					this.troopMake4Button5.Visible = true;
					this.troop4Image.Alpha = 1f;
				}
				else
				{
					this.troop4Image.CustomTooltipID = 610;
					this.troopMake4Button1.Visible = false;
					this.troopMake4Button20.Visible = false;
					this.troopMake4Button5.Visible = false;
					this.troop4Image.Alpha = 0.3f;
				}
				if (flag3)
				{
					this.troop3Image.CustomTooltipID = 604;
					this.troopMake3Button1.Visible = true;
					this.troopMake3Button20.Visible = true;
					this.troopMake3Button5.Visible = true;
					this.troop3Image.Alpha = 1f;
				}
				else
				{
					this.troop3Image.CustomTooltipID = 609;
					this.troopMake3Button1.Visible = false;
					this.troopMake3Button20.Visible = false;
					this.troopMake3Button5.Visible = false;
					this.troop3Image.Alpha = 0.3f;
				}
				if (flag)
				{
					this.troop6Image.CustomTooltipID = 607;
					this.troopMake6Button1.Visible = true;
					this.troopMake6Button20.Visible = true;
					this.troopMake6Button5.Visible = true;
					this.troop6Image.Alpha = 1f;
				}
				else
				{
					this.troop6Image.CustomTooltipID = 612;
					this.troopMake6Button1.Visible = false;
					this.troopMake6Button20.Visible = false;
					this.troopMake6Button5.Visible = false;
					this.troop6Image.Alpha = 0.3f;
				}
			}
			if (GameEngine.Instance.World.WorldEnded)
			{
				this.troopsMade1Disband.Visible = false;
				this.troopsMade2Disband.Visible = false;
				this.troopsMade3Disband.Visible = false;
				this.troopsMade4Disband.Visible = false;
				this.troopsMade5Disband.Visible = false;
				this.troopsMade6Disband.Visible = false;
				this.troopMake1Button1.Visible = false;
				this.troopMake1Button20.Visible = false;
				this.troopMake1Button5.Visible = false;
				this.troopMake2Button1.Visible = false;
				this.troopMake2Button20.Visible = false;
				this.troopMake2Button5.Visible = false;
				this.troopMake3Button1.Visible = false;
				this.troopMake3Button20.Visible = false;
				this.troopMake3Button5.Visible = false;
				this.troopMake4Button1.Visible = false;
				this.troopMake4Button20.Visible = false;
				this.troopMake4Button5.Visible = false;
				this.troopMake5Button1.Visible = false;
				this.troopMake5Button20.Visible = false;
				this.troopMake5Button5.Visible = false;
				this.troopMake6Button1.Visible = false;
				this.troopMake6Button20.Visible = false;
				this.troopMake6Button5.Visible = false;
			}
		}

		// Token: 0x06000680 RID: 1664 RVA: 0x0000B72B File Offset: 0x0000992B
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

		// Token: 0x06000681 RID: 1665 RVA: 0x0008AA20 File Offset: 0x00088C20
		private void makeTroopClick()
		{
			if (this.OverControl != null)
			{
				try
				{
					CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.OverControl;
					if (!csdbutton.Active || !csdbutton.Visible)
					{
						if (csdbutton.Visible)
						{
							GameEngine.Instance.playInterfaceSound("UnitsPanel2_make_failed");
						}
					}
					else
					{
						int num = csdbutton.Data;
						VillageMap village = GameEngine.Instance.Village;
						if (village != null)
						{
							int num2 = 1;
							int num3 = 0;
							int num4 = num % 1000;
							switch (num4)
							{
							case 70:
								num3 = this.makePeasants;
								GameEngine.Instance.playInterfaceSound("BarracksPanel_make_peasants");
								break;
							case 71:
								num3 = this.makeSwordsmen;
								GameEngine.Instance.playInterfaceSound("BarracksPanel_make_swordsmen");
								break;
							case 72:
								num3 = this.makeArchers;
								GameEngine.Instance.playInterfaceSound("BarracksPanel_make_archers");
								break;
							case 73:
								num3 = this.makePikemen;
								GameEngine.Instance.playInterfaceSound("BarracksPanel_make_pikemen");
								break;
							case 74:
								num3 = this.makeCatapults;
								GameEngine.Instance.playInterfaceSound("BarracksPanel_make_catapults");
								break;
							default:
								if (num4 == 100)
								{
									num3 = this.makeCaptains;
									GameEngine.Instance.playInterfaceSound("BarracksPanel_make_captain");
								}
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
									goto IL_17D;
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
					IL_17D:;
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x06000682 RID: 1666 RVA: 0x0008ABCC File Offset: 0x00088DCC
		private void makeTroopOver()
		{
			if (this.OverControl != null)
			{
				CustomSelfDrawPanel.CSDControl overControl = this.OverControl;
				int data = overControl.Data;
				this.mouseOver = data % 1000;
			}
		}

		// Token: 0x06000683 RID: 1667 RVA: 0x0000B740 File Offset: 0x00009940
		private void makeTroopLeave()
		{
			this.mouseOver = -1;
		}

		// Token: 0x06000684 RID: 1668 RVA: 0x0008ABFC File Offset: 0x00088DFC
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

		// Token: 0x06000685 RID: 1669 RVA: 0x0000B749 File Offset: 0x00009949
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

		// Token: 0x06000686 RID: 1670 RVA: 0x0000B772 File Offset: 0x00009972
		private void attackInfoClick()
		{
			InterfaceMgr.Instance.setVillageTabSubMode(7);
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x0000B77F File Offset: 0x0000997F
		private void reinforcementInfoClick()
		{
			InterfaceMgr.Instance.setVillageTabSubMode(6);
		}

		// Token: 0x04000866 RID: 2150
		private DockableControl dockableControl;

		// Token: 0x04000867 RID: 2151
		private IContainer components;

		// Token: 0x04000868 RID: 2152
		public static BarracksPanel instance = null;

		// Token: 0x04000869 RID: 2153
		private static List<WorldMap.VillageNameItem> exchangeHistory = new List<WorldMap.VillageNameItem>();

		// Token: 0x0400086A RID: 2154
		private static List<WorldMap.VillageNameItem> exchangeFavourites = new List<WorldMap.VillageNameItem>();

		// Token: 0x0400086B RID: 2155
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400086C RID: 2156
		private CustomSelfDrawPanel.CSDArea mainBackgroundArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400086D RID: 2157
		private CustomSelfDrawPanel.CSDLabel barracksLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400086E RID: 2158
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400086F RID: 2159
		private CustomSelfDrawPanel.CSDImage troop1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000870 RID: 2160
		private CustomSelfDrawPanel.CSDImage troop2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000871 RID: 2161
		private CustomSelfDrawPanel.CSDImage troop3Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000872 RID: 2162
		private CustomSelfDrawPanel.CSDImage troop4Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000873 RID: 2163
		private CustomSelfDrawPanel.CSDImage troop5Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000874 RID: 2164
		private CustomSelfDrawPanel.CSDImage troop6Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000875 RID: 2165
		private CustomSelfDrawPanel.CSDButton troopsMade1Disband = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000876 RID: 2166
		private CustomSelfDrawPanel.CSDButton troopsMade2Disband = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000877 RID: 2167
		private CustomSelfDrawPanel.CSDButton troopsMade3Disband = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000878 RID: 2168
		private CustomSelfDrawPanel.CSDButton troopsMade4Disband = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000879 RID: 2169
		private CustomSelfDrawPanel.CSDButton troopsMade5Disband = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400087A RID: 2170
		private CustomSelfDrawPanel.CSDButton troopsMade6Disband = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400087B RID: 2171
		private CustomSelfDrawPanel.CSDLabel troopGoldCost1Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400087C RID: 2172
		private CustomSelfDrawPanel.CSDLabel troopGoldCost2Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400087D RID: 2173
		private CustomSelfDrawPanel.CSDLabel troopGoldCost3Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400087E RID: 2174
		private CustomSelfDrawPanel.CSDLabel troopGoldCost4Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400087F RID: 2175
		private CustomSelfDrawPanel.CSDLabel troopGoldCost5Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000880 RID: 2176
		private CustomSelfDrawPanel.CSDLabel troopGoldCost6Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000881 RID: 2177
		private CustomSelfDrawPanel.CSDButton troopMake1Button1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000882 RID: 2178
		private CustomSelfDrawPanel.CSDButton troopMake2Button1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000883 RID: 2179
		private CustomSelfDrawPanel.CSDButton troopMake3Button1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000884 RID: 2180
		private CustomSelfDrawPanel.CSDButton troopMake4Button1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000885 RID: 2181
		private CustomSelfDrawPanel.CSDButton troopMake5Button1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000886 RID: 2182
		private CustomSelfDrawPanel.CSDButton troopMake6Button1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000887 RID: 2183
		private CustomSelfDrawPanel.CSDButton troopMake1Button5 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000888 RID: 2184
		private CustomSelfDrawPanel.CSDButton troopMake2Button5 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000889 RID: 2185
		private CustomSelfDrawPanel.CSDButton troopMake3Button5 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400088A RID: 2186
		private CustomSelfDrawPanel.CSDButton troopMake4Button5 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400088B RID: 2187
		private CustomSelfDrawPanel.CSDButton troopMake5Button5 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400088C RID: 2188
		private CustomSelfDrawPanel.CSDButton troopMake6Button5 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400088D RID: 2189
		private CustomSelfDrawPanel.CSDButton troopMake1Button20 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400088E RID: 2190
		private CustomSelfDrawPanel.CSDButton troopMake2Button20 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400088F RID: 2191
		private CustomSelfDrawPanel.CSDButton troopMake3Button20 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000890 RID: 2192
		private CustomSelfDrawPanel.CSDButton troopMake4Button20 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000891 RID: 2193
		private CustomSelfDrawPanel.CSDButton troopMake5Button20 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000892 RID: 2194
		private CustomSelfDrawPanel.CSDButton troopMake6Button20 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000893 RID: 2195
		private CustomSelfDrawPanel.CSDImage troopGold1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000894 RID: 2196
		private CustomSelfDrawPanel.CSDImage troopGold2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000895 RID: 2197
		private CustomSelfDrawPanel.CSDImage troopGold3Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000896 RID: 2198
		private CustomSelfDrawPanel.CSDImage troopGold4Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000897 RID: 2199
		private CustomSelfDrawPanel.CSDImage troopGold5Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000898 RID: 2200
		private CustomSelfDrawPanel.CSDImage troopGold6Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000899 RID: 2201
		private CustomSelfDrawPanel.CSDImage troop2Weapon1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400089A RID: 2202
		private CustomSelfDrawPanel.CSDImage troop3Weapon1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400089B RID: 2203
		private CustomSelfDrawPanel.CSDImage troop3Weapon2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400089C RID: 2204
		private CustomSelfDrawPanel.CSDImage troop4Weapon1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400089D RID: 2205
		private CustomSelfDrawPanel.CSDImage troop4Weapon2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400089E RID: 2206
		private CustomSelfDrawPanel.CSDImage troop5Weapon1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400089F RID: 2207
		private CustomSelfDrawPanel.CSDLabel troopCtrl1Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008A0 RID: 2208
		private CustomSelfDrawPanel.CSDLabel troopCtrl2Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008A1 RID: 2209
		private CustomSelfDrawPanel.CSDLabel troopCtrl3Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008A2 RID: 2210
		private CustomSelfDrawPanel.CSDLabel troopCtrl4Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008A3 RID: 2211
		private CustomSelfDrawPanel.CSDLabel troopCtrl5Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008A4 RID: 2212
		private CustomSelfDrawPanel.CSDImage item1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040008A5 RID: 2213
		private CustomSelfDrawPanel.CSDImage item2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040008A6 RID: 2214
		private CustomSelfDrawPanel.CSDImage item3Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040008A7 RID: 2215
		private CustomSelfDrawPanel.CSDImage item4Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040008A8 RID: 2216
		private CustomSelfDrawPanel.CSDImage item5Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040008A9 RID: 2217
		private CustomSelfDrawPanel.CSDImage item6Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040008AA RID: 2218
		private CustomSelfDrawPanel.CSDLabel item1AmountLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008AB RID: 2219
		private CustomSelfDrawPanel.CSDLabel item2AmountLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008AC RID: 2220
		private CustomSelfDrawPanel.CSDLabel item3AmountLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008AD RID: 2221
		private CustomSelfDrawPanel.CSDLabel item4AmountLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008AE RID: 2222
		private CustomSelfDrawPanel.CSDLabel item5AmountLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008AF RID: 2223
		private CustomSelfDrawPanel.CSDLabel item6AmountLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008B0 RID: 2224
		private CustomSelfDrawPanel.CSDLabel CurrentTroopsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008B1 RID: 2225
		private CustomSelfDrawPanel.CSDLabel SpaceLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008B2 RID: 2226
		private CustomSelfDrawPanel.CSDLabel MaxLabelLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008B3 RID: 2227
		private CustomSelfDrawPanel.CSDColorBar fullBar = new CustomSelfDrawPanel.CSDColorBar();

		// Token: 0x040008B4 RID: 2228
		private CustomSelfDrawPanel.CSDLabel BottomHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008B5 RID: 2229
		private CustomSelfDrawPanel.CSDLabel LocalLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008B6 RID: 2230
		private CustomSelfDrawPanel.CSDLabel InCastleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008B7 RID: 2231
		private CustomSelfDrawPanel.CSDLabel AttackingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008B8 RID: 2232
		private CustomSelfDrawPanel.CSDLabel ReinforcingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008B9 RID: 2233
		private CustomSelfDrawPanel.CSDImage smallPeasantImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040008BA RID: 2234
		private CustomSelfDrawPanel.CSDLabel localPeasantsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008BB RID: 2235
		private CustomSelfDrawPanel.CSDLabel localArchersLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008BC RID: 2236
		private CustomSelfDrawPanel.CSDLabel localPikmenLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008BD RID: 2237
		private CustomSelfDrawPanel.CSDLabel localSwordsmenLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008BE RID: 2238
		private CustomSelfDrawPanel.CSDLabel localCatapultsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008BF RID: 2239
		private CustomSelfDrawPanel.CSDLabel localCaptainsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008C0 RID: 2240
		private CustomSelfDrawPanel.CSDLabel inCastlePeasantsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008C1 RID: 2241
		private CustomSelfDrawPanel.CSDLabel inCastleArchersLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008C2 RID: 2242
		private CustomSelfDrawPanel.CSDLabel inCastlePikmenLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008C3 RID: 2243
		private CustomSelfDrawPanel.CSDLabel inCastleSwordsmenLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008C4 RID: 2244
		private CustomSelfDrawPanel.CSDLabel inCastleCatapultsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008C5 RID: 2245
		private CustomSelfDrawPanel.CSDLabel inCastleCaptainsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008C6 RID: 2246
		private CustomSelfDrawPanel.CSDLabel attackingPeasantsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008C7 RID: 2247
		private CustomSelfDrawPanel.CSDLabel attackingArchersLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008C8 RID: 2248
		private CustomSelfDrawPanel.CSDLabel attackingPikmenLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008C9 RID: 2249
		private CustomSelfDrawPanel.CSDLabel attackingSwordsmenLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008CA RID: 2250
		private CustomSelfDrawPanel.CSDLabel attackingCatapultsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008CB RID: 2251
		private CustomSelfDrawPanel.CSDLabel attackingCaptainsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008CC RID: 2252
		private CustomSelfDrawPanel.CSDLabel reinforcingPeasantsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008CD RID: 2253
		private CustomSelfDrawPanel.CSDLabel reinforcingArchersLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008CE RID: 2254
		private CustomSelfDrawPanel.CSDLabel reinforcingPikmenLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008CF RID: 2255
		private CustomSelfDrawPanel.CSDLabel reinforcingSwordsmenLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008D0 RID: 2256
		private CustomSelfDrawPanel.CSDLabel reinforcingCatapultsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008D1 RID: 2257
		private CustomSelfDrawPanel.CSDLabel reinforcingCaptainsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040008D2 RID: 2258
		private CustomSelfDrawPanel.CSDButton attackInfoButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040008D3 RID: 2259
		private CustomSelfDrawPanel.CSDButton reinforcementInfoButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040008D4 RID: 2260
		private CardBarGDI cardbar = new CardBarGDI();

		// Token: 0x040008D5 RID: 2261
		private int makePeasants = 10;

		// Token: 0x040008D6 RID: 2262
		private int makeArchers = 10;

		// Token: 0x040008D7 RID: 2263
		private int makePikemen = 10;

		// Token: 0x040008D8 RID: 2264
		private int makeSwordsmen = 10;

		// Token: 0x040008D9 RID: 2265
		private int makeCatapults = 10;

		// Token: 0x040008DA RID: 2266
		private int makeCaptains = 10;

		// Token: 0x040008DB RID: 2267
		private int mouseOver = -1;

		// Token: 0x040008DC RID: 2268
		private DisbandTroopsPopup m_disbandPopup;
	}
}
