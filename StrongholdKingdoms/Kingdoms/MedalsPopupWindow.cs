using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x0200023E RID: 574
	public partial class MedalsPopupWindow : Form
	{
		// Token: 0x0600197F RID: 6527 RVA: 0x00019C71 File Offset: 0x00017E71
		public MedalsPopupWindow()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06001980 RID: 6528 RVA: 0x00198FF4 File Offset: 0x001971F4
		public void init(List<int> achievements, Form parent)
		{
			if (parent != null)
			{
				base.Location = new Point(parent.Location.X + (parent.Width - base.Width) / 2, parent.Location.Y + (parent.Height - base.Height) / 2);
			}
			this.medalsPopupPanel.init(achievements, this);
		}
	}
}
