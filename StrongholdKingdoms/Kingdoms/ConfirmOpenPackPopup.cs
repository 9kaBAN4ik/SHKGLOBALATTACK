using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x02000138 RID: 312
	public partial class ConfirmOpenPackPopup : Form
	{
		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000B8C RID: 2956 RVA: 0x0000E8D8 File Offset: 0x0000CAD8
		public int Multiple
		{
			get
			{
				return this.confirmPanel.Multiple;
			}
		}

		// Token: 0x06000B8D RID: 2957 RVA: 0x0000E8E5 File Offset: 0x0000CAE5
		public ConfirmOpenPackPopup()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06000B8E RID: 2958 RVA: 0x0000E908 File Offset: 0x0000CB08
		public void init(UICardPack pack, ConfirmOpenPackPanel.CardClickPlayDelegate callback)
		{
			this.confirmPanel.init(pack, callback, this);
		}

		// Token: 0x06000B8F RID: 2959 RVA: 0x0000E918 File Offset: 0x0000CB18
		public void update()
		{
			this.confirmPanel.update();
		}

		// Token: 0x06000B90 RID: 2960 RVA: 0x000E5384 File Offset: 0x000E3584
		private void ConfirmPlayCardPopup_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseReason closeReason = e.CloseReason;
			if (closeReason == CloseReason.UserClosing && !this.closing)
			{
				this.closing = true;
				InterfaceMgr.Instance.closeConfirmPlayCardPopup();
			}
		}

		// Token: 0x04000FA2 RID: 4002
		private bool closing;
	}
}
