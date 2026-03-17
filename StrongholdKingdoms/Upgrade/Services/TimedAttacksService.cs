using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using CommonTypes;
using Kingdoms;

namespace Upgrade.Services
{
	// Token: 0x02000056 RID: 86
	public class TimedAttacksService : ASubscribed
	{
		// Token: 0x060002BB RID: 699 RVA: 0x00009695 File Offset: 0x00007895
		public TimedAttacksService(Log logMethod)
		{
			this.CapitalAttackRates = new Dictionary<int, double>();
			this.Log = logMethod;
		}

		// Token: 0x060002BC RID: 700 RVA: 0x000096AF File Offset: 0x000078AF
		private void LLog(string message, bool isError = false)
		{
			this.Log(message, ControlForm.Tab.TimedAttacks, isError);
		}

		// Token: 0x060002BD RID: 701 RVA: 0x00007CE0 File Offset: 0x00005EE0
		internal override void TranslateUI()
		{
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0004D63C File Offset: 0x0004B83C
		public void CalculateAttackTimes(int targetId)
		{
			if (!base.IsSubscribed)
			{
				ABaseService.MessageBoxNonModal(string.Concat(new string[]
				{
					LNG.Print("You need to have one of the following subscriptions"),
					": ",
					LNG.Print("All features"),
					", ",
					LNG.Print("Timed Attacks")
				}), LNG.Print("Please subscribe"));
				return;
			}
			List<Attacker> listOfAttackers = this.GetListOfAttackers();
			this.FillAttackersInfo(listOfAttackers, targetId);
			this.SaveAttackersToCsv(listOfAttackers, targetId);
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0004D6BC File Offset: 0x0004B8BC
		private void SaveAttackersToCsv(List<Attacker> attackers, int targetId)
		{
			string[] array = new string[attackers.Count + 1];
			array[0] = Attacker.CsvHeaderString();
			int num = 1;
			foreach (Attacker attacker in from x in attackers
			orderby x.ArmyTime
			select x)
			{
				array[num] = attacker.ToCsvString();
				num++;
			}
			string settingsFilePath = SettingsManager.GetSettingsFilePath(LNG.Print("Attack Times For") + " - " + GameEngine.Instance.World.getVillageNameOrType(targetId) + ".txt", true, new string[]
			{
				"Timed Attacks"
			});
			try
			{
				File.WriteAllLines(settingsFilePath, array, Encoding.Unicode);
			}
			catch (Exception ex)
			{
				ABaseService.MessageBoxNonModal(ex.Message, SK.Text("GENERIC_Error", "Error"));
				return;
			}
			this.LLog(LNG.Print("Attack times are saved to") + ": " + settingsFilePath, false);
			Process.Start(Path.GetDirectoryName(settingsFilePath));
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x0004D7E8 File Offset: 0x0004B9E8
		private void FillAttackersInfo(List<Attacker> attackers, int targetId)
		{
			WorldData localWorldData = GameEngine.Instance.LocalWorldData;
			for (int i = 0; i < attackers.Count; i++)
			{
				Attacker attacker = attackers[i];
				attacker.Name = GameEngine.Instance.World.getVillageName(attackers[i].Id);
				attacker.Distance = GameEngine.Instance.World.getDistance(targetId, attackers[i].Id);
				if (attacker.Type == AttackerType.Capital)
				{
					if (!this.CapitalAttackRates.ContainsKey(attacker.Id))
					{
						this.LLog(LNG.Print("Please update capital army speed for") + " " + GameEngine.Instance.World.getVillageName(attacker.Id), false);
					}
					else
					{
						double num = this.CapitalAttackRates[attacker.Id];
						if (num == 0.0)
						{
							num = 1.0;
						}
						double num2 = attacker.Distance * localWorldData.armyMoveSpeed * localWorldData.gamePlaySpeed * num;
						attacker.TotalArmySeconds = (int)num2;
						attacker.ArmyTime = TimeSpan.FromSeconds(num2);
					}
				}
				else
				{
					double num3 = attacker.Distance * localWorldData.armyMoveSpeed * localWorldData.gamePlaySpeed * ResearchData.ArmyTimes[(int)GameEngine.Instance.World.UserResearchData.Research_ForcedMarch];
					attacker.TotalArmySeconds = (int)num3;
					attacker.ArmyTime = TimeSpan.FromSeconds(num3);
					if (attacker.Type == AttackerType.Village)
					{
						double num4 = attacker.Distance * localWorldData.CaptainsMoveSpeed * localWorldData.gamePlaySpeed * ResearchData.CaptainTimes[(int)GameEngine.Instance.World.GetResearchDataForCurrentVillage().Research_Courtiers];
						attacker.TotalCaptSeconds = (int)num4;
						attacker.CaptainTime = TimeSpan.FromSeconds(num4);
					}
				}
			}
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x0004D9A8 File Offset: 0x0004BBA8
		public double CalcAttackTimeForPredator(int villageId, double distance)
		{
			WorldData localWorldData = GameEngine.Instance.LocalWorldData;
			if (GameEngine.Instance.World.isCapital(villageId))
			{
				if (this.CapitalAttackRates.ContainsKey(villageId))
				{
					double num = this.CapitalAttackRates[villageId];
					if (num == 0.0)
					{
						num = 1.0;
					}
					return (double)((int)(distance * localWorldData.armyMoveSpeed * localWorldData.gamePlaySpeed * num));
				}
				this.Log(LNG.Print("Please update capital army speed for") + " " + GameEngine.Instance.World.getVillageName(villageId), ControlForm.Tab.Predator, false);
			}
			return distance * localWorldData.armyMoveSpeed * localWorldData.gamePlaySpeed * ResearchData.ArmyTimes[(int)GameEngine.Instance.World.UserResearchData.Research_ForcedMarch];
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x0004DA78 File Offset: 0x0004BC78
		private List<Attacker> GetListOfAttackers()
		{
			VillageData[] villageList = GameEngine.Instance.World.VillageList;
			List<Attacker> list = new List<Attacker>();
			for (int j = 0; j < villageList.Length; j++)
			{
				if (villageList[j].userID == RemoteServices.Instance.UserID)
				{
					list.Add(new Attacker
					{
						Id = villageList[j].id,
						Type = (villageList[j].Capital ? AttackerType.Capital : AttackerType.Village)
					});
				}
			}
			List<Attacker> list2 = new List<Attacker>();
			int i;
			int i2;
			for (i = 0; i < villageList.Length; i = i2 + 1)
			{
				int connecterId = villageList[i].connecter;
				if (list.Any((Attacker a) => a.Id == connecterId))
				{
					list2.Add(new Attacker
					{
						Id = villageList[i].id,
						Type = AttackerType.Vassal
					});
				}
				i2 = i;
			}
			list.AddRange(list2);
			return list;
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x0004DB98 File Offset: 0x0004BD98
		public void UpdateCapitalsAttackSpeed(int targetId)
		{
			PredatorService predatorService = DX.ControlForm.GetService<PredatorService>();
			if (!base.IsSubscribed && !predatorService.IsSubscribed)
			{
				ABaseService.MessageBoxNonModal(string.Concat(new string[]
				{
					LNG.Print("You need to have one of the following subscriptions"),
					": ",
					LNG.Print("All features"),
					", ",
					LNG.Print("Timed Attacks"),
					", ",
					LNG.Print(predatorService.Name)
				}), LNG.Print("Please subscribe"));
				return;
			}
			if (predatorService.Capitals.Count <= 0)
			{
				this.LLog(LNG.Print("You don't have any capitals"), false);
				return;
			}
			new Thread(delegate()
			{
				if (targetId == -1)
				{
					targetId = TimedAttacksService.GetFirstAICastle();
					if (targetId == -1)
					{
						this.LLog(LNG.Print("Please specify the village ID"), true);
						return;
					}
				}
				this.LLog(LNG.Print("Start updating capitals armies attack speed"), false);
				foreach (int num in predatorService.Capitals)
				{
					this.LLog(string.Format("{0}: {1}", LNG.Print("Requesting attack speed for"), num), false);
					RemoteServices.Instance.set_PreAttackSetup_UserCallBack(new RemoteServices.PreAttackSetup_UserCallBack(this.PreAttackSetupCallback));
					RemoteServices.Instance.PreAttackSetup(num, num, targetId, 0, 0, 0, 0, 0, 0, 0, 0);
					if (this.RandomSleepOrExit(1212, 1714))
					{
						break;
					}
				}
			}).Start();
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x0004DC88 File Offset: 0x0004BE88
		private static int GetFirstAICastle()
		{
			VillageData[] villageList = GameEngine.Instance.World.VillageList;
			foreach (int num in TimedAttacksService.AIspecials)
			{
				for (int j = 0; j < villageList.Length; j++)
				{
					if (villageList[j].special == num)
					{
						return villageList[j].id;
					}
				}
			}
			return -1;
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x0004DCE8 File Offset: 0x0004BEE8
		private void PreAttackSetupCallback(PreAttackSetup_ReturnType returnData)
		{
			if (!returnData.Success)
			{
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
			int attackingVillage = returnData.attackingVillage;
			this.LLog(LNG.Print("Received attack speed for") + " " + GameEngine.Instance.World.getVillageName(attackingVillage), false);
			if (!this.CapitalAttackRates.ContainsKey(attackingVillage))
			{
				this.CapitalAttackRates.Add(attackingVillage, returnData.capitalAttackRate);
				return;
			}
			this.CapitalAttackRates[attackingVillage] = returnData.capitalAttackRate;
		}

		// Token: 0x04000429 RID: 1065
		private Dictionary<int, double> CapitalAttackRates;

		// Token: 0x0400042A RID: 1066
		private readonly Log Log;

		// Token: 0x0400042B RID: 1067
		private static readonly int[] AIspecials = new int[]
		{
			13,
			11,
			9,
			7
		};
	}
}
