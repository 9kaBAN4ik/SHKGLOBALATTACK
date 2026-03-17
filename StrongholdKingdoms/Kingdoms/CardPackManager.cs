using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;
using Stronghold.AuthClient;

namespace Kingdoms
{
	// Token: 0x0200010F RID: 271
	public class CardPackManager
	{
		// Token: 0x1700005E RID: 94
		// (get) Token: 0x0600089E RID: 2206 RVA: 0x0000D153 File Offset: 0x0000B353
		public Dictionary<int, CardTypes.CardOffer> ProfileCardOffers
		{
			get
			{
				if (this.mProfileCardOffers == null)
				{
					this.mProfileCardOffers = new Dictionary<int, CardTypes.CardOffer>();
				}
				return this.mProfileCardOffers;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x0600089F RID: 2207 RVA: 0x0000D16E File Offset: 0x0000B36E
		// (set) Token: 0x060008A0 RID: 2208 RVA: 0x0000D189 File Offset: 0x0000B389
		public Dictionary<int, CardTypes.UserCardPack> ProfileUserCardPacks
		{
			get
			{
				if (this.mProfileUserCardPacks == null)
				{
					this.mProfileUserCardPacks = new Dictionary<int, CardTypes.UserCardPack>();
				}
				return this.mProfileUserCardPacks;
			}
			set
			{
				this.mProfileUserCardPacks = value;
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060008A1 RID: 2209 RVA: 0x000B6560 File Offset: 0x000B4760
		public int ProfileUserTotalOwnedCardPacks
		{
			get
			{
				if (this.mProfileUserCardPacks == null)
				{
					return 0;
				}
				int num = 0;
				foreach (CardTypes.UserCardPack userCardPack in this.mProfileUserCardPacks.Values)
				{
					num += userCardPack.Count;
				}
				return num;
			}
		}

		// Token: 0x060008A2 RID: 2210 RVA: 0x000B65C8 File Offset: 0x000B47C8
		public Dictionary<int, int> ProfileUserOwnedCardPackCounts()
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			foreach (CardTypes.UserCardPack userCardPack in GameEngine.Instance.cardPackManager.ProfileUserCardPacks.Values)
			{
				if (!dictionary.ContainsKey(userCardPack.OfferID))
				{
					dictionary.Add(userCardPack.OfferID, 0);
				}
				Dictionary<int, int> dictionary2 = dictionary;
				int offerID = userCardPack.OfferID;
				int num = dictionary2[offerID];
				dictionary2[offerID] = num + 1;
			}
			return dictionary;
		}

		// Token: 0x060008A3 RID: 2211 RVA: 0x000B6660 File Offset: 0x000B4860
		public int CountOwnedCardPacksInCategory(string category)
		{
			int num = 0;
			foreach (KeyValuePair<int, CardTypes.UserCardPack> keyValuePair in this.ProfileUserCardPacks)
			{
				if (this.ProfileCardOffers.ContainsKey(keyValuePair.Key) && this.ProfileCardOffers[keyValuePair.Key].Category == category)
				{
					num += keyValuePair.Value.Count;
				}
			}
			return num;
		}

		// Token: 0x060008A4 RID: 2212 RVA: 0x000B66F4 File Offset: 0x000B48F4
		public void addCardPack(int packType, int amount)
		{
			if (this.ProfileUserCardPacks.ContainsKey(packType))
			{
				CardTypes.UserCardPack userCardPack = this.ProfileUserCardPacks[packType];
				userCardPack.Count += amount;
				return;
			}
			CardTypes.UserCardPack userCardPack2 = new CardTypes.UserCardPack();
			userCardPack2.OfferID = packType;
			userCardPack2.Count = amount;
			this.ProfileUserCardPacks[packType] = userCardPack2;
		}

		// Token: 0x060008A5 RID: 2213 RVA: 0x000B674C File Offset: 0x000B494C
		public void PurchasePack(CardTypes.CardOffer offer, CardsEndResponseUIDelegate uiCallback, Control callbackControl)
		{
			this.control = callbackControl;
			if (offer == null)
			{
				throw new ArgumentNullException("No card pack passed into purchase method");
			}
			this.offerBeingPurchased = offer;
			if (uiCallback != null)
			{
				this.m_uiCallback = uiCallback;
			}
			XmlRpcCardsProvider xmlRpcCardsProvider = XmlRpcCardsProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressCards, URLs.ProfileServerPort, URLs.ProfileCardPath);
			XmlRpcCardsRequest xmlRpcCardsRequest = new XmlRpcCardsRequest(RemoteServices.Instance.UserGuid.ToString().Replace("-", ""), offer.ID.ToString());
			xmlRpcCardsRequest.SessionGUID = RemoteServices.Instance.SessionGuid.ToString().Replace("-", "");
			if (InterfaceMgr.Instance.BuyOfferMultiple > 1)
			{
				xmlRpcCardsRequest.Multiple = new int?(InterfaceMgr.Instance.BuyOfferMultiple);
			}
			this.m_callback = new CardsEndResponseDelegate(this.offerBought);
			xmlRpcCardsProvider.buyCardOffer(xmlRpcCardsRequest, this.m_callback, this.control);
			GameEngine.Instance.World.ProfileCrowns -= offer.CrownCost * InterfaceMgr.Instance.BuyOfferMultiple;
		}

		// Token: 0x060008A6 RID: 2214 RVA: 0x000B686C File Offset: 0x000B4A6C
		private void offerBought(ICardsProvider provider, ICardsResponse response)
		{
			int? successCode = response.SuccessCode;
			int num = 1;
			if (successCode.GetValueOrDefault() == num & successCode != null)
			{
				if (GameEngine.Instance.cardPackManager.ProfileUserCardPacks.ContainsKey(this.offerBeingPurchased.ID))
				{
					if (InterfaceMgr.Instance.BuyOfferMultiple < 1)
					{
						GameEngine.Instance.cardPackManager.ProfileUserCardPacks[this.offerBeingPurchased.ID].Count++;
					}
					else
					{
						GameEngine.Instance.cardPackManager.ProfileUserCardPacks[this.offerBeingPurchased.ID].Count += InterfaceMgr.Instance.BuyOfferMultiple;
					}
				}
				else
				{
					CardTypes.UserCardPack userCardPack = new CardTypes.UserCardPack();
					userCardPack.Count = InterfaceMgr.Instance.BuyOfferMultiple;
					userCardPack.OfferID = this.offerBeingPurchased.ID;
					GameEngine.Instance.cardPackManager.ProfileUserCardPacks.Add(this.offerBeingPurchased.ID, userCardPack);
				}
			}
			else
			{
				GameEngine.Instance.World.ProfileCrowns += this.offerBeingPurchased.CrownCost * InterfaceMgr.Instance.BuyOfferMultiple;
			}
			this.m_uiCallback(response);
		}

		// Token: 0x060008A7 RID: 2215 RVA: 0x000B69B0 File Offset: 0x000B4BB0
		public CardTypes.CardOffer GetCardOffer(string category)
		{
			foreach (KeyValuePair<int, CardTypes.CardOffer> keyValuePair in this.ProfileCardOffers)
			{
				if (keyValuePair.Value.Category == category)
				{
					return keyValuePair.Value;
				}
			}
			return null;
		}

		// Token: 0x060008A8 RID: 2216 RVA: 0x000B6A20 File Offset: 0x000B4C20
		public CardTypes.CardOffer GetCardOffer(int OfferID)
		{
			foreach (KeyValuePair<int, CardTypes.CardOffer> keyValuePair in this.ProfileCardOffers)
			{
				if (keyValuePair.Value.ID == OfferID)
				{
					return keyValuePair.Value;
				}
			}
			return null;
		}

		// Token: 0x060008A9 RID: 2217 RVA: 0x000B6A88 File Offset: 0x000B4C88
		public bool TryOpenPack(int offerID, CardsEndResponseUIDelegate uiClickDelegate, Control callbackControl)
		{
			this.control = callbackControl;
			string category = GameEngine.Instance.cardPackManager.ProfileCardOffers[offerID].Category;
			this.m_uiCallback = uiClickDelegate;
			bool flag = false;
			this.openingPack = true;
			this.extendedMultiOpen = false;
			this.extendedMultiOpenLeft = 0;
			this.extendedMultiOpened = 0;
			foreach (CardTypes.UserCardPack userCardPack in GameEngine.Instance.cardPackManager.ProfileUserCardPacks.Values)
			{
				if (GameEngine.Instance.cardPackManager.ProfileCardOffers[userCardPack.OfferID].Category == category && userCardPack.Count > 0)
				{
					this.openedPackID = userCardPack.OfferID;
					XmlRpcCardsProvider xmlRpcCardsProvider = XmlRpcCardsProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressCards, URLs.ProfileServerPort, URLs.ProfileCardPath);
					XmlRpcCardsRequest xmlRpcCardsRequest = new XmlRpcCardsRequest(RemoteServices.Instance.UserGuid.ToString().Replace("-", ""), (GameEngine.Instance.World.getRank() + 1).ToString(), userCardPack.OfferID.ToString(), RemoteServices.Instance.ProfileWorldID.ToString());
					xmlRpcCardsRequest.SessionGUID = RemoteServices.Instance.SessionGuid.ToString().Replace("-", "");
					xmlRpcCardsRequest.Multiple = new int?(InterfaceMgr.Instance.OpenPackMultiple);
					UniversalDebugLog.Log("opening " + xmlRpcCardsRequest.Multiple.ToString());
					if (InterfaceMgr.Instance.OpenPackMultiple > 0 && userCardPack.Count < InterfaceMgr.Instance.OpenPackMultiple)
					{
						this.extendedMultiOpen = true;
						this.extendedMultiOpenLeft = InterfaceMgr.Instance.OpenPackMultiple - userCardPack.Count;
						this.extendedPackClicked = this.GetCardOffer(offerID);
						xmlRpcCardsRequest.Multiple = new int?(userCardPack.Count);
						this.extendedMultiOpened = userCardPack.Count;
					}
					xmlRpcCardsProvider.openCardPack(xmlRpcCardsRequest, new CardsEndResponseDelegate(this.onPackOpened), this.control);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				this.openingPack = false;
			}
			return flag;
		}

		// Token: 0x060008AA RID: 2218 RVA: 0x000B6CFC File Offset: 0x000B4EFC
		public bool doExtendedMultiOpen(string searchCat)
		{
			foreach (CardTypes.UserCardPack userCardPack in GameEngine.Instance.cardPackManager.ProfileUserCardPacks.Values)
			{
				if (GameEngine.Instance.cardPackManager.ProfileCardOffers[userCardPack.OfferID].Category == searchCat && userCardPack.Count > 0)
				{
					this.openedPackID = userCardPack.OfferID;
					XmlRpcCardsProvider xmlRpcCardsProvider = XmlRpcCardsProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressCards, URLs.ProfileServerPort, URLs.ProfileCardPath);
					XmlRpcCardsRequest xmlRpcCardsRequest = new XmlRpcCardsRequest(RemoteServices.Instance.UserGuid.ToString().Replace("-", ""), (GameEngine.Instance.World.getRank() + 1).ToString(), userCardPack.OfferID.ToString(), RemoteServices.Instance.ProfileWorldID.ToString());
					xmlRpcCardsRequest.SessionGUID = RemoteServices.Instance.SessionGuid.ToString().Replace("-", "");
					xmlRpcCardsRequest.Multiple = new int?(this.extendedMultiOpenLeft);
					if (userCardPack.Count < this.extendedMultiOpenLeft)
					{
						this.extendedMultiOpen = true;
						this.extendedMultiOpenLeft -= userCardPack.Count;
						xmlRpcCardsRequest.Multiple = new int?(userCardPack.Count);
						this.extendedMultiOpened = userCardPack.Count;
					}
					else
					{
						this.extendedMultiOpened = this.extendedMultiOpenLeft;
						this.extendedMultiOpen = false;
						this.extendedPackClicked = null;
					}
					xmlRpcCardsProvider.openCardPack(xmlRpcCardsRequest, new CardsEndResponseDelegate(this.onPackOpened), this.control);
					return true;
				}
			}
			return false;
		}

		// Token: 0x060008AB RID: 2219 RVA: 0x000B6EEC File Offset: 0x000B50EC
		private void onPackOpened(ICardsProvider provider, ICardsResponse response)
		{
			if (response.SuccessCode.Value == 1)
			{
				foreach (CardTypes.UserCardPack userCardPack in GameEngine.Instance.cardPackManager.ProfileUserCardPacks.Values)
				{
					if (userCardPack.OfferID == this.openedPackID)
					{
						if (this.extendedMultiOpened > 0)
						{
							userCardPack.Count -= this.extendedMultiOpened;
						}
						else if (InterfaceMgr.Instance.OpenPackMultiple < 1)
						{
							userCardPack.Count--;
						}
						else
						{
							userCardPack.Count -= InterfaceMgr.Instance.OpenPackMultiple;
						}
						if (!this.extendedMultiOpen)
						{
							break;
						}
						if (this.extendedMultiOpenLeft <= 0)
						{
							break;
						}
						string category = this.extendedPackClicked.Category;
						if (!this.doExtendedMultiOpen(category))
						{
							break;
						}
						Dictionary<int, CardTypes.CardDefinition> cardsFromServerResponse = this.getCardsFromServerResponse(response.Strings);
						using (Dictionary<int, CardTypes.CardDefinition>.Enumerator enumerator2 = cardsFromServerResponse.GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								KeyValuePair<int, CardTypes.CardDefinition> keyValuePair = enumerator2.Current;
								GameEngine.Instance.cardsManager.ProfileCards.Add(keyValuePair.Key, keyValuePair.Value);
							}
							return;
						}
					}
				}
			}
			this.openingPack = false;
			this.m_uiCallback(response);
		}

