using System;
using System.Drawing;
using System.Windows.Forms;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x0200024C RID: 588
	public partial class MyMessageBoxPopUp : MyFormBase
	{
		// Token: 0x06001A12 RID: 6674 RVA: 0x0019C9D8 File Offset: 0x0019ABD8
		public MyMessageBoxPopUp()
		{
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			base.ClientSize = new Size(400, 125);
			this.panel = new MyMessageBoxPanel();
			this.panel.Size = new Size(base.Size.Width, base.Size.Height - 34);
			this.panel.Location = new Point(0, 34);
			base.Icon = Resources.shk_icon;
			base.StartPosition = FormStartPosition.CenterScreen;
			base.Controls.Add(this.panel);
			this.Text = "MessageBoxPopUp";
			base.Controls.SetChildIndex(this.panel, 0);
			base.ResumeLayout(false);
			base.PerformLayout();
			base.FormClosing += this.MyMessageBoxPopUps_FormClosing;
		}

		// Token: 0x06001A13 RID: 6675 RVA: 0x0019CAC0 File Offset: 0x0019ACC0
		public void init(string message, string title, int type, CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate leftButton, bool leaveGreaoutOpenOnClose)
		{
			base.Title = title;
			this.Text = title;
			this.panel.init(this, message, type, leftButton, leaveGreaoutOpenOnClose);
			if (leaveGreaoutOpenOnClose)
			{
				this.closing = true;
			}
		}

		// Token: 0x06001A14 RID: 6676 RVA: 0x0019CB00 File Offset: 0x0019AD00
		public void init(string message, string title, int type, CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate leftButton)
		{
			base.Title = title;
			this.Text = title;
			this.panel.init(this, message, type, leftButton, null);
		}

		// Token: 0x06001A15 RID: 6677 RVA: 0x0001A294 File Offset: 0x00018494
		public void setCustomYesText(string yesText)
		{
			this.panel.setCustomYesText(yesText);
		}

		// Token: 0x06001A16 RID: 6678 RVA: 0x0001A2A2 File Offset: 0x000184A2
		public void setCustomNoText(string noText)
		{
			this.panel.setCustomNoText(noText);
		}

		// Token: 0x06001A17 RID: 6679 RVA: 0x0019CB34 File Offset: 0x0019AD34
		private void MyMessageBoxPopUps_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseReason closeReason = e.CloseReason;
			if (closeReason == CloseReason.UserClosing && !this.closing)
			{
				this.closing = true;
				InterfaceMgr.Instance.closeGreyOut();
			}
		}

		// Token: 0x04002A8D RID: 10893
		private MyMessageBoxPanel panel;

		// Token: 0x04002A8E RID: 10894
		public bool closing;
	}
}
