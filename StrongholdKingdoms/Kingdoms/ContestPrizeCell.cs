using System;
using System.Drawing;

namespace Kingdoms
{
	// Token: 0x02000140 RID: 320
	public class ContestPrizeCell : CustomSelfDrawPanel.CSDControl
	{
		// Token: 0x06000BE4 RID: 3044 RVA: 0x000E7A2C File Offset: 0x000E5C2C
		public virtual void init()
		{
			this.clearControls();
			this.Quantity.Color = global::ARGBColors.Black;
			this.Quantity.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
			this.Quantity.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.Icon.setSizeToImage();
			base.addControl(this.Icon);
			base.addControl(this.Quantity);
		}

		// Token: 0x06000BE5 RID: 3045 RVA: 0x000E7A9C File Offset: 0x000E5C9C
		public virtual void resize()
		{
			this.Icon.Width = base.Width;
			this.Icon.Height = base.Width / 3;
			this.Quantity.Size = new Size(this.Icon.Width * 2 / 3, this.Icon.Height);
			this.Quantity.Position = new Point(this.Icon.Width / 3, 0);
			this.Quantity.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.Quantity.Font = FontManager.GetFont("Arial", (float)(this.Icon.Height / 3), FontStyle.Regular);
			this.Icon.invalidate();
			this.Quantity.invalidate();
		}

		// Token: 0x04000FE5 RID: 4069
		public CustomSelfDrawPanel.CSDImage Icon = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000FE6 RID: 4070
		public CustomSelfDrawPanel.CSDLabel Quantity = new CustomSelfDrawPanel.CSDLabel();
	}
}
