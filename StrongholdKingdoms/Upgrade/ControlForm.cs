using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms;
using Properties;
using Upgrade.Services;

namespace Upgrade
{
	// Token: 0x02000016 RID: 22
	public sealed partial class ControlForm : Form
	{
		// Token: 0x0600003D RID: 61 RVA: 0x00007E30 File Offset: 0x00006030
		internal static string GetLinkToVideo(string video)
		{
			return "https://shkbot.site/video/?mode=" + video;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00027700 File Offset: 0x00025900
		private void InitServices(bool onlineMode)
		{
			this.Services.Add(new MonitorService(new Log(this.Log), this.listBox_Subscriptions, this)
			{
				IntervalMultiplier = 3600000,
				Interval = 6,
				DefaultInterval = 6,
				Enabled = true,
				IsSubscribed = true,
				Name = "Monitor Service",
				NeedsToSleep = false
			});
			this.Services.Add(new DownloadVillagesService(new Log(this.Log))
			{
				IntervalMultiplier = 60000,
				Interval = 5,
				IsSubscribed = true,
				Name = "Download Villages",
				NeedsToSleep = false
			});
			this.Services.Add(new ScoutingService(new Log(this.Log), this.listBox_scoutFrom, this.listBox_ScoutingTypes, this.listBox_ScoutingTypes_Ignore, this.checkBox_sendOneScout)
			{
				IntervalMultiplier = 1000,
				Interval = 5,
				Name = "Scouting"
			});
			this.Services.Add(new TradeService(new Log(this.Log), this.dataGridView_Trade, this.numericUpDown_PacketsPerTrade, this.dataGridView_TradeRoutes)
			{
				IntervalMultiplier = 1000,
				Interval = 10,
				Name = "Trade"
			});
			this.Services.Add(new VillagelayoutService(new Log(this.Log), this.dataGridViewVillageLayoutsEdit)
			{
				IntervalMultiplier = 1000,
				Interval = 30,
				Name = "Village layout"
			});
			this.Services.Add(new RadarService(new Log(this.Log), this.dataGridView_RadarSettings, this.checkBox_RadarUseDefault, this.label_RadarEmailStatus, this.radarNotifyIcon, this.label_RadarAltAccounts, this.label_AutoID)
			{
				IntervalMultiplier = 1000,
				Interval = 5,
				Name = "Radar",
				SharedThread = false,
				NeedsToSleep = false
			});
			this.Services.Add(new TroopsrecruitingService(this.dataGridView_TroopsRecruiting, this.dataGridView_CapitalsRecruiting, this.dataGridView_FillVassals, new Log(this.Log))
			{
				IntervalMultiplier = 1000,
				Interval = 60,
				Name = "Troops recruiting"
			});
			this.Services.Add(new BanquetService(new Log(this.Log), this.dataGridView_Banquets)
			{
				IntervalMultiplier = 1000,
				Interval = 15,
				Name = "Banquet"
			});
			this.Services.Add(new PopularityRegulationService(new Log(this.Log))
			{
				IntervalMultiplier = 60000,
				Interval = 1,
				Name = "Popularity Regulation"
			});
			int num = PopularityRegulationService.LoadMode();
			if (num >= this.comboBox_PopularityRegulationMode.Items.Count)
			{
				num = 0;
			}
			this.comboBox_PopularityRegulationMode.SelectedIndex = num;
			this.Services.Add(new SpinService(new Log(this.Log))
			{
				IntervalMultiplier = 60000,
				Interval = 10,
				Name = "Spin"
			});
			this.Services.Add(new ResearchService(new Log(this.Log), this.listBox_Queue, this.listBox_ResearchList, this.textBox_CurrentResearch)
			{
				IntervalMultiplier = 1000,
				Interval = 15,
				Name = "Research"
			});
			this.Services.Add(new PredatorService(new Log(this.Log), this.dataGridView_PredatorPreys, this.dataGridView_FoundPreys, this.listBox_PredatorVillages, this.listBox_PredatorVassals, this.listBox_PredatorCapitals, this.checkBox_PredatorUseCastleTroops, this)
			{
				IntervalMultiplier = 1000,
				Interval = 5,
				Name = "Predator"
			});
			this.Services.Add(new FreeMonitorService(new Log(this.Log), this.dataGridView_FreeMonitor, this.checkedListBox_FreeMonitorColumns)
			{
				IntervalMultiplier = 1000,
				Interval = 60,
				Name = "Free Monitor",
				IsSubscribed = true
			});
			this.Services.Add(new MonkService(new Log(this.Log), this.dataGridView_Monks, new MakeMonksDelegate(this.GetService<RadarService>().MakeMonks))
			{
				IntervalMultiplier = 1000,
				Interval = 60,
				Name = "Monks"
			});
			this.Services.Add(new FreeCardCollector(new Log(this.Log))
			{
				IntervalMultiplier = 60000,
				Interval = 3,
				Name = "Free Card Collector",
				Enabled = true
			});
			this.Services.Add(new FeedService(this.webBrowser_Feed, this.radarNotifyIcon, new Log(this.Log))
			{
				IntervalMultiplier = 60000,
				Interval = 15,
				Name = "Feed",
				Enabled = true,
				IsSubscribed = true,
				NeedsToSleep = false
			});
			this.TimedAttacksService = new TimedAttacksService(new Log(this.Log))
			{
				Enabled = true
			};
			this.FiltersService = new FiltersService();
			this.CastleRepairService = new CastleRepairService(new Log(this.Log), this.dataGridView_RepairCastle, this.button_FixCastles)
			{
				Enabled = true
			};
			this.CardExpiryChecker = new CardExpiryChecker(new Log(this.Log), this.GetService<ScoutingService>(), this.GetService<TradeService>(), this.checkBox_Scout, this.checkBox_Trade);
			this.SharedThread = new Thread(new ParameterizedThreadStart(this.RunSharedThreadServices));
			this.SharedThread.Start(onlineMode);
			this.CreateAndStartThreads(onlineMode);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00027CB4 File Offset: 0x00025EB4
		public T GetService<T>() where T : class
		{
			foreach (ABaseService abaseService in this.Services)
			{
				if (abaseService is T)
				{
					return abaseService as T;
				}
			}
			return default(T);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00027D24 File Offset: 0x00025F24
		private void ViewVillageIDs()
		{
			if (!Program.mySettings.viewVillageIDs || !Program.mySettings.viewCapitalIDs)
			{
				this.Log(SK.Text("Options_Apply", "Apply") + ": \"" + SK.Text("Options_VillageIDs", "View Village IDs") + "\"", ControlForm.Tab.Main, false);
				this.Log(SK.Text("Options_Apply", "Apply") + ": \"" + SK.Text("Options_CapitalIDs", "View Capital IDs") + "\"", ControlForm.Tab.Main, false);
				Program.mySettings.viewVillageIDs = true;
				Program.mySettings.viewCapitalIDs = true;
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00007E3D File Offset: 0x0000603D
		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://shkbot.site");
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00027DCC File Offset: 0x00025FCC
		public ControlForm(bool onlineMode = true)
		{
			this.InitializeComponent();
			DX.Info.Clear();
			this.webBrowser_Feed.Url = new Uri("https://shkbot.site/feed.html", UriKind.Absolute);
			this.ViewVillageIDs();
			string[] array = Regex.Split(Application.StartupPath, "\\\\");
			this.Text = (this.FormHeading = string.Concat(new string[]
			{
				RemoteServices.Instance.UserName,
				" - ",
				Program.WorldName,
				" - SHKEducations Bot 9.8.5 [ ",
				array[array.Length - 1],
				" ]"
			}));
			if (!onlineMode)
			{
				GameEngine.Instance.World.VillageList = new VillageData[100000];
			}
			this.InitServices(onlineMode);
			this._actions = SettingsManager.CreateSettingsFolders();
			this.InitAutomaticActionsTab();
			LNG.InitLanguagesBox(this, this.comboBox_Language);
			this.dataGridView_ApplySelectAll(this);
			this.Log(LNG.Print("Hint: To Select All lines in a Column - click the Column Header"), ControlForm.Tab.Main, false);
			this.textBox_ToEmail.Text = Program.mySettings.Username;
			this.comboBox_RankUpMode.SelectedIndex = 0;
			this.InitContextMenu(this.contextMenuStrip_ResourcesQuickSelector);
			this.InitMainCheckBoxes();
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00007E4A File Offset: 0x0000604A
		public static string[] GetMainMethodArgs()
		{
			string[] array = new string[3];
			array[0] = "-installerversion";
			array[1] = "117";
			int num = 2;
			MySettings mySettings = Program.mySettings;
			array[num] = (((mySettings != null) ? mySettings.languageIdent : null) ?? "en");
			return array;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00027F54 File Offset: 0x00026154
		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (((this.tabControl1.SelectedTab.Name == "tabPage_Castle" && this.CastleRepairService.IsSubscribed) || (this.tabControl1.SelectedTab.Name == "tabPage_Predator" && this.GetService<PredatorService>().IsSubscribed)) && !PresetManager.Instance.IsDataReady)
			{
				this.Log(LNG.Print("Loading Presets From Server"), ControlForm.Tab.Main, false);
				PresetManager.Instance.LoadPresetsFromServer(new PresetPanel());
			}
			this.DGVSelectAll = true;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00027FE8 File Offset: 0x000261E8
		private void dataGridView_ApplySelectAll(Control control)
		{
			DataGridView dataGridView = control as DataGridView;
			if (dataGridView != null)
			{
				dataGridView.ColumnHeaderMouseClick += this.dataGridView_ColumnHeaderMouseClick;
				dataGridView.CellMouseUp += this.dataGridView_CellMouseUp;
				dataGridView.DataError += this.dataGridView_DataError;
				dataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
				return;
			}
			if (control.HasChildren)
			{
				foreach (object obj in control.Controls)
				{
					Control control2 = (Control)obj;
					this.dataGridView_ApplySelectAll(control2);
				}
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00028094 File Offset: 0x00026294
		private void dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			DataGridView dataGridView = sender as DataGridView;
			if (dataGridView != null && dataGridView.Columns[e.ColumnIndex].GetType() == typeof(DataGridViewCheckBoxColumn))
			{
				for (int i = 0; i < dataGridView.Rows.Count; i++)
				{
					dataGridView[e.ColumnIndex, i].Value = this.DGVSelectAll;
				}
				this.DGVSelectAll = !this.DGVSelectAll;
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00028110 File Offset: 0x00026310
		private void dataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.RowIndex != -1 && this.IsTradingVillageSelected())
			{
				DataGridView dataGridView = sender as DataGridView;
				if (dataGridView != null && dataGridView.Columns[e.ColumnIndex].CellType == typeof(DataGridViewCheckBoxCell))
				{
					dataGridView.EndEdit();
				}
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00028164 File Offset: 0x00026364
		private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			if (e.Exception.GetType() == typeof(ArgumentException))
			{
				object value = ((DataGridView)sender)[e.ColumnIndex, e.RowIndex].Value;
				this.Log(string.Format("Invalid setting: {0}. At: {1}", value, ((Control)sender).Name), ControlForm.Tab.Main, true);
				e.ThrowException = false;
			}
		}

		// Token: 0x06000049 RID: 73 RVA: 0x000281CC File Offset: 0x000263CC
		private void SelectedVillagesChanged(ABaseService service, ListBox listBox)
		{
			bool flag = false;
			if (service.Enabled)
			{
				flag = service.Enabled;
				service.Enabled = false;
			}
			service.SelectedVillages.Clear();
			foreach (object obj in listBox.SelectedItems)
			{
				string item = (string)obj;
				service.SelectedVillages.Add(ControlForm.GetId(item));
			}
			if (flag)
			{
				service.Enabled = flag;
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00007E7F File Offset: 0x0000607F
		public static int GetId(string item)
		{
			return int.Parse(item.TrimStart(new char[]
			{
				'['
			}).Split(new char[]
			{
				']'
			})[0]);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00007EA9 File Offset: 0x000060A9
		private void checkBox_FeedShouldNotify_CheckedChanged(object sender, EventArgs e)
		{
			this.GetService<FeedService>().ShouldNotify = this.checkBox_FeedShouldNotify.Checked;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00007EC1 File Offset: 0x000060C1
		private void CheckBox_CollectFreeCard_CheckedChanged(object sender, EventArgs e)
		{
			this.GetService<FreeCardCollector>().Enabled = this.checkBox_CollectFreeCard.Checked;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00007ED9 File Offset: 0x000060D9
		private void NumericUpDown_BotWorkPeriod_ValueChanged(object sender, EventArgs e)
		{
			WorkCycle.WorkPeriod = (int)this.numericUpDown_BotWorkPeriod.Value;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00007EF0 File Offset: 0x000060F0
		private void NumericUpDown_BotSleepPeriod_ValueChanged(object sender, EventArgs e)
		{
			WorkCycle.SleepPeriod = (int)this.numericUpDown_BotSleepPeriod.Value;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00007F07 File Offset: 0x00006107
		private void checkBox_BotCycleRandomPeriods_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.checkBox_BotCycleRandomPeriods.Checked)
			{
				MessageBox.Show(LNG.Print("Random Periods setting is highly recommended for safety of your account!"), LNG.Print("Warning!"));
			}
			WorkCycle.RandomPeriods = this.checkBox_BotCycleRandomPeriods.Checked;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00007F40 File Offset: 0x00006140
		internal void DisplayWorkCycleStatus(string status, int workPeriod = -1, int sleepPeriod = -1)
		{
			this.label_BotCycleStatusValue.Text = status;
			if (workPeriod != -1)
			{
				this.numericUpDown_BotWorkPeriod.Value = workPeriod;
			}
			if (sleepPeriod != -1)
			{
				this.numericUpDown_BotSleepPeriod.Value = sleepPeriod;
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00007F78 File Offset: 0x00006178
		private void button_OpenBotSettings_Click(object sender, EventArgs e)
		{
			Process.Start(ControlForm.SettingsFolder);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00007F85 File Offset: 0x00006185
		private void button2_Click_2(object sender, EventArgs e)
		{
			Process.Start("calc.exe");
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00007F92 File Offset: 0x00006192
		private void button_cacheSub_Click(object sender, EventArgs e)
		{
			CacheSub.Encrypt();
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00007F99 File Offset: 0x00006199
		private void button_cacheLoad_Click(object sender, EventArgs e)
		{
			this.GetService<MonitorService>().Load();
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00007FA6 File Offset: 0x000061A6
		private void checkBox_StayOnTop_CheckedChanged(object sender, EventArgs e)
		{
			base.TopMost = this.checkBox_StayOnTop.Checked;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00007FB9 File Offset: 0x000061B9
		private void button_MainHelp_Click(object sender, EventArgs e)
		{
			Process.Start(ControlForm.GetLinkToVideo("Main tab features"));
		}

		// Token: 0x06000057 RID: 87 RVA: 0x0002825C File Offset: 0x0002645C
		internal void SelectTab(string name)
		{
			foreach (object obj in this.tabControl1.TabPages)
			{
				TabPage tabPage = (TabPage)obj;
				if (tabPage.Name == name)
				{
					this.tabControl1.SelectTab(name);
					break;
				}
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00007FCB File Offset: 0x000061CB
		private void comboBox_Language_SelectionChangeCommitted(object sender, EventArgs e)
		{
			LNG.ApplyLNG(this.comboBox_Language.SelectedItem.ToString(), this);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000282D0 File Offset: 0x000264D0
		private void ControlForm_Load(object sender, EventArgs e)
		{
			try
			{
				Settings @default = Settings.Default;
				this.textBox_UserContactEmail.Text = @default.UserContactEmail;
				this.checkBox_stopTradeOnCardExpiry.Checked = @default.StopTradeOnCardsExpiry;
				this.checkBox_showPopupOnTradeExpiry.Checked = @default.ShowPopupOnTradeExpiry;
				this.checkBox_AutoRepairCastle.Checked = @default.RepairOnAIAttacks;
				this.checkBox_showPopupOnScoutsExpiry.Checked = @default.ShowPopupOnScoutsExpiry;
				this.checkBox_StopScoutsOnCardExpiry.Checked = @default.StopScoutOnCardsExpiry;
				this.checkBox_IsFullRefreshAllowed.Checked = @default.FullRefreshEnabled;
				this.checkBox_LoadMonksSettings.Checked = @default.LoadMonksSettings;
				this.checkBox_StartMonks.Checked = @default.StartMonks;
				this.CastleRepairService.RepairOnAIAttacks = @default.RepairOnAIAttacks;
				this.numericUpDown_BotSleepPeriod.Value = (WorkCycle.SleepPeriod = Math.Abs(@default.BotSleepPeriod));
				this.numericUpDown_BotWorkPeriod.Value = (WorkCycle.WorkPeriod = Math.Abs(@default.BotWorkPeriod));
				this.numericUpDown_MerchantsTradeLimit.Value = Math.Abs(@default.MerchantsTradeLimit);
				this.numericUpDown_MerchantsExchangeLimit.Value = Math.Abs(@default.MerchantsExchangeLimit);
				this.numericUpDown_KeepMonks.Value = Math.Abs(@default.MonksToKeep);
				this.numericUpDown_VassalTroopsMinimum.Value = Math.Abs(@default.VassalTroopsMinimum);
				this.checkBox_FeedShouldNotify.Checked = @default.FeedShouldNotify;
				this.checkBox_BotCycleRandomPeriods.Checked = @default.RandomWorkPeriodsEnabled;
				this.textBox_DiscordWebhook.Text = @default.DiscordWebhook;
				this.textBox_TelegramBotToken.Text = @default.TelegramBotToken;
				this.textBox_TelegramChatID.Text = @default.TelegramChatID;
				this.checkBox_StayOnTop.Checked = @default.StayOnTop;
				this.numericUpDown_minScouts.Value = Math.Abs(@default.MinimumScouts);
				this.checkBox_ScoutsWaitFreeSpace.Checked = @default.DoScoutsNeedFreeSpace;
				this.numericUpDown_LogsToKeep.Value = Math.Abs(@default.MaxLogsToKeep);
				this.numericUpDown_RadarAutoID.Value = Math.Abs(@default.AutoIDExtraDelay);
				this.radioButton_ScoutsPriorityByDistance.Checked = @default.ScoutingIgnoreType;
				RadarService.ProxyAddress = (this.textBox_ProxyAddress.Text = @default.ProxyAddress);
				Control control = this.textBox_ProxyPort;
				int num = RadarService.ProxyPort = @default.ProxyPort;
				control.Text = num.ToString();
				RadarService.ProxyUsername = (this.textBox_ProxyUsername.Text = @default.ProxyUsername);
				RadarService.ProxyPassword = (this.textBox_ProxyPassword.Text = @default.ProxyPassword);
				RadarService.UseProxy = (this.checkBox_TelegramUseProxy.Checked = @default.TelegramUseProxy);
				RadarService.UseCredentials = (this.checkBox_ProxyUseCredential.Checked = @default.ProxyUseCredential);
				if (!string.IsNullOrEmpty(@default.TabsOrder))
				{
					this.RestoreTabsOrder(@default.TabsOrder);
				}
				base.Height = @default.FormHeight;
				base.Width = @default.FormWidth;
				this.tabControl1.SelectTab("tabPage_Trade");
				this.splitContainer_Trade.SplitterDistance = @default.TradeSlider1Distance;
				this.splitContainer_Trade2.SplitterDistance = @default.TradeSlider2Distance;
				this.tabControl1.SelectedIndex = 0;
			}
			catch (ConfigurationErrorsException ex)
			{
				ABaseService.ProcessOldSettings(ex);
			}
			catch (Exception ex2)
			{
				ABaseService.MessageBoxNonModal(ex2.Message, LNG.Print("Error on loading settings"));
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x0002867C File Offset: 0x0002687C
		private void SaveSettings()
		{
			try
			{
				Settings @default = Settings.Default;
				@default.StopTradeOnCardsExpiry = this.checkBox_stopTradeOnCardExpiry.Checked;
				@default.ShowPopupOnTradeExpiry = this.checkBox_showPopupOnTradeExpiry.Checked;
				@default.ShowPopupOnScoutsExpiry = this.checkBox_showPopupOnScoutsExpiry.Checked;
				@default.StopScoutOnCardsExpiry = this.checkBox_StopScoutsOnCardExpiry.Checked;
				@default.RefreshEnabled = this.checkBox_DownloadVillages.Checked;
				@default.FullRefreshEnabled = this.checkBox_IsFullRefreshAllowed.Checked;
				@default.LoadMonksSettings = this.checkBox_LoadMonksSettings.Checked;
				@default.StartMonks = this.checkBox_StartMonks.Checked;
				@default.UserContactEmail = this.textBox_UserContactEmail.Text;
				@default.RepairOnAIAttacks = this.CastleRepairService.RepairOnAIAttacks;
				@default.BotSleepPeriod = WorkCycle.SleepPeriod;
				@default.BotWorkPeriod = WorkCycle.WorkPeriod;
				@default.MerchantsTradeLimit = (int)this.numericUpDown_MerchantsTradeLimit.Value;
				@default.MerchantsExchangeLimit = (int)this.numericUpDown_MerchantsExchangeLimit.Value;
				@default.MonksToKeep = (int)this.numericUpDown_KeepMonks.Value;
				@default.VassalTroopsMinimum = (int)this.numericUpDown_VassalTroopsMinimum.Value;
				@default.FeedShouldNotify = this.checkBox_FeedShouldNotify.Checked;
				@default.RandomWorkPeriodsEnabled = this.checkBox_BotCycleRandomPeriods.Checked;
				@default.DiscordWebhook = this.textBox_DiscordWebhook.Text;
				@default.TelegramBotToken = this.textBox_TelegramBotToken.Text;
				@default.TelegramChatID = this.textBox_TelegramChatID.Text;
				@default.StayOnTop = this.checkBox_StayOnTop.Checked;
				@default.ScoutingIgnoreType = this.radioButton_ScoutsPriorityByDistance.Checked;
				@default.MinimumScouts = (int)this.numericUpDown_minScouts.Value;
				@default.DoScoutsNeedFreeSpace = this.checkBox_ScoutsWaitFreeSpace.Checked;
				@default.MaxLogsToKeep = (int)this.numericUpDown_LogsToKeep.Value;
				@default.AutoIDExtraDelay = (int)this.numericUpDown_RadarAutoID.Value;
				@default.TelegramUseProxy = RadarService.UseProxy;
				@default.ProxyUseCredential = RadarService.UseCredentials;
				@default.ProxyAddress = RadarService.ProxyAddress;
				@default.ProxyPort = RadarService.ProxyPort;
				@default.ProxyUsername = RadarService.ProxyUsername;
				@default.ProxyPassword = RadarService.ProxyPassword;
				@default.TabsOrder = this.SaveTabsOrder();
				@default.TradeSlider2Distance = this.splitContainer_Trade2.SplitterDistance;
				@default.TradeSlider1Distance = this.splitContainer_Trade.SplitterDistance;
				@default.FormHeight = base.Height;
				@default.FormWidth = base.Width;
				@default.Language = this.comboBox_Language.SelectedItem.ToString();
				@default.Save();
			}
			catch (ConfigurationErrorsException ex)
			{
				ABaseService.ProcessOldSettings(ex);
			}
			catch (Exception ex2)
			{
				ABaseService.MessageBoxNonModal(ex2.Message, "Error on saving settings");
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00007FE3 File Offset: 0x000061E3
		public bool CheckAction(string action)
		{
			return Array.IndexOf<string>(this._actions, action) > -1;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00028968 File Offset: 0x00026B68
		public void AutomaticActions()
		{
			this.AutoRun();
			bool enabled = this.GetService<DownloadVillagesService>().Enabled;
			if (this.CheckAction("Load scouts settings"))
			{
				this.Button_LoadScoutingInfo_Click(null, EventArgs.Empty);
				if (enabled && this.CheckAction("Start scouting"))
				{
					this.checkBox_Scout.Checked = true;
				}
			}
			if (this.CheckAction("Load trade settings"))
			{
				this.GetService<TradeService>().LoadSettings(this.listBox_ActiveVillages, false);
				if (enabled && this.CheckAction("Start trading"))
				{
					this.checkBox_Trade.Checked = true;
				}
			}
			if (this.CheckAction("Load troops recruiting settings"))
			{
				this.loadTroopsRecruiting_Click(null, EventArgs.Empty);
				if (enabled && this.CheckAction("Recruit troops"))
				{
					this.checkBox_recruitingtroops.Checked = true;
				}
			}
			if (this.CheckAction("Load Banquets"))
			{
				this.GetService<BanquetService>().Load();
				if (enabled && this.CheckAction("Banquet"))
				{
					this.PlayBanquets.Checked = true;
				}
			}
			if (this.CheckAction("Load Radar settings"))
			{
				this.GetService<RadarService>().Load(false);
				if (enabled && this.CheckAction("Monitor attacks"))
				{
					this.checkBox_Monitor.Checked = true;
				}
			}
			if (this.CheckAction("Load village layouts"))
			{
				this.GetService<VillagelayoutService>().LoadLayouts();
				if (enabled && this.CheckAction("Start building villages"))
				{
					this.checkBox_VillageLayouts.Checked = true;
				}
			}
			if (this.CheckAction("Load Researches"))
			{
				this.GetService<ResearchService>().Load();
				if (this.CheckAction("Start Researching"))
				{
					this.checkBox_Research.Checked = true;
				}
			}
			if (enabled && this.CheckAction("Start regulate popularity"))
			{
				this.RegulatePopularity.Checked = true;
			}
			if (this.CheckAction("Load castle repair settings"))
			{
				this.CastleRepairService.ShouldLoadSettings = true;
			}
			if (this.CheckAction("Load Predator Settings"))
			{
				this.GetService<PredatorService>().ShouldLoadSettings = true;
			}
			if (this.listBox_ActiveVillages.Items.Count > 0)
			{
				string text = this.listBox_ActiveVillages.Items[0].ToString();
				int id = ControlForm.GetId(text);
				this._selectedVillageId = id;
				this.SelectTradingVillage(id, text);
				this.SelectScoutingVillage(id, text);
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00028B90 File Offset: 0x00026D90
		private void AutoRun()
		{
			try
			{
				Settings @default = Settings.Default;
				this.GetService<DownloadVillagesService>().Load(this.listBox_Refresh);
				this.GetService<DownloadVillagesService>().Enabled = true;
				if (@default.LoadMonksSettings)
				{
					this.GetService<MonkService>().Load();
					this.checkBox_EnableMonks.Checked = @default.StartMonks;
				}
			}
			catch (ConfigurationErrorsException ex)
			{
				ABaseService.ProcessOldSettings(ex);
			}
			catch (Exception ex2)
			{
				ABaseService.ReportError(ex2, ControlForm.Tab.Main);
				ABaseService.MessageBoxNonModal(ex2.Message, LNG.Print("Error during AutoRun"));
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00028C2C File Offset: 0x00026E2C
		private void InitAutomaticActionsTab()
		{
			try
			{
				foreach (object obj in this.tabPage_AutomaticActions.Controls)
				{
					CheckBox checkBox = (CheckBox)obj;
					string value = checkBox.Name.Split(new char[]
					{
						'_'
					})[1];
					for (int i = 0; i < this._actions.Length; i++)
					{
						if (this._actions[i].Replace(" ", "").EndsWith(value))
						{
							checkBox.Checked = !this._actions[i].StartsWith("-");
							break;
						}
					}
				}
			}
			catch (Exception ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.Main);
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00028D08 File Offset: 0x00026F08
		private void ActionChanged(object sender, EventArgs e)
		{
			try
			{
				CheckBox checkBox = (CheckBox)sender;
				string value = checkBox.Name.Split(new char[]
				{
					'_'
				})[1];
				for (int i = 0; i < this._actions.Length; i++)
				{
					if (this._actions[i].Replace(" ", "").EndsWith(value))
					{
						if (checkBox.Checked)
						{
							this._actions[i] = this._actions[i].Replace("-", "");
						}
						else if (!checkBox.Checked)
						{
							this._actions[i] = "-" + this._actions[i];
						}
						File.WriteAllLines(ControlForm.SettingsFolder + "AutomaticActions.txt", this._actions);
						break;
					}
				}
			}
			catch (Exception ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.Main);
			}
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00007FF4 File Offset: 0x000061F4
		private void checkBox_WriteLogs_CheckedChanged(object sender, EventArgs e)
		{
			this._writeLogs = this.checkBox_WriteLogs.Checked;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00008007 File Offset: 0x00006207
		private void numericUpDown_LogsToKeep_ValueChanged(object sender, EventArgs e)
		{
			this._maxLogsToKeep = (int)this.numericUpDown_LogsToKeep.Value;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00028DF0 File Offset: 0x00026FF0
		public void Log(string text, ControlForm.Tab tab = ControlForm.Tab.Main, bool isError = false)
		{
			if (!this._writeLogs && !isError)
			{
				return;
			}
			RichTextBox rtb = this.FindRichTextBox("richTextBox" + tab.ToString());
			if (rtb == null || rtb.IsDisposed)
			{
				return;
			}
			string msg = string.Format("[ {0} ] {1} \r\n", DateTime.Now, text);
			if (rtb.InvokeRequired)
			{
				rtb.BeginInvoke(new MethodInvoker(delegate()
				{
					this.AppendText(rtb, msg, text, tab, isError);
				}));
				return;
			}
			this.AppendText(rtb, msg, text, tab, isError);
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00028ED8 File Offset: 0x000270D8
		private void AppendText(RichTextBox rtb, string msg, string text, ControlForm.Tab tab, bool isError)
		{
			if (rtb.Lines.Length > this._maxLogsToKeep)
			{
				rtb.Clear();
			}
			int length = rtb.Text.Length;
			rtb.AppendText(msg);
			if (isError)
			{
				rtb.SelectionStart = length;
				rtb.SelectionLength = msg.Length;
				rtb.SelectionColor = global::ARGBColors.Red;
				this.richTextBox_Errors.AppendText(string.Format("[ {0} ][{1}] {2} \r\n", DateTime.Now, tab, text));
				this.SetErrorsCountIndicator(this.richTextBox_Errors.Lines.Length - 1);
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x0000801F File Offset: 0x0000621F
		private void button_ClearErrors_Click(object sender, EventArgs e)
		{
			this.richTextBox_Errors.Clear();
			this.SetErrorsCountIndicator(0);
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00028F6C File Offset: 0x0002716C
		private void SetErrorsCountIndicator(int count)
		{
			this.tabPage_Error.Text = LNG.Print("Errors");
			if (count > 0)
			{
				TabPage tabPage = this.tabPage_Error;
				tabPage.Text += string.Format(" ({0})", count);
			}
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00028FB8 File Offset: 0x000271B8
		private RichTextBox FindRichTextBox(string name)
		{
			if (name != null)
			{
				uint num = PrivateImplementationDetails.ComputeStringHash(name);
				if (num <= 1617029855U)
				{
					if (num <= 670721451U)
					{
						if (num != 204184553U)
						{
							if (num != 245840533U)
							{
								if (num == 670721451U)
								{
									if (name == "richTextBoxMonks")
									{
										return this.richTextBoxMonks;
									}
								}
							}
							else if (name == "richTextBoxCastle")
							{
								return this.richTextBoxCastle;
							}
						}
						else if (name == "richTextBoxScout")
						{
							return this.richTextBoxScout;
						}
					}
					else if (num <= 1344707836U)
					{
						if (num != 1256746634U)
						{
							if (num == 1344707836U)
							{
								if (name == "richTextBoxMain")
								{
									return this.richTextBoxMain;
								}
							}
						}
						else if (name == "richTextBoxPopularityRegulation")
						{
							return this.richTextBoxPopularityRegulation;
						}
					}
					else if (num != 1489175386U)
					{
						if (num == 1617029855U)
						{
							if (name == "richTextBoxRadar")
							{
								return this.richTextBoxRadar;
							}
						}
					}
					else if (name == "richTextBoxVillageLayouts")
					{
						return this.richTextBoxVillageLayouts;
					}
				}
				else if (num <= 3138658950U)
				{
					if (num <= 2244176221U)
					{
						if (num != 1990607714U)
						{
							if (num == 2244176221U)
							{
								if (name == "richTextBoxBanquetting")
								{
									return this.richTextBoxBanquetting;
								}
							}
						}
						else if (name == "richTextBoxSpins")
						{
							return this.richTextBoxSpins;
						}
					}
					else if (num != 2301106662U)
					{
						if (num == 3138658950U)
						{
							if (name == "richTextBoxTroopsRecruiting")
							{
								return this.richTextBoxTroopsRecruiting;
							}
						}
					}
					else if (name == "richTextBoxPredator")
					{
						return this.richTextBoxPredator;
					}
				}
				else if (num <= 3606008733U)
				{
					if (num != 3154446593U)
					{
						if (num == 3606008733U)
						{
							if (name == "richTextBoxTrade")
							{
								return this.richTextBoxTrade;
							}
						}
					}
					else if (name == "richTextBoxTimedAttacks")
					{
						return this.richTextBoxTimedAttacks;
					}
				}
				else if (num != 3915408080U)
				{
					if (num == 4163867896U)
					{
						if (name == "richTextBoxRefresh")
						{
							return this.richTextBox_Refresh;
						}
					}
				}
				else if (name == "richTextBoxResearch")
				{
					return this.richTextBoxResearch;
				}
			}
			return this.richTextBoxMain;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0002925C File Offset: 0x0002745C
		private void button_ClearLogs_Click(object sender, EventArgs e)
		{
			this.ClearRichTextBoxes(this.tabControl1);
			foreach (TabHost tabHost in this.TabHosts)
			{
				this.ClearRichTextBoxes(tabHost.tabControl1);
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x000292C0 File Offset: 0x000274C0
		private void ClearRichTextBoxes(Control control)
		{
			RichTextBox richTextBox = control as RichTextBox;
			if (richTextBox != null)
			{
				richTextBox.Clear();
				return;
			}
			if (control.HasChildren)
			{
				foreach (object obj in control.Controls)
				{
					Control control2 = (Control)obj;
					this.ClearRichTextBoxes(control2);
				}
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00029334 File Offset: 0x00027534
		private void CreateAndStartThreads(bool online)
		{
			foreach (ABaseService abaseService in from s in this.Services
			where !s.SharedThread
			select s)
			{
				this.BotThreads.Add(new Thread(new ParameterizedThreadStart(abaseService.Action))
				{
					Name = abaseService.Name
				});
				this.listBox_ModuleDisable.Items.Add(abaseService.Name);
			}
			foreach (Thread thread in this.BotThreads)
			{
				thread.Start(online);
			}
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00029424 File Offset: 0x00027624
		private void RunSharedThreadServices(object online)
		{
			IEnumerable<ABaseService> source = from s in this.Services
			where s.SharedThread
			select s;
			for (;;)
			{
				if (!source.Any((ABaseService s) => !s.Exiting.WaitOne(1000)))
				{
					break;
				}
				foreach (ABaseService abaseService in from s in source
				orderby s.LastRan
				select s)
				{
					if (abaseService.ShouldRun())
					{
						while ((bool)online && !GameEngine.Instance.World.isDownloadComplete() && abaseService.Name != "Monitor Service")
						{
						}
						try
						{
							abaseService.ConcreteAction();
						}
						catch (Exception ex)
						{
							ABaseService.ReportError(ex, ControlForm.Tab.Main);
						}
						abaseService.LastRan = DateTime.Now;
					}
				}
			}
			this.Log(LNG.Print("Shared thread modules switched off"), ControlForm.Tab.Main, false);
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00029554 File Offset: 0x00027754
		private void listBox_ModuleDisable_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			int num = this.listBox_ModuleDisable.IndexFromPoint(e.Location);
			if (num == -1)
			{
				return;
			}
			string serviceName = this.listBox_ModuleDisable.Items[num].ToString();
			ABaseService abaseService = this.Services.SingleOrDefault((ABaseService s) => s.Name == serviceName);
			if (abaseService == null)
			{
				this.Log(serviceName + " " + LNG.Print("is not initialized"), ControlForm.Tab.Main, false);
				return;
			}
			abaseService.Exiting.Set();
			abaseService.ModuleSleep.Set();
			this.listBox_ModuleDisable.Items.Remove(serviceName);
			this.listBox_ModuleDisable.SelectedIndex = -1;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00029614 File Offset: 0x00027814
		private void InitMainCheckBoxes()
		{
			this.MainCheckBoxes = new CheckBox[]
			{
				this.checkBox_EnableRefresh,
				this.checkBox_FreeMonitorEnable,
				this.checkBox_Monitor,
				this.checkBox_Trade,
				this.checkBox_Scout,
				this.checkBox_Banquet,
				this.checkBox_Research,
				this.checkBox_VillageLayouts,
				this.checkBox_Spin,
				this.checkBox_recruitingtroops,
				this.RegulatePopularity,
				this.checkBox_EnableMonks,
				this.checkBox_StartHunting
			};
		}

		// Token: 0x0600006D RID: 109 RVA: 0x000296A8 File Offset: 0x000278A8
		private void Button_PauseEveryThing_Click(object sender, EventArgs e)
		{
			if (this.isPaused)
			{
				for (int i = 0; i < this.MainCheckBoxes.Length; i++)
				{
					this.MainCheckBoxes[i].Checked = this.PausedState[i];
				}
				this.GetService<FeedService>().Enabled = true;
				this.button_PauseEveryThing.Text = LNG.Print("Stop All Modules!");
				this.isPaused = false;
				this.PausedState = null;
				return;
			}
			this.PausedState = new bool[this.MainCheckBoxes.Length];
			for (int j = 0; j < this.MainCheckBoxes.Length; j++)
			{
				this.PausedState[j] = this.MainCheckBoxes[j].Checked;
				this.MainCheckBoxes[j].Checked = false;
			}
			this.GetService<FeedService>().Enabled = false;
			this.button_PauseEveryThing.Text = LNG.Print("Continue");
			this.isPaused = true;
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00029788 File Offset: 0x00027988
		public void ExitAllServices()
		{
			for (int i = 0; i < this.Services.Count; i++)
			{
				this.Services[i].Exiting.Set();
				this.Services[i].ModuleSleep.Set();
			}
			foreach (Thread thread in this.BotThreads)
			{
				thread.Join();
			}
			this.SharedThread.Join();
		}

		// Token: 0x0600006F RID: 111 RVA: 0x0002982C File Offset: 0x00027A2C
		private void BotForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!this.IsProgrammaticClosing && e.CloseReason == CloseReason.UserClosing && MessageBox.Show(LNG.Print("Turn off Bot"), LNG.Print("Turn off Bot"), MessageBoxButtons.OKCancel) != DialogResult.OK)
			{
				e.Cancel = true;
				return;
			}
			this.Text += " Turn Off...";
			this._writeLogs = false;
			this.ExitAllServices();
			this.GetService<RadarService>().SoundPlayer.Close();
			this.GetService<RadarService>().CloseAllMessages(sender, e);
			this.SaveSettings();
		}

		// Token: 0x06000070 RID: 112 RVA: 0x000298B8 File Offset: 0x00027AB8
		public void AddFakeVillages()
		{
			this.AddFakeVillage(12345, "Highland", false, 2019, 1, 100, 30);
			this.AddFakeVillage(67890, "Plains", false, 2019, 7, 30, 200);
			this.AddFakeVillage(13579, "Marsh", false, 2019, 6, 60, 350);
			this.AddFakeVillage(1007, "River 1", false, 2019, 2, 250, 200);
			this.AddFakeVillage(23423, "River 2", false, 2019, 3, 450, 200);
			this.AddFakeVillage(12367, "Mountain Peak", false, 2019, 1, 550, 35);
			this.AddFakeVillage(13590, "Valley Side", false, 2019, 8, 600, 200);
			this.AddFakeVillage(67891, "Lowland", false, 2019, 0, 550, 350);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x000299C0 File Offset: 0x00027BC0
		public void AddFakeVillage(int villageId, string name, bool isCapital, int parishCapitalId, short terrain = 0, short x1 = 0, short y1 = 0)
		{
			string text = string.Format("[{0}] {1}", villageId, name);
			GameEngine.Instance.World.VillageList[villageId] = new VillageData
			{
				villageTerrain = terrain,
				x = x1,
				y = y1,
				villageName = name,
				id = villageId
			};
			this.GetService<RadarService>().SelectedVillages.Add(villageId);
			int villageInsertionIndex = this.GetVillageInsertionIndex(villageId, isCapital, false);
			if (isCapital)
			{
				this.listBox_PredatorCapitals.Items.Add(text);
				this.GetService<PredatorService>().Capitals.Add(villageId);
				return;
			}
			this.GetService<FreeMonitorService>().SelectedVillages.Add(villageId);
			this.GetService<DownloadVillagesService>().SelectedVillages.Add(villageId);
			this.comboBox_testInderdict.Items.Add(text);
			if (this.comboBox_testInderdict.SelectedIndex == -1)
			{
				this.comboBox_testInderdict.SelectedIndex = 0;
			}
			List<int> quickTargets = new List<int>
			{
				parishCapitalId
			};
			TradeType[] array = new TradeType[24];
			for (int i = 0; i < 24; i++)
			{
				array[i] = new TradeType
				{
					ResourceId = TradeService.tradeTypeId[i],
					MaxBuyPrice = 150
				};
			}
			this.GetService<TradeService>().VillagesTradeInfo.Add(villageId, new VillageTradeInfo(array, quickTargets, true));
			this.listBox_ActiveVillages.Items.Add(text);
			this.comboBox_TradeVillages.Items.Add(text);
			this.listBox_ActiveVillages.SetSelected(this.listBox_ActiveVillages.Items.Count - 1, true);
			this.listBox_scoutFrom.Items.Add(text);
			this.comboBox_ScoutingVillages.Items.Add(text);
			this.listBox_scoutFrom.SetSelected(this.listBox_scoutFrom.Items.Count - 1, true);
			this.GetService<ScoutingService>().SelectedVillages.Add(villageId);
			this.GetService<ScoutingService>().ResForScouting.Add(villageId, new List<int>());
			this.GetService<ScoutingService>().ResForScoutingIgnore.Add(villageId, new List<int>
			{
				100,
				106,
				107,
				108,
				109,
				112,
				113,
				114,
				115,
				116,
				117,
				118,
				119,
				121,
				122,
				123,
				124,
				125,
				126,
				128,
				129,
				130,
				131,
				132,
				133
			});
			this.listBox_PopularityRegulation.Items.Add(text);
			this.GetService<PopularityRegulationService>().SelectedVillages.Add(villageId);
			this.listBox_PopularityRegulation.SetSelected(this.listBox_PopularityRegulation.Items.Count - 1, true);
			this.listBox_VillageLayouts.Items.Add(text);
			this.listBox_VillageLayouts.SetSelected(this.listBox_VillageLayouts.Items.Count - 1, true);
			this.comboBox_villageLayouts.Items.Add(text);
			this.GetService<VillagelayoutService>().AddVillage(villageId);
			this.dataGridView_TroopsRecruiting.Rows.Add(new object[]
			{
				text,
				false,
				0,
				0,
				0,
				0,
				0,
				0
			});
			this.CastleRepairService.InsertVillage(villageInsertionIndex, text);
			this.listBox_PredatorVillages.Items.Add(text);
			this.GetService<PredatorService>().Villages.Add(villageId);
			this.listBox_Interdict.Items.Insert(villageInsertionIndex, text);
			this.Log(string.Format("Village added to the Bot: {0}", villageId), ControlForm.Tab.Main, false);
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00029DEC File Offset: 0x00027FEC
		public void AddVillage(int villageId)
		{
			try
			{
				VillageData villageData = GameEngine.Instance.World.getVillageData(villageId);
				string villageName = villageData.villageName;
				this.GetService<RadarService>().SelectedVillages.Add(villageId);
				int villageInsertionIndex = this.GetVillageInsertionIndex(villageId, villageData.Capital, false);
				int villageInsertionIndex2 = this.GetVillageInsertionIndex(villageId, villageData.Capital, true);
				this.listBox_Refresh.Items.Insert(villageInsertionIndex2, villageName);
				this.GetService<DownloadVillagesService>().AddVillage(villageId);
				this.listBox_Refresh.SetSelected(villageInsertionIndex2, true);
				if (villageData.Capital)
				{
					this.listBox_PredatorCapitals.Items.Insert(villageInsertionIndex, villageName);
					this.GetService<PredatorService>().Capitals.Insert(villageInsertionIndex, villageId);
					this.dataGridView_CapitalsRecruiting.Rows.Insert(villageInsertionIndex, new object[]
					{
						villageName,
						false,
						0,
						0,
						0,
						0,
						0,
						0
					});
					this.Log(LNG.Print("Village added to the Bot") + ": " + villageData.villageName, ControlForm.Tab.Main, false);
				}
				else
				{
					this.GetService<FreeMonitorService>().SelectedVillages.Insert(villageInsertionIndex, villageId);
					this.comboBox_testInderdict.Items.Insert(villageInsertionIndex, villageName);
					if (this.comboBox_testInderdict.SelectedIndex == -1)
					{
						this.comboBox_testInderdict.SelectedIndex = 0;
					}
					int regionCapitalVillage = GameEngine.Instance.World.getRegionCapitalVillage((int)villageData.regionID);
					List<int> quickTargets = new List<int>
					{
						regionCapitalVillage
					};
					TradeType[] array = new TradeType[24];
					for (int i = 0; i < 24; i++)
					{
						array[i] = new TradeType
						{
							ResourceId = TradeService.tradeTypeId[i],
							MaxBuyPrice = 150
						};
					}
					this.GetService<TradeService>().VillagesTradeInfo.Add(villageId, new VillageTradeInfo(array, quickTargets, true));
					this.listBox_ActiveVillages.Items.Insert(villageInsertionIndex, villageName);
					this.comboBox_TradeVillages.Items.Insert(villageInsertionIndex, villageName);
					this.listBox_ActiveVillages.SetSelected(villageInsertionIndex, true);
					this.listBox_scoutFrom.Items.Insert(villageInsertionIndex, villageName);
					this.comboBox_ScoutingVillages.Items.Insert(villageInsertionIndex, villageName);
					this.listBox_scoutFrom.SetSelected(villageInsertionIndex, true);
					this.GetService<ScoutingService>().SelectedVillages.Insert(villageInsertionIndex, villageId);
					this.GetService<ScoutingService>().ResForScouting.Add(villageId, new List<int>
					{
						100,
						125,
						124,
						118,
						123,
						109,
						115,
						133,
						119,
						107,
						126,
						121,
						122,
						108,
						114,
						106,
						116,
						117,
						113,
						112
					});
					this.GetService<ScoutingService>().ResForScoutingIgnore.Add(villageId, new List<int>
					{
						128,
						129,
						130,
						131,
						132
					});
					this.GetService<BanquetService>().InsertVillage(villageInsertionIndex, villageName);
					this.listBox_PopularityRegulation.Items.Insert(villageInsertionIndex, villageName);
					this.GetService<PopularityRegulationService>().SelectedVillages.Insert(villageInsertionIndex, villageId);
					this.listBox_PopularityRegulation.SetSelected(villageInsertionIndex, true);
					this.listBox_VillageLayouts.Items.Insert(villageInsertionIndex, villageName);
					this.listBox_VillageLayouts.SetSelected(villageInsertionIndex, true);
					this.comboBox_villageLayouts.Items.Insert(villageInsertionIndex, villageName);
					this.GetService<VillagelayoutService>().AddVillage(villageId);
					this.dataGridView_TroopsRecruiting.Rows.Insert(villageInsertionIndex, new object[]
					{
						villageName,
						false,
						0,
						0,
						0,
						0,
						0,
						0
					});
					this.CastleRepairService.InsertVillage(villageInsertionIndex, villageName);
					this.listBox_PredatorVillages.Items.Insert(villageInsertionIndex, villageName);
					this.GetService<PredatorService>().Villages.Insert(villageInsertionIndex, villageId);
					this.listBox_Interdict.Items.Insert(villageInsertionIndex, villageName);
					this.GetService<MonkService>().SelectedVillages.Add(villageId);
					this.Log(LNG.Print("Village added to the Bot") + ": " + villageData.villageName, ControlForm.Tab.Main, false);
				}
			}
			catch (Exception ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.Main);
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x0002A2C8 File Offset: 0x000284C8
		public void RemoveVillage(int villageId)
		{
			string text = "";
			foreach (object obj in this.listBox_Refresh.Items)
			{
				string text2 = (string)obj;
				if (ControlForm.GetId(text2) == villageId)
				{
					text = text2;
				}
			}
			if (string.IsNullOrEmpty(text))
			{
				MyMessageBox.Show(string.Format("{0} {1}", villageId, LNG.Print("village is not found to remove from Bot. Please re-enter the game world!")));
				return;
			}
			this.listBox_Refresh.Items.Remove(text);
			if (GameEngine.Instance.World.isCapital(villageId))
			{
				this.GetService<PredatorService>().SelectedCapitals.Remove(villageId);
				this.listBox_PredatorCapitals.Items.Remove(text);
				this.GetService<PredatorService>().Capitals.Remove(villageId);
				SettingsManager.RemoveVillageFromGrid(this.dataGridView_CapitalsRecruiting, villageId);
				this.Log(LNG.Print("Village removed from Bot") + ": " + text, ControlForm.Tab.Main, false);
				return;
			}
			for (int i = 0; i < this.Services.Count; i++)
			{
				this.Services[i].SelectedVillages.Remove(villageId);
			}
			this.GetService<TradeService>().VillagesTradeInfo.Remove(villageId);
			this.listBox_ActiveVillages.Items.Remove(text);
			this.comboBox_TradeVillages.Items.Remove(text);
			this.GetService<TradeService>().RemoveVillageFromRoutes(villageId);
			this.GetService<ScoutingService>().ResForScouting.Remove(villageId);
			this.GetService<ScoutingService>().ResForScoutingIgnore.Remove(villageId);
			this.listBox_scoutFrom.Items.Remove(text);
			this.comboBox_ScoutingVillages.Items.Remove(text);
			this.GetService<BanquetService>().RemoveVillage(villageId);
			this.listBox_PopularityRegulation.Items.Remove(text);
			this.listBox_VillageLayouts.Items.Remove(text);
			this.comboBox_villageLayouts.Items.Remove(text);
			this.GetService<VillagelayoutService>().RemoveVillage(villageId);
			SettingsManager.RemoveVillageFromGrid(this.dataGridView_TroopsRecruiting, villageId);
			SettingsManager.RemoveVillageFromGrid(this.dataGridView_RepairCastle, villageId);
			this.listBox_PredatorVillages.Items.Remove(text);
			this.GetService<PredatorService>().Villages.Remove(villageId);
			this.listBox_Interdict.Items.Remove(text);
			this.GetService<MonkService>().SelectedVillages.Remove(villageId);
			this.GetService<MonkService>().RemoveVillages(villageId);
			this.Log(LNG.Print("Village removed from Bot") + ": " + text, ControlForm.Tab.Main, false);
		}

		// Token: 0x06000074 RID: 116 RVA: 0x0002A568 File Offset: 0x00028768
		public int GetVillageInsertionIndex(int villageId, bool isCapital, bool fullList)
		{
			string villageNameOnly = GameEngine.Instance.World.getVillageNameOnly(villageId);
			int num = 0;
			List<int> list;
			if (fullList)
			{
				list = this.GetService<DownloadVillagesService>().SelectedVillages.ToList<int>();
			}
			else
			{
				list = (isCapital ? this.GetService<PredatorService>().Capitals.ToList<int>() : this.GetService<FreeMonitorService>().SelectedVillages.ToList<int>());
			}
			foreach (int villageID in list)
			{
				string villageNameOnly2 = GameEngine.Instance.World.getVillageNameOnly(villageID);
				if (villageNameOnly == villageNameOnly2)
				{
					break;
				}
				if (villageNameOnly.CompareTo(villageNameOnly2) == -1)
				{
					break;
				}
				num++;
			}
			if (num <= list.Count)
			{
				return num;
			}
			return list.Count - 1;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x0002A640 File Offset: 0x00028840
		internal void button_CopySettings_Click(object sender, EventArgs e)
		{
			int moduleToSelect = -1;
			int villageToSelect = -1;
			List<string> listOfModules = new List<string>
			{
				"Scouting",
				"Trade",
				"Village",
				"Castle",
				"Recruiting",
				"Banquet",
				"Popularity"
			};
			IEnumerable<string> enumerable = this.listBox_ActiveVillages.Items.Cast<string>();
			string name = this.tabControl1.SelectedTab.Name;
			if (name != null)
			{
				uint num = PrivateImplementationDetails.ComputeStringHash(name);
				if (num <= 1402670767U)
				{
					if (num <= 709191094U)
					{
						if (num != 109241228U)
						{
							if (num == 709191094U)
							{
								if (name == "tabPage_Trade")
								{
									moduleToSelect = 1;
									villageToSelect = ControlForm.GetId(this.groupBox_TradingVillage.Text);
								}
							}
						}
						else if (name == "tabPage_Castle")
						{
							moduleToSelect = 3;
							villageToSelect = this.GetSelectedRowVillageID(this.dataGridView_RepairCastle);
						}
					}
					else if (num != 1169996230U)
					{
						if (num == 1402670767U)
						{
							if (name == "tabPage_PopularityRegulation")
							{
								moduleToSelect = 6;
								villageToSelect = InterfaceMgr.Instance.OwnSelectedVillage;
							}
						}
					}
					else if (name == "tabPage_Banquet")
					{
						moduleToSelect = 5;
						villageToSelect = this.GetSelectedRowVillageID(this.dataGridView_Banquets);
					}
				}
				else if (num <= 3125881927U)
				{
					if (num != 2397690083U)
					{
						if (num == 3125881927U)
						{
							if (name == "tabPage_Predator")
							{
								moduleToSelect = 0;
								listOfModules = new List<string>
								{
									"Predator"
								};
								enumerable = this.GetService<PredatorService>().PreysNames;
								villageToSelect = this.GetSelectedRowIndex(this.dataGridView_PredatorPreys);
							}
						}
					}
					else if (name == "tabPage_Troopsrecruiting")
					{
						if (this.tabControl_TroopsRecruiting.SelectedTab.Name == "tabPage_VassalsTroopsRecruiting")
						{
							listOfModules = new List<string>
							{
								"Vassals"
							};
							enumerable = this.listBox_PredatorVassals.Items.Cast<string>();
							moduleToSelect = 0;
							villageToSelect = this.GetSelectedRowVillageID(this.dataGridView_FillVassals);
						}
						else
						{
							moduleToSelect = 4;
							villageToSelect = this.GetSelectedRowVillageID(this.dataGridView_TroopsRecruiting);
						}
					}
				}
				else if (num != 3845030030U)
				{
					if (num == 4069123478U)
					{
						if (name == "tabPage_Scouting")
						{
							moduleToSelect = 0;
							villageToSelect = this.GetService<ScoutingService>().SelectedScoutingVillageId;
						}
					}
				}
				else if (name == "tabPage_Villagelayout")
				{
					moduleToSelect = 2;
					villageToSelect = this._villageLayoutId;
				}
			}
			if (enumerable.Count<string>() < 1)
			{
				MyMessageBox.Show(LNG.Print("Nothing to copy!"));
				return;
			}
			this.copySettings = new CopySettings(new CopySettingsDel(this.CopySettings), listOfModules, enumerable, moduleToSelect, villageToSelect);
			this.copySettings.Show();
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00008033 File Offset: 0x00006233
		internal int GetSelectedRowIndex(DataGridView grid)
		{
			if (grid.SelectedCells.Count > 0)
			{
				return grid.SelectedCells[0].RowIndex;
			}
			return -1;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00008056 File Offset: 0x00006256
		internal int GetSelectedRowVillageID(DataGridView grid)
		{
			if (grid.SelectedCells.Count > 0)
			{
				return ControlForm.GetId(grid[0, grid.SelectedCells[0].RowIndex].Value.ToString());
			}
			return -1;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x0002A94C File Offset: 0x00028B4C
		public void CopySettings(IEnumerable<string> listOfModules, string sampleVillage, IEnumerable<string> listOfVillages, bool saveSettings)
		{
			if (listOfModules.Contains("Predator"))
			{
				SettingsManager.CopyPredatorGridContent(this.dataGridView_PredatorPreys, listOfVillages, sampleVillage);
				if (saveSettings)
				{
					this.GetService<PredatorService>().Save();
				}
				return;
			}
			int id = ControlForm.GetId(sampleVillage);
			if (listOfModules.Contains("Vassals"))
			{
				SettingsManager.CopyDataGridViewContent(this.dataGridView_FillVassals, listOfVillages, id);
				if (saveSettings)
				{
					this.GetService<TroopsrecruitingService>().Save();
				}
				return;
			}
			if (listOfModules.Contains("Scouting"))
			{
				this.GetService<ScoutingService>().CopySettings(listOfVillages, id, saveSettings);
			}
			if (listOfModules.Contains("Trade"))
			{
				this.GetService<TradeService>().CopySettings(this.listBox_ActiveVillages, listOfVillages, id, saveSettings);
			}
			if (listOfModules.Contains("Village"))
			{
				this.GetService<VillagelayoutService>().CopySettings(this.listBox_VillageLayouts, listOfVillages, id, saveSettings);
			}
			if (listOfModules.Contains("Recruiting"))
			{
				SettingsManager.CopyDataGridViewContent(this.dataGridView_TroopsRecruiting, listOfVillages, id);
				if (saveSettings)
				{
					this.GetService<TroopsrecruitingService>().Save();
				}
			}
			if (listOfModules.Contains("Castle"))
			{
				SettingsManager.CopyDataGridViewContent(this.dataGridView_RepairCastle, listOfVillages, id);
				if (saveSettings)
				{
					this.CastleRepairService.Save();
				}
			}
			if (listOfModules.Contains("Banquet"))
			{
				SettingsManager.CopyDataGridViewContent(this.dataGridView_Banquets, listOfVillages, id);
				if (saveSettings)
				{
					this.GetService<BanquetService>().Save();
				}
			}
			if (listOfModules.Contains("Popularity"))
			{
				this.GetService<PopularityRegulationService>().CopySettings(listOfVillages, id);
			}
		}

		// Token: 0x06000079 RID: 121 RVA: 0x0000808F File Offset: 0x0000628F
		private void numericUpDown_ScoutMaxRadius_ValueChanged(object sender, EventArgs e)
		{
			this.GetService<ScoutingService>().ScoutsMaxTime = (int)this.numericUpDown_ScoutMaxTime.Value;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000080AC File Offset: 0x000062AC
		private void checkBox_HireScouts_CheckedChanged(object sender, EventArgs e)
		{
			this.GetService<ScoutingService>().HireScouts = this.checkBox_HireScouts.Checked;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x000080C4 File Offset: 0x000062C4
		private void radioButton_ScoutsPriorityBy_CheckedChanged(object sender, EventArgs e)
		{
			this.GetService<ScoutingService>().IgnoreType = this.radioButton_ScoutsPriorityByDistance.Checked;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x000080DC File Offset: 0x000062DC
		private void checkBox_Scout_CheckedChanged(object sender, EventArgs e)
		{
			this.GetService<ScoutingService>().Enabled = this.checkBox_Scout.Checked;
		}

		// Token: 0x0600007D RID: 125 RVA: 0x000080F4 File Offset: 0x000062F4
		private void button_SaveScoutingInfo_Click(object sender, EventArgs e)
		{
			this.GetService<ScoutingService>().SaveSettings(Control.ModifierKeys == Keys.Control);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x0000810D File Offset: 0x0000630D
		private void checkBox_ScoutsWaitFreeSpace_CheckedChanged(object sender, EventArgs e)
		{
			this.GetService<ScoutingService>().WaitForFreeSpace = this.checkBox_ScoutsWaitFreeSpace.Checked;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00008125 File Offset: 0x00006325
		private void checkBox_StopScoutsOnCardExpiry_CheckedChanged(object sender, EventArgs e)
		{
			this.GetService<ScoutingService>().StopScoutOnCardsExpiry = this.checkBox_StopScoutsOnCardExpiry.Checked;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000813D File Offset: 0x0000633D
		private void CheckBox_showPopupOnScoutsExpiry_CheckedChanged(object sender, EventArgs e)
		{
			this.GetService<ScoutingService>().ShowPopupOnScoutsExpiry = this.checkBox_showPopupOnScoutsExpiry.Checked;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x0002AAAC File Offset: 0x00028CAC
		private void Button_LoadScoutingInfo_Click(object sender, EventArgs e)
		{
			ScoutingService service = this.GetService<ScoutingService>();
			service.LoadSettings(this.listBox_scoutFrom, this.numericUpDown_ScoutMaxTime, Control.ModifierKeys == Keys.Control);
			this.SelectScoutingVillage(service.SelectedScoutingVillageId, this.groupBox_ScoutingVillage.Text);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x0002AAF8 File Offset: 0x00028CF8
		private void checkBox_sendOneScout_CheckedChanged(object sender, EventArgs e)
		{
			ScoutingService service = this.GetService<ScoutingService>();
			service.SendOneScout = this.checkBox_sendOneScout.Checked;
			if (service.SendOneScout)
			{
				service.MinimumScouts = 1;
				this.numericUpDown_minScouts.Value = 1m;
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0002AB3C File Offset: 0x00028D3C
		private void numericUpDown_minScouts_ValueChanged(object sender, EventArgs e)
		{
			ScoutingService service = this.GetService<ScoutingService>();
			service.MinimumScouts = (int)this.numericUpDown_minScouts.Value;
			if (this.numericUpDown_minScouts.Value > 1m)
			{
				service.SendOneScout = false;
				this.checkBox_sendOneScout.Checked = false;
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x0002AB90 File Offset: 0x00028D90
		private void ListBox_scoutFrom_MouseDown(object sender, MouseEventArgs e)
		{
			int num = this.listBox_scoutFrom.IndexFromPoint(e.Location);
			if (num == -1)
			{
				return;
			}
			string text = this.listBox_scoutFrom.Items[num].ToString();
			MouseButtons button = e.Button;
			if (button != MouseButtons.Left)
			{
				if (button == MouseButtons.Right)
				{
					this.comboBox_ScoutingVillages.SelectedItem = text;
					return;
				}
			}
			else
			{
				ScoutingService service = this.GetService<ScoutingService>();
				if (service.SelectedScoutingVillageId == ControlForm.GetId(text))
				{
					this.checkBox_ShouldVillageScout.Checked = this.listBox_scoutFrom.GetSelected(num);
				}
				this.SelectedVillagesChanged(service, this.listBox_scoutFrom);
			}
		}

		// Token: 0x06000085 RID: 133 RVA: 0x0002AC28 File Offset: 0x00028E28
		private void SelectScoutingVillage(int villageId, string villageName)
		{
			ScoutingService service = this.GetService<ScoutingService>();
			if (!service.ResForScouting.ContainsKey(villageId))
			{
				this.Log("No settings found for this village", ControlForm.Tab.Trade, false);
				return;
			}
			service.SelectedScoutingVillageId = villageId;
			this.listBox_ScoutingTypes.Items.Clear();
			foreach (int num in service.ResForScouting[villageId])
			{
				this.listBox_ScoutingTypes.Items.Add((num == 100) ? SpecialVillageTypes.getName(num, Program.mySettings.LanguageIdent) : VillageBuildingsData.getResourceNames(num - 100));
			}
			this.listBox_ScoutingTypes_Ignore.Items.Clear();
			foreach (int num2 in service.ResForScoutingIgnore[villageId])
			{
				this.listBox_ScoutingTypes_Ignore.Items.Add((num2 == 100) ? SpecialVillageTypes.getName(num2, Program.mySettings.LanguageIdent) : VillageBuildingsData.getResourceNames(num2 - 100));
			}
			this.groupBox_ScoutingVillage.Text = villageName;
			this.checkBox_ShouldVillageScout.Checked = service.SelectedVillages.Contains(villageId);
			this.comboBox_ScoutingVillages.SelectedItem = villageName;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00008155 File Offset: 0x00006355
		private void button_ScoutingHelp_Click(object sender, EventArgs e)
		{
			Process.Start(ControlForm.GetLinkToVideo("Scouts"));
		}

		// Token: 0x06000087 RID: 135 RVA: 0x0002AD9C File Offset: 0x00028F9C
		internal void button_ScoutingPreviousVillage_Click(object sender, EventArgs e)
		{
			int num = this.comboBox_ScoutingVillages.SelectedIndex;
			if (num > 0)
			{
				num--;
			}
			else
			{
				num = this.comboBox_ScoutingVillages.Items.Count - 1;
			}
			this.comboBox_ScoutingVillages.SelectedIndex = num;
		}

		// Token: 0x06000088 RID: 136 RVA: 0x0002ADE0 File Offset: 0x00028FE0
		internal void button_ScoutingNextVillage_Click(object sender, EventArgs e)
		{
			int num = this.comboBox_ScoutingVillages.SelectedIndex;
			if (num < this.comboBox_ScoutingVillages.Items.Count - 1)
			{
				num++;
			}
			else
			{
				num = 0;
			}
			this.comboBox_ScoutingVillages.SelectedIndex = num;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x0002AE24 File Offset: 0x00029024
		private void comboBox_ScoutingVillages_SelectedIndexChanged(object sender, EventArgs e)
		{
			string text = this.comboBox_ScoutingVillages.SelectedItem.ToString();
			int id = ControlForm.GetId(text);
			this.SelectScoutingVillage(id, text);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x0002AE54 File Offset: 0x00029054
		private void checkBox_ScoutingAllVillages_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.checkBox_ScoutingAllVillages.Checked;
			for (int i = 0; i < this.listBox_scoutFrom.Items.Count; i++)
			{
				this.listBox_scoutFrom.SetSelected(i, @checked);
			}
			this.SelectedVillagesChanged(this.GetService<ScoutingService>(), this.listBox_scoutFrom);
			this.checkBox_ShouldVillageScout.Checked = @checked;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x0002AEB4 File Offset: 0x000290B4
		private void checkBox_ShouldVillageScout_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.checkBox_ShouldVillageScout.Checked;
			ScoutingService service = this.GetService<ScoutingService>();
			if (@checked)
			{
				service.SelectedVillages.Add(service.SelectedScoutingVillageId);
			}
			else
			{
				service.SelectedVillages.Remove(service.SelectedScoutingVillageId);
			}
			this.listBox_scoutFrom.SetSelected(this.listBox_scoutFrom.Items.IndexOf(this.groupBox_ScoutingVillage.Text), @checked);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00008167 File Offset: 0x00006367
		private void checkBox_Trade_CheckedChanged(object sender, EventArgs e)
		{
			this.GetService<TradeService>().Enabled = this.checkBox_Trade.Checked;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0000817F File Offset: 0x0000637F
		private void CheckBox_showPopupOnTradeExpiry_CheckedChanged(object sender, EventArgs e)
		{
			this.GetService<TradeService>().ShowPopupOnTradeExpiry = this.checkBox_showPopupOnTradeExpiry.Checked;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00008197 File Offset: 0x00006397
		private void button_TradeSave_Click(object sender, EventArgs e)
		{
			this.GetService<TradeService>().SaveSettings(Control.ModifierKeys == Keys.Control);
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0002AF24 File Offset: 0x00029124
		private void button_TradeLoad_Click(object sender, EventArgs e)
		{
			this.GetService<TradeService>().LoadSettings(this.listBox_ActiveVillages, Control.ModifierKeys == Keys.Control);
			if (this.listBox_ActiveVillages.Items.Count <= 0)
			{
				return;
			}
			string text = this.listBox_ActiveVillages.Items[0].ToString();
			this.SelectTradingVillage(ControlForm.GetId(text), text);
		}

		// Token: 0x06000090 RID: 144 RVA: 0x0002AF88 File Offset: 0x00029188
		private void SelectTradingVillage(int villageId, string villageName)
		{
			TradeService service = this.GetService<TradeService>();
			Dictionary<int, VillageTradeInfo> villagesTradeInfo = service.VillagesTradeInfo;
			if (!villagesTradeInfo.ContainsKey(villageId))
			{
				this.Log("No settings found for this village", ControlForm.Tab.Trade, false);
				return;
			}
			service.SelectedVillageId = villageId;
			VillageMap village = GameEngine.Instance.getVillage(villageId);
			VillageTradeInfo villageTradeInfo = villagesTradeInfo[villageId];
			for (int i = 0; i < 24; i++)
			{
				DataGridViewRow dataGridViewRow = this.dataGridView_Trade.Rows[i];
				TradeType tradeType = villageTradeInfo.TradeTypes[i];
				dataGridViewRow.Cells[2].Value = tradeType.Sell;
				dataGridViewRow.Cells[3].Value = tradeType.MinSellPrice;
				dataGridViewRow.Cells[4].Value = tradeType.SellLimit;
				dataGridViewRow.Cells[5].Value = tradeType.Buy;
				dataGridViewRow.Cells[6].Value = tradeType.MaxBuyPrice;
				dataGridViewRow.Cells[7].Value = tradeType.BuyLimit;
				if (village != null)
				{
					dataGridViewRow.Cells[8].Value = Math.Round(village.getResourceLevel((int)tradeType.ResourceId), 2);
					dataGridViewRow.Cells[9].Value = Math.Round(village.getResourceProductionPerDay((int)tradeType.ResourceId), 2);
				}
			}
			this.listBox_ParishList.Items.Clear();
			foreach (int num in villageTradeInfo.QuickTargets)
			{
				this.listBox_ParishList.Items.Add(num);
			}
			this.groupBox_TradingVillage.Text = villageName;
			this.checkBox_ShouldVillageTrade.Checked = villageTradeInfo.IsTrading;
			this.comboBox_TradeVillages.SelectedItem = villageName;
			this.label_TotalMarkets.Text = villageTradeInfo.QuickTargets.Count.ToString();
		}

		// Token: 0x06000091 RID: 145 RVA: 0x0002B1C8 File Offset: 0x000293C8
		private void listBox_ActiveVillages_MouseDown(object sender, MouseEventArgs e)
		{
			int num = this.listBox_ActiveVillages.IndexFromPoint(e.Location);
			if (num == -1)
			{
				return;
			}
			string text = this.listBox_ActiveVillages.Items[num].ToString();
			int id = ControlForm.GetId(text);
			MouseButtons button = e.Button;
			if (button != MouseButtons.Left)
			{
				if (button == MouseButtons.Right)
				{
					this._selectedVillageId = id;
					this.SelectTradingVillage(this._selectedVillageId, text);
					return;
				}
			}
			else
			{
				bool selected = this.listBox_ActiveVillages.GetSelected(num);
				this.GetService<TradeService>().VillagesTradeInfo[id].IsTrading = selected;
				if (id == this._selectedVillageId)
				{
					this.checkBox_ShouldVillageTrade.Checked = selected;
				}
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0002B274 File Offset: 0x00029474
		private bool IsTradingVillageSelected()
		{
			if (this._selectedVillageId == -1)
			{
				this.Log(LNG.Print("Village is not selected"), ControlForm.Tab.Trade, false);
				return false;
			}
			if (!this.GetService<TradeService>().VillagesTradeInfo.ContainsKey(this._selectedVillageId))
			{
				this.Log("No settings found for this village", ControlForm.Tab.Trade, false);
				return false;
			}
			return true;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0002B2C8 File Offset: 0x000294C8
		private void listBox_ParishList_DoubleClick(object sender, EventArgs e)
		{
			if (!this.IsTradingVillageSelected())
			{
				return;
			}
			if (this.listBox_ParishList.SelectedIndex == -1)
			{
				return;
			}
			List<int> quickTargets = this.GetService<TradeService>().VillagesTradeInfo[this._selectedVillageId].QuickTargets;
			quickTargets.Remove(Convert.ToInt32(this.listBox_ParishList.SelectedItem));
			this.listBox_ParishList.Items.RemoveAt(this.listBox_ParishList.SelectedIndex);
			this.label_TotalMarkets.Text = quickTargets.Count.ToString();
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0002B354 File Offset: 0x00029554
		private void button_Add_Click(object sender, EventArgs e)
		{
			if (!this.IsTradingVillageSelected())
			{
				return;
			}
			if (string.IsNullOrEmpty(this.textBox_TradeTargetID.Text))
			{
				MyMessageBox.Show("Please specify Capital ID.");
				return;
			}
			int num;
			if (!int.TryParse(this.textBox_TradeTargetID.Text, out num))
			{
				MyMessageBox.Show(LNG.Print("Only numbers 0-9!"));
				return;
			}
			if (!GameEngine.Instance.World.allowExchangeTrade(num, this._selectedVillageId))
			{
				MyMessageBox.Show(SK.Text("VillageMap_Stock_Exchange_Too_Far", "The Stock Exchange is too far away for you to trade with."), SK.Text("VillageMap_Trade_Error", "Trade Error"));
				return;
			}
			this.listBox_ParishList.Items.Add(num);
			VillageTradeInfo villageTradeInfo = this.GetService<TradeService>().VillagesTradeInfo[this._selectedVillageId];
			villageTradeInfo.QuickTargets.Add(num);
			this.label_TotalMarkets.Text = villageTradeInfo.QuickTargets.Count.ToString();
		}

		// Token: 0x06000095 RID: 149 RVA: 0x0002B444 File Offset: 0x00029644
		private void button_AddMarkets_Click(object sender, EventArgs e)
		{
			if ((Control.ModifierKeys == Keys.Shift || Control.ModifierKeys == Keys.Control) && this._selectedVillageId != -1)
			{
				this.GetService<TradeService>().AddMarkets((double)this.numericUpDown_MarketsRadius.Value, this._selectedVillageId);
			}
			else
			{
				this.GetService<TradeService>().AddMarkets((double)this.numericUpDown_MarketsRadius.Value, -1);
			}
			if (this._selectedVillageId == -1)
			{
				return;
			}
			this.label_TotalMarkets.Text = this.GetService<TradeService>().VillagesTradeInfo[this._selectedVillageId].QuickTargets.Count.ToString();
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0002B4F0 File Offset: 0x000296F0
		private void checkBox_ShouldVillageTrade_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.checkBox_ShouldVillageTrade.Checked;
			this.GetService<TradeService>().VillagesTradeInfo[this._selectedVillageId].IsTrading = @checked;
			this.listBox_ActiveVillages.SetSelected(this.listBox_ActiveVillages.Items.IndexOf(this.groupBox_TradingVillage.Text), @checked);
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0002B54C File Offset: 0x0002974C
		private void checkBox_TradeAllVillages_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.checkBox_TradeAllVillages.Checked;
			for (int i = 0; i < this.listBox_ActiveVillages.Items.Count; i++)
			{
				this.listBox_ActiveVillages.SetSelected(i, @checked);
			}
			Dictionary<int, VillageTradeInfo> villagesTradeInfo = this.GetService<TradeService>().VillagesTradeInfo;
			foreach (int key in villagesTradeInfo.Keys.ToArray<int>())
			{
				villagesTradeInfo[key].IsTrading = @checked;
			}
			this.checkBox_ShouldVillageTrade.Checked = @checked;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0002B5D8 File Offset: 0x000297D8
		private void comboBox_TradeVillages_SelectedIndexChanged(object sender, EventArgs e)
		{
			string text = this.comboBox_TradeVillages.SelectedItem.ToString();
			this._selectedVillageId = ControlForm.GetId(text);
			this.SelectTradingVillage(this._selectedVillageId, text);
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0002B610 File Offset: 0x00029810
		internal void button_TradePreviousVillage_Click(object sender, EventArgs e)
		{
			int num = this.comboBox_TradeVillages.SelectedIndex;
			if (num > 0)
			{
				num--;
			}
			else
			{
				num = this.comboBox_TradeVillages.Items.Count - 1;
			}
			this.comboBox_TradeVillages.SelectedIndex = num;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0002B654 File Offset: 0x00029854
		internal void button_TradeNextVillage_Click(object sender, EventArgs e)
		{
			int num = this.comboBox_TradeVillages.SelectedIndex;
			if (num < this.comboBox_TradeVillages.Items.Count - 1)
			{
				num++;
			}
			else
			{
				num = 0;
			}
			this.comboBox_TradeVillages.SelectedIndex = num;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x000081B0 File Offset: 0x000063B0
		private void button_TradeHelp_Click(object sender, EventArgs e)
		{
			Process.Start(ControlForm.GetLinkToVideo("Trade"));
		}

		// Token: 0x0600009C RID: 156 RVA: 0x0002B698 File Offset: 0x00029898
		private void dataGridView_TradeRoutes_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Right)
			{
				return;
			}
			DataGridView.HitTestInfo hitTestInfo = this.dataGridView_TradeRoutes.HitTest(e.X, e.Y);
			if (hitTestInfo.RowIndex == -1)
			{
				return;
			}
			this.dataGridView_TradeRoutes.ClearSelection();
			this.dataGridView_TradeRoutes.Rows[hitTestInfo.RowIndex].Selected = true;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x000081C2 File Offset: 0x000063C2
		private void button_TradeRoutesNew_Click(object sender, EventArgs e)
		{
			this._routeEditor = new RouteEditor(this.listBox_ActiveVillages.Items.Cast<string>(), new SaveTradeRouteDel2(this.GetService<TradeService>().SaveTradeRoute2), null, -1);
			this._routeEditor.Show();
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0002B6FC File Offset: 0x000298FC
		private void button_TradeRoutesEdit_Click(object sender, EventArgs e)
		{
			if (this.dataGridView_TradeRoutes.SelectedRows.Count < 1)
			{
				MessageBox.Show("Please select a row to Edit");
				return;
			}
			DataGridViewRow dataGridViewRow = this.dataGridView_TradeRoutes.SelectedRows[0];
			this._routeEditor = new RouteEditor(this.listBox_ActiveVillages.Items.Cast<string>(), new SaveTradeRouteDel2(this.GetService<TradeService>().SaveTradeRoute2), dataGridViewRow, dataGridViewRow.Index);
			this._routeEditor.Show();
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0002B778 File Offset: 0x00029978
		private void button_TradeRoutesDelete_Click(object sender, EventArgs e)
		{
			if (this.dataGridView_TradeRoutes.SelectedRows.Count < 1)
			{
				MessageBox.Show("Please select a row to Delete");
				return;
			}
			if (MyMessageBox.Show(string.Format("Delete \"{0}\" ?", this.dataGridView_TradeRoutes.SelectedRows[0].Cells[0].Value), "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				int index = this.dataGridView_TradeRoutes.SelectedRows[0].Index;
				this.GetService<TradeService>().DeleteRoute(index);
			}
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0002B800 File Offset: 0x00029A00
		private void button_TradeRoutesCopy_Click(object sender, EventArgs e)
		{
			if (this.dataGridView_TradeRoutes.SelectedRows.Count < 1)
			{
				MessageBox.Show("Please select a row to Copy");
				return;
			}
			DataGridViewRow route = this.dataGridView_TradeRoutes.SelectedRows[0];
			this._routeEditor = new RouteEditor(this.listBox_ActiveVillages.Items.Cast<string>(), new SaveTradeRouteDel2(this.GetService<TradeService>().SaveTradeRoute2), route, -1);
			this._routeEditor.Show();
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x000081C2 File Offset: 0x000063C2
		private void newRouteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this._routeEditor = new RouteEditor(this.listBox_ActiveVillages.Items.Cast<string>(), new SaveTradeRouteDel2(this.GetService<TradeService>().SaveTradeRoute2), null, -1);
			this._routeEditor.Show();
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0002B6FC File Offset: 0x000298FC
		private void editTaskToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.dataGridView_TradeRoutes.SelectedRows.Count < 1)
			{
				MessageBox.Show("Please select a row to Edit");
				return;
			}
			DataGridViewRow dataGridViewRow = this.dataGridView_TradeRoutes.SelectedRows[0];
			this._routeEditor = new RouteEditor(this.listBox_ActiveVillages.Items.Cast<string>(), new SaveTradeRouteDel2(this.GetService<TradeService>().SaveTradeRoute2), dataGridViewRow, dataGridViewRow.Index);
			this._routeEditor.Show();
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0002B800 File Offset: 0x00029A00
		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.dataGridView_TradeRoutes.SelectedRows.Count < 1)
			{
				MessageBox.Show("Please select a row to Copy");
				return;
			}
			DataGridViewRow route = this.dataGridView_TradeRoutes.SelectedRows[0];
			this._routeEditor = new RouteEditor(this.listBox_ActiveVillages.Items.Cast<string>(), new SaveTradeRouteDel2(this.GetService<TradeService>().SaveTradeRoute2), route, -1);
			this._routeEditor.Show();
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0002B778 File Offset: 0x00029978
		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.dataGridView_TradeRoutes.SelectedRows.Count < 1)
			{
				MessageBox.Show("Please select a row to Delete");
				return;
			}
			if (MyMessageBox.Show(string.Format("Delete \"{0}\" ?", this.dataGridView_TradeRoutes.SelectedRows[0].Cells[0].Value), "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				int index = this.dataGridView_TradeRoutes.SelectedRows[0].Index;
				this.GetService<TradeService>().DeleteRoute(index);
			}
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x000081FD File Offset: 0x000063FD
		private void numericUpDown_PacketsPerTrade_ValueChanged(object sender, EventArgs e)
		{
			this.GetService<TradeService>().MerchantsPerTrade = (int)this.numericUpDown_PacketsPerTrade.Value;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0002B878 File Offset: 0x00029A78
		private void checkBox_TradeIgnoreCurrentTransactions_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.checkBox_TradeIgnoreCurrentTransactions.Checked;
			if (@checked && MyMessageBox.Show("Possible resources waste!", "Warning! Ignore Current Transactions?") != DialogResult.OK)
			{
				return;
			}
			this.GetService<TradeService>().IgnoreCurrentTransactions = @checked;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000821A File Offset: 0x0000641A
		private void checkBox_AutoHireMerchants_CheckedChanged(object sender, EventArgs e)
		{
			this.GetService<TradeService>().IsAutoHireMerhantsEnabled = this.checkBox_AutoHireMerchants.Checked;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00008232 File Offset: 0x00006432
		private void numericUpDown_AutoHireMerchantsLimit_ValueChanged(object sender, EventArgs e)
		{
			this.GetService<TradeService>().AutoHireMerchantsLimit = (int)this.numericUpDown_AutoHireMerchantsLimit.Value;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000824F File Offset: 0x0000644F
		private void checkBox_stopTradeOnCardExpiry_CheckedChanged(object sender, EventArgs e)
		{
			this.GetService<TradeService>().StopTradeOnCardExpiry = this.checkBox_stopTradeOnCardExpiry.Checked;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00008267 File Offset: 0x00006467
		private void numericUpDown_MerchantsTradeLimit_ValueChanged(object sender, EventArgs e)
		{
			this.GetService<TradeService>().MerchantsTradeLimit = (int)this.numericUpDown_MerchantsTradeLimit.Value;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00008284 File Offset: 0x00006484
		private void numericUpDown_MerchantsExchangeLimit_ValueChanged(object sender, EventArgs e)
		{
			this.GetService<TradeService>().MerchantsExchangeLimit = (int)this.numericUpDown_MerchantsExchangeLimit.Value;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0002B8B4 File Offset: 0x00029AB4
		private void InitContextMenu(ContextMenuStrip menu)
		{
			for (int i = 0; i < menu.Items.Count; i++)
			{
				ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)menu.Items[i];
				toolStripMenuItem.CheckOnClick = true;
			}
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000082A1 File Offset: 0x000064A1
		private void selectAllStockpileGoodsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.SelectResources(true, ((ToolStripMenuItem)sender).Checked, 0, 4);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x000082B7 File Offset: 0x000064B7
		private void selectAllFoodToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.SelectResources(true, ((ToolStripMenuItem)sender).Checked, 5, 11);
		}

		// Token: 0x060000AF RID: 175 RVA: 0x000082CE File Offset: 0x000064CE
		private void selectAllBanquetsGoodsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.SelectResources(true, ((ToolStripMenuItem)sender).Checked, 11, 19);
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x000082E6 File Offset: 0x000064E6
		private void selectAllWeaponsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.SelectResources(true, ((ToolStripMenuItem)sender).Checked, 19, 24);
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x000082FE File Offset: 0x000064FE
		private void buyAllStockpileGoodsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.SelectResources(false, ((ToolStripMenuItem)sender).Checked, 0, 4);
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00008314 File Offset: 0x00006514
		private void buyAllFoodToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.SelectResources(false, ((ToolStripMenuItem)sender).Checked, 5, 11);
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000832B File Offset: 0x0000652B
		private void buyAllBanquetsGoodsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.SelectResources(false, ((ToolStripMenuItem)sender).Checked, 11, 19);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00008343 File Offset: 0x00006543
		private void buyAllWeaponsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.SelectResources(false, ((ToolStripMenuItem)sender).Checked, 19, 24);
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0002B8F0 File Offset: 0x00029AF0
		private void SelectResources(bool isSell, bool isSelected, int start, int end)
		{
			if (!this.IsTradingVillageSelected())
			{
				return;
			}
			TradeType[] tradeTypes = this.GetService<TradeService>().VillagesTradeInfo[this._selectedVillageId].TradeTypes;
			for (int i = start; i < end; i++)
			{
				if (isSell)
				{
					tradeTypes[i].Sell = isSelected;
				}
				else
				{
					tradeTypes[i].Buy = isSelected;
				}
			}
			this.SelectTradingVillage(this._selectedVillageId, GameEngine.Instance.World.getVillageName(this._selectedVillageId));
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x0000835B File Offset: 0x0000655B
		private void button_LoadResearches_Click(object sender, EventArgs e)
		{
			this.GetService<ResearchService>().Load();
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00008368 File Offset: 0x00006568
		private void button_SaveResearches_Click(object sender, EventArgs e)
		{
			this.GetService<ResearchService>().Save();
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00008375 File Offset: 0x00006575
		private void comboBox_RankUpMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.GetService<ResearchService>().RankUpMode = this.comboBox_RankUpMode.SelectedIndex;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0000838D File Offset: 0x0000658D
		private void listBox_ResearchList_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.listBox_Queue.Items.Add(this.listBox_ResearchList.SelectedItem);
		}

		// Token: 0x060000BA RID: 186 RVA: 0x000083AB File Offset: 0x000065AB
		private void listBox_Queue_DoubleClick(object sender, EventArgs e)
		{
			this.listBox_Queue.Items.Remove(this.listBox_Queue.SelectedItem);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x000083C8 File Offset: 0x000065C8
		private void checkBox_Research_CheckedChanged(object sender, EventArgs e)
		{
			this.GetService<ResearchService>().Enabled = this.checkBox_Research.Checked;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x000083E0 File Offset: 0x000065E0
		private void button_ResearchHelp_Click(object sender, EventArgs e)
		{
			Process.Start(ControlForm.GetLinkToVideo("Researches"));
		}

		// Token: 0x060000BD RID: 189 RVA: 0x000083F2 File Offset: 0x000065F2
		private void PlayBanquets_CheckedChanged(object sender, EventArgs e)
		{
			this.GetService<BanquetService>().Enabled = this.PlayBanquets.Checked;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000840A File Offset: 0x0000660A
		private void numeric_BanquetInterval_ValueChanged(object sender, EventArgs e)
		{
			this.GetService<BanquetService>().Interval = (int)this.numeric_BanquetInterval.Value;
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00008427 File Offset: 0x00006627
		private void button_BanquetSave_Click(object sender, EventArgs e)
		{
			this.GetService<BanquetService>().Save();
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00008434 File Offset: 0x00006634
		private void button_BanquetLoad_Click(object sender, EventArgs e)
		{
			this.GetService<BanquetService>().Load();
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00008441 File Offset: 0x00006641
		private void button_BanquetingHelp_Click(object sender, EventArgs e)
		{
			Process.Start(ControlForm.GetLinkToVideo("Banqueting"));
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00008453 File Offset: 0x00006653
		private void RegulatePopularity_CheckedChanged(object sender, EventArgs e)
		{
			this.GetService<PopularityRegulationService>().Enabled = this.RegulatePopularity.Checked;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0002B968 File Offset: 0x00029B68
		private void comboBox_PopularityRegulationMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			int selectedIndex = this.comboBox_PopularityRegulationMode.SelectedIndex;
			this.GetService<PopularityRegulationService>().PopularityRegulationMode = selectedIndex;
			string settingsFilePath = SettingsManager.GetSettingsFilePath("Mode.txt", true, new string[]
			{
				"Popularity Regulation"
			});
			File.WriteAllText(settingsFilePath, selectedIndex.ToString());
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000846B File Offset: 0x0000666B
		private void numericUpDown_PopularityRegulation_ValueChanged(object sender, EventArgs e)
		{
			this.GetService<PopularityRegulationService>().Interval = (int)this.numericUpDown_PopularityRegulation.Value;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00008488 File Offset: 0x00006688
		private void listBox_PopularityRegulation_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.SelectedVillagesChanged(this.GetService<PopularityRegulationService>(), this.listBox_PopularityRegulation);
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0002B9B4 File Offset: 0x00029BB4
		private void checkBox_PopularitySelectAll_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.checkBox_PopularitySelectAll.Checked;
			for (int i = 0; i < this.listBox_PopularityRegulation.Items.Count; i++)
			{
				this.listBox_PopularityRegulation.SetSelected(i, @checked);
			}
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000849C File Offset: 0x0000669C
		private void loadTroopsRecruiting_Click(object sender, EventArgs e)
		{
			this.GetService<TroopsrecruitingService>().Load();
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x000084AA File Offset: 0x000066AA
		private void saveTroopsRecruiting_Click(object sender, EventArgs e)
		{
			this.GetService<TroopsrecruitingService>().Save();
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x000084B7 File Offset: 0x000066B7
		private void numericUpDown2_ValueChanged(object sender, EventArgs e)
		{
			this.GetService<TroopsrecruitingService>().Interval = (int)((NumericUpDown)sender).Value;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000084D4 File Offset: 0x000066D4
		private void checkBox_recruitingtroops_CheckedChanged(object sender, EventArgs e)
		{
			this.GetService<TroopsrecruitingService>().Enabled = this.checkBox_recruitingtroops.Checked;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x000084EC File Offset: 0x000066EC
		private void numericUpDown_VassalTroopsMinimum_ValueChanged(object sender, EventArgs e)
		{
			this.GetService<TroopsrecruitingService>().VassalTroopsMinimum = (int)this.numericUpDown_VassalTroopsMinimum.Value;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00008509 File Offset: 0x00006709
		private void button_RecruitingHelp_Click(object sender, EventArgs e)
		{
			Process.Start(ControlForm.GetLinkToVideo("Recruiting"));
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000851B File Offset: 0x0000671B
		private void button_LoadLayouts_Click(object sender, EventArgs e)
		{
			this.GetService<VillagelayoutService>().LoadLayouts();
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00008528 File Offset: 0x00006728
		private void button_SaveLayouts_Click(object sender, EventArgs e)
		{
			this.GetService<VillagelayoutService>().SaveLayouts();
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00008535 File Offset: 0x00006735
		private void button_VillageLayouts_Help_Click(object sender, EventArgs e)
		{
			Process.Start(ControlForm.GetLinkToVideo("Village construction"));
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00008547 File Offset: 0x00006747
		private void checkBox_VillageLayouts_CheckedChanged(object sender, EventArgs e)
		{
			this.GetService<VillagelayoutService>().Enabled = this.checkBox_VillageLayouts.Checked;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000855F File Offset: 0x0000675F
		private void checkBox_AutoConstr_WaitRes_CheckedChanged(object sender, EventArgs e)
		{
			this.GetService<VillagelayoutService>().WaitForResources = this.checkBox_AutoConstr_WaitRes.Checked;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00008577 File Offset: 0x00006777
		private void numericUpDown_VillageLayoutInterval_ValueChanged(object sender, EventArgs e)
		{
			this.GetService<VillagelayoutService>().Interval = (int)this.numericUpDown_VillageLayoutInterval.Value;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00008594 File Offset: 0x00006794
		private void listBox_VillageLayouts_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.SelectedVillagesChanged(this.GetService<VillagelayoutService>(), this.listBox_VillageLayouts);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0002B9F8 File Offset: 0x00029BF8
		private void listBox_VillageLayouts_MouseDown(object sender, MouseEventArgs e)
		{
			int num = this.listBox_VillageLayouts.IndexFromPoint(e.Location);
			if (num == -1)
			{
				return;
			}
			MouseButtons button = e.Button;
			if (button != MouseButtons.Left)
			{
				if (button != MouseButtons.Right)
				{
					return;
				}
				this.SelectVillageLayout(num);
			}
			else
			{
				string item = this.listBox_VillageLayouts.Items[num].ToString();
				if (ControlForm.GetId(item) == this._villageLayoutId)
				{
					this.checkBox_ShouldLayoutBeBuilt.Checked = this.listBox_VillageLayouts.GetSelected(num);
					return;
				}
			}
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0002BA78 File Offset: 0x00029C78
		private void SelectVillageLayout(int villageIndex)
		{
			string text = this.listBox_VillageLayouts.Items[villageIndex].ToString();
			this.groupBox_SelectedLayout.Text = text;
			int villageLayoutId = this._villageLayoutId;
			this._villageLayoutId = ControlForm.GetId(text);
			bool isRefresh = villageLayoutId == this._villageLayoutId;
			VillagelayoutService service = this.GetService<VillagelayoutService>();
			this.LoadBuildingsDataIntoDataGridView(this._villageLayoutId, service, isRefresh);
			service.SelectedLayout = this._villageLayoutId;
			this.checkBox_ShouldLayoutBeBuilt.Checked = this.listBox_VillageLayouts.GetSelected(villageIndex);
			this.comboBox_villageLayouts.SelectedItem = text;
			service.FillTemplates(this.comboBox_VillageTemplate);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0002BB18 File Offset: 0x00029D18
		private void MoveBuilding(bool up = true)
		{
			DataGridView dataGridView = this.dataGridViewVillageLayoutsEdit;
			int index = dataGridView.SelectedRows[0].Index;
			if ((up && (index == 0 || index == dataGridView.NewRowIndex)) || (!up && index >= dataGridView.NewRowIndex - 1))
			{
				return;
			}
			int num = up ? (index - 1) : (index + 1);
			DataGridViewRow dataGridViewRow = dataGridView.Rows[index];
			dataGridView.Rows.RemoveAt(index);
			dataGridView.Rows.Insert(num, dataGridViewRow);
			dataGridView.Rows[num].Selected = true;
			List<int[]> list = this.GetService<VillagelayoutService>().BuildingsData[this._villageLayoutId];
			int[] item = list[index];
			list.RemoveAt(index);
			list.Insert(num, item);
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0002BBD4 File Offset: 0x00029DD4
		internal void LoadBuildingsDataIntoDataGridView(int villageId, VillagelayoutService service, bool isRefresh = false)
		{
			if (this.dataGridViewVillageLayoutsEdit.Columns.Count < 1)
			{
				return;
			}
			int num = this.dataGridViewVillageLayoutsEdit.FirstDisplayedScrollingRowIndex;
			this.dataGridViewVillageLayoutsEdit.Rows.Clear();
			for (int i = 0; i < service.BuildingsData[villageId].Count; i++)
			{
				List<int[]> list = service.BuildingsData[villageId];
				int[] array = list[i];
				int num2 = 1;
				for (int j = 0; j < i; j++)
				{
					int[] array2 = list[j];
					if (array2[0] == array[0])
					{
						num2++;
					}
				}
				this.dataGridViewVillageLayoutsEdit.Rows.Add(new object[]
				{
					array[0],
					VillageBuildingsData.getBuildingName(array[0]),
					num2,
					service.GetErrorMessage(array[3]),
					array[1],
					array[2]
				});
			}
			if (isRefresh)
			{
				int num3 = this.dataGridViewVillageLayoutsEdit.DisplayedRowCount(true);
				if (this.dataGridViewVillageLayoutsEdit.Rows.Count <= num3)
				{
					return;
				}
				int num4 = this.dataGridViewVillageLayoutsEdit.Rows.Count - num3;
				if (num > num4)
				{
					num = num4;
				}
				if (num < 0)
				{
					num = 0;
				}
				this.dataGridViewVillageLayoutsEdit.FirstDisplayedScrollingRowIndex = num;
			}
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0002BD24 File Offset: 0x00029F24
		private void checkBox_villagesLayoutsSelectAll_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.checkBox_villagesLayoutsSelectAll.Checked;
			for (int i = 0; i < this.listBox_VillageLayouts.Items.Count; i++)
			{
				this.listBox_VillageLayouts.SetSelected(i, @checked);
			}
			this.checkBox_ShouldLayoutBeBuilt.Checked = @checked;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0002BD74 File Offset: 0x00029F74
		private void dataGridViewVillageLayoutsEdit_KeyDown(object sender, KeyEventArgs e)
		{
			Keys keyCode = e.KeyCode;
			if (keyCode != Keys.Up)
			{
				if (keyCode != Keys.Down)
				{
					return;
				}
				if (e.Control)
				{
					this.MoveBuilding(false);
				}
			}
			else if (e.Control)
			{
				this.MoveBuilding(true);
				return;
			}
		}

		// Token: 0x060000DA RID: 218 RVA: 0x000085A8 File Offset: 0x000067A8
		private void dataGridViewVillageLayoutsEdit_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			if (e.RowCount != 1)
			{
				return;
			}
			this.GetService<VillagelayoutService>().DeleteBuilding(this._villageLayoutId, e.RowIndex);
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0002BDB4 File Offset: 0x00029FB4
		private void checkBox_ShouldLayoutBeBuilt_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.checkBox_ShouldLayoutBeBuilt.Checked;
			int num = this.listBox_VillageLayouts.Items.IndexOf(this.groupBox_SelectedLayout.Text);
			if (num == -1)
			{
				return;
			}
			this.listBox_VillageLayouts.SetSelected(num, @checked);
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000085CB File Offset: 0x000067CB
		private void comboBox_villageLayouts_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.SelectVillageLayout(this.comboBox_villageLayouts.SelectedIndex);
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0002BDFC File Offset: 0x00029FFC
		internal void button_previousLayout_Click(object sender, EventArgs e)
		{
			int num = this.comboBox_villageLayouts.SelectedIndex;
			if (num > 0)
			{
				num--;
			}
			else
			{
				num = this.comboBox_villageLayouts.Items.Count - 1;
			}
			this.comboBox_villageLayouts.SelectedIndex = num;
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0002BE40 File Offset: 0x0002A040
		internal void button_nextLayout_Click(object sender, EventArgs e)
		{
			int num = this.comboBox_villageLayouts.SelectedIndex;
			if (num < this.comboBox_villageLayouts.Items.Count - 1)
			{
				num++;
			}
			else
			{
				num = 0;
			}
			this.comboBox_villageLayouts.SelectedIndex = num;
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0002BE84 File Offset: 0x0002A084
		private void comboBox_VillageTemplate_SelectionChangeCommitted(object sender, EventArgs e)
		{
			VillagelayoutService service = this.GetService<VillagelayoutService>();
			if (this.comboBox_VillageTemplate.SelectedIndex == 0)
			{
				service.RemoveTemplate();
			}
			else
			{
				string item = this.comboBox_VillageTemplate.SelectedItem.ToString();
				service.SetTemplate(ControlForm.GetId(item));
			}
			this.LoadBuildingsDataIntoDataGridView(this._villageLayoutId, service, true);
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x000085DE File Offset: 0x000067DE
		private void button_ImportLayoutFromFile_Click(object sender, EventArgs e)
		{
			this.GetService<VillagelayoutService>().ImportTemplateFromFile();
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0002BED8 File Offset: 0x0002A0D8
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData <= (Keys.LButton | Keys.RButton | Keys.MButton | Keys.Space | Keys.Control))
			{
				if (keyData != (Keys.LButton | Keys.MButton | Keys.Space | Keys.Control))
				{
					if (keyData == (Keys.LButton | Keys.RButton | Keys.MButton | Keys.Space | Keys.Control))
					{
						if (this.tabControl1.SelectedTab.Name == "tabPage_Trade")
						{
							this.button_TradeNextVillage_Click(null, EventArgs.Empty);
							return true;
						}
						if (this.tabControl1.SelectedTab.Name == "tabPage_Scouting")
						{
							this.button_ScoutingNextVillage_Click(null, EventArgs.Empty);
							return true;
						}
						if (this.tabControl1.SelectedTab.Name == "tabPage_Villagelayout")
						{
							this.button_nextLayout_Click(null, EventArgs.Empty);
							return true;
						}
					}
				}
				else
				{
					if (this.tabControl1.SelectedTab.Name == "tabPage_Trade")
					{
						this.button_TradePreviousVillage_Click(null, EventArgs.Empty);
						return true;
					}
					if (this.tabControl1.SelectedTab.Name == "tabPage_Scouting")
					{
						this.button_ScoutingPreviousVillage_Click(null, EventArgs.Empty);
						return true;
					}
					if (this.tabControl1.SelectedTab.Name == "tabPage_Villagelayout")
					{
						this.button_previousLayout_Click(null, EventArgs.Empty);
						return true;
					}
				}
			}
			else if (keyData != (Keys)131155)
			{
				if (keyData == (Keys)196675)
				{
					this.button_CopySettings_Click(null, EventArgs.Empty);
				}
			}
			else
			{
				this.GetService<RadarService>().SoundPlayer.Stop();
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x000085EB File Offset: 0x000067EB
		private void checkBox_Spin_CheckedChanged(object sender, EventArgs e)
		{
			this.GetService<SpinService>().Enabled = this.checkBox_Spin.Checked;
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00008603 File Offset: 0x00006803
		private void numericUpDown_SpinInterval_ValueChanged(object sender, EventArgs e)
		{
			this.GetService<SpinService>().Interval = (int)this.numericUpDown_SpinInterval.Value;
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0002C048 File Offset: 0x0002A248
		private void button_UpdateCapitalsSpeed_Click(object sender, EventArgs e)
		{
			int targetId;
			if (!int.TryParse(this.textBox_getAttackersTarget.Text, out targetId))
			{
				targetId = -1;
			}
			this.TimedAttacksService.UpdateCapitalsAttackSpeed(targetId);
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0002C078 File Offset: 0x0002A278
		private void btnGetAttackers_Click(object sender, EventArgs e)
		{
			int targetId;
			if (int.TryParse(this.textBox_getAttackersTarget.Text, out targetId))
			{
				this.TimedAttacksService.CalculateAttackTimes(targetId);
				return;
			}
			this.Log(LNG.Print("Please specify the village ID"), ControlForm.Tab.TimedAttacks, false);
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00008620 File Offset: 0x00006820
		private void button_TimingHelp_Click(object sender, EventArgs e)
		{
			Process.Start(ControlForm.GetLinkToVideo("Timing"));
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00008632 File Offset: 0x00006832
		private void checkBox_Monitor_CheckedChanged(object sender, EventArgs e)
		{
			this.GetService<RadarService>().Enabled = this.checkBox_Monitor.Checked;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x0000864A File Offset: 0x0000684A
		private void button_StopSoundPlayer_Click(object sender, EventArgs e)
		{
			this.GetService<RadarService>().SoundPlayer.Stop();
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0000865C File Offset: 0x0000685C
		private void button_CloseAllMessages_Click(object sender, EventArgs e)
		{
			this.GetService<RadarService>().CloseAllMessages(sender, e);
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000866B File Offset: 0x0000686B
		private void button_RadarGridSave_Click(object sender, EventArgs e)
		{
			this.GetService<RadarService>().Save();
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00008678 File Offset: 0x00006878
		private void button_RadarGridLoad_Click(object sender, EventArgs e)
		{
			this.GetService<RadarService>().Load(false);
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00008686 File Offset: 0x00006886
		private void button_ExportForOffline_Click(object sender, EventArgs e)
		{
			RadarService.ExportSettings();
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000868D File Offset: 0x0000688D
		private void button_RadarHelp_Click(object sender, EventArgs e)
		{
			Process.Start(ControlForm.GetLinkToVideo("Radar 2.0"));
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0000869F File Offset: 0x0000689F
		private void button_SaveEmail_Click(object sender, EventArgs e)
		{
			SettingsManager.CreateNotificationsEmail(true, this.textBox_FromEmail.Text, this.textBox_FromEmailPass.Text, this.textBox_ToEmail.Text);
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000086C8 File Offset: 0x000068C8
		private void checkBox_RadarRehireMonks_CheckedChanged(object sender, EventArgs e)
		{
			this.GetService<RadarService>().AutoHireMonks = this.checkBox_RadarRehireMonks.Checked;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0002C0BC File Offset: 0x0002A2BC
		public void checkBox_RadarUseDefault_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.checkBox_RadarUseDefault.Checked;
			this.textBox_FromEmailPass.Enabled = !@checked;
			this.textBox_FromEmail.Enabled = !@checked;
			RadarService service = this.GetService<RadarService>();
			service.UseDefaultEmail = @checked;
			if (@checked)
			{
				this.textBox_FromEmail.Text = "SHKDemoPlayer@gmail.com";
				this.textBox_FromEmailPass.Text = "********";
				if (this.textBox_ToEmail.Text == "")
				{
					this.textBox_ToEmail.Text = Program.mySettings.Username;
					return;
				}
			}
			else
			{
				this.textBox_FromEmail.Text = service.FromEmail;
				this.textBox_FromEmailPass.Text = service.FromPw;
				this.textBox_ToEmail.Text = service.ToEmail;
			}
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x000086E0 File Offset: 0x000068E0
		private void textBox_FromEmail_TextChanged(object sender, EventArgs e)
		{
			if (this.checkBox_RadarUseDefault.Checked)
			{
				return;
			}
			this.GetService<RadarService>().FromEmail = this.textBox_FromEmail.Text;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00008706 File Offset: 0x00006906
		private void textBox_FromEmailPass_TextChanged(object sender, EventArgs e)
		{
			if (this.checkBox_RadarUseDefault.Checked)
			{
				return;
			}
			this.GetService<RadarService>().FromPw = this.textBox_FromEmailPass.Text;
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0000872C File Offset: 0x0000692C
		private void textBox_ToEmail_TextChanged(object sender, EventArgs e)
		{
			this.GetService<RadarService>().ToEmail = this.textBox_ToEmail.Text;
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00008744 File Offset: 0x00006944
		private void textBox_DiscordWebhook_TextChanged(object sender, EventArgs e)
		{
			this.GetService<RadarService>().DiscordWebhook = this.textBox_DiscordWebhook.Text;
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0000875C File Offset: 0x0000695C
		private void textBox_TelegramBotToken_TextChanged(object sender, EventArgs e)
		{
			this.GetService<RadarService>().TelegramBotToken = this.textBox_TelegramBotToken.Text;
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00008774 File Offset: 0x00006974
		private void textBox_TelegramChatID_TextChanged(object sender, EventArgs e)
		{
			this.GetService<RadarService>().TelegramChatID = this.textBox_TelegramChatID.Text;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x0000878C File Offset: 0x0000698C
		private void textBox_ProxyAddress_TextChanged(object sender, EventArgs e)
		{
			RadarService.ProxyAddress = this.textBox_ProxyAddress.Text;
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x0002C184 File Offset: 0x0002A384
		private void textBox_ProxyPort_TextChanged(object sender, EventArgs e)
		{
			int proxyPort;
			if (int.TryParse(this.textBox_ProxyPort.Text, out proxyPort))
			{
				RadarService.ProxyPort = proxyPort;
				return;
			}
			MyMessageBox.Show(LNG.Print("Only numbers 0-9!"));
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x0000879E File Offset: 0x0000699E
		private void textBox_ProxyUsername_TextChanged(object sender, EventArgs e)
		{
			RadarService.ProxyUsername = this.textBox_ProxyUsername.Text;
		}

		// Token: 0x060000FA RID: 250 RVA: 0x000087B0 File Offset: 0x000069B0
		private void textBox_ProxyPassword_TextChanged(object sender, EventArgs e)
		{
			RadarService.ProxyPassword = this.textBox_ProxyPassword.Text;
		}

		// Token: 0x060000FB RID: 251 RVA: 0x000087C2 File Offset: 0x000069C2
		private void checkBox_TelegramUseProxy_CheckedChanged(object sender, EventArgs e)
		{
			RadarService.UseProxy = this.checkBox_TelegramUseProxy.Checked;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x000087D4 File Offset: 0x000069D4
		private void checkBox_ProxyUseCredential_CheckedChanged(object sender, EventArgs e)
		{
			RadarService.UseCredentials = this.checkBox_ProxyUseCredential.Checked;
		}

		// Token: 0x060000FD RID: 253 RVA: 0x000087E6 File Offset: 0x000069E6
		private void button_RadarFindByID_Click(object sender, EventArgs e)
		{
			this.GetService<RadarService>().FindPlayerByVillageID((int)this.numericUpDown_RadarFindByID.Value);
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00008803 File Offset: 0x00006A03
		private void button_FindByUsername_Click(object sender, EventArgs e)
		{
			this.GetService<RadarService>().FindPlayerByUsername(this.textBox_RadarFindByUsername.Text);
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0000881B File Offset: 0x00006A1B
		private void button_RadarResetAlt_Click(object sender, EventArgs e)
		{
			this.GetService<RadarService>().Reset();
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00008828 File Offset: 0x00006A28
		private void numericUpDown_RadarAutoID_ValueChanged(object sender, EventArgs e)
		{
			this.GetService<RadarService>().AutoIDExtraDelay = (int)this.numericUpDown_RadarAutoID.Value;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00008845 File Offset: 0x00006A45
		private void button_TestMail_Click(object sender, EventArgs e)
		{
			new Thread(delegate()
			{
				string notification = LNG.Print("Email delivery succeeded!:)");
				this.GetService<RadarService>().SendEmail("Incoming Attack in " + Program.WorldName, notification);
			}).Start();
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0000885D File Offset: 0x00006A5D
		private void button_testID_Click(object sender, EventArgs e)
		{
			this.GetService<RadarService>().VillageSelfID(ControlForm.GetId(this.comboBox_testInderdict.Text), true, 1, false, true, false);
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000887F File Offset: 0x00006A7F
		private void button_RadarTestSound_Click(object sender, EventArgs e)
		{
			this.GetService<RadarService>().TestPlaySound();
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0002C1BC File Offset: 0x0002A3BC
		private void button_TestPopup_Click(object sender, EventArgs e)
		{
			string text = this.dataGridView_RepairCastle[0, 0].Value.ToString();
			int id = ControlForm.GetId(text);
			this.GetService<RadarService>().ShowRadarPopupMessage("Scouts", text, text, id, id, 20000.0, new CloseAllMessages(this.button_CloseAllMessages_Click));
		}

		// Token: 0x06000105 RID: 261 RVA: 0x0002C214 File Offset: 0x0002A414
		private void button_RadarTestTray_Click(object sender, EventArgs e)
		{
			this.GetService<RadarService>().ShowNotifyIcon("Incoming Attack in " + Program.WorldName, string.Format("Attack: {0} => {1}.", this.dataGridView_PredatorPreys["PreyName", 5].Value, this.listBox_ActiveVillages.Items[0].ToString()));
		}

		// Token: 0x06000106 RID: 262 RVA: 0x0000888C File Offset: 0x00006A8C
		private void button_RadarTestDiscord_Click(object sender, EventArgs e)
		{
			this.GetService<RadarService>().TestDiscordMessage();
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00008899 File Offset: 0x00006A99
		private void button_RadarTestTelegram_Click(object sender, EventArgs e)
		{
			this.GetService<RadarService>().TestTelegramMessage();
		}

		// Token: 0x06000108 RID: 264 RVA: 0x000088A6 File Offset: 0x00006AA6
		private void button_FixCastles_Click(object sender, EventArgs e)
		{
			CastleRepairService castleRepairService = this.CastleRepairService;
			if (castleRepairService == null)
			{
				return;
			}
			castleRepairService.FixCastles();
		}

		// Token: 0x06000109 RID: 265 RVA: 0x000088B8 File Offset: 0x00006AB8
		private void button_CastleHelp_Click(object sender, EventArgs e)
		{
			Process.Start(ControlForm.GetLinkToVideo("Castle"));
		}

		// Token: 0x0600010A RID: 266 RVA: 0x000088CA File Offset: 0x00006ACA
		private void button_CastleLoad_Click(object sender, EventArgs e)
		{
			CastleRepairService castleRepairService = this.CastleRepairService;
			if (castleRepairService == null)
			{
				return;
			}
			castleRepairService.Load();
		}

		// Token: 0x0600010B RID: 267 RVA: 0x000088DC File Offset: 0x00006ADC
		private void button_CastleSave_Click(object sender, EventArgs e)
		{
			CastleRepairService castleRepairService = this.CastleRepairService;
			if (castleRepairService == null)
			{
				return;
			}
			castleRepairService.Save();
		}

		// Token: 0x0600010C RID: 268 RVA: 0x000088EE File Offset: 0x00006AEE
		private void button_SaveCastlesLocally_Click(object sender, EventArgs e)
		{
			this.CastleRepairService.MemoriseTroopsAndCastles();
		}

		// Token: 0x0600010D RID: 269 RVA: 0x000088FB File Offset: 0x00006AFB
		private void CheckBox_AutoRepairCastle_CheckedChanged(object sender, EventArgs e)
		{
			this.CastleRepairService.RepairOnAIAttacks = this.checkBox_AutoRepairCastle.Checked;
		}

		// Token: 0x0600010E RID: 270 RVA: 0x0002C274 File Offset: 0x0002A474
		private void Button_RepairCurrent_Click(object sender, EventArgs e)
		{
			int villageId = InterfaceMgr.Instance.OwnSelectedVillage;
			string villageName = GameEngine.Instance.World.getVillageName(villageId);
			if (GameEngine.Instance.getVillage(villageId) == null)
			{
				return;
			}
			new Thread(delegate()
			{
				this.CastleRepairService.RepairCastle(villageId, villageName);
			}).Start();
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00008913 File Offset: 0x00006B13
		private void checkBox_StartHunting_CheckedChanged(object sender, EventArgs e)
		{
			this.GetService<PredatorService>().Enabled = this.checkBox_StartHunting.Checked;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x0000892B File Offset: 0x00006B2B
		private void button_PredatorClearPreys_Click(object sender, EventArgs e)
		{
			this.GetService<PredatorService>().ClearPreys();
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00008938 File Offset: 0x00006B38
		private void button_SavePrays_Click(object sender, EventArgs e)
		{
			this.GetService<PredatorService>().Save();
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00008945 File Offset: 0x00006B45
		private void button_LoadPrays_Click(object sender, EventArgs e)
		{
			this.GetService<PredatorService>().Load();
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00008952 File Offset: 0x00006B52
		private void button_predatorStopSound_Click(object sender, EventArgs e)
		{
			this.GetService<PredatorService>().StopSound();
		}

		// Token: 0x06000114 RID: 276 RVA: 0x0000895F File Offset: 0x00006B5F
		private void button_PredatorUpdatePresets_Click(object sender, EventArgs e)
		{
			this.GetService<PredatorService>().InitPredatorFormations();
		}

		// Token: 0x06000115 RID: 277 RVA: 0x0000896C File Offset: 0x00006B6C
		private void button_PredatorHelp_Click(object sender, EventArgs e)
		{
			Process.Start(ControlForm.GetLinkToVideo("Predator"));
		}

		// Token: 0x06000116 RID: 278 RVA: 0x0002C2E4 File Offset: 0x0002A4E4
		public void RemoveVassal(VillageData village)
		{
			this.GetService<PredatorService>().SelectedVassals.Remove(village.id);
			this.listBox_PredatorVassals.Items.Remove(village.villageName);
			this.GetService<PredatorService>().Vassals.Remove(village.id);
			int num = -1;
			for (int i = 0; i < this.dataGridView_FillVassals.Rows.Count; i++)
			{
				if (ControlForm.GetId(this.dataGridView_FillVassals[0, i].Value.ToString()) == village.id)
				{
					num = i;
				}
			}
			if (num == -1)
			{
				this.Log(string.Format("{0}: {1} {2}", LNG.Print("Can not find an remove vassal"), village.id, village.villageName), ControlForm.Tab.Main, false);
				return;
			}
			this.dataGridView_FillVassals.Rows.RemoveAt(num);
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0002C3BC File Offset: 0x0002A5BC
		public void AddVassal(VillageData village)
		{
			List<int> vassals = this.GetService<PredatorService>().Vassals;
			if (vassals.Contains(village.id))
			{
				this.Log("Duplicate vassal entry skipped: " + village.villageName, ControlForm.Tab.Predator, false);
				return;
			}
			vassals.Add(village.id);
			this.listBox_PredatorVassals.Items.Add(village.villageName);
			this.dataGridView_FillVassals.Rows.Add(new object[]
			{
				village.villageName + " (" + GameEngine.Instance.World.getUsernameByVillageId(village.id) + ")",
				false,
				0,
				0,
				0,
				0,
				0
			});
		}

		// Token: 0x06000118 RID: 280 RVA: 0x0002C49C File Offset: 0x0002A69C
		private void checkBox_PredatorVillages_CheckedChanged(object sender, EventArgs e)
		{
			this.GetService<PredatorService>().SelectedVillages.Clear();
			for (int i = 0; i < this.listBox_PredatorVillages.Items.Count; i++)
			{
				this.listBox_PredatorVillages.SetSelected(i, this.checkBox_PredatorVillages.Checked);
				if (this.checkBox_PredatorVillages.Checked)
				{
					this.GetService<PredatorService>().SelectedVillages.Add(ControlForm.GetId(this.listBox_PredatorVillages.Items[i].ToString()));
				}
			}
		}

		// Token: 0x06000119 RID: 281 RVA: 0x0002C524 File Offset: 0x0002A724
		private void checkBox_PredatorVassals_CheckedChanged(object sender, EventArgs e)
		{
			this.GetService<PredatorService>().SelectedVassals.Clear();
			for (int i = 0; i < this.listBox_PredatorVassals.Items.Count; i++)
			{
				this.listBox_PredatorVassals.SetSelected(i, this.checkBox_PredatorVassals.Checked);
				if (this.checkBox_PredatorVassals.Checked)
				{
					this.GetService<PredatorService>().SelectedVassals.Add(ControlForm.GetId(this.listBox_PredatorVassals.Items[i].ToString()));
				}
			}
		}

		// Token: 0x0600011A RID: 282 RVA: 0x0002C5AC File Offset: 0x0002A7AC
		private void checkBox_PredatorCapitals_CheckedChanged(object sender, EventArgs e)
		{
			this.GetService<PredatorService>().SelectedCapitals.Clear();
			for (int i = 0; i < this.listBox_PredatorCapitals.Items.Count; i++)
			{
				this.listBox_PredatorCapitals.SetSelected(i, this.checkBox_PredatorCapitals.Checked);
				if (this.checkBox_PredatorCapitals.Checked)
				{
					this.GetService<PredatorService>().SelectedCapitals.Add(ControlForm.GetId(this.listBox_PredatorCapitals.Items[i].ToString()));
				}
			}
		}

		// Token: 0x0600011B RID: 283 RVA: 0x0002C634 File Offset: 0x0002A834
		private void listBox_PredatorVillages_MouseClick(object sender, MouseEventArgs e)
		{
			int num = this.listBox_PredatorVillages.IndexFromPoint(e.Location);
			if (num == -1)
			{
				return;
			}
			bool selected = this.listBox_PredatorVillages.GetSelected(num);
			int id = ControlForm.GetId(this.listBox_PredatorVillages.Items[num].ToString());
			if (selected)
			{
				this.GetService<PredatorService>().SelectedVillages.Add(id);
				return;
			}
			this.GetService<PredatorService>().SelectedVillages.Remove(id);
		}

		// Token: 0x0600011C RID: 284 RVA: 0x0002C6A8 File Offset: 0x0002A8A8
		private void listBox_PredatorVassals_MouseClick(object sender, MouseEventArgs e)
		{
			int num = this.listBox_PredatorVassals.IndexFromPoint(e.Location);
			if (num == -1)
			{
				return;
			}
			bool selected = this.listBox_PredatorVassals.GetSelected(num);
			int id = ControlForm.GetId(this.listBox_PredatorVassals.Items[num].ToString());
			if (selected)
			{
				this.GetService<PredatorService>().SelectedVassals.Add(id);
				return;
			}
			this.GetService<PredatorService>().SelectedVassals.Remove(id);
		}

		// Token: 0x0600011D RID: 285 RVA: 0x0002C71C File Offset: 0x0002A91C
		private void listBox_PredatorCapitals_MouseClick(object sender, MouseEventArgs e)
		{
			int num = this.listBox_PredatorCapitals.IndexFromPoint(e.Location);
			if (num == -1)
			{
				return;
			}
			bool selected = this.listBox_PredatorCapitals.GetSelected(num);
			int id = ControlForm.GetId(this.listBox_PredatorCapitals.Items[num].ToString());
			if (selected)
			{
				this.GetService<PredatorService>().SelectedCapitals.Add(id);
				return;
			}
			this.GetService<PredatorService>().SelectedCapitals.Remove(id);
		}

		// Token: 0x0600011E RID: 286 RVA: 0x0000897E File Offset: 0x00006B7E
		private void checkBox_PredatorUseCastleTroops_CheckedChanged(object sender, EventArgs e)
		{
			this.GetService<PredatorService>().UseCastleTroops = this.checkBox_PredatorUseCastleTroops.Checked;
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00008996 File Offset: 0x00006B96
		private void checkBox_HuntWithinParish_CheckedChanged(object sender, EventArgs e)
		{
			this.GetService<PredatorService>().HuntWithinParish = this.checkBox_HuntWithinParish.Checked;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x000089AE File Offset: 0x00006BAE
		private void checkBox_FreeMonitorEnable_CheckedChanged(object sender, EventArgs e)
		{
			this.GetService<FreeMonitorService>().Enabled = this.checkBox_FreeMonitorEnable.Checked;
		}

		// Token: 0x06000121 RID: 289 RVA: 0x0002C790 File Offset: 0x0002A990
		private void checkedListBox_FreeMonitorColumns_SelectedIndexChanged(object sender, EventArgs e)
		{
			for (int i = 1; i < this.dataGridView_FreeMonitor.Columns.Count; i++)
			{
				this.dataGridView_FreeMonitor.Columns[i].Visible = this.checkedListBox_FreeMonitorColumns.GetItemChecked(i - 1);
			}
		}

		// Token: 0x06000122 RID: 290 RVA: 0x0002C7DC File Offset: 0x0002A9DC
		private void button_Interdict_Click(object sender, EventArgs e)
		{
			this.GetService<RadarService>().InterdictSelectedVillages((int)this.numericUpDown_InterdictNumberOfMonks.Value, from string v in this.listBox_Interdict.SelectedItems
			select ControlForm.GetId(v), this.checkBox_Interdict_SkipIfAlreadyID.Checked, this.checkBox_Interdict_AllowHireMonks.Checked);
		}

		// Token: 0x06000123 RID: 291 RVA: 0x0002C850 File Offset: 0x0002AA50
		private void checkBox_InterdictSelectAll_CheckedChanged(object sender, EventArgs e)
		{
			for (int i = 0; i < this.listBox_Interdict.Items.Count; i++)
			{
				this.listBox_Interdict.SetSelected(i, this.checkBox_InterdictSelectAll.Checked);
			}
		}

		// Token: 0x06000124 RID: 292 RVA: 0x000089C6 File Offset: 0x00006BC6
		private void button_InterdictTabHelp_Click(object sender, EventArgs e)
		{
			Process.Start(ControlForm.GetLinkToVideo("Radar Interdict"));
		}

		// Token: 0x06000125 RID: 293 RVA: 0x000089D8 File Offset: 0x00006BD8
		private void Button1_Click_1(object sender, EventArgs e)
		{
			this.FindCharters();
		}

		// Token: 0x06000126 RID: 294 RVA: 0x0002C890 File Offset: 0x0002AA90
		private void FindCharters()
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			Dictionary<int, int> dictionary2 = new Dictionary<int, int>();
			foreach (int num in this.GetService<TradeService>().CapitalsList)
			{
				int num2 = 0;
				int num3 = 0;
				foreach (VillageData villageData in GameEngine.Instance.World.VillageList)
				{
					if (villageData.visible && !villageData.Capital && PredatorService.IsInSameParish(num, villageData.id))
					{
						if (villageData.special == 0 && GameEngine.Instance.World.getVillageUserID(villageData.id) < 0)
						{
							num2++;
						}
						else
						{
							num3++;
						}
					}
				}
				if (num2 > 5)
				{
					dictionary.Add(num, num2);
				}
				if (num3 > 10)
				{
					dictionary2.Add(num, num3);
				}
			}
			this.listBox1.Items.Clear();
			this.listBox1.Items.Add("Top by Charters");
			foreach (KeyValuePair<int, int> keyValuePair in (from e in dictionary
			orderby e.Value descending
			select e).Take(10))
			{
				this.listBox1.Items.Add(string.Format("{0} - {1}", keyValuePair.Key, keyValuePair.Value));
			}
			this.listBox1.Items.Add("Top by Villages");
			foreach (KeyValuePair<int, int> keyValuePair2 in (from e in dictionary2
			orderby e.Value descending
			select e).Take(10))
			{
				this.listBox1.Items.Add(string.Format("{0} - {1}", keyValuePair2.Key, keyValuePair2.Value));
			}
		}

		// Token: 0x06000127 RID: 295 RVA: 0x0002CAD8 File Offset: 0x0002ACD8
		private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.listBox1.SelectedIndex == -1)
			{
				return;
			}
			string text = this.listBox1.SelectedItem.ToString();
			if (text == "Top by Charters" || text == "Top by Villages")
			{
				return;
			}
			int villageID = Convert.ToInt32(text.Split(new char[]
			{
				'-'
			})[0].TrimEnd(new char[0]));
			InterfaceMgr.Instance.selectVillage(villageID);
			InterfaceMgr.Instance.switchToSelectedVillage();
		}

		// Token: 0x06000128 RID: 296 RVA: 0x000089E0 File Offset: 0x00006BE0
		private void ToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this._monkRouteEditor = new MonkRouteEditor(this.listBox_ActiveVillages.Items.Cast<string>(), new SaveMonkRouteDel(this.GetService<MonkService>().SaveMonkRoute), null, -1);
			this._monkRouteEditor.Show();
		}

		// Token: 0x06000129 RID: 297 RVA: 0x0002CB5C File Offset: 0x0002AD5C
		private void ToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			if (this.dataGridView_Monks.SelectedRows.Count < 1)
			{
				MessageBox.Show("Please select a row to Edit");
				return;
			}
			DataGridViewRow dataGridViewRow = this.dataGridView_Monks.SelectedRows[0];
			this._monkRouteEditor = new MonkRouteEditor(this.listBox_ActiveVillages.Items.Cast<string>(), new SaveMonkRouteDel(this.GetService<MonkService>().SaveMonkRoute), this.GetService<MonkService>().MonkRoutes[dataGridViewRow.Index], dataGridViewRow.Index);
			this._monkRouteEditor.Show();
		}

		// Token: 0x0600012A RID: 298 RVA: 0x0002CBF0 File Offset: 0x0002ADF0
		private void ToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			if (this.dataGridView_Monks.SelectedRows.Count < 1)
			{
				MessageBox.Show("Please select a row to Delete");
				return;
			}
			if (MyMessageBox.Show(string.Format("Delete \"{0}\" ?", this.dataGridView_Monks.SelectedRows[0].Cells[0].Value), "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				int index = this.dataGridView_Monks.SelectedRows[0].Index;
				this.dataGridView_Monks.Rows.RemoveAt(index);
				this.dataGridView_Monks.ClearSelection();
				this.GetService<MonkService>().MonkRoutes.RemoveAt(index);
			}
		}

		// Token: 0x0600012B RID: 299 RVA: 0x0002CC9C File Offset: 0x0002AE9C
		private void ToolStripMenuItem4_Click(object sender, EventArgs e)
		{
			if (this.dataGridView_Monks.SelectedRows.Count < 1)
			{
				MessageBox.Show("Please select a row to Copy");
				return;
			}
			DataGridViewRow dataGridViewRow = this.dataGridView_Monks.SelectedRows[0];
			this._monkRouteEditor = new MonkRouteEditor(this.listBox_ActiveVillages.Items.Cast<string>(), new SaveMonkRouteDel(this.GetService<MonkService>().SaveMonkRoute), this.GetService<MonkService>().MonkRoutes[dataGridViewRow.Index], -1);
			this._monkRouteEditor.Show();
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00008A1B File Offset: 0x00006C1B
		private void Button_SaveMonks_Click(object sender, EventArgs e)
		{
			this.GetService<MonkService>().Save();
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00008A28 File Offset: 0x00006C28
		private void Button_LoadMonks_Click(object sender, EventArgs e)
		{
			this.GetService<MonkService>().Load();
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00008A35 File Offset: 0x00006C35
		private void Button_HelpMonks_Click(object sender, EventArgs e)
		{
			Process.Start(ControlForm.GetLinkToVideo("Monks"));
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00008A47 File Offset: 0x00006C47
		private void CheckBox_EnableMonks_CheckedChanged(object sender, EventArgs e)
		{
			this.GetService<MonkService>().Enabled = this.checkBox_EnableMonks.Checked;
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00008A5F File Offset: 0x00006C5F
		private void numericUpDown_KeepMonks_ValueChanged(object sender, EventArgs e)
		{
			this.GetService<MonkService>().MonksToKeep = (int)this.numericUpDown_KeepMonks.Value;
		}

		// Token: 0x06000131 RID: 305 RVA: 0x0002CD28 File Offset: 0x0002AF28
		private void DataGridView_Monks_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Right)
			{
				return;
			}
			DataGridView.HitTestInfo hitTestInfo = this.dataGridView_Monks.HitTest(e.X, e.Y);
			if (hitTestInfo.RowIndex == -1)
			{
				return;
			}
			this.dataGridView_Monks.ClearSelection();
			this.dataGridView_Monks.Rows[hitTestInfo.RowIndex].Selected = true;
		}

		// Token: 0x06000134 RID: 308 RVA: 0x0003EAA8 File Offset: 0x0003CCA8
		private void CreateForm()
		{
			if (!this.moving)
			{
				return;
			}
			this.moving = false;
			TabHost tabHost = new TabHost(this.selectedTab, this.tabControl1);
			this.selectedTab = null;
			tabHost.Show();
			this.TabHosts.Add(tabHost);
			this.rect = default(Rectangle);
		}

		// Token: 0x06000135 RID: 309 RVA: 0x0003EAFC File Offset: 0x0003CCFC
		private void tabControl1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && this.tabControl1.SelectedIndex != -1 && this.IsMainLineClicked(e.Y))
			{
				this.rect = this.tabControl1.GetTabRect(this.tabControl1.SelectedIndex);
				this.selectedTab = this.tabControl1.SelectedTab;
				this.moving = true;
			}
		}

		// Token: 0x06000136 RID: 310 RVA: 0x0003EB68 File Offset: 0x0003CD68
		private bool IsMainLineClicked(int y)
		{
			return this.tabControl1.RowCount == 1 || y > (this.tabControl1.RowCount - 1) * this.tabControl1.ItemSize.Height;
		}

		// Token: 0x06000137 RID: 311 RVA: 0x0003EBAC File Offset: 0x0003CDAC
		private void tabControl1_MouseMove(object sender, MouseEventArgs e)
		{
			if (!this.moving)
			{
				return;
			}
			if (this.rect.Contains(e.Location))
			{
				return;
			}
			Rectangle targetRect = default(Rectangle);
			if (!this.tabControl1.ClientRectangle.Contains(e.Location))
			{
				this.CreateForm();
				return;
			}
			for (int i = 0; i < this.tabControl1.TabPages.Count; i++)
			{
				targetRect = this.tabControl1.GetTabRect(i);
				if (targetRect.Contains(e.Location) && this.HasCrossedMiddle(i, targetRect, e.X))
				{
					this.targetIndex = i;
					break;
				}
			}
			if (this.targetIndex == -1)
			{
				return;
			}
			this.tabControl1.TabPages.Remove(this.selectedTab);
			this.tabControl1.TabPages.Insert(this.targetIndex, this.selectedTab);
			this.rect = targetRect;
			this.tabControl1.SelectedIndex = this.targetIndex;
			this.targetIndex = -1;
		}

		// Token: 0x06000138 RID: 312 RVA: 0x0003ECAC File Offset: 0x0003CEAC
		private bool HasCrossedMiddle(int targetIndex, Rectangle targetRect, int x)
		{
			bool flag = x - targetRect.Left > targetRect.Width / 2;
			if (this.tabControl1.SelectedIndex >= targetIndex)
			{
				return !flag;
			}
			return flag;
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0003ECE4 File Offset: 0x0003CEE4
		private void RestoreTabsOrder(string setting)
		{
			string[] array = setting.Split(new char[]
			{
				','
			});
			for (int i = 0; i < array.Length; i++)
			{
				TabPage tabByName = this.GetTabByName(array[i]);
				if (tabByName != null)
				{
					this.tabControl1.TabPages.Remove(tabByName);
					this.tabControl1.TabPages.Insert(i, tabByName);
				}
			}
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0003ED44 File Offset: 0x0003CF44
		private string SaveTabsOrder()
		{
			string[] array = new string[this.tabControl1.TabPages.Count];
			for (int i = 0; i < this.tabControl1.TabPages.Count; i++)
			{
				array[i] = this.tabControl1.TabPages[i].Name;
			}
			return string.Join(",", array);
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00008A9B File Offset: 0x00006C9B
		private void tabControl1_MouseUp(object sender, MouseEventArgs e)
		{
			this.selectedTab = null;
			this.moving = false;
			this.rect = default(Rectangle);
		}

		// Token: 0x0600013C RID: 316 RVA: 0x0003EDA8 File Offset: 0x0003CFA8
		private TabPage GetTabByName(string i)
		{
			foreach (object obj in this.tabControl1.TabPages)
			{
				TabPage tabPage = (TabPage)obj;
				if (tabPage.Name == i)
				{
					return tabPage;
				}
			}
			return null;
		}

		// Token: 0x0600013D RID: 317 RVA: 0x0003EE14 File Offset: 0x0003D014
		private void CheckBox_RefreshCapitals_CheckedChanged(object sender, EventArgs e)
		{
			for (int i = 0; i < this.listBox_Refresh.Items.Count; i++)
			{
				if (GameEngine.Instance.World.isCapital(ControlForm.GetId(this.listBox_Refresh.Items[i].ToString())))
				{
					this.listBox_Refresh.SetSelected(i, this.checkBox_RefreshCapitals.Checked);
				}
			}
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00008AB7 File Offset: 0x00006CB7
		private void CheckBox_IsFullRefreshAllowed_CheckedChanged(object sender, EventArgs e)
		{
			this.GetService<DownloadVillagesService>().IsFullRefreshAllowed = this.checkBox_IsFullRefreshAllowed.Checked;
		}

		// Token: 0x0600013F RID: 319 RVA: 0x0003EE80 File Offset: 0x0003D080
		private void CheckBox_AllRefresh_CheckedChanged(object sender, EventArgs e)
		{
			for (int i = 0; i < this.listBox_Refresh.Items.Count; i++)
			{
				this.listBox_Refresh.SetSelected(i, this.checkBox_AllRefresh.Checked);
			}
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00008ACF File Offset: 0x00006CCF
		private void ListBox_Refresh_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.SelectedVillagesChanged(this.GetService<DownloadVillagesService>(), this.listBox_Refresh);
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00008AE3 File Offset: 0x00006CE3
		private void CheckBox_EnableRefresh_CheckedChanged(object sender, EventArgs e)
		{
			this.GetService<DownloadVillagesService>().Enabled = this.checkBox_EnableRefresh.Checked;
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00008AFB File Offset: 0x00006CFB
		private void Button_SaveRefreshList_Click(object sender, EventArgs e)
		{
			this.GetService<DownloadVillagesService>().Save(this.listBox_Refresh);
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00008B0E File Offset: 0x00006D0E
		private void Button_LoadRefreshList_Click(object sender, EventArgs e)
		{
			this.GetService<DownloadVillagesService>().Load(this.listBox_Refresh);
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00008B21 File Offset: 0x00006D21
		private void Button_RefreshHelp_Click(object sender, EventArgs e)
		{
			Process.Start(ControlForm.GetLinkToVideo("Refresh"));
		}

		// Token: 0x0400006C RID: 108
		internal const string testEnvironment = "http://mytestdomain.website";

		// Token: 0x0400006D RID: 109
		internal const string linkToSite = "https://shkbot.site";

		// Token: 0x0400006E RID: 110
		internal static string linkToDownload = "https://shkbot.site/download/";

		// Token: 0x0400006F RID: 111
		public const string VersionNumber = "9.8.5";

		// Token: 0x04000070 RID: 112
		internal bool IsExclusive;

		// Token: 0x04000071 RID: 113
		internal DateTime LastWorldMapUpdate = DateTime.MinValue;

		// Token: 0x04000072 RID: 114
		private string FormHeading;

		// Token: 0x04000073 RID: 115
		public FiltersService FiltersService;

		// Token: 0x04000074 RID: 116
		public TimedAttacksService TimedAttacksService;

		// Token: 0x04000075 RID: 117
		public CastleRepairService CastleRepairService;

		// Token: 0x04000076 RID: 118
		internal CardExpiryChecker CardExpiryChecker;

		// Token: 0x04000077 RID: 119
		internal List<ABaseService> Services = new List<ABaseService>();

		// Token: 0x04000078 RID: 120
		public static string SettingsFolder = Application.StartupPath + "\\BotSettings\\";

		// Token: 0x04000079 RID: 121
		private bool DGVSelectAll = true;

		// Token: 0x0400007A RID: 122
		private readonly string[] _actions;

		// Token: 0x0400007B RID: 123
		private bool _writeLogs = true;

		// Token: 0x0400007C RID: 124
		private int _maxLogsToKeep = 1000;

		// Token: 0x0400007D RID: 125
		private List<Thread> BotThreads = new List<Thread>();

		// Token: 0x0400007E RID: 126
		private Thread SharedThread;

		// Token: 0x0400007F RID: 127
		private CheckBox[] MainCheckBoxes;

		// Token: 0x04000080 RID: 128
		private bool[] PausedState;

		// Token: 0x04000081 RID: 129
		private bool isPaused;

		// Token: 0x04000082 RID: 130
		internal bool IsProgrammaticClosing;

		// Token: 0x04000083 RID: 131
		private CopySettings copySettings;

		// Token: 0x04000084 RID: 132
		private int _selectedVillageId = -1;

		// Token: 0x04000085 RID: 133
		private RouteEditor _routeEditor;

		// Token: 0x04000086 RID: 134
		private int _villageLayoutId = -1;

		// Token: 0x04000087 RID: 135
		private MonkRouteEditor _monkRouteEditor;

		// Token: 0x0400027E RID: 638
		private List<TabHost> TabHosts = new List<TabHost>();

		// Token: 0x0400027F RID: 639
		private TabPage selectedTab;

		// Token: 0x04000280 RID: 640
		private int targetIndex = -1;

		// Token: 0x04000281 RID: 641
		private Rectangle rect;

		// Token: 0x04000282 RID: 642
		private bool moving;

		// Token: 0x02000017 RID: 23
		public enum TimeMultiplier
		{
			// Token: 0x04000284 RID: 644
			Seconds = 1000,
			// Token: 0x04000285 RID: 645
			Minutes = 60000,
			// Token: 0x04000286 RID: 646
			Hours = 3600000
		}

		// Token: 0x02000018 RID: 24
		public enum Tab
		{
			// Token: 0x04000288 RID: 648
			Main,
			// Token: 0x04000289 RID: 649
			Refresh,
			// Token: 0x0400028A RID: 650
			Radar,
			// Token: 0x0400028B RID: 651
			Trade,
			// Token: 0x0400028C RID: 652
			Scout,
			// Token: 0x0400028D RID: 653
			Research,
			// Token: 0x0400028E RID: 654
			Castle,
			// Token: 0x0400028F RID: 655
			Banquetting,
			// Token: 0x04000290 RID: 656
			PopularityRegulation,
			// Token: 0x04000291 RID: 657
			TroopsRecruiting,
			// Token: 0x04000292 RID: 658
			VillageLayouts,
			// Token: 0x04000293 RID: 659
			Spins,
			// Token: 0x04000294 RID: 660
			X1Functions,
			// Token: 0x04000295 RID: 661
			TimedAttacks,
			// Token: 0x04000296 RID: 662
			Predator,
			// Token: 0x04000297 RID: 663
			Monks
		}
	}
}
