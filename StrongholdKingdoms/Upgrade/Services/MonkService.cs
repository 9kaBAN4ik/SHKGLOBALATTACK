using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms;

namespace Upgrade.Services
{
	// Token: 0x02000041 RID: 65
	internal class MonkService : ABaseService
	{
		// Token: 0x06000249 RID: 585 RVA: 0x000490C8 File Offset: 0x000472C8
		internal MonkService(Log log, DataGridView dataGridView_Monks, MakeMonksDelegate makeMonksDelegate) : base(log)
		{
			this.TranslateUI();
			this._dataGridView_Monks = dataGridView_Monks;
			this._dataGridView_Monks.CellValueChanged += this.DataGridView_MonkRoutes_CellValueChanged;
			this.MakeMonks = makeMonksDelegate;
		}

		// Token: 0x0600024A RID: 586 RVA: 0x00049120 File Offset: 0x00047320
		private void DataGridView_MonkRoutes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex == -1)
			{
				return;
			}
			MonkRoute monkRoute = this.MonkRoutes[e.RowIndex];
			object value = this._dataGridView_Monks[e.ColumnIndex, e.RowIndex].Value;
			switch (e.ColumnIndex)
			{
			case 0:
				monkRoute.Name = ((value != null) ? value.ToString() : null);
				return;
			case 1:
				monkRoute.Enabled = (bool)value;
				return;
			case 2:
			case 3:
			case 4:
			case 5:
				break;
			case 6:
			case 8:
			{
				int num;
				if (value == null || !int.TryParse(value.ToString(), out num))
				{
					MyMessageBox.Show("Only numbers 0-9!");
					if (e.ColumnIndex == 6)
					{
						this._dataGridView_Monks[e.ColumnIndex, e.RowIndex].Value = monkRoute.ExtraParameter;
						return;
					}
					this._dataGridView_Monks[e.ColumnIndex, e.RowIndex].Value = monkRoute.DistanceLimit;
					return;
				}
				else
				{
					if (e.ColumnIndex == 6)
					{
						monkRoute.ExtraParameter = num;
						return;
					}
					monkRoute.DistanceLimit = num;
					MonkService.OptimizeRoute(monkRoute);
					return;
				}
				break;
			}
			case 7:
				monkRoute.IsDistanceLimited = (bool)value;
				MonkService.OptimizeRoute(monkRoute);
				break;
			default:
				return;
			}
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00009382 File Offset: 0x00007582
		private void LLog(string message, bool isError = false)
		{
			this.Log(message, ControlForm.Tab.Monks, isError);
		}

		// Token: 0x0600024C RID: 588 RVA: 0x00049264 File Offset: 0x00047464
		private void UpdateUIonRouteDisable(MonkRoute route)
		{
			int routeIndex = this.MonkRoutes.IndexOf(route);
			this.UpdateUIonRouteDisable(routeIndex);
		}

		// Token: 0x0600024D RID: 589 RVA: 0x00049288 File Offset: 0x00047488
		private void UpdateUIonRouteDisable(int routeIndex)
		{
			this._dataGridView_Monks.BeginInvoke(new MethodInvoker(delegate()
			{
				this._dataGridView_Monks[1, routeIndex].Value = false;
			}));
		}

