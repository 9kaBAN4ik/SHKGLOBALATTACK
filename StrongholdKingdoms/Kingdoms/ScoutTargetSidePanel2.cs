using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x0200047E RID: 1150
	public class ScoutTargetSidePanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x060029C6 RID: 10694 RVA: 0x0001EB8D File Offset: 0x0001CD8D
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x060029C7 RID: 10695 RVA: 0x0001EB9D File Offset: 0x0001CD9D
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x060029C8 RID: 10696 RVA: 0x0001EBAD File Offset: 0x0001CDAD
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x060029C9 RID: 10697 RVA: 0x0001EBBF File Offset: 0x0001CDBF
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x060029CA RID: 10698 RVA: 0x0001EBCC File Offset: 0x0001CDCC
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x060029CB RID: 10699 RVA: 0x0001EBDA File Offset: 0x0001CDDA
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x060029CC RID: 10700 RVA: 0x0001EBE7 File Offset: 0x0001CDE7
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x060029CD RID: 10701 RVA: 0x0001EBF4 File Offset: 0x0001CDF4
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060029CE RID: 10702 RVA: 0x0020587C File Offset: 0x00203A7C
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Name = "ScoutTargetSidePanel2";
			base.Size = new Size(199, 213);
			base.ResumeLayout(false);
		}

		// Token: 0x060029CF RID: 10703 RVA: 0x002058C8 File Offset: 0x00203AC8
		public ScoutTargetSidePanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SelfDrawBackground = true;
		}

		// Token: 0x060029D0 RID: 10704 RVA: 0x00205928 File Offset: 0x00203B28
		public void init()
		{
			base.clearControls();
			CustomSelfDrawPanel.CSDImage csdimage = this.backGround.init(false, 10000);
			this.backGround.updatePanelText(SK.Text("ScoutTargetSidePanel_Select_Scout_Target", "Select Scout Target"));
			this.backGround.setAction(1002);
			base.addControl(this.backGround);
			this.okButton.ImageNorm = GFXLibrary.mrhp_button_check_normal;
			this.okButton.ImageOver = GFXLibrary.mrhp_button_check_over;
			this.okButton.ImageClick = GFXLibrary.mrhp_button_check_pushed;
			this.okButton.Position = new Point(102, 64);
			this.okButton.Enabled = false;
			this.okButton.CustomTooltipID = 2405;
			this.okButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.selectTargetClick), "ScoutTargetSidePanel2_ok");
			csdimage.addControl(this.okButton);
			this.cancelButton.ImageNorm = GFXLibrary.mrhp_button_x_normal;
			this.cancelButton.ImageOver = GFXLibrary.mrhp_button_x_over;
			this.cancelButton.ImageClick = GFXLibrary.mrhp_button_x_pushed;
			this.cancelButton.Position = new Point(20, 64);
			this.cancelButton.CustomTooltipID = 2400;
			this.cancelButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.cancelClick), "ScoutTargetSidePanel2_cancel");
			csdimage.addControl(this.cancelButton);
		}

		// Token: 0x060029D1 RID: 10705 RVA: 0x0001EC13 File Offset: 0x0001CE13
		public void update()
		{
			this.backGround.update();
		}

		// Token: 0x060029D2 RID: 10706 RVA: 0x0001EC20 File Offset: 0x0001CE20
		private void selectTargetClick()
		{
			InterfaceMgr.Instance.openScoutPopupWindow(this.selectedVillage, false);
		}

		// Token: 0x060029D3 RID: 10707 RVA: 0x0000B220 File Offset: 0x00009420
		private void cancelClick()
		{
			InterfaceMgr.Instance.getMainTabBar().changeTab(0);
		}

		// Token: 0x060029D4 RID: 10708 RVA: 0x00205AA8 File Offset: 0x00203CA8
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

		// Token: 0x04003371 RID: 13169
		private DockableControl dockableControl;

		// Token: 0x04003372 RID: 13170
		private IContainer components;

		// Token: 0x04003373 RID: 13171
		private CustomSelfDrawPanel.MRHP_Background backGround = new CustomSelfDrawPanel.MRHP_Background();

		// Token: 0x04003374 RID: 13172
		private CustomSelfDrawPanel.CSDButton okButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003375 RID: 13173
		private CustomSelfDrawPanel.CSDButton cancelButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003376 RID: 13174
		private int selectedVillage = -1;
	}
}
