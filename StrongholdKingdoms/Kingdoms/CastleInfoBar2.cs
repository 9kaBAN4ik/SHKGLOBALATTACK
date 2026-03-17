using System;
using System.Drawing;
using System.Globalization;

namespace Kingdoms
{
	// Token: 0x02000114 RID: 276
	public class CastleInfoBar2 : CustomSelfDrawPanel.CSDControl
	{
		// Token: 0x060008F4 RID: 2292 RVA: 0x000BA500 File Offset: 0x000B8700
		public void init()
		{
			this.clearControls();
			this.lblWoodLevel.Text = "";
			this.lblWoodLevel.Position = new Point(44, 3);
			this.lblWoodLevel.Size = new Size(88, 29);
			this.lblWoodLevel.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.lblWoodLevel.Color = global::ARGBColors.Yellow;
			this.lblWoodLevel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.lblWoodLevel.CustomTooltipID = 142;
			base.addControl(this.lblWoodLevel);
			this.lblStoneLevel.Text = "";
			this.lblStoneLevel.Position = new Point(175, 3);
			this.lblStoneLevel.Size = new Size(88, 29);
			this.lblStoneLevel.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.lblStoneLevel.Color = global::ARGBColors.Yellow;
			this.lblStoneLevel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.lblStoneLevel.CustomTooltipID = 143;
			base.addControl(this.lblStoneLevel);
			this.lblPitchLevel.Text = "";
			this.lblPitchLevel.Position = new Point(306, 3);
			this.lblPitchLevel.Size = new Size(88, 29);
			this.lblPitchLevel.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.lblPitchLevel.Color = global::ARGBColors.Yellow;
			this.lblPitchLevel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.lblPitchLevel.CustomTooltipID = 148;
			base.addControl(this.lblPitchLevel);
			this.lblIronLevel.Text = "";
			this.lblIronLevel.Position = new Point(437, 3);
			this.lblIronLevel.Size = new Size(88, 29);
			this.lblIronLevel.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.lblIronLevel.Color = global::ARGBColors.Yellow;
			this.lblIronLevel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.lblIronLevel.CustomTooltipID = 149;
			base.addControl(this.lblIronLevel);
			this.imgWood.Image = GFXLibrary.com_32_wood;
			this.imgWood.Position = new Point(6, 0);
			this.imgWood.CustomTooltipID = 142;
			base.addControl(this.imgWood);
			this.imgStone.Image = GFXLibrary.com_32_stone;
			this.imgStone.Position = new Point(138, 0);
			this.imgStone.CustomTooltipID = 143;
			base.addControl(this.imgStone);
			this.imgPitch.Image = GFXLibrary.com_32_pitch;
			this.imgPitch.Position = new Point(269, 0);
			this.imgPitch.CustomTooltipID = 148;
			base.addControl(this.imgPitch);
			this.imgIron.Image = GFXLibrary.com_32_iron;
			this.imgIron.Position = new Point(400, 0);
			this.imgIron.CustomTooltipID = 149;
			base.addControl(this.imgIron);
		}

		// Token: 0x060008F5 RID: 2293 RVA: 0x000BA858 File Offset: 0x000B8A58
		public void setDisplayedLevels(int woodLevel, int stoneLevel, int pitchLevel, int ironLevel)
		{
			NumberFormatInfo nfi = GameEngine.NFI;
			this.lblWoodLevel.TextDiffOnly = woodLevel.ToString("N", nfi);
			this.lblStoneLevel.TextDiffOnly = stoneLevel.ToString("N", nfi);
			this.lblPitchLevel.TextDiffOnly = pitchLevel.ToString("N", nfi);
			this.lblIronLevel.TextDiffOnly = ironLevel.ToString("N", nfi);
		}

		// Token: 0x060008F6 RID: 2294 RVA: 0x0000D39B File Offset: 0x0000B59B
		public bool isVisible()
		{
			return base.Visible;
		}

		// Token: 0x060008F7 RID: 2295 RVA: 0x0000D3A3 File Offset: 0x0000B5A3
		public void show()
		{
			base.Visible = true;
			base.invalidate();
		}

		// Token: 0x060008F8 RID: 2296 RVA: 0x0000D3B2 File Offset: 0x0000B5B2
		public void hide()
		{
			base.Visible = false;
			base.invalidate();
		}

		// Token: 0x04000C62 RID: 3170
		private CustomSelfDrawPanel.CSDLabel lblWoodLevel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000C63 RID: 3171
		private CustomSelfDrawPanel.CSDLabel lblStoneLevel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000C64 RID: 3172
		private CustomSelfDrawPanel.CSDLabel lblPitchLevel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000C65 RID: 3173
		private CustomSelfDrawPanel.CSDLabel lblIronLevel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000C66 RID: 3174
		private CustomSelfDrawPanel.CSDImage imgWood = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000C67 RID: 3175
		private CustomSelfDrawPanel.CSDImage imgStone = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000C68 RID: 3176
		private CustomSelfDrawPanel.CSDImage imgPitch = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000C69 RID: 3177
		private CustomSelfDrawPanel.CSDImage imgIron = new CustomSelfDrawPanel.CSDImage();
	}
}
