using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonTypes;
using Stronghold.AuthClient;

namespace Kingdoms
{
	// Token: 0x0200027F RID: 639
	public class PremiumTokenManager
	{
		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x06001CB3 RID: 7347 RVA: 0x0001C1A9 File Offset: 0x0001A3A9
		public Dictionary<int, CardTypes.PremiumToken> ProfilePremiumTokens
		{
			get
			{
				if (this.mProfilePremiumTokens == null)
				{
					this.mProfilePremiumTokens = new Dictionary<int, CardTypes.PremiumToken>();
				}
				return this.mProfilePremiumTokens;
			}
		}

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x06001CB4 RID: 7348 RVA: 0x0001C1C4 File Offset: 0x0001A3C4
		public TimeSpan ExpiryTimeSpan
		{
			get
			{
				return GameEngine.Instance.cardsManager.UserCardData.premiumCardExpiry.Subtract(VillageMap.getCurrentServerTime());
			}
		}

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x06001CB5 RID: 7349 RVA: 0x0001C1E4 File Offset: 0x0001A3E4
		public bool PremiumInPlay
		{
			get
			{
				return GameEngine.Instance.cardsManager.UserCardData.premiumCard > 0;
			}
		}

		// Token: 0x06001CB6 RID: 7350 RVA: 0x001C2410 File Offset: 0x001C0610
		public int countPremiumTokensOfType(int tokenType)
		{
			int num = 0;
			foreach (CardTypes.PremiumToken premiumToken in this.ProfilePremiumTokens.Values)
			{
				if (premiumToken.Type == tokenType)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06001CB7 RID: 7351 RVA: 0x001C2474 File Offset: 0x001C0674
		public void buyToken(int premiumType, CardsEndResponseDelegate uiDelegate, Control callbackControl)
		{
			this.buyTokenUiDelegate = uiDelegate;
			this.buyingTokenType = premiumType;
			XmlRpcCardsProvider xmlRpcCardsProvider = XmlRpcCardsProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressCards, URLs.ProfileServerPort, URLs.ProfileCardPath);
			XmlRpcCardsRequest xmlRpcCardsRequest = new XmlRpcCardsRequest(RemoteServices.Instance.UserGuid.ToString().Replace("-", ""));
			xmlRpcCardsRequest.SessionGUID = RemoteServices.Instance.SessionGuid.ToString().Replace("-", "");
			if (premiumType != 4112)
			{
				if (premiumType != 4114)
				{
					throw new ArgumentException("Did not provide a purchasable premium token type");
				}
				xmlRpcCardsRequest.PackID = "6";
				this.crowns = 100;
			}
			else
			{
				xmlRpcCardsRequest.PackID = "2";
				this.crowns = 30;
			}
			xmlRpcCardsProvider.buyPremium(xmlRpcCardsRequest, new CardsEndResponseDelegate(this.onBoughtToken), callbackControl);
			GameEngine.Instance.World.ProfileCrowns -= this.crowns;
		}

		// Token: 0x06001CB8 RID: 7352 RVA: 0x001C257C File Offset: 0x001C077C
		private void onBoughtToken(ICardsProvider provider, ICardsResponse response)
		{
			int? successCode = response.SuccessCode;
			int num = 1;
			if (!(successCode.GetValueOrDefault() == num & successCode != null))
			{
				GameEngine.Instance.World.ProfileCrowns += this.crowns;
			}
			else
			{
				int num2 = 0;
				int.TryParse(response.Strings, out num2);
				CardTypes.PremiumToken premiumToken = new CardTypes.PremiumToken();
				premiumToken.Reward = 0;
				premiumToken.Type = this.buyingTokenType;
				premiumToken.UserPremiumTokenID = num2;
				premiumToken.WorldID = RemoteServices.Instance.ProfileWorldID;
				this.ProfilePremiumTokens.Add(num2, premiumToken);
			}
			this.buyTokenUiDelegate(provider, response);
		}

		// Token: 0x06001CB9 RID: 7353 RVA: 0x001C2620 File Offset: 0x001C0820
		public CardTypes.PremiumToken getUserTokenOfType(int tokenType)
		{
			if (tokenType != 4113 && tokenType != 4112 && tokenType != 4114)
			{
				throw new ArgumentException("Tried to find invalid token type " + tokenType.ToString());
			}
			if (this.mProfilePremiumTokens != null)
			{
				foreach (CardTypes.PremiumToken premiumToken in this.mProfilePremiumTokens.Values)
				{
					if (premiumToken.Type == tokenType)
					{
						return premiumToken;
					}
				}
			}
			return null;
		}

		// Token: 0x06001CBA RID: 7354 RVA: 0x0001C1FD File Offset: 0x0001A3FD
		public CardTypes.PremiumToken getUserToken(int userTokenID)
		{
			if (this.mProfilePremiumTokens != null && this.mProfilePremiumTokens.ContainsKey(userTokenID))
			{
				return this.mProfilePremiumTokens[userTokenID];
			}
			return null;
		}

		// Token: 0x06001CBB RID: 7355 RVA: 0x001C26B8 File Offset: 0x001C08B8
		public void PlayToken(CardTypes.PremiumToken token, CardsEndResponseDelegate uiDelegate, Control callbackControl)
		{
			this.playingToken = token;
			this.m_playTokenUiDelegate = uiDelegate;
			DateTime dateTime = VillageMap.getCurrentServerTime();
			double num = GameEngine.Instance.cardsManager.UserCardData.premiumCardExpiry.Subtract(VillageMap.getCurrentServerTime()).TotalSeconds;
			if (num < 0.0)
			{
				num = 0.0;
			}
			dateTime = dateTime.AddSeconds(num);
			XmlRpcCardsProvider xmlRpcCardsProvider = XmlRpcCardsProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressCards, URLs.ProfileServerPort, URLs.ProfileCardPath);
			XmlRpcCardsRequest xmlRpcCardsRequest = new XmlRpcCardsRequest(RemoteServices.Instance.UserGuid.ToString().Replace("-", ""));
			xmlRpcCardsRequest.SessionGUID = RemoteServices.Instance.SessionGuid.ToString().Replace("-", "");
			xmlRpcCardsRequest.WorldID = RemoteServices.Instance.ProfileWorldID.ToString();
			xmlRpcCardsRequest.UserCardID = this.playingToken.UserPremiumTokenID.ToString();
			if (this.playingToken.Type == 4112)
			{
				xmlRpcCardsRequest.CardString = "CARDTYPE_PREMIUM";
			}
			if (this.playingToken.Type == 4113)
			{
				xmlRpcCardsRequest.CardString = "CARDTYPE_PREMIUM2";
			}
			if (this.playingToken.Type == 4114)
			{
				xmlRpcCardsRequest.CardString = "CARDTYPE_PREMIUM30";
			}
			xmlRpcCardsProvider.playPremium(xmlRpcCardsRequest, new CardsEndResponseDelegate(this.onPlayedToken), callbackControl);
			this.ProfilePremiumCards--;
			if (this.playingToken.Type == 4112)
			{
				GameEngine.Instance.cardsManager.UserCardData.premiumCardExpiry = dateTime.AddDays(7.0);
			}
			if (this.playingToken.Type == 4114)
			{
				GameEngine.Instance.cardsManager.UserCardData.premiumCardExpiry = dateTime.AddDays(30.0);
			}
			if (this.playingToken.Type == 4113)
			{
				GameEngine.Instance.cardsManager.UserCardData.premiumCardExpiry = dateTime.AddDays(2.0);
			}
			if (this.PremiumInPlay)
			{
				GameEngine.Instance.cardsManager.UserCardData.premiumCard = 4116;
			}
			else
			{
				GameEngine.Instance.cardsManager.UserCardData.premiumCard = this.playingToken.Type;
			}
			GameEngine.Instance.premiumTokenManager.ProfilePremiumTokens.Remove(this.playingToken.UserPremiumTokenID);
		}

