using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x020001EC RID: 492
	public partial class GloryVictoryWindow : Form
	{
		// Token: 0x060013A4 RID: 5028 RVA: 0x000155AE File Offset: 0x000137AE
		public GloryVictoryWindow()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x060013A5 RID: 5029 RVA: 0x0014F6A8 File Offset: 0x0014D8A8
		public void init(Form parent)
		{
			if (parent != null)
			{
				base.Location = new Point(parent.Location.X + (parent.Width - base.Width) / 2, parent.Location.Y + (parent.Height - base.Height) / 2);
			}
			this.gloryVictoryPanel.init(this);
		}

		// Token: 0x060013A6 RID: 5030 RVA: 0x0014F70C File Offset: 0x0014D90C
		public void initValues(Form parent)
		{
			if (parent != null)
			{
				base.Location = new Point(parent.Location.X + (parent.Width - base.Width) / 2, parent.Location.Y + (parent.Height - base.Height) / 2);
			}
			this.gloryVictoryPanel.initValues(this);
		}
	}
}
