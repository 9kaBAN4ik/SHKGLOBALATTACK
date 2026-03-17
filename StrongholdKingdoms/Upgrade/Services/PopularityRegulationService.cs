using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using CommonTypes;
using Kingdoms;

namespace Upgrade.Services
{
	// Token: 0x02000073 RID: 115
	internal class PopularityRegulationService : ABaseService
	{
		// Token: 0x06000340 RID: 832 RVA: 0x00009A19 File Offset: 0x00007C19
		private void LLog(string message, bool isError = false)
		{
			this.Log(message, ControlForm.Tab.PopularityRegulation, isError);
		}

		// Token: 0x06000341 RID: 833 RVA: 0x0000935B File Offset: 0x0000755B
		public PopularityRegulationService(Log log) : base(log)
		{
		}

		// Token: 0x06000342 RID: 834 RVA: 0x00007CE0 File Offset: 0x00005EE0
		internal override void TranslateUI()
		{
		}

		// Token: 0x06000343 RID: 835 RVA: 0x0005164C File Offset: 0x0004F84C
		internal static int LoadMode()
		{
			string settingsFilePath = SettingsManager.GetSettingsFilePath("Mode.txt", false, new string[]
			{
				"Popularity Regulation"
			});
			if (!File.Exists(settingsFilePath))
			{
				return 0;
			}
			int result;
			if (!int.TryParse(File.ReadAllText(settingsFilePath), out result))
			{
				return 0;
			}
			return result;
		}

		// Token: 0x06000344 RID: 836 RVA: 0x00051690 File Offset: 0x0004F890
		public override void ConcreteAction()
		{
			if (this.PopularityRegulationMode == 0)
			{
				this.LLog(LNG.Print("Mode is not selected!"), true);
				return;
			}
			if (this.PopularityRegulationMode < 0 || this.PopularityRegulationMode > 4)
			{
				this.LLog(LNG.Print("Incorrect mode!"), true);
				return;
			}
			int maxTaxLevel = CardTypes.getMaxTaxLevel(GameEngine.Instance.cardsManager.UserCardData);
			List<int> list = new List<int>(this.SelectedVillages);
			foreach (int num in list)
			{
				VillageMap village = GameEngine.Instance.getVillage(num);
				if (village == null)
				{
					this.LLog(string.Format("{0} : {1}", LNG.Print("Village wasn't loaded"), num), true);
				}
				else
				{
					int taxLevel = village.m_taxLevel;
					int rationsLevel = village.m_rationsLevel;
					int aleRationsLevel = village.m_aleRationsLevel;
					if (this.PopularityRegulationMode == 1 || ((this.PopularityRegulationMode == 2 || this.PopularityRegulationMode == 4) && village.m_totalPeople >= village.m_housingCapacity))
					{
						this.LLog(string.Format("{0} is {1}", num, LNG.Print("taxing!")), false);
						int affordableRationsLevel = village.GetAffordableRationsLevel();
						int num2 = affordableRationsLevel - rationsLevel;
						int affordableAleRationsLevel = village.GetAffordableAleRationsLevel();
						int num3 = affordableAleRationsLevel - aleRationsLevel;
						if (num2 != 0 || num3 != 0)
						{
							village.changeStats(0, num2, num3);
							if (base.RandomSleepOrExit(1000, 1500))
							{
								break;
							}
						}
						int num4 = (int)village.getPopularity() - VillageBuildingsData.getTaxPopularityLevel(taxLevel);
						this.LLog(string.Format("{0} {1}", LNG.Print("Current popularity (without taxes effect) is"), num4), false);
						this.LLog(string.Format("{0} {1}", LNG.Print("Tax Level is"), taxLevel), false);
						int i = maxTaxLevel;
						while (i >= 0)
						{
							if (num4 + VillageBuildingsData.getTaxPopularityLevel(i) >= 0)
							{
								int num5 = i - taxLevel;
								if (num5 == 0)
								{
									break;
								}
								village.changeStats(num5, 0, 0);
								this.LLog(string.Format("{0} {1}", LNG.Print("Tax level is changed by"), num5), false);
								if (base.RandomSleepOrExit(3000, 5000))
								{
									return;
								}
								break;
							}
							else
							{
								i--;
							}
						}
					}
					else if ((this.PopularityRegulationMode == 3 || (this.PopularityRegulationMode == 4 && village.m_totalPeople < village.m_housingCapacity)) && (taxLevel != 0 || rationsLevel != 6 || aleRationsLevel != 4))
					{
						this.LLog(string.Format("{0} {1}", num, LNG.Print("is recruiting!")), false);
						village.changeStats(0 - taxLevel, 6 - rationsLevel, 4 - aleRationsLevel);
						if (base.RandomSleepOrExit(3000, 5000))
						{
							break;
						}
					}
				}
			}
		}

		// Token: 0x06000345 RID: 837 RVA: 0x0005197C File Offset: 0x0004FB7C
		internal void CopySettings(IEnumerable<string> listOfVillages, int villageId)
		{
			if (!base.IsSubscribed)
			{
				ABaseService.MessageBoxNonModal(string.Concat(new string[]
				{
					LNG.Print("You need to have one of the following subscriptions"),
					": ",
					LNG.Print("All features"),
					", ",
					LNG.Print(this.Name)
				}), LNG.Print("Please subscribe"));
				return;
			}
			if (this._processingRequest)
			{
				this.LLog(LNG.Print("Previous operation is not finished!"), true);
				return;
			}
			this._processingRequest = true;
			VillageMap map = GameEngine.Instance.getVillage(villageId);
			if (map == null)
			{
				this.LLog(string.Format("{0} : {1}", LNG.Print("Village wasn't loaded"), villageId), true);
				this._processingRequest = false;
				return;
			}
			this.thread = new Thread(delegate()
			{
				this.CopyVillageStats(listOfVillages, map);
			});
			this.thread.Start();
		}

		// Token: 0x06000346 RID: 838 RVA: 0x00051A80 File Offset: 0x0004FC80
		private void CopyVillageStats(IEnumerable<string> listOfVillages, VillageMap map)
		{
			try
			{
				foreach (string text in listOfVillages)
				{
					VillageMap village = GameEngine.Instance.getVillage(ControlForm.GetId(text));
					if (village == null)
					{
						this.LLog(LNG.Print("Village wasn't loaded") + " : " + text, true);
					}
					else
					{
						this.LLog(LNG.Print("Checking village") + ": " + text, false);
						if (map.m_taxLevel != village.m_taxLevel || map.m_rationsLevel != village.m_rationsLevel || map.m_aleRationsLevel != village.m_aleRationsLevel)
						{
							village.changeStats(map.m_taxLevel - village.m_taxLevel, map.m_rationsLevel - village.m_rationsLevel, map.m_aleRationsLevel - village.m_aleRationsLevel);
							if (this.Exiting.WaitOne(ASubscribed._random.Next(3000, 5000)))
							{
								return;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				this._processingRequest = false;
				ABaseService.ReportError(ex, ControlForm.Tab.PopularityRegulation);
			}
			this._processingRequest = false;
		}

		// Token: 0x04000486 RID: 1158
		public int PopularityRegulationMode;

		// Token: 0x04000487 RID: 1159
		private bool _processingRequest;

		// Token: 0x04000488 RID: 1160
		private Thread thread;
	}
}
