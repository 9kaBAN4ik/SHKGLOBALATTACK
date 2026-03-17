using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x0200046F RID: 1135
	public partial class ReportCapturePopup : Form
	{
		// Token: 0x060028EE RID: 10478 RVA: 0x0001E31A File Offset: 0x0001C51A
		public ReportCapturePopup()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x060028EF RID: 10479 RVA: 0x001F2A24 File Offset: 0x001F0C24
		public void init(int mode)
		{
			this.m_mode = mode;
			if (mode <= 1)
			{
				this.reportCapturePanel.Visible = true;
				this.reportDeletePanel.Visible = false;
				this.reportCapturePanel.init(mode, this);
				return;
			}
			if (mode != 2)
			{
				return;
			}
			this.reportDeletePanel.Visible = true;
			this.reportCapturePanel.Visible = false;
			this.reportDeletePanel.init(mode, this);
		}

		// Token: 0x060028F0 RID: 10480 RVA: 0x0001E33D File Offset: 0x0001C53D
		public void update()
		{
			if (this.m_mode == 0 || this.m_mode == 1)
			{
				this.reportCapturePanel.update();
				return;
			}
			if (this.m_mode == 2)
			{
				this.reportDeletePanel.update();
			}
		}

		// Token: 0x0400321A RID: 12826
		private int m_mode;
	}
}
