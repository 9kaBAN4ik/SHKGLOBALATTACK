using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000113 RID: 275
	public partial class CastleCommitPopup : MyFormBase
	{
		// Token: 0x060008F2 RID: 2290 RVA: 0x0000D371 File Offset: 0x0000B571
		public CastleCommitPopup()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			base.ShowClose = false;
		}

		// Token: 0x060008F3 RID: 2291 RVA: 0x000BA4B4 File Offset: 0x000B86B4
		private void CastleCommitPopup_Load(object sender, EventArgs e)
		{
			this.label1.Text = SK.Text("CastleCommitPopup_Updating_Castle_Please_Wait", "Updating Castle, Please wait....");
			string text = this.Text = (base.Title = SK.Text("CastleCommitPopup_Updating_Castle", "Updating Castle"));
		}
	}
}
