using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Kingdoms;

namespace Upgrade.Services
{
	// Token: 0x02000065 RID: 101
	internal class DownloadVillagesService : ABaseService
	{
		// Token: 0x06000308 RID: 776 RVA: 0x0000935B File Offset: 0x0000755B
		public DownloadVillagesService(Log log) : base(log)
		{
		}

		// Token: 0x06000309 RID: 777 RVA: 0x000098D5 File Offset: 0x00007AD5
		private void LLog(string message, bool isError = false)
		{
			this.Log(message, ControlForm.Tab.Refresh, isError);
		}

		// Token: 0x0600030A RID: 778 RVA: 0x0004FCA4 File Offset: 0x0004DEA4
		public override void ConcreteAction()
		{
			this.LLog(LNG.Print("Start refreshing villages"), false);
			List<int> list = new List<int>(this.SelectedVillages);
			foreach (int num in list.Shuffle<int>())
			{
				VillageMap village = GameEngine.Instance.getVillage(num);
				if (village == null || this.IsFullRefreshAllowed || GameEngine.Instance.World.isCapital(num))
				{
					this.ForeGroundRefresh(num);
				}
				if (base.RandomSleepOrExit(2535, 3576))
				{
					break;
				}
			}
		}

		// Token: 0x0600030B RID: 779 RVA: 0x0004FD4C File Offset: 0x0004DF4C
		private void ForeGroundRefresh(int villageId)
		{
			DX.ControlForm.Invoke(new MethodInvoker(delegate()
			{
				this.LLog(string.Format("{0}: {1}", LNG.Print("Downloading village"), villageId), false);
				InterfaceMgr.Instance.setVillageNameBar(villageId);
				GameEngine.Instance.forceDownloadCurrentVillage();
			}));
		}

		// Token: 0x0600030C RID: 780 RVA: 0x0004FD84 File Offset: 0x0004DF84
		internal void Save(ListBox list)
		{
			string settingsFilePath = SettingsManager.GetSettingsFilePath("RefreshIgnoreList.txt", true, new string[0]);
			List<int> list2 = new List<int>();
			for (int i = 0; i < list.Items.Count; i++)
			{
				if (!list.GetSelected(i))
				{
					list2.Add(ControlForm.GetId(list.Items[i].ToString()));
				}
			}
			string stringOfIds = DX.GetStringOfIds(list2);
			File.WriteAllText(settingsFilePath, stringOfIds);
			this.LLog(LNG.Print("Saved to") + ": " + settingsFilePath, false);
		}

		// Token: 0x0600030D RID: 781 RVA: 0x0004FE10 File Offset: 0x0004E010
		internal void Load(ListBox list)
		{
			string settingsFilePath = SettingsManager.GetSettingsFilePath("RefreshIgnoreList.txt", false, new string[0]);
			if (!File.Exists(settingsFilePath))
			{
				this.LLog(LNG.Print("File doesn't exist") + ": " + settingsFilePath, false);
				return;
			}
			string setting = File.ReadAllText(settingsFilePath);
			List<int> listOfIds = DX.GetListOfIds(setting);
			this.ClearIgnoreList(ref listOfIds);
			for (int i = 0; i < list.Items.Count; i++)
			{
				int id = ControlForm.GetId(list.Items[i].ToString());
				if (listOfIds.Contains(id))
				{
					list.SetSelected(i, false);
					this.SelectedVillages.Remove(id);
				}
			}
			this.LLog(LNG.Print("Settings loaded from") + ": " + settingsFilePath, false);
		}

		// Token: 0x0600030E RID: 782 RVA: 0x0004FED4 File Offset: 0x0004E0D4
		private void ClearIgnoreList(ref List<int> ignoreList)
		{
			List<int> listOfUserVillagesAndCapitals = GameEngine.Instance.World.getListOfUserVillagesAndCapitals(RemoteServices.Instance.UserID);
			List<int> list = new List<int>();
			foreach (int item in ignoreList)
			{
				if (!listOfUserVillagesAndCapitals.Contains(item))
				{
					list.Add(item);
				}
			}
			if (list.Count > 0)
			{
				foreach (int item2 in list)
				{
					ignoreList.Remove(item2);
				}
				string settingsFilePath = SettingsManager.GetSettingsFilePath("RefreshIgnoreList.txt", true, new string[0]);
				File.WriteAllText(settingsFilePath, DX.GetStringOfIds(ignoreList));
			}
		}

		// Token: 0x0600030F RID: 783 RVA: 0x000098E5 File Offset: 0x00007AE5
		internal void AddVillage(int villageId)
		{
			this.SelectedVillages.Add(villageId);
		}

		// Token: 0x06000310 RID: 784 RVA: 0x00007CE0 File Offset: 0x00005EE0
		internal override void TranslateUI()
		{
		}

		// Token: 0x0400045E RID: 1118
		internal bool IsFullRefreshAllowed;

		// Token: 0x0400045F RID: 1119
		private const string RefreshListFileName = "RefreshIgnoreList.txt";
	}
}
