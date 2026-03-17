using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms;

namespace Upgrade.Services
{
	// Token: 0x0200005B RID: 91
	public class CastleRepairService : ASubscribed
	{
		// Token: 0x060002D7 RID: 727 RVA: 0x0004E4B4 File Offset: 0x0004C6B4
		public CastleRepairService(Log logMethod, DataGridView settingsGrid, Button fixCastles)
		{
			this.Log = logMethod;
			this._settingsGrid = settingsGrid;
			this._fixCastles = fixCastles;
			this.CastlesList = new List<string>
			{
				"Local"
			};
			this.TroopsList = new List<string>
			{
				"Local"
			};
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x00009735 File Offset: 0x00007935
		private void LLog(string message, bool isError = false)
		{
			this.Log(message, ControlForm.Tab.Castle, isError);
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x0004E508 File Offset: 0x0004C708
		public void UpdateCastleGridPresets()
		{
			this.CastlesList = new List<string>
			{
				"Local"
			};
			IEnumerable<CastleMapPreset> source = from p in PresetManager.Instance.m_presets
			where p.Type == PresetType.INFRASTRUCTURE
			select p;
			if (source.Any<CastleMapPreset>())
			{
				this.CastlesList.AddRange(from p in source
				select p.Name);
			}
			this.TroopsList = new List<string>
			{
				"Local"
			};
			source = from p in PresetManager.Instance.m_presets
			where p.Type == PresetType.TROOP_DEFEND
			select p;
			if (source.Any<CastleMapPreset>())
			{
				this.TroopsList.AddRange(from p in source
				select p.Name);
			}
			foreach (object obj in ((IEnumerable)this._settingsGrid.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				((DataGridViewComboBoxCell)dataGridViewRow.Cells[2]).DataSource = this.CastlesList;
				((DataGridViewComboBoxCell)dataGridViewRow.Cells[4]).DataSource = this.TroopsList;
			}
			if (this.ShouldLoadSettings)
			{
				this.Load();
			}
			this.ShouldLoadSettings = false;
		}

		// Token: 0x060002DA RID: 730 RVA: 0x0004E6A8 File Offset: 0x0004C8A8
		public void InsertVillage(int index, string name)
		{
			this._settingsGrid.Rows.Insert(index, new object[]
			{
				name,
				true,
				this.CastlesList[0],
				true,
				this.CastlesList[0]
			});
			DataGridViewComboBoxCell dataGridViewComboBoxCell = (DataGridViewComboBoxCell)this._settingsGrid[2, index];
			dataGridViewComboBoxCell.DataSource = this.CastlesList;
			dataGridViewComboBoxCell = (DataGridViewComboBoxCell)this._settingsGrid[4, index];
			dataGridViewComboBoxCell.DataSource = this.CastlesList;
		}

		// Token: 0x060002DB RID: 731 RVA: 0x0004E740 File Offset: 0x0004C940
		public void Save()
		{
			List<string> list = new List<string>();
			foreach (object obj in ((IEnumerable)this._settingsGrid.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				string item = string.Concat(new string[]
				{
					string.Format("{0}", ControlForm.GetId(dataGridViewRow.Cells[0].Value.ToString())),
					string.Format(",{0}", dataGridViewRow.Cells[1].Value),
					string.Format(",{0}", dataGridViewRow.Cells[2].Value),
					string.Format(",{0}", dataGridViewRow.Cells[3].Value),
					string.Format(",{0}", dataGridViewRow.Cells[4].Value)
				});
				list.Add(item);
			}
			string settingsFilePath = SettingsManager.GetSettingsFilePath("CastleRepair.txt", true, new string[0]);
			File.WriteAllLines(settingsFilePath, list.ToArray());
		}

		// Token: 0x060002DC RID: 732 RVA: 0x0004E880 File Offset: 0x0004CA80
		public void Load()
		{
			string settingsFilePath = SettingsManager.GetSettingsFilePath("CastleRepair.txt", false, new string[0]);
			if (!File.Exists(settingsFilePath))
			{
				this.LLog(LNG.Print("File doesn't exist") + ": " + settingsFilePath, false);
				return;
			}
			string[] array = File.ReadAllLines(settingsFilePath);
			foreach (string text in array)
			{
				string[] array3 = text.Split(new char[]
				{
					','
				});
				int num;
				if (array3.Length != 5)
				{
					this.LLog(LNG.Print("Castle repair setting is incorrect (fields number)") + ": " + text, false);
				}
				else if (!int.TryParse(array3[0], out num))
				{
					this.LLog(LNG.Print("Castle setting is incorrect (first column must be a village Id)") + ": " + text, false);
				}
				else
				{
					int j = 0;
					while (j < this._settingsGrid.Rows.Count)
					{
						if (ControlForm.GetId(this._settingsGrid[0, j].Value.ToString()) == num)
						{
							this._settingsGrid[1, j].Value = (array3[1] == "True");
							if (!this.CastlesList.Contains(array3[2]))
							{
								this.LLog(LNG.Print("Castle preset wasn't found") + ": " + array3[2], false);
							}
							else
							{
								this._settingsGrid[2, j].Value = array3[2];
							}
							this._settingsGrid[3, j].Value = (array3[3] == "True");
							if (!this.TroopsList.Contains(array3[4]))
							{
								this.LLog(LNG.Print("Troops preset wasn't found") + ": " + array3[4], false);
								break;
							}
							this._settingsGrid[4, j].Value = array3[4];
							break;
						}
						else
						{
							j++;
						}
					}
				}
			}
			this.LLog(LNG.Print("Castle repair settings are loaded"), false);
		}

		// Token: 0x060002DD RID: 733 RVA: 0x0004EA8C File Offset: 0x0004CC8C
		public void FixCastles()
		{
			if (!base.IsSubscribed)
			{
				ABaseService.MessageBoxNonModal(string.Concat(new string[]
				{
					LNG.Print("You need to have one of the following subscriptions"),
					": ",
					LNG.Print("All features"),
					", ",
					LNG.Print("Castle Repair")
				}), LNG.Print("Please subscribe"));
				return;
			}
			this._fixCastles.Enabled = false;
			bool isRefreshEnabled = DX.ControlForm.GetService<DownloadVillagesService>().Enabled;
			bool isPopularityEnabled = DX.ControlForm.GetService<PopularityRegulationService>().Enabled;
			bool isAutoRepairEnabled = this.RepairOnAIAttacks;
			ControlForm botForm = DX.ControlForm;
			new Thread(delegate()
			{
				try
				{
					DX.ControlForm.GetService<DownloadVillagesService>().Enabled = false;
					DX.ControlForm.GetService<PopularityRegulationService>().Enabled = false;
					this.RepairOnAIAttacks = false;
					foreach (object obj in ((IEnumerable)this._settingsGrid.Rows))
					{
						DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
						string text = dataGridViewRow.Cells[0].Value.ToString();
						int villageId = ControlForm.GetId(text);
						if (villageId == -1)
						{
							this.LLog(LNG.Print("Could not get village ID of") + ": " + text, false);
						}
						else
						{
							this.LLog(LNG.Print("Checking") + " " + text, false);
							try
							{
								botForm.Invoke(new MethodInvoker(delegate()
								{
									InterfaceMgr.Instance.setVillageNameBar(villageId);
									GameEngine.Instance.downloadCurrentVillage();
								}));
							}
							catch (Exception ex)
							{
								this.LLog(string.Concat(new string[]
								{
									LNG.Print("Switch village error."),
									" ",
									ex.Message,
									" ",
									ex.StackTrace
								}), false);
								continue;
							}
							if (GameEngine.Instance.Castle == null)
							{
								this.LLog(LNG.Print("Castle wasn't loaded"), false);
							}
							else
							{
								if (this.RandomSleepOrExit(500, 1500))
								{
									return;
								}
								if (GameEngine.Instance.Castle.castleDamaged)
								{
									this.LLog(LNG.Print("Launching Autorepair"), false);
									botForm.Invoke(new MethodInvoker(delegate()
									{
										GameEngine.Instance.Castle.autoRepairCastle();
									}));
									if (this.RandomSleepOrExit(1500, 2500))
									{
										return;
									}
								}
								if ((bool)dataGridViewRow.Cells[1].Value)
								{
									string presetName = ((DataGridViewComboBoxCell)dataGridViewRow.Cells[2]).Value.ToString();
									this.RestoreCastle(villageId, presetName);
								}
								if (this.RandomSleepOrExit(1000, 2000))
								{
									return;
								}
								if ((bool)dataGridViewRow.Cells[3].Value)
								{
									string presetName2 = ((DataGridViewComboBoxCell)dataGridViewRow.Cells[4]).Value.ToString();
									this.RestoreTroops(villageId, presetName2);
								}
								if (this.RandomSleepOrExit(1500, 3000))
								{
									return;
								}
							}
						}
					}
				}
				catch (InvalidOperationException ex2)
				{
					this.LLog(LNG.Print("ERROR: List of villages has changed. Please start Repair again."), false);
					ABaseService.ReportError(ex2, ControlForm.Tab.Castle);
				}
				catch (Exception ex3)
				{
					ABaseService.ReportError(ex3, ControlForm.Tab.Castle);
				}
				finally
				{
					if (isRefreshEnabled)
					{
						DX.ControlForm.GetService<DownloadVillagesService>().Enabled = true;
					}
					this.RepairOnAIAttacks = isAutoRepairEnabled;
					if (isPopularityEnabled)
					{
						DX.ControlForm.GetService<PopularityRegulationService>().Enabled = true;
					}
					this._fixCastles.BeginInvoke(new MethodInvoker(delegate()
					{
						this._fixCastles.Enabled = true;
					}));
				}
				this.LLog(LNG.Print("Castle repair finished"), false);
			}).Start();
		}

		// Token: 0x060002DE RID: 734 RVA: 0x0004EB64 File Offset: 0x0004CD64
		private void RestoreCastle(int villageId, string presetName)
		{
			try
			{
				int num = 0;
				if (presetName == "Local")
				{
					num = (int)DX.ControlForm.Invoke(new Func<int>(() => GameEngine.Instance.Castle.restoreInfrastructure()));
				}
				else
				{
					IEnumerable<CastleMapPreset> source = from p in PresetManager.Instance.m_presets
					where p.Type == PresetType.INFRASTRUCTURE
					select p;
					if (source.Count<CastleMapPreset>() > 0)
					{
						CastleMapPreset preset = source.SingleOrDefault((CastleMapPreset p) => p.Name == presetName);
						if (preset == null)
						{
							this.LLog(LNG.Print("ERROR. Castle preset not found in cloud") + ": " + presetName, false);
						}
						else
						{
							num = (int)DX.ControlForm.Invoke(new Func<int>(() => GameEngine.Instance.Castle.restoreInfrastructurePreset(preset)));
						}
					}
					else
					{
						this.LLog(LNG.Print("ERROR. Castle presets not found in cloud."), false);
					}
				}
				if (num > 0)
				{
					DX.ControlForm.Invoke(new MethodInvoker(delegate()
					{
						GameEngine.Instance.Castle.commitCastle(true);
					}));
					while (InterfaceMgr.Instance.WaitingForCallback)
					{
						this.LLog(LNG.Print("Saving castle of") + " " + GameEngine.Instance.World.getVillageName(villageId), false);
						if (base.SleepOrExit(200))
						{
							return;
						}
					}
					this.LLog(GameEngine.Instance.World.getVillageName(villageId) + " " + LNG.Print("infrastructure restored"), false);
					base.RandomSleepOrExit(1500, 2000);
				}
			}
			catch (Exception ex)
			{
				this.LLog(string.Concat(new string[]
				{
					LNG.Print("ERROR. Infrastucture restore error."),
					" ",
					ex.Message,
					" ",
					ex.StackTrace
				}), false);
				ABaseService.ReportError(ex, ControlForm.Tab.Castle);
			}
		}

		// Token: 0x060002DF RID: 735 RVA: 0x0004ED9C File Offset: 0x0004CF9C
		private void RestoreTroops(int villageId, string presetName)
		{
			try
			{
				int num = 0;
				if (presetName == "Local")
				{
					num = (int)DX.ControlForm.Invoke(new Func<int>(() => GameEngine.Instance.Castle.restoreTroops()));
				}
				else
				{
					IEnumerable<CastleMapPreset> source = from p in PresetManager.Instance.m_presets
					where p.Type == PresetType.TROOP_DEFEND
					select p;
					if (source.Count<CastleMapPreset>() > 0)
					{
						CastleMapPreset preset = source.SingleOrDefault((CastleMapPreset p) => p.Name == presetName);
						if (preset == null)
						{
							this.LLog(LNG.Print("ERROR. Troops preset not found in cloud") + ": " + presetName, false);
						}
						else
						{
							num = (int)DX.ControlForm.Invoke(new Func<int>(() => GameEngine.Instance.Castle.restoreTroopsPreset(preset)));
						}
					}
					else
					{
						this.LLog(LNG.Print("ERROR. Troops presets not found in cloud."), false);
					}
				}
				if (num > 0)
				{
					DX.ControlForm.Invoke(new MethodInvoker(delegate()
					{
						GameEngine.Instance.Castle.commitCastle(true);
					}));
					while (InterfaceMgr.Instance.WaitingForCallback)
					{
						this.LLog(LNG.Print("Saving castle of") + " " + GameEngine.Instance.World.getVillageName(villageId), false);
						if (base.SleepOrExit(200))
						{
							return;
						}
					}
					this.LLog(GameEngine.Instance.World.getVillageName(villageId) + " " + LNG.Print("troops restored"), false);
					base.RandomSleepOrExit(1500, 2000);
				}
			}
			catch (Exception ex)
			{
				this.LLog(string.Concat(new string[]
				{
					LNG.Print("ERROR. Troops restore error."),
					" ",
					ex.Message,
					" ",
					ex.StackTrace
				}), false);
				ABaseService.ReportError(ex, ControlForm.Tab.Castle);
			}
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x00009745 File Offset: 0x00007945
		public void MemoriseTroopsAndCastles()
		{
			new Thread(delegate()
			{
				try
				{
					foreach (object obj in GameEngine.Instance.Castles)
					{
						CastleMap castleMap = (CastleMap)obj;
						if (castleMap == null)
						{
							this.LLog(string.Format("{0}: {1}", LNG.Print("Castle wasn't loaded"), castleMap.VillageID), false);
						}
						else
						{
							this.LLog(string.Format("{0}: {1}", LNG.Print("Saving castle"), castleMap.VillageID), false);
							if (castleMap.memoriseTroops())
							{
								this.LLog(SK.Text("Advanced_Castle_Troops_Saves", "Troops Memorized"), false);
							}
							else
							{
								this.LLog(SK.Text("Advanced_Castle_Troops_Saves_failed", "Troops Memorize Failed"), false);
							}
							if (base.RandomSleepOrExit(400, 700))
							{
								return;
							}
							if (castleMap.memoriseInfrastructure())
							{
								this.LLog(SK.Text("Advanced_Castle_Infrastructure_Saves", "Infrastructure Memorized"), false);
							}
							else
							{
								this.LLog(SK.Text("Advanced_Castle_Infrastructure_Saves_failed", "Infrastructure Memorize Failed"), false);
							}
							if (base.RandomSleepOrExit(1000, 2000))
							{
								return;
							}
						}
					}
					this.LLog(LNG.Print("Finish!:)"), false);
				}
				catch (InvalidOperationException ex)
				{
					this.LLog(LNG.Print("ERROR: List of villages has changed. Please start Repair again."), false);
					ABaseService.ReportError(ex, ControlForm.Tab.Castle);
				}
				catch (Exception ex2)
				{
					ABaseService.ReportError(ex2, ControlForm.Tab.Castle);
				}
			}).Start();
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x0004EFD4 File Offset: 0x0004D1D4
		public void LaunchCastleRepair(WorldMap.LocalArmyData armyData)
		{
			if (!this.RepairOnAIAttacks)
			{
				this.LLog(LNG.Print("Auto-repair cancelled by user settings."), false);
				return;
			}
			if (DX.ControlForm.IsDisposed || !DX.ControlForm.IsHandleCreated)
			{
				return;
			}
			int villageId = armyData.targetVillageID;
			string villageName = GameEngine.Instance.World.getVillageName(villageId);
			if (GameEngine.Instance.getVillage(villageId) == null)
			{
				return;
			}
			int homeVillageID = armyData.homeVillageID;
			if (GameEngine.Instance.World.getSpecial(homeVillageID) == 0)
			{
				this.LLog(LNG.Print("Auto-repair cancelled. Human attack."), false);
				return;
			}
			new Thread(delegate()
			{
				this.RepairCastle(villageId, villageName);
			}).Start();
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x0004F0A0 File Offset: 0x0004D2A0
		internal void RepairCastle(int villageId, string villageName)
		{
			if (!base.IsSubscribed)
			{
				ABaseService.MessageBoxNonModal(string.Concat(new string[]
				{
					LNG.Print("You need to have one of the following subscriptions"),
					": ",
					LNG.Print("All features"),
					", ",
					LNG.Print("Castle Repair")
				}), LNG.Print("Please subscribe"));
				return;
			}
			bool enabled = DX.ControlForm.GetService<DownloadVillagesService>().Enabled;
			bool enabled2 = DX.ControlForm.GetService<PopularityRegulationService>().Enabled;
			string originalText = this._fixCastles.Text;
			this._fixCastles.Invoke(new MethodInvoker(delegate()
			{
				this._fixCastles.Enabled = false;
				this._fixCastles.Text = "Wait...";
			}));
			try
			{
				DX.ControlForm.GetService<DownloadVillagesService>().Enabled = false;
				DX.ControlForm.GetService<PopularityRegulationService>().Enabled = false;
				if (!base.RandomSleepOrExit(1500, 3000))
				{
					this.LLog(LNG.Print("Repairing village") + ": " + villageName, false);
					if (InterfaceMgr.Instance.OwnSelectedVillage != villageId)
					{
						this.LLog(LNG.Print("Trying to select the village."), false);
						try
						{
							DX.ControlForm.Invoke(new MethodInvoker(delegate()
							{
								InterfaceMgr.Instance.setVillageNameBar(villageId);
								GameEngine.Instance.downloadCurrentVillage();
							}));
							goto IL_1A1;
						}
						catch (Exception ex)
						{
							this.LLog(string.Concat(new string[]
							{
								LNG.Print("Switch village error."),
								" ",
								ex.Message,
								" ",
								ex.StackTrace
							}), false);
							return;
						}
					}
					this.LLog(LNG.Print("Village is in focus."), false);
					IL_1A1:
					if (GameEngine.Instance.Castle == null)
					{
						this.LLog(LNG.Print("Castle wasn't loaded"), false);
					}
					else
					{
						this.LLog(LNG.Print("Updaing Castle to see the damange"), false);
						DX.ControlForm.Invoke(new MethodInvoker(delegate()
						{
							GameEngine.Instance.Castle.commitCastle(true);
						}));
						while (InterfaceMgr.Instance.WaitingForCallback)
						{
							this.LLog(LNG.Print("Update in process..."), false);
							if (base.SleepOrExit(200))
							{
								return;
							}
						}
						this.LLog(LNG.Print("Castle updated"), false);
						if (!base.RandomSleepOrExit(500, 1500))
						{
							if (GameEngine.Instance.Castle.castleDamaged)
							{
								this.LLog(LNG.Print("Launching Autorepair"), false);
								DX.ControlForm.Invoke(new MethodInvoker(delegate()
								{
									GameEngine.Instance.Castle.autoRepairCastle();
								}));
								if (base.RandomSleepOrExit(1500, 2500))
								{
									return;
								}
							}
							else
							{
								this.LLog(LNG.Print("Castle has no damaged pieces."), false);
							}
							DataGridViewRow villageSettings = this.GetVillageSettings(villageId);
							if (villageSettings == null)
							{
								this.LLog(LNG.Print("No settings found for village") + ": " + villageName, false);
							}
							else
							{
								if ((bool)villageSettings.Cells[1].Value)
								{
									string presetName = ((DataGridViewComboBoxCell)villageSettings.Cells[2]).Value.ToString();
									this.RestoreCastle(villageId, presetName);
								}
								else
								{
									this.LLog(LNG.Print("Restore Castle cancelled according to village settings."), false);
								}
								if (!base.RandomSleepOrExit(1000, 2000))
								{
									if ((bool)villageSettings.Cells[3].Value)
									{
										string presetName2 = ((DataGridViewComboBoxCell)villageSettings.Cells[4]).Value.ToString();
										this.RestoreTroops(villageId, presetName2);
									}
									else
									{
										this.LLog(LNG.Print("Restore Troops cancelled according to village settings."), false);
									}
									this.LLog(villageName + " " + LNG.Print("auto-repair finished."), false);
									base.RandomSleepOrExit(1000, 2000);
								}
							}
						}
					}
				}
			}
			catch (Exception ex2)
			{
				ABaseService.ReportError(ex2, ControlForm.Tab.Castle);
			}
			finally
			{
				if (enabled)
				{
					DX.ControlForm.GetService<DownloadVillagesService>().Enabled = true;
				}
				if (enabled2)
				{
					DX.ControlForm.GetService<PopularityRegulationService>().Enabled = true;
				}
				this._fixCastles.BeginInvoke(new MethodInvoker(delegate()
				{
					this._fixCastles.Enabled = true;
					this._fixCastles.Text = originalText;
				}));
			}
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0004F534 File Offset: 0x0004D734
		private DataGridViewRow GetVillageSettings(int villageId)
		{
			foreach (object obj in ((IEnumerable)this._settingsGrid.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				string item = dataGridViewRow.Cells[0].Value.ToString();
				if (villageId == ControlForm.GetId(item))
				{
					return dataGridViewRow;
				}
			}
			return null;
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x0004F5B8 File Offset: 0x0004D7B8
		internal override void TranslateUI()
		{
			this._settingsGrid.Columns[0].HeaderText = SK.Text("GENERIC_Village", "Village");
			this._settingsGrid.Columns[1].HeaderText = SK.Text("Advanced_Castle_Restore", "Restore") + " " + SK.Text("Advanced_Castle_Castle", "Infrastructure");
			this._settingsGrid.Columns[2].HeaderText = SK.Text("CastleMapPanel_Stored_Castle", "Stored Castles");
			this._settingsGrid.Columns[3].HeaderText = SK.Text("Advanced_Castle_Restore", "Restore") + " " + SK.Text("Advanced_Castle_Troops", "Troops");
			this._settingsGrid.Columns[4].HeaderText = SK.Text("CastleMapPanel_Stored_Formations", "Stored Troops");
			this._fixCastles.Text = SK.Text("CastleMapPanel_Repair", "Repair");
		}

		// Token: 0x04000437 RID: 1079
		private DataGridView _settingsGrid;

		// Token: 0x04000438 RID: 1080
		private Button _fixCastles;

		// Token: 0x04000439 RID: 1081
		private List<string> CastlesList;

		// Token: 0x0400043A RID: 1082
		private List<string> TroopsList;

		// Token: 0x0400043B RID: 1083
		private const string SettingsFileName = "CastleRepair.txt";

		// Token: 0x0400043C RID: 1084
		private readonly Log Log;

		// Token: 0x0400043D RID: 1085
		internal bool ShouldLoadSettings;

		// Token: 0x0400043E RID: 1086
		internal bool RepairOnAIAttacks;
	}
}
