using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x020004BD RID: 1213
	public partial class VacationCancelPopupWindow : Form
	{
		// Token: 0x06002CCA RID: 11466 RVA: 0x00020D99 File Offset: 0x0001EF99
		public VacationCancelPopupWindow()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06002CCB RID: 11467 RVA: 0x00020DBC File Offset: 0x0001EFBC
		public void init(int secondsLeft, int secondsLeftToCancel, bool canCancel)
		{
			this.createPopupPanel.init(secondsLeft, secondsLeftToCancel, canCancel);
		}

		// Token: 0x06002CCC RID: 11468 RVA: 0x00020DCC File Offset: 0x0001EFCC
		public void update()
		{
			this.createPopupPanel.update();
		}

		// Token: 0x06002CCD RID: 11469 RVA: 0x0023B220 File Offset: 0x00239420
		private void CreatePopupPanel_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseReason closeReason = e.CloseReason;
			if (closeReason == CloseReason.UserClosing && !this.closing)
			{
				this.closing = true;
				InterfaceMgr.Instance.closeVacationCancelPopupWindow();
			}
		}

		// Token: 0x040037D5 RID: 14293
		private bool closing;
	}
}
