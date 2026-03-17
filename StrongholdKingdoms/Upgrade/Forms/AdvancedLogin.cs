using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Kingdoms;
using Properties;

namespace Upgrade.Forms
{
	// Token: 0x020000AF RID: 175
	public partial class AdvancedLogin : Form
	{
		// Token: 0x06000476 RID: 1142 RVA: 0x0005D1B0 File Offset: 0x0005B3B0
		public AdvancedLogin(TextBox email, TextBox password, CustomSelfDrawPanel.CSDLabel connectionInfo, GetMAC getMAC)
		{
			this.InitializeComponent();
			this.checkBox_ShowOnStartup.Checked = Settings.Default.ShowAdvancedLoginOptions;
			this._email = email;
			this._password = password;
			this._getMAC = getMAC;
			this._connectionInfo = connectionInfo;
			this.AutoLoad();
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x0005D204 File Offset: 0x0005B404
		private void button_test_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.textBox_MAC.Text) && this.textBox_MAC.Text.Length != 12)
			{
				MessageBox.Show("MAC Address is invalid");
			}
			else
			{
				DX.OverrideMAC = this.textBox_MAC.Text;
			}
			WebRequest webRequest = WebRequest.Create("http://icanhazip.com/");
			if (!string.IsNullOrEmpty(this.textBox_proxyIP.Text) && !string.IsNullOrEmpty(this.textBox_proxyPort.Text))
			{
				WebProxy webProxy = new WebProxy(this.textBox_proxyIP.Text, int.Parse(this.textBox_proxyPort.Text));
				if (!string.IsNullOrEmpty(this.textBox_proxyUser.Text) && !string.IsNullOrEmpty(this.textBox_proxyPass.Text))
				{
					webProxy.Credentials = new NetworkCredential(this.textBox_proxyUser.Text, this.textBox_proxyPass.Text);
				}
				webRequest.Proxy = webProxy;
			}
			string str = string.Empty;
			using (WebResponse response = webRequest.GetResponse())
			{
				using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
				{
					str = streamReader.ReadToEnd();
				}
			}
			MessageBox.Show("IP: " + str + " MAC: " + this._getMAC());
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x0005D368 File Offset: 0x0005B568
		private void button_apply_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.textBox_proxyIP.Text) && !string.IsNullOrEmpty(this.textBox_proxyPort.Text))
			{
				WebProxy webProxy = new WebProxy(this.textBox_proxyIP.Text, int.Parse(this.textBox_proxyPort.Text));
				if (!string.IsNullOrEmpty(this.textBox_proxyUser.Text) && !string.IsNullOrEmpty(this.textBox_proxyPass.Text))
				{
					webProxy.Credentials = new NetworkCredential(this.textBox_proxyUser.Text, this.textBox_proxyPass.Text);
				}
				WebRequest.DefaultWebProxy = webProxy;
			}
			this._email.Text = this.textBox_email.Text;
			this._password.Text = this.textBox_password.Text;
			DX.OverrideMAC = this.textBox_MAC.Text;
			this._connectionInfo.Text = DX.GetConnectionInfo(this._getMAC());
			base.Close();
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x0005D464 File Offset: 0x0005B664
		private void button_save_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			if (saveFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			File.WriteAllLines(saveFileDialog.FileName, new string[]
			{
				this.textBox_email.Text,
				this.textBox_password.Text,
				this.textBox_MAC.Text,
				this.textBox_proxyIP.Text,
				this.textBox_proxyPort.Text,
				this.textBox_proxyUser.Text,
				this.textBox_proxyPass.Text
			});
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x0005D4F4 File Offset: 0x0005B6F4
		private void button_load_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			this.LoadOption(openFileDialog.FileName);
			Settings.Default.LastLoadedAdvancedLogin = openFileDialog.FileName;
			Settings.Default.Save();
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x0005D538 File Offset: 0x0005B738
		private void AutoLoad()
		{
			try
			{
				string lastLoadedAdvancedLogin = Settings.Default.LastLoadedAdvancedLogin;
				if (File.Exists(lastLoadedAdvancedLogin))
				{
					this.LoadOption(lastLoadedAdvancedLogin);
				}
			}
			catch (Exception ex)
			{
				DX.ShowErrorMessage(ex);
			}
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x0005D57C File Offset: 0x0005B77C
		private void LoadOption(string filename)
		{
			List<string> list = File.ReadAllLines(filename).ToList<string>();
			if (list.Count < 7)
			{
				for (int i = 0; i < 7 - list.Count; i++)
				{
					list.Add(string.Empty);
				}
			}
			this.textBox_email.Text = list[0];
			this.textBox_password.Text = list[1];
			this.textBox_MAC.Text = list[2];
			this.textBox_proxyIP.Text = list[3];
			this.textBox_proxyPort.Text = list[4];
			this.textBox_proxyUser.Text = list[5];
			this.textBox_proxyPass.Text = list[6];
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x0005D63C File Offset: 0x0005B83C
		private void textBox_MAC_TextChanged(object sender, EventArgs e)
		{
			this.textBox_MAC.Text = this.textBox_MAC.Text.Replace("-", "").Replace(":", "").ToUpper();
			this.textBox_MAC.SelectionStart = this.textBox_MAC.Text.Length;
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x0000A1FB File Offset: 0x000083FB
		private void checkBox_ShowOnStartup_CheckedChanged(object sender, EventArgs e)
		{
			Settings.Default.ShowAdvancedLoginOptions = this.checkBox_ShowOnStartup.Checked;
			Settings.Default.Save();
		}

		// Token: 0x04000583 RID: 1411
		private TextBox _email;

		// Token: 0x04000584 RID: 1412
		private TextBox _password;

		// Token: 0x04000585 RID: 1413
		private GetMAC _getMAC;

		// Token: 0x04000586 RID: 1414
		private CustomSelfDrawPanel.CSDLabel _connectionInfo;
	}
}
