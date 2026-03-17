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
	// Token: 0x020001F0 RID: 496
	public class HouseInfoPanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x060013C5 RID: 5061 RVA: 0x00154C34 File Offset: 0x00152E34
		public HouseInfoPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x060013C6 RID: 5062 RVA: 0x00154EF8 File Offset: 0x001530F8
		public void init(bool resized)
		{
			int height = base.Height;
			NumberFormatInfo nfi = GameEngine.NFI;
			HouseInfoPanel.instance = this;
			this.inHouseVote = false;
			base.clearControls();
			GameEngine.Instance.houseManager.UpdateGloryPoints(new HouseManager.HouseInfoUpdatedCallback(this.Refresh));
			this.sidebar.addSideBar(8, this);
			HouseData houseData = null;
			try
			{
				houseData = GameEngine.Instance.World.HouseInfo[HouseInfoPanel.SelectedHouse];
				this.m_houseLeaderFactionID = houseData.leadingFactionID;
			}
			catch (Exception)
			{
				houseData = new HouseData();
				this.m_houseLeaderFactionID = -1;
			}
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
			this.barImage1.Position = new Point(201, 70);
			this.mainBackgroundImage.addControl(this.barImage1);
			this.barImage2.Image = GFXLibrary.faction_bar_tan_1_lighter;
			this.barImage2.Position = new Point(201, 94);
			this.mainBackgroundImage.addControl(this.barImage2);
			this.barImage3.Image = GFXLibrary.faction_bar_tan_1_heavier;
			this.barImage3.Position = new Point(201, 118);
			this.mainBackgroundImage.addControl(this.barImage3);
			this.barImage4.Image = GFXLibrary.faction_bar_tan_2_heavier;
			this.barImage4.Position = new Point(460, 70);
			this.mainBackgroundImage.addControl(this.barImage4);
			this.barImage5.Image = GFXLibrary.faction_bar_tan_2_lighter;
			this.barImage5.Position = new Point(460, 94);
			this.mainBackgroundImage.addControl(this.barImage5);
			this.barImage6.Image = GFXLibrary.faction_bar_tan_2_heavier;
			this.barImage6.Position = new Point(460, 118);
			this.mainBackgroundImage.addControl(this.barImage6);
			this.houseNameLabel.Text = SK.Text("STATS_CATEGORY_TITLE_HOUSE", "House") + " " + HouseInfoPanel.SelectedHouse.ToString();
			this.houseNameLabel.Color = global::ARGBColors.Black;
			this.houseNameLabel.Position = new Point(205, 10);
			this.houseNameLabel.Size = new Size(600, 40);
			this.houseNameLabel.Font = FontManager.GetFont("Arial", 20f, FontStyle.Regular);
			this.houseNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainBackgroundImage.addControl(this.houseNameLabel);
			this.houseMottoLabel.Text = "\"" + CustomTooltipManager.getHouseMotto(HouseInfoPanel.SelectedHouse) + "\"";
			this.houseMottoLabel.Color = global::ARGBColors.Black;
			this.houseMottoLabel.Position = new Point(205, 41);
			this.houseMottoLabel.Size = new Size(600, 40);
			this.houseMottoLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.houseMottoLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainBackgroundImage.addControl(this.houseMottoLabel);
			this.houseImage.Image = GFXLibrary.house_circles_large[HouseInfoPanel.SelectedHouse - 1];
			this.houseImage.Position = new Point(32, 24);
			this.mainBackgroundImage.addControl(this.houseImage);
			this.data1Label.Text = SK.Text("GENERIC_Factions", "Factions");
			this.data1Label.Color = global::ARGBColors.Black;
			this.data1Label.Position = new Point(210, 73);
			this.data1Label.Size = new Size(600, 40);
			this.data1Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.data1Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainBackgroundImage.addControl(this.data1Label);
			if (HouseInfoPanel.SelectedHouse == 0)
			{
				this.data1LabelValue.Text = GameEngine.Instance.World.countHouseFactions(HouseInfoPanel.SelectedHouse).ToString("N", nfi);
			}
			else
			{
				this.data1LabelValue.Text = houseData.numFactions.ToString("N", nfi);
			}
			this.data1LabelValue.Color = global::ARGBColors.Black;
			this.data1LabelValue.Position = new Point(200, 73);
			this.data1LabelValue.Size = new Size(230, 40);
			this.data1LabelValue.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.data1LabelValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.mainBackgroundImage.addControl(this.data1LabelValue);
			this.data2Label.Text = SK.Text("FactionInvites_Total_Points", "Total Points");
			this.data2Label.Color = global::ARGBColors.Black;
			this.data2Label.Position = new Point(210, 97);
			this.data2Label.Size = new Size(600, 40);
			this.data2Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.data2Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainBackgroundImage.addControl(this.data2Label);
			this.data2LabelValue.Text = houseData.points.ToString("N", nfi);
			this.data2LabelValue.Color = global::ARGBColors.Black;
			this.data2LabelValue.Position = new Point(200, 97);
			this.data2LabelValue.Size = new Size(230, 40);
			this.data2LabelValue.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.data2LabelValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.mainBackgroundImage.addControl(this.data2LabelValue);
			this.data3Label.Text = SK.Text("FactionInvites_Members", "Members");
			this.data3Label.Color = global::ARGBColors.Black;
			this.data3Label.Position = new Point(210, 121);
			this.data3Label.Size = new Size(600, 40);
			this.data3Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.data3Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainBackgroundImage.addControl(this.data3Label);
			this.data3LabelValue.Text = GameEngine.Instance.World.countHouseMembers(HouseInfoPanel.SelectedHouse).ToString("N", nfi);
			this.data3LabelValue.Color = global::ARGBColors.Black;
			this.data3LabelValue.Position = new Point(200, 121);
			this.data3LabelValue.Size = new Size(230, 40);
			this.data3LabelValue.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.data3LabelValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.mainBackgroundImage.addControl(this.data3LabelValue);
			this.data4Label.Text = SK.Text("FactionInvites_Marshall", "Marshall");
			this.data4Label.Color = global::ARGBColors.Black;
			this.data4Label.Position = new Point(467, 73);
			this.data4Label.Size = new Size(600, 40);
			this.data4Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.data4Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainBackgroundImage.addControl(this.data4Label);
			this.data4LabelValue.Text = houseData.leaderUserName;
			this.data4LabelValue.Color = global::ARGBColors.Black;
			this.data4LabelValue.Position = new Point(517, 73);
			this.data4LabelValue.Size = new Size(230, 40);
			this.data4LabelValue.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.data4LabelValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.mainBackgroundImage.addControl(this.data4LabelValue);
			this.data5Label.Text = SK.Text("STATS_CATEGORY_TITLE_FACTION", "Faction");
			this.data5Label.Color = global::ARGBColors.Black;
			this.data5Label.Position = new Point(467, 97);
			this.data5Label.Size = new Size(600, 40);
			this.data5Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.data5Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainBackgroundImage.addControl(this.data5Label);
			this.data5LabelValue.Text = "";
			if (houseData.leadingFactionID >= 0)
			{
				FactionData faction = GameEngine.Instance.World.getFaction(houseData.leadingFactionID);
				if (faction != null)
				{
					this.data5LabelValue.Text = faction.factionName;
				}
			}
			this.data5LabelValue.Color = global::ARGBColors.Black;
			this.data5LabelValue.Position = new Point(517, 75);
			this.data5LabelValue.Size = new Size(230, 60);
			this.data5LabelValue.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.data5LabelValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.mainBackgroundImage.addControl(this.data5LabelValue);
			int gloryRank = GameEngine.Instance.World.getGloryRank(HouseInfoPanel.SelectedHouse);
			if (gloryRank >= 0)
			{
				this.gloryImage.Image = GFXLibrary.glory_frame;
				this.gloryImage.Position = new Point(490, 10);
				this.mainBackgroundImage.addControl(this.gloryImage);
				this.data6Label.Text = SK.Text("FactionInvites_Glory_Rank", "Glory Rank");
				this.data6Label.Color = global::ARGBColors.Black;
				this.data6Label.Position = new Point(505, 27);
				this.data6Label.Size = new Size(600, 40);
				this.data6Label.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
				this.data6Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.mainBackgroundImage.addControl(this.data6Label);
				this.data6LabelValue.Text = (gloryRank + 1).ToString("N", nfi);
				this.data6LabelValue.Color = global::ARGBColors.Black;
				this.data6LabelValue.Position = new Point(694, 27);
				this.data6LabelValue.Size = new Size(29, 40);
				this.data6LabelValue.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
				this.data6LabelValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.mainBackgroundImage.addControl(this.data6LabelValue);
			}
			this.data7Label.Text = SK.Text("FactionInvites_Glory Victories", "Glory Victories");
			this.data7Label.Color = global::ARGBColors.Black;
			this.data7Label.Position = new Point(467, 121);
			this.data7Label.Size = new Size(600, 40);
			this.data7Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.data7Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainBackgroundImage.addControl(this.data7Label);
			this.data7LabelValue.Text = houseData.numVictories.ToString("N", nfi);
			this.data7LabelValue.Color = global::ARGBColors.Black;
			this.data7LabelValue.Position = new Point(517, 121);
			this.data7LabelValue.Size = new Size(230, 40);
			this.data7LabelValue.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.data7LabelValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.mainBackgroundImage.addControl(this.data7LabelValue);
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
			this.factionLabel.Text = SK.Text("STATS_CATEGORY_TITLE_FACTION", "Faction");
			this.factionLabel.Color = global::ARGBColors.Black;
			this.factionLabel.Position = new Point(9, -2);
			this.factionLabel.Size = new Size(323, this.headerLabelsImage.Height);
			this.factionLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.factionLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.factionLabel);
			this.pointsLabel.Text = SK.Text("FactionsPanel_Points", "Points");
			this.pointsLabel.Color = global::ARGBColors.Black;
			this.pointsLabel.Position = new Point(295, -2);
			this.pointsLabel.Size = new Size(140, this.headerLabelsImage.Height);
			this.pointsLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.pointsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.headerLabelsImage.addControl(this.pointsLabel);
			InterfaceMgr.Instance.setVillageHeading(SK.Text("STATS_CATEGORY_TITLE_HOUSE", "House") + " " + HouseInfoPanel.SelectedHouse.ToString());
			FactionData yourFaction = GameEngine.Instance.World.YourFaction;
			int num = 0;
			if (yourFaction != null)
			{
				num = yourFaction.houseID;
			}
			bool flag = false;
			int yourFactionRank = GameEngine.Instance.World.getYourFactionRank();
			if (num != 0 && num == HouseInfoPanel.SelectedHouse)
			{
				this.leaderVisited();
				if (GameEngine.Instance.World.HouseVoteInfo != null && GameEngine.Instance.World.HouseVoteInfo.appliedToHouseID > 0)
				{
					int appliedToHouseID = GameEngine.Instance.World.HouseVoteInfo.appliedToHouseID;
				}
				if (yourFactionRank == 1 && !GameEngine.Instance.World.WorldEnded)
				{
					this.leaveHouseButton.ImageNorm = GFXLibrary.misc_button_blue_210wide_normal;
					this.leaveHouseButton.ImageOver = GFXLibrary.misc_button_blue_210wide_over;
					this.leaveHouseButton.ImageClick = GFXLibrary.misc_button_blue_210wide_pushed;
					this.leaveHouseButton.Position = new Point(560, height - 30);
					this.leaveHouseButton.Text.Text = SK.Text("FactionsPanel_Leave_House", "Leave House");
					this.leaveHouseButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
					this.leaveHouseButton.TextYOffset = -3;
					this.leaveHouseButton.Text.Color = global::ARGBColors.Black;
					this.leaveHouseButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.leaveHouseClick), "HouseInfoPanel_leave");
					this.mainBackgroundImage.addControl(this.leaveHouseButton);
					flag = true;
				}
				if (yourFactionRank == 1 || yourFactionRank == 2)
				{
					TimeSpan timeSpan = VillageMap.getCurrentServerTime() - yourFaction.lastHouseDate;
					string str;
					if (timeSpan.TotalDays < 1.0 && VillageMap.getCurrentServerTime().Day == yourFaction.lastHouseDate.Day)
					{
						str = SK.Text("FactionsPanel_Today", "Today");
					}
					else if (timeSpan.TotalDays < 2.0 && VillageMap.getCurrentServerTime().Day == yourFaction.lastHouseDate.AddDays(1.0).Day)
					{
						str = SK.Text("FactionsPanel_Yesterday", "Yesterday");
					}
					else
					{
						int num2 = (int)timeSpan.TotalDays;
						if (num2 < 2)
						{
							num2 = 2;
						}
						str = num2.ToString() + " " + SK.Text("FactionsPanel_X_Days_Ago", "Days ago");
					}
					this.lastVisitLabel.Text = SK.Text("FactionsPanel_Last_General_Visit", "Last General Visit") + " : " + str;
					this.lastVisitLabel.Color = global::ARGBColors.Black;
					this.lastVisitLabel.Position = new Point(10, height - 25);
					this.lastVisitLabel.Size = new Size(400, 40);
					this.lastVisitLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
					this.lastVisitLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
					this.mainBackgroundImage.addControl(this.lastVisitLabel);
					flag = true;
				}
				this.divider3Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
				this.divider3Image.Position = new Point(610, 0);
				this.headerLabelsImage.addControl(this.divider3Image);
				this.membershipVoteLabel.Text = SK.Text("FactionsPanel_Membership_Vote", "Membership Vote");
				this.membershipVoteLabel.Color = global::ARGBColors.Black;
				this.membershipVoteLabel.Position = new Point(445, -2);
				this.membershipVoteLabel.Size = new Size(160, this.headerLabelsImage.Height);
				this.membershipVoteLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.membershipVoteLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.headerLabelsImage.addControl(this.membershipVoteLabel);
				this.leadershipVoteLabel.Text = SK.Text("FactionsPanel_Leadership_Vote", "Leadership Vote");
				this.leadershipVoteLabel.Color = global::ARGBColors.Black;
				this.leadershipVoteLabel.Position = new Point(595, -2);
				this.leadershipVoteLabel.Size = new Size(160, this.headerLabelsImage.Height);
				this.leadershipVoteLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.leadershipVoteLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.headerLabelsImage.addControl(this.leadershipVoteLabel);
				int yourHouseRank = GameEngine.Instance.World.getYourHouseRank();
				if (yourHouseRank == 10 && yourFactionRank == 1)
				{
					this.sendProclamationButton.ImageNorm = GFXLibrary.misc_button_blue_210wide_normal;
					this.sendProclamationButton.ImageOver = GFXLibrary.misc_button_blue_210wide_over;
					this.sendProclamationButton.ImageClick = GFXLibrary.misc_button_blue_210wide_pushed;
					this.sendProclamationButton.Position = new Point(330, height - 30);
					this.sendProclamationButton.Text.Text = SK.Text("Capitials_Proclamation", "Send Proclamation");
					this.sendProclamationButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
					this.sendProclamationButton.TextYOffset = -3;
					this.sendProclamationButton.Text.Color = global::ARGBColors.Black;
					this.sendProclamationButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sendProclamation), "HouseInfoPanel_sendProclamation");
					this.mainBackgroundImage.addControl(this.sendProclamationButton);
					HouseData[] houseInfo = GameEngine.Instance.World.HouseInfo;
					DateTime lastProclomationDate = houseInfo[num].lastProclomationDate;
					TimeSpan t = VillageMap.getCurrentServerTime() - lastProclomationDate;
					this.nextProclamationLabel.Text = SK.Text("FactionsPanel_Next_Proclamation_Time", "Next proclamation available in") + " : ";
					this.nextProclamationLabel.Color = global::ARGBColors.White;
					this.nextProclamationLabel.Position = new Point(330, height - 32);
					this.nextProclamationLabel.Size = new Size(160, this.headerLabelsImage.Height);
					this.nextProclamationLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
					this.nextProclamationLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.mainBackgroundImage.addControl(this.nextProclamationLabel);
					if (t.TotalDays >= 1.0)
					{
						this.sendProclamationButton.Enabled = true;
						this.sendProclamationButton.Visible = true;
						this.nextProclamationLabel.Visible = false;
					}
					else
					{
						TimeSpan timeSpan2 = TimeSpan.FromDays(1.0) - t;
						this.sendProclamationButton.Enabled = false;
						this.sendProclamationButton.Visible = false;
						CustomSelfDrawPanel.CSDLabel csdlabel = this.nextProclamationLabel;
						csdlabel.Text += TimeSpan.FromSeconds((double)(timeSpan2.Hours * 60 * 60 + timeSpan2.Minutes * 60 + timeSpan2.Seconds)).ToString();
						this.nextProclamationLabel.Visible = true;
					}
				}
			}
			else if (num > 0)
			{
				bool flag2 = false;
				if (yourFactionRank == 1)
				{
					int yourHouseRank2 = GameEngine.Instance.World.getYourHouseRank();
					if (yourHouseRank2 == 10)
					{
						flag2 = true;
					}
				}
				if (flag2)
				{
					this.diplomacyButton.ImageNorm = GFXLibrary.misc_button_blue_210wide_normal;
					this.diplomacyButton.ImageOver = GFXLibrary.misc_button_blue_210wide_over;
					this.diplomacyButton.ImageClick = GFXLibrary.misc_button_blue_210wide_pushed;
					this.diplomacyButton.Position = new Point(559, height - 30);
					this.diplomacyButton.Text.Text = "";
					this.diplomacyButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.diplomacyButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
					this.diplomacyButton.TextYOffset = -3;
					this.diplomacyButton.Text.Color = global::ARGBColors.Black;
					this.diplomacyButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.diplomacyClicked), "HouseInfoPanel_diplomacy");
					this.mainBackgroundImage.addControl(this.diplomacyButton);
					flag = true;
				}
				else
				{
					this.diplomacyLabel.Text = "";
					this.diplomacyLabel.Color = global::ARGBColors.Black;
					this.diplomacyLabel.Position = new Point(520, height - 25);
					this.diplomacyLabel.Size = new Size(240, 40);
					this.diplomacyLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
					this.diplomacyLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
					this.mainBackgroundImage.addControl(this.diplomacyLabel);
					flag = true;
				}
			}
			this.wallScrollArea.Position = new Point(25, 188);
			if (flag)
			{
				this.wallScrollArea.Size = new Size(705, height - 240);
				this.wallScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(705, height - 240));
			}
			else
			{
				this.wallScrollArea.Size = new Size(705, height - 188);
				this.wallScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(705, height - 188));
			}
			this.mainBackgroundImage.addControl(this.wallScrollArea);
			this.mouseWheelOverlay.Position = this.wallScrollArea.Position;
			this.mouseWheelOverlay.Size = this.wallScrollArea.Size;
			this.mouseWheelOverlay.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mouseWheelMoved));
			this.mainBackgroundImage.addControl(this.mouseWheelOverlay);
			int value = this.wallScrollBar.Value;
			this.wallScrollBar.Position = new Point(733, 188);
			if (flag)
			{
				this.wallScrollBar.Size = new Size(24, height - 240);
			}
			else
			{
				this.wallScrollBar.Size = new Size(24, height - 188);
			}
			this.mainBackgroundImage.addControl(this.wallScrollBar);
			this.wallScrollBar.Value = 0;
			this.wallScrollBar.Max = 100;
			this.wallScrollBar.NumVisibleLines = 25;
			this.wallScrollBar.Create(null, null, null, GFXLibrary._24wide_thumb_top, GFXLibrary._24wide_thumb_middle, GFXLibrary._24wide_thumb_bottom);
			this.wallScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.wallScrollBarMoved));
			this.addFactions();
		}

		// Token: 0x060013C7 RID: 5063 RVA: 0x00156998 File Offset: 0x00154B98
		public void updateRelationshipText()
		{
			int house = GameEngine.Instance.World.getHouse(RemoteServices.Instance.UserFactionID);
			if (RemoteServices.Instance.UserFactionID < 0 || house == 0 || house == HouseInfoPanel.SelectedHouse)
			{
				this.diplomacyButton.Visible = false;
				this.diplomacyLabel.Visible = false;
				return;
			}
			string text = SK.Text("AllArmiesPanel_Diplomacy", "Diplomacy") + " : ";
			this.diplomacyButton.Visible = true;
			this.diplomacyLabel.Visible = true;
			int num = 0;
			if (HouseInfoPanel.SelectedHouse >= 0)
			{
				num = GameEngine.Instance.World.getYourHouseRelation(HouseInfoPanel.SelectedHouse);
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
		}

		// Token: 0x060013C8 RID: 5064 RVA: 0x00015738 File Offset: 0x00013938
		public new void Refresh()
		{
			this.init(false);
		}

		// Token: 0x060013C9 RID: 5065 RVA: 0x00015741 File Offset: 0x00013941
		public void update()
		{
			this.sidebar.update();
		}

		// Token: 0x060013CA RID: 5066 RVA: 0x00156AB0 File Offset: 0x00154CB0
		private void wallScrollBarMoved()
		{
			int value = this.wallScrollBar.Value;
			this.wallScrollArea.Position = new Point(this.wallScrollArea.X, 188 - value);
			this.wallScrollArea.ClipRect = new Rectangle(this.wallScrollArea.ClipRect.X, value, this.wallScrollArea.ClipRect.Width, this.wallScrollArea.ClipRect.Height);
			this.wallScrollArea.invalidate();
			this.wallScrollBar.invalidate();
		}

		// Token: 0x060013CB RID: 5067 RVA: 0x0001574E File Offset: 0x0001394E
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

		// Token: 0x060013CC RID: 5068 RVA: 0x0000ADE9 File Offset: 0x00008FE9
		public void closing()
		{
			InterfaceMgr.Instance.closeDonatePopup();
		}

		// Token: 0x060013CD RID: 5069 RVA: 0x00156B4C File Offset: 0x00154D4C
		private void leaveHouseClick()
		{
			if (GameEngine.Instance.World.YourFaction != null)
			{
				int houseID = GameEngine.Instance.World.YourFaction.houseID;
				if (houseID > 0)
				{
					this.leaveHouseConfirmationPopup(houseID);
				}
			}
		}

		// Token: 0x060013CE RID: 5070 RVA: 0x00156B8C File Offset: 0x00154D8C
		public void leaveHouseConfirmationPopup(int houseID)
		{
			this.houseIDRef = houseID;
			DialogResult dialogResult = MyMessageBox.Show(SK.Text("FORUMS_Are_You_Sure", "Are you sure?"), SK.Text("FactionsPanel_Leave_House", "Leave House"), MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				this.leaveHouseConfirmed();
			}
		}

		// Token: 0x060013CF RID: 5071 RVA: 0x00015780 File Offset: 0x00013980
		private void leaveHouseConfirmed()
		{
			GameEngine.Instance.houseManager.LeaveHouse(this.houseIDRef, new HouseManager.HouseInfoUpdatedCallback(this.Refresh));
		}

		// Token: 0x060013D0 RID: 5072 RVA: 0x000157A3 File Offset: 0x000139A3
		public void houseVote(int targetFaction, bool application, bool vote)
		{
			GameEngine.Instance.houseManager.houseVote(targetFaction, application, vote, new HouseManager.HouseInfoUpdatedCallback(this.Refresh));
		}

		// Token: 0x060013D1 RID: 5073 RVA: 0x000157C3 File Offset: 0x000139C3
		public void houseVoteHouseLeader(int targetFaction)
		{
			if (!this.inHouseVote)
			{
				this.inHouseVote = true;
				GameEngine.Instance.houseManager.houseVoteHouseLeader(targetFaction, new HouseManager.HouseInfoUpdatedCallback(this.houseVoteHouseLeaderCallback));
			}
		}

		// Token: 0x060013D2 RID: 5074 RVA: 0x000157F0 File Offset: 0x000139F0
		public void houseVoteHouseLeaderCallback()
		{
			this.inHouseVote = false;
			this.Refresh();
		}

		// Token: 0x060013D3 RID: 5075 RVA: 0x000157FF File Offset: 0x000139FF
		private void leaderVisited()
		{
			if (GameEngine.Instance.World.getYourFactionRank() == 1 && !this.houseVisitSent)
			{
				this.houseVisitSent = true;
				RemoteServices.Instance.TouchHouseVisitDate(RemoteServices.Instance.UserFactionID);
			}
		}

		// Token: 0x060013D4 RID: 5076 RVA: 0x00015836 File Offset: 0x00013A36
		public void logout()
		{
			this.houseVisitSent = false;
		}

		// Token: 0x060013D5 RID: 5077 RVA: 0x00156BD0 File Offset: 0x00154DD0
		public void addFactions()
		{
			this.wallScrollArea.clearControls();
			int num = 0;
			this.lineList.Clear();
			FactionData yourFaction = GameEngine.Instance.World.YourFaction;
			int num2 = 0;
			int num3 = 0;
			int num4 = -1;
			if (yourFaction != null)
			{
				num2 = yourFaction.houseID;
				num4 = yourFaction.houseLeaderVote;
			}
			if (num2 != 0 && num2 == HouseInfoPanel.SelectedHouse)
			{
				if (GameEngine.Instance.World.HouseVoteInfo != null && GameEngine.Instance.World.HouseVoteInfo.appliedToHouseID > 0)
				{
					int appliedToHouseID = GameEngine.Instance.World.HouseVoteInfo.appliedToHouseID;
				}
				num3 = GameEngine.Instance.World.getYourFactionRank();
			}
			int num5 = 0;
			FactionData[] houseFactions = GameEngine.Instance.World.getHouseFactions(HouseInfoPanel.SelectedHouse);
			HouseVoteData houseVoteInfo = GameEngine.Instance.World.HouseVoteInfo;
			if (num4 < 0)
			{
				num4 = this.m_houseLeaderFactionID;
			}
			bool flag = false;
			FactionData[] array = houseFactions;
			foreach (FactionData factionData in array)
			{
				if (num4 == factionData.factionID)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				num4 = this.m_houseLeaderFactionID;
			}
			FactionData[] array3 = houseFactions;
			foreach (FactionData factionData2 in array3)
			{
				if (factionData2.active && factionData2.numMembers != 0)
				{
					HouseInfoPanel.HouseLine houseLine = new HouseInfoPanel.HouseLine();
					if (num != 0)
					{
						num += 5;
					}
					houseLine.Position = new Point(0, num);
					houseLine.init(factionData2, num5, this);
					if (houseVoteInfo != null && (num3 == 1 || num3 == 2) && num2 == HouseInfoPanel.SelectedHouse)
					{
						bool vote = false;
						if (houseVoteInfo.contains(factionData2.factionID, ref vote))
						{
							int numPos = 0;
							int numNeg = 0;
							if (houseVoteInfo.voteTotals != null)
							{
								for (int k = 0; k < houseVoteInfo.voteTotals.Length / 3; k++)
								{
									if (houseVoteInfo.voteTotals[k, 0] == factionData2.factionID)
									{
										numPos = houseVoteInfo.voteTotals[k, 1];
										numNeg = houseVoteInfo.voteTotals[k, 2];
										break;
									}
								}
							}
							houseLine.extendVote(vote, numPos, numNeg, num3 == 1);
						}
					}
					if ((num3 == 1 || num3 == 2) && num2 == HouseInfoPanel.SelectedHouse)
					{
						bool vote2 = false;
						if (num4 == factionData2.factionID)
						{
							vote2 = true;
						}
						houseLine.extendLeader(vote2, num3 == 1);
					}
					this.wallScrollArea.addControl(houseLine);
					num += houseLine.Height;
					this.lineList.Add(houseLine);
					num5++;
				}
			}
			if (num2 == HouseInfoPanel.SelectedHouse && houseVoteInfo != null && houseVoteInfo.applications != null && houseVoteInfo.applications.Length != 0 && (num3 == 1 || num3 == 2))
			{
				HouseInfoPanel.HouseLine houseLine2 = new HouseInfoPanel.HouseLine();
				houseLine2.Position = new Point(0, num);
				houseLine2.applicationLine();
				this.wallScrollArea.addControl(houseLine2);
				num += houseLine2.Height;
				this.lineList.Add(houseLine2);
				num5++;
				int[] applications = houseVoteInfo.applications;
				foreach (int factionID in applications)
				{
					FactionData faction = GameEngine.Instance.World.getFaction(factionID);
					bool vote3 = false;
					if (faction != null && houseVoteInfo.contains(faction.factionID, ref vote3))
					{
						int numPos2 = 0;
						int numNeg2 = 0;
						if (houseVoteInfo.voteTotals != null)
						{
							for (int m = 0; m < houseVoteInfo.voteTotals.Length / 3; m++)
							{
								if (houseVoteInfo.voteTotals[m, 0] == faction.factionID)
								{
									numPos2 = houseVoteInfo.voteTotals[m, 1];
									numNeg2 = houseVoteInfo.voteTotals[m, 2];
									break;
								}
							}
						}
						houseLine2 = new HouseInfoPanel.HouseLine();
						if (num != 0)
						{
							num += 5;
						}
						houseLine2.Position = new Point(0, num);
						houseLine2.init(faction, num5, this);
						houseLine2.extendVote(vote3, numPos2, numNeg2, num3 == 1);
						houseLine2.setAsApplication();
						this.wallScrollArea.addControl(houseLine2);
						num += houseLine2.Height;
						this.lineList.Add(houseLine2);
						num5++;
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

		// Token: 0x060013D6 RID: 5078 RVA: 0x0001583F File Offset: 0x00013A3F
		private void diplomacyClicked()
		{
			this.addDiplomacyOverlay();
		}

		// Token: 0x060013D7 RID: 5079 RVA: 0x001570A0 File Offset: 0x001552A0
		public void addDiplomacyOverlay()
		{
			this.removeOverlay();
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
			this.diplomacyFactionLabel.Text = SK.Text("STATS_CATEGORY_TITLE_HOUSE", "House") + " " + HouseInfoPanel.SelectedHouse.ToString();
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
			int yourHouseRelation = GameEngine.Instance.World.getYourHouseRelation(HouseInfoPanel.SelectedHouse);
			if (yourHouseRelation == 0)
			{
				text += SK.Text("GENERIC_Neutral", "Neutral");
			}
			else if (yourHouseRelation > 0)
			{
				text += SK.Text("GENERIC_Ally", "Ally");
			}
			else if (yourHouseRelation < 0)
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
			this.diplomacyNeutralButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnBreakAlliance_Click), "HouseInfoPanel_neutral");
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
			this.diplomacyAllyButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnAlly_Click), "HouseInfoPanel_ally");
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
			this.diplomacyEnemyButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnMakeEnemy_Click), "HouseInfoPanel_enemy");
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
			}, "HouseInfoPanel_cancel");
			this.diplomacyBackgroundImage.addControl(this.diplomacyCancelButton);
			this.diplomacyEnemyButton.Enabled = true;
			this.diplomacyAllyButton.Enabled = true;
			this.diplomacyNeutralButton.Enabled = true;
		}

		// Token: 0x060013D8 RID: 5080 RVA: 0x00015847 File Offset: 0x00013A47
		public void removeOverlay()
		{
			this.mainBackgroundImage.removeControl(this.greyOverlay);
			this.greyOverlay.clearControls();
			base.Invalidate();
		}

		// Token: 0x060013D9 RID: 5081 RVA: 0x001578F0 File Offset: 0x00155AF0
		private void btnAlly_Click()
		{
			this.diplomacyEnemyButton.Enabled = false;
			this.diplomacyAllyButton.Enabled = false;
			this.diplomacyNeutralButton.Enabled = false;
			RemoteServices.Instance.set_CreateHouseRelationship_UserCallBack(new RemoteServices.CreateHouseRelationship_UserCallBack(this.createHouseRelationshipCallback));
			RemoteServices.Instance.CreateHouseRelationship(HouseInfoPanel.SelectedHouse, 1);
		}

		// Token: 0x060013DA RID: 5082 RVA: 0x00157948 File Offset: 0x00155B48
		private void btnMakeEnemy_Click()
		{
			this.diplomacyEnemyButton.Enabled = false;
			this.diplomacyAllyButton.Enabled = false;
			this.diplomacyNeutralButton.Enabled = false;
			RemoteServices.Instance.set_CreateHouseRelationship_UserCallBack(new RemoteServices.CreateHouseRelationship_UserCallBack(this.createHouseRelationshipCallback));
			RemoteServices.Instance.CreateHouseRelationship(HouseInfoPanel.SelectedHouse, -1);
		}

		// Token: 0x060013DB RID: 5083 RVA: 0x001579A0 File Offset: 0x00155BA0
		private void btnBreakAlliance_Click()
		{
			this.diplomacyEnemyButton.Enabled = false;
			this.diplomacyAllyButton.Enabled = false;
			this.diplomacyNeutralButton.Enabled = false;
			RemoteServices.Instance.set_CreateHouseRelationship_UserCallBack(new RemoteServices.CreateHouseRelationship_UserCallBack(this.createHouseRelationshipCallback));
			RemoteServices.Instance.CreateHouseRelationship(HouseInfoPanel.SelectedHouse, 0);
		}

		// Token: 0x060013DC RID: 5084 RVA: 0x001579F8 File Offset: 0x00155BF8
		private void createHouseRelationshipCallback(CreateHouseRelationship_ReturnType returnData)
		{
			if (returnData.Success)
			{
				GameEngine.Instance.World.HouseAllies = returnData.yourHouseAllies;
				GameEngine.Instance.World.HouseEnemies = returnData.yourHouseEnemies;
				this.init(false);
				return;
			}
			this.diplomacyEnemyButton.Enabled = true;
			this.diplomacyAllyButton.Enabled = true;
			this.diplomacyNeutralButton.Enabled = true;
		}

		// Token: 0x060013DD RID: 5085 RVA: 0x0001586B File Offset: 0x00013A6B
		private void sendProclamation()
		{
			GameEngine.Instance.playInterfaceSound("UserInfoScreen_send_mail");
			InterfaceMgr.Instance.getMainTabBar().selectDummyTabFast(21);
			InterfaceMgr.Instance.sendProclamation(2, GameEngine.Instance.World.YourHouse);
		}

		// Token: 0x060013DE RID: 5086 RVA: 0x000158A7 File Offset: 0x00013AA7
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x060013DF RID: 5087 RVA: 0x000158B7 File Offset: 0x00013AB7
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x060013E0 RID: 5088 RVA: 0x000158C7 File Offset: 0x00013AC7
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x060013E1 RID: 5089 RVA: 0x000158D9 File Offset: 0x00013AD9
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x060013E2 RID: 5090 RVA: 0x000158E6 File Offset: 0x00013AE6
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closing();
		}

		// Token: 0x060013E3 RID: 5091 RVA: 0x00015900 File Offset: 0x00013B00
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x060013E4 RID: 5092 RVA: 0x0001590D File Offset: 0x00013B0D
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x060013E5 RID: 5093 RVA: 0x0001591A File Offset: 0x00013B1A
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060013E6 RID: 5094 RVA: 0x00157A64 File Offset: 0x00155C64
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.MaximumSize = new Size(992, 10000);
			this.MinimumSize = new Size(992, 566);
			base.Name = "HouseInfoPanel";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x04002559 RID: 9561
		public const int PANEL_ID = 52;

		// Token: 0x0400255A RID: 9562
		public static HouseInfoPanel instance = null;

		// Token: 0x0400255B RID: 9563
		public static int SelectedHouse = -1;

		// Token: 0x0400255C RID: 9564
		private int m_houseLeaderFactionID = -1;

		// Token: 0x0400255D RID: 9565
		private CustomSelfDrawPanel.CSDFill mainBackgroundImage = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x0400255E RID: 9566
		private CustomSelfDrawPanel.CSDImage backgroundFade = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400255F RID: 9567
		private CustomSelfDrawPanel.CSDLabel titleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002560 RID: 9568
		private CustomSelfDrawPanel.CSDLabel houseNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002561 RID: 9569
		private CustomSelfDrawPanel.CSDLabel houseMottoLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002562 RID: 9570
		private CustomSelfDrawPanel.CSDImage houseImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002563 RID: 9571
		private CustomSelfDrawPanel.CSDLabel data1Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002564 RID: 9572
		private CustomSelfDrawPanel.CSDLabel data1LabelValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002565 RID: 9573
		private CustomSelfDrawPanel.CSDLabel data2Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002566 RID: 9574
		private CustomSelfDrawPanel.CSDLabel data2LabelValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002567 RID: 9575
		private CustomSelfDrawPanel.CSDLabel data3Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002568 RID: 9576
		private CustomSelfDrawPanel.CSDLabel data3LabelValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002569 RID: 9577
		private CustomSelfDrawPanel.CSDLabel data4Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400256A RID: 9578
		private CustomSelfDrawPanel.CSDLabel data4LabelValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400256B RID: 9579
		private CustomSelfDrawPanel.CSDLabel data5Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400256C RID: 9580
		private CustomSelfDrawPanel.CSDLabel data5LabelValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400256D RID: 9581
		private CustomSelfDrawPanel.CSDLabel data6Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400256E RID: 9582
		private CustomSelfDrawPanel.CSDLabel data6LabelValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400256F RID: 9583
		private CustomSelfDrawPanel.CSDLabel data7Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002570 RID: 9584
		private CustomSelfDrawPanel.CSDLabel data7LabelValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002571 RID: 9585
		private CustomSelfDrawPanel.CSDLabel diplomacyLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002572 RID: 9586
		private CustomSelfDrawPanel.CSDButton diplomacyButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002573 RID: 9587
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04002574 RID: 9588
		private CustomSelfDrawPanel.CSDImage divider1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002575 RID: 9589
		private CustomSelfDrawPanel.CSDImage divider2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002576 RID: 9590
		private CustomSelfDrawPanel.CSDImage divider3Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002577 RID: 9591
		private CustomSelfDrawPanel.CSDLabel factionLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002578 RID: 9592
		private CustomSelfDrawPanel.CSDLabel pointsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002579 RID: 9593
		private CustomSelfDrawPanel.CSDLabel membershipVoteLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400257A RID: 9594
		private CustomSelfDrawPanel.CSDLabel leadershipVoteLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400257B RID: 9595
		private CustomSelfDrawPanel.CSDVertScrollBar wallScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x0400257C RID: 9596
		private CustomSelfDrawPanel.CSDArea wallScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400257D RID: 9597
		private CustomSelfDrawPanel.CSDControl mouseWheelOverlay = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x0400257E RID: 9598
		private CustomSelfDrawPanel.CSDImage backImage1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400257F RID: 9599
		private CustomSelfDrawPanel.CSDImage backImage2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002580 RID: 9600
		private CustomSelfDrawPanel.CSDImage barImage1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002581 RID: 9601
		private CustomSelfDrawPanel.CSDImage barImage2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002582 RID: 9602
		private CustomSelfDrawPanel.CSDImage barImage3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002583 RID: 9603
		private CustomSelfDrawPanel.CSDImage barImage4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002584 RID: 9604
		private CustomSelfDrawPanel.CSDImage barImage5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002585 RID: 9605
		private CustomSelfDrawPanel.CSDImage barImage6 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002586 RID: 9606
		private CustomSelfDrawPanel.CSDImage gloryImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002587 RID: 9607
		private CustomSelfDrawPanel.CSDButton leaveHouseButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002588 RID: 9608
		private CustomSelfDrawPanel.CSDLabel lastVisitLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002589 RID: 9609
		private CustomSelfDrawPanel.CSDButton sendProclamationButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400258A RID: 9610
		private CustomSelfDrawPanel.CSDLabel nextProclamationLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400258B RID: 9611
		private CustomSelfDrawPanel.FactionPanelSideBar sidebar = new CustomSelfDrawPanel.FactionPanelSideBar();

		// Token: 0x0400258C RID: 9612
		private MyMessageBoxPopUp PopUpRef;

		// Token: 0x0400258D RID: 9613
		private int houseIDRef;

		// Token: 0x0400258E RID: 9614
		private bool inHouseVote;

		// Token: 0x0400258F RID: 9615
		private bool houseVisitSent;

		// Token: 0x04002590 RID: 9616
		private List<HouseInfoPanel.HouseLine> lineList = new List<HouseInfoPanel.HouseLine>();

		// Token: 0x04002591 RID: 9617
		private CustomSelfDrawPanel.CSDFill greyOverlay = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x04002592 RID: 9618
		private CustomSelfDrawPanel.CSDHorzExtendingPanel diplomacyHeaderImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04002593 RID: 9619
		private CustomSelfDrawPanel.CSDExtendingPanel diplomacyBackgroundImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04002594 RID: 9620
		private CustomSelfDrawPanel.CSDButton diplomacyNeutralButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002595 RID: 9621
		private CustomSelfDrawPanel.CSDButton diplomacyAllyButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002596 RID: 9622
		private CustomSelfDrawPanel.CSDButton diplomacyEnemyButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002597 RID: 9623
		private CustomSelfDrawPanel.CSDButton diplomacyCancelButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002598 RID: 9624
		private CustomSelfDrawPanel.CSDLabel diplomacyHeadingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002599 RID: 9625
		private CustomSelfDrawPanel.CSDLabel diplomacyFactionLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400259A RID: 9626
		private CustomSelfDrawPanel.CSDLabel diplomacyCurrentLabelHeader = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400259B RID: 9627
		private CustomSelfDrawPanel.CSDLabel diplomacyCurrentLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400259C RID: 9628
		private DockableControl dockableControl;

		// Token: 0x0400259D RID: 9629
		private IContainer components;

		// Token: 0x0400259E RID: 9630
		[CompilerGenerated]
		private static CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate _003C_003E9__CachedAnonymousMethodDelegate2;

		// Token: 0x020001F1 RID: 497
		public class HouseLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x060013E9 RID: 5097 RVA: 0x00157AD0 File Offset: 0x00155CD0
			public void init(FactionData factionData, int position, HouseInfoPanel parent)
			{
				this.m_parent = parent;
				this.m_position = position;
				this.m_factionData = factionData;
				this.m_application = false;
				this.clearControls();
				if ((position & 1) == 0)
				{
					this.backgroundImage.Image = GFXLibrary.lineitem_strip_02_light;
				}
				else
				{
					this.backgroundImage.Image = GFXLibrary.lineitem_strip_02_dark;
				}
				this.backgroundImage.Position = new Point(60, 0);
				base.addControl(this.backgroundImage);
				this.Size = this.backgroundImage.Size;
				this.flagImage.createFromFlagData(factionData.flagData);
				this.flagImage.Position = new Point(0, 0);
				this.flagImage.Scale = 0.25;
				this.flagImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
				base.addControl(this.flagImage);
				NumberFormatInfo nfi = GameEngine.NFI;
				this.factionName.Text = factionData.factionName;
				this.factionName.Color = global::ARGBColors.Black;
				this.factionName.Position = new Point(9, 0);
				this.factionName.Size = new Size(220, this.backgroundImage.Height);
				this.factionName.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.factionName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.factionName.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
				this.backgroundImage.addControl(this.factionName);
				this.pointsLabel.Text = factionData.points.ToString("N", nfi);
				this.pointsLabel.Color = global::ARGBColors.Black;
				this.pointsLabel.Position = new Point(235, 0);
				this.pointsLabel.Size = new Size(100, this.backgroundImage.Height);
				this.pointsLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.pointsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.pointsLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
				this.backgroundImage.addControl(this.pointsLabel);
				base.invalidate();
			}

			// Token: 0x060013EA RID: 5098 RVA: 0x00157D18 File Offset: 0x00155F18
			public void applicationLine()
			{
				this.clearControls();
				this.factionName.Text = SK.Text("HouseFactionsLine_Application", "Applications");
				this.factionName.Color = global::ARGBColors.Black;
				this.factionName.Position = new Point(9, 2);
				this.factionName.Size = new Size(GFXLibrary.lineitem_strip_02_light.Width, GFXLibrary.lineitem_strip_02_light.Height);
				this.factionName.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.factionName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				base.addControl(this.factionName);
				this.Size = GFXLibrary.lineitem_strip_02_light.Size;
			}

			// Token: 0x060013EB RID: 5099 RVA: 0x00157DD0 File Offset: 0x00155FD0
			public void extendVote(bool vote, int numPos, int numNeg, bool leader)
			{
				if (GameEngine.Instance.World.WorldEnded)
				{
					return;
				}
				NumberFormatInfo nfi = GameEngine.NFI;
				this.posLabel.Text = numPos.ToString("N", nfi);
				this.posLabel.Color = global::ARGBColors.Black;
				this.posLabel.Position = new Point(329, 0);
				this.posLabel.Size = new Size(100, this.backgroundImage.Height);
				this.posLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.posLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.backgroundImage.addControl(this.posLabel);
				this.newLabel.Text = numNeg.ToString("N", nfi);
				this.newLabel.Color = global::ARGBColors.Black;
				this.newLabel.Position = new Point(389, 0);
				this.newLabel.Size = new Size(100, this.backgroundImage.Height);
				this.newLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.newLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.backgroundImage.addControl(this.newLabel);
				if (!vote)
				{
					this.posVote.ImageNorm = GFXLibrary.radio_green[2];
					this.posVote.ImageOver = GFXLibrary.radio_green[1];
					this.posVote.ImageClick = GFXLibrary.radio_green[1];
					this.posVote.Position = new Point(434, 7);
					if (leader)
					{
						this.posVote.Active = true;
						this.posVote.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.posVoteClicked), "HouseInfoPanel_");
					}
					else
					{
						this.posVote.Active = false;
					}
					this.backgroundImage.addControl(this.posVote);
					this.negVote.ImageNorm = GFXLibrary.radio_green[0];
					this.negVote.ImageOver = GFXLibrary.radio_green[0];
					this.negVote.ImageClick = GFXLibrary.radio_green[0];
					this.negVote.Active = false;
					this.negVote.Position = new Point(494, 7);
					this.backgroundImage.addControl(this.negVote);
					return;
				}
				this.posVote.ImageNorm = GFXLibrary.radio_green[0];
				this.posVote.ImageOver = GFXLibrary.radio_green[0];
				this.posVote.ImageClick = GFXLibrary.radio_green[0];
				this.posVote.Active = false;
				this.posVote.Position = new Point(434, 7);
				this.backgroundImage.addControl(this.posVote);
				this.negVote.ImageNorm = GFXLibrary.radio_green[2];
				this.negVote.ImageOver = GFXLibrary.radio_green[1];
				this.negVote.ImageClick = GFXLibrary.radio_green[1];
				this.negVote.Position = new Point(494, 7);
				if (leader)
				{
					this.negVote.Active = true;
					this.negVote.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.negVoteClicked), "HouseInfoPanel_");
				}
				else
				{
					this.negVote.Active = false;
				}
				this.backgroundImage.addControl(this.negVote);
			}

			// Token: 0x060013EC RID: 5100 RVA: 0x00158160 File Offset: 0x00156360
			public void extendLeader(bool vote, bool leader)
			{
				if (!vote)
				{
					this.leaderVote.ImageNorm = GFXLibrary.radio_green[2];
					this.leaderVote.ImageOver = GFXLibrary.radio_green[1];
					this.leaderVote.ImageClick = GFXLibrary.radio_green[1];
					this.leaderVote.Position = new Point(598, 7);
					if (leader)
					{
						this.leaderVote.Active = true;
						this.leaderVote.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.leaderClicked), "HouseInfoPanel_");
					}
					else
					{
						this.leaderVote.Active = false;
					}
					this.backgroundImage.addControl(this.leaderVote);
					return;
				}
				this.leaderVote.ImageNorm = GFXLibrary.radio_green[0];
				this.leaderVote.ImageOver = GFXLibrary.radio_green[0];
				this.leaderVote.ImageClick = GFXLibrary.radio_green[0];
				this.leaderVote.Active = false;
				this.leaderVote.Position = new Point(598, 7);
				this.backgroundImage.addControl(this.leaderVote);
			}

			// Token: 0x060013ED RID: 5101 RVA: 0x0001594F File Offset: 0x00013B4F
			public void setAsApplication()
			{
				this.m_application = true;
			}

			// Token: 0x060013EE RID: 5102 RVA: 0x00007CE0 File Offset: 0x00005EE0
			public void update()
			{
			}

			// Token: 0x060013EF RID: 5103 RVA: 0x00015958 File Offset: 0x00013B58
			public void clickedLine()
			{
				GameEngine.Instance.playInterfaceSound("HouseInfoPanel_faction");
				InterfaceMgr.Instance.showFactionPanel(this.m_factionData.factionID);
			}

			// Token: 0x060013F0 RID: 5104 RVA: 0x0001597E File Offset: 0x00013B7E
			public void posVoteClicked()
			{
				this.posVote.Active = false;
				this.m_parent.houseVote(this.m_factionData.factionID, this.m_application, true);
			}

			// Token: 0x060013F1 RID: 5105 RVA: 0x000159A9 File Offset: 0x00013BA9
			public void negVoteClicked()
			{
				this.negVote.Active = false;
				this.m_parent.houseVote(this.m_factionData.factionID, this.m_application, false);
			}

			// Token: 0x060013F2 RID: 5106 RVA: 0x000159D4 File Offset: 0x00013BD4
			public void leaderClicked()
			{
				this.m_parent.houseVoteHouseLeader(this.m_factionData.factionID);
			}

			// Token: 0x0400259F RID: 9631
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040025A0 RID: 9632
			private CustomSelfDrawPanel.CSDLabel factionName = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040025A1 RID: 9633
			private CustomSelfDrawPanel.CSDLabel numPlayersLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040025A2 RID: 9634
			private CustomSelfDrawPanel.CSDLabel pointsLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040025A3 RID: 9635
			private CustomSelfDrawPanel.CSDLabel membershipLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040025A4 RID: 9636
			private CustomSelfDrawPanel.CSDImage allianceImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040025A5 RID: 9637
			private CustomSelfDrawPanel.CSDFactionFlagImage flagImage = new CustomSelfDrawPanel.CSDFactionFlagImage();

			// Token: 0x040025A6 RID: 9638
			private int m_position = -1000;

			// Token: 0x040025A7 RID: 9639
			private FactionData m_factionData;

			// Token: 0x040025A8 RID: 9640
			private bool m_application;

			// Token: 0x040025A9 RID: 9641
			private HouseInfoPanel m_parent;

			// Token: 0x040025AA RID: 9642
			private CustomSelfDrawPanel.CSDLabel posLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040025AB RID: 9643
			private CustomSelfDrawPanel.CSDLabel newLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040025AC RID: 9644
			private CustomSelfDrawPanel.CSDButton posVote = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040025AD RID: 9645
			private CustomSelfDrawPanel.CSDButton negVote = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040025AE RID: 9646
			private CustomSelfDrawPanel.CSDButton leaderVote = new CustomSelfDrawPanel.CSDButton();
		}
	}
}
