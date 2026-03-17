using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x02000211 RID: 529
	public partial class LoadingPanel : Form
	{
		// Token: 0x06001649 RID: 5705 RVA: 0x00017994 File Offset: 0x00015B94
		public LoadingPanel()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x0600164A RID: 5706 RVA: 0x000179B7 File Offset: 0x00015BB7
		public void init()
		{
			this.Text = SK.Text("LoadingPanel_Loading", "Loading Stronghold Kingdoms");
		}

		// Token: 0x0600164B RID: 5707 RVA: 0x001602D8 File Offset: 0x0015E4D8
		private void LoadingPanel_Load(object sender, EventArgs e)
		{
			Graphics graphics = base.CreateGraphics();
			FontManager.setDPI(graphics);
			graphics.Dispose();
		}
	}
}
