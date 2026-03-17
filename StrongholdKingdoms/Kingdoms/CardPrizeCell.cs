using System;
using System.Drawing;
using CommonTypes;
using Stronghold.AuthClient;

namespace Kingdoms
{
	// Token: 0x02000110 RID: 272
	public class CardPrizeCell : ContestPrizeCell
	{
		// Token: 0x060008B3 RID: 2227 RVA: 0x000B811C File Offset: 0x000B631C
		public override void init()
		{
			this.clearControls();
			this.Quantity.Color = global::ARGBColors.Black;
			this.Quantity.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
			this.Quantity.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			base.addControl(this.Icon);
			base.addControl(this.Quantity);
		}

		// Token: 0x060008B4 RID: 2228 RVA: 0x000B8180 File Offset: 0x000B6380
		public void SetCardImage(ContestPrizeCardDefinition def)
		{
			this.newCard = BuyCardsPanel.makeUICard(CardTypes.getCardDefinition(def.ID), 0, GameEngine.Instance.World.getRank() + 1);
			this.newCard.ScaleAll(0.25 * (double)InterfaceMgr.UIScale);
			base.addControl(this.newCard);
		}

		// Token: 0x060008B5 RID: 2229 RVA: 0x000B81DC File Offset: 0x000B63DC
		public override void resize()
		{
			base.resize();
			this.newCard.Position = new Point(base.Width / 4 - this.newCard.Width / 2, this.Icon.Height / 2 - this.newCard.Height / 2);
			this.newCard.invalidate();
			this.Quantity.invalidate();
		}

		// Token: 0x04000C3D RID: 3133
		private UICard newCard;
	}
}
