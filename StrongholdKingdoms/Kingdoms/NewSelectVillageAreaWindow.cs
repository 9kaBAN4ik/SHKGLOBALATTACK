using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x0200025C RID: 604
	public partial class NewSelectVillageAreaWindow : Form
	{
		// Token: 0x06001A9B RID: 6811 RVA: 0x0001A9AB File Offset: 0x00018BAB
		public NewSelectVillageAreaWindow()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06001A9C RID: 6812 RVA: 0x001A5024 File Offset: 0x001A3224
		public void init(int tryingToJoinCounty)
		{
			this.customPanel.init(tryingToJoinCounty, this);
			Form parentForm = InterfaceMgr.Instance.ParentForm;
			base.Location = new Point(parentForm.Location.X + parentForm.Width / 2 - base.Width / 2, parentForm.Location.Y + parentForm.Height / 2 - base.Height / 2);
		}

		// Token: 0x06001A9D RID: 6813 RVA: 0x0001A9CE File Offset: 0x00018BCE
		public void update()
		{
			this.customPanel.update();
		}

		// Token: 0x06001A9E RID: 6814 RVA: 0x0001A9DB File Offset: 0x00018BDB
		public void closePopup()
		{
			this.customPanel.closePopup();
		}

		// Token: 0x06001A9F RID: 6815 RVA: 0x001A5094 File Offset: 0x001A3294
		private void NewSelectVillageAreaWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseReason closeReason = e.CloseReason;
			if (closeReason == CloseReason.UserClosing && !this.closing)
			{
				this.closing = true;
				GameEngine.Instance.closeNoVillagePopup(false);
				LoggingOutPopup.open(true, false, false, false, false, false, false, 0, 100, false, false, false, false, false, false, 500, 500, 500, 500, 250);
			}
		}

		// Token: 0x04002B73 RID: 11123
		public bool closing;
	}
}
