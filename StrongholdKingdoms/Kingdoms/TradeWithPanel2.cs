using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020004A0 RID: 1184
	public class TradeWithPanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06002B5B RID: 11099 RVA: 0x0001FD84 File Offset: 0x0001DF84
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06002B5C RID: 11100 RVA: 0x0001FD94 File Offset: 0x0001DF94
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06002B5D RID: 11101 RVA: 0x0001FDA4 File Offset: 0x0001DFA4
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06002B5E RID: 11102 RVA: 0x0001FDB6 File Offset: 0x0001DFB6
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06002B5F RID: 11103 RVA: 0x0001FDC3 File Offset: 0x0001DFC3
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x06002B60 RID: 11104 RVA: 0x0001FDD1 File Offset: 0x0001DFD1
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06002B61 RID: 11105 RVA: 0x0001FDDE File Offset: 0x0001DFDE
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06002B62 RID: 11106 RVA: 0x0001FDEB File Offset: 0x0001DFEB
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002B63 RID: 11107 RVA: 0x00223A74 File Offset: 0x00221C74
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Name = "TradeWithPanel2";
			base.Size = new Size(199, 213);
			base.ResumeLayout(false);
		}

		// Token: 0x06002B64 RID: 11108 RVA: 0x00223AC0 File Offset: 0x00221CC0
		public TradeWithPanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SelfDrawBackground = true;
		}

		// Token: 0x06002B65 RID: 11109 RVA: 0x00223B20 File Offset: 0x00221D20
		public void init()
		{
			base.clearControls();
			CustomSelfDrawPanel.CSDImage csdimage = this.backGround.init(false, 10000);
			this.backGround.updatePanelText(SK.Text("TradeWithPanel_Select_Trade_Village", "Select Trade Village"));
			this.backGround.setAction(1004);
			base.addControl(this.backGround);
			this.okButton.ImageNorm = GFXLibrary.mrhp_button_check_normal;
			this.okButton.ImageOver = GFXLibrary.mrhp_button_check_over;
			this.okButton.ImageClick = GFXLibrary.mrhp_button_check_pushed;
			this.okButton.Position = new Point(102, 64);
			this.okButton.Enabled = false;
			this.okButton.CustomTooltipID = 2403;
			this.okButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.selectTargetClick), "TradeWithPanel2_ok");
			csdimage.addControl(this.okButton);
			this.cancelButton.ImageNorm = GFXLibrary.mrhp_button_x_normal;
			this.cancelButton.ImageOver = GFXLibrary.mrhp_button_x_over;
			this.cancelButton.ImageClick = GFXLibrary.mrhp_button_x_pushed;
			this.cancelButton.Position = new Point(20, 64);
			this.cancelButton.CustomTooltipID = 2400;
			this.cancelButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.cancelClick), "TradeWithPanel2_cancel");
			csdimage.addControl(this.cancelButton);
		}

		// Token: 0x06002B66 RID: 11110 RVA: 0x0001FE0A File Offset: 0x0001E00A
		public void update()
		{
			this.backGround.update();
		}

		// Token: 0x06002B67 RID: 11111 RVA: 0x00223CA0 File Offset: 0x00221EA0
		public void setTradeWithVillage(int villageID)
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

		// Token: 0x06002B68 RID: 11112 RVA: 0x0001FE17 File Offset: 0x0001E017
		private void cancelClick()
		{
			if (MainTabBar2.LastDummyMode >= 0)
			{
				InterfaceMgr.Instance.openTradeMode(-1, true);
				return;
			}
			InterfaceMgr.Instance.getMainTabBar().changeTab(0);
		}

		// Token: 0x06002B69 RID: 11113 RVA: 0x00223D2C File Offset: 0x00221F2C
		private void selectTargetClick()
		{
			GameEngine.Instance.SkipVillageTab();
			InterfaceMgr.Instance.getMainTabBar().changeTab(1);
			InterfaceMgr.Instance.tradeWithResume(-1, true);
			InterfaceMgr.Instance.setVillageTabSubMode(2);
			InterfaceMgr.Instance.tradeWithResume(this.selectedVillage, true);
		}

		// Token: 0x04003603 RID: 13827
		private DockableControl dockableControl;

		// Token: 0x04003604 RID: 13828
		private IContainer components;

		// Token: 0x04003605 RID: 13829
		private CustomSelfDrawPanel.MRHP_Background backGround = new CustomSelfDrawPanel.MRHP_Background();

		// Token: 0x04003606 RID: 13830
		private CustomSelfDrawPanel.CSDButton okButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003607 RID: 13831
		private CustomSelfDrawPanel.CSDButton cancelButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003608 RID: 13832
		private int selectedVillage = -1;
	}
}
