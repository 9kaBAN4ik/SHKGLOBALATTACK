using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x02000124 RID: 292
	public class CastleMapPanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06000A90 RID: 2704 RVA: 0x0000DF9B File Offset: 0x0000C19B
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06000A91 RID: 2705 RVA: 0x0000DFAB File Offset: 0x0000C1AB
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06000A92 RID: 2706 RVA: 0x0000DFBB File Offset: 0x0000C1BB
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06000A93 RID: 2707 RVA: 0x0000DFCD File Offset: 0x0000C1CD
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06000A94 RID: 2708 RVA: 0x0000DFDA File Offset: 0x0000C1DA
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x06000A95 RID: 2709 RVA: 0x0000DFE8 File Offset: 0x0000C1E8
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06000A96 RID: 2710 RVA: 0x0000DFF5 File Offset: 0x0000C1F5
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06000A97 RID: 2711 RVA: 0x0000E002 File Offset: 0x0000C202
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000A98 RID: 2712 RVA: 0x000D1E1C File Offset: 0x000D001C
		private void InitializeComponent()
		{
			this.LoadCampDialog = new OpenFileDialog();
			this.SaveCampDialog = new SaveFileDialog();
			base.SuspendLayout();
			this.LoadCampDialog.DefaultExt = "camp";
			this.LoadCampDialog.Filter = "Bandit Camps (*.camp)|*.camp";
			this.LoadCampDialog.Title = "Load Bandit Camps";
			this.SaveCampDialog.DefaultExt = "camp";
			this.SaveCampDialog.Filter = "Bandit Camps (*.camp)|*.camp";
			this.SaveCampDialog.Title = "Save bandit Camps";
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Name = "CastleMapPanel";
			base.Size = new Size(196, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x06000A99 RID: 2713 RVA: 0x000D1EE0 File Offset: 0x000D00E0
		public CastleMapPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SelfDrawBackground = true;
		}

		// Token: 0x06000A9A RID: 2714 RVA: 0x000D25B8 File Offset: 0x000D07B8
		public void create()
		{
			this.initCastlePlacePanel();
			this.initCommitBuildPanel();
			this.initUtilBar();
			this.initSelectionPanel();
			this.initSelectionPanel_Captains();
			this.controlBlockOverlay.Position = new Point(0, 0);
			this.controlBlockOverlay.Size = base.Size;
			this.controlBlockOverlay.FillColor = Color.FromArgb(0, global::ARGBColors.Black);
			this.controlBlockOverlay.Visible = false;
			this.controlBlockOverlay.setClickDelegate(delegate()
			{
			});
			this.controlBlockOverlay.setMouseOverDelegate(delegate
			{
			}, delegate
			{
			});
			base.addControl(this.controlBlockOverlay);
		}

		// Token: 0x06000A9B RID: 2715 RVA: 0x000D26A8 File Offset: 0x000D08A8
		public void initCastlePlacePanel()
		{
			int num = 0;
			this.castlePlaceBackgroundArea.Position = new Point(0, 0);
			this.castlePlaceBackgroundArea.Size = base.Size;
			base.addControl(this.castlePlaceBackgroundArea);
			this.castlePlacePanelImage.Image = GFXLibrary.r_building_panel_back;
			this.castlePlacePanelImage.Position = new Point(0, num + 25);
			this.castlePlaceBackgroundArea.addControl(this.castlePlacePanelImage);
			this.castlePlaceHeaderArea.Position = new Point(0, num);
			this.castlePlaceHeaderArea.Size = new Size(196, 62);
			this.castlePlaceBackgroundArea.addControl(this.castlePlaceHeaderArea);
			this.castlePlace1Button.Position = new Point(6, 14);
			this.castlePlace1Button.Visible = false;
			this.castlePlace1Button.ClickArea = new Rectangle(10, 10, 85, 85);
			this.castlePlace1Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceClick), "CastleMapPanel_generic_place");
			this.castlePlace1Button.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.castlePlaceMouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.castlePlaceMouseLeave));
			this.castlePlacePanelImage.addControl(this.castlePlace1Button);
			this.building1Image.Image = GFXLibrary.building_icon_circle;
			this.building1Image.Alpha = 0.65f;
			this.building1Image.Position = new Point(64, 59);
			this.castlePlace1Button.addControl(this.building1Image);
			this.building1Label.Text = "0";
			this.building1Label.Color = global::ARGBColors.Black;
			this.building1Label.Position = new Point(-1, -1);
			this.building1Label.Size = this.building1Image.Size;
			this.building1Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.building1Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.building1Image.addControl(this.building1Label);
			this.castlePlace2Button.Position = new Point(88, 14);
			this.castlePlace2Button.Visible = false;
			this.castlePlace2Button.ClickArea = new Rectangle(10, 10, 85, 85);
			this.castlePlace2Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceClick), "CastleMapPanel_generic_place");
			this.castlePlace2Button.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.castlePlaceMouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.castlePlaceMouseLeave));
			this.castlePlacePanelImage.addControl(this.castlePlace2Button);
			this.building2Image.Image = GFXLibrary.building_icon_circle;
			this.building2Image.Alpha = 0.65f;
			this.building2Image.Position = new Point(64, 59);
			this.castlePlace2Button.addControl(this.building2Image);
			this.building2Label.Text = "0";
			this.building2Label.Color = global::ARGBColors.Black;
			this.building2Label.Position = new Point(-1, -1);
			this.building2Label.Size = this.building1Image.Size;
			this.building2Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.building2Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.building2Image.addControl(this.building2Label);
			this.castlePlace3Button.Position = new Point(6, 89);
			this.castlePlace3Button.Visible = false;
			this.castlePlace3Button.ClickArea = new Rectangle(10, 10, 85, 85);
			this.castlePlace3Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceClick), "CastleMapPanel_generic_place");
			this.castlePlace3Button.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.castlePlaceMouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.castlePlaceMouseLeave));
			this.castlePlacePanelImage.addControl(this.castlePlace3Button);
			this.building3Image.Image = GFXLibrary.building_icon_circle;
			this.building3Image.Alpha = 0.65f;
			this.building3Image.Position = new Point(64, 59);
			this.castlePlace3Button.addControl(this.building3Image);
			this.building3Label.Text = "0";
			this.building3Label.Color = global::ARGBColors.Black;
			this.building3Label.Position = new Point(-1, -1);
			this.building3Label.Size = this.building1Image.Size;
			this.building3Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.building3Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.building3Image.addControl(this.building3Label);
			this.castlePlace4Button.Position = new Point(88, 89);
			this.castlePlace4Button.Visible = false;
			this.castlePlace4Button.ClickArea = new Rectangle(10, 10, 85, 85);
			this.castlePlace4Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceClick), "CastleMapPanel_generic_place");
			this.castlePlace4Button.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.castlePlaceMouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.castlePlaceMouseLeave));
			this.castlePlacePanelImage.addControl(this.castlePlace4Button);
			this.building4Image.Image = GFXLibrary.building_icon_circle;
			this.building4Image.Alpha = 0.65f;
			this.building4Image.Position = new Point(64, 59);
			this.castlePlace4Button.addControl(this.building4Image);
			this.building4Label.Text = "0";
			this.building4Label.Color = global::ARGBColors.Black;
			this.building4Label.Position = new Point(-1, -1);
			this.building4Label.Size = this.building1Image.Size;
			this.building4Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.building4Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.building4Image.addControl(this.building4Label);
			this.castlePlace5Button.Position = new Point(6, 164);
			this.castlePlace5Button.Visible = false;
			this.castlePlace5Button.ClickArea = new Rectangle(10, 10, 85, 85);
			this.castlePlace5Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceClick), "CastleMapPanel_generic_place");
			this.castlePlace5Button.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.castlePlaceMouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.castlePlaceMouseLeave));
			this.castlePlacePanelImage.addControl(this.castlePlace5Button);
			this.building5Image.Image = GFXLibrary.building_icon_circle;
			this.building5Image.Alpha = 0.65f;
			this.building5Image.Position = new Point(64, 59);
			this.castlePlace5Button.addControl(this.building5Image);
			this.building5Label.Text = "0";
			this.building5Label.Color = global::ARGBColors.Black;
			this.building5Label.Position = new Point(-1, -1);
			this.building5Label.Size = this.building1Image.Size;
			this.building5Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.building5Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.building5Image.addControl(this.building5Label);
			this.castlePlace6Button.Position = new Point(88, 164);
			this.castlePlace6Button.Visible = false;
			this.castlePlace6Button.ClickArea = new Rectangle(10, 10, 85, 85);
			this.castlePlace6Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceClick), "CastleMapPanel_generic_place");
			this.castlePlace6Button.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.castlePlaceMouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.castlePlaceMouseLeave));
			this.castlePlacePanelImage.addControl(this.castlePlace6Button);
			this.building6Image.Image = GFXLibrary.building_icon_circle;
			this.building6Image.Alpha = 0.65f;
			this.building6Image.Position = new Point(64, 59);
			this.castlePlace6Button.addControl(this.building6Image);
			this.building6Label.Text = "0";
			this.building6Label.Color = global::ARGBColors.Black;
			this.building6Label.Position = new Point(-1, -1);
			this.building6Label.Size = this.building1Image.Size;
			this.building6Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.building6Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.building6Image.addControl(this.building6Label);
			this.castlePlace7Button.Position = new Point(6, 239);
			this.castlePlace7Button.Visible = false;
			this.castlePlace7Button.ClickArea = new Rectangle(10, 10, 85, 85);
			this.castlePlace7Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceClick), "CastleMapPanel_generic_place");
			this.castlePlace7Button.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.castlePlaceMouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.castlePlaceMouseLeave));
			this.castlePlacePanelImage.addControl(this.castlePlace7Button);
			this.building7Image.Image = GFXLibrary.building_icon_circle;
			this.building7Image.Alpha = 0.65f;
			this.building7Image.Position = new Point(64, 59);
			this.castlePlace7Button.addControl(this.building7Image);
			this.building7Label.Text = "0";
			this.building7Label.Color = global::ARGBColors.Black;
			this.building7Label.Position = new Point(-1, -1);
			this.building7Label.Size = this.building1Image.Size;
			this.building7Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.building7Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.building7Image.addControl(this.building7Label);
			this.castlePlace8Button.Position = new Point(88, 239);
			this.castlePlace8Button.Visible = false;
			this.castlePlace8Button.ClickArea = new Rectangle(10, 10, 85, 85);
			this.castlePlace8Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceClick), "CastleMapPanel_generic_place");
			this.castlePlace8Button.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.castlePlaceMouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.castlePlaceMouseLeave));
			this.castlePlacePanelImage.addControl(this.castlePlace8Button);
			this.building8Image.Image = GFXLibrary.building_icon_circle;
			this.building8Image.Alpha = 0.65f;
			this.building8Image.Position = new Point(64, 59);
			this.castlePlace8Button.addControl(this.building8Image);
			this.building8Label.Text = "0";
			this.building8Label.Color = global::ARGBColors.Black;
			this.building8Label.Position = new Point(-1, -1);
			this.building8Label.Size = this.building1Image.Size;
			this.building8Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.building8Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.building8Image.addControl(this.building8Label);
			this.castlePlacePeasantButton.ImageNorm = GFXLibrary.r_building_miltary_peasent;
			this.castlePlacePeasantButton.ImageOver = GFXLibrary.r_building_miltary_peasent_over;
			this.castlePlacePeasantButton.Position = new Point(-9, 14);
			this.castlePlacePeasantButton.Visible = false;
			this.castlePlacePeasantButton.Data = 70;
			this.castlePlacePeasantButton.CustomTooltipID = 200;
			this.castlePlacePeasantButton.CustomTooltipData = 70;
			this.castlePlacePeasantButton.ClickArea = new Rectangle(10, 10, 85, 85);
			this.castlePlacePeasantButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceClick), "CastleMapPanel_place_peasant");
			this.castlePlacePeasantButton.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.castlePlaceMouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.castlePlaceMouseLeave));
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
			this.castlePlaceArcherButton.ImageNorm = GFXLibrary.r_building_miltary_archer;
			this.castlePlaceArcherButton.ImageOver = GFXLibrary.r_building_miltary_archer_over;
			this.castlePlaceArcherButton.Position = new Point(73, 14);
			this.castlePlaceArcherButton.Visible = false;
			this.castlePlaceArcherButton.ClickArea = new Rectangle(10, 10, 85, 85);
			this.castlePlaceArcherButton.Data = 72;
			this.castlePlaceArcherButton.CustomTooltipID = 200;
			this.castlePlaceArcherButton.CustomTooltipData = 72;
			this.castlePlaceArcherButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceClick), "CastleMapPanel_place_archer");
			this.castlePlaceArcherButton.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.castlePlaceMouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.castlePlaceMouseLeave));
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
			this.castlePlacePikemanButton.ImageNorm = GFXLibrary.r_building_miltary_pikemen;
			this.castlePlacePikemanButton.ImageOver = GFXLibrary.r_building_miltary_pikemen_over;
			this.castlePlacePikemanButton.Position = new Point(-9, 89);
			this.castlePlacePikemanButton.Visible = false;
			this.castlePlacePikemanButton.ClickArea = new Rectangle(10, 10, 85, 85);
			this.castlePlacePikemanButton.Data = 73;
			this.castlePlacePikemanButton.CustomTooltipID = 200;
			this.castlePlacePikemanButton.CustomTooltipData = 73;
			this.castlePlacePikemanButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceClick), "CastleMapPanel_place_pikemen");
			this.castlePlacePikemanButton.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.castlePlaceMouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.castlePlaceMouseLeave));
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
			this.castlePlaceSwordsmanButton.ImageNorm = GFXLibrary.r_building_miltary_swordsman;
			this.castlePlaceSwordsmanButton.ImageOver = GFXLibrary.r_building_miltary_swordsman_over;
			this.castlePlaceSwordsmanButton.Position = new Point(73, 89);
			this.castlePlaceSwordsmanButton.Visible = false;
			this.castlePlaceSwordsmanButton.ClickArea = new Rectangle(10, 10, 85, 85);
			this.castlePlaceSwordsmanButton.Data = 71;
			this.castlePlaceSwordsmanButton.CustomTooltipID = 200;
			this.castlePlaceSwordsmanButton.CustomTooltipData = 71;
			this.castlePlaceSwordsmanButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceClick), "CastleMapPanel_place_swordsmen");
			this.castlePlaceSwordsmanButton.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.castlePlaceMouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.castlePlaceMouseLeave));
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
			this.castlePlaceWolfButton.ImageNorm = GFXLibrary.r_building_miltary_pikemen;
			this.castlePlaceWolfButton.ImageOver = GFXLibrary.r_building_miltary_pikemen_over;
			this.castlePlaceWolfButton.Position = new Point(-9, 164);
			this.castlePlaceWolfButton.Visible = false;
			this.castlePlaceWolfButton.ClickArea = new Rectangle(10, 10, 85, 85);
			this.castlePlaceWolfButton.Data = 77;
			this.castlePlaceWolfButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceClick), "CastleMapPanel_place_captain");
			this.castlePlaceWolfButton.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.castlePlaceMouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.castlePlaceMouseLeave));
			this.castlePlacePanelImage.addControl(this.castlePlaceWolfButton);
			this.castlePlaceWolfInset.Image = GFXLibrary.castlescreen_unit_capsule;
			this.castlePlaceWolfInset.Position = new Point(55, 65);
			this.castlePlaceWolfButton.addControl(this.castlePlaceWolfInset);
			this.castlePlaceWolfLabel.Text = "1000";
			this.castlePlaceWolfLabel.Color = Color.FromArgb(254, 248, 229);
			this.castlePlaceWolfLabel.Position = new Point(0, -1);
			this.castlePlaceWolfLabel.Size = this.castlePlacePikemanInset.Size;
			this.castlePlaceWolfLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.castlePlaceWolfInset.addControl(this.castlePlaceWolfLabel);
			if (!CastleMap.CreateMode)
			{
				this.castlePlaceWolfButton.ImageNorm = GFXLibrary.r_building_miltary_captain_normal;
				this.castlePlaceWolfButton.ImageOver = GFXLibrary.r_building_miltary_captain_over;
				this.castlePlaceWolfButton.Data = 85;
				this.castlePlaceWolfButton.CustomTooltipID = 200;
				this.castlePlaceWolfButton.CustomTooltipData = 85;
			}
			this.castlePlaceToggleReinforcementsButton.ImageNorm = GFXLibrary.r_building_miltary_flag_normal;
			this.castlePlaceToggleReinforcementsButton.ImageOver = GFXLibrary.r_building_miltary_flag_over;
			this.castlePlaceToggleReinforcementsButton.Position = new Point(88, 174);
			this.castlePlaceToggleReinforcementsButton.Visible = false;
			this.castlePlaceToggleReinforcementsButton.ClickArea = new Rectangle(10, 10, 85, 85);
			this.castlePlaceToggleReinforcementsButton.CustomTooltipID = 205;
			this.castlePlaceToggleReinforcementsButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.reinforcementsClick), "CastleMapPanel_reinforcements_toggle");
			this.castlePlacePanelImage.addControl(this.castlePlaceToggleReinforcementsButton);
			this.castlePlaceSize1Button.ImageNorm = GFXLibrary.castlescreen_unitbrush_1x1_normal;
			this.castlePlaceSize1Button.ImageOver = GFXLibrary.castlescreen_unitbrush_1x1_over;
			this.castlePlaceSize1Button.Position = new Point(26, 285);
			this.castlePlaceSize1Button.Visible = false;
			this.castlePlaceSize1Button.Data = 1;
			this.castlePlaceSize1Button.CustomTooltipID = 207;
			this.castlePlaceSize1Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceSizeClick), "CastleMapPanel_placement_1x1");
			this.castlePlacePanelImage.addControl(this.castlePlaceSize1Button);
			this.castlePlaceSize3Button.ImageNorm = GFXLibrary.castlescreen_unitbrush_3x3_normal;
			this.castlePlaceSize3Button.ImageOver = GFXLibrary.castlescreen_unitbrush_3x3_over;
			this.castlePlaceSize3Button.Position = new Point(64, 285);
			this.castlePlaceSize3Button.Visible = false;
			this.castlePlaceSize3Button.Data = 3;
			this.castlePlaceSize3Button.CustomTooltipID = 208;
			this.castlePlaceSize3Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceSizeClick), "CastleMapPanel_placement_3x3");
			this.castlePlacePanelImage.addControl(this.castlePlaceSize3Button);
			this.castlePlaceSize5Button.ImageNorm = GFXLibrary.castlescreen_unitbrush_5x5_normal;
			this.castlePlaceSize5Button.ImageOver = GFXLibrary.castlescreen_unitbrush_5x5_over;
			this.castlePlaceSize5Button.Position = new Point(102, 285);
			this.castlePlaceSize5Button.Visible = false;
			this.castlePlaceSize5Button.Data = 5;
			this.castlePlaceSize5Button.CustomTooltipID = 209;
			this.castlePlaceSize5Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceSizeClick), "CastleMapPanel_placement_5x5");
			this.castlePlacePanelImage.addControl(this.castlePlaceSize5Button);
			this.castlePlaceSize15Button.ImageNorm = GFXLibrary.castlescreen_unitbrush_1x5_normal;
			this.castlePlaceSize15Button.ImageOver = GFXLibrary.castlescreen_unitbrush_1x5_over;
			this.castlePlaceSize15Button.Position = new Point(140, 285);
			this.castlePlaceSize15Button.Visible = false;
			this.castlePlaceSize15Button.Data = 15;
			this.castlePlaceSize15Button.CustomTooltipID = 210;
			this.castlePlaceSize15Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceSizeClick), "CastleMapPanel_placement_1x5");
			this.castlePlacePanelImage.addControl(this.castlePlaceSize15Button);
			this.castlePlaceTab1Button.Position = new Point(0, 0);
			this.castlePlaceTab1Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceTab1Clicked));
			this.castlePlaceTab1Button.CustomTooltipID = 201;
			this.castlePlaceHeaderArea.addControl(this.castlePlaceTab1Button);
			this.castlePlaceTab2Button.Position = new Point(41, 0);
			this.castlePlaceTab2Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceTab2Clicked));
			this.castlePlaceTab2Button.CustomTooltipID = 202;
			this.castlePlaceHeaderArea.addControl(this.castlePlaceTab2Button);
			this.castlePlaceTab3Button.Position = new Point(79, 0);
			this.castlePlaceTab3Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceTab3Clicked));
			this.castlePlaceTab3Button.CustomTooltipID = 203;
			this.castlePlaceHeaderArea.addControl(this.castlePlaceTab3Button);
			this.castlePlaceTab4Button.Position = new Point(117, 0);
			this.castlePlaceTab4Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceTab4Clicked));
			this.castlePlaceTab4Button.CustomTooltipID = 204;
			this.castlePlaceHeaderArea.addControl(this.castlePlaceTab4Button);
			this.castlePlaceTab5Button.Position = new Point(155, 0);
			this.castlePlaceTab5Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePlaceTab5Clicked));
			this.castlePlaceTab5Button.CustomTooltipID = 223;
			this.castlePlaceHeaderArea.addControl(this.castlePlaceTab5Button);
			this.castlePlaceInfoImage.Image = GFXLibrary.r_building_panel_inset_small;
			this.castlePlaceInfoImage.Position = new Point(12, 327);
			this.castlePlacePanelImage.addControl(this.castlePlaceInfoImage);
			this.castlePlaceTypeLabel.Text = SK.Text("CastleMapPanel_Click_To_place", "Click Icons above to place");
			this.castlePlaceTypeLabel.Color = global::ARGBColors.Black;
			this.castlePlaceTypeLabel.Position = new Point(13, 4);
			this.castlePlaceTypeLabel.Size = new Size(141, 20);
			if (Program.mySettings.LanguageIdent == "tr" || Program.mySettings.LanguageIdent == "pl" || Program.mySettings.LanguageIdent == "it" || Program.mySettings.LanguageIdent == "pt")
			{
				this.castlePlaceTypeLabel.Position = new Point(13, -8);
				this.castlePlaceTypeLabel.Size = new Size(161, 40);
				this.castlePlaceTypeLabel.Font = FontManager.GetFont("Arial", 7.25f);
				this.castlePlaceTypeLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			}
			else if (Program.mySettings.LanguageIdent == "ko")
			{
				this.castlePlaceTypeLabel.Position = new Point(-2, -8);
				this.castlePlaceTypeLabel.Size = new Size(181, 40);
				this.castlePlaceTypeLabel.Font = FontManager.GetFont("Arial", 7.25f);
				this.castlePlaceTypeLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			}
			else
			{
				this.castlePlaceTypeLabel.Size = new Size(141, 20);
				this.castlePlaceTypeLabel.Font = FontManager.GetFont("Arial", 8.25f);
			}
			this.castlePlaceInfoImage.addControl(this.castlePlaceTypeLabel);
			this.castlePlaceTimeImage.Image = GFXLibrary.r_building_panel_inset_icon_time;
			this.castlePlaceTimeImage.Position = new Point(13, 22);
			this.castlePlaceTimeImage.Visible = false;
			this.castlePlaceInfoImage.addControl(this.castlePlaceTimeImage);
			this.castlePlaceTimeLabel.Text = "";
			this.castlePlaceTimeLabel.Color = global::ARGBColors.Black;
			this.castlePlaceTimeLabel.Position = new Point(40, 26);
			this.castlePlaceTimeLabel.Size = new Size(120, 20);
			this.castlePlaceTimeLabel.Visible = false;
			this.castlePlaceInfoImage.addControl(this.castlePlaceTimeLabel);
			this.castlePlaceWoodImage.Image = GFXLibrary.r_building_panel_inset_icon_wood;
			this.castlePlaceWoodImage.Position = new Point(86, 22);
			this.castlePlaceInfoImage.addControl(this.castlePlaceWoodImage);
			this.castlePlaceWoodLabel.Text = "0";
			this.castlePlaceWoodLabel.Color = global::ARGBColors.Black;
			this.castlePlaceWoodLabel.Position = new Point(113, 26);
			this.castlePlaceWoodLabel.Size = new Size(46, 20);
			this.castlePlaceWoodLabel.Visible = false;
			this.castlePlaceInfoImage.addControl(this.castlePlaceWoodLabel);
			this.castlePlaceStoneImage.Image = GFXLibrary.r_building_panel_inset_icon_stone;
			this.castlePlaceStoneImage.Position = new Point(86, 22);
			this.castlePlaceInfoImage.addControl(this.castlePlaceStoneImage);
			this.castlePlaceStoneLabel.Text = "0";
			this.castlePlaceStoneLabel.Color = global::ARGBColors.Black;
			this.castlePlaceStoneLabel.Position = new Point(113, 26);
			this.castlePlaceStoneLabel.Size = new Size(46, 20);
			this.castlePlaceStoneLabel.Visible = false;
			this.castlePlaceInfoImage.addControl(this.castlePlaceStoneLabel);
			this.castlePlaceIronImage.Image = GFXLibrary.com_16_iron;
			this.castlePlaceIronImage.Position = new Point(86, 22);
			this.castlePlaceInfoImage.addControl(this.castlePlaceIronImage);
			this.castlePlaceIronLabel.Text = "0";
			this.castlePlaceIronLabel.Color = global::ARGBColors.Black;
			this.castlePlaceIronLabel.Position = new Point(113, 26);
			this.castlePlaceIronLabel.Size = new Size(46, 20);
			this.castlePlaceIronLabel.Visible = false;
			this.castlePlaceInfoImage.addControl(this.castlePlaceIronLabel);
			this.castlePlacePitchImage.Image = GFXLibrary.com_16_pitch;
			this.castlePlacePitchImage.Position = new Point(86, 22);
			this.castlePlaceInfoImage.addControl(this.castlePlacePitchImage);
			this.castlePlacePitchLabel.Text = "0";
			this.castlePlacePitchLabel.Color = global::ARGBColors.Black;
			this.castlePlacePitchLabel.Position = new Point(113, 26);
			this.castlePlacePitchLabel.Size = new Size(46, 20);
			this.castlePlacePitchLabel.Visible = false;
			this.castlePlaceInfoImage.addControl(this.castlePlacePitchLabel);
			this.castlePlaceGoldImage.Image = GFXLibrary.r_building_panel_inset_icon_gold;
			this.castlePlaceGoldImage.Position = new Point(86, 22);
			this.castlePlaceInfoImage.addControl(this.castlePlaceGoldImage);
			this.castlePlaceGoldLabel.Text = "0";
			this.castlePlaceGoldLabel.Color = global::ARGBColors.Black;
			this.castlePlaceGoldLabel.Position = new Point(113, 26);
			this.castlePlaceGoldLabel.Size = new Size(46, 20);
			this.castlePlaceGoldLabel.Visible = false;
			this.castlePlaceInfoImage.addControl(this.castlePlaceGoldLabel);
			this.castleTotalGoldImage.Image = GFXLibrary.r_building_panel_inset_icon_gold;
			this.castleTotalGoldImage.Position = new Point(49, -18);
			this.castlePlaceInfoImage.addControl(this.castleTotalGoldImage);
			this.castleTotalGoldLabel.Text = "0";
			this.castleTotalGoldLabel.Color = global::ARGBColors.Black;
			this.castleTotalGoldLabel.Position = new Point(76, -14);
			this.castleTotalGoldLabel.Size = new Size(86, 20);
			this.castleTotalGoldLabel.Visible = false;
			this.castlePlaceInfoImage.addControl(this.castleTotalGoldLabel);
			this.utilViewModeButton.ImageNorm = GFXLibrary.r_building_miltary_viewmode_normal;
			this.utilViewModeButton.ImageOver = GFXLibrary.r_building_miltary_viewmode_over;
			this.utilViewModeButton.ImageClick = GFXLibrary.r_building_miltary_viewmode_pushed;
			this.utilViewModeButton.Position = new Point(2, 44);
			if (CastleMap.displayCollapsed)
			{
				this.utilViewModeButton.CustomTooltipID = 211;
			}
			else
			{
				this.utilViewModeButton.CustomTooltipID = 212;
			}
			this.utilViewModeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.utilViewModeClick));
			this.castlePlaceInfoImage.addControl(this.utilViewModeButton);
			this.deleteHeaderButton.ImageNorm = GFXLibrary.r_building_miltary_deletemode_off_normal;
			this.deleteHeaderButton.ImageOver = GFXLibrary.r_building_miltary_deletemode_off_over;
			this.deleteHeaderButton.Position = new Point(90, 44);
			this.deleteHeaderButton.Text.Text = SK.Text("GENERIC_Delete", "Delete");
			this.deleteHeaderButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.deleteHeaderButton.Text.Position = new Point(6, -6);
			this.deleteHeaderButton.Text.Size = new Size(this.deleteHeaderButton.Width - 15, this.deleteHeaderButton.Height);
			this.deleteHeaderButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.deleteHeaderButton.TextYOffset = 0;
			this.deleteHeaderButton.Text.Color = global::ARGBColors.Black;
			this.deleteHeaderButton.CustomTooltipID = 213;
			this.deleteHeaderButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castleElementDeleteToggle), "CastleMapPanel_toggle_delete");
			this.castlePlaceInfoImage.addControl(this.deleteHeaderButton);
			this.deleteHeaderLabel.Text = SK.Text("CastleMapPanel_Off", "Off");
			this.deleteHeaderLabel.Color = global::ARGBColors.Black;
			this.deleteHeaderLabel.Position = new Point(0, 20);
			this.deleteHeaderLabel.Size = new Size(this.deleteHeaderButton.Text.Size.Width + 20, this.deleteHeaderButton.Text.Size.Height);
			this.deleteHeaderLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			if (Program.mySettings.LanguageIdent == "pl" || Program.mySettings.LanguageIdent == "pt")
			{
				this.deleteHeaderLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
			}
			else
			{
				this.deleteHeaderLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			}
			this.deleteHeaderButton.addControl(this.deleteHeaderLabel);
			this.castlePlaceGuardhouseLabel.Text = "";
			this.castlePlaceGuardhouseLabel.Color = global::ARGBColors.Black;
			this.castlePlaceGuardhouseLabel.Visible = false;
			this.castlePlaceGuardhouseLabel.Position = new Point(10, 18);
			this.castlePlaceGuardhouseLabel.Size = new Size(160, 25);
			this.castlePlaceGuardhouseLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.castlePlaceInfoImage.addControl(this.castlePlaceGuardhouseLabel);
			this.castlePlacePanelFaderImage.Image = GFXLibrary.r_building_panel_back;
			this.castlePlacePanelFaderImage.Position = new Point(0, 0);
			this.castlePlacePanelFaderImage.Alpha = 0f;
			this.castlePlacePanelImage.addControl(this.castlePlacePanelFaderImage);
			this.setCastlePlaceTab(-1);
		}

		// Token: 0x06000A9C RID: 2716 RVA: 0x000D4848 File Offset: 0x000D2A48
		private void castlePlaceMouseOver()
		{
			if (!this.buildingBeingPlaced && this.OverControl != null)
			{
				CustomSelfDrawPanel.CSDControl overControl = this.OverControl;
				int data = overControl.Data;
				if (data < 110 && GameEngine.Instance.Castle != null)
				{
					GameEngine.Instance.Castle.startPlaceElement_ShowPanel(data, CastlesCommon.getPieceName(data), true);
				}
			}
		}

		// Token: 0x06000A9D RID: 2717 RVA: 0x0000E021 File Offset: 0x0000C221
		private void castlePlaceMouseLeave()
		{
			if (!this.buildingBeingPlaced)
			{
				this.clearCastlePlaceInfo();
			}
		}

		// Token: 0x06000A9E RID: 2718 RVA: 0x000D489C File Offset: 0x000D2A9C
		private void castlePlaceClick()
		{
			CustomSelfDrawPanel.CSDControl overControl = this.OverControl;
			if (overControl == null)
			{
				return;
			}
			int num = overControl.Data;
			if (num < 69)
			{
				if (GameEngine.Instance.Castle != null && GameEngine.Instance.Castle.startPlaceElement(num))
				{
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
					GameEngine.Instance.Castle.startPlaceElement_ShowPanel(num, CastlesCommon.getPieceName(num), false);
					this.buildingBeingPlaced = true;
					return;
				}
			}
			else if (num < 110 && GameEngine.Instance.Castle != null)
			{
				GameEngine.Instance.Castle.startPlacingTroops(num, this.placingReinforcements);
				GameEngine.Instance.Castle.startPlaceElement_ShowPanel(num, CastlesCommon.getPieceName(num), false);
				this.buildingBeingPlaced = true;
			}
		}

		// Token: 0x06000A9F RID: 2719 RVA: 0x000D495C File Offset: 0x000D2B5C
		public void setCastleElementInfo(string pieceName, int woodCost, int stoneCost, int ironCost, int pitchCost, int goldCost, string buildTime, bool rollover)
		{
			NumberFormatInfo nfi = GameEngine.NFI;
			VillageMap village = GameEngine.Instance.Village;
			this.clearCastlePlaceInfo();
			this.castlePlaceTypeLabel.Text = pieceName;
			this.castlePlaceTypeLabel.Visible = true;
			if (this.currentCastlePlaceTab == 0)
			{
				return;
			}
			this.castlePlaceTimeLabel.Visible = true;
			if (buildTime.Length > 8)
			{
				string text = "";
				bool flag = false;
				foreach (char c in buildTime)
				{
					if (c == ':')
					{
						if (flag)
						{
							break;
						}
						text += c.ToString();
						flag = true;
					}
					else
					{
						text += c.ToString();
					}
				}
				buildTime = text;
			}
			this.castlePlaceTimeImage.Visible = true;
			this.castlePlaceTimeLabel.Text = buildTime;
			if (woodCost > 0)
			{
				this.castlePlaceWoodLabel.Text = woodCost.ToString("N", nfi);
				this.castlePlaceWoodLabel.Visible = true;
				this.castlePlaceWoodImage.Visible = true;
				this.castlePlaceWoodLabel.Color = global::ARGBColors.Black;
				if (village != null && village.getResourceLevel(6) < (double)woodCost)
				{
					this.castlePlaceWoodLabel.Color = global::ARGBColors.Red;
				}
			}
			if (stoneCost > 0)
			{
				this.castlePlaceStoneLabel.Text = stoneCost.ToString("N", nfi);
				this.castlePlaceStoneLabel.Visible = true;
				this.castlePlaceStoneImage.Visible = true;
				this.castlePlaceStoneLabel.Color = global::ARGBColors.Black;
				if (village != null && village.getResourceLevel(7) < (double)stoneCost)
				{
					this.castlePlaceStoneLabel.Color = global::ARGBColors.Red;
				}
			}
			if (pitchCost > 0)
			{
				this.castlePlacePitchLabel.Text = pitchCost.ToString("N", nfi);
				this.castlePlacePitchLabel.Visible = true;
				this.castlePlacePitchImage.Visible = true;
				this.castlePlacePitchLabel.Color = global::ARGBColors.Black;
				if (village != null && village.getResourceLevel(9) < (double)pitchCost)
				{
					this.castlePlacePitchLabel.Color = global::ARGBColors.Red;
				}
			}
			if (ironCost > 0)
			{
				this.castlePlaceIronLabel.Text = ironCost.ToString("N", nfi);
				this.castlePlaceIronLabel.Visible = true;
				this.castlePlaceIronImage.Visible = true;
				this.castlePlaceIronLabel.Color = global::ARGBColors.Black;
				if (village != null && village.getResourceLevel(8) < (double)ironCost)
				{
					this.castlePlaceIronLabel.Color = global::ARGBColors.Red;
				}
			}
			double num = GameEngine.Instance.World.getCurrentGold();
			int selectedMenuVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
			if (GameEngine.Instance.World.isCapital(selectedMenuVillage) && GameEngine.Instance.Castle != null)
			{
				num = village.m_capitalGold;
				int num2 = (int)num;
				VillageMap.StockpileLevels stockpileLevels = new VillageMap.StockpileLevels();
				GameEngine.Instance.Castle.adjustLevels(ref stockpileLevels, ref num2);
				this.castleTotalGoldLabel.Text = num2.ToString("N", nfi);
			}
			if (goldCost > 0)
			{
				this.castlePlaceGoldLabel.Text = goldCost.ToString("N", nfi);
				this.castlePlaceGoldLabel.Visible = true;
				this.castlePlaceGoldImage.Visible = true;
				this.castlePlaceGoldLabel.Color = global::ARGBColors.Black;
				if (num < (double)goldCost)
				{
					this.castlePlaceGoldLabel.Color = global::ARGBColors.Red;
				}
			}
			if (!rollover)
			{
				this.buildingBeingPlaced = true;
			}
		}

		// Token: 0x06000AA0 RID: 2720 RVA: 0x000D4C9C File Offset: 0x000D2E9C
		public void clearCastlePlaceInfo()
		{
			this.buildingBeingPlaced = false;
			this.castlePlaceTypeLabel.Text = SK.Text("CastleMapPanel_Click_To_place", "Click Icons above to place");
			this.castlePlaceTimeLabel.Visible = false;
			this.castlePlaceWoodLabel.Visible = false;
			this.castlePlacePitchLabel.Visible = false;
			this.castlePlaceIronLabel.Visible = false;
			this.castlePlaceStoneLabel.Visible = false;
			this.castlePlaceGoldLabel.Visible = false;
			this.castlePlaceTimeImage.Visible = false;
			this.castlePlaceWoodImage.Visible = false;
			this.castlePlaceStoneImage.Visible = false;
			this.castlePlaceIronImage.Visible = false;
			this.castlePlacePitchImage.Visible = false;
			this.castlePlaceGoldImage.Visible = false;
		}

		// Token: 0x06000AA1 RID: 2721 RVA: 0x0000E031 File Offset: 0x0000C231
		public bool TUTORIAL_openedWoodTab()
		{
			return this.currentCastlePlaceHeight != 0 && this.currentCastlePlaceTab == 1;
		}

		// Token: 0x06000AA2 RID: 2722 RVA: 0x000D4D5C File Offset: 0x000D2F5C
		private void castlePlaceTab1Clicked()
		{
			if (this.currentCastlePlaceHeight == 0)
			{
				GameEngine.Instance.playInterfaceSound("CastleMapPanel_tab_open");
				this.openCastlePlaceTab();
			}
			else
			{
				if (this.currentCastlePlaceTab == 0 || this.currentCastlePlaceTab >= 1000)
				{
					GameEngine.Instance.playInterfaceSound("CastleMapPanel_tab_close");
					this.closeCastlePlacePanel();
					return;
				}
				GameEngine.Instance.playInterfaceSound("CastleMapPanel_tab_clicked");
			}
			this.setCastlePlaceTab(0);
		}

		// Token: 0x06000AA3 RID: 2723 RVA: 0x000D4DCC File Offset: 0x000D2FCC
		private void castlePlaceTab2Clicked()
		{
			if (this.currentCastlePlaceHeight == 0)
			{
				GameEngine.Instance.playInterfaceSound("CastleMapPanel_tab_open");
				this.openCastlePlaceTab();
			}
			else
			{
				if (this.currentCastlePlaceTab == 1)
				{
					GameEngine.Instance.playInterfaceSound("CastleMapPanel_tab_close");
					this.closeCastlePlacePanel();
					return;
				}
				GameEngine.Instance.playInterfaceSound("CastleMapPanel_tab_clicked");
			}
			this.setCastlePlaceTab(1);
		}

		// Token: 0x06000AA4 RID: 2724 RVA: 0x000D4E30 File Offset: 0x000D3030
		private void castlePlaceTab3Clicked()
		{
			if (this.currentCastlePlaceHeight == 0)
			{
				GameEngine.Instance.playInterfaceSound("CastleMapPanel_tab_open");
				this.openCastlePlaceTab();
			}
			else
			{
				if (this.currentCastlePlaceTab == 2)
				{
					GameEngine.Instance.playInterfaceSound("CastleMapPanel_tab_close");
					this.closeCastlePlacePanel();
					return;
				}
				GameEngine.Instance.playInterfaceSound("CastleMapPanel_tab_clicked");
			}
			this.setCastlePlaceTab(2);
		}

		// Token: 0x06000AA5 RID: 2725 RVA: 0x000D4E94 File Offset: 0x000D3094
		private void castlePlaceTab4Clicked()
		{
			if (this.currentCastlePlaceHeight == 0)
			{
				GameEngine.Instance.playInterfaceSound("CastleMapPanel_tab_open");
				this.openCastlePlaceTab();
			}
			else
			{
				if (this.currentCastlePlaceTab == 3)
				{
					GameEngine.Instance.playInterfaceSound("CastleMapPanel_tab_close");
					this.closeCastlePlacePanel();
					return;
				}
				GameEngine.Instance.playInterfaceSound("CastleMapPanel_tab_clicked");
			}
			this.setCastlePlaceTab(3);
		}

		// Token: 0x06000AA6 RID: 2726 RVA: 0x000D4EF8 File Offset: 0x000D30F8
		private void castlePlaceTab5Clicked()
		{
			if (this.currentCastlePlaceHeight == 0)
			{
				GameEngine.Instance.playInterfaceSound("CastleMapPanel_tab_open");
				this.openCastlePlaceTab();
			}
			else
			{
				if (this.currentCastlePlaceTab == 4)
				{
					GameEngine.Instance.playInterfaceSound("CastleMapPanel_tab_close");
					this.closeCastlePlacePanel();
					return;
				}
				GameEngine.Instance.playInterfaceSound("CastleMapPanel_tab_clicked");
			}
			this.setCastlePlaceTab(4);
		}

		// Token: 0x06000AA7 RID: 2727 RVA: 0x0000E049 File Offset: 0x0000C249
		private void openCastlePlaceTab()
		{
			this.closeutilPanel();
			this.targetCastlePlaceHeight = 422;
		}

		// Token: 0x06000AA8 RID: 2728 RVA: 0x0000E05C File Offset: 0x0000C25C
		private void closeCastlePlacePanel()
		{
			this.targetCastlePlaceHeight = 0;
		}

		// Token: 0x06000AA9 RID: 2729 RVA: 0x0000E065 File Offset: 0x0000C265
		private void reinforcementsClick()
		{
			this.setReinforcementsMode(!this.placingReinforcements);
			if (GameEngine.Instance.Castle != null)
			{
				GameEngine.Instance.Castle.recalcCastleLayout();
			}
		}

		// Token: 0x06000AAA RID: 2730 RVA: 0x000D4F5C File Offset: 0x000D315C
		private void setReinforcementsMode(bool reinforcements)
		{
			this.placingReinforcements = reinforcements;
			if (!reinforcements)
			{
				this.castlePlaceToggleReinforcementsButton.CustomTooltipID = 205;
				this.castlePlacePeasantButton.ImageNorm = GFXLibrary.r_building_miltary_peasent;
				this.castlePlacePeasantButton.ImageOver = GFXLibrary.r_building_miltary_peasent_over;
				this.castlePlaceArcherButton.ImageNorm = GFXLibrary.r_building_miltary_archer;
				this.castlePlaceArcherButton.ImageOver = GFXLibrary.r_building_miltary_archer_over;
				this.castlePlacePikemanButton.ImageNorm = GFXLibrary.r_building_miltary_pikemen;
				this.castlePlacePikemanButton.ImageOver = GFXLibrary.r_building_miltary_pikemen_over;
				this.castlePlaceSwordsmanButton.ImageNorm = GFXLibrary.r_building_miltary_swordsman;
				this.castlePlaceSwordsmanButton.ImageOver = GFXLibrary.r_building_miltary_swordsman_over;
				this.castlePlaceToggleReinforcementsButton.ImageNorm = GFXLibrary.r_building_miltary_flag_normal;
				this.castlePlaceToggleReinforcementsButton.ImageOver = GFXLibrary.r_building_miltary_flag_over;
				return;
			}
			this.castlePlaceToggleReinforcementsButton.CustomTooltipID = 206;
			this.castlePlacePeasantButton.ImageNorm = GFXLibrary.r_building_miltary_peasent_green;
			this.castlePlacePeasantButton.ImageOver = GFXLibrary.r_building_miltary_peasent_over_green;
			this.castlePlaceArcherButton.ImageNorm = GFXLibrary.r_building_miltary_archer_green;
			this.castlePlaceArcherButton.ImageOver = GFXLibrary.r_building_miltary_archer_over_green;
			this.castlePlacePikemanButton.ImageNorm = GFXLibrary.r_building_miltary_pikemen_green;
			this.castlePlacePikemanButton.ImageOver = GFXLibrary.r_building_miltary_pikemen_over_green;
			this.castlePlaceSwordsmanButton.ImageNorm = GFXLibrary.r_building_miltary_swordsman_green;
			this.castlePlaceSwordsmanButton.ImageOver = GFXLibrary.r_building_miltary_swordsman_over_green;
			this.castlePlaceToggleReinforcementsButton.ImageNorm = GFXLibrary.r_building_miltary_flag_blue_normal;
			this.castlePlaceToggleReinforcementsButton.ImageOver = GFXLibrary.r_building_miltary_flag_blue_over;
		}

		// Token: 0x06000AAB RID: 2731 RVA: 0x000D513C File Offset: 0x000D333C
		private void castlePlaceSizeClick()
		{
			CustomSelfDrawPanel.CSDControl overControl = this.OverControl;
			if (overControl != null)
			{
				int data = overControl.Data;
				this.setPlaceSize(data);
			}
		}

		// Token: 0x06000AAC RID: 2732 RVA: 0x000D5164 File Offset: 0x000D3364
		private void setPlaceSize(int size)
		{
			this.placementSize = size;
			switch (size)
			{
			case 1:
				if (GameEngine.Instance.Castle != null)
				{
					GameEngine.Instance.Castle.CurrentBrushSize = CastleMap.BrushSize.BRUSH_1X1;
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
				if (GameEngine.Instance.Castle != null)
				{
					GameEngine.Instance.Castle.CurrentBrushSize = CastleMap.BrushSize.BRUSH_3X3;
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
				if (GameEngine.Instance.Castle != null)
				{
					GameEngine.Instance.Castle.CurrentBrushSize = CastleMap.BrushSize.BRUSH_5X5;
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
				if (GameEngine.Instance.Castle != null)
				{
					GameEngine.Instance.Castle.CurrentBrushSize = CastleMap.BrushSize.BRUSH_1X5;
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

		// Token: 0x06000AAD RID: 2733 RVA: 0x000D54B0 File Offset: 0x000D36B0
		private void setCastlePlaceTab(int tab)
		{
			this.currentCastlePlaceTab = tab;
			this.castlePlaceTab1Button.ImageNorm = GFXLibrary.castlebar_unit_normal;
			this.castlePlaceTab1Button.ImageOver = GFXLibrary.castlebar_unit_over;
			this.castlePlaceTab1Button.ImageClick = GFXLibrary.castlebar_unit_normal;
			this.castlePlaceTab2Button.ImageNorm = GFXLibrary.castlebar_wood_normal;
			this.castlePlaceTab2Button.ImageOver = GFXLibrary.castlebar_wood_over;
			this.castlePlaceTab2Button.ImageClick = GFXLibrary.castlebar_wood_normal;
			this.castlePlaceTab3Button.ImageNorm = GFXLibrary.castlebar_stone_normal;
			this.castlePlaceTab3Button.ImageOver = GFXLibrary.castlebar_stone_overl;
			this.castlePlaceTab3Button.ImageClick = GFXLibrary.castlebar_stone_normal;
			this.castlePlaceTab4Button.ImageNorm = GFXLibrary.castlebar_defenses_normal;
			this.castlePlaceTab4Button.ImageOver = GFXLibrary.castlebar_defenses_over;
			this.castlePlaceTab4Button.ImageClick = GFXLibrary.castlebar_defenses_normal;
			this.castlePlaceTab5Button.ImageNorm = GFXLibrary.castlebar_lock_normal;
			this.castlePlaceTab5Button.ImageOver = GFXLibrary.castlebar_lock_over;
			this.castlePlaceTab5Button.ImageClick = GFXLibrary.castlebar_lock_normal;
			this.castlePlaceTab1Button.CustomTooltipData = 0;
			this.castlePlaceTab2Button.CustomTooltipData = 0;
			this.castlePlaceTab3Button.CustomTooltipData = 0;
			this.castlePlaceTab4Button.CustomTooltipData = 0;
			this.castlePlaceTab5Button.CustomTooltipData = 0;
			switch (tab)
			{
			case 0:
				this.castlePlaceTab1Button.CustomTooltipData = 1;
				this.castlePlaceTab1Button.ImageNorm = GFXLibrary.castlebar_unit_selected;
				this.castlePlaceTab1Button.ImageOver = GFXLibrary.castlebar_unit_selected;
				this.castlePlaceTab1Button.ImageClick = GFXLibrary.castlebar_unit_selected;
				break;
			case 1:
				this.castlePlaceTab2Button.CustomTooltipData = 1;
				this.castlePlaceTab2Button.ImageNorm = GFXLibrary.castlebar_wood_selected;
				this.castlePlaceTab2Button.ImageOver = GFXLibrary.castlebar_wood_selected;
				this.castlePlaceTab2Button.ImageClick = GFXLibrary.castlebar_wood_selected;
				break;
			case 2:
				this.castlePlaceTab3Button.CustomTooltipData = 1;
				this.castlePlaceTab3Button.ImageNorm = GFXLibrary.castlebar_stone_selected;
				this.castlePlaceTab3Button.ImageOver = GFXLibrary.castlebar_stone_selected;
				this.castlePlaceTab3Button.ImageClick = GFXLibrary.castlebar_stone_selected;
				break;
			case 3:
				this.castlePlaceTab4Button.CustomTooltipData = 1;
				this.castlePlaceTab4Button.ImageNorm = GFXLibrary.castlebar_defenses_selected;
				this.castlePlaceTab4Button.ImageOver = GFXLibrary.castlebar_defenses_selected;
				this.castlePlaceTab4Button.ImageClick = GFXLibrary.castlebar_defenses_selected;
				break;
			case 4:
				this.castlePlaceTab5Button.CustomTooltipData = 1;
				this.castlePlaceTab5Button.ImageNorm = GFXLibrary.castlebar_lock_selected;
				this.castlePlaceTab5Button.ImageOver = GFXLibrary.castlebar_lock_selected;
				this.castlePlaceTab5Button.ImageClick = GFXLibrary.castlebar_lock_selected;
				break;
			}
			this.resetCastleIcons();
			bool flag = true;
			int selectedMenuVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
			if (GameEngine.Instance.World.isCapital(selectedMenuVillage) && !GameEngine.Instance.World.isUserVillage(selectedMenuVillage))
			{
				flag = false;
			}
			if (flag && GameEngine.Instance.Castle != null)
			{
				switch (tab)
				{
				case 0:
					if (!GameEngine.Instance.Castle.InBuilderMode || CastleMap.CreateMode)
					{
						if (this.canPlaceCastleItem(70))
						{
							this.castlePlacePeasantButton.Visible = true;
						}
						if (this.canPlaceCastleItem(72))
						{
							this.castlePlaceArcherButton.Visible = true;
						}
						if (this.canPlaceCastleItem(73))
						{
							this.castlePlacePikemanButton.Visible = true;
						}
						if (this.canPlaceCastleItem(71))
						{
							this.castlePlaceSwordsmanButton.Visible = true;
						}
						if (CastleMap.CreateMode)
						{
							this.castlePlaceWolfButton.Visible = true;
						}
						else if (this.canPlaceCastleItem(85))
						{
							this.castlePlaceWolfButton.Visible = true;
						}
						this.castlePlaceToggleReinforcementsButton.Visible = true;
						this.castlePlaceSize1Button.Visible = true;
						this.castlePlaceSize3Button.Visible = true;
						this.castlePlaceSize5Button.Visible = true;
						this.castlePlaceSize15Button.Visible = true;
						this.castlePlaceGuardhouseLabel.Visible = true;
					}
					this.castlePlaceTimeImage.Visible = false;
					this.castlePlaceWoodImage.Visible = false;
					this.castlePlaceStoneImage.Visible = false;
					this.castlePlaceIronImage.Visible = false;
					this.castlePlacePitchImage.Visible = false;
					this.castlePlaceGoldImage.Visible = false;
					this.castleTotalGoldImage.Visible = false;
					this.castleTotalGoldLabel.Visible = false;
					break;
				case 1:
					if (!GameEngine.Instance.Castle.InTroopPlacerMode || CastleMap.CreateMode)
					{
						this.addCastleIcon(33, GFXLibrary.r_building_miltary_woodwall, GFXLibrary.r_building_miltary_woodwall_over);
						this.addCastleIcon(66, GFXLibrary.r_building_miltary_woodwallblock, GFXLibrary.r_building_miltary_woodwallblock_over);
						this.addCastleIcon(39, GFXLibrary.r_building_miltary_gatehouse_wood, GFXLibrary.r_building_miltary_gatehouse_wood_over);
						this.addCastleIcon(21, GFXLibrary.r_building_miltary_woodtower, GFXLibrary.r_building_miltary_woodtower_over);
					}
					break;
				case 2:
					if (!GameEngine.Instance.Castle.InTroopPlacerMode || CastleMap.CreateMode)
					{
						this.addCastleIcon(34, GFXLibrary.r_building_miltary_stonewall, GFXLibrary.r_building_miltary_stonewall_over);
						this.addCastleIcon(65, GFXLibrary.r_building_miltary_stonewallblock, GFXLibrary.r_building_miltary_stonewallblock_over);
						this.addCastleIcon(37, GFXLibrary.r_building_miltary_gatehouse, GFXLibrary.r_building_miltary_gatehouse_over);
						this.addCastleIcon(11, GFXLibrary.r_building_miltary_lookouttower, GFXLibrary.r_building_miltary_lookouttower_over);
						this.addCastleIcon(12, GFXLibrary.r_building_miltary_smalltower, GFXLibrary.r_building_miltary_smalltower_over);
						this.addCastleIcon(13, GFXLibrary.r_building_miltary_largetower, GFXLibrary.r_building_miltary_largetower_over);
						this.addCastleIcon(14, GFXLibrary.r_building_miltary_greattower, GFXLibrary.r_building_miltary_greattower_over);
					}
					break;
				case 3:
					if (!GameEngine.Instance.Castle.InTroopPlacerMode || CastleMap.CreateMode)
					{
						this.addCastleIcon(31, GFXLibrary.r_building_miltary_guardhouse, GFXLibrary.r_building_miltary_guardhouse_over);
						this.addCastleIcon(36, GFXLibrary.r_building_miltary_killingpits, GFXLibrary.r_building_miltary_killingpits_over);
						this.addCastleIcon(32, GFXLibrary.r_building_miltary_smelter, GFXLibrary.r_building_miltary_smelter_over);
					}
					if (!GameEngine.Instance.Castle.InBuilderMode || CastleMap.CreateMode)
					{
						this.addCastleIcon(75, GFXLibrary.r_building_miltary_oilpots, GFXLibrary.r_building_miltary_oilpots_over);
					}
					if (!GameEngine.Instance.Castle.InTroopPlacerMode || CastleMap.CreateMode)
					{
						this.addCastleIcon(35, GFXLibrary.r_building_miltary_moat, GFXLibrary.r_building_miltary_moat_over);
					}
					break;
				case 4:
					if (!GameEngine.Instance.Castle.InTroopPlacerMode || CastleMap.CreateMode)
					{
						this.addCastleIcon(41, GFXLibrary.r_building_miltary_turrets, GFXLibrary.r_building_miltary_tunnels_over);
						this.addCastleIcon(43, GFXLibrary.r_building_miltary_tunnels, GFXLibrary.r_building_miltary_turrets_over);
						this.addCastleIcon(42, GFXLibrary.r_building_miltary_ballista, GFXLibrary.r_building_miltary_ballista_over);
						this.addCastleIcon(44, GFXLibrary.r_building_miltary_bombard, GFXLibrary.r_building_miltary_bombard_over);
					}
					break;
				}
			}
			if (!GameEngine.Instance.World.WorldEnded)
			{
				this.deleteHeaderButton.Enabled = true;
			}
			else
			{
				this.deleteHeaderButton.Enabled = false;
			}
			if (GameEngine.Instance.World.isCapital(selectedMenuVillage))
			{
				VillageMap village = GameEngine.Instance.Village;
				if (village != null)
				{
					NumberFormatInfo nfi = GameEngine.NFI;
					this.castleTotalGoldLabel.Text = ((int)village.m_capitalGold).ToString("N", nfi);
				}
				if (!GameEngine.Instance.World.isUserVillage(selectedMenuVillage))
				{
					this.deleteHeaderButton.Enabled = false;
				}
			}
		}

		// Token: 0x06000AAE RID: 2734 RVA: 0x0000E091 File Offset: 0x0000C291
		public void refreshInterface()
		{
			this.controlBlockOverlay.Visible = false;
			if (this.currentCastlePlaceTab >= 0)
			{
				this.setCastlePlaceTab(this.currentCastlePlaceTab);
			}
		}

		// Token: 0x06000AAF RID: 2735 RVA: 0x000D5C34 File Offset: 0x000D3E34
		private void resetCastleIcons()
		{
			this.clearCastlePlaceInfo();
			this.currentCastleIcon = 0;
			this.castlePlace1Button.Visible = false;
			this.castlePlace2Button.Visible = false;
			this.castlePlace3Button.Visible = false;
			this.castlePlace4Button.Visible = false;
			this.castlePlace5Button.Visible = false;
			this.castlePlace6Button.Visible = false;
			this.castlePlace7Button.Visible = false;
			this.castlePlace8Button.Visible = false;
			this.castlePlacePeasantButton.Visible = false;
			this.castlePlaceArcherButton.Visible = false;
			this.castlePlacePikemanButton.Visible = false;
			this.castlePlaceSwordsmanButton.Visible = false;
			this.castlePlaceWolfButton.Visible = false;
			this.castlePlaceToggleReinforcementsButton.Visible = false;
			this.castlePlaceSize1Button.Visible = false;
			this.castlePlaceSize3Button.Visible = false;
			this.castlePlaceSize5Button.Visible = false;
			this.castlePlaceSize15Button.Visible = false;
			this.castlePlaceGuardhouseLabel.Visible = false;
			this.castlePlaceTimeImage.Visible = false;
			this.castlePlaceWoodImage.Visible = false;
			this.castlePlaceStoneImage.Visible = false;
			this.castlePlaceIronImage.Visible = false;
			this.castlePlacePitchImage.Visible = false;
			this.castlePlaceGoldImage.Visible = false;
			this.building1Image.Visible = false;
			this.building2Image.Visible = false;
			this.building3Image.Visible = false;
			this.building4Image.Visible = false;
			this.building5Image.Visible = false;
			this.building6Image.Visible = false;
			this.building7Image.Visible = false;
			this.building8Image.Visible = false;
			int selectedMenuVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
			if (GameEngine.Instance.World.isCapital(selectedMenuVillage))
			{
				this.castleTotalGoldImage.Visible = true;
				this.castleTotalGoldLabel.Visible = true;
				return;
			}
			this.castleTotalGoldImage.Visible = false;
			this.castleTotalGoldLabel.Visible = false;
		}

		// Token: 0x06000AB0 RID: 2736 RVA: 0x000D5E28 File Offset: 0x000D4028
		private void addCastleIcon(int pieceType, BaseImage newImage, BaseImage overImage)
		{
			bool enabled = true;
			bool flag = false;
			int num = pieceType;
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
			if (this.canPlaceCastleItem(num))
			{
				flag = true;
			}
			if (pieceType == 75 && GameEngine.Instance.Castle.InBuilderMode && !CastleMap.CreateMode)
			{
				flag = false;
			}
			if (!flag)
			{
				return;
			}
			if (pieceType == 44 || pieceType == 41 || pieceType == 42 || pieceType == 31 || pieceType == 35 || pieceType == 75)
			{
				int num2 = 0;
				int num3 = 0;
				if (pieceType <= 35)
				{
					if (pieceType != 31)
					{
						if (pieceType == 35)
						{
							num3 = GameEngine.Instance.Castle.countMoat();
							num2 = GameEngine.Instance.LocalWorldData.Castle_Max_Moat_Tiles;
						}
					}
					else
					{
						num3 = GameEngine.Instance.Castle.countGuardHouses();
						num2 = 400 / GameEngine.Instance.LocalWorldData.castle_troopsPerGuardHouse;
						num2 = (GameEngine.Instance.World.isCapital(GameEngine.Instance.Village.VillageID) ? (num2 - 5) : (num2 - 2));
					}
				}
				else
				{
					switch (pieceType)
					{
					case 41:
						num3 = GameEngine.Instance.Castle.countTurrets();
						num2 = (int)GameEngine.Instance.Village.m_parishCapitalResearchData.Research_CAP_Turrets;
						break;
					case 42:
						num3 = GameEngine.Instance.Castle.countBallistas();
						num2 = (int)GameEngine.Instance.Village.m_parishCapitalResearchData.Research_CAP_Ballista;
						break;
					case 43:
						break;
					case 44:
						num3 = GameEngine.Instance.Castle.countBombards();
						num2 = (int)GameEngine.Instance.Village.m_parishCapitalResearchData.Research_Leadership;
						break;
					default:
						if (pieceType == 75)
						{
							num3 = GameEngine.Instance.Castle.countPlacedOilPots();
							num2 = GameEngine.Instance.LocalWorldData.castle_oilPerSmelter * GameEngine.Instance.Castle.countCompletedSmelters();
						}
						break;
					}
				}
				if (num2 <= num3)
				{
					enabled = false;
				}
				else if (num2 - num3 > 1)
				{
					CustomSelfDrawPanel.CSDImage csdimage = null;
					CustomSelfDrawPanel.CSDLabel csdlabel = null;
					switch (this.currentCastleIcon)
					{
					case 0:
						csdimage = this.building1Image;
						csdlabel = this.building1Label;
						break;
					case 1:
						csdimage = this.building2Image;
						csdlabel = this.building2Label;
						break;
					case 2:
						csdimage = this.building3Image;
						csdlabel = this.building3Label;
						break;
					case 3:
						csdimage = this.building4Image;
						csdlabel = this.building4Label;
						break;
					case 4:
						csdimage = this.building5Image;
						csdlabel = this.building5Label;
						break;
					case 5:
						csdimage = this.building6Image;
						csdlabel = this.building6Label;
						break;
					case 6:
						csdimage = this.building7Image;
						csdlabel = this.building7Label;
						break;
					case 7:
						csdimage = this.building8Image;
						csdlabel = this.building8Label;
						break;
					}
					if (csdimage != null)
					{
						csdimage.Visible = true;
					}
					if (csdlabel != null)
					{
						csdlabel.Text = (num2 - num3).ToString();
					}
				}
			}
			CustomSelfDrawPanel.CSDButton csdbutton;
			switch (this.currentCastleIcon)
			{
			case 0:
				csdbutton = this.castlePlace1Button;
				break;
			case 1:
				csdbutton = this.castlePlace2Button;
				break;
			case 2:
				csdbutton = this.castlePlace3Button;
				break;
			case 3:
				csdbutton = this.castlePlace4Button;
				break;
			case 4:
				csdbutton = this.castlePlace5Button;
				break;
			case 5:
				csdbutton = this.castlePlace6Button;
				break;
			case 6:
				csdbutton = this.castlePlace7Button;
				break;
			case 7:
				csdbutton = this.castlePlace8Button;
				break;
			default:
				return;
			}
			if (csdbutton != null)
			{
				csdbutton.ImageNorm = newImage;
				csdbutton.ImageOver = overImage;
				csdbutton.Visible = true;
				csdbutton.Enabled = enabled;
				csdbutton.Data = pieceType;
				csdbutton.CustomTooltipID = 200;
				csdbutton.CustomTooltipData = pieceType;
			}
			this.currentCastleIcon++;
		}

		// Token: 0x06000AB1 RID: 2737 RVA: 0x000D61E4 File Offset: 0x000D43E4
		public bool canPlaceCastleItem(int pieceType)
		{
			if (CastleMap.CreateMode)
			{
				return true;
			}
			ResearchData researchDataForCurrentVillage = GameEngine.Instance.World.GetResearchDataForCurrentVillage();
			int research_Fortification = (int)researchDataForCurrentVillage.Research_Fortification;
			int research_Defences = (int)researchDataForCurrentVillage.Research_Defences;
			WorldData localWorldData = GameEngine.Instance.LocalWorldData;
			switch (pieceType)
			{
			case 11:
				if (research_Fortification >= 4)
				{
					return true;
				}
				break;
			case 12:
				if (research_Fortification >= 5)
				{
					return true;
				}
				break;
			case 13:
				if (research_Fortification >= 7)
				{
					return true;
				}
				break;
			case 14:
				if (research_Fortification >= 8)
				{
					return true;
				}
				break;
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 22:
			case 23:
			case 24:
			case 25:
			case 26:
			case 27:
			case 28:
			case 29:
			case 30:
				break;
			case 21:
				if (research_Fortification >= 2)
				{
					return true;
				}
				break;
			case 31:
				if (research_Defences >= 1)
				{
					return true;
				}
				break;
			case 32:
				if (research_Defences >= 5)
				{
					return true;
				}
				break;
			case 33:
				if (research_Fortification >= 1)
				{
					return true;
				}
				break;
			case 34:
				if (research_Fortification >= 3)
				{
					return true;
				}
				break;
			case 35:
				if (research_Defences >= 7)
				{
					return true;
				}
				break;
			case 36:
				if (research_Defences >= 2)
				{
					return true;
				}
				break;
			case 37:
			case 38:
				if (research_Fortification >= 6)
				{
					return true;
				}
				break;
			case 39:
			case 40:
				if (research_Fortification >= 1)
				{
					return true;
				}
				break;
			case 41:
				return GameEngine.Instance.Village == null || GameEngine.Instance.Village.m_parishCapitalResearchData == null || GameEngine.Instance.Village.m_parishCapitalResearchData.Research_CAP_Turrets > 0;
			case 42:
				return GameEngine.Instance.Village == null || GameEngine.Instance.Village.m_parishCapitalResearchData == null || GameEngine.Instance.Village.m_parishCapitalResearchData.Research_CAP_Ballista > 0;
			case 43:
				return GameEngine.Instance.Village == null || GameEngine.Instance.Village.m_parishCapitalResearchData == null || GameEngine.Instance.Village.m_parishCapitalResearchData.Research_CAP_Tunnellors > 0;
			case 44:
				return GameEngine.Instance.Village == null || GameEngine.Instance.Village.m_parishCapitalResearchData == null || GameEngine.Instance.Village.m_parishCapitalResearchData.Research_Leadership > 0;
			default:
				switch (pieceType)
				{
				case 70:
					return true;
				case 71:
					return true;
				case 72:
					return true;
				case 73:
					return true;
				case 74:
					break;
				case 75:
					if (research_Defences >= 5)
					{
						return true;
					}
					break;
				default:
					if (pieceType == 85)
					{
						if (researchDataForCurrentVillage.Research_Captains > 0)
						{
							return true;
						}
					}
					break;
				}
				break;
			}
			return false;
		}

		// Token: 0x06000AB2 RID: 2738 RVA: 0x000D6458 File Offset: 0x000D4658
		public void init()
		{
			this.controlBlockOverlay.Size = base.Size;
			this.controlBlockOverlay.Visible = false;
			int selectedMenuVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
			if (GameEngine.Instance.World.isCapital(selectedMenuVillage) && GameEngine.Instance.World.isUserRelatedVillage(selectedMenuVillage))
			{
				this.castlePlaceBackgroundArea.Visible = false;
			}
			else
			{
				this.castlePlaceBackgroundArea.Visible = true;
			}
			this.stopDeleting();
			this.targetCastlePlaceHeight = 0;
			this.currentCastlePlaceHeight = 1;
			this.setCastlePlaceTab(-1);
			this.setPlaceSize(1);
			this.setReinforcementsMode(false);
		}

		// Token: 0x06000AB3 RID: 2739 RVA: 0x000D64F4 File Offset: 0x000D46F4
		public void Run()
		{
			this.updateCastleCompleteTime();
			this.CastlePanelUpdate();
			this.alphaPulse += 20;
			if (this.alphaPulse > 511)
			{
				this.alphaPulse -= 511;
			}
			int num = this.alphaPulse;
			if (num > 255)
			{
				num = 511 - num;
			}
			if (!this.overCommitButton)
			{
				this.commitBuildCommitButton.Alpha = (float)num / 255f;
				this.commitBuildCommitButton.invalidate();
			}
			else
			{
				this.commitBuildCommitButton.Alpha = 1f;
				this.commitBuildCommitButton.invalidate();
			}
			if (GameEngine.Instance.World.WorldEnded)
			{
				this.commitBuildCommitButton.Visible = false;
				return;
			}
			this.commitBuildCommitButton.Visible = true;
		}

		// Token: 0x06000AB4 RID: 2740 RVA: 0x000D65C0 File Offset: 0x000D47C0
		private void CastlePanelUpdate()
		{
			bool flag = false;
			if (this.commitBuildPanelImage.Visible)
			{
				if (GameEngine.Instance.Castle != null && !GameEngine.Instance.Castle.InBuilderMode && !GameEngine.Instance.Castle.InTroopPlacerMode)
				{
					CastleMapPanel.commitButtonVisible = false;
					this.commitBuildPanelImage.Visible = false;
					this.utilAdvancedButton.Enabled = true;
					flag = true;
				}
				this.updateCommitValues();
			}
			if (this.currentCastlePlaceHeight != this.targetCastlePlaceHeight)
			{
				if (this.currentCastlePlaceHeight < this.targetCastlePlaceHeight)
				{
					this.currentCastlePlaceHeight += 50;
					if (this.currentCastlePlaceHeight > this.targetCastlePlaceHeight)
					{
						this.currentCastlePlaceHeight = this.targetCastlePlaceHeight;
					}
				}
				else
				{
					this.currentCastlePlaceHeight -= 50;
					if (this.currentCastlePlaceHeight <= this.targetCastlePlaceHeight)
					{
						this.currentCastlePlaceHeight = this.targetCastlePlaceHeight;
						this.setCastlePlaceTab(-1);
					}
				}
				this.castlePlacePanelImage.Y = 25 - (422 - this.currentCastlePlaceHeight);
				this.castlePlacePanelImage.ClipRect = new Rectangle(0, 422 - this.currentCastlePlaceHeight, this.castlePlacePanelImage.Width, this.currentCastlePlaceHeight);
				flag = true;
				float num = (float)this.currentCastlePlaceHeight / 422f * 2f - 1f;
				if (num < 0f)
				{
					num = 0f;
				}
				this.castlePlacePanelFaderImage.Alpha = 1f - num;
			}
			if (this.currentCastlePlaceHeight == 0)
			{
				this.castlePlacePanelImage.Visible = false;
			}
			else
			{
				this.castlePlacePanelImage.Visible = true;
			}
			int y = this.calcDeleteBarYPos();
			this.commitBuildPanelImage.Y = y;
			int num2 = this.calcUtilBarYPos();
			if (this.lastUtilYpos != num2)
			{
				flag = true;
			}
			this.lastUtilYpos = num2;
			this.utilHeaderPanelImage.Y = num2;
			if (this.currentUtilHeight != this.targetUtilHeight || flag)
			{
				if (this.currentUtilHeight < this.targetUtilHeight)
				{
					this.currentUtilHeight += 50;
					if (this.currentUtilHeight > this.targetUtilHeight)
					{
						this.currentUtilHeight = this.targetUtilHeight;
					}
				}
				else
				{
					this.currentUtilHeight -= 50;
					if (this.currentUtilHeight <= this.targetUtilHeight)
					{
						this.currentUtilHeight = this.targetUtilHeight;
					}
				}
				this.utilPanelImage.Y = 25 - (366 - this.currentUtilHeight) + num2;
				this.utilPanelImage.ClipRect = new Rectangle(0, 366 - this.currentUtilHeight, this.utilPanelImage.Width, this.currentUtilHeight);
				flag = true;
				float num3 = (float)this.currentUtilHeight / 366f * 2f - 1f;
				if (num3 < 0f)
				{
					num3 = 0f;
				}
				this.utilPanelFaderImage.Alpha = 1f - num3;
			}
			if (this.currentUtilHeight == 0 || (GameEngine.Instance.Castle != null && GameEngine.Instance.Castle.InTroopPlacerMode && !CastleMap.CreateMode))
			{
				this.utilPanelImage.Visible = false;
			}
			else
			{
				this.utilPanelImage.Visible = true;
			}
			if (flag)
			{
				base.Invalidate();
			}
		}

		// Token: 0x06000AB5 RID: 2741 RVA: 0x000D68DC File Offset: 0x000D4ADC
		private void updateCastleCompleteTime()
		{
			if (GameEngine.Instance.Castle != null && !CastleMap.CreateMode)
			{
				this.utilHeaderPanelImage.Visible = !GameEngine.Instance.Castle.InTroopPlacerMode;
			}
			if (this.m_castledCompleted)
			{
				this.utilHeaderLabel1.Visible = false;
				this.utilHeaderLabel3.Visible = true;
				this.utilHeaderLabel2.Visible = false;
				return;
			}
			this.utilHeaderLabel1.Visible = true;
			this.utilHeaderLabel3.Visible = false;
			this.utilHeaderLabel2.Visible = true;
			TimeSpan timeSpan = this.m_castleCompletTime - CastleMap.getCurrentServerTime();
			this.utilHeaderLabel2.Text = VillageMap.createBuildTimeString((int)timeSpan.TotalSeconds);
		}

		// Token: 0x06000AB6 RID: 2742 RVA: 0x000D6994 File Offset: 0x000D4B94
		public void setCastleStats(int numGuardHouseSpaces, int numPlacedArchers, int numPlacedPeasants, int numPlacedPikemen, int numPlacedSwordsmen, DateTime castleComplete, bool castleCompleted, int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numPots, int numSmelterPlaces, bool castleDamaged, int numPlacedReinforceArchers, int numPlacedReinforcePeasants, int numPlacedReinforcePikemen, int numPlacedReinforceSwordsmen, int numReinforcePeasants, int numReinforceArchers, int numReinforcePikemen, int numReinforceSwordsmen, int numAvailableVassalReinforceDefenderPeasants, int numAvailableVassalReinforceDefenderArchers, int numAvailableVassalReinforceDefenderPikemen, int numAvailableVassalReinforceDefenderSwordsmen, int numPlacedVassalReinforceDefenderArchers, int numPlacedVassalReinforceDefenderPeasants, int numPlacedVassalReinforceDefenderPikemen, int numPlacedVassalReinforceDefenderSwordsmen, int numPlacedCaptains, int numCaptains)
		{
			this.m_castleCompletTime = castleComplete;
			this.m_castledCompleted = castleCompleted;
			this.updateCastleCompleteTime();
			if (CastleMap.CreateMode)
			{
				numPeasants = 1000;
				numArchers = 1000;
				numPikemen = 1000;
				numSwordsmen = 1000;
				numGuardHouseSpaces = 10000;
				this.saveButton.Visible = true;
				this.loadButton.Visible = true;
			}
			else
			{
				this.saveButton.Visible = false;
				this.loadButton.Visible = false;
			}
			if (castleDamaged && !GameEngine.Instance.World.WorldEnded)
			{
				int selectedMenuVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
				if (GameEngine.Instance.World.isCapital(selectedMenuVillage) && !GameEngine.Instance.World.isUserVillage(selectedMenuVillage))
				{
					this.utilRepairButton.Enabled = false;
				}
				else
				{
					this.utilRepairButton.Enabled = true;
				}
			}
			else
			{
				this.utilRepairButton.Enabled = false;
			}
			if (castleCompleted || GameEngine.Instance.World.WorldEnded)
			{
				this.utilDeleteConstructingButton.Enabled = false;
			}
			else
			{
				int selectedMenuVillage2 = InterfaceMgr.Instance.getSelectedMenuVillage();
				if (GameEngine.Instance.World.isCapital(selectedMenuVillage2) && !GameEngine.Instance.World.isUserVillage(selectedMenuVillage2))
				{
					this.utilDeleteConstructingButton.Enabled = false;
				}
				else if (GameEngine.Instance.Castle != null && GameEngine.Instance.Castle.isInDeleteConstructing())
				{
					this.utilDeleteConstructingButton.Enabled = false;
				}
				else
				{
					this.utilDeleteConstructingButton.Enabled = true;
				}
			}
			NumberFormatInfo nfi = GameEngine.NFI;
			int num = numPlacedArchers + numPlacedPeasants + numPlacedPikemen + numPlacedSwordsmen + numPlacedCaptains;
			num += numPlacedReinforceArchers + numPlacedReinforcePeasants + numPlacedReinforcePikemen + numPlacedReinforceSwordsmen;
			num += numPlacedVassalReinforceDefenderArchers + numPlacedVassalReinforceDefenderPeasants + numPlacedVassalReinforceDefenderPikemen + numPlacedVassalReinforceDefenderSwordsmen;
			int num2 = numGuardHouseSpaces - num;
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (!this.placingReinforcements)
			{
				this.castlePlacePeasantLabel.Text = Math.Min(numPeasants, num2).ToString("N", nfi);
				this.castlePlaceArcherLabel.Text = Math.Min(numArchers, num2).ToString("N", nfi);
				this.castlePlacePikemanLabel.Text = Math.Min(numPikemen, num2).ToString("N", nfi);
				this.castlePlaceSwordsmanLabel.Text = Math.Min(numSwordsmen, num2).ToString("N", nfi);
				if (!CastleMap.CreateMode)
				{
					this.castlePlaceWolfLabel.Text = Math.Min(numCaptains, num2).ToString("N", nfi);
				}
				if (numPeasants == 0 || num >= numGuardHouseSpaces)
				{
					this.castlePlacePeasantButton.Enabled = false;
				}
				else
				{
					this.castlePlacePeasantButton.Enabled = true;
				}
				if (numArchers == 0 || num >= numGuardHouseSpaces)
				{
					this.castlePlaceArcherButton.Enabled = false;
				}
				else
				{
					this.castlePlaceArcherButton.Enabled = true;
				}
				if (numPikemen == 0 || num >= numGuardHouseSpaces)
				{
					this.castlePlacePikemanButton.Enabled = false;
				}
				else
				{
					this.castlePlacePikemanButton.Enabled = true;
				}
				if (numSwordsmen == 0 || num >= numGuardHouseSpaces)
				{
					this.castlePlaceSwordsmanButton.Enabled = false;
				}
				else
				{
					this.castlePlaceSwordsmanButton.Enabled = true;
				}
				if (!CastleMap.CreateMode)
				{
					if (numCaptains == 0 || num >= numGuardHouseSpaces)
					{
						this.castlePlaceWolfButton.Enabled = false;
					}
					else
					{
						this.castlePlaceWolfButton.Enabled = true;
					}
				}
			}
			else
			{
				this.castlePlacePeasantLabel.Text = Math.Max(0, Math.Min(numReinforcePeasants + numAvailableVassalReinforceDefenderPeasants - numPlacedReinforcePeasants, num2)).ToString("N", nfi);
				this.castlePlaceArcherLabel.Text = Math.Max(0, Math.Min(numReinforceArchers + numAvailableVassalReinforceDefenderArchers - numPlacedReinforceArchers, num2)).ToString("N", nfi);
				this.castlePlacePikemanLabel.Text = Math.Max(0, Math.Min(numReinforcePikemen + numAvailableVassalReinforceDefenderPikemen - numPlacedReinforcePikemen, num2)).ToString("N", nfi);
				this.castlePlaceSwordsmanLabel.Text = Math.Max(0, Math.Min(numReinforceSwordsmen + numAvailableVassalReinforceDefenderSwordsmen - numPlacedReinforceSwordsmen, num2)).ToString("N", nfi);
				if (!CastleMap.CreateMode)
				{
					this.castlePlaceWolfLabel.Text = "0";
					this.castlePlaceWolfButton.Enabled = false;
				}
				if (numReinforcePeasants + numAvailableVassalReinforceDefenderPeasants - numPlacedReinforcePeasants <= 0 || num >= numGuardHouseSpaces)
				{
					this.castlePlacePeasantButton.Enabled = false;
				}
				else
				{
					this.castlePlacePeasantButton.Enabled = true;
				}
				if (numReinforceArchers + numAvailableVassalReinforceDefenderArchers - numPlacedReinforceArchers <= 0 || num >= numGuardHouseSpaces)
				{
					this.castlePlaceArcherButton.Enabled = false;
				}
				else
				{
					this.castlePlaceArcherButton.Enabled = true;
				}
				if (numReinforcePikemen + numAvailableVassalReinforceDefenderPikemen - numPlacedReinforcePikemen <= 0 || num >= numGuardHouseSpaces)
				{
					this.castlePlacePikemanButton.Enabled = false;
				}
				else
				{
					this.castlePlacePikemanButton.Enabled = true;
				}
				if (numReinforceSwordsmen + numAvailableVassalReinforceDefenderSwordsmen - numPlacedReinforceSwordsmen <= 0 || num >= numGuardHouseSpaces)
				{
					this.castlePlaceSwordsmanButton.Enabled = false;
				}
				else
				{
					this.castlePlaceSwordsmanButton.Enabled = true;
				}
			}
			if (num >= numGuardHouseSpaces)
			{
				this.castlePlaceGuardhouseLabel.Color = global::ARGBColors.Red;
			}
			else
			{
				this.castlePlaceGuardhouseLabel.Color = global::ARGBColors.Black;
			}
			if (!CastleMap.CreateMode)
			{
				this.castlePlaceGuardhouseLabel.Text = string.Concat(new string[]
				{
					SK.Text("CASTLEMAP_GUARD_HOUSE_CAPACITY", "Guard House Capacity"),
					" ",
					num.ToString("N", nfi),
					"/",
					numGuardHouseSpaces.ToString("N", nfi)
				});
				return;
			}
			this.castlePlaceGuardhouseLabel.Text = CastleMap.Builder_MapX.ToString() + ", " + CastleMap.Builder_MapY.ToString();
		}

		// Token: 0x06000AB7 RID: 2743 RVA: 0x000D6EF8 File Offset: 0x000D50F8
		public void initDeleteBar()
		{
			int y = this.calcDeleteBarYPos();
			this.deleteHeaderButton.ImageNorm = GFXLibrary.r_building_miltary_deletemode_off_normal;
			this.deleteHeaderButton.ImageOver = GFXLibrary.r_building_miltary_deletemode_off_over;
			this.deleteHeaderButton.Position = new Point(0, y);
			this.deleteHeaderButton.Text.Text = SK.Text("CastleMapPanel_Delete_Off", "Delete: Off");
			this.deleteHeaderButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.deleteHeaderButton.Text.Position = new Point(75, -6);
			this.deleteHeaderButton.Text.Size = new Size(this.deleteHeaderButton.Width - 75, this.deleteHeaderButton.Height);
			this.deleteHeaderButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.deleteHeaderButton.TextYOffset = 0;
			this.deleteHeaderButton.Text.Color = global::ARGBColors.Black;
			this.deleteHeaderButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castleElementDeleteToggle), "CastleMapPanel_toggle_delete");
			this.castlePlaceBackgroundArea.addControl(this.deleteHeaderButton);
		}

		// Token: 0x06000AB8 RID: 2744 RVA: 0x000D7030 File Offset: 0x000D5230
		private int calcDeleteBarYPos()
		{
			int num = 25 + this.currentCastlePlaceHeight;
			if (num < 55)
			{
				num = 55;
			}
			return num;
		}

		// Token: 0x06000AB9 RID: 2745 RVA: 0x000D7050 File Offset: 0x000D5250
		private void castleElementDeleteToggle()
		{
			this.deleteState = !this.deleteState;
			if (this.deleteState)
			{
				if (GameEngine.Instance.Castle != null && this.allowDeleteCallback)
				{
					GameEngine.Instance.Castle.startDeleting();
				}
				this.deleteHeaderButton.CustomTooltipID = 214;
				this.deleteHeaderButton.ImageNorm = GFXLibrary.r_building_miltary_deletemode_on_normal;
				this.deleteHeaderButton.ImageOver = GFXLibrary.r_building_miltary_deletemode_on_over;
				this.deleteHeaderLabel.Text = SK.Text("CastleMapPanel_On", "On");
				this.deleteState = true;
				return;
			}
			if (GameEngine.Instance.Castle != null && this.allowDeleteCallback)
			{
				GameEngine.Instance.Castle.stopPlaceElement();
			}
			this.deleteHeaderButton.CustomTooltipID = 213;
			this.deleteHeaderButton.ImageNorm = GFXLibrary.r_building_miltary_deletemode_off_normal;
			this.deleteHeaderButton.ImageOver = GFXLibrary.r_building_miltary_deletemode_off_over;
			this.deleteHeaderLabel.Text = SK.Text("CastleMapPanel_Off", "Off");
			this.deleteState = false;
		}

		// Token: 0x06000ABA RID: 2746 RVA: 0x0000E0B4 File Offset: 0x0000C2B4
		public void stopDeleting()
		{
			this.allowDeleteCallback = false;
			this.deleteState = true;
			this.castleElementDeleteToggle();
			this.allowDeleteCallback = true;
		}

		// Token: 0x06000ABB RID: 2747 RVA: 0x000D7174 File Offset: 0x000D5374
		public void initUtilBar()
		{
			int num = this.calcUtilBarYPos();
			this.utilPanelImage.Image = GFXLibrary.castlescreen_panelback_A;
			this.utilPanelImage.Position = new Point(0, num + 25);
			this.castlePlaceBackgroundArea.addControl(this.utilPanelImage);
			this.utilHeaderPanelImage.Image = GFXLibrary.r_building_miltary_castleinfo_normal;
			this.utilHeaderPanelImage.Position = new Point(0, num);
			this.utilHeaderPanelImage.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.utilMouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.utilMouseLeave));
			this.utilHeaderPanelImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.utilClicked));
			this.utilHeaderPanelImage.CustomTooltipID = 215;
			this.castlePlaceBackgroundArea.addControl(this.utilHeaderPanelImage);
			this.utilHeaderLabel1.Text = SK.Text("CastleMapPanel_Completion_In", "Completion In");
			this.utilHeaderLabel1.Color = global::ARGBColors.Black;
			this.utilHeaderLabel1.Position = new Point(50, 11);
			this.utilHeaderLabel1.Size = new Size(140, 20);
			this.utilHeaderLabel1.Visible = false;
			this.utilHeaderLabel1.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.utilHeaderLabel1.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.utilHeaderPanelImage.addControl(this.utilHeaderLabel1);
			this.utilHeaderLabel2.Text = "00:00:00";
			this.utilHeaderLabel2.Color = global::ARGBColors.Black;
			this.utilHeaderLabel2.Position = new Point(50, 25);
			this.utilHeaderLabel2.Size = new Size(140, 20);
			this.utilHeaderLabel2.Visible = false;
			this.utilHeaderLabel2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.utilHeaderLabel2.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.utilHeaderPanelImage.addControl(this.utilHeaderLabel2);
			this.utilHeaderLabel3.Text = SK.Text("CastleMapPanel_Castle_Completed", "Castle Completed");
			this.utilHeaderLabel3.Color = global::ARGBColors.Black;
			this.utilHeaderLabel3.Position = new Point(40, 18);
			this.utilHeaderLabel3.Size = new Size(160, 20);
			this.utilHeaderLabel3.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.utilHeaderLabel3.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.utilHeaderPanelImage.addControl(this.utilHeaderLabel3);
			int num2 = 95;
			this.utilRepairLabel.Text = SK.Text("CastleMapPanel_Repair", "Repair");
			this.utilRepairLabel.Color = global::ARGBColors.Black;
			this.utilRepairLabel.Position = new Point(85, num2 + 45);
			this.utilRepairLabel.Size = new Size(110, 20);
			this.utilRepairLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.utilRepairLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.utilPanelImage.addControl(this.utilRepairLabel);
			this.utilRepairButton.ImageNorm = GFXLibrary.r_building_miltary_repair_normal;
			this.utilRepairButton.ImageOver = GFXLibrary.r_building_miltary_repair_over;
			this.utilRepairButton.ImageClick = GFXLibrary.r_building_miltary_repair_pushed;
			this.utilRepairButton.Position = new Point(15, num2 + 32);
			this.utilRepairButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.utilRepairClick), "CastleMapPanel_repair");
			this.utilRepairButton.CustomTooltipID = 217;
			this.utilPanelImage.addControl(this.utilRepairButton);
			this.utilDeleteConstructingLabel.Text = SK.Text("CastleMapPanel_Delete_Constructing", "Delete Constructing");
			this.utilDeleteConstructingLabel.Color = global::ARGBColors.Black;
			this.utilDeleteConstructingLabel.Position = new Point(85, num2 + 45 + 50 - 20);
			this.utilDeleteConstructingLabel.Size = new Size(110, 40);
			this.utilDeleteConstructingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.utilDeleteConstructingLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.utilPanelImage.addControl(this.utilDeleteConstructingLabel);
			this.utilDeleteConstructingButton.ImageNorm = GFXLibrary.r_building_miltary_repair_normal;
			this.utilDeleteConstructingButton.ImageOver = GFXLibrary.r_building_miltary_repair_over;
			this.utilDeleteConstructingButton.ImageClick = GFXLibrary.r_building_miltary_repair_pushed;
			this.utilDeleteConstructingButton.Position = new Point(15, num2 + 32 + 50);
			this.utilDeleteConstructingButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.utilDeleteConstructingClick), "CastleMapPanel_delete_constructing");
			this.utilDeleteConstructingButton.CustomTooltipID = 218;
			this.utilPanelImage.addControl(this.utilDeleteConstructingButton);
			this.utilAdvancedButton.ImageNorm = GFXLibrary.int_but_delete_norm;
			this.utilAdvancedButton.ImageOver = GFXLibrary.int_but_delete_over;
			this.utilAdvancedButton.Position = new Point(21, num2 + 32 + 100);
			this.utilAdvancedButton.Text.Text = SK.Text("CastleMapPanel_Delete_Advanced", "Advanced Options");
			this.utilAdvancedButton.TextYOffset = -1;
			this.utilAdvancedButton.Text.Color = global::ARGBColors.Black;
			this.utilAdvancedButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.utilAdvancedClick), "CastleMapPanel_advanced_options");
			this.utilAdvancedButton.Enabled = true;
			this.utilPanelImage.addControl(this.utilAdvancedButton);
			this.utilPanelFaderImage.Image = GFXLibrary.castlescreen_panelback_A;
			this.utilPanelFaderImage.Position = new Point(0, 0);
			this.utilPanelFaderImage.Alpha = 0f;
			this.loadButton.ImageNorm = GFXLibrary.int_but_delete_norm;
			this.loadButton.ImageOver = GFXLibrary.int_but_delete_over;
			this.loadButton.Position = new Point(42, num2 + 32 + 30);
			this.loadButton.Text.Text = "Load";
			this.loadButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.loadButton.TextYOffset = 1;
			this.loadButton.Visible = false;
			this.loadButton.Text.Color = global::ARGBColors.Black;
			this.loadButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.DEBUG_load));
			this.utilPanelImage.addControl(this.loadButton);
			this.saveButton.ImageNorm = GFXLibrary.int_but_delete_norm;
			this.saveButton.ImageOver = GFXLibrary.int_but_delete_over;
			this.saveButton.Position = new Point(42, num2 + 32 + 60);
			this.saveButton.Text.Text = "Save";
			this.saveButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.saveButton.TextYOffset = 1;
			this.saveButton.Visible = false;
			this.saveButton.Text.Color = global::ARGBColors.Black;
			this.saveButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.DEBUG_save));
			this.utilPanelImage.addControl(this.saveButton);
			this.utilCastlePresetButton.ImageNorm = GFXLibrary.int_but_delete_blue_norm;
			this.utilCastlePresetButton.ImageOver = GFXLibrary.int_but_delete_blue_over;
			this.utilCastlePresetButton.Position = new Point(21, num2 + 32 + 140);
			this.utilCastlePresetButton.Text.Text = SK.Text("CastleMapPanel_Stored_Castle", "Stored Castles");
			this.utilCastlePresetButton.TextYOffset = -1;
			this.utilCastlePresetButton.Text.Color = global::ARGBColors.Black;
			this.utilCastlePresetButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePresetClick), "CastleMapPanel_castle_presets");
			this.utilAdvancedButton.Enabled = true;
			this.utilPanelImage.addControl(this.utilCastlePresetButton);
			this.utilTroopPresetButton.ImageNorm = GFXLibrary.int_but_delete_blue_norm;
			this.utilTroopPresetButton.ImageOver = GFXLibrary.int_but_delete_blue_over;
			this.utilTroopPresetButton.Position = new Point(21, num2 + 32 + 180);
			this.utilTroopPresetButton.Text.Text = SK.Text("CastleMapPanel_Stored_Formations", "Stored Troops");
			this.utilTroopPresetButton.TextYOffset = -1;
			this.utilTroopPresetButton.Text.Color = global::ARGBColors.Black;
			this.utilTroopPresetButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.troopPresetClick), "CastleMapPanel_troop_presets");
			this.utilPanelImage.addControl(this.utilTroopPresetButton);
		}

		// Token: 0x06000ABC RID: 2748 RVA: 0x000D7A44 File Offset: 0x000D5C44
		private int calcUtilBarYPos()
		{
			int num = this.calcDeleteBarYPos();
			if (this.commitBuildPanelImage.Visible)
			{
				num += 120;
			}
			return num;
		}

		// Token: 0x06000ABD RID: 2749 RVA: 0x000D7A6C File Offset: 0x000D5C6C
		private void utilClicked()
		{
			this.closeCastlePlacePanel();
			if (this.currentUtilHeight == 0)
			{
				GameEngine.Instance.playInterfaceSound("CastleMapPanel_util_open");
				this.utilHeaderPanelImage.CustomTooltipID = 216;
				this.targetUtilHeight = 271;
				return;
			}
			if (this.currentUtilHeight == 271)
			{
				GameEngine.Instance.playInterfaceSound("CastleMapPanel_util_close");
				this.closeutilPanel();
			}
		}

		// Token: 0x06000ABE RID: 2750 RVA: 0x0000E0D1 File Offset: 0x0000C2D1
		public void closeutilPanel()
		{
			this.utilHeaderPanelImage.CustomTooltipID = 215;
			this.targetUtilHeight = 0;
		}

		// Token: 0x06000ABF RID: 2751 RVA: 0x0000E0EA File Offset: 0x0000C2EA
		private void utilMouseOver()
		{
			this.utilHeaderPanelImage.Image = GFXLibrary.r_building_miltary_castleinfo_over;
		}

		// Token: 0x06000AC0 RID: 2752 RVA: 0x0000E101 File Offset: 0x0000C301
		private void utilMouseLeave()
		{
			this.utilHeaderPanelImage.Image = GFXLibrary.r_building_miltary_castleinfo_normal;
		}

		// Token: 0x06000AC1 RID: 2753 RVA: 0x0000E118 File Offset: 0x0000C318
		private void utilRepairClick()
		{
			if (GameEngine.Instance.Castle != null)
			{
				GameEngine.Instance.Castle.autoRepairCastle();
				this.utilRepairButton.Enabled = false;
			}
		}

		// Token: 0x06000AC2 RID: 2754 RVA: 0x000D7AD4 File Offset: 0x000D5CD4
		private void utilViewModeClick()
		{
			if (GameEngine.Instance.Castle != null)
			{
				GameEngine.Instance.Castle.toggleHeight();
				if (CastleMap.displayCollapsed)
				{
					GameEngine.Instance.playInterfaceSound("CastleMapPanel_toggle_height_low");
					this.utilViewModeButton.CustomTooltipID = 211;
					return;
				}
				GameEngine.Instance.playInterfaceSound("CastleMapPanel_toggle_height_high");
				this.utilViewModeButton.CustomTooltipID = 212;
			}
		}

		// Token: 0x06000AC3 RID: 2755 RVA: 0x000D7B44 File Offset: 0x000D5D44
		private void utilDeleteConstructingClick()
		{
			if (GameEngine.Instance.Castle != null)
			{
				DialogResult dialogResult = MyMessageBox.Show(SK.Text("FORUMS_Are_You_Sure", "Are you sure?"), SK.Text("CastleMapPanel_Delete_All_Constructing", "Delete All Constructing?"), MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					this.utilDeleteConstructing();
				}
			}
		}

		// Token: 0x06000AC4 RID: 2756 RVA: 0x0000E141 File Offset: 0x0000C341
		private void utilDeleteConstructing()
		{
			this.utilDeleteConstructingButton.Enabled = false;
			GameEngine.Instance.Castle.deleteConstructingElements();
			this.controlBlockOverlay.Visible = true;
		}

		// Token: 0x06000AC5 RID: 2757 RVA: 0x0000E16A File Offset: 0x0000C36A
		private void utilAdvancedClick()
		{
			if (GameEngine.Instance.Castle != null)
			{
				InterfaceMgr.Instance.openAdvancedCastleOptionsPopup(true);
			}
		}

		// Token: 0x06000AC6 RID: 2758 RVA: 0x000D7B8C File Offset: 0x000D5D8C
		private void initPresetButtons()
		{
			this.utilCastlePresetButton.ImageNorm = GFXLibrary.int_but_delete_norm;
			this.utilCastlePresetButton.ImageOver = GFXLibrary.int_but_delete_over;
			this.utilCastlePresetButton.Position = new Point(0, 605);
			this.utilCastlePresetButton.Size = new Size(196, this.utilCastlePresetButton.ImageNorm.Height);
			this.utilCastlePresetButton.Text.Text = SK.Text("CastleMapPanel_Castle_Preset", "Castle Presets");
			this.utilCastlePresetButton.Text.Size = this.utilCastlePresetButton.Size;
			this.utilCastlePresetButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.utilCastlePresetButton.TextYOffset = 0;
			this.utilCastlePresetButton.Text.Color = global::ARGBColors.Black;
			this.utilCastlePresetButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castlePresetClick), "CastleMapPanel_castle_presets");
			base.addControl(this.utilCastlePresetButton);
			this.utilTroopPresetButton.ImageNorm = GFXLibrary.int_but_delete_norm;
			this.utilTroopPresetButton.ImageOver = GFXLibrary.int_but_delete_over;
			this.utilTroopPresetButton.Position = new Point(0, 635);
			this.utilTroopPresetButton.Size = new Size(196, this.utilTroopPresetButton.ImageNorm.Height);
			this.utilTroopPresetButton.Text.Text = SK.Text("CastleMapPanel_Troop_Preset", "Troop Presets");
			this.utilTroopPresetButton.Text.Size = this.utilTroopPresetButton.Size;
			this.utilTroopPresetButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.utilTroopPresetButton.TextYOffset = 0;
			this.utilTroopPresetButton.Text.Color = global::ARGBColors.Black;
			this.utilTroopPresetButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.troopPresetClick), "CastleMapPanel_troop_presets");
			base.addControl(this.utilTroopPresetButton);
		}

		// Token: 0x06000AC7 RID: 2759 RVA: 0x0000E184 File Offset: 0x0000C384
		private void castlePresetClick()
		{
			InterfaceMgr.Instance.openPresetPopup(PresetType.INFRASTRUCTURE);
		}

		// Token: 0x06000AC8 RID: 2760 RVA: 0x0000E192 File Offset: 0x0000C392
		private void troopPresetClick()
		{
			InterfaceMgr.Instance.openPresetPopup(PresetType.TROOP_DEFEND);
		}

		// Token: 0x06000AC9 RID: 2761 RVA: 0x000D7DAC File Offset: 0x000D5FAC
		public void initSelectionPanel()
		{
			this.castleSelectionBackgroundArea.Position = new Point(0, 0);
			this.castleSelectionBackgroundArea.Size = base.Size;
			this.castleSelectionBackgroundArea.Visible = false;
			base.addControl(this.castleSelectionBackgroundArea);
			this.castleSelectionPanelImage.Image = GFXLibrary.r_building_panel_back;
			this.castleSelectionPanelImage.Position = new Point(0, 0);
			this.castleSelectionBackgroundArea.addControl(this.castleSelectionPanelImage);
			this.closeButton.ImageNorm = GFXLibrary.int_button_close_normal;
			this.closeButton.ImageOver = GFXLibrary.int_button_close_over;
			this.closeButton.ImageClick = GFXLibrary.int_button_close_in;
			this.closeButton.Position = new Point(153, 6);
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "CastleMapPanel_selection_close");
			this.castleSelectionBackgroundArea.addControl(this.closeButton);
			this.castleSelectionInset1Image.Image = GFXLibrary.castlescreen_panel_halfinset_def_select;
			this.castleSelectionInset1Image.Position = new Point(3, 28);
			this.castleSelectionPanelImage.addControl(this.castleSelectionInset1Image);
			this.castleSelectionPeasantImage.Image = GFXLibrary.r_building_miltary_peasent;
			this.castleSelectionPeasantImage.Position = new Point(20, -20);
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
			this.castleSelectionPeasantButton.ImageNorm = GFXLibrary.castlescreen_stance_def_normal;
			this.castleSelectionPeasantButton.ImageOver = GFXLibrary.castlescreen_stance_def_over;
			this.castleSelectionPeasantButton.Position = new Point(5, 12);
			this.castleSelectionPeasantButton.Data = 70;
			this.castleSelectionPeasantButton.CustomTooltipID = 222;
			this.castleSelectionPeasantButton.CustomTooltipData = 70;
			this.castleSelectionPeasantButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.aggressiveStateClick), "CastleMapPanel_toggle_aggressive_peasant");
			this.castleSelectionInset1Image.addControl(this.castleSelectionPeasantButton);
			this.castleSelectionPeasantDeleteButton.ImageNorm = GFXLibrary.castlescreen_sendback_normal;
			this.castleSelectionPeasantDeleteButton.ImageOver = GFXLibrary.castlescreen_sendback_over;
			this.castleSelectionPeasantDeleteButton.Position = new Point(135, 13);
			this.castleSelectionPeasantDeleteButton.Data = 70;
			this.castleSelectionPeasantDeleteButton.CustomTooltipID = 221;
			this.castleSelectionPeasantDeleteButton.CustomTooltipData = 70;
			this.castleSelectionPeasantDeleteButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.troopDeleteClick), "CastleMapPanel_delete_peasants");
			this.castleSelectionInset1Image.addControl(this.castleSelectionPeasantDeleteButton);
			this.castleSelectionInset2Image.Image = GFXLibrary.castlescreen_panel_halfinset_def_select;
			this.castleSelectionInset2Image.Position = new Point(3, 108);
			this.castleSelectionPanelImage.addControl(this.castleSelectionInset2Image);
			this.castleSelectionArcherImage.Image = GFXLibrary.r_building_miltary_archer;
			this.castleSelectionArcherImage.Position = new Point(20, -20);
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
			this.castleSelectionArcherButton.ImageNorm = GFXLibrary.castlescreen_stance_def_normal;
			this.castleSelectionArcherButton.ImageOver = GFXLibrary.castlescreen_stance_def_over;
			this.castleSelectionArcherButton.Position = new Point(5, 12);
			this.castleSelectionArcherButton.Data = 72;
			this.castleSelectionArcherButton.Enabled = false;
			this.castleSelectionArcherButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.aggressiveStateClick), "CastleMapPanel_toggle_aggressive_archers");
			this.castleSelectionInset2Image.addControl(this.castleSelectionArcherButton);
			this.castleSelectionArcherDeleteButton.ImageNorm = GFXLibrary.castlescreen_sendback_normal;
			this.castleSelectionArcherDeleteButton.ImageOver = GFXLibrary.castlescreen_sendback_over;
			this.castleSelectionArcherDeleteButton.Position = new Point(135, 13);
			this.castleSelectionArcherDeleteButton.Data = 72;
			this.castleSelectionArcherDeleteButton.CustomTooltipID = 221;
			this.castleSelectionArcherDeleteButton.CustomTooltipData = 72;
			this.castleSelectionArcherDeleteButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.troopDeleteClick), "CastleMapPanel_delete_archers");
			this.castleSelectionInset2Image.addControl(this.castleSelectionArcherDeleteButton);
			this.castleSelectionInset3Image.Image = GFXLibrary.castlescreen_panel_halfinset_def_select;
			this.castleSelectionInset3Image.Position = new Point(3, 188);
			this.castleSelectionPanelImage.addControl(this.castleSelectionInset3Image);
			this.castleSelectionPikemanImage.Image = GFXLibrary.r_building_miltary_pikemen;
			this.castleSelectionPikemanImage.Position = new Point(20, -20);
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
			this.castleSelectionPikemanButton.ImageNorm = GFXLibrary.castlescreen_stance_def_normal;
			this.castleSelectionPikemanButton.ImageOver = GFXLibrary.castlescreen_stance_def_over;
			this.castleSelectionPikemanButton.Position = new Point(5, 12);
			this.castleSelectionPikemanButton.Data = 73;
			this.castleSelectionPikemanButton.CustomTooltipID = 222;
			this.castleSelectionPikemanButton.CustomTooltipData = 73;
			this.castleSelectionPikemanButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.aggressiveStateClick), "CastleMapPanel_toggle_aggressive_pikemen");
			this.castleSelectionInset3Image.addControl(this.castleSelectionPikemanButton);
			this.castleSelectionPikemanDeleteButton.ImageNorm = GFXLibrary.castlescreen_sendback_normal;
			this.castleSelectionPikemanDeleteButton.ImageOver = GFXLibrary.castlescreen_sendback_over;
			this.castleSelectionPikemanDeleteButton.Position = new Point(135, 13);
			this.castleSelectionPikemanDeleteButton.Data = 73;
			this.castleSelectionPikemanDeleteButton.CustomTooltipID = 221;
			this.castleSelectionPikemanDeleteButton.CustomTooltipData = 73;
			this.castleSelectionPikemanDeleteButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.troopDeleteClick), "CastleMapPanel_delete_pikemen");
			this.castleSelectionInset3Image.addControl(this.castleSelectionPikemanDeleteButton);
			this.castleSelectionInset4Image.Image = GFXLibrary.castlescreen_panel_halfinset_def_select;
			this.castleSelectionInset4Image.Position = new Point(3, 268);
			this.castleSelectionPanelImage.addControl(this.castleSelectionInset4Image);
			this.castleSelectionSwordsmanImage.Image = GFXLibrary.r_building_miltary_swordsman;
			this.castleSelectionSwordsmanImage.Position = new Point(20, -20);
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
			this.castleSelectionSwordsmanButton.ImageNorm = GFXLibrary.castlescreen_stance_def_normal;
			this.castleSelectionSwordsmanButton.ImageOver = GFXLibrary.castlescreen_stance_def_over;
			this.castleSelectionSwordsmanButton.Position = new Point(5, 12);
			this.castleSelectionSwordsmanButton.Data = 71;
			this.castleSelectionSwordsmanButton.CustomTooltipID = 222;
			this.castleSelectionSwordsmanButton.CustomTooltipData = 71;
			this.castleSelectionSwordsmanButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.aggressiveStateClick), "CastleMapPanel_toggle_aggressive_swordsmen");
			this.castleSelectionInset4Image.addControl(this.castleSelectionSwordsmanButton);
			this.castleSelectionSwordsmanDeleteButton.ImageNorm = GFXLibrary.castlescreen_sendback_normal;
			this.castleSelectionSwordsmanDeleteButton.ImageOver = GFXLibrary.castlescreen_sendback_over;
			this.castleSelectionSwordsmanDeleteButton.Position = new Point(135, 13);
			this.castleSelectionSwordsmanDeleteButton.Data = 71;
			this.castleSelectionSwordsmanDeleteButton.CustomTooltipID = 221;
			this.castleSelectionSwordsmanDeleteButton.CustomTooltipData = 71;
			this.castleSelectionSwordsmanDeleteButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.troopDeleteClick), "CastleMapPanel_delete_swordsmen");
			this.castleSelectionInset4Image.addControl(this.castleSelectionSwordsmanDeleteButton);
			this.castleSelectionInset5Image.Image = GFXLibrary.castlescreen_panel_halfinset_def_select;
			this.castleSelectionInset5Image.Position = new Point(3, 348);
			this.castleSelectionPanelImage.addControl(this.castleSelectionInset5Image);
			this.castleSelectionCaptainImage.Image = GFXLibrary.r_building_miltary_captain_normal;
			this.castleSelectionCaptainImage.Position = new Point(20, -20);
			this.castleSelectionInset5Image.addControl(this.castleSelectionCaptainImage);
			this.castleSelectionCaptainInset.Image = GFXLibrary.castlescreen_unit_capsule;
			this.castleSelectionCaptainInset.Position = new Point(70, 60);
			this.castleSelectionCaptainImage.addControl(this.castleSelectionCaptainInset);
			this.castleSelectionCaptainLabel.Text = "0";
			this.castleSelectionCaptainLabel.Color = Color.FromArgb(254, 248, 229);
			this.castleSelectionCaptainLabel.Position = new Point(0, 0);
			this.castleSelectionCaptainLabel.Size = this.castleSelectionCaptainInset.Size;
			this.castleSelectionCaptainLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.castleSelectionCaptainInset.addControl(this.castleSelectionCaptainLabel);
			this.castleSelectionCaptainButton.ImageNorm = GFXLibrary.castlescreen_stance_def_normal;
			this.castleSelectionCaptainButton.ImageOver = GFXLibrary.castlescreen_stance_def_over;
			this.castleSelectionCaptainButton.Position = new Point(5, 12);
			this.castleSelectionCaptainButton.Data = 85;
			this.castleSelectionCaptainButton.Enabled = false;
			this.castleSelectionCaptainButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.aggressiveStateClick), "CastleMapPanel_toggle_aggressive_captains");
			this.castleSelectionInset5Image.addControl(this.castleSelectionCaptainButton);
			this.castleSelectionCaptainDeleteButton.ImageNorm = GFXLibrary.castlescreen_sendback_normal;
			this.castleSelectionCaptainDeleteButton.ImageOver = GFXLibrary.castlescreen_sendback_over;
			this.castleSelectionCaptainDeleteButton.Position = new Point(135, 13);
			this.castleSelectionCaptainDeleteButton.Data = 85;
			this.castleSelectionCaptainDeleteButton.CustomTooltipID = 221;
			this.castleSelectionCaptainDeleteButton.CustomTooltipData = 85;
			this.castleSelectionCaptainDeleteButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.troopDeleteClick), "CastleMapPanel_delete_captains");
			this.castleSelectionInset5Image.addControl(this.castleSelectionCaptainDeleteButton);
		}

		// Token: 0x06000ACA RID: 2762 RVA: 0x000D8A18 File Offset: 0x000D6C18
		public void setSelectedTroop(int numPeasants, int peasantsState, int numArchers, int archersState, int numPikemen, int pikemenState, int numSwordsmen, int swordsmenState, int numCaptains, int captainState)
		{
			if (!this.castleSelectionBackgroundArea.Visible || this.sst_lastPeasants != numPeasants || this.sst_lastArchers != numArchers || this.sst_lastPikeman != numPikemen || this.sst_lastSwordsman != numSwordsmen || this.sst_lastCaptains != numCaptains)
			{
				GameEngine.Instance.playInterfaceSound("CastleMapPanel_open_selected_troops_panel");
			}
			this.sst_lastPeasants = numPeasants;
			this.sst_lastArchers = numArchers;
			this.sst_lastPikeman = numPikemen;
			this.sst_lastSwordsman = numSwordsmen;
			this.sst_lastCaptains = numCaptains;
			if (!this.captain_castleSelectionBackgroundArea.Visible)
			{
				base.Invalidate();
			}
			this.castleSelectionBackgroundArea.Visible = true;
			this.castlePlaceBackgroundArea.Visible = false;
			this.castleSelectionPeasantLabel.Text = numPeasants.ToString();
			this.castleSelectionArcherLabel.Text = numArchers.ToString();
			this.castleSelectionPikemanLabel.Text = numPikemen.ToString();
			this.castleSelectionSwordsmanLabel.Text = numSwordsmen.ToString();
			this.castleSelectionCaptainLabel.Text = numCaptains.ToString();
			this.castleSelectionPeasantDeleteButton.Enabled = (numPeasants > 0);
			this.castleSelectionArcherDeleteButton.Enabled = (numArchers > 0);
			this.castleSelectionPikemanDeleteButton.Enabled = (numPikemen > 0);
			this.castleSelectionSwordsmanDeleteButton.Enabled = (numSwordsmen > 0);
			this.castleSelectionCaptainDeleteButton.Enabled = (numCaptains > 0);
			this.castleSelectionPeasantButton.Enabled = (numPeasants > 0);
			this.castleSelectionArcherButton.Enabled = false;
			this.castleSelectionPikemanButton.Enabled = (numPikemen > 0);
			this.castleSelectionSwordsmanButton.Enabled = (numSwordsmen > 0);
			this.castleSelectionCaptainButton.Enabled = false;
			if (peasantsState != 0)
			{
				if (peasantsState != 1)
				{
					this.castleSelectionPeasantButton.ImageNorm = GFXLibrary.castlescreen_stance_mix_normal;
					this.castleSelectionPeasantButton.ImageOver = GFXLibrary.castlescreen_stance_mix_over;
					this.nextPeasantState = false;
				}
				else
				{
					this.castleSelectionPeasantButton.ImageNorm = GFXLibrary.castlescreen_stance_off_normal;
					this.castleSelectionPeasantButton.ImageOver = GFXLibrary.castlescreen_stance_off_over;
					this.nextPeasantState = false;
				}
			}
			else
			{
				this.castleSelectionPeasantButton.ImageNorm = GFXLibrary.castlescreen_stance_def_normal;
				this.castleSelectionPeasantButton.ImageOver = GFXLibrary.castlescreen_stance_def_over;
				this.nextPeasantState = true;
			}
			if (archersState != 0)
			{
				if (archersState != 1)
				{
					this.castleSelectionArcherButton.ImageNorm = GFXLibrary.castlescreen_stance_mix_normal;
					this.castleSelectionArcherButton.ImageOver = GFXLibrary.castlescreen_stance_mix_over;
					this.nextArcherState = false;
				}
				else
				{
					this.castleSelectionArcherButton.ImageNorm = GFXLibrary.castlescreen_stance_off_normal;
					this.castleSelectionArcherButton.ImageOver = GFXLibrary.castlescreen_stance_off_over;
					this.nextArcherState = false;
				}
			}
			else
			{
				this.castleSelectionArcherButton.ImageNorm = GFXLibrary.castlescreen_stance_def_normal;
				this.castleSelectionArcherButton.ImageOver = GFXLibrary.castlescreen_stance_def_over;
				this.nextArcherState = true;
			}
			if (pikemenState != 0)
			{
				if (pikemenState != 1)
				{
					this.castleSelectionPikemanButton.ImageNorm = GFXLibrary.castlescreen_stance_mix_normal;
					this.castleSelectionPikemanButton.ImageOver = GFXLibrary.castlescreen_stance_mix_over;
					this.nextPikemanState = false;
				}
				else
				{
					this.castleSelectionPikemanButton.ImageNorm = GFXLibrary.castlescreen_stance_off_normal;
					this.castleSelectionPikemanButton.ImageOver = GFXLibrary.castlescreen_stance_off_over;
					this.nextPikemanState = false;
				}
			}
			else
			{
				this.castleSelectionPikemanButton.ImageNorm = GFXLibrary.castlescreen_stance_def_normal;
				this.castleSelectionPikemanButton.ImageOver = GFXLibrary.castlescreen_stance_def_over;
				this.nextPikemanState = true;
			}
			if (swordsmenState != 0)
			{
				if (swordsmenState != 1)
				{
					this.castleSelectionSwordsmanButton.ImageNorm = GFXLibrary.castlescreen_stance_mix_normal;
					this.castleSelectionSwordsmanButton.ImageOver = GFXLibrary.castlescreen_stance_mix_over;
					this.nextSwordsmanState = false;
				}
				else
				{
					this.castleSelectionSwordsmanButton.ImageNorm = GFXLibrary.castlescreen_stance_off_normal;
					this.castleSelectionSwordsmanButton.ImageOver = GFXLibrary.castlescreen_stance_off_over;
					this.nextSwordsmanState = false;
				}
			}
			else
			{
				this.castleSelectionSwordsmanButton.ImageNorm = GFXLibrary.castlescreen_stance_def_normal;
				this.castleSelectionSwordsmanButton.ImageOver = GFXLibrary.castlescreen_stance_def_over;
				this.nextSwordsmanState = true;
			}
			if (captainState == 0)
			{
				this.castleSelectionCaptainButton.ImageNorm = GFXLibrary.castlescreen_stance_def_normal;
				this.castleSelectionCaptainButton.ImageOver = GFXLibrary.castlescreen_stance_def_over;
				this.nextCaptainState = true;
				return;
			}
			if (captainState != 1)
			{
				this.castleSelectionCaptainButton.ImageNorm = GFXLibrary.castlescreen_stance_mix_normal;
				this.castleSelectionCaptainButton.ImageOver = GFXLibrary.castlescreen_stance_mix_over;
				this.nextCaptainState = false;
				return;
			}
			this.castleSelectionCaptainButton.ImageNorm = GFXLibrary.castlescreen_stance_off_normal;
			this.castleSelectionCaptainButton.ImageOver = GFXLibrary.castlescreen_stance_off_over;
			this.nextCaptainState = false;
		}

		// Token: 0x06000ACB RID: 2763 RVA: 0x0000E1A0 File Offset: 0x0000C3A0
		public void clearSelectedTroop()
		{
			this.captain_castleSelectionBackgroundArea.Visible = false;
			this.castleSelectionBackgroundArea.Visible = false;
			this.castlePlaceBackgroundArea.Visible = true;
			base.Invalidate();
		}

		// Token: 0x06000ACC RID: 2764 RVA: 0x000D8ED8 File Offset: 0x000D70D8
		private void aggressiveStateClick()
		{
			if (this.OverControl != null)
			{
				CustomSelfDrawPanel.CSDControl overControl = this.OverControl;
				int data = overControl.Data;
				bool state = false;
				switch (data)
				{
				case 70:
					state = this.nextPeasantState;
					break;
				case 71:
					state = this.nextSwordsmanState;
					break;
				case 72:
					state = this.nextArcherState;
					break;
				case 73:
					state = this.nextPikemanState;
					break;
				default:
					if (data == 85)
					{
						state = this.nextCaptainState;
					}
					break;
				}
				GameEngine.Instance.Castle.setTroopAggressiveMode(data, state);
			}
		}

		// Token: 0x06000ACD RID: 2765 RVA: 0x000D8F5C File Offset: 0x000D715C
		private void troopDeleteClick()
		{
			if (this.OverControl != null)
			{
				CustomSelfDrawPanel.CSDControl overControl = this.OverControl;
				int data = overControl.Data;
				GameEngine.Instance.Castle.deleteTroopsFromSelection(data);
			}
		}

		// Token: 0x06000ACE RID: 2766 RVA: 0x0000E1CC File Offset: 0x0000C3CC
		private void closeClick()
		{
			GameEngine.Instance.Castle.clearLasso();
			if (!this.commitBuildPanelImage.Visible)
			{
				GameEngine.Instance.Castle.cancelBuilderMode();
			}
		}

		// Token: 0x06000ACF RID: 2767 RVA: 0x000D8F90 File Offset: 0x000D7190
		public void initSelectionPanel_Captains()
		{
			this.captain_castleSelectionBackgroundArea.Position = new Point(0, 0);
			this.captain_castleSelectionBackgroundArea.Size = base.Size;
			this.captain_castleSelectionBackgroundArea.Visible = false;
			base.addControl(this.captain_castleSelectionBackgroundArea);
			this.captain_castleSelectionPanelImage.Image = GFXLibrary.castlescreen_panelback_A;
			this.captain_castleSelectionPanelImage.Position = new Point(0, 0);
			this.captain_castleSelectionBackgroundArea.addControl(this.captain_castleSelectionPanelImage);
			this.captain_closeButton.ImageNorm = GFXLibrary.int_button_close_normal;
			this.captain_closeButton.ImageOver = GFXLibrary.int_button_close_over;
			this.captain_closeButton.ImageClick = GFXLibrary.int_button_close_in;
			this.captain_closeButton.Position = new Point(153, 6);
			this.captain_closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "CastleMapPanel_captains_close");
			this.captain_castleSelectionBackgroundArea.addControl(this.captain_closeButton);
			this.captain_castleSelectionInset5Image.Image = GFXLibrary.castlescreen_panel_halfinset_def_select;
			this.captain_castleSelectionInset5Image.Position = new Point(3, 28);
			this.captain_castleSelectionPanelImage.addControl(this.captain_castleSelectionInset5Image);
			this.captain_castleSelectionCaptainImage.Image = GFXLibrary.r_building_miltary_captain_normal;
			this.captain_castleSelectionCaptainImage.Position = new Point(20, -20);
			this.captain_castleSelectionInset5Image.addControl(this.captain_castleSelectionCaptainImage);
			this.captain_castleSelectionCaptainInset.Image = GFXLibrary.castlescreen_unit_capsule;
			this.captain_castleSelectionCaptainInset.Position = new Point(70, 60);
			this.captain_castleSelectionCaptainImage.addControl(this.captain_castleSelectionCaptainInset);
			this.captain_castleSelectionCaptainLabel.Text = "0";
			this.captain_castleSelectionCaptainLabel.Color = Color.FromArgb(254, 248, 229);
			this.captain_castleSelectionCaptainLabel.Position = new Point(0, 0);
			this.captain_castleSelectionCaptainLabel.Size = this.captain_castleSelectionCaptainInset.Size;
			this.captain_castleSelectionCaptainLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.captain_castleSelectionCaptainInset.addControl(this.captain_castleSelectionCaptainLabel);
			this.captain_castleSelectionCaptainButton.ImageNorm = GFXLibrary.castlescreen_stance_def_normal;
			this.captain_castleSelectionCaptainButton.ImageOver = GFXLibrary.castlescreen_stance_def_over;
			this.captain_castleSelectionCaptainButton.Position = new Point(5, 12);
			this.captain_castleSelectionCaptainButton.Data = 85;
			this.captain_castleSelectionCaptainButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.aggressiveStateClick), "CastleMapPanel_toggle_aggressive_captains");
			this.captain_castleSelectionInset5Image.addControl(this.captain_castleSelectionCaptainButton);
			this.captain_castleSelectionCaptainDeleteButton.ImageNorm = GFXLibrary.castlescreen_sendback_normal;
			this.captain_castleSelectionCaptainDeleteButton.ImageOver = GFXLibrary.castlescreen_sendback_over;
			this.captain_castleSelectionCaptainDeleteButton.Position = new Point(135, 13);
			this.captain_castleSelectionCaptainDeleteButton.Data = 85;
			this.captain_castleSelectionCaptainDeleteButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.troopDeleteClick), "CastleMapPanel_delete_captains");
			this.captain_castleSelectionInset5Image.addControl(this.captain_castleSelectionCaptainDeleteButton);
		}

		// Token: 0x06000AD0 RID: 2768 RVA: 0x0000E1F9 File Offset: 0x0000C3F9
		public void showNewInterface()
		{
			this.currentUtilHeight = 0;
			this.currentCastlePlaceHeight = 0;
			this.closeCastlePlacePanel();
			this.closeutilPanel();
			this.CastlePanelUpdate();
		}

		// Token: 0x06000AD1 RID: 2769 RVA: 0x0000E21B File Offset: 0x0000C41B
		private void DEBUG_load()
		{
			if (this.LoadCampDialog.ShowDialog() == DialogResult.OK && GameEngine.Instance.Castle != null)
			{
				GameEngine.Instance.Castle.loadCamp(this.LoadCampDialog.FileName);
			}
		}

		// Token: 0x06000AD2 RID: 2770 RVA: 0x0000E251 File Offset: 0x0000C451
		private void DEBUG_save()
		{
			if (this.SaveCampDialog.ShowDialog() == DialogResult.OK && GameEngine.Instance.Castle != null)
			{
				GameEngine.Instance.Castle.saveCamp(this.SaveCampDialog.FileName);
			}
		}

		// Token: 0x06000AD3 RID: 2771 RVA: 0x000D92A8 File Offset: 0x000D74A8
		public void initCommitBuildPanel()
		{
			int y = this.calcDeleteBarYPos();
			this.commitBuildPanelImage.Image = GFXLibrary.castlescreen_panelback_C;
			this.commitBuildPanelImage.Position = new Point(0, y);
			this.commitBuildPanelImage.Visible = false;
			CastleMapPanel.commitButtonVisible = false;
			base.addControl(this.commitBuildPanelImage);
			this.commitBuildCommitImage.Image = GFXLibrary.int_but_industry_blank_norm;
			this.commitBuildCommitImage.Position = new Point(11, 82);
			this.commitBuildCommitImage.Alpha = 0.8f;
			this.commitBuildPanelImage.addControl(this.commitBuildCommitImage);
			this.overCommitButton = false;
			this.commitBuildCommitButton.ImageNorm = GFXLibrary.int_but_industry_blank_over;
			this.commitBuildCommitButton.ImageOver = GFXLibrary.int_but_industry_blank_over;
			this.commitBuildCommitButton.Position = new Point(11, 82);
			this.commitBuildCommitButton.Text.Text = SK.Text("CastleMapPanel_Confirm", "Confirm");
			this.commitBuildCommitButton.TextYOffset = -1;
			this.commitBuildCommitButton.Text.Color = global::ARGBColors.Black;
			this.commitBuildCommitButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.commitBuildings), "CastleMapPanel_confirm");
			this.commitBuildCommitButton.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.commitBuildingsOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.commitBuildingsLeave));
			this.commitBuildCommitButton.CustomTooltipID = 219;
			this.commitBuildPanelImage.addControl(this.commitBuildCommitButton);
			if (GameEngine.Instance.World.WorldEnded)
			{
				this.commitBuildCommitButton.Visible = false;
			}
			else
			{
				this.commitBuildCommitButton.Visible = true;
			}
			this.commitBuildCancelButton.ImageNorm = GFXLibrary.int_but_industry_blank_norm;
			this.commitBuildCancelButton.ImageOver = GFXLibrary.int_but_industry_blank_over;
			this.commitBuildCancelButton.Position = new Point(99, 82);
			this.commitBuildCancelButton.Text.Text = SK.Text("GENERIC_Cancel", "Cancel");
			this.commitBuildCancelButton.TextYOffset = -1;
			this.commitBuildCancelButton.Text.Color = global::ARGBColors.Black;
			this.commitBuildCancelButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.cancelBuildings), "CastleMapPanel_cancel");
			this.commitBuildCancelButton.CustomTooltipID = 220;
			this.commitBuildPanelImage.addControl(this.commitBuildCancelButton);
			this.commitBuildWoodImage.Image = GFXLibrary.r_building_panel_inset_icon_wood;
			this.commitBuildWoodImage.Position = new Point(13, 7);
			this.commitBuildPanelImage.addControl(this.commitBuildWoodImage);
			this.commitBuildWoodLabel.Text = "0";
			this.commitBuildWoodLabel.Color = global::ARGBColors.Black;
			this.commitBuildWoodLabel.Position = new Point(40, 11);
			this.commitBuildWoodLabel.Size = new Size(46, 20);
			this.commitBuildPanelImage.addControl(this.commitBuildWoodLabel);
			this.commitBuildStoneImage.Image = GFXLibrary.r_building_panel_inset_icon_stone;
			this.commitBuildStoneImage.Position = new Point(13, 26);
			this.commitBuildPanelImage.addControl(this.commitBuildStoneImage);
			this.commitBuildStoneLabel.Text = "0";
			this.commitBuildStoneLabel.Color = global::ARGBColors.Black;
			this.commitBuildStoneLabel.Position = new Point(40, 30);
			this.commitBuildStoneLabel.Size = new Size(46, 20);
			this.commitBuildPanelImage.addControl(this.commitBuildStoneLabel);
			this.commitBuildIronImage.Image = GFXLibrary.com_16_iron;
			this.commitBuildIronImage.Position = new Point(106, 7);
			this.commitBuildPanelImage.addControl(this.commitBuildIronImage);
			this.commitBuildIronLabel.Text = "0";
			this.commitBuildIronLabel.Color = global::ARGBColors.Black;
			this.commitBuildIronLabel.Position = new Point(133, 11);
			this.commitBuildIronLabel.Size = new Size(46, 20);
			this.commitBuildPanelImage.addControl(this.commitBuildIronLabel);
			this.commitBuildPitchImage.Image = GFXLibrary.com_16_pitch;
			this.commitBuildPitchImage.Position = new Point(106, 26);
			this.commitBuildPanelImage.addControl(this.commitBuildPitchImage);
			this.commitBuildPitchLabel.Text = "0";
			this.commitBuildPitchLabel.Color = global::ARGBColors.Black;
			this.commitBuildPitchLabel.Position = new Point(133, 30);
			this.commitBuildPitchLabel.Size = new Size(46, 20);
			this.commitBuildPanelImage.addControl(this.commitBuildPitchLabel);
			this.commitBuildGoldImage.Image = GFXLibrary.r_building_panel_inset_icon_gold;
			this.commitBuildGoldImage.Position = new Point(13, 45);
			this.commitBuildPanelImage.addControl(this.commitBuildGoldImage);
			this.commitBuildGoldLabel.Text = "0";
			this.commitBuildGoldLabel.Color = global::ARGBColors.Black;
			this.commitBuildGoldLabel.Position = new Point(40, 49);
			this.commitBuildGoldLabel.Size = new Size(46, 20);
			this.commitBuildPanelImage.addControl(this.commitBuildGoldLabel);
			this.commitBuildTimeImage.Image = GFXLibrary.r_building_panel_inset_icon_time;
			this.commitBuildTimeImage.Position = new Point(13, 64);
			this.commitBuildPanelImage.addControl(this.commitBuildTimeImage);
			this.commitBuildTimeLabel.Text = "";
			this.commitBuildTimeLabel.Color = global::ARGBColors.Black;
			this.commitBuildTimeLabel.Position = new Point(40, 67);
			this.commitBuildTimeLabel.Size = new Size(120, 20);
			this.commitBuildPanelImage.addControl(this.commitBuildTimeLabel);
		}

		// Token: 0x06000AD4 RID: 2772 RVA: 0x000D988C File Offset: 0x000D7A8C
		public void updateCommitValues()
		{
			int num = 0;
			VillageMap.StockpileLevels stockpileLevels = new VillageMap.StockpileLevels();
			if (GameEngine.Instance.Castle != null)
			{
				GameEngine.Instance.Castle.adjustLevels(ref stockpileLevels, ref num);
				this.commitBuildWoodLabel.Text = (0.0 - stockpileLevels.woodLevel).ToString();
				this.commitBuildStoneLabel.Text = (0.0 - stockpileLevels.stoneLevel).ToString();
				this.commitBuildIronLabel.Text = (0.0 - stockpileLevels.ironLevel).ToString();
				this.commitBuildPitchLabel.Text = (0.0 - stockpileLevels.pitchLevel).ToString();
				this.commitBuildGoldLabel.Text = (-num).ToString();
				this.commitBuildTimeLabel.Text = GameEngine.Instance.Castle.GetNewBuildTime();
			}
		}

		// Token: 0x06000AD5 RID: 2773 RVA: 0x000D9980 File Offset: 0x000D7B80
		public void commitBuildings()
		{
			if (!CastleMap.CreateMode && GameEngine.Instance.Castle != null && (DateTime.Now - this.lastCommitClick).TotalSeconds > 10.0)
			{
				this.commitBuildCommitButton.Enabled = false;
				this.lastCommitClick = DateTime.Now;
				this.controlBlockOverlay.Visible = true;
				GameEngine.Instance.Castle.commitCastle(false);
			}
		}

		// Token: 0x06000AD6 RID: 2774 RVA: 0x0000E287 File Offset: 0x0000C487
		private void commitBuildingsOver()
		{
			this.overCommitButton = true;
		}

		// Token: 0x06000AD7 RID: 2775 RVA: 0x0000E290 File Offset: 0x0000C490
		private void commitBuildingsLeave()
		{
			this.overCommitButton = false;
		}

		// Token: 0x06000AD8 RID: 2776 RVA: 0x0000E299 File Offset: 0x0000C499
		public void castleCommitReturn()
		{
			this.commitBuildCommitButton.Enabled = true;
			this.lastCommitClick = DateTime.MinValue;
			this.controlBlockOverlay.Visible = false;
		}

		// Token: 0x06000AD9 RID: 2777 RVA: 0x000D99F8 File Offset: 0x000D7BF8
		public void cancelBuildings()
		{
			if (!CastleMap.CreateMode)
			{
				if (GameEngine.Instance.Castle != null)
				{
					GameEngine.Instance.Castle.cancelBuilderMode();
				}
				this.commitBuildPanelImage.Visible = false;
				CastleMapPanel.commitButtonVisible = false;
				this.utilAdvancedButton.Enabled = true;
				this.setCastlePlaceTab(this.currentCastlePlaceTab);
			}
		}

		// Token: 0x06000ADA RID: 2778 RVA: 0x000D9A54 File Offset: 0x000D7C54
		public void castleStartBuilderMode()
		{
			if (CastleMap.CreateMode || GameEngine.Instance.Castle == null)
			{
				return;
			}
			if (GameEngine.Instance.Castle.InBuilderMode)
			{
				this.commitBuildWoodImage.Visible = true;
				this.commitBuildWoodLabel.Visible = true;
				this.commitBuildStoneImage.Visible = true;
				this.commitBuildStoneLabel.Visible = true;
				this.commitBuildPitchImage.Visible = true;
				this.commitBuildPitchLabel.Visible = true;
				this.commitBuildIronImage.Visible = true;
				this.commitBuildIronLabel.Visible = true;
				this.commitBuildGoldImage.Visible = true;
				this.commitBuildGoldLabel.Visible = true;
				this.commitBuildTimeImage.Visible = true;
				this.commitBuildTimeLabel.Visible = true;
			}
			if (GameEngine.Instance.Castle.InTroopPlacerMode)
			{
				this.commitBuildWoodImage.Visible = false;
				this.commitBuildWoodLabel.Visible = false;
				this.commitBuildStoneImage.Visible = false;
				this.commitBuildStoneLabel.Visible = false;
				this.commitBuildPitchImage.Visible = false;
				this.commitBuildPitchLabel.Visible = false;
				this.commitBuildIronImage.Visible = false;
				this.commitBuildIronLabel.Visible = false;
				this.commitBuildGoldImage.Visible = false;
				this.commitBuildGoldLabel.Visible = false;
				this.commitBuildTimeImage.Visible = false;
				this.commitBuildTimeLabel.Visible = false;
				if (this.currentCastlePlaceTab < 0)
				{
					this.castlePlaceTab1Clicked();
				}
			}
			this.commitBuildPanelImage.Visible = true;
			CastleMapPanel.commitButtonVisible = true;
			this.utilAdvancedButton.Enabled = false;
			this.setCastlePlaceTab(this.currentCastlePlaceTab);
		}

		// Token: 0x06000ADB RID: 2779 RVA: 0x0000E2BE File Offset: 0x0000C4BE
		public void castleEndBuilderMode()
		{
			this.CastlePanelUpdate();
			this.setCastlePlaceTab(this.currentCastlePlaceTab);
		}

		// Token: 0x04000E34 RID: 3636
		private const int WINDOWS_EXPAND_SPEED = 50;

		// Token: 0x04000E35 RID: 3637
		private const int CASTLEPANEL_WINDOW_SIZE = 422;

		// Token: 0x04000E36 RID: 3638
		private const int UTILPANEL_WINDOW_SIZE = 366;

		// Token: 0x04000E37 RID: 3639
		private const int UTILPANEL_WINDOW_OPENSIZE = 271;

		// Token: 0x04000E38 RID: 3640
		private DockableControl dockableControl;

		// Token: 0x04000E39 RID: 3641
		private IContainer components;

		// Token: 0x04000E3A RID: 3642
		private OpenFileDialog LoadCampDialog;

		// Token: 0x04000E3B RID: 3643
		private SaveFileDialog SaveCampDialog;

		// Token: 0x04000E3C RID: 3644
		private CustomSelfDrawPanel.CSDFill controlBlockOverlay = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x04000E3D RID: 3645
		private int currentCastlePlaceHeight;

		// Token: 0x04000E3E RID: 3646
		private int targetCastlePlaceHeight;

		// Token: 0x04000E3F RID: 3647
		private int currentUtilHeight;

		// Token: 0x04000E40 RID: 3648
		private int targetUtilHeight;

		// Token: 0x04000E41 RID: 3649
		private CustomSelfDrawPanel.CSDArea castlePlaceBackgroundArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000E42 RID: 3650
		private CustomSelfDrawPanel.CSDImage castlePlacePanelImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000E43 RID: 3651
		private CustomSelfDrawPanel.CSDArea castlePlaceHeaderArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000E44 RID: 3652
		private CustomSelfDrawPanel.CSDImage castlePlacePanelFaderImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000E45 RID: 3653
		private CustomSelfDrawPanel.CSDButton castlePlaceTab1Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E46 RID: 3654
		private CustomSelfDrawPanel.CSDButton castlePlaceTab2Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E47 RID: 3655
		private CustomSelfDrawPanel.CSDButton castlePlaceTab3Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E48 RID: 3656
		private CustomSelfDrawPanel.CSDButton castlePlaceTab4Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E49 RID: 3657
		private CustomSelfDrawPanel.CSDButton castlePlaceTab5Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E4A RID: 3658
		private CustomSelfDrawPanel.CSDImage castlePlaceInfoImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000E4B RID: 3659
		private CustomSelfDrawPanel.CSDLabel castlePlaceTypeLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E4C RID: 3660
		private CustomSelfDrawPanel.CSDImage castlePlaceTimeImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000E4D RID: 3661
		private CustomSelfDrawPanel.CSDLabel castlePlaceTimeLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E4E RID: 3662
		private CustomSelfDrawPanel.CSDImage castlePlaceWoodImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000E4F RID: 3663
		private CustomSelfDrawPanel.CSDLabel castlePlaceWoodLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E50 RID: 3664
		private CustomSelfDrawPanel.CSDImage castlePlaceStoneImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000E51 RID: 3665
		private CustomSelfDrawPanel.CSDLabel castlePlaceStoneLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E52 RID: 3666
		private CustomSelfDrawPanel.CSDImage castlePlacePitchImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000E53 RID: 3667
		private CustomSelfDrawPanel.CSDLabel castlePlacePitchLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E54 RID: 3668
		private CustomSelfDrawPanel.CSDImage castlePlaceIronImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000E55 RID: 3669
		private CustomSelfDrawPanel.CSDLabel castlePlaceIronLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E56 RID: 3670
		private CustomSelfDrawPanel.CSDImage castlePlaceGoldImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000E57 RID: 3671
		private CustomSelfDrawPanel.CSDLabel castlePlaceGoldLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E58 RID: 3672
		private CustomSelfDrawPanel.CSDImage castleTotalGoldImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000E59 RID: 3673
		private CustomSelfDrawPanel.CSDLabel castleTotalGoldLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E5A RID: 3674
		private CustomSelfDrawPanel.CSDButton castlePlace1Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E5B RID: 3675
		private CustomSelfDrawPanel.CSDButton castlePlace2Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E5C RID: 3676
		private CustomSelfDrawPanel.CSDButton castlePlace3Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E5D RID: 3677
		private CustomSelfDrawPanel.CSDButton castlePlace4Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E5E RID: 3678
		private CustomSelfDrawPanel.CSDButton castlePlace5Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E5F RID: 3679
		private CustomSelfDrawPanel.CSDButton castlePlace6Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E60 RID: 3680
		private CustomSelfDrawPanel.CSDButton castlePlace7Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E61 RID: 3681
		private CustomSelfDrawPanel.CSDButton castlePlace8Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E62 RID: 3682
		private CustomSelfDrawPanel.CSDImage building1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000E63 RID: 3683
		private CustomSelfDrawPanel.CSDLabel building1Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E64 RID: 3684
		private CustomSelfDrawPanel.CSDImage building2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000E65 RID: 3685
		private CustomSelfDrawPanel.CSDLabel building2Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E66 RID: 3686
		private CustomSelfDrawPanel.CSDImage building3Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000E67 RID: 3687
		private CustomSelfDrawPanel.CSDLabel building3Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E68 RID: 3688
		private CustomSelfDrawPanel.CSDImage building4Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000E69 RID: 3689
		private CustomSelfDrawPanel.CSDLabel building4Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E6A RID: 3690
		private CustomSelfDrawPanel.CSDImage building5Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000E6B RID: 3691
		private CustomSelfDrawPanel.CSDLabel building5Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E6C RID: 3692
		private CustomSelfDrawPanel.CSDImage building6Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000E6D RID: 3693
		private CustomSelfDrawPanel.CSDLabel building6Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E6E RID: 3694
		private CustomSelfDrawPanel.CSDImage building7Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000E6F RID: 3695
		private CustomSelfDrawPanel.CSDLabel building7Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E70 RID: 3696
		private CustomSelfDrawPanel.CSDImage building8Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000E71 RID: 3697
		private CustomSelfDrawPanel.CSDLabel building8Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E72 RID: 3698
		private CustomSelfDrawPanel.CSDButton castlePlacePeasantButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E73 RID: 3699
		private CustomSelfDrawPanel.CSDButton castlePlaceArcherButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E74 RID: 3700
		private CustomSelfDrawPanel.CSDButton castlePlacePikemanButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E75 RID: 3701
		private CustomSelfDrawPanel.CSDButton castlePlaceSwordsmanButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E76 RID: 3702
		private CustomSelfDrawPanel.CSDButton castlePlaceWolfButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E77 RID: 3703
		private CustomSelfDrawPanel.CSDImage castlePlacePeasantInset = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000E78 RID: 3704
		private CustomSelfDrawPanel.CSDImage castlePlaceArcherInset = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000E79 RID: 3705
		private CustomSelfDrawPanel.CSDImage castlePlacePikemanInset = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000E7A RID: 3706
		private CustomSelfDrawPanel.CSDImage castlePlaceSwordsmanInset = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000E7B RID: 3707
		private CustomSelfDrawPanel.CSDImage castlePlaceWolfInset = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000E7C RID: 3708
		private CustomSelfDrawPanel.CSDLabel castlePlacePeasantLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E7D RID: 3709
		private CustomSelfDrawPanel.CSDLabel castlePlaceArcherLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E7E RID: 3710
		private CustomSelfDrawPanel.CSDLabel castlePlacePikemanLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E7F RID: 3711
		private CustomSelfDrawPanel.CSDLabel castlePlaceSwordsmanLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E80 RID: 3712
		private CustomSelfDrawPanel.CSDLabel castlePlaceWolfLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E81 RID: 3713
		private CustomSelfDrawPanel.CSDLabel castlePlaceGuardhouseLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E82 RID: 3714
		private CustomSelfDrawPanel.CSDButton castlePlaceToggleReinforcementsButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E83 RID: 3715
		private CustomSelfDrawPanel.CSDButton castlePlaceSize1Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E84 RID: 3716
		private CustomSelfDrawPanel.CSDButton castlePlaceSize3Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E85 RID: 3717
		private CustomSelfDrawPanel.CSDButton castlePlaceSize5Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E86 RID: 3718
		private CustomSelfDrawPanel.CSDButton castlePlaceSize15Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E87 RID: 3719
		private bool buildingBeingPlaced;

		// Token: 0x04000E88 RID: 3720
		private bool placingReinforcements;

		// Token: 0x04000E89 RID: 3721
		private int placementSize = 1;

		// Token: 0x04000E8A RID: 3722
		private int currentCastlePlaceTab = -1;

		// Token: 0x04000E8B RID: 3723
		private int currentCastleIcon;

		// Token: 0x04000E8C RID: 3724
		private int alphaPulse = 255;

		// Token: 0x04000E8D RID: 3725
		public static bool commitButtonVisible;

		// Token: 0x04000E8E RID: 3726
		private int lastUtilYpos = -1;

		// Token: 0x04000E8F RID: 3727
		private DateTime m_castleCompletTime = DateTime.Now;

		// Token: 0x04000E90 RID: 3728
		private bool m_castledCompleted = true;

		// Token: 0x04000E91 RID: 3729
		private CustomSelfDrawPanel.CSDButton deleteHeaderButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E92 RID: 3730
		private CustomSelfDrawPanel.CSDLabel deleteHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E93 RID: 3731
		private CustomSelfDrawPanel.CSDButton loadButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E94 RID: 3732
		private CustomSelfDrawPanel.CSDButton saveButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E95 RID: 3733
		private bool deleteState;

		// Token: 0x04000E96 RID: 3734
		private bool allowDeleteCallback = true;

		// Token: 0x04000E97 RID: 3735
		private CustomSelfDrawPanel.CSDImage utilHeaderPanelImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000E98 RID: 3736
		private CustomSelfDrawPanel.CSDLabel utilHeaderLabel1 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E99 RID: 3737
		private CustomSelfDrawPanel.CSDLabel utilHeaderLabel2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E9A RID: 3738
		private CustomSelfDrawPanel.CSDLabel utilHeaderLabel3 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E9B RID: 3739
		private CustomSelfDrawPanel.CSDImage utilPanelImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000E9C RID: 3740
		private CustomSelfDrawPanel.CSDImage utilPanelFaderImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000E9D RID: 3741
		private CustomSelfDrawPanel.CSDButton utilRepairButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E9E RID: 3742
		private CustomSelfDrawPanel.CSDLabel utilRepairLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E9F RID: 3743
		private CustomSelfDrawPanel.CSDButton utilViewModeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000EA0 RID: 3744
		private CustomSelfDrawPanel.CSDLabel utilViewModeLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000EA1 RID: 3745
		private CustomSelfDrawPanel.CSDButton utilDeleteConstructingButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000EA2 RID: 3746
		private CustomSelfDrawPanel.CSDLabel utilDeleteConstructingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000EA3 RID: 3747
		private CustomSelfDrawPanel.CSDButton utilAdvancedButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000EA4 RID: 3748
		private CustomSelfDrawPanel.CSDButton utilTroopPresetButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000EA5 RID: 3749
		private CustomSelfDrawPanel.CSDButton utilCastlePresetButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000EA6 RID: 3750
		private CustomSelfDrawPanel.CSDArea castleSelectionBackgroundArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000EA7 RID: 3751
		private CustomSelfDrawPanel.CSDImage castleSelectionPanelImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000EA8 RID: 3752
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000EA9 RID: 3753
		private CustomSelfDrawPanel.CSDImage castleSelectionInset1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000EAA RID: 3754
		private CustomSelfDrawPanel.CSDImage castleSelectionInset2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000EAB RID: 3755
		private CustomSelfDrawPanel.CSDImage castleSelectionInset3Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000EAC RID: 3756
		private CustomSelfDrawPanel.CSDImage castleSelectionInset4Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000EAD RID: 3757
		private CustomSelfDrawPanel.CSDImage castleSelectionInset5Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000EAE RID: 3758
		private CustomSelfDrawPanel.CSDImage castleSelectionPeasantImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000EAF RID: 3759
		private CustomSelfDrawPanel.CSDImage castleSelectionArcherImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000EB0 RID: 3760
		private CustomSelfDrawPanel.CSDImage castleSelectionPikemanImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000EB1 RID: 3761
		private CustomSelfDrawPanel.CSDImage castleSelectionSwordsmanImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000EB2 RID: 3762
		private CustomSelfDrawPanel.CSDImage castleSelectionCaptainImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000EB3 RID: 3763
		private CustomSelfDrawPanel.CSDImage castleSelectionPeasantInset = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000EB4 RID: 3764
		private CustomSelfDrawPanel.CSDImage castleSelectionArcherInset = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000EB5 RID: 3765
		private CustomSelfDrawPanel.CSDImage castleSelectionPikemanInset = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000EB6 RID: 3766
		private CustomSelfDrawPanel.CSDImage castleSelectionSwordsmanInset = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000EB7 RID: 3767
		private CustomSelfDrawPanel.CSDImage castleSelectionCaptainInset = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000EB8 RID: 3768
		private CustomSelfDrawPanel.CSDLabel castleSelectionPeasantLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000EB9 RID: 3769
		private CustomSelfDrawPanel.CSDLabel castleSelectionArcherLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000EBA RID: 3770
		private CustomSelfDrawPanel.CSDLabel castleSelectionPikemanLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000EBB RID: 3771
		private CustomSelfDrawPanel.CSDLabel castleSelectionSwordsmanLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000EBC RID: 3772
		private CustomSelfDrawPanel.CSDLabel castleSelectionCaptainLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000EBD RID: 3773
		private CustomSelfDrawPanel.CSDButton castleSelectionPeasantButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000EBE RID: 3774
		private CustomSelfDrawPanel.CSDButton castleSelectionArcherButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000EBF RID: 3775
		private CustomSelfDrawPanel.CSDButton castleSelectionPikemanButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000EC0 RID: 3776
		private CustomSelfDrawPanel.CSDButton castleSelectionSwordsmanButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000EC1 RID: 3777
		private CustomSelfDrawPanel.CSDButton castleSelectionCaptainButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000EC2 RID: 3778
		private CustomSelfDrawPanel.CSDButton castleSelectionPeasantDeleteButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000EC3 RID: 3779
		private CustomSelfDrawPanel.CSDButton castleSelectionArcherDeleteButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000EC4 RID: 3780
		private CustomSelfDrawPanel.CSDButton castleSelectionPikemanDeleteButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000EC5 RID: 3781
		private CustomSelfDrawPanel.CSDButton castleSelectionSwordsmanDeleteButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000EC6 RID: 3782
		private CustomSelfDrawPanel.CSDButton castleSelectionCaptainDeleteButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000EC7 RID: 3783
		private bool nextPeasantState;

		// Token: 0x04000EC8 RID: 3784
		private bool nextArcherState;

		// Token: 0x04000EC9 RID: 3785
		private bool nextPikemanState;

		// Token: 0x04000ECA RID: 3786
		private bool nextSwordsmanState;

		// Token: 0x04000ECB RID: 3787
		private bool nextCaptainState;

		// Token: 0x04000ECC RID: 3788
		private int sst_lastPeasants;

		// Token: 0x04000ECD RID: 3789
		private int sst_lastArchers;

		// Token: 0x04000ECE RID: 3790
		private int sst_lastPikeman;

		// Token: 0x04000ECF RID: 3791
		private int sst_lastSwordsman;

		// Token: 0x04000ED0 RID: 3792
		private int sst_lastCaptains;

		// Token: 0x04000ED1 RID: 3793
		private CustomSelfDrawPanel.CSDArea captain_castleSelectionBackgroundArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000ED2 RID: 3794
		private CustomSelfDrawPanel.CSDImage captain_castleSelectionPanelImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000ED3 RID: 3795
		private CustomSelfDrawPanel.CSDButton captain_closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000ED4 RID: 3796
		private CustomSelfDrawPanel.CSDImage captain_castleSelectionInset5Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000ED5 RID: 3797
		private CustomSelfDrawPanel.CSDImage captain_castleSelectionCaptainImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000ED6 RID: 3798
		private CustomSelfDrawPanel.CSDImage captain_castleSelectionCaptainInset = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000ED7 RID: 3799
		private CustomSelfDrawPanel.CSDLabel captain_castleSelectionCaptainLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000ED8 RID: 3800
		private CustomSelfDrawPanel.CSDButton captain_castleSelectionCaptainButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000ED9 RID: 3801
		private CustomSelfDrawPanel.CSDButton captain_castleSelectionCaptainDeleteButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000EDA RID: 3802
		private CustomSelfDrawPanel.CSDImage commitBuildPanelImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000EDB RID: 3803
		private CustomSelfDrawPanel.CSDImage commitBuildCommitImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000EDC RID: 3804
		private CustomSelfDrawPanel.CSDButton commitBuildCommitButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000EDD RID: 3805
		private CustomSelfDrawPanel.CSDButton commitBuildCancelButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000EDE RID: 3806
		private CustomSelfDrawPanel.CSDImage commitBuildWoodImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000EDF RID: 3807
		private CustomSelfDrawPanel.CSDLabel commitBuildWoodLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000EE0 RID: 3808
		private CustomSelfDrawPanel.CSDImage commitBuildStoneImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000EE1 RID: 3809
		private CustomSelfDrawPanel.CSDLabel commitBuildStoneLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000EE2 RID: 3810
		private CustomSelfDrawPanel.CSDImage commitBuildPitchImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000EE3 RID: 3811
		private CustomSelfDrawPanel.CSDLabel commitBuildPitchLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000EE4 RID: 3812
		private CustomSelfDrawPanel.CSDImage commitBuildIronImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000EE5 RID: 3813
		private CustomSelfDrawPanel.CSDLabel commitBuildIronLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000EE6 RID: 3814
		private CustomSelfDrawPanel.CSDImage commitBuildGoldImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000EE7 RID: 3815
		private CustomSelfDrawPanel.CSDLabel commitBuildGoldLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000EE8 RID: 3816
		private CustomSelfDrawPanel.CSDImage commitBuildTimeImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000EE9 RID: 3817
		private CustomSelfDrawPanel.CSDLabel commitBuildTimeLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000EEA RID: 3818
		private DateTime lastCommitClick = DateTime.MinValue;

		// Token: 0x04000EEB RID: 3819
		private bool overCommitButton;

		// Token: 0x04000EEC RID: 3820
		[CompilerGenerated]
		private static CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate _003C_003E9__CachedAnonymousMethodDelegate3;

		// Token: 0x04000EED RID: 3821
		[CompilerGenerated]
		private static CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate _003C_003E9__CachedAnonymousMethodDelegate4;

		// Token: 0x04000EEE RID: 3822
		[CompilerGenerated]
		private static CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate _003C_003E9__CachedAnonymousMethodDelegate5;
	}
}
