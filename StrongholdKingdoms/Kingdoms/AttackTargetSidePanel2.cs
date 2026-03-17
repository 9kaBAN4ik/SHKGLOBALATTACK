using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020000D2 RID: 210
	public class AttackTargetSidePanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x060005EC RID: 1516 RVA: 0x0007900C File Offset: 0x0007720C
		public AttackTargetSidePanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SelfDrawBackground = true;
		}

		// Token: 0x060005ED RID: 1517 RVA: 0x0007906C File Offset: 0x0007726C
		public void init()
		{
			base.clearControls();
			CustomSelfDrawPanel.CSDImage csdimage = this.backGround.init(false, 10000);
			this.backGround.updatePanelText(SK.Text("AttackTargetSidePanel_Select_Attack_Target", "Select Attack Target"));
			this.backGround.setAction(1000);
			base.addControl(this.backGround);
			this.okButton.ImageNorm = GFXLibrary.mrhp_button_check_normal;
			this.okButton.ImageOver = GFXLibrary.mrhp_button_check_over;
			this.okButton.ImageClick = GFXLibrary.mrhp_button_check_pushed;
			this.okButton.Position = new Point(102, 64);
			this.okButton.Enabled = false;
			this.okButton.CustomTooltipID = 2401;
			this.okButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.selectTargetClick), "AttackTargetSidePanel2_ok");
			csdimage.addControl(this.okButton);
			this.cancelButton.ImageNorm = GFXLibrary.mrhp_button_x_normal;
			this.cancelButton.ImageOver = GFXLibrary.mrhp_button_x_over;
			this.cancelButton.ImageClick = GFXLibrary.mrhp_button_x_pushed;
			this.cancelButton.Position = new Point(20, 64);
			this.cancelButton.CustomTooltipID = 2400;
			this.cancelButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.cancelClick), "AttackTargetSidePanel2_cancel");
			csdimage.addControl(this.cancelButton);
		}

		// Token: 0x060005EE RID: 1518 RVA: 0x0000B213 File Offset: 0x00009413
		public void update()
		{
			this.backGround.update();
		}

		// Token: 0x060005EF RID: 1519 RVA: 0x000791EC File Offset: 0x000773EC
		private void selectTargetClick()
		{
			if (GameEngine.Instance.World.isCapital(this.selectedVillage) && GameEngine.Instance.World.isUserVillage(this.selectedVillage))
			{
				GameEngine.Instance.SkipVillageTab();
				InterfaceMgr.Instance.getMainTabBar().changeTab(1);
				InterfaceMgr.Instance.setCapitalSendTargetVillage(this.selectedVillage);
				InterfaceMgr.Instance.setVillageTabSubMode(17);
				return;
			}
			GameEngine.Instance.preAttackSetup(InterfaceMgr.Instance.OwnSelectedVillage, InterfaceMgr.Instance.OwnSelectedVillage, this.selectedVillage);
		}

		// Token: 0x060005F0 RID: 1520 RVA: 0x0000B220 File Offset: 0x00009420
		private void cancelClick()
		{
			InterfaceMgr.Instance.getMainTabBar().changeTab(0);
		}

		// Token: 0x060005F1 RID: 1521 RVA: 0x00079284 File Offset: 0x00077484
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

		// Token: 0x060005F2 RID: 1522 RVA: 0x0000B232 File Offset: 0x00009432
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x060005F3 RID: 1523 RVA: 0x0000B242 File Offset: 0x00009442
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x0000B252 File Offset: 0x00009452
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x0000B264 File Offset: 0x00009464
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x060005F6 RID: 1526 RVA: 0x0000B271 File Offset: 0x00009471
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x060005F7 RID: 1527 RVA: 0x0000B27F File Offset: 0x0000947F
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x0000B28C File Offset: 0x0000948C
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x0000B299 File Offset: 0x00009499
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x00079310 File Offset: 0x00077510
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Name = "AttackTargetSidePanel2";
			base.Size = new Size(199, 213);
			base.ResumeLayout(false);
		}

		// Token: 0x040007A3 RID: 1955
		private CustomSelfDrawPanel.MRHP_Background backGround = new CustomSelfDrawPanel.MRHP_Background();

		// Token: 0x040007A4 RID: 1956
		private CustomSelfDrawPanel.CSDButton okButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040007A5 RID: 1957
		private CustomSelfDrawPanel.CSDButton cancelButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040007A6 RID: 1958
		private int selectedVillage = -1;

		// Token: 0x040007A7 RID: 1959
		private DockableControl dockableControl;

		// Token: 0x040007A8 RID: 1960
		private IContainer components;
	}
}
