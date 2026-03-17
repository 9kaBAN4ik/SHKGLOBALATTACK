using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms;

namespace Upgrade.Services
{
	// Token: 0x020000A2 RID: 162
	internal class VillagelayoutService : ABaseService
	{
		// Token: 0x06000437 RID: 1079 RVA: 0x00009FFB File Offset: 0x000081FB
		internal void LLog(string message, bool isError = false)
		{
			this.Log(message, ControlForm.Tab.VillageLayouts, isError);
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x0005B81C File Offset: 0x00059A1C
		public VillagelayoutService(Log log, DataGridView dataGridView) : base(log)
		{
			this.BuildingsData = new Dictionary<int, List<int[]>>();
			this.Templates = new Dictionary<int, int>();
			this.dataGridView1 = dataGridView;
			this.dataGridView1.MouseMove += this.dataGridView1_MouseMove;
			this.dataGridView1.MouseDown += this.dataGridView1_MouseDown;
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x00007CE0 File Offset: 0x00005EE0
		internal override void TranslateUI()
		{
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x0005B88C File Offset: 0x00059A8C
		internal void CopySettings(ListBox listBox_VillageLayouts, IEnumerable<string> listOfVillages, int id, bool saveSettings)
		{
			bool value = this.SelectedVillages.Contains(id);
			foreach (string text in listOfVillages)
			{
				int id2 = ControlForm.GetId(text);
				if (id2 != id)
				{
					if (!GameEngine.Instance.World.areSameVillageType(id, id2))
					{
						this.LLog(string.Format("{0} : {1}, {2}", LNG.Print("Village types don't match"), id, text), true);
					}
					else
					{
						this.BuildingsData[id2] = new List<int[]>(this.BuildingsData[id]);
						for (int i = 0; i < this.BuildingsData[id2].Count; i++)
						{
							this.BuildingsData[id2][i][3] = -1;
						}
						int num = listBox_VillageLayouts.Items.IndexOf(text);
						if (num != -1)
						{
							listBox_VillageLayouts.SetSelected(num, value);
						}
					}
				}
			}
			if (saveSettings)
			{
				this.SaveLayouts();
			}
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x0005B9A0 File Offset: 0x00059BA0
		internal void AddVillage(int villageId)
		{
			this.SelectedVillages.Add(villageId);
			List<int[]> value = new List<int[]>();
			this.BuildingsData.Add(villageId, value);
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x0005B9CC File Offset: 0x00059BCC
		internal void RemoveVillage(int villageId)
		{
			this.BuildingsData.Remove(villageId);
			List<int> list = new List<int>();
			foreach (KeyValuePair<int, int> keyValuePair in this.Templates)
			{
				if (keyValuePair.Value == villageId)
				{
					list.Add(keyValuePair.Key);
					this.LLog(string.Format("{0} {1}: {2}", keyValuePair.Key, LNG.Print("lost template"), villageId), false);
				}
			}
			foreach (int key in list)
			{
				this.Templates.Remove(key);
			}
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x0005BAB4 File Offset: 0x00059CB4
		internal void ImportBuildings(VillageMap village)
		{
			if (!this.BuildingsData.ContainsKey(village.VillageID))
			{
				this.BuildingsData.Add(village.VillageID, new List<int[]>());
			}
			if (this.BuildingsData[village.VillageID].Count != 0)
			{
				return;
			}
			this.ResetBuildings(village);
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x0005BB0C File Offset: 0x00059D0C
		internal void ResetBuildings(VillageMap village)
		{
			List<int[]> list = this.BuildingsData[village.VillageID];
			list.Clear();
			object localBuildingsLock = village._localBuildingsLock;
			lock (localBuildingsLock)
			{
				foreach (VillageMapBuilding villageMapBuilding in village.Buildings)
				{
					int buildingType = villageMapBuilding.buildingType;
					if (buildingType != 0)
					{
						Point buildingLocation = villageMapBuilding.buildingLocation;
						List<int[]> list2 = list;
						int[] array = new int[4];
						array[0] = buildingType;
						array[1] = buildingLocation.X;
						array[2] = buildingLocation.Y;
						list2.Add(array);
					}
				}
			}
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x0005BBCC File Offset: 0x00059DCC
		private bool SaveVillageLayout(int villageId)
		{
			VillageMap village = GameEngine.Instance.getVillage(villageId);
			if (village == null)
			{
				this.LLog(LNG.Print("Village wasn't loaded") + ": " + GameEngine.Instance.World.getVillageName(villageId), true);
				return false;
			}
			int villageTerrainType = GameEngine.Instance.World.getVillageTerrainType(villageId);
			string item = string.Format("{0};{1};{2}", this.SelectedVillages.Contains(villageId) ? 1 : 0, villageTerrainType, PredatorService.GetVillageTerrainTypeName(villageTerrainType));
			List<string> list = new List<string>
			{
				item
			};
			List<int[]> placedBuildings = new List<int[]>();
			object localBuildingsLock = village._localBuildingsLock;
			lock (localBuildingsLock)
			{
				foreach (VillageMapBuilding villageMapBuilding in village.Buildings)
				{
					int buildingType = villageMapBuilding.buildingType;
					if (buildingType != 0)
					{
						Point buildingLocation = villageMapBuilding.buildingLocation;
						string item2 = string.Format("{0},{1},{2}", buildingType, buildingLocation.X, buildingLocation.Y);
						placedBuildings.Add(new int[]
						{
							buildingType,
							buildingLocation.X,
							buildingLocation.Y
						});
						list.Add(item2);
					}
				}
			}
			if (this.BuildingsData.ContainsKey(villageId))
			{
				IEnumerable<int[]> source = from b in this.BuildingsData[villageId]
				where !placedBuildings.Any((int[] bp) => bp[0] == b[0] && bp[1] == b[1] && bp[2] == b[2])
				select b;
				list.AddRange(from b in source
				select string.Format("{0},{1},{2}", b[0], b[1], b[2]));
			}
			bool result;
			try
			{
				File.WriteAllLines(string.Format("{0}VillageLayouts\\{1}.txt", ControlForm.SettingsFolder, villageId), list.ToArray());
				result = true;
			}
			catch (UnauthorizedAccessException ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.VillageLayouts);
				result = false;
			}
			return result;
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x0005BDF0 File Offset: 0x00059FF0
		public void SaveLayouts()
		{
			foreach (int villageId in GameEngine.Instance.World.getListOfUserVillages())
			{
				this.SaveVillageLayout(villageId);
			}
			this.SaveTemplates();
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x0005BE54 File Offset: 0x0005A054
		private void SaveTemplates()
		{
			List<string> list = new List<string>();
			foreach (KeyValuePair<int, int> keyValuePair in this.Templates)
			{
				list.Add(string.Format("{0}=>{1}", keyValuePair.Key, keyValuePair.Value));
			}
			string settingsFilePath = SettingsManager.GetSettingsFilePath("Templates.txt", true, new string[]
			{
				"Village"
			});
			File.WriteAllLines(settingsFilePath, list.ToArray());
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x0005BEF4 File Offset: 0x0005A0F4
		public void LoadVillageLayout(int villageId)
		{
			string text = string.Format("{0}VillageLayouts\\{1}.txt", ControlForm.SettingsFolder, villageId);
			if (!File.Exists(text))
			{
				this.LLog(LNG.Print("File doesn't exist") + ": " + text, false);
				return;
			}
			string[] array = File.ReadAllLines(text);
			string villageName = GameEngine.Instance.World.getVillageName(villageId);
			List<int[]> list = this.BuildingsData[villageId];
			list.Clear();
			foreach (string text2 in array)
			{
				if (text2.Contains(";"))
				{
					if (!this.InitLoadedLayout(villageId, villageName, text2))
					{
						break;
					}
				}
				else
				{
					string[] array3 = text2.Split(this.BuildingDataSeparator, StringSplitOptions.RemoveEmptyEntries);
					List<int> list2 = new List<int>();
					for (int j = 0; j < array3.Length; j++)
					{
						int item;
						if (int.TryParse(array3[j], out item))
						{
							list2.Add(item);
						}
					}
					if (list2.Count != 3)
					{
						this.LLog(LNG.Print("Building data has incorrect format") + ": " + text2, true);
					}
					else
					{
						list2.Add(-1);
						list.Add(list2.ToArray());
					}
				}
			}
			this.LLog(villageName + " " + LNG.Print("layout is loaded"), false);
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x0005C048 File Offset: 0x0005A248
		internal bool InitLoadedLayout(int villageId, string villageName, string firstLine)
		{
			string[] array = firstLine.Split(new char[]
			{
				';'
			});
			int num = int.Parse(array[1]);
			int villageTerrainType = GameEngine.Instance.World.getVillageTerrainType(villageId);
			if (num != villageTerrainType)
			{
				this.SelectedVillages.Remove(villageId);
				this.LLog(string.Concat(new string[]
				{
					LNG.Print("Village type doesn't match."),
					" ",
					villageName,
					" (",
					PredatorService.GetVillageTerrainTypeName(villageTerrainType),
					"). Layout (",
					PredatorService.GetVillageTerrainTypeName(num),
					")"
				}), true);
				return false;
			}
			bool flag = array[0] == "1";
			if (flag)
			{
				this.SelectedVillages.Add(villageId);
			}
			else
			{
				this.SelectedVillages.Remove(villageId);
			}
			ListBox listBox_VillageLayouts = DX.ControlForm.listBox_VillageLayouts;
			for (int i = 0; i < listBox_VillageLayouts.Items.Count; i++)
			{
				if (ControlForm.GetId(listBox_VillageLayouts.Items[i].ToString()) == villageId)
				{
					listBox_VillageLayouts.SetSelected(i, flag);
					break;
				}
			}
			if (villageId == this.SelectedLayout)
			{
				DX.ControlForm.checkBox_ShouldLayoutBeBuilt.Checked = flag;
			}
			return true;
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x0005C180 File Offset: 0x0005A380
		public void LoadLayouts()
		{
			foreach (int villageId in GameEngine.Instance.World.getListOfUserVillages())
			{
				this.LoadVillageLayout(villageId);
			}
			this.LoadTemplates();
			this.LLog(LNG.Print("All layouts are loaded"), false);
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x0005C1F4 File Offset: 0x0005A3F4
		private void LoadTemplates()
		{
			string settingsFilePath = SettingsManager.GetSettingsFilePath("Templates.txt", false, new string[]
			{
				"Village"
			});
			if (!File.Exists(settingsFilePath))
			{
				this.LLog(LNG.Print("File doesn't exist") + ": " + settingsFilePath, false);
				return;
			}
			string[] array = File.ReadAllLines(settingsFilePath);
			this.Templates.Clear();
			foreach (string text in array)
			{
				string[] array3 = text.Split(VillagelayoutService.Separator, StringSplitOptions.None);
				int num = int.Parse(array3[0]);
				int num2 = int.Parse(array3[1]);
				if (!this.BuildingsData.ContainsKey(num))
				{
					this.LLog(string.Format("{0}: {1}", SK.Text("GameEngine_Lost_Control_Of_Village", "You have lost control of this village!"), num), true);
				}
				else if (!this.BuildingsData.ContainsKey(num2))
				{
					this.LLog(string.Format("{0}: {1}", SK.Text("GameEngine_Lost_Control_Of_Village", "You have lost control of this village!"), num2), true);
				}
				else if (!GameEngine.Instance.World.areSameVillageType(num, num2))
				{
					this.LLog(string.Format("{0} : {1}, {2}", LNG.Print("Village types don't match"), num, num2), true);
				}
				else
				{
					this.Templates.Add(num, num2);
				}
			}
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x0005C354 File Offset: 0x0005A554
		internal void ImportTemplateFromFile()
		{
			if (this.SelectedLayout == -1)
			{
				MessageBox.Show(LNG.Print("Village is not selected"));
				return;
			}
			try
			{
				string text = ControlForm.SettingsFolder + "VillageLayouts\\";
				OpenFileDialog openFileDialog = new OpenFileDialog();
				if (Directory.Exists(text))
				{
					openFileDialog.InitialDirectory = text;
				}
				openFileDialog.Filter = "TXT files (*.txt)|*.txt|All files (*.*)|*.*";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					if (this.IsValidVillageType(this.SelectedLayout, openFileDialog.FileName))
					{
						string text2 = Path.Combine(text, string.Format("{0}.txt", this.SelectedLayout));
						if (File.Exists(text2) && DialogResult.Yes != MessageBox.Show("Overwrite old file?", "", MessageBoxButtons.YesNo))
						{
							this.LLog("Import cancelled", false);
						}
						else
						{
							File.Copy(openFileDialog.FileName, text2, true);
							this.LoadVillageLayout(this.SelectedLayout);
						}
					}
				}
			}
			catch (Exception ex)
			{
				DX.ShowErrorMessage(ex);
			}
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x0005C448 File Offset: 0x0005A648
		internal bool IsValidVillageType(int villageId, string filename)
		{
			string text = string.Empty;
			using (StreamReader streamReader = new StreamReader(filename))
			{
				text = streamReader.ReadLine();
			}
			if (!text.Contains(";"))
			{
				this.LLog("Village type can't be checked", true);
				return true;
			}
			string[] array = text.Split(new char[]
			{
				';'
			});
			int num = int.Parse(array[1]);
			int villageTerrainType = GameEngine.Instance.World.getVillageTerrainType(villageId);
			if (num != villageTerrainType)
			{
				MessageBox.Show(string.Concat(new string[]
				{
					LNG.Print("Village"),
					": (",
					PredatorService.GetVillageTerrainTypeName(villageTerrainType),
					").\nFile: (",
					PredatorService.GetVillageTerrainTypeName(num),
					")"
				}), LNG.Print("Village type doesn't match."));
				return false;
			}
			return true;
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x0005C52C File Offset: 0x0005A72C
		internal string GetErrorMessage(int code)
		{
			switch (code)
			{
			case -1:
				return "In queue";
			case 0:
				return "OK";
			case 1:
				return SK.Text("VillageMap_Cannot_Be_Placed_Here", "Cannot be placed here");
			case 2:
				return SK.Text("VillageMap_Cannot_Place_Any_More", "You cannot place any more of this building type");
			case 3:
				if (GameEngine.Instance.World.isAccountPremium())
				{
					return SK.Text("VillageMap_Building_Queue_Full", "Building Queue Is Full");
				}
				return SK.Text("VillageMap_Play_Premium_For_Build_Queue", "Play a Premium Token for a Building Queue");
			case 4:
				return SK.Text("VillageMap_Cannot_Afford_Building", "You cannot afford to place this building");
			case 5:
				return SK.Text("VillageMap_Not_Enough_Flags", "You do not have enough flags to place this building");
			case 6:
				return SK.Text("VillageMap_Not_Enough_Resources", "You do not have enough resources to place this building");
			case 7:
				return SK.Text("VillageMap_Near_Trees", "Place near Trees");
			case 8:
				return SK.Text("VillageMap_On_Stone", "Place on Stone");
			case 9:
				return SK.Text("VillageMap_On_Iron", "Place on Iron");
			case 10:
				return SK.Text("VillageMap_On_Marsh", "Place on Marsh");
			case 11:
				return SK.Text("VillageMap_On_Water", "Place on Water");
			case 12:
				return SK.Text("VillageMap_On_Salt_Flats", "Place on Salt Flats");
			case 13:
				return SK.Text("VillageMap_On_River_Edge", "Place near Water");
			default:
				return "Unknown placement error!!11:0";
			}
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x0005C684 File Offset: 0x0005A884
		internal bool IsBuildingPresent(int villageId, int type, int x, int y)
		{
			return this.BuildingsData[villageId].Any((int[] b) => b[0] == type && b[1] == x && b[2] == y);
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x0005C6CC File Offset: 0x0005A8CC
		public override void ConcreteAction()
		{
			List<int> list = new List<int>(this.SelectedVillages);
			foreach (int num in list)
			{
				VillageMap village = GameEngine.Instance.getVillage(num);
				string villageName = GameEngine.Instance.World.getVillageName(num);
				if (village == null)
				{
					this.LLog(LNG.Print("Village wasn't loaded:") + " " + villageName, true);
				}
				else
				{
					List<int[]> list2 = this.BuildingsData[num];
					village.UpdateBG();
					for (int i = 0; i < list2.Count; i++)
					{
						int[] array = list2[i];
						int num2 = array[0];
						string buildingName = VillageBuildingsData.getBuildingName(num2);
						if (!VillageBuildingsData.isThisBuildingTypeAvailable(num2, village.VillageMapType, GameEngine.Instance.World.UserResearchData))
						{
							this.LLog(LNG.Print("Building type is not researched") + ":" + buildingName, true);
						}
						else
						{
							Point point = new Point(array[1], array[2]);
							int num3;
							if (!village.CheckPlacementBuildingToTile(point, num2, out num3))
							{
								int num4 = array[3];
								if (num4 != num3)
								{
									string status = this.GetErrorMessage(num3);
									if (num4 != -1 && num3 != 0)
									{
										this.LLog(string.Format("{0} ({1}/{2}) {3}: {4}", new object[]
										{
											buildingName,
											point.X,
											point.Y,
											LNG.Print("status is"),
											status
										}), false);
									}
									if (num == this.SelectedLayout)
									{
										int localIndex = i;
										this.dataGridView1.BeginInvoke(new MethodInvoker(delegate()
										{
											if (this.dataGridView1.Rows.Count > localIndex)
											{
												this.dataGridView1[3, localIndex].Value = status;
											}
										}));
									}
									array[3] = num3;
								}
								if (num3 == 3)
								{
									this.LLog(villageName + " " + LNG.Print("has been processed (contruction queue is full)."), false);
									break;
								}
								if (this.WaitForResources && (num3 == 4 || num3 == 6))
								{
									this.LLog(villageName + " " + LNG.Print("has been processed (waiting for resources for next building)."), false);
									break;
								}
							}
							else
							{
								this.LLog(string.Format("{0} - {1} {2} => {3}/{4}", new object[]
								{
									villageName,
									LNG.Print("Trying to place"),
									buildingName,
									point.X,
									point.Y
								}), false);
								village.PlaceBuilding(num2, point);
								if (base.RandomSleepOrExit(4000, 6000))
								{
									return;
								}
							}
						}
					}
					if (base.RandomSleepOrExit(1000, 2000))
					{
						return;
					}
				}
			}
			this.LLog(LNG.Print("Cycle is over."), false);
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x0005C9C4 File Offset: 0x0005ABC4
		private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
		{
			DataGridView dataGridView = sender as DataGridView;
			int rowIndex = dataGridView.HitTest(e.X, e.Y).RowIndex;
			if (rowIndex == -1)
			{
				return;
			}
			this.bufferIndex = rowIndex;
			this.bufferItem = dataGridView.Rows[rowIndex];
			DataGridViewCellCollection cells = this.bufferItem.Cells;
			this.bufferItem2 = this.BuildingsData[this.SelectedLayout][rowIndex];
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x0005CA38 File Offset: 0x0005AC38
		private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left)
			{
				return;
			}
			DataGridView dataGridView = sender as DataGridView;
			int rowIndex = dataGridView.HitTest(e.X, e.Y).RowIndex;
			if (rowIndex == this.bufferIndex || rowIndex == -1)
			{
				return;
			}
			dataGridView.Rows.RemoveAt(this.bufferIndex);
			this.bufferIndex = rowIndex;
			dataGridView.Rows.Insert(rowIndex, this.bufferItem);
			dataGridView.Rows[rowIndex].Selected = true;
			this.BuildingsData[this.SelectedLayout].Insert(rowIndex, this.bufferItem2);
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x0005CADC File Offset: 0x0005ACDC
		internal void FillTemplates(ComboBox comboBox)
		{
			int selectedLayout = this.SelectedLayout;
			if (this.Templates.ContainsValue(selectedLayout))
			{
				comboBox.Items.Clear();
				comboBox.Items.Add(LNG.Print("Not available"));
				comboBox.SelectedIndex = 0;
				return;
			}
			short villageTerrain = GameEngine.Instance.World.VillageList[selectedLayout].villageTerrain;
			string text = LNG.Print("No template");
			comboBox.Items.Clear();
			comboBox.Items.Add(text);
			foreach (int num in GameEngine.Instance.World.getListOfUserVillages())
			{
				if (num != selectedLayout && GameEngine.Instance.World.isTargetTerrain(num, villageTerrain) && !this.Templates.ContainsKey(num))
				{
					comboBox.Items.Add(GameEngine.Instance.World.getVillageName(num));
				}
			}
			comboBox.SelectedItem = (this.Templates.ContainsKey(selectedLayout) ? GameEngine.Instance.World.getVillageName(this.Templates[selectedLayout]) : text);
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x0005CC24 File Offset: 0x0005AE24
		internal void SetTemplate(int templateId)
		{
			int selectedLayout = this.SelectedLayout;
			if (!this.Templates.ContainsKey(selectedLayout))
			{
				this.Templates.Add(selectedLayout, templateId);
			}
			else
			{
				this.Templates[selectedLayout] = templateId;
			}
			this.BuildingsData[selectedLayout] = new List<int[]>(this.BuildingsData[templateId]);
			for (int i = 0; i < this.BuildingsData[selectedLayout].Count; i++)
			{
				this.BuildingsData[selectedLayout][i][3] = -1;
			}
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x0000A00C File Offset: 0x0000820C
		internal void RemoveTemplate()
		{
			if (this.Templates.ContainsKey(this.SelectedLayout))
			{
				this.Templates.Remove(this.SelectedLayout);
			}
			this.ResetBuildings(GameEngine.Instance.getVillage(this.SelectedLayout));
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x0005CCB0 File Offset: 0x0005AEB0
		internal void AddBuilding(int villageID, VillageMapBuilding building, Point newLocation = default(Point))
		{
			int[] array = this.BuildingsData[villageID].SingleOrDefault((int[] b) => b[0] == building.buildingType && b[1] == building.buildingLocation.X && b[2] == building.buildingLocation.Y);
			if (array != null)
			{
				array[3] = 0;
			}
			else if (newLocation == default(Point))
			{
				List<int[]> list = this.BuildingsData[villageID];
				int[] array2 = new int[4];
				array2[0] = building.buildingType;
				array2[1] = building.buildingLocation.X;
				array2[2] = building.buildingLocation.Y;
				list.Add(array2);
			}
			else
			{
				List<int[]> list2 = this.BuildingsData[villageID];
				int[] array3 = new int[4];
				array3[0] = building.buildingType;
				array3[1] = newLocation.X;
				array3[2] = newLocation.Y;
				list2.Add(array3);
			}
			if (this.SelectedLayout == villageID)
			{
				ControlForm controlForm = DX.ControlForm;
				if (controlForm != null)
				{
					controlForm.LoadBuildingsDataIntoDataGridView(this.SelectedLayout, this, true);
				}
			}
			foreach (KeyValuePair<int, int> keyValuePair in this.Templates)
			{
				if (keyValuePair.Value == villageID)
				{
					this.AddBuilding(keyValuePair.Key, building, newLocation);
				}
			}
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x0005CE0C File Offset: 0x0005B00C
		internal void DeleteBuilding(int villageID, VillageMapBuilding building, bool isRefreshNeeded = true)
		{
			int[] array = this.BuildingsData[villageID].SingleOrDefault((int[] b) => b[0] == building.buildingType && b[1] == building.buildingLocation.X && b[2] == building.buildingLocation.Y);
			if (array != null)
			{
				this.BuildingsData[villageID].Remove(array);
			}
			if (isRefreshNeeded && this.SelectedLayout == villageID)
			{
				ControlForm controlForm = DX.ControlForm;
				if (controlForm != null)
				{
					controlForm.LoadBuildingsDataIntoDataGridView(this.SelectedLayout, this, true);
				}
			}
			foreach (KeyValuePair<int, int> keyValuePair in this.Templates)
			{
				if (keyValuePair.Value == villageID)
				{
					this.DeleteBuilding(keyValuePair.Key, building, isRefreshNeeded);
				}
			}
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x0005CEDC File Offset: 0x0005B0DC
		internal void DeleteBuilding(int villageID, int buildingIndex)
		{
			int[] item = this.BuildingsData[villageID][buildingIndex];
			this.BuildingsData[villageID].Remove(item);
			foreach (KeyValuePair<int, int> keyValuePair in this.Templates)
			{
				if (keyValuePair.Value == villageID)
				{
					this.BuildingsData[keyValuePair.Key].Remove(item);
				}
			}
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x0000A049 File Offset: 0x00008249
		internal void MoveBuilding(int villageID, VillageMapBuilding building, Point newLocation)
		{
			this.DeleteBuilding(villageID, building, false);
			this.AddBuilding(villageID, building, newLocation);
		}

		// Token: 0x04000564 RID: 1380
		public Dictionary<int, List<int[]>> BuildingsData;

		// Token: 0x04000565 RID: 1381
		public bool WaitForResources;

		// Token: 0x04000566 RID: 1382
		internal int SelectedLayout;

		// Token: 0x04000567 RID: 1383
		private readonly char[] BuildingDataSeparator = new char[]
		{
			','
		};

		// Token: 0x04000568 RID: 1384
		private static string[] Separator = new string[]
		{
			"=>"
		};

		// Token: 0x04000569 RID: 1385
		private DataGridView dataGridView1;

		// Token: 0x0400056A RID: 1386
		private DataGridViewRow bufferItem;

		// Token: 0x0400056B RID: 1387
		private int[] bufferItem2;

		// Token: 0x0400056C RID: 1388
		private int bufferIndex;

		// Token: 0x0400056D RID: 1389
		internal Dictionary<int, int> Templates;
	}
}
