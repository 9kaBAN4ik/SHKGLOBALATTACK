using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x0200024A RID: 586
	public partial class MyMessageBox : Form
	{
		// Token: 0x060019F7 RID: 6647
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		// Token: 0x060019F8 RID: 6648
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		// Token: 0x060019F9 RID: 6649 RVA: 0x0001A187 File Offset: 0x00018387
		public static void setCustomSounds(string newOK, string newCancel)
		{
			MyMessageBox.customOKSound = newOK;
			MyMessageBox.customCancelSound = newCancel;
		}

		// Token: 0x060019FA RID: 6650 RVA: 0x0001A195 File Offset: 0x00018395
		public static void resetCustomSounds()
		{
			MyMessageBox.customCancelSound = "";
			MyMessageBox.customOKSound = "";
		}

		// Token: 0x060019FB RID: 6651 RVA: 0x0001A1AB File Offset: 0x000183AB
		public static void setForcedForm(Form form)
		{
			MyMessageBox.forcedForm = form;
		}

		// Token: 0x060019FC RID: 6652 RVA: 0x0019B9A8 File Offset: 0x00199BA8
		public MyMessageBox()
		{
			this.InitializeComponent();
			this.panel2.BackgroundImage = GFXLibrary.messageboxtop;
			this.lblTimer.Font = FontManager.GetFont("Arial", 9.75f, FontStyle.Bold);
			this.lblMessage.Font = FontManager.GetFont("Arial", 9.75f, FontStyle.Regular);
			this.lblTitle.Font = FontManager.GetFont("Arial", 9.75f, FontStyle.Bold);
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			Form parentForm = InterfaceMgr.Instance.ParentForm;
			if (parentForm != null && parentForm.WindowState != FormWindowState.Minimized)
			{
				Point location = parentForm.Location;
				Size size = parentForm.Size;
				Size size2 = base.Size;
				base.Location = new Point((size.Width - size2.Width) / 2 + location.X, (size.Height - size2.Height) / 2 + location.Y);
				return;
			}
			base.StartPosition = FormStartPosition.CenterScreen;
		}

		// Token: 0x060019FD RID: 6653 RVA: 0x0019BAB0 File Offset: 0x00199CB0
		public static DialogResult Show(string txtMessage)
		{
			MyMessageBox.newMessageBox = new MyMessageBox();
			MyMessageBox.buttons = MessageBoxButtons.OK;
			MyMessageBox.defaultButton = MessageBoxDefaultButton.Button1;
			MyMessageBox.newMessageBox.lblMessage.Text = txtMessage;
			Graphics graphics = MyMessageBox.newMessageBox.lblMessage.CreateGraphics();
			Size size = graphics.MeasureString(txtMessage, MyMessageBox.newMessageBox.lblMessage.Font, 335).ToSize();
			graphics.Dispose();
			int num = size.Height;
			if (num < 50)
			{
				num = 50;
			}
			MyMessageBox.newMessageBox.lblMessage.Size = new Size(335, num);
			MyMessageBox.newMessageBox.panel1.Size = MyMessageBox.newMessageBox.lblMessage.Size;
			MyMessageBox.newMessageBox.Size = new Size(MyMessageBox.newMessageBox.Size.Width, num + 142 - 58);
			bool flag = false;
			Form activeForm = Form.ActiveForm;
			if (MyMessageBox.forcedForm != null)
			{
				activeForm = MyMessageBox.forcedForm;
				flag = true;
				MyMessageBox.newMessageBox.StartPosition = FormStartPosition.CenterParent;
			}
			else if (activeForm != null && activeForm.ProductName == MyMessageBox.newMessageBox.ProductName && activeForm.WindowState == FormWindowState.Normal)
			{
				flag = true;
			}
			if (flag)
			{
				MyMessageBox.newMessageBox.ShowDialog(activeForm);
			}
			else
			{
				MyMessageBox.newMessageBox.ShowDialog();
			}
			MyMessageBox.newMessageBox.Dispose();
			MyMessageBox.forcedForm = null;
			if (activeForm != null && flag)
			{
				bool topMost = activeForm.TopMost;
				activeForm.TopMost = false;
				activeForm.TopMost = true;
				activeForm.Focus();
				activeForm.BringToFront();
				activeForm.Focus();
				activeForm.TopMost = topMost;
			}
			return MyMessageBox.result;
		}

		// Token: 0x060019FE RID: 6654 RVA: 0x0019BC54 File Offset: 0x00199E54
		public static DialogResult Show(string txtMessage, string txtTitle)
		{
			MyMessageBox.newMessageBox = new MyMessageBox();
			MyMessageBox.buttons = MessageBoxButtons.OK;
			MyMessageBox.defaultButton = MessageBoxDefaultButton.Button1;
			MyMessageBox.newMessageBox.lblTitle.Text = txtTitle;
			MyMessageBox.newMessageBox.lblMessage.Text = txtMessage;
			Graphics graphics = MyMessageBox.newMessageBox.lblMessage.CreateGraphics();
			Size size = graphics.MeasureString(txtMessage, MyMessageBox.newMessageBox.lblMessage.Font, 335).ToSize();
			graphics.Dispose();
			int num = size.Height + 3;
			if (num < 50)
			{
				num = 50;
			}
			MyMessageBox.newMessageBox.lblMessage.Size = new Size(335, num + 20);
			MyMessageBox.newMessageBox.panel1.Size = MyMessageBox.newMessageBox.lblMessage.Size;
			MyMessageBox.newMessageBox.Size = new Size(MyMessageBox.newMessageBox.Size.Width, num + 142 - 58);
			bool flag = false;
			Form activeForm = Form.ActiveForm;
			if (MyMessageBox.forcedForm != null)
			{
				activeForm = MyMessageBox.forcedForm;
				flag = true;
				MyMessageBox.newMessageBox.StartPosition = FormStartPosition.CenterParent;
			}
			else if (activeForm != null && activeForm.ProductName == MyMessageBox.newMessageBox.ProductName && activeForm.WindowState == FormWindowState.Normal)
			{
				flag = true;
			}
			if (flag)
			{
				MyMessageBox.newMessageBox.StartPosition = FormStartPosition.CenterParent;
				MyMessageBox.newMessageBox.ShowDialog(activeForm);
			}
			else
			{
				MyMessageBox.newMessageBox.ShowDialog();
			}
			MyMessageBox.newMessageBox.Dispose();
			MyMessageBox.forcedForm = null;
			if (activeForm != null && flag)
			{
				bool topMost = activeForm.TopMost;
				activeForm.TopMost = false;
				activeForm.TopMost = true;
				activeForm.Focus();
				activeForm.BringToFront();
				activeForm.Focus();
				activeForm.TopMost = topMost;
			}
			return MyMessageBox.result;
		}

		// Token: 0x060019FF RID: 6655 RVA: 0x0019BE18 File Offset: 0x0019A018
		public static DialogResult Show(string txtMessage, string txtTitle, MessageBoxButtons buts)
		{
			MyMessageBox.newMessageBox = new MyMessageBox();
			MyMessageBox.buttons = buts;
			MyMessageBox.defaultButton = MessageBoxDefaultButton.Button1;
			MyMessageBox.newMessageBox.lblTitle.Text = txtTitle;
			MyMessageBox.newMessageBox.lblMessage.Text = txtMessage;
			Graphics graphics = MyMessageBox.newMessageBox.lblMessage.CreateGraphics();
			Size size = graphics.MeasureString(txtMessage, MyMessageBox.newMessageBox.lblMessage.Font, 335).ToSize();
			graphics.Dispose();
			int num = size.Height;
			if (num < 50)
			{
				num = 50;
			}
			MyMessageBox.newMessageBox.lblMessage.Size = new Size(335, num + 20);
			MyMessageBox.newMessageBox.panel1.Size = MyMessageBox.newMessageBox.lblMessage.Size;
			MyMessageBox.newMessageBox.Size = new Size(MyMessageBox.newMessageBox.Size.Width, num + 142 - 58);
			bool flag = false;
			Form activeForm = Form.ActiveForm;
			if (MyMessageBox.forcedForm != null)
			{
				activeForm = MyMessageBox.forcedForm;
				flag = true;
				MyMessageBox.newMessageBox.StartPosition = FormStartPosition.CenterParent;
			}
			else if (activeForm != null && activeForm.ProductName == MyMessageBox.newMessageBox.ProductName && activeForm.WindowState == FormWindowState.Normal)
			{
				flag = true;
			}
			if (flag)
			{
				MyMessageBox.newMessageBox.ShowDialog(activeForm);
			}
			else
			{
				MyMessageBox.newMessageBox.ShowDialog();
			}
			MyMessageBox.newMessageBox.Dispose();
			MyMessageBox.forcedForm = null;
			if (activeForm != null && flag)
			{
				bool topMost = activeForm.TopMost;
				activeForm.TopMost = false;
				activeForm.TopMost = true;
				activeForm.Focus();
				activeForm.BringToFront();
				activeForm.Focus();
				activeForm.TopMost = topMost;
			}
			return MyMessageBox.result;
		}

		// Token: 0x06001A00 RID: 6656 RVA: 0x0019BFD0 File Offset: 0x0019A1D0
		public static DialogResult Show(string txtMessage, string txtTitle, MessageBoxButtons buts, MessageBoxIcon x1, MessageBoxDefaultButton defaultBut, int x2)
		{
			MyMessageBox.newMessageBox = new MyMessageBox();
			MyMessageBox.buttons = buts;
			MyMessageBox.defaultButton = defaultBut;
			MyMessageBox.newMessageBox.lblTitle.Text = txtTitle;
			MyMessageBox.newMessageBox.lblMessage.Text = txtMessage;
			Graphics graphics = MyMessageBox.newMessageBox.lblMessage.CreateGraphics();
			Size size = graphics.MeasureString(txtMessage, MyMessageBox.newMessageBox.lblMessage.Font, 335).ToSize();
			graphics.Dispose();
			int num = size.Height;
			if (num < 50)
			{
				num = 50;
			}
			MyMessageBox.newMessageBox.lblMessage.Size = new Size(335, num + 20);
			MyMessageBox.newMessageBox.panel1.Size = MyMessageBox.newMessageBox.lblMessage.Size;
			MyMessageBox.newMessageBox.Size = new Size(MyMessageBox.newMessageBox.Size.Width, num + 142 - 58);
			bool flag = false;
			Form activeForm = Form.ActiveForm;
			if (activeForm != null && activeForm.ProductName == MyMessageBox.newMessageBox.ProductName && activeForm.WindowState == FormWindowState.Normal)
			{
				flag = true;
			}
			if (flag)
			{
				MyMessageBox.newMessageBox.ShowDialog(activeForm);
			}
			else
			{
				MyMessageBox.newMessageBox.ShowDialog();
			}
			MyMessageBox.newMessageBox.Dispose();
			if (activeForm != null && flag)
			{
				bool topMost = activeForm.TopMost;
				activeForm.TopMost = false;
				activeForm.TopMost = true;
				activeForm.Focus();
				activeForm.BringToFront();
				activeForm.Focus();
				activeForm.TopMost = topMost;
			}
			return MyMessageBox.result;
		}

		// Token: 0x06001A01 RID: 6657 RVA: 0x0019C164 File Offset: 0x0019A364
		private void MyMessageBox_Load(object sender, EventArgs e)
		{
			if (MyMessageBox.buttons == MessageBoxButtons.OK)
			{
				this.btnCancel.Location = new Point(143, this.btnCancel.Location.Y);
				this.btnCancel.Text = SK.Text("GENERIC_OK", "OK");
				this.btnCancel.Visible = true;
				this.btnOK.Visible = false;
				this.btnCancel.TabIndex = 1;
				this.btnOK.TabIndex = 2;
				this.btnCancel.Focus();
			}
			if (MyMessageBox.buttons == MessageBoxButtons.YesNo)
			{
				this.btnCancel.Location = new Point(184, this.btnCancel.Location.Y);
				this.btnCancel.Text = SK.Text("GENERIC_No", "No");
				this.btnCancel.Visible = true;
				this.btnOK.Text = SK.Text("GENERIC_Yes", "Yes");
				this.btnOK.Visible = true;
				if (MyMessageBox.defaultButton == MessageBoxDefaultButton.Button1)
				{
					this.btnOK.TabIndex = 1;
					this.btnCancel.TabIndex = 2;
					this.btnOK.Focus();
				}
				else
				{
					this.btnOK.TabIndex = 2;
					this.btnCancel.TabIndex = 1;
					this.btnCancel.Focus();
				}
			}
			if (MyMessageBox.buttons == MessageBoxButtons.OKCancel)
			{
				this.btnCancel.Location = new Point(184, this.btnCancel.Location.Y);
				this.btnCancel.Text = SK.Text("GENERIC_Cancel", "Cancel");
				this.btnCancel.Visible = true;
				this.btnOK.Text = SK.Text("GENERIC_OK", "OK");
				this.btnOK.Visible = true;
				if (MyMessageBox.defaultButton == MessageBoxDefaultButton.Button1)
				{
					this.btnOK.TabIndex = 1;
					this.btnCancel.TabIndex = 2;
					this.btnOK.Focus();
					return;
				}
				this.btnOK.TabIndex = 2;
				this.btnCancel.TabIndex = 1;
				this.btnCancel.Focus();
			}
		}

		// Token: 0x06001A02 RID: 6658 RVA: 0x0019C398 File Offset: 0x0019A598
		private void MyMessageBox_Paint(object sender, PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			Pen pen = new Pen(Color.FromArgb(86, 98, 106), 1f);
			Rectangle rect = new Rectangle(1, 1, base.Width - 1 - 2, base.Height - 1 - 2);
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, Color.FromArgb(86, 98, 106), Color.FromArgb(159, 180, 193), LinearGradientMode.Vertical);
			graphics.FillRectangle(linearGradientBrush, rect);
			graphics.DrawRectangle(pen, rect);
			linearGradientBrush.Dispose();
			pen.Dispose();
		}

		// Token: 0x06001A03 RID: 6659 RVA: 0x0019C424 File Offset: 0x0019A624
		private void btnOK_Click(object sender, EventArgs e)
		{
			if (MyMessageBox.customOKSound.Length == 0)
			{
				GameEngine.Instance.playInterfaceSound("MyMessageBox_ok");
			}
			else
			{
				GameEngine.Instance.playInterfaceSound(MyMessageBox.customOKSound);
			}
			if (MyMessageBox.buttons == MessageBoxButtons.OKCancel)
			{
				MyMessageBox.result = DialogResult.OK;
			}
			if (MyMessageBox.buttons == MessageBoxButtons.YesNo)
			{
				MyMessageBox.result = DialogResult.Yes;
			}
			MyMessageBox.newMessageBox.Dispose();
		}

		// Token: 0x06001A04 RID: 6660 RVA: 0x0019C484 File Offset: 0x0019A684
		private void btnCancel_Click(object sender, EventArgs e)
		{
			if (MyMessageBox.customCancelSound.Length == 0)
			{
				GameEngine.Instance.playInterfaceSound("MyMessageBox_cancel");
			}
			else
			{
				GameEngine.Instance.playInterfaceSound(MyMessageBox.customCancelSound);
			}
			if (MyMessageBox.buttons == MessageBoxButtons.OK)
			{
				MyMessageBox.result = DialogResult.OK;
			}
			if (MyMessageBox.buttons == MessageBoxButtons.OKCancel)
			{
				MyMessageBox.result = DialogResult.Cancel;
			}
			if (MyMessageBox.buttons == MessageBoxButtons.YesNo)
			{
				MyMessageBox.result = DialogResult.No;
			}
			MyMessageBox.newMessageBox.Dispose();
		}

		// Token: 0x06001A05 RID: 6661 RVA: 0x0001A1B3 File Offset: 0x000183B3
		private void panel2_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				MyMessageBox.ReleaseCapture();
				MyMessageBox.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x06001A06 RID: 6662 RVA: 0x0001A1B3 File Offset: 0x000183B3
		private void lblTitle_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				MyMessageBox.ReleaseCapture();
				MyMessageBox.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x04002A68 RID: 10856
		public const int WM_NCLBUTTONDOWN = 161;

		// Token: 0x04002A69 RID: 10857
		public const int HT_CAPTION = 2;

		// Token: 0x04002A72 RID: 10866
		private static MyMessageBox newMessageBox;

		// Token: 0x04002A73 RID: 10867
		public Timer msgTimer;

		// Token: 0x04002A74 RID: 10868
		private static DialogResult result = DialogResult.OK;

		// Token: 0x04002A75 RID: 10869
		private static MessageBoxButtons buttons = MessageBoxButtons.OK;

		// Token: 0x04002A76 RID: 10870
		private static MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1;

		// Token: 0x04002A77 RID: 10871
		private static Form forcedForm = null;

		// Token: 0x04002A78 RID: 10872
		private static string customOKSound = "";

		// Token: 0x04002A79 RID: 10873
		private static string customCancelSound = "";
	}
}
