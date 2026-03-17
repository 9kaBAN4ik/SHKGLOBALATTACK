using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms;

namespace Upgrade.Services
{
	// Token: 0x020000A0 RID: 160
	internal class TroopsrecruitingService : ABaseService
	{
		// Token: 0x06000423 RID: 1059 RVA: 0x00009F66 File Offset: 0x00008166
		private void LLog(string message, bool isError = false)
		{
			this.Log(message, ControlForm.Tab.TroopsRecruiting, isError);
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x00059934 File Offset: 0x00057B34
		public TroopsrecruitingService(DataGridView settingsGrid, DataGridView capitalsSettingsGrid, DataGridView vassalsSettingsGrid, Log logMethod) : base(logMethod)
		{
			VassalsOverview.VassalsCache.Clear();
			this._settingsGrid = settingsGrid;
			this._settingsGrid.CellValueChanged += this.SettingsGrid_CellValueChanged;
			this._capitalsSettingsGrid = capitalsSettingsGrid;
			this._capitalsSettingsGrid.CellValueChanged += this.SettingsGrid_CellValueChanged;
			this._vassalsSettingsGrid = vassalsSettingsGrid;
			this._vassalsSettingsGrid.CellValueChanged += this.SettingsGrid_CellValueChanged;
			this.troopsCost = new int[5];
			this.TranslateUI();
			if (GameEngine.Instance.LocalWorldData != null)
			{
				this.troopsCost[0] = GameEngine.Instance.LocalWorldData.Barracks_GoldCost_Peasant;
				this.troopsCost[1] = GameEngine.Instance.LocalWorldData.Barracks_GoldCost_Archer;
				this.troopsCost[2] = GameEngine.Instance.LocalWorldData.Barracks_GoldCost_Pikeman;
				this.troopsCost[3] = GameEngine.Instance.LocalWorldData.Barracks_GoldCost_Swordsman;
				this.troopsCost[4] = GameEngine.Instance.LocalWorldData.Barracks_GoldCost_Catapult;
			}
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x00009F77 File Offset: 0x00008177
		public override void ConcreteAction()
		{
			this.RecruitInVillages();
			this.RecruitInCapitals();
			this.FillVassals();
			this.LLog(LNG.Print("Recruiting cycle is over"), false);
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x00059A64 File Offset: 0x00057C64
		private void RecruitInVillages()
		{
			foreach (object obj in ((IEnumerable)this._settingsGrid.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				if (Convert.ToBoolean(dataGridViewRow.Cells[1].Value))
				{
					int id = ControlForm.GetId(dataGridViewRow.Cells[0].Value.ToString());
					VillageMap village = GameEngine.Instance.getVillage(id);
					string villageName = GameEngine.Instance.World.getVillageName(id);
					if (village == null)
					{
						this.LLog(LNG.Print("Village wasn't loaded") + ": " + villageName, true);
					}
					else
					{
						village.CheckVillagersArrival(ControlForm.Tab.TroopsRecruiting);
						int num = village.m_spareWorkers;
						if (num <= 0)
						{
							this.LLog(LNG.Print("Village has no spare workers") + ": " + villageName, false);
						}
						else
						{
							this.LLog(string.Format("{0} {1}: {2}", villageName, LNG.Print("is recruiting spareworkers"), num), false);
							int num2 = GameEngine.Instance.LocalWorldData.Village_UnitCapacity - village.calcUnitUsages();
							if (num2 <= 0)
							{
								this.LLog(LNG.Print("Village has no spare unit space") + ": " + villageName, false);
							}
							else
							{
								int num3 = village.calcTotalTroops();
								this.LLog(string.Format("{0}: {1}", LNG.Print("Village already has troops"), num3), false);
								int num4 = ResearchData.commandResearchTroopLevels[(int)GameEngine.Instance.World.userResearchData.Research_Command] - num3;
								if (num4 <= 0)
								{
									this.LLog(LNG.Print("Village has max army size") + ": " + villageName, false);
								}
								else
								{
									VillageMap.ArmouryLevels armouryLevels = new VillageMap.ArmouryLevels();
									village.getArmouryLevels(armouryLevels);
									int num5 = (int)armouryLevels.bowsLevel;
									int val = (int)armouryLevels.pikesLevel;
									int num6 = (int)armouryLevels.armourLevel;
									int val2 = (int)armouryLevels.swordsLevel;
									int num7 = (int)armouryLevels.catapultsLevel;
									int num8 = (int)GameEngine.Instance.World.getCurrentGold();
									if (num8 <= 0)
									{
										this.LLog(LNG.Print("Not enough gold"), false);
									}
									else
									{
										int[] array = new int[]
										{
											Convert.ToInt32(dataGridViewRow.Cells[2].Value),
											Convert.ToInt32(dataGridViewRow.Cells[3].Value),
											Convert.ToInt32(dataGridViewRow.Cells[4].Value),
											Convert.ToInt32(dataGridViewRow.Cells[5].Value),
											Convert.ToInt32(dataGridViewRow.Cells[6].Value)
										};
										int[] array2 = village.CalcTotalTroopsArray();
										string text = "Troops recruited: ";
										bool flag = false;
										int num9 = 0;
										while (num9 < array.Length && num != 0 && num2 != 0 && num8 != 0 && num4 != 0)
										{
											if (array2[num9] < array[num9])
											{
												int num10 = array[num9] - array2[num9];
												this.LLog(string.Format("{0} {1} {2}", num10, TroopsrecruitingService.TroopsNames[num9], LNG.Print("are needed")), false);
												if (num < num10)
												{
													num10 = num;
													this.LLog(string.Format("{0} {1}", LNG.Print("Spare workers limit us to"), num10), false);
												}
												if (num2 < num10)
												{
													num10 = num2;
													this.LLog(string.Format("{0} {1}", LNG.Print("Spare unit space limits us to"), num10), false);
												}
												if (num4 < num10)
												{
													num10 = num4;
													this.LLog(string.Format("{0} {1}", LNG.Print("Command research limits us to"), num10), false);
												}
												int num11 = CardTypes.adjustTroopCost(GameEngine.Instance.cardsManager.UserCardData, this.troopsCost[num9]);
												this.LLog(string.Format("{0} {1}", LNG.Print("Unit's price is"), num11), false);
												if (num8 < num10 * num11)
												{
													num10 = num8 / num11;
													this.LLog(string.Format("{0} {1}", LNG.Print("Gold limits us to"), num10), false);
												}
												switch (num9)
												{
												case 0:
													if (GameEngine.Instance.World.UserResearchData.Research_Conscription == 0)
													{
														goto IL_673;
													}
													break;
												case 1:
													if (GameEngine.Instance.World.UserResearchData.Research_LongBow == 0)
													{
														this.LLog(SK.Text("TOOLTIPS_BARRACKS_ARCHERS_NOT_RESEARCHED", "To recruit Archers you must be Rank 6 and research 'Long Bows'."), false);
														goto IL_673;
													}
													if (num5 < num10)
													{
														num10 = num5;
														this.LLog(string.Format("{0} {1}", LNG.Print("Weapons limit us to"), num10), false);
													}
													break;
												case 2:
												{
													if (GameEngine.Instance.World.UserResearchData.Research_Pike == 0)
													{
														this.LLog(SK.Text("TOOLTIPS_BARRACKS_PIKEMEN_NOT_RESEARCHED", "To recruit Pikemen you must be Rank 11 and research 'Pike'."), false);
														goto IL_673;
													}
													int num12 = num10;
													num10 = Math.Min(num10, val);
													num10 = Math.Min(num10, num6);
													if (num12 != num10)
													{
														this.LLog(string.Format("{0} {1}", LNG.Print("Weapons limit us to"), num10), false);
													}
													num6 -= num10;
													break;
												}
												case 3:
												{
													if (GameEngine.Instance.World.UserResearchData.Research_Sword == 0)
													{
														this.LLog(SK.Text("TOOLTIPS_BARRACKS_SWORDSMEN_NOT_RESEARCHED", "To recruit Swordsmen you must be Rank 13 and research 'Sword'."), false);
														goto IL_673;
													}
													int num12 = num10;
													num10 = Math.Min(num10, val2);
													num10 = Math.Min(num10, num6);
													if (num12 != num10)
													{
														this.LLog(string.Format("{0} {1}", LNG.Print("Weapons limit us to"), num10), false);
													}
													break;
												}
												case 4:
													if (GameEngine.Instance.World.UserResearchData.Research_Catapult == 0)
													{
														this.LLog(SK.Text("TOOLTIPS_BARRACKS_CATAPULTS_NOT_RESEARCHED", "To recruit Catapults you must be Rank 15 and research 'Catapult'."), false);
														goto IL_673;
													}
													if (num7 < num10)
													{
														num10 = num7;
														this.LLog(string.Format("{0} {1}", LNG.Print("Weapons limit us to"), num10), false);
													}
													break;
												}
												if (num10 > 0)
												{
													flag = true;
													village.makeTroops(this.troopsTypes[num9], num10, false);
													num -= num10;
													num2 -= num10;
													num8 -= num10 * num11;
													num4 -= num10;
													text += string.Format("{0} {1},", num10, TroopsrecruitingService.TroopsNames[num9]);
													if (base.RandomSleepOrExit(2000, 3000))
													{
														return;
													}
												}
											}
											IL_673:
											num9++;
										}
										if (flag)
										{
											this.LLog(text.TrimEnd(new char[]
											{
												','
											}), false);
										}
										if (base.RandomSleepOrExit(1000, 2000))
										{
											break;
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x0005A164 File Offset: 0x00058364
		private void RecruitInCapitals()
		{
			foreach (object obj in ((IEnumerable)this._capitalsSettingsGrid.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				if (Convert.ToBoolean(dataGridViewRow.Cells[1].Value))
				{
					int id = ControlForm.GetId(dataGridViewRow.Cells[0].Value.ToString());
					VillageMap village = GameEngine.Instance.getVillage(id);
					string villageName = GameEngine.Instance.World.getVillageName(id);
					if (village == null)
					{
						this.LLog(LNG.Print("Capital wasn't loaded") + ": " + villageName, true);
					}
					else
					{
						int capitalCurrentTroops = TroopsrecruitingService.GetCapitalCurrentTroops(village);
						this.LLog(string.Format("{0}: {1}", LNG.Print("Capital already has troops"), capitalCurrentTroops), false);
						int num = (int)village.m_capitalGold;
						int num2 = (int)((village.m_parishCapitalResearchData.Research_Command + 1) * 25);
						this.LLog(string.Format("{0}:{1}", SK.Text("BARRACKS_Max_Army_Size", "Max Army Size"), num2), false);
						int num3 = num2 - capitalCurrentTroops;
						int[] array = new int[]
						{
							Convert.ToInt32(dataGridViewRow.Cells[2].Value),
							Convert.ToInt32(dataGridViewRow.Cells[3].Value),
							Convert.ToInt32(dataGridViewRow.Cells[4].Value),
							Convert.ToInt32(dataGridViewRow.Cells[5].Value),
							Convert.ToInt32(dataGridViewRow.Cells[6].Value)
						};
						int[] capitalCurrentTroopsArray = TroopsrecruitingService.GetCapitalCurrentTroopsArray(village);
						string text = "Troops recruited: ";
						bool flag = false;
						ResearchData researchDataForCurrentVillage = GameEngine.Instance.World.GetResearchDataForCurrentVillage();
						int num4 = 0;
						while (num4 < 5 && num != 0 && num3 != 0)
						{
							if (capitalCurrentTroopsArray[num4] < array[num4])
							{
								switch (num4)
								{
								case 0:
									if (researchDataForCurrentVillage.Research_Conscription == 0)
									{
										this.LLog(LNG.Print("Troop type not available in this capital."), false);
										goto IL_3E4;
									}
									break;
								case 1:
									if (researchDataForCurrentVillage.Research_LongBow == 0)
									{
										this.LLog(LNG.Print("Troop type not available in this capital."), false);
										goto IL_3E4;
									}
									break;
								case 2:
									if (researchDataForCurrentVillage.Research_Pike == 0)
									{
										this.LLog(LNG.Print("Troop type not available in this capital."), false);
										goto IL_3E4;
									}
									break;
								case 3:
									if (researchDataForCurrentVillage.Research_Sword == 0)
									{
										this.LLog(LNG.Print("Troop type not available in this capital."), false);
										goto IL_3E4;
									}
									break;
								case 4:
									if (researchDataForCurrentVillage.Research_Catapult == 0)
									{
										this.LLog(LNG.Print("Troop type not available in this capital."), false);
										goto IL_3E4;
									}
									break;
								}
								int num5 = array[num4] - capitalCurrentTroopsArray[num4];
								this.LLog(string.Format("{0} {1} {2}", num5, TroopsrecruitingService.TroopsNames[num4], LNG.Print("are needed")), false);
								if (num3 < num5)
								{
									num5 = num3;
									this.LLog(string.Format("{0} {1}", LNG.Print("Max army limits us to"), num5), false);
								}
								int num6 = this.troopsCost[num4] * GameEngine.Instance.LocalWorldData.MercenaryCostMultiplier;
								if (GameEngine.Instance.World.SixthAgeWorld)
								{
									num6 /= 2;
								}
								this.LLog(string.Format("{0}: {1}", LNG.Print("Unit's price is"), num6), false);
								if (num < num5 * num6)
								{
									num5 = num / num6;
									this.LLog(string.Format("{0} {1}", LNG.Print("Gold limits us to"), num5), false);
								}
								if (num5 > 0)
								{
									flag = true;
									village.makeTroops(this.troopsTypes[num4], num5, false);
									num3 -= num5;
									num -= num5 * num6;
									text += string.Format("{0} {1},", num5, TroopsrecruitingService.TroopsNames[num4]);
									if (base.RandomSleepOrExit(2000, 3000))
									{
										return;
									}
								}
							}
							IL_3E4:
							num4++;
						}
						if (flag)
						{
							this.LLog(text.TrimEnd(new char[]
							{
								','
							}), false);
						}
						if (base.RandomSleepOrExit(1000, 2000))
						{
							break;
						}
					}
				}
			}
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x0005A5D4 File Offset: 0x000587D4
		private void FillVassals()
		{
			foreach (object obj in ((IEnumerable)this._vassalsSettingsGrid.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				if (Convert.ToBoolean(dataGridViewRow.Cells[1].Value))
				{
					this.m_vassalVillageID = ControlForm.GetId(dataGridViewRow.Cells[0].Value.ToString());
					this.LLog(string.Format("{0}: {1}", LNG.Print("Checking vassal"), this.m_vassalVillageID), false);
					int connecter = GameEngine.Instance.World.VillageList[this.m_vassalVillageID].connecter;
					VillageMap village = GameEngine.Instance.getVillage(connecter);
					string villageName = GameEngine.Instance.World.getVillageName(connecter);
					if (village == null)
					{
						this.LLog(LNG.Print("Liege Lord Village wasn't loaded") + " : " + villageName, true);
					}
					else
					{
						this.LLog(string.Format("Liege Lord {0} has: {1} {2}, {3} {4}, {5} {6}, {7} {8}, {9} {10},", new object[]
						{
							villageName,
							village.m_numPeasants,
							TroopsrecruitingService.TroopsNames[0],
							village.m_numArchers,
							TroopsrecruitingService.TroopsNames[1],
							village.m_numPikemen,
							TroopsrecruitingService.TroopsNames[2],
							village.m_numSwordsmen,
							TroopsrecruitingService.TroopsNames[3],
							village.m_numCatapults,
							TroopsrecruitingService.TroopsNames[4]
						}), false);
						int num = village.m_numPeasants + village.m_numArchers + village.m_numPikemen + village.m_numSwordsmen + village.m_numCatapults;
						if (num <= 0)
						{
							this.LLog(LNG.Print("No troops in liege lord village barracks!"), false);
						}
						else
						{
							int num2 = Convert.ToInt32(dataGridViewRow.Cells[2].Value);
							int num3 = Convert.ToInt32(dataGridViewRow.Cells[3].Value);
							int num4 = Convert.ToInt32(dataGridViewRow.Cells[4].Value);
							int num5 = Convert.ToInt32(dataGridViewRow.Cells[5].Value);
							int num6 = Convert.ToInt32(dataGridViewRow.Cells[6].Value);
							num2 = Math.Min(num2, village.m_numPeasants);
							num3 = Math.Min(num3, village.m_numArchers);
							num4 = Math.Min(num4, village.m_numPikemen);
							num5 = Math.Min(num5, village.m_numSwordsmen);
							num6 = Math.Min(num6, village.m_numCatapults);
							int num7 = num2 + num3 + num4 + num5 + num6;
							if (num7 <= 0)
							{
								this.LLog(LNG.Print("No troops to send"), false);
							}
							else
							{
								int num8 = ResearchData.commandResearchTroopLevels[(int)GameEngine.Instance.World.userResearchData.Research_Command];
								if (num7 > num8)
								{
									this.LLog(LNG.Print("Not enough Command research"), false);
								}
								else
								{
									RemoteServices.Instance.set_GetVassalArmyInfo_UserCallBack(new RemoteServices.GetVassalArmyInfo_UserCallBack(this.getVassalArmyInfoCallback));
									RemoteServices.Instance.GetVassalArmyInfo(this.m_vassalVillageID, 0, -1);
									if (base.RandomSleepOrExit(5879, 8160))
									{
										break;
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x0005A934 File Offset: 0x00058B34
		public void getVassalArmyInfoCallback(GetVassalArmyInfo_ReturnType returnData)
		{
			if (returnData == null || !returnData.Success || this.m_vassalVillageID != returnData.vassalVillageID)
			{
				this.LLog(LNG.Print("ERROR on checking vassal"), true);
				this.LLog(ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID) + ". Vassal Village " + GameEngine.Instance.World.getVillageName(this.m_vassalVillageID), true);
				return;
			}
			VassalsOverview.AddVassalToCache(returnData);
			int num = returnData.numStationedTroops_Peasants + returnData.numAttackingTroops_Peasants + returnData.numEnrouteTroops_Peasants;
			int num2 = returnData.numStationedTroops_Archers + returnData.numAttackingTroops_Archers + returnData.numEnrouteTroops_Archers;
			int num3 = returnData.numStationedTroops_Pikemen + returnData.numAttackingTroops_Pikemen + returnData.numEnrouteTroops_Pikemen;
			int num4 = returnData.numStationedTroops_Swordsmen + returnData.numAttackingTroops_Swordsmen + returnData.numEnrouteTroops_Swordsmen;
			int num5 = returnData.numStationedTroops_Catapults + returnData.numAttackingTroops_Catapults + returnData.numEnrouteTroops_Catapults;
			this.LLog(string.Format("Vassal {0} has: {1} {2}, {3} {4}, {5} {6}, {7} {8}, {9} {10},", new object[]
			{
				this.m_vassalVillageID,
				num,
				TroopsrecruitingService.TroopsNames[0],
				num2,
				TroopsrecruitingService.TroopsNames[1],
				num3,
				TroopsrecruitingService.TroopsNames[2],
				num4,
				TroopsrecruitingService.TroopsNames[3],
				num5,
				TroopsrecruitingService.TroopsNames[4]
			}), false);
			DataGridViewRow dataGridViewRow = null;
			foreach (object obj in ((IEnumerable)this._vassalsSettingsGrid.Rows))
			{
				DataGridViewRow dataGridViewRow2 = (DataGridViewRow)obj;
				int id = ControlForm.GetId(dataGridViewRow2.Cells[0].Value.ToString());
				if (id == this.m_vassalVillageID)
				{
					dataGridViewRow = dataGridViewRow2;
					break;
				}
			}
			if (dataGridViewRow == null)
			{
				this.LLog(string.Format("{0}: {1}", LNG.Print("No settings for vassal"), this.m_vassalVillageID), false);
				return;
			}
			int num6 = int.Parse(dataGridViewRow.Cells[2].Value.ToString()) - num;
			int num7 = int.Parse(dataGridViewRow.Cells[3].Value.ToString()) - num2;
			int num8 = int.Parse(dataGridViewRow.Cells[4].Value.ToString()) - num3;
			int num9 = int.Parse(dataGridViewRow.Cells[5].Value.ToString()) - num4;
			int num10 = int.Parse(dataGridViewRow.Cells[6].Value.ToString()) - num5;
			num6 = Math.Max(num6, 0);
			num7 = Math.Max(num7, 0);
			num8 = Math.Max(num8, 0);
			num9 = Math.Max(num9, 0);
			num10 = Math.Max(num10, 0);
			this.LLog(string.Format("Vassal {0} need: {1} {2}, {3} {4}, {5} {6}, {7} {8}, {9} {10},", new object[]
			{
				this.m_vassalVillageID,
				num6,
				TroopsrecruitingService.TroopsNames[0],
				num7,
				TroopsrecruitingService.TroopsNames[1],
				num8,
				TroopsrecruitingService.TroopsNames[2],
				num9,
				TroopsrecruitingService.TroopsNames[3],
				num10,
				TroopsrecruitingService.TroopsNames[4]
			}), false);
			int connecter = GameEngine.Instance.World.VillageList[this.m_vassalVillageID].connecter;
			VillageMap village = GameEngine.Instance.getVillage(connecter);
			string villageName = GameEngine.Instance.World.getVillageName(connecter);
			this.LLog(string.Format("Liege Lord {0} has: {1} {2}, {3} {4}, {5} {6}, {7} {8}, {9} {10},", new object[]
			{
				villageName,
				village.m_numPeasants,
				TroopsrecruitingService.TroopsNames[0],
				village.m_numArchers,
				TroopsrecruitingService.TroopsNames[1],
				village.m_numPikemen,
				TroopsrecruitingService.TroopsNames[2],
				village.m_numSwordsmen,
				TroopsrecruitingService.TroopsNames[3],
				village.m_numCatapults,
				TroopsrecruitingService.TroopsNames[4]
			}), false);
			num6 = Math.Min(num6, village.m_numPeasants);
			num7 = Math.Min(num7, village.m_numArchers);
			num8 = Math.Min(num8, village.m_numPikemen);
			num9 = Math.Min(num9, village.m_numSwordsmen);
			num10 = Math.Min(num10, village.m_numCatapults);
			int num11 = num6 + num7 + num8 + num9 + num10;
			if (num11 <= 0)
			{
				this.LLog(LNG.Print("No troops to send"), false);
				return;
			}
			int num12 = ResearchData.commandResearchTroopLevels[(int)GameEngine.Instance.World.userResearchData.Research_Command];
			if (num11 > num12 - returnData.TotalTroops)
			{
				this.LLog(LNG.Print("Not enough space at vassal"), false);
				return;
			}
			if (num11 < this.VassalTroopsMinimum && num12 - returnData.TotalTroops > this.VassalTroopsMinimum)
			{
				this.LLog(string.Format("{0}/{1} {2}", num11, this.VassalTroopsMinimum, LNG.Print("troops ready. Need to gather more troops!")), false);
				return;
			}
			RemoteServices.Instance.SendTroopsToVassal(connecter, this.m_vassalVillageID, num6, num7, num8, num9, num10);
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x0005AEA4 File Offset: 0x000590A4
		internal void Save()
		{
			List<string> list = new List<string>();
			foreach (object obj in ((IEnumerable)this._settingsGrid.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				string item = string.Concat(new string[]
				{
					string.Format("{0}", dataGridViewRow.Cells[0].Value),
					string.Format(",{0}", dataGridViewRow.Cells[1].Value),
					string.Format(",{0}", dataGridViewRow.Cells[2].Value),
					string.Format(",{0}", dataGridViewRow.Cells[3].Value),
					string.Format(",{0}", dataGridViewRow.Cells[4].Value),
					string.Format(",{0}", dataGridViewRow.Cells[5].Value),
					string.Format(",{0}", dataGridViewRow.Cells[6].Value)
				});
				list.Add(item);
			}
			foreach (object obj2 in ((IEnumerable)this._capitalsSettingsGrid.Rows))
			{
				DataGridViewRow dataGridViewRow2 = (DataGridViewRow)obj2;
				string text = "";
				foreach (object obj3 in dataGridViewRow2.Cells)
				{
					DataGridViewCell dataGridViewCell = (DataGridViewCell)obj3;
					string str = text;
					object value = dataGridViewCell.Value;
					text = str + ((value != null) ? value.ToString() : null) + ",";
				}
				list.Add(text.Remove(text.Length - 1));
			}
			foreach (object obj4 in ((IEnumerable)this._vassalsSettingsGrid.Rows))
			{
				DataGridViewRow dataGridViewRow3 = (DataGridViewRow)obj4;
				string text2 = "";
				foreach (object obj5 in dataGridViewRow3.Cells)
				{
					DataGridViewCell dataGridViewCell2 = (DataGridViewCell)obj5;
					string str2 = text2;
					object value2 = dataGridViewCell2.Value;
					text2 = str2 + ((value2 != null) ? value2.ToString() : null) + ",";
				}
				list.Add(text2.Remove(text2.Length - 1));
			}
			string settingsFilePath = SettingsManager.GetSettingsFilePath("TroopsRecruiting.txt", true, new string[0]);
			File.WriteAllLines(settingsFilePath, list.ToArray());
			this.LLog(LNG.Print("Settings are saved to") + " " + settingsFilePath, false);
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x0005B220 File Offset: 0x00059420
		internal bool Load()
		{
			bool result;
			try
			{
				string settingsFilePath = SettingsManager.GetSettingsFilePath("TroopsRecruiting.txt", false, new string[0]);
				if (!File.Exists(settingsFilePath))
				{
					this.LLog(LNG.Print("File doesn't exist") + ": " + settingsFilePath, false);
					result = false;
				}
				else
				{
					string[] array = File.ReadAllLines(settingsFilePath);
					foreach (string text in array)
					{
						string[] line = text.Split(new char[]
						{
							','
						});
						if (!TroopsrecruitingService.SearchAndInsertLine(this._settingsGrid, line) && !TroopsrecruitingService.SearchAndInsertLine(this._capitalsSettingsGrid, line))
						{
							TroopsrecruitingService.SearchAndInsertLine(this._vassalsSettingsGrid, line);
						}
					}
					result = true;
				}
			}
			catch (Exception ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.TroopsRecruiting);
				result = false;
			}
			return result;
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x0005B2EC File Offset: 0x000594EC
		private static bool SearchAndInsertLine(DataGridView grid, string[] line)
		{
			for (int i = 0; i < grid.Rows.Count; i++)
			{
				string text = grid[0, i].Value.ToString();
				if (ControlForm.GetId(text) == ControlForm.GetId(line[0]))
				{
					grid.Rows.RemoveAt(i);
					line[0] = text;
					grid.Rows.Insert(i, line);
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x0005B354 File Offset: 0x00059554
		private static int GetCapitalCurrentTroops(VillageMap village)
		{
			int locallyMade_Peasants = village.LocallyMade_Peasants;
			int locallyMade_Archers = village.LocallyMade_Archers;
			int locallyMade_Pikemen = village.LocallyMade_Pikemen;
			int locallyMade_Swordsmen = village.LocallyMade_Swordsmen;
			int locallyMade_Catapults = village.LocallyMade_Catapults;
			int num = locallyMade_Swordsmen + locallyMade_Pikemen + locallyMade_Peasants + locallyMade_Catapults + locallyMade_Archers;
			return village.calcTotalTroops() + num;
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x0005B39C File Offset: 0x0005959C
		private static int[] GetCapitalCurrentTroopsArray(VillageMap village)
		{
			int locallyMade_Peasants = village.LocallyMade_Peasants;
			int locallyMade_Archers = village.LocallyMade_Archers;
			int locallyMade_Pikemen = village.LocallyMade_Pikemen;
			int locallyMade_Swordsmen = village.LocallyMade_Swordsmen;
			int locallyMade_Catapults = village.LocallyMade_Catapults;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			int num9 = 0;
			int num10 = 0;
			int num11 = 0;
			int num12 = 0;
			GameEngine.Instance.World.getTotalTroopsOutOfVillage(village.VillageID, ref num, ref num2, ref num3, ref num4, ref num5, ref num6, ref num7, ref num8, ref num9, ref num10, ref num11, ref num12);
			int num13 = 0;
			int num14 = 0;
			int num15 = 0;
			int num16 = 0;
			int num17 = 0;
			CastleMap castleMap = (CastleMap)GameEngine.Instance.Castles[village.VillageID];
			castleMap.countOwnPlacedTroopTypes(ref num13, ref num14, ref num15, ref num16, ref num17);
			num += village.m_numPeasants + locallyMade_Peasants;
			num += num13;
			num += num7;
			num2 += village.m_numArchers + locallyMade_Archers;
			num2 += num14;
			num2 += num8;
			num3 += village.m_numPikemen + locallyMade_Pikemen;
			num3 += num15;
			num3 += num9;
			num4 += village.m_numSwordsmen + locallyMade_Swordsmen;
			num4 += num16;
			num4 += num10;
			num5 += village.m_numCatapults + locallyMade_Catapults;
			num5 += num11;
			return new int[]
			{
				num,
				num2,
				num3,
				num4,
				num5
			};
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x0005B4FC File Offset: 0x000596FC
		internal override void TranslateUI()
		{
			TroopsrecruitingService.TroopsNames = new string[]
			{
				SK.Text("GENERIC_Armed_Peasants", "Armed Peasants"),
				SK.Text("GENERIC_Archers", "Archers"),
				SK.Text("GENERIC_Pikemen", "Pikemen"),
				SK.Text("GENERIC_Swordsmen", "Swordsmen"),
				SK.Text("GENERIC_Catapults", "Catapults"),
				SK.Text("GENERIC_Captains", "Captains")
			};
			this._settingsGrid.Columns[0].HeaderText = SK.Text("GENERIC_Village", "Village");
			for (int i = 2; i < 8; i++)
			{
				this._settingsGrid.Columns[i].HeaderText = TroopsrecruitingService.TroopsNames[i - 2];
			}
			this._capitalsSettingsGrid.Columns[0].HeaderText = SK.Text("GENERIC_Capital", "Capital");
			for (int j = 2; j < 7; j++)
			{
				this._capitalsSettingsGrid.Columns[j].HeaderText = TroopsrecruitingService.TroopsNames[j - 2];
			}
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x0005B620 File Offset: 0x00059820
		private void SettingsGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex == -1 || e.ColumnIndex < 2)
			{
				return;
			}
			DataGridView dataGridView = sender as DataGridView;
			object value = dataGridView[e.ColumnIndex, e.RowIndex].Value;
			int num;
			if (value == null || !int.TryParse(value.ToString(), out num))
			{
				MyMessageBox.Show(LNG.Print("Only numbers 0-9!"));
				dataGridView[e.ColumnIndex, e.RowIndex].Value = 0;
			}
		}

		// Token: 0x04000559 RID: 1369
		internal static string[] TroopsNames;

		// Token: 0x0400055A RID: 1370
		private int[] troopsTypes = new int[]
		{
			70,
			72,
			73,
			71,
			74,
			85
		};

		// Token: 0x0400055B RID: 1371
		private int[] troopsCost;

		// Token: 0x0400055C RID: 1372
		private DataGridView _settingsGrid;

		// Token: 0x0400055D RID: 1373
		private DataGridView _capitalsSettingsGrid;

		// Token: 0x0400055E RID: 1374
		private DataGridView _vassalsSettingsGrid;

		// Token: 0x0400055F RID: 1375
		internal int VassalTroopsMinimum = 1;

		// Token: 0x04000560 RID: 1376
		private int m_vassalVillageID = -1;

		// Token: 0x04000561 RID: 1377
		private const string TroopsRecruitingFileName = "TroopsRecruiting.txt";
	}
}
