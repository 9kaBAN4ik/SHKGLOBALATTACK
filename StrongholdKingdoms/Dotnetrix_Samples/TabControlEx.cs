using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Dotnetrix_Samples
{
	// Token: 0x02000536 RID: 1334
	public class TabControlEx : TabControl
	{
		// Token: 0x170006B8 RID: 1720
		// (get) Token: 0x060037FB RID: 14331 RVA: 0x00025488 File Offset: 0x00023688
		// (set) Token: 0x060037FC RID: 14332 RVA: 0x000254C7 File Offset: 0x000236C7
		[Description("The background color used to display text and graphics in a control.")]
		[Browsable(true)]
		public override Color BackColor
		{
			get
			{
				if (!this.m_Backcolor.Equals(Color.Empty))
				{
					return this.m_Backcolor;
				}
				if (base.Parent == null)
				{
					return Control.DefaultBackColor;
				}
				return base.Parent.BackColor;
			}
			set
			{
				if (!this.m_Backcolor.Equals(value))
				{
					this.m_Backcolor = value;
					base.Invalidate();
					base.OnBackColorChanged(EventArgs.Empty);
				}
			}
		}

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x060037FD RID: 14333 RVA: 0x002B7FFC File Offset: 0x002B61FC
		// (remove) Token: 0x060037FE RID: 14334 RVA: 0x002B8034 File Offset: 0x002B6234
		[Description("Occurs as a tab is being changed.")]
		public event SelectedTabPageChangeEventHandler SelectedIndexChanging;

		// Token: 0x060037FF RID: 14335 RVA: 0x000254FA File Offset: 0x000236FA
		public TabControlEx()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
		}

		// Token: 0x06003800 RID: 14336 RVA: 0x0002551F File Offset: 0x0002371F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06003801 RID: 14337 RVA: 0x0002553E File Offset: 0x0002373E
		private void InitializeComponent()
		{
			this.components = new Container();
		}

		// Token: 0x06003802 RID: 14338 RVA: 0x0002554B File Offset: 0x0002374B
		public bool ShouldSerializeBackColor()
		{
			return !this.m_Backcolor.Equals(Color.Empty);
		}

		// Token: 0x06003803 RID: 14339 RVA: 0x0002556B File Offset: 0x0002376B
		public override void ResetBackColor()
		{
			this.m_Backcolor = Color.Empty;
			base.Invalidate();
		}

		// Token: 0x06003804 RID: 14340 RVA: 0x0002557E File Offset: 0x0002377E
		protected override void OnParentBackColorChanged(EventArgs e)
		{
			base.OnParentBackColorChanged(e);
			base.Invalidate();
		}

		// Token: 0x06003805 RID: 14341 RVA: 0x0002558D File Offset: 0x0002378D
		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			base.OnSelectedIndexChanged(e);
			base.Invalidate();
		}

		// Token: 0x06003806 RID: 14342 RVA: 0x002B806C File Offset: 0x002B626C
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			e.Graphics.Clear(this.BackColor);
			Rectangle rectangle = base.ClientRectangle;
			if (base.TabCount <= 0)
			{
				return;
			}
			rectangle = base.SelectedTab.Bounds;
			StringFormat stringFormat = new StringFormat();
			stringFormat.Alignment = StringAlignment.Center;
			stringFormat.LineAlignment = StringAlignment.Center;
			rectangle.Inflate(3, 3);
			TabPage tabPage = base.TabPages[base.SelectedIndex];
			SolidBrush solidBrush = new SolidBrush(tabPage.BackColor);
			Pen pen = new Pen(Color.FromArgb(207, 218, 224));
			e.Graphics.FillRectangle(solidBrush, rectangle);
			ControlPaint.DrawBorder(e.Graphics, rectangle, solidBrush.Color, ButtonBorderStyle.Outset);
			for (int i = 0; i <= base.TabCount - 1; i++)
			{
				tabPage = base.TabPages[i];
				rectangle = base.GetTabRect(i);
				ButtonBorderStyle style = ButtonBorderStyle.Solid;
				if (i == base.SelectedIndex)
				{
					style = ButtonBorderStyle.Outset;
				}
				solidBrush.Color = tabPage.BackColor;
				e.Graphics.FillRectangle(solidBrush, rectangle);
				solidBrush.Color = Color.FromArgb(130, 145, 155);
				ControlPaint.DrawBorder(e.Graphics, rectangle, solidBrush.Color, style);
				solidBrush.Color = tabPage.ForeColor;
				if (base.Alignment == TabAlignment.Left || base.Alignment == TabAlignment.Right)
				{
					float angle = 90f;
					if (base.Alignment == TabAlignment.Left)
					{
						angle = 270f;
					}
					PointF pointF = new PointF((float)(rectangle.Left + (rectangle.Width >> 1)), (float)(rectangle.Top + (rectangle.Height >> 1)));
					e.Graphics.TranslateTransform(pointF.X, pointF.Y);
					e.Graphics.RotateTransform(angle);
					rectangle = new Rectangle(-(rectangle.Height >> 1), -(rectangle.Width >> 1), rectangle.Height, rectangle.Width);
				}
				if (tabPage.Enabled)
				{
					e.Graphics.DrawString(tabPage.Text, this.Font, solidBrush, rectangle, stringFormat);
				}
				else
				{
					ControlPaint.DrawStringDisabled(e.Graphics, tabPage.Text, this.Font, tabPage.BackColor, rectangle, stringFormat);
				}
				e.Graphics.ResetTransform();
				if (i != base.SelectedIndex)
				{
					e.Graphics.DrawLine(pen, new Point(rectangle.Left, rectangle.Bottom - 1), new Point(rectangle.Right, rectangle.Bottom - 1));
				}
			}
			pen.Dispose();
			solidBrush.Dispose();
		}

		// Token: 0x06003807 RID: 14343 RVA: 0x002B8308 File Offset: 0x002B6508
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 8270)
			{
				TabControlEx.NMHDR nmhdr = (TabControlEx.NMHDR)Marshal.PtrToStructure(m.LParam, typeof(TabControlEx.NMHDR));
				if (nmhdr.code == -552)
				{
					TabPage tabPage = this.TestTab(base.PointToClient(Cursor.Position));
					if (tabPage != null)
					{
						TabPageChangeEventArgs tabPageChangeEventArgs = new TabPageChangeEventArgs(base.SelectedTab, tabPage);
						if (this.SelectedIndexChanging != null)
						{
							this.SelectedIndexChanging(this, tabPageChangeEventArgs);
						}
						if (tabPageChangeEventArgs.Cancel || !tabPage.Enabled)
						{
							m.Result = new IntPtr(1);
							return;
						}
					}
				}
			}
			base.WndProc(ref m);
		}

		// Token: 0x06003808 RID: 14344 RVA: 0x002B83A8 File Offset: 0x002B65A8
		private TabPage TestTab(Point pt)
		{
			for (int i = 0; i <= base.TabCount - 1; i++)
			{
				if (base.GetTabRect(i).Contains(pt.X, pt.Y))
				{
					return base.TabPages[i];
				}
			}
			return null;
		}

		// Token: 0x04004116 RID: 16662
		private const int TCN_FIRST = -550;

		// Token: 0x04004117 RID: 16663
		private const int TCN_SELCHANGING = -552;

		// Token: 0x04004118 RID: 16664
		private const int WM_USER = 1024;

		// Token: 0x04004119 RID: 16665
		private const int WM_NOTIFY = 78;

		// Token: 0x0400411A RID: 16666
		private const int WM_REFLECT = 8192;

		// Token: 0x0400411B RID: 16667
		private Container components;

		// Token: 0x0400411C RID: 16668
		private Color m_Backcolor = Color.Empty;

		// Token: 0x02000537 RID: 1335
		private struct NMHDR
		{
			// Token: 0x06003809 RID: 14345 RVA: 0x0002559C File Offset: 0x0002379C
			public override string ToString()
			{
				return string.Format("Hwnd: {0}, ControlID: {1}, Code: {2}", this.HWND, this.idFrom, this.code);
			}

			// Token: 0x0400411E RID: 16670
			public IntPtr HWND;

			// Token: 0x0400411F RID: 16671
			public uint idFrom;

			// Token: 0x04004120 RID: 16672
			public int code;
		}
	}
}
