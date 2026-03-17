using System;
using System.Drawing;

namespace Kingdoms
{
	// Token: 0x02000240 RID: 576
	public class MenuMailPanel : CustomSelfDrawPanel.CSDControl
	{
		// Token: 0x06001984 RID: 6532 RVA: 0x00199180 File Offset: 0x00197380
		public void init()
		{
			this.clearControls();
			this.premiumVOButton.ImageNorm = GFXLibrary.premium_menubar_normal;
			this.premiumVOButton.ImageOver = GFXLibrary.premium_menubar_over;
			this.premiumVOButton.Position = new Point(0, 0);
			this.premiumVOButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.voClicked));
			this.premiumVOButton.CustomTooltipID = 33;
			base.addControl(this.premiumVOButton);
			this.mailButton.ImageNorm = GFXLibrary.mail_menubar_open;
			this.mailButton.ImageOver = GFXLibrary.mail_menubar_open_bright;
			this.mailButton.Position = new Point(35, 0);
			this.mailButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.mailClicked));
			this.mailButton.CustomTooltipID = 28;
			base.addControl(this.mailButton);
			this.overlayIcon.Image = GFXLibrary.mail_menubar_closed_bright;
			this.overlayIcon.Position = new Point(0, 0);
			this.overlayIcon.Visible = false;
			this.mailButton.addControl(this.overlayIcon);
			this.chatButton.ImageNorm = GFXLibrary.bubble_normal;
			this.chatButton.ImageOver = GFXLibrary.bubble_over;
			this.chatButton.Position = new Point(70, 0);
			this.chatButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.chatClicked));
			this.chatButton.CustomTooltipID = 53;
			base.addControl(this.chatButton);
			this.leaderboardButton.ImageNorm = GFXLibrary.points_menubar_normal;
			this.leaderboardButton.ImageOver = GFXLibrary.points_menubar_bright;
			this.leaderboardButton.Position = new Point(105, 0);
			this.leaderboardButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.leaderboardClicked));
			this.leaderboardButton.CustomTooltipID = 29;
			base.addControl(this.leaderboardButton);
			this.contestLeaderboardButton.ImageNorm = GFXLibrary.contest_menubar_normal;
			this.contestLeaderboardButton.ImageOver = GFXLibrary.contest_menubar_bright;
			this.contestLeaderboardButton.Position = new Point(140, 0);
			this.contestLeaderboardButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.contestsLeaderboardClicked));
			this.contestLeaderboardButton.CustomTooltipID = 34;
			base.addControl(this.contestLeaderboardButton);
			this.contestLeaderboardButton.Visible = (GameEngine.Instance.World.previousContests.Count > 0 || GameEngine.Instance.World.contestID > 0);
		}

		// Token: 0x06001985 RID: 6533 RVA: 0x00019CBB File Offset: 0x00017EBB
		public void setContestLeaderboardButtonVisible(bool visible)
		{
			this.contestLeaderboardButton.Visible = visible;
			this.contestLeaderboardButton.invalidate();
		}

		// Token: 0x06001986 RID: 6534 RVA: 0x00019CD4 File Offset: 0x00017ED4
		public void setMailAlpha(double alpha)
		{
			this.overlayIcon.Alpha = (float)alpha;
			this.overlayIcon.invalidate();
		}

		// Token: 0x06001987 RID: 6535 RVA: 0x00199434 File Offset: 0x00197634
		public void newMail(bool newMail)
		{
			if (newMail)
			{
				this.mailButton.ImageNorm = GFXLibrary.mail_menubar_closed;
				this.mailButton.ImageOver = GFXLibrary.mail_menubar_closed_bright;
				this.overlayIcon.Visible = true;
				return;
			}
			this.mailButton.ImageNorm = GFXLibrary.mail_menubar_open;
			this.mailButton.ImageOver = GFXLibrary.mail_menubar_open_bright;
			this.overlayIcon.Visible = false;
		}

		// Token: 0x06001988 RID: 6536 RVA: 0x001994B4 File Offset: 0x001976B4
		public void mailClicked()
		{
			GameEngine.Instance.playInterfaceSound("WorldMapScreen_menu_mail");
			if (InterfaceMgr.Instance.isMailDocked())
			{
				InterfaceMgr.Instance.getMainTabBar().selectDummyTab(21);
				return;
			}
			if (InterfaceMgr.Instance.mailScreenNeedsOpening())
			{
				InterfaceMgr.Instance.initMailSubTab(0);
				return;
			}
			InterfaceMgr.Instance.mailScreenRePop();
		}

		// Token: 0x06001989 RID: 6537 RVA: 0x00019CEE File Offset: 0x00017EEE
		public void chatClicked()
		{
			GameEngine.Instance.playInterfaceSound("WorldMapScreen_menu_chat");
			InterfaceMgr.Instance.initChatPanel(-1, -1);
		}

		// Token: 0x0600198A RID: 6538 RVA: 0x00019D0B File Offset: 0x00017F0B
		public void leaderboardClicked()
		{
			GameEngine.Instance.playInterfaceSound("WorldMapScreen_menu_leaderboard");
			InterfaceMgr.Instance.getMainTabBar().selectDummyTab(22);
		}

		// Token: 0x0600198B RID: 6539 RVA: 0x00199510 File Offset: 0x00197710
		public void contestsLeaderboardClicked()
		{
			bool flag = true;
			if (GameEngine.Instance.World.contestID > 0)
			{
				DateTime t = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds((double)GameEngine.Instance.World.contestStartTime);
				DateTime t2 = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds((double)GameEngine.Instance.World.contestEndTime);
				if (t <= VillageMap.getCurrentServerTime() && t2 > VillageMap.getCurrentServerTime())
				{
					GameEngine.Instance.playInterfaceSound("WorldMapScreen_menu_leaderboard");
					InterfaceMgr.Instance.getMainTabBar().selectDummyTab(30);
					flag = false;
				}
			}
			if (flag)
			{
				GameEngine.Instance.playInterfaceSound("WorldMapScreen_menu_leaderboard");
				InterfaceMgr.Instance.getMainTabBar().selectDummyTab(31);
			}
		}

		// Token: 0x0600198C RID: 6540 RVA: 0x00019D2D File Offset: 0x00017F2D
		public void voClicked()
		{
			InterfaceMgr.Instance.getMainTabBar().selectDummyTab(100);
		}

		// Token: 0x04002A2B RID: 10795
		private CustomSelfDrawPanel.CSDImage overlayIcon = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002A2C RID: 10796
		private CustomSelfDrawPanel.CSDButton mailButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002A2D RID: 10797
		private CustomSelfDrawPanel.CSDButton chatButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002A2E RID: 10798
		private CustomSelfDrawPanel.CSDButton leaderboardButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002A2F RID: 10799
		private CustomSelfDrawPanel.CSDButton premiumVOButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002A30 RID: 10800
		private CustomSelfDrawPanel.CSDButton contestLeaderboardButton = new CustomSelfDrawPanel.CSDButton();
	}
}
