namespace Upgrade
{
	// Token: 0x02000016 RID: 22
	public sealed partial class ControlForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000132 RID: 306 RVA: 0x00008A7C File Offset: 0x00006C7C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000133 RID: 307 RVA: 0x0002CD8C File Offset: 0x0002AF8C
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new global::System.Windows.Forms.DataGridViewCellStyle();
			this.tabPage_Trade = new global::System.Windows.Forms.TabPage();
			this.button_TradeCopy = new global::System.Windows.Forms.Button();
			this.tabControl_Trade = new global::System.Windows.Forms.TabControl();
			this.tabPage_TradeMarkets = new global::System.Windows.Forms.TabPage();
			this.splitContainer_Trade = new global::System.Windows.Forms.SplitContainer();
			this.listBox_ActiveVillages = new global::System.Windows.Forms.ListBox();
			this.groupBox_TradingVillage = new global::System.Windows.Forms.GroupBox();
			this.splitContainer_Trade2 = new global::System.Windows.Forms.SplitContainer();
			this.dataGridView_Trade = new global::System.Windows.Forms.DataGridView();
			this.TradeTypeId = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TradeType = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TradeTypeSell = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.TradeMinPrice = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TradeLimit = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TradeBuy = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.TradeMaxBuy = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TradeBuyLimit = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TradeCurrentLevel = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TradeDailyProduction = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.contextMenuStrip_ResourcesQuickSelector = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.selectAllStockpileGoodsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.selectAllFoodToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.selectAllBanquetsGoodsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.selectAllWeaponsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.buyAllStockpileGoodsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.buyAllFoodToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.buyAllBanquetsGoodsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.buyAllWeaponsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.label_Markets = new global::System.Windows.Forms.Label();
			this.button7 = new global::System.Windows.Forms.Button();
			this.textBox_TradeTargetID = new global::System.Windows.Forms.TextBox();
			this.listBox_ParishList = new global::System.Windows.Forms.ListBox();
			this.label_TotalMarkets = new global::System.Windows.Forms.Label();
			this.label_TotalMarketsLabel = new global::System.Windows.Forms.Label();
			this.checkBox_ShouldVillageTrade = new global::System.Windows.Forms.CheckBox();
			this.checkBox_TradeAllVillages = new global::System.Windows.Forms.CheckBox();
			this.label27 = new global::System.Windows.Forms.Label();
			this.button_TradePreviousVillage = new global::System.Windows.Forms.Button();
			this.button_AddMarkets = new global::System.Windows.Forms.Button();
			this.button_TradeNextVillage = new global::System.Windows.Forms.Button();
			this.numericUpDown_MarketsRadius = new global::System.Windows.Forms.NumericUpDown();
			this.comboBox_TradeVillages = new global::System.Windows.Forms.ComboBox();
			this.tabPage_TradeBetweenVillages = new global::System.Windows.Forms.TabPage();
			this.button_TradeRoutesCopy = new global::System.Windows.Forms.Button();
			this.button_TradeRoutesDelete = new global::System.Windows.Forms.Button();
			this.button_TradeRoutesEdit = new global::System.Windows.Forms.Button();
			this.button_TradeRoutesNew = new global::System.Windows.Forms.Button();
			this.dataGridView_TradeRoutes = new global::System.Windows.Forms.DataGridView();
			this.RouteName = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RouteEnabled = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.RouteFrom = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RouteTo = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RouteResourceType = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RouteKeepMinimum = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RouteMaxMerchantsPerTransaction = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RouteSendMaximum = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RouteIsDistanceLimited = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.RouteDistanceLimit = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.contextMenu_TradeRoutes = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.newRouteToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.editTaskToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.tabPage_TradeAdvanced = new global::System.Windows.Forms.TabPage();
			this.numericUpDown_MerchantsExchangeLimit = new global::System.Windows.Forms.NumericUpDown();
			this.numericUpDown_MerchantsTradeLimit = new global::System.Windows.Forms.NumericUpDown();
			this.label_MerchantsExchangeLimit = new global::System.Windows.Forms.Label();
			this.label_MerchantsTradeLimit = new global::System.Windows.Forms.Label();
			this.checkBox_showPopupOnTradeExpiry = new global::System.Windows.Forms.CheckBox();
			this.checkBox_stopTradeOnCardExpiry = new global::System.Windows.Forms.CheckBox();
			this.numericUpDown_AutoHireMerchantsLimit = new global::System.Windows.Forms.NumericUpDown();
			this.checkBox_AutoHireMerchants = new global::System.Windows.Forms.CheckBox();
			this.checkBox_TradeIgnoreCurrentTransactions = new global::System.Windows.Forms.CheckBox();
			this.numericUpDown_PacketsPerTrade = new global::System.Windows.Forms.NumericUpDown();
			this.label4 = new global::System.Windows.Forms.Label();
			this.tabPage_TradeLogs = new global::System.Windows.Forms.TabPage();
			this.richTextBoxTrade = new global::System.Windows.Forms.RichTextBox();
			this.button_TradeHelp = new global::System.Windows.Forms.Button();
			this.checkBox_Trade = new global::System.Windows.Forms.CheckBox();
			this.button4 = new global::System.Windows.Forms.Button();
			this.button5 = new global::System.Windows.Forms.Button();
			this.tabPage_Research = new global::System.Windows.Forms.TabPage();
			this.button_ResearchHelp = new global::System.Windows.Forms.Button();
			this.checkBox_Research = new global::System.Windows.Forms.CheckBox();
			this.comboBox_RankUpMode = new global::System.Windows.Forms.ComboBox();
			this.button_LoadResearches = new global::System.Windows.Forms.Button();
			this.button_SaveResearches = new global::System.Windows.Forms.Button();
			this.richTextBoxResearch = new global::System.Windows.Forms.RichTextBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.textBox_CurrentResearch = new global::System.Windows.Forms.TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.listBox_Queue = new global::System.Windows.Forms.ListBox();
			this.listBox_ResearchList = new global::System.Windows.Forms.ListBox();
			this.tabPage_Scouting = new global::System.Windows.Forms.TabPage();
			this.checkBox_ScoutsWaitFreeSpace = new global::System.Windows.Forms.CheckBox();
			this.label_MinimumScouts = new global::System.Windows.Forms.Label();
			this.numericUpDown_minScouts = new global::System.Windows.Forms.NumericUpDown();
			this.button_ScoutingCopy = new global::System.Windows.Forms.Button();
			this.radioButton_ScoutsPriorityByDistance = new global::System.Windows.Forms.RadioButton();
			this.radioButton_ScoutsPriorityByTypeAndDistance = new global::System.Windows.Forms.RadioButton();
			this.checkBox_showPopupOnScoutsExpiry = new global::System.Windows.Forms.CheckBox();
			this.checkBox_StopScoutsOnCardExpiry = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ScoutingAllVillages = new global::System.Windows.Forms.CheckBox();
			this.button_ScoutingHelp = new global::System.Windows.Forms.Button();
			this.button_ScoutingPreviousVillage = new global::System.Windows.Forms.Button();
			this.button_ScoutingNextVillage = new global::System.Windows.Forms.Button();
			this.comboBox_ScoutingVillages = new global::System.Windows.Forms.ComboBox();
			this.groupBox_ScoutingVillage = new global::System.Windows.Forms.GroupBox();
			this.checkBox_ShouldVillageScout = new global::System.Windows.Forms.CheckBox();
			this.label18 = new global::System.Windows.Forms.Label();
			this.listBox_ScoutingTypes = new global::System.Windows.Forms.ListBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.listBox_ScoutingTypes_Ignore = new global::System.Windows.Forms.ListBox();
			this.checkBox_sendOneScout = new global::System.Windows.Forms.CheckBox();
			this.numericUpDown_ScoutMaxTime = new global::System.Windows.Forms.NumericUpDown();
			this.checkBox_HireScouts = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Scout = new global::System.Windows.Forms.CheckBox();
			this.button_LoadScoutingInfo = new global::System.Windows.Forms.Button();
			this.button_SaveScoutingInfo = new global::System.Windows.Forms.Button();
			this.richTextBoxScout = new global::System.Windows.Forms.RichTextBox();
			this.label12 = new global::System.Windows.Forms.Label();
			this.label_scoutFrom = new global::System.Windows.Forms.Label();
			this.listBox_scoutFrom = new global::System.Windows.Forms.ListBox();
			this.tabPage_Main = new global::System.Windows.Forms.TabPage();
			this.label_LogsToKeep = new global::System.Windows.Forms.Label();
			this.numericUpDown_LogsToKeep = new global::System.Windows.Forms.NumericUpDown();
			this.button_MainHelp = new global::System.Windows.Forms.Button();
			this.checkBox_StayOnTop = new global::System.Windows.Forms.CheckBox();
			this.button_cacheLoad = new global::System.Windows.Forms.Button();
			this.button_cacheSub = new global::System.Windows.Forms.Button();
			this.groupBox_BotLifeCycle = new global::System.Windows.Forms.GroupBox();
			this.label_BotCycleStatusValue = new global::System.Windows.Forms.Label();
			this.checkBox_BotCycleRandomPeriods = new global::System.Windows.Forms.CheckBox();
			this.label_BotCycleStatus = new global::System.Windows.Forms.Label();
			this.numericUpDown_BotWorkPeriod = new global::System.Windows.Forms.NumericUpDown();
			this.label_BotSleepPeriod = new global::System.Windows.Forms.Label();
			this.numericUpDown_BotSleepPeriod = new global::System.Windows.Forms.NumericUpDown();
			this.label_BotWorkPeriod = new global::System.Windows.Forms.Label();
			this.checkBox_CollectFreeCard = new global::System.Windows.Forms.CheckBox();
			this.textBox_UserContactEmail = new global::System.Windows.Forms.TextBox();
			this.label_ContactEmail = new global::System.Windows.Forms.Label();
			this.checkBox_WriteLogs = new global::System.Windows.Forms.CheckBox();
			this.button_CopySettings = new global::System.Windows.Forms.Button();
			this.button_Calc = new global::System.Windows.Forms.Button();
			this.label_subscriptions = new global::System.Windows.Forms.Label();
			this.listBox_Subscriptions = new global::System.Windows.Forms.ListBox();
			this.comboBox_Language = new global::System.Windows.Forms.ComboBox();
			this.button_OpenBotSettings = new global::System.Windows.Forms.Button();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label_ModuleDisable = new global::System.Windows.Forms.Label();
			this.listBox_ModuleDisable = new global::System.Windows.Forms.ListBox();
			this.button_ClearLogs = new global::System.Windows.Forms.Button();
			this.richTextBoxMain = new global::System.Windows.Forms.RichTextBox();
			this.button1 = new global::System.Windows.Forms.Button();
			this.tabControl1 = new global::System.Windows.Forms.TabControl();
			this.tabPage_Feed = new global::System.Windows.Forms.TabPage();
			this.checkBox_FeedShouldNotify = new global::System.Windows.Forms.CheckBox();
			this.webBrowser_Feed = new global::System.Windows.Forms.WebBrowser();
			this.tabPage_AutomaticActions = new global::System.Windows.Forms.TabPage();
			this.checkBox_LoadBanquets = new global::System.Windows.Forms.CheckBox();
			this.checkBox_StartMonks = new global::System.Windows.Forms.CheckBox();
			this.checkBox_LoadMonksSettings = new global::System.Windows.Forms.CheckBox();
			this.checkBox_LoadPredatorSettings = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Loadcastlerepairsettings = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Startregulatepopularity = new global::System.Windows.Forms.CheckBox();
			this.checkBox_StartResearching = new global::System.Windows.Forms.CheckBox();
			this.checkBox_LoadRadarsettings = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Startbuildingvillages = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Loadvillagelayouts = new global::System.Windows.Forms.CheckBox();
			this.checkBox_LoadResearches = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Monitorattacks = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Banquet = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Recruittroops = new global::System.Windows.Forms.CheckBox();
			this.checkBox_DownloadVillages = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Loadtroopsrecruitingsettings = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Starttrading = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Loadtradesettings = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Startscouting = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Loadscoutssettings = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Login = new global::System.Windows.Forms.CheckBox();
			this.checkBox_RememberPassword = new global::System.Windows.Forms.CheckBox();
			this.tabPage_Refresh = new global::System.Windows.Forms.TabPage();
			this.button_RefreshHelp = new global::System.Windows.Forms.Button();
			this.button_LoadRefreshList = new global::System.Windows.Forms.Button();
			this.button_SaveRefreshList = new global::System.Windows.Forms.Button();
			this.checkBox_RefreshCapitals = new global::System.Windows.Forms.CheckBox();
			this.checkBox_IsFullRefreshAllowed = new global::System.Windows.Forms.CheckBox();
			this.richTextBox_Refresh = new global::System.Windows.Forms.RichTextBox();
			this.checkBox_EnableRefresh = new global::System.Windows.Forms.CheckBox();
			this.checkBox_AllRefresh = new global::System.Windows.Forms.CheckBox();
			this.listBox_Refresh = new global::System.Windows.Forms.ListBox();
			this.tabPage_FreeMonitor = new global::System.Windows.Forms.TabPage();
			this.checkedListBox_FreeMonitorColumns = new global::System.Windows.Forms.CheckedListBox();
			this.checkBox_FreeMonitorEnable = new global::System.Windows.Forms.CheckBox();
			this.label_FreeMonitorLastUpdateValue = new global::System.Windows.Forms.Label();
			this.label_FreeMonitorLastUpdate = new global::System.Windows.Forms.Label();
			this.label_NumResearchesInQueueValue = new global::System.Windows.Forms.Label();
			this.label_NumResearchesInQueue = new global::System.Windows.Forms.Label();
			this.dataGridView_FreeMonitor = new global::System.Windows.Forms.DataGridView();
			this.FreeMonitorVillage = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FreeMonitorVillageStatus = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FreeMonitorTraders = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FreeMonitorScouts = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FreeMonitorRecruits = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FreeMonitorBanquets = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FreeMonitorPopularity = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FreeMonitorFaithPoints = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FreeMonitorConstrutionQueue = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FreeMonitorIsCastleDamaged = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.FreeMonitorIsCastleEnlosed = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.FreeMonitorCastleCompleteTime = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FreeMonitorAIsAround = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FreeMonitorCaptains = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabPage_Radar = new global::System.Windows.Forms.TabPage();
			this.button_ExportForOffline = new global::System.Windows.Forms.Button();
			this.tabControl2 = new global::System.Windows.Forms.TabControl();
			this.tabPage_RadarMain = new global::System.Windows.Forms.TabPage();
			this.dataGridView_RadarSettings = new global::System.Windows.Forms.DataGridView();
			this.RadarEvent = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RadarTrackEvent = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.RadarMessagePopup = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.RadarSound = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RadarSendEmail = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.RadarInterdict = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RadarSystemNotification = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.RadarDiscord = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.RadarTelegram = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.tabPage_Interdict = new global::System.Windows.Forms.TabPage();
			this.button_InterdictTabHelp = new global::System.Windows.Forms.Button();
			this.checkBox_Interdict_AllowHireMonks = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Interdict_SkipIfAlreadyID = new global::System.Windows.Forms.CheckBox();
			this.checkBox_InterdictSelectAll = new global::System.Windows.Forms.CheckBox();
			this.numericUpDown_InterdictNumberOfMonks = new global::System.Windows.Forms.NumericUpDown();
			this.label_InterdictNumberOfMonks = new global::System.Windows.Forms.Label();
			this.button_Interdict = new global::System.Windows.Forms.Button();
			this.listBox_Interdict = new global::System.Windows.Forms.ListBox();
			this.tabPage_RadarEmail = new global::System.Windows.Forms.TabPage();
			this.label_RadarEmailStatus = new global::System.Windows.Forms.Label();
			this.checkBox_RadarUseDefault = new global::System.Windows.Forms.CheckBox();
			this.label_RadarLastEmailStatus = new global::System.Windows.Forms.Label();
			this.textBox_ToEmail = new global::System.Windows.Forms.TextBox();
			this.textBox_FromEmailPass = new global::System.Windows.Forms.TextBox();
			this.label_ToEmail = new global::System.Windows.Forms.Label();
			this.label_FromEmail = new global::System.Windows.Forms.Label();
			this.label_FromEmailPass = new global::System.Windows.Forms.Label();
			this.textBox_FromEmail = new global::System.Windows.Forms.TextBox();
			this.tabPage_RadarDiscord = new global::System.Windows.Forms.TabPage();
			this.textBox_DiscordWebhook = new global::System.Windows.Forms.TextBox();
			this.label_DiscordWebhook = new global::System.Windows.Forms.Label();
			this.tabPage_RadarTelegram = new global::System.Windows.Forms.TabPage();
			this.groupBox_TelegramProxy = new global::System.Windows.Forms.GroupBox();
			this.checkBox_ProxyUseCredential = new global::System.Windows.Forms.CheckBox();
			this.label_ProxyPassword = new global::System.Windows.Forms.Label();
			this.label_ProxyLogin = new global::System.Windows.Forms.Label();
			this.label_ProxyPort = new global::System.Windows.Forms.Label();
			this.label_ProxyAddress = new global::System.Windows.Forms.Label();
			this.textBox_ProxyPassword = new global::System.Windows.Forms.TextBox();
			this.checkBox_TelegramUseProxy = new global::System.Windows.Forms.CheckBox();
			this.textBox_ProxyAddress = new global::System.Windows.Forms.TextBox();
			this.textBox_ProxyPort = new global::System.Windows.Forms.TextBox();
			this.textBox_ProxyUsername = new global::System.Windows.Forms.TextBox();
			this.label_TeleTip3 = new global::System.Windows.Forms.Label();
			this.label_TeleTip2 = new global::System.Windows.Forms.Label();
			this.label_TeleTip1 = new global::System.Windows.Forms.Label();
			this.textBox_TelegramChatID = new global::System.Windows.Forms.TextBox();
			this.label_TelegramChatID = new global::System.Windows.Forms.Label();
			this.textBox_TelegramBotToken = new global::System.Windows.Forms.TextBox();
			this.label_TelegramBotToken = new global::System.Windows.Forms.Label();
			this.tabPage_RadarTest = new global::System.Windows.Forms.TabPage();
			this.button_RadarTestTray = new global::System.Windows.Forms.Button();
			this.button_RadarTestTelegram = new global::System.Windows.Forms.Button();
			this.button_RadarTestDiscord = new global::System.Windows.Forms.Button();
			this.button_testID = new global::System.Windows.Forms.Button();
			this.button_TestPopup = new global::System.Windows.Forms.Button();
			this.button_TestMail = new global::System.Windows.Forms.Button();
			this.button_RadarTestSound = new global::System.Windows.Forms.Button();
			this.comboBox_testInderdict = new global::System.Windows.Forms.ComboBox();
			this.tabPage_AltAccounts = new global::System.Windows.Forms.TabPage();
			this.label_RadarAltToolTip = new global::System.Windows.Forms.Label();
			this.button_FindByUsername = new global::System.Windows.Forms.Button();
			this.textBox_RadarFindByUsername = new global::System.Windows.Forms.TextBox();
			this.button_RadarResetAlt = new global::System.Windows.Forms.Button();
			this.button_RadarFindByID = new global::System.Windows.Forms.Button();
			this.numericUpDown_RadarFindByID = new global::System.Windows.Forms.NumericUpDown();
			this.label_RadarAltAccounts = new global::System.Windows.Forms.Label();
			this.tabPage_RadarAutoID = new global::System.Windows.Forms.TabPage();
			this.label_AutoIDExtraDelay = new global::System.Windows.Forms.Label();
			this.label_AutoID = new global::System.Windows.Forms.Label();
			this.numericUpDown_RadarAutoID = new global::System.Windows.Forms.NumericUpDown();
			this.checkBox_RadarRehireMonks = new global::System.Windows.Forms.CheckBox();
			this.button_RadarHelp = new global::System.Windows.Forms.Button();
			this.button_CloseAllMessages = new global::System.Windows.Forms.Button();
			this.button_RadarGridLoad = new global::System.Windows.Forms.Button();
			this.button_RadarGridSave = new global::System.Windows.Forms.Button();
			this.button_StopSoundPlayer = new global::System.Windows.Forms.Button();
			this.checkBox_Monitor = new global::System.Windows.Forms.CheckBox();
			this.richTextBoxRadar = new global::System.Windows.Forms.RichTextBox();
			this.tabPage_Troopsrecruiting = new global::System.Windows.Forms.TabPage();
			this.button_RecruitingCopy = new global::System.Windows.Forms.Button();
			this.button_RecruitingHelp = new global::System.Windows.Forms.Button();
			this.tabControl_TroopsRecruiting = new global::System.Windows.Forms.TabControl();
			this.tabPage_VillagesTroopsRecruiting = new global::System.Windows.Forms.TabPage();
			this.dataGridView_TroopsRecruiting = new global::System.Windows.Forms.DataGridView();
			this.Village = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Recruit = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.Peasants = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Archers = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Pikemen = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Swordsmen = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Catapults = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Captains = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabPage_CapitalsTroopsRecruiting = new global::System.Windows.Forms.TabPage();
			this.dataGridView_CapitalsRecruiting = new global::System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn1 = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewTextBoxColumn2 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabPage_VassalsTroopsRecruiting = new global::System.Windows.Forms.TabPage();
			this.button_VassalsCopy = new global::System.Windows.Forms.Button();
			this.numericUpDown_VassalTroopsMinimum = new global::System.Windows.Forms.NumericUpDown();
			this.label_VassalTroopsMinimum = new global::System.Windows.Forms.Label();
			this.dataGridView_FillVassals = new global::System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn7 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn2 = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewTextBoxColumn8 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn9 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn10 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn11 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn12 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn13 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.numericUpDown2 = new global::System.Windows.Forms.NumericUpDown();
			this.label21 = new global::System.Windows.Forms.Label();
			this.checkBox_recruitingtroops = new global::System.Windows.Forms.CheckBox();
			this.saveTroopsRecruiting = new global::System.Windows.Forms.Button();
			this.loadTroopsRecruiting = new global::System.Windows.Forms.Button();
			this.richTextBoxTroopsRecruiting = new global::System.Windows.Forms.RichTextBox();
			this.tabPage_Spin = new global::System.Windows.Forms.TabPage();
			this.numericUpDown_SpinInterval = new global::System.Windows.Forms.NumericUpDown();
			this.richTextBoxSpins = new global::System.Windows.Forms.RichTextBox();
			this.label31 = new global::System.Windows.Forms.Label();
			this.label25 = new global::System.Windows.Forms.Label();
			this.checkBox_Spin = new global::System.Windows.Forms.CheckBox();
			this.tabPage_Banquet = new global::System.Windows.Forms.TabPage();
			this.button_BanquetCopy = new global::System.Windows.Forms.Button();
			this.button_BanquetLoad = new global::System.Windows.Forms.Button();
			this.button_BanquetSave = new global::System.Windows.Forms.Button();
			this.dataGridView_Banquets = new global::System.Windows.Forms.DataGridView();
			this.BanquetVillage = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.BanquetLevel = new global::System.Windows.Forms.DataGridViewComboBoxColumn();
			this.button_BanquetingHelp = new global::System.Windows.Forms.Button();
			this.numeric_BanquetInterval = new global::System.Windows.Forms.NumericUpDown();
			this.richTextBoxBanquetting = new global::System.Windows.Forms.RichTextBox();
			this.label7 = new global::System.Windows.Forms.Label();
			this.PlayBanquets = new global::System.Windows.Forms.CheckBox();
			this.tabPage_PopularityRegulation = new global::System.Windows.Forms.TabPage();
			this.button_CopyPopularity = new global::System.Windows.Forms.Button();
			this.checkBox_PopularitySelectAll = new global::System.Windows.Forms.CheckBox();
			this.comboBox_PopularityRegulationMode = new global::System.Windows.Forms.ComboBox();
			this.numericUpDown_PopularityRegulation = new global::System.Windows.Forms.NumericUpDown();
			this.listBox_PopularityRegulation = new global::System.Windows.Forms.ListBox();
			this.richTextBoxPopularityRegulation = new global::System.Windows.Forms.RichTextBox();
			this.label14 = new global::System.Windows.Forms.Label();
			this.RegulatePopularity = new global::System.Windows.Forms.CheckBox();
			this.tabPage_Villagelayout = new global::System.Windows.Forms.TabPage();
			this.tabControl_VillageLayouts = new global::System.Windows.Forms.TabControl();
			this.tabPage_villageLayouts = new global::System.Windows.Forms.TabPage();
			this.groupBox_villageLayoutsNavigation = new global::System.Windows.Forms.GroupBox();
			this.button_previousLayout = new global::System.Windows.Forms.Button();
			this.button_nextLayout = new global::System.Windows.Forms.Button();
			this.comboBox_villageLayouts = new global::System.Windows.Forms.ComboBox();
			this.groupBox_VillageLayoutsSettings = new global::System.Windows.Forms.GroupBox();
			this.button_VillageCopy = new global::System.Windows.Forms.Button();
			this.button_VillageLayouts_Help = new global::System.Windows.Forms.Button();
			this.checkBox_VillageLayouts = new global::System.Windows.Forms.CheckBox();
			this.numericUpDown_VillageLayoutInterval = new global::System.Windows.Forms.NumericUpDown();
			this.checkBox_AutoConstr_WaitRes = new global::System.Windows.Forms.CheckBox();
			this.button8 = new global::System.Windows.Forms.Button();
			this.label_villageConstruction_interval = new global::System.Windows.Forms.Label();
			this.button_SaveLayouts = new global::System.Windows.Forms.Button();
			this.groupBox_SelectedLayout = new global::System.Windows.Forms.GroupBox();
			this.button_ImportLayoutFromFile = new global::System.Windows.Forms.Button();
			this.comboBox_VillageTemplate = new global::System.Windows.Forms.ComboBox();
			this.label_VillageTemplate = new global::System.Windows.Forms.Label();
			this.checkBox_ShouldLayoutBeBuilt = new global::System.Windows.Forms.CheckBox();
			this.dataGridViewVillageLayoutsEdit = new global::System.Windows.Forms.DataGridView();
			this.typeID = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TypeName = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Number = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.BuildingStatus = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Xcoord = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Ycoord = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.checkBox_villagesLayoutsSelectAll = new global::System.Windows.Forms.CheckBox();
			this.listBox_VillageLayouts = new global::System.Windows.Forms.ListBox();
			this.tabPage_villageLayoutsLogs = new global::System.Windows.Forms.TabPage();
			this.richTextBoxVillageLayouts = new global::System.Windows.Forms.RichTextBox();
			this.tabPage_Castle = new global::System.Windows.Forms.TabPage();
			this.button_CastleHelp = new global::System.Windows.Forms.Button();
			this.button3 = new global::System.Windows.Forms.Button();
			this.checkBox_AutoRepairCastle = new global::System.Windows.Forms.CheckBox();
			this.button_SaveCastlesLocally = new global::System.Windows.Forms.Button();
			this.button_CastleLoad = new global::System.Windows.Forms.Button();
			this.button_CastleSave = new global::System.Windows.Forms.Button();
			this.dataGridView_RepairCastle = new global::System.Windows.Forms.DataGridView();
			this.CastleVillageName = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CastleRestoreCastle = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.CastleSelectLayout = new global::System.Windows.Forms.DataGridViewComboBoxColumn();
			this.CastleRestoreTroops = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.CastleSelectTroops = new global::System.Windows.Forms.DataGridViewComboBoxColumn();
			this.richTextBoxCastle = new global::System.Windows.Forms.RichTextBox();
			this.button_FixCastles = new global::System.Windows.Forms.Button();
			this.tabPage_Predator = new global::System.Windows.Forms.TabPage();
			this.button_PredatorCopy = new global::System.Windows.Forms.Button();
			this.button_PredatorHelp = new global::System.Windows.Forms.Button();
			this.tabControl_PredatorSettings = new global::System.Windows.Forms.TabControl();
			this.tabPage1 = new global::System.Windows.Forms.TabPage();
			this.dataGridView_PredatorPreys = new global::System.Windows.Forms.DataGridView();
			this.PreyType = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PreyName = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PreyHunt = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.MaxDistance = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.IncludeVassalHonourRange = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.IncludeCapitalHonourRange = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.NotifyWithMessage = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.NotifyWithSound = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.Kill = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.PredatorAttackFormation = new global::System.Windows.Forms.DataGridViewComboBoxColumn();
			this.label_whatYouWannaHunt = new global::System.Windows.Forms.Label();
			this.tabPage2 = new global::System.Windows.Forms.TabPage();
			this.checkBox_PredatorCapitals = new global::System.Windows.Forms.CheckBox();
			this.checkBox_PredatorVassals = new global::System.Windows.Forms.CheckBox();
			this.checkBox_PredatorVillages = new global::System.Windows.Forms.CheckBox();
			this.label_PredatorCapitals = new global::System.Windows.Forms.Label();
			this.label_PredatorVassals = new global::System.Windows.Forms.Label();
			this.label_PredatorVillages = new global::System.Windows.Forms.Label();
			this.listBox_PredatorCapitals = new global::System.Windows.Forms.ListBox();
			this.listBox_PredatorVassals = new global::System.Windows.Forms.ListBox();
			this.listBox_PredatorVillages = new global::System.Windows.Forms.ListBox();
			this.tabPage3 = new global::System.Windows.Forms.TabPage();
			this.checkBox_HuntWithinParish = new global::System.Windows.Forms.CheckBox();
			this.checkBox_PredatorUseCastleTroops = new global::System.Windows.Forms.CheckBox();
			this.tabControl_Predator = new global::System.Windows.Forms.TabControl();
			this.tabPage_FoundPreys = new global::System.Windows.Forms.TabPage();
			this.button_UpdateCapitalsSpeed2 = new global::System.Windows.Forms.Button();
			this.dataGridView_FoundPreys = new global::System.Windows.Forms.DataGridView();
			this.PreyId = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Prey = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PreyDistance = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PreyNextTo = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PreyTime = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.button_ClearPreys = new global::System.Windows.Forms.Button();
			this.tabPage_Logs = new global::System.Windows.Forms.TabPage();
			this.richTextBoxPredator = new global::System.Windows.Forms.RichTextBox();
			this.button_PredatorUpdatePresets = new global::System.Windows.Forms.Button();
			this.button_predatorStopSound = new global::System.Windows.Forms.Button();
			this.checkBox_StartHunting = new global::System.Windows.Forms.CheckBox();
			this.button_LoadPrays = new global::System.Windows.Forms.Button();
			this.button_SavePrays = new global::System.Windows.Forms.Button();
			this.tabPage_TimedAttacks = new global::System.Windows.Forms.TabPage();
			this.button_TimingHelp = new global::System.Windows.Forms.Button();
			this.listBox1 = new global::System.Windows.Forms.ListBox();
			this.button_UpdateCapitalsSpeed = new global::System.Windows.Forms.Button();
			this.richTextBoxTimedAttacks = new global::System.Windows.Forms.RichTextBox();
			this.label_TimedAttacksTargetId = new global::System.Windows.Forms.Label();
			this.textBox_getAttackersTarget = new global::System.Windows.Forms.TextBox();
			this.btnGetAttackers = new global::System.Windows.Forms.Button();
			this.tabPage_Monks = new global::System.Windows.Forms.TabPage();
			this.numericUpDown_KeepMonks = new global::System.Windows.Forms.NumericUpDown();
			this.label_KeepMonks = new global::System.Windows.Forms.Label();
			this.dataGridView_Monks = new global::System.Windows.Forms.DataGridView();
			this.MonkRouteName = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MonkRouteEnabled = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.MonkRouteVillages = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MonkRouteTargets = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MonkRouteCommand = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MonkRouteStopCondition = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MonkRouteParameter = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MonkRouteIsDistanceLimited = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.MonkRouteDistanceLimit = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.contextMenu_MonkRoutes = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.button_HelpMonks = new global::System.Windows.Forms.Button();
			this.button_LoadMonks = new global::System.Windows.Forms.Button();
			this.checkBox_EnableMonks = new global::System.Windows.Forms.CheckBox();
			this.button_SaveMonks = new global::System.Windows.Forms.Button();
			this.richTextBoxMonks = new global::System.Windows.Forms.RichTextBox();
			this.tabPage_Error = new global::System.Windows.Forms.TabPage();
			this.button_ClearErrors = new global::System.Windows.Forms.Button();
			this.richTextBox_Errors = new global::System.Windows.Forms.RichTextBox();
			this.toolTip1 = new global::System.Windows.Forms.ToolTip(this.components);
			this.label_Contacts = new global::System.Windows.Forms.Label();
			this.linkLabel_botSiteLink = new global::System.Windows.Forms.LinkLabel();
			this.label_contributions = new global::System.Windows.Forms.Label();
			this.textBox_contactEmail = new global::System.Windows.Forms.TextBox();
			this.button_PauseEveryThing = new global::System.Windows.Forms.Button();
			this.radarNotifyIcon = new global::System.Windows.Forms.NotifyIcon(this.components);
			this.tabPage_Trade.SuspendLayout();
			this.tabControl_Trade.SuspendLayout();
			this.tabPage_TradeMarkets.SuspendLayout();
			this.splitContainer_Trade.Panel1.SuspendLayout();
			this.splitContainer_Trade.Panel2.SuspendLayout();
			this.splitContainer_Trade.SuspendLayout();
			this.groupBox_TradingVillage.SuspendLayout();
			this.splitContainer_Trade2.Panel1.SuspendLayout();
			this.splitContainer_Trade2.Panel2.SuspendLayout();
			this.splitContainer_Trade2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView_Trade).BeginInit();
			this.contextMenuStrip_ResourcesQuickSelector.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_MarketsRadius).BeginInit();
			this.tabPage_TradeBetweenVillages.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView_TradeRoutes).BeginInit();
			this.contextMenu_TradeRoutes.SuspendLayout();
			this.tabPage_TradeAdvanced.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_MerchantsExchangeLimit).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_MerchantsTradeLimit).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_AutoHireMerchantsLimit).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_PacketsPerTrade).BeginInit();
			this.tabPage_TradeLogs.SuspendLayout();
			this.tabPage_Research.SuspendLayout();
			this.tabPage_Scouting.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_minScouts).BeginInit();
			this.groupBox_ScoutingVillage.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_ScoutMaxTime).BeginInit();
			this.tabPage_Main.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_LogsToKeep).BeginInit();
			this.groupBox_BotLifeCycle.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_BotWorkPeriod).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_BotSleepPeriod).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage_Feed.SuspendLayout();
			this.tabPage_AutomaticActions.SuspendLayout();
			this.tabPage_Refresh.SuspendLayout();
			this.tabPage_FreeMonitor.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView_FreeMonitor).BeginInit();
			this.tabPage_Radar.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabPage_RadarMain.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView_RadarSettings).BeginInit();
			this.tabPage_Interdict.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_InterdictNumberOfMonks).BeginInit();
			this.tabPage_RadarEmail.SuspendLayout();
			this.tabPage_RadarDiscord.SuspendLayout();
			this.tabPage_RadarTelegram.SuspendLayout();
			this.groupBox_TelegramProxy.SuspendLayout();
			this.tabPage_RadarTest.SuspendLayout();
			this.tabPage_AltAccounts.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_RadarFindByID).BeginInit();
			this.tabPage_RadarAutoID.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_RadarAutoID).BeginInit();
			this.tabPage_Troopsrecruiting.SuspendLayout();
			this.tabControl_TroopsRecruiting.SuspendLayout();
			this.tabPage_VillagesTroopsRecruiting.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView_TroopsRecruiting).BeginInit();
			this.tabPage_CapitalsTroopsRecruiting.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView_CapitalsRecruiting).BeginInit();
			this.tabPage_VassalsTroopsRecruiting.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_VassalTroopsMinimum).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView_FillVassals).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown2).BeginInit();
			this.tabPage_Spin.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_SpinInterval).BeginInit();
			this.tabPage_Banquet.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView_Banquets).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numeric_BanquetInterval).BeginInit();
			this.tabPage_PopularityRegulation.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_PopularityRegulation).BeginInit();
			this.tabPage_Villagelayout.SuspendLayout();
			this.tabControl_VillageLayouts.SuspendLayout();
			this.tabPage_villageLayouts.SuspendLayout();
			this.groupBox_villageLayoutsNavigation.SuspendLayout();
			this.groupBox_VillageLayoutsSettings.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_VillageLayoutInterval).BeginInit();
			this.groupBox_SelectedLayout.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridViewVillageLayoutsEdit).BeginInit();
			this.tabPage_villageLayoutsLogs.SuspendLayout();
			this.tabPage_Castle.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView_RepairCastle).BeginInit();
			this.tabPage_Predator.SuspendLayout();
			this.tabControl_PredatorSettings.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView_PredatorPreys).BeginInit();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabControl_Predator.SuspendLayout();
			this.tabPage_FoundPreys.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView_FoundPreys).BeginInit();
			this.tabPage_Logs.SuspendLayout();
			this.tabPage_TimedAttacks.SuspendLayout();
			this.tabPage_Monks.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_KeepMonks).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView_Monks).BeginInit();
			this.contextMenu_MonkRoutes.SuspendLayout();
			this.tabPage_Error.SuspendLayout();
			base.SuspendLayout();
			this.tabPage_Trade.Controls.Add(this.button_TradeCopy);
			this.tabPage_Trade.Controls.Add(this.tabControl_Trade);
			this.tabPage_Trade.Controls.Add(this.button_TradeHelp);
			this.tabPage_Trade.Controls.Add(this.checkBox_Trade);
			this.tabPage_Trade.Controls.Add(this.button4);
			this.tabPage_Trade.Controls.Add(this.button5);
			this.tabPage_Trade.Location = new global::System.Drawing.Point(4, 40);
			this.tabPage_Trade.Name = "tabPage_Trade";
			this.tabPage_Trade.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage_Trade.Size = new global::System.Drawing.Size(556, 624);
			this.tabPage_Trade.TabIndex = 6;
			this.tabPage_Trade.Text = "Trade";
			this.tabPage_Trade.UseVisualStyleBackColor = true;
			this.button_TradeCopy.Location = new global::System.Drawing.Point(429, 3);
			this.button_TradeCopy.Name = "button_TradeCopy";
			this.button_TradeCopy.Size = new global::System.Drawing.Size(124, 23);
			this.button_TradeCopy.TabIndex = 94;
			this.button_TradeCopy.Text = "Copy Settings";
			this.toolTip1.SetToolTip(this.button_TradeCopy, "CTRL+Shift+C");
			this.button_TradeCopy.UseVisualStyleBackColor = true;
			this.button_TradeCopy.Click += new global::System.EventHandler(this.button_CopySettings_Click);
			this.tabControl_Trade.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.tabControl_Trade.Controls.Add(this.tabPage_TradeMarkets);
			this.tabControl_Trade.Controls.Add(this.tabPage_TradeBetweenVillages);
			this.tabControl_Trade.Controls.Add(this.tabPage_TradeAdvanced);
			this.tabControl_Trade.Controls.Add(this.tabPage_TradeLogs);
			this.tabControl_Trade.Location = new global::System.Drawing.Point(3, 29);
			this.tabControl_Trade.Name = "tabControl_Trade";
			this.tabControl_Trade.SelectedIndex = 0;
			this.tabControl_Trade.Size = new global::System.Drawing.Size(550, 592);
			this.tabControl_Trade.TabIndex = 89;
			this.tabPage_TradeMarkets.Controls.Add(this.splitContainer_Trade);
			this.tabPage_TradeMarkets.Controls.Add(this.checkBox_TradeAllVillages);
			this.tabPage_TradeMarkets.Controls.Add(this.label27);
			this.tabPage_TradeMarkets.Controls.Add(this.button_TradePreviousVillage);
			this.tabPage_TradeMarkets.Controls.Add(this.button_AddMarkets);
			this.tabPage_TradeMarkets.Controls.Add(this.button_TradeNextVillage);
			this.tabPage_TradeMarkets.Controls.Add(this.numericUpDown_MarketsRadius);
			this.tabPage_TradeMarkets.Controls.Add(this.comboBox_TradeVillages);
			this.tabPage_TradeMarkets.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage_TradeMarkets.Name = "tabPage_TradeMarkets";
			this.tabPage_TradeMarkets.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage_TradeMarkets.Size = new global::System.Drawing.Size(542, 566);
			this.tabPage_TradeMarkets.TabIndex = 0;
			this.tabPage_TradeMarkets.Text = "Trade with Markets";
			this.tabPage_TradeMarkets.UseVisualStyleBackColor = true;
			this.splitContainer_Trade.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.splitContainer_Trade.FixedPanel = global::System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer_Trade.Location = new global::System.Drawing.Point(0, 29);
			this.splitContainer_Trade.Name = "splitContainer_Trade";
			this.splitContainer_Trade.Panel1.Controls.Add(this.listBox_ActiveVillages);
			this.splitContainer_Trade.Panel1MinSize = 5;
			this.splitContainer_Trade.Panel2.Controls.Add(this.groupBox_TradingVillage);
			this.splitContainer_Trade.Panel2MinSize = 5;
			this.splitContainer_Trade.Size = new global::System.Drawing.Size(542, 537);
			this.splitContainer_Trade.SplitterDistance = 114;
			this.splitContainer_Trade.TabIndex = 93;
			this.listBox_ActiveVillages.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.listBox_ActiveVillages.FormattingEnabled = true;
			this.listBox_ActiveVillages.Location = new global::System.Drawing.Point(0, 0);
			this.listBox_ActiveVillages.Name = "listBox_ActiveVillages";
			this.listBox_ActiveVillages.SelectionMode = global::System.Windows.Forms.SelectionMode.MultiSimple;
			this.listBox_ActiveVillages.Size = new global::System.Drawing.Size(114, 537);
			this.listBox_ActiveVillages.TabIndex = 57;
			this.listBox_ActiveVillages.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.listBox_ActiveVillages_MouseDown);
			this.groupBox_TradingVillage.BackColor = global::System.Drawing.Color.PaleGreen;
			this.groupBox_TradingVillage.Controls.Add(this.splitContainer_Trade2);
			this.groupBox_TradingVillage.Controls.Add(this.label_TotalMarkets);
			this.groupBox_TradingVillage.Controls.Add(this.label_TotalMarketsLabel);
			this.groupBox_TradingVillage.Controls.Add(this.checkBox_ShouldVillageTrade);
			this.groupBox_TradingVillage.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox_TradingVillage.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.groupBox_TradingVillage.Location = new global::System.Drawing.Point(0, 0);
			this.groupBox_TradingVillage.Name = "groupBox_TradingVillage";
			this.groupBox_TradingVillage.Size = new global::System.Drawing.Size(424, 537);
			this.groupBox_TradingVillage.TabIndex = 88;
			this.groupBox_TradingVillage.TabStop = false;
			this.groupBox_TradingVillage.Text = "No selected village";
			this.splitContainer_Trade2.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.splitContainer_Trade2.Location = new global::System.Drawing.Point(0, 32);
			this.splitContainer_Trade2.Name = "splitContainer_Trade2";
			this.splitContainer_Trade2.Panel1.Controls.Add(this.dataGridView_Trade);
			this.splitContainer_Trade2.Panel1MinSize = 5;
			this.splitContainer_Trade2.Panel2.Controls.Add(this.label_Markets);
			this.splitContainer_Trade2.Panel2.Controls.Add(this.button7);
			this.splitContainer_Trade2.Panel2.Controls.Add(this.textBox_TradeTargetID);
			this.splitContainer_Trade2.Panel2.Controls.Add(this.listBox_ParishList);
			this.splitContainer_Trade2.Panel2MinSize = 5;
			this.splitContainer_Trade2.Size = new global::System.Drawing.Size(424, 502);
			this.splitContainer_Trade2.SplitterDistance = 338;
			this.splitContainer_Trade2.TabIndex = 89;
			this.dataGridView_Trade.AllowUserToAddRows = false;
			this.dataGridView_Trade.AllowUserToDeleteRows = false;
			this.dataGridView_Trade.AllowUserToOrderColumns = true;
			this.dataGridView_Trade.AutoSizeColumnsMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView_Trade.AutoSizeRowsMode = global::System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridView_Trade.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_Trade.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.TradeTypeId,
				this.TradeType,
				this.TradeTypeSell,
				this.TradeMinPrice,
				this.TradeLimit,
				this.TradeBuy,
				this.TradeMaxBuy,
				this.TradeBuyLimit,
				this.TradeCurrentLevel,
				this.TradeDailyProduction
			});
			this.dataGridView_Trade.ContextMenuStrip = this.contextMenuStrip_ResourcesQuickSelector;
			this.dataGridView_Trade.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.dataGridView_Trade.Location = new global::System.Drawing.Point(0, 0);
			this.dataGridView_Trade.Name = "dataGridView_Trade";
			this.dataGridView_Trade.RowHeadersVisible = false;
			this.dataGridView_Trade.RowTemplate.Height = 18;
			this.dataGridView_Trade.Size = new global::System.Drawing.Size(338, 502);
			this.dataGridView_Trade.TabIndex = 85;
			this.TradeTypeId.HeaderText = "TypeId";
			this.TradeTypeId.Name = "TradeTypeId";
			this.TradeTypeId.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.TradeTypeId.Visible = false;
			this.TradeType.HeaderText = "Type";
			this.TradeType.Name = "TradeType";
			this.TradeType.ReadOnly = true;
			this.TradeType.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			dataGridViewCellStyle.Alignment = global::System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle.BackColor = global::System.Drawing.Color.Aqua;
			dataGridViewCellStyle.NullValue = false;
			this.TradeTypeSell.DefaultCellStyle = dataGridViewCellStyle;
			this.TradeTypeSell.HeaderText = "Sell";
			this.TradeTypeSell.Name = "TradeTypeSell";
			dataGridViewCellStyle2.BackColor = global::System.Drawing.Color.Aqua;
			this.TradeMinPrice.DefaultCellStyle = dataGridViewCellStyle2;
			this.TradeMinPrice.HeaderText = "Min";
			this.TradeMinPrice.Name = "TradeMinPrice";
			this.TradeMinPrice.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.TradeMinPrice.ToolTipText = "Minimum Selling Price";
			dataGridViewCellStyle3.BackColor = global::System.Drawing.Color.Aqua;
			this.TradeLimit.DefaultCellStyle = dataGridViewCellStyle3;
			this.TradeLimit.HeaderText = "Sell Limit";
			this.TradeLimit.Name = "TradeLimit";
			this.TradeLimit.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.TradeLimit.ToolTipText = "Minimum amount to keep in the village";
			dataGridViewCellStyle4.Alignment = global::System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle4.BackColor = global::System.Drawing.Color.Pink;
			dataGridViewCellStyle4.NullValue = false;
			this.TradeBuy.DefaultCellStyle = dataGridViewCellStyle4;
			this.TradeBuy.HeaderText = "Buy";
			this.TradeBuy.Name = "TradeBuy";
			this.TradeBuy.Resizable = global::System.Windows.Forms.DataGridViewTriState.True;
			dataGridViewCellStyle5.BackColor = global::System.Drawing.Color.Pink;
			this.TradeMaxBuy.DefaultCellStyle = dataGridViewCellStyle5;
			this.TradeMaxBuy.HeaderText = "Max ";
			this.TradeMaxBuy.Name = "TradeMaxBuy";
			this.TradeMaxBuy.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.TradeMaxBuy.ToolTipText = "Maximum Buy Price";
			dataGridViewCellStyle6.BackColor = global::System.Drawing.Color.Pink;
			this.TradeBuyLimit.DefaultCellStyle = dataGridViewCellStyle6;
			this.TradeBuyLimit.HeaderText = "Buy Limit";
			this.TradeBuyLimit.Name = "TradeBuyLimit";
			this.TradeBuyLimit.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.TradeBuyLimit.ToolTipText = "Maximum amount to keep in the village";
			this.TradeCurrentLevel.HeaderText = "Current amount";
			this.TradeCurrentLevel.Name = "TradeCurrentLevel";
			this.TradeCurrentLevel.ReadOnly = true;
			this.TradeCurrentLevel.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.TradeCurrentLevel.ToolTipText = "How much you currently have (read only column)";
			this.TradeDailyProduction.HeaderText = "Daily Production";
			this.TradeDailyProduction.Name = "TradeDailyProduction";
			this.TradeDailyProduction.ReadOnly = true;
			this.TradeDailyProduction.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.TradeDailyProduction.ToolTipText = "How much you currently produce (read only column)";
			this.contextMenuStrip_ResourcesQuickSelector.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.selectAllStockpileGoodsToolStripMenuItem,
				this.selectAllFoodToolStripMenuItem,
				this.selectAllBanquetsGoodsToolStripMenuItem,
				this.selectAllWeaponsToolStripMenuItem,
				this.buyAllStockpileGoodsToolStripMenuItem,
				this.buyAllFoodToolStripMenuItem,
				this.buyAllBanquetsGoodsToolStripMenuItem,
				this.buyAllWeaponsToolStripMenuItem
			});
			this.contextMenuStrip_ResourcesQuickSelector.Name = "contextMenuStrip_ResourcesQuickSelector";
			this.contextMenuStrip_ResourcesQuickSelector.Size = new global::System.Drawing.Size(201, 180);
			this.selectAllStockpileGoodsToolStripMenuItem.Name = "selectAllStockpileGoodsToolStripMenuItem";
			this.selectAllStockpileGoodsToolStripMenuItem.Size = new global::System.Drawing.Size(200, 22);
			this.selectAllStockpileGoodsToolStripMenuItem.Text = "Sell All Stockpile Goods";
			this.selectAllStockpileGoodsToolStripMenuItem.Click += new global::System.EventHandler(this.selectAllStockpileGoodsToolStripMenuItem_Click);
			this.selectAllFoodToolStripMenuItem.Name = "selectAllFoodToolStripMenuItem";
			this.selectAllFoodToolStripMenuItem.Size = new global::System.Drawing.Size(200, 22);
			this.selectAllFoodToolStripMenuItem.Text = "Sell All Food";
			this.selectAllFoodToolStripMenuItem.Click += new global::System.EventHandler(this.selectAllFoodToolStripMenuItem_Click);
			this.selectAllBanquetsGoodsToolStripMenuItem.Name = "selectAllBanquetsGoodsToolStripMenuItem";
			this.selectAllBanquetsGoodsToolStripMenuItem.Size = new global::System.Drawing.Size(200, 22);
			this.selectAllBanquetsGoodsToolStripMenuItem.Text = "Sell All Banquets Goods";
			this.selectAllBanquetsGoodsToolStripMenuItem.Click += new global::System.EventHandler(this.selectAllBanquetsGoodsToolStripMenuItem_Click);
			this.selectAllWeaponsToolStripMenuItem.Name = "selectAllWeaponsToolStripMenuItem";
			this.selectAllWeaponsToolStripMenuItem.Size = new global::System.Drawing.Size(200, 22);
			this.selectAllWeaponsToolStripMenuItem.Text = "Sell All Weapons";
			this.selectAllWeaponsToolStripMenuItem.Click += new global::System.EventHandler(this.selectAllWeaponsToolStripMenuItem_Click);
			this.buyAllStockpileGoodsToolStripMenuItem.Name = "buyAllStockpileGoodsToolStripMenuItem";
			this.buyAllStockpileGoodsToolStripMenuItem.Size = new global::System.Drawing.Size(200, 22);
			this.buyAllStockpileGoodsToolStripMenuItem.Text = "Buy All Stockpile Goods";
			this.buyAllStockpileGoodsToolStripMenuItem.Click += new global::System.EventHandler(this.buyAllStockpileGoodsToolStripMenuItem_Click);
			this.buyAllFoodToolStripMenuItem.Name = "buyAllFoodToolStripMenuItem";
			this.buyAllFoodToolStripMenuItem.Size = new global::System.Drawing.Size(200, 22);
			this.buyAllFoodToolStripMenuItem.Text = "Buy All Food";
			this.buyAllFoodToolStripMenuItem.Click += new global::System.EventHandler(this.buyAllFoodToolStripMenuItem_Click);
			this.buyAllBanquetsGoodsToolStripMenuItem.Name = "buyAllBanquetsGoodsToolStripMenuItem";
			this.buyAllBanquetsGoodsToolStripMenuItem.Size = new global::System.Drawing.Size(200, 22);
			this.buyAllBanquetsGoodsToolStripMenuItem.Text = "Buy All Banquets Goods";
			this.buyAllBanquetsGoodsToolStripMenuItem.Click += new global::System.EventHandler(this.buyAllBanquetsGoodsToolStripMenuItem_Click);
			this.buyAllWeaponsToolStripMenuItem.Name = "buyAllWeaponsToolStripMenuItem";
			this.buyAllWeaponsToolStripMenuItem.Size = new global::System.Drawing.Size(200, 22);
			this.buyAllWeaponsToolStripMenuItem.Text = "Buy All Weapons";
			this.buyAllWeaponsToolStripMenuItem.Click += new global::System.EventHandler(this.buyAllWeaponsToolStripMenuItem_Click);
			this.label_Markets.AutoSize = true;
			this.label_Markets.Location = new global::System.Drawing.Point(1, 0);
			this.label_Markets.Name = "label_Markets";
			this.label_Markets.Size = new global::System.Drawing.Size(48, 13);
			this.label_Markets.TabIndex = 61;
			this.label_Markets.Text = "Markets:";
			this.toolTip1.SetToolTip(this.label_Markets, "List of markets");
			this.button7.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.button7.Location = new global::System.Drawing.Point(-1, 477);
			this.button7.Name = "button7";
			this.button7.Size = new global::System.Drawing.Size(23, 23);
			this.button7.TabIndex = 58;
			this.button7.Text = "+";
			this.toolTip1.SetToolTip(this.button7, "Push to add new market ID to the list");
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new global::System.EventHandler(this.button_Add_Click);
			this.textBox_TradeTargetID.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.textBox_TradeTargetID.Location = new global::System.Drawing.Point(24, 479);
			this.textBox_TradeTargetID.Name = "textBox_TradeTargetID";
			this.textBox_TradeTargetID.Size = new global::System.Drawing.Size(54, 20);
			this.textBox_TradeTargetID.TabIndex = 48;
			this.toolTip1.SetToolTip(this.textBox_TradeTargetID, "Type capital ID to add new market");
			this.listBox_ParishList.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.listBox_ParishList.FormattingEnabled = true;
			this.listBox_ParishList.Location = new global::System.Drawing.Point(1, 13);
			this.listBox_ParishList.Name = "listBox_ParishList";
			this.listBox_ParishList.Size = new global::System.Drawing.Size(76, 446);
			this.listBox_ParishList.TabIndex = 56;
			this.toolTip1.SetToolTip(this.listBox_ParishList, "Double click to remove market from list");
			this.listBox_ParishList.DoubleClick += new global::System.EventHandler(this.listBox_ParishList_DoubleClick);
			this.label_TotalMarkets.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.label_TotalMarkets.Location = new global::System.Drawing.Point(373, 16);
			this.label_TotalMarkets.Name = "label_TotalMarkets";
			this.label_TotalMarkets.Size = new global::System.Drawing.Size(40, 13);
			this.label_TotalMarkets.TabIndex = 88;
			this.label_TotalMarkets.Text = "0";
			this.label_TotalMarkets.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.label_TotalMarketsLabel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.label_TotalMarketsLabel.AutoSize = true;
			this.label_TotalMarketsLabel.Location = new global::System.Drawing.Point(292, 16);
			this.label_TotalMarketsLabel.Name = "label_TotalMarketsLabel";
			this.label_TotalMarketsLabel.Size = new global::System.Drawing.Size(75, 13);
			this.label_TotalMarketsLabel.TabIndex = 87;
			this.label_TotalMarketsLabel.Text = "Total Markets:";
			this.toolTip1.SetToolTip(this.label_TotalMarketsLabel, "Total number of markets this village is set to trade with");
			this.checkBox_ShouldVillageTrade.AutoSize = true;
			this.checkBox_ShouldVillageTrade.Location = new global::System.Drawing.Point(7, 15);
			this.checkBox_ShouldVillageTrade.Name = "checkBox_ShouldVillageTrade";
			this.checkBox_ShouldVillageTrade.Size = new global::System.Drawing.Size(144, 17);
			this.checkBox_ShouldVillageTrade.TabIndex = 86;
			this.checkBox_ShouldVillageTrade.Text = "Should this village trade?";
			this.checkBox_ShouldVillageTrade.UseVisualStyleBackColor = true;
			this.checkBox_ShouldVillageTrade.CheckedChanged += new global::System.EventHandler(this.checkBox_ShouldVillageTrade_CheckedChanged);
			this.checkBox_TradeAllVillages.AutoSize = true;
			this.checkBox_TradeAllVillages.Checked = true;
			this.checkBox_TradeAllVillages.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.checkBox_TradeAllVillages.Location = new global::System.Drawing.Point(101, 13);
			this.checkBox_TradeAllVillages.Name = "checkBox_TradeAllVillages";
			this.checkBox_TradeAllVillages.Size = new global::System.Drawing.Size(15, 14);
			this.checkBox_TradeAllVillages.TabIndex = 92;
			this.toolTip1.SetToolTip(this.checkBox_TradeAllVillages, "Selects all villages to trade or to stop trading");
			this.checkBox_TradeAllVillages.UseVisualStyleBackColor = true;
			this.checkBox_TradeAllVillages.CheckedChanged += new global::System.EventHandler(this.checkBox_TradeAllVillages_CheckedChanged);
			this.label27.AutoSize = true;
			this.label27.Location = new global::System.Drawing.Point(-2, 10);
			this.label27.Name = "label27";
			this.label27.Size = new global::System.Drawing.Size(61, 13);
			this.label27.TabIndex = 60;
			this.label27.Text = "Trade from:";
			this.button_TradePreviousVillage.Location = new global::System.Drawing.Point(117, 3);
			this.button_TradePreviousVillage.Name = "button_TradePreviousVillage";
			this.button_TradePreviousVillage.Size = new global::System.Drawing.Size(30, 23);
			this.button_TradePreviousVillage.TabIndex = 91;
			this.button_TradePreviousVillage.Text = "<-";
			this.toolTip1.SetToolTip(this.button_TradePreviousVillage, "Previous village settings (CTRL+Left)");
			this.button_TradePreviousVillage.UseVisualStyleBackColor = true;
			this.button_TradePreviousVillage.Click += new global::System.EventHandler(this.button_TradePreviousVillage_Click);
			this.button_AddMarkets.Location = new global::System.Drawing.Point(354, 3);
			this.button_AddMarkets.Name = "button_AddMarkets";
			this.button_AddMarkets.Size = new global::System.Drawing.Size(149, 23);
			this.button_AddMarkets.TabIndex = 73;
			this.button_AddMarkets.Text = "Add Markets";
			this.toolTip1.SetToolTip(this.button_AddMarkets, "Adds all available markets within specified range");
			this.button_AddMarkets.UseVisualStyleBackColor = true;
			this.button_AddMarkets.Click += new global::System.EventHandler(this.button_AddMarkets_Click);
			this.button_TradeNextVillage.Location = new global::System.Drawing.Point(149, 3);
			this.button_TradeNextVillage.Name = "button_TradeNextVillage";
			this.button_TradeNextVillage.Size = new global::System.Drawing.Size(30, 23);
			this.button_TradeNextVillage.TabIndex = 90;
			this.button_TradeNextVillage.Text = "->";
			this.toolTip1.SetToolTip(this.button_TradeNextVillage, "Next village settings (CTRL+Right)");
			this.button_TradeNextVillage.UseVisualStyleBackColor = true;
			this.button_TradeNextVillage.Click += new global::System.EventHandler(this.button_TradeNextVillage_Click);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.numericUpDown_MarketsRadius;
			int[] array = new int[4];
			array[0] = 5;
			numericUpDown.Increment = new decimal(array);
			this.numericUpDown_MarketsRadius.Location = new global::System.Drawing.Point(506, 4);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.numericUpDown_MarketsRadius;
			int[] array2 = new int[4];
			array2[0] = 300;
			numericUpDown2.Maximum = new decimal(array2);
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.numericUpDown_MarketsRadius;
			int[] array3 = new int[4];
			array3[0] = 5;
			numericUpDown3.Minimum = new decimal(array3);
			this.numericUpDown_MarketsRadius.Name = "numericUpDown_MarketsRadius";
			this.numericUpDown_MarketsRadius.Size = new global::System.Drawing.Size(40, 20);
			this.numericUpDown_MarketsRadius.TabIndex = 84;
			global::System.Windows.Forms.NumericUpDown numericUpDown4 = this.numericUpDown_MarketsRadius;
			int[] array4 = new int[4];
			array4[0] = 50;
			numericUpDown4.Value = new decimal(array4);
			this.comboBox_TradeVillages.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_TradeVillages.FormattingEnabled = true;
			this.comboBox_TradeVillages.Location = new global::System.Drawing.Point(183, 4);
			this.comboBox_TradeVillages.Name = "comboBox_TradeVillages";
			this.comboBox_TradeVillages.Size = new global::System.Drawing.Size(165, 21);
			this.comboBox_TradeVillages.TabIndex = 89;
			this.toolTip1.SetToolTip(this.comboBox_TradeVillages, "Select a village to specify it's trade settings");
			this.comboBox_TradeVillages.SelectedIndexChanged += new global::System.EventHandler(this.comboBox_TradeVillages_SelectedIndexChanged);
			this.tabPage_TradeBetweenVillages.Controls.Add(this.button_TradeRoutesCopy);
			this.tabPage_TradeBetweenVillages.Controls.Add(this.button_TradeRoutesDelete);
			this.tabPage_TradeBetweenVillages.Controls.Add(this.button_TradeRoutesEdit);
			this.tabPage_TradeBetweenVillages.Controls.Add(this.button_TradeRoutesNew);
			this.tabPage_TradeBetweenVillages.Controls.Add(this.dataGridView_TradeRoutes);
			this.tabPage_TradeBetweenVillages.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage_TradeBetweenVillages.Name = "tabPage_TradeBetweenVillages";
			this.tabPage_TradeBetweenVillages.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage_TradeBetweenVillages.Size = new global::System.Drawing.Size(542, 583);
			this.tabPage_TradeBetweenVillages.TabIndex = 1;
			this.tabPage_TradeBetweenVillages.Text = "Trade between Villages";
			this.tabPage_TradeBetweenVillages.UseVisualStyleBackColor = true;
			this.button_TradeRoutesCopy.Location = new global::System.Drawing.Point(351, 6);
			this.button_TradeRoutesCopy.Name = "button_TradeRoutesCopy";
			this.button_TradeRoutesCopy.Size = new global::System.Drawing.Size(110, 23);
			this.button_TradeRoutesCopy.TabIndex = 4;
			this.button_TradeRoutesCopy.Text = "Copy";
			this.button_TradeRoutesCopy.UseVisualStyleBackColor = true;
			this.button_TradeRoutesCopy.Click += new global::System.EventHandler(this.button_TradeRoutesCopy_Click);
			this.button_TradeRoutesDelete.Location = new global::System.Drawing.Point(235, 6);
			this.button_TradeRoutesDelete.Name = "button_TradeRoutesDelete";
			this.button_TradeRoutesDelete.Size = new global::System.Drawing.Size(110, 23);
			this.button_TradeRoutesDelete.TabIndex = 3;
			this.button_TradeRoutesDelete.Text = "Delete";
			this.button_TradeRoutesDelete.UseVisualStyleBackColor = true;
			this.button_TradeRoutesDelete.Click += new global::System.EventHandler(this.button_TradeRoutesDelete_Click);
			this.button_TradeRoutesEdit.Location = new global::System.Drawing.Point(119, 6);
			this.button_TradeRoutesEdit.Name = "button_TradeRoutesEdit";
			this.button_TradeRoutesEdit.Size = new global::System.Drawing.Size(110, 23);
			this.button_TradeRoutesEdit.TabIndex = 2;
			this.button_TradeRoutesEdit.Text = "Edit";
			this.button_TradeRoutesEdit.UseVisualStyleBackColor = true;
			this.button_TradeRoutesEdit.Click += new global::System.EventHandler(this.button_TradeRoutesEdit_Click);
			this.button_TradeRoutesNew.Location = new global::System.Drawing.Point(3, 6);
			this.button_TradeRoutesNew.Name = "button_TradeRoutesNew";
			this.button_TradeRoutesNew.Size = new global::System.Drawing.Size(110, 23);
			this.button_TradeRoutesNew.TabIndex = 1;
			this.button_TradeRoutesNew.Text = "New";
			this.button_TradeRoutesNew.UseVisualStyleBackColor = true;
			this.button_TradeRoutesNew.Click += new global::System.EventHandler(this.button_TradeRoutesNew_Click);
			this.dataGridView_TradeRoutes.AllowUserToAddRows = false;
			this.dataGridView_TradeRoutes.AllowUserToDeleteRows = false;
			this.dataGridView_TradeRoutes.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.dataGridView_TradeRoutes.AutoSizeColumnsMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView_TradeRoutes.AutoSizeRowsMode = global::System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridView_TradeRoutes.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_TradeRoutes.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.RouteName,
				this.RouteEnabled,
				this.RouteFrom,
				this.RouteTo,
				this.RouteResourceType,
				this.RouteKeepMinimum,
				this.RouteMaxMerchantsPerTransaction,
				this.RouteSendMaximum,
				this.RouteIsDistanceLimited,
				this.RouteDistanceLimit
			});
			this.dataGridView_TradeRoutes.ContextMenuStrip = this.contextMenu_TradeRoutes;
			this.dataGridView_TradeRoutes.Location = new global::System.Drawing.Point(3, 30);
			this.dataGridView_TradeRoutes.Name = "dataGridView_TradeRoutes";
			this.dataGridView_TradeRoutes.RowHeadersVisible = false;
			this.dataGridView_TradeRoutes.SelectionMode = global::System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView_TradeRoutes.Size = new global::System.Drawing.Size(536, 550);
			this.dataGridView_TradeRoutes.TabIndex = 0;
			this.dataGridView_TradeRoutes.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.dataGridView_TradeRoutes_MouseUp);
			this.RouteName.HeaderText = "Name";
			this.RouteName.Name = "RouteName";
			this.RouteName.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.RouteEnabled.HeaderText = "Enabled";
			this.RouteEnabled.Name = "RouteEnabled";
			this.RouteFrom.HeaderText = "From";
			this.RouteFrom.Name = "RouteFrom";
			this.RouteFrom.ReadOnly = true;
			this.RouteFrom.Resizable = global::System.Windows.Forms.DataGridViewTriState.True;
			this.RouteFrom.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.RouteTo.HeaderText = "To";
			this.RouteTo.Name = "RouteTo";
			this.RouteTo.ReadOnly = true;
			this.RouteTo.Resizable = global::System.Windows.Forms.DataGridViewTriState.True;
			this.RouteTo.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.RouteResourceType.HeaderText = "Resource";
			this.RouteResourceType.Name = "RouteResourceType";
			this.RouteResourceType.ReadOnly = true;
			this.RouteResourceType.Resizable = global::System.Windows.Forms.DataGridViewTriState.True;
			this.RouteResourceType.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.RouteKeepMinimum.HeaderText = "Keep minimum";
			this.RouteKeepMinimum.Name = "RouteKeepMinimum";
			this.RouteKeepMinimum.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.RouteMaxMerchantsPerTransaction.HeaderText = "Max merchants per trade";
			this.RouteMaxMerchantsPerTransaction.Name = "RouteMaxMerchantsPerTransaction";
			this.RouteMaxMerchantsPerTransaction.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.RouteSendMaximum.HeaderText = "Send Maximum";
			this.RouteSendMaximum.Name = "RouteSendMaximum";
			this.RouteSendMaximum.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.RouteIsDistanceLimited.HeaderText = "Is Distance Limited? ";
			this.RouteIsDistanceLimited.Name = "RouteIsDistanceLimited";
			this.RouteDistanceLimit.HeaderText = "Distance Limit";
			this.RouteDistanceLimit.Name = "RouteDistanceLimit";
			this.RouteDistanceLimit.Resizable = global::System.Windows.Forms.DataGridViewTriState.True;
			this.RouteDistanceLimit.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.contextMenu_TradeRoutes.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.newRouteToolStripMenuItem,
				this.editTaskToolStripMenuItem,
				this.deleteToolStripMenuItem,
				this.copyToolStripMenuItem
			});
			this.contextMenu_TradeRoutes.Name = "contextMenu_TradeRoutes";
			this.contextMenu_TradeRoutes.Size = new global::System.Drawing.Size(108, 92);
			this.newRouteToolStripMenuItem.Name = "newRouteToolStripMenuItem";
			this.newRouteToolStripMenuItem.Size = new global::System.Drawing.Size(107, 22);
			this.newRouteToolStripMenuItem.Text = "New";
			this.newRouteToolStripMenuItem.Click += new global::System.EventHandler(this.newRouteToolStripMenuItem_Click);
			this.editTaskToolStripMenuItem.Name = "editTaskToolStripMenuItem";
			this.editTaskToolStripMenuItem.Size = new global::System.Drawing.Size(107, 22);
			this.editTaskToolStripMenuItem.Text = "Edit";
			this.editTaskToolStripMenuItem.Click += new global::System.EventHandler(this.editTaskToolStripMenuItem_Click);
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new global::System.Drawing.Size(107, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new global::System.EventHandler(this.deleteToolStripMenuItem_Click);
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.Size = new global::System.Drawing.Size(107, 22);
			this.copyToolStripMenuItem.Text = "Copy";
			this.copyToolStripMenuItem.Click += new global::System.EventHandler(this.copyToolStripMenuItem_Click);
			this.tabPage_TradeAdvanced.Controls.Add(this.numericUpDown_MerchantsExchangeLimit);
			this.tabPage_TradeAdvanced.Controls.Add(this.numericUpDown_MerchantsTradeLimit);
			this.tabPage_TradeAdvanced.Controls.Add(this.label_MerchantsExchangeLimit);
			this.tabPage_TradeAdvanced.Controls.Add(this.label_MerchantsTradeLimit);
			this.tabPage_TradeAdvanced.Controls.Add(this.checkBox_showPopupOnTradeExpiry);
			this.tabPage_TradeAdvanced.Controls.Add(this.checkBox_stopTradeOnCardExpiry);
			this.tabPage_TradeAdvanced.Controls.Add(this.numericUpDown_AutoHireMerchantsLimit);
			this.tabPage_TradeAdvanced.Controls.Add(this.checkBox_AutoHireMerchants);
			this.tabPage_TradeAdvanced.Controls.Add(this.checkBox_TradeIgnoreCurrentTransactions);
			this.tabPage_TradeAdvanced.Controls.Add(this.numericUpDown_PacketsPerTrade);
			this.tabPage_TradeAdvanced.Controls.Add(this.label4);
			this.tabPage_TradeAdvanced.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage_TradeAdvanced.Name = "tabPage_TradeAdvanced";
			this.tabPage_TradeAdvanced.Size = new global::System.Drawing.Size(542, 583);
			this.tabPage_TradeAdvanced.TabIndex = 2;
			this.tabPage_TradeAdvanced.Text = "Advanced Settings";
			this.tabPage_TradeAdvanced.UseVisualStyleBackColor = true;
			this.numericUpDown_MerchantsExchangeLimit.Location = new global::System.Drawing.Point(178, 169);
			global::System.Windows.Forms.NumericUpDown numericUpDown5 = this.numericUpDown_MerchantsExchangeLimit;
			int[] array5 = new int[4];
			array5[0] = 50;
			numericUpDown5.Maximum = new decimal(array5);
			this.numericUpDown_MerchantsExchangeLimit.Name = "numericUpDown_MerchantsExchangeLimit";
			this.numericUpDown_MerchantsExchangeLimit.Size = new global::System.Drawing.Size(58, 20);
			this.numericUpDown_MerchantsExchangeLimit.TabIndex = 100;
			global::System.Windows.Forms.NumericUpDown numericUpDown6 = this.numericUpDown_MerchantsExchangeLimit;
			int[] array6 = new int[4];
			array6[0] = 50;
			numericUpDown6.Value = new decimal(array6);
			this.numericUpDown_MerchantsExchangeLimit.ValueChanged += new global::System.EventHandler(this.numericUpDown_MerchantsExchangeLimit_ValueChanged);
			this.numericUpDown_MerchantsTradeLimit.Location = new global::System.Drawing.Point(178, 143);
			global::System.Windows.Forms.NumericUpDown numericUpDown7 = this.numericUpDown_MerchantsTradeLimit;
			int[] array7 = new int[4];
			array7[0] = 50;
			numericUpDown7.Maximum = new decimal(array7);
			this.numericUpDown_MerchantsTradeLimit.Name = "numericUpDown_MerchantsTradeLimit";
			this.numericUpDown_MerchantsTradeLimit.Size = new global::System.Drawing.Size(58, 20);
			this.numericUpDown_MerchantsTradeLimit.TabIndex = 99;
			global::System.Windows.Forms.NumericUpDown numericUpDown8 = this.numericUpDown_MerchantsTradeLimit;
			int[] array8 = new int[4];
			array8[0] = 50;
			numericUpDown8.Value = new decimal(array8);
			this.numericUpDown_MerchantsTradeLimit.ValueChanged += new global::System.EventHandler(this.numericUpDown_MerchantsTradeLimit_ValueChanged);
			this.label_MerchantsExchangeLimit.AutoSize = true;
			this.label_MerchantsExchangeLimit.Location = new global::System.Drawing.Point(6, 171);
			this.label_MerchantsExchangeLimit.Name = "label_MerchantsExchangeLimit";
			this.label_MerchantsExchangeLimit.Size = new global::System.Drawing.Size(132, 13);
			this.label_MerchantsExchangeLimit.TabIndex = 98;
			this.label_MerchantsExchangeLimit.Text = "Merchants Exchange Limit";
			this.toolTip1.SetToolTip(this.label_MerchantsExchangeLimit, "Maximum merchants for villages exchange");
			this.label_MerchantsTradeLimit.AutoSize = true;
			this.label_MerchantsTradeLimit.Location = new global::System.Drawing.Point(6, 150);
			this.label_MerchantsTradeLimit.Name = "label_MerchantsTradeLimit";
			this.label_MerchantsTradeLimit.Size = new global::System.Drawing.Size(112, 13);
			this.label_MerchantsTradeLimit.TabIndex = 97;
			this.label_MerchantsTradeLimit.Text = "Merchants Trade Limit";
			this.toolTip1.SetToolTip(this.label_MerchantsTradeLimit, "Maximum merchants for Markets trading");
			this.checkBox_showPopupOnTradeExpiry.AutoSize = true;
			this.checkBox_showPopupOnTradeExpiry.Checked = true;
			this.checkBox_showPopupOnTradeExpiry.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.checkBox_showPopupOnTradeExpiry.Location = new global::System.Drawing.Point(9, 130);
			this.checkBox_showPopupOnTradeExpiry.Name = "checkBox_showPopupOnTradeExpiry";
			this.checkBox_showPopupOnTradeExpiry.Size = new global::System.Drawing.Size(165, 17);
			this.checkBox_showPopupOnTradeExpiry.TabIndex = 96;
			this.checkBox_showPopupOnTradeExpiry.Text = "Show Popup On Cards Expiry";
			this.checkBox_showPopupOnTradeExpiry.UseVisualStyleBackColor = true;
			this.checkBox_showPopupOnTradeExpiry.CheckedChanged += new global::System.EventHandler(this.CheckBox_showPopupOnTradeExpiry_CheckedChanged);
			this.checkBox_stopTradeOnCardExpiry.AutoSize = true;
			this.checkBox_stopTradeOnCardExpiry.Location = new global::System.Drawing.Point(9, 107);
			this.checkBox_stopTradeOnCardExpiry.Name = "checkBox_stopTradeOnCardExpiry";
			this.checkBox_stopTradeOnCardExpiry.Size = new global::System.Drawing.Size(157, 17);
			this.checkBox_stopTradeOnCardExpiry.TabIndex = 95;
			this.checkBox_stopTradeOnCardExpiry.Text = "Stop Trade On Cards Expiry";
			this.toolTip1.SetToolTip(this.checkBox_stopTradeOnCardExpiry, "Run speed/capacity card and then turn this on");
			this.checkBox_stopTradeOnCardExpiry.UseVisualStyleBackColor = true;
			this.checkBox_stopTradeOnCardExpiry.CheckedChanged += new global::System.EventHandler(this.checkBox_stopTradeOnCardExpiry_CheckedChanged);
			global::System.Windows.Forms.NumericUpDown numericUpDown9 = this.numericUpDown_AutoHireMerchantsLimit;
			int[] array9 = new int[4];
			array9[0] = 5;
			numericUpDown9.Increment = new decimal(array9);
			this.numericUpDown_AutoHireMerchantsLimit.Location = new global::System.Drawing.Point(178, 62);
			global::System.Windows.Forms.NumericUpDown numericUpDown10 = this.numericUpDown_AutoHireMerchantsLimit;
			int[] array10 = new int[4];
			array10[0] = 50;
			numericUpDown10.Maximum = new decimal(array10);
			global::System.Windows.Forms.NumericUpDown numericUpDown11 = this.numericUpDown_AutoHireMerchantsLimit;
			int[] array11 = new int[4];
			array11[0] = 1;
			numericUpDown11.Minimum = new decimal(array11);
			this.numericUpDown_AutoHireMerchantsLimit.Name = "numericUpDown_AutoHireMerchantsLimit";
			this.numericUpDown_AutoHireMerchantsLimit.Size = new global::System.Drawing.Size(58, 20);
			this.numericUpDown_AutoHireMerchantsLimit.TabIndex = 94;
			global::System.Windows.Forms.NumericUpDown numericUpDown12 = this.numericUpDown_AutoHireMerchantsLimit;
			int[] array12 = new int[4];
			array12[0] = 50;
			numericUpDown12.Value = new decimal(array12);
			this.numericUpDown_AutoHireMerchantsLimit.ValueChanged += new global::System.EventHandler(this.numericUpDown_AutoHireMerchantsLimit_ValueChanged);
			this.checkBox_AutoHireMerchants.AutoSize = true;
			this.checkBox_AutoHireMerchants.Location = new global::System.Drawing.Point(9, 63);
			this.checkBox_AutoHireMerchants.Name = "checkBox_AutoHireMerchants";
			this.checkBox_AutoHireMerchants.RightToLeft = global::System.Windows.Forms.RightToLeft.Yes;
			this.checkBox_AutoHireMerchants.Size = new global::System.Drawing.Size(117, 17);
			this.checkBox_AutoHireMerchants.TabIndex = 93;
			this.checkBox_AutoHireMerchants.Text = "Autohire merchants";
			this.checkBox_AutoHireMerchants.UseVisualStyleBackColor = true;
			this.checkBox_AutoHireMerchants.CheckedChanged += new global::System.EventHandler(this.checkBox_AutoHireMerchants_CheckedChanged);
			this.checkBox_TradeIgnoreCurrentTransactions.AutoSize = true;
			this.checkBox_TradeIgnoreCurrentTransactions.Location = new global::System.Drawing.Point(9, 86);
			this.checkBox_TradeIgnoreCurrentTransactions.Name = "checkBox_TradeIgnoreCurrentTransactions";
			this.checkBox_TradeIgnoreCurrentTransactions.Size = new global::System.Drawing.Size(155, 17);
			this.checkBox_TradeIgnoreCurrentTransactions.TabIndex = 92;
			this.checkBox_TradeIgnoreCurrentTransactions.Text = "Ignore current transactions ";
			this.checkBox_TradeIgnoreCurrentTransactions.UseVisualStyleBackColor = true;
			this.checkBox_TradeIgnoreCurrentTransactions.CheckedChanged += new global::System.EventHandler(this.checkBox_TradeIgnoreCurrentTransactions_CheckedChanged);
			this.numericUpDown_PacketsPerTrade.Location = new global::System.Drawing.Point(178, 36);
			global::System.Windows.Forms.NumericUpDown numericUpDown13 = this.numericUpDown_PacketsPerTrade;
			int[] array13 = new int[4];
			array13[0] = 50;
			numericUpDown13.Maximum = new decimal(array13);
			global::System.Windows.Forms.NumericUpDown numericUpDown14 = this.numericUpDown_PacketsPerTrade;
			int[] array14 = new int[4];
			array14[0] = 1;
			numericUpDown14.Minimum = new decimal(array14);
			this.numericUpDown_PacketsPerTrade.Name = "numericUpDown_PacketsPerTrade";
			this.numericUpDown_PacketsPerTrade.Size = new global::System.Drawing.Size(58, 20);
			this.numericUpDown_PacketsPerTrade.TabIndex = 87;
			this.toolTip1.SetToolTip(this.numericUpDown_PacketsPerTrade, "How much free merchants a village must have to send  a trade");
			global::System.Windows.Forms.NumericUpDown numericUpDown15 = this.numericUpDown_PacketsPerTrade;
			int[] array15 = new int[4];
			array15[0] = 1;
			numericUpDown15.Value = new decimal(array15);
			this.numericUpDown_PacketsPerTrade.ValueChanged += new global::System.EventHandler(this.numericUpDown_PacketsPerTrade_ValueChanged);
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(6, 38);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(148, 13);
			this.label4.TabIndex = 86;
			this.label4.Text = "Minimum merchants per trade:";
			this.toolTip1.SetToolTip(this.label4, "Trade only if the village has the specified amount of merchants available");
			this.tabPage_TradeLogs.Controls.Add(this.richTextBoxTrade);
			this.tabPage_TradeLogs.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage_TradeLogs.Name = "tabPage_TradeLogs";
			this.tabPage_TradeLogs.Size = new global::System.Drawing.Size(542, 583);
			this.tabPage_TradeLogs.TabIndex = 3;
			this.tabPage_TradeLogs.Text = "Logs";
			this.tabPage_TradeLogs.UseVisualStyleBackColor = true;
			this.richTextBoxTrade.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.richTextBoxTrade.Location = new global::System.Drawing.Point(0, 0);
			this.richTextBoxTrade.Name = "richTextBoxTrade";
			this.richTextBoxTrade.ReadOnly = true;
			this.richTextBoxTrade.Size = new global::System.Drawing.Size(542, 583);
			this.richTextBoxTrade.TabIndex = 69;
			this.richTextBoxTrade.Text = "";
			this.toolTip1.SetToolTip(this.richTextBoxTrade, "A journal of Trade module's actions");
			this.button_TradeHelp.Location = new global::System.Drawing.Point(90, 3);
			this.button_TradeHelp.Name = "button_TradeHelp";
			this.button_TradeHelp.Size = new global::System.Drawing.Size(110, 23);
			this.button_TradeHelp.TabIndex = 93;
			this.button_TradeHelp.Text = "Help";
			this.toolTip1.SetToolTip(this.button_TradeHelp, "Opens a playlist with Trade module related videos");
			this.button_TradeHelp.UseVisualStyleBackColor = true;
			this.button_TradeHelp.Click += new global::System.EventHandler(this.button_TradeHelp_Click);
			this.checkBox_Trade.AutoSize = true;
			this.checkBox_Trade.Location = new global::System.Drawing.Point(8, 6);
			this.checkBox_Trade.Name = "checkBox_Trade";
			this.checkBox_Trade.Size = new global::System.Drawing.Size(54, 17);
			this.checkBox_Trade.TabIndex = 76;
			this.checkBox_Trade.Text = "Trade";
			this.toolTip1.SetToolTip(this.checkBox_Trade, "Turns on/off Trade module");
			this.checkBox_Trade.UseVisualStyleBackColor = true;
			this.checkBox_Trade.CheckedChanged += new global::System.EventHandler(this.checkBox_Trade_CheckedChanged);
			this.button4.Location = new global::System.Drawing.Point(203, 3);
			this.button4.Name = "button4";
			this.button4.Size = new global::System.Drawing.Size(110, 23);
			this.button4.TabIndex = 67;
			this.button4.Text = "Save";
			this.toolTip1.SetToolTip(this.button4, "Save your trading Settings");
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new global::System.EventHandler(this.button_TradeSave_Click);
			this.button5.Location = new global::System.Drawing.Point(316, 3);
			this.button5.Name = "button5";
			this.button5.Size = new global::System.Drawing.Size(110, 23);
			this.button5.TabIndex = 66;
			this.button5.Text = "Load";
			this.toolTip1.SetToolTip(this.button5, "Load your trading settings");
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new global::System.EventHandler(this.button_TradeLoad_Click);
			this.tabPage_Research.Controls.Add(this.button_ResearchHelp);
			this.tabPage_Research.Controls.Add(this.checkBox_Research);
			this.tabPage_Research.Controls.Add(this.comboBox_RankUpMode);
			this.tabPage_Research.Controls.Add(this.button_LoadResearches);
			this.tabPage_Research.Controls.Add(this.button_SaveResearches);
			this.tabPage_Research.Controls.Add(this.richTextBoxResearch);
			this.tabPage_Research.Controls.Add(this.label5);
			this.tabPage_Research.Controls.Add(this.textBox_CurrentResearch);
			this.tabPage_Research.Controls.Add(this.label3);
			this.tabPage_Research.Controls.Add(this.listBox_Queue);
			this.tabPage_Research.Controls.Add(this.listBox_ResearchList);
			this.tabPage_Research.Location = new global::System.Drawing.Point(4, 40);
			this.tabPage_Research.Name = "tabPage_Research";
			this.tabPage_Research.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage_Research.Size = new global::System.Drawing.Size(556, 626);
			this.tabPage_Research.TabIndex = 2;
			this.tabPage_Research.Text = "Research";
			this.tabPage_Research.UseVisualStyleBackColor = true;
			this.button_ResearchHelp.Location = new global::System.Drawing.Point(345, 169);
			this.button_ResearchHelp.Name = "button_ResearchHelp";
			this.button_ResearchHelp.Size = new global::System.Drawing.Size(144, 23);
			this.button_ResearchHelp.TabIndex = 29;
			this.button_ResearchHelp.Text = "Help";
			this.button_ResearchHelp.UseVisualStyleBackColor = true;
			this.button_ResearchHelp.Click += new global::System.EventHandler(this.button_ResearchHelp_Click);
			this.checkBox_Research.AutoSize = true;
			this.checkBox_Research.BackColor = global::System.Drawing.Color.Transparent;
			this.checkBox_Research.Location = new global::System.Drawing.Point(171, 7);
			this.checkBox_Research.Name = "checkBox_Research";
			this.checkBox_Research.Size = new global::System.Drawing.Size(121, 17);
			this.checkBox_Research.TabIndex = 28;
			this.checkBox_Research.Text = "Turn On the Module";
			this.checkBox_Research.UseVisualStyleBackColor = false;
			this.checkBox_Research.CheckedChanged += new global::System.EventHandler(this.checkBox_Research_CheckedChanged);
			this.comboBox_RankUpMode.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_RankUpMode.FormattingEnabled = true;
			this.comboBox_RankUpMode.Items.AddRange(new object[]
			{
				"No automatic ranking up",
				"Rank up once if no research points available",
				"Rank up always if there is enough honour "
			});
			this.comboBox_RankUpMode.Location = new global::System.Drawing.Point(171, 51);
			this.comboBox_RankUpMode.Name = "comboBox_RankUpMode";
			this.comboBox_RankUpMode.Size = new global::System.Drawing.Size(308, 21);
			this.comboBox_RankUpMode.TabIndex = 27;
			this.comboBox_RankUpMode.SelectedIndexChanged += new global::System.EventHandler(this.comboBox_RankUpMode_SelectedIndexChanged);
			this.button_LoadResearches.Location = new global::System.Drawing.Point(345, 140);
			this.button_LoadResearches.Name = "button_LoadResearches";
			this.button_LoadResearches.Size = new global::System.Drawing.Size(144, 23);
			this.button_LoadResearches.TabIndex = 26;
			this.button_LoadResearches.Text = "Load";
			this.button_LoadResearches.UseVisualStyleBackColor = true;
			this.button_LoadResearches.Click += new global::System.EventHandler(this.button_LoadResearches_Click);
			this.button_SaveResearches.Location = new global::System.Drawing.Point(345, 111);
			this.button_SaveResearches.Name = "button_SaveResearches";
			this.button_SaveResearches.Size = new global::System.Drawing.Size(144, 23);
			this.button_SaveResearches.TabIndex = 25;
			this.button_SaveResearches.Text = "Save";
			this.button_SaveResearches.UseVisualStyleBackColor = true;
			this.button_SaveResearches.Click += new global::System.EventHandler(this.button_SaveResearches_Click);
			this.richTextBoxResearch.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.richTextBoxResearch.Location = new global::System.Drawing.Point(3, 499);
			this.richTextBoxResearch.Name = "richTextBoxResearch";
			this.richTextBoxResearch.ReadOnly = true;
			this.richTextBoxResearch.Size = new global::System.Drawing.Size(550, 124);
			this.richTextBoxResearch.TabIndex = 24;
			this.richTextBoxResearch.Text = "";
			this.label5.Location = new global::System.Drawing.Point(170, 77);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(309, 31);
			this.label5.TabIndex = 22;
			this.label5.Text = "Double click on research to remove it from queue. Drag to reorder the queue";
			this.textBox_CurrentResearch.Location = new global::System.Drawing.Point(247, 25);
			this.textBox_CurrentResearch.Name = "textBox_CurrentResearch";
			this.textBox_CurrentResearch.ReadOnly = true;
			this.textBox_CurrentResearch.Size = new global::System.Drawing.Size(232, 20);
			this.textBox_CurrentResearch.TabIndex = 20;
			this.textBox_CurrentResearch.Text = "None";
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(170, 28);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(44, 13);
			this.label3.TabIndex = 19;
			this.label3.Text = "Current:";
			this.listBox_Queue.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.listBox_Queue.FormattingEnabled = true;
			this.listBox_Queue.Location = new global::System.Drawing.Point(171, 114);
			this.listBox_Queue.Name = "listBox_Queue";
			this.listBox_Queue.Size = new global::System.Drawing.Size(168, 394);
			this.listBox_Queue.TabIndex = 16;
			this.listBox_Queue.DoubleClick += new global::System.EventHandler(this.listBox_Queue_DoubleClick);
			this.listBox_ResearchList.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.listBox_ResearchList.FormattingEnabled = true;
			this.listBox_ResearchList.Location = new global::System.Drawing.Point(0, 0);
			this.listBox_ResearchList.Name = "listBox_ResearchList";
			this.listBox_ResearchList.Size = new global::System.Drawing.Size(167, 498);
			this.listBox_ResearchList.TabIndex = 15;
			this.listBox_ResearchList.SelectedIndexChanged += new global::System.EventHandler(this.listBox_ResearchList_SelectedIndexChanged);
			this.tabPage_Scouting.Controls.Add(this.checkBox_ScoutsWaitFreeSpace);
			this.tabPage_Scouting.Controls.Add(this.label_MinimumScouts);
			this.tabPage_Scouting.Controls.Add(this.numericUpDown_minScouts);
			this.tabPage_Scouting.Controls.Add(this.button_ScoutingCopy);
			this.tabPage_Scouting.Controls.Add(this.radioButton_ScoutsPriorityByDistance);
			this.tabPage_Scouting.Controls.Add(this.radioButton_ScoutsPriorityByTypeAndDistance);
			this.tabPage_Scouting.Controls.Add(this.checkBox_showPopupOnScoutsExpiry);
			this.tabPage_Scouting.Controls.Add(this.checkBox_StopScoutsOnCardExpiry);
			this.tabPage_Scouting.Controls.Add(this.checkBox_ScoutingAllVillages);
			this.tabPage_Scouting.Controls.Add(this.button_ScoutingHelp);
			this.tabPage_Scouting.Controls.Add(this.button_ScoutingPreviousVillage);
			this.tabPage_Scouting.Controls.Add(this.button_ScoutingNextVillage);
			this.tabPage_Scouting.Controls.Add(this.comboBox_ScoutingVillages);
			this.tabPage_Scouting.Controls.Add(this.groupBox_ScoutingVillage);
			this.tabPage_Scouting.Controls.Add(this.checkBox_sendOneScout);
			this.tabPage_Scouting.Controls.Add(this.numericUpDown_ScoutMaxTime);
			this.tabPage_Scouting.Controls.Add(this.checkBox_HireScouts);
			this.tabPage_Scouting.Controls.Add(this.checkBox_Scout);
			this.tabPage_Scouting.Controls.Add(this.button_LoadScoutingInfo);
			this.tabPage_Scouting.Controls.Add(this.button_SaveScoutingInfo);
			this.tabPage_Scouting.Controls.Add(this.richTextBoxScout);
			this.tabPage_Scouting.Controls.Add(this.label12);
			this.tabPage_Scouting.Controls.Add(this.label_scoutFrom);
			this.tabPage_Scouting.Controls.Add(this.listBox_scoutFrom);
			this.tabPage_Scouting.Location = new global::System.Drawing.Point(4, 40);
			this.tabPage_Scouting.Name = "tabPage_Scouting";
			this.tabPage_Scouting.Padding = new global::System.Windows.Forms.Padding(1);
			this.tabPage_Scouting.Size = new global::System.Drawing.Size(556, 624);
			this.tabPage_Scouting.TabIndex = 4;
			this.tabPage_Scouting.Text = "Scouting";
			this.tabPage_Scouting.UseVisualStyleBackColor = true;
			this.checkBox_ScoutsWaitFreeSpace.AutoSize = true;
			this.checkBox_ScoutsWaitFreeSpace.Checked = true;
			this.checkBox_ScoutsWaitFreeSpace.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.checkBox_ScoutsWaitFreeSpace.Location = new global::System.Drawing.Point(377, 177);
			this.checkBox_ScoutsWaitFreeSpace.Name = "checkBox_ScoutsWaitFreeSpace";
			this.checkBox_ScoutsWaitFreeSpace.Size = new global::System.Drawing.Size(116, 17);
			this.checkBox_ScoutsWaitFreeSpace.TabIndex = 107;
			this.checkBox_ScoutsWaitFreeSpace.Text = "Wait for free space";
			this.checkBox_ScoutsWaitFreeSpace.UseVisualStyleBackColor = true;
			this.checkBox_ScoutsWaitFreeSpace.CheckedChanged += new global::System.EventHandler(this.checkBox_ScoutsWaitFreeSpace_CheckedChanged);
			this.label_MinimumScouts.AutoSize = true;
			this.label_MinimumScouts.Location = new global::System.Drawing.Point(420, 153);
			this.label_MinimumScouts.Name = "label_MinimumScouts";
			this.label_MinimumScouts.Size = new global::System.Drawing.Size(120, 13);
			this.label_MinimumScouts.TabIndex = 106;
			this.label_MinimumScouts.Text = "Minimum scouts to send";
			this.numericUpDown_minScouts.Location = new global::System.Drawing.Point(377, 151);
			global::System.Windows.Forms.NumericUpDown numericUpDown16 = this.numericUpDown_minScouts;
			int[] array16 = new int[4];
			array16[0] = 8;
			numericUpDown16.Maximum = new decimal(array16);
			global::System.Windows.Forms.NumericUpDown numericUpDown17 = this.numericUpDown_minScouts;
			int[] array17 = new int[4];
			array17[0] = 1;
			numericUpDown17.Minimum = new decimal(array17);
			this.numericUpDown_minScouts.Name = "numericUpDown_minScouts";
			this.numericUpDown_minScouts.Size = new global::System.Drawing.Size(36, 20);
			this.numericUpDown_minScouts.TabIndex = 105;
			global::System.Windows.Forms.NumericUpDown numericUpDown18 = this.numericUpDown_minScouts;
			int[] array18 = new int[4];
			array18[0] = 2;
			numericUpDown18.Value = new decimal(array18);
			this.numericUpDown_minScouts.ValueChanged += new global::System.EventHandler(this.numericUpDown_minScouts_ValueChanged);
			this.button_ScoutingCopy.Location = new global::System.Drawing.Point(380, 388);
			this.button_ScoutingCopy.Name = "button_ScoutingCopy";
			this.button_ScoutingCopy.Size = new global::System.Drawing.Size(121, 23);
			this.button_ScoutingCopy.TabIndex = 104;
			this.button_ScoutingCopy.Text = "Copy Settings";
			this.toolTip1.SetToolTip(this.button_ScoutingCopy, "CTRL+Shift+C");
			this.button_ScoutingCopy.UseVisualStyleBackColor = true;
			this.button_ScoutingCopy.Click += new global::System.EventHandler(this.button_CopySettings_Click);
			this.radioButton_ScoutsPriorityByDistance.AutoSize = true;
			this.radioButton_ScoutsPriorityByDistance.Location = new global::System.Drawing.Point(377, 278);
			this.radioButton_ScoutsPriorityByDistance.Name = "radioButton_ScoutsPriorityByDistance";
			this.radioButton_ScoutsPriorityByDistance.Size = new global::System.Drawing.Size(113, 17);
			this.radioButton_ScoutsPriorityByDistance.TabIndex = 103;
			this.radioButton_ScoutsPriorityByDistance.Text = "Priority by distance";
			this.radioButton_ScoutsPriorityByDistance.UseVisualStyleBackColor = true;
			this.radioButton_ScoutsPriorityByDistance.CheckedChanged += new global::System.EventHandler(this.radioButton_ScoutsPriorityBy_CheckedChanged);
			this.radioButton_ScoutsPriorityByTypeAndDistance.AutoSize = true;
			this.radioButton_ScoutsPriorityByTypeAndDistance.Checked = true;
			this.radioButton_ScoutsPriorityByTypeAndDistance.Location = new global::System.Drawing.Point(377, 255);
			this.radioButton_ScoutsPriorityByTypeAndDistance.Name = "radioButton_ScoutsPriorityByTypeAndDistance";
			this.radioButton_ScoutsPriorityByTypeAndDistance.Size = new global::System.Drawing.Size(157, 17);
			this.radioButton_ScoutsPriorityByTypeAndDistance.TabIndex = 102;
			this.radioButton_ScoutsPriorityByTypeAndDistance.TabStop = true;
			this.radioButton_ScoutsPriorityByTypeAndDistance.Text = "Priority by type and distance";
			this.radioButton_ScoutsPriorityByTypeAndDistance.UseVisualStyleBackColor = true;
			this.radioButton_ScoutsPriorityByTypeAndDistance.CheckedChanged += new global::System.EventHandler(this.radioButton_ScoutsPriorityBy_CheckedChanged);
			this.checkBox_showPopupOnScoutsExpiry.AutoSize = true;
			this.checkBox_showPopupOnScoutsExpiry.Checked = true;
			this.checkBox_showPopupOnScoutsExpiry.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.checkBox_showPopupOnScoutsExpiry.Location = new global::System.Drawing.Point(377, 221);
			this.checkBox_showPopupOnScoutsExpiry.Name = "checkBox_showPopupOnScoutsExpiry";
			this.checkBox_showPopupOnScoutsExpiry.Size = new global::System.Drawing.Size(165, 17);
			this.checkBox_showPopupOnScoutsExpiry.TabIndex = 101;
			this.checkBox_showPopupOnScoutsExpiry.Text = "Show Popup On Cards Expiry";
			this.checkBox_showPopupOnScoutsExpiry.UseVisualStyleBackColor = true;
			this.checkBox_showPopupOnScoutsExpiry.CheckedChanged += new global::System.EventHandler(this.CheckBox_showPopupOnScoutsExpiry_CheckedChanged);
			this.checkBox_StopScoutsOnCardExpiry.AutoSize = true;
			this.checkBox_StopScoutsOnCardExpiry.Location = new global::System.Drawing.Point(377, 198);
			this.checkBox_StopScoutsOnCardExpiry.Name = "checkBox_StopScoutsOnCardExpiry";
			this.checkBox_StopScoutsOnCardExpiry.Size = new global::System.Drawing.Size(163, 17);
			this.checkBox_StopScoutsOnCardExpiry.TabIndex = 100;
			this.checkBox_StopScoutsOnCardExpiry.Text = "Stop foraging on cards expiry";
			this.checkBox_StopScoutsOnCardExpiry.UseVisualStyleBackColor = true;
			this.checkBox_StopScoutsOnCardExpiry.CheckedChanged += new global::System.EventHandler(this.checkBox_StopScoutsOnCardExpiry_CheckedChanged);
			this.checkBox_ScoutingAllVillages.AutoSize = true;
			this.checkBox_ScoutingAllVillages.Location = new global::System.Drawing.Point(144, 23);
			this.checkBox_ScoutingAllVillages.Name = "checkBox_ScoutingAllVillages";
			this.checkBox_ScoutingAllVillages.Size = new global::System.Drawing.Size(15, 14);
			this.checkBox_ScoutingAllVillages.TabIndex = 99;
			this.toolTip1.SetToolTip(this.checkBox_ScoutingAllVillages, "Selects all villages to scout or to stop scouting");
			this.checkBox_ScoutingAllVillages.UseVisualStyleBackColor = true;
			this.checkBox_ScoutingAllVillages.CheckedChanged += new global::System.EventHandler(this.checkBox_ScoutingAllVillages_CheckedChanged);
			this.button_ScoutingHelp.Location = new global::System.Drawing.Point(380, 359);
			this.button_ScoutingHelp.Name = "button_ScoutingHelp";
			this.button_ScoutingHelp.Size = new global::System.Drawing.Size(121, 23);
			this.button_ScoutingHelp.TabIndex = 98;
			this.button_ScoutingHelp.Text = "Help";
			this.toolTip1.SetToolTip(this.button_ScoutingHelp, "Opens a playlist with Scouting module related videos");
			this.button_ScoutingHelp.UseVisualStyleBackColor = true;
			this.button_ScoutingHelp.Click += new global::System.EventHandler(this.button_ScoutingHelp_Click);
			this.button_ScoutingPreviousVillage.Location = new global::System.Drawing.Point(283, 3);
			this.button_ScoutingPreviousVillage.Name = "button_ScoutingPreviousVillage";
			this.button_ScoutingPreviousVillage.Size = new global::System.Drawing.Size(30, 23);
			this.button_ScoutingPreviousVillage.TabIndex = 97;
			this.button_ScoutingPreviousVillage.Text = "<-";
			this.toolTip1.SetToolTip(this.button_ScoutingPreviousVillage, "Previous village settings (CTRL+Left)");
			this.button_ScoutingPreviousVillage.UseVisualStyleBackColor = true;
			this.button_ScoutingPreviousVillage.Click += new global::System.EventHandler(this.button_ScoutingPreviousVillage_Click);
			this.button_ScoutingNextVillage.Location = new global::System.Drawing.Point(315, 3);
			this.button_ScoutingNextVillage.Name = "button_ScoutingNextVillage";
			this.button_ScoutingNextVillage.Size = new global::System.Drawing.Size(30, 23);
			this.button_ScoutingNextVillage.TabIndex = 96;
			this.button_ScoutingNextVillage.Text = "->";
			this.toolTip1.SetToolTip(this.button_ScoutingNextVillage, "Next village settings (CTRL+Right)");
			this.button_ScoutingNextVillage.UseVisualStyleBackColor = true;
			this.button_ScoutingNextVillage.Click += new global::System.EventHandler(this.button_ScoutingNextVillage_Click);
			this.comboBox_ScoutingVillages.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_ScoutingVillages.FormattingEnabled = true;
			this.comboBox_ScoutingVillages.Location = new global::System.Drawing.Point(349, 4);
			this.comboBox_ScoutingVillages.Name = "comboBox_ScoutingVillages";
			this.comboBox_ScoutingVillages.Size = new global::System.Drawing.Size(199, 21);
			this.comboBox_ScoutingVillages.TabIndex = 95;
			this.toolTip1.SetToolTip(this.comboBox_ScoutingVillages, "Select a village to specify it's scouting settings");
			this.comboBox_ScoutingVillages.SelectedIndexChanged += new global::System.EventHandler(this.comboBox_ScoutingVillages_SelectedIndexChanged);
			this.groupBox_ScoutingVillage.BackColor = global::System.Drawing.Color.Aquamarine;
			this.groupBox_ScoutingVillage.Controls.Add(this.checkBox_ShouldVillageScout);
			this.groupBox_ScoutingVillage.Controls.Add(this.label18);
			this.groupBox_ScoutingVillage.Controls.Add(this.listBox_ScoutingTypes);
			this.groupBox_ScoutingVillage.Controls.Add(this.label1);
			this.groupBox_ScoutingVillage.Controls.Add(this.listBox_ScoutingTypes_Ignore);
			this.groupBox_ScoutingVillage.Location = new global::System.Drawing.Point(163, 32);
			this.groupBox_ScoutingVillage.Name = "groupBox_ScoutingVillage";
			this.groupBox_ScoutingVillage.Size = new global::System.Drawing.Size(209, 431);
			this.groupBox_ScoutingVillage.TabIndex = 94;
			this.groupBox_ScoutingVillage.TabStop = false;
			this.groupBox_ScoutingVillage.Text = "No selected village";
			this.checkBox_ShouldVillageScout.AutoSize = true;
			this.checkBox_ShouldVillageScout.Location = new global::System.Drawing.Point(6, 20);
			this.checkBox_ShouldVillageScout.Name = "checkBox_ShouldVillageScout";
			this.checkBox_ShouldVillageScout.Size = new global::System.Drawing.Size(146, 17);
			this.checkBox_ShouldVillageScout.TabIndex = 86;
			this.checkBox_ShouldVillageScout.Text = "Should this village scout?";
			this.checkBox_ShouldVillageScout.UseVisualStyleBackColor = true;
			this.checkBox_ShouldVillageScout.CheckedChanged += new global::System.EventHandler(this.checkBox_ShouldVillageScout_CheckedChanged);
			this.label18.Location = new global::System.Drawing.Point(6, 41);
			this.label18.Name = "label18";
			this.label18.Size = new global::System.Drawing.Size(96, 12);
			this.label18.TabIndex = 47;
			this.label18.Text = "To scout";
			this.label18.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.listBox_ScoutingTypes.FormattingEnabled = true;
			this.listBox_ScoutingTypes.Location = new global::System.Drawing.Point(6, 56);
			this.listBox_ScoutingTypes.Name = "listBox_ScoutingTypes";
			this.listBox_ScoutingTypes.Size = new global::System.Drawing.Size(96, 355);
			this.listBox_ScoutingTypes.TabIndex = 56;
			this.label1.Location = new global::System.Drawing.Point(107, 41);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(96, 13);
			this.label1.TabIndex = 84;
			this.label1.Text = "To ignore";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.listBox_ScoutingTypes_Ignore.FormattingEnabled = true;
			this.listBox_ScoutingTypes_Ignore.Location = new global::System.Drawing.Point(107, 56);
			this.listBox_ScoutingTypes_Ignore.Name = "listBox_ScoutingTypes_Ignore";
			this.listBox_ScoutingTypes_Ignore.Size = new global::System.Drawing.Size(96, 355);
			this.listBox_ScoutingTypes_Ignore.TabIndex = 85;
			this.checkBox_sendOneScout.AutoSize = true;
			this.checkBox_sendOneScout.Location = new global::System.Drawing.Point(377, 128);
			this.checkBox_sendOneScout.Name = "checkBox_sendOneScout";
			this.checkBox_sendOneScout.Size = new global::System.Drawing.Size(123, 17);
			this.checkBox_sendOneScout.TabIndex = 93;
			this.checkBox_sendOneScout.Text = "Send 1 scout at time";
			this.checkBox_sendOneScout.UseVisualStyleBackColor = true;
			this.checkBox_sendOneScout.CheckedChanged += new global::System.EventHandler(this.checkBox_sendOneScout_CheckedChanged);
			this.numericUpDown_ScoutMaxTime.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			global::System.Windows.Forms.NumericUpDown numericUpDown19 = this.numericUpDown_ScoutMaxTime;
			int[] array19 = new int[4];
			array19[0] = 60;
			numericUpDown19.Increment = new decimal(array19);
			this.numericUpDown_ScoutMaxTime.Location = new global::System.Drawing.Point(377, 32);
			global::System.Windows.Forms.NumericUpDown numericUpDown20 = this.numericUpDown_ScoutMaxTime;
			int[] array20 = new int[4];
			array20[0] = 10000;
			numericUpDown20.Maximum = new decimal(array20);
			global::System.Windows.Forms.NumericUpDown numericUpDown21 = this.numericUpDown_ScoutMaxTime;
			int[] array21 = new int[4];
			array21[0] = 5;
			numericUpDown21.Minimum = new decimal(array21);
			this.numericUpDown_ScoutMaxTime.Name = "numericUpDown_ScoutMaxTime";
			this.numericUpDown_ScoutMaxTime.Size = new global::System.Drawing.Size(50, 20);
			this.numericUpDown_ScoutMaxTime.TabIndex = 92;
			this.numericUpDown_ScoutMaxTime.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			global::System.Windows.Forms.NumericUpDown numericUpDown22 = this.numericUpDown_ScoutMaxTime;
			int[] array22 = new int[4];
			array22[0] = 1200;
			numericUpDown22.Value = new decimal(array22);
			this.numericUpDown_ScoutMaxTime.ValueChanged += new global::System.EventHandler(this.numericUpDown_ScoutMaxRadius_ValueChanged);
			this.checkBox_HireScouts.AutoSize = true;
			this.checkBox_HireScouts.Checked = true;
			this.checkBox_HireScouts.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.checkBox_HireScouts.Location = new global::System.Drawing.Point(377, 104);
			this.checkBox_HireScouts.Name = "checkBox_HireScouts";
			this.checkBox_HireScouts.Size = new global::System.Drawing.Size(142, 17);
			this.checkBox_HireScouts.TabIndex = 91;
			this.checkBox_HireScouts.Text = "Automatically hire scouts";
			this.checkBox_HireScouts.UseVisualStyleBackColor = true;
			this.checkBox_HireScouts.CheckedChanged += new global::System.EventHandler(this.checkBox_HireScouts_CheckedChanged);
			this.checkBox_Scout.AutoSize = true;
			this.checkBox_Scout.Location = new global::System.Drawing.Point(9, 4);
			this.checkBox_Scout.Name = "checkBox_Scout";
			this.checkBox_Scout.Size = new global::System.Drawing.Size(54, 17);
			this.checkBox_Scout.TabIndex = 90;
			this.checkBox_Scout.Text = "Scout";
			this.toolTip1.SetToolTip(this.checkBox_Scout, "Turns on/off Scouting module");
			this.checkBox_Scout.UseVisualStyleBackColor = true;
			this.checkBox_Scout.CheckedChanged += new global::System.EventHandler(this.checkBox_Scout_CheckedChanged);
			this.button_LoadScoutingInfo.Location = new global::System.Drawing.Point(380, 330);
			this.button_LoadScoutingInfo.Name = "button_LoadScoutingInfo";
			this.button_LoadScoutingInfo.Size = new global::System.Drawing.Size(121, 23);
			this.button_LoadScoutingInfo.TabIndex = 58;
			this.button_LoadScoutingInfo.Text = "Load";
			this.button_LoadScoutingInfo.UseVisualStyleBackColor = true;
			this.button_LoadScoutingInfo.Click += new global::System.EventHandler(this.Button_LoadScoutingInfo_Click);
			this.button_SaveScoutingInfo.Location = new global::System.Drawing.Point(380, 301);
			this.button_SaveScoutingInfo.Name = "button_SaveScoutingInfo";
			this.button_SaveScoutingInfo.Size = new global::System.Drawing.Size(121, 23);
			this.button_SaveScoutingInfo.TabIndex = 57;
			this.button_SaveScoutingInfo.Text = "Save";
			this.button_SaveScoutingInfo.UseVisualStyleBackColor = true;
			this.button_SaveScoutingInfo.Click += new global::System.EventHandler(this.button_SaveScoutingInfo_Click);
			this.richTextBoxScout.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.richTextBoxScout.Location = new global::System.Drawing.Point(163, 469);
			this.richTextBoxScout.Name = "richTextBoxScout";
			this.richTextBoxScout.ReadOnly = true;
			this.richTextBoxScout.Size = new global::System.Drawing.Size(392, 152);
			this.richTextBoxScout.TabIndex = 55;
			this.richTextBoxScout.Text = "";
			this.label12.Location = new global::System.Drawing.Point(435, 34);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(117, 37);
			this.label12.TabIndex = 42;
			this.label12.Text = "- Max time to stash (specify in seconds)";
			this.label_scoutFrom.AutoSize = true;
			this.label_scoutFrom.Location = new global::System.Drawing.Point(6, 23);
			this.label_scoutFrom.Name = "label_scoutFrom";
			this.label_scoutFrom.Size = new global::System.Drawing.Size(61, 13);
			this.label_scoutFrom.TabIndex = 40;
			this.label_scoutFrom.Text = "Scout from:";
			this.listBox_scoutFrom.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.listBox_scoutFrom.FormattingEnabled = true;
			this.listBox_scoutFrom.Location = new global::System.Drawing.Point(0, 40);
			this.listBox_scoutFrom.Name = "listBox_scoutFrom";
			this.listBox_scoutFrom.SelectionMode = global::System.Windows.Forms.SelectionMode.MultiSimple;
			this.listBox_scoutFrom.Size = new global::System.Drawing.Size(158, 576);
			this.listBox_scoutFrom.TabIndex = 39;
			this.listBox_scoutFrom.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.ListBox_scoutFrom_MouseDown);
			this.tabPage_Main.Controls.Add(this.label_LogsToKeep);
			this.tabPage_Main.Controls.Add(this.numericUpDown_LogsToKeep);
			this.tabPage_Main.Controls.Add(this.button_MainHelp);
			this.tabPage_Main.Controls.Add(this.checkBox_StayOnTop);
			this.tabPage_Main.Controls.Add(this.button_cacheLoad);
			this.tabPage_Main.Controls.Add(this.button_cacheSub);
			this.tabPage_Main.Controls.Add(this.groupBox_BotLifeCycle);
			this.tabPage_Main.Controls.Add(this.checkBox_CollectFreeCard);
			this.tabPage_Main.Controls.Add(this.textBox_UserContactEmail);
			this.tabPage_Main.Controls.Add(this.label_ContactEmail);
			this.tabPage_Main.Controls.Add(this.checkBox_WriteLogs);
			this.tabPage_Main.Controls.Add(this.button_CopySettings);
			this.tabPage_Main.Controls.Add(this.button_Calc);
			this.tabPage_Main.Controls.Add(this.label_subscriptions);
			this.tabPage_Main.Controls.Add(this.listBox_Subscriptions);
			this.tabPage_Main.Controls.Add(this.comboBox_Language);
			this.tabPage_Main.Controls.Add(this.button_OpenBotSettings);
			this.tabPage_Main.Controls.Add(this.label2);
			this.tabPage_Main.Controls.Add(this.label_ModuleDisable);
			this.tabPage_Main.Controls.Add(this.listBox_ModuleDisable);
			this.tabPage_Main.Controls.Add(this.button_ClearLogs);
			this.tabPage_Main.Controls.Add(this.richTextBoxMain);
			this.tabPage_Main.Location = new global::System.Drawing.Point(4, 40);
			this.tabPage_Main.Name = "tabPage_Main";
			this.tabPage_Main.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage_Main.Size = new global::System.Drawing.Size(556, 626);
			this.tabPage_Main.TabIndex = 0;
			this.tabPage_Main.Text = "Main";
			this.tabPage_Main.UseVisualStyleBackColor = true;
			this.label_LogsToKeep.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.label_LogsToKeep.Location = new global::System.Drawing.Point(481, 82);
			this.label_LogsToKeep.Name = "label_LogsToKeep";
			this.label_LogsToKeep.Size = new global::System.Drawing.Size(67, 43);
			this.label_LogsToKeep.TabIndex = 92;
			this.label_LogsToKeep.Text = "Max logs to keep (lines)";
			this.label_LogsToKeep.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.numericUpDown_LogsToKeep.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			global::System.Windows.Forms.NumericUpDown numericUpDown23 = this.numericUpDown_LogsToKeep;
			int[] array23 = new int[4];
			array23[0] = 100;
			numericUpDown23.Increment = new decimal(array23);
			this.numericUpDown_LogsToKeep.Location = new global::System.Drawing.Point(425, 88);
			global::System.Windows.Forms.NumericUpDown numericUpDown24 = this.numericUpDown_LogsToKeep;
			int[] array24 = new int[4];
			array24[0] = 30000;
			numericUpDown24.Maximum = new decimal(array24);
			global::System.Windows.Forms.NumericUpDown numericUpDown25 = this.numericUpDown_LogsToKeep;
			int[] array25 = new int[4];
			array25[0] = 100;
			numericUpDown25.Minimum = new decimal(array25);
			this.numericUpDown_LogsToKeep.Name = "numericUpDown_LogsToKeep";
			this.numericUpDown_LogsToKeep.Size = new global::System.Drawing.Size(50, 20);
			this.numericUpDown_LogsToKeep.TabIndex = 91;
			global::System.Windows.Forms.NumericUpDown numericUpDown26 = this.numericUpDown_LogsToKeep;
			int[] array26 = new int[4];
			array26[0] = 1000;
			numericUpDown26.Value = new decimal(array26);
			this.numericUpDown_LogsToKeep.ValueChanged += new global::System.EventHandler(this.numericUpDown_LogsToKeep_ValueChanged);
			this.button_MainHelp.Location = new global::System.Drawing.Point(136, 103);
			this.button_MainHelp.Name = "button_MainHelp";
			this.button_MainHelp.Size = new global::System.Drawing.Size(121, 23);
			this.button_MainHelp.TabIndex = 90;
			this.button_MainHelp.Text = "Help";
			this.button_MainHelp.UseVisualStyleBackColor = true;
			this.button_MainHelp.Click += new global::System.EventHandler(this.button_MainHelp_Click);
			this.checkBox_StayOnTop.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.checkBox_StayOnTop.AutoSize = true;
			this.checkBox_StayOnTop.Location = new global::System.Drawing.Point(281, 11);
			this.checkBox_StayOnTop.Name = "checkBox_StayOnTop";
			this.checkBox_StayOnTop.Size = new global::System.Drawing.Size(86, 17);
			this.checkBox_StayOnTop.TabIndex = 89;
			this.checkBox_StayOnTop.Text = "Stay On Top";
			this.checkBox_StayOnTop.UseVisualStyleBackColor = true;
			this.checkBox_StayOnTop.CheckedChanged += new global::System.EventHandler(this.checkBox_StayOnTop_CheckedChanged);
			this.button_cacheLoad.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.button_cacheLoad.Enabled = false;
			this.button_cacheLoad.Location = new global::System.Drawing.Point(423, 600);
			this.button_cacheLoad.Name = "button_cacheLoad";
			this.button_cacheLoad.Size = new global::System.Drawing.Size(125, 23);
			this.button_cacheLoad.TabIndex = 88;
			this.button_cacheLoad.Text = "Load";
			this.button_cacheLoad.UseVisualStyleBackColor = true;
			this.button_cacheLoad.Visible = false;
			this.button_cacheLoad.Click += new global::System.EventHandler(this.button_cacheLoad_Click);
			this.button_cacheSub.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.button_cacheSub.Enabled = false;
			this.button_cacheSub.Location = new global::System.Drawing.Point(263, 600);
			this.button_cacheSub.Name = "button_cacheSub";
			this.button_cacheSub.Size = new global::System.Drawing.Size(125, 23);
			this.button_cacheSub.TabIndex = 87;
			this.button_cacheSub.Text = "Save";
			this.button_cacheSub.UseVisualStyleBackColor = true;
			this.button_cacheSub.Visible = false;
			this.button_cacheSub.Click += new global::System.EventHandler(this.button_cacheSub_Click);
			this.groupBox_BotLifeCycle.Controls.Add(this.label_BotCycleStatusValue);
			this.groupBox_BotLifeCycle.Controls.Add(this.checkBox_BotCycleRandomPeriods);
			this.groupBox_BotLifeCycle.Controls.Add(this.label_BotCycleStatus);
			this.groupBox_BotLifeCycle.Controls.Add(this.numericUpDown_BotWorkPeriod);
			this.groupBox_BotLifeCycle.Controls.Add(this.label_BotSleepPeriod);
			this.groupBox_BotLifeCycle.Controls.Add(this.numericUpDown_BotSleepPeriod);
			this.groupBox_BotLifeCycle.Controls.Add(this.label_BotWorkPeriod);
			this.groupBox_BotLifeCycle.Location = new global::System.Drawing.Point(11, 6);
			this.groupBox_BotLifeCycle.Name = "groupBox_BotLifeCycle";
			this.groupBox_BotLifeCycle.Size = new global::System.Drawing.Size(200, 91);
			this.groupBox_BotLifeCycle.TabIndex = 86;
			this.groupBox_BotLifeCycle.TabStop = false;
			this.groupBox_BotLifeCycle.Text = "Bot Work Cycle";
			this.label_BotCycleStatusValue.AutoSize = true;
			this.label_BotCycleStatusValue.Location = new global::System.Drawing.Point(52, 14);
			this.label_BotCycleStatusValue.Name = "label_BotCycleStatusValue";
			this.label_BotCycleStatusValue.Size = new global::System.Drawing.Size(47, 13);
			this.label_BotCycleStatusValue.TabIndex = 88;
			this.label_BotCycleStatusValue.Text = "Working";
			this.checkBox_BotCycleRandomPeriods.AutoSize = true;
			this.checkBox_BotCycleRandomPeriods.Checked = true;
			this.checkBox_BotCycleRandomPeriods.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.checkBox_BotCycleRandomPeriods.Location = new global::System.Drawing.Point(8, 73);
			this.checkBox_BotCycleRandomPeriods.Name = "checkBox_BotCycleRandomPeriods";
			this.checkBox_BotCycleRandomPeriods.Size = new global::System.Drawing.Size(104, 17);
			this.checkBox_BotCycleRandomPeriods.TabIndex = 87;
			this.checkBox_BotCycleRandomPeriods.Text = "Random Periods";
			this.checkBox_BotCycleRandomPeriods.UseVisualStyleBackColor = true;
			this.checkBox_BotCycleRandomPeriods.CheckedChanged += new global::System.EventHandler(this.checkBox_BotCycleRandomPeriods_CheckedChanged);
			this.label_BotCycleStatus.AutoSize = true;
			this.label_BotCycleStatus.Location = new global::System.Drawing.Point(6, 14);
			this.label_BotCycleStatus.Name = "label_BotCycleStatus";
			this.label_BotCycleStatus.Size = new global::System.Drawing.Size(40, 13);
			this.label_BotCycleStatus.TabIndex = 86;
			this.label_BotCycleStatus.Text = "Status:";
			this.numericUpDown_BotWorkPeriod.Location = new global::System.Drawing.Point(125, 30);
			global::System.Windows.Forms.NumericUpDown numericUpDown27 = this.numericUpDown_BotWorkPeriod;
			int[] array27 = new int[4];
			array27[0] = 180;
			numericUpDown27.Maximum = new decimal(array27);
			global::System.Windows.Forms.NumericUpDown numericUpDown28 = this.numericUpDown_BotWorkPeriod;
			int[] array28 = new int[4];
			array28[0] = 1;
			numericUpDown28.Minimum = new decimal(array28);
			this.numericUpDown_BotWorkPeriod.Name = "numericUpDown_BotWorkPeriod";
			this.numericUpDown_BotWorkPeriod.Size = new global::System.Drawing.Size(44, 20);
			this.numericUpDown_BotWorkPeriod.TabIndex = 82;
			global::System.Windows.Forms.NumericUpDown numericUpDown29 = this.numericUpDown_BotWorkPeriod;
			int[] array29 = new int[4];
			array29[0] = 45;
			numericUpDown29.Value = new decimal(array29);
			this.numericUpDown_BotWorkPeriod.ValueChanged += new global::System.EventHandler(this.NumericUpDown_BotWorkPeriod_ValueChanged);
			this.label_BotSleepPeriod.AutoSize = true;
			this.label_BotSleepPeriod.Location = new global::System.Drawing.Point(6, 55);
			this.label_BotSleepPeriod.Name = "label_BotSleepPeriod";
			this.label_BotSleepPeriod.Size = new global::System.Drawing.Size(109, 13);
			this.label_BotSleepPeriod.TabIndex = 85;
			this.label_BotSleepPeriod.Text = "SleepPeriod (minutes)";
			this.numericUpDown_BotSleepPeriod.Location = new global::System.Drawing.Point(125, 53);
			global::System.Windows.Forms.NumericUpDown numericUpDown30 = this.numericUpDown_BotSleepPeriod;
			int[] array30 = new int[4];
			array30[0] = 1;
			numericUpDown30.Minimum = new decimal(array30);
			this.numericUpDown_BotSleepPeriod.Name = "numericUpDown_BotSleepPeriod";
			this.numericUpDown_BotSleepPeriod.Size = new global::System.Drawing.Size(44, 20);
			this.numericUpDown_BotSleepPeriod.TabIndex = 83;
			global::System.Windows.Forms.NumericUpDown numericUpDown31 = this.numericUpDown_BotSleepPeriod;
			int[] array31 = new int[4];
			array31[0] = 15;
			numericUpDown31.Value = new decimal(array31);
			this.numericUpDown_BotSleepPeriod.ValueChanged += new global::System.EventHandler(this.NumericUpDown_BotSleepPeriod_ValueChanged);
			this.label_BotWorkPeriod.AutoSize = true;
			this.label_BotWorkPeriod.Location = new global::System.Drawing.Point(6, 32);
			this.label_BotWorkPeriod.Name = "label_BotWorkPeriod";
			this.label_BotWorkPeriod.Size = new global::System.Drawing.Size(111, 13);
			this.label_BotWorkPeriod.TabIndex = 84;
			this.label_BotWorkPeriod.Text = "Work Period (minutes)";
			this.checkBox_CollectFreeCard.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.checkBox_CollectFreeCard.AutoSize = true;
			this.checkBox_CollectFreeCard.Checked = true;
			this.checkBox_CollectFreeCard.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.checkBox_CollectFreeCard.Location = new global::System.Drawing.Point(281, 35);
			this.checkBox_CollectFreeCard.Name = "checkBox_CollectFreeCard";
			this.checkBox_CollectFreeCard.Size = new global::System.Drawing.Size(107, 17);
			this.checkBox_CollectFreeCard.TabIndex = 81;
			this.checkBox_CollectFreeCard.Text = "Collect Free Card";
			this.checkBox_CollectFreeCard.UseVisualStyleBackColor = true;
			this.checkBox_CollectFreeCard.CheckedChanged += new global::System.EventHandler(this.CheckBox_CollectFreeCard_CheckedChanged);
			this.textBox_UserContactEmail.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.textBox_UserContactEmail.Location = new global::System.Drawing.Point(263, 467);
			this.textBox_UserContactEmail.Name = "textBox_UserContactEmail";
			this.textBox_UserContactEmail.Size = new global::System.Drawing.Size(285, 20);
			this.textBox_UserContactEmail.TabIndex = 79;
			this.label_ContactEmail.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.label_ContactEmail.AutoSize = true;
			this.label_ContactEmail.Location = new global::System.Drawing.Point(263, 451);
			this.label_ContactEmail.Name = "label_ContactEmail";
			this.label_ContactEmail.Size = new global::System.Drawing.Size(75, 13);
			this.label_ContactEmail.TabIndex = 78;
			this.label_ContactEmail.Text = "Contact Email:";
			this.checkBox_WriteLogs.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.checkBox_WriteLogs.Checked = true;
			this.checkBox_WriteLogs.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.checkBox_WriteLogs.Location = new global::System.Drawing.Point(425, 33);
			this.checkBox_WriteLogs.Name = "checkBox_WriteLogs";
			this.checkBox_WriteLogs.Size = new global::System.Drawing.Size(123, 21);
			this.checkBox_WriteLogs.TabIndex = 77;
			this.checkBox_WriteLogs.Text = "Write Logs";
			this.checkBox_WriteLogs.UseVisualStyleBackColor = true;
			this.checkBox_WriteLogs.CheckedChanged += new global::System.EventHandler(this.checkBox_WriteLogs_CheckedChanged);
			this.button_CopySettings.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.button_CopySettings.Location = new global::System.Drawing.Point(281, 56);
			this.button_CopySettings.Name = "button_CopySettings";
			this.button_CopySettings.Size = new global::System.Drawing.Size(140, 23);
			this.button_CopySettings.TabIndex = 76;
			this.button_CopySettings.Text = "Copy Settings";
			this.toolTip1.SetToolTip(this.button_CopySettings, "CTRL+Shift+C");
			this.button_CopySettings.UseVisualStyleBackColor = true;
			this.button_CopySettings.Click += new global::System.EventHandler(this.button_CopySettings_Click);
			this.button_Calc.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 204);
			this.button_Calc.Location = new global::System.Drawing.Point(9, 103);
			this.button_Calc.Name = "button_Calc";
			this.button_Calc.Size = new global::System.Drawing.Size(123, 23);
			this.button_Calc.TabIndex = 75;
			this.button_Calc.Text = "Calc";
			this.button_Calc.UseVisualStyleBackColor = true;
			this.button_Calc.Click += new global::System.EventHandler(this.button2_Click_2);
			this.label_subscriptions.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.label_subscriptions.AutoSize = true;
			this.label_subscriptions.Location = new global::System.Drawing.Point(263, 489);
			this.label_subscriptions.Name = "label_subscriptions";
			this.label_subscriptions.Size = new global::System.Drawing.Size(96, 13);
			this.label_subscriptions.TabIndex = 74;
			this.label_subscriptions.Text = "Your subscriptions:";
			this.listBox_Subscriptions.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.listBox_Subscriptions.FormattingEnabled = true;
			this.listBox_Subscriptions.Location = new global::System.Drawing.Point(263, 505);
			this.listBox_Subscriptions.Name = "listBox_Subscriptions";
			this.listBox_Subscriptions.Size = new global::System.Drawing.Size(285, 95);
			this.listBox_Subscriptions.TabIndex = 73;
			this.comboBox_Language.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.comboBox_Language.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_Language.FormattingEnabled = true;
			this.comboBox_Language.Location = new global::System.Drawing.Point(437, 6);
			this.comboBox_Language.Name = "comboBox_Language";
			this.comboBox_Language.Size = new global::System.Drawing.Size(111, 21);
			this.comboBox_Language.TabIndex = 72;
			this.comboBox_Language.SelectionChangeCommitted += new global::System.EventHandler(this.comboBox_Language_SelectionChangeCommitted);
			this.button_OpenBotSettings.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.button_OpenBotSettings.Location = new global::System.Drawing.Point(281, 85);
			this.button_OpenBotSettings.Name = "button_OpenBotSettings";
			this.button_OpenBotSettings.Size = new global::System.Drawing.Size(140, 23);
			this.button_OpenBotSettings.TabIndex = 72;
			this.button_OpenBotSettings.Text = "Open BotSettings";
			this.button_OpenBotSettings.UseVisualStyleBackColor = true;
			this.button_OpenBotSettings.Click += new global::System.EventHandler(this.button_OpenBotSettings_Click);
			this.label2.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(376, 9);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(55, 13);
			this.label2.TabIndex = 23;
			this.label2.Text = "Language";
			this.label_ModuleDisable.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.label_ModuleDisable.AutoSize = true;
			this.label_ModuleDisable.Location = new global::System.Drawing.Point(6, 439);
			this.label_ModuleDisable.Name = "label_ModuleDisable";
			this.label_ModuleDisable.Size = new global::System.Drawing.Size(280, 13);
			this.label_ModuleDisable.TabIndex = 68;
			this.label_ModuleDisable.Text = "Double click to disable the module to save RAM and CPU";
			this.label_ModuleDisable.Visible = false;
			this.listBox_ModuleDisable.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.listBox_ModuleDisable.FormattingEnabled = true;
			this.listBox_ModuleDisable.Location = new global::System.Drawing.Point(6, 463);
			this.listBox_ModuleDisable.Name = "listBox_ModuleDisable";
			this.listBox_ModuleDisable.Size = new global::System.Drawing.Size(129, 160);
			this.listBox_ModuleDisable.TabIndex = 67;
			this.listBox_ModuleDisable.Visible = false;
			this.listBox_ModuleDisable.MouseDoubleClick += new global::System.Windows.Forms.MouseEventHandler(this.listBox_ModuleDisable_MouseDoubleClick);
			this.button_ClearLogs.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.button_ClearLogs.Location = new global::System.Drawing.Point(425, 56);
			this.button_ClearLogs.Name = "button_ClearLogs";
			this.button_ClearLogs.Size = new global::System.Drawing.Size(123, 23);
			this.button_ClearLogs.TabIndex = 50;
			this.button_ClearLogs.Text = "Clear Logs";
			this.button_ClearLogs.UseVisualStyleBackColor = true;
			this.button_ClearLogs.Click += new global::System.EventHandler(this.button_ClearLogs_Click);
			this.richTextBoxMain.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.richTextBoxMain.Location = new global::System.Drawing.Point(9, 128);
			this.richTextBoxMain.Name = "richTextBoxMain";
			this.richTextBoxMain.ReadOnly = true;
			this.richTextBoxMain.Size = new global::System.Drawing.Size(541, 305);
			this.richTextBoxMain.TabIndex = 46;
			this.richTextBoxMain.Text = "";
			this.button1.Enabled = false;
			this.button1.Location = new global::System.Drawing.Point(325, 6);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(75, 23);
			this.button1.TabIndex = 78;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Visible = false;
			this.button1.Click += new global::System.EventHandler(this.Button1_Click_1);
			this.tabControl1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.tabControl1.Controls.Add(this.tabPage_Main);
			this.tabControl1.Controls.Add(this.tabPage_Feed);
			this.tabControl1.Controls.Add(this.tabPage_AutomaticActions);
			this.tabControl1.Controls.Add(this.tabPage_Refresh);
			this.tabControl1.Controls.Add(this.tabPage_FreeMonitor);
			this.tabControl1.Controls.Add(this.tabPage_Radar);
			this.tabControl1.Controls.Add(this.tabPage_Trade);
			this.tabControl1.Controls.Add(this.tabPage_Scouting);
			this.tabControl1.Controls.Add(this.tabPage_Research);
			this.tabControl1.Controls.Add(this.tabPage_Troopsrecruiting);
			this.tabControl1.Controls.Add(this.tabPage_Spin);
			this.tabControl1.Controls.Add(this.tabPage_Banquet);
			this.tabControl1.Controls.Add(this.tabPage_PopularityRegulation);
			this.tabControl1.Controls.Add(this.tabPage_Villagelayout);
			this.tabControl1.Controls.Add(this.tabPage_Castle);
			this.tabControl1.Controls.Add(this.tabPage_Predator);
			this.tabControl1.Controls.Add(this.tabPage_TimedAttacks);
			this.tabControl1.Controls.Add(this.tabPage_Monks);
			this.tabControl1.Controls.Add(this.tabPage_Error);
			this.tabControl1.Location = new global::System.Drawing.Point(3, 35);
			this.tabControl1.Multiline = true;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new global::System.Drawing.Size(564, 668);
			this.tabControl1.TabIndex = 21;
			this.tabControl1.SelectedIndexChanged += new global::System.EventHandler(this.tabControl1_SelectedIndexChanged);
			this.tabControl1.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseDown);
			this.tabControl1.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseMove);
			this.tabControl1.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseUp);
			this.tabPage_Feed.Controls.Add(this.checkBox_FeedShouldNotify);
			this.tabPage_Feed.Controls.Add(this.webBrowser_Feed);
			this.tabPage_Feed.Location = new global::System.Drawing.Point(4, 40);
			this.tabPage_Feed.Name = "tabPage_Feed";
			this.tabPage_Feed.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage_Feed.Size = new global::System.Drawing.Size(556, 626);
			this.tabPage_Feed.TabIndex = 24;
			this.tabPage_Feed.Text = "Feed";
			this.tabPage_Feed.UseVisualStyleBackColor = true;
			this.checkBox_FeedShouldNotify.AutoSize = true;
			this.checkBox_FeedShouldNotify.Checked = true;
			this.checkBox_FeedShouldNotify.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.checkBox_FeedShouldNotify.Location = new global::System.Drawing.Point(7, 7);
			this.checkBox_FeedShouldNotify.Name = "checkBox_FeedShouldNotify";
			this.checkBox_FeedShouldNotify.Size = new global::System.Drawing.Size(130, 17);
			this.checkBox_FeedShouldNotify.TabIndex = 1;
			this.checkBox_FeedShouldNotify.Text = "Notify about updates?";
			this.checkBox_FeedShouldNotify.UseVisualStyleBackColor = true;
			this.checkBox_FeedShouldNotify.CheckedChanged += new global::System.EventHandler(this.checkBox_FeedShouldNotify_CheckedChanged);
			this.webBrowser_Feed.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.webBrowser_Feed.Location = new global::System.Drawing.Point(3, 30);
			this.webBrowser_Feed.MinimumSize = new global::System.Drawing.Size(20, 20);
			this.webBrowser_Feed.Name = "webBrowser_Feed";
			this.webBrowser_Feed.ScriptErrorsSuppressed = true;
			this.webBrowser_Feed.Size = new global::System.Drawing.Size(550, 608);
			this.webBrowser_Feed.TabIndex = 0;
			this.tabPage_AutomaticActions.Controls.Add(this.checkBox_LoadBanquets);
			this.tabPage_AutomaticActions.Controls.Add(this.checkBox_StartMonks);
			this.tabPage_AutomaticActions.Controls.Add(this.checkBox_LoadMonksSettings);
			this.tabPage_AutomaticActions.Controls.Add(this.checkBox_LoadPredatorSettings);
			this.tabPage_AutomaticActions.Controls.Add(this.checkBox_Loadcastlerepairsettings);
			this.tabPage_AutomaticActions.Controls.Add(this.checkBox_Startregulatepopularity);
			this.tabPage_AutomaticActions.Controls.Add(this.checkBox_StartResearching);
			this.tabPage_AutomaticActions.Controls.Add(this.checkBox_LoadRadarsettings);
			this.tabPage_AutomaticActions.Controls.Add(this.checkBox_Startbuildingvillages);
			this.tabPage_AutomaticActions.Controls.Add(this.checkBox_Loadvillagelayouts);
			this.tabPage_AutomaticActions.Controls.Add(this.checkBox_LoadResearches);
			this.tabPage_AutomaticActions.Controls.Add(this.checkBox_Monitorattacks);
			this.tabPage_AutomaticActions.Controls.Add(this.checkBox_Banquet);
			this.tabPage_AutomaticActions.Controls.Add(this.checkBox_Recruittroops);
			this.tabPage_AutomaticActions.Controls.Add(this.checkBox_DownloadVillages);
			this.tabPage_AutomaticActions.Controls.Add(this.checkBox_Loadtroopsrecruitingsettings);
			this.tabPage_AutomaticActions.Controls.Add(this.checkBox_Starttrading);
			this.tabPage_AutomaticActions.Controls.Add(this.checkBox_Loadtradesettings);
			this.tabPage_AutomaticActions.Controls.Add(this.checkBox_Startscouting);
			this.tabPage_AutomaticActions.Controls.Add(this.checkBox_Loadscoutssettings);
			this.tabPage_AutomaticActions.Controls.Add(this.checkBox_Login);
			this.tabPage_AutomaticActions.Controls.Add(this.checkBox_RememberPassword);
			this.tabPage_AutomaticActions.Location = new global::System.Drawing.Point(4, 40);
			this.tabPage_AutomaticActions.Name = "tabPage_AutomaticActions";
			this.tabPage_AutomaticActions.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage_AutomaticActions.Size = new global::System.Drawing.Size(556, 626);
			this.tabPage_AutomaticActions.TabIndex = 16;
			this.tabPage_AutomaticActions.Text = "Autorun";
			this.tabPage_AutomaticActions.UseVisualStyleBackColor = true;
			this.checkBox_LoadBanquets.AutoSize = true;
			this.checkBox_LoadBanquets.Location = new global::System.Drawing.Point(8, 259);
			this.checkBox_LoadBanquets.Name = "checkBox_LoadBanquets";
			this.checkBox_LoadBanquets.Size = new global::System.Drawing.Size(98, 17);
			this.checkBox_LoadBanquets.TabIndex = 23;
			this.checkBox_LoadBanquets.Text = "Load Banquets";
			this.checkBox_LoadBanquets.UseVisualStyleBackColor = true;
			this.checkBox_LoadBanquets.CheckedChanged += new global::System.EventHandler(this.ActionChanged);
			this.checkBox_StartMonks.AutoSize = true;
			this.checkBox_StartMonks.Location = new global::System.Drawing.Point(6, 489);
			this.checkBox_StartMonks.Name = "checkBox_StartMonks";
			this.checkBox_StartMonks.Size = new global::System.Drawing.Size(83, 17);
			this.checkBox_StartMonks.TabIndex = 22;
			this.checkBox_StartMonks.Text = "Start Monks";
			this.checkBox_StartMonks.UseVisualStyleBackColor = true;
			this.checkBox_LoadMonksSettings.AutoSize = true;
			this.checkBox_LoadMonksSettings.Location = new global::System.Drawing.Point(7, 466);
			this.checkBox_LoadMonksSettings.Name = "checkBox_LoadMonksSettings";
			this.checkBox_LoadMonksSettings.Size = new global::System.Drawing.Size(126, 17);
			this.checkBox_LoadMonksSettings.TabIndex = 21;
			this.checkBox_LoadMonksSettings.Text = "Load Monks Settings";
			this.checkBox_LoadMonksSettings.UseVisualStyleBackColor = true;
			this.checkBox_LoadPredatorSettings.AutoSize = true;
			this.checkBox_LoadPredatorSettings.Location = new global::System.Drawing.Point(8, 443);
			this.checkBox_LoadPredatorSettings.Name = "checkBox_LoadPredatorSettings";
			this.checkBox_LoadPredatorSettings.Size = new global::System.Drawing.Size(134, 17);
			this.checkBox_LoadPredatorSettings.TabIndex = 20;
			this.checkBox_LoadPredatorSettings.Text = "Load Predator Settings";
			this.checkBox_LoadPredatorSettings.UseVisualStyleBackColor = true;
			this.checkBox_LoadPredatorSettings.CheckedChanged += new global::System.EventHandler(this.ActionChanged);
			this.checkBox_Loadcastlerepairsettings.AutoSize = true;
			this.checkBox_Loadcastlerepairsettings.Location = new global::System.Drawing.Point(8, 420);
			this.checkBox_Loadcastlerepairsettings.Name = "checkBox_Loadcastlerepairsettings";
			this.checkBox_Loadcastlerepairsettings.Size = new global::System.Drawing.Size(157, 17);
			this.checkBox_Loadcastlerepairsettings.TabIndex = 19;
			this.checkBox_Loadcastlerepairsettings.Text = "Load Castle Repair Settings";
			this.checkBox_Loadcastlerepairsettings.UseVisualStyleBackColor = true;
			this.checkBox_Loadcastlerepairsettings.CheckedChanged += new global::System.EventHandler(this.ActionChanged);
			this.checkBox_Startregulatepopularity.AutoSize = true;
			this.checkBox_Startregulatepopularity.Location = new global::System.Drawing.Point(8, 397);
			this.checkBox_Startregulatepopularity.Name = "checkBox_Startregulatepopularity";
			this.checkBox_Startregulatepopularity.Size = new global::System.Drawing.Size(137, 17);
			this.checkBox_Startregulatepopularity.TabIndex = 18;
			this.checkBox_Startregulatepopularity.Text = "Start regulate popularity";
			this.checkBox_Startregulatepopularity.UseVisualStyleBackColor = true;
			this.checkBox_Startregulatepopularity.CheckedChanged += new global::System.EventHandler(this.ActionChanged);
			this.checkBox_StartResearching.AutoSize = true;
			this.checkBox_StartResearching.Location = new global::System.Drawing.Point(8, 190);
			this.checkBox_StartResearching.Name = "checkBox_StartResearching";
			this.checkBox_StartResearching.Size = new global::System.Drawing.Size(111, 17);
			this.checkBox_StartResearching.TabIndex = 17;
			this.checkBox_StartResearching.Text = "Start Researching";
			this.checkBox_StartResearching.UseVisualStyleBackColor = true;
			this.checkBox_LoadRadarsettings.AutoSize = true;
			this.checkBox_LoadRadarsettings.Location = new global::System.Drawing.Point(8, 305);
			this.checkBox_LoadRadarsettings.Name = "checkBox_LoadRadarsettings";
			this.checkBox_LoadRadarsettings.Size = new global::System.Drawing.Size(121, 17);
			this.checkBox_LoadRadarsettings.TabIndex = 16;
			this.checkBox_LoadRadarsettings.Text = "Load Radar settings";
			this.checkBox_LoadRadarsettings.UseVisualStyleBackColor = true;
			this.checkBox_LoadRadarsettings.CheckedChanged += new global::System.EventHandler(this.ActionChanged);
			this.checkBox_Startbuildingvillages.AutoSize = true;
			this.checkBox_Startbuildingvillages.Location = new global::System.Drawing.Point(8, 374);
			this.checkBox_Startbuildingvillages.Name = "checkBox_Startbuildingvillages";
			this.checkBox_Startbuildingvillages.Size = new global::System.Drawing.Size(125, 17);
			this.checkBox_Startbuildingvillages.TabIndex = 15;
			this.checkBox_Startbuildingvillages.Text = "Start building villages";
			this.checkBox_Startbuildingvillages.UseVisualStyleBackColor = true;
			this.checkBox_Startbuildingvillages.CheckedChanged += new global::System.EventHandler(this.ActionChanged);
			this.checkBox_Loadvillagelayouts.AutoSize = true;
			this.checkBox_Loadvillagelayouts.Location = new global::System.Drawing.Point(8, 351);
			this.checkBox_Loadvillagelayouts.Name = "checkBox_Loadvillagelayouts";
			this.checkBox_Loadvillagelayouts.Size = new global::System.Drawing.Size(119, 17);
			this.checkBox_Loadvillagelayouts.TabIndex = 14;
			this.checkBox_Loadvillagelayouts.Text = "Load village layouts";
			this.checkBox_Loadvillagelayouts.UseVisualStyleBackColor = true;
			this.checkBox_Loadvillagelayouts.CheckedChanged += new global::System.EventHandler(this.ActionChanged);
			this.checkBox_LoadResearches.AutoSize = true;
			this.checkBox_LoadResearches.Location = new global::System.Drawing.Point(8, 167);
			this.checkBox_LoadResearches.Name = "checkBox_LoadResearches";
			this.checkBox_LoadResearches.Size = new global::System.Drawing.Size(110, 17);
			this.checkBox_LoadResearches.TabIndex = 13;
			this.checkBox_LoadResearches.Text = "Load Researches";
			this.checkBox_LoadResearches.UseVisualStyleBackColor = true;
			this.checkBox_LoadResearches.CheckedChanged += new global::System.EventHandler(this.ActionChanged);
			this.checkBox_Monitorattacks.AutoSize = true;
			this.checkBox_Monitorattacks.Location = new global::System.Drawing.Point(8, 328);
			this.checkBox_Monitorattacks.Name = "checkBox_Monitorattacks";
			this.checkBox_Monitorattacks.Size = new global::System.Drawing.Size(99, 17);
			this.checkBox_Monitorattacks.TabIndex = 12;
			this.checkBox_Monitorattacks.Text = "Monitor attacks";
			this.checkBox_Monitorattacks.UseVisualStyleBackColor = true;
			this.checkBox_Monitorattacks.CheckedChanged += new global::System.EventHandler(this.ActionChanged);
			this.checkBox_Banquet.AutoSize = true;
			this.checkBox_Banquet.Location = new global::System.Drawing.Point(8, 282);
			this.checkBox_Banquet.Name = "checkBox_Banquet";
			this.checkBox_Banquet.Size = new global::System.Drawing.Size(66, 17);
			this.checkBox_Banquet.TabIndex = 11;
			this.checkBox_Banquet.Text = "Banquet";
			this.checkBox_Banquet.UseVisualStyleBackColor = true;
			this.checkBox_Banquet.CheckedChanged += new global::System.EventHandler(this.ActionChanged);
			this.checkBox_Recruittroops.AutoSize = true;
			this.checkBox_Recruittroops.Location = new global::System.Drawing.Point(8, 236);
			this.checkBox_Recruittroops.Name = "checkBox_Recruittroops";
			this.checkBox_Recruittroops.Size = new global::System.Drawing.Size(92, 17);
			this.checkBox_Recruittroops.TabIndex = 10;
			this.checkBox_Recruittroops.Text = "Recruit troops";
			this.checkBox_Recruittroops.UseVisualStyleBackColor = true;
			this.checkBox_Recruittroops.CheckedChanged += new global::System.EventHandler(this.ActionChanged);
			this.checkBox_DownloadVillages.AutoSize = true;
			this.checkBox_DownloadVillages.Checked = true;
			this.checkBox_DownloadVillages.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.checkBox_DownloadVillages.Enabled = false;
			this.checkBox_DownloadVillages.Location = new global::System.Drawing.Point(8, 52);
			this.checkBox_DownloadVillages.Name = "checkBox_DownloadVillages";
			this.checkBox_DownloadVillages.Size = new global::System.Drawing.Size(113, 17);
			this.checkBox_DownloadVillages.TabIndex = 9;
			this.checkBox_DownloadVillages.Text = "Download Villages";
			this.toolTip1.SetToolTip(this.checkBox_DownloadVillages, "Please use Refresh tab");
			this.checkBox_DownloadVillages.UseVisualStyleBackColor = true;
			this.checkBox_DownloadVillages.Visible = false;
			this.checkBox_DownloadVillages.CheckedChanged += new global::System.EventHandler(this.ActionChanged);
			this.checkBox_Loadtroopsrecruitingsettings.AutoSize = true;
			this.checkBox_Loadtroopsrecruitingsettings.Location = new global::System.Drawing.Point(8, 213);
			this.checkBox_Loadtroopsrecruitingsettings.Name = "checkBox_Loadtroopsrecruitingsettings";
			this.checkBox_Loadtroopsrecruitingsettings.Size = new global::System.Drawing.Size(167, 17);
			this.checkBox_Loadtroopsrecruitingsettings.TabIndex = 8;
			this.checkBox_Loadtroopsrecruitingsettings.Text = "Load troops recruiting settings";
			this.checkBox_Loadtroopsrecruitingsettings.UseVisualStyleBackColor = true;
			this.checkBox_Loadtroopsrecruitingsettings.CheckedChanged += new global::System.EventHandler(this.ActionChanged);
			this.checkBox_Starttrading.AutoSize = true;
			this.checkBox_Starttrading.Location = new global::System.Drawing.Point(8, 144);
			this.checkBox_Starttrading.Name = "checkBox_Starttrading";
			this.checkBox_Starttrading.Size = new global::System.Drawing.Size(83, 17);
			this.checkBox_Starttrading.TabIndex = 7;
			this.checkBox_Starttrading.Text = "Start trading";
			this.checkBox_Starttrading.UseVisualStyleBackColor = true;
			this.checkBox_Starttrading.CheckedChanged += new global::System.EventHandler(this.ActionChanged);
			this.checkBox_Loadtradesettings.AutoSize = true;
			this.checkBox_Loadtradesettings.Location = new global::System.Drawing.Point(8, 121);
			this.checkBox_Loadtradesettings.Name = "checkBox_Loadtradesettings";
			this.checkBox_Loadtradesettings.Size = new global::System.Drawing.Size(116, 17);
			this.checkBox_Loadtradesettings.TabIndex = 4;
			this.checkBox_Loadtradesettings.Text = "Load trade settings";
			this.checkBox_Loadtradesettings.UseVisualStyleBackColor = true;
			this.checkBox_Loadtradesettings.CheckedChanged += new global::System.EventHandler(this.ActionChanged);
			this.checkBox_Startscouting.AutoSize = true;
			this.checkBox_Startscouting.Location = new global::System.Drawing.Point(8, 98);
			this.checkBox_Startscouting.Name = "checkBox_Startscouting";
			this.checkBox_Startscouting.Size = new global::System.Drawing.Size(91, 17);
			this.checkBox_Startscouting.TabIndex = 3;
			this.checkBox_Startscouting.Text = "Start scouting";
			this.checkBox_Startscouting.UseVisualStyleBackColor = true;
			this.checkBox_Startscouting.CheckedChanged += new global::System.EventHandler(this.ActionChanged);
			this.checkBox_Loadscoutssettings.AutoSize = true;
			this.checkBox_Loadscoutssettings.Location = new global::System.Drawing.Point(8, 75);
			this.checkBox_Loadscoutssettings.Name = "checkBox_Loadscoutssettings";
			this.checkBox_Loadscoutssettings.Size = new global::System.Drawing.Size(123, 17);
			this.checkBox_Loadscoutssettings.TabIndex = 2;
			this.checkBox_Loadscoutssettings.Text = "Load scouts settings";
			this.checkBox_Loadscoutssettings.UseVisualStyleBackColor = true;
			this.checkBox_Loadscoutssettings.CheckedChanged += new global::System.EventHandler(this.ActionChanged);
			this.checkBox_Login.AutoSize = true;
			this.checkBox_Login.Location = new global::System.Drawing.Point(8, 29);
			this.checkBox_Login.Name = "checkBox_Login";
			this.checkBox_Login.Size = new global::System.Drawing.Size(52, 17);
			this.checkBox_Login.TabIndex = 1;
			this.checkBox_Login.Text = "Login";
			this.checkBox_Login.UseVisualStyleBackColor = true;
			this.checkBox_Login.CheckedChanged += new global::System.EventHandler(this.ActionChanged);
			this.checkBox_RememberPassword.AutoSize = true;
			this.checkBox_RememberPassword.Enabled = false;
			this.checkBox_RememberPassword.Location = new global::System.Drawing.Point(8, 6);
			this.checkBox_RememberPassword.Name = "checkBox_RememberPassword";
			this.checkBox_RememberPassword.Size = new global::System.Drawing.Size(126, 17);
			this.checkBox_RememberPassword.TabIndex = 0;
			this.checkBox_RememberPassword.Text = "Remember Password";
			this.checkBox_RememberPassword.UseVisualStyleBackColor = true;
			this.checkBox_RememberPassword.Visible = false;
			this.checkBox_RememberPassword.CheckedChanged += new global::System.EventHandler(this.ActionChanged);
			this.tabPage_Refresh.Controls.Add(this.button_RefreshHelp);
			this.tabPage_Refresh.Controls.Add(this.button_LoadRefreshList);
			this.tabPage_Refresh.Controls.Add(this.button_SaveRefreshList);
			this.tabPage_Refresh.Controls.Add(this.checkBox_RefreshCapitals);
			this.tabPage_Refresh.Controls.Add(this.checkBox_IsFullRefreshAllowed);
			this.tabPage_Refresh.Controls.Add(this.richTextBox_Refresh);
			this.tabPage_Refresh.Controls.Add(this.checkBox_EnableRefresh);
			this.tabPage_Refresh.Controls.Add(this.checkBox_AllRefresh);
			this.tabPage_Refresh.Controls.Add(this.listBox_Refresh);
			this.tabPage_Refresh.Location = new global::System.Drawing.Point(4, 40);
			this.tabPage_Refresh.Name = "tabPage_Refresh";
			this.tabPage_Refresh.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage_Refresh.Size = new global::System.Drawing.Size(556, 626);
			this.tabPage_Refresh.TabIndex = 22;
			this.tabPage_Refresh.Text = "Download villages";
			this.tabPage_Refresh.UseVisualStyleBackColor = true;
			this.button_RefreshHelp.Location = new global::System.Drawing.Point(177, 317);
			this.button_RefreshHelp.Name = "button_RefreshHelp";
			this.button_RefreshHelp.Size = new global::System.Drawing.Size(131, 23);
			this.button_RefreshHelp.TabIndex = 8;
			this.button_RefreshHelp.Text = "Help";
			this.button_RefreshHelp.UseVisualStyleBackColor = true;
			this.button_RefreshHelp.Click += new global::System.EventHandler(this.Button_RefreshHelp_Click);
			this.button_LoadRefreshList.Location = new global::System.Drawing.Point(176, 375);
			this.button_LoadRefreshList.Name = "button_LoadRefreshList";
			this.button_LoadRefreshList.Size = new global::System.Drawing.Size(132, 23);
			this.button_LoadRefreshList.TabIndex = 7;
			this.button_LoadRefreshList.Text = "Load";
			this.button_LoadRefreshList.UseVisualStyleBackColor = true;
			this.button_LoadRefreshList.Click += new global::System.EventHandler(this.Button_LoadRefreshList_Click);
			this.button_SaveRefreshList.Location = new global::System.Drawing.Point(176, 346);
			this.button_SaveRefreshList.Name = "button_SaveRefreshList";
			this.button_SaveRefreshList.Size = new global::System.Drawing.Size(132, 23);
			this.button_SaveRefreshList.TabIndex = 6;
			this.button_SaveRefreshList.Text = "Save";
			this.button_SaveRefreshList.UseVisualStyleBackColor = true;
			this.button_SaveRefreshList.Click += new global::System.EventHandler(this.Button_SaveRefreshList_Click);
			this.checkBox_RefreshCapitals.AutoSize = true;
			this.checkBox_RefreshCapitals.Location = new global::System.Drawing.Point(201, 52);
			this.checkBox_RefreshCapitals.Name = "checkBox_RefreshCapitals";
			this.checkBox_RefreshCapitals.Size = new global::System.Drawing.Size(237, 17);
			this.checkBox_RefreshCapitals.TabIndex = 5;
			this.checkBox_RefreshCapitals.Text = "Allow Refresh Capitals (it will switch capitals!)";
			this.toolTip1.SetToolTip(this.checkBox_RefreshCapitals, "It opens the Capital in the Interface!");
			this.checkBox_RefreshCapitals.UseVisualStyleBackColor = true;
			this.checkBox_RefreshCapitals.CheckedChanged += new global::System.EventHandler(this.CheckBox_RefreshCapitals_CheckedChanged);
			this.checkBox_IsFullRefreshAllowed.AutoSize = true;
			this.checkBox_IsFullRefreshAllowed.Location = new global::System.Drawing.Point(201, 29);
			this.checkBox_IsFullRefreshAllowed.Name = "checkBox_IsFullRefreshAllowed";
			this.checkBox_IsFullRefreshAllowed.Size = new global::System.Drawing.Size(272, 17);
			this.checkBox_IsFullRefreshAllowed.TabIndex = 4;
			this.checkBox_IsFullRefreshAllowed.Text = "Allow Full Refresh For Villages (it will switch villages!)";
			this.toolTip1.SetToolTip(this.checkBox_IsFullRefreshAllowed, "It's safer but it takes over the interface. Use it over night or when you don't play.");
			this.checkBox_IsFullRefreshAllowed.UseVisualStyleBackColor = true;
			this.checkBox_IsFullRefreshAllowed.CheckedChanged += new global::System.EventHandler(this.CheckBox_IsFullRefreshAllowed_CheckedChanged);
			this.richTextBox_Refresh.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.richTextBox_Refresh.Location = new global::System.Drawing.Point(3, 454);
			this.richTextBox_Refresh.Name = "richTextBox_Refresh";
			this.richTextBox_Refresh.ReadOnly = true;
			this.richTextBox_Refresh.Size = new global::System.Drawing.Size(550, 169);
			this.richTextBox_Refresh.TabIndex = 3;
			this.richTextBox_Refresh.Text = "";
			this.checkBox_EnableRefresh.AutoSize = true;
			this.checkBox_EnableRefresh.Checked = true;
			this.checkBox_EnableRefresh.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.checkBox_EnableRefresh.Location = new global::System.Drawing.Point(201, 6);
			this.checkBox_EnableRefresh.Name = "checkBox_EnableRefresh";
			this.checkBox_EnableRefresh.Size = new global::System.Drawing.Size(87, 17);
			this.checkBox_EnableRefresh.TabIndex = 2;
			this.checkBox_EnableRefresh.Text = "Turn On | Off";
			this.checkBox_EnableRefresh.UseVisualStyleBackColor = true;
			this.checkBox_EnableRefresh.CheckedChanged += new global::System.EventHandler(this.CheckBox_EnableRefresh_CheckedChanged);
			this.checkBox_AllRefresh.AutoSize = true;
			this.checkBox_AllRefresh.Checked = true;
			this.checkBox_AllRefresh.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.checkBox_AllRefresh.Location = new global::System.Drawing.Point(155, 6);
			this.checkBox_AllRefresh.Name = "checkBox_AllRefresh";
			this.checkBox_AllRefresh.Size = new global::System.Drawing.Size(15, 14);
			this.checkBox_AllRefresh.TabIndex = 1;
			this.checkBox_AllRefresh.UseVisualStyleBackColor = true;
			this.checkBox_AllRefresh.CheckedChanged += new global::System.EventHandler(this.CheckBox_AllRefresh_CheckedChanged);
			this.listBox_Refresh.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.listBox_Refresh.FormattingEnabled = true;
			this.listBox_Refresh.Location = new global::System.Drawing.Point(3, 26);
			this.listBox_Refresh.Name = "listBox_Refresh";
			this.listBox_Refresh.SelectionMode = global::System.Windows.Forms.SelectionMode.MultiSimple;
			this.listBox_Refresh.Size = new global::System.Drawing.Size(167, 433);
			this.listBox_Refresh.TabIndex = 0;
			this.listBox_Refresh.SelectedIndexChanged += new global::System.EventHandler(this.ListBox_Refresh_SelectedIndexChanged);
			this.tabPage_FreeMonitor.Controls.Add(this.checkedListBox_FreeMonitorColumns);
			this.tabPage_FreeMonitor.Controls.Add(this.checkBox_FreeMonitorEnable);
			this.tabPage_FreeMonitor.Controls.Add(this.label_FreeMonitorLastUpdateValue);
			this.tabPage_FreeMonitor.Controls.Add(this.label_FreeMonitorLastUpdate);
			this.tabPage_FreeMonitor.Controls.Add(this.label_NumResearchesInQueueValue);
			this.tabPage_FreeMonitor.Controls.Add(this.label_NumResearchesInQueue);
			this.tabPage_FreeMonitor.Controls.Add(this.dataGridView_FreeMonitor);
			this.tabPage_FreeMonitor.Location = new global::System.Drawing.Point(4, 40);
			this.tabPage_FreeMonitor.Name = "tabPage_FreeMonitor";
			this.tabPage_FreeMonitor.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage_FreeMonitor.Size = new global::System.Drawing.Size(556, 626);
			this.tabPage_FreeMonitor.TabIndex = 20;
			this.tabPage_FreeMonitor.Text = "Free Monitor";
			this.tabPage_FreeMonitor.UseVisualStyleBackColor = true;
			this.checkedListBox_FreeMonitorColumns.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.checkedListBox_FreeMonitorColumns.CheckOnClick = true;
			this.checkedListBox_FreeMonitorColumns.FormattingEnabled = true;
			this.checkedListBox_FreeMonitorColumns.Items.AddRange(new object[]
			{
				"Village Status",
				"Traders",
				"Scouts",
				"Recruits",
				"Banquets",
				"Popularity",
				"Faith Points",
				"Construction queue",
				"Is Castle Damaged",
				"Is Castle Enclosed",
				"Castle Completition In",
				"AIs around",
				"Captains"
			});
			this.checkedListBox_FreeMonitorColumns.Location = new global::System.Drawing.Point(428, 0);
			this.checkedListBox_FreeMonitorColumns.Name = "checkedListBox_FreeMonitorColumns";
			this.checkedListBox_FreeMonitorColumns.Size = new global::System.Drawing.Size(128, 169);
			this.checkedListBox_FreeMonitorColumns.TabIndex = 6;
			this.checkedListBox_FreeMonitorColumns.SelectedIndexChanged += new global::System.EventHandler(this.checkedListBox_FreeMonitorColumns_SelectedIndexChanged);
			this.checkBox_FreeMonitorEnable.AutoSize = true;
			this.checkBox_FreeMonitorEnable.Location = new global::System.Drawing.Point(9, 7);
			this.checkBox_FreeMonitorEnable.Name = "checkBox_FreeMonitorEnable";
			this.checkBox_FreeMonitorEnable.Size = new global::System.Drawing.Size(65, 17);
			this.checkBox_FreeMonitorEnable.TabIndex = 5;
			this.checkBox_FreeMonitorEnable.Text = "Turn On";
			this.checkBox_FreeMonitorEnable.UseVisualStyleBackColor = true;
			this.checkBox_FreeMonitorEnable.CheckedChanged += new global::System.EventHandler(this.checkBox_FreeMonitorEnable_CheckedChanged);
			this.label_FreeMonitorLastUpdateValue.AutoSize = true;
			this.label_FreeMonitorLastUpdateValue.Location = new global::System.Drawing.Point(237, 8);
			this.label_FreeMonitorLastUpdateValue.Name = "label_FreeMonitorLastUpdateValue";
			this.label_FreeMonitorLastUpdateValue.Size = new global::System.Drawing.Size(43, 13);
			this.label_FreeMonitorLastUpdateValue.TabIndex = 4;
			this.label_FreeMonitorLastUpdateValue.Text = "no data";
			this.label_FreeMonitorLastUpdate.AutoSize = true;
			this.label_FreeMonitorLastUpdate.Location = new global::System.Drawing.Point(163, 8);
			this.label_FreeMonitorLastUpdate.Name = "label_FreeMonitorLastUpdate";
			this.label_FreeMonitorLastUpdate.Size = new global::System.Drawing.Size(68, 13);
			this.label_FreeMonitorLastUpdate.TabIndex = 3;
			this.label_FreeMonitorLastUpdate.Text = "Last Update:";
			this.label_NumResearchesInQueueValue.AutoSize = true;
			this.label_NumResearchesInQueueValue.Location = new global::System.Drawing.Point(188, 30);
			this.label_NumResearchesInQueueValue.Name = "label_NumResearchesInQueueValue";
			this.label_NumResearchesInQueueValue.Size = new global::System.Drawing.Size(43, 13);
			this.label_NumResearchesInQueueValue.TabIndex = 2;
			this.label_NumResearchesInQueueValue.Text = "no data";
			this.label_NumResearchesInQueue.AutoSize = true;
			this.label_NumResearchesInQueue.Location = new global::System.Drawing.Point(6, 30);
			this.label_NumResearchesInQueue.Name = "label_NumResearchesInQueue";
			this.label_NumResearchesInQueue.Size = new global::System.Drawing.Size(176, 13);
			this.label_NumResearchesInQueue.TabIndex = 1;
			this.label_NumResearchesInQueue.Text = "Number of researches in the queue:";
			this.dataGridView_FreeMonitor.AllowUserToAddRows = false;
			this.dataGridView_FreeMonitor.AllowUserToDeleteRows = false;
			this.dataGridView_FreeMonitor.AutoSizeRowsMode = global::System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridView_FreeMonitor.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_FreeMonitor.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.FreeMonitorVillage,
				this.FreeMonitorVillageStatus,
				this.FreeMonitorTraders,
				this.FreeMonitorScouts,
				this.FreeMonitorRecruits,
				this.FreeMonitorBanquets,
				this.FreeMonitorPopularity,
				this.FreeMonitorFaithPoints,
				this.FreeMonitorConstrutionQueue,
				this.FreeMonitorIsCastleDamaged,
				this.FreeMonitorIsCastleEnlosed,
				this.FreeMonitorCastleCompleteTime,
				this.FreeMonitorAIsAround,
				this.FreeMonitorCaptains
			});
			this.dataGridView_FreeMonitor.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.dataGridView_FreeMonitor.Location = new global::System.Drawing.Point(3, 190);
			this.dataGridView_FreeMonitor.Name = "dataGridView_FreeMonitor";
			this.dataGridView_FreeMonitor.ReadOnly = true;
			this.dataGridView_FreeMonitor.RowHeadersVisible = false;
			dataGridViewCellStyle7.WrapMode = global::System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView_FreeMonitor.RowsDefaultCellStyle = dataGridViewCellStyle7;
			this.dataGridView_FreeMonitor.Size = new global::System.Drawing.Size(550, 433);
			this.dataGridView_FreeMonitor.TabIndex = 0;
			this.FreeMonitorVillage.HeaderText = "Village";
			this.FreeMonitorVillage.Name = "FreeMonitorVillage";
			this.FreeMonitorVillage.ReadOnly = true;
			this.FreeMonitorVillage.ToolTipText = "Village name";
			this.FreeMonitorVillageStatus.HeaderText = "Village Status";
			this.FreeMonitorVillageStatus.Name = "FreeMonitorVillageStatus";
			this.FreeMonitorVillageStatus.ReadOnly = true;
			this.FreeMonitorVillageStatus.ToolTipText = "Interdiction, Excommunication and Peace time";
			this.FreeMonitorTraders.HeaderText = "Traders";
			this.FreeMonitorTraders.Name = "FreeMonitorTraders";
			this.FreeMonitorTraders.ReadOnly = true;
			this.FreeMonitorTraders.ToolTipText = "Available traders, total traders and maximum traders you can hire";
			this.FreeMonitorScouts.HeaderText = "Scouts";
			this.FreeMonitorScouts.Name = "FreeMonitorScouts";
			this.FreeMonitorScouts.ReadOnly = true;
			this.FreeMonitorScouts.ToolTipText = "Available scouts, total hired scouts and maximum scouts you can hire";
			this.FreeMonitorRecruits.HeaderText = "Recruits";
			this.FreeMonitorRecruits.Name = "FreeMonitorRecruits";
			this.FreeMonitorRecruits.ReadOnly = true;
			this.FreeMonitorRecruits.ToolTipText = "Available recruits in the village";
			this.FreeMonitorBanquets.HeaderText = "Banquets";
			this.FreeMonitorBanquets.Name = "FreeMonitorBanquets";
			this.FreeMonitorBanquets.ReadOnly = true;
			this.FreeMonitorBanquets.ToolTipText = "Maximum level of Banquet available at this village";
			this.FreeMonitorPopularity.HeaderText = "Popularity";
			this.FreeMonitorPopularity.Name = "FreeMonitorPopularity";
			this.FreeMonitorPopularity.ReadOnly = true;
			this.FreeMonitorPopularity.ToolTipText = "Popularity levels";
			this.FreeMonitorFaithPoints.HeaderText = "Faith Points";
			this.FreeMonitorFaithPoints.Name = "FreeMonitorFaithPoints";
			this.FreeMonitorFaithPoints.ReadOnly = true;
			this.FreeMonitorConstrutionQueue.HeaderText = "Constrution Queue";
			this.FreeMonitorConstrutionQueue.Name = "FreeMonitorConstrutionQueue";
			this.FreeMonitorConstrutionQueue.ReadOnly = true;
			this.FreeMonitorConstrutionQueue.ToolTipText = "Number of buildings in the construction queue and maximum queue length";
			this.FreeMonitorIsCastleDamaged.HeaderText = "Is Castle Damaged";
			this.FreeMonitorIsCastleDamaged.Name = "FreeMonitorIsCastleDamaged";
			this.FreeMonitorIsCastleDamaged.ReadOnly = true;
			this.FreeMonitorIsCastleEnlosed.HeaderText = "Is Castle Enlosed";
			this.FreeMonitorIsCastleEnlosed.Name = "FreeMonitorIsCastleEnlosed";
			this.FreeMonitorIsCastleEnlosed.ReadOnly = true;
			this.FreeMonitorCastleCompleteTime.HeaderText = "Castle Completition In";
			this.FreeMonitorCastleCompleteTime.Name = "FreeMonitorCastleCompleteTime";
			this.FreeMonitorCastleCompleteTime.ReadOnly = true;
			this.FreeMonitorAIsAround.HeaderText = "AIs Around";
			this.FreeMonitorAIsAround.Name = "FreeMonitorAIsAround";
			this.FreeMonitorAIsAround.ReadOnly = true;
			this.FreeMonitorAIsAround.Resizable = global::System.Windows.Forms.DataGridViewTriState.True;
			this.FreeMonitorAIsAround.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.FreeMonitorAIsAround.ToolTipText = "Number of AIs within honour circle";
			this.FreeMonitorCaptains.HeaderText = "Captains";
			this.FreeMonitorCaptains.Name = "FreeMonitorCaptains";
			this.FreeMonitorCaptains.ReadOnly = true;
			this.tabPage_Radar.Controls.Add(this.button_ExportForOffline);
			this.tabPage_Radar.Controls.Add(this.tabControl2);
			this.tabPage_Radar.Controls.Add(this.checkBox_RadarRehireMonks);
			this.tabPage_Radar.Controls.Add(this.button_RadarHelp);
			this.tabPage_Radar.Controls.Add(this.button_CloseAllMessages);
			this.tabPage_Radar.Controls.Add(this.button_RadarGridLoad);
			this.tabPage_Radar.Controls.Add(this.button_RadarGridSave);
			this.tabPage_Radar.Controls.Add(this.button_StopSoundPlayer);
			this.tabPage_Radar.Controls.Add(this.checkBox_Monitor);
			this.tabPage_Radar.Controls.Add(this.richTextBoxRadar);
			this.tabPage_Radar.Location = new global::System.Drawing.Point(4, 40);
			this.tabPage_Radar.Name = "tabPage_Radar";
			this.tabPage_Radar.Size = new global::System.Drawing.Size(556, 626);
			this.tabPage_Radar.TabIndex = 15;
			this.tabPage_Radar.Text = "Radar";
			this.tabPage_Radar.UseVisualStyleBackColor = true;
			this.button_ExportForOffline.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.button_ExportForOffline.Location = new global::System.Drawing.Point(437, 32);
			this.button_ExportForOffline.Name = "button_ExportForOffline";
			this.button_ExportForOffline.Size = new global::System.Drawing.Size(119, 23);
			this.button_ExportForOffline.TabIndex = 39;
			this.button_ExportForOffline.Text = "Export Settings";
			this.button_ExportForOffline.UseVisualStyleBackColor = true;
			this.button_ExportForOffline.Click += new global::System.EventHandler(this.button_ExportForOffline_Click);
			this.tabControl2.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.tabControl2.Controls.Add(this.tabPage_RadarMain);
			this.tabControl2.Controls.Add(this.tabPage_Interdict);
			this.tabControl2.Controls.Add(this.tabPage_RadarEmail);
			this.tabControl2.Controls.Add(this.tabPage_RadarDiscord);
			this.tabControl2.Controls.Add(this.tabPage_RadarTelegram);
			this.tabControl2.Controls.Add(this.tabPage_RadarTest);
			this.tabControl2.Controls.Add(this.tabPage_AltAccounts);
			this.tabControl2.Controls.Add(this.tabPage_RadarAutoID);
			this.tabControl2.Location = new global::System.Drawing.Point(0, 61);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new global::System.Drawing.Size(556, 300);
			this.tabControl2.TabIndex = 38;
			this.tabPage_RadarMain.Controls.Add(this.dataGridView_RadarSettings);
			this.tabPage_RadarMain.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage_RadarMain.Name = "tabPage_RadarMain";
			this.tabPage_RadarMain.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage_RadarMain.Size = new global::System.Drawing.Size(548, 274);
			this.tabPage_RadarMain.TabIndex = 0;
			this.tabPage_RadarMain.Text = "Radar";
			this.tabPage_RadarMain.UseVisualStyleBackColor = true;
			this.dataGridView_RadarSettings.AllowUserToAddRows = false;
			this.dataGridView_RadarSettings.AllowUserToDeleteRows = false;
			this.dataGridView_RadarSettings.AutoSizeColumnsMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView_RadarSettings.AutoSizeRowsMode = global::System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridView_RadarSettings.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_RadarSettings.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.RadarEvent,
				this.RadarTrackEvent,
				this.RadarMessagePopup,
				this.RadarSound,
				this.RadarSendEmail,
				this.RadarInterdict,
				this.RadarSystemNotification,
				this.RadarDiscord,
				this.RadarTelegram
			});
			this.dataGridView_RadarSettings.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.dataGridView_RadarSettings.Location = new global::System.Drawing.Point(3, 3);
			this.dataGridView_RadarSettings.MultiSelect = false;
			this.dataGridView_RadarSettings.Name = "dataGridView_RadarSettings";
			this.dataGridView_RadarSettings.RowHeadersVisible = false;
			this.dataGridView_RadarSettings.Size = new global::System.Drawing.Size(542, 268);
			this.dataGridView_RadarSettings.TabIndex = 29;
			this.RadarEvent.HeaderText = "Event";
			this.RadarEvent.Name = "RadarEvent";
			this.RadarEvent.ReadOnly = true;
			this.RadarEvent.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.RadarTrackEvent.HeaderText = "Monitor Event?";
			this.RadarTrackEvent.Name = "RadarTrackEvent";
			this.RadarMessagePopup.HeaderText = "Popup Message";
			this.RadarMessagePopup.Name = "RadarMessagePopup";
			this.RadarSound.HeaderText = "Play Sound";
			this.RadarSound.Name = "RadarSound";
			this.RadarSound.Resizable = global::System.Windows.Forms.DataGridViewTriState.True;
			this.RadarSound.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.RadarSendEmail.HeaderText = "Send Email";
			this.RadarSendEmail.Name = "RadarSendEmail";
			this.RadarInterdict.HeaderText = "Interdict (monks)";
			this.RadarInterdict.Name = "RadarInterdict";
			this.RadarInterdict.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.RadarSystemNotification.HeaderText = "System Notification";
			this.RadarSystemNotification.Name = "RadarSystemNotification";
			this.RadarDiscord.HeaderText = "Discord";
			this.RadarDiscord.Name = "RadarDiscord";
			this.RadarTelegram.HeaderText = "Telegram";
			this.RadarTelegram.Name = "RadarTelegram";
			this.tabPage_Interdict.Controls.Add(this.button_InterdictTabHelp);
			this.tabPage_Interdict.Controls.Add(this.checkBox_Interdict_AllowHireMonks);
			this.tabPage_Interdict.Controls.Add(this.checkBox_Interdict_SkipIfAlreadyID);
			this.tabPage_Interdict.Controls.Add(this.checkBox_InterdictSelectAll);
			this.tabPage_Interdict.Controls.Add(this.numericUpDown_InterdictNumberOfMonks);
			this.tabPage_Interdict.Controls.Add(this.label_InterdictNumberOfMonks);
			this.tabPage_Interdict.Controls.Add(this.button_Interdict);
			this.tabPage_Interdict.Controls.Add(this.listBox_Interdict);
			this.tabPage_Interdict.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage_Interdict.Name = "tabPage_Interdict";
			this.tabPage_Interdict.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage_Interdict.Size = new global::System.Drawing.Size(548, 274);
			this.tabPage_Interdict.TabIndex = 21;
			this.tabPage_Interdict.Text = "Interdict";
			this.tabPage_Interdict.UseVisualStyleBackColor = true;
			this.button_InterdictTabHelp.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.button_InterdictTabHelp.Location = new global::System.Drawing.Point(472, 6);
			this.button_InterdictTabHelp.Name = "button_InterdictTabHelp";
			this.button_InterdictTabHelp.Size = new global::System.Drawing.Size(75, 23);
			this.button_InterdictTabHelp.TabIndex = 39;
			this.button_InterdictTabHelp.Text = "Help";
			this.button_InterdictTabHelp.UseVisualStyleBackColor = true;
			this.button_InterdictTabHelp.Click += new global::System.EventHandler(this.button_InterdictTabHelp_Click);
			this.checkBox_Interdict_AllowHireMonks.AutoSize = true;
			this.checkBox_Interdict_AllowHireMonks.Checked = true;
			this.checkBox_Interdict_AllowHireMonks.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.checkBox_Interdict_AllowHireMonks.Location = new global::System.Drawing.Point(227, 98);
			this.checkBox_Interdict_AllowHireMonks.Name = "checkBox_Interdict_AllowHireMonks";
			this.checkBox_Interdict_AllowHireMonks.Size = new global::System.Drawing.Size(108, 17);
			this.checkBox_Interdict_AllowHireMonks.TabIndex = 38;
			this.checkBox_Interdict_AllowHireMonks.Text = "Allow Hire Monks";
			this.checkBox_Interdict_AllowHireMonks.UseVisualStyleBackColor = true;
			this.checkBox_Interdict_SkipIfAlreadyID.AutoSize = true;
			this.checkBox_Interdict_SkipIfAlreadyID.Location = new global::System.Drawing.Point(227, 75);
			this.checkBox_Interdict_SkipIfAlreadyID.Name = "checkBox_Interdict_SkipIfAlreadyID";
			this.checkBox_Interdict_SkipIfAlreadyID.Size = new global::System.Drawing.Size(288, 17);
			this.checkBox_Interdict_SkipIfAlreadyID.TabIndex = 6;
			this.checkBox_Interdict_SkipIfAlreadyID.Text = "Reduce number of monks if village is already interdicted";
			this.checkBox_Interdict_SkipIfAlreadyID.UseVisualStyleBackColor = true;
			this.checkBox_InterdictSelectAll.AutoSize = true;
			this.checkBox_InterdictSelectAll.Location = new global::System.Drawing.Point(227, 6);
			this.checkBox_InterdictSelectAll.Name = "checkBox_InterdictSelectAll";
			this.checkBox_InterdictSelectAll.Size = new global::System.Drawing.Size(70, 17);
			this.checkBox_InterdictSelectAll.TabIndex = 5;
			this.checkBox_InterdictSelectAll.Text = "Select All";
			this.checkBox_InterdictSelectAll.UseVisualStyleBackColor = true;
			this.checkBox_InterdictSelectAll.CheckedChanged += new global::System.EventHandler(this.checkBox_InterdictSelectAll_CheckedChanged);
			this.numericUpDown_InterdictNumberOfMonks.Location = new global::System.Drawing.Point(326, 49);
			global::System.Windows.Forms.NumericUpDown numericUpDown32 = this.numericUpDown_InterdictNumberOfMonks;
			int[] array32 = new int[4];
			array32[0] = 8;
			numericUpDown32.Maximum = new decimal(array32);
			global::System.Windows.Forms.NumericUpDown numericUpDown33 = this.numericUpDown_InterdictNumberOfMonks;
			int[] array33 = new int[4];
			array33[0] = 1;
			numericUpDown33.Minimum = new decimal(array33);
			this.numericUpDown_InterdictNumberOfMonks.Name = "numericUpDown_InterdictNumberOfMonks";
			this.numericUpDown_InterdictNumberOfMonks.Size = new global::System.Drawing.Size(65, 20);
			this.numericUpDown_InterdictNumberOfMonks.TabIndex = 3;
			global::System.Windows.Forms.NumericUpDown numericUpDown34 = this.numericUpDown_InterdictNumberOfMonks;
			int[] array34 = new int[4];
			array34[0] = 2;
			numericUpDown34.Value = new decimal(array34);
			this.label_InterdictNumberOfMonks.AutoSize = true;
			this.label_InterdictNumberOfMonks.Location = new global::System.Drawing.Point(224, 51);
			this.label_InterdictNumberOfMonks.Name = "label_InterdictNumberOfMonks";
			this.label_InterdictNumberOfMonks.Size = new global::System.Drawing.Size(96, 13);
			this.label_InterdictNumberOfMonks.TabIndex = 2;
			this.label_InterdictNumberOfMonks.Text = "Number Of Monks:";
			this.button_Interdict.Location = new global::System.Drawing.Point(326, 121);
			this.button_Interdict.Name = "button_Interdict";
			this.button_Interdict.Size = new global::System.Drawing.Size(75, 23);
			this.button_Interdict.TabIndex = 1;
			this.button_Interdict.Text = "Interdict";
			this.button_Interdict.UseVisualStyleBackColor = true;
			this.button_Interdict.Click += new global::System.EventHandler(this.button_Interdict_Click);
			this.listBox_Interdict.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.listBox_Interdict.FormattingEnabled = true;
			this.listBox_Interdict.Location = new global::System.Drawing.Point(3, 3);
			this.listBox_Interdict.Name = "listBox_Interdict";
			this.listBox_Interdict.SelectionMode = global::System.Windows.Forms.SelectionMode.MultiSimple;
			this.listBox_Interdict.Size = new global::System.Drawing.Size(215, 268);
			this.listBox_Interdict.TabIndex = 0;
			this.tabPage_RadarEmail.Controls.Add(this.label_RadarEmailStatus);
			this.tabPage_RadarEmail.Controls.Add(this.checkBox_RadarUseDefault);
			this.tabPage_RadarEmail.Controls.Add(this.label_RadarLastEmailStatus);
			this.tabPage_RadarEmail.Controls.Add(this.textBox_ToEmail);
			this.tabPage_RadarEmail.Controls.Add(this.textBox_FromEmailPass);
			this.tabPage_RadarEmail.Controls.Add(this.label_ToEmail);
			this.tabPage_RadarEmail.Controls.Add(this.label_FromEmail);
			this.tabPage_RadarEmail.Controls.Add(this.label_FromEmailPass);
			this.tabPage_RadarEmail.Controls.Add(this.textBox_FromEmail);
			this.tabPage_RadarEmail.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage_RadarEmail.Name = "tabPage_RadarEmail";
			this.tabPage_RadarEmail.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage_RadarEmail.Size = new global::System.Drawing.Size(548, 274);
			this.tabPage_RadarEmail.TabIndex = 1;
			this.tabPage_RadarEmail.Text = "Email Settings";
			this.tabPage_RadarEmail.UseVisualStyleBackColor = true;
			this.label_RadarEmailStatus.AutoSize = true;
			this.label_RadarEmailStatus.Location = new global::System.Drawing.Point(107, 104);
			this.label_RadarEmailStatus.Name = "label_RadarEmailStatus";
			this.label_RadarEmailStatus.Size = new global::System.Drawing.Size(143, 13);
			this.label_RadarEmailStatus.TabIndex = 30;
			this.label_RadarEmailStatus.Text = "No Emails were sent recently";
			this.checkBox_RadarUseDefault.AutoSize = true;
			this.checkBox_RadarUseDefault.Location = new global::System.Drawing.Point(7, 6);
			this.checkBox_RadarUseDefault.Name = "checkBox_RadarUseDefault";
			this.checkBox_RadarUseDefault.Size = new global::System.Drawing.Size(119, 17);
			this.checkBox_RadarUseDefault.TabIndex = 28;
			this.checkBox_RadarUseDefault.Text = "Use default settings";
			this.checkBox_RadarUseDefault.UseVisualStyleBackColor = true;
			this.checkBox_RadarUseDefault.CheckedChanged += new global::System.EventHandler(this.checkBox_RadarUseDefault_CheckedChanged);
			this.label_RadarLastEmailStatus.AutoSize = true;
			this.label_RadarLastEmailStatus.Location = new global::System.Drawing.Point(4, 104);
			this.label_RadarLastEmailStatus.Name = "label_RadarLastEmailStatus";
			this.label_RadarLastEmailStatus.Size = new global::System.Drawing.Size(88, 13);
			this.label_RadarLastEmailStatus.TabIndex = 29;
			this.label_RadarLastEmailStatus.Text = "Last Email Status";
			this.textBox_ToEmail.Location = new global::System.Drawing.Point(110, 77);
			this.textBox_ToEmail.Name = "textBox_ToEmail";
			this.textBox_ToEmail.Size = new global::System.Drawing.Size(120, 20);
			this.textBox_ToEmail.TabIndex = 23;
			this.textBox_ToEmail.TextChanged += new global::System.EventHandler(this.textBox_ToEmail_TextChanged);
			this.textBox_FromEmailPass.Location = new global::System.Drawing.Point(110, 51);
			this.textBox_FromEmailPass.Name = "textBox_FromEmailPass";
			this.textBox_FromEmailPass.Size = new global::System.Drawing.Size(120, 20);
			this.textBox_FromEmailPass.TabIndex = 22;
			this.textBox_FromEmailPass.TextChanged += new global::System.EventHandler(this.textBox_FromEmailPass_TextChanged);
			this.label_ToEmail.AutoSize = true;
			this.label_ToEmail.Location = new global::System.Drawing.Point(4, 80);
			this.label_ToEmail.Name = "label_ToEmail";
			this.label_ToEmail.Size = new global::System.Drawing.Size(48, 13);
			this.label_ToEmail.TabIndex = 27;
			this.label_ToEmail.Text = "To Email";
			this.label_FromEmail.AutoSize = true;
			this.label_FromEmail.Location = new global::System.Drawing.Point(4, 28);
			this.label_FromEmail.Name = "label_FromEmail";
			this.label_FromEmail.Size = new global::System.Drawing.Size(58, 13);
			this.label_FromEmail.TabIndex = 25;
			this.label_FromEmail.Text = "From Email";
			this.label_FromEmailPass.AutoSize = true;
			this.label_FromEmailPass.Location = new global::System.Drawing.Point(4, 54);
			this.label_FromEmailPass.Name = "label_FromEmailPass";
			this.label_FromEmailPass.Size = new global::System.Drawing.Size(79, 13);
			this.label_FromEmailPass.TabIndex = 26;
			this.label_FromEmailPass.Text = "From Password";
			this.textBox_FromEmail.Location = new global::System.Drawing.Point(110, 25);
			this.textBox_FromEmail.Name = "textBox_FromEmail";
			this.textBox_FromEmail.Size = new global::System.Drawing.Size(120, 20);
			this.textBox_FromEmail.TabIndex = 21;
			this.textBox_FromEmail.TextChanged += new global::System.EventHandler(this.textBox_FromEmail_TextChanged);
			this.tabPage_RadarDiscord.Controls.Add(this.textBox_DiscordWebhook);
			this.tabPage_RadarDiscord.Controls.Add(this.label_DiscordWebhook);
			this.tabPage_RadarDiscord.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage_RadarDiscord.Name = "tabPage_RadarDiscord";
			this.tabPage_RadarDiscord.Size = new global::System.Drawing.Size(548, 274);
			this.tabPage_RadarDiscord.TabIndex = 2;
			this.tabPage_RadarDiscord.Text = "Discord";
			this.tabPage_RadarDiscord.UseVisualStyleBackColor = true;
			this.textBox_DiscordWebhook.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.textBox_DiscordWebhook.Location = new global::System.Drawing.Point(2, 28);
			this.textBox_DiscordWebhook.Multiline = true;
			this.textBox_DiscordWebhook.Name = "textBox_DiscordWebhook";
			this.textBox_DiscordWebhook.Size = new global::System.Drawing.Size(546, 46);
			this.textBox_DiscordWebhook.TabIndex = 1;
			this.textBox_DiscordWebhook.TextChanged += new global::System.EventHandler(this.textBox_DiscordWebhook_TextChanged);
			this.label_DiscordWebhook.AutoSize = true;
			this.label_DiscordWebhook.Location = new global::System.Drawing.Point(7, 12);
			this.label_DiscordWebhook.Name = "label_DiscordWebhook";
			this.label_DiscordWebhook.Size = new global::System.Drawing.Size(54, 13);
			this.label_DiscordWebhook.TabIndex = 0;
			this.label_DiscordWebhook.Text = "Webhook";
			this.tabPage_RadarTelegram.Controls.Add(this.groupBox_TelegramProxy);
			this.tabPage_RadarTelegram.Controls.Add(this.label_TeleTip3);
			this.tabPage_RadarTelegram.Controls.Add(this.label_TeleTip2);
			this.tabPage_RadarTelegram.Controls.Add(this.label_TeleTip1);
			this.tabPage_RadarTelegram.Controls.Add(this.textBox_TelegramChatID);
			this.tabPage_RadarTelegram.Controls.Add(this.label_TelegramChatID);
			this.tabPage_RadarTelegram.Controls.Add(this.textBox_TelegramBotToken);
			this.tabPage_RadarTelegram.Controls.Add(this.label_TelegramBotToken);
			this.tabPage_RadarTelegram.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage_RadarTelegram.Name = "tabPage_RadarTelegram";
			this.tabPage_RadarTelegram.Size = new global::System.Drawing.Size(548, 274);
			this.tabPage_RadarTelegram.TabIndex = 4;
			this.tabPage_RadarTelegram.Text = "Telegram";
			this.tabPage_RadarTelegram.UseVisualStyleBackColor = true;
			this.groupBox_TelegramProxy.Controls.Add(this.checkBox_ProxyUseCredential);
			this.groupBox_TelegramProxy.Controls.Add(this.label_ProxyPassword);
			this.groupBox_TelegramProxy.Controls.Add(this.label_ProxyLogin);
			this.groupBox_TelegramProxy.Controls.Add(this.label_ProxyPort);
			this.groupBox_TelegramProxy.Controls.Add(this.label_ProxyAddress);
			this.groupBox_TelegramProxy.Controls.Add(this.textBox_ProxyPassword);
			this.groupBox_TelegramProxy.Controls.Add(this.checkBox_TelegramUseProxy);
			this.groupBox_TelegramProxy.Controls.Add(this.textBox_ProxyAddress);
			this.groupBox_TelegramProxy.Controls.Add(this.textBox_ProxyPort);
			this.groupBox_TelegramProxy.Controls.Add(this.textBox_ProxyUsername);
			this.groupBox_TelegramProxy.Location = new global::System.Drawing.Point(7, 185);
			this.groupBox_TelegramProxy.Name = "groupBox_TelegramProxy";
			this.groupBox_TelegramProxy.Size = new global::System.Drawing.Size(405, 86);
			this.groupBox_TelegramProxy.TabIndex = 14;
			this.groupBox_TelegramProxy.TabStop = false;
			this.groupBox_TelegramProxy.Text = "Proxy Settings";
			this.checkBox_ProxyUseCredential.AutoSize = true;
			this.checkBox_ProxyUseCredential.Location = new global::System.Drawing.Point(194, 13);
			this.checkBox_ProxyUseCredential.Name = "checkBox_ProxyUseCredential";
			this.checkBox_ProxyUseCredential.Size = new global::System.Drawing.Size(152, 17);
			this.checkBox_ProxyUseCredential.TabIndex = 18;
			this.checkBox_ProxyUseCredential.Text = "Use credentials (if needed)";
			this.checkBox_ProxyUseCredential.UseVisualStyleBackColor = true;
			this.checkBox_ProxyUseCredential.CheckedChanged += new global::System.EventHandler(this.checkBox_ProxyUseCredential_CheckedChanged);
			this.label_ProxyPassword.AutoSize = true;
			this.label_ProxyPassword.Location = new global::System.Drawing.Point(191, 65);
			this.label_ProxyPassword.Name = "label_ProxyPassword";
			this.label_ProxyPassword.Size = new global::System.Drawing.Size(53, 13);
			this.label_ProxyPassword.TabIndex = 17;
			this.label_ProxyPassword.Text = "Password";
			this.label_ProxyLogin.AutoSize = true;
			this.label_ProxyLogin.Location = new global::System.Drawing.Point(191, 39);
			this.label_ProxyLogin.Name = "label_ProxyLogin";
			this.label_ProxyLogin.Size = new global::System.Drawing.Size(33, 13);
			this.label_ProxyLogin.TabIndex = 16;
			this.label_ProxyLogin.Text = "Login";
			this.label_ProxyPort.AutoSize = true;
			this.label_ProxyPort.Location = new global::System.Drawing.Point(9, 65);
			this.label_ProxyPort.Name = "label_ProxyPort";
			this.label_ProxyPort.Size = new global::System.Drawing.Size(26, 13);
			this.label_ProxyPort.TabIndex = 15;
			this.label_ProxyPort.Text = "Port";
			this.label_ProxyAddress.AutoSize = true;
			this.label_ProxyAddress.Location = new global::System.Drawing.Point(9, 39);
			this.label_ProxyAddress.Name = "label_ProxyAddress";
			this.label_ProxyAddress.Size = new global::System.Drawing.Size(45, 13);
			this.label_ProxyAddress.TabIndex = 14;
			this.label_ProxyAddress.Text = "Address";
			this.textBox_ProxyPassword.Location = new global::System.Drawing.Point(265, 62);
			this.textBox_ProxyPassword.Name = "textBox_ProxyPassword";
			this.textBox_ProxyPassword.Size = new global::System.Drawing.Size(100, 20);
			this.textBox_ProxyPassword.TabIndex = 12;
			this.textBox_ProxyPassword.TextChanged += new global::System.EventHandler(this.textBox_ProxyPassword_TextChanged);
			this.checkBox_TelegramUseProxy.AutoSize = true;
			this.checkBox_TelegramUseProxy.Location = new global::System.Drawing.Point(6, 13);
			this.checkBox_TelegramUseProxy.Name = "checkBox_TelegramUseProxy";
			this.checkBox_TelegramUseProxy.Size = new global::System.Drawing.Size(73, 17);
			this.checkBox_TelegramUseProxy.TabIndex = 13;
			this.checkBox_TelegramUseProxy.Text = "Use proxy";
			this.checkBox_TelegramUseProxy.UseVisualStyleBackColor = true;
			this.checkBox_TelegramUseProxy.CheckedChanged += new global::System.EventHandler(this.checkBox_TelegramUseProxy_CheckedChanged);
			this.textBox_ProxyAddress.Location = new global::System.Drawing.Point(85, 36);
			this.textBox_ProxyAddress.Name = "textBox_ProxyAddress";
			this.textBox_ProxyAddress.Size = new global::System.Drawing.Size(100, 20);
			this.textBox_ProxyAddress.TabIndex = 9;
			this.textBox_ProxyAddress.Text = "11.22.33.44";
			this.textBox_ProxyAddress.TextChanged += new global::System.EventHandler(this.textBox_ProxyAddress_TextChanged);
			this.textBox_ProxyPort.Location = new global::System.Drawing.Point(85, 62);
			this.textBox_ProxyPort.Name = "textBox_ProxyPort";
			this.textBox_ProxyPort.Size = new global::System.Drawing.Size(100, 20);
			this.textBox_ProxyPort.TabIndex = 10;
			this.textBox_ProxyPort.Text = "80";
			this.textBox_ProxyPort.TextChanged += new global::System.EventHandler(this.textBox_ProxyPort_TextChanged);
			this.textBox_ProxyUsername.Location = new global::System.Drawing.Point(265, 36);
			this.textBox_ProxyUsername.Name = "textBox_ProxyUsername";
			this.textBox_ProxyUsername.Size = new global::System.Drawing.Size(100, 20);
			this.textBox_ProxyUsername.TabIndex = 11;
			this.textBox_ProxyUsername.TextChanged += new global::System.EventHandler(this.textBox_ProxyUsername_TextChanged);
			this.label_TeleTip3.AutoSize = true;
			this.label_TeleTip3.Location = new global::System.Drawing.Point(4, 164);
			this.label_TeleTip3.Name = "label_TeleTip3";
			this.label_TeleTip3.Size = new global::System.Drawing.Size(360, 13);
			this.label_TeleTip3.TabIndex = 8;
			this.label_TeleTip3.Text = "Tip: One same Telegram Bot and one same Chat can be used by everyone";
			this.label_TeleTip2.AutoSize = true;
			this.label_TeleTip2.Location = new global::System.Drawing.Point(4, 136);
			this.label_TeleTip2.Name = "label_TeleTip2";
			this.label_TeleTip2.Size = new global::System.Drawing.Size(304, 13);
			this.label_TeleTip2.TabIndex = 7;
			this.label_TeleTip2.Text = "Tip: Invite @get_id_bot and use command /my_id@get_id_bot";
			this.label_TeleTip1.AutoSize = true;
			this.label_TeleTip1.Location = new global::System.Drawing.Point(3, 50);
			this.label_TeleTip1.Name = "label_TeleTip1";
			this.label_TeleTip1.Size = new global::System.Drawing.Size(189, 13);
			this.label_TeleTip1.TabIndex = 6;
			this.label_TeleTip1.Text = "Tip: Create your Bot using @BotFather";
			this.textBox_TelegramChatID.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.textBox_TelegramChatID.Location = new global::System.Drawing.Point(4, 112);
			this.textBox_TelegramChatID.Name = "textBox_TelegramChatID";
			this.textBox_TelegramChatID.Size = new global::System.Drawing.Size(540, 20);
			this.textBox_TelegramChatID.TabIndex = 3;
			this.textBox_TelegramChatID.TextChanged += new global::System.EventHandler(this.textBox_TelegramChatID_TextChanged);
			this.label_TelegramChatID.AutoSize = true;
			this.label_TelegramChatID.Location = new global::System.Drawing.Point(4, 96);
			this.label_TelegramChatID.Name = "label_TelegramChatID";
			this.label_TelegramChatID.Size = new global::System.Drawing.Size(43, 13);
			this.label_TelegramChatID.TabIndex = 2;
			this.label_TelegramChatID.Text = "Chat ID";
			this.textBox_TelegramBotToken.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.textBox_TelegramBotToken.Location = new global::System.Drawing.Point(3, 27);
			this.textBox_TelegramBotToken.Name = "textBox_TelegramBotToken";
			this.textBox_TelegramBotToken.Size = new global::System.Drawing.Size(541, 20);
			this.textBox_TelegramBotToken.TabIndex = 1;
			this.textBox_TelegramBotToken.TextChanged += new global::System.EventHandler(this.textBox_TelegramBotToken_TextChanged);
			this.label_TelegramBotToken.AutoSize = true;
			this.label_TelegramBotToken.Location = new global::System.Drawing.Point(4, 11);
			this.label_TelegramBotToken.Name = "label_TelegramBotToken";
			this.label_TelegramBotToken.Size = new global::System.Drawing.Size(57, 13);
			this.label_TelegramBotToken.TabIndex = 0;
			this.label_TelegramBotToken.Text = "Bot Token";
			this.tabPage_RadarTest.Controls.Add(this.button_RadarTestTray);
			this.tabPage_RadarTest.Controls.Add(this.button_RadarTestTelegram);
			this.tabPage_RadarTest.Controls.Add(this.button_RadarTestDiscord);
			this.tabPage_RadarTest.Controls.Add(this.button_testID);
			this.tabPage_RadarTest.Controls.Add(this.button_TestPopup);
			this.tabPage_RadarTest.Controls.Add(this.button_TestMail);
			this.tabPage_RadarTest.Controls.Add(this.button_RadarTestSound);
			this.tabPage_RadarTest.Controls.Add(this.comboBox_testInderdict);
			this.tabPage_RadarTest.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage_RadarTest.Name = "tabPage_RadarTest";
			this.tabPage_RadarTest.Size = new global::System.Drawing.Size(548, 274);
			this.tabPage_RadarTest.TabIndex = 3;
			this.tabPage_RadarTest.Text = "Test";
			this.tabPage_RadarTest.UseVisualStyleBackColor = true;
			this.button_RadarTestTray.Location = new global::System.Drawing.Point(166, 122);
			this.button_RadarTestTray.Name = "button_RadarTestTray";
			this.button_RadarTestTray.Size = new global::System.Drawing.Size(136, 23);
			this.button_RadarTestTray.TabIndex = 37;
			this.button_RadarTestTray.Text = "System Notification";
			this.button_RadarTestTray.UseVisualStyleBackColor = true;
			this.button_RadarTestTray.Click += new global::System.EventHandler(this.button_RadarTestTray_Click);
			this.button_RadarTestTelegram.Location = new global::System.Drawing.Point(166, 180);
			this.button_RadarTestTelegram.Name = "button_RadarTestTelegram";
			this.button_RadarTestTelegram.Size = new global::System.Drawing.Size(136, 23);
			this.button_RadarTestTelegram.TabIndex = 36;
			this.button_RadarTestTelegram.Text = "Telegram";
			this.button_RadarTestTelegram.UseVisualStyleBackColor = true;
			this.button_RadarTestTelegram.Click += new global::System.EventHandler(this.button_RadarTestTelegram_Click);
			this.button_RadarTestDiscord.Location = new global::System.Drawing.Point(166, 151);
			this.button_RadarTestDiscord.Name = "button_RadarTestDiscord";
			this.button_RadarTestDiscord.Size = new global::System.Drawing.Size(136, 23);
			this.button_RadarTestDiscord.TabIndex = 35;
			this.button_RadarTestDiscord.Text = "Discord";
			this.button_RadarTestDiscord.UseVisualStyleBackColor = true;
			this.button_RadarTestDiscord.Click += new global::System.EventHandler(this.button_RadarTestDiscord_Click);
			this.button_testID.Location = new global::System.Drawing.Point(166, 93);
			this.button_testID.Name = "button_testID";
			this.button_testID.Size = new global::System.Drawing.Size(136, 23);
			this.button_testID.TabIndex = 19;
			this.button_testID.Text = "Test Interdiction";
			this.button_testID.UseVisualStyleBackColor = true;
			this.button_testID.Click += new global::System.EventHandler(this.button_testID_Click);
			this.button_TestPopup.Location = new global::System.Drawing.Point(166, 6);
			this.button_TestPopup.Name = "button_TestPopup";
			this.button_TestPopup.Size = new global::System.Drawing.Size(136, 23);
			this.button_TestPopup.TabIndex = 34;
			this.button_TestPopup.Text = "Popup Message";
			this.button_TestPopup.UseVisualStyleBackColor = true;
			this.button_TestPopup.Click += new global::System.EventHandler(this.button_TestPopup_Click);
			this.button_TestMail.Location = new global::System.Drawing.Point(166, 64);
			this.button_TestMail.Name = "button_TestMail";
			this.button_TestMail.Size = new global::System.Drawing.Size(136, 23);
			this.button_TestMail.TabIndex = 18;
			this.button_TestMail.Text = "Send Email";
			this.button_TestMail.UseVisualStyleBackColor = true;
			this.button_TestMail.Click += new global::System.EventHandler(this.button_TestMail_Click);
			this.button_RadarTestSound.Location = new global::System.Drawing.Point(166, 35);
			this.button_RadarTestSound.Name = "button_RadarTestSound";
			this.button_RadarTestSound.Size = new global::System.Drawing.Size(136, 23);
			this.button_RadarTestSound.TabIndex = 32;
			this.button_RadarTestSound.Text = "Play Sound";
			this.button_RadarTestSound.UseVisualStyleBackColor = true;
			this.button_RadarTestSound.Click += new global::System.EventHandler(this.button_RadarTestSound_Click);
			this.comboBox_testInderdict.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_testInderdict.FormattingEnabled = true;
			this.comboBox_testInderdict.Location = new global::System.Drawing.Point(9, 94);
			this.comboBox_testInderdict.Name = "comboBox_testInderdict";
			this.comboBox_testInderdict.Size = new global::System.Drawing.Size(151, 21);
			this.comboBox_testInderdict.TabIndex = 33;
			this.tabPage_AltAccounts.Controls.Add(this.label_RadarAltToolTip);
			this.tabPage_AltAccounts.Controls.Add(this.button_FindByUsername);
			this.tabPage_AltAccounts.Controls.Add(this.textBox_RadarFindByUsername);
			this.tabPage_AltAccounts.Controls.Add(this.button_RadarResetAlt);
			this.tabPage_AltAccounts.Controls.Add(this.button_RadarFindByID);
			this.tabPage_AltAccounts.Controls.Add(this.numericUpDown_RadarFindByID);
			this.tabPage_AltAccounts.Controls.Add(this.label_RadarAltAccounts);
			this.tabPage_AltAccounts.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage_AltAccounts.Name = "tabPage_AltAccounts";
			this.tabPage_AltAccounts.Size = new global::System.Drawing.Size(548, 274);
			this.tabPage_AltAccounts.TabIndex = 5;
			this.tabPage_AltAccounts.Text = "Alt accounts";
			this.tabPage_AltAccounts.UseVisualStyleBackColor = true;
			this.label_RadarAltToolTip.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.label_RadarAltToolTip.Location = new global::System.Drawing.Point(17, 34);
			this.label_RadarAltToolTip.Name = "label_RadarAltToolTip";
			this.label_RadarAltToolTip.Size = new global::System.Drawing.Size(265, 33);
			this.label_RadarAltToolTip.TabIndex = 6;
			this.label_RadarAltToolTip.Text = "Warning! If alt monitoring is set up, the main account will NOT be monitored!";
			this.button_FindByUsername.Location = new global::System.Drawing.Point(122, 72);
			this.button_FindByUsername.Name = "button_FindByUsername";
			this.button_FindByUsername.Size = new global::System.Drawing.Size(160, 23);
			this.button_FindByUsername.TabIndex = 5;
			this.button_FindByUsername.Text = "Find Player By Username";
			this.button_FindByUsername.UseVisualStyleBackColor = true;
			this.button_FindByUsername.Click += new global::System.EventHandler(this.button_FindByUsername_Click);
			this.textBox_RadarFindByUsername.Location = new global::System.Drawing.Point(20, 73);
			this.textBox_RadarFindByUsername.Name = "textBox_RadarFindByUsername";
			this.textBox_RadarFindByUsername.Size = new global::System.Drawing.Size(100, 20);
			this.textBox_RadarFindByUsername.TabIndex = 4;
			this.button_RadarResetAlt.Location = new global::System.Drawing.Point(122, 126);
			this.button_RadarResetAlt.Name = "button_RadarResetAlt";
			this.button_RadarResetAlt.Size = new global::System.Drawing.Size(160, 23);
			this.button_RadarResetAlt.TabIndex = 3;
			this.button_RadarResetAlt.Text = "Reset to Default";
			this.button_RadarResetAlt.UseVisualStyleBackColor = true;
			this.button_RadarResetAlt.Click += new global::System.EventHandler(this.button_RadarResetAlt_Click);
			this.button_RadarFindByID.Location = new global::System.Drawing.Point(122, 98);
			this.button_RadarFindByID.Name = "button_RadarFindByID";
			this.button_RadarFindByID.Size = new global::System.Drawing.Size(160, 23);
			this.button_RadarFindByID.TabIndex = 2;
			this.button_RadarFindByID.Text = "Find Player By Village ID";
			this.button_RadarFindByID.UseVisualStyleBackColor = true;
			this.button_RadarFindByID.Click += new global::System.EventHandler(this.button_RadarFindByID_Click);
			this.numericUpDown_RadarFindByID.InterceptArrowKeys = false;
			this.numericUpDown_RadarFindByID.Location = new global::System.Drawing.Point(20, 99);
			global::System.Windows.Forms.NumericUpDown numericUpDown35 = this.numericUpDown_RadarFindByID;
			int[] array35 = new int[4];
			array35[0] = 1000000;
			numericUpDown35.Maximum = new decimal(array35);
			this.numericUpDown_RadarFindByID.Name = "numericUpDown_RadarFindByID";
			this.numericUpDown_RadarFindByID.Size = new global::System.Drawing.Size(100, 20);
			this.numericUpDown_RadarFindByID.TabIndex = 1;
			this.label_RadarAltAccounts.AutoSize = true;
			this.label_RadarAltAccounts.Location = new global::System.Drawing.Point(17, 19);
			this.label_RadarAltAccounts.Name = "label_RadarAltAccounts";
			this.label_RadarAltAccounts.Size = new global::System.Drawing.Size(124, 13);
			this.label_RadarAltAccounts.TabIndex = 0;
			this.label_RadarAltAccounts.Text = "Radar works for account";
			this.tabPage_RadarAutoID.Controls.Add(this.label_AutoIDExtraDelay);
			this.tabPage_RadarAutoID.Controls.Add(this.label_AutoID);
			this.tabPage_RadarAutoID.Controls.Add(this.numericUpDown_RadarAutoID);
			this.tabPage_RadarAutoID.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage_RadarAutoID.Name = "tabPage_RadarAutoID";
			this.tabPage_RadarAutoID.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage_RadarAutoID.Size = new global::System.Drawing.Size(548, 274);
			this.tabPage_RadarAutoID.TabIndex = 22;
			this.tabPage_RadarAutoID.Text = "Auto-Interdiction";
			this.tabPage_RadarAutoID.UseVisualStyleBackColor = true;
			this.label_AutoIDExtraDelay.AutoSize = true;
			this.label_AutoIDExtraDelay.Location = new global::System.Drawing.Point(6, 8);
			this.label_AutoIDExtraDelay.Name = "label_AutoIDExtraDelay";
			this.label_AutoIDExtraDelay.Size = new global::System.Drawing.Size(196, 13);
			this.label_AutoIDExtraDelay.TabIndex = 2;
			this.label_AutoIDExtraDelay.Text = "Extra delay before automatic Interdiction";
			this.label_AutoID.AutoSize = true;
			this.label_AutoID.Location = new global::System.Drawing.Point(16, 38);
			this.label_AutoID.Name = "label_AutoID";
			this.label_AutoID.Size = new global::System.Drawing.Size(0, 13);
			this.label_AutoID.TabIndex = 1;
			this.numericUpDown_RadarAutoID.Location = new global::System.Drawing.Point(312, 6);
			this.numericUpDown_RadarAutoID.Name = "numericUpDown_RadarAutoID";
			this.numericUpDown_RadarAutoID.Size = new global::System.Drawing.Size(120, 20);
			this.numericUpDown_RadarAutoID.TabIndex = 0;
			this.numericUpDown_RadarAutoID.ValueChanged += new global::System.EventHandler(this.numericUpDown_RadarAutoID_ValueChanged);
			this.checkBox_RadarRehireMonks.AutoSize = true;
			this.checkBox_RadarRehireMonks.Location = new global::System.Drawing.Point(250, 32);
			this.checkBox_RadarRehireMonks.Name = "checkBox_RadarRehireMonks";
			this.checkBox_RadarRehireMonks.Size = new global::System.Drawing.Size(102, 17);
			this.checkBox_RadarRehireMonks.TabIndex = 37;
			this.checkBox_RadarRehireMonks.Text = "Auto-hire monks";
			this.checkBox_RadarRehireMonks.UseVisualStyleBackColor = true;
			this.checkBox_RadarRehireMonks.CheckedChanged += new global::System.EventHandler(this.checkBox_RadarRehireMonks_CheckedChanged);
			this.button_RadarHelp.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.button_RadarHelp.Location = new global::System.Drawing.Point(231, 3);
			this.button_RadarHelp.Name = "button_RadarHelp";
			this.button_RadarHelp.Size = new global::System.Drawing.Size(75, 23);
			this.button_RadarHelp.TabIndex = 36;
			this.button_RadarHelp.Text = "Help";
			this.button_RadarHelp.UseVisualStyleBackColor = true;
			this.button_RadarHelp.Click += new global::System.EventHandler(this.button_RadarHelp_Click);
			this.button_CloseAllMessages.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.button_CloseAllMessages.Location = new global::System.Drawing.Point(312, 3);
			this.button_CloseAllMessages.Name = "button_CloseAllMessages";
			this.button_CloseAllMessages.Size = new global::System.Drawing.Size(119, 23);
			this.button_CloseAllMessages.TabIndex = 35;
			this.button_CloseAllMessages.Text = "Close All Messages";
			this.button_CloseAllMessages.UseVisualStyleBackColor = true;
			this.button_CloseAllMessages.Click += new global::System.EventHandler(this.button_CloseAllMessages_Click);
			this.button_RadarGridLoad.Location = new global::System.Drawing.Point(126, 32);
			this.button_RadarGridLoad.Name = "button_RadarGridLoad";
			this.button_RadarGridLoad.Size = new global::System.Drawing.Size(116, 23);
			this.button_RadarGridLoad.TabIndex = 31;
			this.button_RadarGridLoad.Text = "Load";
			this.button_RadarGridLoad.UseVisualStyleBackColor = true;
			this.button_RadarGridLoad.Click += new global::System.EventHandler(this.button_RadarGridLoad_Click);
			this.button_RadarGridSave.Location = new global::System.Drawing.Point(0, 32);
			this.button_RadarGridSave.Name = "button_RadarGridSave";
			this.button_RadarGridSave.Size = new global::System.Drawing.Size(116, 23);
			this.button_RadarGridSave.TabIndex = 30;
			this.button_RadarGridSave.Text = "Save";
			this.button_RadarGridSave.UseVisualStyleBackColor = true;
			this.button_RadarGridSave.Click += new global::System.EventHandler(this.button_RadarGridSave_Click);
			this.button_StopSoundPlayer.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.button_StopSoundPlayer.Location = new global::System.Drawing.Point(437, 3);
			this.button_StopSoundPlayer.Name = "button_StopSoundPlayer";
			this.button_StopSoundPlayer.Size = new global::System.Drawing.Size(119, 23);
			this.button_StopSoundPlayer.TabIndex = 16;
			this.button_StopSoundPlayer.Text = "Stop Sound";
			this.toolTip1.SetToolTip(this.button_StopSoundPlayer, "CTRL+S");
			this.button_StopSoundPlayer.UseVisualStyleBackColor = true;
			this.button_StopSoundPlayer.Click += new global::System.EventHandler(this.button_StopSoundPlayer_Click);
			this.checkBox_Monitor.AutoSize = true;
			this.checkBox_Monitor.Location = new global::System.Drawing.Point(4, 3);
			this.checkBox_Monitor.Name = "checkBox_Monitor";
			this.checkBox_Monitor.Size = new global::System.Drawing.Size(61, 17);
			this.checkBox_Monitor.TabIndex = 6;
			this.checkBox_Monitor.Text = "Monitor";
			this.checkBox_Monitor.UseVisualStyleBackColor = true;
			this.checkBox_Monitor.CheckedChanged += new global::System.EventHandler(this.checkBox_Monitor_CheckedChanged);
			this.richTextBoxRadar.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.richTextBoxRadar.Location = new global::System.Drawing.Point(0, 363);
			this.richTextBoxRadar.Name = "richTextBoxRadar";
			this.richTextBoxRadar.ReadOnly = true;
			this.richTextBoxRadar.Size = new global::System.Drawing.Size(556, 278);
			this.richTextBoxRadar.TabIndex = 4;
			this.richTextBoxRadar.Text = "";
			this.tabPage_Troopsrecruiting.Controls.Add(this.button_RecruitingCopy);
			this.tabPage_Troopsrecruiting.Controls.Add(this.button_RecruitingHelp);
			this.tabPage_Troopsrecruiting.Controls.Add(this.tabControl_TroopsRecruiting);
			this.tabPage_Troopsrecruiting.Controls.Add(this.numericUpDown2);
			this.tabPage_Troopsrecruiting.Controls.Add(this.label21);
			this.tabPage_Troopsrecruiting.Controls.Add(this.checkBox_recruitingtroops);
			this.tabPage_Troopsrecruiting.Controls.Add(this.saveTroopsRecruiting);
			this.tabPage_Troopsrecruiting.Controls.Add(this.loadTroopsRecruiting);
			this.tabPage_Troopsrecruiting.Controls.Add(this.richTextBoxTroopsRecruiting);
			this.tabPage_Troopsrecruiting.Location = new global::System.Drawing.Point(4, 40);
			this.tabPage_Troopsrecruiting.Name = "tabPage_Troopsrecruiting";
			this.tabPage_Troopsrecruiting.Size = new global::System.Drawing.Size(556, 626);
			this.tabPage_Troopsrecruiting.TabIndex = 10;
			this.tabPage_Troopsrecruiting.Text = "Recruiting";
			this.tabPage_Troopsrecruiting.UseVisualStyleBackColor = true;
			this.button_RecruitingCopy.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.button_RecruitingCopy.Location = new global::System.Drawing.Point(279, 479);
			this.button_RecruitingCopy.Name = "button_RecruitingCopy";
			this.button_RecruitingCopy.Size = new global::System.Drawing.Size(132, 23);
			this.button_RecruitingCopy.TabIndex = 12;
			this.button_RecruitingCopy.Text = "Copy Settings";
			this.toolTip1.SetToolTip(this.button_RecruitingCopy, "CTRL+Shift+C");
			this.button_RecruitingCopy.UseVisualStyleBackColor = true;
			this.button_RecruitingCopy.Click += new global::System.EventHandler(this.button_CopySettings_Click);
			this.button_RecruitingHelp.Location = new global::System.Drawing.Point(438, 6);
			this.button_RecruitingHelp.Name = "button_RecruitingHelp";
			this.button_RecruitingHelp.Size = new global::System.Drawing.Size(115, 23);
			this.button_RecruitingHelp.TabIndex = 11;
			this.button_RecruitingHelp.Text = "Help";
			this.button_RecruitingHelp.UseVisualStyleBackColor = true;
			this.button_RecruitingHelp.Click += new global::System.EventHandler(this.button_RecruitingHelp_Click);
			this.tabControl_TroopsRecruiting.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.tabControl_TroopsRecruiting.Controls.Add(this.tabPage_VillagesTroopsRecruiting);
			this.tabControl_TroopsRecruiting.Controls.Add(this.tabPage_CapitalsTroopsRecruiting);
			this.tabControl_TroopsRecruiting.Controls.Add(this.tabPage_VassalsTroopsRecruiting);
			this.tabControl_TroopsRecruiting.Location = new global::System.Drawing.Point(0, 35);
			this.tabControl_TroopsRecruiting.Name = "tabControl_TroopsRecruiting";
			this.tabControl_TroopsRecruiting.SelectedIndex = 0;
			this.tabControl_TroopsRecruiting.Size = new global::System.Drawing.Size(553, 444);
			this.tabControl_TroopsRecruiting.TabIndex = 10;
			this.tabPage_VillagesTroopsRecruiting.Controls.Add(this.dataGridView_TroopsRecruiting);
			this.tabPage_VillagesTroopsRecruiting.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage_VillagesTroopsRecruiting.Name = "tabPage_VillagesTroopsRecruiting";
			this.tabPage_VillagesTroopsRecruiting.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage_VillagesTroopsRecruiting.Size = new global::System.Drawing.Size(545, 418);
			this.tabPage_VillagesTroopsRecruiting.TabIndex = 0;
			this.tabPage_VillagesTroopsRecruiting.Text = "Villages";
			this.tabPage_VillagesTroopsRecruiting.UseVisualStyleBackColor = true;
			this.dataGridView_TroopsRecruiting.AllowUserToAddRows = false;
			this.dataGridView_TroopsRecruiting.AllowUserToDeleteRows = false;
			this.dataGridView_TroopsRecruiting.AutoSizeColumnsMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataGridView_TroopsRecruiting.AutoSizeRowsMode = global::System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridView_TroopsRecruiting.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_TroopsRecruiting.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.Village,
				this.Recruit,
				this.Peasants,
				this.Archers,
				this.Pikemen,
				this.Swordsmen,
				this.Catapults,
				this.Captains
			});
			this.dataGridView_TroopsRecruiting.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.dataGridView_TroopsRecruiting.Location = new global::System.Drawing.Point(3, 3);
			this.dataGridView_TroopsRecruiting.Name = "dataGridView_TroopsRecruiting";
			this.dataGridView_TroopsRecruiting.RowHeadersVisible = false;
			this.dataGridView_TroopsRecruiting.Size = new global::System.Drawing.Size(539, 412);
			this.dataGridView_TroopsRecruiting.TabIndex = 1;
			this.dataGridView_TroopsRecruiting.Tag = "troops";
			this.Village.HeaderText = "Village";
			this.Village.Name = "Village";
			this.Village.ReadOnly = true;
			this.Village.Width = 63;
			this.Recruit.HeaderText = "Recruit";
			this.Recruit.Name = "Recruit";
			this.Recruit.Width = 47;
			this.Peasants.HeaderText = "Peasants";
			this.Peasants.Name = "Peasants";
			this.Peasants.Width = 76;
			this.Archers.HeaderText = "Archers";
			this.Archers.Name = "Archers";
			this.Archers.Width = 68;
			this.Pikemen.HeaderText = "Pikemen";
			this.Pikemen.Name = "Pikemen";
			this.Pikemen.Width = 73;
			this.Swordsmen.HeaderText = "Swordsmen";
			this.Swordsmen.Name = "Swordsmen";
			this.Swordsmen.Width = 87;
			this.Catapults.HeaderText = "Catapults";
			this.Catapults.Name = "Catapults";
			this.Catapults.Width = 76;
			this.Captains.HeaderText = "Captains";
			this.Captains.Name = "Captains";
			this.Captains.Visible = false;
			this.Captains.Width = 73;
			this.tabPage_CapitalsTroopsRecruiting.Controls.Add(this.dataGridView_CapitalsRecruiting);
			this.tabPage_CapitalsTroopsRecruiting.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage_CapitalsTroopsRecruiting.Name = "tabPage_CapitalsTroopsRecruiting";
			this.tabPage_CapitalsTroopsRecruiting.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage_CapitalsTroopsRecruiting.Size = new global::System.Drawing.Size(545, 418);
			this.tabPage_CapitalsTroopsRecruiting.TabIndex = 1;
			this.tabPage_CapitalsTroopsRecruiting.Text = "Capitals";
			this.tabPage_CapitalsTroopsRecruiting.UseVisualStyleBackColor = true;
			this.dataGridView_CapitalsRecruiting.AllowUserToAddRows = false;
			this.dataGridView_CapitalsRecruiting.AllowUserToDeleteRows = false;
			this.dataGridView_CapitalsRecruiting.AutoSizeColumnsMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataGridView_CapitalsRecruiting.AutoSizeRowsMode = global::System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridView_CapitalsRecruiting.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_CapitalsRecruiting.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn1,
				this.dataGridViewCheckBoxColumn1,
				this.dataGridViewTextBoxColumn2,
				this.dataGridViewTextBoxColumn3,
				this.dataGridViewTextBoxColumn4,
				this.dataGridViewTextBoxColumn5,
				this.dataGridViewTextBoxColumn6
			});
			this.dataGridView_CapitalsRecruiting.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.dataGridView_CapitalsRecruiting.Location = new global::System.Drawing.Point(3, 3);
			this.dataGridView_CapitalsRecruiting.Name = "dataGridView_CapitalsRecruiting";
			this.dataGridView_CapitalsRecruiting.RowHeadersVisible = false;
			this.dataGridView_CapitalsRecruiting.Size = new global::System.Drawing.Size(539, 412);
			this.dataGridView_CapitalsRecruiting.TabIndex = 2;
			this.dataGridView_CapitalsRecruiting.Tag = "troops";
			this.dataGridViewTextBoxColumn1.HeaderText = "Capital";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 64;
			this.dataGridViewCheckBoxColumn1.HeaderText = "Recruit";
			this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
			this.dataGridViewCheckBoxColumn1.Width = 47;
			this.dataGridViewTextBoxColumn2.HeaderText = "Peasants";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.Width = 76;
			this.dataGridViewTextBoxColumn3.HeaderText = "Archers";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.Width = 68;
			this.dataGridViewTextBoxColumn4.HeaderText = "Pikemen";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.Width = 73;
			this.dataGridViewTextBoxColumn5.HeaderText = "Swordsmen";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.Width = 87;
			this.dataGridViewTextBoxColumn6.HeaderText = "Catapults";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.Width = 76;
			this.tabPage_VassalsTroopsRecruiting.Controls.Add(this.button_VassalsCopy);
			this.tabPage_VassalsTroopsRecruiting.Controls.Add(this.numericUpDown_VassalTroopsMinimum);
			this.tabPage_VassalsTroopsRecruiting.Controls.Add(this.label_VassalTroopsMinimum);
			this.tabPage_VassalsTroopsRecruiting.Controls.Add(this.dataGridView_FillVassals);
			this.tabPage_VassalsTroopsRecruiting.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage_VassalsTroopsRecruiting.Name = "tabPage_VassalsTroopsRecruiting";
			this.tabPage_VassalsTroopsRecruiting.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage_VassalsTroopsRecruiting.Size = new global::System.Drawing.Size(545, 418);
			this.tabPage_VassalsTroopsRecruiting.TabIndex = 2;
			this.tabPage_VassalsTroopsRecruiting.Text = "Vassals";
			this.tabPage_VassalsTroopsRecruiting.UseVisualStyleBackColor = true;
			this.button_VassalsCopy.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.button_VassalsCopy.Location = new global::System.Drawing.Point(434, 2);
			this.button_VassalsCopy.Name = "button_VassalsCopy";
			this.button_VassalsCopy.Size = new global::System.Drawing.Size(108, 23);
			this.button_VassalsCopy.TabIndex = 5;
			this.button_VassalsCopy.Text = "Copy Settings";
			this.toolTip1.SetToolTip(this.button_VassalsCopy, "CTRL+Shift+C");
			this.button_VassalsCopy.UseVisualStyleBackColor = true;
			this.button_VassalsCopy.Click += new global::System.EventHandler(this.button_CopySettings_Click);
			this.numericUpDown_VassalTroopsMinimum.Location = new global::System.Drawing.Point(249, 5);
			global::System.Windows.Forms.NumericUpDown numericUpDown36 = this.numericUpDown_VassalTroopsMinimum;
			int[] array36 = new int[4];
			array36[0] = 500;
			numericUpDown36.Maximum = new decimal(array36);
			global::System.Windows.Forms.NumericUpDown numericUpDown37 = this.numericUpDown_VassalTroopsMinimum;
			int[] array37 = new int[4];
			array37[0] = 1;
			numericUpDown37.Minimum = new decimal(array37);
			this.numericUpDown_VassalTroopsMinimum.Name = "numericUpDown_VassalTroopsMinimum";
			this.numericUpDown_VassalTroopsMinimum.Size = new global::System.Drawing.Size(50, 20);
			this.numericUpDown_VassalTroopsMinimum.TabIndex = 4;
			this.numericUpDown_VassalTroopsMinimum.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			global::System.Windows.Forms.NumericUpDown numericUpDown38 = this.numericUpDown_VassalTroopsMinimum;
			int[] array38 = new int[4];
			array38[0] = 1;
			numericUpDown38.Value = new decimal(array38);
			this.numericUpDown_VassalTroopsMinimum.ValueChanged += new global::System.EventHandler(this.numericUpDown_VassalTroopsMinimum_ValueChanged);
			this.label_VassalTroopsMinimum.AutoSize = true;
			this.label_VassalTroopsMinimum.Location = new global::System.Drawing.Point(7, 7);
			this.label_VassalTroopsMinimum.Name = "label_VassalTroopsMinimum";
			this.label_VassalTroopsMinimum.Size = new global::System.Drawing.Size(193, 13);
			this.label_VassalTroopsMinimum.TabIndex = 3;
			this.label_VassalTroopsMinimum.Text = "Minimum troops sent to vassal at once: ";
			this.dataGridView_FillVassals.AllowUserToAddRows = false;
			this.dataGridView_FillVassals.AllowUserToDeleteRows = false;
			this.dataGridView_FillVassals.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.dataGridView_FillVassals.AutoSizeColumnsMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataGridView_FillVassals.AutoSizeRowsMode = global::System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridView_FillVassals.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_FillVassals.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn7,
				this.dataGridViewCheckBoxColumn2,
				this.dataGridViewTextBoxColumn8,
				this.dataGridViewTextBoxColumn9,
				this.dataGridViewTextBoxColumn10,
				this.dataGridViewTextBoxColumn11,
				this.dataGridViewTextBoxColumn12,
				this.dataGridViewTextBoxColumn13
			});
			this.dataGridView_FillVassals.Location = new global::System.Drawing.Point(3, 26);
			this.dataGridView_FillVassals.Name = "dataGridView_FillVassals";
			this.dataGridView_FillVassals.RowHeadersVisible = false;
			this.dataGridView_FillVassals.Size = new global::System.Drawing.Size(539, 389);
			this.dataGridView_FillVassals.TabIndex = 2;
			this.dataGridView_FillVassals.Tag = "troops";
			this.dataGridViewTextBoxColumn7.HeaderText = "Village";
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn7.ReadOnly = true;
			this.dataGridViewTextBoxColumn7.Width = 63;
			this.dataGridViewCheckBoxColumn2.HeaderText = "Fill";
			this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
			this.dataGridViewCheckBoxColumn2.Width = 25;
			this.dataGridViewTextBoxColumn8.HeaderText = "Peasants";
			this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn8.Width = 76;
			this.dataGridViewTextBoxColumn9.HeaderText = "Archers";
			this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn9.Width = 68;
			this.dataGridViewTextBoxColumn10.HeaderText = "Pikemen";
			this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
			this.dataGridViewTextBoxColumn10.Width = 73;
			this.dataGridViewTextBoxColumn11.HeaderText = "Swordsmen";
			this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
			this.dataGridViewTextBoxColumn11.Width = 87;
			this.dataGridViewTextBoxColumn12.HeaderText = "Catapults";
			this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
			this.dataGridViewTextBoxColumn12.Width = 76;
			this.dataGridViewTextBoxColumn13.HeaderText = "Captains";
			this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
			this.dataGridViewTextBoxColumn13.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn13.Visible = false;
			this.dataGridViewTextBoxColumn13.Width = 54;
			global::System.Windows.Forms.NumericUpDown numericUpDown39 = this.numericUpDown2;
			int[] array39 = new int[4];
			array39[0] = 5;
			numericUpDown39.Increment = new decimal(array39);
			this.numericUpDown2.Location = new global::System.Drawing.Point(383, 9);
			global::System.Windows.Forms.NumericUpDown numericUpDown40 = this.numericUpDown2;
			int[] array40 = new int[4];
			array40[0] = 1000;
			numericUpDown40.Maximum = new decimal(array40);
			global::System.Windows.Forms.NumericUpDown numericUpDown41 = this.numericUpDown2;
			int[] array41 = new int[4];
			array41[0] = 60;
			numericUpDown41.Minimum = new decimal(array41);
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new global::System.Drawing.Size(49, 20);
			this.numericUpDown2.TabIndex = 9;
			global::System.Windows.Forms.NumericUpDown numericUpDown42 = this.numericUpDown2;
			int[] array42 = new int[4];
			array42[0] = 60;
			numericUpDown42.Value = new decimal(array42);
			this.numericUpDown2.ValueChanged += new global::System.EventHandler(this.numericUpDown2_ValueChanged);
			this.label21.AutoSize = true;
			this.label21.Location = new global::System.Drawing.Point(202, 11);
			this.label21.Name = "label21";
			this.label21.Size = new global::System.Drawing.Size(130, 13);
			this.label21.TabIndex = 8;
			this.label21.Text = "Recruit interval (seconds):";
			this.checkBox_recruitingtroops.AutoSize = true;
			this.checkBox_recruitingtroops.Location = new global::System.Drawing.Point(9, 10);
			this.checkBox_recruitingtroops.Name = "checkBox_recruitingtroops";
			this.checkBox_recruitingtroops.Size = new global::System.Drawing.Size(106, 17);
			this.checkBox_recruitingtroops.TabIndex = 6;
			this.checkBox_recruitingtroops.Text = "Recruiting troops";
			this.checkBox_recruitingtroops.UseVisualStyleBackColor = true;
			this.checkBox_recruitingtroops.CheckedChanged += new global::System.EventHandler(this.checkBox_recruitingtroops_CheckedChanged);
			this.saveTroopsRecruiting.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.saveTroopsRecruiting.Location = new global::System.Drawing.Point(3, 479);
			this.saveTroopsRecruiting.Name = "saveTroopsRecruiting";
			this.saveTroopsRecruiting.Size = new global::System.Drawing.Size(132, 23);
			this.saveTroopsRecruiting.TabIndex = 5;
			this.saveTroopsRecruiting.Text = "Save";
			this.saveTroopsRecruiting.UseVisualStyleBackColor = true;
			this.saveTroopsRecruiting.Click += new global::System.EventHandler(this.saveTroopsRecruiting_Click);
			this.loadTroopsRecruiting.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.loadTroopsRecruiting.Location = new global::System.Drawing.Point(141, 479);
			this.loadTroopsRecruiting.Name = "loadTroopsRecruiting";
			this.loadTroopsRecruiting.Size = new global::System.Drawing.Size(132, 23);
			this.loadTroopsRecruiting.TabIndex = 4;
			this.loadTroopsRecruiting.Text = "Load";
			this.loadTroopsRecruiting.UseVisualStyleBackColor = true;
			this.loadTroopsRecruiting.Click += new global::System.EventHandler(this.loadTroopsRecruiting_Click);
			this.richTextBoxTroopsRecruiting.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.richTextBoxTroopsRecruiting.Location = new global::System.Drawing.Point(0, 508);
			this.richTextBoxTroopsRecruiting.Name = "richTextBoxTroopsRecruiting";
			this.richTextBoxTroopsRecruiting.ReadOnly = true;
			this.richTextBoxTroopsRecruiting.Size = new global::System.Drawing.Size(556, 118);
			this.richTextBoxTroopsRecruiting.TabIndex = 2;
			this.richTextBoxTroopsRecruiting.Text = "";
			this.tabPage_Spin.Controls.Add(this.numericUpDown_SpinInterval);
			this.tabPage_Spin.Controls.Add(this.richTextBoxSpins);
			this.tabPage_Spin.Controls.Add(this.label31);
			this.tabPage_Spin.Controls.Add(this.label25);
			this.tabPage_Spin.Controls.Add(this.checkBox_Spin);
			this.tabPage_Spin.Location = new global::System.Drawing.Point(4, 40);
			this.tabPage_Spin.Name = "tabPage_Spin";
			this.tabPage_Spin.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage_Spin.Size = new global::System.Drawing.Size(556, 626);
			this.tabPage_Spin.TabIndex = 13;
			this.tabPage_Spin.Text = "Spin";
			this.tabPage_Spin.UseVisualStyleBackColor = true;
			this.numericUpDown_SpinInterval.Location = new global::System.Drawing.Point(129, 53);
			global::System.Windows.Forms.NumericUpDown numericUpDown43 = this.numericUpDown_SpinInterval;
			int[] array43 = new int[4];
			array43[0] = 1;
			numericUpDown43.Minimum = new decimal(array43);
			this.numericUpDown_SpinInterval.Name = "numericUpDown_SpinInterval";
			this.numericUpDown_SpinInterval.Size = new global::System.Drawing.Size(48, 20);
			this.numericUpDown_SpinInterval.TabIndex = 5;
			global::System.Windows.Forms.NumericUpDown numericUpDown44 = this.numericUpDown_SpinInterval;
			int[] array44 = new int[4];
			array44[0] = 1;
			numericUpDown44.Value = new decimal(array44);
			this.numericUpDown_SpinInterval.ValueChanged += new global::System.EventHandler(this.numericUpDown_SpinInterval_ValueChanged);
			this.richTextBoxSpins.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.richTextBoxSpins.Location = new global::System.Drawing.Point(3, 120);
			this.richTextBoxSpins.Name = "richTextBoxSpins";
			this.richTextBoxSpins.ReadOnly = true;
			this.richTextBoxSpins.Size = new global::System.Drawing.Size(550, 503);
			this.richTextBoxSpins.TabIndex = 4;
			this.richTextBoxSpins.Text = "";
			this.label31.AutoSize = true;
			this.label31.Location = new global::System.Drawing.Point(7, 7);
			this.label31.Name = "label31";
			this.label31.Size = new global::System.Drawing.Size(363, 13);
			this.label31.TabIndex = 3;
			this.label31.Text = "First place the mouse over Spin button and press F6 to save it's coordinates";
			this.label31.Visible = false;
			this.label25.AutoSize = true;
			this.label25.Location = new global::System.Drawing.Point(4, 55);
			this.label25.Name = "label25";
			this.label25.Size = new global::System.Drawing.Size(87, 13);
			this.label25.TabIndex = 2;
			this.label25.Text = "Interval (minutes)";
			this.checkBox_Spin.AutoSize = true;
			this.checkBox_Spin.Location = new global::System.Drawing.Point(7, 31);
			this.checkBox_Spin.Name = "checkBox_Spin";
			this.checkBox_Spin.Size = new global::System.Drawing.Size(47, 17);
			this.checkBox_Spin.TabIndex = 0;
			this.checkBox_Spin.Text = "Spin";
			this.checkBox_Spin.UseVisualStyleBackColor = true;
			this.checkBox_Spin.CheckedChanged += new global::System.EventHandler(this.checkBox_Spin_CheckedChanged);
			this.tabPage_Banquet.Controls.Add(this.button_BanquetCopy);
			this.tabPage_Banquet.Controls.Add(this.button_BanquetLoad);
			this.tabPage_Banquet.Controls.Add(this.button_BanquetSave);
			this.tabPage_Banquet.Controls.Add(this.dataGridView_Banquets);
			this.tabPage_Banquet.Controls.Add(this.button_BanquetingHelp);
			this.tabPage_Banquet.Controls.Add(this.numeric_BanquetInterval);
			this.tabPage_Banquet.Controls.Add(this.richTextBoxBanquetting);
			this.tabPage_Banquet.Controls.Add(this.label7);
			this.tabPage_Banquet.Controls.Add(this.PlayBanquets);
			this.tabPage_Banquet.Location = new global::System.Drawing.Point(4, 40);
			this.tabPage_Banquet.Name = "tabPage_Banquet";
			this.tabPage_Banquet.Size = new global::System.Drawing.Size(556, 626);
			this.tabPage_Banquet.TabIndex = 8;
			this.tabPage_Banquet.Text = "Banquet";
			this.tabPage_Banquet.UseVisualStyleBackColor = true;
			this.button_BanquetCopy.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.button_BanquetCopy.Location = new global::System.Drawing.Point(281, 384);
			this.button_BanquetCopy.Name = "button_BanquetCopy";
			this.button_BanquetCopy.Size = new global::System.Drawing.Size(132, 23);
			this.button_BanquetCopy.TabIndex = 14;
			this.button_BanquetCopy.Text = "Copy Settings";
			this.button_BanquetCopy.UseVisualStyleBackColor = true;
			this.button_BanquetCopy.Click += new global::System.EventHandler(this.button_CopySettings_Click);
			this.button_BanquetLoad.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.button_BanquetLoad.Location = new global::System.Drawing.Point(143, 384);
			this.button_BanquetLoad.Name = "button_BanquetLoad";
			this.button_BanquetLoad.Size = new global::System.Drawing.Size(132, 23);
			this.button_BanquetLoad.TabIndex = 13;
			this.button_BanquetLoad.Text = "Load";
			this.button_BanquetLoad.UseVisualStyleBackColor = true;
			this.button_BanquetLoad.Click += new global::System.EventHandler(this.button_BanquetLoad_Click);
			this.button_BanquetSave.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.button_BanquetSave.Location = new global::System.Drawing.Point(0, 384);
			this.button_BanquetSave.Name = "button_BanquetSave";
			this.button_BanquetSave.Size = new global::System.Drawing.Size(132, 23);
			this.button_BanquetSave.TabIndex = 12;
			this.button_BanquetSave.Text = "Save";
			this.button_BanquetSave.UseVisualStyleBackColor = true;
			this.button_BanquetSave.Click += new global::System.EventHandler(this.button_BanquetSave_Click);
			this.dataGridView_Banquets.AllowUserToAddRows = false;
			this.dataGridView_Banquets.AllowUserToDeleteRows = false;
			this.dataGridView_Banquets.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.dataGridView_Banquets.AutoSizeRowsMode = global::System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridView_Banquets.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_Banquets.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.BanquetVillage,
				this.BanquetLevel
			});
			this.dataGridView_Banquets.Location = new global::System.Drawing.Point(0, 34);
			this.dataGridView_Banquets.Name = "dataGridView_Banquets";
			this.dataGridView_Banquets.RowHeadersVisible = false;
			this.dataGridView_Banquets.Size = new global::System.Drawing.Size(556, 344);
			this.dataGridView_Banquets.TabIndex = 11;
			this.BanquetVillage.HeaderText = "Village";
			this.BanquetVillage.Name = "BanquetVillage";
			this.BanquetVillage.ReadOnly = true;
			this.BanquetVillage.Width = 200;
			this.BanquetLevel.HeaderText = "Banquet";
			this.BanquetLevel.Name = "BanquetLevel";
			this.BanquetLevel.Width = 150;
			this.button_BanquetingHelp.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.button_BanquetingHelp.Location = new global::System.Drawing.Point(457, 5);
			this.button_BanquetingHelp.Name = "button_BanquetingHelp";
			this.button_BanquetingHelp.Size = new global::System.Drawing.Size(96, 23);
			this.button_BanquetingHelp.TabIndex = 10;
			this.button_BanquetingHelp.Text = "Help";
			this.button_BanquetingHelp.UseVisualStyleBackColor = true;
			this.button_BanquetingHelp.Click += new global::System.EventHandler(this.button_BanquetingHelp_Click);
			this.numeric_BanquetInterval.Location = new global::System.Drawing.Point(350, 4);
			global::System.Windows.Forms.NumericUpDown numericUpDown45 = this.numeric_BanquetInterval;
			int[] array45 = new int[4];
			array45[0] = 1000;
			numericUpDown45.Maximum = new decimal(array45);
			global::System.Windows.Forms.NumericUpDown numericUpDown46 = this.numeric_BanquetInterval;
			int[] array46 = new int[4];
			array46[0] = 5;
			numericUpDown46.Minimum = new decimal(array46);
			this.numeric_BanquetInterval.Name = "numeric_BanquetInterval";
			this.numeric_BanquetInterval.Size = new global::System.Drawing.Size(48, 20);
			this.numeric_BanquetInterval.TabIndex = 8;
			global::System.Windows.Forms.NumericUpDown numericUpDown47 = this.numeric_BanquetInterval;
			int[] array47 = new int[4];
			array47[0] = 15;
			numericUpDown47.Value = new decimal(array47);
			this.numeric_BanquetInterval.ValueChanged += new global::System.EventHandler(this.numeric_BanquetInterval_ValueChanged);
			this.richTextBoxBanquetting.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.richTextBoxBanquetting.Location = new global::System.Drawing.Point(0, 415);
			this.richTextBoxBanquetting.Name = "richTextBoxBanquetting";
			this.richTextBoxBanquetting.ReadOnly = true;
			this.richTextBoxBanquetting.Size = new global::System.Drawing.Size(556, 211);
			this.richTextBoxBanquetting.TabIndex = 7;
			this.richTextBoxBanquetting.Text = "";
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(175, 6);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(116, 13);
			this.label7.TabIndex = 3;
			this.label7.Text = "Time interval (seconds)";
			this.PlayBanquets.AutoSize = true;
			this.PlayBanquets.Location = new global::System.Drawing.Point(8, 5);
			this.PlayBanquets.Name = "PlayBanquets";
			this.PlayBanquets.Size = new global::System.Drawing.Size(94, 17);
			this.PlayBanquets.TabIndex = 0;
			this.PlayBanquets.Text = "Play Banquets";
			this.PlayBanquets.UseVisualStyleBackColor = true;
			this.PlayBanquets.CheckedChanged += new global::System.EventHandler(this.PlayBanquets_CheckedChanged);
			this.tabPage_PopularityRegulation.Controls.Add(this.button_CopyPopularity);
			this.tabPage_PopularityRegulation.Controls.Add(this.checkBox_PopularitySelectAll);
			this.tabPage_PopularityRegulation.Controls.Add(this.comboBox_PopularityRegulationMode);
			this.tabPage_PopularityRegulation.Controls.Add(this.numericUpDown_PopularityRegulation);
			this.tabPage_PopularityRegulation.Controls.Add(this.listBox_PopularityRegulation);
			this.tabPage_PopularityRegulation.Controls.Add(this.richTextBoxPopularityRegulation);
			this.tabPage_PopularityRegulation.Controls.Add(this.label14);
			this.tabPage_PopularityRegulation.Controls.Add(this.RegulatePopularity);
			this.tabPage_PopularityRegulation.Location = new global::System.Drawing.Point(4, 40);
			this.tabPage_PopularityRegulation.Name = "tabPage_PopularityRegulation";
			this.tabPage_PopularityRegulation.Size = new global::System.Drawing.Size(556, 626);
			this.tabPage_PopularityRegulation.TabIndex = 9;
			this.tabPage_PopularityRegulation.Text = "Popularity";
			this.tabPage_PopularityRegulation.UseVisualStyleBackColor = true;
			this.button_CopyPopularity.Location = new global::System.Drawing.Point(190, 130);
			this.button_CopyPopularity.Name = "button_CopyPopularity";
			this.button_CopyPopularity.Size = new global::System.Drawing.Size(109, 23);
			this.button_CopyPopularity.TabIndex = 13;
			this.button_CopyPopularity.Text = "Copy Settings";
			this.button_CopyPopularity.UseVisualStyleBackColor = true;
			this.button_CopyPopularity.Click += new global::System.EventHandler(this.button_CopySettings_Click);
			this.checkBox_PopularitySelectAll.AutoSize = true;
			this.checkBox_PopularitySelectAll.Location = new global::System.Drawing.Point(171, 6);
			this.checkBox_PopularitySelectAll.Name = "checkBox_PopularitySelectAll";
			this.checkBox_PopularitySelectAll.Size = new global::System.Drawing.Size(15, 14);
			this.checkBox_PopularitySelectAll.TabIndex = 12;
			this.checkBox_PopularitySelectAll.UseVisualStyleBackColor = true;
			this.checkBox_PopularitySelectAll.CheckedChanged += new global::System.EventHandler(this.checkBox_PopularitySelectAll_CheckedChanged);
			this.comboBox_PopularityRegulationMode.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_PopularityRegulationMode.FormattingEnabled = true;
			this.comboBox_PopularityRegulationMode.Items.AddRange(new object[]
			{
				"Select the mode",
				"Take highest possible tax",
				"Tax only villages with max population",
				"Reach highest possible recruit rate",
				"Auto-switch between taxes and recruitment"
			});
			this.comboBox_PopularityRegulationMode.Location = new global::System.Drawing.Point(190, 26);
			this.comboBox_PopularityRegulationMode.Name = "comboBox_PopularityRegulationMode";
			this.comboBox_PopularityRegulationMode.Size = new global::System.Drawing.Size(269, 21);
			this.comboBox_PopularityRegulationMode.TabIndex = 11;
			this.comboBox_PopularityRegulationMode.SelectedIndexChanged += new global::System.EventHandler(this.comboBox_PopularityRegulationMode_SelectedIndexChanged);
			this.numericUpDown_PopularityRegulation.Location = new global::System.Drawing.Point(322, 57);
			global::System.Windows.Forms.NumericUpDown numericUpDown48 = this.numericUpDown_PopularityRegulation;
			int[] array48 = new int[4];
			array48[0] = 1;
			numericUpDown48.Minimum = new decimal(array48);
			this.numericUpDown_PopularityRegulation.Name = "numericUpDown_PopularityRegulation";
			this.numericUpDown_PopularityRegulation.Size = new global::System.Drawing.Size(45, 20);
			this.numericUpDown_PopularityRegulation.TabIndex = 10;
			global::System.Windows.Forms.NumericUpDown numericUpDown49 = this.numericUpDown_PopularityRegulation;
			int[] array49 = new int[4];
			array49[0] = 1;
			numericUpDown49.Value = new decimal(array49);
			this.numericUpDown_PopularityRegulation.ValueChanged += new global::System.EventHandler(this.numericUpDown_PopularityRegulation_ValueChanged);
			this.listBox_PopularityRegulation.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.listBox_PopularityRegulation.FormattingEnabled = true;
			this.listBox_PopularityRegulation.Location = new global::System.Drawing.Point(4, 24);
			this.listBox_PopularityRegulation.Name = "listBox_PopularityRegulation";
			this.listBox_PopularityRegulation.SelectionMode = global::System.Windows.Forms.SelectionMode.MultiSimple;
			this.listBox_PopularityRegulation.Size = new global::System.Drawing.Size(180, 303);
			this.listBox_PopularityRegulation.TabIndex = 9;
			this.listBox_PopularityRegulation.SelectedIndexChanged += new global::System.EventHandler(this.listBox_PopularityRegulation_SelectedIndexChanged);
			this.richTextBoxPopularityRegulation.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.richTextBoxPopularityRegulation.Location = new global::System.Drawing.Point(0, 344);
			this.richTextBoxPopularityRegulation.Name = "richTextBoxPopularityRegulation";
			this.richTextBoxPopularityRegulation.ReadOnly = true;
			this.richTextBoxPopularityRegulation.Size = new global::System.Drawing.Size(556, 282);
			this.richTextBoxPopularityRegulation.TabIndex = 7;
			this.richTextBoxPopularityRegulation.Text = "";
			this.label14.AutoSize = true;
			this.label14.Location = new global::System.Drawing.Point(187, 60);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(112, 13);
			this.label14.TabIndex = 5;
			this.label14.Text = "Time interval (minutes)";
			this.RegulatePopularity.AutoSize = true;
			this.RegulatePopularity.Location = new global::System.Drawing.Point(204, 5);
			this.RegulatePopularity.Name = "RegulatePopularity";
			this.RegulatePopularity.Size = new global::System.Drawing.Size(118, 17);
			this.RegulatePopularity.TabIndex = 3;
			this.RegulatePopularity.Text = "Regulate Popularity";
			this.RegulatePopularity.UseVisualStyleBackColor = true;
			this.RegulatePopularity.CheckedChanged += new global::System.EventHandler(this.RegulatePopularity_CheckedChanged);
			this.tabPage_Villagelayout.Controls.Add(this.tabControl_VillageLayouts);
			this.tabPage_Villagelayout.Location = new global::System.Drawing.Point(4, 40);
			this.tabPage_Villagelayout.Name = "tabPage_Villagelayout";
			this.tabPage_Villagelayout.Size = new global::System.Drawing.Size(556, 626);
			this.tabPage_Villagelayout.TabIndex = 11;
			this.tabPage_Villagelayout.Text = "Village";
			this.tabPage_Villagelayout.UseVisualStyleBackColor = true;
			this.tabControl_VillageLayouts.Controls.Add(this.tabPage_villageLayouts);
			this.tabControl_VillageLayouts.Controls.Add(this.tabPage_villageLayoutsLogs);
			this.tabControl_VillageLayouts.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tabControl_VillageLayouts.Location = new global::System.Drawing.Point(0, 0);
			this.tabControl_VillageLayouts.Name = "tabControl_VillageLayouts";
			this.tabControl_VillageLayouts.SelectedIndex = 0;
			this.tabControl_VillageLayouts.Size = new global::System.Drawing.Size(556, 626);
			this.tabControl_VillageLayouts.TabIndex = 17;
			this.tabPage_villageLayouts.BackColor = global::System.Drawing.Color.Transparent;
			this.tabPage_villageLayouts.Controls.Add(this.groupBox_villageLayoutsNavigation);
			this.tabPage_villageLayouts.Controls.Add(this.groupBox_VillageLayoutsSettings);
			this.tabPage_villageLayouts.Controls.Add(this.groupBox_SelectedLayout);
			this.tabPage_villageLayouts.Controls.Add(this.checkBox_villagesLayoutsSelectAll);
			this.tabPage_villageLayouts.Controls.Add(this.listBox_VillageLayouts);
			this.tabPage_villageLayouts.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage_villageLayouts.Name = "tabPage_villageLayouts";
			this.tabPage_villageLayouts.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage_villageLayouts.Size = new global::System.Drawing.Size(548, 600);
			this.tabPage_villageLayouts.TabIndex = 0;
			this.tabPage_villageLayouts.Text = "Village layout";
			this.groupBox_villageLayoutsNavigation.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.groupBox_villageLayoutsNavigation.BackColor = global::System.Drawing.Color.PaleGreen;
			this.groupBox_villageLayoutsNavigation.Controls.Add(this.button_previousLayout);
			this.groupBox_villageLayoutsNavigation.Controls.Add(this.button_nextLayout);
			this.groupBox_villageLayoutsNavigation.Controls.Add(this.comboBox_villageLayouts);
			this.groupBox_villageLayoutsNavigation.Location = new global::System.Drawing.Point(170, 0);
			this.groupBox_villageLayoutsNavigation.Name = "groupBox_villageLayoutsNavigation";
			this.groupBox_villageLayoutsNavigation.Size = new global::System.Drawing.Size(378, 42);
			this.groupBox_villageLayoutsNavigation.TabIndex = 19;
			this.groupBox_villageLayoutsNavigation.TabStop = false;
			this.groupBox_villageLayoutsNavigation.Text = "Navigation";
			this.button_previousLayout.Location = new global::System.Drawing.Point(6, 14);
			this.button_previousLayout.Name = "button_previousLayout";
			this.button_previousLayout.Size = new global::System.Drawing.Size(30, 23);
			this.button_previousLayout.TabIndex = 94;
			this.button_previousLayout.Text = "<-";
			this.toolTip1.SetToolTip(this.button_previousLayout, "Previous village settings (CTRL+Left)");
			this.button_previousLayout.UseVisualStyleBackColor = true;
			this.button_previousLayout.Click += new global::System.EventHandler(this.button_previousLayout_Click);
			this.button_nextLayout.Location = new global::System.Drawing.Point(38, 14);
			this.button_nextLayout.Name = "button_nextLayout";
			this.button_nextLayout.Size = new global::System.Drawing.Size(30, 23);
			this.button_nextLayout.TabIndex = 93;
			this.button_nextLayout.Text = "->";
			this.toolTip1.SetToolTip(this.button_nextLayout, "Next village settings (CTRL+Right)");
			this.button_nextLayout.UseVisualStyleBackColor = true;
			this.button_nextLayout.Click += new global::System.EventHandler(this.button_nextLayout_Click);
			this.comboBox_villageLayouts.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.comboBox_villageLayouts.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_villageLayouts.FormattingEnabled = true;
			this.comboBox_villageLayouts.Location = new global::System.Drawing.Point(72, 15);
			this.comboBox_villageLayouts.Name = "comboBox_villageLayouts";
			this.comboBox_villageLayouts.Size = new global::System.Drawing.Size(300, 21);
			this.comboBox_villageLayouts.TabIndex = 92;
			this.toolTip1.SetToolTip(this.comboBox_villageLayouts, "Select a village to specify it's trade settings");
			this.comboBox_villageLayouts.SelectedIndexChanged += new global::System.EventHandler(this.comboBox_villageLayouts_SelectedIndexChanged);
			this.groupBox_VillageLayoutsSettings.BackColor = global::System.Drawing.Color.Aquamarine;
			this.groupBox_VillageLayoutsSettings.Controls.Add(this.button_VillageCopy);
			this.groupBox_VillageLayoutsSettings.Controls.Add(this.button_VillageLayouts_Help);
			this.groupBox_VillageLayoutsSettings.Controls.Add(this.checkBox_VillageLayouts);
			this.groupBox_VillageLayoutsSettings.Controls.Add(this.numericUpDown_VillageLayoutInterval);
			this.groupBox_VillageLayoutsSettings.Controls.Add(this.checkBox_AutoConstr_WaitRes);
			this.groupBox_VillageLayoutsSettings.Controls.Add(this.button8);
			this.groupBox_VillageLayoutsSettings.Controls.Add(this.label_villageConstruction_interval);
			this.groupBox_VillageLayoutsSettings.Controls.Add(this.button_SaveLayouts);
			this.groupBox_VillageLayoutsSettings.Location = new global::System.Drawing.Point(0, 0);
			this.groupBox_VillageLayoutsSettings.Name = "groupBox_VillageLayoutsSettings";
			this.groupBox_VillageLayoutsSettings.Size = new global::System.Drawing.Size(164, 193);
			this.groupBox_VillageLayoutsSettings.TabIndex = 18;
			this.groupBox_VillageLayoutsSettings.TabStop = false;
			this.groupBox_VillageLayoutsSettings.Text = "Settings";
			this.button_VillageCopy.Location = new global::System.Drawing.Point(3, 170);
			this.button_VillageCopy.Name = "button_VillageCopy";
			this.button_VillageCopy.Size = new global::System.Drawing.Size(139, 23);
			this.button_VillageCopy.TabIndex = 17;
			this.button_VillageCopy.Text = "Copy Settings";
			this.toolTip1.SetToolTip(this.button_VillageCopy, "CTRL+Shift+C");
			this.button_VillageCopy.UseVisualStyleBackColor = true;
			this.button_VillageCopy.Click += new global::System.EventHandler(this.button_CopySettings_Click);
			this.button_VillageLayouts_Help.Location = new global::System.Drawing.Point(3, 144);
			this.button_VillageLayouts_Help.Name = "button_VillageLayouts_Help";
			this.button_VillageLayouts_Help.Size = new global::System.Drawing.Size(139, 23);
			this.button_VillageLayouts_Help.TabIndex = 16;
			this.button_VillageLayouts_Help.Text = "Help";
			this.button_VillageLayouts_Help.UseVisualStyleBackColor = true;
			this.button_VillageLayouts_Help.Click += new global::System.EventHandler(this.button_VillageLayouts_Help_Click);
			this.checkBox_VillageLayouts.AutoSize = true;
			this.checkBox_VillageLayouts.Location = new global::System.Drawing.Point(6, 19);
			this.checkBox_VillageLayouts.Name = "checkBox_VillageLayouts";
			this.checkBox_VillageLayouts.Size = new global::System.Drawing.Size(100, 17);
			this.checkBox_VillageLayouts.TabIndex = 4;
			this.checkBox_VillageLayouts.Text = "Turn on module";
			this.checkBox_VillageLayouts.UseVisualStyleBackColor = true;
			this.checkBox_VillageLayouts.CheckedChanged += new global::System.EventHandler(this.checkBox_VillageLayouts_CheckedChanged);
			global::System.Windows.Forms.NumericUpDown numericUpDown50 = this.numericUpDown_VillageLayoutInterval;
			int[] array50 = new int[4];
			array50[0] = 5;
			numericUpDown50.Increment = new decimal(array50);
			this.numericUpDown_VillageLayoutInterval.Location = new global::System.Drawing.Point(103, 37);
			global::System.Windows.Forms.NumericUpDown numericUpDown51 = this.numericUpDown_VillageLayoutInterval;
			int[] array51 = new int[4];
			array51[0] = 1000;
			numericUpDown51.Maximum = new decimal(array51);
			global::System.Windows.Forms.NumericUpDown numericUpDown52 = this.numericUpDown_VillageLayoutInterval;
			int[] array52 = new int[4];
			array52[0] = 10;
			numericUpDown52.Minimum = new decimal(array52);
			this.numericUpDown_VillageLayoutInterval.Name = "numericUpDown_VillageLayoutInterval";
			this.numericUpDown_VillageLayoutInterval.Size = new global::System.Drawing.Size(42, 20);
			this.numericUpDown_VillageLayoutInterval.TabIndex = 13;
			global::System.Windows.Forms.NumericUpDown numericUpDown53 = this.numericUpDown_VillageLayoutInterval;
			int[] array53 = new int[4];
			array53[0] = 30;
			numericUpDown53.Value = new decimal(array53);
			this.numericUpDown_VillageLayoutInterval.ValueChanged += new global::System.EventHandler(this.numericUpDown_VillageLayoutInterval_ValueChanged);
			this.checkBox_AutoConstr_WaitRes.AutoSize = true;
			this.checkBox_AutoConstr_WaitRes.Location = new global::System.Drawing.Point(3, 63);
			this.checkBox_AutoConstr_WaitRes.Name = "checkBox_AutoConstr_WaitRes";
			this.checkBox_AutoConstr_WaitRes.Size = new global::System.Drawing.Size(148, 17);
			this.checkBox_AutoConstr_WaitRes.TabIndex = 12;
			this.checkBox_AutoConstr_WaitRes.Text = "Wait till enough resources";
			this.checkBox_AutoConstr_WaitRes.UseVisualStyleBackColor = true;
			this.checkBox_AutoConstr_WaitRes.CheckedChanged += new global::System.EventHandler(this.checkBox_AutoConstr_WaitRes_CheckedChanged);
			this.button8.Location = new global::System.Drawing.Point(3, 115);
			this.button8.Name = "button8";
			this.button8.Size = new global::System.Drawing.Size(139, 23);
			this.button8.TabIndex = 5;
			this.button8.Text = "Load";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new global::System.EventHandler(this.button_LoadLayouts_Click);
			this.label_villageConstruction_interval.AutoSize = true;
			this.label_villageConstruction_interval.Location = new global::System.Drawing.Point(0, 39);
			this.label_villageConstruction_interval.Name = "label_villageConstruction_interval";
			this.label_villageConstruction_interval.Size = new global::System.Drawing.Size(94, 13);
			this.label_villageConstruction_interval.TabIndex = 15;
			this.label_villageConstruction_interval.Text = "Interval (seconds):";
			this.button_SaveLayouts.Location = new global::System.Drawing.Point(3, 86);
			this.button_SaveLayouts.Name = "button_SaveLayouts";
			this.button_SaveLayouts.Size = new global::System.Drawing.Size(139, 23);
			this.button_SaveLayouts.TabIndex = 2;
			this.button_SaveLayouts.Text = "Save";
			this.button_SaveLayouts.UseVisualStyleBackColor = true;
			this.button_SaveLayouts.Click += new global::System.EventHandler(this.button_SaveLayouts_Click);
			this.groupBox_SelectedLayout.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.groupBox_SelectedLayout.BackColor = global::System.Drawing.Color.LightCoral;
			this.groupBox_SelectedLayout.Controls.Add(this.button_ImportLayoutFromFile);
			this.groupBox_SelectedLayout.Controls.Add(this.comboBox_VillageTemplate);
			this.groupBox_SelectedLayout.Controls.Add(this.label_VillageTemplate);
			this.groupBox_SelectedLayout.Controls.Add(this.checkBox_ShouldLayoutBeBuilt);
			this.groupBox_SelectedLayout.Controls.Add(this.dataGridViewVillageLayoutsEdit);
			this.groupBox_SelectedLayout.Location = new global::System.Drawing.Point(170, 48);
			this.groupBox_SelectedLayout.Name = "groupBox_SelectedLayout";
			this.groupBox_SelectedLayout.Size = new global::System.Drawing.Size(378, 552);
			this.groupBox_SelectedLayout.TabIndex = 17;
			this.groupBox_SelectedLayout.TabStop = false;
			this.groupBox_SelectedLayout.Text = "None selected";
			this.button_ImportLayoutFromFile.Location = new global::System.Drawing.Point(213, 29);
			this.button_ImportLayoutFromFile.Name = "button_ImportLayoutFromFile";
			this.button_ImportLayoutFromFile.Size = new global::System.Drawing.Size(139, 23);
			this.button_ImportLayoutFromFile.TabIndex = 13;
			this.button_ImportLayoutFromFile.Text = "Import From File";
			this.button_ImportLayoutFromFile.UseVisualStyleBackColor = true;
			this.button_ImportLayoutFromFile.Click += new global::System.EventHandler(this.button_ImportLayoutFromFile_Click);
			this.comboBox_VillageTemplate.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_VillageTemplate.FormattingEnabled = true;
			this.comboBox_VillageTemplate.Location = new global::System.Drawing.Point(86, 30);
			this.comboBox_VillageTemplate.Name = "comboBox_VillageTemplate";
			this.comboBox_VillageTemplate.Size = new global::System.Drawing.Size(121, 21);
			this.comboBox_VillageTemplate.TabIndex = 12;
			this.comboBox_VillageTemplate.SelectionChangeCommitted += new global::System.EventHandler(this.comboBox_VillageTemplate_SelectionChangeCommitted);
			this.label_VillageTemplate.AutoSize = true;
			this.label_VillageTemplate.Location = new global::System.Drawing.Point(7, 34);
			this.label_VillageTemplate.Name = "label_VillageTemplate";
			this.label_VillageTemplate.Size = new global::System.Drawing.Size(51, 13);
			this.label_VillageTemplate.TabIndex = 11;
			this.label_VillageTemplate.Text = "Template";
			this.checkBox_ShouldLayoutBeBuilt.AutoSize = true;
			this.checkBox_ShouldLayoutBeBuilt.Location = new global::System.Drawing.Point(7, 14);
			this.checkBox_ShouldLayoutBeBuilt.Name = "checkBox_ShouldLayoutBeBuilt";
			this.checkBox_ShouldLayoutBeBuilt.Size = new global::System.Drawing.Size(154, 17);
			this.checkBox_ShouldLayoutBeBuilt.TabIndex = 10;
			this.checkBox_ShouldLayoutBeBuilt.Text = "Should this village be built?";
			this.checkBox_ShouldLayoutBeBuilt.UseVisualStyleBackColor = true;
			this.checkBox_ShouldLayoutBeBuilt.CheckedChanged += new global::System.EventHandler(this.checkBox_ShouldLayoutBeBuilt_CheckedChanged);
			this.dataGridViewVillageLayoutsEdit.AllowUserToAddRows = false;
			this.dataGridViewVillageLayoutsEdit.AllowUserToOrderColumns = true;
			this.dataGridViewVillageLayoutsEdit.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.dataGridViewVillageLayoutsEdit.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewVillageLayoutsEdit.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.typeID,
				this.TypeName,
				this.Number,
				this.BuildingStatus,
				this.Xcoord,
				this.Ycoord
			});
			this.dataGridViewVillageLayoutsEdit.Location = new global::System.Drawing.Point(6, 52);
			this.dataGridViewVillageLayoutsEdit.MultiSelect = false;
			this.dataGridViewVillageLayoutsEdit.Name = "dataGridViewVillageLayoutsEdit";
			this.dataGridViewVillageLayoutsEdit.ReadOnly = true;
			this.dataGridViewVillageLayoutsEdit.RowHeadersVisible = false;
			this.dataGridViewVillageLayoutsEdit.SelectionMode = global::System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewVillageLayoutsEdit.Size = new global::System.Drawing.Size(366, 494);
			this.dataGridViewVillageLayoutsEdit.TabIndex = 9;
			this.dataGridViewVillageLayoutsEdit.RowsRemoved += new global::System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridViewVillageLayoutsEdit_RowsRemoved);
			this.dataGridViewVillageLayoutsEdit.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.dataGridViewVillageLayoutsEdit_KeyDown);
			this.typeID.HeaderText = "Type";
			this.typeID.Name = "typeID";
			this.typeID.ReadOnly = true;
			this.typeID.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.typeID.Visible = false;
			this.TypeName.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.TypeName.FillWeight = 169.9667f;
			this.TypeName.HeaderText = "Building";
			this.TypeName.Name = "TypeName";
			this.TypeName.ReadOnly = true;
			this.TypeName.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Number.FillWeight = 30f;
			this.Number.HeaderText = "Num.";
			this.Number.Name = "Number";
			this.Number.ReadOnly = true;
			this.Number.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Number.Width = 40;
			this.BuildingStatus.HeaderText = "Status";
			this.BuildingStatus.Name = "BuildingStatus";
			this.BuildingStatus.ReadOnly = true;
			this.BuildingStatus.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Xcoord.FillWeight = 30f;
			this.Xcoord.HeaderText = "X";
			this.Xcoord.Name = "Xcoord";
			this.Xcoord.ReadOnly = true;
			this.Xcoord.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Xcoord.Width = 40;
			this.Ycoord.FillWeight = 30f;
			this.Ycoord.HeaderText = "Y";
			this.Ycoord.Name = "Ycoord";
			this.Ycoord.ReadOnly = true;
			this.Ycoord.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Ycoord.Width = 40;
			this.checkBox_villagesLayoutsSelectAll.AutoSize = true;
			this.checkBox_villagesLayoutsSelectAll.Location = new global::System.Drawing.Point(149, 199);
			this.checkBox_villagesLayoutsSelectAll.Name = "checkBox_villagesLayoutsSelectAll";
			this.checkBox_villagesLayoutsSelectAll.Size = new global::System.Drawing.Size(15, 14);
			this.checkBox_villagesLayoutsSelectAll.TabIndex = 16;
			this.checkBox_villagesLayoutsSelectAll.UseVisualStyleBackColor = true;
			this.checkBox_villagesLayoutsSelectAll.CheckedChanged += new global::System.EventHandler(this.checkBox_villagesLayoutsSelectAll_CheckedChanged);
			this.listBox_VillageLayouts.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.listBox_VillageLayouts.FormattingEnabled = true;
			this.listBox_VillageLayouts.Location = new global::System.Drawing.Point(-1, 219);
			this.listBox_VillageLayouts.Name = "listBox_VillageLayouts";
			this.listBox_VillageLayouts.SelectionMode = global::System.Windows.Forms.SelectionMode.MultiSimple;
			this.listBox_VillageLayouts.Size = new global::System.Drawing.Size(165, 381);
			this.listBox_VillageLayouts.TabIndex = 0;
			this.listBox_VillageLayouts.SelectedIndexChanged += new global::System.EventHandler(this.listBox_VillageLayouts_SelectedIndexChanged);
			this.listBox_VillageLayouts.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.listBox_VillageLayouts_MouseDown);
			this.tabPage_villageLayoutsLogs.Controls.Add(this.richTextBoxVillageLayouts);
			this.tabPage_villageLayoutsLogs.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage_villageLayoutsLogs.Name = "tabPage_villageLayoutsLogs";
			this.tabPage_villageLayoutsLogs.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage_villageLayoutsLogs.Size = new global::System.Drawing.Size(548, 600);
			this.tabPage_villageLayoutsLogs.TabIndex = 1;
			this.tabPage_villageLayoutsLogs.Text = "Logs";
			this.tabPage_villageLayoutsLogs.UseVisualStyleBackColor = true;
			this.richTextBoxVillageLayouts.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.richTextBoxVillageLayouts.Location = new global::System.Drawing.Point(3, 3);
			this.richTextBoxVillageLayouts.Name = "richTextBoxVillageLayouts";
			this.richTextBoxVillageLayouts.ReadOnly = true;
			this.richTextBoxVillageLayouts.Size = new global::System.Drawing.Size(542, 594);
			this.richTextBoxVillageLayouts.TabIndex = 1;
			this.richTextBoxVillageLayouts.Text = "";
			this.tabPage_Castle.Controls.Add(this.button_CastleHelp);
			this.tabPage_Castle.Controls.Add(this.button3);
			this.tabPage_Castle.Controls.Add(this.checkBox_AutoRepairCastle);
			this.tabPage_Castle.Controls.Add(this.button_SaveCastlesLocally);
			this.tabPage_Castle.Controls.Add(this.button_CastleLoad);
			this.tabPage_Castle.Controls.Add(this.button_CastleSave);
			this.tabPage_Castle.Controls.Add(this.dataGridView_RepairCastle);
			this.tabPage_Castle.Controls.Add(this.richTextBoxCastle);
			this.tabPage_Castle.Controls.Add(this.button_FixCastles);
			this.tabPage_Castle.Location = new global::System.Drawing.Point(4, 40);
			this.tabPage_Castle.Name = "tabPage_Castle";
			this.tabPage_Castle.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage_Castle.Size = new global::System.Drawing.Size(556, 626);
			this.tabPage_Castle.TabIndex = 17;
			this.tabPage_Castle.Text = "Castle";
			this.tabPage_Castle.UseVisualStyleBackColor = true;
			this.button_CastleHelp.Location = new global::System.Drawing.Point(358, 6);
			this.button_CastleHelp.Name = "button_CastleHelp";
			this.button_CastleHelp.Size = new global::System.Drawing.Size(109, 23);
			this.button_CastleHelp.TabIndex = 9;
			this.button_CastleHelp.Text = "Help";
			this.button_CastleHelp.UseVisualStyleBackColor = true;
			this.button_CastleHelp.Click += new global::System.EventHandler(this.button_CastleHelp_Click);
			this.button3.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.button3.Location = new global::System.Drawing.Point(270, 401);
			this.button3.Name = "button3";
			this.button3.Size = new global::System.Drawing.Size(109, 23);
			this.button3.TabIndex = 8;
			this.button3.Text = "Repair Current";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new global::System.EventHandler(this.Button_RepairCurrent_Click);
			this.checkBox_AutoRepairCastle.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.checkBox_AutoRepairCastle.AutoSize = true;
			this.checkBox_AutoRepairCastle.Location = new global::System.Drawing.Point(8, 407);
			this.checkBox_AutoRepairCastle.Name = "checkBox_AutoRepairCastle";
			this.checkBox_AutoRepairCastle.Size = new global::System.Drawing.Size(123, 17);
			this.checkBox_AutoRepairCastle.TabIndex = 7;
			this.checkBox_AutoRepairCastle.Text = "Repair on AI attacks";
			this.checkBox_AutoRepairCastle.UseVisualStyleBackColor = true;
			this.checkBox_AutoRepairCastle.CheckedChanged += new global::System.EventHandler(this.CheckBox_AutoRepairCastle_CheckedChanged);
			this.button_SaveCastlesLocally.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.button_SaveCastlesLocally.Location = new global::System.Drawing.Point(385, 401);
			this.button_SaveCastlesLocally.Name = "button_SaveCastlesLocally";
			this.button_SaveCastlesLocally.Size = new global::System.Drawing.Size(163, 23);
			this.button_SaveCastlesLocally.TabIndex = 6;
			this.button_SaveCastlesLocally.Text = "Save Castles Locally";
			this.button_SaveCastlesLocally.UseVisualStyleBackColor = true;
			this.button_SaveCastlesLocally.Click += new global::System.EventHandler(this.button_SaveCastlesLocally_Click);
			this.button_CastleLoad.Location = new global::System.Drawing.Point(243, 6);
			this.button_CastleLoad.Name = "button_CastleLoad";
			this.button_CastleLoad.Size = new global::System.Drawing.Size(109, 23);
			this.button_CastleLoad.TabIndex = 5;
			this.button_CastleLoad.Text = "Load";
			this.button_CastleLoad.UseVisualStyleBackColor = true;
			this.button_CastleLoad.Click += new global::System.EventHandler(this.button_CastleLoad_Click);
			this.button_CastleSave.Location = new global::System.Drawing.Point(130, 6);
			this.button_CastleSave.Name = "button_CastleSave";
			this.button_CastleSave.Size = new global::System.Drawing.Size(109, 23);
			this.button_CastleSave.TabIndex = 4;
			this.button_CastleSave.Text = "Save";
			this.button_CastleSave.UseVisualStyleBackColor = true;
			this.button_CastleSave.Click += new global::System.EventHandler(this.button_CastleSave_Click);
			this.dataGridView_RepairCastle.AllowUserToAddRows = false;
			this.dataGridView_RepairCastle.AllowUserToDeleteRows = false;
			this.dataGridView_RepairCastle.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.dataGridView_RepairCastle.AutoSizeColumnsMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView_RepairCastle.AutoSizeRowsMode = global::System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridView_RepairCastle.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_RepairCastle.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.CastleVillageName,
				this.CastleRestoreCastle,
				this.CastleSelectLayout,
				this.CastleRestoreTroops,
				this.CastleSelectTroops
			});
			this.dataGridView_RepairCastle.Location = new global::System.Drawing.Point(0, 35);
			this.dataGridView_RepairCastle.Name = "dataGridView_RepairCastle";
			this.dataGridView_RepairCastle.RowHeadersVisible = false;
			this.dataGridView_RepairCastle.Size = new global::System.Drawing.Size(556, 365);
			this.dataGridView_RepairCastle.TabIndex = 2;
			this.CastleVillageName.HeaderText = "Village";
			this.CastleVillageName.Name = "CastleVillageName";
			this.CastleVillageName.ReadOnly = true;
			this.CastleRestoreCastle.HeaderText = "Restore Castle";
			this.CastleRestoreCastle.Name = "CastleRestoreCastle";
			this.CastleSelectLayout.HeaderText = "Castle Layout";
			this.CastleSelectLayout.Name = "CastleSelectLayout";
			this.CastleRestoreTroops.HeaderText = "Restore Troops";
			this.CastleRestoreTroops.Name = "CastleRestoreTroops";
			this.CastleSelectTroops.HeaderText = "Troops Placement";
			this.CastleSelectTroops.Name = "CastleSelectTroops";
			this.richTextBoxCastle.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.richTextBoxCastle.Location = new global::System.Drawing.Point(3, 430);
			this.richTextBoxCastle.Name = "richTextBoxCastle";
			this.richTextBoxCastle.ReadOnly = true;
			this.richTextBoxCastle.Size = new global::System.Drawing.Size(550, 193);
			this.richTextBoxCastle.TabIndex = 1;
			this.richTextBoxCastle.Text = "";
			this.button_FixCastles.Location = new global::System.Drawing.Point(8, 6);
			this.button_FixCastles.Name = "button_FixCastles";
			this.button_FixCastles.Size = new global::System.Drawing.Size(116, 23);
			this.button_FixCastles.TabIndex = 0;
			this.button_FixCastles.Text = "Fix castles";
			this.button_FixCastles.UseVisualStyleBackColor = true;
			this.button_FixCastles.Click += new global::System.EventHandler(this.button_FixCastles_Click);
			this.tabPage_Predator.Controls.Add(this.button_PredatorCopy);
			this.tabPage_Predator.Controls.Add(this.button_PredatorHelp);
			this.tabPage_Predator.Controls.Add(this.tabControl_PredatorSettings);
			this.tabPage_Predator.Controls.Add(this.tabControl_Predator);
			this.tabPage_Predator.Controls.Add(this.button_PredatorUpdatePresets);
			this.tabPage_Predator.Controls.Add(this.button_predatorStopSound);
			this.tabPage_Predator.Controls.Add(this.checkBox_StartHunting);
			this.tabPage_Predator.Controls.Add(this.button_LoadPrays);
			this.tabPage_Predator.Controls.Add(this.button_SavePrays);
			this.tabPage_Predator.Location = new global::System.Drawing.Point(4, 40);
			this.tabPage_Predator.Name = "tabPage_Predator";
			this.tabPage_Predator.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage_Predator.Size = new global::System.Drawing.Size(556, 626);
			this.tabPage_Predator.TabIndex = 18;
			this.tabPage_Predator.Text = "Predator";
			this.tabPage_Predator.UseVisualStyleBackColor = true;
			this.button_PredatorCopy.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.button_PredatorCopy.Location = new global::System.Drawing.Point(170, 23);
			this.button_PredatorCopy.Name = "button_PredatorCopy";
			this.button_PredatorCopy.Size = new global::System.Drawing.Size(92, 23);
			this.button_PredatorCopy.TabIndex = 14;
			this.button_PredatorCopy.Text = "Copy Settings";
			this.toolTip1.SetToolTip(this.button_PredatorCopy, "CTRL+Shift+C");
			this.button_PredatorCopy.UseVisualStyleBackColor = true;
			this.button_PredatorCopy.Click += new global::System.EventHandler(this.button_CopySettings_Click);
			this.button_PredatorHelp.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.button_PredatorHelp.Location = new global::System.Drawing.Point(328, 0);
			this.button_PredatorHelp.Name = "button_PredatorHelp";
			this.button_PredatorHelp.Size = new global::System.Drawing.Size(75, 23);
			this.button_PredatorHelp.TabIndex = 13;
			this.button_PredatorHelp.Text = "Help";
			this.button_PredatorHelp.UseVisualStyleBackColor = true;
			this.button_PredatorHelp.Click += new global::System.EventHandler(this.button_PredatorHelp_Click);
			this.tabControl_PredatorSettings.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.tabControl_PredatorSettings.Controls.Add(this.tabPage1);
			this.tabControl_PredatorSettings.Controls.Add(this.tabPage2);
			this.tabControl_PredatorSettings.Controls.Add(this.tabPage3);
			this.tabControl_PredatorSettings.Location = new global::System.Drawing.Point(0, 52);
			this.tabControl_PredatorSettings.Name = "tabControl_PredatorSettings";
			this.tabControl_PredatorSettings.SelectedIndex = 0;
			this.tabControl_PredatorSettings.Size = new global::System.Drawing.Size(556, 309);
			this.tabControl_PredatorSettings.TabIndex = 12;
			this.tabPage1.Controls.Add(this.dataGridView_PredatorPreys);
			this.tabPage1.Controls.Add(this.label_whatYouWannaHunt);
			this.tabPage1.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new global::System.Drawing.Size(548, 283);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Settings";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.dataGridView_PredatorPreys.AllowUserToAddRows = false;
			this.dataGridView_PredatorPreys.AllowUserToDeleteRows = false;
			this.dataGridView_PredatorPreys.AllowUserToResizeRows = false;
			this.dataGridView_PredatorPreys.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.dataGridView_PredatorPreys.AutoSizeRowsMode = global::System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridView_PredatorPreys.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_PredatorPreys.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.PreyType,
				this.PreyName,
				this.PreyHunt,
				this.MaxDistance,
				this.IncludeVassalHonourRange,
				this.IncludeCapitalHonourRange,
				this.NotifyWithMessage,
				this.NotifyWithSound,
				this.Kill,
				this.PredatorAttackFormation
			});
			this.dataGridView_PredatorPreys.Location = new global::System.Drawing.Point(0, 19);
			this.dataGridView_PredatorPreys.Name = "dataGridView_PredatorPreys";
			this.dataGridView_PredatorPreys.RowHeadersVisible = false;
			this.dataGridView_PredatorPreys.Size = new global::System.Drawing.Size(548, 264);
			this.dataGridView_PredatorPreys.TabIndex = 1;
			this.PreyType.HeaderText = "Prey Type";
			this.PreyType.Name = "PreyType";
			this.PreyType.ReadOnly = true;
			this.PreyType.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.PreyType.Visible = false;
			this.PreyName.HeaderText = "Prey";
			this.PreyName.Name = "PreyName";
			this.PreyName.ReadOnly = true;
			this.PreyName.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.PreyHunt.HeaderText = "Hunt";
			this.PreyHunt.Name = "PreyHunt";
			this.PreyHunt.Resizable = global::System.Windows.Forms.DataGridViewTriState.True;
			this.PreyHunt.Width = 70;
			this.MaxDistance.HeaderText = "Max Distance";
			this.MaxDistance.Name = "MaxDistance";
			this.MaxDistance.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.IncludeVassalHonourRange.HeaderText = "Search around vassal";
			this.IncludeVassalHonourRange.Name = "IncludeVassalHonourRange";
			this.IncludeCapitalHonourRange.HeaderText = "Search around capitals";
			this.IncludeCapitalHonourRange.Name = "IncludeCapitalHonourRange";
			this.NotifyWithMessage.HeaderText = "Notify With Message";
			this.NotifyWithMessage.Name = "NotifyWithMessage";
			this.NotifyWithSound.HeaderText = "Notify With Sound";
			this.NotifyWithSound.Name = "NotifyWithSound";
			this.Kill.HeaderText = "Kill";
			this.Kill.Name = "Kill";
			this.Kill.Width = 70;
			this.PredatorAttackFormation.HeaderText = "Formation";
			this.PredatorAttackFormation.Name = "PredatorAttackFormation";
			this.label_whatYouWannaHunt.AutoSize = true;
			this.label_whatYouWannaHunt.Location = new global::System.Drawing.Point(6, 3);
			this.label_whatYouWannaHunt.Name = "label_whatYouWannaHunt";
			this.label_whatYouWannaHunt.Size = new global::System.Drawing.Size(75, 13);
			this.label_whatYouWannaHunt.TabIndex = 3;
			this.label_whatYouWannaHunt.Text = "What to hunt?";
			this.tabPage2.Controls.Add(this.checkBox_PredatorCapitals);
			this.tabPage2.Controls.Add(this.checkBox_PredatorVassals);
			this.tabPage2.Controls.Add(this.checkBox_PredatorVillages);
			this.tabPage2.Controls.Add(this.label_PredatorCapitals);
			this.tabPage2.Controls.Add(this.label_PredatorVassals);
			this.tabPage2.Controls.Add(this.label_PredatorVillages);
			this.tabPage2.Controls.Add(this.listBox_PredatorCapitals);
			this.tabPage2.Controls.Add(this.listBox_PredatorVassals);
			this.tabPage2.Controls.Add(this.listBox_PredatorVillages);
			this.tabPage2.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new global::System.Drawing.Size(548, 283);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Hunters";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.checkBox_PredatorCapitals.AutoSize = true;
			this.checkBox_PredatorCapitals.Location = new global::System.Drawing.Point(527, 3);
			this.checkBox_PredatorCapitals.Name = "checkBox_PredatorCapitals";
			this.checkBox_PredatorCapitals.Size = new global::System.Drawing.Size(15, 14);
			this.checkBox_PredatorCapitals.TabIndex = 8;
			this.checkBox_PredatorCapitals.UseVisualStyleBackColor = true;
			this.checkBox_PredatorCapitals.CheckedChanged += new global::System.EventHandler(this.checkBox_PredatorCapitals_CheckedChanged);
			this.checkBox_PredatorVassals.AutoSize = true;
			this.checkBox_PredatorVassals.Location = new global::System.Drawing.Point(345, 3);
			this.checkBox_PredatorVassals.Name = "checkBox_PredatorVassals";
			this.checkBox_PredatorVassals.Size = new global::System.Drawing.Size(15, 14);
			this.checkBox_PredatorVassals.TabIndex = 7;
			this.checkBox_PredatorVassals.UseVisualStyleBackColor = true;
			this.checkBox_PredatorVassals.CheckedChanged += new global::System.EventHandler(this.checkBox_PredatorVassals_CheckedChanged);
			this.checkBox_PredatorVillages.AutoSize = true;
			this.checkBox_PredatorVillages.Location = new global::System.Drawing.Point(160, 3);
			this.checkBox_PredatorVillages.Name = "checkBox_PredatorVillages";
			this.checkBox_PredatorVillages.Size = new global::System.Drawing.Size(15, 14);
			this.checkBox_PredatorVillages.TabIndex = 6;
			this.checkBox_PredatorVillages.UseVisualStyleBackColor = true;
			this.checkBox_PredatorVillages.CheckedChanged += new global::System.EventHandler(this.checkBox_PredatorVillages_CheckedChanged);
			this.label_PredatorCapitals.AutoSize = true;
			this.label_PredatorCapitals.Location = new global::System.Drawing.Point(363, 3);
			this.label_PredatorCapitals.Name = "label_PredatorCapitals";
			this.label_PredatorCapitals.Size = new global::System.Drawing.Size(44, 13);
			this.label_PredatorCapitals.TabIndex = 5;
			this.label_PredatorCapitals.Text = "Capitals";
			this.label_PredatorVassals.AutoSize = true;
			this.label_PredatorVassals.Location = new global::System.Drawing.Point(181, 3);
			this.label_PredatorVassals.Name = "label_PredatorVassals";
			this.label_PredatorVassals.Size = new global::System.Drawing.Size(43, 13);
			this.label_PredatorVassals.TabIndex = 4;
			this.label_PredatorVassals.Text = "Vassals";
			this.label_PredatorVillages.AutoSize = true;
			this.label_PredatorVillages.Location = new global::System.Drawing.Point(2, 3);
			this.label_PredatorVillages.Name = "label_PredatorVillages";
			this.label_PredatorVillages.Size = new global::System.Drawing.Size(43, 13);
			this.label_PredatorVillages.TabIndex = 3;
			this.label_PredatorVillages.Text = "Villages";
			this.listBox_PredatorCapitals.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.listBox_PredatorCapitals.FormattingEnabled = true;
			this.listBox_PredatorCapitals.Location = new global::System.Drawing.Point(366, 19);
			this.listBox_PredatorCapitals.Name = "listBox_PredatorCapitals";
			this.listBox_PredatorCapitals.SelectionMode = global::System.Windows.Forms.SelectionMode.MultiSimple;
			this.listBox_PredatorCapitals.Size = new global::System.Drawing.Size(176, 264);
			this.listBox_PredatorCapitals.TabIndex = 2;
			this.listBox_PredatorCapitals.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.listBox_PredatorCapitals_MouseClick);
			this.listBox_PredatorVassals.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.listBox_PredatorVassals.FormattingEnabled = true;
			this.listBox_PredatorVassals.Location = new global::System.Drawing.Point(184, 19);
			this.listBox_PredatorVassals.Name = "listBox_PredatorVassals";
			this.listBox_PredatorVassals.SelectionMode = global::System.Windows.Forms.SelectionMode.MultiSimple;
			this.listBox_PredatorVassals.Size = new global::System.Drawing.Size(176, 264);
			this.listBox_PredatorVassals.TabIndex = 1;
			this.listBox_PredatorVassals.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.listBox_PredatorVassals_MouseClick);
			this.listBox_PredatorVillages.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.listBox_PredatorVillages.FormattingEnabled = true;
			this.listBox_PredatorVillages.Location = new global::System.Drawing.Point(2, 19);
			this.listBox_PredatorVillages.Name = "listBox_PredatorVillages";
			this.listBox_PredatorVillages.SelectionMode = global::System.Windows.Forms.SelectionMode.MultiSimple;
			this.listBox_PredatorVillages.Size = new global::System.Drawing.Size(176, 264);
			this.listBox_PredatorVillages.TabIndex = 0;
			this.listBox_PredatorVillages.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.listBox_PredatorVillages_MouseClick);
			this.tabPage3.Controls.Add(this.checkBox_HuntWithinParish);
			this.tabPage3.Controls.Add(this.checkBox_PredatorUseCastleTroops);
			this.tabPage3.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new global::System.Drawing.Size(548, 283);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Advanced Settings";
			this.tabPage3.UseVisualStyleBackColor = true;
			this.checkBox_HuntWithinParish.AutoSize = true;
			this.checkBox_HuntWithinParish.Location = new global::System.Drawing.Point(7, 29);
			this.checkBox_HuntWithinParish.Name = "checkBox_HuntWithinParish";
			this.checkBox_HuntWithinParish.Size = new global::System.Drawing.Size(156, 17);
			this.checkBox_HuntWithinParish.TabIndex = 14;
			this.checkBox_HuntWithinParish.Text = "Hunt within the same parish";
			this.checkBox_HuntWithinParish.UseVisualStyleBackColor = true;
			this.checkBox_HuntWithinParish.CheckedChanged += new global::System.EventHandler(this.checkBox_HuntWithinParish_CheckedChanged);
			this.checkBox_PredatorUseCastleTroops.AutoSize = true;
			this.checkBox_PredatorUseCastleTroops.Location = new global::System.Drawing.Point(7, 6);
			this.checkBox_PredatorUseCastleTroops.Name = "checkBox_PredatorUseCastleTroops";
			this.checkBox_PredatorUseCastleTroops.Size = new global::System.Drawing.Size(108, 17);
			this.checkBox_PredatorUseCastleTroops.TabIndex = 13;
			this.checkBox_PredatorUseCastleTroops.Text = "Use castle troops";
			this.checkBox_PredatorUseCastleTroops.UseVisualStyleBackColor = true;
			this.checkBox_PredatorUseCastleTroops.CheckedChanged += new global::System.EventHandler(this.checkBox_PredatorUseCastleTroops_CheckedChanged);
			this.tabControl_Predator.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.tabControl_Predator.Controls.Add(this.tabPage_FoundPreys);
			this.tabControl_Predator.Controls.Add(this.tabPage_Logs);
			this.tabControl_Predator.Location = new global::System.Drawing.Point(0, 367);
			this.tabControl_Predator.Name = "tabControl_Predator";
			this.tabControl_Predator.SelectedIndex = 0;
			this.tabControl_Predator.Size = new global::System.Drawing.Size(556, 259);
			this.tabControl_Predator.TabIndex = 11;
			this.tabPage_FoundPreys.Controls.Add(this.button_UpdateCapitalsSpeed2);
			this.tabPage_FoundPreys.Controls.Add(this.dataGridView_FoundPreys);
			this.tabPage_FoundPreys.Controls.Add(this.button_ClearPreys);
			this.tabPage_FoundPreys.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage_FoundPreys.Name = "tabPage_FoundPreys";
			this.tabPage_FoundPreys.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage_FoundPreys.Size = new global::System.Drawing.Size(548, 233);
			this.tabPage_FoundPreys.TabIndex = 0;
			this.tabPage_FoundPreys.Text = "Found Preys";
			this.tabPage_FoundPreys.UseVisualStyleBackColor = true;
			this.button_UpdateCapitalsSpeed2.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.button_UpdateCapitalsSpeed2.Location = new global::System.Drawing.Point(251, 0);
			this.button_UpdateCapitalsSpeed2.Name = "button_UpdateCapitalsSpeed2";
			this.button_UpdateCapitalsSpeed2.Size = new global::System.Drawing.Size(199, 23);
			this.button_UpdateCapitalsSpeed2.TabIndex = 9;
			this.button_UpdateCapitalsSpeed2.Text = "Update Capitals Army Speed";
			this.button_UpdateCapitalsSpeed2.UseVisualStyleBackColor = true;
			this.button_UpdateCapitalsSpeed2.Click += new global::System.EventHandler(this.button_UpdateCapitalsSpeed_Click);
			this.dataGridView_FoundPreys.AllowUserToAddRows = false;
			this.dataGridView_FoundPreys.AllowUserToDeleteRows = false;
			this.dataGridView_FoundPreys.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.dataGridView_FoundPreys.AutoSizeColumnsMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView_FoundPreys.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_FoundPreys.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.PreyId,
				this.Prey,
				this.PreyDistance,
				this.PreyNextTo,
				this.PreyTime
			});
			this.dataGridView_FoundPreys.Location = new global::System.Drawing.Point(0, 23);
			this.dataGridView_FoundPreys.Name = "dataGridView_FoundPreys";
			this.dataGridView_FoundPreys.ReadOnly = true;
			this.dataGridView_FoundPreys.RowHeadersVisible = false;
			this.dataGridView_FoundPreys.Size = new global::System.Drawing.Size(548, 210);
			this.dataGridView_FoundPreys.TabIndex = 2;
			this.PreyId.HeaderText = "Id";
			this.PreyId.Name = "PreyId";
			this.PreyId.ReadOnly = true;
			this.Prey.HeaderText = "Prey";
			this.Prey.Name = "Prey";
			this.Prey.ReadOnly = true;
			this.PreyDistance.HeaderText = "Distance";
			this.PreyDistance.Name = "PreyDistance";
			this.PreyDistance.ReadOnly = true;
			this.PreyNextTo.HeaderText = "Next to";
			this.PreyNextTo.Name = "PreyNextTo";
			this.PreyNextTo.ReadOnly = true;
			this.PreyTime.HeaderText = "Time";
			this.PreyTime.Name = "PreyTime";
			this.PreyTime.ReadOnly = true;
			this.button_ClearPreys.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.button_ClearPreys.Location = new global::System.Drawing.Point(456, 0);
			this.button_ClearPreys.Name = "button_ClearPreys";
			this.button_ClearPreys.Size = new global::System.Drawing.Size(92, 23);
			this.button_ClearPreys.TabIndex = 8;
			this.button_ClearPreys.Text = "Clear";
			this.button_ClearPreys.UseVisualStyleBackColor = true;
			this.button_ClearPreys.Click += new global::System.EventHandler(this.button_PredatorClearPreys_Click);
			this.tabPage_Logs.Controls.Add(this.richTextBoxPredator);
			this.tabPage_Logs.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage_Logs.Name = "tabPage_Logs";
			this.tabPage_Logs.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage_Logs.Size = new global::System.Drawing.Size(548, 233);
			this.tabPage_Logs.TabIndex = 1;
			this.tabPage_Logs.Text = "Logs";
			this.tabPage_Logs.UseVisualStyleBackColor = true;
			this.richTextBoxPredator.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.richTextBoxPredator.Location = new global::System.Drawing.Point(3, 3);
			this.richTextBoxPredator.Name = "richTextBoxPredator";
			this.richTextBoxPredator.ReadOnly = true;
			this.richTextBoxPredator.Size = new global::System.Drawing.Size(542, 227);
			this.richTextBoxPredator.TabIndex = 0;
			this.richTextBoxPredator.Text = "";
			this.button_PredatorUpdatePresets.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.button_PredatorUpdatePresets.Location = new global::System.Drawing.Point(409, 0);
			this.button_PredatorUpdatePresets.Name = "button_PredatorUpdatePresets";
			this.button_PredatorUpdatePresets.Size = new global::System.Drawing.Size(147, 23);
			this.button_PredatorUpdatePresets.TabIndex = 10;
			this.button_PredatorUpdatePresets.Text = "Update Formations";
			this.button_PredatorUpdatePresets.UseVisualStyleBackColor = true;
			this.button_PredatorUpdatePresets.Click += new global::System.EventHandler(this.button_PredatorUpdatePresets_Click);
			this.button_predatorStopSound.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.button_predatorStopSound.Location = new global::System.Drawing.Point(268, 23);
			this.button_predatorStopSound.Name = "button_predatorStopSound";
			this.button_predatorStopSound.Size = new global::System.Drawing.Size(92, 23);
			this.button_predatorStopSound.TabIndex = 9;
			this.button_predatorStopSound.Text = "Stop sound";
			this.button_predatorStopSound.UseVisualStyleBackColor = true;
			this.button_predatorStopSound.Click += new global::System.EventHandler(this.button_predatorStopSound_Click);
			this.checkBox_StartHunting.AutoSize = true;
			this.checkBox_StartHunting.Location = new global::System.Drawing.Point(11, 6);
			this.checkBox_StartHunting.Name = "checkBox_StartHunting";
			this.checkBox_StartHunting.Size = new global::System.Drawing.Size(91, 17);
			this.checkBox_StartHunting.TabIndex = 7;
			this.checkBox_StartHunting.Text = "Start Hunting!";
			this.checkBox_StartHunting.UseVisualStyleBackColor = true;
			this.checkBox_StartHunting.CheckedChanged += new global::System.EventHandler(this.checkBox_StartHunting_CheckedChanged);
			this.button_LoadPrays.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.button_LoadPrays.Location = new global::System.Drawing.Point(464, 23);
			this.button_LoadPrays.Name = "button_LoadPrays";
			this.button_LoadPrays.Size = new global::System.Drawing.Size(92, 23);
			this.button_LoadPrays.TabIndex = 6;
			this.button_LoadPrays.Text = "Load";
			this.button_LoadPrays.UseVisualStyleBackColor = true;
			this.button_LoadPrays.Click += new global::System.EventHandler(this.button_LoadPrays_Click);
			this.button_SavePrays.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.button_SavePrays.Location = new global::System.Drawing.Point(366, 23);
			this.button_SavePrays.Name = "button_SavePrays";
			this.button_SavePrays.Size = new global::System.Drawing.Size(92, 23);
			this.button_SavePrays.TabIndex = 5;
			this.button_SavePrays.Text = "Save";
			this.button_SavePrays.UseVisualStyleBackColor = true;
			this.button_SavePrays.Click += new global::System.EventHandler(this.button_SavePrays_Click);
			this.tabPage_TimedAttacks.Controls.Add(this.button_TimingHelp);
			this.tabPage_TimedAttacks.Controls.Add(this.listBox1);
			this.tabPage_TimedAttacks.Controls.Add(this.button1);
			this.tabPage_TimedAttacks.Controls.Add(this.button_UpdateCapitalsSpeed);
			this.tabPage_TimedAttacks.Controls.Add(this.richTextBoxTimedAttacks);
			this.tabPage_TimedAttacks.Controls.Add(this.label_TimedAttacksTargetId);
			this.tabPage_TimedAttacks.Controls.Add(this.textBox_getAttackersTarget);
			this.tabPage_TimedAttacks.Controls.Add(this.btnGetAttackers);
			this.tabPage_TimedAttacks.Location = new global::System.Drawing.Point(4, 40);
			this.tabPage_TimedAttacks.Name = "tabPage_TimedAttacks";
			this.tabPage_TimedAttacks.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage_TimedAttacks.Size = new global::System.Drawing.Size(556, 626);
			this.tabPage_TimedAttacks.TabIndex = 19;
			this.tabPage_TimedAttacks.Text = "Timing";
			this.tabPage_TimedAttacks.UseVisualStyleBackColor = true;
			this.button_TimingHelp.Location = new global::System.Drawing.Point(9, 88);
			this.button_TimingHelp.Name = "button_TimingHelp";
			this.button_TimingHelp.Size = new global::System.Drawing.Size(75, 23);
			this.button_TimingHelp.TabIndex = 80;
			this.button_TimingHelp.Text = "Help";
			this.button_TimingHelp.UseVisualStyleBackColor = true;
			this.button_TimingHelp.Click += new global::System.EventHandler(this.button_TimingHelp_Click);
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new global::System.Drawing.Point(406, 6);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new global::System.Drawing.Size(120, 303);
			this.listBox1.TabIndex = 79;
			this.listBox1.Visible = false;
			this.listBox1.SelectedIndexChanged += new global::System.EventHandler(this.ListBox1_SelectedIndexChanged);
			this.button_UpdateCapitalsSpeed.Location = new global::System.Drawing.Point(9, 29);
			this.button_UpdateCapitalsSpeed.Name = "button_UpdateCapitalsSpeed";
			this.button_UpdateCapitalsSpeed.Size = new global::System.Drawing.Size(199, 23);
			this.button_UpdateCapitalsSpeed.TabIndex = 71;
			this.button_UpdateCapitalsSpeed.Text = "Update Capitals Army Speed";
			this.button_UpdateCapitalsSpeed.UseVisualStyleBackColor = true;
			this.button_UpdateCapitalsSpeed.Click += new global::System.EventHandler(this.button_UpdateCapitalsSpeed_Click);
			this.richTextBoxTimedAttacks.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.richTextBoxTimedAttacks.Location = new global::System.Drawing.Point(6, 321);
			this.richTextBoxTimedAttacks.Name = "richTextBoxTimedAttacks";
			this.richTextBoxTimedAttacks.ReadOnly = true;
			this.richTextBoxTimedAttacks.Size = new global::System.Drawing.Size(547, 297);
			this.richTextBoxTimedAttacks.TabIndex = 70;
			this.richTextBoxTimedAttacks.Text = "";
			this.label_TimedAttacksTargetId.AutoSize = true;
			this.label_TimedAttacksTargetId.Location = new global::System.Drawing.Point(6, 6);
			this.label_TimedAttacksTargetId.Name = "label_TimedAttacksTargetId";
			this.label_TimedAttacksTargetId.Size = new global::System.Drawing.Size(122, 13);
			this.label_TimedAttacksTargetId.TabIndex = 68;
			this.label_TimedAttacksTargetId.Text = "Enter village Id of target:";
			this.textBox_getAttackersTarget.Location = new global::System.Drawing.Point(168, 3);
			this.textBox_getAttackersTarget.Name = "textBox_getAttackersTarget";
			this.textBox_getAttackersTarget.Size = new global::System.Drawing.Size(74, 20);
			this.textBox_getAttackersTarget.TabIndex = 67;
			this.btnGetAttackers.Location = new global::System.Drawing.Point(9, 58);
			this.btnGetAttackers.Name = "btnGetAttackers";
			this.btnGetAttackers.Size = new global::System.Drawing.Size(147, 23);
			this.btnGetAttackers.TabIndex = 66;
			this.btnGetAttackers.Text = "Calculate Attack Times";
			this.btnGetAttackers.UseVisualStyleBackColor = true;
			this.btnGetAttackers.Click += new global::System.EventHandler(this.btnGetAttackers_Click);
			this.tabPage_Monks.Controls.Add(this.numericUpDown_KeepMonks);
			this.tabPage_Monks.Controls.Add(this.label_KeepMonks);
			this.tabPage_Monks.Controls.Add(this.dataGridView_Monks);
			this.tabPage_Monks.Controls.Add(this.button_HelpMonks);
			this.tabPage_Monks.Controls.Add(this.button_LoadMonks);
			this.tabPage_Monks.Controls.Add(this.checkBox_EnableMonks);
			this.tabPage_Monks.Controls.Add(this.button_SaveMonks);
			this.tabPage_Monks.Controls.Add(this.richTextBoxMonks);
			this.tabPage_Monks.Location = new global::System.Drawing.Point(4, 40);
			this.tabPage_Monks.Name = "tabPage_Monks";
			this.tabPage_Monks.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage_Monks.Size = new global::System.Drawing.Size(556, 626);
			this.tabPage_Monks.TabIndex = 23;
			this.tabPage_Monks.Text = "Monks";
			this.tabPage_Monks.UseVisualStyleBackColor = true;
			this.numericUpDown_KeepMonks.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.numericUpDown_KeepMonks.Location = new global::System.Drawing.Point(218, 397);
			global::System.Windows.Forms.NumericUpDown numericUpDown54 = this.numericUpDown_KeepMonks;
			int[] array54 = new int[4];
			array54[0] = 7;
			numericUpDown54.Maximum = new decimal(array54);
			this.numericUpDown_KeepMonks.Name = "numericUpDown_KeepMonks";
			this.numericUpDown_KeepMonks.Size = new global::System.Drawing.Size(40, 20);
			this.numericUpDown_KeepMonks.TabIndex = 7;
			global::System.Windows.Forms.NumericUpDown numericUpDown55 = this.numericUpDown_KeepMonks;
			int[] array55 = new int[4];
			array55[0] = 1;
			numericUpDown55.Value = new decimal(array55);
			this.numericUpDown_KeepMonks.ValueChanged += new global::System.EventHandler(this.numericUpDown_KeepMonks_ValueChanged);
			this.label_KeepMonks.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.label_KeepMonks.AutoSize = true;
			this.label_KeepMonks.Location = new global::System.Drawing.Point(9, 399);
			this.label_KeepMonks.Name = "label_KeepMonks";
			this.label_KeepMonks.Size = new global::System.Drawing.Size(195, 13);
			this.label_KeepMonks.TabIndex = 6;
			this.label_KeepMonks.Text = "How many monks to keep in the village:";
			this.dataGridView_Monks.AllowUserToAddRows = false;
			this.dataGridView_Monks.AllowUserToDeleteRows = false;
			this.dataGridView_Monks.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.dataGridView_Monks.AutoSizeRowsMode = global::System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridView_Monks.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_Monks.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.MonkRouteName,
				this.MonkRouteEnabled,
				this.MonkRouteVillages,
				this.MonkRouteTargets,
				this.MonkRouteCommand,
				this.MonkRouteStopCondition,
				this.MonkRouteParameter,
				this.MonkRouteIsDistanceLimited,
				this.MonkRouteDistanceLimit
			});
			this.dataGridView_Monks.ContextMenuStrip = this.contextMenu_MonkRoutes;
			this.dataGridView_Monks.Location = new global::System.Drawing.Point(3, 35);
			this.dataGridView_Monks.Name = "dataGridView_Monks";
			this.dataGridView_Monks.RowHeadersVisible = false;
			this.dataGridView_Monks.SelectionMode = global::System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView_Monks.Size = new global::System.Drawing.Size(547, 359);
			this.dataGridView_Monks.TabIndex = 5;
			this.dataGridView_Monks.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.DataGridView_Monks_MouseUp);
			this.MonkRouteName.HeaderText = "Name";
			this.MonkRouteName.Name = "MonkRouteName";
			this.MonkRouteName.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.MonkRouteEnabled.HeaderText = "Enabled";
			this.MonkRouteEnabled.Name = "MonkRouteEnabled";
			this.MonkRouteVillages.HeaderText = "Villages";
			this.MonkRouteVillages.Name = "MonkRouteVillages";
			this.MonkRouteVillages.ReadOnly = true;
			this.MonkRouteVillages.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.MonkRouteTargets.HeaderText = "Targets";
			this.MonkRouteTargets.Name = "MonkRouteTargets";
			this.MonkRouteTargets.ReadOnly = true;
			this.MonkRouteTargets.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.MonkRouteCommand.HeaderText = "Command";
			this.MonkRouteCommand.Name = "MonkRouteCommand";
			this.MonkRouteCommand.ReadOnly = true;
			this.MonkRouteCommand.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.MonkRouteStopCondition.HeaderText = "Stop Condition";
			this.MonkRouteStopCondition.Name = "MonkRouteStopCondition";
			this.MonkRouteStopCondition.ReadOnly = true;
			this.MonkRouteStopCondition.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.MonkRouteParameter.HeaderText = "Parameter";
			this.MonkRouteParameter.Name = "MonkRouteParameter";
			this.MonkRouteParameter.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.MonkRouteIsDistanceLimited.HeaderText = "Is Distance Limited";
			this.MonkRouteIsDistanceLimited.Name = "MonkRouteIsDistanceLimited";
			this.MonkRouteDistanceLimit.HeaderText = "Distance Limit";
			this.MonkRouteDistanceLimit.Name = "MonkRouteDistanceLimit";
			this.MonkRouteDistanceLimit.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.contextMenu_MonkRoutes.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.toolStripMenuItem1,
				this.toolStripMenuItem2,
				this.toolStripMenuItem3,
				this.toolStripMenuItem4
			});
			this.contextMenu_MonkRoutes.Name = "contextMenu_MonkRoutes";
			this.contextMenu_MonkRoutes.Size = new global::System.Drawing.Size(134, 92);
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new global::System.Drawing.Size(133, 22);
			this.toolStripMenuItem1.Text = "Create new";
			this.toolStripMenuItem1.Click += new global::System.EventHandler(this.ToolStripMenuItem1_Click);
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new global::System.Drawing.Size(133, 22);
			this.toolStripMenuItem2.Text = "Edit";
			this.toolStripMenuItem2.Click += new global::System.EventHandler(this.ToolStripMenuItem2_Click);
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new global::System.Drawing.Size(133, 22);
			this.toolStripMenuItem3.Text = "Delete";
			this.toolStripMenuItem3.Click += new global::System.EventHandler(this.ToolStripMenuItem3_Click);
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new global::System.Drawing.Size(133, 22);
			this.toolStripMenuItem4.Text = "Copy";
			this.toolStripMenuItem4.Click += new global::System.EventHandler(this.ToolStripMenuItem4_Click);
			this.button_HelpMonks.Location = new global::System.Drawing.Point(316, 6);
			this.button_HelpMonks.Name = "button_HelpMonks";
			this.button_HelpMonks.Size = new global::System.Drawing.Size(95, 23);
			this.button_HelpMonks.TabIndex = 4;
			this.button_HelpMonks.Text = "Help";
			this.button_HelpMonks.UseVisualStyleBackColor = true;
			this.button_HelpMonks.Click += new global::System.EventHandler(this.Button_HelpMonks_Click);
			this.button_LoadMonks.Location = new global::System.Drawing.Point(216, 6);
			this.button_LoadMonks.Name = "button_LoadMonks";
			this.button_LoadMonks.Size = new global::System.Drawing.Size(94, 23);
			this.button_LoadMonks.TabIndex = 3;
			this.button_LoadMonks.Text = "Load";
			this.button_LoadMonks.UseVisualStyleBackColor = true;
			this.button_LoadMonks.Click += new global::System.EventHandler(this.Button_LoadMonks_Click);
			this.checkBox_EnableMonks.AutoSize = true;
			this.checkBox_EnableMonks.Location = new global::System.Drawing.Point(8, 6);
			this.checkBox_EnableMonks.Name = "checkBox_EnableMonks";
			this.checkBox_EnableMonks.Size = new global::System.Drawing.Size(87, 17);
			this.checkBox_EnableMonks.TabIndex = 2;
			this.checkBox_EnableMonks.Text = "Turn On | Off";
			this.checkBox_EnableMonks.UseVisualStyleBackColor = true;
			this.checkBox_EnableMonks.CheckedChanged += new global::System.EventHandler(this.CheckBox_EnableMonks_CheckedChanged);
			this.button_SaveMonks.Location = new global::System.Drawing.Point(115, 6);
			this.button_SaveMonks.Name = "button_SaveMonks";
			this.button_SaveMonks.Size = new global::System.Drawing.Size(95, 23);
			this.button_SaveMonks.TabIndex = 1;
			this.button_SaveMonks.Text = "Save";
			this.button_SaveMonks.UseVisualStyleBackColor = true;
			this.button_SaveMonks.Click += new global::System.EventHandler(this.Button_SaveMonks_Click);
			this.richTextBoxMonks.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.richTextBoxMonks.Location = new global::System.Drawing.Point(3, 418);
			this.richTextBoxMonks.Name = "richTextBoxMonks";
			this.richTextBoxMonks.ReadOnly = true;
			this.richTextBoxMonks.Size = new global::System.Drawing.Size(550, 205);
			this.richTextBoxMonks.TabIndex = 0;
			this.richTextBoxMonks.Text = "";
			this.tabPage_Error.Controls.Add(this.button_ClearErrors);
			this.tabPage_Error.Controls.Add(this.richTextBox_Errors);
			this.tabPage_Error.Location = new global::System.Drawing.Point(4, 40);
			this.tabPage_Error.Name = "tabPage_Error";
			this.tabPage_Error.Size = new global::System.Drawing.Size(556, 626);
			this.tabPage_Error.TabIndex = 25;
			this.tabPage_Error.Text = "Errors";
			this.tabPage_Error.UseVisualStyleBackColor = true;
			this.button_ClearErrors.Location = new global::System.Drawing.Point(435, 3);
			this.button_ClearErrors.Name = "button_ClearErrors";
			this.button_ClearErrors.Size = new global::System.Drawing.Size(118, 23);
			this.button_ClearErrors.TabIndex = 1;
			this.button_ClearErrors.Text = "Clear";
			this.button_ClearErrors.UseVisualStyleBackColor = true;
			this.button_ClearErrors.Click += new global::System.EventHandler(this.button_ClearErrors_Click);
			this.richTextBox_Errors.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.richTextBox_Errors.Location = new global::System.Drawing.Point(0, 29);
			this.richTextBox_Errors.Name = "richTextBox_Errors";
			this.richTextBox_Errors.ReadOnly = true;
			this.richTextBox_Errors.Size = new global::System.Drawing.Size(556, 597);
			this.richTextBox_Errors.TabIndex = 0;
			this.richTextBox_Errors.Text = "";
			this.label_Contacts.AutoSize = true;
			this.label_Contacts.Location = new global::System.Drawing.Point(7, 6);
			this.label_Contacts.Name = "label_Contacts";
			this.label_Contacts.Size = new global::System.Drawing.Size(182, 13);
			this.label_Contacts.TabIndex = 22;
			this.label_Contacts.Text = "For any questions please address to: ";
			this.linkLabel_botSiteLink.AutoSize = true;
			this.linkLabel_botSiteLink.Location = new global::System.Drawing.Point(221, 19);
			this.linkLabel_botSiteLink.Name = "linkLabel_botSiteLink";
			this.linkLabel_botSiteLink.Size = new global::System.Drawing.Size(61, 13);
			this.linkLabel_botSiteLink.TabIndex = 24;
			this.linkLabel_botSiteLink.TabStop = true;
			this.linkLabel_botSiteLink.Text = "our website";
			this.linkLabel_botSiteLink.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			this.label_contributions.AutoSize = true;
			this.label_contributions.Location = new global::System.Drawing.Point(8, 20);
			this.label_contributions.Name = "label_contributions";
			this.label_contributions.Size = new global::System.Drawing.Size(142, 13);
			this.label_contributions.TabIndex = 73;
			this.label_contributions.Text = "Contributions can be sent to:";
			this.textBox_contactEmail.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.textBox_contactEmail.Location = new global::System.Drawing.Point(223, 6);
			this.textBox_contactEmail.Name = "textBox_contactEmail";
			this.textBox_contactEmail.ReadOnly = true;
			this.textBox_contactEmail.Size = new global::System.Drawing.Size(140, 13);
			this.textBox_contactEmail.TabIndex = 74;
			this.textBox_contactEmail.Text = "SHKEducations@gmail.com";
			this.button_PauseEveryThing.Location = new global::System.Drawing.Point(430, 9);
			this.button_PauseEveryThing.Name = "button_PauseEveryThing";
			this.button_PauseEveryThing.Size = new global::System.Drawing.Size(122, 23);
			this.button_PauseEveryThing.TabIndex = 75;
			this.button_PauseEveryThing.Text = "Stop All Modules!";
			this.button_PauseEveryThing.UseVisualStyleBackColor = true;
			this.button_PauseEveryThing.Click += new global::System.EventHandler(this.Button_PauseEveryThing_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(564, 703);
			base.Controls.Add(this.button_PauseEveryThing);
			base.Controls.Add(this.textBox_contactEmail);
			base.Controls.Add(this.label_contributions);
			base.Controls.Add(this.linkLabel_botSiteLink);
			base.Controls.Add(this.label_Contacts);
			base.Controls.Add(this.tabControl1);
			base.MaximizeBox = false;
			this.MinimumSize = new global::System.Drawing.Size(580, 742);
			base.Name = "ControlForm";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.BotForm_FormClosing);
			base.Load += new global::System.EventHandler(this.ControlForm_Load);
			this.tabPage_Trade.ResumeLayout(false);
			this.tabPage_Trade.PerformLayout();
			this.tabControl_Trade.ResumeLayout(false);
			this.tabPage_TradeMarkets.ResumeLayout(false);
			this.tabPage_TradeMarkets.PerformLayout();
			this.splitContainer_Trade.Panel1.ResumeLayout(false);
			this.splitContainer_Trade.Panel2.ResumeLayout(false);
			this.splitContainer_Trade.ResumeLayout(false);
			this.groupBox_TradingVillage.ResumeLayout(false);
			this.groupBox_TradingVillage.PerformLayout();
			this.splitContainer_Trade2.Panel1.ResumeLayout(false);
			this.splitContainer_Trade2.Panel2.ResumeLayout(false);
			this.splitContainer_Trade2.Panel2.PerformLayout();
			this.splitContainer_Trade2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView_Trade).EndInit();
			this.contextMenuStrip_ResourcesQuickSelector.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_MarketsRadius).EndInit();
			this.tabPage_TradeBetweenVillages.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView_TradeRoutes).EndInit();
			this.contextMenu_TradeRoutes.ResumeLayout(false);
			this.tabPage_TradeAdvanced.ResumeLayout(false);
			this.tabPage_TradeAdvanced.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_MerchantsExchangeLimit).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_MerchantsTradeLimit).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_AutoHireMerchantsLimit).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_PacketsPerTrade).EndInit();
			this.tabPage_TradeLogs.ResumeLayout(false);
			this.tabPage_Research.ResumeLayout(false);
			this.tabPage_Research.PerformLayout();
			this.tabPage_Scouting.ResumeLayout(false);
			this.tabPage_Scouting.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_minScouts).EndInit();
			this.groupBox_ScoutingVillage.ResumeLayout(false);
			this.groupBox_ScoutingVillage.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_ScoutMaxTime).EndInit();
			this.tabPage_Main.ResumeLayout(false);
			this.tabPage_Main.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_LogsToKeep).EndInit();
			this.groupBox_BotLifeCycle.ResumeLayout(false);
			this.groupBox_BotLifeCycle.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_BotWorkPeriod).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_BotSleepPeriod).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage_Feed.ResumeLayout(false);
			this.tabPage_Feed.PerformLayout();
			this.tabPage_AutomaticActions.ResumeLayout(false);
			this.tabPage_AutomaticActions.PerformLayout();
			this.tabPage_Refresh.ResumeLayout(false);
			this.tabPage_Refresh.PerformLayout();
			this.tabPage_FreeMonitor.ResumeLayout(false);
			this.tabPage_FreeMonitor.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView_FreeMonitor).EndInit();
			this.tabPage_Radar.ResumeLayout(false);
			this.tabPage_Radar.PerformLayout();
			this.tabControl2.ResumeLayout(false);
			this.tabPage_RadarMain.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView_RadarSettings).EndInit();
			this.tabPage_Interdict.ResumeLayout(false);
			this.tabPage_Interdict.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_InterdictNumberOfMonks).EndInit();
			this.tabPage_RadarEmail.ResumeLayout(false);
			this.tabPage_RadarEmail.PerformLayout();
			this.tabPage_RadarDiscord.ResumeLayout(false);
			this.tabPage_RadarDiscord.PerformLayout();
			this.tabPage_RadarTelegram.ResumeLayout(false);
			this.tabPage_RadarTelegram.PerformLayout();
			this.groupBox_TelegramProxy.ResumeLayout(false);
			this.groupBox_TelegramProxy.PerformLayout();
			this.tabPage_RadarTest.ResumeLayout(false);
			this.tabPage_AltAccounts.ResumeLayout(false);
			this.tabPage_AltAccounts.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_RadarFindByID).EndInit();
			this.tabPage_RadarAutoID.ResumeLayout(false);
			this.tabPage_RadarAutoID.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_RadarAutoID).EndInit();
			this.tabPage_Troopsrecruiting.ResumeLayout(false);
			this.tabPage_Troopsrecruiting.PerformLayout();
			this.tabControl_TroopsRecruiting.ResumeLayout(false);
			this.tabPage_VillagesTroopsRecruiting.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView_TroopsRecruiting).EndInit();
			this.tabPage_CapitalsTroopsRecruiting.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView_CapitalsRecruiting).EndInit();
			this.tabPage_VassalsTroopsRecruiting.ResumeLayout(false);
			this.tabPage_VassalsTroopsRecruiting.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_VassalTroopsMinimum).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView_FillVassals).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown2).EndInit();
			this.tabPage_Spin.ResumeLayout(false);
			this.tabPage_Spin.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_SpinInterval).EndInit();
			this.tabPage_Banquet.ResumeLayout(false);
			this.tabPage_Banquet.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView_Banquets).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numeric_BanquetInterval).EndInit();
			this.tabPage_PopularityRegulation.ResumeLayout(false);
			this.tabPage_PopularityRegulation.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_PopularityRegulation).EndInit();
			this.tabPage_Villagelayout.ResumeLayout(false);
			this.tabControl_VillageLayouts.ResumeLayout(false);
			this.tabPage_villageLayouts.ResumeLayout(false);
			this.tabPage_villageLayouts.PerformLayout();
			this.groupBox_villageLayoutsNavigation.ResumeLayout(false);
			this.groupBox_VillageLayoutsSettings.ResumeLayout(false);
			this.groupBox_VillageLayoutsSettings.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_VillageLayoutInterval).EndInit();
			this.groupBox_SelectedLayout.ResumeLayout(false);
			this.groupBox_SelectedLayout.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridViewVillageLayoutsEdit).EndInit();
			this.tabPage_villageLayoutsLogs.ResumeLayout(false);
			this.tabPage_Castle.ResumeLayout(false);
			this.tabPage_Castle.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView_RepairCastle).EndInit();
			this.tabPage_Predator.ResumeLayout(false);
			this.tabPage_Predator.PerformLayout();
			this.tabControl_PredatorSettings.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView_PredatorPreys).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.tabControl_Predator.ResumeLayout(false);
			this.tabPage_FoundPreys.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView_FoundPreys).EndInit();
			this.tabPage_Logs.ResumeLayout(false);
			this.tabPage_TimedAttacks.ResumeLayout(false);
			this.tabPage_TimedAttacks.PerformLayout();
			this.tabPage_Monks.ResumeLayout(false);
			this.tabPage_Monks.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_KeepMonks).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView_Monks).EndInit();
			this.contextMenu_MonkRoutes.ResumeLayout(false);
			this.tabPage_Error.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000088 RID: 136
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000089 RID: 137
		private global::System.Windows.Forms.TabPage tabPage_Trade;

		// Token: 0x0400008A RID: 138
		private global::System.Windows.Forms.Button button4;

		// Token: 0x0400008B RID: 139
		private global::System.Windows.Forms.Button button5;

		// Token: 0x0400008C RID: 140
		private global::System.Windows.Forms.Label label27;

		// Token: 0x0400008D RID: 141
		private global::System.Windows.Forms.ListBox listBox_ActiveVillages;

		// Token: 0x0400008E RID: 142
		private global::System.Windows.Forms.TabPage tabPage_Research;

		// Token: 0x0400008F RID: 143
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000090 RID: 144
		private global::System.Windows.Forms.TextBox textBox_CurrentResearch;

		// Token: 0x04000091 RID: 145
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000092 RID: 146
		private global::System.Windows.Forms.ListBox listBox_Queue;

		// Token: 0x04000093 RID: 147
		private global::System.Windows.Forms.ListBox listBox_ResearchList;

		// Token: 0x04000094 RID: 148
		private global::System.Windows.Forms.TabPage tabPage_Scouting;

		// Token: 0x04000095 RID: 149
		private global::System.Windows.Forms.Label label18;

		// Token: 0x04000096 RID: 150
		private global::System.Windows.Forms.Label label12;

		// Token: 0x04000097 RID: 151
		private global::System.Windows.Forms.Label label_scoutFrom;

		// Token: 0x04000098 RID: 152
		private global::System.Windows.Forms.ListBox listBox_scoutFrom;

		// Token: 0x04000099 RID: 153
		private global::System.Windows.Forms.TabPage tabPage_Main;

		// Token: 0x0400009A RID: 154
		private global::System.Windows.Forms.TabControl tabControl1;

		// Token: 0x0400009B RID: 155
		private global::System.Windows.Forms.TabPage tabPage_Banquet;

		// Token: 0x0400009C RID: 156
		private global::System.Windows.Forms.CheckBox PlayBanquets;

		// Token: 0x0400009D RID: 157
		private global::System.Windows.Forms.Label label7;

		// Token: 0x0400009E RID: 158
		private global::System.Windows.Forms.TabPage tabPage_PopularityRegulation;

		// Token: 0x0400009F RID: 159
		private global::System.Windows.Forms.CheckBox RegulatePopularity;

		// Token: 0x040000A0 RID: 160
		private global::System.Windows.Forms.Label label14;

		// Token: 0x040000A1 RID: 161
		private global::System.Windows.Forms.RichTextBox richTextBoxTrade;

		// Token: 0x040000A2 RID: 162
		private global::System.Windows.Forms.RichTextBox richTextBoxResearch;

		// Token: 0x040000A3 RID: 163
		private global::System.Windows.Forms.RichTextBox richTextBoxScout;

		// Token: 0x040000A4 RID: 164
		private global::System.Windows.Forms.RichTextBox richTextBoxMain;

		// Token: 0x040000A5 RID: 165
		private global::System.Windows.Forms.RichTextBox richTextBoxBanquetting;

		// Token: 0x040000A6 RID: 166
		private global::System.Windows.Forms.RichTextBox richTextBoxPopularityRegulation;

		// Token: 0x040000A7 RID: 167
		private global::System.Windows.Forms.TabPage tabPage_Troopsrecruiting;

		// Token: 0x040000A8 RID: 168
		private global::System.Windows.Forms.RichTextBox richTextBoxTroopsRecruiting;

		// Token: 0x040000A9 RID: 169
		private global::System.Windows.Forms.DataGridView dataGridView_TroopsRecruiting;

		// Token: 0x040000AA RID: 170
		private global::System.Windows.Forms.Button saveTroopsRecruiting;

		// Token: 0x040000AB RID: 171
		private global::System.Windows.Forms.Button loadTroopsRecruiting;

		// Token: 0x040000AC RID: 172
		private global::System.Windows.Forms.CheckBox checkBox_recruitingtroops;

		// Token: 0x040000AD RID: 173
		private global::System.Windows.Forms.Label label21;

		// Token: 0x040000AE RID: 174
		private global::System.Windows.Forms.TabPage tabPage_Villagelayout;

		// Token: 0x040000AF RID: 175
		private global::System.Windows.Forms.Button button_SaveLayouts;

		// Token: 0x040000B0 RID: 176
		private global::System.Windows.Forms.RichTextBox richTextBoxVillageLayouts;

		// Token: 0x040000B1 RID: 177
		private global::System.Windows.Forms.CheckBox checkBox_VillageLayouts;

		// Token: 0x040000B2 RID: 178
		private global::System.Windows.Forms.Button button8;

		// Token: 0x040000B3 RID: 179
		private global::System.Windows.Forms.Button button_LoadResearches;

		// Token: 0x040000B4 RID: 180
		private global::System.Windows.Forms.Button button_SaveResearches;

		// Token: 0x040000B5 RID: 181
		private global::System.Windows.Forms.Button button_LoadScoutingInfo;

		// Token: 0x040000B6 RID: 182
		private global::System.Windows.Forms.Button button_SaveScoutingInfo;

		// Token: 0x040000B7 RID: 183
		private global::System.Windows.Forms.ListBox listBox_ScoutingTypes;

		// Token: 0x040000B8 RID: 184
		private global::System.Windows.Forms.ListBox listBox_PopularityRegulation;

		// Token: 0x040000B9 RID: 185
		private global::System.Windows.Forms.Button button_AddMarkets;

		// Token: 0x040000BA RID: 186
		private global::System.Windows.Forms.TabPage tabPage_Spin;

		// Token: 0x040000BB RID: 187
		private global::System.Windows.Forms.Label label25;

		// Token: 0x040000BC RID: 188
		private global::System.Windows.Forms.CheckBox checkBox_Spin;

		// Token: 0x040000BD RID: 189
		private global::System.Windows.Forms.Label label31;

		// Token: 0x040000BE RID: 190
		private global::System.Windows.Forms.RichTextBox richTextBoxSpins;

		// Token: 0x040000BF RID: 191
		private global::System.Windows.Forms.Button button_ClearLogs;

		// Token: 0x040000C0 RID: 192
		private global::System.Windows.Forms.ListBox listBox_ScoutingTypes_Ignore;

		// Token: 0x040000C1 RID: 193
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040000C2 RID: 194
		private global::System.Windows.Forms.TabPage tabPage_Radar;

		// Token: 0x040000C3 RID: 195
		private global::System.Windows.Forms.RichTextBox richTextBoxRadar;

		// Token: 0x040000C4 RID: 196
		private global::System.Windows.Forms.CheckBox checkBox_Monitor;

		// Token: 0x040000C5 RID: 197
		private global::System.Windows.Forms.NumericUpDown numericUpDown2;

		// Token: 0x040000C6 RID: 198
		private global::System.Windows.Forms.Button button_StopSoundPlayer;

		// Token: 0x040000C7 RID: 199
		private global::System.Windows.Forms.ToolTip toolTip1;

		// Token: 0x040000C8 RID: 200
		private global::System.Windows.Forms.CheckBox checkBox_AutoConstr_WaitRes;

		// Token: 0x040000C9 RID: 201
		private global::System.Windows.Forms.NumericUpDown numeric_BanquetInterval;

		// Token: 0x040000CA RID: 202
		private global::System.Windows.Forms.ComboBox comboBox_RankUpMode;

		// Token: 0x040000CB RID: 203
		private global::System.Windows.Forms.CheckBox checkBox_HireScouts;

		// Token: 0x040000CC RID: 204
		private global::System.Windows.Forms.NumericUpDown numericUpDown_VillageLayoutInterval;

		// Token: 0x040000CD RID: 205
		private global::System.Windows.Forms.NumericUpDown numericUpDown_ScoutMaxTime;

		// Token: 0x040000CE RID: 206
		private global::System.Windows.Forms.NumericUpDown numericUpDown_MarketsRadius;

		// Token: 0x040000CF RID: 207
		private global::System.Windows.Forms.NumericUpDown numericUpDown_PopularityRegulation;

		// Token: 0x040000D0 RID: 208
		private global::System.Windows.Forms.NumericUpDown numericUpDown_SpinInterval;

		// Token: 0x040000D1 RID: 209
		private global::System.Windows.Forms.Button button_TestMail;

		// Token: 0x040000D2 RID: 210
		private global::System.Windows.Forms.Label label_ModuleDisable;

		// Token: 0x040000D3 RID: 211
		private global::System.Windows.Forms.ListBox listBox_ModuleDisable;

		// Token: 0x040000D4 RID: 212
		private global::System.Windows.Forms.Label label_Contacts;

		// Token: 0x040000D5 RID: 213
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040000D6 RID: 214
		private global::System.Windows.Forms.DataGridView dataGridView_Trade;

		// Token: 0x040000D7 RID: 215
		private global::System.Windows.Forms.TextBox textBox_TradeTargetID;

		// Token: 0x040000D8 RID: 216
		private global::System.Windows.Forms.Label label_Markets;

		// Token: 0x040000D9 RID: 217
		private global::System.Windows.Forms.Button button7;

		// Token: 0x040000DA RID: 218
		private global::System.Windows.Forms.ListBox listBox_ParishList;

		// Token: 0x040000DB RID: 219
		private global::System.Windows.Forms.LinkLabel linkLabel_botSiteLink;

		// Token: 0x040000DC RID: 220
		private global::System.Windows.Forms.Button button_testID;

		// Token: 0x040000DD RID: 221
		private global::System.Windows.Forms.Label label_villageConstruction_interval;

		// Token: 0x040000DE RID: 222
		private global::System.Windows.Forms.ComboBox comboBox_Language;

		// Token: 0x040000DF RID: 223
		private global::System.Windows.Forms.Label label_contributions;

		// Token: 0x040000E0 RID: 224
		private global::System.Windows.Forms.TextBox textBox_contactEmail;

		// Token: 0x040000E1 RID: 225
		private global::System.Windows.Forms.TabPage tabPage_AutomaticActions;

		// Token: 0x040000E2 RID: 226
		private global::System.Windows.Forms.CheckBox checkBox_Loadtroopsrecruitingsettings;

		// Token: 0x040000E3 RID: 227
		private global::System.Windows.Forms.CheckBox checkBox_Starttrading;

		// Token: 0x040000E4 RID: 228
		private global::System.Windows.Forms.CheckBox checkBox_Loadtradesettings;

		// Token: 0x040000E5 RID: 229
		private global::System.Windows.Forms.CheckBox checkBox_Startscouting;

		// Token: 0x040000E6 RID: 230
		private global::System.Windows.Forms.CheckBox checkBox_Loadscoutssettings;

		// Token: 0x040000E7 RID: 231
		private global::System.Windows.Forms.CheckBox checkBox_Login;

		// Token: 0x040000E8 RID: 232
		private global::System.Windows.Forms.CheckBox checkBox_RememberPassword;

		// Token: 0x040000E9 RID: 233
		private global::System.Windows.Forms.CheckBox checkBox_DownloadVillages;

		// Token: 0x040000EA RID: 234
		private global::System.Windows.Forms.CheckBox checkBox_Monitorattacks;

		// Token: 0x040000EB RID: 235
		private global::System.Windows.Forms.CheckBox checkBox_Banquet;

		// Token: 0x040000EC RID: 236
		private global::System.Windows.Forms.CheckBox checkBox_Recruittroops;

		// Token: 0x040000ED RID: 237
		private global::System.Windows.Forms.TabPage tabPage_Castle;

		// Token: 0x040000EE RID: 238
		private global::System.Windows.Forms.Button button_FixCastles;

		// Token: 0x040000EF RID: 239
		private global::System.Windows.Forms.RichTextBox richTextBoxCastle;

		// Token: 0x040000F0 RID: 240
		private global::System.Windows.Forms.TabPage tabPage_Predator;

		// Token: 0x040000F1 RID: 241
		private global::System.Windows.Forms.DataGridView dataGridView_PredatorPreys;

		// Token: 0x040000F2 RID: 242
		private global::System.Windows.Forms.CheckBox checkBox_StartHunting;

		// Token: 0x040000F3 RID: 243
		private global::System.Windows.Forms.Button button_LoadPrays;

		// Token: 0x040000F4 RID: 244
		private global::System.Windows.Forms.Button button_SavePrays;

		// Token: 0x040000F5 RID: 245
		private global::System.Windows.Forms.Label label_whatYouWannaHunt;

		// Token: 0x040000F6 RID: 246
		private global::System.Windows.Forms.DataGridView dataGridView_FoundPreys;

		// Token: 0x040000F7 RID: 247
		private global::System.Windows.Forms.Button button_ClearPreys;

		// Token: 0x040000F8 RID: 248
		private global::System.Windows.Forms.TabPage tabPage_TimedAttacks;

		// Token: 0x040000F9 RID: 249
		private global::System.Windows.Forms.Label label_TimedAttacksTargetId;

		// Token: 0x040000FA RID: 250
		private global::System.Windows.Forms.TextBox textBox_getAttackersTarget;

		// Token: 0x040000FB RID: 251
		private global::System.Windows.Forms.Button btnGetAttackers;

		// Token: 0x040000FC RID: 252
		private global::System.Windows.Forms.RichTextBox richTextBoxTimedAttacks;

		// Token: 0x040000FD RID: 253
		private global::System.Windows.Forms.Button button_UpdateCapitalsSpeed;

		// Token: 0x040000FE RID: 254
		private global::System.Windows.Forms.DataGridView dataGridView_RepairCastle;

		// Token: 0x040000FF RID: 255
		private global::System.Windows.Forms.DataGridViewTextBoxColumn CastleVillageName;

		// Token: 0x04000100 RID: 256
		private global::System.Windows.Forms.DataGridViewCheckBoxColumn CastleRestoreCastle;

		// Token: 0x04000101 RID: 257
		private global::System.Windows.Forms.DataGridViewComboBoxColumn CastleSelectLayout;

		// Token: 0x04000102 RID: 258
		private global::System.Windows.Forms.DataGridViewCheckBoxColumn CastleRestoreTroops;

		// Token: 0x04000103 RID: 259
		private global::System.Windows.Forms.DataGridViewComboBoxColumn CastleSelectTroops;

		// Token: 0x04000104 RID: 260
		private global::System.Windows.Forms.Button button_CastleLoad;

		// Token: 0x04000105 RID: 261
		private global::System.Windows.Forms.Button button_CastleSave;

		// Token: 0x04000106 RID: 262
		private global::System.Windows.Forms.Label label_ToEmail;

		// Token: 0x04000107 RID: 263
		private global::System.Windows.Forms.Label label_FromEmailPass;

		// Token: 0x04000108 RID: 264
		private global::System.Windows.Forms.Label label_FromEmail;

		// Token: 0x04000109 RID: 265
		private global::System.Windows.Forms.TextBox textBox_ToEmail;

		// Token: 0x0400010A RID: 266
		private global::System.Windows.Forms.TextBox textBox_FromEmailPass;

		// Token: 0x0400010B RID: 267
		private global::System.Windows.Forms.TextBox textBox_FromEmail;

		// Token: 0x0400010C RID: 268
		private global::System.Windows.Forms.Button button_OpenBotSettings;

		// Token: 0x0400010D RID: 269
		private global::System.Windows.Forms.CheckBox checkBox_Startbuildingvillages;

		// Token: 0x0400010E RID: 270
		private global::System.Windows.Forms.CheckBox checkBox_Loadvillagelayouts;

		// Token: 0x0400010F RID: 271
		private global::System.Windows.Forms.CheckBox checkBox_LoadResearches;

		// Token: 0x04000110 RID: 272
		private global::System.Windows.Forms.CheckBox checkBox_sendOneScout;

		// Token: 0x04000111 RID: 273
		private global::System.Windows.Forms.Button button_predatorStopSound;

		// Token: 0x04000112 RID: 274
		private global::System.Windows.Forms.NumericUpDown numericUpDown_PacketsPerTrade;

		// Token: 0x04000113 RID: 275
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000114 RID: 276
		private global::System.Windows.Forms.ListBox listBox_Subscriptions;

		// Token: 0x04000115 RID: 277
		private global::System.Windows.Forms.Label label_subscriptions;

		// Token: 0x04000116 RID: 278
		private global::System.Windows.Forms.Button button_Calc;

		// Token: 0x04000117 RID: 279
		private global::System.Windows.Forms.Button button_PredatorUpdatePresets;

		// Token: 0x04000118 RID: 280
		private global::System.Windows.Forms.TabControl tabControl_Predator;

		// Token: 0x04000119 RID: 281
		private global::System.Windows.Forms.TabPage tabPage_FoundPreys;

		// Token: 0x0400011A RID: 282
		private global::System.Windows.Forms.TabPage tabPage_Logs;

		// Token: 0x0400011B RID: 283
		private global::System.Windows.Forms.RichTextBox richTextBoxPredator;

		// Token: 0x0400011C RID: 284
		private global::System.Windows.Forms.TabControl tabControl_PredatorSettings;

		// Token: 0x0400011D RID: 285
		private global::System.Windows.Forms.TabPage tabPage1;

		// Token: 0x0400011E RID: 286
		private global::System.Windows.Forms.TabPage tabPage2;

		// Token: 0x0400011F RID: 287
		private global::System.Windows.Forms.ListBox listBox_PredatorCapitals;

		// Token: 0x04000120 RID: 288
		private global::System.Windows.Forms.ListBox listBox_PredatorVassals;

		// Token: 0x04000121 RID: 289
		private global::System.Windows.Forms.ListBox listBox_PredatorVillages;

		// Token: 0x04000122 RID: 290
		private global::System.Windows.Forms.Label label_PredatorCapitals;

		// Token: 0x04000123 RID: 291
		private global::System.Windows.Forms.Label label_PredatorVassals;

		// Token: 0x04000124 RID: 292
		private global::System.Windows.Forms.Label label_PredatorVillages;

		// Token: 0x04000125 RID: 293
		private global::System.Windows.Forms.CheckBox checkBox_PredatorCapitals;

		// Token: 0x04000126 RID: 294
		private global::System.Windows.Forms.CheckBox checkBox_PredatorVassals;

		// Token: 0x04000127 RID: 295
		private global::System.Windows.Forms.CheckBox checkBox_PredatorVillages;

		// Token: 0x04000128 RID: 296
		private global::System.Windows.Forms.CheckBox checkBox_PredatorUseCastleTroops;

		// Token: 0x04000129 RID: 297
		private global::System.Windows.Forms.Button button_CopySettings;

		// Token: 0x0400012A RID: 298
		private global::System.Windows.Forms.DataGridView dataGridView_RadarSettings;

		// Token: 0x0400012B RID: 299
		private global::System.Windows.Forms.Button button_RadarGridLoad;

		// Token: 0x0400012C RID: 300
		private global::System.Windows.Forms.Button button_RadarGridSave;

		// Token: 0x0400012D RID: 301
		private global::System.Windows.Forms.CheckBox checkBox_LoadRadarsettings;

		// Token: 0x0400012E RID: 302
		private global::System.Windows.Forms.CheckBox checkBox_RadarUseDefault;

		// Token: 0x0400012F RID: 303
		private global::System.Windows.Forms.Label label_RadarEmailStatus;

		// Token: 0x04000130 RID: 304
		private global::System.Windows.Forms.Label label_RadarLastEmailStatus;

		// Token: 0x04000131 RID: 305
		private global::System.Windows.Forms.Button button_RadarTestSound;

		// Token: 0x04000132 RID: 306
		private global::System.Windows.Forms.ComboBox comboBox_testInderdict;

		// Token: 0x04000133 RID: 307
		private global::System.Windows.Forms.Button button_TestPopup;

		// Token: 0x04000134 RID: 308
		private global::System.Windows.Forms.Button button_CloseAllMessages;

		// Token: 0x04000135 RID: 309
		private global::System.Windows.Forms.Button button_RadarHelp;

		// Token: 0x04000136 RID: 310
		private global::System.Windows.Forms.GroupBox groupBox_TradingVillage;

		// Token: 0x04000137 RID: 311
		private global::System.Windows.Forms.Button button_TradePreviousVillage;

		// Token: 0x04000138 RID: 312
		private global::System.Windows.Forms.Button button_TradeNextVillage;

		// Token: 0x04000139 RID: 313
		private global::System.Windows.Forms.ComboBox comboBox_TradeVillages;

		// Token: 0x0400013A RID: 314
		private global::System.Windows.Forms.CheckBox checkBox_ShouldVillageTrade;

		// Token: 0x0400013B RID: 315
		private global::System.Windows.Forms.CheckBox checkBox_TradeAllVillages;

		// Token: 0x0400013C RID: 316
		private global::System.Windows.Forms.Label label_TotalMarkets;

		// Token: 0x0400013D RID: 317
		private global::System.Windows.Forms.Label label_TotalMarketsLabel;

		// Token: 0x0400013E RID: 318
		private global::System.Windows.Forms.Button button_TradeHelp;

		// Token: 0x0400013F RID: 319
		private global::System.Windows.Forms.GroupBox groupBox_ScoutingVillage;

		// Token: 0x04000140 RID: 320
		private global::System.Windows.Forms.Button button_ScoutingHelp;

		// Token: 0x04000141 RID: 321
		private global::System.Windows.Forms.Button button_ScoutingPreviousVillage;

		// Token: 0x04000142 RID: 322
		private global::System.Windows.Forms.Button button_ScoutingNextVillage;

		// Token: 0x04000143 RID: 323
		private global::System.Windows.Forms.ComboBox comboBox_ScoutingVillages;

		// Token: 0x04000144 RID: 324
		private global::System.Windows.Forms.CheckBox checkBox_ScoutingAllVillages;

		// Token: 0x04000145 RID: 325
		private global::System.Windows.Forms.CheckBox checkBox_ShouldVillageScout;

		// Token: 0x04000146 RID: 326
		private global::System.Windows.Forms.TabControl tabControl_Trade;

		// Token: 0x04000147 RID: 327
		private global::System.Windows.Forms.TabPage tabPage_TradeMarkets;

		// Token: 0x04000148 RID: 328
		private global::System.Windows.Forms.TabPage tabPage_TradeBetweenVillages;

		// Token: 0x04000149 RID: 329
		private global::System.Windows.Forms.TabPage tabPage_TradeAdvanced;

		// Token: 0x0400014A RID: 330
		private global::System.Windows.Forms.DataGridView dataGridView_TradeRoutes;

		// Token: 0x0400014B RID: 331
		private global::System.Windows.Forms.ContextMenuStrip contextMenu_TradeRoutes;

		// Token: 0x0400014C RID: 332
		private global::System.Windows.Forms.ToolStripMenuItem newRouteToolStripMenuItem;

		// Token: 0x0400014D RID: 333
		private global::System.Windows.Forms.ToolStripMenuItem editTaskToolStripMenuItem;

		// Token: 0x0400014E RID: 334
		private global::System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;

		// Token: 0x0400014F RID: 335
		private global::System.Windows.Forms.TabPage tabPage_TradeLogs;

		// Token: 0x04000150 RID: 336
		private global::System.Windows.Forms.CheckBox checkBox_WriteLogs;

		// Token: 0x04000151 RID: 337
		internal global::System.Windows.Forms.CheckBox checkBox_TradeIgnoreCurrentTransactions;

		// Token: 0x04000152 RID: 338
		private global::System.Windows.Forms.ToolStripMenuItem selectAllStockpileGoodsToolStripMenuItem;

		// Token: 0x04000153 RID: 339
		private global::System.Windows.Forms.ToolStripMenuItem selectAllFoodToolStripMenuItem;

		// Token: 0x04000154 RID: 340
		private global::System.Windows.Forms.ToolStripMenuItem selectAllBanquetsGoodsToolStripMenuItem;

		// Token: 0x04000155 RID: 341
		private global::System.Windows.Forms.ToolStripMenuItem selectAllWeaponsToolStripMenuItem;

		// Token: 0x04000156 RID: 342
		internal global::System.Windows.Forms.ContextMenuStrip contextMenuStrip_ResourcesQuickSelector;

		// Token: 0x04000157 RID: 343
		private global::System.Windows.Forms.ToolStripMenuItem buyAllStockpileGoodsToolStripMenuItem;

		// Token: 0x04000158 RID: 344
		private global::System.Windows.Forms.ToolStripMenuItem buyAllFoodToolStripMenuItem;

		// Token: 0x04000159 RID: 345
		private global::System.Windows.Forms.ToolStripMenuItem buyAllBanquetsGoodsToolStripMenuItem;

		// Token: 0x0400015A RID: 346
		private global::System.Windows.Forms.ToolStripMenuItem buyAllWeaponsToolStripMenuItem;

		// Token: 0x0400015B RID: 347
		private global::System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;

		// Token: 0x0400015C RID: 348
		internal global::System.Windows.Forms.NumericUpDown numericUpDown_AutoHireMerchantsLimit;

		// Token: 0x0400015D RID: 349
		internal global::System.Windows.Forms.CheckBox checkBox_AutoHireMerchants;

		// Token: 0x0400015E RID: 350
		private global::System.Windows.Forms.TabPage tabPage_FreeMonitor;

		// Token: 0x0400015F RID: 351
		private global::System.Windows.Forms.Label label_FreeMonitorLastUpdate;

		// Token: 0x04000160 RID: 352
		private global::System.Windows.Forms.Label label_NumResearchesInQueue;

		// Token: 0x04000161 RID: 353
		private global::System.Windows.Forms.CheckBox checkBox_FreeMonitorEnable;

		// Token: 0x04000162 RID: 354
		internal global::System.Windows.Forms.DataGridView dataGridView_FreeMonitor;

		// Token: 0x04000163 RID: 355
		internal global::System.Windows.Forms.Label label_FreeMonitorLastUpdateValue;

		// Token: 0x04000164 RID: 356
		internal global::System.Windows.Forms.Label label_NumResearchesInQueueValue;

		// Token: 0x04000165 RID: 357
		private global::System.Windows.Forms.CheckedListBox checkedListBox_FreeMonitorColumns;

		// Token: 0x04000166 RID: 358
		private global::System.Windows.Forms.CheckBox checkBox_stopTradeOnCardExpiry;

		// Token: 0x04000167 RID: 359
		internal global::System.Windows.Forms.CheckBox checkBox_Trade;

		// Token: 0x04000168 RID: 360
		private global::System.Windows.Forms.CheckBox checkBox_villagesLayoutsSelectAll;

		// Token: 0x04000169 RID: 361
		internal global::System.Windows.Forms.DataGridView dataGridViewVillageLayoutsEdit;

		// Token: 0x0400016A RID: 362
		private global::System.Windows.Forms.TabControl tabControl_VillageLayouts;

		// Token: 0x0400016B RID: 363
		private global::System.Windows.Forms.TabPage tabPage_villageLayouts;

		// Token: 0x0400016C RID: 364
		private global::System.Windows.Forms.TabPage tabPage_villageLayoutsLogs;

		// Token: 0x0400016D RID: 365
		private global::System.Windows.Forms.GroupBox groupBox_villageLayoutsNavigation;

		// Token: 0x0400016E RID: 366
		private global::System.Windows.Forms.Button button_previousLayout;

		// Token: 0x0400016F RID: 367
		private global::System.Windows.Forms.Button button_nextLayout;

		// Token: 0x04000170 RID: 368
		private global::System.Windows.Forms.ComboBox comboBox_villageLayouts;

		// Token: 0x04000171 RID: 369
		private global::System.Windows.Forms.GroupBox groupBox_VillageLayoutsSettings;

		// Token: 0x04000172 RID: 370
		private global::System.Windows.Forms.GroupBox groupBox_SelectedLayout;

		// Token: 0x04000173 RID: 371
		internal global::System.Windows.Forms.ListBox listBox_VillageLayouts;

		// Token: 0x04000174 RID: 372
		internal global::System.Windows.Forms.CheckBox checkBox_ShouldLayoutBeBuilt;

		// Token: 0x04000175 RID: 373
		private global::System.Windows.Forms.Button button_VillageLayouts_Help;

		// Token: 0x04000176 RID: 374
		internal global::System.Windows.Forms.CheckBox checkBox_RadarRehireMonks;

		// Token: 0x04000177 RID: 375
		private global::System.Windows.Forms.CheckBox checkBox_StopScoutsOnCardExpiry;

		// Token: 0x04000178 RID: 376
		internal global::System.Windows.Forms.CheckBox checkBox_Scout;

		// Token: 0x04000179 RID: 377
		private global::System.Windows.Forms.CheckBox checkBox_Research;

		// Token: 0x0400017A RID: 378
		private global::System.Windows.Forms.CheckBox checkBox_StartResearching;

		// Token: 0x0400017B RID: 379
		private global::System.Windows.Forms.ComboBox comboBox_PopularityRegulationMode;

		// Token: 0x0400017C RID: 380
		private global::System.Windows.Forms.CheckBox checkBox_Loadcastlerepairsettings;

		// Token: 0x0400017D RID: 381
		private global::System.Windows.Forms.CheckBox checkBox_Startregulatepopularity;

		// Token: 0x0400017E RID: 382
		private global::System.Windows.Forms.CheckBox checkBox_LoadPredatorSettings;

		// Token: 0x0400017F RID: 383
		private global::System.Windows.Forms.Button button_SaveCastlesLocally;

		// Token: 0x04000180 RID: 384
		private global::System.Windows.Forms.TabPage tabPage3;

		// Token: 0x04000181 RID: 385
		internal global::System.Windows.Forms.CheckBox checkBox_HuntWithinParish;

		// Token: 0x04000182 RID: 386
		private global::System.Windows.Forms.TabPage tabPage_Interdict;

		// Token: 0x04000183 RID: 387
		private global::System.Windows.Forms.CheckBox checkBox_InterdictSelectAll;

		// Token: 0x04000184 RID: 388
		internal global::System.Windows.Forms.NumericUpDown numericUpDown_InterdictNumberOfMonks;

		// Token: 0x04000185 RID: 389
		private global::System.Windows.Forms.Label label_InterdictNumberOfMonks;

		// Token: 0x04000186 RID: 390
		private global::System.Windows.Forms.Button button_Interdict;

		// Token: 0x04000187 RID: 391
		private global::System.Windows.Forms.ListBox listBox_Interdict;

		// Token: 0x04000188 RID: 392
		private global::System.Windows.Forms.CheckBox checkBox_Interdict_SkipIfAlreadyID;

		// Token: 0x04000189 RID: 393
		internal global::System.Windows.Forms.CheckBox checkBox_Interdict_AllowHireMonks;

		// Token: 0x0400018A RID: 394
		private global::System.Windows.Forms.DataGridViewTextBoxColumn PreyId;

		// Token: 0x0400018B RID: 395
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Prey;

		// Token: 0x0400018C RID: 396
		private global::System.Windows.Forms.DataGridViewTextBoxColumn PreyDistance;

		// Token: 0x0400018D RID: 397
		private global::System.Windows.Forms.DataGridViewTextBoxColumn PreyNextTo;

		// Token: 0x0400018E RID: 398
		private global::System.Windows.Forms.DataGridViewTextBoxColumn PreyTime;

		// Token: 0x0400018F RID: 399
		private global::System.Windows.Forms.DataGridViewTextBoxColumn PreyType;

		// Token: 0x04000190 RID: 400
		private global::System.Windows.Forms.DataGridViewTextBoxColumn PreyName;

		// Token: 0x04000191 RID: 401
		private global::System.Windows.Forms.DataGridViewCheckBoxColumn PreyHunt;

		// Token: 0x04000192 RID: 402
		private global::System.Windows.Forms.DataGridViewTextBoxColumn MaxDistance;

		// Token: 0x04000193 RID: 403
		private global::System.Windows.Forms.DataGridViewCheckBoxColumn IncludeVassalHonourRange;

		// Token: 0x04000194 RID: 404
		private global::System.Windows.Forms.DataGridViewCheckBoxColumn IncludeCapitalHonourRange;

		// Token: 0x04000195 RID: 405
		private global::System.Windows.Forms.DataGridViewCheckBoxColumn NotifyWithMessage;

		// Token: 0x04000196 RID: 406
		private global::System.Windows.Forms.DataGridViewCheckBoxColumn NotifyWithSound;

		// Token: 0x04000197 RID: 407
		private global::System.Windows.Forms.DataGridViewCheckBoxColumn Kill;

		// Token: 0x04000198 RID: 408
		private global::System.Windows.Forms.DataGridViewComboBoxColumn PredatorAttackFormation;

		// Token: 0x04000199 RID: 409
		private global::System.Windows.Forms.CheckBox checkBox_showPopupOnTradeExpiry;

		// Token: 0x0400019A RID: 410
		private global::System.Windows.Forms.CheckBox checkBox_showPopupOnScoutsExpiry;

		// Token: 0x0400019B RID: 411
		private global::System.Windows.Forms.Button button_PauseEveryThing;

		// Token: 0x0400019C RID: 412
		private global::System.Windows.Forms.SplitContainer splitContainer_Trade2;

		// Token: 0x0400019D RID: 413
		private global::System.Windows.Forms.SplitContainer splitContainer_Trade;

		// Token: 0x0400019E RID: 414
		private global::System.Windows.Forms.Button button1;

		// Token: 0x0400019F RID: 415
		private global::System.Windows.Forms.ListBox listBox1;

		// Token: 0x040001A0 RID: 416
		private global::System.Windows.Forms.CheckBox checkBox_AutoRepairCastle;

		// Token: 0x040001A1 RID: 417
		private global::System.Windows.Forms.TextBox textBox_UserContactEmail;

		// Token: 0x040001A2 RID: 418
		private global::System.Windows.Forms.Label label_ContactEmail;

		// Token: 0x040001A3 RID: 419
		private global::System.Windows.Forms.TabControl tabControl_TroopsRecruiting;

		// Token: 0x040001A4 RID: 420
		private global::System.Windows.Forms.TabPage tabPage_VillagesTroopsRecruiting;

		// Token: 0x040001A5 RID: 421
		private global::System.Windows.Forms.TabPage tabPage_CapitalsTroopsRecruiting;

		// Token: 0x040001A6 RID: 422
		private global::System.Windows.Forms.DataGridView dataGridView_CapitalsRecruiting;

		// Token: 0x040001A7 RID: 423
		private global::System.Windows.Forms.TabPage tabPage_Refresh;

		// Token: 0x040001A8 RID: 424
		private global::System.Windows.Forms.RichTextBox richTextBox_Refresh;

		// Token: 0x040001A9 RID: 425
		private global::System.Windows.Forms.CheckBox checkBox_EnableRefresh;

		// Token: 0x040001AA RID: 426
		private global::System.Windows.Forms.CheckBox checkBox_AllRefresh;

		// Token: 0x040001AB RID: 427
		private global::System.Windows.Forms.ListBox listBox_Refresh;

		// Token: 0x040001AC RID: 428
		private global::System.Windows.Forms.CheckBox checkBox_RefreshCapitals;

		// Token: 0x040001AD RID: 429
		private global::System.Windows.Forms.CheckBox checkBox_IsFullRefreshAllowed;

		// Token: 0x040001AE RID: 430
		private global::System.Windows.Forms.Button button_LoadRefreshList;

		// Token: 0x040001AF RID: 431
		private global::System.Windows.Forms.Button button_SaveRefreshList;

		// Token: 0x040001B0 RID: 432
		private global::System.Windows.Forms.TabPage tabPage_Monks;

		// Token: 0x040001B1 RID: 433
		private global::System.Windows.Forms.DataGridView dataGridView_Monks;

		// Token: 0x040001B2 RID: 434
		private global::System.Windows.Forms.Button button_HelpMonks;

		// Token: 0x040001B3 RID: 435
		private global::System.Windows.Forms.Button button_LoadMonks;

		// Token: 0x040001B4 RID: 436
		private global::System.Windows.Forms.CheckBox checkBox_EnableMonks;

		// Token: 0x040001B5 RID: 437
		private global::System.Windows.Forms.Button button_SaveMonks;

		// Token: 0x040001B6 RID: 438
		private global::System.Windows.Forms.RichTextBox richTextBoxMonks;

		// Token: 0x040001B7 RID: 439
		private global::System.Windows.Forms.ContextMenuStrip contextMenu_MonkRoutes;

		// Token: 0x040001B8 RID: 440
		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;

		// Token: 0x040001B9 RID: 441
		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;

		// Token: 0x040001BA RID: 442
		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;

		// Token: 0x040001BB RID: 443
		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;

		// Token: 0x040001BC RID: 444
		private global::System.Windows.Forms.CheckBox checkBox_StartMonks;

		// Token: 0x040001BD RID: 445
		private global::System.Windows.Forms.CheckBox checkBox_LoadMonksSettings;

		// Token: 0x040001BE RID: 446
		private global::System.Windows.Forms.DataGridViewTextBoxColumn MonkRouteName;

		// Token: 0x040001BF RID: 447
		private global::System.Windows.Forms.DataGridViewCheckBoxColumn MonkRouteEnabled;

		// Token: 0x040001C0 RID: 448
		private global::System.Windows.Forms.DataGridViewTextBoxColumn MonkRouteVillages;

		// Token: 0x040001C1 RID: 449
		private global::System.Windows.Forms.DataGridViewTextBoxColumn MonkRouteTargets;

		// Token: 0x040001C2 RID: 450
		private global::System.Windows.Forms.DataGridViewTextBoxColumn MonkRouteCommand;

		// Token: 0x040001C3 RID: 451
		private global::System.Windows.Forms.DataGridViewTextBoxColumn MonkRouteStopCondition;

		// Token: 0x040001C4 RID: 452
		private global::System.Windows.Forms.DataGridViewTextBoxColumn MonkRouteParameter;

		// Token: 0x040001C5 RID: 453
		private global::System.Windows.Forms.DataGridViewCheckBoxColumn MonkRouteIsDistanceLimited;

		// Token: 0x040001C6 RID: 454
		private global::System.Windows.Forms.DataGridViewTextBoxColumn MonkRouteDistanceLimit;

		// Token: 0x040001C7 RID: 455
		private global::System.Windows.Forms.CheckBox checkBox_CollectFreeCard;

		// Token: 0x040001C8 RID: 456
		private global::System.Windows.Forms.Button button_RefreshHelp;

		// Token: 0x040001C9 RID: 457
		private global::System.Windows.Forms.NumericUpDown numericUpDown_BotSleepPeriod;

		// Token: 0x040001CA RID: 458
		private global::System.Windows.Forms.NumericUpDown numericUpDown_BotWorkPeriod;

		// Token: 0x040001CB RID: 459
		private global::System.Windows.Forms.GroupBox groupBox_BotLifeCycle;

		// Token: 0x040001CC RID: 460
		private global::System.Windows.Forms.Label label_BotSleepPeriod;

		// Token: 0x040001CD RID: 461
		private global::System.Windows.Forms.Label label_BotWorkPeriod;

		// Token: 0x040001CE RID: 462
		private global::System.Windows.Forms.TabPage tabPage_VassalsTroopsRecruiting;

		// Token: 0x040001CF RID: 463
		private global::System.Windows.Forms.DataGridView dataGridView_FillVassals;

		// Token: 0x040001D0 RID: 464
		internal global::System.Windows.Forms.NotifyIcon radarNotifyIcon;

		// Token: 0x040001D1 RID: 465
		private global::System.Windows.Forms.Button button3;

		// Token: 0x040001D2 RID: 466
		private global::System.Windows.Forms.NumericUpDown numericUpDown_MerchantsExchangeLimit;

		// Token: 0x040001D3 RID: 467
		private global::System.Windows.Forms.NumericUpDown numericUpDown_MerchantsTradeLimit;

		// Token: 0x040001D4 RID: 468
		private global::System.Windows.Forms.Label label_MerchantsExchangeLimit;

		// Token: 0x040001D5 RID: 469
		private global::System.Windows.Forms.Label label_MerchantsTradeLimit;

		// Token: 0x040001D6 RID: 470
		private global::System.Windows.Forms.NumericUpDown numericUpDown_KeepMonks;

		// Token: 0x040001D7 RID: 471
		private global::System.Windows.Forms.Label label_KeepMonks;

		// Token: 0x040001D8 RID: 472
		private global::System.Windows.Forms.NumericUpDown numericUpDown_VassalTroopsMinimum;

		// Token: 0x040001D9 RID: 473
		private global::System.Windows.Forms.Label label_VassalTroopsMinimum;

		// Token: 0x040001DA RID: 474
		private global::System.Windows.Forms.TabPage tabPage_Feed;

		// Token: 0x040001DB RID: 475
		private global::System.Windows.Forms.WebBrowser webBrowser_Feed;

		// Token: 0x040001DC RID: 476
		private global::System.Windows.Forms.CheckBox checkBox_FeedShouldNotify;

		// Token: 0x040001DD RID: 477
		private global::System.Windows.Forms.Label label_BotCycleStatusValue;

		// Token: 0x040001DE RID: 478
		private global::System.Windows.Forms.CheckBox checkBox_BotCycleRandomPeriods;

		// Token: 0x040001DF RID: 479
		private global::System.Windows.Forms.Label label_BotCycleStatus;

		// Token: 0x040001E0 RID: 480
		private global::System.Windows.Forms.Button button_PredatorHelp;

		// Token: 0x040001E1 RID: 481
		private global::System.Windows.Forms.CheckBox checkBox_PopularitySelectAll;

		// Token: 0x040001E2 RID: 482
		private global::System.Windows.Forms.Button button_cacheLoad;

		// Token: 0x040001E3 RID: 483
		private global::System.Windows.Forms.Button button_cacheSub;

		// Token: 0x040001E4 RID: 484
		private global::System.Windows.Forms.TabControl tabControl2;

		// Token: 0x040001E5 RID: 485
		private global::System.Windows.Forms.TabPage tabPage_RadarMain;

		// Token: 0x040001E6 RID: 486
		private global::System.Windows.Forms.TabPage tabPage_RadarEmail;

		// Token: 0x040001E7 RID: 487
		private global::System.Windows.Forms.TabPage tabPage_RadarDiscord;

		// Token: 0x040001E8 RID: 488
		private global::System.Windows.Forms.TabPage tabPage_RadarTelegram;

		// Token: 0x040001E9 RID: 489
		private global::System.Windows.Forms.TabPage tabPage_RadarTest;

		// Token: 0x040001EA RID: 490
		private global::System.Windows.Forms.TextBox textBox_DiscordWebhook;

		// Token: 0x040001EB RID: 491
		private global::System.Windows.Forms.Label label_DiscordWebhook;

		// Token: 0x040001EC RID: 492
		private global::System.Windows.Forms.Button button_RadarTestTelegram;

		// Token: 0x040001ED RID: 493
		private global::System.Windows.Forms.Button button_RadarTestDiscord;

		// Token: 0x040001EE RID: 494
		private global::System.Windows.Forms.TextBox textBox_TelegramChatID;

		// Token: 0x040001EF RID: 495
		private global::System.Windows.Forms.Label label_TelegramChatID;

		// Token: 0x040001F0 RID: 496
		private global::System.Windows.Forms.TextBox textBox_TelegramBotToken;

		// Token: 0x040001F1 RID: 497
		private global::System.Windows.Forms.Label label_TelegramBotToken;

		// Token: 0x040001F2 RID: 498
		private global::System.Windows.Forms.Label label_TeleTip2;

		// Token: 0x040001F3 RID: 499
		private global::System.Windows.Forms.Label label_TeleTip1;

		// Token: 0x040001F4 RID: 500
		private global::System.Windows.Forms.Label label_TeleTip3;

		// Token: 0x040001F5 RID: 501
		private global::System.Windows.Forms.Button button_RadarTestTray;

		// Token: 0x040001F6 RID: 502
		private global::System.Windows.Forms.CheckBox checkBox_StayOnTop;

		// Token: 0x040001F7 RID: 503
		private global::System.Windows.Forms.ComboBox comboBox_VillageTemplate;

		// Token: 0x040001F8 RID: 504
		private global::System.Windows.Forms.Label label_VillageTemplate;

		// Token: 0x040001F9 RID: 505
		private global::System.Windows.Forms.DataGridViewTextBoxColumn RadarEvent;

		// Token: 0x040001FA RID: 506
		private global::System.Windows.Forms.DataGridViewCheckBoxColumn RadarTrackEvent;

		// Token: 0x040001FB RID: 507
		private global::System.Windows.Forms.DataGridViewCheckBoxColumn RadarMessagePopup;

		// Token: 0x040001FC RID: 508
		private global::System.Windows.Forms.DataGridViewTextBoxColumn RadarSound;

		// Token: 0x040001FD RID: 509
		private global::System.Windows.Forms.DataGridViewCheckBoxColumn RadarSendEmail;

		// Token: 0x040001FE RID: 510
		private global::System.Windows.Forms.DataGridViewTextBoxColumn RadarInterdict;

		// Token: 0x040001FF RID: 511
		private global::System.Windows.Forms.DataGridViewCheckBoxColumn RadarSystemNotification;

		// Token: 0x04000200 RID: 512
		private global::System.Windows.Forms.DataGridViewCheckBoxColumn RadarDiscord;

		// Token: 0x04000201 RID: 513
		private global::System.Windows.Forms.DataGridViewCheckBoxColumn RadarTelegram;

		// Token: 0x04000202 RID: 514
		private global::System.Windows.Forms.DataGridViewTextBoxColumn RouteName;

		// Token: 0x04000203 RID: 515
		private global::System.Windows.Forms.DataGridViewCheckBoxColumn RouteEnabled;

		// Token: 0x04000204 RID: 516
		private global::System.Windows.Forms.DataGridViewTextBoxColumn RouteFrom;

		// Token: 0x04000205 RID: 517
		private global::System.Windows.Forms.DataGridViewTextBoxColumn RouteTo;

		// Token: 0x04000206 RID: 518
		private global::System.Windows.Forms.DataGridViewTextBoxColumn RouteResourceType;

		// Token: 0x04000207 RID: 519
		private global::System.Windows.Forms.DataGridViewTextBoxColumn RouteKeepMinimum;

		// Token: 0x04000208 RID: 520
		private global::System.Windows.Forms.DataGridViewTextBoxColumn RouteMaxMerchantsPerTransaction;

		// Token: 0x04000209 RID: 521
		private global::System.Windows.Forms.DataGridViewTextBoxColumn RouteSendMaximum;

		// Token: 0x0400020A RID: 522
		private global::System.Windows.Forms.DataGridViewCheckBoxColumn RouteIsDistanceLimited;

		// Token: 0x0400020B RID: 523
		private global::System.Windows.Forms.DataGridViewTextBoxColumn RouteDistanceLimit;

		// Token: 0x0400020C RID: 524
		private global::System.Windows.Forms.DataGridViewTextBoxColumn typeID;

		// Token: 0x0400020D RID: 525
		private global::System.Windows.Forms.DataGridViewTextBoxColumn TypeName;

		// Token: 0x0400020E RID: 526
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Number;

		// Token: 0x0400020F RID: 527
		private global::System.Windows.Forms.DataGridViewTextBoxColumn BuildingStatus;

		// Token: 0x04000210 RID: 528
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Xcoord;

		// Token: 0x04000211 RID: 529
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Ycoord;

		// Token: 0x04000212 RID: 530
		private global::System.Windows.Forms.Button button_TimingHelp;

		// Token: 0x04000213 RID: 531
		private global::System.Windows.Forms.Button button_InterdictTabHelp;

		// Token: 0x04000214 RID: 532
		private global::System.Windows.Forms.Button button_MainHelp;

		// Token: 0x04000215 RID: 533
		private global::System.Windows.Forms.Button button_CastleHelp;

		// Token: 0x04000216 RID: 534
		private global::System.Windows.Forms.Button button_BanquetingHelp;

		// Token: 0x04000217 RID: 535
		private global::System.Windows.Forms.Button button_ResearchHelp;

		// Token: 0x04000218 RID: 536
		private global::System.Windows.Forms.Button button_RecruitingHelp;

		// Token: 0x04000219 RID: 537
		private global::System.Windows.Forms.TabPage tabPage_AltAccounts;

		// Token: 0x0400021A RID: 538
		private global::System.Windows.Forms.Button button_RadarFindByID;

		// Token: 0x0400021B RID: 539
		private global::System.Windows.Forms.NumericUpDown numericUpDown_RadarFindByID;

		// Token: 0x0400021C RID: 540
		private global::System.Windows.Forms.Label label_RadarAltAccounts;

		// Token: 0x0400021D RID: 541
		private global::System.Windows.Forms.Button button_RadarResetAlt;

		// Token: 0x0400021E RID: 542
		private global::System.Windows.Forms.Button button_FindByUsername;

		// Token: 0x0400021F RID: 543
		private global::System.Windows.Forms.TextBox textBox_RadarFindByUsername;

		// Token: 0x04000220 RID: 544
		private global::System.Windows.Forms.RadioButton radioButton_ScoutsPriorityByDistance;

		// Token: 0x04000221 RID: 545
		private global::System.Windows.Forms.RadioButton radioButton_ScoutsPriorityByTypeAndDistance;

		// Token: 0x04000222 RID: 546
		private global::System.Windows.Forms.Button button_ScoutingCopy;

		// Token: 0x04000223 RID: 547
		private global::System.Windows.Forms.Button button_PredatorCopy;

		// Token: 0x04000224 RID: 548
		private global::System.Windows.Forms.Button button_VassalsCopy;

		// Token: 0x04000225 RID: 549
		private global::System.Windows.Forms.Button button_VillageCopy;

		// Token: 0x04000226 RID: 550
		private global::System.Windows.Forms.Button button_RecruitingCopy;

		// Token: 0x04000227 RID: 551
		private global::System.Windows.Forms.Button button_BanquetCopy;

		// Token: 0x04000228 RID: 552
		private global::System.Windows.Forms.Button button_BanquetLoad;

		// Token: 0x04000229 RID: 553
		private global::System.Windows.Forms.Button button_BanquetSave;

		// Token: 0x0400022A RID: 554
		private global::System.Windows.Forms.DataGridView dataGridView_Banquets;

		// Token: 0x0400022B RID: 555
		private global::System.Windows.Forms.DataGridViewTextBoxColumn BanquetVillage;

		// Token: 0x0400022C RID: 556
		private global::System.Windows.Forms.DataGridViewComboBoxColumn BanquetLevel;

		// Token: 0x0400022D RID: 557
		private global::System.Windows.Forms.Button button_CopyPopularity;

		// Token: 0x0400022E RID: 558
		private global::System.Windows.Forms.Button button_UpdateCapitalsSpeed2;

		// Token: 0x0400022F RID: 559
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Village;

		// Token: 0x04000230 RID: 560
		private global::System.Windows.Forms.DataGridViewCheckBoxColumn Recruit;

		// Token: 0x04000231 RID: 561
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Peasants;

		// Token: 0x04000232 RID: 562
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Archers;

		// Token: 0x04000233 RID: 563
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Pikemen;

		// Token: 0x04000234 RID: 564
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Swordsmen;

		// Token: 0x04000235 RID: 565
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Catapults;

		// Token: 0x04000236 RID: 566
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Captains;

		// Token: 0x04000237 RID: 567
		private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		// Token: 0x04000238 RID: 568
		private global::System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;

		// Token: 0x04000239 RID: 569
		private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		// Token: 0x0400023A RID: 570
		private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

		// Token: 0x0400023B RID: 571
		private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

		// Token: 0x0400023C RID: 572
		private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;

		// Token: 0x0400023D RID: 573
		private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;

		// Token: 0x0400023E RID: 574
		private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;

		// Token: 0x0400023F RID: 575
		private global::System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;

		// Token: 0x04000240 RID: 576
		private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;

		// Token: 0x04000241 RID: 577
		private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;

		// Token: 0x04000242 RID: 578
		private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;

		// Token: 0x04000243 RID: 579
		private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;

		// Token: 0x04000244 RID: 580
		private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;

		// Token: 0x04000245 RID: 581
		private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;

		// Token: 0x04000246 RID: 582
		private global::System.Windows.Forms.Button button_ExportForOffline;

		// Token: 0x04000247 RID: 583
		private global::System.Windows.Forms.TextBox textBox_ProxyPassword;

		// Token: 0x04000248 RID: 584
		private global::System.Windows.Forms.TextBox textBox_ProxyUsername;

		// Token: 0x04000249 RID: 585
		private global::System.Windows.Forms.TextBox textBox_ProxyPort;

		// Token: 0x0400024A RID: 586
		private global::System.Windows.Forms.TextBox textBox_ProxyAddress;

		// Token: 0x0400024B RID: 587
		private global::System.Windows.Forms.CheckBox checkBox_TelegramUseProxy;

		// Token: 0x0400024C RID: 588
		private global::System.Windows.Forms.GroupBox groupBox_TelegramProxy;

		// Token: 0x0400024D RID: 589
		private global::System.Windows.Forms.CheckBox checkBox_ProxyUseCredential;

		// Token: 0x0400024E RID: 590
		private global::System.Windows.Forms.Label label_ProxyPassword;

		// Token: 0x0400024F RID: 591
		private global::System.Windows.Forms.Label label_ProxyLogin;

		// Token: 0x04000250 RID: 592
		private global::System.Windows.Forms.Label label_ProxyPort;

		// Token: 0x04000251 RID: 593
		private global::System.Windows.Forms.Label label_ProxyAddress;

		// Token: 0x04000252 RID: 594
		private global::System.Windows.Forms.Button button_TradeCopy;

		// Token: 0x04000253 RID: 595
		private global::System.Windows.Forms.DataGridViewTextBoxColumn TradeTypeId;

		// Token: 0x04000254 RID: 596
		private global::System.Windows.Forms.DataGridViewTextBoxColumn TradeType;

		// Token: 0x04000255 RID: 597
		private global::System.Windows.Forms.DataGridViewCheckBoxColumn TradeTypeSell;

		// Token: 0x04000256 RID: 598
		private global::System.Windows.Forms.DataGridViewTextBoxColumn TradeMinPrice;

		// Token: 0x04000257 RID: 599
		private global::System.Windows.Forms.DataGridViewTextBoxColumn TradeLimit;

		// Token: 0x04000258 RID: 600
		private global::System.Windows.Forms.DataGridViewCheckBoxColumn TradeBuy;

		// Token: 0x04000259 RID: 601
		private global::System.Windows.Forms.DataGridViewTextBoxColumn TradeMaxBuy;

		// Token: 0x0400025A RID: 602
		private global::System.Windows.Forms.DataGridViewTextBoxColumn TradeBuyLimit;

		// Token: 0x0400025B RID: 603
		private global::System.Windows.Forms.DataGridViewTextBoxColumn TradeCurrentLevel;

		// Token: 0x0400025C RID: 604
		private global::System.Windows.Forms.DataGridViewTextBoxColumn TradeDailyProduction;

		// Token: 0x0400025D RID: 605
		private global::System.Windows.Forms.Label label_MinimumScouts;

		// Token: 0x0400025E RID: 606
		private global::System.Windows.Forms.NumericUpDown numericUpDown_minScouts;

		// Token: 0x0400025F RID: 607
		private global::System.Windows.Forms.CheckBox checkBox_ScoutsWaitFreeSpace;

		// Token: 0x04000260 RID: 608
		private global::System.Windows.Forms.Label label_LogsToKeep;

		// Token: 0x04000261 RID: 609
		private global::System.Windows.Forms.NumericUpDown numericUpDown_LogsToKeep;

		// Token: 0x04000262 RID: 610
		private global::System.Windows.Forms.CheckBox checkBox_LoadBanquets;

		// Token: 0x04000263 RID: 611
		private global::System.Windows.Forms.TabPage tabPage_Error;

		// Token: 0x04000264 RID: 612
		private global::System.Windows.Forms.RichTextBox richTextBox_Errors;

		// Token: 0x04000265 RID: 613
		private global::System.Windows.Forms.Button button_ClearErrors;

		// Token: 0x04000266 RID: 614
		private global::System.Windows.Forms.Label label_RadarAltToolTip;

		// Token: 0x04000267 RID: 615
		private global::System.Windows.Forms.Button button_ImportLayoutFromFile;

		// Token: 0x04000268 RID: 616
		private global::System.Windows.Forms.TabPage tabPage_RadarAutoID;

		// Token: 0x04000269 RID: 617
		private global::System.Windows.Forms.Label label_AutoID;

		// Token: 0x0400026A RID: 618
		private global::System.Windows.Forms.NumericUpDown numericUpDown_RadarAutoID;

		// Token: 0x0400026B RID: 619
		private global::System.Windows.Forms.Label label_AutoIDExtraDelay;

		// Token: 0x0400026C RID: 620
		private global::System.Windows.Forms.DataGridViewTextBoxColumn FreeMonitorVillage;

		// Token: 0x0400026D RID: 621
		private global::System.Windows.Forms.DataGridViewTextBoxColumn FreeMonitorVillageStatus;

		// Token: 0x0400026E RID: 622
		private global::System.Windows.Forms.DataGridViewTextBoxColumn FreeMonitorTraders;

		// Token: 0x0400026F RID: 623
		private global::System.Windows.Forms.DataGridViewTextBoxColumn FreeMonitorScouts;

		// Token: 0x04000270 RID: 624
		private global::System.Windows.Forms.DataGridViewTextBoxColumn FreeMonitorRecruits;

		// Token: 0x04000271 RID: 625
		private global::System.Windows.Forms.DataGridViewTextBoxColumn FreeMonitorBanquets;

		// Token: 0x04000272 RID: 626
		private global::System.Windows.Forms.DataGridViewTextBoxColumn FreeMonitorPopularity;

		// Token: 0x04000273 RID: 627
		private global::System.Windows.Forms.DataGridViewTextBoxColumn FreeMonitorFaithPoints;

		// Token: 0x04000274 RID: 628
		private global::System.Windows.Forms.DataGridViewTextBoxColumn FreeMonitorConstrutionQueue;

		// Token: 0x04000275 RID: 629
		private global::System.Windows.Forms.DataGridViewCheckBoxColumn FreeMonitorIsCastleDamaged;

		// Token: 0x04000276 RID: 630
		private global::System.Windows.Forms.DataGridViewCheckBoxColumn FreeMonitorIsCastleEnlosed;

		// Token: 0x04000277 RID: 631
		private global::System.Windows.Forms.DataGridViewTextBoxColumn FreeMonitorCastleCompleteTime;

		// Token: 0x04000278 RID: 632
		private global::System.Windows.Forms.DataGridViewTextBoxColumn FreeMonitorAIsAround;

		// Token: 0x04000279 RID: 633
		private global::System.Windows.Forms.DataGridViewTextBoxColumn FreeMonitorCaptains;

		// Token: 0x0400027A RID: 634
		private global::System.Windows.Forms.Button button_TradeRoutesCopy;

		// Token: 0x0400027B RID: 635
		private global::System.Windows.Forms.Button button_TradeRoutesDelete;

		// Token: 0x0400027C RID: 636
		private global::System.Windows.Forms.Button button_TradeRoutesEdit;

		// Token: 0x0400027D RID: 637
		private global::System.Windows.Forms.Button button_TradeRoutesNew;
	}
}
