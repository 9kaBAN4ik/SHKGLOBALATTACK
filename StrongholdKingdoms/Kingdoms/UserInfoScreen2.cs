using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CommonTypes;
using StatTracking;

namespace Kingdoms
{
	// Token: 0x020004B3 RID: 1203
	public class UserInfoScreen2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06002C52 RID: 11346 RVA: 0x00233A94 File Offset: 0x00231C94
		public UserInfoScreen2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06002C53 RID: 11347 RVA: 0x00233D00 File Offset: 0x00231F00
		public void init(WorldMap.CachedUserInfo userInfo)
		{
			base.clearControls();
			NumberFormatInfo nfi = GameEngine.NFI;
			this.m_houseID = 0;
			if (userInfo == null)
			{
				userInfo = new WorldMap.CachedUserInfo();
				userInfo.userID = this.m_userID;
			}
			this.m_userID = userInfo.userID;
			WorldMap.VillageRolloverInfo villageRolloverInfo = null;
			GameEngine.Instance.World.retrieveUserData(-1, userInfo.userID, ref villageRolloverInfo, ref userInfo, true, true);
			this.m_userInfo = userInfo;
			this.mainBackgroundImage.Size = new Size(base.Width, base.Height - 40);
			this.mainBackgroundImage.Position = new Point(0, 40);
			base.addControl(this.mainBackgroundImage);
			this.mainBackgroundImage.Create(GFXLibrary.mail2_mail_panel_upper_left, GFXLibrary.mail2_mail_panel_upper_middle, GFXLibrary.mail2_mail_panel_upper_right, GFXLibrary.mail2_mail_panel_middle_left, GFXLibrary.mail2_mail_panel_middle_middle, GFXLibrary.mail2_mail_panel_middle_right, GFXLibrary.mail2_mail_panel_lower_left, GFXLibrary.mail2_mail_panel_lower_middle, GFXLibrary.mail2_mail_panel_lower_right);
			this.mainHeaderArea.Position = new Point(0, -40);
			this.mainHeaderArea.Size = new Size(992, 45);
			this.mainBackgroundImage.addControl(this.mainHeaderArea);
			this.headerImage.Size = new Size(base.Width, 40);
			this.headerImage.Position = new Point(0, 0);
			this.mainHeaderArea.addControl(this.headerImage);
			this.headerImage.Create(GFXLibrary.mail2_titlebar_left, GFXLibrary.mail2_titlebar_middle, GFXLibrary.mail2_titlebar_right);
			this.positionImage.Image = GFXLibrary.char_position[0];
			this.positionImage.Position = new Point(9, 7);
			this.positionImage.Visible = false;
			this.mainHeaderArea.addControl(this.positionImage);
			if (userInfo != null)
			{
				this.headerLabel.Text = userInfo.userName;
			}
			else
			{
				this.headerLabel.Text = "";
			}
			this.headerLabel.Color = global::ARGBColors.White;
			this.headerLabel.DropShadowColor = global::ARGBColors.Black;
			this.headerLabel.Position = new Point(39, 10);
			this.headerLabel.Size = new Size(500, 50);
			this.headerLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.headerLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainHeaderArea.addControl(this.headerLabel);
			Size textSizeX = this.headerLabel.TextSizeX;
			this.headerLabel2.Text = "";
			this.headerLabel2.Color = Color.FromArgb(173, 195, 208);
			this.headerLabel2.DropShadowColor = global::ARGBColors.Black;
			this.headerLabel2.Position = new Point(this.headerLabel.Position.X + textSizeX.Width + 5, 12);
			this.headerLabel2.Size = new Size(700, 28);
			this.headerLabel2.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.headerLabel2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainHeaderArea.addControl(this.headerLabel2);
			if (userInfo != null && userInfo.standing >= 0)
			{
				this.standingLabelLabel.Text = SK.Text("STATS_CATEGORY_TITLE_RANK", "Rank") + " : " + userInfo.standing.ToString("N", nfi);
			}
			else
			{
				this.standingLabelLabel.Text = "";
			}
			this.standingLabelLabel.Color = Color.FromArgb(173, 195, 208);
			this.standingLabelLabel.DropShadowColor = global::ARGBColors.Black;
			this.standingLabelLabel.Position = new Point(650, 12);
			this.standingLabelLabel.Size = new Size(700, 28);
			this.standingLabelLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.standingLabelLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainHeaderArea.addControl(this.standingLabelLabel);
			if (userInfo != null)
			{
				this.pointsLabel.Text = SK.Text("GENERIC_Points", "Points") + " : " + userInfo.points.ToString("N", nfi);
			}
			else
			{
				this.pointsLabel.Text = "";
			}
			this.pointsLabel.Color = Color.FromArgb(173, 195, 208);
			this.pointsLabel.DropShadowColor = global::ARGBColors.Black;
			this.pointsLabel.Position = new Point(775, 12);
			this.pointsLabel.Size = new Size(700, 28);
			this.pointsLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.pointsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainHeaderArea.addControl(this.pointsLabel);
			this.closeButton.ImageNorm = GFXLibrary.int_button_close_normal;
			this.closeButton.ImageOver = GFXLibrary.int_button_close_over;
			this.closeButton.ImageClick = GFXLibrary.int_button_close_in;
			this.closeButton.Position = new Point(948, 4);
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "UserInfo2_close");
			this.closeButton.CustomTooltipID = 502;
			this.mainHeaderArea.addControl(this.closeButton);
			if (userInfo != null && userInfo.avatarData != null)
			{
				this.backgroundLeft.Image = GFXLibrary.char_portraite_shadow;
				this.backgroundLeft.Position = new Point(5, 0);
				this.mainBackgroundImage.addControl(this.backgroundLeft);
			}
			this.backgroundRight.Image = GFXLibrary.char_villagelist_inset;
			this.backgroundRight.Position = new Point(base.Width - 7 - GFXLibrary.char_villagelist_inset.Width, 1);
			this.mainBackgroundImage.addControl(this.backgroundRight);
			this.backgroundCentre.Image = GFXLibrary.char_shieldcomp_back;
			this.backgroundCentre.Position = new Point(299, 1);
			this.mainBackgroundImage.addControl(this.backgroundCentre);
			if (userInfo != null)
			{
				this.nameLabel.Text = userInfo.userName;
				this.nameLabel.Color = global::ARGBColors.Black;
				this.nameLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				this.nameLabel.Position = new Point(11, 30);
				this.nameLabel.Size = new Size(180, 45);
				this.nameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.backgroundCentre.addControl(this.nameLabel);
				if (userInfo.avatarData != null)
				{
					this.rankLabel.TextDiffOnly = Rankings.getRankingName(userInfo.rank, userInfo.avatarData.male);
				}
				else
				{
					this.rankLabel.TextDiffOnly = Rankings.getRankingName(userInfo.rank);
				}
				this.rankLabel.Color = global::ARGBColors.Black;
				this.rankLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.rankLabel.Position = new Point(11, 61);
				this.rankLabel.Size = new Size(180, 20);
				this.rankLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.backgroundCentre.addControl(this.rankLabel);
				if (userInfo.avatarData != null)
				{
					if (UserInfoScreen2.lastCreatedAvatar != null)
					{
						UserInfoScreen2.lastCreatedAvatar.Dispose();
					}
					UserInfoScreen2.lastCreatedAvatar = (this.avatarImage.Image = Avatar.CreateAvatar(userInfo.avatarData, global::ARGBColors.Transparent));
					this.avatarImage.Position = new Point(73, 22);
					this.mainBackgroundImage.addControl(this.avatarImage);
				}
				this.shieldImage.Image = GameEngine.Instance.World.getWorldShieldOrBlank(userInfo.userID, 140, 156);
				if (this.shieldImage.Image != null)
				{
					this.shieldImage.Position = new Point(24, 102);
					if (userInfo.userID == RemoteServices.Instance.UserID)
					{
						this.shieldImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.editClicked), "UserInfo2_edit_shield_shield_clicked");
						this.shieldImage.CustomTooltipID = 4015;
					}
					else
					{
						this.shieldImage.setClickDelegate(null);
						this.shieldImage.CustomTooltipID = 0;
					}
					this.backgroundCentre.addControl(this.shieldImage);
				}
				if (userInfo.factionID >= 0)
				{
					FactionData faction = GameEngine.Instance.World.getFaction(userInfo.factionID);
					if (faction != null)
					{
						this.flagImageShadow.Image = GFXLibrary.char_shadow_faction;
						this.flagImageShadow.Position = new Point(130, 259);
						this.backgroundCentre.addControl(this.flagImageShadow);
						this.flagImage.createFromFlagData(faction.flagData);
						this.flagImage.CustomTooltipData = faction.factionID;
						this.flagImage.Position = new Point(128, 257);
						this.flagImage.Scale = 0.25;
						this.flagImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.factionClicked), "UserInfoPanel2_faction_flag");
						this.flagImage.CustomTooltipID = 2501;
						this.backgroundCentre.addControl(this.flagImage);
						this.factionLabel.Text = faction.factionNameAbrv;
						this.factionLabel.Color = global::ARGBColors.Black;
						this.factionLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
						this.factionLabel.Position = new Point(11, 311);
						this.factionLabel.Size = new Size(180, 20);
						this.factionLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
						this.factionLabel.CustomTooltipID = 2501;
						this.factionLabel.CustomTooltipData = faction.factionID;
						this.factionLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.factionClicked), "UserInfoPanel2_faction_flag");
						this.backgroundCentre.addControl(this.factionLabel);
						if (faction.houseID > 0)
						{
							this.houseImageShadow.Image = GFXLibrary.char_shadow_house;
							this.houseImageShadow.Position = new Point(10, 247);
							this.backgroundCentre.addControl(this.houseImageShadow);
							Image image = this.houseImage.Image = (this.houseImage.Image = GFXLibrary.house_circles_medium[faction.houseID - 1]);
							this.houseImage.CustomTooltipData = faction.houseID;
							this.houseImage.Position = new Point(10, 247);
							this.houseImage.CustomTooltipID = 2307;
							this.houseImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.houseClicked), "UserInfoPanel2_house");
							this.backgroundCentre.addControl(this.houseImage);
							this.houseLabel.Text = SK.Text("STATS_CATEGORY_TITLE_HOUSE", "House") + " " + faction.houseID.ToString();
							this.houseLabel.Color = global::ARGBColors.Black;
							this.houseLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
							this.houseLabel.Position = new Point(11, 285);
							this.houseLabel.Size = new Size(180, 20);
							this.houseLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
							this.houseLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.houseClicked), "UserInfoPanel2_house");
							this.backgroundCentre.addControl(this.houseLabel);
							this.m_houseID = faction.houseID;
						}
					}
				}
				int yourFactionRank = GameEngine.Instance.World.getYourFactionRank();
				FactionData yourFaction = GameEngine.Instance.World.YourFaction;
				if (yourFaction != null && userInfo != null && userInfo.userID != RemoteServices.Instance.UserID)
				{
					FactionMemberData[] factionMembers = GameEngine.Instance.World.FactionMembers;
					if (factionMembers != null && yourFactionRank > 0)
					{
						this.inviteButton.ImageNorm = GFXLibrary.char_but_invite[0];
						this.inviteButton.ImageOver = GFXLibrary.char_but_invite[1];
						this.inviteButton.Position = new Point(62, 346);
						this.inviteButton.MoveOnClick = true;
						this.inviteButton.Text.Text = SK.Text("UserInfoScreen_InviteToFaction", "Invite To Faction");
						this.inviteButton.Text.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
						this.inviteButton.Text.Position = new Point(3, 26);
						this.inviteButton.Text.Size = new Size(70, 27);
						this.inviteButton.TextYOffset = 0;
						this.inviteButton.Text.Color = global::ARGBColors.Black;
						this.inviteButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.inviteToFactionClicked), "UserInfoPanel2_invite_to_faction_clicked");
						this.backgroundCentre.addControl(this.inviteButton);
					}
				}
				this.mailButton.ImageNorm = GFXLibrary.char_but_mail[0];
				this.mailButton.ImageOver = GFXLibrary.char_but_mail[1];
				this.mailButton.Position = new Point(62, 417);
				this.mailButton.MoveOnClick = true;
				this.mailButton.Text.Text = SK.Text("User_Send_A_Message", "Send a Message");
				this.mailButton.Text.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
				this.mailButton.Text.Position = new Point(3, 26);
				this.mailButton.Text.Size = new Size(70, 27);
				this.mailButton.TextYOffset = 0;
				this.mailButton.Text.Color = global::ARGBColors.Black;
				this.mailButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sendMailClicked), "UserInfoPanel2_send_mail_clicked");
				this.backgroundCentre.addControl(this.mailButton);
				if (GameEngine.Instance.LocalWorldData.IsHereticEUAIWorld && userInfo.userID <= 4)
				{
					this.mailButton.Visible = false;
				}
				else
				{
					this.mailButton.Visible = true;
				}
				this.diplomacyButton.ImageNorm = GFXLibrary.misc_button_blue_210wide_normal;
				this.diplomacyButton.ImageOver = GFXLibrary.misc_button_blue_210wide_over;
				this.diplomacyButton.ImageClick = GFXLibrary.misc_button_blue_210wide_pushed;
				this.diplomacyButton.Position = new Point(635, 509);
				if (userInfo.userID == RemoteServices.Instance.UserID)
				{
					this.diplomacyButton.Text.Text = SK.Text("User_Manage_Relations", "Manage Diplomacy");
					this.diplomacyButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.manageDiplomacyClicked), "FactionMyFactionPanel_diplomacy");
				}
				else
				{
					string text = SK.Text("AllArmiesPanel_Diplomacy", "Diplomacy") + " : ";
					int userRelationship = GameEngine.Instance.World.getUserRelationship(userInfo.userID);
					if (userRelationship == 0)
					{
						text += SK.Text("GENERIC_Neutral", "Neutral");
					}
					else if (userRelationship > 0)
					{
						text += SK.Text("GENERIC_Ally", "Ally");
					}
					else if (userRelationship < 0)
					{
						text += SK.Text("GENERIC_Enemy", "Enemy");
					}
					this.diplomacyButton.Text.Text = text;
					this.diplomacyButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.addDiplomacyOverlay), "FactionMyFactionPanel_diplomacy");
				}
				this.diplomacyButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.diplomacyButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.diplomacyButton.TextYOffset = -3;
				this.diplomacyButton.Text.Color = global::ARGBColors.Black;
				this.mainBackgroundImage.addControl(this.diplomacyButton);
			}
			if (RemoteServices.Instance.Admin || RemoteServices.Instance.Moderator)
			{
				this.adminButton.ImageNorm = GFXLibrary.int_button_close_normal;
				this.adminButton.ImageOver = GFXLibrary.int_button_close_over;
				this.adminButton.ImageClick = GFXLibrary.int_button_close_in;
				this.adminButton.Position = new Point(72, 481);
				this.adminButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.adminClick));
				this.adminButton.CustomTooltipID = 3101;
				this.backgroundCentre.addControl(this.adminButton);
			}
			if (userInfo != null && this.m_userInfo.userID == RemoteServices.Instance.UserID)
			{
				this.editButton.ImageNorm = GFXLibrary.mrhp_button_more_info;
				this.editButton.ImageOver = GFXLibrary.mrhp_button_more_info_over;
				this.editButton.MoveOnClick = true;
				this.editButton.Position = new Point(57, 79);
				this.editButton.Text.Text = SK.Text("User_Edit", "Edit");
				this.editButton.Text.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
				this.editButton.TextYOffset = -3;
				this.editButton.Text.Color = Color.FromArgb(233, 231, 213);
				this.editButton.Text.Position = new Point(-3, 0);
				this.editButton.Text.DropShadowColor = global::ARGBColors.Black;
				this.editButton.CustomTooltipID = 4015;
				this.editButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.editClicked), "UserInfo2_edit_shield_button_clicked");
				this.backgroundCentre.addControl(this.editButton);
				this.editAvatarButton.ImageNorm = GFXLibrary.mrhp_button_more_info;
				this.editAvatarButton.ImageOver = GFXLibrary.mrhp_button_more_info_over;
				this.editAvatarButton.MoveOnClick = true;
				this.editAvatarButton.Position = new Point(106, 499);
				this.editAvatarButton.Text.Text = SK.Text("User_Edit", "Edit");
				this.editAvatarButton.Text.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
				this.editAvatarButton.TextYOffset = -3;
				this.editAvatarButton.Text.Color = Color.FromArgb(233, 231, 213);
				this.editAvatarButton.Text.Position = new Point(-3, 0);
				this.editAvatarButton.Text.DropShadowColor = global::ARGBColors.Black;
				this.editAvatarButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.editAvatarClicked), "UserInfo2_edit_avatar_clicked");
				this.mainBackgroundImage.addControl(this.editAvatarButton);
			}
			this.achievementsButton.ImageNorm = GFXLibrary.char_but_achievement[0];
			this.achievementsButton.ImageOver = GFXLibrary.char_but_achievement[1];
			this.achievementsButton.ImageClick = GFXLibrary.char_but_achievement[2];
			this.achievementsButton.Position = new Point(584, 11);
			this.achievementsButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.achievementsClicked));
			this.mainBackgroundImage.addControl(this.achievementsButton);
			if (userInfo != null && userInfo.achievements != null)
			{
				this.achievementsLabel.Text = SK.Text("GENERIC_Achievements", "Achievements") + " : " + userInfo.achievements.Count.ToString("N", nfi);
			}
			else
			{
				this.achievementsLabel.Text = "";
			}
			this.achievementsLabel.Color = global::ARGBColors.White;
			this.achievementsLabel.DropShadowColor = global::ARGBColors.Black;
			this.achievementsLabel.Position = new Point(624, 17);
			this.achievementsLabel.Size = new Size(300, 28);
			this.achievementsLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.achievementsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainBackgroundImage.addControl(this.achievementsLabel);
			this.questsButton.ImageNorm = GFXLibrary.char_but_quest[0];
			this.questsButton.ImageOver = GFXLibrary.char_but_quest[1];
			this.questsButton.ImageClick = GFXLibrary.char_but_quest[2];
			if (userInfo == null || userInfo.completedQuests == null)
			{
				this.questsButton.ImageOver = GFXLibrary.char_but_quest[0];
				this.questsButton.ImageClick = GFXLibrary.char_but_quest[0];
				this.questsButton.setClickDelegate(null);
			}
			else
			{
				this.questsButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.questsClicked), "UserInfo2_quests_clicked");
			}
			this.questsButton.Position = new Point(584, 48);
			this.mainBackgroundImage.addControl(this.questsButton);
			if (userInfo != null)
			{
				this.questsLabel.Text = SK.Text("User_Quests_Complete", "Quests Completed") + " : " + userInfo.numQuests.ToString("N", nfi);
			}
			else
			{
				this.questsLabel.Text = "";
			}
			this.questsLabel.Color = global::ARGBColors.White;
			this.questsLabel.DropShadowColor = global::ARGBColors.Black;
			this.questsLabel.Position = new Point(624, 54);
			this.questsLabel.Size = new Size(300, 28);
			this.questsLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.questsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainBackgroundImage.addControl(this.questsLabel);
			this.headerLabelsImage.Size = new Size(400, 28);
			this.headerLabelsImage.Position = new Point(89, 98);
			this.backgroundRight.addControl(this.headerLabelsImage);
			this.headerLabelsImage.Create(GFXLibrary.mail2_field_bar_mail_left, GFXLibrary.mail2_field_bar_mail_middle, GFXLibrary.mail2_field_bar_mail_right);
			this.divider1Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
			this.divider1Image.Position = new Point(218, 0);
			this.headerLabelsImage.addControl(this.divider1Image);
			this.villageLabel.Text = SK.Text("GENERIC_Village", "Village");
			this.villageLabel.Color = global::ARGBColors.Black;
			this.villageLabel.Position = new Point(20, -3);
			this.villageLabel.Size = new Size(208, this.headerLabelsImage.Height);
			this.villageLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.villageLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.villageLabel);
			this.regionLabel.Text = SK.Text("Users_Region", "Region");
			this.regionLabel.Color = global::ARGBColors.Black;
			this.regionLabel.Position = new Point(222, -3);
			this.regionLabel.Size = new Size(223, this.headerLabelsImage.Height);
			this.regionLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.regionLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.regionLabel);
			if (userInfo != null && userInfo.villages != null)
			{
				this.addVillages(userInfo.villages);
			}
			base.Invalidate();
		}

		// Token: 0x06002C54 RID: 11348 RVA: 0x002355C8 File Offset: 0x002337C8
		public void update()
		{
			WorldMap.CachedUserInfo storedUserInfo = GameEngine.Instance.World.getStoredUserInfo(this.m_userID);
			if (this.m_userInfo != storedUserInfo)
			{
				this.init(storedUserInfo);
			}
		}

		// Token: 0x06002C55 RID: 11349 RVA: 0x002355FC File Offset: 0x002337FC
		private void addVillages(int[] villages)
		{
			int num = 0;
			int villageID = -1;
			this.outgoingScrollArea.Position = new Point(98, 133);
			this.outgoingScrollArea.Size = new Size(360, 360);
			this.outgoingScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(360, 360));
			this.backgroundRight.addControl(this.outgoingScrollArea);
			int value = this.outgoingScrollBar.Value;
			this.outgoingScrollBar.Position = new Point(463, 133);
			this.outgoingScrollBar.Size = new Size(24, 360);
			this.backgroundRight.addControl(this.outgoingScrollBar);
			this.outgoingScrollBar.Value = 0;
			this.outgoingScrollBar.Max = 100;
			this.outgoingScrollBar.NumVisibleLines = 25;
			this.outgoingScrollBar.Create(null, null, null, GFXLibrary._24wide_thumb_top, GFXLibrary._24wide_thumb_middle, GFXLibrary._24wide_thumb_bottom);
			this.outgoingScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.wallScrollBarMoved));
			List<int> list = new List<int>(villages);
			list.Sort(UserInfoScreen2.villageComparer);
			this.outgoingScrollArea.clearControls();
			int num2 = 0;
			for (int i = 0; i < list.Count; i++)
			{
				int num3 = list[i];
				UserInfoScreen2.VillageLine villageLine = new UserInfoScreen2.VillageLine();
				if (num2 != 0)
				{
					num2 += 5;
				}
				villageLine.Position = new Point(0, num2);
				villageLine.init(num3, this, i);
				this.outgoingScrollArea.addControl(villageLine);
				num2 += villageLine.Height;
				this.lineList.Add(villageLine);
				VillageData villageData = GameEngine.Instance.World.getVillageData(num3);
				if (villageData != null && villageData.Capital)
				{
					int num4 = 0;
					if (villageData.regionCapital)
					{
						num4 = 1;
					}
					if (villageData.countyCapital)
					{
						num4 = 2;
					}
					if (villageData.provinceCapital)
					{
						num4 = 3;
					}
					if (villageData.countryCapital)
					{
						num4 = 4;
					}
					if (num4 > num)
					{
						num = num4;
						villageID = num3;
					}
				}
			}
			this.outgoingScrollArea.Size = new Size(this.outgoingScrollArea.Width, num2);
			if (num2 < this.outgoingScrollBar.Height)
			{
				this.outgoingScrollBar.Visible = false;
			}
			else
			{
				this.outgoingScrollBar.Visible = true;
				this.outgoingScrollBar.NumVisibleLines = this.outgoingScrollBar.Height;
				this.outgoingScrollBar.Max = num2 - this.outgoingScrollBar.Height;
			}
			this.outgoingScrollArea.invalidate();
			this.outgoingScrollBar.invalidate();
			if (num > 0)
			{
				this.positionImage.Image = GFXLibrary.char_position[num - 1];
				this.positionImage.Visible = true;
				string text = "";
				switch (num)
				{
				case 1:
					text = SK.Text("ParishWallPanel_Steward", "Steward") + " - " + GameEngine.Instance.World.getVillageName(villageID);
					break;
				case 2:
					text = SK.Text("ParishWallPanel_Sheriff", "Sheriff") + " - " + GameEngine.Instance.World.getCountyName(GameEngine.Instance.World.getCountyFromVillageID(villageID));
					break;
				case 3:
					text = SK.Text("ParishWallPanel_Governor", "Governor") + " - " + GameEngine.Instance.World.getProvinceName(GameEngine.Instance.World.getProvinceFromVillageID(villageID));
					break;
				case 4:
					text = SK.Text("ParishWallPanel_King", "King") + " - " + GameEngine.Instance.World.getCountryName(GameEngine.Instance.World.getCountryFromVillageID(villageID));
					break;
				}
				this.headerLabel2.Text = text;
			}
		}

		// Token: 0x06002C56 RID: 11350 RVA: 0x002359E4 File Offset: 0x00233BE4
		private void wallScrollBarMoved()
		{
			int value = this.outgoingScrollBar.Value;
			this.outgoingScrollArea.Position = new Point(this.outgoingScrollArea.X, 133 - value);
			this.outgoingScrollArea.ClipRect = new Rectangle(this.outgoingScrollArea.ClipRect.X, value, this.outgoingScrollArea.ClipRect.Width, this.outgoingScrollArea.ClipRect.Height);
			this.outgoingScrollArea.invalidate();
			this.outgoingScrollBar.invalidate();
		}

		// Token: 0x06002C57 RID: 11351 RVA: 0x000208C7 File Offset: 0x0001EAC7
		private void closeClick()
		{
			GameEngine.Instance.playInterfaceSound("UserInfoScreen_close");
			GameEngine.Instance.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_WORLD;
			InterfaceMgr.Instance.closeParishPanel();
			InterfaceMgr.Instance.getMainTabBar().changeTab(0);
		}

		// Token: 0x06002C58 RID: 11352 RVA: 0x00235A80 File Offset: 0x00233C80
		private void adminClick()
		{
			if (this.m_userInfo != null)
			{
				GameEngine.Instance.playInterfaceSound("UserInfoScreen_close");
				GameEngine.Instance.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_WORLD;
				InterfaceMgr.Instance.closeParishPanel();
				InterfaceMgr.Instance.getMainTabBar().changeTab(0);
				InterfaceMgr.Instance.showUserInfoScreenAdmin(this.m_userInfo);
			}
		}

		// Token: 0x06002C59 RID: 11353 RVA: 0x001C98D0 File Offset: 0x001C7AD0
		private void editClicked()
		{
			Process.Start(string.Concat(new string[]
			{
				URLs.shieldDesignerURL,
				"?webtoken=",
				RemoteServices.Instance.WebToken,
				"&lang=",
				Program.mySettings.LanguageIdent.ToLower()
			}));
		}

		// Token: 0x06002C5A RID: 11354 RVA: 0x00020809 File Offset: 0x0001EA09
		private void editAvatarClicked()
		{
			GameEngine.Instance.playInterfaceSound("UserInfoScreen_edit_avatar");
			InterfaceMgr.Instance.getMainTabBar().selectDummyTab(10);
		}

		// Token: 0x06002C5B RID: 11355 RVA: 0x0022EA2C File Offset: 0x0022CC2C
		public static int getInt32FromString(string text)
		{
			if (text.Length == 0)
			{
				return 0;
			}
			try
			{
				return Convert.ToInt32(text);
			}
			catch (Exception)
			{
			}
			return 0;
		}

		// Token: 0x06002C5C RID: 11356 RVA: 0x000208FD File Offset: 0x0001EAFD
		public void inviteToFactionClicked()
		{
			GameEngine.Instance.playInterfaceSound("UserInfoScreen_faction_invite");
			InterfaceMgr.Instance.clearControls();
			if (this.m_userInfo != null)
			{
				InterfaceMgr.Instance.inviteToFaction(this.m_userInfo.userName);
			}
		}

		// Token: 0x06002C5D RID: 11357 RVA: 0x00020935 File Offset: 0x0001EB35
		private void achievementsClicked()
		{
			GameEngine.Instance.playInterfaceSound("UserInfoScreen_achievements");
			if (this.m_userInfo != null)
			{
				InterfaceMgr.Instance.openAchievements(this.m_userInfo.achievements);
			}
		}

		// Token: 0x06002C5E RID: 11358 RVA: 0x00020963 File Offset: 0x0001EB63
		private void questsClicked()
		{
			if (this.m_userInfo != null)
			{
				InterfaceMgr.Instance.openNewQuestsCompletedPopup(this.m_userInfo.completedQuests);
			}
		}

		// Token: 0x06002C5F RID: 11359 RVA: 0x00235ADC File Offset: 0x00233CDC
		private void sendMailClicked()
		{
			GameEngine.Instance.playInterfaceSound("UserInfoScreen_send_mail");
			if (this.m_userInfo != null)
			{
				InterfaceMgr.Instance.getMainTabBar().selectDummyTab(21);
				InterfaceMgr.Instance.mailTo(this.m_userInfo.userID, this.m_userInfo.userName);
			}
		}

		// Token: 0x06002C60 RID: 11360 RVA: 0x00235B34 File Offset: 0x00233D34
		private void factionClicked()
		{
			if (this.m_userInfo != null && this.m_userInfo.factionID >= 0)
			{
				GameEngine.Instance.playInterfaceSound("UserInfoScreen_faction");
				InterfaceMgr.Instance.closeParishPanel();
				InterfaceMgr.Instance.showFactionPanel(this.m_userInfo.factionID);
			}
		}

		// Token: 0x06002C61 RID: 11361 RVA: 0x00020982 File Offset: 0x0001EB82
		private void houseClicked()
		{
			if (this.m_userInfo != null && this.m_houseID > 0)
			{
				InterfaceMgr.Instance.closeParishPanel();
				InterfaceMgr.Instance.showHousePanel(this.m_houseID);
			}
		}

		// Token: 0x06002C62 RID: 11362 RVA: 0x000209AF File Offset: 0x0001EBAF
		private void manageDiplomacyClicked()
		{
			InterfaceMgr.Instance.setVillageTabSubMode(60, false);
		}

		// Token: 0x06002C63 RID: 11363 RVA: 0x00235B88 File Offset: 0x00233D88
		public void addDiplomacyOverlay()
		{
			if (this.m_userInfo != null)
			{
				this.removeOverlay();
				this.diplomacyOverlayVisible = true;
				this.greyOverlay.Position = new Point(0, -this.mainHeaderArea.Height);
				this.greyOverlay.Size = base.Size;
				this.greyOverlay.FillColor = Color.FromArgb(128, 0, 0, 0);
				this.greyOverlay.setClickDelegate(delegate()
				{
				});
				this.mainBackgroundImage.addControl(this.greyOverlay);
				this.diplomacyHeaderImage.Size = new Size(400, 40);
				this.diplomacyHeaderImage.Position = new Point((base.Width - 400) / 2, 100);
				this.greyOverlay.addControl(this.diplomacyHeaderImage);
				this.diplomacyHeaderImage.Create(GFXLibrary.mail2_titlebar_left, GFXLibrary.mail2_titlebar_middle, GFXLibrary.mail2_titlebar_right);
				this.diplomacyBackgroundImage.Size = new Size(400, 300);
				this.diplomacyBackgroundImage.Position = new Point((base.Width - 400) / 2, 140);
				this.greyOverlay.addControl(this.diplomacyBackgroundImage);
				this.diplomacyBackgroundImage.Create(GFXLibrary.mail2_mail_panel_upper_left, GFXLibrary.mail2_mail_panel_upper_middle, GFXLibrary.mail2_mail_panel_upper_right, GFXLibrary.mail2_mail_panel_middle_left, GFXLibrary.mail2_mail_panel_middle_middle, GFXLibrary.mail2_mail_panel_middle_right, GFXLibrary.mail2_mail_panel_lower_left, GFXLibrary.mail2_mail_panel_lower_middle, GFXLibrary.mail2_mail_panel_lower_right);
				this.diplomacyHeadingLabel.Text = SK.Text("AllArmiesPanel_Diplomacy", "Diplomacy");
				this.diplomacyHeadingLabel.Color = global::ARGBColors.White;
				this.diplomacyHeadingLabel.Position = new Point(0, 0);
				this.diplomacyHeadingLabel.Size = this.diplomacyHeaderImage.Size;
				this.diplomacyHeadingLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
				this.diplomacyHeadingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.diplomacyHeaderImage.addControl(this.diplomacyHeadingLabel);
				this.diplomacyFactionLabel.Text = this.m_userInfo.userName;
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
				int userRelationship = GameEngine.Instance.World.getUserRelationship(this.m_userInfo.userID);
				if (userRelationship == 0)
				{
					text += SK.Text("GENERIC_Neutral", "Neutral");
				}
				else if (userRelationship > 0)
				{
					text += SK.Text("GENERIC_Ally", "Ally");
				}
				else if (userRelationship < 0)
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

		// Token: 0x06002C64 RID: 11364 RVA: 0x000209BE File Offset: 0x0001EBBE
		public void removeOverlay()
		{
			this.mainBackgroundImage.removeControl(this.greyOverlay);
			this.greyOverlay.clearControls();
			base.Invalidate();
			this.diplomacyOverlayVisible = false;
		}

		// Token: 0x06002C65 RID: 11365 RVA: 0x002363EC File Offset: 0x002345EC
		private void btnAlly_Click()
		{
			this.diplomacyEnemyButton.Enabled = false;
			this.diplomacyAllyButton.Enabled = false;
			this.diplomacyNeutralButton.Enabled = false;
			if (GameEngine.Instance.World.UserRelations.Count == 0)
			{
				StatTrackingClient.Instance().ActivateTrigger(11, 0);
			}
			GameEngine.Instance.World.setUserRelationship(this.m_userInfo.userID, 1, this.m_userInfo.userName);
			RemoteServices.Instance.set_CreateUserRelationship_UserCallBack(new RemoteServices.CreateUserRelationship_UserCallBack(this.createUserRelationshipCallback));
			RemoteServices.Instance.CreateUserRelationship(this.m_userInfo.userID, 1);
		}

		// Token: 0x06002C66 RID: 11366 RVA: 0x00236498 File Offset: 0x00234698
		private void btnMakeEnemy_Click()
		{
			this.diplomacyEnemyButton.Enabled = false;
			this.diplomacyAllyButton.Enabled = false;
			this.diplomacyNeutralButton.Enabled = false;
			if (GameEngine.Instance.World.UserRelations.Count == 0)
			{
				StatTrackingClient.Instance().ActivateTrigger(11, 0);
			}
			GameEngine.Instance.World.setUserRelationship(this.m_userInfo.userID, -1, this.m_userInfo.userName);
			RemoteServices.Instance.set_CreateUserRelationship_UserCallBack(new RemoteServices.CreateUserRelationship_UserCallBack(this.createUserRelationshipCallback));
			RemoteServices.Instance.CreateUserRelationship(this.m_userInfo.userID, -1);
		}

		// Token: 0x06002C67 RID: 11367 RVA: 0x00236544 File Offset: 0x00234744
		private void btnBreakAlliance_Click()
		{
			this.diplomacyEnemyButton.Enabled = false;
			this.diplomacyAllyButton.Enabled = false;
			this.diplomacyNeutralButton.Enabled = false;
			GameEngine.Instance.World.setUserRelationship(this.m_userInfo.userID, 0, this.m_userInfo.userName);
			RemoteServices.Instance.set_CreateUserRelationship_UserCallBack(new RemoteServices.CreateUserRelationship_UserCallBack(this.createUserRelationshipCallback));
			RemoteServices.Instance.CreateUserRelationship(this.m_userInfo.userID, 0);
		}

		// Token: 0x06002C68 RID: 11368 RVA: 0x002365C8 File Offset: 0x002347C8
		private void createUserRelationshipCallback(CreateUserRelationship_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.diplomacyOverlayVisible = false;
				this.init(this.m_userInfo);
				return;
			}
			this.diplomacyEnemyButton.Enabled = true;
			this.diplomacyAllyButton.Enabled = true;
			this.diplomacyNeutralButton.Enabled = true;
		}

		// Token: 0x06002C69 RID: 11369 RVA: 0x000209E9 File Offset: 0x0001EBE9
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06002C6A RID: 11370 RVA: 0x000209F9 File Offset: 0x0001EBF9
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06002C6B RID: 11371 RVA: 0x00020A09 File Offset: 0x0001EC09
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06002C6C RID: 11372 RVA: 0x00020A1B File Offset: 0x0001EC1B
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06002C6D RID: 11373 RVA: 0x00020A28 File Offset: 0x0001EC28
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x06002C6E RID: 11374 RVA: 0x00020A36 File Offset: 0x0001EC36
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06002C6F RID: 11375 RVA: 0x00020A43 File Offset: 0x0001EC43
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06002C70 RID: 11376 RVA: 0x00020A50 File Offset: 0x0001EC50
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002C71 RID: 11377 RVA: 0x00236618 File Offset: 0x00234818
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.MaximumSize = new Size(992, 590);
			this.MinimumSize = new Size(992, 590);
			base.Name = "UserInfoScreen2";
			base.Size = new Size(992, 590);
			base.ResumeLayout(false);
		}

		// Token: 0x04003720 RID: 14112
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04003721 RID: 14113
		private CustomSelfDrawPanel.CSDExtendingPanel mainBackgroundImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04003722 RID: 14114
		private CustomSelfDrawPanel.CSDArea mainHeaderArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003723 RID: 14115
		private CustomSelfDrawPanel.CSDArea mainBodyArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003724 RID: 14116
		private CustomSelfDrawPanel.CSDLabel headerLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003725 RID: 14117
		private CustomSelfDrawPanel.CSDLabel headerLabel2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003726 RID: 14118
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003727 RID: 14119
		private CustomSelfDrawPanel.CSDButton adminButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003728 RID: 14120
		private CustomSelfDrawPanel.CSDImage backgroundLeft = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003729 RID: 14121
		private CustomSelfDrawPanel.CSDImage backgroundCentre = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400372A RID: 14122
		private CustomSelfDrawPanel.CSDImage backgroundRight = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400372B RID: 14123
		private CustomSelfDrawPanel.CSDImage avatarImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400372C RID: 14124
		private CustomSelfDrawPanel.CSDImage shieldImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400372D RID: 14125
		private CustomSelfDrawPanel.CSDFactionFlagImage flagImage = new CustomSelfDrawPanel.CSDFactionFlagImage();

		// Token: 0x0400372E RID: 14126
		private CustomSelfDrawPanel.CSDImage houseImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400372F RID: 14127
		private CustomSelfDrawPanel.CSDImage houseImageShadow = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003730 RID: 14128
		private CustomSelfDrawPanel.CSDImage flagImageShadow = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003731 RID: 14129
		private CustomSelfDrawPanel.CSDLabel nameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003732 RID: 14130
		private CustomSelfDrawPanel.CSDLabel rankLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003733 RID: 14131
		private CustomSelfDrawPanel.CSDLabel houseLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003734 RID: 14132
		private CustomSelfDrawPanel.CSDLabel factionLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003735 RID: 14133
		private CustomSelfDrawPanel.CSDButton inviteButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003736 RID: 14134
		private CustomSelfDrawPanel.CSDButton mailButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003737 RID: 14135
		private CustomSelfDrawPanel.CSDImage positionImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003738 RID: 14136
		private CustomSelfDrawPanel.CSDLabel standingLabelLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003739 RID: 14137
		private CustomSelfDrawPanel.CSDLabel pointsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400373A RID: 14138
		private CustomSelfDrawPanel.CSDButton achievementsButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400373B RID: 14139
		private CustomSelfDrawPanel.CSDLabel achievementsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400373C RID: 14140
		private CustomSelfDrawPanel.CSDButton questsButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400373D RID: 14141
		private CustomSelfDrawPanel.CSDLabel questsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400373E RID: 14142
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x0400373F RID: 14143
		private CustomSelfDrawPanel.CSDImage divider1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003740 RID: 14144
		private CustomSelfDrawPanel.CSDLabel villageLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003741 RID: 14145
		private CustomSelfDrawPanel.CSDLabel regionLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003742 RID: 14146
		private CustomSelfDrawPanel.CSDVertScrollBar outgoingScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04003743 RID: 14147
		private CustomSelfDrawPanel.CSDArea outgoingScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003744 RID: 14148
		private WorldMap.CachedUserInfo m_userInfo;

		// Token: 0x04003745 RID: 14149
		private int m_userID = -1;

		// Token: 0x04003746 RID: 14150
		private int m_houseID;

		// Token: 0x04003747 RID: 14151
		private CustomSelfDrawPanel.CSDButton editButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003748 RID: 14152
		private CustomSelfDrawPanel.CSDButton editAvatarButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003749 RID: 14153
		private CustomSelfDrawPanel.CSDButton diplomacyButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400374A RID: 14154
		private static Image lastCreatedAvatar = null;

		// Token: 0x0400374B RID: 14155
		public static UserInfoScreen2.VillageComparer villageComparer = new UserInfoScreen2.VillageComparer();

		// Token: 0x0400374C RID: 14156
		private List<UserInfoScreen2.VillageLine> lineList = new List<UserInfoScreen2.VillageLine>();

		// Token: 0x0400374D RID: 14157
		private CustomSelfDrawPanel.CSDFill greyOverlay = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x0400374E RID: 14158
		private CustomSelfDrawPanel.CSDHorzExtendingPanel diplomacyHeaderImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x0400374F RID: 14159
		private CustomSelfDrawPanel.CSDExtendingPanel diplomacyBackgroundImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04003750 RID: 14160
		private CustomSelfDrawPanel.CSDButton diplomacyNeutralButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003751 RID: 14161
		private CustomSelfDrawPanel.CSDButton diplomacyAllyButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003752 RID: 14162
		private CustomSelfDrawPanel.CSDButton diplomacyEnemyButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003753 RID: 14163
		private CustomSelfDrawPanel.CSDButton diplomacyCancelButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003754 RID: 14164
		private CustomSelfDrawPanel.CSDLabel diplomacyHeadingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003755 RID: 14165
		private CustomSelfDrawPanel.CSDLabel diplomacyFactionLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003756 RID: 14166
		private CustomSelfDrawPanel.CSDLabel diplomacyCurrentLabelHeader = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003757 RID: 14167
		private CustomSelfDrawPanel.CSDLabel diplomacyCurrentLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003758 RID: 14168
		private bool diplomacyOverlayVisible;

		// Token: 0x04003759 RID: 14169
		private DockableControl dockableControl;

		// Token: 0x0400375A RID: 14170
		private IContainer components;

		// Token: 0x0400375B RID: 14171
		[CompilerGenerated]
		private static CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate _003C_003E9__CachedAnonymousMethodDelegate2;

		// Token: 0x020004B4 RID: 1204
		public class VillageComparer : IComparer<int>
		{
			// Token: 0x06002C74 RID: 11380 RVA: 0x00236684 File Offset: 0x00234884
			public int Compare(int x, int y)
			{
				VillageData villageData = GameEngine.Instance.World.getVillageData(x);
				VillageData villageData2 = GameEngine.Instance.World.getVillageData(y);
				if (villageData == null)
				{
					if (villageData2 == null)
					{
						return 0;
					}
					return -1;
				}
				else
				{
					if (villageData2 == null)
					{
						return 1;
					}
					if (villageData.Capital && !villageData2.Capital)
					{
						return 1;
					}
					if (!villageData.Capital && villageData2.Capital)
					{
						return -1;
					}
					if (villageData.Capital && villageData2.Capital)
					{
						int num = 0;
						int num2 = 0;
						if (villageData.countyCapital)
						{
							num = 1;
						}
						else if (villageData.provinceCapital)
						{
							num = 2;
						}
						else if (villageData.countryCapital)
						{
							num = 3;
						}
						if (villageData2.countyCapital)
						{
							num2 = 1;
						}
						else if (villageData2.provinceCapital)
						{
							num2 = 2;
						}
						else if (villageData2.countryCapital)
						{
							num2 = 3;
						}
						if (num < num2)
						{
							return -1;
						}
						if (num2 < num)
						{
							return 1;
						}
					}
					return villageData.villageName.CompareTo(villageData2.villageName);
				}
			}
		}

		// Token: 0x020004B5 RID: 1205
		public class VillageLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06002C76 RID: 11382 RVA: 0x0023675C File Offset: 0x0023495C
			public void init(int villageID, UserInfoScreen2 parent, int position)
			{
				this.m_villageID = villageID;
				this.m_parent = parent;
				this.clearControls();
				if ((position & 1) == 0)
				{
					this.backgroundImage.Image = GFXLibrary.char_line_01;
				}
				else
				{
					this.backgroundImage.Image = GFXLibrary.char_line_02;
				}
				this.backgroundImage.Position = new Point(0, 5);
				this.backgroundImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				base.addControl(this.backgroundImage);
				base.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				this.Size = new Size(360, 30);
				this.villageNameLabel.Text = GameEngine.Instance.World.getVillageName(villageID);
				this.villageNameLabel.Color = global::ARGBColors.Black;
				this.villageNameLabel.RolloverColor = global::ARGBColors.White;
				this.villageNameLabel.Position = new Point(50, -10);
				this.villageNameLabel.Size = new Size(160, this.backgroundImage.Height + 20);
				this.villageNameLabel.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.villageNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.villageNameLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				this.backgroundImage.addControl(this.villageNameLabel);
				this.regionLabel.Color = global::ARGBColors.Black;
				this.regionLabel.RolloverColor = global::ARGBColors.White;
				this.regionLabel.Position = new Point(220, -10);
				this.regionLabel.Size = new Size(140, this.backgroundImage.Height + 20);
				this.regionLabel.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.regionLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.regionLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				this.backgroundImage.addControl(this.regionLabel);
				if (GameEngine.Instance.World.isCapital(villageID))
				{
					int num = 0;
					if (GameEngine.Instance.World.isRegionCapital(villageID))
					{
						num = 0;
						int villageCounty = GameEngine.Instance.World.getVillageCounty(villageID);
						this.regionLabel.Text = GameEngine.Instance.World.getCountyName(villageCounty);
					}
					else if (GameEngine.Instance.World.isCountyCapital(villageID))
					{
						num = 1;
						int villageCounty2 = GameEngine.Instance.World.getVillageCounty(villageID);
						this.regionLabel.Text = GameEngine.Instance.World.getCountyName(villageCounty2);
					}
					else if (GameEngine.Instance.World.isProvinceCapital(villageID))
					{
						num = 2;
						int provinceFromVillageID = GameEngine.Instance.World.getProvinceFromVillageID(villageID);
						this.regionLabel.Text = GameEngine.Instance.World.getProvinceName(provinceFromVillageID);
					}
					else if (GameEngine.Instance.World.isCountryCapital(villageID))
					{
						num = 3;
						int countryFromVillageID = GameEngine.Instance.World.getCountryFromVillageID(villageID);
						this.regionLabel.Text = GameEngine.Instance.World.getCountryName(countryFromVillageID);
					}
					this.villageImage.Image = GFXLibrary.char_position[num + 4];
					this.villageImage.Position = new Point(10, -4);
					this.villageImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
					this.backgroundImage.addControl(this.villageImage);
					return;
				}
				int villageSize = GameEngine.Instance.World.getVillageSize(villageID);
				this.villageImage.Image = GFXLibrary.char_village_icons[villageSize];
				this.villageImage.Position = new Point(-5, -18);
				this.villageImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				this.backgroundImage.addControl(this.villageImage);
				int villageCounty3 = GameEngine.Instance.World.getVillageCounty(villageID);
				this.regionLabel.Text = GameEngine.Instance.World.getCountyName(villageCounty3);
			}

			// Token: 0x06002C77 RID: 11383 RVA: 0x0000A849 File Offset: 0x00008A49
			public bool update(double localTime)
			{
				return true;
			}

			// Token: 0x06002C78 RID: 11384 RVA: 0x00236B80 File Offset: 0x00234D80
			private void lineClicked()
			{
				if (this.m_villageID >= 0)
				{
					if (RemoteServices.Instance.Admin && GameEngine.shiftPressed)
					{
						AGUR agur = new AGUR();
						agur.init(this.m_villageID);
						agur.Show(InterfaceMgr.Instance.ParentForm);
						return;
					}
					GameEngine.Instance.playInterfaceSound("UserinfoScreenLine_village");
					Point villageLocation = GameEngine.Instance.World.getVillageLocation(this.m_villageID);
					GameEngine.Instance.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_WORLD;
					InterfaceMgr.Instance.closeParishPanel();
					InterfaceMgr.Instance.getMainTabBar().changeTab(0);
					GameEngine.Instance.World.startMultiStageZoom(10000.0, (double)villageLocation.X, (double)villageLocation.Y);
					InterfaceMgr.Instance.displaySelectedVillagePanel(this.m_villageID, false, true, true, false);
				}
			}

			// Token: 0x0400375C RID: 14172
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x0400375D RID: 14173
			private CustomSelfDrawPanel.CSDImage villageImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x0400375E RID: 14174
			private CustomSelfDrawPanel.CSDLabel villageNameLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400375F RID: 14175
			private CustomSelfDrawPanel.CSDLabel regionLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04003760 RID: 14176
			private UserInfoScreen2 m_parent;

			// Token: 0x04003761 RID: 14177
			private int m_villageID = -1;
		}
	}
}
