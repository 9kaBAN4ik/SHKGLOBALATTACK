using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020001F3 RID: 499
	public class HouseListPanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x060013F7 RID: 5111 RVA: 0x00158338 File Offset: 0x00156538
		public HouseListPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x060013F8 RID: 5112 RVA: 0x001584B0 File Offset: 0x001566B0
		public void init(bool resized)
		{
			int height = base.Height;
			HouseListPanel.instance = this;
			base.clearControls();
			if (GameEngine.Instance.World.testGloryPointsUpdate())
			{
				RemoteServices.Instance.set_GetHouseGloryPoints_UserCallBack(new RemoteServices.GetHouseGloryPoints_UserCallBack(this.GetHouseGloryPointsCallBack));
				RemoteServices.Instance.GetHouseGloryPoints();
			}
			this.sidebar.addSideBar(7, this);
			this.mainBackgroundImage.FillColor = Color.FromArgb(134, 153, 165);
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = new Size(base.Width - 200, height);
			base.addControl(this.mainBackgroundImage);
			this.backgroundFade.Image = GFXLibrary.background_top;
			this.backgroundFade.Position = new Point(0, 0);
			this.backgroundFade.Size = new Size(base.Width - 200, this.backgroundFade.Image.Height);
			this.mainBackgroundImage.addControl(this.backgroundFade);
			this.headerLabelsImage.Size = new Size(base.Width - 25 - 23 - 200, 28);
			this.headerLabelsImage.Position = new Point(25, 39);
			this.mainBackgroundImage.addControl(this.headerLabelsImage);
			this.headerLabelsImage.Create(GFXLibrary.mail2_field_bar_mail_left, GFXLibrary.mail2_field_bar_mail_middle, GFXLibrary.mail2_field_bar_mail_right);
			this.divider1Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
			this.divider1Image.Position = new Point(250, 0);
			this.headerLabelsImage.addControl(this.divider1Image);
			this.divider2Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
			this.divider2Image.Position = new Point(400, 0);
			this.headerLabelsImage.addControl(this.divider2Image);
			this.divider3Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
			this.divider3Image.Position = new Point(560, 0);
			this.headerLabelsImage.addControl(this.divider3Image);
			this.houseLabel.Text = SK.Text("STATS_CATEGORY_TITLE_HOUSE", "House");
			this.houseLabel.Color = global::ARGBColors.Black;
			this.houseLabel.Position = new Point(9, -2);
			this.houseLabel.Size = new Size(323, this.headerLabelsImage.Height);
			this.houseLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.houseLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.houseLabel);
			this.houseSortArea.Position = new Point(0, 0);
			this.houseSortArea.Size = new Size(250, this.headerLabelsImage.Height);
			this.houseSortArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortNameClick), "HouseListPanel_sort_house");
			this.headerLabelsImage.addControl(this.houseSortArea);
			if (this.pageMode == 0)
			{
				this.playersLabel.Text = SK.Text("GENERIC_Factions", "Factions");
			}
			else
			{
				this.playersLabel.Text = SK.Text("FactionInvites_Glory_Rank", "Glory Rank");
			}
			this.playersLabel.Color = global::ARGBColors.Black;
			this.playersLabel.Position = new Point(255, -2);
			this.playersLabel.Size = new Size(130, this.headerLabelsImage.Height);
			this.playersLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.playersLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.headerLabelsImage.addControl(this.playersLabel);
			this.factionsSortArea.Position = new Point(250, 0);
			this.factionsSortArea.Size = new Size(150, this.headerLabelsImage.Height);
			this.factionsSortArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortFactionsClick), "HouseListPanel_sort_faction");
			this.headerLabelsImage.addControl(this.factionsSortArea);
			if (this.pageMode == 0)
			{
				this.pointsLabel.Text = SK.Text("FactionsPanel_Points", "Points");
			}
			else
			{
				this.pointsLabel.Text = SK.Text("FactionInvites_Glory_Points", "Glory Points");
			}
			this.pointsLabel.Color = global::ARGBColors.Black;
			this.pointsLabel.Position = new Point(405, -2);
			this.pointsLabel.Size = new Size(160, this.headerLabelsImage.Height);
			this.pointsLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.pointsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.headerLabelsImage.addControl(this.pointsLabel);
			this.pointsSortArea.Position = new Point(400, 0);
			this.pointsSortArea.Size = new Size(160, this.headerLabelsImage.Height);
			this.pointsSortArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortPointsClick), "HouseListPanel_sort_points");
			this.headerLabelsImage.addControl(this.pointsSortArea);
			this.membershipLabel.Text = SK.Text("FactionInvites_Membership", "Membership");
			this.membershipLabel.Color = global::ARGBColors.Black;
			this.membershipLabel.Position = new Point(565, -2);
			this.membershipLabel.Size = new Size(175, this.headerLabelsImage.Height);
			this.membershipLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.membershipLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.headerLabelsImage.addControl(this.membershipLabel);
			this.factionInfoButton.ImageNorm = GFXLibrary.misc_button_blue_210wide_normal;
			this.factionInfoButton.ImageOver = GFXLibrary.misc_button_blue_210wide_over;
			this.factionInfoButton.ImageClick = GFXLibrary.misc_button_blue_210wide_pushed;
			this.factionInfoButton.Position = new Point(100, 5);
			this.factionInfoButton.Text.Text = SK.Text("HouseInfoPanel_Faction_Info", "Faction Info");
			this.factionInfoButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.factionInfoButton.TextYOffset = -3;
			if (this.pageMode == 0)
			{
				this.factionInfoButton.Text.Color = global::ARGBColors.White;
				this.factionInfoButton.Text.DropShadowColor = global::ARGBColors.Black;
			}
			else
			{
				this.factionInfoButton.Text.Color = global::ARGBColors.Black;
				this.factionInfoButton.Text.clearDropShadow();
			}
			this.factionInfoButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.factionInfoClick), "HouseInfoPanel_leave");
			this.mainBackgroundImage.addControl(this.factionInfoButton);
			this.gloryInfoButton.ImageNorm = GFXLibrary.misc_button_blue_210wide_normal;
			this.gloryInfoButton.ImageOver = GFXLibrary.misc_button_blue_210wide_over;
			this.gloryInfoButton.ImageClick = GFXLibrary.misc_button_blue_210wide_pushed;
			this.gloryInfoButton.Position = new Point(470, 5);
			this.gloryInfoButton.Text.Text = SK.Text("HouseInfoPanel_Glory_Info", "Glory Info");
			this.gloryInfoButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.gloryInfoButton.TextYOffset = -3;
			if (this.pageMode == 1)
			{
				this.gloryInfoButton.Text.Color = global::ARGBColors.White;
				this.gloryInfoButton.Text.DropShadowColor = global::ARGBColors.Black;
			}
			else
			{
				this.gloryInfoButton.Text.Color = global::ARGBColors.Black;
				this.gloryInfoButton.Text.clearDropShadow();
			}
			this.gloryInfoButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.gloryInfoClick), "HouseInfoPanel_leave");
			this.mainBackgroundImage.addControl(this.gloryInfoButton);
			InterfaceMgr.Instance.setVillageHeading(SK.Text("HouseInfo_All_Houses", "All Houses"));
			this.wallScrollArea.Position = new Point(25, 68);
			this.wallScrollArea.Size = new Size(705, height - 38 - 30);
			this.wallScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(705, height - 38 - 30));
			this.mainBackgroundImage.addControl(this.wallScrollArea);
			this.mouseWheelOverlay.Position = this.wallScrollArea.Position;
			this.mouseWheelOverlay.Size = this.wallScrollArea.Size;
			this.mouseWheelOverlay.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mouseWheelMoved));
			this.mainBackgroundImage.addControl(this.mouseWheelOverlay);
			int value = this.wallScrollBar.Value;
			this.wallScrollBar.Visible = false;
			this.wallScrollBar.Position = new Point(733, 68);
			this.wallScrollBar.Size = new Size(24, height - 38 - 30);
			this.mainBackgroundImage.addControl(this.wallScrollBar);
			this.wallScrollBar.Value = 0;
			this.wallScrollBar.Max = 100;
			this.wallScrollBar.NumVisibleLines = 25;
			this.wallScrollBar.Create(null, null, null, GFXLibrary._24wide_thumb_top, GFXLibrary._24wide_thumb_middle, GFXLibrary._24wide_thumb_bottom);
			this.wallScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.wallScrollBarMoved));
			this.addFactions();
		}

		// Token: 0x060013F9 RID: 5113 RVA: 0x000159F8 File Offset: 0x00013BF8
		public void update()
		{
			this.sidebar.update();
		}

		// Token: 0x060013FA RID: 5114 RVA: 0x00015A05 File Offset: 0x00013C05
		public void logout()
		{
			this.sortMethod = -1;
			this.pageMode = 0;
		}

		// Token: 0x060013FB RID: 5115 RVA: 0x00015A15 File Offset: 0x00013C15
		public void GetHouseGloryPointsCallBack(GetHouseGloryPoints_ReturnType returnData)
		{
			if (returnData.Success)
			{
				GameEngine.Instance.World.HouseGloryPoints = returnData.gloryPoints;
				GameEngine.Instance.World.HouseGloryRoundData = returnData.gloryRoundData;
			}
		}

		// Token: 0x060013FC RID: 5116 RVA: 0x00015A49 File Offset: 0x00013C49
		private void factionInfoClick()
		{
			this.pageMode = 0;
			this.init(true);
		}

		// Token: 0x060013FD RID: 5117 RVA: 0x00015A59 File Offset: 0x00013C59
		private void gloryInfoClick()
		{
			this.pageMode = 1;
			this.init(true);
		}

		// Token: 0x060013FE RID: 5118 RVA: 0x00158EAC File Offset: 0x001570AC
		private void wallScrollBarMoved()
		{
			int value = this.wallScrollBar.Value;
			this.wallScrollArea.Position = new Point(this.wallScrollArea.X, 68 - value);
			this.wallScrollArea.ClipRect = new Rectangle(this.wallScrollArea.ClipRect.X, value, this.wallScrollArea.ClipRect.Width, this.wallScrollArea.ClipRect.Height);
			this.wallScrollArea.invalidate();
			this.wallScrollBar.invalidate();
		}

		// Token: 0x060013FF RID: 5119 RVA: 0x00015A69 File Offset: 0x00013C69
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

		// Token: 0x06001400 RID: 5120 RVA: 0x0000ADE9 File Offset: 0x00008FE9
		public void closing()
		{
			InterfaceMgr.Instance.closeDonatePopup();
		}

		// Token: 0x06001401 RID: 5121 RVA: 0x00158F44 File Offset: 0x00157144
		public void addFactions()
		{
			int yourFactionRank = GameEngine.Instance.World.getYourFactionRank();
			FactionData yourFaction = GameEngine.Instance.World.YourFaction;
			int yourHouseID = 0;
			if (yourFaction != null)
			{
				yourHouseID = yourFaction.houseID;
			}
			int appliedToHouse = 0;
			if (GameEngine.Instance.World.HouseVoteInfo != null && GameEngine.Instance.World.HouseVoteInfo.appliedToHouseID > 0)
			{
				appliedToHouse = GameEngine.Instance.World.HouseVoteInfo.appliedToHouseID;
			}
			this.wallScrollArea.clearControls();
			int num = 0;
			this.lineList.Clear();
			int num2 = 0;
			HouseData[] houseInfo = GameEngine.Instance.World.HouseInfo;
			List<HouseData> list = new List<HouseData>();
			HouseData[] array = houseInfo;
			foreach (HouseData item in array)
			{
				list.Add(item);
			}
			switch (this.sortMethod)
			{
			case 0:
				list.Sort(this.namePosComparer);
				break;
			case 1:
				list.Sort(this.nameNegComparer);
				break;
			case 2:
				if (this.pageMode == 0)
				{
					list.Sort(this.playersPosComparer);
				}
				else
				{
					list.Sort(this.gloryPosComparer);
				}
				break;
			case 3:
				if (this.pageMode == 0)
				{
					list.Sort(this.playersNegComparer);
				}
				else
				{
					list.Sort(this.gloryNegComparer);
				}
				break;
			case 4:
				if (this.pageMode == 0)
				{
					list.Sort(this.pointsPosComparer);
				}
				else
				{
					list.Sort(this.gloryPosComparer);
				}
				break;
			case 5:
				if (this.pageMode == 0)
				{
					list.Sort(this.pointsNegComparer);
				}
				else
				{
					list.Sort(this.gloryNegComparer);
				}
				break;
			}
			foreach (HouseData houseData in list)
			{
				HouseListPanel.HouseLine houseLine = new HouseListPanel.HouseLine();
				if (num != 0)
				{
					num += 5;
				}
				houseLine.Position = new Point(0, num);
				houseLine.init(houseData, yourHouseID, yourFactionRank, appliedToHouse, num2, this, this.pageMode == 1);
				this.wallScrollArea.addControl(houseLine);
				num += houseLine.Height;
				this.lineList.Add(houseLine);
				num2++;
			}
			this.wallScrollArea.Size = new Size(this.wallScrollArea.Width, num);
			if (num < this.wallScrollBar.Height)
			{
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

		// Token: 0x06001402 RID: 5122 RVA: 0x00015A9B File Offset: 0x00013C9B
		public void selfJoinHouse(int houseID)
		{
			RemoteServices.Instance.set_SelfJoinHouse_UserCallBack(new RemoteServices.SelfJoinHouse_UserCallBack(this.selfJoinHouseCallback));
			RemoteServices.Instance.SelfJoinHouse(RemoteServices.Instance.UserFactionID, houseID, GameEngine.Instance.World.StoredFactionChangesPos);
		}

		// Token: 0x06001403 RID: 5123 RVA: 0x0015923C File Offset: 0x0015743C
		public void selfJoinHouseCallback(SelfJoinHouse_ReturnType returnData)
		{
			if (!returnData.Success)
			{
				if (returnData.m_errorCode == ErrorCodes.ErrorCode.HOUSE_FULL || returnData.m_errorCode == ErrorCodes.ErrorCode.HOUSE_FACTION_NEEDS_5_MEMBERS)
				{
					if (returnData.m_errorCode == ErrorCodes.ErrorCode.HOUSE_FACTION_NEEDS_5_MEMBERS && GameEngine.Instance.LocalWorldData.Alternate_Ruleset == 1)
					{
						MyMessageBox.Show(SK.Text("ERRORCODE_HOUSE_FACTION_NEEDS_10_MEMBERS", "Your faction needs 10 members to join a house."), SK.Text("FactionsPanel_House_Join_Error", "House Join Error"));
						return;
					}
					MyMessageBox.Show(ErrorCodes.getErrorString(returnData.m_errorCode), SK.Text("FactionsPanel_House_Join_Error", "House Join Error"));
				}
				return;
			}
			if (returnData.factionsList != null)
			{
				GameEngine.Instance.World.processFactionsList(returnData.factionsList, returnData.currentFactionChangePos);
			}
			GameEngine.Instance.World.HouseInfo = returnData.m_houseData;
			GameEngine.Instance.World.YourFaction = returnData.yourFaction;
			GameEngine.Instance.World.HouseVoteInfo = returnData.m_houseVoteData;
			if (returnData.yourFaction != null && returnData.yourFaction.houseID > 0)
			{
				InterfaceMgr.Instance.showHousePanel(returnData.yourFaction.houseID);
				return;
			}
			this.init(false);
		}

		// Token: 0x06001404 RID: 5124 RVA: 0x00015AD7 File Offset: 0x00013CD7
		private void sortNameClick()
		{
			if (this.sortMethod == 0)
			{
				this.sortMethod = 1;
			}
			else
			{
				this.sortMethod = 0;
			}
			this.addFactions();
		}

		// Token: 0x06001405 RID: 5125 RVA: 0x00015AF7 File Offset: 0x00013CF7
		private void sortFactionsClick()
		{
			if (this.sortMethod == 2)
			{
				this.sortMethod = 3;
			}
			else
			{
				this.sortMethod = 2;
			}
			this.addFactions();
		}

		// Token: 0x06001406 RID: 5126 RVA: 0x00015B18 File Offset: 0x00013D18
		private void sortPointsClick()
		{
			if (this.pageMode == 0)
			{
				if (this.sortMethod == 4)
				{
					this.sortMethod = 5;
				}
				else
				{
					this.sortMethod = 4;
				}
				this.addFactions();
				return;
			}
			this.sortFactionsClick();
		}

		// Token: 0x06001407 RID: 5127 RVA: 0x00015B48 File Offset: 0x00013D48
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06001408 RID: 5128 RVA: 0x00015B58 File Offset: 0x00013D58
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06001409 RID: 5129 RVA: 0x00015B68 File Offset: 0x00013D68
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x0600140A RID: 5130 RVA: 0x00015B7A File Offset: 0x00013D7A
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x0600140B RID: 5131 RVA: 0x00015B87 File Offset: 0x00013D87
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closing();
		}

		// Token: 0x0600140C RID: 5132 RVA: 0x00015BA1 File Offset: 0x00013DA1
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x0600140D RID: 5133 RVA: 0x00015BAE File Offset: 0x00013DAE
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x0600140E RID: 5134 RVA: 0x00015BBB File Offset: 0x00013DBB
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600140F RID: 5135 RVA: 0x00159368 File Offset: 0x00157568
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.MaximumSize = new Size(992, 10000);
			this.MinimumSize = new Size(992, 566);
			base.Name = "HouseListPanel";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x040025B1 RID: 9649
		public const int PANEL_ID = 51;

		// Token: 0x040025B2 RID: 9650
		public static HouseListPanel instance;

		// Token: 0x040025B3 RID: 9651
		private CustomSelfDrawPanel.CSDFill mainBackgroundImage = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x040025B4 RID: 9652
		private CustomSelfDrawPanel.CSDImage backgroundFade = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040025B5 RID: 9653
		private CustomSelfDrawPanel.CSDLabel titleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040025B6 RID: 9654
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x040025B7 RID: 9655
		private CustomSelfDrawPanel.CSDImage divider1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040025B8 RID: 9656
		private CustomSelfDrawPanel.CSDImage divider2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040025B9 RID: 9657
		private CustomSelfDrawPanel.CSDImage divider3Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040025BA RID: 9658
		private CustomSelfDrawPanel.CSDLabel houseLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040025BB RID: 9659
		private CustomSelfDrawPanel.CSDLabel playersLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040025BC RID: 9660
		private CustomSelfDrawPanel.CSDLabel pointsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040025BD RID: 9661
		private CustomSelfDrawPanel.CSDLabel membershipLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040025BE RID: 9662
		private CustomSelfDrawPanel.CSDVertScrollBar wallScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x040025BF RID: 9663
		private CustomSelfDrawPanel.CSDArea wallScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040025C0 RID: 9664
		private CustomSelfDrawPanel.CSDControl mouseWheelOverlay = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x040025C1 RID: 9665
		private CustomSelfDrawPanel.CSDArea houseSortArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040025C2 RID: 9666
		private CustomSelfDrawPanel.CSDArea factionsSortArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040025C3 RID: 9667
		private CustomSelfDrawPanel.CSDArea pointsSortArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040025C4 RID: 9668
		private CustomSelfDrawPanel.CSDButton factionInfoButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040025C5 RID: 9669
		private CustomSelfDrawPanel.CSDButton gloryInfoButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040025C6 RID: 9670
		private CustomSelfDrawPanel.FactionPanelSideBar sidebar = new CustomSelfDrawPanel.FactionPanelSideBar();

		// Token: 0x040025C7 RID: 9671
		private int sortMethod = -1;

		// Token: 0x040025C8 RID: 9672
		private int pageMode;

		// Token: 0x040025C9 RID: 9673
		private List<HouseListPanel.HouseLine> lineList = new List<HouseListPanel.HouseLine>();

		// Token: 0x040025CA RID: 9674
		private HouseListPanel.NamePosComparer namePosComparer = new HouseListPanel.NamePosComparer();

		// Token: 0x040025CB RID: 9675
		private HouseListPanel.NameNegComparer nameNegComparer = new HouseListPanel.NameNegComparer();

		// Token: 0x040025CC RID: 9676
		private HouseListPanel.PlayersPosComparer playersPosComparer = new HouseListPanel.PlayersPosComparer();

		// Token: 0x040025CD RID: 9677
		private HouseListPanel.PlayersNegComparer playersNegComparer = new HouseListPanel.PlayersNegComparer();

		// Token: 0x040025CE RID: 9678
		private HouseListPanel.PointsPosComparer pointsPosComparer = new HouseListPanel.PointsPosComparer();

		// Token: 0x040025CF RID: 9679
		private HouseListPanel.PointsNegComparer pointsNegComparer = new HouseListPanel.PointsNegComparer();

		// Token: 0x040025D0 RID: 9680
		private HouseListPanel.GloryPosComparer gloryPosComparer = new HouseListPanel.GloryPosComparer();

		// Token: 0x040025D1 RID: 9681
		private HouseListPanel.GloryNegComparer gloryNegComparer = new HouseListPanel.GloryNegComparer();

		// Token: 0x040025D2 RID: 9682
		private DockableControl dockableControl;

		// Token: 0x040025D3 RID: 9683
		private IContainer components;

		// Token: 0x020001F4 RID: 500
		public class HouseLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06001410 RID: 5136 RVA: 0x001593D4 File Offset: 0x001575D4
			public void init(HouseData houseData, int yourHouseID, int yourRank, int appliedToHouse, int position, HouseListPanel parent, bool gloryMode)
			{
				this.m_parent = parent;
				this.m_position = position;
				this.m_houseData = houseData;
				this.clearControls();
				if ((position & 1) == 0)
				{
					this.backgroundImage.Image = GFXLibrary.lineitem_strip_02_light;
				}
				else
				{
					this.backgroundImage.Image = GFXLibrary.lineitem_strip_02_dark;
				}
				this.backgroundImage.Position = new Point(0, 0);
				this.backgroundImage.Size = new Size(this.backgroundImage.Size.Width, 51);
				base.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
				base.addControl(this.backgroundImage);
				this.Size = this.backgroundImage.Size;
				if (houseData.houseID > 0)
				{
					this.houseImage.Image = GFXLibrary.house_circles_medium[houseData.houseID - 1];
					this.houseImage.Position = new Point(5, 0);
					this.houseImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
					this.houseImage.CustomTooltipID = 2308;
					this.houseImage.CustomTooltipData = houseData.houseID;
					this.backgroundImage.addControl(this.houseImage);
				}
				NumberFormatInfo nfi = GameEngine.NFI;
				Color color = global::ARGBColors.Black;
				if (houseData.houseID == yourHouseID)
				{
					color = global::ARGBColors.Yellow;
				}
				this.houseName.Text = SK.Text("STATS_CATEGORY_TITLE_HOUSE", "House") + " " + houseData.houseID.ToString();
				this.houseName.Color = color;
				this.houseName.Position = new Point(64, 5);
				this.houseName.Size = new Size(280, this.backgroundImage.Height);
				this.houseName.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.houseName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.houseName.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
				this.backgroundImage.addControl(this.houseName);
				this.houseMotto.Text = "\"" + CustomTooltipManager.getHouseMotto(houseData.houseID) + "\"";
				this.houseMotto.Color = color;
				this.houseMotto.Position = new Point(64, 30);
				this.houseMotto.Size = new Size(280, this.backgroundImage.Height);
				this.houseMotto.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.houseMotto.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.houseMotto.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
				this.backgroundImage.addControl(this.houseMotto);
				int num = -1;
				if (!gloryMode)
				{
					if (houseData.houseID == 0)
					{
						this.numPlayersLabel.Text = GameEngine.Instance.World.countHouseFactions(0).ToString("N", nfi);
					}
					else
					{
						this.numPlayersLabel.Text = houseData.numFactions.ToString("N", nfi);
					}
				}
				else
				{
					int gloryRank = GameEngine.Instance.World.getGloryRank(houseData.houseID);
					if (houseData.houseID == 0 || gloryRank < 0)
					{
						this.numPlayersLabel.Text = "";
					}
					else
					{
						this.numPlayersLabel.Text = (gloryRank + 1).ToString("N", nfi);
						num = GameEngine.Instance.World.getGloryPoints(houseData.houseID);
					}
				}
				this.numPlayersLabel.Color = global::ARGBColors.Black;
				this.numPlayersLabel.Position = new Point(235, 0);
				this.numPlayersLabel.Size = new Size(100, this.backgroundImage.Height);
				this.numPlayersLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.numPlayersLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.numPlayersLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
				this.backgroundImage.addControl(this.numPlayersLabel);
				if (!gloryMode)
				{
					this.pointsLabel.Text = houseData.points.ToString("N", nfi);
				}
				else if (num >= 0)
				{
					this.pointsLabel.Text = num.ToString("N", nfi);
				}
				else
				{
					this.pointsLabel.Text = "";
				}
				this.pointsLabel.Color = global::ARGBColors.Black;
				this.pointsLabel.Position = new Point(410, 0);
				this.pointsLabel.Size = new Size(100, this.backgroundImage.Height);
				this.pointsLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.pointsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.pointsLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
				this.backgroundImage.addControl(this.pointsLabel);
				if (houseData.houseID > 0)
				{
					this.membershipLabel.Color = global::ARGBColors.Black;
					this.membershipLabel.Position = new Point(570, 3);
					this.membershipLabel.Size = new Size(130, this.backgroundImage.Height);
					this.membershipLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
					this.membershipLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
					this.membershipLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
					this.backgroundImage.addControl(this.membershipLabel);
					this.joinButton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
					this.joinButton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
					this.joinButton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
					this.joinButton.Position = new Point(567, 24);
					string text = this.joinButton.Text.Text = SK.Text("HouseInfoLine_Join", "Join");
					this.joinButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.joinButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
					this.joinButton.TextYOffset = -3;
					this.joinButton.Text.Color = global::ARGBColors.Black;
					this.joinButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.joinClicked), "HouseListPanel_join");
					this.backgroundImage.addControl(this.joinButton);
					this.joinButton.Visible = false;
					if (yourHouseID == 0 && appliedToHouse > 0)
					{
						if (houseData.houseID == appliedToHouse)
						{
							text = SK.Text("HouseInfoLine_Applied", "Applied");
							this.joinButton.Visible = true;
							this.m_applied = true;
							if (yourRank != 1)
							{
								this.joinButton.Enabled = false;
							}
						}
					}
					else if (houseData.numFactions < GameEngine.Instance.LocalWorldData.Houses_MaxFactions && yourHouseID == 0 && yourRank == 1 && houseData.houseID != 0)
					{
						if (houseData.numFactions >= GameEngine.Instance.LocalWorldData.Houses_SelfJoinLimit)
						{
							text = SK.Text("HouseInfoLine_Apply", "Apply");
							this.joinButton.Visible = true;
						}
						else
						{
							text = SK.Text("HouseInfoLine_Join", "Join");
							this.joinButton.Visible = true;
						}
					}
					if (houseData.houseID == 10 && GameEngine.Instance.LocalWorldData.AIWorld)
					{
						this.membershipLabel.Text = SK.Text("FactionInvites_Membership_closed", "Closed");
						this.joinButton.Visible = false;
					}
					else if (houseData.numFactions < GameEngine.Instance.LocalWorldData.Houses_MaxFactions)
					{
						this.membershipLabel.Text = SK.Text("FactionInvites_Membership_open", "Open");
					}
					else
					{
						this.membershipLabel.Text = SK.Text("FactionInvites_Membership_closed", "Closed");
					}
					this.joinButton.Text.Text = text;
					if (!this.joinButton.Visible)
					{
						this.membershipLabel.Position = new Point(570, 0);
						this.membershipLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					}
				}
				int yourHouseRelation = GameEngine.Instance.World.getYourHouseRelation(houseData.houseID);
				if (yourHouseRelation != 0)
				{
					if (yourHouseRelation > 0)
					{
						this.allianceImage.Image = GFXLibrary.faction_relationships[0];
						this.allianceImage.CustomTooltipID = 2303;
					}
					else
					{
						this.allianceImage.Image = GFXLibrary.faction_relationships[2];
						this.allianceImage.CustomTooltipID = 2304;
					}
					this.allianceImage.Position = new Point(238, 12);
					this.allianceImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
					this.backgroundImage.addControl(this.allianceImage);
				}
				if (GameEngine.Instance.World.WorldEnded)
				{
					this.joinButton.Visible = false;
				}
				base.invalidate();
			}

			// Token: 0x06001411 RID: 5137 RVA: 0x00007CE0 File Offset: 0x00005EE0
			public void update()
			{
			}

			// Token: 0x06001412 RID: 5138 RVA: 0x00015BDA File Offset: 0x00013DDA
			public void clickedLine()
			{
				GameEngine.Instance.playInterfaceSound("HouseListPanel_faction");
				if (this.m_houseData.houseID > 0)
				{
					InterfaceMgr.Instance.showHousePanel(this.m_houseData.houseID);
				}
			}

			// Token: 0x06001413 RID: 5139 RVA: 0x00159CF8 File Offset: 0x00157EF8
			private void joinClicked()
			{
				if (this.m_parent == null)
				{
					return;
				}
				if (!this.m_applied)
				{
					this.m_parent.selfJoinHouse(this.m_houseData.houseID);
					return;
				}
				MessageBoxButtons buts = MessageBoxButtons.YesNo;
				DialogResult dialogResult = MyMessageBox.Show(SK.Text("FORUMS_Are_You_Sure", "Are you sure?"), SK.Text("FactionInvite_Cancel_Application", "Cancel Application"), buts);
				if (dialogResult == DialogResult.Yes)
				{
					this.Join();
				}
			}

			// Token: 0x06001414 RID: 5140 RVA: 0x00015C0E File Offset: 0x00013E0E
			private void Join()
			{
				this.m_parent.selfJoinHouse(-1);
			}

			// Token: 0x040025D4 RID: 9684
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040025D5 RID: 9685
			private CustomSelfDrawPanel.CSDImage houseImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040025D6 RID: 9686
			private CustomSelfDrawPanel.CSDLabel houseName = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040025D7 RID: 9687
			private CustomSelfDrawPanel.CSDLabel houseMotto = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040025D8 RID: 9688
			private CustomSelfDrawPanel.CSDLabel numPlayersLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040025D9 RID: 9689
			private CustomSelfDrawPanel.CSDLabel pointsLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040025DA RID: 9690
			private CustomSelfDrawPanel.CSDLabel membershipLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040025DB RID: 9691
			private CustomSelfDrawPanel.CSDButton joinButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040025DC RID: 9692
			private CustomSelfDrawPanel.CSDImage allianceImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040025DD RID: 9693
			private int m_position = -1000;

			// Token: 0x040025DE RID: 9694
			private bool m_applied;

			// Token: 0x040025DF RID: 9695
			private HouseData m_houseData;

			// Token: 0x040025E0 RID: 9696
			private HouseListPanel m_parent;

			// Token: 0x040025E1 RID: 9697
			private MyMessageBoxPopUp PopUpRef;
		}

		// Token: 0x020001F5 RID: 501
		public class NamePosComparer : IComparer<HouseData>
		{
			// Token: 0x06001416 RID: 5142 RVA: 0x00015C1C File Offset: 0x00013E1C
			public int Compare(HouseData x, HouseData y)
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
					return x.houseID.CompareTo(y.houseID);
				}
			}
		}

		// Token: 0x020001F6 RID: 502
		public class NameNegComparer : IComparer<HouseData>
		{
			// Token: 0x06001418 RID: 5144 RVA: 0x00015C3E File Offset: 0x00013E3E
			public int Compare(HouseData y, HouseData x)
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
					return x.houseID.CompareTo(y.houseID);
				}
			}
		}

		// Token: 0x020001F7 RID: 503
		public class PlayersPosComparer : IComparer<HouseData>
		{
			// Token: 0x0600141A RID: 5146 RVA: 0x00159DE4 File Offset: 0x00157FE4
			public int Compare(HouseData x, HouseData y)
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
					if (x.numFactions > y.numFactions)
					{
						return -1;
					}
					if (x.numFactions < y.numFactions)
					{
						return 1;
					}
					return x.houseID.CompareTo(y.houseID);
				}
			}
		}

		// Token: 0x020001F8 RID: 504
		public class PlayersNegComparer : IComparer<HouseData>
		{
			// Token: 0x0600141C RID: 5148 RVA: 0x00159E34 File Offset: 0x00158034
			public int Compare(HouseData y, HouseData x)
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
					if (x.numFactions > y.numFactions)
					{
						return -1;
					}
					if (x.numFactions < y.numFactions)
					{
						return 1;
					}
					return x.houseID.CompareTo(y.houseID);
				}
			}
		}

		// Token: 0x020001F9 RID: 505
		public class PointsPosComparer : IComparer<HouseData>
		{
			// Token: 0x0600141E RID: 5150 RVA: 0x00159E84 File Offset: 0x00158084
			public int Compare(HouseData x, HouseData y)
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
					if (x.points > y.points)
					{
						return -1;
					}
					if (x.points < y.points)
					{
						return 1;
					}
					return x.houseID.CompareTo(y.houseID);
				}
			}
		}

		// Token: 0x020001FA RID: 506
		public class PointsNegComparer : IComparer<HouseData>
		{
			// Token: 0x06001420 RID: 5152 RVA: 0x00159ED4 File Offset: 0x001580D4
			public int Compare(HouseData y, HouseData x)
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
					if (x.points > y.points)
					{
						return -1;
					}
					if (x.points < y.points)
					{
						return 1;
					}
					return x.houseID.CompareTo(y.houseID);
				}
			}
		}

		// Token: 0x020001FB RID: 507
		public class GloryPosComparer : IComparer<HouseData>
		{
			// Token: 0x06001422 RID: 5154 RVA: 0x00159F24 File Offset: 0x00158124
			public int Compare(HouseData x, HouseData y)
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
					if (x.loser != y.loser)
					{
						if (x.loser)
						{
							return 1;
						}
						return -1;
					}
					else
					{
						if (x.loser)
						{
							return x.houseID.CompareTo(y.houseID);
						}
						int num = GameEngine.Instance.World.getGloryPoints(x.houseID);
						int num2 = GameEngine.Instance.World.getGloryPoints(y.houseID);
						if (x.houseID == 0)
						{
							num = -1;
						}
						if (y.houseID == 0)
						{
							num2 = -1;
						}
						if (num > num2)
						{
							return -1;
						}
						if (num < num2)
						{
							return 1;
						}
						return x.houseID.CompareTo(y.houseID);
					}
				}
			}
		}

		// Token: 0x020001FC RID: 508
		public class GloryNegComparer : IComparer<HouseData>
		{
			// Token: 0x06001424 RID: 5156 RVA: 0x00159FD4 File Offset: 0x001581D4
			public int Compare(HouseData y, HouseData x)
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
					if (x.loser != y.loser)
					{
						if (x.loser)
						{
							return 1;
						}
						return -1;
					}
					else
					{
						if (x.loser)
						{
							return x.houseID.CompareTo(y.houseID);
						}
						int num = GameEngine.Instance.World.getGloryPoints(x.houseID);
						int num2 = GameEngine.Instance.World.getGloryPoints(y.houseID);
						if (x.houseID == 0)
						{
							num = -1;
						}
						if (y.houseID == 0)
						{
							num2 = -1;
						}
						if (num > num2)
						{
							return -1;
						}
						if (num < num2)
						{
							return 1;
						}
						return x.houseID.CompareTo(y.houseID);
					}
				}
			}
		}
	}
}
