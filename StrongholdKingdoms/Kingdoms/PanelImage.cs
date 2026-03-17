using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x02000267 RID: 615
	public class PanelImage : Panel
	{
		// Token: 0x170001DE RID: 478
		// (get) Token: 0x06001B6B RID: 7019 RVA: 0x0001B427 File Offset: 0x00019627
		// (set) Token: 0x06001B6C RID: 7020 RVA: 0x0001B42F File Offset: 0x0001962F
		public float Alpha
		{
			get
			{
				return this.alpha;
			}
			set
			{
				if (this.alpha != value)
				{
					this.alpha = value;
					base.Invalidate();
				}
			}
		}

		// Token: 0x06001B6D RID: 7021 RVA: 0x0001B447 File Offset: 0x00019647
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001B6E RID: 7022 RVA: 0x0001B466 File Offset: 0x00019666
		private void InitializeComponent()
		{
			this.components = new Container();
		}

		// Token: 0x06001B6F RID: 7023 RVA: 0x0001B473 File Offset: 0x00019673
		public PanelImage()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint, true);
		}

		// Token: 0x06001B70 RID: 7024 RVA: 0x001ACBAC File Offset: 0x001AADAC
		protected override void OnPaint(PaintEventArgs e)
		{
			Rectangle destRect = new Rectangle(0, 0, this.BackgroundImage.Width, this.BackgroundImage.Height);
			e.Graphics.DrawImage(this.BackgroundImage, destRect, destRect.X, destRect.Y, destRect.Width, destRect.Height, GraphicsUnit.Pixel, this.createAlpha(this.alpha));
		}

		// Token: 0x06001B71 RID: 7025 RVA: 0x000F702C File Offset: 0x000F522C
		private ImageAttributes createAlpha(float alpha)
		{
			ColorMatrix colorMatrix = new ColorMatrix();
			float matrix = colorMatrix.Matrix44 = 1f;
			float matrix2 = colorMatrix.Matrix22 = matrix;
			float num = colorMatrix.Matrix00 = (colorMatrix.Matrix11 = matrix2);
			colorMatrix.Matrix33 = alpha;
			ImageAttributes imageAttributes = new ImageAttributes();
			imageAttributes.SetColorMatrix(colorMatrix);
			return imageAttributes;
		}

		// Token: 0x06001B72 RID: 7026 RVA: 0x001ACC14 File Offset: 0x001AAE14
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			if (this.BackColor == global::ARGBColors.Transparent)
			{
				Rectangle rect = new Rectangle(-base.Location.X, -base.Location.Y, base.Parent.Width, base.Parent.Height);
				LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, Color.FromArgb(197, 189, 158), Color.FromArgb(141, 126, 105), LinearGradientMode.Vertical);
				e.Graphics.FillRectangle(linearGradientBrush, rect);
				linearGradientBrush.Dispose();
				return;
			}
			Brush brush = new SolidBrush(this.BackColor);
			Rectangle rect2 = new Rectangle(0, 0, base.Size.Width, base.Size.Height);
			e.Graphics.FillRectangle(brush, rect2);
			brush.Dispose();
		}

		// Token: 0x04002C1D RID: 11293
		private IContainer components;

		// Token: 0x04002C1E RID: 11294
		private float alpha = 1f;
	}
}
