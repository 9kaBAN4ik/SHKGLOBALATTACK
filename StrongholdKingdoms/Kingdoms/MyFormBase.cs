using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x02000248 RID: 584
	[ComVisible(true)]
	[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
	public partial class MyFormBase : Form
	{
		// Token: 0x170001D9 RID: 473
		// (set) Token: 0x060019CF RID: 6607 RVA: 0x00019F5F File Offset: 0x0001815F
		public string Title
		{
			set
			{
				this.lblTitle.Text = value;
			}
		}

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x060019D0 RID: 6608 RVA: 0x00019F6D File Offset: 0x0001816D
		// (set) Token: 0x060019D1 RID: 6609 RVA: 0x00019F7A File Offset: 0x0001817A
		public bool ShowClose
		{
			get
			{
				return this.panel1.Visible;
			}
			set
			{
				this.panel1.Visible = value;
			}
		}

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x060019D2 RID: 6610 RVA: 0x00019F88 File Offset: 0x00018188
		// (set) Token: 0x060019D3 RID: 6611 RVA: 0x00019F95 File Offset: 0x00018195
		public bool ShowBar
		{
			get
			{
				return this.panel2.Visible;
			}
			set
			{
				this.panel2.Visible = value;
			}
		}

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x060019D4 RID: 6612 RVA: 0x00019FA3 File Offset: 0x000181A3
		// (set) Token: 0x060019D5 RID: 6613 RVA: 0x00019FAB File Offset: 0x000181AB
		public bool Resizable
		{
			get
			{
				return this.resizable;
			}
			set
			{
				this.resizable = value;
			}
		}

		// Token: 0x060019D6 RID: 6614
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		// Token: 0x060019D7 RID: 6615
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		// Token: 0x060019D8 RID: 6616 RVA: 0x0019A9AC File Offset: 0x00198BAC
		public MyFormBase()
		{
			this.InitializeComponent();
			try
			{
				this.panel1.BackgroundImage = GFXLibrary.messageboxclose;
				this.panel3.BackgroundImage = GFXLibrary.message_box_maximize_normal;
				this.panel4.BackgroundImage = GFXLibrary.message_box_minimize_normal;
				this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
				this.lblTitle.Font = FontManager.GetFont("Microsoft Sans Serif", 9.75f, FontStyle.Bold);
				Form parentForm = InterfaceMgr.Instance.ParentForm;
				if (parentForm != null && parentForm.WindowState != FormWindowState.Minimized)
				{
					Point location = parentForm.Location;
					Size size = parentForm.Size;
					Size size2 = base.Size;
					Point point = base.Location = new Point((size.Width - size2.Width) / 2 + location.X, (size.Height - size2.Height) / 2 + location.Y);
				}
				else
				{
					base.StartPosition = FormStartPosition.CenterScreen;
				}
			}
			catch (Exception)
			{
				UniversalDebugLog.Log("An exception occurred in myformbase constructor");
			}
		}

		// Token: 0x060019D9 RID: 6617 RVA: 0x00019FB4 File Offset: 0x000181B4
		public void setGradient(Color top, Color bottom)
		{
			this.topColor = top;
			this.bottomColor = bottom;
		}

		// Token: 0x060019DA RID: 6618 RVA: 0x00019FC4 File Offset: 0x000181C4
		public void showMinMax()
		{
			this.panel3.Visible = true;
			this.panel4.Visible = true;
		}

		// Token: 0x060019DB RID: 6619 RVA: 0x0019AB00 File Offset: 0x00198D00
		private void MyFormBase_Paint(object sender, PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			Pen pen = new Pen(Color.FromArgb(86, 98, 106), 1f);
			Rectangle rect = new Rectangle(1, 1, base.Width - 1 - 2, base.Height - 1 - 2);
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, this.topColor, this.bottomColor, LinearGradientMode.Vertical);
			graphics.FillRectangle(linearGradientBrush, rect);
			graphics.DrawRectangle(pen, rect);
			if (this.resizable)
			{
				Rectangle bounds = new Rectangle(base.ClientSize.Width - 16, base.ClientSize.Height - 16, 16, 16);
				ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, bounds);
			}
			linearGradientBrush.Dispose();
			pen.Dispose();
		}

		// Token: 0x060019DC RID: 6620 RVA: 0x00019FDE File Offset: 0x000181DE
		private void panel2_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				MyFormBase.ReleaseCapture();
				MyFormBase.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x060019DD RID: 6621 RVA: 0x00019FDE File Offset: 0x000181DE
		private void lblTitle_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				MyFormBase.ReleaseCapture();
				MyFormBase.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x060019DE RID: 6622 RVA: 0x0001A006 File Offset: 0x00018206
		private void panel1_MouseClick(object sender, MouseEventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("MyFormBase_close");
			if (this.closeCallback != null)
			{
				this.closeCallback();
			}
			base.Close();
		}

		// Token: 0x060019DF RID: 6623 RVA: 0x0001A030 File Offset: 0x00018230
		private void panel1_MouseEnter(object sender, EventArgs e)
		{
			this.panel1.BackgroundImage = GFXLibrary.messageboxclose_over;
		}

		// Token: 0x060019E0 RID: 6624 RVA: 0x0001A047 File Offset: 0x00018247
		private void panel1_MouseLeave(object sender, EventArgs e)
		{
			this.panel1.BackgroundImage = GFXLibrary.messageboxclose;
		}

		// Token: 0x060019E1 RID: 6625 RVA: 0x0019ABC4 File Offset: 0x00198DC4
		private void panel2_SizeChanged(object sender, EventArgs e)
		{
			if (!this.inSizeChanged && !this.rightResize)
			{
				this.inSizeChanged = true;
				this.panel2.Width = base.Width - 2;
				this.panel2.init(this.panel2.Width);
				if (base.WindowState != FormWindowState.Minimized)
				{
					this.panel1.Location = new Point(this.panel2.Width - 28, this.panel1.Location.Y);
					this.panel3.Location = new Point(this.panel2.Width - 28 - 24, this.panel3.Location.Y);
					this.panel4.Location = new Point(this.panel2.Width - 28 - 48, this.panel4.Location.Y);
				}
				this.inSizeChanged = false;
			}
		}

		// Token: 0x060019E2 RID: 6626 RVA: 0x0001A05E File Offset: 0x0001825E
		private void panel4_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("MyFormBase_minimized");
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x060019E3 RID: 6627 RVA: 0x0001A076 File Offset: 0x00018276
		private void panel3_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("MyFormBase_maximized");
			if (base.WindowState != FormWindowState.Maximized)
			{
				base.WindowState = FormWindowState.Maximized;
				return;
			}
			base.WindowState = FormWindowState.Normal;
		}

		// Token: 0x060019E4 RID: 6628 RVA: 0x0019ACC4 File Offset: 0x00198EC4
		private void ucRightResize_MouseDown(object sender, MouseEventArgs e)
		{
			if (!this.rightResize)
			{
				this.rightResize = true;
				this.resizeOrig = base.Size;
				this.lastWidth = -1;
				this.RESIZESTART = base.PointToScreen(new Point(e.X, e.Y));
			}
		}

		// Token: 0x060019E5 RID: 6629 RVA: 0x0001A09F File Offset: 0x0001829F
		private void ucRightResize_MouseUp(object sender, MouseEventArgs e)
		{
			this.rightResize = false;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060019E6 RID: 6630 RVA: 0x0019AD10 File Offset: 0x00198F10
		private void ucRightResize_MouseMove(object sender, MouseEventArgs e)
		{
			Point point = base.PointToScreen(new Point(e.X, e.Y));
			if (this.rightResize)
			{
				int num = this.resizeOrig.Width + (point.X - this.RESIZESTART.X);
				if (num != this.lastWidth)
				{
					base.Size = new Size(num, base.Height);
					this.lastWidth = num;
					base.Invalidate();
					this.Title = num.ToString();
				}
			}
			if (this.rightResize)
			{
				this.Cursor = Cursors.SizeWE;
			}
		}

		// Token: 0x060019E7 RID: 6631 RVA: 0x0001A0B3 File Offset: 0x000182B3
		private void ucRightResize_MouseEnter(object sender, EventArgs e)
		{
			if (!this.rightResize)
			{
				this.Cursor = Cursors.SizeWE;
			}
		}

		// Token: 0x060019E8 RID: 6632 RVA: 0x0001A0C8 File Offset: 0x000182C8
		private void ucRightResize_MouseLeave(object sender, EventArgs e)
		{
			if (!this.rightResize)
			{
				this.Cursor = Cursors.Default;
			}
		}

		// Token: 0x060019E9 RID: 6633 RVA: 0x0001A0DD File Offset: 0x000182DD
		private void panel3_MouseEnter(object sender, EventArgs e)
		{
			this.panel3.BackgroundImage = GFXLibrary.message_box_maximize_over;
		}

		// Token: 0x060019EA RID: 6634 RVA: 0x0001A0F4 File Offset: 0x000182F4
		private void panel3_MouseLeave(object sender, EventArgs e)
		{
			this.panel3.BackgroundImage = GFXLibrary.message_box_maximize_normal;
		}

		// Token: 0x060019EB RID: 6635 RVA: 0x0001A10B File Offset: 0x0001830B
		private void panel4_MouseLeave(object sender, EventArgs e)
		{
			this.panel4.BackgroundImage = GFXLibrary.message_box_minimize_normal;
		}

		// Token: 0x060019EC RID: 6636 RVA: 0x0001A122 File Offset: 0x00018322
		private void panel4_MouseEnter(object sender, EventArgs e)
		{
			this.panel4.BackgroundImage = GFXLibrary.message_box_minimize_over;
		}

		// Token: 0x060019ED RID: 6637 RVA: 0x0019ADA8 File Offset: 0x00198FA8
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 132 && this.resizable)
			{
				Point p = new Point(m.LParam.ToInt32() & 65535, m.LParam.ToInt32() >> 16);
				p = base.PointToClient(p);
				if (p.X >= base.ClientSize.Width - 16 && p.Y >= base.ClientSize.Height - 16)
				{
					m.Result = (IntPtr)17;
					return;
				}
				if (p.X >= base.ClientSize.Width - 4)
				{
					m.Result = (IntPtr)11;
					return;
				}
				if (p.Y >= base.ClientSize.Height - 4)
				{
					m.Result = (IntPtr)15;
					return;
				}
			}
			base.WndProc(ref m);
		}

		// Token: 0x060019EE RID: 6638 RVA: 0x0001A139 File Offset: 0x00018339
		private void MyFormBase_SizeChanged(object sender, EventArgs e)
		{
			if (this.resizable)
			{
				base.Invalidate();
			}
		}

		// Token: 0x04002A54 RID: 10836
		public const int WM_NCLBUTTONDOWN = 161;

		// Token: 0x04002A55 RID: 10837
		public const int HT_CAPTION = 2;

		// Token: 0x04002A56 RID: 10838
		private const int cGrip = 16;

		// Token: 0x04002A57 RID: 10839
		private const int cCaption = 25;

		// Token: 0x04002A58 RID: 10840
		private Color topColor = Color.FromArgb(86, 98, 106);

		// Token: 0x04002A59 RID: 10841
		private Color bottomColor = Color.FromArgb(159, 180, 193);

		// Token: 0x04002A5A RID: 10842
		public MyFormBase.MFBClose closeCallback;

		// Token: 0x04002A5B RID: 10843
		private bool inSizeChanged;

		// Token: 0x04002A5C RID: 10844
		private bool rightResize;

		// Token: 0x04002A5D RID: 10845
		private Point RESIZESTART;

		// Token: 0x04002A5E RID: 10846
		private Size resizeOrig;

		// Token: 0x04002A5F RID: 10847
		private int lastWidth = -1;

		// Token: 0x04002A60 RID: 10848
		private bool resizable;

		// Token: 0x02000249 RID: 585
		// (Invoke) Token: 0x060019F2 RID: 6642
		public delegate void MFBClose();
	}
}
