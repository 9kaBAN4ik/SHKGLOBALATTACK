using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x020000F6 RID: 246
	public partial class BuyVillagePopupWindow : Form
	{
		// Token: 0x06000776 RID: 1910 RVA: 0x0000C382 File Offset: 0x0000A582
		public BuyVillagePopupWindow()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06000777 RID: 1911 RVA: 0x0000C3A5 File Offset: 0x0000A5A5
		public void init(int villageID, bool buy)
		{
			this.buyVillagePopupPanel.init(villageID, buy);
		}

		// Token: 0x06000778 RID: 1912 RVA: 0x0000C3B4 File Offset: 0x0000A5B4
		public void update()
		{
			this.buyVillagePopupPanel.update();
		}

		// Token: 0x06000779 RID: 1913 RVA: 0x0009C8A0 File Offset: 0x0009AAA0
		private void BuyVillagePopupPanel_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseReason closeReason = e.CloseReason;
			if (closeReason == CloseReason.UserClosing && !this.closing)
			{
				this.closing = true;
				InterfaceMgr.Instance.closeBuyVillagePopupWindow();
			}
		}

		// Token: 0x04000A29 RID: 2601
		private bool closing;
	}
}
