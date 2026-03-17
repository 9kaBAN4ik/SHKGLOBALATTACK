using System;
using System.Collections.Generic;
using System.Threading;
using CommonTypes;
using Stronghold.AuthClient;
using Upgrade;

namespace Kingdoms
{
	// Token: 0x02000111 RID: 273
	public class CardsManager
	{
		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060008B7 RID: 2231 RVA: 0x0000D1A9 File Offset: 0x0000B3A9
		public Dictionary<int, CardTypes.CardDefinition> ProfileCards
		{
			get
			{
				if (this.mProfileCards == null)
				{
					this.mProfileCards = new Dictionary<int, CardTypes.CardDefinition>();
				}
				return this.mProfileCards;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060008B8 RID: 2232 RVA: 0x0000D1C4 File Offset: 0x0000B3C4
		public List<int> ProfileCardsSearch
		{
			get
			{
				if (this.mProfileCardsSearch == null)
				{
					this.mProfileCardsSearch = new List<int>();
				}
				return this.mProfileCardsSearch;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060008B9 RID: 2233 RVA: 0x0000D1DF File Offset: 0x0000B3DF
		public List<int> ProfileCardsSet
		{
			get
			{
				if (this.mProfileCardsSet == null)
				{
					this.mProfileCardsSet = new List<int>();
				}
				return this.mProfileCardsSet;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060008BA RID: 2234 RVA: 0x0000D1FA File Offset: 0x0000B3FA
		public List<int> CatalogCardsSearch
		{
			get
			{
				if (this.mCatalogCardsSearch == null)
				{
					this.mCatalogCardsSearch = new List<int>();
				}
				return this.mCatalogCardsSearch;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060008BB RID: 2235 RVA: 0x0000D215 File Offset: 0x0000B415
		public List<int> ShoppingCartCards
		{
			get
			{
				if (this.mShoppingCartCards == null)
				{
					this.mShoppingCartCards = new List<int>();
				}
				return this.mShoppingCartCards;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060008BC RID: 2236 RVA: 0x000B8248 File Offset: 0x000B6448
		// (set) Token: 0x060008BD RID: 2237 RVA: 0x000B8368 File Offset: 0x000B6568
		public CardData UserCardData
		{
			get
			{
				if (this.m_userCardData == null)
				{
					return new CardData();
				}
				DateTime currentServerTime = VillageMap.getCurrentServerTime();
				for (int i = 0; i < this.m_userCardData.cards.Length; i++)
				{
					if (this.m_userCardData.cards[i] != 0 && currentServerTime > this.m_userCardData.cardsExpiry[i])
					{
						this.m_userCardData.cards[i] = 0;
					}
				}
				if (this.m_userCardData.premiumCard != 0)
				{
					if (this.m_userCardData.premiumCard == 4113 && currentServerTime > this.m_userCardData.premiumCardExpiry)
					{
						this.m_userCardData.premiumCard = 0;
						if (!Program.mySettings.AdvertShown)
						{
							this.m_userCardData.premiumAdvertNeeded = true;
						}
					}
					else if (currentServerTime > this.m_userCardData.premiumCardExpiry)
					{
						this.m_userCardData.premiumCard = 0;
					}
				}
				if (this.m_userCardData.premiumAdvertNeeded)
				{
					this.m_userCardData.premiumAdvertNeeded = false;
					Program.mySettings.AdvertShown = true;
					InterfaceMgr.Instance.openLogoutWindow(true, true);
				}
				return this.m_userCardData;
			}
			set
			{
				this.m_userCardData = value;
				if (this.m_userCardData != null)
				{
					ControlForm controlForm = DX.ControlForm;
					if (controlForm != null)
					{
						controlForm.CardExpiryChecker.CheckCardsExpiration(this.m_userCardData);
					}
					InterfaceMgr.Instance.setCardData(this.m_userCardData);
				}
				this.UserCardDataChanged = true;
			}
		}

		// Token: 0x060008BE RID: 2238 RVA: 0x0000D230 File Offset: 0x0000B430
		public bool SelectedCardExists()
		{
			return this.ProfileCards != null && GameEngine.Instance.cardsManager.ProfileCards.ContainsKey(GameEngine.Instance.cardsManager.SelectedUserCardID);
		}

		// Token: 0x060008BF RID: 2239 RVA: 0x0000D25F File Offset: 0x0000B45F
		public CardTypes.CardDefinition SelectedCardDefinition()
		{
			return GameEngine.Instance.cardsManager.ProfileCards[this.SelectedUserCardID];
		}

		// Token: 0x060008C0 RID: 2240 RVA: 0x000B83B8 File Offset: 0x000B65B8
		public void addRecentCard(int newCard)
		{
			if (this.recentCards.Contains(newCard))
			{
				this.recentCards.Remove(newCard);
			}
			if (this.recentCards.Count == 8)
			{
				this.recentCards.RemoveAt(7);
			}
			this.recentCards.Insert(0, newCard);
		}

		// Token: 0x060008C1 RID: 2241 RVA: 0x000B8408 File Offset: 0x000B6608
		public void addRecentCardsFromServer(int[] cards)
		{
			int num = 0;
			this.recentCards.Clear();
			if (cards == null)
			{
				return;
			}
			foreach (int card in cards)
			{
				num++;
				this.recentCards.Add(CardTypes.getCardType(card));
				if (num == 8)
				{
					break;
				}
			}
		}

		// Token: 0x060008C2 RID: 2242 RVA: 0x0000D27B File Offset: 0x0000B47B
		public void onLogout()
		{
			this.mProfileCardsSet = new List<int>();
		}

		// Token: 0x060008C3 RID: 2243 RVA: 0x000B8454 File Offset: 0x000B6654
		public bool isCardInPlay(CardTypes.CardDefinition def)
		{
			if (this.UserCardData != null)
			{
				int[] cards = this.UserCardData.cards;
				foreach (int card in cards)
				{
					int cardType = CardTypes.getCardType(card);
					if (cardType == def.id)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x060008C4 RID: 2244 RVA: 0x000B84A0 File Offset: 0x000B66A0
		public List<CardTypes.CardDefinition> getCardsInPlay()
		{
			List<CardTypes.CardDefinition> list = new List<CardTypes.CardDefinition>();
			if (this.UserCardData != null)
			{
				int[] cards = this.UserCardData.cards;
				foreach (int cardType in cards)
				{
					list.Add(CardTypes.getCardDefinition(cardType));
				}
			}
			return list;
		}

		// Token: 0x060008C5 RID: 2245 RVA: 0x000B84EC File Offset: 0x000B66EC
		public void addProfileCard(int id, string type)
		{
			if (!this.ProfileCards.ContainsKey(id))
			{
				try
				{
					this.ProfileCards.Add(id, CardTypes.getCardDefinitionFromString(type.Trim()));
				}
				catch (Exception ex)
				{
					string message = ex.Message;
					string str = " ";
					Exception innerException = ex.InnerException;
					UniversalDebugLog.Log(message + str + ((innerException != null) ? innerException.ToString() : null));
					throw new Exception("Tried to add a card and couldn't: UserTradingCardID= " + id.ToString() + " type= " + type);
				}
				return;
			}
			throw new Exception("Tried to add a card that was already there: UserTradingCardID=" + id.ToString());
		}

		// Token: 0x060008C6 RID: 2246 RVA: 0x000B858C File Offset: 0x000B678C
		public void removeProfileCard(int id)
		{
			if (this.ProfileCards.ContainsKey(id))
			{
				this.ProfileCards.Remove(id);
				if (this.ProfileCardsSearch.Contains(id))
				{
					this.ProfileCardsSearch.Remove(id);
				}
				if (this.ProfileCardsSet.Contains(id))
				{
					this.ProfileCardsSet.Remove(id);
				}
				return;
			}
			throw new Exception("Tried to remove a card that wasn't there: UserTradingCardID=" + id.ToString());
		}

		// Token: 0x060008C7 RID: 2247 RVA: 0x000B8604 File Offset: 0x000B6804
		public void searchProfileCards(CardTypes.CardDefinition filter, string sort, string namefilter)
		{
			this.ProfileCardsSearch.Clear();
			List<int> list = new List<int>();
			filter.cardFilter = 0;
			foreach (int num in this.ProfileCards.Keys)
			{
				if (this.filterCard(filter, this.ProfileCards[num]))
				{
					list.Add(num);
				}
			}
			foreach (int num2 in list)
			{
				if (CardTypes.isCardInNewCategory(this.ProfileCards[num2].id, filter.newCardCategoryFilter) && (namefilter.Length == 0 || CardTypes.containsName(this.ProfileCards[num2].id, namefilter)))
				{
					this.ProfileCardsSearch.Add(num2);
				}
			}
			if (this.ProfileCardsSearch.Count > 0)
			{
				if (sort == "rarity")
				{
					this.ProfileCardsSearch.Sort(delegate(int first, int next)
					{
						int cardRarity = CardTypes.getCardDefinition(this.ProfileCards[first].id).cardRarity;
						int cardRarity2 = CardTypes.getCardDefinition(this.ProfileCards[next].id).cardRarity;
						if (cardRarity == cardRarity2)
						{
							return this.ProfileCards[first].id.CompareTo(this.ProfileCards[next].id);
						}
						return cardRarity2.CompareTo(cardRarity);
					});
				}
				else if (sort == "meta")
				{
					this.ProfileCardsSearch.Sort(delegate(int first, int next)
					{
						int metaScore = CardTypes.getCardDefinition(this.ProfileCards[first].id).metaScore;
						int metaScore2 = CardTypes.getCardDefinition(this.ProfileCards[next].id).metaScore;
						if (metaScore == metaScore2)
						{
							return this.ProfileCards[first].id.CompareTo(this.ProfileCards[next].id);
						}
						return metaScore2.CompareTo(metaScore);
					});
				}
				else
				{
					this.ProfileCardsSearch.Sort(delegate(int first, int next)
					{
						string descriptionFromCard = CardTypes.getDescriptionFromCard(this.ProfileCards[first].id);
						string descriptionFromCard2 = CardTypes.getDescriptionFromCard(this.ProfileCards[next].id);
						if (!(descriptionFromCard != descriptionFromCard2))
						{
							return this.ProfileCards[first].id.CompareTo(this.ProfileCards[next].id);
						}
						return descriptionFromCard.CompareTo(descriptionFromCard2);
					});
				}
			}
			this.lastUserCardSearchCriteria = filter;
			this.lastUserCardSortOrder = sort;
			this.lastUserCardNameFilter = namefilter;
		}

		// Token: 0x060008C8 RID: 2248 RVA: 0x0000D288 File Offset: 0x0000B488
		public void searchProfileCardsRedoLast()
		{
			if (this.lastUserCardSearchCriteria != null)
			{
				this.searchProfileCards(this.lastUserCardSearchCriteria, this.lastUserCardSortOrder, this.lastUserCardNameFilter);
			}
		}

		// Token: 0x060008C9 RID: 2249 RVA: 0x0000D2AA File Offset: 0x0000B4AA
		public void searchProfileCardsRedoLast(string nameFilter)
		{
			if (this.lastUserCardSearchCriteria != null)
			{
				this.searchProfileCards(this.lastUserCardSearchCriteria, this.lastUserCardSortOrder, nameFilter);
			}
		}

		// Token: 0x060008CA RID: 2250 RVA: 0x000B8794 File Offset: 0x000B6994
		public bool filterCard(CardTypes.CardDefinition filter, CardTypes.CardDefinition card)
		{
			if ((filter.cardCategory != 7 || (card.id != 2689 && card.id != 2690)) && filter.cardCategory != 0 && filter.cardCategory != card.cardCategory && (filter.cardCategory != 9 || (card.cardCategory != 6 && card.cardCategory != 7)))
			{
				return false;
			}
			if (filter.cardColour != 0 && filter.cardColour != card.cardColour)
			{
				return false;
			}
			if (filter.cardRank != 0 && filter.cardRank < card.cardRank)
			{
				return false;
			}
			if (filter.cardFilter != 0 && filter.cardFilter != card.cardFilter)
			{
				return false;
			}
			if (card.rewardcard && (!filter.rewardcard || card.worldID != RemoteServices.Instance.ProfileWorldID))
			{
				return false;
			}
			if (filter.keywords.Length > 0)
			{
				bool flag = false;
				string[] array = filter.keywords.Split(",".ToCharArray());
				string[] array2 = array;
				foreach (string value in array2)
				{
					if (card.keywords.Contains(value))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060008CB RID: 2251 RVA: 0x000B88C0 File Offset: 0x000B6AC0
		public int countPlayableCardsInFilter(int filter)
		{
			int num = 0;
			foreach (int key in this.ProfileCards.Keys)
			{
				if (CardTypes.isCardInNewCategory(this.ProfileCards[key].id, filter))
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x060008CC RID: 2252 RVA: 0x000B8934 File Offset: 0x000B6B34
		public int countPlayableCardsInCardSection(int category)
		{
			int num = 0;
			if (this.ProfileCards != null && this.ProfileCards.Values != null)
			{
				foreach (CardTypes.CardDefinition cardDefinition in this.ProfileCards.Values)
				{
					if (cardDefinition != null)
					{
						if (cardDefinition.cardCategory != category && category != 0)
						{
							if (category == 9 && (cardDefinition.cardCategory == 6 || cardDefinition.cardCategory == 7) && cardDefinition.name != "CARDTYPE_FLAG")
							{
								num++;
							}
						}
						else
						{
							num++;
						}
					}
				}
				return num;
			}
			return num;
		}

		// Token: 0x060008CD RID: 2253 RVA: 0x000B89E4 File Offset: 0x000B6BE4
		public void CardPlayed(int section, int type, int villageid)
		{
			GameEngine.Instance.World.handleQuestObjectiveHappening_PlayedCard(CardTypes.getCardType(type));
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			int cardType = CardTypes.getCardType(type);
			if (cardType <= 1039)
			{
				if (cardType <= 542)
				{
					if (cardType - 257 <= 2)
					{
						flag2 = true;
						goto IL_693;
					}
					if (cardType - 513 > 29)
					{
						goto IL_693;
					}
				}
				else if (cardType - 769 > 14 && cardType - 1025 > 14)
				{
					goto IL_693;
				}
			}
			else if (cardType <= 1802)
			{
				if (cardType - 1281 > 26)
				{
					if (cardType - 1800 > 2)
					{
						goto IL_693;
					}
					flag2 = true;
					goto IL_693;
				}
			}
			else
			{
				if (cardType - 2817 <= 14)
				{
					flag3 = true;
					goto IL_693;
				}
				switch (cardType)
				{
				case 2945:
				case 2946:
				case 2947:
					flag3 = true;
					goto IL_693;
				case 2948:
				case 2949:
				case 2950:
				case 2951:
				case 2952:
				case 2953:
				case 2954:
				case 2955:
				case 2956:
				case 2957:
				case 2958:
				case 2959:
				case 2960:
				case 2961:
				case 2962:
				case 2963:
				case 2964:
				case 2965:
				case 2966:
				case 2967:
				case 2968:
				case 2969:
				case 2976:
				case 2977:
				case 2978:
				case 2979:
				case 2980:
				case 2981:
				case 2982:
				case 2983:
				case 2984:
				case 2985:
				case 2986:
				case 2987:
				case 2988:
				case 2989:
				case 2990:
				case 2991:
				case 2992:
				case 2993:
				case 2994:
				case 2995:
				case 2996:
				case 2997:
				case 2998:
				case 2999:
				case 3000:
				case 3001:
				case 3002:
				case 3003:
				case 3004:
				case 3005:
				case 3006:
				case 3007:
				case 3008:
				case 3009:
				case 3010:
				case 3011:
				case 3012:
				case 3013:
				case 3014:
				case 3015:
				case 3016:
				case 3017:
				case 3018:
				case 3019:
				case 3020:
				case 3021:
				case 3022:
				case 3023:
				case 3024:
				case 3025:
				case 3026:
				case 3027:
				case 3028:
				case 3029:
				case 3030:
				case 3054:
				case 3060:
				case 3061:
				case 3062:
				case 3063:
				case 3064:
				case 3065:
				case 3066:
				case 3067:
				case 3068:
				case 3069:
				case 3070:
				case 3071:
				case 3072:
				case 3181:
				case 3182:
				case 3183:
				case 3184:
				case 3185:
				case 3186:
				case 3187:
				case 3188:
				case 3189:
				case 3190:
				case 3191:
				case 3192:
				case 3193:
				case 3194:
				case 3195:
				case 3196:
				case 3197:
				case 3198:
				case 3199:
				case 3200:
				case 3204:
				case 3205:
				case 3206:
				case 3207:
				case 3208:
				case 3209:
				case 3210:
				case 3211:
				case 3212:
				case 3213:
				case 3214:
				case 3215:
				case 3216:
				case 3217:
				case 3218:
				case 3219:
				case 3220:
				case 3221:
				case 3222:
				case 3223:
				case 3224:
				case 3225:
				case 3226:
				case 3227:
				case 3228:
				case 3229:
				case 3230:
				case 3231:
				case 3232:
				case 3239:
				case 3240:
				case 3241:
				case 3242:
				case 3243:
				case 3244:
				case 3245:
				case 3246:
				case 3247:
				case 3248:
				case 3253:
				case 3254:
				case 3255:
				case 3256:
				case 3257:
				case 3258:
				case 3259:
				case 3260:
				case 3261:
				case 3262:
				case 3263:
					goto IL_693;
				case 2970:
				case 2971:
				case 2972:
				case 2973:
				case 2974:
				case 2975:
					flag3 = true;
					goto IL_693;
				case 3031:
				case 3032:
				case 3033:
				case 3034:
				case 3035:
				case 3036:
				case 3037:
				case 3038:
				case 3039:
				case 3040:
				case 3041:
				case 3042:
				case 3043:
				case 3044:
				case 3045:
				case 3046:
				case 3047:
				case 3048:
				case 3049:
				case 3050:
				case 3051:
				case 3052:
				case 3053:
				case 3055:
				case 3056:
				case 3057:
				case 3058:
				case 3059:
					flag2 = true;
					goto IL_693;
				case 3073:
				case 3074:
				case 3075:
					flag4 = true;
					goto IL_693;
				case 3076:
					flag = true;
					goto IL_693;
				case 3077:
				case 3078:
				case 3079:
				case 3080:
				case 3081:
				case 3082:
				case 3083:
				case 3084:
					flag = true;
					goto IL_693;
				case 3085:
				case 3086:
				case 3087:
				case 3088:
				case 3089:
				case 3090:
				case 3091:
				case 3092:
				case 3093:
				case 3094:
				case 3095:
				case 3096:
				case 3097:
				case 3098:
				case 3099:
				case 3100:
				case 3101:
				case 3102:
				case 3103:
				case 3104:
				case 3105:
				case 3106:
				case 3107:
				case 3108:
				case 3109:
				case 3110:
				case 3111:
				case 3112:
				case 3113:
				case 3114:
				case 3115:
				case 3116:
				case 3117:
				case 3118:
				case 3119:
				case 3120:
				case 3121:
				case 3122:
				case 3123:
				case 3124:
				case 3125:
				case 3126:
				case 3127:
				case 3128:
				case 3129:
				case 3130:
				case 3131:
				case 3132:
				case 3133:
				case 3134:
				case 3135:
				case 3136:
				case 3137:
				case 3138:
				case 3139:
				case 3140:
				case 3141:
				case 3142:
				case 3143:
				case 3144:
				case 3145:
				case 3146:
				case 3147:
				case 3148:
				case 3149:
				case 3150:
				case 3151:
				case 3152:
				case 3153:
				case 3154:
				case 3155:
				case 3156:
				case 3157:
				case 3158:
				case 3159:
				case 3160:
				case 3161:
				case 3162:
				case 3163:
				case 3164:
				case 3165:
				case 3166:
				case 3167:
				case 3168:
				case 3169:
				case 3170:
				case 3171:
				case 3172:
				case 3173:
				case 3174:
				case 3175:
				case 3176:
				case 3177:
				case 3178:
				case 3179:
				case 3180:
					flag2 = true;
					goto IL_693;
				case 3201:
				case 3202:
				case 3203:
					flag2 = true;
					goto IL_693;
				case 3233:
				case 3234:
				case 3235:
					flag4 = true;
					goto IL_693;
				case 3236:
				case 3237:
				case 3238:
					flag2 = true;
					goto IL_693;
				case 3249:
				case 3250:
				case 3251:
				case 3252:
					flag4 = true;
					goto IL_693;
				case 3264:
				case 3265:
				case 3266:
				case 3267:
				case 3268:
				case 3269:
				case 3270:
				case 3271:
				case 3272:
				case 3273:
				case 3274:
				case 3275:
				case 3276:
				case 3277:
				case 3278:
				case 3279:
				case 3280:
				case 3281:
				case 3282:
				case 3283:
					flag2 = true;
					goto IL_693;
				case 3284:
				case 3285:
				case 3286:
					flag2 = true;
					goto IL_693;
				case 3287:
				case 3288:
				case 3289:
				case 3290:
				case 3291:
				case 3292:
				case 3293:
				case 3294:
				case 3295:
				case 3296:
				case 3297:
				case 3298:
					flag2 = true;
					goto IL_693;
				default:
					goto IL_693;
				}
			}
			flag3 = true;
			IL_693:
			if (flag)
			{
				this.pendingFullRefresh = true;
				this.pendingCardUpdateTime = DateTime.Now;
			}
			else
			{
				if (flag3)
				{
					this.pendingAllVillageRefresh = true;
					this.pendingCardUpdateTime = DateTime.Now;
				}
				else if (flag2 && villageid >= 0)
				{
					this.pendingVillageRefresh = true;
					this.pendingVillageRefreshID = villageid;
					this.pendingCardUpdateTime = DateTime.Now;
				}
				if (flag4)
				{
					this.pendingResearchRefresh = true;
					this.pendingCardUpdateTime = DateTime.Now;
				}
			}
			if (InterfaceMgr.Instance.getCardWindow() != null)
			{
				CursorManager.SetCursor(CursorManager.CursorType.Default, InterfaceMgr.Instance.getCardWindow());
			}
		}

		// Token: 0x060008CE RID: 2254 RVA: 0x000B9104 File Offset: 0x000B7304
		private void updateCurrentCardsCallback(UpdateCurrentCards_ReturnType returnData)
		{
			if (returnData.Success && returnData.m_cardData != null)
			{
				GameEngine.Instance.cardsManager.UserCardData = returnData.m_cardData;
				GameEngine.Instance.World.setGoldData(returnData.currentGoldLevel, returnData.currentGoldRate);
				GameEngine.Instance.World.setHonourData(returnData.currentHonourLevel, returnData.currentHonourRate);
				GameEngine.Instance.World.setFaithPointsData(returnData.currentFaithPointsLevel, returnData.currentFaithPointsRate);
			}
		}

		// Token: 0x060008CF RID: 2255 RVA: 0x000B9188 File Offset: 0x000B7388
		public void RetrievePremiumOffers()
		{
			if (!this.isGettingPremiumOffers && this.PremiumOffers == null)
			{
				this.isGettingPremiumOffers = true;
				this.PremiumOffers = null;
				XmlRpcPremiumOffersProvider xmlRpcPremiumOffersProvider = XmlRpcPremiumOffersProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressLogin, URLs.ProfileServerPort, URLs.ProfilePath);
				xmlRpcPremiumOffersProvider.GetSpecialOffers(new XmlRpcPremiumOffersRequest
				{
					UserGUID = RemoteServices.Instance.UserGuidProfileSite,
					SessionGUID = RemoteServices.Instance.SessionGuidProfileSite
				}, new PremiumOffersEndResponseDelegate(this.getSpecialOffersCallback), null);
			}
		}

		// Token: 0x060008D0 RID: 2256 RVA: 0x000B9208 File Offset: 0x000B7408
		private void getSpecialOffersCallback(IPremiumOffersProvider sender, IPremiumOffersResponse response)
		{
			int? successCode = response.SuccessCode;
			int num = 1;
			if (successCode.GetValueOrDefault() == num & successCode != null)
			{
				try
				{
					this.PremiumOffers = ((XmlRpcPremiumOffersResponse)response).Offers.ToArray();
					this.PremiumOffersViewed = false;
					goto IL_57;
				}
				catch (Exception)
				{
					this.PremiumOffers = new PremiumOfferData[0];
					goto IL_57;
				}
			}
			this.PremiumOffers = new PremiumOfferData[0];
			IL_57:
			this.isGettingPremiumOffers = false;
		}

		// Token: 0x060008D1 RID: 2257 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void purchasePremiumOffer()
		{
		}

		// Token: 0x060008D2 RID: 2258 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void purchasePremiumOfferCallback()
		{
		}

		// Token: 0x060008D3 RID: 2259 RVA: 0x0000D2C7 File Offset: 0x0000B4C7
		public void ResetPremiumOffers()
		{
			this.PremiumOffers = null;
			this.PremiumOffersViewed = true;
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x0000D2D7 File Offset: 0x0000B4D7
		public bool ShowPremiumOfferAlert()
		{
			return this.PremiumOffers != null && this.PremiumOffers.Length != 0 && !this.isGettingPremiumOffers && !this.PremiumOffersViewed;
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x000B9284 File Offset: 0x000B7484
		public bool PremiumOfferAvailable()
		{
			if (this.PremiumOffers == null || this.PremiumOffers.Length == 0)
			{
				return false;
			}
			PremiumOfferData[] premiumOffers = this.PremiumOffers;
			foreach (PremiumOfferData premiumOfferData in premiumOffers)
			{
				if (!premiumOfferData.HasBeenPurchased && premiumOfferData.ExpirationDate > VillageMap.getCurrentServerTime())
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060008D6 RID: 2262 RVA: 0x000B92DC File Offset: 0x000B74DC
		public void postcardPlayUpdate()
		{
			if ((DateTime.Now - this.pendingCardUpdateTime).TotalSeconds < 2.0)
			{
				return;
			}
			if (this.pendingFullRefresh)
			{
				GameEngine.Instance.flushVillages();
				GameEngine.Instance.World.doFullTick(true, 0);
			}
			else
			{
				bool flag = false;
				if (this.pendingAllVillageRefresh)
				{
					GameEngine.Instance.flushVillages();
					GameEngine.Instance.downloadCurrentVillage();
					Thread.Sleep(200);
					flag = true;
				}
				else if (this.pendingVillageRefresh && this.pendingVillageRefreshID >= 0)
				{
					GameEngine.Instance.flushVillage(this.pendingVillageRefreshID);
					GameEngine.Instance.downloadCurrentVillage();
					Thread.Sleep(200);
					flag = true;
				}
				if (this.pendingResearchRefresh)
				{
					GameEngine.Instance.World.updateResearch(true);
					Thread.Sleep(200);
					flag = true;
				}
				if (flag)
				{
					RemoteServices.Instance.set_UpdateCurrentCards_UserCallBack(new RemoteServices.UpdateCurrentCards_UserCallBack(this.updateCurrentCardsCallback));
					RemoteServices.Instance.UpdateCurrentCards();
				}
			}
			this.pendingFullRefresh = false;
			this.pendingAllVillageRefresh = false;
			this.pendingVillageRefresh = false;
			this.pendingVillageRefreshID = -1;
			this.pendingResearchRefresh = false;
		}

		// Token: 0x060008D7 RID: 2263 RVA: 0x000B9404 File Offset: 0x000B7604
		public void calcAvailableCategories()
		{
			CardTypes.CardDefinition[] cardList = CardTypes.cardList;
			foreach (CardTypes.CardDefinition cardDefinition in cardList)
			{
				if (cardDefinition.cardRank > 0 && cardDefinition.cardRarity > 0 && cardDefinition.available == 1)
				{
					if (CardTypes.isCardInNewCategory(cardDefinition.id, 16390))
					{
						this.NewCategoriesAvailable_Salt = true;
					}
					if (CardTypes.isCardInNewCategory(cardDefinition.id, 16391))
					{
						this.NewCategoriesAvailable_Spice = true;
					}
					if (CardTypes.isCardInNewCategory(cardDefinition.id, 16392))
					{
						this.NewCategoriesAvailable_Silk = true;
					}
					if (CardTypes.isCardInNewCategory(cardDefinition.id, 32773))
					{
						this.NewCategoriesAvailable_Catapults = true;
					}
					if (CardTypes.isCardInNewCategory(cardDefinition.id, 131077))
					{
						this.NewCategoriesAvailable_Strategy = true;
					}
					if (CardTypes.isCardInNewCategory(cardDefinition.id, 262151))
					{
						this.NewCategoriesAvailable_Capacity = true;
					}
					if (CardTypes.isCardInNewCategory(cardDefinition.id, 524288))
					{
						this.NewCategoriesAvailable_Parish = true;
					}
				}
			}
			if (this.NewCategoriesAvailable_Parish && (this.NewCategoriesAvailable_Capacity || (this.NewCategoriesAvailable_Salt && this.NewCategoriesAvailable_Spice && this.NewCategoriesAvailable_Silk)))
			{
				this.NewCategoriesAvailable_FullHeight = true;
			}
		}

		// Token: 0x060008D8 RID: 2264 RVA: 0x000B9534 File Offset: 0x000B7734
		public int countCardsInCategory(int newCategory)
		{
			if (newCategory == this.lastCountedCategory)
			{
				return this.lastCountedCategoryValue;
			}
			int num = 0;
			foreach (int key in this.ProfileCards.Keys)
			{
				if (CardTypes.isCardInNewCategory(this.ProfileCards[key].id, newCategory) || (newCategory == 1048576 && GameEngine.Instance.cardsManager.recentCards.Contains(this.ProfileCards[key].id)) || (newCategory == 2097152 && this.ProfileCards[key].cardRank <= GameEngine.Instance.World.getRank() + 1))
				{
					num++;
				}
			}
			this.lastCountedCategoryValue = num;
			this.lastCountedCategory = newCategory;
			return num;
		}

		// Token: 0x060008D9 RID: 2265 RVA: 0x000B9624 File Offset: 0x000B7824
		public int getUserCardIDByDefinition(CardTypes.CardDefinition def)
		{
			foreach (KeyValuePair<int, CardTypes.CardDefinition> keyValuePair in this.ProfileCards)
			{
				if (def.id == keyValuePair.Value.id)
				{
					return keyValuePair.Key;
				}
			}
			return 0;
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x000B9694 File Offset: 0x000B7894
		public bool HasCardAndCanPlayIt(int cardType)
		{
			List<int> inPlayCardSlots = GameEngine.Instance.cardsManager.getInPlayCardSlots();
			CardTypes.CardDefinition cardDefinition = CardTypes.getCardDefinition(cardType);
			int basicUniqueCardType = CardTypes.getBasicUniqueCardType(cardDefinition.id);
			List<int> allUserCardIDsByDefinition = GameEngine.Instance.cardsManager.getAllUserCardIDsByDefinition(cardDefinition);
			bool flag = basicUniqueCardType != -1 && inPlayCardSlots.Contains(basicUniqueCardType);
			bool flag2 = allUserCardIDsByDefinition.Count == 0;
			return !flag && !flag2;
		}

		// Token: 0x060008DB RID: 2267 RVA: 0x000B96FC File Offset: 0x000B78FC
		public List<int> getAllUserCardIDsByDefinition(CardTypes.CardDefinition def)
		{
			List<int> list = new List<int>();
			foreach (KeyValuePair<int, CardTypes.CardDefinition> keyValuePair in this.ProfileCards)
			{
				if (def.id == keyValuePair.Value.id)
				{
					list.Add(keyValuePair.Key);
				}
			}
			return list;
		}

		// Token: 0x060008DC RID: 2268 RVA: 0x0000D2FD File Offset: 0x0000B4FD
		public static string translateCardError(string message, int cardType)
		{
			return CardsManager.translateCardError(message, cardType, -1);
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x000B9770 File Offset: 0x000B7970
		public static string translateCardError(string message, int cardType, int altMethod)
		{
			SK.Text("RETURNED_CARD_ERROR_BASE", "Could not play");
			if (message.Contains("More than one of this card (or this type of card) may not be played at the same time."))
			{
				return string.Concat(new string[]
				{
					SK.Text("RETURNED_CARD_ERROR_BASE", "Could not play"),
					Environment.NewLine,
					Environment.NewLine,
					CardTypes.getDescriptionFromCard(cardType),
					Environment.NewLine,
					Environment.NewLine,
					SK.Text("RETURNED_CARD_ERROR_17", "More than one of this card (or this type of card) may not be played at the same time.")
				});
			}
			if (message.Contains("Troop type not researched.") || altMethod == 5)
			{
				return string.Concat(new string[]
				{
					SK.Text("RETURNED_CARD_ERROR_BASE", "Could not play"),
					Environment.NewLine,
					Environment.NewLine,
					CardTypes.getDescriptionFromCard(cardType),
					Environment.NewLine,
					Environment.NewLine,
					SK.Text("RETURNED_CARD_ERROR_18", "Troop type not researched.")
				});
			}
			if (message.Contains("Not enough space in the barracks for those troops.") || altMethod == 1)
			{
				return string.Concat(new string[]
				{
					SK.Text("RETURNED_CARD_ERROR_BASE", "Could not play"),
					Environment.NewLine,
					Environment.NewLine,
					CardTypes.getDescriptionFromCard(cardType),
					Environment.NewLine,
					Environment.NewLine,
					SK.Text("RETURNED_CARD_ERROR_15", "Not enough space in the barracks for those troops.")
				});
			}
			if (message.Contains("No Room for Merchants.") || altMethod == 4)
			{
				return string.Concat(new string[]
				{
					SK.Text("RETURNED_CARD_ERROR_BASE", "Could not play"),
					Environment.NewLine,
					Environment.NewLine,
					CardTypes.getDescriptionFromCard(cardType),
					Environment.NewLine,
					Environment.NewLine,
					SK.Text("RETURNED_CARD_ERROR_19", "No Room for Merchants.")
				});
			}
			if (message.Contains("No walls under construction."))
			{
				return string.Concat(new string[]
				{
					SK.Text("RETURNED_CARD_ERROR_BASE", "Could not play"),
					Environment.NewLine,
					Environment.NewLine,
					CardTypes.getDescriptionFromCard(cardType),
					Environment.NewLine,
					Environment.NewLine,
					SK.Text("RETURNED_CARD_ERROR_20", "No walls under construction.")
				});
			}
			if (message.Contains("No moat under construction"))
			{
				return string.Concat(new string[]
				{
					SK.Text("RETURNED_CARD_ERROR_BASE", "Could not play"),
					Environment.NewLine,
					Environment.NewLine,
					CardTypes.getDescriptionFromCard(cardType),
					Environment.NewLine,
					Environment.NewLine,
					SK.Text("RETURNED_CARD_ERROR_21", "No moat under construction")
				});
			}
			if (message.Contains("No pits under construction"))
			{
				return string.Concat(new string[]
				{
					SK.Text("RETURNED_CARD_ERROR_BASE", "Could not play"),
					Environment.NewLine,
					Environment.NewLine,
					CardTypes.getDescriptionFromCard(cardType),
					Environment.NewLine,
					Environment.NewLine,
					SK.Text("RETURNED_CARD_ERROR_22", "No pits under construction")
				});
			}
			if (message.Contains("No room for Monks") || altMethod == 3)
			{
				return string.Concat(new string[]
				{
					SK.Text("RETURNED_CARD_ERROR_BASE", "Could not play"),
					Environment.NewLine,
					Environment.NewLine,
					CardTypes.getDescriptionFromCard(cardType),
					Environment.NewLine,
					Environment.NewLine,
					SK.Text("RETURNED_CARD_ERROR_23", "No room for Monks")
				});
			}
			if (message.Contains("No room for Scouts") || altMethod == 2)
			{
				return string.Concat(new string[]
				{
					SK.Text("RETURNED_CARD_ERROR_BASE", "Could not play"),
					Environment.NewLine,
					Environment.NewLine,
					CardTypes.getDescriptionFromCard(cardType),
					Environment.NewLine,
					Environment.NewLine,
					SK.Text("RETURNED_CARD_ERROR_24", "No room for Scouts")
				});
			}
			if (message.Contains("Nothing under construction"))
			{
				return string.Concat(new string[]
				{
					SK.Text("RETURNED_CARD_ERROR_BASE", "Could not play"),
					Environment.NewLine,
					Environment.NewLine,
					CardTypes.getDescriptionFromCard(cardType),
					Environment.NewLine,
					Environment.NewLine,
					SK.Text("RETURNED_CARD_ERROR_25", "Nothing under construction")
				});
			}
			if (message.Contains("No current building queue"))
			{
				return string.Concat(new string[]
				{
					SK.Text("RETURNED_CARD_ERROR_BASE", "Could not play"),
					Environment.NewLine,
					Environment.NewLine,
					CardTypes.getDescriptionFromCard(cardType),
					Environment.NewLine,
					Environment.NewLine,
					SK.Text("RETURNED_CARD_ERROR_12", "No current building queue")
				});
			}
			if (message.Contains("No current Research"))
			{
				return string.Concat(new string[]
				{
					SK.Text("RETURNED_CARD_ERROR_BASE", "Could not play"),
					Environment.NewLine,
					Environment.NewLine,
					CardTypes.getDescriptionFromCard(cardType),
					Environment.NewLine,
					Environment.NewLine,
					SK.Text("RETURNED_CARD_ERROR_11", "No current Research")
				});
			}
			if (message.Contains("Premium card already in play"))
			{
				return SK.Text("RETURNED_CARD_ERROR_6", "Premium token already in play");
			}
			if (message.Contains("Player Rank too low"))
			{
				return string.Concat(new string[]
				{
					SK.Text("RETURNED_CARD_ERROR_BASE", "Could not play"),
					Environment.NewLine,
					Environment.NewLine,
					CardTypes.getDescriptionFromCard(cardType),
					Environment.NewLine,
					Environment.NewLine,
					SK.Text("RETURNED_CARD_ERROR_8", "Player Rank too low")
				});
			}
			return message;
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x000B9CF0 File Offset: 0x000B7EF0
		public static string translateErrorShort(string message)
		{
			if (message.Contains("More than one of this card (or this type of card) may not be played at the same time."))
			{
				return SK.Text("RETURNED_CARD_ERROR_17", "More than one of this card (or this type of card) may not be played at the same time.");
			}
			if (message.Contains("Troop type not researched."))
			{
				return SK.Text("RETURNED_CARD_ERROR_18", "Troop type not researched.");
			}
			if (message.Contains("Not enough space in the barracks for those troops."))
			{
				return SK.Text("RETURNED_CARD_ERROR_15", "Not enough space in the barracks for those troops.");
			}
			if (message.Contains("No Room for Merchants."))
			{
				return SK.Text("RETURNED_CARD_ERROR_19", "No Room for Merchants.");
			}
			if (message.Contains("No walls under construction."))
			{
				return SK.Text("RETURNED_CARD_ERROR_20", "No walls under construction.");
			}
			if (message.Contains("No moat under construction"))
			{
				return SK.Text("RETURNED_CARD_ERROR_21", "No moat under construction");
			}
			if (message.Contains("No pits under construction"))
			{
				return SK.Text("RETURNED_CARD_ERROR_22", "No pits under construction");
			}
			if (message.Contains("No room for Monks"))
			{
				return SK.Text("RETURNED_CARD_ERROR_23", "No room for Monks");
			}
			if (message.Contains("No room for Scouts"))
			{
				return SK.Text("RETURNED_CARD_ERROR_24", "No room for Scouts");
			}
			if (message.Contains("Nothing under construction"))
			{
				return SK.Text("RETURNED_CARD_ERROR_25", "Nothing under construction");
			}
			if (message.Contains("No current building queue"))
			{
				return SK.Text("RETURNED_CARD_ERROR_12", "No current building queue");
			}
			if (message.Contains("No current Research"))
			{
				return SK.Text("RETURNED_CARD_ERROR_11", "No current Research");
			}
			if (message.Contains("Premium card already in play"))
			{
				return SK.Text("RETURNED_CARD_ERROR_6", "Premium token already in play");
			}
			if (message.Contains("Player Rank too low"))
			{
				return SK.Text("RETURNED_CARD_ERROR_8", "Player Rank too low");
			}
			return message;
		}

		// Token: 0x060008DF RID: 2271 RVA: 0x000B9E94 File Offset: 0x000B8094
		public List<int> getInPlayCardSlots()
		{
			List<int> list = new List<int>();
			int[] cards = this.UserCardData.cards;
			foreach (int card in cards)
			{
				int cardType = CardTypes.getCardType(card);
				int basicUniqueCardType = CardTypes.getBasicUniqueCardType(cardType);
				if (!list.Contains(basicUniqueCardType))
				{
					list.Add(basicUniqueCardType);
				}
			}
			return list;
		}

		// Token: 0x04000C3E RID: 3134
		public int SelectedUserCardID;

		// Token: 0x04000C3F RID: 3135
		public CardTypes.CardDefinition lastUserCardSearchCriteria;

		// Token: 0x04000C40 RID: 3136
		public string lastUserCardSortOrder = string.Empty;

		// Token: 0x04000C41 RID: 3137
		public string lastUserCardNameFilter = string.Empty;

		// Token: 0x04000C42 RID: 3138
		public CardTypes.CardDefinition lastCardCatalogSearchCriteria;

		// Token: 0x04000C43 RID: 3139
		public string lastCardCatalogSortOrder = string.Empty;

		// Token: 0x04000C44 RID: 3140
		private Dictionary<int, CardTypes.CardDefinition> mProfileCards;

		// Token: 0x04000C45 RID: 3141
		private List<int> mProfileCardsSearch;

		// Token: 0x04000C46 RID: 3142
		private List<int> mProfileCardsSet;

		// Token: 0x04000C47 RID: 3143
		private List<int> mCatalogCardsSearch;

		// Token: 0x04000C48 RID: 3144
		private List<int> mShoppingCartCards;

		// Token: 0x04000C49 RID: 3145
		public bool NewCategoriesAvailable_Salt;

		// Token: 0x04000C4A RID: 3146
		public bool NewCategoriesAvailable_Spice;

		// Token: 0x04000C4B RID: 3147
		public bool NewCategoriesAvailable_Silk;

		// Token: 0x04000C4C RID: 3148
		public bool NewCategoriesAvailable_Catapults;

		// Token: 0x04000C4D RID: 3149
		public bool NewCategoriesAvailable_Strategy;

		// Token: 0x04000C4E RID: 3150
		public bool NewCategoriesAvailable_Capacity;

		// Token: 0x04000C4F RID: 3151
		public bool NewCategoriesAvailable_Parish;

		// Token: 0x04000C50 RID: 3152
		public bool NewCategoriesAvailable_FullHeight;

		// Token: 0x04000C51 RID: 3153
		public int lastCountedCategory = -1;

		// Token: 0x04000C52 RID: 3154
		public int lastCountedCategoryValue;

		// Token: 0x04000C53 RID: 3155
		private CardData m_userCardData;

		// Token: 0x04000C54 RID: 3156
		public bool UserCardDataChanged;

		// Token: 0x04000C55 RID: 3157
		public List<int> recentCards = new List<int>();

		// Token: 0x04000C56 RID: 3158
		public PremiumOfferData[] PremiumOffers;

		// Token: 0x04000C57 RID: 3159
		public bool isGettingPremiumOffers;

		// Token: 0x04000C58 RID: 3160
		public bool PremiumOffersViewed;

		// Token: 0x04000C59 RID: 3161
		private bool pendingFullRefresh;

		// Token: 0x04000C5A RID: 3162
		private bool pendingAllVillageRefresh;

		// Token: 0x04000C5B RID: 3163
		private bool pendingVillageRefresh;

		// Token: 0x04000C5C RID: 3164
		private int pendingVillageRefreshID = -1;

		// Token: 0x04000C5D RID: 3165
		private bool pendingResearchRefresh;

		// Token: 0x04000C5E RID: 3166
		private DateTime pendingCardUpdateTime = DateTime.MinValue;
	}
}