		// Token: 0x0600024E RID: 590 RVA: 0x000492C4 File Offset: 0x000474C4
		public override void ConcreteAction()
		{
			List<MonkRoute> list = new List<MonkRoute>(this.MonkRoutes);
			foreach (MonkRoute monkRoute in list)
			{
				if (monkRoute.Enabled)
				{
					this.LLog(LNG.Print("Process route") + ": " + monkRoute.Name, false);
					MonkService.ShkMonkCommand shkMonkCommand = this.MapMonkCommand(monkRoute.Command);
					if (!this.IsMonkCommandResearched(shkMonkCommand))
					{
						this.LLog(LNG.Print("Monk command is not researched! Stopping") + " \"" + monkRoute.Name + "\"", false);
						monkRoute.Enabled = false;
						this.UpdateUIonRouteDisable(monkRoute);
					}
					else
					{
						int num = 0;
						if (monkRoute.StopConditionType == 0)
						{
							num = this.TotalMonksToQuestComplete(shkMonkCommand);
							if (num <= 0)
							{
								this.LLog(LNG.Print("Quest is complete! Stopping") + " \"" + monkRoute.Name + "\"", false);
								monkRoute.Enabled = false;
								this.UpdateUIonRouteDisable(monkRoute);
								continue;
							}
						}
						List<int> list2 = new List<int>();
						foreach (int num2 in monkRoute.From)
						{
							if (GameEngine.Instance.getVillage(num2) == null)
							{
								this.LLog(string.Format("{0} {1}", LNG.Print("Village wasn't loaded:"), num2), false);
							}
							else if (GameEngine.Instance.World.isVillageExcommunicated(num2))
							{
								this.LLog(SK.Text("TOOLTIPS_VO_EXCOMMUNICATION", "This village is Excommunicated."), false);
							}
							else
							{
								this.LLog(string.Format("{0}: {1}", LNG.Print("Process village"), num2), false);
								foreach (int num3 in monkRoute.SortedRecipients[num2])
								{
									if (list2.Contains(num3))
									{
										this.LLog(string.Format("{0}: {1}", LNG.Print("Target already processed"), num3), false);
									}
									else
									{
										this.LLog(string.Format("{0}: {1}", LNG.Print("Process target"), num3), false);
										if (monkRoute.StopConditionType == 1)
										{
											num = monkRoute.ExtraParameter - monkRoute.CurrentProgress[num3];
											this.LLog(string.Format("Target {0} current progress {1}/{2}.", num3, monkRoute.CurrentProgress[num3], monkRoute.ExtraParameter), false);
										}
										else if (monkRoute.StopConditionType == 2)
										{
											num = this.CheckTargetCondition(num3, shkMonkCommand, monkRoute);
										}
										if (num <= 0)
										{
											this.LLog(string.Format("Target: {0} doesn't need monks.", num3), false);
											list2.Add(num3);
										}
										else
										{
											int num4 = this.PrepareAndCountMonks(num, num2);
											if (num4 <= 0 || num4 > 8)
											{
												this.LLog(string.Format("{0} didn't send any {1} to {2} because it had {3} monks.", new object[]
												{
													num2,
													shkMonkCommand,
													num3,
													num4
												}), false);
											}
											else
											{
												this._lastRouteIndex = this.MonkRoutes.IndexOf(monkRoute);
												RemoteServices.Instance.set_SendPeople_UserCallBack(new RemoteServices.SendPeople_UserCallBack(this.sendPeopleCallback));
												RemoteServices.Instance.SendPeople(num2, num3, 4, num4, (int)shkMonkCommand, -1);
												AllVillagesPanel.travellersChanged();
												num -= num4;
												if (monkRoute.StopConditionType == 1)
												{
													Dictionary<int, int> currentProgress = monkRoute.CurrentProgress;
													int key = num3;
													currentProgress[key] += num4;
												}
												this.LLog(string.Format("{0} sent {1} of {2} to {3}. Monks till finish {4}", new object[]
												{
													num2,
													num4,
													shkMonkCommand,
													num3,
													num
												}), false);
												if (base.RandomSleepOrExit(3189, 5196))
												{
													return;
												}
											}
											if (monkRoute.StopConditionType == 0 && num <= 0)
											{
												break;
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600024F RID: 591 RVA: 0x00049748 File Offset: 0x00047948
		public void sendPeopleCallback(SendPeople_ReturnType returnData)
		{
			try
			{
				if (returnData.Success)
				{
					GameEngine.Instance.World.importOrphanedPeople(returnData.people, returnData.currentTime, -2);
					GameEngine.Instance.World.setFaithPointsData(returnData.currentFaithPointsLevel, returnData.currentFaithPointsRate);
				}
				else
				{
					this.LLog(string.Concat(new string[]
					{
						ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID),
						". Source Village ",
						GameEngine.Instance.World.getVillageName(returnData.villageID),
						" Target Village ",
						GameEngine.Instance.World.getVillageName(returnData.targetVillageID),
						" "
					}), true);
					if (returnData.m_errorCode == ErrorCodes.ErrorCode.PEOPLE_INTERDICT_RANK_TOO_HIGH)
					{
						this.LLog(SK.Text("SendMonksPanel_Rank_Too_High", "The Target Village Rank is too high."), true);
					}
					int lastRouteIndex = this._lastRouteIndex;
					if (lastRouteIndex < 0 || lastRouteIndex >= this.MonkRoutes.Count)
					{
						this.LLog(string.Format("Route index: {0}. Stop {1} module.", lastRouteIndex, this.Name), false);
						base.Enabled = false;
					}
					else
					{
						this.LLog(LNG.Print("Disabling route") + ": " + this.MonkRoutes[lastRouteIndex].Name, false);
						this.MonkRoutes[lastRouteIndex].Enabled = false;
						this.UpdateUIonRouteDisable(lastRouteIndex);
					}
				}
			}
			catch (Exception ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.Main);
				ABaseService.ReportError(ex, ControlForm.Tab.Monks);
			}
		}

		// Token: 0x06000250 RID: 592 RVA: 0x000498DC File Offset: 0x00047ADC
		internal bool IsMonkCommandResearched(MonkService.ShkMonkCommand command)
		{
			ResearchData userResearchData = GameEngine.Instance.World.UserResearchData;
			switch (command)
			{
			case MonkService.ShkMonkCommand.Blessing:
				return userResearchData.Research_Marriage > 0;
			case MonkService.ShkMonkCommand.Inquisition:
				return userResearchData.Research_Confirmation > 0;
			case MonkService.ShkMonkCommand.Interdiction:
				return userResearchData.Research_Eucharist > 0 && GameEngine.Instance.LocalWorldData.Alternate_Ruleset != 1;
			case MonkService.ShkMonkCommand.Restoration:
				return userResearchData.Research_Baptism > 0;
			case MonkService.ShkMonkCommand.Absolution:
				return userResearchData.Research_Confession > 0;
			case MonkService.ShkMonkCommand.Excommunication:
				return userResearchData.Research_ExtremeUnction > 0;
			}
			return false;
		}

		// Token: 0x06000251 RID: 593 RVA: 0x00049974 File Offset: 0x00047B74
		private int PrepareAndCountMonks(int monksTillFinish, int villageId)
		{
			this.LLog(string.Format("Preparing monks at {0}, {1} monks required.", villageId, monksTillFinish), false);
			int num = 0;
			GameEngine.Instance.World.countVillagePeople(villageId, 4, ref num);
			num -= this.MonksToKeep;
			if (num < monksTillFinish)
			{
				int numberOfMonks = monksTillFinish - num;
				num += this.MakeMonks(villageId, numberOfMonks, true, ControlForm.Tab.Monks);
				if (base.RandomSleepOrExit(1789, 2785))
				{
					return 0;
				}
			}
			else
			{
				num = monksTillFinish;
			}
			this.LLog(string.Format("Total monks ready {0}, keep {1} in the village.", num, this.MonksToKeep), false);
			return num;
		}

		// Token: 0x06000252 RID: 594 RVA: 0x00049A14 File Offset: 0x00047C14
		internal static MonkRoute OptimizeRoute(MonkRoute route)
		{
			route.SortedRecipients.Clear();
			int squareDistance = route.DistanceLimit * route.DistanceLimit;
			using (IEnumerator<int> enumerator = route.From.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int sender = enumerator.Current;
					IEnumerable<int> source = route.IsDistanceLimited ? (from id in route.To
					where GameEngine.Instance.World.getSquareDistance(sender, id) <= squareDistance
					select id) : route.To.AsEnumerable<int>();
					if (route.Command != 0)
					{
						source = from x in source
						where x != sender
						select x;
					}
					source = from id in source
					orderby GameEngine.Instance.World.getSquareDistance(sender, id)
					select id;
					route.SortedRecipients.Add(sender, source.ToList<int>());
				}
			}
			List<int> from = (from x in route.From
			where route.SortedRecipients[x].Count<int>() > 0
			orderby (from y in route.SortedRecipients[x]
			select GameEngine.Instance.World.getSquareDistance(x, y)).Sum()
			select x).ToList<int>();
			route.From = from;
			return route;
		}

		// Token: 0x06000253 RID: 595 RVA: 0x00049BA0 File Offset: 0x00047DA0
		internal void SaveMonkRoute(MonkRoute route, object[] row, int index = -1)
		{
			if (index == -1)
			{
				this.MonkRoutes.Add(route);
				this._dataGridView_Monks.Rows.Add(row);
				return;
			}
			this.MonkRoutes[index] = route;
			this._dataGridView_Monks.Rows.RemoveAt(index);
			this._dataGridView_Monks.Rows.Insert(index, row);
			this._dataGridView_Monks.ClearSelection();
			this._dataGridView_Monks.Rows[index].Selected = true;
		}

		// Token: 0x06000254 RID: 596 RVA: 0x00049C24 File Offset: 0x00047E24
		private MonkService.ShkMonkCommand MapMonkCommand(int command)
		{
			this.LLog(string.Format("{0} {1}", LNG.Print("Mapping command"), command), false);
			switch (command)
			{
			case 0:
				return MonkService.ShkMonkCommand.Interdiction;
			case 1:
				return MonkService.ShkMonkCommand.Restoration;
			case 2:
				return MonkService.ShkMonkCommand.Blessing;
			case 3:
				return MonkService.ShkMonkCommand.Inquisition;
			case 4:
				return MonkService.ShkMonkCommand.Absolution;
			case 5:
				return MonkService.ShkMonkCommand.Excommunication;
			default:
				throw new Exception(LNG.Print("Invalid monk command"));
			}
		}

		// Token: 0x06000255 RID: 597 RVA: 0x00049C90 File Offset: 0x00047E90
		private int CheckTargetCondition(int targetId, MonkService.ShkMonkCommand command, MonkRoute route)
		{
			double num = 0.0;
			switch (command)
			{
			case MonkService.ShkMonkCommand.Blessing:
			case MonkService.ShkMonkCommand.Inquisition:
			{
				VillageMap loadedVillageWithinParish = GameEngine.Instance.GetLoadedVillageWithinParish(targetId);
				if (loadedVillageWithinParish == null)
				{
					this.LLog(string.Format("{0}: {1}", LNG.Print("Not a single loaded village in parish"), targetId), false);
					return 0;
				}
				int eventType = (command == MonkService.ShkMonkCommand.Blessing) ? 10101 : 10102;
				PopEventData popEventData = loadedVillageWithinParish.m_popEvents.FirstOrDefault((PopEventData e) => e.eventType == eventType);
				int num2 = (popEventData != null) ? popEventData.eventEffect : 0;
				this.LLog(string.Format("{0} level: {1}/{2}", command, num2, route.ExtraParameter), false);
				num = (double)(route.ExtraParameter - num2);
				break;
			}
			case MonkService.ShkMonkCommand.Interdiction:
			{
				this.LLog(string.Format("{0}: {1}", LNG.Print("Checking Interdict time at"), targetId), false);
				WorldMap.VillageRolloverInfo villageRolloverInfo = null;
				WorldMap.CachedUserInfo cachedUserInfo = null;
				GameEngine.Instance.World.retrieveUserData(targetId, -1, ref villageRolloverInfo, ref cachedUserInfo, true, false);
				if (base.RandomSleepOrExit(2189, 3196))
				{
					return 0;
				}
				if (villageRolloverInfo == null)
				{
					VillageData villageData = GameEngine.Instance.World.getVillageData(targetId);
					if (villageData == null || villageData.rolloverInfo == null)
					{
						this.LLog(LNG.Print("Can't get Interdiction time for") + " " + GameEngine.Instance.World.getVillageName(targetId), true);
						break;
					}
					villageRolloverInfo = villageData.rolloverInfo;
				}
				DateTime currentServerTime = VillageMap.getCurrentServerTime();
				num = (double)route.ExtraParameter;
				if (currentServerTime < villageRolloverInfo.interdictionTime)
				{
					TimeSpan timeSpan = villageRolloverInfo.interdictionTime - currentServerTime;
					this.LLog(string.Format("{0} is protected for: {1}. (total hours): {2}", targetId, timeSpan, timeSpan.TotalHours), false);
					num -= timeSpan.TotalHours;
				}
				else
				{
					this.LLog(string.Format("{0} {1}", targetId, LNG.Print("is not Interdicted.")), false);
				}
				this.LLog(string.Format("{0}: {1}", LNG.Print("Need to add hours of Interdict"), num), false);
				break;
			}
			case MonkService.ShkMonkCommand.Restoration:
			{
				this.LLog(string.Format("{0}: {1}", LNG.Print("Checking desease level at"), targetId), false);
				WorldMap.VillageRolloverInfo villageRolloverInfo2 = null;
				WorldMap.CachedUserInfo cachedUserInfo2 = null;
				GameEngine.Instance.World.retrieveUserData(targetId, -1, ref villageRolloverInfo2, ref cachedUserInfo2, true, false);
				if (base.RandomSleepOrExit(1189, 3196))
				{
					return 0;
				}
				num = (double)GameEngine.Instance.World.getParishPlagueLevel(targetId);
				this.LLog(string.Format("{0}: {1}", LNG.Print("Desease level"), num), false);
				num -= (double)route.ExtraParameter;
				break;
			}
			case MonkService.ShkMonkCommand.Absolution:
			{
				DateTime excommunicationTime = GameEngine.Instance.World.getExcommunicationTime(targetId);
				DateTime currentServerTime2 = VillageMap.getCurrentServerTime();
				if (currentServerTime2 < excommunicationTime)
				{
					TimeSpan timeSpan2 = excommunicationTime - currentServerTime2;
					this.LLog(string.Format("{0} is excommunicated for: {1}. (total hours): {2}", targetId, timeSpan2, timeSpan2.TotalHours), false);
					num = timeSpan2.TotalHours - (double)route.ExtraParameter;
					this.LLog(string.Format("{0}: {1}", LNG.Print("Hours of excomm to remove"), num), false);
				}
				double num3 = (excommunicationTime - VillageMap.getCurrentServerTime()).TotalHours - (double)route.ExtraParameter;
				this.LLog(string.Format("{0} 2: {1}", LNG.Print("Hours of excomm to remove"), num3), false);
				break;
			}
			}
			if (num <= 0.0)
			{
				return 0;
			}
			return this.TotalMonksToComplete(num, command, targetId);
		}

		// Token: 0x06000256 RID: 598 RVA: 0x0004A050 File Offset: 0x00048250
		private int TotalMonksToQuestComplete(MonkService.ShkMonkCommand command)
		{
			NewQuestsData newQuestData = GameEngine.Instance.World.getNewQuestData();
			if (newQuestData == null)
			{
				this.LLog(LNG.Print("Quests information missing!"), false);
				return 0;
			}
			NewQuests.NewQuestDefinition newQuestDef = NewQuests.getNewQuestDef(newQuestData.questID);
			if (newQuestDef == null)
			{
				this.LLog(LNG.Print("No active quest!"), false);
				return 0;
			}
			int questType = newQuestDef.questType;
			bool flag = false;
			switch (command)
			{
			case MonkService.ShkMonkCommand.Blessing:
				if (questType != 0)
				{
					flag = true;
				}
				break;
			case MonkService.ShkMonkCommand.Inquisition:
				if (questType != 33)
				{
					flag = true;
				}
				break;
			case MonkService.ShkMonkCommand.Interdiction:
				if (questType != 42)
				{
					flag = true;
				}
				break;
			case MonkService.ShkMonkCommand.Restoration:
				if (questType != 15)
				{
					flag = true;
				}
				break;
			case MonkService.ShkMonkCommand.Absolution:
				if (questType != 43)
				{
					flag = true;
				}
				break;
			case MonkService.ShkMonkCommand.Excommunication:
				if (questType != 44)
				{
					flag = true;
				}
				break;
			}
			if (flag)
			{
				this.LLog(LNG.Print("Wrong active quest!"), false);
				return 0;
			}
			double num = (double)(newQuestDef.parameter - newQuestData.data);
			if (num <= 0.0)
			{
				return 0;
			}
			this.LLog(string.Format("{0}: {1}/{2}", LNG.Print("Quest progress"), newQuestData.data, newQuestDef.parameter), false);
			return this.TotalMonksToComplete(num, command, -1);
		}

		// Token: 0x06000257 RID: 599 RVA: 0x0004A178 File Offset: 0x00048378
		private int TotalMonksToComplete(double total, MonkService.ShkMonkCommand shkcommand, int targetId)
		{
			double num = 1.0;
			switch (shkcommand)
			{
			case MonkService.ShkMonkCommand.Interdiction:
				num = (double)CardTypes.adjustInterdictionLevel(GameEngine.Instance.cardsManager.UserCardData, 4);
				break;
			case MonkService.ShkMonkCommand.Restoration:
			{
				int num2 = (int)GameEngine.Instance.World.UserResearchData.Research_Baptism;
				if (num2 < 1)
				{
					num2 = 1;
				}
				int currentLevel = ResearchData.baptismRestoreAmount[num2];
				num = (double)CardTypes.adjustRestorationLevel(GameEngine.Instance.cardsManager.UserCardData, currentLevel);
				break;
			}
			case MonkService.ShkMonkCommand.Absolution:
			{
				int num3 = (int)GameEngine.Instance.World.UserResearchData.Research_Confession;
				if (num3 < 1)
				{
					num3 = 1;
				}
				double currentLevel2 = (double)ResearchData.confessionTimes[num3];
				num = CardTypes.adjustAbsolutionLevel(GameEngine.Instance.cardsManager.UserCardData, currentLevel2);
				break;
			}
			case MonkService.ShkMonkCommand.Excommunication:
			{
				int num4 = (int)GameEngine.Instance.World.UserResearchData.Research_ExtremeUnction;
				if (num4 < 1)
				{
					num4 = 1;
				}
				double currentLevel3 = (double)ResearchData.extremeUnctionTimes[num4];
				num = CardTypes.adjustExcommunicationLevel(GameEngine.Instance.cardsManager.UserCardData, currentLevel3);
				break;
			}
			}
			double num5 = (double)GameEngine.Instance.World.countCommandMonksSent((int)shkcommand, targetId);
			num5 *= num;
			total -= num5;
			bool flag = total % num != 0.0;
			total /= num;
			if (flag)
			{
				total += 1.0;
			}
			this.LLog(string.Format("Research efficiency: {0}. Monks till finish: {1}.", num, (int)total), false);
			return (int)total;
		}

		// Token: 0x06000258 RID: 600 RVA: 0x0004A2F0 File Offset: 0x000484F0
		internal void RemoveVillages(int villageId)
		{
			for (int i = 0; i < this.MonkRoutes.Count; i++)
			{
				bool flag = false;
				MonkRoute monkRoute = this.MonkRoutes[i];
				if (monkRoute.From.Contains(villageId))
				{
					monkRoute.From = monkRoute.From.Where((int x) => x != villageId);
					flag = true;
				}
				if (monkRoute.To.Contains(villageId))
				{
					monkRoute.To = monkRoute.To.Where((int x) => x != villageId);
					flag = true;
				}
				if (flag)
				{
					MonkService.OptimizeRoute(monkRoute);
				}
			}
		}

		// Token: 0x06000259 RID: 601 RVA: 0x0004A3D0 File Offset: 0x000485D0
		internal void Save()
		{
			try
			{
				string settingsFilePath = SettingsManager.GetSettingsFilePath("MonkRoutes.txt", true, new string[]
				{
					this.Name
				});
				List<string> list = new List<string>();
				foreach (MonkRoute monkRoute in this.MonkRoutes)
				{
					string item = string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8}", new object[]
					{
						monkRoute.Name,
						monkRoute.Enabled,
						DX.GetStringOfIds(monkRoute.From),
						DX.GetStringOfIds(monkRoute.To),
						monkRoute.Command,
						monkRoute.StopConditionType,
						monkRoute.ExtraParameter,
						monkRoute.IsDistanceLimited,
						monkRoute.DistanceLimit
					});
					list.Add(item);
				}
				File.WriteAllLines(settingsFilePath, list.ToArray());
				this.LLog(LNG.Print("Settings saved to") + ": " + settingsFilePath, false);
			}
			catch (Exception ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.Monks);
			}
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0004A534 File Offset: 0x00048734
		internal void Load()
		{
			try
			{
				string settingsFilePath = SettingsManager.GetSettingsFilePath("MonkRoutes.txt", false, new string[]
				{
					this.Name
				});
				if (!File.Exists(settingsFilePath))
				{
					this.LLog(LNG.Print("File doesn't exist") + ": " + settingsFilePath, false);
				}
				else
				{
					string[] array = File.ReadAllLines(settingsFilePath);
					this.MonkRoutes.Clear();
					this._dataGridView_Monks.Rows.Clear();
					string[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						string text = array2[i];
						string[] array3 = text.Split(new char[]
						{
							';'
						});
						string text2 = array3[0];
						bool flag = array3[1] == "True";
						List<int> ownVillages = GameEngine.Instance.World.getListOfUserVillages();
						List<int> list = new List<int>();
						if (string.IsNullOrEmpty(array3[2]))
						{
							this.LLog("WARNING! Route \"" + text2 + "\": List of senders is empty", false);
						}
						else
						{
							list = DX.GetListOfIds(array3[2]);
							list = (from x in list
							where ownVillages.Contains(x)
							select x).ToList<int>();
							if (list.Count == 0)
							{
								this.LLog("WARNING! Route \"" + text2 + "\": List of senders is empty after validation.", false);
							}
						}
						List<int> list2 = new List<int>();
						if (string.IsNullOrEmpty(array3[3]))
						{
							this.LLog("WARNING! Route \"" + text2 + "\": List of targets is empty", false);
						}
						else
						{
							list2 = DX.GetListOfIds(array3[3]);
							list2.RemoveAll((int x) => !GameEngine.Instance.World.isRegionCapital(x) && !GameEngine.Instance.World.IsPlayerVillage(x));
							if (list2.Count == 0)
							{
								this.LLog("WARNING! Route \"" + text2 + "\": List of targets is empty after validation.", false);
							}
						}
						int num = int.Parse(array3[4]);
						int num2 = int.Parse(array3[5]);
						if (num2 < 0 || num2 >= MonkService.StopConditions.Length)
						{
							num2 = 0;
						}
						int num3 = int.Parse(array3[6]);
						bool flag2 = bool.Parse(array3[7]);
						int num4 = int.Parse(array3[8]);
						Dictionary<int, int> dictionary = new Dictionary<int, int>();
						foreach (int key in list2)
						{
							dictionary.Add(key, 0);
						}
						this.MonkRoutes.Add(MonkService.OptimizeRoute(new MonkRoute(text2, flag, list, list2, num, num2, num3, dictionary, flag2, num4)));
						DataGridViewRowCollection rows = this._dataGridView_Monks.Rows;
						object[] array4 = new object[9];
						array4[0] = text2;
						array4[1] = flag;
						array4[2] = string.Join(",", (from id in list
						select GameEngine.Instance.World.getVillageName(id)).ToArray<string>());
						array4[3] = string.Join(",", (from id in list2
						select GameEngine.Instance.World.getVillageName(id)).ToArray<string>());
						array4[4] = (Command)num;
						array4[5] = MonkService.StopConditions[num2];
						array4[6] = num3;
						array4[7] = flag2;
						array4[8] = num4;
						rows.Add(array4);
					}
					this.LLog(LNG.Print("Monk Routes Loaded"), false);
				}
			}
			catch (Exception ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.Monks);
			}
		}

		// Token: 0x0600025B RID: 603 RVA: 0x0004A8CC File Offset: 0x00048ACC
		internal override void TranslateUI()
		{
			MonkService.StopConditions = new string[3];
			MonkService.StopConditions[0] = LNG.Print("Stop on quest completition");
			MonkService.StopConditions[1] = LNG.Print("Send X monks to EACH target");
			MonkService.StopConditions[2] = LNG.Print("Run on condition");
			MonkService.StopConditionsDescription = new string[5];
			MonkService.StopConditionsDescription[0] = LNG.Print("Support minimum of X hours of Interdict on each target. If target village has less than X hours of Interdict, the Bot will send monks to it.");
			MonkService.StopConditionsDescription[1] = LNG.Print("Heal parish if it has over X points of desease. Leave at 0 to have all parishes healed completely");
			MonkService.StopConditionsDescription[2] = LNG.Print("Support X level of Blessing on each parish. You require to have at least 1 village in that parish. That village must be loaded. Maximum is 100.");
			MonkService.StopConditionsDescription[3] = LNG.Print("Support X level of Inquisition on each parish.You require to have at least 1 village in that parish.That village must be loaded.Maximum is 100.");
			MonkService.StopConditionsDescription[4] = LNG.Print("Remove excommunication if more than X hours. Leave at 0 to remove all excommunication. Only works with own villages.");
		}

		// Token: 0x040003CC RID: 972
		private DataGridView _dataGridView_Monks;

		// Token: 0x040003CD RID: 973
		internal List<MonkRoute> MonkRoutes = new List<MonkRoute>();

		// Token: 0x040003CE RID: 974
		private const string MonkRoutesFileName = "MonkRoutes.txt";

		// Token: 0x040003CF RID: 975
		internal int MonksToKeep = 1;

		// Token: 0x040003D0 RID: 976
		private MakeMonksDelegate MakeMonks;

		// Token: 0x040003D1 RID: 977
		private int _lastRouteIndex = -1;

		// Token: 0x040003D2 RID: 978
		internal static string[] StopConditions;

		// Token: 0x040003D3 RID: 979
		internal static string[] StopConditionsDescription;

		// Token: 0x02000042 RID: 66
		internal enum ShkMonkCommand
		{
			// Token: 0x040003D5 RID: 981
			Blessing = 1,
			// Token: 0x040003D6 RID: 982
			Inquisition = 3,
			// Token: 0x040003D7 RID: 983
			Interdiction,
			// Token: 0x040003D8 RID: 984
			Restoration,
			// Token: 0x040003D9 RID: 985
			Absolution,
			// Token: 0x040003DA RID: 986
			Excommunication
		}
	}
}
