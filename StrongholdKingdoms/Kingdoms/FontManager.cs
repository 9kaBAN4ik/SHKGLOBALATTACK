using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;

namespace Kingdoms
{
	// Token: 0x020001DA RID: 474
	public class FontManager
	{
		// Token: 0x060011E4 RID: 4580 RVA: 0x0001378D File Offset: 0x0001198D
		public static void setDPI(Graphics gfx)
		{
			FontManager.dpi = gfx.DpiX;
			FontManager.dpiSet = true;
		}

		// Token: 0x060011E5 RID: 4581 RVA: 0x0012CAFC File Offset: 0x0012ACFC
		public static Font GetPrivateFont(string fileName, float pointSize, FontStyle style)
		{
			string key = FontManager.createHashString(fileName, pointSize, style);
			try
			{
				Font font = FontManager.fontCollection[key];
				if (font != null)
				{
					return font;
				}
			}
			catch (Exception)
			{
			}
			try
			{
				FontFamily family = null;
				try
				{
					int num = FontManager.privateFontNames[fileName];
					family = FontManager.pfc.Families[num];
				}
				catch (Exception)
				{
					FontManager.pfc.AddFontFile(fileName);
					int num = FontManager.pfc.Families.Length - 1;
					family = FontManager.pfc.Families[num];
					FontManager.privateFontNames.Add(fileName, num);
				}
				Font font2 = new Font(family, pointSize * 96f / FontManager.dpi, style);
				if (font2 != null)
				{
					if (FontManager.dpiSet)
					{
						FontManager.fontCollection.Add(key, font2);
					}
					return font2;
				}
			}
			catch (Exception ex)
			{
				string message = ex.Message;
			}
			return null;
		}

		// Token: 0x060011E6 RID: 4582 RVA: 0x000137A0 File Offset: 0x000119A0
		private static string createHashString(string fontFamilyName, float pointSize, FontStyle style)
		{
			return fontFamilyName + pointSize.ToString() + style.ToString();
		}

		// Token: 0x060011E7 RID: 4583 RVA: 0x0012CBF8 File Offset: 0x0012ADF8
		public static Font GetFont(string fontFamilyName, float pointSize, FontStyle style)
		{
			if ((Program.mySettings.LanguageIdent == "zh" || Program.mySettings.LanguageIdent == "zhHK") && style == FontStyle.Bold && pointSize < 12f)
			{
				style = FontStyle.Regular;
			}
			string key = FontManager.createHashString(fontFamilyName, pointSize, style);
			try
			{
				if (FontManager.fontCollection.ContainsKey(key))
				{
					Font font = FontManager.fontCollection[key];
					if (font != null)
					{
						return font;
					}
				}
			}
			catch (Exception)
			{
			}
			Font font2 = FontManager.getFont(fontFamilyName, pointSize, style);
			if (font2 == null)
			{
				font2 = FontManager.GetFont("Microsoft Sans Serif", pointSize, style);
			}
			if (font2 != null && FontManager.dpiSet)
			{
				FontManager.fontCollection.Add(key, font2);
			}
			return font2;
		}

		// Token: 0x060011E8 RID: 4584 RVA: 0x000137BC File Offset: 0x000119BC
		public static Font GetFont(string fontFamilyName, float pointSize)
		{
			return FontManager.GetFont(fontFamilyName, pointSize, FontStyle.Regular);
		}

		// Token: 0x060011E9 RID: 4585 RVA: 0x0012CCB0 File Offset: 0x0012AEB0
		private static Font getFont(string fontFamilyName, float pointSize, FontStyle style)
		{
			try
			{
				Font font = new Font(fontFamilyName, pointSize * 96f / FontManager.dpi, style);
				if (font != null)
				{
					return font;
				}
			}
			catch (Exception)
			{
			}
			return null;
		}

		// Token: 0x04001822 RID: 6178
		public const string DEFAULT_FONT = "Arial";

		// Token: 0x04001823 RID: 6179
		public const string DEFAULT_FONT2 = "Microsoft Sans Serif";

		// Token: 0x04001824 RID: 6180
		public static float dpi = 96f;

		// Token: 0x04001825 RID: 6181
		private static bool dpiSet = false;

		// Token: 0x04001826 RID: 6182
		private static Dictionary<string, int> privateFontNames = new Dictionary<string, int>();

		// Token: 0x04001827 RID: 6183
		private static PrivateFontCollection pfc = new PrivateFontCollection();

		// Token: 0x04001828 RID: 6184
		public static Dictionary<string, Font> fontCollection = new Dictionary<string, Font>();
	}
}
