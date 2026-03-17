using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020002B5 RID: 693
	public class ReinforcementTargetSidePanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06001EF9 RID: 7929 RVA: 0x0001D7A7 File Offset: 0x0001B9A7
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06001EFA RID: 7930 RVA: 0x0001D7B7 File Offset: 0x0001B9B7
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06001EFB RID: 7931 RVA: 0x0001D7C7 File Offset: 0x0001B9C7
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06001EFC RID: 7932 RVA: 0x0001D7D9 File Offset: 0x0001B9D9
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06001EFD RID: 7933 RVA: 0x0001D7E6 File Offset: 0x0001B9E6
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x06001EFE RID: 7934 RVA: 0x0001D7F4 File Offset: 0x0001B9F4
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06001EFF RID: 7935 RVA: 0x0001D801 File Offset: 0x0001BA01
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06001F00 RID: 7936 RVA: 0x0001D80E File Offset: 0x0001BA0E
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001F01 RID: 7937 RVA: 0x001DDD94 File Offset: 0x001DBF94
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Name = "ReinforcementTargetSidePanel2";
			base.Size = new Size(199, 213);
			base.ResumeLayout(false);
		}

		// Token: 0x06001F02 RID: 7938 RVA: 0x001DDDE0 File Offset: 0x001DBFE0
		public ReinforcementTargetSidePanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SelfDrawBackground = true;
		}

		// Token: 0x06001F03 RID: 7939 RVA: 0x001DDE40 File Offset: 0x001DC040
		public void init()
		{
			base.clearControls();
			CustomSelfDrawPanel.CSDImage csdimage = this.backGround.init(false, 10000);
			this.backGround.updatePanelText(SK.Text("ReinforcementTargetSidePanel_Select_Reinforcement_Target", "Select Reinforcement Target"));
			this.backGround.setAction(1003);
			base.addControl(this.backGround);
			this.okButton.ImageNorm = GFXLibrary.mrhp_button_check_normal;
			this.okButton.ImageOver = GFXLibrary.mrhp_button_check_over;
			this.okButton.ImageClick = GFXLibrary.mrhp_button_check_pushed;
			this.okButton.Position = new Point(102, 64);
			this.okButton.Enabled = false;
			this.okButton.CustomTooltipID = 2402;
			this.okButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.selectTargetClick), "ReinforcementTargetSidePanel2_ok");
			csdimage.addControl(this.okButton);
			this.cancelButton.ImageNorm = GFXLibrary.mrhp_button_x_normal;
			this.cancelButton.ImageOver = GFXLibrary.mrhp_button_x_over;
			this.cancelButton.ImageClick = GFXLibrary.mrhp_button_x_pushed;
			this.cancelButton.Position = new Point(20, 64);
			this.cancelButton.CustomTooltipID = 2400;
			this.cancelButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.cancelClick), "ReinforcementTargetSidePanel2_cancel");
			csdimage.addControl(this.cancelButton);
		}

		// Token: 0x06001F04 RID: 7940 RVA: 0x0001D82D File Offset: 0x0001BA2D
		public void update()
		{
			this.backGround.update();
		}

		// Token: 0x06001F05 RID: 7941 RVA: 0x001DDFC0 File Offset: 0x001DC1C0
		private void selectTargetClick()
		{
			if (!GameEngine.Instance.World.WorldEnded)
			{
				if (GameEngine.Instance.World.isCapital(this.selectedVillage) && GameEngine.Instance.World.isUserVillage(this.selectedVillage))
				{
					GameEngine.Instance.SkipVillageTab();
					InterfaceMgr.Instance.getMainTabBar().changeTab(1);
					InterfaceMgr.Instance.setCapitalSendTargetVillage(this.selectedVillage);
					InterfaceMgr.Instance.setVillageTabSubMode(17);
					return;
				}
				GameEngine.Instance.SkipVillageTab();
				InterfaceMgr.Instance.getMainTabBar().changeTab(1);
				InterfaceMgr.Instance.setVillageTabSubMode(6);
				InterfaceMgr.Instance.getVillageTabBar().changeTabGfxOnly(9);
				InterfaceMgr.Instance.setReinforcementVillage(this.selectedVillage);
			}
		}

		// Token: 0x06001F06 RID: 7942 RVA: 0x0000B220 File Offset: 0x00009420
		private void cancelClick()
		{
			InterfaceMgr.Instance.getMainTabBar().changeTab(0);
		}

		// Token: 0x06001F07 RID: 7943 RVA: 0x001DE08C File Offset: 0x001DC28C
		public void setReinforcementTarget(int villageID)
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

		// Token: 0x04002FEA RID: 12266
		private DockableControl dockableControl;

		// Token: 0x04002FEB RID: 12267
		private IContainer components;

		// Token: 0x04002FEC RID: 12268
		private CustomSelfDrawPanel.MRHP_Background backGround = new CustomSelfDrawPanel.MRHP_Background();

		// Token: 0x04002FED RID: 12269
		private CustomSelfDrawPanel.CSDButton okButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002FEE RID: 12270
		private CustomSelfDrawPanel.CSDButton cancelButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002FEF RID: 12271
		private int selectedVillage = -1;
	}
}
