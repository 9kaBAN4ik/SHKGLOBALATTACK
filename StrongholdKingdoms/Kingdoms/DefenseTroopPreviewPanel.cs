using System;
using System.Drawing;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000198 RID: 408
	public class DefenseTroopPreviewPanel : BasePreviewPanel
	{
		// Token: 0x06000FB8 RID: 4024 RVA: 0x00011736 File Offset: 0x0000F936
		protected override void previewClick()
		{
			if (GameEngine.Instance.GameDisplayModeSubMode == GameEngine.GameDisplaySubModes.SUBMODE_DEFAULT)
			{
				GameEngine.Instance.InitCastlePreview(this.m_preset);
				return;
			}
			GameEngine.Instance.villageTabChange(1);
			InterfaceMgr.Instance.initCastleTab();
		}

		// Token: 0x06000FB9 RID: 4025 RVA: 0x0001176A File Offset: 0x0000F96A
		protected override void populateRequirements()
		{
			this.populateTroopCounts();
		}

		// Token: 0x06000FBA RID: 4026 RVA: 0x00114E64 File Offset: 0x00113064
		private void populateTroopCounts()
		{
			CustomSelfDrawPanel.CSDExtendingPanel csdextendingPanel = new CustomSelfDrawPanel.CSDExtendingPanel();
			csdextendingPanel.Size = new Size(base.Width - 40, base.Height / 2);
			csdextendingPanel.Position = new Point(20, base.Height / 4);
			csdextendingPanel.Create(GFXLibrary.quest_9sclice_grey_inset_top_left, GFXLibrary.quest_9sclice_grey_inset_top_mid, GFXLibrary.quest_9sclice_grey_inset_top_right, GFXLibrary.quest_9sclice_grey_inset_mid_left, GFXLibrary.quest_9sclice_grey_inset_mid_mid, GFXLibrary.quest_9sclice_grey_inset_mid_right, GFXLibrary.quest_9sclice_grey_inset_bottom_left, GFXLibrary.quest_9sclice_grey_inset_bottom_mid, GFXLibrary.quest_9sclice_grey_inset_bottom_right);
			base.addControl(csdextendingPanel);
			CustomSelfDrawPanel.CSDLabel csdlabel = new CustomSelfDrawPanel.CSDLabel();
			csdlabel.Text = SK.Text("GENERIC_Contents", "Contents");
			csdlabel.Color = global::ARGBColors.Black;
			csdlabel.Size = new Size(csdextendingPanel.Width, 30);
			csdlabel.Position = new Point(csdextendingPanel.X, csdextendingPanel.Y - csdlabel.Height);
			csdlabel.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
			csdlabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			base.addControl(csdlabel);
			int elementTotal = this.m_preset.GetElementTotal(70);
			int elementTotal2 = this.m_preset.GetElementTotal(72);
			int elementTotal3 = this.m_preset.GetElementTotal(73);
			int elementTotal4 = this.m_preset.GetElementTotal(71);
			int rangeTotal = this.m_preset.GetRangeTotal(100, 109);
			TroopCount remainingPlaceableDefenders = GameEngine.Instance.Castle.getRemainingPlaceableDefenders();
			CustomSelfDrawPanel.CSDImage csdimage = new CustomSelfDrawPanel.CSDImage();
			csdimage.Image = ((elementTotal <= remainingPlaceableDefenders.peasants) ? GFXLibrary.preset_req_peasant : GFXLibrary.preset_req_peasant_red);
			csdimage.setSizeToImage();
			csdimage.Position = new Point(csdextendingPanel.Width / 5 - csdimage.Width, csdextendingPanel.Height / 4 - csdimage.Height / 2);
			csdextendingPanel.addControl(csdimage);
			csdextendingPanel.addControl(new CustomSelfDrawPanel.CSDLabel
			{
				Text = elementTotal.ToString(),
				Color = global::ARGBColors.White,
				Position = new Point(csdimage.Rectangle.Right + 5, csdimage.Y),
				Size = new Size(csdextendingPanel.Width / 3, csdimage.Height),
				Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular),
				Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT
			});
			CustomSelfDrawPanel.CSDImage csdimage2 = new CustomSelfDrawPanel.CSDImage();
			csdimage2.Image = ((elementTotal2 <= remainingPlaceableDefenders.archers) ? GFXLibrary.preset_req_archer : GFXLibrary.preset_req_archer_red);
			csdimage2.setSizeToImage();
			csdimage2.Position = new Point(csdextendingPanel.Width / 2 - csdimage2.Width, csdextendingPanel.Height / 4 - csdimage2.Height / 2);
			csdextendingPanel.addControl(csdimage2);
			csdextendingPanel.addControl(new CustomSelfDrawPanel.CSDLabel
			{
				Text = elementTotal2.ToString(),
				Color = global::ARGBColors.White,
				Position = new Point(csdimage2.Rectangle.Right + 5, csdimage2.Y),
				Size = new Size(csdextendingPanel.Width / 3, csdimage2.Height),
				Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular),
				Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT
			});
			CustomSelfDrawPanel.CSDImage csdimage3 = new CustomSelfDrawPanel.CSDImage();
			csdimage3.Image = ((elementTotal3 <= remainingPlaceableDefenders.pikemen) ? GFXLibrary.preset_req_pikeman : GFXLibrary.preset_req_pikeman_red);
			csdimage3.setSizeToImage();
			csdimage3.Position = new Point(csdextendingPanel.Width * 4 / 5 - csdimage3.Width, csdextendingPanel.Height / 4 - csdimage3.Height / 2);
			csdextendingPanel.addControl(csdimage3);
			csdextendingPanel.addControl(new CustomSelfDrawPanel.CSDLabel
			{
				Text = elementTotal3.ToString(),
				Color = global::ARGBColors.White,
				Position = new Point(csdimage3.Rectangle.Right + 5, csdimage3.Y),
				Size = new Size(csdextendingPanel.Width / 3, csdimage3.Height),
				Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular),
				Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT
			});
			CustomSelfDrawPanel.CSDImage csdimage4 = new CustomSelfDrawPanel.CSDImage();
			csdimage4.Image = ((elementTotal4 <= remainingPlaceableDefenders.swordsmen) ? GFXLibrary.preset_req_swordsman : GFXLibrary.preset_req_swordsman_red);
			csdimage4.setSizeToImage();
			csdimage4.Position = new Point(csdextendingPanel.Width / 3 - csdimage4.Width, csdextendingPanel.Height * 3 / 4 - csdimage4.Height / 2);
			csdextendingPanel.addControl(csdimage4);
			csdextendingPanel.addControl(new CustomSelfDrawPanel.CSDLabel
			{
				Text = elementTotal4.ToString(),
				Color = global::ARGBColors.White,
				Position = new Point(csdimage4.Rectangle.Right + 5, csdimage4.Y),
				Size = new Size(csdextendingPanel.Width / 2, csdimage4.Height),
				Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular),
				Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT
			});
			CustomSelfDrawPanel.CSDImage csdimage5 = new CustomSelfDrawPanel.CSDImage();
			csdimage5.Image = ((rangeTotal <= remainingPlaceableDefenders.captains) ? GFXLibrary.preset_req_captain : GFXLibrary.preset_req_captain_red);
			csdimage5.setSizeToImage();
			csdimage5.Position = new Point(csdextendingPanel.Width * 2 / 3 - csdimage5.Width, csdextendingPanel.Height * 3 / 4 - csdimage5.Height / 2);
			csdextendingPanel.addControl(csdimage5);
			csdextendingPanel.addControl(new CustomSelfDrawPanel.CSDLabel
			{
				Text = rangeTotal.ToString(),
				Color = global::ARGBColors.White,
				Position = new Point(csdimage5.Rectangle.Right + 5, csdimage5.Y),
				Size = new Size(csdextendingPanel.Width / 2, csdimage5.Height),
				Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular),
				Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT
			});
		}
	}
}
