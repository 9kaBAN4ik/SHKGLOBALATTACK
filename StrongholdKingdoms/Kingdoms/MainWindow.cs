using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x02000231 RID: 561
	public partial class MainWindow : Form
	{
		// Token: 0x0600187C RID: 6268 RVA: 0x0018209C File Offset: 0x0018029C
		public MainWindow()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.mainRightHandPanel1.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.topLeftMenu1.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x0600187D RID: 6269 RVA: 0x000193C5 File Offset: 0x000175C5
		public void setTooltipText(Control control, string text)
		{
			this.m_wndToolTip.SetToolTip(control, text);
		}

		// Token: 0x0600187E RID: 6270 RVA: 0x000193D4 File Offset: 0x000175D4
		public DXPanel getDXBasePanel()
		{
			return this.dxBasePanel;
		}

		// Token: 0x0600187F RID: 6271 RVA: 0x0018210C File Offset: 0x0018030C
		public void makeFullDX()
		{
			this.origDXLoc = this.dxBasePanel.Location;
			this.origDXSize = this.dxBasePanel.Size;
			this.dxBasePanel.Location = new Point(0, 0);
			this.dxBasePanel.Size = base.ClientSize;
			this.steamOverlayed = true;
			if (Program.arcInstall && GameEngine.Instance.World != null)
			{
				GameEngine.Instance.World.setScreenSize(this.dxBasePanel.Width, this.dxBasePanel.Height);
			}
		}

		// Token: 0x06001880 RID: 6272 RVA: 0x001821A0 File Offset: 0x001803A0
		public void restoreDXSize()
		{
			this.dxBasePanel.Location = this.origDXLoc;
			this.dxBasePanel.Size = this.origDXSize;
			this.steamOverlayed = false;
			InterfaceMgr.Instance.reShowDXWindow();
			if (Program.arcInstall && GameEngine.Instance.World != null)
			{
				GameEngine.Instance.World.setScreenSize(this.dxBasePanel.Width, this.dxBasePanel.Height);
			}
		}

		// Token: 0x06001881 RID: 6273 RVA: 0x000193DC File Offset: 0x000175DC
		public MainRightHandPanel getMainRightHandPanel()
		{
			return this.mainRightHandPanel1;
		}

		// Token: 0x06001882 RID: 6274 RVA: 0x000193E4 File Offset: 0x000175E4
		public MainTabBar2 getMainTabBar()
		{
			return this.topRightMenu1.getMainTabBar();
		}

		// Token: 0x06001883 RID: 6275 RVA: 0x000193F1 File Offset: 0x000175F1
		public VillageTabBar2 getVillageTabBar()
		{
			return this.topRightMenu1.getVillageTabBar();
		}

		// Token: 0x06001884 RID: 6276 RVA: 0x000193FE File Offset: 0x000175FE
		public FactionTabBar2 getFactionTabBar()
		{
			return this.topRightMenu1.getFactionTabBar();
		}

		// Token: 0x06001885 RID: 6277 RVA: 0x0001940B File Offset: 0x0001760B
		public TopLeftMenu2 getTopLeftMenu()
		{
			return this.topLeftMenu1;
		}

		// Token: 0x06001886 RID: 6278 RVA: 0x00019413 File Offset: 0x00017613
		public TopRightMenu getTopRightMenu()
		{
			return this.topRightMenu1;
		}

		// Token: 0x06001887 RID: 6279 RVA: 0x0001941B File Offset: 0x0001761B
		public MainMenuBar2 getMainMenuBar()
		{
			return this.topRightMenu1.mainMenuBar;
		}

		// Token: 0x06001888 RID: 6280 RVA: 0x00019428 File Offset: 0x00017628
		public void setMainAreaVisible(bool state)
		{
			this.mainRightHandPanel1.Visible = state;
			this.dxBasePanel.Visible = state;
		}

		// Token: 0x06001889 RID: 6281 RVA: 0x00019442 File Offset: 0x00017642
		public bool isFullMainArea()
		{
			return !this.mainRightHandPanel1.Visible;
		}

		// Token: 0x0600188A RID: 6282 RVA: 0x00019452 File Offset: 0x00017652
		public void setMainWindowAreaVisible(bool state)
		{
			this.dxBasePanel.Visible = state;
		}

		// Token: 0x0600188B RID: 6283 RVA: 0x00019460 File Offset: 0x00017660
		private void MainWindowLarge_Activated(object sender, EventArgs e)
		{
			GameEngine.Instance.WindowActive = true;
		}

		// Token: 0x0600188C RID: 6284 RVA: 0x0001946D File Offset: 0x0001766D
		private void MainWindowLarge_Deactivate(object sender, EventArgs e)
		{
			GameEngine.Instance.WindowActive = false;
		}

		// Token: 0x0600188D RID: 6285 RVA: 0x00182218 File Offset: 0x00180418
		private void MainWindowLarge_FormClosed(object sender, FormClosedEventArgs e)
		{
			CloseReason closeReason = e.CloseReason;
			if (closeReason == CloseReason.WindowsShutDown || closeReason == CloseReason.UserClosing || closeReason == CloseReason.ApplicationExitCall)
			{
				GameEngine.Instance.windowClosing();
			}
		}

		// Token: 0x0600188E RID: 6286 RVA: 0x0001947A File Offset: 0x0001767A
		public void finaliseResize()
		{
			this.MainWindowLarge_ResizeEnd(null, null);
		}

		// Token: 0x0600188F RID: 6287 RVA: 0x00019484 File Offset: 0x00017684
		private void MainWindowLarge_ResizeBegin(object sender, EventArgs e)
		{
			this.dxBasePanel.resizing = true;
			GameEngine.Instance.startResizeWindow();
		}

		// Token: 0x06001890 RID: 6288 RVA: 0x00182244 File Offset: 0x00180444
		private void MainWindowLarge_ResizeEnd(object sender, EventArgs e)
		{
			this.dxBasePanel.resizing = false;
			if (GameEngine.Instance != null)
			{
				GameEngine.Instance.resizeWindow();
				if (GameEngine.Instance.World != null)
				{
					GameEngine.Instance.World.setScreenSize(this.dxBasePanel.Width, this.dxBasePanel.Height);
				}
			}
			Program.mySettings.ScreenWidth = base.ClientSize.Width;
			Program.mySettings.ScreenHeight = base.ClientSize.Height;
			this.topLeftMenu1.resize();
			this.topRightMenu1.resize();
		}

		// Token: 0x06001891 RID: 6289 RVA: 0x0001949C File Offset: 0x0001769C
		public void allowResizing(bool state)
		{
			this.m_allowResizing = state;
		}

		// Token: 0x06001892 RID: 6290 RVA: 0x001822E8 File Offset: 0x001804E8
		public void MainWindowLarge_SizeChanged(object sender, EventArgs e)
		{
			if (!this.m_allowResizing)
			{
				return;
			}
			GameEngine.Instance.finaliseResize = true;
			if (this.steamOverlayed)
			{
				this.origDXSize = new Size(base.ClientSize.Width - this.mainRightHandPanel1.Width, base.ClientSize.Height - 120);
				this.dxBasePanel.Size = base.ClientSize;
			}
			else
			{
				this.dxBasePanel.Width = base.ClientSize.Width - this.mainRightHandPanel1.Width;
				this.dxBasePanel.Height = base.ClientSize.Height - 120;
			}
			this.mainRightHandPanel1.Height = base.ClientSize.Height - 120;
			this.mainRightHandPanel1.Location = new Point(base.ClientSize.Width - this.mainRightHandPanel1.Width, this.mainRightHandPanel1.Location.Y);
			this.topRightMenu1.Size = new Size(base.ClientSize.Width - this.topLeftMenu1.Width, this.topRightMenu1.Height);
			if (GameEngine.Instance != null)
			{
				GameEngine.Instance.resizeWindow();
				if (GameEngine.Instance.World != null)
				{
					GameEngine.Instance.World.setScreenSize(this.dxBasePanel.Width, this.dxBasePanel.Height);
				}
			}
			if (base.ClientSize.Width >= 1100)
			{
				this.topLeftMenu1.Size = new Size(base.ClientSize.Width / 2 + 86, this.topLeftMenu1.Size.Height);
			}
			else
			{
				this.topLeftMenu1.Size = new Size(base.ClientSize.Width - 463, this.topLeftMenu1.Size.Height);
			}
			this.topRightMenu1.Size = new Size(base.ClientSize.Width - this.topLeftMenu1.Size.Width, this.topRightMenu1.Size.Height);
			this.topRightMenu1.Location = new Point(this.topLeftMenu1.Size.Width, this.topRightMenu1.Location.Y);
			this.topLeftMenu1.resize();
			this.topRightMenu1.resize();
		}

		// Token: 0x06001893 RID: 6291 RVA: 0x00182580 File Offset: 0x00180780
		private void MainWindow_Load(object sender, EventArgs e)
		{
			Screen primaryScreen = Screen.PrimaryScreen;
			Point location = primaryScreen.WorkingArea.Location;
			location.X += (primaryScreen.WorkingArea.Width - base.Size.Width) / 2;
			location.Y += (primaryScreen.WorkingArea.Height - base.Size.Height) / 2;
			base.Location = location;
		}

		// Token: 0x06001894 RID: 6292 RVA: 0x00182604 File Offset: 0x00180804
		private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseReason closeReason = e.CloseReason;
			if (closeReason == CloseReason.UserClosing && RemoteServices.Instance.UserID >= 0)
			{
				if (!InterfaceMgr.Instance.isLogoutPopupOpen())
				{
					InterfaceMgr.Instance.openLogoutWindow(true);
				}
				e.Cancel = true;
			}
		}

		// Token: 0x06001895 RID: 6293 RVA: 0x00182648 File Offset: 0x00180848
		private void MainWindow_LocationChanged(object sender, EventArgs e)
		{
			InterfaceMgr.Instance.movePlayCardsWindow();
			InterfaceMgr.Instance.moveLogoutWindow();
			InterfaceMgr.Instance.moveReportCaptureWindow();
			InterfaceMgr.Instance.moveScoutPopupWindow();
			InterfaceMgr.Instance.moveGreyOutWindow();
			InterfaceMgr.Instance.moveTutorialWindow();
			InterfaceMgr.Instance.moveTutorialArrowWindow();
			InterfaceMgr.Instance.moveFreeCardsPopup();
			InterfaceMgr.Instance.moveWheelPopup();
			InterfaceMgr.Instance.moveWheelSelectPopup();
			InterfaceMgr.Instance.moveAdvancedCastleOptionsPopup();
			InterfaceMgr.Instance.moveAchievementPopup();
		}

		// Token: 0x06001896 RID: 6294 RVA: 0x001826D0 File Offset: 0x001808D0
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 528 && MainWindow.captureCloseMenuEvent)
			{
				InterfaceMgr.Instance.closeMenuPopup();
			}
			else if (m.Msg == 1591 && Program.arcInstall)
			{
				if ((int)m.LParam != 0)
				{
					if (!this.steamOverlayed)
					{
						InterfaceMgr.Instance.ParentMainWindow.makeFullDX();
						GameEngine.Instance.GFX.fullDeviceReset();
					}
					InterfaceMgr.Instance.closeAllPopups();
					Program.arc_overlay_open = true;
				}
				else
				{
					InterfaceMgr.Instance.ParentMainWindow.restoreDXSize();
					GameEngine.Instance.GFX.resizeWindow();
					Program.arc_overlay_open = false;
				}
				Program.arc_overlay_delay = 5;
			}
			base.WndProc(ref m);
		}

		// Token: 0x040028EF RID: 10479
		private CustomSelfDrawPanel.CSDImage debugBgd = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040028F0 RID: 10480
		private bool steamOverlayed;

		// Token: 0x040028F1 RID: 10481
		private Point origDXLoc;

		// Token: 0x040028F2 RID: 10482
		private Size origDXSize;

		// Token: 0x040028F3 RID: 10483
		private bool m_allowResizing;

		// Token: 0x040028F4 RID: 10484
		public static bool captureCloseMenuEvent;
	}
}
