using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x02000481 RID: 1153
	public class SelectArmyPanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x060029E6 RID: 10726 RVA: 0x002069E0 File Offset: 0x00204BE0
		public SelectArmyPanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SelfDrawBackground = true;
		}

		// Token: 0x060029E7 RID: 10727 RVA: 0x00206A68 File Offset: 0x00204C68
		public void init()
		{
			base.clearControls();
			CustomSelfDrawPanel.CSDImage csdimage = this.backGround.init(true, 1000);
			this.backGround.centerSubHeading();
			base.addControl(this.backGround);
			this.backGround.initTravelButton(this.homeVillageButton);
			this.homeVillageButton.Position = new Point(11, 61);
			this.homeVillageButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.homeClick), "SelectArmyPanel2_home_village");
			csdimage.addControl(this.homeVillageButton);
			this.backGround.initTravelButton(this.targetVillageButton);
			this.targetVillageButton.Position = new Point(11, 119);
			this.targetVillageButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.targetClick), "SelectArmyPanel2_target_village");
			csdimage.addControl(this.targetVillageButton);
			this.travelDirection.Image = GFXLibrary.mrhp_travelling_arrows[0];
			this.travelDirection.Position = new Point(88, 90);
			this.travelDirection.Alpha = 0.5f;
			csdimage.addControl(this.travelDirection);
			this.returnButton.ImageNorm = GFXLibrary.mrhp_button_150x25[0];
			this.returnButton.ImageOver = GFXLibrary.mrhp_button_150x25[1];
			this.returnButton.ImageClick = GFXLibrary.mrhp_button_150x25[2];
			this.returnButton.Position = new Point(26, 155);
			this.returnButton.Text.Text = SK.Text("GENERIC_Cancel", "Cancel");
			this.returnButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.returnButton.TextYOffset = -3;
			this.returnButton.Text.Color = global::ARGBColors.Black;
			this.returnButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.cancelClick), "SelectArmyPanel2_cancel");
			this.returnButton.Visible = false;
			csdimage.addControl(this.returnButton);
			this.forceReturnOff = false;
		}

		// Token: 0x060029E8 RID: 10728 RVA: 0x00206C80 File Offset: 0x00204E80
		public void update()
		{
			this.backGround.update();
			this.m_army = GameEngine.Instance.World.getArmy(this.selectedArmyID);
			if (this.m_army == null)
			{
				InterfaceMgr.Instance.closeArmySelectedPanel();
				return;
			}
			if (this.m_army.dead)
			{
				this.m_army = null;
				InterfaceMgr.Instance.closeArmySelectedPanel();
				return;
			}
			double num = DXTimer.GetCurrentMilliseconds() / 1000.0;
			double num2 = this.m_army.localEndTime - num;
			if (num2 < 0.0)
			{
				num2 = 0.0;
			}
			string subHeading = VillageMap.createBuildTimeString((int)num2);
			if (!GameEngine.Instance.World.isUserVillage(this.m_army.homeVillageID) || (this.m_army.localStartTime + (double)(GameEngine.Instance.LocalWorldData.AttackCancelDuration * 60) < num && !this.m_army.isScouts() && !this.targetIsAI(this.m_army.targetVillageID)) || this.m_army.lootType >= 0 || this.forceReturnOff)
			{
				this.returnButton.Visible = false;
			}
			else
			{
				this.returnButton.Visible = true;
			}
			if (this.m_army.lootType != this.lastState)
			{
				bool flag = false;
				if (this.m_army.attackType == 30 || this.m_army.attackType == 31)
				{
					this.backGround.updateHeading(SK.Text("SelectArmyPanel_Troops", "Troops"));
					this.backGround.updatePanelType(1000);
				}
				else if (this.m_army.attackType == 17)
				{
					this.backGround.updateHeading(SK.Text("GENERIC_Invasion", "Invasion"));
					this.backGround.updatePanelType(1000);
				}
				else if (!this.m_army.isScouts())
				{
					this.backGround.updateHeading(SK.Text("SelectArmyPanel_Army", "Army"));
					this.backGround.updatePanelType(1000);
				}
				else
				{
					flag = true;
					this.backGround.updatePanelType(1002);
					this.backGround.updateHeading(SK.Text("SelectArmyPanel_Scouts", "Scouts"));
				}
				this.lastState = this.m_army.lootType;
				if (this.lastState < 0)
				{
					this.travelDirection.Image = GFXLibrary.mrhp_travelling_arrows[0];
					if (this.m_army.attackType == 30 || this.m_army.attackType == 31)
					{
						this.backGround.updatePanelText(SK.Text("SelectArmyPanel_Stationing", "Stationing"));
					}
					else if (!flag)
					{
						if (GameEngine.Instance.LocalWorldData.AIWorld && this.m_army.attackType == 17)
						{
							bool flag2 = false;
							int special = GameEngine.Instance.World.getVillageData(this.m_army.travelFromVillageID).special;
							int special2 = GameEngine.Instance.World.getVillageData(this.m_army.targetVillageID).special;
							if (special == 30 && special2 - 7 <= 7)
							{
								this.backGround.updatePanelText(SK.Text("BARRACKS_Reinforcing", "Reinforcing"));
								flag2 = true;
							}
							if (!flag2)
							{
								this.backGround.updatePanelText(SK.Text("GENERIC_Attacking", "Attacking"));
							}
						}
						else
						{
							this.backGround.updatePanelText(SK.Text("GENERIC_Attacking", "Attacking"));
						}
					}
					else
					{
						this.backGround.updatePanelText(SK.Text("SelectArmyPanel_Scouting", "Scouting"));
					}
					if (this.m_army.attackType != 13)
					{
						this.backGround.updateTravelButton(this.homeVillageButton, this.m_army.travelFromVillageID);
					}
					else
					{
						this.backGround.updateTravelButton(this.homeVillageButton, SK.Text("SelectArmyPanel_Tutorial", "Tutorial"));
					}
					this.backGround.updateTravelButton(this.targetVillageButton, this.m_army.targetVillageID);
					if (flag && this.homeVillageButton.Text.Text.Length == 0)
					{
						this.backGround.updateTravelButton(this.targetVillageButton, SK.Text("GENERIC_Unknown", "Unknown"));
					}
					this.fromVillageID = this.m_army.travelFromVillageID;
					this.toVillageID = this.m_army.targetVillageID;
				}
				else
				{
					this.travelDirection.Image = GFXLibrary.mrhp_travelling_arrows[1];
					this.backGround.updatePanelText(SK.Text("SelectArmyPanel_Returning", "Returning"));
					if (this.m_army.attackType != 13)
					{
						this.backGround.updateTravelButton(this.homeVillageButton, this.m_army.travelFromVillageID);
					}
					else
					{
						this.backGround.updateTravelButton(this.homeVillageButton, SK.Text("SelectArmyPanel_Tutorial", "Tutorial"));
					}
					this.backGround.updateTravelButton(this.targetVillageButton, this.m_army.targetVillageID);
					if (flag && this.homeVillageButton.Text.Text.Length == 0)
					{
						this.backGround.updateTravelButton(this.targetVillageButton, SK.Text("GENERIC_Unknown", "Unknown"));
					}
					this.fromVillageID = this.m_army.travelFromVillageID;
					this.toVillageID = this.m_army.targetVillageID;
					this.returnButton.Visible = false;
				}
			}
			this.backGround.updateSubHeading(subHeading);
		}

		// Token: 0x060029E9 RID: 10729 RVA: 0x0001ED0B File Offset: 0x0001CF0B
		private bool targetIsAI(int villageID)
		{
			return GameEngine.Instance.World.getSpecial(villageID) != 0;
		}

		// Token: 0x060029EA RID: 10730 RVA: 0x002071F4 File Offset: 0x002053F4
		public void armySelected(long armyID)
		{
			WorldMap.LocalArmyData army = GameEngine.Instance.World.getArmy(armyID);
			if (army != null)
			{
				this.selectedArmyID = armyID;
				this.m_army = army;
				this.lastState = -2;
				this.update();
				return;
			}
			InterfaceMgr.Instance.closeArmySelectedPanel();
			this.m_army = null;
		}

		// Token: 0x060029EB RID: 10731 RVA: 0x0001ED22 File Offset: 0x0001CF22
		private void homeClick()
		{
			if (this.m_army != null && this.fromVillageID >= 0)
			{
				GameEngine.Instance.World.zoomToVillage(this.fromVillageID);
			}
		}

		// Token: 0x060029EC RID: 10732 RVA: 0x0001ED4A File Offset: 0x0001CF4A
		private void targetClick()
		{
			if (this.m_army != null && this.toVillageID >= 0)
			{
				GameEngine.Instance.World.zoomToVillage(this.toVillageID);
			}
		}

		// Token: 0x060029ED RID: 10733 RVA: 0x00207244 File Offset: 0x00205444
		private void cancelClick()
		{
			if (!GameEngine.Instance.World.WorldEnded && this.m_army != null)
			{
				this.returnButton.Visible = false;
				this.forceReturnOff = true;
				RemoteServices.Instance.set_CancelCastleAttack_UserCallBack(new RemoteServices.CancelCastleAttack_UserCallBack(this.cancelCastleAttackCallBack));
				RemoteServices.Instance.CancelCastleAttack(this.m_army.armyID);
			}
		}

		// Token: 0x060029EE RID: 10734 RVA: 0x002072A8 File Offset: 0x002054A8
		private void cancelCastleAttackCallBack(CancelCastleAttack_ReturnType returnData)
		{
			if (returnData.Success)
			{
				if (returnData.armyData != null)
				{
					ArmyReturnData[] armyReturnData = new ArmyReturnData[]
					{
						returnData.armyData
					};
					GameEngine.Instance.World.doGetArmyData(armyReturnData, null, false);
					GameEngine.Instance.World.addExistingArmy(returnData.armyData.armyID);
					GameEngine.Instance.World.setHonourData(returnData.currentHonourLevel, returnData.currentHonourRate);
					GameEngine.Instance.World.deleteArmy(returnData.oldArmyID);
					if (SpecialVillageTypes.IS_TREASURE_CASTLE(GameEngine.Instance.World.getSpecial(returnData.armyData.targetVillageID)))
					{
						GameEngine.Instance.World.setLastTreasureCastleAttackTime(DateTime.MinValue);
					}
				}
				this.update();
				this.returnButton.Visible = false;
				return;
			}
			this.forceReturnOff = false;
		}

		// Token: 0x060029EF RID: 10735 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x060029F0 RID: 10736 RVA: 0x0001ED72 File Offset: 0x0001CF72
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x060029F1 RID: 10737 RVA: 0x0001ED82 File Offset: 0x0001CF82
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x060029F2 RID: 10738 RVA: 0x0001ED92 File Offset: 0x0001CF92
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x060029F3 RID: 10739 RVA: 0x0001EDA4 File Offset: 0x0001CFA4
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x060029F4 RID: 10740 RVA: 0x0001EDB1 File Offset: 0x0001CFB1
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x060029F5 RID: 10741 RVA: 0x0001EDBF File Offset: 0x0001CFBF
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x060029F6 RID: 10742 RVA: 0x0001EDCC File Offset: 0x0001CFCC
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x060029F7 RID: 10743 RVA: 0x0001EDD9 File Offset: 0x0001CFD9
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060029F8 RID: 10744 RVA: 0x00207388 File Offset: 0x00205588
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Name = "SelectArmyPanel2";
			base.Size = new Size(199, 213);
			base.ResumeLayout(false);
		}

		// Token: 0x04003382 RID: 13186
		private CustomSelfDrawPanel.MRHP_Background backGround = new CustomSelfDrawPanel.MRHP_Background();

		// Token: 0x04003383 RID: 13187
		private CustomSelfDrawPanel.CSDButton homeVillageButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003384 RID: 13188
		private CustomSelfDrawPanel.CSDButton targetVillageButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003385 RID: 13189
		private CustomSelfDrawPanel.CSDImage travelDirection = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003386 RID: 13190
		private CustomSelfDrawPanel.CSDButton returnButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003387 RID: 13191
		private bool forceReturnOff;

		// Token: 0x04003388 RID: 13192
		private int fromVillageID = -1;

		// Token: 0x04003389 RID: 13193
		private int toVillageID = -1;

		// Token: 0x0400338A RID: 13194
		private int lastState = -2;

		// Token: 0x0400338B RID: 13195
		private WorldMap.LocalArmyData m_army;

		// Token: 0x0400338C RID: 13196
		private long selectedArmyID;

		// Token: 0x0400338D RID: 13197
		private DockableControl dockableControl;

		// Token: 0x0400338E RID: 13198
		private IContainer components;
	}
}