		// Token: 0x060008AC RID: 2220 RVA: 0x000B7088 File Offset: 0x000B5288
		public Dictionary<int, CardTypes.CardDefinition> getCardsFromServerResponse(string responseString)
		{
			Dictionary<int, CardTypes.CardDefinition> dictionary = new Dictionary<int, CardTypes.CardDefinition>();
			string[] array = responseString.Split(";".ToCharArray());
			string[] array2 = array;
			foreach (string text in array2)
			{
				string[] array4 = text.Split(",".ToCharArray());
				if (array4.Length == 2)
				{
					int key = Convert.ToInt32(array4[0].Trim());
					string cardString = array4[1].Trim();
					CardTypes.CardDefinition cardDefinitionFromString = CardTypes.getCardDefinitionFromString(cardString);
					dictionary.Add(key, cardDefinitionFromString);
				}
			}
			return dictionary;
		}

		// Token: 0x060008AD RID: 2221 RVA: 0x000B7114 File Offset: 0x000B5314
		public BaseImage getCardPackBaseImage(string category)
		{
			string key;
			if (category != null)
			{
				uint num = PrivateImplementationDetails.ComputeStringHash(category);
				if (num > 1840469762U)
				{
					if (num <= 2384087216U)
					{
						if (num <= 2020401625U)
						{
							if (num != 1999303592U)
							{
								if (num != 2020401625U)
								{
									goto IL_36A;
								}
								if (!(category == "CASTLE"))
								{
									goto IL_36A;
								}
								key = "card_pack_castle_standard_normal";
								goto IL_3C8;
							}
							else
							{
								if (!(category == "SUPERDEFENCE"))
								{
									goto IL_36A;
								}
								goto IL_37A;
							}
						}
						else if (num != 2135598467U)
						{
							if (num != 2291264053U)
							{
								if (num != 2384087216U)
								{
									goto IL_36A;
								}
								if (!(category == "ULTIMATEINDUSTRY"))
								{
									goto IL_36A;
								}
								key = "card_pack_Industry_gold_normal";
								goto IL_3C8;
							}
							else
							{
								if (!(category == "PLATINUM"))
								{
									goto IL_36A;
								}
								key = "card_pack_army_gold_normal";
								goto IL_3C8;
							}
						}
						else if (!(category == "DEFENCE"))
						{
							goto IL_36A;
						}
					}
					else if (num <= 3336250060U)
					{
						if (num != 2398591754U)
						{
							if (num != 2669819251U)
							{
								if (num != 3336250060U)
								{
									goto IL_36A;
								}
								if (!(category == "RESEARCH"))
								{
									goto IL_36A;
								}
								key = "card_pack_research_silver_normal";
								goto IL_3C8;
							}
							else if (!(category == "DEFENSE"))
							{
								goto IL_36A;
							}
						}
						else
						{
							if (!(category == "SUPERINDUSTRY"))
							{
								goto IL_36A;
							}
							key = "card_pack_Industry_silver_normal";
							goto IL_3C8;
						}
					}
					else if (num != 3400942179U)
					{
						if (num != 3529609855U)
						{
							if (num != 3631079739U)
							{
								goto IL_36A;
							}
							if (!(category == "SUPERRANDOM"))
							{
								goto IL_36A;
							}
							key = "card_pack_random_silver_normal";
							goto IL_3C8;
						}
						else
						{
							if (!(category == "INDUSTRY"))
							{
								goto IL_36A;
							}
							key = "card_pack_Industry_standard_normal";
							goto IL_3C8;
						}
					}
					else
					{
						if (!(category == "ULTIMATEARMY"))
						{
							goto IL_36A;
						}
						key = "card_pack_army_gold_normal";
						goto IL_3C8;
					}
					key = "card_pack_defence_standard_normal";
					goto IL_3C8;
				}
				if (num > 453818725U)
				{
					if (num <= 1465082808U)
					{
						if (num != 1025969697U)
						{
							if (num != 1306248978U)
							{
								if (num != 1465082808U)
								{
									goto IL_36A;
								}
								if (!(category == "SUPERDEFENSE"))
								{
									goto IL_36A;
								}
								goto IL_37A;
							}
							else if (!(category == "ULTIMATEDEFENSE"))
							{
								goto IL_36A;
							}
						}
						else
						{
							if (!(category == "ULTIMATERANDOM"))
							{
								goto IL_36A;
							}
							key = "card_pack_random_gold_normal";
							goto IL_3C8;
						}
					}
					else if (num != 1614633826U)
					{
						if (num != 1752986212U)
						{
							if (num != 1840469762U)
							{
								goto IL_36A;
							}
							if (!(category == "ULTIMATEDEFENCE"))
							{
								goto IL_36A;
							}
						}
						else
						{
							if (!(category == "ARMY"))
							{
								goto IL_36A;
							}
							key = "card_pack_army_standard_normal";
							goto IL_3C8;
						}
					}
					else
					{
						if (!(category == "RANDOM"))
						{
							goto IL_36A;
						}
						key = "card_pack_random_standard_normal";
						goto IL_3C8;
					}
					key = "card_pack_defence_gold_normal";
					goto IL_3C8;
				}
				if (num <= 253004944U)
				{
					if (num != 207630535U)
					{
						if (num != 253004944U)
						{
							goto IL_36A;
						}
						if (!(category == "SUPERFARMING"))
						{
							goto IL_36A;
						}
						key = "card_pack_food_silver_normal";
						goto IL_3C8;
					}
					else
					{
						if (!(category == "FARMING"))
						{
							goto IL_36A;
						}
						key = "card_pack_food_standard_normal";
						goto IL_3C8;
					}
				}
				else if (num != 364403686U)
				{
					if (num != 387929467U)
					{
						if (num != 453818725U)
						{
							goto IL_36A;
						}
						if (!(category == "SUPERARMY"))
						{
							goto IL_36A;
						}
						key = "card_pack_army_silver_normal";
						goto IL_3C8;
					}
					else
					{
						if (!(category == "EXCLUSIVE"))
						{
							goto IL_36A;
						}
						key = "card_pack_exclusive_silver_normal";
						goto IL_3C8;
					}
				}
				else
				{
					if (!(category == "ULTIMATEFARMING"))
					{
						goto IL_36A;
					}
					key = "card_pack_food_gold_normal";
					goto IL_3C8;
				}
				IL_37A:
				key = "card_pack_defence_silver_normal";
				goto IL_3C8;
			}
			IL_36A:
			key = "card_pack_Industry_standard_normal";
			IL_3C8:
			BaseImage result;
			try
			{
				result = GFXLibrary.CardPackImages[key];
			}
			catch (Exception)
			{
				result = GFXLibrary.CardPackImages["card_pack_open_Industry-Pack"];
			}
			return result;
		}

