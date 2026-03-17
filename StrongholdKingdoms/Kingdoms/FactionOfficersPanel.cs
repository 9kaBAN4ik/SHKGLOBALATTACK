using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020001D0 RID: 464
	public class FactionOfficersPanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x0600116D RID: 4461 RVA: 0x00126B54 File Offset: 0x00124D54
		public FactionOfficersPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x0600116E RID: 4462 RVA: 0x00126D34 File Offset: 0x00124F34
		public void init(bool resized)
		{
			int height = base.Height;
			FactionOfficersPanel.instance = this;
			base.clearControls();
			NumberFormatInfo nfi = GameEngine.NFI;
			this.sidebar.addSideBar(3, this);
			FactionData factionData = GameEngine.Instance.World.YourFaction;
			if (factionData == null)
			{
				factionData = new FactionData();
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
			int yourFactionRank = GameEngine.Instance.World.getYourFactionRank();
			this.factionMottoLabel.Text = "\"" + factionData.factionMotto + "\"";
			this.factionMottoLabel.Color = global::ARGBColors.Black;
			if (yourFactionRank == 1)
			{
				this.factionMottoLabel.Position = new Point(230, 41);
			}
			else
			{
				this.factionMottoLabel.Position = new Point(205, 41);
			}
			this.factionMottoLabel.Size = new Size(600, 40);
			this.factionMottoLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.factionMottoLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainBackgroundImage.addControl(this.factionMottoLabel);
			this.applicationButton.ImageNorm = GFXLibrary.misc_button_blue_210wide_normal;
			this.applicationButton.ImageOver = GFXLibrary.misc_button_blue_210wide_over;
			this.applicationButton.ImageClick = GFXLibrary.misc_button_blue_210wide_pushed;
			this.applicationButton.Position = new Point(24, 126);
			if (factionData.openForApplications)
			{
				this.applicationButton.Text.Text = SK.Text("FactionInvites_Accepting_Apps", "Accepting");
			}
			else
			{
				this.applicationButton.Text.Text = SK.Text("FactionInvites_Not_Accepting_App", "Not Accepting");
			}
			this.applicationButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.applicationButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.applicationButton.TextYOffset = -3;
			this.applicationButton.Text.Color = global::ARGBColors.Black;
			this.applicationButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.setApplicationModeClicked));
			this.applicationButton.Enabled = true;
			this.mainBackgroundImage.addControl(this.applicationButton);
			this.applicationsLabel.Text = SK.Text("FactionInvites_Applications", "Applications");
			this.applicationsLabel.Color = global::ARGBColors.Black;
			this.applicationsLabel.Position = new Point(24, 96);
			this.applicationsLabel.Size = this.applicationButton.Size;
			this.applicationsLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.applicationsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.mainBackgroundImage.addControl(this.applicationsLabel);
			if (yourFactionRank == 1)
			{
				this.editButton.ImageNorm = GFXLibrary.faction_pen;
				this.editButton.ImageOver = GFXLibrary.faction_pen;
				this.editButton.ImageClick = GFXLibrary.faction_pen;
				this.editButton.Position = new Point(205, 41);
				this.editButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.editClicked), "FactionOfficersPanel_edit");
				this.mainBackgroundImage.addControl(this.editButton);
			}
			if (factionData.houseID > 0)
			{
				this.houseLabel.Text = SK.Text("STATS_CATEGORY_TITLE_HOUSE", "House") + " " + factionData.houseID.ToString();
				this.houseLabel.Color = global::ARGBColors.Black;
				this.houseLabel.Position = new Point(575, 110);
				this.houseLabel.Size = new Size(200, 50);
				this.houseLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.houseLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.houseLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.houseClicked), "FactionOfficersPanel_house");
				this.mainBackgroundImage.addControl(this.houseLabel);
				this.houseImage.Image = GFXLibrary.house_circles_large[factionData.houseID - 1];
				this.houseImage.Position = new Point(675 - this.houseImage.Image.Width / 2, 65 - this.houseImage.Image.Height / 2 + 8);
				this.houseImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.houseClicked), "FactionOfficersPanel_house");
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
			this.rankHeaderLabelValue.Text = (GameEngine.Instance.World.getYourFactionRank() + 1).ToString("N", nfi);
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
			this.playerNameLabel.Text = SK.Text("UserInfoPanel_", "Player Name");
			this.playerNameLabel.Color = global::ARGBColors.Black;
			this.playerNameLabel.Position = new Point(9, -2);
			this.playerNameLabel.Size = new Size(323, this.headerLabelsImage.Height);
			this.playerNameLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.playerNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.playerNameLabel);
			this.leadershipVoteLabel.Text = SK.Text("FactionsPanel_Leadership_Vote", "Leadership Vote");
			this.leadershipVoteLabel.Color = global::ARGBColors.Black;
			this.leadershipVoteLabel.Position = new Point(444, -2);
			this.leadershipVoteLabel.Size = new Size(300, this.headerLabelsImage.Height);
			this.leadershipVoteLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.leadershipVoteLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.headerLabelsImage.addControl(this.leadershipVoteLabel);
			InterfaceMgr.Instance.setVillageHeading(SK.Text("FactionInvites_Faction_Officers", "Faction Officers"));
			this.inviteButton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
			this.inviteButton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
			this.inviteButton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
			this.inviteButton.Position = new Point(20, height - 30);
			this.inviteButton.Text.Text = SK.Text("FactionsPanel_Invite_User", "Invite User");
			this.inviteButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.inviteButton.TextYOffset = -3;
			this.inviteButton.Text.Color = global::ARGBColors.Black;
			this.inviteButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.inviteClick), "FactionOfficersPanel_invite");
			this.mainBackgroundImage.addControl(this.inviteButton);
			this.wallScrollArea.Position = new Point(25, 188);
			this.wallScrollArea.Size = new Size(705, height - 50 - 150 - 40);
			this.wallScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(705, height - 50 - 150 - 40));
			this.mainBackgroundImage.addControl(this.wallScrollArea);
			this.mouseWheelOverlay.Position = this.wallScrollArea.Position;
			this.mouseWheelOverlay.Size = this.wallScrollArea.Size;
			this.mouseWheelOverlay.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mouseWheelMoved));
			this.mainBackgroundImage.addControl(this.mouseWheelOverlay);
			this.flagimage.createFromFlagData(factionData.flagData);
			this.flagimage.Position = new Point(35, 6);
			this.flagimage.Scale = 0.5;
			this.flagimage.ClickArea = new Rectangle(0, 0, GFXLibrary.factionFlags[0].Width / 2, GFXLibrary.factionFlags[0].Height / 2);
			if (yourFactionRank == 1)
			{
				this.flagimage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.editClicked), "FactionOfficersPanel_edit");
			}
			else
			{
				this.flagimage.setClickDelegate(null);
			}
			this.mainBackgroundImage.addControl(this.flagimage);
			int value = this.wallScrollBar.Value;
			this.wallScrollBar.Visible = false;
			this.wallScrollBar.Position = new Point(733, 188);
			this.wallScrollBar.Size = new Size(24, height - 50 - 150 - 40);
			this.mainBackgroundImage.addControl(this.wallScrollBar);
			this.wallScrollBar.Value = 0;
			this.wallScrollBar.Max = 100;
			this.wallScrollBar.NumVisibleLines = 25;
			this.wallScrollBar.Create(null, null, null, GFXLibrary._24wide_thumb_top, GFXLibrary._24wide_thumb_middle, GFXLibrary._24wide_thumb_bottom);
			this.wallScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.wallScrollBarMoved));
			bool flag = false;
			FactionMemberData[] factionMemberData = GameEngine.Instance.World.getFactionMemberData(factionData.factionID, ref flag);
			if (!resized && !flag)
			{
				RemoteServices.Instance.set_GetViewFactionData_UserCallBack(new RemoteServices.GetViewFactionData_UserCallBack(this.getViewFactionDataCallback));
				RemoteServices.Instance.GetViewFactionData(factionData.factionID);
			}
			this.addPlayers(factionMemberData);
		}

		// Token: 0x0600116F RID: 4463 RVA: 0x00127D00 File Offset: 0x00125F00
		private void getViewFactionDataCallback(GetViewFactionData_ReturnType returnData)
		{
			if (returnData.Success)
			{
				NumberFormatInfo nfi = GameEngine.NFI;
				this.addPlayers(returnData.members);
				if (returnData.factionData != null)
				{
					GameEngine.Instance.World.setFactionMemberData(returnData.factionData.factionID, returnData.members);
				}
				GameEngine.Instance.World.setFactionData(returnData.factionData);
				GameEngine.Instance.World.FactionAllies = returnData.yourAllies;
				GameEngine.Instance.World.FactionEnemies = returnData.yourEnemies;
			}
		}

		// Token: 0x06001170 RID: 4464 RVA: 0x000130FD File Offset: 0x000112FD
		public void update()
		{
			this.sidebar.update();
			if (this.tbInviteName.Text.Length == 0)
			{
				this.inviteButton.Enabled = false;
				return;
			}
			this.inviteButton.Enabled = true;
		}

		// Token: 0x06001171 RID: 4465 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void logout()
		{
		}

		// Token: 0x06001172 RID: 4466 RVA: 0x00127D90 File Offset: 0x00125F90
		private void wallScrollBarMoved()
		{
			int value = this.wallScrollBar.Value;
			this.wallScrollArea.Position = new Point(this.wallScrollArea.X, 188 - value);
			this.wallScrollArea.ClipRect = new Rectangle(this.wallScrollArea.ClipRect.X, value, this.wallScrollArea.ClipRect.Width, this.wallScrollArea.ClipRect.Height);
			this.wallScrollArea.invalidate();
			this.wallScrollBar.invalidate();
		}

		// Token: 0x06001173 RID: 4467 RVA: 0x00013135 File Offset: 0x00011335
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

		// Token: 0x06001174 RID: 4468 RVA: 0x00013167 File Offset: 0x00011367
		public void editClicked()
		{
			InterfaceMgr.Instance.showEditFactionPanel();
		}

		// Token: 0x06001175 RID: 4469 RVA: 0x00127E2C File Offset: 0x0012602C
		public void houseClicked()
		{
			FactionData yourFaction = GameEngine.Instance.World.YourFaction;
			if (yourFaction != null && yourFaction.houseID > 0)
			{
				InterfaceMgr.Instance.showHousePanel(yourFaction.houseID);
			}
		}

		// Token: 0x06001176 RID: 4470 RVA: 0x0000ADE9 File Offset: 0x00008FE9
		public void closing()
		{
			InterfaceMgr.Instance.closeDonatePopup();
		}

		// Token: 0x06001177 RID: 4471 RVA: 0x00127E68 File Offset: 0x00126068
		public void addPlayers(FactionMemberData[] fmd)
		{
			this.wallScrollArea.clearControls();
			int num = 0;
			this.lineList.Clear();
			int num2 = 0;
			if (fmd != null)
			{
				int num3 = 0;
				foreach (FactionMemberData factionMemberData in fmd)
				{
					if (factionMemberData.status == 2)
					{
						num3++;
					}
				}
				for (int j = 0; j < 5; j++)
				{
					int num4 = 1;
					switch (j)
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
					case 4:
						num4 = -3;
						break;
					}
					foreach (FactionMemberData factionMemberData2 in fmd)
					{
						if (factionMemberData2.status == num4)
						{
							FactionOfficersPanel.FactionMemberLineOfficer factionMemberLineOfficer = new FactionOfficersPanel.FactionMemberLineOfficer();
							if (num != 0)
							{
								num += 5;
							}
							factionMemberLineOfficer.Position = new Point(0, num);
							factionMemberLineOfficer.init(factionMemberData2, num2, this, true, num3);
							this.wallScrollArea.addControl(factionMemberLineOfficer);
							num += factionMemberLineOfficer.Height;
							this.lineList.Add(factionMemberLineOfficer);
							num2++;
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
			this.update();
			base.Invalidate();
		}

		// Token: 0x06001178 RID: 4472 RVA: 0x00013173 File Offset: 0x00011373
		public void inviteClick()
		{
			if (this.tbInviteName.Text.Length > 0)
			{
				this.inviteToFaction(this.tbInviteName.Text);
			}
		}

		// Token: 0x06001179 RID: 4473 RVA: 0x00128014 File Offset: 0x00126214
		public void setApplicationModeClicked()
		{
			FactionData factionData = GameEngine.Instance.World.YourFaction;
			if (factionData == null)
			{
				factionData = new FactionData();
			}
			this.applicationButton.Enabled = false;
			RemoteServices.Instance.set_FactionApplicationProcessing_UserCallBack(new RemoteServices.FactionApplicationProcessing_UserCallBack(this.factionApplicationProcessingCallback));
			RemoteServices.Instance.FactionApplicationSetMode(!factionData.openForApplications);
		}

		// Token: 0x0600117A RID: 4474 RVA: 0x00128070 File Offset: 0x00126270
		public void factionApplicationProcessingCallback(FactionApplicationProcessing_ReturnType returnData)
		{
			this.applicationButton.Enabled = true;
			if (returnData.members != null)
			{
				GameEngine.Instance.World.FactionMembers = returnData.members;
				GameEngine.Instance.World.YourFaction = returnData.yourFaction;
				this.init(false);
			}
		}

		// Token: 0x0600117B RID: 4475 RVA: 0x00013199 File Offset: 0x00011399
		public void inviteToFaction(string username)
		{
			this.invitedUserName = username;
			RemoteServices.Instance.set_FactionSendInvite_UserCallBack(new RemoteServices.FactionSendInvite_UserCallBack(this.factionSendInviteCallback));
			RemoteServices.Instance.FactionSendInvite(username);
		}

		// Token: 0x0600117C RID: 4476 RVA: 0x001280C4 File Offset: 0x001262C4
		public void factionSendInviteCallback(FactionSendInvite_ReturnType returnData)
		{
			if (returnData.members != null)
			{
				GameEngine.Instance.World.FactionMembers = returnData.members;
				this.addPlayers(GameEngine.Instance.World.FactionMembers);
			}
			if (returnData.Success)
			{
				MyMessageBox.Show(SK.Text("FactionsPanel_Invited", "Player Successfully Invited") + Environment.NewLine + Environment.NewLine + this.invitedUserName, SK.Text("FactionsPanel_Invited_Header", "Player Invited"));
				this.tbInviteName.Text = "";
				this.inviteButton.Enabled = false;
				return;
			}
			ErrorCodes.ErrorCode errorCode = returnData.m_errorCode;
			switch (errorCode)
			{
			case ErrorCodes.ErrorCode.FACTION_ALREADY_IN_FACTION:
				MyMessageBox.Show(SK.Text("FactionsPanel_Already_In_Faction", "This user is already in this faction."), SK.Text("FactionsPanel_Invite_Error", "Invite Error"));
				return;
			case ErrorCodes.ErrorCode.FACTION_INVALID_INVITE:
				break;
			case ErrorCodes.ErrorCode.FACTION_INVITE_ALREADY_EXISTS:
				MyMessageBox.Show(SK.Text("FactionsPanel_Already_Has_Invite", "This User already has an invite."), SK.Text("FactionsPanel_Invite_Error", "Invite Error"));
				return;
			case ErrorCodes.ErrorCode.FACTION_FULL:
				MyMessageBox.Show(SK.Text("FactionsPanel_Faction_Full", "The Faction is full."), SK.Text("FactionsPanel_Invite_Error", "Invite Error"));
				return;
			default:
				if (errorCode == ErrorCodes.ErrorCode.FACTION_UNKNOWN_USER)
				{
					MyMessageBox.Show(SK.Text("FactionsPanel_Unknown_User", "Unknown User"), SK.Text("FactionsPanel_Invite_Error", "Invite Error"));
					return;
				}
				if (errorCode != ErrorCodes.ErrorCode.FACTION_INVITEE_TOO_LOW)
				{
					return;
				}
				MyMessageBox.Show(SK.Text("FactionsPanel_Rank_Too_Low", "User's rank too low"), SK.Text("FactionsPanel_Invite_Error", "Invite Error"));
				break;
			}
		}

		// Token: 0x0600117D RID: 4477 RVA: 0x000131C3 File Offset: 0x000113C3
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x0600117E RID: 4478 RVA: 0x000131D3 File Offset: 0x000113D3
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x0600117F RID: 4479 RVA: 0x000131E3 File Offset: 0x000113E3
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06001180 RID: 4480 RVA: 0x000131F5 File Offset: 0x000113F5
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06001181 RID: 4481 RVA: 0x00013202 File Offset: 0x00011402
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closing();
		}

		// Token: 0x06001182 RID: 4482 RVA: 0x0001321C File Offset: 0x0001141C
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06001183 RID: 4483 RVA: 0x00013229 File Offset: 0x00011429
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06001184 RID: 4484 RVA: 0x00013236 File Offset: 0x00011436
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001185 RID: 4485 RVA: 0x0012824C File Offset: 0x0012644C
		private void InitializeComponent()
		{
			this.tbInviteName = new TextBox();
			base.SuspendLayout();
			this.tbInviteName.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.tbInviteName.Location = new Point(188, 539);
			this.tbInviteName.Name = "tbInviteName";
			this.tbInviteName.Size = new Size(245, 20);
			this.tbInviteName.TabIndex = 7;
			base.AutoScaleMode = AutoScaleMode.None;
			base.Controls.Add(this.tbInviteName);
			this.MaximumSize = new Size(992, 10000);
			this.MinimumSize = new Size(992, 566);
			base.Name = "FactionOfficersPanel";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400179B RID: 6043
		public const int PANEL_ID = 46;

		// Token: 0x0400179C RID: 6044
		public static FactionOfficersPanel instance;

		// Token: 0x0400179D RID: 6045
		private CustomSelfDrawPanel.CSDExtendingPanel backgroundImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x0400179E RID: 6046
		private CustomSelfDrawPanel.CSDFill mainBackgroundImage = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x0400179F RID: 6047
		private CustomSelfDrawPanel.CSDImage backgroundFade = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040017A0 RID: 6048
		private CustomSelfDrawPanel.CSDLabel titleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040017A1 RID: 6049
		private CustomSelfDrawPanel.CSDExtendingPanel wallInfoImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x040017A2 RID: 6050
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x040017A3 RID: 6051
		private CustomSelfDrawPanel.CSDImage divider1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040017A4 RID: 6052
		private CustomSelfDrawPanel.CSDImage divider2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040017A5 RID: 6053
		private CustomSelfDrawPanel.CSDImage divider3Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040017A6 RID: 6054
		private CustomSelfDrawPanel.CSDLabel playerNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040017A7 RID: 6055
		private CustomSelfDrawPanel.CSDLabel leadershipVoteLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040017A8 RID: 6056
		private CustomSelfDrawPanel.CSDLabel rankLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040017A9 RID: 6057
		private CustomSelfDrawPanel.CSDLabel villagesLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040017AA RID: 6058
		private CustomSelfDrawPanel.CSDLabel factionNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040017AB RID: 6059
		private CustomSelfDrawPanel.CSDLabel factionMottoLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040017AC RID: 6060
		private CustomSelfDrawPanel.CSDLabel houseLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040017AD RID: 6061
		private CustomSelfDrawPanel.CSDImage houseImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040017AE RID: 6062
		private CustomSelfDrawPanel.CSDLabel membersLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040017AF RID: 6063
		private CustomSelfDrawPanel.CSDLabel membersLabelValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040017B0 RID: 6064
		private CustomSelfDrawPanel.CSDLabel pointsHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040017B1 RID: 6065
		private CustomSelfDrawPanel.CSDLabel pointsHeaderLabelValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040017B2 RID: 6066
		private CustomSelfDrawPanel.CSDLabel rankHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040017B3 RID: 6067
		private CustomSelfDrawPanel.CSDLabel rankHeaderLabelValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040017B4 RID: 6068
		private CustomSelfDrawPanel.CSDButton inviteButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040017B5 RID: 6069
		private CustomSelfDrawPanel.CSDFactionFlagImage flagimage = new CustomSelfDrawPanel.CSDFactionFlagImage();

		// Token: 0x040017B6 RID: 6070
		private CustomSelfDrawPanel.CSDButton editButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040017B7 RID: 6071
		private CustomSelfDrawPanel.CSDVertScrollBar wallScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x040017B8 RID: 6072
		private CustomSelfDrawPanel.CSDArea wallScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040017B9 RID: 6073
		private CustomSelfDrawPanel.CSDControl mouseWheelOverlay = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x040017BA RID: 6074
		private CustomSelfDrawPanel.CSDImage backImage1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040017BB RID: 6075
		private CustomSelfDrawPanel.CSDImage backImage2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040017BC RID: 6076
		private CustomSelfDrawPanel.CSDImage barImage1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040017BD RID: 6077
		private CustomSelfDrawPanel.CSDImage barImage2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040017BE RID: 6078
		private CustomSelfDrawPanel.CSDImage barImage3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040017BF RID: 6079
		private CustomSelfDrawPanel.CSDButton applicationButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040017C0 RID: 6080
		private CustomSelfDrawPanel.CSDLabel applicationsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040017C1 RID: 6081
		private CustomSelfDrawPanel.FactionPanelSideBar sidebar = new CustomSelfDrawPanel.FactionPanelSideBar();

		// Token: 0x040017C2 RID: 6082
		private List<FactionOfficersPanel.FactionMemberLineOfficer> lineList = new List<FactionOfficersPanel.FactionMemberLineOfficer>();

		// Token: 0x040017C3 RID: 6083
		private string invitedUserName = "";

		// Token: 0x040017C4 RID: 6084
		private DockableControl dockableControl;

		// Token: 0x040017C5 RID: 6085
		private IContainer components;

		// Token: 0x040017C6 RID: 6086
		private TextBox tbInviteName;

		// Token: 0x020001D1 RID: 465
		public class FactionMemberLineOfficer : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06001186 RID: 4486 RVA: 0x00128334 File Offset: 0x00126534
			public void init(FactionMemberData factionData, int position, FactionOfficersPanel parent, bool ownFaction, int numOfficers)
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
				this.playerName.Color = global::ARGBColors.Black;
				this.playerName.Position = new Point(39, 0);
				this.playerName.Size = new Size(280, this.backgroundImage.Height);
				this.playerName.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.playerName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.playerName.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
				this.backgroundImage.addControl(this.playerName);
				if (factionData.status == -1)
				{
					this.pendingLabel.Text = SK.Text("FactionsInvites_Invite_Pending", "Invitation Pending");
					this.pendingLabel.Color = global::ARGBColors.DarkRed;
					this.pendingLabel.Position = new Point(300, 0);
					this.pendingLabel.Size = new Size(500, this.backgroundImage.Height);
					this.pendingLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
					this.pendingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
					this.pendingLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
					this.backgroundImage.addControl(this.pendingLabel);
					int yourFactionRank = GameEngine.Instance.World.getYourFactionRank();
					if ((yourFactionRank == 1 || yourFactionRank == 2) && !GameEngine.Instance.World.WorldEnded)
					{
						this.declineButton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
						this.declineButton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
						this.declineButton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
						this.declineButton.Position = new Point(525, 0);
						this.declineButton.Text.Text = SK.Text("FactionMemberLine_Cancel_Invite", "Cancel Invite");
						this.declineButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
						this.declineButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
						this.declineButton.TextYOffset = -3;
						this.declineButton.Text.Color = global::ARGBColors.Black;
						this.declineButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.declineClicked), "FactionOfficersPanel_decline");
						this.backgroundImage.addControl(this.declineButton);
					}
				}
				else if (factionData.status == -3)
				{
					this.pendingLabel.Text = SK.Text("FactionsInvites_Application", "Application");
					this.pendingLabel.Color = global::ARGBColors.DarkRed;
					this.pendingLabel.Position = new Point(270, 0);
					this.pendingLabel.Size = new Size(500, this.backgroundImage.Height);
					this.pendingLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
					this.pendingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
					this.pendingLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
					this.backgroundImage.addControl(this.pendingLabel);
					int yourFactionRank2 = GameEngine.Instance.World.getYourFactionRank();
					if ((yourFactionRank2 == 1 || yourFactionRank2 == 2) && !GameEngine.Instance.World.WorldEnded)
					{
						this.acceptButton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
						this.acceptButton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
						this.acceptButton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
						this.acceptButton.Position = new Point(370, 0);
						this.acceptButton.Text.Text = SK.Text("FactionInviteLine_Accept", "Accept");
						this.acceptButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
						this.acceptButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
						this.acceptButton.TextYOffset = -3;
						this.acceptButton.Text.Color = global::ARGBColors.Black;
						this.acceptButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.acceptAppClicked), "FactionOfficersPanel_decline");
						this.backgroundImage.addControl(this.acceptButton);
						this.declineButton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
						this.declineButton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
						this.declineButton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
						this.declineButton.Position = new Point(525, 0);
						this.declineButton.Text.Text = SK.Text("FactionInviteLine_Decline", "Decline");
						this.declineButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
						this.declineButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
						this.declineButton.TextYOffset = -3;
						this.declineButton.Text.Color = global::ARGBColors.Black;
						this.declineButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.declineAppClicked), "FactionOfficersPanel_decline");
						this.backgroundImage.addControl(this.declineButton);
					}
				}
				else
				{
					int yourFactionRank3 = GameEngine.Instance.World.getYourFactionRank();
					if (factionData.status != 1)
					{
						if (yourFactionRank3 == 1 && !GameEngine.Instance.World.WorldEnded)
						{
							this.promoteButton.ImageNorm = GFXLibrary.misc_button_blue_210wide_normal;
							this.promoteButton.ImageOver = GFXLibrary.misc_button_blue_210wide_over;
							this.promoteButton.ImageClick = GFXLibrary.misc_button_blue_210wide_pushed;
							this.promoteButton.Position = new Point(300, 0);
							this.promoteButton.Text.Text = SK.Text("FactionMemberLine_Cancel_Invite", "Cancel Invite");
							if (factionData.status == 0)
							{
								this.promoteButton.Text.Text = SK.Text("FactionMemberLine_Promote_To_Officer", "Promote To Officer");
								if (numOfficers >= GameEngine.Instance.LocalWorldData.Faction_MaxSergeants)
								{
									this.promoteButton.Enabled = false;
								}
							}
							else
							{
								this.promoteButton.Text.Text = SK.Text("FactionMemberLine_Demote_To_Commoner", "Demote To Commoner");
							}
							this.promoteButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
							this.promoteButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
							this.promoteButton.TextYOffset = -3;
							this.promoteButton.Text.Color = global::ARGBColors.Black;
							this.promoteButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.promoteClicked), "FactionOfficersPanel_promote");
							this.backgroundImage.addControl(this.promoteButton);
						}
						if (factionData.status == 0 && !GameEngine.Instance.World.WorldEnded)
						{
							this.dismissButton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
							this.dismissButton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
							this.dismissButton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
							this.dismissButton.Position = new Point(525, 0);
							this.dismissButton.Text.Text = SK.Text("FactionMemberLine_Dismiss", "Dismiss");
							this.dismissButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
							this.dismissButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
							this.dismissButton.TextYOffset = -3;
							this.dismissButton.Text.Color = global::ARGBColors.Black;
							this.dismissButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.dismissMember), "FactionOfficersPanel_dismiss");
							this.backgroundImage.addControl(this.dismissButton);
						}
					}
					if ((factionData.status == 1 || factionData.status == 2) && !GameEngine.Instance.World.WorldEnded)
					{
						this.voteCheck.CheckedImage = GFXLibrary.checkbox_checked;
						this.voteCheck.UncheckedImage = GFXLibrary.checkbox_unchecked;
						this.voteCheck.Position = new Point(585, 5);
						if (factionData.userID == GameEngine.Instance.World.YourFactionVote || (GameEngine.Instance.World.YourFactionVote == -1 && factionData.status == 1))
						{
							this.voteCheck.Checked = true;
						}
						else
						{
							this.voteCheck.Checked = false;
							this.voteCheck.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.checkToggled));
						}
						this.backgroundImage.addControl(this.voteCheck);
					}
				}
				base.invalidate();
			}

			// Token: 0x06001187 RID: 4487 RVA: 0x00007CE0 File Offset: 0x00005EE0
			public void update()
			{
			}

			// Token: 0x06001188 RID: 4488 RVA: 0x00128D64 File Offset: 0x00126F64
			public void clickedLine()
			{
				GameEngine.Instance.playInterfaceSound("FactionOfficersPanel_user_clicked");
				WorldMap.CachedUserInfo cachedUserInfo = new WorldMap.CachedUserInfo();
				cachedUserInfo.userID = this.m_factionMemberData.userID;
				InterfaceMgr.Instance.showUserInfoScreen(cachedUserInfo);
			}

			// Token: 0x06001189 RID: 4489 RVA: 0x00013255 File Offset: 0x00011455
			public void checkToggled()
			{
				if (this.voteCheck.Checked)
				{
					this.voteLeaderChange(this.m_factionMemberData.userID);
				}
			}

			// Token: 0x0600118A RID: 4490 RVA: 0x00013275 File Offset: 0x00011475
			private void voteLeaderChange(int userID)
			{
				RemoteServices.Instance.set_FactionLeadershipVote_UserCallBack(new RemoteServices.FactionLeadershipVote_UserCallBack(this.factionLeadershipVoteCallback));
				RemoteServices.Instance.FactionLeadershipVote(RemoteServices.Instance.UserFactionID, userID);
			}

			// Token: 0x0600118B RID: 4491 RVA: 0x00128DA4 File Offset: 0x00126FA4
			public void factionLeadershipVoteCallback(FactionLeadershipVote_ReturnType returnData)
			{
				if (returnData.Success)
				{
					GameEngine.Instance.World.YourFactionVote = returnData.yourLeaderVote;
					if (returnData.leaderChanged)
					{
						RemoteServices.Instance.UserFactionID = returnData.yourFaction.factionID;
						GameEngine.Instance.World.YourFaction = returnData.yourFaction;
						GameEngine.Instance.World.FactionMembers = returnData.members;
						GameEngine.Instance.World.FactionInvites = returnData.invites;
						GameEngine.Instance.World.FactionApplications = returnData.applications;
					}
					this.m_parent.init(false);
				}
			}

			// Token: 0x0600118C RID: 4492 RVA: 0x000132A2 File Offset: 0x000114A2
			public void promoteClicked()
			{
				this.promoteButton.Enabled = false;
				if (this.m_factionMemberData.status == 0)
				{
					this.changeRank(2);
					return;
				}
				this.changeRank(0);
			}

			// Token: 0x0600118D RID: 4493 RVA: 0x000132CC File Offset: 0x000114CC
			public void changeRank(int rank)
			{
				RemoteServices.Instance.set_FactionChangeMemberStatus_UserCallBack(new RemoteServices.FactionChangeMemberStatus_UserCallBack(this.factionChangeMemberStatusCallback));
				RemoteServices.Instance.FactionChangeMemberStatus(this.m_factionMemberData.userID, rank);
			}

			// Token: 0x0600118E RID: 4494 RVA: 0x000132FA File Offset: 0x000114FA
			public void dismissMember()
			{
				this.dismissButton.Enabled = false;
				RemoteServices.Instance.set_FactionChangeMemberStatus_UserCallBack(new RemoteServices.FactionChangeMemberStatus_UserCallBack(this.factionChangeMemberStatusCallback));
				RemoteServices.Instance.FactionChangeMemberStatus(this.m_factionMemberData.userID, -2);
			}

			// Token: 0x0600118F RID: 4495 RVA: 0x00128E50 File Offset: 0x00127050
			public void factionChangeMemberStatusCallback(FactionChangeMemberStatus_ReturnType returnData)
			{
				if (returnData.Success)
				{
					GameEngine.Instance.World.FactionMembers = returnData.members;
					GameEngine.Instance.World.YourFaction = returnData.yourFaction;
					this.m_parent.init(false);
					return;
				}
				this.promoteButton.Enabled = true;
				this.dismissButton.Enabled = true;
			}

			// Token: 0x06001190 RID: 4496 RVA: 0x00013335 File Offset: 0x00011535
			public void declineClicked()
			{
				this.declineButton.Enabled = false;
				RemoteServices.Instance.set_FactionWithdrawInvite_UserCallBack(new RemoteServices.FactionWithdrawInvite_UserCallBack(this.factionWithdrawInviteCallback));
				RemoteServices.Instance.FactionWithdrawInvite(this.m_factionMemberData.userID);
			}

			// Token: 0x06001191 RID: 4497 RVA: 0x0001336E File Offset: 0x0001156E
			public void factionWithdrawInviteCallback(FactionWithdrawInvite_ReturnType returnData)
			{
				this.declineButton.Enabled = true;
				if (returnData.members != null)
				{
					GameEngine.Instance.World.FactionMembers = returnData.members;
					this.m_parent.init(false);
				}
			}

			// Token: 0x06001192 RID: 4498 RVA: 0x000133A5 File Offset: 0x000115A5
			public void declineAppClicked()
			{
				this.declineButton.Enabled = false;
				RemoteServices.Instance.set_FactionApplicationProcessing_UserCallBack(new RemoteServices.FactionApplicationProcessing_UserCallBack(this.factionApplicationProcessingCallback));
				RemoteServices.Instance.FactionApplicationReject(this.m_factionMemberData.userID);
			}

			// Token: 0x06001193 RID: 4499 RVA: 0x000133DE File Offset: 0x000115DE
			public void acceptAppClicked()
			{
				this.declineButton.Enabled = false;
				RemoteServices.Instance.set_FactionApplicationProcessing_UserCallBack(new RemoteServices.FactionApplicationProcessing_UserCallBack(this.factionApplicationProcessingCallback));
				RemoteServices.Instance.FactionApplicationAccept(this.m_factionMemberData.userID);
			}

			// Token: 0x06001194 RID: 4500 RVA: 0x00128EB4 File Offset: 0x001270B4
			public void factionApplicationProcessingCallback(FactionApplicationProcessing_ReturnType returnData)
			{
				if (returnData.m_errorCode == ErrorCodes.ErrorCode.FACTION_FULL)
				{
					MyMessageBox.Show(SK.Text("FactionsPanel_Faction_Full", "The Faction is full."), SK.Text("GENERIC_Error", "Error"));
				}
				this.declineButton.Enabled = true;
				if (returnData.members != null)
				{
					GameEngine.Instance.World.FactionMembers = returnData.members;
					GameEngine.Instance.World.YourFaction = returnData.yourFaction;
					this.m_parent.init(false);
				}
			}

			// Token: 0x040017C7 RID: 6087
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040017C8 RID: 6088
			private CustomSelfDrawPanel.CSDImage officerImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040017C9 RID: 6089
			private CustomSelfDrawPanel.CSDLabel playerName = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040017CA RID: 6090
			private CustomSelfDrawPanel.CSDButton promoteButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040017CB RID: 6091
			private CustomSelfDrawPanel.CSDButton dismissButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040017CC RID: 6092
			private CustomSelfDrawPanel.CSDCheckBox voteCheck = new CustomSelfDrawPanel.CSDCheckBox();

			// Token: 0x040017CD RID: 6093
			private CustomSelfDrawPanel.CSDLabel pendingLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040017CE RID: 6094
			private CustomSelfDrawPanel.CSDButton acceptButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040017CF RID: 6095
			private CustomSelfDrawPanel.CSDButton declineButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040017D0 RID: 6096
			private int m_position = -1000;

			// Token: 0x040017D1 RID: 6097
			private FactionMemberData m_factionMemberData;

			// Token: 0x040017D2 RID: 6098
			private FactionOfficersPanel m_parent;
		}
	}
}
