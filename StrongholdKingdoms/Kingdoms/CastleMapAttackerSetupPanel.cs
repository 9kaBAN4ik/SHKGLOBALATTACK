using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000122 RID: 290
	public class CastleMapAttackerSetupPanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06000A4D RID: 2637 RVA: 0x000CCDCC File Offset: 0x000CAFCC
		public CastleMapAttackerSetupPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SelfDrawBackground = true;
		}

		// Token: 0x06000A4E RID: 2638 RVA: 0x0000DCB1 File Offset: 0x0000BEB1
		public void create()
		{
			this.initCastlePlacePanel();
			this.initLaunchBar();
			this.initSelectionPanel();
			this.initSelectionPanel_Captain();
		}

		// Token: 0x06000A4F RID: 2639 RVA: 0x000CD1E0 File Offset: 0x000CB3E0
		public void initCastlePlacePanel()
		{
			this.castlePlaceBackgroundArea.Position = new Point(3, 0);
			this.castlePlaceBackgroundArea.Size = base.Size;
			base.addControl(this.castlePlaceBackgroundArea);
			this.castlePlacePanelImage.Image = GFXLibrary.castlescreen_panelback_A;
			this.castlePlacePanelImage.Position = new Point(0, 0);
			this.castlePlaceBackgroundArea.addControl(this.castlePlacePanelImage);
			this.castlePlacePeasantButton.ImageNorm = GFXLibrary.r_building_miltary_peasent;
			this.castlePlacePeasantButton.ImageOver = GFXLibrary.r_building_miltary_peasent_over;
			this.castlePlacePeasantButton.Position = new Point(-9, 5);
			this.castlePlacePeasantButton.Data = 90;
			this.castlePlacePeasantButton.ClickArea = new Rectangle(10, 10, 85, 85);
			this.castlePlacePeasantButton.CustomTooltipID = 200;
			this.castlePlacePeasantButton.CustomTooltipData = 90;
			this.castlePlacePeasantButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceClick), "CastleMapAttackerSetupPanel_peasants");
			this.castlePlacePanelImage.addControl(this.castlePlacePeasantButton);
			this.castlePlacePeasantInset.Image = GFXLibrary.castlescreen_unit_capsule;
			this.castlePlacePeasantInset.Position = new Point(55, 65);
			this.castlePlacePeasantButton.addControl(this.castlePlacePeasantInset);
			this.castlePlacePeasantLabel.Text = "0";
			this.castlePlacePeasantLabel.Color = Color.FromArgb(254, 248, 229);
			this.castlePlacePeasantLabel.Position = new Point(0, -1);
			this.castlePlacePeasantLabel.Size = this.castlePlacePeasantInset.Size;
			this.castlePlacePeasantLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.castlePlacePeasantInset.addControl(this.castlePlacePeasantLabel);
			this.castlePlacePeasantCastle.Image = GFXLibrary.castlescreen_take_from_castle;
			this.castlePlacePeasantCastle.Position = new Point(15, -20);
			this.castlePlacePeasantCastle.Visible = false;
			this.castlePlacePeasantLabel.addControl(this.castlePlacePeasantCastle);
			this.castlePlaceArcherButton.ImageNorm = GFXLibrary.r_building_miltary_archer;
			this.castlePlaceArcherButton.ImageOver = GFXLibrary.r_building_miltary_archer_over;
			this.castlePlaceArcherButton.Position = new Point(73, 5);
			this.castlePlaceArcherButton.ClickArea = new Rectangle(10, 10, 85, 85);
			this.castlePlaceArcherButton.Data = 92;
			this.castlePlaceArcherButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceClick), "CastleMapAttackerSetupPanel_archers");
			this.castlePlaceArcherButton.CustomTooltipID = 200;
			this.castlePlaceArcherButton.CustomTooltipData = 92;
			this.castlePlacePanelImage.addControl(this.castlePlaceArcherButton);
			this.castlePlaceArcherInset.Image = GFXLibrary.castlescreen_unit_capsule;
			this.castlePlaceArcherInset.Position = new Point(55, 65);
			this.castlePlaceArcherButton.addControl(this.castlePlaceArcherInset);
			this.castlePlaceArcherLabel.Text = "0";
			this.castlePlaceArcherLabel.Color = Color.FromArgb(254, 248, 229);
			this.castlePlaceArcherLabel.Position = new Point(0, -1);
			this.castlePlaceArcherLabel.Size = this.castlePlaceArcherInset.Size;
			this.castlePlaceArcherLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.castlePlaceArcherInset.addControl(this.castlePlaceArcherLabel);
			this.castlePlaceArcherCastle.Image = GFXLibrary.castlescreen_take_from_castle;
			this.castlePlaceArcherCastle.Position = new Point(15, -20);
			this.castlePlaceArcherCastle.Visible = false;
			this.castlePlaceArcherLabel.addControl(this.castlePlaceArcherCastle);
			this.castlePlacePikemanButton.ImageNorm = GFXLibrary.r_building_miltary_pikemen;
			this.castlePlacePikemanButton.ImageOver = GFXLibrary.r_building_miltary_pikemen_over;
			this.castlePlacePikemanButton.Position = new Point(-9, 80);
			this.castlePlacePikemanButton.ClickArea = new Rectangle(10, 10, 85, 85);
			this.castlePlacePikemanButton.Data = 93;
			this.castlePlacePikemanButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceClick), "CastleMapAttackerSetupPanel_pikemen");
			this.castlePlacePikemanButton.CustomTooltipID = 200;
			this.castlePlacePikemanButton.CustomTooltipData = 93;
			this.castlePlacePanelImage.addControl(this.castlePlacePikemanButton);
			this.castlePlacePikemanInset.Image = GFXLibrary.castlescreen_unit_capsule;
			this.castlePlacePikemanInset.Position = new Point(55, 65);
			this.castlePlacePikemanButton.addControl(this.castlePlacePikemanInset);
			this.castlePlacePikemanLabel.Text = "0";
			this.castlePlacePikemanLabel.Color = Color.FromArgb(254, 248, 229);
			this.castlePlacePikemanLabel.Position = new Point(0, -1);
			this.castlePlacePikemanLabel.Size = this.castlePlacePikemanInset.Size;
			this.castlePlacePikemanLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.castlePlacePikemanInset.addControl(this.castlePlacePikemanLabel);
			this.castlePlacePikemanCastle.Image = GFXLibrary.castlescreen_take_from_castle;
			this.castlePlacePikemanCastle.Position = new Point(15, -20);
			this.castlePlacePikemanCastle.Visible = false;
			this.castlePlacePikemanLabel.addControl(this.castlePlacePikemanCastle);
			this.castlePlaceSwordsmanButton.ImageNorm = GFXLibrary.r_building_miltary_swordsman;
			this.castlePlaceSwordsmanButton.ImageOver = GFXLibrary.r_building_miltary_swordsman_over;
			this.castlePlaceSwordsmanButton.Position = new Point(73, 80);
			this.castlePlaceSwordsmanButton.ClickArea = new Rectangle(10, 10, 85, 85);
			this.castlePlaceSwordsmanButton.Data = 91;
			this.castlePlaceSwordsmanButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceClick), "CastleMapAttackerSetupPanel_swordsmen");
			this.castlePlaceSwordsmanButton.CustomTooltipID = 200;
			this.castlePlaceSwordsmanButton.CustomTooltipData = 91;
			this.castlePlacePanelImage.addControl(this.castlePlaceSwordsmanButton);
			this.castlePlaceSwordsmanInset.Image = GFXLibrary.castlescreen_unit_capsule;
			this.castlePlaceSwordsmanInset.Position = new Point(55, 65);
			this.castlePlaceSwordsmanButton.addControl(this.castlePlaceSwordsmanInset);
			this.castlePlaceSwordsmanLabel.Text = "0";
			this.castlePlaceSwordsmanLabel.Color = Color.FromArgb(254, 248, 229);
			this.castlePlaceSwordsmanLabel.Position = new Point(0, -1);
			this.castlePlaceSwordsmanLabel.Size = this.castlePlaceSwordsmanInset.Size;
			this.castlePlaceSwordsmanLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.castlePlaceSwordsmanInset.addControl(this.castlePlaceSwordsmanLabel);
			this.castlePlaceSwordsmanCastle.Image = GFXLibrary.castlescreen_take_from_castle;
			this.castlePlaceSwordsmanCastle.Position = new Point(15, -20);
			this.castlePlaceSwordsmanCastle.Visible = false;
			this.castlePlaceSwordsmanLabel.addControl(this.castlePlaceSwordsmanCastle);
			this.castlePlaceCatapultButton.ImageNorm = GFXLibrary.r_building_miltary_catapult;
			this.castlePlaceCatapultButton.ImageOver = GFXLibrary.r_building_miltary_catapult_over;
			this.castlePlaceCatapultButton.Position = new Point(-9, 155);
			this.castlePlaceCatapultButton.ClickArea = new Rectangle(10, 10, 85, 85);
			this.castlePlaceCatapultButton.Data = 94;
			this.castlePlaceCatapultButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceClick), "CastleMapAttackerSetupPanel_catapults");
			this.castlePlaceCatapultButton.CustomTooltipID = 200;
			this.castlePlaceCatapultButton.CustomTooltipData = 94;
			this.castlePlacePanelImage.addControl(this.castlePlaceCatapultButton);
			this.castlePlaceCatapultInset.Image = GFXLibrary.castlescreen_unit_capsule;
			this.castlePlaceCatapultInset.Position = new Point(55, 65);
			this.castlePlaceCatapultButton.addControl(this.castlePlaceCatapultInset);
			this.castlePlaceCatapultLabel.Text = "0";
			this.castlePlaceCatapultLabel.Color = Color.FromArgb(254, 248, 229);
			this.castlePlaceCatapultLabel.Position = new Point(0, 0);
			this.castlePlaceCatapultLabel.Size = this.castlePlaceCatapultInset.Size;
			this.castlePlaceCatapultLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.castlePlaceCatapultInset.addControl(this.castlePlaceCatapultLabel);
			this.castlePlaceCaptainButton.ImageNorm = GFXLibrary.r_building_miltary_captain_normal;
			this.castlePlaceCaptainButton.ImageOver = GFXLibrary.r_building_miltary_captain_over;
			this.castlePlaceCaptainButton.Position = new Point(73, 155);
			this.castlePlaceCaptainButton.ClickArea = new Rectangle(10, 10, 85, 85);
			this.castlePlaceCaptainButton.Data = 100;
			this.castlePlaceCaptainButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceClick), "CastleMapAttackerSetupPanel_captain");
			this.castlePlaceCaptainButton.CustomTooltipID = 200;
			this.castlePlaceCaptainButton.CustomTooltipData = 100;
			this.castlePlacePanelImage.addControl(this.castlePlaceCaptainButton);
			this.castlePlaceCaptainInset.Image = GFXLibrary.castlescreen_unit_capsule;
			this.castlePlaceCaptainInset.Position = new Point(55, 65);
			this.castlePlaceCaptainButton.addControl(this.castlePlaceCaptainInset);
			this.castlePlaceCaptainLabel.Text = "0";
			this.castlePlaceCaptainLabel.Color = Color.FromArgb(254, 248, 229);
			this.castlePlaceCaptainLabel.Position = new Point(0, 0);
			this.castlePlaceCaptainLabel.Size = this.castlePlaceCaptainInset.Size;
			this.castlePlaceCaptainLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.castlePlaceCaptainInset.addControl(this.castlePlaceCaptainLabel);
			this.castlePlaceSize1Button.ImageNorm = GFXLibrary.castlescreen_unitbrush_1x1_normal;
			this.castlePlaceSize1Button.ImageOver = GFXLibrary.castlescreen_unitbrush_1x1_over;
			this.castlePlaceSize1Button.Position = new Point(26, 285);
			this.castlePlaceSize1Button.Data = 1;
			this.castlePlaceSize1Button.CustomTooltipID = 207;
			this.castlePlaceSize1Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceSizeClick), "CastleMapAttackerSetupPanel_1x1");
			this.castlePlacePanelImage.addControl(this.castlePlaceSize1Button);
			this.castlePlaceSize3Button.ImageNorm = GFXLibrary.castlescreen_unitbrush_3x3_normal;
			this.castlePlaceSize3Button.ImageOver = GFXLibrary.castlescreen_unitbrush_3x3_over;
			this.castlePlaceSize3Button.Position = new Point(64, 285);
			this.castlePlaceSize3Button.Data = 3;
			this.castlePlaceSize3Button.CustomTooltipID = 208;
			this.castlePlaceSize3Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceSizeClick), "CastleMapAttackerSetupPanel_3x3");
			this.castlePlacePanelImage.addControl(this.castlePlaceSize3Button);
			this.castlePlaceSize5Button.ImageNorm = GFXLibrary.castlescreen_unitbrush_5x5_normal;
			this.castlePlaceSize5Button.ImageOver = GFXLibrary.castlescreen_unitbrush_5x5_over;
			this.castlePlaceSize5Button.Position = new Point(102, 285);
			this.castlePlaceSize5Button.Data = 5;
			this.castlePlaceSize5Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceSizeClick), "CastleMapAttackerSetupPanel_5x5");
			this.castlePlaceSize5Button.CustomTooltipID = 209;
			this.castlePlacePanelImage.addControl(this.castlePlaceSize5Button);
			this.castlePlaceSize15Button.ImageNorm = GFXLibrary.castlescreen_unitbrush_1x5_normal;
			this.castlePlaceSize15Button.ImageOver = GFXLibrary.castlescreen_unitbrush_1x5_over;
			this.castlePlaceSize15Button.Position = new Point(140, 285);
			this.castlePlaceSize15Button.Data = 15;
			this.castlePlaceSize15Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceSizeClick), "CastleMapAttackerSetupPanel_1x5");
			this.castlePlaceSize15Button.CustomTooltipID = 210;
			this.castlePlacePanelImage.addControl(this.castlePlaceSize15Button);
			this.castlePlacePanelFaderImage.Image = GFXLibrary.castlescreen_panelback_A;
			this.castlePlacePanelFaderImage.Position = new Point(0, 0);
			this.castlePlacePanelFaderImage.Alpha = 0f;
			this.castlePlacePanelImage.addControl(this.castlePlacePanelFaderImage);
		}

		// Token: 0x06000A50 RID: 2640 RVA: 0x000CDE08 File Offset: 0x000CC008
		private void castlePlaceClick()
		{
			CustomSelfDrawPanel.CSDControl overControl = this.OverControl;
			if (overControl != null)
			{
				int data = overControl.Data;
				this.setPlaceSize(this.placementSize);
				if (GameEngine.Instance.CastleAttackerSetup.checkNormalTroopsAvailable(data))
				{
					GameEngine.Instance.CastleAttackerSetup.setUsingCastleTroops(false);
				}
				else
				{
					GameEngine.Instance.CastleAttackerSetup.setUsingCastleTroops(true);
				}
				GameEngine.Instance.CastleAttackerSetup.startPlacingAttackerTroops(data);
			}
		}

		// Token: 0x06000A51 RID: 2641 RVA: 0x000CDE78 File Offset: 0x000CC078
		private void castlePlaceSizeClick()
		{
			CustomSelfDrawPanel.CSDControl overControl = this.OverControl;
			if (overControl != null)
			{
				int data = overControl.Data;
				int data2 = overControl.Data;
				this.setPlaceSize(data2);
			}
		}

		// Token: 0x06000A52 RID: 2642 RVA: 0x000CDEA8 File Offset: 0x000CC0A8
		private void setPlaceSize(int size)
		{
			this.placementSize = size;
			switch (size)
			{
			case 1:
				if (GameEngine.Instance.CastleAttackerSetup != null)
				{
					GameEngine.Instance.CastleAttackerSetup.CurrentBrushSize = CastleMap.BrushSize.BRUSH_1X1;
				}
				this.castlePlaceSize1Button.ImageNorm = GFXLibrary.castlescreen_unitbrush_1x1_selected;
				this.castlePlaceSize1Button.ImageOver = GFXLibrary.castlescreen_unitbrush_1x1_selected;
				this.castlePlaceSize3Button.ImageNorm = GFXLibrary.castlescreen_unitbrush_3x3_normal;
				this.castlePlaceSize3Button.ImageOver = GFXLibrary.castlescreen_unitbrush_3x3_over;
				this.castlePlaceSize5Button.ImageNorm = GFXLibrary.castlescreen_unitbrush_5x5_normal;
				this.castlePlaceSize5Button.ImageOver = GFXLibrary.castlescreen_unitbrush_5x5_over;
				this.castlePlaceSize15Button.ImageNorm = GFXLibrary.castlescreen_unitbrush_1x5_normal;
				this.castlePlaceSize15Button.ImageOver = GFXLibrary.castlescreen_unitbrush_1x5_over;
				return;
			case 2:
			case 4:
				break;
			case 3:
				if (GameEngine.Instance.CastleAttackerSetup != null)
				{
					GameEngine.Instance.CastleAttackerSetup.CurrentBrushSize = CastleMap.BrushSize.BRUSH_3X3;
				}
				this.castlePlaceSize1Button.ImageNorm = GFXLibrary.castlescreen_unitbrush_1x1_normal;
				this.castlePlaceSize1Button.ImageOver = GFXLibrary.castlescreen_unitbrush_1x1_over;
				this.castlePlaceSize3Button.ImageNorm = GFXLibrary.castlescreen_unitbrush_3x3_selected;
				this.castlePlaceSize3Button.ImageOver = GFXLibrary.castlescreen_unitbrush_3x3_selected;
				this.castlePlaceSize5Button.ImageNorm = GFXLibrary.castlescreen_unitbrush_5x5_normal;
				this.castlePlaceSize5Button.ImageOver = GFXLibrary.castlescreen_unitbrush_5x5_over;
				this.castlePlaceSize15Button.ImageNorm = GFXLibrary.castlescreen_unitbrush_1x5_normal;
				this.castlePlaceSize15Button.ImageOver = GFXLibrary.castlescreen_unitbrush_1x5_over;
				return;
			case 5:
				if (GameEngine.Instance.CastleAttackerSetup != null)
				{
					GameEngine.Instance.CastleAttackerSetup.CurrentBrushSize = CastleMap.BrushSize.BRUSH_5X5;
				}
				this.castlePlaceSize1Button.ImageNorm = GFXLibrary.castlescreen_unitbrush_1x1_normal;
				this.castlePlaceSize1Button.ImageOver = GFXLibrary.castlescreen_unitbrush_1x1_over;
				this.castlePlaceSize3Button.ImageNorm = GFXLibrary.castlescreen_unitbrush_3x3_normal;
				this.castlePlaceSize3Button.ImageOver = GFXLibrary.castlescreen_unitbrush_3x3_over;
				this.castlePlaceSize5Button.ImageNorm = GFXLibrary.castlescreen_unitbrush_5x5_selected;
				this.castlePlaceSize5Button.ImageOver = GFXLibrary.castlescreen_unitbrush_5x5_selected;
				this.castlePlaceSize15Button.ImageNorm = GFXLibrary.castlescreen_unitbrush_1x5_normal;
				this.castlePlaceSize15Button.ImageOver = GFXLibrary.castlescreen_unitbrush_1x5_over;
				return;
			default:
				if (size != 15)
				{
					return;
				}
				if (GameEngine.Instance.CastleAttackerSetup != null)
				{
					GameEngine.Instance.CastleAttackerSetup.CurrentBrushSize = CastleMap.BrushSize.BRUSH_1X5;
				}
				this.castlePlaceSize1Button.ImageNorm = GFXLibrary.castlescreen_unitbrush_1x1_normal;
				this.castlePlaceSize1Button.ImageOver = GFXLibrary.castlescreen_unitbrush_1x1_over;
				this.castlePlaceSize3Button.ImageNorm = GFXLibrary.castlescreen_unitbrush_3x3_normal;
				this.castlePlaceSize3Button.ImageOver = GFXLibrary.castlescreen_unitbrush_3x3_over;
				this.castlePlaceSize5Button.ImageNorm = GFXLibrary.castlescreen_unitbrush_5x5_normal;
				this.castlePlaceSize5Button.ImageOver = GFXLibrary.castlescreen_unitbrush_5x5_over;
				this.castlePlaceSize15Button.ImageNorm = GFXLibrary.castlescreen_unitbrush_1x5_selected;
				this.castlePlaceSize15Button.ImageOver = GFXLibrary.castlescreen_unitbrush_1x5_selected;
				break;
			}
		}

		// Token: 0x06000A53 RID: 2643 RVA: 0x0000DCCB File Offset: 0x0000BECB
		public void init()
		{
			this.setPlaceSize(3);
		}

		// Token: 0x06000A54 RID: 2644 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void Run()
		{
		}

		// Token: 0x06000A55 RID: 2645 RVA: 0x000CE1F4 File Offset: 0x000CC3F4
		public void initLaunchBar()
		{
			int num = this.calcLaunchBarYPos();
			this.launchHeaderButton.ImageNorm = GFXLibrary.infobar_03;
			this.launchHeaderButton.ImageHighlight = GFXLibrary.infobar_03_over;
			this.launchHeaderButton.Position = new Point(0, num);
			this.launchHeaderButton.Text.Text = SK.Text("GENERIC_Launch_Attack", "Launch Attack");
			this.launchHeaderButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.launchHeaderButton.TextYOffset = -5;
			this.launchHeaderButton.Enabled = false;
			this.launchHeaderButton.Text.Color = global::ARGBColors.Black;
			this.launchHeaderButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.launchAttack), "CastleMapAttackerSetupPanel_launch");
			this.castlePlaceBackgroundArea.addControl(this.launchHeaderButton);
			this.cancelButton.ImageNorm = GFXLibrary.int_but_delete_norm;
			this.cancelButton.ImageOver = GFXLibrary.int_but_delete_over;
			this.cancelButton.Position = new Point(0, num + 40 + 10);
			this.cancelButton.Size = new Size(196, this.cancelButton.ImageNorm.Height);
			this.cancelButton.Text.Text = SK.Text("CastleMapAttackerSetup_Cancel_Attack", "Cancel Attack");
			this.cancelButton.Text.Size = this.cancelButton.Size;
			this.cancelButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.cancelButton.TextYOffset = 0;
			this.cancelButton.Text.Color = global::ARGBColors.Black;
			this.cancelButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.cancelAttack), "CastleMapAttackerSetupPanel_cancel");
			this.castlePlaceBackgroundArea.addControl(this.cancelButton);
			this.advancedButton.ImageNorm = GFXLibrary.int_but_delete_norm;
			this.advancedButton.ImageOver = GFXLibrary.int_but_delete_over;
			this.advancedButton.Position = new Point(0, num + 40 + 40 + 10);
			this.advancedButton.Size = new Size(196, this.advancedButton.ImageNorm.Height);
			this.advancedButton.Text.Text = SK.Text("CastleMapPanel_Local_Setups", "Local Setups");
			this.advancedButton.Text.Size = this.advancedButton.Size;
			this.advancedButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.advancedButton.TextYOffset = 0;
			this.advancedButton.Text.Color = global::ARGBColors.Black;
			this.advancedButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.utilAdvancedClick), "CastleMapPanel_advanced_options");
			this.castlePlaceBackgroundArea.addControl(this.advancedButton);
			this.cloudButton.ImageNorm = GFXLibrary.int_but_delete_blue_norm;
			this.cloudButton.ImageOver = GFXLibrary.int_but_delete_blue_over;
			this.cloudButton.Position = new Point(0, num + 40 + 80 + 10);
			this.cloudButton.Size = new Size(196, this.cloudButton.ImageNorm.Height);
			this.cloudButton.Text.Text = SK.Text("CastleMapPanel_Cloud_Setups", "Cloud Setups");
			this.cloudButton.Text.Size = this.cloudButton.Size;
			this.cloudButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.cloudButton.TextYOffset = 0;
			this.cloudButton.Text.Color = global::ARGBColors.Black;
			this.cloudButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.utilCloudClick), "CastleMapPanel_advanced_options");
			this.castlePlaceBackgroundArea.addControl(this.cloudButton);
			this.loadButton.ImageNorm = GFXLibrary.int_but_delete_norm;
			this.loadButton.ImageOver = GFXLibrary.int_but_delete_over;
			this.loadButton.Position = new Point(42, num + 55 + 30);
			this.loadButton.Text.Text = "Load";
			this.loadButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.loadButton.TextYOffset = 1;
			this.loadButton.Visible = false;
			this.loadButton.Text.Color = global::ARGBColors.Black;
			this.loadButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.DEBUG_load));
			this.castlePlaceBackgroundArea.addControl(this.loadButton);
			this.saveButton.ImageNorm = GFXLibrary.int_but_delete_norm;
			this.saveButton.ImageOver = GFXLibrary.int_but_delete_over;
			this.saveButton.Position = new Point(42, num + 55 + 60);
			this.saveButton.Text.Text = "Save";
			this.saveButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.saveButton.TextYOffset = 1;
			this.saveButton.Visible = false;
			this.saveButton.Text.Color = global::ARGBColors.Black;
			this.saveButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.DEBUG_save));
			this.castlePlaceBackgroundArea.addControl(this.saveButton);
			this.aiExportButton.ImageNorm = GFXLibrary.int_but_delete_norm;
			this.aiExportButton.ImageOver = GFXLibrary.int_but_delete_over;
			this.aiExportButton.Position = new Point(42, num + 55 + 90);
			this.aiExportButton.Text.Text = "AI Export";
			this.aiExportButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.aiExportButton.TextYOffset = 1;
			this.aiExportButton.Visible = false;
			this.aiExportButton.Text.Color = global::ARGBColors.Black;
			this.aiExportButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.DEBUG_export));
			this.castlePlaceBackgroundArea.addControl(this.aiExportButton);
		}

		// Token: 0x06000A56 RID: 2646 RVA: 0x0000DCD4 File Offset: 0x0000BED4
		private int calcLaunchBarYPos()
		{
			return 366;
		}

		// Token: 0x06000A57 RID: 2647 RVA: 0x000CE878 File Offset: 0x000CCA78
		private void launchAttack()
		{
			if (this.loadButton.Visible)
			{
				GameEngine.Instance.CastleAttackerSetup.launchArmy(false);
				return;
			}
			this.armyLaunched = false;
			SendArmyWindow sendArmyWindow = InterfaceMgr.Instance.openLaunchAttackPopup();
			int attackRealTargetVillage = GameEngine.Instance.CastleAttackerSetup.attackRealTargetVillage;
			int attackRealAttackingVillage = GameEngine.Instance.CastleAttackerSetup.attackRealAttackingVillage;
			int parentOfAttackingVillage = GameEngine.Instance.CastleAttackerSetup.ParentOfAttackingVillage;
			string villageName;
			if (!GameEngine.Instance.World.isSpecial(attackRealTargetVillage))
			{
				villageName = ((GameEngine.Instance.CastleAttackerSetup.m_targetUserName == null || GameEngine.Instance.CastleAttackerSetup.m_targetUserName.Length <= 0) ? GameEngine.Instance.World.getVillageName(attackRealTargetVillage) : (GameEngine.Instance.World.getVillageName(attackRealTargetVillage) + " (" + GameEngine.Instance.CastleAttackerSetup.m_targetUserName + ")"));
			}
			else
			{
				int special = GameEngine.Instance.World.getSpecial(attackRealTargetVillage);
				villageName = SpecialVillageTypes.getName(special, Program.mySettings.LanguageIdent);
			}
			WorldData localWorldData = GameEngine.Instance.LocalWorldData;
			Point villageLocation = GameEngine.Instance.World.getVillageLocation(attackRealAttackingVillage);
			Point villageLocation2 = GameEngine.Instance.World.getVillageLocation(attackRealTargetVillage);
			int x = villageLocation.X;
			int y = villageLocation.Y;
			int x2 = villageLocation2.X;
			int y2 = villageLocation2.Y;
			double num = (double)((x - x2) * (x - x2) + (y - y2) * (y - y2));
			num = Math.Sqrt(num);
			if (!GameEngine.Instance.World.isCapital(parentOfAttackingVillage) && !GameEngine.Instance.World.isCapital(attackRealAttackingVillage))
			{
				num = ((!GameEngine.Instance.CastleAttackerSetup.containsCaptain()) ? (num * (localWorldData.armyMoveSpeed * localWorldData.gamePlaySpeed * ResearchData.ArmyTimes[(int)GameEngine.Instance.World.GetResearchDataForCurrentVillage().Research_ForcedMarch])) : (num * (localWorldData.CaptainsMoveSpeed * localWorldData.gamePlaySpeed * ResearchData.CaptainTimes[(int)GameEngine.Instance.World.GetResearchDataForCurrentVillage().Research_Courtiers])));
			}
			else
			{
				double num2 = GameEngine.Instance.CastleAttackerSetup.CapitalAttackRate;
				if (num2 == 0.0)
				{
					num2 = 1.0;
				}
				num *= localWorldData.armyMoveSpeed * localWorldData.gamePlaySpeed * num2;
			}
			bool gotCaptain = GameEngine.Instance.CastleAttackerSetup.captainPlaced();
			sendArmyWindow.init(parentOfAttackingVillage, attackRealAttackingVillage, attackRealTargetVillage, villageName, num, GameEngine.Instance.CastleAttackerSetup.m_battleHonourData, gotCaptain, this);
			GameEngine.Instance.DisableMouseClicks();
			bool flag = this.armyLaunched;
		}

		// Token: 0x06000A58 RID: 2648 RVA: 0x0000DCDB File Offset: 0x0000BEDB
		public void launched()
		{
			this.armyLaunched = true;
			this.launchHeaderButton.Enabled = false;
		}

		// Token: 0x06000A59 RID: 2649 RVA: 0x0000DCF0 File Offset: 0x0000BEF0
		private void cancelAttack()
		{
			InterfaceMgr.Instance.toggleDXCardBarActive(true);
			InterfaceMgr.Instance.getMainTabBar().changeTab(9);
			InterfaceMgr.Instance.getMainTabBar().changeTab(0);
		}

		// Token: 0x06000A5A RID: 2650 RVA: 0x0000DD1E File Offset: 0x0000BF1E
		private void utilAdvancedClick()
		{
			if (GameEngine.Instance.CastleAttackerSetup != null)
			{
				InterfaceMgr.Instance.openFormationPopup();
			}
		}

		// Token: 0x06000A5B RID: 2651 RVA: 0x0000DD37 File Offset: 0x0000BF37
		private void utilCloudClick()
		{
			if (GameEngine.Instance.CastleAttackerSetup != null)
			{
				InterfaceMgr.Instance.openPresetPopup(PresetType.TROOP_ATTACK);
			}
		}

		// Token: 0x06000A5C RID: 2652 RVA: 0x000CEB20 File Offset: 0x000CCD20
		public void initSelectionPanel()
		{
			this.castleSelectionBackgroundArea.Position = new Point(0, 0);
			this.castleSelectionBackgroundArea.Size = base.Size;
			this.castleSelectionBackgroundArea.Visible = false;
			base.addControl(this.castleSelectionBackgroundArea);
			this.castleSelectionPanelImage.Image = GFXLibrary.castlescreen_panelback_B;
			this.castleSelectionPanelImage.Position = new Point(0, 0);
			this.castleSelectionBackgroundArea.addControl(this.castleSelectionPanelImage);
			this.closeButton.ImageNorm = GFXLibrary.int_button_close_normal;
			this.closeButton.ImageOver = GFXLibrary.int_button_close_over;
			this.closeButton.ImageClick = GFXLibrary.int_button_close_in;
			this.closeButton.Position = new Point(153, 6);
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "CastleMapAttackerSetupPanel_close");
			this.castleSelectionBackgroundArea.addControl(this.closeButton);
			this.castleSelectionInset1Image.Image = GFXLibrary.castlescreen_panel_halfinset_off_select;
			this.castleSelectionInset1Image.Position = new Point(3, 28);
			this.castleSelectionPanelImage.addControl(this.castleSelectionInset1Image);
			this.castleSelectionPeasantImage.Image = GFXLibrary.r_building_miltary_peasent;
			this.castleSelectionPeasantImage.Position = new Point(-10, -20);
			this.castleSelectionInset1Image.addControl(this.castleSelectionPeasantImage);
			this.castleSelectionPeasantInset.Image = GFXLibrary.castlescreen_unit_capsule;
			this.castleSelectionPeasantInset.Position = new Point(70, 60);
			this.castleSelectionPeasantImage.addControl(this.castleSelectionPeasantInset);
			this.castleSelectionPeasantLabel.Text = "0";
			this.castleSelectionPeasantLabel.Color = Color.FromArgb(254, 248, 229);
			this.castleSelectionPeasantLabel.Position = new Point(0, 0);
			this.castleSelectionPeasantLabel.Size = this.castleSelectionPeasantInset.Size;
			this.castleSelectionPeasantLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.castleSelectionPeasantInset.addControl(this.castleSelectionPeasantLabel);
			this.castleSelectionPeasantDeleteButton.ImageNorm = GFXLibrary.castlescreen_sendback_normal;
			this.castleSelectionPeasantDeleteButton.ImageOver = GFXLibrary.castlescreen_sendback_over;
			this.castleSelectionPeasantDeleteButton.Position = new Point(125, 13);
			this.castleSelectionPeasantDeleteButton.Data = 90;
			this.castleSelectionPeasantDeleteButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.troopDeleteClick), "CastleMapAttackerSetupPanel_delete_peasants");
			this.castleSelectionInset1Image.addControl(this.castleSelectionPeasantDeleteButton);
			this.castleSelectionInset2Image.Image = GFXLibrary.castlescreen_panel_halfinset_off_select;
			this.castleSelectionInset2Image.Position = new Point(3, 108);
			this.castleSelectionPanelImage.addControl(this.castleSelectionInset2Image);
			this.castleSelectionArcherImage.Image = GFXLibrary.r_building_miltary_archer;
			this.castleSelectionArcherImage.Position = new Point(-10, -20);
			this.castleSelectionInset2Image.addControl(this.castleSelectionArcherImage);
			this.castleSelectionArcherInset.Image = GFXLibrary.castlescreen_unit_capsule;
			this.castleSelectionArcherInset.Position = new Point(70, 60);
			this.castleSelectionArcherImage.addControl(this.castleSelectionArcherInset);
			this.castleSelectionArcherLabel.Text = "0";
			this.castleSelectionArcherLabel.Color = Color.FromArgb(254, 248, 229);
			this.castleSelectionArcherLabel.Position = new Point(0, 0);
			this.castleSelectionArcherLabel.Size = this.castleSelectionArcherInset.Size;
			this.castleSelectionArcherLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.castleSelectionArcherInset.addControl(this.castleSelectionArcherLabel);
			this.castleSelectionArcherDeleteButton.ImageNorm = GFXLibrary.castlescreen_sendback_normal;
			this.castleSelectionArcherDeleteButton.ImageOver = GFXLibrary.castlescreen_sendback_over;
			this.castleSelectionArcherDeleteButton.Position = new Point(125, 13);
			this.castleSelectionArcherDeleteButton.Data = 92;
			this.castleSelectionArcherDeleteButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.troopDeleteClick), "CastleMapAttackerSetupPanel_delete_archers");
			this.castleSelectionInset2Image.addControl(this.castleSelectionArcherDeleteButton);
			this.castleSelectionInset3Image.Image = GFXLibrary.castlescreen_panel_halfinset_off_select;
			this.castleSelectionInset3Image.Position = new Point(3, 188);
			this.castleSelectionPanelImage.addControl(this.castleSelectionInset3Image);
			this.castleSelectionPikemanImage.Image = GFXLibrary.r_building_miltary_pikemen;
			this.castleSelectionPikemanImage.Position = new Point(-10, -20);
			this.castleSelectionInset3Image.addControl(this.castleSelectionPikemanImage);
			this.castleSelectionPikemanInset.Image = GFXLibrary.castlescreen_unit_capsule;
			this.castleSelectionPikemanInset.Position = new Point(70, 60);
			this.castleSelectionPikemanImage.addControl(this.castleSelectionPikemanInset);
			this.castleSelectionPikemanLabel.Text = "0";
			this.castleSelectionPikemanLabel.Color = Color.FromArgb(254, 248, 229);
			this.castleSelectionPikemanLabel.Position = new Point(0, 0);
			this.castleSelectionPikemanLabel.Size = this.castleSelectionPikemanInset.Size;
			this.castleSelectionPikemanLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.castleSelectionPikemanInset.addControl(this.castleSelectionPikemanLabel);
			this.castleSelectionPikemanDeleteButton.ImageNorm = GFXLibrary.castlescreen_sendback_normal;
			this.castleSelectionPikemanDeleteButton.ImageOver = GFXLibrary.castlescreen_sendback_over;
			this.castleSelectionPikemanDeleteButton.Position = new Point(125, 13);
			this.castleSelectionPikemanDeleteButton.Data = 93;
			this.castleSelectionPikemanDeleteButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.troopDeleteClick), "CastleMapAttackerSetupPanel_delete_pikemen");
			this.castleSelectionInset3Image.addControl(this.castleSelectionPikemanDeleteButton);
			this.castleSelectionInset4Image.Image = GFXLibrary.castlescreen_panel_halfinset_off_select;
			this.castleSelectionInset4Image.Position = new Point(3, 268);
			this.castleSelectionPanelImage.addControl(this.castleSelectionInset4Image);
			this.castleSelectionSwordsmanImage.Image = GFXLibrary.r_building_miltary_swordsman;
			this.castleSelectionSwordsmanImage.Position = new Point(-10, -20);
			this.castleSelectionInset4Image.addControl(this.castleSelectionSwordsmanImage);
			this.castleSelectionSwordsmanInset.Image = GFXLibrary.castlescreen_unit_capsule;
			this.castleSelectionSwordsmanInset.Position = new Point(70, 60);
			this.castleSelectionSwordsmanImage.addControl(this.castleSelectionSwordsmanInset);
			this.castleSelectionSwordsmanLabel.Text = "0";
			this.castleSelectionSwordsmanLabel.Color = Color.FromArgb(254, 248, 229);
			this.castleSelectionSwordsmanLabel.Position = new Point(0, 0);
			this.castleSelectionSwordsmanLabel.Size = this.castleSelectionSwordsmanInset.Size;
			this.castleSelectionSwordsmanLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.castleSelectionSwordsmanInset.addControl(this.castleSelectionSwordsmanLabel);
			this.castleSelectionSwordsmanDeleteButton.ImageNorm = GFXLibrary.castlescreen_sendback_normal;
			this.castleSelectionSwordsmanDeleteButton.ImageOver = GFXLibrary.castlescreen_sendback_over;
			this.castleSelectionSwordsmanDeleteButton.Position = new Point(125, 13);
			this.castleSelectionSwordsmanDeleteButton.Data = 91;
			this.castleSelectionSwordsmanDeleteButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.troopDeleteClick), "CastleMapAttackerSetupPanel_delete_swordsmen");
			this.castleSelectionInset4Image.addControl(this.castleSelectionSwordsmanDeleteButton);
			this.castleSelectionInset5Image.Image = GFXLibrary.castlescreen_panel_halfinset_off_select;
			this.castleSelectionInset5Image.Position = new Point(3, 348);
			this.castleSelectionPanelImage.addControl(this.castleSelectionInset5Image);
			this.castleSelectionCatapultImage.Image = GFXLibrary.r_building_miltary_catapult;
			this.castleSelectionCatapultImage.Position = new Point(-10, -20);
			this.castleSelectionInset5Image.addControl(this.castleSelectionCatapultImage);
			this.castleSelectionCatapultInset.Image = GFXLibrary.castlescreen_unit_capsule;
			this.castleSelectionCatapultInset.Position = new Point(70, 60);
			this.castleSelectionCatapultImage.addControl(this.castleSelectionCatapultInset);
			this.castleSelectionCatapultLabel.Text = "0";
			this.castleSelectionCatapultLabel.Color = Color.FromArgb(254, 248, 229);
			this.castleSelectionCatapultLabel.Position = new Point(0, 0);
			this.castleSelectionCatapultLabel.Size = this.castleSelectionCatapultInset.Size;
			this.castleSelectionCatapultLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.castleSelectionCatapultInset.addControl(this.castleSelectionCatapultLabel);
			this.castleSelectionCatapultDeleteButton.ImageNorm = GFXLibrary.castlescreen_sendback_normal;
			this.castleSelectionCatapultDeleteButton.ImageOver = GFXLibrary.castlescreen_sendback_over;
			this.castleSelectionCatapultDeleteButton.Position = new Point(125, 13);
			this.castleSelectionCatapultDeleteButton.Data = 94;
			this.castleSelectionCatapultDeleteButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.troopDeleteClick), "CastleMapAttackerSetupPanel_delete_catapults");
			this.castleSelectionInset5Image.addControl(this.castleSelectionCatapultDeleteButton);
			this.castleSelectionInset6Image.Image = GFXLibrary.castlescreen_panel_halfinset_off_select;
			this.castleSelectionInset6Image.Position = new Point(3, 428);
			this.castleSelectionPanelImage.addControl(this.castleSelectionInset6Image);
			this.castleSelectionCaptainImage.Image = GFXLibrary.r_building_miltary_captain_normal;
			this.castleSelectionCaptainImage.Position = new Point(-10, -20);
			this.castleSelectionInset6Image.addControl(this.castleSelectionCaptainImage);
			this.castleSelectionCaptainInset.Image = GFXLibrary.castlescreen_unit_capsule;
			this.castleSelectionCaptainInset.Position = new Point(70, 60);
			this.castleSelectionCaptainImage.addControl(this.castleSelectionCaptainInset);
			this.castleSelectionCaptainLabel.Text = "0";
			this.castleSelectionCaptainLabel.Color = Color.FromArgb(254, 248, 229);
			this.castleSelectionCaptainLabel.Position = new Point(0, 0);
			this.castleSelectionCaptainLabel.Size = this.castleSelectionCaptainInset.Size;
			this.castleSelectionCaptainLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.castleSelectionCaptainInset.addControl(this.castleSelectionCaptainLabel);
			this.castleSelectionCaptainDeleteButton.ImageNorm = GFXLibrary.castlescreen_sendback_normal;
			this.castleSelectionCaptainDeleteButton.ImageOver = GFXLibrary.castlescreen_sendback_over;
			this.castleSelectionCaptainDeleteButton.Position = new Point(125, 13);
			this.castleSelectionCaptainDeleteButton.Data = 100;
			this.castleSelectionCaptainDeleteButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.troopDeleteClick), "CastleMapAttackerSetupPanel_delete_captains");
			this.castleSelectionInset6Image.addControl(this.castleSelectionCaptainDeleteButton);
		}

		// Token: 0x06000A5D RID: 2653 RVA: 0x000CF5C4 File Offset: 0x000CD7C4
		public void setSelectedTroop(int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults, int numCaptains, int captainsCommand, int captainsData)
		{
			GameEngine.Instance.playInterfaceSound("CastleMapPanel_open_selected_troops_panel");
			if (numCaptains == 1 && numPeasants == 0 && numArchers == 0 && numPikemen == 0 && numSwordsmen == 0 && numCatapults == 0)
			{
				if (!this.captain_castleSelectionBackgroundArea.Visible)
				{
					int num = 0;
					if (captainsData > 0)
					{
						num = captainsData / 5 - 1;
						if (num < 0)
						{
							num = 0;
						}
					}
					this.captain_commandValueTrack.Value = num;
					this.tracksMoved();
					this.updateCaptainCommands(captainsCommand);
				}
				this.castleSelectionBackgroundArea.Visible = false;
				this.captain_castleSelectionBackgroundArea.Visible = true;
				this.castlePlaceBackgroundArea.Visible = false;
				this.captain_castleSelectionCaptainLabel.Text = numCaptains.ToString();
				this.captain_castleSelectionCaptainDeleteButton.Enabled = (numCaptains > 0);
				return;
			}
			this.castleSelectionBackgroundArea.Visible = true;
			this.captain_castleSelectionBackgroundArea.Visible = false;
			this.castlePlaceBackgroundArea.Visible = false;
			this.castleSelectionPeasantLabel.Text = numPeasants.ToString();
			this.castleSelectionArcherLabel.Text = numArchers.ToString();
			this.castleSelectionPikemanLabel.Text = numPikemen.ToString();
			this.castleSelectionSwordsmanLabel.Text = numSwordsmen.ToString();
			this.castleSelectionCatapultLabel.Text = numCatapults.ToString();
			this.castleSelectionCaptainLabel.Text = numCaptains.ToString();
			this.castleSelectionPeasantDeleteButton.Enabled = (numPeasants > 0);
			this.castleSelectionArcherDeleteButton.Enabled = (numArchers > 0);
			this.castleSelectionPikemanDeleteButton.Enabled = (numPikemen > 0);
			this.castleSelectionSwordsmanDeleteButton.Enabled = (numSwordsmen > 0);
			this.castleSelectionCatapultDeleteButton.Enabled = (numCatapults > 0);
			this.castleSelectionCaptainDeleteButton.Enabled = (numCaptains > 0);
		}

		// Token: 0x06000A5E RID: 2654 RVA: 0x0000DD51 File Offset: 0x0000BF51
		public void clearSelectedTroop()
		{
			this.castleSelectionBackgroundArea.Visible = false;
			this.captain_castleSelectionBackgroundArea.Visible = false;
			this.castlePlaceBackgroundArea.Visible = true;
		}

		// Token: 0x06000A5F RID: 2655 RVA: 0x000CF778 File Offset: 0x000CD978
		private void troopDeleteClick()
		{
			if (this.OverControl != null)
			{
				CustomSelfDrawPanel.CSDControl overControl = this.OverControl;
				int data = overControl.Data;
				GameEngine.Instance.CastleAttackerSetup.startDeleteAttackingTroops(data);
				if (data == 100)
				{
					GameEngine.Instance.CastleAttackerSetup.startDeleteAttackingTroops(102);
					GameEngine.Instance.CastleAttackerSetup.startDeleteAttackingTroops(104);
					GameEngine.Instance.CastleAttackerSetup.startDeleteAttackingTroops(103);
					GameEngine.Instance.CastleAttackerSetup.startDeleteAttackingTroops(105);
					GameEngine.Instance.CastleAttackerSetup.startDeleteAttackingTroops(106);
					GameEngine.Instance.CastleAttackerSetup.startDeleteAttackingTroops(107);
					GameEngine.Instance.CastleAttackerSetup.startDeleteAttackingTroops(101);
				}
			}
		}

		// Token: 0x06000A60 RID: 2656 RVA: 0x0000DD77 File Offset: 0x0000BF77
		private void closeClick()
		{
			GameEngine.Instance.CastleAttackerSetup.clearLasso();
		}

		// Token: 0x06000A61 RID: 2657 RVA: 0x000CF82C File Offset: 0x000CDA2C
		public void initSelectionPanel_Captain()
		{
			this.captain_castleSelectionBackgroundArea.Position = new Point(0, 0);
			this.captain_castleSelectionBackgroundArea.Size = base.Size;
			this.captain_castleSelectionBackgroundArea.Visible = false;
			base.addControl(this.captain_castleSelectionBackgroundArea);
			this.captain_castleSelectionPanelImage.Image = GFXLibrary.castlescreen_panelback_B;
			this.captain_castleSelectionPanelImage.Position = new Point(0, 0);
			this.captain_castleSelectionBackgroundArea.addControl(this.captain_castleSelectionPanelImage);
			this.captain_closeButton.ImageNorm = GFXLibrary.int_button_close_normal;
			this.captain_closeButton.ImageOver = GFXLibrary.int_button_close_over;
			this.captain_closeButton.ImageClick = GFXLibrary.int_button_close_in;
			this.captain_closeButton.Position = new Point(153, 6);
			this.captain_closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "CastleMapAttackerSetupPanel_close");
			this.captain_castleSelectionBackgroundArea.addControl(this.captain_closeButton);
			this.captain_castleSelectionInset6Image.Image = GFXLibrary.castlescreen_panel_halfinset_off_select;
			this.captain_castleSelectionInset6Image.Position = new Point(3, 28);
			this.captain_castleSelectionPanelImage.addControl(this.captain_castleSelectionInset6Image);
			this.captain_castleSelectionCaptainImage.Image = GFXLibrary.r_building_miltary_captain_normal;
			this.captain_castleSelectionCaptainImage.Position = new Point(-10, -20);
			this.captain_castleSelectionInset6Image.addControl(this.captain_castleSelectionCaptainImage);
			this.captain_castleSelectionCaptainInset.Image = GFXLibrary.castlescreen_unit_capsule;
			this.captain_castleSelectionCaptainInset.Position = new Point(70, 60);
			this.captain_castleSelectionCaptainImage.addControl(this.captain_castleSelectionCaptainInset);
			this.captain_castleSelectionCaptainLabel.Text = "0";
			this.captain_castleSelectionCaptainLabel.Color = Color.FromArgb(254, 248, 229);
			this.captain_castleSelectionCaptainLabel.Position = new Point(0, 0);
			this.captain_castleSelectionCaptainLabel.Size = this.castleSelectionCaptainInset.Size;
			this.captain_castleSelectionCaptainLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.captain_castleSelectionCaptainInset.addControl(this.captain_castleSelectionCaptainLabel);
			this.captain_castleSelectionCaptainDeleteButton.ImageNorm = GFXLibrary.castlescreen_sendback_normal;
			this.captain_castleSelectionCaptainDeleteButton.ImageOver = GFXLibrary.castlescreen_sendback_over;
			this.captain_castleSelectionCaptainDeleteButton.Position = new Point(125, 13);
			this.captain_castleSelectionCaptainDeleteButton.Data = 100;
			this.captain_castleSelectionCaptainDeleteButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.troopDeleteClick), "CastleMapAttackerSetupPanel_delete_captains");
			this.captain_castleSelectionInset6Image.addControl(this.captain_castleSelectionCaptainDeleteButton);
			this.captain_castleSelectionCommand1.ImageNorm = GFXLibrary.captains_commands_icons[16];
			this.captain_castleSelectionCommand1.ImageOver = GFXLibrary.captains_commands_icons[8];
			this.captain_castleSelectionCommand1.Position = new Point(21, 100);
			this.captain_castleSelectionCommand1.Data = 100;
			this.captain_castleSelectionCommand1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.captainCommandClick), "CastleMapAttackerSetupPanel_captain_command_1");
			this.captain_castleSelectionPanelImage.addControl(this.captain_castleSelectionCommand1);
			this.captain_castleSelectionCommand2.ImageNorm = GFXLibrary.captains_commands_icons[17];
			this.captain_castleSelectionCommand2.ImageOver = GFXLibrary.captains_commands_icons[9];
			this.captain_castleSelectionCommand2.Position = new Point(101, 100);
			this.captain_castleSelectionCommand2.Data = 101;
			this.captain_castleSelectionCommand2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.captainCommandClick), "CastleMapAttackerSetupPanel_captain_command_2");
			this.captain_castleSelectionPanelImage.addControl(this.captain_castleSelectionCommand2);
			this.captain_castleSelectionCommand3.ImageNorm = GFXLibrary.captains_commands_icons[18];
			this.captain_castleSelectionCommand3.ImageOver = GFXLibrary.captains_commands_icons[10];
			this.captain_castleSelectionCommand3.Position = new Point(21, 180);
			this.captain_castleSelectionCommand3.Data = 102;
			this.captain_castleSelectionCommand3.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.captainCommandClick), "CastleMapAttackerSetupPanel_captain_command_3");
			this.captain_castleSelectionPanelImage.addControl(this.captain_castleSelectionCommand3);
			this.captain_castleSelectionCommand4.ImageNorm = GFXLibrary.captains_commands_icons[19];
			this.captain_castleSelectionCommand4.ImageOver = GFXLibrary.captains_commands_icons[11];
			this.captain_castleSelectionCommand4.Position = new Point(21, 260);
			this.captain_castleSelectionCommand4.Data = 103;
			this.captain_castleSelectionCommand4.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.captainCommandClick), "CastleMapAttackerSetupPanel_captain_command_4");
			this.captain_castleSelectionPanelImage.addControl(this.captain_castleSelectionCommand4);
			this.captain_castleSelectionCommand5.ImageNorm = GFXLibrary.captains_commands_icons[20];
			this.captain_castleSelectionCommand5.ImageOver = GFXLibrary.captains_commands_icons[12];
			this.captain_castleSelectionCommand5.Position = new Point(101, 180);
			this.captain_castleSelectionCommand5.Data = 104;
			this.captain_castleSelectionCommand5.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.captainCommandClick), "CastleMapAttackerSetupPanel_captain_command_5");
			this.captain_castleSelectionPanelImage.addControl(this.captain_castleSelectionCommand5);
			this.captain_castleSelectionCommand6.ImageNorm = GFXLibrary.captains_commands_icons[21];
			this.captain_castleSelectionCommand6.ImageOver = GFXLibrary.captains_commands_icons[13];
			this.captain_castleSelectionCommand6.Position = new Point(101, 260);
			this.captain_castleSelectionCommand6.Data = 105;
			this.captain_castleSelectionCommand6.Visible = false;
			this.captain_castleSelectionCommand6.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.captainCommandClick), "CastleMapAttackerSetupPanel_captain_command_6");
			this.captain_castleSelectionPanelImage.addControl(this.captain_castleSelectionCommand6);
			this.captain_castleSelectionCommand7.ImageNorm = GFXLibrary.captains_commands_icons[22];
			this.captain_castleSelectionCommand7.ImageOver = GFXLibrary.captains_commands_icons[14];
			this.captain_castleSelectionCommand7.Position = new Point(21, 340);
			this.captain_castleSelectionCommand7.Data = 106;
			this.captain_castleSelectionCommand7.Visible = false;
			this.captain_castleSelectionCommand7.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.captainCommandClick), "CastleMapAttackerSetupPanel_captain_command_7");
			this.captain_castleSelectionPanelImage.addControl(this.captain_castleSelectionCommand7);
			this.captain_castleSelectionCommand8.ImageNorm = GFXLibrary.captains_commands_icons[23];
			this.captain_castleSelectionCommand8.ImageOver = GFXLibrary.captains_commands_icons[15];
			this.captain_castleSelectionCommand8.Position = new Point(101, 340);
			this.captain_castleSelectionCommand8.Data = 107;
			this.captain_castleSelectionCommand8.Visible = false;
			this.captain_castleSelectionCommand8.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.captainCommandClick), "CastleMapAttackerSetupPanel_captain_command_8");
			this.captain_castleSelectionPanelImage.addControl(this.captain_castleSelectionCommand8);
			this.captain_castleSelectionCaptainCommandLabel.Text = SK.Text("CastleMapAttackerSetup_Command", "Command");
			this.captain_castleSelectionCaptainCommandLabel.Color = global::ARGBColors.Black;
			this.captain_castleSelectionCaptainCommandLabel.Position = new Point(0, 421);
			this.captain_castleSelectionCaptainCommandLabel.Size = new Size(this.captain_castleSelectionPanelImage.Size.Width, 30);
			this.captain_castleSelectionCaptainCommandLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.captain_castleSelectionCaptainCommandLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.captain_castleSelectionPanelImage.addControl(this.captain_castleSelectionCaptainCommandLabel);
			this.captain_commandValueTrack.Position = new Point(32, 444);
			this.captain_commandValueTrack.Margin = new Rectangle(3, -1, 1, 0);
			this.captain_commandValueTrack.Value = 0;
			this.captain_commandValueTrack.Max = 39;
			this.captain_commandValueTrack.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.tracksMoved));
			this.captain_castleSelectionPanelImage.addControl(this.captain_commandValueTrack);
			this.captain_commandValueTrack.Create(GFXLibrary.int_slidebar_ruler, GFXLibrary.int_slidebar_thumb_middle_normal, GFXLibrary.int_slidebar_thumb_left_normal, GFXLibrary.int_slidebar_thumb_right_normal, GFXLibrary.int_slidebar_thumb_middle_in, GFXLibrary.int_slidebar_thumb_middle_over);
			this.captain_castleSelectionCaptainSecondsCountLabel.Text = "0";
			this.captain_castleSelectionCaptainSecondsCountLabel.Color = global::ARGBColors.Black;
			this.captain_castleSelectionCaptainSecondsCountLabel.Position = new Point(0, 479);
			this.captain_castleSelectionCaptainSecondsCountLabel.Size = new Size(100, 30);
			this.captain_castleSelectionCaptainSecondsCountLabel.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
			this.captain_castleSelectionCaptainSecondsCountLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.captain_castleSelectionPanelImage.addControl(this.captain_castleSelectionCaptainSecondsCountLabel);
			this.captain_castleSelectionCaptainSecondsLabel.Text = SK.Text("CastleMapAttackerSetup_Seconds", "Seconds");
			this.captain_castleSelectionCaptainSecondsLabel.Color = global::ARGBColors.Black;
			this.captain_castleSelectionCaptainSecondsLabel.Position = new Point(100, 484);
			this.captain_castleSelectionCaptainSecondsLabel.Size = new Size(this.captain_castleSelectionPanelImage.Size.Width - 100, 30);
			this.captain_castleSelectionCaptainSecondsLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.captain_castleSelectionCaptainSecondsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.captain_castleSelectionPanelImage.addControl(this.captain_castleSelectionCaptainSecondsLabel);
		}

		// Token: 0x06000A62 RID: 2658 RVA: 0x000D0160 File Offset: 0x000CE360
		public void tracksMoved()
		{
			int value = (this.captain_commandValueTrack.Value + 1) * 5;
			this.captain_castleSelectionCaptainSecondsCountLabel.Text = value.ToString();
			GameEngine.Instance.CastleAttackerSetup.updateCaptainsDetails(value);
		}

		// Token: 0x06000A63 RID: 2659 RVA: 0x000D01A0 File Offset: 0x000CE3A0
		public void updateCaptainCommands(int activeCommand)
		{
			this.captain_castleSelectionCommand1.ImageNorm = GFXLibrary.captains_commands_icons[16];
			this.captain_castleSelectionCommand1.ImageOver = GFXLibrary.captains_commands_icons[0];
			this.captain_castleSelectionCommand2.ImageNorm = GFXLibrary.captains_commands_icons[17];
			this.captain_castleSelectionCommand2.ImageOver = GFXLibrary.captains_commands_icons[1];
			this.captain_castleSelectionCommand3.ImageNorm = GFXLibrary.captains_commands_icons[18];
			this.captain_castleSelectionCommand3.ImageOver = GFXLibrary.captains_commands_icons[2];
			this.captain_castleSelectionCommand4.ImageNorm = GFXLibrary.captains_commands_icons[19];
			this.captain_castleSelectionCommand4.ImageOver = GFXLibrary.captains_commands_icons[3];
			this.captain_castleSelectionCommand5.ImageNorm = GFXLibrary.captains_commands_icons[20];
			this.captain_castleSelectionCommand5.ImageOver = GFXLibrary.captains_commands_icons[4];
			this.captain_castleSelectionCommand6.ImageNorm = GFXLibrary.captains_commands_icons[21];
			this.captain_castleSelectionCommand6.ImageOver = GFXLibrary.captains_commands_icons[5];
			this.captain_castleSelectionCommand7.ImageNorm = GFXLibrary.captains_commands_icons[22];
			this.captain_castleSelectionCommand7.ImageOver = GFXLibrary.captains_commands_icons[6];
			this.captain_castleSelectionCommand8.ImageNorm = GFXLibrary.captains_commands_icons[23];
			this.captain_castleSelectionCommand8.ImageOver = GFXLibrary.captains_commands_icons[7];
			switch (activeCommand)
			{
			case 100:
				this.captain_castleSelectionCommand1.ImageNorm = GFXLibrary.captains_commands_icons[8];
				this.captain_castleSelectionCaptainCommandLabel.Text = SK.Text("CAPTAINS_COMMANDS_", "Delay");
				break;
			case 101:
				this.captain_castleSelectionCommand2.ImageNorm = GFXLibrary.captains_commands_icons[9];
				this.captain_castleSelectionCaptainCommandLabel.Text = SK.Text("CAPTAINS_COMMANDS_Rallying_Cry", "Rallying Cry");
				break;
			case 102:
				this.captain_castleSelectionCommand3.ImageNorm = GFXLibrary.captains_commands_icons[10];
				this.captain_castleSelectionCaptainCommandLabel.Text = SK.Text("CAPTAINS_COMMANDS_Arrow_Volley", "Arrow Volley");
				break;
			case 103:
				this.captain_castleSelectionCommand4.ImageNorm = GFXLibrary.captains_commands_icons[11];
				this.captain_castleSelectionCaptainCommandLabel.Text = SK.Text("CAPTAINS_COMMANDS_Catapult_Volley", "Catapult Volley");
				break;
			case 104:
				this.captain_castleSelectionCommand5.ImageNorm = GFXLibrary.captains_commands_icons[12];
				this.captain_castleSelectionCaptainCommandLabel.Text = SK.Text("CAPTAINS_COMMANDS_Battle_Cry", "Battle Cry");
				break;
			case 105:
				this.captain_castleSelectionCommand6.ImageNorm = GFXLibrary.captains_commands_icons[13];
				this.captain_castleSelectionCaptainCommandLabel.Text = "Command 6";
				break;
			case 106:
				this.captain_castleSelectionCommand7.ImageNorm = GFXLibrary.captains_commands_icons[14];
				this.captain_castleSelectionCaptainCommandLabel.Text = "Command 7";
				break;
			case 107:
				this.captain_castleSelectionCommand8.ImageNorm = GFXLibrary.captains_commands_icons[15];
				this.captain_castleSelectionCaptainCommandLabel.Text = "Command 8";
				break;
			}
			int research_Tactics = (int)GameEngine.Instance.World.UserResearchData.Research_Tactics;
			if (research_Tactics < 1)
			{
				this.captain_castleSelectionCommand2.Alpha = 0.5f;
				this.captain_castleSelectionCommand2.Enabled = false;
			}
			else
			{
				this.captain_castleSelectionCommand2.Alpha = 1f;
				this.captain_castleSelectionCommand2.Enabled = true;
			}
			if (research_Tactics < 2)
			{
				this.captain_castleSelectionCommand3.Alpha = 0.5f;
				this.captain_castleSelectionCommand3.Enabled = false;
			}
			else
			{
				this.captain_castleSelectionCommand3.Alpha = 1f;
				this.captain_castleSelectionCommand3.Enabled = true;
			}
			if (research_Tactics < 4)
			{
				this.captain_castleSelectionCommand4.Alpha = 0.5f;
				this.captain_castleSelectionCommand4.Enabled = false;
			}
			else
			{
				this.captain_castleSelectionCommand4.Alpha = 1f;
				this.captain_castleSelectionCommand4.Enabled = true;
			}
			if (research_Tactics < 3)
			{
				this.captain_castleSelectionCommand5.Alpha = 0.5f;
				this.captain_castleSelectionCommand5.Enabled = false;
			}
			else
			{
				this.captain_castleSelectionCommand5.Alpha = 1f;
				this.captain_castleSelectionCommand5.Enabled = true;
			}
			if (research_Tactics < 6)
			{
				this.captain_castleSelectionCommand6.Alpha = 0.5f;
				this.captain_castleSelectionCommand6.Enabled = false;
			}
			else
			{
				this.captain_castleSelectionCommand6.Alpha = 1f;
				this.captain_castleSelectionCommand6.Enabled = true;
			}
			if (research_Tactics < 7)
			{
				this.captain_castleSelectionCommand7.Alpha = 0.5f;
				this.captain_castleSelectionCommand7.Enabled = false;
			}
			else
			{
				this.captain_castleSelectionCommand7.Alpha = 1f;
				this.captain_castleSelectionCommand7.Enabled = true;
			}
			if (research_Tactics < 8)
			{
				this.captain_castleSelectionCommand8.Alpha = 0.5f;
				this.captain_castleSelectionCommand8.Enabled = false;
				return;
			}
			this.captain_castleSelectionCommand8.Alpha = 1f;
			this.captain_castleSelectionCommand8.Enabled = true;
		}

		// Token: 0x06000A64 RID: 2660 RVA: 0x000D06A4 File Offset: 0x000CE8A4
		private void captainCommandClick()
		{
			if (this.OverControl != null)
			{
				CustomSelfDrawPanel.CSDControl overControl = this.OverControl;
				int data = overControl.Data;
				this.updateCaptainCommands(data);
				GameEngine.Instance.CastleAttackerSetup.updateAttackingCaptainCommand(data);
			}
		}

		// Token: 0x06000A65 RID: 2661 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void setTimes(DateTime castleViewTime, bool castleAvailable, DateTime troopViewTime, bool troopAvailable)
		{
		}

		// Token: 0x06000A66 RID: 2662 RVA: 0x000D06E0 File Offset: 0x000CE8E0
		public void showRealAttack(bool state)
		{
			this.armyLaunched = false;
			if (state)
			{
				this.loadButton.Visible = false;
				this.saveButton.Visible = false;
				this.aiExportButton.Visible = false;
				this.launchHeaderButton.Enabled = false;
				return;
			}
			this.loadButton.Visible = true;
			this.saveButton.Visible = true;
			this.aiExportButton.Visible = true;
			this.launchHeaderButton.Enabled = true;
		}

		// Token: 0x06000A67 RID: 2663 RVA: 0x0000DD88 File Offset: 0x0000BF88
		public void showAttackReady(bool state)
		{
			if (!this.armyLaunched)
			{
				this.launchHeaderButton.Enabled = state;
			}
		}

		// Token: 0x06000A68 RID: 2664 RVA: 0x000D0758 File Offset: 0x000CE958
		public void setStats(int numArchers, int numPikemen, int numSwordsmen, int numPeasants, int numCatapults, int maxPeasants, int maxArchers, int maxPikemen, int maxSwordsmen, int maxCatapults, int numCaptains, int maxCaptains, int captainsCommand, int numPeasantsInCastle, int numArchersInCastle, int numPikemenInCastle, int numSwordsmenInCastle)
		{
			int num = maxPeasants - numPeasants;
			int num2 = maxArchers - numArchers;
			int num3 = maxPikemen - numPikemen;
			int num4 = maxSwordsmen - numSwordsmen;
			int num5 = maxCatapults - numCatapults;
			int num6 = maxCaptains - numCaptains;
			bool visible = false;
			if (num <= 0)
			{
				num += numPeasantsInCastle;
				if (num > 0)
				{
					visible = true;
				}
			}
			bool visible2 = false;
			if (num2 <= 0)
			{
				num2 += numArchersInCastle;
				if (num2 > 0)
				{
					visible2 = true;
				}
			}
			bool visible3 = false;
			if (num3 <= 0)
			{
				num3 += numPikemenInCastle;
				if (num3 > 0)
				{
					visible3 = true;
				}
			}
			bool visible4 = false;
			if (num4 <= 0)
			{
				num4 += numSwordsmenInCastle;
				if (num4 > 0)
				{
					visible4 = true;
				}
			}
			if (num <= 0)
			{
				num = 0;
				this.castlePlacePeasantButton.Enabled = false;
			}
			else
			{
				this.castlePlacePeasantButton.Enabled = true;
			}
			if (num2 <= 0)
			{
				num2 = 0;
				this.castlePlaceArcherButton.Enabled = false;
			}
			else
			{
				this.castlePlaceArcherButton.Enabled = true;
			}
			if (num3 <= 0)
			{
				num3 = 0;
				this.castlePlacePikemanButton.Enabled = false;
			}
			else
			{
				this.castlePlacePikemanButton.Enabled = true;
			}
			if (num4 <= 0)
			{
				num4 = 0;
				this.castlePlaceSwordsmanButton.Enabled = false;
			}
			else
			{
				this.castlePlaceSwordsmanButton.Enabled = true;
			}
			if (num5 <= 0)
			{
				num5 = 0;
				this.castlePlaceCatapultButton.Enabled = false;
			}
			else
			{
				this.castlePlaceCatapultButton.Enabled = true;
			}
			if (num6 <= 0)
			{
				num6 = 0;
				this.castlePlaceCaptainButton.Enabled = false;
			}
			else
			{
				this.castlePlaceCaptainButton.Enabled = true;
			}
			this.castlePlacePeasantLabel.Text = num.ToString();
			this.castlePlaceArcherLabel.Text = num2.ToString();
			this.castlePlacePikemanLabel.Text = num3.ToString();
			this.castlePlaceSwordsmanLabel.Text = num4.ToString();
			this.castlePlaceCatapultLabel.Text = num5.ToString();
			this.castlePlaceCaptainLabel.Text = num6.ToString();
			this.castlePlacePeasantCastle.Visible = visible;
			this.castlePlaceArcherCastle.Visible = visible2;
			this.castlePlacePikemanCastle.Visible = visible3;
			this.castlePlaceSwordsmanCastle.Visible = visible4;
		}

		// Token: 0x06000A69 RID: 2665 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void DEBUG_load()
		{
		}

		// Token: 0x06000A6A RID: 2666 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void DEBUG_save()
		{
		}

		// Token: 0x06000A6B RID: 2667 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void DEBUG_export()
		{
		}

		// Token: 0x06000A6C RID: 2668 RVA: 0x0000DD9E File Offset: 0x0000BF9E
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06000A6D RID: 2669 RVA: 0x0000DDAE File Offset: 0x0000BFAE
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06000A6E RID: 2670 RVA: 0x0000DDBE File Offset: 0x0000BFBE
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06000A6F RID: 2671 RVA: 0x0000DDD0 File Offset: 0x0000BFD0
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06000A70 RID: 2672 RVA: 0x0000DDDD File Offset: 0x0000BFDD
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x06000A71 RID: 2673 RVA: 0x0000DDEB File Offset: 0x0000BFEB
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06000A72 RID: 2674 RVA: 0x0000DDF8 File Offset: 0x0000BFF8
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06000A73 RID: 2675 RVA: 0x0000DE05 File Offset: 0x0000C005
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000A74 RID: 2676 RVA: 0x000D0938 File Offset: 0x000CEB38
		private void InitializeComponent()
		{
			this.LoadSetupFileDialog = new OpenFileDialog();
			this.SaveSetupFileDialog = new SaveFileDialog();
			base.SuspendLayout();
			this.LoadSetupFileDialog.DefaultExt = "cmap";
			this.LoadSetupFileDialog.Filter = "Castle Maps (*.cmap)|*.cmap|AI Export Files (*.txt)|*.txt";
			this.LoadSetupFileDialog.Title = "Load Debug Castle Map";
			this.SaveSetupFileDialog.DefaultExt = "cmap";
			this.SaveSetupFileDialog.Filter = "Castle Maps (*.cmap)|*.cmap";
			this.SaveSetupFileDialog.Title = "Save Debug Castle Map";
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Name = "CastleMapAttackerSetupPanel2";
			base.Size = new Size(196, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x04000DB4 RID: 3508
		private CustomSelfDrawPanel.CSDArea castlePlaceBackgroundArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000DB5 RID: 3509
		private CustomSelfDrawPanel.CSDImage castlePlacePanelImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DB6 RID: 3510
		private CustomSelfDrawPanel.CSDImage castlePlacePanelFaderImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DB7 RID: 3511
		private CustomSelfDrawPanel.CSDButton castlePlacePeasantButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000DB8 RID: 3512
		private CustomSelfDrawPanel.CSDButton castlePlaceArcherButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000DB9 RID: 3513
		private CustomSelfDrawPanel.CSDButton castlePlacePikemanButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000DBA RID: 3514
		private CustomSelfDrawPanel.CSDButton castlePlaceSwordsmanButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000DBB RID: 3515
		private CustomSelfDrawPanel.CSDButton castlePlaceCatapultButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000DBC RID: 3516
		private CustomSelfDrawPanel.CSDButton castlePlaceCaptainButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000DBD RID: 3517
		private CustomSelfDrawPanel.CSDImage castlePlacePeasantInset = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DBE RID: 3518
		private CustomSelfDrawPanel.CSDImage castlePlaceArcherInset = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DBF RID: 3519
		private CustomSelfDrawPanel.CSDImage castlePlacePikemanInset = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DC0 RID: 3520
		private CustomSelfDrawPanel.CSDImage castlePlaceSwordsmanInset = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DC1 RID: 3521
		private CustomSelfDrawPanel.CSDImage castlePlaceCaptainInset = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DC2 RID: 3522
		private CustomSelfDrawPanel.CSDImage castlePlaceCatapultInset = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DC3 RID: 3523
		private CustomSelfDrawPanel.CSDLabel castlePlacePeasantLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000DC4 RID: 3524
		private CustomSelfDrawPanel.CSDLabel castlePlaceArcherLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000DC5 RID: 3525
		private CustomSelfDrawPanel.CSDLabel castlePlacePikemanLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000DC6 RID: 3526
		private CustomSelfDrawPanel.CSDLabel castlePlaceSwordsmanLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000DC7 RID: 3527
		private CustomSelfDrawPanel.CSDLabel castlePlaceCatapultLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000DC8 RID: 3528
		private CustomSelfDrawPanel.CSDLabel castlePlaceCaptainLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000DC9 RID: 3529
		private CustomSelfDrawPanel.CSDImage castlePlacePeasantCastle = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DCA RID: 3530
		private CustomSelfDrawPanel.CSDImage castlePlaceArcherCastle = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DCB RID: 3531
		private CustomSelfDrawPanel.CSDImage castlePlacePikemanCastle = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DCC RID: 3532
		private CustomSelfDrawPanel.CSDImage castlePlaceSwordsmanCastle = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DCD RID: 3533
		private CustomSelfDrawPanel.CSDButton castlePlaceSize1Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000DCE RID: 3534
		private CustomSelfDrawPanel.CSDButton castlePlaceSize3Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000DCF RID: 3535
		private CustomSelfDrawPanel.CSDButton castlePlaceSize5Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000DD0 RID: 3536
		private CustomSelfDrawPanel.CSDButton castlePlaceSize15Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000DD1 RID: 3537
		private int placementSize = 1;

		// Token: 0x04000DD2 RID: 3538
		private CustomSelfDrawPanel.CSDButton launchHeaderButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000DD3 RID: 3539
		private CustomSelfDrawPanel.CSDButton cancelButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000DD4 RID: 3540
		private CustomSelfDrawPanel.CSDButton advancedButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000DD5 RID: 3541
		private CustomSelfDrawPanel.CSDButton cloudButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000DD6 RID: 3542
		private CustomSelfDrawPanel.CSDButton loadButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000DD7 RID: 3543
		private CustomSelfDrawPanel.CSDButton saveButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000DD8 RID: 3544
		private CustomSelfDrawPanel.CSDButton aiExportButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000DD9 RID: 3545
		private bool armyLaunched;

		// Token: 0x04000DDA RID: 3546
		private CustomSelfDrawPanel.CSDArea castleSelectionBackgroundArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000DDB RID: 3547
		private CustomSelfDrawPanel.CSDImage castleSelectionPanelImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DDC RID: 3548
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000DDD RID: 3549
		private CustomSelfDrawPanel.CSDImage castleSelectionInset1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DDE RID: 3550
		private CustomSelfDrawPanel.CSDImage castleSelectionInset2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DDF RID: 3551
		private CustomSelfDrawPanel.CSDImage castleSelectionInset3Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DE0 RID: 3552
		private CustomSelfDrawPanel.CSDImage castleSelectionInset4Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DE1 RID: 3553
		private CustomSelfDrawPanel.CSDImage castleSelectionInset5Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DE2 RID: 3554
		private CustomSelfDrawPanel.CSDImage castleSelectionInset6Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DE3 RID: 3555
		private CustomSelfDrawPanel.CSDImage castleSelectionPeasantImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DE4 RID: 3556
		private CustomSelfDrawPanel.CSDImage castleSelectionArcherImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DE5 RID: 3557
		private CustomSelfDrawPanel.CSDImage castleSelectionPikemanImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DE6 RID: 3558
		private CustomSelfDrawPanel.CSDImage castleSelectionSwordsmanImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DE7 RID: 3559
		private CustomSelfDrawPanel.CSDImage castleSelectionCatapultImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DE8 RID: 3560
		private CustomSelfDrawPanel.CSDImage castleSelectionCaptainImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DE9 RID: 3561
		private CustomSelfDrawPanel.CSDImage castleSelectionPeasantInset = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DEA RID: 3562
		private CustomSelfDrawPanel.CSDImage castleSelectionArcherInset = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DEB RID: 3563
		private CustomSelfDrawPanel.CSDImage castleSelectionPikemanInset = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DEC RID: 3564
		private CustomSelfDrawPanel.CSDImage castleSelectionSwordsmanInset = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DED RID: 3565
		private CustomSelfDrawPanel.CSDImage castleSelectionCatapultInset = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DEE RID: 3566
		private CustomSelfDrawPanel.CSDImage castleSelectionCaptainInset = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DEF RID: 3567
		private CustomSelfDrawPanel.CSDLabel castleSelectionPeasantLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000DF0 RID: 3568
		private CustomSelfDrawPanel.CSDLabel castleSelectionArcherLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000DF1 RID: 3569
		private CustomSelfDrawPanel.CSDLabel castleSelectionPikemanLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000DF2 RID: 3570
		private CustomSelfDrawPanel.CSDLabel castleSelectionSwordsmanLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000DF3 RID: 3571
		private CustomSelfDrawPanel.CSDLabel castleSelectionCatapultLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000DF4 RID: 3572
		private CustomSelfDrawPanel.CSDLabel castleSelectionCaptainLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000DF5 RID: 3573
		private CustomSelfDrawPanel.CSDButton castleSelectionPeasantDeleteButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000DF6 RID: 3574
		private CustomSelfDrawPanel.CSDButton castleSelectionArcherDeleteButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000DF7 RID: 3575
		private CustomSelfDrawPanel.CSDButton castleSelectionPikemanDeleteButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000DF8 RID: 3576
		private CustomSelfDrawPanel.CSDButton castleSelectionSwordsmanDeleteButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000DF9 RID: 3577
		private CustomSelfDrawPanel.CSDButton castleSelectionCatapultDeleteButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000DFA RID: 3578
		private CustomSelfDrawPanel.CSDButton castleSelectionCaptainDeleteButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000DFB RID: 3579
		private CustomSelfDrawPanel.CSDArea captain_castleSelectionBackgroundArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000DFC RID: 3580
		private CustomSelfDrawPanel.CSDImage captain_castleSelectionPanelImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DFD RID: 3581
		private CustomSelfDrawPanel.CSDButton captain_closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000DFE RID: 3582
		private CustomSelfDrawPanel.CSDImage captain_castleSelectionInset6Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000DFF RID: 3583
		private CustomSelfDrawPanel.CSDImage captain_castleSelectionCaptainImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000E00 RID: 3584
		private CustomSelfDrawPanel.CSDImage captain_castleSelectionCaptainInset = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000E01 RID: 3585
		private CustomSelfDrawPanel.CSDLabel captain_castleSelectionCaptainLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E02 RID: 3586
		private CustomSelfDrawPanel.CSDButton captain_castleSelectionCaptainDeleteButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E03 RID: 3587
		private CustomSelfDrawPanel.CSDButton captain_castleSelectionCommand1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E04 RID: 3588
		private CustomSelfDrawPanel.CSDButton captain_castleSelectionCommand2 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E05 RID: 3589
		private CustomSelfDrawPanel.CSDButton captain_castleSelectionCommand3 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E06 RID: 3590
		private CustomSelfDrawPanel.CSDButton captain_castleSelectionCommand4 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E07 RID: 3591
		private CustomSelfDrawPanel.CSDButton captain_castleSelectionCommand5 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E08 RID: 3592
		private CustomSelfDrawPanel.CSDButton captain_castleSelectionCommand6 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E09 RID: 3593
		private CustomSelfDrawPanel.CSDButton captain_castleSelectionCommand7 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E0A RID: 3594
		private CustomSelfDrawPanel.CSDButton captain_castleSelectionCommand8 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E0B RID: 3595
		private CustomSelfDrawPanel.CSDLabel captain_castleSelectionCaptainCommandLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E0C RID: 3596
		private CustomSelfDrawPanel.CSDLabel captain_castleSelectionCaptainSecondsCountLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E0D RID: 3597
		private CustomSelfDrawPanel.CSDLabel captain_castleSelectionCaptainSecondsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E0E RID: 3598
		private CustomSelfDrawPanel.CSDTrackBar captain_commandValueTrack = new CustomSelfDrawPanel.CSDTrackBar();

		// Token: 0x04000E0F RID: 3599
		private DockableControl dockableControl;

		// Token: 0x04000E10 RID: 3600
		private IContainer components;

		// Token: 0x04000E11 RID: 3601
		private OpenFileDialog LoadSetupFileDialog;

		// Token: 0x04000E12 RID: 3602
		private SaveFileDialog SaveSetupFileDialog;
	}
}
