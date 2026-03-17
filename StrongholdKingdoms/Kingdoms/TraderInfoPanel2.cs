using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;
using Upgrade;

namespace Kingdoms
{
	// Token: 0x0200049F RID: 1183
	public class TraderInfoPanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06002B4C RID: 11084 RVA: 0x0001FCAC File Offset: 0x0001DEAC
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06002B4D RID: 11085 RVA: 0x0001FCBC File Offset: 0x0001DEBC
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06002B4E RID: 11086 RVA: 0x0001FCCC File Offset: 0x0001DECC
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06002B4F RID: 11087 RVA: 0x0001FCDE File Offset: 0x0001DEDE
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06002B50 RID: 11088 RVA: 0x0001FCEB File Offset: 0x0001DEEB
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x06002B51 RID: 11089 RVA: 0x0001FCF9 File Offset: 0x0001DEF9
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06002B52 RID: 11090 RVA: 0x0001FD06 File Offset: 0x0001DF06
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06002B53 RID: 11091 RVA: 0x0001FD13 File Offset: 0x0001DF13
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002B54 RID: 11092 RVA: 0x002234CC File Offset: 0x002216CC
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Name = "TraderInfoPanel2";
			base.Size = new Size(199, 213);
			base.ResumeLayout(false);
		}

		// Token: 0x06002B55 RID: 11093 RVA: 0x00223518 File Offset: 0x00221718
		public TraderInfoPanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SelfDrawBackground = true;
		}

		// Token: 0x06002B56 RID: 11094 RVA: 0x0022359C File Offset: 0x0022179C
		public void init()
		{
			base.clearControls();
			CustomSelfDrawPanel.CSDImage csdimage = this.backGround.init(true, 1004);
			this.backGround.updateHeading(SK.Text("SelectArmyPanel_Trader", "Trader"));
			this.backGround.centerSubHeading();
			base.addControl(this.backGround);
			this.backGround.initTravelButton(this.homeVillageButton);
			this.homeVillageButton.Position = new Point(11, 61);
			this.homeVillageButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.homeClick), "TraderInfoPanel2_home_village");
			csdimage.addControl(this.homeVillageButton);
			this.backGround.initTravelButton(this.targetVillageButton);
			this.targetVillageButton.Position = new Point(11, 119);
			this.targetVillageButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.targetClick), "TraderInfoPanel2_target_village");
			csdimage.addControl(this.targetVillageButton);
			this.travelDirection.Image = GFXLibrary.mrhp_travelling_arrows[0];
			this.travelDirection.Position = new Point(88, 90);
			this.travelDirection.Alpha = 0.5f;
			csdimage.addControl(this.travelDirection);
			this.resourceImage.Image = GFXLibrary.dummy;
			this.resourceImage.Position = new Point(45, 144);
			this.resourceImage.Visible = false;
			csdimage.addControl(this.resourceImage);
			this.resourceAmountLabel.Text = "";
			this.resourceAmountLabel.Color = global::ARGBColors.Black;
			this.resourceAmountLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
			this.resourceAmountLabel.Position = new Point(90, 158);
			this.resourceAmountLabel.Size = new Size(168, 23);
			this.resourceAmountLabel.Visible = false;
			csdimage.addControl(this.resourceAmountLabel);
		}

		// Token: 0x06002B57 RID: 11095 RVA: 0x00223794 File Offset: 0x00221994
		public void setTrader(long traderID)
		{
			WorldMap.LocalTrader trader = GameEngine.Instance.World.getTrader(traderID);
			if (trader != null)
			{
				this.m_trader = trader;
				this.lastState = -1;
				this.update();
				return;
			}
			InterfaceMgr.Instance.closeTraderInfoPanel();
		}

		// Token: 0x06002B58 RID: 11096 RVA: 0x002237D4 File Offset: 0x002219D4
		public void update()
		{
			this.backGround.update();
			if (this.m_trader == null)
			{
				return;
			}
			if (this.m_trader.trader.traderState != this.lastState)
			{
				this.lastState = this.m_trader.trader.traderState;
				this.backGround.updateTravelButton(this.homeVillageButton, this.m_trader.trader.homeVillageID);
				this.backGround.updateTravelButton(this.targetVillageButton, this.m_trader.trader.targetVillageID);
				this.resourceImage.Visible = false;
				this.resourceAmountLabel.Visible = false;
				if (this.lastState == 0)
				{
					InterfaceMgr.Instance.closeTraderInfoPanel();
					return;
				}
				if (this.lastState == 1 || this.lastState == 3 || this.lastState == 6)
				{
					this.backGround.updatePanelText(SK.Text("SelectArmyPanel_Trading", "Trading"));
					if (GameEngine.Instance.World.isUserVillage(this.m_trader.trader.homeVillageID) || DX.ControlForm.IsExclusive)
					{
						this.resourceImage.Image = GFXLibrary.getCommodity32DSImage(this.m_trader.trader.resource);
						this.resourceImage.Visible = true;
						NumberFormatInfo nfi = GameEngine.NFI;
						int tradingAmount = GameEngine.Instance.World.getTradingAmount(this.m_trader.traderID);
						this.resourceAmountLabel.TextDiffOnly = tradingAmount.ToString("N", nfi);
						this.resourceAmountLabel.Visible = true;
					}
					if (this.lastState == 6)
					{
						this.travelDirection.Image = GFXLibrary.mrhp_travelling_arrows[1];
					}
					else
					{
						this.travelDirection.Image = GFXLibrary.mrhp_travelling_arrows[0];
					}
				}
				else if (this.lastState == 2 || this.lastState == 4)
				{
					this.backGround.updatePanelText(SK.Text("SelectArmyPanel_Returning", "Returning"));
					this.travelDirection.Image = GFXLibrary.mrhp_travelling_arrows[1];
				}
				else if (this.lastState == 5)
				{
					this.backGround.updatePanelText(SK.Text("SelectArmyPanel_Collecting", "Collecting"));
					this.travelDirection.Image = GFXLibrary.mrhp_travelling_arrows[0];
				}
			}
			double num = DXTimer.GetCurrentMilliseconds() / 1000.0;
			double num2 = this.m_trader.localEndTime - num;
			if (num2 < 0.0)
			{
				num2 = 0.0;
			}
			string subHeading = VillageMap.createBuildTimeString((int)num2);
			this.backGround.updateSubHeading(subHeading);
		}

		// Token: 0x06002B59 RID: 11097 RVA: 0x0001FD32 File Offset: 0x0001DF32
		private void homeClick()
		{
			if (this.m_trader != null)
			{
				GameEngine.Instance.World.zoomToVillage(this.m_trader.trader.homeVillageID);
			}
		}

		// Token: 0x06002B5A RID: 11098 RVA: 0x0001FD5B File Offset: 0x0001DF5B
		private void targetClick()
		{
			if (this.m_trader != null)
			{
				GameEngine.Instance.World.zoomToVillage(this.m_trader.trader.targetVillageID);
			}
		}

		// Token: 0x040035F9 RID: 13817
		private DockableControl dockableControl;

		// Token: 0x040035FA RID: 13818
		private IContainer components;

		// Token: 0x040035FB RID: 13819
		private CustomSelfDrawPanel.MRHP_Background backGround = new CustomSelfDrawPanel.MRHP_Background();

		// Token: 0x040035FC RID: 13820
		private CustomSelfDrawPanel.CSDButton homeVillageButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040035FD RID: 13821
		private CustomSelfDrawPanel.CSDButton targetVillageButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040035FE RID: 13822
		private CustomSelfDrawPanel.CSDImage travelDirection = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040035FF RID: 13823
		private CustomSelfDrawPanel.CSDImage resourceImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003600 RID: 13824
		private CustomSelfDrawPanel.CSDLabel resourceAmountLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003601 RID: 13825
		private WorldMap.LocalTrader m_trader;

		// Token: 0x04003602 RID: 13826
		private int lastState = -1;
	}
}
