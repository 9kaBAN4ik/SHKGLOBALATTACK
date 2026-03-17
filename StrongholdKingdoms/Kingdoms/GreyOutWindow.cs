using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x020001EE RID: 494
	public partial class GreyOutWindow : Form
	{
		// Token: 0x060013B1 RID: 5041 RVA: 0x00015672 File Offset: 0x00013872
		public GreyOutWindow()
		{
			this.InitializeComponent();
		}

		// Token: 0x060013B2 RID: 5042 RVA: 0x00015680 File Offset: 0x00013880
		public void init(bool showBorder)
		{
			this.greyOutPanel.Visible = false;
		}

		// Token: 0x060013B3 RID: 5043 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void setInnerArea(Rectangle area)
		{
		}
	}
}