		// Token: 0x06001CBC RID: 7356 RVA: 0x001C2944 File Offset: 0x001C0B44
		private void onPlayedToken(ICardsProvider provider, ICardsResponse response)
		{
			int? successCode = response.SuccessCode;
			int num = 1;
			if (!(successCode.GetValueOrDefault() == num & successCode != null))
			{
				GameEngine.Instance.premiumTokenManager.ProfilePremiumTokens.Add(this.playingToken.UserPremiumTokenID, this.playingToken);
				GameEngine.Instance.cardsManager.UserCardData.premiumCard = 0;
				GameEngine.Instance.cardsManager.UserCardData.premiumCardExpiry = VillageMap.getCurrentServerTime();
			}
			else
			{
				GameEngine.Instance.cardsManager.CardPlayed(-1, GameEngine.Instance.cardsManager.UserCardData.premiumCard, -1);
			}
			if (this.m_playTokenUiDelegate != null)
			{
				this.m_playTokenUiDelegate(provider, response);
			}
		}

		// Token: 0x06001CBD RID: 7357 RVA: 0x0001C223 File Offset: 0x0001A423
		public void AddToken(CardTypes.PremiumToken premiumToken)
		{
			if (!this.ProfilePremiumTokens.ContainsKey(premiumToken.UserPremiumTokenID))
			{
				this.ProfilePremiumTokens.Add(premiumToken.UserPremiumTokenID, premiumToken);
			}
		}

		// Token: 0x04002DA4 RID: 11684
		public int ProfilePremiumCards;

		// Token: 0x04002DA5 RID: 11685
		private Dictionary<int, CardTypes.PremiumToken> mProfilePremiumTokens;

		// Token: 0x04002DA6 RID: 11686
		private CardsEndResponseDelegate buyTokenUiDelegate;

		// Token: 0x04002DA7 RID: 11687
		private int crowns;

		// Token: 0x04002DA8 RID: 11688
		private int buyingTokenType;

		// Token: 0x04002DA9 RID: 11689
		private CardsEndResponseDelegate m_playTokenUiDelegate;

		// Token: 0x04002DAA RID: 11690
		private CardTypes.PremiumToken playingToken;
	}
}