		// Token: 0x060008AE RID: 2222 RVA: 0x000B751C File Offset: 0x000B571C
		public BaseImage getCardPackOverImage(string category)
		{
			string key;
			if (category != null)
			{
				uint num = PrivateImplementationDetails.ComputeStringHash(category);
				if (num > 1840469762U)
				{
					if (num <= 2384087216U)
					{
						if (num <= 2020401625U)
						{
							if (num != 1999303592U)
							{
								if (num != 2020401625U)
								{
									goto IL_36A;
								}
								if (!(category == "CASTLE"))
								{
									goto IL_36A;
								}
								key = "card_pack_castle_standard_over";
								goto IL_3C8;
							}
							else
							{
								if (!(category == "SUPERDEFENCE"))
								{
									goto IL_36A;
								}
								goto IL_37A;
							}
						}
						else if (num != 2135598467U)
						{
							if (num != 2291264053U)
							{
								if (num != 2384087216U)
								{
									goto IL_36A;
								}
								if (!(category == "ULTIMATEINDUSTRY"))
								{
									goto IL_36A;
								}
								key = "card_pack_Industry_gold_over";
								goto IL_3C8;
							}
							else
							{
								if (!(category == "PLATINUM"))
								{
									goto IL_36A;
								}
								key = "card_pack_army_gold_over";
								goto IL_3C8;
							}
						}
						else if (!(category == "DEFENCE"))
						{
							goto IL_36A;
						}
					}
					else if (num <= 3336250060U)
					{
						if (num != 2398591754U)
						{
							if (num != 2669819251U)
							{
								if (num != 3336250060U)
								{
									goto IL_36A;
								}
								if (!(category == "RESEARCH"))
								{
									goto IL_36A;
								}
								key = "card_pack_research_silver_over";
								goto IL_3C8;
							}
							else if (!(category == "DEFENSE"))
							{
								goto IL_36A;
							}
						}
						else
						{
							if (!(category == "SUPERINDUSTRY"))
							{
								goto IL_36A;
							}
							key = "card_pack_Industry_silver_over";
							goto IL_3C8;
						}
					}
					else if (num != 3400942179U)
					{
						if (num != 3529609855U)
						{
							if (num != 3631079739U)
							{
								goto IL_36A;
							}
							if (!(category == "SUPERRANDOM"))
							{
								goto IL_36A;
							}
							key = "card_pack_random_silver_over";
							goto IL_3C8;
						}
						else
						{
							if (!(category == "INDUSTRY"))
							{
								goto IL_36A;
							}
							key = "card_pack_Industry_standard_over";
							goto IL_3C8;
						}
					}
					else
					{
						if (!(category == "ULTIMATEARMY"))
						{
							goto IL_36A;
						}
						key = "card_pack_army_gold_over";
						goto IL_3C8;
					}
					key = "card_pack_defence_standard_over";
					goto IL_3C8;
				}
				if (num > 453818725U)
				{
					if (num <= 1465082808U)
					{
						if (num != 1025969697U)
						{
							if (num != 1306248978U)
							{
								if (num != 1465082808U)
								{
									goto IL_36A;
								}
								if (!(category == "SUPERDEFENSE"))
								{
									goto IL_36A;
								}
								goto IL_37A;
							}
							else if (!(category == "ULTIMATEDEFENSE"))
							{
								goto IL_36A;
							}
						}
						else
						{
							if (!(category == "ULTIMATERANDOM"))
							{
								goto IL_36A;
							}
							key = "card_pack_random_gold_over";
							goto IL_3C8;
						}
					}
					else if (num != 1614633826U)
					{
						if (num != 1752986212U)
						{
							if (num != 1840469762U)
							{
								goto IL_36A;
							}
							if (!(category == "ULTIMATEDEFENCE"))
							{
								goto IL_36A;
							}
						}
						else
						{
							if (!(category == "ARMY"))
							{
								goto IL_36A;
							}
							key = "card_pack_army_standard_over";
							goto IL_3C8;
						}
					}
					else
					{
						if (!(category == "RANDOM"))
						{
							goto IL_36A;
						}
						key = "card_pack_random_standard_over";
						goto IL_3C8;
					}
					key = "card_pack_defence_gold_over";
					goto IL_3C8;
				}
				if (num <= 253004944U)
				{
					if (num != 207630535U)
					{
						if (num != 253004944U)
						{
							goto IL_36A;
						}
						if (!(category == "SUPERFARMING"))
						{
							goto IL_36A;
						}
						key = "card_pack_food_silver_over";
						goto IL_3C8;
					}
					else
					{
						if (!(category == "FARMING"))
						{
							goto IL_36A;
						}
						key = "card_pack_food_standard_over";
						goto IL_3C8;
					}
				}
				else if (num != 364403686U)
				{
					if (num != 387929467U)
					{
						if (num != 453818725U)
						{
							goto IL_36A;
						}
						if (!(category == "SUPERARMY"))
						{
							goto IL_36A;
						}
						key = "card_pack_army_silver_over";
						goto IL_3C8;
					}
					else
					{
						if (!(category == "EXCLUSIVE"))
						{
							goto IL_36A;
						}
						key = "card_pack_exclusive_silver_over";
						goto IL_3C8;
					}
				}
				else
				{
					if (!(category == "ULTIMATEFARMING"))
					{
						goto IL_36A;
					}
					key = "card_pack_food_gold_over";
					goto IL_3C8;
				}
				IL_37A:
				key = "card_pack_defence_silver_over";
				goto IL_3C8;
			}
			IL_36A:
			key = "card_pack_Industry_standard_over";
			IL_3C8:
			BaseImage result;
			try
			{
				result = GFXLibrary.CardPackImages[key];
			}
			catch (Exception)
			{
				result = GFXLibrary.CardPackImages["card_pack_Industry_standard_over"];
			}
			return result;
		}

