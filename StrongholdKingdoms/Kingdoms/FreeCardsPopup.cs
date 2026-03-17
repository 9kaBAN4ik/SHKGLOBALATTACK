using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x020001DE RID: 478
	public partial class FreeCardsPopup : Form
	{
		// Token: 0x0600122D RID: 4653 RVA: 0x00133244 File Offset: 0x00131444
		public FreeCardsPopup()
		{
			this.InitializeComponent();
			base.TransparencyKey = Color.FromArgb(255, 255, 0, 255);
			this.BackColor = base.TransparencyKey;
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x0600122E RID: 4654 RVA: 0x00013B8A File Offset: 0x00011D8A
		public void init()
		{
			this.freeCardsPanel.init(true);
		}

		// Token: 0x0600122F RID: 4655 RVA: 0x00013B98 File Offset: 0x00011D98
		public void update()
		{
			this.freeCardsPanel.update();
		}
	}
}
