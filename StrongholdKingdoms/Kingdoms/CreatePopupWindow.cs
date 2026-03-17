using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x02000157 RID: 343
	public partial class CreatePopupWindow : Form
	{
		// Token: 0x06000CE2 RID: 3298 RVA: 0x0000F954 File Offset: 0x0000DB54
		public CreatePopupWindow()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06000CE3 RID: 3299 RVA: 0x0000F977 File Offset: 0x0000DB77
		public void init()
		{
			this.createPopupPanel.init(true);
		}

		// Token: 0x06000CE4 RID: 3300 RVA: 0x0000F985 File Offset: 0x0000DB85
		public void update()
		{
			this.createPopupPanel.update();
		}

		// Token: 0x06000CE5 RID: 3301 RVA: 0x000F5344 File Offset: 0x000F3544
		private void CreatePopupPanel_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseReason closeReason = e.CloseReason;
			if (closeReason == CloseReason.UserClosing && !this.closing)
			{
				this.closing = true;
				InterfaceMgr.Instance.closeCreatePopupWindow();
			}
		}

		// Token: 0x0400112F RID: 4399
		private bool closing;
	}
}
