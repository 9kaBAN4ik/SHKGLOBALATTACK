using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms;

namespace Upgrade.Services
{
	// Token: 0x0200005A RID: 90
	internal class BanquetService : ABaseService
	{
		// Token: 0x060002CE RID: 718 RVA: 0x00009708 File Offset: 0x00007908
		public BanquetService(Log logMethod, DataGridView settingsGrid) : base(logMethod)
		{
			this._settings = settingsGrid;
			this.UpdateBanquetLevels();
		}

		// Token: 0x060002CF RID: 719 RVA: 0x00009725 File Offset: 0x00007925
		private void LLog(string message, bool isError = false)
		{
			this.Log(message, ControlForm.Tab.Banquetting, isError);
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x0004DEE8 File Offset: 0x0004C0E8
		public void InsertVillage(int index, string name)
		{
			this._settings.Rows.Insert(index, new object[]
			{
				name,
				this._levels[this._levels.Length - 1]
			});
			DataGridViewComboBoxCell dataGridViewComboBoxCell = (DataGridViewComboBoxCell)this._settings[1, index];
			dataGridViewComboBoxCell.DataSource = this._levels;
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0004DF44 File Offset: 0x0004C144
		public void RemoveVillage(int id)
		{
			try
			{
				DataGridViewRow dataGridViewRow = null;
				foreach (object obj in ((IEnumerable)this._settings.Rows))
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
					this._settings.Rows.Remove(dataGridViewRow);
				}
			}
			catch (Exception ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.Banquetting);
			}
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0004DFF0 File Offset: 0x0004C1F0
		private void UpdateBanquetLevels()
		{
			byte research_Craftsmanship = GameEngine.Instance.World.UserResearchData.Research_Craftsmanship;
			if (this._banquettingResearch == (int)research_Craftsmanship)
			{
				return;
			}
			this.LLog(string.Format("{0} {1}", LNG.Print("Init banquets to level"), research_Craftsmanship), false);
			this._banquettingResearch = (int)research_Craftsmanship;
			this._levels = new string[(int)(research_Craftsmanship + 1)];
			this._levels[0] = "No Banquet";
			for (byte b = 1; b < research_Craftsmanship + 1; b += 1)
			{
				this._levels[(int)b] = b.ToString();
			}
			foreach (object obj in ((IEnumerable)this._settings.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				((DataGridViewComboBoxCell)dataGridViewRow.Cells[1]).DataSource = this._levels;
				((DataGridViewComboBoxCell)dataGridViewRow.Cells[1]).Value = this._levels[this._levels.Length - 1];
			}
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x0004E110 File Offset: 0x0004C310
		public override void ConcreteAction()
		{
			this.UpdateBanquetLevels();
			foreach (object obj in ((IEnumerable)this._settings.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				int id = ControlForm.GetId(dataGridViewRow.Cells[0].Value.ToString());
				VillageMap village = GameEngine.Instance.getVillage(id);
				string villageName = GameEngine.Instance.World.getVillageName(id);
				if (village == null)
				{
					this.LLog(LNG.Print("Village wasn't loaded") + ": " + villageName, true);
				}
				else
				{
					string text = ((DataGridViewComboBoxCell)dataGridViewRow.Cells[1]).Value.ToString();
					if (!(text == "No Banquet"))
					{
						village.banqueting.updateLevels(true);
						int num = Convert.ToInt32(text);
						for (int i = num; i <= this._banquettingResearch; i++)
						{
							if (village.banqueting.HoldBanquet(i - 1, village))
							{
								this.LLog(string.Format("{0} ({1}) {2} {3}", new object[]
								{
									Banqueting.getBanquetName((Banqueting.Level)(i - 1)),
									i,
									LNG.Print("banquet played in village"),
									id
								}), false);
								if (base.RandomSleepOrExit(1000, 2000))
								{
									return;
								}
							}
						}
						if (base.RandomSleepOrExit(750, 1500))
						{
							break;
						}
					}
				}
			}
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0004E2B8 File Offset: 0x0004C4B8
		internal override void TranslateUI()
		{
			this._settings.Columns[0].HeaderText = SK.Text("GENERIC_Village", "Village");
			this._settings.Columns[1].HeaderText = SK.Text("ADVICE_Header_Banquet", "Banquets");
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x0004E310 File Offset: 0x0004C510
		internal void Save()
		{
			string[] array = new string[this._settings.Rows.Count];
			for (int i = 0; i < this._settings.Rows.Count; i++)
			{
				array[i] = string.Format("{0},{1}", this._settings[0, i].Value, this._settings[1, i].Value);
			}
			string settingsFilePath = SettingsManager.GetSettingsFilePath("Banquets.txt", true, new string[0]);
			File.WriteAllLines(settingsFilePath, array);
			this.LLog(LNG.Print("Settings are saved to") + " " + settingsFilePath, false);
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x0004E3B4 File Offset: 0x0004C5B4
		internal void Load()
		{
			try
			{
				string settingsFilePath = SettingsManager.GetSettingsFilePath("Banquets.txt", false, new string[0]);
				if (!File.Exists(settingsFilePath))
				{
					this.LLog(LNG.Print("File doesn't exist") + ": " + settingsFilePath, false);
				}
				else
				{
					string[] array = File.ReadAllLines(settingsFilePath);
					foreach (string text in array)
					{
						string[] array3 = text.Split(new char[]
						{
							','
						});
						for (int j = 0; j < this._settings.Rows.Count; j++)
						{
							string item = this._settings[0, j].Value.ToString();
							if (ControlForm.GetId(item) == ControlForm.GetId(array3[0]))
							{
								this._settings[1, j].Value = array3[1];
								break;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.Banquetting);
			}
		}

		// Token: 0x04000434 RID: 1076
		private int _banquettingResearch = -1;

		// Token: 0x04000435 RID: 1077
		private DataGridView _settings;

		// Token: 0x04000436 RID: 1078
		private string[] _levels;
	}
}
