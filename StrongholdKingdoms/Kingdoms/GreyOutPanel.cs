using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x020001ED RID: 493
	public class GreyOutPanel : UserControl
	{
		// Token: 0x060013A7 RID: 5031 RVA: 0x000155D1 File Offset: 0x000137D1
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060013A8 RID: 5032 RVA: 0x000155F0 File Offset: 0x000137F0
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.None;
		}

		// Token: 0x060013A9 RID: 5033 RVA: 0x00015604 File Offset: 0x00013804
		public GreyOutPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint, true);
		}

		// Token: 0x060013AA RID: 5034 RVA: 0x0001561A File Offset: 0x0001381A
		public void setInnerArea(Rectangle area)
		{
			this.innerArea = area;
			this.forceBackgroundRedraw = true;
		}

		// Token: 0x060013AB RID: 5035 RVA: 0x0014F770 File Offset: 0x0014D970
		protected override void OnPaint(PaintEventArgs e)
		{
			if (this._backBuffer == null || this.forceBackgroundRedraw)
			{
				if (this._backBuffer == null)
				{
					this._backBuffer = new Bitmap(base.Size.Width, base.Size.Height);
				}
				this.forceBackgroundRedraw = false;
				Graphics graphics = Graphics.FromImage(this._backBuffer);
				Brush brush = new SolidBrush(global::ARGBColors.Black);
				graphics.FillRectangle(brush, new Rectangle(base.Location, base.Size));
				brush.Dispose();
				int x = this.innerArea.X;
				int y = this.innerArea.Y;
				if (x > 0 || y > 0)
				{
					graphics.DrawImage(GFXLibrary.interface_under_shadow_128_topleft, x - 128, y - 128, 128, 128);
					graphics.DrawImage(GFXLibrary.interface_under_shadow_128_topright, x + this.innerArea.Width, y - 128, 128, 128);
					graphics.DrawImage(GFXLibrary.interface_under_shadow_128_bottomleft, x - 128, y + this.innerArea.Height, 128, 128);
					graphics.DrawImage(GFXLibrary.interface_under_shadow_128_bottomright, x + this.innerArea.Width, y + this.innerArea.Height, 128, 128);
					if (x > 0)
					{
						this.drawImageStretched(graphics, GFXLibrary.interface_under_shadow_128_top, (float)x, (float)(y - 128), (float)this.innerArea.Width, 128f);
						this.drawImageStretched(graphics, GFXLibrary.interface_under_shadow_128_bottom, (float)x, (float)(y + this.innerArea.Height), (float)this.innerArea.Width, 128f);
					}
					if (y > 0)
					{
						this.drawImageStretched(graphics, GFXLibrary.interface_under_shadow_128_left, (float)(x - 128), (float)y, 128f, (float)this.innerArea.Height);
						this.drawImageStretched(graphics, GFXLibrary.interface_under_shadow_128_right, (float)(x + this.innerArea.Width), (float)y, 128f, (float)this.innerArea.Height);
					}
				}
				graphics.Dispose();
			}
			if (e != null)
			{
				e.Graphics.DrawImageUnscaled(this._backBuffer, 0, 0);
			}
		}

		// Token: 0x060013AC RID: 5036 RVA: 0x000E3950 File Offset: 0x000E1B50
		private void drawImageStretched(Graphics g, Image image, float x, float y, float width, float height)
		{
			RectangleF srcRect = (image.Width == 1) ? new RectangleF(0f, 0f, 1E-05f, (float)image.Height) : new RectangleF(0f, 0f, (float)image.Width, 1E-05f);
			RectangleF destRect = new RectangleF(x, y, width, height);
			g.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
		}

		// Token: 0x060013AD RID: 5037 RVA: 0x00007CE0 File Offset: 0x00005EE0
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
		}

		// Token: 0x060013AE RID: 5038 RVA: 0x0001562A File Offset: 0x0001382A
		protected override void OnSizeChanged(EventArgs e)
		{
			if (this._backBuffer != null)
			{
				this._backBuffer.Dispose();
				this._backBuffer = null;
				base.Invalidate();
			}
			base.OnSizeChanged(e);
		}

		// Token: 0x040024C4 RID: 9412
		private IContainer components;

		// Token: 0x040024C5 RID: 9413
		private Rectangle innerArea;

		// Token: 0x040024C6 RID: 9414
		private Bitmap _backBuffer;

		// Token: 0x040024C7 RID: 9415
		private bool forceBackgroundRedraw;
	}
}
