using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000239 RID: 569
	public class MapFilterSelectPanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06001912 RID: 6418 RVA: 0x0018D89C File Offset: 0x0018BA9C
		public MapFilterSelectPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SelfDrawBackground = true;
		}

		// Token: 0x06001913 RID: 6419 RVA: 0x0018D8EC File Offset: 0x0018BAEC
		public void init(bool showAsOpen, bool doubleHeight)
		{
			base.clearControls();
			if (doubleHeight)
			{
				this.filterButton.MoveOnClick = true;
				this.filterButton.ImageClick = null;
				this.filterButton.Position = new Point(8, 32);
				if (showAsOpen)
				{
					if (GameEngine.Instance.World.worldMapFilter.FilterActive)
					{
						this.filterButton.ImageNorm = GFXLibrary.mrhp_button_filter_normal;
						this.filterButton.ImageOver = GFXLibrary.mrhp_button_filter_over;
						this.filterButton.Text.Text = SK.Text("MapFilterSelectPanel_Filter_Active", "Filter Active");
						this.filterButton.CustomTooltipID = 93;
					}
					else
					{
						this.filterButton.ImageNorm = GFXLibrary.mrhp_button_filter_off_normal;
						this.filterButton.ImageOver = GFXLibrary.mrhp_button_filter_off_over;
						this.filterButton.Text.Text = SK.Text("MapFilterSelectPanel_Map_Filtering", "Map Filtering");
						this.filterButton.CustomTooltipID = 91;
					}
					this.filterButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.filterClick), "MapFilterSelectPanel_filter");
				}
				else
				{
					this.filterButton.ImageNorm = GFXLibrary.mrhp_button_filter_off_normal;
					this.filterButton.ImageOver = GFXLibrary.mrhp_button_filter_off_over;
					this.filterButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "MapFilterSelectPanel_filter");
					this.filterButton.Text.Text = SK.Text("GENERIC_Close", "Close");
					this.filterButton.CustomTooltipID = 92;
				}
				this.filterButton.Text.Color = global::ARGBColors.Black;
				this.filterButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.filterButton.Text.Size = new Size(130, 52);
				this.filterButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.filterButton.Text.Position = new Point(39, -10);
				base.addControl(this.filterButton);
				if (showAsOpen)
				{
					this.attackButton.Position = new Point(8, 2);
					this.attackButton.ImageNorm = GFXLibrary.mrhp_button_attack_normal;
					this.attackButton.ImageOver = GFXLibrary.mrhp_button_attack_over;
					this.attackButton.Text.Text = SK.Text("Attack_Targets", "Attack Targets");
					this.attackButton.Text.Color = global::ARGBColors.Black;
					this.attackButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
					this.attackButton.Text.Size = new Size(130, 52);
					this.attackButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
					this.attackButton.Text.Position = new Point(39, -10);
					this.attackButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.attackClick), "MapFilterSelectPanel_filter");
					this.attackButton.CustomTooltipID = 94;
					base.addControl(this.attackButton);
				}
				base.Size = new Size(187, 57);
				return;
			}
			this.filterButton.Position = new Point(8, 2);
			if (showAsOpen)
			{
				if (GameEngine.Instance.World.worldMapFilter.FilterActive)
				{
					this.filterButton.ImageNorm = GFXLibrary.mrhp_button_filter_off[6];
					this.filterButton.ImageOver = GFXLibrary.mrhp_button_filter_off[7];
					this.filterButton.ImageClick = GFXLibrary.mrhp_button_filter_off[8];
					this.filterButton.Text.Text = "";
					this.filterButton.CustomTooltipID = 93;
				}
				else
				{
					this.filterButton.ImageNorm = GFXLibrary.mrhp_button_filter_off[3];
					this.filterButton.ImageOver = GFXLibrary.mrhp_button_filter_off[4];
					this.filterButton.ImageClick = GFXLibrary.mrhp_button_filter_off[5];
					this.filterButton.Text.Text = "";
					this.filterButton.CustomTooltipID = 91;
				}
				this.filterButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.filterClick), "MapFilterSelectPanel_filter");
			}
			else
			{
				this.filterButton.ImageNorm = GFXLibrary.mrhp_button_filter_off[3];
				this.filterButton.ImageOver = GFXLibrary.mrhp_button_filter_off[4];
				this.filterButton.ImageClick = GFXLibrary.mrhp_button_filter_off[5];
				this.filterButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "MapFilterSelectPanel_filter");
				this.filterButton.Text.Text = "";
				this.filterButton.CustomTooltipID = 92;
			}
			base.addControl(this.filterButton);
			this.attackButton.Position = new Point(102, 2);
			this.attackButton.Text.Text = "";
			this.attackButton.ImageNorm = GFXLibrary.mrhp_button_filter_off[9];
			this.attackButton.ImageOver = GFXLibrary.mrhp_button_filter_off[10];
			this.attackButton.ImageClick = GFXLibrary.mrhp_button_filter_off[11];
			this.attackButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.attackClick), "MapFilterSelectPanel_filter");
			this.attackButton.CustomTooltipID = 94;
			base.addControl(this.attackButton);
			base.Size = new Size(187, 27);
		}

		// Token: 0x06001914 RID: 6420 RVA: 0x000198D0 File Offset: 0x00017AD0
		private void filterClick()
		{
			InterfaceMgr.Instance.showMapFilterPanel();
			InterfaceMgr.Instance.showMapFilterSelectPanel(true, false, true, true);
		}

		// Token: 0x06001915 RID: 6421 RVA: 0x000198EA File Offset: 0x00017AEA
		private void attackClick()
		{
			InterfaceMgr.Instance.openAttackTargetsPopup();
		}

		// Token: 0x06001916 RID: 6422 RVA: 0x000198AE File Offset: 0x00017AAE
		private void closeClick()
		{
			InterfaceMgr.Instance.clearControls();
			InterfaceMgr.Instance.showMapFilterSelectPanel(true, true);
			InterfaceMgr.Instance.selectCurrentUserVillage();
		}

		// Token: 0x06001917 RID: 6423 RVA: 0x000198F7 File Offset: 0x00017AF7
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06001918 RID: 6424 RVA: 0x00019907 File Offset: 0x00017B07
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06001919 RID: 6425 RVA: 0x00019917 File Offset: 0x00017B17
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x0600191A RID: 6426 RVA: 0x00019929 File Offset: 0x00017B29
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x0600191B RID: 6427 RVA: 0x00019936 File Offset: 0x00017B36
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x0600191C RID: 6428 RVA: 0x00019944 File Offset: 0x00017B44
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x0600191D RID: 6429 RVA: 0x00019951 File Offset: 0x00017B51
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x0600191E RID: 6430 RVA: 0x0001995E File Offset: 0x00017B5E
		public void setPosition(int x, int y)
		{
			this.dockableControl.setPosition(x, y);
		}

		// Token: 0x0600191F RID: 6431 RVA: 0x0001996D File Offset: 0x00017B6D
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001920 RID: 6432 RVA: 0x0001998C File Offset: 0x00017B8C
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Name = "MapFilterSelectPanel";
			base.Size = new Size(187, 27);
			base.ResumeLayout(false);
		}

		// Token: 0x04002981 RID: 10625
		private CustomSelfDrawPanel.CSDButton filterButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002982 RID: 10626
		private CustomSelfDrawPanel.CSDButton attackButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002983 RID: 10627
		private DockableControl dockableControl;

		// Token: 0x04002984 RID: 10628
		private IContainer components;
	}
}