		// Token: 0x060008AF RID: 2223 RVA: 0x000B7924 File Offset: 0x000B5B24
		public int getCardPackTooltipID(string category)
		{
			int result = 0;
			if (category != null)
			{
				uint num = PrivateImplementationDetails.ComputeStringHash(category);
				if (num > 1840469762U)
				{
					if (num <= 2384087216U)
					{
						if (num <= 2020401625U)
						{
							if (num != 1999303592U)
							{
								if (num != 2020401625U)
								{
									return result;
								}
								if (!(category == "CASTLE"))
								{
									return result;
								}
								return 10302;
							}
							else
							{
								if (!(category == "SUPERDEFENCE"))
								{
									return result;
								}
								goto IL_37D;
							}
						}
						else if (num != 2135598467U)
						{
							if (num != 2291264053U)
							{
								if (num != 2384087216U)
								{
									return result;
								}
								if (!(category == "ULTIMATEINDUSTRY"))
								{
									return result;
								}
								return 10318;
							}
							else
							{
								if (!(category == "PLATINUM"))
								{
									return result;
								}
								return 10321;
							}
						}
						else if (!(category == "DEFENCE"))
						{
							return result;
						}
					}
					else if (num <= 3336250060U)
					{
						if (num != 2398591754U)
						{
							if (num != 2669819251U)
							{
								if (num != 3336250060U)
								{
									return result;
								}
								if (!(category == "RESEARCH"))
								{
									return result;
								}
								return 10307;
							}
							else if (!(category == "DEFENSE"))
							{
								return result;
							}
						}
						else
						{
							if (!(category == "SUPERINDUSTRY"))
							{
								return result;
							}
							return 10313;
						}
					}
					else if (num != 3400942179U)
					{
						if (num != 3529609855U)
						{
							if (num != 3631079739U)
							{
								return result;
							}
							if (!(category == "SUPERRANDOM"))
							{
								return result;
							}
							return 10312;
						}
						else
						{
							if (!(category == "INDUSTRY"))
							{
								return result;
							}
							return 10306;
						}
					}
					else
					{
						if (!(category == "ULTIMATEARMY"))
						{
							return result;
						}
						return 10316;
					}
					return 10303;
				}
				if (num > 453818725U)
				{
					if (num <= 1465082808U)
					{
						if (num != 1025969697U)
						{
							if (num != 1306248978U)
							{
								if (num != 1465082808U)
								{
									return result;
								}
								if (!(category == "SUPERDEFENSE"))
								{
									return result;
								}
								goto IL_37D;
							}
							else if (!(category == "ULTIMATEDEFENSE"))
							{
								return result;
							}
						}
						else
						{
							if (!(category == "ULTIMATERANDOM"))
							{
								return result;
							}
							return 10317;
						}
					}
					else if (num != 1614633826U)
					{
						if (num != 1752986212U)
						{
							if (num != 1840469762U)
							{
								return result;
							}
							if (!(category == "ULTIMATEDEFENCE"))
							{
								return result;
							}
						}
						else
						{
							if (!(category == "ARMY"))
							{
								return result;
							}
							return 10304;
						}
					}
					else
					{
						if (!(category == "RANDOM"))
						{
							return result;
						}
						return 10305;
					}
					return 10315;
				}
				if (num <= 253004944U)
				{
					if (num != 207630535U)
					{
						if (num != 253004944U)
						{
							return result;
						}
						if (!(category == "SUPERFARMING"))
						{
							return result;
						}
						return 10309;
					}
					else
					{
						if (!(category == "FARMING"))
						{
							return result;
						}
						return 10301;
					}
				}
				else if (num != 364403686U)
				{
					if (num != 387929467U)
					{
						if (num != 453818725U)
						{
							return result;
						}
						if (!(category == "SUPERARMY"))
						{
							return result;
						}
						return 10311;
					}
					else
					{
						if (!(category == "EXCLUSIVE"))
						{
							return result;
						}
						return 10308;
					}
				}
				else
				{
					if (!(category == "ULTIMATEFARMING"))
					{
						return result;
					}
					return 10314;
				}
				IL_37D:
				result = 10310;
			}
			return result;
		}

