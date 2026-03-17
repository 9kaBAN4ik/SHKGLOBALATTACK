using System;
using System.Drawing;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x0200015B RID: 347
	public class CustomPrizeCell : ContestPrizeCell
	{
		// Token: 0x06000CF2 RID: 3314 RVA: 0x000F63FC File Offset: 0x000F45FC
		public override void init()
		{
			this.clearControls();
			this.Icon.Image = GFXLibrary.prizeBlank;
			this.Quantity.Color = global::ARGBColors.Black;
			this.Quantity.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
			this.Quantity.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			base.addControl(this.Icon);
			base.addControl(this.Quantity);
		}

		// Token: 0x06000CF3 RID: 3315 RVA: 0x0000F9B9 File Offset: 0x0000DBB9
		public void SetImage(BaseImage img)
		{
			this.SetImage(img, 1.0);
		}

		// Token: 0x06000CF4 RID: 3316 RVA: 0x000F6474 File Offset: 0x000F4674
		public void SetImage(BaseImage img, double scale)
		{
			if (this.prizeImage != null)
			{
				base.removeControl(this.prizeImage);
			}
			this.prizeImage = new CustomSelfDrawPanel.CSDImage();
			this.prizeImage.Image = img;
			this.prizeImage.Scale = scale * (double)this.Icon.Height / (double)this.prizeImage.Image.Height;
			base.addControl(this.prizeImage);
		}

		// Token: 0x06000CF5 RID: 3317 RVA: 0x000F64E8 File Offset: 0x000F46E8
		public override void resize()
		{
			base.resize();
			this.prizeImage.Position = new Point(base.Width / 4 - (int)(this.prizeImage.Scale * (double)this.prizeImage.Width / 2.0), this.Icon.Height / 2 - (int)(this.prizeImage.Scale * (double)this.prizeImage.Height / 2.0));
			this.prizeImage.invalidate();
			this.Quantity.invalidate();
		}

		// Token: 0x04001145 RID: 4421
		private CustomSelfDrawPanel.CSDImage prizeImage;
	}
}
