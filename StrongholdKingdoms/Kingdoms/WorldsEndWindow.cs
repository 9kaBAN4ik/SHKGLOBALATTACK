using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x02000526 RID: 1318
	public partial class WorldsEndWindow : Form
	{
		// Token: 0x060033D9 RID: 13273 RVA: 0x00025217 File Offset: 0x00023417
		public WorldsEndWindow()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x060033DA RID: 13274 RVA: 0x002AE118 File Offset: 0x002AC318
		public void init()
		{
			this.customPanel.init(this);
			Form parentForm = InterfaceMgr.Instance.ParentForm;
			base.Location = new Point(parentForm.Location.X + parentForm.Width / 2 - base.Width / 2, parentForm.Location.Y + parentForm.Height / 2 - base.Height / 2);
		}

		// Token: 0x060033DB RID: 13275 RVA: 0x00025241 File Offset: 0x00023441
		public void update()
		{
			this.customPanel.update();
		}

		// Token: 0x060033DC RID: 13276 RVA: 0x0002524E File Offset: 0x0002344E
		public void closePopup()
		{
			this.customPanel.closePopup();
		}

		// Token: 0x060033DD RID: 13277 RVA: 0x002AE188 File Offset: 0x002AC388
		private void WorldsEndWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseReason closeReason = e.CloseReason;
			if (closeReason == CloseReason.UserClosing && !this.closing)
			{
				this.closing = true;
				GameEngine.Instance.closeNoVillagePopup(false);
				LoggingOutPopup.open(true, false, false, false, false, false, false, 0, 100, false, false, false, false, false, false, 500, 500, 500, 500, 250);
			}
		}

		// Token: 0x040040F8 RID: 16632
		private int lastMode = -1;

		// Token: 0x040040F9 RID: 16633
		public bool closing;
	}
}
