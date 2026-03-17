using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x02000524 RID: 1316
	public partial class WorldSelectPopupWindow : Form
	{
		// Token: 0x060033CB RID: 13259 RVA: 0x00025173 File Offset: 0x00023373
		public WorldSelectPopupWindow()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x060033CC RID: 13260 RVA: 0x00025196 File Offset: 0x00023396
		public void init(int villageID, bool reset)
		{
			this.createPopupPanel.init(villageID, reset);
		}

		// Token: 0x060033CD RID: 13261 RVA: 0x000251A5 File Offset: 0x000233A5
		public void update()
		{
			this.createPopupPanel.update();
		}

		// Token: 0x060033CE RID: 13262 RVA: 0x002ABCA0 File Offset: 0x002A9EA0
		private void CreatePopupPanel_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseReason closeReason = e.CloseReason;
			if (closeReason == CloseReason.UserClosing && !this.closing)
			{
				this.closing = true;
				InterfaceMgr.Instance.closeWorldSelectPopupWindow();
			}
		}

		// Token: 0x040040BF RID: 16575
		private bool closing;
	}
}
