using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020002AE RID: 686
	public partial class RankFacebookPopup : MyFormBase
	{
		// Token: 0x06001EB8 RID: 7864 RVA: 0x0001D485 File Offset: 0x0001B685
		public RankFacebookPopup()
		{
			this.InitializeComponent();
			base.Title = SK.Text("FACEBOOK_SHARE_PACK", "Free Card Pack");
			this.customPanel.init(this);
		}

		// Token: 0x06001EB9 RID: 7865 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void closeFunction()
		{
		}
	}
}
