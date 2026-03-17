using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media;
using CommonTypes;
using DXGraphics;
using Kingdoms;
using Properties;

namespace Upgrade.Services
{
	// Token: 0x0200004B RID: 75
	internal class RadarService : ABaseService
	{
		// Token: 0x06000273 RID: 627 RVA: 0x0004A9C0 File Offset: 0x00048BC0
		internal void SetUser(int userID = -1, string username = "")
		{
			if (userID == -1 && username == "")
			{
				this.AltUserID = RemoteServices.Instance.UserID;
				this.AltUsername = RemoteServices.Instance.UserName;
				this.IsMonitoringAlt = false;
			}
			else
			{
				this.AltUserID = userID;
				this.AltUsername = username;
				this.IsMonitoringAlt = true;
			}
			this.UpdateLabel();
		}

		// Token: 0x06000274 RID: 628 RVA: 0x0004AA24 File Offset: 0x00048C24
		internal void FindPlayerByVillageID(int villageID)
		{
			VillageData villageData = GameEngine.Instance.World.getVillageData(villageID);
			if (villageData == null)
			{
				this.LLog(LNG.Print("Invalid village"), true);
				return;
			}
			int userID = villageData.userID;
			if (userID == -1)
			{
				this.LLog(LNG.Print("Invalid village"), true);
				return;
			}
			WorldMap.CachedUserInfo storedUserInfo = GameEngine.Instance.World.getStoredUserInfo(userID);
			if (storedUserInfo == null)
			{
				LeaderBoardShortData leaderBoardShortData = DX.Info.FirstOrDefault((LeaderBoardShortData i) => i.userID == userID);
				if (leaderBoardShortData != null)
				{
					this.ProcessLeaderBoardInfo(leaderBoardShortData);
					return;
				}
			}
			if (storedUserInfo == null)
			{
				this.LLog(LNG.Print("Requesting user info"), false);
				WorldMap.VillageRolloverInfo villageRolloverInfo = null;
				GameEngine.Instance.World.retrieveUserData(villageID, -1, ref villageRolloverInfo, ref storedUserInfo, true, false);
				Thread thread = new Thread(new ParameterizedThreadStart(this.BackGroundSearch));
				thread.Start(userID);
				return;
			}
			this.ProcessCachedUserInfo(storedUserInfo);
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0004AB1C File Offset: 0x00048D1C
		private void BackGroundSearch(object target)
		{
			this.LLog(LNG.Print("Wait server response"), false);
			if (base.RandomSleepOrExit(1189, 3196))
			{
				return;
			}
			WorldMap.CachedUserInfo storedUserInfo = GameEngine.Instance.World.getStoredUserInfo((int)target);
			this.ProcessCachedUserInfo(storedUserInfo);
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0004AB6C File Offset: 0x00048D6C
		internal void FindPlayerByUsername(string username)
		{
			WorldMap.CachedUserInfo storedUserInfo = GameEngine.Instance.World.getStoredUserInfo(username);
			if (storedUserInfo == null)
			{
				LeaderBoardShortData leaderBoardShortData = DX.Info.FirstOrDefault((LeaderBoardShortData i) => i.userName == username);
				if (leaderBoardShortData != null)
				{
					this.ProcessLeaderBoardInfo(leaderBoardShortData);
					return;
				}
			}
			this.ProcessCachedUserInfo(storedUserInfo);
		}

		// Token: 0x06000277 RID: 631 RVA: 0x0004ABC8 File Offset: 0x00048DC8
		private void ProcessCachedUserInfo(WorldMap.CachedUserInfo cachedInfo)
		{
			if (cachedInfo == null)
			{
				this.LLog(LNG.Print("Player not found. Click his village on map and retry"), false);
				return;
			}
			string userName = cachedInfo.userName;
			this.LLog(string.Format("{0}: {1} {2} {3} {4} {5}", new object[]
			{
				SK.Text("UserInfoPanel_", "Player Name"),
				userName,
				cachedInfo.numVillages,
				SK.Text("GENERIC_Villages", "Villages"),
				cachedInfo.points,
				SK.Text("UserInfoPanel_Points", "Points")
			}), false);
			this.SetUser(cachedInfo.userID, userName);
			this.SuggestLoadSettings(userName);
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0004AC74 File Offset: 0x00048E74
		private void ProcessLeaderBoardInfo(LeaderBoardShortData cachedInfo)
		{
			string userName = cachedInfo.userName;
			this.LLog(string.Format("{0}: {1} {2} {3}", new object[]
			{
				SK.Text("UserInfoPanel_", "Player Name"),
				userName,
				cachedInfo.numPoints,
				SK.Text("UserInfoPanel_Points", "Points")
			}), false);
			this.SetUser(cachedInfo.userID, userName);
			this.SuggestLoadSettings(userName);
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0004ACEC File Offset: 0x00048EEC
		private void SuggestLoadSettings(string username)
		{
			if (MessageBox.Show(SK.Text("GENERIC_Warning", "Warning") + "! " + LNG.Print("Auto-Interdict will not work, only notifications"), LNG.Print("Load settings for") + " " + username + "?") == DialogResult.OK)
			{
				this.Load(true);
			}
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0004AD48 File Offset: 0x00048F48
		private void LoadAltSettings()
		{
			string settingsFilePath = SettingsManager.GetSettingsFilePath("RadarAltSettings.txt", true, new string[]
			{
				this.Name
			});
			if (File.Exists(settingsFilePath))
			{
				try
				{
					string text = File.ReadAllText(settingsFilePath);
					string[] array = text.Split(new char[]
					{
						';'
					});
					this.SetUser(int.Parse(array[0]), array[1]);
				}
				catch (Exception ex)
				{
					DX.ShowErrorMessage(ex);
				}
			}
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0004ADC0 File Offset: 0x00048FC0
		internal void UpdateLabel()
		{
			string text = LNG.Print("Radar works for account") + ": " + this.AltUsername;
			if (this._radarAltLabel.InvokeRequired)
			{
				this._radarAltLabel.BeginInvoke(new MethodInvoker(delegate()
				{
					this._radarAltLabel.Text = text;
				}));
				return;
			}
			this._radarAltLabel.Text = text;
		}

		// Token: 0x0600027C RID: 636 RVA: 0x00009499 File Offset: 0x00007699
		internal void Reset()
		{
			this.SetUser(-1, "");
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0004AE34 File Offset: 0x00049034
		public RadarService(Log logMethod, DataGridView radarSettings, CheckBox radarUseDefault, Label radarEmailStatus, NotifyIcon notifyIcon, Label radarAltLabel, Label autoIDExtraDelay) : base(logMethod)
		{
			this.SoundPlayer = new MediaPlayer();
			this.SoundPlayer.MediaEnded += delegate(object sender, EventArgs e)
			{
				this.SoundPlayer.Close();
			};
			this._radarSettings = radarSettings;
			this._radarSettings.CellValueChanged += this.SettingsGrid_CellValueChanged;
			this._radarSettings.CellBeginEdit += this.SettingsGrid_CellBeginEdit;
			this._radarBGSettings = RadarService.GetEventTypes();
			foreach (RadarSetting radarSetting in this._radarBGSettings)
			{
				this._radarSettings.Rows.Add(new object[]
				{
					radarSetting.Name,
					false,
					false,
					"Select sound file",
					false,
					0,
					false
				});
			}
			this._radarUseDefault = radarUseDefault;
			this._radarEmailStatus = radarEmailStatus;
			this.OpenMessages = new List<RadarPopupMessage>();
			this._notifyIcon = notifyIcon;
			this._notifyIcon.Icon = new Icon("shk_icon.ico");
			this._notifyIcon.Text = LNG.Print("Radar notifications");
			this._radarAltLabel = radarAltLabel;
			this._autoIDExtraDelay = autoIDExtraDelay;
			this.UpdateLabel();
			this.PrintAutoIDWarning();
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0004AFA8 File Offset: 0x000491A8
		internal static RadarSetting[] GetEventTypes()
		{
			return new RadarSetting[]
			{
				new RadarSetting("Scouts"),
				new RadarSetting("Monks"),
				new RadarSetting("AI Attack"),
				new RadarSetting("AI Captain"),
				new RadarSetting("Attack"),
				new RadarSetting("Captain"),
				new RadarSetting("Scouts to Capital"),
				new RadarSetting("Monks to Capital"),
				new RadarSetting("AI Monks To Capital"),
				new RadarSetting("Attack to Capital")
			};
		}

		// Token: 0x0600027F RID: 639 RVA: 0x0004B040 File Offset: 0x00049240
		internal override void TranslateUI()
		{
			for (int i = 0; i < this._radarSettings.Rows.Count; i++)
			{
				this._radarSettings[0, i].Value = LNG.Print(this._radarBGSettings[i].Name);
				if (string.IsNullOrEmpty(this._radarBGSettings[i].Sound))
				{
					this._radarSettings[3, i].Value = LNG.Print("Select sound file");
				}
			}
			this.UpdateLabel();
			this.PrintAutoIDWarning();
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0004B0C8 File Offset: 0x000492C8
		private void PrintAutoIDWarning()
		{
			this._autoIDExtraDelay.Text = string.Concat(new string[]
			{
				LNG.Print("Set number of seconds before automatic Interdiction will be casted."),
				Environment.NewLine,
				LNG.Print("Remember that an enemy has 30 seconds to launch attacks before they are shown in your game."),
				Environment.NewLine,
				LNG.Print("Radar also makes 3 - 5 second basic delay."),
				Environment.NewLine,
				LNG.Print("SHK server needs some time to process your Interdict command. It can be 3 - 5 seconds too. "),
				Environment.NewLine,
				LNG.Print("So if You set, for example, 10 seconds into this field, your enemy will have total 46 - 50 seconds to launch attacks at your village before it's Interdicted. "),
				Environment.NewLine,
				LNG.Print("Use this feature only if you understand the risk of loosing a village.")
			});
			this._autoIDExtraDelay.MaximumSize = new Size(this._autoIDExtraDelay.Parent.Width - 2 * this._autoIDExtraDelay.Left, 0);
		}

		// Token: 0x06000281 RID: 641 RVA: 0x000094A7 File Offset: 0x000076A7
		private void LLog(string message, bool isError = false)
		{
			this.Log(message, ControlForm.Tab.Radar, isError);
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0004B194 File Offset: 0x00049394
		private void PlaySound(string soundFile)
		{
			if (!this.IsSoundFileValid(soundFile))
			{
				return;
			}
			try
			{
				this.SoundPlayer.Dispatcher.BeginInvoke(new MethodInvoker(delegate()
				{
					this.SoundPlayer.Open(new Uri(soundFile, UriKind.Absolute));
					this.SoundPlayer.Play();
				}), new object[0]);
			}
			catch (Exception ex)
			{
				this.LLog(LNG.Print("ERROR DURING SOUND NOTIFICATION") + ": " + ex.Message, true);
				ABaseService.ReportError(ex, ControlForm.Tab.Radar);
			}
		}

		// Token: 0x06000283 RID: 643 RVA: 0x0004B228 File Offset: 0x00049428
		public void TestPlaySound()
		{
			this.SoundPlayer.Dispatcher.BeginInvoke(new MethodInvoker(delegate()
			{
				this.SoundPlayer.Stop();
			}), new object[0]);
			if (this._lastPlayedIndex > this._radarBGSettings.Length - 1)
			{
				this._lastPlayedIndex = 0;
			}
			if (this.IsSoundFileValid(this._radarBGSettings[this._lastPlayedIndex].Sound))
			{
				this.PlaySound(this._radarBGSettings[this._lastPlayedIndex].Sound);
			}
			this._lastPlayedIndex++;
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0004B2B4 File Offset: 0x000494B4
		public int MakeMonks(int villageId, int numberOfMonks, bool waitForMonks = true, ControlForm.Tab logTab = ControlForm.Tab.Radar)
		{
			if (numberOfMonks <= 0)
			{
				return 0;
			}
			VillageMap village = GameEngine.Instance.getVillage(villageId);
			if (village == null)
			{
				this.Log(string.Format("Can't make monks! Village {0} wasn't loaded", villageId), logTab, true);
				return 0;
			}
			int num = ResearchData.ordinationResearchMonkLevels[(int)GameEngine.Instance.World.userResearchData.Research_Ordination];
			numberOfMonks = Math.Min(numberOfMonks, num);
			int num2 = 0;
			int num3 = GameEngine.Instance.World.countVillagePeople(villageId, 4, ref num2);
			this.Log(string.Format("{0} total monks in the village", num3), logTab, false);
			int val = num - num3;
			numberOfMonks = Math.Min(numberOfMonks, val);
			if (numberOfMonks <= 0)
			{
				this.Log("Can not have any more monks in this village", logTab, false);
				return 0;
			}
			village.CheckVillagersArrival(ControlForm.Tab.Radar);
			int spareWorkers = village.m_spareWorkers;
			if (numberOfMonks > spareWorkers)
			{
				this.Log(string.Format("Can't make {0}! Only {1} recruits in the village", numberOfMonks, spareWorkers), logTab, false);
				numberOfMonks = spareWorkers;
			}
			int num4 = GameEngine.Instance.LocalWorldData.Village_UnitCapacity - village.calcUnitUsages();
			int unitSize_Priests = GameEngine.Instance.LocalWorldData.UnitSize_Priests;
			int num5 = numberOfMonks * unitSize_Priests;
			if (num4 < num5)
			{
				this.Log(string.Format("Can't make {0} monks. {1} unit space in the village", numberOfMonks, num4), logTab, false);
				numberOfMonks = num4 / unitSize_Priests;
			}
			int num6 = 0;
			int num7 = (int)GameEngine.Instance.World.getCurrentGold();
			int num8 = Math.Min(num, numberOfMonks);
			int num9 = 0;
			for (int i = num3; i < num8; i++)
			{
				int monkCost = GameEngine.Instance.LocalWorldData.getMonkCost(i);
				if (num6 + monkCost > num7)
				{
					break;
				}
				num6 += monkCost;
				num9++;
			}
			this.Log(string.Format("Gold check: {0} monks were ordered, {1} gold available, can do {2} monks for {3} total price", new object[]
			{
				numberOfMonks,
				num7,
				num9,
				num6
			}), logTab, false);
			numberOfMonks = Math.Min(numberOfMonks, num9);
			if (numberOfMonks <= 0)
			{
				return 0;
			}
			this.Log(string.Format("Making {0} monks.", numberOfMonks), logTab, false);
			if (numberOfMonks == 1)
			{
				village.makePeople(4);
			}
			else
			{
				village.makePeople(1000 + numberOfMonks);
			}
			if (waitForMonks)
			{
				int num10 = 0;
				while (village.MakePeopleLocked && num10 < 100)
				{
					if (this.Exiting.WaitOne(100))
					{
						return 0;
					}
					num10++;
				}
			}
			return numberOfMonks;
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0004B52C File Offset: 0x0004972C
		public void sendPeopleCallback(SendPeople_ReturnType returnData)
		{
			try
			{
				if (!returnData.Success)
				{
					this.LLog(ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID) + ". Village " + GameEngine.Instance.World.getVillageName(returnData.targetVillageID), true);
					if (this.VillagesSentSelfID.ContainsKey(returnData.targetVillageID))
					{
						this.VillagesSentSelfID.Remove(returnData.targetVillageID);
					}
				}
				else
				{
					this.LLog(LNG.Print("Successful Interdict in village") + ": " + GameEngine.Instance.World.getVillageName(returnData.targetVillageID), false);
					GameEngine.Instance.World.importOrphanedPeople(returnData.people, returnData.currentTime, -2);
					GameEngine.Instance.World.setFaithPointsData(returnData.currentFaithPointsLevel, returnData.currentFaithPointsRate);
					if (this.AutoHireMonks)
					{
						byte research_Ordination = GameEngine.Instance.World.userResearchData.Research_Ordination;
						int numberOfMonks = (int)research_Ordination - returnData.people.Count;
						this.MakeMonks(returnData.targetVillageID, numberOfMonks, false, ControlForm.Tab.Radar);
					}
				}
			}
			catch (Exception ex)
			{
				this.LLog(LNG.Print("Error occured when tried to send monks with ID. Error") + ": " + ex.Message, true);
				ABaseService.ReportError(ex, ControlForm.Tab.Radar);
			}
		}

		// Token: 0x06000286 RID: 646 RVA: 0x0004B694 File Offset: 0x00049894
		private bool ValidateInterdictCommand(int villageId, out VillageMap village)
		{
			village = null;
			if (GameEngine.Instance.World.isCapital(villageId))
			{
				return false;
			}
			village = GameEngine.Instance.getVillage(villageId);
			if (village == null)
			{
				this.LLog(string.Format("{0} : {1}", LNG.Print("Village wasn't loaded"), villageId), true);
				return false;
			}
			if (GameEngine.Instance.World.userResearchData.Research_Ordination == 0)
			{
				this.LLog(SK.Text("TOOLTIPS_UNITS_MONKS_NOT_RESEARCHED", "To recruit Monks you must be Rank 8 and research 'Ordination'."), true);
				return false;
			}
			if (GameEngine.Instance.World.userResearchData.Research_Eucharist <= 0)
			{
				this.LLog(LNG.Print("Interdict is not researched"), true);
				return false;
			}
			if (GameEngine.Instance.World.isVillageExcommunicated(villageId))
			{
				this.LLog(SK.Text("TOOLTIPS_VO_EXCOMMUNICATION", "This village is Excommunicated."), true);
				return false;
			}
			return true;
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0004B770 File Offset: 0x00049970
		public void VillageSelfID(int villageId, bool allowHireMonks, int numberOfMonks = 1, bool waitForMonks = true, bool radarCalled = true, bool reduceMonksIfIDed = false)
		{
			VillageMap villageMap;
			if (!this.ValidateInterdictCommand(villageId, out villageMap))
			{
				return;
			}
			if (reduceMonksIfIDed)
			{
				DateTime interdictionTime = GameEngine.Instance.World.getVillageData(villageId).interdictionTime;
				DateTime currentServerTime = VillageMap.getCurrentServerTime();
				if (interdictionTime > currentServerTime)
				{
					int num = (int)(interdictionTime - currentServerTime).TotalSeconds;
					this.LLog(LNG.Print("Village is currently Interdicted for") + ": " + VillageMap.createBuildTimeString(num), false);
					int num2 = CardTypes.adjustInterdictionLevel(GameEngine.Instance.cardsManager.UserCardData, 4);
					this.Log(string.Format("{0}: {1} {2}", LNG.Print("1 Monk Interdicts for"), num2, SK.Text("ResearchEffect_X_Hours", "hours")), ControlForm.Tab.Main, false);
					int num3 = numberOfMonks * num2;
					int num4 = num3 * 3600;
					int num5 = num4 - num;
					if (num5 <= 0)
					{
						this.LLog(LNG.Print("Village has enough of interdiction time"), false);
						return;
					}
					this.LLog(LNG.Print("Need to Interdict for") + ": " + VillageMap.createBuildTimeString(num5), false);
					numberOfMonks = num5 / (num2 * 3600);
					if (numberOfMonks < 8)
					{
						numberOfMonks++;
					}
					this.LLog(string.Format("{0}: {1}", LNG.Print("Set Number Of Monks to"), numberOfMonks), false);
				}
			}
			int num6 = GameEngine.Instance.LocalWorldData.MonkCommandPointsCost_Interdicts;
			int rank = GameEngine.Instance.World.getRank();
			num6 = TradingCalcs.adjustInterdictionCostByTargetRank(num6, rank, GameEngine.Instance.World.SecondAgeWorld);
			num6 *= numberOfMonks;
			this.LLog(string.Format("{0}: {1}", SK.Text("SendMonksPanel_Faith_Points_Cost", "Faith Points Cost"), num6), false);
			if ((double)num6 > GameEngine.Instance.World.getCurrentFaithPoints())
			{
				this.LLog(LNG.Print("Not enough Faith Points"), true);
				return;
			}
			int num7 = villageMap.calcTotalMonksAtHome();
			this.LLog(string.Format("{0}: {1}", LNG.Print("Number of monks available at the moment"), num7), false);
			if (num7 < numberOfMonks && allowHireMonks)
			{
				this.LLog(LNG.Print("Trying to hire extra monks"), false);
				int num8 = this.MakeMonks(villageId, numberOfMonks - num7, waitForMonks, ControlForm.Tab.Radar);
				if (num8 > 0)
				{
					num7 = villageMap.calcTotalMonksAtHome();
					this.LLog(string.Format("{0}: {1}", LNG.Print("Number of monks available at the moment"), num7), false);
				}
			}
			if (num7 == 0)
			{
				this.LLog(LNG.Print("Village doesn't have monks. Can't interdict"), true);
				return;
			}
			if (num7 < numberOfMonks)
			{
				numberOfMonks = num7;
			}
			this.LLog(string.Format("{0} : {1}", LNG.Print("Trying to send monks"), numberOfMonks), false);
			this.LLog(LNG.Print("Init basic delay of random length"), false);
			if (radarCalled && base.RandomSleepOrExit(3521, 5241))
			{
				return;
			}
			if (this.AutoIDExtraDelay > 0)
			{
				this.LLog(string.Format("{0} {1}s", LNG.Print("Init extra delay"), this.AutoIDExtraDelay), false);
				if (base.SleepOrExit(this.AutoIDExtraDelay * 1000))
				{
					return;
				}
			}
			RemoteServices.Instance.set_SendPeople_UserCallBack(new RemoteServices.SendPeople_UserCallBack(this.sendPeopleCallback));
			RemoteServices.Instance.SendPeople(villageId, villageId, 4, numberOfMonks, 4, -1);
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0004BA9C File Offset: 0x00049C9C
		public void ScanMonks(List<int> playerVillages)
		{
			SparseArray peopleArray = GameEngine.Instance.World.getPeopleArray();
			foreach (object obj in peopleArray)
			{
				WorldMap.LocalPerson localPerson = (WorldMap.LocalPerson)obj;
				int homeVillageID = localPerson.person.homeVillageID;
				int targetVillageID = localPerson.person.targetVillageID;
				if (localPerson.person.personType == 4 && localPerson.person.state > 0 && localPerson.parentPerson < 0L && playerVillages.Contains(targetVillageID) && !playerVillages.Contains(homeVillageID) && !this.SpotedMonks.Contains(localPerson.personID))
				{
					this.SpotedMonks.Add(localPerson.personID);
					string eventType = RadarService.GetEventType(false, targetVillageID, homeVillageID, 0, 0, 0);
					this.ProcessEvent(eventType, homeVillageID, targetVillageID, localPerson.localEndTime);
				}
			}
		}

		// Token: 0x06000289 RID: 649 RVA: 0x0004BB98 File Offset: 0x00049D98
		internal void ProcessEvent(string eventType, int fromId, int toId, double localEndTime)
		{
			RadarSetting radarSetting = this._radarBGSettings.Single((RadarSetting s) => s.Name == eventType);
			if (!radarSetting.MonitorIt)
			{
				return;
			}
			string villageNameOrType = GameEngine.Instance.World.getVillageNameOrType(fromId);
			string villageName = GameEngine.Instance.World.getVillageName(toId);
			string text = string.Concat(new string[]
			{
				eventType,
				": ",
				villageNameOrType,
				" => ",
				villageName,
				"."
			});
			DateTime interdictionTime = GameEngine.Instance.World.getVillageData(toId).interdictionTime;
			DateTime currentServerTime = VillageMap.getCurrentServerTime();
			if (interdictionTime > currentServerTime)
			{
				int secsLeft = (int)(interdictionTime - currentServerTime).TotalSeconds;
				text = string.Concat(new string[]
				{
					text,
					" ",
					SK.Text("OtherVillagePanel_Cannot_Be_Attacked_For_X_Time", "Cannot be attacked for"),
					": ",
					VillageMap.createBuildTimeString(secsLeft)
				});
			}
			else if (radarSetting.Interdict > 0 && !this.IsMonitoringAlt)
			{
				bool flag = true;
				if (!this.VillagesSentSelfID.ContainsKey(toId))
				{
					this.VillagesSentSelfID.Add(toId, DateTime.Now);
					this.LLog(string.Format("{0} new Interdict attempt.", toId), false);
				}
				else if (DateTime.Now - this.VillagesSentSelfID[toId] > TimeSpan.FromSeconds(30.0))
				{
					this.LLog(string.Format("{0} last Interdict attempt: {1}", toId, this.VillagesSentSelfID[toId]), false);
					this.VillagesSentSelfID[toId] = DateTime.Now;
				}
				else
				{
					this.LLog(string.Format("{0} last Interdict attempt: {1}", toId, this.VillagesSentSelfID[toId]), false);
					flag = false;
				}
				if (flag)
				{
					this.LLog(string.Format("{0} {1}", toId, LNG.Print("trying to Interdict.")), false);
					this.VillageSelfID(toId, this.AutoHireMonks, (int)radarSetting.Interdict, true, true, false);
				}
			}
			if (radarSetting.PopupMessage)
			{
				this.ShowRadarPopupMessage(eventType, villageNameOrType, villageName, fromId, toId, localEndTime, new CloseAllMessages(this.CloseAllMessages));
			}
			string text2 = "Incoming " + eventType + " in " + Program.WorldName;
			this.PlaySound(radarSetting.Sound);
			if (radarSetting.Email)
			{
				this.SendEmail(text2, text);
			}
			if (radarSetting.NotifyIcon)
			{
				this.ShowNotifyIcon(text2, text);
			}
			string message = string.Concat(new string[]
			{
				"[",
				RemoteServices.Instance.UserName,
				"] [",
				Program.WorldName,
				"] ",
				text
			});
			if (radarSetting.SendDiscordMessage)
			{
				RadarService.SendDiscordMessage(message, this.DiscordWebhook, this.Log);
			}
			if (radarSetting.SendTelegramMessage)
			{
				RadarService.SendTelegramMessage(message, this.TelegramBotToken, this.TelegramChatID, this.Log);
			}
			this.LLog(text, false);
		}

		// Token: 0x0600028A RID: 650 RVA: 0x0004BEC4 File Offset: 0x0004A0C4
		internal void ShowNotifyIcon(string eventType, string notification)
		{
			this._notifyIcon.Visible = true;
			this._notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
			this._notifyIcon.BalloonTipText = notification;
			this._notifyIcon.BalloonTipTitle = eventType;
			this._notifyIcon.ShowBalloonTip(5000);
			this._closeNotifyIconTimer = new System.Threading.Timer(delegate(object state)
			{
				this._notifyIcon.Visible = false;
			}, null, 10000, 0);
		}

		// Token: 0x0600028B RID: 651 RVA: 0x0004BF30 File Offset: 0x0004A130
		public void ShowRadarPopupMessage(string eventType, string from, string to, int fromId, int toId, double localEndTime, CloseAllMessages del)
		{
			BaseImage image = null;
			if (eventType.Contains("Scouts"))
			{
				image = GFXLibrary.scout_screen_illustration_01;
			}
			else if (eventType.Contains("Monks"))
			{
				image = GFXLibrary.illustration_monks;
			}
			else
			{
				image = GFXLibrary.send_army_illustration;
			}
			DX.ControlForm.BeginInvoke(new MethodInvoker(delegate()
			{
				if (GameEngine.Instance.LocalWorldData != null)
				{
					int villageFaction = GameEngine.Instance.World.getVillageFaction(fromId);
					RadarPopupMessage radarPopupMessage = new RadarPopupMessage(image, eventType, from, to, GameEngine.Instance.World.getFactionName(villageFaction), GameEngine.Instance.World.getHouse(villageFaction), localEndTime, del);
					radarPopupMessage.Show();
					radarPopupMessage.TopMost = this.PopupOnTop;
					this.OpenMessages.Add(radarPopupMessage);
					return;
				}
				RadarPopupMessage radarPopupMessage2 = new RadarPopupMessage(image, eventType, from, to, "NonExistables", 19, localEndTime, del);
				radarPopupMessage2.Show();
				this.OpenMessages.Add(radarPopupMessage2);
			}));
		}

		// Token: 0x0600028C RID: 652 RVA: 0x0004BFE0 File Offset: 0x0004A1E0
		public void CloseAllMessages(object sender, EventArgs e)
		{
			try
			{
				foreach (Form form in this.OpenMessages)
				{
					form.Close();
				}
			}
			catch (InvalidOperationException ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.Radar);
			}
			this.OpenMessages.Clear();
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0004C058 File Offset: 0x0004A258
		public void SendEmail(string subject, string notification)
		{
			if (this.AreEmailsConfigured())
			{
				string result = this.UseDefaultEmail ? this.SendDefaultMail(subject, notification) : MailService.SendMail(this.FromEmail, this.FromPw, this.ToEmail, subject, notification);
				this.LLog(result, false);
				this._radarEmailStatus.BeginInvoke(new MethodInvoker(delegate()
				{
					this._radarEmailStatus.Text = result;
				}));
				return;
			}
			this.PrintEmailsWarning();
		}

		// Token: 0x0600028E RID: 654 RVA: 0x000094B7 File Offset: 0x000076B7
		internal void TestDiscordMessage()
		{
			RadarService.SendDiscordMessage(LNG.Print("Working"), this.DiscordWebhook, this.Log);
		}

		// Token: 0x0600028F RID: 655 RVA: 0x0004C0D8 File Offset: 0x0004A2D8
		internal static void SendDiscordMessage(string message, string discordWebhook, Log logMethod)
		{
			if (string.IsNullOrEmpty(discordWebhook))
			{
				logMethod(string.Concat(new string[]
				{
					SK.Text("GENERIC_Error", "Error"),
					" ",
					LNG.Print("Webhook"),
					" ",
					LNG.Print("no data")
				}), ControlForm.Tab.Radar, false);
				return;
			}
			NameValueCollection data = new NameValueCollection
			{
				{
					"content",
					message
				},
				{
					"username",
					"SHKE Bot Radar"
				}
			};
			try
			{
				DX.WebClient.UploadValues(discordWebhook, data);
			}
			catch (Exception ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.Radar);
			}
		}

		// Token: 0x06000290 RID: 656 RVA: 0x000094D4 File Offset: 0x000076D4
		internal void TestTelegramMessage()
		{
			RadarService.SendTelegramMessage(LNG.Print("Working"), this.TelegramBotToken, this.TelegramChatID, this.Log);
		}

		// Token: 0x06000291 RID: 657 RVA: 0x0004C188 File Offset: 0x0004A388
		internal static void SendTelegramMessage(string message, string telegramBotToken, string telegramChatID, Log logMethod)
		{
			if (string.IsNullOrEmpty(telegramBotToken))
			{
				logMethod(string.Concat(new string[]
				{
					SK.Text("GENERIC_Error", "Error"),
					" ",
					LNG.Print("Bot Token"),
					" ",
					LNG.Print("no data")
				}), ControlForm.Tab.Radar, false);
				return;
			}
			if (string.IsNullOrEmpty(telegramChatID))
			{
				logMethod(string.Concat(new string[]
				{
					SK.Text("GENERIC_Error", "Error"),
					" ",
					LNG.Print("Chat ID"),
					" ",
					LNG.Print("no data")
				}), ControlForm.Tab.Radar, false);
				return;
			}
			NameValueCollection nameValueCollection = new NameValueCollection
			{
				{
					"text",
					message
				},
				{
					"chat_id",
					telegramChatID
				}
			};
			try
			{
				ServicePointManager.SecurityProtocol = (SecurityProtocolType)3312;
				if (RadarService.UseProxy)
				{
					IWebProxy proxy = DX.WebClient.Proxy;
					DX.WebClient.Proxy = new WebProxy(RadarService.ProxyAddress, RadarService.ProxyPort);
					if (RadarService.UseCredentials)
					{
						DX.WebClient.Proxy.Credentials = new NetworkCredential(RadarService.ProxyUsername, RadarService.ProxyPassword);
					}
					DX.WebClient.UploadValues("https://api.telegram.org/bot" + telegramBotToken + "/sendMessage", nameValueCollection);
					DX.WebClient.Proxy = proxy;
				}
				else
				{
					DX.WebClient.UploadValues("https://api.telegram.org/bot" + telegramBotToken + "/sendMessage", nameValueCollection);
				}
			}
			catch (NotSupportedException ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.Radar);
				ABaseService.ProcessUnsupportedException();
				nameValueCollection.Add("token", telegramBotToken);
				try
				{
					DX.WebClient.UploadValues("https://shkbot.site/telegramProxy.php", nameValueCollection);
				}
				catch (Exception ex2)
				{
					ABaseService.ReportError(ex2, ControlForm.Tab.Radar);
				}
			}
			catch (Exception ex3)
			{
				ABaseService.ReportError(ex3, ControlForm.Tab.Radar);
			}
			finally
			{
				ServicePointManager.SecurityProtocol = (SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls);
			}
		}

		// Token: 0x06000292 RID: 658 RVA: 0x0004C388 File Offset: 0x0004A588
		public void ScanArmies(List<int> playerVillages)
		{
			SparseArray armyArray = GameEngine.Instance.World.getArmyArray();
			IEnumerator enumerator = armyArray.GetEnumerator();
			while (enumerator.MoveNext())
			{
					WorldMap.LocalArmyData army = (WorldMap.LocalArmyData)enumerator.Current;
					if (!army.reinforcements && playerVillages.Contains(army.targetVillageID) && !this.ReportedArmies.Any((ReportedArmy a) => a.armyID == army.armyID && a.serverStartTime == army.serverStartTime) && army.lootType < 0 && army.attackType != 30 && army.attackType != 31 && army.armyID > GameEngine.Instance.World.HighestArmyIDSeen)
					{
						this.ReportedArmies.Add(new ReportedArmy
						{
							armyID = army.armyID,
							serverStartTime = army.serverStartTime
						});
						GameEngine.Instance.World.HighestArmyIDSeen = army.armyID;
						this.ProcessEvent(RadarService.GetEventType(true, army.targetVillageID, army.travelFromVillageID, army.numScouts, army.numCaptains, army.attackType), army.travelFromVillageID, army.targetVillageID, army.localEndTime);
					}
			}
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0004C548 File Offset: 0x0004A748
		internal static string GetEventType(bool isArmy, int targetVillageID, int travelFromVillageID, int numScouts, int numCaptains, int attackType)
		{
			string text;
			if (isArmy)
			{
				if (!GameEngine.Instance.World.isCapital(targetVillageID))
				{
					if (numScouts > 0)
					{
						text = "Scouts";
					}
					else
					{
						if (numCaptains > 0 || attackType == 18)
						{
							text = "Captain";
						}
						else
						{
							text = "Attack";
						}
						bool flag = GameEngine.Instance.World.getSpecial(travelFromVillageID) != 0;
						if (flag)
						{
							text = "AI " + text;
						}
					}
				}
				else if (numScouts > 0)
				{
					text = "Scouts to Capital";
				}
				else
				{
					text = "Attack to Capital";
				}
			}
			else if (!GameEngine.Instance.World.isCapital(targetVillageID))
			{
				text = "Monks";
			}
			else
			{
				text = "Monks to Capital";
				bool flag2 = GameEngine.Instance.World.getSpecial(travelFromVillageID) != 0;
				if (flag2)
				{
					text = "AI " + text;
				}
			}
			return text;
		}

		// Token: 0x06000294 RID: 660 RVA: 0x000094F7 File Offset: 0x000076F7
		private bool IsSoundFileValid(string path)
		{
			if (!string.IsNullOrEmpty(path) && path.Trim().Length != 0)
			{
				if (File.Exists(path))
				{
					return true;
				}
				this.LLog(LNG.Print("File doesn't exist") + " : " + path, false);
			}
			return false;
		}

		// Token: 0x06000295 RID: 661 RVA: 0x00009535 File Offset: 0x00007735
		public void Save()
		{
			new Thread(delegate()
			{
				string path = ControlForm.SettingsFolder + "UseDefaultEmail.txt";
				File.WriteAllText(path, this._radarUseDefault.Checked.ToString());
				string[] array = new string[this._radarBGSettings.Length + 1];
				int num = 0;
				foreach (RadarSetting radarSetting in this._radarBGSettings)
				{
					array[num] = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", new object[]
					{
						radarSetting.MonitorIt,
						radarSetting.PopupMessage,
						radarSetting.Sound,
						radarSetting.Email,
						radarSetting.Interdict,
						radarSetting.NotifyIcon,
						radarSetting.SendDiscordMessage,
						radarSetting.SendTelegramMessage
					});
					num++;
				}
				array[num] = string.Format("UserID: {0}", RemoteServices.Instance.UserID);
				path = (this.IsMonitoringAlt ? SettingsManager.GetSettingsFilePathAnotherUser("Radar.txt", this.AltUsername, true, new string[]
				{
					this.Name
				}) : SettingsManager.GetSettingsFilePath("Radar.txt", true, new string[]
				{
					this.Name
				}));
				File.WriteAllLines(path, array);
				path = (this.IsMonitoringAlt ? SettingsManager.GetSettingsFilePathAnotherUser("AutoHireMonks.txt", this.AltUsername, false, new string[]
				{
					this.Name
				}) : SettingsManager.GetSettingsFilePath("AutoHireMonks.txt", true, new string[]
				{
					this.Name
				}));
				File.WriteAllText(path, this.AutoHireMonks.ToString());
				if (this.IsMonitoringAlt)
				{
					path = SettingsManager.GetSettingsFilePath("RadarAltSettings.txt", true, new string[]
					{
						this.Name
					});
					File.WriteAllText(path, string.Format("{0};{1}", this.AltUserID, this.AltUsername));
				}
				SettingsManager.CreateNotificationsEmail(true, this.FromEmail, this.FromPw, this.ToEmail);
			}).Start();
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0004C610 File Offset: 0x0004A810
		public void Load(bool skipAltLoading = false)
		{
			this.LoadRadarEmailSettings();
			string text = ControlForm.SettingsFolder + "UseDefaultEmail.txt";
			bool @checked;
			if (File.Exists(text) && bool.TryParse(File.ReadAllText(text), out @checked))
			{
				this._radarUseDefault.Checked = @checked;
				DX.ControlForm.checkBox_RadarUseDefault_CheckedChanged(null, EventArgs.Empty);
			}
			if (!skipAltLoading)
			{
				this.LoadAltSettings();
			}
			text = (this.IsMonitoringAlt ? SettingsManager.GetSettingsFilePathAnotherUser("Radar.txt", this.AltUsername, false, new string[]
			{
				this.Name
			}) : SettingsManager.GetSettingsFilePath("Radar.txt", false, new string[]
			{
				this.Name
			}));
			if (!File.Exists(text))
			{
				this.LLog(LNG.Print("File doesn't exist") + ": " + text, false);
			}
			else
			{
				string[] array = File.ReadAllLines(text);
				try
				{
					for (int i = 0; i < 10; i++)
					{
						string[] array2 = array[i].Split(new char[]
						{
							','
						});
						if (array2.Length < 5 || array2.Length > 8)
						{
							ABaseService.MessageBoxNonModal("Radar setting is out dated or Sound file has commas.\n " + array[i], "Warning!");
						}
						else
						{
							this._radarBGSettings[i].MonitorIt = (array2[0] == "True");
							this._radarBGSettings[i].PopupMessage = (array2[1] == "True");
							if (!string.IsNullOrEmpty(array2[2]) && !File.Exists(array2[2]))
							{
								ABaseService.MessageBoxNonModal(LNG.Print("File doesn't exist") + ":\n " + array2[2], "Warning!");
							}
							this._radarBGSettings[i].Sound = array2[2];
							this._radarBGSettings[i].Email = (array2[3] == "True");
							if (i < 6)
							{
								this._radarBGSettings[i].Interdict = Convert.ToByte(array2[4]);
							}
							this._radarBGSettings[i].NotifyIcon = (array2[5] == "True");
							this._radarSettings[7, i].Value = (this._radarBGSettings[i].SendDiscordMessage = (array2.Length == 8 && array2[6] == "True"));
							this._radarSettings[8, i].Value = (this._radarBGSettings[i].SendTelegramMessage = (array2.Length == 8 && array2[7] == "True"));
							this._radarSettings[1, i].Value = this._radarBGSettings[i].MonitorIt;
							this._radarSettings[2, i].Value = this._radarBGSettings[i].PopupMessage;
							this._radarSettings[3, i].Value = Path.GetFileName(this._radarBGSettings[i].Sound);
							this._radarSettings[4, i].Value = this._radarBGSettings[i].Email;
							if (i < 6)
							{
								this._radarSettings[5, i].Value = this._radarBGSettings[i].Interdict;
							}
							this._radarSettings[6, i].Value = this._radarBGSettings[i].NotifyIcon;
						}
					}
				}
				catch (Exception ex)
				{
					ABaseService.ReportError(ex, ControlForm.Tab.Radar);
				}
				if (this._radarBGSettings.Any((RadarSetting s) => s.Email) && !this.AreEmailsConfigured())
				{
					this.PrintEmailsWarning();
				}
			}
			text = (this.IsMonitoringAlt ? SettingsManager.GetSettingsFilePathAnotherUser("Radar.txt", this.AltUsername, false, new string[]
			{
				this.Name
			}) : SettingsManager.GetSettingsFilePath("AutoHireMonks.txt", false, new string[]
			{
				this.Name
			}));
			bool flag;
			if (File.Exists(text) && bool.TryParse(File.ReadAllText(text), out flag))
			{
				this.AutoHireMonks = flag;
				if (DX.ControlForm != null)
				{
					DX.ControlForm.checkBox_RadarRehireMonks.Checked = flag;
				}
			}
		}

		// Token: 0x06000297 RID: 663 RVA: 0x0004CA60 File Offset: 0x0004AC60
		internal static void ExportSettings()
		{
			try
			{
				List<string> list = new List<string>();
				list.Add(RemoteServices.Instance.UserName);
				list.Add(Program.mySettings.Username);
				list.Add(Settings.Default.UserContactEmail);
				string text = ControlForm.SettingsFolder + "\\NotificationEmail.txt";
				if (File.Exists(text))
				{
					list.Add(File.ReadAllLines(text)[2]);
				}
				list.Add(Settings.Default.DiscordWebhook);
				list.Add(Settings.Default.TelegramBotToken);
				list.Add(Settings.Default.TelegramChatID);
				string[] directories = Directory.GetDirectories(Path.Combine(ControlForm.SettingsFolder, RemoteServices.Instance.UserName));
				foreach (string text2 in directories)
				{
					text = Path.Combine(text2, "Radar");
					text = Path.Combine(text, "Radar.txt");
					if (File.Exists(text))
					{
						DirectoryInfo directoryInfo = new DirectoryInfo(text2);
						list.Add("World Settings: " + directoryInfo.Name);
						list.AddRange(File.ReadAllLines(text));
					}
				}
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					File.WriteAllLines(saveFileDialog.FileName, list.ToArray());
				}
			}
			catch (Exception ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.Radar);
				DX.ShowErrorMessage(ex);
			}
		}

		// Token: 0x06000298 RID: 664 RVA: 0x0004CBD0 File Offset: 0x0004ADD0
		public override void ConcreteAction()
		{
			try
			{
				if (this._radarBGSettings.Any((RadarSetting s) => s.Email) && !this.AreEmailsConfigured())
				{
					this.PrintEmailsWarning();
				}
				List<int> playerVillages = this.IsMonitoringAlt ? GameEngine.Instance.World.getListOfUserVillagesAndCapitals(this.AltUserID) : new List<int>(this.SelectedVillages);
				this.ScanArmies(playerVillages);
				this.ScanMonks(playerVillages);
			}
			catch (InvalidOperationException)
			{
			}
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0004CC68 File Offset: 0x0004AE68
		public string SendDefaultMail(string subject, string body)
		{
			string url = string.Concat(new string[]
			{
				"qjd=",
				DX.Encode(RemoteServices.Instance.UserName),
				"&me=r&xcg=",
				DX.Encode(DX.GetConfig().Email),
				"&qlc=",
				DX.Encode(this.ToEmail.Trim()),
				"&cvd=",
				DX.Encode(subject),
				"&ppz=",
				DX.Encode(body)
			});
			return base.MonitorAttacks(url, ControlForm.Tab.Radar);
		}

		// Token: 0x0600029A RID: 666 RVA: 0x0004CCFC File Offset: 0x0004AEFC
		private void SettingsGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			if (e.RowIndex == -1 || e.ColumnIndex != 3)
			{
				return;
			}
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Filter = "Music (.mp3)|*.mp3|ALL Files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				if (openFileDialog.FileName.Contains(","))
				{
					ABaseService.MessageBoxNonModal("Please remove commas from MP3 name! \n " + openFileDialog.FileName, "Warning!");
					return;
				}
				this._radarSettings[e.ColumnIndex, e.RowIndex].Value = Path.GetFileName(openFileDialog.FileName);
				this._radarBGSettings[e.RowIndex].Sound = openFileDialog.FileName;
			}
		}

		// Token: 0x0600029B RID: 667 RVA: 0x0004CDA4 File Offset: 0x0004AFA4
		private void SettingsGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex == -1)
			{
				return;
			}
			object value = this._radarSettings[e.ColumnIndex, e.RowIndex].Value;
			switch (e.ColumnIndex)
			{
			case 1:
				this._radarBGSettings[e.RowIndex].MonitorIt = (bool)value;
				return;
			case 2:
				this._radarBGSettings[e.RowIndex].PopupMessage = (bool)value;
				return;
			case 3:
				if (value == null || value.ToString() == string.Empty)
				{
					this._radarSettings[e.ColumnIndex, e.RowIndex].Value = LNG.Print("Select sound file");
					this._radarBGSettings[e.RowIndex].Sound = string.Empty;
					return;
				}
				break;
			case 4:
			{
				bool flag = (bool)value;
				if (!flag)
				{
					this._radarBGSettings[e.RowIndex].Email = flag;
					return;
				}
				if (this.AreEmailsConfigured())
				{
					this._radarBGSettings[e.RowIndex].Email = flag;
					return;
				}
				this._radarSettings[e.ColumnIndex, e.RowIndex].Value = false;
				this.PrintEmailsWarning();
				return;
			}
			case 5:
			{
				if (e.RowIndex > 5)
				{
					this._radarSettings[e.ColumnIndex, e.RowIndex].Value = 0;
					MyMessageBox.Show(LNG.Print("Can not Interdict Capitals."));
					return;
				}
				byte interdict;
				if (value == null || !byte.TryParse(value.ToString(), out interdict))
				{
					MyMessageBox.Show(LNG.Print("Only numbers 0-9!"));
					this._radarSettings[e.ColumnIndex, e.RowIndex].Value = this._radarBGSettings[e.RowIndex].Interdict;
					return;
				}
				this._radarBGSettings[e.RowIndex].Interdict = interdict;
				return;
			}
			case 6:
				this._radarBGSettings[e.RowIndex].NotifyIcon = (bool)value;
				return;
			case 7:
				this._radarBGSettings[e.RowIndex].SendDiscordMessage = (bool)value;
				return;
			case 8:
				this._radarBGSettings[e.RowIndex].SendTelegramMessage = (bool)value;
				break;
			default:
				return;
			}
		}

		// Token: 0x0600029C RID: 668 RVA: 0x0004CFE0 File Offset: 0x0004B1E0
		private void SettingsGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 5)
			{
				if (e.RowIndex > 5)
				{
					this._radarSettings[e.ColumnIndex, e.RowIndex].Value = 0;
					MyMessageBox.Show("Can not Interdict Capitals.");
					return;
				}
				DataGridViewCell dataGridViewCell = this._radarSettings[e.ColumnIndex, e.RowIndex];
				string s;
				if (dataGridViewCell == null)
				{
					s = null;
				}
				else
				{
					object value = dataGridViewCell.Value;
					s = ((value != null) ? value.ToString() : null);
				}
				byte interdict;
				if (!byte.TryParse(s, out interdict))
				{
					MyMessageBox.Show("Incorrect input. This cell should only contain numbers");
					this._radarSettings[e.ColumnIndex, e.RowIndex].Value = 0;
					return;
				}
				this._radarBGSettings[e.RowIndex].Interdict = interdict;
			}
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0004D0AC File Offset: 0x0004B2AC
		private void LoadRadarEmailSettings()
		{
			string text = ControlForm.SettingsFolder + "\\NotificationEmail.txt";
			if (!File.Exists(text))
			{
				this.LLog(LNG.Print("File doesn't exist") + ": " + text + " ", false);
				return;
			}
			string[] array = File.ReadAllLines(text);
			char[] separator = new char[]
			{
				':'
			};
			foreach (string text2 in array)
			{
				string[] array3 = text2.Split(separator, StringSplitOptions.RemoveEmptyEntries);
				if (array3.Length >= 2 && !string.IsNullOrEmpty(array3[1]))
				{
					string text3 = array3[0];
					if (text3 != null)
					{
						if (!(text3 == "From"))
						{
							if (!(text3 == "Password"))
							{
								if (text3 == "To")
								{
									this.ToEmail = array3[1];
								}
							}
							else
							{
								this.FromPw = array3[1];
							}
						}
						else
						{
							this.FromEmail = array3[1];
						}
					}
				}
			}
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0000954D File Offset: 0x0000774D
		public bool AreEmailsConfigured()
		{
			return !string.IsNullOrEmpty(this.ToEmail) && (this.UseDefaultEmail || (!string.IsNullOrEmpty(this.FromEmail) && !string.IsNullOrEmpty(this.FromPw)));
		}

		// Token: 0x0600029F RID: 671 RVA: 0x00009585 File Offset: 0x00007785
		public void PrintEmailsWarning()
		{
			this.LLog(LNG.Print("WARNING! You should complete 'Email Settings' first!"), true);
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x0004D19C File Offset: 0x0004B39C
		internal void InterdictSelectedVillages(int numberOfMonks, IEnumerable<int> selectedVillages, bool reduceMonksIfIDed, bool allowHireMonks)
		{
			if (!base.IsSubscribed)
			{
				ABaseService.MessageBoxNonModal(string.Concat(new string[]
				{
					LNG.Print("You need to have one of the following subscriptions"),
					": ",
					LNG.Print("All features"),
					", ",
					LNG.Print(this.Name)
				}), LNG.Print("Please subscribe"));
				return;
			}
			if (selectedVillages.Count<int>() < 1)
			{
				this.LLog(LNG.Print("Please select at least 1 village"), true);
				return;
			}
			this.LLog(LNG.Print("Start Interdict cycle"), false);
			new Thread(delegate()
			{
				foreach (int num in selectedVillages)
				{
					this.LLog(string.Format("{0}: {1}", LNG.Print("Checking village"), num), false);
					this.VillageSelfID(num, allowHireMonks, numberOfMonks, true, false, reduceMonksIfIDed);
					this.RandomSleepOrExit(1500, 2000);
				}
				this.LLog(LNG.Print("Finished Interdict cycle"), false);
			}).Start();
		}

		// Token: 0x040003EB RID: 1003
		internal bool IsMonitoringAlt;

		// Token: 0x040003EC RID: 1004
		private int AltUserID;

		// Token: 0x040003ED RID: 1005
		private string AltUsername;

		// Token: 0x040003EE RID: 1006
		private Label _radarAltLabel;

		// Token: 0x040003EF RID: 1007
		private DataGridView _radarSettings;

		// Token: 0x040003F0 RID: 1008
		private RadarSetting[] _radarBGSettings;

		// Token: 0x040003F1 RID: 1009
		public string FromEmail;

		// Token: 0x040003F2 RID: 1010
		public string FromPw;

		// Token: 0x040003F3 RID: 1011
		public string ToEmail;

		// Token: 0x040003F4 RID: 1012
		public bool UseDefaultEmail;

		// Token: 0x040003F5 RID: 1013
		private CheckBox _radarUseDefault;

		// Token: 0x040003F6 RID: 1014
		private Label _radarEmailStatus;

		// Token: 0x040003F7 RID: 1015
		private const string SettingsFileName = "Radar.txt";

		// Token: 0x040003F8 RID: 1016
		private const string AutoHireMonksFileName = "AutoHireMonks.txt";

		// Token: 0x040003F9 RID: 1017
		private const string RadarAltSettingsFileName = "RadarAltSettings.txt";

		// Token: 0x040003FA RID: 1018
		private List<RadarPopupMessage> OpenMessages;

		// Token: 0x040003FB RID: 1019
		public MediaPlayer SoundPlayer;

		// Token: 0x040003FC RID: 1020
		public List<ReportedArmy> ReportedArmies = new List<ReportedArmy>();

		// Token: 0x040003FD RID: 1021
		public List<long> SpotedMonks = new List<long>();

		// Token: 0x040003FE RID: 1022
		internal bool AutoHireMonks;

		// Token: 0x040003FF RID: 1023
		internal bool PopupOnTop = true;

		// Token: 0x04000400 RID: 1024
		private NotifyIcon _notifyIcon;

		// Token: 0x04000401 RID: 1025
		private System.Threading.Timer _closeNotifyIconTimer;

		// Token: 0x04000402 RID: 1026
		internal string DiscordWebhook;

		// Token: 0x04000403 RID: 1027
		internal string TelegramBotToken;

		// Token: 0x04000404 RID: 1028
		internal string TelegramChatID;

		// Token: 0x04000405 RID: 1029
		internal static bool UseProxy;

		// Token: 0x04000406 RID: 1030
		internal static bool UseCredentials;

		// Token: 0x04000407 RID: 1031
		internal static string ProxyAddress;

		// Token: 0x04000408 RID: 1032
		internal static int ProxyPort;

		// Token: 0x04000409 RID: 1033
		internal static string ProxyUsername;

		// Token: 0x0400040A RID: 1034
		internal static string ProxyPassword;

		// Token: 0x0400040B RID: 1035
		internal int AutoIDExtraDelay;

		// Token: 0x0400040C RID: 1036
		private Label _autoIDExtraDelay;

		// Token: 0x0400040D RID: 1037
		private int _lastPlayedIndex;

		// Token: 0x0400040E RID: 1038
		private Dictionary<int, DateTime> VillagesSentSelfID = new Dictionary<int, DateTime>();
	}
}
