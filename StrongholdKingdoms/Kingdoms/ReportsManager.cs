using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000472 RID: 1138
	public class ReportsManager
	{
		// Token: 0x17000229 RID: 553
		// (get) Token: 0x06002902 RID: 10498 RVA: 0x0001E47E File Offset: 0x0001C67E
		public static ReportsManager instance
		{
			get
			{
				if (ReportsManager.m_instance == null)
				{
					ReportsManager.m_instance = new ReportsManager();
				}
				return ReportsManager.m_instance;
			}
		}

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x06002903 RID: 10499 RVA: 0x0001E496 File Offset: 0x0001C696
		// (set) Token: 0x06002904 RID: 10500 RVA: 0x0001E49E File Offset: 0x0001C69E
		public SparseArray storedReportHeaders
		{
			get
			{
				return this.m_storedReportHeaders;
			}
			set
			{
				this.m_storedReportHeaders = value;
			}
		}

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x06002905 RID: 10501 RVA: 0x0001E4A7 File Offset: 0x0001C6A7
		// (set) Token: 0x06002906 RID: 10502 RVA: 0x0001E4AF File Offset: 0x0001C6AF
		public SparseArray storedReportBodies
		{
			get
			{
				return this.m_storedReportBodies;
			}
			set
			{
				this.m_storedReportBodies = value;
			}
		}

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x06002907 RID: 10503 RVA: 0x0001E4B8 File Offset: 0x0001C6B8
		// (set) Token: 0x06002908 RID: 10504 RVA: 0x0001E4C0 File Offset: 0x0001C6C0
		public SparseArray storedReportData
		{
			get
			{
				return this.m_storedReportData;
			}
			set
			{
				this.m_storedReportData = value;
			}
		}

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x06002909 RID: 10505 RVA: 0x0001E4C9 File Offset: 0x0001C6C9
		// (set) Token: 0x0600290A RID: 10506 RVA: 0x0001E4D1 File Offset: 0x0001C6D1
		public int readFilterTypeDownloaded
		{
			get
			{
				return this.m_readFilterTypeDownloaded;
			}
			set
			{
				this.m_readFilterTypeDownloaded = value;
			}
		}

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x0600290B RID: 10507 RVA: 0x0001E4DA File Offset: 0x0001C6DA
		public ReportFilterList Filters
		{
			get
			{
				return this.filters;
			}
		}

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x0600290C RID: 10508 RVA: 0x0001E4E2 File Offset: 0x0001C6E2
		// (set) Token: 0x0600290D RID: 10509 RVA: 0x0001E4EA File Offset: 0x0001C6EA
		public bool ShowReadMessages
		{
			get
			{
				return this.showReadMessages;
			}
			set
			{
				this.showReadMessages = value;
			}
		}

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x0600290E RID: 10510 RVA: 0x0001E4F3 File Offset: 0x0001C6F3
		// (set) Token: 0x0600290F RID: 10511 RVA: 0x0001E4FB File Offset: 0x0001C6FB
		public bool ShowParishAttacks
		{
			get
			{
				return this.showParishAttacks;
			}
			set
			{
				this.showParishAttacks = value;
			}
		}

		// Token: 0x17000231 RID: 561
		// (get) Token: 0x06002910 RID: 10512 RVA: 0x0001E504 File Offset: 0x0001C704
		// (set) Token: 0x06002911 RID: 10513 RVA: 0x0001E50C File Offset: 0x0001C70C
		public bool ShowVillageLost
		{
			get
			{
				return this.showVillageLost;
			}
			set
			{
				this.showVillageLost = value;
			}
		}

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x06002912 RID: 10514 RVA: 0x0001E515 File Offset: 0x0001C715
		// (set) Token: 0x06002913 RID: 10515 RVA: 0x0001E51D File Offset: 0x0001C71D
		public bool ShowForwardedMessagesOnly
		{
			get
			{
				return this.showForwardedMessagesOnly;
			}
			set
			{
				this.showForwardedMessagesOnly = value;
			}
		}

		// Token: 0x06002914 RID: 10516 RVA: 0x001F3630 File Offset: 0x001F1830
		public void deleteReport(long reportToDelete)
		{
			long[] reportsToDelete = new long[]
			{
				reportToDelete
			};
			RemoteServices.Instance.DeleteReports(reportsToDelete);
			foreach (object obj in this.m_storedReportHeaders)
			{
				ReportListItem reportListItem = (ReportListItem)obj;
				if (Math.Abs(reportListItem.reportID) == reportToDelete)
				{
					this.m_storedReportHeaders[Math.Abs(reportListItem.reportID)] = null;
					break;
				}
			}
		}

		// Token: 0x06002915 RID: 10517 RVA: 0x0001E526 File Offset: 0x0001C726
		public object getReportData(long reportID)
		{
			return this.m_storedReportData[reportID];
		}

		// Token: 0x06002916 RID: 10518 RVA: 0x0001E534 File Offset: 0x0001C734
		public void setReportData(object reportData, long reportID)
		{
			this.m_storedReportData[reportID] = reportData;
		}

		// Token: 0x06002917 RID: 10519 RVA: 0x001F36C0 File Offset: 0x001F18C0
		public void setReportAlreadyRead(long reportID)
		{
			UniversalDebugLog.Log("set read " + reportID.ToString() + " / " + this.m_storedReportBodies.Count.ToString());
			((GetReport_ReturnType)this.m_storedReportBodies[reportID]).wasAlreadyRead = true;
		}

		// Token: 0x06002918 RID: 10520 RVA: 0x001F3714 File Offset: 0x001F1914
		public long findHighestReportID()
		{
			long num = -1L;
			foreach (object obj in this.m_storedReportHeaders)
			{
				ReportListItem reportListItem = (ReportListItem)obj;
				if (Math.Abs(reportListItem.reportID) > num)
				{
					num = Math.Abs(reportListItem.reportID);
				}
			}
			return num;
		}

		// Token: 0x06002919 RID: 10521 RVA: 0x001F3784 File Offset: 0x001F1984
		public List<ReportListItem> getReportEntries(DateTime serverTime)
		{
			List<ReportListItem> list = new List<ReportListItem>();
			foreach (object obj in this.storedReportHeaders)
			{
				ReportListItem reportListItem = (ReportListItem)obj;
				TimeSpan timeDiff = serverTime - reportListItem.reportTime;
				if ((this.showReadMessages || !reportListItem.readStatus) && (!this.showForwardedMessagesOnly || (reportListItem.reportAboutUser != null && reportListItem.reportAboutUser.Length != 0)) && !this.isReportTypeFiltered(reportListItem))
				{
					ReportListItem item = reportListItem;
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x0600291A RID: 10522 RVA: 0x001F382C File Offset: 0x001F1A2C
		private bool isReportTypeFiltered(ReportListItem item)
		{
			bool result = false;
			switch (item.reportType)
			{
			case 1:
			case 2:
			case 24:
			case 25:
			case 58:
			case 59:
			case 60:
			case 61:
			case 123:
			case 124:
			case 125:
			case 132:
				if (GameEngine.Instance.World.isCapital(item.sourceVillage))
				{
					if (!this.ShowParishAttacks)
					{
						result = true;
					}
				}
				else if (!this.filters.attacks)
				{
					result = true;
				}
				break;
			case 3:
			case 4:
			case 62:
			case 63:
			case 64:
			case 65:
			case 79:
			case 86:
			case 87:
			case 88:
			case 89:
			case 90:
				if (!this.filters.defense)
				{
					result = true;
				}
				break;
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
				result = true;
				break;
			case 13:
			case 14:
			case 15:
			case 16:
			case 46:
			case 47:
			case 48:
			case 49:
				if (!this.filters.vassals)
				{
					result = true;
				}
				break;
			case 17:
			case 18:
			case 19:
				if (!this.filters.reinforcements)
				{
					result = true;
				}
				break;
			case 20:
				if (!this.filters.research)
				{
					result = true;
				}
				break;
			case 21:
			case 22:
			case 26:
			case 27:
			case 54:
			case 55:
			case 56:
			case 57:
			case 121:
			case 122:
			case 126:
			case 133:
				if (!this.filters.scouting)
				{
					result = true;
				}
				break;
			case 23:
				if (!this.filters.foraging)
				{
					result = true;
				}
				break;
			case 28:
			case 51:
			case 52:
			case 53:
			case 74:
			case 75:
				if (!this.filters.elections)
				{
					result = true;
				}
				break;
			case 29:
			case 30:
			case 31:
			case 32:
			case 33:
			case 34:
			case 35:
			case 36:
			case 37:
			case 38:
			case 39:
			case 40:
				result = true;
				break;
			case 50:
			case 107:
			case 108:
			case 109:
			case 110:
			case 111:
			case 112:
			case 115:
			case 116:
			case 117:
			case 118:
				if (!this.filters.factions)
				{
					result = true;
				}
				break;
			case 66:
			case 67:
			case 68:
			case 69:
			case 70:
			case 71:
			case 72:
			case 91:
			case 103:
			case 104:
			case 105:
			case 106:
				if (!this.filters.religion)
				{
					result = true;
				}
				break;
			case 73:
			case 78:
				if (!this.filters.trade)
				{
					result = true;
				}
				break;
			case 76:
			case 77:
			case 99:
				if (!this.filters.cards)
				{
					result = true;
				}
				break;
			case 80:
			case 81:
			case 82:
			case 83:
			case 84:
			case 85:
				if (!this.filters.enemyWarnings)
				{
					result = true;
				}
				break;
			case 92:
				if (!this.filters.achievements)
				{
					result = true;
				}
				break;
			case 93:
			case 94:
			case 95:
			case 96:
				if (!this.filters.buyVillages)
				{
					result = true;
				}
				break;
			case 100:
			case 101:
				if (!this.filters.quests)
				{
					result = true;
				}
				break;
			case 102:
			case 129:
			case 130:
			case 131:
			case 136:
			case 140:
			case 141:
				if (!this.filters.spins)
				{
					result = true;
				}
				break;
			case 113:
			case 114:
			case 120:
			case 134:
			case 135:
				if (!this.filters.house)
				{
					result = true;
				}
				break;
			case 127:
			case 128:
				if (!this.ShowVillageLost)
				{
					result = true;
				}
				break;
			}
			return result;
		}

		// Token: 0x0600291B RID: 10523 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void loadReports()
		{
		}

		// Token: 0x0600291C RID: 10524 RVA: 0x001F3C3C File Offset: 0x001F1E3C
		public void saveReports()
		{
			int userID = RemoteServices.Instance.UserID;
			string settingsPath = GameEngine.getSettingsPath(true);
			try
			{
				FileInfo fileInfo = new FileInfo(string.Concat(new string[]
				{
					settingsPath,
					"\\ReportData-",
					userID.ToString(),
					"-",
					GameEngine.Instance.World.GetGlobalWorldID().ToString(),
					".dat"
				}));
				fileInfo.IsReadOnly = false;
			}
			catch (Exception)
			{
			}
			FileStream fileStream = null;
			BinaryWriter binaryWriter = null;
			try
			{
				fileStream = new FileStream(string.Concat(new string[]
				{
					settingsPath,
					"\\ReportData-",
					userID.ToString(),
					"-",
					GameEngine.Instance.World.GetGlobalWorldID().ToString(),
					".dat"
				}), FileMode.Create);
				binaryWriter = new BinaryWriter(fileStream);
				int value = -1;
				binaryWriter.Write(value);
				int count = this.m_storedReportHeaders.Count;
				binaryWriter.Write(count);
				foreach (object obj in this.m_storedReportHeaders)
				{
					ReportListItem reportListItem = (ReportListItem)obj;
					long index = Math.Abs(reportListItem.reportID);
					binaryWriter.Write(reportListItem.reportID);
					binaryWriter.Write(reportListItem.otherUser);
					binaryWriter.Write(reportListItem.reportAboutUser);
					binaryWriter.Write(reportListItem.folderID);
					binaryWriter.Write(reportListItem.sourceVillage);
					binaryWriter.Write(reportListItem.targetVillage);
					binaryWriter.Write(reportListItem.reportType);
					binaryWriter.Write(reportListItem.readStatus);
					binaryWriter.Write(reportListItem.successStatus);
					long ticks = reportListItem.reportTime.Ticks;
					binaryWriter.Write(ticks);
					if (this.m_storedReportBodies[index] == null)
					{
						binaryWriter.Write(false);
					}
					else
					{
						binaryWriter.Write(true);
						GetReport_ReturnType getReport_ReturnType = (GetReport_ReturnType)this.m_storedReportBodies[index];
						binaryWriter.Write(getReport_ReturnType.otherUser);
						binaryWriter.Write(getReport_ReturnType.reportAboutUser);
						binaryWriter.Write(getReport_ReturnType.reportAboutUserID);
						long ticks2 = getReport_ReturnType.reportTime.Ticks;
						binaryWriter.Write(ticks2);
						binaryWriter.Write(getReport_ReturnType.reportType);
						binaryWriter.Write(getReport_ReturnType.successStatus);
						binaryWriter.Write(getReport_ReturnType.snapshotAvailable);
						binaryWriter.Write(getReport_ReturnType.wasAlreadyRead);
						binaryWriter.Write(getReport_ReturnType.genericData1);
						binaryWriter.Write(getReport_ReturnType.attackingVillage);
						binaryWriter.Write(getReport_ReturnType.defendingVillage);
						binaryWriter.Write(getReport_ReturnType.genericData2);
						binaryWriter.Write(getReport_ReturnType.genericData3);
						binaryWriter.Write(getReport_ReturnType.genericData4);
						binaryWriter.Write(getReport_ReturnType.genericData5);
						binaryWriter.Write(getReport_ReturnType.genericData6);
						binaryWriter.Write(getReport_ReturnType.genericData7);
						binaryWriter.Write(getReport_ReturnType.genericData8);
						binaryWriter.Write(getReport_ReturnType.genericData9);
						binaryWriter.Write(getReport_ReturnType.genericData10);
						binaryWriter.Write(getReport_ReturnType.genericData11);
						binaryWriter.Write(getReport_ReturnType.genericData12);
						binaryWriter.Write(getReport_ReturnType.genericData13);
						binaryWriter.Write(getReport_ReturnType.genericData14);
						binaryWriter.Write(getReport_ReturnType.genericData15);
						binaryWriter.Write(getReport_ReturnType.genericData16);
						binaryWriter.Write(getReport_ReturnType.genericData17);
						binaryWriter.Write(getReport_ReturnType.genericData18);
						binaryWriter.Write(getReport_ReturnType.genericData19);
						binaryWriter.Write(getReport_ReturnType.genericData20);
						binaryWriter.Write(getReport_ReturnType.genericData21);
						binaryWriter.Write(getReport_ReturnType.genericData22);
						binaryWriter.Write(getReport_ReturnType.genericData23);
						binaryWriter.Write(getReport_ReturnType.genericData24);
						binaryWriter.Write(getReport_ReturnType.genericData25);
						binaryWriter.Write(getReport_ReturnType.genericData26);
						binaryWriter.Write(getReport_ReturnType.genericData27);
						binaryWriter.Write(getReport_ReturnType.genericData28);
						binaryWriter.Write(getReport_ReturnType.genericData29);
						binaryWriter.Write(getReport_ReturnType.genericData30);
						binaryWriter.Write(getReport_ReturnType.genericData31);
						binaryWriter.Write(getReport_ReturnType.genericData32);
						binaryWriter.Write(getReport_ReturnType.genericData33);
						binaryWriter.Write(getReport_ReturnType.genericData34);
						binaryWriter.Write(getReport_ReturnType.genericData35);
					}
					if (this.m_storedReportData[index] == null)
					{
						binaryWriter.Write(false);
					}
					else
					{
						binaryWriter.Write(true);
						ViewBattle_ReturnType viewBattle_ReturnType = (ViewBattle_ReturnType)this.m_storedReportData[index];
						if (viewBattle_ReturnType.castleMapSnapshot == null)
						{
							binaryWriter.Write(0);
						}
						else
						{
							binaryWriter.Write(viewBattle_ReturnType.castleMapSnapshot.Length);
							binaryWriter.Write(viewBattle_ReturnType.castleMapSnapshot, 0, viewBattle_ReturnType.castleMapSnapshot.Length);
						}
						if (viewBattle_ReturnType.damageMapSnapshot == null)
						{
							binaryWriter.Write(0);
						}
						else
						{
							binaryWriter.Write(viewBattle_ReturnType.damageMapSnapshot.Length);
							binaryWriter.Write(viewBattle_ReturnType.damageMapSnapshot, 0, viewBattle_ReturnType.damageMapSnapshot.Length);
						}
						if (viewBattle_ReturnType.castleTroopsSnapshot == null)
						{
							binaryWriter.Write(0);
						}
						else
						{
							binaryWriter.Write(viewBattle_ReturnType.castleTroopsSnapshot.Length);
							binaryWriter.Write(viewBattle_ReturnType.castleTroopsSnapshot, 0, viewBattle_ReturnType.castleTroopsSnapshot.Length);
						}
						if (viewBattle_ReturnType.attackMapSnapshot == null)
						{
							binaryWriter.Write(0);
						}
						else
						{
							binaryWriter.Write(viewBattle_ReturnType.attackMapSnapshot.Length);
							binaryWriter.Write(viewBattle_ReturnType.attackMapSnapshot, 0, viewBattle_ReturnType.attackMapSnapshot.Length);
						}
						binaryWriter.Write(viewBattle_ReturnType.keepLevel);
						binaryWriter.Write(viewBattle_ReturnType.landType);
						if (viewBattle_ReturnType.defenderResearchData == null)
						{
							binaryWriter.Write(false);
						}
						else
						{
							binaryWriter.Write(true);
							viewBattle_ReturnType.defenderResearchData.Write(binaryWriter);
						}
						if (viewBattle_ReturnType.attackerResearchData == null)
						{
							binaryWriter.Write(false);
						}
						else
						{
							binaryWriter.Write(true);
							viewBattle_ReturnType.attackerResearchData.Write(binaryWriter);
						}
					}
				}
				binaryWriter.Close();
				fileStream.Close();
			}
			catch (Exception ex)
			{
				try
				{
					if (binaryWriter != null)
					{
						binaryWriter.Close();
					}
				}
				catch (Exception)
				{
				}
				try
				{
					if (fileStream != null)
					{
						fileStream.Close();
					}
				}
				catch (Exception)
				{
				}
				MyMessageBox.Show("A problem occurred saving 'ReportData.data'\n\n" + ex.ToString(), "Data Save Error");
			}
		}

		// Token: 0x0600291D RID: 10525 RVA: 0x001F42E0 File Offset: 0x001F24E0
		public void ClearAllReports()
		{
			this.filters = new ReportFilterList();
			this.showReadMessages = true;
			this.showParishAttacks = true;
			this.ShowForwardedMessagesOnly = false;
			if (!this.initialLoad)
			{
				this.saveReports();
			}
			this.initialLoad = true;
			if (this.storedReportHeaders != null)
			{
				this.storedReportHeaders.Clear();
			}
			if (this.storedReportBodies != null)
			{
				this.storedReportBodies.Clear();
			}
			if (this.storedReportData != null)
			{
				this.storedReportData.Clear();
			}
		}

		// Token: 0x0600291E RID: 10526 RVA: 0x001F435C File Offset: 0x001F255C
		public void filterAll()
		{
			this.Filters.attacks = false;
			this.Filters.defense = false;
			this.Filters.enemyWarnings = false;
			this.Filters.reinforcements = false;
			this.Filters.scouting = false;
			this.Filters.foraging = false;
			this.Filters.trade = false;
			this.Filters.vassals = false;
			this.Filters.religion = false;
			this.Filters.research = false;
			this.Filters.elections = false;
			this.Filters.factions = false;
			this.Filters.cards = false;
			this.Filters.quests = false;
			this.Filters.spins = false;
			this.Filters.achievements = false;
			this.ShowParishAttacks = false;
			this.ShowVillageLost = false;
		}

		// Token: 0x0600291F RID: 10527 RVA: 0x001F4438 File Offset: 0x001F2638
		public bool areFiltersClear()
		{
			return this.filters.attacks && this.filters.defense && this.filters.enemyWarnings && this.filters.reinforcements && this.filters.scouting && this.filters.foraging && this.filters.trade && this.filters.vassals && this.filters.religion && this.filters.research && this.filters.elections && this.filters.factions && this.filters.cards && this.filters.achievements && this.filters.buyVillages && this.filters.quests && this.filters.spins && this.showReadMessages && this.showParishAttacks && !this.showForwardedMessagesOnly;
		}

		// Token: 0x06002920 RID: 10528 RVA: 0x001F4564 File Offset: 0x001F2764
		public static string getReportTitle(ReportListItem item)
		{
			int reportType = (int)item.reportType;
			string text = "";
			if (item.otherUser != null)
			{
				text = item.otherUser;
			}
			if (item.reportAboutUser != null && item.reportAboutUser.Length > 0)
			{
				string reportAboutUser = item.reportAboutUser;
			}
			else
			{
				string userName = RemoteServices.Instance.UserName;
			}
			int targetVillage = item.targetVillage;
			int sourceVillage = item.sourceVillage;
			string text2 = "";
			switch (reportType)
			{
			case 1:
				if (GameEngine.Instance.World.isRegionCapital(sourceVillage) && GameEngine.Instance.World.isRegionCapital(targetVillage))
				{
					text2 += SK.Text("ReportsPanel_Attack_parish_parish", "Your Parish Attacks Parish : ");
					text2 += GameEngine.Instance.World.getVillageName(targetVillage);
				}
				else if (text.Length == 0)
				{
					text2 = (GameEngine.Instance.World.isRegionCapital(sourceVillage) ? (text2 + SK.Text("ReportsPanel_Attack_Player_parish", "Your Parish Attacks Player : ")) : (GameEngine.Instance.World.isCountyCapital(sourceVillage) ? (text2 + SK.Text("ReportsPanel_Attack_Player_county", "Your County Attacks Player : ")) : (GameEngine.Instance.World.isProvinceCapital(sourceVillage) ? (text2 + SK.Text("ReportsPanel_Attack_Player_province", "Your Province Attacks Player : ")) : ((!GameEngine.Instance.World.isCountryCapital(sourceVillage)) ? (text2 + SK.Text("ReportsPanel_Attack_Player", "Your Troops Attack Player : ")) : (text2 + SK.Text("ReportsPanel_Attack_Player_country", "Your Country Attacks Player : "))))));
					text2 = ((targetVillage < 0) ? (text2 + SK.Text("ReportsPanel_An_Empty_Village", "An empty village")) : (text2 + GameEngine.Instance.World.getVillageName(targetVillage)));
				}
				else
				{
					text2 += SK.Text("ReportsPanel_Attack_Village", "Your Troops Attack Village : ");
					text2 += text;
				}
				break;
			case 2:
				if (text.Length == 0)
				{
					text2 += SK.Text("ReportsPanel_Parish_Attack_Player", "Your Parish Attacks Player : ");
					text2 = ((targetVillage < 0) ? (text2 + SK.Text("ReportsPanel_An_Empty_Village", "An empty village")) : (text2 + GameEngine.Instance.World.getVillageName(targetVillage)));
				}
				else
				{
					text2 += SK.Text("ReportsPanel_Parish_Attack_Village", "Your Parish Attacks Village : ");
					text2 += text;
				}
				break;
			case 3:
				text2 = (GameEngine.Instance.World.isRegionCapital(targetVillage) ? (text2 + SK.Text("ReportsPanel_Player_Attacks_parish", "Player attacks your Parish : ")) : (GameEngine.Instance.World.isCountyCapital(targetVillage) ? (text2 + SK.Text("ReportsPanel_Player_Attacks_county", "Player attacks your County : ")) : (GameEngine.Instance.World.isProvinceCapital(targetVillage) ? (text2 + SK.Text("ReportsPanel_Player_Attacks_province", "Player attacks your Province : ")) : ((!GameEngine.Instance.World.isCountryCapital(targetVillage)) ? (text2 + SK.Text("ReportsPanel_Player_Attacks", "Player attacks your castle : ")) : (text2 + SK.Text("ReportsPanel_Player_Attacks_country", "Player attacks your Country : "))))));
				text2 = ((text.Length != 0) ? (text2 + text) : (text2 + SK.Text("ReportsPanel_Unknown_Player", "An Unknown Player")));
				break;
			case 4:
				text2 += SK.Text("ReportsPanel_Parish_Attacks", "Parish attacks your castle : ");
				text2 = ((text.Length != 0) ? (text2 + text) : (text2 + SK.Text("ReportsPanel_Unknown_Player", "An Unknown Player")));
				break;
			case 15:
				text2 = text2 + SK.Text("ReportsPanel_Lost_Vassal", "You have lost a vassal : ") + text;
				break;
			case 16:
				text2 += SK.Text("ReportsPanel_No_Liege_Lord", "You no longer have a liege lord");
				break;
			case 17:
				text2 = text2 + SK.Text("ReportsPanel_Reinforcements_Arrived", "Reinforcements have arrived from : ") + text;
				break;
			case 18:
				if (text == "")
				{
					text = SK.Text("ReportsPanel_An_Empty_Village", "An empty village");
				}
				text2 = text2 + SK.Text("ReportsPanel_Reinforcements_Returned", "Reinforcements have returned from : ") + text;
				break;
			case 19:
				text2 = text2 + SK.Text("ReportsPanel_Reinforcements_Retrieved", "Reinforcements have been retrieved by : ") + text;
				break;
			case 20:
				text2 += SK.Text("ReportsPanel_Research_Complete", "Research Task Complete");
				break;
			case 21:
				if (text.Length == 0)
				{
					text2 += SK.Text("ReportsPanel_Scouted_Out", "Your Scouts Scout-Out Village : ");
					text2 = ((targetVillage < 0) ? (text2 + SK.Text("ReportsPanel_An_Empty_Village", "An empty village")) : (text2 + GameEngine.Instance.World.getVillageName(targetVillage)));
				}
				else
				{
					text2 += SK.Text("ReportsPanel_Scouts", "Your Scouts Scout-Out Player : ");
					text2 += text;
				}
				break;
			case 22:
				text2 += SK.Text("ReportsPanel_Scouted", "Player scouts your castle : ");
				text2 = ((text.Length != 0) ? (text2 + text) : (text2 + SK.Text("ReportsPanel_Unknown_Player", "An Unknown Player")));
				break;
			case 23:
				text2 += SK.Text("ReportsPanel_Stash_Foraged", "Stash Foraged");
				break;
			case 24:
				text2 = ((!GameEngine.Instance.World.isRegionCapital(sourceVillage)) ? ((!GameEngine.Instance.World.isCountyCapital(sourceVillage)) ? ((!GameEngine.Instance.World.isProvinceCapital(sourceVillage)) ? ((!GameEngine.Instance.World.isCountryCapital(sourceVillage)) ? (text2 + SK.Text("ReportsPanel_Attack_Bandit", "Your Troops Attack a Bandit Camp")) : (text2 + SK.Text("ReportsPanel_Attack_Bandit_country", "Your Country Attacks a Bandit Camp"))) : (text2 + SK.Text("ReportsPanel_Attack_Bandit_province", "Your Province Attacks a Bandit Camp"))) : (text2 + SK.Text("ReportsPanel_Attack_Bandit_county", "Your County Attacks a Bandit Camp"))) : (text2 + SK.Text("ReportsPanel_Attack_Bandit_parish", "Your Parish Attacks a Bandit Camp")));
				break;
			case 25:
				text2 = ((!GameEngine.Instance.World.isRegionCapital(sourceVillage)) ? ((!GameEngine.Instance.World.isCountyCapital(sourceVillage)) ? ((!GameEngine.Instance.World.isProvinceCapital(sourceVillage)) ? ((!GameEngine.Instance.World.isCountryCapital(sourceVillage)) ? (text2 + SK.Text("ReportsPanel_Attack_Wolf_Lair", "Your Troops Attack a Wolf Lair")) : (text2 + SK.Text("ReportsPanel_Attack_Wolf_Lair_country", "Your Country Attacks a Wolf Lair"))) : (text2 + SK.Text("ReportsPanel_Attack_Wolf_Lair_province", "Your Province Attacks a Wolf Lair"))) : (text2 + SK.Text("ReportsPanel_Attack_Wolf_Lair_county", "Your County Attacks a Wolf Lair"))) : (text2 + SK.Text("ReportsPanel_Attack_Wolf_Lair_parish", "Your Parish Attacks a Wolf Lair")));
				break;
			case 26:
				text2 += SK.Text("ReportsPanel_Bandit_Camp_Scouted", "Bandit Camp Scouted");
				break;
			case 27:
				text2 += SK.Text("ReportsPanel_Wolf_Lair_Scouted", "Wolf Lair Scouted");
				break;
			case 28:
				text2 = ((text.Length <= 0) ? (text2 + SK.Text("ReportsPanel_No_Parish_Winner", "No Winner of Parish Election")) : (text2 + SK.Text("ReportsPanel_New_Steward", "New Steward in Parish : ") + text));
				break;
			case 29:
				text2 = ((text.Length <= 0) ? (text2 + "Spy Report - Command 'Player 1'") : (text2 + "Spy Report - Command 'Player 1' of " + text));
				break;
			case 30:
				text2 = ((text.Length <= 0) ? (text2 + "Spy Report - Command 'Village 1'") : (text2 + "Spy Report - Command 'Village 1' of " + text));
				break;
			case 31:
				text2 = ((text.Length <= 0) ? (text2 + "Spy Report - Command 'Castle 1'") : (text2 + "Spy Report - Command 'Castle 1' of " + text));
				break;
			case 32:
				text2 = ((text.Length <= 0) ? (text2 + "Spy Report - Command 'Army 1'") : (text2 + "Spy Report - Command 'Army 1' of " + text));
				break;
			case 33:
				text2 = ((text.Length <= 0) ? (text2 + "Spy Report - Command 'Village 2'") : (text2 + "Spy Report - Command 'Village 2' of " + text));
				break;
			case 34:
				text2 = ((text.Length <= 0) ? (text2 + "Spy Report - Command 'Castle 2'") : (text2 + "Spy Report - Command 'Castle 2' of " + text));
				break;
			case 35:
				text2 = ((text.Length <= 0) ? (text2 + "Spy Report - Command 'Player 2'") : (text2 + "Spy Report - Command 'Player 2' of " + text));
				break;
			case 36:
				text2 = ((text.Length <= 0) ? (text2 + "Spy Report - Command 'Castle 3'") : (text2 + "Spy Report - Command 'Castle 3' of " + text));
				break;
			case 37:
				text2 = ((text.Length <= 0) ? (text2 + "Spy Report - Command 'Army 2'") : (text2 + "Spy Report - Command 'Army 2' of " + text));
				break;
			case 38:
				text2 = ((text.Length <= 0) ? (text2 + "Spy Report - Command 'Castle 4'") : (text2 + "Spy Report - Command 'Castle 4' of " + text));
				break;
			case 39:
				text2 += "Spy Report - Command Failed ";
				break;
			case 40:
				text2 += "Spy Report - No Spies Found ";
				break;
			case 46:
				text2 = text2 + SK.Text("ReportsPanel_Liege_Lord_Offer_FRom", "Offer to be your liege lord from : ") + text;
				break;
			case 47:
				text2 = text2 + SK.Text("ReportsPanel_Vassal_Request_Accepted", "Vassal Request accepted by : ") + text;
				break;
			case 48:
				text2 = text2 + SK.Text("ReportsPanel_Vassal_request_Declined", "Vassal Request declined by : ") + text;
				break;
			case 49:
				text2 = text2 + SK.Text("ReportsPanel_Liege_Lord_Offer_Withdrawn", "Liege lord offer withdrawn by : ") + text;
				break;
			case 50:
				text2 += SK.Text("ReportsPanel_Faction_Invite", "Faction Invite");
				break;
			case 53:
				text2 = ((text.Length <= 0) ? (text2 + SK.Text("ReportsPanel_No_County_Winner", "No Winner of County Election")) : (text2 + SK.Text("ReportsPanel_New_Sheriff", "New Sheriff in County : ") + text));
				break;
			case 54:
				text2 += SK.Text("ReportsPanel_Rat_Castle_Scouted", "Rat's Castle Scouted");
				break;
			case 55:
				text2 += SK.Text("ReportsPanel_Snake_Castle_Scouted", "Snake's Castle Scouted");
				break;
			case 56:
				text2 += SK.Text("ReportsPanel_Pig_Castle_Scouted", "Pig's Castle Scouted");
				break;
			case 57:
				text2 += SK.Text("ReportsPanel_Wolf_Castle_Scouted", "Wolf's Castle Scouted");
				break;
			case 58:
				text2 = ((!GameEngine.Instance.World.isRegionCapital(sourceVillage)) ? ((!GameEngine.Instance.World.isCountyCapital(sourceVillage)) ? ((!GameEngine.Instance.World.isProvinceCapital(sourceVillage)) ? ((!GameEngine.Instance.World.isCountryCapital(sourceVillage)) ? (text2 + SK.Text("ReportsPanel_Attack_Rat", "Your Troops Attack the Rat")) : (text2 + SK.Text("ReportsPanel_Attack_Rat_country", "Your Country Attacks the Rat"))) : (text2 + SK.Text("ReportsPanel_Attack_Rat_province", "Your Province Attacks the Rat"))) : (text2 + SK.Text("ReportsPanel_Attack_Rat_county", "Your County Attacks the Rat"))) : (text2 + SK.Text("ReportsPanel_Attack_Rat_parish", "Your Parish Attacks the Rat")));
				break;
			case 59:
				text2 = ((!GameEngine.Instance.World.isRegionCapital(sourceVillage)) ? ((!GameEngine.Instance.World.isCountyCapital(sourceVillage)) ? ((!GameEngine.Instance.World.isProvinceCapital(sourceVillage)) ? ((!GameEngine.Instance.World.isCountryCapital(sourceVillage)) ? (text2 + SK.Text("ReportsPanel_Attack_Snake", "Your Troops Attack the Snake")) : (text2 + SK.Text("ReportsPanel_Attack_Snake_country", "Your Country Attacks the Snake"))) : (text2 + SK.Text("ReportsPanel_Attack_Snake_province", "Your Province Attacks the Snake"))) : (text2 + SK.Text("ReportsPanel_Attack_Snake_county", "Your County Attacks the Snake"))) : (text2 + SK.Text("ReportsPanel_Attack_Snake_parish", "Your Parish Attacks the Snake")));
				break;
			case 60:
				text2 = ((!GameEngine.Instance.World.isRegionCapital(sourceVillage)) ? ((!GameEngine.Instance.World.isCountyCapital(sourceVillage)) ? ((!GameEngine.Instance.World.isProvinceCapital(sourceVillage)) ? ((!GameEngine.Instance.World.isCountryCapital(sourceVillage)) ? (text2 + SK.Text("ReportsPanel_Attack_Pig", "Your Troops Attack the Pig")) : (text2 + SK.Text("ReportsPanel_Attack_Pig_country", "Your Country Attacks the Pig"))) : (text2 + SK.Text("ReportsPanel_Attack_Pig_province", "Your Province Attacks the Pig"))) : (text2 + SK.Text("ReportsPanel_Attack_Pig_county", "Your County Attacks the Pig"))) : (text2 + SK.Text("ReportsPanel_Attack_Pig_parish", "Your Parish Attacks the Pig")));
				break;
			case 61:
				text2 = ((!GameEngine.Instance.World.isRegionCapital(sourceVillage)) ? ((!GameEngine.Instance.World.isCountyCapital(sourceVillage)) ? ((!GameEngine.Instance.World.isProvinceCapital(sourceVillage)) ? ((!GameEngine.Instance.World.isCountryCapital(sourceVillage)) ? (text2 + SK.Text("ReportsPanel_Attack_Wolf", "Your Troops Attack the Wolf")) : (text2 + SK.Text("ReportsPanel_Attack_Wolf_country", "Your Country Attacks the Wolf"))) : (text2 + SK.Text("ReportsPanel_Attack_Wolf_province", "Your Province Attacks the Wolf"))) : (text2 + SK.Text("ReportsPanel_Attack_Wolf_county", "Your County Attacks the Wolf"))) : (text2 + SK.Text("ReportsPanel_Attack_Wolf_parish", "Your Parish Attacks the Wolf")));
				break;
			case 62:
				text2 += SK.Text("ReportsPanel_Rat_Attacks", "The Rat Attacks");
				break;
			case 63:
				text2 += SK.Text("ReportsPanel_Snake_Attacks", "The Snake Attacks");
				break;
			case 64:
				text2 += SK.Text("ReportsPanel_Pig_Attacks", "The Pig Attacks");
				break;
			case 65:
				text2 += SK.Text("ReportsPanel_Wolf_Attacks", "The Wolf Attacks");
				break;
			case 66:
				text2 += SK.Text("ReportsPanel_Monk_Influence", "Monk Influence");
				break;
			case 67:
				text2 += SK.Text("ReportsPanel_Monk_Restoration", "Monk Restoration");
				break;
			case 68:
			case 105:
				text2 += SK.Text("ReportsPanel_Monk_Interdiction", "Monk Interdiction");
				break;
			case 69:
			case 104:
				text2 += SK.Text("ReportsPanel_Monk_Inquisition", "Monk Inquisition");
				break;
			case 70:
			case 91:
				text2 += SK.Text("ReportsPanel_Monk_Excommunication", "Monk Excommunication");
				break;
			case 71:
			case 103:
				text2 += SK.Text("ReportsPanel_Monk_Absolution", "Monk Absolution");
				break;
			case 72:
				text2 += SK.Text("ReportsPanel_Monk_Blessing", "Monk Blessing");
				break;
			case 73:
				text2 = text2 + SK.Text("ReportsPanel_Goods_Sent_From", "Goods Sent From : ") + text;
				break;
			case 74:
				text2 = ((text.Length <= 0) ? (text2 + SK.Text("ReportsPanel_No_Province_Winner", "No Winner of Province Election")) : (text2 + SK.Text("ReportsPanel_New_Governor", "New Governor in Province : ") + text));
				break;
			case 75:
				text2 = ((text.Length <= 0) ? (text2 + SK.Text("ReportsPanel_No_Country_Winner", "No Winner of Country Election")) : (text2 + SK.Text("ReportsPanel_New_Monarch", "New Monarch in Country : ") + text));
				break;
			case 76:
				text2 += SK.Text("ReportsPanel_Card_Expires", "Card Expires");
				break;
			case 77:
				text2 += SK.Text("ReportsPanel_Instant_Card_Played", "Instant Card Played");
				break;
			case 78:
				text2 += SK.Text("ReportsPanel_Auto_Trade_Sent", "Auto Trade Sent");
				break;
			case 79:
				text2 += SK.Text("ReportsPanel_Enemy_Attacks", "The Enemy Attacks");
				break;
			case 80:
				text2 += SK.Text("ReportsPanel_Enemy_Arrive", "The enemy arrives in our parish!");
				break;
			case 81:
				text2 += SK.Text("ReportsPanel_Enemy_First", "Enemy probes castle defences");
				break;
			case 82:
				text2 += SK.Text("ReportsPanel_Enemy_Normal", "Enemy launches attack");
				break;
			case 83:
				text2 += SK.Text("ReportsPanel_Enemy_Prefinal", "Enemy troops advancing in large numbers");
				break;
			case 84:
				text2 += SK.Text("ReportsPanel_Enemy_Final", "Enemy launches final attack");
				break;
			case 85:
				text2 += SK.Text("ReportsPanel_Enemy_Leave", "The enemy is vanquished!");
				break;
			case 86:
				text2 += SK.Text("ReportsPanel_Diplomacy", "The enemy attack was stopped by Diplomacy");
				break;
			case 87:
				text2 += SK.Text("ReportsPanel_Rat_Diplomacy", "The Rat's attack was stopped by Diplomacy");
				break;
			case 88:
				text2 += SK.Text("ReportsPanel_Snake_Diplomacy", "The Snake's attack was stopped by Diplomacy");
				break;
			case 89:
				text2 += SK.Text("ReportsPanel_Pig_Diplomacy", "The Pig's attack was stopped by Diplomacy");
				break;
			case 90:
				text2 += SK.Text("ReportsPanel_Wolf_Diplomacy", "The Wolf's attack was stopped by Diplomacy");
				break;
			case 92:
				text2 += SK.Text("ReportsPanel_Achievement_Attained", "Achievement Attained");
				break;
			case 93:
				text2 += SK.Text("ReportsPanel_Buy_Village_Success", "Village Charter Purchased");
				break;
			case 94:
			case 95:
			case 96:
				text2 += SK.Text("ReportsPanel_Buy_Village_Failed", "Village Charter Purchase Failed");
				break;
			case 99:
				text2 += SK.Text("ReportsPanel_Card_Used", "Card Used and Expired");
				break;
			case 100:
				text2 += SK.Text("ReportsPanel_QuestCompleted", "Quest Completed");
				break;
			case 101:
				text2 += SK.Text("ReportsPanel_Quest Failed", "Quest Failed");
				break;
			case 102:
				text2 += SK.Text("Reports_Spins", "Wheel Spin Prize");
				break;
			case 106:
				text2 += SK.Text("ReportsPanel_Monk_Ended", "Monk Interdiction Ended");
				break;
			case 107:
				text2 = text2 + SK.Text("ReportsPanel_Faction_Member_Join", "New Faction Member") + " : " + text;
				break;
			case 108:
				text2 = ((!(text == "")) ? (text2 + SK.Text("ReportsPanel_Faction_Member_Leave", "Faction Member Leaves") + " : " + text) : (text2 + SK.Text("ReportsPanel_Faction_Member_Leave_Self", "You are no longer a member of a faction")));
				break;
			case 109:
				text2 = ((!(text == "")) ? (text2 + SK.Text("ReportsPanel_Faction_Member_Dismissed", "Faction Member Dismissed") + " : " + text) : (text2 + SK.Text("ReportsPanel_Faction_Member_Dismissed_Self", "You have been dismissed from your faction")));
				break;
			case 110:
				text2 += SK.Text("ReportsPanel_Faction_Promotion", "Faction Promotion");
				break;
			case 111:
				text2 += SK.Text("ReportsPanel_Faction_Demotion", "Faction Demotion");
				break;
			case 112:
				text2 += SK.Text("ReportsPanel_Faction_Relationship_Change", "Faction Relationship Change");
				break;
			case 113:
				text2 += SK.Text("ReportsPanel_Faction_House_Change", "House Membership Change");
				break;
			case 114:
				text2 += SK.Text("ReportsPanel_House_Relationship_Change", "House Relationship Change");
				break;
			case 115:
				text2 = text2 + SK.Text("ReportsPanel_Faction_Application", "A Player has applied to your Faction") + " : " + text;
				break;
			case 116:
				text2 += SK.Text("ReportsPanel_Faction_Application_accepted", "Your faction application has been accepted");
				break;
			case 117:
				text2 += SK.Text("ReportsPanel_Faction_Application_rejected", "Your faction application has been rejected");
				break;
			case 118:
				text2 += SK.Text("ReportsPanel_Faction_Member_Dismissed_Self", "You have been dismissed from your faction");
				break;
			case 120:
				text2 += SK.Text("ReportsPanel_Faction_Glory_Obtained", "Your house has been awarded glory points");
				break;
			case 121:
				text2 += SK.Text("ReportsPanel_Paladin_Castle_Scouted", "Paladin's Castle Scouted");
				break;
			case 122:
				text2 += SK.Text("ReportsPanel_Paladin_Castle_Scouted", "Paladin's Castle Scouted");
				break;
			case 123:
				text2 = ((!GameEngine.Instance.World.isRegionCapital(sourceVillage)) ? ((!GameEngine.Instance.World.isCountyCapital(sourceVillage)) ? ((!GameEngine.Instance.World.isProvinceCapital(sourceVillage)) ? ((!GameEngine.Instance.World.isCountryCapital(sourceVillage)) ? (text2 + SK.Text("ReportsPanel_Attack_Paladin", "Your Troops Attack the Paladin's Castle")) : (text2 + SK.Text("ReportsPanel_Attack_Paladin_country", "Your Country Attacks the Paladin's Castle"))) : (text2 + SK.Text("ReportsPanel_Attack_Paladin_province", "Your Province Attacks the Paladin's Castle"))) : (text2 + SK.Text("ReportsPanel_Attack_Paladin_county", "Your County Attacks the Paladin's Castle"))) : (text2 + SK.Text("ReportsPanel_Attack_Paladin_parish", "Your Parish Attacks the Paladin's Castle")));
				break;
			case 124:
				text2 = ((!GameEngine.Instance.World.isRegionCapital(sourceVillage)) ? ((!GameEngine.Instance.World.isCountyCapital(sourceVillage)) ? ((!GameEngine.Instance.World.isProvinceCapital(sourceVillage)) ? ((!GameEngine.Instance.World.isCountryCapital(sourceVillage)) ? (text2 + SK.Text("ReportsPanel_Attack_Paladin", "Your Troops Attack the Paladin's Castle")) : (text2 + SK.Text("ReportsPanel_Attack_Paladin_country", "Your Country Attacks the Paladin's Castle"))) : (text2 + SK.Text("ReportsPanel_Attack_Paladin_province", "Your Province Attacks the Paladin's Castle"))) : (text2 + SK.Text("ReportsPanel_Attack_Paladin_county", "Your County Attacks the Paladin's Castle"))) : (text2 + SK.Text("ReportsPanel_Attack_Paladin_parish", "Your Parish Attacks the Paladin's Castle")));
				break;
			case 125:
				text2 += SK.Text("ReportsPanel_Attack_Treasure_Castle", "Your Troops Attack a Treasure Castle");
				break;
			case 126:
				text2 += SK.Text("ReportsPanel_Treasure_Castle_Scouted", "Treasure Castle Scouted");
				break;
			case 127:
			case 128:
				text2 += SK.Text("Reports_VillageLost", "Village Lost");
				break;
			case 129:
				text2 += SK.Text("Reports_AI_Spins", "Wheel Spin Bonus from AI Razing");
				break;
			case 130:
				text2 += SK.Text("Reports_Forage_Spins", "Wheel Spin Bonus from Foraging");
				break;
			case 131:
				text2 += SK.Text("Reports_AI_Spins_capture", "Wheel Spin Bonus from AI Capture");
				break;
			case 132:
				text2 += SK.Text("ReportsPanel_Attack_Royal_twer", "Your Troops Attack a Royal Tower");
				break;
			case 133:
				text2 += SK.Text("ReportsPanel_Royal_Tower_Scouted", "Royal Tower Scouted");
				break;
			case 134:
				text2 += SK.Text("ReportsPanel_Royal_Tower_Gained", "Your house has captured a Royal Tower");
				break;
			case 135:
				text2 += SK.Text("ReportsPanel_Royal_Tower_Lost", "Royal Tower Lost!");
				break;
			case 136:
				text2 += SK.Text("Reports_Heretic_Spins", "Wheel Spin Bonus from Player Razing");
				break;
			case 140:
				text2 += SK.Text("Reports_Contest_Awarded", "Prize Won");
				break;
			case 141:
				text2 += SK.Text("Reports_Contest_Claimed", "Prize Claimed");
				break;
			}
			return text2;
		}

		// Token: 0x06002921 RID: 10529 RVA: 0x001F5ED0 File Offset: 0x001F40D0
		public void moveReports(string destFolderName)
		{
			long reportFolderID = this.getReportFolderID(destFolderName);
			if (this.m_moveArray == null || this.m_moveArray.Length == 0)
			{
				return;
			}
			RemoteServices.Instance.MoveReports(this.m_moveArray, reportFolderID);
			long[] moveArray = this.m_moveArray;
			foreach (long index in moveArray)
			{
				if (this.storedReportHeaders[index] != null)
				{
					ReportListItem reportListItem = (ReportListItem)this.storedReportHeaders[index];
					reportListItem.folderID = reportFolderID;
					this.storedReportHeaders[index] = reportListItem;
				}
			}
		}

		// Token: 0x06002922 RID: 10530 RVA: 0x001F5F60 File Offset: 0x001F4160
		public void deleteReportFolder(string folderName, int mode)
		{
			long reportFolderID = this.getReportFolderID(folderName);
			if (reportFolderID >= 0L)
			{
				RemoteServices.Instance.deleteReportFolder(reportFolderID, mode);
				if (mode == 3)
				{
					foreach (object obj in this.storedReportHeaders)
					{
						ReportListItem reportListItem = (ReportListItem)obj;
						if (reportListItem.folderID == reportFolderID)
						{
							reportListItem.folderID = -1L;
						}
					}
				}
			}
		}

		// Token: 0x06002923 RID: 10531 RVA: 0x0001E543 File Offset: 0x0001C743
		public long getReportFolderID()
		{
			return -1L;
		}

		// Token: 0x06002924 RID: 10532 RVA: 0x001F5FE0 File Offset: 0x001F41E0
		public long getReportFolderID(string folderName)
		{
			if (this.folderNamesList != null)
			{
				int num = 0;
				string[] array = this.folderNamesList;
				foreach (string a in array)
				{
					if (a == folderName)
					{
						return this.folderIDList[num];
					}
					num++;
				}
			}
			return -1L;
		}

		// Token: 0x06002925 RID: 10533 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void manageReportFoldersCallback(ManageReportFolders_ReturnType returnData)
		{
		}

		// Token: 0x06002926 RID: 10534 RVA: 0x001F602C File Offset: 0x001F422C
		public void reportListCallback(GetReportsList_ReturnType returnData)
		{
			if (returnData.Success)
			{
				int count = returnData.reports.Count;
				for (int i = 0; i < count; i++)
				{
					if (this.storedReportHeaders[Math.Abs(returnData.reports[i].reportID)] == null)
					{
						this.storedReportHeaders[Math.Abs(returnData.reports[i].reportID)] = returnData.reports[i];
					}
				}
			}
			this.m_getReportListUICallback(returnData);
		}

		// Token: 0x06002927 RID: 10535 RVA: 0x0001E547 File Offset: 0x0001C747
		public void init(RemoteServices.GetReportsList_UserCallBack getReportsListUICallback)
		{
			this.m_getReportListUICallback = getReportsListUICallback;
			RemoteServices.Instance.set_GetReportsList_UserCallBack(new RemoteServices.GetReportsList_UserCallBack(this.reportListCallback));
		}

		// Token: 0x04003232 RID: 12850
		private static ReportsManager m_instance;

		// Token: 0x04003233 RID: 12851
		private SparseArray m_storedReportHeaders = new SparseArray();

		// Token: 0x04003234 RID: 12852
		private SparseArray m_storedReportBodies = new SparseArray();

		// Token: 0x04003235 RID: 12853
		private SparseArray m_storedReportData = new SparseArray();

		// Token: 0x04003236 RID: 12854
		private int m_readFilterTypeDownloaded = 3;

		// Token: 0x04003237 RID: 12855
		public ReportsManager.ReportsComparer reportsMainComparer = new ReportsManager.ReportsComparer();

		// Token: 0x04003238 RID: 12856
		private ReportFilterList filters = new ReportFilterList();

		// Token: 0x04003239 RID: 12857
		private bool showReadMessages = true;

		// Token: 0x0400323A RID: 12858
		private bool showParishAttacks = true;

		// Token: 0x0400323B RID: 12859
		private bool showVillageLost = true;

		// Token: 0x0400323C RID: 12860
		private bool showForwardedMessagesOnly;

		// Token: 0x0400323D RID: 12861
		public bool HasNewReports;

		// Token: 0x0400323E RID: 12862
		private bool initialLoad;

		// Token: 0x0400323F RID: 12863
		private long[] m_moveArray;

		// Token: 0x04003240 RID: 12864
		private string[] folderNamesList;

		// Token: 0x04003241 RID: 12865
		private long[] folderIDList;

		// Token: 0x04003242 RID: 12866
		private RemoteServices.GetReportsList_UserCallBack m_getReportListUICallback;

		// Token: 0x04003243 RID: 12867
		public RecipientList ForwardTo = new RecipientList();

		// Token: 0x02000473 RID: 1139
		public class ReportsComparer : IComparer<ReportListItem>
		{
			// Token: 0x06002929 RID: 10537 RVA: 0x001F612C File Offset: 0x001F432C
			public int Compare(ReportListItem x, ReportListItem y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return 0;
					}
					return -1;
				}
				else
				{
					if (y == null)
					{
						return 1;
					}
					if (Math.Abs(x.reportID) < Math.Abs(y.reportID))
					{
						return 1;
					}
					if (Math.Abs(x.reportID) > Math.Abs(y.reportID))
					{
						return -1;
					}
					return 0;
				}
			}
		}
	}
}
