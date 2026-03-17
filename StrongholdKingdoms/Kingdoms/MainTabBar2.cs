using System;
using System.Drawing;
using CommonTypes;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x0200022F RID: 559
	public class MainTabBar2 : CustomSelfDrawPanel.CSDControl
	{
		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x06001852 RID: 6226 RVA: 0x0001921E File Offset: 0x0001741E
		// (set) Token: 0x06001853 RID: 6227 RVA: 0x00019225 File Offset: 0x00017425
		public static int DummyMode
		{
			get
			{
				return MainTabBar2.dummyMode;
			}
			set
			{
				MainTabBar2.dummyMode = value;
			}
		}

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x06001854 RID: 6228 RVA: 0x0001922D File Offset: 0x0001742D
		// (set) Token: 0x06001855 RID: 6229 RVA: 0x00019234 File Offset: 0x00017434
		public static int LastDummyMode
		{
			get
			{
				return MainTabBar2.lastDummyMode;
			}
			set
			{
				MainTabBar2.lastDummyMode = value;
			}
		}

		// Token: 0x06001856 RID: 6230 RVA: 0x00180FF8 File Offset: 0x0017F1F8
		public MainTabBar2()
		{
			this.lastNewMail = false;
			this.lastNewReports = false;
			this.lastNewQuests = false;
			this.lastAttacks = 0;
			this.lastWidth = -1;
			this.refresh = false;
		}

		// Token: 0x06001857 RID: 6231 RVA: 0x0018105C File Offset: 0x0017F25C
		public void init()
		{
			this.clearControls();
			this.tabControl1.Position = new Point(0, 3);
			base.addControl(this.tabControl1);
			this.initImages();
			int num = this.tabControl1.Create(10, this.images);
			this.tabControl1.setCallback(0, new CustomSelfDrawPanel.CSDTabControl.TabClickedCallback(this.tabPage1_Enter), 22);
			this.tabControl1.setCallback(1, new CustomSelfDrawPanel.CSDTabControl.TabClickedCallback(this.tabPage2_Enter), 23);
			this.tabControl1.setCallback(2, new CustomSelfDrawPanel.CSDTabControl.TabClickedCallback(this.tabPage3_Enter), 32);
			this.tabControl1.setCallback(3, new CustomSelfDrawPanel.CSDTabControl.TabClickedCallback(this.tabPage4_Enter), 24);
			this.tabControl1.setCallback(4, new CustomSelfDrawPanel.CSDTabControl.TabClickedCallback(this.tabPage5_Enter), 25);
			this.tabControl1.setCallback(5, new CustomSelfDrawPanel.CSDTabControl.TabClickedCallback(this.tabPage6_Enter), 31);
			this.tabControl1.setCallback(6, new CustomSelfDrawPanel.CSDTabControl.TabClickedCallback(this.tabPage7_Enter), 26);
			this.tabControl1.setCallback(7, new CustomSelfDrawPanel.CSDTabControl.TabClickedCallback(this.tabPage8_Enter), 27);
			this.tabControl1.setCallback(8, new CustomSelfDrawPanel.CSDTabControl.TabClickedCallback(this.tabPage9_Enter), 30);
			this.tabControl1.setCallback(9, new CustomSelfDrawPanel.CSDTabControl.TabClickedCallback(this.tabPage10_Enter), 0);
			this.tabControl1.setSoundCallback(new CustomSelfDrawPanel.CSDTabControl.TabClickedCallback(this.tabControl1_Click));
			if (num > 0)
			{
				this.Size = new Size(num, this.images[0].Height);
				this.tabControl1.Size = new Size(num, this.images[0].Height);
			}
		}

		// Token: 0x06001858 RID: 6232 RVA: 0x00181200 File Offset: 0x0017F400
		public void initImages()
		{
			if (this.images == null)
			{
				this.images = new BaseImage[18];
				this.images[0] = GFXLibrary.tab_world_normal;
				this.images[1] = GFXLibrary.tab_world_selected;
				this.images[2] = GFXLibrary.tab_village_normal;
				this.images[3] = GFXLibrary.tab_village_selected;
				this.images[4] = GFXLibrary.tab_capital_normal;
				this.images[5] = GFXLibrary.tab_capital_selected;
				this.images[6] = GFXLibrary.tab_3_normal;
				this.images[7] = GFXLibrary.tab_3_selected;
				this.images[8] = GFXLibrary.tab_4_normal;
				this.images[9] = GFXLibrary.tab_4_selected;
				this.images[10] = GFXLibrary.tab_quest_normal;
				this.images[11] = GFXLibrary.tab_quest_selected;
				this.images[12] = GFXLibrary.tab_5_normal;
				this.images[13] = GFXLibrary.tab_5_selected;
				this.images[14] = GFXLibrary.tab_6_normal;
				this.images[15] = GFXLibrary.tab_6_selected;
				this.images[16] = GFXLibrary.tab_9_normal;
				this.images[17] = GFXLibrary.tab_9_selected;
			}
		}

		// Token: 0x06001859 RID: 6233 RVA: 0x00181318 File Offset: 0x0017F518
		public void update()
		{
			if (GameEngine.Instance.World.WorldEnded)
			{
				this.lastNewQuests = false;
			}
			this.alphaPulse += 20;
			if (this.alphaPulse > 511)
			{
				this.alphaPulse -= 511;
			}
			int num = this.alphaPulse;
			if (num > 255)
			{
				num = 511 - num;
			}
			if (this.lastNewReports)
			{
				this.refresh = true;
				this.tabControl1.setOverlayAlpha(7, num);
			}
			if (this.lastNewMail)
			{
				InterfaceMgr.Instance.getMainMenuBar().setMailAlpha((double)num / 255.0);
			}
			if (this.lastArmyFlashing)
			{
				this.refresh = true;
				this.tabControl1.setOverlayAlpha(6, num);
			}
			if (this.lastNewQuests)
			{
				this.refresh = true;
				this.tabControl1.setOverlayAlpha(5, num);
			}
			double currentHonour = GameEngine.Instance.World.getCurrentHonour();
			int rank = GameEngine.Instance.World.getRank();
			int rankSubLevel = GameEngine.Instance.World.getRankSubLevel();
			int num2 = GameEngine.Instance.LocalWorldData.ranks_HonourPerLevel[rank];
			if (rank != 21)
			{
				if (rank == 22)
				{
					num2 = (int)Rankings.calcHonourForCrownPrince(rankSubLevel);
				}
			}
			else if (rankSubLevel >= 24)
			{
				num2 = 10000000;
			}
			int num3 = GameEngine.Instance.LocalWorldData.ranks_Levels[rank];
			if (currentHonour >= (double)num2)
			{
				if (this.images[8] != GFXLibrary.tab_4b_normal)
				{
					this.images[8] = GFXLibrary.tab_4b_normal;
					this.images[9] = GFXLibrary.tab_4b_selected;
					this.tabControl1.updateImageArray(this.images);
				}
			}
			else if (this.images[8] != GFXLibrary.tab_4_normal)
			{
				this.images[8] = GFXLibrary.tab_4_normal;
				this.images[9] = GFXLibrary.tab_4_selected;
				this.tabControl1.updateImageArray(this.images);
			}
			if (this.refresh)
			{
				this.refresh = false;
			}
			if (this.lastTab == 1)
			{
				InterfaceMgr.Instance.getTopRightMenu().getVillageTabBar().updateAlert();
			}
		}

		// Token: 0x0600185A RID: 6234 RVA: 0x0018151C File Offset: 0x0017F71C
		public void newReports(bool newReport)
		{
			if (newReport)
			{
				this.images[14] = GFXLibrary.tab_6B_normal;
				this.tabControl1.addOverlayImages(7, GFXLibrary.tab_6B_normal_bright, null, 255);
				this.tabControl1.updateImageArray(this.images);
			}
			else
			{
				this.images[14] = GFXLibrary.tab_6_normal;
				this.tabControl1.addOverlayImages(7, null, null, 255);
				this.tabControl1.updateImageArray(this.images);
			}
			if (this.lastNewReports != newReport)
			{
				this.refresh = true;
			}
			this.lastNewReports = newReport;
		}

		// Token: 0x0600185B RID: 6235 RVA: 0x001815B0 File Offset: 0x0017F7B0
		public void newQuestsCompleted(bool newQuests)
		{
			if (!GameEngine.Instance.World.WorldEnded)
			{
				if (newQuests && GameEngine.Instance.World.isTutorialActive())
				{
					newQuests = false;
				}
				if (newQuests)
				{
					this.images[10] = GFXLibrary.tab_quest_normal;
					this.tabControl1.addOverlayImages(5, GFXLibrary.tab_quest_glow, null, 255);
					this.tabControl1.updateImageArray(this.images);
				}
				else
				{
					this.images[10] = GFXLibrary.tab_quest_normal;
					this.tabControl1.addOverlayImages(5, null, null, 255);
					this.tabControl1.updateImageArray(this.images);
				}
				if (this.lastNewQuests != newQuests)
				{
					this.refresh = true;
				}
				this.lastNewQuests = newQuests;
			}
		}

		// Token: 0x0600185C RID: 6236 RVA: 0x0001923C File Offset: 0x0001743C
		public void newMail(bool newMail)
		{
			InterfaceMgr.Instance.getMainMenuBar().newMail(newMail);
			if (this.lastNewMail != newMail)
			{
				this.refresh = true;
			}
			this.lastNewMail = newMail;
		}

		// Token: 0x0600185D RID: 6237 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void newPoliticsPost(bool newPost)
		{
		}

		// Token: 0x0600185E RID: 6238 RVA: 0x0018166C File Offset: 0x0017F86C
		public void incomingAttacks(int numAttacks, long highestArmyID)
		{
			if (numAttacks > 0)
			{
				this.images[12] = GFXLibrary.tab_5b_normal;
				this.images[13] = GFXLibrary.tab_5b_selected;
				this.tabControl1.setTabText(6, numAttacks.ToString());
			}
			else
			{
				this.images[12] = GFXLibrary.tab_5_normal;
				this.images[13] = GFXLibrary.tab_5_selected;
				this.tabControl1.setTabText(6, "");
			}
			this.tabControl1.updateImageArray(this.images);
			long highestArmyIDSeen = GameEngine.Instance.World.HighestArmyIDSeen;
			bool flag = false;
			if (highestArmyID > highestArmyIDSeen && numAttacks > 0)
			{
				this.tabControl1.addOverlayImages(6, GFXLibrary.tab_5b_normal_bright, GFXLibrary.tab_5b_selected_bright, 255);
				flag = true;
			}
			else
			{
				this.tabControl1.addOverlayImages(6, null, null, 255);
			}
			if (this.lastAttacks != numAttacks)
			{
				this.refresh = true;
			}
			if (this.lastArmyFlashing != flag)
			{
				this.refresh = true;
			}
			this.lastAttacks = numAttacks;
			this.lastArmyFlashing = flag;
		}

		// Token: 0x0600185F RID: 6239 RVA: 0x00019265 File Offset: 0x00017465
		public bool isArmiesFlashing()
		{
			return this.lastArmyFlashing;
		}

		// Token: 0x06001860 RID: 6240 RVA: 0x00181768 File Offset: 0x0017F968
		public void updateResearchTime(ResearchData data)
		{
			int num = -1;
			if (data != null && data.researchingType >= 0)
			{
				DateTime currentServerTime = VillageMap.getCurrentServerTime();
				int num2 = (int)(data.research_completionTime - currentServerTime).TotalSeconds;
				TimeSpan timeSpan = data.calcResearchTime(data.research_pointCount - 1, GameEngine.Instance.cardsManager.UserCardData, GameEngine.Instance.LocalWorldData);
				if (GameEngine.Instance.LocalWorldData.Alternate_Ruleset == 1)
				{
					timeSpan = new TimeSpan(timeSpan.Ticks / 2L);
				}
				int num3 = (int)timeSpan.TotalSeconds;
				if (num3 < 1)
				{
					num3 = 1;
				}
				if (num3 == 30 && GameEngine.Instance.World.getTutorialStage() == 5)
				{
					num3 = 11;
				}
				this.images[6] = GFXLibrary.tab_3b_normal;
				this.images[7] = GFXLibrary.tab_3b_selected;
				this.tabControl1.addOverlayImages(3, GFXLibrary.tab_3c_normal, GFXLibrary.tab_3c_selected, 255);
				num = 3 + 44 * (num3 - num2) / num3;
				this.tabControl1.setOverlayWidth(3, num);
				this.refresh = true;
			}
			else
			{
				this.images[6] = GFXLibrary.tab_3_normal;
				this.images[7] = GFXLibrary.tab_3_selected;
				this.tabControl1.addOverlayImages(3, null, null, 255);
			}
			this.tabControl1.updateImageArray(this.images);
			if (num != this.lastWidth)
			{
				this.refresh = true;
			}
			this.lastWidth = num;
		}

		// Token: 0x06001861 RID: 6241 RVA: 0x0001926D File Offset: 0x0001746D
		public void selectDummyTab(int mode)
		{
			GameEngine.Instance.ResetVillageIfChangedFromCapital();
			MainTabBar2.dummyMode = mode;
			if (this.tabControl1.SelectedIndex == 9)
			{
				this.tabChangeCallback(9);
				return;
			}
			this.tabControl1.SelectedIndex = 9;
		}

		// Token: 0x06001862 RID: 6242 RVA: 0x000192A9 File Offset: 0x000174A9
		public void selectDummyTabFast(int mode)
		{
			MainTabBar2.dummyMode = mode;
			if (this.tabControl1.SelectedIndex == 9)
			{
				this.tabChangeCallback(9);
				return;
			}
			this.tabControl1.SelectedIndex = 9;
		}

		// Token: 0x06001863 RID: 6243 RVA: 0x000192DB File Offset: 0x000174DB
		public void registerTabChangeCallback(MainTabBar2.TabChangeCallback newTabChangeCallback)
		{
			this.tabChangeCallback = newTabChangeCallback;
		}

		// Token: 0x06001864 RID: 6244 RVA: 0x001818CC File Offset: 0x0017FACC
		public void tabPage1_Enter()
		{
			if (this.lastTab != 0 && !this.ignore)
			{
				GFXLibrary.Instance.changeView(GFXLibrary.getPanelDescFromID(201));
				this.lastTab = 0;
				GameEngine.Instance.ResetVillageIfChangedFromCapital();
				this.tabChangeCallback(0);
			}
		}

		// Token: 0x06001865 RID: 6245 RVA: 0x0018191C File Offset: 0x0017FB1C
		private void tabPage2_Enter()
		{
			if (this.lastTab != 1 && !this.ignore)
			{
				GFXLibrary.Instance.changeView(GFXLibrary.getPanelDescFromID(202));
				this.lastTab = 1;
				GameEngine.Instance.forceResetVillageIfChangedFromCapital();
				this.tabChangeCallback(1);
			}
		}

		// Token: 0x06001866 RID: 6246 RVA: 0x000192E4 File Offset: 0x000174E4
		private void tabPage3_Enter()
		{
			if (this.lastTab != 2 && !this.ignore)
			{
				GFXLibrary.Instance.changeView(GFXLibrary.getPanelDescFromID(203));
				this.lastTab = 2;
				this.tabChangeCallback(2);
			}
		}

		// Token: 0x06001867 RID: 6247 RVA: 0x0018196C File Offset: 0x0017FB6C
		private void tabPage4_Enter()
		{
			if (this.lastTab != 3 && !this.ignore)
			{
				GFXLibrary.Instance.changeView(GFXLibrary.getPanelDescFromID(204));
				this.lastTab = 3;
				GameEngine.Instance.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_TEMP_DUMMY;
				GameEngine.Instance.ResetVillageIfChangedFromCapital();
				this.tabChangeCallback(3);
			}
		}

		// Token: 0x06001868 RID: 6248 RVA: 0x001819C8 File Offset: 0x0017FBC8
		public void tabPage5_Enter()
		{
			if (this.lastTab != 4 && !this.ignore)
			{
				GFXLibrary.Instance.changeView(GFXLibrary.getPanelDescFromID(205));
				this.lastTab = 4;
				GameEngine.Instance.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_TEMP_DUMMY;
				GameEngine.Instance.ResetVillageIfChangedFromCapital();
				this.tabChangeCallback(4);
			}
		}

		// Token: 0x06001869 RID: 6249 RVA: 0x00181A24 File Offset: 0x0017FC24
		private void tabPage6_Enter()
		{
			if (this.lastTab != 5 && !this.ignore)
			{
				GFXLibrary.Instance.changeView(GFXLibrary.getPanelDescFromID(206));
				this.lastTab = 5;
				GameEngine.Instance.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_TEMP_DUMMY;
				GameEngine.Instance.ResetVillageIfChangedFromCapital();
				this.tabChangeCallback(5);
			}
		}

		// Token: 0x0600186A RID: 6250 RVA: 0x00181A80 File Offset: 0x0017FC80
		private void tabPage7_Enter()
		{
			if (this.lastTab != 6 && !this.ignore)
			{
				GFXLibrary.Instance.changeView(GFXLibrary.getPanelDescFromID(207));
				this.lastTab = 6;
				GameEngine.Instance.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_TEMP_DUMMY;
				GameEngine.Instance.ResetVillageIfChangedFromCapital();
				this.tabChangeCallback(6);
			}
		}

		// Token: 0x0600186B RID: 6251 RVA: 0x00181ADC File Offset: 0x0017FCDC
		private void tabPage8_Enter()
		{
			if (this.lastTab != 7 && !this.ignore)
			{
				GFXLibrary.Instance.changeView(GFXLibrary.getPanelDescFromID(208));
				this.lastTab = 7;
				GameEngine.Instance.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_TEMP_DUMMY;
				GameEngine.Instance.ResetVillageIfChangedFromCapital();
				this.tabChangeCallback(7);
				this.newReports(false);
			}
		}

		// Token: 0x0600186C RID: 6252 RVA: 0x00181B40 File Offset: 0x0017FD40
		private void tabPage9_Enter()
		{
			if (this.lastTab != 8 && !this.ignore)
			{
				GFXLibrary.Instance.changeView(GFXLibrary.getPanelDescFromID(209));
				this.lastTab = 8;
				GameEngine.Instance.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_TEMP_DUMMY;
				GameEngine.Instance.ResetVillageIfChangedFromCapital();
				this.tabChangeCallback(8);
			}
		}

		// Token: 0x0600186D RID: 6253 RVA: 0x00181B9C File Offset: 0x0017FD9C
		private void tabPage10_Enter()
		{
			if (this.lastTab != 9 && !this.ignore)
			{
				GFXLibrary.Instance.changeView(GFXLibrary.getPanelDescFromID(210));
				this.lastTab = 9;
				GameEngine.Instance.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_TEMP_DUMMY;
				GameEngine.Instance.ResetVillageIfChangedFromCapital();
				this.tabChangeCallback(9);
			}
		}

		// Token: 0x0600186E RID: 6254 RVA: 0x0001931E File Offset: 0x0001751E
		public int getCurrentTab()
		{
			return this.lastTab;
		}

		// Token: 0x0600186F RID: 6255 RVA: 0x00181BFC File Offset: 0x0017FDFC
		public void changeTab(int tabID)
		{
			this.lastSoundTab = tabID;
			this.ignore = true;
			if (tabID == 0)
			{
				this.tabControl1.SelectedIndex = 0;
				this.tabControl1.SelectedIndex = 1;
			}
			else
			{
				this.tabControl1.SelectedIndex = 1;
				this.tabControl1.SelectedIndex = 0;
			}
			this.ignore = false;
			this.lastTab = tabID + 1;
			this.tabControl1.SelectedIndex = tabID;
		}

		// Token: 0x06001870 RID: 6256 RVA: 0x00019326 File Offset: 0x00017526
		public void changeTabGfxOnly(int tabID)
		{
			this.lastSoundTab = tabID;
			this.ignore = true;
			this.lastTab = tabID;
			this.tabControl1.SelectedIndex = tabID;
			this.ignore = false;
		}

		// Token: 0x06001871 RID: 6257 RVA: 0x00019350 File Offset: 0x00017550
		public void changeTabRight()
		{
			if (this.tabControl1.SelectedIndex >= 5)
			{
				this.changeTab(3);
				return;
			}
			this.changeTab(this.tabControl1.SelectedIndex + 1);
		}

		// Token: 0x06001872 RID: 6258 RVA: 0x0001937B File Offset: 0x0001757B
		public void changeTabLeft()
		{
			if (this.tabControl1.SelectedIndex <= 3)
			{
				this.changeTab(5);
				return;
			}
			this.changeTab(this.tabControl1.SelectedIndex - 1);
		}

		// Token: 0x06001873 RID: 6259 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void tabPage1_Leave(object sender, EventArgs e)
		{
		}

		// Token: 0x06001874 RID: 6260 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void tabPage2_Leave(object sender, EventArgs e)
		{
		}

		// Token: 0x06001875 RID: 6261 RVA: 0x00181C68 File Offset: 0x0017FE68
		private void tabControl1_Click()
		{
			if (this.lastSoundTab != this.lastTab)
			{
				this.lastSoundTab = this.lastTab;
				GameEngine.Instance.playInterfaceSound("WorldMapScreen_main_tabbar_item_clicked");
				Sound.playDelayedInterfaceSound("WorldMapScreen_main_tabbar_item_clicked_" + this.lastTab.ToString(), 100);
			}
		}

		// Token: 0x040028D9 RID: 10457
		private MainTabBar2.TabChangeCallback tabChangeCallback;

		// Token: 0x040028DA RID: 10458
		private bool lastNewMail;

		// Token: 0x040028DB RID: 10459
		private bool lastNewReports;

		// Token: 0x040028DC RID: 10460
		private bool lastArmyFlashing;

		// Token: 0x040028DD RID: 10461
		private bool lastNewQuests;

		// Token: 0x040028DE RID: 10462
		private int lastAttacks;

		// Token: 0x040028DF RID: 10463
		private int lastWidth;

		// Token: 0x040028E0 RID: 10464
		private BaseImage[] images;

		// Token: 0x040028E1 RID: 10465
		private CustomSelfDrawPanel.CSDTabControl tabControl1 = new CustomSelfDrawPanel.CSDTabControl();

		// Token: 0x040028E2 RID: 10466
		private bool refresh;

		// Token: 0x040028E3 RID: 10467
		private int alphaPulse = 255;

		// Token: 0x040028E4 RID: 10468
		private static int dummyMode;

		// Token: 0x040028E5 RID: 10469
		private static int lastDummyMode;

		// Token: 0x040028E6 RID: 10470
		private bool ignore;

		// Token: 0x040028E7 RID: 10471
		private int lastTab = -1;

		// Token: 0x040028E8 RID: 10472
		private int lastSoundTab = -2;

		// Token: 0x02000230 RID: 560
		// (Invoke) Token: 0x06001877 RID: 6263
		public delegate void TabChangeCallback(int tabID);
	}
}
