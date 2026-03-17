using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x020000B9 RID: 185
	public partial class AdvancedCastleOptionsPopup : Form
	{
		// Token: 0x0600051B RID: 1307 RVA: 0x0000AB50 File Offset: 0x00008D50
		public AdvancedCastleOptionsPopup()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x0600051C RID: 1308 RVA: 0x0000AB73 File Offset: 0x00008D73
		public void init(bool castleSetup)
		{
			this.advancedCastleOptionsPanel.init(this, castleSetup);
		}

		// Token: 0x0600051D RID: 1309 RVA: 0x0000AB82 File Offset: 0x00008D82
		public void update()
		{
			this.advancedCastleOptionsPanel.update();
		}
	}
}
