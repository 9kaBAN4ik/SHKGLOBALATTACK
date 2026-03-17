using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;
using StatTracking;
using Upgrade;
using Upgrade.Services;

namespace Kingdoms
{
	// Token: 0x020001DF RID: 479
	public class GameEngine
	{
		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06001230 RID: 4656 RVA: 0x00013BA5 File Offset: 0x00011DA5
		public GraphicsMgr GFX
		{
			get
			{
				return this.gfx;
			}
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06001231 RID: 4657 RVA: 0x00013BAD File Offset: 0x00011DAD
		public VillageMap Village
		{
			get
			{
				return this.village;
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06001232 RID: 4658 RVA: 0x00013BB5 File Offset: 0x00011DB5
		public CastleMapRendering castleMapRendering
		{
			get
			{
				if (this.m_castleMapRendering == null)
				{
					this.m_castleMapRendering = new CastleMapRendering(this.gfx);
				}
				return this.m_castleMapRendering;
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06001233 RID: 4659 RVA: 0x00013BD6 File Offset: 0x00011DD6
		public CastleMap Castle
		{
			get
			{
				return this.castle;
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06001234 RID: 4660 RVA: 0x00013BDE File Offset: 0x00011DDE
		public CastleMap CastleAttackerSetup
		{
			get
			{
				return this.castle_AttackerSetup;
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x06001235 RID: 4661 RVA: 0x00013BE6 File Offset: 0x00011DE6
		public CastleMap CastleBattle
		{
			get
			{
				return this.castle_Battle;
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x06001236 RID: 4662 RVA: 0x00013BEE File Offset: 0x00011DEE
		public CastleMap CastlePreview
		{
			get
			{
				return this.castle_Preview;
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06001237 RID: 4663 RVA: 0x00013BF6 File Offset: 0x00011DF6
		public WorldMap World
		{
			get
			{
				return this.world;
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06001238 RID: 4664 RVA: 0x00013BFE File Offset: 0x00011DFE
		public WorldData LocalWorldData
		{
			get
			{
				return this.worldData;
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06001239 RID: 4665 RVA: 0x00013C06 File Offset: 0x00011E06
		public PremiumTokenManager premiumTokenManager
		{
			get
			{
				return this.m_premiumTokenManager;
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x0600123A RID: 4666 RVA: 0x00013C0E File Offset: 0x00011E0E
		public CardsManager cardsManager
		{
			get
			{
				return this.m_cardsManager;
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x0600123B RID: 4667 RVA: 0x00013C16 File Offset: 0x00011E16
		public CardPackManager cardPackManager
		{
			get
			{
				return this.m_cardPackManager;
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x0600123C RID: 4668 RVA: 0x00013C1E File Offset: 0x00011E1E
		public MonksManager monksManager
		{
			get
			{
				return this.m_monksManager;
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x0600123D RID: 4669 RVA: 0x00013C26 File Offset: 0x00011E26
		public VassalsManager vassalsManager
		{
			get
			{
				return this.m_vassalsManager;
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x0600123E RID: 4670 RVA: 0x00013C2E File Offset: 0x00011E2E
		public HouseManager houseManager
		{
			get
			{
				return this.m_houseManager;
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x0600123F RID: 4671 RVA: 0x00013C36 File Offset: 0x00011E36
		public FactionManager factionManager
		{
			get
			{
				return this.m_factionManager;
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06001240 RID: 4672 RVA: 0x00013C3E File Offset: 0x00011E3E
		public Audio AudioEngine
		{
			get
			{
				return this.audio;
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06001241 RID: 4673 RVA: 0x00013C46 File Offset: 0x00011E46
		public WorldMapTypes WorldMapTypesData
		{
			get
			{
				return this.worldMapTypesData;
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06001242 RID: 4674 RVA: 0x00013C4E File Offset: 0x00011E4E
		public int NewResolution
		{
			get
			{
				return this.newResolution;
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06001243 RID: 4675 RVA: 0x00013C56 File Offset: 0x00011E56
		public int CurrentResolution
		{
			get
			{
				if (InterfaceMgr.Instance.ParentForm.Height < 960)
				{
					return 0;
				}
				return 1;
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x06001244 RID: 4676 RVA: 0x00013C71 File Offset: 0x00011E71
		public int MaxResolution
		{
			get
			{
				return this.maxResolution;
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06001245 RID: 4677 RVA: 0x00013C79 File Offset: 0x00011E79
		// (set) Token: 0x06001246 RID: 4678 RVA: 0x00013C81 File Offset: 0x00011E81
		public bool WindowActive
		{
			get
			{
				return this.windowActive;
			}
			set
			{
				this.windowActive = value;
				this.gfx.WindowActive = value;
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06001247 RID: 4679 RVA: 0x00013C96 File Offset: 0x00011E96
		// (set) Token: 0x06001248 RID: 4680 RVA: 0x0013329C File Offset: 0x0013149C
		public GameEngine.GameDisplays GameDisplayMode
		{
			get
			{
				return this.gameDisplayMode;
			}
			set
			{
				if (Sound.isPlayingEnvironmental(19) && value != GameEngine.GameDisplays.DISPLAY_WORLD)
				{
					Sound.stopVillageEnvironmental();
				}
				this.gameDisplayMode = value;
				if (value == GameEngine.GameDisplays.DISPLAY_WORLD && InterfaceMgr.Instance.ParentForm != null && InterfaceMgr.Instance.ParentForm.Visible)
				{
					Sound.playVillageEnvironmental(19);
				}
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06001249 RID: 4681 RVA: 0x00013C9E File Offset: 0x00011E9E
		public GameEngine.GameDisplaySubModes GameDisplayModeSubMode
		{
			get
			{
				return this.gameDisplayModeSubMode;
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x0600124A RID: 4682 RVA: 0x00013CA6 File Offset: 0x00011EA6
		public static NumberFormatInfo NFI
		{
			get
			{
				return GameEngine.nfi;
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x0600124B RID: 4683 RVA: 0x00013CAD File Offset: 0x00011EAD
		public static NumberFormatInfo NFI_D
		{
			get
			{
				return GameEngine.nfi_decimal;
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x0600124C RID: 4684 RVA: 0x00013CB4 File Offset: 0x00011EB4
		public static NumberFormatInfo NFI_D1
		{
			get
			{
				return GameEngine.nfi_decimal1;
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x0600124D RID: 4685 RVA: 0x00013CBB File Offset: 0x00011EBB
		public static NumberFormatInfo NFI_D2
		{
			get
			{
				return GameEngine.nfi_decimal2;
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x0600124E RID: 4686 RVA: 0x00013CC2 File Offset: 0x00011EC2
		public int IncomingArmies
		{
			get
			{
				return this.incomingAttacks;
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x0600124F RID: 4687 RVA: 0x00013CCA File Offset: 0x00011ECA
		// (set) Token: 0x06001250 RID: 4688 RVA: 0x00013CD2 File Offset: 0x00011ED2
		public int MovedFromVillageID
		{
			get
			{
				return this.movedFromVillageID;
			}
			set
			{
				this.movedFromVillageID = value;
				if (value != -1 && !this.world.isCapital(value))
				{
					this.movedFromVillageIDNonCapital = value;
				}
			}
		}

		// Token: 0x06001251 RID: 4689 RVA: 0x001332EC File Offset: 0x001314EC
		public GameEngine()
		{
			GameEngine.Instance = this;
		}

		// Token: 0x06001252 RID: 4690 RVA: 0x0013348C File Offset: 0x0013168C
		public void loadThread()
		{
			InterfaceMgr.Instance.showDXCardBar(0);
			if (!this.gfxLoaded)
			{
				UVSpriteLoader.loadUVX("assets\\uvx.resources");
				GFXLibrary.Instance.loadGFX(this.gfx);
				UVSpriteLoader.closeUVX();
				this.gfxLoaded = true;
				return;
			}
			this.gfx.reloadGFX();
		}

		// Token: 0x06001253 RID: 4691 RVA: 0x00013CF4 File Offset: 0x00011EF4
		public bool cancelLoading()
		{
			return this.m_cancelLoading;
		}

		// Token: 0x06001254 RID: 4692 RVA: 0x00013CFC File Offset: 0x00011EFC
		public void killLoadThread()
		{
			this.m_cancelLoading = true;
			while (!this.gfxLoaded)
			{
				Thread.Sleep(10);
				Program.DoEvents();
			}
		}

		// Token: 0x06001255 RID: 4693 RVA: 0x00013D1B File Offset: 0x00011F1B
		public bool isStillLoading()
		{
			return !GFXLibrary.Instance.worldMapLoaded;
		}

		// Token: 0x06001256 RID: 4694 RVA: 0x001334E0 File Offset: 0x001316E0
		public bool Initialise(GraphicsMgr mgr, int maxRes, int curRes)
		{
			if (Program.mySettings.LanguageIdent == "de")
			{
				GameEngine.nfi = new CultureInfo("de-DE", false).NumberFormat;
				GameEngine.nfi.NumberDecimalDigits = 0;
				GameEngine.nfi_decimal = new CultureInfo("de-DE", false).NumberFormat;
				GameEngine.nfi_decimal1 = new CultureInfo("de-DE", false).NumberFormat;
				GameEngine.nfi_decimal1.NumberDecimalDigits = 1;
				GameEngine.nfi_decimal2 = new CultureInfo("de-DE", false).NumberFormat;
				GameEngine.nfi_decimal2.NumberDecimalDigits = 2;
			}
			else if (Program.mySettings.LanguageIdent == "fr")
			{
				GameEngine.nfi = new CultureInfo("fr-FR", false).NumberFormat;
				GameEngine.nfi.NumberDecimalDigits = 0;
				GameEngine.nfi_decimal = new CultureInfo("fr-FR", false).NumberFormat;
				GameEngine.nfi_decimal1 = new CultureInfo("fr-FR", false).NumberFormat;
				GameEngine.nfi_decimal1.NumberDecimalDigits = 1;
				GameEngine.nfi_decimal2 = new CultureInfo("fr-FR", false).NumberFormat;
				GameEngine.nfi_decimal2.NumberDecimalDigits = 2;
			}
			else if (Program.mySettings.LanguageIdent == "ru")
			{
				GameEngine.nfi = new CultureInfo("ru-RU", false).NumberFormat;
				GameEngine.nfi.NumberDecimalDigits = 0;
				GameEngine.nfi_decimal = new CultureInfo("ru-RU", false).NumberFormat;
				GameEngine.nfi_decimal1 = new CultureInfo("ru-RU", false).NumberFormat;
				GameEngine.nfi_decimal1.NumberDecimalDigits = 1;
				GameEngine.nfi_decimal2 = new CultureInfo("ru-RU", false).NumberFormat;
				GameEngine.nfi_decimal2.NumberDecimalDigits = 2;
			}
			else if (Program.mySettings.LanguageIdent == "es")
			{
				GameEngine.nfi = new CultureInfo("es-ES", false).NumberFormat;
				GameEngine.nfi.NumberDecimalDigits = 0;
				GameEngine.nfi_decimal = new CultureInfo("es-ES", false).NumberFormat;
				GameEngine.nfi_decimal1 = new CultureInfo("es-ES", false).NumberFormat;
				GameEngine.nfi_decimal1.NumberDecimalDigits = 1;
				GameEngine.nfi_decimal2 = new CultureInfo("es-ES", false).NumberFormat;
				GameEngine.nfi_decimal2.NumberDecimalDigits = 2;
			}
			else if (Program.mySettings.LanguageIdent == "pl")
			{
				GameEngine.nfi = new CultureInfo("pl-PL", false).NumberFormat;
				GameEngine.nfi.NumberDecimalDigits = 0;
				GameEngine.nfi_decimal = new CultureInfo("pl-PL", false).NumberFormat;
				GameEngine.nfi_decimal1 = new CultureInfo("pl-PL", false).NumberFormat;
				GameEngine.nfi_decimal1.NumberDecimalDigits = 1;
				GameEngine.nfi_decimal2 = new CultureInfo("pl-PL", false).NumberFormat;
				GameEngine.nfi_decimal2.NumberDecimalDigits = 2;
			}
			else if (Program.mySettings.LanguageIdent == "it")
			{
				GameEngine.nfi = new CultureInfo("it-IT", false).NumberFormat;
				GameEngine.nfi.NumberDecimalDigits = 0;
				GameEngine.nfi_decimal = new CultureInfo("it-IT", false).NumberFormat;
				GameEngine.nfi_decimal1 = new CultureInfo("it-IT", false).NumberFormat;
				GameEngine.nfi_decimal1.NumberDecimalDigits = 1;
				GameEngine.nfi_decimal2 = new CultureInfo("it-IT", false).NumberFormat;
				GameEngine.nfi_decimal2.NumberDecimalDigits = 2;
			}
			else if (Program.mySettings.LanguageIdent == "tr")
			{
				GameEngine.nfi = new CultureInfo("tr-TR", false).NumberFormat;
				GameEngine.nfi.NumberDecimalDigits = 0;
				GameEngine.nfi_decimal = new CultureInfo("tr-TR", false).NumberFormat;
				GameEngine.nfi_decimal1 = new CultureInfo("tr-TR", false).NumberFormat;
				GameEngine.nfi_decimal1.NumberDecimalDigits = 1;
				GameEngine.nfi_decimal2 = new CultureInfo("tr-TR", false).NumberFormat;
				GameEngine.nfi_decimal2.NumberDecimalDigits = 2;
			}
			else if (Program.mySettings.LanguageIdent == "pt")
			{
				GameEngine.nfi = new CultureInfo("pt-BR", false).NumberFormat;
				GameEngine.nfi.NumberDecimalDigits = 0;
				GameEngine.nfi_decimal = new CultureInfo("pt-BR", false).NumberFormat;
				GameEngine.nfi_decimal1 = new CultureInfo("pt-BR", false).NumberFormat;
				GameEngine.nfi_decimal1.NumberDecimalDigits = 1;
				GameEngine.nfi_decimal2 = new CultureInfo("pt-BR", false).NumberFormat;
				GameEngine.nfi_decimal2.NumberDecimalDigits = 2;
			}
			else
			{
				GameEngine.nfi = new CultureInfo(CultureInfo.CurrentCulture.Name, false).NumberFormat;
				GameEngine.nfi.NumberDecimalDigits = 0;
				GameEngine.nfi_decimal = new CultureInfo(CultureInfo.CurrentCulture.Name, false).NumberFormat;
				GameEngine.nfi_decimal1 = new CultureInfo(CultureInfo.CurrentCulture.Name, false).NumberFormat;
				GameEngine.nfi_decimal1.NumberDecimalDigits = 1;
				GameEngine.nfi_decimal2 = new CultureInfo(CultureInfo.CurrentCulture.Name, false).NumberFormat;
				GameEngine.nfi_decimal2.NumberDecimalDigits = 2;
			}
			NewQuests.loadCSV();
			this.maxResolution = maxRes;
			this.currentResolution = curRes;
			this.gfx = mgr;
			this.m_doReLogin = false;
			this.villageToAbandon = -1;
			if (this.firstCall)
			{
				this.m_tickTimer = new System.Threading.Timer(new TimerCallback(this.TimerCallbackFunction), null, 33, 33);
			}
			string text = this.gfx.InitControl(InterfaceMgr.Instance.getDXBasePanel(), Program.mySettings.AAMode);
			if (text != null)
			{
				GameEngine.displayDirectXError();
				return false;
			}
			if (this.gfx.calcedAAMode > 0)
			{
				Program.mySettings.AAMode = this.gfx.calcedAAMode;
			}
			this.dxFont1.Family = "Tahoma";
			this.dxFont1.Height = 18;
			this.dxFont2.Family = "Arial";
			this.dxFont2.Weight = FontDesc.Weighting.Normal;
			this.dxFont2.Height = 18;
			this.gfx.Initialize();
			this.gfx.initRenderCallback(new GraphicsMgr.RenderCallback(this.render));
			this.gfx.initFont(this.dxFont1, this.dxFont2);
			this.m_WorkerThread = new Thread(new ThreadStart(this.loadThread));
			this.m_WorkerThread.Name = "Loader";
			GFXLibrary.Instance.loadResources();
			InterfaceMgr.Instance.mapPanelCreates();
			this.m_WorkerThread.Start();
			if (this.firstCall)
			{
				Thread.Sleep(100);
			}
			this.worldMapTypesData = new WorldMapTypes();
			if (this.firstCall)
			{
				this.audio = new Audio();
				this.audio.initAudio();
				VillageMap.loadVillageSounds();
				Sound.createPlayLists();
			}
			RemoteServices.Instance.set_CommonData_UserCallBack(new RemoteServices.CommonData_UserCallBack(this.remoteConnectionCommonHandler));
			InterfaceMgr.Instance.initInterfaces();
			OptionsPopup.registerCallback(new OptionsPopup.ResolutionChangeCallback(this.resolutionButtonChange));
			this.world.registerWorldZoomCallback(new WorldMap.WorldZoomCallback(this.worldZoomChange));
			this.world.capZoom(0.0);
			this.world.initFW();
			InterfaceMgr.Instance.getMainTabBar().registerTabChangeCallback(new MainTabBar2.TabChangeCallback(this.mainTabChange));
			InterfaceMgr.Instance.getVillageTabBar().registerTabChangeCallback(new VillageTabBar2.TabChangeCallback(this.villageTabChange));
			InterfaceMgr.Instance.getFactionTabBar().registerTabChangeCallback(new FactionTabBar2.TabChangeCallback(this.factionTabChange));
			RemoteServices.Instance.set_GetVillageBuildingsList_UserCallBack(new RemoteServices.GetVillageBuildingsList_UserCallBack(this.getVillageBuildingListCallBack));
			this.gfx.BGColor = WorldMap.SEACOLOR;
			this.lastTabID = -1;
			InterfaceMgr.Instance.ignoreStopDraw = true;
			DXPanel.skipPaint = true;
			this.mainTabChange(0);
			DXPanel.skipPaint = false;
			InterfaceMgr.Instance.ignoreStopDraw = false;
			this.firstCall = false;
			this.lastFullTickRegisterTime = (this.lastFullTickTime = DXTimer.GetCurrentMilliseconds());
			return true;
		}

		// Token: 0x06001257 RID: 4695 RVA: 0x00013D2A File Offset: 0x00011F2A
		public void resumeCommonRemote()
		{
			RemoteServices.Instance.set_CommonData_UserCallBack(new RemoteServices.CommonData_UserCallBack(this.remoteConnectionCommonHandler));
		}

		// Token: 0x06001258 RID: 4696 RVA: 0x00133CC0 File Offset: 0x00131EC0
		public void lateStart()
		{
			InterfaceMgr.Instance.setUserName(RemoteServices.Instance.UserName);
			this.world.setCurrentZoom((float)this.World.WorldZoom);
			this.world.setScreenSize(InterfaceMgr.Instance.getDXBasePanel().Width, InterfaceMgr.Instance.getDXBasePanel().Height);
			int selectedMenuVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
			InterfaceMgr.Instance.getMainTabBar().changeTab(9);
			InterfaceMgr.Instance.getMainTabBar().changeTab(0);
			this.world.startGameZoom(selectedMenuVillage);
			InterfaceMgr.Instance.getTopLeftMenu().init();
			InterfaceMgr.Instance.getTopRightMenu().init();
			if (this.LocalWorldData.Alternate_Ruleset == 1)
			{
				InterfaceMgr.Instance.showDominationWindow();
			}
		}

		// Token: 0x06001259 RID: 4697 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void showConnectingPopup()
		{
		}

		// Token: 0x0600125A RID: 4698 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void enableConnectingPopup()
		{
		}

		// Token: 0x0600125B RID: 4699 RVA: 0x00013D42 File Offset: 0x00011F42
		public void enableConnectingPopup2()
		{
			if (this.m_loginWindow != null)
			{
				this.m_loginWindow.selfClose();
				this.m_loginWindow.Close();
			}
		}

		// Token: 0x0600125C RID: 4700 RVA: 0x00013D62 File Offset: 0x00011F62
		public void updateConnectingPopup()
		{
			if (this.m_loginWindow != null)
			{
				this.m_loginWindow.update();
			}
		}

		// Token: 0x0600125D RID: 4701 RVA: 0x00013D77 File Offset: 0x00011F77
		public bool waitForConnectingPopupToClose()
		{
			return this.m_loginWindow != null && this.m_loginWindow.Created;
		}

		// Token: 0x0600125E RID: 4702 RVA: 0x00013D8E File Offset: 0x00011F8E
		public void setProfileLogin(ProfileLoginWindow loginWindow)
		{
			this.m_loginWindow = loginWindow;
		}

		// Token: 0x0600125F RID: 4703 RVA: 0x00013D97 File Offset: 0x00011F97
		public ProfileLoginWindow getLoginWindow()
		{
			if (this.m_loginWindow != null && this.m_loginWindow.Created)
			{
				return this.m_loginWindow;
			}
			return null;
		}

		// Token: 0x06001260 RID: 4704 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void TimerCallbackFunction(object o)
		{
		}

		// Token: 0x06001261 RID: 4705 RVA: 0x00013DB6 File Offset: 0x00011FB6
		public void forceFullTick()
		{
			this.forceTriggerFullTick = true;
		}

		// Token: 0x06001262 RID: 4706 RVA: 0x00133D90 File Offset: 0x00131F90
		public bool isSelectNewVillageVisible()
		{
			if (this.noVillagePopup == null && this.noAutoVillagePopup == null)
			{
				return false;
			}
			if (this.noVillagePopup != null)
			{
				if (!this.noVillagePopup.Created)
				{
					return false;
				}
				if (!this.noVillagePopup.Visible)
				{
					return false;
				}
			}
			if (this.noAutoVillagePopup != null)
			{
				if (!this.noAutoVillagePopup.Created)
				{
					return false;
				}
				if (!this.noAutoVillagePopup.Visible)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06001263 RID: 4707 RVA: 0x00133DFC File Offset: 0x00131FFC
		public void run()
		{
			long num = this.lastFrameTime;
			long currentMillisecondsLong = DXTimer.GetCurrentMillisecondsLong();
			if (num == 0L)
			{
				num = currentMillisecondsLong - 33L;
			}
			long num2 = currentMillisecondsLong - num;
			if (num2 >= 33L)
			{
				this.ticked = true;
				if (num2 >= 49L)
				{
					this.lastFrameTime = currentMillisecondsLong;
				}
				else
				{
					this.lastFrameTime += 33L;
				}
				InterfaceMgr.Instance.getDXBasePanel().AllowDraw();
				InterfaceMgr.Instance.getDXBasePanel().Invalidate();
				Program.DoEvents();
			}
			if (this.villageToAbandon >= 0)
			{
				int villageID = this.villageToAbandon;
				this.villageHasBeenDownloaded = false;
				InterfaceMgr.Instance.changeTab(9);
				InterfaceMgr.Instance.changeTab(1);
				for (int i = 0; i < 210; i++)
				{
					Thread.Sleep(33);
					Program.DoEvents();
					RemoteServices.Instance.processData();
					if (this.villageHasBeenDownloaded)
					{
						this.villageToAbandon = -1;
						for (int j = 0; j < 10; j++)
						{
							Thread.Sleep(33);
							this.run();
							RemoteServices.Instance.processData();
						}
						break;
					}
				}
				int num3 = 0;
				VillageMap villageMap = GameEngine.Instance.getVillage(villageID);
				if (villageMap != null)
				{
					num3 = villageMap.countBuildings();
				}
				MessageBoxButtons buts = MessageBoxButtons.YesNo;
				DialogResult dialogResult = (num3 > 0) ? MyMessageBox.Show(string.Concat(new string[]
				{
					SK.Text("Abandon_Message", "You are about to Abandon this village. You will lose ownership of this village and once abandoned it can not be reversed."),
					Environment.NewLine,
					SK.Text("BuyVillagePopup_Are_You_REALLY_Sure", "Are you REALLY Sure you want to do this and that you have selected the correct village?"),
					Environment.NewLine,
					Environment.NewLine,
					SK.Text("BuyVillagePopup_To_Be_Abandon", "The Village to be abandoned is : "),
					Environment.NewLine,
					Environment.NewLine,
					GameEngine.Instance.World.getVillageName(villageID),
					Environment.NewLine,
					Environment.NewLine,
					".",
					SK.Text("BuyVillagePopup_Num_Buildings", "The number of buildings in this village : "),
					num3.ToString(),
					Environment.NewLine,
					Environment.NewLine,
					"."
				}), SK.Text("MENU_Abandon_Warning", "Warning! : Abandon") + " : " + GameEngine.Instance.World.getVillageName(villageID) + "?", buts, MessageBoxIcon.None, MessageBoxDefaultButton.Button2, 0) : MyMessageBox.Show(string.Concat(new string[]
				{
					SK.Text("Abandon_Message", "You are about to Abandon this village. You will lose ownership of this village and once abandoned it can not be reversed."),
					Environment.NewLine,
					SK.Text("BuyVillagePopup_Are_You_REALLY_Sure", "Are you REALLY Sure you want to do this and that you have selected the correct village?"),
					Environment.NewLine,
					Environment.NewLine,
					SK.Text("BuyVillagePopup_To_Be_Abandon", "The Village to be abandoned is : "),
					Environment.NewLine,
					Environment.NewLine,
					GameEngine.Instance.World.getVillageName(villageID),
					Environment.NewLine,
					Environment.NewLine,
					"."
				}), SK.Text("MENU_Abandon_Warning", "Warning! : Abandon") + " : " + GameEngine.Instance.World.getVillageName(villageID) + "?", buts, MessageBoxIcon.None, MessageBoxDefaultButton.Button2, 0);
				if (dialogResult == DialogResult.Yes)
				{
					RemoteServices.Instance.set_VillageRename_UserCallBack(new RemoteServices.VillageRename_UserCallBack(MainMenuBar2.VillageRenameCallback));
					RemoteServices.Instance.VillageAbandon(villageID);
				}
				this.villageToAbandon = -1;
			}
			if (this.ticked)
			{
				if (this.lastSoundClear == DateTime.MinValue)
				{
					this.lastSoundClear = DateTime.Now;
				}
				else if ((DateTime.Now - this.lastSoundClear).TotalMinutes > 5.0)
				{
					this.lastSoundClear = DateTime.Now;
					this.AudioEngine.unloadUnplayingSounds();
				}
				Program.steam_run();
				Program.arc_run();
				this.audio.update();
				Form activeForm = Form.ActiveForm;
				if (activeForm != InterfaceMgr.Instance.ParentForm && (activeForm != InterfaceMgr.Instance.ChatForm || InterfaceMgr.Instance.ChatForm == null))
				{
					GameEngine.scrollLeft = false;
					GameEngine.scrollUp = false;
					GameEngine.scrollRight = false;
					GameEngine.scrollDown = false;
					GameEngine.Instance.GFX.keyControlled = false;
					GameEngine.shiftPressed = false;
					GameEngine.tabPressed = false;
				}
				this.gfx.RenderList.clearLayers();
				this.ticked = false;
				this.tickCount++;
				this.cardsManager.postcardPlayUpdate();
				if (this.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_VILLAGE)
				{
					if (this.village != null)
					{
						this.village.Update(true);
					}
					if (this.castle != null)
					{
						this.castle.Update(false);
					}
					InterfaceMgr.Instance.runVillageInterface();
				}
				else if (this.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_CASTLE)
				{
					if (this.gameDisplayModeSubMode == GameEngine.GameDisplaySubModes.SUBMODE_DEFAULT)
					{
						if (this.village != null)
						{
							this.village.Update(false);
						}
						if (this.castle != null)
						{
							this.castle.Update(true);
						}
						InterfaceMgr.Instance.runCastleInterface();
					}
					else if (this.gameDisplayModeSubMode == GameEngine.GameDisplaySubModes.SUBMODE_CASTLE_ATTACKER_SETUP)
					{
						if (this.castle_AttackerSetup != null)
						{
							this.castle_AttackerSetup.Update(true);
						}
					}
					else if (this.gameDisplayModeSubMode == GameEngine.GameDisplaySubModes.SUBMODE_BATTLE)
					{
						if (this.castle_Battle != null)
						{
							this.castle_Battle.BattleUpdateManager(true);
						}
					}
					else if (this.gameDisplayModeSubMode == GameEngine.GameDisplaySubModes.SUBMODE_PREVIEW && this.castle_Preview != null)
					{
						this.castle_Preview.Update(true);
					}
				}
				else if (this.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_WORLD)
				{
					bool special = false;
					this.world.Update();
					if (this.world.ZoomChange != 0.0)
					{
						this.world.changeZoom((float)this.world.ZoomChange);
						if (this.world.ZoomChange <= 0.0)
						{
							this.world.centreMap(false);
						}
					}
					if (this.tickCount % 10 == 0)
					{
						InterfaceMgr.Instance.updateTraderInfo();
						InterfaceMgr.Instance.updatePersonInfo();
						this.World.updateLocalVillagesFromFactions();
						InterfaceMgr.Instance.ensureInfoTabCleared();
						this.World.monitorAIInvasionActivity();
					}
					double currentMilliseconds = DXTimer.GetCurrentMilliseconds();
					double num4 = this.LocalWorldData.callHomeRate;
					int gameActivityMode = InterfaceMgr.Instance.getGameActivityMode();
					switch (gameActivityMode)
					{
					case 1:
						num4 *= 2.0;
						break;
					case 2:
						num4 *= 4.0;
						break;
					case 3:
						num4 *= 6.0;
						break;
					case 4:
						num4 *= 14.0;
						break;
					case 5:
						num4 *= 20.0;
						break;
					}
					this.clockMode = gameActivityMode;
					double num5 = (currentMilliseconds - this.lastFullTickTime) * 64.0 / (num4 * 1000.0);
					this.clockFrame = (int)num5;
					if (this.clockFrame >= 63)
					{
						this.clockFrame = 63;
					}
					if (currentMilliseconds - this.lastFullTickTime > num4 * 1000.0 || this.forceTriggerFullTick)
					{
						this.clockFrame = 0;
						this.forceTriggerFullTick = false;
						if (currentMilliseconds - this.lastFullTickRegisterTime > 240000.0)
						{
							this.lastFullTickTime = currentMilliseconds;
							this.lastFullTickRegisterTime = currentMilliseconds;
							this.World.doFullTick(true, gameActivityMode);
						}
						else if (!InterfaceMgr.Instance.isGameMinimised())
						{
							this.lastFullTickTime = currentMilliseconds;
							this.World.doFullTick(false, gameActivityMode);
						}
						special = true;
					}
					InterfaceMgr.Instance.worldTabUpdate(special);
				}
				else if (this.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_REPORTS)
				{
					if (this.tickCount % 10 == 0)
					{
						InterfaceMgr.Instance.updateVillageReports();
					}
				}
				else if (this.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_LEADERBOARD)
				{
					if (this.tickCount % 10 == 0)
					{
						InterfaceMgr.Instance.updateVillageReports();
					}
				}
				else if (this.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_CONTESTS_LEADERBOARD)
				{
					if (this.tickCount % 10 == 0)
					{
						InterfaceMgr.Instance.updateVillageReports();
					}
				}
				else if (this.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_USER_INFO)
				{
					if (this.tickCount % 10 == 0)
					{
						InterfaceMgr.Instance.updateVillageReports();
					}
				}
				else if (this.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_ALL_VILLAGES)
				{
					if (this.tickCount % 10 == 0)
					{
						InterfaceMgr.Instance.updateVillageReports();
					}
				}
				else if (this.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_RANKINGS)
				{
					InterfaceMgr.Instance.updateVillageReports();
				}
				else if (this.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_FACTIONS)
				{
					if (this.tickCount % 10 == 0)
					{
						InterfaceMgr.Instance.updateVillageReports();
					}
				}
				else if (this.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_QUESTS)
				{
					InterfaceMgr.Instance.updateVillageReports();
				}
				else if (this.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_ARMIES)
				{
					if (this.tickCount % 10 == 0)
					{
						double currentMilliseconds2 = DXTimer.GetCurrentMilliseconds();
						double num6 = this.LocalWorldData.callHomeRate;
						int gameActivityMode2 = InterfaceMgr.Instance.getGameActivityMode();
						switch (gameActivityMode2)
						{
						case 1:
							num6 *= 2.0;
							break;
						case 2:
							num6 *= 4.0;
							break;
						case 3:
							num6 *= 6.0;
							break;
						case 4:
							num6 *= 14.0;
							break;
						case 5:
							num6 *= 20.0;
							break;
						}
						if (currentMilliseconds2 - this.lastFullTickTime > num6 * 1000.0)
						{
							this.lastFullTickTime = currentMilliseconds2;
							this.World.doFullTick(false, gameActivityMode2);
						}
						InterfaceMgr.Instance.updateVillageReports();
					}
				}
				else if (this.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_RESEARCH)
				{
					InterfaceMgr.Instance.updateResearch(this.tickCount % 10 == 0);
				}
				else if (this.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_AVATAR_EDITOR)
				{
					InterfaceMgr.Instance.updateVillageReports();
				}
				if (this.GameDisplayMode != GameEngine.GameDisplays.DISPLAY_QUESTS && this.tickCount % 60 == 35)
				{
					NewQuestsPanel.handleClientSideQuestReporting(true);
				}
				if (this.forceTriggerFullTick && this.GameDisplayMode != GameEngine.GameDisplays.DISPLAY_WORLD)
				{
					double currentMilliseconds3 = DXTimer.GetCurrentMilliseconds();
					this.forceTriggerFullTick = false;
					this.lastFullTickTime = currentMilliseconds3;
					this.World.doFullTick(false, 3);
				}
				if (this.GameDisplayMode != GameEngine.GameDisplays.DISPLAY_WORLD && this.GameDisplayMode != GameEngine.GameDisplays.DISPLAY_ARMIES && !InterfaceMgr.Instance.isGameMinimised())
				{
					double currentMilliseconds4 = DXTimer.GetCurrentMilliseconds();
					double num7 = this.LocalWorldData.callHomeRate;
					switch (InterfaceMgr.Instance.getGameActivityMode())
					{
					case 0:
						num7 *= 3.0;
						break;
					case 1:
						num7 *= 4.0;
						break;
					case 2:
						num7 *= 7.0;
						break;
					case 3:
						num7 *= 10.0;
						break;
					case 4:
						num7 *= 19.0;
						break;
					case 5:
						num7 *= 25.0;
						break;
					}
					if (currentMilliseconds4 - this.lastFullTickTime > num7 * 1000.0)
					{
						this.lastFullTickTime = currentMilliseconds4;
						this.World.getArmiesIfNewAttacks();
					}
				}
				if (this.tickCount % 10 == 0)
				{
					if (GameEngine.Instance.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_CASTLE)
					{
						int num8 = (int)this.world.getCurrentGold();
						if (this.Castle != null && !this.World.isCapital(this.Castle.VillageID))
						{
							VillageMap.StockpileLevels stockpileLevels = new VillageMap.StockpileLevels();
							this.Castle.adjustLevels(ref stockpileLevels, ref num8);
							InterfaceMgr.Instance.setGold((double)num8);
						}
					}
					else
					{
						InterfaceMgr.Instance.setGold(this.world.getCurrentGold());
					}
					InterfaceMgr.Instance.setHonour(this.world.getCurrentHonour(), this.world.getRank());
					InterfaceMgr.Instance.setFaithPoints(this.world.getCurrentFaithPoints());
					InterfaceMgr.Instance.setPoints(this.world.getCurrentPoints());
					InterfaceMgr.Instance.setServerTime(VillageMap.getCurrentServerTime(), this.World.getGameDay());
					if (RemoteServices.Instance.queueEmpty())
					{
						InterfaceMgr.Instance.setConnectionLight(false);
					}
					else
					{
						InterfaceMgr.Instance.setConnectionLight(true);
					}
					long num9 = -1L;
					this.incomingAttacks = this.World.countIncomingAttacks(ref num9);
					if (num9 > this.lastHighestArmyIDSeen)
					{
						this.NewArmiesSeen = true;
						this.lastHighestArmyIDSeen = num9;
					}
					InterfaceMgr.Instance.getMainTabBar().incomingAttacks(this.incomingAttacks, num9);
					InterfaceMgr.Instance.getMainTabBar().updateResearchTime(this.World.UserResearchData);
					foreach (object obj in this.villages)
					{
						VillageMap villageMap2 = (VillageMap)obj;
						if (villageMap2 != null)
						{
							villageMap2.makeTroopsUpdate();
						}
					}
					this.World.updateArmyRetrievalData();
					this.monitorDownTime();
					Sound.monitorMusic();
				}
				InterfaceMgr.Instance.mailUpdate();
				InterfaceMgr.Instance.chatUpdate();
				InterfaceMgr.Instance.getTopLeftMenu().update();
				InterfaceMgr.Instance.getMainTabBar().update();
				InterfaceMgr.Instance.updatePopups();
				this.World.updateResearch(false);
				bool mapScreenNoUpdate = Program.mySettings.MapScreenNoUpdate;
				if (!this.World.WorldEnded)
				{
					this.World.updateArmies();
					this.World.updateTraders();
					this.World.updatePeople();
				}
				else
				{
					this.World.updateFW();
				}
				PizzazzPopupWindow.updatePizzazz();
				InterfaceMgr.Instance.runTutorialWindow();
				MouseInputState mouseInputState = new MouseInputState();
				mouseInputState.getInput();
				this.manageInput(mouseInputState);
				if (this.tickCount % 1800 == 0)
				{
					GC.Collect();
					GC.WaitForPendingFinalizers();
				}
				if (this.tickCount % 120 == 0)
				{
					this.World.runClientAchievementTests();
				}
				if (this.worldsEndPopup == null && this.noVillagePopup == null && this.noAutoVillagePopup == null && this.lostVillagePopup == null)
				{
					if (this.World.WorldEnded && !this.World.WorldEnded_message)
					{
						this.World.WorldEnded_message = true;
						GameEngine.Instance.openWorldsEnd();
						RemoteServices.Instance.Show2ndAgeMessage = false;
						RemoteServices.Instance.Show3rdAgeMessage = false;
						RemoteServices.Instance.Show4thAgeMessage = false;
						RemoteServices.Instance.Show5thAgeMessage = false;
						RemoteServices.Instance.Show6thAgeMessage = false;
						RemoteServices.Instance.Show7thAgeMessage = false;
					}
					else if (RemoteServices.Instance.Show7thAgeMessage)
					{
						GameEngine.Instance.openLostVillage(7);
						RemoteServices.Instance.Show2ndAgeMessage = false;
						RemoteServices.Instance.Show3rdAgeMessage = false;
						RemoteServices.Instance.Show4thAgeMessage = false;
						RemoteServices.Instance.Show5thAgeMessage = false;
						RemoteServices.Instance.Show6thAgeMessage = false;
					}
					else if (RemoteServices.Instance.Show6thAgeMessage)
					{
						GameEngine.Instance.openLostVillage(6);
						RemoteServices.Instance.Show2ndAgeMessage = false;
						RemoteServices.Instance.Show3rdAgeMessage = false;
						RemoteServices.Instance.Show4thAgeMessage = false;
						RemoteServices.Instance.Show5thAgeMessage = false;
					}
					else if (RemoteServices.Instance.Show5thAgeMessage)
					{
						GameEngine.Instance.openLostVillage(5);
						RemoteServices.Instance.Show2ndAgeMessage = false;
						RemoteServices.Instance.Show3rdAgeMessage = false;
						RemoteServices.Instance.Show4thAgeMessage = false;
					}
					else if (RemoteServices.Instance.Show4thAgeMessage)
					{
						GameEngine.Instance.openLostVillage(4);
						RemoteServices.Instance.Show2ndAgeMessage = false;
						RemoteServices.Instance.Show3rdAgeMessage = false;
					}
					else if (RemoteServices.Instance.Show3rdAgeMessage)
					{
						GameEngine.Instance.openLostVillage(3);
						RemoteServices.Instance.Show2ndAgeMessage = false;
					}
					else if (RemoteServices.Instance.Show2ndAgeMessage)
					{
						GameEngine.Instance.openLostVillage(2);
					}
					else if (GameEngine.Instance.World.showGloryResults)
					{
						this.houseManager.UpdateGloryPoints(new HouseManager.HouseInfoUpdatedCallback(InterfaceMgr.Instance.openGloryVictoryPopup), true);
						GameEngine.Instance.World.showGloryResults = false;
					}
					if (!this.World.isRetrievingUserVillages() && !LoggingOutPopup.loggingOut && this.World.numVillagesOwned() == 0 && !this.World.WorldEnded)
					{
						this.World.updateLastAttackerInfo();
					}
				}
				else if (this.noVillagePopup != null)
				{
					this.noVillagePopup.update();
				}
				else if (this.lostVillagePopup != null)
				{
					this.lostVillagePopup.update();
				}
				else if (this.worldsEndPopup != null)
				{
					this.worldsEndPopup.update();
				}
				else if (this.noAutoVillagePopup != null)
				{
					this.noAutoVillagePopup.update();
				}
				TutorialWindow.runTutorial();
				this.debugPopupRun();
				this.loginHistoryRun();
				if (this.pendingUserVillageZoom)
				{
					int selectedMenuVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
					if (selectedMenuVillage >= 0)
					{
						this.pendingUserVillageZoom = false;
						VillageData villageData = this.world.getVillageData(selectedMenuVillage);
						if (villageData != null)
						{
							this.world.startMultiStageZoom(10000.0, (double)villageData.x, (double)villageData.y);
						}
					}
				}
			}
			if (Program.ShowSeasonalFX && SnowSystem.getInstance().snowTexture != null)
			{
				SnowSystem.getInstance().update(this.gfx);
			}
			if (this.finaliseResize)
			{
				try
				{
					this.finaliseResize = false;
					if (InterfaceMgr.Instance.ParentForm != null)
					{
						((MainWindow)InterfaceMgr.Instance.ParentForm).finaliseResize();
					}
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x06001264 RID: 4708 RVA: 0x00134F10 File Offset: 0x00133110
		public void closeNoVillagePopup(bool pendingVillage)
		{
			if (this.noVillagePopup != null)
			{
				InterfaceMgr.Instance.ParentForm.Enabled = true;
				this.noVillagePopup.closePopup();
				this.noVillagePopup.Close();
				this.noVillagePopup = null;
				InterfaceMgr.Instance.closeGreyOut();
			}
			if (this.lostVillagePopup != null)
			{
				if (this.lostVillagePopup.isCardsPopup())
				{
					this.lostVillagePopup.closePopup();
					this.lostVillagePopup.Close();
					this.lostVillagePopup = null;
				}
				else
				{
					InterfaceMgr.Instance.ParentForm.Enabled = true;
					this.lostVillagePopup.closePopup();
					this.lostVillagePopup.Close();
					this.lostVillagePopup = null;
					InterfaceMgr.Instance.closeGreyOut();
				}
			}
			if (this.worldsEndPopup != null)
			{
				InterfaceMgr.Instance.ParentForm.Enabled = true;
				this.worldsEndPopup.closePopup();
				this.worldsEndPopup.Close();
				this.worldsEndPopup = null;
				InterfaceMgr.Instance.closeGreyOut();
			}
			if (this.noAutoVillagePopup != null)
			{
				InterfaceMgr.Instance.ParentForm.Enabled = true;
				this.noAutoVillagePopup.closePopup();
				this.noAutoVillagePopup.Close();
				this.noAutoVillagePopup = null;
				InterfaceMgr.Instance.closeGreyOut();
			}
			if (pendingVillage)
			{
				this.pendingUserVillageZoom = true;
			}
		}

		// Token: 0x06001265 RID: 4709 RVA: 0x00135050 File Offset: 0x00133250
		public void openAdvancedSelectVillage()
		{
			InterfaceMgr.Instance.openGreyOutWindow(false);
			InterfaceMgr.Instance.ParentForm.Enabled = false;
			this.noVillagePopup = new NewSelectVillageAreaWindow();
			this.noVillagePopup.init(this.tryingToJoinCounty);
			this.noVillagePopup.Show(InterfaceMgr.Instance.getGreyOutWindow());
		}

		// Token: 0x06001266 RID: 4710 RVA: 0x001350AC File Offset: 0x001332AC
		public void openLostVillage(int age)
		{
			if (InterfaceMgr.Instance.ParentForm.WindowState == FormWindowState.Minimized)
			{
				InterfaceMgr.Instance.ParentForm.WindowState = FormWindowState.Normal;
				for (int i = 0; i < 10; i++)
				{
					Thread.Sleep(100);
					Application.DoEvents();
				}
			}
			InterfaceMgr.Instance.openGreyOutWindow(false);
			InterfaceMgr.Instance.ParentForm.Enabled = false;
			this.lostVillagePopup = new LostVillageWindow();
			this.lostVillagePopup.init(age, -1);
			this.lostVillagePopup.Show(InterfaceMgr.Instance.getGreyOutWindow());
		}

		// Token: 0x06001267 RID: 4711 RVA: 0x00135140 File Offset: 0x00133340
		public void openWorldsEnd()
		{
			if (InterfaceMgr.Instance.ParentForm.WindowState == FormWindowState.Minimized)
			{
				InterfaceMgr.Instance.ParentForm.WindowState = FormWindowState.Normal;
				for (int i = 0; i < 10; i++)
				{
					Thread.Sleep(100);
					Application.DoEvents();
				}
			}
			InterfaceMgr.Instance.openGreyOutWindow(false);
			InterfaceMgr.Instance.ParentForm.Enabled = false;
			this.worldsEndPopup = new WorldsEndWindow();
			this.worldsEndPopup.init();
			this.worldsEndPopup.Show(InterfaceMgr.Instance.getGreyOutWindow());
		}

		// Token: 0x06001268 RID: 4712 RVA: 0x001351D0 File Offset: 0x001333D0
		public void openSimpleSelectVillage()
		{
			InterfaceMgr.Instance.openGreyOutWindow(false);
			InterfaceMgr.Instance.ParentForm.Enabled = false;
			this.noAutoVillagePopup = new NewAutoSelectVillageWindow();
			this.noAutoVillagePopup.init(this.tryingToJoinCounty);
			this.noAutoVillagePopup.Show(InterfaceMgr.Instance.getGreyOutWindow());
		}

		// Token: 0x06001269 RID: 4713 RVA: 0x00013DBF File Offset: 0x00011FBF
		public void openSuperPackInfo(int mode)
		{
			this.lostVillagePopup = new LostVillageWindow();
			this.lostVillagePopup.init(0, mode);
			this.lostVillagePopup.Show(InterfaceMgr.Instance.getCardWindow());
		}

		// Token: 0x0600126A RID: 4714 RVA: 0x0013522C File Offset: 0x0013342C
		public void OnPaintCallback()
		{
			bool flag = false;
			if (this.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_WORLD)
			{
				flag = true;
			}
			if (this.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_VILLAGE && InterfaceMgr.Instance.updateVillageReports())
			{
				flag = true;
			}
			if (this.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_CASTLE)
			{
				flag = true;
			}
			if (!flag || !InterfaceMgr.Instance.ParentForm.Created)
			{
				return;
			}
			bool renderContent = true;
			if (Program.steamInstall)
			{
				renderContent = !Program.steamOverlayActive;
			}
			if (!this.gfx.render(renderContent))
			{
				this.newResolution = this.currentResolution;
				if (InterfaceMgr.Instance.ParentForm != null)
				{
					MyMessageBox.Show(SK.Text("GameEngine_Generic_Error", "An error has occurred and Stronghold Kingdoms will now close."), "DirectX");
					InterfaceMgr.Instance.ParentForm.Close();
				}
			}
		}

		// Token: 0x0600126B RID: 4715 RVA: 0x001352E0 File Offset: 0x001334E0
		public void setServerDownTime(DateTime downtime)
		{
			if (!(downtime != this.serverDowntime))
			{
				return;
			}
			if (downtime == DateTime.MinValue)
			{
				this.clearServerDowntime();
				return;
			}
			this.clearServerDowntime();
			this.serverDowntime = downtime;
			TimeSpan timeSpan = this.serverDowntime - VillageMap.getCurrentServerTime();
			if (timeSpan.TotalMinutes < 780.0)
			{
				this.warning24H = true;
			}
			if (timeSpan.TotalMinutes < 300.0)
			{
				this.warning12H = true;
			}
			if (timeSpan.TotalMinutes < 120.0)
			{
				this.warning4H = true;
			}
			if (timeSpan.TotalMinutes < 35.0)
			{
				this.warning60 = true;
			}
			if (timeSpan.TotalMinutes < 19.0)
			{
				this.warning30 = true;
			}
			if (timeSpan.TotalMinutes < 8.0)
			{
				this.warning15 = true;
			}
		}

		// Token: 0x0600126C RID: 4716 RVA: 0x001353C4 File Offset: 0x001335C4
		private void monitorDownTime()
		{
			if (this.serverDowntime != DateTime.MinValue)
			{
				TimeSpan timeSpan = this.serverDowntime - VillageMap.getCurrentServerTime();
				if (timeSpan.TotalMinutes < 1440.5 && !this.warning24H)
				{
					this.warning24H = true;
					this.showDowntimeWarning(timeSpan.TotalMinutes);
					return;
				}
				if (timeSpan.TotalMinutes < 720.5 && !this.warning12H)
				{
					this.warning12H = true;
					this.showDowntimeWarning(timeSpan.TotalMinutes);
					return;
				}
				if (timeSpan.TotalMinutes < 240.5 && !this.warning4H)
				{
					this.warning4H = true;
					this.showDowntimeWarning(timeSpan.TotalMinutes);
					return;
				}
				if (timeSpan.TotalMinutes < 60.5 && !this.warning60)
				{
					this.warning60 = true;
					this.showDowntimeWarning(timeSpan.TotalMinutes);
					return;
				}
				if (timeSpan.TotalMinutes < 30.5 && !this.warning30)
				{
					this.warning30 = true;
					this.showDowntimeWarning(timeSpan.TotalMinutes);
					return;
				}
				if (timeSpan.TotalMinutes < 15.5 && !this.warning15)
				{
					this.warning15 = true;
					this.showDowntimeWarning(timeSpan.TotalMinutes);
					return;
				}
				if (timeSpan.TotalMinutes < 5.5 && !this.warning5)
				{
					this.warning5 = true;
					this.showDowntimeWarning(timeSpan.TotalMinutes);
					return;
				}
				if (timeSpan.TotalMinutes < 0.0 && !this.serverOffline)
				{
					this.serverOffline = true;
					this.clearDowntimePopup();
					this.sessionExpired(3);
					return;
				}
			}
			int alternate_Ruleset = this.LocalWorldData.Alternate_Ruleset;
		}

		// Token: 0x0600126D RID: 4717 RVA: 0x0013557C File Offset: 0x0013377C
		public TimeSpan getDominationTimeLeft()
		{
			DateTime currentServerTime = VillageMap.getCurrentServerTime();
			int gameDay = GameEngine.Instance.World.getGameDay();
			TimeSpan timeSpan = new TimeSpan(gameDay, currentServerTime.Hour, currentServerTime.Minute, currentServerTime.Second);
			timeSpan -= new TimeSpan(14, 0, 0);
			return new TimeSpan(92, 0, 0, 0) - timeSpan;
		}

		// Token: 0x0600126E RID: 4718 RVA: 0x00013DEE File Offset: 0x00011FEE
		private void showDowntimeWarning(double minutes)
		{
			if (minutes >= 0.0)
			{
				this.clearDowntimePopup();
				this.m_downtimePopup = new ServerDowntimePopup();
				this.m_downtimePopup.show((int)minutes);
			}
		}

		// Token: 0x0600126F RID: 4719 RVA: 0x00013E1A File Offset: 0x0001201A
		public void clearDowntimePopup()
		{
			if (this.m_downtimePopup != null)
			{
				if (this.m_downtimePopup.Created && this.m_downtimePopup.Visible)
				{
					this.m_downtimePopup.Close();
				}
				this.m_downtimePopup = null;
			}
		}

		// Token: 0x06001270 RID: 4720 RVA: 0x00013E50 File Offset: 0x00012050
		public void clearServerDowntime()
		{
			this.serverDowntime = DateTime.MinValue;
			this.warning5 = false;
			this.warning15 = false;
			this.warning30 = false;
			this.warning60 = false;
			this.serverOffline = false;
		}

		// Token: 0x06001271 RID: 4721 RVA: 0x001355DC File Offset: 0x001337DC
		public void render()
		{
			this.gfx.drawOverLayTexture = InterfaceMgr.Instance.allowDrawCircles();
			InterfaceMgr.Instance.updateDXCardBar();
			if (this.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_WORLD)
			{
				this.world.drawVillageTree(this.gfx);
				this.gfx.drawPlaybackTexture = InterfaceMgr.Instance.playbackEnabled;
				if (this.gfx.drawPlaybackTexture)
				{
					InterfaceMgr.Instance.updateDXPlaybackBar();
				}
			}
			else
			{
				this.gfx.drawPlaybackTexture = false;
			}
			try
			{
				this.gfx.RenderList.render(this.gfx);
			}
			catch (InvalidOperationException ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.Main);
			}
			if (this.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_CASTLE)
			{
				if (this.gameDisplayModeSubMode == GameEngine.GameDisplaySubModes.SUBMODE_CASTLE_ATTACKER_SETUP && this.castle_AttackerSetup != null)
				{
					this.castle_AttackerSetup.drawCatapultLines();
					this.castle_AttackerSetup.drawLasso();
				}
				if (this.gameDisplayModeSubMode == GameEngine.GameDisplaySubModes.SUBMODE_DEFAULT && this.castle != null)
				{
					this.castle.drawLasso();
				}
			}
			if (this.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_VILLAGE && this.village != null)
			{
				this.village.drawProductionArrow();
			}
			if (Program.ShowSeasonalFX && SnowSystem.getInstance().snowTexture != null)
			{
				this.gfx.beginSprites();
				SnowSystem.getInstance().render(this.gfx);
				this.gfx.endSprites();
			}
		}

		// Token: 0x06001272 RID: 4722 RVA: 0x00135730 File Offset: 0x00133930
		public void manageInput(MouseInputState inputState)
		{
			InterfaceMgr.Instance.runTooltips();
			if (!inputState.leftdown && (GameEngine.scrollLeft || GameEngine.scrollRight || GameEngine.scrollUp || GameEngine.scrollDown))
			{
				if (this.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_VILLAGE && this.village != null)
				{
					if (GameEngine.scrollLeft)
					{
						this.village.Camera.Drag(new Point(10, 0));
					}
					if (GameEngine.scrollRight)
					{
						this.village.Camera.Drag(new Point(-10, 0));
					}
					if (GameEngine.scrollUp)
					{
						this.village.Camera.Drag(new Point(0, 10));
					}
					if (GameEngine.scrollDown)
					{
						this.village.Camera.Drag(new Point(0, -10));
					}
				}
				else if (this.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_WORLD)
				{
					if (GameEngine.scrollLeft)
					{
						this.world.moveMap(0.0 - 10.0 / this.world.WorldScale, 0.0);
					}
					if (GameEngine.scrollRight)
					{
						this.world.moveMap(10.0 / this.world.WorldScale, 0.0);
					}
					if (GameEngine.scrollUp)
					{
						this.world.moveMap(0.0, 0.0 - 10.0 / this.world.WorldScale);
					}
					if (GameEngine.scrollDown)
					{
						this.world.moveMap(0.0, 10.0 / this.world.WorldScale);
					}
				}
				else if (this.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_CASTLE)
				{
					CastleMap castleMap = this.castle;
					if (this.gameDisplayModeSubMode == GameEngine.GameDisplaySubModes.SUBMODE_CASTLE_ATTACKER_SETUP)
					{
						castleMap = this.castle_AttackerSetup;
					}
					else if (this.gameDisplayModeSubMode == GameEngine.GameDisplaySubModes.SUBMODE_BATTLE)
					{
						castleMap = this.castle_Battle;
					}
					else if (this.gameDisplayModeSubMode == GameEngine.GameDisplaySubModes.SUBMODE_PREVIEW)
					{
						castleMap = this.castle_Preview;
					}
					if (castleMap != null)
					{
						if (GameEngine.scrollLeft)
						{
							castleMap.moveMap(10, 0);
						}
						if (GameEngine.scrollRight)
						{
							castleMap.moveMap(-10, 0);
						}
						if (GameEngine.scrollUp)
						{
							castleMap.moveMap(0, 10);
						}
						if (GameEngine.scrollDown)
						{
							castleMap.moveMap(0, -10);
						}
					}
				}
			}
			if (!this.WindowActive)
			{
				return;
			}
			if (GameEngine.f11Pressed)
			{
				GameEngine.f11Pressed = false;
				if (InterfaceMgr.Instance.ParentForm != null && InterfaceMgr.Instance.ParentForm.Visible)
				{
					if (InterfaceMgr.Instance.ParentForm.FormBorderStyle == FormBorderStyle.Sizable)
					{
						InterfaceMgr.Instance.ParentForm.FormBorderStyle = FormBorderStyle.None;
						return;
					}
					if (InterfaceMgr.Instance.ParentForm.WindowState == FormWindowState.Maximized)
					{
						InterfaceMgr.Instance.ParentForm.Visible = false;
						InterfaceMgr.Instance.ParentForm.WindowState = FormWindowState.Normal;
						Program.DoEvents();
						Thread.Sleep(100);
						InterfaceMgr.Instance.ParentForm.FormBorderStyle = FormBorderStyle.Sizable;
						Program.DoEvents();
						InterfaceMgr.Instance.ParentForm.WindowState = FormWindowState.Maximized;
						InterfaceMgr.Instance.ParentForm.Visible = true;
						Program.DoEvents();
						InterfaceMgr.Instance.ParentForm.Invalidate();
						return;
					}
					InterfaceMgr.Instance.ParentForm.FormBorderStyle = FormBorderStyle.Sizable;
				}
				return;
			}
			if (InterfaceMgr.Instance.getDXBasePanel().Visible)
			{
				if (this.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_VILLAGE)
				{
					VillageInputHandler villageInputHandler = new VillageInputHandler(this.village);
					villageInputHandler.handleInput(inputState);
				}
				else if (this.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_WORLD)
				{
					WorldMapInputHandler worldMapInputHandler = new WorldMapInputHandler(this.world);
					worldMapInputHandler.handleInput(inputState);
				}
				else if (this.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_CASTLE)
				{
					CastleMap castlemap = this.castle;
					if (this.gameDisplayModeSubMode == GameEngine.GameDisplaySubModes.SUBMODE_CASTLE_ATTACKER_SETUP)
					{
						castlemap = this.castle_AttackerSetup;
					}
					else if (this.gameDisplayModeSubMode == GameEngine.GameDisplaySubModes.SUBMODE_BATTLE)
					{
						castlemap = this.castle_Battle;
					}
					else if (this.gameDisplayModeSubMode == GameEngine.GameDisplaySubModes.SUBMODE_PREVIEW)
					{
						castlemap = this.castle_Preview;
					}
					CastleMouseInputHandler castleMouseInputHandler = new CastleMouseInputHandler(castlemap, this.gameDisplayModeSubMode);
					castleMouseInputHandler.handleInput(inputState);
				}
			}
			this.gfx.clearInput();
		}

		// Token: 0x06001273 RID: 4723 RVA: 0x00013E80 File Offset: 0x00012080
		public void resolutionButtonChange(int newRes)
		{
			if (newRes <= this.maxResolution)
			{
				this.newResolution = newRes;
			}
		}

		// Token: 0x06001274 RID: 4724 RVA: 0x00013E92 File Offset: 0x00012092
		public bool resolutionChange()
		{
			return this.newResolution != -1;
		}

		// Token: 0x06001275 RID: 4725 RVA: 0x00013EA0 File Offset: 0x000120A0
		public void worldZoomChange(double worldZoom, bool redraw)
		{
			this.world.WorldZoom = worldZoom;
			if (redraw)
			{
				this.run();
			}
		}

		// Token: 0x06001276 RID: 4726 RVA: 0x00013EB7 File Offset: 0x000120B7
		public void ResetVillageIfChangedFromCapital()
		{
			if (this.MovedFromVillageID >= 0)
			{
				if (InterfaceMgr.Instance.getMainTabBar().getCurrentTab() == 0)
				{
					this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_WORLD;
				}
				InterfaceMgr.Instance.selectUserVillage(this.MovedFromVillageID, false);
			}
		}

		// Token: 0x06001277 RID: 4727 RVA: 0x00135B28 File Offset: 0x00133D28
		public void forceResetVillageIfChangedFromCapital()
		{
			if (!this.World.isCapital(InterfaceMgr.Instance.getSelectedMenuVillage()))
			{
				return;
			}
			if (this.MovedFromVillageID >= 0 && !this.World.isCapital(this.MovedFromVillageID))
			{
				InterfaceMgr.Instance.selectUserVillage(this.MovedFromVillageID, false);
				return;
			}
			if (this.movedFromVillageIDNonCapital >= 0 && !this.World.isCapital(this.movedFromVillageIDNonCapital))
			{
				InterfaceMgr.Instance.selectUserVillage(this.movedFromVillageIDNonCapital, false);
				return;
			}
			int num = this.MovedFromVillageID;
			List<int> userVillageIDList = this.World.getUserVillageIDList();
			if (userVillageIDList.Count > 0)
			{
				InterfaceMgr.Instance.selectUserVillage(userVillageIDList[0], false);
			}
			this.MovedFromVillageID = num;
		}

		// Token: 0x06001278 RID: 4728 RVA: 0x00013EEB File Offset: 0x000120EB
		public void externalMainTabChange(int tabID)
		{
			this.lastTabID = tabID;
		}

		// Token: 0x06001279 RID: 4729 RVA: 0x00135BE0 File Offset: 0x00133DE0
		public void mainTabChange(int tabID)
		{
			if (this.lastTabID == tabID && tabID != 9)
			{
				return;
			}
			if (this.lastTabID == 0 && tabID != 0 && this.World.playbackActive())
			{
				this.World.stopPlayback();
			}
			if (tabID == 1)
			{
				int selectedMenuVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
				if (selectedMenuVillage < 0)
				{
					InterfaceMgr.Instance.StopDrawing();
					InterfaceMgr.Instance.getMainTabBar().changeTab(this.lastTabID);
					InterfaceMgr.Instance.StartDrawing();
					return;
				}
			}
			InterfaceMgr.Instance.StopDrawing();
			this.previousTabID = this.lastTabID;
			this.lastTabID = tabID;
			InterfaceMgr.Instance.clearControls();
			this.gameDisplayModeSubMode = GameEngine.GameDisplaySubModes.SUBMODE_DEFAULT;
			StatTrackingClient.Instance().ActivateTrigger(1, tabID);
			if (tabID != 1)
			{
				this.lastLoadedVillage = -1;
			}
			switch (tabID)
			{
			case 0:
				this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_WORLD;
				this.gfx.BGColor = WorldMap.SEACOLOR;
				InterfaceMgr.Instance.initWorldTab();
				InterfaceMgr.Instance.selectCurrentUserVillage();
				break;
			case 1:
				this.lastVillageTabID = -1;
				InterfaceMgr.Instance.showVillageTabBar();
				InterfaceMgr.Instance.getVillageTabBar().forceChangeTab(0);
				break;
			case 2:
			{
				int selectedMenuVillage2 = InterfaceMgr.Instance.getSelectedMenuVillage();
				if (InterfaceMgr.Instance.isSelectedVillageACapital())
				{
					this.lastVillageTabID = -1;
					InterfaceMgr.Instance.showVillageTabBar();
					InterfaceMgr.Instance.getVillageTabBar().forceChangeTab(5);
					this.MovedFromVillageID = selectedMenuVillage2;
				}
				else
				{
					int parishFromVillageID = this.World.getParishFromVillageID(selectedMenuVillage2);
					int parishCapital = this.World.getParishCapital(parishFromVillageID);
					if (parishCapital >= 0)
					{
						this.lastVillageTabID = -1;
						InterfaceMgr.Instance.showVillageTabBar();
						InterfaceMgr.Instance.selectUserVillage(parishCapital, false);
						InterfaceMgr.Instance.getVillageTabBar().forceChangeTab(5);
						this.MovedFromVillageID = selectedMenuVillage2;
					}
					else
					{
						InterfaceMgr.Instance.getMainTabBar().changeTab(0);
					}
				}
				break;
			}
			case 3:
				this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_RESEARCH;
				InterfaceMgr.Instance.addMainWindow(this.m_firstDrawResearch, true);
				this.m_firstDrawResearch = false;
				InterfaceMgr.Instance.initResearchTab();
				break;
			case 4:
				this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_RANKINGS;
				InterfaceMgr.Instance.addMainWindow(this.m_firstDrawRank, true);
				this.m_firstDrawRank = false;
				InterfaceMgr.Instance.initRankingsTab();
				break;
			case 5:
				this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_QUESTS;
				InterfaceMgr.Instance.addMainWindow(this.m_firstDrawQuest, true);
				this.m_firstDrawQuest = false;
				InterfaceMgr.Instance.initQuestsTab();
				break;
			case 6:
				this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_ARMIES;
				InterfaceMgr.Instance.addMainWindow(this.m_firstDrawArmy, true);
				this.m_firstDrawArmy = false;
				InterfaceMgr.Instance.initAllArmiesTab();
				break;
			case 7:
				this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_REPORTS;
				InterfaceMgr.Instance.addMainWindow(this.m_firstDrawReports, false);
				this.m_firstDrawReports = false;
				InterfaceMgr.Instance.initReportTab();
				break;
			case 8:
				this.lastVillageTabID = -1;
				this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_FACTIONS;
				InterfaceMgr.Instance.showFactionTabBar();
				if (this.nextFactionPage < 0 || this.nextFactionPage == 65)
				{
					InterfaceMgr.Instance.getFactionTabBar().forceChangeTab(0);
				}
				else if (this.nextFactionPage == 52 || this.nextFactionPage == 51)
				{
					InterfaceMgr.Instance.getFactionTabBar().forceChangeTab(2);
				}
				else
				{
					InterfaceMgr.Instance.getFactionTabBar().forceChangeTab(1);
				}
				break;
			case 9:
			{
				int num = MainTabBar2.LastDummyMode = MainTabBar2.DummyMode;
				MainTabBar2.DummyMode = 0;
				if (num <= 31)
				{
					switch (num)
					{
					case -14:
					case 14:
						this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_WORLD;
						this.gfx.BGColor = WorldMap.SEACOLOR;
						InterfaceMgr.Instance.initWorldTab_monkSelect();
						goto IL_6BE;
					case -13:
					case 13:
						this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_WORLD;
						this.gfx.BGColor = WorldMap.SEACOLOR;
						InterfaceMgr.Instance.initWorldTab_vassalSelect();
						goto IL_6BE;
					case -12:
					case -10:
					case -9:
					case -8:
					case -6:
					case -2:
					case -1:
					case 0:
					case 8:
					case 9:
					case 12:
					case 15:
					case 16:
					case 17:
					case 18:
					case 19:
					case 20:
						break;
					case -11:
					case 11:
						this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_WORLD;
						this.gfx.BGColor = WorldMap.SEACOLOR;
						InterfaceMgr.Instance.initWorldTab_courtierTargetSelect();
						goto IL_6BE;
					case -7:
					case 7:
						this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_WORLD;
						this.gfx.BGColor = WorldMap.SEACOLOR;
						InterfaceMgr.Instance.initWorldTab_scoutTargetSelect();
						goto IL_6BE;
					case -5:
					case 5:
						this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_WORLD;
						this.gfx.BGColor = WorldMap.SEACOLOR;
						InterfaceMgr.Instance.initWorldTab_attackTargetSelect();
						goto IL_6BE;
					case -4:
					case 4:
						this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_WORLD;
						this.gfx.BGColor = WorldMap.SEACOLOR;
						InterfaceMgr.Instance.initWorldTab_stockExchangeSelect();
						goto IL_6BE;
					case -3:
					case 3:
						this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_WORLD;
						this.gfx.BGColor = WorldMap.SEACOLOR;
						InterfaceMgr.Instance.initWorldTab_tradingVillageSelect();
						goto IL_6BE;
					case 1:
					case 2:
					case 6:
						goto IL_6BE;
					case 10:
						this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_AVATAR_EDITOR;
						InterfaceMgr.Instance.getTopRightMenu().showVillageTab(false);
						InterfaceMgr.Instance.addMainWindow(this.m_firstDrawDummy, true);
						this.m_firstDrawDummy = false;
						InterfaceMgr.Instance.setVillageTabSubMode(10);
						goto IL_6BE;
					case 21:
						if (InterfaceMgr.Instance.isMailDocked())
						{
							this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_MAIL;
							InterfaceMgr.Instance.addMainWindow(this.m_firstDrawMail, true);
							this.m_firstDrawMail = false;
						}
						InterfaceMgr.Instance.initMailSubTab(0);
						goto IL_6BE;
					case 22:
						this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_LEADERBOARD;
						InterfaceMgr.Instance.addMainWindow(this.m_firstDrawLeaderboard, true);
						this.m_firstDrawLeaderboard = false;
						InterfaceMgr.Instance.initReportsLeaderboard();
						goto IL_6BE;
					default:
						if (num == 30)
						{
							this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_CONTESTS_LEADERBOARD;
							InterfaceMgr.Instance.addMainWindow(this.m_firstDrawLeaderboard, true);
							this.m_firstDrawLeaderboard = false;
							InterfaceMgr.Instance.initContestsLeaderboard();
							goto IL_6BE;
						}
						if (num == 31)
						{
							this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_CONTESTS_HISTORY;
							InterfaceMgr.Instance.addMainWindow(this.m_firstDrawLeaderboard, true);
							this.m_firstDrawLeaderboard = false;
							InterfaceMgr.Instance.initContestHistory();
							goto IL_6BE;
						}
						break;
					}
				}
				else
				{
					if (num == 50)
					{
						this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_VILLAGE;
						this.gfx.BGColor = global::ARGBColors.Black;
						InterfaceMgr.Instance.initVillageTabView();
						break;
					}
					if (num == 60)
					{
						InterfaceMgr.Instance.setVillageTabSubMode(60);
						break;
					}
					if (num == 100)
					{
						this.gfx.BGColor = global::ARGBColors.Black;
						InterfaceMgr.Instance.showAllVillagesScreen();
						break;
					}
				}
				InterfaceMgr.Instance.addMainWindow(this.m_firstDrawDummy, true);
				this.m_firstDrawDummy = false;
				break;
			}
			}
			IL_6BE:
			InterfaceMgr.Instance.StartDrawing();
		}

		// Token: 0x0600127A RID: 4730 RVA: 0x00013EF4 File Offset: 0x000120F4
		public void forceVillageTabUpdate()
		{
			this.lastVillageTabID = -1;
		}

		// Token: 0x0600127B RID: 4731 RVA: 0x00013EFD File Offset: 0x000120FD
		public void SkipVillageTab()
		{
			this.skipVillageTab = true;
		}

		// Token: 0x0600127C RID: 4732 RVA: 0x001362B8 File Offset: 0x001344B8
		public void villageTabChange(int tabID)
		{
			if (this.lastVillageTabID == tabID && tabID != 9 && this.gameDisplayModeSubMode != GameEngine.GameDisplaySubModes.SUBMODE_PREVIEW)
			{
				return;
			}
			InterfaceMgr.Instance.StopDrawing();
			InterfaceMgr.Instance.getVillageTabBar().updateShownTabs();
			this.lastVillageTabID = tabID;
			if (tabID <= 1)
			{
				InterfaceMgr.Instance.clearControls();
			}
			else
			{
				InterfaceMgr.Instance.clearControls(false, false, true, true);
			}
			this.gameDisplayModeSubMode = GameEngine.GameDisplaySubModes.SUBMODE_DEFAULT;
			if (InterfaceMgr.Instance.getSelectedMenuVillage() != this.lastLoadedVillage)
			{
				this.downloadCurrentVillage();
			}
			switch (tabID)
			{
			case 0:
			{
				this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_VILLAGE;
				this.gfx.BGColor = global::ARGBColors.Black;
				if (!this.skipVillageTab)
				{
					InterfaceMgr.Instance.initVillageTab();
				}
				VillageMap villageMap = this.getVillage(InterfaceMgr.Instance.getSelectedMenuVillage());
				if (villageMap != null)
				{
					villageMap.playEnvironmentalSounds();
				}
				this.skipVillageTab = false;
				break;
			}
			case 1:
				this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_CASTLE;
				StatTrackingClient.Instance().ActivateTrigger(2, null);
				this.gfx.BGColor = global::ARGBColors.Black;
				InterfaceMgr.Instance.initCastleTab();
				this.World.handleQuestObjectiveHappening(10004);
				break;
			case 2:
				this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_VILLAGE;
				InterfaceMgr.Instance.initVillageTabTabBarsOnly();
				if (!InterfaceMgr.Instance.isSelectedVillageACapital())
				{
					InterfaceMgr.Instance.setVillageTabSubMode(5);
				}
				else
				{
					InterfaceMgr.Instance.setVillageTabSubMode(1005);
				}
				break;
			case 3:
				this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_VILLAGE;
				InterfaceMgr.Instance.initVillageTabTabBarsOnly();
				if (!InterfaceMgr.Instance.isSelectedVillageACapital())
				{
					InterfaceMgr.Instance.setVillageTabSubMode(3);
				}
				else
				{
					InterfaceMgr.Instance.setVillageTabSubMode(1003);
				}
				break;
			case 4:
				this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_VILLAGE;
				InterfaceMgr.Instance.initVillageTabTabBarsOnly();
				if (!InterfaceMgr.Instance.isSelectedVillageACapital())
				{
					InterfaceMgr.Instance.setVillageTabSubMode(4);
				}
				else
				{
					InterfaceMgr.Instance.setVillageTabSubMode(1004);
				}
				break;
			case 5:
				this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_VILLAGE;
				InterfaceMgr.Instance.initVillageTabTabBarsOnly();
				if (!InterfaceMgr.Instance.isSelectedVillageACapital())
				{
					InterfaceMgr.Instance.setVillageTabSubMode(18);
				}
				else if (InterfaceMgr.Instance.isSelectedVillageAParishCapital())
				{
					InterfaceMgr.Instance.setVillageTabSubMode(1008);
				}
				else if (InterfaceMgr.Instance.isSelectedVillageACountyCapital())
				{
					InterfaceMgr.Instance.setVillageTabSubMode(1108);
				}
				else if (InterfaceMgr.Instance.isSelectedVillageAProvinceCapital())
				{
					InterfaceMgr.Instance.setVillageTabSubMode(1208);
				}
				else if (InterfaceMgr.Instance.isSelectedVillageACountryCapital())
				{
					InterfaceMgr.Instance.setVillageTabSubMode(1308);
				}
				break;
			case 6:
				this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_VILLAGE;
				InterfaceMgr.Instance.initVillageTabTabBarsOnly();
				if (!InterfaceMgr.Instance.isSelectedVillageACapital())
				{
					InterfaceMgr.Instance.setVillageTabSubMode(1);
				}
				else if (InterfaceMgr.Instance.isSelectedVillageAParishCapital())
				{
					InterfaceMgr.Instance.setVillageTabSubMode(1006);
				}
				else if (InterfaceMgr.Instance.isSelectedVillageACountyCapital())
				{
					InterfaceMgr.Instance.setVillageTabSubMode(1106);
				}
				else if (InterfaceMgr.Instance.isSelectedVillageAProvinceCapital())
				{
					InterfaceMgr.Instance.setVillageTabSubMode(1206);
				}
				else if (InterfaceMgr.Instance.isSelectedVillageACountryCapital())
				{
					InterfaceMgr.Instance.setVillageTabSubMode(1306);
				}
				break;
			case 7:
				this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_VILLAGE;
				InterfaceMgr.Instance.initVillageTabTabBarsOnly();
				if (!InterfaceMgr.Instance.isSelectedVillageACapital())
				{
					InterfaceMgr.Instance.setVillageTabSubMode(8);
				}
				else if (InterfaceMgr.Instance.isSelectedVillageAParishCapital())
				{
					InterfaceMgr.Instance.setVillageTabSubMode(1007);
				}
				else if (InterfaceMgr.Instance.isSelectedVillageACountyCapital())
				{
					InterfaceMgr.Instance.setVillageTabSubMode(1107);
				}
				else if (InterfaceMgr.Instance.isSelectedVillageAProvinceCapital())
				{
					InterfaceMgr.Instance.setVillageTabSubMode(1207);
				}
				else if (InterfaceMgr.Instance.isSelectedVillageACountryCapital())
				{
					InterfaceMgr.Instance.setVillageTabSubMode(1307);
				}
				break;
			case 8:
				InterfaceMgr.Instance.initVillageTabTabBarsOnly();
				break;
			}
			InterfaceMgr.Instance.StartDrawing();
		}

		// Token: 0x0600127D RID: 4733 RVA: 0x00013F06 File Offset: 0x00012106
		public void setNextFactionPage(int pageID)
		{
			this.nextFactionPage = pageID;
		}

		// Token: 0x0600127E RID: 4734 RVA: 0x00013F0F File Offset: 0x0001210F
		public void forceFactionTabChange()
		{
			this.lastFactionTabID = -1;
		}

		// Token: 0x0600127F RID: 4735 RVA: 0x001366D4 File Offset: 0x001348D4
		public void factionTabChange(int tabID)
		{
			if (this.lastFactionTabID == tabID && tabID != 9)
			{
				return;
			}
			InterfaceMgr.Instance.StopDrawing();
			InterfaceMgr.Instance.getFactionTabBar().updateShownTabs();
			this.lastFactionTabID = tabID;
			InterfaceMgr.Instance.clearControls();
			this.gameDisplayModeSubMode = GameEngine.GameDisplaySubModes.SUBMODE_DEFAULT;
			switch (tabID)
			{
			case 0:
				this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_FACTIONS;
				InterfaceMgr.Instance.addMainWindow(this.m_firstDrawFactions, true);
				this.m_firstDrawFactions = false;
				if (this.nextFactionPage == 65)
				{
					InterfaceMgr.Instance.setVillageTabSubMode(this.nextFactionPage, false);
				}
				else
				{
					InterfaceMgr.Instance.initGloryTab();
				}
				break;
			case 1:
				this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_FACTIONS;
				if (this.nextFactionPage >= 0 && this.nextFactionPage != 999)
				{
					InterfaceMgr.Instance.setVillageTabSubMode(this.nextFactionPage, false);
				}
				else if (RemoteServices.Instance.UserFactionID >= 0)
				{
					InterfaceMgr.Instance.showFactionPanel(RemoteServices.Instance.UserFactionID);
				}
				else
				{
					InterfaceMgr.Instance.setVillageTabSubMode(41, false);
				}
				this.nextFactionPage = -1;
				break;
			case 2:
				this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_FACTIONS;
				if (this.nextFactionPage >= 0)
				{
					InterfaceMgr.Instance.setVillageTabSubMode(this.nextFactionPage, false);
				}
				else
				{
					InterfaceMgr.Instance.setVillageTabSubMode(51, false);
				}
				this.nextFactionPage = -1;
				break;
			}
			InterfaceMgr.Instance.StartDrawing();
		}

		// Token: 0x06001280 RID: 4736 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void politicsTabChange(int tabID)
		{
		}

		// Token: 0x06001281 RID: 4737 RVA: 0x00136834 File Offset: 0x00134A34
		public void preAttackSetup(int parentVillageID, int attackingVillageID, int targetVillageID)
		{
			RemoteServices.Instance.set_PreAttackSetup_UserCallBack(new RemoteServices.PreAttackSetup_UserCallBack(this.preAttackSetupCallback));
			RemoteServices.Instance.PreAttackSetup(parentVillageID, attackingVillageID, targetVillageID, 0, 0, 0, 0, 0, 0, 0, 0);
		}

		// Token: 0x06001282 RID: 4738 RVA: 0x0013686C File Offset: 0x00134A6C
		public void preAttackSetupCallback(PreAttackSetup_ReturnType returnData)
		{
			if (returnData.protectedVillage)
			{
				MyMessageBox.Show(SK.Text("GameEngine_Protected_Interdiction", "This village is protected from attack by an Interdiction."), SK.Text("GENERIC_Village_Protected", "Village Protected"));
				InterfaceMgr.Instance.getMainTabBar().changeTab(9);
				InterfaceMgr.Instance.getMainTabBar().changeTab(0);
				return;
			}
			if (returnData.vacationVillage)
			{
				MyMessageBox.Show(SK.Text("GameEngine_Protected_Vacation", "This village is protected from attack by Vacation Mode."), SK.Text("GENERIC_Village_Protected", "Village Protected"));
				InterfaceMgr.Instance.getMainTabBar().changeTab(9);
				InterfaceMgr.Instance.getMainTabBar().changeTab(0);
				return;
			}
			if (returnData.vassalVacation)
			{
				MyMessageBox.Show(SK.Text("GameEngine_Vassal_Vacation", "Your vassal is in Vacation Mode and you cannot attack from here."), SK.Text("GENERIC_Cannot_Attack_Target", "Cannot Attack Target"));
				InterfaceMgr.Instance.getMainTabBar().changeTab(9);
				InterfaceMgr.Instance.getMainTabBar().changeTab(0);
				return;
			}
			if (returnData.peaceVillage)
			{
				if (!this.world.isCapital(returnData.targetVillage))
				{
					MyMessageBox.Show(SK.Text("GameEngine_Protected_Peacetime", "This village is within Peace Time and cannot be attacked."), SK.Text("GENERIC_Village_Protected", "Village Protected"));
				}
				else
				{
					MyMessageBox.Show(SK.Text("GameEngine_Protected_Peacetime_Capital", "This capital is within peace time and cannot be attacked."), SK.Text("GENERIC_Capital_Protected", "Capital Protected"));
				}
				InterfaceMgr.Instance.getMainTabBar().changeTab(9);
				InterfaceMgr.Instance.getMainTabBar().changeTab(0);
				return;
			}
			if (returnData.peaceAttacker)
			{
				if (returnData.parentAttackingVillage != returnData.attackingVillage)
				{
					MyMessageBox.Show(SK.Text("GameEngine_Cannot_Attack_PeaceTime", "You are within Peace Time and cannot attack from this village."), SK.Text("GENERIC_Village_Protected", "Village Protected"));
					InterfaceMgr.Instance.getMainTabBar().changeTab(9);
					InterfaceMgr.Instance.getMainTabBar().changeTab(0);
					return;
				}
				MessageBoxButtons buts = MessageBoxButtons.YesNo;
				DialogResult dialogResult = MyMessageBox.Show(SK.Text("GameEngine_Currently_Peacetime", "You are currently Peace Time protected") + "\n" + SK.Text("GameEngine_CancelProtection", "Do you wish to cancel this protection?"), SK.Text("GENERIC_Village_Protected", "Village Protected"), buts);
				if (dialogResult == DialogResult.Yes)
				{
					this.sentParentVillageID = returnData.parentAttackingVillage;
					this.sentAttackingVillageID = returnData.attackingVillage;
					this.sentTargetVillageID = returnData.targetVillage;
					RemoteServices.Instance.set_CancelInterdiction_UserCallBack(new RemoteServices.CancelInterdiction_UserCallBack(this.cancelInterdictionCallback));
					RemoteServices.Instance.CancelInterdiction(returnData.attackingVillage);
					return;
				}
				InterfaceMgr.Instance.getMainTabBar().changeTab(9);
				InterfaceMgr.Instance.getMainTabBar().changeTab(0);
				return;
			}
			else if (returnData.protectedAttacker)
			{
				if (returnData.parentAttackingVillage != returnData.attackingVillage)
				{
					MyMessageBox.Show(SK.Text("GameEngine_Currently_Interdited_Vassal", "Your vassal is protected by Interdiction and you cannot attack from this village."), SK.Text("GameEngine_Currently_Interdited_protected", "Your Vassal is Protected"));
					InterfaceMgr.Instance.getMainTabBar().changeTab(9);
					InterfaceMgr.Instance.getMainTabBar().changeTab(0);
					return;
				}
				MessageBoxButtons buts2 = MessageBoxButtons.YesNo;
				DialogResult dialogResult2 = MyMessageBox.Show(SK.Text("GameEngine_Currently_Interdited", "You are currently Interdiction protected") + "\n" + SK.Text("GameEngine_CancelProtection", "Do you wish to cancel this protection?"), SK.Text("GENERIC_Protected", "You Are Protected"), buts2);
				if (dialogResult2 != DialogResult.Yes)
				{
					InterfaceMgr.Instance.getMainTabBar().changeTab(9);
					InterfaceMgr.Instance.getMainTabBar().changeTab(0);
					return;
				}
				this.sentParentVillageID = returnData.parentAttackingVillage;
				this.sentAttackingVillageID = returnData.attackingVillage;
				this.sentTargetVillageID = returnData.targetVillage;
				RemoteServices.Instance.set_CancelInterdiction_UserCallBack(new RemoteServices.CancelInterdiction_UserCallBack(this.cancelInterdictionCallback));
				if (this.LocalWorldData.AIWorld)
				{
					RemoteServices.Instance.CancelInterdiction(-returnData.attackingVillage);
					return;
				}
				RemoteServices.Instance.CancelInterdiction(returnData.attackingVillage);
				return;
			}
			else
			{
				if (!returnData.Success)
				{
					ErrorCodes.ErrorCode errorCode = returnData.m_errorCode;
					if (errorCode == ErrorCodes.ErrorCode.ATTACKING_NOT_ENOUGH_TROOPS || errorCode == ErrorCodes.ErrorCode.ATTACKING_INVALID_TARGET)
					{
						MyMessageBox.Show(ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID), SK.Text("GENERIC_Attack_Error", "Attack Error"));
					}
					return;
				}
				int num = 0;
				if (returnData.battleHonourData != null)
				{
					returnData.battleHonourData.attackType = 11;
					if (!GameEngine.Instance.World.isCapital(returnData.parentAttackingVillage))
					{
						num = CastlesCommon.calcBattleHonourCost(returnData.battleHonourData, GameEngine.Instance.LocalWorldData.Alternate_Ruleset, GameEngine.Instance.LocalWorldData.EraWorld);
					}
				}
				if (num > 0 && this.World.getCurrentHonour() <= 0.0)
				{
					MyMessageBox.Show(SK.Text("GameEngine_Require_Honour_To_Attack", "You require honour to attack this target."), SK.Text("GENERIC_Attack_Error", "Attack Error"));
					return;
				}
				this.InitCastleAttackSetup(returnData.castleMapSnapshot, returnData.castleTroopsSnapshot, returnData.keepLevel, returnData.numPeasants, returnData.numArchers, returnData.numPikemen, returnData.numSwordsmen, returnData.numCatapults, returnData.attackingVillage, returnData.targetVillage, returnData.attackType, returnData.pillagePercent, returnData.captainsCommand, returnData.parentAttackingVillage, returnData.numPeasantsInCastle, returnData.numArchersInCastle, returnData.numPikemenInCastle, returnData.numSwordsmenInCastle, returnData.targetUserID, returnData.targetUserName, returnData.battleHonourData, returnData.numCaptainsInCastle, returnData.numCaptains, returnData.landType, returnData.capitalAttackRate);
				InterfaceMgr.Instance.setCastleViewTimes(returnData.lastCastleTime, returnData.castleMapSnapshot != null, returnData.lastTroopTime, returnData.castleTroopsSnapshot != null);
				return;
			}
		}

		// Token: 0x06001283 RID: 4739 RVA: 0x00136DD0 File Offset: 0x00134FD0
		public void cancelInterdictionCallback(CancelInterdiction_ReturnType returnData)
		{
			if (returnData.Success)
			{
				RemoteServices.Instance.set_PreAttackSetup_UserCallBack(new RemoteServices.PreAttackSetup_UserCallBack(this.preAttackSetupCallback));
				RemoteServices.Instance.PreAttackSetup(this.sentParentVillageID, this.sentAttackingVillageID, this.sentTargetVillageID, 0, 0, 0, 0, 0, 0, 0, 0);
			}
		}

		// Token: 0x06001284 RID: 4740 RVA: 0x00136E20 File Offset: 0x00135020
		public void InitCastleAttackSetup()
		{
			InterfaceMgr.Instance.clearControls();
			if (this.castle_AttackerSetup == null)
			{
				this.castle_AttackerSetup = new CastleMap(-1, this.gfx, 1);
			}
			this.castle_AttackerSetup.castleShown(false);
			this.castle_AttackerSetup.reInitGFX();
			if (this.castle == null)
			{
				this.castle_AttackerSetup.importDefenderSnapshot(null, null, 0, false, 0);
			}
			else
			{
				this.castle_AttackerSetup.importDefenderSnapshot(this.castle.generateCastleMapSnapshot(), this.castle.generateCastleTroopsSnapshot(), 0, false, 0);
			}
			this.castle_AttackerSetup.initFakeSetup();
			this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_CASTLE;
			this.gameDisplayModeSubMode = GameEngine.GameDisplaySubModes.SUBMODE_CASTLE_ATTACKER_SETUP;
			this.gfx.BGColor = global::ARGBColors.Black;
			InterfaceMgr.Instance.initCastleAttackerSetupTab();
		}

		// Token: 0x06001285 RID: 4741 RVA: 0x00136EDC File Offset: 0x001350DC
		public void InitCastleAttackSetup(byte[] castleMap, byte[] defenderMap, int keepLevel, int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults, int attackingVillage, int targetVillage, int attackType, int pillagePercent, int captainsCommand, int parentOfAttackingVillage, int numPeasantsInCastle, int numArchersInCastle, int numPikemenInCastle, int numSwordsmenInCastle, int targetUserID, string targetUserName, BattleHonourData honourData, int numCaptainsInCastle, int numCaptains, int landType, double capitalAttackRate)
		{
			try
			{
				InterfaceMgr.Instance.clearControls();
				if (this.castle_AttackerSetup == null)
				{
					this.castle_AttackerSetup = new CastleMap(-1, this.gfx, 1);
				}
				this.castle_AttackerSetup.castleShown(false);
				this.castle_AttackerSetup.reInitGFX();
				int campMode = 0;
				int special = this.World.getSpecial(targetVillage);
				if (special != 3)
				{
					if (special == 5)
					{
						campMode = 2;
					}
				}
				else
				{
					campMode = 1;
				}
				this.castle_AttackerSetup.setCampMode(campMode);
				this.castle_AttackerSetup.importDefenderSnapshot(castleMap, defenderMap, keepLevel, true, landType);
				this.castle_AttackerSetup.initRealSetup(attackingVillage, targetVillage, numPeasants, numArchers, numPikemen, numSwordsmen, numCatapults, attackType, pillagePercent, captainsCommand, parentOfAttackingVillage, numPeasantsInCastle, numArchersInCastle, numPikemenInCastle, numSwordsmenInCastle, targetUserID, targetUserName, honourData, numCaptainsInCastle, numCaptains, capitalAttackRate);
				this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_CASTLE;
				this.gameDisplayModeSubMode = GameEngine.GameDisplaySubModes.SUBMODE_CASTLE_ATTACKER_SETUP;
				this.gfx.BGColor = global::ARGBColors.Black;
				InterfaceMgr.Instance.initCastleAttackerSetupTab();
			}
			catch (Exception ex)
			{
				UniversalDebugLog.Log(string.Concat(new object[]
				{
					ex.ToString(),
					" values = ",
					castleMap,
					defenderMap,
					keepLevel,
					numPeasants,
					numArchers,
					numPikemen,
					numSwordsmen,
					numCatapults,
					attackingVillage,
					targetVillage,
					attackType,
					pillagePercent,
					captainsCommand,
					parentOfAttackingVillage,
					numPeasantsInCastle,
					numArchersInCastle
				}));
			}
		}

		// Token: 0x06001286 RID: 4742 RVA: 0x00137098 File Offset: 0x00135298
		public void InitCastlePreview(CastleMapPreset preset)
		{
			InterfaceMgr.Instance.clearControls();
			if (this.castle_Preview == null)
			{
				this.castle_Preview = new CastleMap(-1, this.gfx, 4);
			}
			this.castle_Preview.castleShown(false);
			this.castle_Preview.reInitGFX();
			List<CastleElement> list = new List<CastleElement>();
			foreach (CastleMapPreset.CastleElementInfo castleElementInfo in preset.BasicData)
			{
				list.Add(new CastleElement
				{
					elementType = castleElementInfo.elementType,
					xPos = castleElementInfo.xPos,
					yPos = castleElementInfo.yPos,
					reinforcement = castleElementInfo.reinforcement,
					aggressiveDefender = false,
					completionTime = DateTime.MinValue,
					damage = 0f,
					elementID = -1L
				});
			}
			this.castle_Preview.importElements(list);
			this.castle_Preview.initFakeSetup();
			this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_CASTLE;
			this.gameDisplayModeSubMode = GameEngine.GameDisplaySubModes.SUBMODE_PREVIEW;
			this.gfx.BGColor = global::ARGBColors.Black;
		}

		// Token: 0x06001287 RID: 4743 RVA: 0x001371C0 File Offset: 0x001353C0
		public void InitBattle(int keepType, int fakeDefensiveMode)
		{
			CastleResearchData castleResearchData = new CastleResearchData();
			CastleResearchData castleResearchData2 = new CastleResearchData();
			switch (fakeDefensiveMode)
			{
			case 0:
				castleResearchData.catapult = 0;
				castleResearchData.conscription = 0;
				castleResearchData.longBow = 0;
				castleResearchData.pike = 0;
				castleResearchData.sword = 0;
				keepType = 1;
				break;
			case 1:
				castleResearchData.defences = 4;
				keepType = 3;
				castleResearchData.catapult = 2;
				castleResearchData.conscription = 2;
				castleResearchData.longBow = 2;
				castleResearchData.pike = 2;
				castleResearchData.sword = 2;
				break;
			case 2:
				castleResearchData.defences = 8;
				castleResearchData.sallyForth = 2;
				keepType = 5;
				castleResearchData.catapult = 4;
				castleResearchData.conscription = 4;
				castleResearchData.longBow = 4;
				castleResearchData.pike = 4;
				castleResearchData.sword = 4;
				break;
			case 3:
				castleResearchData.defences = 10;
				castleResearchData.sallyForth = 4;
				keepType = 10;
				castleResearchData.catapult = 6;
				castleResearchData.conscription = 6;
				castleResearchData.longBow = 6;
				castleResearchData.pike = 6;
				castleResearchData.sword = 6;
				castleResearchData.tunnel = 6;
				break;
			}
			castleResearchData2.defences = (int)this.World.UserResearchData.Research_Defences;
			castleResearchData2.catapult = (int)this.World.UserResearchData.Research_Catapult;
			castleResearchData2.sword = (int)this.World.UserResearchData.Research_Sword;
			castleResearchData2.pike = (int)this.World.UserResearchData.Research_Pike;
			castleResearchData2.longBow = (int)this.World.UserResearchData.Research_LongBow;
			castleResearchData2.conscription = (int)this.World.UserResearchData.Research_Conscription;
			castleResearchData2.sallyForth = (int)this.World.UserResearchData.Research_SallyForth;
			castleResearchData2.vaults = (int)this.World.UserResearchData.Research_Vaults;
			InterfaceMgr.Instance.clearControls();
			this.castle_Battle = new CastleMap(-1, this.gfx, 3);
			this.castle_Battle.castleShown(false);
			this.castle_Battle.reInitGFX();
			this.castle_Battle.setCampMode(0);
			if (keepType < 0)
			{
				keepType = 1;
			}
			this.castle_Battle.launchBattle(this.castle_AttackerSetup.generateCastleMapSnapshot(), null, this.castle_AttackerSetup.generateCastleTroopsSnapshot(), null, keepType, castleResearchData, castleResearchData2, 0, -1, -1, -1, 0, false, false);
			this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_CASTLE;
			this.gameDisplayModeSubMode = GameEngine.GameDisplaySubModes.SUBMODE_BATTLE;
			this.gfx.BGColor = global::ARGBColors.Black;
			InterfaceMgr.Instance.initCastleBattleTab(true, -1, false);
		}

		// Token: 0x06001288 RID: 4744 RVA: 0x00137410 File Offset: 0x00135610
		public void InitBattle(GetReport_ReturnType reportData, ViewBattle_ReturnType battleData)
		{
			int campMode = 0;
			if (reportData.reportType == 24)
			{
				campMode = 1;
			}
			else if (reportData.reportType == 25)
			{
				campMode = 2;
			}
			int num = -1;
			int num2 = -1;
			int num3 = -1;
			switch (reportData.genericData30)
			{
			case 2:
			case 4:
			case 5:
			case 6:
			case 7:
				num = reportData.genericData31;
				if (num > 9999)
				{
					num -= 10000;
				}
				break;
			case 3:
				num2 = reportData.genericData31;
				if (num2 > 9999)
				{
					num2 -= 10000;
				}
				break;
			case 12:
				num3 = reportData.genericData31;
				if (num3 > 9999)
				{
					num3 -= 10000;
				}
				break;
			}
			this.InitBattle(battleData.castleMapSnapshot, battleData.damageMapSnapshot, battleData.castleTroopsSnapshot, battleData.attackMapSnapshot, battleData.keepLevel, battleData.defenderResearchData, battleData.attackerResearchData, campMode, num, num2, num3, reportData.genericData30, reportData.defendingVillage, reportData, battleData.landType);
		}

		// Token: 0x06001289 RID: 4745 RVA: 0x00137510 File Offset: 0x00135710
		public void InitBattle(byte[] compressedCastleMap, byte[] compressedCastleDamageMap, byte[] compressedDefenderMap, byte[] compressedAttackerMap, int keepType, CastleResearchData defenderResearchData, CastleResearchData attackerResearchData, int campMode, int pillageInfo, int ransackCount, int raidCount, int attackType, int villageID, GetReport_ReturnType reportReturnData, int landType)
		{
			InterfaceMgr.Instance.clearControls();
			this.castle_Battle = new CastleMap(villageID, this.gfx, 3);
			this.castle_Battle.castleShown(false);
			this.castle_Battle.reInitGFX();
			this.castle_Battle.setCampMode(campMode);
			bool oldReport = false;
			if (reportReturnData != null && reportReturnData.reportTime < CastlesCommon.PRE_FOREST_CHANGE_DATE)
			{
				oldReport = true;
			}
			this.castle_Battle.setReportData(reportReturnData);
			this.castle_Battle.launchBattle(compressedCastleMap, compressedCastleDamageMap, compressedDefenderMap, compressedAttackerMap, keepType, defenderResearchData, attackerResearchData, campMode, pillageInfo, ransackCount, raidCount, landType, false, oldReport);
			this.castle_Battle.returnToReports();
			this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_CASTLE;
			this.gameDisplayModeSubMode = GameEngine.GameDisplaySubModes.SUBMODE_BATTLE;
			this.gfx.BGColor = global::ARGBColors.Black;
			bool aiattack = true;
			if (reportReturnData != null)
			{
				aiattack = this.World.isSpecial(reportReturnData.attackingVillage);
			}
			InterfaceMgr.Instance.initCastleBattleTab(true, attackType, aiattack);
		}

		// Token: 0x0600128A RID: 4746 RVA: 0x001375FC File Offset: 0x001357FC
		public void InitCastleView(byte[] compressedCastleMap, byte[] compressedDefenderMap, int keepType, int campMode, int defencesResearch, int villageID, int landType)
		{
			InterfaceMgr.Instance.clearControls();
			this.castle_Battle = new CastleMap(-1, this.gfx, 3);
			this.castle_Battle.castleShown(false);
			this.castle_Battle.reInitGFX();
			this.castle_Battle.setCampMode(campMode);
			this.castle_Battle.clearTempAttackers();
			CastleResearchData castleResearchData = new CastleResearchData();
			castleResearchData.defences = defencesResearch;
			this.castle_Battle.launchBattle(compressedCastleMap, null, compressedDefenderMap, null, keepType, castleResearchData, new CastleResearchData(), campMode, -1, -1, -1, landType, true, false);
			this.castle_Battle.returnToReports();
			this.castle_Battle.setRealBattleMode(false);
			this.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_CASTLE;
			this.gameDisplayModeSubMode = GameEngine.GameDisplaySubModes.SUBMODE_BATTLE;
			this.gfx.BGColor = global::ARGBColors.Black;
			InterfaceMgr.Instance.initCastleBattleTab(false, villageID, false);
		}

		// Token: 0x0600128B RID: 4747 RVA: 0x001376C8 File Offset: 0x001358C8
		public void windowClosing()
		{
			DX.CloseBotWindow();
			foreach (object obj in this.villages)
			{
				VillageMap villageMap = (VillageMap)obj;
				villageMap.dispose();
			}
			this.villages.Clear();
			foreach (object obj2 in this.castles)
			{
				CastleMap castleMap = (CastleMap)obj2;
				castleMap.dispose();
			}
			this.castles.Clear();
			this.cardsManager.UserCardData = null;
			InterfaceMgr.Instance.ignoreStopDraw = true;
			InterfaceMgr.Instance.logout();
			InterfaceMgr.Instance.changeTab(0);
			InterfaceMgr.Instance.ignoreStopDraw = false;
			this.World.clearParishChat();
			this.World.resetLeaderboards();
			this.World.logout();
			this.newResolution = -1;
			this.nextFactionPage = -1;
			this.villageToAbandon = -1;
			WorldsEndPanel.logout();
			if (this.noVillagePopup != null)
			{
				this.noVillagePopup.closing = true;
			}
			if (this.lostVillagePopup != null)
			{
				this.lostVillagePopup.closing = true;
			}
			if (this.worldsEndPopup != null)
			{
				this.worldsEndPopup.closing = true;
			}
			if (this.noAutoVillagePopup != null)
			{
				this.noAutoVillagePopup.closing = true;
			}
			this.closeNoVillagePopup(false);
			this.noVillagePopup = null;
			this.lostVillagePopup = null;
			this.worldsEndPopup = null;
			this.noAutoVillagePopup = null;
		}

		// Token: 0x0600128C RID: 4748 RVA: 0x00013F18 File Offset: 0x00012118
		public void setPendingSessionExpiredStat(int errorNo)
		{
			this.pendingErrorCode = errorNo;
			if (errorNo != -1)
			{
				GameEngine.Instance.World.downloadingCounter = -100;
				this.forceRelogin();
			}
		}

		// Token: 0x0600128D RID: 4749 RVA: 0x00013F3C File Offset: 0x0001213C
		public bool pendingError()
		{
			if (this.pendingErrorCode == -1)
			{
				return false;
			}
			this.sessionExpired(this.pendingErrorCode);
			return true;
		}

		// Token: 0x0600128E RID: 4750 RVA: 0x00013F56 File Offset: 0x00012156
		public void appClosing()
		{
			this.appClose = true;
		}

		// Token: 0x0600128F RID: 4751 RVA: 0x00013F5F File Offset: 0x0001215F
		public void initWorldData(WorldData newWorldData)
		{
			this.worldData = newWorldData;
		}

		// Token: 0x06001290 RID: 4752 RVA: 0x0013786C File Offset: 0x00135A6C
		public void sessionExpired(int errorNo)
		{
			string connectionErrorTitle = GameEngine.GetConnectionErrorTitle(errorNo);
			string text = GameEngine.GetConnectionErrorMessage(errorNo);
			UniversalDebugLog.Log("Got session expired error " + errorNo.ToString());
			bool flag = false;
			if (errorNo == 11)
			{
				errorNo = 1;
				flag = true;
			}
			if (errorNo == 1 && InterfaceMgr.Instance.ParentForm != null && !this.appClose)
			{
				if (!InterfaceMgr.Instance.isConnectionErrorWindow() && !this.forcingLogout)
				{
					if (!flag)
					{
						InterfaceMgr.Instance.closeAllPopups();
						InterfaceMgr.Instance.getMainTabBar().changeTab(0);
					}
					InterfaceMgr.Instance.openConnectionErrorWindow();
				}
				return;
			}
			InterfaceMgr.Instance.closeAllPopups();
			InterfaceMgr.Instance.chatClose();
			if (InterfaceMgr.Instance.ParentForm != null && !this.appClose)
			{
				if (errorNo >= 0)
				{
					if (errorNo == 0 && this.LocalWorldData.Alternate_Ruleset == 1 && this.getDominationTimeLeft().TotalMinutes < 5.0)
					{
						GameEngine.Instance.openLostVillage(1000);
						while (this.lostVillagePopup != null && this.lostVillagePopup.Visible)
						{
							Thread.Sleep(100);
							Application.DoEvents();
						}
					}
					if (errorNo == 1)
					{
						text = text + "\n\n" + this.connectionErrorString;
					}
					MyMessageBox.Show(text, connectionErrorTitle);
				}
				this.m_doReLogin = true;
			}
			this.World.invalidateWorldData();
			if (this.dPop != null && this.dPop.Created)
			{
				this.dPop.Close();
			}
			if (this.m_loginHistoryPop != null && this.m_loginHistoryPop.Created)
			{
				this.m_loginHistoryPop.Close();
			}
			this.pendingErrorCode = -1;
		}

		// Token: 0x06001291 RID: 4753 RVA: 0x00137A04 File Offset: 0x00135C04
		public static string GetConnectionErrorTitle(int errorNo)
		{
			switch (errorNo)
			{
			case 0:
				return SK.Text("GameEngine_Session_Lost", "Session Lost");
			case 1:
				break;
			case 2:
				goto IL_4D;
			case 3:
				return SK.Text("ServerDowntime_Scheduled_DownTime", "Scheduled Server Maintenance");
			default:
				if (errorNo != 11)
				{
					goto IL_4D;
				}
				break;
			}
			return SK.Text("ConnectioError_Title", "Problem with Connection to Server");
			IL_4D:
			return SK.Text("GENERIC_Connection_Error", "Connection Error");
		}

		// Token: 0x06001292 RID: 4754 RVA: 0x00137A70 File Offset: 0x00135C70
		public static string GetConnectionErrorMessage(int errorNo)
		{
			switch (errorNo)
			{
			case 0:
				return SK.Text("GameEngine_Session_Lost_Message", "Your current session has been lost, please login again.");
			case 1:
				break;
			case 2:
				return SK.Text("GameEngine_Connection_Timed_Out", "Your connection has timed out.");
			case 3:
				return SK.Text("ServerDowntime_Scheduled_DownTime", "Scheduled Server Maintenance");
			default:
				if (errorNo != 11)
				{
					return "";
				}
				break;
			}
			return SK.Text("GameEngine_Cannot_Access_Server", "Cannot access Server.");
		}

		// Token: 0x06001293 RID: 4755 RVA: 0x00137AE0 File Offset: 0x00135CE0
		public void forceLogout()
		{
			this.forcingLogout = true;
			InterfaceMgr.Instance.chatClose();
			this.m_doReLogin = true;
			this.World.invalidateWorldData();
			if (this.dPop != null && this.dPop.Created)
			{
				this.dPop.Close();
			}
			if (this.m_loginHistoryPop != null && this.m_loginHistoryPop.Created)
			{
				this.m_loginHistoryPop.Close();
			}
			this.pendingErrorCode = -1;
			InterfaceMgr.Instance.closeAllPopups();
		}

		// Token: 0x06001294 RID: 4756 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void chatSessionExpired(int errorNo)
		{
		}

		// Token: 0x06001295 RID: 4757 RVA: 0x00013F68 File Offset: 0x00012168
		public void forceRelogin()
		{
			this.m_doReLogin = true;
		}

		// Token: 0x06001296 RID: 4758 RVA: 0x00013F71 File Offset: 0x00012171
		public bool loginCancelled()
		{
			return this.m_doReLogin;
		}

		// Token: 0x06001297 RID: 4759 RVA: 0x00137B64 File Offset: 0x00135D64
		public bool reLogin()
		{
			bool doReLogin = this.m_doReLogin;
			this.m_doReLogin = false;
			return doReLogin;
		}

		// Token: 0x06001298 RID: 4760 RVA: 0x00013F79 File Offset: 0x00012179
		public void FlagQuitGame()
		{
			this.quitGame = true;
		}

		// Token: 0x06001299 RID: 4761 RVA: 0x00013F82 File Offset: 0x00012182
		public bool quitting()
		{
			return this.quitGame;
		}

		// Token: 0x0600129A RID: 4762 RVA: 0x00013F8A File Offset: 0x0001218A
		public static void displayDirectXError()
		{
			MessageBox.Show(SK.Text("GameEngine_DX_problem", "There is a problem with DirectX, please contact Support."), SK.Text("GameEngine_DX_Error", "DirectX Error"));
			Application.Exit();
		}

		// Token: 0x0600129B RID: 4763 RVA: 0x00137B80 File Offset: 0x00135D80
		public void remoteConnectionCommonHandler(Common_ReturnData returnData)
		{
			InterfaceMgr.Instance.getMainTabBar().newReports(returnData.NewReports);
			InterfaceMgr.Instance.getMainTabBar().newMail(returnData.NewMail);
			if (returnData.NewMail)
			{
				InterfaceMgr.Instance.mailPopupNewMail();
			}
			InterfaceMgr.Instance.getMainTabBar().newPoliticsPost(returnData.NewPoliticsForumPost);
			if (returnData.NewIngameMessage)
			{
				RemoteServices.Instance.set_GetIngameMessage_UserCallBack(new RemoteServices.GetIngameMessage_UserCallBack(this.getIngameMessageCallback));
				RemoteServices.Instance.GetIngameMessage();
			}
			if (returnData.NoVillages)
			{
				InterfaceMgr.Instance.getMainTabBar().changeTab(9);
				InterfaceMgr.Instance.getMainTabBar().changeTab(0);
			}
		}

		// Token: 0x0600129C RID: 4764 RVA: 0x00013FB5 File Offset: 0x000121B5
		public void getIngameMessageCallback(GetIngameMessage_ReturnType returnData)
		{
			if (returnData.Success && returnData.message.Length > 0)
			{
				AdminInfoPopup.setMessage(returnData.message);
				AdminInfoPopup.showMessage();
			}
		}

		// Token: 0x0600129D RID: 4765 RVA: 0x00137C30 File Offset: 0x00135E30
		public void forceDownloadCurrentVillage()
		{
			int selectedMenuVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
			this.villages[selectedMenuVillage] = null;
			this.downloadCurrentVillage();
		}

		// Token: 0x0600129E RID: 4766 RVA: 0x00137C5C File Offset: 0x00135E5C
		public void downloadCurrentVillage()
		{
			int selectedMenuVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
			InterfaceMgr.Instance.villageChanged(selectedMenuVillage);
			InterfaceMgr.Instance.castleChanged();
			this.castle = null;
			this.village = null;
			this.lastLoadedVillage = selectedMenuVillage;
			bool needParishPeople = false;
			if (this.villages[selectedMenuVillage] != null && this.castles[selectedMenuVillage] != null)
			{
				this.village = (VillageMap)this.villages[selectedMenuVillage];
				this.castle = (CastleMap)this.castles[selectedMenuVillage];
				this.village.Camera.Drag(new Point(0, 0));
				this.castle.moveMap(0, 0);
				this.village.ViewOnly = false;
				if (this.World.isCapital(selectedMenuVillage) && this.village.needParishPeople())
				{
					needParishPeople = true;
				}
				if ((DateTime.Now - this.village.lastDownloadedTime).TotalMinutes < 5.0)
				{
					VillageMap.loadVillageBuildingsGFX2();
					this.village.loadBackgroundImage();
					this.village.reAddBuildingsToMap();
					this.village.updateConstructionOnCachedLoad();
					this.castle.reInitGFX();
					CastleMap.CreateMode = false;
					InterfaceMgr.Instance.villageDownloaded(selectedMenuVillage);
					this.castle.castleShown(true);
					return;
				}
			}
			else if (this.World.isCapital(selectedMenuVillage))
			{
				needParishPeople = true;
			}
			RemoteServices.Instance.GetVillageBuildingsList(selectedMenuVillage, true, needParishPeople);
			VillageMap.loadVillageBuildingsGFX2();
			if (this.village != null)
			{
				this.village.loadBackgroundImage();
			}
			if (this.castle != null)
			{
				this.castle.reInitGFX();
			}
			CastleMap.CreateMode = false;
			if (this.convertVillageCallback != null)
			{
				this.convertVillageCallback();
			}
		}

		// Token: 0x0600129F RID: 4767 RVA: 0x00137E18 File Offset: 0x00136018
		public void flushVillages()
		{
			foreach (object obj in this.villages)
			{
				VillageMap villageMap = (VillageMap)obj;
				if (villageMap != null)
				{
					villageMap.lastDownloadedTime = DateTime.MinValue;
				}
			}
		}

		// Token: 0x060012A0 RID: 4768 RVA: 0x00137E78 File Offset: 0x00136078
		public void flushVillage(int villageID)
		{
			if (this.villages[villageID] != null)
			{
				VillageMap villageMap = (VillageMap)this.villages[villageID];
				if (villageMap != null)
				{
					villageMap.lastDownloadedTime = DateTime.MinValue;
				}
			}
		}

		// Token: 0x060012A1 RID: 4769 RVA: 0x00137EB4 File Offset: 0x001360B4
		public void getVillageBuildingListCallBack(GetVillageBuildingsList_ReturnType returnData)
		{
			if (returnData.Success)
			{
				if (returnData.existingArmies != null)
				{
					this.World.updateExistingArmies(returnData.existingArmies);
				}
				if (InterfaceMgr.Instance.getSelectedMenuVillage() == returnData.villageID)
				{
					int villageID = returnData.villageID;
					if (this.villages[villageID] == null)
					{
						VillageMap value = new VillageMap(returnData.mapID, returnData.mapVariant, returnData.mapType, villageID, this.gfx);
						this.villages[villageID] = value;
					}
					bool flag = false;
					VillageMap villageMap = (VillageMap)this.villages[villageID];
					if (villageID == InterfaceMgr.Instance.getSelectedMenuVillage() || returnData.viewOnly)
					{
						this.village = villageMap;
						flag = true;
					}
					villageMap.resetMapType(returnData.mapID, returnData.mapVariant, returnData.mapType);
					if (flag)
					{
						villageMap.loadBackgroundImage();
						villageMap.reInitGFX(this.gfx);
					}
					villageMap.ViewOnly = returnData.viewOnly;
					villageMap.ViewHonour = returnData.viewHonour;
					villageMap.lastDownloadedTime = DateTime.Now;
					if (returnData.parishTaxInfo != null)
					{
						villageMap.importParishTaxPeople(returnData.parishTaxInfo, returnData.currentTime);
					}
					VillageMap.setServerTime(returnData.currentTime);
					if (returnData.fullUpdate)
					{
						villageMap.initClickMask();
					}
					villageMap.importResourcesAndStats(returnData.villageResourcesAndStats, returnData.currentTime);
					villageMap.importVillageBuildings(returnData.villageBuildings, returnData.fullUpdate);
					ControlForm controlForm = DX.ControlForm;
					if (controlForm != null)
					{
						controlForm.GetService<VillagelayoutService>().ImportBuildings(villageMap);
					}
					if (!returnData.viewOnly)
					{
						villageMap.importTraders(returnData.traders, returnData.currentTime);
					}
					DXPanel.skipPaint = true;
					if (this.lastVillageTabID == 0)
					{
						villageMap.playEnvironmentalSounds();
					}
					InterfaceMgr.Instance.villageDownloaded(returnData.villageID);
					if (!returnData.viewOnly)
					{
						this.getCastleCallBack(returnData);
					}
					if (returnData.viewOnly)
					{
						InterfaceMgr.Instance.getMainTabBar().selectDummyTab(50);
					}
				}
				if (!returnData.viewOnly)
				{
					this.World.importOrphanedPeople(returnData.people, returnData.currentTime, returnData.villageID);
					return;
				}
			}
			else if (returnData.m_errorCode == ErrorCodes.ErrorCode.VILLAGE_BUILDINGS_NO_LONGER_OWNER && !returnData.viewOnly)
			{
				this.displayedVillageLost(returnData.villageID, true);
			}
		}

		// Token: 0x060012A2 RID: 4770 RVA: 0x00013FDD File Offset: 0x000121DD
		public VillageMap getVillage(int villageID)
		{
			if (villageID < 0)
			{
				return null;
			}
			if (this.villages[villageID] == null)
			{
				return null;
			}
			return (VillageMap)this.villages[villageID];
		}

		// Token: 0x060012A3 RID: 4771 RVA: 0x001380D8 File Offset: 0x001362D8
		public void displayedVillageLost(int villageID, bool popup)
		{
			InterfaceMgr.Instance.closeVillageTab();
			InterfaceMgr.Instance.closeCastleTab();
			this.world.updateWorldMapOwnership();
			if (popup)
			{
				MyMessageBox.Show(SK.Text("GameEngine_Lost_Control_Of_Village", "You have lost control of this village!"), SK.Text("GENERIC_Error", "Error"));
			}
			if (this.villages[villageID] != null)
			{
				this.villages[villageID] = null;
				this.village = null;
			}
			InterfaceMgr.Instance.getMainTabBar().changeTab(9);
			InterfaceMgr.Instance.getMainTabBar().changeTab(0);
		}

		// Token: 0x060012A4 RID: 4772 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void downloadCurrentCastle()
		{
		}

		// Token: 0x060012A5 RID: 4773 RVA: 0x00138170 File Offset: 0x00136370
		public void getCastleCallBack(GetVillageBuildingsList_ReturnType returnData)
		{
			if (returnData.Success)
			{
				int villageID = returnData.villageID;
				if (this.castles[villageID] == null)
				{
					CastleMap value = new CastleMap(villageID, this.gfx, 0);
					this.castles[villageID] = value;
				}
				CastleMap castleMap = (CastleMap)this.castles[villageID];
				if (villageID == InterfaceMgr.Instance.getSelectedMenuVillage())
				{
					this.castle = castleMap;
				}
				CastleMap.setServerTime(returnData.currentTime);
				castleMap.importElements(returnData.elements);
				castleMap.castleShown(true);
			}
		}

		// Token: 0x060012A6 RID: 4774 RVA: 0x001381FC File Offset: 0x001363FC
		public void toggleDebugPopup()
		{
			if (this.dPop == null)
			{
				this.dPop = new DebugPopup();
				this.dPop.Show();
				return;
			}
			if (this.dPop.Created)
			{
				this.dPop.Close();
				this.dPop = null;
				return;
			}
			this.dPop = new DebugPopup();
			this.dPop.Show();
		}

		// Token: 0x060012A7 RID: 4775 RVA: 0x00014006 File Offset: 0x00012206
		private void debugPopupRun()
		{
			if (this.dPop != null && this.dPop.Created)
			{
				this.dPop.run();
			}
		}

		// Token: 0x060012A8 RID: 4776 RVA: 0x00014028 File Offset: 0x00012228
		public void showLoginHistory()
		{
			if (this.m_loginHistoryPop != null)
			{
				if (this.m_loginHistoryPop.Created)
				{
					this.m_loginHistoryPop.Close();
				}
				this.m_loginHistoryPop = null;
			}
			this.m_loginHistoryPop = new LoginHistoryPopup();
			this.m_loginHistoryPop.Show();
		}

		// Token: 0x060012A9 RID: 4777 RVA: 0x00014067 File Offset: 0x00012267
		private void loginHistoryRun()
		{
			if (this.m_loginHistoryPop != null && this.m_loginHistoryPop.Created)
			{
				this.m_loginHistoryPop.update();
			}
		}

		// Token: 0x060012AA RID: 4778 RVA: 0x00014089 File Offset: 0x00012289
		public void startResizeWindow()
		{
			InterfaceMgr.Instance.mainWindowStartResize();
		}

		// Token: 0x060012AB RID: 4779 RVA: 0x00138260 File Offset: 0x00136460
		public void resizeWindow()
		{
			if (this.gfx != null)
			{
				this.gfx.resizeWindow();
			}
			InterfaceMgr.Instance.mainWindowResize();
			int num = this.lastTabID;
			if (num != 0)
			{
				if (num != 1)
				{
					if (num == 9)
					{
						if (this.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_CASTLE)
						{
							InterfaceMgr.Instance.castleMapResizeWindow();
							if (this.gameDisplayModeSubMode == GameEngine.GameDisplaySubModes.SUBMODE_DEFAULT)
							{
								if (this.castle != null)
								{
									this.castle.moveMap(0, 0);
									this.castle.createSurroundSprites();
									this.gfx.RenderList.clearLayers();
									this.castle.justDrawSprites();
									this.castle.recalcCastleLayout();
								}
							}
							else if (this.gameDisplayModeSubMode == GameEngine.GameDisplaySubModes.SUBMODE_CASTLE_ATTACKER_SETUP)
							{
								if (this.castle_AttackerSetup != null)
								{
									this.castle_AttackerSetup.moveMap(0, 0);
									this.castle_AttackerSetup.createSurroundSprites();
									this.gfx.RenderList.clearLayers();
									this.castle_AttackerSetup.justDrawSprites();
								}
							}
							else if (this.gameDisplayModeSubMode == GameEngine.GameDisplaySubModes.SUBMODE_BATTLE)
							{
								if (this.castle_Battle != null)
								{
									this.castle_Battle.moveMap(0, 0);
									this.castle_Battle.createSurroundSprites();
									this.gfx.RenderList.clearLayers();
									this.castle_Battle.justDrawSprites();
								}
							}
							else if (this.gameDisplayModeSubMode == GameEngine.GameDisplaySubModes.SUBMODE_PREVIEW && this.castle_Preview != null)
							{
								this.castle_Preview.moveMap(0, 0);
								this.castle_Preview.createSurroundSprites();
								this.gfx.RenderList.clearLayers();
								this.castle_Preview.justDrawSprites();
							}
						}
					}
				}
				else if (this.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_VILLAGE)
				{
					InterfaceMgr.Instance.villageMapResizeWindow();
					if (this.village != null)
					{
						this.village.Camera.Drag(new Point(0, 0));
						this.Village.createSurroundSprites();
						this.gfx.RenderList.clearLayers();
						this.village.justDrawSprites();
					}
				}
				else if (this.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_CASTLE)
				{
					InterfaceMgr.Instance.castleMapResizeWindow();
					if (this.gameDisplayModeSubMode == GameEngine.GameDisplaySubModes.SUBMODE_DEFAULT)
					{
						if (this.castle != null)
						{
							this.castle.moveMap(0, 0);
							this.castle.createSurroundSprites();
							this.gfx.RenderList.clearLayers();
							this.castle.justDrawSprites();
							this.castle.recalcCastleLayout();
						}
					}
					else if (this.gameDisplayModeSubMode == GameEngine.GameDisplaySubModes.SUBMODE_CASTLE_ATTACKER_SETUP)
					{
						if (this.castle_AttackerSetup != null)
						{
							this.castle_AttackerSetup.moveMap(0, 0);
							this.castle_AttackerSetup.createSurroundSprites();
							this.gfx.RenderList.clearLayers();
							this.castle_AttackerSetup.justDrawSprites();
						}
					}
					else if (this.gameDisplayModeSubMode == GameEngine.GameDisplaySubModes.SUBMODE_BATTLE)
					{
						if (this.castle_Battle != null)
						{
							this.castle_Battle.moveMap(0, 0);
							this.castle_Battle.createSurroundSprites();
							this.gfx.RenderList.clearLayers();
							this.castle_Battle.justDrawSprites();
						}
					}
					else if (this.gameDisplayModeSubMode == GameEngine.GameDisplaySubModes.SUBMODE_PREVIEW && this.castle_Preview != null)
					{
						this.castle_Preview.moveMap(0, 0);
						this.castle_Preview.createSurroundSprites();
						this.gfx.RenderList.clearLayers();
						this.castle_Preview.justDrawSprites();
					}
				}
			}
			else if (this.World != null)
			{
				this.World.moveMap(0.0, 0.0);
			}
			InterfaceMgr.Instance.getDXBasePanel().Invalidate();
		}

		// Token: 0x060012AC RID: 4780 RVA: 0x00014095 File Offset: 0x00012295
		public void playInterfaceSound(string soundTag)
		{
			this.playInterfaceSound(soundTag, true);
		}

		// Token: 0x060012AD RID: 4781 RVA: 0x001385D8 File Offset: 0x001367D8
		public void playInterfaceSound(string soundTag, bool overwritePlayingSound)
		{
			if (soundTag.Trim().Length != 0 && this.AudioEngine != null && !this.stopInterfaceSounds && Sound.SFXActive && (overwritePlayingSound || !this.AudioEngine.isSoundPlaying(soundTag)))
			{
				this.AudioEngine.playInterfaceSound(soundTag);
			}
		}

		// Token: 0x060012AE RID: 4782 RVA: 0x00138628 File Offset: 0x00136828
		public static void updateFolderPermissions(string path)
		{
			if (!GameEngine.updatedPermissions)
			{
				GameEngine.updatedPermissions = true;
				try
				{
					SecurityIdentifier securityIdentifier = new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null);
					NTAccount ntaccount = securityIdentifier.Translate(typeof(NTAccount)) as NTAccount;
					string account = ntaccount.ToString();
					GameEngine.AddDirectorySecurity(path, account, FileSystemRights.FullControl, AccessControlType.Allow);
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x060012AF RID: 4783 RVA: 0x0013868C File Offset: 0x0013688C
		public static void AddDirectorySecurity(string FileName, string Account, FileSystemRights Rights, AccessControlType ControlType)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(FileName);
			DirectorySecurity accessControl = directoryInfo.GetAccessControl();
			accessControl.AddAccessRule(new FileSystemAccessRule(Account, Rights, InheritanceFlags.ObjectInherit, PropagationFlags.InheritOnly, ControlType));
			accessControl.AddAccessRule(new FileSystemAccessRule(Account, Rights, InheritanceFlags.ContainerInherit, PropagationFlags.InheritOnly, ControlType));
			accessControl.AddAccessRule(new FileSystemAccessRule(Account, Rights, ControlType));
			directoryInfo.SetAccessControl(accessControl);
		}

		// Token: 0x060012B0 RID: 4784 RVA: 0x0001409F File Offset: 0x0001229F
		public void DisableMouseClicks()
		{
			if (this.Filter == null)
			{
				this.Filter = new GameEngine.MouseClickMessageFilter();
				Application.AddMessageFilter(this.Filter);
			}
		}

		// Token: 0x060012B1 RID: 4785 RVA: 0x000140BF File Offset: 0x000122BF
		public void EnableMouseClicks()
		{
			if (this.Filter != null)
			{
				Application.RemoveMessageFilter(this.Filter);
				this.Filter = null;
			}
		}

		// Token: 0x060012B2 RID: 4786 RVA: 0x001386DC File Offset: 0x001368DC
		public void initCensorText(string[] words)
		{
			List<string> list = new List<string>();
			foreach (string text in words)
			{
				if (text.ToLower() != "niger")
				{
					list.Add(text);
				}
			}
			this.badWords = list.ToArray();
		}

		// Token: 0x060012B3 RID: 4787 RVA: 0x000140DB File Offset: 0x000122DB
		public string censorString(string text)
		{
			if (this.badWords == null)
			{
				return text;
			}
			if (GameEngine.staticCensor == null)
			{
				GameEngine.staticCensor = new Censor(this.badWords);
			}
			return GameEngine.staticCensor.CensorText(text);
		}

		// Token: 0x060012B4 RID: 4788 RVA: 0x00014109 File Offset: 0x00012309
		public void installKeyboardHook()
		{
			this.uninstallKeyboardHook();
			GameEngine._hookID = GameEngine.SetHook(GameEngine._proc, 13);
			GameEngine.keyboardHookedInstalled = true;
		}

		// Token: 0x060012B5 RID: 4789 RVA: 0x00014128 File Offset: 0x00012328
		public void uninstallKeyboardHook()
		{
			if (GameEngine.keyboardHookedInstalled)
			{
				GameEngine.UnhookWindowsHookEx(GameEngine._hookID);
				GameEngine.keyboardHookedInstalled = false;
			}
		}

		// Token: 0x060012B6 RID: 4790 RVA: 0x00138728 File Offset: 0x00136928
		private static IntPtr SetHook(GameEngine.LowLevelKeyboardProc proc, int type)
		{
			IntPtr result;
			using (Process currentProcess = Process.GetCurrentProcess())
			{
				using (ProcessModule mainModule = currentProcess.MainModule)
				{
					result = GameEngine.SetWindowsHookEx(type, proc, GameEngine.GetModuleHandle(mainModule.ModuleName), 0U);
				}
			}
			return result;
		}

		// Token: 0x060012B7 RID: 4791 RVA: 0x0013878C File Offset: 0x0013698C
		private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
		{
			if (GameEngine.Instance.GFX == null)
			{
				return GameEngine.CallNextHookEx(GameEngine._hookID, nCode, wParam, lParam);
			}
			if (nCode >= 0 && wParam == (IntPtr)256)
			{
				GameEngine.Instance.lastMouseMoveTime = DateTime.Now;
				int num = Marshal.ReadInt32(lParam);
				if (num == 160 || num == 161)
				{
					GameEngine.shiftPressedAlways = true;
				}
				GameEngine.lastKeyPressed = num;
				Form activeForm = Form.ActiveForm;
				bool flag = false;
				if (!GameEngine.StopKeyTrap && InterfaceMgr.Instance.ParentForm != null && (activeForm == InterfaceMgr.Instance.ParentForm || (activeForm == InterfaceMgr.Instance.ChatForm && activeForm != null)))
				{
					bool flag2 = false;
					if (GameEngine.Instance.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_MAIL || GameEngine.Instance.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_CASTLE || GameEngine.Instance.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_VILLAGE || GameEngine.Instance.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_WORLD)
					{
						flag2 = true;
					}
					if (GameEngine.Instance.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_VILLAGE && InterfaceMgr.Instance.isTextInputScreenActive())
					{
						if (num != 9)
						{
							if (num - 160 <= 1)
							{
								GameEngine.shiftPressed = true;
							}
						}
						else
						{
							GameEngine.tabPressed = true;
						}
						return GameEngine.CallNextHookEx(GameEngine._hookID, nCode, wParam, lParam);
					}
					if (activeForm == InterfaceMgr.Instance.ChatForm)
					{
						flag = true;
					}
					if (num <= 40)
					{
						if (num != 9)
						{
							if (num != 13)
							{
								switch (num)
								{
								case 37:
									if (flag2)
									{
										if (!flag)
										{
											GameEngine.scrollLeft = true;
										}
										if (GameEngine.Instance.GameDisplayMode != GameEngine.GameDisplays.DISPLAY_MAIL && !flag)
										{
											if (GameEngine.Instance.GFX.keyControlled)
											{
												GameEngine.Instance.playInterfaceSound("WorldMapScreen_village_left");
												InterfaceMgr.Instance.selectedVillageNameLeft();
											}
											return (IntPtr)1;
										}
									}
									break;
								case 38:
									if (flag2)
									{
										if (!flag)
										{
											GameEngine.scrollUp = true;
										}
										if (GameEngine.Instance.GameDisplayMode != GameEngine.GameDisplays.DISPLAY_MAIL && !flag)
										{
											return (IntPtr)1;
										}
									}
									break;
								case 39:
									if (flag2)
									{
										if (!flag)
										{
											GameEngine.scrollRight = true;
										}
										if (GameEngine.Instance.GameDisplayMode != GameEngine.GameDisplays.DISPLAY_MAIL && !flag)
										{
											if (GameEngine.Instance.GFX.keyControlled)
											{
												GameEngine.Instance.playInterfaceSound("WorldMapScreen_village_right");
												InterfaceMgr.Instance.selectedVillageNameRight();
											}
											return (IntPtr)1;
										}
									}
									break;
								case 40:
									if (flag2)
									{
										if (!flag)
										{
											GameEngine.scrollDown = true;
										}
										if (GameEngine.Instance.GameDisplayMode != GameEngine.GameDisplays.DISPLAY_MAIL && !flag)
										{
											return (IntPtr)1;
										}
									}
									break;
								}
							}
							else if (!flag)
							{
								GameEngine.enterPressed = true;
							}
						}
						else if (!flag)
						{
							GameEngine.tabPressed = true;
						}
					}
					else if (num != 122)
					{
						if (num - 160 > 1)
						{
							if (num - 162 <= 1)
							{
								GameEngine.Instance.GFX.keyControlled = true;
							}
						}
						else
						{
							GameEngine.shiftPressed = true;
						}
					}
					else
					{
						GameEngine.f11Pressed = true;
					}
				}
			}
			else
			{
				GameEngine.lastKeyPressed = 0;
				if (nCode >= 0 && wParam == (IntPtr)257)
				{
					int num2 = Marshal.ReadInt32(lParam);
					if (num2 <= 40)
					{
						if (num2 != 9)
						{
							switch (num2)
							{
							case 37:
								GameEngine.scrollLeft = false;
								break;
							case 38:
								GameEngine.scrollUp = false;
								break;
							case 39:
								GameEngine.scrollRight = false;
								break;
							case 40:
								GameEngine.scrollDown = false;
								break;
							}
						}
						else
						{
							GameEngine.tabPressed = false;
							GameEngine.tabReleased = true;
						}
					}
					else if (num2 - 160 > 1)
					{
						if (num2 - 162 <= 1)
						{
							GameEngine.Instance.GFX.keyControlled = false;
						}
					}
					else
					{
						GameEngine.shiftPressed = false;
						GameEngine.shiftPressedAlways = false;
					}
				}
			}
			return GameEngine.CallNextHookEx(GameEngine._hookID, nCode, wParam, lParam);
		}

		// Token: 0x060012B8 RID: 4792
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr SetWindowsHookEx(int idHook, GameEngine.LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

		// Token: 0x060012B9 RID: 4793
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool UnhookWindowsHookEx(IntPtr hhk);

		// Token: 0x060012BA RID: 4794
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

		// Token: 0x060012BB RID: 4795
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr GetModuleHandle(string lpModuleName);

		// Token: 0x060012BC RID: 4796 RVA: 0x00138B38 File Offset: 0x00136D38
		public static string getCachePath()
		{
			string text = Path.Combine(GameEngine.getSettingsPath(false), "BrowserCache");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			return text;
		}

		// Token: 0x060012BD RID: 4797 RVA: 0x00138B68 File Offset: 0x00136D68
		public static string getSettingsPath(bool createFolder)
		{
			if (GameEngine.userPath == null)
			{
				FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
				GameEngine.userPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
				GameEngine.userPath += "\\";
				GameEngine.userPath += versionInfo.CompanyName;
				GameEngine.userPathBase = GameEngine.userPath;
				GameEngine.userPath += "\\";
				GameEngine.userPath += versionInfo.ProductName;
			}
			try
			{
				if (Directory.Exists(GameEngine.userPath) || !createFolder)
				{
					GameEngine.updateFolderPermissions(GameEngine.userPath);
					return GameEngine.userPath;
				}
				Directory.CreateDirectory(GameEngine.userPathBase);
				Directory.CreateDirectory(GameEngine.userPath);
				GameEngine.updateFolderPermissions(GameEngine.userPath);
			}
			catch (Exception)
			{
			}
			return GameEngine.userPath;
		}

		// Token: 0x060012BE RID: 4798 RVA: 0x00138C54 File Offset: 0x00136E54
		public static string getLangsPath()
		{
			if (GameEngine.langPath == null)
			{
				GameEngine.langPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Stronghold Kingdoms\\";
				try
				{
					Directory.CreateDirectory(GameEngine.langPath);
				}
				catch (Exception)
				{
				}
			}
			return GameEngine.langPath;
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x060012BF RID: 4799 RVA: 0x00014142 File Offset: 0x00012342
		internal SparseArray Castles
		{
			get
			{
				return this.castles;
			}
		}

		// Token: 0x060012C0 RID: 4800 RVA: 0x00138CA4 File Offset: 0x00136EA4
		internal VillageMap GetLoadedVillageWithinParish(int capitalId)
		{
			foreach (object obj in this.villages)
			{
				VillageMap villageMap = (VillageMap)obj;
				if (PredatorService.IsInSameParish(villageMap.VillageID, capitalId) && villageMap != null)
				{
					return villageMap;
				}
			}
			return null;
		}

		// Token: 0x040018A7 RID: 6311
		private const long FRAME_TIME = 33L;

		// Token: 0x040018A8 RID: 6312
		private const int WM_LBUTTONDOWN = 513;

		// Token: 0x040018A9 RID: 6313
		private const int WM_LBUTTONUP = 514;

		// Token: 0x040018AA RID: 6314
		private const int WM_LBUTTONDBLCLK = 515;

		// Token: 0x040018AB RID: 6315
		private const int WM_MOUSEMOVE = 512;

		// Token: 0x040018AC RID: 6316
		private const int WM_RBUTTONDOWN = 516;

		// Token: 0x040018AD RID: 6317
		private const int WM_RBUTTONUP = 517;

		// Token: 0x040018AE RID: 6318
		private const int WM_RBUTTONDBLCLK = 518;

		// Token: 0x040018AF RID: 6319
		private const int WM_MBUTTONDOWN = 519;

		// Token: 0x040018B0 RID: 6320
		private const int WM_MBUTTONUP = 520;

		// Token: 0x040018B1 RID: 6321
		private const int WM_MBUTTONDBLCLK = 521;

		// Token: 0x040018B2 RID: 6322
		private const int WH_KEYBOARD_LL = 13;

		// Token: 0x040018B3 RID: 6323
		private const int WH_MOUSE_LL = 7;

		// Token: 0x040018B4 RID: 6324
		private const int WM_KEYDOWN = 256;

		// Token: 0x040018B5 RID: 6325
		private const int WM_KEYUP = 257;

		// Token: 0x040018B6 RID: 6326
		public static GameEngine Instance = null;

		// Token: 0x040018B7 RID: 6327
		private GraphicsMgr gfx;

		// Token: 0x040018B8 RID: 6328
		private SparseArray villages = new SparseArray();

		// Token: 0x040018B9 RID: 6329
		private VillageMap village;

		// Token: 0x040018BA RID: 6330
		private SparseArray castles = new SparseArray();

		// Token: 0x040018BB RID: 6331
		private CastleMapRendering m_castleMapRendering;

		// Token: 0x040018BC RID: 6332
		private CastleMap castle;

		// Token: 0x040018BD RID: 6333
		private CastleMap castle_AttackerSetup;

		// Token: 0x040018BE RID: 6334
		private CastleMap castle_Battle;

		// Token: 0x040018BF RID: 6335
		private CastleMap castle_Preview;

		// Token: 0x040018C0 RID: 6336
		private WorldMap world = new WorldMap();

		// Token: 0x040018C1 RID: 6337
		private WorldData worldData;

		// Token: 0x040018C2 RID: 6338
		private readonly PremiumTokenManager m_premiumTokenManager = new PremiumTokenManager();

		// Token: 0x040018C3 RID: 6339
		private readonly CardsManager m_cardsManager = new CardsManager();

		// Token: 0x040018C4 RID: 6340
		private readonly CardPackManager m_cardPackManager = new CardPackManager();

		// Token: 0x040018C5 RID: 6341
		private readonly MonksManager m_monksManager = new MonksManager();

		// Token: 0x040018C6 RID: 6342
		private readonly VassalsManager m_vassalsManager = new VassalsManager();

		// Token: 0x040018C7 RID: 6343
		private readonly HouseManager m_houseManager = new HouseManager();

		// Token: 0x040018C8 RID: 6344
		private readonly FactionManager m_factionManager = new FactionManager();

		// Token: 0x040018C9 RID: 6345
		private Audio audio;

		// Token: 0x040018CA RID: 6346
		private WorldMapTypes worldMapTypesData;

		// Token: 0x040018CB RID: 6347
		private System.Threading.Timer m_tickTimer;

		// Token: 0x040018CC RID: 6348
		private bool ticked;

		// Token: 0x040018CD RID: 6349
		private bool firstCall = true;

		// Token: 0x040018CE RID: 6350
		private bool m_doReLogin;

		// Token: 0x040018CF RID: 6351
		private int currentResolution = -1;

		// Token: 0x040018D0 RID: 6352
		private int maxResolution = -1;

		// Token: 0x040018D1 RID: 6353
		private int newResolution = -1;

		// Token: 0x040018D2 RID: 6354
		private bool windowActive;

		// Token: 0x040018D3 RID: 6355
		private double lastFullTickTime;

		// Token: 0x040018D4 RID: 6356
		private double lastFullTickRegisterTime;

		// Token: 0x040018D5 RID: 6357
		private int tickCount;

		// Token: 0x040018D6 RID: 6358
		private GameEngine.GameDisplays gameDisplayMode = GameEngine.GameDisplays.DISPLAY_WORLD;

		// Token: 0x040018D7 RID: 6359
		private GameEngine.GameDisplaySubModes gameDisplayModeSubMode;

		// Token: 0x040018D8 RID: 6360
		private static NumberFormatInfo nfi = null;

		// Token: 0x040018D9 RID: 6361
		private static NumberFormatInfo nfi_decimal = null;

		// Token: 0x040018DA RID: 6362
		private static NumberFormatInfo nfi_decimal1 = null;

		// Token: 0x040018DB RID: 6363
		private static NumberFormatInfo nfi_decimal2 = null;

		// Token: 0x040018DC RID: 6364
		private FontDesc dxFont1 = new FontDesc();

		// Token: 0x040018DD RID: 6365
		private FontDesc dxFont2 = new FontDesc();

		// Token: 0x040018DE RID: 6366
		private Thread m_WorkerThread;

		// Token: 0x040018DF RID: 6367
		private bool gfxLoaded;

		// Token: 0x040018E0 RID: 6368
		private bool m_cancelLoading;

		// Token: 0x040018E1 RID: 6369
		private ProfileLoginWindow m_loginWindow;

		// Token: 0x040018E2 RID: 6370
		private bool forceTriggerFullTick;

		// Token: 0x040018E3 RID: 6371
		private LostVillageWindow lostVillagePopup;

		// Token: 0x040018E4 RID: 6372
		private WorldsEndWindow worldsEndPopup;

		// Token: 0x040018E5 RID: 6373
		private NewSelectVillageAreaWindow noVillagePopup;

		// Token: 0x040018E6 RID: 6374
		public NewAutoSelectVillageWindow noAutoVillagePopup;

		// Token: 0x040018E7 RID: 6375
		public int tryingToJoinCounty = -2;

		// Token: 0x040018E8 RID: 6376
		private bool pendingUserVillageZoom;

		// Token: 0x040018E9 RID: 6377
		public int clockFrame;

		// Token: 0x040018EA RID: 6378
		public int clockMode;

		// Token: 0x040018EB RID: 6379
		private long lastFrameTime;

		// Token: 0x040018EC RID: 6380
		public int villageToAbandon = -1;

		// Token: 0x040018ED RID: 6381
		public bool villageHasBeenDownloaded;

		// Token: 0x040018EE RID: 6382
		private DateTime lastSoundClear = DateTime.MinValue;

		// Token: 0x040018EF RID: 6383
		public bool finaliseResize;

		// Token: 0x040018F0 RID: 6384
		private int incomingAttacks;

		// Token: 0x040018F1 RID: 6385
		private long lastHighestArmyIDSeen = -1L;

		// Token: 0x040018F2 RID: 6386
		public bool NewArmiesSeen;

		// Token: 0x040018F3 RID: 6387
		private bool shownLostVillage;

		// Token: 0x040018F4 RID: 6388
		private DateTime serverDowntime = DateTime.MinValue;

		// Token: 0x040018F5 RID: 6389
		private bool warning5;

		// Token: 0x040018F6 RID: 6390
		private bool warning15;

		// Token: 0x040018F7 RID: 6391
		private bool warning30;

		// Token: 0x040018F8 RID: 6392
		private bool warning60;

		// Token: 0x040018F9 RID: 6393
		private bool warning4H;

		// Token: 0x040018FA RID: 6394
		private bool warning12H;

		// Token: 0x040018FB RID: 6395
		private bool warning24H;

		// Token: 0x040018FC RID: 6396
		private bool serverOffline;

		// Token: 0x040018FD RID: 6397
		private ServerDowntimePopup m_downtimePopup;

		// Token: 0x040018FE RID: 6398
		private int previousTabID = -1;

		// Token: 0x040018FF RID: 6399
		private int lastTabID = -1;

		// Token: 0x04001900 RID: 6400
		private bool m_firstDrawReports = true;

		// Token: 0x04001901 RID: 6401
		private bool m_firstDrawRank = true;

		// Token: 0x04001902 RID: 6402
		private bool m_firstDrawResearch = true;

		// Token: 0x04001903 RID: 6403
		private bool m_firstDrawDummy = true;

		// Token: 0x04001904 RID: 6404
		private bool m_firstDrawMail = true;

		// Token: 0x04001905 RID: 6405
		private bool m_firstDrawArmy = true;

		// Token: 0x04001906 RID: 6406
		private bool m_firstDrawFactions = true;

		// Token: 0x04001907 RID: 6407
		private bool m_firstDrawLeaderboard = true;

		// Token: 0x04001908 RID: 6408
		private bool m_firstDrawQuest = true;

		// Token: 0x04001909 RID: 6409
		public int movedFromVillageID = -1;

		// Token: 0x0400190A RID: 6410
		public int movedFromVillageIDNonCapital = -1;

		// Token: 0x0400190B RID: 6411
		private int lastVillageTabID = -1;

		// Token: 0x0400190C RID: 6412
		private bool skipVillageTab;

		// Token: 0x0400190D RID: 6413
		private int nextFactionPage = -1;

		// Token: 0x0400190E RID: 6414
		private int lastFactionTabID = -1;

		// Token: 0x0400190F RID: 6415
		private int sentParentVillageID = -1;

		// Token: 0x04001910 RID: 6416
		private int sentAttackingVillageID = -1;

		// Token: 0x04001911 RID: 6417
		private int sentTargetVillageID = -1;

		// Token: 0x04001912 RID: 6418
		private int pendingErrorCode = -1;

		// Token: 0x04001913 RID: 6419
		private bool appClose;

		// Token: 0x04001914 RID: 6420
		public string connectionErrorString = "";

		// Token: 0x04001915 RID: 6421
		public bool forcingLogout;

		// Token: 0x04001916 RID: 6422
		private bool quitGame;

		// Token: 0x04001917 RID: 6423
		private int lastLoadedVillage = -1;

		// Token: 0x04001918 RID: 6424
		public GameEngine.ConvertVillageDelegate convertVillageCallback;

		// Token: 0x04001919 RID: 6425
		public int lastLoadedCastle = -1;

		// Token: 0x0400191A RID: 6426
		private DebugPopup dPop;

		// Token: 0x0400191B RID: 6427
		private LoginHistoryPopup m_loginHistoryPop;

		// Token: 0x0400191C RID: 6428
		public bool stopInterfaceSounds;

		// Token: 0x0400191D RID: 6429
		private static bool updatedPermissions = false;

		// Token: 0x0400191E RID: 6430
		private GameEngine.MouseClickMessageFilter Filter;

		// Token: 0x0400191F RID: 6431
		private string[] badWords;

		// Token: 0x04001920 RID: 6432
		private static Censor staticCensor = null;

		// Token: 0x04001921 RID: 6433
		private static GameEngine.LowLevelKeyboardProc _proc = new GameEngine.LowLevelKeyboardProc(GameEngine.HookCallback);

		// Token: 0x04001922 RID: 6434
		private static IntPtr _hookID = IntPtr.Zero;

		// Token: 0x04001923 RID: 6435
		private static bool keyboardHookedInstalled = false;

		// Token: 0x04001924 RID: 6436
		public static bool StopKeyTrap = false;

		// Token: 0x04001925 RID: 6437
		private static int lastKeyPressed = 0;

		// Token: 0x04001926 RID: 6438
		public static bool scrollUp = false;

		// Token: 0x04001927 RID: 6439
		public static bool scrollDown = false;

		// Token: 0x04001928 RID: 6440
		public static bool scrollLeft = false;

		// Token: 0x04001929 RID: 6441
		public static bool scrollRight = false;

		// Token: 0x0400192A RID: 6442
		public static bool shiftPressed = false;

		// Token: 0x0400192B RID: 6443
		public static bool shiftPressedAlways = false;

		// Token: 0x0400192C RID: 6444
		public static bool tabPressed = false;

		// Token: 0x0400192D RID: 6445
		public static bool tabReleased = false;

		// Token: 0x0400192E RID: 6446
		public static bool enterPressed = false;

		// Token: 0x0400192F RID: 6447
		public static bool f11Pressed = false;

		// Token: 0x04001930 RID: 6448
		public Point lastMouseMovePosition;

		// Token: 0x04001931 RID: 6449
		public DateTime lastMouseMoveTime = DateTime.Now;

		// Token: 0x04001932 RID: 6450
		private static string userPath = null;

		// Token: 0x04001933 RID: 6451
		private static string userPathBase = null;

		// Token: 0x04001934 RID: 6452
		private static string langPath = null;

		// Token: 0x020001E0 RID: 480
		public enum GameDisplays
		{
			// Token: 0x04001936 RID: 6454
			DISPLAY_VILLAGE,
			// Token: 0x04001937 RID: 6455
			DISPLAY_WORLD,
			// Token: 0x04001938 RID: 6456
			DISPLAY_REPORTS,
			// Token: 0x04001939 RID: 6457
			DISPLAY_CASTLE,
			// Token: 0x0400193A RID: 6458
			DISPLAY_RANKINGS,
			// Token: 0x0400193B RID: 6459
			DISPLAY_RESEARCH,
			// Token: 0x0400193C RID: 6460
			DISPLAY_ARMIES,
			// Token: 0x0400193D RID: 6461
			DISPLAY_MAIL,
			// Token: 0x0400193E RID: 6462
			DISPLAY_ELECTIONS,
			// Token: 0x0400193F RID: 6463
			DISPLAY_POLITICS_VOTE,
			// Token: 0x04001940 RID: 6464
			DISPLAY_POLITICS_FORUM,
			// Token: 0x04001941 RID: 6465
			DISPLAY_AVATAR_EDITOR,
			// Token: 0x04001942 RID: 6466
			DISPLAY_FACTIONS,
			// Token: 0x04001943 RID: 6467
			DISPLAY_WEB,
			// Token: 0x04001944 RID: 6468
			DISPLAY_LEADERBOARD,
			// Token: 0x04001945 RID: 6469
			DISPLAY_QUESTS,
			// Token: 0x04001946 RID: 6470
			DISPLAY_TEMP_DUMMY,
			// Token: 0x04001947 RID: 6471
			DISPLAY_USER_INFO,
			// Token: 0x04001948 RID: 6472
			DISPLAY_ALL_VILLAGES,
			// Token: 0x04001949 RID: 6473
			DISPLAY_CONTESTS_LEADERBOARD,
			// Token: 0x0400194A RID: 6474
			DISPLAY_CONTESTS_HISTORY
		}

		// Token: 0x020001E1 RID: 481
		public enum GameDisplaySubModes
		{
			// Token: 0x0400194C RID: 6476
			SUBMODE_DEFAULT,
			// Token: 0x0400194D RID: 6477
			SUBMODE_CASTLE_ATTACKER_SETUP,
			// Token: 0x0400194E RID: 6478
			SUBMODE_BATTLE,
			// Token: 0x0400194F RID: 6479
			SUBMODE_PREVIEW
		}

		// Token: 0x020001E2 RID: 482
		// (Invoke) Token: 0x060012C3 RID: 4803
		public delegate void ConvertVillageDelegate();

		// Token: 0x020001E3 RID: 483
		public class MouseClickMessageFilter : IMessageFilter
		{
			// Token: 0x060012C6 RID: 4806 RVA: 0x00009262 File Offset: 0x00007462
			public bool PreFilterMessage(ref Message m)
			{
				return false;
			}
		}

		// Token: 0x020001E4 RID: 484
		// (Invoke) Token: 0x060012C9 RID: 4809
		private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

		// Token: 0x020001E5 RID: 485
		// (Invoke) Token: 0x060012CD RID: 4813
		private delegate IntPtr MessageTextProc(int nCode, IntPtr wParam, IntPtr lParam);
	}
}
