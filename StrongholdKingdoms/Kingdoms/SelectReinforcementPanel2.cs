using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x02000482 RID: 1154
	public class SelectReinforcementPanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x060029F9 RID: 10745 RVA: 0x0001EDF8 File Offset: 0x0001CFF8
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x060029FA RID: 10746 RVA: 0x0001EE08 File Offset: 0x0001D008
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x060029FB RID: 10747 RVA: 0x0001EE18 File Offset: 0x0001D018
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x060029FC RID: 10748 RVA: 0x0001EE2A File Offset: 0x0001D02A
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x060029FD RID: 10749 RVA: 0x0001EE37 File Offset: 0x0001D037
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x060029FE RID: 10750 RVA: 0x0001EE45 File Offset: 0x0001D045
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x060029FF RID: 10751 RVA: 0x0001EE52 File Offset: 0x0001D052
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06002A00 RID: 10752 RVA: 0x0001EE5F File Offset: 0x0001D05F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002A01 RID: 10753 RVA: 0x002073D4 File Offset: 0x002055D4
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Name = "SelectReinforcementPanel2";
			base.Size = new Size(199, 213);
			base.ResumeLayout(false);
		}

		// Token: 0x06002A02 RID: 10754 RVA: 0x00207420 File Offset: 0x00205620
		public SelectReinforcementPanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SelfDrawBackground = true;
		}

		// Token: 0x06002A03 RID: 10755 RVA: 0x002074A8 File Offset: 0x002056A8
		public void init()
		{
			base.clearControls();
			CustomSelfDrawPanel.CSDImage csdimage = this.backGround.init(true, 1003);
			this.backGround.updateHeading(SK.Text("SelectArmyPanel_Reinforcements", "Reinforcements"));
			this.backGround.centerSubHeading();
			base.addControl(this.backGround);
			this.backGround.initTravelButton(this.homeVillageButton);
			this.homeVillageButton.Position = new Point(11, 61);
			this.homeVillageButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.homeClick), "SelectReinforcementPanel2_home_village");
			csdimage.addControl(this.homeVillageButton);
			this.backGround.initTravelButton(this.targetVillageButton);
			this.targetVillageButton.Position = new Point(11, 119);
			this.targetVillageButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.targetClick), "SelectReinforcementPanel2_target_village");
			csdimage.addControl(this.targetVillageButton);
			this.travelDirection.Image = GFXLibrary.mrhp_travelling_arrows[0];
			this.travelDirection.Alpha = 0.5f;
			this.travelDirection.Position = new Point(88, 90);
			csdimage.addControl(this.travelDirection);
			this.returnButton.ImageNorm = GFXLibrary.mrhp_button_150x25[0];
			this.returnButton.ImageOver = GFXLibrary.mrhp_button_150x25[1];
			this.returnButton.ImageClick = GFXLibrary.mrhp_button_150x25[2];
			this.returnButton.Position = new Point(26, 155);
			this.returnButton.Text.Text = "";
			this.returnButton.TextYOffset = -3;
			this.returnButton.Text.Color = global::ARGBColors.Black;
			this.returnButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.returnButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.returnClick), "SelectReinforcementPanel2_return");
			this.returnButton.Visible = false;
			csdimage.addControl(this.returnButton);
		}

		// Token: 0x06002A04 RID: 10756 RVA: 0x002076C8 File Offset: 0x002058C8
		public void update()
		{
			this.backGround.update();
			this.m_reinforcements = GameEngine.Instance.World.getReinforcement(this.selectedReinforcementID);
			if (this.m_reinforcements == null)
			{
				InterfaceMgr.Instance.closeReinforcementSelectedPanel();
				return;
			}
			if (this.m_reinforcements.dead)
			{
				this.m_reinforcements = null;
				InterfaceMgr.Instance.closeReinforcementSelectedPanel();
				return;
			}
			if (this.m_reinforcements.attackType != this.lastState)
			{
				this.backGround.updateTravelButton(this.homeVillageButton, this.m_reinforcements.homeVillageID);
				this.backGround.updateTravelButton(this.targetVillageButton, this.m_reinforcements.targetVillageID);
				this.fromVillageID = this.m_reinforcements.homeVillageID;
				this.toVillageID = this.m_reinforcements.targetVillageID;
				this.lastState = this.m_reinforcements.attackType;
				if (this.lastState == 20)
				{
					this.travelDirection.Image = GFXLibrary.mrhp_travelling_arrows[0];
					if (GameEngine.Instance.World.isUserVillage(this.m_reinforcements.homeVillageID))
					{
						this.returnButton.Visible = true;
					}
					else
					{
						this.returnButton.Visible = false;
					}
					if (GameEngine.Instance.World.isUserVillage(this.m_reinforcements.homeVillageID))
					{
						this.returnButton.Text.TextDiffOnly = SK.Text("SelectArmyPanel_Retrieve", "Retrieve");
					}
					else
					{
						this.returnButton.Text.TextDiffOnly = SK.Text("SelectArmyPanel_Return", "Return");
					}
				}
				else
				{
					this.travelDirection.Image = GFXLibrary.mrhp_travelling_arrows[1];
					this.returnButton.Visible = false;
				}
			}
			double num = DXTimer.GetCurrentMilliseconds() / 1000.0;
			double num2 = this.m_reinforcements.localEndTime - num;
			if (num2 < 0.0)
			{
				this.backGround.updateSubHeading("");
				return;
			}
			string subHeading = VillageMap.createBuildTimeString((int)num2);
			this.backGround.updateSubHeading(subHeading);
		}

		// Token: 0x06002A05 RID: 10757 RVA: 0x002078DC File Offset: 0x00205ADC
		public void reinforcementSelected(long reinforcementID)
		{
			WorldMap.LocalArmyData reinforcement = GameEngine.Instance.World.getReinforcement(reinforcementID);
			if (reinforcement != null)
			{
				this.selectedReinforcementID = reinforcementID;
				this.m_reinforcements = reinforcement;
				this.lastState = -2;
				this.update();
				return;
			}
			InterfaceMgr.Instance.closeReinforcementSelectedPanel();
			this.m_reinforcements = null;
		}

		// Token: 0x06002A06 RID: 10758 RVA: 0x0001EE7E File Offset: 0x0001D07E
		private void homeClick()
		{
			if (this.m_reinforcements != null && this.fromVillageID >= 0)
			{
				GameEngine.Instance.World.zoomToVillage(this.fromVillageID);
			}
		}

		// Token: 0x06002A07 RID: 10759 RVA: 0x0001EEA6 File Offset: 0x0001D0A6
		private void targetClick()
		{
			if (this.m_reinforcements != null && this.toVillageID >= 0)
			{
				GameEngine.Instance.World.zoomToVillage(this.toVillageID);
			}
		}

		// Token: 0x06002A08 RID: 10760 RVA: 0x0020792C File Offset: 0x00205B2C
		private void returnClick()
		{
			if (!GameEngine.Instance.World.WorldEnded && this.m_reinforcements != null)
			{
				RemoteServices.Instance.set_ReturnReinforcements_UserCallBack(new RemoteServices.ReturnReinforcements_UserCallBack(this.returnReinforcementsCallBack));
				RemoteServices.Instance.ReturnReinforcements(this.m_reinforcements.armyID);
				this.returnButton.Visible = false;
			}
		}

		// Token: 0x06002A09 RID: 10761 RVA: 0x0020798C File Offset: 0x00205B8C
		private void returnReinforcementsCallBack(ReturnReinforcements_ReturnType returnData)
		{
			if (returnData.Success)
			{
				if (returnData.armyData != null)
				{
					GameEngine.Instance.World.addReinforcementArmy(returnData.armyData);
				}
				if (returnData.armyData2 != null)
				{
					GameEngine.Instance.World.addReinforcementArmy(returnData.armyData2);
				}
				this.update();
				this.returnButton.Visible = false;
			}
		}

		// Token: 0x06002A0A RID: 10762 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x0400338F RID: 13199
		private DockableControl dockableControl;

		// Token: 0x04003390 RID: 13200
		private IContainer components;

		// Token: 0x04003391 RID: 13201
		private CustomSelfDrawPanel.MRHP_Background backGround = new CustomSelfDrawPanel.MRHP_Background();

		// Token: 0x04003392 RID: 13202
		private CustomSelfDrawPanel.CSDButton homeVillageButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003393 RID: 13203
		private CustomSelfDrawPanel.CSDButton targetVillageButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003394 RID: 13204
		private CustomSelfDrawPanel.CSDImage travelDirection = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003395 RID: 13205
		private CustomSelfDrawPanel.CSDButton returnButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003396 RID: 13206
		private int fromVillageID = -1;

		// Token: 0x04003397 RID: 13207
		private int toVillageID = -1;

		// Token: 0x04003398 RID: 13208
		private int lastState = -2;

		// Token: 0x04003399 RID: 13209
		private WorldMap.LocalArmyData m_reinforcements;

		// Token: 0x0400339A RID: 13210
		private long selectedReinforcementID;
	}
}
