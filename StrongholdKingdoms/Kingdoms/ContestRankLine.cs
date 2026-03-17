using System;
using System.Drawing;
using CommonTypes;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x02000144 RID: 324
	public class ContestRankLine : CustomSelfDrawPanel.CSDControl
	{
		// Token: 0x06000BF1 RID: 3057 RVA: 0x000E8F58 File Offset: 0x000E7158
		public void init(ContestEntry entry, CustomSelfDrawPanel.CSDControl parentControl, bool isDark)
		{
			this.clearControls();
			this.backgroundImage.Image = (isDark ? GFXLibrary.lineitem_strip_02_dark : GFXLibrary.lineitem_strip_02_light);
			this.backgroundImage.Position = new Point(5, 0);
			this.backgroundImage.Size = new Size(parentControl.Width - 10, this.backgroundImage.Height * 4 / 3);
			base.addControl(this.backgroundImage);
			this.Size = new Size(parentControl.Width, this.backgroundImage.Height);
			this.rankLabel.Text = entry.Rank.ToString() + ": ";
			this.rankLabel.Color = global::ARGBColors.Black;
			this.rankLabel.Position = new Point(5, 0);
			this.rankLabel.Size = new Size(this.backgroundImage.Width / 4, this.backgroundImage.Height);
			this.rankLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.rankLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.backgroundImage.addControl(this.rankLabel);
			this.nameLabel.Text = entry.Name;
			this.nameLabel.Color = global::ARGBColors.Black;
			this.nameLabel.Position = new Point(this.backgroundImage.Width / 3, 0);
			this.nameLabel.Size = new Size(this.backgroundImage.Width / 2, this.backgroundImage.Height);
			this.nameLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.nameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.backgroundImage.addControl(this.nameLabel);
			this.scoreLabel.Text = entry.Score.ToString();
			this.scoreLabel.Color = global::ARGBColors.Black;
			this.scoreLabel.Position = new Point(this.backgroundImage.Width * 2 / 3 - 20, 0);
			this.scoreLabel.Size = new Size(this.backgroundImage.Width / 3, this.backgroundImage.Height);
			this.scoreLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.scoreLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.backgroundImage.addControl(this.scoreLabel);
			this.shieldImage.Image = GameEngine.Instance.World.getWorldShield(entry.UserID, 25, 28);
			if (this.shieldImage.Image != null)
			{
				this.shieldImage.Position = new Point(this.nameLabel.X - this.shieldImage.Width - 3, 6);
				this.shieldImage.Visible = true;
				this.backgroundImage.addControl(this.shieldImage);
			}
			this.houseImage.Image = this.GetHouseImage(entry.HouseID);
			if (this.houseImage.Image != null)
			{
				this.houseImage.Position = new Point(35, 0);
				this.houseImage.Visible = true;
				this.backgroundImage.addControl(this.houseImage);
			}
		}

		// Token: 0x06000BF2 RID: 3058 RVA: 0x000E92A8 File Offset: 0x000E74A8
		private BaseImage GetHouseImage(int houseID)
		{
			switch (houseID)
			{
			case 1:
				return GFXLibrary.house_flag_001;
			case 2:
				return GFXLibrary.house_flag_002;
			case 3:
				return GFXLibrary.house_flag_003;
			case 4:
				return GFXLibrary.house_flag_004;
			case 5:
				return GFXLibrary.house_flag_005;
			case 6:
				return GFXLibrary.house_flag_006;
			case 7:
				return GFXLibrary.house_flag_007;
			case 8:
				return GFXLibrary.house_flag_008;
			case 9:
				return GFXLibrary.house_flag_009;
			case 10:
				return GFXLibrary.house_flag_010;
			case 11:
				return GFXLibrary.house_flag_011;
			case 12:
				return GFXLibrary.house_flag_012;
			case 13:
				return GFXLibrary.house_flag_013;
			case 14:
				return GFXLibrary.house_flag_014;
			case 15:
				return GFXLibrary.house_flag_015;
			case 16:
				return GFXLibrary.house_flag_016;
			case 17:
				return GFXLibrary.house_flag_017;
			case 18:
				return GFXLibrary.house_flag_018;
			case 19:
				return GFXLibrary.house_flag_019;
			case 20:
				return GFXLibrary.house_flag_020;
			default:
				return null;
			}
		}

		// Token: 0x04000FF3 RID: 4083
		private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000FF4 RID: 4084
		private CustomSelfDrawPanel.CSDLabel rankLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000FF5 RID: 4085
		private CustomSelfDrawPanel.CSDLabel nameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000FF6 RID: 4086
		private CustomSelfDrawPanel.CSDLabel scoreLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000FF7 RID: 4087
		private CustomSelfDrawPanel.CSDImage houseImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000FF8 RID: 4088
		private CustomSelfDrawPanel.CSDImage shieldImage = new CustomSelfDrawPanel.CSDImage();
	}
}
