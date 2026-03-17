using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;
using Kingdoms;

namespace Upgrade.Services
{
	// Token: 0x02000075 RID: 117
	internal class PredatorService : ABaseService
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000349 RID: 841 RVA: 0x00009A42 File Offset: 0x00007C42
		internal IEnumerable<string> PreysNames
		{
			get
			{
				return from s in this._settings
				select s.TypeName;
			}
		}

		// Token: 0x0600034A RID: 842 RVA: 0x00051BB8 File Offset: 0x0004FDB8
		public PredatorService(Log log, DataGridView settingsGrid, DataGridView foundPreysGrid, ListBox villages, ListBox vassals, ListBox capitals, CheckBox useCastleTroops, ControlForm controlForm) : base(log)
		{
			this._settingsGrid = settingsGrid;
			this._settingsGrid.CellValueChanged += this.SettingsGrid_CellValueChanged;
			this._foundPreysGrid = foundPreysGrid;
			this._foundPreysGrid.CellClick += this.ShowPrey;
			this._lbSelectedVillages = villages;
			this._lbSelectedVassals = vassals;
			this._lbSelectedCapitals = capitals;
			this._chbUseCastleTroops = useCastleTroops;
			this._settings = new List<PredatorPreySettings>();
			this._foundPreys = new List<PredatorPrey>();
			this.InitPredatorSettingsGrid();
			this._controlForm = controlForm;
		}

		// Token: 0x0600034B RID: 843 RVA: 0x00009A6E File Offset: 0x00007C6E
		private void LLog(string message, bool isError = false)
		{
			this.Log(message, ControlForm.Tab.Predator, isError);
		}

		// Token: 0x0600034C RID: 844 RVA: 0x00051C90 File Offset: 0x0004FE90
		private List<string> GetLocalSetupsNames()
		{
			char[] separator = new char[]
			{
				'_'
			};
			List<string> list = new List<string>();
			string[] files = Directory.GetFiles(GameEngine.getSettingsPath(true), "*.cas");
			foreach (string text in files)
			{
				string text2 = Path.GetFileName(text.Remove(text.LastIndexOf('.')));
				string[] array2 = text2.Split(separator);
				if (array2.Length >= 2 && !(array2[0].ToLowerInvariant() != "attacksetup"))
				{
					text2 = text2.Replace("AttackSetup_", "");
					list.Add(text2);
				}
			}
			return list;
		}

		// Token: 0x0600034D RID: 845 RVA: 0x00051D34 File Offset: 0x0004FF34
		private List<string> GetCloudSetupsNames()
		{
			return (from p in PresetManager.Instance.m_presets
			where p.Type == PresetType.TROOP_ATTACK
			select p.Name).ToList<string>();
		}

		// Token: 0x0600034E RID: 846 RVA: 0x00051D98 File Offset: 0x0004FF98
		private List<string> GetAllSetupsNames()
		{
			this.cloudSetupsNames = this.GetCloudSetupsNames();
			List<string> list = new List<string>(this.cloudSetupsNames);
			list.AddRange(this.localSetupsNames = this.GetLocalSetupsNames());
			if (list.Count == 0)
			{
				list.Add("No Data");
			}
			return list;
		}

		// Token: 0x0600034F RID: 847 RVA: 0x00051DE8 File Offset: 0x0004FFE8
		public void InitPredatorFormations()
		{
			List<string> allSetupsNames = this.GetAllSetupsNames();
			for (int i = 0; i < this._settingsGrid.Rows.Count; i++)
			{
				DataGridViewRow dataGridViewRow = this._settingsGrid.Rows[i];
				DataGridViewComboBoxCell dataGridViewComboBoxCell = (DataGridViewComboBoxCell)dataGridViewRow.Cells[9];
				dataGridViewComboBoxCell.DataSource = allSetupsNames;
				dataGridViewComboBoxCell.Value = allSetupsNames.FirstOrDefault<string>();
				int type = Convert.ToInt32(dataGridViewRow.Cells[0].Value);
				this._settings.Find((PredatorPreySettings s) => s.TypeId == type).Formation = allSetupsNames.FirstOrDefault<string>();
			}
			this.LLog(LNG.Print("Predator Formations are loaded"), false);
			if (this.ShouldLoadSettings)
			{
				this.Load();
			}
			this.ShouldLoadSettings = false;
		}

		// Token: 0x06000350 RID: 848 RVA: 0x00009A7F File Offset: 0x00007C7F
		public static int GetHonourRangeOrDefault()
		{
			if (GameEngine.Instance.LocalWorldData == null)
			{
				return 32;
			}
			return GameEngine.Instance.LocalWorldData.BaseScoutHonourRange;
		}

		// Token: 0x06000351 RID: 849 RVA: 0x00051EC4 File Offset: 0x000500C4
		public void InitPredatorSettingsGrid()
		{
			int honourRangeOrDefault = PredatorService.GetHonourRangeOrDefault();
			int maxSquareDistance = honourRangeOrDefault * honourRangeOrDefault;
			for (int i = 0; i <= 17; i++)
			{
				if (PredatorService.IsPrey(i, -1))
				{
					PredatorPreySettings predatorPreySettings = new PredatorPreySettings(i, (i == 0) ? "Rogue village" : SpecialVillageTypes.getName(i, Program.mySettings.LanguageIdent), false, honourRangeOrDefault, maxSquareDistance, true, true, true, false, false, "No Data");
					this._settings.Add(predatorPreySettings);
					int rowIndex = this._settingsGrid.Rows.Add(predatorPreySettings.GetParams());
					DataGridViewComboBoxCell dataGridViewComboBoxCell = (DataGridViewComboBoxCell)this._settingsGrid[9, rowIndex];
					dataGridViewComboBoxCell.DataSource = new List<string>
					{
						"No Data"
					};
					dataGridViewComboBoxCell.Value = "No Data";
				}
			}
		}

