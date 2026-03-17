using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x020001D9 RID: 473
	public partial class FloatingInputText : Form
	{
		// Token: 0x060011DC RID: 4572 RVA: 0x00013736 File Offset: 0x00011936
		public FloatingInputText()
		{
			this.InitializeComponent();
		}

		// Token: 0x060011DD RID: 4573 RVA: 0x0012C91C File Offset: 0x0012AB1C
		public static void open(int x, int y, string text, Form parent)
		{
			FloatingInputText.close();
			FloatingInputText.Instance = new FloatingInputText();
			FloatingInputText.Instance.Location = new Point(x, y);
			FloatingInputText.Instance.textBox1.Text = text;
			FloatingInputText.Instance.init();
			FloatingInputText.Instance.Show(parent);
		}

		// Token: 0x060011DE RID: 4574 RVA: 0x0012C970 File Offset: 0x0012AB70
		public static void openDisband(int x, int y, string text, Form parent)
		{
			FloatingInputText.close();
			FloatingInputText.Instance = new FloatingInputText();
			FloatingInputText.Instance.Location = new Point(x, y);
			FloatingInputText.Instance.MinimumSize = new Size(500, 19);
			FloatingInputText.Instance.Size = new Size(500, 19);
			FloatingInputText.Instance.MaximumSize = new Size(500, 19);
			FloatingInputText.Instance.textBox1.Text = text;
			FloatingInputText.Instance.textBox1.BackColor = Color.FromArgb(74, 86, 92);
			FloatingInputText.Instance.textBox1.ForeColor = global::ARGBColors.White;
			FloatingInputText.Instance.BackColor = Color.FromArgb(74, 86, 92);
			FloatingInputText.Instance.init();
			FloatingInputText.Instance.Show(parent);
		}

		// Token: 0x060011DF RID: 4575 RVA: 0x0001374F File Offset: 0x0001194F
		public static void close()
		{
			if (FloatingInputText.Instance != null)
			{
				FloatingInputText.Instance.Close();
				FloatingInputText.Instance = null;
			}
		}

		// Token: 0x060011E0 RID: 4576 RVA: 0x00013768 File Offset: 0x00011968
		public void init()
		{
			this.lastString = this.textBox1.Text;
		}

		// Token: 0x060011E1 RID: 4577 RVA: 0x0012CA48 File Offset: 0x0012AC48
		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			if (!this.inChange)
			{
				this.inChange = true;
				string text = this.textBox1.Text;
				string text2 = "";
				text2 += text;
				if (text != text2)
				{
					this.textBox1.Text = text2;
				}
				this.lastString = this.textBox1.Text;
				this.inChange = false;
			}
		}

		// Token: 0x060011E2 RID: 4578 RVA: 0x0012CAAC File Offset: 0x0012ACAC
		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				InterfaceMgr.Instance.closeTextStringInput(this.lastString);
				return;
			}
			if (this.textBox1.Text.Length >= 90 && !char.IsControl(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		// Token: 0x060011E3 RID: 4579 RVA: 0x0001377B File Offset: 0x0001197B
		private void FloatingInputText_Deactivate(object sender, EventArgs e)
		{
			InterfaceMgr.Instance.closeTextStringInput(this.lastString);
		}

		// Token: 0x0400181F RID: 6175
		private static FloatingInputText Instance;

		// Token: 0x04001820 RID: 6176
		public string lastString = "";

		// Token: 0x04001821 RID: 6177
		private bool inChange;
	}
}
