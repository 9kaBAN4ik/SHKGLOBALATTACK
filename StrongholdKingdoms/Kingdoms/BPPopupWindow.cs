using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x020000E7 RID: 231
	public partial class BPPopupWindow : Form
	{
		// Token: 0x060006FE RID: 1790 RVA: 0x0000BC14 File Offset: 0x00009E14
		public BPPopupWindow()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x0000BC37 File Offset: 0x00009E37
		public void init(ProfileLoginWindow parent)
		{
			this.createPopupPanel.init(parent);
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x0000BC45 File Offset: 0x00009E45
		public void update()
		{
			this.createPopupPanel.update();
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x0000BC52 File Offset: 0x00009E52
		public void attempt1Failed()
		{
			this.createPopupPanel.attempt1Failed();
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x00090348 File Offset: 0x0008E548
		private void CreatePopupPanel_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseReason closeReason = e.CloseReason;
			if (closeReason == CloseReason.UserClosing && !this.closing)
			{
				this.closing = true;
				InterfaceMgr.Instance.closeBPPopupWindow();
			}
		}

		// Token: 0x0400093E RID: 2366
		private bool closing;
	}
}
