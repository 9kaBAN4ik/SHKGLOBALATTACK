using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020000D5 RID: 213
	public partial class AttackTargetsPopup : MyFormBase
	{
		// Token: 0x06000615 RID: 1557 RVA: 0x0000B3DA File Offset: 0x000095DA
		public AttackTargetsPopup()
		{
			this.InitializeComponent();
			base.Title = SK.Text("Attack_Targets", "Attack Targets");
			this.customPanel.init(this);
		}

		// Token: 0x06000616 RID: 1558 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void closeFunction()
		{
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x00079FBC File Offset: 0x000781BC
		private void AttackTargetsPoup_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseReason closeReason = e.CloseReason;
			if (closeReason == CloseReason.UserClosing && !this.closing)
			{
				this.closing = true;
				InterfaceMgr.Instance.closeAttackTargetsPopup();
			}
		}

		// Token: 0x040007BA RID: 1978
		private bool closing;
	}
}
