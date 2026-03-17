using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x020004F7 RID: 1271
	public partial class WheelPopup : Form
	{
		// Token: 0x0600304E RID: 12366 RVA: 0x0027C82C File Offset: 0x0027AA2C
		public WheelPopup()
		{
			this.InitializeComponent();
			base.TransparencyKey = Color.FromArgb(255, 255, 0, 255);
			this.BackColor = base.TransparencyKey;
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x0600304F RID: 12367 RVA: 0x00023255 File Offset: 0x00021455
		public void init(int wheelType)
		{
			this.wheelPanel.init(true, wheelType);
		}

		// Token: 0x06003050 RID: 12368 RVA: 0x00023264 File Offset: 0x00021464
		public void update()
		{
			this.wheelPanel.update();
		}
	}
}
