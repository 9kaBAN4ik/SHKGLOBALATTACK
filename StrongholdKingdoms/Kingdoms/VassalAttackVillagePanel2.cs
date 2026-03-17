using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020004BF RID: 1215
	public class VassalAttackVillagePanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06002CED RID: 11501 RVA: 0x00020F81 File Offset: 0x0001F181
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06002CEE RID: 11502 RVA: 0x00020F91 File Offset: 0x0001F191
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06002CEF RID: 11503 RVA: 0x00020FA1 File Offset: 0x0001F1A1
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06002CF0 RID: 11504 RVA: 0x00020FB3 File Offset: 0x0001F1B3
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06002CF1 RID: 11505 RVA: 0x00020FC0 File Offset: 0x0001F1C0
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x06002CF2 RID: 11506 RVA: 0x00020FCE File Offset: 0x0001F1CE
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06002CF3 RID: 11507 RVA: 0x00020FDB File Offset: 0x0001F1DB
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06002CF4 RID: 11508 RVA: 0x00020FE8 File Offset: 0x0001F1E8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002CF5 RID: 11509 RVA: 0x0023DCF0 File Offset: 0x0023BEF0
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Name = "VassalAttackVillagePanel2";
			base.Size = new Size(199, 213);
			base.ResumeLayout(false);
		}

		// Token: 0x06002CF6 RID: 11510 RVA: 0x0023DD3C File Offset: 0x0023BF3C
		public VassalAttackVillagePanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SelfDrawBackground = true;
		}

		// Token: 0x06002CF7 RID: 11511 RVA: 0x0023DDA4 File Offset: 0x0023BFA4
		public void init(int villageID)
		{
			this.wasTall = this.isTallTreasureChestPanel(villageID);
			int num = 0;
			if (this.wasTall)
			{
				num = 60;
			}
			base.clearControls();
			CustomSelfDrawPanel.CSDImage csdimage = this.backGround.init(this.wasTall, 10000);
			base.addControl(this.backGround);
			this.attackButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.ATTACK);
			this.attackButton.Position = new Point(80, 49 + num);
			this.attackButton.Enabled = false;
			this.attackButton.CustomTooltipID = 2411;
			this.attackButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnAttack_Click), "VassalAttackVillagePanel2_attack");
			csdimage.addControl(this.attackButton);
			this.treasureCastleTimeoutLabel.Text = "";
			this.treasureCastleTimeoutLabel.Color = global::ARGBColors.Black;
			this.treasureCastleTimeoutLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
			this.treasureCastleTimeoutLabel.Position = new Point(10, 50);
			this.treasureCastleTimeoutLabel.Size = new Size(csdimage.Width - 20, 80);
			this.treasureCastleTimeoutLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.treasureCastleTimeoutLabel.Visible = false;
			csdimage.addControl(this.treasureCastleTimeoutLabel);
		}

		// Token: 0x06002CF8 RID: 11512 RVA: 0x00021007 File Offset: 0x0001F207
		public void update()
		{
			this.backGround.update();
			this.updateTreasureCastleTimeout();
		}

		// Token: 0x06002CF9 RID: 11513 RVA: 0x0023DEE8 File Offset: 0x0023C0E8
		public void updateOtherVillageText(int selectedVillage)
		{
			bool flag = false;
			if (GameEngine.Instance.World.isSpecial(selectedVillage) && GameEngine.Instance.World.isAttackableSpecial(selectedVillage))
			{
				bool flag2 = this.isTallTreasureChestPanel(selectedVillage);
				if (flag2 != this.wasTall)
				{
					this.init(selectedVillage);
				}
				flag = flag2;
			}
			this.m_selectedVillage = selectedVillage;
			string villageNameOrType = GameEngine.Instance.World.getVillageNameOrType(selectedVillage);
			this.backGround.updateHeading(villageNameOrType);
			this.backGround.updatePanelTypeFromVillageID(selectedVillage);
			if (selectedVillage < 0)
			{
				this.attackButton.Enabled = false;
				return;
			}
			if (GameEngine.Instance.World.isAttackableSpecial(selectedVillage))
			{
				this.attackButton.Enabled = true;
				int special = GameEngine.Instance.World.getSpecial(selectedVillage);
				if (SpecialVillageTypes.IS_TREASURE_CASTLE(special))
				{
					if (GameEngine.Instance.World.isCapital(InterfaceMgr.Instance.OwnSelectedVillage))
					{
						this.attackButton.Enabled = false;
					}
					if (flag)
					{
						this.updateTreasureCastleTimeout();
						this.treasureCastleTimeoutLabel.Visible = true;
						this.attackButton.Enabled = false;
						return;
					}
				}
				else if (SpecialVillageTypes.IS_ROYAL_TOWER(special) && GameEngine.Instance.World.isCapital(InterfaceMgr.Instance.OwnSelectedVillage))
				{
					this.attackButton.Enabled = false;
					return;
				}
			}
			else
			{
				if (!GameEngine.Instance.World.isCapital(selectedVillage) && GameEngine.Instance.World.getVillageUserID(selectedVillage) >= 0)
				{
					this.attackButton.Enabled = true;
					return;
				}
				this.attackButton.Enabled = false;
			}
		}

		// Token: 0x06002CFA RID: 11514 RVA: 0x0023E06C File Offset: 0x0023C26C
		private void btnAttack_Click()
		{
			if (this.m_selectedVillage >= 0)
			{
				int selectedVassalVillage = InterfaceMgr.Instance.SelectedVassalVillage;
				GameEngine.Instance.preAttackSetup(InterfaceMgr.Instance.OwnSelectedVillage, selectedVassalVillage, this.m_selectedVillage);
			}
		}

		// Token: 0x06002CFB RID: 11515 RVA: 0x001186C8 File Offset: 0x001168C8
		private bool isTallTreasureChestPanel(int villageID)
		{
			if (GameEngine.Instance.World.isSpecial(villageID) && GameEngine.Instance.World.isAttackableSpecial(villageID))
			{
				int special = GameEngine.Instance.World.getSpecial(villageID);
				if (SpecialVillageTypes.IS_TREASURE_CASTLE(special))
				{
					TimeSpan timeSpan = VillageMap.getCurrentServerTime() - GameEngine.Instance.World.getLastTreasureCastleAttackTime();
					int treasureCastle_AttackGap = WorldMap.TreasureCastle_AttackGap;
					if (timeSpan.TotalSeconds < (double)treasureCastle_AttackGap)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06002CFC RID: 11516 RVA: 0x0023E0A8 File Offset: 0x0023C2A8
		private void updateTreasureCastleTimeout()
		{
			if (!GameEngine.Instance.World.isSpecial(this.m_selectedVillage) || !GameEngine.Instance.World.isAttackableSpecial(this.m_selectedVillage))
			{
				return;
			}
			TimeSpan timeSpan = VillageMap.getCurrentServerTime() - GameEngine.Instance.World.getLastTreasureCastleAttackTime();
			int treasureCastle_AttackGap = WorldMap.TreasureCastle_AttackGap;
			if (timeSpan.TotalSeconds < (double)treasureCastle_AttackGap)
			{
				this.treasureCastleTimeoutLabel.TextDiffOnly = SK.Text("EmptyVillage_NextAttackAvailable", "Next Attack Available in") + " " + VillageMap.createBuildTimeString(treasureCastle_AttackGap - (int)timeSpan.TotalSeconds);
				return;
			}
			this.treasureCastleTimeoutLabel.TextDiffOnly = "";
			if (this.treasureCastleTimeoutLabel.Visible && !GameEngine.Instance.World.isCapital(InterfaceMgr.Instance.OwnSelectedVillage))
			{
				this.attackButton.Enabled = true;
			}
		}

		// Token: 0x04003812 RID: 14354
		private DockableControl dockableControl;

		// Token: 0x04003813 RID: 14355
		private IContainer components;

		// Token: 0x04003814 RID: 14356
		private CustomSelfDrawPanel.MRHP_Background backGround = new CustomSelfDrawPanel.MRHP_Background();

		// Token: 0x04003815 RID: 14357
		private CustomSelfDrawPanel.CSDButton attackButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003816 RID: 14358
		private CustomSelfDrawPanel.CSDLabel treasureCastleTimeoutLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003817 RID: 14359
		private bool wasTall = true;

		// Token: 0x04003818 RID: 14360
		private int m_selectedVillage = -1;
	}
}
