using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x020001D8 RID: 472
	public partial class FloatingInput : Form
	{
		// Token: 0x060011D1 RID: 4561 RVA: 0x00013652 File Offset: 0x00011852
		public FloatingInput()
		{
			this.InitializeComponent();
		}

		// Token: 0x060011D2 RID: 4562 RVA: 0x00013672 File Offset: 0x00011872
		public static void open(int x, int y, int startingValue, int maxV, Form parent)
		{
			FloatingInput.close();
			FloatingInput.Instance = new FloatingInput();
			FloatingInput.Instance.Location = new Point(x, y);
			FloatingInput.Instance.init(startingValue, maxV);
			FloatingInput.Instance.Show(parent);
		}

		// Token: 0x060011D3 RID: 4563 RVA: 0x0012C53C File Offset: 0x0012A73C
		public static void openDisband(int x, int y, int startingValue, int maxV, Form parent)
		{
			FloatingInput.close();
			FloatingInput.Instance = new FloatingInput();
			FloatingInput.Instance.Location = new Point(x, y);
			FloatingInput.Instance.MinimumSize = new Size(60, 19);
			FloatingInput.Instance.Size = new Size(60, 19);
			FloatingInput.Instance.MaximumSize = new Size(60, 19);
			FloatingInput.Instance.textBox1.BackColor = Color.FromArgb(74, 86, 92);
			FloatingInput.Instance.textBox1.ForeColor = global::ARGBColors.White;
			FloatingInput.Instance.BackColor = Color.FromArgb(74, 86, 92);
			FloatingInput.Instance.init(startingValue, maxV);
			FloatingInput.Instance.Show(parent);
		}

		// Token: 0x060011D4 RID: 4564 RVA: 0x000136AC File Offset: 0x000118AC
		public static void close()
		{
			if (FloatingInput.Instance != null)
			{
				FloatingInput.Instance.Close();
				FloatingInput.Instance = null;
			}
		}

		// Token: 0x060011D5 RID: 4565 RVA: 0x000136C5 File Offset: 0x000118C5
		public void init(int startingValue, int maxV)
		{
			if (startingValue > maxV)
			{
				startingValue = maxV;
			}
			if (startingValue < 0)
			{
				startingValue = 0;
			}
			this.maxValue = maxV;
			this.textBox1.Text = startingValue.ToString();
			this.lastString = this.textBox1.Text;
		}

		// Token: 0x060011D6 RID: 4566 RVA: 0x0012C600 File Offset: 0x0012A800
		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			if (this.inChange)
			{
				return;
			}
			this.inChange = true;
			string text = this.textBox1.Text;
			string text2 = "";
			string text3 = text;
			foreach (char c in text3)
			{
				if (char.IsDigit(c))
				{
					text2 += c.ToString();
				}
			}
			if (text != text2)
			{
				this.textBox1.Text = text2;
			}
			int int32FromString = this.getInt32FromString(this.textBox1.Text);
			if (int32FromString < 0 || int32FromString > this.maxValue)
			{
				int selectionStart = this.textBox1.SelectionStart;
				this.textBox1.Text = this.lastString;
				this.textBox1.SelectionStart = selectionStart;
			}
			else
			{
				this.lastString = this.textBox1.Text;
			}
			this.inChange = false;
		}

		// Token: 0x060011D7 RID: 4567 RVA: 0x0012C6E8 File Offset: 0x0012A8E8
		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				InterfaceMgr.Instance.closeTextInput(this.getInt32FromString(this.lastString));
				return;
			}
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		// Token: 0x060011D8 RID: 4568 RVA: 0x0012C738 File Offset: 0x0012A938
		public int getInt32FromString(string text)
		{
			if (text.Length == 0)
			{
				return 0;
			}
			try
			{
				return Convert.ToInt32(text);
			}
			catch (Exception)
			{
			}
			return 0;
		}

		// Token: 0x060011D9 RID: 4569 RVA: 0x000136FF File Offset: 0x000118FF
		private void FloatingInput_Deactivate(object sender, EventArgs e)
		{
			InterfaceMgr.Instance.closeTextInput(this.getInt32FromString(this.lastString));
		}

		// Token: 0x04001819 RID: 6169
		private static FloatingInput Instance;

		// Token: 0x0400181A RID: 6170
		private int maxValue = 1;

		// Token: 0x0400181B RID: 6171
		public string lastString = "";

		// Token: 0x0400181C RID: 6172
		private bool inChange;
	}
}
