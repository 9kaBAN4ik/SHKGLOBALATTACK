using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms;

namespace Upgrade.Services
{
	// Token: 0x02000093 RID: 147
	internal class TradeService : ABaseService
	{
		// Token: 0x060003E1 RID: 993 RVA: 0x00007CE0 File Offset: 0x00005EE0
		internal override void TranslateUI()
		{
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x00056A3C File Offset: 0x00054C3C
		public TradeService(Log log, DataGridView dataGridView_Trade, NumericUpDown numericUpDown_PacketsPerTrade, DataGridView dataGridView_TradeRoutes) : base(log)
		{
			this._numericUpDown_PacketsPerTrade = numericUpDown_PacketsPerTrade;
			this.VillagesTradeInfo = new Dictionary<int, VillageTradeInfo>();
			this._stockExchanges = new List<StockExchangePanel.StockExchangeInfo>();
			this._dataGridView_Trade = dataGridView_Trade;
			this._dataGridView_Trade.CellValueChanged += this.dataGridView_Trade_CellValueChanged;
			foreach (byte b in TradeService.tradeTypeId)
			{
				dataGridView_Trade.Rows.Add(new object[]
				{
					b,
					VillageBuildingsData.getResourceNames((int)b),
					false,
					0,
					0,
					false,
					150
				});
			}
			this._dataGridView_TradeRoutes = dataGridView_TradeRoutes;
			this._dataGridView_TradeRoutes.CellValueChanged += this.DataGridView_TradeRoutes_CellValueChanged;
			this._tradeRoutes = new List<TradeRoute>();
			this.CapitalsList = (from v in GameEngine.Instance.World.VillageList
			where v.Capital
			select v.id).ToArray<int>();
			this.AreWeaponsAllowed = (GameEngine.Instance.LocalWorldData.EraWorld || !GameEngine.Instance.World.FourthAgeWorld || GameEngine.Instance.World.SixthAgeWorld);
			if (!this.AreWeaponsAllowed)
			{
				this.LLog(SK.Text("TRADE_NO_WEAPONS_4TH_AGE", "Weapons cannot be bought or sold in this Age."), false);
			}
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x00056C48 File Offset: 0x00054E48
		internal void CopySettings(ListBox listBox_ActiveVillages, IEnumerable<string> listOfVillages, int id, bool saveSettings)
		{
			if (!this.VillagesTradeInfo.ContainsKey(id))
			{
				return;
			}
			foreach (string text in listOfVillages)
			{
				int id2 = ControlForm.GetId(text);
				if (id2 != id && this.VillagesTradeInfo.ContainsKey(id2))
				{
					for (int i = 0; i < this.VillagesTradeInfo[id].TradeTypes.Length; i++)
					{
						this.VillagesTradeInfo[id2].TradeTypes[i] = this.VillagesTradeInfo[id].TradeTypes[i].Clone();
					}
					this.VillagesTradeInfo[id2].IsTrading = this.VillagesTradeInfo[id].IsTrading;
					int num = listBox_ActiveVillages.Items.IndexOf(text);
					if (num != -1)
					{
						listBox_ActiveVillages.SetSelected(num, this.VillagesTradeInfo[id2].IsTrading);
					}
				}
			}
			if (saveSettings)
			{
				this.SaveSettings(false);
			}
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x00009D84 File Offset: 0x00007F84
		private void LLog(string message, bool isError = false)
		{
			this.Log(message, ControlForm.Tab.Trade, isError);
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x00056D64 File Offset: 0x00054F64
		internal void SaveTradeRoute2(TradeRoute route, object[] row, int index = -1)
		{
			if (index == -1)
			{
				this._tradeRoutes.Add(route);
				this._dataGridView_TradeRoutes.Rows.Add(row);
				return;
			}
			this._tradeRoutes[index] = route;
			this._dataGridView_TradeRoutes.Rows.RemoveAt(index);
			this._dataGridView_TradeRoutes.Rows.Insert(index, row);
			this._dataGridView_TradeRoutes.ClearSelection();
			this._dataGridView_TradeRoutes.Rows[index].Selected = true;
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x00056DE8 File Offset: 0x00054FE8
		internal static TradeRoute OptimizeRoute(TradeRoute route)
		{
			route.SortedRecipients.Clear();
			int squareDistance = route.DistanceLimit * route.DistanceLimit;
			using (List<int>.Enumerator enumerator = route.From.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int sender = enumerator.Current;
					List<int> value = (from id in route.To
					where id != sender && (!route.IsDistanceLimited || GameEngine.Instance.World.getSquareDistance(sender, id) <= squareDistance)
					orderby GameEngine.Instance.World.getSquareDistance(sender, id)
					select id).ToList<int>();
					route.SortedRecipients.Add(sender, value);
				}
			}
			route.From.RemoveAll((int sender) => route.SortedRecipients[sender].Count <= 0);
			route.From = (from x in route.From
			orderby (from y in route.SortedRecipients[x]
			select GameEngine.Instance.World.getSquareDistance(x, y)).Sum() descending
			select x).ToList<int>();
			return route;
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x00009D94 File Offset: 0x00007F94
		public void DeleteRoute(int index)
		{
			this._dataGridView_TradeRoutes.Rows.RemoveAt(index);
			this._dataGridView_TradeRoutes.ClearSelection();
			this._tradeRoutes.RemoveAt(index);
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x00056F28 File Offset: 0x00055128
		private void dataGridView_Trade_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex == -1)
			{
				return;
			}
			if (this.SelectedVillageId == -1)
			{
				this.LLog(LNG.Print("Village is not selected"), false);
				return;
			}
			object value = this._dataGridView_Trade[e.ColumnIndex, e.RowIndex].Value;
			TradeType tradeType = this.VillagesTradeInfo[this.SelectedVillageId].TradeTypes[e.RowIndex];
			switch (e.ColumnIndex)
			{
			case 2:
				tradeType.Sell = (bool)value;
				return;
			case 3:
			{
				int minSellPrice;
				if (value == null || !int.TryParse(value.ToString(), out minSellPrice))
				{
					MyMessageBox.Show(LNG.Print("Only numbers 0-9!"));
					this._dataGridView_Trade[e.ColumnIndex, e.RowIndex].Value = tradeType.MinSellPrice;
					return;
				}
				tradeType.MinSellPrice = minSellPrice;
				return;
			}
			case 4:
			{
				int sellLimit;
				if (value == null || !int.TryParse(value.ToString(), out sellLimit))
				{
					MyMessageBox.Show(LNG.Print("Only numbers 0-9!"));
					this._dataGridView_Trade[e.ColumnIndex, e.RowIndex].Value = tradeType.SellLimit;
					return;
				}
				tradeType.SellLimit = sellLimit;
				return;
			}
			case 5:
				tradeType.Buy = (bool)value;
				return;
			case 6:
			{
				int maxBuyPrice;
				if (value == null || !int.TryParse(value.ToString(), out maxBuyPrice))
				{
					MyMessageBox.Show(LNG.Print("Only numbers 0-9!"));
					this._dataGridView_Trade[e.ColumnIndex, e.RowIndex].Value = tradeType.MaxBuyPrice;
					return;
				}
				tradeType.MaxBuyPrice = maxBuyPrice;
				return;
			}
			case 7:
			{
				int buyLimit;
				if (value == null || !int.TryParse(value.ToString(), out buyLimit))
				{
					MyMessageBox.Show(LNG.Print("Only numbers 0-9!"));
					this._dataGridView_Trade[e.ColumnIndex, e.RowIndex].Value = tradeType.BuyLimit;
					return;
				}
				tradeType.BuyLimit = buyLimit;
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x00057124 File Offset: 0x00055324
		private void DataGridView_TradeRoutes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex == -1)
			{
				return;
			}
			TradeRoute tradeRoute = this._tradeRoutes[e.RowIndex];
			object value = this._dataGridView_TradeRoutes[e.ColumnIndex, e.RowIndex].Value;
			switch (e.ColumnIndex)
			{
			case 0:
				tradeRoute.Name = ((value != null) ? value.ToString() : null);
				return;
			case 1:
				tradeRoute.Enabled = (bool)value;
				return;
			case 2:
			case 3:
			case 4:
				break;
			case 5:
			{
				int keepMinimum;
				if (value == null || !int.TryParse(value.ToString(), out keepMinimum))
				{
					MyMessageBox.Show(LNG.Print("Only numbers 0-9!"));
					this._dataGridView_TradeRoutes[e.ColumnIndex, e.RowIndex].Value = tradeRoute.KeepMinimum;
					return;
				}
				tradeRoute.KeepMinimum = keepMinimum;
				return;
			}
			case 6:
			{
				int maxMerchantsPerTransaction;
				if (value == null || !int.TryParse(value.ToString(), out maxMerchantsPerTransaction))
				{
					MyMessageBox.Show(LNG.Print("Only numbers 0-9!"));
					this._dataGridView_TradeRoutes[e.ColumnIndex, e.RowIndex].Value = tradeRoute.MaxMerchantsPerTransaction;
					return;
				}
				tradeRoute.MaxMerchantsPerTransaction = maxMerchantsPerTransaction;
				return;
			}
			case 7:
			{
				int sendMaximum;
				if (value == null || !int.TryParse(value.ToString(), out sendMaximum))
				{
					MyMessageBox.Show(LNG.Print("Only numbers 0-9!"));
					this._dataGridView_TradeRoutes[e.ColumnIndex, e.RowIndex].Value = tradeRoute.SendMaximum;
					return;
				}
				tradeRoute.SendMaximum = sendMaximum;
				return;
			}
			case 8:
				tradeRoute.IsDistanceLimited = (bool)value;
				TradeService.OptimizeRoute(tradeRoute);
				return;
			case 9:
			{
				int distanceLimit;
				if (value == null || !int.TryParse(value.ToString(), out distanceLimit))
				{
					MyMessageBox.Show(LNG.Print("Only numbers 0-9!"));
					this._dataGridView_TradeRoutes[e.ColumnIndex, e.RowIndex].Value = tradeRoute.DistanceLimit;
					return;
				}
				tradeRoute.DistanceLimit = distanceLimit;
				TradeService.OptimizeRoute(tradeRoute);
				break;
			}
			default:
				return;
			}
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x00057328 File Offset: 0x00055528
		public void RemoveVillageFromRoutes(int villageId)
		{
			for (int i = 0; i < this._tradeRoutes.Count; i++)
			{
				TradeRoute tradeRoute = this._tradeRoutes[i];
				tradeRoute.From.Remove(villageId);
				tradeRoute.To.Remove(villageId);
				TradeService.OptimizeRoute(tradeRoute);
			}
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x0005737C File Offset: 0x0005557C
		private void LoadRoutes()
		{
			try
			{
				string settingsFilePath = SettingsManager.GetSettingsFilePath("Routes.txt", false, new string[]
				{
					"Trade"
				});
				if (!File.Exists(settingsFilePath))
				{
					this.LLog(LNG.Print("File not found") + ": " + settingsFilePath, false);
				}
				else
				{
					Dictionary<int, string> currentVillages = TradeService.GetCurrentVillagesWithNames();
					string[] array = File.ReadAllLines(settingsFilePath);
					this._tradeRoutes.Clear();
					this._dataGridView_TradeRoutes.Rows.Clear();
					foreach (string text in array)
					{
						string[] array3 = text.Split(new char[]
						{
							';'
						});
						bool flag = array3[1] == "True";
						List<int> list = new List<int>();
						if (string.IsNullOrEmpty(array3[2]))
						{
							this.LLog(LNG.Print("Warning! List of senders is empty in Route") + " : \"" + array3[0] + "\"", true);
						}
						else
						{
							list = DX.GetListOfIds(array3[2]);
							this.ValidateVillages(list, currentVillages);
						}
						List<int> list2 = new List<int>();
						if (string.IsNullOrEmpty(array3[3]))
						{
							this.LLog(LNG.Print("Warning! List of recipients is empty in Route") + " : \"" + array3[0] + "\"", true);
						}
						else
						{
							list2 = DX.GetListOfIds(array3[3]);
							this.ValidateVillages(list2, currentVillages);
						}
						List<int> listOfIds = DX.GetListOfIds(array3[4]);
						int num = int.Parse(array3[5]);
						int num2 = int.Parse(array3[6]);
						int num3 = int.Parse(array3[7]);
						bool flag2 = bool.Parse(array3[8]);
						int num4 = int.Parse(array3[9]);
						this._tradeRoutes.Add(TradeService.OptimizeRoute(new TradeRoute(array3[0], flag, list, list2, listOfIds, num, num2, num3, flag2, num4)));
						DataGridViewRowCollection rows = this._dataGridView_TradeRoutes.Rows;
						object[] array4 = new object[10];
						array4[0] = array3[0];
						array4[1] = flag;
						array4[2] = string.Join(",", list.Select((int id) => currentVillages[id]).ToArray<string>());
						array4[3] = string.Join(",", list2.Select((int id) => currentVillages[id]).ToArray<string>());
						array4[4] = string.Join(",", (from x in listOfIds
						select VillageBuildingsData.getResourceNames(x)).ToArray<string>());
						array4[5] = num;
						array4[6] = num2;
						array4[7] = num3;
						array4[8] = flag2;
						array4[9] = num4;
						rows.Add(array4);
					}
					this.LLog(LNG.Print("Trade Routes Loaded"), false);
				}
			}
			catch (Exception ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.Trade);
			}
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x00057698 File Offset: 0x00055898
		private void SaveRoutes()
		{
			string[] array = new string[this._tradeRoutes.Count];
			int num = 0;
			foreach (TradeRoute tradeRoute in this._tradeRoutes)
			{
				array[num] = string.Concat(new string[]
				{
					tradeRoute.Name,
					string.Format(";{0}", tradeRoute.Enabled),
					";",
					DX.GetStringOfIds(tradeRoute.From),
					";",
					DX.GetStringOfIds(tradeRoute.To),
					";",
					DX.GetStringOfIds(tradeRoute.Resources),
					string.Format(";{0};{1};{2};{3};{4}", new object[]
					{
						tradeRoute.KeepMinimum,
						tradeRoute.MaxMerchantsPerTransaction,
						tradeRoute.SendMaximum,
						tradeRoute.IsDistanceLimited,
						tradeRoute.DistanceLimit
					})
				});
				num++;
			}
			string settingsFilePath = SettingsManager.GetSettingsFilePath("Routes.txt", true, new string[]
			{
				"Trade"
			});
			File.WriteAllLines(settingsFilePath, array);
			this.LLog(LNG.Print("Trade Routes saved to") + ": " + settingsFilePath, false);
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x00057814 File Offset: 0x00055A14
		private static Dictionary<int, string> GetCurrentVillagesWithNames()
		{
			List<int> listOfUserVillages = GameEngine.Instance.World.getListOfUserVillages();
			Dictionary<int, string> dictionary = new Dictionary<int, string>();
			foreach (int num in listOfUserVillages)
			{
				dictionary.Add(num, GameEngine.Instance.World.getVillageName(num));
			}
			return dictionary;
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x0005788C File Offset: 0x00055A8C
		private void ValidateVillages(List<int> list, Dictionary<int, string> validList)
		{
			List<int> list2 = new List<int>();
			foreach (int num in list)
			{
				if (!validList.ContainsKey(num))
				{
					list2.Add(num);
					this.LLog(LNG.Print("You no longer own village") + ": " + GameEngine.Instance.World.getVillageNameOrType(num), false);
				}
			}
			foreach (int item in list2)
			{
				list.Remove(item);
			}
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x00057954 File Offset: 0x00055B54
		private void TradeBetweenVillages()
		{
			Dictionary<int, string> currentVillagesWithNames = TradeService.GetCurrentVillagesWithNames();
			Dictionary<int, VillageMap> dictionary = new Dictionary<int, VillageMap>();
			foreach (int num in currentVillagesWithNames.Keys)
			{
				VillageMap village = GameEngine.Instance.getVillage(num);
				if (village == null)
				{
					this.LLog(LNG.Print("Village wasn't loaded:") + " " + currentVillagesWithNames[num], true);
				}
				else
				{
					dictionary.Add(num, village);
				}
			}
			List<TradeRoute> list = new List<TradeRoute>(this._tradeRoutes);
			foreach (TradeRoute tradeRoute in list)
			{
				if (tradeRoute.Enabled)
				{
					this.LLog(LNG.Print("Process route") + ": " + tradeRoute.Name, false);
					foreach (int num2 in tradeRoute.From)
					{
						if (dictionary.ContainsKey(num2))
						{
							VillageMap map = dictionary[num2];
							if (this.IsAutoHireMerhantsEnabled)
							{
								this.AutoHireMerchants(map);
							}
							int num3 = map.m_numTradersAtHome;
							int num4 = this.CountMovingMerchants(num2, false);
							if (num4 < this.MerchantsExchangeLimit)
							{
								foreach (int num5 in tradeRoute.SortedRecipients[num2])
								{
									if (dictionary.ContainsKey(num5))
									{
										VillageMap villageMap = dictionary[num5];
										IOrderedEnumerable<int> source = tradeRoute.Resources.OrderByDescending((int r) => map.getResourceLevel(r));
										foreach (int num6 in source.ThenByDescending((int r) => map.getResourceProductionPerDay(r) / (double)DX.GetCap(r)))
										{
											if (num3 < this.MerchantsPerTrade)
											{
												break;
											}
											if (num4 >= this.MerchantsExchangeLimit)
											{
												break;
											}
											double resourceLevel = map.getResourceLevel(num6);
											if (resourceLevel > (double)tradeRoute.KeepMinimum)
											{
												double num7 = villageMap.getResourceLevel(num6) + (double)this.GetPurchasedAmount(num5, num6);
												if (num7 < (double)tradeRoute.SendMaximum)
												{
													int cap = DX.GetCap(num6);
													double num8 = (tradeRoute.SendMaximum > cap) ? ((double)cap - num7) : ((double)tradeRoute.SendMaximum - num7);
													double num9 = resourceLevel - (double)tradeRoute.KeepMinimum;
													if (num8 > num9)
													{
														num8 = num9;
													}
													int num10 = GameEngine.Instance.LocalWorldData.traderCarryingLevels[num6];
													if (num8 >= (double)(num10 * this.MerchantsPerTrade))
													{
														int num11 = (int)num8 / num10;
														num11 = Math.Min(num11, num3);
														num11 = Math.Min(num11, tradeRoute.MaxMerchantsPerTransaction);
														num11 = Math.Min(num11, this.MerchantsExchangeLimit - num4);
														int num12 = num11 * num10;
														map.sendResources(num5, num6, num12);
														num3 -= num11;
														num4 += num11;
														this.LLog(string.Format("{0} {1} {2} of {3} ", new object[]
														{
															currentVillagesWithNames[num2],
															LNG.Print("sent"),
															num12,
															VillageBuildingsData.getResourceNames(num6)
														}) + string.Format("to {0}. {1} {2}", currentVillagesWithNames[num5], num3, LNG.Print("merchants left")), false);
														if (base.RandomSleepOrExit(3000, 6000))
														{
															return;
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			this.LLog(LNG.Print("Trade between Villages cycle is over."), false);
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x00057DF0 File Offset: 0x00055FF0
		private void TradeWithMarkets()
		{
			Dictionary<int, VillageTradeInfo> ienum = new Dictionary<int, VillageTradeInfo>(this.VillagesTradeInfo);
			foreach (KeyValuePair<int, VillageTradeInfo> villageInfo in ienum.Shuffle<KeyValuePair<int, VillageTradeInfo>>())
			{
				if (villageInfo.Value.IsTrading)
				{
					int key = villageInfo.Key;
					string villageName = GameEngine.Instance.World.getVillageName(key);
					VillageMap map = GameEngine.Instance.getVillage(key);
					if (map == null)
					{
						this.LLog(LNG.Print("Village wasn't loaded:") + " " + villageName, true);
					}
					else
					{
						this.LLog(LNG.Print("Trading village") + ": " + villageName, false);
						if (this.IsAutoHireMerhantsEnabled)
						{
							this.AutoHireMerchants(map);
						}
						int num = map.m_numTradersAtHome;
						int num2 = this.CountMovingMerchants(key, true);
						if (num2 < this.MerchantsTradeLimit && num >= this.MerchantsPerTrade)
						{
							IEnumerable<TradeType> source = from t in villageInfo.Value.TradeTypes
							where (t.Sell || t.Buy) && (this.AreWeaponsAllowed || !this.WeaponsTradeTypesIds.Contains(t.ResourceId))
							select t;
							foreach (TradeType tradeType in source.OrderByDescending((TradeType t) => Math.Abs(map.getResourceLevel((int)t.ResourceId) - (double)(t.Sell ? t.SellLimit : t.BuyLimit)) / (double)DX.GetCap((int)t.ResourceId)))
							{
								if (num < this.MerchantsPerTrade)
								{
									break;
								}
								if (num2 >= this.MerchantsTradeLimit)
								{
									break;
								}
								int resourceId = (int)tradeType.ResourceId;
								int num3 = (int)map.getResourceLevel(resourceId);
								num3 += this.GetPurchasedAmount(villageInfo.Key, resourceId);
								int num4 = num3 - Math.Max(tradeType.SellLimit, 0);
								int num5 = Math.Min(tradeType.BuyLimit, DX.GetCap(resourceId)) - num3;
								int num6 = CardTypes.adjustTraderCarryLevels(GameEngine.Instance.cardsManager.UserCardData, GameEngine.Instance.LocalWorldData.traderCarryingLevels[resourceId]);
								string resourceNames = VillageBuildingsData.getResourceNames(resourceId);
								int num7 = num6 * this.MerchantsPerTrade;
								if (tradeType.Sell && num4 > num7)
								{
									int num9;
									int num8 = this.BestPrice(villageInfo, tradeType.MinSellPrice, resourceId, true, out num9);
									if (num8 == -1)
									{
										this.LLog(LNG.Print("No Market with good price for") + " " + resourceNames, false);
									}
									else
									{
										if (num8 == -2)
										{
											this.LLog(LNG.Print("Trade module switched off!"), false);
											return;
										}
										int num10 = Math.Min(num4 / num6, num);
										num10 = Math.Min(num10, this.MerchantsTradeLimit - num2);
										int num11 = num10 * num6;
										map.stockExchangeTrade(num8, resourceId, num11, false);
										num -= num10;
										num2 += num10;
										this.LLog(string.Format("{0} {1} {2} of {3} ", new object[]
										{
											villageName,
											LNG.Print("is selling"),
											num11,
											resourceNames
										}) + string.Format("to {0}. {1} {2}", GameEngine.Instance.World.getVillageName(num8), num, LNG.Print("merchants left")), false);
										if (base.RandomSleepOrExit(3000, 4000))
										{
											return;
										}
									}
								}
								else if (tradeType.Buy && num5 > num7)
								{
									int num13;
									int num12 = this.BestPrice(villageInfo, tradeType.MaxBuyPrice, resourceId, false, out num13);
									if (num12 == -1)
									{
										this.LLog(LNG.Print("No Market with good price for") + " " + resourceNames, false);
									}
									else
									{
										if (num12 == -2)
										{
											this.LLog(LNG.Print("Trade module switched off!"), false);
											return;
										}
										if (num13 < num7)
										{
											this.LLog(string.Format("{0} {1} {2}. {3}: {4}", new object[]
											{
												LNG.Print("Found only"),
												num13,
												resourceNames,
												LNG.Print("Your settings require"),
												num7
											}), false);
										}
										else
										{
											int num14 = Math.Min(num5, num13) / num6;
											num14 = Math.Min(num14, num);
											num14 = Math.Min(num14, this.MerchantsTradeLimit - num2);
											int num15 = TradingCalcs.calcGoldCost(GameEngine.Instance.LocalWorldData, num13, resourceId, num13 - num14 * num6);
											int num16 = num15 * num14;
											int num17 = (int)GameEngine.Instance.World.getCurrentGold();
											if (num16 >= num17)
											{
												this.LLog(string.Format("{0}: merchants to send = {1}, price = {2}, gold needed = {3}, gold available = {4}", new object[]
												{
													LNG.Print("Not enough gold"),
													num14,
													num15,
													num16,
													num17
												}), false);
												num14 = num17 / num15;
											}
											if (num14 >= this.MerchantsPerTrade)
											{
												int num18 = num14 * num6;
												map.stockExchangeTrade(num12, resourceId, num18, true);
												num -= num14;
												num2 += num14;
												this.LLog(string.Format("{0} {1} {2} of {3} ", new object[]
												{
													villageName,
													LNG.Print("is buying"),
													num18,
													resourceNames
												}) + string.Format("{0} {1}. {2} {3}", new object[]
												{
													LNG.Print("at"),
													GameEngine.Instance.World.getVillageName(num12),
													num,
													LNG.Print("merchants left")
												}), false);
												if (base.RandomSleepOrExit(3000, 4000))
												{
													return;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			this.LLog(LNG.Print("Trade with Markets cycle is over."), false);
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x00009DBE File Offset: 0x00007FBE
		public override void ConcreteAction()
		{
			this.TradeWithMarkets();
			this.TradeBetweenVillages();
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x000583F4 File Offset: 0x000565F4
		private int GetPurchasedAmount(int villageId, int resourceId)
		{
			if (this.IgnoreCurrentTransactions)
			{
				return 0;
			}
			SparseArray traderArray = GameEngine.Instance.World.getTraderArray();
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			bool flag;
			do
			{
				try
				{
					foreach (object obj in traderArray)
					{
						WorldMap.LocalTrader localTrader = (WorldMap.LocalTrader)obj;
						MarketTraderData trader = localTrader.trader;
						if (trader.homeVillageID == villageId && trader.resource == resourceId && (trader.traderState == 5 || trader.traderState == 6))
						{
							num2 += trader.amount;
						}
						if (trader.targetVillageID == villageId && trader.resource == resourceId && trader.traderState == 1)
						{
							num3 += trader.amount;
						}
					}
					flag = true;
				}
				catch (InvalidOperationException)
				{
					flag = false;
				}
			}
			while (!flag);
			if (num2 > 0)
			{
				this.LLog(string.Format("{0} {1}: {2}", villageId, LNG.Print("is already buying from markets"), num2), false);
			}
			if (num3 > 0)
			{
				this.LLog(string.Format("{0} {1}: {2} {3}", new object[]
				{
					villageId,
					LNG.Print("is receiving from other villages"),
					num3,
					VillageBuildingsData.getResourceNames(resourceId)
				}), false);
			}
			return num + num2 + num3;
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x00058560 File Offset: 0x00056760
		private int CountMovingMerchants(int villageId, bool trade)
		{
			SparseArray traderArray = GameEngine.Instance.World.getTraderArray();
			int num = 0;
			int num2 = 0;
			bool flag;
			do
			{
				try
				{
					foreach (object obj in traderArray)
					{
						WorldMap.LocalTrader localTrader = (WorldMap.LocalTrader)obj;
						MarketTraderData trader = localTrader.trader;
						if (trader.homeVillageID == villageId)
						{
							if (GameEngine.Instance.World.isCapital(trader.targetVillageID))
							{
								num += trader.numTraders;
							}
							else
							{
								num2 += trader.numTraders;
							}
						}
					}
					flag = true;
				}
				catch (InvalidOperationException)
				{
					flag = false;
				}
			}
			while (!flag);
			if (trade)
			{
				if (num > 0)
				{
					this.LLog(string.Format("{0} {1}: {2}", villageId, LNG.Print("has already sent merchants to markets"), num), false);
				}
				return num;
			}
			if (num2 > 0)
			{
				this.LLog(string.Format("{0} {1}: {2}", villageId, LNG.Print("has already sent merchants to villages"), num2), false);
			}
			return num2;
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x00058684 File Offset: 0x00056884
		internal void GetStockExchangePremiumData(int villageID)
		{
			List<StockExchangePanel.ClosestCapitalSortItem> list = new List<StockExchangePanel.ClosestCapitalSortItem>();
			foreach (int num in this.CapitalsList)
			{
				if (num != villageID)
				{
					int squareDistance = GameEngine.Instance.World.getSquareDistance(villageID, num);
					if (squareDistance < 40000 && GameEngine.Instance.World.allowExchangeTrade(num, villageID))
					{
						list.Add(new StockExchangePanel.ClosestCapitalSortItem
						{
							distance = squareDistance,
							villageID = num
						});
					}
				}
			}
			list.Sort((StockExchangePanel.ClosestCapitalSortItem a, StockExchangePanel.ClosestCapitalSortItem b) => a.distance.CompareTo(b.distance));
			if (list.Count > 20)
			{
				list.RemoveRange(20, list.Count - 20);
			}
			IEnumerable<int> source = from m in list
			select m.villageID into m
			where !this._stockExchanges.Any((StockExchangePanel.StockExchangeInfo ex) => ex.villageID == m && (DateTime.Now - ex.lastTime).TotalMinutes < 1.0)
			select m;
			if (source.Count<int>() > 0)
			{
				RemoteServices.Instance.set_GetStockExchangeData_UserCallBack(new RemoteServices.GetStockExchangeData_UserCallBack(this.RecieveStockExchangeData));
				RemoteServices.Instance.GetStockExchangePremiumData(villageID, source.ToArray<int>());
			}
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x000587AC File Offset: 0x000569AC
		public void RecieveStockExchangeData(GetStockExchangeData_ReturnType returnData)
		{
			if (!returnData.Success)
			{
				this.LLog(ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID) + ". Village " + GameEngine.Instance.World.getVillageName(returnData.villageID), true);
				return;
			}
			this.SaveStockExchangeData(returnData);
			if (returnData.otherVillages != null)
			{
				foreach (GetStockExchangeData_ReturnType returnData2 in returnData.otherVillages)
				{
					this.SaveStockExchangeData(returnData2);
				}
			}
			this._updatingMarket.Set();
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x0005885C File Offset: 0x00056A5C
		private void SaveStockExchangeData(GetStockExchangeData_ReturnType returnData)
		{
			this._stockExchanges.RemoveAll((StockExchangePanel.StockExchangeInfo i) => i.villageID == returnData.villageID);
			this._stockExchanges.Add(new StockExchangePanel.StockExchangeInfo
			{
				lastTime = DateTime.Now,
				villageID = returnData.villageID,
				woodLevel = returnData.woodLevel,
				stoneLevel = returnData.stoneLevel,
				ironLevel = returnData.ironLevel,
				pitchLevel = returnData.pitchLevel,
				aleLevel = returnData.aleLevel,
				applesLevel = returnData.applesLevel,
				breadLevel = returnData.breadLevel,
				meatLevel = returnData.meatLevel,
				cheeseLevel = returnData.cheeseLevel,
				vegLevel = returnData.vegLevel,
				fishLevel = returnData.fishLevel,
				bowsLevel = returnData.bowsLevel,
				pikesLevel = returnData.pikesLevel,
				swordsLevel = returnData.swordsLevel,
				armourLevel = returnData.armourLevel,
				catapultsLevel = returnData.catapultsLevel,
				furnitureLevel = returnData.furnitureLevel,
				clothesLevel = returnData.clothesLevel,
				saltLevel = returnData.saltLevel,
				venisonLevel = returnData.venisonLevel,
				silkLevel = returnData.silkLevel,
				spicesLevel = returnData.spicesLevel,
				metalwareLevel = returnData.metalwareLevel,
				wineLevel = returnData.wineLevel
			});
			this.LLog(GameEngine.Instance.World.getVillageName(returnData.villageID) + " " + LNG.Print("prices are downloaded"), false);
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x00058A88 File Offset: 0x00056C88
		private int BestPrice(KeyValuePair<int, VillageTradeInfo> villageInfo, int controlPrice, int resourceId, bool highestPrice, out int stockAmount)
		{
			int num = -1;
			double num2 = double.MaxValue;
			stockAmount = (highestPrice ? int.MaxValue : int.MinValue);
			Point villageLocation = GameEngine.Instance.World.getVillageLocation(villageInfo.Key);
			List<int> list = new List<int>(villageInfo.Value.QuickTargets);
			using (IEnumerator<int> enumerator = list.Shuffle<int>().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int marketId = enumerator.Current;
					int num3 = 0;
					StockExchangePanel.StockExchangeInfo stockExchangeInfo;
					do
					{
						stockExchangeInfo = this._stockExchanges.FirstOrDefault((StockExchangePanel.StockExchangeInfo e) => e.villageID == marketId);
						if (stockExchangeInfo == null || (DateTime.Now - stockExchangeInfo.lastTime).TotalMinutes >= 1.0)
						{
							this.LLog(string.Format("{0}: {1}", LNG.Print("Updating market info"), marketId), false);
							if (GameEngine.Instance.World.isAccountPremium())
							{
								this.GetStockExchangePremiumData(marketId);
							}
							else
							{
								RemoteServices.Instance.set_GetStockExchangeData_UserCallBack(new RemoteServices.GetStockExchangeData_UserCallBack(this.RecieveStockExchangeData));
								RemoteServices.Instance.GetStockExchangeData(marketId, true);
							}
							num3++;
							if (base.RandomSleepOrExit(2122, 2735))
							{
								goto Block_9;
							}
							this._updatingMarket.WaitOne(10000);
						}
					}
					while (stockExchangeInfo == null && num3 < 5);
					if (stockExchangeInfo == null)
					{
						continue;
					}
					int level = stockExchangeInfo.getLevel(resourceId);
					if ((highestPrice && level < stockAmount) || (!highestPrice && level > stockAmount))
					{
						stockAmount = level;
						num = marketId;
						num2 = (double)GameEngine.Instance.World.getSquareDistance(villageLocation.X, villageLocation.Y, marketId);
						continue;
					}
					if (level != stockAmount || (!highestPrice && level == 0))
					{
						continue;
					}
					int squareDistance = GameEngine.Instance.World.getSquareDistance(villageLocation.X, villageLocation.Y, marketId);
					if ((double)squareDistance < num2)
					{
						this.LLog(string.Format("{0} {1} ({2})<({3})", new object[]
						{
							marketId,
							LNG.Print("is closer"),
							squareDistance,
							num2
						}), false);
						num2 = (double)squareDistance;
						stockAmount = level;
						num = marketId;
						continue;
					}
					continue;
					Block_9:
					return -2;
				}
			}
			if (num == -1)
			{
				return -1;
			}
			this.LLog(string.Format("{0}: {1}", LNG.Print("Parish with best price"), num), false);
			if (!this.CheckPrice(controlPrice, !highestPrice, stockAmount, resourceId))
			{
				return -1;
			}
			return num;
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x00058D80 File Offset: 0x00056F80
		private bool CheckPrice(int controlPrice, bool buy, int stockAmount, int resourceId)
		{
			if ((buy && controlPrice >= 150) || (!buy && controlPrice <= 0))
			{
				return true;
			}
			WorldData localWorldData = GameEngine.Instance.LocalWorldData;
			int num = TradingCalcs.calcSellCost(localWorldData, stockAmount, resourceId);
			this.LLog(string.Format("{0}: {1} {2}", LNG.Print("Parish price vs limit price"), num, controlPrice), false);
			if (buy)
			{
				return num <= controlPrice;
			}
			return num >= controlPrice;
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x00058DF0 File Offset: 0x00056FF0
		public void LoadSettings(ListBox listBox_ActiveVillages, bool customLocation)
		{
			string text = ControlForm.SettingsFolder + "TradeInfo\\";
			if (customLocation)
			{
				FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
				{
					SelectedPath = text,
					ShowNewFolderButton = true
				};
				if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
				{
					this.LLog(LNG.Print("Loading cancelled"), false);
					return;
				}
				text = folderBrowserDialog.SelectedPath;
			}
			using (Dictionary<int, VillageTradeInfo>.Enumerator enumerator = this.VillagesTradeInfo.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<int, VillageTradeInfo> villageInfo = enumerator.Current;
					string text2 = string.Format("{0}\\{1}.csv", text, villageInfo.Key);
					if (!File.Exists(text2))
					{
						this.LLog(LNG.Print("File doesn't exist") + ": " + text2, false);
					}
					else
					{
						string[] array = File.ReadAllLines(text2);
						for (int i = 0; i < villageInfo.Value.TradeTypes.Length; i++)
						{
							TradeType tradeType = villageInfo.Value.TradeTypes[i];
							string[] array2 = array[i].Split(new char[]
							{
								','
							});
							tradeType.Sell = (array2[0] == "1");
							tradeType.MinSellPrice = Convert.ToInt32(array2[1]);
							tradeType.SellLimit = Convert.ToInt32(array2[2]);
							tradeType.Buy = (array2[3] == "1");
							tradeType.MaxBuyPrice = Convert.ToInt32(array2[4]);
							tradeType.BuyLimit = ((array2.Length == 6) ? Convert.ToInt32(array2[5]) : DX.GetCap((int)tradeType.ResourceId));
						}
						villageInfo.Value.QuickTargets = (from market in DX.GetListOfIds(array[24])
						where GameEngine.Instance.World.allowExchangeTrade(market, villageInfo.Key)
						select market).ToList<int>();
						bool flag = array[25] == "1";
						villageInfo.Value.IsTrading = flag;
						if (flag)
						{
							this.SelectedVillages.Add(villageInfo.Key);
						}
						else
						{
							this.SelectedVillages.Remove(villageInfo.Key);
						}
						for (int j = 0; j < listBox_ActiveVillages.Items.Count; j++)
						{
							if (listBox_ActiveVillages.Items[j].ToString().StartsWith(string.Format("[{0}]", villageInfo.Key)))
							{
								listBox_ActiveVillages.SetSelected(j, flag);
								break;
							}
						}
					}
				}
			}
			text = SettingsManager.GetSettingsFilePath("MerchantsPerTrade.txt", true, new string[0]);
			int value;
			if (File.Exists(text) && int.TryParse(File.ReadAllText(text), out value))
			{
				this._numericUpDown_PacketsPerTrade.Value = value;
			}
			text = SettingsManager.GetSettingsFilePath("IgnoreCurrentTransactions.txt", false, new string[]
			{
				"Trade"
			});
			bool @checked;
			if (File.Exists(text) && bool.TryParse(File.ReadAllText(text), out @checked))
			{
				DX.ControlForm.checkBox_TradeIgnoreCurrentTransactions.Checked = @checked;
			}
			text = SettingsManager.GetSettingsFilePath("AutoHireMerhants.txt", false, new string[]
			{
				"Trade"
			});
			bool checked2;
			if (File.Exists(text) && bool.TryParse(File.ReadAllText(text), out checked2))
			{
				DX.ControlForm.checkBox_AutoHireMerchants.Checked = checked2;
			}
			text = SettingsManager.GetSettingsFilePath("AutoHireMerhantsLimit.txt", false, new string[]
			{
				"Trade"
			});
			int value2;
			if (File.Exists(text) && int.TryParse(File.ReadAllText(text), out value2))
			{
				DX.ControlForm.numericUpDown_AutoHireMerchantsLimit.Value = value2;
			}
			this.LoadRoutes();
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x000591C0 File Offset: 0x000573C0
		public void SaveSettings(bool customLocation)
		{
			string text = ControlForm.SettingsFolder + "TradeInfo\\";
			if (customLocation)
			{
				FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
				{
					ShowNewFolderButton = true,
					SelectedPath = text
				};
				if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
				{
					this.LLog(LNG.Print("Saving cancelled"), false);
					return;
				}
				text = folderBrowserDialog.SelectedPath;
			}
			Thread thread = new Thread(new ParameterizedThreadStart(this.SaveSettingsBG));
			thread.Start(text);
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x00059234 File Offset: 0x00057434
		private void SaveSettingsBG(object param)
		{
			string text = param.ToString();
			foreach (KeyValuePair<int, VillageTradeInfo> keyValuePair in this.VillagesTradeInfo)
			{
				string[] array = new string[26];
				for (int i = 0; i < 24; i++)
				{
					TradeType tradeType = keyValuePair.Value.TradeTypes[i];
					array[i] = string.Format("{0},{1},{2},{3},{4},{5}", new object[]
					{
						Convert.ToInt32(tradeType.Sell),
						tradeType.MinSellPrice,
						tradeType.SellLimit,
						Convert.ToInt32(tradeType.Buy),
						tradeType.MaxBuyPrice,
						tradeType.BuyLimit
					});
				}
				StringBuilder stringBuilder = new StringBuilder();
				foreach (int value in keyValuePair.Value.QuickTargets)
				{
					stringBuilder.Append(value);
					stringBuilder.Append(',');
				}
				array[24] = stringBuilder.ToString();
				array[25] = (keyValuePair.Value.IsTrading ? "1" : "0");
				File.WriteAllLines(string.Format("{0}\\{1}.csv", text, keyValuePair.Key), array);
			}
			text = SettingsManager.GetSettingsFilePath("MerchantsPerTrade.txt", true, new string[0]);
			File.WriteAllText(text, this.MerchantsPerTrade.ToString());
			text = SettingsManager.GetSettingsFilePath("IgnoreCurrentTransactions.txt", true, new string[]
			{
				"Trade"
			});
			File.WriteAllText(text, this.IgnoreCurrentTransactions.ToString());
			text = SettingsManager.GetSettingsFilePath("AutoHireMerhants.txt", true, new string[]
			{
				"Trade"
			});
			File.WriteAllText(text, this.IsAutoHireMerhantsEnabled.ToString());
			text = SettingsManager.GetSettingsFilePath("AutoHireMerhantsLimit.txt", true, new string[]
			{
				"Trade"
			});
			File.WriteAllText(text, this.AutoHireMerchantsLimit.ToString());
			this.SaveRoutes();
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x0005949C File Offset: 0x0005769C
		public void AddMarkets(double maxDistance, int currentVillage = -1)
		{
			try
			{
				maxDistance *= maxDistance;
				if (currentVillage == -1)
				{
					using (Dictionary<int, VillageTradeInfo>.Enumerator enumerator = this.VillagesTradeInfo.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							KeyValuePair<int, VillageTradeInfo> villageInfo = enumerator.Current;
							this.AddMarketForVillage(maxDistance, villageInfo);
						}
						goto IL_70;
					}
				}
				this.AddMarketForVillage(maxDistance, this.VillagesTradeInfo.Single((KeyValuePair<int, VillageTradeInfo> i) => i.Key == currentVillage));
				IL_70:;
			}
			catch (Exception ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.Trade);
			}
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x00059544 File Offset: 0x00057744
		private void AddMarketForVillage(double maxDistance, KeyValuePair<int, VillageTradeInfo> villageInfo)
		{
			WorldMap world = GameEngine.Instance.World;
			villageInfo.Value.QuickTargets.Clear();
			Point villageLocation = world.getVillageLocation(villageInfo.Key);
			int num = 0;
			foreach (int num2 in this.CapitalsList)
			{
				if (world.allowExchangeTrade(num2, villageInfo.Key))
				{
					double num3 = (double)GameEngine.Instance.World.getSquareDistance(villageLocation.X, villageLocation.Y, num2);
					if (num3 <= maxDistance)
					{
						villageInfo.Value.QuickTargets.Add(num2);
						num++;
					}
				}
			}
			this.LLog(string.Format("{0} {1} {2}", world.getVillageName(villageInfo.Key), LNG.Print("added markets"), num), false);
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x0005961C File Offset: 0x0005781C
		private void AutoHireMerchants(VillageMap map)
		{
			int num = map.countWorkingMarkets() * ResearchData.numMerchantGuildsTraders[(int)GameEngine.Instance.World.userResearchData.Research_Merchant_Guilds];
			num = Math.Min(this.AutoHireMerchantsLimit, num);
			try
			{
				int num2 = map.numTraders();
				if (num2 < num)
				{
					int num3 = num - num2;
					this.LLog(string.Format("{0} {1} {2}", GameEngine.Instance.World.getVillageName(map.VillageID), LNG.Print("needs to hire merchants(s):"), num3), false);
					int spareWorkers = map.m_spareWorkers;
					if (num3 > spareWorkers)
					{
						this.LLog(string.Format("{0} {1}", spareWorkers, LNG.Print("recruits in the village")), false);
						num3 = spareWorkers;
					}
					int unitSize_Trader = GameEngine.Instance.LocalWorldData.UnitSize_Trader;
					int num4 = map.calcUnitUsages() + map.LocallyMade_Traders * unitSize_Trader;
					int num5 = GameEngine.Instance.LocalWorldData.Village_UnitCapacity - num4;
					if (num5 < num3 * unitSize_Trader)
					{
						this.LLog(string.Format("{0} {1}", num5, LNG.Print("unit space in the village")), false);
						num3 = num5 / unitSize_Trader;
					}
					int num6 = (int)GameEngine.Instance.World.getCurrentGold();
					int traderGoldCost = GameEngine.Instance.LocalWorldData.TraderGoldCost;
					if (num6 < num3 * traderGoldCost)
					{
						num3 = num6 / traderGoldCost;
						this.LLog(string.Format("{0} {1}", LNG.Print("Gold limits us to scout(s):"), num3), false);
					}
					if (num3 <= 0)
					{
						this.LLog(LNG.Print("Can't make any merchants. Please provide gold/recruits/space."), false);
					}
					else
					{
						this.LLog(string.Format("{0} {1}", LNG.Print("Making merchants(s):"), num3), false);
						map.makeTroops(-5, num3, false);
						base.RandomSleepOrExit(2000, 6000);
					}
				}
			}
			catch (InvalidOperationException)
			{
			}
			catch (Exception ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.Trade);
			}
		}

		// Token: 0x04000527 RID: 1319
		public readonly Dictionary<int, VillageTradeInfo> VillagesTradeInfo;

		// Token: 0x04000528 RID: 1320
		private readonly List<StockExchangePanel.StockExchangeInfo> _stockExchanges;

		// Token: 0x04000529 RID: 1321
		internal int SelectedVillageId = -1;

		// Token: 0x0400052A RID: 1322
		private AutoResetEvent _updatingMarket = new AutoResetEvent(false);

		// Token: 0x0400052B RID: 1323
		public static byte[] tradeTypeId = new byte[]
		{
			6,
			7,
			8,
			9,
			12,
			13,
			14,
			15,
			16,
			17,
			18,
			22,
			21,
			26,
			19,
			33,
			23,
			24,
			25,
			29,
			28,
			31,
			30,
			32
		};

		// Token: 0x0400052C RID: 1324
		public readonly List<byte> WeaponsTradeTypesIds = new List<byte>
		{
			29,
			28,
			31,
			30,
			32
		};

		// Token: 0x0400052D RID: 1325
		public int MerchantsPerTrade = 1;

		// Token: 0x0400052E RID: 1326
		private const string MerchantsPerTradeFileName = "MerchantsPerTrade.txt";

		// Token: 0x0400052F RID: 1327
		private NumericUpDown _numericUpDown_PacketsPerTrade;

		// Token: 0x04000530 RID: 1328
		public bool IgnoreCurrentTransactions;

		// Token: 0x04000531 RID: 1329
		private const string IgnoreCurrentTransactionsFileName = "IgnoreCurrentTransactions.txt";

		// Token: 0x04000532 RID: 1330
		public bool IsAutoHireMerhantsEnabled;

		// Token: 0x04000533 RID: 1331
		private const string AutoHireMerhantsFileName = "AutoHireMerhants.txt";

		// Token: 0x04000534 RID: 1332
		public int AutoHireMerchantsLimit = 50;

		// Token: 0x04000535 RID: 1333
		private const string AutoHireMerhantsLimitFileName = "AutoHireMerhantsLimit.txt";

		// Token: 0x04000536 RID: 1334
		internal int MerchantsTradeLimit = 50;

		// Token: 0x04000537 RID: 1335
		internal int MerchantsExchangeLimit = 50;

		// Token: 0x04000538 RID: 1336
		public bool StopTradeOnCardExpiry;

		// Token: 0x04000539 RID: 1337
		public bool ShowPopupOnTradeExpiry = true;

		// Token: 0x0400053A RID: 1338
		private DataGridView _dataGridView_Trade;

		// Token: 0x0400053B RID: 1339
		private DataGridView _dataGridView_TradeRoutes;

		// Token: 0x0400053C RID: 1340
		private List<TradeRoute> _tradeRoutes;

		// Token: 0x0400053D RID: 1341
		internal readonly int[] CapitalsList;

		// Token: 0x0400053E RID: 1342
		private readonly bool AreWeaponsAllowed;

		// Token: 0x0400053F RID: 1343
		private const string RoutesFileName = "Routes.txt";
	}
}
