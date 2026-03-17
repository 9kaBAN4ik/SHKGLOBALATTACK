using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;
using Kingdoms;

namespace Upgrade.Services
{
	// Token: 0x0200008C RID: 140
	internal class ScoutingService : ABaseService
	{
		// Token: 0x060003B3 RID: 947 RVA: 0x000548E8 File Offset: 0x00052AE8
		public ScoutingService(Log log, ListBox listBox_ScoutFrom, ListBox listBox_ScoutingTypes, ListBox listBox_ScoutingTypes_Ignore, CheckBox sendOneScout) : base(log)
		{
			this._listBox_ScoutFrom = listBox_ScoutFrom;
			this._listBox_ScoutingTypes = listBox_ScoutingTypes;
			this._listBox_ScoutingTypes_Ignore = listBox_ScoutingTypes_Ignore;
			this._sendOneScout = sendOneScout;
			this._listBox_ScoutingTypes.MouseDown += this.listBox_MouseDown;
			this._listBox_ScoutingTypes.MouseMove += this.listBox_MouseMove;
			this._listBox_ScoutingTypes.MouseUp += this.listBox1_MouseUp;
			this._listBox_ScoutingTypes_Ignore.MouseDown += this.listBox_MouseDown;
			this._listBox_ScoutingTypes_Ignore.MouseMove += this.listBox_MouseMove;
			this._listBox_ScoutingTypes_Ignore.MouseUp += this.listBox2_MouseUp;
			this.ResForScouting = new Dictionary<int, List<int>>();
			this.ResForScoutingIgnore = new Dictionary<int, List<int>>();
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x00007CE0 File Offset: 0x00005EE0
		internal override void TranslateUI()
		{
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x00009D2C File Offset: 0x00007F2C
		private void LLog(string message, bool isError = false)
		{
			this.Log(message, ControlForm.Tab.Scout, isError);
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x000549F4 File Offset: 0x00052BF4
		internal void CopySettings(IEnumerable<string> listOfVillages, int id, bool saveSettings)
		{
			if (this.ResForScouting.ContainsKey(id) && this.ResForScoutingIgnore.ContainsKey(id))
			{
				bool flag = this.SelectedVillages.Contains(id);
				foreach (string text in listOfVillages)
				{
					int id2 = ControlForm.GetId(text);
					if (id2 != id)
					{
						if (this.ResForScouting.ContainsKey(id2))
						{
							this.ResForScouting[id2] = new List<int>(this.ResForScouting[id]);
						}
						if (this.ResForScoutingIgnore.ContainsKey(id2))
						{
							this.ResForScoutingIgnore[id2] = new List<int>(this.ResForScoutingIgnore[id]);
						}
						if (flag)
						{
							this.SelectedVillages.Add(id2);
						}
						int num = this._listBox_ScoutFrom.Items.IndexOf(text);
						if (num != -1)
						{
							this._listBox_ScoutFrom.SetSelected(num, flag);
						}
					}
				}
				if (saveSettings)
				{
					this.SaveSettings(false);
				}
			}
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x00054B10 File Offset: 0x00052D10
		private void listBox_MouseDown(object sender, MouseEventArgs e)
		{
			if (this.SelectedScoutingVillageId == -1)
			{
				this.LLog(LNG.Print("Village is not selected"), false);
				return;
			}
			ListBox listBox = sender as ListBox;
			int num = listBox.IndexFromPoint(e.Location);
			if (num == -1)
			{
				return;
			}
			this.bufferIndex = num;
			this.bufferItem = listBox.Items[num];
			this.indexChanged = false;
			if (listBox == this._listBox_ScoutingTypes)
			{
				this.bufferType = this.ResForScouting[this.SelectedScoutingVillageId][num];
				return;
			}
			if (listBox == this._listBox_ScoutingTypes_Ignore)
			{
				this.bufferType = this.ResForScoutingIgnore[this.SelectedScoutingVillageId][num];
			}
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x00054BC0 File Offset: 0x00052DC0
		private void listBox_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left)
			{
				return;
			}
			ListBox listBox = sender as ListBox;
			int num = listBox.IndexFromPoint(e.Location);
			if (num == this.bufferIndex || num == -1 || this.bufferIndex == -1)
			{
				return;
			}
			listBox.Items.RemoveAt(this.bufferIndex);
			this.bufferIndex = num;
			this.indexChanged = true;
			listBox.Items.Insert(num, this.bufferItem);
			if (listBox == this._listBox_ScoutingTypes)
			{
				this.ResForScouting[this.SelectedScoutingVillageId].Remove(this.bufferType);
				this.ResForScouting[this.SelectedScoutingVillageId].Insert(num, this.bufferType);
				return;
			}
			if (listBox == this._listBox_ScoutingTypes_Ignore)
			{
				this.ResForScoutingIgnore[this.SelectedScoutingVillageId].Remove(this.bufferType);
				this.ResForScoutingIgnore[this.SelectedScoutingVillageId].Insert(num, this.bufferType);
			}
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x00054CC0 File Offset: 0x00052EC0
		private void listBox1_MouseUp(object sender, MouseEventArgs e)
		{
			if (this.SelectedScoutingVillageId == -1)
			{
				return;
			}
			if (this.bufferItem == null || this.indexChanged)
			{
				return;
			}
			Point p = new Point(e.X - (this._listBox_ScoutingTypes_Ignore.Location.X - this._listBox_ScoutingTypes.Location.X), e.Y - (this._listBox_ScoutingTypes_Ignore.Location.Y - this._listBox_ScoutingTypes.Location.Y));
			int num = this._listBox_ScoutingTypes_Ignore.IndexFromPoint(p);
			if (num == -1)
			{
				num = this._listBox_ScoutingTypes_Ignore.Items.Count;
			}
			this._listBox_ScoutingTypes_Ignore.Items.Insert(num, this.bufferItem);
			this.ResForScoutingIgnore[this.SelectedScoutingVillageId].Insert(num, this.bufferType);
			this._listBox_ScoutingTypes_Ignore.SetSelected(num, true);
			this._listBox_ScoutingTypes.Items.Remove(this.bufferItem);
			this.ResForScouting[this.SelectedScoutingVillageId].Remove(this.bufferType);
			this._listBox_ScoutingTypes.ClearSelected();
			this.bufferType = 0;
			this.bufferItem = null;
			this.bufferIndex = -1;
		}

		// Token: 0x060003BA RID: 954 RVA: 0x00054E04 File Offset: 0x00053004
		private void listBox2_MouseUp(object sender, MouseEventArgs e)
		{
			if (this.bufferItem == null || this.indexChanged)
			{
				return;
			}
			Point p = new Point(e.X + (this._listBox_ScoutingTypes_Ignore.Location.X - this._listBox_ScoutingTypes.Location.X), e.Y + (this._listBox_ScoutingTypes_Ignore.Location.Y - this._listBox_ScoutingTypes.Location.Y));
			int num = this._listBox_ScoutingTypes.IndexFromPoint(p);
			if (num == -1)
			{
				num = this._listBox_ScoutingTypes.Items.Count;
			}
			this._listBox_ScoutingTypes.Items.Insert(num, this.bufferItem);
			this._listBox_ScoutingTypes.SetSelected(num, true);
			this.ResForScouting[this.SelectedScoutingVillageId].Insert(num, this.bufferType);
			this._listBox_ScoutingTypes_Ignore.Items.Remove(this.bufferItem);
			this._listBox_ScoutingTypes_Ignore.ClearSelected();
			this.ResForScoutingIgnore[this.SelectedScoutingVillageId].Remove(this.bufferType);
			this.bufferType = 0;
			this.bufferItem = null;
			this.bufferIndex = -1;
		}

		// Token: 0x060003BB RID: 955 RVA: 0x00054F3C File Offset: 0x0005313C
		public void LoadSettings(ListBox listBox_scoutFrom, NumericUpDown radius, bool customLocation)
		{
			string text = SettingsManager.GetSettingsFilePath("Scouting.txt", true, new string[]
			{
				this.Name
			});
			if (customLocation)
			{
				OpenFileDialog openFileDialog = new OpenFileDialog
				{
					Filter = "TXT files (*.txt)|*.txt|All files (*.*)|*.*",
					FileName = "Scouting.txt",
					InitialDirectory = Path.GetDirectoryName(text)
				};
				if (openFileDialog.ShowDialog() != DialogResult.OK)
				{
					this.LLog(LNG.Print("Loading cancelled"), false);
					return;
				}
				text = openFileDialog.FileName;
			}
			else if (!File.Exists(text))
			{
				this.LLog(LNG.Print("File doesn't exist") + ": " + text, false);
				return;
			}
			string[] array = File.ReadAllLines(text);
			foreach (string text2 in array)
			{
				string[] array3 = text2.Split(new char[]
				{
					';'
				});
				int num = Convert.ToInt32(array3[0]);
				if (!this.ResForScouting.ContainsKey(num))
				{
					this.LLog(string.Format("{0} {1}", LNG.Print("Could not load scouting setting for village"), num), false);
				}
				else
				{
					this.ResForScouting[num].Clear();
					if (!string.IsNullOrEmpty(array3[1]))
					{
						this.ResForScouting[num].AddRange(from type in DX.GetListOfIds(array3[1])
						where type >= 100 & type < 134
						select type);
					}
					this.ResForScoutingIgnore[num].Clear();
					if (!string.IsNullOrEmpty(array3[2]))
					{
						this.ResForScoutingIgnore[num].AddRange(DX.GetListOfIds(array3[2]));
					}
					bool flag = array3[3] == "1";
					if (flag)
					{
						this.SelectedVillages.Add(num);
					}
					else
					{
						this.SelectedVillages.Remove(num);
					}
					int num2 = -1;
					foreach (object obj in listBox_scoutFrom.Items)
					{
						if (obj.ToString().StartsWith(string.Format("[{0}]", num)))
						{
							num2 = listBox_scoutFrom.Items.IndexOf(obj);
						}
					}
					if (num2 == -1)
					{
						this.LLog(string.Format("{0} {1}", LNG.Print("Couldn't select village in scouting villages listbox. Village Id:"), num), false);
					}
					else
					{
						listBox_scoutFrom.SetSelected(num2, flag);
					}
				}
			}
			text = SettingsManager.GetSettingsFilePath("ScoutsTime.txt", false, new string[0]);
			if (File.Exists(text))
			{
				int value;
				if (int.TryParse(File.ReadAllText(text), out value))
				{
					radius.Value = value;
				}
			}
			else
			{
				text = SettingsManager.GetSettingsFilePath("ScoutsRadius.txt", false, new string[0]);
				int num3;
				if (File.Exists(text) && int.TryParse(File.ReadAllText(text), out num3))
				{
					radius.Value = (int)ScoutingService.ConvertScoutsDistanceToTime((double)num3);
				}
			}
			text = SettingsManager.GetSettingsFilePath("ScoutsSendByOne.txt", false, new string[0]);
			if (!File.Exists(text))
			{
				File.WriteAllText(text, this.SendOneScout.ToString());
				return;
			}
			bool @checked;
			if (bool.TryParse(File.ReadAllText(text), out @checked))
			{
				this._sendOneScout.Checked = @checked;
			}
		}

		// Token: 0x060003BC RID: 956 RVA: 0x00055284 File Offset: 0x00053484
		public void SaveSettings(bool customLocation)
		{
			List<string> list = new List<string>();
			foreach (KeyValuePair<int, List<int>> keyValuePair in this.ResForScouting)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(keyValuePair.Key);
				stringBuilder.Append(';');
				stringBuilder.Append(DX.GetStringOfIds(keyValuePair.Value));
				stringBuilder.Append(';');
				stringBuilder.Append(DX.GetStringOfIds(this.ResForScoutingIgnore[keyValuePair.Key]));
				stringBuilder.Append(';');
				stringBuilder.Append(this.SelectedVillages.Contains(keyValuePair.Key) ? '1' : '0');
				list.Add(stringBuilder.ToString());
			}
			string path = SettingsManager.GetSettingsFilePath("Scouting.txt", true, new string[]
			{
				this.Name
			});
			if (customLocation)
			{
				SaveFileDialog saveFileDialog = new SaveFileDialog
				{
					Filter = "TXT files (*.txt)|*.txt|All files (*.*)|*.*",
					FileName = "Scouting.txt",
					InitialDirectory = Path.GetDirectoryName(path)
				};
				if (saveFileDialog.ShowDialog() != DialogResult.OK)
				{
					this.LLog(LNG.Print("Saving cancelled"), false);
					return;
				}
				path = saveFileDialog.FileName;
			}
			File.WriteAllLines(path, list.ToArray());
			path = SettingsManager.GetSettingsFilePath("ScoutsTime.txt", true, new string[0]);
			File.WriteAllText(path, this.ScoutsMaxTime.ToString());
			path = SettingsManager.GetSettingsFilePath("ScoutsSendByOne.txt", true, new string[0]);
			File.WriteAllText(path, this.SendOneScout.ToString());
		}

		// Token: 0x060003BD RID: 957 RVA: 0x00055434 File Offset: 0x00053634
		private void CheckIfMaxScouts(VillageMap map)
		{
			byte research_Scouts = GameEngine.Instance.World.UserResearchData.Research_Scouts;
			try
			{
				int num = map.calcTotalScouts() + map.LocallyMade_Scouts;
				if (num != (int)research_Scouts)
				{
					int num2 = (int)research_Scouts - num;
					if (num2 > 0)
					{
						this.LLog(string.Format("{0} {1} {2}", GameEngine.Instance.World.getVillageName(map.VillageID), LNG.Print("needs to hire scout(s):"), num2), false);
						int spareWorkers = map.m_spareWorkers;
						if (num2 > spareWorkers)
						{
							this.LLog(string.Format("{0} {1}", spareWorkers, LNG.Print("recruits in the village")), false);
							num2 = spareWorkers;
						}
						int num3 = map.calcUnitUsages() + map.LocallyMade_Scouts * GameEngine.Instance.LocalWorldData.UnitSize_Scout;
						int num4 = GameEngine.Instance.LocalWorldData.Village_UnitCapacity - num3;
						int unitSize_Scout = GameEngine.Instance.LocalWorldData.UnitSize_Scout;
						if (num4 < num2 * unitSize_Scout)
						{
							this.LLog(string.Format("{0} {1}", num4, LNG.Print("unit space in the village")), false);
							num2 = num4 / unitSize_Scout;
						}
						int num5 = (int)GameEngine.Instance.World.getCurrentGold();
						int scoutGoldCost = GameEngine.Instance.LocalWorldData.ScoutGoldCost;
						if (num5 < num2 * scoutGoldCost)
						{
							num2 = num5 / scoutGoldCost;
							this.LLog(string.Format("{0} {1}", LNG.Print("Gold limits us to scout(s):"), num2), false);
						}
						if (num2 <= 0)
						{
							this.LLog(LNG.Print("Can't make any scouts. Please provide gold/recruits/space."), false);
						}
						else
						{
							num2 = Math.Min(num2, 4);
							this.LLog(string.Format("{0} {1}", LNG.Print("Making scout(s):"), num2), false);
							map.makeTroops(76, num2, false);
						}
					}
				}
			}
			catch (InvalidOperationException)
			{
			}
			catch (Exception ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.Scout);
			}
		}

		// Token: 0x060003BE RID: 958 RVA: 0x00055634 File Offset: 0x00053834
		private static int ScoutsCapacity(int special)
		{
			byte research_Foraging = GameEngine.Instance.World.UserResearchData.Research_Foraging;
			int num = GameEngine.Instance.LocalWorldData.ScoutResourceCarryLevel;
			num = CardTypes.adjustForagingLevel(GameEngine.Instance.cardsManager.UserCardData, num) * ResearchData.foragingResearch[(int)research_Foraging] / 2;
			switch (special)
			{
			case 119:
			case 121:
			case 122:
			case 123:
			case 124:
			case 125:
			case 126:
			case 128:
			case 129:
			case 130:
			case 131:
			case 132:
			case 133:
				num /= 10;
				break;
			}
			return num;
		}

		// Token: 0x060003BF RID: 959 RVA: 0x000556D4 File Offset: 0x000538D4
		private static double CalcMovingScouts(int villageId, int targetId, int typeId, string villageName, out int alreadyGoingScouts)
		{
			int num = 0;
			double num2 = 0.0;
			alreadyGoingScouts = 0;
			do
			{
				try
				{
					SparseArray armyArray = GameEngine.Instance.World.getArmyArray();
					foreach (object obj in armyArray)
					{
						WorldMap.LocalArmyData localArmyData = (WorldMap.LocalArmyData)obj;
						if (localArmyData.numScouts != 0)
						{
							if (localArmyData.lootType >= 0)
							{
								if (localArmyData.homeVillageID == villageId && localArmyData.lootType == typeId && localArmyData.lootLevel > 0.0)
								{
									num2 += localArmyData.lootLevel;
								}
							}
							else if (localArmyData.targetVillageID == targetId && GameEngine.Instance.World.isUserVillage(localArmyData.travelFromVillageID))
							{
								alreadyGoingScouts += localArmyData.numScouts;
							}
						}
					}
					break;
				}
				catch (InvalidOperationException)
				{
					num++;
				}
			}
			while (num < 5);
			string typeName = ScoutingService.GetTypeName(targetId);
			if (num2 > 0.0)
			{
				DX.ControlForm.Log(string.Format("{0} {1} {2} {3}.", new object[]
				{
					villageName,
					LNG.Print("already foraged"),
					num2,
					typeName
				}), ControlForm.Tab.Scout, false);
			}
			if (alreadyGoingScouts > 0)
			{
				DX.ControlForm.Log(string.Format("{0} {1} {2}({3}).", new object[]
				{
					alreadyGoingScouts,
					LNG.Print("scouts already going to"),
					typeName,
					targetId
				}), ControlForm.Tab.Scout, false);
			}
			return num2;
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x00055878 File Offset: 0x00053A78
		public override void ConcreteAction()
		{
			if ((DateTime.Now - DX.ControlForm.LastWorldMapUpdate).TotalSeconds >= 35.0)
			{
				this.LLog(LNG.Print("Please open the world map for update!"), true);
				return;
			}
			Stopwatch stopwatch = Stopwatch.StartNew();
			this.CalcelScouts(stopwatch);
			List<int> list = new List<int>(this.SelectedVillages);
			foreach (int num in list.Shuffle<int>())
			{
				if (this.SelectedVillages.Contains(num))
				{
					string villageName = GameEngine.Instance.World.getVillageName(num);
					if (InterfaceMgr.Instance.isScoutPopup() && InterfaceMgr.Instance.OwnSelectedVillage == num)
					{
						this.LLog(villageName + " " + LNG.Print("village skipped because Send Scouts window is open"), false);
					}
					else
					{
						VillageMap village = GameEngine.Instance.getVillage(num);
						if (village == null)
						{
							this.LLog(LNG.Print("Village wasn't loaded:") + " " + villageName, true);
							if (base.RandomSleepOrExit(2000, 3000))
							{
								return;
							}
						}
						else
						{
							if (this.HireScouts)
							{
								this.CheckIfMaxScouts(village);
							}
							if (village.m_numScouts > 0 && village.m_numScouts <= (int)GameEngine.Instance.World.userResearchData.Research_Scouts)
							{
								if (!this.ResForScouting.ContainsKey(num))
								{
									this.LLog(LNG.Print("Settings not found for village") + ": " + villageName, true);
								}
								else
								{
									List<int> foragingList = new List<int>(this.ResForScouting[num]);
									List<StashDistance> stashesInRange = this.GetStashesInRange(num, foragingList);
									if (this.IgnoreType)
									{
										stashesInRange.Sort(this.ComparerByDistance);
									}
									else
									{
										stashesInRange.Sort(delegate(StashDistance x, StashDistance y)
										{
											if (x.TypeIndex < y.TypeIndex)
											{
												return -1;
											}
											if (x.TypeIndex > y.TypeIndex)
											{
												return 1;
											}
											if (x.Distance < y.Distance)
											{
												return -1;
											}
											if (x.Distance > y.Distance)
											{
												return 1;
											}
											return 0;
										});
									}
									this.ProcessStashList(stashesInRange, village, villageName, stopwatch);
									stopwatch.Stop();
									if (base.RandomSleepOrExit(1500, 2500))
									{
										return;
									}
									stopwatch.Start();
								}
							}
						}
					}
				}
			}
			this.LLog(LNG.Print("Scouting cicle is over.") ?? "", false);
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x00055AE0 File Offset: 0x00053CE0
		private void ProcessStashList(List<StashDistance> list, VillageMap village, string villageName, Stopwatch sw)
		{
			foreach (StashDistance stashDistance in list)
			{
				int id = stashDistance.Id;
				int special = stashDistance.Special;
				string text;
				int num;
				if (special != 100)
				{
					bool flag;
					WorldMap.SpecialVillageCache specialVillageData = GameEngine.Instance.World.GetSpecialVillageData(id, out flag);
					text = VillageBuildingsData.getResourceNames(special - 100);
					if (flag)
					{
						this.LLog(string.Format("{0}: {1} {2}", LNG.Print("Retrieve stash size from server"), id, text), false);
						sw.Stop();
						if (base.RandomSleepOrExit(1500, 2500))
						{
							break;
						}
						sw.Start();
						bool flag2;
						specialVillageData = GameEngine.Instance.World.GetSpecialVillageData(id, out flag2);
					}
					if (specialVillageData == null)
					{
						this.LLog(string.Format("{0}: {1} {2}", LNG.Print("Stash size not retrieved from server"), id, text), true);
						continue;
					}
					num = ScoutingService.CalculateNumScouts(village, villageName, id, special, specialVillageData.resourceLevel, this.WaitForFreeSpace);
					if (num <= 0)
					{
						continue;
					}
					if (num > village.m_numScouts && village.m_numScouts < this.MinimumScouts)
					{
						this.LLog(string.Format("Not enough scouts: {0}/{1}", village.m_numScouts, num), false);
						break;
					}
					num = Math.Min(num, village.m_numScouts);
					if (this.SendOneScout)
					{
						for (int i = 0; i < num; i++)
						{
							if (this.DispatchScouts(village, villageName, id, text, 1, sw))
							{
								return;
							}
						}
						this.LLog("Finished sending scouts by one", false);
						continue;
					}
				}
				else
				{
					text = SpecialVillageTypes.getName(special, Program.mySettings.LanguageIdent);
					num = ASubscribed._random.Next(1, Math.Min(village.m_numScouts, this.MinimumScouts));
					this.LLog(string.Format("Random {0} for new stash", num), false);
				}
				if (this.DispatchScouts(village, villageName, id, text, num, sw))
				{
					break;
				}
				if (village.m_numScouts <= 0)
				{
					break;
				}
			}
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x00055D0C File Offset: 0x00053F0C
		private bool IsFirstToStash(int targetId, double ourDistance)
		{
			int num = 0;
			do
			{
				try
				{
					SparseArray armyArray = GameEngine.Instance.World.getArmyArray();
					foreach (object obj in armyArray)
					{
						WorldMap.LocalArmyData localArmyData = (WorldMap.LocalArmyData)obj;
						if (localArmyData.targetVillageID == targetId && localArmyData.numScouts > 0 && localArmyData.lootType < 0)
						{
							double num2 = DXTimer.GetCurrentMilliseconds() / 1000.0;
							double num3 = localArmyData.localEndTime - num2;
							if (num3 < ourDistance)
							{
								return false;
							}
						}
					}
					return true;
				}
				catch (InvalidOperationException)
				{
					this.LLog(LNG.Print("Armies array changed. Scanning again."), false);
					num++;
				}
			}
			while (num < 5);
			return false;
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x00055DE4 File Offset: 0x00053FE4
		private bool DispatchScouts(VillageMap map, string villageName, int targetId, string typeName, int numScouts, Stopwatch sw)
		{
			int special = GameEngine.Instance.World.getSpecial(targetId);
			if (special < 100 || special > 133)
			{
				this.LLog(string.Format("{0}: [{1}] ({2}) {3}", new object[]
				{
					LNG.Print("Target is no longer a stash that can be foraged"),
					targetId,
					special,
					GameEngine.Instance.World.getVillageNameOrType(targetId)
				}), false);
				return false;
			}
			this.DelayBetweenFarAwayStashes(targetId, sw);
			RemoteServices.Instance.set_SendScouts_UserCallBack(new RemoteServices.SendScouts_UserCallBack(this.SendScoutsCallback));
			RemoteServices.Instance.SendScouts(map.VillageID, targetId, numScouts);
			this.LLog(string.Format("{0} {1} {2} {3} => {4} ({5})", new object[]
			{
				villageName,
				LNG.Print("sent"),
				numScouts,
				SK.Text("AllArmiesPanel_Scouts", "Scouts"),
				targetId,
				typeName
			}), false);
			map.addTroops(0, 0, 0, 0, 0, -numScouts);
			AllVillagesPanel.travellersChanged();
			sw.Stop();
			if (base.RandomSleepOrExit(3000, 4200))
			{
				return true;
			}
			sw.Start();
			return false;
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x00055F14 File Offset: 0x00054114
		private static int CalculateNumScouts(VillageMap village, string villageName, int targetId, int type, int stashRes, bool waitFreeSpace)
		{
			int num = ScoutingService.ScoutsCapacity(type);
			int num3;
			int num2 = (int)ScoutingService.CalcMovingScouts(village.VillageID, targetId, type, villageName, out num3);
			stashRes -= num3 * num;
			if (stashRes <= 0)
			{
				return 0;
			}
			int num4;
			if (!waitFreeSpace)
			{
				num4 = stashRes / num;
				if (stashRes % num > 0)
				{
					num4++;
				}
				return num4;
			}
			int num5 = (int)village.getResourceLevel(type - 100);
			int cap = DX.GetCap(type - 100);
			int num6 = cap - num5 - num2 - num3 * num;
			if (num6 < num && num6 < cap / 10)
			{
				return 0;
			}
			if (num6 < stashRes)
			{
				num4 = num6 / num;
			}
			else
			{
				num4 = stashRes / num;
				if (stashRes % num > 0)
				{
					num4++;
				}
			}
			return num4;
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x00055FB4 File Offset: 0x000541B4
		internal static string GetTypeName(int villageId)
		{
			int special = GameEngine.Instance.World.getSpecial(villageId);
			if (special == 100)
			{
				return SpecialVillageTypes.getName(special, Program.mySettings.LanguageIdent);
			}
			return VillageBuildingsData.getResourceNames(special - 100);
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x00055FF4 File Offset: 0x000541F4
		private void DelayBetweenFarAwayStashes(int nextStashId, Stopwatch sw)
		{
			Point villageLocation = GameEngine.Instance.World.getVillageLocation(nextStashId);
			if (this._lastForagedStash != default(Point))
			{
				int squareDistance = GameEngine.Instance.World.getSquareDistance(villageLocation.X, villageLocation.Y, this._lastForagedStash.X, this._lastForagedStash.Y);
				if (squareDistance > 10000)
				{
					int num = squareDistance / 10;
					if (num > 3000)
					{
						this.LLog(LNG.Print("Extra delay between far away stashes") + ": ~3s", false);
						sw.Stop();
						if (base.RandomSleepOrExit(2987, 3123))
						{
							return;
						}
						sw.Start();
					}
					else
					{
						this.LLog(string.Format("{0}: {1}ms", LNG.Print("Extra delay between far away stashes"), num), false);
						sw.Stop();
						if (base.SleepOrExit(num))
						{
							return;
						}
						sw.Start();
					}
				}
			}
			this._lastForagedStash = villageLocation;
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x000560F4 File Offset: 0x000542F4
		private bool IsThereACloserVillage(double currentDistance, int targetId)
		{
			for (int i = 0; i < this.SelectedVillages.Count; i++)
			{
				if (currentDistance > ScoutingService.GetScoutsTime(this.SelectedVillages[i], targetId))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x00056130 File Offset: 0x00054330
		private static double ConvertScoutsDistanceToTime(double distance)
		{
			WorldData localWorldData = GameEngine.Instance.LocalWorldData;
			distance *= localWorldData.ScoutsMoveSpeed * localWorldData.gamePlaySpeed * ResearchData.ScoutTimes[(int)GameEngine.Instance.World.UserResearchData.Research_Horsemanship];
			distance *= CardTypes.getScoutSpeed(GameEngine.Instance.cardsManager.UserCardData);
			return distance;
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x00056190 File Offset: 0x00054390
		private static double GetScoutsTime(int playerVillageId, int id)
		{
			double num = GameEngine.Instance.World.getDistance(playerVillageId, id);
			WorldData localWorldData = GameEngine.Instance.LocalWorldData;
			num *= localWorldData.ScoutsMoveSpeed * localWorldData.gamePlaySpeed * ResearchData.ScoutTimes[(int)GameEngine.Instance.World.UserResearchData.Research_Horsemanship];
			num = GameEngine.Instance.World.adjustIfIslandTravel(num, playerVillageId, id);
			return num * CardTypes.getScoutSpeed(GameEngine.Instance.cardsManager.UserCardData);
		}

		// Token: 0x060003CA RID: 970 RVA: 0x00056210 File Offset: 0x00054410
		private List<StashDistance> GetStashesInRange(int playerVillageId, List<int> foragingList)
		{
			List<StashDistance> list = new List<StashDistance>();
			VillageData[] villageList = GameEngine.Instance.World.VillageList;
			for (int i = 0; i < villageList.Length; i++)
			{
				int id = villageList[i].id;
				int special = villageList[i].special;
				int num = foragingList.IndexOf(special);
				if (num != -1 && special >= 100 && special <= 133)
				{
					double scoutsTime = ScoutingService.GetScoutsTime(playerVillageId, id);
					if (scoutsTime <= (double)this.ScoutsMaxTime && (special != 100 || (!this.IsThereACloserVillage(scoutsTime, id) && this.IsFirstToStash(id, scoutsTime))))
					{
						list.Add(new StashDistance
						{
							Id = id,
							Distance = scoutsTime,
							Special = special,
							TypeIndex = num
						});
					}
				}
			}
			return list;
		}

		// Token: 0x060003CB RID: 971 RVA: 0x000562DC File Offset: 0x000544DC
		private void CalcelScouts(Stopwatch sw)
		{
			try
			{
				SparseArray armyArray = GameEngine.Instance.World.getArmyArray();
				List<long> list = new List<long>();
				foreach (object obj in armyArray)
				{
					WorldMap.LocalArmyData localArmyData = (WorldMap.LocalArmyData)obj;
					if (!localArmyData.dead && localArmyData.lootType < 0 && localArmyData.isScouts() && GameEngine.Instance.World.isUserVillage(localArmyData.homeVillageID) && !GameEngine.Instance.World.isVillageVisible(localArmyData.targetVillageID) && (localArmyData.serverEndTime - VillageMap.getCurrentServerTime()).TotalSeconds > 15.0)
					{
						this.LLog(string.Format("{0} {1} ID: {2} Name: {3}", new object[]
						{
							GameEngine.Instance.World.getVillageName(localArmyData.homeVillageID),
							LNG.Print("must return scouts from"),
							localArmyData.targetVillageID,
							GameEngine.Instance.World.getVillageNameOrType(localArmyData.targetVillageID)
						}), false);
						list.Add(localArmyData.armyID);
					}
				}
				foreach (long armyID in list)
				{
					RemoteServices.Instance.set_CancelCastleAttack_UserCallBack(new RemoteServices.CancelCastleAttack_UserCallBack(this.CancelCastleAttackCallBack));
					RemoteServices.Instance.CancelCastleAttack(armyID);
					sw.Stop();
					if (base.RandomSleepOrExit(987, 1325))
					{
						break;
					}
					sw.Start();
				}
			}
			catch (InvalidOperationException)
			{
			}
		}

		// Token: 0x060003CC RID: 972 RVA: 0x000564E0 File Offset: 0x000546E0
		private void SendScoutsCallback(SendScouts_ReturnType returnData)
		{
			if (returnData.Success)
			{
				ArmyReturnData[] armyReturnData = new ArmyReturnData[]
				{
					returnData.armyData
				};
				GameEngine.Instance.World.doGetArmyData(armyReturnData, null, false);
				GameEngine.Instance.World.addExistingArmy(returnData.armyData.armyID);
				if (returnData.cardData != null)
				{
					GameEngine.Instance.cardsManager.UserCardData = returnData.cardData;
					return;
				}
			}
			else
			{
				if (!returnData.Success && returnData.m_errorCode == ErrorCodes.ErrorCode.ATTACKING_VILLAGE_INTERDICT_PROTECTED)
				{
					this.LLog(string.Format("{0} {1}", LNG.Print("Cannot scout from IDed village:"), returnData.sourceVillage), true);
					return;
				}
				this.LLog(LNG.Print("Error on sending scouts"), true);
				this.LLog(LNG.Print("Forward the logs to Bot developer"), true);
				this.LLog(string.Concat(new string[]
				{
					ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID),
					". Source Village ",
					GameEngine.Instance.World.getVillageName(returnData.sourceVillage),
					" Target Village ",
					GameEngine.Instance.World.getVillageName(returnData.targetVillage)
				}), true);
			}
		}

		// Token: 0x060003CD RID: 973 RVA: 0x00056614 File Offset: 0x00054814
		private void CancelCastleAttackCallBack(CancelCastleAttack_ReturnType returnData)
		{
			if (returnData.Success)
			{
				if (returnData.armyData != null)
				{
					ArmyReturnData[] armyReturnData = new ArmyReturnData[]
					{
						returnData.armyData
					};
					GameEngine.Instance.World.doGetArmyData(armyReturnData, null, false);
					GameEngine.Instance.World.addExistingArmy(returnData.armyData.armyID);
					GameEngine.Instance.World.deleteArmy(returnData.oldArmyID);
					return;
				}
			}
			else
			{
				this.LLog(LNG.Print("Error on cancelling scouts"), true);
				this.LLog(LNG.Print("Forward the logs to Bot developer"), true);
				this.LLog(ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID), true);
				if (returnData.armyData != null)
				{
					this.LLog("Source Village " + GameEngine.Instance.World.getVillageName(returnData.armyData.homeVillageID) + " Target Village " + GameEngine.Instance.World.getVillageNameOrType(returnData.armyData.targetVillageID), true);
				}
			}
		}

		// Token: 0x040004FE RID: 1278
		public readonly Dictionary<int, List<int>> ResForScouting;

		// Token: 0x040004FF RID: 1279
		public readonly Dictionary<int, List<int>> ResForScoutingIgnore;

		// Token: 0x04000500 RID: 1280
		public bool HireScouts = true;

		// Token: 0x04000501 RID: 1281
		public bool SendOneScout;

		// Token: 0x04000502 RID: 1282
		internal int MinimumScouts = 2;

		// Token: 0x04000503 RID: 1283
		internal bool IgnoreType;

		// Token: 0x04000504 RID: 1284
		internal bool WaitForFreeSpace = true;

		// Token: 0x04000505 RID: 1285
		public bool StopScoutOnCardsExpiry;

		// Token: 0x04000506 RID: 1286
		public bool ShowPopupOnScoutsExpiry = true;

		// Token: 0x04000507 RID: 1287
		public int ScoutsMaxTime = 1200;

		// Token: 0x04000508 RID: 1288
		public int SelectedScoutingVillageId = -1;

		// Token: 0x04000509 RID: 1289
		public const string ScoutsRadiusFileName = "ScoutsRadius.txt";

		// Token: 0x0400050A RID: 1290
		public const string ScoutsTimeFileName = "ScoutsTime.txt";

		// Token: 0x0400050B RID: 1291
		public const string SendOneAtTimeFileName = "ScoutsSendByOne.txt";

		// Token: 0x0400050C RID: 1292
		private ListBox _listBox_ScoutFrom;

		// Token: 0x0400050D RID: 1293
		private ListBox _listBox_ScoutingTypes;

		// Token: 0x0400050E RID: 1294
		private ListBox _listBox_ScoutingTypes_Ignore;

		// Token: 0x0400050F RID: 1295
		private CheckBox _sendOneScout;

		// Token: 0x04000510 RID: 1296
		private Point _lastForagedStash;

		// Token: 0x04000511 RID: 1297
		private CompareStashByDistance ComparerByDistance = new CompareStashByDistance();

		// Token: 0x04000512 RID: 1298
		private object bufferItem;

		// Token: 0x04000513 RID: 1299
		private int bufferType;

		// Token: 0x04000514 RID: 1300
		private int bufferIndex;

		// Token: 0x04000515 RID: 1301
		private bool indexChanged;
	}
}
