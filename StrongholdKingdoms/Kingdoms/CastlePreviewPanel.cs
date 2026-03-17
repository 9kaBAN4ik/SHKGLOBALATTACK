using System;
using System.Drawing;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x0200012C RID: 300
	public class CastlePreviewPanel : BasePreviewPanel
	{
		// Token: 0x06000B09 RID: 2825 RVA: 0x0000E36B File Offset: 0x0000C56B
		protected override void previewClick()
		{
			if (this.m_preset != null)
			{
				if (GameEngine.Instance.GameDisplayModeSubMode == GameEngine.GameDisplaySubModes.SUBMODE_DEFAULT)
				{
					GameEngine.Instance.InitCastlePreview(this.m_preset);
					return;
				}
				GameEngine.Instance.villageTabChange(1);
				InterfaceMgr.Instance.initCastleTab();
			}
		}

		// Token: 0x06000B0A RID: 2826 RVA: 0x000BE67C File Offset: 0x000BC87C
		private int correctPlacementType(int placementType)
		{
			int num = placementType;
			if (num != 65)
			{
				if (num == 66)
				{
					num = 33;
				}
			}
			else
			{
				num = 34;
			}
			return num;
		}

		// Token: 0x06000B0B RID: 2827 RVA: 0x000DF754 File Offset: 0x000DD954
		protected override void populateRequirements()
		{
			base.addControl(new CustomSelfDrawPanel.CSDLabel
			{
				Text = SK.Text("Preset_Requirements", "Requirements"),
				Color = global::ARGBColors.Black,
				Size = new Size(base.Width, 30),
				Position = new Point(0, base.Height / 6),
				Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold),
				Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER
			});
			this.populateResearch();
			this.populateResources();
		}

		// Token: 0x06000B0C RID: 2828 RVA: 0x000DF7E0 File Offset: 0x000DD9E0
		private void populateResearch()
		{
			CustomSelfDrawPanel.CSDExtendingPanel csdextendingPanel = new CustomSelfDrawPanel.CSDExtendingPanel();
			csdextendingPanel.Size = new Size(base.Width / 3 - 10, base.Height * 2 / 3 - 5);
			csdextendingPanel.Position = new Point(base.Width * 2 / 3 + 5, base.Height / 3);
			csdextendingPanel.Create(GFXLibrary.quest_9sclice_grey_inset_top_left, GFXLibrary.quest_9sclice_grey_inset_top_mid, GFXLibrary.quest_9sclice_grey_inset_top_right, GFXLibrary.quest_9sclice_grey_inset_mid_left, GFXLibrary.quest_9sclice_grey_inset_mid_mid, GFXLibrary.quest_9sclice_grey_inset_mid_right, GFXLibrary.quest_9sclice_grey_inset_bottom_left, GFXLibrary.quest_9sclice_grey_inset_bottom_mid, GFXLibrary.quest_9sclice_grey_inset_bottom_right);
			base.addControl(csdextendingPanel);
			CustomSelfDrawPanel.CSDLabel csdlabel = new CustomSelfDrawPanel.CSDLabel();
			csdlabel.Text = SK.Text("GENERIC_Research", "Research");
			csdlabel.Color = global::ARGBColors.Black;
			csdlabel.Size = new Size(csdextendingPanel.Width, 20);
			csdlabel.Position = new Point(csdextendingPanel.X, csdextendingPanel.Y - csdlabel.Height);
			csdlabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			csdlabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			base.addControl(csdlabel);
			ResearchData researchDataForCurrentVillage = GameEngine.Instance.World.GetResearchDataForCurrentVillage();
			bool flag = this.m_preset.GetFortificationResearchLevel() <= (int)researchDataForCurrentVillage.Research_Fortification;
			bool flag2 = this.m_preset.GetDefenceResearchLevel() <= (int)researchDataForCurrentVillage.Research_Defences;
			CustomSelfDrawPanel.CSDImage csdimage = new CustomSelfDrawPanel.CSDImage();
			csdimage.Image = (flag ? GFXLibrary.preset_req_fortification : GFXLibrary.preset_req_fortification_red);
			csdimage.setSizeToImage();
			csdimage.Position = new Point(csdextendingPanel.Width / 2 - csdimage.Width / 2, csdextendingPanel.Height / 6 - csdimage.Height / 2);
			csdimage.CustomTooltipID = 231;
			csdimage.CustomTooltipData = (flag ? 1 : 0);
			csdextendingPanel.addControl(csdimage);
			csdextendingPanel.addControl(new CustomSelfDrawPanel.CSDLabel
			{
				Text = this.m_preset.GetFortificationResearchLevel().ToString(),
				Color = global::ARGBColors.White,
				Position = csdimage.Position,
				Size = csdimage.Size,
				Font = FontManager.GetFont("Arial", 30f, FontStyle.Bold),
				Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER
			});
			CustomSelfDrawPanel.CSDImage csdimage2 = new CustomSelfDrawPanel.CSDImage();
			csdimage2.Image = (flag2 ? GFXLibrary.preset_req_defence : GFXLibrary.preset_req_defence_red);
			csdimage2.setSizeToImage();
			csdimage2.Position = new Point(csdextendingPanel.Width / 2 - csdimage2.Width / 2, csdextendingPanel.Height / 2 - csdimage2.Height / 2);
			csdimage2.CustomTooltipID = 230;
			csdimage2.CustomTooltipData = (flag2 ? 1 : 0);
			csdextendingPanel.addControl(csdimage2);
			csdextendingPanel.addControl(new CustomSelfDrawPanel.CSDLabel
			{
				Text = this.m_preset.GetDefenceResearchLevel().ToString(),
				Color = global::ARGBColors.White,
				Position = csdimage2.Position,
				Size = csdimage2.Size,
				Font = FontManager.GetFont("Arial", 30f, FontStyle.Bold),
				Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER
			});
			if (this.m_preset.RequiresParishBuilding())
			{
				bool flag3 = this.m_preset.ParishRequirementsMet();
				CustomSelfDrawPanel.CSDImage csdimage3 = new CustomSelfDrawPanel.CSDImage();
				csdimage3.Image = (flag3 ? GFXLibrary.preset_req_capital : GFXLibrary.preset_req_capital_red);
				csdimage3.setSizeToImage();
				csdimage3.Position = new Point(csdextendingPanel.Width / 2 - csdimage3.Width / 2, csdextendingPanel.Height * 5 / 6 - csdimage3.Height / 2);
				csdimage3.CustomTooltipID = 232;
				csdimage3.CustomTooltipData = (flag3 ? 1 : 0);
				csdextendingPanel.addControl(csdimage3);
			}
		}

		// Token: 0x06000B0D RID: 2829 RVA: 0x000DFBCC File Offset: 0x000DDDCC
		private void populateResources()
		{
			CustomSelfDrawPanel.CSDExtendingPanel csdextendingPanel = new CustomSelfDrawPanel.CSDExtendingPanel();
			csdextendingPanel.Size = new Size(base.Width * 2 / 3 - 10, base.Height * 2 / 3 - 5);
			csdextendingPanel.Position = new Point(5, base.Height / 3);
			csdextendingPanel.Create(GFXLibrary.quest_9sclice_grey_inset_top_left, GFXLibrary.quest_9sclice_grey_inset_top_mid, GFXLibrary.quest_9sclice_grey_inset_top_right, GFXLibrary.quest_9sclice_grey_inset_mid_left, GFXLibrary.quest_9sclice_grey_inset_mid_mid, GFXLibrary.quest_9sclice_grey_inset_mid_right, GFXLibrary.quest_9sclice_grey_inset_bottom_left, GFXLibrary.quest_9sclice_grey_inset_bottom_mid, GFXLibrary.quest_9sclice_grey_inset_bottom_right);
			base.addControl(csdextendingPanel);
			CustomSelfDrawPanel.CSDLabel csdlabel = new CustomSelfDrawPanel.CSDLabel();
			csdlabel.Text = SK.Text("GENERIC_Resources", "Resources");
			csdlabel.Color = global::ARGBColors.Black;
			csdlabel.Size = new Size(csdextendingPanel.Width, 20);
			csdlabel.Position = new Point(csdextendingPanel.X, csdextendingPanel.Y - csdlabel.Height);
			csdlabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			csdlabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			base.addControl(csdlabel);
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			bool flag = GameEngine.Instance.World.isCapital(InterfaceMgr.Instance.getSelectedMenuVillage());
			CardData cardData = new CardData();
			if (!flag)
			{
				cardData = GameEngine.Instance.cardsManager.UserCardData;
			}
			double num6 = 0.0;
			foreach (CastleMapPreset.CastleElementInfo castleElementInfo in this.m_preset.BasicData)
			{
				if (castleElementInfo.elementType <= 69 && castleElementInfo.elementType != 43)
				{
					int num7 = (int)castleElementInfo.elementType;
					if (num7 == 65)
					{
						num7 = 34;
					}
					if (num7 == 66)
					{
						num7 = 33;
					}
					int num8 = 0;
					int num9 = 0;
					int num10 = 0;
					int num11 = 0;
					int num12 = 0;
					CastlesCommon.getConstrCost(GameEngine.Instance.LocalWorldData, num7, ref num8, ref num9, ref num12, ref num11, ref num10);
					num += num8;
					num2 += num9;
					num3 += num10;
					num4 += num11;
					num5 += num12;
					num6 += CastlesCommon.calcConstrTime(GameEngine.Instance.LocalWorldData, num7, (int)GameEngine.Instance.World.GetResearchDataForCurrentVillage().Research_Construction, flag, cardData);
				}
			}
			VillageMap.StockpileLevels stockpileLevels = new VillageMap.StockpileLevels();
			GameEngine.Instance.Village.getStockpileLevels(stockpileLevels);
			CustomSelfDrawPanel.CSDImage csdimage = new CustomSelfDrawPanel.CSDImage();
			csdimage.Image = ((stockpileLevels.woodLevel >= (double)num) ? GFXLibrary.preset_req_wood : GFXLibrary.preset_req_wood_red);
			csdimage.setSizeToImage();
			csdimage.Position = new Point(10, csdextendingPanel.Height / 6 - csdimage.Height / 2);
			csdimage.CustomTooltipID = 233;
			csdimage.CustomTooltipData = ((stockpileLevels.woodLevel >= (double)num) ? 1 : 0);
			csdextendingPanel.addControl(csdimage);
			csdextendingPanel.addControl(new CustomSelfDrawPanel.CSDLabel
			{
				Text = num.ToString(),
				Color = global::ARGBColors.White,
				Position = new Point(csdimage.Rectangle.Right + 5, csdimage.Y),
				Size = new Size(csdextendingPanel.Width / 2, csdimage.Height),
				Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular),
				Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT
			});
			CustomSelfDrawPanel.CSDImage csdimage2 = new CustomSelfDrawPanel.CSDImage();
			csdimage2.Image = ((stockpileLevels.stoneLevel >= (double)num2) ? GFXLibrary.preset_req_stone : GFXLibrary.preset_req_stone_red);
			csdimage2.setSizeToImage();
			csdimage2.Position = new Point(csdextendingPanel.Width / 2 + 10, csdextendingPanel.Height / 6 - csdimage2.Height / 2);
			csdimage2.CustomTooltipID = 234;
			csdimage2.CustomTooltipData = ((stockpileLevels.stoneLevel >= (double)num2) ? 1 : 0);
			csdextendingPanel.addControl(csdimage2);
			csdextendingPanel.addControl(new CustomSelfDrawPanel.CSDLabel
			{
				Text = num2.ToString(),
				Color = global::ARGBColors.White,
				Position = new Point(csdimage2.Rectangle.Right + 5, csdimage2.Y),
				Size = new Size(csdextendingPanel.Width / 2, csdimage2.Height),
				Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular),
				Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT
			});
			CustomSelfDrawPanel.CSDImage csdimage3 = new CustomSelfDrawPanel.CSDImage();
			csdimage3.Image = ((stockpileLevels.ironLevel >= (double)num3) ? GFXLibrary.preset_req_iron : GFXLibrary.preset_req_iron_red);
			csdimage3.setSizeToImage();
			csdimage3.Position = new Point(10, csdextendingPanel.Height / 2 - csdimage3.Height / 2);
			csdimage3.CustomTooltipID = 235;
			csdimage3.CustomTooltipData = ((stockpileLevels.ironLevel >= (double)num3) ? 1 : 0);
			csdextendingPanel.addControl(csdimage3);
			csdextendingPanel.addControl(new CustomSelfDrawPanel.CSDLabel
			{
				Text = num3.ToString(),
				Color = global::ARGBColors.White,
				Position = new Point(csdimage3.Rectangle.Right + 5, csdimage3.Y),
				Size = new Size(csdextendingPanel.Width / 2, csdimage3.Height),
				Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular),
				Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT
			});
			CustomSelfDrawPanel.CSDImage csdimage4 = new CustomSelfDrawPanel.CSDImage();
			csdimage4.Image = ((stockpileLevels.pitchLevel >= (double)num4) ? GFXLibrary.preset_req_pitch : GFXLibrary.preset_req_pitch_red);
			csdimage4.setSizeToImage();
			csdimage4.Position = new Point(csdextendingPanel.Width / 2 + 10, csdextendingPanel.Height / 2 - csdimage4.Height / 2);
			csdimage4.CustomTooltipID = 236;
			csdimage4.CustomTooltipData = ((stockpileLevels.pitchLevel >= (double)num4) ? 1 : 0);
			csdextendingPanel.addControl(csdimage4);
			csdextendingPanel.addControl(new CustomSelfDrawPanel.CSDLabel
			{
				Text = num4.ToString(),
				Color = global::ARGBColors.White,
				Position = new Point(csdimage4.Rectangle.Right + 5, csdimage4.Y),
				Size = new Size(csdextendingPanel.Width / 2, csdimage4.Height),
				Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular),
				Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT
			});
			bool flag2 = (!flag) ? ((double)num5 <= GameEngine.Instance.World.getCurrentGold()) : ((double)num5 <= GameEngine.Instance.Village.m_capitalGold);
			CustomSelfDrawPanel.CSDImage csdimage5 = new CustomSelfDrawPanel.CSDImage();
			csdimage5.Image = (flag2 ? GFXLibrary.preset_req_gold : GFXLibrary.preset_req_gold_red);
			csdimage5.setSizeToImage();
			csdimage5.Position = new Point(10, csdextendingPanel.Height * 5 / 6 - csdimage5.Height / 2);
			csdimage5.CustomTooltipID = 237;
			csdimage5.CustomTooltipData = (flag2 ? 1 : 0);
			csdextendingPanel.addControl(csdimage5);
			csdextendingPanel.addControl(new CustomSelfDrawPanel.CSDLabel
			{
				Text = num5.ToString(),
				Color = global::ARGBColors.White,
				Position = new Point(csdimage5.Rectangle.Right + 5, csdimage5.Y),
				Size = new Size(csdextendingPanel.Width / 2, csdimage5.Height),
				Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular),
				Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT
			});
			CustomSelfDrawPanel.CSDImage csdimage6 = new CustomSelfDrawPanel.CSDImage();
			csdimage6.Image = GFXLibrary.preset_req_time;
			csdimage6.setSizeToImage();
			csdimage6.Position = new Point(csdextendingPanel.Width / 2 + 10, csdextendingPanel.Height * 5 / 6 - csdimage6.Height / 2);
			csdimage6.CustomTooltipID = 238;
			csdextendingPanel.addControl(csdimage6);
			csdextendingPanel.addControl(new CustomSelfDrawPanel.CSDLabel
			{
				Text = VillageMap.createBuildTimeString((int)(num6 * 3600.0)),
				Color = global::ARGBColors.White,
				Position = new Point(csdimage6.Rectangle.Right + 5, csdimage6.Y),
				Size = new Size(csdextendingPanel.Width / 2, csdimage6.Height),
				Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular),
				Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT
			});
		}
	}
}
