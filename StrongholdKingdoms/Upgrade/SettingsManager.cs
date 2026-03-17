using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Kingdoms;

namespace Upgrade
{
	// Token: 0x02000030 RID: 48
	internal class SettingsManager
	{
		// Token: 0x060001F7 RID: 503 RVA: 0x00047E44 File Offset: 0x00046044
		public static string[] CreateSettingsFolders()
		{
			string[] array = new string[]
			{
				"TradeInfo",
				"VillageLayouts"
			};
			foreach (string str in array)
			{
				Directory.CreateDirectory(ControlForm.SettingsFolder + str);
			}
			string path = ControlForm.SettingsFolder + "\\Password.txt";
			if (!File.Exists(path))
			{
				File.Create(path);
			}
			SettingsManager.CreateNotificationsEmail(false, null, null, null);
			string path2 = ControlForm.SettingsFolder + "\\AutomaticActions.txt";
			string[] array3 = new string[]
			{
				"-Login",
				"-Load scouts settings",
				"-Load trade settings",
				"-Start scouting",
				"-Start trading",
				"-Load Researches",
				"Start Researching",
				"-Load troops recruiting settings",
				"-Recruit troops",
				"-Load Banquets",
				"-Banquet",
				"-Load Radar settings",
				"-Monitor attacks",
				"-Load village layouts",
				"-Start building villages",
				"-Start regulate popularity",
				"-Load castle repair settings",
				"-Load Predator Settings"
			};
			if (!File.Exists(path2))
			{
				File.WriteAllLines(path2, array3);
				return array3;
			}
			string[] collection = File.ReadAllLines(path2);
			List<string> list = new List<string>(collection);
			bool flag = false;
			string[] array4 = array3;
			for (int j = 0; j < array4.Length; j++)
			{
				string action = array4[j];
				if (!list.Any((string a) => a.EndsWith(action.TrimStart(new char[]
				{
					'-'
				}))))
				{
					list.Add(action);
					flag = true;
				}
			}
			string[] array5 = list.Distinct<string>().ToArray<string>();
			if (flag)
			{
				File.WriteAllLines(path2, array5);
			}
			return array5;
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x00048004 File Offset: 0x00046204
		public static void CreateNotificationsEmail(bool overWrite, string from = null, string fromPw = null, string to = null)
		{
			string path = ControlForm.SettingsFolder + "\\NotificationEmail.txt";
			if (!File.Exists(path) || overWrite)
			{
				File.WriteAllLines(path, new string[]
				{
					"From:" + from,
					"Password:" + fromPw,
					"To:" + to
				});
			}
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x000090AA File Offset: 0x000072AA
		public static string GetSettingsFilePath(string fileName, bool creadeDir = true, params string[] subfolders)
		{
			return SettingsManager.GetCommonSettingsPath(fileName, RemoteServices.Instance.UserName, creadeDir, subfolders);
		}

		// Token: 0x060001FA RID: 506 RVA: 0x000090BE File Offset: 0x000072BE
		public static string GetSettingsFilePathAnotherUser(string fileName, string username, bool creadeDir = true, params string[] subfolders)
		{
			return SettingsManager.GetCommonSettingsPath(fileName, username, creadeDir, subfolders);
		}

		// Token: 0x060001FB RID: 507 RVA: 0x00048064 File Offset: 0x00046264
		private static string GetCommonSettingsPath(string fileName, string username, bool creadeDir, string[] subfolders)
		{
			string path = Path.Combine(ControlForm.SettingsFolder, username);
			string text = Path.Combine(path, Program.WorldName);
			string text2 = text;
			if (subfolders != null)
			{
				foreach (string path2 in subfolders)
				{
					text2 = Path.Combine(text2, path2);
				}
			}
			if (creadeDir)
			{
				Directory.CreateDirectory(text2);
			}
			return Path.Combine(text2, fileName);
		}

		// Token: 0x060001FC RID: 508 RVA: 0x000480C8 File Offset: 0x000462C8
		public static void CopyDataGridViewContent(DataGridView grid, IEnumerable<string> listOfVillages, int id)
		{
			DataGridViewRow dataGridViewRow = null;
			foreach (object obj in ((IEnumerable)grid.Rows))
			{
				DataGridViewRow dataGridViewRow2 = (DataGridViewRow)obj;
				if (ControlForm.GetId(dataGridViewRow2.Cells[0].Value.ToString()) == id)
				{
					dataGridViewRow = dataGridViewRow2;
					break;
				}
			}
			if (dataGridViewRow != null)
			{
				IEnumerable<int> source = from v in listOfVillages
				select ControlForm.GetId(v);
				for (int i = 0; i < grid.Rows.Count; i++)
				{
					int id2 = ControlForm.GetId(grid[0, i].Value.ToString());
					if (source.Contains(id2))
					{
						for (int j = 1; j < grid.ColumnCount; j++)
						{
							grid[j, i].Value = dataGridViewRow.Cells[j].Value;
						}
					}
				}
				return;
			}
			ControlForm controlForm = DX.ControlForm;
			if (controlForm == null)
			{
				return;
			}
			controlForm.Log(string.Format("Error in CopySettings. Sample settings {0} not found in {1}", id, grid.Name), ControlForm.Tab.Main, false);
		}

		// Token: 0x060001FD RID: 509 RVA: 0x00048208 File Offset: 0x00046408
		public static void CopyPredatorGridContent(DataGridView grid, IEnumerable<string> listOfVillages, string sample)
		{
			DataGridViewRow dataGridViewRow = null;
			foreach (object obj in ((IEnumerable)grid.Rows))
			{
				DataGridViewRow dataGridViewRow2 = (DataGridViewRow)obj;
				if (dataGridViewRow2.Cells[1].Value.ToString() == sample)
				{
					dataGridViewRow = dataGridViewRow2;
				}
			}
			if (dataGridViewRow != null)
			{
				for (int i = 0; i < grid.Rows.Count; i++)
				{
					string value = grid[1, i].Value.ToString();
					if (listOfVillages.Contains(value))
					{
						for (int j = 2; j < grid.ColumnCount; j++)
						{
							grid[j, i].Value = dataGridViewRow.Cells[j].Value;
						}
					}
				}
				return;
			}
			ControlForm controlForm = DX.ControlForm;
			if (controlForm == null)
			{
				return;
			}
			controlForm.Log("Error in CopySettings. Sample settings " + sample + " not found in " + grid.Name, ControlForm.Tab.Main, false);
		}

		// Token: 0x060001FE RID: 510 RVA: 0x00048318 File Offset: 0x00046518
		public static void RemoveVillageFromGrid(DataGridView grid, int villageId)
		{
			DataGridViewRow dataGridViewRow = null;
			foreach (object obj in ((IEnumerable)grid.Rows))
			{
				DataGridViewRow dataGridViewRow2 = (DataGridViewRow)obj;
				if (ControlForm.GetId(dataGridViewRow2.Cells[0].Value.ToString()) == villageId)
				{
					dataGridViewRow = dataGridViewRow2;
					break;
				}
			}
			if (dataGridViewRow != null)
			{
				grid.Rows.Remove(dataGridViewRow);
				return;
			}
			DX.ControlForm.Log(string.Format("{0}: {1} {2}", LNG.Print("Settings not found for village"), villageId, grid.Name), ControlForm.Tab.Main, true);
		}
	}
}
