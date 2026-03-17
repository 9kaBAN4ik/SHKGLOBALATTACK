using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020004B2 RID: 1202
	public class UserInfoScreen : UserControl, IDockableControl
	{
		// Token: 0x06002C18 RID: 11288 RVA: 0x0022DF54 File Offset: 0x0022C154
		public UserInfoScreen()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			this.lblUserName.Font = FontManager.GetFont("Microsoft Sans Serif", 12f, FontStyle.Bold);
			this.lblRank.Font = FontManager.GetFont("Microsoft Sans Serif", 10f);
			this.label1.Font = FontManager.GetFont("Microsoft Sans Serif", 10f);
			this.lblPoints.Font = FontManager.GetFont("Microsoft Sans Serif", 10f);
			this.lblStanding.Font = FontManager.GetFont("Microsoft Sans Serif", 10f);
			this.label3.Font = FontManager.GetFont("Microsoft Sans Serif", 10f);
			this.label2.Font = FontManager.GetFont("Microsoft Sans Serif", 10f);
			this.lblFaction.Font = FontManager.GetFont("Microsoft Sans Serif", 10f);
			this.label5.Font = FontManager.GetFont("Microsoft Sans Serif", 10f);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
		}

		// Token: 0x06002C19 RID: 11289 RVA: 0x00020608 File Offset: 0x0001E808
		public void clear()
		{
			this.m_villages = null;
			this.m_userInfo = null;
			this.imgAvatar.BackgroundImage = null;
			this.lblFaction.ForeColor = global::ARGBColors.Black;
		}

		// Token: 0x06002C1A RID: 11290 RVA: 0x0022E090 File Offset: 0x0022C290
		public void init(WorldMap.CachedUserInfo userInfo)
		{
			this.btnClose.Text = SK.Text("GENERIC_Close", "Close");
			this.lblUserName.Text = "";
			this.lblRank.Text = "";
			this.label1.Text = SK.Text("GENERIC_Points", "Points") + " : ";
			this.label3.Text = SK.Text("STATS_CATEGORY_TITLE_RANK", "Rank") + " : ";
			this.label2.Text = SK.Text("UserInfoScreen_Villages", "Villages");
			this.label5.Text = SK.Text("STATS_CATEGORY_TITLE_FACTION", "Faction") + " : ";
			this.btnSendMail.Text = SK.Text("UserInfoScreen_Send_Mail", "Send Mail");
			this.btnAchievements.Text = SK.Text("GENERIC_Achievements", "Achievements");
			this.btnInviteToFaction.Text = SK.Text("UserInfoScreen_InviteToFaction", "Invite To Faction");
			this.btnEditAvatar.Text = SK.Text("MENU_Edit_Avatar", "Edit Avatar");
			if (userInfo == null)
			{
				userInfo = new WorldMap.CachedUserInfo();
				userInfo.userID = this.m_userID;
			}
			this.m_userID = userInfo.userID;
			NumberFormatInfo nfi = GameEngine.NFI;
			WorldMap.VillageRolloverInfo villageRolloverInfo = null;
			GameEngine.Instance.World.retrieveUserData(-1, userInfo.userID, ref villageRolloverInfo, ref userInfo, true, true);
			this.btnEditAvatar.Visible = (this.m_userID == RemoteServices.Instance.UserID);
			this.m_userInfo = userInfo;
			if (userInfo != null)
			{
				this.lblUserName.Text = userInfo.userName;
				this.lblPoints.Text = userInfo.points.ToString("N", nfi);
				if (userInfo.standing >= 0)
				{
					this.lblStanding.Text = userInfo.standing.ToString("N", nfi);
				}
				else
				{
					this.lblStanding.Text = "?";
				}
				if (userInfo.avatarData != null)
				{
					this.lblRank.Text = Rankings.getRankingName(userInfo.rank, userInfo.avatarData.male);
				}
				else
				{
					this.lblRank.Text = Rankings.getRankingName(userInfo.rank);
				}
				if (userInfo.factionID >= 0)
				{
					FactionData faction = GameEngine.Instance.World.getFaction(userInfo.factionID);
					if (faction != null)
					{
						this.lblFaction.Text = faction.factionNameAbrv;
					}
					else
					{
						this.lblFaction.Text = "";
					}
				}
				else
				{
					this.lblFaction.Text = "";
				}
				if (userInfo.avatarData != null && this.imgAvatar.BackgroundImage == null)
				{
					this.imgAvatar.BackgroundImage = Avatar.CreateAvatar(userInfo.avatarData, global::ARGBColors.Transparent);
				}
				if (!this.areEqual(userInfo.villages, this.m_villages))
				{
					this.m_villages = userInfo.villages;
					this.addVillages(this.m_villages);
				}
				if (!RemoteServices.Instance.Admin && !RemoteServices.Instance.Moderator)
				{
					this.lblIsAdmin.Visible = false;
					this.lblIsModerator.Visible = false;
					this.gbModerator.Visible = false;
				}
				else
				{
					this.gbModerator.Visible = true;
					this.lblIsAdmin.Visible = RemoteServices.Instance.Admin;
					this.lblIsModerator.Visible = RemoteServices.Instance.Moderator;
					this.btnChatBan7.Visible = RemoteServices.Instance.Admin;
					this.btnChatBanPerma.Visible = RemoteServices.Instance.Admin;
					this.btnMailBanClear.Visible = RemoteServices.Instance.Admin;
					this.btnMailBan1.Visible = RemoteServices.Instance.Admin;
					this.btnMailBan3.Visible = RemoteServices.Instance.Admin;
					this.btnMailBan7.Visible = RemoteServices.Instance.Admin;
					this.btnMailBanPerma.Visible = RemoteServices.Instance.Admin;
					this.btnForumBan7.Visible = RemoteServices.Instance.Admin;
					this.btnForumBanPerma.Visible = RemoteServices.Instance.Admin;
					this.btnWalBan7.Visible = RemoteServices.Instance.Admin;
					this.btnWalBanPerma.Visible = RemoteServices.Instance.Admin;
					this.btnMakeModerator.Visible = false;
					this.btnRemoveModerator.Visible = false;
					this.lblGold.Visible = RemoteServices.Instance.Admin;
					this.lblHonour.Visible = RemoteServices.Instance.Admin;
					this.lblRP.Visible = RemoteServices.Instance.Admin;
					this.tbGold.Visible = RemoteServices.Instance.Admin;
					this.tbHonour.Visible = RemoteServices.Instance.Admin;
					this.tbRP.Visible = RemoteServices.Instance.Admin;
					this.btnApplyGold.Visible = RemoteServices.Instance.Admin;
					this.btnApplyHonour.Visible = RemoteServices.Instance.Admin;
					this.btnApplyRP.Visible = RemoteServices.Instance.Admin;
					this.btnFlushCaches.Visible = RemoteServices.Instance.Admin;
					if (RemoteServices.Instance.Admin)
					{
						this.tbStuff.Text = userInfo.stuff.Replace("-", "");
					}
					this.btnFixAchievements.Visible = RemoteServices.Instance.Admin;
					this.btnGiveQuests.Visible = RemoteServices.Instance.Admin;
				}
			}
			else
			{
				this.lblUserName.Text = "";
				this.lblPoints.Text = "0";
				this.lblStanding.Text = "0";
				this.lblRank.Text = "";
				this.lblFaction.Text = "";
				this.imgAvatar.BackgroundImage = null;
				this.lblIsAdmin.Visible = false;
				this.lblIsModerator.Visible = false;
				this.gbModerator.Visible = false;
			}
			int yourFactionRank = GameEngine.Instance.World.getYourFactionRank();
			bool visible = false;
			FactionData yourFaction = GameEngine.Instance.World.YourFaction;
			if (yourFaction != null && this.m_userInfo != null && this.m_userInfo.userID != RemoteServices.Instance.UserID)
			{
				FactionMemberData[] factionMembers = GameEngine.Instance.World.FactionMembers;
				if (factionMembers != null && yourFactionRank > 0 && factionMembers.Length < GameEngine.Instance.LocalWorldData.Faction_MaxMembers)
				{
					visible = true;
				}
			}
			this.btnInviteToFaction.Visible = visible;
		}

		// Token: 0x06002C1B RID: 11291 RVA: 0x0022E738 File Offset: 0x0022C938
		private bool areEqual(int[] villages1, int[] villages2)
		{
			if (villages1 == null && villages2 == null)
			{
				return true;
			}
			if (villages1 == null || villages2 == null)
			{
				return false;
			}
			if (villages1.Length != villages2.Length)
			{
				return false;
			}
			List<int> list = new List<int>();
			list.AddRange(villages2);
			foreach (int item in villages1)
			{
				if (!list.Contains(item))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06002C1C RID: 11292 RVA: 0x00020634 File Offset: 0x0001E834
		public void update()
		{
			this.init(this.m_userInfo);
		}

		// Token: 0x06002C1D RID: 11293 RVA: 0x0022E78C File Offset: 0x0022C98C
		private void addVillages(int[] villages)
		{
			int y = this.pnlVillages.AutoScrollPosition.Y;
			this.lineList.Clear();
			this.pnlVillages.SuspendLayout();
			this.pnlVillages.Controls.Clear();
			int num = 0;
			if (villages != null)
			{
				foreach (int villageID in villages)
				{
					UserinfoScreenLine userinfoScreenLine = new UserinfoScreenLine();
					userinfoScreenLine.Location = new Point(0, num);
					userinfoScreenLine.init(GameEngine.Instance.World.getVillageName(villageID), villageID);
					this.pnlVillages.Controls.Add(userinfoScreenLine);
					num += userinfoScreenLine.Height;
					this.lineList.Add(userinfoScreenLine);
				}
			}
			this.pnlVillages.ResumeLayout(false);
			this.pnlVillages.PerformLayout();
		}

		// Token: 0x06002C1E RID: 11294 RVA: 0x00020642 File Offset: 0x0001E842
		private void btnClose_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("UserInfoScreen_close");
			InterfaceMgr.Instance.closeParishPanel();
		}

		// Token: 0x06002C1F RID: 11295 RVA: 0x0002065D File Offset: 0x0001E85D
		private void lblFaction_MouseEnter(object sender, EventArgs e)
		{
			this.lblFaction.ForeColor = global::ARGBColors.Blue;
		}

		// Token: 0x06002C20 RID: 11296 RVA: 0x0002066F File Offset: 0x0001E86F
		private void lblFaction_MouseLeave(object sender, EventArgs e)
		{
			this.lblFaction.ForeColor = global::ARGBColors.Black;
		}

		// Token: 0x06002C21 RID: 11297 RVA: 0x0022E85C File Offset: 0x0022CA5C
		private void btnSendMail_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("UserInfoScreen_send_mail");
			if (this.m_userInfo != null)
			{
				InterfaceMgr.Instance.getMainTabBar().selectDummyTab(21);
				InterfaceMgr.Instance.mailTo(this.m_userInfo.userID, this.m_userInfo.userName);
			}
		}

		// Token: 0x06002C22 RID: 11298 RVA: 0x00020681 File Offset: 0x0001E881
		private void btnChatBan1_Click(object sender, EventArgs e)
		{
			this.sendCommandToServer(1, 1);
		}

		// Token: 0x06002C23 RID: 11299 RVA: 0x0002068B File Offset: 0x0001E88B
		private void btnChatBan3_Click(object sender, EventArgs e)
		{
			this.sendCommandToServer(1, 3);
		}

		// Token: 0x06002C24 RID: 11300 RVA: 0x00020695 File Offset: 0x0001E895
		private void btnChatBan7_Click(object sender, EventArgs e)
		{
			this.sendCommandToServer(1, 7);
		}

		// Token: 0x06002C25 RID: 11301 RVA: 0x0002069F File Offset: 0x0001E89F
		private void btnChatBanPerma_Click(object sender, EventArgs e)
		{
			this.sendCommandToServer(1, 3650);
		}

		// Token: 0x06002C26 RID: 11302 RVA: 0x000206AD File Offset: 0x0001E8AD
		private void btnChatBanClear_Click(object sender, EventArgs e)
		{
			this.sendCommandToServer(1, -1);
		}

		// Token: 0x06002C27 RID: 11303 RVA: 0x000206B7 File Offset: 0x0001E8B7
		private void btnMailBan1_Click(object sender, EventArgs e)
		{
			this.sendCommandToServer(2, 1);
		}

		// Token: 0x06002C28 RID: 11304 RVA: 0x000206C1 File Offset: 0x0001E8C1
		private void btnMailBan3_Click(object sender, EventArgs e)
		{
			this.sendCommandToServer(2, 3);
		}

		// Token: 0x06002C29 RID: 11305 RVA: 0x000206CB File Offset: 0x0001E8CB
		private void btnMailBan7_Click(object sender, EventArgs e)
		{
			this.sendCommandToServer(2, 7);
		}

		// Token: 0x06002C2A RID: 11306 RVA: 0x000206D5 File Offset: 0x0001E8D5
		private void btnMailBanPerma_Click(object sender, EventArgs e)
		{
			this.sendCommandToServer(2, 3650);
		}

		// Token: 0x06002C2B RID: 11307 RVA: 0x000206E3 File Offset: 0x0001E8E3
		private void btnMailBanClear_Click(object sender, EventArgs e)
		{
			this.sendCommandToServer(2, -1);
		}

		// Token: 0x06002C2C RID: 11308 RVA: 0x000206ED File Offset: 0x0001E8ED
		private void btnForumBan1_Click(object sender, EventArgs e)
		{
			this.sendCommandToServer(3, 1);
		}

		// Token: 0x06002C2D RID: 11309 RVA: 0x000206F7 File Offset: 0x0001E8F7
		private void btnForumBan3_Click(object sender, EventArgs e)
		{
			this.sendCommandToServer(3, 3);
		}

		// Token: 0x06002C2E RID: 11310 RVA: 0x00020701 File Offset: 0x0001E901
		private void btnForumBan7_Click(object sender, EventArgs e)
		{
			this.sendCommandToServer(3, 7);
		}

		// Token: 0x06002C2F RID: 11311 RVA: 0x0002070B File Offset: 0x0001E90B
		private void btnForumBanPerma_Click(object sender, EventArgs e)
		{
			this.sendCommandToServer(3, 3650);
		}

		// Token: 0x06002C30 RID: 11312 RVA: 0x00020719 File Offset: 0x0001E919
		private void btnForumBanClear_Click(object sender, EventArgs e)
		{
			this.sendCommandToServer(3, -1);
		}

		// Token: 0x06002C31 RID: 11313 RVA: 0x00020723 File Offset: 0x0001E923
		private void btnWalBan1_Click(object sender, EventArgs e)
		{
			this.sendCommandToServer(4, 1);
		}

		// Token: 0x06002C32 RID: 11314 RVA: 0x0002072D File Offset: 0x0001E92D
		private void btnWalBan3_Click(object sender, EventArgs e)
		{
			this.sendCommandToServer(4, 3);
		}

		// Token: 0x06002C33 RID: 11315 RVA: 0x00020737 File Offset: 0x0001E937
		private void btnWalBan7_Click(object sender, EventArgs e)
		{
			this.sendCommandToServer(4, 7);
		}

		// Token: 0x06002C34 RID: 11316 RVA: 0x00020741 File Offset: 0x0001E941
		private void btnWalBanPerma_Click(object sender, EventArgs e)
		{
			this.sendCommandToServer(4, 3650);
		}

		// Token: 0x06002C35 RID: 11317 RVA: 0x0002074F File Offset: 0x0001E94F
		private void btnWalBanClear_Click(object sender, EventArgs e)
		{
			this.sendCommandToServer(4, -1);
		}

		// Token: 0x06002C36 RID: 11318 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void btnMakeModerator_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06002C37 RID: 11319 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void btnRemoveModerator_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06002C38 RID: 11320 RVA: 0x0022E8B4 File Offset: 0x0022CAB4
		private void sendCommandToServer(int command, int duration)
		{
			bool flag = false;
			if (RemoteServices.Instance.Admin && this.m_userID == RemoteServices.Instance.UserID && (command - 21 <= 2 || command == 1000))
			{
				flag = true;
			}
			if ((this.m_userID == RemoteServices.Instance.UserID || (!RemoteServices.Instance.Admin && !RemoteServices.Instance.Moderator)) && !flag)
			{
				MyMessageBox.Show("Command not sent", "Admin Error");
				return;
			}
			this.m_reasonString = "";
			ReasonPopup reasonPopup = new ReasonPopup();
			reasonPopup.init(this);
			reasonPopup.ShowDialog();
			if (this.m_reasonString.Length > 0)
			{
				RemoteServices.Instance.SendCommands(this.m_userID, command, duration, this.m_reasonString);
				return;
			}
			MyMessageBox.Show("Not reason given", "Admin Error");
		}

		// Token: 0x06002C39 RID: 11321 RVA: 0x00020759 File Offset: 0x0001E959
		public void setReasonString(string reasonString)
		{
			this.m_reasonString = reasonString;
		}

		// Token: 0x06002C3A RID: 11322 RVA: 0x0022E98C File Offset: 0x0022CB8C
		private void btnApplyGold_Click(object sender, EventArgs e)
		{
			if (RemoteServices.Instance.Admin)
			{
				int int32FromString = UserInfoScreen.getInt32FromString(this.tbGold.Text);
				if (int32FromString > 0 && int32FromString < 1000000)
				{
					this.sendCommandToServer(21, int32FromString);
					return;
				}
				MyMessageBox.Show("Out of range", "Admin Error");
			}
		}

		// Token: 0x06002C3B RID: 11323 RVA: 0x0022E9DC File Offset: 0x0022CBDC
		private void btnApplyHonour_Click(object sender, EventArgs e)
		{
			if (RemoteServices.Instance.Admin)
			{
				int int32FromString = UserInfoScreen.getInt32FromString(this.tbHonour.Text);
				if (int32FromString > 0 && int32FromString < 10000000)
				{
					this.sendCommandToServer(22, int32FromString);
					return;
				}
				MyMessageBox.Show("Out of range", "Admin Error");
			}
		}

		// Token: 0x06002C3C RID: 11324 RVA: 0x0022EA2C File Offset: 0x0022CC2C
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

		// Token: 0x06002C3D RID: 11325 RVA: 0x0022EA64 File Offset: 0x0022CC64
		private void btnApplyRP_Click(object sender, EventArgs e)
		{
			if (RemoteServices.Instance.Admin)
			{
				int int32FromString = UserInfoScreen.getInt32FromString(this.tbRP.Text);
				if (int32FromString > 0 && int32FromString < 5)
				{
					this.sendCommandToServer(23, int32FromString);
					return;
				}
				MyMessageBox.Show("Out of range", "Admin Error");
			}
		}

		// Token: 0x06002C3E RID: 11326 RVA: 0x00020762 File Offset: 0x0001E962
		private void btnFlushCaches_Click(object sender, EventArgs e)
		{
			if (RemoteServices.Instance.Admin)
			{
				this.sendCommandToServer(31, 0);
			}
		}

		// Token: 0x06002C3F RID: 11327 RVA: 0x00020779 File Offset: 0x0001E979
		private void btnKick_Click(object sender, EventArgs e)
		{
			RemoteServices.Instance.Chat_Admin_Command(5, this.m_userID);
		}

		// Token: 0x06002C40 RID: 11328 RVA: 0x0002078C File Offset: 0x0001E98C
		private void lblUserName_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				Clipboard.SetText(((Label)sender).Text);
			}
		}

		// Token: 0x06002C41 RID: 11329 RVA: 0x0022EAB0 File Offset: 0x0022CCB0
		private void lblFaction_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && this.m_userInfo != null && this.m_userInfo.factionID >= 0)
			{
				GameEngine.Instance.playInterfaceSound("UserInfoScreen_faction");
				InterfaceMgr.Instance.closeParishPanel();
				InterfaceMgr.Instance.showFactionPanel(this.m_userInfo.factionID);
			}
			if (e.Button == MouseButtons.Right)
			{
				Clipboard.SetText(((Label)sender).Text);
			}
		}

		// Token: 0x06002C42 RID: 11330 RVA: 0x000207AB File Offset: 0x0001E9AB
		private void btnAchievements_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("UserInfoScreen_achievements");
			InterfaceMgr.Instance.openAchievements(this.m_userInfo.achievements);
		}

		// Token: 0x06002C43 RID: 11331 RVA: 0x000207D1 File Offset: 0x0001E9D1
		private void btnInviteToFaction_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("UserInfoScreen_faction_invite");
			InterfaceMgr.Instance.clearControls();
			InterfaceMgr.Instance.inviteToFaction(this.m_userInfo.userName);
		}

		// Token: 0x06002C44 RID: 11332 RVA: 0x0022EB2C File Offset: 0x0022CD2C
		private void UserInfoScreen_Paint(object sender, PaintEventArgs e)
		{
			Rectangle rect = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, Color.FromArgb(86, 98, 106), Color.FromArgb(159, 180, 193), LinearGradientMode.Vertical);
			e.Graphics.FillRectangle(linearGradientBrush, rect);
			linearGradientBrush.Dispose();
		}

		// Token: 0x06002C45 RID: 11333 RVA: 0x00020801 File Offset: 0x0001EA01
		private void UserInfoScreen_Resize(object sender, EventArgs e)
		{
			base.Invalidate();
		}

		// Token: 0x06002C46 RID: 11334 RVA: 0x00020809 File Offset: 0x0001EA09
		private void bitmapButton1_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("UserInfoScreen_edit_avatar");
			InterfaceMgr.Instance.getMainTabBar().selectDummyTab(10);
		}

		// Token: 0x06002C47 RID: 11335 RVA: 0x0002082B File Offset: 0x0001EA2B
		private void btnFixAchievements_Click(object sender, EventArgs e)
		{
			this.sendCommandToServer(42, 0);
		}

		// Token: 0x06002C48 RID: 11336 RVA: 0x00020836 File Offset: 0x0001EA36
		private void btnGiveQuests_Click(object sender, EventArgs e)
		{
			this.sendCommandToServer(43, 0);
		}

		// Token: 0x06002C49 RID: 11337 RVA: 0x00020841 File Offset: 0x0001EA41
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06002C4A RID: 11338 RVA: 0x00020851 File Offset: 0x0001EA51
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06002C4B RID: 11339 RVA: 0x00020861 File Offset: 0x0001EA61
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06002C4C RID: 11340 RVA: 0x00020873 File Offset: 0x0001EA73
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06002C4D RID: 11341 RVA: 0x00020880 File Offset: 0x0001EA80
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x06002C4E RID: 11342 RVA: 0x0002088E File Offset: 0x0001EA8E
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06002C4F RID: 11343 RVA: 0x0002089B File Offset: 0x0001EA9B
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06002C50 RID: 11344 RVA: 0x000208A8 File Offset: 0x0001EAA8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002C51 RID: 11345 RVA: 0x0022EB8C File Offset: 0x0022CD8C
		private void InitializeComponent()
		{
			this.pnlVillages = new Panel();
			this.lblUserName = new Label();
			this.lblRank = new Label();
			this.label1 = new Label();
			this.lblPoints = new Label();
			this.lblStanding = new Label();
			this.label3 = new Label();
			this.label2 = new Label();
			this.lblFaction = new Label();
			this.label5 = new Label();
			this.imgAvatar = new UserControl();
			this.lblIsAdmin = new Label();
			this.lblIsModerator = new Label();
			this.gbModerator = new GroupBox();
			this.btnFixAchievements = new BitmapButton();
			this.tbStuff = new TextBox();
			this.btnKick = new BitmapButton();
			this.btnFlushCaches = new BitmapButton();
			this.btnApplyRP = new BitmapButton();
			this.tbRP = new TextBox();
			this.lblRP = new Label();
			this.btnApplyHonour = new BitmapButton();
			this.btnApplyGold = new BitmapButton();
			this.tbHonour = new TextBox();
			this.tbGold = new TextBox();
			this.lblHonour = new Label();
			this.lblGold = new Label();
			this.btnRemoveModerator = new BitmapButton();
			this.btnMakeModerator = new BitmapButton();
			this.btnWalBanClear = new BitmapButton();
			this.btnWalBanPerma = new BitmapButton();
			this.btnWalBan7 = new BitmapButton();
			this.btnWalBan3 = new BitmapButton();
			this.label9 = new Label();
			this.btnWalBan1 = new BitmapButton();
			this.btnForumBanClear = new BitmapButton();
			this.btnForumBanPerma = new BitmapButton();
			this.btnForumBan7 = new BitmapButton();
			this.btnForumBan3 = new BitmapButton();
			this.label8 = new Label();
			this.btnForumBan1 = new BitmapButton();
			this.btnMailBanClear = new BitmapButton();
			this.btnMailBanPerma = new BitmapButton();
			this.btnMailBan7 = new BitmapButton();
			this.btnMailBan3 = new BitmapButton();
			this.label7 = new Label();
			this.btnMailBan1 = new BitmapButton();
			this.btnChatBanClear = new BitmapButton();
			this.btnChatBanPerma = new BitmapButton();
			this.btnChatBan7 = new BitmapButton();
			this.btnChatBan3 = new BitmapButton();
			this.label6 = new Label();
			this.btnChatBan1 = new BitmapButton();
			this.label4 = new Label();
			this.btnEditAvatar = new BitmapButton();
			this.btnInviteToFaction = new BitmapButton();
			this.btnAchievements = new BitmapButton();
			this.btnSendMail = new BitmapButton();
			this.btnClose = new BitmapButton();
			this.btnGiveQuests = new BitmapButton();
			this.gbModerator.SuspendLayout();
			base.SuspendLayout();
			this.pnlVillages.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);
			this.pnlVillages.AutoScroll = true;
			this.pnlVillages.BackColor = Color.FromArgb(96, 109, 118);
			this.pnlVillages.Location = new Point(23, 317);
			this.pnlVillages.Name = "pnlVillages";
			this.pnlVillages.Size = new Size(336, 221);
			this.pnlVillages.TabIndex = 9;
			this.lblUserName.AutoSize = true;
			this.lblUserName.BackColor = Color.FromArgb(0, 255, 255, 255);
			this.lblUserName.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblUserName.Location = new Point(36, 19);
			this.lblUserName.Name = "lblUserName";
			this.lblUserName.Size = new Size(93, 20);
			this.lblUserName.TabIndex = 10;
			this.lblUserName.Text = "UserName";
			this.lblUserName.MouseClick += this.lblUserName_MouseClick;
			this.lblRank.AutoSize = true;
			this.lblRank.BackColor = Color.FromArgb(0, 255, 255, 255);
			this.lblRank.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.lblRank.Location = new Point(37, 49);
			this.lblRank.Name = "lblRank";
			this.lblRank.Size = new Size(43, 17);
			this.lblRank.TabIndex = 11;
			this.lblRank.Text = "name";
			this.label1.AutoSize = true;
			this.label1.BackColor = Color.FromArgb(0, 255, 255, 255);
			this.label1.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(37, 108);
			this.label1.Name = "label1";
			this.label1.Size = new Size(59, 17);
			this.label1.TabIndex = 12;
			this.label1.Text = "Points : ";
			this.lblPoints.AutoSize = true;
			this.lblPoints.BackColor = Color.FromArgb(0, 255, 255, 255);
			this.lblPoints.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.lblPoints.Location = new Point(113, 108);
			this.lblPoints.Name = "lblPoints";
			this.lblPoints.Size = new Size(16, 17);
			this.lblPoints.TabIndex = 13;
			this.lblPoints.Text = "0";
			this.lblStanding.AutoSize = true;
			this.lblStanding.BackColor = Color.FromArgb(0, 255, 255, 255);
			this.lblStanding.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.lblStanding.Location = new Point(113, 148);
			this.lblStanding.Name = "lblStanding";
			this.lblStanding.Size = new Size(16, 17);
			this.lblStanding.TabIndex = 15;
			this.lblStanding.Text = "0";
			this.label3.AutoSize = true;
			this.label3.BackColor = Color.FromArgb(0, 255, 255, 255);
			this.label3.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label3.Location = new Point(37, 148);
			this.label3.Name = "label3";
			this.label3.Size = new Size(49, 17);
			this.label3.TabIndex = 14;
			this.label3.Text = "Rank :";
			this.label2.AutoSize = true;
			this.label2.BackColor = Color.FromArgb(0, 255, 255, 255);
			this.label2.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label2.Location = new Point(29, 297);
			this.label2.Name = "label2";
			this.label2.Size = new Size(57, 17);
			this.label2.TabIndex = 16;
			this.label2.Text = "Villages";
			this.lblFaction.AutoSize = true;
			this.lblFaction.BackColor = Color.FromArgb(0, 255, 255, 255);
			this.lblFaction.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Underline, GraphicsUnit.Point, 0);
			this.lblFaction.Location = new Point(113, 235);
			this.lblFaction.Name = "lblFaction";
			this.lblFaction.Size = new Size(24, 17);
			this.lblFaction.TabIndex = 18;
			this.lblFaction.Text = "....";
			this.lblFaction.MouseLeave += this.lblFaction_MouseLeave;
			this.lblFaction.MouseClick += this.lblFaction_MouseClick;
			this.lblFaction.MouseEnter += this.lblFaction_MouseEnter;
			this.label5.AutoSize = true;
			this.label5.BackColor = Color.FromArgb(0, 255, 255, 255);
			this.label5.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label5.Location = new Point(37, 235);
			this.label5.Name = "label5";
			this.label5.Size = new Size(62, 17);
			this.label5.TabIndex = 17;
			this.label5.Text = "Faction :";
			this.imgAvatar.BackColor = Color.FromArgb(0, 255, 255, 255);
			this.imgAvatar.Location = new Point(616, 19);
			this.imgAvatar.Name = "imgAvatar";
			this.imgAvatar.Size = new Size(154, 500);
			this.imgAvatar.TabIndex = 19;
			this.lblIsAdmin.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.lblIsAdmin.AutoSize = true;
			this.lblIsAdmin.BackColor = Color.FromArgb(0, 255, 255, 255);
			this.lblIsAdmin.Location = new Point(385, 213);
			this.lblIsAdmin.Name = "lblIsAdmin";
			this.lblIsAdmin.Size = new Size(47, 13);
			this.lblIsAdmin.TabIndex = 21;
			this.lblIsAdmin.Text = "Is Admin";
			this.lblIsAdmin.Visible = false;
			this.lblIsModerator.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.lblIsModerator.AutoSize = true;
			this.lblIsModerator.BackColor = Color.FromArgb(0, 255, 255, 255);
			this.lblIsModerator.Location = new Point(438, 213);
			this.lblIsModerator.Name = "lblIsModerator";
			this.lblIsModerator.Size = new Size(66, 13);
			this.lblIsModerator.TabIndex = 22;
			this.lblIsModerator.Text = "Is Moderator";
			this.lblIsModerator.Visible = false;
			this.gbModerator.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.gbModerator.BackColor = Color.FromArgb(0, 255, 255, 255);
			this.gbModerator.Controls.Add(this.btnGiveQuests);
			this.gbModerator.Controls.Add(this.btnFixAchievements);
			this.gbModerator.Controls.Add(this.tbStuff);
			this.gbModerator.Controls.Add(this.btnKick);
			this.gbModerator.Controls.Add(this.btnFlushCaches);
			this.gbModerator.Controls.Add(this.btnApplyRP);
			this.gbModerator.Controls.Add(this.tbRP);
			this.gbModerator.Controls.Add(this.lblRP);
			this.gbModerator.Controls.Add(this.btnApplyHonour);
			this.gbModerator.Controls.Add(this.btnApplyGold);
			this.gbModerator.Controls.Add(this.tbHonour);
			this.gbModerator.Controls.Add(this.tbGold);
			this.gbModerator.Controls.Add(this.lblHonour);
			this.gbModerator.Controls.Add(this.lblGold);
			this.gbModerator.Controls.Add(this.btnRemoveModerator);
			this.gbModerator.Controls.Add(this.btnMakeModerator);
			this.gbModerator.Controls.Add(this.btnWalBanClear);
			this.gbModerator.Controls.Add(this.btnWalBanPerma);
			this.gbModerator.Controls.Add(this.btnWalBan7);
			this.gbModerator.Controls.Add(this.btnWalBan3);
			this.gbModerator.Controls.Add(this.label9);
			this.gbModerator.Controls.Add(this.btnWalBan1);
			this.gbModerator.Controls.Add(this.btnForumBanClear);
			this.gbModerator.Controls.Add(this.btnForumBanPerma);
			this.gbModerator.Controls.Add(this.btnForumBan7);
			this.gbModerator.Controls.Add(this.btnForumBan3);
			this.gbModerator.Controls.Add(this.label8);
			this.gbModerator.Controls.Add(this.btnForumBan1);
			this.gbModerator.Controls.Add(this.btnMailBanClear);
			this.gbModerator.Controls.Add(this.btnMailBanPerma);
			this.gbModerator.Controls.Add(this.btnMailBan7);
			this.gbModerator.Controls.Add(this.btnMailBan3);
			this.gbModerator.Controls.Add(this.label7);
			this.gbModerator.Controls.Add(this.btnMailBan1);
			this.gbModerator.Controls.Add(this.btnChatBanClear);
			this.gbModerator.Controls.Add(this.btnChatBanPerma);
			this.gbModerator.Controls.Add(this.btnChatBan7);
			this.gbModerator.Controls.Add(this.btnChatBan3);
			this.gbModerator.Controls.Add(this.label6);
			this.gbModerator.Controls.Add(this.btnChatBan1);
			this.gbModerator.Controls.Add(this.label4);
			this.gbModerator.Location = new Point(365, 229);
			this.gbModerator.Name = "gbModerator";
			this.gbModerator.Size = new Size(245, 325);
			this.gbModerator.TabIndex = 23;
			this.gbModerator.TabStop = false;
			this.gbModerator.Text = "Moderating Functions";
			this.gbModerator.Visible = false;
			this.btnFixAchievements.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnFixAchievements.BorderDrawing = true;
			this.btnFixAchievements.FocusRectangleEnabled = false;
			this.btnFixAchievements.Image = null;
			this.btnFixAchievements.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnFixAchievements.ImageBorderEnabled = true;
			this.btnFixAchievements.ImageDropShadow = true;
			this.btnFixAchievements.ImageFocused = null;
			this.btnFixAchievements.ImageInactive = null;
			this.btnFixAchievements.ImageMouseOver = null;
			this.btnFixAchievements.ImageNormal = null;
			this.btnFixAchievements.ImagePressed = null;
			this.btnFixAchievements.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnFixAchievements.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnFixAchievements.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnFixAchievements.Location = new Point(12, 302);
			this.btnFixAchievements.Name = "btnFixAchievements";
			this.btnFixAchievements.OffsetPressedContent = true;
			this.btnFixAchievements.Padding2 = 5;
			this.btnFixAchievements.Size = new Size(108, 23);
			this.btnFixAchievements.StretchImage = false;
			this.btnFixAchievements.TabIndex = 41;
			this.btnFixAchievements.Text = "Fix Achievements";
			this.btnFixAchievements.TextDropShadow = false;
			this.btnFixAchievements.UseVisualStyleBackColor = true;
			this.btnFixAchievements.Click += this.btnFixAchievements_Click;
			this.tbStuff.Location = new Point(12, 280);
			this.tbStuff.Name = "tbStuff";
			this.tbStuff.ReadOnly = true;
			this.tbStuff.Size = new Size(227, 20);
			this.tbStuff.TabIndex = 40;
			this.btnKick.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnKick.BorderDrawing = true;
			this.btnKick.FocusRectangleEnabled = false;
			this.btnKick.Image = null;
			this.btnKick.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnKick.ImageBorderEnabled = true;
			this.btnKick.ImageDropShadow = true;
			this.btnKick.ImageFocused = null;
			this.btnKick.ImageInactive = null;
			this.btnKick.ImageMouseOver = null;
			this.btnKick.ImageNormal = null;
			this.btnKick.ImagePressed = null;
			this.btnKick.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnKick.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnKick.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnKick.Location = new Point(214, 31);
			this.btnKick.Name = "btnKick";
			this.btnKick.OffsetPressedContent = true;
			this.btnKick.Padding2 = 5;
			this.btnKick.Size = new Size(25, 23);
			this.btnKick.StretchImage = false;
			this.btnKick.TabIndex = 39;
			this.btnKick.Text = "K";
			this.btnKick.TextDropShadow = false;
			this.btnKick.UseVisualStyleBackColor = true;
			this.btnKick.Click += this.btnKick_Click;
			this.btnFlushCaches.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnFlushCaches.BorderDrawing = true;
			this.btnFlushCaches.FocusRectangleEnabled = false;
			this.btnFlushCaches.Image = null;
			this.btnFlushCaches.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnFlushCaches.ImageBorderEnabled = true;
			this.btnFlushCaches.ImageDropShadow = true;
			this.btnFlushCaches.ImageFocused = null;
			this.btnFlushCaches.ImageInactive = null;
			this.btnFlushCaches.ImageMouseOver = null;
			this.btnFlushCaches.ImageNormal = null;
			this.btnFlushCaches.ImagePressed = null;
			this.btnFlushCaches.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnFlushCaches.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnFlushCaches.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnFlushCaches.Location = new Point(44, 254);
			this.btnFlushCaches.Name = "btnFlushCaches";
			this.btnFlushCaches.OffsetPressedContent = true;
			this.btnFlushCaches.Padding2 = 5;
			this.btnFlushCaches.Size = new Size(151, 23);
			this.btnFlushCaches.StretchImage = false;
			this.btnFlushCaches.TabIndex = 38;
			this.btnFlushCaches.Text = "Flush Client Village Cache";
			this.btnFlushCaches.TextDropShadow = false;
			this.btnFlushCaches.UseVisualStyleBackColor = true;
			this.btnFlushCaches.Click += this.btnFlushCaches_Click;
			this.btnApplyRP.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnApplyRP.BorderDrawing = true;
			this.btnApplyRP.FocusRectangleEnabled = false;
			this.btnApplyRP.Image = null;
			this.btnApplyRP.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnApplyRP.ImageBorderEnabled = true;
			this.btnApplyRP.ImageDropShadow = true;
			this.btnApplyRP.ImageFocused = null;
			this.btnApplyRP.ImageInactive = null;
			this.btnApplyRP.ImageMouseOver = null;
			this.btnApplyRP.ImageNormal = null;
			this.btnApplyRP.ImagePressed = null;
			this.btnApplyRP.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnApplyRP.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnApplyRP.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnApplyRP.Location = new Point(182, 228);
			this.btnApplyRP.Name = "btnApplyRP";
			this.btnApplyRP.OffsetPressedContent = true;
			this.btnApplyRP.Padding2 = 5;
			this.btnApplyRP.Size = new Size(57, 23);
			this.btnApplyRP.StretchImage = false;
			this.btnApplyRP.TabIndex = 37;
			this.btnApplyRP.Text = "Give";
			this.btnApplyRP.TextDropShadow = false;
			this.btnApplyRP.UseVisualStyleBackColor = true;
			this.btnApplyRP.Click += this.btnApplyRP_Click;
			this.tbRP.Location = new Point(76, 229);
			this.tbRP.Name = "tbRP";
			this.tbRP.Size = new Size(100, 20);
			this.tbRP.TabIndex = 36;
			this.lblRP.AutoSize = true;
			this.lblRP.BackColor = Color.FromArgb(0, 255, 255, 255);
			this.lblRP.Location = new Point(9, 233);
			this.lblRP.Name = "lblRP";
			this.lblRP.Size = new Size(22, 13);
			this.lblRP.TabIndex = 35;
			this.lblRP.Text = "RP";
			this.btnApplyHonour.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnApplyHonour.BorderDrawing = true;
			this.btnApplyHonour.FocusRectangleEnabled = false;
			this.btnApplyHonour.Image = null;
			this.btnApplyHonour.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnApplyHonour.ImageBorderEnabled = true;
			this.btnApplyHonour.ImageDropShadow = true;
			this.btnApplyHonour.ImageFocused = null;
			this.btnApplyHonour.ImageInactive = null;
			this.btnApplyHonour.ImageMouseOver = null;
			this.btnApplyHonour.ImageNormal = null;
			this.btnApplyHonour.ImagePressed = null;
			this.btnApplyHonour.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnApplyHonour.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnApplyHonour.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnApplyHonour.Location = new Point(182, 202);
			this.btnApplyHonour.Name = "btnApplyHonour";
			this.btnApplyHonour.OffsetPressedContent = true;
			this.btnApplyHonour.Padding2 = 5;
			this.btnApplyHonour.Size = new Size(57, 23);
			this.btnApplyHonour.StretchImage = false;
			this.btnApplyHonour.TabIndex = 34;
			this.btnApplyHonour.Text = "Give";
			this.btnApplyHonour.TextDropShadow = false;
			this.btnApplyHonour.UseVisualStyleBackColor = true;
			this.btnApplyHonour.Click += this.btnApplyHonour_Click;
			this.btnApplyGold.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnApplyGold.BorderDrawing = true;
			this.btnApplyGold.FocusRectangleEnabled = false;
			this.btnApplyGold.Image = null;
			this.btnApplyGold.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnApplyGold.ImageBorderEnabled = true;
			this.btnApplyGold.ImageDropShadow = true;
			this.btnApplyGold.ImageFocused = null;
			this.btnApplyGold.ImageInactive = null;
			this.btnApplyGold.ImageMouseOver = null;
			this.btnApplyGold.ImageNormal = null;
			this.btnApplyGold.ImagePressed = null;
			this.btnApplyGold.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnApplyGold.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnApplyGold.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnApplyGold.Location = new Point(182, 176);
			this.btnApplyGold.Name = "btnApplyGold";
			this.btnApplyGold.OffsetPressedContent = true;
			this.btnApplyGold.Padding2 = 5;
			this.btnApplyGold.Size = new Size(57, 23);
			this.btnApplyGold.StretchImage = false;
			this.btnApplyGold.TabIndex = 33;
			this.btnApplyGold.Text = "Give";
			this.btnApplyGold.TextDropShadow = false;
			this.btnApplyGold.UseVisualStyleBackColor = true;
			this.btnApplyGold.Click += this.btnApplyGold_Click;
			this.tbHonour.Location = new Point(76, 203);
			this.tbHonour.Name = "tbHonour";
			this.tbHonour.Size = new Size(100, 20);
			this.tbHonour.TabIndex = 32;
			this.tbGold.Location = new Point(76, 178);
			this.tbGold.Name = "tbGold";
			this.tbGold.Size = new Size(100, 20);
			this.tbGold.TabIndex = 31;
			this.lblHonour.AutoSize = true;
			this.lblHonour.BackColor = Color.FromArgb(0, 255, 255, 255);
			this.lblHonour.Location = new Point(9, 207);
			this.lblHonour.Name = "lblHonour";
			this.lblHonour.Size = new Size(42, 13);
			this.lblHonour.TabIndex = 30;
			this.lblHonour.Text = "Honour";
			this.lblGold.AutoSize = true;
			this.lblGold.BackColor = Color.FromArgb(0, 255, 255, 255);
			this.lblGold.Location = new Point(9, 181);
			this.lblGold.Name = "lblGold";
			this.lblGold.Size = new Size(29, 13);
			this.lblGold.TabIndex = 29;
			this.lblGold.Text = "Gold";
			this.btnRemoveModerator.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnRemoveModerator.BorderDrawing = true;
			this.btnRemoveModerator.FocusRectangleEnabled = false;
			this.btnRemoveModerator.Image = null;
			this.btnRemoveModerator.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnRemoveModerator.ImageBorderEnabled = true;
			this.btnRemoveModerator.ImageDropShadow = true;
			this.btnRemoveModerator.ImageFocused = null;
			this.btnRemoveModerator.ImageInactive = null;
			this.btnRemoveModerator.ImageMouseOver = null;
			this.btnRemoveModerator.ImageNormal = null;
			this.btnRemoveModerator.ImagePressed = null;
			this.btnRemoveModerator.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnRemoveModerator.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnRemoveModerator.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnRemoveModerator.Location = new Point(127, 147);
			this.btnRemoveModerator.Name = "btnRemoveModerator";
			this.btnRemoveModerator.OffsetPressedContent = true;
			this.btnRemoveModerator.Padding2 = 5;
			this.btnRemoveModerator.Size = new Size(112, 23);
			this.btnRemoveModerator.StretchImage = false;
			this.btnRemoveModerator.TabIndex = 28;
			this.btnRemoveModerator.Text = "Remove Moderator";
			this.btnRemoveModerator.TextDropShadow = false;
			this.btnRemoveModerator.UseVisualStyleBackColor = true;
			this.btnRemoveModerator.Click += this.btnRemoveModerator_Click;
			this.btnMakeModerator.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnMakeModerator.BorderDrawing = true;
			this.btnMakeModerator.FocusRectangleEnabled = false;
			this.btnMakeModerator.Image = null;
			this.btnMakeModerator.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnMakeModerator.ImageBorderEnabled = true;
			this.btnMakeModerator.ImageDropShadow = true;
			this.btnMakeModerator.ImageFocused = null;
			this.btnMakeModerator.ImageInactive = null;
			this.btnMakeModerator.ImageMouseOver = null;
			this.btnMakeModerator.ImageNormal = null;
			this.btnMakeModerator.ImagePressed = null;
			this.btnMakeModerator.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnMakeModerator.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnMakeModerator.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnMakeModerator.Location = new Point(9, 147);
			this.btnMakeModerator.Name = "btnMakeModerator";
			this.btnMakeModerator.OffsetPressedContent = true;
			this.btnMakeModerator.Padding2 = 5;
			this.btnMakeModerator.Size = new Size(112, 23);
			this.btnMakeModerator.StretchImage = false;
			this.btnMakeModerator.TabIndex = 26;
			this.btnMakeModerator.Text = "Make Moderator";
			this.btnMakeModerator.TextDropShadow = false;
			this.btnMakeModerator.UseVisualStyleBackColor = true;
			this.btnMakeModerator.Click += this.btnMakeModerator_Click;
			this.btnWalBanClear.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnWalBanClear.BorderDrawing = true;
			this.btnWalBanClear.FocusRectangleEnabled = false;
			this.btnWalBanClear.Image = null;
			this.btnWalBanClear.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnWalBanClear.ImageBorderEnabled = true;
			this.btnWalBanClear.ImageDropShadow = true;
			this.btnWalBanClear.ImageFocused = null;
			this.btnWalBanClear.ImageInactive = null;
			this.btnWalBanClear.ImageMouseOver = null;
			this.btnWalBanClear.ImageNormal = null;
			this.btnWalBanClear.ImagePressed = null;
			this.btnWalBanClear.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnWalBanClear.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnWalBanClear.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnWalBanClear.Location = new Point(178, 118);
			this.btnWalBanClear.Name = "btnWalBanClear";
			this.btnWalBanClear.OffsetPressedContent = true;
			this.btnWalBanClear.Padding2 = 5;
			this.btnWalBanClear.Size = new Size(30, 23);
			this.btnWalBanClear.StretchImage = false;
			this.btnWalBanClear.TabIndex = 24;
			this.btnWalBanClear.Text = "Clr";
			this.btnWalBanClear.TextDropShadow = false;
			this.btnWalBanClear.UseVisualStyleBackColor = true;
			this.btnWalBanClear.Click += this.btnWalBanClear_Click;
			this.btnWalBanPerma.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnWalBanPerma.BorderDrawing = true;
			this.btnWalBanPerma.FocusRectangleEnabled = false;
			this.btnWalBanPerma.Image = null;
			this.btnWalBanPerma.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnWalBanPerma.ImageBorderEnabled = true;
			this.btnWalBanPerma.ImageDropShadow = true;
			this.btnWalBanPerma.ImageFocused = null;
			this.btnWalBanPerma.ImageInactive = null;
			this.btnWalBanPerma.ImageMouseOver = null;
			this.btnWalBanPerma.ImageNormal = null;
			this.btnWalBanPerma.ImagePressed = null;
			this.btnWalBanPerma.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnWalBanPerma.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnWalBanPerma.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnWalBanPerma.Location = new Point(138, 118);
			this.btnWalBanPerma.Name = "btnWalBanPerma";
			this.btnWalBanPerma.OffsetPressedContent = true;
			this.btnWalBanPerma.Padding2 = 5;
			this.btnWalBanPerma.Size = new Size(34, 23);
			this.btnWalBanPerma.StretchImage = false;
			this.btnWalBanPerma.TabIndex = 23;
			this.btnWalBanPerma.Text = "Prm";
			this.btnWalBanPerma.TextDropShadow = false;
			this.btnWalBanPerma.UseVisualStyleBackColor = true;
			this.btnWalBanPerma.Click += this.btnWalBanPerma_Click;
			this.btnWalBan7.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnWalBan7.BorderDrawing = true;
			this.btnWalBan7.FocusRectangleEnabled = false;
			this.btnWalBan7.Image = null;
			this.btnWalBan7.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnWalBan7.ImageBorderEnabled = true;
			this.btnWalBan7.ImageDropShadow = true;
			this.btnWalBan7.ImageFocused = null;
			this.btnWalBan7.ImageInactive = null;
			this.btnWalBan7.ImageMouseOver = null;
			this.btnWalBan7.ImageNormal = null;
			this.btnWalBan7.ImagePressed = null;
			this.btnWalBan7.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnWalBan7.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnWalBan7.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnWalBan7.Location = new Point(107, 118);
			this.btnWalBan7.Name = "btnWalBan7";
			this.btnWalBan7.OffsetPressedContent = true;
			this.btnWalBan7.Padding2 = 5;
			this.btnWalBan7.Size = new Size(25, 23);
			this.btnWalBan7.StretchImage = false;
			this.btnWalBan7.TabIndex = 22;
			this.btnWalBan7.Text = "7";
			this.btnWalBan7.TextDropShadow = false;
			this.btnWalBan7.UseVisualStyleBackColor = true;
			this.btnWalBan7.Click += this.btnWalBan7_Click;
			this.btnWalBan3.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnWalBan3.BorderDrawing = true;
			this.btnWalBan3.FocusRectangleEnabled = false;
			this.btnWalBan3.Image = null;
			this.btnWalBan3.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnWalBan3.ImageBorderEnabled = true;
			this.btnWalBan3.ImageDropShadow = true;
			this.btnWalBan3.ImageFocused = null;
			this.btnWalBan3.ImageInactive = null;
			this.btnWalBan3.ImageMouseOver = null;
			this.btnWalBan3.ImageNormal = null;
			this.btnWalBan3.ImagePressed = null;
			this.btnWalBan3.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnWalBan3.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnWalBan3.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnWalBan3.Location = new Point(76, 118);
			this.btnWalBan3.Name = "btnWalBan3";
			this.btnWalBan3.OffsetPressedContent = true;
			this.btnWalBan3.Padding2 = 5;
			this.btnWalBan3.Size = new Size(25, 23);
			this.btnWalBan3.StretchImage = false;
			this.btnWalBan3.TabIndex = 21;
			this.btnWalBan3.Text = "3";
			this.btnWalBan3.TextDropShadow = false;
			this.btnWalBan3.UseVisualStyleBackColor = true;
			this.btnWalBan3.Click += this.btnWalBan3_Click;
			this.label9.AutoSize = true;
			this.label9.BackColor = Color.FromArgb(0, 255, 255, 255);
			this.label9.Location = new Point(8, 123);
			this.label9.Name = "label9";
			this.label9.Size = new Size(28, 13);
			this.label9.TabIndex = 20;
			this.label9.Text = "Wall";
			this.btnWalBan1.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnWalBan1.BorderDrawing = true;
			this.btnWalBan1.FocusRectangleEnabled = false;
			this.btnWalBan1.Image = null;
			this.btnWalBan1.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnWalBan1.ImageBorderEnabled = true;
			this.btnWalBan1.ImageDropShadow = true;
			this.btnWalBan1.ImageFocused = null;
			this.btnWalBan1.ImageInactive = null;
			this.btnWalBan1.ImageMouseOver = null;
			this.btnWalBan1.ImageNormal = null;
			this.btnWalBan1.ImagePressed = null;
			this.btnWalBan1.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnWalBan1.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnWalBan1.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnWalBan1.Location = new Point(45, 118);
			this.btnWalBan1.Name = "btnWalBan1";
			this.btnWalBan1.OffsetPressedContent = true;
			this.btnWalBan1.Padding2 = 5;
			this.btnWalBan1.Size = new Size(25, 23);
			this.btnWalBan1.StretchImage = false;
			this.btnWalBan1.TabIndex = 19;
			this.btnWalBan1.Text = "1";
			this.btnWalBan1.TextDropShadow = false;
			this.btnWalBan1.UseVisualStyleBackColor = true;
			this.btnWalBan1.Click += this.btnWalBan1_Click;
			this.btnForumBanClear.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnForumBanClear.BorderDrawing = true;
			this.btnForumBanClear.FocusRectangleEnabled = false;
			this.btnForumBanClear.Image = null;
			this.btnForumBanClear.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnForumBanClear.ImageBorderEnabled = true;
			this.btnForumBanClear.ImageDropShadow = true;
			this.btnForumBanClear.ImageFocused = null;
			this.btnForumBanClear.ImageInactive = null;
			this.btnForumBanClear.ImageMouseOver = null;
			this.btnForumBanClear.ImageNormal = null;
			this.btnForumBanClear.ImagePressed = null;
			this.btnForumBanClear.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnForumBanClear.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnForumBanClear.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnForumBanClear.Location = new Point(178, 89);
			this.btnForumBanClear.Name = "btnForumBanClear";
			this.btnForumBanClear.OffsetPressedContent = true;
			this.btnForumBanClear.Padding2 = 5;
			this.btnForumBanClear.Size = new Size(30, 23);
			this.btnForumBanClear.StretchImage = false;
			this.btnForumBanClear.TabIndex = 18;
			this.btnForumBanClear.Text = "Clr";
			this.btnForumBanClear.TextDropShadow = false;
			this.btnForumBanClear.UseVisualStyleBackColor = true;
			this.btnForumBanClear.Click += this.btnForumBanClear_Click;
			this.btnForumBanPerma.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnForumBanPerma.BorderDrawing = true;
			this.btnForumBanPerma.FocusRectangleEnabled = false;
			this.btnForumBanPerma.Image = null;
			this.btnForumBanPerma.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnForumBanPerma.ImageBorderEnabled = true;
			this.btnForumBanPerma.ImageDropShadow = true;
			this.btnForumBanPerma.ImageFocused = null;
			this.btnForumBanPerma.ImageInactive = null;
			this.btnForumBanPerma.ImageMouseOver = null;
			this.btnForumBanPerma.ImageNormal = null;
			this.btnForumBanPerma.ImagePressed = null;
			this.btnForumBanPerma.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnForumBanPerma.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnForumBanPerma.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnForumBanPerma.Location = new Point(138, 89);
			this.btnForumBanPerma.Name = "btnForumBanPerma";
			this.btnForumBanPerma.OffsetPressedContent = true;
			this.btnForumBanPerma.Padding2 = 5;
			this.btnForumBanPerma.Size = new Size(34, 23);
			this.btnForumBanPerma.StretchImage = false;
			this.btnForumBanPerma.TabIndex = 17;
			this.btnForumBanPerma.Text = "Prm";
			this.btnForumBanPerma.TextDropShadow = false;
			this.btnForumBanPerma.UseVisualStyleBackColor = true;
			this.btnForumBanPerma.Click += this.btnForumBanPerma_Click;
			this.btnForumBan7.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnForumBan7.BorderDrawing = true;
			this.btnForumBan7.FocusRectangleEnabled = false;
			this.btnForumBan7.Image = null;
			this.btnForumBan7.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnForumBan7.ImageBorderEnabled = true;
			this.btnForumBan7.ImageDropShadow = true;
			this.btnForumBan7.ImageFocused = null;
			this.btnForumBan7.ImageInactive = null;
			this.btnForumBan7.ImageMouseOver = null;
			this.btnForumBan7.ImageNormal = null;
			this.btnForumBan7.ImagePressed = null;
			this.btnForumBan7.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnForumBan7.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnForumBan7.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnForumBan7.Location = new Point(107, 89);
			this.btnForumBan7.Name = "btnForumBan7";
			this.btnForumBan7.OffsetPressedContent = true;
			this.btnForumBan7.Padding2 = 5;
			this.btnForumBan7.Size = new Size(25, 23);
			this.btnForumBan7.StretchImage = false;
			this.btnForumBan7.TabIndex = 16;
			this.btnForumBan7.Text = "7";
			this.btnForumBan7.TextDropShadow = false;
			this.btnForumBan7.UseVisualStyleBackColor = true;
			this.btnForumBan7.Click += this.btnForumBan7_Click;
			this.btnForumBan3.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnForumBan3.BorderDrawing = true;
			this.btnForumBan3.FocusRectangleEnabled = false;
			this.btnForumBan3.Image = null;
			this.btnForumBan3.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnForumBan3.ImageBorderEnabled = true;
			this.btnForumBan3.ImageDropShadow = true;
			this.btnForumBan3.ImageFocused = null;
			this.btnForumBan3.ImageInactive = null;
			this.btnForumBan3.ImageMouseOver = null;
			this.btnForumBan3.ImageNormal = null;
			this.btnForumBan3.ImagePressed = null;
			this.btnForumBan3.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnForumBan3.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnForumBan3.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnForumBan3.Location = new Point(76, 89);
			this.btnForumBan3.Name = "btnForumBan3";
			this.btnForumBan3.OffsetPressedContent = true;
			this.btnForumBan3.Padding2 = 5;
			this.btnForumBan3.Size = new Size(25, 23);
			this.btnForumBan3.StretchImage = false;
			this.btnForumBan3.TabIndex = 15;
			this.btnForumBan3.Text = "3";
			this.btnForumBan3.TextDropShadow = false;
			this.btnForumBan3.UseVisualStyleBackColor = true;
			this.btnForumBan3.Click += this.btnForumBan3_Click;
			this.label8.AutoSize = true;
			this.label8.BackColor = Color.FromArgb(0, 255, 255, 255);
			this.label8.Location = new Point(8, 94);
			this.label8.Name = "label8";
			this.label8.Size = new Size(36, 13);
			this.label8.TabIndex = 14;
			this.label8.Text = "Forum";
			this.btnForumBan1.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnForumBan1.BorderDrawing = true;
			this.btnForumBan1.FocusRectangleEnabled = false;
			this.btnForumBan1.Image = null;
			this.btnForumBan1.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnForumBan1.ImageBorderEnabled = true;
			this.btnForumBan1.ImageDropShadow = true;
			this.btnForumBan1.ImageFocused = null;
			this.btnForumBan1.ImageInactive = null;
			this.btnForumBan1.ImageMouseOver = null;
			this.btnForumBan1.ImageNormal = null;
			this.btnForumBan1.ImagePressed = null;
			this.btnForumBan1.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnForumBan1.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnForumBan1.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnForumBan1.Location = new Point(45, 89);
			this.btnForumBan1.Name = "btnForumBan1";
			this.btnForumBan1.OffsetPressedContent = true;
			this.btnForumBan1.Padding2 = 5;
			this.btnForumBan1.Size = new Size(25, 23);
			this.btnForumBan1.StretchImage = false;
			this.btnForumBan1.TabIndex = 13;
			this.btnForumBan1.Text = "1";
			this.btnForumBan1.TextDropShadow = false;
			this.btnForumBan1.UseVisualStyleBackColor = true;
			this.btnForumBan1.Click += this.btnForumBan1_Click;
			this.btnMailBanClear.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnMailBanClear.BorderDrawing = true;
			this.btnMailBanClear.FocusRectangleEnabled = false;
			this.btnMailBanClear.Image = null;
			this.btnMailBanClear.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnMailBanClear.ImageBorderEnabled = true;
			this.btnMailBanClear.ImageDropShadow = true;
			this.btnMailBanClear.ImageFocused = null;
			this.btnMailBanClear.ImageInactive = null;
			this.btnMailBanClear.ImageMouseOver = null;
			this.btnMailBanClear.ImageNormal = null;
			this.btnMailBanClear.ImagePressed = null;
			this.btnMailBanClear.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnMailBanClear.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnMailBanClear.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnMailBanClear.Location = new Point(178, 60);
			this.btnMailBanClear.Name = "btnMailBanClear";
			this.btnMailBanClear.OffsetPressedContent = true;
			this.btnMailBanClear.Padding2 = 5;
			this.btnMailBanClear.Size = new Size(30, 23);
			this.btnMailBanClear.StretchImage = false;
			this.btnMailBanClear.TabIndex = 12;
			this.btnMailBanClear.Text = "Clr";
			this.btnMailBanClear.TextDropShadow = false;
			this.btnMailBanClear.UseVisualStyleBackColor = true;
			this.btnMailBanClear.Click += this.btnMailBanClear_Click;
			this.btnMailBanPerma.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnMailBanPerma.BorderDrawing = true;
			this.btnMailBanPerma.FocusRectangleEnabled = false;
			this.btnMailBanPerma.Image = null;
			this.btnMailBanPerma.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnMailBanPerma.ImageBorderEnabled = true;
			this.btnMailBanPerma.ImageDropShadow = true;
			this.btnMailBanPerma.ImageFocused = null;
			this.btnMailBanPerma.ImageInactive = null;
			this.btnMailBanPerma.ImageMouseOver = null;
			this.btnMailBanPerma.ImageNormal = null;
			this.btnMailBanPerma.ImagePressed = null;
			this.btnMailBanPerma.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnMailBanPerma.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnMailBanPerma.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnMailBanPerma.Location = new Point(138, 60);
			this.btnMailBanPerma.Name = "btnMailBanPerma";
			this.btnMailBanPerma.OffsetPressedContent = true;
			this.btnMailBanPerma.Padding2 = 5;
			this.btnMailBanPerma.Size = new Size(34, 23);
			this.btnMailBanPerma.StretchImage = false;
			this.btnMailBanPerma.TabIndex = 11;
			this.btnMailBanPerma.Text = "Prm";
			this.btnMailBanPerma.TextDropShadow = false;
			this.btnMailBanPerma.UseVisualStyleBackColor = true;
			this.btnMailBanPerma.Click += this.btnMailBanPerma_Click;
			this.btnMailBan7.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnMailBan7.BorderDrawing = true;
			this.btnMailBan7.FocusRectangleEnabled = false;
			this.btnMailBan7.Image = null;
			this.btnMailBan7.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnMailBan7.ImageBorderEnabled = true;
			this.btnMailBan7.ImageDropShadow = true;
			this.btnMailBan7.ImageFocused = null;
			this.btnMailBan7.ImageInactive = null;
			this.btnMailBan7.ImageMouseOver = null;
			this.btnMailBan7.ImageNormal = null;
			this.btnMailBan7.ImagePressed = null;
			this.btnMailBan7.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnMailBan7.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnMailBan7.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnMailBan7.Location = new Point(107, 60);
			this.btnMailBan7.Name = "btnMailBan7";
			this.btnMailBan7.OffsetPressedContent = true;
			this.btnMailBan7.Padding2 = 5;
			this.btnMailBan7.Size = new Size(25, 23);
			this.btnMailBan7.StretchImage = false;
			this.btnMailBan7.TabIndex = 10;
			this.btnMailBan7.Text = "7";
			this.btnMailBan7.TextDropShadow = false;
			this.btnMailBan7.UseVisualStyleBackColor = true;
			this.btnMailBan7.Click += this.btnMailBan7_Click;
			this.btnMailBan3.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnMailBan3.BorderDrawing = true;
			this.btnMailBan3.FocusRectangleEnabled = false;
			this.btnMailBan3.Image = null;
			this.btnMailBan3.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnMailBan3.ImageBorderEnabled = true;
			this.btnMailBan3.ImageDropShadow = true;
			this.btnMailBan3.ImageFocused = null;
			this.btnMailBan3.ImageInactive = null;
			this.btnMailBan3.ImageMouseOver = null;
			this.btnMailBan3.ImageNormal = null;
			this.btnMailBan3.ImagePressed = null;
			this.btnMailBan3.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnMailBan3.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnMailBan3.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnMailBan3.Location = new Point(76, 60);
			this.btnMailBan3.Name = "btnMailBan3";
			this.btnMailBan3.OffsetPressedContent = true;
			this.btnMailBan3.Padding2 = 5;
			this.btnMailBan3.Size = new Size(25, 23);
			this.btnMailBan3.StretchImage = false;
			this.btnMailBan3.TabIndex = 9;
			this.btnMailBan3.Text = "3";
			this.btnMailBan3.TextDropShadow = false;
			this.btnMailBan3.UseVisualStyleBackColor = true;
			this.btnMailBan3.Click += this.btnMailBan3_Click;
			this.label7.AutoSize = true;
			this.label7.BackColor = Color.FromArgb(0, 255, 255, 255);
			this.label7.Location = new Point(8, 65);
			this.label7.Name = "label7";
			this.label7.Size = new Size(26, 13);
			this.label7.TabIndex = 8;
			this.label7.Text = "Mail";
			this.btnMailBan1.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnMailBan1.BorderDrawing = true;
			this.btnMailBan1.FocusRectangleEnabled = false;
			this.btnMailBan1.Image = null;
			this.btnMailBan1.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnMailBan1.ImageBorderEnabled = true;
			this.btnMailBan1.ImageDropShadow = true;
			this.btnMailBan1.ImageFocused = null;
			this.btnMailBan1.ImageInactive = null;
			this.btnMailBan1.ImageMouseOver = null;
			this.btnMailBan1.ImageNormal = null;
			this.btnMailBan1.ImagePressed = null;
			this.btnMailBan1.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnMailBan1.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnMailBan1.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnMailBan1.Location = new Point(45, 60);
			this.btnMailBan1.Name = "btnMailBan1";
			this.btnMailBan1.OffsetPressedContent = true;
			this.btnMailBan1.Padding2 = 5;
			this.btnMailBan1.Size = new Size(25, 23);
			this.btnMailBan1.StretchImage = false;
			this.btnMailBan1.TabIndex = 7;
			this.btnMailBan1.Text = "1";
			this.btnMailBan1.TextDropShadow = false;
			this.btnMailBan1.UseVisualStyleBackColor = true;
			this.btnMailBan1.Click += this.btnMailBan1_Click;
			this.btnChatBanClear.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnChatBanClear.BorderDrawing = true;
			this.btnChatBanClear.FocusRectangleEnabled = false;
			this.btnChatBanClear.Image = null;
			this.btnChatBanClear.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnChatBanClear.ImageBorderEnabled = true;
			this.btnChatBanClear.ImageDropShadow = true;
			this.btnChatBanClear.ImageFocused = null;
			this.btnChatBanClear.ImageInactive = null;
			this.btnChatBanClear.ImageMouseOver = null;
			this.btnChatBanClear.ImageNormal = null;
			this.btnChatBanClear.ImagePressed = null;
			this.btnChatBanClear.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnChatBanClear.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnChatBanClear.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnChatBanClear.Location = new Point(178, 31);
			this.btnChatBanClear.Name = "btnChatBanClear";
			this.btnChatBanClear.OffsetPressedContent = true;
			this.btnChatBanClear.Padding2 = 5;
			this.btnChatBanClear.Size = new Size(30, 23);
			this.btnChatBanClear.StretchImage = false;
			this.btnChatBanClear.TabIndex = 6;
			this.btnChatBanClear.Text = "Clr";
			this.btnChatBanClear.TextDropShadow = false;
			this.btnChatBanClear.UseVisualStyleBackColor = true;
			this.btnChatBanClear.Click += this.btnChatBanClear_Click;
			this.btnChatBanPerma.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnChatBanPerma.BorderDrawing = true;
			this.btnChatBanPerma.FocusRectangleEnabled = false;
			this.btnChatBanPerma.Image = null;
			this.btnChatBanPerma.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnChatBanPerma.ImageBorderEnabled = true;
			this.btnChatBanPerma.ImageDropShadow = true;
			this.btnChatBanPerma.ImageFocused = null;
			this.btnChatBanPerma.ImageInactive = null;
			this.btnChatBanPerma.ImageMouseOver = null;
			this.btnChatBanPerma.ImageNormal = null;
			this.btnChatBanPerma.ImagePressed = null;
			this.btnChatBanPerma.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnChatBanPerma.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnChatBanPerma.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnChatBanPerma.Location = new Point(138, 31);
			this.btnChatBanPerma.Name = "btnChatBanPerma";
			this.btnChatBanPerma.OffsetPressedContent = true;
			this.btnChatBanPerma.Padding2 = 5;
			this.btnChatBanPerma.Size = new Size(34, 23);
			this.btnChatBanPerma.StretchImage = false;
			this.btnChatBanPerma.TabIndex = 5;
			this.btnChatBanPerma.Text = "Prm";
			this.btnChatBanPerma.TextDropShadow = false;
			this.btnChatBanPerma.UseVisualStyleBackColor = true;
			this.btnChatBanPerma.Click += this.btnChatBanPerma_Click;
			this.btnChatBan7.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnChatBan7.BorderDrawing = true;
			this.btnChatBan7.FocusRectangleEnabled = false;
			this.btnChatBan7.Image = null;
			this.btnChatBan7.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnChatBan7.ImageBorderEnabled = true;
			this.btnChatBan7.ImageDropShadow = true;
			this.btnChatBan7.ImageFocused = null;
			this.btnChatBan7.ImageInactive = null;
			this.btnChatBan7.ImageMouseOver = null;
			this.btnChatBan7.ImageNormal = null;
			this.btnChatBan7.ImagePressed = null;
			this.btnChatBan7.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnChatBan7.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnChatBan7.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnChatBan7.Location = new Point(107, 31);
			this.btnChatBan7.Name = "btnChatBan7";
			this.btnChatBan7.OffsetPressedContent = true;
			this.btnChatBan7.Padding2 = 5;
			this.btnChatBan7.Size = new Size(25, 23);
			this.btnChatBan7.StretchImage = false;
			this.btnChatBan7.TabIndex = 4;
			this.btnChatBan7.Text = "7";
			this.btnChatBan7.TextDropShadow = false;
			this.btnChatBan7.UseVisualStyleBackColor = true;
			this.btnChatBan7.Click += this.btnChatBan7_Click;
			this.btnChatBan3.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnChatBan3.BorderDrawing = true;
			this.btnChatBan3.FocusRectangleEnabled = false;
			this.btnChatBan3.Image = null;
			this.btnChatBan3.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnChatBan3.ImageBorderEnabled = true;
			this.btnChatBan3.ImageDropShadow = true;
			this.btnChatBan3.ImageFocused = null;
			this.btnChatBan3.ImageInactive = null;
			this.btnChatBan3.ImageMouseOver = null;
			this.btnChatBan3.ImageNormal = null;
			this.btnChatBan3.ImagePressed = null;
			this.btnChatBan3.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnChatBan3.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnChatBan3.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnChatBan3.Location = new Point(76, 31);
			this.btnChatBan3.Name = "btnChatBan3";
			this.btnChatBan3.OffsetPressedContent = true;
			this.btnChatBan3.Padding2 = 5;
			this.btnChatBan3.Size = new Size(25, 23);
			this.btnChatBan3.StretchImage = false;
			this.btnChatBan3.TabIndex = 3;
			this.btnChatBan3.Text = "3";
			this.btnChatBan3.TextDropShadow = false;
			this.btnChatBan3.UseVisualStyleBackColor = true;
			this.btnChatBan3.Click += this.btnChatBan3_Click;
			this.label6.AutoSize = true;
			this.label6.BackColor = Color.FromArgb(0, 255, 255, 255);
			this.label6.Location = new Point(8, 36);
			this.label6.Name = "label6";
			this.label6.Size = new Size(29, 13);
			this.label6.TabIndex = 2;
			this.label6.Text = "Chat";
			this.btnChatBan1.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnChatBan1.BorderDrawing = true;
			this.btnChatBan1.FocusRectangleEnabled = false;
			this.btnChatBan1.Image = null;
			this.btnChatBan1.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnChatBan1.ImageBorderEnabled = true;
			this.btnChatBan1.ImageDropShadow = true;
			this.btnChatBan1.ImageFocused = null;
			this.btnChatBan1.ImageInactive = null;
			this.btnChatBan1.ImageMouseOver = null;
			this.btnChatBan1.ImageNormal = null;
			this.btnChatBan1.ImagePressed = null;
			this.btnChatBan1.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnChatBan1.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnChatBan1.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnChatBan1.Location = new Point(45, 31);
			this.btnChatBan1.Name = "btnChatBan1";
			this.btnChatBan1.OffsetPressedContent = true;
			this.btnChatBan1.Padding2 = 5;
			this.btnChatBan1.Size = new Size(25, 23);
			this.btnChatBan1.StretchImage = false;
			this.btnChatBan1.TabIndex = 1;
			this.btnChatBan1.Text = "1";
			this.btnChatBan1.TextDropShadow = false;
			this.btnChatBan1.UseVisualStyleBackColor = true;
			this.btnChatBan1.Click += this.btnChatBan1_Click;
			this.label4.AutoSize = true;
			this.label4.BackColor = Color.FromArgb(0, 255, 255, 255);
			this.label4.Location = new Point(6, 15);
			this.label4.Name = "label4";
			this.label4.Size = new Size(64, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Bans (Days)";
			this.btnEditAvatar.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnEditAvatar.BorderDrawing = true;
			this.btnEditAvatar.FocusRectangleEnabled = false;
			this.btnEditAvatar.Image = null;
			this.btnEditAvatar.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnEditAvatar.ImageBorderEnabled = true;
			this.btnEditAvatar.ImageDropShadow = true;
			this.btnEditAvatar.ImageFocused = null;
			this.btnEditAvatar.ImageInactive = null;
			this.btnEditAvatar.ImageMouseOver = null;
			this.btnEditAvatar.ImageNormal = null;
			this.btnEditAvatar.ImagePressed = null;
			this.btnEditAvatar.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnEditAvatar.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnEditAvatar.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnEditAvatar.Location = new Point(627, 521);
			this.btnEditAvatar.Name = "btnEditAvatar";
			this.btnEditAvatar.OffsetPressedContent = true;
			this.btnEditAvatar.Padding2 = 5;
			this.btnEditAvatar.Size = new Size(131, 23);
			this.btnEditAvatar.StretchImage = false;
			this.btnEditAvatar.TabIndex = 26;
			this.btnEditAvatar.Text = "Edit Avatar";
			this.btnEditAvatar.TextDropShadow = false;
			this.btnEditAvatar.UseVisualStyleBackColor = true;
			this.btnEditAvatar.Visible = false;
			this.btnEditAvatar.Click += this.bitmapButton1_Click;
			this.btnInviteToFaction.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnInviteToFaction.BorderDrawing = true;
			this.btnInviteToFaction.FocusRectangleEnabled = false;
			this.btnInviteToFaction.Image = null;
			this.btnInviteToFaction.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnInviteToFaction.ImageBorderEnabled = true;
			this.btnInviteToFaction.ImageDropShadow = true;
			this.btnInviteToFaction.ImageFocused = null;
			this.btnInviteToFaction.ImageInactive = null;
			this.btnInviteToFaction.ImageMouseOver = null;
			this.btnInviteToFaction.ImageNormal = null;
			this.btnInviteToFaction.ImagePressed = null;
			this.btnInviteToFaction.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnInviteToFaction.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnInviteToFaction.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnInviteToFaction.Location = new Point(479, 97);
			this.btnInviteToFaction.Name = "btnInviteToFaction";
			this.btnInviteToFaction.OffsetPressedContent = true;
			this.btnInviteToFaction.Padding2 = 5;
			this.btnInviteToFaction.Size = new Size(131, 33);
			this.btnInviteToFaction.StretchImage = false;
			this.btnInviteToFaction.TabIndex = 25;
			this.btnInviteToFaction.Text = "Invite To Faction";
			this.btnInviteToFaction.TextDropShadow = false;
			this.btnInviteToFaction.UseVisualStyleBackColor = true;
			this.btnInviteToFaction.Visible = false;
			this.btnInviteToFaction.Click += this.btnInviteToFaction_Click;
			this.btnAchievements.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnAchievements.BorderDrawing = true;
			this.btnAchievements.FocusRectangleEnabled = false;
			this.btnAchievements.Image = null;
			this.btnAchievements.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnAchievements.ImageBorderEnabled = true;
			this.btnAchievements.ImageDropShadow = true;
			this.btnAchievements.ImageFocused = null;
			this.btnAchievements.ImageInactive = null;
			this.btnAchievements.ImageMouseOver = null;
			this.btnAchievements.ImageNormal = null;
			this.btnAchievements.ImagePressed = null;
			this.btnAchievements.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnAchievements.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnAchievements.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnAchievements.Location = new Point(479, 58);
			this.btnAchievements.Name = "btnAchievements";
			this.btnAchievements.OffsetPressedContent = true;
			this.btnAchievements.Padding2 = 5;
			this.btnAchievements.Size = new Size(131, 33);
			this.btnAchievements.StretchImage = false;
			this.btnAchievements.TabIndex = 24;
			this.btnAchievements.Text = "Achievements";
			this.btnAchievements.TextDropShadow = false;
			this.btnAchievements.UseVisualStyleBackColor = true;
			this.btnAchievements.Click += this.btnAchievements_Click;
			this.btnSendMail.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnSendMail.BorderDrawing = true;
			this.btnSendMail.FocusRectangleEnabled = false;
			this.btnSendMail.Image = null;
			this.btnSendMail.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnSendMail.ImageBorderEnabled = true;
			this.btnSendMail.ImageDropShadow = true;
			this.btnSendMail.ImageFocused = null;
			this.btnSendMail.ImageInactive = null;
			this.btnSendMail.ImageMouseOver = null;
			this.btnSendMail.ImageNormal = null;
			this.btnSendMail.ImagePressed = null;
			this.btnSendMail.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnSendMail.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnSendMail.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnSendMail.Location = new Point(479, 19);
			this.btnSendMail.Name = "btnSendMail";
			this.btnSendMail.OffsetPressedContent = true;
			this.btnSendMail.Padding2 = 5;
			this.btnSendMail.Size = new Size(131, 33);
			this.btnSendMail.StretchImage = false;
			this.btnSendMail.TabIndex = 20;
			this.btnSendMail.Text = "Send Mail";
			this.btnSendMail.TextDropShadow = false;
			this.btnSendMail.UseVisualStyleBackColor = true;
			this.btnSendMail.Click += this.btnSendMail_Click;
			this.btnClose.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.btnClose.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnClose.BorderDrawing = true;
			this.btnClose.FocusRectangleEnabled = false;
			this.btnClose.Image = null;
			this.btnClose.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnClose.ImageBorderEnabled = true;
			this.btnClose.ImageDropShadow = true;
			this.btnClose.ImageFocused = null;
			this.btnClose.ImageInactive = null;
			this.btnClose.ImageMouseOver = null;
			this.btnClose.ImageNormal = null;
			this.btnClose.ImagePressed = null;
			this.btnClose.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnClose.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnClose.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnClose.Location = new Point(695, 531);
			this.btnClose.Name = "btnClose";
			this.btnClose.OffsetPressedContent = true;
			this.btnClose.Padding2 = 5;
			this.btnClose.Size = new Size(75, 23);
			this.btnClose.StretchImage = false;
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "Close";
			this.btnClose.TextDropShadow = false;
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += this.btnClose_Click;
			this.btnGiveQuests.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnGiveQuests.BorderDrawing = true;
			this.btnGiveQuests.FocusRectangleEnabled = false;
			this.btnGiveQuests.Image = null;
			this.btnGiveQuests.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnGiveQuests.ImageBorderEnabled = true;
			this.btnGiveQuests.ImageDropShadow = true;
			this.btnGiveQuests.ImageFocused = null;
			this.btnGiveQuests.ImageInactive = null;
			this.btnGiveQuests.ImageMouseOver = null;
			this.btnGiveQuests.ImageNormal = null;
			this.btnGiveQuests.ImagePressed = null;
			this.btnGiveQuests.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnGiveQuests.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnGiveQuests.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnGiveQuests.Location = new Point(127, 302);
			this.btnGiveQuests.Name = "btnGiveQuests";
			this.btnGiveQuests.OffsetPressedContent = true;
			this.btnGiveQuests.Padding2 = 5;
			this.btnGiveQuests.Size = new Size(108, 23);
			this.btnGiveQuests.StretchImage = false;
			this.btnGiveQuests.TabIndex = 42;
			this.btnGiveQuests.Text = "Give Quests";
			this.btnGiveQuests.TextDropShadow = false;
			this.btnGiveQuests.UseVisualStyleBackColor = true;
			this.btnGiveQuests.Click += this.btnGiveQuests_Click;
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = Color.FromArgb(159, 180, 193);
			base.Controls.Add(this.btnEditAvatar);
			base.Controls.Add(this.btnInviteToFaction);
			base.Controls.Add(this.btnAchievements);
			base.Controls.Add(this.gbModerator);
			base.Controls.Add(this.lblIsModerator);
			base.Controls.Add(this.lblIsAdmin);
			base.Controls.Add(this.btnSendMail);
			base.Controls.Add(this.imgAvatar);
			base.Controls.Add(this.lblFaction);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.lblStanding);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.lblPoints);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.lblRank);
			base.Controls.Add(this.lblUserName);
			base.Controls.Add(this.pnlVillages);
			base.Controls.Add(this.btnClose);
			this.MinimumSize = new Size(792, 566);
			base.Name = "UserInfoScreen";
			base.Size = new Size(792, 566);
			base.Paint += this.UserInfoScreen_Paint;
			base.Resize += this.UserInfoScreen_Resize;
			this.gbModerator.ResumeLayout(false);
			this.gbModerator.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040036DD RID: 14045
		private WorldMap.CachedUserInfo m_userInfo;

		// Token: 0x040036DE RID: 14046
		private int m_userID = -1;

		// Token: 0x040036DF RID: 14047
		private int[] m_villages;

		// Token: 0x040036E0 RID: 14048
		private List<UserinfoScreenLine> lineList = new List<UserinfoScreenLine>();

		// Token: 0x040036E1 RID: 14049
		private string m_reasonString = "";

		// Token: 0x040036E2 RID: 14050
		private DockableControl dockableControl;

		// Token: 0x040036E3 RID: 14051
		private IContainer components;

		// Token: 0x040036E4 RID: 14052
		private BitmapButton btnClose;

		// Token: 0x040036E5 RID: 14053
		private Panel pnlVillages;

		// Token: 0x040036E6 RID: 14054
		private Label lblUserName;

		// Token: 0x040036E7 RID: 14055
		private Label lblRank;

		// Token: 0x040036E8 RID: 14056
		private Label label1;

		// Token: 0x040036E9 RID: 14057
		private Label lblPoints;

		// Token: 0x040036EA RID: 14058
		private Label lblStanding;

		// Token: 0x040036EB RID: 14059
		private Label label3;

		// Token: 0x040036EC RID: 14060
		private Label label2;

		// Token: 0x040036ED RID: 14061
		private Label lblFaction;

		// Token: 0x040036EE RID: 14062
		private Label label5;

		// Token: 0x040036EF RID: 14063
		private UserControl imgAvatar;

		// Token: 0x040036F0 RID: 14064
		private BitmapButton btnSendMail;

		// Token: 0x040036F1 RID: 14065
		private Label lblIsAdmin;

		// Token: 0x040036F2 RID: 14066
		private Label lblIsModerator;

		// Token: 0x040036F3 RID: 14067
		private GroupBox gbModerator;

		// Token: 0x040036F4 RID: 14068
		private BitmapButton btnChatBanClear;

		// Token: 0x040036F5 RID: 14069
		private BitmapButton btnChatBanPerma;

		// Token: 0x040036F6 RID: 14070
		private BitmapButton btnChatBan7;

		// Token: 0x040036F7 RID: 14071
		private BitmapButton btnChatBan3;

		// Token: 0x040036F8 RID: 14072
		private Label label6;

		// Token: 0x040036F9 RID: 14073
		private BitmapButton btnChatBan1;

		// Token: 0x040036FA RID: 14074
		private Label label4;

		// Token: 0x040036FB RID: 14075
		private BitmapButton btnWalBanClear;

		// Token: 0x040036FC RID: 14076
		private BitmapButton btnWalBanPerma;

		// Token: 0x040036FD RID: 14077
		private BitmapButton btnWalBan7;

		// Token: 0x040036FE RID: 14078
		private BitmapButton btnWalBan3;

		// Token: 0x040036FF RID: 14079
		private Label label9;

		// Token: 0x04003700 RID: 14080
		private BitmapButton btnWalBan1;

		// Token: 0x04003701 RID: 14081
		private BitmapButton btnForumBanClear;

		// Token: 0x04003702 RID: 14082
		private BitmapButton btnForumBanPerma;

		// Token: 0x04003703 RID: 14083
		private BitmapButton btnForumBan7;

		// Token: 0x04003704 RID: 14084
		private BitmapButton btnForumBan3;

		// Token: 0x04003705 RID: 14085
		private Label label8;

		// Token: 0x04003706 RID: 14086
		private BitmapButton btnForumBan1;

		// Token: 0x04003707 RID: 14087
		private BitmapButton btnMailBanClear;

		// Token: 0x04003708 RID: 14088
		private BitmapButton btnMailBanPerma;

		// Token: 0x04003709 RID: 14089
		private BitmapButton btnMailBan7;

		// Token: 0x0400370A RID: 14090
		private BitmapButton btnMailBan3;

		// Token: 0x0400370B RID: 14091
		private Label label7;

		// Token: 0x0400370C RID: 14092
		private BitmapButton btnMailBan1;

		// Token: 0x0400370D RID: 14093
		private BitmapButton btnMakeModerator;

		// Token: 0x0400370E RID: 14094
		private BitmapButton btnRemoveModerator;

		// Token: 0x0400370F RID: 14095
		private TextBox tbHonour;

		// Token: 0x04003710 RID: 14096
		private TextBox tbGold;

		// Token: 0x04003711 RID: 14097
		private Label lblHonour;

		// Token: 0x04003712 RID: 14098
		private Label lblGold;

		// Token: 0x04003713 RID: 14099
		private BitmapButton btnApplyGold;

		// Token: 0x04003714 RID: 14100
		private BitmapButton btnApplyHonour;

		// Token: 0x04003715 RID: 14101
		private BitmapButton btnApplyRP;

		// Token: 0x04003716 RID: 14102
		private TextBox tbRP;

		// Token: 0x04003717 RID: 14103
		private Label lblRP;

		// Token: 0x04003718 RID: 14104
		private BitmapButton btnFlushCaches;

		// Token: 0x04003719 RID: 14105
		private BitmapButton btnKick;

		// Token: 0x0400371A RID: 14106
		private BitmapButton btnAchievements;

		// Token: 0x0400371B RID: 14107
		private BitmapButton btnInviteToFaction;

		// Token: 0x0400371C RID: 14108
		private TextBox tbStuff;

		// Token: 0x0400371D RID: 14109
		private BitmapButton btnEditAvatar;

		// Token: 0x0400371E RID: 14110
		private BitmapButton btnFixAchievements;

		// Token: 0x0400371F RID: 14111
		private BitmapButton btnGiveQuests;
	}
}
