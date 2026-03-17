using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms;

namespace Upgrade.Services
{
	// Token: 0x0200008A RID: 138
	internal class ResearchService : ABaseService
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x060003A1 RID: 929 RVA: 0x00009C5B File Offset: 0x00007E5B
		// (set) Token: 0x060003A2 RID: 930 RVA: 0x00009C63 File Offset: 0x00007E63
		public int RankUpMode { get; set; }

		// Token: 0x060003A3 RID: 931 RVA: 0x000541A4 File Offset: 0x000523A4
		public ResearchService(Log log, ListBox listBox_Queue, ListBox listBox_ResearchList, TextBox textBox_CurrentResearch) : base(log)
		{
			this._listBox_Queue = listBox_Queue;
			this._listBox_ResearchList = listBox_ResearchList;
			this.TranslateUI();
			this._textBox_CurrentResearch = textBox_CurrentResearch;
			this._listBox_Queue.MouseDown += this.listBox_MouseDown;
			this._listBox_Queue.MouseMove += this.listBox_MouseMove;
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x00054204 File Offset: 0x00052404
		internal override void TranslateUI()
		{
			List<int> list = new List<int>();
			list.AddRange(ResearchData.industryResearchLayout);
			list.AddRange(ResearchData.militaryResearchLayout);
			list.AddRange(ResearchData.farmingResearchLayout);
			if (GameEngine.Instance.LocalWorldData.Alternate_Ruleset != 1)
			{
				list.AddRange(ResearchData.educationResearchLayout);
			}
			else
			{
				list.AddRange(ResearchData.educationResearchLayout2);
			}
			this._listBox_ResearchList.Items.Clear();
			foreach (int num in list)
			{
				if ((int)GameEngine.Instance.World.userResearchData.research[num] >= ResearchData.getNumLevels(num))
				{
					this.LLog("Skip research as maxed: " + ResearchData.getResearchName(num), false);
				}
				else
				{
					this._listBox_ResearchList.Items.Add(string.Format("{0} - {1}", num, ResearchData.getResearchName(num)));
				}
			}
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x00009C6C File Offset: 0x00007E6C
		private void LLog(string message, bool isError = false)
		{
			this.Log(message, ControlForm.Tab.Research, isError);
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x0005430C File Offset: 0x0005250C
		public void Load()
		{
			string settingsFilePath = SettingsManager.GetSettingsFilePath("Researches.txt", false, new string[0]);
			if (!File.Exists(settingsFilePath))
			{
				this.LLog(LNG.Print("File doesn't exist") + ": " + settingsFilePath, false);
				return;
			}
			string[] array = File.ReadAllLines(settingsFilePath);
			this._listBox_Queue.Items.Clear();
			ListBox.ObjectCollection items = this._listBox_Queue.Items;
			object[] items2 = array;
			items.AddRange(items2);
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x00009C7C File Offset: 0x00007E7C
		public void Save()
		{
			File.WriteAllLines(SettingsManager.GetSettingsFilePath("Researches.txt", true, new string[0]), this._listBox_Queue.Items.Cast<string>().ToArray<string>());
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x0005437C File Offset: 0x0005257C
		private void listBox_MouseDown(object sender, MouseEventArgs e)
		{
			ListBox listBox = sender as ListBox;
			int num = listBox.IndexFromPoint(e.Location);
			if (num == -1)
			{
				return;
			}
			this.bufferIndex = num;
			this.bufferItem = listBox.Items[num];
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x000543BC File Offset: 0x000525BC
		private void listBox_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left)
			{
				return;
			}
			ListBox listBox = sender as ListBox;
			int num = listBox.IndexFromPoint(e.Location);
			if (num == this.bufferIndex || num == -1)
			{
				return;
			}
			listBox.Items.RemoveAt(this.bufferIndex);
			this.bufferIndex = num;
			listBox.Items.Insert(num, this.bufferItem);
		}

		// Token: 0x060003AA RID: 938 RVA: 0x00054424 File Offset: 0x00052624
		public override void ConcreteAction()
		{
			if (GameEngine.Instance.World.userResearchData.researchingType != -1)
			{
				TextBox textBox_CurrentResearch = this._textBox_CurrentResearch;
				if (textBox_CurrentResearch != null)
				{
					textBox_CurrentResearch.BeginInvoke(new MethodInvoker(delegate()
					{
						if (GameEngine.Instance.World.userResearchData.researchingType != -1)
						{
							this._textBox_CurrentResearch.Text = ResearchData.getResearchName(GameEngine.Instance.World.userResearchData.researchingType);
						}
					}));
				}
			}
			if (this._listBox_Queue.Items.Count == 0)
			{
				return;
			}
			if (this.RankUpMode == 2)
			{
				this.RankUp();
			}
			if (GameEngine.Instance.World.userResearchData.researchingType != -1 && !GameEngine.Instance.World.userResearchData.canDoMoreResearch(GameEngine.Instance.World.isAccountPremium()))
			{
				this.LLog(LNG.Print("The queue is full:)"), false);
				return;
			}
			int research_points = GameEngine.Instance.World.userResearchData.research_points;
			if (research_points == 0 || (GameEngine.Instance.World.userResearchData.research_queueEntries != null && GameEngine.Instance.World.userResearchData.research_queueEntries.Length == research_points))
			{
				this.LLog(LNG.Print("No research points!"), true);
				if (this.RankUpMode == 1)
				{
					this.RankUp();
				}
				return;
			}
			try
			{
				int j;
				int i;
				for (i = 0; i < this._listBox_Queue.Items.Count; i = j + 1)
				{
					int researchType = this.GetResearchType(this._listBox_Queue.Items[i].ToString());
					string researchName = ResearchData.getResearchName(researchType);
					int num = 0;
					bool flag = false;
					if (GameEngine.Instance.World.userResearchData.isResearchStepOpen(researchType, (int)GameEngine.Instance.World.userResearchData.research[researchType], GameEngine.Instance.World.getRank(), GameEngine.Instance.World.getRankSubLevel(), ref num, ref flag, GameEngine.Instance.LocalWorldData.EraWorld))
					{
						GameEngine.Instance.World.doResearch(researchType);
						this.LLog(researchName + " " + LNG.Print("research started!:)"), false);
						this._listBox_Queue.BeginInvoke(new MethodInvoker(delegate()
						{
							this._listBox_Queue.Items.RemoveAt(i);
						}));
						break;
					}
					this.LLog(string.Format("Skip research as unavailable: {0}; rankNeeded {1}; special {2}", researchName, num, flag), false);
					j = i;
				}
				this.Save();
			}
			catch (Exception ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.Research);
			}
		}

		// Token: 0x060003AB RID: 939 RVA: 0x000546AC File Offset: 0x000528AC
		private void UpgradeRankCallBack(UpgradeRank_ReturnType returnData)
		{
			if (returnData.Success)
			{
				GameEngine.Instance.World.setHonourData(returnData.currentHonourLevel, returnData.currentHonourRate);
				InterfaceMgr.Instance.setHonour(returnData.currentHonourLevel, returnData.rank);
				GameEngine.Instance.World.setRanking(returnData.rank, returnData.rankSubLevel);
				GameEngine.Instance.World.setResearchData(returnData.researchData);
				InterfaceMgr.Instance.researchDataChanged(returnData.researchData);
				GameEngine.Instance.World.setPoints(returnData.currentPoints);
				if (returnData.rank == 1 && GameEngine.Instance.World.getTutorialStage() == 7)
				{
					GameEngine.Instance.World.forceTutorialToBeShown();
				}
				GameEngine.Instance.World.LastUpdatedCrowns = DateTime.MinValue;
				return;
			}
			this.LLog(ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID), true);
		}

		// Token: 0x060003AC RID: 940 RVA: 0x000547A4 File Offset: 0x000529A4
		private bool IsNextRankAvailable(int rank, int rankSubLevel)
		{
			double currentHonour = GameEngine.Instance.World.getCurrentHonour();
			double num = (double)GameEngine.Instance.LocalWorldData.ranks_HonourPerLevel[rank];
			if (rank != 21)
			{
				if (rank == 22)
				{
					num = Rankings.calcHonourForCrownPrince(rankSubLevel);
				}
			}
			else if (rankSubLevel >= 24)
			{
				num = 10000000.0;
			}
			return currentHonour >= num;
		}

		// Token: 0x060003AD RID: 941 RVA: 0x00054800 File Offset: 0x00052A00
		private void RankUp()
		{
			try
			{
				int rankSubLevel = GameEngine.Instance.World.getRankSubLevel();
				int rank = GameEngine.Instance.World.getRank();
				if (!this.IsNextRankAvailable(rank, rankSubLevel))
				{
					this.LLog(LNG.Print("Not enough honour to rank up!"), false);
				}
				else
				{
					RemoteServices.Instance.set_UpgradeRank_UserCallBack(new RemoteServices.UpgradeRank_UserCallBack(this.UpgradeRankCallBack));
					RemoteServices.Instance.UpgradeRank(rank, rankSubLevel);
				}
			}
			catch (Exception ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.Research);
			}
		}

		// Token: 0x060003AE RID: 942 RVA: 0x00054888 File Offset: 0x00052A88
		internal static int CountResearchesInQueue()
		{
			ResearchData userResearchData = GameEngine.Instance.World.userResearchData;
			int num = 0;
			if (userResearchData.researchingType >= 0)
			{
				num++;
			}
			if (userResearchData.research_queueEntries != null)
			{
				int[] research_queueEntries = userResearchData.research_queueEntries;
				foreach (int num2 in research_queueEntries)
				{
					if (num2 >= 0)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x060003AF RID: 943 RVA: 0x00009CA9 File Offset: 0x00007EA9
		internal int GetResearchType(string researchName)
		{
			return int.Parse(researchName.Replace(" ", "").Split(new char[]
			{
				'-'
			})[0]);
		}

		// Token: 0x040004F6 RID: 1270
		private const string SettingsFileName = "Researches.txt";

		// Token: 0x040004F7 RID: 1271
		private ListBox _listBox_Queue;

		// Token: 0x040004F8 RID: 1272
		private ListBox _listBox_ResearchList;

		// Token: 0x040004F9 RID: 1273
		private TextBox _textBox_CurrentResearch;

		// Token: 0x040004FA RID: 1274
		private object bufferItem;

		// Token: 0x040004FB RID: 1275
		private int bufferIndex;
	}
}
