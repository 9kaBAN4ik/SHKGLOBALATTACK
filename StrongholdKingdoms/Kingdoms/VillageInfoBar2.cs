using System;
using System.Drawing;
using System.Globalization;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020004D2 RID: 1234
	public class VillageInfoBar2 : CustomSelfDrawPanel.CSDControl
	{
		// Token: 0x06002D93 RID: 11667 RVA: 0x00243614 File Offset: 0x00241814
		public void init()
		{
			this.clearControls();
			this.lblWoodName.Text = SK.Text("VillageInfoBar_No_Stockpile", "No Stockpile");
			this.lblWoodName.Position = new Point(3, 0);
			this.lblWoodName.Size = new Size(250, 29);
			this.lblWoodName.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.lblWoodName.Color = global::ARGBColors.Yellow;
			this.lblWoodName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.lblWoodName.CustomTooltipID = 142;
			this.lblWoodName.Visible = false;
			base.addControl(this.lblWoodName);
			this.lblWoodLevel.Text = "";
			this.lblWoodLevel.Position = new Point(44, 3);
			this.lblWoodLevel.Size = new Size(75, 29);
			this.lblWoodLevel.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.lblWoodLevel.Color = global::ARGBColors.Yellow;
			this.lblWoodLevel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.lblWoodLevel.CustomTooltipID = 142;
			base.addControl(this.lblWoodLevel);
			this.lblStoneLevel.Text = "";
			this.lblStoneLevel.Position = new Point(165, 3);
			this.lblStoneLevel.Size = new Size(75, 29);
			this.lblStoneLevel.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.lblStoneLevel.Color = global::ARGBColors.Yellow;
			this.lblStoneLevel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.lblStoneLevel.CustomTooltipID = 143;
			base.addControl(this.lblStoneLevel);
			this.lblFoodLevel.Text = "";
			this.lblFoodLevel.Position = new Point(286, 3);
			this.lblFoodLevel.Size = new Size(78, 29);
			this.lblFoodLevel.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.lblFoodLevel.Color = global::ARGBColors.Yellow;
			this.lblFoodLevel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.lblFoodLevel.CustomTooltipID = 144;
			base.addControl(this.lblFoodLevel);
			this.lblFoodName.Text = SK.Text("VillageInfoBar_No_Granary", "No Granary");
			this.lblFoodName.Position = new Point(269, 3);
			this.lblFoodName.Size = new Size(206, 29);
			this.lblFoodName.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.lblFoodName.Color = global::ARGBColors.Yellow;
			this.lblFoodName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.lblFoodName.CustomTooltipID = 142;
			this.lblFoodName.Visible = false;
			base.addControl(this.lblFoodName);
			this.lblPeople.Text = "";
			this.lblPeople.Position = new Point(418, 3);
			this.lblPeople.Size = new Size(51, 29);
			this.lblPeople.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.lblPeople.Color = global::ARGBColors.Yellow;
			this.lblPeople.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.lblPeople.CustomTooltipID = 141;
			base.addControl(this.lblPeople);
			this.lblPeasants.Text = "";
			this.lblPeasants.Position = new Point(503, 3);
			this.lblPeasants.Size = new Size(27, 29);
			this.lblPeasants.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.lblPeasants.Color = global::ARGBColors.Yellow;
			this.lblPeasants.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.lblPeasants.CustomTooltipID = 141;
			base.addControl(this.lblPeasants);
			this.lblHeading.Text = "";
			this.lblHeading.Position = new Point(0, 2);
			this.lblHeading.Size = new Size(500, 29);
			this.lblHeading.Font = FontManager.GetFont("Microsoft Sans Serif", 18f);
			this.lblHeading.Color = Color.FromArgb(224, 203, 146);
			this.lblHeading.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.lblHeading.Visible = false;
			base.addControl(this.lblHeading);
			this.imgWood.Image = GFXLibrary.com_32_wood;
			this.imgWood.Position = new Point(7, 0);
			this.imgWood.CustomTooltipID = 142;
			base.addControl(this.imgWood);
			this.imgStone.Image = GFXLibrary.com_32_stone;
			this.imgStone.Position = new Point(128, 0);
			this.imgStone.CustomTooltipID = 143;
			base.addControl(this.imgStone);
			this.imgFood.Image = GFXLibrary.com_32_food;
			this.imgFood.Position = new Point(249, 0);
			this.imgFood.CustomTooltipID = 144;
			base.addControl(this.imgFood);
			this.imgBed.Image = GFXLibrary.population_bed;
			this.imgBed.Position = new Point(370, 0);
			this.imgBed.CustomTooltipID = 141;
			base.addControl(this.imgBed);
			this.imgPeople.Image = GFXLibrary.population_head;
			this.imgPeople.Position = new Point(469, 0);
			this.imgPeople.CustomTooltipID = 141;
			base.addControl(this.imgPeople);
			this.imgGold.Image = GFXLibrary.com_32_money;
			this.imgGold.Position = new Point(7, 0);
			this.imgGold.CustomTooltipID = 145;
			base.addControl(this.imgGold);
			this.imgFlag.Image = GFXLibrary.flag_blue_icon;
			this.imgFlag.Position = new Point(128, 8);
			this.imgFlag.CustomTooltipID = 146;
			base.addControl(this.imgFlag);
		}

		// Token: 0x06002D94 RID: 11668 RVA: 0x00243CA8 File Offset: 0x00241EA8
		public void setHeading(string text)
		{
			this.lblWoodName.Visible = false;
			this.lblFoodLevel.Visible = false;
			this.lblFoodName.Visible = false;
			this.imgFood.Visible = false;
			this.imgWood.Visible = false;
			this.imgStone.Visible = false;
			this.lblPeasants.Visible = false;
			this.lblPeople.Visible = false;
			this.imgPeople.Visible = false;
			this.imgBed.Visible = false;
			this.lblStoneLevel.Visible = false;
			this.lblWoodLevel.Visible = false;
			this.imgGold.Visible = false;
			this.lblFoodName.Visible = false;
			this.imgFlag.Visible = false;
			this.lblHeading.Text = text;
			this.lblHeading.Visible = true;
		}

		// Token: 0x06002D95 RID: 11669 RVA: 0x000217F4 File Offset: 0x0001F9F4
		public void removeHeading()
		{
			this.lblHeading.Visible = false;
		}

		// Token: 0x06002D96 RID: 11670 RVA: 0x00243D84 File Offset: 0x00241F84
		public void setDisplayedLevels(int woodLevel, int stoneLevel, int foodLevel, bool gotStockpile, bool gotGranary, int totalPeople, int housingCapacity, int spareWorkers, bool viewOnly, int capitalGold, int villageID, int numFlags)
		{
			if (this.lblHeading.Visible)
			{
				return;
			}
			NumberFormatInfo nfi = GameEngine.NFI;
			if (GameEngine.Instance.World.isCapital(villageID))
			{
				this.lblWoodLevel.Visible = true;
				this.lblStoneLevel.Visible = true;
				this.lblWoodName.Visible = false;
				this.lblFoodLevel.Visible = false;
				this.lblFoodName.Visible = false;
				this.imgFood.Visible = false;
				this.imgWood.Visible = false;
				this.imgStone.Visible = false;
				this.lblPeasants.Visible = false;
				this.lblPeople.Visible = false;
				this.imgPeople.Visible = false;
				this.imgBed.Visible = false;
				this.imgGold.Visible = true;
				this.imgFlag.Visible = true;
				this.lblWoodLevel.TextDiffOnly = capitalGold.ToString("N", nfi);
				this.lblStoneLevel.TextDiffOnly = numFlags.ToString("N", nfi);
				this.lblWoodLevel.CustomTooltipID = 145;
				this.lblStoneLevel.CustomTooltipID = 146;
				return;
			}
			this.imgGold.Visible = false;
			this.lblPeasants.Visible = true;
			this.lblPeople.Visible = true;
			this.lblWoodLevel.Visible = true;
			this.lblStoneLevel.Visible = true;
			this.lblWoodName.Visible = false;
			this.lblFoodLevel.Visible = true;
			this.imgFood.Visible = true;
			this.imgWood.Visible = true;
			this.imgStone.Visible = true;
			this.imgPeople.Visible = true;
			this.imgBed.Visible = true;
			this.imgFlag.Visible = false;
			this.lblWoodLevel.CustomTooltipID = 142;
			this.lblStoneLevel.CustomTooltipID = 143;
			if (!viewOnly)
			{
				if (this.lastViewOnly)
				{
					this.lastStockpile = !gotStockpile;
					this.lastGranary = !gotGranary;
					this.lastViewOnly = false;
				}
				this.lblWoodLevel.TextDiffOnly = woodLevel.ToString("N", nfi);
				this.lblStoneLevel.TextDiffOnly = stoneLevel.ToString("N", nfi);
				this.lblFoodLevel.TextDiffOnly = foodLevel.ToString("N", nfi);
				this.lastStockpile = gotStockpile;
				if (gotStockpile)
				{
					this.lblWoodLevel.Visible = true;
					this.lblStoneLevel.Visible = true;
					this.imgWood.Visible = true;
					this.imgStone.Visible = true;
					this.lblWoodName.Visible = false;
				}
				else
				{
					this.lblWoodLevel.Visible = false;
					this.lblStoneLevel.Visible = false;
					this.imgWood.Visible = false;
					this.imgStone.Visible = false;
					this.lblWoodName.Visible = true;
				}
				this.lastGranary = gotGranary;
				if (gotGranary)
				{
					this.lblFoodLevel.Visible = true;
					this.lblFoodName.Visible = false;
					this.imgFood.Visible = true;
				}
				else
				{
					this.lblFoodLevel.Visible = false;
					this.lblFoodName.Visible = true;
					this.imgFood.Visible = false;
				}
			}
			else
			{
				this.lastViewOnly = true;
				this.lblWoodLevel.Visible = false;
				this.lblStoneLevel.Visible = false;
				this.lblWoodName.Visible = false;
				this.lblFoodLevel.Visible = false;
				this.lblFoodName.Visible = false;
				this.imgFood.Visible = false;
				this.imgWood.Visible = false;
				this.imgStone.Visible = false;
			}
			this.lblPeople.TextDiffOnly = totalPeople.ToString() + "/" + housingCapacity.ToString();
			this.lblPeasants.TextDiffOnly = spareWorkers.ToString();
		}

		// Token: 0x06002D97 RID: 11671 RVA: 0x0000D39B File Offset: 0x0000B59B
		public bool isVisible()
		{
			return base.Visible;
		}

		// Token: 0x06002D98 RID: 11672 RVA: 0x0000D3A3 File Offset: 0x0000B5A3
		public void show()
		{
			base.Visible = true;
			base.invalidate();
		}

		// Token: 0x06002D99 RID: 11673 RVA: 0x0000D3B2 File Offset: 0x0000B5B2
		public void hide()
		{
			base.Visible = false;
			base.invalidate();
		}

		// Token: 0x040038C9 RID: 14537
		private CustomSelfDrawPanel.CSDLabel lblWoodName = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040038CA RID: 14538
		private CustomSelfDrawPanel.CSDLabel lblWoodLevel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040038CB RID: 14539
		private CustomSelfDrawPanel.CSDLabel lblStoneLevel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040038CC RID: 14540
		private CustomSelfDrawPanel.CSDLabel lblFoodLevel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040038CD RID: 14541
		private CustomSelfDrawPanel.CSDLabel lblFoodName = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040038CE RID: 14542
		private CustomSelfDrawPanel.CSDLabel lblPeople = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040038CF RID: 14543
		private CustomSelfDrawPanel.CSDLabel lblPeasants = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040038D0 RID: 14544
		private CustomSelfDrawPanel.CSDLabel lblHeading = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040038D1 RID: 14545
		private CustomSelfDrawPanel.CSDImage imgWood = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040038D2 RID: 14546
		private CustomSelfDrawPanel.CSDImage imgStone = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040038D3 RID: 14547
		private CustomSelfDrawPanel.CSDImage imgFood = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040038D4 RID: 14548
		private CustomSelfDrawPanel.CSDImage imgBed = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040038D5 RID: 14549
		private CustomSelfDrawPanel.CSDImage imgPeople = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040038D6 RID: 14550
		private CustomSelfDrawPanel.CSDImage imgGold = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040038D7 RID: 14551
		private CustomSelfDrawPanel.CSDImage imgFlag = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040038D8 RID: 14552
		private bool lastStockpile = true;

		// Token: 0x040038D9 RID: 14553
		private bool lastGranary = true;

		// Token: 0x040038DA RID: 14554
		private bool lastViewOnly;
	}
}
