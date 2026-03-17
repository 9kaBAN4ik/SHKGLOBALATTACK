using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020001AF RID: 431
	public class FactionAllFactionsPanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06001059 RID: 4185 RVA: 0x0011B514 File Offset: 0x00119714
		public FactionAllFactionsPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x0600105A RID: 4186 RVA: 0x0011B680 File Offset: 0x00119880
		public void init(bool resized)
		{
			int height = base.Height;
			FactionAllFactionsPanel.instance = this;
			base.clearControls();
			this.sidebar.addSideBar(2, this);
			this.mainBackgroundImage.FillColor = Color.FromArgb(134, 153, 165);
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = new Size(base.Width - 200, height);
			base.addControl(this.mainBackgroundImage);
			this.backgroundFade.Image = GFXLibrary.background_top;
			this.backgroundFade.Position = new Point(0, 0);
			this.backgroundFade.Size = new Size(base.Width - 200, this.backgroundFade.Image.Height);
			this.mainBackgroundImage.addControl(this.backgroundFade);
			this.headerLabelsImage.Size = new Size(base.Width - 25 - 23 - 200, 28);
			this.headerLabelsImage.Position = new Point(25, 9);
			this.mainBackgroundImage.addControl(this.headerLabelsImage);
			this.headerLabelsImage.Create(GFXLibrary.mail2_field_bar_mail_left, GFXLibrary.mail2_field_bar_mail_middle, GFXLibrary.mail2_field_bar_mail_right);
			this.divider1Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
			this.divider1Image.Position = new Point(290, 0);
			this.headerLabelsImage.addControl(this.divider1Image);
			this.divider2Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
			this.divider2Image.Position = new Point(440, 0);
			this.headerLabelsImage.addControl(this.divider2Image);
			this.divider3Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
			this.divider3Image.Position = new Point(610, 0);
			this.headerLabelsImage.addControl(this.divider3Image);
			this.factionLabel.Text = SK.Text("STATS_CATEGORY_TITLE_FACTION", "Faction");
			this.factionLabel.Color = global::ARGBColors.Black;
			this.factionLabel.Position = new Point(9, -2);
			this.factionLabel.Size = new Size(323, this.headerLabelsImage.Height);
			this.factionLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.factionLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.factionLabel);
			this.factionSortArea.Position = new Point(0, 0);
			this.factionSortArea.Size = new Size(290, this.headerLabelsImage.Height);
			this.factionSortArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortNameClick), "FactionAllFactionsPanel_sort_faction");
			this.headerLabelsImage.addControl(this.factionSortArea);
			this.playersLabel.Text = SK.Text("FactionInvites_Players", "Players");
			this.playersLabel.Color = global::ARGBColors.Black;
			this.playersLabel.Position = new Point(295, -2);
			this.playersLabel.Size = new Size(140, this.headerLabelsImage.Height);
			this.playersLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.playersLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.headerLabelsImage.addControl(this.playersLabel);
			this.playersSortArea.Position = new Point(290, 0);
			this.playersSortArea.Size = new Size(150, this.headerLabelsImage.Height);
			this.playersSortArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortPlayersClick), "FactionAllFactionsPanel_sort_players");
			this.headerLabelsImage.addControl(this.playersSortArea);
			this.pointsLabel.Text = SK.Text("FactionsPanel_Points", "Points");
			this.pointsLabel.Color = global::ARGBColors.Black;
			this.pointsLabel.Position = new Point(445, -2);
			this.pointsLabel.Size = new Size(160, this.headerLabelsImage.Height);
			this.pointsLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.pointsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.headerLabelsImage.addControl(this.pointsLabel);
			this.pointsSortArea.Position = new Point(440, 0);
			this.pointsSortArea.Size = new Size(170, this.headerLabelsImage.Height);
			this.pointsSortArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortPointsClick), "FactionAllFactionsPanel_sort_points");
			this.headerLabelsImage.addControl(this.pointsSortArea);
			this.membershipLabel.Text = SK.Text("FactionInvites_Membership", "Membership");
			this.membershipLabel.Color = global::ARGBColors.Black;
			this.membershipLabel.Position = new Point(615, -2);
			this.membershipLabel.Size = new Size(110, this.headerLabelsImage.Height);
			this.membershipLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.membershipLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.headerLabelsImage.addControl(this.membershipLabel);
			this.openSortArea.Position = new Point(610, 0);
			this.openSortArea.Size = new Size(120, this.headerLabelsImage.Height);
			this.openSortArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortOpenClick), "FactionAllFactionsPanel_sort_points");
			this.headerLabelsImage.addControl(this.openSortArea);
			InterfaceMgr.Instance.setVillageHeading(SK.Text("FactionInvites_All_Factions", "All Factions"));
			this.wallScrollArea.Position = new Point(25, 38);
			this.wallScrollArea.Size = new Size(705, height - 38);
			this.wallScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(705, height - 38));
			this.mainBackgroundImage.addControl(this.wallScrollArea);
			this.mouseWheelOverlay.Position = this.wallScrollArea.Position;
			this.mouseWheelOverlay.Size = this.wallScrollArea.Size;
			this.mouseWheelOverlay.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mouseWheelMoved));
			this.mainBackgroundImage.addControl(this.mouseWheelOverlay);
			int value = this.wallScrollBar.Value;
			this.wallScrollBar.Position = new Point(733, 38);
			this.wallScrollBar.Size = new Size(24, height - 38);
			this.mainBackgroundImage.addControl(this.wallScrollBar);
			this.wallScrollBar.Value = 0;
			this.wallScrollBar.Max = 100;
			this.wallScrollBar.NumVisibleLines = 25;
			this.wallScrollBar.Create(null, null, null, GFXLibrary._24wide_thumb_top, GFXLibrary._24wide_thumb_middle, GFXLibrary._24wide_thumb_bottom);
			this.wallScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.wallScrollBarMoved));
			if (!resized)
			{
				CustomSelfDrawPanel.FactionPanelSideBar.downloadCurrentFactionInfo();
			}
			this.addFactions();
		}

		// Token: 0x0600105B RID: 4187 RVA: 0x00011FED File Offset: 0x000101ED
		public void update()
		{
			this.sidebar.update();
		}

		// Token: 0x0600105C RID: 4188 RVA: 0x00011FFA File Offset: 0x000101FA
		public void logout()
		{
			this.sortMethod = -1;
		}

		// Token: 0x0600105D RID: 4189 RVA: 0x0011BE08 File Offset: 0x0011A008
		private void wallScrollBarMoved()
		{
			int value = this.wallScrollBar.Value;
			this.wallScrollArea.Position = new Point(this.wallScrollArea.X, 38 - value);
			this.wallScrollArea.ClipRect = new Rectangle(this.wallScrollArea.ClipRect.X, value, this.wallScrollArea.ClipRect.Width, this.wallScrollArea.ClipRect.Height);
			this.wallScrollArea.invalidate();
			this.wallScrollBar.invalidate();
		}

		// Token: 0x0600105E RID: 4190 RVA: 0x00012003 File Offset: 0x00010203
		private void mouseWheelMoved(int delta)
		{
			if (this.wallScrollBar.Visible)
			{
				if (delta < 0)
				{
					this.wallScrollBar.scrollDown(40);
					return;
				}
				if (delta > 0)
				{
					this.wallScrollBar.scrollUp(40);
				}
			}
		}

		// Token: 0x0600105F RID: 4191 RVA: 0x0000ADE9 File Offset: 0x00008FE9
		public void closing()
		{
			InterfaceMgr.Instance.closeDonatePopup();
		}

		// Token: 0x06001060 RID: 4192 RVA: 0x0011BEA0 File Offset: 0x0011A0A0
		public void addFactions()
		{
			this.wallScrollArea.clearControls();
			int num = 0;
			this.lineList.Clear();
			int num2 = 0;
			SparseArray allFactions = GameEngine.Instance.World.getAllFactions();
			List<FactionData> list = new List<FactionData>();
			foreach (object obj in allFactions)
			{
				FactionData factionData = (FactionData)obj;
				if (factionData.active && factionData.numMembers != 0 && factionData.factionName.Length != 0)
				{
					list.Add(factionData);
				}
			}
			switch (this.sortMethod)
			{
			case 0:
				list.Sort(this.namePosComparer);
				break;
			case 1:
				list.Sort(this.nameNegComparer);
				break;
			case 2:
				list.Sort(this.playersPosComparer);
				break;
			case 3:
				list.Sort(this.playersNegComparer);
				break;
			case 4:
				list.Sort(this.pointsPosComparer);
				break;
			case 5:
				list.Sort(this.pointsNegComparer);
				break;
			case 6:
				list.Sort(this.openPosComparer);
				break;
			case 7:
				list.Sort(this.openNegComparer);
				break;
			}
			foreach (FactionData factionData2 in list)
			{
				FactionAllFactionsPanel.FactionsAllLine factionsAllLine = new FactionAllFactionsPanel.FactionsAllLine();
				if (num != 0)
				{
					num += 5;
				}
				factionsAllLine.Position = new Point(0, num);
				factionsAllLine.init(factionData2, num2, this);
				this.wallScrollArea.addControl(factionsAllLine);
				num += factionsAllLine.Height;
				this.lineList.Add(factionsAllLine);
				num2++;
			}
			this.wallScrollArea.Size = new Size(this.wallScrollArea.Width, num);
			if (num < this.wallScrollBar.Height)
			{
				this.wallScrollBar.Visible = false;
			}
			else
			{
				this.wallScrollBar.Visible = true;
				this.wallScrollBar.NumVisibleLines = this.wallScrollBar.Height;
				this.wallScrollBar.Max = num - this.wallScrollBar.Height;
			}
			this.wallScrollArea.invalidate();
			this.wallScrollBar.invalidate();
			this.update();
			base.Invalidate();
		}

		// Token: 0x06001061 RID: 4193 RVA: 0x00012035 File Offset: 0x00010235
		private void sortNameClick()
		{
			if (this.sortMethod == 0)
			{
				this.sortMethod = 1;
			}
			else
			{
				this.sortMethod = 0;
			}
			this.addFactions();
		}

		// Token: 0x06001062 RID: 4194 RVA: 0x00012055 File Offset: 0x00010255
		private void sortPlayersClick()
		{
			if (this.sortMethod == 2)
			{
				this.sortMethod = 3;
			}
			else
			{
				this.sortMethod = 2;
			}
			this.addFactions();
		}

		// Token: 0x06001063 RID: 4195 RVA: 0x00012076 File Offset: 0x00010276
		private void sortPointsClick()
		{
			if (this.sortMethod == 4)
			{
				this.sortMethod = 5;
			}
			else
			{
				this.sortMethod = 4;
			}
			this.addFactions();
		}

		// Token: 0x06001064 RID: 4196 RVA: 0x00012097 File Offset: 0x00010297
		private void sortOpenClick()
		{
			if (this.sortMethod == 6)
			{
				this.sortMethod = 7;
			}
			else
			{
				this.sortMethod = 6;
			}
			this.addFactions();
		}

		// Token: 0x06001065 RID: 4197 RVA: 0x000120B8 File Offset: 0x000102B8
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06001066 RID: 4198 RVA: 0x000120C8 File Offset: 0x000102C8
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06001067 RID: 4199 RVA: 0x000120D8 File Offset: 0x000102D8
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06001068 RID: 4200 RVA: 0x000120EA File Offset: 0x000102EA
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06001069 RID: 4201 RVA: 0x000120F7 File Offset: 0x000102F7
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closing();
		}

		// Token: 0x0600106A RID: 4202 RVA: 0x00012111 File Offset: 0x00010311
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x0600106B RID: 4203 RVA: 0x0001211E File Offset: 0x0001031E
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x0600106C RID: 4204 RVA: 0x0001212B File Offset: 0x0001032B
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600106D RID: 4205 RVA: 0x0011C108 File Offset: 0x0011A308
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.MaximumSize = new Size(992, 10000);
			this.MinimumSize = new Size(992, 566);
			base.Name = "FactionAllFactionsPanel";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x0400166F RID: 5743
		public const int PANEL_ID = 43;

		// Token: 0x04001670 RID: 5744
		public static FactionAllFactionsPanel instance;

		// Token: 0x04001671 RID: 5745
		private CustomSelfDrawPanel.CSDFill mainBackgroundImage = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x04001672 RID: 5746
		private CustomSelfDrawPanel.CSDImage backgroundFade = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001673 RID: 5747
		private CustomSelfDrawPanel.CSDLabel titleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001674 RID: 5748
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04001675 RID: 5749
		private CustomSelfDrawPanel.CSDImage divider1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001676 RID: 5750
		private CustomSelfDrawPanel.CSDImage divider2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001677 RID: 5751
		private CustomSelfDrawPanel.CSDImage divider3Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001678 RID: 5752
		private CustomSelfDrawPanel.CSDLabel factionLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001679 RID: 5753
		private CustomSelfDrawPanel.CSDLabel playersLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400167A RID: 5754
		private CustomSelfDrawPanel.CSDLabel pointsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400167B RID: 5755
		private CustomSelfDrawPanel.CSDLabel membershipLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400167C RID: 5756
		private CustomSelfDrawPanel.CSDArea factionSortArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400167D RID: 5757
		private CustomSelfDrawPanel.CSDArea playersSortArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400167E RID: 5758
		private CustomSelfDrawPanel.CSDArea pointsSortArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400167F RID: 5759
		private CustomSelfDrawPanel.CSDArea openSortArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04001680 RID: 5760
		private CustomSelfDrawPanel.CSDVertScrollBar wallScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04001681 RID: 5761
		private CustomSelfDrawPanel.CSDArea wallScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04001682 RID: 5762
		private CustomSelfDrawPanel.CSDControl mouseWheelOverlay = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x04001683 RID: 5763
		private CustomSelfDrawPanel.FactionPanelSideBar sidebar = new CustomSelfDrawPanel.FactionPanelSideBar();

		// Token: 0x04001684 RID: 5764
		private int sortMethod = -1;

		// Token: 0x04001685 RID: 5765
		private List<FactionAllFactionsPanel.FactionsAllLine> lineList = new List<FactionAllFactionsPanel.FactionsAllLine>();

		// Token: 0x04001686 RID: 5766
		private FactionAllFactionsPanel.NamePosComparer namePosComparer = new FactionAllFactionsPanel.NamePosComparer();

		// Token: 0x04001687 RID: 5767
		private FactionAllFactionsPanel.NameNegComparer nameNegComparer = new FactionAllFactionsPanel.NameNegComparer();

		// Token: 0x04001688 RID: 5768
		private FactionAllFactionsPanel.PlayersPosComparer playersPosComparer = new FactionAllFactionsPanel.PlayersPosComparer();

		// Token: 0x04001689 RID: 5769
		private FactionAllFactionsPanel.PlayersNegComparer playersNegComparer = new FactionAllFactionsPanel.PlayersNegComparer();

		// Token: 0x0400168A RID: 5770
		private FactionAllFactionsPanel.PointsPosComparer pointsPosComparer = new FactionAllFactionsPanel.PointsPosComparer();

		// Token: 0x0400168B RID: 5771
		private FactionAllFactionsPanel.PointsNegComparer pointsNegComparer = new FactionAllFactionsPanel.PointsNegComparer();

		// Token: 0x0400168C RID: 5772
		private FactionAllFactionsPanel.OpenPosComparer openPosComparer = new FactionAllFactionsPanel.OpenPosComparer();

		// Token: 0x0400168D RID: 5773
		private FactionAllFactionsPanel.OpenNegComparer openNegComparer = new FactionAllFactionsPanel.OpenNegComparer();

		// Token: 0x0400168E RID: 5774
		private DockableControl dockableControl;

		// Token: 0x0400168F RID: 5775
		private IContainer components;

		// Token: 0x020001B0 RID: 432
		public class FactionsAllLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x0600106E RID: 4206 RVA: 0x0011C174 File Offset: 0x0011A374
			public void init(FactionData factionData, int position, FactionAllFactionsPanel parent)
			{
				this.m_parent = parent;
				this.m_position = position;
				this.m_factionData = factionData;
				this.ClipVisible = true;
				this.clearControls();
				if ((position & 1) == 0)
				{
					this.backgroundImage.Image = GFXLibrary.lineitem_strip_02_light;
				}
				else
				{
					this.backgroundImage.Image = GFXLibrary.lineitem_strip_02_dark;
				}
				this.backgroundImage.Position = new Point(60, 0);
				base.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
				base.addControl(this.backgroundImage);
				this.Size = this.backgroundImage.Size;
				this.flagImage.createFromFlagData(factionData.flagData);
				this.flagImage.Position = new Point(0, 0);
				this.flagImage.Scale = 0.25;
				this.flagImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
				base.addControl(this.flagImage);
				NumberFormatInfo nfi = GameEngine.NFI;
				this.factionName.Text = factionData.factionName;
				this.factionName.Color = global::ARGBColors.Black;
				this.factionName.Position = new Point(9, 0);
				this.factionName.Size = new Size(220, this.backgroundImage.Height);
				this.factionName.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.factionName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.factionName.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
				this.backgroundImage.addControl(this.factionName);
				this.numPlayersLabel.Text = factionData.numMembers.ToString("N", nfi);
				this.numPlayersLabel.Color = global::ARGBColors.Black;
				this.numPlayersLabel.Position = new Point(215, 0);
				this.numPlayersLabel.Size = new Size(100, this.backgroundImage.Height);
				this.numPlayersLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.numPlayersLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.numPlayersLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
				this.backgroundImage.addControl(this.numPlayersLabel);
				this.pointsLabel.Text = factionData.points.ToString("N", nfi);
				this.pointsLabel.Color = global::ARGBColors.Black;
				this.pointsLabel.Position = new Point(390, 0);
				this.pointsLabel.Size = new Size(100, this.backgroundImage.Height);
				this.pointsLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.pointsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.pointsLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
				this.backgroundImage.addControl(this.pointsLabel);
				if (factionData.numMembers < GameEngine.Instance.LocalWorldData.Faction_MaxMembers)
				{
					if (factionData.openForApplications)
					{
						this.membershipLabel.Text = SK.Text("FactionInvites_Membership_open", "Open");
					}
					else
					{
						this.membershipLabel.Text = SK.Text("FactionInvites_Membership_closed", "Closed");
					}
				}
				else
				{
					this.membershipLabel.Text = SK.Text("FactionInvites_Membership_Full", "Full");
				}
				this.membershipLabel.Color = global::ARGBColors.Black;
				this.membershipLabel.Position = new Point(530, 0);
				this.membershipLabel.Size = new Size(160, this.backgroundImage.Height);
				this.membershipLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.membershipLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.membershipLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
				this.backgroundImage.addControl(this.membershipLabel);
				int yourFactionRelation = GameEngine.Instance.World.getYourFactionRelation(factionData.factionID);
				if (yourFactionRelation != 0)
				{
					if (yourFactionRelation > 0)
					{
						this.allianceImage.Image = GFXLibrary.faction_relationships[0];
						this.allianceImage.CustomTooltipID = 2303;
					}
					else
					{
						this.allianceImage.Image = GFXLibrary.faction_relationships[2];
						this.allianceImage.CustomTooltipID = 2304;
					}
					this.allianceImage.Position = new Point(218, 2);
					this.allianceImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
					this.backgroundImage.addControl(this.allianceImage);
				}
				base.invalidate();
			}

			// Token: 0x0600106F RID: 4207 RVA: 0x00007CE0 File Offset: 0x00005EE0
			public void update()
			{
			}

			// Token: 0x06001070 RID: 4208 RVA: 0x0001214A File Offset: 0x0001034A
			public void clickedLine()
			{
				GameEngine.Instance.playInterfaceSound("FactionAllFactionsPanel_entry_clicked");
				InterfaceMgr.Instance.showFactionPanel(this.m_factionData.factionID);
			}

			// Token: 0x04001690 RID: 5776
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001691 RID: 5777
			private CustomSelfDrawPanel.CSDLabel factionName = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04001692 RID: 5778
			private CustomSelfDrawPanel.CSDLabel numPlayersLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04001693 RID: 5779
			private CustomSelfDrawPanel.CSDLabel pointsLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04001694 RID: 5780
			private CustomSelfDrawPanel.CSDLabel membershipLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04001695 RID: 5781
			private CustomSelfDrawPanel.CSDImage allianceImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001696 RID: 5782
			private CustomSelfDrawPanel.CSDFactionFlagImage flagImage = new CustomSelfDrawPanel.CSDFactionFlagImage();

			// Token: 0x04001697 RID: 5783
			private int m_position = -1000;

			// Token: 0x04001698 RID: 5784
			private FactionData m_factionData;

			// Token: 0x04001699 RID: 5785
			private FactionAllFactionsPanel m_parent;
		}

		// Token: 0x020001B1 RID: 433
		public class NamePosComparer : IComparer<FactionData>
		{
			// Token: 0x06001072 RID: 4210 RVA: 0x00012170 File Offset: 0x00010370
			public int Compare(FactionData x, FactionData y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return 0;
					}
					return -1;
				}
				else
				{
					if (y == null)
					{
						return 1;
					}
					return x.factionName.CompareTo(y.factionName);
				}
			}
		}

		// Token: 0x020001B2 RID: 434
		public class NameNegComparer : IComparer<FactionData>
		{
			// Token: 0x06001074 RID: 4212 RVA: 0x00012192 File Offset: 0x00010392
			public int Compare(FactionData y, FactionData x)
			{
				if (x == null)
				{
					if (y == null)
					{
						return 0;
					}
					return -1;
				}
				else
				{
					if (y == null)
					{
						return 1;
					}
					return x.factionName.CompareTo(y.factionName);
				}
			}
		}

		// Token: 0x020001B3 RID: 435
		public class PlayersPosComparer : IComparer<FactionData>
		{
			// Token: 0x06001076 RID: 4214 RVA: 0x0011C69C File Offset: 0x0011A89C
			public int Compare(FactionData x, FactionData y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return 0;
					}
					return -1;
				}
				else
				{
					if (y == null)
					{
						return 1;
					}
					if (x.numMembers > y.numMembers)
					{
						return -1;
					}
					if (x.numMembers < y.numMembers)
					{
						return 1;
					}
					return x.factionName.CompareTo(y.factionName);
				}
			}
		}

		// Token: 0x020001B4 RID: 436
		public class PlayersNegComparer : IComparer<FactionData>
		{
			// Token: 0x06001078 RID: 4216 RVA: 0x0011C6EC File Offset: 0x0011A8EC
			public int Compare(FactionData y, FactionData x)
			{
				if (x == null)
				{
					if (y == null)
					{
						return 0;
					}
					return -1;
				}
				else
				{
					if (y == null)
					{
						return 1;
					}
					if (x.numMembers > y.numMembers)
					{
						return -1;
					}
					if (x.numMembers < y.numMembers)
					{
						return 1;
					}
					return x.factionName.CompareTo(y.factionName);
				}
			}
		}

		// Token: 0x020001B5 RID: 437
		public class PointsPosComparer : IComparer<FactionData>
		{
			// Token: 0x0600107A RID: 4218 RVA: 0x0011C73C File Offset: 0x0011A93C
			public int Compare(FactionData x, FactionData y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return 0;
					}
					return -1;
				}
				else
				{
					if (y == null)
					{
						return 1;
					}
					if (x.points > y.points)
					{
						return -1;
					}
					if (x.points < y.points)
					{
						return 1;
					}
					return x.factionName.CompareTo(y.factionName);
				}
			}
		}

		// Token: 0x020001B6 RID: 438
		public class PointsNegComparer : IComparer<FactionData>
		{
			// Token: 0x0600107C RID: 4220 RVA: 0x0011C78C File Offset: 0x0011A98C
			public int Compare(FactionData y, FactionData x)
			{
				if (x == null)
				{
					if (y == null)
					{
						return 0;
					}
					return -1;
				}
				else
				{
					if (y == null)
					{
						return 1;
					}
					if (x.points > y.points)
					{
						return -1;
					}
					if (x.points < y.points)
					{
						return 1;
					}
					return x.factionName.CompareTo(y.factionName);
				}
			}
		}

		// Token: 0x020001B7 RID: 439
		public class OpenPosComparer : IComparer<FactionData>
		{
			// Token: 0x0600107E RID: 4222 RVA: 0x0011C7DC File Offset: 0x0011A9DC
			public int Compare(FactionData x, FactionData y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return 0;
					}
					return -1;
				}
				else
				{
					if (y == null)
					{
						return 1;
					}
					if (x.numMembers >= GameEngine.Instance.LocalWorldData.Faction_MaxMembers)
					{
						if (y.numMembers >= GameEngine.Instance.LocalWorldData.Faction_MaxMembers)
						{
							return x.factionName.CompareTo(y.factionName);
						}
						return 1;
					}
					else
					{
						if (y.numMembers >= GameEngine.Instance.LocalWorldData.Faction_MaxMembers)
						{
							return -1;
						}
						if (x.openForApplications)
						{
							if (y.openForApplications)
							{
								return x.factionName.CompareTo(y.factionName);
							}
							return -1;
						}
						else
						{
							if (y.openForApplications)
							{
								return 1;
							}
							return x.factionName.CompareTo(y.factionName);
						}
					}
				}
			}
		}

		// Token: 0x020001B8 RID: 440
		public class OpenNegComparer : IComparer<FactionData>
		{
			// Token: 0x06001080 RID: 4224 RVA: 0x0011C894 File Offset: 0x0011AA94
			public int Compare(FactionData y, FactionData x)
			{
				if (x == null)
				{
					if (y == null)
					{
						return 0;
					}
					return -1;
				}
				else
				{
					if (y == null)
					{
						return 1;
					}
					if (x.numMembers >= GameEngine.Instance.LocalWorldData.Faction_MaxMembers)
					{
						if (y.numMembers >= GameEngine.Instance.LocalWorldData.Faction_MaxMembers)
						{
							return x.factionName.CompareTo(y.factionName);
						}
						return 1;
					}
					else
					{
						if (y.numMembers >= GameEngine.Instance.LocalWorldData.Faction_MaxMembers)
						{
							return -1;
						}
						if (x.openForApplications)
						{
							if (y.openForApplications)
							{
								return x.factionName.CompareTo(y.factionName);
							}
							return -1;
						}
						else
						{
							if (y.openForApplications)
							{
								return 1;
							}
							return x.factionName.CompareTo(y.factionName);
						}
					}
				}
			}
		}
	}
}
