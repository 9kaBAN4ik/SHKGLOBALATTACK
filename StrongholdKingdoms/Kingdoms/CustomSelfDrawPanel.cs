using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x0200015C RID: 348
	public class CustomSelfDrawPanel : UserControl
	{
		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000CF7 RID: 3319 RVA: 0x0000F9CB File Offset: 0x0000DBCB
		// (set) Token: 0x06000CF8 RID: 3320 RVA: 0x0000F9D3 File Offset: 0x0000DBD3
		public Graphics StoredGraphics
		{
			get
			{
				return this.storedGraphics;
			}
			set
			{
				this.storedGraphics = value;
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000CF9 RID: 3321 RVA: 0x0000F9DC File Offset: 0x0000DBDC
		public Point LastMousePosition
		{
			get
			{
				return this.lastMousePosition;
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x06000CFA RID: 3322 RVA: 0x0000F9E4 File Offset: 0x0000DBE4
		public bool MouseReallyPressed
		{
			get
			{
				return this.mouseReallyPressed;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000CFB RID: 3323 RVA: 0x0000F9EC File Offset: 0x0000DBEC
		// (set) Token: 0x06000CFC RID: 3324 RVA: 0x0000F9F4 File Offset: 0x0000DBF4
		public bool PanelActive
		{
			get
			{
				return this.panelActive;
			}
			set
			{
				this.panelActive = value;
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000CFD RID: 3325 RVA: 0x0000F9FD File Offset: 0x0000DBFD
		// (set) Token: 0x06000CFE RID: 3326 RVA: 0x0000FA05 File Offset: 0x0000DC05
		public bool SelfDrawBackground
		{
			get
			{
				return this.selfDrawBackground;
			}
			set
			{
				this.selfDrawBackground = value;
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000CFF RID: 3327 RVA: 0x0000FA0E File Offset: 0x0000DC0E
		// (set) Token: 0x06000D00 RID: 3328 RVA: 0x0000FA16 File Offset: 0x0000DC16
		public bool NoDrawBackground
		{
			get
			{
				return this.noDrawBackground;
			}
			set
			{
				this.noDrawBackground = value;
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000D01 RID: 3329 RVA: 0x0000FA1F File Offset: 0x0000DC1F
		// (set) Token: 0x06000D02 RID: 3330 RVA: 0x0000FA27 File Offset: 0x0000DC27
		public bool ClickThru
		{
			get
			{
				return this.clickThru;
			}
			set
			{
				this.clickThru = value;
			}
		}

		// Token: 0x06000D03 RID: 3331 RVA: 0x000F6580 File Offset: 0x000F4780
		public CustomSelfDrawPanel()
		{
			this.InitializeComponent();
			base.MouseWheel += this.CustomSelfDrawPanel_MouseWheel;
		}

		// Token: 0x06000D04 RID: 3332 RVA: 0x0000FA30 File Offset: 0x0000DC30
		public void forceStyle()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06000D05 RID: 3333 RVA: 0x0000FA3E File Offset: 0x0000DC3E
		public bool initOnPaint(PaintEventArgs e)
		{
			if (!this.inDXDraw)
			{
				this.inNormalDraw = true;
				this.StoredGraphics = e.Graphics;
				this.StoredGraphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				return true;
			}
			return false;
		}

		// Token: 0x06000D06 RID: 3334 RVA: 0x0000FA6A File Offset: 0x0000DC6A
		public bool initFromDX(Graphics g, CustomSelfDrawPanel.CSDControl control)
		{
			if (!this.inNormalDraw)
			{
				this.inDXDraw = true;
				this.StoredGraphics = g;
				return true;
			}
			return false;
		}

		// Token: 0x06000D07 RID: 3335 RVA: 0x0000FA85 File Offset: 0x0000DC85
		public void endPaint()
		{
			this.inNormalDraw = false;
			this.inDXDraw = false;
			this.StoredGraphics = null;
		}

		// Token: 0x06000D08 RID: 3336 RVA: 0x000F65EC File Offset: 0x000F47EC
		protected override void OnPaint(PaintEventArgs e)
		{
			try
			{
				if (this.initOnPaint(e))
				{
					CustomSelfDrawPanel.screenClipRect = e.ClipRectangle;
					this.drawControls();
					this.endPaint();
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000D09 RID: 3337 RVA: 0x000F6630 File Offset: 0x000F4830
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			try
			{
				if (!this.selfDrawBackground)
				{
					if (!this.noDrawBackground)
					{
						base.OnPaintBackground(pevent);
					}
				}
				else if (base.Parent != null && base.Parent.BackgroundImage != null && pevent.Graphics != null)
				{
					new Rectangle(0, 0, base.Parent.BackgroundImage.Width, base.Parent.BackgroundImage.Height);
					Rectangle destRect = new Rectangle(-base.Location.X, -base.Location.Y, base.Parent.Size.Width, base.Parent.Size.Height);
					ImageAttributes imageAttributes = new ImageAttributes();
					imageAttributes.SetWrapMode(WrapMode.Tile);
					pevent.Graphics.DrawImage(base.Parent.BackgroundImage, destRect, 0, 0, base.Parent.BackgroundImage.Width, base.Parent.BackgroundImage.Height, GraphicsUnit.Pixel, imageAttributes);
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000D0A RID: 3338 RVA: 0x000F6760 File Offset: 0x000F4960
		public void setClipRegion(Rectangle clipRect)
		{
			if (this.StoredGraphics != null)
			{
				this.clipRectStack.Push(this.currentClip);
				this.currentClip = clipRect;
				this.clipStack.Push(this.StoredGraphics.Clip);
				Region region = this.StoredGraphics.Clip.Clone();
				region.Intersect(clipRect);
				this.StoredGraphics.Clip = region;
			}
		}

		// Token: 0x06000D0B RID: 3339 RVA: 0x0000FA9C File Offset: 0x0000DC9C
		public void restoreClipRegion()
		{
			if (this.StoredGraphics != null)
			{
				this.StoredGraphics.Clip = this.clipStack.Pop();
				this.currentClip = this.clipRectStack.Pop();
			}
		}

		// Token: 0x06000D0C RID: 3340 RVA: 0x0000FACD File Offset: 0x0000DCCD
		public Rectangle getCurrentClip()
		{
			if (this.StoredGraphics != null)
			{
				return this.currentClip;
			}
			return Rectangle.Empty;
		}

		// Token: 0x06000D0D RID: 3341 RVA: 0x0000FAE3 File Offset: 0x0000DCE3
		public void clearControls()
		{
			this.baseControl.clearControls();
		}

		// Token: 0x06000D0E RID: 3342 RVA: 0x0000FAF0 File Offset: 0x0000DCF0
		public void addControl(CustomSelfDrawPanel.CSDControl control)
		{
			this.addControl(control, false);
		}

		// Token: 0x06000D0F RID: 3343 RVA: 0x0000FAFA File Offset: 0x0000DCFA
		public void addControl(CustomSelfDrawPanel.CSDControl control, bool addAtBack)
		{
			this.baseControl.setCustomSelfDrawPanel(this);
			if (addAtBack)
			{
				this.baseControl.addControlAtBack(control);
				return;
			}
			this.baseControl.addControl(control);
		}

		// Token: 0x06000D10 RID: 3344 RVA: 0x0000FB24 File Offset: 0x0000DD24
		public void removeControl(CustomSelfDrawPanel.CSDControl control)
		{
			this.baseControl.setCustomSelfDrawPanel(this);
			this.baseControl.removeControl(control);
		}

		// Token: 0x06000D11 RID: 3345 RVA: 0x0000FB3E File Offset: 0x0000DD3E
		public void drawControls()
		{
			this.baseControl.drawControls(new Point(0, 0));
		}

		// Token: 0x06000D12 RID: 3346 RVA: 0x000F67C8 File Offset: 0x000F49C8
		protected void drawImage(Image image, Point dest)
		{
			Rectangle srcRect = new Rectangle(0, 0, image.Width, image.Height);
			Rectangle destRect = new Rectangle(dest.X, dest.Y, image.Width, image.Height);
			if (this.StoredGraphics != null)
			{
				this.StoredGraphics.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
			}
		}

		// Token: 0x06000D13 RID: 3347 RVA: 0x000F6824 File Offset: 0x000F4A24
		protected void drawImage(Image image, Point dest, float alpha)
		{
			Rectangle rectangle = new Rectangle(0, 0, image.Width, image.Height);
			Rectangle destRect = new Rectangle(dest.X, dest.Y, image.Width, image.Height);
			if (this.StoredGraphics != null)
			{
				this.StoredGraphics.DrawImage(image, destRect, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, GraphicsUnit.Pixel, this.createAlpha(alpha));
			}
		}

		// Token: 0x06000D14 RID: 3348 RVA: 0x000F68A0 File Offset: 0x000F4AA0
		protected void drawImageMirrorRotate(Image image, Rectangle source, Rectangle dest, bool mirrored, float rotate, PointF rotateCentre)
		{
			if (this.StoredGraphics == null)
			{
				return;
			}
			RectangleF srcRect = new RectangleF((float)source.X, (float)source.Y, (float)source.Width, (float)source.Height);
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddPolygon(new Point[]
			{
				new Point(0, 0),
				new Point(dest.Width, 0),
				new Point(0, dest.Height)
			});
			Matrix matrix = new Matrix();
			if (mirrored)
			{
				matrix = new Matrix(-1f, 0f, 0f, 1f, 0f, 0f);
			}
			if (rotate != 0f)
			{
				if (rotateCentre.X == -1000f)
				{
					matrix.RotateAt(rotate, new PointF((float)(source.Width / 2), (float)(source.Height / 2)));
				}
				else
				{
					matrix.RotateAt(rotate, rotateCentre);
				}
			}
			if (mirrored)
			{
				matrix.Translate((float)(dest.X + source.Width), (float)dest.Y, MatrixOrder.Append);
			}
			else
			{
				matrix.Translate((float)dest.X, (float)dest.Y, MatrixOrder.Append);
			}
			Matrix transform = this.StoredGraphics.Transform;
			graphicsPath.Transform(matrix);
			PointF[] pathPoints = graphicsPath.PathPoints;
			this.StoredGraphics.DrawImage(image, pathPoints, srcRect, GraphicsUnit.Pixel);
			this.StoredGraphics.Transform = transform;
		}

		// Token: 0x06000D15 RID: 3349 RVA: 0x000F6A0C File Offset: 0x000F4C0C
		protected void drawImageMirrorRotateAlpha(Image image, Rectangle source, Rectangle dest, bool mirrored, float rotate, PointF rotateCentre, float alpha)
		{
			if (this.StoredGraphics == null)
			{
				return;
			}
			RectangleF srcRect = new RectangleF((float)source.X, (float)source.Y, (float)source.Width, (float)source.Height);
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddPolygon(new Point[]
			{
				new Point(0, 0),
				new Point(dest.Width, 0),
				new Point(0, dest.Height)
			});
			Matrix matrix = new Matrix();
			if (mirrored)
			{
				matrix = new Matrix(-1f, 0f, 0f, 1f, 0f, 0f);
			}
			if (rotate != 0f)
			{
				if (rotateCentre.X == -1000f)
				{
					matrix.RotateAt(rotate, new PointF((float)(source.Width / 2), (float)(source.Height / 2)));
				}
				else
				{
					matrix.RotateAt(rotate, rotateCentre);
				}
			}
			if (mirrored)
			{
				matrix.Translate((float)(dest.X + source.Width), (float)dest.Y, MatrixOrder.Append);
			}
			else
			{
				matrix.Translate((float)dest.X, (float)dest.Y, MatrixOrder.Append);
			}
			Matrix transform = this.StoredGraphics.Transform;
			graphicsPath.Transform(matrix);
			PointF[] pathPoints = graphicsPath.PathPoints;
			this.StoredGraphics.DrawImage(image, pathPoints, srcRect, GraphicsUnit.Pixel, this.createAlpha(alpha));
			this.StoredGraphics.Transform = transform;
		}

		// Token: 0x06000D16 RID: 3350 RVA: 0x0000FB52 File Offset: 0x0000DD52
		protected void drawImage(Image image, Rectangle source, Rectangle dest)
		{
			if (this.StoredGraphics != null)
			{
				this.StoredGraphics.DrawImage(image, dest, source, GraphicsUnit.Pixel);
			}
		}

		// Token: 0x06000D17 RID: 3351 RVA: 0x000F6B80 File Offset: 0x000F4D80
		protected void drawImageColourMap(Image image, Rectangle source, Rectangle dest, ColorMap[] colourMap)
		{
			if (this.StoredGraphics != null)
			{
				ImageAttributes imageAttributes = new ImageAttributes();
				imageAttributes.SetRemapTable(colourMap);
				this.StoredGraphics.DrawImage(image, dest, (float)source.X, (float)source.Y, (float)source.Width, (float)source.Height, GraphicsUnit.Pixel, imageAttributes);
			}
		}

		// Token: 0x06000D18 RID: 3352 RVA: 0x0000FB6B File Offset: 0x0000DD6B
		protected void drawImage(Image image, RectangleF source, RectangleF dest)
		{
			if (this.StoredGraphics != null)
			{
				this.StoredGraphics.DrawImage(image, dest, source, GraphicsUnit.Pixel);
			}
		}

		// Token: 0x06000D19 RID: 3353 RVA: 0x000F6BD4 File Offset: 0x000F4DD4
		protected void drawImage(Image image, RectangleF source, RectangleF dest, float alpha)
		{
			PointF pointF = new PointF(dest.Left, dest.Top);
			PointF pointF2 = new PointF(dest.Right, dest.Top);
			PointF pointF3 = new PointF(dest.Left, dest.Bottom);
			PointF[] destPoints = new PointF[]
			{
				pointF,
				pointF2,
				pointF3
			};
			if (this.StoredGraphics != null)
			{
				this.StoredGraphics.DrawImage(image, destPoints, source, GraphicsUnit.Pixel, this.createAlpha(alpha));
			}
		}

		// Token: 0x06000D1A RID: 3354 RVA: 0x000F6C60 File Offset: 0x000F4E60
		protected void drawImage(Image image, Rectangle source, Rectangle dest, float alpha)
		{
			if (this.StoredGraphics != null)
			{
				this.StoredGraphics.DrawImage(image, dest, source.X, source.Y, source.Width, source.Height, GraphicsUnit.Pixel, this.createAlpha(alpha));
			}
		}

		// Token: 0x06000D1B RID: 3355 RVA: 0x000F6CA8 File Offset: 0x000F4EA8
		protected void drawImageBrighten(Image image, Rectangle source, Rectangle dest, float alpha)
		{
			if (this.StoredGraphics != null)
			{
				this.StoredGraphics.DrawImage(image, dest, source.X, source.Y, source.Width, source.Height, GraphicsUnit.Pixel, this.createAlphaBrighten(alpha));
			}
		}

		// Token: 0x06000D1C RID: 3356 RVA: 0x000F6CF0 File Offset: 0x000F4EF0
		protected void drawImage(Image image, Rectangle source, Rectangle dest, float alpha, double scale)
		{
			double num = (double)dest.Width * scale;
			double num2 = (double)dest.Height * scale;
			Rectangle destRect = new Rectangle(dest.X, dest.Y, (int)num, (int)num2);
			if (this.StoredGraphics != null)
			{
				this.StoredGraphics.DrawImage(image, destRect, source.X, source.Y, source.Width, source.Height, GraphicsUnit.Pixel, this.createAlpha(alpha));
			}
		}

		// Token: 0x06000D1D RID: 3357 RVA: 0x000F6D68 File Offset: 0x000F4F68
		protected void drawImage(Image image, Point dest, float alpha, double scale)
		{
			double num = (double)image.Width * scale;
			double num2 = (double)image.Height * scale;
			Rectangle rectangle = new Rectangle(0, 0, image.Width, image.Height);
			Rectangle destRect = new Rectangle(dest.X, dest.Y, (int)num, (int)num2);
			if (this.StoredGraphics != null)
			{
				this.StoredGraphics.DrawImage(image, destRect, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, GraphicsUnit.Pixel, this.createAlpha(alpha));
			}
		}

		// Token: 0x06000D1E RID: 3358 RVA: 0x000F6DF4 File Offset: 0x000F4FF4
		protected void drawImage(Image image, RectangleF source, RectangleF dest, float alpha, Color color)
		{
			PointF pointF = new PointF(dest.Left, dest.Top);
			PointF pointF2 = new PointF(dest.Right, dest.Top);
			PointF pointF3 = new PointF(dest.Left, dest.Bottom);
			PointF[] destPoints = new PointF[]
			{
				pointF,
				pointF2,
				pointF3
			};
			if (this.StoredGraphics != null)
			{
				this.StoredGraphics.DrawImage(image, destPoints, source, GraphicsUnit.Pixel, this.createColour(color, alpha));
			}
		}

		// Token: 0x06000D1F RID: 3359 RVA: 0x000F6E80 File Offset: 0x000F5080
		protected void drawImage(Image image, Rectangle source, Rectangle dest, float alpha, Color color)
		{
			if (this.StoredGraphics != null)
			{
				this.StoredGraphics.DrawImage(image, dest, source.X, source.Y, source.Width, source.Height, GraphicsUnit.Pixel, this.createColour(color, alpha));
			}
		}

		// Token: 0x06000D20 RID: 3360 RVA: 0x000F6ECC File Offset: 0x000F50CC
		protected void drawImage(Image image, Rectangle source, Rectangle dest, float alpha, double scale, Color color)
		{
			double num = (double)dest.Width * scale;
			double num2 = (double)dest.Height * scale;
			Rectangle destRect = new Rectangle(dest.X, dest.Y, (int)num, (int)num2);
			if (this.StoredGraphics != null)
			{
				this.StoredGraphics.DrawImage(image, destRect, source.X, source.Y, source.Width, source.Height, GraphicsUnit.Pixel, this.createColour(color, alpha));
			}
		}

		// Token: 0x06000D21 RID: 3361 RVA: 0x000F6F48 File Offset: 0x000F5148
		protected void drawImage(Image image, Point dest, float alpha, double scale, Color color)
		{
			double num = (double)image.Width * scale;
			double num2 = (double)image.Height * scale;
			Rectangle rectangle = new Rectangle(0, 0, image.Width, image.Height);
			Rectangle destRect = new Rectangle(dest.X, dest.Y, (int)num, (int)num2);
			if (this.StoredGraphics != null)
			{
				this.StoredGraphics.DrawImage(image, destRect, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, GraphicsUnit.Pixel, this.createColour(color, alpha));
			}
		}

		// Token: 0x06000D22 RID: 3362 RVA: 0x000F6FD4 File Offset: 0x000F51D4
		protected void drawImage(Image image, Rectangle source, Rectangle dest, double scale)
		{
			double num = (double)dest.Width * scale;
			double num2 = (double)dest.Height * scale;
			Rectangle destRect = new Rectangle(dest.X, dest.Y, (int)num, (int)num2);
			if (this.StoredGraphics != null)
			{
				this.StoredGraphics.DrawImage(image, destRect, source, GraphicsUnit.Pixel);
			}
		}

		// Token: 0x06000D23 RID: 3363 RVA: 0x0000FB84 File Offset: 0x0000DD84
		protected void drawSpecialGradient(Rectangle rect)
		{
			if (this.StoredGraphics != null)
			{
				CustomSelfDrawPanel.drawGradientPanel(this.StoredGraphics, rect.Location, rect.Size);
			}
		}

		// Token: 0x06000D24 RID: 3364 RVA: 0x000F702C File Offset: 0x000F522C
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

		// Token: 0x06000D25 RID: 3365 RVA: 0x000F7090 File Offset: 0x000F5290
		private ImageAttributes createAlphaBrighten(float alpha)
		{
			ColorMatrix colorMatrix = new ColorMatrix();
			float matrix = colorMatrix.Matrix44 = 1f;
			float matrix2 = colorMatrix.Matrix22 = matrix;
			float num = colorMatrix.Matrix00 = (colorMatrix.Matrix11 = matrix2);
			float matrix3 = colorMatrix.Matrix32 = 0.1f;
			num = (colorMatrix.Matrix30 = (colorMatrix.Matrix31 = matrix3));
			colorMatrix.Matrix33 = alpha;
			ImageAttributes imageAttributes = new ImageAttributes();
			imageAttributes.SetColorMatrix(colorMatrix);
			return imageAttributes;
		}

		// Token: 0x06000D26 RID: 3366 RVA: 0x000F7120 File Offset: 0x000F5320
		private ImageAttributes createColour(Color color, float alpha)
		{
			ColorMatrix colorMatrix = new ColorMatrix();
			colorMatrix.Matrix00 = (float)color.R / 255f;
			colorMatrix.Matrix11 = (float)color.G / 255f;
			colorMatrix.Matrix22 = (float)color.B / 255f;
			colorMatrix.Matrix44 = 1f;
			colorMatrix.Matrix33 = alpha;
			ImageAttributes imageAttributes = new ImageAttributes();
			imageAttributes.SetColorMatrix(colorMatrix);
			return imageAttributes;
		}

		// Token: 0x06000D27 RID: 3367 RVA: 0x000F7190 File Offset: 0x000F5390
		protected void drawRect(Rectangle area, Color col)
		{
			if (this.StoredGraphics != null)
			{
				Pen pen = new Pen(col);
				this.StoredGraphics.DrawRectangle(pen, area);
				pen.Dispose();
			}
		}

		// Token: 0x06000D28 RID: 3368 RVA: 0x000F71C0 File Offset: 0x000F53C0
		protected void drawLine(Color col, Point start, Point end)
		{
			if (this.StoredGraphics != null)
			{
				Pen pen = new Pen(col);
				this.StoredGraphics.DrawLine(pen, start, end);
				pen.Dispose();
			}
		}

		// Token: 0x06000D29 RID: 3369 RVA: 0x000F71F0 File Offset: 0x000F53F0
		protected void drawString(string text, Rectangle displayRect, Color color, Font font, CustomSelfDrawPanel.CSD_Text_Alignment alignment)
		{
			SolidBrush solidBrush = new SolidBrush(color);
			StringFormat stringFormat = new StringFormat();
			switch (alignment)
			{
			case CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT:
				stringFormat.Alignment = StringAlignment.Near;
				stringFormat.LineAlignment = StringAlignment.Near;
				break;
			case CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER:
				stringFormat.Alignment = StringAlignment.Center;
				stringFormat.LineAlignment = StringAlignment.Near;
				break;
			case CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT:
				stringFormat.Alignment = StringAlignment.Far;
				stringFormat.LineAlignment = StringAlignment.Near;
				break;
			case CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT:
				stringFormat.Alignment = StringAlignment.Near;
				stringFormat.LineAlignment = StringAlignment.Center;
				break;
			case CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER:
				stringFormat.Alignment = StringAlignment.Center;
				stringFormat.LineAlignment = StringAlignment.Center;
				break;
			case CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT:
				stringFormat.Alignment = StringAlignment.Far;
				stringFormat.LineAlignment = StringAlignment.Center;
				break;
			case CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_LEFT:
				stringFormat.Alignment = StringAlignment.Near;
				stringFormat.LineAlignment = StringAlignment.Far;
				break;
			case CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_CENTER:
				stringFormat.Alignment = StringAlignment.Center;
				stringFormat.LineAlignment = StringAlignment.Far;
				break;
			case CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_RIGHT:
				stringFormat.Alignment = StringAlignment.Far;
				stringFormat.LineAlignment = StringAlignment.Far;
				break;
			}
			RectangleF layoutRectangle = new RectangleF((float)displayRect.X, (float)displayRect.Y, (float)displayRect.Width, (float)displayRect.Height);
			if (this.StoredGraphics != null)
			{
				this.StoredGraphics.DrawString(text, font, solidBrush, layoutRectangle, stringFormat);
			}
			solidBrush.Dispose();
		}

		// Token: 0x06000D2A RID: 3370 RVA: 0x000F7310 File Offset: 0x000F5510
		protected SizeF getStringBounds(string text, int displayWidth, Font font)
		{
			if (this.StoredGraphics != null)
			{
				return this.StoredGraphics.MeasureString(text, font, displayWidth);
			}
			return default(SizeF);
		}

		// Token: 0x06000D2B RID: 3371 RVA: 0x000F7340 File Offset: 0x000F5540
		private void fillRect(Rectangle fillArea, Color fillColor)
		{
			SolidBrush solidBrush = new SolidBrush(fillColor);
			if (this.StoredGraphics != null)
			{
				this.StoredGraphics.FillRectangle(solidBrush, fillArea);
			}
			solidBrush.Dispose();
		}

		// Token: 0x06000D2C RID: 3372 RVA: 0x000F7370 File Offset: 0x000F5570
		private void CustomSelfDrawPanel_MouseClick(object sender, MouseEventArgs e)
		{
			if (!this.panelActive)
			{
				return;
			}
			if (e.Button == MouseButtons.Left)
			{
				Point mousePos = this.lastMousePosition = e.Location;
				if (Math.Abs(this.lastMousePosition.X - this.mouseDownLocation.X) <= 4 && Math.Abs(this.lastMousePosition.Y - this.mouseDownLocation.Y) <= 4)
				{
					this.ClickHandled = this.baseControl.parentClicked(mousePos);
					return;
				}
			}
			else if (e.Button == MouseButtons.Right)
			{
				Point mousePos2 = this.lastMousePosition = e.Location;
				if (Math.Abs(this.lastMousePosition.X - this.mouseDownLocation.X) <= 4 && Math.Abs(this.lastMousePosition.Y - this.mouseDownLocation.Y) <= 4)
				{
					this.baseControl.parentRightClicked(mousePos2);
				}
			}
		}

		// Token: 0x06000D2D RID: 3373 RVA: 0x0000FBA7 File Offset: 0x0000DDA7
		private void CustomSelfDrawPanel_MouseEnter(object sender, EventArgs e)
		{
			bool flag = this.panelActive;
		}

		// Token: 0x06000D2E RID: 3374 RVA: 0x0000FBB0 File Offset: 0x0000DDB0
		private void CustomSelfDrawPanel_MouseLeave(object sender, EventArgs e)
		{
			if (this.panelActive)
			{
				CustomTooltipManager.MouseLeaveTooltipArea();
				this.baseControl.handleMouseLeave(null);
			}
		}

		// Token: 0x06000D2F RID: 3375 RVA: 0x0000FBCB File Offset: 0x0000DDCB
		public static Point GetMousePosition()
		{
			return CustomSelfDrawPanel.mousePosition;
		}

		// Token: 0x06000D30 RID: 3376 RVA: 0x0000FBD2 File Offset: 0x0000DDD2
		public void addTrapMouseEvent(CustomSelfDrawPanel.CSDControl control)
		{
			if (!this.trapMouseEvents.Contains(control))
			{
				this.trapMouseEvents.Add(control);
			}
		}

		// Token: 0x06000D31 RID: 3377 RVA: 0x0000FBEE File Offset: 0x0000DDEE
		public void removeTrapMouseEvent(CustomSelfDrawPanel.CSDControl control)
		{
			this.trapMouseEvents.Remove(control);
		}

		// Token: 0x06000D32 RID: 3378 RVA: 0x000F7460 File Offset: 0x000F5660
		public void clearTrappedMouseEvents()
		{
			foreach (CustomSelfDrawPanel.CSDControl csdcontrol in this.trapMouseEvents)
			{
				UniversalDebugLog.Log(csdcontrol.GetType() + " onclear mouseup");
				UniversalDebugLog.Log("Stop here");
				csdcontrol.mouseUpOutside();
			}
			this.trapMouseEvents.Clear();
		}

		// Token: 0x06000D33 RID: 3379 RVA: 0x000F74DC File Offset: 0x000F56DC
		public void manageTrappedMouseEvents()
		{
			List<CustomSelfDrawPanel.CSDControl> list = null;
			bool flag = true;
			while (flag)
			{
				flag = false;
				try
				{
					foreach (CustomSelfDrawPanel.CSDControl csdcontrol in this.trapMouseEvents)
					{
						if (csdcontrol.Visible)
						{
							csdcontrol.mouseEventTrapped();
						}
						else
						{
							if (list == null)
							{
								list = new List<CustomSelfDrawPanel.CSDControl>();
							}
							list.Add(csdcontrol);
						}
					}
				}
				catch (Exception)
				{
					flag = true;
				}
			}
			if (list != null)
			{
				foreach (CustomSelfDrawPanel.CSDControl item in list)
				{
					this.trapMouseEvents.Remove(item);
				}
			}
		}

		// Token: 0x06000D34 RID: 3380 RVA: 0x000F75B0 File Offset: 0x000F57B0
		private void CustomSelfDrawPanel_MouseDown(object sender, MouseEventArgs e)
		{
			if (this.panelActive)
			{
				if (e.Button == MouseButtons.Left)
				{
					Point location = e.Location;
					this.mouseReallyPressed = true;
					this.lastMousePosition = location;
					this.mouseDownLocation = location;
					this.baseControl.parentMouseDown(location);
				}
				if (e.Button == MouseButtons.Right)
				{
					this.mouseDownLocation = (this.lastMousePosition = e.Location);
				}
			}
		}

		// Token: 0x06000D35 RID: 3381 RVA: 0x000F7620 File Offset: 0x000F5820
		private void CustomSelfDrawPanel_MouseUp(object sender, MouseEventArgs e)
		{
			if (this.panelActive)
			{
				if (e.Button == MouseButtons.Left)
				{
					Point location = e.Location;
					this.mouseReallyPressed = false;
					this.lastMousePosition = location;
					this.baseControl.parentMouseUp(location);
					this.manageTrappedMouseEvents();
				}
				if (e.Button == MouseButtons.Right)
				{
					Point point = this.lastMousePosition = e.Location;
				}
			}
		}

		// Token: 0x06000D36 RID: 3382 RVA: 0x000F7688 File Offset: 0x000F5888
		private void CustomSelfDrawPanel_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.panelActive)
			{
				CustomTooltipManager.MouseLeaveTooltipArea();
				this.tooltipSet = false;
				Point mousePos = this.lastMousePosition = e.Location;
				if (this.baseControl.parentMouseOver(mousePos) == null)
				{
					this.baseControl.handleMouseLeave(null);
				}
				this.manageTrappedMouseEvents();
			}
		}

		// Token: 0x06000D37 RID: 3383 RVA: 0x000F76DC File Offset: 0x000F58DC
		private void CustomSelfDrawPanel_MouseWheel(object sender, MouseEventArgs e)
		{
			if (this.panelActive)
			{
				int delta = e.Delta / SystemInformation.MouseWheelScrollDelta;
				Point mousePos = this.lastMousePosition = e.Location;
				this.baseControl.parentMouseWheel(mousePos, delta);
			}
		}

		// Token: 0x06000D38 RID: 3384 RVA: 0x0000FBFD File Offset: 0x0000DDFD
		protected void handleMouseLeave(CustomSelfDrawPanel.CSDControl control)
		{
			this.baseControl.handleMouseLeave(control);
		}

		// Token: 0x06000D39 RID: 3385 RVA: 0x0000FC0B File Offset: 0x0000DE0B
		public bool getToolTip(ref int data)
		{
			return this.baseControl.getToolTip(this.lastMousePosition, ref data);
		}

		// Token: 0x06000D3A RID: 3386 RVA: 0x000F771C File Offset: 0x000F591C
		public void InvalidateCached(Rectangle rect)
		{
			CustomSelfDrawPanel.InvalidRectpair invalidRectpair = new CustomSelfDrawPanel.InvalidRectpair();
			invalidRectpair.rect = rect;
			invalidRectpair.panel = this;
			CustomSelfDrawPanel.invalidRectList.Add(invalidRectpair);
		}

		// Token: 0x06000D3B RID: 3387 RVA: 0x000F7748 File Offset: 0x000F5948
		public static void processInvalidRectCache()
		{
			if (CustomSelfDrawPanel.invalidRectList.Count > 0)
			{
				foreach (CustomSelfDrawPanel.InvalidRectpair invalidRectpair in CustomSelfDrawPanel.invalidRectList)
				{
					invalidRectpair.panel.Invalidate(invalidRectpair.rect);
				}
				CustomSelfDrawPanel.invalidRectList.Clear();
			}
		}

		// Token: 0x06000D3C RID: 3388 RVA: 0x000F77BC File Offset: 0x000F59BC
		public static void drawGradientPanel(Graphics mGraphics, Size size)
		{
			CustomSelfDrawPanel.drawGradientPanel(mGraphics, default(Point), size);
		}

		// Token: 0x06000D3D RID: 3389 RVA: 0x000F77DC File Offset: 0x000F59DC
		public static void drawGradientPanel(Graphics mGraphics, Point pos, Size size)
		{
			Rectangle rect = new Rectangle(pos.X, pos.Y, size.Width, size.Height);
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, Color.FromArgb(86, 98, 106), Color.FromArgb(159, 180, 193), LinearGradientMode.Vertical);
			mGraphics.FillRectangle(linearGradientBrush, rect);
			Pen pen = new Pen(Color.FromArgb(159, 180, 193), 1f);
			Rectangle rect2 = new Rectangle(pos.X, pos.Y, size.Width - 1, size.Height - 1);
			mGraphics.DrawRectangle(pen, rect2);
			Pen pen2 = new Pen(Color.FromArgb(86, 98, 106), 1f);
			Rectangle rect3 = new Rectangle(pos.X + 1, pos.Y, size.Width - 3, size.Height - 2);
			mGraphics.DrawRectangle(pen2, rect3);
			pen.Dispose();
			pen2.Dispose();
			linearGradientBrush.Dispose();
		}

		// Token: 0x06000D3E RID: 3390 RVA: 0x0000FC1F File Offset: 0x0000DE1F
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 132 && this.clickThru)
			{
				m.Result = (IntPtr)(-1);
				return;
			}
			base.WndProc(ref m);
		}

		// Token: 0x06000D3F RID: 3391 RVA: 0x0000FC4A File Offset: 0x0000DE4A
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000D40 RID: 3392 RVA: 0x000F78E8 File Offset: 0x000F5AE8
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			base.Name = "CustomSelfDrawPanel";
			base.MouseLeave += this.CustomSelfDrawPanel_MouseLeave;
			base.MouseMove += this.CustomSelfDrawPanel_MouseMove;
			base.MouseDoubleClick += this.CustomSelfDrawPanel_MouseClick;
			base.MouseClick += this.CustomSelfDrawPanel_MouseClick;
			base.MouseDown += this.CustomSelfDrawPanel_MouseDown;
			base.MouseUp += this.CustomSelfDrawPanel_MouseUp;
			base.MouseEnter += this.CustomSelfDrawPanel_MouseEnter;
			base.ResumeLayout(false);
		}

		// Token: 0x04001146 RID: 4422
		public static Color MailBodyColor = Color.FromArgb(234, 245, 253);

		// Token: 0x04001147 RID: 4423
		public static Color MailLineColor = Color.FromArgb(223, 237, 249);

		// Token: 0x04001148 RID: 4424
		public static Color MailOverColor = Color.FromArgb(247, 252, 254);

		// Token: 0x04001149 RID: 4425
		public static Color MailLineOverColor = Color.FromArgb(223, 237, 249);

		// Token: 0x0400114A RID: 4426
		public static Color MailSelectedColor = Color.FromArgb(192, 222, 237);

		// Token: 0x0400114B RID: 4427
		public static Color MailSelectedOverColor = Color.FromArgb(221, 241, 249);

		// Token: 0x0400114C RID: 4428
		private Graphics storedGraphics;

		// Token: 0x0400114D RID: 4429
		private bool inDXDraw;

		// Token: 0x0400114E RID: 4430
		private bool inNormalDraw;

		// Token: 0x0400114F RID: 4431
		private static Rectangle screenClipRect = default(Rectangle);

		// Token: 0x04001150 RID: 4432
		private Rectangle currentClip = Rectangle.Empty;

		// Token: 0x04001151 RID: 4433
		private Stack<Rectangle> clipRectStack = new Stack<Rectangle>();

		// Token: 0x04001152 RID: 4434
		private Stack<Region> clipStack = new Stack<Region>();

		// Token: 0x04001153 RID: 4435
		public static CustomSelfDrawPanel.CSDControl StaticClickedControl = null;

		// Token: 0x04001154 RID: 4436
		public CustomSelfDrawPanel.CSDControl ClickedControl;

		// Token: 0x04001155 RID: 4437
		public CustomSelfDrawPanel.CSDControl OverControl;

		// Token: 0x04001156 RID: 4438
		public CustomSelfDrawPanel.CSDControl baseControl = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x04001157 RID: 4439
		public bool ClickHandled;

		// Token: 0x04001158 RID: 4440
		private static Point mousePosition = default(Point);

		// Token: 0x04001159 RID: 4441
		private static Point clickedPosition = default(Point);

		// Token: 0x0400115A RID: 4442
		private Point lastMousePosition;

		// Token: 0x0400115B RID: 4443
		private bool mouseReallyPressed;

		// Token: 0x0400115C RID: 4444
		private List<CustomSelfDrawPanel.CSDControl> trapMouseEvents = new List<CustomSelfDrawPanel.CSDControl>();

		// Token: 0x0400115D RID: 4445
		private Point mouseDownLocation;

		// Token: 0x0400115E RID: 4446
		public bool tooltipSet;

		// Token: 0x0400115F RID: 4447
		private bool panelActive = true;

		// Token: 0x04001160 RID: 4448
		private static List<CustomSelfDrawPanel.InvalidRectpair> invalidRectList = new List<CustomSelfDrawPanel.InvalidRectpair>();

		// Token: 0x04001161 RID: 4449
		private bool selfDrawBackground;

		// Token: 0x04001162 RID: 4450
		private bool noDrawBackground;

		// Token: 0x04001163 RID: 4451
		private bool clickThru;

		// Token: 0x04001164 RID: 4452
		private IContainer components;

		// Token: 0x0200015D RID: 349
		public class CSDListItem
		{
			// Token: 0x17000095 RID: 149
			// (get) Token: 0x06000D42 RID: 3394 RVA: 0x0000FC69 File Offset: 0x0000DE69
			// (set) Token: 0x06000D43 RID: 3395 RVA: 0x0000FC71 File Offset: 0x0000DE71
			public string Text
			{
				get
				{
					return this.text;
				}
				set
				{
					this.text = value;
				}
			}

			// Token: 0x17000096 RID: 150
			// (get) Token: 0x06000D44 RID: 3396 RVA: 0x0000FC7A File Offset: 0x0000DE7A
			// (set) Token: 0x06000D45 RID: 3397 RVA: 0x0000FC82 File Offset: 0x0000DE82
			public long DataL
			{
				get
				{
					return this.data;
				}
				set
				{
					this.data = value;
				}
			}

			// Token: 0x17000097 RID: 151
			// (get) Token: 0x06000D46 RID: 3398 RVA: 0x0000FC8B File Offset: 0x0000DE8B
			// (set) Token: 0x06000D47 RID: 3399 RVA: 0x0000FC94 File Offset: 0x0000DE94
			public int Data
			{
				get
				{
					return (int)this.data;
				}
				set
				{
					this.data = (long)value;
				}
			}

			// Token: 0x04001165 RID: 4453
			private string text = "";

			// Token: 0x04001166 RID: 4454
			private long data;
		}

		// Token: 0x0200015E RID: 350
		public class CSDControl
		{
			// Token: 0x17000098 RID: 152
			// (get) Token: 0x06000D49 RID: 3401 RVA: 0x0000FCB1 File Offset: 0x0000DEB1
			// (set) Token: 0x06000D4A RID: 3402 RVA: 0x0000FCB9 File Offset: 0x0000DEB9
			public PointF RotateCentre
			{
				get
				{
					return this.rotateCentre;
				}
				set
				{
					this.rotateCentre = value;
					this.rotationCentreSet = true;
				}
			}

			// Token: 0x17000099 RID: 153
			// (get) Token: 0x06000D4B RID: 3403 RVA: 0x0000FCC9 File Offset: 0x0000DEC9
			public Rectangle Rectangle
			{
				get
				{
					return this.rect;
				}
			}

			// Token: 0x1700009A RID: 154
			// (get) Token: 0x06000D4C RID: 3404 RVA: 0x0000FCD1 File Offset: 0x0000DED1
			// (set) Token: 0x06000D4D RID: 3405 RVA: 0x0000FCD9 File Offset: 0x0000DED9
			public virtual Point Position
			{
				get
				{
					return this.position;
				}
				set
				{
					this.position = value;
					this.rect.Location = value;
				}
			}

			// Token: 0x1700009B RID: 155
			// (get) Token: 0x06000D4E RID: 3406 RVA: 0x0000FCEE File Offset: 0x0000DEEE
			// (set) Token: 0x06000D4F RID: 3407 RVA: 0x0000FCFB File Offset: 0x0000DEFB
			public int X
			{
				get
				{
					return this.position.X;
				}
				set
				{
					this.position.X = value;
					this.rect.X = value;
				}
			}

			// Token: 0x1700009C RID: 156
			// (get) Token: 0x06000D50 RID: 3408 RVA: 0x0000FD15 File Offset: 0x0000DF15
			// (set) Token: 0x06000D51 RID: 3409 RVA: 0x0000FD22 File Offset: 0x0000DF22
			public int Y
			{
				get
				{
					return this.position.Y;
				}
				set
				{
					this.position.Y = value;
					this.rect.Y = value;
				}
			}

			// Token: 0x1700009D RID: 157
			// (get) Token: 0x06000D52 RID: 3410 RVA: 0x0000FD3C File Offset: 0x0000DF3C
			// (set) Token: 0x06000D53 RID: 3411 RVA: 0x0000FD44 File Offset: 0x0000DF44
			public bool Visible
			{
				get
				{
					return this.visible;
				}
				set
				{
					if (this.visible != value)
					{
						this.invalidate();
					}
					this.visible = value;
				}
			}

			// Token: 0x1700009E RID: 158
			// (get) Token: 0x06000D54 RID: 3412 RVA: 0x0000FD5C File Offset: 0x0000DF5C
			// (set) Token: 0x06000D55 RID: 3413 RVA: 0x0000FD64 File Offset: 0x0000DF64
			public virtual bool Enabled
			{
				get
				{
					return this.enabled;
				}
				set
				{
					if (this.enabled != value)
					{
						this.invalidate();
					}
					this.enabled = value;
				}
			}

			// Token: 0x1700009F RID: 159
			// (get) Token: 0x06000D56 RID: 3414 RVA: 0x0000FD7C File Offset: 0x0000DF7C
			// (set) Token: 0x06000D57 RID: 3415 RVA: 0x0000FD84 File Offset: 0x0000DF84
			public virtual Size Size
			{
				get
				{
					return this.size;
				}
				set
				{
					this.size = value;
					this.rect.Size = value;
				}
			}

			// Token: 0x170000A0 RID: 160
			// (get) Token: 0x06000D58 RID: 3416 RVA: 0x0000FD99 File Offset: 0x0000DF99
			// (set) Token: 0x06000D59 RID: 3417 RVA: 0x0000FDA6 File Offset: 0x0000DFA6
			public int Width
			{
				get
				{
					return this.size.Width;
				}
				set
				{
					this.size.Width = value;
					this.rect.Width = value;
				}
			}

			// Token: 0x170000A1 RID: 161
			// (get) Token: 0x06000D5A RID: 3418 RVA: 0x0000FDC0 File Offset: 0x0000DFC0
			// (set) Token: 0x06000D5B RID: 3419 RVA: 0x0000FDCD File Offset: 0x0000DFCD
			public int Height
			{
				get
				{
					return this.size.Height;
				}
				set
				{
					this.size.Height = value;
					this.rect.Height = value;
				}
			}

			// Token: 0x170000A2 RID: 162
			// (get) Token: 0x06000D5C RID: 3420 RVA: 0x0000FDE7 File Offset: 0x0000DFE7
			// (set) Token: 0x06000D5D RID: 3421 RVA: 0x0000FDEF File Offset: 0x0000DFEF
			public Rectangle ClipRect
			{
				get
				{
					return this.clipRect;
				}
				set
				{
					this.clipRect = value;
				}
			}

			// Token: 0x170000A3 RID: 163
			// (get) Token: 0x06000D5E RID: 3422 RVA: 0x0000FDF8 File Offset: 0x0000DFF8
			// (set) Token: 0x06000D5F RID: 3423 RVA: 0x0000FE00 File Offset: 0x0000E000
			public virtual bool ClipVisible
			{
				get
				{
					return this.clipVisible;
				}
				set
				{
					this.clipVisible = value;
				}
			}

			// Token: 0x170000A4 RID: 164
			// (get) Token: 0x06000D60 RID: 3424 RVA: 0x0000FE09 File Offset: 0x0000E009
			// (set) Token: 0x06000D61 RID: 3425 RVA: 0x0000FE11 File Offset: 0x0000E011
			public Rectangle ClickArea
			{
				get
				{
					return this.clickArea;
				}
				set
				{
					this.clickArea = value;
				}
			}

			// Token: 0x170000A5 RID: 165
			// (get) Token: 0x06000D62 RID: 3426 RVA: 0x0000FE1A File Offset: 0x0000E01A
			// (set) Token: 0x06000D63 RID: 3427 RVA: 0x0000FE22 File Offset: 0x0000E022
			public double Scale
			{
				get
				{
					return this.scale;
				}
				set
				{
					this.scale = value;
				}
			}

			// Token: 0x170000A6 RID: 166
			// (get) Token: 0x06000D64 RID: 3428 RVA: 0x0000FE2B File Offset: 0x0000E02B
			// (set) Token: 0x06000D65 RID: 3429 RVA: 0x0000FE33 File Offset: 0x0000E033
			public int CustomTooltipID
			{
				get
				{
					return this.customTooltipID;
				}
				set
				{
					this.customTooltipID = value;
				}
			}

			// Token: 0x170000A7 RID: 167
			// (get) Token: 0x06000D66 RID: 3430 RVA: 0x0000FE3C File Offset: 0x0000E03C
			// (set) Token: 0x06000D67 RID: 3431 RVA: 0x0000FE44 File Offset: 0x0000E044
			public int CustomTooltipData
			{
				get
				{
					return this.customTooltipData;
				}
				set
				{
					this.customTooltipData = value;
				}
			}

			// Token: 0x170000A8 RID: 168
			// (get) Token: 0x06000D68 RID: 3432 RVA: 0x0000FE4D File Offset: 0x0000E04D
			// (set) Token: 0x06000D69 RID: 3433 RVA: 0x0000FE55 File Offset: 0x0000E055
			public int Tooltip
			{
				get
				{
					return this.tooltip;
				}
				set
				{
					this.tooltip = value;
					this.tooltipActive = true;
				}
			}

			// Token: 0x170000A9 RID: 169
			// (get) Token: 0x06000D6A RID: 3434 RVA: 0x0000FE65 File Offset: 0x0000E065
			// (set) Token: 0x06000D6B RID: 3435 RVA: 0x0000FE6D File Offset: 0x0000E06D
			public string sTag
			{
				get
				{
					return this.soundTag;
				}
				set
				{
					this.soundTag = value;
				}
			}

			// Token: 0x170000AA RID: 170
			// (get) Token: 0x06000D6C RID: 3436 RVA: 0x0000FE76 File Offset: 0x0000E076
			// (set) Token: 0x06000D6D RID: 3437 RVA: 0x0000FE7E File Offset: 0x0000E07E
			public object Tag
			{
				get
				{
					return this.tag;
				}
				set
				{
					this.tag = value;
				}
			}

			// Token: 0x170000AB RID: 171
			// (get) Token: 0x06000D6E RID: 3438 RVA: 0x0000FE87 File Offset: 0x0000E087
			// (set) Token: 0x06000D6F RID: 3439 RVA: 0x0000FE8F File Offset: 0x0000E08F
			public int Data
			{
				get
				{
					return this.dataValue;
				}
				set
				{
					this.dataValue = value;
				}
			}

			// Token: 0x170000AC RID: 172
			// (get) Token: 0x06000D70 RID: 3440 RVA: 0x0000FE98 File Offset: 0x0000E098
			// (set) Token: 0x06000D71 RID: 3441 RVA: 0x0000FEA0 File Offset: 0x0000E0A0
			public long DataL
			{
				get
				{
					return this.dataValueL;
				}
				set
				{
					this.dataValueL = value;
				}
			}

			// Token: 0x170000AD RID: 173
			// (get) Token: 0x06000D72 RID: 3442 RVA: 0x0000FEA9 File Offset: 0x0000E0A9
			// (set) Token: 0x06000D73 RID: 3443 RVA: 0x0000FEB1 File Offset: 0x0000E0B1
			public object dataObject
			{
				get
				{
					return this.dataValueObject;
				}
				set
				{
					this.dataValueObject = value;
				}
			}

			// Token: 0x170000AE RID: 174
			// (get) Token: 0x06000D74 RID: 3444 RVA: 0x0000FEBA File Offset: 0x0000E0BA
			public Point LastRelativeMousePos
			{
				get
				{
					return this.lastRelativeMousePos;
				}
			}

			// Token: 0x170000AF RID: 175
			// (get) Token: 0x06000D75 RID: 3445 RVA: 0x0000FEC2 File Offset: 0x0000E0C2
			// (set) Token: 0x06000D76 RID: 3446 RVA: 0x0000FECA File Offset: 0x0000E0CA
			public bool MouseDownFlag
			{
				get
				{
					return this.mouseDownFlag;
				}
				set
				{
					this.mouseDownFlag = value;
				}
			}

			// Token: 0x170000B0 RID: 176
			// (get) Token: 0x06000D77 RID: 3447 RVA: 0x0000FED3 File Offset: 0x0000E0D3
			public CustomSelfDrawPanel.CSDControl Parent
			{
				get
				{
					return this.parent;
				}
			}

			// Token: 0x170000B1 RID: 177
			// (get) Token: 0x06000D78 RID: 3448 RVA: 0x0000FEDB File Offset: 0x0000E0DB
			public CustomSelfDrawPanel csd
			{
				get
				{
					if (this.m_csd != null)
					{
						return this.m_csd;
					}
					if (this.parent != null)
					{
						this.m_csd = this.parent.csd;
						return this.m_csd;
					}
					return null;
				}
			}

			// Token: 0x170000B2 RID: 178
			// (get) Token: 0x06000D79 RID: 3449 RVA: 0x0000FF0D File Offset: 0x0000E10D
			public List<CustomSelfDrawPanel.CSDControl> Controls
			{
				get
				{
					return this.csdControls;
				}
			}

			// Token: 0x06000D7A RID: 3450 RVA: 0x000F7A68 File Offset: 0x000F5C68
			public bool getToolTip(Point mousePos, ref int data)
			{
				bool result = false;
				if (this.Visible && this.Enabled)
				{
					mousePos = new Point((int)((double)mousePos.X / this.Scale), (int)((double)mousePos.Y / this.Scale));
					Point point = new Point(mousePos.X - this.X, mousePos.Y - this.Y);
					if (!this.ClipRect.IsEmpty && !this.ClipRect.Contains(point))
					{
						return false;
					}
					foreach (CustomSelfDrawPanel.CSDControl csdcontrol in this.csdControls)
					{
						if (csdcontrol.getToolTip(point, ref data))
						{
							result = true;
						}
					}
					if (this.tooltipActive && this.mouseOver(mousePos))
					{
						result = true;
						data = this.tooltip;
					}
				}
				return result;
			}

			// Token: 0x06000D7B RID: 3451 RVA: 0x000F7B64 File Offset: 0x000F5D64
			public void setChildrensScale(double scale)
			{
				foreach (CustomSelfDrawPanel.CSDControl csdcontrol in this.csdControls)
				{
					csdcontrol.setScale(scale);
				}
			}

			// Token: 0x06000D7C RID: 3452 RVA: 0x000F7BB8 File Offset: 0x000F5DB8
			public void setScale(double scale)
			{
				this.Scale = scale;
				foreach (CustomSelfDrawPanel.CSDControl csdcontrol in this.csdControls)
				{
					csdcontrol.setScale(scale);
				}
			}

			// Token: 0x06000D7D RID: 3453 RVA: 0x0000FF15 File Offset: 0x0000E115
			public void setClickDelegate(CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate newDelegate)
			{
				this.clickDelegate = newDelegate;
			}

			// Token: 0x06000D7E RID: 3454 RVA: 0x0000FF1E File Offset: 0x0000E11E
			public void setClickDelegate(CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate newDelegate, string tag)
			{
				this.clickDelegate = newDelegate;
				this.sTag = tag;
			}

			// Token: 0x06000D7F RID: 3455 RVA: 0x0000FF2E File Offset: 0x0000E12E
			public void setRightClickDelegate(CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate newDelegate)
			{
				this.rightClickDelegate = newDelegate;
			}

			// Token: 0x06000D80 RID: 3456 RVA: 0x000F7C14 File Offset: 0x000F5E14
			public bool mouseOver(Point mousePos)
			{
				Rectangle rectangle = this.rect;
				if (this.Scale != 1.0)
				{
					rectangle.Width = (int)((double)rectangle.Width * this.Scale);
					rectangle.Height = (int)((double)rectangle.Height * this.Scale);
				}
				if (!this.clickArea.IsEmpty)
				{
					rectangle.Width = this.clickArea.Width;
					rectangle.Height = this.clickArea.Height;
					rectangle.X += this.clickArea.X;
					rectangle.Y += this.clickArea.Y;
				}
				return rectangle.Contains(mousePos);
			}

			// Token: 0x06000D81 RID: 3457 RVA: 0x000F7CD4 File Offset: 0x000F5ED4
			public bool parentClicked(Point mousePos)
			{
				if (this.Visible && this.Enabled)
				{
					Point point = new Point(mousePos.X - this.X, mousePos.Y - this.Y);
					if (!this.ClipRect.IsEmpty && !this.ClipRect.Contains(point))
					{
						return false;
					}
					for (int i = this.csdControls.Count - 1; i >= 0; i--)
					{
						if (this.csdControls[i].parentClicked(point))
						{
							return true;
						}
					}
					if (this.clickDelegate != null && this.mouseOver(mousePos))
					{
						this.csd.ClickedControl = this;
						CustomSelfDrawPanel.StaticClickedControl = this;
						this.lastRelativeMousePos = mousePos;
						if (this.sTag.Length > 0)
						{
							GameEngine.Instance.playInterfaceSound(this.sTag);
						}
						this.clickDelegate();
						return true;
					}
				}
				return false;
			}

			// Token: 0x06000D82 RID: 3458 RVA: 0x000F7DC4 File Offset: 0x000F5FC4
			public bool parentRightClicked(Point mousePos)
			{
				if (this.Visible && this.Enabled)
				{
					Point point = new Point(mousePos.X - this.X, mousePos.Y - this.Y);
					if (!this.ClipRect.IsEmpty && !this.ClipRect.Contains(point))
					{
						return false;
					}
					for (int i = this.csdControls.Count - 1; i >= 0; i--)
					{
						if (this.csdControls[i].parentRightClicked(point))
						{
							return true;
						}
					}
					if (this.rightClickDelegate != null && this.mouseOver(mousePos))
					{
						this.csd.ClickedControl = this;
						this.lastRelativeMousePos = mousePos;
						if (this.sTag.Length > 0)
						{
							GameEngine.Instance.playInterfaceSound(this.sTag);
						}
						this.rightClickDelegate();
						return true;
					}
				}
				return false;
			}

			// Token: 0x06000D83 RID: 3459 RVA: 0x0000FF37 File Offset: 0x0000E137
			public void setMouseOverDelegate(CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate overDelegate, CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate leaveDelegate)
			{
				this.mouseOverDelegate = overDelegate;
				this.mouseLeaveDelegate = leaveDelegate;
			}

			// Token: 0x06000D84 RID: 3460 RVA: 0x000F7EAC File Offset: 0x000F60AC
			public CustomSelfDrawPanel.CSDControl parentMouseOver(Point mousePos)
			{
				CustomSelfDrawPanel.CSDControl csdcontrol = null;
				if (this.Visible && this.Enabled)
				{
					Point point = new Point(mousePos.X - this.X, mousePos.Y - this.Y);
					if (!this.ClipRect.IsEmpty && !this.ClipRect.Contains(point))
					{
						return null;
					}
					for (int i = this.csdControls.Count - 1; i >= 0; i--)
					{
						csdcontrol = this.csdControls[i].parentMouseOver(point);
						if (csdcontrol != null)
						{
							return csdcontrol;
						}
					}
					if (this.customTooltipID != 0)
					{
						if (this.mouseOver(mousePos))
						{
							if (!this.csd.tooltipSet)
							{
								this.csd.tooltipSet = true;
								CustomTooltipManager.MouseEnterTooltipArea(this.customTooltipID, this.customTooltipData, this.csd.FindForm());
								this.customTooltipWasOver = true;
							}
						}
						else if (this.customTooltipWasOver)
						{
							this.customTooltipWasOver = false;
							CustomTooltipManager.MouseLeaveTooltipArea();
						}
					}
					if (this.mouseOverDelegate != null && this.mouseOver(mousePos))
					{
						if (this.csd.OverControl != this)
						{
							this.csd.handleMouseLeave(this);
							this.csd.OverControl = this;
						}
						if (!this.mouseOverFlag)
						{
							this.mouseOverFlag = true;
							this.lastRelativeMousePos = mousePos;
							this.mouseOverDelegate();
						}
						return this;
					}
				}
				return csdcontrol;
			}

			// Token: 0x06000D85 RID: 3461 RVA: 0x000F8008 File Offset: 0x000F6208
			public void handleMouseLeave(CustomSelfDrawPanel.CSDControl overControl)
			{
				foreach (CustomSelfDrawPanel.CSDControl csdcontrol in this.csdControls)
				{
					csdcontrol.handleMouseLeave(overControl);
				}
				if (!this.mouseOverFlag || this == overControl)
				{
					return;
				}
				this.mouseOverFlag = false;
				if (this.mouseDownFlag)
				{
					this.mouseDownFlag = false;
					if (this.mouseUpDelegate != null)
					{
						this.mouseUpDelegate();
					}
				}
				if (this.mouseLeaveDelegate != null)
				{
					this.mouseLeaveDelegate();
				}
				this.csd.OverControl = null;
			}

			// Token: 0x06000D86 RID: 3462 RVA: 0x00007CE0 File Offset: 0x00005EE0
			public virtual void mouseEventTrapped()
			{
			}

			// Token: 0x06000D87 RID: 3463 RVA: 0x0000FF47 File Offset: 0x0000E147
			public void setMouseDownDelegate(CustomSelfDrawPanel.CSDControl.CSD_MouseDownDelegate downDelegate, CustomSelfDrawPanel.CSDControl.CSD_MouseDownDelegate upDelegate)
			{
				this.mouseDownDelegate = downDelegate;
				this.mouseUpDelegate = upDelegate;
			}

			// Token: 0x06000D88 RID: 3464 RVA: 0x000F80B0 File Offset: 0x000F62B0
			public CustomSelfDrawPanel.CSDControl parentMouseDown(Point mousePos)
			{
				CustomSelfDrawPanel.CSDControl csdcontrol = null;
				if (this.Visible && this.Enabled)
				{
					Point point = new Point(mousePos.X - this.X, mousePos.Y - this.Y);
					if (!this.ClipRect.IsEmpty && !this.ClipRect.Contains(point))
					{
						return null;
					}
					for (int i = this.csdControls.Count - 1; i >= 0; i--)
					{
						csdcontrol = this.csdControls[i].parentMouseDown(point);
						if (csdcontrol != null)
						{
							return csdcontrol;
						}
					}
					if (this.mouseDownDelegate != null)
					{
						if (this.mouseOver(mousePos))
						{
							CustomSelfDrawPanel.StaticClickedControl = this;
							if (!this.mouseDownFlag)
							{
								this.mouseDownFlag = true;
								this.lastRelativeMousePos = mousePos;
								this.mouseDownDelegate();
							}
							if (!this.clickThrough)
							{
								return this;
							}
						}
						else
						{
							this.mouseDownFlag = false;
						}
					}
				}
				return csdcontrol;
			}

			// Token: 0x06000D89 RID: 3465 RVA: 0x00007CE0 File Offset: 0x00005EE0
			public virtual void mouseUpOutside()
			{
			}

			// Token: 0x06000D8A RID: 3466 RVA: 0x000F8198 File Offset: 0x000F6398
			public CustomSelfDrawPanel.CSDControl parentMouseUp(Point mousePos)
			{
				CustomSelfDrawPanel.CSDControl csdcontrol = null;
				if (this.Visible)
				{
					Point point = new Point(mousePos.X - this.X, mousePos.Y - this.Y);
					if (!this.ClipRect.IsEmpty && !this.ClipRect.Contains(point))
					{
						return null;
					}
					for (int i = this.csdControls.Count - 1; i >= 0; i--)
					{
						csdcontrol = this.csdControls[i].parentMouseUp(point);
						if (csdcontrol != null)
						{
							return csdcontrol;
						}
					}
					if (this.mouseUpDelegate != null && this.mouseOver(mousePos))
					{
						if (this.mouseDownFlag)
						{
							this.mouseDownFlag = false;
							this.lastRelativeMousePos = mousePos;
							this.mouseUpDelegate();
						}
						return this;
					}
				}
				return csdcontrol;
			}

			// Token: 0x06000D8B RID: 3467 RVA: 0x0000FF57 File Offset: 0x0000E157
			public void setMouseWheelDelegate(CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate newDelegate)
			{
				this.mouseWheelDelegate = newDelegate;
			}

			// Token: 0x06000D8C RID: 3468 RVA: 0x000F8260 File Offset: 0x000F6460
			public CustomSelfDrawPanel.CSDControl parentMouseWheel(Point mousePos, int delta)
			{
				CustomSelfDrawPanel.CSDControl csdcontrol = null;
				if (this.Visible && this.Enabled)
				{
					Point point = new Point(mousePos.X - this.X, mousePos.Y - this.Y);
					if (!this.ClipRect.IsEmpty && !this.ClipRect.Contains(point))
					{
						return null;
					}
					for (int i = this.csdControls.Count - 1; i >= 0; i--)
					{
						csdcontrol = this.csdControls[i].parentMouseWheel(point, delta);
						if (csdcontrol != null)
						{
							return csdcontrol;
						}
					}
					if (this.mouseWheelDelegate != null && this.mouseOver(mousePos))
					{
						this.lastRelativeMousePos = mousePos;
						this.mouseWheelDelegate(delta);
						return this;
					}
				}
				return csdcontrol;
			}

			// Token: 0x06000D8D RID: 3469 RVA: 0x0000FF60 File Offset: 0x0000E160
			public void setCustomSelfDrawPanel(CustomSelfDrawPanel newCSD)
			{
				this.m_csd = newCSD;
			}

			// Token: 0x06000D8E RID: 3470 RVA: 0x0000FF69 File Offset: 0x0000E169
			public void setParent(CustomSelfDrawPanel.CSDControl newParent)
			{
				this.parent = newParent;
			}

			// Token: 0x06000D8F RID: 3471 RVA: 0x000F8324 File Offset: 0x000F6524
			public virtual void clearControls()
			{
				for (int i = 0; i < this.csdControls.Count; i++)
				{
					this.csdControls[i].clearControls();
					this.csdControls[i] = null;
				}
				this.csdControls.Clear();
				this.onClear();
			}

			// Token: 0x06000D90 RID: 3472 RVA: 0x00007CE0 File Offset: 0x00005EE0
			public virtual void onClear()
			{
			}

			// Token: 0x06000D91 RID: 3473 RVA: 0x0000FF72 File Offset: 0x0000E172
			public void clearDirectControlsOnly()
			{
				this.csdControls.Clear();
			}

			// Token: 0x06000D92 RID: 3474 RVA: 0x000F8378 File Offset: 0x000F6578
			public void addControl(CustomSelfDrawPanel.CSDControl control)
			{
				if (control.parent != null && control.parent.csdControls.Contains(control))
				{
					control.parent.removeControl(control);
				}
				control.m_csd = this.csd;
				control.parent = this;
				this.csdControls.Add(control);
				control.addedToParent();
			}

			// Token: 0x06000D93 RID: 3475 RVA: 0x000F83D4 File Offset: 0x000F65D4
			public void addControlAtBack(CustomSelfDrawPanel.CSDControl control)
			{
				if (control.parent != null && control.parent.csdControls.Contains(control))
				{
					control.parent.removeControl(control);
				}
				control.m_csd = this.csd;
				control.parent = this;
				this.csdControls.Insert(0, control);
				control.addedToParent();
			}

			// Token: 0x06000D94 RID: 3476 RVA: 0x00007CE0 File Offset: 0x00005EE0
			public virtual void addedToParent()
			{
			}

			// Token: 0x06000D95 RID: 3477 RVA: 0x0000FF7F File Offset: 0x0000E17F
			public void removeControl(CustomSelfDrawPanel.CSDControl control)
			{
				if (control != null)
				{
					this.csdControls.Remove(control);
					control.parent = null;
				}
			}

			// Token: 0x06000D96 RID: 3478 RVA: 0x000F8430 File Offset: 0x000F6630
			public void invalidate()
			{
				if (this.csd != null)
				{
					Point point = new Point(this.X, this.Y);
					for (CustomSelfDrawPanel.CSDControl csdcontrol = this.parent; csdcontrol != null; csdcontrol = csdcontrol.parent)
					{
						point.X += csdcontrol.X;
						point.Y += csdcontrol.Y;
					}
					Rectangle rc = new Rectangle(point.X, point.Y, this.Width, this.Height);
					if (!this.csd.inNormalDraw)
					{
						this.csd.Invalidate(rc);
						return;
					}
					this.csd.InvalidateCached(rc);
				}
			}

			// Token: 0x06000D97 RID: 3479 RVA: 0x000F84E0 File Offset: 0x000F66E0
			public void invalidateXtra()
			{
				if (this.csd != null)
				{
					Point point = new Point(this.X, this.Y);
					for (CustomSelfDrawPanel.CSDControl csdcontrol = this.parent; csdcontrol != null; csdcontrol = csdcontrol.parent)
					{
						point.X += csdcontrol.X;
						point.Y += csdcontrol.Y;
					}
					Rectangle rc = new Rectangle(point.X - 10, point.Y - 10, this.Width + 20, this.Height + 20);
					this.csd.Invalidate(rc);
				}
			}

			// Token: 0x06000D98 RID: 3480 RVA: 0x000F8580 File Offset: 0x000F6780
			public Point getPanelPosition()
			{
				Point result = new Point(this.X, this.Y);
				for (CustomSelfDrawPanel.CSDControl csdcontrol = this.parent; csdcontrol != null; csdcontrol = csdcontrol.parent)
				{
					result.X += csdcontrol.X;
					result.Y += csdcontrol.Y;
				}
				return result;
			}

			// Token: 0x06000D99 RID: 3481 RVA: 0x000F85DC File Offset: 0x000F67DC
			public void drawControls(Point parentLocation)
			{
				if (!this.Visible)
				{
					return;
				}
				if (this.clipVisible)
				{
					Rectangle currentClip = this.csd.getCurrentClip();
					if (currentClip != Rectangle.Empty)
					{
						Point location = (this.Scale == 1.0) ? new Point(parentLocation.X + this.X, parentLocation.Y + this.Y) : new Point(parentLocation.X + (int)((double)this.X * this.scale), parentLocation.Y + (int)((double)this.Y * this.scale));
						if (Rectangle.Intersect(currentClip, new Rectangle(location, this.Size)) == Rectangle.Empty || Rectangle.Intersect(CustomSelfDrawPanel.screenClipRect, new Rectangle(location, this.Size)) == Rectangle.Empty)
						{
							return;
						}
					}
				}
				if (this.clipRect != Rectangle.Empty)
				{
					Rectangle clipRegion = new Rectangle(this.clipRect.X + parentLocation.X + this.X, this.clipRect.Y + parentLocation.Y + this.Y, this.clipRect.Width, this.clipRect.Height);
					this.csd.setClipRegion(clipRegion);
				}
				this.draw(parentLocation);
				Point parentLocation2 = (this.Scale == 1.0) ? new Point(parentLocation.X + this.X, parentLocation.Y + this.Y) : new Point(parentLocation.X + (int)((double)this.X * this.scale), parentLocation.Y + (int)((double)this.Y * this.scale));
				foreach (CustomSelfDrawPanel.CSDControl csdcontrol in this.csdControls)
				{
					csdcontrol.drawControls(parentLocation2);
				}
				if (this.clipRect != Rectangle.Empty)
				{
					this.csd.restoreClipRegion();
				}
			}

			// Token: 0x06000D9A RID: 3482 RVA: 0x00007CE0 File Offset: 0x00005EE0
			public virtual void draw(Point parentLocation)
			{
			}

			// Token: 0x06000D9B RID: 3483 RVA: 0x00007CE0 File Offset: 0x00005EE0
			public virtual void unityOverridableUpdate(Point parentLocation)
			{
			}

			// Token: 0x06000D9C RID: 3484 RVA: 0x000F8808 File Offset: 0x000F6A08
			public void fitContents()
			{
				foreach (CustomSelfDrawPanel.CSDControl csdcontrol in this.Controls)
				{
					this.Width = Math.Max(this.Width, csdcontrol.Rectangle.Right);
					this.Height = Math.Max(this.Height, csdcontrol.Rectangle.Bottom);
				}
			}

			// Token: 0x04001167 RID: 4455
			public float Rotate;

			// Token: 0x04001168 RID: 4456
			private PointF rotateCentre = new Point(-1000, -1000);

			// Token: 0x04001169 RID: 4457
			private bool rotationCentreSet;

			// Token: 0x0400116A RID: 4458
			private Point position = new Point(0, 0);

			// Token: 0x0400116B RID: 4459
			private Rectangle rect = new Rectangle(0, 0, 1, 1);

			// Token: 0x0400116C RID: 4460
			private bool visible = true;

			// Token: 0x0400116D RID: 4461
			private bool enabled = true;

			// Token: 0x0400116E RID: 4462
			private Size size = new Size(1, 1);

			// Token: 0x0400116F RID: 4463
			private Rectangle clipRect = Rectangle.Empty;

			// Token: 0x04001170 RID: 4464
			private bool clipVisible;

			// Token: 0x04001171 RID: 4465
			private Rectangle clickArea = Rectangle.Empty;

			// Token: 0x04001172 RID: 4466
			private double scale = 1.0;

			// Token: 0x04001173 RID: 4467
			private int customTooltipID;

			// Token: 0x04001174 RID: 4468
			private int customTooltipData;

			// Token: 0x04001175 RID: 4469
			private bool customTooltipWasOver;

			// Token: 0x04001176 RID: 4470
			private bool tooltipActive;

			// Token: 0x04001177 RID: 4471
			private int tooltip;

			// Token: 0x04001178 RID: 4472
			private string soundTag = "";

			// Token: 0x04001179 RID: 4473
			protected object tag;

			// Token: 0x0400117A RID: 4474
			protected int dataValue;

			// Token: 0x0400117B RID: 4475
			protected long dataValueL;

			// Token: 0x0400117C RID: 4476
			protected object dataValueObject;

			// Token: 0x0400117D RID: 4477
			private Point lastRelativeMousePos;

			// Token: 0x0400117E RID: 4478
			private CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate clickDelegate;

			// Token: 0x0400117F RID: 4479
			private CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate rightClickDelegate;

			// Token: 0x04001180 RID: 4480
			protected bool mouseOverFlag;

			// Token: 0x04001181 RID: 4481
			protected CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate mouseOverDelegate;

			// Token: 0x04001182 RID: 4482
			protected CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate mouseLeaveDelegate;

			// Token: 0x04001183 RID: 4483
			protected bool mouseDownFlag;

			// Token: 0x04001184 RID: 4484
			protected CustomSelfDrawPanel.CSDControl.CSD_MouseDownDelegate mouseDownDelegate;

			// Token: 0x04001185 RID: 4485
			protected CustomSelfDrawPanel.CSDControl.CSD_MouseDownDelegate mouseUpDelegate;

			// Token: 0x04001186 RID: 4486
			public bool clickThrough;

			// Token: 0x04001187 RID: 4487
			protected CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate mouseWheelDelegate;

			// Token: 0x04001188 RID: 4488
			public List<CustomSelfDrawPanel.CSDControl> csdControls = new List<CustomSelfDrawPanel.CSDControl>();

			// Token: 0x04001189 RID: 4489
			protected CustomSelfDrawPanel.CSDControl parent;

			// Token: 0x0400118A RID: 4490
			protected CustomSelfDrawPanel m_csd;

			// Token: 0x0200015F RID: 351
			// (Invoke) Token: 0x06000D9F RID: 3487
			public delegate void CSD_ValueChangedDelegate();

			// Token: 0x02000160 RID: 352
			// (Invoke) Token: 0x06000DA3 RID: 3491
			public delegate void CSD_ScrollBarChangedDelegate();

			// Token: 0x02000161 RID: 353
			// (Invoke) Token: 0x06000DA7 RID: 3495
			public delegate void CSD_ClickDelegate();

			// Token: 0x02000162 RID: 354
			// (Invoke) Token: 0x06000DAB RID: 3499
			public delegate void CSD_MouseOverDelegate();

			// Token: 0x02000163 RID: 355
			// (Invoke) Token: 0x06000DAF RID: 3503
			public delegate void CSD_MouseDownDelegate();

			// Token: 0x02000164 RID: 356
			// (Invoke) Token: 0x06000DB3 RID: 3507
			public delegate void CSD_MouseWheelDelegate(int delta);
		}

		// Token: 0x02000165 RID: 357
		private class CSDListEntry : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x170000B3 RID: 179
			// (set) Token: 0x06000DB6 RID: 3510 RVA: 0x0000FF98 File Offset: 0x0000E198
			public Color BodyColor
			{
				set
				{
					if (this.setupComplete)
					{
						if (this.bodyColor != value)
						{
							this.main.invalidate();
						}
						this.main.FillColor = value;
					}
					this.bodyColor = value;
				}
			}

			// Token: 0x170000B4 RID: 180
			// (set) Token: 0x06000DB7 RID: 3511 RVA: 0x0000FFCE File Offset: 0x0000E1CE
			public Color LineColor
			{
				set
				{
					if (this.setupComplete)
					{
						if (this.lineColor != value)
						{
							this.line.invalidate();
						}
						this.line.FillColor = value;
					}
					this.lineColor = value;
				}
			}

			// Token: 0x170000B5 RID: 181
			// (set) Token: 0x06000DB8 RID: 3512 RVA: 0x00010004 File Offset: 0x0000E204
			public Color OverColor
			{
				set
				{
					this.overColor = value;
				}
			}

			// Token: 0x170000B6 RID: 182
			// (set) Token: 0x06000DB9 RID: 3513 RVA: 0x0001000D File Offset: 0x0000E20D
			public Color LineOverColor
			{
				set
				{
					this.lineOverColor = value;
				}
			}

			// Token: 0x170000B7 RID: 183
			// (get) Token: 0x06000DBA RID: 3514 RVA: 0x00010016 File Offset: 0x0000E216
			public CustomSelfDrawPanel.CSDLabel Text
			{
				get
				{
					return this.textLabel;
				}
			}

			// Token: 0x06000DBB RID: 3515 RVA: 0x000F8934 File Offset: 0x000F6B34
			public void reset()
			{
				this.bodyColor = CustomSelfDrawPanel.MailBodyColor;
				this.lineColor = CustomSelfDrawPanel.MailLineColor;
				this.overColor = CustomSelfDrawPanel.MailOverColor;
				this.lineOverColor = CustomSelfDrawPanel.MailLineOverColor;
				this.main.FillColor = this.bodyColor;
				this.line.FillColor = this.lineColor;
			}

			// Token: 0x06000DBC RID: 3516 RVA: 0x000F8990 File Offset: 0x000F6B90
			public void setup()
			{
				this.main.Size = new Size(this.Size.Width, this.Size.Height - 1);
				this.main.FillColor = this.bodyColor;
				this.line.Position = new Point(0, this.Size.Height - 1);
				this.line.Size = new Size(this.Size.Width, 1);
				this.line.FillColor = this.lineColor;
				this.textLabel.Position = new Point(3, 2);
				this.textLabel.Size = new Size(259, this.Size.Height - 4);
				this.textLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				base.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.mouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.mouseLeave));
				base.addControl(this.main);
				base.addControl(this.line);
				this.main.addControl(this.textLabel);
				this.setupComplete = true;
			}

			// Token: 0x06000DBD RID: 3517 RVA: 0x000F8AC0 File Offset: 0x000F6CC0
			private void mouseOver()
			{
				if (this.textLabel.Text.Length > 0 && this.parent.Enabled)
				{
					this.main.FillColor = this.overColor;
					this.line.FillColor = this.lineOverColor;
				}
			}

			// Token: 0x06000DBE RID: 3518 RVA: 0x0001001E File Offset: 0x0000E21E
			private void mouseLeave()
			{
				this.main.FillColor = this.bodyColor;
				this.line.FillColor = this.lineColor;
				base.invalidate();
			}

			// Token: 0x0400118B RID: 4491
			private bool setupComplete;

			// Token: 0x0400118C RID: 4492
			private CustomSelfDrawPanel.CSDFill main = new CustomSelfDrawPanel.CSDFill();

			// Token: 0x0400118D RID: 4493
			private CustomSelfDrawPanel.CSDFill line = new CustomSelfDrawPanel.CSDFill();

			// Token: 0x0400118E RID: 4494
			private CustomSelfDrawPanel.CSDLabel textLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400118F RID: 4495
			private Color bodyColor = CustomSelfDrawPanel.MailBodyColor;

			// Token: 0x04001190 RID: 4496
			private Color lineColor = CustomSelfDrawPanel.MailLineColor;

			// Token: 0x04001191 RID: 4497
			private Color overColor = CustomSelfDrawPanel.MailOverColor;

			// Token: 0x04001192 RID: 4498
			private Color lineOverColor = CustomSelfDrawPanel.MailLineOverColor;
		}

		// Token: 0x02000166 RID: 358
		public class CSDListBox : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x170000B8 RID: 184
			// (get) Token: 0x06000DC0 RID: 3520 RVA: 0x0000A849 File Offset: 0x00008A49
			// (set) Token: 0x06000DC1 RID: 3521 RVA: 0x000F8B70 File Offset: 0x000F6D70
			public override bool Enabled
			{
				get
				{
					return true;
				}
				set
				{
					if (this.created)
					{
						if (this.entries[0].Enabled != value)
						{
							base.invalidate();
						}
						CustomSelfDrawPanel.CSDListEntry[] array = this.entries;
						foreach (CustomSelfDrawPanel.CSDListEntry csdlistEntry in array)
						{
							csdlistEntry.Enabled = value;
						}
					}
				}
			}

			// Token: 0x06000DC2 RID: 3522 RVA: 0x000F8BC0 File Offset: 0x000F6DC0
			public void Create(int numRows, int elementHeight)
			{
				if (base.csd == null)
				{
					return;
				}
				if (!this.created)
				{
					this.created = true;
					this.m_numRows = numRows;
					this.entries = new CustomSelfDrawPanel.CSDListEntry[numRows];
					for (int i = 0; i < numRows; i++)
					{
						CustomSelfDrawPanel.CSDListEntry csdlistEntry = new CustomSelfDrawPanel.CSDListEntry();
						csdlistEntry.Position = new Point(0, i * elementHeight);
						csdlistEntry.Size = new Size(this.Size.Width - 16, elementHeight);
						csdlistEntry.Data = i;
						csdlistEntry.Text.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
						csdlistEntry.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.cellClicked), "CSD_List_Box_entry_clicked");
						this.entries[i] = csdlistEntry;
						base.addControl(csdlistEntry);
						csdlistEntry.setup();
					}
					this.scrollBar.Position = new Point(this.Size.Width - 16, 17);
					this.scrollBar.Size = new Size(16, this.Size.Height - 17 - 17 - 1);
					base.addControl(this.scrollBar);
					this.scrollBar.Value = 0;
					this.scrollBar.Max = 0;
					this.scrollBar.NumVisibleLines = numRows;
					this.scrollBar.TabMinSize = 26;
					this.scrollBar.OffsetTL = new Point(0, 0);
					this.scrollBar.OffsetBR = new Point(0, 0);
					this.scrollBar.Create(GFXLibrary.mail2_blue_scrollbar_bar_top, GFXLibrary.mail2_blue_scrollbar_bar_middle, GFXLibrary.mail2_blue_scrollbar_bar_bottom, GFXLibrary.mail2_blue_scrollbar_thumb_top, GFXLibrary.mail2_blue_scrollbar_thumb_mid, GFXLibrary.mail2_blue_scrollbar_thumb_bottom);
					this.scrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.scrollBarValueMoved));
					this.scrollBar.setScrollChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ScrollBarChangedDelegate(this.scrollBarMoved));
					this.upArrow.ImageNorm = GFXLibrary.mail2_blue_scrollbar_toparrow_normal;
					this.upArrow.ImageOver = GFXLibrary.mail2_blue_scrollbar_toparrow_over;
					this.upArrow.ImageClick = GFXLibrary.mail2_blue_scrollbar_toparrow_in;
					this.upArrow.Position = new Point(this.scrollBar.Position.X, 0);
					this.upArrow.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.ScrollUp), "CSD_List_Box_scroll_up");
					base.addControl(this.upArrow);
					this.downArrow.ImageNorm = GFXLibrary.mail2_blue_scrollbar_bottomarrow_normal;
					this.downArrow.ImageOver = GFXLibrary.mail2_blue_scrollbar_bottomarrow_over;
					this.downArrow.ImageClick = GFXLibrary.mail2_blue_scrollbar_bottomarrow_in;
					this.downArrow.Position = new Point(this.scrollBar.Position.X, this.scrollBar.Position.Y + this.scrollBar.Size.Height);
					this.downArrow.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.ScrollDown), "CSD_List_Box_scroll_down");
					base.addControl(this.downArrow);
					this.scrollTabLines.Image = GFXLibrary.mail2_blue_scrollbar_thumb_mid_lines;
					this.scrollTabLines.Position = new Point(this.scrollBar.TabPosition.X, (this.scrollBar.TabSize - 8) / 2 + this.scrollBar.TabPosition.Y);
					this.scrollBar.addControl(this.scrollTabLines);
					this.mouseWheelOverlay.Position = new Point(0, 0);
					this.mouseWheelOverlay.Size = this.Size;
					this.mouseWheelOverlay.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mouseWheelMoved));
					base.addControl(this.mouseWheelOverlay);
				}
				this.selectedItemID = -1;
				this.updateEntries();
			}

			// Token: 0x06000DC3 RID: 3523 RVA: 0x00010048 File Offset: 0x0000E248
			public void populate(List<CustomSelfDrawPanel.CSDListItem> items)
			{
				this.dataItems = items;
				this.updateEntries();
			}

			// Token: 0x06000DC4 RID: 3524 RVA: 0x00010057 File Offset: 0x0000E257
			public void setLineClickedDelegate(CustomSelfDrawPanel.CSDListBox.CSD_LineClickedDelegate callback)
			{
				this.lineClickedDelegate = callback;
			}

			// Token: 0x06000DC5 RID: 3525 RVA: 0x00010060 File Offset: 0x0000E260
			public void setDoubleClickedDelegate(CustomSelfDrawPanel.CSDListBox.CSD_LineClickedDelegate callback)
			{
				this.doubleClickedDelegate = callback;
			}

			// Token: 0x06000DC6 RID: 3526 RVA: 0x00010069 File Offset: 0x0000E269
			public CustomSelfDrawPanel.CSDListItem getSelectedItem()
			{
				if (this.selectedItemID < 0 || this.selectedItemID >= this.dataItems.Count)
				{
					return null;
				}
				return this.dataItems[this.selectedItemID];
			}

			// Token: 0x06000DC7 RID: 3527 RVA: 0x0001009A File Offset: 0x0000E29A
			public void clearSelectedItem()
			{
				this.selectedItemID = -1;
				this.updateEntries();
			}

			// Token: 0x06000DC8 RID: 3528 RVA: 0x000F8FAC File Offset: 0x000F71AC
			public void updateEntries()
			{
				int num = this.scrollBar.Max + this.m_numRows;
				if (num > this.dataItems.Count)
				{
					int num2 = Math.Max(0, this.dataItems.Count - this.m_numRows);
					if (this.scrollBar.Value > num2)
					{
						this.scrollBar.Value = num2;
					}
					this.scrollBar.Max = num2;
				}
				else
				{
					this.scrollBar.Max = Math.Max(0, this.dataItems.Count - this.m_numRows);
				}
				for (int i = 0; i < this.m_numRows; i++)
				{
					CustomSelfDrawPanel.CSDListEntry csdlistEntry = this.entries[i];
					csdlistEntry.Text.Text = "";
					csdlistEntry.reset();
				}
				int num3 = this.scrollBar.Value;
				int num4 = 0;
				while (num4 < this.m_numRows && num3 < this.dataItems.Count)
				{
					CustomSelfDrawPanel.CSDListItem csdlistItem = this.dataItems[num3];
					CustomSelfDrawPanel.CSDListEntry csdlistEntry2 = this.entries[num4];
					csdlistEntry2.Text.Text = csdlistItem.Text;
					if (num3 == this.selectedItemID)
					{
						if (this.highlightedItems.Contains(csdlistItem))
						{
							csdlistEntry2.BodyColor = global::ARGBColors.GreenYellow;
							csdlistEntry2.OverColor = global::ARGBColors.Honeydew;
						}
						else
						{
							csdlistEntry2.BodyColor = CustomSelfDrawPanel.MailSelectedColor;
							csdlistEntry2.OverColor = CustomSelfDrawPanel.MailSelectedOverColor;
						}
					}
					else if (this.highlightedItems.Contains(csdlistItem))
					{
						csdlistEntry2.BodyColor = global::ARGBColors.LightGreen;
						csdlistEntry2.OverColor = global::ARGBColors.Chartreuse;
					}
					csdlistEntry2.invalidate();
					num4++;
					num3++;
				}
				this.scrollBar.recalc();
				this.scrollBar.invalidate();
				this.scrollBarMoved();
			}

			// Token: 0x06000DC9 RID: 3529 RVA: 0x000100A9 File Offset: 0x0000E2A9
			private void scrollBarValueMoved()
			{
				this.updateEntries();
			}

			// Token: 0x06000DCA RID: 3530 RVA: 0x000F916C File Offset: 0x000F736C
			private void scrollBarMoved()
			{
				this.scrollTabLines.Position = new Point(this.scrollBar.TabPosition.X, (this.scrollBar.TabSize - 8) / 2 + this.scrollBar.TabPosition.Y);
			}

			// Token: 0x06000DCB RID: 3531 RVA: 0x000100B1 File Offset: 0x0000E2B1
			private void ScrollUp()
			{
				this.ScrollUp(1);
			}

			// Token: 0x06000DCC RID: 3532 RVA: 0x000100BA File Offset: 0x0000E2BA
			private void ScrollDown()
			{
				this.ScrollDown(1);
			}

			// Token: 0x06000DCD RID: 3533 RVA: 0x000F91C0 File Offset: 0x000F73C0
			private void ScrollUp(int diff)
			{
				int num = this.scrollBar.Value;
				if (num > 0)
				{
					num -= diff;
					if (num < 0)
					{
						num = 0;
					}
					this.scrollBar.Value = num;
					this.scrollBar.invalidate();
					this.scrollBarMoved();
					this.scrollBarValueMoved();
					base.invalidate();
				}
			}

			// Token: 0x06000DCE RID: 3534 RVA: 0x000F9210 File Offset: 0x000F7410
			private void ScrollDown(int diff)
			{
				int num = this.scrollBar.Value;
				if (num < this.scrollBar.Max)
				{
					num += diff;
					if (num > this.scrollBar.Max)
					{
						num = this.scrollBar.Max;
					}
					this.scrollBar.Value = num;
					this.scrollBar.invalidate();
					this.scrollBarValueMoved();
					this.scrollBarMoved();
					base.invalidate();
				}
			}

			// Token: 0x06000DCF RID: 3535 RVA: 0x000100C3 File Offset: 0x0000E2C3
			private void mouseWheelMoved(int delta)
			{
				if (this.scrollBar.Visible)
				{
					if (delta < 0)
					{
						this.ScrollDown(3);
						return;
					}
					if (delta > 0)
					{
						this.ScrollUp(3);
					}
				}
			}

			// Token: 0x06000DD0 RID: 3536 RVA: 0x000F9280 File Offset: 0x000F7480
			private void cellClicked()
			{
				if (base.csd.ClickedControl == null)
				{
					return;
				}
				CustomSelfDrawPanel.CSDListEntry csdlistEntry = (CustomSelfDrawPanel.CSDListEntry)base.csd.ClickedControl;
				int num = csdlistEntry.Data + this.scrollBar.Value;
				DateTime now = DateTime.Now;
				bool flag = false;
				if (num >= 0 && num < this.dataItems.Count)
				{
					if (num == this.selectedItemID && (now - this.doubleClickTime).TotalSeconds < 2.0)
					{
						flag = true;
						this.doubleClickTime = DateTime.MinValue;
					}
					this.doubleClickTime = now;
					this.selectedItemID = num;
					this.updateEntries();
					if (this.lineClickedDelegate != null)
					{
						this.lineClickedDelegate(this.dataItems[num]);
					}
					if (flag && this.doubleClickedDelegate != null)
					{
						this.doubleClickedDelegate(this.dataItems[num]);
					}
				}
			}

			// Token: 0x06000DD1 RID: 3537 RVA: 0x000F936C File Offset: 0x000F756C
			public bool contains(string testText)
			{
				foreach (CustomSelfDrawPanel.CSDListItem csdlistItem in this.dataItems)
				{
					if (csdlistItem.Text == testText)
					{
						return true;
					}
				}
				return false;
			}

			// Token: 0x04001193 RID: 4499
			private bool created;

			// Token: 0x04001194 RID: 4500
			private CustomSelfDrawPanel.CSDListEntry[] entries;

			// Token: 0x04001195 RID: 4501
			public List<CustomSelfDrawPanel.CSDListItem> highlightedItems = new List<CustomSelfDrawPanel.CSDListItem>();

			// Token: 0x04001196 RID: 4502
			private int m_numRows;

			// Token: 0x04001197 RID: 4503
			private CustomSelfDrawPanel.CSDVertScrollBar scrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

			// Token: 0x04001198 RID: 4504
			private CustomSelfDrawPanel.CSDImage scrollTabLines = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001199 RID: 4505
			private CustomSelfDrawPanel.CSDButton upArrow = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x0400119A RID: 4506
			private CustomSelfDrawPanel.CSDButton downArrow = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x0400119B RID: 4507
			public List<CustomSelfDrawPanel.CSDListItem> dataItems = new List<CustomSelfDrawPanel.CSDListItem>();

			// Token: 0x0400119C RID: 4508
			private int selectedItemID = -1;

			// Token: 0x0400119D RID: 4509
			private CustomSelfDrawPanel.CSDControl mouseWheelOverlay = new CustomSelfDrawPanel.CSDControl();

			// Token: 0x0400119E RID: 4510
			private CustomSelfDrawPanel.CSDListBox.CSD_LineClickedDelegate lineClickedDelegate;

			// Token: 0x0400119F RID: 4511
			private CustomSelfDrawPanel.CSDListBox.CSD_LineClickedDelegate doubleClickedDelegate;

			// Token: 0x040011A0 RID: 4512
			private DateTime doubleClickTime = DateTime.MinValue;

			// Token: 0x02000167 RID: 359
			// (Invoke) Token: 0x06000DD4 RID: 3540
			public delegate void CSD_LineClickedDelegate(CustomSelfDrawPanel.CSDListItem item);
		}

		// Token: 0x02000168 RID: 360
		private class CSDTabItem : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x170000B9 RID: 185
			// (get) Token: 0x06000DD7 RID: 3543 RVA: 0x000100E9 File Offset: 0x0000E2E9
			// (set) Token: 0x06000DD8 RID: 3544 RVA: 0x000F9444 File Offset: 0x000F7644
			public Image overlayNormImage
			{
				get
				{
					return this.m_overlayNormImage;
				}
				set
				{
					this.m_overlayNormImage = value;
					if (value != null)
					{
						if (!this.m_selected && this.mainButton.ImageIcon != value)
						{
							this.mainButton.ImageIcon = value;
							this.mainButton.invalidate();
							return;
						}
					}
					else if (this.mainButton.ImageIcon != value)
					{
						this.mainButton.ImageIcon = null;
						this.mainButton.invalidate();
					}
				}
			}

			// Token: 0x170000BA RID: 186
			// (get) Token: 0x06000DD9 RID: 3545 RVA: 0x000100F1 File Offset: 0x0000E2F1
			// (set) Token: 0x06000DDA RID: 3546 RVA: 0x000F94B0 File Offset: 0x000F76B0
			public Image overlaySelectedImage
			{
				get
				{
					return this.m_overlaySelectedImage;
				}
				set
				{
					this.m_overlaySelectedImage = value;
					if (value != null)
					{
						if (this.m_selected && this.mainButton.ImageIcon != value)
						{
							this.mainButton.ImageIcon = value;
							this.mainButton.invalidate();
							return;
						}
					}
					else if (this.mainButton.ImageIcon != value)
					{
						this.mainButton.ImageIcon = null;
						this.mainButton.invalidate();
					}
				}
			}

			// Token: 0x170000BB RID: 187
			// (get) Token: 0x06000DDB RID: 3547 RVA: 0x000100F9 File Offset: 0x0000E2F9
			// (set) Token: 0x06000DDC RID: 3548 RVA: 0x00010101 File Offset: 0x0000E301
			public float overlayAlpha
			{
				get
				{
					return this.m_overlayAlpha;
				}
				set
				{
					this.m_overlayAlpha = value;
					this.mainButton.ImageIconAlpha = value;
				}
			}

			// Token: 0x06000DDD RID: 3549 RVA: 0x000F951C File Offset: 0x000F771C
			public int setup(int xPos, CustomSelfDrawPanel.CSDTabControl parentControl, int index, bool selected)
			{
				this.m_selected = selected;
				this.m_parentControl = parentControl;
				if (!selected)
				{
					this.mainButton.ImageNormAndOver = this.normImage;
				}
				else
				{
					this.mainButton.ImageNormAndOver = this.selectedImage;
				}
				this.mainButton.MoveOnClick = false;
				this.mainButton.Position = new Point(xPos, 0);
				this.mainButton.Data = index;
				this.mainButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tabClicked));
				this.mainButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.mainButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				this.mainButton.Text.Position = new Point(0, 5);
				this.mainButton.Text.Color = global::ARGBColors.White;
				this.mainButton.LateTextRender = true;
				base.addControl(this.mainButton);
				this.Size = this.mainButton.Size;
				if (this.mainButton.ImageNormAndOver != null)
				{
					return this.mainButton.ImageNormAndOver.Width;
				}
				return 1;
			}

			// Token: 0x06000DDE RID: 3550 RVA: 0x00010116 File Offset: 0x0000E316
			public void setCallback(CustomSelfDrawPanel.CSDTabControl.TabClickedCallback callback)
			{
				this.m_callback = callback;
			}

			// Token: 0x06000DDF RID: 3551 RVA: 0x0001011F File Offset: 0x0000E31F
			public void setTooltip(int tooltip)
			{
				this.mainButton.CustomTooltipID = tooltip;
			}

			// Token: 0x06000DE0 RID: 3552 RVA: 0x000F9648 File Offset: 0x000F7848
			public void updateImage(bool selected)
			{
				this.m_selected = selected;
				if (!selected)
				{
					if (this.normImage != this.mainButton.ImageNormAndOver)
					{
						this.mainButton.ImageNormAndOver = this.normImage;
						this.mainButton.invalidate();
					}
					if (this.overlayNormImage != this.mainButton.ImageIcon)
					{
						this.overlayNormImage = this.overlayNormImage;
						return;
					}
				}
				else
				{
					if (this.mainButton.ImageNormAndOver != this.selectedImage)
					{
						this.mainButton.ImageNormAndOver = this.selectedImage;
						this.mainButton.invalidate();
					}
					if (this.overlaySelectedImage != this.mainButton.ImageIcon)
					{
						this.overlaySelectedImage = this.overlaySelectedImage;
					}
				}
			}

			// Token: 0x06000DE1 RID: 3553 RVA: 0x0001012D File Offset: 0x0000E32D
			private void tabClicked()
			{
				if (this.m_parentControl != null)
				{
					this.m_parentControl.tabClicked(base.csd.ClickedControl.Data, true);
				}
			}

			// Token: 0x06000DE2 RID: 3554 RVA: 0x00010153 File Offset: 0x0000E353
			public void runCallback()
			{
				if (this.m_callback != null)
				{
					this.m_callback();
				}
			}

			// Token: 0x06000DE3 RID: 3555 RVA: 0x00010168 File Offset: 0x0000E368
			public void setText(string text)
			{
				this.mainButton.Text.Text = text;
			}

			// Token: 0x06000DE4 RID: 3556 RVA: 0x000F96FC File Offset: 0x000F78FC
			public void setOverlayWidth(int width)
			{
				if (width != this.mainButton.ImageIconClipRect.Width)
				{
					this.mainButton.ImageIconClipRect = new Rectangle(0, 0, width, this.mainButton.Height);
					this.mainButton.invalidate();
				}
			}

			// Token: 0x040011A1 RID: 4513
			public Image normImage;

			// Token: 0x040011A2 RID: 4514
			public Image selectedImage;

			// Token: 0x040011A3 RID: 4515
			private Image m_overlayNormImage;

			// Token: 0x040011A4 RID: 4516
			private Image m_overlaySelectedImage;

			// Token: 0x040011A5 RID: 4517
			private float m_overlayAlpha = 1f;

			// Token: 0x040011A6 RID: 4518
			public int overlayImageWidth = 1;

			// Token: 0x040011A7 RID: 4519
			private CustomSelfDrawPanel.CSDTabControl m_parentControl;

			// Token: 0x040011A8 RID: 4520
			private CustomSelfDrawPanel.CSDButton mainButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011A9 RID: 4521
			private bool m_selected;

			// Token: 0x040011AA RID: 4522
			private CustomSelfDrawPanel.CSDTabControl.TabClickedCallback m_callback;
		}

		// Token: 0x02000169 RID: 361
		public class CSDTabControl : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x170000BC RID: 188
			// (get) Token: 0x06000DE6 RID: 3558 RVA: 0x000101A0 File Offset: 0x0000E3A0
			// (set) Token: 0x06000DE7 RID: 3559 RVA: 0x000101A8 File Offset: 0x0000E3A8
			public int SelectedIndex
			{
				get
				{
					return this.currentSelected;
				}
				set
				{
					this.currentSelected = value;
					this.tabClicked(value, false);
				}
			}

			// Token: 0x06000DE8 RID: 3560 RVA: 0x000F9748 File Offset: 0x000F7948
			public int Create(int numIcons, BaseImage[] images)
			{
				this.items.Clear();
				int num = 0;
				for (int i = 0; i < numIcons; i++)
				{
					CustomSelfDrawPanel.CSDTabItem csdtabItem = new CustomSelfDrawPanel.CSDTabItem();
					if (i * 2 < images.Length)
					{
						csdtabItem.normImage = images[i * 2];
						csdtabItem.selectedImage = images[i * 2 + 1];
					}
					num += csdtabItem.setup(num, this, i, i == this.currentSelected);
					this.items.Add(csdtabItem);
					base.addControl(csdtabItem);
				}
				this.currentSelected = 0;
				this.updateAll();
				return num;
			}

			// Token: 0x06000DE9 RID: 3561 RVA: 0x000101B9 File Offset: 0x0000E3B9
			public void setCallback(int tab, CustomSelfDrawPanel.CSDTabControl.TabClickedCallback callback, int tooltip)
			{
				if (tab >= 0 && tab < this.items.Count)
				{
					this.items[tab].setCallback(callback);
					this.items[tab].setTooltip(tooltip);
				}
			}

			// Token: 0x06000DEA RID: 3562 RVA: 0x000101F1 File Offset: 0x0000E3F1
			public void setTooltip(int tab, int tooltip)
			{
				if (tab >= 0 && tab < this.items.Count)
				{
					this.items[tab].setTooltip(tooltip);
				}
			}

			// Token: 0x06000DEB RID: 3563 RVA: 0x000F97D4 File Offset: 0x000F79D4
			public void updateImageArray(BaseImage[] images)
			{
				int num = 0;
				foreach (CustomSelfDrawPanel.CSDTabItem csdtabItem in this.items)
				{
					if (num * 2 < images.Length)
					{
						csdtabItem.normImage = images[num * 2];
						csdtabItem.selectedImage = images[num * 2 + 1];
					}
					csdtabItem.updateImage(num == this.currentSelected);
					num++;
				}
			}

			// Token: 0x06000DEC RID: 3564 RVA: 0x000F9860 File Offset: 0x000F7A60
			public void tabClicked(int index, bool fromClick)
			{
				this.currentSelected = index;
				this.updateAll();
				if (this.currentSelected >= 0 && this.currentSelected < this.items.Count)
				{
					this.items[this.currentSelected].runCallback();
				}
				if (fromClick && this.soundsCallback != null)
				{
					this.soundsCallback();
				}
			}

			// Token: 0x06000DED RID: 3565 RVA: 0x000F98C4 File Offset: 0x000F7AC4
			private void updateAll()
			{
				int num = 0;
				foreach (CustomSelfDrawPanel.CSDTabItem csdtabItem in this.items)
				{
					csdtabItem.updateImage(num == this.currentSelected);
					num++;
				}
			}

			// Token: 0x06000DEE RID: 3566 RVA: 0x000F9928 File Offset: 0x000F7B28
			public void setOverlayAlpha(int tab, int alpha)
			{
				if (tab >= 0 && tab < this.items.Count)
				{
					float num = (float)alpha / 255f;
					if (num != this.items[tab].overlayAlpha)
					{
						this.items[tab].overlayAlpha = num;
					}
				}
			}

			// Token: 0x06000DEF RID: 3567 RVA: 0x00010217 File Offset: 0x0000E417
			public void setOverlayWidth(int tab, int width)
			{
				if (tab >= 0 && tab < this.items.Count)
				{
					this.items[tab].setOverlayWidth(width);
				}
			}

			// Token: 0x06000DF0 RID: 3568 RVA: 0x000F9978 File Offset: 0x000F7B78
			public void addOverlayImages(int tab, BaseImage overlayNorm, BaseImage overlaySelected, int alpha)
			{
				if (tab >= 0 && tab < this.items.Count)
				{
					float overlayAlpha = (float)alpha / 255f;
					this.items[tab].overlayNormImage = overlayNorm;
					this.items[tab].overlaySelectedImage = overlaySelected;
					this.items[tab].overlayAlpha = overlayAlpha;
					if (overlayNorm != null)
					{
						this.items[tab].overlayImageWidth = overlayNorm.Width;
					}
				}
			}

			// Token: 0x06000DF1 RID: 3569 RVA: 0x0001023D File Offset: 0x0000E43D
			public void setTabText(int tab, string text)
			{
				if (tab >= 0 && tab < this.items.Count)
				{
					this.items[tab].setText(text);
				}
			}

			// Token: 0x06000DF2 RID: 3570 RVA: 0x00010263 File Offset: 0x0000E463
			public void setSoundCallback(CustomSelfDrawPanel.CSDTabControl.TabClickedCallback callback)
			{
				this.soundsCallback = callback;
			}

			// Token: 0x040011AB RID: 4523
			private List<CustomSelfDrawPanel.CSDTabItem> items = new List<CustomSelfDrawPanel.CSDTabItem>();

			// Token: 0x040011AC RID: 4524
			private int currentSelected;

			// Token: 0x040011AD RID: 4525
			private CustomSelfDrawPanel.CSDTabControl.TabClickedCallback soundsCallback;

			// Token: 0x0200016A RID: 362
			// (Invoke) Token: 0x06000DF5 RID: 3573
			public delegate void TabClickedCallback();
		}

		// Token: 0x0200016B RID: 363
		public class FactionPanelSideBar : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06000DF8 RID: 3576 RVA: 0x000F99FC File Offset: 0x000F7BFC
			public void addSideBar(int mode, CustomSelfDrawPanel parent)
			{
				CustomSelfDrawPanel.FactionPanelSideBar.m_factionDataUpdated = false;
				CustomSelfDrawPanel.FactionPanelSideBar.m_currentSidebarMode = mode;
				this.m_parent = parent;
				this.clearControls();
				this.Position = new Point(parent.Width - 200, 0);
				this.Size = new Size(200, parent.Height);
				parent.removeControl(this);
				parent.addControl(this);
				this.backgroundImage.Position = new Point(0, 0);
				this.backgroundImage.Size = new Size(200, parent.Height);
				base.addControl(this.backgroundImage);
				this.backgroundImage.Create(GFXLibrary.faction_background, GFXLibrary.faction_background_bottom, GFXLibrary.faction_background_bottom);
				this.factionButtonBackground.Image = GFXLibrary.faction_button_background;
				this.factionButtonBackground.Position = new Point(0, 0);
				this.factionButtonBackground.Visible = false;
				this.backgroundImage.addControl(this.factionButtonBackground);
				int num = 10;
				int num2 = 40;
				if (mode > 6)
				{
					if (mode - 7 <= 1)
					{
						CustomSelfDrawPanel.WikiLinkControl.init(this.backgroundImage, 24, new Point(this.backgroundImage.Width - 38, 52));
						this.houseShowAllButton.ImageNorm = GFXLibrary.faction_buttons[20];
						this.houseShowAllButton.ImageOver = GFXLibrary.faction_buttons[21];
						this.houseShowAllButton.Position = new Point(7, num);
						this.houseShowAllButton.MoveOnClick = true;
						this.houseShowAllButton.Text.Text = SK.Text("FactionsSidebar_Show_All", "Show All");
						this.houseShowAllButton.Text.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
						this.houseShowAllButton.Text.Position = new Point(84, 0);
						this.houseShowAllButton.Text.Size = new Size(94, 40);
						this.houseShowAllButton.TextYOffset = -3;
						this.houseShowAllButton.Text.Color = global::ARGBColors.Black;
						this.houseShowAllButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.showAllHousesClicked), "FactionPanelSideBar_all_houses");
						this.houseShowAllButton.Active = true;
						this.backgroundImage.addControl(this.houseShowAllButton);
						num += num2 + 1;
						int num3 = 1;
						int x = 47;
						int x2 = 107;
						int num4 = -15;
						int num5 = 25;
						this.house1Button.ImageNorm = GFXLibrary.house_circles_medium[num3 - 1];
						this.house1Button.ImageOver = GFXLibrary.house_circles_medium[num3 - 1 + 20];
						this.house1Button.Position = new Point(x, num);
						this.house1Button.MoveOnClick = true;
						this.house1Button.CustomTooltipID = 2307;
						this.house1Button.CustomTooltipData = num3;
						this.house1Button.Data = num3++;
						this.house1Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.selectHouseClicked));
						this.house1Button.Active = true;
						this.backgroundImage.addControl(this.house1Button);
						num += num5;
						this.house2Button.ImageNorm = GFXLibrary.house_circles_medium[num3 - 1];
						this.house2Button.ImageOver = GFXLibrary.house_circles_medium[num3 - 1 + 20];
						this.house2Button.Position = new Point(x2, num + num4);
						this.house2Button.MoveOnClick = true;
						this.house2Button.CustomTooltipID = 2307;
						this.house2Button.CustomTooltipData = num3;
						this.house2Button.Data = num3++;
						this.house2Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.selectHouseClicked));
						this.house2Button.Active = true;
						this.backgroundImage.addControl(this.house2Button);
						num += num5;
						this.house3Button.ImageNorm = GFXLibrary.house_circles_medium[num3 - 1];
						this.house3Button.ImageOver = GFXLibrary.house_circles_medium[num3 - 1 + 20];
						this.house3Button.Position = new Point(x, num);
						this.house3Button.MoveOnClick = true;
						this.house3Button.CustomTooltipID = 2307;
						this.house3Button.CustomTooltipData = num3;
						this.house3Button.Data = num3++;
						this.house3Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.selectHouseClicked));
						this.house3Button.Active = true;
						this.backgroundImage.addControl(this.house3Button);
						num += num5;
						this.house4Button.ImageNorm = GFXLibrary.house_circles_medium[num3 - 1];
						this.house4Button.ImageOver = GFXLibrary.house_circles_medium[num3 - 1 + 20];
						this.house4Button.Position = new Point(x2, num + num4);
						this.house4Button.MoveOnClick = true;
						this.house4Button.CustomTooltipID = 2307;
						this.house4Button.CustomTooltipData = num3;
						this.house4Button.Data = num3++;
						this.house4Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.selectHouseClicked));
						this.house4Button.Active = true;
						this.backgroundImage.addControl(this.house4Button);
						num += num5;
						this.house5Button.ImageNorm = GFXLibrary.house_circles_medium[num3 - 1];
						this.house5Button.ImageOver = GFXLibrary.house_circles_medium[num3 - 1 + 20];
						this.house5Button.Position = new Point(x, num);
						this.house5Button.MoveOnClick = true;
						this.house5Button.CustomTooltipID = 2307;
						this.house5Button.CustomTooltipData = num3;
						this.house5Button.Data = num3++;
						this.house5Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.selectHouseClicked));
						this.house5Button.Active = true;
						this.backgroundImage.addControl(this.house5Button);
						num += num5;
						this.house6Button.ImageNorm = GFXLibrary.house_circles_medium[num3 - 1];
						this.house6Button.ImageOver = GFXLibrary.house_circles_medium[num3 - 1 + 20];
						this.house6Button.Position = new Point(x2, num + num4);
						this.house6Button.MoveOnClick = true;
						this.house6Button.CustomTooltipID = 2307;
						this.house6Button.CustomTooltipData = num3;
						this.house6Button.Data = num3++;
						this.house6Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.selectHouseClicked));
						this.house6Button.Active = true;
						this.backgroundImage.addControl(this.house6Button);
						num += num5;
						this.house7Button.ImageNorm = GFXLibrary.house_circles_medium[num3 - 1];
						this.house7Button.ImageOver = GFXLibrary.house_circles_medium[num3 - 1 + 20];
						this.house7Button.Position = new Point(x, num);
						this.house7Button.MoveOnClick = true;
						this.house7Button.CustomTooltipID = 2307;
						this.house7Button.CustomTooltipData = num3;
						this.house7Button.Data = num3++;
						this.house7Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.selectHouseClicked));
						this.house7Button.Active = true;
						this.backgroundImage.addControl(this.house7Button);
						num += num5;
						this.house8Button.ImageNorm = GFXLibrary.house_circles_medium[num3 - 1];
						this.house8Button.ImageOver = GFXLibrary.house_circles_medium[num3 - 1 + 20];
						this.house8Button.Position = new Point(x2, num + num4);
						this.house8Button.MoveOnClick = true;
						this.house8Button.CustomTooltipID = 2307;
						this.house8Button.CustomTooltipData = num3;
						this.house8Button.Data = num3++;
						this.house8Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.selectHouseClicked));
						this.house8Button.Active = true;
						this.backgroundImage.addControl(this.house8Button);
						num += num5;
						this.house9Button.ImageNorm = GFXLibrary.house_circles_medium[num3 - 1];
						this.house9Button.ImageOver = GFXLibrary.house_circles_medium[num3 - 1 + 20];
						this.house9Button.Position = new Point(x, num);
						this.house9Button.MoveOnClick = true;
						this.house9Button.CustomTooltipID = 2307;
						this.house9Button.CustomTooltipData = num3;
						this.house9Button.Data = num3++;
						this.house9Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.selectHouseClicked));
						this.house9Button.Active = true;
						this.backgroundImage.addControl(this.house9Button);
						num += num5;
						this.house10Button.ImageNorm = GFXLibrary.house_circles_medium[num3 - 1];
						this.house10Button.ImageOver = GFXLibrary.house_circles_medium[num3 - 1 + 20];
						this.house10Button.Position = new Point(x2, num + num4);
						this.house10Button.MoveOnClick = true;
						this.house10Button.CustomTooltipID = 2307;
						this.house10Button.CustomTooltipData = num3;
						this.house10Button.Data = num3++;
						this.house10Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.selectHouseClicked));
						this.house10Button.Active = true;
						this.backgroundImage.addControl(this.house10Button);
						num += num5;
						this.house11Button.ImageNorm = GFXLibrary.house_circles_medium[num3 - 1];
						this.house11Button.ImageOver = GFXLibrary.house_circles_medium[num3 - 1 + 20];
						this.house11Button.Position = new Point(x, num);
						this.house11Button.MoveOnClick = true;
						this.house11Button.CustomTooltipID = 2307;
						this.house11Button.CustomTooltipData = num3;
						this.house11Button.Data = num3++;
						this.house11Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.selectHouseClicked));
						this.house11Button.Active = true;
						this.backgroundImage.addControl(this.house11Button);
						num += num5;
						this.house12Button.ImageNorm = GFXLibrary.house_circles_medium[num3 - 1];
						this.house12Button.ImageOver = GFXLibrary.house_circles_medium[num3 - 1 + 20];
						this.house12Button.Position = new Point(x2, num + num4);
						this.house12Button.MoveOnClick = true;
						this.house12Button.CustomTooltipID = 2307;
						this.house12Button.CustomTooltipData = num3;
						this.house12Button.Data = num3++;
						this.house12Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.selectHouseClicked));
						this.house12Button.Active = true;
						this.backgroundImage.addControl(this.house12Button);
						num += num5;
						this.house13Button.ImageNorm = GFXLibrary.house_circles_medium[num3 - 1];
						this.house13Button.ImageOver = GFXLibrary.house_circles_medium[num3 - 1 + 20];
						this.house13Button.Position = new Point(x, num);
						this.house13Button.MoveOnClick = true;
						this.house13Button.CustomTooltipID = 2307;
						this.house13Button.CustomTooltipData = num3;
						this.house13Button.Data = num3++;
						this.house13Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.selectHouseClicked));
						this.house13Button.Active = true;
						this.backgroundImage.addControl(this.house13Button);
						num += num5;
						this.house14Button.ImageNorm = GFXLibrary.house_circles_medium[num3 - 1];
						this.house14Button.ImageOver = GFXLibrary.house_circles_medium[num3 - 1 + 20];
						this.house14Button.Position = new Point(x2, num + num4);
						this.house14Button.MoveOnClick = true;
						this.house14Button.CustomTooltipID = 2307;
						this.house14Button.CustomTooltipData = num3;
						this.house14Button.Data = num3++;
						this.house14Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.selectHouseClicked));
						this.house14Button.Active = true;
						this.backgroundImage.addControl(this.house14Button);
						num += num5;
						this.house15Button.ImageNorm = GFXLibrary.house_circles_medium[num3 - 1];
						this.house15Button.ImageOver = GFXLibrary.house_circles_medium[num3 - 1 + 20];
						this.house15Button.Position = new Point(x, num);
						this.house15Button.MoveOnClick = true;
						this.house15Button.CustomTooltipID = 2307;
						this.house15Button.CustomTooltipData = num3;
						this.house15Button.Data = num3++;
						this.house15Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.selectHouseClicked));
						this.house15Button.Active = true;
						this.backgroundImage.addControl(this.house15Button);
						num += num5;
						this.house16Button.ImageNorm = GFXLibrary.house_circles_medium[num3 - 1];
						this.house16Button.ImageOver = GFXLibrary.house_circles_medium[num3 - 1 + 20];
						this.house16Button.Position = new Point(x2, num + num4);
						this.house16Button.MoveOnClick = true;
						this.house16Button.CustomTooltipID = 2307;
						this.house16Button.CustomTooltipData = num3;
						this.house16Button.Data = num3++;
						this.house16Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.selectHouseClicked));
						this.house16Button.Active = true;
						this.backgroundImage.addControl(this.house16Button);
						num += num5;
						this.house17Button.ImageNorm = GFXLibrary.house_circles_medium[num3 - 1];
						this.house17Button.ImageOver = GFXLibrary.house_circles_medium[num3 - 1 + 20];
						this.house17Button.Position = new Point(x, num);
						this.house17Button.MoveOnClick = true;
						this.house17Button.CustomTooltipID = 2307;
						this.house17Button.CustomTooltipData = num3;
						this.house17Button.Data = num3++;
						this.house17Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.selectHouseClicked));
						this.house17Button.Active = true;
						this.backgroundImage.addControl(this.house17Button);
						num += num5;
						this.house18Button.ImageNorm = GFXLibrary.house_circles_medium[num3 - 1];
						this.house18Button.ImageOver = GFXLibrary.house_circles_medium[num3 - 1 + 20];
						this.house18Button.Position = new Point(x2, num + num4);
						this.house18Button.MoveOnClick = true;
						this.house18Button.CustomTooltipID = 2307;
						this.house18Button.CustomTooltipData = num3;
						this.house18Button.Data = num3++;
						this.house18Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.selectHouseClicked));
						this.house18Button.Active = true;
						this.backgroundImage.addControl(this.house18Button);
						num += num5;
						this.house19Button.ImageNorm = GFXLibrary.house_circles_medium[num3 - 1];
						this.house19Button.ImageOver = GFXLibrary.house_circles_medium[num3 - 1 + 20];
						this.house19Button.Position = new Point(x, num);
						this.house19Button.MoveOnClick = true;
						this.house19Button.CustomTooltipID = 2307;
						this.house19Button.CustomTooltipData = num3;
						this.house19Button.Data = num3++;
						this.house19Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.selectHouseClicked));
						this.house19Button.Active = true;
						this.backgroundImage.addControl(this.house19Button);
						num += num5;
						this.house20Button.ImageNorm = GFXLibrary.house_circles_medium[num3 - 1];
						this.house20Button.ImageOver = GFXLibrary.house_circles_medium[num3 - 1 + 20];
						this.house20Button.Position = new Point(x2, num + num4);
						this.house20Button.MoveOnClick = true;
						this.house20Button.CustomTooltipID = 2307;
						this.house20Button.CustomTooltipData = num3;
						this.house20Button.Data = num3++;
						this.house20Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.selectHouseClicked));
						this.house20Button.Active = true;
						this.backgroundImage.addControl(this.house20Button);
						num += num5;
					}
				}
				else
				{
					this.factionShowAllButton.ImageNorm = GFXLibrary.faction_buttons[0];
					this.factionShowAllButton.ImageOver = GFXLibrary.faction_buttons[1];
					this.factionShowAllButton.Position = new Point(7, num);
					this.factionShowAllButton.MoveOnClick = true;
					this.factionShowAllButton.Text.Text = SK.Text("FactionsSidebar_Show_All", "Show All");
					this.factionShowAllButton.Text.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
					this.factionShowAllButton.Text.Position = new Point(84, 0);
					this.factionShowAllButton.Text.Size = new Size(94, 40);
					this.factionShowAllButton.TextYOffset = -3;
					this.factionShowAllButton.Text.Color = global::ARGBColors.Black;
					this.factionShowAllButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.showAllClicked), "FactionPanelSideBar_all_factions");
					this.factionShowAllButton.Active = true;
					this.factionShowAllButton.CustomTooltipID = 2350;
					this.backgroundImage.addControl(this.factionShowAllButton);
					num += num2;
					int yourFactionRank = GameEngine.Instance.World.getYourFactionRank();
					if (RemoteServices.Instance.UserFactionID >= 0)
					{
						this.factionMyFactionButton.ImageNorm = GFXLibrary.faction_buttons[2];
						this.factionMyFactionButton.ImageOver = GFXLibrary.faction_buttons[3];
						this.factionMyFactionButton.Position = new Point(7, num);
						this.factionMyFactionButton.MoveOnClick = true;
						this.factionMyFactionButton.Text.Text = SK.Text("FactionsSidebar_My_Faction", "My Faction");
						this.factionMyFactionButton.Text.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
						this.factionMyFactionButton.Text.Position = new Point(84, 0);
						this.factionMyFactionButton.Text.Size = new Size(94, 40);
						this.factionMyFactionButton.TextYOffset = -3;
						this.factionMyFactionButton.Text.Color = global::ARGBColors.Black;
						this.factionMyFactionButton.Active = true;
						this.factionMyFactionButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.myFactionClicked), "FactionPanelSideBar_my_faction");
						this.factionMyFactionButton.CustomTooltipID = 2351;
						this.backgroundImage.addControl(this.factionMyFactionButton);
						num += num2;
						if (!GameEngine.Instance.World.isHeretic())
						{
							this.factionDiplomacyButton.ImageNorm = GFXLibrary.faction_buttons[4];
							this.factionDiplomacyButton.ImageOver = GFXLibrary.faction_buttons[5];
							this.factionDiplomacyButton.Position = new Point(7, num);
							this.factionDiplomacyButton.MoveOnClick = true;
							this.factionDiplomacyButton.Text.Text = SK.Text("AllArmiesPanel_Diplomacy", "Diplomacy");
							this.factionDiplomacyButton.Text.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
							this.factionDiplomacyButton.Text.Position = new Point(84, 0);
							this.factionDiplomacyButton.Text.Size = new Size(94, 40);
							this.factionDiplomacyButton.TextYOffset = -3;
							this.factionDiplomacyButton.Text.Color = global::ARGBColors.Black;
							this.factionDiplomacyButton.Active = true;
							this.factionDiplomacyButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.diplomacyClicked), "FactionPanelSideBar_diplomacy");
							this.factionDiplomacyButton.CustomTooltipID = 2352;
							this.backgroundImage.addControl(this.factionDiplomacyButton);
							num += num2;
							if (yourFactionRank == 2 || yourFactionRank == 1)
							{
								this.factionOfficersButton.ImageNorm = GFXLibrary.faction_buttons[6];
								this.factionOfficersButton.ImageOver = GFXLibrary.faction_buttons[7];
								this.factionOfficersButton.Position = new Point(7, num);
								this.factionOfficersButton.MoveOnClick = true;
								this.factionOfficersButton.Text.Text = SK.Text("FactionsSidebar_Officers", "Officers");
								this.factionOfficersButton.Text.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
								this.factionOfficersButton.Text.Position = new Point(84, 0);
								this.factionOfficersButton.Text.Size = new Size(94, 40);
								this.factionOfficersButton.TextYOffset = -3;
								this.factionOfficersButton.Text.Color = global::ARGBColors.Black;
								this.factionOfficersButton.Active = true;
								this.factionOfficersButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.officersClicked), "FactionPanelSideBar_officers");
								this.factionOfficersButton.CustomTooltipID = 2353;
								this.backgroundImage.addControl(this.factionOfficersButton);
								num += num2;
							}
							this.factionForumButton.ImageNorm = GFXLibrary.faction_buttons[8];
							this.factionForumButton.ImageOver = GFXLibrary.faction_buttons[9];
							this.factionForumButton.Position = new Point(7, num);
							this.factionForumButton.MoveOnClick = true;
							this.factionForumButton.Text.Text = SK.Text("FactionsSidebar_Forum", "Forum");
							this.factionForumButton.Text.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
							this.factionForumButton.Text.Position = new Point(84, 0);
							this.factionForumButton.Text.Size = new Size(94, 40);
							this.factionForumButton.TextYOffset = -3;
							this.factionForumButton.Text.Color = global::ARGBColors.Black;
							this.factionForumButton.Active = true;
							this.factionForumButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.forumClicked), "FactionPanelSideBar_forum");
							this.factionForumButton.CustomTooltipID = 2354;
							this.backgroundImage.addControl(this.factionForumButton);
							num += num2;
						}
					}
					if (!GameEngine.Instance.World.isHeretic())
					{
						if (yourFactionRank == 2 || yourFactionRank == 1)
						{
							this.factionMailFactionButton.ImageNorm = GFXLibrary.faction_buttons[10];
							this.factionMailFactionButton.ImageOver = GFXLibrary.faction_buttons[11];
							this.factionMailFactionButton.Position = new Point(7, num);
							this.factionMailFactionButton.MoveOnClick = true;
							this.factionMailFactionButton.Text.Text = SK.Text("FactionsPanel_MailFaction", "Mail To Faction");
							this.factionMailFactionButton.Text.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
							this.factionMailFactionButton.Text.Position = new Point(84, 0);
							this.factionMailFactionButton.Text.Size = new Size(94, 40);
							this.factionMailFactionButton.TextYOffset = -3;
							this.factionMailFactionButton.Text.Color = global::ARGBColors.Black;
							this.factionMailFactionButton.Active = true;
							this.factionMailFactionButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.mailFactionClicked), "FactionPanelSideBar_mail_faction");
							this.factionMailFactionButton.CustomTooltipID = 2355;
							this.backgroundImage.addControl(this.factionMailFactionButton);
							num += num2;
						}
						this.factionInvitesButton.ImageNorm = GFXLibrary.faction_buttons[12];
						this.factionInvitesButton.ImageOver = GFXLibrary.faction_buttons[13];
						this.factionInvitesButton.Position = new Point(7, num);
						this.factionInvitesButton.MoveOnClick = true;
						this.factionInvitesButton.Text.Text = SK.Text("FactionsPanel_Users", "Invites");
						this.factionInvitesButton.Text.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
						this.factionInvitesButton.Text.Position = new Point(84, 0);
						this.factionInvitesButton.Text.Size = new Size(94, 40);
						this.factionInvitesButton.TextYOffset = -3;
						this.factionInvitesButton.Text.Color = global::ARGBColors.Black;
						this.factionInvitesButton.Active = true;
						this.factionInvitesButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.invitesClicked), "FactionPanelSideBar_invites");
						this.factionInvitesButton.CustomTooltipID = 2356;
						this.backgroundImage.addControl(this.factionInvitesButton);
						num += num2;
					}
					if (RemoteServices.Instance.UserFactionID < 0)
					{
						this.factionStartFactionButton.ImageNorm = GFXLibrary.faction_buttons[16];
						this.factionStartFactionButton.ImageOver = GFXLibrary.faction_buttons[17];
						this.factionStartFactionButton.Position = new Point(7, num);
						this.factionStartFactionButton.MoveOnClick = true;
						this.factionStartFactionButton.Text.Text = SK.Text("FactionsSidebar_Start_Faction", "Start a Faction");
						this.factionStartFactionButton.Text.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
						this.factionStartFactionButton.Text.Position = new Point(84, 0);
						this.factionStartFactionButton.Text.Size = new Size(94, 40);
						this.factionStartFactionButton.TextYOffset = -3;
						this.factionStartFactionButton.Text.Color = global::ARGBColors.Black;
						this.factionStartFactionButton.Active = true;
						this.factionStartFactionButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.startFactionClicked), "FactionPanelSideBar_start_faction");
						this.factionChatButton.CustomTooltipID = 2358;
						this.backgroundImage.addControl(this.factionStartFactionButton);
						num += num2;
						if (GameEngine.Instance.LocalWorldData.IsHereticEUAIWorld)
						{
							this.factionHereticButton.ImageNorm = GFXLibrary.faction_buttons[22];
							this.factionHereticButton.ImageOver = GFXLibrary.faction_buttons[23];
							this.factionHereticButton.Position = new Point(7, num);
							this.factionHereticButton.MoveOnClick = true;
							this.factionHereticButton.Text.Text = SK.Text("FactionsSidebar_Heretic", "Go Heretic!");
							this.factionHereticButton.Text.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
							this.factionHereticButton.Text.Position = new Point(84, 0);
							this.factionHereticButton.Text.Size = new Size(94, 40);
							this.factionHereticButton.TextYOffset = -3;
							this.factionHereticButton.Text.Color = global::ARGBColors.Black;
							this.factionHereticButton.Active = true;
							this.factionHereticButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.goHereticClicked), "FactionPanelSideBar_start_faction");
							this.backgroundImage.addControl(this.factionHereticButton);
							this.factionHereticButton.Enabled = false;
							if (GameEngine.Instance.World.getRank() >= 6)
							{
								this.factionHereticButton.Enabled = true;
							}
							num += num2;
						}
						CustomSelfDrawPanel.WikiLinkControl.init(this.backgroundImage, 23, new Point(this.backgroundImage.Width - 38, num + 5));
					}
					else if (!GameEngine.Instance.World.isHeretic())
					{
						this.factionChatButton.ImageNorm = GFXLibrary.faction_buttons[14];
						this.factionChatButton.ImageOver = GFXLibrary.faction_buttons[15];
						this.factionChatButton.Position = new Point(7, num);
						this.factionChatButton.MoveOnClick = true;
						this.factionChatButton.Text.Text = SK.Text("GENERIC_Chat", "Chat");
						this.factionChatButton.Text.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
						this.factionChatButton.Text.Position = new Point(84, 0);
						this.factionChatButton.Text.Size = new Size(94, 40);
						this.factionChatButton.TextYOffset = -3;
						this.factionChatButton.Text.Color = global::ARGBColors.Black;
						this.factionChatButton.Active = true;
						this.factionChatButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.chatClicked), "FactionPanelSideBar_chat");
						this.factionChatButton.CustomTooltipID = 2357;
						this.backgroundImage.addControl(this.factionChatButton);
						num += num2;
						if (GameEngine.Instance.LocalWorldData.IsHereticEUAIWorld)
						{
							this.factionHereticButton.ImageNorm = GFXLibrary.faction_buttons[22];
							this.factionHereticButton.ImageOver = GFXLibrary.faction_buttons[23];
							this.factionHereticButton.Position = new Point(7, num);
							this.factionHereticButton.MoveOnClick = true;
							this.factionHereticButton.Text.Text = SK.Text("FactionsSidebar_Heretic", "Go Heretic!");
							this.factionHereticButton.Text.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
							this.factionHereticButton.Text.Position = new Point(84, 0);
							this.factionHereticButton.Text.Size = new Size(94, 40);
							this.factionHereticButton.TextYOffset = -3;
							this.factionHereticButton.Text.Color = global::ARGBColors.Black;
							this.factionHereticButton.Active = true;
							this.factionHereticButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.goHereticClicked), "FactionPanelSideBar_start_faction");
							this.backgroundImage.addControl(this.factionHereticButton);
							this.factionHereticButton.Enabled = false;
							if (GameEngine.Instance.World.getRank() >= 6)
							{
								this.factionHereticButton.Enabled = true;
							}
							num += num2;
						}
						CustomSelfDrawPanel.WikiLinkControl.init(this.backgroundImage, 23, new Point(this.backgroundImage.Width - 38, num + 5));
						this.factionLeaveFactionButton.ImageNorm = GFXLibrary.faction_buttons[18];
						this.factionLeaveFactionButton.ImageOver = GFXLibrary.faction_buttons[19];
						this.factionLeaveFactionButton.Position = new Point(7, base.Height - 45);
						this.factionLeaveFactionButton.MoveOnClick = true;
						this.factionLeaveFactionButton.Text.Text = SK.Text("FactionsPanel_Leave_Faction", "Leave Faction");
						this.factionLeaveFactionButton.Text.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
						this.factionLeaveFactionButton.Text.Position = new Point(84, 0);
						this.factionLeaveFactionButton.Text.Size = new Size(94, 40);
						this.factionLeaveFactionButton.TextYOffset = -3;
						this.factionLeaveFactionButton.Text.Color = global::ARGBColors.Black;
						this.factionLeaveFactionButton.Active = true;
						this.factionLeaveFactionButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.leaveFactionClicked), "FactionPanelSideBar_leave_faction");
						this.factionLeaveFactionButton.CustomTooltipID = 2359;
						this.backgroundImage.addControl(this.factionLeaveFactionButton);
					}
				}
				int yourHouse = GameEngine.Instance.World.YourHouse;
				Point position = Point.Empty;
				switch (yourHouse)
				{
				case 1:
					position = this.house1Button.Position;
					break;
				case 2:
					position = this.house2Button.Position;
					break;
				case 3:
					position = this.house3Button.Position;
					break;
				case 4:
					position = this.house4Button.Position;
					break;
				case 5:
					position = this.house5Button.Position;
					break;
				case 6:
					position = this.house6Button.Position;
					break;
				case 7:
					position = this.house7Button.Position;
					break;
				case 8:
					position = this.house8Button.Position;
					break;
				case 9:
					position = this.house9Button.Position;
					break;
				case 10:
					position = this.house10Button.Position;
					break;
				case 11:
					position = this.house11Button.Position;
					break;
				case 12:
					position = this.house12Button.Position;
					break;
				case 13:
					position = this.house13Button.Position;
					break;
				case 14:
					position = this.house14Button.Position;
					break;
				case 15:
					position = this.house15Button.Position;
					break;
				case 16:
					position = this.house16Button.Position;
					break;
				case 17:
					position = this.house17Button.Position;
					break;
				case 18:
					position = this.house18Button.Position;
					break;
				case 19:
					position = this.house19Button.Position;
					break;
				case 20:
					position = this.house20Button.Position;
					break;
				}
				if (!position.IsEmpty)
				{
					this.houseOverlay.Image = GFXLibrary.house_circles_medium_selected_top;
					this.houseOverlay.Position = position;
					this.backgroundImage.addControl(this.houseOverlay);
				}
				this.factionButtonBackground.Image = GFXLibrary.faction_button_background;
				switch (mode)
				{
				case 0:
					this.factionInvitesButton.Active = false;
					this.factionInvitesButton.ImageOver = GFXLibrary.faction_buttons[12];
					this.factionButtonBackground.Visible = true;
					this.factionButtonBackground.Position = new Point(0, this.factionInvitesButton.Position.Y - 3);
					break;
				case 1:
					if (FactionMyFactionPanel.SelectedFaction == RemoteServices.Instance.UserFactionID)
					{
						this.factionMyFactionButton.ImageOver = GFXLibrary.faction_buttons[2];
						this.factionMyFactionButton.Active = false;
						this.factionButtonBackground.Visible = true;
						this.factionButtonBackground.Position = new Point(0, this.factionMyFactionButton.Position.Y - 3);
					}
					break;
				case 2:
					this.factionShowAllButton.Active = false;
					this.factionShowAllButton.ImageOver = GFXLibrary.faction_buttons[0];
					this.factionButtonBackground.Visible = true;
					this.factionButtonBackground.Position = new Point(0, this.factionShowAllButton.Position.Y - 3);
					break;
				case 3:
					this.factionOfficersButton.Active = false;
					this.factionOfficersButton.ImageOver = GFXLibrary.faction_buttons[6];
					this.factionButtonBackground.Visible = true;
					this.factionButtonBackground.Position = new Point(0, this.factionOfficersButton.Position.Y - 3);
					break;
				case 4:
					this.factionDiplomacyButton.Active = false;
					this.factionDiplomacyButton.ImageOver = GFXLibrary.faction_buttons[4];
					this.factionButtonBackground.Visible = true;
					this.factionButtonBackground.Position = new Point(0, this.factionDiplomacyButton.Position.Y - 3);
					break;
				case 5:
					if (RemoteServices.Instance.UserFactionID < 0)
					{
						this.factionStartFactionButton.Active = false;
						this.factionStartFactionButton.ImageOver = GFXLibrary.faction_buttons[16];
						this.factionButtonBackground.Visible = true;
						this.factionButtonBackground.Position = new Point(0, this.factionStartFactionButton.Position.Y - 3);
					}
					break;
				case 6:
					this.factionForumButton.Active = false;
					this.factionForumButton.ImageOver = GFXLibrary.faction_buttons[8];
					this.factionButtonBackground.Visible = true;
					this.factionButtonBackground.Position = new Point(0, this.factionForumButton.Position.Y - 3);
					break;
				case 7:
					this.houseShowAllButton.Active = false;
					this.houseShowAllButton.ImageOver = GFXLibrary.faction_buttons[0];
					this.factionButtonBackground.Visible = true;
					this.factionButtonBackground.Position = new Point(0, this.houseShowAllButton.Position.Y - 3);
					break;
				case 8:
				{
					CustomSelfDrawPanel.CSDButton csdbutton = null;
					switch (HouseInfoPanel.SelectedHouse)
					{
					case 1:
						csdbutton = this.house1Button;
						break;
					case 2:
						csdbutton = this.house2Button;
						break;
					case 3:
						csdbutton = this.house3Button;
						break;
					case 4:
						csdbutton = this.house4Button;
						break;
					case 5:
						csdbutton = this.house5Button;
						break;
					case 6:
						csdbutton = this.house6Button;
						break;
					case 7:
						csdbutton = this.house7Button;
						break;
					case 8:
						csdbutton = this.house8Button;
						break;
					case 9:
						csdbutton = this.house9Button;
						break;
					case 10:
						csdbutton = this.house10Button;
						break;
					case 11:
						csdbutton = this.house11Button;
						break;
					case 12:
						csdbutton = this.house12Button;
						break;
					case 13:
						csdbutton = this.house13Button;
						break;
					case 14:
						csdbutton = this.house14Button;
						break;
					case 15:
						csdbutton = this.house15Button;
						break;
					case 16:
						csdbutton = this.house16Button;
						break;
					case 17:
						csdbutton = this.house17Button;
						break;
					case 18:
						csdbutton = this.house18Button;
						break;
					case 19:
						csdbutton = this.house19Button;
						break;
					case 20:
						csdbutton = this.house20Button;
						break;
					}
					if (csdbutton != null)
					{
						Image image = csdbutton.ImageNorm = (csdbutton.ImageHighlight = csdbutton.ImageOver);
						csdbutton.Active = false;
					}
					break;
				}
				}
				if (this.factionButtonBackground.Position.Y < 10)
				{
					this.factionButtonBackground.Image = GFXLibrary.faction_button_background1;
					return;
				}
				if (this.factionButtonBackground.Position.Y < 50)
				{
					this.factionButtonBackground.Image = GFXLibrary.faction_button_background2;
					return;
				}
				if (this.factionButtonBackground.Position.Y < 90)
				{
					this.factionButtonBackground.Image = GFXLibrary.faction_button_background3;
				}
			}

			// Token: 0x06000DF9 RID: 3577 RVA: 0x0001027F File Offset: 0x0000E47F
			private void showAllClicked()
			{
				InterfaceMgr.Instance.setVillageTabSubMode(43, false);
			}

			// Token: 0x06000DFA RID: 3578 RVA: 0x0001028E File Offset: 0x0000E48E
			private void invitesClicked()
			{
				InterfaceMgr.Instance.setVillageTabSubMode(41, false);
			}

			// Token: 0x06000DFB RID: 3579 RVA: 0x0001029D File Offset: 0x0000E49D
			private void startFactionClicked()
			{
				InterfaceMgr.Instance.showStartFactionPanel();
			}

			// Token: 0x06000DFC RID: 3580 RVA: 0x000102A9 File Offset: 0x0000E4A9
			private void myFactionClicked()
			{
				InterfaceMgr.Instance.showFactionPanel(RemoteServices.Instance.UserFactionID);
			}

			// Token: 0x06000DFD RID: 3581 RVA: 0x000102BF File Offset: 0x0000E4BF
			private void forumClicked()
			{
				InterfaceMgr.Instance.setVillageTabSubMode(45, false);
			}

			// Token: 0x06000DFE RID: 3582 RVA: 0x000102CE File Offset: 0x0000E4CE
			private void officersClicked()
			{
				InterfaceMgr.Instance.setVillageTabSubMode(46, false);
			}

			// Token: 0x06000DFF RID: 3583 RVA: 0x000102DD File Offset: 0x0000E4DD
			private void diplomacyClicked()
			{
				InterfaceMgr.Instance.setVillageTabSubMode(44, false);
			}

			// Token: 0x06000E00 RID: 3584 RVA: 0x000102EC File Offset: 0x0000E4EC
			private void chatClicked()
			{
				if (RemoteServices.Instance.UserFactionID >= 0)
				{
					InterfaceMgr.Instance.initChatPanel(5, RemoteServices.Instance.UserFactionID);
				}
			}

			// Token: 0x06000E01 RID: 3585 RVA: 0x00010310 File Offset: 0x0000E510
			private void LeaveFaction()
			{
				RemoteServices.Instance.set_FactionLeave_UserCallBack(new RemoteServices.FactionLeave_UserCallBack(this.factionLeaveCallback));
				RemoteServices.Instance.FactionLeave();
				InterfaceMgr.Instance.closeGreyOut();
				this.leaveFactionPopup.Close();
			}

			// Token: 0x06000E02 RID: 3586 RVA: 0x00010347 File Offset: 0x0000E547
			private void ClosePopUp()
			{
				if (this.leaveFactionPopup != null)
				{
					if (this.leaveFactionPopup.Created)
					{
						this.leaveFactionPopup.Close();
					}
					InterfaceMgr.Instance.closeGreyOut();
					this.leaveFactionPopup = null;
				}
			}

			// Token: 0x06000E03 RID: 3587 RVA: 0x000FC1D0 File Offset: 0x000FA3D0
			private void leaveFactionClicked()
			{
				this.ClosePopUp();
				InterfaceMgr.Instance.openGreyOutWindow(false);
				this.leaveFactionPopup = new MyMessageBoxPopUp();
				this.leaveFactionPopup.init(SK.Text("FORUMS_Are_You_Sure", "Are you sure?"), SK.Text("FactionsPanel_Leave_Faction", "Leave Faction"), 0, new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.LeaveFaction));
				this.leaveFactionPopup.Show(InterfaceMgr.Instance.getGreyOutWindow());
			}

			// Token: 0x06000E04 RID: 3588 RVA: 0x000FC248 File Offset: 0x000FA448
			public void factionLeaveCallback(FactionLeave_ReturnType returnData)
			{
				if (returnData.Success)
				{
					RemoteServices.Instance.UserFactionID = -1;
					GameEngine.Instance.World.FactionMembers = null;
					GameEngine.Instance.World.FactionInvites = returnData.invites;
					GameEngine.Instance.World.FactionApplications = returnData.applications;
					GameEngine.Instance.World.FactionAllies = null;
					GameEngine.Instance.World.FactionEnemies = null;
					GameEngine.Instance.World.HouseAllies = null;
					GameEngine.Instance.World.HouseEnemies = null;
					GameEngine.Instance.World.HouseInfo = returnData.m_houseData;
					GameEngine.Instance.setNextFactionPage(-1);
					InterfaceMgr.Instance.getFactionTabBar().forceChangeTab(1);
				}
			}

			// Token: 0x06000E05 RID: 3589 RVA: 0x000FC318 File Offset: 0x000FA518
			private void goHereticClicked()
			{
				this.ClosePopUp();
				InterfaceMgr.Instance.openGreyOutWindow(false);
				this.leaveFactionPopup = new MyMessageBoxPopUp();
				this.leaveFactionPopup.setCustomYesText(SK.Text("FactionsSidebar_Heretic", "Go Heretic!"));
				this.leaveFactionPopup.setCustomNoText(SK.Text("FactionsSidebar_StayFree", "Stay Free"));
				this.leaveFactionPopup.init(string.Concat(new string[]
				{
					SK.Text("FactionsPanel_go_heretic_1a", "Beware, going 'Heretic' will put you in the Wolfs faction. He will not let you leave, ever!"),
					Environment.NewLine,
					Environment.NewLine,
					SK.Text("FactionsPanel_go_heretic_1b", "You will win no prizes and not be permitted to attack the wolf or his allies, only his enemies. Consider this choice carefully, it is a hard and lonely road to take."),
					Environment.NewLine
				}), SK.Text("FactionsSidebar_Heretic", "Go Heretic!"), 0, new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.goHereticClicked2));
				this.leaveFactionPopup.Show(InterfaceMgr.Instance.getGreyOutWindow());
			}

			// Token: 0x06000E06 RID: 3590 RVA: 0x000FC3FC File Offset: 0x000FA5FC
			private void goHereticClicked2()
			{
				this.leaveFactionPopup.Close();
				this.leaveFactionPopup = new MyMessageBoxPopUp();
				this.leaveFactionPopup.setCustomYesText(SK.Text("FactionsSidebar_Heretic", "Go Heretic!"));
				this.leaveFactionPopup.setCustomNoText(SK.Text("FactionsSidebar_StayFree", "Stay Free"));
				this.leaveFactionPopup.init(string.Concat(new string[]
				{
					SK.Text("FactionsPanel_go_heretic_2a", "Are you really sure you want to do this?"),
					Environment.NewLine,
					Environment.NewLine,
					SK.Text("FactionsPanel_go_heretic_2b", "This is your last chance, clicking 'Go Heretic' again, will permanently put you in the clutches of the wolf"),
					Environment.NewLine
				}), SK.Text("FactionsSidebar_Heretic", "Go Heretic!"), 0, new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.GoHeretic));
				this.leaveFactionPopup.Show(InterfaceMgr.Instance.getGreyOutWindow());
			}

			// Token: 0x06000E07 RID: 3591 RVA: 0x0001037A File Offset: 0x0000E57A
			private void GoHeretic()
			{
				RemoteServices.Instance.set_FactionApplicationProcessing_UserCallBack(new RemoteServices.FactionApplicationProcessing_UserCallBack(this.GoHereticCallback));
				RemoteServices.Instance.FactionApplicationGoHeretic();
				InterfaceMgr.Instance.closeGreyOut();
				this.leaveFactionPopup.Close();
			}

			// Token: 0x06000E08 RID: 3592 RVA: 0x000FC4D8 File Offset: 0x000FA6D8
			private void GoHereticCallback(FactionApplicationProcessing_ReturnType returnData)
			{
				if (returnData.Success && returnData.members != null)
				{
					GameEngine.Instance.World.FactionMembers = returnData.members;
					GameEngine.Instance.World.YourFaction = returnData.yourFaction;
					InterfaceMgr.Instance.openGreyOutWindow(false);
					this.leaveFactionPopup = new MyMessageBoxPopUp();
					this.leaveFactionPopup.init(SK.Text("FactionsPanel_go_heretic_3b", "You are now in the service of the Wolf, good hunting..") + Environment.NewLine, SK.Text("FactionsSidebar_Heretic_3a", "Heretic!"), 6, new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.HereticFinished));
					this.leaveFactionPopup.Show(InterfaceMgr.Instance.getGreyOutWindow());
				}
			}

			// Token: 0x06000E09 RID: 3593 RVA: 0x000103B1 File Offset: 0x0000E5B1
			private void HereticFinished()
			{
				InterfaceMgr.Instance.closeGreyOut();
				this.leaveFactionPopup.Close();
				GameEngine.Instance.setNextFactionPage(-1);
				InterfaceMgr.Instance.getFactionTabBar().forceChangeTab(1);
			}

			// Token: 0x06000E0A RID: 3594 RVA: 0x000103E3 File Offset: 0x0000E5E3
			public void showAllHousesClicked()
			{
				InterfaceMgr.Instance.setVillageTabSubMode(51, false);
			}

			// Token: 0x06000E0B RID: 3595 RVA: 0x000FC594 File Offset: 0x000FA794
			public void selectHouseClicked()
			{
				GameEngine.Instance.playInterfaceSound("FactionPanelSideBar_house");
				int data = this.m_parent.ClickedControl.Data;
				InterfaceMgr.Instance.showHousePanel(data);
			}

			// Token: 0x06000E0C RID: 3596 RVA: 0x000FC5CC File Offset: 0x000FA7CC
			public void update()
			{
				if (!CustomSelfDrawPanel.FactionPanelSideBar.m_factionDataUpdated)
				{
					return;
				}
				CustomSelfDrawPanel.FactionPanelSideBar.m_factionDataUpdated = false;
				if (this.m_parent != null)
				{
					if (CustomSelfDrawPanel.FactionPanelSideBar.m_currentSidebarMode == 2)
					{
						((FactionAllFactionsPanel)this.m_parent).init(false);
						return;
					}
					if (CustomSelfDrawPanel.FactionPanelSideBar.m_currentSidebarMode == 0)
					{
						((FactionInvitePanel)this.m_parent).init(false);
						return;
					}
					if (CustomSelfDrawPanel.FactionPanelSideBar.m_currentSidebarMode == 1)
					{
						((FactionMyFactionPanel)this.m_parent).init(false);
						return;
					}
					if (CustomSelfDrawPanel.FactionPanelSideBar.m_currentSidebarMode == 4)
					{
						((FactionDiplomacyPanel)this.m_parent).init(false);
					}
				}
			}

			// Token: 0x06000E0D RID: 3597 RVA: 0x000103F2 File Offset: 0x0000E5F2
			public static void logout()
			{
				CustomSelfDrawPanel.FactionPanelSideBar.m_lastFactionUpdate = DateTime.MinValue;
				CustomSelfDrawPanel.FactionPanelSideBar.m_factionDataUpdated = false;
			}

			// Token: 0x06000E0E RID: 3598 RVA: 0x00010404 File Offset: 0x0000E604
			public static void forceReUpdate()
			{
				CustomSelfDrawPanel.FactionPanelSideBar.m_lastFactionUpdate = DateTime.MinValue;
			}

			// Token: 0x06000E0F RID: 3599 RVA: 0x000FC658 File Offset: 0x000FA858
			public static void downloadCurrentFactionInfo()
			{
				if ((DateTime.Now - CustomSelfDrawPanel.FactionPanelSideBar.m_lastFactionUpdate).TotalMinutes > 5.0)
				{
					CustomSelfDrawPanel.FactionPanelSideBar.m_lastFactionUpdate = DateTime.Now;
					RemoteServices.Instance.set_GetFactionData_UserCallBack(new RemoteServices.GetFactionData_UserCallBack(CustomSelfDrawPanel.FactionPanelSideBar.getFactionDataCallback));
					RemoteServices.Instance.GetFactionData(RemoteServices.Instance.UserFactionID, GameEngine.Instance.World.StoredFactionChangesPos);
				}
			}

			// Token: 0x06000E10 RID: 3600 RVA: 0x000FC6CC File Offset: 0x000FA8CC
			public static void getFactionDataCallback(GetFactionData_ReturnType returnData)
			{
				if (returnData.Success)
				{
					if (returnData.factionsList != null)
					{
						GameEngine.Instance.World.processFactionsList(returnData.factionsList, returnData.currentFactionChangePos);
					}
					GameEngine.Instance.World.FactionMembers = returnData.members;
					GameEngine.Instance.World.YourFaction = returnData.yourFaction;
					GameEngine.Instance.World.FactionInvites = returnData.invites;
					GameEngine.Instance.World.FactionApplications = returnData.applications;
					GameEngine.Instance.World.HouseInfo = returnData.m_houseData;
					GameEngine.Instance.World.HouseVoteInfo = returnData.m_houseVoteData;
					GameEngine.Instance.World.FactionAllies = returnData.yourAllies;
					GameEngine.Instance.World.FactionEnemies = returnData.yourEnemies;
					GameEngine.Instance.World.HouseAllies = returnData.yourHouseAllies;
					GameEngine.Instance.World.HouseEnemies = returnData.yourHouseEnemies;
					GameEngine.Instance.World.YourFactionVote = returnData.yourLeaderVote;
					CustomSelfDrawPanel.FactionPanelSideBar.m_factionDataUpdated = true;
				}
			}

			// Token: 0x06000E11 RID: 3601 RVA: 0x000FC7F4 File Offset: 0x000FA9F4
			public void mailFactionClicked()
			{
				FactionMemberData[] factionMembers = GameEngine.Instance.World.FactionMembers;
				if (factionMembers == null)
				{
					return;
				}
				List<string> list = new List<string>();
				FactionMemberData[] array = factionMembers;
				foreach (FactionMemberData factionMemberData in array)
				{
					if (factionMemberData.userID != RemoteServices.Instance.UserID && factionMemberData.status >= 0)
					{
						list.Add(factionMemberData.userName);
					}
				}
				MailScreen.setFromFaction();
				InterfaceMgr.Instance.getMainTabBar().selectDummyTab(21);
				InterfaceMgr.Instance.mailTo(RemoteServices.Instance.UserID, list.ToArray());
			}

			// Token: 0x040011AE RID: 4526
			public const int SIDEBAR_WIDTH = 200;

			// Token: 0x040011AF RID: 4527
			public const int SIDEBAR_MODE_INVITES = 0;

			// Token: 0x040011B0 RID: 4528
			public const int SIDEBAR_MODE_MY_FACTION = 1;

			// Token: 0x040011B1 RID: 4529
			public const int SIDEBAR_MODE_ALL_FACTIONS = 2;

			// Token: 0x040011B2 RID: 4530
			public const int SIDEBAR_MODE_OFFICERS = 3;

			// Token: 0x040011B3 RID: 4531
			public const int SIDEBAR_MODE_DIPLOMACY = 4;

			// Token: 0x040011B4 RID: 4532
			public const int SIDEBAR_MODE_START_FACTION = 5;

			// Token: 0x040011B5 RID: 4533
			public const int SIDEBAR_MODE_FORUM = 6;

			// Token: 0x040011B6 RID: 4534
			public const int SIDEBAR_MODE_HOUSE_LIST = 7;

			// Token: 0x040011B7 RID: 4535
			public const int SIDEBAR_MODE_HOUSE_INFO = 8;

			// Token: 0x040011B8 RID: 4536
			private CustomSelfDrawPanel.CSDVertExtendingPanel backgroundImage = new CustomSelfDrawPanel.CSDVertExtendingPanel();

			// Token: 0x040011B9 RID: 4537
			private CustomSelfDrawPanel.CSDButton factionShowAllButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011BA RID: 4538
			private CustomSelfDrawPanel.CSDButton factionMyFactionButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011BB RID: 4539
			private CustomSelfDrawPanel.CSDButton factionDiplomacyButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011BC RID: 4540
			private CustomSelfDrawPanel.CSDButton factionOfficersButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011BD RID: 4541
			private CustomSelfDrawPanel.CSDButton factionForumButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011BE RID: 4542
			private CustomSelfDrawPanel.CSDButton factionMailFactionButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011BF RID: 4543
			private CustomSelfDrawPanel.CSDButton factionInvitesButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011C0 RID: 4544
			private CustomSelfDrawPanel.CSDButton factionStartFactionButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011C1 RID: 4545
			private CustomSelfDrawPanel.CSDButton factionChatButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011C2 RID: 4546
			private CustomSelfDrawPanel.CSDButton factionHereticButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011C3 RID: 4547
			private CustomSelfDrawPanel.CSDButton factionLeaveFactionButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011C4 RID: 4548
			private CustomSelfDrawPanel.CSDImage factionButtonBackground = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040011C5 RID: 4549
			private CustomSelfDrawPanel.CSDButton houseShowAllButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011C6 RID: 4550
			private CustomSelfDrawPanel.CSDButton house1Button = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011C7 RID: 4551
			private CustomSelfDrawPanel.CSDButton house2Button = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011C8 RID: 4552
			private CustomSelfDrawPanel.CSDButton house3Button = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011C9 RID: 4553
			private CustomSelfDrawPanel.CSDButton house4Button = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011CA RID: 4554
			private CustomSelfDrawPanel.CSDButton house5Button = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011CB RID: 4555
			private CustomSelfDrawPanel.CSDButton house6Button = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011CC RID: 4556
			private CustomSelfDrawPanel.CSDButton house7Button = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011CD RID: 4557
			private CustomSelfDrawPanel.CSDButton house8Button = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011CE RID: 4558
			private CustomSelfDrawPanel.CSDButton house9Button = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011CF RID: 4559
			private CustomSelfDrawPanel.CSDButton house10Button = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011D0 RID: 4560
			private CustomSelfDrawPanel.CSDButton house11Button = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011D1 RID: 4561
			private CustomSelfDrawPanel.CSDButton house12Button = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011D2 RID: 4562
			private CustomSelfDrawPanel.CSDButton house13Button = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011D3 RID: 4563
			private CustomSelfDrawPanel.CSDButton house14Button = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011D4 RID: 4564
			private CustomSelfDrawPanel.CSDButton house15Button = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011D5 RID: 4565
			private CustomSelfDrawPanel.CSDButton house16Button = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011D6 RID: 4566
			private CustomSelfDrawPanel.CSDButton house17Button = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011D7 RID: 4567
			private CustomSelfDrawPanel.CSDButton house18Button = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011D8 RID: 4568
			private CustomSelfDrawPanel.CSDButton house19Button = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011D9 RID: 4569
			private CustomSelfDrawPanel.CSDButton house20Button = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040011DA RID: 4570
			private CustomSelfDrawPanel.CSDImage houseOverlay = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040011DB RID: 4571
			private static int m_currentSidebarMode = -1;

			// Token: 0x040011DC RID: 4572
			private CustomSelfDrawPanel m_parent;

			// Token: 0x040011DD RID: 4573
			private MyMessageBoxPopUp leaveFactionPopup;

			// Token: 0x040011DE RID: 4574
			private static bool m_factionDataUpdated = false;

			// Token: 0x040011DF RID: 4575
			private static DateTime m_lastFactionUpdate = DateTime.MinValue;
		}

		// Token: 0x0200016C RID: 364
		public enum CSD_Text_Alignment
		{
			// Token: 0x040011E1 RID: 4577
			TOP_LEFT,
			// Token: 0x040011E2 RID: 4578
			TOP_CENTER,
			// Token: 0x040011E3 RID: 4579
			TOP_RIGHT,
			// Token: 0x040011E4 RID: 4580
			CENTER_LEFT,
			// Token: 0x040011E5 RID: 4581
			CENTER_CENTER,
			// Token: 0x040011E6 RID: 4582
			CENTER_RIGHT,
			// Token: 0x040011E7 RID: 4583
			BOTTOM_LEFT,
			// Token: 0x040011E8 RID: 4584
			BOTTOM_CENTER,
			// Token: 0x040011E9 RID: 4585
			BOTTOM_RIGHT
		}

		// Token: 0x0200016D RID: 365
		public interface ICardsPanel
		{
			// Token: 0x06000E14 RID: 3604
			void init(int cardsection);

			// Token: 0x06000E15 RID: 3605
			void update();
		}

		// Token: 0x0200016E RID: 366
		public class CSDImage : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x170000BD RID: 189
			// (get) Token: 0x06000E16 RID: 3606 RVA: 0x00010428 File Offset: 0x0000E628
			// (set) Token: 0x06000E17 RID: 3607 RVA: 0x00010430 File Offset: 0x0000E630
			public Image Image
			{
				get
				{
					return this.image;
				}
				set
				{
					if (this.image != value)
					{
						base.invalidate();
					}
					this.image = value;
					this.setSizeToImage();
				}
			}

			// Token: 0x170000BE RID: 190
			// (get) Token: 0x06000E18 RID: 3608 RVA: 0x00010428 File Offset: 0x0000E628
			// (set) Token: 0x06000E19 RID: 3609 RVA: 0x0001044E File Offset: 0x0000E64E
			public Image ImageNoInvalidate
			{
				get
				{
					return this.image;
				}
				set
				{
					this.image = value;
				}
			}

			// Token: 0x170000BF RID: 191
			// (get) Token: 0x06000E1A RID: 3610 RVA: 0x00010428 File Offset: 0x0000E628
			// (set) Token: 0x06000E1B RID: 3611 RVA: 0x00010457 File Offset: 0x0000E657
			public Image ImageNoSizing
			{
				get
				{
					return this.image;
				}
				set
				{
					if (this.image != value)
					{
						base.invalidate();
					}
					this.image = value;
				}
			}

			// Token: 0x170000C0 RID: 192
			// (get) Token: 0x06000E1C RID: 3612 RVA: 0x0001046F File Offset: 0x0000E66F
			// (set) Token: 0x06000E1D RID: 3613 RVA: 0x00010477 File Offset: 0x0000E677
			public float Alpha
			{
				get
				{
					return this.alpha;
				}
				set
				{
					this.alpha = value;
				}
			}

			// Token: 0x170000C1 RID: 193
			// (get) Token: 0x06000E1E RID: 3614 RVA: 0x00010480 File Offset: 0x0000E680
			// (set) Token: 0x06000E1F RID: 3615 RVA: 0x00010488 File Offset: 0x0000E688
			public Color Colorise
			{
				get
				{
					return this.colorise;
				}
				set
				{
					if (this.colorise != value)
					{
						base.invalidate();
					}
					this.colorise = value;
				}
			}

			// Token: 0x170000C2 RID: 194
			// (get) Token: 0x06000E20 RID: 3616 RVA: 0x000104A5 File Offset: 0x0000E6A5
			// (set) Token: 0x06000E21 RID: 3617 RVA: 0x000104AD File Offset: 0x0000E6AD
			public bool Tile
			{
				get
				{
					return this.tile;
				}
				set
				{
					this.tile = value;
				}
			}

			// Token: 0x170000C3 RID: 195
			// (get) Token: 0x06000E22 RID: 3618 RVA: 0x000104B6 File Offset: 0x0000E6B6
			// (set) Token: 0x06000E23 RID: 3619 RVA: 0x000104BE File Offset: 0x0000E6BE
			public bool MirrorFlip
			{
				get
				{
					return this.mirrorFlip;
				}
				set
				{
					this.mirrorFlip = value;
				}
			}

			// Token: 0x06000E24 RID: 3620 RVA: 0x000104C7 File Offset: 0x0000E6C7
			public void setSizeToImage()
			{
				if (this.image != null)
				{
					this.Size = this.image.Size;
				}
			}

			// Token: 0x06000E25 RID: 3621 RVA: 0x000FCA28 File Offset: 0x000FAC28
			public override void draw(Point parentLocation)
			{
				if (this.image == null)
				{
					return;
				}
				Rectangle rectangle = base.Rectangle;
				if (base.Scale != 1.0)
				{
					rectangle.X = (int)((double)rectangle.X * base.Scale);
					rectangle.Y = (int)((double)rectangle.Y * base.Scale);
				}
				rectangle.X += parentLocation.X;
				rectangle.Y += parentLocation.Y;
				Rectangle source = new Rectangle(0, 0, this.image.Width, this.image.Height);
				if (!this.Tile)
				{
					if (base.Scale == 1.0)
					{
						if (this.alpha == 1f && this.colorise == global::ARGBColors.White)
						{
							if (source.Width != rectangle.Width || source.Height != rectangle.Height)
							{
								float num = (float)source.Width;
								float num2 = (float)source.Height;
								if (source.Width != rectangle.Width)
								{
									num -= 0.999f;
								}
								if (source.Height != rectangle.Height)
								{
									num2 -= 0.999f;
								}
								RectangleF source2 = new RectangleF((float)source.X, (float)source.Y, num, num2);
								RectangleF dest = new RectangleF((float)rectangle.X, (float)rectangle.Y, (float)rectangle.Width, (float)rectangle.Height);
								base.csd.drawImage(this.image, source2, dest);
								return;
							}
							if (!this.mirrorFlip && this.Rotate == 0f)
							{
								base.csd.drawImage(this.image, source, rectangle);
								return;
							}
							base.csd.drawImageMirrorRotate(this.image, source, rectangle, this.mirrorFlip, this.Rotate, base.RotateCentre);
							return;
						}
						else
						{
							if (this.alpha <= 0f && !(this.colorise != global::ARGBColors.White))
							{
								return;
							}
							if (source.Width != rectangle.Width || source.Height != rectangle.Height)
							{
								float num3 = (float)source.Width;
								float num4 = (float)source.Height;
								if (source.Width != rectangle.Width)
								{
									num3 -= 0.999f;
								}
								if (source.Height != rectangle.Height)
								{
									num4 -= 0.999f;
								}
								RectangleF source3 = new RectangleF((float)source.X, (float)source.Y, num3, num4);
								RectangleF dest2 = new RectangleF((float)rectangle.X, (float)rectangle.Y, (float)rectangle.Width, (float)rectangle.Height);
								base.csd.drawImage(this.image, source3, dest2, this.alpha, this.colorise);
								return;
							}
							if (!this.mirrorFlip && this.Rotate == 0f)
							{
								base.csd.drawImage(this.image, source, rectangle, this.alpha, this.colorise);
								return;
							}
							base.csd.drawImageMirrorRotateAlpha(this.image, source, rectangle, this.mirrorFlip, this.Rotate, base.RotateCentre, this.alpha);
							return;
						}
					}
					else
					{
						if (this.alpha == 1f && this.colorise == global::ARGBColors.White)
						{
							base.csd.drawImage(this.image, source, rectangle, base.Scale);
							return;
						}
						if (this.alpha > 0f || this.colorise != global::ARGBColors.White)
						{
							base.csd.drawImage(this.image, source, rectangle, this.alpha, base.Scale, this.colorise);
						}
						return;
					}
				}
				else
				{
					if (this.image.Size.Width != 1)
					{
						for (int i = 0; i < this.Size.Height; i += this.image.Size.Height)
						{
							for (int j = 0; j < this.Size.Width; j += this.image.Size.Width)
							{
								Rectangle dest3 = new Rectangle(rectangle.X + j, rectangle.Y + i, this.image.Width, this.image.Height);
								if (this.alpha == 1f && this.colorise == global::ARGBColors.White)
								{
									base.csd.drawImage(this.image, source, dest3);
								}
								else if (this.alpha > 0f || this.colorise != global::ARGBColors.White)
								{
									base.csd.drawImage(this.image, source, dest3, this.alpha, this.colorise);
								}
							}
						}
						return;
					}
					RectangleF source4 = new RectangleF((float)source.X, (float)source.Y, 0.001f, (float)source.Height);
					RectangleF dest4 = new RectangleF((float)rectangle.X, (float)rectangle.Y, (float)rectangle.Width, (float)rectangle.Height);
					if (this.alpha == 1f && this.colorise == global::ARGBColors.White)
					{
						base.csd.drawImage(this.image, source4, dest4);
						return;
					}
					base.csd.drawImage(this.image, source4, dest4, this.alpha, this.colorise);
					return;
				}
			}

			// Token: 0x040011EA RID: 4586
			protected Image image;

			// Token: 0x040011EB RID: 4587
			private float alpha = 1f;

			// Token: 0x040011EC RID: 4588
			private Color colorise = global::ARGBColors.White;

			// Token: 0x040011ED RID: 4589
			private bool tile;

			// Token: 0x040011EE RID: 4590
			private bool mirrorFlip;
		}

		// Token: 0x0200016F RID: 367
		public class CSDImageAnim : CustomSelfDrawPanel.CSDImage
		{
			// Token: 0x06000E27 RID: 3623 RVA: 0x000FCFB4 File Offset: 0x000FB1B4
			public void SetFrames(BaseImage[] frames)
			{
				this.Playing = false;
				this.Frames = frames;
				this.FrameData = new int[frames.Length];
				for (int i = 0; i < this.FrameData.Length; i++)
				{
					this.FrameData[i] = 0;
				}
				this.CurrentFrame = 0;
				this.Interval = 33.0;
				this.CurrentStep = 0;
			}

			// Token: 0x06000E28 RID: 3624 RVA: 0x00010500 File Offset: 0x0000E700
			public void Animate(double now)
			{
				this.Animate(now, -1);
			}

			// Token: 0x06000E29 RID: 3625 RVA: 0x000FD018 File Offset: 0x000FB218
			public bool Animate(double now, int target)
			{
				if (this.Playing)
				{
					this.CurrentFrame = (this.CurrentFrame + 1) % this.Frames.Length;
					base.Image = this.Frames[this.CurrentFrame];
					if (this.FrameData[this.CurrentFrame] == target)
					{
						this.Playing = false;
					}
				}
				return this.Playing;
			}

			// Token: 0x06000E2A RID: 3626 RVA: 0x000FD07C File Offset: 0x000FB27C
			public void NoLoopAnim()
			{
				if (!this.Playing)
				{
					return;
				}
				this.CurrentStep++;
				if (this.CurrentStep < this.Step)
				{
					return;
				}
				this.CurrentFrame++;
				this.CurrentStep = 0;
				if (this.CurrentFrame >= this.Frames.Length)
				{
					this.Playing = false;
					if (this.parent != null)
					{
						this.parent.removeControl(this);
						return;
					}
				}
				else
				{
					base.ImageNoSizing = this.Frames[this.CurrentFrame];
				}
			}

			// Token: 0x040011EF RID: 4591
			public BaseImage[] Frames;

			// Token: 0x040011F0 RID: 4592
			public int[] FrameData;

			// Token: 0x040011F1 RID: 4593
			public int FirstFrame;

			// Token: 0x040011F2 RID: 4594
			public bool Playing;

			// Token: 0x040011F3 RID: 4595
			public int CurrentFrame;

			// Token: 0x040011F4 RID: 4596
			public double Interval;

			// Token: 0x040011F5 RID: 4597
			public int Step = 1;

			// Token: 0x040011F6 RID: 4598
			private int CurrentStep;
		}

		// Token: 0x02000170 RID: 368
		public class CSDVertImageScroller : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06000E2C RID: 3628 RVA: 0x000FD108 File Offset: 0x000FB308
			public void init(Point position, BaseImage[] sourceImages, int[] sourceIDs)
			{
				this.initialPosition = position;
				this.Position = position;
				this.Images = new CustomSelfDrawPanel.CSDImage[sourceImages.Length + 1];
				int num = 0;
				int width = 0;
				for (int i = 0; i <= sourceImages.Length; i++)
				{
					CustomSelfDrawPanel.CSDImage csdimage = new CustomSelfDrawPanel.CSDImage();
					if (i == sourceImages.Length)
					{
						csdimage.Size = sourceImages[0].Size;
						csdimage.Image = sourceImages[0];
					}
					else
					{
						csdimage.Image = sourceImages[i];
						csdimage.Size = sourceImages[i].Size;
					}
					if (i == 0)
					{
						csdimage.Position = new Point(0, 0);
					}
					else
					{
						csdimage.Position = new Point(0, this.Images[i - 1].Y - csdimage.Height);
					}
					this.Images[i] = csdimage;
					if (i < sourceIDs.Length && !this.ImageOffsets.ContainsKey(sourceIDs[i]))
					{
						this.ImageOffsets.Add(sourceIDs[i], -csdimage.Y);
					}
					else if (i == sourceIDs.Length)
					{
						this.ImageOffsets[sourceIDs[0]] = -csdimage.Y;
					}
					base.addControl(csdimage);
					if (base.Width < csdimage.Width)
					{
						width = csdimage.Width;
					}
					if (i < sourceImages.Length)
					{
						num += csdimage.Height;
					}
				}
				this.Size = new Size(width, num);
				base.ClipRect = new Rectangle(0, 0, this.Images[0].Width, this.Images[0].Height);
			}

			// Token: 0x06000E2D RID: 3629 RVA: 0x000FD278 File Offset: 0x000FB478
			public void scroll(int speed)
			{
				this.scrolling = true;
				this.Position = new Point(this.Position.X, this.Position.Y + speed);
				base.ClipRect = new Rectangle(base.ClipRect.X, base.ClipRect.Y - speed, base.ClipRect.Width, base.ClipRect.Height);
				if (this.Position.Y > this.initialPosition.Y + base.Height)
				{
					this.Position = new Point(this.Position.X, this.Position.Y - base.Height);
					base.ClipRect = new Rectangle(base.ClipRect.X, base.ClipRect.Y + base.Height, base.ClipRect.Width, base.ClipRect.Height);
				}
			}

			// Token: 0x06000E2E RID: 3630 RVA: 0x000FD394 File Offset: 0x000FB594
			public void scroll(int speed, int stop)
			{
				if (this.Position.Y - this.initialPosition.Y <= this.ImageOffsets[stop] && this.Position.Y - this.initialPosition.Y + speed >= this.ImageOffsets[stop])
				{
					this.Position = new Point(this.Position.X, this.initialPosition.Y + this.ImageOffsets[stop]);
					base.ClipRect = new Rectangle(base.ClipRect.X, -this.ImageOffsets[stop], base.ClipRect.Width, base.ClipRect.Height);
					this.scrolling = false;
					return;
				}
				this.scroll(speed);
			}

			// Token: 0x040011F7 RID: 4599
			public CustomSelfDrawPanel.CSDImage[] Images;

			// Token: 0x040011F8 RID: 4600
			public Dictionary<int, int> ImageOffsets = new Dictionary<int, int>();

			// Token: 0x040011F9 RID: 4601
			public Point initialPosition;

			// Token: 0x040011FA RID: 4602
			public bool scrolling;
		}

		// Token: 0x02000171 RID: 369
		public class CSDLabel : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x170000C4 RID: 196
			// (get) Token: 0x06000E30 RID: 3632 RVA: 0x0001052D File Offset: 0x0000E72D
			// (set) Token: 0x06000E31 RID: 3633 RVA: 0x00010535 File Offset: 0x0000E735
			public string Text
			{
				get
				{
					return this.text;
				}
				set
				{
					this.text = value;
					base.invalidate();
				}
			}

			// Token: 0x170000C5 RID: 197
			// (get) Token: 0x06000E32 RID: 3634 RVA: 0x0001052D File Offset: 0x0000E72D
			// (set) Token: 0x06000E33 RID: 3635 RVA: 0x00010544 File Offset: 0x0000E744
			public string TextDiffOnly
			{
				get
				{
					return this.text;
				}
				set
				{
					if (this.text != value)
					{
						this.text = value;
						base.invalidate();
					}
				}
			}

			// Token: 0x170000C6 RID: 198
			// (get) Token: 0x06000E34 RID: 3636 RVA: 0x000FD478 File Offset: 0x000FB678
			public Size TextSize
			{
				get
				{
					Size result = default(Size);
					Graphics graphics = base.csd.CreateGraphics();
					result = graphics.MeasureString(this.text, this.Font, base.Width).ToSize();
					graphics.Dispose();
					return result;
				}
			}

			// Token: 0x170000C7 RID: 199
			// (get) Token: 0x06000E35 RID: 3637 RVA: 0x000FD4C4 File Offset: 0x000FB6C4
			public Size TextSizeX
			{
				get
				{
					Size result = default(Size);
					Graphics graphics = base.csd.CreateGraphics();
					result = graphics.MeasureString(this.text, this.Font, base.Width).ToSize();
					graphics.Dispose();
					result.Width += 2;
					result.Height += 2;
					return result;
				}
			}

			// Token: 0x170000C8 RID: 200
			// (get) Token: 0x06000E36 RID: 3638 RVA: 0x00010561 File Offset: 0x0000E761
			// (set) Token: 0x06000E37 RID: 3639 RVA: 0x00010569 File Offset: 0x0000E769
			public CustomSelfDrawPanel.CSD_Text_Alignment Alignment
			{
				get
				{
					return this.alignment;
				}
				set
				{
					this.alignment = value;
				}
			}

			// Token: 0x170000C9 RID: 201
			// (get) Token: 0x06000E38 RID: 3640 RVA: 0x00010572 File Offset: 0x0000E772
			// (set) Token: 0x06000E39 RID: 3641 RVA: 0x0001057A File Offset: 0x0000E77A
			public Color Color
			{
				get
				{
					return this.color;
				}
				set
				{
					this.color = value;
					base.invalidate();
				}
			}

			// Token: 0x170000CA RID: 202
			// (get) Token: 0x06000E3A RID: 3642 RVA: 0x00010589 File Offset: 0x0000E789
			// (set) Token: 0x06000E3B RID: 3643 RVA: 0x00010591 File Offset: 0x0000E791
			public Color RolloverColor
			{
				get
				{
					return this.rolloverColor;
				}
				set
				{
					this.rolloverColor = value;
					base.invalidate();
					base.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.colourRollover), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.colourRolloff));
					this.defaultColor = this.color;
				}
			}

			// Token: 0x170000CB RID: 203
			// (get) Token: 0x06000E3C RID: 3644 RVA: 0x000105CA File Offset: 0x0000E7CA
			// (set) Token: 0x06000E3D RID: 3645 RVA: 0x000105D2 File Offset: 0x0000E7D2
			public Color DropShadowColor
			{
				get
				{
					return this.dropShadowColor;
				}
				set
				{
					this.dropShadowColor = value;
					this.dropShadow = true;
					base.invalidate();
				}
			}

			// Token: 0x170000CC RID: 204
			// (get) Token: 0x06000E3E RID: 3646 RVA: 0x000105E8 File Offset: 0x0000E7E8
			// (set) Token: 0x06000E3F RID: 3647 RVA: 0x000105F0 File Offset: 0x0000E7F0
			public Font Font
			{
				get
				{
					return this.font;
				}
				set
				{
					this.font = value;
				}
			}

			// Token: 0x06000E40 RID: 3648 RVA: 0x000105F9 File Offset: 0x0000E7F9
			private void colourRollover()
			{
				this.Color = this.rolloverColor;
			}

			// Token: 0x06000E41 RID: 3649 RVA: 0x00010607 File Offset: 0x0000E807
			private void colourRolloff()
			{
				this.Color = this.defaultColor;
			}

			// Token: 0x06000E42 RID: 3650 RVA: 0x00010615 File Offset: 0x0000E815
			public void clearDropShadow()
			{
				this.dropShadow = false;
			}

			// Token: 0x06000E43 RID: 3651 RVA: 0x000FD52C File Offset: 0x000FB72C
			public override void draw(Point parentLocation)
			{
				Rectangle rectangle = base.Rectangle;
				Font font = this.font;
				if (base.Scale != 1.0)
				{
					if (this.font.SizeInPoints * (float)base.Scale < 6f)
					{
						return;
					}
					rectangle.X = (int)((double)rectangle.X * base.Scale);
					rectangle.Y = (int)((double)rectangle.Y * base.Scale);
					rectangle.Width = (int)((double)rectangle.Width * base.Scale);
					rectangle.Height = (int)((double)rectangle.Height * base.Scale);
					font = new Font(this.font.FontFamily, this.font.SizeInPoints * (float)base.Scale, this.font.Style);
				}
				rectangle.X += parentLocation.X;
				rectangle.Y += parentLocation.Y;
				if (this.dropShadow)
				{
					int num = rectangle.X;
					rectangle.X = num + 1;
					num = rectangle.Y;
					rectangle.Y = num + 1;
					base.csd.drawString(this.Text, rectangle, this.dropShadowColor, font, this.alignment);
					num = rectangle.X;
					rectangle.X = num - 1;
					num = rectangle.Y;
					rectangle.Y = num - 1;
				}
				base.csd.drawString(this.Text, rectangle, this.color, font, this.alignment);
			}

			// Token: 0x040011FB RID: 4603
			private string text = "";

			// Token: 0x040011FC RID: 4604
			private CustomSelfDrawPanel.CSD_Text_Alignment alignment;

			// Token: 0x040011FD RID: 4605
			private Color color = global::ARGBColors.Black;

			// Token: 0x040011FE RID: 4606
			private Color rolloverColor = global::ARGBColors.Black;

			// Token: 0x040011FF RID: 4607
			private Color defaultColor = global::ARGBColors.Black;

			// Token: 0x04001200 RID: 4608
			private Color dropShadowColor = global::ARGBColors.Black;

			// Token: 0x04001201 RID: 4609
			private bool dropShadow;

			// Token: 0x04001202 RID: 4610
			private Font font = FontManager.GetFont("Arial", 8.25f);
		}

		// Token: 0x02000172 RID: 370
		public class CSDFloatingText : CustomSelfDrawPanel.CSDLabel
		{
			// Token: 0x06000E45 RID: 3653 RVA: 0x000FD718 File Offset: 0x000FB918
			public void init(Point pos, Size size, Color basecolor, Color dropcolor, int _dx, int _dy, int _da, string text, int fontsize, double _interval, double _lifespan, double _start, CustomSelfDrawPanel.CSDControl _parent)
			{
				this.Position = pos;
				this.Size = size;
				base.Text = text;
				base.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				base.Font = FontManager.GetFont("Arial", (float)fontsize, FontStyle.Bold);
				base.Color = basecolor;
				base.DropShadowColor = dropcolor;
				this.BaseColor = basecolor;
				this.BaseDrop = dropcolor;
				this.dx = _dx;
				this.dy = _dy;
				this.da = _da;
				this.interval = _interval;
				this.lifespan = _lifespan;
				this.start = _start;
				_parent.addControl(this);
				this.currentAlpha = 255;
			}

			// Token: 0x06000E46 RID: 3654 RVA: 0x000FD7B8 File Offset: 0x000FB9B8
			public void move(double now)
			{
				if (!this.live)
				{
					return;
				}
				if (now - this.start < this.lifespan)
				{
					if (now - this.last >= this.interval)
					{
						this.Position = new Point(this.Position.X + this.dx, this.Position.Y + this.dy);
						this.currentAlpha += this.da;
						if (this.currentAlpha < 0)
						{
							this.currentAlpha = 0;
						}
						else if (this.currentAlpha > 255)
						{
							this.currentAlpha = 255;
						}
						base.Color = Color.FromArgb(this.currentAlpha, this.BaseColor);
						base.DropShadowColor = Color.FromArgb(this.currentAlpha, this.BaseDrop);
						this.last = now;
						return;
					}
				}
				else
				{
					if (this.parent != null)
					{
						this.parent.removeControl(this);
					}
					this.live = false;
					if (this.parent != null)
					{
						this.parent.invalidate();
					}
				}
			}

			// Token: 0x04001203 RID: 4611
			public int dx;

			// Token: 0x04001204 RID: 4612
			public int dy;

			// Token: 0x04001205 RID: 4613
			public int da;

			// Token: 0x04001206 RID: 4614
			public Color BaseColor;

			// Token: 0x04001207 RID: 4615
			public Color BaseDrop;

			// Token: 0x04001208 RID: 4616
			public int currentAlpha;

			// Token: 0x04001209 RID: 4617
			public double interval;

			// Token: 0x0400120A RID: 4618
			public double lifespan;

			// Token: 0x0400120B RID: 4619
			public double start;

			// Token: 0x0400120C RID: 4620
			public double last;

			// Token: 0x0400120D RID: 4621
			public bool live = true;
		}

		// Token: 0x02000173 RID: 371
		public class UICardsButtons : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x170000CD RID: 205
			// (get) Token: 0x06000E48 RID: 3656 RVA: 0x0001062D File Offset: 0x0000E82D
			// (set) Token: 0x06000E49 RID: 3657 RVA: 0x000FD8CC File Offset: 0x000FBACC
			public bool Available
			{
				get
				{
					return this.mAvailable;
				}
				set
				{
					this.mAvailable = value;
					this.buyButton.Enabled = this.mAvailable;
					this.crownsButton.Enabled = this.mAvailable;
					this.manageButton.Enabled = this.mAvailable;
					this.premiumButton.Enabled = this.mAvailable;
					this.inviteButton.Enabled = (this.mAvailable && !GameEngine.Instance.cardsManager.PremiumOfferAvailable());
					this.offersButton.Enabled = (this.mAvailable && GameEngine.Instance.cardsManager.PremiumOfferAvailable());
				}
			}

			// Token: 0x06000E4A RID: 3658 RVA: 0x000FD974 File Offset: 0x000FBB74
			public UICardsButtons(PlayCardsWindow window)
			{
				this.cardsWindow = window;
				this.mAvailable = true;
				this.buyButton = new CustomSelfDrawPanel.CSDButton();
				this.premiumButton = new CustomSelfDrawPanel.CSDButton();
				this.crownsButton = new CustomSelfDrawPanel.CSDButton();
				this.manageButton = new CustomSelfDrawPanel.CSDButton();
				this.inviteButton = new CustomSelfDrawPanel.CSDButton();
				this.offersButton = new CustomSelfDrawPanel.CSDButton();
				this.buyButton.ImageNorm = GFXLibrary.cardpanel_RH_button_v2_getcards_normal;
				this.premiumButton.ImageNorm = GFXLibrary.cardpanel_RH_button_v2_getpremium_normal;
				this.crownsButton.ImageNorm = GFXLibrary.cardpanel_RH_button_v2_buycrowns_normal;
				this.manageButton.ImageNorm = GFXLibrary.cardpanel_RH_button_v2_choose_cards_normal;
				this.inviteButton.ImageNorm = GFXLibrary.cardpanel_RH_button_v2_friend_normal;
				this.offersButton.ImageNorm = GFXLibrary.cardpanel_RH_button_v2_offers_normal;
				this.buyButton.ImageOver = GFXLibrary.cardpanel_RH_button_v2_getcards_over;
				this.premiumButton.ImageOver = GFXLibrary.cardpanel_RH_button_v2_getpremium_over;
				this.crownsButton.ImageOver = GFXLibrary.cardpanel_RH_button_v2_buycrowns_over;
				this.manageButton.ImageOver = GFXLibrary.cardpanel_RH_button_v2_choose_cards_over;
				this.inviteButton.ImageOver = GFXLibrary.cardpanel_RH_button_v2_friend_over;
				this.offersButton.ImageOver = GFXLibrary.cardpanel_RH_button_v2_offers_over;
				CustomSelfDrawPanel.CSDButton csdbutton = null;
				switch (window.CurrentPanelID)
				{
				case 2:
					csdbutton = this.buyButton;
					break;
				case 4:
					csdbutton = this.premiumButton;
					break;
				case 6:
					csdbutton = this.manageButton;
					break;
				case 7:
					csdbutton = this.crownsButton;
					break;
				case 9:
					csdbutton = this.offersButton;
					break;
				}
				if (csdbutton != null)
				{
					csdbutton.ImageNorm = GFXLibrary.cardpanel_RH_button_back_normal;
					csdbutton.ImageOver = GFXLibrary.cardpanel_RH_button_back_over;
					csdbutton.addControl(new CustomSelfDrawPanel.CSDLabel
					{
						Position = new Point(0, 31),
						Size = csdbutton.Size,
						Text = SK.Text("CARDS_BackToPlayCarads", "Back to Play Cards"),
						Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER,
						Font = FontManager.GetFont("Arial", 11f, FontStyle.Regular),
						Color = global::ARGBColors.Black
					});
				}
				this.inviteButton.Position = new Point(11, 7);
				this.offersButton.Position = new Point(11, 7);
				this.manageButton.Position = new Point(11, 117);
				this.buyButton.Position = new Point(11, 227);
				this.premiumButton.Position = new Point(11, 337);
				this.crownsButton.Position = new Point(11, 447);
				this.buyButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.buyclick), "UICardsButtons_get_cards");
				this.premiumButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.premiumclick), "UICardsButtons_premium");
				this.crownsButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.cardsWindow.GetCrowns), "UICardsButtons_get_crowns");
				this.manageButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.manageclick), "UICardsButtons_swap_cards");
				this.inviteButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.cardsWindow.InviteAFriend), "UICardsButtons_invite_a_friend");
				this.offersButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.offersclick), "UICardsButtons_show_offers");
				this.Size = new Size(200, this.buyButton.Height + this.premiumButton.Height + this.crownsButton.Height + this.manageButton.Height);
				base.addControl(this.buyButton);
				base.addControl(this.premiumButton);
				base.addControl(this.crownsButton);
				base.addControl(this.manageButton);
				base.addControl(this.offersButton);
				if (!GameEngine.Instance.World.isBigpointAccount && !Program.bigpointInstall && !Program.aeriaInstall && !Program.bigpointPartnerInstall && window.CurrentPanelID != 9)
				{
					base.addControl(this.inviteButton);
				}
			}

			// Token: 0x06000E4B RID: 3659 RVA: 0x00010635 File Offset: 0x0000E835
			public void buyclick()
			{
				this.cardsWindow.SwitchPanel(2);
			}

			// Token: 0x06000E4C RID: 3660 RVA: 0x00010643 File Offset: 0x0000E843
			public void premiumclick()
			{
				this.cardsWindow.SwitchPanel(4);
			}

			// Token: 0x06000E4D RID: 3661 RVA: 0x00010651 File Offset: 0x0000E851
			public void manageclick()
			{
				this.cardsWindow.SwitchPanel(6);
			}

			// Token: 0x06000E4E RID: 3662 RVA: 0x0001065F File Offset: 0x0000E85F
			public void offersclick()
			{
				this.cardsWindow.SwitchPanel(9);
				GameEngine.Instance.cardsManager.PremiumOffersViewed = true;
			}

			// Token: 0x0400120E RID: 4622
			public CustomSelfDrawPanel.CSDButton buyButton;

			// Token: 0x0400120F RID: 4623
			public CustomSelfDrawPanel.CSDButton premiumButton;

			// Token: 0x04001210 RID: 4624
			public CustomSelfDrawPanel.CSDButton crownsButton;

			// Token: 0x04001211 RID: 4625
			public CustomSelfDrawPanel.CSDButton manageButton;

			// Token: 0x04001212 RID: 4626
			public CustomSelfDrawPanel.CSDButton inviteButton;

			// Token: 0x04001213 RID: 4627
			public CustomSelfDrawPanel.CSDButton offersButton;

			// Token: 0x04001214 RID: 4628
			public PlayCardsWindow cardsWindow;

			// Token: 0x04001215 RID: 4629
			public bool mAvailable;
		}

		// Token: 0x02000174 RID: 372
		public class CSDArea : CustomSelfDrawPanel.CSDControl
		{
		}

		// Token: 0x02000175 RID: 373
		public class CSDScrollLabel : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x170000CE RID: 206
			// (get) Token: 0x06000E50 RID: 3664 RVA: 0x0001067E File Offset: 0x0000E87E
			// (set) Token: 0x06000E51 RID: 3665 RVA: 0x00010686 File Offset: 0x0000E886
			public string Text
			{
				get
				{
					return this.text;
				}
				set
				{
					this.text = value;
					base.invalidate();
					this.dirty = true;
				}
			}

			// Token: 0x170000CF RID: 207
			// (get) Token: 0x06000E52 RID: 3666 RVA: 0x0001069C File Offset: 0x0000E89C
			// (set) Token: 0x06000E53 RID: 3667 RVA: 0x000106A4 File Offset: 0x0000E8A4
			public int VerticalOffset
			{
				get
				{
					return this.verticalOffset;
				}
				set
				{
					this.verticalOffset = value;
					base.invalidate();
				}
			}

			// Token: 0x170000D0 RID: 208
			// (get) Token: 0x06000E54 RID: 3668 RVA: 0x000106B3 File Offset: 0x0000E8B3
			// (set) Token: 0x06000E55 RID: 3669 RVA: 0x000106BB File Offset: 0x0000E8BB
			public Color Color
			{
				get
				{
					return this.color;
				}
				set
				{
					this.color = value;
					base.invalidate();
				}
			}

			// Token: 0x170000D1 RID: 209
			// (set) Token: 0x06000E56 RID: 3670 RVA: 0x000106CA File Offset: 0x0000E8CA
			public Font Font
			{
				set
				{
					this.font = value;
					this.dirty = true;
				}
			}

			// Token: 0x170000D2 RID: 210
			// (get) Token: 0x06000E57 RID: 3671 RVA: 0x000106DA File Offset: 0x0000E8DA
			public int TextHeight
			{
				get
				{
					return this.textHeight;
				}
			}

			// Token: 0x06000E58 RID: 3672 RVA: 0x000106E2 File Offset: 0x0000E8E2
			public void setTextHeightChangedCallback(CustomSelfDrawPanel.CSDScrollLabel.CSD_TextHeightChanged callback)
			{
				this.textHeightDelegate = callback;
			}

			// Token: 0x06000E59 RID: 3673 RVA: 0x000FDDA4 File Offset: 0x000FBFA4
			public override void draw(Point parentLocation)
			{
				if (this.dirty)
				{
					this.textHeight = (int)base.csd.getStringBounds(this.Text, base.Rectangle.Width, this.font).Height;
					this.dirty = false;
					if (this.textHeightDelegate != null)
					{
						this.textHeightDelegate(this.textHeight);
					}
				}
				Rectangle rectangle = base.Rectangle;
				Font font = this.font;
				if (base.Scale != 1.0)
				{
					if (this.font.SizeInPoints * (float)base.Scale < 6f)
					{
						return;
					}
					rectangle.X = (int)((double)rectangle.X * base.Scale);
					rectangle.Y = (int)((double)rectangle.Y * base.Scale);
					rectangle.Width = (int)((double)rectangle.Width * base.Scale);
					rectangle.Height = (int)((double)rectangle.Height * base.Scale);
					font = new Font(this.font.FontFamily, this.font.SizeInPoints * (float)base.Scale, this.font.Style);
				}
				rectangle.X += parentLocation.X;
				rectangle.Y += parentLocation.Y;
				base.csd.setClipRegion(rectangle);
				rectangle.Y -= this.verticalOffset;
				rectangle.Height = 100000;
				base.csd.drawString(this.Text, rectangle, this.color, font, CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT);
				base.csd.restoreClipRegion();
			}

			// Token: 0x04001216 RID: 4630
			private bool dirty = true;

			// Token: 0x04001217 RID: 4631
			private string text = "";

			// Token: 0x04001218 RID: 4632
			private int verticalOffset;

			// Token: 0x04001219 RID: 4633
			private Color color = global::ARGBColors.Black;

			// Token: 0x0400121A RID: 4634
			private Font font = FontManager.GetFont("Arial", 8.25f);

			// Token: 0x0400121B RID: 4635
			private CustomSelfDrawPanel.CSDScrollLabel.CSD_TextHeightChanged textHeightDelegate;

			// Token: 0x0400121C RID: 4636
			private int textHeight;

			// Token: 0x02000176 RID: 374
			// (Invoke) Token: 0x06000E5C RID: 3676
			public delegate void CSD_TextHeightChanged(int textHeight);
		}

		// Token: 0x02000177 RID: 375
		public class CSDFactionFlagImage : CustomSelfDrawPanel.CSDImage
		{
			// Token: 0x170000D3 RID: 211
			// (get) Token: 0x06000E5F RID: 3679 RVA: 0x00010725 File Offset: 0x0000E925
			// (set) Token: 0x06000E60 RID: 3680 RVA: 0x0001072D File Offset: 0x0000E92D
			public override Size Size
			{
				get
				{
					return base.Size;
				}
				set
				{
					base.Size = value;
				}
			}

			// Token: 0x170000D4 RID: 212
			// (get) Token: 0x06000E61 RID: 3681 RVA: 0x00010736 File Offset: 0x0000E936
			// (set) Token: 0x06000E62 RID: 3682 RVA: 0x0001073E File Offset: 0x0000E93E
			public ColorMap[] ColourMap
			{
				get
				{
					return this.colourMap;
				}
				set
				{
					this.colourMap = value;
				}
			}

			// Token: 0x06000E63 RID: 3683 RVA: 0x000FDF50 File Offset: 0x000FC150
			public void createFromFlagData(int flagData)
			{
				int num = 0;
				int colour = 0;
				int colour2 = 0;
				int colour3 = 0;
				int colour4 = 0;
				FactionData.getFlagData(flagData, ref num, ref colour, ref colour2, ref colour3, ref colour4);
				if (num >= 0 && num < GFXLibrary.factionFlags.Length)
				{
					base.Image = GFXLibrary.factionFlags[num];
				}
				else
				{
					base.Image = GFXLibrary.factionFlags[0];
				}
				this.ColourMap = FactionData.getColourMap(colour, colour2, colour3, colour4, 255);
			}

			// Token: 0x06000E64 RID: 3684 RVA: 0x000FDFC4 File Offset: 0x000FC1C4
			public override void draw(Point parentLocation)
			{
				if (this.image != null)
				{
					Rectangle rectangle = base.Rectangle;
					rectangle.X += parentLocation.X;
					rectangle.Y += parentLocation.Y;
					Rectangle source = new Rectangle(0, 0, this.image.Width, this.image.Height);
					if (base.Scale != 1.0)
					{
						rectangle.Width = (int)((double)rectangle.Width * base.Scale);
						rectangle.Height = (int)((double)rectangle.Height * base.Scale);
					}
					if (this.colourMap != null)
					{
						base.csd.drawImageColourMap(this.image, source, rectangle, this.colourMap);
					}
					else
					{
						base.csd.drawImage(this.image, source, rectangle);
					}
					if (base.Scale == 1.0)
					{
						base.csd.drawImage(GFXLibrary.faction_flag_outline_100, source, rectangle);
						return;
					}
					if (base.Scale > 0.4000000059604645)
					{
						base.csd.drawImage(GFXLibrary.faction_flag_outline_50, new Rectangle(0, 0, GFXLibrary.faction_flag_outline_50.Width, GFXLibrary.faction_flag_outline_50.Height), rectangle);
						return;
					}
					base.csd.drawImage(GFXLibrary.faction_flag_outline_25, new Rectangle(0, 0, GFXLibrary.faction_flag_outline_25.Width, GFXLibrary.faction_flag_outline_25.Height), rectangle);
				}
			}

			// Token: 0x0400121D RID: 4637
			private ColorMap[] colourMap;

			// Token: 0x0400121E RID: 4638
			private CustomSelfDrawPanel.CSDImage flagOverlayImage;
		}

		// Token: 0x02000178 RID: 376
		public class CSDCheckBox : CustomSelfDrawPanel.CSDImage
		{
			// Token: 0x170000D5 RID: 213
			// (get) Token: 0x06000E66 RID: 3686 RVA: 0x000FE140 File Offset: 0x000FC340
			public CustomSelfDrawPanel.CSDLabel CBLabel
			{
				get
				{
					if (this.textLabel == null)
					{
						this.textLabel = new CustomSelfDrawPanel.CSDLabel();
						this.textLabel.CustomTooltipID = base.CustomTooltipID;
						this.textLabel.CustomTooltipData = base.CustomTooltipData;
						base.addControl(this.textLabel);
					}
					return this.textLabel;
				}
			}

			// Token: 0x170000D6 RID: 214
			// (set) Token: 0x06000E67 RID: 3687 RVA: 0x0001074F File Offset: 0x0000E94F
			public Image CheckedImage
			{
				set
				{
					this.checkedImage = value;
				}
			}

			// Token: 0x170000D7 RID: 215
			// (set) Token: 0x06000E68 RID: 3688 RVA: 0x00010758 File Offset: 0x0000E958
			public Image UncheckedImage
			{
				set
				{
					this.uncheckedImage = value;
					base.Image = value;
				}
			}

			// Token: 0x170000D8 RID: 216
			// (set) Token: 0x06000E69 RID: 3689 RVA: 0x00010768 File Offset: 0x0000E968
			public Image CheckedOverImage
			{
				set
				{
					this.checkedOverImage = value;
				}
			}

			// Token: 0x170000D9 RID: 217
			// (set) Token: 0x06000E6A RID: 3690 RVA: 0x00010771 File Offset: 0x0000E971
			public Image UncheckedOverImage
			{
				set
				{
					this.uncheckedOverImage = value;
				}
			}

			// Token: 0x170000DA RID: 218
			// (get) Token: 0x06000E6B RID: 3691 RVA: 0x0001077A File Offset: 0x0000E97A
			// (set) Token: 0x06000E6C RID: 3692 RVA: 0x00010782 File Offset: 0x0000E982
			public bool Checked
			{
				get
				{
					return this.boxChecked;
				}
				set
				{
					this.boxChecked = value;
					this.updateImage();
				}
			}

			// Token: 0x06000E6D RID: 3693 RVA: 0x00010791 File Offset: 0x0000E991
			public CSDCheckBox()
			{
				base.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.toggled), "Generic_check_box_toggled");
				base.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.enterCB), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.leaveCB));
			}

			// Token: 0x06000E6E RID: 3694 RVA: 0x000107CE File Offset: 0x0000E9CE
			public override void onClear()
			{
				this.textLabel = null;
			}

			// Token: 0x06000E6F RID: 3695 RVA: 0x000107D7 File Offset: 0x0000E9D7
			public bool isMouseOver()
			{
				return this.over;
			}

			// Token: 0x06000E70 RID: 3696 RVA: 0x000FE194 File Offset: 0x000FC394
			private void updateImage()
			{
				if (this.boxChecked)
				{
					if (!this.over || this.checkedOverImage == null)
					{
						if (base.Image != this.checkedImage)
						{
							base.Image = this.checkedImage;
						}
					}
					else if (base.Image != this.checkedOverImage)
					{
						base.Image = this.checkedOverImage;
					}
				}
				else if (!this.over || this.uncheckedOverImage == null)
				{
					if (base.Image != this.uncheckedImage)
					{
						base.Image = this.uncheckedImage;
					}
				}
				else if (base.Image != this.uncheckedOverImage)
				{
					base.Image = this.uncheckedOverImage;
				}
				base.invalidate();
			}

			// Token: 0x06000E71 RID: 3697 RVA: 0x000107DF File Offset: 0x0000E9DF
			private void toggled()
			{
				this.Checked = !this.boxChecked;
				if (this.checkChangedDelegate != null)
				{
					base.csd.ClickedControl = this;
					this.checkChangedDelegate();
				}
			}

			// Token: 0x06000E72 RID: 3698 RVA: 0x0001080F File Offset: 0x0000EA0F
			private void enterCB()
			{
				this.over = true;
				this.updateImage();
			}

			// Token: 0x06000E73 RID: 3699 RVA: 0x0001081E File Offset: 0x0000EA1E
			private void leaveCB()
			{
				this.over = false;
				this.updateImage();
			}

			// Token: 0x06000E74 RID: 3700 RVA: 0x0001082D File Offset: 0x0000EA2D
			public void setCheckChangedDelegate(CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate newDelegate)
			{
				this.checkChangedDelegate = newDelegate;
				this.initClickArea();
			}

			// Token: 0x06000E75 RID: 3701 RVA: 0x000FE240 File Offset: 0x000FC440
			public void initClickArea()
			{
				if (this.CBLabel != null && this.clickArea == null && base.csd != null)
				{
					Rectangle rectangle = default(Rectangle);
					rectangle.X = base.Image.Width;
					rectangle.Y = this.CBLabel.Y;
					Size textSize = this.CBLabel.TextSize;
					rectangle.Width = this.CBLabel.Position.X + textSize.Width;
					rectangle.Height = textSize.Height;
					this.clickArea = new CustomSelfDrawPanel.CSDArea();
					this.clickArea.Position = rectangle.Location;
					this.clickArea.Size = rectangle.Size;
					this.clickArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.toggled), "Generic_check_box_toggled");
					base.addControl(this.clickArea);
				}
			}

			// Token: 0x06000E76 RID: 3702 RVA: 0x0001083C File Offset: 0x0000EA3C
			public override void addedToParent()
			{
				this.initClickArea();
			}

			// Token: 0x0400121F RID: 4639
			private Image checkedImage;

			// Token: 0x04001220 RID: 4640
			private Image uncheckedImage;

			// Token: 0x04001221 RID: 4641
			private Image checkedOverImage;

			// Token: 0x04001222 RID: 4642
			private Image uncheckedOverImage;

			// Token: 0x04001223 RID: 4643
			private CustomSelfDrawPanel.CSDArea clickArea;

			// Token: 0x04001224 RID: 4644
			private CustomSelfDrawPanel.CSDLabel textLabel;

			// Token: 0x04001225 RID: 4645
			private bool over;

			// Token: 0x04001226 RID: 4646
			private bool boxChecked;

			// Token: 0x04001227 RID: 4647
			private CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate checkChangedDelegate;

			// Token: 0x02000179 RID: 377
			// (Invoke) Token: 0x06000E78 RID: 3704
			public delegate void CSD_CheckChangedDelegate();
		}

		// Token: 0x0200017A RID: 378
		public class CSDColorBar : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x170000DB RID: 219
			// (get) Token: 0x06000E7B RID: 3707 RVA: 0x00010844 File Offset: 0x0000EA44
			// (set) Token: 0x06000E7C RID: 3708 RVA: 0x0001084C File Offset: 0x0000EA4C
			public double Number
			{
				get
				{
					return this.number;
				}
				set
				{
					if (this.number != value)
					{
						base.invalidate();
					}
					this.number = value;
				}
			}

			// Token: 0x170000DC RID: 220
			// (get) Token: 0x06000E7D RID: 3709 RVA: 0x00010864 File Offset: 0x0000EA64
			// (set) Token: 0x06000E7E RID: 3710 RVA: 0x0001086C File Offset: 0x0000EA6C
			public double MaxValue
			{
				get
				{
					return this.maxNumber;
				}
				set
				{
					if (this.maxNumber != value)
					{
						base.invalidate();
					}
					this.maxNumber = value;
				}
			}

			// Token: 0x06000E7F RID: 3711 RVA: 0x000FE330 File Offset: 0x000FC530
			public void setImages(Image positiveBack, Image positiveLeft, Image positiveMid, Image positiveRight, Image negativeBack, Image negativeLeft, Image negativeMid, Image negativeRight)
			{
				base.invalidate();
				this.images[0] = positiveBack;
				this.images[1] = positiveLeft;
				this.images[2] = positiveMid;
				this.images[3] = positiveRight;
				this.images[4] = negativeBack;
				this.images[5] = negativeLeft;
				this.images[6] = negativeMid;
				this.images[7] = negativeRight;
				this.Size = this.images[0].Size;
			}

			// Token: 0x06000E80 RID: 3712 RVA: 0x00010884 File Offset: 0x0000EA84
			public void SetMargin(int lm, int tm, int rm, int bm)
			{
				this.leftMargin = lm;
				this.rightMargin = rm;
				this.topMargin = tm;
				this.bottomMargin = bm;
			}

			// Token: 0x06000E81 RID: 3713 RVA: 0x000108A3 File Offset: 0x0000EAA3
			public void setMarker(double marker)
			{
				this.markerValue = marker;
				this.markerShown = true;
				base.invalidate();
			}

			// Token: 0x06000E82 RID: 3714 RVA: 0x000108B9 File Offset: 0x0000EAB9
			public void clearMarker()
			{
				this.markerShown = false;
				base.invalidate();
			}

			// Token: 0x06000E83 RID: 3715 RVA: 0x000FE3A4 File Offset: 0x000FC5A4
			public override void draw(Point parentLocation)
			{
				Rectangle rectangle = base.Rectangle;
				rectangle.X += parentLocation.X;
				rectangle.Y += parentLocation.Y;
				int num = 0;
				if (this.number < 0.0)
				{
					num = 4;
				}
				Rectangle source = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
				base.csd.drawImage(this.images[num], source, rectangle);
				rectangle.X += this.leftMargin;
				rectangle.Y += this.topMargin;
				rectangle.Width -= this.leftMargin + this.rightMargin;
				rectangle.Height -= this.topMargin + this.bottomMargin;
				if (this.number != 0.0)
				{
					double num2 = Math.Abs(this.number);
					if (num2 > this.maxNumber)
					{
						num2 = this.maxNumber;
					}
					double num3 = (double)(rectangle.Width - this.images[num + 1].Size.Width - this.images[num + 3].Size.Width) - 1.0;
					double num4 = num3 / this.maxNumber * num2;
					int num5 = (int)num4 - 1;
					int num6 = rectangle.X;
					rectangle.X = num6 + 1;
					num6 = rectangle.Y;
					rectangle.Y = num6 + 1;
					base.csd.drawImage(this.images[num + 1], rectangle.Location);
					Point location = rectangle.Location;
					location.X += this.images[num + 1].Size.Width;
					if (num5 > 0)
					{
						for (int i = 0; i < num5; i++)
						{
							Point dest = location;
							dest.X += i;
							base.csd.drawImage(this.images[num + 2], dest);
						}
					}
					location.X += num5;
					base.csd.drawImage(this.images[num + 3], location);
					num6 = rectangle.X;
					rectangle.X = num6 - 1;
					num6 = rectangle.Y;
					rectangle.Y = num6 - 1;
				}
				if (this.markerShown)
				{
					double num7 = Math.Abs(this.markerValue);
					if (num7 > this.maxNumber)
					{
						num7 = this.maxNumber;
					}
					double num8 = (double)(this.Size.Width - this.images[num + 1].Size.Width - this.images[num + 3].Size.Width) - 1.0;
					double num9 = num8 / this.maxNumber * num7;
					base.csd.drawLine(global::ARGBColors.Black, new Point((int)((double)(rectangle.X + 1) + num9), rectangle.Y), new Point((int)((double)(rectangle.X + 1) + num9), rectangle.Y + rectangle.Height - 2));
				}
			}

			// Token: 0x04001228 RID: 4648
			private Image[] images = new Image[8];

			// Token: 0x04001229 RID: 4649
			private double number;

			// Token: 0x0400122A RID: 4650
			private double maxNumber = 1.0;

			// Token: 0x0400122B RID: 4651
			private int leftMargin;

			// Token: 0x0400122C RID: 4652
			private int rightMargin;

			// Token: 0x0400122D RID: 4653
			private int topMargin;

			// Token: 0x0400122E RID: 4654
			private int bottomMargin;

			// Token: 0x0400122F RID: 4655
			private double markerValue;

			// Token: 0x04001230 RID: 4656
			private bool markerShown;
		}

		// Token: 0x0200017B RID: 379
		public class CSDButton : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x170000DD RID: 221
			// (get) Token: 0x06000E85 RID: 3717 RVA: 0x000108EB File Offset: 0x0000EAEB
			// (set) Token: 0x06000E86 RID: 3718 RVA: 0x000108F3 File Offset: 0x0000EAF3
			public Image ImageNorm
			{
				get
				{
					return this.imageNorm;
				}
				set
				{
					if (this.imageNorm != value)
					{
						base.invalidate();
					}
					this.imageNorm = value;
					this.setSizeToImage();
				}
			}

			// Token: 0x170000DE RID: 222
			// (get) Token: 0x06000E87 RID: 3719 RVA: 0x000108EB File Offset: 0x0000EAEB
			// (set) Token: 0x06000E88 RID: 3720 RVA: 0x00010911 File Offset: 0x0000EB11
			public Image ImageNormAndOver
			{
				get
				{
					return this.imageNorm;
				}
				set
				{
					if (this.imageNorm != value)
					{
						base.invalidate();
					}
					this.imageNorm = value;
					this.imageOver = value;
					this.setSizeToImage();
				}
			}

			// Token: 0x170000DF RID: 223
			// (get) Token: 0x06000E89 RID: 3721 RVA: 0x00010936 File Offset: 0x0000EB36
			// (set) Token: 0x06000E8A RID: 3722 RVA: 0x0001093E File Offset: 0x0000EB3E
			public Image ImageOver
			{
				get
				{
					return this.imageOver;
				}
				set
				{
					if (this.imageOver != value)
					{
						base.invalidate();
					}
					this.imageOver = value;
				}
			}

			// Token: 0x170000E0 RID: 224
			// (get) Token: 0x06000E8B RID: 3723 RVA: 0x00010956 File Offset: 0x0000EB56
			// (set) Token: 0x06000E8C RID: 3724 RVA: 0x0001095E File Offset: 0x0000EB5E
			public Image ImageClick
			{
				get
				{
					return this.imageClick;
				}
				set
				{
					if (this.imageClick != value)
					{
						base.invalidate();
					}
					this.imageClick = value;
				}
			}

			// Token: 0x170000E1 RID: 225
			// (get) Token: 0x06000E8D RID: 3725 RVA: 0x00010976 File Offset: 0x0000EB76
			// (set) Token: 0x06000E8E RID: 3726 RVA: 0x0001097E File Offset: 0x0000EB7E
			public Image ImageHighlight
			{
				get
				{
					return this.imageHighlight;
				}
				set
				{
					if (this.imageHighlight != value)
					{
						base.invalidate();
					}
					this.imageHighlight = value;
				}
			}

			// Token: 0x170000E2 RID: 226
			// (get) Token: 0x06000E8F RID: 3727 RVA: 0x00010996 File Offset: 0x0000EB96
			// (set) Token: 0x06000E90 RID: 3728 RVA: 0x0001099E File Offset: 0x0000EB9E
			public Image ImageIcon
			{
				get
				{
					return this.imageIcon;
				}
				set
				{
					if (this.imageIcon != value)
					{
						base.invalidate();
					}
					this.imageIcon = value;
				}
			}

			// Token: 0x170000E3 RID: 227
			// (get) Token: 0x06000E91 RID: 3729 RVA: 0x000109B6 File Offset: 0x0000EBB6
			// (set) Token: 0x06000E92 RID: 3730 RVA: 0x000109BE File Offset: 0x0000EBBE
			public Point ImageIconPosition
			{
				get
				{
					return this.imageIconPosition;
				}
				set
				{
					this.imageIconPosition = value;
				}
			}

			// Token: 0x170000E4 RID: 228
			// (get) Token: 0x06000E93 RID: 3731 RVA: 0x000109C7 File Offset: 0x0000EBC7
			// (set) Token: 0x06000E94 RID: 3732 RVA: 0x000109CF File Offset: 0x0000EBCF
			public float ImageIconAlpha
			{
				get
				{
					return this.imageIconAlpha;
				}
				set
				{
					if (this.imageIconAlpha != value)
					{
						base.invalidate();
					}
					this.imageIconAlpha = value;
				}
			}

			// Token: 0x170000E5 RID: 229
			// (get) Token: 0x06000E95 RID: 3733 RVA: 0x000109E7 File Offset: 0x0000EBE7
			// (set) Token: 0x06000E96 RID: 3734 RVA: 0x000109EF File Offset: 0x0000EBEF
			public Rectangle ImageIconClipRect
			{
				get
				{
					return this.imageIconClipRect;
				}
				set
				{
					this.imageIconClipRect = value;
				}
			}

			// Token: 0x170000E6 RID: 230
			// (get) Token: 0x06000E97 RID: 3735 RVA: 0x000109F8 File Offset: 0x0000EBF8
			// (set) Token: 0x06000E98 RID: 3736 RVA: 0x00010A00 File Offset: 0x0000EC00
			public float Alpha
			{
				get
				{
					return this.alpha;
				}
				set
				{
					this.alpha = value;
				}
			}

			// Token: 0x170000E7 RID: 231
			// (get) Token: 0x06000E99 RID: 3737 RVA: 0x00010A09 File Offset: 0x0000EC09
			// (set) Token: 0x06000E9A RID: 3738 RVA: 0x00010A11 File Offset: 0x0000EC11
			public bool OverBrighten
			{
				get
				{
					return this.overBrighten;
				}
				set
				{
					this.overBrighten = value;
				}
			}

			// Token: 0x170000E8 RID: 232
			// (get) Token: 0x06000E9B RID: 3739 RVA: 0x00010A1A File Offset: 0x0000EC1A
			// (set) Token: 0x06000E9C RID: 3740 RVA: 0x00010A22 File Offset: 0x0000EC22
			public int TextYOffset
			{
				get
				{
					return this.textYOffset;
				}
				set
				{
					this.textYOffset = value;
				}
			}

			// Token: 0x170000E9 RID: 233
			// (get) Token: 0x06000E9D RID: 3741 RVA: 0x00010A2B File Offset: 0x0000EC2B
			// (set) Token: 0x06000E9E RID: 3742 RVA: 0x00010A33 File Offset: 0x0000EC33
			public bool LateTextRender
			{
				get
				{
					return this.lateTextRender;
				}
				set
				{
					this.lateTextRender = value;
				}
			}

			// Token: 0x170000EA RID: 234
			// (get) Token: 0x06000E9F RID: 3743 RVA: 0x00010A3C File Offset: 0x0000EC3C
			// (set) Token: 0x06000EA0 RID: 3744 RVA: 0x00010A44 File Offset: 0x0000EC44
			public bool Active
			{
				get
				{
					return this.active;
				}
				set
				{
					this.active = value;
				}
			}

			// Token: 0x170000EB RID: 235
			// (get) Token: 0x06000EA1 RID: 3745 RVA: 0x00010A4D File Offset: 0x0000EC4D
			// (set) Token: 0x06000EA2 RID: 3746 RVA: 0x00010A55 File Offset: 0x0000EC55
			public bool MoveOnClick
			{
				get
				{
					return this.moveOnClick;
				}
				set
				{
					this.moveOnClick = value;
				}
			}

			// Token: 0x170000EC RID: 236
			// (get) Token: 0x06000EA3 RID: 3747 RVA: 0x00010A5E File Offset: 0x0000EC5E
			// (set) Token: 0x06000EA4 RID: 3748 RVA: 0x00010A66 File Offset: 0x0000EC66
			public bool UseTextSize
			{
				get
				{
					return this.useTextSize;
				}
				set
				{
					this.useTextSize = value;
				}
			}

			// Token: 0x170000ED RID: 237
			// (get) Token: 0x06000EA5 RID: 3749 RVA: 0x00010A6F File Offset: 0x0000EC6F
			// (set) Token: 0x06000EA6 RID: 3750 RVA: 0x00010A77 File Offset: 0x0000EC77
			public Color FillRectOverColor
			{
				get
				{
					return this.fillRectOverColor;
				}
				set
				{
					this.fillRectOverColor = value;
					this.fillRectOverVariant = true;
				}
			}

			// Token: 0x170000EE RID: 238
			// (get) Token: 0x06000EA7 RID: 3751 RVA: 0x00010A87 File Offset: 0x0000EC87
			// (set) Token: 0x06000EA8 RID: 3752 RVA: 0x00010A8F File Offset: 0x0000EC8F
			public bool FillRectVariant
			{
				get
				{
					return this.fillRectVariant;
				}
				set
				{
					this.fillRectVariant = value;
				}
			}

			// Token: 0x170000EF RID: 239
			// (get) Token: 0x06000EA9 RID: 3753 RVA: 0x00010A98 File Offset: 0x0000EC98
			// (set) Token: 0x06000EAA RID: 3754 RVA: 0x00010AA0 File Offset: 0x0000ECA0
			public Color FillRectColor
			{
				get
				{
					return this.fillRectColor;
				}
				set
				{
					this.fillRectColor = value;
					this.fillRectVariant = true;
				}
			}

			// Token: 0x170000F0 RID: 240
			// (get) Token: 0x06000EAB RID: 3755 RVA: 0x00010AB0 File Offset: 0x0000ECB0
			// (set) Token: 0x06000EAC RID: 3756 RVA: 0x00010AB8 File Offset: 0x0000ECB8
			public bool ForceFillRect
			{
				get
				{
					return this.forceFillRect;
				}
				set
				{
					this.forceFillRect = value;
				}
			}

			// Token: 0x06000EAD RID: 3757 RVA: 0x000FE6EC File Offset: 0x000FC8EC
			public CSDButton()
			{
				base.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.buttonOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.buttonLeave));
				base.setMouseDownDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseDownDelegate(this.buttonDown), new CustomSelfDrawPanel.CSDControl.CSD_MouseDownDelegate(this.buttonUp));
				this.Text = new CustomSelfDrawPanel.CSDLabel();
				this.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.Text.setParent(this);
			}

			// Token: 0x06000EAE RID: 3758 RVA: 0x00010AC1 File Offset: 0x0000ECC1
			public void setSizeToImage()
			{
				if (this.imageNorm != null)
				{
					this.Size = this.imageNorm.Size;
					if (!this.useTextSize)
					{
						this.Text.Size = this.Size;
					}
				}
			}

			// Token: 0x06000EAF RID: 3759 RVA: 0x000FE7BC File Offset: 0x000FC9BC
			public void createSubText(string text)
			{
				this.Text2 = new CustomSelfDrawPanel.CSDLabel();
				this.Text2.Size = this.Size;
				this.Text2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.Text2.Text = text;
				this.Text2.setParent(this);
			}

			// Token: 0x06000EB0 RID: 3760 RVA: 0x000FE80C File Offset: 0x000FCA0C
			public void setNormalExtImage(Image left, Image mid, Image right)
			{
				this.stretchButtons = true;
				this.normalExt = new CustomSelfDrawPanel.CSDHorzExtendingPanel();
				this.normalExt.Size = this.Size;
				this.normalExt.Position = new Point(0, 0);
				this.normalExt.Create(left, mid, right);
				this.normalExt.setParent(this);
				if (!this.useTextSize)
				{
					this.Text.Size = this.Size;
				}
			}

			// Token: 0x06000EB1 RID: 3761 RVA: 0x000FE884 File Offset: 0x000FCA84
			public void setOverExtImage(Image left, Image mid, Image right)
			{
				this.stretchButtons = true;
				this.overExt = new CustomSelfDrawPanel.CSDHorzExtendingPanel();
				this.overExt.Size = this.Size;
				this.overExt.Position = new Point(0, 0);
				this.overExt.Create(left, mid, right);
				this.overExt.setParent(this);
				if (!this.useTextSize)
				{
					this.Text.Size = this.Size;
				}
			}

			// Token: 0x06000EB2 RID: 3762 RVA: 0x000FE8FC File Offset: 0x000FCAFC
			public void setClickExtImage(Image left, Image mid, Image right)
			{
				this.stretchButtons = true;
				this.clickExt = new CustomSelfDrawPanel.CSDHorzExtendingPanel();
				this.clickExt.Size = this.Size;
				this.clickExt.Position = new Point(0, 0);
				this.clickExt.Create(left, mid, right);
				if (!this.useTextSize)
				{
					this.Text.Size = this.Size;
				}
			}

			// Token: 0x06000EB3 RID: 3763 RVA: 0x00010AF5 File Offset: 0x0000ECF5
			public void setButtonMouseOverDelegate(CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate overDelegate, CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate leaveDelegate)
			{
				this.buttonMouseOverDelegate = overDelegate;
				this.buttonMouseLeaveDelegate = leaveDelegate;
			}

			// Token: 0x06000EB4 RID: 3764 RVA: 0x000FE968 File Offset: 0x000FCB68
			public override void draw(Point parentLocation)
			{
				Rectangle rectangle = base.Rectangle;
				rectangle.X += parentLocation.X;
				rectangle.Y += parentLocation.Y;
				Point point = new Point(0, this.textYOffset);
				Image image = this.imageNorm;
				Rectangle source = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
				if (image != null)
				{
					source = new Rectangle(0, 0, image.Width, image.Height);
				}
				if (this.active)
				{
					if (this.stretchButtons)
					{
						CustomSelfDrawPanel.CSDHorzExtendingPanel csdhorzExtendingPanel = this.normalExt;
						if (this.mouseDownFlag)
						{
							if (this.clickExt != null)
							{
								csdhorzExtendingPanel = this.clickExt;
								if (this.moveOnClick)
								{
									int num = point.X;
									point.X = num + 1;
									num = point.Y;
									point.Y = num + 1;
								}
							}
							else
							{
								if (this.overExt != null)
								{
									csdhorzExtendingPanel = this.overExt;
								}
								if (this.moveOnClick)
								{
									int num = rectangle.X;
									rectangle.X = num + 1;
									num = rectangle.Y;
									rectangle.Y = num + 1;
								}
							}
						}
						else if (this.mouseOverFlag && this.overExt != null)
						{
							csdhorzExtendingPanel = this.overExt;
						}
						if (csdhorzExtendingPanel != null)
						{
							float num2 = this.alpha;
							if (!this.Enabled)
							{
								num2 /= 2f;
							}
							Point parentLocation2 = new Point(rectangle.X, rectangle.Y);
							csdhorzExtendingPanel.forceDraw(parentLocation2, num2);
						}
					}
					else if (this.imageHighlight == null)
					{
						if (this.mouseDownFlag)
						{
							if (this.imageClick != null)
							{
								image = this.imageClick;
								if (this.moveOnClick)
								{
									int num = point.X;
									point.X = num + 1;
									num = point.Y;
									point.Y = num + 1;
								}
							}
							else
							{
								image = this.imageOver;
								if (this.moveOnClick)
								{
									int num = rectangle.X;
									rectangle.X = num + 1;
									num = rectangle.Y;
									rectangle.Y = num + 1;
								}
							}
						}
						else if (this.mouseOverFlag)
						{
							image = this.imageOver;
						}
					}
					else if (this.mouseDownFlag && this.moveOnClick)
					{
						int num = rectangle.X;
						rectangle.X = num + 1;
						num = rectangle.Y;
						rectangle.Y = num + 1;
					}
				}
				float num3 = this.alpha;
				if (!this.Enabled)
				{
					num3 /= 2f;
				}
				if (image != null)
				{
					if (num3 == 1f)
					{
						base.csd.drawImage(image, source, rectangle);
					}
					else
					{
						base.csd.drawImage(image, source, rectangle, num3);
					}
				}
				else if (this.mouseOverFlag && this.imageOver == null && this.overBrighten)
				{
					if (num3 == 1f)
					{
						base.csd.drawImageBrighten(this.imageNorm, source, rectangle, 1f);
					}
					else
					{
						base.csd.drawImageBrighten(this.imageNorm, source, rectangle, num3);
					}
				}
				if (this.active && this.mouseOverFlag && this.imageHighlight != null)
				{
					base.csd.drawImage(this.imageHighlight, source, rectangle);
				}
				if (this.fillRectVariant && !this.mouseOverFlag && !this.mouseDownFlag)
				{
					base.csd.fillRect(rectangle, this.fillRectColor);
				}
				if (this.fillRectOverVariant && (this.mouseOverFlag || this.mouseDownFlag || this.forceFillRect))
				{
					base.csd.fillRect(rectangle, this.fillRectOverColor);
				}
				if (!this.lateTextRender)
				{
					if (this.Text.Text.Length > 0)
					{
						if (image == null && !this.useTextSize)
						{
							this.Text.Size = this.Size;
						}
						Point parentLocation3 = new Point(rectangle.X, rectangle.Y);
						parentLocation3.X += point.X;
						parentLocation3.Y += point.Y;
						this.Text.draw(parentLocation3);
					}
					if (this.Text2 != null && this.Text2.Text.Length > 0)
					{
						Point parentLocation4 = new Point(rectangle.X, rectangle.Y);
						parentLocation4.X += point.X;
						parentLocation4.Y += point.Y;
						this.Text2.draw(parentLocation4);
					}
				}
				if (this.imageIcon != null)
				{
					Rectangle dest = new Rectangle(rectangle.X + this.imageIconPosition.X, rectangle.Y + this.imageIconPosition.Y, this.imageIcon.Width, this.imageIcon.Height);
					Rectangle source2 = new Rectangle(0, 0, this.imageIcon.Width, this.imageIcon.Height);
					if (!this.imageIconClipRect.IsEmpty)
					{
						Rectangle clipRegion = new Rectangle(rectangle.X + this.imageIconPosition.X + this.imageIconClipRect.X, rectangle.Y + this.imageIconPosition.Y + this.imageIconClipRect.Y, this.imageIconClipRect.Width, this.imageIconClipRect.Height);
						base.csd.setClipRegion(clipRegion);
					}
					if (this.imageIconAlpha == 1f)
					{
						base.csd.drawImage(this.imageIcon, source2, dest);
					}
					else
					{
						base.csd.drawImage(this.imageIcon, source2, dest, this.imageIconAlpha);
					}
					if (!this.imageIconClipRect.IsEmpty)
					{
						base.csd.restoreClipRegion();
					}
				}
				if (!this.lateTextRender)
				{
					return;
				}
				if (this.Text.Text.Length > 0)
				{
					if (image == null && !this.useTextSize)
					{
						this.Text.Size = this.Size;
					}
					Point parentLocation5 = new Point(rectangle.X, rectangle.Y);
					parentLocation5.X += point.X;
					parentLocation5.Y += point.Y;
					this.Text.draw(parentLocation5);
				}
				if (this.Text2 != null && this.Text2.Text.Length > 0)
				{
					Point parentLocation6 = new Point(rectangle.X, rectangle.Y);
					parentLocation6.X += point.X;
					parentLocation6.Y += point.Y;
					this.Text2.draw(parentLocation6);
				}
			}

			// Token: 0x06000EB5 RID: 3765 RVA: 0x00010B05 File Offset: 0x0000ED05
			private void buttonOver()
			{
				base.invalidate();
				if (this.buttonMouseOverDelegate != null)
				{
					this.buttonMouseOverDelegate();
				}
			}

			// Token: 0x06000EB6 RID: 3766 RVA: 0x00010B20 File Offset: 0x0000ED20
			private void buttonLeave()
			{
				base.invalidate();
				if (this.buttonMouseLeaveDelegate != null)
				{
					this.buttonMouseLeaveDelegate();
				}
			}

			// Token: 0x06000EB7 RID: 3767 RVA: 0x00010B3B File Offset: 0x0000ED3B
			private void buttonDown()
			{
				base.invalidate();
			}

			// Token: 0x06000EB8 RID: 3768 RVA: 0x00010B3B File Offset: 0x0000ED3B
			private void buttonUp()
			{
				base.invalidate();
			}

			// Token: 0x04001231 RID: 4657
			private Image imageNorm;

			// Token: 0x04001232 RID: 4658
			private Image imageOver;

			// Token: 0x04001233 RID: 4659
			private Image imageClick;

			// Token: 0x04001234 RID: 4660
			private Image imageHighlight;

			// Token: 0x04001235 RID: 4661
			private Image imageIcon;

			// Token: 0x04001236 RID: 4662
			private Point imageIconPosition = new Point(0, 0);

			// Token: 0x04001237 RID: 4663
			private float imageIconAlpha = 1f;

			// Token: 0x04001238 RID: 4664
			private Rectangle imageIconClipRect = new Rectangle(0, 0, 0, 0);

			// Token: 0x04001239 RID: 4665
			private float alpha = 1f;

			// Token: 0x0400123A RID: 4666
			private bool overBrighten;

			// Token: 0x0400123B RID: 4667
			private int textYOffset = -3;

			// Token: 0x0400123C RID: 4668
			private bool lateTextRender;

			// Token: 0x0400123D RID: 4669
			private bool active = true;

			// Token: 0x0400123E RID: 4670
			private bool moveOnClick = true;

			// Token: 0x0400123F RID: 4671
			private bool useTextSize;

			// Token: 0x04001240 RID: 4672
			private Color fillRectOverColor = global::ARGBColors.White;

			// Token: 0x04001241 RID: 4673
			private bool fillRectOverVariant;

			// Token: 0x04001242 RID: 4674
			private Color fillRectColor = global::ARGBColors.White;

			// Token: 0x04001243 RID: 4675
			private bool fillRectVariant;

			// Token: 0x04001244 RID: 4676
			private bool forceFillRect;

			// Token: 0x04001245 RID: 4677
			private bool stretchButtons;

			// Token: 0x04001246 RID: 4678
			private CustomSelfDrawPanel.CSDHorzExtendingPanel normalExt;

			// Token: 0x04001247 RID: 4679
			private CustomSelfDrawPanel.CSDHorzExtendingPanel overExt;

			// Token: 0x04001248 RID: 4680
			private CustomSelfDrawPanel.CSDHorzExtendingPanel clickExt;

			// Token: 0x04001249 RID: 4681
			public CustomSelfDrawPanel.CSDLabel Text;

			// Token: 0x0400124A RID: 4682
			public CustomSelfDrawPanel.CSDLabel Text2;

			// Token: 0x0400124B RID: 4683
			protected CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate buttonMouseOverDelegate;

			// Token: 0x0400124C RID: 4684
			protected CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate buttonMouseLeaveDelegate;
		}

		// Token: 0x0200017C RID: 380
		public class CSDExtendingPanel : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x170000F1 RID: 241
			// (get) Token: 0x06000EB9 RID: 3769 RVA: 0x00010B43 File Offset: 0x0000ED43
			// (set) Token: 0x06000EBA RID: 3770 RVA: 0x000FF008 File Offset: 0x000FD208
			public float Alpha
			{
				get
				{
					return this.alpha;
				}
				set
				{
					if (value > 1f)
					{
						this.alpha = value / 256f;
					}
					else
					{
						this.alpha = value;
					}
					this.TopLeft.Alpha = this.alpha;
					this.TopRight.Alpha = this.alpha;
					this.TopMid.Alpha = this.alpha;
					this.Left.Alpha = this.alpha;
					this.Right.Alpha = this.alpha;
					this.Mid.Alpha = this.alpha;
					this.BottomLeft.Alpha = this.alpha;
					this.BottomMid.Alpha = this.alpha;
					this.BottomRight.Alpha = this.alpha;
				}
			}

			// Token: 0x06000EBB RID: 3771 RVA: 0x00010B4B File Offset: 0x0000ED4B
			public void ForceTiling()
			{
				this.TopMid.Tile = true;
				this.Left.Tile = true;
				this.BottomMid.Tile = true;
				this.Right.Tile = true;
				this.Mid.Tile = true;
			}

			// Token: 0x06000EBC RID: 3772 RVA: 0x000FF0CC File Offset: 0x000FD2CC
			public void Create(Image topLeftImage, Image topMidImage, Image topRightImage, Image leftImage, Image midImage, Image rightImage, Image bottomLeftImage, Image bottomMidImage, Image bottomRightImage)
			{
				this.TopLeft.Image = topLeftImage;
				this.TopLeft.Position = new Point(0, 0);
				this.TopLeft.Alpha = this.alpha;
				base.addControl(this.TopLeft);
				this.TopRight.Image = topRightImage;
				this.TopRight.Position = new Point(base.Width - this.TopRight.Image.Width, 0);
				this.TopRight.Alpha = this.alpha;
				base.addControl(this.TopRight);
				this.TopMid.Image = topMidImage;
				this.TopMid.Position = new Point(this.TopLeft.Image.Width, 0);
				this.TopMid.Size = new Size(base.Width - this.TopLeft.Image.Width - this.TopRight.Image.Width, this.TopMid.Image.Height);
				this.TopMid.Alpha = this.alpha;
				base.addControl(this.TopMid);
				this.Left.Image = leftImage;
				this.Left.Position = new Point(0, this.TopLeft.Image.Height);
				this.Left.Size = new Size(this.Left.Image.Width, base.Height - this.TopLeft.Image.Height - bottomLeftImage.Width);
				this.Left.Alpha = this.alpha;
				base.addControl(this.Left);
				this.Right.Image = rightImage;
				this.Right.Position = new Point(base.Width - this.Right.Image.Width, this.TopRight.Image.Height);
				this.Right.Size = new Size(this.Right.Image.Width, base.Height - this.TopRight.Image.Height - bottomRightImage.Width);
				this.Right.Alpha = this.alpha;
				base.addControl(this.Right);
				this.BottomLeft.Image = bottomLeftImage;
				this.BottomLeft.Position = new Point(0, base.Height - this.BottomLeft.Height);
				this.BottomLeft.Alpha = this.alpha;
				base.addControl(this.BottomLeft);
				this.BottomRight.Image = bottomRightImage;
				this.BottomRight.Position = new Point(base.Width - this.BottomRight.Image.Width, base.Height - this.BottomRight.Height);
				this.BottomRight.Alpha = this.alpha;
				base.addControl(this.BottomRight);
				this.BottomMid.Image = bottomMidImage;
				this.BottomMid.Position = new Point(this.BottomLeft.Image.Width, base.Height - this.BottomMid.Image.Height);
				this.BottomMid.Size = new Size(base.Width - this.BottomLeft.Image.Width - this.BottomRight.Image.Width, this.BottomMid.Image.Height);
				this.BottomMid.Alpha = this.alpha;
				base.addControl(this.BottomMid);
				if (midImage != null)
				{
					this.Mid.Image = midImage;
					this.Mid.Position = new Point(this.Left.Image.Width, this.TopMid.Image.Height);
					this.Mid.Size = new Size(base.Width - this.Left.Image.Width - this.Right.Image.Width, base.Height - this.TopMid.Image.Height - this.BottomMid.Image.Height);
					this.Mid.Alpha = this.alpha;
					base.addControl(this.Mid);
				}
			}

			// Token: 0x0400124D RID: 4685
			public CustomSelfDrawPanel.CSDImage TopLeft = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x0400124E RID: 4686
			public CustomSelfDrawPanel.CSDImage TopMid = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x0400124F RID: 4687
			public CustomSelfDrawPanel.CSDImage TopRight = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001250 RID: 4688
			public CustomSelfDrawPanel.CSDImage Left = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001251 RID: 4689
			public CustomSelfDrawPanel.CSDImage Mid = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001252 RID: 4690
			public CustomSelfDrawPanel.CSDImage Right = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001253 RID: 4691
			public CustomSelfDrawPanel.CSDImage BottomLeft = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001254 RID: 4692
			public CustomSelfDrawPanel.CSDImage BottomMid = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001255 RID: 4693
			public CustomSelfDrawPanel.CSDImage BottomRight = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001256 RID: 4694
			private float alpha = 1f;
		}

		// Token: 0x0200017D RID: 381
		public class CSDHorzExtendingPanel : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06000EBE RID: 3774 RVA: 0x000FF5C0 File Offset: 0x000FD7C0
			public void Create(Image leftImage, Image midImage, Image rightImage)
			{
				base.removeControl(this.Left);
				base.removeControl(this.Right);
				base.removeControl(this.Mid);
				this.Left.Image = leftImage;
				this.Left.Position = new Point(0, 0);
				base.addControl(this.Left);
				this.Right.Image = rightImage;
				this.Right.Position = new Point(base.Width - this.Right.Image.Width, 0);
				base.addControl(this.Right);
				this.Mid.Image = midImage;
				this.Mid.Position = new Point(this.Left.Image.Width, 0);
				this.Mid.Size = new Size(base.Width - this.Left.Image.Width - this.Right.Image.Width, this.Mid.Image.Height);
				this.Mid.Tile = true;
				base.addControl(this.Mid);
				this.Size = new Size(this.Size.Width, this.Left.Image.Height);
			}

			// Token: 0x06000EBF RID: 3775 RVA: 0x000FF714 File Offset: 0x000FD914
			public void CreateX(Image leftImage, Image midImage, Image rightImage, int midShorten, int rightExtra)
			{
				base.removeControl(this.Left);
				base.removeControl(this.Right);
				base.removeControl(this.Mid);
				this.Left.Image = leftImage;
				this.Left.Position = new Point(0, 0);
				base.addControl(this.Left);
				this.Right.Image = rightImage;
				this.Right.Position = new Point(base.Width - this.Right.Image.Width + rightExtra, 0);
				this.Mid.Image = midImage;
				this.Mid.Position = new Point(this.Left.Image.Width, 0);
				this.Mid.Size = new Size(base.Width - this.Left.Image.Width - this.Right.Image.Width - midShorten, this.Mid.Image.Height);
				this.Mid.Tile = true;
				this.Mid.ClipRect = new Rectangle(0, 0, this.Mid.Size.Width, this.Mid.Size.Height);
				base.addControl(this.Mid);
				base.addControl(this.Right);
				this.Size = new Size(this.Size.Width, this.Left.Image.Height);
			}

			// Token: 0x06000EC0 RID: 3776 RVA: 0x000FF8A4 File Offset: 0x000FDAA4
			public void resize()
			{
				this.Right.Position = new Point(base.Width - this.Right.Image.Width, 0);
				this.Mid.Position = new Point(this.Left.Image.Width, 0);
				this.Mid.Size = new Size(base.Width - this.Left.Image.Width - this.Right.Image.Width, this.Mid.Image.Height);
			}

			// Token: 0x06000EC1 RID: 3777 RVA: 0x000FF944 File Offset: 0x000FDB44
			public void forceDraw(Point parentLocation, float alpha)
			{
				Rectangle rectangle = base.Rectangle;
				rectangle.X += parentLocation.X;
				rectangle.Y += parentLocation.Y;
				Point parentLocation2 = new Point(rectangle.X, rectangle.Y);
				this.Left.Alpha = alpha;
				this.Left.draw(parentLocation2);
				this.Mid.Alpha = alpha;
				this.Mid.draw(parentLocation2);
				this.Right.Alpha = alpha;
				this.Right.draw(parentLocation2);
			}

			// Token: 0x04001257 RID: 4695
			public CustomSelfDrawPanel.CSDImage Left = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001258 RID: 4696
			public CustomSelfDrawPanel.CSDImage Mid = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001259 RID: 4697
			public CustomSelfDrawPanel.CSDImage Right = new CustomSelfDrawPanel.CSDImage();
		}

		// Token: 0x0200017E RID: 382
		public class CSDVertExtendingPanel : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x170000F2 RID: 242
			// (get) Token: 0x06000EC3 RID: 3779 RVA: 0x00010725 File Offset: 0x0000E925
			// (set) Token: 0x06000EC4 RID: 3780 RVA: 0x00010BB2 File Offset: 0x0000EDB2
			public override Size Size
			{
				get
				{
					return base.Size;
				}
				set
				{
					base.Size = value;
					this.resize();
				}
			}

			// Token: 0x170000F3 RID: 243
			// (get) Token: 0x06000EC5 RID: 3781 RVA: 0x00010BC1 File Offset: 0x0000EDC1
			public int YDiff
			{
				get
				{
					return this.yDiff;
				}
			}

			// Token: 0x06000EC6 RID: 3782 RVA: 0x000FF9E0 File Offset: 0x000FDBE0
			public CSDVertExtendingPanel()
			{
				base.setMouseDownDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseDownDelegate(this.buttonDown), new CustomSelfDrawPanel.CSDControl.CSD_MouseDownDelegate(this.buttonUp));
			}

			// Token: 0x06000EC7 RID: 3783 RVA: 0x00010BC9 File Offset: 0x0000EDC9
			public void setAreaMouseDownDelegate(CustomSelfDrawPanel.CSDControl.CSD_MouseDownDelegate downDelegate, CustomSelfDrawPanel.CSDControl.CSD_MouseDownDelegate upDelegate)
			{
				this.areaMouseDownDelegate = downDelegate;
				this.areaMouseUpDelegate = upDelegate;
			}

			// Token: 0x06000EC8 RID: 3784 RVA: 0x000FFA40 File Offset: 0x000FDC40
			public void Create(Image topImage, Image midImage, Image bottomImage)
			{
				if (topImage != null && midImage != null && bottomImage != null)
				{
					this.Top.Image = topImage;
					this.Top.Position = new Point(0, 0);
					base.addControl(this.Top);
					this.Bottom.Image = bottomImage;
					this.Bottom.Position = new Point(0, base.Height - this.Bottom.Image.Height);
					base.addControl(this.Bottom);
					this.Mid.Image = midImage;
					this.Mid.Position = new Point(0, this.Top.Image.Height);
					this.Mid.Size = new Size(this.Mid.Image.Width, base.Height - this.Top.Image.Height - this.Bottom.Image.Height);
					this.Mid.Tile = true;
					base.addControl(this.Mid);
					this.Size = new Size(this.Top.Image.Width, this.Size.Height);
					this.created = true;
				}
			}

			// Token: 0x06000EC9 RID: 3785 RVA: 0x000FFB88 File Offset: 0x000FDD88
			public void resize()
			{
				if (this.created && !this.inResize)
				{
					this.inResize = true;
					this.Bottom.Position = new Point(0, base.Height - this.Bottom.Image.Height);
					this.Mid.Size = new Size(this.Mid.Image.Width, base.Height - this.Top.Image.Height - this.Bottom.Image.Height);
					this.Size = new Size(this.Top.Image.Width, this.Size.Height);
					this.inResize = false;
				}
			}

			// Token: 0x06000ECA RID: 3786 RVA: 0x00010BD9 File Offset: 0x0000EDD9
			public int getMinSize()
			{
				return this.Top.Image.Height + this.Bottom.Image.Height + 1;
			}

			// Token: 0x06000ECB RID: 3787 RVA: 0x000FFC54 File Offset: 0x000FDE54
			private void buttonDown()
			{
				if (!this.held)
				{
					this.heldPosition = base.csd.LastMousePosition;
					this.held = true;
					this.yDiff = 0;
				}
				else
				{
					this.yDiff = base.csd.LastMousePosition.Y - this.heldPosition.Y;
				}
				if (this.areaMouseDownDelegate != null)
				{
					this.areaMouseDownDelegate();
				}
			}

			// Token: 0x06000ECC RID: 3788 RVA: 0x00010BFE File Offset: 0x0000EDFE
			private void buttonUp()
			{
				this.held = false;
				this.yDiff = 0;
				if (this.areaMouseUpDelegate != null)
				{
					this.areaMouseUpDelegate();
				}
			}

			// Token: 0x06000ECD RID: 3789 RVA: 0x000FFCC4 File Offset: 0x000FDEC4
			public override void draw(Point parentLocation)
			{
				if (!this.held)
				{
					return;
				}
				if (!base.csd.MouseReallyPressed)
				{
					this.mouseDownFlag = false;
					this.buttonUp();
					return;
				}
				this.yDiff = base.csd.LastMousePosition.Y - this.heldPosition.Y;
				if (this.areaMouseDownDelegate != null)
				{
					this.areaMouseDownDelegate();
				}
			}

			// Token: 0x0400125A RID: 4698
			protected CustomSelfDrawPanel.CSDControl.CSD_MouseDownDelegate areaMouseDownDelegate;

			// Token: 0x0400125B RID: 4699
			protected CustomSelfDrawPanel.CSDControl.CSD_MouseDownDelegate areaMouseUpDelegate;

			// Token: 0x0400125C RID: 4700
			public CustomSelfDrawPanel.CSDImage Top = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x0400125D RID: 4701
			public CustomSelfDrawPanel.CSDImage Mid = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x0400125E RID: 4702
			public CustomSelfDrawPanel.CSDImage Bottom = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x0400125F RID: 4703
			private bool created;

			// Token: 0x04001260 RID: 4704
			private bool inResize;

			// Token: 0x04001261 RID: 4705
			private bool held;

			// Token: 0x04001262 RID: 4706
			private Point heldPosition = new Point(0, 0);

			// Token: 0x04001263 RID: 4707
			private int yDiff;
		}

		// Token: 0x0200017F RID: 383
		public class CSDVertScrollBar : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x170000F4 RID: 244
			// (get) Token: 0x06000ECE RID: 3790 RVA: 0x00010C21 File Offset: 0x0000EE21
			// (set) Token: 0x06000ECF RID: 3791 RVA: 0x00010C29 File Offset: 0x0000EE29
			public Point OffsetTL
			{
				get
				{
					return this.offsetTL;
				}
				set
				{
					this.offsetTL = value;
				}
			}

			// Token: 0x170000F5 RID: 245
			// (get) Token: 0x06000ED0 RID: 3792 RVA: 0x00010C32 File Offset: 0x0000EE32
			// (set) Token: 0x06000ED1 RID: 3793 RVA: 0x00010C3A File Offset: 0x0000EE3A
			public Point OffsetBR
			{
				get
				{
					return this.offsetBR;
				}
				set
				{
					this.offsetBR = value;
				}
			}

			// Token: 0x170000F6 RID: 246
			// (get) Token: 0x06000ED2 RID: 3794 RVA: 0x00010C43 File Offset: 0x0000EE43
			// (set) Token: 0x06000ED3 RID: 3795 RVA: 0x00010C4B File Offset: 0x0000EE4B
			public int Value
			{
				get
				{
					return this.currentValue;
				}
				set
				{
					this.currentValue = value;
					this.recalc();
				}
			}

			// Token: 0x170000F7 RID: 247
			// (get) Token: 0x06000ED4 RID: 3796 RVA: 0x00010C5A File Offset: 0x0000EE5A
			// (set) Token: 0x06000ED5 RID: 3797 RVA: 0x00010C62 File Offset: 0x0000EE62
			public int Max
			{
				get
				{
					return this.maxValue;
				}
				set
				{
					this.maxValue = value;
					this.recalc();
				}
			}

			// Token: 0x170000F8 RID: 248
			// (get) Token: 0x06000ED6 RID: 3798 RVA: 0x00010C71 File Offset: 0x0000EE71
			// (set) Token: 0x06000ED7 RID: 3799 RVA: 0x00010C79 File Offset: 0x0000EE79
			public int NumVisibleLines
			{
				get
				{
					return this.visibleLines;
				}
				set
				{
					this.visibleLines = value;
					this.recalc();
				}
			}

			// Token: 0x170000F9 RID: 249
			// (get) Token: 0x06000ED8 RID: 3800 RVA: 0x00010C88 File Offset: 0x0000EE88
			// (set) Token: 0x06000ED9 RID: 3801 RVA: 0x00010C90 File Offset: 0x0000EE90
			public int TabMinSize
			{
				get
				{
					return this.tabMinSize;
				}
				set
				{
					this.tabMinSize = value;
					this.recalc();
				}
			}

			// Token: 0x170000FA RID: 250
			// (get) Token: 0x06000EDA RID: 3802 RVA: 0x00010C9F File Offset: 0x0000EE9F
			// (set) Token: 0x06000EDB RID: 3803 RVA: 0x00010CA7 File Offset: 0x0000EEA7
			public int StepSize
			{
				get
				{
					return this.stepSize;
				}
				set
				{
					this.stepSize = value;
				}
			}

			// Token: 0x170000FB RID: 251
			// (get) Token: 0x06000EDC RID: 3804 RVA: 0x000FFD30 File Offset: 0x000FDF30
			public int TabSize
			{
				get
				{
					return this.tab.Size.Height;
				}
			}

			// Token: 0x170000FC RID: 252
			// (get) Token: 0x06000EDD RID: 3805 RVA: 0x00010CB0 File Offset: 0x0000EEB0
			public Point TabPosition
			{
				get
				{
					return this.tab.Position;
				}
			}

			// Token: 0x06000EDE RID: 3806 RVA: 0x000FFD50 File Offset: 0x000FDF50
			public void Create(Image topImage, Image midImage, Image bottomImage, Image tabTopImage, Image tabMidImage, Image tabBottomImage)
			{
				this.background.Size = this.Size;
				base.addControl(this.background);
				this.background.Create(topImage, midImage, bottomImage);
				this.tab.Size = new Size(this.background.Size.Width - this.offsetTL.X - this.offsetBR.X, this.background.Size.Height - this.offsetTL.Y - this.offsetBR.Y);
				this.tab.Position = new Point(0, this.offsetTL.Y);
				this.background.addControl(this.tab);
				this.tab.Create(tabTopImage, tabMidImage, tabBottomImage);
				this.created = true;
				this.recalc();
				this.tab.setAreaMouseDownDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseDownDelegate(this.buttonDown), new CustomSelfDrawPanel.CSDControl.CSD_MouseDownDelegate(this.buttonUp));
				this.background.setAreaMouseDownDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseDownDelegate(this.backgroundButtonDown), new CustomSelfDrawPanel.CSDControl.CSD_MouseDownDelegate(this.backgroundButtonUp));
			}

			// Token: 0x06000EDF RID: 3807 RVA: 0x00010CBD File Offset: 0x0000EEBD
			public void setValueChangeDelegate(CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate newDelegate)
			{
				this.valueChangedDelegate = newDelegate;
			}

			// Token: 0x06000EE0 RID: 3808 RVA: 0x00010CC6 File Offset: 0x0000EEC6
			public void setScrollChangeDelegate(CustomSelfDrawPanel.CSDControl.CSD_ScrollBarChangedDelegate newDelegate)
			{
				this.scrollChangedDelegate = newDelegate;
			}

			// Token: 0x06000EE1 RID: 3809 RVA: 0x000FFE80 File Offset: 0x000FE080
			public void recalc()
			{
				if (!this.created)
				{
					return;
				}
				int num = this.background.Size.Height - this.offsetTL.Y - this.offsetBR.Y;
				if (this.maxValue > 0)
				{
					int num2 = this.tab.getMinSize() + this.tabMinSize;
					int num3 = num * this.NumVisibleLines / Math.Max(this.maxValue + this.NumVisibleLines, 1);
					if (num3 < num2)
					{
						num3 = num2;
					}
					int num4 = num - num3;
					int num5 = num4 * this.Value / Math.Max(this.maxValue, 1);
					this.tab.Size = new Size(this.tab.Size.Width, num3);
					this.tab.Position = new Point(0, this.offsetTL.Y + num5);
					this.maxTabPosition = this.minTabPosition + num4;
				}
				else
				{
					this.tab.Size = new Size(this.tab.Size.Width, num);
					this.tab.Position = new Point(0, this.offsetTL.Y);
					this.maxTabPosition = this.minTabPosition;
				}
				this.minTabPosition = this.offsetTL.Y;
			}

			// Token: 0x06000EE2 RID: 3810 RVA: 0x000FFFD4 File Offset: 0x000FE1D4
			private void buttonDown()
			{
				if (!this.held)
				{
					this.held = true;
					this.baseYPos = this.tab.Position.Y;
					this.tab.invalidate();
					return;
				}
				this.moveTabPosition(this.baseYPos, this.tab.YDiff);
			}

			// Token: 0x06000EE3 RID: 3811 RVA: 0x00010CCF File Offset: 0x0000EECF
			private void buttonUp()
			{
				this.held = false;
			}

			// Token: 0x06000EE4 RID: 3812 RVA: 0x00010CD8 File Offset: 0x0000EED8
			private void backgroundButtonDown()
			{
				this.clickedOnBar = true;
			}

			// Token: 0x06000EE5 RID: 3813 RVA: 0x0010002C File Offset: 0x000FE22C
			private void backgroundButtonUp()
			{
				if (this.clickedOnBar)
				{
					if (this.StepSize != 0)
					{
						if (this.background.LastRelativeMousePos.Y < this.tab.Y + this.tab.Height / 2)
						{
							int value = this.Value;
							int num = this.Value - this.stepSize;
							if (num < 0)
							{
								num = 0;
							}
							if (num != value)
							{
								this.Value = num;
								if (this.valueChangedDelegate != null)
								{
									this.valueChangedDelegate();
								}
								if (this.scrollChangedDelegate != null)
								{
									this.scrollChangedDelegate();
								}
							}
						}
						else
						{
							int num2 = this.Value += this.stepSize;
							this.moveTabPosition(this.tab.Y, 0);
							if (this.valueChangedDelegate != null)
							{
								this.valueChangedDelegate();
							}
							if (this.scrollChangedDelegate != null)
							{
								this.scrollChangedDelegate();
							}
						}
					}
					else if (this.background.LastRelativeMousePos.Y < this.tab.Y + this.tab.Height / 2)
					{
						this.moveTabPosition(this.tab.Y, -this.tab.Height);
					}
					else
					{
						this.moveTabPosition(this.tab.Y, this.tab.Height);
					}
				}
				this.clickedOnBar = false;
			}

			// Token: 0x06000EE6 RID: 3814 RVA: 0x00100198 File Offset: 0x000FE398
			private void moveTabPosition(int baseYPos, int diff)
			{
				int num = baseYPos + diff;
				if (num < this.minTabPosition)
				{
					num = this.minTabPosition;
				}
				if (num >= this.maxTabPosition)
				{
					num = this.maxTabPosition;
				}
				this.tab.Position = new Point(0, num);
				int num2 = this.currentValue;
				if (this.maxTabPosition - this.minTabPosition > 0)
				{
					this.currentValue = this.maxValue * (num - this.minTabPosition) / Math.Max(this.maxTabPosition - this.minTabPosition, 1);
				}
				else
				{
					this.currentValue = 0;
				}
				if (num2 != this.currentValue && this.valueChangedDelegate != null)
				{
					this.valueChangedDelegate();
				}
				if (this.scrollChangedDelegate != null)
				{
					this.scrollChangedDelegate();
				}
				this.background.invalidate();
				this.tab.invalidate();
			}

			// Token: 0x06000EE7 RID: 3815 RVA: 0x00010CE1 File Offset: 0x0000EEE1
			public void scrollUp()
			{
				this.moveTabPosition(this.tab.Y, -this.tab.Height);
			}

			// Token: 0x06000EE8 RID: 3816 RVA: 0x00010D00 File Offset: 0x0000EF00
			public void scrollUp(int amount)
			{
				this.moveTabPosition(this.tab.Y, -amount);
			}

			// Token: 0x06000EE9 RID: 3817 RVA: 0x00010D15 File Offset: 0x0000EF15
			public void scrollDown()
			{
				this.moveTabPosition(this.tab.Y, this.tab.Height);
			}

			// Token: 0x06000EEA RID: 3818 RVA: 0x00010D33 File Offset: 0x0000EF33
			public void scrollDown(int amount)
			{
				this.moveTabPosition(this.tab.Y, amount);
			}

			// Token: 0x04001264 RID: 4708
			private CustomSelfDrawPanel.CSDVertExtendingPanel background = new CustomSelfDrawPanel.CSDVertExtendingPanel();

			// Token: 0x04001265 RID: 4709
			private CustomSelfDrawPanel.CSDVertExtendingPanel tab = new CustomSelfDrawPanel.CSDVertExtendingPanel();

			// Token: 0x04001266 RID: 4710
			private Point offsetTL;

			// Token: 0x04001267 RID: 4711
			private Point offsetBR;

			// Token: 0x04001268 RID: 4712
			private int currentValue;

			// Token: 0x04001269 RID: 4713
			private int maxValue;

			// Token: 0x0400126A RID: 4714
			private int visibleLines = 1;

			// Token: 0x0400126B RID: 4715
			private int tabMinSize;

			// Token: 0x0400126C RID: 4716
			private int stepSize;

			// Token: 0x0400126D RID: 4717
			private bool created;

			// Token: 0x0400126E RID: 4718
			protected CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate valueChangedDelegate;

			// Token: 0x0400126F RID: 4719
			protected CustomSelfDrawPanel.CSDControl.CSD_ScrollBarChangedDelegate scrollChangedDelegate;

			// Token: 0x04001270 RID: 4720
			private int minTabPosition;

			// Token: 0x04001271 RID: 4721
			private int maxTabPosition;

			// Token: 0x04001272 RID: 4722
			private bool held;

			// Token: 0x04001273 RID: 4723
			private int baseYPos;

			// Token: 0x04001274 RID: 4724
			private bool clickedOnBar;
		}

		// Token: 0x02000180 RID: 384
		public class CSDTrackBar : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x170000FD RID: 253
			// (get) Token: 0x06000EEC RID: 3820 RVA: 0x00010D6C File Offset: 0x0000EF6C
			// (set) Token: 0x06000EED RID: 3821 RVA: 0x00010D74 File Offset: 0x0000EF74
			public int Value
			{
				get
				{
					return this.currentValue;
				}
				set
				{
					this.currentValue = value;
					this.recalc();
				}
			}

			// Token: 0x170000FE RID: 254
			// (get) Token: 0x06000EEE RID: 3822 RVA: 0x00010D83 File Offset: 0x0000EF83
			// (set) Token: 0x06000EEF RID: 3823 RVA: 0x00010D8B File Offset: 0x0000EF8B
			public int Max
			{
				get
				{
					return this.maxValue;
				}
				set
				{
					this.maxValue = value;
					this.recalc();
					this.calcStepSize();
				}
			}

			// Token: 0x170000FF RID: 255
			// (get) Token: 0x06000EF0 RID: 3824 RVA: 0x00010DA0 File Offset: 0x0000EFA0
			// (set) Token: 0x06000EF1 RID: 3825 RVA: 0x00010DA8 File Offset: 0x0000EFA8
			public int StepValue
			{
				get
				{
					return this.stepValue;
				}
				set
				{
					this.stepValue = value;
					if (this.stepValue < 1)
					{
						this.stepValue = 1;
					}
				}
			}

			// Token: 0x17000100 RID: 256
			// (get) Token: 0x06000EF2 RID: 3826 RVA: 0x00010DC1 File Offset: 0x0000EFC1
			// (set) Token: 0x06000EF3 RID: 3827 RVA: 0x00010DC9 File Offset: 0x0000EFC9
			public Rectangle Margin
			{
				get
				{
					return this.margin;
				}
				set
				{
					this.margin = value;
					this.recalc();
				}
			}

			// Token: 0x06000EF4 RID: 3828 RVA: 0x00010DD8 File Offset: 0x0000EFD8
			public void Create(Image backImage, Image tabImage, Image leftImage, Image rightImage, Image tabDownImage, Image tabOverImage)
			{
				this.Create(backImage, tabImage, leftImage, rightImage, tabDownImage, tabOverImage, true);
			}

			// Token: 0x06000EF5 RID: 3829 RVA: 0x0010026C File Offset: 0x000FE46C
			public void Create(Image backImage, Image tabImage, Image leftImage, Image rightImage, Image tabDownImage, Image tabOverImage, bool backClick)
			{
				this.m_tabImage = tabImage;
				this.m_tabDownImage = tabDownImage;
				this.m_tabOverImage = tabOverImage;
				Size size = this.Size;
				if (backImage != null)
				{
					this.background.Image = backImage;
					this.background.Size = backImage.Size;
					base.addControl(this.background);
					size = backImage.Size;
				}
				else
				{
					this.background.Size = size;
					base.addControl(this.background);
				}
				this.tab.Image = tabImage;
				this.minTabPosition = this.margin.Left - this.tab.Size.Width / 2;
				this.maxTabPosition = this.minTabPosition + (size.Width - this.margin.Left - this.margin.Width);
				this.tab.Position = new Point(this.minTabPosition, this.margin.Top);
				this.background.addControl(this.tab);
				this.created = true;
				this.recalc();
				this.calcStepSize();
				this.Size = size;
				this.tab.setMouseDownDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseDownDelegate(this.buttonDown), new CustomSelfDrawPanel.CSDControl.CSD_MouseDownDelegate(this.buttonUp));
				this.tab.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.buttonOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.buttonLeave));
				if (backClick)
				{
					this.background.setMouseDownDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseDownDelegate(this.backgroundButtonDown), new CustomSelfDrawPanel.CSDControl.CSD_MouseDownDelegate(this.backgroundButtonUp));
				}
				this.mouseWheelOverlay.Position = new Point(0, 0);
				this.mouseWheelOverlay.Size = size;
				this.mouseWheelOverlay.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mouseWheelMoved));
				base.addControl(this.mouseWheelOverlay);
			}

			// Token: 0x06000EF6 RID: 3830 RVA: 0x00100440 File Offset: 0x000FE640
			private void mouseWheelMoved(int delta)
			{
				this.tab.invalidate();
				int num = this.currentValue;
				if (delta < 0)
				{
					this.currentValue -= this.stepValue;
					if (this.currentValue < 0)
					{
						this.currentValue = 0;
					}
					this.recalc();
				}
				else if (delta > 0)
				{
					this.currentValue += this.stepValue;
					if (this.currentValue > this.maxValue)
					{
						this.currentValue = this.maxValue;
					}
					this.recalc();
				}
				if (num != this.currentValue && this.valueChangedDelegate != null)
				{
					this.valueChangedDelegate();
				}
				this.background.invalidate();
				this.tab.invalidate();
			}

			// Token: 0x06000EF7 RID: 3831 RVA: 0x00010DEA File Offset: 0x0000EFEA
			public void setValueChangeDelegate(CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate newDelegate)
			{
				this.valueChangedDelegate = newDelegate;
			}

			// Token: 0x06000EF8 RID: 3832 RVA: 0x001004F8 File Offset: 0x000FE6F8
			public void recalc()
			{
				if (this.created)
				{
					if (this.maxValue > 0)
					{
						int num = this.background.Size.Width - this.margin.Left - this.margin.Width;
						int num2 = num * this.Value / Math.Max(this.maxValue, 1);
						this.tab.Position = new Point(this.minTabPosition + num2, this.margin.Top);
						return;
					}
					this.tab.Position = new Point(this.minTabPosition, this.margin.Top);
				}
			}

			// Token: 0x06000EF9 RID: 3833 RVA: 0x001005A0 File Offset: 0x000FE7A0
			private void calcStepSize()
			{
				int num = this.background.Size.Width - this.margin.Left - this.margin.Width;
				if (this.maxValue <= 1)
				{
					this.stepSize = num;
					return;
				}
				this.stepSize = num / this.maxValue;
			}

			// Token: 0x06000EFA RID: 3834 RVA: 0x001005F8 File Offset: 0x000FE7F8
			private void buttonDown()
			{
				if (!this.held)
				{
					this.baseXPos = base.csd.LastMousePosition.X;
					this.baseValue = this.Value;
					this.held = true;
					this.updateTabImages();
					return;
				}
				int num = base.csd.LastMousePosition.X - this.baseXPos;
				if (num != 0)
				{
					this.moveTabPosition(this.baseXPos, num);
				}
			}

			// Token: 0x06000EFB RID: 3835 RVA: 0x00007CE0 File Offset: 0x00005EE0
			private void buttonUp()
			{
			}

			// Token: 0x06000EFC RID: 3836 RVA: 0x00010DF3 File Offset: 0x0000EFF3
			private void buttonOver()
			{
				this.m_mouseOverFlag = true;
				this.updateTabImages();
			}

			// Token: 0x06000EFD RID: 3837 RVA: 0x00010E02 File Offset: 0x0000F002
			private void buttonLeave()
			{
				this.m_mouseOverFlag = false;
				this.updateTabImages();
			}

			// Token: 0x06000EFE RID: 3838 RVA: 0x0010066C File Offset: 0x000FE86C
			private void updateTabImages()
			{
				if (this.held)
				{
					this.tab.Image = this.m_tabDownImage;
				}
				else if (this.m_mouseOverFlag)
				{
					this.tab.Image = this.m_tabOverImage;
				}
				else
				{
					this.tab.Image = this.m_tabImage;
				}
				this.tab.invalidate();
			}

			// Token: 0x06000EFF RID: 3839 RVA: 0x00010E11 File Offset: 0x0000F011
			private void backgroundButtonDown()
			{
				this.clickedOnBar = true;
			}

			// Token: 0x06000F00 RID: 3840 RVA: 0x001006CC File Offset: 0x000FE8CC
			private void backgroundButtonUp()
			{
				if (this.clickedOnBar)
				{
					int x = this.background.LastRelativeMousePos.X;
					int num = this.tab.Position.X + this.tab.Width / 2;
					int num2 = this.currentValue;
					this.tab.invalidate();
					if (x < num)
					{
						this.currentValue -= this.stepValue;
						if (this.currentValue < 0)
						{
							this.currentValue = 0;
						}
						this.recalc();
					}
					else
					{
						this.currentValue += this.stepValue;
						if (this.currentValue > this.maxValue)
						{
							this.currentValue = this.maxValue;
						}
						this.recalc();
					}
					if (num2 != this.currentValue && this.valueChangedDelegate != null)
					{
						this.valueChangedDelegate();
					}
					this.background.invalidate();
					this.tab.invalidate();
				}
				this.clickedOnBar = false;
			}

			// Token: 0x06000F01 RID: 3841 RVA: 0x001007C8 File Offset: 0x000FE9C8
			private void moveTabPosition(int baseYPos, int diff)
			{
				int num = this.currentValue;
				this.tab.invalidate();
				if (this.maxValue == 0)
				{
					this.currentValue = 0;
				}
				else
				{
					int num2 = this.background.Size.Width - this.margin.Left - this.margin.Width;
					int num3 = num2 * this.baseValue / Math.Max(this.maxValue, 1);
					num3 += diff;
					if (num3 < 0)
					{
						num3 = 0;
					}
					if (num3 >= num2)
					{
						num3 = num2;
					}
					this.currentValue = this.maxValue * (num3 + this.stepSize / 2) / Math.Max(this.maxTabPosition - this.minTabPosition, 1);
				}
				this.recalc();
				if (num != this.currentValue && this.valueChangedDelegate != null)
				{
					this.valueChangedDelegate();
				}
				base.invalidate();
				this.background.invalidate();
				this.tab.invalidate();
			}

			// Token: 0x06000F02 RID: 3842 RVA: 0x00010E1A File Offset: 0x0000F01A
			public void invalidateTab()
			{
				this.tab.invalidate();
			}

			// Token: 0x06000F03 RID: 3843 RVA: 0x00010E27 File Offset: 0x0000F027
			public override void draw(Point parentLocation)
			{
				if (this.held)
				{
					if (!base.csd.MouseReallyPressed)
					{
						this.tab.MouseDownFlag = false;
						this.held = false;
						this.updateTabImages();
						return;
					}
					this.buttonDown();
				}
			}

			// Token: 0x04001275 RID: 4725
			private CustomSelfDrawPanel.CSDImage background = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001276 RID: 4726
			private CustomSelfDrawPanel.CSDImage leftTab = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001277 RID: 4727
			private CustomSelfDrawPanel.CSDImage tab = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001278 RID: 4728
			private CustomSelfDrawPanel.CSDImage rightTab = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001279 RID: 4729
			private CustomSelfDrawPanel.CSDControl mouseWheelOverlay = new CustomSelfDrawPanel.CSDControl();

			// Token: 0x0400127A RID: 4730
			private int currentValue;

			// Token: 0x0400127B RID: 4731
			private int maxValue;

			// Token: 0x0400127C RID: 4732
			private int stepValue = 1;

			// Token: 0x0400127D RID: 4733
			private Rectangle margin;

			// Token: 0x0400127E RID: 4734
			private bool created;

			// Token: 0x0400127F RID: 4735
			private Image m_tabImage;

			// Token: 0x04001280 RID: 4736
			private Image m_tabDownImage;

			// Token: 0x04001281 RID: 4737
			private Image m_tabOverImage;

			// Token: 0x04001282 RID: 4738
			protected CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate valueChangedDelegate;

			// Token: 0x04001283 RID: 4739
			private int minTabPosition;

			// Token: 0x04001284 RID: 4740
			private int maxTabPosition;

			// Token: 0x04001285 RID: 4741
			public bool held;

			// Token: 0x04001286 RID: 4742
			private int baseXPos;

			// Token: 0x04001287 RID: 4743
			private int baseValue;

			// Token: 0x04001288 RID: 4744
			private int stepSize = 1;

			// Token: 0x04001289 RID: 4745
			private bool m_mouseOverFlag;

			// Token: 0x0400128A RID: 4746
			private bool clickedOnBar;
		}

		// Token: 0x02000181 RID: 385
		public class CSDHorzProgressBar : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x17000101 RID: 257
			// (get) Token: 0x06000F05 RID: 3845 RVA: 0x00010E5E File Offset: 0x0000F05E
			// (set) Token: 0x06000F06 RID: 3846 RVA: 0x00010E66 File Offset: 0x0000F066
			public Point Offset
			{
				get
				{
					return this.offset;
				}
				set
				{
					this.offset = value;
				}
			}

			// Token: 0x06000F07 RID: 3847 RVA: 0x0010090C File Offset: 0x000FEB0C
			public void Create(Image leftImage, Image midImage, Image rightImage, Image innerLeftImage, Image innerMidImage, Image innerRightImage)
			{
				if (leftImage != null && midImage != null && rightImage != null)
				{
					this.Left.Image = leftImage;
					this.Left.Position = new Point(0, 0);
					base.addControl(this.Left);
					this.Right.Image = rightImage;
					this.Right.Position = new Point(base.Width - this.Right.Image.Width, 0);
					base.addControl(this.Right);
					this.Mid.Image = midImage;
					this.Mid.Position = new Point(this.Left.Image.Width, 0);
					this.Mid.Size = new Size(base.Width - this.Left.Image.Width - this.Right.Image.Width, this.Mid.Image.Height);
					this.Mid.Tile = true;
					base.addControl(this.Mid);
					this.Size = new Size(this.Size.Width, this.Left.Image.Height);
				}
				else
				{
					this.Size = new Size(this.Size.Width, innerLeftImage.Height);
				}
				this.barLeft.Image = innerLeftImage;
				this.barLeft.Position = this.offset;
				base.addControl(this.barLeft);
				this.barMid.Image = innerMidImage;
				this.barMid.Tile = true;
				base.addControl(this.barMid);
				this.barRight.Image = innerRightImage;
				base.addControl(this.barRight);
				this.created = true;
				this.setValues(1.0, 1.0);
			}

			// Token: 0x06000F08 RID: 3848 RVA: 0x00100AF4 File Offset: 0x000FECF4
			public void setValues(double curValue, double maxValue)
			{
				if (!this.created)
				{
					return;
				}
				if (maxValue <= 0.0)
				{
					this.barLeft.Visible = false;
					this.barRight.Visible = false;
					this.barMid.Visible = false;
					return;
				}
				this.barLeft.Visible = true;
				this.barRight.Visible = true;
				this.barMid.Visible = true;
				if (curValue > maxValue)
				{
					curValue = maxValue;
				}
				double num = (double)(base.Width - this.offset.X * 2 - this.barLeft.Image.Width - this.barRight.Image.Width);
				double num2 = num * curValue / maxValue;
				num2 = Math.Round(num2);
				this.barRight.Position = new Point(this.offset.X + (int)num2 + this.barLeft.Width, this.offset.Y);
				this.barMid.Position = new Point(this.offset.X + this.barLeft.Width, this.offset.Y);
				this.barMid.Size = new Size((int)num2, this.barLeft.Image.Height);
				this.barMid.ClipRect = new Rectangle(new Point(0, 0), this.barMid.Size);
			}

			// Token: 0x0400128B RID: 4747
			public CustomSelfDrawPanel.CSDImage Left = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x0400128C RID: 4748
			public CustomSelfDrawPanel.CSDImage Mid = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x0400128D RID: 4749
			public CustomSelfDrawPanel.CSDImage Right = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x0400128E RID: 4750
			public CustomSelfDrawPanel.CSDImage barLeft = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x0400128F RID: 4751
			public CustomSelfDrawPanel.CSDImage barMid = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001290 RID: 4752
			public CustomSelfDrawPanel.CSDImage barRight = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001291 RID: 4753
			private Point offset = new Point(0, 0);

			// Token: 0x04001292 RID: 4754
			private bool created;
		}

		// Token: 0x02000182 RID: 386
		public class CSDDragPanel : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x17000102 RID: 258
			// (get) Token: 0x06000F0A RID: 3850 RVA: 0x00010E6F File Offset: 0x0000F06F
			public int YDiff
			{
				get
				{
					return this.yDiff;
				}
			}

			// Token: 0x17000103 RID: 259
			// (get) Token: 0x06000F0B RID: 3851 RVA: 0x00010E77 File Offset: 0x0000F077
			public int XDiff
			{
				get
				{
					return this.xDiff;
				}
			}

			// Token: 0x06000F0C RID: 3852 RVA: 0x00100CBC File Offset: 0x000FEEBC
			public CSDDragPanel()
			{
				base.setMouseDownDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseDownDelegate(this.buttonDown), new CustomSelfDrawPanel.CSDControl.CSD_MouseDownDelegate(this.buttonUp));
			}

			// Token: 0x06000F0D RID: 3853 RVA: 0x00010E7F File Offset: 0x0000F07F
			public void setValueChangeDelegate(CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate newDelegate)
			{
				this.valueChangedDelegate = newDelegate;
			}

			// Token: 0x06000F0E RID: 3854 RVA: 0x00100D10 File Offset: 0x000FEF10
			private void buttonDown()
			{
				if (!this.held)
				{
					this.heldPosition = base.csd.LastMousePosition;
					this.held = true;
					this.yDiff = 0;
				}
				else
				{
					this.xDiff = base.csd.LastMousePosition.X - this.heldPosition.X;
					this.yDiff = base.csd.LastMousePosition.Y - this.heldPosition.Y;
				}
				if (this.valueChangedDelegate != null && (this.xDiff != 0 || this.yDiff != 0))
				{
					this.valueChangedDelegate();
				}
				this.heldPosition = new Point(base.csd.LastMousePosition.X, base.csd.LastMousePosition.Y);
				base.csd.addTrapMouseEvent(this);
			}

			// Token: 0x06000F0F RID: 3855 RVA: 0x00100DF0 File Offset: 0x000FEFF0
			private void buttonUp()
			{
				if (!base.csd.MouseReallyPressed)
				{
					this.held = false;
					this.yDiff = 0;
					this.xDiff = 0;
					if (this.valueChangedDelegate != null)
					{
						this.valueChangedDelegate();
					}
					base.csd.removeTrapMouseEvent(this);
				}
			}

			// Token: 0x06000F10 RID: 3856 RVA: 0x00100E40 File Offset: 0x000FF040
			public override void mouseEventTrapped()
			{
				if (!this.held)
				{
					return;
				}
				if (!base.csd.MouseReallyPressed)
				{
					this.mouseDownFlag = false;
					this.buttonUp();
					return;
				}
				this.xDiff = base.csd.LastMousePosition.X - this.heldPosition.X;
				this.yDiff = base.csd.LastMousePosition.Y - this.heldPosition.Y;
				if (this.valueChangedDelegate != null && (Math.Abs(this.xDiff) > 5 || Math.Abs(this.yDiff) > 5))
				{
					InterfaceMgr.mouseDownOnDraggable = true;
					this.valueChangedDelegate();
				}
				this.heldPosition = new Point(base.csd.LastMousePosition.X, base.csd.LastMousePosition.Y);
			}

			// Token: 0x04001293 RID: 4755
			protected CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate valueChangedDelegate;

			// Token: 0x04001294 RID: 4756
			private float xMomentum;

			// Token: 0x04001295 RID: 4757
			private float yMomentum;

			// Token: 0x04001296 RID: 4758
			private float dampen = 0.97f;

			// Token: 0x04001297 RID: 4759
			private float maxMomentum = 100f;

			// Token: 0x04001298 RID: 4760
			private bool held;

			// Token: 0x04001299 RID: 4761
			private Point heldPosition = new Point(0, 0);

			// Token: 0x0400129A RID: 4762
			private int yDiff;

			// Token: 0x0400129B RID: 4763
			private int xDiff;
		}

		// Token: 0x02000183 RID: 387
		public class CSDFill : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x17000104 RID: 260
			// (get) Token: 0x06000F11 RID: 3857 RVA: 0x00010E88 File Offset: 0x0000F088
			// (set) Token: 0x06000F12 RID: 3858 RVA: 0x00010E90 File Offset: 0x0000F090
			public float Alpha
			{
				get
				{
					return this.alpha;
				}
				set
				{
					if (value > 1f)
					{
						this.alpha = 1f;
						return;
					}
					this.alpha = value;
				}
			}

			// Token: 0x17000105 RID: 261
			// (get) Token: 0x06000F13 RID: 3859 RVA: 0x00010EAD File Offset: 0x0000F0AD
			// (set) Token: 0x06000F14 RID: 3860 RVA: 0x00010EB5 File Offset: 0x0000F0B5
			public Color FillColor
			{
				get
				{
					return this.fillColor;
				}
				set
				{
					if (this.fillColor != value)
					{
						base.invalidate();
					}
					this.fillColor = value;
				}
			}

			// Token: 0x17000106 RID: 262
			// (get) Token: 0x06000F15 RID: 3861 RVA: 0x00010ED2 File Offset: 0x0000F0D2
			// (set) Token: 0x06000F16 RID: 3862 RVA: 0x00010EDA File Offset: 0x0000F0DA
			public bool Border
			{
				get
				{
					return this.border;
				}
				set
				{
					if (this.border != value)
					{
						base.invalidate();
					}
					this.border = value;
				}
			}

			// Token: 0x17000107 RID: 263
			// (get) Token: 0x06000F17 RID: 3863 RVA: 0x00010EF2 File Offset: 0x0000F0F2
			// (set) Token: 0x06000F18 RID: 3864 RVA: 0x00010EFA File Offset: 0x0000F0FA
			public bool SpecialGradient
			{
				get
				{
					return this.specialGradient;
				}
				set
				{
					if (this.specialGradient != value)
					{
						base.invalidate();
					}
					this.specialGradient = value;
				}
			}

			// Token: 0x06000F19 RID: 3865 RVA: 0x00100F24 File Offset: 0x000FF124
			public override void draw(Point parentLocation)
			{
				Rectangle rectangle = base.Rectangle;
				rectangle.X += parentLocation.X;
				rectangle.Y += parentLocation.Y;
				if (this.specialGradient)
				{
					base.csd.drawSpecialGradient(rectangle);
					return;
				}
				base.csd.fillRect(rectangle, this.fillColor);
				if (this.border)
				{
					Color black = global::ARGBColors.Black;
					base.csd.drawLine(black, new Point(rectangle.X, rectangle.Y), new Point(rectangle.X + this.Size.Width - 1, rectangle.Y));
					base.csd.drawLine(black, new Point(rectangle.X, rectangle.Y), new Point(rectangle.X, rectangle.Y + this.Size.Height - 2));
					base.csd.drawLine(black, new Point(rectangle.X + this.Size.Width - 1, rectangle.Y + this.Size.Height - 1), new Point(rectangle.X + this.Size.Width - 1, rectangle.Y));
					base.csd.drawLine(black, new Point(rectangle.X + this.Size.Width - 1, rectangle.Y + this.Size.Height - 1), new Point(rectangle.X, rectangle.Y + this.Size.Height - 1));
				}
			}

			// Token: 0x0400129C RID: 4764
			private float alpha = 1f;

			// Token: 0x0400129D RID: 4765
			private Color fillColor;

			// Token: 0x0400129E RID: 4766
			private bool border;

			// Token: 0x0400129F RID: 4767
			private bool specialGradient;
		}

		// Token: 0x02000184 RID: 388
		public class CSDLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x17000108 RID: 264
			// (get) Token: 0x06000F1B RID: 3867 RVA: 0x00010F25 File Offset: 0x0000F125
			// (set) Token: 0x06000F1C RID: 3868 RVA: 0x00010F2D File Offset: 0x0000F12D
			public Color LineColor
			{
				get
				{
					return this.lineColor;
				}
				set
				{
					if (this.lineColor != value)
					{
						base.invalidate();
					}
					this.lineColor = value;
				}
			}

			// Token: 0x06000F1D RID: 3869 RVA: 0x001010EC File Offset: 0x000FF2EC
			public override void draw(Point parentLocation)
			{
				Rectangle rectangle = base.Rectangle;
				rectangle.X += parentLocation.X;
				rectangle.Y += parentLocation.Y;
				base.csd.drawLine(this.lineColor, new Point(rectangle.X, rectangle.Y), new Point(rectangle.X + this.Size.Width, rectangle.Y + this.Size.Height));
			}

			// Token: 0x040012A0 RID: 4768
			private Color lineColor = global::ARGBColors.White;
		}

		// Token: 0x02000185 RID: 389
		public class CSDRectangle : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x17000109 RID: 265
			// (get) Token: 0x06000F1F RID: 3871 RVA: 0x00010F5D File Offset: 0x0000F15D
			// (set) Token: 0x06000F20 RID: 3872 RVA: 0x00010F65 File Offset: 0x0000F165
			public Color LineColor
			{
				get
				{
					return this.lineColor;
				}
				set
				{
					if (this.lineColor != value)
					{
						base.invalidate();
					}
					this.lineColor = value;
				}
			}

			// Token: 0x06000F21 RID: 3873 RVA: 0x00101180 File Offset: 0x000FF380
			public override void draw(Point parentLocation)
			{
				Rectangle rectangle = base.Rectangle;
				rectangle.X += parentLocation.X;
				rectangle.Y += parentLocation.Y;
				base.csd.drawLine(this.lineColor, new Point(rectangle.X, rectangle.Y), new Point(rectangle.X + this.Size.Width - 1, rectangle.Y));
				base.csd.drawLine(this.lineColor, new Point(rectangle.X, rectangle.Y), new Point(rectangle.X, rectangle.Y + this.Size.Height - 2));
				base.csd.drawLine(this.lineColor, new Point(rectangle.X + this.Size.Width - 1, rectangle.Y + this.Size.Height - 1), new Point(rectangle.X + this.Size.Width - 1, rectangle.Y));
				base.csd.drawLine(this.lineColor, new Point(rectangle.X + this.Size.Width - 1, rectangle.Y + this.Size.Height - 1), new Point(rectangle.X, rectangle.Y + this.Size.Height - 1));
			}

			// Token: 0x040012A1 RID: 4769
			private Color lineColor = global::ARGBColors.White;
		}

		// Token: 0x02000186 RID: 390
		private class InvalidRectpair
		{
			// Token: 0x040012A2 RID: 4770
			public Rectangle rect;

			// Token: 0x040012A3 RID: 4771
			public CustomSelfDrawPanel panel;
		}

		// Token: 0x02000187 RID: 391
		public class WikiLinkControl : CustomSelfDrawPanel.CSDButton
		{
			// Token: 0x06000F24 RID: 3876 RVA: 0x00010F95 File Offset: 0x0000F195
			public static CustomSelfDrawPanel.WikiLinkControl init(CustomSelfDrawPanel.CSDControl parent, int screenID, Point position)
			{
				return CustomSelfDrawPanel.WikiLinkControl.init(parent, screenID, position, false);
			}

			// Token: 0x06000F25 RID: 3877 RVA: 0x00101324 File Offset: 0x000FF524
			public static CustomSelfDrawPanel.WikiLinkControl init(CustomSelfDrawPanel.CSDControl parent, int screenID, Point position, bool scaledSmaller)
			{
				if (AdvicePanel.usesAdvicePanel(screenID))
				{
					InterfaceMgr.Instance.openAdvicePopupFirstTime(screenID);
				}
				CustomSelfDrawPanel.WikiLinkControl wikiLinkControl = new CustomSelfDrawPanel.WikiLinkControl();
				wikiLinkControl.ImageNorm = GFXLibrary.int_button_Q_normal;
				wikiLinkControl.ImageOver = GFXLibrary.int_button_Q_over;
				wikiLinkControl.ImageClick = GFXLibrary.int_button_Q_in;
				if (scaledSmaller)
				{
					wikiLinkControl.Size = new Size(28, 28);
				}
				wikiLinkControl.Position = position;
				wikiLinkControl.m_ID = screenID;
				wikiLinkControl.CustomTooltipData = screenID;
				wikiLinkControl.CustomTooltipID = 4400;
				wikiLinkControl.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(wikiLinkControl.helpClicked));
				parent.addControl(wikiLinkControl);
				return wikiLinkControl;
			}

			// Token: 0x06000F26 RID: 3878 RVA: 0x001013C8 File Offset: 0x000FF5C8
			public static CustomSelfDrawPanel.WikiLinkControl init(CustomSelfDrawPanel parent, int screenID, Point position)
			{
				if (AdvicePanel.usesAdvicePanel(screenID))
				{
					InterfaceMgr.Instance.openAdvicePopupFirstTime(screenID);
				}
				CustomSelfDrawPanel.WikiLinkControl wikiLinkControl = new CustomSelfDrawPanel.WikiLinkControl();
				wikiLinkControl.ImageNorm = GFXLibrary.int_button_Q_normal;
				wikiLinkControl.ImageOver = GFXLibrary.int_button_Q_over;
				wikiLinkControl.ImageClick = GFXLibrary.int_button_Q_in;
				wikiLinkControl.Position = position;
				wikiLinkControl.m_ID = screenID;
				wikiLinkControl.CustomTooltipData = screenID;
				wikiLinkControl.CustomTooltipID = 4400;
				wikiLinkControl.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(wikiLinkControl.helpClicked));
				parent.addControl(wikiLinkControl);
				return wikiLinkControl;
			}

			// Token: 0x06000F27 RID: 3879 RVA: 0x00010FA0 File Offset: 0x0000F1A0
			public void helpClicked()
			{
				CustomSelfDrawPanel.WikiLinkControl.openHelpLink(this.m_ID);
			}

			// Token: 0x06000F28 RID: 3880 RVA: 0x00010FAD File Offset: 0x0000F1AD
			public static void openHelpLink(int index)
			{
				if (AdvicePanel.usesAdvicePanel(index))
				{
					InterfaceMgr.Instance.openAdvicePopupFromButton(index);
					return;
				}
				CustomSelfDrawPanel.WikiLinkControl.openWikiPage(index);
			}

			// Token: 0x06000F29 RID: 3881 RVA: 0x00101458 File Offset: 0x000FF658
			public static void openWikiPage(int index)
			{
				if (GameEngine.Instance.LocalWorldData != null && GameEngine.Instance.LocalWorldData.EraWorld)
				{
					switch (index)
					{
					case 45:
					case 46:
					case 48:
					case 51:
					case 52:
					case 53:
						index = 55;
						break;
					}
				}
				int num = 0;
				string languageIdent = Program.mySettings.LanguageIdent;
				if (languageIdent != null)
				{
					uint num2 = PrivateImplementationDetails.ComputeStringHash(languageIdent);
					if (num2 <= 1194886160U)
					{
						if (num2 <= 1162757945U)
						{
							if (num2 != 1092248970U)
							{
								if (num2 == 1162757945U)
								{
									if (languageIdent == "pl")
									{
										num = 5;
									}
								}
							}
							else if (languageIdent == "en")
							{
								num = 0;
							}
						}
						else if (num2 != 1176137065U)
						{
							if (num2 == 1194886160U)
							{
								if (languageIdent == "it")
								{
									num = 7;
								}
							}
						}
						else if (languageIdent == "es")
						{
							num = 4;
						}
					}
					else if (num2 <= 1213488160U)
					{
						if (num2 != 1195724803U)
						{
							if (num2 == 1213488160U)
							{
								if (languageIdent == "ru")
								{
									num = 3;
								}
							}
						}
						else if (languageIdent == "tr")
						{
							num = 6;
						}
					}
					else if (num2 != 1461901041U)
					{
						if (num2 != 1545391778U)
						{
							if (num2 == 1565420801U)
							{
								if (languageIdent == "pt")
								{
									num = 8;
								}
							}
						}
						else if (languageIdent == "de")
						{
							num = 1;
						}
					}
					else if (languageIdent == "fr")
					{
						num = 2;
					}
				}
				if (CustomSelfDrawPanel.WikiLinkControl.urls[index * 11 + num].Length == 0)
				{
					num = 0;
				}
				try
				{
					Process.Start(CustomSelfDrawPanel.WikiLinkControl.urls[index * 11 + num]);
				}
				catch (Exception)
				{
				}
			}

			// Token: 0x040012A4 RID: 4772
			public const int WORLD_MAP = 0;

			// Token: 0x040012A5 RID: 4773
			public const int VILLAGE_VILLAGE_MAP = 1;

			// Token: 0x040012A6 RID: 4774
			public const int VILLAGE_CASTLE_MAP = 2;

			// Token: 0x040012A7 RID: 4775
			public const int VILLAGE_RESOURCES = 3;

			// Token: 0x040012A8 RID: 4776
			public const int VILLAGE_TRADE = 4;

			// Token: 0x040012A9 RID: 4777
			public const int VILLAGE_TROOPS = 5;

			// Token: 0x040012AA RID: 4778
			public const int VILLAGE_UNITS = 6;

			// Token: 0x040012AB RID: 4779
			public const int VILLAGE_HOLD_A_BANQUET = 7;

			// Token: 0x040012AC RID: 4780
			public const int VILLAGE_VASSALS = 8;

			// Token: 0x040012AD RID: 4781
			public const int PARISH_CAPITAL_VILLAGE_MAP = 9;

			// Token: 0x040012AE RID: 4782
			public const int PARISH_CAPITAL_CASTLE_MAP = 10;

			// Token: 0x040012AF RID: 4783
			public const int PARISH_CAPITAL_RESOURCES = 11;

			// Token: 0x040012B0 RID: 4784
			public const int PARISH_CAPITAL_TRADE = 12;

			// Token: 0x040012B1 RID: 4785
			public const int PARISH_CAPITAL_TROOPS = 13;

			// Token: 0x040012B2 RID: 4786
			public const int PARISH_CAPITAL_CAPITAL_INFO = 14;

			// Token: 0x040012B3 RID: 4787
			public const int PARISH_CAPITAL_VOTE = 15;

			// Token: 0x040012B4 RID: 4788
			public const int PARISH_CAPITAL_PARISH_FORUM = 16;

			// Token: 0x040012B5 RID: 4789
			public const int RESEARCH = 17;

			// Token: 0x040012B6 RID: 4790
			public const int RANK = 18;

			// Token: 0x040012B7 RID: 4791
			public const int QUESTS = 19;

			// Token: 0x040012B8 RID: 4792
			public const int ATTACKS = 20;

			// Token: 0x040012B9 RID: 4793
			public const int REPORTS = 21;

			// Token: 0x040012BA RID: 4794
			public const int FACTIONS_HOUSES_GLORY = 22;

			// Token: 0x040012BB RID: 4795
			public const int FACTIONS_HOUSES_FACTION = 23;

			// Token: 0x040012BC RID: 4796
			public const int FACTIONS_HOUSES_HOUSE = 24;

			// Token: 0x040012BD RID: 4797
			public const int CARDS = 25;

			// Token: 0x040012BE RID: 4798
			public const int MAIL = 26;

			// Token: 0x040012BF RID: 4799
			public const int CHAT = 27;

			// Token: 0x040012C0 RID: 4800
			public const int LEADERBOARD = 28;

			// Token: 0x040012C1 RID: 4801
			public const int MY_ACCOUNT = 29;

			// Token: 0x040012C2 RID: 4802
			public const int SETTINGS = 30;

			// Token: 0x040012C3 RID: 4803
			public const int COAT_OF_ARMS = 31;

			// Token: 0x040012C4 RID: 4804
			public const int QUEST_WHEEL = 32;

			// Token: 0x040012C5 RID: 4805
			public const int SEND_ATTACK = 33;

			// Token: 0x040012C6 RID: 4806
			public const int SEND_SCOUTS = 34;

			// Token: 0x040012C7 RID: 4807
			public const int SEND_MONKS = 35;

			// Token: 0x040012C8 RID: 4808
			public const int SEND_TRADER_MERCHANTS = 36;

			// Token: 0x040012C9 RID: 4809
			public const int BUY_PREMIUM_TOKENS = 37;

			// Token: 0x040012CA RID: 4810
			public const int BUY_CROWNS = 38;

			// Token: 0x040012CB RID: 4811
			public const int BUY_CARDS = 39;

			// Token: 0x040012CC RID: 4812
			public const int SWAP_CARDS = 40;

			// Token: 0x040012CD RID: 4813
			public const int LOGOUT = 41;

			// Token: 0x040012CE RID: 4814
			public const int DONATE_TO_PARISH = 42;

			// Token: 0x040012CF RID: 4815
			public const int VILLAGES_OVERVIEW = 43;

			// Token: 0x040012D0 RID: 4816
			public const int ACHIEVEMENTS = 44;

			// Token: 0x040012D1 RID: 4817
			public const int SECONDAGE = 45;

			// Token: 0x040012D2 RID: 4818
			public const int THIRDAGE = 46;

			// Token: 0x040012D3 RID: 4819
			public const int DOMINATION_RULES = 47;

			// Token: 0x040012D4 RID: 4820
			public const int FOURTHAGE = 48;

			// Token: 0x040012D5 RID: 4821
			public const int TREASURE_CASTLES = 49;

			// Token: 0x040012D6 RID: 4822
			public const int PALADIN_CASTLES = 50;

			// Token: 0x040012D7 RID: 4823
			public const int FIFTHAGE = 51;

			// Token: 0x040012D8 RID: 4824
			public const int SIXTHAGE = 52;

			// Token: 0x040012D9 RID: 4825
			public const int FINAL_AGE = 53;

			// Token: 0x040012DA RID: 4826
			public const int ROYAL_TOWERS = 54;

			// Token: 0x040012DB RID: 4827
			public const int ERAS = 55;

			// Token: 0x040012DC RID: 4828
			private int m_ID = -1;

			// Token: 0x040012DD RID: 4829
			private static string[] urls = new string[]
			{
				"http://strongholdkingdoms.gamepedia.com/World_Map",
				"http://strongholdkingdoms-de.gamepedia.com/Weltkarte",
				"http://strongholdkingdoms-fr.gamepedia.com/Carte_du_Monde",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%9A%D0%B0%D1%80%D1%82%D0%B0_%D0%BC%D0%B8%D1%80%D0%B0",
				"http://strongholdkingdoms-es.gamepedia.com/Mapa_del_mundo",
				"http://strongholdkingdoms-pl.gamepedia.com/Mapa_%C5%9Bwiata",
				"http://strongholdkingdoms-tr.gamepedia.com/D%C3%BCnya_Haritas%C4%B1",
				"http://strongholdkingdoms-it.gamepedia.com/Mappa_del_mondo",
				"http://strongholdkingdoms-pt.gamepedia.com/Mapa_do_mundo",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Villages",
				"http://strongholdkingdoms-de.gamepedia.com/D%C3%B6rfer",
				"http://strongholdkingdoms-fr.gamepedia.com/Village",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%A7%D0%B0%D0%92%D0%BE:%D0%92%D0%B0%D1%88%D0%B0_%D0%B4%D0%B5%D1%80%D0%B5%D0%B2%D0%BD%D1%8F",
				"http://strongholdkingdoms-es.gamepedia.com/Aldeas",
				"http://strongholdkingdoms-pl.gamepedia.com/Wioski",
				"http://strongholdkingdoms-tr.gamepedia.com/K%C3%B6yler",
				"http://strongholdkingdoms-it.gamepedia.com/Villaggi",
				"http://strongholdkingdoms-pt.gamepedia.com/Aldeia",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Castles",
				"http://strongholdkingdoms-de.gamepedia.com/Burgen",
				"http://strongholdkingdoms-fr.gamepedia.com/Ch%C3%A2teau",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%97%D0%B0%D0%BC%D0%BA%D0%B8",
				"http://strongholdkingdoms-es.gamepedia.com/Castillos",
				"http://strongholdkingdoms-pl.gamepedia.com/Zamki",
				"http://strongholdkingdoms-tr.gamepedia.com/Kaleler",
				"http://strongholdkingdoms-it.gamepedia.com/Castelli",
				"http://strongholdkingdoms-pt.gamepedia.com/Castelos",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Resources",
				"http://strongholdkingdoms-de.gamepedia.com/Ressourcen",
				"http://strongholdkingdoms-fr.gamepedia.com/Ressources",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%A0%D0%B5%D1%81%D1%83%D1%80%D1%81%D1%8B",
				"http://strongholdkingdoms-es.gamepedia.com/Recursos",
				"http://strongholdkingdoms-pl.gamepedia.com/Surowce",
				"http://strongholdkingdoms-tr.gamepedia.com/Kaynaklar",
				"http://strongholdkingdoms-it.gamepedia.com/Risorse",
				"http://strongholdkingdoms-pt.gamepedia.com/Recursos",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Trading",
				"http://strongholdkingdoms-de.gamepedia.com/Handel",
				"http://strongholdkingdoms-fr.gamepedia.com/Commerce",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%A7%D0%B0%D0%92%D0%BE:%D0%9D%D0%B0%D0%BB%D0%BE%D0%B3%D0%B8_%D0%B8_%D1%82%D0%BE%D1%80%D0%B3%D0%BE%D0%B2%D0%BB%D1%8F",
				"http://strongholdkingdoms-es.gamepedia.com/Comerciar",
				"http://strongholdkingdoms-pl.gamepedia.com/Handel",
				"http://strongholdkingdoms-tr.gamepedia.com/Ticaret",
				"http://strongholdkingdoms-it.gamepedia.com/Commercio",
				"http://strongholdkingdoms-pt.gamepedia.com/Comercio",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Barracks",
				"http://strongholdkingdoms-de.gamepedia.com/Kaserne",
				"http://strongholdkingdoms-fr.gamepedia.com/Garnison",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%91%D0%B0%D1%80%D0%B0%D0%BA%D0%B8",
				"http://strongholdkingdoms-es.gamepedia.com/Barracas",
				"http://strongholdkingdoms-pl.gamepedia.com/Koszary",
				"http://strongholdkingdoms-tr.gamepedia.com/K%C4%B1%C5%9Flalar",
				"http://strongholdkingdoms-it.gamepedia.com/Guarnigione",
				"http://strongholdkingdoms-pt.gamepedia.com/Quartel",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Units",
				"http://strongholdkingdoms-de.gamepedia.com/Einheiten",
				"http://strongholdkingdoms-fr.gamepedia.com/Sp%C3%A9cialistes",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%AE%D0%BD%D0%B8%D1%82%D1%8B",
				"http://strongholdkingdoms-es.gamepedia.com/Unidades",
				"http://strongholdkingdoms-pl.gamepedia.com/Jednostki",
				"http://strongholdkingdoms-tr.gamepedia.com/Birimler",
				"http://strongholdkingdoms-it.gamepedia.com/Unit%C3%A0",
				"http://strongholdkingdoms-pt.gamepedia.com/Unidades",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Banquets",
				"http://strongholdkingdoms-de.gamepedia.com/Bankette",
				"http://strongholdkingdoms-fr.gamepedia.com/Banquets",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%9F%D0%BE%D1%81%D1%82%D1%80%D0%BE%D0%B9%D0%BA%D0%B8:%D0%91%D0%B0%D0%BD%D0%BA%D0%B5%D1%82%D1%8B",
				"http://strongholdkingdoms-es.gamepedia.com/Banquetes",
				"http://strongholdkingdoms-pl.gamepedia.com/Uczty",
				"http://strongholdkingdoms-tr.gamepedia.com/Ziyafetler",
				"http://strongholdkingdoms-it.gamepedia.com/Banchetti",
				"http://strongholdkingdoms-pt.gamepedia.com/Banquete",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Vassals_%26_Liege_Lords",
				"http://strongholdkingdoms-de.gamepedia.com/Vassalle_%26_Lehnsherren",
				"http://strongholdkingdoms-fr.gamepedia.com/Vassaux",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%92%D0%B0%D1%81%D1%81%D0%B0%D0%BB%D1%8B_%D0%B8_%D1%81%D0%B5%D0%BD%D1%8C%D0%BE%D1%80%D1%8B",
				"http://strongholdkingdoms-es.gamepedia.com/Vasallos_y_se%C3%B1ores_feudales",
				"http://strongholdkingdoms-pl.gamepedia.com/Wasale_i_seniorzy",
				"http://strongholdkingdoms-tr.gamepedia.com/Vasallar_ve_S%C3%BCzerenler",
				"http://strongholdkingdoms-it.gamepedia.com/Vassalli_e_feudatari",
				"http://strongholdkingdoms-pt.gamepedia.com/Vassalos_%26_Senhores_feudais",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Parishes_%26_Capitals#Capital_Town",
				"http://strongholdkingdoms-de.gamepedia.com/Gemeinden_%26_Hauptst%C3%A4dte",
				"http://strongholdkingdoms-fr.gamepedia.com/Pr%C3%A9v%C3%B4t%C3%A9s_et_Capitales#Bourg_de_capitale",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%9E%D0%BA%D1%80%D1%83%D0%B3%D0%B0_%D0%B8_%D1%81%D1%82%D0%BE%D0%BB%D0%B8%D1%86%D1%8B",
				"http://strongholdkingdoms-es.gamepedia.com/Parroquias_y_capitales",
				"http://strongholdkingdoms-pl.gamepedia.com/Flagami",
				"http://strongholdkingdoms-tr.gamepedia.com/Pari%C5%9Fler_ve_Ba%C5%9Fkentler",
				"http://strongholdkingdoms-it.gamepedia.com/Distretti_e_capitali",
				"http://strongholdkingdoms-pt.gamepedia.com/Par%C3%B3quias_e_Capitais#Capital",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Parishes_%26_Capitals#Capital_Castle",
				"http://strongholdkingdoms-de.gamepedia.com/Gemeinden_%26_Hauptst%C3%A4dte",
				"http://strongholdkingdoms-fr.gamepedia.com/Pr%C3%A9v%C3%B4t%C3%A9s_et_Capitales#Ch.C3.A2teau_d.27une_capitale",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%9E%D0%BA%D1%80%D1%83%D0%B3%D0%B0_%D0%B8_%D1%81%D1%82%D0%BE%D0%BB%D0%B8%D1%86%D1%8B",
				"http://strongholdkingdoms-es.gamepedia.com/Parroquias_y_capitales",
				"http://strongholdkingdoms-pl.gamepedia.com/Flagami",
				"http://strongholdkingdoms-tr.gamepedia.com/Pari%C5%9Fler_ve_Ba%C5%9Fkentler",
				"http://strongholdkingdoms-it.gamepedia.com/Distretti_e_capitali#Castello_della_capitale",
				"http://strongholdkingdoms-pt.gamepedia.com/Par%C3%B3quias_e_Capitais#Castelo_da_capital",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Resources",
				"http://strongholdkingdoms-de.gamepedia.com/Ressourcen",
				"http://strongholdkingdoms-fr.gamepedia.com/Ressources",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%A0%D0%B5%D1%81%D1%83%D1%80%D1%81%D1%8B",
				"http://strongholdkingdoms-es.gamepedia.com/Recursos",
				"http://strongholdkingdoms-pl.gamepedia.com/Surowce",
				"http://strongholdkingdoms-tr.gamepedia.com/Kaynaklar",
				"http://strongholdkingdoms-it.gamepedia.com/Risorse",
				"http://strongholdkingdoms-pt.gamepedia.com/Recursos",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Parishes_%26_Capitals",
				"http://strongholdkingdoms-de.gamepedia.com/Gemeinden_%26_Hauptst%C3%A4dte",
				"http://strongholdkingdoms-fr.gamepedia.com/Pr%C3%A9v%C3%B4t%C3%A9s_et_Capitales",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%9E%D0%BA%D1%80%D1%83%D0%B3%D0%B0_%D0%B8_%D1%81%D1%82%D0%BE%D0%BB%D0%B8%D1%86%D1%8B",
				"http://strongholdkingdoms-es.gamepedia.com/Parroquias_y_capitales",
				"http://strongholdkingdoms-pl.gamepedia.com/Flagami",
				"http://strongholdkingdoms-tr.gamepedia.com/Pari%C5%9Fler_ve_Ba%C5%9Fkentler",
				"http://strongholdkingdoms-it.gamepedia.com/Capitale",
				"http://strongholdkingdoms-pt.gamepedia.com/Par%C3%B3quias_e_Capitais",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Barracks",
				"http://strongholdkingdoms-de.gamepedia.com/Kaserne",
				"http://strongholdkingdoms-fr.gamepedia.com/Garnison",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%91%D0%B0%D1%80%D0%B0%D0%BA%D0%B8",
				"http://strongholdkingdoms-es.gamepedia.com/Barracas",
				"http://strongholdkingdoms-pl.gamepedia.com/Koszary",
				"http://strongholdkingdoms-tr.gamepedia.com/Pari%C5%9Fler_ve_Ba%C5%9Fkentler",
				"http://strongholdkingdoms-it.gamepedia.com/Guarnigione",
				"http://strongholdkingdoms-pt.gamepedia.com/Quartel",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Parishes_%26_Capitals",
				"http://strongholdkingdoms-de.gamepedia.com/Gemeinden_%26_Hauptst%C3%A4dte",
				"http://strongholdkingdoms-fr.gamepedia.com/Pr%C3%A9v%C3%B4t%C3%A9s_et_Capitales",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%9E%D0%BA%D1%80%D1%83%D0%B3%D0%B0_%D0%B8_%D1%81%D1%82%D0%BE%D0%BB%D0%B8%D1%86%D1%8B",
				"http://strongholdkingdoms-es.gamepedia.com/Parroquias_y_capitales",
				"http://strongholdkingdoms-pl.gamepedia.com/Flagami",
				"http://strongholdkingdoms-tr.gamepedia.com/Pari%C5%9Fler_ve_Ba%C5%9Fkentler",
				"http://strongholdkingdoms-it.gamepedia.com/Capitale",
				"http://strongholdkingdoms-pt.gamepedia.com/Par%C3%B3quias_e_Capitais",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Parishes_%26_Capitals#Voting",
				"http://strongholdkingdoms-de.gamepedia.com/Gemeinden_%26_Hauptst%C3%A4dte#Abstimmen",
				"http://strongholdkingdoms-fr.gamepedia.com/Pr%C3%A9v%C3%B4t%C3%A9s_et_Capitales#.C3.89lection",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%9E%D0%BA%D1%80%D1%83%D0%B3%D0%B0_%D0%B8_%D1%81%D1%82%D0%BE%D0%BB%D0%B8%D1%86%D1%8B",
				"http://strongholdkingdoms-es.gamepedia.com/Parroquias_y_capitales",
				"http://strongholdkingdoms-pl.gamepedia.com/Flagami",
				"http://strongholdkingdoms-tr.gamepedia.com/Pari%C5%9Fler_ve_Ba%C5%9Fkentler",
				"http://strongholdkingdoms-it.gamepedia.com/Capitale#Votare",
				"http://strongholdkingdoms-pt.gamepedia.com/Par%C3%B3quias_e_Capitais",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Communication",
				"http://strongholdkingdoms-de.gamepedia.com/Kommunikation",
				"http://strongholdkingdoms-fr.gamepedia.com/Communication",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%9E%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B5",
				"http://strongholdkingdoms-es.gamepedia.com/Medios_para_comunicarse",
				"http://strongholdkingdoms-pl.gamepedia.com/Czatu",
				"http://strongholdkingdoms-tr.gamepedia.com/%C4%B0leti%C5%9Fim",
				"http://strongholdkingdoms-it.gamepedia.com/Comunicazioni",
				"http://strongholdkingdoms-pt.gamepedia.com/Comunicacao",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Research",
				"http://strongholdkingdoms-de.gamepedia.com/Forschung",
				"http://strongholdkingdoms-fr.gamepedia.com/Recherches",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%98%D1%81%D1%81%D0%BB%D0%B5%D0%B4%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D1%8F",
				"http://strongholdkingdoms-es.gamepedia.com/Investigaci%C3%B3n",
				"http://strongholdkingdoms-pl.gamepedia.com/Badania",
				"http://strongholdkingdoms-tr.gamepedia.com/Ara%C5%9Ft%C4%B1rma",
				"http://strongholdkingdoms-it.gamepedia.com/Ricerca",
				"http://strongholdkingdoms-pt.gamepedia.com/Pesquisar",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Ranks",
				"http://strongholdkingdoms-de.gamepedia.com/Rang",
				"http://strongholdkingdoms-fr.gamepedia.com/Rangs",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%A0%D0%B0%D0%BD%D0%B3%D0%B8",
				"http://strongholdkingdoms-es.gamepedia.com/Niveles",
				"http://strongholdkingdoms-pl.gamepedia.com/Rang",
				"http://strongholdkingdoms-tr.gamepedia.com/Mertebeler",
				"http://strongholdkingdoms-it.gamepedia.com/Ranghi",
				"http://strongholdkingdoms-pt.gamepedia.com/Postos",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Quests",
				"http://strongholdkingdoms-de.gamepedia.com/Quest",
				"http://strongholdkingdoms-fr.gamepedia.com/Qu%C3%AAtes",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%97%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D1%8F",
				"http://strongholdkingdoms-es.gamepedia.com/Misiones",
				"http://strongholdkingdoms-pl.gamepedia.com/Misji",
				"http://strongholdkingdoms-tr.gamepedia.com/G%C3%B6revler",
				"http://strongholdkingdoms-it.gamepedia.com/Missioni",
				"http://strongholdkingdoms-pt.gamepedia.com/Missoes",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Combat",
				"http://strongholdkingdoms-de.gamepedia.com/Kampf",
				"http://strongholdkingdoms-fr.gamepedia.com/Combat",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%91%D0%B8%D1%82%D0%B2%D0%B0",
				"http://strongholdkingdoms-es.gamepedia.com/Combate",
				"http://strongholdkingdoms-pl.gamepedia.com/Walka",
				"http://strongholdkingdoms-tr.gamepedia.com/Muharebe",
				"http://strongholdkingdoms-it.gamepedia.com/Combattimento",
				"http://strongholdkingdoms-pt.gamepedia.com/Combate",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Reports",
				"http://strongholdkingdoms-de.gamepedia.com/Berichte",
				"http://strongholdkingdoms-fr.gamepedia.com/Rapports",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%9E%D1%82%D1%87%D1%91%D1%82%D1%8B",
				"http://strongholdkingdoms-es.gamepedia.com/Informes",
				"http://strongholdkingdoms-pl.gamepedia.com/Raporty",
				"http://strongholdkingdoms-tr.gamepedia.com/Raporlar",
				"http://strongholdkingdoms-it.gamepedia.com/Rapporti",
				"http://strongholdkingdoms-pt.gamepedia.com/Relatorios",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Glory",
				"http://strongholdkingdoms-de.gamepedia.com/Herrlichkeit",
				"http://strongholdkingdoms-fr.gamepedia.com/Gloire",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%A1%D0%BB%D0%B0%D0%B2%D0%B0",
				"http://strongholdkingdoms-es.gamepedia.com/Gloria",
				"http://strongholdkingdoms-pl.gamepedia.com/Punkty_chwa%C5%82y",
				"http://strongholdkingdoms-tr.gamepedia.com/%C5%9Ean",
				"http://strongholdkingdoms-it.gamepedia.com/Gloria",
				"http://strongholdkingdoms-pt.gamepedia.com/Gloria",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Factions_%26_Houses",
				"http://strongholdkingdoms-de.gamepedia.com/H%C3%A4user",
				"http://strongholdkingdoms-fr.gamepedia.com/Maisons",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%A4%D1%80%D0%B0%D0%BA%D1%86%D0%B8%D0%B8_%D0%B8_%D0%94%D0%BE%D0%BC%D0%B0",
				"http://strongholdkingdoms-es.gamepedia.com/Facciones_y_Casas",
				"http://strongholdkingdoms-pl.gamepedia.com/Dom",
				"http://strongholdkingdoms-tr.gamepedia.com/%C4%B0htilaflar_ve_Haneler",
				"http://strongholdkingdoms-it.gamepedia.com/Fazioni_e_casati",
				"http://strongholdkingdoms-pt.gamepedia.com/Faccoes_e_Casas",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Factions_%26_Houses",
				"http://strongholdkingdoms-de.gamepedia.com/H%C3%A4user",
				"http://strongholdkingdoms-fr.gamepedia.com/Maisons",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%A4%D1%80%D0%B0%D0%BA%D1%86%D0%B8%D0%B8_%D0%B8_%D0%94%D0%BE%D0%BC%D0%B0",
				"http://strongholdkingdoms-es.gamepedia.com/Facciones_y_Casas",
				"http://strongholdkingdoms-pl.gamepedia.com/Dom",
				"http://strongholdkingdoms-tr.gamepedia.com/%C4%B0htilaflar_ve_Haneler",
				"http://strongholdkingdoms-it.gamepedia.com/Fazioni_e_casati",
				"http://strongholdkingdoms-pt.gamepedia.com/Faccoes_e_Casas",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Strategy_Cards",
				"http://strongholdkingdoms-de.gamepedia.com/Strategiekarten",
				"http://strongholdkingdoms-fr.gamepedia.com/Cartes_Strat%C3%A9giques",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%A1%D1%82%D1%80%D0%B0%D1%82%D0%B5%D0%B3%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B8%D0%B5_%D0%BA%D0%B0%D1%80%D1%82%D1%8B",
				"http://strongholdkingdoms-es.gamepedia.com/Cartas_de_estrategia",
				"http://strongholdkingdoms-pl.gamepedia.com/Karty_strategiczne",
				"http://strongholdkingdoms-tr.gamepedia.com/%C3%9Ccretsiz_Strateji_Kartlar%C4%B1",
				"http://strongholdkingdoms-it.gamepedia.com/Carte_strategiche",
				"http://strongholdkingdoms-pt.gamepedia.com/Cartas_de_estrategia",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Communication",
				"http://strongholdkingdoms-de.gamepedia.com/Kommunikation",
				"http://strongholdkingdoms-fr.gamepedia.com/Communication",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%9E%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B5",
				"http://strongholdkingdoms-es.gamepedia.com/Medios_para_comunicarse",
				"http://strongholdkingdoms-pl.gamepedia.com/Czatu",
				"http://strongholdkingdoms-tr.gamepedia.com/%C4%B0leti%C5%9Fim",
				"http://strongholdkingdoms-it.gamepedia.com/Comunicazioni",
				"http://strongholdkingdoms-pt.gamepedia.com/Comunicacao",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Communication",
				"http://strongholdkingdoms-de.gamepedia.com/Kommunikation",
				"http://strongholdkingdoms-fr.gamepedia.com/Communication",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%9E%D0%B1%D1%89%D0%B5%D0%BD%D0%B8%D0%B5",
				"http://strongholdkingdoms-es.gamepedia.com/Medios_para_comunicarse",
				"http://strongholdkingdoms-pl.gamepedia.com/Czatu",
				"http://strongholdkingdoms-tr.gamepedia.com/%C4%B0leti%C5%9Fim",
				"http://strongholdkingdoms-it.gamepedia.com/Comunicazioni",
				"http://strongholdkingdoms-pt.gamepedia.com/Comunicacao",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Leaderboard",
				"http://strongholdkingdoms-de.gamepedia.com/Bestenliste",
				"http://strongholdkingdoms-fr.gamepedia.com/Classement",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%A0%D0%B5%D0%B9%D1%82%D0%B8%D0%BD%D0%B3",
				"http://strongholdkingdoms-es.gamepedia.com/Tabla_de_clasificaci%C3%B3n",
				"http://strongholdkingdoms-pl.gamepedia.com/Tablica_wynik%C3%B3w",
				"http://strongholdkingdoms-tr.gamepedia.com/Liderlik_Tablosu",
				"http://strongholdkingdoms-it.gamepedia.com/Classifica",
				"http://strongholdkingdoms-pt.gamepedia.com/Placar_de_Lideres",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Account_Details",
				"http://strongholdkingdoms-de.gamepedia.com/Konten_Einzelheiten",
				"http://strongholdkingdoms-fr.gamepedia.com/Profil_Joueur",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%A3%D1%87%D0%B5%D1%82%D0%BD%D0%B0%D1%8F_%D0%B7%D0%B0%D0%BF%D0%B8%D1%81%D1%8C",
				"http://strongholdkingdoms-es.gamepedia.com/Detalles_de_la_cuenta",
				"http://strongholdkingdoms-pl.gamepedia.com/Szczeg%C3%B3%C5%82y_konta",
				"http://strongholdkingdoms-tr.gamepedia.com/Hesap_Bilgileri",
				"http://strongholdkingdoms-it.gamepedia.com/Dettagli_dell%E2%80%99account",
				"http://strongholdkingdoms-pt.gamepedia.com/Detalhes_da_conta",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Options_%26_Settings",
				"http://strongholdkingdoms-de.gamepedia.com/Optionen/Einstellungen",
				"http://strongholdkingdoms-fr.gamepedia.com/Options",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%9D%D0%B0%D1%81%D1%82%D1%80%D0%BE%D0%B9%D0%BA%D0%B8",
				"http://strongholdkingdoms-es.gamepedia.com/Opciones_y_configuraci%C3%B3n",
				"http://strongholdkingdoms-pl.gamepedia.com/Opcje_i_ustawienia",
				"http://strongholdkingdoms-tr.gamepedia.com/Se%C3%A7enekler_ve_Ayarlar",
				"http://strongholdkingdoms-it.gamepedia.com/Opzioni_e_impostazioni",
				"http://strongholdkingdoms-pt.gamepedia.com/Opcoes_e_configuracoes",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Coat_of_Arms",
				"http://strongholdkingdoms-de.gamepedia.com/Wappen",
				"http://strongholdkingdoms-fr.gamepedia.com/Armoiries",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%A1%D0%BE%D0%B7%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_%D0%B3%D0%B5%D1%80%D0%B1%D0%B0",
				"http://strongholdkingdoms-es.gamepedia.com/Escudo_de_armas",
				"http://strongholdkingdoms-pl.gamepedia.com/Herb",
				"http://strongholdkingdoms-tr.gamepedia.com/Armal%C4%B1_Kalkan",
				"http://strongholdkingdoms-it.gamepedia.com/Blasone",
				"http://strongholdkingdoms-pt.gamepedia.com/Brasao",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Wheel",
				"http://strongholdkingdoms-de.gamepedia.com/Quest_Gl%C3%BCcksrad",
				"http://strongholdkingdoms-fr.gamepedia.com/Roue_des_Qu%C3%AAtes",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%9A%D0%BE%D0%BB%D0%B5%D1%81%D0%BE",
				"http://strongholdkingdoms-es.gamepedia.com/Ruleta",
				"http://strongholdkingdoms-pl.gamepedia.com/Ko%C5%82o",
				"http://strongholdkingdoms-tr.gamepedia.com/%C3%87ark",
				"http://strongholdkingdoms-it.gamepedia.com/Ruota",
				"http://strongholdkingdoms-pt.gamepedia.com/Roda",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Combat",
				"http://strongholdkingdoms-de.gamepedia.com/Kampf",
				"http://strongholdkingdoms-fr.gamepedia.com/Combat",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%91%D0%B8%D1%82%D0%B2%D0%B0",
				"http://strongholdkingdoms-es.gamepedia.com/Combate",
				"http://strongholdkingdoms-pl.gamepedia.com/Walki",
				"http://strongholdkingdoms-tr.gamepedia.com/Muharebe",
				"http://strongholdkingdoms-it.gamepedia.com/Combattimento",
				"http://strongholdkingdoms-pt.gamepedia.com/Combate",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Scouts",
				"http://strongholdkingdoms-de.gamepedia.com/Kundschafter",
				"http://strongholdkingdoms-fr.gamepedia.com/Eclaireurs",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%A0%D0%B0%D0%B7%D0%B2%D0%B5%D0%B4%D0%BA%D0%B0",
				"http://strongholdkingdoms-es.gamepedia.com/Exploradores",
				"http://strongholdkingdoms-pl.gamepedia.com/Zwiadu",
				"http://strongholdkingdoms-tr.gamepedia.com/Ke%C5%9Fif_Erleri",
				"http://strongholdkingdoms-it.gamepedia.com/Esploratori",
				"http://strongholdkingdoms-pt.gamepedia.com/Batedores",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Monks",
				"http://strongholdkingdoms-de.gamepedia.com/M%C3%B6nche",
				"http://strongholdkingdoms-fr.gamepedia.com/Moine",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%9C%D0%BE%D0%BD%D0%B0%D1%85",
				"http://strongholdkingdoms-es.gamepedia.com/Monjes",
				"http://strongholdkingdoms-pl.gamepedia.com/Mnichom",
				"http://strongholdkingdoms-tr.gamepedia.com/Ke%C5%9Fi%C5%9Fler",
				"http://strongholdkingdoms-it.gamepedia.com/Monaco",
				"http://strongholdkingdoms-pt.gamepedia.com/Monges",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Trading",
				"http://strongholdkingdoms-de.gamepedia.com/Handel",
				"http://strongholdkingdoms-fr.gamepedia.com/Commerce",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%9F%D1%80%D0%B5%D0%BC%D0%B8%D1%83%D0%BC-%D0%B6%D0%B5%D1%82%D0%BE%D0%BD%D1%8B",
				"http://strongholdkingdoms-es.gamepedia.com/Comerciar",
				"http://strongholdkingdoms-pl.gamepedia.com/Handel",
				"http://strongholdkingdoms-tr.gamepedia.com/Ticaret",
				"http://strongholdkingdoms-it.gamepedia.com/Commercio",
				"http://strongholdkingdoms-pt.gamepedia.com/Comercio",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Premium_Tokens",
				"http://strongholdkingdoms-de.gamepedia.com/Premium-Token",
				"http://strongholdkingdoms-fr.gamepedia.com/Jetons_Premium",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%9F%D1%80%D0%B5%D0%BC%D0%B8%D1%83%D0%BC-%D0%B6%D0%B5%D1%82%D0%BE%D0%BD%D1%8B",
				"http://strongholdkingdoms-es.gamepedia.com/Vales_Premium",
				"http://strongholdkingdoms-pl.gamepedia.com/Premium",
				"http://strongholdkingdoms-tr.gamepedia.com/Premium_Token",
				"http://strongholdkingdoms-it.gamepedia.com/Gettoni_Premium",
				"http://strongholdkingdoms-pt.gamepedia.com/Fichas_premio",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Firefly_Crowns",
				"http://strongholdkingdoms-de.gamepedia.com/Firefly-Kronen",
				"http://strongholdkingdoms-fr.gamepedia.com/Couronne",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%9A%D1%80%D0%BE%D0%BD%D1%8B_Firefly",
				"http://strongholdkingdoms-es.gamepedia.com/Coronas_Firefly",
				"http://strongholdkingdoms-pl.gamepedia.com/Korony",
				"http://strongholdkingdoms-tr.gamepedia.com/Firefly_Sikkeleri",
				"http://strongholdkingdoms-it.gamepedia.com/Corone_Firefly",
				"http://strongholdkingdoms-pt.gamepedia.com/Coroas_Firefly",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Strategy_Cards",
				"http://strongholdkingdoms-de.gamepedia.com/Strategiekarten",
				"http://strongholdkingdoms-fr.gamepedia.com/Cartes_Strat%C3%A9giques",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%A1%D1%82%D1%80%D0%B0%D1%82%D0%B5%D0%B3%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B8%D0%B5_%D0%BA%D0%B0%D1%80%D1%82%D1%8B",
				"http://strongholdkingdoms-es.gamepedia.com/Cartas_de_estrategia",
				"http://strongholdkingdoms-pl.gamepedia.com/Karty_strategiczne",
				"http://strongholdkingdoms-tr.gamepedia.com/Strateji_Kartlar%C4%B1",
				"http://strongholdkingdoms-it.gamepedia.com/Carte_strategiche",
				"http://strongholdkingdoms-pt.gamepedia.com/Cartas_de_estrategia",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Strategy_Cards",
				"http://strongholdkingdoms-de.gamepedia.com/Strategiekarten",
				"http://strongholdkingdoms-fr.gamepedia.com/Cartes_Strat%C3%A9giques",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%A1%D1%82%D1%80%D0%B0%D1%82%D0%B5%D0%B3%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B8%D0%B5_%D0%BA%D0%B0%D1%80%D1%82%D1%8B",
				"http://strongholdkingdoms-es.gamepedia.com/Cartas_de_estrategia",
				"http://strongholdkingdoms-pl.gamepedia.com/Karty_strategiczne",
				"http://strongholdkingdoms-tr.gamepedia.com/Strateji_Kartlar%C4%B1",
				"http://strongholdkingdoms-it.gamepedia.com/Carte_strategiche",
				"http://strongholdkingdoms-pt.gamepedia.com/Cartas_de_estrategia",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Premium_Tokens",
				"http://strongholdkingdoms-de.gamepedia.com/Premium-Token",
				"http://strongholdkingdoms-fr.gamepedia.com/Jetons_Premium",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%9F%D1%80%D0%B5%D0%BC%D0%B8%D1%83%D0%BC-%D0%B6%D0%B5%D1%82%D0%BE%D0%BD%D1%8B",
				"http://strongholdkingdoms-es.gamepedia.com/Vales_Premium",
				"http://strongholdkingdoms-pl.gamepedia.com/Premium",
				"http://strongholdkingdoms-tr.gamepedia.com/Premium_Token",
				"http://strongholdkingdoms-it.gamepedia.com/Gettoni_Premium",
				"http://strongholdkingdoms-pt.gamepedia.com/Fichas_premio",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Donate_to_Parish",
				"http://strongholdkingdoms-de.gamepedia.com/Ressourcen_an_die_Hauptstadt_spenden",
				"http://strongholdkingdoms-fr.gamepedia.com/Donation_%C3%A0_la_Pr%C3%A9v%C3%B4t%C3%A9",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%9F%D0%BE%D0%B6%D0%B5%D1%80%D1%82%D0%B2%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D1%8F_%D0%B2_%D0%BE%D0%BA%D1%80%D1%83%D0%B3",
				"http://strongholdkingdoms-es.gamepedia.com/Donar_a_la_parroquia",
				"http://strongholdkingdoms-pl.gamepedia.com/Datki_na_rzecz_gminy",
				"http://strongholdkingdoms-tr.gamepedia.com/Pari%C5%9F%27e_Ba%C4%9F%C4%B1%C5%9F",
				"http://strongholdkingdoms-it.gamepedia.com/Donazioni_al_distretto",
				"http://strongholdkingdoms-pt.gamepedia.com/Doe_a_paroquia",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Villages_Overview",
				"http://strongholdkingdoms-de.gamepedia.com/Dorf%C3%BCbersichtsanzeige",
				"http://strongholdkingdoms-fr.gamepedia.com/Vue_d%27Ensemble_Village",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%9E%D0%B1%D0%B7%D0%BE%D1%80_%D0%B4%D0%B5%D1%80%D0%B5%D0%B2%D0%BD%D0%B8",
				"http://strongholdkingdoms-es.gamepedia.com/Vistazo_general_de_las_aldeas",
				"http://strongholdkingdoms-pl.gamepedia.com/Przegl%C4%85d_wiosek",
				"http://strongholdkingdoms-tr.gamepedia.com/K%C3%B6ylere_genel_bak%C4%B1%C5%9F",
				"http://strongholdkingdoms-it.gamepedia.com/Quadro_dei_villaggi",
				"http://strongholdkingdoms-pt.gamepedia.com/Visao_geral_das_aldeias",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Achievements",
				"http://strongholdkingdoms-de.gamepedia.com/Errungenschaften",
				"http://strongholdkingdoms-fr.gamepedia.com/Ach%C3%A8vements",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%94%D0%BE%D1%81%D1%82%D0%B8%D0%B6%D0%B5%D0%BD%D0%B8%D1%8F",
				"http://strongholdkingdoms-es.gamepedia.com/Logros",
				"http://strongholdkingdoms-pl.gamepedia.com/Osi%C4%85gni%C4%99cie",
				"http://strongholdkingdoms-tr.gamepedia.com/Ba%C5%9Far%C4%B1lar",
				"http://strongholdkingdoms-it.gamepedia.com/Imprese",
				"http://strongholdkingdoms-pt.gamepedia.com/Conquistas",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/The_Second_Age",
				"http://strongholdkingdoms-de.gamepedia.com/Die_Zweite_Epoche",
				"http://strongholdkingdoms-fr.gamepedia.com/Deuxi%C3%A8me_%C3%88re",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%92%D1%82%D0%BE%D1%80%D0%B0%D1%8F_%D0%AD%D0%BF%D0%BE%D1%85%D0%B0",
				"http://strongholdkingdoms-es.gamepedia.com/La_segunda_edad",
				"http://strongholdkingdoms-pl.gamepedia.com/Druga_Epoka",
				"http://strongholdkingdoms-tr.gamepedia.com/%C4%B0kinci_%C3%87a%C4%9F",
				"http://strongholdkingdoms-it.gamepedia.com/La_Seconda_Epoca",
				"http://strongholdkingdoms-pt.gamepedia.com/A_Segunda_Era",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/The_Third_Age",
				"http://strongholdkingdoms-de.gamepedia.com/Die_Dritte_Epoche",
				"http://strongholdkingdoms-fr.gamepedia.com/Troisi%C3%A8me_%C3%88re",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%A2%D1%80%D0%B5%D1%82%D1%8C%D1%8F_%D0%AD%D0%BF%D0%BE%D1%85%D0%B0",
				"http://strongholdkingdoms-es.gamepedia.com/La_tercera_edad",
				"http://strongholdkingdoms-pl.gamepedia.com/Trzecia_Epoka",
				"http://strongholdkingdoms-tr.gamepedia.com/%C3%9C%C3%A7%C3%BCnc%C3%BC_%C3%87a%C4%9F",
				"http://strongholdkingdoms-it.gamepedia.com/La_Terza_Epoca",
				"http://strongholdkingdoms-pt.gamepedia.com/A_Terceira_Era",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Domination_World_4",
				"http://strongholdkingdoms-de.gamepedia.com/Domination_Welt_4",
				"http://strongholdkingdoms-fr.gamepedia.com/Monde_de_Domination_4",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%9C%D0%B8%D1%80_Domination_4",
				"http://strongholdkingdoms-es.gamepedia.com/Mundo_Domination_4",
				"http://strongholdkingdoms-pl.gamepedia.com/%C5%9Awiat_Domination_4",
				"http://strongholdkingdoms-tr.gamepedia.com/Domination_D%C3%BCnyas%C4%B1_4",
				"http://strongholdkingdoms-it.gamepedia.com/Mondo_Domination_4",
				"http://strongholdkingdoms-pt.gamepedia.com/Mundo_Domina%C3%A7%C3%A3o_4",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/The_Fourth_Age",
				"http://strongholdkingdoms-de.gamepedia.com/Die_Vierte_Epoche",
				"http://strongholdkingdoms-fr.gamepedia.com/Quatri%C3%A8me_%C3%88re",
				"http://strongholdkingdoms-ru.gamepedia.com/Четвёртая_Эпоха",
				"http://strongholdkingdoms-es.gamepedia.com/La_cuarta_edad",
				"http://strongholdkingdoms-pl.gamepedia.com/Czwarta_Epoka",
				"http://strongholdkingdoms-tr.gamepedia.com/Dorduncu_Cag",
				"http://strongholdkingdoms-it.gamepedia.com/La_Quarta_Epoca",
				"http://strongholdkingdoms-pt.gamepedia.com/A_Quarta_Era",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Treasure_Castle",
				"http://strongholdkingdoms-de.gamepedia.com/Schatzburg",
				"http://strongholdkingdoms-fr.gamepedia.com/Ch%C3%A2teau_au_Tr%C3%A9sor",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%97%D0%B0%D0%BC%D0%BA%D0%B8_%D1%81_%D1%81%D0%BE%D0%BA%D1%80%D0%BE%D0%B2%D0%B8%D1%89%D0%B0%D0%BC%D0%B8",
				"http://strongholdkingdoms-es.gamepedia.com/Castillo_del_tesoro",
				"http://strongholdkingdoms-pl.gamepedia.com/Zamki_ze_skarbami",
				"http://strongholdkingdoms-tr.gamepedia.com/Define_Kaleleri",
				"http://strongholdkingdoms-it.gamepedia.com/Castello_del_tesoro",
				"http://strongholdkingdoms-pt.gamepedia.com/Castelos_de_Tesouro",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Paladin_Castles",
				"http://strongholdkingdoms-de.gamepedia.com/Burg_des_Paladins",
				"http://strongholdkingdoms-fr.gamepedia.com/Ch%C3%A2teau_du_Paladin",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%97%D0%B0%D0%BC%D0%BE%D0%BA_%D0%9F%D0%B0%D0%BB%D0%B0%D0%B4%D0%B8%D0%BD%D0%B0",
				"http://strongholdkingdoms-es.gamepedia.com/Castillos_de_Palad%C3%ADn",
				"http://strongholdkingdoms-pl.gamepedia.com/Zamek_Paladyna",
				"http://strongholdkingdoms-tr.gamepedia.com/Paladin_Kaleleri",
				"http://strongholdkingdoms-it.gamepedia.com/Castello_del_Paladino",
				"http://strongholdkingdoms-pt.gamepedia.com/Castelo_do_paladino",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/The_Fifth_Age",
				"http://strongholdkingdoms-de.gamepedia.com/Die_F%C3%BCnfte_Epoche",
				"http://strongholdkingdoms-fr.gamepedia.com/Cinqui%C3%A8me_Ere",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%9F%D1%8F%D1%82%D0%B0%D1%8F_%D0%AD%D0%BF%D0%BE%D1%85%D0%B0",
				"http://strongholdkingdoms-es.gamepedia.com/La_quinta_edad",
				"http://strongholdkingdoms-pl.gamepedia.com/Piata_Epoka",
				"http://strongholdkingdoms-tr.gamepedia.com/Besinci_Cag",
				"http://strongholdkingdoms-it.gamepedia.com/La_quinta_epoca",
				"http://strongholdkingdoms-pt.gamepedia.com/Quinta_Era",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/The_Sixth_Age",
				"http://strongholdkingdoms-de.gamepedia.com/Die_Sechste_Epoche",
				"http://strongholdkingdoms-fr.gamepedia.com/Sixieme_Ere",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%A8%D0%B5%D1%81%D1%82%D0%B0%D1%8F_%D0%AD%D0%BF%D0%BE%D1%85%D0%B0",
				"http://strongholdkingdoms-es.gamepedia.com/La_Sexta_Edad",
				"http://strongholdkingdoms-pl.gamepedia.com/Szosta_Epoka",
				"http://strongholdkingdoms-tr.gamepedia.com/Alt?nc?_Cag",
				"http://strongholdkingdoms-it.gamepedia.com/La_Sesta_Epoca",
				"http://strongholdkingdoms-pt.gamepedia.com/A_Sexta_Era",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/The_Final_Age",
				"http://strongholdkingdoms-de.gamepedia.com/Die_Letzte_Epoche",
				"http://strongholdkingdoms-fr.gamepedia.com/Ere_Finalee",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%9F%D0%BE%D1%81%D0%BB%D0%B5%D0%B4%D0%BD%D1%8F%D1%8F_%D0%AD%D0%BF%D0%BE%D1%85%D0%B0",
				"http://strongholdkingdoms-es.gamepedia.com/La_Edad_Final",
				"http://strongholdkingdoms-pl.gamepedia.com/Ostatnia_Epoka",
				"http://strongholdkingdoms-tr.gamepedia.com/Son_Cag",
				"http://strongholdkingdoms-it.gamepedia.com/L'Epoca_Finale",
				"http://strongholdkingdoms-pt.gamepedia.com/A_Era_Final",
				"",
				"",
				"http://strongholdkingdoms.gamepedia.com/Royal_Towers",
				"http://strongholdkingdoms-de.gamepedia.com/K%C3%B6nigliche_T%C3%BCrme",
				"http://strongholdkingdoms-fr.gamepedia.com/Tours_Royales",
				"http://strongholdkingdoms-ru.gamepedia.com/%D0%9A%D0%BE%D1%80%D0%BE%D0%BB%D0%B5%D0%B2%D1%81%D0%BA%D0%B0%D1%8F_%D0%91%D0%B0%D1%88%D0%BD%D1%8F",
				"http://strongholdkingdoms-es.gamepedia.com/Torres_Reales",
				"http://strongholdkingdoms-pl.gamepedia.com/Krolewska_Wieza",
				"http://strongholdkingdoms-tr.gamepedia.com/Kraliyet_Kuleleri",
				"http://strongholdkingdoms-it.gamepedia.com/Torri_Reali",
				"http://strongholdkingdoms-pt.gamepedia.com/Torres_Reais",
				"",
				"",
				"https://strongholdkingdoms.gamepedia.com/Eras",
				"https://strongholdkingdoms-de.gamepedia.com/%C3%84ra",
				"https://strongholdkingdoms-fr.gamepedia.com/Epoques",
				"https://strongholdkingdoms-ru.gamepedia.com/%D0%AD%D1%80%D0%B0",
				"https://strongholdkingdoms-es.gamepedia.com/Eras",
				"https://strongholdkingdoms-pl.gamepedia.com/Ery",
				"https://strongholdkingdoms.gamepedia.com/Eras",
				"https://strongholdkingdoms.gamepedia.com/Eras",
				"https://strongholdkingdoms.gamepedia.com/Eras",
				"",
				""
			};
		}

		// Token: 0x02000188 RID: 392
		public class ParishChatPanel : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x1700010A RID: 266
			// (get) Token: 0x06000F2C RID: 3884 RVA: 0x00010FD8 File Offset: 0x0000F1D8
			public bool Locked
			{
				get
				{
					return this.locked;
				}
			}

			// Token: 0x1700010B RID: 267
			// (set) Token: 0x06000F2D RID: 3885 RVA: 0x00010FE0 File Offset: 0x0000F1E0
			public bool Repopulate
			{
				set
				{
					this.repopulate = value;
				}
			}

			// Token: 0x06000F2E RID: 3886 RVA: 0x001031B8 File Offset: 0x001013B8
			public void reset(ParishWallPanel parent, int id)
			{
				this.m_parent = parent;
				this.m_id = id;
				this.currentText.Clear();
				this.currentChatHeight = 0;
				this.clearControls();
				this.locked = false;
				this.allowBackFill = true;
				if (id == 3)
				{
					this.locked = true;
				}
			}

			// Token: 0x06000F2F RID: 3887 RVA: 0x00010FE9 File Offset: 0x0000F1E9
			public void setAsSteward()
			{
				this.locked = false;
			}

			// Token: 0x06000F30 RID: 3888 RVA: 0x00103204 File Offset: 0x00101404
			public void setUnreads(int numUnread)
			{
				string text = "";
				switch (this.m_id)
				{
				case 0:
					text = SK.Text("ParishWallPanel_General", "General");
					break;
				case 1:
					text = SK.Text("ParishWallPanel_War", "War");
					break;
				case 2:
					text = SK.Text("ParishWallPanel_inn", "Inn");
					break;
				case 3:
					text = SK.Text("ParishWallPanel_Steward", "Steward");
					break;
				case 4:
					text = SK.Text("GENERIC_Parish", "Parish");
					break;
				case 5:
					text = SK.Text("MENU_Help", "Help");
					break;
				}
				if (numUnread > 0)
				{
					text = text + " (" + numUnread.ToString() + ")";
				}
				this.m_parent.setTabText(this.m_id, text);
			}

			// Token: 0x06000F31 RID: 3889 RVA: 0x001032D8 File Offset: 0x001014D8
			public void importText(Chat_TextEntry[] newText, bool backFill, long deleteID)
			{
				int num = newText.Length;
				if (num == 0 && !this.repopulate && !backFill && deleteID < 0L)
				{
					return;
				}
				this.repopulate = false;
				if (backFill && num == 0)
				{
					this.allowBackFill = false;
				}
				if (deleteID >= 0L)
				{
					this.allowBackFill = true;
					for (int i = 0; i < this.currentText.Count; i++)
					{
						if (this.currentText[i].textID == deleteID)
						{
							this.currentText.Remove(this.currentText[i]);
							break;
						}
					}
				}
				else if (!backFill)
				{
					List<Chat_TextEntry> list = new List<Chat_TextEntry>();
					list.AddRange(newText);
					list.AddRange(this.currentText);
					this.currentText = list;
				}
				else
				{
					this.currentText.AddRange(newText);
					num = 0;
				}
				if (this.currentText.Count > 150)
				{
					this.currentText.RemoveRange(150, this.currentText.Count - 150);
				}
				int num2 = this.chatScrollBar.Value;
				bool flag = false;
				if (this.chatScrollArea.Y == 0)
				{
					flag = true;
				}
				this.clearControls();
				this.chatScrollArea.Position = new Point(0, 0);
				this.chatScrollArea.Size = new Size(base.Width - 60, base.Height);
				this.chatScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(base.Width - 60, base.Height));
				base.addControl(this.chatScrollArea);
				this.chatScrollBar.Visible = false;
				this.chatScrollBar.Position = new Point(base.Width - 26, 0);
				this.chatScrollBar.Size = new Size(24, base.Height);
				base.addControl(this.chatScrollBar);
				this.chatScrollBar.Value = 0;
				this.chatScrollBar.Max = 100;
				this.chatScrollBar.NumVisibleLines = 25;
				this.chatScrollBar.Create(null, null, null, GFXLibrary._24wide_thumb_top, GFXLibrary._24wide_thumb_middle, GFXLibrary._24wide_thumb_bottom);
				this.chatScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.chatScrollBarMoved));
				int num3 = 0;
				int num4 = 0;
				int num5 = 0;
				foreach (Chat_TextEntry textEntry in this.currentText)
				{
					CustomSelfDrawPanel.ParishWallChatEntry parishWallChatEntry = new CustomSelfDrawPanel.ParishWallChatEntry();
					parishWallChatEntry.Position = new Point(0, num3);
					parishWallChatEntry.init(textEntry, this.m_parent);
					this.chatScrollArea.addControl(parishWallChatEntry);
					num3 += parishWallChatEntry.Height;
					this.currentChatHeight += parishWallChatEntry.Height;
					if (num4 < this.currentText.Count - 1 || this.allowBackFill)
					{
						CustomSelfDrawPanel.CSDImage csdimage = new CustomSelfDrawPanel.CSDImage();
						csdimage.Image = GFXLibrary.parishwall_dividing_line;
						csdimage.Position = new Point(0, num3 + 3);
						this.chatScrollArea.addControl(csdimage);
						num3 += 10;
					}
					if (num4 + 1 == num)
					{
						num5 = num3;
					}
					num4++;
				}
				if (this.allowBackFill)
				{
					this.oldMessagesLabel.Text = SK.Text("ParishWallPanel_Older_Messages", "Older Messages");
					this.oldMessagesLabel.Color = global::ARGBColors.Blue;
					this.oldMessagesLabel.Position = new Point(63, num3 + 3);
					this.oldMessagesLabel.Size = new Size(405, 30);
					this.oldMessagesLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
					this.oldMessagesLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
					this.oldMessagesLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.downloadOlderMessages), "ParishChatPanel_view_older_messages");
					this.oldMessagesLabel.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.oldMessagesOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.oldMessagesLeave));
					this.oldMessagesLabel.Enabled = true;
					this.chatScrollArea.addControl(this.oldMessagesLabel);
					num3 += 25;
				}
				this.chatScrollArea.Size = new Size(this.chatScrollArea.Width, num3);
				if (num3 < this.chatScrollBar.Height)
				{
					this.chatScrollBar.Visible = false;
				}
				else
				{
					this.chatScrollBar.Visible = true;
					this.chatScrollBar.NumVisibleLines = this.chatScrollBar.Height;
					this.chatScrollBar.Max = num3 - this.chatScrollBar.Height;
				}
				this.chatScrollArea.invalidate();
				this.chatScrollBar.invalidate();
				if (this.m_parent != null)
				{
					this.m_parent.Invalidate();
				}
				if (flag)
				{
					return;
				}
				num2 += num5;
				if (num2 > 0 && this.chatScrollBar.Visible)
				{
					if (num2 >= this.chatScrollBar.Max)
					{
						num2 = this.chatScrollBar.Max;
					}
					this.chatScrollBar.Value = num2;
					this.chatScrollBarMoved();
				}
			}

			// Token: 0x06000F32 RID: 3890 RVA: 0x001037DC File Offset: 0x001019DC
			private void chatScrollBarMoved()
			{
				int value = this.chatScrollBar.Value;
				this.chatScrollArea.Position = new Point(this.chatScrollArea.X, -value);
				this.chatScrollArea.ClipRect = new Rectangle(this.chatScrollArea.ClipRect.X, value, this.chatScrollArea.ClipRect.Width, this.chatScrollArea.ClipRect.Height);
				this.chatScrollArea.invalidate();
				this.chatScrollBar.invalidate();
			}

			// Token: 0x06000F33 RID: 3891 RVA: 0x00010FF2 File Offset: 0x0000F1F2
			public void scrollToBottom()
			{
				this.chatScrollBar.Value = 0;
				this.chatScrollBarMoved();
			}

			// Token: 0x06000F34 RID: 3892 RVA: 0x00011006 File Offset: 0x0000F206
			public void downloadOlderMessages()
			{
				if (this.m_parent != null)
				{
					this.m_parent.backfillPage(this.m_id);
					this.oldMessagesLabel.Enabled = false;
					this.oldMessagesLeave();
				}
			}

			// Token: 0x06000F35 RID: 3893 RVA: 0x00011033 File Offset: 0x0000F233
			public void oldMessagesOver()
			{
				this.oldMessagesLabel.Color = global::ARGBColors.Aquamarine;
			}

			// Token: 0x06000F36 RID: 3894 RVA: 0x00011045 File Offset: 0x0000F245
			public void oldMessagesLeave()
			{
				this.oldMessagesLabel.Color = global::ARGBColors.Blue;
			}

			// Token: 0x06000F37 RID: 3895 RVA: 0x00011057 File Offset: 0x0000F257
			public void freeOldMessagesButton()
			{
				this.oldMessagesLabel.Enabled = true;
			}

			// Token: 0x040012DE RID: 4830
			private List<Chat_TextEntry> currentText = new List<Chat_TextEntry>();

			// Token: 0x040012DF RID: 4831
			private int currentChatHeight;

			// Token: 0x040012E0 RID: 4832
			private ParishWallPanel m_parent;

			// Token: 0x040012E1 RID: 4833
			private int m_id = -1;

			// Token: 0x040012E2 RID: 4834
			private bool locked;

			// Token: 0x040012E3 RID: 4835
			private bool repopulate;

			// Token: 0x040012E4 RID: 4836
			private bool allowBackFill = true;

			// Token: 0x040012E5 RID: 4837
			private CustomSelfDrawPanel.CSDVertScrollBar chatScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

			// Token: 0x040012E6 RID: 4838
			private CustomSelfDrawPanel.CSDArea chatScrollArea = new CustomSelfDrawPanel.CSDArea();

			// Token: 0x040012E7 RID: 4839
			private CustomSelfDrawPanel.CSDLabel oldMessagesLabel = new CustomSelfDrawPanel.CSDLabel();
		}

		// Token: 0x02000189 RID: 393
		public class ParishWallEntry : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06000F39 RID: 3897 RVA: 0x001038C4 File Offset: 0x00101AC4
			public void init(WallInfo wallInfo, int lineID, int villageID, CustomSelfDrawPanel window)
			{
				this.m_parent = window;
				this.m_villageID = villageID;
				this.m_lineID = lineID;
				this.m_wallInfo = wallInfo;
				this.clearControls();
				if ((lineID & 1) == 0)
				{
					this.backgroundImage.Image = GFXLibrary.parishwall_tan_bar_01;
				}
				else
				{
					this.backgroundImage.Image = GFXLibrary.parishwall_tan_bar_02;
				}
				this.backgroundImage.Position = new Point(0, 0);
				this.backgroundImage.setClickDelegate(null);
				this.backgroundImage.setMouseOverDelegate(null, null);
				base.addControl(this.backgroundImage);
				this.Size = this.backgroundImage.Size;
				this.shieldImage.Image = GameEngine.Instance.World.getWorldShield(wallInfo.userID, 32, 36);
				this.shieldImage.Position = new Point(10, 5);
				this.backgroundImage.addControl(this.shieldImage);
				this.playerName.Text = wallInfo.username;
				this.playerName.Color = global::ARGBColors.Black;
				this.playerName.Position = new Point(60, 4);
				this.playerName.Size = new Size(214, 16);
				this.playerName.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				this.playerName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.playerName.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.playerClicked), "ParishChatPanel_user");
				this.playerName.Data = wallInfo.userID;
				this.playerName.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.playerOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.playerLeave));
				this.backgroundImage.addControl(this.playerName);
				Graphics graphics = window.CreateGraphics();
				Size size = graphics.MeasureString(wallInfo.username, this.playerName.Font, 214).ToSize();
				this.playerName.Size = new Size(size.Width + 5, 16);
				graphics.Dispose();
				this.effectText.Text = "";
				this.effectText.Color = Color.FromArgb(38, 77, 0);
				this.effectText.Position = new Point(60, 19);
				this.effectText.Size = new Size(214, 28);
				this.effectText.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				this.effectText.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.backgroundImage.addControl(this.effectText);
				int num = -1;
				switch (wallInfo.entryType)
				{
				case 1:
					this.effectText.Text = SK.Text("ParishWallPanel_Donates_Goods", "Donates Goods");
					num = 2;
					this.backgroundImage.Data = wallInfo.entryType;
					this.backgroundImage.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.overDonate), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.leaveDonate));
					this.backgroundImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickDonate), "ParishChatPanel_donate_popup");
					break;
				case 2:
					this.effectText.Text = SK.Text("ParishWallPanel_Upgrades", "Upgrades") + " : " + VillageBuildingsData.getBuildingName(wallInfo.data1);
					this.effectImage.Image = this.getCapitalBuildingImage(wallInfo.data1);
					this.effectImage.Size = new Size(60, 60);
					this.effectImage.Position = new Point(272, -7);
					this.backgroundImage.addControl(this.effectImage);
					break;
				case 10:
					this.effectText.Text = SK.Text("ParishWallPanel_Destroys_Bandit_Camp", "Destroys a Bandit Camp");
					num = 3;
					break;
				case 11:
					this.effectText.Text = SK.Text("ParishWallPanel_Destroys_Wolf_Lair", "Destroys a Wolf Lair");
					num = 1;
					break;
				case 12:
					this.effectText.Text = SK.Text("ParishWallPanel_Defeats_rat", "Defeats the Rat");
					num = 12;
					break;
				case 13:
					this.effectText.Text = SK.Text("ParishWallPanel_Defeats_Snake", "Defeats the Snake");
					num = 12;
					break;
				case 14:
					this.effectText.Text = SK.Text("ParishWallPanel_Defeats_Pig", "Defeats the Pig");
					num = 12;
					break;
				case 15:
					this.effectText.Text = SK.Text("Defeats_Wolf", "Defeats the Wolf");
					num = 12;
					break;
				case 16:
					this.effectText.Text = SK.Text("Defeats_Paladin", "Defeats Paladin's Castle");
					num = 14;
					break;
				case 17:
					this.effectText.Text = SK.Text("Defeats_Paladin", "Defeats Paladin's Castle");
					num = 14;
					break;
				case 18:
					this.effectText.Text = SK.Text("Defeats_Treasure_Castle", "Defeats a Treasure Castle");
					num = 15;
					break;
				case 20:
					this.effectText.Text = SK.Text("ParishWallPanel_Attacks_Bandit_Camp", "Attacks a Bandit Camp");
					num = 3;
					break;
				case 21:
					this.effectText.Text = SK.Text("ParishWallPanel_Attacks_Wolf_Lair", "Attacks a Wolf Lair");
					num = 1;
					break;
				case 22:
					this.effectText.Text = SK.Text("ParishWallPanel_Attacks_Rat", "Attacks the Rat");
					num = 12;
					break;
				case 23:
					this.effectText.Text = SK.Text("ParishWallPanel_Attacks_Snake", "Attacks the Snake");
					num = 12;
					break;
				case 24:
					this.effectText.Text = SK.Text("ParishWallPanel_Attacks_Pig", "Attacks the Pig");
					num = 12;
					break;
				case 25:
					this.effectText.Text = SK.Text("ParishWallPanel_Attacks_Wolf", "Attacks the Wolf");
					num = 12;
					break;
				case 26:
					this.effectText.Text = SK.Text("ParishWallPanel_Attacks_Paladin", "Attacks Paladin's Castle");
					num = 14;
					break;
				case 27:
					this.effectText.Text = SK.Text("ParishWallPanel_Attacks_Paladin", "Attacks Paladin's Castle");
					num = 14;
					break;
				case 28:
					this.effectText.Text = SK.Text("ParishWallPanel__Treasure_Castle", "Attacks a Treasure Castle");
					num = 15;
					break;
				case 30:
					this.effectText.Text = SK.Text("ParishWallPanel_Capture_Flag", "Captures a Flag");
					num = 4;
					break;
				case 31:
					this.effectText.Text = SK.Text("ParishWallPanel_Taken_Flag", "Taken Flag");
					num = 5;
					break;
				case 40:
					this.effectText.Text = SK.Text("ParishWallPanel_Blesses", "Blesses the Parish");
					num = 7;
					break;
				case 42:
					this.effectText.Text = SK.Text("ParishWallPanel_Influences", "Influences Election");
					num = 7;
					break;
				case 43:
					this.effectText.Text = SK.Text("ParishWallPanel_Inquisition", "Inquisitions the Parish");
					num = 7;
					break;
				case 44:
					this.effectText.Text = SK.Text("ParishWallPanel_Heals", "Heals some disease in the parish");
					num = 7;
					break;
				case 50:
					this.effectText.Text = SK.Text("ParishWallPanel_Joins_Parish", "Joins the Parish");
					num = 8;
					break;
				case 51:
					this.effectText.Text = SK.Text("ParishWallPanel_Promotes_To", "Promotes To") + " : " + Rankings.getRankingName(wallInfo.data1, wallInfo.data2 == 0);
					num = 0;
					break;
				case 52:
					this.effectText.Text = SK.Text("ParishWallPanel_Becomes_Steward", "Becomes Steward");
					num = 13;
					break;
				case 53:
					this.effectText.Text = SK.Text("ParishWallPanel_Becomes_Sheriff", "Becomes Sheriff");
					num = 13;
					break;
				case 54:
					this.effectText.Text = SK.Text("ParishWallPanel_Becomes_Governor", "Becomes Governor");
					num = 13;
					break;
				case 55:
					this.effectText.Text = SK.Text("ParishWallPanel_Becomes_King", "Becomes King");
					num = 13;
					break;
				}
				if (num >= 0)
				{
					this.effectImage.Image = GFXLibrary.parishwall_village_center_achievement_icons[num];
					this.effectImage.Position = new Point(274, -5);
					this.backgroundImage.addControl(this.effectImage);
				}
			}

			// Token: 0x06000F3A RID: 3898 RVA: 0x00104194 File Offset: 0x00102394
			public BaseImage getCapitalBuildingImage(int buildingType)
			{
				BaseImage result = null;
				switch (buildingType)
				{
				case 79:
					result = GFXLibrary.townbuilding_Woodcutter_normal;
					break;
				case 80:
					result = GFXLibrary.townbuilding_stonequarry_normal;
					break;
				case 81:
					result = GFXLibrary.townbuilding_iron_normal;
					break;
				case 82:
					result = GFXLibrary.townbuilding_pitch_normal;
					break;
				case 83:
					result = GFXLibrary.townbuilding_ale_normal;
					break;
				case 84:
					result = GFXLibrary.townbuilding_apples_normal;
					break;
				case 85:
					result = GFXLibrary.townbuilding_cheese_normal;
					break;
				case 86:
					result = GFXLibrary.townbuilding_meat_normal;
					break;
				case 87:
					result = GFXLibrary.townbuilding_bread_normal;
					break;
				case 88:
					result = GFXLibrary.townbuilding_veg_normal;
					break;
				case 89:
					result = GFXLibrary.townbuilding_fish_normal;
					break;
				case 90:
					result = GFXLibrary.townbuilding_bows_normal;
					break;
				case 91:
					result = GFXLibrary.townbuilding_pikes_normal;
					break;
				case 92:
					result = GFXLibrary.townbuilding_armour_normal;
					break;
				case 93:
					result = GFXLibrary.townbuilding_sword_normal;
					break;
				case 94:
					result = GFXLibrary.townbuilding_catapults_normal;
					break;
				case 95:
					result = GFXLibrary.townbuilding_venison_normal;
					break;
				case 96:
					result = GFXLibrary.townbuilding_wine_normal;
					break;
				case 97:
					result = GFXLibrary.townbuilding_salt_normal;
					break;
				case 98:
					result = GFXLibrary.townbuilding_carpenter_normal;
					break;
				case 99:
					result = GFXLibrary.townbuilding_tailor_normal;
					break;
				case 100:
					result = GFXLibrary.townbuilding_metalware_normal;
					break;
				case 101:
					result = GFXLibrary.townbuilding_spice_normal;
					break;
				case 102:
					result = GFXLibrary.townbuilding_silk_normal;
					break;
				case 103:
					result = GFXLibrary.townbuilding_architectsguild_normal;
					break;
				case 104:
					result = GFXLibrary.townbuilding_Labourersbillets_normal;
					break;
				case 105:
					result = GFXLibrary.townbuilding_castellanshouse_normal;
					break;
				case 106:
					result = GFXLibrary.townbuilding_sergeantsatarmsoffice_normal;
					break;
				case 107:
					result = GFXLibrary.townbuilding_stables_normal;
					break;
				case 108:
					result = GFXLibrary.townbuilding_barracks_normal;
					break;
				case 109:
					result = GFXLibrary.townbuilding_peasntshall_normal;
					break;
				case 110:
					result = GFXLibrary.townbuilding_archeryrange_normal;
					break;
				case 111:
					result = GFXLibrary.townbuilding_pikemandrillyard_normal;
					break;
				case 112:
					result = GFXLibrary.townbuilding_combatarena_normal;
					break;
				case 113:
					result = GFXLibrary.townbuilding_siegeengineersguild_normal;
					break;
				case 114:
					result = GFXLibrary.townbuilding_officersquarters_normal;
					break;
				case 115:
					result = GFXLibrary.townbuilding_militaryschool_normal;
					break;
				case 116:
					result = GFXLibrary.townbuilding_supplydepot_normal;
					break;
				case 117:
					result = GFXLibrary.townbuilding_townhall_normal;
					break;
				case 118:
					result = GFXLibrary.townbuilding_church_normal;
					break;
				case 119:
					result = GFXLibrary.townbuilding_towngarden_normal;
					break;
				case 120:
					result = GFXLibrary.townbuilding_statue_normal;
					break;
				case 121:
					result = GFXLibrary.townbuilding_turretmaker_normal;
					break;
				case 122:
					result = GFXLibrary.townbuilding_tunnellorsguild_normal;
					break;
				case 123:
					result = GFXLibrary.townbuilding_ballistamaker_normal;
					break;
				}
				return result;
			}

			// Token: 0x06000F3B RID: 3899 RVA: 0x00104420 File Offset: 0x00102620
			public void playerClicked()
			{
				if (base.csd.ClickedControl != null)
				{
					CustomSelfDrawPanel.CSDControl clickedControl = base.csd.ClickedControl;
					int data = clickedControl.Data;
					InterfaceMgr.Instance.changeTab(0);
					WorldMap.CachedUserInfo cachedUserInfo = new WorldMap.CachedUserInfo();
					cachedUserInfo.userID = data;
					InterfaceMgr.Instance.showUserInfoScreen(cachedUserInfo);
				}
			}

			// Token: 0x06000F3C RID: 3900 RVA: 0x00011065 File Offset: 0x0000F265
			public void playerOver()
			{
				this.playerName.Color = global::ARGBColors.White;
			}

			// Token: 0x06000F3D RID: 3901 RVA: 0x00011077 File Offset: 0x0000F277
			public void playerLeave()
			{
				this.playerName.Color = global::ARGBColors.Black;
			}

			// Token: 0x06000F3E RID: 3902 RVA: 0x00011089 File Offset: 0x0000F289
			public void overDonate()
			{
				if (this.backgroundImage.Enabled)
				{
					this.backgroundImage.Image = GFXLibrary.parishwall_tan_bar_03;
				}
			}

			// Token: 0x06000F3F RID: 3903 RVA: 0x000110AD File Offset: 0x0000F2AD
			public void leaveDonate()
			{
				if ((this.m_lineID & 1) == 0)
				{
					this.backgroundImage.Image = GFXLibrary.parishwall_tan_bar_01;
					return;
				}
				this.backgroundImage.Image = GFXLibrary.parishwall_tan_bar_02;
			}

			// Token: 0x06000F40 RID: 3904 RVA: 0x00104470 File Offset: 0x00102670
			public void clickDonate()
			{
				if (base.csd.ClickedControl != null && this.backgroundImage.Enabled)
				{
					CustomSelfDrawPanel.CSDControl clickedControl = base.csd.ClickedControl;
					this.donatePopupLocation = clickedControl.getPanelPosition();
					this.donatePopupLocation = new Point(this.donatePopupLocation.X + clickedControl.Width, this.donatePopupLocation.Y);
					this.donatePopupLocation = this.m_parent.PointToScreen(this.donatePopupLocation);
					this.showDetailedInfo(this.m_wallInfo.userID, this.m_wallInfo.entryType);
					this.leaveDonate();
				}
			}

			// Token: 0x06000F41 RID: 3905 RVA: 0x00104514 File Offset: 0x00102714
			public void showDetailedInfo(int userID, int wallType)
			{
				ParishWallDetailInfo_ReturnType parishWallDonateDetails = GameEngine.Instance.World.getParishWallDonateDetails(this.m_villageID, userID);
				if (parishWallDonateDetails == null)
				{
					RemoteServices.Instance.set_ParishWallDetailInfo_UserCallBack(new RemoteServices.ParishWallDetailInfo_UserCallBack(this.parishWallDetailInfoCallBack));
					RemoteServices.Instance.ParishWallDetailInfo(this.m_villageID, userID, wallType);
					this.backgroundImage.Enabled = false;
					return;
				}
				this.parishWallDetailInfoCallBack(parishWallDonateDetails);
			}

			// Token: 0x06000F42 RID: 3906 RVA: 0x00104578 File Offset: 0x00102778
			public void parishWallDetailInfoCallBack(ParishWallDetailInfo_ReturnType returnData)
			{
				this.backgroundImage.Enabled = true;
				if (returnData.Success && returnData.detailedInfo != null && returnData.detailedInfo.Count > 0 && returnData.detailedInfo[0].entryType == 1)
				{
					if (returnData.m_errorID != 999)
					{
						returnData.m_errorID = 999;
						GameEngine.Instance.World.registerParishWallDonateDetails(returnData);
					}
					DonatePopup.CreateDonatePopup(this.donatePopupLocation, returnData);
				}
			}

			// Token: 0x040012E8 RID: 4840
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040012E9 RID: 4841
			private CustomSelfDrawPanel.CSDLabel playerName = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040012EA RID: 4842
			private CustomSelfDrawPanel.CSDLabel effectText = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040012EB RID: 4843
			private CustomSelfDrawPanel.CSDImage effectImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040012EC RID: 4844
			private CustomSelfDrawPanel.CSDImage shieldImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040012ED RID: 4845
			private int m_lineID;

			// Token: 0x040012EE RID: 4846
			private WallInfo m_wallInfo;

			// Token: 0x040012EF RID: 4847
			private int m_villageID = -1;

			// Token: 0x040012F0 RID: 4848
			private CustomSelfDrawPanel m_parent;

			// Token: 0x040012F1 RID: 4849
			private Point donatePopupLocation;
		}

		// Token: 0x0200018A RID: 394
		public class ParishWallChatEntry : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06000F44 RID: 3908 RVA: 0x0010464C File Offset: 0x0010284C
			public void init(Chat_TextEntry textEntry, ParishWallPanel window)
			{
				this.parent = window;
				this.textID = textEntry.textID;
				this.shieldImage.Image = GameEngine.Instance.World.getWorldShield(textEntry.userID, 32, 36);
				this.shieldImage.Position = new Point(15, 7);
				base.addControl(this.shieldImage);
				this.playerName.Text = textEntry.username;
				this.playerName.Color = global::ARGBColors.Blue;
				this.playerName.Position = new Point(0, 0);
				this.playerName.Size = new Size(405, 30);
				this.playerName.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.playerName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.playerName.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.playerClicked), "ParishChatPanel_user");
				this.playerName.Data = textEntry.userID;
				this.playerName.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.playerOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.playerLeave));
				this.playerName.setRightClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.copyTextToClipboardClick));
				this.bodyText.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				Graphics graphics = window.CreateGraphics();
				Size size = graphics.MeasureString(textEntry.username, this.playerName.Font, 1000000).ToSize();
				this.playerName.Size = new Size(size.Width + 5, 20);
				if (CustomSelfDrawPanel.ParishWallChatEntry.spaceWidth < 0)
				{
					CustomSelfDrawPanel.ParishWallChatEntry.spaceWidth = graphics.MeasureString(" ", this.bodyText.Font, 1000000).ToSize().Width;
				}
				string text = "";
				for (int i = size.Width + 15; i > 0; i -= CustomSelfDrawPanel.ParishWallChatEntry.spaceWidth)
				{
					text += " ";
				}
				text += textEntry.text;
				this.textArea = new CustomSelfDrawPanel.CSDArea();
				this.textArea.Position = new Point(63, 0);
				this.textArea.Size = new Size(405, 1000);
				base.addControl(this.textArea);
				this.bodyText.Text = text;
				this.bodyText.Color = global::ARGBColors.Black;
				this.bodyText.Position = new Point(0, 0);
				this.bodyText.Size = new Size(405, 1000);
				this.bodyText.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.bodyText.setRightClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.copyTextToClipboardClick));
				this.textArea.addControl(this.bodyText);
				this.textArea.addControl(this.playerName);
				int num = graphics.MeasureString(text, this.bodyText.Font, 405).ToSize().Height;
				num += 20;
				if (num < 63)
				{
					num = 63;
				}
				DateTime currentServerTime = VillageMap.getCurrentServerTime();
				TimeSpan timeSpan = currentServerTime - textEntry.postedTime;
				if (timeSpan.TotalMinutes < 1.0)
				{
					int num2 = (int)timeSpan.TotalSeconds;
					if (num2 <= 0)
					{
						num2 = 1;
					}
					if (num2 != 1)
					{
						this.dateText.Text = num2.ToString() + " " + SK.Text("ParishWallPanel_X_Seconds_Ago", "seconds ago");
					}
					else
					{
						this.dateText.Text = num2.ToString() + " " + SK.Text("ParishWallPanel_X_Second_Ago", "second ago");
					}
				}
				else if (timeSpan.TotalHours < 1.0)
				{
					int num3 = (int)timeSpan.TotalMinutes;
					if (num3 <= 0)
					{
						num3 = 1;
					}
					if (num3 != 1)
					{
						this.dateText.Text = num3.ToString() + " " + SK.Text("ParishWallPanel_X_Minutes_Ago", "minutes ago");
					}
					else
					{
						this.dateText.Text = num3.ToString() + " " + SK.Text("ParishWallPanel_X_Minute_Ago", "minute ago");
					}
				}
				else if (timeSpan.TotalHours < 24.0)
				{
					int num4 = (int)timeSpan.TotalHours;
					if (num4 <= 0)
					{
						num4 = 1;
					}
					if (num4 != 1)
					{
						this.dateText.Text = num4.ToString() + " " + SK.Text("ParishWallPanel_X_Hours_Ago", "hours ago");
					}
					else
					{
						this.dateText.Text = num4.ToString() + " " + SK.Text("ParishWallPanel_X_Hour_Ago", "hour ago");
					}
				}
				else
				{
					int num5 = (int)timeSpan.TotalDays;
					if (num5 <= 0)
					{
						num5 = 1;
					}
					if (num5 != 1)
					{
						this.dateText.Text = num5.ToString() + " " + SK.Text("ParishWallPanel_X_Days_Ago", "days ago");
					}
					else
					{
						this.dateText.Text = num5.ToString() + " " + SK.Text("ParishWallPanel_X_Day_Ago", "day ago");
					}
				}
				this.dateText.Color = Color.FromArgb(77, 79, 81);
				this.dateText.Position = new Point(63, num - 20);
				this.dateText.Size = new Size(405, 30);
				this.dateText.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
				this.dateText.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				base.addControl(this.dateText);
				this.Size = new Size(405, num);
				this.textArea.ClipVisible = true;
				graphics.Dispose();
				if (RemoteServices.Instance.Admin || RemoteServices.Instance.Moderator || RemoteServices.Instance.UserID == ParishWallPanel.m_userIDOnCurrent)
				{
					this.deleteButton.ImageNorm = GFXLibrary.trashcan_normal;
					this.deleteButton.ImageOver = GFXLibrary.trashcan_over;
					this.deleteButton.ImageClick = GFXLibrary.trashcan_clicked;
					this.deleteButton.Position = new Point(445, num - 20);
					this.deleteButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.deleteClicked), "FactionNewForumPostsPanel_delete_post");
					base.addControl(this.deleteButton);
				}
			}

			// Token: 0x06000F45 RID: 3909 RVA: 0x00104CCC File Offset: 0x00102ECC
			private void deleteClicked()
			{
				DialogResult dialogResult = MyMessageBox.Show(SK.Text("FORUMS_Are_You_Sure", "Are you sure?"), SK.Text("FORUMS_Delete_Post", "Delete This Post"), MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					this.DeletePost();
				}
			}

			// Token: 0x06000F46 RID: 3910 RVA: 0x000110E4 File Offset: 0x0000F2E4
			private void DeletePost()
			{
				RemoteServices.Instance.Chat_Admin_Command(6, (int)this.textID);
				if (this.parent != null)
				{
					this.parent.deleteWallPost(this.textID);
				}
			}

			// Token: 0x06000F47 RID: 3911 RVA: 0x00104420 File Offset: 0x00102620
			public void playerClicked()
			{
				if (base.csd.ClickedControl != null)
				{
					CustomSelfDrawPanel.CSDControl clickedControl = base.csd.ClickedControl;
					int data = clickedControl.Data;
					InterfaceMgr.Instance.changeTab(0);
					WorldMap.CachedUserInfo cachedUserInfo = new WorldMap.CachedUserInfo();
					cachedUserInfo.userID = data;
					InterfaceMgr.Instance.showUserInfoScreen(cachedUserInfo);
				}
			}

			// Token: 0x06000F48 RID: 3912 RVA: 0x00011111 File Offset: 0x0000F311
			public void playerOver()
			{
				this.playerName.Color = global::ARGBColors.Aquamarine;
			}

			// Token: 0x06000F49 RID: 3913 RVA: 0x00011123 File Offset: 0x0000F323
			public void playerLeave()
			{
				this.playerName.Color = global::ARGBColors.Blue;
			}

			// Token: 0x06000F4A RID: 3914 RVA: 0x00104D08 File Offset: 0x00102F08
			private void copyTextToClipboardClick()
			{
				if (base.csd != null && base.csd.ClickedControl != null && base.csd.ClickedControl.GetType() == typeof(CustomSelfDrawPanel.CSDLabel))
				{
					CustomSelfDrawPanel.CSDLabel csdlabel = (CustomSelfDrawPanel.CSDLabel)base.csd.ClickedControl;
					Clipboard.SetText(csdlabel.Text.TrimStart(null));
				}
			}

			// Token: 0x040012F2 RID: 4850
			private static int spaceWidth = -1;

			// Token: 0x040012F3 RID: 4851
			private CustomSelfDrawPanel.CSDArea textArea = new CustomSelfDrawPanel.CSDArea();

			// Token: 0x040012F4 RID: 4852
			private CustomSelfDrawPanel.CSDLabel playerName = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040012F5 RID: 4853
			private CustomSelfDrawPanel.CSDLabel bodyText = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040012F6 RID: 4854
			private CustomSelfDrawPanel.CSDLabel dateText = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040012F7 RID: 4855
			private CustomSelfDrawPanel.CSDImage effectImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040012F8 RID: 4856
			private CustomSelfDrawPanel.CSDImage shieldImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040012F9 RID: 4857
			private CustomSelfDrawPanel.CSDButton deleteButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040012FA RID: 4858
			private long textID = -1L;

			// Token: 0x040012FB RID: 4859
			private new ParishWallPanel parent;

			// Token: 0x040012FC RID: 4860
			private MyMessageBoxPopUp PopUpRef;
		}

		// Token: 0x0200018B RID: 395
		public class MedalImage : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06000F4D RID: 3917 RVA: 0x00104DD0 File Offset: 0x00102FD0
			public void init(int achievement, CustomSelfDrawPanel.MedalWindow parent)
			{
				this.m_rawAchievement = achievement;
				this.m_parent = parent;
				int num = 3002;
				bool flag = true;
				if (achievement < 0)
				{
					flag = false;
					achievement = -achievement;
					num = 3001;
				}
				if (parent != null && parent.ownPlayer)
				{
					num += 2;
				}
				this.m_achievement = (achievement & 4095);
				int num2 = achievement & 1879048192;
				int num3;
				if (num2 <= 1073741824)
				{
					if (num2 == 268435456)
					{
						this.m_achievementRank = 1;
						num3 = 1;
						goto IL_DC;
					}
					if (num2 == 536870912)
					{
						this.m_achievementRank = 2;
						num3 = 2;
						goto IL_DC;
					}
					if (num2 == 1073741824)
					{
						this.m_achievementRank = 3;
						num3 = 3;
						goto IL_DC;
					}
				}
				else
				{
					if (num2 == 1342177280)
					{
						this.m_achievementRank = 4;
						num3 = 53;
						goto IL_DC;
					}
					if (num2 == 1610612736)
					{
						this.m_achievementRank = 5;
						num3 = 54;
						goto IL_DC;
					}
					if (num2 == 1879048192)
					{
						this.m_achievementRank = 6;
						num3 = 55;
						goto IL_DC;
					}
				}
				this.m_achievementRank = 0;
				num3 = 0;
				IL_DC:
				this.clearControls();
				Color colorise = global::ARGBColors.White;
				float alpha = 1f;
				if (!flag)
				{
					colorise = Color.FromArgb(128, 128, 128, 128);
					alpha = 0.7f;
				}
				this.Size = new Size(81, 110);
				int ribbonColour = this.getRibbonColour(this.m_achievement);
				this.ribbonBase.Image = GFXLibrary.achievement_ribbons_base[ribbonColour];
				this.ribbonBase.Position = new Point(0, 0);
				this.ribbonBase.Colorise = colorise;
				this.ribbonBase.Alpha = alpha;
				this.ribbonBase.CustomTooltipID = num;
				this.ribbonBase.CustomTooltipData = achievement;
				base.addControl(this.ribbonBase);
				if (this.m_achievementRank != 0)
				{
					if (this.m_achievementRank == 1)
					{
						this.ribbonOverlay.Image = GFXLibrary.achievement_ribbons_edges[ribbonColour];
					}
					else if (this.m_achievementRank == 2)
					{
						this.ribbonOverlay.Image = GFXLibrary.achievement_ribbons_centre[ribbonColour];
					}
					else if (this.m_achievementRank >= 3)
					{
						this.ribbonOverlay.Image = GFXLibrary.ribbon_comp_centerstripe_gold;
					}
					this.ribbonOverlay.Position = new Point(0, 0);
					this.ribbonOverlay.Colorise = colorise;
					this.ribbonOverlay.Alpha = alpha;
					this.ribbonOverlay.CustomTooltipID = num;
					this.ribbonOverlay.CustomTooltipData = achievement;
					this.ribbonBase.addControl(this.ribbonOverlay);
				}
				this.nail.Image = GFXLibrary.ribbon_comp_nail;
				this.nail.Position = new Point(0, 0);
				this.nail.Colorise = colorise;
				this.nail.Alpha = alpha;
				this.nail.CustomTooltipID = num;
				this.nail.CustomTooltipData = achievement;
				this.ribbonBase.addControl(this.nail);
				this.medalMetal.Image = GFXLibrary.medal_images[num3];
				this.medalMetal.Position = new Point(8, 58);
				this.medalMetal.Colorise = colorise;
				this.medalMetal.Alpha = alpha;
				this.medalMetal.CustomTooltipID = num;
				this.medalMetal.CustomTooltipData = achievement;
				base.addControl(this.medalMetal);
				this.medalImage.Image = GFXLibrary.medal_images[CustomSelfDrawPanel.MedalImage.getAchievementImage(this.m_achievement)];
				this.medalImage.Position = new Point(0, 0);
				this.medalImage.Colorise = colorise;
				this.medalImage.Alpha = alpha;
				this.medalImage.CustomTooltipID = num;
				this.medalImage.CustomTooltipData = achievement;
				this.medalMetal.addControl(this.medalImage);
				if (this.m_rawAchievement >= 0)
				{
					base.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.achClicked));
				}
				base.invalidate();
			}

			// Token: 0x06000F4E RID: 3918 RVA: 0x0001113D File Offset: 0x0000F33D
			private void achClicked()
			{
				if (this.m_parent != null)
				{
					this.m_parent.achievementClicked(this.m_rawAchievement);
				}
			}

			// Token: 0x06000F4F RID: 3919 RVA: 0x001051A0 File Offset: 0x001033A0
			private int getRibbonColour(int achievement)
			{
				if (achievement <= 163)
				{
					if (achievement <= 67)
					{
						if (achievement - 1 <= 15)
						{
							return 0;
						}
						if (achievement - 33 <= 4)
						{
							return 1;
						}
						if (achievement - 65 <= 2)
						{
							return 2;
						}
					}
					else
					{
						if (achievement - 97 <= 4)
						{
							return 3;
						}
						if (achievement - 129 <= 2)
						{
							return 4;
						}
						if (achievement - 161 <= 2)
						{
							return 5;
						}
					}
				}
				else if (achievement <= 257)
				{
					if (achievement - 193 <= 2)
					{
						return 6;
					}
					if (achievement - 225 <= 1)
					{
						return 7;
					}
					if (achievement == 257)
					{
						return 8;
					}
				}
				else if (achievement <= 321)
				{
					if (achievement - 289 <= 1)
					{
						return 9;
					}
					if (achievement == 321)
					{
						return 10;
					}
				}
				else
				{
					if (achievement - 353 <= 1)
					{
						return 11;
					}
					if (achievement - 385 <= 3)
					{
						return 12;
					}
				}
				return 0;
			}

			// Token: 0x06000F50 RID: 3920 RVA: 0x00105270 File Offset: 0x00103470
			public static int getAchievementImage(int achievement)
			{
				if (achievement <= 225)
				{
					if (achievement <= 101)
					{
						switch (achievement)
						{
						case 1:
							return 4;
						case 2:
							return 5;
						case 3:
							return 6;
						case 4:
							return 7;
						case 5:
							return 8;
						case 6:
							return 49;
						case 7:
							return 50;
						case 8:
							return 51;
						case 9:
							return 52;
						case 10:
							return 10;
						case 11:
							return 11;
						case 12:
							return 12;
						case 13:
							return 13;
						case 14:
							return 14;
						case 15:
							return 56;
						case 16:
							return 57;
						case 17:
						case 18:
						case 19:
						case 20:
						case 21:
						case 22:
						case 23:
						case 24:
						case 25:
						case 26:
						case 27:
						case 28:
						case 29:
						case 30:
						case 31:
						case 32:
							break;
						case 33:
							return 15;
						case 34:
							return 16;
						case 35:
							return 17;
						case 36:
							return 18;
						case 37:
							return 19;
						default:
							switch (achievement)
							{
							case 65:
								return 20;
							case 66:
								return 21;
							case 67:
								return 22;
							default:
								switch (achievement)
								{
								case 97:
									return 23;
								case 98:
									return 24;
								case 99:
									return 25;
								case 100:
									return 26;
								case 101:
									return 27;
								}
								break;
							}
							break;
						}
					}
					else if (achievement <= 163)
					{
						switch (achievement)
						{
						case 129:
							return 28;
						case 130:
							return 29;
						case 131:
							return 30;
						default:
							switch (achievement)
							{
							case 161:
								return 31;
							case 162:
								return 32;
							case 163:
								return 33;
							}
							break;
						}
					}
					else
					{
						switch (achievement)
						{
						case 193:
							return 34;
						case 194:
							return 35;
						case 195:
							return 36;
						default:
							if (achievement == 225)
							{
								return 37;
							}
							break;
						}
					}
				}
				else if (achievement <= 290)
				{
					if (achievement <= 257)
					{
						if (achievement == 226)
						{
							return 38;
						}
						if (achievement == 257)
						{
							return 39;
						}
					}
					else
					{
						if (achievement == 289)
						{
							return 40;
						}
						if (achievement == 290)
						{
							return 41;
						}
					}
				}
				else if (achievement <= 353)
				{
					if (achievement == 321)
					{
						return 42;
					}
					if (achievement == 353)
					{
						return 43;
					}
				}
				else
				{
					if (achievement == 354)
					{
						return 44;
					}
					switch (achievement)
					{
					case 385:
						return 45;
					case 386:
						return 46;
					case 387:
						return 47;
					case 388:
						return 48;
					}
				}
				return 0;
			}

			// Token: 0x040012FD RID: 4861
			private CustomSelfDrawPanel.CSDImage ribbonBase = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040012FE RID: 4862
			private CustomSelfDrawPanel.CSDImage ribbonOverlay = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040012FF RID: 4863
			private CustomSelfDrawPanel.CSDImage nail = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001300 RID: 4864
			private CustomSelfDrawPanel.CSDImage medalMetal = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001301 RID: 4865
			private CustomSelfDrawPanel.CSDImage medalImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001302 RID: 4866
			private int m_achievement;

			// Token: 0x04001303 RID: 4867
			private int m_achievementRank;

			// Token: 0x04001304 RID: 4868
			private int m_rawAchievement;

			// Token: 0x04001305 RID: 4869
			private CustomSelfDrawPanel.MedalWindow m_parent;
		}

		// Token: 0x0200018C RID: 396
		public class MedalWindow : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06000F52 RID: 3922 RVA: 0x001054F0 File Offset: 0x001036F0
			public void init(List<int> earnedAchievements, bool addUnearned, bool popupOverlay, int heightDiff)
			{
				this.ownPlayer = !popupOverlay;
				this.clearControls();
				this.Size = new Size(475, 350);
				this.scrollArea.Position = new Point(7, 30);
				this.scrollArea.Size = new Size(475, 2000);
				this.scrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(475, 305 + heightDiff));
				base.addControl(this.scrollArea);
				this.scrollImage.Image = GFXLibrary.achievement_woodback_middletile;
				this.scrollImage.Size = this.scrollArea.Size;
				this.scrollImage.Tile = true;
				this.scrollImage.Position = new Point(0, 0);
				this.scrollArea.addControl(this.scrollImage);
				this.scrollArea2.Position = new Point(0, 0);
				this.scrollArea2.Size = this.scrollImage.Size;
				this.scrollImage.addControl(this.scrollArea2);
				this.mouseWheelOverlay.Position = this.scrollArea.Position;
				this.mouseWheelOverlay.Size = this.scrollArea.Size;
				this.mouseWheelOverlay.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mouseWheelMoved));
				base.addControl(this.mouseWheelOverlay);
				this.scrollBar.Position = new Point(436, 55);
				this.scrollBar.Size = new Size(32, 275 + heightDiff);
				base.addControl(this.scrollBar);
				this.scrollBar.Value = 0;
				this.scrollBar.Max = 920 - (305 + heightDiff) + 20;
				this.scrollBar.NumVisibleLines = 305 + heightDiff;
				this.scrollBar.Create(null, null, null, GFXLibrary.scroll_thumb_top, GFXLibrary.scroll_thumb_mid, GFXLibrary.scroll_thumb_bottom);
				this.scrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.scrollBarMoved));
				this.ach_top_overlay.Image = GFXLibrary.panel_cover_top;
				this.ach_top_overlay.Position = new Point(0, 0);
				base.addControl(this.ach_top_overlay);
				this.ach_bottom_overlay.Image = GFXLibrary.panel_cover_bottom;
				this.ach_bottom_overlay.Position = new Point(0, 30 + (305 + heightDiff) - 45);
				base.addControl(this.ach_bottom_overlay);
				if (popupOverlay)
				{
					this.popupOverlayImage.Image = GFXLibrary.char_achievementOverlay;
					this.popupOverlayImage.Position = new Point(0, 0);
					base.addControl(this.popupOverlayImage);
				}
				List<int> list = CustomSelfDrawPanel.MedalWindow.processAchievements(earnedAchievements, addUnearned);
				int num = 25;
				int num2 = 10;
				int num3 = 80;
				int num4 = 115;
				if (list.Count > 0)
				{
					this.medal1.init(list[0], this);
					this.medal1.Position = new Point(num, num2);
					this.scrollArea2.addControl(this.medal1);
				}
				if (list.Count > 1)
				{
					this.medal2.init(list[1], this);
					this.medal2.Position = new Point(num + num3, num2);
					this.scrollArea2.addControl(this.medal2);
				}
				if (list.Count > 2)
				{
					this.medal3.init(list[2], this);
					this.medal3.Position = new Point(num + num3 * 2, num2);
					this.scrollArea2.addControl(this.medal3);
				}
				if (list.Count > 3)
				{
					this.medal4.init(list[3], this);
					this.medal4.Position = new Point(num + num3 * 3, num2);
					this.scrollArea2.addControl(this.medal4);
				}
				if (list.Count > 4)
				{
					this.medal5.init(list[4], this);
					this.medal5.Position = new Point(num + num3 * 4, num2);
					this.scrollArea2.addControl(this.medal5);
				}
				if (list.Count > 5)
				{
					this.medal6.init(list[5], this);
					this.medal6.Position = new Point(num, num2 + num4);
					this.scrollArea2.addControl(this.medal6);
				}
				if (list.Count > 6)
				{
					this.medal7.init(list[6], this);
					this.medal7.Position = new Point(num + num3, num2 + num4);
					this.scrollArea2.addControl(this.medal7);
				}
				if (list.Count > 7)
				{
					this.medal8.init(list[7], this);
					this.medal8.Position = new Point(num + num3 * 2, num2 + num4);
					this.scrollArea2.addControl(this.medal8);
				}
				if (list.Count > 8)
				{
					this.medal9.init(list[8], this);
					this.medal9.Position = new Point(num + num3 * 3, num2 + num4);
					this.scrollArea2.addControl(this.medal9);
				}
				if (list.Count > 9)
				{
					this.medal10.init(list[9], this);
					this.medal10.Position = new Point(num + num3 * 4, num2 + num4);
					this.scrollArea2.addControl(this.medal10);
				}
				if (list.Count > 10)
				{
					this.medal11.init(list[10], this);
					this.medal11.Position = new Point(num, num2 + num4 * 2);
					this.scrollArea2.addControl(this.medal11);
				}
				if (list.Count > 11)
				{
					this.medal12.init(list[11], this);
					this.medal12.Position = new Point(num + num3, num2 + num4 * 2);
					this.scrollArea2.addControl(this.medal12);
				}
				if (list.Count > 12)
				{
					this.medal13.init(list[12], this);
					this.medal13.Position = new Point(num + num3 * 2, num2 + num4 * 2);
					this.scrollArea2.addControl(this.medal13);
				}
				if (list.Count > 13)
				{
					this.medal14.init(list[13], this);
					this.medal14.Position = new Point(num + num3 * 3, num2 + num4 * 2);
					this.scrollArea2.addControl(this.medal14);
				}
				if (list.Count > 14)
				{
					this.medal15.init(list[14], this);
					this.medal15.Position = new Point(num + num3 * 4, num2 + num4 * 2);
					this.scrollArea2.addControl(this.medal15);
				}
				if (list.Count > 15)
				{
					this.medal16.init(list[15], this);
					this.medal16.Position = new Point(num, num2 + num4 * 3);
					this.scrollArea2.addControl(this.medal16);
				}
				if (list.Count > 16)
				{
					this.medal17.init(list[16], this);
					this.medal17.Position = new Point(num + num3, num2 + num4 * 3);
					this.scrollArea2.addControl(this.medal17);
				}
				if (list.Count > 17)
				{
					this.medal18.init(list[17], this);
					this.medal18.Position = new Point(num + num3 * 2, num2 + num4 * 3);
					this.scrollArea2.addControl(this.medal18);
				}
				if (list.Count > 18)
				{
					this.medal19.init(list[18], this);
					this.medal19.Position = new Point(num + num3 * 3, num2 + num4 * 3);
					this.scrollArea2.addControl(this.medal19);
				}
				if (list.Count > 19)
				{
					this.medal20.init(list[19], this);
					this.medal20.Position = new Point(num + num3 * 4, num2 + num4 * 3);
					this.scrollArea2.addControl(this.medal20);
				}
				if (list.Count > 20)
				{
					this.medal21.init(list[20], this);
					this.medal21.Position = new Point(num, num2 + num4 * 4);
					this.scrollArea2.addControl(this.medal21);
				}
				if (list.Count > 21)
				{
					this.medal22.init(list[21], this);
					this.medal22.Position = new Point(num + num3, num2 + num4 * 4);
					this.scrollArea2.addControl(this.medal22);
				}
				if (list.Count > 22)
				{
					this.medal23.init(list[22], this);
					this.medal23.Position = new Point(num + num3 * 2, num2 + num4 * 4);
					this.scrollArea2.addControl(this.medal23);
				}
				if (list.Count > 23)
				{
					this.medal24.init(list[23], this);
					this.medal24.Position = new Point(num + num3 * 3, num2 + num4 * 4);
					this.scrollArea2.addControl(this.medal24);
				}
				if (list.Count > 24)
				{
					this.medal25.init(list[24], this);
					this.medal25.Position = new Point(num + num3 * 4, num2 + num4 * 4);
					this.scrollArea2.addControl(this.medal25);
				}
				if (list.Count > 25)
				{
					this.medal26.init(list[25], this);
					this.medal26.Position = new Point(num, num2 + num4 * 5);
					this.scrollArea2.addControl(this.medal26);
				}
				if (list.Count > 26)
				{
					this.medal27.init(list[26], this);
					this.medal27.Position = new Point(num + num3, num2 + num4 * 5);
					this.scrollArea2.addControl(this.medal27);
				}
				if (list.Count > 27)
				{
					this.medal28.init(list[27], this);
					this.medal28.Position = new Point(num + num3 * 2, num2 + num4 * 5);
					this.scrollArea2.addControl(this.medal28);
				}
				if (list.Count > 28)
				{
					this.medal29.init(list[28], this);
					this.medal29.Position = new Point(num + num3 * 3, num2 + num4 * 5);
					this.scrollArea2.addControl(this.medal29);
				}
				if (list.Count > 29)
				{
					this.medal30.init(list[29], this);
					this.medal30.Position = new Point(num + num3 * 4, num2 + num4 * 5);
					this.scrollArea2.addControl(this.medal30);
				}
				if (list.Count > 30)
				{
					this.medal31.init(list[30], this);
					this.medal31.Position = new Point(num, num2 + num4 * 6);
					this.scrollArea2.addControl(this.medal31);
				}
				if (list.Count > 31)
				{
					this.medal32.init(list[31], this);
					this.medal32.Position = new Point(num + num3, num2 + num4 * 6);
					this.scrollArea2.addControl(this.medal32);
				}
				if (list.Count > 32)
				{
					this.medal33.init(list[32], this);
					this.medal33.Position = new Point(num + num3 * 2, num2 + num4 * 6);
					this.scrollArea2.addControl(this.medal33);
				}
				if (list.Count > 33)
				{
					this.medal34.init(list[33], this);
					this.medal34.Position = new Point(num + num3 * 3, num2 + num4 * 6);
					this.scrollArea2.addControl(this.medal34);
				}
				if (list.Count > 34)
				{
					this.medal35.init(list[34], this);
					this.medal35.Position = new Point(num + num3 * 4, num2 + num4 * 6);
					this.scrollArea2.addControl(this.medal35);
				}
				if (list.Count > 35)
				{
					this.medal36.init(list[35], this);
					this.medal36.Position = new Point(num, num2 + num4 * 7);
					this.scrollArea2.addControl(this.medal36);
				}
				if (list.Count > 36)
				{
					this.medal37.init(list[36], this);
					this.medal37.Position = new Point(num + num3, num2 + num4 * 7);
					this.scrollArea2.addControl(this.medal37);
				}
				if (list.Count > 37)
				{
					this.medal38.init(list[37], this);
					this.medal38.Position = new Point(num + num3 * 2, num2 + num4 * 7);
					this.scrollArea2.addControl(this.medal38);
				}
				if (list.Count > 38)
				{
					this.medal39.init(list[38], this);
					this.medal39.Position = new Point(num + num3 * 3, num2 + num4 * 7);
					this.scrollArea2.addControl(this.medal39);
				}
				if (list.Count > 39)
				{
					this.medal40.init(list[39], this);
					this.medal40.Position = new Point(num + num3 * 4, num2 + num4 * 7);
					this.scrollArea2.addControl(this.medal40);
				}
				if (list.Count > 40)
				{
					this.medal41.init(list[40], this);
					this.medal41.Position = new Point(num, num2 + num4 * 8);
					this.scrollArea2.addControl(this.medal41);
				}
				if (list.Count > 41)
				{
					this.medal42.init(list[41], this);
					this.medal42.Position = new Point(num + num3, num2 + num4 * 8);
					this.scrollArea2.addControl(this.medal42);
				}
				if (list.Count > 42)
				{
					this.medal43.init(list[42], this);
					this.medal43.Position = new Point(num + num3 * 2, num2 + num4 * 8);
					this.scrollArea2.addControl(this.medal43);
				}
				if (list.Count > 43)
				{
					this.medal44.init(list[43], this);
					this.medal44.Position = new Point(num + num3 * 3, num2 + num4 * 8);
					this.scrollArea2.addControl(this.medal44);
				}
				if (list.Count > 44)
				{
					this.medal45.init(list[44], this);
					this.medal45.Position = new Point(num + num3 * 4, num2 + num4 * 8);
					this.scrollArea2.addControl(this.medal45);
				}
				int num5 = (list.Count + 4) / 5;
				int num6 = num5 * 115 - 305 + 20;
				if (num6 < 0)
				{
					num6 = 0;
					this.scrollBar.Visible = false;
				}
				else
				{
					this.scrollBar.Visible = true;
				}
				this.scrollBar.Max = num6;
				if (heightDiff != 0)
				{
					if (earnedAchievements.Count == 1)
					{
						int num7 = earnedAchievements[0];
						int achievement = num7 & 4095;
						string achievementRank = CustomTooltipManager.getAchievementRank(num7);
						int num8 = num7 & 1879048192;
						int rankLevel;
						if (num8 <= 1073741824)
						{
							if (num8 == 268435456)
							{
								rankLevel = 1;
								goto IL_114E;
							}
							if (num8 == 536870912)
							{
								rankLevel = 2;
								goto IL_114E;
							}
							if (num8 == 1073741824)
							{
								rankLevel = 3;
								goto IL_114E;
							}
						}
						else
						{
							if (num8 == 1342177280)
							{
								rankLevel = 4;
								goto IL_114E;
							}
							if (num8 == 1610612736)
							{
								rankLevel = 5;
								goto IL_114E;
							}
							if (num8 == 1879048192)
							{
								rankLevel = 6;
								goto IL_114E;
							}
						}
						rankLevel = 0;
						IL_114E:
						string text = this.fb_title = CustomTooltipManager.getAchievementTitle(achievement);
						string text2 = this.fb_caption = CustomTooltipManager.getAchievementRequirement(achievement, rankLevel);
						string text3 = string.Concat(new string[]
						{
							text,
							Environment.NewLine,
							achievementRank,
							Environment.NewLine,
							text2
						});
						this.achievementsLabel.Text = text3;
						this.achievementsLabel.Position = new Point(105, 45);
						this.achievementsLabel.Size = new Size(350, 110);
						this.achievementsLabel.Font = FontManager.GetFont("Arial", 11f, FontStyle.Regular);
						this.achievementsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
						this.achievementsLabel.Color = global::ARGBColors.White;
						this.ach_top_overlay.addControl(this.achievementsLabel);
					}
					return;
				}
				this.achievementsLabel.Text = SK.Text("GENERIC_Achievements", "Achievements");
				this.achievementsLabel.Position = new Point(0, 0);
				this.achievementsLabel.Size = new Size(this.ach_top_overlay.Width, 30);
				this.achievementsLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
				this.achievementsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				if (!popupOverlay)
				{
					this.achievementsLabel.Color = Color.FromArgb(224, 203, 146);
					this.achievementsLabel.DropShadowColor = Color.FromArgb(56, 50, 36);
					this.ach_top_overlay.addControl(this.achievementsLabel);
					return;
				}
				this.achievementsLabel.Color = global::ARGBColors.White;
				this.achievementsLabel.DropShadowColor = global::ARGBColors.Black;
				this.popupOverlayImage.addControl(this.achievementsLabel);
			}

			// Token: 0x06000F53 RID: 3923 RVA: 0x00106724 File Offset: 0x00104924
			private void scrollBarMoved()
			{
				int value = this.scrollBar.Value;
				this.scrollArea.Position = new Point(this.scrollArea.X, 30 - value);
				this.scrollArea.ClipRect = new Rectangle(this.scrollArea.ClipRect.X, value, this.scrollArea.ClipRect.Width, this.scrollArea.ClipRect.Height);
				this.scrollArea.invalidate();
			}

			// Token: 0x06000F54 RID: 3924 RVA: 0x00011197 File Offset: 0x0000F397
			private void mouseWheelMoved(int delta)
			{
				if (delta < 0)
				{
					this.scrollBar.scrollDown(6);
					return;
				}
				if (delta > 0)
				{
					this.scrollBar.scrollUp(6);
				}
			}

			// Token: 0x06000F55 RID: 3925 RVA: 0x001067B4 File Offset: 0x001049B4
			public static int getAchievementRanking(int achievement)
			{
				int num = achievement & 268435455;
				if (num <= 225)
				{
					if (num <= 101)
					{
						switch (num)
						{
						case 1:
							return 4;
						case 2:
							return 8;
						case 3:
							return 13;
						case 4:
							return 14;
						case 5:
							return 17;
						case 6:
							return 19;
						case 7:
							return 22;
						case 8:
							return 28;
						case 9:
							return 33;
						case 10:
							return 27;
						case 11:
							return 28;
						case 12:
							return 25;
						case 13:
							return 19;
						case 14:
							return 22;
						case 15:
							return 29;
						case 16:
							return 30;
						case 17:
						case 18:
						case 19:
						case 20:
						case 21:
						case 22:
						case 23:
						case 24:
						case 25:
						case 26:
						case 27:
						case 28:
						case 29:
						case 30:
						case 31:
						case 32:
							break;
						case 33:
							return 10;
						case 34:
							return 16;
						case 35:
							return 0;
						case 36:
							return 0;
						case 37:
							return 15;
						default:
							switch (num)
							{
							case 65:
								return 28;
							case 66:
								return 25;
							case 67:
								return 24;
							default:
								switch (num)
								{
								case 97:
									return 7;
								case 98:
									return 8;
								case 99:
									return 24;
								case 100:
									return 23;
								case 101:
									return 19;
								}
								break;
							}
							break;
						}
					}
					else if (num <= 163)
					{
						switch (num)
						{
						case 129:
							return 26;
						case 130:
							return 33;
						case 131:
							return 22;
						default:
							switch (num)
							{
							case 161:
								return 5;
							case 162:
								return 3;
							case 163:
								return 11;
							}
							break;
						}
					}
					else
					{
						switch (num)
						{
						case 193:
							return 31;
						case 194:
							return 21;
						case 195:
							return 16;
						default:
							if (num == 225)
							{
								return 46;
							}
							break;
						}
					}
				}
				else if (num <= 290)
				{
					if (num <= 257)
					{
						if (num == 226)
						{
							return 9;
						}
						if (num == 257)
						{
							return 14;
						}
					}
					else
					{
						if (num == 289)
						{
							return 15;
						}
						if (num == 290)
						{
							return 18;
						}
					}
				}
				else if (num <= 353)
				{
					if (num == 321)
					{
						return 0;
					}
					if (num == 353)
					{
						return 20;
					}
				}
				else
				{
					if (num == 354)
					{
						return 32;
					}
					switch (num)
					{
					case 385:
						return 30;
					case 386:
						return 40;
					case 387:
						return 45;
					case 388:
						return 50;
					}
				}
				return 0;
			}

			// Token: 0x06000F56 RID: 3926 RVA: 0x00106A38 File Offset: 0x00104C38
			public static List<int> processAchievements(List<int> achievements, bool addUnEarned)
			{
				if (achievements == null)
				{
					achievements = new List<int>();
				}
				List<int> list = new List<int>();
				foreach (int num in achievements)
				{
					int num2 = num & 268435455;
					int num3 = num & 1879048192;
					bool flag = false;
					for (int i = 0; i < list.Count; i++)
					{
						int num4 = list[i];
						int num5 = num4 & 268435455;
						if (num5 == num2)
						{
							int num6 = num4 & 1879048192;
							if (num3 > num6)
							{
								list[i] = num;
							}
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						list.Add(num);
					}
				}
				list.Sort(CustomSelfDrawPanel.MedalWindow.achievementComparer);
				if (addUnEarned)
				{
					List<int> list2 = new List<int>();
					foreach (int num7 in list)
					{
						int item = num7 & 268435455;
						list2.Add(item);
					}
					List<int> list3 = new List<int>();
					int[] array = CustomSelfDrawPanel.MedalWindow.activeAchievements;
					foreach (int item2 in array)
					{
						if (!list2.Contains(item2))
						{
							list3.Add(item2);
						}
					}
					if (list3.Count > 1)
					{
						list3.Sort(CustomSelfDrawPanel.MedalWindow.achievementComparer);
						list3.Reverse();
					}
					for (int k = 0; k < list3.Count; k++)
					{
						list3[k] = -list3[k];
					}
					list.AddRange(list3);
				}
				return list;
			}

			// Token: 0x06000F57 RID: 3927 RVA: 0x000111BA File Offset: 0x0000F3BA
			public void setChildWindow(CustomSelfDrawPanel.MedalWindow child)
			{
				this._childWindow = child;
			}

			// Token: 0x06000F58 RID: 3928 RVA: 0x00106BEC File Offset: 0x00104DEC
			public void achievementClicked(int achievement)
			{
				if (this._childWindow != null)
				{
					List<int> list = new List<int>();
					list.Add(achievement);
					this._childWindow.init(list, false, false, -150);
					this._childWindow.Visible = true;
				}
			}

			// Token: 0x04001306 RID: 4870
			private const int ach_area_x = 0;

			// Token: 0x04001307 RID: 4871
			private const int ach_area_y = 30;

			// Token: 0x04001308 RID: 4872
			private CustomSelfDrawPanel.CSDLabel achievementsLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04001309 RID: 4873
			private CustomSelfDrawPanel.CSDVertScrollBar scrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

			// Token: 0x0400130A RID: 4874
			private CustomSelfDrawPanel.CSDArea scrollArea = new CustomSelfDrawPanel.CSDArea();

			// Token: 0x0400130B RID: 4875
			private CustomSelfDrawPanel.CSDImage scrollImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x0400130C RID: 4876
			private CustomSelfDrawPanel.CSDArea scrollArea2 = new CustomSelfDrawPanel.CSDArea();

			// Token: 0x0400130D RID: 4877
			private CustomSelfDrawPanel.CSDControl mouseWheelOverlay = new CustomSelfDrawPanel.CSDControl();

			// Token: 0x0400130E RID: 4878
			private CustomSelfDrawPanel.CSDImage ach_top_overlay = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x0400130F RID: 4879
			private CustomSelfDrawPanel.CSDImage ach_bottom_overlay = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001310 RID: 4880
			private CustomSelfDrawPanel.CSDImage ach_top_inset = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001311 RID: 4881
			private CustomSelfDrawPanel.CSDImage popupOverlayImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001312 RID: 4882
			private CustomSelfDrawPanel.MedalImage medal1 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x04001313 RID: 4883
			private CustomSelfDrawPanel.MedalImage medal2 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x04001314 RID: 4884
			private CustomSelfDrawPanel.MedalImage medal3 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x04001315 RID: 4885
			private CustomSelfDrawPanel.MedalImage medal4 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x04001316 RID: 4886
			private CustomSelfDrawPanel.MedalImage medal5 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x04001317 RID: 4887
			private CustomSelfDrawPanel.MedalImage medal6 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x04001318 RID: 4888
			private CustomSelfDrawPanel.MedalImage medal7 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x04001319 RID: 4889
			private CustomSelfDrawPanel.MedalImage medal8 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x0400131A RID: 4890
			private CustomSelfDrawPanel.MedalImage medal9 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x0400131B RID: 4891
			private CustomSelfDrawPanel.MedalImage medal10 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x0400131C RID: 4892
			private CustomSelfDrawPanel.MedalImage medal11 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x0400131D RID: 4893
			private CustomSelfDrawPanel.MedalImage medal12 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x0400131E RID: 4894
			private CustomSelfDrawPanel.MedalImage medal13 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x0400131F RID: 4895
			private CustomSelfDrawPanel.MedalImage medal14 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x04001320 RID: 4896
			private CustomSelfDrawPanel.MedalImage medal15 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x04001321 RID: 4897
			private CustomSelfDrawPanel.MedalImage medal16 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x04001322 RID: 4898
			private CustomSelfDrawPanel.MedalImage medal17 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x04001323 RID: 4899
			private CustomSelfDrawPanel.MedalImage medal18 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x04001324 RID: 4900
			private CustomSelfDrawPanel.MedalImage medal19 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x04001325 RID: 4901
			private CustomSelfDrawPanel.MedalImage medal20 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x04001326 RID: 4902
			private CustomSelfDrawPanel.MedalImage medal21 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x04001327 RID: 4903
			private CustomSelfDrawPanel.MedalImage medal22 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x04001328 RID: 4904
			private CustomSelfDrawPanel.MedalImage medal23 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x04001329 RID: 4905
			private CustomSelfDrawPanel.MedalImage medal24 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x0400132A RID: 4906
			private CustomSelfDrawPanel.MedalImage medal25 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x0400132B RID: 4907
			private CustomSelfDrawPanel.MedalImage medal26 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x0400132C RID: 4908
			private CustomSelfDrawPanel.MedalImage medal27 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x0400132D RID: 4909
			private CustomSelfDrawPanel.MedalImage medal28 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x0400132E RID: 4910
			private CustomSelfDrawPanel.MedalImage medal29 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x0400132F RID: 4911
			private CustomSelfDrawPanel.MedalImage medal30 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x04001330 RID: 4912
			private CustomSelfDrawPanel.MedalImage medal31 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x04001331 RID: 4913
			private CustomSelfDrawPanel.MedalImage medal32 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x04001332 RID: 4914
			private CustomSelfDrawPanel.MedalImage medal33 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x04001333 RID: 4915
			private CustomSelfDrawPanel.MedalImage medal34 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x04001334 RID: 4916
			private CustomSelfDrawPanel.MedalImage medal35 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x04001335 RID: 4917
			private CustomSelfDrawPanel.MedalImage medal36 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x04001336 RID: 4918
			private CustomSelfDrawPanel.MedalImage medal37 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x04001337 RID: 4919
			private CustomSelfDrawPanel.MedalImage medal38 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x04001338 RID: 4920
			private CustomSelfDrawPanel.MedalImage medal39 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x04001339 RID: 4921
			private CustomSelfDrawPanel.MedalImage medal40 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x0400133A RID: 4922
			private CustomSelfDrawPanel.MedalImage medal41 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x0400133B RID: 4923
			private CustomSelfDrawPanel.MedalImage medal42 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x0400133C RID: 4924
			private CustomSelfDrawPanel.MedalImage medal43 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x0400133D RID: 4925
			private CustomSelfDrawPanel.MedalImage medal44 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x0400133E RID: 4926
			private CustomSelfDrawPanel.MedalImage medal45 = new CustomSelfDrawPanel.MedalImage();

			// Token: 0x0400133F RID: 4927
			public bool ownPlayer = true;

			// Token: 0x04001340 RID: 4928
			private string fb_title = "";

			// Token: 0x04001341 RID: 4929
			private string fb_caption = "";

			// Token: 0x04001342 RID: 4930
			private int fb_achievement;

			// Token: 0x04001343 RID: 4931
			private static int[] activeAchievements = new int[]
			{
				1,
				2,
				5,
				11,
				12,
				13,
				14,
				34,
				37,
				163,
				226,
				257,
				289,
				4,
				6,
				7,
				8,
				9,
				15,
				16,
				10,
				3,
				65,
				66,
				67,
				129,
				131,
				130,
				290,
				162,
				161,
				354,
				353,
				101,
				100,
				388,
				386,
				387,
				385,
				225,
				194,
				195,
				321
			};

			// Token: 0x04001344 RID: 4932
			private CustomSelfDrawPanel.MedalWindow _childWindow;

			// Token: 0x04001345 RID: 4933
			public static CustomSelfDrawPanel.MedalWindow.AchievementComparer achievementComparer = new CustomSelfDrawPanel.MedalWindow.AchievementComparer();

			// Token: 0x0200018D RID: 397
			public class AchievementComparer : IComparer<int>
			{
				// Token: 0x06000F5B RID: 3931 RVA: 0x00106EC0 File Offset: 0x001050C0
				public int Compare(int x, int y)
				{
					int num = x & 1879048192;
					int num2 = y & 1879048192;
					if (num < num2)
					{
						return 1;
					}
					if (num > num2)
					{
						return -1;
					}
					int achievement = x & 268435455;
					int achievement2 = y & 268435455;
					int achievementRanking = CustomSelfDrawPanel.MedalWindow.getAchievementRanking(achievement);
					int achievementRanking2 = CustomSelfDrawPanel.MedalWindow.getAchievementRanking(achievement2);
					if (achievementRanking < achievementRanking2)
					{
						return 1;
					}
					if (achievementRanking > achievementRanking2)
					{
						return -1;
					}
					return 0;
				}
			}
		}

		// Token: 0x0200018E RID: 398
		public class ResourceButton : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06000F5D RID: 3933 RVA: 0x00106F1C File Offset: 0x0010511C
			public void init(int resource, LogoutPanel logoutParent)
			{
				this.m_logoutParent = logoutParent;
				this.baseButton.ImageNorm = GFXLibrary.logout_bits[7];
				this.baseButton.ImageOver = GFXLibrary.logout_bits[8];
				this.baseButton.Position = new Point(0, 1);
				this.baseButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.buttonClicked), "SelectTradingResourcePanel_resource");
				this.baseButton.Data = resource;
				base.addControl(this.baseButton);
				this.baseButton.CustomTooltipID = 1417;
				this.baseButton.CustomTooltipData = resource;
				this.Size = this.baseButton.Size;
				this.resourceImage.Image = GFXLibrary.getCommodity64DSImage(resource);
				this.resourceImage.Data = resource;
				this.resourceImage.Position = new Point(0, 0);
				this.resourceImage.Size = new Size(69, 69);
				this.baseButton.addControl(this.resourceImage);
			}

			// Token: 0x06000F5E RID: 3934 RVA: 0x0010702C File Offset: 0x0010522C
			public void buttonClicked()
			{
				if (base.csd.ClickedControl != null)
				{
					CustomSelfDrawPanel.CSDControl clickedControl = base.csd.ClickedControl;
					int data = clickedControl.Data;
					if (this.m_logoutParent != null)
					{
						this.m_logoutParent.resourceSelected(data);
					}
				}
			}

			// Token: 0x04001346 RID: 4934
			private CustomSelfDrawPanel.CSDButton baseButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x04001347 RID: 4935
			private CustomSelfDrawPanel.CSDImage resourceImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001348 RID: 4936
			private LogoutPanel m_logoutParent;
		}

		// Token: 0x0200018F RID: 399
		public class MRHP_Background : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06000F60 RID: 3936 RVA: 0x00011204 File Offset: 0x0000F404
			public CustomSelfDrawPanel.CSDImage init(bool tall, int villageBackgroundType)
			{
				return this.init(tall, villageBackgroundType, "", "", "");
			}

			// Token: 0x06000F61 RID: 3937 RVA: 0x00107070 File Offset: 0x00105270
			public CustomSelfDrawPanel.CSDImage init(bool tall, int villageBackgroundType, string heading, string subHeading, string panelText)
			{
				this.headingVillageID = -1;
				this.Size = new Size(199, 213);
				this.clearControls();
				this.avatarUnderlayImage.Image = GFXLibrary.mrhp_avatar_frame;
				this.avatarUnderlayImage.Position = new Point(0, 182);
				this.avatarUnderlayImage.ClipRect = new Rectangle(0, 0, 200, 31);
				base.addControl(this.avatarUnderlayImage);
				if (!tall)
				{
					this.backGroundImage.Image = GFXLibrary.mrhp_world_panel_102;
				}
				else
				{
					this.backGroundImage.Image = GFXLibrary.mrhp_world_panel_192;
				}
				this.backGroundImage.Position = new Point(6, 20);
				base.addControl(this.backGroundImage);
				this.headerImage.Image = GFXLibrary.mrhp_location_portrait[10];
				this.headerImage.Position = new Point(-1, -17);
				this.backGroundImage.addControl(this.headerImage);
				this.headerGlowLong.Image = GFXLibrary.mrhp_location_portrait_glow_long;
				this.headerGlowLong.Position = new Point(45, 10);
				this.headerImage.addControl(this.headerGlowLong);
				this.headerGlowSmall.Image = GFXLibrary.mrhp_location_portrait_glow_short;
				this.headerGlowSmall.Position = new Point(0, -9);
				this.headerImage.addControl(this.headerGlowSmall);
				this.headerIcon.Image = GFXLibrary.wl_moving_unit_icons[0];
				this.headerIcon.Position = new Point(17, 26);
				this.headerGlowSmall.addControl(this.headerIcon);
				this.actionIcon.Image = GFXLibrary.wl_moving_unit_icons[0];
				this.actionIcon.Position = new Point(141, 17);
				this.actionIcon.Visible = false;
				this.headerImage.addControl(this.actionIcon);
				this.headingLabel.Text = "";
				this.headingLabel.Color = global::ARGBColors.Black;
				this.headingLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
				this.headingLabel.Position = new Point(14, 5);
				this.headingLabel.Size = new Size(168, 23);
				this.headingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.headingLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.headingClicked), "MRHP_Background_heading");
				this.headerImage.addControl(this.headingLabel);
				this.subHeadingLabel.Text = "";
				this.subHeadingLabel.Color = global::ARGBColors.Black;
				this.subHeadingLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
				this.subHeadingLabel.Position = new Point(12, 18);
				this.subHeadingLabel.Size = new Size(132, 20);
				this.subHeadingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.headerGlowLong.addControl(this.subHeadingLabel);
				this.panelLabel.Text = "";
				this.panelLabel.Color = global::ARGBColors.Black;
				this.panelLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
				this.panelLabel.Position = new Point(0, 38);
				this.panelLabel.Size = new Size(this.backGroundImage.Width, 23);
				this.panelLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.backGroundImage.addControl(this.panelLabel);
				this.LastVillageType = -1;
				this.update(villageBackgroundType, heading, subHeading, panelText);
				return this.backGroundImage;
			}

			// Token: 0x06000F62 RID: 3938 RVA: 0x0001121D File Offset: 0x0000F41D
			public void stretchBackground()
			{
				this.Size = new Size(199, 273);
				this.backGroundImage.Size = new Size(GFXLibrary.mrhp_world_panel_192.Width, GFXLibrary.mrhp_world_panel_192.Height + 60);
			}

			// Token: 0x06000F63 RID: 3939 RVA: 0x0001125B File Offset: 0x0000F45B
			public void update()
			{
				if (this.avatarUnderlayImage.Visible != InterfaceMgr.Instance.isUserInfoVisible())
				{
					this.avatarUnderlayImage.Visible = InterfaceMgr.Instance.isUserInfoVisible();
					base.invalidate();
				}
			}

			// Token: 0x06000F64 RID: 3940 RVA: 0x0001128F File Offset: 0x0000F48F
			public void showFade(bool state)
			{
				this.avatarUnderlayImage.Visible = state;
			}

			// Token: 0x06000F65 RID: 3941 RVA: 0x0001129D File Offset: 0x0000F49D
			public void updateHeading(string heading)
			{
				this.headingVillageID = -1;
				this.update(this.LastVillageType, heading, this.subHeadingLabel.Text, this.panelLabel.Text);
			}

			// Token: 0x06000F66 RID: 3942 RVA: 0x000112C9 File Offset: 0x0000F4C9
			public void updateSubHeading(string subHeading)
			{
				this.update(this.LastVillageType, this.headingLabel.Text, subHeading, this.panelLabel.Text);
			}

			// Token: 0x06000F67 RID: 3943 RVA: 0x00107438 File Offset: 0x00105638
			public void centerSubHeading()
			{
				this.headerGlowLong.Position = new Point((this.backGroundImage.Image.Width - this.headerGlowLong.Image.Width) / 2 - 20, 10);
				this.headerGlowLong.Size = new Size(this.headerGlowLong.Image.Width + 40, this.headerGlowLong.Height);
				this.subHeadingLabel.Size = new Size(this.headerGlowLong.Size.Width - 24, 20);
			}

			// Token: 0x06000F68 RID: 3944 RVA: 0x000112EE File Offset: 0x0000F4EE
			public void updatePanelText(string panelText)
			{
				this.update(this.LastVillageType, this.headingLabel.Text, this.subHeadingLabel.Text, panelText);
			}

			// Token: 0x06000F69 RID: 3945 RVA: 0x00011313 File Offset: 0x0000F513
			public void updatePanelType(int villageBackgroundType)
			{
				this.update(villageBackgroundType, this.headingLabel.Text, this.subHeadingLabel.Text, this.panelLabel.Text);
			}

			// Token: 0x06000F6A RID: 3946 RVA: 0x001074D4 File Offset: 0x001056D4
			public void updatePanelTypeFromVillageID(int villageID)
			{
				this.headingVillageID = villageID;
				int num;
				if (!GameEngine.Instance.World.isSpecial(villageID))
				{
					num = (GameEngine.Instance.World.isRegionCapital(villageID) ? 1500 : (GameEngine.Instance.World.isCountyCapital(villageID) ? 1501 : (GameEngine.Instance.World.isProvinceCapital(villageID) ? 1502 : (GameEngine.Instance.World.isCountryCapital(villageID) ? 1503 : ((GameEngine.Instance.World.getVillageUserID(villageID) >= 0) ? (2000 + GameEngine.Instance.World.getVillageTerrainType(villageID)) : 1505)))));
				}
				else
				{
					num = GameEngine.Instance.World.getSpecial(villageID);
					if (GameEngine.Instance.LocalWorldData.AIWorld && num - 7 <= 7)
					{
						num = 2000 + GameEngine.Instance.World.getVillageTerrainType(villageID);
					}
				}
				this.updatePanelType(num);
			}

			// Token: 0x06000F6B RID: 3947 RVA: 0x001075E0 File Offset: 0x001057E0
			public void update(int villageBackgroundType, string heading, string subHeading, string panelText)
			{
				if (this.LastVillageType == villageBackgroundType && heading == this.headingLabel.Text && subHeading == this.subHeadingLabel.Text && this.panelLabel.Text == panelText)
				{
					return;
				}
				int customTooltipID = 0;
				int customTooltipData = 0;
				this.LastVillageType = villageBackgroundType;
				if (this.headingLabel.TextDiffOnly != heading)
				{
					int num = 0;
					Graphics graphics = InterfaceMgr.Instance.ParentForm.CreateGraphics();
					if (graphics.MeasureString(heading, FontManager.GetFont("Arial", 9f, FontStyle.Bold), 168).ToSize().Height > 18)
					{
						num = 1;
						if (graphics.MeasureString(heading, FontManager.GetFont("Arial", 8f, FontStyle.Bold), 168).ToSize().Height > 18)
						{
							num = 2;
							if (graphics.MeasureString(heading, FontManager.GetFont("Arial", 8f, FontStyle.Regular), 168).ToSize().Height > 18)
							{
								num = 3;
							}
						}
					}
					graphics.Dispose();
					switch (num)
					{
					case 0:
						this.headingLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
						this.headingLabel.Position = new Point(14, 5);
						this.headingLabel.Size = new Size(168, 23);
						this.headingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
						break;
					case 1:
						this.headingLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
						this.headingLabel.Position = new Point(14, 5);
						this.headingLabel.Size = new Size(168, 23);
						this.headingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
						break;
					case 2:
						this.headingLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
						this.headingLabel.Position = new Point(14, 5);
						this.headingLabel.Size = new Size(168, 23);
						this.headingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
						break;
					case 3:
						this.headingLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
						this.headingLabel.Position = new Point(18, 5);
						this.headingLabel.Size = new Size(500, 23);
						this.headingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
						break;
					}
				}
				this.headingLabel.TextDiffOnly = heading;
				this.subHeadingLabel.TextDiffOnly = subHeading;
				this.panelLabel.TextDiffOnly = panelText;
				if (subHeading.Length > 0)
				{
					this.headerGlowLong.Visible = true;
				}
				else
				{
					this.headerGlowLong.Visible = false;
				}
				this.headerIcon.Position = new Point(17, 26);
				if (villageBackgroundType <= 1006)
				{
					switch (villageBackgroundType)
					{
					case 3:
					case 4:
						this.headerImage.Image = GFXLibrary.mrhp_location_portrait[15];
						customTooltipID = 2424;
						this.headerGlowSmall.Visible = false;
						break;
					case 5:
					case 6:
						this.headerImage.Image = GFXLibrary.mrhp_location_portrait[16];
						customTooltipID = 2425;
						this.headerGlowSmall.Visible = false;
						break;
					case 7:
					case 8:
						this.headerImage.Image = GFXLibrary.mrhp_location_portrait[18];
						customTooltipID = 2426;
						this.headerGlowSmall.Visible = false;
						break;
					case 9:
					case 10:
						this.headerImage.Image = GFXLibrary.mrhp_location_portrait[18];
						customTooltipID = 2427;
						this.headerGlowSmall.Visible = false;
						break;
					case 11:
					case 12:
						this.headerImage.Image = GFXLibrary.mrhp_location_portrait[18];
						customTooltipID = 2428;
						this.headerGlowSmall.Visible = false;
						break;
					case 13:
					case 14:
						this.headerImage.Image = GFXLibrary.mrhp_location_portrait[18];
						customTooltipID = 2429;
						this.headerGlowSmall.Visible = false;
						break;
					case 15:
					case 16:
						this.headerImage.Image = GFXLibrary.mrhp_location_portrait[23];
						customTooltipID = 2447;
						this.headerGlowSmall.Visible = false;
						break;
					case 17:
					case 18:
						this.headerImage.Image = GFXLibrary.mrhp_location_portrait[23];
						customTooltipID = 2448;
						this.headerGlowSmall.Visible = false;
						break;
					case 19:
					case 22:
					case 23:
					case 24:
					case 25:
					case 26:
					case 27:
					case 28:
					case 29:
					case 31:
					case 32:
					case 33:
					case 34:
					case 35:
					case 36:
					case 37:
					case 38:
					case 39:
					case 91:
					case 92:
					case 93:
					case 94:
					case 95:
					case 96:
					case 97:
					case 98:
					case 99:
					case 101:
					case 102:
					case 103:
					case 104:
					case 105:
					case 110:
					case 111:
					case 120:
					case 127:
					case 134:
					case 135:
					case 136:
					case 137:
					case 138:
					case 139:
					case 140:
					case 141:
					case 142:
					case 143:
					case 144:
					case 145:
					case 146:
					case 147:
					case 148:
					case 149:
					case 150:
					case 151:
					case 152:
					case 153:
					case 154:
					case 155:
					case 156:
					case 157:
					case 158:
					case 159:
					case 160:
					case 161:
					case 162:
					case 163:
					case 164:
					case 165:
					case 166:
					case 167:
					case 168:
					case 169:
					case 170:
					case 171:
					case 172:
					case 173:
					case 174:
					case 175:
					case 176:
					case 177:
					case 178:
					case 179:
					case 180:
					case 181:
					case 182:
					case 183:
					case 184:
					case 185:
					case 186:
					case 187:
					case 188:
					case 189:
					case 190:
					case 191:
					case 192:
					case 193:
					case 194:
					case 195:
					case 196:
					case 197:
					case 198:
					case 199:
						break;
					case 20:
					case 21:
						this.headerImage.Image = GFXLibrary.mrhp_location_portrait[17];
						this.headerGlowSmall.Visible = false;
						break;
					case 30:
						this.headerImage.Image = GFXLibrary.mrhp_location_portrait[29];
						this.headerGlowSmall.Visible = false;
						break;
					case 40:
					case 41:
					case 42:
					case 43:
					case 44:
					case 45:
					case 46:
					case 47:
					case 48:
					case 49:
					case 50:
						this.headerImage.Image = GFXLibrary.mrhp_location_portrait[24];
						customTooltipID = 2449;
						customTooltipData = villageBackgroundType;
						this.headerGlowSmall.Visible = false;
						break;
					case 51:
					case 52:
					case 53:
					case 54:
					case 55:
					case 56:
					case 57:
					case 58:
					case 59:
					case 60:
						this.headerImage.Image = GFXLibrary.mrhp_location_portrait[25];
						customTooltipID = 2449;
						customTooltipData = villageBackgroundType;
						this.headerGlowSmall.Visible = false;
						break;
					case 61:
					case 62:
					case 63:
					case 64:
					case 65:
					case 66:
					case 67:
					case 68:
					case 69:
					case 70:
						this.headerImage.Image = GFXLibrary.mrhp_location_portrait[26];
						customTooltipID = 2449;
						customTooltipData = villageBackgroundType;
						this.headerGlowSmall.Visible = false;
						break;
					case 71:
					case 72:
					case 73:
					case 74:
					case 75:
					case 76:
					case 77:
					case 78:
					case 79:
					case 80:
						this.headerImage.Image = GFXLibrary.mrhp_location_portrait[27];
						customTooltipID = 2449;
						customTooltipData = villageBackgroundType;
						this.headerGlowSmall.Visible = false;
						break;
					case 81:
					case 82:
					case 83:
					case 84:
					case 85:
					case 86:
					case 87:
					case 88:
					case 89:
					case 90:
						this.headerImage.Image = GFXLibrary.mrhp_location_portrait[28];
						customTooltipID = 2449;
						customTooltipData = villageBackgroundType;
						this.headerGlowSmall.Visible = false;
						break;
					case 100:
					case 106:
					case 107:
					case 108:
					case 109:
					case 112:
					case 113:
					case 114:
					case 115:
					case 116:
					case 117:
					case 118:
					case 119:
					case 121:
					case 122:
					case 123:
					case 124:
					case 125:
					case 126:
					case 128:
					case 129:
					case 130:
					case 131:
					case 132:
					case 133:
						if (villageBackgroundType != 100)
						{
							this.headerIcon.Image = GFXLibrary.getCommodity32DSImage(villageBackgroundType - 100);
							this.headerGlowSmall.Visible = true;
						}
						else
						{
							this.headerIcon.Position = new Point(-19, -3);
							if (!HolidayPeriods.xmas(VillageMap.getCurrentServerTime()))
							{
								this.headerIcon.Image = GFXLibrary.scout_screen_icons[29];
							}
							else
							{
								this.headerIcon.Image = GFXLibrary.scout_screen_icons[59];
							}
							this.headerGlowSmall.Visible = true;
						}
						customTooltipData = villageBackgroundType;
						customTooltipID = 2430;
						break;
					case 200:
					case 201:
					case 202:
					case 203:
					case 204:
					case 205:
					case 206:
					case 207:
					case 208:
					case 209:
					case 210:
					case 211:
					case 212:
					case 213:
					case 214:
					case 215:
					case 216:
					case 217:
					case 218:
					case 219:
					case 220:
						this.headerImage.Image = GFXLibrary.mrhp_location_portrait[30 + (villageBackgroundType - 200)];
						this.headerGlowSmall.Visible = false;
						break;
					default:
						switch (villageBackgroundType)
						{
						case 1000:
							this.headerImage.Image = GFXLibrary.mrhp_location_portrait[10];
							this.headerIcon.Image = GFXLibrary.mrhp_world_icons_rhs_array[1];
							this.headerGlowSmall.Visible = true;
							break;
						case 1001:
							this.headerImage.Image = GFXLibrary.mrhp_location_portrait[10];
							this.headerIcon.Image = GFXLibrary.mrhp_world_icons_rhs_array[4];
							this.headerGlowSmall.Visible = true;
							break;
						case 1002:
							this.headerImage.Image = GFXLibrary.mrhp_location_portrait[10];
							this.headerIcon.Image = GFXLibrary.mrhp_world_icons_rhs_array[3];
							this.headerGlowSmall.Visible = true;
							break;
						case 1003:
							this.headerImage.Image = GFXLibrary.mrhp_location_portrait[10];
							this.headerIcon.Image = GFXLibrary.mrhp_world_icons_rhs_array[2];
							this.headerGlowSmall.Visible = true;
							break;
						case 1004:
							this.headerImage.Image = GFXLibrary.mrhp_location_portrait[10];
							this.headerIcon.Image = GFXLibrary.mrhp_world_icons_rhs_array[0];
							this.headerGlowSmall.Visible = true;
							break;
						case 1005:
							this.headerImage.Image = GFXLibrary.mrhp_location_portrait[10];
							this.headerIcon.Image = GFXLibrary.mrhp_world_icons_rhs_array[5];
							this.headerGlowSmall.Visible = true;
							break;
						case 1006:
							this.headerImage.Image = GFXLibrary.mrhp_location_portrait[10];
							this.headerIcon.Image = GFXLibrary.mrhp_world_icons_rhs_array[21];
							this.headerGlowSmall.Visible = true;
							break;
						}
						break;
					}
				}
				else
				{
					switch (villageBackgroundType)
					{
					case 1500:
						this.headerImage.Image = GFXLibrary.mrhp_location_portrait[11];
						this.headerGlowSmall.Visible = false;
						customTooltipID = 2420;
						break;
					case 1501:
						this.headerImage.Image = GFXLibrary.mrhp_location_portrait[12];
						this.headerGlowSmall.Visible = false;
						customTooltipID = 2421;
						break;
					case 1502:
						this.headerImage.Image = GFXLibrary.mrhp_location_portrait[13];
						this.headerGlowSmall.Visible = false;
						customTooltipID = 2422;
						break;
					case 1503:
						this.headerImage.Image = GFXLibrary.mrhp_location_portrait[14];
						this.headerGlowSmall.Visible = false;
						customTooltipID = 2423;
						break;
					case 1504:
						this.headerImage.Image = GFXLibrary.mrhp_location_portrait[20];
						this.headerGlowSmall.Visible = false;
						customTooltipID = 2450;
						break;
					case 1505:
						this.headerImage.Image = GFXLibrary.mrhp_location_portrait[21];
						this.headerGlowSmall.Visible = false;
						customTooltipID = 2444;
						break;
					case 1506:
						this.headerImage.Image = GFXLibrary.mrhp_location_portrait[22];
						this.headerGlowSmall.Visible = false;
						break;
					default:
						if (villageBackgroundType - 2000 > 9)
						{
							if (villageBackgroundType == 10000)
							{
								this.headerImage.Image = GFXLibrary.mrhp_location_portrait[10];
								this.headerGlowSmall.Visible = false;
							}
						}
						else
						{
							this.headerImage.Image = GFXLibrary.mrhp_location_portrait[this.remapTerrainToGFX(villageBackgroundType - 2000)];
							this.headerGlowSmall.Visible = false;
							customTooltipID = 2436;
							customTooltipData = villageBackgroundType - 2000;
						}
						break;
					}
				}
				this.headerImage.CustomTooltipID = customTooltipID;
				this.headerImage.CustomTooltipData = customTooltipData;
			}

			// Token: 0x06000F6C RID: 3948 RVA: 0x0001133D File Offset: 0x0000F53D
			public void hideBackground()
			{
				this.backGroundImage.Size = new Size(1, 1);
			}

			// Token: 0x06000F6D RID: 3949 RVA: 0x001083BC File Offset: 0x001065BC
			public void setAction(int action)
			{
				this.actionIcon.Position = new Point(141, 17);
				this.actionIcon.Visible = (action != 10000);
				switch (action)
				{
				case 1000:
					this.actionIcon.Image = GFXLibrary.mrhp_world_icons_rhs_array[1];
					return;
				case 1001:
					this.actionIcon.Image = GFXLibrary.mrhp_world_icons_rhs_array[4];
					return;
				case 1002:
					this.actionIcon.Image = GFXLibrary.mrhp_world_icons_rhs_array[3];
					return;
				case 1003:
					this.actionIcon.Image = GFXLibrary.mrhp_world_icons_rhs_array[2];
					return;
				case 1004:
					this.actionIcon.Image = GFXLibrary.mrhp_world_icons_rhs_array[0];
					return;
				case 1005:
					this.actionIcon.Image = GFXLibrary.mrhp_world_icons_rhs_array[5];
					return;
				default:
					return;
				}
			}

			// Token: 0x06000F6E RID: 3950 RVA: 0x001084AC File Offset: 0x001066AC
			public void setActionFromVillage(int selectedVillage, int targetVillage)
			{
				this.actionIcon.Position = new Point(141, 17);
				if (targetVillage < 0)
				{
					if (GameEngine.Instance.World.isUserVillage(selectedVillage))
					{
						this.actionIcon.Image = GFXLibrary.mrhp_world_icons_rhs_array[24];
						this.actionIcon.Visible = true;
						return;
					}
					if (GameEngine.Instance.World.isUserRelatedVillage(selectedVillage))
					{
						this.actionIcon.Image = GFXLibrary.mrhp_world_icons_rhs_array[27];
						this.actionIcon.Visible = true;
						return;
					}
				}
				else
				{
					if (GameEngine.Instance.World.isUserVillage(targetVillage))
					{
						this.actionIcon.Image = GFXLibrary.mrhp_world_icons_rhs_array[24];
						this.actionIcon.Visible = true;
						return;
					}
					if (GameEngine.Instance.World.isUserRelatedVillage(targetVillage))
					{
						this.actionIcon.Image = GFXLibrary.mrhp_world_icons_rhs_array[27];
						this.actionIcon.Visible = true;
						return;
					}
					if (GameEngine.Instance.World.isVassal(selectedVillage, targetVillage))
					{
						this.actionIcon.Image = GFXLibrary.mrhp_world_icons_rhs_array[30];
						this.actionIcon.Visible = true;
						return;
					}
					if (GameEngine.Instance.World.isVassal(targetVillage, selectedVillage))
					{
						this.actionIcon.Image = GFXLibrary.mrhp_world_icons_rhs_array[33];
						this.actionIcon.Visible = true;
						return;
					}
					int num = 0;
					VillageData villageData = GameEngine.Instance.World.getVillageData(targetVillage);
					if (villageData != null && villageData.factionID >= 0 && RemoteServices.Instance.UserFactionID >= 0)
					{
						if (villageData.factionID != RemoteServices.Instance.UserFactionID)
						{
							int house = GameEngine.Instance.World.getHouse(RemoteServices.Instance.UserFactionID);
							int house2 = GameEngine.Instance.World.getHouse(villageData.factionID);
							if (house != house2)
							{
								int yourHouseRelation = GameEngine.Instance.World.getYourHouseRelation(house2);
								if (yourHouseRelation > 0)
								{
									num = 1;
								}
								else if (yourHouseRelation < 0)
								{
									num = -1;
								}
							}
							if (num == 0)
							{
								int yourFactionRelation = GameEngine.Instance.World.getYourFactionRelation(villageData.factionID);
								if (yourFactionRelation > 0)
								{
									num = 1;
								}
								else if (yourFactionRelation < 0)
								{
									num = -1;
								}
							}
						}
						else
						{
							num = 2;
						}
					}
					switch (num)
					{
					case -1:
						this.actionIcon.Image = GFXLibrary.faction_relationships[2];
						this.actionIcon.Visible = true;
						this.actionIcon.Position = new Point(141, 20);
						return;
					case 1:
						this.actionIcon.Image = GFXLibrary.faction_relationships[0];
						this.actionIcon.Visible = true;
						this.actionIcon.Position = new Point(141, 20);
						return;
					case 2:
						this.actionIcon.Image = GFXLibrary.faction_relationships[1];
						this.actionIcon.Visible = true;
						this.actionIcon.Position = new Point(141, 20);
						return;
					}
				}
				this.actionIcon.Visible = false;
			}

			// Token: 0x06000F6F RID: 3951 RVA: 0x00011351 File Offset: 0x0000F551
			public void setTooltipData(int tooltipData)
			{
				this.headerImage.CustomTooltipData = tooltipData;
			}

			// Token: 0x06000F70 RID: 3952 RVA: 0x0001135F File Offset: 0x0000F55F
			private void headingClicked()
			{
				if (this.headingVillageID >= 0)
				{
					GameEngine.Instance.World.zoomToVillage(this.headingVillageID);
				}
			}

			// Token: 0x06000F71 RID: 3953 RVA: 0x001087CC File Offset: 0x001069CC
			public void initTravelButton(CustomSelfDrawPanel.CSDButton button)
			{
				button.ImageNorm = GFXLibrary.mrhp_travelling_buttons[0];
				button.ImageOver = GFXLibrary.mrhp_travelling_buttons[1];
				button.ImageClick = GFXLibrary.mrhp_travelling_buttons[2];
				button.Text.TextDiffOnly = "";
				button.Text.Color = global::ARGBColors.Black;
				button.Text.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
				button.Text.Size = new Size(130, 52);
				button.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				button.Text.Position = new Point(40, -9);
				button.ImageIcon = GFXLibrary.mrhp_village_type_miniicons[0];
				button.ImageIconPosition = new Point(10, 0);
			}

			// Token: 0x06000F72 RID: 3954 RVA: 0x0001137F File Offset: 0x0000F57F
			public void updateTravelButton(CustomSelfDrawPanel.CSDButton button, string villageString)
			{
				button.Text.TextDiffOnly = villageString;
				button.ImageIcon = GFXLibrary.scout_screen_icons[26];
				button.ImageIconPosition = new Point(-26, -33);
			}

			// Token: 0x06000F73 RID: 3955 RVA: 0x001088A4 File Offset: 0x00106AA4
			public void updateTravelButton(CustomSelfDrawPanel.CSDButton button, int villageID)
			{
				try
				{
					string villageNameOrType = GameEngine.Instance.World.getVillageNameOrType(villageID);
					int num = 0;
					Graphics graphics = InterfaceMgr.Instance.ParentForm.CreateGraphics();
					Size size = graphics.MeasureString(villageNameOrType, button.Text.Font, 98).ToSize();
					if (size.Height > 18)
					{
						num = 1;
						size = graphics.MeasureString(villageNameOrType, button.Text.Font, 128).ToSize();
						if (size.Height > 18)
						{
							num = 2;
						}
					}
					switch (num)
					{
					case 0:
						button.Text.Size = new Size(100, 52);
						button.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
						button.Text.Position = new Point(40, -9);
						break;
					case 1:
						button.Text.Size = new Size(130, 52);
						button.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
						button.Text.Position = new Point(40, -9);
						break;
					case 2:
						if (size.Width < 126)
						{
							button.Text.Size = new Size(size.Width + 4, 52);
						}
						else
						{
							button.Text.Size = new Size(130, 52);
						}
						button.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
						button.Text.Position = new Point(40, -9);
						break;
					}
					graphics.Dispose();
					button.Text.TextDiffOnly = villageNameOrType;
					if (GameEngine.Instance.World.isSpecial(villageID))
					{
						int special = GameEngine.Instance.World.getSpecial(villageID);
						switch (special)
						{
						case 3:
						case 4:
							button.ImageIcon = GFXLibrary.scout_screen_icons[24];
							button.ImageIconPosition = new Point(-26, -33);
							break;
						case 5:
						case 6:
							button.ImageIcon = GFXLibrary.scout_screen_icons[25];
							button.ImageIconPosition = new Point(-18, -35);
							break;
						case 7:
						case 8:
							button.ImageIcon = GFXLibrary.scout_screen_icons[28];
							button.ImageIconPosition = new Point(-26, -31);
							break;
						case 9:
						case 10:
							button.ImageIcon = GFXLibrary.scout_screen_icons[28];
							button.ImageIconPosition = new Point(-26, -31);
							break;
						case 11:
						case 12:
							button.ImageIcon = GFXLibrary.scout_screen_icons[28];
							button.ImageIconPosition = new Point(-26, -31);
							break;
						case 13:
						case 14:
							button.ImageIcon = GFXLibrary.scout_screen_icons[28];
							button.ImageIconPosition = new Point(-26, -31);
							break;
						case 15:
						case 16:
							button.ImageIcon = GFXLibrary.scout_screen_icons[53];
							button.ImageIconPosition = new Point(-26, -31);
							break;
						case 17:
						case 18:
							button.ImageIcon = GFXLibrary.scout_screen_icons[53];
							button.ImageIconPosition = new Point(-26, -31);
							break;
						case 20:
						case 21:
							button.ImageIcon = GFXLibrary.scout_screen_icons[26];
							button.ImageIconPosition = new Point(-26, -33);
							break;
						case 40:
						case 41:
						case 42:
						case 43:
						case 44:
						case 45:
						case 46:
						case 47:
						case 48:
						case 49:
						case 50:
							button.ImageIcon = GFXLibrary.scout_screen_icons[54];
							button.ImageIconPosition = new Point(-26, -31);
							break;
						case 51:
						case 52:
						case 53:
						case 54:
						case 55:
						case 56:
						case 57:
						case 58:
						case 59:
						case 60:
							button.ImageIcon = GFXLibrary.scout_screen_icons[55];
							button.ImageIconPosition = new Point(-26, -31);
							break;
						case 61:
						case 62:
						case 63:
						case 64:
						case 65:
						case 66:
						case 67:
						case 68:
						case 69:
						case 70:
							button.ImageIcon = GFXLibrary.scout_screen_icons[56];
							button.ImageIconPosition = new Point(-26, -31);
							break;
						case 71:
						case 72:
						case 73:
						case 74:
						case 75:
						case 76:
						case 77:
						case 78:
						case 79:
						case 80:
							button.ImageIcon = GFXLibrary.scout_screen_icons[57];
							button.ImageIconPosition = new Point(-26, -31);
							break;
						case 81:
						case 82:
						case 83:
						case 84:
						case 85:
						case 86:
						case 87:
						case 88:
						case 89:
						case 90:
							button.ImageIcon = GFXLibrary.scout_screen_icons[58];
							button.ImageIconPosition = new Point(-26, -31);
							break;
						case 100:
							if (!HolidayPeriods.xmas(VillageMap.getCurrentServerTime()))
							{
								button.ImageIcon = GFXLibrary.scout_screen_icons[29];
							}
							else
							{
								button.ImageIcon = GFXLibrary.scout_screen_icons[59];
							}
							button.ImageIconPosition = new Point(-31, -33);
							break;
						case 106:
						case 107:
						case 108:
						case 109:
						case 112:
						case 113:
						case 114:
						case 115:
						case 116:
						case 117:
						case 118:
						case 119:
						case 121:
						case 122:
						case 123:
						case 124:
						case 125:
						case 126:
						case 133:
							button.ImageIcon = GFXLibrary.getCommodity32DSImage(special - 100);
							button.ImageIconPosition = new Point(6, -7);
							break;
						case 200:
						case 201:
						case 202:
						case 203:
						case 204:
						case 205:
						case 206:
						case 207:
						case 208:
						case 209:
						case 210:
						case 211:
						case 212:
						case 213:
						case 214:
						case 215:
						case 216:
						case 217:
						case 218:
						case 219:
						case 220:
							button.ImageIcon = GFXLibrary.scout_screen_icons[65];
							button.ImageIconPosition = new Point(-26, -31);
							break;
						}
					}
					else if (GameEngine.Instance.World.isRegionCapital(villageID))
					{
						button.ImageIcon = GFXLibrary.parishwall_village_center_achievement_icons[8];
						button.ImageIconPosition = new Point(-6, -16);
					}
					else if (GameEngine.Instance.World.isCountyCapital(villageID))
					{
						button.ImageIcon = GFXLibrary.parishwall_village_center_achievement_icons[9];
						button.ImageIconPosition = new Point(-6, -16);
					}
					else if (GameEngine.Instance.World.isProvinceCapital(villageID))
					{
						button.ImageIcon = GFXLibrary.parishwall_village_center_achievement_icons[10];
						button.ImageIconPosition = new Point(-6, -16);
					}
					else if (GameEngine.Instance.World.isCountryCapital(villageID))
					{
						button.ImageIcon = GFXLibrary.parishwall_village_center_achievement_icons[11];
						button.ImageIconPosition = new Point(-6, -16);
					}
					else
					{
						button.ImageIcon = GFXLibrary.mrhp_village_type_miniicons[this.remapTerrainToGFX(GameEngine.Instance.World.getVillageTerrainType(villageID)) * 3];
						button.ImageIconPosition = new Point(10, 0);
					}
				}
				catch (Exception)
				{
				}
			}

			// Token: 0x06000F74 RID: 3956 RVA: 0x000113AF File Offset: 0x0000F5AF
			private int remapTerrainToGFX(int type)
			{
				switch (type)
				{
				case 2:
					return 3;
				case 3:
					return 4;
				case 4:
					return 2;
				default:
					return type;
				}
			}

			// Token: 0x06000F75 RID: 3957 RVA: 0x000113CE File Offset: 0x0000F5CE
			public CustomSelfDrawPanel.WikiLinkControl addWikiLink(int id)
			{
				return CustomSelfDrawPanel.WikiLinkControl.init(this.headerImage, id, new Point(150, 21));
			}

			// Token: 0x06000F76 RID: 3958 RVA: 0x000113E8 File Offset: 0x0000F5E8
			public void removeWikiLink(CustomSelfDrawPanel.WikiLinkControl wikiLink)
			{
				if (wikiLink != null)
				{
					this.headerImage.removeControl(wikiLink);
				}
			}

			// Token: 0x04001349 RID: 4937
			public const int HEADER_TYPE_NONE = 10000;

			// Token: 0x0400134A RID: 4938
			public const int HEADER_TYPE_ATTACK = 1000;

			// Token: 0x0400134B RID: 4939
			public const int HEADER_TYPE_MONK = 1001;

			// Token: 0x0400134C RID: 4940
			public const int HEADER_TYPE_SCOUT = 1002;

			// Token: 0x0400134D RID: 4941
			public const int HEADER_TYPE_REINFORCEMENT = 1003;

			// Token: 0x0400134E RID: 4942
			public const int HEADER_TYPE_TRADE = 1004;

			// Token: 0x0400134F RID: 4943
			public const int HEADER_TYPE_VASSAL = 1005;

			// Token: 0x04001350 RID: 4944
			public const int HEADER_TYPE_RAT = 1006;

			// Token: 0x04001351 RID: 4945
			public const int HEADER_TYPE_PARISH = 1500;

			// Token: 0x04001352 RID: 4946
			public const int HEADER_TYPE_COUNTY = 1501;

			// Token: 0x04001353 RID: 4947
			public const int HEADER_TYPE_PROVINCE = 1502;

			// Token: 0x04001354 RID: 4948
			public const int HEADER_TYPE_COUNTRY = 1503;

			// Token: 0x04001355 RID: 4949
			public const int HEADER_TYPE_PARISH_PLAGUE = 1504;

			// Token: 0x04001356 RID: 4950
			public const int HEADER_TYPE_CHARTER = 1505;

			// Token: 0x04001357 RID: 4951
			public const int HEADER_TYPE_FILTER = 1506;

			// Token: 0x04001358 RID: 4952
			public const int HEADER_TYPE_TERRAIN_LOWLAND = 2000;

			// Token: 0x04001359 RID: 4953
			public const int HEADER_TYPE_TERRAIN_HIGHLAND = 2001;

			// Token: 0x0400135A RID: 4954
			public const int HEADER_TYPE_TERRAIN_MOUNTAIN_PEAK = 2002;

			// Token: 0x0400135B RID: 4955
			public const int HEADER_TYPE_TERRAIN_RIVER1 = 2003;

			// Token: 0x0400135C RID: 4956
			public const int HEADER_TYPE_TERRAIN_RIVER2 = 2004;

			// Token: 0x0400135D RID: 4957
			public const int HEADER_TYPE_TERRAIN_SALT = 2005;

			// Token: 0x0400135E RID: 4958
			public const int HEADER_TYPE_TERRAIN_MARSH = 2006;

			// Token: 0x0400135F RID: 4959
			public const int HEADER_TYPE_TERRAIN_PLAINS = 2007;

			// Token: 0x04001360 RID: 4960
			public const int HEADER_TYPE_TERRAIN_VALLEY = 2008;

			// Token: 0x04001361 RID: 4961
			public const int HEADER_TYPE_TERRAIN_FOREST = 2009;

			// Token: 0x04001362 RID: 4962
			private CustomSelfDrawPanel.CSDImage avatarUnderlayImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001363 RID: 4963
			private CustomSelfDrawPanel.CSDImage backGroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001364 RID: 4964
			private CustomSelfDrawPanel.CSDImage headerImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001365 RID: 4965
			private CustomSelfDrawPanel.CSDImage headerIcon = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001366 RID: 4966
			private CustomSelfDrawPanel.CSDImage actionIcon = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001367 RID: 4967
			private CustomSelfDrawPanel.CSDImage headerGlowSmall = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001368 RID: 4968
			private CustomSelfDrawPanel.CSDImage headerGlowLong = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001369 RID: 4969
			private CustomSelfDrawPanel.CSDLabel headingLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400136A RID: 4970
			private CustomSelfDrawPanel.CSDLabel subHeadingLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400136B RID: 4971
			private CustomSelfDrawPanel.CSDLabel panelLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400136C RID: 4972
			private int LastVillageType;

			// Token: 0x0400136D RID: 4973
			private int headingVillageID = -1;
		}
	}
}
