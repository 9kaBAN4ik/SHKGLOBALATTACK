using System;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms;

namespace Upgrade.Services
{
	// Token: 0x0200003B RID: 59
	internal class CardExpiryChecker
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000229 RID: 553 RVA: 0x00009265 File Offset: 0x00007465
		internal ScoutingService ScoutingService { get; private set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600022A RID: 554 RVA: 0x0000926D File Offset: 0x0000746D
		internal TradeService TradeService { get; private set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600022B RID: 555 RVA: 0x00009275 File Offset: 0x00007475
		public CheckBox CheckBox_Scout { get; private set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600022C RID: 556 RVA: 0x0000927D File Offset: 0x0000747D
		public CheckBox CheckBox_Trade { get; private set; }

		// Token: 0x0600022D RID: 557 RVA: 0x00009285 File Offset: 0x00007485
		private void LLog(string msg)
		{
			this.Log(msg, ControlForm.Tab.Main, false);
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00009295 File Offset: 0x00007495
		internal CardExpiryChecker(Log log, ScoutingService scoutingService, TradeService tradeService, CheckBox checkBox_Scout, CheckBox checkBox_Trade)
		{
			this.Log = log;
			this.ScoutingService = scoutingService;
			this.TradeService = tradeService;
			this.CheckBox_Scout = checkBox_Scout;
			this.CheckBox_Trade = checkBox_Trade;
		}

		// Token: 0x0600022F RID: 559 RVA: 0x000092C2 File Offset: 0x000074C2
		internal void CheckCardsExpiration(CardData cardData)
		{
			if (this.SkipCheck())
			{
				return;
			}
			this.DidCardsExpire(cardData);
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00048A50 File Offset: 0x00046C50
		private bool SkipCheck()
		{
			return this._nextCardExpiry > VillageMap.getCurrentServerTime().AddSeconds(10.0) || ((!this.ScoutingService.Enabled || !this.ScoutingService.StopScoutOnCardsExpiry) && (!this.TradeService.Enabled || !this.TradeService.StopTradeOnCardExpiry));
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00048ABC File Offset: 0x00046CBC
		private void DidCardsExpire(CardData cardData)
		{
			bool flag = false;
			bool flag2 = false;
			DateTime dateTime = DateTime.MaxValue;
			for (int i = 0; i < cardData.cards.Length; i++)
			{
				if (cardData.cards[i] != 0)
				{
					int cardType = CardTypes.getCardType(cardData.cards[i]);
					if (cardType - 1537 > 2 && cardType - 1541 > 2)
					{
						if (cardType - 2305 <= 5)
						{
							flag = true;
							if (dateTime > cardData.cardsExpiry[i])
							{
								dateTime = cardData.cardsExpiry[i];
							}
						}
					}
					else
					{
						flag2 = true;
						if (dateTime > cardData.cardsExpiry[i])
						{
							dateTime = cardData.cardsExpiry[i];
						}
					}
				}
			}
			bool didScoutingCardsExpire = this._scoutsInPlay && !flag;
			bool didTradingCardsExpire = this._tradeInPlay && !flag2;
			this._scoutsInPlay = flag;
			this._tradeInPlay = flag2;
			if (flag || flag2)
			{
				this._nextCardExpiry = dateTime;
			}
			else
			{
				this._nextCardExpiry = VillageMap.getCurrentServerTime().AddHours(3.0);
			}
			this.DisableModules(didScoutingCardsExpire, didTradingCardsExpire);
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00048BE0 File Offset: 0x00046DE0
		private void DisableModules(bool didScoutingCardsExpire, bool didTradingCardsExpire)
		{
			if (didScoutingCardsExpire && this.ScoutingService.Enabled && this.ScoutingService.StopScoutOnCardsExpiry)
			{
				this.ScoutingService.Enabled = false;
				this.CheckBox_Scout.Checked = false;
				if (this.ScoutingService.ShowPopupOnScoutsExpiry)
				{
					ABaseService.MessageBoxNonModal(LNG.Print("Scouting was stopped due cards expiry."), LNG.Print("Scouting stopped"));
				}
			}
			if (didTradingCardsExpire && this.TradeService.Enabled && this.TradeService.StopTradeOnCardExpiry)
			{
				this.TradeService.Enabled = false;
				this.CheckBox_Trade.Checked = false;
				if (this.TradeService.ShowPopupOnTradeExpiry)
				{
					ABaseService.MessageBoxNonModal(LNG.Print("Trade was stopped due cards expiry"), LNG.Print("Trade stopped"));
				}
			}
		}

		// Token: 0x040003B3 RID: 947
		private DateTime _nextCardExpiry;

		// Token: 0x040003B4 RID: 948
		private bool _scoutsInPlay;

		// Token: 0x040003B5 RID: 949
		private bool _tradeInPlay;

		// Token: 0x040003B6 RID: 950
		private readonly Log Log;
	}
}
