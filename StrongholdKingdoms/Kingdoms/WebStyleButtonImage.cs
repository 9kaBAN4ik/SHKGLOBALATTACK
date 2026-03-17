using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Kingdoms
{
	// Token: 0x020004F4 RID: 1268
	public class WebStyleButtonImage
	{
		// Token: 0x06003031 RID: 12337 RVA: 0x00279320 File Offset: 0x00277520
		public static Image Generate(int width, int height, string text, Font font, Color forecolour, Color backcolour, int radius)
		{
			int num = radius * 2;
			Image image = new Bitmap(width + 1, height + 1);
			SolidBrush solidBrush = new SolidBrush(forecolour);
			SolidBrush solidBrush2 = new SolidBrush(backcolour);
			Pen pen = new Pen(forecolour);
			Pen pen2 = new Pen(backcolour);
			using (Graphics graphics = Graphics.FromImage(image))
			{
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
				graphics.Clear(global::ARGBColors.Transparent);
				graphics.FillRectangle(solidBrush2, new Rectangle(0, radius, width, height - num));
				graphics.FillRectangle(solidBrush2, new Rectangle(radius, 0, width - num, height));
				graphics.FillEllipse(solidBrush2, new Rectangle(0, 0, num, num));
				graphics.FillEllipse(solidBrush2, new Rectangle(0, height - num, num, num));
				graphics.FillEllipse(solidBrush2, new Rectangle(width - num, 0, num, num));
				graphics.FillEllipse(solidBrush2, new Rectangle(width - num, height - num, num, num));
				StringFormat stringFormat = new StringFormat();
				stringFormat.LineAlignment = StringAlignment.Center;
				stringFormat.Alignment = StringAlignment.Center;
				font = FontManager.GetPrivateFont("AssetIcons/Cards/panel/Brokenscript-BoldCond.ttf", 12f, FontStyle.Bold);
				graphics.DrawString(text, font, solidBrush, new RectangleF(0f, 0f, (float)(width + 1), (float)(height + 1)), stringFormat);
			}
			pen.Dispose();
			pen2.Dispose();
			solidBrush.Dispose();
			solidBrush2.Dispose();
			return image;
		}

		// Token: 0x06003032 RID: 12338 RVA: 0x00279480 File Offset: 0x00277680
		public static Image GenerateLabel(int width, int height, string text, Color forecolour, Color backcolour)
		{
			Image image = new Bitmap(width + 1, height + 1);
			SolidBrush solidBrush = new SolidBrush(forecolour);
			SolidBrush solidBrush2 = new SolidBrush(backcolour);
			using (Graphics graphics = Graphics.FromImage(image))
			{
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
				graphics.Clear(backcolour);
				StringFormat stringFormat = new StringFormat();
				stringFormat.LineAlignment = StringAlignment.Near;
				stringFormat.Alignment = StringAlignment.Near;
				Font privateFont = FontManager.GetPrivateFont("AssetIcons/Cards/panel/Brokenscript-BoldCond.ttf", 14f, FontStyle.Bold);
				graphics.DrawString(text, privateFont, solidBrush, new RectangleF(0f, 0f, (float)(width + 1), (float)(height + 1)), stringFormat);
			}
			solidBrush.Dispose();
			solidBrush2.Dispose();
			return image;
		}
	}
}
