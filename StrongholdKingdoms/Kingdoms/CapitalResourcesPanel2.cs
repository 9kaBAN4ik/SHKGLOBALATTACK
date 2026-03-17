using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000105 RID: 261
	public class CapitalResourcesPanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x0600080F RID: 2063 RVA: 0x000AB270 File Offset: 0x000A9470
		public CapitalResourcesPanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06000810 RID: 2064 RVA: 0x000AB348 File Offset: 0x000A9548
		public void init()
		{
			base.clearControls();
			NumberFormatInfo nfi = GameEngine.NFI;
			this.mainBackgroundImage.Image = GFXLibrary.body_background_canvas;
			this.mainBackgroundImage.Position = new Point(0, 0);
			base.addControl(this.mainBackgroundImage);
			this.mainBackgroundArea.Position = new Point(0, 0);
			this.mainBackgroundArea.Size = new Size(992, 566);
			this.mainBackgroundImage.addControl(this.mainBackgroundArea);
			this.closeButton.ImageNorm = GFXLibrary.int_button_close_normal;
			this.closeButton.ImageOver = GFXLibrary.int_button_close_over;
			this.closeButton.ImageClick = GFXLibrary.int_button_close_in;
			this.closeButton.Position = new Point(948, 10);
			this.closeButton.CustomTooltipID = 900;
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "CapitalResourcesPanel2_close");
			this.mainBackgroundArea.addControl(this.closeButton);
			CustomSelfDrawPanel.WikiLinkControl.init(this.mainBackgroundArea, 11, new Point(898, 10));
			Color color = Color.FromArgb(224, 203, 146);
			Color dropShadowColor = Color.FromArgb(74, 67, 48);
			this.lightPanel.Position = new Point(157, 87);
			this.lightPanel.Size = new Size(343, 390);
			this.mainBackgroundArea.addControl(this.lightPanel);
			this.lightPanel.Create(GFXLibrary.lite_9slice_panel_top_left, GFXLibrary.lite_9slice_panel_top_mid, GFXLibrary.lite_9slice_panel_top_right, GFXLibrary.lite_9slice_panel_mid_left, GFXLibrary.lite_9slice_panel_mid_mid, GFXLibrary.lite_9slice_panel_mid_right, GFXLibrary.lite_9slice_panel_bottom_left, GFXLibrary.lite_9slice_panel_bottom_mid, GFXLibrary.lite_9slice_panel_bottom_right);
			this.illustration.Image = GFXLibrary.donate_illustration;
			this.illustration.Position = new Point(513, 87);
			this.mainBackgroundArea.addControl(this.illustration);
			this.stockpileHeaderLabel.Text = SK.Text("ResourcesPanel_Parish_Resources", "Parish Resources");
			this.stockpileHeaderLabel.Color = color;
			this.stockpileHeaderLabel.DropShadowColor = dropShadowColor;
			this.stockpileHeaderLabel.Position = new Point(9, 9);
			this.stockpileHeaderLabel.Size = new Size(992, 50);
			this.stockpileHeaderLabel.Font = FontManager.GetFont("Arial", 20f, FontStyle.Bold);
			this.stockpileHeaderLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainBackgroundArea.addControl(this.stockpileHeaderLabel);
			this.stockpileLimitLabel.Text = SK.Text("ResourcesPanel_Parish_Capacity", "Capacity of the Warehouse") + ": " + 100000.ToString("N", nfi);
			this.stockpileLimitLabel.Color = color;
			this.stockpileLimitLabel.DropShadowColor = dropShadowColor;
			this.stockpileLimitLabel.Position = new Point(523, 418);
			this.stockpileLimitLabel.Size = new Size(325, 50);
			this.stockpileLimitLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.stockpileLimitLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainBackgroundArea.addControl(this.stockpileLimitLabel);
			this.woodLabel.Text = "0";
			this.woodLabel.Color = color;
			this.woodLabel.DropShadowColor = dropShadowColor;
			this.woodLabel.Position = new Point(120, 50);
			this.woodLabel.Size = new Size(200, 50);
			this.woodLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.woodLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.lightPanel.addControl(this.woodLabel);
			this.stoneLabel.Text = "0";
			this.stoneLabel.Color = color;
			this.stoneLabel.DropShadowColor = dropShadowColor;
			this.stoneLabel.Position = new Point(120, 135);
			this.stoneLabel.Size = new Size(200, 50);
			this.stoneLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.stoneLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.lightPanel.addControl(this.stoneLabel);
			this.ironLabel.Text = "0";
			this.ironLabel.Color = color;
			this.ironLabel.DropShadowColor = dropShadowColor;
			this.ironLabel.Position = new Point(120, 220);
			this.ironLabel.Size = new Size(200, 50);
			this.ironLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.ironLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.lightPanel.addControl(this.ironLabel);
			this.pitchLabel.Text = "0";
			this.pitchLabel.Color = color;
			this.pitchLabel.DropShadowColor = dropShadowColor;
			this.pitchLabel.Position = new Point(120, 305);
			this.pitchLabel.Size = new Size(200, 50);
			this.pitchLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.pitchLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.lightPanel.addControl(this.pitchLabel);
			this.woodImage.Image = GFXLibrary.getCommodity64DSImage(6);
			this.woodImage.Position = new Point(18, 24);
			this.lightPanel.addControl(this.woodImage);
			this.stoneImage.Image = GFXLibrary.getCommodity64DSImage(7);
			this.stoneImage.Position = new Point(18, 109);
			this.lightPanel.addControl(this.stoneImage);
			this.ironImage.Image = GFXLibrary.getCommodity64DSImage(8);
			this.ironImage.Position = new Point(18, 194);
			this.lightPanel.addControl(this.ironImage);
			this.pitchImage.Image = GFXLibrary.getCommodity64DSImage(9);
			this.pitchImage.Position = new Point(18, 279);
			this.lightPanel.addControl(this.pitchImage);
			this.update();
		}

		// Token: 0x06000811 RID: 2065 RVA: 0x000ABA00 File Offset: 0x000A9C00
		public void update()
		{
			VillageMap village = GameEngine.Instance.Village;
			if (village != null)
			{
				if (GameEngine.Instance.World.isRegionCapital(village.VillageID))
				{
					this.stockpileHeaderLabel.Text = SK.Text("ResourcesPanel_Parish_Resources", "Parish Resources");
				}
				else if (GameEngine.Instance.World.isCountyCapital(village.VillageID))
				{
					this.stockpileHeaderLabel.Text = SK.Text("ResourcesPanel_County_Resources", "County Resources");
				}
				else if (GameEngine.Instance.World.isProvinceCapital(village.VillageID))
				{
					this.stockpileHeaderLabel.Text = SK.Text("ResourcesPanel_Province_Resources", "Province Resources");
				}
				else if (GameEngine.Instance.World.isCountryCapital(village.VillageID))
				{
					this.stockpileHeaderLabel.Text = SK.Text("ResourcesPanel_Country_Resources", "Country Resources");
				}
				NumberFormatInfo nfi = GameEngine.NFI;
				VillageMap.StockpileLevels stockpileLevels = new VillageMap.StockpileLevels();
				village.getStockpileLevels(stockpileLevels);
				this.woodLabel.Text = SK.Text("ResourceTypeWood", "Wood") + ": " + stockpileLevels.woodLevel.ToString("N", nfi);
				this.stoneLabel.Text = SK.Text("ResourceType_Stone", "Stone") + ": " + stockpileLevels.stoneLevel.ToString("N", nfi);
				this.pitchLabel.Text = SK.Text("ResourceType_Pitch", "Pitch") + ": " + stockpileLevels.pitchLevel.ToString("N", nfi);
				this.ironLabel.Text = SK.Text("ResourceType_Iron", "Iron") + ": " + stockpileLevels.ironLevel.ToString("N", nfi);
			}
		}

		// Token: 0x06000812 RID: 2066 RVA: 0x000ABBD4 File Offset: 0x000A9DD4
		private int getCap(int resourceType)
		{
			double resourceCap = GameEngine.Instance.World.UserResearchData.getResourceCap(GameEngine.Instance.LocalWorldData, resourceType, true);
			return (int)resourceCap;
		}

		// Token: 0x06000813 RID: 2067 RVA: 0x0000B71E File Offset: 0x0000991E
		public void closeClick()
		{
			InterfaceMgr.Instance.setVillageTabSubMode(-1);
		}

		// Token: 0x06000814 RID: 2068 RVA: 0x0000CAE1 File Offset: 0x0000ACE1
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x0000CAF1 File Offset: 0x0000ACF1
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06000816 RID: 2070 RVA: 0x0000CB01 File Offset: 0x0000AD01
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06000817 RID: 2071 RVA: 0x0000CB13 File Offset: 0x0000AD13
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06000818 RID: 2072 RVA: 0x0000CB20 File Offset: 0x0000AD20
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
		}

		// Token: 0x06000819 RID: 2073 RVA: 0x0000CB34 File Offset: 0x0000AD34
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x0600081A RID: 2074 RVA: 0x0000CB41 File Offset: 0x0000AD41
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x0600081B RID: 2075 RVA: 0x0000CB4E File Offset: 0x0000AD4E
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600081C RID: 2076 RVA: 0x000ABC04 File Offset: 0x000A9E04
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.MaximumSize = new Size(992, 566);
			this.MinimumSize = new Size(992, 566);
			base.Name = "CapitalResourcesPanel2";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x04000B5C RID: 2908
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000B5D RID: 2909
		private CustomSelfDrawPanel.CSDArea mainBackgroundArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000B5E RID: 2910
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000B5F RID: 2911
		private CustomSelfDrawPanel.CSDLabel stockpileHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000B60 RID: 2912
		private CustomSelfDrawPanel.CSDLabel stockpileLimitLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000B61 RID: 2913
		private CustomSelfDrawPanel.CSDImage illustration = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000B62 RID: 2914
		private CustomSelfDrawPanel.CSDExtendingPanel lightPanel = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04000B63 RID: 2915
		private CustomSelfDrawPanel.CSDLabel woodLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000B64 RID: 2916
		private CustomSelfDrawPanel.CSDLabel stoneLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000B65 RID: 2917
		private CustomSelfDrawPanel.CSDLabel ironLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000B66 RID: 2918
		private CustomSelfDrawPanel.CSDLabel pitchLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000B67 RID: 2919
		private CustomSelfDrawPanel.CSDImage woodImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000B68 RID: 2920
		private CustomSelfDrawPanel.CSDImage stoneImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000B69 RID: 2921
		private CustomSelfDrawPanel.CSDImage ironImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000B6A RID: 2922
		private CustomSelfDrawPanel.CSDImage pitchImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000B6B RID: 2923
		private DockableControl dockableControl;

		// Token: 0x04000B6C RID: 2924
		private IContainer components;
	}
}
