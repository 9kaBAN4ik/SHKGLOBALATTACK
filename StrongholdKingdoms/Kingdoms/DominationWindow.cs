using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x0200019E RID: 414
	public partial class DominationWindow : MyFormBase
	{
		// Token: 0x06000FE1 RID: 4065 RVA: 0x00116B48 File Offset: 0x00114D48
		public DominationWindow()
		{
			this.InitializeComponent();
			this.closeCallback = new MyFormBase.MFBClose(this.domCloseCallback);
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.lblDuration.Font = FontManager.GetFont("Microsoft Sans Serif", 9f, FontStyle.Bold);
			this.Text = (base.Title = SK.Text("Domination_World", "Domination World"));
			this.btnClose.Text = SK.Text("GENERIC_Close", "Close");
			this.lblDominationInfo.Text = SK.Text("Domination_Info", "Domination World will end in");
			this.lblDuration.Text = "";
		}

		// Token: 0x06000FE2 RID: 4066 RVA: 0x000119CE File Offset: 0x0000FBCE
		public void updateText(string text)
		{
			this.lblDuration.Text = text;
		}

		// Token: 0x06000FE3 RID: 4067 RVA: 0x000119DC File Offset: 0x0000FBDC
		private void btnClose_Click(object sender, EventArgs e)
		{
			InterfaceMgr.Instance.closeDominatonWindow();
		}

		// Token: 0x06000FE4 RID: 4068 RVA: 0x000119DC File Offset: 0x0000FBDC
		private void domCloseCallback()
		{
			InterfaceMgr.Instance.closeDominatonWindow();
		}
	}
}