		// Token: 0x060008B0 RID: 2224 RVA: 0x000B7D00 File Offset: 0x000B5F00
		public string getCardPackLocalizedStringID(string category)
		{
			if (category != null)
			{
				uint num = PrivateImplementationDetails.ComputeStringHash(category);
				if (num > 1840469762U)
				{
					if (num <= 2384087216U)
					{
						if (num <= 2020401625U)
						{
							if (num != 1999303592U)
							{
								if (num != 2020401625U)
								{
									goto IL_348;
								}
								if (!(category == "CASTLE"))
								{
									goto IL_348;
								}
								return "CARD_OFFERS_Castle_Pack";
							}
							else
							{
								if (!(category == "SUPERDEFENCE"))
								{
									goto IL_348;
								}
								goto IL_354;
							}
						}
						else if (num != 2135598467U)
						{
							if (num != 2291264053U)
							{
								if (num != 2384087216U)
								{
									goto IL_348;
								}
								if (!(category == "ULTIMATEINDUSTRY"))
								{
									goto IL_348;
								}
								return "CARD_OFFERS_Ultimate_Industry_Pack";
							}
							else
							{
								if (!(category == "PLATINUM"))
								{
									goto IL_348;
								}
								return "CARD_OFFERS_Platinum_Pack";
							}
						}
						else if (!(category == "DEFENCE"))
						{
							goto IL_348;
						}
					}
					else if (num <= 3336250060U)
					{
						if (num != 2398591754U)
						{
							if (num != 2669819251U)
							{
								if (num != 3336250060U)
								{
									goto IL_348;
								}
								if (!(category == "RESEARCH"))
								{
									goto IL_348;
								}
								return "CARD_OFFERS_Research_Pack";
							}
							else if (!(category == "DEFENSE"))
							{
								goto IL_348;
							}
						}
						else
						{
							if (!(category == "SUPERINDUSTRY"))
							{
								goto IL_348;
							}
							return "CARD_OFFERS_Super_Industry_Pack";
						}
					}
					else if (num != 3400942179U)
					{
						if (num != 3529609855U)
						{
							if (num != 3631079739U)
							{
								goto IL_348;
							}
							if (!(category == "SUPERRANDOM"))
							{
								goto IL_348;
							}
							return "CARD_OFFERS_Super_Random_Pack";
						}
						else
						{
							if (!(category == "INDUSTRY"))
							{
								goto IL_348;
							}
							return "CARD_OFFERS_Industry_Pack";
						}
					}
					else
					{
						if (!(category == "ULTIMATEARMY"))
						{
							goto IL_348;
						}
						return "CARD_OFFERS_Ultimate_Army_Pack";
					}
					return "CARD_OFFERS_Defense_Pack";
				}
				if (num > 453818725U)
				{
					if (num <= 1465082808U)
					{
						if (num != 1025969697U)
						{
							if (num != 1306248978U)
							{
								if (num != 1465082808U)
								{
									goto IL_348;
								}
								if (!(category == "SUPERDEFENSE"))
								{
									goto IL_348;
								}
								goto IL_354;
							}
							else if (!(category == "ULTIMATEDEFENSE"))
							{
								goto IL_348;
							}
						}
						else
						{
							if (!(category == "ULTIMATERANDOM"))
							{
								goto IL_348;
							}
							return "CARD_OFFERS_Ultimate_Random_Pack";
						}
					}
					else if (num != 1614633826U)
					{
						if (num != 1752986212U)
						{
							if (num != 1840469762U)
							{
								goto IL_348;
							}
							if (!(category == "ULTIMATEDEFENCE"))
							{
								goto IL_348;
							}
						}
						else
						{
							if (!(category == "ARMY"))
							{
								goto IL_348;
							}
							return "CARD_OFFERS_Army_Pack";
						}
					}
					else
					{
						if (!(category == "RANDOM"))
						{
							goto IL_348;
						}
						return "CARD_OFFERS_Random_Pack";
					}
					return "CARD_OFFERS_Ultimate_Defense_Pack";
				}
				if (num <= 253004944U)
				{
					if (num != 207630535U)
					{
						if (num != 253004944U)
						{
							goto IL_348;
						}
						if (!(category == "SUPERFARMING"))
						{
							goto IL_348;
						}
						return "CARD_OFFERS_Super_Food_Pack";
					}
					else
					{
						if (!(category == "FARMING"))
						{
							goto IL_348;
						}
						return "CARD_OFFERS_Food_Pack";
					}
				}
				else if (num != 364403686U)
				{
					if (num != 387929467U)
					{
						if (num != 453818725U)
						{
							goto IL_348;
						}
						if (!(category == "SUPERARMY"))
						{
							goto IL_348;
						}
						return "CARD_OFFERS_Super_Army_Pack";
					}
					else
					{
						if (!(category == "EXCLUSIVE"))
						{
							goto IL_348;
						}
						return "CARD_OFFERS_Exclusive_Pack";
					}
				}
				else
				{
					if (!(category == "ULTIMATEFARMING"))
					{
						goto IL_348;
					}
					return "CARD_OFFERS_Ultimate_Food_Pack";
				}
				IL_354:
				return "CARD_OFFERS_Super_Defense_Pack";
			}
			IL_348:
			return "CARD_OFFERS_Industry_Pack";
		}

