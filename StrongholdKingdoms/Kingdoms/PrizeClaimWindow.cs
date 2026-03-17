using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x02000290 RID: 656
	public partial class PrizeClaimWindow : Form
	{
		// Token: 0x06001D3D RID: 7485 RVA: 0x0001C6AC File Offset: 0x0001A8AC
		public PrizeClaimWindow()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06001D3E RID: 7486 RVA: 0x001C706C File Offset: 0x001C526C
		public static void CreatePrizeClaimWindow()
		{
			InterfaceMgr.Instance.openGreyOutWindow(false);
			PrizeClaimWindow prizeClaimWindow = new PrizeClaimWindow();
			prizeClaimWindow.init();
			prizeClaimWindow.Show(InterfaceMgr.Instance.getGreyOutWindow());
		}

		// Token: 0x06001D3F RID: 7487 RVA: 0x001C70A4 File Offset: 0x001C52A4
		public void init()
		{
			PrizeClaimWindow.instance = this;
			this.customPanel.init(this);
			Form parentForm = InterfaceMgr.Instance.ParentForm;
			base.Location = new Point(parentForm.Location.X + parentForm.Width / 2 - base.Width / 2, parentForm.Location.Y + parentForm.Height / 2 - base.Height / 2);
		}

		// Token: 0x06001D40 RID: 7488 RVA: 0x001C711C File Offset: 0x001C531C
		public static void close()
		{
			try
			{
				if (PrizeClaimWindow.instance != null)
				{
					InterfaceMgr.Instance.closeGreyOut();
					PrizeClaimWindow.instance.Close();
					PrizeClaimWindow.instance = null;
				}
			}
			catch
			{
			}
		}

		// Token: 0x06001D41 RID: 7489 RVA: 0x0001C6CF File Offset: 0x0001A8CF
		private void PrizeClaimWindow_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (!this.inCloseForm)
			{
				this.inCloseForm = true;
				InterfaceMgr.Instance.closeGreyOut();
				this.inCloseForm = false;
			}
		}

		// Token: 0x04002E06 RID: 11782
		private static PrizeClaimWindow instance;

		// Token: 0x04002E07 RID: 11783
		private bool inCloseForm;
	}
}
