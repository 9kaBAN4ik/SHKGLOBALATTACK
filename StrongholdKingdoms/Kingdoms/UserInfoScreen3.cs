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
	// Token: 0x020004B7 RID: 1207
	public class UserInfoScreen3 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06002C7D RID: 11389 RVA: 0x00236C58 File Offset: 0x00234E58
		public UserInfoScreen3()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06002C7E RID: 11390 RVA: 0x00236F20 File Offset: 0x00235120
		public void init(WorldMap.CachedUserInfo userInfo)
		{
			foreach (UserInfoScreen3.VillageLine villageLine in this.lineList)
			{
				villageLine.resetRepairStatus();
			}
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
				this.standingLabelLabel.Text = SK.Text("UserInfoScreen_Rank", "Rank") + " : " + userInfo.standing.ToString("N", nfi);
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
					if (UserInfoScreen3.lastCreatedAvatar != null)
					{
						UserInfoScreen3.lastCreatedAvatar.Dispose();
					}
					UserInfoScreen3.lastCreatedAvatar = (this.avatarImage.Image = Avatar.CreateAvatar(userInfo.avatarData, global::ARGBColors.Transparent));
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
				this.addVillages(userInfo.villages, userInfo.avatarData.male);
			}
			base.Invalidate();
		}

		// Token: 0x06002C7F RID: 11391 RVA: 0x0023883C File Offset: 0x00236A3C
		public void update()
		{
			WorldMap.CachedUserInfo storedUserInfo = GameEngine.Instance.World.getStoredUserInfo(this.m_userID);
			if (this.m_userInfo != storedUserInfo)
			{
				this.init(storedUserInfo);
			}
		}

		// Token: 0x06002C80 RID: 11392 RVA: 0x00238870 File Offset: 0x00236A70
		private void addVillages(int[] villages, bool isMale)
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
			list.Sort(UserInfoScreen3.villageComparer);
			this.outgoingScrollArea.clearControls();
			int num2 = 0;
			for (int i = 0; i < list.Count; i++)
			{
				int num3 = list[i];
				UserInfoScreen3.VillageLine villageLine = new UserInfoScreen3.VillageLine();
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
					text = ((!isMale) ? SK.Text("ParishWallPanel_Queen", "Queen") : SK.Text("ParishWallPanel_King", "King"));
					text = text + " - " + GameEngine.Instance.World.getCountryName(GameEngine.Instance.World.getCountryFromVillageID(villageID));
					break;
				}
				this.headerLabel2.Text = text;
			}
		}

		// Token: 0x06002C81 RID: 11393 RVA: 0x00238C70 File Offset: 0x00236E70
		private void wallScrollBarMoved()
		{
			int value = this.outgoingScrollBar.Value;
			this.outgoingScrollArea.Position = new Point(this.outgoingScrollArea.X, 133 - value);
			this.outgoingScrollArea.ClipRect = new Rectangle(this.outgoingScrollArea.ClipRect.X, value, this.outgoingScrollArea.ClipRect.Width, this.outgoingScrollArea.ClipRect.Height);
			this.outgoingScrollArea.invalidate();
			this.outgoingScrollBar.invalidate();
		}

		// Token: 0x06002C82 RID: 11394 RVA: 0x000208C7 File Offset: 0x0001EAC7
		private void closeClick()
		{
			GameEngine.Instance.playInterfaceSound("UserInfoScreen_close");
			GameEngine.Instance.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_WORLD;
			InterfaceMgr.Instance.closeParishPanel();
			InterfaceMgr.Instance.getMainTabBar().changeTab(0);
		}

		// Token: 0x06002C83 RID: 11395 RVA: 0x00238D0C File Offset: 0x00236F0C
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

		// Token: 0x06002C84 RID: 11396 RVA: 0x001C98D0 File Offset: 0x001C7AD0
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

		// Token: 0x06002C85 RID: 11397 RVA: 0x00020809 File Offset: 0x0001EA09
		private void editAvatarClicked()
		{
			GameEngine.Instance.playInterfaceSound("UserInfoScreen_edit_avatar");
			InterfaceMgr.Instance.getMainTabBar().selectDummyTab(10);
		}

		// Token: 0x06002C86 RID: 11398 RVA: 0x0022EA2C File Offset: 0x0022CC2C
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

		// Token: 0x06002C87 RID: 11399 RVA: 0x00020AD0 File Offset: 0x0001ECD0
		public void inviteToFactionClicked()
		{
			GameEngine.Instance.playInterfaceSound("UserInfoScreen_faction_invite");
			InterfaceMgr.Instance.clearControls();
			if (this.m_userInfo != null)
			{
				InterfaceMgr.Instance.inviteToFaction(this.m_userInfo.userName);
			}
		}

		// Token: 0x06002C88 RID: 11400 RVA: 0x00020B08 File Offset: 0x0001ED08
		private void achievementsClicked()
		{
			GameEngine.Instance.playInterfaceSound("UserInfoScreen_achievements");
			if (this.m_userInfo != null)
			{
				InterfaceMgr.Instance.openAchievements(this.m_userInfo.achievements);
			}
		}

		// Token: 0x06002C89 RID: 11401 RVA: 0x00020B36 File Offset: 0x0001ED36
		private void questsClicked()
		{
			if (this.m_userInfo != null)
			{
				InterfaceMgr.Instance.openNewQuestsCompletedPopup(this.m_userInfo.completedQuests);
			}
		}

		// Token: 0x06002C8A RID: 11402 RVA: 0x00238D68 File Offset: 0x00236F68
		private void sendMailClicked()
		{
			GameEngine.Instance.playInterfaceSound("UserInfoScreen_send_mail");
			if (this.m_userInfo != null)
			{
				InterfaceMgr.Instance.getMainTabBar().selectDummyTab(21);
				InterfaceMgr.Instance.mailTo(this.m_userInfo.userID, this.m_userInfo.userName);
			}
		}

		// Token: 0x06002C8B RID: 11403 RVA: 0x00238DC0 File Offset: 0x00236FC0
		private void factionClicked()
		{
			if (this.m_userInfo != null && this.m_userInfo.factionID >= 0)
			{
				GameEngine.Instance.playInterfaceSound("UserInfoScreen_faction");
				InterfaceMgr.Instance.closeParishPanel();
				InterfaceMgr.Instance.showFactionPanel(this.m_userInfo.factionID);
			}
		}

		// Token: 0x06002C8C RID: 11404 RVA: 0x00020B55 File Offset: 0x0001ED55
		private void houseClicked()
		{
			if (this.m_userInfo != null && this.m_houseID > 0)
			{
				InterfaceMgr.Instance.closeParishPanel();
				InterfaceMgr.Instance.showHousePanel(this.m_houseID);
			}
		}

		// Token: 0x06002C8D RID: 11405 RVA: 0x000209AF File Offset: 0x0001EBAF
		private void manageDiplomacyClicked()
		{
			InterfaceMgr.Instance.setVillageTabSubMode(60, false);
		}

		// Token: 0x06002C8E RID: 11406 RVA: 0x00238E14 File Offset: 0x00237014
		public void addDiplomacyOverlay()
		{
			if (this.m_userInfo == null)
			{
				return;
			}
			this.removeOverlay();
			this.diplomacyOverlayVisible = true;
			this.greyOverlay.Position = new Point(0, -this.mainHeaderArea.Height);
			this.greyOverlay.Size = base.Size;
			this.greyOverlay.FillColor = Color.FromArgb(128, 0, 0, 0);
			this.greyOverlay.setClickDelegate(delegate()
			{
			});
			this.mainBackgroundImage.addControl(this.greyOverlay);
			this.diplomacyHeaderImage.Size = new Size(500, 40);
			this.diplomacyHeaderImage.Position = new Point((base.Width - 500) / 2, 100);
			this.greyOverlay.addControl(this.diplomacyHeaderImage);
			this.diplomacyHeaderImage.Create(GFXLibrary.mail2_titlebar_left, GFXLibrary.mail2_titlebar_middle, GFXLibrary.mail2_titlebar_right);
			this.diplomacyBackgroundImage.Size = new Size(500, 300);
			this.diplomacyBackgroundImage.Position = new Point((base.Width - 500) / 2, 140);
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
			this.statusHeaderLabel.Text = SK.Text("GENERIC_Current_Relationship", "Current Relationship");
			this.statusHeaderLabel.Color = global::ARGBColors.Black;
			this.statusHeaderLabel.Position = new Point(0, 40);
			this.statusHeaderLabel.Size = new Size(this.diplomacyBackgroundImage.Width, 30);
			this.statusHeaderLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.statusHeaderLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.diplomacyBackgroundImage.addControl(this.statusHeaderLabel);
			this.allyButton.ImageNorm = GFXLibrary.button_132_normal;
			this.allyButton.ImageOver = GFXLibrary.button_132_over;
			this.allyButton.ImageClick = GFXLibrary.button_132_in;
			this.allyButton.setSizeToImage();
			this.allyButton.Position = new Point(this.diplomacyBackgroundImage.Width / 6 - this.allyButton.Width / 2, this.statusHeaderLabel.Rectangle.Bottom + 5);
			this.allyButton.Text.Text = SK.Text("GENERIC_Ally", "Ally");
			this.allyButton.Text.Color = global::ARGBColors.Green;
			Font font = this.allyButton.Text.Font = (this.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold));
			this.allyButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.onAllyClick));
			this.diplomacyBackgroundImage.addControl(this.allyButton);
			this.neutralButton.ImageNorm = GFXLibrary.button_132_normal;
			this.neutralButton.ImageOver = GFXLibrary.button_132_over;
			this.neutralButton.ImageClick = GFXLibrary.button_132_in;
			this.neutralButton.setSizeToImage();
			this.neutralButton.Position = new Point(this.diplomacyBackgroundImage.Width / 2 - this.neutralButton.Width / 2, this.statusHeaderLabel.Rectangle.Bottom + 5);
			this.neutralButton.Text.Text = SK.Text("GENERIC_Neutral", "Neutral");
			this.neutralButton.Text.Color = global::ARGBColors.Black;
			font = (this.neutralButton.Text.Font = (this.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold)));
			this.neutralButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.onNeutralClick));
			this.diplomacyBackgroundImage.addControl(this.neutralButton);
			this.enemyButton.ImageNorm = GFXLibrary.button_132_normal;
			this.enemyButton.ImageOver = GFXLibrary.button_132_over;
			this.enemyButton.ImageClick = GFXLibrary.button_132_in;
			this.enemyButton.setSizeToImage();
			this.enemyButton.Position = new Point(this.diplomacyBackgroundImage.Width * 5 / 6 - this.enemyButton.Width / 2, this.statusHeaderLabel.Rectangle.Bottom + 5);
			this.enemyButton.Text.Text = SK.Text("GENERIC_Enemy", "Enemy");
			this.enemyButton.Text.Color = global::ARGBColors.Red;
			font = (this.enemyButton.Text.Font = (this.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold)));
			this.enemyButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.onEnemyClick));
			this.diplomacyBackgroundImage.addControl(this.enemyButton);
			UserRelationship userRelationshipData = GameEngine.Instance.World.getUserRelationshipData(this.m_userInfo.userID);
			if (userRelationshipData == null)
			{
				this.neutralButton.ImageNorm = GFXLibrary.button_132_normal_gold;
				this.neutralButton.ImageOver = GFXLibrary.button_132_over_gold;
				this.neutralButton.ImageClick = GFXLibrary.button_132_in_gold;
				this.isAlly = false;
				this.isEnemy = false;
			}
			else if (userRelationshipData.friendly)
			{
				this.allyButton.ImageNorm = GFXLibrary.button_132_normal_gold;
				this.allyButton.ImageOver = GFXLibrary.button_132_over_gold;
				this.allyButton.ImageClick = GFXLibrary.button_132_in_gold;
				this.isAlly = true;
				this.isEnemy = false;
			}
			else
			{
				this.enemyButton.ImageNorm = GFXLibrary.button_132_normal_gold;
				this.enemyButton.ImageOver = GFXLibrary.button_132_over_gold;
				this.enemyButton.ImageClick = GFXLibrary.button_132_in_gold;
				this.isAlly = false;
				this.isEnemy = true;
			}
			this.markerHeaderLabel.Text = SK.Text("GENERIC_Player_Marker", "Assign Player Marker");
			this.markerHeaderLabel.Color = global::ARGBColors.Black;
			this.markerHeaderLabel.Position = new Point(0, this.neutralButton.Rectangle.Bottom + 20);
			this.markerHeaderLabel.Size = new Size(this.diplomacyBackgroundImage.Width, 20);
			this.markerHeaderLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.markerHeaderLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.diplomacyBackgroundImage.addControl(this.markerHeaderLabel);
			UserMarker userMarker = GameEngine.Instance.World.getUserMarker(this.m_userInfo.userID);
			this.currentMarkerType = 0;
			for (int i = 0; i < GFXLibrary.custom_player_marker.Length; i++)
			{
				this.markerButtons[i] = new CustomSelfDrawPanel.CSDButton();
				if (userMarker != null && userMarker.markerType == i + 1)
				{
					this.markerButtons[i].ImageNorm = GFXLibrary.custom_player_marker_selected[i];
					this.markerButtons[i].ImageOver = GFXLibrary.custom_player_marker_selected[i];
					this.markerButtons[i].ImageClick = GFXLibrary.custom_player_marker_selected[i];
					this.markerButtons[i].setSizeToImage();
					this.currentMarkerType = userMarker.markerType;
				}
				else
				{
					this.markerButtons[i].ImageNorm = GFXLibrary.custom_player_marker[i];
					this.markerButtons[i].ImageOver = GFXLibrary.custom_player_marker[i];
					this.markerButtons[i].ImageClick = GFXLibrary.custom_player_marker[i];
					this.markerButtons[i].setSizeToImage();
				}
				this.markerButtons[i].Position = new Point(this.diplomacyBackgroundImage.Width * (i % 4 + 1) / 5 - this.markerButtons[i].Width / 2, this.markerHeaderLabel.Rectangle.Bottom + 10 + i / 4 * (this.markerButtons[i].Height + 5));
				this.markerButtons[i].Data = i;
				this.markerButtons[i].setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.onMarkerClick));
				this.diplomacyBackgroundImage.addControl(this.markerButtons[i]);
			}
			this.updateButton.ImageNorm = GFXLibrary.button_132_normal;
			this.updateButton.ImageOver = GFXLibrary.button_132_over;
			this.updateButton.ImageClick = GFXLibrary.button_132_in;
			this.updateButton.setSizeToImage();
			this.updateButton.Position = new Point(this.diplomacyBackgroundImage.Width / 2 - this.updateButton.Width / 2, this.diplomacyBackgroundImage.Height - this.updateButton.Height - 10);
			this.updateButton.Text.Text = SK.Text("GENERIC_Close", "Close");
			this.updateButton.Text.Color = global::ARGBColors.Black;
			this.updateButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.updateRelationship));
			this.diplomacyBackgroundImage.addControl(this.updateButton);
			this.relationshipChanged = false;
			this.pendingMarkerUpdate = false;
			this.pendingRelationshipUpdate = false;
		}

		// Token: 0x06002C8F RID: 11407 RVA: 0x00239958 File Offset: 0x00237B58
		private void onMarkerClick()
		{
			if (this.pendingMarkerUpdate)
			{
				return;
			}
			CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
			int data = csdbutton.Data;
			if (data + 1 == this.currentMarkerType)
			{
				csdbutton.ImageNorm = GFXLibrary.custom_player_marker[data];
				csdbutton.ImageOver = GFXLibrary.custom_player_marker[data];
				csdbutton.ImageClick = GFXLibrary.custom_player_marker[data];
				this.currentMarkerType = 0;
			}
			else
			{
				for (int i = 0; i < this.markerButtons.Length; i++)
				{
					if (i == data)
					{
						this.markerButtons[i].ImageNorm = GFXLibrary.custom_player_marker_selected[i];
						this.markerButtons[i].ImageOver = GFXLibrary.custom_player_marker_selected[i];
						this.markerButtons[i].ImageClick = GFXLibrary.custom_player_marker_selected[i];
						this.currentMarkerType = i + 1;
					}
					else
					{
						this.markerButtons[i].ImageNorm = GFXLibrary.custom_player_marker[i];
						this.markerButtons[i].ImageOver = GFXLibrary.custom_player_marker[i];
						this.markerButtons[i].ImageClick = GFXLibrary.custom_player_marker[i];
					}
				}
			}
			base.Invalidate();
		}

		// Token: 0x06002C90 RID: 11408 RVA: 0x00239A94 File Offset: 0x00237C94
		private void onAllyClick()
		{
			if (!this.pendingRelationshipUpdate && !this.isAlly)
			{
				this.isAlly = true;
				this.isEnemy = false;
				this.allyButton.ImageNorm = GFXLibrary.button_132_normal_gold;
				this.allyButton.ImageOver = GFXLibrary.button_132_over_gold;
				this.allyButton.ImageClick = GFXLibrary.button_132_in_gold;
				this.enemyButton.ImageNorm = GFXLibrary.button_132_normal;
				this.enemyButton.ImageOver = GFXLibrary.button_132_over;
				this.enemyButton.ImageClick = GFXLibrary.button_132_in;
				this.neutralButton.ImageNorm = GFXLibrary.button_132_normal;
				this.neutralButton.ImageOver = GFXLibrary.button_132_over;
				this.neutralButton.ImageClick = GFXLibrary.button_132_in;
				this.relationshipChanged = true;
			}
		}

		// Token: 0x06002C91 RID: 11409 RVA: 0x00239B8C File Offset: 0x00237D8C
		private void onNeutralClick()
		{
			if (!this.pendingRelationshipUpdate && (this.isAlly || this.isEnemy))
			{
				this.isAlly = false;
				this.isEnemy = false;
				this.neutralButton.ImageNorm = GFXLibrary.button_132_normal_gold;
				this.neutralButton.ImageOver = GFXLibrary.button_132_over_gold;
				this.neutralButton.ImageClick = GFXLibrary.button_132_in_gold;
				this.allyButton.ImageNorm = GFXLibrary.button_132_normal;
				this.allyButton.ImageOver = GFXLibrary.button_132_over;
				this.allyButton.ImageClick = GFXLibrary.button_132_in;
				this.enemyButton.ImageNorm = GFXLibrary.button_132_normal;
				this.enemyButton.ImageOver = GFXLibrary.button_132_over;
				this.enemyButton.ImageClick = GFXLibrary.button_132_in;
				this.relationshipChanged = true;
			}
		}

		// Token: 0x06002C92 RID: 11410 RVA: 0x00239C8C File Offset: 0x00237E8C
		private void onEnemyClick()
		{
			if (!this.pendingRelationshipUpdate && !this.isEnemy)
			{
				this.isAlly = false;
				this.isEnemy = true;
				this.enemyButton.ImageNorm = GFXLibrary.button_132_normal_gold;
				this.enemyButton.ImageOver = GFXLibrary.button_132_over_gold;
				this.enemyButton.ImageClick = GFXLibrary.button_132_in_gold;
				this.allyButton.ImageNorm = GFXLibrary.button_132_normal;
				this.allyButton.ImageOver = GFXLibrary.button_132_over;
				this.allyButton.ImageClick = GFXLibrary.button_132_in;
				this.neutralButton.ImageNorm = GFXLibrary.button_132_normal;
				this.neutralButton.ImageOver = GFXLibrary.button_132_over;
				this.neutralButton.ImageClick = GFXLibrary.button_132_in;
				this.relationshipChanged = true;
			}
		}

		// Token: 0x06002C93 RID: 11411 RVA: 0x00239D84 File Offset: 0x00237F84
		public void removeOverlay()
		{
			this.mainBackgroundImage.removeControl(this.greyOverlay);
			this.greyOverlay.clearControls();
			base.Invalidate();
			this.diplomacyOverlayVisible = false;
			RemoteServices.Instance.set_CreateUserRelationship_UserCallBack(null);
			RemoteServices.Instance.set_SetUserMarker_UserCallBack(null);
		}

		// Token: 0x06002C94 RID: 11412 RVA: 0x00239DD0 File Offset: 0x00237FD0
		public void updateRelationship()
		{
			UserMarker userMarker = GameEngine.Instance.World.getUserMarker(this.m_userInfo.userID);
			if (userMarker == null || userMarker.markerType != this.currentMarkerType)
			{
				GameEngine.Instance.World.setUserMarker(this.m_userInfo.userID, this.currentMarkerType, this.m_userInfo.userName);
				RemoteServices.Instance.set_SetUserMarker_UserCallBack(new RemoteServices.SetUserMarker_UserCallBack(this.updateMarkerCallback));
				RemoteServices.Instance.SetUserMarker(this.m_userInfo.userID, this.currentMarkerType);
				this.pendingMarkerUpdate = true;
			}
			if (this.relationshipChanged)
			{
				if (this.isAlly)
				{
					GameEngine.Instance.World.setUserRelationship(this.m_userInfo.userID, 1, this.m_userInfo.userName);
					RemoteServices.Instance.CreateUserRelationship(this.m_userInfo.userID, 1);
				}
				else if (this.isEnemy)
				{
					GameEngine.Instance.World.setUserRelationship(this.m_userInfo.userID, -1, this.m_userInfo.userName);
					RemoteServices.Instance.CreateUserRelationship(this.m_userInfo.userID, -1);
				}
				else
				{
					GameEngine.Instance.World.setUserRelationship(this.m_userInfo.userID, 0, this.m_userInfo.userName);
					RemoteServices.Instance.CreateUserRelationship(this.m_userInfo.userID, 0);
				}
				RemoteServices.Instance.set_CreateUserRelationship_UserCallBack(new RemoteServices.CreateUserRelationship_UserCallBack(this.updateRelationshipCallback));
				this.pendingRelationshipUpdate = true;
			}
			this.removeOverlay();
		}

		// Token: 0x06002C95 RID: 11413 RVA: 0x00020B82 File Offset: 0x0001ED82
		private void updateMarkerCallback(SetUserMarker_ReturnType returnData)
		{
			this.pendingMarkerUpdate = false;
		}

		// Token: 0x06002C96 RID: 11414 RVA: 0x00020B8B File Offset: 0x0001ED8B
		private void updateRelationshipCallback(CreateUserRelationship_ReturnType returnData)
		{
			this.pendingRelationshipUpdate = false;
		}

		// Token: 0x06002C97 RID: 11415 RVA: 0x00239F68 File Offset: 0x00238168
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

		// Token: 0x06002C98 RID: 11416 RVA: 0x0023A014 File Offset: 0x00238214
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

		// Token: 0x06002C99 RID: 11417 RVA: 0x0023A0C0 File Offset: 0x002382C0
		private void btnBreakAlliance_Click()
		{
			this.diplomacyEnemyButton.Enabled = false;
			this.diplomacyAllyButton.Enabled = false;
			this.diplomacyNeutralButton.Enabled = false;
			GameEngine.Instance.World.setUserRelationship(this.m_userInfo.userID, 0, this.m_userInfo.userName);
			RemoteServices.Instance.set_CreateUserRelationship_UserCallBack(new RemoteServices.CreateUserRelationship_UserCallBack(this.createUserRelationshipCallback));
			RemoteServices.Instance.CreateUserRelationship(this.m_userInfo.userID, 0);
		}

		// Token: 0x06002C9A RID: 11418 RVA: 0x0023A144 File Offset: 0x00238344
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

		// Token: 0x06002C9B RID: 11419 RVA: 0x00020B94 File Offset: 0x0001ED94
		private void repairAllClicked()
		{
			this.repairCount = 0;
			this.repairButton.Enabled = false;
			this.startNextRepair();
		}

		// Token: 0x06002C9C RID: 11420 RVA: 0x0023A194 File Offset: 0x00238394
		private void startNextRepair()
		{
			this.currentRepairCastle = null;
			foreach (UserInfoScreen3.VillageLine villageLine in this.lineList)
			{
				if (villageLine.RepairAvailable)
				{
					this.currentRepairCastle = villageLine;
					this.startRepair();
					return;
				}
			}
			this.repairButton.Enabled = true;
			foreach (UserInfoScreen3.VillageLine villageLine2 in this.lineList)
			{
				villageLine2.resetRepairStatus();
			}
		}

		// Token: 0x06002C9D RID: 11421 RVA: 0x00020BAF File Offset: 0x0001EDAF
		private void startRepair()
		{
			if (this.currentRepairCastle != null)
			{
				this.currentRepairCastle.startRepair();
				RemoteServices.Instance.set_AutoRepairCastle_UserCallBack(new RemoteServices.AutoRepairCastle_UserCallBack(this.repairCallback));
				RemoteServices.Instance.AutoRepairCastle(this.currentRepairCastle.villageID);
			}
		}

		// Token: 0x06002C9E RID: 11422 RVA: 0x0023A24C File Offset: 0x0023844C
		private void repairCallback(AutoRepairCastle_ReturnType returnData)
		{
			if (returnData.Success)
			{
				VillageMap village = GameEngine.Instance.getVillage(returnData.villageID);
				if (village != null)
				{
					village.importResourcesAndStats(returnData.villageResourcesAndStats, returnData.currentTime);
					if (returnData.elements != null)
					{
						GameEngine.Instance.Castle.importElements(returnData.elements);
					}
				}
				bool flag = false;
				if (returnData.elements != null)
				{
					foreach (CastleElement castleElement in returnData.elements)
					{
						if (castleElement.damage > 0f)
						{
							flag = true;
							break;
						}
					}
				}
				this.currentRepairCastle.completeRepair(!flag);
				if (!flag)
				{
					this.repairCount++;
				}
				base.Invalidate();
			}
			this.startNextRepair();
		}

		// Token: 0x06002C9F RID: 11423 RVA: 0x00020BEF File Offset: 0x0001EDEF
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06002CA0 RID: 11424 RVA: 0x00020BFF File Offset: 0x0001EDFF
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06002CA1 RID: 11425 RVA: 0x00020C0F File Offset: 0x0001EE0F
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06002CA2 RID: 11426 RVA: 0x00020C21 File Offset: 0x0001EE21
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06002CA3 RID: 11427 RVA: 0x00020C2E File Offset: 0x0001EE2E
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x06002CA4 RID: 11428 RVA: 0x00020C3C File Offset: 0x0001EE3C
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06002CA5 RID: 11429 RVA: 0x00020C49 File Offset: 0x0001EE49
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06002CA6 RID: 11430 RVA: 0x00020C56 File Offset: 0x0001EE56
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002CA7 RID: 11431 RVA: 0x0023A330 File Offset: 0x00238530
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.MaximumSize = new Size(992, 590);
			this.MinimumSize = new Size(992, 590);
			base.Name = "UserInfoScreen3";
			base.Size = new Size(992, 590);
			base.ResumeLayout(false);
		}

		// Token: 0x04003764 RID: 14180
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04003765 RID: 14181
		private CustomSelfDrawPanel.CSDExtendingPanel mainBackgroundImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04003766 RID: 14182
		private CustomSelfDrawPanel.CSDArea mainHeaderArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003767 RID: 14183
		private CustomSelfDrawPanel.CSDArea mainBodyArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003768 RID: 14184
		private CustomSelfDrawPanel.CSDLabel headerLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003769 RID: 14185
		private CustomSelfDrawPanel.CSDLabel headerLabel2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400376A RID: 14186
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400376B RID: 14187
		private CustomSelfDrawPanel.CSDButton adminButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400376C RID: 14188
		private CustomSelfDrawPanel.CSDImage backgroundLeft = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400376D RID: 14189
		private CustomSelfDrawPanel.CSDImage backgroundCentre = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400376E RID: 14190
		private CustomSelfDrawPanel.CSDImage backgroundRight = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400376F RID: 14191
		private CustomSelfDrawPanel.CSDImage avatarImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003770 RID: 14192
		private CustomSelfDrawPanel.CSDImage shieldImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003771 RID: 14193
		private CustomSelfDrawPanel.CSDFactionFlagImage flagImage = new CustomSelfDrawPanel.CSDFactionFlagImage();

		// Token: 0x04003772 RID: 14194
		private CustomSelfDrawPanel.CSDImage houseImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003773 RID: 14195
		private CustomSelfDrawPanel.CSDImage houseImageShadow = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003774 RID: 14196
		private CustomSelfDrawPanel.CSDImage flagImageShadow = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003775 RID: 14197
		private CustomSelfDrawPanel.CSDLabel nameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003776 RID: 14198
		private CustomSelfDrawPanel.CSDLabel rankLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003777 RID: 14199
		private CustomSelfDrawPanel.CSDLabel houseLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003778 RID: 14200
		private CustomSelfDrawPanel.CSDLabel factionLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003779 RID: 14201
		private CustomSelfDrawPanel.CSDButton inviteButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400377A RID: 14202
		private CustomSelfDrawPanel.CSDButton mailButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400377B RID: 14203
		private CustomSelfDrawPanel.CSDImage positionImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400377C RID: 14204
		private CustomSelfDrawPanel.CSDLabel standingLabelLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400377D RID: 14205
		private CustomSelfDrawPanel.CSDLabel pointsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400377E RID: 14206
		private CustomSelfDrawPanel.CSDButton achievementsButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400377F RID: 14207
		private CustomSelfDrawPanel.CSDLabel achievementsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003780 RID: 14208
		private CustomSelfDrawPanel.CSDButton questsButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003781 RID: 14209
		private CustomSelfDrawPanel.CSDLabel questsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003782 RID: 14210
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04003783 RID: 14211
		private CustomSelfDrawPanel.CSDImage divider1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003784 RID: 14212
		private CustomSelfDrawPanel.CSDLabel villageLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003785 RID: 14213
		private CustomSelfDrawPanel.CSDLabel regionLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003786 RID: 14214
		private CustomSelfDrawPanel.CSDVertScrollBar outgoingScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04003787 RID: 14215
		private CustomSelfDrawPanel.CSDArea outgoingScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003788 RID: 14216
		private WorldMap.CachedUserInfo m_userInfo;

		// Token: 0x04003789 RID: 14217
		private int m_userID = -1;

		// Token: 0x0400378A RID: 14218
		private int m_houseID;

		// Token: 0x0400378B RID: 14219
		private CustomSelfDrawPanel.CSDButton editButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400378C RID: 14220
		private CustomSelfDrawPanel.CSDButton editAvatarButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400378D RID: 14221
		private CustomSelfDrawPanel.CSDButton diplomacyButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400378E RID: 14222
		private CustomSelfDrawPanel.CSDButton repairButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400378F RID: 14223
		private static Image lastCreatedAvatar = null;

		// Token: 0x04003790 RID: 14224
		public static UserInfoScreen3.VillageComparer villageComparer = new UserInfoScreen3.VillageComparer();

		// Token: 0x04003791 RID: 14225
		private List<UserInfoScreen3.VillageLine> lineList = new List<UserInfoScreen3.VillageLine>();

		// Token: 0x04003792 RID: 14226
		private CustomSelfDrawPanel.CSDButton diplomacyNeutralButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003793 RID: 14227
		private CustomSelfDrawPanel.CSDButton diplomacyAllyButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003794 RID: 14228
		private CustomSelfDrawPanel.CSDButton diplomacyEnemyButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003795 RID: 14229
		private CustomSelfDrawPanel.CSDLabel diplomacyCurrentLabelHeader = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003796 RID: 14230
		private CustomSelfDrawPanel.CSDLabel diplomacyCurrentLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003797 RID: 14231
		private bool diplomacyOverlayVisible;

		// Token: 0x04003798 RID: 14232
		private CustomSelfDrawPanel.CSDFill greyOverlay = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x04003799 RID: 14233
		private CustomSelfDrawPanel.CSDHorzExtendingPanel diplomacyHeaderImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x0400379A RID: 14234
		private CustomSelfDrawPanel.CSDExtendingPanel diplomacyBackgroundImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x0400379B RID: 14235
		private CustomSelfDrawPanel.CSDLabel diplomacyHeadingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400379C RID: 14236
		private CustomSelfDrawPanel.CSDLabel diplomacyFactionLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400379D RID: 14237
		private CustomSelfDrawPanel.CSDButton diplomacyCancelButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400379E RID: 14238
		private CustomSelfDrawPanel.CSDLabel statusHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400379F RID: 14239
		private CustomSelfDrawPanel.CSDButton allyButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040037A0 RID: 14240
		private CustomSelfDrawPanel.CSDButton neutralButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040037A1 RID: 14241
		private CustomSelfDrawPanel.CSDButton enemyButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040037A2 RID: 14242
		private CustomSelfDrawPanel.CSDLabel markerHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037A3 RID: 14243
		private CustomSelfDrawPanel.CSDButton[] markerButtons = new CustomSelfDrawPanel.CSDButton[GFXLibrary.custom_player_marker.Length];

		// Token: 0x040037A4 RID: 14244
		private CustomSelfDrawPanel.CSDButton updateButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040037A5 RID: 14245
		private bool isAlly;

		// Token: 0x040037A6 RID: 14246
		private bool isEnemy;

		// Token: 0x040037A7 RID: 14247
		private bool relationshipChanged;

		// Token: 0x040037A8 RID: 14248
		private int currentMarkerType;

		// Token: 0x040037A9 RID: 14249
		private bool pendingMarkerUpdate;

		// Token: 0x040037AA RID: 14250
		private bool pendingRelationshipUpdate;

		// Token: 0x040037AB RID: 14251
		private UserInfoScreen3.VillageLine currentRepairCastle;

		// Token: 0x040037AC RID: 14252
		private int repairCount;

		// Token: 0x040037AD RID: 14253
		private DockableControl dockableControl;

		// Token: 0x040037AE RID: 14254
		private IContainer components;

		// Token: 0x040037AF RID: 14255
		[CompilerGenerated]
		private static CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate _003C_003E9__CachedAnonymousMethodDelegate1;

		// Token: 0x020004B8 RID: 1208
		public class VillageComparer : IComparer<int>
		{
			// Token: 0x06002CA9 RID: 11433 RVA: 0x00236684 File Offset: 0x00234884
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

		// Token: 0x020004B9 RID: 1209
		public class VillageLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x1700024E RID: 590
			// (get) Token: 0x06002CAB RID: 11435 RVA: 0x00020C87 File Offset: 0x0001EE87
			public int villageID
			{
				get
				{
					return this.m_villageID;
				}
			}

			// Token: 0x06002CAC RID: 11436 RVA: 0x0023A39C File Offset: 0x0023859C
			public void init(int villageID, UserInfoScreen3 parent, int position)
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
				if (GameEngine.Instance.World.isUserVillage(villageID))
				{
					this.repairStatusImage.Position = new Point(base.Width * 5 / 6, base.Height / 2 - 16);
					this.backgroundImage.addControl(this.repairStatusImage);
				}
			}

			// Token: 0x06002CAD RID: 11437 RVA: 0x0000A849 File Offset: 0x00008A49
			public bool update(double localTime)
			{
				return true;
			}

			// Token: 0x06002CAE RID: 11438 RVA: 0x0023A808 File Offset: 0x00238A08
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

			// Token: 0x06002CAF RID: 11439 RVA: 0x00020C8F File Offset: 0x0001EE8F
			public void startRepair()
			{
				this.RepairAvailable = false;
				this.villageNameLabel.Color = global::ARGBColors.Green;
			}

			// Token: 0x06002CB0 RID: 11440 RVA: 0x00020CA8 File Offset: 0x0001EEA8
			public void completeRepair(bool success)
			{
				this.repairStatusImage.setSizeToImage();
				this.villageNameLabel.Color = global::ARGBColors.Black;
			}

			// Token: 0x06002CB1 RID: 11441 RVA: 0x00020CC5 File Offset: 0x0001EEC5
			public void resetRepairStatus()
			{
				this.RepairAvailable = true;
				this.villageNameLabel.Color = global::ARGBColors.Black;
			}

			// Token: 0x040037B0 RID: 14256
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040037B1 RID: 14257
			private CustomSelfDrawPanel.CSDImage villageImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040037B2 RID: 14258
			private CustomSelfDrawPanel.CSDLabel villageNameLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040037B3 RID: 14259
			private CustomSelfDrawPanel.CSDLabel regionLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040037B4 RID: 14260
			private CustomSelfDrawPanel.CSDImage repairStatusImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040037B5 RID: 14261
			private UserInfoScreen3 m_parent;

			// Token: 0x040037B6 RID: 14262
			private int m_villageID = -1;

			// Token: 0x040037B7 RID: 14263
			public bool RepairAvailable = true;
		}
	}
}
