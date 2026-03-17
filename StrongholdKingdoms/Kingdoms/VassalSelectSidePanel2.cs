using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020004C1 RID: 1217
	public class VassalSelectSidePanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06002D00 RID: 11520 RVA: 0x0023E614 File Offset: 0x0023C814
		public VassalSelectSidePanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SelfDrawBackground = true;
		}

		// Token: 0x06002D01 RID: 11521 RVA: 0x0023E674 File Offset: 0x0023C874
		public void init()
		{
			base.clearControls();
			CustomSelfDrawPanel.CSDImage csdimage = this.backGround.init(false, 10000);
			this.backGround.updatePanelText(SK.Text("VassalSelectSidePanel_Select_Vassal", "Select Vassal"));
			this.backGround.setAction(1005);
			base.addControl(this.backGround);
			this.okButton.ImageNorm = GFXLibrary.mrhp_button_check_normal;
			this.okButton.ImageOver = GFXLibrary.mrhp_button_check_over;
			this.okButton.ImageClick = GFXLibrary.mrhp_button_check_pushed;
			this.okButton.Position = new Point(102, 64);
			this.okButton.Enabled = false;
			this.okButton.CustomTooltipID = 2407;
			this.okButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.selectTargetClick), "VassalSelectSidePanel2_ok");
			csdimage.addControl(this.okButton);
			this.cancelButton.ImageNorm = GFXLibrary.mrhp_button_x_normal;
			this.cancelButton.ImageOver = GFXLibrary.mrhp_button_x_over;
			this.cancelButton.ImageClick = GFXLibrary.mrhp_button_x_pushed;
			this.cancelButton.Position = new Point(20, 64);
			this.cancelButton.CustomTooltipID = 2400;
			this.cancelButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.cancelClick), "VassalSelectSidePanel2_cancel");
			csdimage.addControl(this.cancelButton);
		}

		// Token: 0x06002D02 RID: 11522 RVA: 0x00021029 File Offset: 0x0001F229
		public void update()
		{
			this.backGround.update();
		}

		// Token: 0x06002D03 RID: 11523 RVA: 0x00021036 File Offset: 0x0001F236
		private void selectTargetClick()
		{
			GameEngine.Instance.SkipVillageTab();
			InterfaceMgr.Instance.getMainTabBar().changeTab(1);
			InterfaceMgr.Instance.setVillageTabSubMode(8);
			InterfaceMgr.Instance.selectVassalTarget(this.selectedVillage);
		}

		// Token: 0x06002D04 RID: 11524 RVA: 0x0023E7F4 File Offset: 0x0023C9F4
		private void cancelClick()
		{
			if (MainTabBar2.LastDummyMode >= 0)
			{
				GameEngine.Instance.SkipVillageTab();
				InterfaceMgr.Instance.getMainTabBar().changeTab(1);
				InterfaceMgr.Instance.setVillageTabSubMode(8);
				InterfaceMgr.Instance.selectVassalTarget(-1);
				return;
			}
			InterfaceMgr.Instance.getMainTabBar().changeTab(0);
		}

		// Token: 0x06002D05 RID: 11525 RVA: 0x0023E84C File Offset: 0x0023CA4C
		public void setTarget(int villageID)
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

		// Token: 0x06002D06 RID: 11526 RVA: 0x0002106D File Offset: 0x0001F26D
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06002D07 RID: 11527 RVA: 0x0002107D File Offset: 0x0001F27D
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06002D08 RID: 11528 RVA: 0x0002108D File Offset: 0x0001F28D
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06002D09 RID: 11529 RVA: 0x0002109F File Offset: 0x0001F29F
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06002D0A RID: 11530 RVA: 0x000210AC File Offset: 0x0001F2AC
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x06002D0B RID: 11531 RVA: 0x000210BA File Offset: 0x0001F2BA
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06002D0C RID: 11532 RVA: 0x000210C7 File Offset: 0x0001F2C7
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06002D0D RID: 11533 RVA: 0x000210D4 File Offset: 0x0001F2D4
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002D0E RID: 11534 RVA: 0x0023E8D8 File Offset: 0x0023CAD8
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Name = "VassalSelectSidePanel2";
			base.Size = new Size(199, 213);
			base.ResumeLayout(false);
		}

		// Token: 0x0400381A RID: 14362
		private CustomSelfDrawPanel.MRHP_Background backGround = new CustomSelfDrawPanel.MRHP_Background();

		// Token: 0x0400381B RID: 14363
		private CustomSelfDrawPanel.CSDButton okButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400381C RID: 14364
		private CustomSelfDrawPanel.CSDButton cancelButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400381D RID: 14365
		private int selectedVillage = -1;

		// Token: 0x0400381E RID: 14366
		private DockableControl dockableControl;

		// Token: 0x0400381F RID: 14367
		private IContainer components;
	}
}
