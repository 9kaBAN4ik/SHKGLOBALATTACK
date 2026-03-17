using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x02000251 RID: 593
	public partial class NewAutoSelectVillageWindow : Form
	{
		// Token: 0x06001A30 RID: 6704 RVA: 0x0001A3BF File Offset: 0x000185BF
		public NewAutoSelectVillageWindow()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06001A31 RID: 6705 RVA: 0x0019E66C File Offset: 0x0019C86C
		public void init(int countyToJoin)
		{
			this.customPanel.init(countyToJoin, this);
			Form parentForm = InterfaceMgr.Instance.ParentForm;
			base.Location = new Point(parentForm.Location.X + parentForm.Width / 2 - base.Width / 2, parentForm.Location.Y + parentForm.Height / 2 - base.Height / 2);
		}

		// Token: 0x06001A32 RID: 6706 RVA: 0x0001A3E2 File Offset: 0x000185E2
		public void update()
		{
			this.customPanel.update();
		}

		// Token: 0x06001A33 RID: 6707 RVA: 0x0001A3EF File Offset: 0x000185EF
		public void closePopup()
		{
			this.customPanel.closePopup();
		}

		// Token: 0x06001A34 RID: 6708 RVA: 0x0019E6DC File Offset: 0x0019C8DC
		private void NewAutoSelectVillageWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseReason closeReason = e.CloseReason;
			if (closeReason == CloseReason.UserClosing && !this.closing)
			{
				this.closing = true;
				GameEngine.Instance.closeNoVillagePopup(false);
				LoggingOutPopup.open(true, false, false, false, false, false, false, 0, 100, false, false, false, false, false, false, 500, 500, 500, 500, 250);
			}
		}

		// Token: 0x04002AEE RID: 10990
		public bool closing;
	}
}
