using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x020000E4 RID: 228
	public class BitmapButton : Button
	{
		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060006A9 RID: 1705 RVA: 0x0000B89C File Offset: 0x00009A9C
		// (set) Token: 0x060006AA RID: 1706 RVA: 0x0000B8A4 File Offset: 0x00009AA4
		[Browsable(false)]
		public new Image Image
		{
			get
			{
				return base.Image;
			}
			set
			{
				base.Image = value;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060006AB RID: 1707 RVA: 0x0000B8AD File Offset: 0x00009AAD
		// (set) Token: 0x060006AC RID: 1708 RVA: 0x0000B8B5 File Offset: 0x00009AB5
		[Browsable(false)]
		public new ImageList ImageList
		{
			get
			{
				return base.ImageList;
			}
			set
			{
				base.ImageList = value;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060006AD RID: 1709 RVA: 0x0000B8BE File Offset: 0x00009ABE
		// (set) Token: 0x060006AE RID: 1710 RVA: 0x0000B8C6 File Offset: 0x00009AC6
		[Browsable(false)]
		public new int ImageIndex
		{
			get
			{
				return base.ImageIndex;
			}
			set
			{
				base.ImageIndex = value;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060006AF RID: 1711 RVA: 0x0000B8CF File Offset: 0x00009ACF
		// (set) Token: 0x060006B0 RID: 1712 RVA: 0x0000B8D7 File Offset: 0x00009AD7
		[Category("Appearance")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Browsable(true)]
		[Description("enables the text to cast a shadow")]
		public bool TextDropShadow
		{
			get
			{
				return this._TextDropShadow;
			}
			set
			{
				this._TextDropShadow = value;
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060006B1 RID: 1713 RVA: 0x0000B8E0 File Offset: 0x00009AE0
		// (set) Token: 0x060006B2 RID: 1714 RVA: 0x0000B8E8 File Offset: 0x00009AE8
		[RefreshProperties(RefreshProperties.Repaint)]
		[Browsable(true)]
		[Category("Appearance")]
		[Description("enables the drawing of the border")]
		public bool BorderDrawing
		{
			get
			{
				return this._BorderDrawing;
			}
			set
			{
				this._BorderDrawing = value;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060006B3 RID: 1715 RVA: 0x0000B8F1 File Offset: 0x00009AF1
		// (set) Token: 0x060006B4 RID: 1716 RVA: 0x0000B8F9 File Offset: 0x00009AF9
		[Category("Appearance")]
		[Browsable(true)]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Description("enables the focus rectangle")]
		public bool FocusRectangleEnabled
		{
			get
			{
				return this._FocusRectangleEnabled;
			}
			set
			{
				this._FocusRectangleEnabled = value;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060006B5 RID: 1717 RVA: 0x0000B902 File Offset: 0x00009B02
		// (set) Token: 0x060006B6 RID: 1718 RVA: 0x0000B90A File Offset: 0x00009B0A
		[Browsable(true)]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Category("Appearance")]
		[Description("enables the image to cast a shadow")]
		public bool ImageDropShadow
		{
			get
			{
				return this._ImageDropShadow;
			}
			set
			{
				this._ImageDropShadow = value;
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060006B7 RID: 1719 RVA: 0x0000B913 File Offset: 0x00009B13
		// (set) Token: 0x060006B8 RID: 1720 RVA: 0x0000B91B File Offset: 0x00009B1B
		[Browsable(true)]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Category("Appearance")]
		[Description("Color of the border around the image")]
		public Color ImageBorderColor
		{
			get
			{
				return this._ImageBorderColor;
			}
			set
			{
				this._ImageBorderColor = value;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060006B9 RID: 1721 RVA: 0x0000B924 File Offset: 0x00009B24
		// (set) Token: 0x060006BA RID: 1722 RVA: 0x0000B92C File Offset: 0x00009B2C
		[RefreshProperties(RefreshProperties.Repaint)]
		[Browsable(true)]
		[Category("Appearance")]
		[Description("Enables the bordering of the image")]
		public bool ImageBorderEnabled
		{
			get
			{
				return this._ImageBorderEnabled;
			}
			set
			{
				this._ImageBorderEnabled = value;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060006BB RID: 1723 RVA: 0x0000B935 File Offset: 0x00009B35
		// (set) Token: 0x060006BC RID: 1724 RVA: 0x0000B93D File Offset: 0x00009B3D
		[Browsable(true)]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Category("Appearance")]
		[Description("Color of the border around the button")]
		public Color BorderColor
		{
			get
			{
				return this._BorderColor;
			}
			set
			{
				this._BorderColor = value;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060006BD RID: 1725 RVA: 0x0000B946 File Offset: 0x00009B46
		// (set) Token: 0x060006BE RID: 1726 RVA: 0x0000B94E File Offset: 0x00009B4E
		[Browsable(true)]
		[Description("Color of the inner border when the button has focus")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Category("Appearance")]
		public Color InnerBorderColor_Focus
		{
			get
			{
				return this._InnerBorderColor_Focus;
			}
			set
			{
				this._InnerBorderColor_Focus = value;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060006BF RID: 1727 RVA: 0x0000B957 File Offset: 0x00009B57
		// (set) Token: 0x060006C0 RID: 1728 RVA: 0x0000B95F File Offset: 0x00009B5F
		[RefreshProperties(RefreshProperties.Repaint)]
		[Browsable(true)]
		[Category("Appearance")]
		[Description("Color of the inner border when the button does not hvae focus")]
		public Color InnerBorderColor
		{
			get
			{
				return this._InnerBorderColor;
			}
			set
			{
				this._InnerBorderColor = value;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060006C1 RID: 1729 RVA: 0x0000B968 File Offset: 0x00009B68
		// (set) Token: 0x060006C2 RID: 1730 RVA: 0x0000B970 File Offset: 0x00009B70
		[Category("Appearance")]
		[Browsable(true)]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Description("color of the inner border when the mouse is over the button")]
		public Color InnerBorderColor_MouseOver
		{
			get
			{
				return this._InnerBorderColor_MouseOver;
			}
			set
			{
				this._InnerBorderColor_MouseOver = value;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060006C3 RID: 1731 RVA: 0x0000B979 File Offset: 0x00009B79
		// (set) Token: 0x060006C4 RID: 1732 RVA: 0x0000B981 File Offset: 0x00009B81
		[Browsable(true)]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Category("Appearance")]
		[Description("stretch the impage to the size of the button")]
		public bool StretchImage
		{
			get
			{
				return this._StretchImage;
			}
			set
			{
				this._StretchImage = value;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060006C5 RID: 1733 RVA: 0x0000B98A File Offset: 0x00009B8A
		// (set) Token: 0x060006C6 RID: 1734 RVA: 0x0000B992 File Offset: 0x00009B92
		[Browsable(true)]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Category("Appearance")]
		[Description("padded pixels around the image and text")]
		public int Padding2
		{
			get
			{
				return this._Padding;
			}
			set
			{
				this._Padding = value;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060006C7 RID: 1735 RVA: 0x0000B99B File Offset: 0x00009B9B
		// (set) Token: 0x060006C8 RID: 1736 RVA: 0x0000B9A3 File Offset: 0x00009BA3
		[RefreshProperties(RefreshProperties.Repaint)]
		[Browsable(true)]
		[Category("Appearance")]
		[Description("Set to true if to offset image/text when button is pressed")]
		public bool OffsetPressedContent
		{
			get
			{
				return this._OffsetPressedContent;
			}
			set
			{
				this._OffsetPressedContent = value;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060006C9 RID: 1737 RVA: 0x0000B9AC File Offset: 0x00009BAC
		// (set) Token: 0x060006CA RID: 1738 RVA: 0x0000B9B4 File Offset: 0x00009BB4
		[Browsable(true)]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Category("Appearance")]
		[Description("Image to be displayed while the button state is in normal state")]
		public Image ImageNormal
		{
			get
			{
				return this._ImageNormal;
			}
			set
			{
				this._ImageNormal = value;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060006CB RID: 1739 RVA: 0x0000B9BD File Offset: 0x00009BBD
		// (set) Token: 0x060006CC RID: 1740 RVA: 0x0000B9C5 File Offset: 0x00009BC5
		[Browsable(true)]
		[Description("Image to be displayed while the button has focus")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Category("Appearance")]
		public Image ImageFocused
		{
			get
			{
				return this._ImageFocused;
			}
			set
			{
				this._ImageFocused = value;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060006CD RID: 1741 RVA: 0x0000B9CE File Offset: 0x00009BCE
		// (set) Token: 0x060006CE RID: 1742 RVA: 0x0000B9D6 File Offset: 0x00009BD6
		[Description("Image to be displayed while the button is inactive")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Category("Appearance")]
		[Browsable(true)]
		public Image ImageInactive
		{
			get
			{
				return this._ImageInactive;
			}
			set
			{
				this._ImageInactive = value;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060006CF RID: 1743 RVA: 0x0000B9DF File Offset: 0x00009BDF
		// (set) Token: 0x060006D0 RID: 1744 RVA: 0x0000B9E7 File Offset: 0x00009BE7
		[Browsable(true)]
		[Category("Appearance")]
		[Description("Image to be displayed while the button state is pressed")]
		[RefreshProperties(RefreshProperties.Repaint)]
		public Image ImagePressed
		{
			get
			{
				return this._ImagePressed;
			}
			set
			{
				this._ImagePressed = value;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060006D1 RID: 1745 RVA: 0x0000B9F0 File Offset: 0x00009BF0
		// (set) Token: 0x060006D2 RID: 1746 RVA: 0x0000B9F8 File Offset: 0x00009BF8
		[RefreshProperties(RefreshProperties.Repaint)]
		[Category("Appearance")]
		[Description("Image to be displayed while the button state is MouseOver")]
		[Browsable(true)]
		public Image ImageMouseOver
		{
			get
			{
				return this._ImageMouseOver;
			}
			set
			{
				this._ImageMouseOver = value;
			}
		}

		// Token: 0x060006D3 RID: 1747 RVA: 0x0008E734 File Offset: 0x0008C934
		public BitmapButton()
		{
			this.InitializeComponent();
		}

		// Token: 0x060006D4 RID: 1748 RVA: 0x0000BA01 File Offset: 0x00009C01
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (base.Region != null)
				{
					base.Region.Dispose();
					base.Region = null;
				}
				if (this.components != null)
				{
					this.components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		// Token: 0x060006D5 RID: 1749 RVA: 0x0000BA3A File Offset: 0x00009C3A
		private void InitializeComponent()
		{
			this.components = new Container();
		}

		// Token: 0x060006D6 RID: 1750 RVA: 0x0000BA47 File Offset: 0x00009C47
		protected override void OnPaint(PaintEventArgs e)
		{
			this.CreateRegion(0);
			this.paint_Background(e);
			this.paint_Text(e);
			this.paint_Image(e);
			if (this.BorderDrawing)
			{
				this.paint_Border(e);
				this.paint_InnerBorder(e);
				this.paint_FocusBorder(e);
			}
		}

		// Token: 0x060006D7 RID: 1751 RVA: 0x0008E7B0 File Offset: 0x0008C9B0
		private void paint_Background(PaintEventArgs e)
		{
			if (e != null && e.Graphics != null)
			{
				Graphics graphics = e.Graphics;
				Rectangle rect = new Rectangle(0, 0, base.Size.Width, base.Size.Height);
				Color color = this.BackColor;
				if (this.btnState == BtnState.Inactive)
				{
					color = global::ARGBColors.LightGray;
				}
				color = ControlPaint.Light(color, 0.1f);
				Color[] colors;
				float[] positions;
				if (this.btnState == BtnState.Pushed)
				{
					colors = new Color[]
					{
						BitmapButton.Blend(this.BackColor, global::ARGBColors.White, 80),
						BitmapButton.Blend(this.BackColor, global::ARGBColors.White, 40),
						BitmapButton.Blend(this.BackColor, global::ARGBColors.Black, 0),
						BitmapButton.Blend(this.BackColor, global::ARGBColors.Black, 0),
						BitmapButton.Blend(this.BackColor, global::ARGBColors.White, 40),
						BitmapButton.Blend(this.BackColor, global::ARGBColors.White, 80)
					};
					positions = new float[]
					{
						0f,
						0.05f,
						0.4f,
						0.6f,
						0.95f,
						1f
					};
				}
				else
				{
					colors = new Color[]
					{
						BitmapButton.Blend(color, global::ARGBColors.White, 80),
						BitmapButton.Blend(color, global::ARGBColors.White, 90),
						BitmapButton.Blend(color, global::ARGBColors.White, 30),
						BitmapButton.Blend(color, global::ARGBColors.White, 0),
						BitmapButton.Blend(color, global::ARGBColors.Black, 30),
						BitmapButton.Blend(color, global::ARGBColors.Black, 20)
					};
					positions = new float[]
					{
						0f,
						0.15f,
						0.4f,
						0.65f,
						0.95f,
						1f
					};
				}
				ColorBlend colorBlend = new ColorBlend();
				colorBlend.Colors = colors;
				colorBlend.Positions = positions;
				LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, this.BackColor, BitmapButton.Blend(this.BackColor, this.BackColor, 10), LinearGradientMode.Vertical);
				linearGradientBrush.InterpolationColors = colorBlend;
				graphics.FillRectangle(linearGradientBrush, rect);
				linearGradientBrush.Dispose();
			}
		}

		// Token: 0x060006D8 RID: 1752 RVA: 0x0008E9C8 File Offset: 0x0008CBC8
		private void paint_Border(PaintEventArgs e)
		{
			if (e != null && e.Graphics != null)
			{
				Pen pen = new Pen(this.BorderColor, 1f);
				Point[] points = this.border_Get(0, 0, base.Width - 1, base.Height - 1);
				e.Graphics.DrawLines(pen, points);
				pen.Dispose();
			}
		}

		// Token: 0x060006D9 RID: 1753 RVA: 0x0008EA20 File Offset: 0x0008CC20
		private void paint_FocusBorder(PaintEventArgs e)
		{
			if (e != null && e.Graphics != null && this.Focused && this.FocusRectangleEnabled)
			{
				ControlPaint.DrawFocusRectangle(e.Graphics, new Rectangle(3, 3, base.Width - 6, base.Height - 6), global::ARGBColors.Black, this.BackColor);
			}
		}

		// Token: 0x060006DA RID: 1754 RVA: 0x0008EA78 File Offset: 0x0008CC78
		private void paint_InnerBorder(PaintEventArgs e)
		{
			if (e == null || e.Graphics == null)
			{
				return;
			}
			Graphics graphics = e.Graphics;
			Rectangle rect = new Rectangle(0, 0, base.Size.Width, base.Size.Height);
			Color scolor = this.BackColor;
			bool flag = false;
			switch (this.btnState)
			{
			case BtnState.Inactive:
				scolor = global::ARGBColors.Gray;
				break;
			case BtnState.Normal:
				if (this.Focused)
				{
					scolor = this.InnerBorderColor_Focus;
					flag = true;
				}
				else
				{
					scolor = this.InnerBorderColor;
				}
				break;
			case BtnState.MouseOver:
				scolor = this.InnerBorderColor_MouseOver;
				break;
			case BtnState.Pushed:
				scolor = BitmapButton.Blend(this.InnerBorderColor_Focus, global::ARGBColors.Black, 10);
				flag = true;
				break;
			}
			Color[] colors;
			float[] positions;
			if (this.btnState == BtnState.Pushed)
			{
				colors = new Color[]
				{
					BitmapButton.Blend(scolor, global::ARGBColors.Black, 20),
					BitmapButton.Blend(scolor, global::ARGBColors.Black, 10),
					BitmapButton.Blend(scolor, global::ARGBColors.White, 0),
					BitmapButton.Blend(scolor, global::ARGBColors.White, 50),
					BitmapButton.Blend(scolor, global::ARGBColors.White, 85),
					BitmapButton.Blend(scolor, global::ARGBColors.White, 90)
				};
				positions = new float[]
				{
					0f,
					0.2f,
					0.5f,
					0.6f,
					0.9f,
					1f
				};
			}
			else
			{
				colors = new Color[]
				{
					BitmapButton.Blend(scolor, global::ARGBColors.White, 80),
					BitmapButton.Blend(scolor, global::ARGBColors.White, 60),
					BitmapButton.Blend(scolor, global::ARGBColors.White, 10),
					BitmapButton.Blend(scolor, global::ARGBColors.White, 0),
					BitmapButton.Blend(scolor, global::ARGBColors.Black, 20),
					BitmapButton.Blend(scolor, global::ARGBColors.Black, 50)
				};
				positions = new float[]
				{
					0f,
					0.2f,
					0.5f,
					0.6f,
					0.9f,
					1f
				};
			}
			ColorBlend colorBlend = new ColorBlend();
			colorBlend.Colors = colors;
			colorBlend.Positions = positions;
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, this.BackColor, BitmapButton.Blend(this.BackColor, this.BackColor, 10), LinearGradientMode.Vertical);
			linearGradientBrush.InterpolationColors = colorBlend;
			Pen pen = new Pen(linearGradientBrush, 1f);
			Point[] points = this.border_Get(0, 0, base.Width - 1, base.Height - 1);
			this.border_Contract(1, ref points);
			e.Graphics.DrawLines(pen, points);
			this.border_Contract(1, ref points);
			e.Graphics.DrawLines(pen, points);
			if (flag)
			{
				this.border_Contract(1, ref points);
				e.Graphics.DrawLines(pen, points);
			}
			pen.Dispose();
			linearGradientBrush.Dispose();
		}

		// Token: 0x060006DB RID: 1755 RVA: 0x0008ED28 File Offset: 0x0008CF28
		private void paint_Text(PaintEventArgs e)
		{
			if (e == null || e.Graphics == null)
			{
				return;
			}
			Rectangle textDestinationRect = this.GetTextDestinationRect();
			StringFormat stringFormat = new StringFormat();
			stringFormat.Alignment = StringAlignment.Center;
			stringFormat.LineAlignment = StringAlignment.Center;
			if (this.btnState == BtnState.Pushed && this.OffsetPressedContent)
			{
				textDestinationRect.Offset(1, 1);
			}
			SizeF sizeF = this.txt_Size(e.Graphics, this.Text, this.Font);
			Point point = this.Calculate_LeftEdgeTopEdge(this.TextAlign, textDestinationRect, (int)sizeF.Width, (int)sizeF.Height);
			if (this.btnState == BtnState.Inactive)
			{
				textDestinationRect.Offset(1, 1);
				Brush brush = new SolidBrush(global::ARGBColors.White);
				e.Graphics.DrawString(this.Text, this.Font, brush, textDestinationRect, stringFormat);
				brush.Dispose();
				textDestinationRect.Offset(-1, -1);
				Brush brush2 = new SolidBrush(Color.FromArgb(50, 50, 50));
				e.Graphics.DrawString(this.Text, this.Font, brush2, textDestinationRect, stringFormat);
				brush2.Dispose();
				return;
			}
			if (this.TextDropShadow)
			{
				Brush brush3 = new SolidBrush(Color.FromArgb(50, global::ARGBColors.Black));
				Brush brush4 = new SolidBrush(Color.FromArgb(20, global::ARGBColors.Black));
				e.Graphics.DrawString(this.Text, this.Font, brush3, (float)point.X, (float)(point.Y + 1));
				e.Graphics.DrawString(this.Text, this.Font, brush3, (float)(point.X + 1), (float)point.Y);
				e.Graphics.DrawString(this.Text, this.Font, brush4, (float)(point.X + 1), (float)(point.Y + 1));
				e.Graphics.DrawString(this.Text, this.Font, brush4, (float)point.X, (float)(point.Y + 2));
				e.Graphics.DrawString(this.Text, this.Font, brush4, (float)(point.X + 2), (float)point.Y);
				brush3.Dispose();
				brush4.Dispose();
			}
			Brush brush5 = new SolidBrush(this.ForeColor);
			e.Graphics.DrawString(this.Text, this.Font, brush5, textDestinationRect, stringFormat);
			brush5.Dispose();
		}

		// Token: 0x060006DC RID: 1756 RVA: 0x0008EF80 File Offset: 0x0008D180
		private void paint_ImageBorder(Graphics g, Rectangle ImageRect)
		{
			Rectangle rect = ImageRect;
			if (this.ImageDropShadow)
			{
				Pen pen = new Pen(Color.FromArgb(80, 0, 0, 0));
				Pen pen2 = new Pen(Color.FromArgb(40, 0, 0, 0));
				g.DrawLine(pen, new Point(rect.Right, rect.Bottom), new Point(rect.Right + 1, rect.Bottom));
				g.DrawLine(pen, new Point(rect.Right + 1, rect.Top + 1), new Point(rect.Right + 1, rect.Bottom));
				g.DrawLine(pen2, new Point(rect.Right + 2, rect.Top + 2), new Point(rect.Right + 2, rect.Bottom + 1));
				g.DrawLine(pen, new Point(rect.Left + 1, rect.Bottom + 1), new Point(rect.Right, rect.Bottom + 1));
				g.DrawLine(pen2, new Point(rect.Left + 1, rect.Bottom + 2), new Point(rect.Right + 1, rect.Bottom + 2));
				pen.Dispose();
				pen2.Dispose();
			}
			if (this.ImageBorderEnabled)
			{
				Color scolor = this.ImageBorderColor;
				if (!base.Enabled)
				{
					scolor = global::ARGBColors.LightGray;
				}
				Color[] colors = new Color[]
				{
					BitmapButton.Blend(scolor, global::ARGBColors.White, 40),
					BitmapButton.Blend(scolor, global::ARGBColors.White, 20),
					BitmapButton.Blend(scolor, global::ARGBColors.White, 30),
					BitmapButton.Blend(scolor, global::ARGBColors.White, 0),
					BitmapButton.Blend(scolor, global::ARGBColors.Black, 30),
					BitmapButton.Blend(scolor, global::ARGBColors.Black, 70)
				};
				float[] positions = new float[]
				{
					0f,
					0.2f,
					0.5f,
					0.6f,
					0.9f,
					1f
				};
				ColorBlend colorBlend = new ColorBlend();
				colorBlend.Colors = colors;
				colorBlend.Positions = positions;
				LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, this.BackColor, BitmapButton.Blend(this.BackColor, this.BackColor, 10), LinearGradientMode.Vertical);
				linearGradientBrush.InterpolationColors = colorBlend;
				Pen pen3 = new Pen(linearGradientBrush, 1f);
				Pen pen4 = new Pen(global::ARGBColors.Black);
				rect.Inflate(1, 1);
				Point[] points = this.border_Get(rect.Left, rect.Top, rect.Width, rect.Height);
				this.border_Contract(1, ref points);
				g.DrawLines(pen4, points);
				this.border_Contract(1, ref points);
				g.DrawLines(pen3, points);
				pen4.Dispose();
				pen3.Dispose();
				linearGradientBrush.Dispose();
			}
		}

		// Token: 0x060006DD RID: 1757 RVA: 0x0008F248 File Offset: 0x0008D448
		private void paint_Image(PaintEventArgs e)
		{
			if (e == null || e.Graphics == null)
			{
				return;
			}
			Image currentImage = this.GetCurrentImage(this.btnState);
			if (currentImage != null)
			{
				Graphics graphics = e.Graphics;
				Rectangle imageDestinationRect = this.GetImageDestinationRect();
				if (this.btnState == BtnState.Pushed && this._OffsetPressedContent)
				{
					imageDestinationRect.Offset(1, 1);
				}
				if (this.StretchImage)
				{
					graphics.DrawImage(currentImage, imageDestinationRect, 0, 0, currentImage.Width, currentImage.Height, GraphicsUnit.Pixel);
				}
				else
				{
					this.GetImageDestinationRect();
					graphics.DrawImage(currentImage, imageDestinationRect, 0, 0, currentImage.Width, currentImage.Height, GraphicsUnit.Pixel);
				}
				this.paint_ImageBorder(graphics, imageDestinationRect);
			}
		}

		// Token: 0x060006DE RID: 1758 RVA: 0x0000BA82 File Offset: 0x00009C82
		private SizeF txt_Size(Graphics g, string strText, Font font)
		{
			return g.MeasureString(strText, font);
		}

		// Token: 0x060006DF RID: 1759 RVA: 0x0008F2E0 File Offset: 0x0008D4E0
		private Rectangle GetTextDestinationRect()
		{
			Rectangle imageDestinationRect = this.GetImageDestinationRect();
			Rectangle result = new Rectangle(0, 0, 0, 0);
			ContentAlignment imageAlign = base.ImageAlign;
			if (imageAlign <= ContentAlignment.MiddleCenter)
			{
				switch (imageAlign)
				{
				case ContentAlignment.TopLeft:
					result = new Rectangle(0, imageDestinationRect.Bottom, base.Width, base.Height - imageDestinationRect.Bottom);
					break;
				case ContentAlignment.TopCenter:
					result = new Rectangle(0, imageDestinationRect.Bottom, base.Width, base.Height - imageDestinationRect.Bottom);
					break;
				case (ContentAlignment)3:
					break;
				case ContentAlignment.TopRight:
					result = new Rectangle(0, imageDestinationRect.Bottom, base.Width, base.Height - imageDestinationRect.Bottom);
					break;
				default:
					if (imageAlign != ContentAlignment.MiddleLeft)
					{
						if (imageAlign == ContentAlignment.MiddleCenter)
						{
							result = new Rectangle(0, imageDestinationRect.Bottom, base.Width, base.Height - imageDestinationRect.Bottom);
						}
					}
					else
					{
						result = new Rectangle(imageDestinationRect.Right, 0, base.Width - imageDestinationRect.Right, base.Height);
					}
					break;
				}
			}
			else if (imageAlign <= ContentAlignment.BottomLeft)
			{
				if (imageAlign != ContentAlignment.MiddleRight)
				{
					if (imageAlign == ContentAlignment.BottomLeft)
					{
						result = new Rectangle(0, 0, base.Width, imageDestinationRect.Top);
					}
				}
				else
				{
					result = new Rectangle(0, 0, imageDestinationRect.Left, base.Height);
				}
			}
			else if (imageAlign != ContentAlignment.BottomCenter)
			{
				if (imageAlign == ContentAlignment.BottomRight)
				{
					result = new Rectangle(0, 0, base.Width, imageDestinationRect.Top);
				}
			}
			else
			{
				result = new Rectangle(0, 0, base.Width, imageDestinationRect.Top);
			}
			result.Inflate(-this.Padding2, -this.Padding2);
			return result;
		}

		// Token: 0x060006E0 RID: 1760 RVA: 0x0008F4A8 File Offset: 0x0008D6A8
		private Rectangle GetImageDestinationRect()
		{
			Rectangle result = new Rectangle(0, 0, 0, 0);
			Image currentImage = this.GetCurrentImage(this.btnState);
			if (currentImage != null)
			{
				if (this.StretchImage)
				{
					result.Width = base.Width;
					result.Height = base.Height;
				}
				else
				{
					result.Width = currentImage.Width;
					result.Height = currentImage.Height;
					Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
					rect.Inflate(-this.Padding2, -this.Padding2);
					Point pos = this.Calculate_LeftEdgeTopEdge(base.ImageAlign, rect, currentImage.Width, currentImage.Height);
					result.Offset(pos);
				}
			}
			return result;
		}

		// Token: 0x060006E1 RID: 1761 RVA: 0x0008F560 File Offset: 0x0008D760
		private Image GetCurrentImage(BtnState btnState)
		{
			Image image = this.ImageNormal;
			switch (btnState)
			{
			case BtnState.Inactive:
				if (this.ImageInactive != null)
				{
					image = this.ImageInactive;
				}
				else
				{
					if (image != null)
					{
						this.ImageInactive = this.ConvertToGrayscale(new Bitmap(this.ImageNormal));
					}
					image = this.ImageNormal;
				}
				break;
			case BtnState.Normal:
				if (this.Focused && this.ImageFocused != null)
				{
					image = this.ImageFocused;
				}
				break;
			case BtnState.MouseOver:
				if (this.ImageMouseOver != null)
				{
					image = this.ImageMouseOver;
				}
				break;
			case BtnState.Pushed:
				if (this.ImagePressed != null)
				{
					image = this.ImagePressed;
				}
				break;
			}
			return image;
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x0008F5FC File Offset: 0x0008D7FC
		public Bitmap ConvertToGrayscale(Bitmap source)
		{
			Bitmap bitmap = new Bitmap(source.Width, source.Height);
			for (int i = 0; i < bitmap.Height; i++)
			{
				for (int j = 0; j < bitmap.Width; j++)
				{
					Color pixel = source.GetPixel(j, i);
					int num = (int)((double)pixel.R * 0.3 + (double)pixel.G * 0.59 + (double)pixel.B * 0.11);
					bitmap.SetPixel(j, i, Color.FromArgb(num, num, num));
				}
			}
			return bitmap;
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x0008F698 File Offset: 0x0008D898
		private Point Calculate_LeftEdgeTopEdge(ContentAlignment Alignment, Rectangle rect, int nWidth, int nHeight)
		{
			Point result = new Point(0, 0);
			if (Alignment <= ContentAlignment.MiddleCenter)
			{
				switch (Alignment)
				{
				case ContentAlignment.TopLeft:
					result.X = 0;
					result.Y = 0;
					break;
				case ContentAlignment.TopCenter:
					result.X = (rect.Width - nWidth) / 2;
					result.Y = 0;
					break;
				case (ContentAlignment)3:
					break;
				case ContentAlignment.TopRight:
					result.X = rect.Width - nWidth;
					result.Y = 0;
					break;
				default:
					if (Alignment != ContentAlignment.MiddleLeft)
					{
						if (Alignment == ContentAlignment.MiddleCenter)
						{
							result.X = (rect.Width - nWidth) / 2;
							result.Y = (rect.Height - nHeight) / 2;
						}
					}
					else
					{
						result.X = 0;
						result.Y = (rect.Height - nHeight) / 2;
					}
					break;
				}
			}
			else if (Alignment <= ContentAlignment.BottomLeft)
			{
				if (Alignment != ContentAlignment.MiddleRight)
				{
					if (Alignment == ContentAlignment.BottomLeft)
					{
						result.X = 0;
						result.Y = rect.Height - nHeight;
					}
				}
				else
				{
					result.X = rect.Width - nWidth;
					result.Y = (rect.Height - nHeight) / 2;
				}
			}
			else if (Alignment != ContentAlignment.BottomCenter)
			{
				if (Alignment == ContentAlignment.BottomRight)
				{
					result.X = rect.Width - nWidth;
					result.Y = rect.Height - nHeight;
				}
			}
			else
			{
				result.X = (rect.Width - nWidth) / 2;
				result.Y = rect.Height - nHeight;
			}
			result.X += rect.Left;
			result.Y += rect.Top;
			return result;
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x0008F85C File Offset: 0x0008DA5C
		private void CreateRegion(int nContract)
		{
			Point[] points = this.border_Get(0, 0, base.Width, base.Height);
			this.border_Contract(nContract, ref points);
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddLines(points);
			base.Region = new Region(graphicsPath);
		}

		// Token: 0x060006E5 RID: 1765 RVA: 0x0008F8A0 File Offset: 0x0008DAA0
		private void border_Contract(int nPixel, ref Point[] pts)
		{
			Point[] array = pts;
			int num = 0;
			array[num].X = array[num].X + nPixel;
			Point[] array2 = pts;
			int num2 = 0;
			array2[num2].Y = array2[num2].Y + nPixel;
			Point[] array3 = pts;
			int num3 = 1;
			array3[num3].X = array3[num3].X - nPixel;
			Point[] array4 = pts;
			int num4 = 1;
			array4[num4].Y = array4[num4].Y + nPixel;
			Point[] array5 = pts;
			int num5 = 2;
			array5[num5].X = array5[num5].X - nPixel;
			Point[] array6 = pts;
			int num6 = 2;
			array6[num6].Y = array6[num6].Y + nPixel;
			Point[] array7 = pts;
			int num7 = 3;
			array7[num7].X = array7[num7].X - nPixel;
			Point[] array8 = pts;
			int num8 = 3;
			array8[num8].Y = array8[num8].Y + nPixel;
			Point[] array9 = pts;
			int num9 = 4;
			array9[num9].X = array9[num9].X - nPixel;
			Point[] array10 = pts;
			int num10 = 4;
			array10[num10].Y = array10[num10].Y - nPixel;
			Point[] array11 = pts;
			int num11 = 5;
			array11[num11].X = array11[num11].X - nPixel;
			Point[] array12 = pts;
			int num12 = 5;
			array12[num12].Y = array12[num12].Y - nPixel;
			Point[] array13 = pts;
			int num13 = 6;
			array13[num13].X = array13[num13].X - nPixel;
			Point[] array14 = pts;
			int num14 = 6;
			array14[num14].Y = array14[num14].Y - nPixel;
			Point[] array15 = pts;
			int num15 = 7;
			array15[num15].X = array15[num15].X + nPixel;
			Point[] array16 = pts;
			int num16 = 7;
			array16[num16].Y = array16[num16].Y - nPixel;
			Point[] array17 = pts;
			int num17 = 8;
			array17[num17].X = array17[num17].X + nPixel;
			Point[] array18 = pts;
			int num18 = 8;
			array18[num18].Y = array18[num18].Y - nPixel;
			Point[] array19 = pts;
			int num19 = 9;
			array19[num19].X = array19[num19].X + nPixel;
			Point[] array20 = pts;
			int num20 = 9;
			array20[num20].Y = array20[num20].Y - nPixel;
			Point[] array21 = pts;
			int num21 = 10;
			array21[num21].X = array21[num21].X + nPixel;
			Point[] array22 = pts;
			int num22 = 10;
			array22[num22].Y = array22[num22].Y + nPixel;
			Point[] array23 = pts;
			int num23 = 11;
			array23[num23].X = array23[num23].X + nPixel;
			Point[] array24 = pts;
			int num24 = 10;
			array24[num24].Y = array24[num24].Y + nPixel;
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x0008FAAC File Offset: 0x0008DCAC
		private Point[] border_Get(int nLeftEdge, int nTopEdge, int nWidth, int nHeight)
		{
			Point[] array = new Point[]
			{
				new Point(1, 0),
				new Point(nWidth - 1, 0),
				new Point(nWidth - 1, 1),
				new Point(nWidth, 1),
				new Point(nWidth, nHeight - 1),
				new Point(nWidth - 1, nHeight - 1),
				new Point(nWidth - 1, nHeight),
				new Point(1, nHeight),
				new Point(1, nHeight - 1),
				new Point(0, nHeight - 1),
				new Point(0, 1),
				new Point(1, 1)
			};
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Offset(nLeftEdge, nTopEdge);
			}
			return array;
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x0008FBA0 File Offset: 0x0008DDA0
		private static Color Shade(Color SColor, int RED, int GREEN, int BLUE)
		{
			int num = (int)SColor.R;
			int num2 = (int)SColor.G;
			int num3 = (int)SColor.B;
			num += RED;
			if (num > 255)
			{
				num = 255;
			}
			if (num < 0)
			{
				num = 0;
			}
			num2 += GREEN;
			if (num2 > 255)
			{
				num2 = 255;
			}
			if (num2 < 0)
			{
				num2 = 0;
			}
			num3 += BLUE;
			if (num3 > 255)
			{
				num3 = 255;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			return Color.FromArgb(num, num2, num3);
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x0008FC18 File Offset: 0x0008DE18
		private static Color Blend(Color SColor, Color DColor, int Percentage)
		{
			int red = (int)SColor.R + (int)(DColor.R - SColor.R) * Percentage / 100;
			int green = (int)SColor.G + (int)(DColor.G - SColor.G) * Percentage / 100;
			int blue = (int)SColor.B + (int)(DColor.B - SColor.B) * Percentage / 100;
			return Color.FromArgb(red, green, blue);
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x0000BA8C File Offset: 0x00009C8C
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			base.Capture = true;
			this.CapturingMouse = true;
			this.btnState = BtnState.Pushed;
			base.Invalidate();
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x0000BAB0 File Offset: 0x00009CB0
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if (base.Enabled)
			{
				this.btnState = BtnState.Normal;
			}
			else
			{
				this.btnState = BtnState.Inactive;
			}
			base.Invalidate();
			this.CapturingMouse = false;
			base.Capture = false;
			base.Invalidate();
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x0000BAEB File Offset: 0x00009CEB
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			if (!this.CapturingMouse)
			{
				if (base.Enabled)
				{
					this.btnState = BtnState.Normal;
				}
				else
				{
					this.btnState = BtnState.Inactive;
				}
				base.Invalidate();
			}
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x0008FC84 File Offset: 0x0008DE84
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (this.CapturingMouse)
			{
				Rectangle rectangle = new Rectangle(0, 0, base.Width, base.Height);
				this.btnState = BtnState.Normal;
				if (e.X >= rectangle.Left && e.X <= rectangle.Right && e.Y >= rectangle.Top && e.Y <= rectangle.Bottom)
				{
					this.btnState = BtnState.Pushed;
				}
				base.Capture = true;
				base.Invalidate();
				return;
			}
			if (this.btnState != BtnState.MouseOver)
			{
				this.btnState = BtnState.MouseOver;
				base.Invalidate();
			}
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x0000BB1A File Offset: 0x00009D1A
		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			if (base.Enabled)
			{
				this.btnState = BtnState.Normal;
			}
			else
			{
				this.btnState = BtnState.Inactive;
				this.CapturingMouse = false;
				base.Capture = false;
			}
			base.Invalidate();
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x0000BB4F File Offset: 0x00009D4F
		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			if (base.Enabled)
			{
				this.btnState = BtnState.Normal;
			}
			base.Invalidate();
		}

		// Token: 0x0400090E RID: 2318
		private Image _ImageNormal;

		// Token: 0x0400090F RID: 2319
		private Image _ImageFocused;

		// Token: 0x04000910 RID: 2320
		private Image _ImagePressed;

		// Token: 0x04000911 RID: 2321
		private Image _ImageMouseOver;

		// Token: 0x04000912 RID: 2322
		private Image _ImageInactive;

		// Token: 0x04000913 RID: 2323
		private Color _BorderColor = global::ARGBColors.DarkBlue;

		// Token: 0x04000914 RID: 2324
		private Color _InnerBorderColor = global::ARGBColors.LightGray;

		// Token: 0x04000915 RID: 2325
		private Color _InnerBorderColor_Focus = global::ARGBColors.LightBlue;

		// Token: 0x04000916 RID: 2326
		private Color _InnerBorderColor_MouseOver = global::ARGBColors.Gold;

		// Token: 0x04000917 RID: 2327
		private Color _ImageBorderColor = global::ARGBColors.Chocolate;

		// Token: 0x04000918 RID: 2328
		private bool _StretchImage;

		// Token: 0x04000919 RID: 2329
		private bool _TextDropShadow;

		// Token: 0x0400091A RID: 2330
		private int _Padding = 5;

		// Token: 0x0400091B RID: 2331
		private bool _OffsetPressedContent = true;

		// Token: 0x0400091C RID: 2332
		private bool _ImageBorderEnabled = true;

		// Token: 0x0400091D RID: 2333
		private bool _ImageDropShadow = true;

		// Token: 0x0400091E RID: 2334
		private bool _FocusRectangleEnabled;

		// Token: 0x0400091F RID: 2335
		private BtnState btnState = BtnState.Normal;

		// Token: 0x04000920 RID: 2336
		private bool CapturingMouse;

		// Token: 0x04000921 RID: 2337
		private bool _BorderDrawing = true;

		// Token: 0x04000922 RID: 2338
		private Container components;
	}
}
