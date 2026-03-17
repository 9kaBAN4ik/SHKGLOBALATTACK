using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000246 RID: 582
	public class MonkTargetSidePanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x060019BD RID: 6589 RVA: 0x00019E86 File Offset: 0x00018086
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x060019BE RID: 6590 RVA: 0x00019E96 File Offset: 0x00018096
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x060019BF RID: 6591 RVA: 0x00019EA6 File Offset: 0x000180A6
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x060019C0 RID: 6592 RVA: 0x00019EB8 File Offset: 0x000180B8
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x060019C1 RID: 6593 RVA: 0x00019EC5 File Offset: 0x000180C5
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x060019C2 RID: 6594 RVA: 0x00019ED3 File Offset: 0x000180D3
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x060019C3 RID: 6595 RVA: 0x00019EE0 File Offset: 0x000180E0
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x060019C4 RID: 6596 RVA: 0x00019EED File Offset: 0x000180ED
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060019C5 RID: 6597 RVA: 0x0019A5F4 File Offset: 0x001987F4
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Name = "MonkTargetSidePanel2";
			base.Size = new Size(199, 213);
			base.ResumeLayout(false);
		}

		// Token: 0x060019C6 RID: 6598 RVA: 0x0019A640 File Offset: 0x00198840
		public MonkTargetSidePanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SelfDrawBackground = true;
		}

		// Token: 0x060019C7 RID: 6599 RVA: 0x0019A6A0 File Offset: 0x001988A0
		public void init()
		{
			base.clearControls();
			CustomSelfDrawPanel.CSDImage csdimage = this.backGround.init(false, 10000);
			this.backGround.updatePanelText(SK.Text("MonkTargetSidePanel_", "Select Monk Target"));
			this.backGround.setAction(1001);
			base.addControl(this.backGround);
			this.okButton.ImageNorm = GFXLibrary.mrhp_button_check_normal;
			this.okButton.ImageOver = GFXLibrary.mrhp_button_check_over;
			this.okButton.ImageClick = GFXLibrary.mrhp_button_check_pushed;
			this.okButton.Position = new Point(102, 64);
			this.okButton.Enabled = false;
			this.okButton.CustomTooltipID = 2406;
			this.okButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.selectTargetClick), "MonkTargetSidePanel2_ok");
			csdimage.addControl(this.okButton);
			this.cancelButton.ImageNorm = GFXLibrary.mrhp_button_x_normal;
			this.cancelButton.ImageOver = GFXLibrary.mrhp_button_x_over;
			this.cancelButton.ImageClick = GFXLibrary.mrhp_button_x_pushed;
			this.cancelButton.Position = new Point(20, 64);
			this.cancelButton.CustomTooltipID = 2400;
			this.cancelButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.cancelClick), "MonkTargetSidePanel2_cancel");
			csdimage.addControl(this.cancelButton);
		}

		// Token: 0x060019C8 RID: 6600 RVA: 0x00019F0C File Offset: 0x0001810C
		public void update()
		{
			this.backGround.update();
		}

		// Token: 0x060019C9 RID: 6601 RVA: 0x00019F19 File Offset: 0x00018119
		private void selectTargetClick()
		{
			if (this.selectedVillage >= 0)
			{
				InterfaceMgr.Instance.openSendMonkWindow(this.selectedVillage);
			}
		}

		// Token: 0x060019CA RID: 6602 RVA: 0x0000B220 File Offset: 0x00009420
		private void cancelClick()
		{
			InterfaceMgr.Instance.getMainTabBar().changeTab(0);
		}

		// Token: 0x060019CB RID: 6603 RVA: 0x0019A820 File Offset: 0x00198A20
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

		// Token: 0x04002A46 RID: 10822
		private DockableControl dockableControl;

		// Token: 0x04002A47 RID: 10823
		private IContainer components;

		// Token: 0x04002A48 RID: 10824
		private CustomSelfDrawPanel.MRHP_Background backGround = new CustomSelfDrawPanel.MRHP_Background();

		// Token: 0x04002A49 RID: 10825
		private CustomSelfDrawPanel.CSDButton okButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002A4A RID: 10826
		private CustomSelfDrawPanel.CSDButton cancelButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002A4B RID: 10827
		private int selectedVillage = -1;
	}
}
