using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x02000135 RID: 309
	public partial class ConfirmBuyOfferPopup : Form
	{
		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000B72 RID: 2930 RVA: 0x0000E79A File Offset: 0x0000C99A
		public int Multiple
		{
			get
			{
				return this.confirmPanel.Multiple;
			}
		}

		// Token: 0x06000B73 RID: 2931 RVA: 0x0000E7A7 File Offset: 0x0000C9A7
		public ConfirmBuyOfferPopup()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06000B74 RID: 2932 RVA: 0x0000E7CA File Offset: 0x0000C9CA
		public void init(UICardOffer offer, ConfirmBuyOfferPanel.CardClickPlayDelegate callback)
		{
			this.confirmPanel.init(offer.Offer, offer.nameLabel.Text, callback, this);
		}

		// Token: 0x06000B75 RID: 2933 RVA: 0x0000E7EA File Offset: 0x0000C9EA
		public void init(CardTypes.CardOffer offer, ConfirmBuyOfferPanel.CardClickPlayDelegate callback)
		{
			this.confirmPanel.init(offer, offer.Name, callback, this);
		}

		// Token: 0x06000B76 RID: 2934 RVA: 0x0000E800 File Offset: 0x0000CA00
		public void update()
		{
			this.confirmPanel.update();
		}

		// Token: 0x06000B77 RID: 2935 RVA: 0x000E4340 File Offset: 0x000E2540
		private void ConfirmPlayCardPopup_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseReason closeReason = e.CloseReason;
			if (closeReason == CloseReason.UserClosing && !this.closing)
			{
				this.closing = true;
				InterfaceMgr.Instance.closeConfirmPlayCardPopup();
			}
		}

		// Token: 0x04000F8B RID: 3979
		private bool closing;
	}
}
