using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x020004F9 RID: 1273
	public partial class WheelSelectPopup : Form
	{
		// Token: 0x06003059 RID: 12377 RVA: 0x0027D8DC File Offset: 0x0027BADC
		public WheelSelectPopup()
		{
			this.InitializeComponent();
			base.TransparencyKey = Color.FromArgb(255, 255, 0, 255);
			this.BackColor = base.TransparencyKey;
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x0600305A RID: 12378 RVA: 0x000232FE File Offset: 0x000214FE
		public void init()
		{
			this.wheelSelectPanel.init(true);
		}
	}
}
