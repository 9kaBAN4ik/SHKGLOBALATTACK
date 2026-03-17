using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x0200013B RID: 315
	public partial class ConfirmPlayCardPopup : Form
	{
		// Token: 0x06000B9E RID: 2974 RVA: 0x0000E977 File Offset: 0x0000CB77
		public ConfirmPlayCardPopup()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06000B9F RID: 2975 RVA: 0x0000E99A File Offset: 0x0000CB9A
		public void init(CardTypes.CardDefinition def, ConfirmPlayCardPanel.CardClickPlayDelegate callback)
		{
			this.confirmPanel.init(def, callback);
		}

		// Token: 0x06000BA0 RID: 2976 RVA: 0x0000E9A9 File Offset: 0x0000CBA9
		public void update()
		{
			this.confirmPanel.update();
		}

		// Token: 0x06000BA1 RID: 2977 RVA: 0x000E5AE4 File Offset: 0x000E3CE4
		private void ConfirmPlayCardPopup_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseReason closeReason = e.CloseReason;
			if (closeReason == CloseReason.UserClosing && !this.closing)
			{
				this.closing = true;
				InterfaceMgr.Instance.closeConfirmPlayCardPopup();
			}
		}

		// Token: 0x04000FAF RID: 4015
		private bool closing;
	}
}
