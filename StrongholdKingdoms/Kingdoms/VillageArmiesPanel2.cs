using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x020004CA RID: 1226
	public class VillageArmiesPanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06002D5D RID: 11613 RVA: 0x000215BA File Offset: 0x0001F7BA
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06002D5E RID: 11614 RVA: 0x000215CA File Offset: 0x0001F7CA
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06002D5F RID: 11615 RVA: 0x000215DA File Offset: 0x0001F7DA
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06002D60 RID: 11616 RVA: 0x000215EC File Offset: 0x0001F7EC
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06002D61 RID: 11617 RVA: 0x000215F9 File Offset: 0x0001F7F9
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closing();
		}

		// Token: 0x06002D62 RID: 11618 RVA: 0x00021613 File Offset: 0x0001F813
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06002D63 RID: 11619 RVA: 0x00021620 File Offset: 0x0001F820
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06002D64 RID: 11620 RVA: 0x0002162D File Offset: 0x0001F82D
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002D65 RID: 11621 RVA: 0x00240E94 File Offset: 0x0023F094
		private void InitializeComponent()
		{
			this.focusPanel = new Panel();
			base.SuspendLayout();
			this.focusPanel.BackColor = global::ARGBColors.Transparent;
			this.focusPanel.ForeColor = global::ARGBColors.Transparent;
			this.focusPanel.Location = new Point(988, 3);
			this.focusPanel.Name = "focusPanel";
			this.focusPanel.Size = new Size(1, 1);
			this.focusPanel.TabIndex = 0;
			base.AutoScaleMode = AutoScaleMode.None;
			base.Controls.Add(this.focusPanel);
			this.MaximumSize = new Size(992, 10000);
			this.MinimumSize = new Size(992, 566);
			base.Name = "VillageArmiesPanel2";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x06002D66 RID: 11622 RVA: 0x00240F80 File Offset: 0x0023F180
		public VillageArmiesPanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.focusPanel.Focus();
		}

		// Token: 0x06002D67 RID: 11623 RVA: 0x00241108 File Offset: 0x0023F308
		public void init(bool resized)
		{
			int height = base.Height;
			VillageArmiesPanel2.instance = this;
			base.clearControls();
			this.backgroundImage.Image = GFXLibrary.body_background_002;
			this.backgroundImage.Size = new Size(base.Width, height - 40);
			this.backgroundImage.Tile = true;
			this.backgroundImage.Position = new Point(0, 40);
			base.addControl(this.backgroundImage);
			this.backgroundLeftEdge.Image = GFXLibrary.body_background_canvas_left_edge;
			this.backgroundLeftEdge.Position = new Point(0, 0);
			this.backgroundLeftEdge.Size = new Size(this.backgroundLeftEdge.Image.Width, height - 40);
			this.backgroundLeftEdge.Tile = true;
			this.backgroundImage.addControl(this.backgroundLeftEdge);
			this.headerImage.Size = new Size(base.Width, 40);
			this.headerImage.Position = new Point(0, 0);
			base.addControl(this.headerImage);
			this.headerImage.CreateX(GFXLibrary.mail_top_drag_bar_left, GFXLibrary.mail_top_drag_bar_middle, GFXLibrary.mail_top_drag_bar_right, -2, 2);
			int selectedMenuVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
			this.parishNameLabel.Text = SK.Text("AllArmiesPanel_Attacks", "Attacks") + " : " + GameEngine.Instance.World.getVillageNameOrType(selectedMenuVillage);
			this.parishNameLabel.Color = global::ARGBColors.White;
			this.parishNameLabel.DropShadowColor = global::ARGBColors.Black;
			this.parishNameLabel.Position = new Point(20, 0);
			this.parishNameLabel.Size = new Size(base.Width - 40, 40);
			this.parishNameLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
			this.parishNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerImage.addControl(this.parishNameLabel);
			this.blockYSize = (height - 40 - 56) / 2;
			this.headerLabelsImage.Size = new Size(base.Width - 25 - 23, 28);
			this.headerLabelsImage.Position = new Point(25, 5);
			this.backgroundImage.addControl(this.headerLabelsImage);
			this.headerLabelsImage.Create(GFXLibrary.brown_mail2_field_bar_mail_left, GFXLibrary.brown_mail2_field_bar_mail_middle, GFXLibrary.brown_mail2_field_bar_mail_right);
			this.divider2Image.Image = GFXLibrary.brown_mail2_field_bar_mail_divider;
			this.divider2Image.Position = new Point(300, 0);
			this.headerLabelsImage.addControl(this.divider2Image);
			this.divider3Image.Image = GFXLibrary.brown_mail2_field_bar_mail_divider;
			this.divider3Image.Position = new Point(678, 0);
			this.headerLabelsImage.addControl(this.divider3Image);
			this.outGoingAttacksLabel.Text = SK.Text("VillageArmiesPanel_Target_Village", "Target Village");
			this.outGoingAttacksLabel.Color = global::ARGBColors.Black;
			this.outGoingAttacksLabel.Position = new Point(12, -2);
			this.outGoingAttacksLabel.Size = new Size(223, this.headerLabelsImage.Height);
			this.outGoingAttacksLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.outGoingAttacksLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.outGoingAttacksLabel);
			this.outGoingArrivesLabel.Text = SK.Text("AllArmiesPanel_Arrives", "Arrives");
			this.outGoingArrivesLabel.Color = global::ARGBColors.Black;
			this.outGoingArrivesLabel.Position = new Point(683, -2);
			this.outGoingArrivesLabel.Size = new Size(114, this.headerLabelsImage.Height);
			this.outGoingArrivesLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.outGoingArrivesLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.outGoingArrivesLabel);
			this.headerLabelsImage2.Size = new Size(base.Width - 25 - 23, 28);
			this.headerLabelsImage2.Position = new Point(25, this.blockYSize + 5);
			this.backgroundImage.addControl(this.headerLabelsImage2);
			this.headerLabelsImage2.Create(GFXLibrary.brown_mail2_field_bar_mail_left, GFXLibrary.brown_mail2_field_bar_mail_middle, GFXLibrary.brown_mail2_field_bar_mail_right);
			this.divider5Image.Image = GFXLibrary.brown_mail2_field_bar_mail_divider;
			this.divider5Image.Position = new Point(300, 0);
			this.headerLabelsImage2.addControl(this.divider5Image);
			this.divider6Image.Image = GFXLibrary.brown_mail2_field_bar_mail_divider;
			this.divider6Image.Position = new Point(678, 0);
			this.headerLabelsImage2.addControl(this.divider6Image);
			this.incomingAttacksLabel.Text = SK.Text("VillageArmiesPanel_From", "From") + ":";
			this.incomingAttacksLabel.Color = global::ARGBColors.Black;
			this.incomingAttacksLabel.Position = new Point(12, -2);
			this.incomingAttacksLabel.Size = new Size(224, this.headerLabelsImage.Height);
			this.incomingAttacksLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.incomingAttacksLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage2.addControl(this.incomingAttacksLabel);
			this.incomingArrivesLabel.Text = SK.Text("AllArmiesPanel_Arrives", "Arrives");
			this.incomingArrivesLabel.Color = global::ARGBColors.Black;
			this.incomingArrivesLabel.Position = new Point(683, -2);
			this.incomingArrivesLabel.Size = new Size(114, this.headerLabelsImage.Height);
			this.incomingArrivesLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.incomingArrivesLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage2.addControl(this.incomingArrivesLabel);
			this.outgoingScrollArea.Position = new Point(25, 40);
			this.outgoingScrollArea.Size = new Size(915, this.blockYSize - 40 - 10);
			this.outgoingScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(915, this.blockYSize - 40 - 10));
			this.backgroundImage.addControl(this.outgoingScrollArea);
			int value = this.outgoingScrollBar.Value;
			this.outgoingScrollBar.Position = new Point(943, 40);
			this.outgoingScrollBar.Size = new Size(24, this.blockYSize - 40 - 10);
			this.backgroundImage.addControl(this.outgoingScrollBar);
			this.outgoingScrollBar.Value = 0;
			this.outgoingScrollBar.Max = 100;
			this.outgoingScrollBar.NumVisibleLines = 25;
			this.outgoingScrollBar.Create(null, null, null, GFXLibrary.brown_24wide_thumb_top, GFXLibrary.brown_24wide_thumb_middle, GFXLibrary.brown_24wide_thumb_bottom);
			this.outgoingScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.wallScrollBarMoved));
			this.incomingScrollArea.Position = new Point(25, 35 + this.blockYSize + 5);
			this.incomingScrollArea.Size = new Size(915, this.blockYSize - 40 - 10);
			this.incomingScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(915, this.blockYSize - 40 - 10));
			this.backgroundImage.addControl(this.incomingScrollArea);
			int value2 = this.incomingScrollBar.Value;
			this.incomingScrollBar.Position = new Point(943, 35 + this.blockYSize + 5);
			this.incomingScrollBar.Size = new Size(24, this.blockYSize - 40 - 10);
			this.backgroundImage.addControl(this.incomingScrollBar);
			this.incomingScrollBar.Value = 0;
			this.incomingScrollBar.Max = 100;
			this.incomingScrollBar.NumVisibleLines = 25;
			this.incomingScrollBar.Create(null, null, null, GFXLibrary.brown_24wide_thumb_top, GFXLibrary.brown_24wide_thumb_middle, GFXLibrary.brown_24wide_thumb_bottom);
			this.incomingScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.incomingWallScrollBarMoved));
			this.smallPeasantImage.Image = GFXLibrary.armies_screen_troops;
			this.smallPeasantImage.Position = new Point(323, -10);
			this.headerLabelsImage.addControl(this.smallPeasantImage);
			if (!resized)
			{
				SparseArray armyArray = GameEngine.Instance.World.getArmyArray();
				this.armyList.Clear();
				foreach (object obj in armyArray)
				{
					WorldMap.LocalArmyData item = (WorldMap.LocalArmyData)obj;
					this.armyList.Add(item);
				}
				this.armyList.Sort(this.armyComparer);
			}
			this.addArmies();
			if (resized)
			{
				this.outgoingScrollBar.Value = value;
				this.incomingScrollBar.Value = value2;
			}
			this.btnClose.ImageNorm = GFXLibrary.brown_misc_button_blue_210wide_normal;
			this.btnClose.ImageOver = GFXLibrary.brown_misc_button_blue_210wide_over;
			this.btnClose.ImageClick = GFXLibrary.brown_misc_button_blue_210wide_pushed;
			this.btnClose.Position = new Point(base.Width - 230, height - 40 - 40 - 4);
			this.btnClose.Text.Text = SK.Text("GENERIC_Close", "Close");
			this.btnClose.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.btnClose.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.btnClose.TextYOffset = -3;
			this.btnClose.Text.Color = global::ARGBColors.Black;
			this.btnClose.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "VillageArmiesPanel2_close");
			this.backgroundImage.addControl(this.btnClose);
		}

		// Token: 0x06002D68 RID: 11624 RVA: 0x00241BA4 File Offset: 0x0023FDA4
		public void update()
		{
			bool flag = false;
			double localTime = DXTimer.GetCurrentMilliseconds() / 1000.0;
			foreach (VillageArmiesPanel2.ArmyLine armyLine in this.lineList)
			{
				if (!armyLine.update(localTime))
				{
					flag = true;
				}
			}
			foreach (VillageArmiesPanel2.ArmyLine armyLine2 in this.lineList2)
			{
				if (!armyLine2.update(localTime))
				{
					flag = true;
				}
			}
			if (flag)
			{
				this.init(false);
			}
		}

		// Token: 0x06002D69 RID: 11625 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void logout()
		{
		}

		// Token: 0x06002D6A RID: 11626 RVA: 0x00241C60 File Offset: 0x0023FE60
		private void wallScrollBarMoved()
		{
			int value = this.outgoingScrollBar.Value;
			this.outgoingScrollArea.Position = new Point(this.outgoingScrollArea.X, 40 - value);
			this.outgoingScrollArea.ClipRect = new Rectangle(this.outgoingScrollArea.ClipRect.X, value, this.outgoingScrollArea.ClipRect.Width, this.outgoingScrollArea.ClipRect.Height);
			this.outgoingScrollArea.invalidate();
			this.outgoingScrollBar.invalidate();
		}

		// Token: 0x06002D6B RID: 11627 RVA: 0x00241CF8 File Offset: 0x0023FEF8
		private void incomingWallScrollBarMoved()
		{
			int value = this.incomingScrollBar.Value;
			this.incomingScrollArea.Position = new Point(this.incomingScrollArea.X, 35 + this.blockYSize + 5 - value);
			this.incomingScrollArea.ClipRect = new Rectangle(this.incomingScrollArea.ClipRect.X, value, this.incomingScrollArea.ClipRect.Width, this.incomingScrollArea.ClipRect.Height);
			this.incomingScrollArea.invalidate();
			this.incomingScrollBar.invalidate();
		}

		// Token: 0x06002D6C RID: 11628 RVA: 0x0000ADE9 File Offset: 0x00008FE9
		public void closing()
		{
			InterfaceMgr.Instance.closeDonatePopup();
		}

		// Token: 0x06002D6D RID: 11629 RVA: 0x00241D9C File Offset: 0x0023FF9C
		public void addArmies()
		{
			this.outgoingScrollArea.clearControls();
			this.incomingScrollArea.clearControls();
			int num = 0;
			int num2 = 0;
			this.lineList.Clear();
			this.lineList2.Clear();
			int selectedMenuVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
			long num3 = -1L;
			int num4 = 0;
			int num5 = 0;
			double num6 = DXTimer.GetCurrentMilliseconds() / 1000.0;
			foreach (WorldMap.LocalArmyData localArmyData in this.armyList)
			{
				if (localArmyData.travelFromVillageID == selectedMenuVillage)
				{
					VillageArmiesPanel2.ArmyLine armyLine = new VillageArmiesPanel2.ArmyLine();
					if (num != 0)
					{
						num += 5;
					}
					armyLine.Position = new Point(0, num);
					bool showButton = localArmyData.lootType < 0;
					if (localArmyData.localEndTime == 0.0)
					{
						showButton = false;
					}
					else
					{
						double localEndTime = localArmyData.localEndTime;
						if (localArmyData.localStartTime + (double)(GameEngine.Instance.LocalWorldData.AttackCancelDuration * 60) < num6)
						{
							showButton = false;
						}
					}
					armyLine.initSent(num4, localArmyData.targetVillageID, localArmyData.numPeasants, localArmyData.numArchers, localArmyData.numPikemen, localArmyData.numSwordsmen, localArmyData.numCatapults, localArmyData.numScouts, localArmyData.serverEndTime, localArmyData.armyID, showButton, this, localArmyData.lootType >= 0);
					this.outgoingScrollArea.addControl(armyLine);
					num += armyLine.Height;
					this.lineList.Add(armyLine);
					num4++;
				}
				if (localArmyData.targetVillageID == selectedMenuVillage && localArmyData.lootType < 0)
				{
					VillageArmiesPanel2.ArmyLine armyLine2 = new VillageArmiesPanel2.ArmyLine();
					if (num2 != 0)
					{
						num2 += 5;
					}
					if (localArmyData.armyID > num3)
					{
						num3 = localArmyData.armyID;
					}
					armyLine2.Position = new Point(0, num2);
					bool tutorial = false;
					if (localArmyData.attackType == 13)
					{
						tutorial = true;
					}
					armyLine2.initIncoming(num5, localArmyData.travelFromVillageID, 0, 0, 0, 0, 0, 0, localArmyData.serverEndTime, localArmyData.armyID, false, this, false, tutorial, localArmyData.attackType);
					this.incomingScrollArea.addControl(armyLine2);
					num2 += armyLine2.Height;
					this.lineList2.Add(armyLine2);
					num5++;
				}
			}
			if (num3 > GameEngine.Instance.World.HighestArmyIDSeen)
			{
				GameEngine.Instance.World.HighestArmyIDSeen = num3;
				RemoteServices.Instance.SetHighestArmySeen(num3);
			}
			this.outgoingScrollArea.Size = new Size(this.outgoingScrollArea.Width, num);
			if (num < this.outgoingScrollBar.Height)
			{
				this.outgoingScrollBar.Visible = false;
			}
			else
			{
				this.outgoingScrollBar.Visible = true;
				this.outgoingScrollBar.NumVisibleLines = this.outgoingScrollBar.Height;
				this.outgoingScrollBar.Max = num - this.outgoingScrollBar.Height;
			}
			this.outgoingScrollArea.invalidate();
			this.outgoingScrollBar.invalidate();
			this.incomingScrollArea.Size = new Size(this.incomingScrollArea.Width, num2);
			if (num2 < this.incomingScrollBar.Height)
			{
				this.incomingScrollBar.Visible = false;
			}
			else
			{
				this.incomingScrollBar.Visible = true;
				this.incomingScrollBar.NumVisibleLines = this.incomingScrollBar.Height;
				this.incomingScrollBar.Max = num2 - this.incomingScrollBar.Height;
			}
			this.incomingScrollArea.invalidate();
			this.incomingScrollBar.invalidate();
			this.backgroundImage.invalidate();
			this.update();
		}

		// Token: 0x06002D6E RID: 11630 RVA: 0x0002164C File Offset: 0x0001F84C
		private void closeClick()
		{
			InterfaceMgr.Instance.setVillageTabSubMode(4);
		}

		// Token: 0x04003864 RID: 14436
		private DockableControl dockableControl;

		// Token: 0x04003865 RID: 14437
		private IContainer components;

		// Token: 0x04003866 RID: 14438
		private Panel focusPanel;

		// Token: 0x04003867 RID: 14439
		public static VillageArmiesPanel2 instance;

		// Token: 0x04003868 RID: 14440
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04003869 RID: 14441
		private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400386A RID: 14442
		private CustomSelfDrawPanel.CSDImage backgroundLeftEdge = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400386B RID: 14443
		private CustomSelfDrawPanel.CSDLabel parishNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400386C RID: 14444
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x0400386D RID: 14445
		private CustomSelfDrawPanel.CSDImage divider1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400386E RID: 14446
		private CustomSelfDrawPanel.CSDImage divider2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400386F RID: 14447
		private CustomSelfDrawPanel.CSDImage divider3Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003870 RID: 14448
		private CustomSelfDrawPanel.CSDImage divider4Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003871 RID: 14449
		private CustomSelfDrawPanel.CSDImage divider5Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003872 RID: 14450
		private CustomSelfDrawPanel.CSDImage divider6Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003873 RID: 14451
		private CustomSelfDrawPanel.CSDLabel outGoingAttacksLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003874 RID: 14452
		private CustomSelfDrawPanel.CSDLabel outGoingFromLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003875 RID: 14453
		private CustomSelfDrawPanel.CSDLabel outGoingArrivesLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003876 RID: 14454
		private CustomSelfDrawPanel.CSDLabel incomingAttacksLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003877 RID: 14455
		private CustomSelfDrawPanel.CSDLabel incomingAttackingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003878 RID: 14456
		private CustomSelfDrawPanel.CSDLabel incomingArrivesLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003879 RID: 14457
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage2 = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x0400387A RID: 14458
		private CustomSelfDrawPanel.CSDVertScrollBar outgoingScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x0400387B RID: 14459
		private CustomSelfDrawPanel.CSDArea outgoingScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400387C RID: 14460
		private CustomSelfDrawPanel.CSDVertScrollBar incomingScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x0400387D RID: 14461
		private CustomSelfDrawPanel.CSDArea incomingScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400387E RID: 14462
		private CustomSelfDrawPanel.CSDLabel diplomacyHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400387F RID: 14463
		private CustomSelfDrawPanel.CSDLabel diplomacyTextLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003880 RID: 14464
		private CustomSelfDrawPanel.CSDImage smallPeasantImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003881 RID: 14465
		private CustomSelfDrawPanel.CSDButton btnClose = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003882 RID: 14466
		private int blockYSize;

		// Token: 0x04003883 RID: 14467
		private List<WorldMap.LocalArmyData> armyList = new List<WorldMap.LocalArmyData>();

		// Token: 0x04003884 RID: 14468
		private List<VillageArmiesPanel2.ArmyLine> lineList = new List<VillageArmiesPanel2.ArmyLine>();

		// Token: 0x04003885 RID: 14469
		private List<VillageArmiesPanel2.ArmyLine> lineList2 = new List<VillageArmiesPanel2.ArmyLine>();

		// Token: 0x04003886 RID: 14470
		private VillageArmiesPanel2.ArmyComparer armyComparer = new VillageArmiesPanel2.ArmyComparer();

		// Token: 0x020004CB RID: 1227
		public class ArmyComparer : IComparer<WorldMap.LocalArmyData>
		{
			// Token: 0x06002D6F RID: 11631 RVA: 0x0001D3B7 File Offset: 0x0001B5B7
			public int Compare(WorldMap.LocalArmyData x, WorldMap.LocalArmyData y)
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
					if (x.armyID > y.armyID)
					{
						return 1;
					}
					if (x.armyID < y.armyID)
					{
						return -1;
					}
					return 0;
				}
			}
		}

		// Token: 0x020004CC RID: 1228
		public class ArmyLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06002D71 RID: 11633 RVA: 0x0024214C File Offset: 0x0024034C
			public void initSent(int position, int villageID, int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults, int numScouts, DateTime arrivalTime, long armyID, bool showButton, VillageArmiesPanel2 parent, bool returning)
			{
				this.initText(position, villageID, numPeasants, numArchers, numPikemen, numSwordsmen, numCatapults, numScouts, arrivalTime, armyID, showButton, parent, returning, true, false, 0);
			}

			// Token: 0x06002D72 RID: 11634 RVA: 0x0024217C File Offset: 0x0024037C
			public void initIncoming(int position, int villageID, int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults, int numScouts, DateTime arrivalTime, long armyID, bool showButton, VillageArmiesPanel2 parent, bool returning, bool tutorial, int attackType)
			{
				this.initText(position, villageID, numPeasants, numArchers, numPikemen, numSwordsmen, numCatapults, numScouts, arrivalTime, armyID, showButton, parent, returning, false, tutorial, attackType);
			}

			// Token: 0x06002D73 RID: 11635 RVA: 0x002421AC File Offset: 0x002403AC
			private void initText(int position, int villageID, int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults, int numScouts, DateTime arrivalTime, long armyID, bool showButton, VillageArmiesPanel2 parent, bool returning, bool showTroops, bool tutorial, int attackType)
			{
				this.m_parent = parent;
				this.m_position = position;
				this.ClipVisible = true;
				this.m_army = GameEngine.Instance.World.getArmy(armyID);
				this.m_origLoot = this.m_army.lootType;
				this.m_armyID = armyID;
				this.m_villageID = villageID;
				this.m_arrivalTime = arrivalTime;
				this.m_returning = returning;
				this.clearControls();
				if ((position & 1) == 0)
				{
					this.backgroundImage.Image = GFXLibrary.brown_lineitem_strip_02_light;
				}
				else
				{
					this.backgroundImage.Image = GFXLibrary.brown_lineitem_strip_02_dark;
				}
				this.backgroundImage.Position = new Point(0, 0);
				base.addControl(this.backgroundImage);
				this.Size = this.backgroundImage.Size;
				if (!tutorial)
				{
					this.lblVillage.Text = GameEngine.Instance.World.getVillageNameOrType(villageID);
				}
				else
				{
					this.lblVillage.Text = SK.Text("GENERIC_TUTORIAL", "Tutorial");
				}
				this.lblVillage.Color = global::ARGBColors.Black;
				this.lblVillage.RolloverColor = global::ARGBColors.White;
				this.lblVillage.Position = new Point(9, 0);
				this.lblVillage.Size = new Size(223, this.backgroundImage.Height);
				this.lblVillage.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblVillage.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.lblVillage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lblVillage_Click), "VillageArmiesPanel2_village");
				this.backgroundImage.addControl(this.lblVillage);
				this.lblReturning.Text = SK.Text("VillageArmySentLine_Returning", "Returning");
				this.lblReturning.Color = global::ARGBColors.Black;
				this.lblReturning.Position = new Point(821, 0);
				this.lblReturning.Size = new Size(110, this.backgroundImage.Height);
				this.lblReturning.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblReturning.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.backgroundImage.addControl(this.lblReturning);
				this.lblReturning.Visible = !showButton;
				if (!showButton)
				{
					if (this.m_returning)
					{
						this.lblReturning.Text = SK.Text("VillageArmySentLine_Returning", "Returning");
					}
					else
					{
						this.lblReturning.Text = SK.Text("GENERIC_Attacking", "Attacking");
					}
				}
				this.leftVillageID = villageID;
				this.lblArrivalTime.Text = "";
				this.lblArrivalTime.Color = global::ARGBColors.Black;
				this.lblArrivalTime.Position = new Point(683, 0);
				this.lblArrivalTime.Size = new Size(114, this.backgroundImage.Height);
				this.lblArrivalTime.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblArrivalTime.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.backgroundImage.addControl(this.lblArrivalTime);
				if (showTroops)
				{
					this.lblPeasants.Text = numPeasants.ToString();
					this.lblPeasants.Color = global::ARGBColors.Black;
					this.lblPeasants.Position = new Point(305, 0);
					this.lblPeasants.Size = new Size(55, this.backgroundImage.Height);
					this.lblPeasants.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
					this.lblPeasants.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.backgroundImage.addControl(this.lblPeasants);
					this.lblArchers.Text = numArchers.ToString();
					this.lblArchers.Color = global::ARGBColors.Black;
					this.lblArchers.Position = new Point(365, 0);
					this.lblArchers.Size = new Size(55, this.backgroundImage.Height);
					this.lblArchers.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
					this.lblArchers.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.backgroundImage.addControl(this.lblArchers);
					this.lblPikemen.Text = numPikemen.ToString();
					this.lblPikemen.Color = global::ARGBColors.Black;
					this.lblPikemen.Position = new Point(425, 0);
					this.lblPikemen.Size = new Size(55, this.backgroundImage.Height);
					this.lblPikemen.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
					this.lblPikemen.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.backgroundImage.addControl(this.lblPikemen);
					this.lblSwordsmen.Text = numSwordsmen.ToString();
					this.lblSwordsmen.Color = global::ARGBColors.Black;
					this.lblSwordsmen.Position = new Point(485, 0);
					this.lblSwordsmen.Size = new Size(55, this.backgroundImage.Height);
					this.lblSwordsmen.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
					this.lblSwordsmen.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.backgroundImage.addControl(this.lblSwordsmen);
					this.lblCatapults.Text = numCatapults.ToString();
					this.lblCatapults.Color = global::ARGBColors.Black;
					this.lblCatapults.Position = new Point(545, 0);
					this.lblCatapults.Size = new Size(55, this.backgroundImage.Height);
					this.lblCatapults.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
					this.lblCatapults.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.backgroundImage.addControl(this.lblCatapults);
					this.lblScouts.Text = numScouts.ToString();
					this.lblScouts.Color = global::ARGBColors.Black;
					this.lblScouts.Position = new Point(605, 0);
					this.lblScouts.Size = new Size(55, this.backgroundImage.Height);
					this.lblScouts.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
					this.lblScouts.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.backgroundImage.addControl(this.lblScouts);
				}
				if (attackType == 30)
				{
					this.lblPeasants.Text = SK.Text("AllArmiesSentLine_Vassal_Support", "Vassal Support");
					this.lblPeasants.Color = global::ARGBColors.Black;
					this.lblPeasants.Position = new Point(305, 0);
					this.lblPeasants.Size = new Size(250, this.backgroundImage.Height);
					this.lblPeasants.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
					this.lblPeasants.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
					this.backgroundImage.addControl(this.lblPeasants);
				}
				if (attackType == 31)
				{
					this.lblPeasants.Text = SK.Text("AllArmiesSentLine_Capital_Support", "Capital Support");
					this.lblPeasants.Color = global::ARGBColors.Black;
					this.lblPeasants.Position = new Point(305, 0);
					this.lblPeasants.Size = new Size(250, this.backgroundImage.Height);
					this.lblPeasants.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
					this.lblPeasants.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
					this.backgroundImage.addControl(this.lblPeasants);
				}
				if (showButton)
				{
					this.btnCancel.ImageNorm = GFXLibrary.brown_mail2_button_blue_141wide_normal;
					this.btnCancel.ImageOver = GFXLibrary.brown_mail2_button_blue_141wide_over;
					this.btnCancel.ImageClick = GFXLibrary.brown_mail2_button_blue_141wide_pushed;
					this.btnCancel.Position = new Point(760, 3);
					this.btnCancel.Text.Text = SK.Text("GENERIC_Cancel", "Cancel");
					this.btnCancel.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.btnCancel.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
					this.btnCancel.TextYOffset = -3;
					this.btnCancel.Text.Color = global::ARGBColors.Black;
					this.btnCancel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.cancelClick), "VillageArmiesPanel2_cancel");
					this.backgroundImage.addControl(this.btnCancel);
				}
				if (!this.update(DXTimer.GetCurrentMilliseconds() / 1000.0))
				{
					this.btnCancel.Visible = false;
				}
				base.invalidate();
			}

			// Token: 0x06002D74 RID: 11636 RVA: 0x00242A94 File Offset: 0x00240C94
			public bool update(double localTime)
			{
				if (this.btnCancel.Visible)
				{
					if (this.m_army.localEndTime == 0.0)
					{
						return false;
					}
					if (this.m_army.localStartTime + (double)(GameEngine.Instance.LocalWorldData.AttackCancelDuration * 60) < localTime)
					{
						return false;
					}
				}
				else
				{
					WorldMap.LocalArmyData army = GameEngine.Instance.World.getArmy(this.m_armyID);
					if (army == null || army.lootType != this.m_origLoot)
					{
						return false;
					}
				}
				DateTime currentServerTime = VillageMap.getCurrentServerTime();
				int num = (int)((this.m_arrivalTime - currentServerTime).TotalSeconds + 0.5);
				if (num < 1)
				{
					num = 0;
				}
				this.lblArrivalTime.Text = VillageMap.createBuildTimeString(num);
				return true;
			}

			// Token: 0x06002D75 RID: 11637 RVA: 0x00242B54 File Offset: 0x00240D54
			private void cancelClick()
			{
				if (this.m_army == null)
				{
					return;
				}
				double num = DXTimer.GetCurrentMilliseconds() / 1000.0;
				double localEndTime = this.m_army.localEndTime;
				if (this.m_army.localStartTime + (double)(GameEngine.Instance.LocalWorldData.AttackCancelDuration * 60) >= num && this.m_army.lootType < 0)
				{
					RemoteServices.Instance.set_CancelCastleAttack_UserCallBack(new RemoteServices.CancelCastleAttack_UserCallBack(this.cancelCastleAttackCallBack));
					RemoteServices.Instance.CancelCastleAttack(this.m_army.armyID);
					this.btnCancel.Visible = false;
					return;
				}
				this.btnCancel.Visible = false;
				if (this.m_parent != null)
				{
					this.m_parent.init(false);
				}
			}

			// Token: 0x06002D76 RID: 11638 RVA: 0x00242C10 File Offset: 0x00240E10
			private void cancelCastleAttackCallBack(CancelCastleAttack_ReturnType returnData)
			{
				if (!returnData.Success)
				{
					return;
				}
				if (returnData.armyData != null)
				{
					ArmyReturnData[] armyReturnData = new ArmyReturnData[]
					{
						returnData.armyData
					};
					GameEngine.Instance.World.doGetArmyData(armyReturnData, null, false);
					GameEngine.Instance.World.addExistingArmy(returnData.armyData.armyID);
					GameEngine.Instance.World.deleteArmy(returnData.oldArmyID);
					if (SpecialVillageTypes.IS_TREASURE_CASTLE(GameEngine.Instance.World.getSpecial(returnData.armyData.targetVillageID)))
					{
						GameEngine.Instance.World.setLastTreasureCastleAttackTime(DateTime.MinValue);
					}
				}
				this.btnCancel.Visible = false;
				if (this.m_parent != null)
				{
					this.m_parent.init(false);
				}
			}

			// Token: 0x06002D77 RID: 11639 RVA: 0x00242CD8 File Offset: 0x00240ED8
			private void lblVillage_Click()
			{
				if (this.leftVillageID >= 0)
				{
					Point villageLocation = GameEngine.Instance.World.getVillageLocation(this.leftVillageID);
					InterfaceMgr.Instance.changeTab(9);
					InterfaceMgr.Instance.changeTab(0);
					InterfaceMgr.Instance.closeParishPanel();
					GameEngine.Instance.World.startMultiStageZoom(10000.0, (double)villageLocation.X, (double)villageLocation.Y);
					InterfaceMgr.Instance.displaySelectedVillagePanel(this.leftVillageID, false, true, true, false);
				}
			}

			// Token: 0x04003887 RID: 14471
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04003888 RID: 14472
			private CustomSelfDrawPanel.CSDLabel lblVillage = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04003889 RID: 14473
			private CustomSelfDrawPanel.CSDLabel lblReturning = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400388A RID: 14474
			private CustomSelfDrawPanel.CSDLabel lblPeasants = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400388B RID: 14475
			private CustomSelfDrawPanel.CSDLabel lblArchers = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400388C RID: 14476
			private CustomSelfDrawPanel.CSDLabel lblPikemen = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400388D RID: 14477
			private CustomSelfDrawPanel.CSDLabel lblSwordsmen = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400388E RID: 14478
			private CustomSelfDrawPanel.CSDLabel lblCatapults = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400388F RID: 14479
			private CustomSelfDrawPanel.CSDLabel lblScouts = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04003890 RID: 14480
			private CustomSelfDrawPanel.CSDLabel lblArrivalTime = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04003891 RID: 14481
			private CustomSelfDrawPanel.CSDButton btnCancel = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x04003892 RID: 14482
			private int m_position = -1000;

			// Token: 0x04003893 RID: 14483
			private VillageArmiesPanel2 m_parent;

			// Token: 0x04003894 RID: 14484
			private int leftVillageID = -1;

			// Token: 0x04003895 RID: 14485
			private int m_villageID = -1;

			// Token: 0x04003896 RID: 14486
			private bool m_returning;

			// Token: 0x04003897 RID: 14487
			private long m_armyID = -1L;

			// Token: 0x04003898 RID: 14488
			private DateTime m_arrivalTime = DateTime.Now;

			// Token: 0x04003899 RID: 14489
			private WorldMap.LocalArmyData m_army;

			// Token: 0x0400389A RID: 14490
			private int m_origLoot = -1;
		}
	}
}