		// Token: 0x060008B1 RID: 2225 RVA: 0x000B809C File Offset: 0x000B629C
		public CardTypes.CardOffer getBuyablePackInCategory(string offerID)
		{
			CardTypes.CardOffer cardOffer = null;
			foreach (CardTypes.CardOffer cardOffer2 in GameEngine.Instance.cardPackManager.ProfileCardOffers.Values)
			{
				if (cardOffer2.Category == offerID)
				{
					if (cardOffer == null)
					{
						cardOffer = cardOffer2;
					}
					else if (cardOffer2.Buyable == 1)
					{
						cardOffer = cardOffer2;
					}
				}
			}
			return cardOffer;
		}

		// Token: 0x04000C31 RID: 3121
		private Dictionary<int, CardTypes.UserCardPack> mProfileUserCardPacks;

		// Token: 0x04000C32 RID: 3122
		private Dictionary<int, CardTypes.CardOffer> mProfileCardOffers;

		// Token: 0x04000C33 RID: 3123
		private CardTypes.CardOffer offerBeingPurchased;

		// Token: 0x04000C34 RID: 3124
		private CardsEndResponseUIDelegate m_uiCallback;

		// Token: 0x04000C35 RID: 3125
		private CardsEndResponseDelegate m_callback;

		// Token: 0x04000C36 RID: 3126
		private bool extendedMultiOpen;

		// Token: 0x04000C37 RID: 3127
		private int extendedMultiOpenLeft;

		// Token: 0x04000C38 RID: 3128
		private int extendedMultiOpened;

		// Token: 0x04000C39 RID: 3129
		private CardTypes.CardOffer extendedPackClicked;

		// Token: 0x04000C3A RID: 3130
		private int openedPackID = -1;

		// Token: 0x04000C3B RID: 3131
		public bool openingPack;

		// Token: 0x04000C3C RID: 3132
		private Control control;
	}
}