		// Token: 0x06000352 RID: 850 RVA: 0x00009A9F File Offset: 0x00007C9F
		public void Save()
		{
			new Thread(delegate()
			{
				string[] array = new string[this._settings.Count];
				int num = 0;
				foreach (PredatorPreySettings predatorPreySettings in this._settings)
				{
					array[num] = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", new object[]
					{
						predatorPreySettings.TypeId,
						predatorPreySettings.TypeName,
						predatorPreySettings.Hunt,
						predatorPreySettings.MaxDistance,
						predatorPreySettings.IncludeVassalHonourRange,
						predatorPreySettings.IncludeCapitalHonourRange,
						predatorPreySettings.NotifyWithMessage,
						predatorPreySettings.NotifyWithSound,
						predatorPreySettings.Kill,
						predatorPreySettings.Formation
					});
					num++;
				}
				string settingsFilePath = SettingsManager.GetSettingsFilePath("Predator.txt", true, new string[0]);
				File.WriteAllLines(settingsFilePath, array);
				this.SaveHunters();
				settingsFilePath = SettingsManager.GetSettingsFilePath("UseCastleTroops.txt", true, new string[]
				{
					this.Name
				});
				File.WriteAllText(settingsFilePath, this._chbUseCastleTroops.Checked.ToString());
				settingsFilePath = SettingsManager.GetSettingsFilePath("HuntWithinParish.txt", true, new string[]
				{
					this.Name
				});
				File.WriteAllText(settingsFilePath, this._controlForm.checkBox_HuntWithinParish.Checked.ToString());
			}).Start();
		}

		// Token: 0x06000353 RID: 851 RVA: 0x00051F88 File Offset: 0x00050188
		public void SaveHunters()
		{
			string[] array = new string[3];
			array[0] = string.Join(",", this.SelectedVillages.ConvertAll<string>((int x) => x.ToString()).ToArray());
			array[1] = string.Join(",", this.SelectedVassals.ConvertAll<string>((int x) => x.ToString()).ToArray());
			array[2] = string.Join(",", this.SelectedCapitals.ConvertAll<string>((int x) => x.ToString()).ToArray());
			string[] contents = array;
			string settingsFilePath = SettingsManager.GetSettingsFilePath("SelectedHunters.txt", true, new string[]
			{
				this.Name
			});
			File.WriteAllLines(settingsFilePath, contents);
		}

		// Token: 0x06000354 RID: 852 RVA: 0x00009AB7 File Offset: 0x00007CB7
		public void Load()
		{
			new Thread(delegate()
			{
				string settingsFilePath = SettingsManager.GetSettingsFilePath("Predator.txt", false, new string[0]);
				if (!File.Exists(settingsFilePath))
				{
					this.LLog(LNG.Print("File doesn't exist") + ": " + settingsFilePath, false);
					return;
				}
				string[] array = File.ReadAllLines(settingsFilePath);
				List<string> attackPresets = this.GetAllSetupsNames();
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string text = array2[i];
					string[] array3 = text.Split(new char[]
					{
						','
					});
					int settingTypeId;
					if (!int.TryParse(array3[0], out settingTypeId))
					{
						this.LLog("Predator setting is incorrect (first column must be a number): " + text, false);
					}
					else
					{
						PredatorPreySettings settingToEdit = this._settings.SingleOrDefault((PredatorPreySettings ps) => ps.TypeId == settingTypeId);
						if (settingToEdit == null)
						{
							this.LLog("Predator setting is incorrect (not valid prey): " + text, false);
						}
						else
						{
							int num;
							if (!int.TryParse(array3[3], out num))
							{
								this.LLog("Predator setting is incorrect (settingMaxDistance): " + text, false);
							}
							else
							{
								settingToEdit.MaxDistance = num;
								settingToEdit.MaxSquareDistance = num * num;
							}
							foreach (int num2 in new int[]
							{
								2,
								4,
								5,
								6,
								7,
								8
							})
							{
								bool value;
								if (bool.TryParse(array3[num2], out value))
								{
									settingToEdit.SetValue(num2, value);
								}
								else
								{
									this.LLog(string.Format("Predator setting #{0} is incorrect: {1}", num2 - 1, text), false);
								}
							}
							if (array3.Length == 10 && attackPresets.Contains(array3[9]))
							{
								settingToEdit.Formation = array3[9];
							}
							else
							{
								settingToEdit.Formation = attackPresets.FirstOrDefault<string>();
							}
							this._settingsGrid.BeginInvoke(new MethodInvoker(delegate()
							{
								for (int k = 0; k < this._settingsGrid.Rows.Count; k++)
								{
									if (Convert.ToInt32(this._settingsGrid.Rows[k].Cells[0].Value) == settingTypeId)
									{
										this._settingsGrid.Rows.RemoveAt(k);
										this._settingsGrid.Rows.Insert(k, settingToEdit.GetParams());
										DataGridViewComboBoxCell dataGridViewComboBoxCell = (DataGridViewComboBoxCell)this._settingsGrid.Rows[k].Cells[9];
										dataGridViewComboBoxCell.DataSource = attackPresets;
										dataGridViewComboBoxCell.Value = settingToEdit.Formation;
										return;
									}
								}
							}));
						}
					}
				}
				this.LoadHunters();
				settingsFilePath = SettingsManager.GetSettingsFilePath("UseCastleTroops.txt", false, new string[]
				{
					this.Name
				});
				bool @checked;
				if (!File.Exists(settingsFilePath))
				{
					this.LLog(LNG.Print("File doesn't exist") + ": " + settingsFilePath, false);
				}
				else if (bool.TryParse(File.ReadAllText(settingsFilePath), out @checked))
				{
					this._chbUseCastleTroops.Checked = @checked;
				}
				settingsFilePath = SettingsManager.GetSettingsFilePath("HuntWithinParish.txt", false, new string[]
				{
					this.Name
				});
				bool checked2;
				if (!File.Exists(settingsFilePath))
				{
					this.LLog(LNG.Print("File doesn't exist") + ": " + settingsFilePath, false);
				}
				else if (bool.TryParse(File.ReadAllText(settingsFilePath), out checked2))
				{
					this._controlForm.checkBox_HuntWithinParish.Checked = checked2;
				}
				this.LLog(LNG.Print("Predator settings are loaded"), false);
			}).Start();
		}

		// Token: 0x06000355 RID: 853 RVA: 0x00052074 File Offset: 0x00050274
		public void LoadHunters()
		{
			string settingsFilePath = SettingsManager.GetSettingsFilePath("SelectedHunters.txt", false, new string[]
			{
				this.Name
			});
			if (!File.Exists(settingsFilePath))
			{
				this.LLog(LNG.Print("File doesn't exist") + ": " + settingsFilePath, false);
				return;
			}
			string[] array = File.ReadAllLines(settingsFilePath);
			if (array.Length < 3)
			{
				this.LLog(LNG.Print("File must have 3 lines") + ": " + settingsFilePath, false);
				return;
			}
			this.LoadGenericHunters(array[0], this.Villages, this.SelectedVillages, this._lbSelectedVillages);
			this.LoadGenericHunters(array[1], this.Vassals, this.SelectedVassals, this._lbSelectedVassals);
			this.LoadGenericHunters(array[2], this.Capitals, this.SelectedCapitals, this._lbSelectedCapitals);
			this.LLog(LNG.Print("List of Hunters is loaded"), false);
		}

		// Token: 0x06000356 RID: 854 RVA: 0x00052150 File Offset: 0x00050350
		private void LoadGenericHunters(string huntersToLoad, List<int> allHunters, List<int> selectedHunters, ListBox listBoxHunters)
		{
			char[] separator = new char[]
			{
				','
			};
			string[] array = huntersToLoad.Split(separator, StringSplitOptions.RemoveEmptyEntries);
			selectedHunters.Clear();
			foreach (string value in array)
			{
				int num = Convert.ToInt32(value);
				if (allHunters.Contains(num))
				{
					selectedHunters.Add(num);
				}
				else
				{
					this.LLog(string.Format("{0}: {1}", LNG.Print("Village/Vassal/Capital wasn't loaded from settings"), num), false);
				}
			}
			for (int j = 0; j < listBoxHunters.Items.Count; j++)
			{
				bool contains = selectedHunters.Contains(ControlForm.GetId(listBoxHunters.Items[j].ToString()));
				int index = j;
				listBoxHunters.BeginInvoke(new MethodInvoker(delegate()
				{
					listBoxHunters.SetSelected(index, contains);
				}));
			}
		}

		// Token: 0x06000357 RID: 855 RVA: 0x00052264 File Offset: 0x00050464
		private void CleanUp()
		{
			List<PredatorPrey> list = new List<PredatorPrey>();
			foreach (PredatorPrey predatorPrey in this._foundPreys)
			{
				VillageData villageData = GameEngine.Instance.World.getVillageData(predatorPrey.Id);
				if (predatorPrey.TypeId == 0)
				{
					if (!PredatorService.IsVillageHostile(predatorPrey.Id))
					{
						list.Add(predatorPrey);
					}
				}
				else if (villageData.special != predatorPrey.TypeId)
				{
					list.Add(predatorPrey);
				}
			}
			using (List<PredatorPrey>.Enumerator enumerator2 = list.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					PredatorPrey foundp = enumerator2.Current;
					this._foundPreys.Remove(foundp);
					this._foundPreysGrid.BeginInvoke(new MethodInvoker(delegate()
					{
						for (int i = 0; i < this._foundPreysGrid.Rows.Count; i++)
						{
							DataGridViewRow dataGridViewRow = this._foundPreysGrid.Rows[i];
							if (Convert.ToInt32(dataGridViewRow.Cells[0].Value) == foundp.Id)
							{
								this._foundPreysGrid.Rows.Remove(dataGridViewRow);
								return;
							}
						}
					}));
				}
			}
		}

		// Token: 0x06000358 RID: 856 RVA: 0x00052378 File Offset: 0x00050578
		public override void ConcreteAction()
		{
			if ((DateTime.Now - DX.ControlForm.LastWorldMapUpdate).TotalSeconds >= 35.0)
			{
				this.LLog(LNG.Print("Please open the world map for update!"), true);
				return;
			}
			VillageData[] villageList = GameEngine.Instance.World.VillageList;
			bool flag = false;
			bool flag2 = false;
			StringBuilder stringBuilder = new StringBuilder();
			this.CleanUp();
			int i;
			int j;
			for (i = 0; i < villageList.Length; i = j + 1)
			{
				int id = villageList[i].id;
				if (!this._foundPreys.Any((PredatorPrey fp) => fp.Id == id) && PredatorService.IsPrey(villageList[i].special, id))
				{
					int villageSpecial = villageList[i].special;
					PredatorPreySettings predatorPreySettings = this._settings.Single((PredatorPreySettings p) => p.TypeId == villageSpecial);
					int parentOfNextTo;
					double distance;
					int nextTo;
					double totalSeconds;
					if (predatorPreySettings.Hunt && this.IsCloseEnough(id, predatorPreySettings.MaxSquareDistance, predatorPreySettings.IncludeVassalHonourRange, predatorPreySettings.IncludeCapitalHonourRange, predatorPreySettings.TypeId == 0, out distance, out nextTo, out parentOfNextTo, out totalSeconds))
					{
						this._foundPreys.Add(new PredatorPrey(id, predatorPreySettings.TypeId, distance, parentOfNextTo, nextTo));
						string villageName = (predatorPreySettings.TypeId == 0) ? (GameEngine.Instance.World.getUsernameByUserId(villageList[i].userID) + " : " + GameEngine.Instance.World.getVillageName(id)) : predatorPreySettings.TypeName;
						this._foundPreysGrid.BeginInvoke(new MethodInvoker(delegate()
						{
							this._foundPreysGrid.Rows.Add(new object[]
							{
								id,
								villageName,
								(int)distance,
								GameEngine.Instance.World.getVillageName(nextTo),
								VillageMap.createBuildTimeString((int)totalSeconds)
							});
						}));
						if (predatorPreySettings.NotifyWithSound)
						{
							flag = true;
						}
						if (predatorPreySettings.NotifyWithMessage)
						{
							flag2 = true;
							stringBuilder.AppendLine(villageName);
						}
					}
				}
				j = i;
			}
			if (flag)
			{
				this.PlaySound();
			}
			if (flag2)
			{
				ABaseService.MessageBoxNonModal(stringBuilder.ToString(), LNG.Print("Predator found prey"));
			}
			this.LLog(LNG.Print("Map scan finished"), false);
			if (this._foundPreys.Count == 0)
			{
				return;
			}
			using (IEnumerator<PredatorPrey> enumerator = (from p in this._foundPreys
			where !p.Attacked
			orderby p.NextTo, p.Distance
			select p).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PredatorPrey foundPrey = enumerator.Current;
					if (!base.Enabled)
					{
						break;
					}
					PredatorPreySettings predatorPreySettings2 = this._settings.Single((PredatorPreySettings p) => p.TypeId == foundPrey.TypeId);
					int num;
					int parentVillageID;
					if (predatorPreySettings2.Kill && this.GetHunter(foundPrey.Id, predatorPreySettings2.Formation, predatorPreySettings2.MaxSquareDistance, predatorPreySettings2.IncludeVassalHonourRange, predatorPreySettings2.IncludeCapitalHonourRange, predatorPreySettings2.TypeId == 0, out num, out parentVillageID))
					{
						this.LLog(string.Format("{0}: {1} => {2}({3})", new object[]
						{
							LNG.Print("Attacking from"),
							GameEngine.Instance.World.getVillageName(num),
							GameEngine.Instance.World.getVillageNameOrType(foundPrey.Id),
							foundPrey.Id
						}), false);
						this.PreAttackSetupBG(parentVillageID, num, foundPrey.Id);
						break;
					}
				}
			}
		}

		// Token: 0x06000359 RID: 857 RVA: 0x00052808 File Offset: 0x00050A08
		public bool GetHunter(int targetId, string formationName, int maxDistance, bool includeVassals, bool includeCapitals, bool ignoreSelected, out int nextTo, out int parentOfNextTo)
		{
			List<int> hunters = this.GetHunters(includeVassals, includeCapitals, ignoreSelected);
			double num = (double)maxDistance;
			nextTo = -1;
			parentOfNextTo = -1;
			Point villageLocation = GameEngine.Instance.World.getVillageLocation(targetId);
			foreach (int num2 in hunters)
			{
				string key = string.Format("{0} - {1}", num2, formationName);
				if (!this.RestingHunters.ContainsKey(key) || !(DateTime.Now - this.RestingHunters[key] < TimeSpan.FromSeconds(600.0)))
				{
					int squareDistance = GameEngine.Instance.World.getSquareDistance(villageLocation.X, villageLocation.Y, num2);
					if ((double)squareDistance <= num && (ignoreSelected || !this.HuntWithinParish || PredatorService.IsInSameParish(num2, targetId)))
					{
						num = (double)squareDistance;
						nextTo = num2;
						parentOfNextTo = (this.SelectedVassals.Contains(num2) ? GameEngine.Instance.World.getVillageData(num2).connecter : num2);
					}
				}
			}
			if (nextTo != -1)
			{
				num = Math.Sqrt(num);
				double num3 = DX.ControlForm.TimedAttacksService.CalcAttackTimeForPredator(nextTo, num);
				int num5;
				int num4 = this.ClosestHunterTime(targetId, out num5);
				if (num5 != -1 && num3 >= (double)num4)
				{
					this.LLog(string.Concat(new string[]
					{
						GameEngine.Instance.World.getVillageName(num5),
						" ",
						LNG.Print("is faster"),
						": ",
						VillageMap.createBuildTimeString(num4)
					}), false);
					return false;
				}
			}
			return nextTo != -1;
		}

		// Token: 0x0600035A RID: 858 RVA: 0x000529D4 File Offset: 0x00050BD4
		public bool IsCloseEnough(int targetId, int maxDistance, bool includeVassals, bool includeCapitals, bool ignoreSelected, out double distance, out int nextTo, out int parentOfNextTo, out double totalSeconds)
		{
			List<int> hunters = this.GetHunters(includeVassals, includeCapitals, ignoreSelected);
			distance = (double)maxDistance;
			nextTo = -1;
			parentOfNextTo = -1;
			totalSeconds = 0.0;
			Point villageLocation = GameEngine.Instance.World.getVillageLocation(targetId);
			foreach (int num in hunters)
			{
				int squareDistance = GameEngine.Instance.World.getSquareDistance(villageLocation.X, villageLocation.Y, num);
				if ((double)squareDistance <= distance && (ignoreSelected || !this.HuntWithinParish || PredatorService.IsInSameParish(num, targetId)))
				{
					distance = (double)squareDistance;
					nextTo = num;
					parentOfNextTo = (this.SelectedVassals.Contains(num) ? GameEngine.Instance.World.getVillageData(num).connecter : num);
				}
			}
			if (nextTo != -1)
			{
				distance = Math.Sqrt(distance);
				totalSeconds = DX.ControlForm.TimedAttacksService.CalcAttackTimeForPredator(nextTo, distance);
				int num3;
				int num2 = this.ClosestHunterTime(targetId, out num3);
				if (num3 != -1 && totalSeconds >= (double)num2)
				{
					this.LLog(string.Concat(new string[]
					{
						GameEngine.Instance.World.getVillageName(num3),
						" ",
						LNG.Print("is faster"),
						": ",
						VillageMap.createBuildTimeString(num2)
					}), false);
					return false;
				}
			}
			return nextTo != -1;
		}

		// Token: 0x0600035B RID: 859 RVA: 0x00052B60 File Offset: 0x00050D60
		public static bool IsInSameParish(int villageId, int targetId)
		{
			int villageRegion = GameEngine.Instance.World.getVillageRegion(villageId);
			int villageRegion2 = GameEngine.Instance.World.getVillageRegion(targetId);
			return villageRegion == villageRegion2;
		}

		// Token: 0x0600035C RID: 860 RVA: 0x00052B94 File Offset: 0x00050D94
		public int ClosestHunterTime(int targetId, out int closestHunterId)
		{
			double num = double.MaxValue;
			closestHunterId = -1;
			bool flag;
			do
			{
				try
				{
					SparseArray armyArray = GameEngine.Instance.World.getArmyArray();
					foreach (object obj in armyArray)
					{
						WorldMap.LocalArmyData localArmyData = (WorldMap.LocalArmyData)obj;
						if (localArmyData.targetVillageID == targetId && localArmyData.numScouts == 0 && localArmyData.lootType < 0)
						{
							double num2 = DXTimer.GetCurrentMilliseconds() / 1000.0;
							double num3 = localArmyData.localEndTime - num2;
							if (num3 < num)
							{
								num = num3;
								closestHunterId = localArmyData.homeVillageID;
							}
						}
					}
					flag = true;
				}
				catch (InvalidOperationException)
				{
					this.LLog(LNG.Print("Armies array changed. Scanning again."), false);
					flag = false;
				}
			}
			while (!flag);
			return (int)num;
		}

		// Token: 0x0600035D RID: 861 RVA: 0x00052C7C File Offset: 0x00050E7C
		public List<int> GetHunters(bool includeVassals, bool includeCapitals, bool ignoreSelected)
		{
			List<int> list = new List<int>(ignoreSelected ? this.Villages : this.SelectedVillages);
			if (includeVassals)
			{
				list.AddRange(ignoreSelected ? this.Vassals : this.SelectedVassals);
			}
			if (includeCapitals)
			{
				list.AddRange(ignoreSelected ? this.Capitals : this.SelectedCapitals);
			}
			return list;
		}

		// Token: 0x0600035E RID: 862 RVA: 0x00052CD8 File Offset: 0x00050ED8
		public static bool IsPrey(int special, int villageId = -1)
		{
			if (special != 0)
			{
				switch (special)
				{
				case 3:
				case 5:
				case 7:
				case 9:
				case 11:
				case 13:
				case 15:
				case 17:
					return true;
				}
				return false;
			}
			return villageId == -1 || PredatorService.IsVillageHostile(villageId);
		}

		// Token: 0x0600035F RID: 863 RVA: 0x00052D40 File Offset: 0x00050F40
		public static bool IsVillageHostile(int villageId)
		{
			int villageUserID = GameEngine.Instance.World.getVillageUserID(villageId);
			return villageUserID != -1 && GameEngine.Instance.World.getUserRelationship(villageUserID) == -1;
		}

		// Token: 0x06000360 RID: 864 RVA: 0x00052D78 File Offset: 0x00050F78
		public void ShowPrey(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex == -1)
			{
				return;
			}
			DataGridViewRow dataGridViewRow = this._foundPreysGrid.Rows[e.RowIndex];
			int villageID = Convert.ToInt32(dataGridViewRow.Cells[0].Value);
			InterfaceMgr.Instance.selectVillage(villageID);
			InterfaceMgr.Instance.switchToSelectedVillage();
		}

		// Token: 0x06000361 RID: 865 RVA: 0x00009ACF File Offset: 0x00007CCF
		public void ClearPreys()
		{
			this.RestingHunters.Clear();
			this._foundPreysGrid.Rows.Clear();
			this._foundPreys.Clear();
		}

		// Token: 0x06000362 RID: 866 RVA: 0x00052DD4 File Offset: 0x00050FD4
		private void SettingsGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex == -1)
			{
				return;
			}
			int rowIndex = e.RowIndex;
			int columnIndex = e.ColumnIndex;
			DataGridViewCell dataGridViewCell = this._settingsGrid[columnIndex, rowIndex];
			if (this._settingsGrid.Columns[columnIndex].GetType() == typeof(DataGridViewCheckBoxColumn))
			{
				bool flag = (bool)dataGridViewCell.Value;
				if (columnIndex == 7 && flag)
				{
					string path = Path.Combine(ControlForm.SettingsFolder, "PreyDetectedSound.wav");
					if (!this.IsSoundFileValid(path))
					{
						dataGridViewCell.Value = false;
						return;
					}
				}
				this._settings[rowIndex].SetValue(columnIndex, flag);
				return;
			}
			if (columnIndex != 3)
			{
				if (columnIndex == 9)
				{
					this._settings[rowIndex].Formation = dataGridViewCell.Value.ToString();
				}
				return;
			}
			int num;
			if (dataGridViewCell.Value == null || !int.TryParse(dataGridViewCell.Value.ToString(), out num))
			{
				MyMessageBox.Show(LNG.Print("Only numbers 0-9!"));
				dataGridViewCell.Value = this._settings[rowIndex].MaxDistance;
				return;
			}
			this._settings[rowIndex].MaxDistance = num;
			this._settings[rowIndex].MaxSquareDistance = num * num;
		}

		// Token: 0x06000363 RID: 867 RVA: 0x00052F14 File Offset: 0x00051114
		private void PlaySound()
		{
			SoundPlayer soundPlayer = this.SoundPlayer;
			if (soundPlayer != null)
			{
				soundPlayer.Stop();
			}
			string text = Path.Combine(ControlForm.SettingsFolder, "PreyDetectedSound.wav");
			if (!this.IsSoundFileValid(text))
			{
				return;
			}
			try
			{
				this.SoundPlayer = new SoundPlayer(text);
				this.SoundPlayer.Play();
			}
			catch (Exception ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.Predator);
			}
		}

		// Token: 0x06000364 RID: 868 RVA: 0x00052F84 File Offset: 0x00051184
		private bool IsSoundFileValid(string path)
		{
			if (File.Exists(path))
			{
				return true;
			}
			new Thread(delegate()
			{
				MessageBox.Show(path + " does not exist.", "Can not play sound notifications.");
			}).Start();
			return false;
		}

		// Token: 0x06000365 RID: 869 RVA: 0x00052FC4 File Offset: 0x000511C4
		public void PreAttackSetupBG(int parentVillageID, int attackingVillageID, int targetVillageID)
		{
			RemoteServices.Instance.set_PreAttackSetup_UserCallBack(new RemoteServices.PreAttackSetup_UserCallBack(this.PreAttackSetupCallbackBG));
			RemoteServices.Instance.PreAttackSetup(parentVillageID, attackingVillageID, targetVillageID, 0, 0, 0, 0, 0, 0, 0, 0);
		}

		// Token: 0x06000366 RID: 870 RVA: 0x00052FFC File Offset: 0x000511FC
		public void PreAttackSetupCallbackBG(PreAttackSetup_ReturnType returnData)
		{
			if (returnData.protectedVillage)
			{
				ABaseService.MessageBoxNonModal(SK.Text("GameEngine_Protected_Interdiction", "This village is protected from attack by an Interdiction."), SK.Text("GENERIC_Village_Protected", "Village Protected"));
				return;
			}
			if (returnData.vacationVillage)
			{
				ABaseService.MessageBoxNonModal(SK.Text("GameEngine_Protected_Vacation", "This village is protected from attack by Vacation Mode."), SK.Text("GENERIC_Village_Protected", "Village Protected"));
				return;
			}
			if (returnData.vassalVacation)
			{
				ABaseService.MessageBoxNonModal(SK.Text("GameEngine_Vassal_Vacation", "Your vassal is in Vacation Mode and you cannot attack from here."), SK.Text("GENERIC_Cannot_Attack_Target", "Cannot Attack Target"));
				return;
			}
			if (returnData.peaceVillage)
			{
				if (!GameEngine.Instance.World.isCapital(returnData.targetVillage))
				{
					ABaseService.MessageBoxNonModal(SK.Text("GameEngine_Protected_Peacetime", "This village is within Peace Time and cannot be attacked."), SK.Text("GENERIC_Village_Protected", "Village Protected"));
					return;
				}
				ABaseService.MessageBoxNonModal(SK.Text("GameEngine_Protected_Peacetime_Capital", "This capital is within peace time and cannot be attacked."), SK.Text("GENERIC_Capital_Protected", "Capital Protected"));
				return;
			}
			else if (returnData.peaceAttacker)
			{
				if (returnData.parentAttackingVillage != returnData.attackingVillage)
				{
					ABaseService.MessageBoxNonModal(SK.Text("GameEngine_Cannot_Attack_PeaceTime", "You are within Peace Time and cannot attack from this village."), SK.Text("GENERIC_Village_Protected", "Village Protected"));
					return;
				}
				ABaseService.MessageBoxNonModal(SK.Text("GameEngine_Currently_Peacetime", "You are currently Peace Time protected"), SK.Text("GENERIC_Village_Protected", "Village Protected"));
				return;
			}
			else if (returnData.protectedAttacker)
			{
				if (returnData.parentAttackingVillage != returnData.attackingVillage)
				{
					ABaseService.MessageBoxNonModal(SK.Text("GameEngine_Currently_Interdited_Vassal", "Your vassal is protected by Interdiction and you cannot attack from this village."), SK.Text("GameEngine_Currently_Interdited_protected", "Your Vassal is Protected"));
					return;
				}
				ABaseService.MessageBoxNonModal(SK.Text("GameEngine_Currently_Interdited", "You are currently Interdiction protected") + "\n" + SK.Text("GameEngine_CancelProtection", "Do you wish to cancel this protection?"), SK.Text("GENERIC_Protected", "You Are Protected"));
				return;
			}
			else
			{
				if (!returnData.Success)
				{
					if (returnData.m_errorCode == ErrorCodes.ErrorCode.ATTACKING_INVALID_TARGET)
					{
						this.LLog(LNG.Print("Please open the world map for update!"), true);
					}
					this.LLog(string.Concat(new string[]
					{
						ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID),
						". Source Village ",
						GameEngine.Instance.World.getVillageName(returnData.attackingVillage),
						" Target Village ",
						GameEngine.Instance.World.getVillageName(returnData.targetVillage),
						" "
					}), true);
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
				if (num > 0 && GameEngine.Instance.World.getCurrentHonour() <= 0.0)
				{
					ABaseService.MessageBoxNonModal(SK.Text("GameEngine_Require_Honour_To_Attack", "You require honour to attack this target."), SK.Text("GENERIC_Attack_Error", "Attack Error"));
					return;
				}
				this.InitCastleAttackSetup(returnData.castleMapSnapshot, returnData.castleTroopsSnapshot, returnData.keepLevel, returnData.numPeasants, returnData.numArchers, returnData.numPikemen, returnData.numSwordsmen, returnData.numCatapults, returnData.attackingVillage, returnData.targetVillage, returnData.attackType, returnData.pillagePercent, returnData.captainsCommand, returnData.parentAttackingVillage, returnData.numPeasantsInCastle, returnData.numArchersInCastle, returnData.numPikemenInCastle, returnData.numSwordsmenInCastle, returnData.targetUserID, returnData.targetUserName, returnData.battleHonourData, returnData.numCaptainsInCastle, returnData.numCaptains, returnData.landType, returnData.capitalAttackRate);
				return;
			}
		}

		// Token: 0x06000367 RID: 871 RVA: 0x00053394 File Offset: 0x00051594
		public void InitCastleAttackSetup(byte[] castleMap, byte[] defenderMap, int keepLevel, int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults, int attackingVillage, int targetVillage, int attackType, int pillagePercent, int captainsCommand, int parentOfAttackingVillage, int numPeasantsInCastle, int numArchersInCastle, int numPikemenInCastle, int numSwordsmenInCastle, int targetUserID, string targetUserName, BattleHonourData honourData, int numCaptainsInCastle, int numCaptains, int landType, double capitalAttackRate)
		{
			CastleMap castleMap2 = new CastleMap(-1, GameEngine.Instance.GFX, 1);
			castleMap2.SetUsingCastleTroopsOK(this.UseCastleTroops);
			castleMap2.importDefenderSnapshot(castleMap, defenderMap, keepLevel, true, landType);
			castleMap2.initRealSetup(attackingVillage, targetVillage, numPeasants, numArchers, numPikemen, numSwordsmen, numCatapults, attackType, pillagePercent, captainsCommand, parentOfAttackingVillage, numPeasantsInCastle, numArchersInCastle, numPikemenInCastle, numSwordsmenInCastle, targetUserID, targetUserName, honourData, numCaptainsInCastle, numCaptains, capitalAttackRate);
			string formationName = this.GetFormationNameBySpecialTargetId(targetVillage);
			if (formationName == null)
			{
				return;
			}
			if (this.cloudSetupsNames.Contains(formationName))
			{
				CastleMapPreset castleMapPreset = PresetManager.Instance.m_presets.FirstOrDefault((CastleMapPreset p) => p.Name == formationName && p.Type == PresetType.TROOP_ATTACK);
				if (castleMapPreset == null)
				{
					this.LLog(LNG.Print("Attack preset is not found in Cloud") + ": \"" + formationName + "\"", false);
					return;
				}
				this.LLog(string.Format("Applying attack formation \"{0}\" with {1} troops", castleMapPreset.Name, castleMapPreset.ElementCount), false);
				int[] array = ExtensionMethods.PresetTroopsCount(castleMapPreset);
				if (!castleMap2.HasEnoughTroopsToPlace(ref array))
				{
					this.ProcessNotEnoughTroops(attackingVillage, castleMapPreset.Name, array);
					return;
				}
				castleMap2.RestoreAttackPresetBG(castleMapPreset);
				if (!PredatorService.WasEnoughTroopsPlaced(castleMap2, array))
				{
					this.LLog("Canceled attack! Can not use formation \"" + castleMapPreset.Name + "\" for " + PredatorService.GetVillageTerrainTypeById(targetVillage), false);
					return;
				}
				if (base.RandomSleepOrExit(1000, 2000))
				{
					return;
				}
				castleMap2.launchArmy(true);
				this._foundPreys.First((PredatorPrey p) => p.Id == targetVillage).Attacked = true;
				return;
			}
			else
			{
				if (!this.localSetupsNames.Contains(formationName))
				{
					this.LLog(LNG.Print("Attack formation is not found in Cloud/Local") + ": \"" + formationName + "\"", false);
					return;
				}
				List<CastleMap.RestoreCastleElement> attackSetup = castleMap2.getAttackSetup(formationName);
				this.LLog(string.Format("Applying local attack formation \"{0}\" with {1} troops", formationName, attackSetup.Count), false);
				int[] troopsCountArray = ExtensionMethods.GetTroopsCountArray12(attackSetup);
				if (!castleMap2.HasEnoughTroopsToPlace(ref troopsCountArray))
				{
					this.ProcessNotEnoughTroops(attackingVillage, formationName, troopsCountArray);
					return;
				}
				castleMap2.RestoreAttackSetupBG(attackSetup);
				if (!PredatorService.WasEnoughTroopsPlaced(castleMap2, troopsCountArray))
				{
					this.LLog("Canceled attack! Can not use formation \"" + formationName + "\" for " + PredatorService.GetVillageTerrainTypeById(targetVillage), false);
					return;
				}
				if (base.RandomSleepOrExit(1000, 2000))
				{
					return;
				}
				castleMap2.launchArmy(true);
				this._foundPreys.First((PredatorPrey p) => p.Id == targetVillage).Attacked = true;
				return;
			}
		}

		// Token: 0x06000368 RID: 872 RVA: 0x0005363C File Offset: 0x0005183C
		public static string GetVillageTerrainTypeById(int villageId)
		{
			int villageTerrainType = GameEngine.Instance.World.getVillageTerrainType(villageId);
			return PredatorService.GetVillageTerrainTypeName(villageTerrainType);
		}

		// Token: 0x06000369 RID: 873 RVA: 0x00053660 File Offset: 0x00051860
		public static string GetVillageTerrainTypeName(int code)
		{
			switch (code)
			{
			case 0:
				return SK.Text("MapTypes_Lowland", "Lowland");
			case 1:
				return SK.Text("MapTypes_Highland", "Highland");
			case 2:
				return SK.Text("MapTypes_River", "River") + " 1";
			case 3:
				return SK.Text("MapTypes_River", "River") + " 2";
			case 4:
				return SK.Text("MapTypes_Mountain_Peak", "Mountain Peak");
			case 5:
				return SK.Text("MapTypes_Salt_Flat", "Salt Flat");
			case 6:
				return SK.Text("MapTypes_Marsh", "Marsh");
			case 7:
				return SK.Text("MapTypes_Plains", "Plains");
			case 8:
				return SK.Text("MapTypes_Valley_Side", "Valley Side");
			case 9:
				return SK.Text("MapTypes_Forest", "Forest");
			default:
				return "Unknown";
			}
		}

		// Token: 0x0600036A RID: 874 RVA: 0x0005375C File Offset: 0x0005195C
		private static bool WasEnoughTroopsPlaced(CastleMap castleMap, int[] array)
		{
			double num = 0.8;
			return (double)castleMap.attackNumPeasants >= (double)array[0] * num && (double)castleMap.attackNumArchers >= (double)array[1] * num && (double)castleMap.attackNumPikemen >= (double)array[2] * num && (double)castleMap.attackNumSwordsmen >= (double)array[3] * num && (double)castleMap.attackNumCatapults >= (double)array[4] * num && (double)castleMap.attackNumCaptains >= (double)array[5] * num;
		}

		// Token: 0x0600036B RID: 875 RVA: 0x000537D4 File Offset: 0x000519D4
		private void ProcessNotEnoughTroops(int attackingVillage, string presetName, int[] array)
		{
			string text = "Missing troops: ";
			for (int i = 0; i < 6; i++)
			{
				if (array[i] != 0 && array[i] > array[i + 6])
				{
					text += string.Format("{0} {1}, ", array[i] - array[i + 6], TroopsrecruitingService.TroopsNames[i]);
				}
			}
			text = text.TrimEnd(new char[]
			{
				' ',
				','
			});
			string villageName = GameEngine.Instance.World.getVillageName(attackingVillage);
			this.LLog(string.Concat(new string[]
			{
				villageName,
				" ",
				LNG.Print("has not enough troops for"),
				" \"",
				presetName,
				"\". ",
				text
			}), false);
			string key = string.Format("{0} - {1}", attackingVillage, presetName);
			if (!this.RestingHunters.ContainsKey(key))
			{
				this.RestingHunters.Add(key, DateTime.Now);
				return;
			}
			this.RestingHunters[key] = DateTime.Now;
		}

		// Token: 0x0600036C RID: 876 RVA: 0x000538D8 File Offset: 0x00051AD8
		public string GetFormationNameBySpecialTargetId(int specialVillageId)
		{
			int type = GameEngine.Instance.World.getSpecial(specialVillageId);
			if (!PredatorService.IsPrey(type, -1))
			{
				this.LLog(string.Format("No attack formation found for {0} of type {1}", specialVillageId, type), false);
				return null;
			}
			PredatorPreySettings predatorPreySettings = this._settings.FirstOrDefault((PredatorPreySettings f) => f.TypeId == type);
			if (predatorPreySettings == null)
			{
				this.LLog(string.Format("{0}: {1}", LNG.Print("No settings found for prey type"), type), false);
				return null;
			}
			string formation = predatorPreySettings.Formation;
			if (string.IsNullOrEmpty(formation))
			{
				this.LLog(string.Format("No attack formation {0} specified for prey type {1}", formation, type), false);
				return null;
			}
			return formation;
		}

		// Token: 0x0600036D RID: 877 RVA: 0x00009AF7 File Offset: 0x00007CF7
		public void StopSound()
		{
			SoundPlayer soundPlayer = this.SoundPlayer;
			if (soundPlayer == null)
			{
				return;
			}
			soundPlayer.Stop();
		}

		// Token: 0x0600036E RID: 878 RVA: 0x00007CE0 File Offset: 0x00005EE0
		internal override void TranslateUI()
		{
		}

		// Token: 0x0400048C RID: 1164
		private DataGridView _settingsGrid;

		// Token: 0x0400048D RID: 1165
		private DataGridView _foundPreysGrid;

		// Token: 0x0400048E RID: 1166
		private List<PredatorPreySettings> _settings;

		// Token: 0x0400048F RID: 1167
		public List<PredatorPrey> _foundPreys;

		// Token: 0x04000490 RID: 1168
		public SoundPlayer SoundPlayer;

		// Token: 0x04000491 RID: 1169
		private const string SettingsFileName = "Predator.txt";

		// Token: 0x04000492 RID: 1170
		private const string HuntersFileName = "SelectedHunters.txt";

		// Token: 0x04000493 RID: 1171
		private const string UseCastleTroopsFileName = "UseCastleTroops.txt";

		// Token: 0x04000494 RID: 1172
		private const string HuntWithinParishFileName = "HuntWithinParish.txt";

		// Token: 0x04000495 RID: 1173
		public const string SoundFileName = "PreyDetectedSound.wav";

		// Token: 0x04000496 RID: 1174
		public List<int> Villages = new List<int>();

		// Token: 0x04000497 RID: 1175
		public List<int> Vassals = new List<int>();

		// Token: 0x04000498 RID: 1176
		public List<int> Capitals = new List<int>();

		// Token: 0x04000499 RID: 1177
		public List<int> SelectedVassals = new List<int>();

		// Token: 0x0400049A RID: 1178
		public List<int> SelectedCapitals = new List<int>();

		// Token: 0x0400049B RID: 1179
		private ListBox _lbSelectedVillages;

		// Token: 0x0400049C RID: 1180
		private ListBox _lbSelectedVassals;

		// Token: 0x0400049D RID: 1181
		private ListBox _lbSelectedCapitals;

		// Token: 0x0400049E RID: 1182
		private CheckBox _chbUseCastleTroops;

		// Token: 0x0400049F RID: 1183
		private ControlForm _controlForm;

		// Token: 0x040004A0 RID: 1184
		public bool UseCastleTroops;

		// Token: 0x040004A1 RID: 1185
		private Dictionary<string, DateTime> RestingHunters = new Dictionary<string, DateTime>();

		// Token: 0x040004A2 RID: 1186
		internal bool ShouldLoadSettings;

		// Token: 0x040004A3 RID: 1187
		private List<string> localSetupsNames;

		// Token: 0x040004A4 RID: 1188
		private List<string> cloudSetupsNames;

		// Token: 0x040004A5 RID: 1189
		public bool HuntWithinParish;
	}
}
