using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020001BF RID: 447
	public class FactionMyFactionPanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x1700010D RID: 269
		// (get) Token: 0x060010D5 RID: 4309 RVA: 0x00012717 File Offset: 0x00010917
		// (set) Token: 0x060010D6 RID: 4310 RVA: 0x0001271E File Offset: 0x0001091E
		public static int SelectedFaction
		{
			get
			{
				return FactionMyFactionPanel.m_selectedFaction;
			}
			set
			{
				FactionMyFactionPanel.m_selectedFaction = value;
			}
		}

		// Token: 0x060010D7 RID: 4311 RVA: 0x00012726 File Offset: 0x00010926
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x060010D8 RID: 4312 RVA: 0x00012736 File Offset: 0x00010936
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x060010D9 RID: 4313 RVA: 0x00012746 File Offset: 0x00010946
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x060010DA RID: 4314 RVA: 0x00012758 File Offset: 0x00010958
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x060010DB RID: 4315 RVA: 0x00012765 File Offset: 0x00010965
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closing();
		}

		// Token: 0x060010DC RID: 4316 RVA: 0x0001277F File Offset: 0x0001097F
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x060010DD RID: 4317 RVA: 0x0001278C File Offset: 0x0001098C
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x060010DE RID: 4318 RVA: 0x00012799 File Offset: 0x00010999
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060010DF RID: 4319 RVA: 0x0011EFD0 File Offset: 0x0011D1D0
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.MaximumSize = new Size(992, 10000);
			this.MinimumSize = new Size(992, 566);
			base.Name = "FactionMyFactionPanel";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x060010E0 RID: 4320 RVA: 0x0011F03C File Offset: 0x0011D23C
		public FactionMyFactionPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x060010E1 RID: 4321 RVA: 0x0011F274 File Offset: 0x0011D474
		public void init(bool resized)
		{
			int height = base.Height;
			FactionMyFactionPanel.instance = this;
			base.clearControls();
			NumberFormatInfo nfi = GameEngine.NFI;
			this.sidebar.addSideBar(1, this);
			FactionData factionData = GameEngine.Instance.World.getFaction(FactionMyFactionPanel.m_selectedFaction);
			if (factionData == null)
			{
				factionData = new FactionData();
			}
			this.greyOverlay.Size = base.Size;
			this.mainBackgroundImage.FillColor = Color.FromArgb(134, 153, 165);
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = new Size(base.Width - 200, height);
			base.addControl(this.mainBackgroundImage);
			this.backgroundFade.Image = GFXLibrary.background_top;
			this.backgroundFade.Position = new Point(0, 0);
			this.backgroundFade.Size = new Size(base.Width - 200, this.backgroundFade.Image.Height);
			this.mainBackgroundImage.addControl(this.backgroundFade);
			this.backImage1.Image = GFXLibrary.faction_tanback;
			this.backImage1.Position = new Point(this.mainBackgroundImage.Size.Width - this.backImage1.Size.Width - 25, 12);
			this.mainBackgroundImage.addControl(this.backImage1);
			this.backImage2.Image = GFXLibrary.faction_title_band;
			this.backImage2.Position = new Point(20, 20);
			this.mainBackgroundImage.addControl(this.backImage2);
			this.barImage1.Image = GFXLibrary.faction_bar_tan_1_heavier;
			this.barImage1.Position = new Point(276, 70);
			this.mainBackgroundImage.addControl(this.barImage1);
			this.barImage2.Image = GFXLibrary.faction_bar_tan_1_lighter;
			this.barImage2.Position = new Point(276, 94);
			this.mainBackgroundImage.addControl(this.barImage2);
			this.barImage3.Image = GFXLibrary.faction_bar_tan_1_heavier;
			this.barImage3.Position = new Point(276, 118);
			this.mainBackgroundImage.addControl(this.barImage3);
			this.factionNameLabel.Text = factionData.factionName;
			this.factionNameLabel.Color = global::ARGBColors.Black;
			this.factionNameLabel.Position = new Point(205, 10);
			this.factionNameLabel.Size = new Size(600, 40);
			this.factionNameLabel.Font = FontManager.GetFont("Arial", 20f, FontStyle.Regular);
			this.factionNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainBackgroundImage.addControl(this.factionNameLabel);
			this.factionMottoLabel.Text = "\"" + factionData.factionMotto + "\"";
			this.factionMottoLabel.Color = global::ARGBColors.Black;
			this.factionMottoLabel.Position = new Point(205, 41);
			this.factionMottoLabel.Size = new Size(600, 40);
			this.factionMottoLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.factionMottoLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainBackgroundImage.addControl(this.factionMottoLabel);
			if (factionData.houseID > 0)
			{
				this.houseLabel.Text = SK.Text("STATS_CATEGORY_TITLE_HOUSE", "House") + " " + factionData.houseID.ToString();
				this.houseLabel.Color = global::ARGBColors.Black;
				this.houseLabel.Position = new Point(575, 110);
				this.houseLabel.Size = new Size(200, 50);
				this.houseLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.houseLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.houseLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.houseClicked), "FactionMyFactionPanel_house");
				this.mainBackgroundImage.addControl(this.houseLabel);
				this.houseImage.Image = GFXLibrary.house_circles_large[factionData.houseID - 1];
				this.houseImage.Position = new Point(675 - this.houseImage.Image.Width / 2, 65 - this.houseImage.Image.Height / 2 + 8);
				this.houseImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.houseClicked), "FactionMyFactionPanel_house");
				this.mainBackgroundImage.addControl(this.houseImage);
			}
			this.membersLabel.Text = SK.Text("FactionInvites_Members", "Members");
			this.membersLabel.Color = global::ARGBColors.Black;
			this.membersLabel.Position = new Point(284, 73);
			this.membersLabel.Size = new Size(600, 40);
			this.membersLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.membersLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainBackgroundImage.addControl(this.membersLabel);
			this.membersLabelValue.Text = factionData.numMembers.ToString();
			this.membersLabelValue.Color = global::ARGBColors.Black;
			this.membersLabelValue.Position = new Point(30, 73);
			this.membersLabelValue.Size = new Size(482, 40);
			this.membersLabelValue.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.membersLabelValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.mainBackgroundImage.addControl(this.membersLabelValue);
			this.rankHeaderLabel.Text = SK.Text("STATS_CATEGORY_TITLE_RANK", "Rank");
			this.rankHeaderLabel.Color = global::ARGBColors.Black;
			this.rankHeaderLabel.Position = new Point(284, 121);
			this.rankHeaderLabel.Size = new Size(600, 40);
			this.rankHeaderLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.rankHeaderLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainBackgroundImage.addControl(this.rankHeaderLabel);
			this.rankHeaderLabelValue.Text = (GameEngine.Instance.World.getFactionRank(FactionMyFactionPanel.m_selectedFaction) + 1).ToString("N", nfi);
			this.rankHeaderLabelValue.Color = global::ARGBColors.Black;
			this.rankHeaderLabelValue.Position = new Point(30, 121);
			this.rankHeaderLabelValue.Size = new Size(482, 40);
			this.rankHeaderLabelValue.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.rankHeaderLabelValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.mainBackgroundImage.addControl(this.rankHeaderLabelValue);
			this.pointsHeaderLabel.Text = SK.Text("FactionsPanel_Points", "Points");
			this.pointsHeaderLabel.Color = global::ARGBColors.Black;
			this.pointsHeaderLabel.Position = new Point(284, 97);
			this.pointsHeaderLabel.Size = new Size(600, 40);
			this.pointsHeaderLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.pointsHeaderLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainBackgroundImage.addControl(this.pointsHeaderLabel);
			this.pointsHeaderLabelValue.Text = factionData.points.ToString("N", nfi);
			this.pointsHeaderLabelValue.Color = global::ARGBColors.Black;
			this.pointsHeaderLabelValue.Position = new Point(30, 97);
			this.pointsHeaderLabelValue.Size = new Size(482, 40);
			this.pointsHeaderLabelValue.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.pointsHeaderLabelValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.mainBackgroundImage.addControl(this.pointsHeaderLabelValue);
			this.headerLabelsImage.Size = new Size(base.Width - 25 - 23 - 200, 28);
			this.headerLabelsImage.Position = new Point(25, 159);
			this.mainBackgroundImage.addControl(this.headerLabelsImage);
			this.headerLabelsImage.Create(GFXLibrary.mail2_field_bar_mail_left, GFXLibrary.mail2_field_bar_mail_middle, GFXLibrary.mail2_field_bar_mail_right);
			this.divider1Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
			this.divider1Image.Position = new Point(290, 0);
			this.headerLabelsImage.addControl(this.divider1Image);
			this.divider2Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
			this.divider2Image.Position = new Point(440, 0);
			this.headerLabelsImage.addControl(this.divider2Image);
			this.divider3Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
			this.divider3Image.Position = new Point(610, 0);
			this.headerLabelsImage.addControl(this.divider3Image);
			this.playerNameLabel.Text = SK.Text("UserInfoPanel_", "Player Name");
			this.playerNameLabel.Color = global::ARGBColors.Black;
			this.playerNameLabel.Position = new Point(9, -2);
			this.playerNameLabel.Size = new Size(323, this.headerLabelsImage.Height);
			this.playerNameLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.playerNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.playerNameLabel);
			this.pointsLabel.Text = SK.Text("FactionsPanel_Points", "Points");
			this.pointsLabel.Color = global::ARGBColors.Black;
			this.pointsLabel.Position = new Point(295, -2);
			this.pointsLabel.Size = new Size(140, this.headerLabelsImage.Height);
			this.pointsLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.pointsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.headerLabelsImage.addControl(this.pointsLabel);
			this.rankLabel.Text = SK.Text("STATS_CATEGORY_TITLE_RANK", "Rank");
			this.rankLabel.Color = global::ARGBColors.Black;
			this.rankLabel.Position = new Point(445, -2);
			this.rankLabel.Size = new Size(223, this.headerLabelsImage.Height);
			this.rankLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.rankLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.rankLabel);
			this.villagesLabel.Text = SK.Text("UserInfoPanel_Villages", "Villages");
			this.villagesLabel.Color = global::ARGBColors.Black;
			this.villagesLabel.Position = new Point(615, -2);
			this.villagesLabel.Size = new Size(110, this.headerLabelsImage.Height);
			this.villagesLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.villagesLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.headerLabelsImage.addControl(this.villagesLabel);
			this.flagimage.createFromFlagData(factionData.flagData);
			this.flagimage.Position = new Point(35, 6);
			this.flagimage.Scale = 0.5;
			this.mainBackgroundImage.addControl(this.flagimage);
			if (factionData.factionID == RemoteServices.Instance.UserFactionID)
			{
				InterfaceMgr.Instance.setVillageHeading(SK.Text("FactionInvites_My_Faction_Details", "My Faction Details"));
			}
			else
			{
				InterfaceMgr.Instance.setVillageHeading(SK.Text("FactionInvites_Faction_Details", "Faction Details"));
			}
			if (RemoteServices.Instance.UserFactionID < 0 && GameEngine.Instance.World.alreadyGotFactionApplication(factionData.factionID))
			{
				this.diplomacyLabel.Text = SK.Text("FactionInvites_Application Pending", "Application Pending");
				this.diplomacyLabel.Color = global::ARGBColors.Black;
				this.diplomacyLabel.Position = new Point(24, 126);
				this.diplomacyLabel.Size = new Size(240, 40);
				this.diplomacyLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.diplomacyLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.mainBackgroundImage.addControl(this.diplomacyLabel);
			}
			else if (RemoteServices.Instance.UserFactionID < 0 && factionData.openForApplications && !GameEngine.Instance.World.alreadyGotFactionApplication(factionData.factionID) && !GameEngine.Instance.World.WorldEnded)
			{
				if (GameEngine.Instance.World.getRank() >= 6)
				{
					this.diplomacyButton.ImageNorm = GFXLibrary.misc_button_blue_210wide_normal;
					this.diplomacyButton.ImageOver = GFXLibrary.misc_button_blue_210wide_over;
					this.diplomacyButton.ImageClick = GFXLibrary.misc_button_blue_210wide_pushed;
					this.diplomacyButton.Position = new Point(24, 126);
					this.diplomacyButton.Text.Text = SK.Text("FactionInvites_Apply", "Apply To Join");
					this.diplomacyButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.diplomacyButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
					this.diplomacyButton.TextYOffset = -3;
					this.diplomacyButton.Text.Color = global::ARGBColors.Black;
					this.diplomacyButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.applyClicked), "FactionMyFactionPanel_diplomacy");
					this.mainBackgroundImage.addControl(this.diplomacyButton);
				}
			}
			else if (factionData.factionID != RemoteServices.Instance.UserFactionID && !GameEngine.Instance.World.WorldEnded)
			{
				if (GameEngine.Instance.World.getYourFactionRank() == 1)
				{
					this.diplomacyButton.ImageNorm = GFXLibrary.misc_button_blue_210wide_normal;
					this.diplomacyButton.ImageOver = GFXLibrary.misc_button_blue_210wide_over;
					this.diplomacyButton.ImageClick = GFXLibrary.misc_button_blue_210wide_pushed;
					this.diplomacyButton.Position = new Point(24, 126);
					this.diplomacyButton.Text.Text = "";
					this.diplomacyButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.diplomacyButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
					this.diplomacyButton.TextYOffset = -3;
					this.diplomacyButton.Text.Color = global::ARGBColors.Black;
					this.diplomacyButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.diplomacyClicked), "FactionMyFactionPanel_diplomacy");
					this.mainBackgroundImage.addControl(this.diplomacyButton);
				}
				else
				{
					this.diplomacyLabel.Text = "";
					this.diplomacyLabel.Color = global::ARGBColors.Black;
					this.diplomacyLabel.Position = new Point(24, 126);
					this.diplomacyLabel.Size = new Size(240, 40);
					this.diplomacyLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
					this.diplomacyLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
					this.mainBackgroundImage.addControl(this.diplomacyLabel);
				}
			}
			this.wallScrollArea.Position = new Point(25, 188);
			this.wallScrollArea.Size = new Size(705, height - 38 - 150);
			this.wallScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(705, height - 38 - 150));
			this.mainBackgroundImage.addControl(this.wallScrollArea);
			this.mouseWheelOverlay.Position = this.wallScrollArea.Position;
			this.mouseWheelOverlay.Size = this.wallScrollArea.Size;
			this.mouseWheelOverlay.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mouseWheelMoved));
			this.mainBackgroundImage.addControl(this.mouseWheelOverlay);
			int value = this.wallScrollBar.Value;
			this.wallScrollBar.Position = new Point(733, 188);
			this.wallScrollBar.Size = new Size(24, height - 38 - 150);
			this.mainBackgroundImage.addControl(this.wallScrollBar);
			this.wallScrollBar.Value = 0;
			this.wallScrollBar.Max = 100;
			this.wallScrollBar.NumVisibleLines = 25;
			this.wallScrollBar.Create(null, null, null, GFXLibrary._24wide_thumb_top, GFXLibrary._24wide_thumb_middle, GFXLibrary._24wide_thumb_bottom);
			this.wallScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.wallScrollBarMoved));
			bool flag = false;
			FactionMemberData[] array = GameEngine.Instance.World.getFactionMemberData(FactionMyFactionPanel.m_selectedFaction, ref flag);
			if (!resized)
			{
				array = this.addAIWorldFactionMemberData(array, factionData.factionID, ref flag);
				if (!flag)
				{
					RemoteServices.Instance.set_GetViewFactionData_UserCallBack(new RemoteServices.GetViewFactionData_UserCallBack(this.getViewFactionDataCallback));
					RemoteServices.Instance.GetViewFactionData(FactionMyFactionPanel.m_selectedFaction);
				}
				this.diplomacyOverlayVisible = false;
			}
			this.addPlayers(array);
			if (resized && this.diplomacyOverlayVisible)
			{
				this.addDiplomacyOverlay();
			}
		}

		// Token: 0x060010E2 RID: 4322 RVA: 0x00120498 File Offset: 0x0011E698
		private FactionMemberData[] addAIWorldFactionMemberData(FactionMemberData[] memberData, int factionID, ref bool uptodate)
		{
			if (GameEngine.Instance.LocalWorldData.AIWorld && factionID >= 1 && factionID <= 4)
			{
				if (factionID == 4 && memberData == null)
				{
					return null;
				}
				List<FactionMemberData> list = new List<FactionMemberData>();
				FactionMemberData factionMemberData = new FactionMemberData();
				switch (factionID)
				{
				case 1:
					factionMemberData.userID = 1;
					factionMemberData.userName = "The Rat";
					factionMemberData.status = 1;
					factionMemberData.numVillages = GameEngine.Instance.World.countRatsCastles();
					break;
				case 2:
					factionMemberData.userID = 2;
					factionMemberData.userName = "The Snake";
					factionMemberData.status = 1;
					factionMemberData.numVillages = GameEngine.Instance.World.countSnakesCastles();
					break;
				case 3:
					factionMemberData.userID = 3;
					factionMemberData.userName = "The Pig";
					factionMemberData.status = 1;
					factionMemberData.numVillages = GameEngine.Instance.World.countPigsCastles();
					break;
				case 4:
					factionMemberData.userID = 4;
					factionMemberData.userName = "The Wolf";
					factionMemberData.status = 1;
					factionMemberData.numVillages = GameEngine.Instance.World.countWolfsCastles();
					break;
				}
				list.Add(factionMemberData);
				if (GameEngine.Instance.LocalWorldData.IsHereticEUAIWorld && factionID == 4)
				{
					FactionMemberData[] array = memberData;
					foreach (FactionMemberData factionMemberData2 in array)
					{
						if (factionMemberData2.userID > 4)
						{
							list.Add(factionMemberData2);
						}
					}
				}
				else
				{
					uptodate = true;
				}
				memberData = list.ToArray();
			}
			return memberData;
		}

		// Token: 0x060010E3 RID: 4323 RVA: 0x000127B8 File Offset: 0x000109B8
		public void update()
		{
			this.sidebar.update();
		}

		// Token: 0x060010E4 RID: 4324 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void logout()
		{
		}

		// Token: 0x060010E5 RID: 4325 RVA: 0x00120614 File Offset: 0x0011E814
		public void updateRelationshipText()
		{
			if (RemoteServices.Instance.UserFactionID >= 0 && FactionMyFactionPanel.m_selectedFaction != RemoteServices.Instance.UserFactionID)
			{
				string text = SK.Text("AllArmiesPanel_Diplomacy", "Diplomacy") + " : ";
				this.diplomacyButton.Visible = true;
				this.diplomacyLabel.Visible = true;
				int num = 0;
				if (FactionMyFactionPanel.m_selectedFaction >= 0)
				{
					num = GameEngine.Instance.World.getYourFactionRelation(FactionMyFactionPanel.m_selectedFaction);
				}
				if (num == 0)
				{
					text += SK.Text("GENERIC_Neutral", "Neutral");
				}
				else if (num > 0)
				{
					text += SK.Text("GENERIC_Ally", "Ally");
				}
				else if (num < 0)
				{
					text += SK.Text("GENERIC_Enemy", "Enemy");
				}
				this.diplomacyLabel.Text = text;
				this.diplomacyButton.Text.Text = text;
				return;
			}
			FactionData faction = GameEngine.Instance.World.getFaction(FactionMyFactionPanel.m_selectedFaction);
			if (RemoteServices.Instance.UserFactionID < 0 && faction != null && GameEngine.Instance.World.alreadyGotFactionApplication(faction.factionID))
			{
				this.diplomacyButton.Visible = false;
				this.diplomacyLabel.Visible = true;
				return;
			}
			if (RemoteServices.Instance.UserFactionID < 0 && faction != null && faction.openForApplications && !GameEngine.Instance.World.alreadyGotFactionApplication(faction.factionID))
			{
				if (GameEngine.Instance.World.getRank() >= 6)
				{
					this.diplomacyButton.Visible = true;
				}
				else
				{
					this.diplomacyButton.Visible = false;
				}
				this.diplomacyLabel.Visible = false;
				return;
			}
			this.diplomacyButton.Visible = false;
			this.diplomacyLabel.Visible = false;
		}

		// Token: 0x060010E6 RID: 4326 RVA: 0x001207D8 File Offset: 0x0011E9D8
		public void houseClicked()
		{
			FactionData faction = GameEngine.Instance.World.getFaction(FactionMyFactionPanel.m_selectedFaction);
			if (faction != null && faction.houseID > 0)
			{
				InterfaceMgr.Instance.showHousePanel(faction.houseID);
			}
		}

		// Token: 0x060010E7 RID: 4327 RVA: 0x00120818 File Offset: 0x0011EA18
		private void getViewFactionDataCallback(GetViewFactionData_ReturnType returnData)
		{
			if (!returnData.Success)
			{
				return;
			}
			NumberFormatInfo nfi = GameEngine.NFI;
			if (returnData.factionData != null)
			{
				bool flag = true;
				FactionMemberData[] array = this.addAIWorldFactionMemberData(returnData.members, returnData.factionData.factionID, ref flag);
				this.addPlayers(array);
				if (GameEngine.Instance.LocalWorldData.IsHereticEUAIWorld && returnData.factionData.factionID == 4)
				{
					returnData.factionData.numMembers = array.Length;
					returnData.factionData.flagData = 941809835;
					returnData.factionData.houseRank = 10;
				}
				GameEngine.Instance.World.setFactionMemberData(returnData.factionData.factionID, returnData.members);
				GameEngine.Instance.World.setFactionData(returnData.factionData);
			}
			GameEngine.Instance.World.FactionAllies = returnData.yourAllies;
			GameEngine.Instance.World.FactionEnemies = returnData.yourEnemies;
		}

		// Token: 0x060010E8 RID: 4328 RVA: 0x0012090C File Offset: 0x0011EB0C
		private void wallScrollBarMoved()
		{
			int value = this.wallScrollBar.Value;
			this.wallScrollArea.Position = new Point(this.wallScrollArea.X, 188 - value);
			this.wallScrollArea.ClipRect = new Rectangle(this.wallScrollArea.ClipRect.X, value, this.wallScrollArea.ClipRect.Width, this.wallScrollArea.ClipRect.Height);
			this.wallScrollArea.invalidate();
			this.wallScrollBar.invalidate();
		}

		// Token: 0x060010E9 RID: 4329 RVA: 0x000127C5 File Offset: 0x000109C5
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

		// Token: 0x060010EA RID: 4330 RVA: 0x0000ADE9 File Offset: 0x00008FE9
		public void closing()
		{
			InterfaceMgr.Instance.closeDonatePopup();
		}

		// Token: 0x060010EB RID: 4331 RVA: 0x001209A8 File Offset: 0x0011EBA8
		public void addPlayers(FactionMemberData[] fmd)
		{
			this.wallScrollArea.clearControls();
			int num = 0;
			this.lineList.Clear();
			int num2 = 0;
			if (fmd != null)
			{
				if (FactionMyFactionPanel.m_selectedFaction != RemoteServices.Instance.UserFactionID)
				{
					for (int i = 0; i < 3; i++)
					{
						int num3 = 1;
						if (i != 1)
						{
							if (i == 2)
							{
								num3 = 0;
							}
						}
						else
						{
							num3 = 2;
						}
						foreach (FactionMemberData factionMemberData in fmd)
						{
							if (factionMemberData.status == num3)
							{
								FactionMyFactionPanel.FactionMemberLine factionMemberLine = new FactionMyFactionPanel.FactionMemberLine();
								if (num != 0)
								{
									num += 5;
								}
								factionMemberLine.Position = new Point(0, num);
								factionMemberLine.init(factionMemberData, num2, this, false);
								this.wallScrollArea.addControl(factionMemberLine);
								num += factionMemberLine.Height;
								this.lineList.Add(factionMemberLine);
								num2++;
							}
						}
					}
				}
				else
				{
					for (int k = 0; k < 3; k++)
					{
						int num4 = 1;
						switch (k)
						{
						case 1:
							num4 = 2;
							break;
						case 2:
							num4 = 0;
							break;
						case 3:
							num4 = -1;
							break;
						}
						foreach (FactionMemberData factionMemberData2 in fmd)
						{
							if (factionMemberData2.status == num4)
							{
								FactionMyFactionPanel.FactionMemberLine factionMemberLine2 = new FactionMyFactionPanel.FactionMemberLine();
								if (num != 0)
								{
									num += 5;
								}
								factionMemberLine2.Position = new Point(0, num);
								factionMemberLine2.init(factionMemberData2, num2, this, true);
								this.wallScrollArea.addControl(factionMemberLine2);
								num += factionMemberLine2.Height;
								this.lineList.Add(factionMemberLine2);
								num2++;
							}
						}
					}
				}
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
			this.updateRelationshipText();
			this.update();
			base.Invalidate();
		}

		// Token: 0x060010EC RID: 4332 RVA: 0x000127F7 File Offset: 0x000109F7
		public void applyClicked()
		{
			this.diplomacyButton.Enabled = false;
			GameEngine.Instance.factionManager.ApplyToFaction(FactionMyFactionPanel.SelectedFaction, new FactionManager.FactionInfoUpdatedCallback(this.factionApplicationCallback));
		}

		// Token: 0x060010ED RID: 4333 RVA: 0x00120BD8 File Offset: 0x0011EDD8
		public void factionApplicationCallback(bool success)
		{
			this.diplomacyButton.Enabled = true;
			if (success)
			{
				this.diplomacyButton.Visible = false;
				this.diplomacyLabel.Text = SK.Text("FactionInvites_Application Pending", "Application Pending");
				this.diplomacyLabel.Color = global::ARGBColors.Black;
				this.diplomacyLabel.Position = new Point(24, 126);
				this.diplomacyLabel.Size = new Size(240, 40);
				this.diplomacyLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.diplomacyLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.mainBackgroundImage.addControl(this.diplomacyLabel);
				this.diplomacyLabel.Visible = true;
				MyMessageBox.Show(SK.Text("FactionInvites_Have_Applied", "You have now applied to join a faction.  Click on the Invites tab to view your current applications."), SK.Text("FactionInvites_Faction_Application", "Faction Application"));
			}
		}

		// Token: 0x060010EE RID: 4334 RVA: 0x00012825 File Offset: 0x00010A25
		private void diplomacyClicked()
		{
			this.addDiplomacyOverlay();
		}

		// Token: 0x060010EF RID: 4335 RVA: 0x00120CC0 File Offset: 0x0011EEC0
		public void addDiplomacyOverlay()
		{
			FactionData faction = GameEngine.Instance.World.getFaction(FactionMyFactionPanel.m_selectedFaction);
			if (faction != null)
			{
				this.removeOverlay();
				this.diplomacyOverlayVisible = true;
				this.greyOverlay.Size = base.Size;
				this.greyOverlay.FillColor = Color.FromArgb(128, 0, 0, 0);
				this.greyOverlay.setClickDelegate(delegate()
				{
				});
				this.mainBackgroundImage.addControl(this.greyOverlay);
				this.diplomacyHeaderImage.Size = new Size(400, 40);
				this.diplomacyHeaderImage.Position = new Point((base.Width - 200 - 400) / 2, 100);
				this.greyOverlay.addControl(this.diplomacyHeaderImage);
				this.diplomacyHeaderImage.Create(GFXLibrary.mail2_titlebar_left, GFXLibrary.mail2_titlebar_middle, GFXLibrary.mail2_titlebar_right);
				this.diplomacyBackgroundImage.Size = new Size(400, 300);
				this.diplomacyBackgroundImage.Position = new Point((base.Width - 200 - 400) / 2, 140);
				this.greyOverlay.addControl(this.diplomacyBackgroundImage);
				this.diplomacyBackgroundImage.Create(GFXLibrary.mail2_mail_panel_upper_left, GFXLibrary.mail2_mail_panel_upper_middle, GFXLibrary.mail2_mail_panel_upper_right, GFXLibrary.mail2_mail_panel_middle_left, GFXLibrary.mail2_mail_panel_middle_middle, GFXLibrary.mail2_mail_panel_middle_right, GFXLibrary.mail2_mail_panel_lower_left, GFXLibrary.mail2_mail_panel_lower_middle, GFXLibrary.mail2_mail_panel_lower_right);
				this.diplomacyHeadingLabel.Text = SK.Text("AllArmiesPanel_Diplomacy", "Diplomacy");
				this.diplomacyHeadingLabel.Color = global::ARGBColors.White;
				this.diplomacyHeadingLabel.Position = new Point(0, 0);
				this.diplomacyHeadingLabel.Size = this.diplomacyHeaderImage.Size;
				this.diplomacyHeadingLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
				this.diplomacyHeadingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.diplomacyHeaderImage.addControl(this.diplomacyHeadingLabel);
				this.diplomacyFactionLabel.Text = faction.factionName;
				this.diplomacyFactionLabel.Color = global::ARGBColors.Black;
				this.diplomacyFactionLabel.Position = new Point(0, 8);
				this.diplomacyFactionLabel.Size = new Size(this.diplomacyBackgroundImage.Width, 30);
				this.diplomacyFactionLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.diplomacyFactionLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.diplomacyBackgroundImage.addControl(this.diplomacyFactionLabel);
				this.diplomacyCurrentLabelHeader.Text = SK.Text("GENERIC_Current_Relationship", "Current Relationship");
				this.diplomacyCurrentLabelHeader.Color = global::ARGBColors.Black;
				this.diplomacyCurrentLabelHeader.Position = new Point(0, 40);
				this.diplomacyCurrentLabelHeader.Size = new Size(this.diplomacyBackgroundImage.Width, 30);
				this.diplomacyCurrentLabelHeader.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.diplomacyCurrentLabelHeader.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.diplomacyBackgroundImage.addControl(this.diplomacyCurrentLabelHeader);
				string text = "";
				int yourFactionRelation = GameEngine.Instance.World.getYourFactionRelation(FactionMyFactionPanel.m_selectedFaction);
				if (yourFactionRelation == 0)
				{
					text += SK.Text("GENERIC_Neutral", "Neutral");
				}
				else if (yourFactionRelation > 0)
				{
					text += SK.Text("GENERIC_Ally", "Ally");
				}
				else if (yourFactionRelation < 0)
				{
					text += SK.Text("GENERIC_Enemy", "Enemy");
				}
				this.diplomacyCurrentLabel.Text = text;
				this.diplomacyCurrentLabel.Color = global::ARGBColors.Black;
				this.diplomacyCurrentLabel.Position = new Point(0, 65);
				this.diplomacyCurrentLabel.Size = new Size(this.diplomacyBackgroundImage.Width, 30);
				this.diplomacyCurrentLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				this.diplomacyCurrentLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.diplomacyBackgroundImage.addControl(this.diplomacyCurrentLabel);
				this.diplomacyNeutralButton.ImageNorm = GFXLibrary.misc_button_blue_210wide_normal;
				this.diplomacyNeutralButton.ImageOver = GFXLibrary.misc_button_blue_210wide_over;
				this.diplomacyNeutralButton.ImageClick = GFXLibrary.misc_button_blue_210wide_pushed;
				this.diplomacyNeutralButton.Position = new Point(95, 100);
				this.diplomacyNeutralButton.Text.Text = SK.Text("FactionsDiplomacy_Set_as_neutral", "Set As Neutral");
				this.diplomacyNeutralButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.diplomacyNeutralButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.diplomacyNeutralButton.TextYOffset = -3;
				this.diplomacyNeutralButton.Text.Color = global::ARGBColors.Black;
				this.diplomacyNeutralButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnBreakAlliance_Click), "FactionMyFactionPanel_neutral_clicked");
				this.diplomacyBackgroundImage.addControl(this.diplomacyNeutralButton);
				this.diplomacyAllyButton.ImageNorm = GFXLibrary.misc_button_blue_210wide_normal;
				this.diplomacyAllyButton.ImageOver = GFXLibrary.misc_button_blue_210wide_over;
				this.diplomacyAllyButton.ImageClick = GFXLibrary.misc_button_blue_210wide_pushed;
				this.diplomacyAllyButton.Position = new Point(95, 150);
				this.diplomacyAllyButton.Text.Text = SK.Text("FactionsDiplomacy_Set_as_ally", "Set As Ally");
				this.diplomacyAllyButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.diplomacyAllyButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.diplomacyAllyButton.TextYOffset = -3;
				this.diplomacyAllyButton.Text.Color = global::ARGBColors.Black;
				this.diplomacyAllyButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnAlly_Click), "FactionMyFactionPanel_ally_clicked");
				this.diplomacyBackgroundImage.addControl(this.diplomacyAllyButton);
				this.diplomacyEnemyButton.ImageNorm = GFXLibrary.misc_button_blue_210wide_normal;
				this.diplomacyEnemyButton.ImageOver = GFXLibrary.misc_button_blue_210wide_over;
				this.diplomacyEnemyButton.ImageClick = GFXLibrary.misc_button_blue_210wide_pushed;
				this.diplomacyEnemyButton.Position = new Point(95, 200);
				this.diplomacyEnemyButton.Text.Text = SK.Text("FactionsDiplomacy_Set_as_enemy", "Set As Enemy");
				this.diplomacyEnemyButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.diplomacyEnemyButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.diplomacyEnemyButton.TextYOffset = -3;
				this.diplomacyEnemyButton.Text.Color = global::ARGBColors.Black;
				this.diplomacyEnemyButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnMakeEnemy_Click), "FactionMyFactionPanel_enemy_clicked");
				this.diplomacyBackgroundImage.addControl(this.diplomacyEnemyButton);
				this.diplomacyCancelButton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
				this.diplomacyCancelButton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
				this.diplomacyCancelButton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
				this.diplomacyCancelButton.Position = new Point(130, 250);
				this.diplomacyCancelButton.Text.Text = SK.Text("GENERIC_Cancel", "Cancel");
				this.diplomacyCancelButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.diplomacyCancelButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.diplomacyCancelButton.TextYOffset = -3;
				this.diplomacyCancelButton.Text.Color = global::ARGBColors.Black;
				this.diplomacyCancelButton.setClickDelegate(delegate()
				{
					this.removeOverlay();
				}, "FactionMyFactionPanel_dipomacy_close");
				this.diplomacyBackgroundImage.addControl(this.diplomacyCancelButton);
				this.diplomacyEnemyButton.Enabled = true;
				this.diplomacyAllyButton.Enabled = true;
				this.diplomacyNeutralButton.Enabled = true;
			}
		}

		// Token: 0x060010F0 RID: 4336 RVA: 0x0001282D File Offset: 0x00010A2D
		public void removeOverlay()
		{
			this.mainBackgroundImage.removeControl(this.greyOverlay);
			this.greyOverlay.clearControls();
			base.Invalidate();
			this.diplomacyOverlayVisible = false;
		}

		// Token: 0x060010F1 RID: 4337 RVA: 0x00121518 File Offset: 0x0011F718
		private void btnAlly_Click()
		{
			this.diplomacyEnemyButton.Enabled = false;
			this.diplomacyAllyButton.Enabled = false;
			this.diplomacyNeutralButton.Enabled = false;
			RemoteServices.Instance.set_CreateFactionRelationship_UserCallBack(new RemoteServices.CreateFactionRelationship_UserCallBack(this.createFactionRelationshipCallback));
			RemoteServices.Instance.CreateFactionRelationship(FactionMyFactionPanel.m_selectedFaction, 1);
		}

		// Token: 0x060010F2 RID: 4338 RVA: 0x00121570 File Offset: 0x0011F770
		private void btnMakeEnemy_Click()
		{
			this.diplomacyEnemyButton.Enabled = false;
			this.diplomacyAllyButton.Enabled = false;
			this.diplomacyNeutralButton.Enabled = false;
			RemoteServices.Instance.set_CreateFactionRelationship_UserCallBack(new RemoteServices.CreateFactionRelationship_UserCallBack(this.createFactionRelationshipCallback));
			RemoteServices.Instance.CreateFactionRelationship(FactionMyFactionPanel.m_selectedFaction, -1);
		}

		// Token: 0x060010F3 RID: 4339 RVA: 0x001215C8 File Offset: 0x0011F7C8
		private void btnBreakAlliance_Click()
		{
			this.diplomacyEnemyButton.Enabled = false;
			this.diplomacyAllyButton.Enabled = false;
			this.diplomacyNeutralButton.Enabled = false;
			RemoteServices.Instance.set_CreateFactionRelationship_UserCallBack(new RemoteServices.CreateFactionRelationship_UserCallBack(this.createFactionRelationshipCallback));
			RemoteServices.Instance.CreateFactionRelationship(FactionMyFactionPanel.m_selectedFaction, 0);
		}

		// Token: 0x060010F4 RID: 4340 RVA: 0x00121620 File Offset: 0x0011F820
		private void createFactionRelationshipCallback(CreateFactionRelationship_ReturnType returnData)
		{
			if (returnData.Success)
			{
				GameEngine.Instance.World.FactionAllies = returnData.yourAllies;
				GameEngine.Instance.World.FactionEnemies = returnData.yourEnemies;
				this.diplomacyOverlayVisible = false;
				this.init(false);
				return;
			}
			this.diplomacyEnemyButton.Enabled = true;
			this.diplomacyAllyButton.Enabled = true;
			this.diplomacyNeutralButton.Enabled = true;
		}

		// Token: 0x040016D2 RID: 5842
		public const int PANEL_ID = 42;

		// Token: 0x040016D3 RID: 5843
		private DockableControl dockableControl;

		// Token: 0x040016D4 RID: 5844
		private IContainer components;

		// Token: 0x040016D5 RID: 5845
		public static FactionMyFactionPanel instance = null;

		// Token: 0x040016D6 RID: 5846
		private static int m_selectedFaction = -1;

		// Token: 0x040016D7 RID: 5847
		private CustomSelfDrawPanel.CSDExtendingPanel backgroundImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x040016D8 RID: 5848
		private CustomSelfDrawPanel.CSDFill mainBackgroundImage = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x040016D9 RID: 5849
		private CustomSelfDrawPanel.CSDImage backgroundFade = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040016DA RID: 5850
		private CustomSelfDrawPanel.CSDLabel titleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040016DB RID: 5851
		private CustomSelfDrawPanel.CSDExtendingPanel wallInfoImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x040016DC RID: 5852
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x040016DD RID: 5853
		private CustomSelfDrawPanel.CSDImage divider1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040016DE RID: 5854
		private CustomSelfDrawPanel.CSDImage divider2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040016DF RID: 5855
		private CustomSelfDrawPanel.CSDImage divider3Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040016E0 RID: 5856
		private CustomSelfDrawPanel.CSDLabel playerNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040016E1 RID: 5857
		private CustomSelfDrawPanel.CSDLabel pointsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040016E2 RID: 5858
		private CustomSelfDrawPanel.CSDLabel rankLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040016E3 RID: 5859
		private CustomSelfDrawPanel.CSDLabel villagesLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040016E4 RID: 5860
		private CustomSelfDrawPanel.CSDLabel factionNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040016E5 RID: 5861
		private CustomSelfDrawPanel.CSDLabel factionMottoLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040016E6 RID: 5862
		private CustomSelfDrawPanel.CSDLabel houseLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040016E7 RID: 5863
		private CustomSelfDrawPanel.CSDImage houseImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040016E8 RID: 5864
		private CustomSelfDrawPanel.CSDLabel membersLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040016E9 RID: 5865
		private CustomSelfDrawPanel.CSDLabel membersLabelValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040016EA RID: 5866
		private CustomSelfDrawPanel.CSDLabel pointsHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040016EB RID: 5867
		private CustomSelfDrawPanel.CSDLabel pointsHeaderLabelValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040016EC RID: 5868
		private CustomSelfDrawPanel.CSDLabel rankHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040016ED RID: 5869
		private CustomSelfDrawPanel.CSDLabel rankHeaderLabelValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040016EE RID: 5870
		private CustomSelfDrawPanel.CSDFactionFlagImage flagimage = new CustomSelfDrawPanel.CSDFactionFlagImage();

		// Token: 0x040016EF RID: 5871
		private CustomSelfDrawPanel.CSDLabel diplomacyLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040016F0 RID: 5872
		private CustomSelfDrawPanel.CSDButton diplomacyButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040016F1 RID: 5873
		private CustomSelfDrawPanel.CSDVertScrollBar wallScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x040016F2 RID: 5874
		private CustomSelfDrawPanel.CSDArea wallScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040016F3 RID: 5875
		private CustomSelfDrawPanel.CSDControl mouseWheelOverlay = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x040016F4 RID: 5876
		private CustomSelfDrawPanel.CSDImage backImage1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040016F5 RID: 5877
		private CustomSelfDrawPanel.CSDImage backImage2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040016F6 RID: 5878
		private CustomSelfDrawPanel.CSDImage barImage1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040016F7 RID: 5879
		private CustomSelfDrawPanel.CSDImage barImage2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040016F8 RID: 5880
		private CustomSelfDrawPanel.CSDImage barImage3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040016F9 RID: 5881
		private CustomSelfDrawPanel.FactionPanelSideBar sidebar = new CustomSelfDrawPanel.FactionPanelSideBar();

		// Token: 0x040016FA RID: 5882
		private List<FactionMyFactionPanel.FactionMemberLine> lineList = new List<FactionMyFactionPanel.FactionMemberLine>();

		// Token: 0x040016FB RID: 5883
		private CustomSelfDrawPanel.CSDFill greyOverlay = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x040016FC RID: 5884
		private CustomSelfDrawPanel.CSDHorzExtendingPanel diplomacyHeaderImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x040016FD RID: 5885
		private CustomSelfDrawPanel.CSDExtendingPanel diplomacyBackgroundImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x040016FE RID: 5886
		private CustomSelfDrawPanel.CSDButton diplomacyNeutralButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040016FF RID: 5887
		private CustomSelfDrawPanel.CSDButton diplomacyAllyButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001700 RID: 5888
		private CustomSelfDrawPanel.CSDButton diplomacyEnemyButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001701 RID: 5889
		private CustomSelfDrawPanel.CSDButton diplomacyCancelButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001702 RID: 5890
		private CustomSelfDrawPanel.CSDLabel diplomacyHeadingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001703 RID: 5891
		private CustomSelfDrawPanel.CSDLabel diplomacyFactionLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001704 RID: 5892
		private CustomSelfDrawPanel.CSDLabel diplomacyCurrentLabelHeader = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001705 RID: 5893
		private CustomSelfDrawPanel.CSDLabel diplomacyCurrentLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001706 RID: 5894
		private bool diplomacyOverlayVisible;

		// Token: 0x04001707 RID: 5895
		[CompilerGenerated]
		private static CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate _003C_003E9__CachedAnonymousMethodDelegate2;

		// Token: 0x020001C0 RID: 448
		public class FactionMemberLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x060010F7 RID: 4343 RVA: 0x00121694 File Offset: 0x0011F894
			public void init(FactionMemberData factionData, int position, FactionMyFactionPanel parent, bool ownFaction)
			{
				this.m_parent = parent;
				this.m_position = position;
				this.m_factionMemberData = factionData;
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
				base.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
				base.addControl(this.backgroundImage);
				this.Size = this.backgroundImage.Size;
				NumberFormatInfo nfi = GameEngine.NFI;
				if (factionData.status == 1 || factionData.status == 2)
				{
					if (factionData.status == 1)
					{
						this.officerImage.Image = GFXLibrary.faction_leaders[1];
						this.officerImage.CustomTooltipID = 2305;
					}
					else
					{
						this.officerImage.Image = GFXLibrary.faction_leaders[0];
						this.officerImage.CustomTooltipID = 2306;
					}
					this.officerImage.Position = new Point(9, 2);
					this.officerImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
					this.backgroundImage.addControl(this.officerImage);
				}
				this.playerName.Text = factionData.userName;
				if (factionData.status != -1)
				{
					this.playerName.Color = global::ARGBColors.Black;
				}
				else
				{
					this.playerName.Color = global::ARGBColors.DarkRed;
				}
				this.playerName.Position = new Point(69, 0);
				this.playerName.Size = new Size(250, this.backgroundImage.Height);
				this.playerName.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.playerName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.playerName.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
				this.backgroundImage.addControl(this.playerName);
				if (factionData.status != -1)
				{
					this.pointsLabel.Text = factionData.totalPoints.ToString("N", nfi);
					this.pointsLabel.Color = global::ARGBColors.Black;
					this.pointsLabel.Position = new Point(300, 0);
					this.pointsLabel.Size = new Size(85, this.backgroundImage.Height);
					this.pointsLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
					this.pointsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
					this.pointsLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
					this.backgroundImage.addControl(this.pointsLabel);
					this.rankName.Text = Rankings.getRankingName(factionData.rank, factionData.male);
					this.rankName.Color = global::ARGBColors.Black;
					this.rankName.Position = new Point(450, 0);
					this.rankName.Size = new Size(150, this.backgroundImage.Height);
					this.rankName.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
					this.rankName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
					this.rankName.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
					this.backgroundImage.addControl(this.rankName);
					this.villageLabel.Text = factionData.numVillages.ToString("N", nfi);
					this.villageLabel.Color = global::ARGBColors.Black;
					this.villageLabel.Position = new Point(620, 0);
					this.villageLabel.Size = new Size(55, this.backgroundImage.Height);
					this.villageLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
					this.villageLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
					this.villageLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
					this.backgroundImage.addControl(this.villageLabel);
					if (factionData.online)
					{
						this.onlineImage.Image = GFXLibrary.radio_green[0];
						this.onlineImage.Position = new Point(280, 5);
						this.backgroundImage.addControl(this.onlineImage);
					}
				}
				else
				{
					this.pointsLabel.Text = SK.Text("FactionsInvites_Invite_Pending", "Invitation Pending");
					this.pointsLabel.Color = global::ARGBColors.DarkRed;
					this.pointsLabel.Position = new Point(300, 0);
					this.pointsLabel.Size = new Size(500, this.backgroundImage.Height);
					this.pointsLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
					this.pointsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
					this.pointsLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
					this.backgroundImage.addControl(this.pointsLabel);
					int yourFactionRank = GameEngine.Instance.World.getYourFactionRank();
					if (yourFactionRank == 1 || yourFactionRank == 2)
					{
						this.declineButton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
						this.declineButton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
						this.declineButton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
						this.declineButton.Position = new Point(560, 0);
						this.declineButton.Text.Text = SK.Text("FactionMemberLine_Cancel_Invite", "Cancel Invite");
						this.declineButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
						this.declineButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
						this.declineButton.TextYOffset = -3;
						this.declineButton.Text.Color = global::ARGBColors.Black;
						this.declineButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.declineClicked), "FactionMyFactionPanel_declined_clicked");
						this.backgroundImage.addControl(this.declineButton);
					}
				}
				this.shieldImage.Image = GameEngine.Instance.World.getWorldShield(factionData.userID, 25, 28);
				if (this.shieldImage.Image != null)
				{
					this.shieldImage.Position = new Point(39, 1);
					this.shieldImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
					this.shieldImage.setRightClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
					this.backgroundImage.addControl(this.shieldImage);
				}
				base.invalidate();
			}

			// Token: 0x060010F8 RID: 4344 RVA: 0x00007CE0 File Offset: 0x00005EE0
			public void update()
			{
			}

			// Token: 0x060010F9 RID: 4345 RVA: 0x00121D4C File Offset: 0x0011FF4C
			public void clickedLine()
			{
				if (this.m_factionMemberData.userID >= 0)
				{
					GameEngine.Instance.playInterfaceSound("FactionMyFactionPanel_user_clicked");
					WorldMap.CachedUserInfo cachedUserInfo = new WorldMap.CachedUserInfo();
					cachedUserInfo.userID = this.m_factionMemberData.userID;
					InterfaceMgr.Instance.showUserInfoScreen(cachedUserInfo);
				}
			}

			// Token: 0x060010FA RID: 4346 RVA: 0x0001286E File Offset: 0x00010A6E
			public void declineClicked()
			{
				this.declineButton.Enabled = false;
				RemoteServices.Instance.set_FactionWithdrawInvite_UserCallBack(new RemoteServices.FactionWithdrawInvite_UserCallBack(this.factionWithdrawInviteCallback));
				RemoteServices.Instance.FactionWithdrawInvite(this.m_factionMemberData.userID);
			}

			// Token: 0x060010FB RID: 4347 RVA: 0x000128A7 File Offset: 0x00010AA7
			public void factionWithdrawInviteCallback(FactionWithdrawInvite_ReturnType returnData)
			{
				this.declineButton.Enabled = true;
				if (returnData.members != null)
				{
					GameEngine.Instance.World.FactionMembers = returnData.members;
					this.m_parent.init(false);
				}
			}

			// Token: 0x04001708 RID: 5896
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001709 RID: 5897
			private CustomSelfDrawPanel.CSDLabel playerName = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400170A RID: 5898
			private CustomSelfDrawPanel.CSDImage officerImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x0400170B RID: 5899
			private CustomSelfDrawPanel.CSDImage shieldImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x0400170C RID: 5900
			private CustomSelfDrawPanel.CSDLabel pointsLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400170D RID: 5901
			private CustomSelfDrawPanel.CSDLabel rankName = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400170E RID: 5902
			private CustomSelfDrawPanel.CSDLabel villageLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400170F RID: 5903
			private CustomSelfDrawPanel.CSDButton declineButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x04001710 RID: 5904
			private CustomSelfDrawPanel.CSDImage onlineImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001711 RID: 5905
			private int m_position = -1000;

			// Token: 0x04001712 RID: 5906
			private FactionMemberData m_factionMemberData;

			// Token: 0x04001713 RID: 5907
			private FactionMyFactionPanel m_parent;
		}
	}
}
