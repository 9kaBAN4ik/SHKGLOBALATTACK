using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x02000270 RID: 624
	public class PersonInfoPanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06001BD3 RID: 7123 RVA: 0x0001B91B File Offset: 0x00019B1B
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06001BD4 RID: 7124 RVA: 0x0001B92B File Offset: 0x00019B2B
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06001BD5 RID: 7125 RVA: 0x0001B93B File Offset: 0x00019B3B
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06001BD6 RID: 7126 RVA: 0x0001B94D File Offset: 0x00019B4D
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06001BD7 RID: 7127 RVA: 0x0001B95A File Offset: 0x00019B5A
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x06001BD8 RID: 7128 RVA: 0x0001B968 File Offset: 0x00019B68
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06001BD9 RID: 7129 RVA: 0x0001B975 File Offset: 0x00019B75
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06001BDA RID: 7130 RVA: 0x0001B982 File Offset: 0x00019B82
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001BDB RID: 7131 RVA: 0x001B23CC File Offset: 0x001B05CC
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Name = "PersonInfoPanel2";
			base.Size = new Size(199, 213);
			base.ResumeLayout(false);
		}

		// Token: 0x06001BDC RID: 7132 RVA: 0x001B2418 File Offset: 0x001B0618
		public PersonInfoPanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SelfDrawBackground = true;
		}

		// Token: 0x06001BDD RID: 7133 RVA: 0x001B2484 File Offset: 0x001B0684
		public void init()
		{
			base.clearControls();
			CustomSelfDrawPanel.CSDImage csdimage = this.backGround.init(true, 1001);
			this.backGround.centerSubHeading();
			base.addControl(this.backGround);
			this.backGround.initTravelButton(this.homeVillageButton);
			this.homeVillageButton.Position = new Point(11, 61);
			this.homeVillageButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.homeClick), "PersonInfoPanel2_home_village");
			csdimage.addControl(this.homeVillageButton);
			this.backGround.initTravelButton(this.targetVillageButton);
			this.targetVillageButton.Position = new Point(11, 119);
			this.targetVillageButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.targetClick), "PersonInfoPanel2_target_village");
			csdimage.addControl(this.targetVillageButton);
			this.travelDirection.Image = GFXLibrary.mrhp_travelling_arrows[0];
			this.travelDirection.Position = new Point(88, 90);
			this.travelDirection.Alpha = 0.5f;
			csdimage.addControl(this.travelDirection);
		}

		// Token: 0x06001BDE RID: 7134 RVA: 0x001B25A4 File Offset: 0x001B07A4
		public void setPerson(long personID)
		{
			WorldMap.LocalPerson person = GameEngine.Instance.World.getPerson(personID);
			if (person != null)
			{
				int personType = person.person.personType;
				if (personType != 4)
				{
					if (personType == 100)
					{
						this.backGround.updatePanelType(1006);
						this.backGround.updateHeading(SK.Text("PersonInfoPanel_Disease_Rat", "Disease Rat"));
					}
				}
				else
				{
					this.backGround.updatePanelType(1001);
					this.backGround.updateHeading(SK.Text("PersonInfoPanel_Monk", "Monk"));
				}
				this.m_person = person;
				this.lastState = -1;
				this.update();
				return;
			}
			InterfaceMgr.Instance.closePersonInfoPanel();
		}

		// Token: 0x06001BDF RID: 7135 RVA: 0x001B2654 File Offset: 0x001B0854
		public void update()
		{
			this.backGround.update();
			if (this.m_person != null && !this.m_person.dying)
			{
				if (this.m_person.person.state != this.lastState)
				{
					this.backGround.updateTravelButton(this.homeVillageButton, this.m_person.person.homeVillageID);
					this.backGround.updateTravelButton(this.targetVillageButton, this.m_person.person.targetVillageID);
					this.lastState = this.m_person.person.state;
					if (this.lastState == 0)
					{
						InterfaceMgr.Instance.closePersonInfoPanel();
						return;
					}
					if (this.lastState == 1 || this.lastState == 11 || this.lastState == 21 || this.lastState == 31 || this.lastState == 75)
					{
						this.travelDirection.Image = GFXLibrary.mrhp_travelling_arrows[0];
					}
					else if (this.lastState == 50)
					{
						this.travelDirection.Image = GFXLibrary.mrhp_travelling_arrows[1];
					}
				}
				double num = DXTimer.GetCurrentMilliseconds() / 1000.0;
				double num2 = this.m_person.localEndTime - num;
				string subHeading = VillageMap.createBuildTimeString((int)num2);
				this.backGround.updateSubHeading(subHeading);
				return;
			}
			InterfaceMgr.Instance.closePersonInfoPanel();
		}

		// Token: 0x06001BE0 RID: 7136 RVA: 0x001B27B8 File Offset: 0x001B09B8
		private void btnFromVillage_Click(object sender, EventArgs e)
		{
			if (this.m_person != null)
			{
				if (this.m_person.person.state == 1 || this.m_person.person.state == 11 || this.m_person.person.state == 21 || this.lastState == 31 || this.lastState == 75)
				{
					GameEngine.Instance.World.zoomToVillage(this.m_person.person.homeVillageID);
					return;
				}
				if (this.m_person.person.state == 50)
				{
					GameEngine.Instance.World.zoomToVillage(this.m_person.person.targetVillageID);
				}
			}
		}

		// Token: 0x06001BE1 RID: 7137 RVA: 0x001B2874 File Offset: 0x001B0A74
		private void btnToVillage_Click(object sender, EventArgs e)
		{
			if (this.m_person != null)
			{
				if (this.m_person.person.state == 50)
				{
					GameEngine.Instance.World.zoomToVillage(this.m_person.person.homeVillageID);
					return;
				}
				if (this.m_person.person.state == 1 || this.m_person.person.state == 11 || this.m_person.person.state == 21 || this.lastState == 31 || this.lastState == 75)
				{
					GameEngine.Instance.World.zoomToVillage(this.m_person.person.targetVillageID);
				}
			}
		}

		// Token: 0x06001BE2 RID: 7138 RVA: 0x0001B9A1 File Offset: 0x00019BA1
		private void homeClick()
		{
			if (this.m_person != null)
			{
				GameEngine.Instance.World.zoomToVillage(this.m_person.person.homeVillageID);
			}
		}

		// Token: 0x06001BE3 RID: 7139 RVA: 0x0001B9CA File Offset: 0x00019BCA
		private void targetClick()
		{
			if (this.m_person != null)
			{
				GameEngine.Instance.World.zoomToVillage(this.m_person.person.targetVillageID);
			}
		}

		// Token: 0x04002C97 RID: 11415
		private DockableControl dockableControl;

		// Token: 0x04002C98 RID: 11416
		private IContainer components;

		// Token: 0x04002C99 RID: 11417
		private CustomSelfDrawPanel.MRHP_Background backGround = new CustomSelfDrawPanel.MRHP_Background();

		// Token: 0x04002C9A RID: 11418
		private CustomSelfDrawPanel.CSDButton homeVillageButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C9B RID: 11419
		private CustomSelfDrawPanel.CSDButton targetVillageButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C9C RID: 11420
		private CustomSelfDrawPanel.CSDImage travelDirection = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002C9D RID: 11421
		private WorldMap.LocalPerson m_person;

		// Token: 0x04002C9E RID: 11422
		private int lastState = -1;
	}
}
