using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x0200049B RID: 1179
	public class StockExchangeSidePanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06002B0C RID: 11020 RVA: 0x0001FA1A File Offset: 0x0001DC1A
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06002B0D RID: 11021 RVA: 0x0001FA2A File Offset: 0x0001DC2A
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06002B0E RID: 11022 RVA: 0x0001FA3A File Offset: 0x0001DC3A
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06002B0F RID: 11023 RVA: 0x0001FA4C File Offset: 0x0001DC4C
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06002B10 RID: 11024 RVA: 0x0001FA59 File Offset: 0x0001DC59
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x06002B11 RID: 11025 RVA: 0x0001FA67 File Offset: 0x0001DC67
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06002B12 RID: 11026 RVA: 0x0001FA74 File Offset: 0x0001DC74
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06002B13 RID: 11027 RVA: 0x0001FA81 File Offset: 0x0001DC81
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002B14 RID: 11028 RVA: 0x00220F7C File Offset: 0x0021F17C
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Name = "StockExchangeSidePanel2";
			base.Size = new Size(199, 213);
			base.ResumeLayout(false);
		}

		// Token: 0x06002B15 RID: 11029 RVA: 0x00220FC8 File Offset: 0x0021F1C8
		public StockExchangeSidePanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SelfDrawBackground = true;
		}

		// Token: 0x06002B16 RID: 11030 RVA: 0x00221028 File Offset: 0x0021F228
		public void init()
		{
			base.clearControls();
			CustomSelfDrawPanel.CSDImage csdimage = this.backGround.init(false, 10000);
			this.backGround.updatePanelText(SK.Text("StockExchangeSidePanel_Select_Stock_Exchange", "Select Stock Exchange"));
			this.backGround.setAction(1004);
			base.addControl(this.backGround);
			this.okButton.ImageNorm = GFXLibrary.mrhp_button_check_normal;
			this.okButton.ImageOver = GFXLibrary.mrhp_button_check_over;
			this.okButton.ImageClick = GFXLibrary.mrhp_button_check_pushed;
			this.okButton.Position = new Point(102, 64);
			this.okButton.Enabled = false;
			this.okButton.CustomTooltipID = 2404;
			this.okButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.selectTargetClick), "StockExchangeSidePanel2_ok");
			csdimage.addControl(this.okButton);
			this.cancelButton.ImageNorm = GFXLibrary.mrhp_button_x_normal;
			this.cancelButton.ImageOver = GFXLibrary.mrhp_button_x_over;
			this.cancelButton.ImageClick = GFXLibrary.mrhp_button_x_pushed;
			this.cancelButton.Position = new Point(20, 64);
			this.cancelButton.CustomTooltipID = 2400;
			this.cancelButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.cancelClick), "StockExchangeSidePanel2_cancel");
			csdimage.addControl(this.cancelButton);
		}

		// Token: 0x06002B17 RID: 11031 RVA: 0x0001FAA0 File Offset: 0x0001DCA0
		public void update()
		{
			this.backGround.update();
		}

		// Token: 0x06002B18 RID: 11032 RVA: 0x002211A8 File Offset: 0x0021F3A8
		private void selectTargetClick()
		{
			InterfaceMgr.Instance.selectStockExchange(-1);
			GameEngine.Instance.SkipVillageTab();
			InterfaceMgr.Instance.getMainTabBar().changeTab(1);
			InterfaceMgr.Instance.setVillageTabSubMode(3);
			InterfaceMgr.Instance.selectStockExchange(this.selectedVillage);
		}

		// Token: 0x06002B19 RID: 11033 RVA: 0x0001FAAD File Offset: 0x0001DCAD
		private void cancelClick()
		{
			GameEngine.Instance.SkipVillageTab();
			InterfaceMgr.Instance.getMainTabBar().changeTab(1);
			InterfaceMgr.Instance.setVillageTabSubMode(3);
			InterfaceMgr.Instance.selectStockExchange(-2);
		}

		// Token: 0x06002B1A RID: 11034 RVA: 0x002211F8 File Offset: 0x0021F3F8
		public void setStockExchange(int villageID)
		{
			this.selectedVillage = villageID;
			if (villageID < 0 || !GameEngine.Instance.World.isVillageVisible(villageID))
			{
				this.backGround.updateHeading("");
				this.backGround.updatePanelType(10000);
				this.okButton.Enabled = false;
				return;
			}
			this.backGround.updateHeading(GameEngine.Instance.World.getVillageNameOrType(villageID));
			this.backGround.updatePanelTypeFromVillageID(villageID);
			this.okButton.Enabled = true;
		}

		// Token: 0x040035CF RID: 13775
		private DockableControl dockableControl;

		// Token: 0x040035D0 RID: 13776
		private IContainer components;

		// Token: 0x040035D1 RID: 13777
		private CustomSelfDrawPanel.MRHP_Background backGround = new CustomSelfDrawPanel.MRHP_Background();

		// Token: 0x040035D2 RID: 13778
		private CustomSelfDrawPanel.CSDButton okButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040035D3 RID: 13779
		private CustomSelfDrawPanel.CSDButton cancelButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040035D4 RID: 13780
		private int selectedVillage = -1;
	}
}
