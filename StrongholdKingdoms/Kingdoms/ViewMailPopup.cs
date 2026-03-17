using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x020004C9 RID: 1225
	public partial class ViewMailPopup : MyFormBase
	{
		// Token: 0x06002D56 RID: 11606 RVA: 0x0002156B File Offset: 0x0001F76B
		public ViewMailPopup()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.tbBody.Focus();
		}

		// Token: 0x06002D57 RID: 11607 RVA: 0x002402B8 File Offset: 0x0023E4B8
		public void init(MailScreen parent, string header, string body, string from, string date)
		{
			body = body.Replace("\r\n", "\n");
			body = body.Replace("\n", "\r\n");
			this.m_parent = parent;
			base.Title = SK.Text("MailScreen_Mail", "Mail");
			this.tbBody.Text = body;
			this.textBox2.Text = header;
			this.lblFromName.Text = from;
			this.lbDateValue.Text = date;
			this.lbFrom.Text = SK.Text("MailScreen_From", "From") + " :";
			this.lbDate.Text = SK.Text("MailScreen_Date", "Date") + " :";
			this.btnClose.Text = SK.Text("GENERIC_Close", "Close");
			this.btnCopySelected.Text = SK.Text("MailScreen_CopySelected", "Copy Selected");
			this.btnCopyClipboard.Text = SK.Text("MailScreen_CopyAll", "Copy All");
			this.tbBody.Focus();
		}

		// Token: 0x06002D58 RID: 11608 RVA: 0x00018F27 File Offset: 0x00017127
		private void btnClose_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("MailUserBlockPopup_close");
			base.Close();
		}

		// Token: 0x06002D59 RID: 11609 RVA: 0x002403DC File Offset: 0x0023E5DC
		private void btnCopyClipboard_Click(object sender, EventArgs e)
		{
			try
			{
				string text = this.tbBody.Text;
				Clipboard.SetText(text);
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06002D5A RID: 11610 RVA: 0x00240410 File Offset: 0x0023E610
		private void btnCopySelected_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.tbBody.SelectedText.Length > 0)
				{
					string selectedText = this.tbBody.SelectedText;
					Clipboard.SetText(selectedText);
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x04003858 RID: 14424
		private MailScreen m_parent;
	}
}
