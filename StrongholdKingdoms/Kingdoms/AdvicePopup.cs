using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x020000BB RID: 187
	public partial class AdvicePopup : Form
	{
		// Token: 0x0600052A RID: 1322 RVA: 0x0000AC17 File Offset: 0x00008E17
		public AdvicePopup()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x0006366C File Offset: 0x0006186C
		public void init(Form parent, int screenID)
		{
			if (parent != null)
			{
				base.Location = new Point(parent.Location.X + (parent.Width - base.Width) / 2, parent.Location.Y + (parent.Height - base.Height) / 2);
			}
			this.customPanel.init(this, screenID);
		}
	}
}
