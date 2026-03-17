using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000208 RID: 520
	public class InterfaceMgr
	{
		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06001454 RID: 5204 RVA: 0x00015CE3 File Offset: 0x00013EE3
		public static InterfaceMgr Instance
		{
			get
			{
				if (InterfaceMgr.instance == null)
				{
					InterfaceMgr.instance = new InterfaceMgr();
				}
				return InterfaceMgr.instance;
			}
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x06001455 RID: 5205 RVA: 0x00015CFB File Offset: 0x00013EFB
		public MainWindow ParentMainWindow
		{
			get
			{
				return this.parentMainWindow;
			}
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x06001456 RID: 5206 RVA: 0x00015D03 File Offset: 0x00013F03
		public Form ParentForm
		{
			get
			{
				return this.parentForm;
			}
		}

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x06001457 RID: 5207 RVA: 0x00015D0B File Offset: 0x00013F0B
		public Form ChatForm
		{
			get
			{
				return this.chatScreenManager.ChatForm();
			}
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x06001458 RID: 5208 RVA: 0x00015D18 File Offset: 0x00013F18
		public int WorldMapMode
		{
			get
			{
				return this.worldMapMode;
			}
		}

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x06001459 RID: 5209 RVA: 0x00015D20 File Offset: 0x00013F20
		// (set) Token: 0x0600145A RID: 5210 RVA: 0x00015D28 File Offset: 0x00013F28
		public int StockExchangeBuyingVillage
		{
			get
			{
				return this.stockExchangeBuyingVillage;
			}
			set
			{
				this.stockExchangeBuyingVillage = value;
			}
		}

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x0600145B RID: 5211 RVA: 0x00015D31 File Offset: 0x00013F31
		// (set) Token: 0x0600145C RID: 5212 RVA: 0x00015D39 File Offset: 0x00013F39
		public int AttackTargetHomeVillage
		{
			get
			{
				return this.attackTargetHomeVillage;
			}
			set
			{
				this.attackTargetHomeVillage = value;
			}
		}

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x0600145D RID: 5213 RVA: 0x00015D42 File Offset: 0x00013F42
		// (set) Token: 0x0600145E RID: 5214 RVA: 0x00015D4A File Offset: 0x00013F4A
		public int VassalSelectHomeVillage
		{
			get
			{
				return this.vassalSelectHomeVillage;
			}
			set
			{
				this.vassalSelectHomeVillage = value;
			}
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x0600145F RID: 5215 RVA: 0x00015D53 File Offset: 0x00013F53
		// (set) Token: 0x06001460 RID: 5216 RVA: 0x00015D5B File Offset: 0x00013F5B
		public int MonkSelectHomeVillage
		{
			get
			{
				return this.monkSelectHomeVillage;
			}
			set
			{
				this.monkSelectHomeVillage = value;
			}
		}

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06001461 RID: 5217 RVA: 0x00015D64 File Offset: 0x00013F64
		// (set) Token: 0x06001462 RID: 5218 RVA: 0x00015D6C File Offset: 0x00013F6C
		public int SelectedVillage
		{
			get
			{
				return this.m_reallySelectedVillage;
			}
			set
			{
				this.m_reallySelectedVillage = value;
				GameEngine.Instance.World.createTributeLinesList(this.m_reallySelectedVillage);
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x06001463 RID: 5219 RVA: 0x00015D8A File Offset: 0x00013F8A
		public int OwnSelectedVillage
		{
			get
			{
				return this.m_ownSelectedVillage;
			}
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06001464 RID: 5220 RVA: 0x00015D92 File Offset: 0x00013F92
		public int SelectedVassalVillage
		{
			get
			{
				return this.m_selectedVassalVillage;
			}
		}

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06001465 RID: 5221 RVA: 0x00015D9A File Offset: 0x00013F9A
		// (set) Token: 0x06001466 RID: 5222 RVA: 0x00015DA2 File Offset: 0x00013FA2
		public int CourtierHomeVillage
		{
			get
			{
				return this.courtierHomeVillage;
			}
			set
			{
				this.courtierHomeVillage = value;
			}
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x06001467 RID: 5223 RVA: 0x00015DAB File Offset: 0x00013FAB
		public int LastVillageTab
		{
			get
			{
				return this.lastVillageTab;
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06001468 RID: 5224 RVA: 0x00015DB3 File Offset: 0x00013FB3
		public int FloatingInputValue
		{
			get
			{
				return this.m_floatingInputValue;
			}
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x06001469 RID: 5225 RVA: 0x00015DBB File Offset: 0x00013FBB
		public string FloatingInputString
		{
			get
			{
				return this.m_floatingInputString;
			}
		}

		// Token: 0x0600146A RID: 5226 RVA: 0x0015A4BC File Offset: 0x001586BC
		public bool isOverDXScreen(Point mousepos)
		{
			return (GameEngine.Instance.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_VILLAGE || GameEngine.Instance.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_WORLD || GameEngine.Instance.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_CASTLE) && InterfaceMgr.Instance.getDXBasePanel().ClientRectangle.Contains(mousepos);
		}

		// Token: 0x0600146B RID: 5227 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void StopDrawing()
		{
		}

		// Token: 0x0600146C RID: 5228 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void StartDrawing()
		{
		}

		// Token: 0x0600146D RID: 5229 RVA: 0x00015DC3 File Offset: 0x00013FC3
		public bool isDXVisible()
		{
			return this.parentMainWindow != null && this.parentMainWindow.getDXBasePanel() != null && this.parentMainWindow.getDXBasePanel().Visible;
		}

		// Token: 0x0600146E RID: 5230 RVA: 0x00015DEC File Offset: 0x00013FEC
		public void reactiveMainWindow()
		{
			if (this.parentForm != null)
			{
				this.parentForm.TopMost = true;
				this.parentForm.Focus();
				this.parentForm.BringToFront();
				this.parentForm.TopMost = false;
			}
		}

		// Token: 0x0600146F RID: 5231 RVA: 0x00015E25 File Offset: 0x00014025
		public void registerForm(Form parent, MainWindow newParentMainWindow)
		{
			this.parentForm = parent;
			this.parentMainWindow = newParentMainWindow;
		}

		// Token: 0x06001470 RID: 5232 RVA: 0x0015A510 File Offset: 0x00158710
		public void initInterfaces()
		{
			this.m_expandedMainSize = this.parentMainWindow.getDXBasePanel().Size;
			this.m_expandedMainSize.Width = this.m_expandedMainSize.Width + this.parentMainWindow.getMainRightHandPanel().Size.Width;
		}

		// Token: 0x06001471 RID: 5233 RVA: 0x00015E35 File Offset: 0x00014035
		public void Close()
		{
			this.villageReportBackgroundPanel.clearAllReports();
			this.mailScreenManager.clearAllMail();
			this.chatScreenManager.close(true, true);
			this.clearControls();
			this.parentMainWindow = null;
			this.parentForm = null;
		}

		// Token: 0x06001472 RID: 5234 RVA: 0x0015A560 File Offset: 0x00158760
		public void logout()
		{
			this.mailScreenManager.logout();
			this.mailScreenManager.close(true);
			this.chatScreenManager.close(true, true);
			this.chatScreenManager.logout();
			this.villageReportBackgroundPanel.clearAllReports();
			this.mailScreenManager.clearAllMail();
			this.villageReportBackgroundPanel.logout();
			this.clearControls();
			this.closeAllPopups();
			RemoteServices.Instance.UserID = -1;
			GameEngine.Instance.World.resetTutorialInfo();
			GameEngine.Instance.World.LastUpdatedCrowns = DateTime.Now.AddHours(-1.0);
			this.castleMapPanel.castleCommitReturn();
			this.m_ownSelectedVillage = -1;
			this.m_selectedVassalVillage = -1;
			this.m_selectedMenuVillage = -1;
			CustomSelfDrawPanel.FactionPanelSideBar.logout();
			PlayCardsWindow.logout();
			TutorialPanel.logout();
			PostTutorialWindow.close();
			VideoWindow.ClosePopup();
			this.nextAchievementIDs.Clear();
			GameEngine.Instance.World.clearPlaybackData();
		}

		// Token: 0x06001473 RID: 5235 RVA: 0x0015A65C File Offset: 0x0015885C
		public Rectangle getWindowRect()
		{
			Point location = this.parentForm.Location;
			return new Rectangle(location, this.parentForm.Size);
		}

		// Token: 0x06001474 RID: 5236 RVA: 0x00015E6E File Offset: 0x0001406E
		public DXPanel getDXBasePanel()
		{
			return this.parentMainWindow.getDXBasePanel();
		}

		// Token: 0x06001475 RID: 5237 RVA: 0x00015E7B File Offset: 0x0001407B
		public MainRightHandPanel getMainRightHandPanel()
		{
			return this.parentMainWindow.getMainRightHandPanel();
		}

		// Token: 0x06001476 RID: 5238 RVA: 0x00015E88 File Offset: 0x00014088
		public MainTabBar2 getMainTabBar()
		{
			return this.parentMainWindow.getMainTabBar();
		}

		// Token: 0x06001477 RID: 5239 RVA: 0x00015E95 File Offset: 0x00014095
		public VillageTabBar2 getVillageTabBar()
		{
			return this.parentMainWindow.getVillageTabBar();
		}

		// Token: 0x06001478 RID: 5240 RVA: 0x00015EA2 File Offset: 0x000140A2
		public FactionTabBar2 getFactionTabBar()
		{
			return this.parentMainWindow.getFactionTabBar();
		}

		// Token: 0x06001479 RID: 5241 RVA: 0x00015EAF File Offset: 0x000140AF
		public TopLeftMenu2 getTopLeftMenu()
		{
			return this.parentMainWindow.getTopLeftMenu();
		}

		// Token: 0x0600147A RID: 5242 RVA: 0x00015EBC File Offset: 0x000140BC
		public TopRightMenu getTopRightMenu()
		{
			return this.parentMainWindow.getTopRightMenu();
		}

		// Token: 0x0600147B RID: 5243 RVA: 0x00015EC9 File Offset: 0x000140C9
		public MainMenuBar2 getMainMenuBar()
		{
			return this.parentMainWindow.getMainMenuBar();
		}

		// Token: 0x0600147C RID: 5244 RVA: 0x00015ED6 File Offset: 0x000140D6
		public void setUserName(string userName)
		{
			this.getTopLeftMenu().setUserName(userName);
		}

		// Token: 0x0600147D RID: 5245 RVA: 0x00015EE4 File Offset: 0x000140E4
		public void setRank(int rank)
		{
			this.getTopLeftMenu().setRank(rank);
		}

		// Token: 0x0600147E RID: 5246 RVA: 0x00015EF2 File Offset: 0x000140F2
		public void changeTab(int tabID)
		{
			this.getMainTabBar().changeTab(tabID);
		}

		// Token: 0x0600147F RID: 5247 RVA: 0x00015F00 File Offset: 0x00014100
		public void showVillageTabBar()
		{
			this.getTopRightMenu().showVillageTab(true);
		}

		// Token: 0x06001480 RID: 5248 RVA: 0x00015F0E File Offset: 0x0001410E
		public void showFactionTabBar()
		{
			this.getTopRightMenu().showFactionTabBar(true);
		}

		// Token: 0x06001481 RID: 5249 RVA: 0x00015F1C File Offset: 0x0001411C
		public void clearControls()
		{
			this.clearControls(true, true, true, true);
		}

		// Token: 0x06001482 RID: 5250 RVA: 0x00015F28 File Offset: 0x00014128
		public void clearControlsBetweenPolitics()
		{
			this.clearControls(false, true, false, true);
		}

		// Token: 0x06001483 RID: 5251 RVA: 0x00015F34 File Offset: 0x00014134
		public void clearControlsLeaveRightHandPanel()
		{
			this.clearControls(true, true, true, false);
		}

		// Token: 0x06001484 RID: 5252 RVA: 0x0015A688 File Offset: 0x00158888
		public void clearControls(bool removeMainWindowPanel, bool removeVillageReportBackground, bool removePolitics, bool removeRightHandPanel)
		{
			this.doUserInfoUpdate = false;
			if (removeRightHandPanel)
			{
				this.userInfoPanel.closeControl(true);
				this.closeTraderInfoPanel();
				this.closeArmySelectedPanel();
				this.closeSelectedVillagePanel();
				this.closePersonInfoPanel();
				this.closeReinforcementSelectedPanel();
				this.getMainRightHandPanel().Controls.Clear();
			}
			this.mapFilterPanel.closeControl(true);
			this.researchPanel.closeControl(true);
			this.mailScreenManager.closeControl(true);
			this.chatScreenManager.closeControl(true);
			this.userInfoScreen.closeControl(true);
			this.mapFilterSelectPanel.closeControl(true);
			this.lastVillageTab = -1;
			this.villageReportBackgroundPanel.showPanel(-1);
			this.closeSendMonkWindow();
			this.m_selectedVassalVillage = -1;
			if (removeVillageReportBackground)
			{
				this.villageReportBackgroundPanel.closeControl(true);
			}
			if (removeMainWindowPanel)
			{
				this.getDXBasePanel().Controls.Remove(this.mainWindowPanel);
				this.parentForm.Controls.Remove(this.mainWindowPanel);
			}
			this.villageInfoBar.hide();
			this.castleInfoBar.hide();
			this.closeVillageTab();
			this.closeCastleTab();
			CapitalHelpBox.closeHelpBox();
			this.closeMedalsPopup();
			this.closeNewQuestsCompletedPopup();
			this.closeGloryVictoryWindowPopup();
		}

		// Token: 0x06001485 RID: 5253 RVA: 0x0015A7BC File Offset: 0x001589BC
		public void initWorldTab()
		{
			this.getTopRightMenu().showVillageTab(false);
			this.getTopRightMenu().showFactionTabBar(false);
			this.worldMapMode = 0;
			this.showDXWindow(true);
			this.showDXCardBar(9);
			this.userInfoPanel.initProperties(true, "User Village Info", this.parentMainWindow.getMainRightHandPanel());
			this.showMapFilterSelectPanel(true, true);
		}

		// Token: 0x06001486 RID: 5254 RVA: 0x00015F40 File Offset: 0x00014140
		public void initWorldTab_tradingVillageSelect()
		{
			this.worldMapMode = 1;
			this.showDXWindow(true);
			this.showDXCardBar(9);
			this.displayTradeWithPanel();
			this.setTradeWithVillage(-1);
			this.showMapFilterSelectPanel(false, true);
		}

		// Token: 0x06001487 RID: 5255 RVA: 0x00015F6D File Offset: 0x0001416D
		public void initWorldTab_stockExchangeSelect()
		{
			this.worldMapMode = 2;
			this.stockExchangeBuyingVillage = -1;
			this.showDXWindow(true);
			this.showDXCardBar(9);
			this.displayStockExchangeSidepanel();
			this.setStockExchangeSidePanelVillage(-1);
			this.showMapFilterSelectPanel(false, true);
		}

		// Token: 0x06001488 RID: 5256 RVA: 0x00015FA1 File Offset: 0x000141A1
		public void initWorldTab_attackTargetSelect()
		{
			this.worldMapMode = 3;
			this.attackTargetHomeVillage = -1;
			this.showDXWindow(true);
			this.showDXCardBar(9);
			this.displayAttackTargetSidepanel();
			this.setAttackTargetSidePanelVillage(-1);
			this.showMapFilterSelectPanel(false, true);
		}

		// Token: 0x06001489 RID: 5257 RVA: 0x00015FD5 File Offset: 0x000141D5
		public void initWorldTab_scoutTargetSelect()
		{
			this.worldMapMode = 4;
			this.attackTargetHomeVillage = -1;
			this.showDXWindow(true);
			this.showDXCardBar(9);
			this.displayScoutTargetSidepanel();
			this.setScoutTargetSidePanelVillage(-1);
			this.showMapFilterSelectPanel(false, true);
		}

		// Token: 0x0600148A RID: 5258 RVA: 0x00016009 File Offset: 0x00014209
		public void initWorldTab_vassalSelect()
		{
			this.worldMapMode = 7;
			this.vassalSelectHomeVillage = -1;
			this.showDXWindow(true);
			this.showDXCardBar(9);
			this.displayVassalSelectSidePanel();
			this.setVassalSelectSidePanelVillage(-1);
			this.showMapFilterSelectPanel(false, true);
		}

		// Token: 0x0600148B RID: 5259 RVA: 0x0001603D File Offset: 0x0001423D
		public void initWorldTab_monkSelect()
		{
			this.worldMapMode = 9;
			this.monkSelectHomeVillage = -1;
			this.showDXWindow(true);
			this.showDXCardBar(9);
			this.displayMonkSelectSidePanel();
			this.setMonkSelectSidePanelVillage(-1);
			this.showMapFilterSelectPanel(false, true);
		}

		// Token: 0x0600148C RID: 5260 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void closeMonksPanel()
		{
		}

		// Token: 0x0600148D RID: 5261 RVA: 0x00016072 File Offset: 0x00014272
		public bool isUserInfoVisible()
		{
			return this.userInfoPanel.isVisible();
		}

		// Token: 0x0600148E RID: 5262 RVA: 0x0015A81C File Offset: 0x00158A1C
		public void showUserInfo()
		{
			if (!this.userInfoPanel.isVisible())
			{
				this.userInfoPanel.display(false, this.parentMainWindow.getMainRightHandPanel(), 0, 182);
				this.userInfoPanel.init();
				this.userInfoRefreshCountdown = 5;
			}
			this.userInfoPanel.SendToBack();
			if (this.userInfoPanel.Parent != null && this.userInfoRefreshCountdown > 0)
			{
				this.userInfoRefreshCountdown--;
				if (this.userInfoRefreshCountdown > 0)
				{
					foreach (object obj in this.userInfoPanel.Parent.Controls)
					{
						Control control = (Control)obj;
						if (control != this.userInfoPanel)
						{
							control.Invalidate();
						}
					}
				}
			}
		}

		// Token: 0x0600148F RID: 5263 RVA: 0x0001607F File Offset: 0x0001427F
		public void clearAndCloseUserInfo()
		{
			this.lastViewedVillage = -1;
			this.closeUserInfo();
		}

		// Token: 0x06001490 RID: 5264 RVA: 0x0001608E File Offset: 0x0001428E
		public void closeUserInfo()
		{
			this.userInfoPanel.closeControl(true);
		}

		// Token: 0x06001491 RID: 5265 RVA: 0x0015A8FC File Offset: 0x00158AFC
		public void userInfoUpdate()
		{
			GameEngine.Instance.World.monitorCachedVillageUserInfo();
			WorldMap.VillageRolloverInfo villageInfo = null;
			WorldMap.CachedUserInfo cachedUserInfo = null;
			GameEngine.Instance.World.retrieveUserData(this.lastViewedVillage, -1, ref villageInfo, ref cachedUserInfo, false, false);
			if (cachedUserInfo != null)
			{
				this.showUserInfo();
				this.userInfoPanel.updateVillageInfo(villageInfo, cachedUserInfo);
				return;
			}
			this.closeUserInfo();
		}

		// Token: 0x06001492 RID: 5266 RVA: 0x0015A958 File Offset: 0x00158B58
		public void worldTabUpdate(bool special)
		{
			if (this.attackTargetSidePanel.isVisible())
			{
				this.attackTargetSidePanel.update();
			}
			if (this.monkTargetSidePanel.isVisible())
			{
				this.monkTargetSidePanel.update();
			}
			if (this.reinforcementTargetSidePanel.isVisible())
			{
				this.reinforcementTargetSidePanel.update();
			}
			if (this.scoutTargetSidePanel.isVisible())
			{
				this.scoutTargetSidePanel.update();
			}
			if (this.stockExchangeSidePanel.isVisible())
			{
				this.stockExchangeSidePanel.update();
			}
			if (this.tradeWithPanel.isVisible())
			{
				this.tradeWithPanel.update();
			}
			if (this.vassalAttackVillagePanel.isVisible())
			{
				this.vassalAttackVillagePanel.update();
			}
			if (this.vassalSelectSidePanel.isVisible())
			{
				this.vassalSelectSidePanel.update();
			}
			if (this.emptyVillagePanel.isVisible())
			{
				this.emptyVillagePanel.update();
			}
			if (this.selectArmyPanel.isVisible())
			{
				this.selectArmyPanel.update();
			}
			if (this.selectReinforcementPanel.isVisible())
			{
				this.selectReinforcementPanel.update();
			}
			if (this.userInfoScreen.isVisible())
			{
				this.userInfoScreen.update();
			}
			if (this.doUserInfoUpdate)
			{
				this.userInfoUpdate();
			}
			if (this.parishCapitalVillagePanel.isVisible())
			{
				this.parishCapitalVillagePanel.update();
			}
			if (this.countyCapitalVillagePanel.isVisible())
			{
				this.countyCapitalVillagePanel.update();
			}
			if (this.countryCapitalVillagePanel.isVisible())
			{
				this.countryCapitalVillagePanel.update();
			}
			if (this.provinceCapitalVillagePanel.isVisible())
			{
				this.provinceCapitalVillagePanel.update();
			}
			if (this.ownParishCapitalPanel.isVisible())
			{
				this.ownParishCapitalPanel.update();
			}
			if (this.ownCountyCapitalPanel.isVisible())
			{
				this.ownCountyCapitalPanel.update();
			}
			if (this.ownProvinceCapitalPanel.isVisible())
			{
				this.ownProvinceCapitalPanel.update();
			}
			if (this.ownCountryCapitalPanel.isVisible())
			{
				this.ownCountryCapitalPanel.update();
			}
			if (this.ownVillagePanel.isVisible())
			{
				this.ownVillagePanel.update();
			}
			if (this.otherVillagePanel.isVisible())
			{
				this.otherVillagePanel.update();
			}
			if (this.vassalVillagePanel.isVisible())
			{
				this.vassalVillagePanel.update();
			}
			if (this.mapFilterPanel.isVisible())
			{
				this.mapFilterPanel.update();
			}
		}

		// Token: 0x06001493 RID: 5267 RVA: 0x0001609C File Offset: 0x0001429C
		public void deselectVillage()
		{
			if (this.SelectedVillage > 0)
			{
				this.SelectedVillage = -1;
			}
		}

		// Token: 0x06001494 RID: 5268 RVA: 0x0015ABB4 File Offset: 0x00158DB4
		public void displaySelectedVillagePanel(int villageID, bool doubleClick, bool doShowUserInfo, bool forceSelfClick, bool forceInactiveNonPlayer)
		{
			UniversalDebugLog.Log("clicked on village! " + villageID.ToString());
			this.showMapFilterSelectPanel(true, true, true, false);
			this.clearRightHandPanel_Special();
			this.doUserInfoUpdate = false;
			this.userInfoRefreshCountdown = 5;
			bool flag = this.emptyVillagePanel.isVisible();
			bool flag2 = this.ownVillagePanel.isVisible();
			bool flag3 = this.ownParishCapitalPanel.isVisible();
			bool flag4 = this.ownCountyCapitalPanel.isVisible();
			bool flag5 = this.ownProvinceCapitalPanel.isVisible();
			bool flag6 = this.ownCountryCapitalPanel.isVisible();
			bool flag7 = this.otherVillagePanel.isVisible();
			bool flag8 = this.parishCapitalVillagePanel.isVisible();
			bool flag9 = this.countyCapitalVillagePanel.isVisible();
			bool flag10 = this.provinceCapitalVillagePanel.isVisible();
			bool flag11 = this.countryCapitalVillagePanel.isVisible();
			bool flag12 = this.vassalVillagePanel.isVisible();
			bool flag13 = this.vassalAttackVillagePanel.isVisible();
			bool flag14 = false;
			bool flag15 = false;
			bool flag16 = false;
			bool flag17 = false;
			bool flag18 = false;
			bool flag19 = false;
			bool flag20 = false;
			bool flag21 = false;
			bool flag22 = false;
			bool flag23 = false;
			bool flag24 = false;
			bool flag25 = false;
			bool flag26 = false;
			WorldMap.SpecialVillageCache specialData = null;
			if (!forceSelfClick && villageID == this.getSelectedMenuVillage())
			{
				forceSelfClick = true;
			}
			this.m_forcedMenuVillage = -1;
			bool flag27 = false;
			if (RemoteServices.Instance.Admin && GameEngine.shiftPressed && GameEngine.Instance.World.isCapital(villageID))
			{
				flag27 = true;
			}
			int y = 0;
			if ((forceSelfClick || doubleClick) && (GameEngine.Instance.World.isUserVillage(villageID) || flag27) && !forceInactiveNonPlayer)
			{
				this.setVillageNameBar(villageID);
				if (!GameEngine.Instance.World.isCapital(villageID))
				{
					GameEngine.Instance.MovedFromVillageID = villageID;
					flag15 = true;
					if (!this.ownVillagePanel.isVisible())
					{
						this.ownVillagePanel.initProperties(true, "", null);
						this.ownVillagePanel.display(this.parentMainWindow.getMainRightHandPanel(), 0, y);
						this.ownVillagePanel.init();
					}
					this.ownVillagePanel.updateOwnVillageText(villageID);
					if (doubleClick)
					{
						InterfaceMgr.Instance.getMainTabBar().changeTab(1);
					}
				}
				else if (GameEngine.Instance.World.isRegionCapital(villageID))
				{
					flag16 = true;
					if (!this.ownParishCapitalPanel.isVisible())
					{
						this.ownParishCapitalPanel.initProperties(true, "", null);
						this.ownParishCapitalPanel.display(this.parentMainWindow.getMainRightHandPanel(), 0, y);
						this.ownParishCapitalPanel.init();
					}
					this.ownParishCapitalPanel.updateOwnVillageText(villageID);
					if (doubleClick)
					{
						if (flag27)
						{
							this.m_forcedMenuVillage = villageID;
						}
						this.m_reallySelectedVillage = villageID;
						InterfaceMgr.Instance.getMainTabBar().changeTab(2);
					}
				}
				else if (GameEngine.Instance.World.isCountyCapital(villageID))
				{
					flag17 = true;
					if (!this.ownCountyCapitalPanel.isVisible())
					{
						this.ownCountyCapitalPanel.initProperties(true, "", null);
						this.ownCountyCapitalPanel.display(this.parentMainWindow.getMainRightHandPanel(), 0, y);
						this.ownCountyCapitalPanel.init();
					}
					this.ownCountyCapitalPanel.updateOwnVillageText(villageID);
					if (doubleClick)
					{
						if (flag27)
						{
							this.m_forcedMenuVillage = villageID;
						}
						this.m_reallySelectedVillage = villageID;
						InterfaceMgr.Instance.getMainTabBar().changeTab(2);
					}
				}
				else if (GameEngine.Instance.World.isProvinceCapital(villageID))
				{
					flag18 = true;
					if (!this.ownProvinceCapitalPanel.isVisible())
					{
						this.ownProvinceCapitalPanel.initProperties(true, "", null);
						this.ownProvinceCapitalPanel.display(this.parentMainWindow.getMainRightHandPanel(), 0, y);
						this.ownProvinceCapitalPanel.init();
					}
					this.ownProvinceCapitalPanel.updateOwnVillageText(villageID);
					if (doubleClick)
					{
						if (flag27)
						{
							this.m_forcedMenuVillage = villageID;
						}
						this.m_reallySelectedVillage = villageID;
						InterfaceMgr.Instance.getMainTabBar().changeTab(2);
					}
				}
				else if (GameEngine.Instance.World.isCountryCapital(villageID))
				{
					flag19 = true;
					if (!this.ownCountryCapitalPanel.isVisible())
					{
						this.ownCountryCapitalPanel.initProperties(true, "", null);
						this.ownCountryCapitalPanel.display(this.parentMainWindow.getMainRightHandPanel(), 0, y);
						this.ownCountryCapitalPanel.init();
					}
					this.ownCountryCapitalPanel.updateOwnVillageText(villageID);
					if (doubleClick)
					{
						if (flag27)
						{
							this.m_forcedMenuVillage = villageID;
						}
						this.m_reallySelectedVillage = villageID;
						InterfaceMgr.Instance.getMainTabBar().changeTab(2);
					}
				}
				this.m_selectedVassalVillage = -1;
			}
			else if (GameEngine.Instance.World.isCapital(villageID) && this.m_selectedVassalVillage < 0)
			{
				if (GameEngine.Instance.World.isRegionCapital(villageID))
				{
					flag21 = true;
					if (!this.parishCapitalVillagePanel.isVisible())
					{
						this.parishCapitalVillagePanel.initProperties(true, "", null);
						this.parishCapitalVillagePanel.display(this.parentMainWindow.getMainRightHandPanel(), 0, y);
						this.parishCapitalVillagePanel.init();
					}
					this.parishCapitalVillagePanel.updateParishCapitalVillageText(villageID, this.OwnSelectedVillage);
					if ((forceSelfClick || doubleClick) && GameEngine.Instance.World.isUserRelatedVillage(villageID))
					{
						this.m_ownSelectedVillage = -1;
						this.setVillageNameBar(villageID);
						GameEngine.Instance.MovedFromVillageID = villageID;
						this.parishCapitalVillagePanel.updateParishCapitalVillageText(villageID, this.OwnSelectedVillage);
						if (doubleClick)
						{
							this.m_reallySelectedVillage = villageID;
							InterfaceMgr.Instance.getMainTabBar().changeTab(2);
						}
					}
				}
				else if (GameEngine.Instance.World.isCountyCapital(villageID))
				{
					flag22 = true;
					if (!this.countyCapitalVillagePanel.isVisible())
					{
						this.countyCapitalVillagePanel.initProperties(true, "", null);
						this.countyCapitalVillagePanel.display(this.parentMainWindow.getMainRightHandPanel(), 0, y);
						this.countyCapitalVillagePanel.init();
					}
					this.countyCapitalVillagePanel.updateCountyCapitalVillageText(villageID, this.OwnSelectedVillage);
					if ((forceSelfClick || doubleClick) && GameEngine.Instance.World.isUserRelatedVillage(villageID))
					{
						this.m_ownSelectedVillage = -1;
						this.setVillageNameBar(villageID);
						GameEngine.Instance.MovedFromVillageID = villageID;
						this.countyCapitalVillagePanel.updateCountyCapitalVillageText(villageID, this.OwnSelectedVillage);
						if (doubleClick)
						{
							this.m_reallySelectedVillage = villageID;
							InterfaceMgr.Instance.getMainTabBar().changeTab(2);
						}
					}
				}
				else if (GameEngine.Instance.World.isProvinceCapital(villageID))
				{
					flag23 = true;
					if (!this.provinceCapitalVillagePanel.isVisible())
					{
						this.provinceCapitalVillagePanel.initProperties(true, "", null);
						this.provinceCapitalVillagePanel.display(this.parentMainWindow.getMainRightHandPanel(), 0, y);
						this.provinceCapitalVillagePanel.init();
					}
					this.provinceCapitalVillagePanel.updateProvinceCapitalVillageText(villageID, this.OwnSelectedVillage);
					if ((forceSelfClick || doubleClick) && GameEngine.Instance.World.isUserRelatedVillage(villageID))
					{
						this.m_ownSelectedVillage = -1;
						this.setVillageNameBar(villageID);
						GameEngine.Instance.MovedFromVillageID = villageID;
						this.provinceCapitalVillagePanel.updateProvinceCapitalVillageText(villageID, this.OwnSelectedVillage);
						if (doubleClick)
						{
							this.m_reallySelectedVillage = villageID;
							InterfaceMgr.Instance.getMainTabBar().changeTab(2);
						}
					}
				}
				else if (GameEngine.Instance.World.isCountryCapital(villageID))
				{
					flag24 = true;
					if (!this.countryCapitalVillagePanel.isVisible())
					{
						this.countryCapitalVillagePanel.initProperties(true, "", null);
						this.countryCapitalVillagePanel.display(this.parentMainWindow.getMainRightHandPanel(), 0, y);
						this.countryCapitalVillagePanel.init();
					}
					this.countryCapitalVillagePanel.updateCountryCapitalVillageText(villageID, this.OwnSelectedVillage);
					if ((forceSelfClick || doubleClick) && GameEngine.Instance.World.isUserRelatedVillage(villageID))
					{
						this.m_ownSelectedVillage = -1;
						this.setVillageNameBar(villageID);
						GameEngine.Instance.MovedFromVillageID = villageID;
						this.countryCapitalVillagePanel.updateCountryCapitalVillageText(villageID, this.OwnSelectedVillage);
						if (doubleClick)
						{
							this.m_reallySelectedVillage = villageID;
							InterfaceMgr.Instance.getMainTabBar().changeTab(2);
						}
					}
				}
				this.m_reallySelectedVillage = villageID;
			}
			else
			{
				int num = GameEngine.Instance.World.getVillageUserID(villageID);
				if (GameEngine.Instance.LocalWorldData.AIWorld && num - 1 <= 3)
				{
					num = -1;
				}
				if (num < 0)
				{
					if (!forceInactiveNonPlayer && this.m_selectedVassalVillage >= 0)
					{
						flag26 = true;
						if (!this.vassalAttackVillagePanel.isVisible())
						{
							this.vassalAttackVillagePanel.initProperties(true, "", null);
							this.vassalAttackVillagePanel.display(this.parentMainWindow.getMainRightHandPanel(), 0, y);
							this.vassalAttackVillagePanel.init(villageID);
						}
						this.vassalAttackVillagePanel.updateOtherVillageText(villageID);
					}
					else
					{
						bool flag28 = false;
						if (GameEngine.Instance.World.isSpecial(villageID))
						{
							flag28 = true;
							specialData = GameEngine.Instance.World.getSpecialVillageData(villageID, true);
						}
						flag14 = true;
						if (!this.emptyVillagePanel.isVisible())
						{
							this.emptyVillagePanel.initProperties(true, "", null);
							this.emptyVillagePanel.display(this.parentMainWindow.getMainRightHandPanel(), 0, y);
							this.emptyVillagePanel.init(villageID);
						}
						this.emptyVillagePanel.updateEmptyVillageText(villageID);
						this.emptyVillagePanel.updateSpecialData(specialData);
						if (forceInactiveNonPlayer && flag28)
						{
							this.emptyVillagePanel.forceDisable();
						}
					}
				}
				else if (!flag15)
				{
					if (!forceInactiveNonPlayer && GameEngine.Instance.World.isVassal(this.m_ownSelectedVillage, villageID))
					{
						flag25 = true;
						if (!this.vassalVillagePanel.isVisible())
						{
							this.vassalVillagePanel.initProperties(true, "", null);
							this.vassalVillagePanel.display(this.parentMainWindow.getMainRightHandPanel(), 0, y);
							this.vassalVillagePanel.init();
						}
						this.vassalVillagePanel.updateVassalVillageText(villageID);
						if (this.m_selectedVassalVillage != villageID)
						{
							this.m_selectedVassalVillage = -1;
						}
					}
					else if (!forceInactiveNonPlayer && this.m_selectedVassalVillage >= 0)
					{
						flag26 = true;
						if (!this.vassalAttackVillagePanel.isVisible())
						{
							this.vassalAttackVillagePanel.initProperties(true, "", null);
							this.vassalAttackVillagePanel.display(this.parentMainWindow.getMainRightHandPanel(), 0, y);
							this.vassalAttackVillagePanel.init(villageID);
						}
						this.vassalAttackVillagePanel.updateOtherVillageText(villageID);
					}
					else
					{
						flag20 = true;
						if (!this.otherVillagePanel.isVisible())
						{
							this.otherVillagePanel.initProperties(true, "", null);
							this.otherVillagePanel.display(this.parentMainWindow.getMainRightHandPanel(), 0, y);
							this.otherVillagePanel.init();
						}
						this.otherVillagePanel.updateOtherVillageText(villageID);
						if (forceInactiveNonPlayer)
						{
							this.otherVillagePanel.forceDisable();
						}
					}
				}
			}
			if (GameEngine.Instance.World.isSpecial(villageID))
			{
				if (GameEngine.Instance.LocalWorldData.AIWorld)
				{
					switch (GameEngine.Instance.World.getSpecial(villageID))
					{
					case 7:
					case 9:
					case 11:
					case 13:
						break;
					default:
						doShowUserInfo = false;
						this.closeUserInfo();
						break;
					}
				}
				else
				{
					doShowUserInfo = false;
					this.closeUserInfo();
				}
			}
			if (doShowUserInfo)
			{
				this.doUserInfoUpdate = true;
				WorldMap.VillageRolloverInfo villageInfo = null;
				WorldMap.CachedUserInfo cachedUserInfo = null;
				if (villageID != this.lastViewedVillage)
				{
					this.lastViewedVillage = villageID;
					GameEngine.Instance.World.retrieveUserData(villageID, -1, ref villageInfo, ref cachedUserInfo, true, false);
				}
				else
				{
					GameEngine.Instance.World.retrieveUserData(villageID, -1, ref villageInfo, ref cachedUserInfo, false, false);
				}
				if (cachedUserInfo != null)
				{
					this.showUserInfo();
					this.userInfoPanel.updateVillageInfo(villageInfo, cachedUserInfo);
				}
				else
				{
					this.closeUserInfo();
				}
			}
			else
			{
				GameEngine.Instance.World.clearCachedVillageUserInfo();
			}
			if (flag && !flag14)
			{
				this.emptyVillagePanel.closeControl(true);
			}
			if (flag7 && !flag20)
			{
				this.otherVillagePanel.closeControl(true);
			}
			if (flag2 && !flag15)
			{
				this.ownVillagePanel.closeControl(true);
			}
			if (flag3 && !flag16)
			{
				this.ownParishCapitalPanel.closeControl(true);
			}
			if (flag4 && !flag17)
			{
				this.ownCountyCapitalPanel.closeControl(true);
			}
			if (flag5 && !flag18)
			{
				this.ownProvinceCapitalPanel.closeControl(true);
			}
			if (flag6 && !flag19)
			{
				this.ownCountryCapitalPanel.closeControl(true);
			}
			if (flag8 && !flag21)
			{
				this.parishCapitalVillagePanel.closeControl(true);
			}
			if (flag9 && !flag22)
			{
				this.countyCapitalVillagePanel.closeControl(true);
			}
			if (flag10 && !flag23)
			{
				this.provinceCapitalVillagePanel.closeControl(true);
			}
			if (flag11 && !flag24)
			{
				this.countryCapitalVillagePanel.closeControl(true);
			}
			if (flag12 && !flag25)
			{
				this.vassalVillagePanel.closeControl(true);
			}
			if (flag13 && !flag26)
			{
				this.vassalAttackVillagePanel.closeControl(true);
			}
			this.m_reallySelectedVillage = villageID;
			GameEngine.Instance.World.createTributeLinesList(villageID);
		}

		// Token: 0x06001495 RID: 5269 RVA: 0x000160AE File Offset: 0x000142AE
		public void setVassalAttackMode(int vassalVillageID)
		{
			this.m_selectedVassalVillage = vassalVillageID;
		}

		// Token: 0x06001496 RID: 5270 RVA: 0x000160B7 File Offset: 0x000142B7
		public void selectVillage(int villageID)
		{
			this.m_reallySelectedVillage = villageID;
		}

		// Token: 0x06001497 RID: 5271 RVA: 0x0015B824 File Offset: 0x00159A24
		public void closeSelectedVillagePanel()
		{
			this.closeUserInfo();
			this.emptyVillagePanel.closeControl(true);
			this.ownVillagePanel.closeControl(true);
			this.ownParishCapitalPanel.closeControl(true);
			this.ownCountyCapitalPanel.closeControl(true);
			this.ownProvinceCapitalPanel.closeControl(true);
			this.ownCountryCapitalPanel.closeControl(true);
			this.otherVillagePanel.closeControl(true);
			this.parishCapitalVillagePanel.closeControl(true);
			this.countyCapitalVillagePanel.closeControl(true);
			this.provinceCapitalVillagePanel.closeControl(true);
			this.countryCapitalVillagePanel.closeControl(true);
			this.vassalVillagePanel.closeControl(true);
			this.vassalAttackVillagePanel.closeControl(true);
			this.monkTargetSidePanel.closeControl(true);
			this.attackTargetSidePanel.closeControl(true);
			this.reinforcementTargetSidePanel.closeControl(true);
			this.scoutTargetSidePanel.closeControl(true);
			this.selectArmyPanel.closeControl(true);
			this.selectReinforcementPanel.closeControl(true);
			this.traderInfoPanel.closeControl(true);
			this.tradeWithPanel.closeControl(true);
			this.vassalAttackVillagePanel.closeControl(true);
			this.vassalSelectSidePanel.closeControl(true);
			this.m_reallySelectedVillage = -1;
		}

		// Token: 0x06001498 RID: 5272 RVA: 0x0015B954 File Offset: 0x00159B54
		public void closeSelectedVillagePanelButNotSelect()
		{
			this.closeUserInfo();
			this.emptyVillagePanel.closeControl(true);
			this.ownVillagePanel.closeControl(true);
			this.ownParishCapitalPanel.closeControl(true);
			this.ownCountyCapitalPanel.closeControl(true);
			this.ownProvinceCapitalPanel.closeControl(true);
			this.ownCountryCapitalPanel.closeControl(true);
			this.otherVillagePanel.closeControl(true);
			this.parishCapitalVillagePanel.closeControl(true);
			this.countyCapitalVillagePanel.closeControl(true);
			this.provinceCapitalVillagePanel.closeControl(true);
			this.countryCapitalVillagePanel.closeControl(true);
			this.vassalVillagePanel.closeControl(true);
			this.vassalAttackVillagePanel.closeControl(true);
			this.selectArmyPanel.closeControl(true);
			this.selectReinforcementPanel.closeControl(true);
			this.traderInfoPanel.closeControl(true);
			this.vassalAttackVillagePanel.closeControl(true);
		}

		// Token: 0x06001499 RID: 5273 RVA: 0x0015BA34 File Offset: 0x00159C34
		public void clearRightHandPanel_Special()
		{
			this.vassalVillagePanel.closeControl(true);
			this.vassalAttackVillagePanel.closeControl(true);
			this.monkTargetSidePanel.closeControl(true);
			this.attackTargetSidePanel.closeControl(true);
			this.reinforcementTargetSidePanel.closeControl(true);
			this.scoutTargetSidePanel.closeControl(true);
			this.selectArmyPanel.closeControl(true);
			this.selectReinforcementPanel.closeControl(true);
			this.traderInfoPanel.closeControl(true);
			this.tradeWithPanel.closeControl(true);
			this.vassalAttackVillagePanel.closeControl(true);
			this.vassalSelectSidePanel.closeControl(true);
			this.mapFilterPanel.closeControl(true);
		}

		// Token: 0x0600149A RID: 5274 RVA: 0x0015BAE0 File Offset: 0x00159CE0
		public void displayArmySelectPanel(long armyID)
		{
			int y = 0;
			this.MapSelectedArmy = armyID;
			if (!this.selectArmyPanel.isVisible())
			{
				this.selectArmyPanel.initProperties(true, "", null);
				this.selectArmyPanel.display(this.parentMainWindow.getMainRightHandPanel(), 0, y);
				this.selectArmyPanel.init();
			}
			this.selectArmyPanel.armySelected(armyID);
		}

		// Token: 0x0600149B RID: 5275 RVA: 0x000160C0 File Offset: 0x000142C0
		public void closeArmySelectedPanel()
		{
			this.selectArmyPanel.closeControl(true);
			this.MapSelectedArmy = -1L;
		}

		// Token: 0x0600149C RID: 5276 RVA: 0x0015BB44 File Offset: 0x00159D44
		public void selectTutorialArmy()
		{
			long tutorialArmyID = GameEngine.Instance.World.getTutorialArmyID();
			if (tutorialArmyID >= 0L)
			{
				this.closeFilterPanel();
				this.closeSelectedVillagePanel();
				this.closeTraderInfoPanel();
				this.closeReinforcementSelectedPanel();
				this.closePersonInfoPanel();
				this.clearAndCloseUserInfo();
				this.displayArmySelectPanel(tutorialArmyID);
			}
		}

		// Token: 0x0600149D RID: 5277 RVA: 0x0015BB94 File Offset: 0x00159D94
		public void displayReinforcementSelectPanel(long armyID)
		{
			this.MapSelectedReinforcement = armyID;
			if (!this.selectReinforcementPanel.isVisible())
			{
				this.selectReinforcementPanel.initProperties(true, "", null);
				this.selectReinforcementPanel.display(this.parentMainWindow.getMainRightHandPanel(), 0, 0);
				this.selectReinforcementPanel.init();
			}
			this.selectReinforcementPanel.reinforcementSelected(armyID);
		}

		// Token: 0x0600149E RID: 5278 RVA: 0x000160D6 File Offset: 0x000142D6
		public void closeReinforcementSelectedPanel()
		{
			this.selectReinforcementPanel.closeControl(true);
			this.MapSelectedReinforcement = -1L;
		}

		// Token: 0x0600149F RID: 5279 RVA: 0x000160EC File Offset: 0x000142EC
		public void displayTradeWithPanel()
		{
			this.tradeWithPanel.initProperties(true, "", null);
			this.tradeWithPanel.display(this.parentMainWindow.getMainRightHandPanel(), 0, 0);
			this.tradeWithPanel.init();
		}

		// Token: 0x060014A0 RID: 5280 RVA: 0x00016123 File Offset: 0x00014323
		public void setTradeWithVillage(int villageID)
		{
			this.tradeWithPanel.setTradeWithVillage(villageID);
		}

		// Token: 0x060014A1 RID: 5281 RVA: 0x00016131 File Offset: 0x00014331
		public void tradeWithResume(int villageID, bool keepInfo)
		{
			this.villageReportBackgroundPanel.tradeWithResume(villageID, keepInfo);
		}

		// Token: 0x060014A2 RID: 5282 RVA: 0x00016140 File Offset: 0x00014340
		public void displayStockExchangeSidepanel()
		{
			this.stockExchangeSidePanel.initProperties(true, "", null);
			this.stockExchangeSidePanel.display(this.parentMainWindow.getMainRightHandPanel(), 0, 0);
			this.stockExchangeSidePanel.init();
		}

		// Token: 0x060014A3 RID: 5283 RVA: 0x00016177 File Offset: 0x00014377
		public void setStockExchangeSidePanelVillage(int villageID)
		{
			this.stockExchangeSidePanel.setStockExchange(villageID);
		}

		// Token: 0x060014A4 RID: 5284 RVA: 0x00016185 File Offset: 0x00014385
		public void selectStockExchange(int villageID)
		{
			this.villageReportBackgroundPanel.selectExchange(villageID);
		}

		// Token: 0x060014A5 RID: 5285 RVA: 0x00016193 File Offset: 0x00014393
		public void displayAttackTargetSidepanel()
		{
			this.attackTargetSidePanel.initProperties(true, "", null);
			this.attackTargetSidePanel.display(this.parentMainWindow.getMainRightHandPanel(), 0, 0);
			this.attackTargetSidePanel.init();
		}

		// Token: 0x060014A6 RID: 5286 RVA: 0x000161CA File Offset: 0x000143CA
		public void setAttackTargetSidePanelVillage(int villageID)
		{
			this.attackTargetSidePanel.setTarget(villageID);
		}

		// Token: 0x060014A7 RID: 5287 RVA: 0x000161D8 File Offset: 0x000143D8
		public void selectAttackTarget(int villageID)
		{
			this.villageReportBackgroundPanel.selectAttackTarget(villageID);
		}

		// Token: 0x060014A8 RID: 5288 RVA: 0x000161E6 File Offset: 0x000143E6
		public void setVassalTargetVillage(int villageID, int targetVillageID)
		{
			this.villageReportBackgroundPanel.setVassalTargetVillage(villageID, targetVillageID);
		}

		// Token: 0x060014A9 RID: 5289 RVA: 0x000161F5 File Offset: 0x000143F5
		public void setReinforcementVillage(int villageID)
		{
			this.villageReportBackgroundPanel.setReinforcementVillage(villageID);
		}

		// Token: 0x060014AA RID: 5290 RVA: 0x00016203 File Offset: 0x00014403
		public void displayScoutTargetSidepanel()
		{
			this.scoutTargetSidePanel.initProperties(true, "", null);
			this.scoutTargetSidePanel.display(this.parentMainWindow.getMainRightHandPanel(), 0, 0);
			this.scoutTargetSidePanel.init();
		}

		// Token: 0x060014AB RID: 5291 RVA: 0x0001623A File Offset: 0x0001443A
		public void setScoutTargetSidePanelVillage(int villageID)
		{
			this.scoutTargetSidePanel.setTarget(villageID);
		}

		// Token: 0x060014AC RID: 5292 RVA: 0x00016248 File Offset: 0x00014448
		public void selectScoutTarget(int villageID)
		{
			this.villageReportBackgroundPanel.selectScoutsTarget(villageID);
		}

		// Token: 0x060014AD RID: 5293 RVA: 0x0015BBF8 File Offset: 0x00159DF8
		public void displayTraderInfoPanel(long traderID)
		{
			this.MapSelectedTrader = traderID;
			if (!this.traderInfoPanel.isVisible())
			{
				this.traderInfoPanel.initProperties(true, "", null);
				this.traderInfoPanel.display(this.parentMainWindow.getMainRightHandPanel(), 0, 0);
				this.traderInfoPanel.init();
			}
			this.traderInfoPanel.setTrader(traderID);
		}

		// Token: 0x060014AE RID: 5294 RVA: 0x00016256 File Offset: 0x00014456
		public void closeTraderInfoPanel()
		{
			this.traderInfoPanel.closeControl(true);
			this.MapSelectedTrader = -1L;
		}

		// Token: 0x060014AF RID: 5295 RVA: 0x0001626C File Offset: 0x0001446C
		public void updateTraderInfo()
		{
			if (this.traderInfoPanel.isVisible())
			{
				this.traderInfoPanel.update();
			}
		}

		// Token: 0x060014B0 RID: 5296 RVA: 0x0015BC5C File Offset: 0x00159E5C
		public void displayPersonInfoPanel(long personID)
		{
			this.MapSelectedPerson = personID;
			if (!this.personInfoPanel.isVisible())
			{
				this.personInfoPanel.initProperties(true, "", null);
				this.personInfoPanel.display(this.parentMainWindow.getMainRightHandPanel(), 0, 0);
				this.personInfoPanel.init();
			}
			this.personInfoPanel.setPerson(personID);
		}

		// Token: 0x060014B1 RID: 5297 RVA: 0x00016286 File Offset: 0x00014486
		public void closePersonInfoPanel()
		{
			this.personInfoPanel.closeControl(true);
			this.MapSelectedPerson = -1L;
		}

		// Token: 0x060014B2 RID: 5298 RVA: 0x0001629C File Offset: 0x0001449C
		public void updatePersonInfo()
		{
			if (this.personInfoPanel.isVisible())
			{
				this.personInfoPanel.update();
			}
		}

		// Token: 0x060014B3 RID: 5299 RVA: 0x000162B6 File Offset: 0x000144B6
		public void initWorldTab_courtierTargetSelect()
		{
			this.worldMapMode = 5;
			this.courtierHomeVillage = -1;
			this.showDXWindow(true);
			this.displayReinforcementTargetSidepanel();
			this.setReinforcementTargetSidePanelVillage(-1);
			this.showMapFilterSelectPanel(false, true);
		}

		// Token: 0x060014B4 RID: 5300 RVA: 0x000162E2 File Offset: 0x000144E2
		public void displayReinforcementTargetSidepanel()
		{
			this.reinforcementTargetSidePanel.initProperties(true, "", null);
			this.reinforcementTargetSidePanel.display(this.parentMainWindow.getMainRightHandPanel(), 0, 0);
			this.reinforcementTargetSidePanel.init();
		}

		// Token: 0x060014B5 RID: 5301 RVA: 0x00016319 File Offset: 0x00014519
		public void setReinforcementTargetSidePanelVillage(int villageID)
		{
			this.reinforcementTargetSidePanel.setReinforcementTarget(villageID);
		}

		// Token: 0x060014B6 RID: 5302 RVA: 0x00016327 File Offset: 0x00014527
		public void displayVassalSelectSidePanel()
		{
			this.vassalSelectSidePanel.initProperties(true, "", null);
			this.vassalSelectSidePanel.display(this.parentMainWindow.getMainRightHandPanel(), 0, 0);
			this.vassalSelectSidePanel.init();
		}

		// Token: 0x060014B7 RID: 5303 RVA: 0x0001635E File Offset: 0x0001455E
		public void setVassalSelectSidePanelVillage(int villageID)
		{
			this.vassalSelectSidePanel.setTarget(villageID);
		}

		// Token: 0x060014B8 RID: 5304 RVA: 0x0001636C File Offset: 0x0001456C
		public void selectVassalTarget(int villageID)
		{
			this.villageReportBackgroundPanel.selectVassalVillage(villageID);
		}

		// Token: 0x060014B9 RID: 5305 RVA: 0x0001637A File Offset: 0x0001457A
		public void displayMonkSelectSidePanel()
		{
			this.monkTargetSidePanel.initProperties(true, "", null);
			this.monkTargetSidePanel.display(this.parentMainWindow.getMainRightHandPanel(), 0, 0);
			this.monkTargetSidePanel.init();
		}

		// Token: 0x060014BA RID: 5306 RVA: 0x000163B1 File Offset: 0x000145B1
		public void setMonkSelectSidePanelVillage(int villageID)
		{
			this.monkTargetSidePanel.setTarget(villageID);
		}

		// Token: 0x060014BB RID: 5307 RVA: 0x000163BF File Offset: 0x000145BF
		public void setVassalArmiesVillage(int villageID)
		{
			this.villageReportBackgroundPanel.setVassalArmiesVillage(villageID);
		}

		// Token: 0x060014BC RID: 5308 RVA: 0x000163CD File Offset: 0x000145CD
		public bool wasShowingVassalSendScreen()
		{
			return this.lastVillageTab == 15;
		}

		// Token: 0x060014BD RID: 5309 RVA: 0x000163DC File Offset: 0x000145DC
		public void setVillageInfoBar(VillageInfoBar2 infoBar, CastleInfoBar2 cInfoBar)
		{
			this.villageInfoBar = infoBar;
			this.castleInfoBar = cInfoBar;
		}

		// Token: 0x060014BE RID: 5310 RVA: 0x000163EC File Offset: 0x000145EC
		public void initVillageTabTabBarsOnly()
		{
			this.getTopRightMenu().showVillageTab(true);
			this.getTopRightMenu().showFactionTabBar(false);
		}

		// Token: 0x060014BF RID: 5311 RVA: 0x0015BCC0 File Offset: 0x00159EC0
		public void initVillageTab()
		{
			this.getTopRightMenu().showVillageTab(true);
			this.getTopRightMenu().showFactionTabBar(false);
			this.showDXWindow(false);
			this.showDXCardBar(10);
			this.villageMapPanel.Height = this.parentMainWindow.getMainRightHandPanel().Height;
			this.villageMapPanel.initProperties(true, "VillageBuildings", null);
			this.villageMapPanel.display(this.parentMainWindow.getMainRightHandPanel(), 6, 5);
			this.initVillageTab_Quick();
			int tutorialStage = GameEngine.Instance.World.getTutorialStage();
			if (tutorialStage == 100)
			{
				GameEngine.Instance.World.advanceTutorialOLD();
			}
			if (GameEngine.Instance.Village != null)
			{
				GameEngine.Instance.Village.createSurroundSprites();
				GameEngine.Instance.Village.Camera.Drag(new Point(0, 0));
			}
		}

		// Token: 0x060014C0 RID: 5312 RVA: 0x0015BD9C File Offset: 0x00159F9C
		public void initVillageTab_Quick()
		{
			this.updateVillageInfoBar();
			if (GameEngine.Instance.Village != null)
			{
				this.villageMapPanel.showAsVillage(!this.isSelectedVillageACapital(GameEngine.Instance.Village.VillageID));
			}
			VillageMap.closePopups();
			this.villageMapPanel.showNewInterface();
			this.villageMapPanel.showExtras();
		}

		// Token: 0x060014C1 RID: 5313 RVA: 0x0015BDFC File Offset: 0x00159FFC
		public void updateVillageInfoBar()
		{
			if (this.getVillageTabBar().getCurrentTab() == 0)
			{
				bool flag = GameEngine.Instance.World.isCapital(this.getSelectedMenuVillage());
				if (!this.villageInfoBar.isVisible() || this.getVillageTabBar().lastVillageCapital != flag)
				{
					this.villageInfoBar.show();
					this.villageInfoBar.removeHeading();
					return;
				}
			}
			else if (this.getVillageTabBar().getCurrentTab() == 3 && GameEngine.Instance.World.isCapital(this.getSelectedMenuVillage()) && (!this.villageInfoBar.isVisible() || !this.getVillageTabBar().lastVillageCapital))
			{
				this.villageInfoBar.show();
				this.villageInfoBar.removeHeading();
			}
		}

		// Token: 0x060014C2 RID: 5314 RVA: 0x00016406 File Offset: 0x00014606
		public void ensureInfoTabCleared()
		{
			if (this.villageInfoBar.isVisible())
			{
				this.villageInfoBar.hide();
			}
		}

		// Token: 0x060014C3 RID: 5315 RVA: 0x0015BEB4 File Offset: 0x0015A0B4
		public void initVillageTabView()
		{
			this.getTopRightMenu().showVillageTab(false);
			this.getTopRightMenu().showFactionTabBar(false);
			this.showDXWindow(false);
			this.showDXCardBar(10);
			this.villageMapPanel.Height = this.parentMainWindow.getMainRightHandPanel().Height;
			this.villageMapPanel.initProperties(true, "VillageBuildings", null);
			this.villageMapPanel.display(this.parentMainWindow.getMainRightHandPanel(), 6, 5);
			this.villageInfoBar.show();
			VillageMap.closePopups();
			this.villageMapPanel.showExtras();
		}

		// Token: 0x060014C4 RID: 5316 RVA: 0x00016420 File Offset: 0x00014620
		public void villageMapResizeWindow()
		{
			this.villageMapPanel.Height = this.parentMainWindow.getMainRightHandPanel().Height;
		}

		// Token: 0x060014C5 RID: 5317 RVA: 0x0001643D File Offset: 0x0001463D
		public void SetVillageViewMode(bool viewOnly)
		{
			this.villageMapPanel.ViewOnly = viewOnly;
		}

		// Token: 0x060014C6 RID: 5318 RVA: 0x0015BF48 File Offset: 0x0015A148
		public void setVillageInfoData(int woodLevel, int clayLevel, int stoneLevel, int foodLevel, bool gotStockpile, bool gotGranary, int totalPeople, int housingCapacity, int spareWorkers, int pitchLevel, bool viewOnly, int ironLevel, int capitalGold, int villageID, int numFlags)
		{
			GameEngine.GameDisplays gameDisplayMode = GameEngine.Instance.GameDisplayMode;
			if (gameDisplayMode == GameEngine.GameDisplays.DISPLAY_VILLAGE)
			{
				this.villageInfoBar.setDisplayedLevels(woodLevel, stoneLevel, foodLevel, gotStockpile, gotGranary, totalPeople, housingCapacity, spareWorkers, viewOnly, capitalGold, villageID, numFlags);
				return;
			}
			if (gameDisplayMode != GameEngine.GameDisplays.DISPLAY_CASTLE)
			{
				return;
			}
			this.castleInfoBar.setDisplayedLevels(woodLevel, stoneLevel, pitchLevel, ironLevel);
		}

		// Token: 0x060014C7 RID: 5319 RVA: 0x0001644B File Offset: 0x0001464B
		public void setVillageHeading(string text)
		{
			if (!this.villageInfoBar.isVisible() || this.villageInfoBar.Parent == null)
			{
				this.villageInfoBar.show();
			}
			this.villageInfoBar.Visible = true;
			this.villageInfoBar.setHeading(text);
		}

		// Token: 0x060014C8 RID: 5320 RVA: 0x0015BF9C File Offset: 0x0015A19C
		public void showVillageStats(int taxLevel, int rationsLevel, int aleRationsLevel, int popularity, double popularityChange, string timeLeftString, string migrationTimeString, double effectiveRationsLevel, int numFoodTypesEaten, double effectiveAleRationsLevel, double housingChangeLevel, double goldDayRate, double dailyFoodConsumption, int totalPeople, int housingCapacity, int numPositiveBuildings, int numNegativeBuildings, PopEventData[] popEvents, double dailyAleConsumption, DateTime curTime, double foodProductionRate, double aleProductionRate, int numPopularityBuildings, int parishTax)
		{
			this.villageMapPanel.showStats(taxLevel, rationsLevel, aleRationsLevel, popularity, popularityChange, timeLeftString, effectiveRationsLevel, numFoodTypesEaten, effectiveAleRationsLevel, housingChangeLevel);
			this.villageMapPanel.showMigration(popularity, migrationTimeString, totalPeople, housingCapacity);
			this.villageMapPanel.showGoldChange(GameEngine.Instance.World.getCurrentGold(), GameEngine.Instance.World.getCurrentGoldRate());
			this.villageMapPanel.showDayRates(goldDayRate, dailyFoodConsumption, dailyAleConsumption, foodProductionRate, aleProductionRate, parishTax);
			this.villageMapPanel.showBuildingInfo(numPositiveBuildings, numNegativeBuildings, numPopularityBuildings);
			this.villageMapPanel.showPopEvents(popEvents, curTime);
		}

		// Token: 0x060014C9 RID: 5321 RVA: 0x0015C038 File Offset: 0x0015A238
		public void showVillageStats2(int numChurches, int numChapels, int numCathedrals, int numSmallGardens, int numLargeGardens, int numSmallStatues, int numLargeStatues, int numDovecotes, int numStocks, int numBurningPosts, int numGibbets, int numRacks, bool lastbanquetStored, double lastBanquetHonour, DateTime lastBanquetDate, double lastTributePayment, double popularityLevel, int capitalTaxRate, int parishTax, ParishTaxCalc[] parishTaxPeople, int parentCapitalTaxRate, int lastCapitalTaxRate, int parishBonus)
		{
			this.villageMapPanel.showHonour();
			this.villageMapPanel.showHonourBuildings(numChurches, numChapels, numCathedrals, numSmallGardens, numLargeGardens, numSmallStatues, numLargeStatues, numDovecotes, numStocks, numBurningPosts, numGibbets, numRacks, popularityLevel, parishBonus);
			if (lastbanquetStored)
			{
				this.villageMapPanel.showHonourBanquet(lastBanquetHonour, lastBanquetDate);
			}
			else
			{
				this.villageMapPanel.showHonourBanquet(0.0, lastBanquetDate);
			}
			this.villageMapPanel.showCapitalData(capitalTaxRate, parishTax, parishTaxPeople, parentCapitalTaxRate, lastCapitalTaxRate);
		}

		// Token: 0x060014CA RID: 5322 RVA: 0x0001648A File Offset: 0x0001468A
		public void closeVillageTab()
		{
			if (GameEngine.Instance.Village != null)
			{
				GameEngine.Instance.Village.leaveMap();
			}
			VillageMap.closePopups();
		}

		// Token: 0x060014CB RID: 5323 RVA: 0x000164AC File Offset: 0x000146AC
		public bool isVillageMapPanelOnFoodTab()
		{
			return this.villageMapPanel.isVillageMapPanelOnFoodTab();
		}

		// Token: 0x060014CC RID: 5324 RVA: 0x000164B9 File Offset: 0x000146B9
		public bool isVillageMapPanelOnIndustryTab()
		{
			return this.villageMapPanel.isVillageMapPanelOnIndustryTab();
		}

		// Token: 0x060014CD RID: 5325 RVA: 0x000164C6 File Offset: 0x000146C6
		public bool isVillageMapPanelOnPopularityBar()
		{
			return this.villageMapPanel.isVillageMapPanelOnPopularityBar();
		}

		// Token: 0x060014CE RID: 5326 RVA: 0x000164D3 File Offset: 0x000146D3
		public bool isVillageHonourTabOpen()
		{
			return this.villageMapPanel.isHonourTabOpen();
		}

		// Token: 0x060014CF RID: 5327 RVA: 0x000164E0 File Offset: 0x000146E0
		public int getVillageMapPanelHonourTabPos()
		{
			return this.villageMapPanel.calcInfoTabYPos();
		}

		// Token: 0x060014D0 RID: 5328 RVA: 0x000164ED File Offset: 0x000146ED
		public int getVillageMapPanelBuildTabPos()
		{
			return this.villageMapPanel.TUTORIAL_getBuildTabYPos();
		}

		// Token: 0x060014D1 RID: 5329 RVA: 0x0015C0B4 File Offset: 0x0015A2B4
		public void showVillageBuildingInfo(string buildingName, int woodCost, int stoneCost, int clayCost, int goldCost, int flagsNeeded, string buildTimeString, int buildingType, int realBuildingType)
		{
			this.villageMapPanel.setBuildingInfo(buildingName, woodCost, stoneCost, clayCost, goldCost, flagsNeeded, buildTimeString, buildingType, realBuildingType);
		}

		// Token: 0x060014D2 RID: 5330 RVA: 0x000164FA File Offset: 0x000146FA
		public void updateSidepanelAfterBuildingPlaced()
		{
			this.villageMapPanel.refreshCurrentTab();
		}

		// Token: 0x060014D3 RID: 5331 RVA: 0x00016507 File Offset: 0x00014707
		public void clearVillageBuildingInfo()
		{
			this.villageMapPanel.clearBuildingInfo();
		}

		// Token: 0x060014D4 RID: 5332 RVA: 0x0015C0DC File Offset: 0x0015A2DC
		public void villageChanged(int villageID)
		{
			if (GameEngine.Instance.Village != null)
			{
				GameEngine.Instance.Village.leaveMap();
			}
			this.villageMapPanel.showAsVillage(!this.isSelectedVillageACapital(villageID));
			this.villageMapPanel.showNewInterface();
			VillageMap.closePopups();
		}

		// Token: 0x060014D5 RID: 5333 RVA: 0x00016514 File Offset: 0x00014714
		public bool isInBuildingPanelOpen()
		{
			return this.villageMapPanel.isInBuildingPanelOpen();
		}

		// Token: 0x060014D6 RID: 5334 RVA: 0x00016521 File Offset: 0x00014721
		public void showInBuildingInfo(VillageMapBuilding building)
		{
			this.villageMapPanel.showInBuildingInfo(building);
		}

		// Token: 0x060014D7 RID: 5335 RVA: 0x0001652F File Offset: 0x0001472F
		public VillageMapBuilding getInBuildingBuilding()
		{
			return this.villageMapPanel.getInBuildingBuilding();
		}

		// Token: 0x060014D8 RID: 5336 RVA: 0x0001653C File Offset: 0x0001473C
		public void villageReshowAfterStockpilePlaced()
		{
			this.villageMapPanel.villageReshowAfterStockpilePlaced();
		}

		// Token: 0x060014D9 RID: 5337 RVA: 0x00016549 File Offset: 0x00014749
		public void capitalDonateResourcesInit(int villageID, VillageMapBuilding selectedBuilding)
		{
			this.villageReportBackgroundPanel.capitalDonateResourcesInit(villageID, selectedBuilding);
		}

		// Token: 0x060014DA RID: 5338 RVA: 0x00016558 File Offset: 0x00014758
		public void runVillageInterface()
		{
			if (this.villageMapPanel.isVisible())
			{
				this.villageMapPanel.run();
			}
		}

		// Token: 0x060014DB RID: 5339 RVA: 0x00016572 File Offset: 0x00014772
		public void stopIndustryEnabled()
		{
			this.villageMapPanel.stopIndustryEnabled();
		}

		// Token: 0x060014DC RID: 5340 RVA: 0x0001657F File Offset: 0x0001477F
		public void mapPanelCreates()
		{
			this.villageMapPanel.create();
			this.castleMapPanel.create();
			this.castleMapAttackerSetupPanel.create();
			this.castleMapBattlePanel.create();
		}

		// Token: 0x060014DD RID: 5341 RVA: 0x0015C12C File Offset: 0x0015A32C
		public void showFactionPanel(int factionID)
		{
			if (this.getMainTabBar().getCurrentTab() != 8)
			{
				GameEngine.Instance.setNextFactionPage(42);
				FactionMyFactionPanel.SelectedFaction = factionID;
				this.getMainTabBar().changeTab(8);
				return;
			}
			if (this.getFactionTabBar().getCurrentTab() != 1)
			{
				GameEngine.Instance.setNextFactionPage(42);
				FactionMyFactionPanel.SelectedFaction = factionID;
				this.getFactionTabBar().changeTab(1);
				return;
			}
			FactionMyFactionPanel.SelectedFaction = factionID;
			this.setVillageTabSubMode(42, false);
		}

		// Token: 0x060014DE RID: 5342 RVA: 0x0015C1A4 File Offset: 0x0015A3A4
		public void showHousePanel(int houseID)
		{
			if (this.getMainTabBar().getCurrentTab() != 8)
			{
				GameEngine.Instance.setNextFactionPage(52);
				HouseInfoPanel.SelectedHouse = houseID;
				this.getMainTabBar().changeTab(8);
				return;
			}
			if (this.getFactionTabBar().getCurrentTab() != 2)
			{
				GameEngine.Instance.setNextFactionPage(52);
				HouseInfoPanel.SelectedHouse = houseID;
				this.getFactionTabBar().changeTab(2);
				return;
			}
			HouseInfoPanel.SelectedHouse = houseID;
			this.setVillageTabSubMode(52, false);
		}

		// Token: 0x060014DF RID: 5343 RVA: 0x0015C21C File Offset: 0x0015A41C
		public void showRoyalTowerPanel()
		{
			if (this.getMainTabBar().getCurrentTab() != 8)
			{
				GameEngine.Instance.setNextFactionPage(65);
				this.getMainTabBar().changeTab(8);
				return;
			}
			if (this.getFactionTabBar().getCurrentTab() != 0)
			{
				GameEngine.Instance.setNextFactionPage(65);
				this.getFactionTabBar().changeTab(0);
				return;
			}
			this.setVillageTabSubMode(65, false);
		}

		// Token: 0x060014E0 RID: 5344 RVA: 0x000165AD File Offset: 0x000147AD
		public void showStartFactionPanel()
		{
			FactionStartFactionPanel.StartFaction = true;
			this.setVillageTabSubMode(47, false);
		}

		// Token: 0x060014E1 RID: 5345 RVA: 0x000165BE File Offset: 0x000147BE
		public void showEditFactionPanel()
		{
			FactionStartFactionPanel.StartFaction = false;
			this.setVillageTabSubMode(47, false);
		}

		// Token: 0x060014E2 RID: 5346 RVA: 0x000165CF File Offset: 0x000147CF
		public void showFactionForumPosts(long threadID, long forumID, string threadTitle, string forumTitle)
		{
			FactionNewForumPostsPanel.ThreadID = threadID;
			FactionNewForumPostsPanel.parentForumID = forumID;
			FactionNewForumPostsPanel.ThreadTitle = threadTitle;
			FactionNewForumPostsPanel.ForumTitle = forumTitle;
			this.setVillageTabSubMode(48, false);
		}

		// Token: 0x060014E3 RID: 5347 RVA: 0x000165F3 File Offset: 0x000147F3
		public void showCapitalForumPosts(long threadID, long forumID, string threadTitle, int areaID, int areaType, string forumTitle)
		{
			CapitalForumPostsPanel.ThreadID = threadID;
			CapitalForumPostsPanel.parentForumID = forumID;
			CapitalForumPostsPanel.ThreadTitle = threadTitle;
			CapitalForumPostsPanel.ForumTitle = forumTitle;
			CapitalForumPostsPanel.areaID = areaID;
			CapitalForumPostsPanel.areaType = areaType;
			this.setVillageTabSubMode(1009, false);
		}

		// Token: 0x060014E4 RID: 5348 RVA: 0x00016628 File Offset: 0x00014828
		public void setVillageTabSubMode(int mode)
		{
			this.setVillageTabSubMode(mode, false);
		}

		// Token: 0x060014E5 RID: 5349 RVA: 0x0015C280 File Offset: 0x0015A480
		public void setVillageTabSubMode(int mode, bool overlayTab)
		{
			this.lastVillageTab = mode;
			if (mode == -1)
			{
				this.getDXBasePanel().Controls.Remove(this.mainWindowPanel);
				this.parentMainWindow.setMainWindowAreaVisible(true);
				GameEngine.Instance.forceVillageTabUpdate();
				this.getVillageTabBar().forceChangeTab(0);
				return;
			}
			GameEngine.Instance.forceVillageTabUpdate();
			if (mode >= 1000 && !this.isSelectedVillageACapital())
			{
				this.initVillageTab();
				return;
			}
			if (mode < 1000 && this.isSelectedVillageACapital() && mode != 6 && mode != 10 && mode != 19 && mode != 20 && mode != 21 && mode != 22 && mode != 23 && mode != 24 && mode != 25 && mode != 26 && mode != 31 && mode != 32 && mode != 33 && mode != 34 && mode != 41 && mode != 42 && mode != 45 && mode != 46 && mode != 43 && mode != 44 && mode != 47 && mode != 48 && mode != 52 && mode != 51 && mode != 99 && mode != 100 && mode != 60 && mode != 65)
			{
				this.initVillageTab();
				return;
			}
			this.StopDrawing();
			this.addMainWindow(this.firstVillageBackgroundCall, overlayTab);
			this.firstVillageBackgroundCall = false;
			this.villageReportBackgroundPanel.initProperties(true, "Village Reports", this.mainWindowPanel);
			this.villageReportBackgroundPanel.Size = this.mainWindowPanel.Size;
			this.villageReportBackgroundPanel.display(this.mainWindowPanel, 0, 0);
			this.villageReportBackgroundPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.villageReportBackgroundPanel.showPanel(mode);
			if (mode <= 1009)
			{
				switch (mode)
				{
				case 0:
					this.getVillageTabBar().changeTabGfxOnly(5);
					goto IL_484;
				case 1:
					this.getVillageTabBar().changeTabGfxOnly(6);
					goto IL_484;
				case 2:
					goto IL_327;
				case 3:
					goto IL_338;
				case 4:
					goto IL_35A;
				case 5:
					break;
				case 6:
				case 7:
				case 9:
				case 10:
				case 14:
				case 18:
				case 27:
				case 28:
				case 29:
				case 35:
				case 36:
				case 37:
				case 38:
				case 39:
				case 40:
				case 49:
				case 50:
				case 53:
				case 54:
				case 55:
				case 56:
				case 57:
				case 58:
				case 59:
					goto IL_484;
				case 8:
					this.getVillageTabBar().changeTabGfxOnly(7);
					goto IL_484;
				case 11:
				case 12:
				case 13:
					this.getVillageTabBar().changeTabGfxOnly(6);
					goto IL_484;
				case 15:
				case 16:
				case 17:
					this.getVillageTabBar().changeTabGfxOnly(9);
					goto IL_484;
				case 19:
				case 20:
				case 21:
				case 23:
				case 24:
				case 30:
					this.getTopRightMenu().showVillageTab(false);
					this.getTopRightMenu().showFactionTabBar(false);
					goto IL_484;
				case 22:
					this.getTopRightMenu().showVillageTab(false);
					this.getTopRightMenu().showFactionTabBar(true);
					goto IL_484;
				case 25:
					this.getTopRightMenu().showVillageTab(false);
					this.getTopRightMenu().showFactionTabBar(false);
					goto IL_484;
				case 26:
					this.getTopRightMenu().showVillageTab(false);
					this.getTopRightMenu().showFactionTabBar(false);
					goto IL_484;
				case 31:
					this.getTopRightMenu().showVillageTab(false);
					goto IL_484;
				case 32:
				case 33:
				case 34:
					this.getTopRightMenu().showVillageTab(false);
					goto IL_484;
				case 41:
				case 42:
				case 43:
				case 44:
				case 45:
				case 46:
				case 47:
				case 48:
				case 51:
				case 52:
					this.getTopRightMenu().showFactionTabBar(true);
					goto IL_484;
				case 60:
					this.getTopRightMenu().showVillageTab(false);
					goto IL_484;
				default:
					switch (mode)
					{
					case 1002:
						goto IL_327;
					case 1003:
						goto IL_338;
					case 1004:
						goto IL_35A;
					case 1005:
						break;
					case 1006:
						goto IL_3B0;
					case 1007:
					case 1009:
						goto IL_3C1;
					case 1008:
						goto IL_3D2;
					default:
						goto IL_484;
					}
					break;
				}
				this.getVillageTabBar().changeTabGfxOnly(2);
				GameEngine.Instance.forceVillageTabUpdate();
				goto IL_484;
				IL_327:
				this.getVillageTabBar().changeTabGfxOnly(3);
				goto IL_484;
				IL_338:
				this.getVillageTabBar().changeTabGfxOnly(3);
				goto IL_484;
				IL_35A:
				this.getVillageTabBar().changeTabGfxOnly(4);
				goto IL_484;
			}
			switch (mode)
			{
			case 1106:
				break;
			case 1107:
				goto IL_3C1;
			case 1108:
				goto IL_3D2;
			default:
				switch (mode)
				{
				case 1206:
					break;
				case 1207:
					goto IL_3C1;
				case 1208:
					goto IL_3D2;
				default:
					switch (mode)
					{
					case 1306:
						break;
					case 1307:
						goto IL_3C1;
					case 1308:
						goto IL_3D2;
					default:
						goto IL_484;
					}
					break;
				}
				break;
			}
			IL_3B0:
			this.getVillageTabBar().changeTabGfxOnly(6);
			goto IL_484;
			IL_3C1:
			this.getVillageTabBar().changeTabGfxOnly(7);
			goto IL_484;
			IL_3D2:
			this.getVillageTabBar().changeTabGfxOnly(5);
			IL_484:
			this.StartDrawing();
		}

		// Token: 0x060014E6 RID: 5350 RVA: 0x0015C718 File Offset: 0x0015A918
		public void villageDownloaded(int villageID)
		{
			GameEngine.Instance.villageHasBeenDownloaded = true;
			ScoutPopupWindow scoutPopupWindow = this.getScoutPopupWindow();
			if (scoutPopupWindow != null && scoutPopupWindow.Visible && scoutPopupWindow.Created)
			{
				scoutPopupWindow.villageLoaded(villageID);
				return;
			}
			InterfaceMgr.Instance.getVillageTabBar().updateShownTabs();
			if (this.getVillageTabBar().getCurrentTab() > 1 || !this.getVillageTabBar().Visible)
			{
				this.villageReportBackgroundPanel.newVillageLoaded();
				return;
			}
			if (this.getVillageTabBar().getCurrentTab() == 1)
			{
				this.initCastleTab();
				return;
			}
			if (this.getVillageTabBar().getCurrentTab() == 0)
			{
				this.initVillageTab_Quick();
				if (this.villageReportBackgroundPanel.isTab0OverLayActive())
				{
					this.villageReportBackgroundPanel.newVillageLoaded();
				}
			}
		}

		// Token: 0x060014E7 RID: 5351 RVA: 0x00016632 File Offset: 0x00014832
		public bool updateVillageReports()
		{
			if (this.lastVillageTab == -1)
			{
				return true;
			}
			this.villageReportBackgroundPanel.update(this.lastVillageTab);
			return false;
		}

		// Token: 0x060014E8 RID: 5352 RVA: 0x00016651 File Offset: 0x00014851
		public void resetVillageReportPanelData()
		{
			this.villageReportBackgroundPanel.resetData();
		}

		// Token: 0x060014E9 RID: 5353 RVA: 0x0001665E File Offset: 0x0001485E
		public void setCapitalSendTargetVillage(int villageID)
		{
			this.villageReportBackgroundPanel.setCapitalSendTargetVillage(villageID);
		}

		// Token: 0x060014EA RID: 5354 RVA: 0x0001666C File Offset: 0x0001486C
		public bool isTextInputScreenActive()
		{
			return this.villageReportBackgroundPanel.isTextInputScreenActive();
		}

		// Token: 0x060014EB RID: 5355 RVA: 0x0001667E File Offset: 0x0001487E
		public bool deleteReport(long reportID)
		{
			return this.villageReportBackgroundPanel.queryDeleteReport(reportID);
		}

		// Token: 0x060014EC RID: 5356 RVA: 0x0001668C File Offset: 0x0001488C
		public Point getVillageReportBackgroundLocation()
		{
			return this.villageReportBackgroundPanel.getLocation();
		}

		// Token: 0x060014ED RID: 5357 RVA: 0x0015C7C8 File Offset: 0x0015A9C8
		public void initCastleTab()
		{
			this.getTopRightMenu().showVillageTab(true);
			this.showDXWindow(false);
			this.showDXCardBar(11);
			this.castleMapPanel.Height = this.parentMainWindow.getMainRightHandPanel().Height;
			this.castleMapPanel.initProperties(true, "Castle", null);
			this.castleMapPanel.display(this.parentMainWindow.getMainRightHandPanel(), 6, 5);
			this.castleMapPanel.showNewInterface();
			this.castleInfoBar.show();
			this.castle_ClearSelectedTroop();
			if (GameEngine.Instance.Castle != null)
			{
				GameEngine.Instance.Castle.createSurroundSprites();
				GameEngine.Instance.Castle.recalcCastleLayout();
				GameEngine.Instance.Castle.moveMap(0, 0);
				if (GameEngine.Instance.Castle.isAnyConstructing())
				{
					Sound.playVillageEnvironmental(18);
				}
				else
				{
					Sound.playVillageEnvironmental(17);
				}
			}
			int tutorialStage = GameEngine.Instance.World.getTutorialStage();
			if (tutorialStage == 10)
			{
				GameEngine.Instance.World.handleQuestObjectiveHappening(10004);
			}
		}

		// Token: 0x060014EE RID: 5358 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void castleMapResizeWindow()
		{
		}

		// Token: 0x060014EF RID: 5359 RVA: 0x00016699 File Offset: 0x00014899
		public void closeCastleTab()
		{
			if (GameEngine.Instance.Castle != null)
			{
				GameEngine.Instance.Castle.leaveMap();
			}
		}

		// Token: 0x060014F0 RID: 5360 RVA: 0x00016699 File Offset: 0x00014899
		public void castleChanged()
		{
			if (GameEngine.Instance.Castle != null)
			{
				GameEngine.Instance.Castle.leaveMap();
			}
		}

		// Token: 0x060014F1 RID: 5361 RVA: 0x000166B6 File Offset: 0x000148B6
		public void runCastleInterface()
		{
			if (this.castleMapPanel.isVisible())
			{
				this.castleMapPanel.Run();
			}
		}

		// Token: 0x060014F2 RID: 5362 RVA: 0x0015C8D8 File Offset: 0x0015AAD8
		public void showCastlePieceInfo(string pieceName, int woodCost, int stoneCost, int ironCost, int pitchCost, int goldCost, string buildTimeString, bool rollover)
		{
			this.castleMapPanel.setCastleElementInfo(pieceName, woodCost, stoneCost, ironCost, pitchCost, goldCost, buildTimeString, rollover);
		}

		// Token: 0x060014F3 RID: 5363 RVA: 0x000166D0 File Offset: 0x000148D0
		public void castleStopPlacing()
		{
			this.castleMapPanel.clearCastlePlaceInfo();
			this.castleMapPanel.stopDeleting();
		}

		// Token: 0x060014F4 RID: 5364 RVA: 0x0015C900 File Offset: 0x0015AB00
		public void setCastleStats(int numGuardHouseSpaces, int numPlacedArchers, int numPlacedPeasants, int numPlacedPikemen, int numPlacedSwordsmen, DateTime completeTime, bool completed, int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numPots, int numSmelterPlaces, bool castleDamaged, int numPlacedReinforceArchers, int numPlacedReinforcePeasants, int numPlacedReinforcePikemen, int numPlacedReinforceSwordsmen, int numReinforcePeasants, int numReinforceArchers, int numReinforcePikemen, int numReinforceSwordsmen, int numAvailableVassalReinforceDefenderPeasants, int numAvailableVassalReinforceDefenderArchers, int numAvailableVassalReinforceDefenderPikemen, int numAvailableVassalReinforceDefenderSwordsmen, int numPlacedVassalReinforceDefenderArchers, int numPlacedVassalReinforceDefenderPeasants, int numPlacedVassalReinforceDefenderPikemen, int numPlacedVassalReinforceDefenderSwordsmen, int numPlacedCaptains, int numCaptains)
		{
			this.castleMapPanel.setCastleStats(numGuardHouseSpaces, numPlacedArchers, numPlacedPeasants, numPlacedPikemen, numPlacedSwordsmen, completeTime, completed, numPeasants, numArchers, numPikemen, numSwordsmen, numPots, numSmelterPlaces, castleDamaged, numPlacedReinforceArchers, numPlacedReinforcePeasants, numPlacedReinforcePikemen, numPlacedReinforceSwordsmen, numReinforcePeasants, numReinforceArchers, numReinforcePikemen, numReinforceSwordsmen, numAvailableVassalReinforceDefenderPeasants, numAvailableVassalReinforceDefenderArchers, numAvailableVassalReinforceDefenderPikemen, numAvailableVassalReinforceDefenderSwordsmen, numPlacedVassalReinforceDefenderArchers, numPlacedVassalReinforceDefenderPeasants, numPlacedVassalReinforceDefenderPikemen, numPlacedVassalReinforceDefenderSwordsmen, numPlacedCaptains, numCaptains);
		}

		// Token: 0x060014F5 RID: 5365 RVA: 0x0015C958 File Offset: 0x0015AB58
		public void castle_SetSelectedTroop(int numPeasants, int peasantsState, int numArchers, int archersState, int numPikemen, int pikemenState, int numSwordsmen, int swordsmenState, int numCaptains, int captainState)
		{
			this.castleMapPanel.setSelectedTroop(numPeasants, peasantsState, numArchers, archersState, numPikemen, pikemenState, numSwordsmen, swordsmenState, numCaptains, captainState);
		}

		// Token: 0x060014F6 RID: 5366 RVA: 0x0015C984 File Offset: 0x0015AB84
		public void castleAttack_SetSelectedTroop(int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults, int numCaptains, int captainsCommand, int captainsData)
		{
			this.castleMapAttackerSetupPanel.setSelectedTroop(numPeasants, numArchers, numPikemen, numSwordsmen, numCatapults, numCaptains, captainsCommand, captainsData);
		}

		// Token: 0x060014F7 RID: 5367 RVA: 0x000166E8 File Offset: 0x000148E8
		public void castle_ClearSelectedTroop()
		{
			this.castleMapPanel.clearSelectedTroop();
			this.castleMapAttackerSetupPanel.clearSelectedTroop();
		}

		// Token: 0x060014F8 RID: 5368 RVA: 0x00016700 File Offset: 0x00014900
		public void refreshCastleInterface()
		{
			this.castleMapPanel.refreshInterface();
		}

		// Token: 0x060014F9 RID: 5369 RVA: 0x0001670D File Offset: 0x0001490D
		public void castleStartBuilderMode()
		{
			this.castleMapPanel.castleStartBuilderMode();
		}

		// Token: 0x060014FA RID: 5370 RVA: 0x0001671A File Offset: 0x0001491A
		public void castleEndBuilderMode()
		{
			this.castleMapPanel.castleEndBuilderMode();
		}

		// Token: 0x060014FB RID: 5371 RVA: 0x00016727 File Offset: 0x00014927
		public void castleCommitReturn()
		{
			this.WaitingForCallback = false;
			this.castleMapPanel.castleCommitReturn();
		}

		// Token: 0x060014FC RID: 5372 RVA: 0x0001673B File Offset: 0x0001493B
		public bool TUTORIAL_openedWoodTab()
		{
			return this.castleMapPanel.TUTORIAL_openedWoodTab();
		}

		// Token: 0x060014FD RID: 5373 RVA: 0x0015C9AC File Offset: 0x0015ABAC
		public void initCastleAttackerSetupTab()
		{
			this.showDXWindow(false);
			this.showDXCardBar(6);
			this.castleMapAttackerSetupPanel.Height = this.parentMainWindow.getMainRightHandPanel().Height;
			this.castleMapAttackerSetupPanel.initProperties(true, "Castle", null);
			this.castleMapAttackerSetupPanel.display(this.parentMainWindow.getMainRightHandPanel(), 2, 5);
			this.castleMapAttackerSetupPanel.init();
		}

		// Token: 0x060014FE RID: 5374 RVA: 0x00016748 File Offset: 0x00014948
		public void setCastleViewTimes(DateTime castleViewTime, bool castleAvailable, DateTime troopViewTime, bool troopAvailable)
		{
			this.castleMapAttackerSetupPanel.setTimes(castleViewTime, castleAvailable, troopViewTime, troopAvailable);
		}

		// Token: 0x060014FF RID: 5375 RVA: 0x0001675A File Offset: 0x0001495A
		public void castleAttackShowRealAttack(bool state)
		{
			this.castleMapAttackerSetupPanel.showRealAttack(state);
		}

		// Token: 0x06001500 RID: 5376 RVA: 0x00016768 File Offset: 0x00014968
		public void castleAttackShowAttackReady(bool state)
		{
			this.castleMapAttackerSetupPanel.showAttackReady(state);
		}

		// Token: 0x06001501 RID: 5377 RVA: 0x0015CA18 File Offset: 0x0015AC18
		public void castleShowPlacedAttackers(int numPlacedPeasants, int numPlacedArchers, int numPlacedPikemen, int numPlacedSwordsmen, int numPlacedCatapults, int maxPeasants, int maxArchers, int maxPikemen, int maxSwordsmen, int maxCatapults, int numCaptains, int maxCaptains, int captainsCommand, int numPeasantsInCastle, int numArchersInCastle, int numPikemenInCastle, int numSwordsmenInCastle)
		{
			this.castleMapAttackerSetupPanel.setStats(numPlacedArchers, numPlacedPikemen, numPlacedSwordsmen, numPlacedPeasants, numPlacedCatapults, maxPeasants, maxArchers, maxPikemen, maxSwordsmen, maxCatapults, numCaptains, maxCaptains, captainsCommand, numPeasantsInCastle, numArchersInCastle, numPikemenInCastle, numSwordsmenInCastle);
		}

		// Token: 0x06001502 RID: 5378 RVA: 0x0015CA50 File Offset: 0x0015AC50
		public void initCastleBattleTab(bool realBattle, int attackType, bool AIAttack)
		{
			this.showDXWindow(false);
			this.showDXCardBar(11);
			this.castleMapBattlePanel.Height = this.parentMainWindow.getMainRightHandPanel().Height;
			this.castleMapBattlePanel.initProperties(true, "Castle", null);
			this.castleMapBattlePanel.battleMode(realBattle, attackType, AIAttack);
			this.castleMapBattlePanel.display(this.parentMainWindow.getMainRightHandPanel(), 2, 5);
		}

		// Token: 0x06001503 RID: 5379 RVA: 0x00016776 File Offset: 0x00014976
		public void castleBattleTimes(DateTime castleTime, DateTime troopTime)
		{
			this.castleMapBattlePanel.setTimes(castleTime, troopTime);
		}

		// Token: 0x06001504 RID: 5380 RVA: 0x00016785 File Offset: 0x00014985
		public void setCastlePillageClock(int pillageClock, int pillageClockMax)
		{
			this.castleMapBattlePanel.setPillageClock(pillageClock, pillageClockMax);
		}

		// Token: 0x06001505 RID: 5381 RVA: 0x00016794 File Offset: 0x00014994
		public void setCastleReportClock(int reportClock, int reportClockMax)
		{
			this.castleMapBattlePanel.setCastleReportClock(reportClock, reportClockMax);
		}

		// Token: 0x06001506 RID: 5382 RVA: 0x000167A3 File Offset: 0x000149A3
		public void ShowViewBattleResults(bool attackerVictory, BattleTroopNumbers startingTroops, BattleTroopNumbers endingTroops, int villageID, GetReport_ReturnType reportReturnData)
		{
			this.castleMapBattlePanel.ShowViewBattleResults(attackerVictory, startingTroops, endingTroops, villageID, reportReturnData);
		}

		// Token: 0x06001507 RID: 5383 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void showParishPanel(int parishID)
		{
		}

		// Token: 0x06001508 RID: 5384 RVA: 0x000167B7 File Offset: 0x000149B7
		public void closeParishPanel()
		{
			this.clearControlsLeaveRightHandPanel();
			this.getTopRightMenu().showVillageTab(false);
			this.getTopRightMenu().showFactionTabBar(false);
			this.worldMapMode = 0;
			this.parentMainWindow.setMainAreaVisible(true);
			this.showMapFilterSelectPanel(true, true);
		}

		// Token: 0x06001509 RID: 5385 RVA: 0x000167F2 File Offset: 0x000149F2
		public void flushParishFrontPageInfo(int parishID)
		{
			this.villageReportBackgroundPanel.flushParishFrontPageInfo(parishID);
		}

		// Token: 0x0600150A RID: 5386 RVA: 0x00016800 File Offset: 0x00014A00
		public void showUserInfoScreen(WorldMap.CachedUserInfo userInfo)
		{
			GameEngine.Instance.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_USER_INFO;
			this.addMainWindow(false, true);
			this.setVillageTabSubMode(99, true);
			this.villageReportBackgroundPanel.userInfoScreen.init(userInfo);
		}

		// Token: 0x0600150B RID: 5387 RVA: 0x0015CAC0 File Offset: 0x0015ACC0
		public void showAllVillagesScreen()
		{
			GameEngine.Instance.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_ALL_VILLAGES;
			this.addMainWindow(false, true);
			this.setVillageTabSubMode(100, true);
			if (!GameEngine.Instance.World.isAccountPremium())
			{
				MyMessageBox.Show(SK.Text("AllVillageOverview_error2", "This feature requires a premium token to be in play."), SK.Text("AllVillageOverview_error", "Premium Village Overview"));
			}
		}

		// Token: 0x0600150C RID: 5388 RVA: 0x0015CB20 File Offset: 0x0015AD20
		public void showUserInfoScreenAdmin(WorldMap.CachedUserInfo userInfo)
		{
			if (this.getMainTabBar().getCurrentTab() != 0)
			{
				this.getMainTabBar().changeTab(0);
			}
			this.clearControlsLeaveRightHandPanel();
			this.addMainWindow(false, true);
			this.userInfoScreen.Size = this.mainWindowPanel.Size;
			this.userInfoScreen.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.userInfoScreen.clear();
			this.userInfoScreen.init(userInfo);
			this.userInfoScreen.display(this.mainWindowPanel, 0, 0);
		}

		// Token: 0x0600150D RID: 5389 RVA: 0x0015CBA4 File Offset: 0x0015ADA4
		public void addMainWindow(bool allowBackgroundDraw, bool overlayTabBar)
		{
			int num = 0;
			if (overlayTabBar)
			{
				num = 28;
			}
			Size size = new Size(this.m_expandedMainSize.Width, this.m_expandedMainSize.Height + num);
			this.getTopLeftMenu().Height = 120 - num;
			this.getTopRightMenu().Height = 120 - num;
			this.mainWindowPanel.Size = size;
			this.getTopLeftMenu().setContextBarVisible(!overlayTabBar);
			this.mainWindowPanel.Location = new Point(0, 120 - num);
			this.mainWindowPanel.BringToFront();
			this.mainWindowPanel.doDraw(allowBackgroundDraw);
			if (!this.parentForm.Controls.Contains(this.mainWindowPanel))
			{
				this.parentForm.SuspendLayout();
				this.parentForm.Controls.Add(this.mainWindowPanel);
				this.parentForm.ResumeLayout(false);
			}
			this.parentMainWindow.setMainAreaVisible(false);
		}

		// Token: 0x0600150E RID: 5390 RVA: 0x00016830 File Offset: 0x00014A30
		public void addMainMiniWindow(bool firstCall)
		{
			this.addMainMiniWindow(firstCall, false);
		}

		// Token: 0x0600150F RID: 5391 RVA: 0x0015CC90 File Offset: 0x0015AE90
		public void addMainMiniWindow(bool firstCall, bool overlayTabBar)
		{
			int num = 0;
			if (overlayTabBar)
			{
				num = 28;
			}
			Size size = new Size(this.parentMainWindow.getDXBasePanel().Width, this.parentForm.ClientSize.Height - 120 + num);
			this.mainWindowPanel.Size = size;
			this.getTopLeftMenu().Height = 120 - num;
			this.getTopRightMenu().Height = 120 - num;
			this.getTopLeftMenu().setContextBarVisible(!overlayTabBar);
			this.mainWindowPanel.Location = new Point(0, 120 - num);
			this.mainWindowPanel.doDraw(firstCall);
			if (!this.parentForm.Controls.Contains(this.mainWindowPanel))
			{
				this.parentForm.SuspendLayout();
				this.parentForm.Controls.Add(this.mainWindowPanel);
				this.mainWindowPanel.ResumeLayout(false);
				this.parentForm.ResumeLayout(false);
			}
			this.parentMainWindow.setMainWindowAreaVisible(false);
		}

		// Token: 0x06001510 RID: 5392 RVA: 0x0015CD8C File Offset: 0x0015AF8C
		public void reShowDXWindow()
		{
			bool flag = this.getTopLeftMenu().contextBarVisible();
			this.showDXWindow(!flag);
		}

		// Token: 0x06001511 RID: 5393 RVA: 0x0015CDB0 File Offset: 0x0015AFB0
		public void showDXWindow(bool overlayTabBar)
		{
			int num = 0;
			if (overlayTabBar)
			{
				num = 28;
			}
			this.parentMainWindow.setMainAreaVisible(true);
			Size size = new Size(this.parentMainWindow.getDXBasePanel().Width, this.parentForm.ClientSize.Height - 120 + num);
			this.getTopLeftMenu().Height = 120 - num;
			this.getTopRightMenu().Height = 120 - num;
			this.getMainRightHandPanel().Height = this.parentForm.ClientSize.Height - 120 + num;
			this.getMainRightHandPanel().Location = new Point(this.getMainRightHandPanel().Location.X, 120 - num);
			this.parentMainWindow.getDXBasePanel().Size = size;
			this.getTopLeftMenu().setContextBarVisible(!overlayTabBar);
			this.parentMainWindow.getDXBasePanel().Location = new Point(0, 120 - num);
			GameEngine.Instance.GFX.resizeWindow();
			if (GameEngine.Instance.World != null)
			{
				GameEngine.Instance.World.setScreenSize(this.parentMainWindow.getDXBasePanel().Width, this.parentMainWindow.getDXBasePanel().Height);
			}
		}

		// Token: 0x06001512 RID: 5394 RVA: 0x0001683A File Offset: 0x00014A3A
		public void mainWindowStartResize()
		{
			this.moveMenuPopup();
		}

		// Token: 0x06001513 RID: 5395 RVA: 0x0015CEEC File Offset: 0x0015B0EC
		public void mainWindowResize()
		{
			this.m_expandedMainSize = this.parentMainWindow.getDXBasePanel().Size;
			this.m_expandedMainSize.Height = this.parentForm.ClientSize.Height - 120;
			this.m_expandedMainSize.Width = this.m_expandedMainSize.Width + this.parentMainWindow.getMainRightHandPanel().Size.Width;
			if (this.getTopLeftMenu().Height != 120)
			{
				this.parentMainWindow.getDXBasePanel().Size = new Size(this.parentMainWindow.getDXBasePanel().Width, this.parentForm.ClientSize.Height - 120 + 28);
			}
			else
			{
				this.parentMainWindow.getDXBasePanel().Size = new Size(this.parentMainWindow.getDXBasePanel().Width, this.parentForm.ClientSize.Height - 120);
			}
			if (this.parentMainWindow.isFullMainArea())
			{
				Size expandedMainSize = this.m_expandedMainSize;
				if (this.getTopLeftMenu().Height != 120)
				{
					expandedMainSize.Height += 28;
				}
				this.mainWindowPanel.Size = expandedMainSize;
			}
			else
			{
				this.mainWindowPanel.Size = this.parentMainWindow.getDXBasePanel().Size;
			}
			this.parentMainWindow.getMainRightHandPanel().Size = new Size(this.parentMainWindow.getMainRightHandPanel().Width, this.parentMainWindow.getDXBasePanel().Height);
			this.villageReportBackgroundPanel.screenResize();
			this.mailScreenManager.screenResize();
			this.chatScreenManager.screenResize();
			this.movePlayCardsWindow();
			this.moveLogoutWindow();
			this.moveScoutPopupWindow();
			this.moveBuyVillagePopupWindow();
			this.moveReportCaptureWindow();
			this.moveNewQuestRewardPopup();
			this.moveGreyOutWindow();
			this.moveMenuPopup();
			this.moveTutorialWindow();
			this.moveTutorialArrowWindow();
			this.moveFreeCardsPopup();
			this.moveWheelPopup();
			this.moveWheelSelectPopup();
			this.moveAdvancedCastleOptionsPopup();
			if (this.mapFilterSelectPanel.isVisible())
			{
				this.showMapFilterSelectPanel(true, true, true, false);
			}
		}

		// Token: 0x06001514 RID: 5396 RVA: 0x00016842 File Offset: 0x00014A42
		public Size getMainWindowSize()
		{
			return this.mainWindowPanel.Size;
		}

		// Token: 0x06001515 RID: 5397 RVA: 0x0001684F File Offset: 0x00014A4F
		public void reportTabSetup()
		{
			RemoteServices.Instance.getReportFolders();
		}

		// Token: 0x06001516 RID: 5398 RVA: 0x0001685B File Offset: 0x00014A5B
		public void initReportTab()
		{
			this.getTopRightMenu().showVillageTab(false);
			this.getTopRightMenu().showFactionTabBar(false);
			this.switchReportTabs(0);
		}

		// Token: 0x06001517 RID: 5399 RVA: 0x0001687C File Offset: 0x00014A7C
		public void switchReportTabs(int tabID)
		{
			this.mainWindowPanel.Controls.Clear();
			if (tabID != 0)
			{
				int num = tabID - 1;
				return;
			}
			this.initReportsReports();
		}

		// Token: 0x06001518 RID: 5400 RVA: 0x0001689E File Offset: 0x00014A9E
		public void initReportsReports()
		{
			this.setVillageTabSubMode(21, true);
		}

		// Token: 0x06001519 RID: 5401 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void updateReports()
		{
		}

		// Token: 0x0600151A RID: 5402 RVA: 0x000168A9 File Offset: 0x00014AA9
		public void moveReports(string folderName)
		{
			this.villageReportBackgroundPanel.moveReports(folderName);
		}

		// Token: 0x0600151B RID: 5403 RVA: 0x000168B7 File Offset: 0x00014AB7
		public void deleteReportFolder(string folderName, int mode)
		{
			this.villageReportBackgroundPanel.deleteReportFolder(folderName, mode);
		}

		// Token: 0x0600151C RID: 5404 RVA: 0x000168C6 File Offset: 0x00014AC6
		public object getReportData(long reportID)
		{
			return this.villageReportBackgroundPanel.getReportData(reportID);
		}

		// Token: 0x0600151D RID: 5405 RVA: 0x000168D4 File Offset: 0x00014AD4
		public void setReportData(object reportData, long reportID)
		{
			this.villageReportBackgroundPanel.setReportData(reportData, reportID);
		}

		// Token: 0x0600151E RID: 5406 RVA: 0x000168E3 File Offset: 0x00014AE3
		public void setReportAlreadyRead(long reportID)
		{
			this.villageReportBackgroundPanel.setReportAlreadyRead(reportID);
		}

		// Token: 0x0600151F RID: 5407 RVA: 0x000168F1 File Offset: 0x00014AF1
		public void initReportsLeaderboard()
		{
			this.setVillageTabSubMode(20, true);
		}

		// Token: 0x06001520 RID: 5408 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void updateLeaderboard()
		{
		}

		// Token: 0x06001521 RID: 5409 RVA: 0x000168FC File Offset: 0x00014AFC
		public void leaderboardSearchComplete(LeaderBoardSearchResults results)
		{
			this.villageReportBackgroundPanel.leaderboardSearchComplete(results);
		}

		// Token: 0x06001522 RID: 5410 RVA: 0x0001690A File Offset: 0x00014B0A
		public void initContestsLeaderboard()
		{
			this.setVillageTabSubMode(30, true);
		}

		// Token: 0x06001523 RID: 5411 RVA: 0x00016915 File Offset: 0x00014B15
		public void initContestHistory()
		{
			this.setVillageTabSubMode(31, true);
		}

		// Token: 0x06001524 RID: 5412 RVA: 0x0015D104 File Offset: 0x0015B304
		public void initResearchTab()
		{
			this.getTopRightMenu().showVillageTab(false);
			this.getTopRightMenu().showFactionTabBar(false);
			this.researchPanel.initProperties(true, "Research", this.mainWindowPanel);
			this.researchPanel.Size = this.mainWindowPanel.Size;
			this.researchPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.researchPanel.updateBasedOnResearchData(GameEngine.Instance.World.UserResearchData, true);
			this.researchPanel.display(this.mainWindowPanel, 0, 0);
		}

		// Token: 0x06001525 RID: 5413 RVA: 0x00016920 File Offset: 0x00014B20
		public void updateResearch(bool fullTick)
		{
			this.researchPanel.update(fullTick);
		}

		// Token: 0x06001526 RID: 5414 RVA: 0x0001692E File Offset: 0x00014B2E
		public void researchDataChanged(ResearchData data)
		{
			if (data != null && this.researchPanel.isVisible())
			{
				this.researchPanel.updateBasedOnResearchData(data, true);
			}
		}

		// Token: 0x06001527 RID: 5415 RVA: 0x0001694D File Offset: 0x00014B4D
		public bool isResearchOnEducationTab()
		{
			return this.researchPanel.isResearchOnEducationTab();
		}

		// Token: 0x06001528 RID: 5416 RVA: 0x0001695A File Offset: 0x00014B5A
		public void initRankingsTab()
		{
			InterfaceMgr.Instance.setVillageTabSubMode(19, true);
			RankingsPanel.setRanking(GameEngine.Instance.World.getRank(), GameEngine.Instance.World.getRankSubLevel());
			this.updateVillageReports();
		}

		// Token: 0x06001529 RID: 5417 RVA: 0x00016993 File Offset: 0x00014B93
		public void initGloryTab()
		{
			this.getTopRightMenu().showVillageTab(false);
			this.getTopRightMenu().showFactionTabBar(true);
			InterfaceMgr.Instance.setVillageTabSubMode(22);
		}

		// Token: 0x0600152A RID: 5418 RVA: 0x000169B9 File Offset: 0x00014BB9
		public void inviteToFaction(string username)
		{
			GameEngine.Instance.setNextFactionPage(46);
			this.getMainTabBar().changeTab(8);
			InterfaceMgr.Instance.setVillageTabSubMode(46, false);
			this.villageReportBackgroundPanel.inviteToFaction(username);
		}

		// Token: 0x0600152B RID: 5419 RVA: 0x000169EC File Offset: 0x00014BEC
		public void downCurrentFactionInfo()
		{
			CustomSelfDrawPanel.FactionPanelSideBar.downloadCurrentFactionInfo();
		}

		// Token: 0x0600152C RID: 5420 RVA: 0x000169F3 File Offset: 0x00014BF3
		public void initAllArmiesTab()
		{
			this.setVillageTabSubMode(23, true);
		}

		// Token: 0x0600152D RID: 5421 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void updateAllArmiesPanel()
		{
		}

		// Token: 0x0600152E RID: 5422 RVA: 0x000169FE File Offset: 0x00014BFE
		public void initQuestsTab()
		{
			this.setVillageTabSubMode(26, true);
			if (!GameEngine.Instance.World.TutorialIsAdvancing() && GameEngine.Instance.World.getTutorialStage() == 101)
			{
				GameEngine.Instance.World.advanceTutorialOLD();
			}
		}

		// Token: 0x0600152F RID: 5423 RVA: 0x00016A3C File Offset: 0x00014C3C
		public void reloadQuestPanel()
		{
			this.villageReportBackgroundPanel.questPanelInit();
		}

		// Token: 0x06001530 RID: 5424 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void updateQuestsPanel()
		{
		}

		// Token: 0x06001531 RID: 5425 RVA: 0x00016A49 File Offset: 0x00014C49
		public void completeQuest(int quest)
		{
			this.villageReportBackgroundPanel.questPanelCompleteQuest(quest);
		}

		// Token: 0x06001532 RID: 5426 RVA: 0x00016A57 File Offset: 0x00014C57
		public bool isMailDocked()
		{
			return this.mailScreenManager.isDocked();
		}

		// Token: 0x06001533 RID: 5427 RVA: 0x00016A64 File Offset: 0x00014C64
		public bool mailScreenNeedsOpening()
		{
			return this.mailScreenManager.isDocked() || !this.mailScreenManager.isMailScreenVisible();
		}

		// Token: 0x06001534 RID: 5428 RVA: 0x0015D194 File Offset: 0x0015B394
		public void initMailSubTab(int mode)
		{
			if (this.mailScreenManager.isDocked())
			{
				this.getTopRightMenu().showVillageTab(false);
				this.getTopRightMenu().showFactionTabBar(false);
				this.mailScreenManager.Size = this.mainWindowPanel.Size;
				this.mailScreenManager.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
				this.mailScreenManager.initProperties(true, "Main", this.mainWindowPanel);
				this.mailScreenManager.open(false, false);
				this.mailScreenManager.display(this.mainWindowPanel, 0, 0);
			}
			else
			{
				this.mailScreenManager.open(false, false);
			}
			if (mode == 1)
			{
				this.mailScreenManager.startWithNewMessage(-1, "");
			}
		}

		// Token: 0x06001535 RID: 5429 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void refreshForMail(bool success)
		{
		}

		// Token: 0x06001536 RID: 5430 RVA: 0x00016A83 File Offset: 0x00014C83
		public void mailTo(int userID, string userName)
		{
			this.mailScreenManager.mailTo(userID, userName);
		}

		// Token: 0x06001537 RID: 5431 RVA: 0x00016A92 File Offset: 0x00014C92
		public void sendProclamation(int mailType, int areaID)
		{
			this.mailScreenManager.sendProclamation(mailType, areaID);
		}

		// Token: 0x06001538 RID: 5432 RVA: 0x00016AA1 File Offset: 0x00014CA1
		public void mailTo(int userID, string[] userNames)
		{
			this.mailScreenManager.mailTo(userID, userNames);
		}

		// Token: 0x06001539 RID: 5433 RVA: 0x00016AB0 File Offset: 0x00014CB0
		public void mailUpdate()
		{
			this.mailScreenManager.mailUpdate();
		}

		// Token: 0x0600153A RID: 5434 RVA: 0x00016ABD File Offset: 0x00014CBD
		public void clearStoredMail()
		{
			this.mailScreenManager.clearStoredMail();
		}

		// Token: 0x0600153B RID: 5435 RVA: 0x00016ACA File Offset: 0x00014CCA
		public void mailPopupNewMail()
		{
			this.mailScreenManager.mailPopupNewMail();
		}

		// Token: 0x0600153C RID: 5436 RVA: 0x00016AD7 File Offset: 0x00014CD7
		public void mailScreenRePop()
		{
			this.mailScreenManager.open(false, false);
		}

		// Token: 0x0600153D RID: 5437 RVA: 0x00016AE6 File Offset: 0x00014CE6
		public bool isChatDocked()
		{
			return this.chatScreenManager.isDocked();
		}

		// Token: 0x0600153E RID: 5438 RVA: 0x0015D244 File Offset: 0x0015B444
		public void initChatPanel(int startingArea, int startAreaID)
		{
			if (this.chatScreenManager.isDocked())
			{
				this.getTopRightMenu().showVillageTab(false);
				this.getTopRightMenu().showFactionTabBar(false);
				this.chatScreenManager.Size = this.mainWindowPanel.Size;
				this.chatScreenManager.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
				this.chatScreenManager.initProperties(true, "Main", this.mainWindowPanel);
				this.chatScreenManager.open(false, false, startingArea, startAreaID);
				this.chatScreenManager.display(this.mainWindowPanel, 0, 0);
				return;
			}
			this.chatScreenManager.open(false, false, startingArea, startAreaID);
		}

		// Token: 0x0600153F RID: 5439 RVA: 0x00016AF3 File Offset: 0x00014CF3
		public void chatUpdate()
		{
			this.chatScreenManager.chatUpdate();
		}

		// Token: 0x06001540 RID: 5440 RVA: 0x00016B00 File Offset: 0x00014D00
		public void chatLogin()
		{
			this.chatScreenManager.login();
		}

		// Token: 0x06001541 RID: 5441 RVA: 0x00016B0D File Offset: 0x00014D0D
		public void chatLogout()
		{
			this.chatScreenManager.logout();
		}

		// Token: 0x06001542 RID: 5442 RVA: 0x00016B1A File Offset: 0x00014D1A
		public void chatClose()
		{
			this.chatScreenManager.close(true, true);
			this.chatScreenManager.logout();
		}

		// Token: 0x06001543 RID: 5443 RVA: 0x00016B34 File Offset: 0x00014D34
		public void chatSetBan(bool banned)
		{
			this.chatScreenManager.setChatBan(banned);
		}

		// Token: 0x06001544 RID: 5444 RVA: 0x00016B42 File Offset: 0x00014D42
		public void showMapFilterSelectPanel(bool show, bool showAsOpen)
		{
			this.showMapFilterSelectPanel(show, showAsOpen, false, false);
		}

		// Token: 0x06001545 RID: 5445 RVA: 0x0015D2E4 File Offset: 0x0015B4E4
		public void showMapFilterSelectPanel(bool show, bool showAsOpen, bool force, bool forceDoubleHeight)
		{
			if (!show)
			{
				this.mapFilterSelectPanel.closeControl(true);
				return;
			}
			int height = this.ParentForm.Height;
			bool flag = false;
			if (height >= 750 || forceDoubleHeight)
			{
				flag = true;
			}
			if (!this.mapFilterSelectPanel.isVisible())
			{
				this.mapFilterSelectPanel.initProperties(true, "", null);
				this.mapFilterSelectPanel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
				if (flag)
				{
					this.mapFilterSelectPanel.display(this.parentMainWindow.getMainRightHandPanel(), 11, this.parentMainWindow.getMainRightHandPanel().Height - 60);
				}
				else
				{
					this.mapFilterSelectPanel.display(this.parentMainWindow.getMainRightHandPanel(), 11, this.parentMainWindow.getMainRightHandPanel().Height - 30);
				}
			}
			else if (force)
			{
				if (flag)
				{
					if (this.mapFilterSelectPanel.Size.Height < 40)
					{
						this.mapFilterSelectPanel.setPosition(11, this.parentMainWindow.getMainRightHandPanel().Height - 60);
					}
				}
				else if (this.mapFilterSelectPanel.Size.Height > 40)
				{
					this.mapFilterSelectPanel.setPosition(11, this.parentMainWindow.getMainRightHandPanel().Height - 30);
				}
			}
			this.mapFilterSelectPanel.init(showAsOpen, flag);
		}

		// Token: 0x06001546 RID: 5446 RVA: 0x00016B4E File Offset: 0x00014D4E
		public void showMapFilterPanel()
		{
			this.clearControls();
			this.mapFilterPanel.initProperties(true, "", null);
			this.mapFilterPanel.display(this.parentMainWindow.getMainRightHandPanel(), 0, 0);
			this.mapFilterPanel.init();
		}

		// Token: 0x06001547 RID: 5447 RVA: 0x00016B8B File Offset: 0x00014D8B
		public void closeFilterPanel()
		{
			this.mapFilterPanel.closeControl(true);
			this.showMapFilterSelectPanel(true, true);
		}

		// Token: 0x06001548 RID: 5448 RVA: 0x0015D430 File Offset: 0x0015B630
		public int getSelectedMenuVillage()
		{
			if (this.m_forcedMenuVillage >= 0 && RemoteServices.Instance.Admin)
			{
				return this.m_forcedMenuVillage;
			}
			if (this.m_selectedMenuVillage >= 0 && (GameEngine.Instance.World.isUserVillage(this.m_selectedMenuVillage) || GameEngine.Instance.World.isUserRelatedVillage(this.m_selectedMenuVillage)))
			{
				return this.m_selectedMenuVillage;
			}
			int nextUserVillage = GameEngine.Instance.World.getNextUserVillage(-1, 1);
			this.setVillageNameBar(nextUserVillage);
			GameEngine.Instance.MovedFromVillageID = nextUserVillage;
			return nextUserVillage;
		}

		// Token: 0x06001549 RID: 5449 RVA: 0x0015D4BC File Offset: 0x0015B6BC
		public void setVillageNameBar(int villageID)
		{
			if (GameEngine.Instance.World.isUserVillage(villageID) || GameEngine.Instance.World.isUserRelatedVillage(villageID))
			{
				this.m_ownSelectedVillage = villageID;
			}
			GameEngine.Instance.World.createTributeLinesList(villageID);
			this.m_selectedMenuVillage = villageID;
			this.parentMainWindow.getTopRightMenu().setSelectedVillageName(GameEngine.Instance.World.getVillageName(villageID), this.isSelectedVillageACapital(villageID));
		}

		// Token: 0x0600154A RID: 5450 RVA: 0x00016BA1 File Offset: 0x00014DA1
		public void centerOnVillage()
		{
			if (this.m_selectedMenuVillage >= 0)
			{
				this.selectUserVillage(this.m_selectedMenuVillage, true);
			}
		}

		// Token: 0x0600154B RID: 5451 RVA: 0x0015D534 File Offset: 0x0015B734
		public void selectedVillageNameLeft()
		{
			int nextUserVillage = GameEngine.Instance.World.getNextUserVillage(this.m_selectedMenuVillage, -1);
			if (nextUserVillage >= 0)
			{
				this.selectUserVillage(nextUserVillage, true);
			}
		}

		// Token: 0x0600154C RID: 5452 RVA: 0x0015D564 File Offset: 0x0015B764
		public void selectedVillageNameRight()
		{
			int nextUserVillage = GameEngine.Instance.World.getNextUserVillage(this.m_selectedMenuVillage, 1);
			if (nextUserVillage >= 0)
			{
				this.selectUserVillage(nextUserVillage, true);
			}
		}

		// Token: 0x0600154D RID: 5453 RVA: 0x0015D594 File Offset: 0x0015B794
		public void selectVillageParent()
		{
			int villageParent = GameEngine.Instance.World.getVillageParent(this.m_selectedMenuVillage);
			if (villageParent >= 0)
			{
				this.selectUserVillage(villageParent, true);
			}
		}

		// Token: 0x0600154E RID: 5454 RVA: 0x0015D5C4 File Offset: 0x0015B7C4
		public void selectVillageChildBestGuess()
		{
			int playerChildVillageFromCapital = GameEngine.Instance.World.getPlayerChildVillageFromCapital(this.m_selectedMenuVillage);
			if (playerChildVillageFromCapital >= 0)
			{
				this.selectUserVillage(playerChildVillageFromCapital, true);
			}
		}

		// Token: 0x0600154F RID: 5455 RVA: 0x0015D5F4 File Offset: 0x0015B7F4
		public void validateUserVillage()
		{
			if (this.m_selectedMenuVillage >= 0 && !GameEngine.Instance.World.isUserVillage(this.m_selectedMenuVillage) && !GameEngine.Instance.World.isUserRelatedVillage(this.m_selectedMenuVillage))
			{
				this.getMainTabBar().changeTab(0);
				this.setupVillageName();
			}
		}

		// Token: 0x06001550 RID: 5456 RVA: 0x0015D64C File Offset: 0x0015B84C
		public void setupVillageName()
		{
			this.m_selectedMenuVillage = -1;
			int num = -1;
			do
			{
				num = GameEngine.Instance.World.getNextUserVillage(num, 1);
			}
			while (num >= 0 && GameEngine.Instance.World.isCapital(num));
			if (num >= 0)
			{
				this.setVillageNameBar(num);
				this.selectUserVillage(num, false);
			}
		}

		// Token: 0x06001551 RID: 5457 RVA: 0x0015D6A0 File Offset: 0x0015B8A0
		public void switchToSelectedVillage()
		{
			int selectedVillage = this.SelectedVillage;
			if (selectedVillage >= 0)
			{
				this.selectUserVillage(selectedVillage, true);
				GameEngine.Instance.downloadCurrentVillage();
				this.SelectedVillage = -1;
			}
		}

		// Token: 0x06001552 RID: 5458 RVA: 0x00016BB9 File Offset: 0x00014DB9
		public void selectCurrentUserVillage()
		{
			if (this.m_selectedMenuVillage >= 0 && GameEngine.Instance.World.isUserVillage(this.m_selectedMenuVillage))
			{
				this.selectUserVillage(this.m_selectedMenuVillage, false);
			}
		}

		// Token: 0x06001553 RID: 5459 RVA: 0x0015D6D4 File Offset: 0x0015B8D4
		public void selectUserVillage(int villageID, bool zoomIn)
		{
			int ownSelectedVillage = this.OwnSelectedVillage;
			GameEngine.Instance.MovedFromVillageID = villageID;
			if (GameEngine.Instance.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_WORLD)
			{
				if (zoomIn)
				{
					Point villageLocation = GameEngine.Instance.World.getVillageLocation(villageID);
					GameEngine.Instance.World.startMultiStageZoom(10000.0, (double)villageLocation.X, (double)villageLocation.Y);
				}
				this.displaySelectedVillagePanel(villageID, false, true, true, false);
			}
			else
			{
				this.setVillageNameBar(villageID);
				if (GameEngine.Instance.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_VILLAGE)
				{
					if (this.wasShowingVassalSendScreen())
					{
						InterfaceMgr.Instance.setVillageTabSubMode(8);
					}
					GameEngine.Instance.downloadCurrentVillage();
				}
				else if (GameEngine.Instance.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_CASTLE)
				{
					if (GameEngine.Instance.GameDisplayModeSubMode == GameEngine.GameDisplaySubModes.SUBMODE_CASTLE_ATTACKER_SETUP || GameEngine.Instance.GameDisplayModeSubMode == GameEngine.GameDisplaySubModes.SUBMODE_PREVIEW)
					{
						InterfaceMgr.Instance.getMainTabBar().changeTab(9);
						InterfaceMgr.Instance.getMainTabBar().changeTab(0);
					}
					else
					{
						GameEngine.Instance.downloadCurrentVillage();
					}
				}
			}
			if (this.getMainTabBar().getCurrentTab() == 1)
			{
				if (GameEngine.Instance.World.isCapital(villageID))
				{
					this.getMainTabBar().changeTabGfxOnly(2);
					GameEngine.Instance.externalMainTabChange(2);
					return;
				}
			}
			else if (this.getMainTabBar().getCurrentTab() == 2 && !GameEngine.Instance.World.isCapital(villageID))
			{
				this.getMainTabBar().changeTabGfxOnly(1);
				GameEngine.Instance.externalMainTabChange(1);
			}
		}

		// Token: 0x06001554 RID: 5460 RVA: 0x00016BE8 File Offset: 0x00014DE8
		public bool isPlayerElectedLeaderOfSelectedVillage()
		{
			return GameEngine.Instance.World.isUserVillage(this.OwnSelectedVillage);
		}

		// Token: 0x06001555 RID: 5461 RVA: 0x00016BFF File Offset: 0x00014DFF
		public bool isSelectedVillageACapital()
		{
			return this.m_selectedMenuVillage >= 0 && GameEngine.Instance.World.isCapital(this.m_selectedMenuVillage);
		}

		// Token: 0x06001556 RID: 5462 RVA: 0x00016C24 File Offset: 0x00014E24
		public bool isSelectedVillageAParishCapital()
		{
			return this.m_selectedMenuVillage >= 0 && GameEngine.Instance.World.isRegionCapital(this.m_selectedMenuVillage);
		}

		// Token: 0x06001557 RID: 5463 RVA: 0x00016C49 File Offset: 0x00014E49
		public bool isSelectedVillageACountyCapital()
		{
			return this.m_selectedMenuVillage >= 0 && GameEngine.Instance.World.isCountyCapital(this.m_selectedMenuVillage);
		}

		// Token: 0x06001558 RID: 5464 RVA: 0x00016C6E File Offset: 0x00014E6E
		public bool isSelectedVillageAProvinceCapital()
		{
			return this.m_selectedMenuVillage >= 0 && GameEngine.Instance.World.isProvinceCapital(this.m_selectedMenuVillage);
		}

		// Token: 0x06001559 RID: 5465 RVA: 0x00016C93 File Offset: 0x00014E93
		public bool isSelectedVillageACountryCapital()
		{
			return this.m_selectedMenuVillage >= 0 && GameEngine.Instance.World.isCountryCapital(this.m_selectedMenuVillage);
		}

		// Token: 0x0600155A RID: 5466 RVA: 0x00016CB8 File Offset: 0x00014EB8
		public bool isSelectedVillageACapital(int villageID)
		{
			return villageID >= 0 && GameEngine.Instance.World.isCapital(villageID);
		}

		// Token: 0x0600155B RID: 5467 RVA: 0x00016CD3 File Offset: 0x00014ED3
		public void setCardData(CardData cardData)
		{
			this.parentMainWindow.getTopLeftMenu().setCards(cardData);
		}

		// Token: 0x0600155C RID: 5468 RVA: 0x00016CE6 File Offset: 0x00014EE6
		public void setGold(double newGold)
		{
			this.parentMainWindow.getTopLeftMenu().setGold(newGold);
		}

		// Token: 0x0600155D RID: 5469 RVA: 0x00016CF9 File Offset: 0x00014EF9
		public void setHonour(double newHonour, int rank)
		{
			this.parentMainWindow.getTopLeftMenu().setHonour(newHonour, rank);
		}

		// Token: 0x0600155E RID: 5470 RVA: 0x00016D0D File Offset: 0x00014F0D
		public void setFaithPoints(double newFaithPoints)
		{
			this.parentMainWindow.getTopLeftMenu().SetFaithPoints(newFaithPoints);
		}

		// Token: 0x0600155F RID: 5471 RVA: 0x00016D20 File Offset: 0x00014F20
		public void setPoints(int points)
		{
			this.parentMainWindow.getTopLeftMenu().setPoints(points);
		}

		// Token: 0x06001560 RID: 5472 RVA: 0x00016D33 File Offset: 0x00014F33
		public void setServerTime(DateTime serverTime, int gameDay)
		{
			this.parentMainWindow.getMainMenuBar().setServerTime(serverTime, gameDay);
		}

		// Token: 0x06001561 RID: 5473 RVA: 0x00016D47 File Offset: 0x00014F47
		public void setConnectionLight(bool loading)
		{
			if (this.getMainMenuBar() != null)
			{
				this.getMainMenuBar().setLoadingLight(loading);
			}
		}

		// Token: 0x06001562 RID: 5474 RVA: 0x00009262 File Offset: 0x00007462
		public bool isGameMinimised()
		{
			return false;
		}

		// Token: 0x06001563 RID: 5475 RVA: 0x00016D5D File Offset: 0x00014F5D
		public int getGameActivityMode()
		{
			this.lastTimeChangedMode = 0;
			return 0;
		}

		// Token: 0x06001564 RID: 5476 RVA: 0x0015D844 File Offset: 0x0015BA44
		public string getPlagueText(int plagueLevel)
		{
			if (plagueLevel >= 181)
			{
				return SK.Text("InterfaceMgr_Disease_10", "The Black Death");
			}
			if (plagueLevel >= 161)
			{
				return SK.Text("InterfaceMgr_Disease_9", "Plague Symptoms");
			}
			if (plagueLevel >= 141)
			{
				return SK.Text("InterfaceMgr_Disease_8", "Mass Delirium");
			}
			if (plagueLevel >= 121)
			{
				return SK.Text("InterfaceMgr_Disease_7", "Raging Fevers");
			}
			if (plagueLevel >= 101)
			{
				return SK.Text("InterfaceMgr_Disease_6", "Flu Epidemic");
			}
			if (plagueLevel >= 81)
			{
				return SK.Text("InterfaceMgr_Disease_5", "Flu Symptoms");
			}
			if (plagueLevel >= 61)
			{
				return SK.Text("InterfaceMgr_Disease_4", "Bronchitis");
			}
			if (plagueLevel >= 41)
			{
				return SK.Text("InterfaceMgr_Disease_3", "Coughing");
			}
			if (plagueLevel >= 21)
			{
				return SK.Text("InterfaceMgr_Disease_2", "Colds");
			}
			return SK.Text("InterfaceMgr_Disease_1", "Slight Sniffles");
		}

		// Token: 0x06001565 RID: 5477 RVA: 0x0015D928 File Offset: 0x0015BB28
		public SendArmyWindow openLaunchAttackPopup()
		{
			this.openGreyOutWindow(true);
			this.closePopupWindow(this.m_launchAttackPopup);
			this.m_launchAttackPopup = new SendArmyWindow();
			this.positionWindow(this.m_launchAttackPopup, true, false);
			this.m_launchAttackPopup.Show(this.getGreyOutWindow());
			if (InterfaceMgr.Instance.isTutorialWindowOpen())
			{
				GameEngine.Instance.World.forceTutorialToBeShown();
			}
			GameEngine.Instance.DisableMouseClicks();
			return this.m_launchAttackPopup;
		}

		// Token: 0x06001566 RID: 5478 RVA: 0x0015D9A0 File Offset: 0x0015BBA0
		public void closeLaunchAttackPopup()
		{
			if (!this.launchAttackPopupClosing)
			{
				this.launchAttackPopupClosing = true;
				if (this.isPopupWindowOpenAndClose(this.m_launchAttackPopup))
				{
					this.closeGreyOut();
				}
				this.m_launchAttackPopup = null;
				this.launchAttackPopupClosing = false;
				if (this.parentForm != null)
				{
					this.parentForm.TopMost = true;
					this.parentForm.Focus();
					this.parentForm.BringToFront();
					this.parentForm.Focus();
					this.parentForm.TopMost = false;
				}
			}
		}

		// Token: 0x06001567 RID: 5479 RVA: 0x0015DA24 File Offset: 0x0015BC24
		public CreatePopupWindow openCreatePopupWindow()
		{
			this.openGreyOutWindowLogin(true);
			this.closePopupWindow(this.m_createPopupWindow);
			this.m_createPopupWindow = new CreatePopupWindow();
			this.positionWindow(this.m_createPopupWindow, true, false);
			this.m_createPopupWindow.init();
			this.m_createPopupWindow.Show(this.getGreyOutWindow());
			GameEngine.Instance.DisableMouseClicks();
			this.m_createPopupWindow.Location = new Point(Program.profileLogin.Location.X + (Program.profileLogin.Width - this.m_createPopupWindow.Width) / 2, Program.profileLogin.Location.Y + (Program.profileLogin.Height - this.m_createPopupWindow.Height) / 2);
			Program.profileLogin.TopMost = false;
			this.m_greyOutWindow.BringToFront();
			this.m_createPopupWindow.BringToFront();
			this.m_createPopupWindow.TopMost = true;
			this.m_createPopupWindow.Focus();
			this.m_createPopupWindow.TopMost = false;
			return this.m_createPopupWindow;
		}

		// Token: 0x06001568 RID: 5480 RVA: 0x0015DB38 File Offset: 0x0015BD38
		public void moveCreatePopupWindow()
		{
			Form createPopupWindow = this.m_createPopupWindow;
			if (createPopupWindow != null && createPopupWindow.Created)
			{
				this.m_createPopupWindow.Location = new Point(Program.profileLogin.Location.X + (Program.profileLogin.Width - this.m_createPopupWindow.Width) / 2, Program.profileLogin.Location.Y + (Program.profileLogin.Height - this.m_createPopupWindow.Height) / 2);
			}
		}

		// Token: 0x06001569 RID: 5481 RVA: 0x0015DBC0 File Offset: 0x0015BDC0
		public void closeCreatePopupWindow()
		{
			if (!this.createPopupWindowClosing)
			{
				this.createPopupWindowClosing = true;
				if (this.isPopupWindowOpenAndClose(this.m_createPopupWindow))
				{
					GameEngine.Instance.EnableMouseClicks();
					this.closeGreyOut();
					this.showDXCardBar(9);
					InterfaceMgr.Instance.closeParishPanel();
				}
				this.m_createPopupWindow = null;
				this.createPopupWindowClosing = false;
				Program.profileLogin.TopMost = true;
				Program.profileLogin.BringToFront();
				Program.profileLogin.TopMost = false;
			}
		}

		// Token: 0x0600156A RID: 5482 RVA: 0x00016D67 File Offset: 0x00014F67
		public CreatePopupWindow getCreatePopupWindow()
		{
			return this.m_createPopupWindow;
		}

		// Token: 0x0600156B RID: 5483 RVA: 0x00016D6F File Offset: 0x00014F6F
		public bool isCreatePopup()
		{
			return this.isPopupWindowOpen(this.m_createPopupWindow);
		}

		// Token: 0x0600156C RID: 5484 RVA: 0x0015DC3C File Offset: 0x0015BE3C
		public WorldSelectPopupWindow openWorldSelectPopupWindow()
		{
			this.openGreyOutWindowLogin(true);
			this.closePopupWindow(this.m_worldSelectPopupWindow);
			this.m_worldSelectPopupWindow = new WorldSelectPopupWindow();
			this.positionWindow(this.m_worldSelectPopupWindow, true, false);
			this.m_worldSelectPopupWindow.init(0, false);
			this.m_worldSelectPopupWindow.Show(this.getGreyOutWindow());
			GameEngine.Instance.DisableMouseClicks();
			this.m_worldSelectPopupWindow.Location = new Point(Program.profileLogin.Location.X + (Program.profileLogin.Width - this.m_worldSelectPopupWindow.Width) / 2, Program.profileLogin.Location.Y + (Program.profileLogin.Height - this.m_worldSelectPopupWindow.Height) / 2 + 10);
			Program.profileLogin.TopMost = false;
			this.m_greyOutWindow.BringToFront();
			this.m_worldSelectPopupWindow.BringToFront();
			this.m_worldSelectPopupWindow.TopMost = true;
			this.m_worldSelectPopupWindow.Focus();
			this.m_worldSelectPopupWindow.TopMost = false;
			return this.m_worldSelectPopupWindow;
		}

		// Token: 0x0600156D RID: 5485 RVA: 0x0015DD54 File Offset: 0x0015BF54
		public void moveWorldSelectPopupWindow()
		{
			Form worldSelectPopupWindow = this.m_worldSelectPopupWindow;
			if (worldSelectPopupWindow != null && worldSelectPopupWindow.Created)
			{
				this.m_worldSelectPopupWindow.Location = new Point(Program.profileLogin.Location.X + (Program.profileLogin.Width - this.m_worldSelectPopupWindow.Width) / 2, Program.profileLogin.Location.Y + (Program.profileLogin.Height - this.m_worldSelectPopupWindow.Height) / 2 + 10);
			}
		}

		// Token: 0x0600156E RID: 5486 RVA: 0x0015DDDC File Offset: 0x0015BFDC
		public void closeWorldSelectPopupWindow()
		{
			if (!this.worldSelectPopupWindowClosing)
			{
				this.worldSelectPopupWindowClosing = true;
				if (this.isPopupWindowOpenAndClose(this.m_worldSelectPopupWindow))
				{
					GameEngine.Instance.EnableMouseClicks();
					this.closeGreyOut();
					this.showDXCardBar(9);
					InterfaceMgr.Instance.closeParishPanel();
				}
				this.m_worldSelectPopupWindow = null;
				this.worldSelectPopupWindowClosing = false;
				Program.profileLogin.TopMost = true;
				Program.profileLogin.BringToFront();
				Program.profileLogin.TopMost = false;
			}
		}

		// Token: 0x0600156F RID: 5487 RVA: 0x00016D7D File Offset: 0x00014F7D
		public WorldSelectPopupWindow getWorldSelectPopupWindow()
		{
			return this.m_worldSelectPopupWindow;
		}

		// Token: 0x06001570 RID: 5488 RVA: 0x00016D85 File Offset: 0x00014F85
		public bool isWorldSelectPopup()
		{
			return this.isPopupWindowOpen(this.m_worldSelectPopupWindow);
		}

		// Token: 0x06001571 RID: 5489 RVA: 0x0015DE58 File Offset: 0x0015C058
		public BPPopupWindow openBPPopupWindow(ProfileLoginWindow parentForm)
		{
			this.openGreyOutWindowLogin(true);
			this.closePopupWindow(this.m_BPPopupWindow);
			this.m_BPPopupWindow = new BPPopupWindow();
			this.positionWindow(this.m_BPPopupWindow, true, false);
			this.m_BPPopupWindow.init(parentForm);
			this.m_BPPopupWindow.Show(this.getGreyOutWindow());
			GameEngine.Instance.DisableMouseClicks();
			this.m_BPPopupWindow.Location = new Point(Program.profileLogin.Location.X + (Program.profileLogin.Width - this.m_BPPopupWindow.Width) / 2, Program.profileLogin.Location.Y + (Program.profileLogin.Height - this.m_BPPopupWindow.Height) / 2 + 10);
			Program.profileLogin.TopMost = false;
			this.m_greyOutWindow.BringToFront();
			this.m_BPPopupWindow.BringToFront();
			this.m_BPPopupWindow.TopMost = true;
			this.m_BPPopupWindow.Focus();
			this.m_BPPopupWindow.TopMost = false;
			return this.m_BPPopupWindow;
		}

		// Token: 0x06001572 RID: 5490 RVA: 0x0015DF70 File Offset: 0x0015C170
		public void moveBPPopupWindow()
		{
			Form bppopupWindow = this.m_BPPopupWindow;
			if (bppopupWindow != null && bppopupWindow.Created)
			{
				this.m_BPPopupWindow.Location = new Point(Program.profileLogin.Location.X + (Program.profileLogin.Width - this.m_BPPopupWindow.Width) / 2, Program.profileLogin.Location.Y + (Program.profileLogin.Height - this.m_BPPopupWindow.Height) / 2 + 10);
			}
		}

		// Token: 0x06001573 RID: 5491 RVA: 0x0015DFF8 File Offset: 0x0015C1F8
		public void closeBPPopupWindow()
		{
			if (!this.BPPopupWindowClosing)
			{
				this.BPPopupWindowClosing = true;
				if (this.isPopupWindowOpenAndClose(this.m_BPPopupWindow))
				{
					GameEngine.Instance.EnableMouseClicks();
					this.closeGreyOut();
					this.showDXCardBar(9);
					InterfaceMgr.Instance.closeParishPanel();
				}
				this.m_BPPopupWindow = null;
				this.BPPopupWindowClosing = false;
				Program.profileLogin.TopMost = true;
				Program.profileLogin.BringToFront();
				Program.profileLogin.TopMost = false;
			}
		}

		// Token: 0x06001574 RID: 5492 RVA: 0x00016D93 File Offset: 0x00014F93
		public BPPopupWindow getBPPopupWindow()
		{
			return this.m_BPPopupWindow;
		}

		// Token: 0x06001575 RID: 5493 RVA: 0x00016D9B File Offset: 0x00014F9B
		public bool isBPPopup()
		{
			return this.isPopupWindowOpen(this.m_BPPopupWindow);
		}

		// Token: 0x06001576 RID: 5494 RVA: 0x0015E074 File Offset: 0x0015C274
		public VacationCancelPopupWindow openVacationCancelPopupWindow(int secondsLeft, int secondsLeftToCancel, bool canCancel)
		{
			this.openGreyOutWindowLogin(true);
			this.closePopupWindow(this.m_VacationCancelPopupWindow);
			this.m_VacationCancelPopupWindow = new VacationCancelPopupWindow();
			this.positionWindow(this.m_VacationCancelPopupWindow, true, false);
			this.m_VacationCancelPopupWindow.init(secondsLeft, secondsLeftToCancel, canCancel);
			this.m_VacationCancelPopupWindow.Show(this.getGreyOutWindow());
			GameEngine.Instance.DisableMouseClicks();
			this.m_VacationCancelPopupWindow.Location = new Point(Program.profileLogin.Location.X + (Program.profileLogin.Width - this.m_VacationCancelPopupWindow.Width) / 2, Program.profileLogin.Location.Y + (Program.profileLogin.Height - this.m_VacationCancelPopupWindow.Height) / 2);
			Program.profileLogin.TopMost = false;
			this.m_greyOutWindow.BringToFront();
			this.m_VacationCancelPopupWindow.BringToFront();
			this.m_VacationCancelPopupWindow.TopMost = true;
			this.m_VacationCancelPopupWindow.Focus();
			this.m_VacationCancelPopupWindow.TopMost = false;
			return this.m_VacationCancelPopupWindow;
		}

		// Token: 0x06001577 RID: 5495 RVA: 0x0015E188 File Offset: 0x0015C388
		public void moveVacationCancelPopupWindow()
		{
			Form vacationCancelPopupWindow = this.m_VacationCancelPopupWindow;
			if (vacationCancelPopupWindow != null && vacationCancelPopupWindow.Created)
			{
				this.m_VacationCancelPopupWindow.Location = new Point(Program.profileLogin.Location.X + (Program.profileLogin.Width - this.m_VacationCancelPopupWindow.Width) / 2, Program.profileLogin.Location.Y + (Program.profileLogin.Height - this.m_VacationCancelPopupWindow.Height) / 2);
			}
		}

		// Token: 0x06001578 RID: 5496 RVA: 0x0015E210 File Offset: 0x0015C410
		public void closeVacationCancelPopupWindow()
		{
			if (!this.VacationCancelPopupWindowClosing)
			{
				this.VacationCancelPopupWindowClosing = true;
				if (this.isPopupWindowOpenAndClose(this.m_VacationCancelPopupWindow))
				{
					GameEngine.Instance.EnableMouseClicks();
					this.closeGreyOut();
					this.showDXCardBar(9);
					InterfaceMgr.Instance.closeParishPanel();
				}
				this.m_VacationCancelPopupWindow = null;
				this.VacationCancelPopupWindowClosing = false;
				Program.profileLogin.TopMost = true;
				Program.profileLogin.BringToFront();
				Program.profileLogin.TopMost = false;
			}
		}

		// Token: 0x06001579 RID: 5497 RVA: 0x00016DA9 File Offset: 0x00014FA9
		public VacationCancelPopupWindow getVacationCancelPopupWindow()
		{
			return this.m_VacationCancelPopupWindow;
		}

		// Token: 0x0600157A RID: 5498 RVA: 0x00016DB1 File Offset: 0x00014FB1
		public bool isVacationCancelPopupWindow()
		{
			return this.isPopupWindowOpen(this.m_VacationCancelPopupWindow);
		}

		// Token: 0x0600157B RID: 5499 RVA: 0x0015E28C File Offset: 0x0015C48C
		public PlayCardsWindow openPlayCardsWindow(int cardSection)
		{
			this.openGreyOutWindow(false);
			this.closePopupWindow(this.m_playCardsWindow);
			this.m_playCardsWindow = new PlayCardsWindow();
			this.positionWindow(this.m_playCardsWindow, false, false);
			this.m_playCardsWindow.init(cardSection, true);
			this.m_playCardsWindow.Show(this.getGreyOutWindow());
			if (InterfaceMgr.Instance.isTutorialWindowOpen())
			{
				GameEngine.Instance.World.forceTutorialToBeShown();
			}
			GameEngine.Instance.DisableMouseClicks();
			return this.m_playCardsWindow;
		}

		// Token: 0x0600157C RID: 5500 RVA: 0x0015E310 File Offset: 0x0015C510
		public PlayCardsWindow openPlayCardsWindowSearch(int cardSection, string searchText)
		{
			this.openGreyOutWindow(false);
			this.closePopupWindow(this.m_playCardsWindow);
			this.m_playCardsWindow = new PlayCardsWindow();
			this.positionWindow(this.m_playCardsWindow, false, false);
			this.m_playCardsWindow.init(cardSection, true);
			this.m_playCardsWindow.Show(this.getGreyOutWindow());
			this.m_playCardsWindow.tbSearchBox.Text = searchText;
			this.m_playCardsWindow.performSearch();
			if (InterfaceMgr.Instance.isTutorialWindowOpen())
			{
				GameEngine.Instance.World.forceTutorialToBeShown();
			}
			GameEngine.Instance.DisableMouseClicks();
			return this.m_playCardsWindow;
		}

		// Token: 0x0600157D RID: 5501 RVA: 0x00016DBF File Offset: 0x00014FBF
		public void movePlayCardsWindow()
		{
			this.positionWindow(this.m_playCardsWindow, false, true);
		}

		// Token: 0x0600157E RID: 5502 RVA: 0x0015E3B0 File Offset: 0x0015C5B0
		public void closePlayCardsWindow()
		{
			if (this.playCardsWindowClosing)
			{
				return;
			}
			this.playCardsWindowClosing = true;
			if (this.isPopupWindowOpenAndClose(this.m_playCardsWindow))
			{
				GameEngine.Instance.EnableMouseClicks();
				if (this.getScoutPopupWindow() == null && this.getSendMonkWindow() == null && this.getBuyVillageWindow() == null && this.m_launchAttackPopup == null)
				{
					this.closeGreyOut();
				}
			}
			this.m_playCardsWindow = null;
			this.playCardsWindowClosing = false;
		}

		// Token: 0x0600157F RID: 5503 RVA: 0x00016DCF File Offset: 0x00014FCF
		public Form getCardWindow()
		{
			return this.m_playCardsWindow;
		}

		// Token: 0x06001580 RID: 5504 RVA: 0x00016DD7 File Offset: 0x00014FD7
		public bool isCardPopupOpen()
		{
			return this.isPopupWindowOpen(this.m_playCardsWindow);
		}

		// Token: 0x06001581 RID: 5505 RVA: 0x00016DE5 File Offset: 0x00014FE5
		public void setCurrentMenuPopup(MenuPopup menuPopup)
		{
			this.m_currentMenuPopup = menuPopup;
		}

		// Token: 0x06001582 RID: 5506 RVA: 0x00016DEE File Offset: 0x00014FEE
		public void moveMenuPopup()
		{
			this.closeMenuPopup();
		}

		// Token: 0x06001583 RID: 5507 RVA: 0x00016DF6 File Offset: 0x00014FF6
		public void closeMenuPopup()
		{
			MainWindow.captureCloseMenuEvent = false;
			if (this.m_currentMenuPopup != null)
			{
				this.closePopupWindow(this.m_currentMenuPopup);
				this.m_currentMenuPopup = null;
				this.m_menuPopupClosedLastTime = DateTime.Now;
			}
		}

		// Token: 0x06001584 RID: 5508 RVA: 0x0015E41C File Offset: 0x0015C61C
		public bool menuPopupClosedRecently()
		{
			return (DateTime.Now - this.m_menuPopupClosedLastTime).TotalMilliseconds < 500.0;
		}

		// Token: 0x06001585 RID: 5509 RVA: 0x00016E24 File Offset: 0x00015024
		public MenuPopup getMenuPopup()
		{
			return this.m_currentMenuPopup;
		}

		// Token: 0x06001586 RID: 5510 RVA: 0x00016E2C File Offset: 0x0001502C
		public bool isMenuPopupOpen()
		{
			return this.isPopupWindowOpen(this.m_currentMenuPopup);
		}

		// Token: 0x06001587 RID: 5511 RVA: 0x00016E3A File Offset: 0x0001503A
		public void setCurrentCustomTooltip(CustomTooltip customTooltip)
		{
			this.m_currentCustomTooltip = customTooltip;
		}

		// Token: 0x06001588 RID: 5512 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void moveCustomTooltip()
		{
		}

		// Token: 0x06001589 RID: 5513 RVA: 0x00016E43 File Offset: 0x00015043
		public void closeCustomTooltip()
		{
			if (this.isPopupWindowOpen(this.m_currentCustomTooltip))
			{
				this.m_currentCustomTooltip.closing();
				this.m_currentCustomTooltip.Hide();
			}
		}

		// Token: 0x0600158A RID: 5514 RVA: 0x00016E69 File Offset: 0x00015069
		public CustomTooltip getCustomTooltip()
		{
			return this.m_currentCustomTooltip;
		}

		// Token: 0x0600158B RID: 5515 RVA: 0x00016E71 File Offset: 0x00015071
		public void runTooltips()
		{
			CustomTooltipManager.runTooltips();
			if (this.m_currentCustomTooltip != null && this.m_currentCustomTooltip.Created && this.m_currentCustomTooltip.Visible)
			{
				this.m_currentCustomTooltip.updateLocation();
			}
		}

		// Token: 0x0600158C RID: 5516 RVA: 0x00016EA5 File Offset: 0x000150A5
		public void setCurrentTutorialWindow(TutorialWindow tutorialWindow)
		{
			this.m_currentTutorialWindow = tutorialWindow;
		}

		// Token: 0x0600158D RID: 5517 RVA: 0x00016EAE File Offset: 0x000150AE
		public void moveTutorialWindow()
		{
			if (this.m_currentTutorialWindow != null && this.m_currentTutorialWindow.Created)
			{
				this.m_currentTutorialWindow.updateLocation(0, this.ParentForm);
			}
		}

		// Token: 0x0600158E RID: 5518 RVA: 0x00016ED7 File Offset: 0x000150D7
		public void closeTutorialWindow()
		{
			if (this.isPopupWindowOpen(this.m_currentTutorialWindow))
			{
				this.m_currentTutorialWindow.closing();
				this.m_currentTutorialWindow.Hide();
			}
		}

		// Token: 0x0600158F RID: 5519 RVA: 0x00016EFD File Offset: 0x000150FD
		public bool isTutorialWindowOpen()
		{
			return this.isPopupWindowOpen(this.m_currentTutorialWindow);
		}

		// Token: 0x06001590 RID: 5520 RVA: 0x00016F0B File Offset: 0x0001510B
		public TutorialWindow getTutorialWindow()
		{
			return this.m_currentTutorialWindow;
		}

		// Token: 0x06001591 RID: 5521 RVA: 0x00016F13 File Offset: 0x00015113
		public void runTutorialWindow()
		{
			if (this.m_currentTutorialWindow != null)
			{
				this.m_currentTutorialWindow.update();
			}
		}

		// Token: 0x06001592 RID: 5522 RVA: 0x0015E450 File Offset: 0x0015C650
		public void activateAchievementPopup(int id)
		{
			if (this.m_achievementPopup != null)
			{
				if (this.m_achievementPopup.isActive())
				{
					this.nextAchievementIDs.Add(id);
					return;
				}
				this.m_achievementPopup = null;
			}
			this.m_achievementPopup = new AchievementPopup();
			this.m_achievementPopup.activate(id);
		}

		// Token: 0x06001593 RID: 5523 RVA: 0x00016F28 File Offset: 0x00015128
		public void moveAchievementPopup()
		{
			if (this.m_achievementPopup != null)
			{
				this.m_achievementPopup.move();
			}
		}

		// Token: 0x06001594 RID: 5524 RVA: 0x00016F3D File Offset: 0x0001513D
		public void closeAchievementPopup()
		{
			if (this.m_achievementPopup != null)
			{
				this.closePopupWindow(this.m_achievementPopup);
				this.m_achievementPopup = null;
			}
		}

		// Token: 0x06001595 RID: 5525 RVA: 0x00016F5A File Offset: 0x0001515A
		public bool isInsideAchievementPopup()
		{
			return this.m_achievementPopup != null && this.m_achievementPopup.isMouseInside();
		}

		// Token: 0x06001596 RID: 5526 RVA: 0x00016F71 File Offset: 0x00015171
		public void openTradeMode(int villageID, bool keepInfo)
		{
			GameEngine.Instance.SkipVillageTab();
			InterfaceMgr.Instance.getMainTabBar().changeTab(1);
			InterfaceMgr.Instance.setVillageTabSubMode(2);
			this.tradeWithResume(villageID, keepInfo);
		}

		// Token: 0x06001597 RID: 5527 RVA: 0x0015E4A0 File Offset: 0x0015C6A0
		public ScoutPopupWindow openScoutPopupWindow(int villageID, bool resetData)
		{
			if (GameEngine.Instance.World.WorldEnded)
			{
				return null;
			}
			this.openGreyOutWindow(true);
			this.closePopupWindow(this.m_scoutPopupWindow);
			this.m_scoutPopupWindow = new ScoutPopupWindow();
			this.positionWindow(this.m_scoutPopupWindow, true, false);
			this.m_scoutPopupWindow.init(villageID, resetData);
			this.m_scoutPopupWindow.Show(this.getGreyOutWindow());
			if (InterfaceMgr.Instance.isTutorialWindowOpen())
			{
				GameEngine.Instance.World.forceTutorialToBeShown();
			}
			GameEngine.Instance.DisableMouseClicks();
			return this.m_scoutPopupWindow;
		}

		// Token: 0x06001598 RID: 5528 RVA: 0x00016FA0 File Offset: 0x000151A0
		public void moveScoutPopupWindow()
		{
			this.positionWindow(this.m_scoutPopupWindow, true, true);
		}

		// Token: 0x06001599 RID: 5529 RVA: 0x0015E538 File Offset: 0x0015C738
		public void closeScoutPopupWindow()
		{
			if (!this.scoutPopupWindowClosing)
			{
				this.scoutPopupWindowClosing = true;
				if (this.isPopupWindowOpenAndClose(this.m_scoutPopupWindow))
				{
					GameEngine.Instance.EnableMouseClicks();
					this.closeGreyOut();
					this.showDXCardBar(9);
					InterfaceMgr.Instance.closeParishPanel();
				}
				this.m_scoutPopupWindow = null;
				this.scoutPopupWindowClosing = false;
			}
		}

		// Token: 0x0600159A RID: 5530 RVA: 0x00016FB0 File Offset: 0x000151B0
		public ScoutPopupWindow getScoutPopupWindow()
		{
			return this.m_scoutPopupWindow;
		}

		// Token: 0x0600159B RID: 5531 RVA: 0x00016FB8 File Offset: 0x000151B8
		public bool isScoutPopup()
		{
			return this.isPopupWindowOpen(this.m_scoutPopupWindow);
		}

		// Token: 0x0600159C RID: 5532 RVA: 0x0015E594 File Offset: 0x0015C794
		public SendMonkWindow openSendMonkWindow(int villageID)
		{
			this.openGreyOutWindow(true);
			this.closePopupWindow(this.m_sendMonkWindow);
			this.m_sendMonkWindow = new SendMonkWindow();
			this.positionWindow(this.m_sendMonkWindow, true, false);
			this.m_sendMonkWindow.init(villageID);
			this.m_sendMonkWindow.Show(this.getGreyOutWindow());
			if (InterfaceMgr.Instance.isTutorialWindowOpen())
			{
				GameEngine.Instance.World.forceTutorialToBeShown();
			}
			GameEngine.Instance.DisableMouseClicks();
			return this.m_sendMonkWindow;
		}

		// Token: 0x0600159D RID: 5533 RVA: 0x00016FC6 File Offset: 0x000151C6
		public void moveSendMonkWindow()
		{
			this.positionWindow(this.m_sendMonkWindow, true, true);
		}

		// Token: 0x0600159E RID: 5534 RVA: 0x0015E618 File Offset: 0x0015C818
		public void closeSendMonkWindow()
		{
			if (!this.sendMonkWindowClosing)
			{
				this.sendMonkWindowClosing = true;
				if (this.isPopupWindowOpenAndClose(this.m_sendMonkWindow))
				{
					GameEngine.Instance.EnableMouseClicks();
					this.closeGreyOut();
					this.showDXCardBar(9);
					InterfaceMgr.Instance.closeParishPanel();
				}
				this.m_sendMonkWindow = null;
				this.sendMonkWindowClosing = false;
			}
		}

		// Token: 0x0600159F RID: 5535 RVA: 0x00016FD6 File Offset: 0x000151D6
		public SendMonkWindow getSendMonkWindow()
		{
			return this.m_sendMonkWindow;
		}

		// Token: 0x060015A0 RID: 5536 RVA: 0x00016FDE File Offset: 0x000151DE
		public bool isSendMonk()
		{
			return this.isPopupWindowOpen(this.m_sendMonkWindow);
		}

		// Token: 0x060015A1 RID: 5537 RVA: 0x0015E674 File Offset: 0x0015C874
		public void openBuyVillageWindow(int villageID, bool buy)
		{
			this.openGreyOutWindow(true);
			this.closePopupWindow(this.m_buyVillageWindow);
			this.m_buyVillageWindow = new BuyVillagePopupWindow();
			this.positionWindow(this.m_buyVillageWindow, true, false);
			this.m_buyVillageWindow.init(villageID, buy);
			this.m_buyVillageWindow.Show(this.getGreyOutWindow());
			if (InterfaceMgr.Instance.isTutorialWindowOpen())
			{
				GameEngine.Instance.World.forceTutorialToBeShown();
			}
			GameEngine.Instance.DisableMouseClicks();
		}

		// Token: 0x060015A2 RID: 5538 RVA: 0x00016FEC File Offset: 0x000151EC
		public void moveBuyVillagePopupWindow()
		{
			this.positionWindow(this.m_buyVillageWindow, true, true);
		}

		// Token: 0x060015A3 RID: 5539 RVA: 0x0015E6F4 File Offset: 0x0015C8F4
		public void closeBuyVillagePopupWindow()
		{
			if (!this.buyVillageWindowClosing)
			{
				this.buyVillageWindowClosing = true;
				if (this.isPopupWindowOpenAndClose(this.m_buyVillageWindow))
				{
					GameEngine.Instance.EnableMouseClicks();
					this.closeGreyOut();
					this.showDXCardBar(9);
				}
				this.m_buyVillageWindow = null;
				this.buyVillageWindowClosing = false;
			}
		}

		// Token: 0x060015A4 RID: 5540 RVA: 0x00016FFC File Offset: 0x000151FC
		public BuyVillagePopupWindow getBuyVillageWindow()
		{
			return this.m_buyVillageWindow;
		}

		// Token: 0x060015A5 RID: 5541 RVA: 0x00017004 File Offset: 0x00015204
		public bool isBuyVillage()
		{
			return this.isPopupWindowOpen(this.m_buyVillageWindow);
		}

		// Token: 0x060015A6 RID: 5542 RVA: 0x0015E744 File Offset: 0x0015C944
		public ConnectionErrorWindow openConnectionErrorWindow()
		{
			UniversalDebugLog.Log("Got connection error");
			this.openGreyOutWindow(true);
			this.closePopupWindow(this.m_connectionErrorWindow);
			this.m_connectionErrorWindow = new ConnectionErrorWindow();
			this.positionWindow(this.m_connectionErrorWindow, false, false);
			this.m_connectionErrorWindow.init();
			this.m_connectionErrorWindow.Show(this.getGreyOutWindow());
			if (InterfaceMgr.Instance.isTutorialWindowOpen())
			{
				GameEngine.Instance.World.forceTutorialToBeShown();
			}
			GameEngine.Instance.DisableMouseClicks();
			return this.m_connectionErrorWindow;
		}

		// Token: 0x060015A7 RID: 5543 RVA: 0x00017012 File Offset: 0x00015212
		public void moveConnectionErrorWindow()
		{
			this.positionWindow(this.m_connectionErrorWindow, true, true);
		}

		// Token: 0x060015A8 RID: 5544 RVA: 0x0015E7D0 File Offset: 0x0015C9D0
		public void closeConnectionErrorWindow()
		{
			if (!this.connectionErrorWindowClosing)
			{
				this.connectionErrorWindowClosing = true;
				if (this.isPopupWindowOpenAndClose(this.m_connectionErrorWindow))
				{
					GameEngine.Instance.EnableMouseClicks();
					this.closeGreyOut();
					this.showDXCardBar(9);
				}
				this.m_connectionErrorWindow = null;
				this.connectionErrorWindowClosing = false;
			}
		}

		// Token: 0x060015A9 RID: 5545 RVA: 0x00017022 File Offset: 0x00015222
		public ConnectionErrorWindow getConnectionErrorWindow()
		{
			return this.m_connectionErrorWindow;
		}

		// Token: 0x060015AA RID: 5546 RVA: 0x0001702A File Offset: 0x0001522A
		public bool isConnectionErrorWindow()
		{
			return this.isPopupWindowOpen(this.m_connectionErrorWindow);
		}

		// Token: 0x060015AB RID: 5547 RVA: 0x0015E820 File Offset: 0x0015CA20
		public GreyOutWindow openGreyOutWindow(bool showBorder)
		{
			if (this.isPopupWindowCreated(this.m_greyOutWindow))
			{
				return this.m_greyOutWindow;
			}
			this.m_greyLogin = false;
			this.m_greyOutWindow = new GreyOutWindow();
			Size clientSize = this.parentMainWindow.ClientSize;
			Point location = this.parentMainWindow.PointToScreen(new Point(0, 0));
			this.m_greyOutWindow.Location = location;
			this.m_greyOutWindow.Size = clientSize;
			this.m_greyOutWindow.init(showBorder);
			this.m_greyOutWindow.Show(this.ParentMainWindow);
			return this.m_greyOutWindow;
		}

		// Token: 0x060015AC RID: 5548 RVA: 0x0015E8B0 File Offset: 0x0015CAB0
		public GreyOutWindow openGreyOutWindowLogin(bool showBorder)
		{
			if (this.isPopupWindowCreated(this.m_greyOutWindow))
			{
				return this.m_greyOutWindow;
			}
			if (Program.profileLogin == null)
			{
				return null;
			}
			this.m_greyLogin = true;
			this.m_greyOutWindow = new GreyOutWindow();
			Size clientSize = Program.profileLogin.ClientSize;
			Point location = Program.profileLogin.PointToScreen(new Point(0, 0));
			this.m_greyOutWindow.Location = location;
			this.m_greyOutWindow.Size = clientSize;
			this.m_greyOutWindow.init(showBorder);
			this.m_greyOutWindow.Show(Program.profileLogin);
			return this.m_greyOutWindow;
		}

		// Token: 0x060015AD RID: 5549 RVA: 0x0015E944 File Offset: 0x0015CB44
		public GreyOutWindow openGreyOutWindow(bool showBorder, Form parent)
		{
			if (this.isPopupWindowCreated(this.m_greyOutWindow))
			{
				return this.m_greyOutWindow;
			}
			this.m_greyLogin = false;
			this.m_greyOutWindow = new GreyOutWindow();
			Size clientSize = parent.ClientSize;
			Point location = parent.PointToScreen(new Point(0, 0));
			this.m_greyOutWindow.Location = location;
			this.m_greyOutWindow.Size = clientSize;
			this.m_greyOutWindow.init(showBorder);
			this.m_greyOutWindow.Show(parent);
			return this.m_greyOutWindow;
		}

		// Token: 0x060015AE RID: 5550 RVA: 0x0015E9C4 File Offset: 0x0015CBC4
		public void moveGreyOutWindow()
		{
			if (!this.isPopupWindowCreated(this.m_greyOutWindow))
			{
				return;
			}
			if (this.m_greyLogin)
			{
				if (Program.profileLogin != null)
				{
					Size clientSize = Program.profileLogin.ClientSize;
					Point location = Program.profileLogin.PointToScreen(new Point(0, 0));
					this.m_greyOutWindow.Location = location;
					this.m_greyOutWindow.Size = clientSize;
					return;
				}
			}
			else
			{
				Size clientSize2 = this.parentMainWindow.ClientSize;
				Point location2 = this.parentMainWindow.PointToScreen(new Point(0, 0));
				this.m_greyOutWindow.Location = location2;
				this.m_greyOutWindow.Size = clientSize2;
			}
		}

		// Token: 0x060015AF RID: 5551 RVA: 0x00017038 File Offset: 0x00015238
		public void closeGreyOut()
		{
			this.closePopupWindow(this.m_greyOutWindow);
			this.m_greyOutWindow = null;
		}

		// Token: 0x060015B0 RID: 5552 RVA: 0x0001704D File Offset: 0x0001524D
		public GreyOutWindow getGreyOutWindow()
		{
			return this.m_greyOutWindow;
		}

		// Token: 0x060015B1 RID: 5553 RVA: 0x00017055 File Offset: 0x00015255
		public bool isGreyOutWindow()
		{
			return this.isPopupWindowOpen(this.m_greyOutWindow);
		}

		// Token: 0x060015B2 RID: 5554 RVA: 0x00017063 File Offset: 0x00015263
		public void setCurrentDonatePopup(DonatePopup donatePopup)
		{
			this.m_currentDonatePopup = donatePopup;
		}

		// Token: 0x060015B3 RID: 5555 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void moveDonatePopup()
		{
		}

		// Token: 0x060015B4 RID: 5556 RVA: 0x0001706C File Offset: 0x0001526C
		public void closeDonatePopup()
		{
			if (this.isPopupWindowOpen(this.m_currentDonatePopup))
			{
				this.m_currentDonatePopup.Hide();
			}
		}

		// Token: 0x060015B5 RID: 5557 RVA: 0x00017087 File Offset: 0x00015287
		public bool isDonatePopupOpen()
		{
			return this.isPopupWindowOpen(this.m_currentDonatePopup);
		}

		// Token: 0x060015B6 RID: 5558 RVA: 0x00017095 File Offset: 0x00015295
		public DonatePopup getDonatePopup()
		{
			return this.m_currentDonatePopup;
		}

		// Token: 0x060015B7 RID: 5559 RVA: 0x0001709D File Offset: 0x0001529D
		public LogoutOptionsWindow2 openLogoutWindow(bool normalLogout)
		{
			return this.openLogoutWindow(normalLogout, false);
		}

		// Token: 0x060015B8 RID: 5560 RVA: 0x0015EA5C File Offset: 0x0015CC5C
		public LogoutOptionsWindow2 openLogoutWindow(bool normalLogout, bool advertOnly)
		{
			this.openGreyOutWindow(false);
			this.closePopupWindow(this.m_logoutOptionsWindow);
			this.m_logoutOptionsWindow = new LogoutOptionsWindow2();
			this.positionWindow(this.m_logoutOptionsWindow, false, false);
			this.m_logoutOptionsWindow.init(normalLogout, advertOnly);
			this.m_logoutOptionsWindow.Show(this.getGreyOutWindow());
			GameEngine.Instance.DisableMouseClicks();
			return this.m_logoutOptionsWindow;
		}

		// Token: 0x060015B9 RID: 5561 RVA: 0x000170A7 File Offset: 0x000152A7
		public void moveLogoutWindow()
		{
			this.positionWindow(this.m_logoutOptionsWindow, false, true);
		}

		// Token: 0x060015BA RID: 5562 RVA: 0x000170B7 File Offset: 0x000152B7
		public void closeLogoutWindow()
		{
			if (!this.logoutWindowClosing)
			{
				this.logoutWindowClosing = true;
				if (this.isPopupWindowOpenAndClose(this.m_logoutOptionsWindow))
				{
					GameEngine.Instance.EnableMouseClicks();
					this.closeGreyOut();
				}
				this.m_logoutOptionsWindow = null;
				this.logoutWindowClosing = false;
			}
		}

		// Token: 0x060015BB RID: 5563 RVA: 0x000170F4 File Offset: 0x000152F4
		public Form getLogoutWindow()
		{
			return this.m_logoutOptionsWindow;
		}

		// Token: 0x060015BC RID: 5564 RVA: 0x000170FC File Offset: 0x000152FC
		public bool isLogoutPopupOpen()
		{
			return this.isPopupWindowOpen(this.m_logoutOptionsWindow);
		}

		// Token: 0x060015BD RID: 5565 RVA: 0x0015EAC4 File Offset: 0x0015CCC4
		public ReportCapturePopup openReportCaptureWindow(int mode)
		{
			this.openGreyOutWindow(false);
			this.closePopupWindow(this.m_reportCapturePopup);
			this.m_reportCapturePopup = new ReportCapturePopup();
			this.m_reportCapturePopup.init(mode);
			this.positionWindow(this.m_reportCapturePopup, false, false);
			this.m_reportCapturePopup.Show(this.getGreyOutWindow());
			GameEngine.Instance.DisableMouseClicks();
			return this.m_reportCapturePopup;
		}

		// Token: 0x060015BE RID: 5566 RVA: 0x0001710A File Offset: 0x0001530A
		public void moveReportCaptureWindow()
		{
			this.positionWindow(this.m_reportCapturePopup, false, true);
		}

		// Token: 0x060015BF RID: 5567 RVA: 0x0001711A File Offset: 0x0001531A
		public void closeReportCaptureWindow()
		{
			if (!this.reportCaptureWindowClosing)
			{
				this.reportCaptureWindowClosing = true;
				if (this.isPopupWindowOpenAndClose(this.m_reportCapturePopup))
				{
					GameEngine.Instance.EnableMouseClicks();
					this.closeGreyOut();
				}
				this.m_reportCapturePopup = null;
				this.reportCaptureWindowClosing = false;
			}
		}

		// Token: 0x060015C0 RID: 5568 RVA: 0x00017157 File Offset: 0x00015357
		public Form getReportCaptureWindow()
		{
			return this.m_reportCapturePopup;
		}

		// Token: 0x060015C1 RID: 5569 RVA: 0x0001715F File Offset: 0x0001535F
		public bool isReportCapturePopupOpen()
		{
			return this.isPopupWindowOpen(this.m_reportCapturePopup);
		}

		// Token: 0x060015C2 RID: 5570 RVA: 0x0015EB2C File Offset: 0x0015CD2C
		public NewQuestRewardPopup openNewQuestRewardPopup(int questID, int villageID, NewQuestsPanel parent)
		{
			this.openGreyOutWindow(false);
			this.closePopupWindow(this.m_newQuestRewardPopup);
			this.m_newQuestRewardPopup = new NewQuestRewardPopup();
			this.m_newQuestRewardPopup.init(questID, villageID, parent);
			this.positionWindow(this.m_newQuestRewardPopup, false, false);
			this.m_newQuestRewardPopup.Show(this.getGreyOutWindow());
			GameEngine.Instance.DisableMouseClicks();
			return this.m_newQuestRewardPopup;
		}

		// Token: 0x060015C3 RID: 5571 RVA: 0x0001716D File Offset: 0x0001536D
		public void moveNewQuestRewardPopup()
		{
			this.positionWindow(this.m_newQuestRewardPopup, false, true);
		}

		// Token: 0x060015C4 RID: 5572 RVA: 0x0001717D File Offset: 0x0001537D
		public void closeNewQuestRewardPopup()
		{
			if (!this.newQuestRewardPopupClosing)
			{
				this.newQuestRewardPopupClosing = true;
				if (this.isPopupWindowOpenAndClose(this.m_newQuestRewardPopup))
				{
					GameEngine.Instance.EnableMouseClicks();
					this.closeGreyOut();
				}
				this.m_newQuestRewardPopup = null;
				this.newQuestRewardPopupClosing = false;
			}
		}

		// Token: 0x060015C5 RID: 5573 RVA: 0x000171BA File Offset: 0x000153BA
		public Form getNewQuestRewardWindow()
		{
			return this.m_newQuestRewardPopup;
		}

		// Token: 0x060015C6 RID: 5574 RVA: 0x000171C2 File Offset: 0x000153C2
		public bool isNewQuestRewardPopupOpen()
		{
			return this.isPopupWindowOpen(this.m_newQuestRewardPopup);
		}

		// Token: 0x060015C7 RID: 5575 RVA: 0x000171D0 File Offset: 0x000153D0
		public void openNewQuestsCompletedPopup(List<int> completedQuests)
		{
			this.closeNewQuestsCompletedPopup();
			this.newQuestsCompletedWindow = new NewQuestsCompletedWindow();
			this.newQuestsCompletedWindow.init(this.ParentForm, completedQuests, true, null, -1);
			this.newQuestsCompletedWindow.Show(this.ParentForm);
		}

		// Token: 0x060015C8 RID: 5576 RVA: 0x0015EB98 File Offset: 0x0015CD98
		public void openNewQuestFurtherTextPopup(string questTag, int questID)
		{
			List<int> quests = new List<int>();
			this.closeNewQuestsCompletedPopup();
			this.newQuestsCompletedWindow = new NewQuestsCompletedWindow();
			this.newQuestsCompletedWindow.init(this.ParentForm, quests, false, questTag, questID);
			this.newQuestsCompletedWindow.Show(this.ParentForm);
		}

		// Token: 0x060015C9 RID: 5577 RVA: 0x00017209 File Offset: 0x00015409
		public void closeNewQuestsCompletedPopup()
		{
			if (this.newQuestsCompletedWindow != null)
			{
				this.newQuestsCompletedWindow.Close();
				this.newQuestsCompletedWindow = null;
			}
		}

		// Token: 0x060015CA RID: 5578 RVA: 0x00017225 File Offset: 0x00015425
		public void openGloryVictoryPopup()
		{
			this.closeGloryVictoryWindowPopup();
			this.gloryVictoryWindow = new GloryVictoryWindow();
			this.gloryVictoryWindow.init(this.ParentForm);
			this.gloryVictoryWindow.Show(this.ParentForm);
		}

		// Token: 0x060015CB RID: 5579 RVA: 0x0001725A File Offset: 0x0001545A
		public void openGloryValuesPopup()
		{
			this.closeGloryVictoryWindowPopup();
			this.gloryVictoryWindow = new GloryVictoryWindow();
			this.gloryVictoryWindow.initValues(this.ParentForm);
			this.gloryVictoryWindow.Show(this.ParentForm);
		}

		// Token: 0x060015CC RID: 5580 RVA: 0x0001728F File Offset: 0x0001548F
		public void closeGloryVictoryWindowPopup()
		{
			if (this.gloryVictoryWindow != null)
			{
				this.gloryVictoryWindow.Close();
				this.gloryVictoryWindow = null;
			}
		}

		// Token: 0x060015CD RID: 5581 RVA: 0x0015EBE4 File Offset: 0x0015CDE4
		public AdvancedCastleOptionsPopup openAdvancedCastleOptionsPopup(bool castleSetup)
		{
			this.openGreyOutWindow(false);
			this.closePopupWindow(this.m_advancedCastleOptionsPopup);
			this.m_advancedCastleOptionsPopup = new AdvancedCastleOptionsPopup();
			this.m_advancedCastleOptionsPopup.init(castleSetup);
			this.positionWindow(this.m_advancedCastleOptionsPopup, false, false);
			this.m_advancedCastleOptionsPopup.Show(this.getGreyOutWindow());
			GameEngine.Instance.DisableMouseClicks();
			return this.m_advancedCastleOptionsPopup;
		}

		// Token: 0x060015CE RID: 5582 RVA: 0x000172AB File Offset: 0x000154AB
		public void moveAdvancedCastleOptionsPopup()
		{
			this.positionWindow(this.m_advancedCastleOptionsPopup, false, true);
		}

		// Token: 0x060015CF RID: 5583 RVA: 0x000172BB File Offset: 0x000154BB
		public void closeAdvancedCastleOptionsPopup()
		{
			if (!this.advancedCastleOptionsPopupClosing)
			{
				this.advancedCastleOptionsPopupClosing = true;
				if (this.isPopupWindowOpenAndClose(this.m_advancedCastleOptionsPopup))
				{
					GameEngine.Instance.EnableMouseClicks();
					this.closeGreyOut();
				}
				this.m_advancedCastleOptionsPopup = null;
				this.advancedCastleOptionsPopupClosing = false;
			}
		}

		// Token: 0x060015D0 RID: 5584 RVA: 0x000172F8 File Offset: 0x000154F8
		public Form getAdvancedCastleOptionsPopup()
		{
			return this.m_advancedCastleOptionsPopup;
		}

		// Token: 0x060015D1 RID: 5585 RVA: 0x00017300 File Offset: 0x00015500
		public bool isAdvancedCastleOptionsPopup()
		{
			return this.isPopupWindowOpen(this.m_advancedCastleOptionsPopup);
		}

		// Token: 0x060015D2 RID: 5586 RVA: 0x0015EC4C File Offset: 0x0015CE4C
		public FormationPopup openFormationPopup()
		{
			this.openGreyOutWindow(false);
			this.closePopupWindow(this.m_formationPopup);
			this.m_formationPopup = new FormationPopup();
			this.positionWindow(this.m_formationPopup, false, false);
			this.m_formationPopup.Show(this.getGreyOutWindow());
			GameEngine.Instance.DisableMouseClicks();
			return this.m_formationPopup;
		}

		// Token: 0x060015D3 RID: 5587 RVA: 0x0001730E File Offset: 0x0001550E
		public void moveFormationPopup()
		{
			this.positionWindow(this.m_formationPopup, false, true);
		}

		// Token: 0x060015D4 RID: 5588 RVA: 0x0001731E File Offset: 0x0001551E
		public void closeFormationPopup()
		{
			if (!this.formationPopupClosing)
			{
				this.formationPopupClosing = true;
				if (this.isPopupWindowOpenAndClose(this.m_formationPopup))
				{
					GameEngine.Instance.EnableMouseClicks();
					this.closeGreyOut();
				}
				this.m_formationPopup = null;
				this.formationPopupClosing = false;
			}
		}

		// Token: 0x060015D5 RID: 5589 RVA: 0x0001735B File Offset: 0x0001555B
		public Form getFormationPopup()
		{
			return this.m_formationPopup;
		}

		// Token: 0x060015D6 RID: 5590 RVA: 0x00017363 File Offset: 0x00015563
		public bool isFormationPopup()
		{
			return this.isPopupWindowOpen(this.m_formationPopup);
		}

		// Token: 0x060015D7 RID: 5591 RVA: 0x0015ECA8 File Offset: 0x0015CEA8
		public PresetPopup openPresetPopup(PresetType type)
		{
			this.openGreyOutWindow(false);
			this.closePopupWindow(this.m_presetPopup);
			this.m_presetPopup = new PresetPopup(type);
			this.positionWindow(this.m_presetPopup, false, false);
			this.m_presetPopup.Show(this.getGreyOutWindow());
			this.m_presetPopup.Location = InterfaceMgr.Instance.ParentMainWindow.getDXBasePanel().PointToScreen(new Point(0, 0));
			GameEngine.Instance.DisableMouseClicks();
			if (!PresetManager.Instance.IsDataReady)
			{
				PresetManager.Instance.LoadPresetsFromServer(this.m_presetPopup.GetPanel());
			}
			return this.m_presetPopup;
		}

		// Token: 0x060015D8 RID: 5592 RVA: 0x00017371 File Offset: 0x00015571
		public void closePresetPopup()
		{
			if (!this.presetPopupClosing)
			{
				this.presetPopupClosing = true;
				if (this.isPopupWindowOpenAndClose(this.m_presetPopup))
				{
					GameEngine.Instance.EnableMouseClicks();
					this.closeGreyOut();
				}
				this.m_presetPopup = null;
				this.presetPopupClosing = false;
			}
		}

		// Token: 0x060015D9 RID: 5593 RVA: 0x0015ED4C File Offset: 0x0015CF4C
		public AttackTargetsPopup openAttackTargetsPopup()
		{
			this.closePopupWindow(this.m_AttackTargetsPopup);
			this.m_AttackTargetsPopup = new AttackTargetsPopup();
			this.positionWindow(this.m_AttackTargetsPopup, false, false);
			this.m_AttackTargetsPopup.Show(this.ParentMainWindow);
			GameEngine.Instance.DisableMouseClicks();
			return this.m_AttackTargetsPopup;
		}

		// Token: 0x060015DA RID: 5594 RVA: 0x000173AE File Offset: 0x000155AE
		public void moveAttackTargetsPopup()
		{
			this.positionWindow(this.m_AttackTargetsPopup, false, true);
		}

		// Token: 0x060015DB RID: 5595 RVA: 0x000173BE File Offset: 0x000155BE
		public void closeAttackTargetsPopup()
		{
			if (!this.AttackTargetsPopupClosing)
			{
				this.AttackTargetsPopupClosing = true;
				if (this.isPopupWindowOpenAndClose(this.m_AttackTargetsPopup))
				{
					GameEngine.Instance.EnableMouseClicks();
				}
				this.m_AttackTargetsPopup = null;
				this.AttackTargetsPopupClosing = false;
			}
		}

		// Token: 0x060015DC RID: 5596 RVA: 0x000173F5 File Offset: 0x000155F5
		public Form getAttackTargetsPopup()
		{
			return this.m_AttackTargetsPopup;
		}

		// Token: 0x060015DD RID: 5597 RVA: 0x000173FD File Offset: 0x000155FD
		public bool isAttackTargetsPopup()
		{
			return this.isPopupWindowOpen(this.m_AttackTargetsPopup);
		}

		// Token: 0x060015DE RID: 5598 RVA: 0x0015EDA0 File Offset: 0x0015CFA0
		public FreeCardsPopup openFreeCardsPopup()
		{
			this.openGreyOutWindow(true);
			this.closePopupWindow(this.m_freeCardsPopup);
			this.m_freeCardsPopup = new FreeCardsPopup();
			this.positionWindow(this.m_freeCardsPopup, false, false);
			this.m_freeCardsPopup.init();
			this.m_freeCardsPopup.Show(this.getGreyOutWindow());
			GameEngine.Instance.DisableMouseClicks();
			return this.m_freeCardsPopup;
		}

		// Token: 0x060015DF RID: 5599 RVA: 0x0001740B File Offset: 0x0001560B
		public void moveFreeCardsPopup()
		{
			this.positionWindow(this.m_freeCardsPopup, false, true);
		}

		// Token: 0x060015E0 RID: 5600 RVA: 0x0001741B File Offset: 0x0001561B
		public void closeFreeCardsPopup()
		{
			if (!this.freeCardsPopupClosing)
			{
				this.freeCardsPopupClosing = true;
				if (this.isPopupWindowOpenAndClose(this.m_freeCardsPopup))
				{
					GameEngine.Instance.EnableMouseClicks();
					this.closeGreyOut();
				}
				this.m_freeCardsPopup = null;
				this.freeCardsPopupClosing = false;
			}
		}

		// Token: 0x060015E1 RID: 5601 RVA: 0x00017458 File Offset: 0x00015658
		public FreeCardsPopup getFreeCardsPopup()
		{
			return this.m_freeCardsPopup;
		}

		// Token: 0x060015E2 RID: 5602 RVA: 0x00017460 File Offset: 0x00015660
		public bool isFreeCardsPopup()
		{
			return this.isPopupWindowOpen(this.m_freeCardsPopup);
		}

		// Token: 0x060015E3 RID: 5603 RVA: 0x0015EE08 File Offset: 0x0015D008
		public WheelPopup openWheelPopup(int wheelType)
		{
			this.openGreyOutWindow(true);
			this.closePopupWindow(this.m_WheelPopup);
			this.m_WheelPopup = new WheelPopup();
			this.positionWindow(this.m_WheelPopup, false, false);
			this.m_WheelPopup.init(wheelType);
			this.m_WheelPopup.Show(this.getGreyOutWindow());
			GameEngine.Instance.DisableMouseClicks();
			return this.m_WheelPopup;
		}

		// Token: 0x060015E4 RID: 5604 RVA: 0x0001746E File Offset: 0x0001566E
		public void moveWheelPopup()
		{
			this.positionWindow(this.m_WheelPopup, false, true);
		}

		// Token: 0x060015E5 RID: 5605 RVA: 0x0015EE70 File Offset: 0x0015D070
		public void closeWheelPopup()
		{
			if (!this.WheelPopupClosing)
			{
				WheelPanel.ClearInstance();
				this.WheelPopupClosing = true;
				if (this.isPopupWindowOpenAndClose(this.m_WheelPopup))
				{
					GameEngine.Instance.EnableMouseClicks();
					this.closeGreyOut();
				}
				this.m_WheelPopup = null;
				this.WheelPopupClosing = false;
			}
		}

		// Token: 0x060015E6 RID: 5606 RVA: 0x0001747E File Offset: 0x0001567E
		public WheelPopup getWheelPopup()
		{
			return this.m_WheelPopup;
		}

		// Token: 0x060015E7 RID: 5607 RVA: 0x00017486 File Offset: 0x00015686
		public bool isWheelPopup()
		{
			return this.isPopupWindowOpen(this.m_WheelPopup);
		}

		// Token: 0x060015E8 RID: 5608 RVA: 0x0015EEC0 File Offset: 0x0015D0C0
		public WheelSelectPopup openWheelSelectPopup()
		{
			this.openGreyOutWindow(true);
			this.closePopupWindow(this.m_WheelSelectPopup);
			this.m_WheelSelectPopup = new WheelSelectPopup();
			this.positionWindow(this.m_WheelSelectPopup, false, false);
			this.m_WheelSelectPopup.init();
			this.m_WheelSelectPopup.Show(this.getGreyOutWindow());
			GameEngine.Instance.DisableMouseClicks();
			return this.m_WheelSelectPopup;
		}

		// Token: 0x060015E9 RID: 5609 RVA: 0x00017494 File Offset: 0x00015694
		public void moveWheelSelectPopup()
		{
			this.positionWindow(this.m_WheelSelectPopup, false, true);
		}

		// Token: 0x060015EA RID: 5610 RVA: 0x0015EF28 File Offset: 0x0015D128
		public void closeWheelSelectPopup()
		{
			if (!this.WheelSelectPopupClosing)
			{
				WheelPanel.ClearInstance();
				this.WheelSelectPopupClosing = true;
				if (this.isPopupWindowOpenAndClose(this.m_WheelSelectPopup))
				{
					GameEngine.Instance.EnableMouseClicks();
					this.closeGreyOut();
				}
				this.m_WheelSelectPopup = null;
				this.WheelSelectPopupClosing = false;
			}
		}

		// Token: 0x060015EB RID: 5611 RVA: 0x000174A4 File Offset: 0x000156A4
		public WheelSelectPopup getWheelSelectPopup()
		{
			return this.m_WheelSelectPopup;
		}

		// Token: 0x060015EC RID: 5612 RVA: 0x000174AC File Offset: 0x000156AC
		public bool isWheelSelectPopup()
		{
			return this.isPopupWindowOpen(this.m_WheelSelectPopup);
		}

		// Token: 0x060015ED RID: 5613 RVA: 0x000174BA File Offset: 0x000156BA
		public void showDominationWindow()
		{
			this.dominationWindow = new DominationWindow();
			this.dominationWindow.Show(this.parentMainWindow);
		}

		// Token: 0x060015EE RID: 5614 RVA: 0x000174D8 File Offset: 0x000156D8
		public void updateDominationWindow(string text)
		{
			if (this.dominationWindow != null)
			{
				this.dominationWindow.updateText(text);
			}
		}

		// Token: 0x060015EF RID: 5615 RVA: 0x000174EE File Offset: 0x000156EE
		public void closeDominatonWindow()
		{
			if (this.dominationWindow != null)
			{
				this.dominationWindow.Close();
				this.dominationWindow = null;
			}
		}

		// Token: 0x060015F0 RID: 5616 RVA: 0x0001750A File Offset: 0x0001570A
		public void openAdvicePopupFromButton(int screenID)
		{
			this.closeAdvicePopup();
			this.advicePopup = new AdvicePopup();
			this.advicePopup.init(this.ParentForm, screenID);
			this.advicePopup.Show(this.ParentForm);
			this.setAdviceViewed(screenID);
		}

		// Token: 0x060015F1 RID: 5617 RVA: 0x0015EF78 File Offset: 0x0015D178
		public void openAdvicePopupFirstTime(int screenID)
		{
			if (Program.mySettings.adviceEnabled && !this.adviceIsViewed(screenID))
			{
				this.closeAdvicePopup();
				this.advicePopup = new AdvicePopup();
				this.advicePopup.init(this.ParentForm, screenID);
				this.advicePopup.Show(this.ParentForm);
				this.setAdviceViewed(screenID);
			}
		}

		// Token: 0x060015F2 RID: 5618 RVA: 0x00017547 File Offset: 0x00015747
		public void enableAdvicePopups(bool enabled)
		{
			Program.mySettings.adviceEnabled = enabled;
		}

		// Token: 0x060015F3 RID: 5619 RVA: 0x0015EFD8 File Offset: 0x0015D1D8
		public bool adviceIsViewed(int screenID)
		{
			string[] array = Program.mySettings.advicePanelsViewed.Split(new char[]
			{
				','
			});
			if (array.Length == 1 && string.IsNullOrEmpty(array[0]))
			{
				return false;
			}
			string[] array2 = array;
			foreach (string s in array2)
			{
				if (int.Parse(s) == screenID)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060015F4 RID: 5620 RVA: 0x0015F038 File Offset: 0x0015D238
		public void setAdviceViewed(int screenID)
		{
			if (!this.adviceIsViewed(screenID))
			{
				if (string.IsNullOrEmpty(Program.mySettings.advicePanelsViewed))
				{
					Program.mySettings.advicePanelsViewed = screenID.ToString();
					return;
				}
				MySettings mySettings = Program.mySettings;
				mySettings.advicePanelsViewed = mySettings.advicePanelsViewed + "," + screenID.ToString();
			}
		}

		// Token: 0x060015F5 RID: 5621 RVA: 0x00017554 File Offset: 0x00015754
		public void closeAdvicePopup()
		{
			if (this.advicePopup != null)
			{
				this.advicePopup.Close();
				this.advicePopup = null;
			}
		}

		// Token: 0x060015F6 RID: 5622 RVA: 0x0015F094 File Offset: 0x0015D294
		public ConfirmOpenPackPopup openConfirmOpenPackPopup(UICardPack pack, ConfirmOpenPackPanel.CardClickPlayDelegate callback)
		{
			this.closePopupWindow(this.m_confirmOpenPackPopup);
			this.m_confirmOpenPackPopup = new ConfirmOpenPackPopup();
			this.positionWindow(this.m_confirmOpenPackPopup, false, false);
			this.m_confirmOpenPackPopup.init(pack, callback);
			this.m_confirmOpenPackPopup.Show(this.getCardWindow());
			return this.m_confirmOpenPackPopup;
		}

		// Token: 0x060015F7 RID: 5623 RVA: 0x00017570 File Offset: 0x00015770
		public void moveConfirmOpenPackPopup()
		{
			this.positionWindow(this.m_confirmOpenPackPopup, true, true);
		}

		// Token: 0x060015F8 RID: 5624 RVA: 0x0015F0EC File Offset: 0x0015D2EC
		public void closeConfirmOpenPackPopup()
		{
			if (!this.confirmOpenPackPopupClosing)
			{
				this.confirmOpenPackPopupClosing = true;
				if (this.isPopupWindowOpenAndClose(this.m_confirmOpenPackPopup))
				{
					PlayCardsWindow playCardsWindow = (PlayCardsWindow)this.getCardWindow();
					playCardsWindow.reactivatePanel();
				}
				this.m_confirmOpenPackPopup = null;
				this.confirmOpenPackPopupClosing = false;
			}
		}

		// Token: 0x060015F9 RID: 5625 RVA: 0x00017580 File Offset: 0x00015780
		public ConfirmOpenPackPopup getConfirmOpenPackPopup()
		{
			return this.m_confirmOpenPackPopup;
		}

		// Token: 0x060015FA RID: 5626 RVA: 0x00017588 File Offset: 0x00015788
		public bool isConfirmOpenPackPopup()
		{
			return this.isPopupWindowOpen(this.m_confirmOpenPackPopup);
		}

		// Token: 0x060015FB RID: 5627 RVA: 0x0015F138 File Offset: 0x0015D338
		public ConfirmBuyOfferPopup openConfirmBuyOfferPopup(UICardOffer offer, ConfirmBuyOfferPanel.CardClickPlayDelegate callback)
		{
			this.closePopupWindow(this.m_confirmBuyOfferPopup);
			this.m_confirmBuyOfferPopup = new ConfirmBuyOfferPopup();
			this.positionWindow(this.m_confirmBuyOfferPopup, false, false);
			this.m_confirmBuyOfferPopup.init(offer, callback);
			this.m_confirmBuyOfferPopup.Show(this.getCardWindow());
			return this.m_confirmBuyOfferPopup;
		}

		// Token: 0x060015FC RID: 5628 RVA: 0x00017596 File Offset: 0x00015796
		public void moveConfirmBuyOfferPopup()
		{
			this.positionWindow(this.m_confirmBuyOfferPopup, true, true);
		}

		// Token: 0x060015FD RID: 5629 RVA: 0x0015F190 File Offset: 0x0015D390
		public void closeConfirmBuyOfferPopup()
		{
			if (!this.confirmBuyOfferPopupClosing)
			{
				this.confirmBuyOfferPopupClosing = true;
				if (this.isPopupWindowOpenAndClose(this.m_confirmBuyOfferPopup))
				{
					PlayCardsWindow playCardsWindow = (PlayCardsWindow)this.getCardWindow();
					playCardsWindow.reactivatePanel();
				}
				this.m_confirmBuyOfferPopup = null;
				this.confirmBuyOfferPopupClosing = false;
			}
		}

		// Token: 0x060015FE RID: 5630 RVA: 0x000175A6 File Offset: 0x000157A6
		public ConfirmBuyOfferPopup getConfirmBuyOfferPopup()
		{
			return this.m_confirmBuyOfferPopup;
		}

		// Token: 0x060015FF RID: 5631 RVA: 0x000175AE File Offset: 0x000157AE
		public bool isConfirmBuyOfferPopup()
		{
			return this.isPopupWindowOpen(this.m_confirmBuyOfferPopup);
		}

		// Token: 0x06001600 RID: 5632 RVA: 0x0015F1DC File Offset: 0x0015D3DC
		public ConfirmPlayCardPopup openConfirmPlayCardPopup(CardTypes.CardDefinition def, ConfirmPlayCardPanel.CardClickPlayDelegate callback)
		{
			this.closePopupWindow(this.m_confirmPlayCardPopup);
			this.m_confirmPlayCardPopup = new ConfirmPlayCardPopup();
			this.positionWindow(this.m_confirmPlayCardPopup, false, false);
			this.m_confirmPlayCardPopup.init(def, callback);
			this.m_confirmPlayCardPopup.Show(this.getCardWindow());
			return this.m_confirmPlayCardPopup;
		}

		// Token: 0x06001601 RID: 5633 RVA: 0x000175BC File Offset: 0x000157BC
		public void moveConfirmPlayCardPopup()
		{
			this.positionWindow(this.m_confirmPlayCardPopup, true, true);
		}

		// Token: 0x06001602 RID: 5634 RVA: 0x0015F234 File Offset: 0x0015D434
		public void closeConfirmPlayCardPopup()
		{
			if (!this.confirmPlayCardPopupClosing)
			{
				this.confirmPlayCardPopupClosing = true;
				if (this.isPopupWindowOpenAndClose(this.m_confirmPlayCardPopup) && this.getCardWindow() != null)
				{
					PlayCardsWindow playCardsWindow = (PlayCardsWindow)this.getCardWindow();
					playCardsWindow.reactivatePanel();
				}
				this.m_confirmPlayCardPopup = null;
				this.confirmPlayCardPopupClosing = false;
			}
		}

		// Token: 0x06001603 RID: 5635 RVA: 0x000175CC File Offset: 0x000157CC
		public ConfirmPlayCardPopup getConfirmPlayCardPopup()
		{
			return this.m_confirmPlayCardPopup;
		}

		// Token: 0x06001604 RID: 5636 RVA: 0x000175D4 File Offset: 0x000157D4
		public bool isConfirmPlayCardPopup()
		{
			return this.isPopupWindowOpen(this.m_confirmPlayCardPopup);
		}

		// Token: 0x06001605 RID: 5637 RVA: 0x000175E2 File Offset: 0x000157E2
		public void setCurrentTutorialArrowWindow(TutorialArrowWindow donatePopup)
		{
			this.m_currentTutorialArrowWindow = donatePopup;
		}

		// Token: 0x06001606 RID: 5638 RVA: 0x000175EB File Offset: 0x000157EB
		public void moveTutorialArrowWindow()
		{
			if (this.m_currentTutorialArrowWindow != null)
			{
				this.m_currentTutorialArrowWindow.move();
			}
		}

		// Token: 0x06001607 RID: 5639 RVA: 0x00017600 File Offset: 0x00015800
		public void closeTutorialArrowWindow()
		{
			if (this.isPopupWindowOpen(this.m_currentTutorialArrowWindow))
			{
				this.m_currentTutorialArrowWindow.Hide();
			}
		}

		// Token: 0x06001608 RID: 5640 RVA: 0x0001761B File Offset: 0x0001581B
		public bool isTutorialArrowWindowOpen()
		{
			return this.isPopupWindowOpen(this.m_currentTutorialArrowWindow);
		}

		// Token: 0x06001609 RID: 5641 RVA: 0x00017629 File Offset: 0x00015829
		public TutorialArrowWindow getTutorialArrowWindow()
		{
			return this.m_currentTutorialArrowWindow;
		}

		// Token: 0x0600160A RID: 5642 RVA: 0x00017631 File Offset: 0x00015831
		public void openAchievements(List<int> achievements)
		{
			this.closeMedalsPopup();
			this.medalsPopupPanel = new MedalsPopupWindow();
			this.medalsPopupPanel.init(achievements, this.ParentForm);
			this.medalsPopupPanel.Show(this.ParentForm);
		}

		// Token: 0x0600160B RID: 5643 RVA: 0x00017667 File Offset: 0x00015867
		public void closeMedalsPopup()
		{
			if (this.medalsPopupPanel != null)
			{
				this.medalsPopupPanel.Close();
				this.medalsPopupPanel = null;
			}
		}

		// Token: 0x0600160C RID: 5644 RVA: 0x0015F288 File Offset: 0x0015D488
		public void updatePopups()
		{
			if (this.isTutorialArrowWindowOpen())
			{
				TutorialArrowWindow.updateArrow();
			}
			bool flag = true;
			if (this.isPopupWindowCreated(this.m_playCardsWindow))
			{
				this.m_playCardsWindow.update();
				Form activeForm = Form.ActiveForm;
				if (Form.ActiveForm == this.ParentForm || (this.m_launchAttackPopup != null && Form.ActiveForm == this.m_launchAttackPopup))
				{
					this.m_playCardsWindow.Focus();
				}
				flag = false;
			}
			if (this.isPopupWindowCreated(this.m_launchAttackPopup))
			{
				this.m_launchAttackPopup.update();
				if (flag)
				{
					Form activeForm2 = Form.ActiveForm;
					if (Form.ActiveForm == this.ParentForm)
					{
						this.m_launchAttackPopup.Focus();
					}
					flag = false;
				}
			}
			if (this.isPopupWindowCreated(this.m_scoutPopupWindow))
			{
				this.m_scoutPopupWindow.update();
				if (flag)
				{
					Form activeForm3 = Form.ActiveForm;
					if (Form.ActiveForm == this.ParentForm || (this.m_launchAttackPopup != null && Form.ActiveForm == this.m_scoutPopupWindow))
					{
						this.m_scoutPopupWindow.Focus();
					}
					flag = false;
				}
			}
			if (this.isPopupWindowCreated(this.m_sendMonkWindow))
			{
				this.m_sendMonkWindow.update();
				if (flag)
				{
					Form activeForm4 = Form.ActiveForm;
					if (Form.ActiveForm == this.ParentForm || (this.m_launchAttackPopup != null && Form.ActiveForm == this.m_sendMonkWindow))
					{
						this.m_sendMonkWindow.Focus();
					}
					flag = false;
				}
			}
			if (this.isPopupWindowCreated(this.m_buyVillageWindow))
			{
				this.m_buyVillageWindow.update();
				if (flag)
				{
					Form activeForm5 = Form.ActiveForm;
					if (Form.ActiveForm == this.ParentForm)
					{
						this.m_buyVillageWindow.Focus();
					}
					flag = false;
				}
			}
			if (this.isPopupWindowCreated(this.m_connectionErrorWindow))
			{
				this.m_connectionErrorWindow.update();
				if (flag)
				{
					Form activeForm6 = Form.ActiveForm;
					if (Form.ActiveForm == this.ParentForm)
					{
						this.m_connectionErrorWindow.Focus();
					}
				}
			}
			if (this.isPopupWindowCreated(this.m_currentDonatePopup))
			{
				Form activeForm7 = Form.ActiveForm;
				if (Form.ActiveForm != this.m_currentDonatePopup)
				{
					this.closeDonatePopup();
				}
			}
			if (this.isPopupWindowCreated(this.m_logoutOptionsWindow))
			{
				this.m_logoutOptionsWindow.update();
				Form activeForm8 = Form.ActiveForm;
				if (Form.ActiveForm == this.ParentForm)
				{
					this.m_logoutOptionsWindow.Focus();
				}
			}
			if (this.isPopupWindowCreated(this.m_reportCapturePopup))
			{
				this.m_reportCapturePopup.update();
				Form activeForm9 = Form.ActiveForm;
				if (Form.ActiveForm == this.ParentForm)
				{
					this.m_reportCapturePopup.Focus();
				}
			}
			if (this.isPopupWindowCreated(this.m_newQuestRewardPopup))
			{
				this.m_newQuestRewardPopup.update();
				Form activeForm10 = Form.ActiveForm;
				if (Form.ActiveForm == this.ParentForm)
				{
					this.m_newQuestRewardPopup.Focus();
				}
			}
			if (this.isPopupWindowCreated(this.m_advancedCastleOptionsPopup))
			{
				this.m_advancedCastleOptionsPopup.update();
				Form activeForm11 = Form.ActiveForm;
				if (Form.ActiveForm == this.ParentForm)
				{
					this.m_advancedCastleOptionsPopup.Focus();
				}
			}
			if (this.isPopupWindowCreated(this.m_freeCardsPopup))
			{
				this.m_freeCardsPopup.update();
				Form activeForm12 = Form.ActiveForm;
				if (Form.ActiveForm == this.ParentForm)
				{
					this.m_freeCardsPopup.Focus();
				}
			}
			if (this.isPopupWindowCreated(this.m_WheelPopup))
			{
				this.m_WheelPopup.update();
				Form activeForm13 = Form.ActiveForm;
				if (Form.ActiveForm == this.ParentForm)
				{
					this.m_WheelPopup.Focus();
				}
			}
			if (this.isPopupWindowCreated(this.m_createPopupWindow))
			{
				this.m_createPopupWindow.update();
			}
			if (this.isPopupWindowCreated(this.m_VacationCancelPopupWindow))
			{
				this.m_VacationCancelPopupWindow.update();
			}
			if (this.isPopupWindowCreated(this.m_worldSelectPopupWindow))
			{
				this.m_worldSelectPopupWindow.update();
			}
			if (this.isPopupWindowCreated(this.m_BPPopupWindow))
			{
				this.m_BPPopupWindow.update();
			}
			if (this.isPopupWindowCreated(this.m_currentMenuPopup))
			{
				this.m_currentMenuPopup.update();
			}
			if (!this.isPopupWindowCreated(this.m_achievementPopup))
			{
				return;
			}
			this.m_achievementPopup.update();
			if (!this.m_achievementPopup.isActive())
			{
				this.m_achievementPopup.Hide();
				this.m_achievementPopup = null;
				if (this.nextAchievementIDs.Count > 0)
				{
					this.m_achievementPopup = new AchievementPopup();
					this.m_achievementPopup.activate(this.nextAchievementIDs[0]);
					this.nextAchievementIDs.RemoveAt(0);
				}
			}
		}

		// Token: 0x0600160D RID: 5645 RVA: 0x0015F6B8 File Offset: 0x0015D8B8
		public void closeAllPopups()
		{
			this.closeLaunchAttackPopup();
			this.closePlayCardsWindow();
			this.closeMenuPopup();
			this.closeCustomTooltip();
			this.closeTutorialWindow();
			this.closeAchievementPopup();
			this.closeScoutPopupWindow();
			this.closeSendMonkWindow();
			this.closeBuyVillagePopupWindow();
			this.closeDonatePopup();
			this.closeLogoutWindow();
			this.closeReportCaptureWindow();
			this.closeNewQuestRewardPopup();
			this.closeNewQuestsCompletedPopup();
			this.closeGloryVictoryWindowPopup();
			this.closeAdvancedCastleOptionsPopup();
			this.closeFreeCardsPopup();
			this.closeWheelPopup();
			this.closeWheelSelectPopup();
			this.closeConfirmPlayCardPopup();
			this.closeTutorialArrowWindow();
			this.closeMedalsPopup();
			this.closeConnectionErrorWindow();
			this.closeDominatonWindow();
			this.closeFormationPopup();
			this.closeAttackTargetsPopup();
			this.closeAdvicePopup();
		}

		// Token: 0x0600160E RID: 5646 RVA: 0x00017683 File Offset: 0x00015883
		private void closePopupWindow(Form window)
		{
			if (window != null && window.Created)
			{
				window.Close();
			}
		}

		// Token: 0x0600160F RID: 5647 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void positionWindow(CustomSelfDrawPanel window, bool dxCentre, bool needCreated)
		{
		}

		// Token: 0x06001610 RID: 5648 RVA: 0x0015F768 File Offset: 0x0015D968
		private void positionWindow(Form window, bool dxCentre, bool needCreated)
		{
			if (window != null && (window.Created || !needCreated))
			{
				if (!dxCentre)
				{
					Point location = this.parentMainWindow.Location;
					Size clientSize = this.parentMainWindow.ClientSize;
					int x = (clientSize.Width - window.Size.Width) / 2 + location.X + 4;
					int y = (clientSize.Height - window.Size.Height - 120) / 2 + 120 + location.Y + 16;
					window.Location = new Point(x, y);
					return;
				}
				Size size = this.parentMainWindow.getDXBasePanel().Size;
				Point point = this.parentMainWindow.getDXBasePanel().PointToScreen(new Point(0, 0));
				int x2 = (size.Width - window.Size.Width) / 2 + point.X;
				int y2 = (size.Height - window.Size.Height) / 2 + point.Y;
				window.Location = new Point(x2, y2);
			}
		}

		// Token: 0x06001611 RID: 5649 RVA: 0x00017696 File Offset: 0x00015896
		private bool isPopupWindowOpen(Form window)
		{
			return window != null && window.Created && window.Visible;
		}

		// Token: 0x06001612 RID: 5650 RVA: 0x000176AE File Offset: 0x000158AE
		private bool isPopupWindowCreated(Form window)
		{
			return window != null && window.Created;
		}

		// Token: 0x06001613 RID: 5651 RVA: 0x000176BE File Offset: 0x000158BE
		private bool isPopupWindowOpenAndClose(Form window)
		{
			if (window != null && window.Created)
			{
				window.Close();
				return true;
			}
			return false;
		}

		// Token: 0x06001614 RID: 5652 RVA: 0x0015F884 File Offset: 0x0015DA84
		public void processAchievements(List<int> achievements)
		{
			if (achievements == null)
			{
				RemoteServices.Instance.UserAchievements = new List<int>();
				return;
			}
			List<int> list = new List<int>();
			bool flag = false;
			foreach (int num in achievements)
			{
				if (num == -1)
				{
					flag = true;
				}
				else
				{
					if (flag)
					{
						this.activateAchievementPopup(num + 1000);
					}
					list.Add(num);
				}
			}
			RemoteServices.Instance.UserAchievements = list;
		}

		// Token: 0x06001615 RID: 5653 RVA: 0x000176D4 File Offset: 0x000158D4
		public void setFloatingValueSentDelegate(InterfaceMgr.FloatingValueSent del)
		{
			this.sendDelegate = del;
		}

		// Token: 0x06001616 RID: 5654 RVA: 0x000176DD File Offset: 0x000158DD
		public void setFloatingTextSentDelegate(InterfaceMgr.FloatingTextSent del)
		{
			this.sendTextDelegate = del;
		}

		// Token: 0x06001617 RID: 5655 RVA: 0x000176E6 File Offset: 0x000158E6
		public void closeTextInput(int inputValue)
		{
			this.m_floatingInputValue = inputValue;
			FloatingInput.close();
			if (this.sendDelegate != null)
			{
				this.sendDelegate(this.m_floatingInputValue);
				this.sendDelegate = null;
			}
		}

		// Token: 0x06001618 RID: 5656 RVA: 0x00017714 File Offset: 0x00015914
		public void closeTextStringInput(string inputValue)
		{
			this.m_floatingInputString = inputValue;
			FloatingInputText.close();
			if (this.sendTextDelegate != null)
			{
				this.sendTextDelegate(this.m_floatingInputString);
				this.sendTextDelegate = null;
			}
		}

		// Token: 0x06001619 RID: 5657 RVA: 0x00017742 File Offset: 0x00015942
		public void toggleDXCardBarActive(bool value)
		{
			this.cardBarDX.toggleEnabled(value);
		}

		// Token: 0x0600161A RID: 5658 RVA: 0x00017750 File Offset: 0x00015950
		public void showDXCardBar(int cardSection)
		{
			if (!DXPanel.skipPaint)
			{
				this.cardBarDX.init(cardSection);
				return;
			}
			this.cardBarDX.delayedInit(cardSection);
		}

		// Token: 0x0600161B RID: 5659 RVA: 0x00017772 File Offset: 0x00015972
		public void updateDXCardBar()
		{
			this.cardBarDX.update();
		}

		// Token: 0x0600161C RID: 5660 RVA: 0x0001777F File Offset: 0x0001597F
		public bool clickDXCardBar(Point mousePos)
		{
			return this.cardBarDX.click(mousePos);
		}

		// Token: 0x0600161D RID: 5661 RVA: 0x0001778D File Offset: 0x0001598D
		public void mouseMoveDXCardBar(Point mousePos)
		{
			this.cardBarDX.mouseMove(mousePos);
		}

		// Token: 0x0600161E RID: 5662 RVA: 0x0015F910 File Offset: 0x0015DB10
		public bool allowDrawCircles()
		{
			if (GameEngine.Instance.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_WORLD)
			{
				return true;
			}
			int selectedMenuVillage = this.getSelectedMenuVillage();
			return selectedMenuVillage >= 0 && GameEngine.Instance.World.isUserVillage(selectedMenuVillage) && !GameEngine.Instance.World.isCapital(selectedMenuVillage);
		}

		// Token: 0x0600161F RID: 5663 RVA: 0x0001779B File Offset: 0x0001599B
		public void togglePlaybackBarDXActive(bool value)
		{
			this.playbackBarDX.toggleEnabled(value);
			this.playbackEnabled = value;
			if (value)
			{
				this.showDXPlaybackBar();
			}
		}

		// Token: 0x06001620 RID: 5664 RVA: 0x000177B9 File Offset: 0x000159B9
		public void showDXPlaybackBar()
		{
			if (!DXPanel.skipPaint)
			{
				this.playbackBarDX.init();
				return;
			}
			this.playbackBarDX.delayedInit();
		}

		// Token: 0x06001621 RID: 5665 RVA: 0x000177D9 File Offset: 0x000159D9
		public void updateDXPlaybackBar()
		{
			this.playbackBarDX.update();
		}

		// Token: 0x06001622 RID: 5666 RVA: 0x000177E6 File Offset: 0x000159E6
		public bool clickDXPlaybackBar(Point mousePos)
		{
			return this.playbackBarDX.click(mousePos);
		}

		// Token: 0x06001623 RID: 5667 RVA: 0x000177F4 File Offset: 0x000159F4
		public bool mouseUpDXPlaybackBar(Point mousePos)
		{
			return this.playbackBarDX.mouseUp(mousePos);
		}

		// Token: 0x06001624 RID: 5668 RVA: 0x00017802 File Offset: 0x00015A02
		public bool mouseDownDXPlaybackBar(Point mousePos)
		{
			return this.playbackBarDX.mouseDown(mousePos);
		}

		// Token: 0x06001625 RID: 5669 RVA: 0x00017810 File Offset: 0x00015A10
		public void mouseMoveDXPlaybackBar(Point mousePos)
		{
			this.playbackBarDX.mouseMove(mousePos);
		}

		// Token: 0x040025E8 RID: 9704
		private const int MRHP_POS = 6;

		// Token: 0x040025E9 RID: 9705
		private const int OVERLAY_CONTEXT_HEIGHT = 28;

		// Token: 0x040025EA RID: 9706
		public static int UIScale = 1;

		// Token: 0x040025EB RID: 9707
		public static bool mouseDownOnDraggable = false;

		// Token: 0x040025EC RID: 9708
		private DateTime lastStopDrawTime = DateTime.MinValue;

		// Token: 0x040025ED RID: 9709
		public bool ignoreStopDraw;

		// Token: 0x040025EE RID: 9710
		private static InterfaceMgr instance = null;

		// Token: 0x040025EF RID: 9711
		private MainWindow parentMainWindow;

		// Token: 0x040025F0 RID: 9712
		private Form parentForm;

		// Token: 0x040025F1 RID: 9713
		private Size m_expandedMainSize;

		// Token: 0x040025F2 RID: 9714
		private int worldMapMode;

		// Token: 0x040025F3 RID: 9715
		private int stockExchangeBuyingVillage = -1;

		// Token: 0x040025F4 RID: 9716
		private int attackTargetHomeVillage = -1;

		// Token: 0x040025F5 RID: 9717
		private int vassalSelectHomeVillage = -1;

		// Token: 0x040025F6 RID: 9718
		private int monkSelectHomeVillage = -1;

		// Token: 0x040025F7 RID: 9719
		private int userInfoRefreshCountdown;

		// Token: 0x040025F8 RID: 9720
		private bool doUserInfoUpdate;

		// Token: 0x040025F9 RID: 9721
		private UserInfoPanel2 userInfoPanel = new UserInfoPanel2();

		// Token: 0x040025FA RID: 9722
		private EmptyVillagePanel2 emptyVillagePanel = new EmptyVillagePanel2();

		// Token: 0x040025FB RID: 9723
		private OwnVillagePanel2 ownVillagePanel = new OwnVillagePanel2();

		// Token: 0x040025FC RID: 9724
		private OtherVillagePanel2 otherVillagePanel = new OtherVillagePanel2();

		// Token: 0x040025FD RID: 9725
		private ParishCapitalVillagePanel2 parishCapitalVillagePanel = new ParishCapitalVillagePanel2();

		// Token: 0x040025FE RID: 9726
		private CountyCapitalVillagePanel2 countyCapitalVillagePanel = new CountyCapitalVillagePanel2();

		// Token: 0x040025FF RID: 9727
		private ProvinceCapitalVillagePanel2 provinceCapitalVillagePanel = new ProvinceCapitalVillagePanel2();

		// Token: 0x04002600 RID: 9728
		private CountryCapitalVillagePanel2 countryCapitalVillagePanel = new CountryCapitalVillagePanel2();

		// Token: 0x04002601 RID: 9729
		private OwnParishCapitalPanel2 ownParishCapitalPanel = new OwnParishCapitalPanel2();

		// Token: 0x04002602 RID: 9730
		private OwnCountyCapitalPanel2 ownCountyCapitalPanel = new OwnCountyCapitalPanel2();

		// Token: 0x04002603 RID: 9731
		private OwnProvinceCapitalPanel2 ownProvinceCapitalPanel = new OwnProvinceCapitalPanel2();

		// Token: 0x04002604 RID: 9732
		private OwnCountryCapitalPanel2 ownCountryCapitalPanel = new OwnCountryCapitalPanel2();

		// Token: 0x04002605 RID: 9733
		private VassalVillagePanel2 vassalVillagePanel = new VassalVillagePanel2();

		// Token: 0x04002606 RID: 9734
		private VassalAttackVillagePanel2 vassalAttackVillagePanel = new VassalAttackVillagePanel2();

		// Token: 0x04002607 RID: 9735
		private int m_reallySelectedVillage = -1;

		// Token: 0x04002608 RID: 9736
		private int m_touchscreenSelectedVillage = -1;

		// Token: 0x04002609 RID: 9737
		private int m_ownSelectedVillage = -1;

		// Token: 0x0400260A RID: 9738
		private int m_selectedVassalVillage = -1;

		// Token: 0x0400260B RID: 9739
		private int lastViewedVillage = -1;

		// Token: 0x0400260C RID: 9740
		private SelectArmyPanel2 selectArmyPanel = new SelectArmyPanel2();

		// Token: 0x0400260D RID: 9741
		public long MapSelectedArmy = -1L;

		// Token: 0x0400260E RID: 9742
		public long MapSelectedReinforcement = -1L;

		// Token: 0x0400260F RID: 9743
		private SelectReinforcementPanel2 selectReinforcementPanel = new SelectReinforcementPanel2();

		// Token: 0x04002610 RID: 9744
		private TradeWithPanel2 tradeWithPanel = new TradeWithPanel2();

		// Token: 0x04002611 RID: 9745
		private StockExchangeSidePanel2 stockExchangeSidePanel = new StockExchangeSidePanel2();

		// Token: 0x04002612 RID: 9746
		private AttackTargetSidePanel2 attackTargetSidePanel = new AttackTargetSidePanel2();

		// Token: 0x04002613 RID: 9747
		private ScoutTargetSidePanel2 scoutTargetSidePanel = new ScoutTargetSidePanel2();

		// Token: 0x04002614 RID: 9748
		private TraderInfoPanel2 traderInfoPanel = new TraderInfoPanel2();

		// Token: 0x04002615 RID: 9749
		public long MapSelectedTrader = -1L;

		// Token: 0x04002616 RID: 9750
		private PersonInfoPanel2 personInfoPanel = new PersonInfoPanel2();

		// Token: 0x04002617 RID: 9751
		public long MapSelectedPerson = -1L;

		// Token: 0x04002618 RID: 9752
		private ReinforcementTargetSidePanel2 reinforcementTargetSidePanel = new ReinforcementTargetSidePanel2();

		// Token: 0x04002619 RID: 9753
		private int courtierHomeVillage = -1;

		// Token: 0x0400261A RID: 9754
		private VassalSelectSidePanel2 vassalSelectSidePanel = new VassalSelectSidePanel2();

		// Token: 0x0400261B RID: 9755
		private MonkTargetSidePanel2 monkTargetSidePanel = new MonkTargetSidePanel2();

		// Token: 0x0400261C RID: 9756
		private VillageMapPanel villageMapPanel = new VillageMapPanel();

		// Token: 0x0400261D RID: 9757
		private VillageInfoBar2 villageInfoBar = new VillageInfoBar2();

		// Token: 0x0400261E RID: 9758
		private VillageReportBackgroundPanel villageReportBackgroundPanel = new VillageReportBackgroundPanel();

		// Token: 0x0400261F RID: 9759
		private int lastVillageTab = -1;

		// Token: 0x04002620 RID: 9760
		private bool firstVillageBackgroundCall = true;

		// Token: 0x04002621 RID: 9761
		private CastleMapPanel castleMapPanel = new CastleMapPanel();

		// Token: 0x04002622 RID: 9762
		private CastleInfoBar2 castleInfoBar = new CastleInfoBar2();

		// Token: 0x04002623 RID: 9763
		public bool WaitingForCallback;

		// Token: 0x04002624 RID: 9764
		private CastleMapAttackerSetupPanel castleMapAttackerSetupPanel = new CastleMapAttackerSetupPanel();

		// Token: 0x04002625 RID: 9765
		private CastleMapBattlePanel2 castleMapBattlePanel = new CastleMapBattlePanel2();

		// Token: 0x04002626 RID: 9766
		private UserInfoScreen userInfoScreen = new UserInfoScreen();

		// Token: 0x04002627 RID: 9767
		private MainWindowPanel mainWindowPanel = new MainWindowPanel();

		// Token: 0x04002628 RID: 9768
		public int SelectedResearchCategory;

		// Token: 0x04002629 RID: 9769
		private ResearchPanel researchPanel = new ResearchPanel();

		// Token: 0x0400262A RID: 9770
		private MailScreenPanel mailScreenManager = new MailScreenPanel();

		// Token: 0x0400262B RID: 9771
		private ChatScreenManager chatScreenManager = new ChatScreenManager();

		// Token: 0x0400262C RID: 9772
		private MapFilterSelectPanel mapFilterSelectPanel = new MapFilterSelectPanel();

		// Token: 0x0400262D RID: 9773
		private MapFilterPanel2 mapFilterPanel = new MapFilterPanel2();

		// Token: 0x0400262E RID: 9774
		public int ChildVillageID = -1;

		// Token: 0x0400262F RID: 9775
		private int m_selectedMenuVillage = -1;

		// Token: 0x04002630 RID: 9776
		private int m_forcedMenuVillage = -1;

		// Token: 0x04002631 RID: 9777
		public string CurrentVillageName = "";

		// Token: 0x04002632 RID: 9778
		public string CurrentVillageDescription = "";

		// Token: 0x04002633 RID: 9779
		public bool cameraCentredOnVillage = true;

		// Token: 0x04002634 RID: 9780
		private DateTime timeChangedToMode1 = DateTime.MinValue;

		// Token: 0x04002635 RID: 9781
		private int lastTimeChangedMode = -1;

		// Token: 0x04002636 RID: 9782
		private SendArmyWindow m_launchAttackPopup;

		// Token: 0x04002637 RID: 9783
		private bool launchAttackPopupClosing;

		// Token: 0x04002638 RID: 9784
		private CreatePopupWindow m_createPopupWindow;

		// Token: 0x04002639 RID: 9785
		private bool createPopupWindowClosing;

		// Token: 0x0400263A RID: 9786
		private WorldSelectPopupWindow m_worldSelectPopupWindow;

		// Token: 0x0400263B RID: 9787
		private bool worldSelectPopupWindowClosing;

		// Token: 0x0400263C RID: 9788
		private BPPopupWindow m_BPPopupWindow;

		// Token: 0x0400263D RID: 9789
		private bool BPPopupWindowClosing;

		// Token: 0x0400263E RID: 9790
		private VacationCancelPopupWindow m_VacationCancelPopupWindow;

		// Token: 0x0400263F RID: 9791
		private bool VacationCancelPopupWindowClosing;

		// Token: 0x04002640 RID: 9792
		private PlayCardsWindow m_playCardsWindow;

		// Token: 0x04002641 RID: 9793
		private bool playCardsWindowClosing;

		// Token: 0x04002642 RID: 9794
		private MenuPopup m_currentMenuPopup;

		// Token: 0x04002643 RID: 9795
		private DateTime m_menuPopupClosedLastTime = DateTime.MinValue;

		// Token: 0x04002644 RID: 9796
		private CustomTooltip m_currentCustomTooltip;

		// Token: 0x04002645 RID: 9797
		private TutorialWindow m_currentTutorialWindow;

		// Token: 0x04002646 RID: 9798
		private AchievementPopup m_achievementPopup;

		// Token: 0x04002647 RID: 9799
		private List<int> nextAchievementIDs = new List<int>();

		// Token: 0x04002648 RID: 9800
		private ScoutPopupWindow m_scoutPopupWindow;

		// Token: 0x04002649 RID: 9801
		private bool scoutPopupWindowClosing;

		// Token: 0x0400264A RID: 9802
		private SendMonkWindow m_sendMonkWindow;

		// Token: 0x0400264B RID: 9803
		private bool sendMonkWindowClosing;

		// Token: 0x0400264C RID: 9804
		private BuyVillagePopupWindow m_buyVillageWindow;

		// Token: 0x0400264D RID: 9805
		private bool buyVillageWindowClosing;

		// Token: 0x0400264E RID: 9806
		private ConnectionErrorWindow m_connectionErrorWindow;

		// Token: 0x0400264F RID: 9807
		private bool connectionErrorWindowClosing;

		// Token: 0x04002650 RID: 9808
		private GreyOutWindow m_greyOutWindow;

		// Token: 0x04002651 RID: 9809
		private bool m_greyLogin;

		// Token: 0x04002652 RID: 9810
		private DonatePopup m_currentDonatePopup;

		// Token: 0x04002653 RID: 9811
		private LogoutOptionsWindow2 m_logoutOptionsWindow;

		// Token: 0x04002654 RID: 9812
		private bool logoutWindowClosing;

		// Token: 0x04002655 RID: 9813
		private ReportCapturePopup m_reportCapturePopup;

		// Token: 0x04002656 RID: 9814
		private bool reportCaptureWindowClosing;

		// Token: 0x04002657 RID: 9815
		private NewQuestRewardPopup m_newQuestRewardPopup;

		// Token: 0x04002658 RID: 9816
		private bool newQuestRewardPopupClosing;

		// Token: 0x04002659 RID: 9817
		private NewQuestsCompletedWindow newQuestsCompletedWindow;

		// Token: 0x0400265A RID: 9818
		private GloryVictoryWindow gloryVictoryWindow;

		// Token: 0x0400265B RID: 9819
		private AdvancedCastleOptionsPopup m_advancedCastleOptionsPopup;

		// Token: 0x0400265C RID: 9820
		private bool advancedCastleOptionsPopupClosing;

		// Token: 0x0400265D RID: 9821
		private FormationPopup m_formationPopup;

		// Token: 0x0400265E RID: 9822
		private bool formationPopupClosing;

		// Token: 0x0400265F RID: 9823
		private PresetPopup m_presetPopup;

		// Token: 0x04002660 RID: 9824
		private bool presetPopupClosing;

		// Token: 0x04002661 RID: 9825
		private AttackTargetsPopup m_AttackTargetsPopup;

		// Token: 0x04002662 RID: 9826
		private bool AttackTargetsPopupClosing;

		// Token: 0x04002663 RID: 9827
		private FreeCardsPopup m_freeCardsPopup;

		// Token: 0x04002664 RID: 9828
		private bool freeCardsPopupClosing;

		// Token: 0x04002665 RID: 9829
		private WheelPopup m_WheelPopup;

		// Token: 0x04002666 RID: 9830
		private bool WheelPopupClosing;

		// Token: 0x04002667 RID: 9831
		private WheelSelectPopup m_WheelSelectPopup;

		// Token: 0x04002668 RID: 9832
		private bool WheelSelectPopupClosing;

		// Token: 0x04002669 RID: 9833
		private DominationWindow dominationWindow;

		// Token: 0x0400266A RID: 9834
		private AdvicePopup advicePopup;

		// Token: 0x0400266B RID: 9835
		public int OpenPackMultiple;

		// Token: 0x0400266C RID: 9836
		private ConfirmOpenPackPopup m_confirmOpenPackPopup;

		// Token: 0x0400266D RID: 9837
		private bool confirmOpenPackPopupClosing;

		// Token: 0x0400266E RID: 9838
		public int BuyOfferMultiple;

		// Token: 0x0400266F RID: 9839
		private ConfirmBuyOfferPopup m_confirmBuyOfferPopup;

		// Token: 0x04002670 RID: 9840
		private bool confirmBuyOfferPopupClosing;

		// Token: 0x04002671 RID: 9841
		private ConfirmPlayCardPopup m_confirmPlayCardPopup;

		// Token: 0x04002672 RID: 9842
		private bool confirmPlayCardPopupClosing;

		// Token: 0x04002673 RID: 9843
		private TutorialArrowWindow m_currentTutorialArrowWindow;

		// Token: 0x04002674 RID: 9844
		private MedalsPopupWindow medalsPopupPanel;

		// Token: 0x04002675 RID: 9845
		public List<int> newAchievements = new List<int>();

		// Token: 0x04002676 RID: 9846
		private int m_floatingInputValue;

		// Token: 0x04002677 RID: 9847
		private string m_floatingInputString = "";

		// Token: 0x04002678 RID: 9848
		private InterfaceMgr.FloatingValueSent sendDelegate;

		// Token: 0x04002679 RID: 9849
		private InterfaceMgr.FloatingTextSent sendTextDelegate;

		// Token: 0x0400267A RID: 9850
		private CardBarDX cardBarDX = new CardBarDX();

		// Token: 0x0400267B RID: 9851
		private PlaybackBarDX playbackBarDX = new PlaybackBarDX();

		// Token: 0x0400267C RID: 9852
		public bool playbackEnabled;

		// Token: 0x02000209 RID: 521
		// (Invoke) Token: 0x06001629 RID: 5673
		public delegate void FloatingValueSent(int value);

		// Token: 0x0200020A RID: 522
		// (Invoke) Token: 0x0600162D RID: 5677
		public delegate void FloatingTextSent(string text);
	}
}
