using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Upgrade;
using Upgrade.Services;

namespace Kingdoms
{
	// Token: 0x020000C9 RID: 201
	public class AllVassalsPanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06000591 RID: 1425 RVA: 0x0006D118 File Offset: 0x0006B318
		public AllVassalsPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.focusPanel.Focus();
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x0000AEBC File Offset: 0x000090BC
		public void reinit()
		{
			this.init(false);
		}

		// Token: 0x06000593 RID: 1427 RVA: 0x0006D210 File Offset: 0x0006B410
		public void init(bool resized)
		{
			int height = base.Height;
			AllVassalsPanel.instance = this;
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
			InterfaceMgr.Instance.getSelectedMenuVillage();
			this.parishNameLabel.Text = SK.Text("Vassals_Overview", "Vassals Overview");
			this.parishNameLabel.Color = global::ARGBColors.White;
			this.parishNameLabel.DropShadowColor = global::ARGBColors.Black;
			this.parishNameLabel.Position = new Point(20, 0);
			this.parishNameLabel.Size = new Size(base.Width - 40, 40);
			this.parishNameLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
			this.parishNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerImage.addControl(this.parishNameLabel);
			this.blockYSize = height - 40 - 56;
			this.headerLabelsImage.Size = new Size(base.Width - 25 - 23, 28);
			this.headerLabelsImage.Position = new Point(25, 5);
			this.backgroundImage.addControl(this.headerLabelsImage);
			this.headerLabelsImage.Create(GFXLibrary.brown_mail2_field_bar_mail_left, GFXLibrary.brown_mail2_field_bar_mail_middle, GFXLibrary.brown_mail2_field_bar_mail_right);
			this.divider2Image.Image = GFXLibrary.brown_mail2_field_bar_mail_divider;
			this.divider2Image.Position = new Point(580, 0);
			this.headerLabelsImage.addControl(this.divider2Image);
			this.yourVassalsLabel.Text = SK.Text("VassalControlPanel_Your_Vassals", "Your Vassals");
			this.yourVassalsLabel.Color = global::ARGBColors.Black;
			this.yourVassalsLabel.Position = new Point(12, -3);
			this.yourVassalsLabel.Size = new Size(223, this.headerLabelsImage.Height);
			this.yourVassalsLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.yourVassalsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.yourVassalsLabel);
			this.vassalScrollArea.Position = new Point(25, 40);
			this.vassalScrollArea.Size = new Size(915, this.blockYSize - 40 - 10);
			this.vassalScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(915, this.blockYSize - 40 - 10));
			this.backgroundImage.addControl(this.vassalScrollArea);
			int value = this.vassalScrollBar.Value;
			this.vassalScrollBar.Position = new Point(943, 40);
			this.vassalScrollBar.Size = new Size(24, this.blockYSize - 40 - 10);
			this.backgroundImage.addControl(this.vassalScrollBar);
			this.vassalScrollBar.Value = 0;
			this.vassalScrollBar.Max = 100;
			this.vassalScrollBar.NumVisibleLines = 25;
			this.vassalScrollBar.Create(null, null, null, GFXLibrary.brown_24wide_thumb_top, GFXLibrary.brown_24wide_thumb_middle, GFXLibrary.brown_24wide_thumb_bottom);
			this.vassalScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.wallScrollBarMoved));
			this.smallPeasantImage.Image = GFXLibrary.armies_screen_troops;
			this.smallPeasantImage.Position = new Point(603, -10);
			this.smallPeasantImage.ClipRect = new Rectangle(0, 0, this.smallPeasantImage.Image.Width * 5 / 6, this.smallPeasantImage.Image.Height);
			this.headerLabelsImage.addControl(this.smallPeasantImage);
			if (resized)
			{
				this.vassalScrollBar.Value = value;
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
			this.btnClose.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "AllVassalsPanel_close");
			this.backgroundImage.addControl(this.btnClose);
			this.chkBotView = new CustomSelfDrawPanel.CSDCheckBox
			{
				CheckedImage = GFXLibrary.mrhp_world_filter_check[0],
				UncheckedImage = GFXLibrary.mrhp_world_filter_check[1],
				Position = new Point(this.btnClose.Position.X - this.btnClose.Width - 15, this.btnClose.Position.Y),
				Checked = AllVassalsPanel.BotViewEnabled
			};
			this.chkBotView.CBLabel.Text = "Bot's View";
			this.chkBotView.CBLabel.Color = global::ARGBColors.Black;
			this.chkBotView.CBLabel.Position = new Point(20, -1);
			this.chkBotView.CBLabel.Size = new Size(150, 50);
			this.chkBotView.CBLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.chkBotView.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.VassalsOverviewEnable));
			this.chkBotView.Visible = true;
			this.backgroundImage.addControl(this.chkBotView);
			this.cachedVassalInfo = null;
			RemoteServices.Instance.set_VassalInfo_UserCallBack(new RemoteServices.VassalInfo_UserCallBack(this.vassalInfoCallBack));
			VillageMap village = GameEngine.Instance.Village;
			if (village != null)
			{
				RemoteServices.Instance.VassalInfo(-1);
			}
			this.reAddVassals();
		}

		// Token: 0x06000594 RID: 1428 RVA: 0x0000AEC5 File Offset: 0x000090C5
		private void VassalsOverviewEnable()
		{
			AllVassalsPanel.BotViewEnabled = this.chkBotView.Checked;
			this.reAddVassals();
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x0000AEDD File Offset: 0x000090DD
		public void vassalInfoCallBack(VassalInfo_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.cachedVassalInfo = returnData.vassals;
				this.reAddVassals();
				GameEngine.Instance.World.updateUserVassals();
			}
		}

		// Token: 0x06000596 RID: 1430 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x06000597 RID: 1431 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void logout()
		{
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x0006D964 File Offset: 0x0006BB64
		private void wallScrollBarMoved()
		{
			int value = this.vassalScrollBar.Value;
			this.vassalScrollArea.Position = new Point(this.vassalScrollArea.X, 40 - value);
			this.vassalScrollArea.ClipRect = new Rectangle(this.vassalScrollArea.ClipRect.X, value, this.vassalScrollArea.ClipRect.Width, this.vassalScrollArea.ClipRect.Height);
			this.vassalScrollArea.invalidate();
			this.vassalScrollBar.invalidate();
		}

		// Token: 0x06000599 RID: 1433 RVA: 0x0000ADE9 File Offset: 0x00008FE9
		public void closing()
		{
			InterfaceMgr.Instance.closeDonatePopup();
		}

		// Token: 0x0600059A RID: 1434 RVA: 0x0006D9FC File Offset: 0x0006BBFC
		internal void reAddVassals()
		{
			this.lineList.Clear();
			this.vassalScrollArea.clearControls();
			int num = 0;
			int num2 = 0;
			if (this.cachedVassalInfo != null)
			{
				VassalInfo[] array = this.cachedVassalInfo;
				foreach (VassalInfo vassalInfo in array)
				{
					if (num != 0)
					{
						num += 5;
					}
					AllVassalsPanel.ArmyLine armyLine = new AllVassalsPanel.ArmyLine();
					armyLine.Position = new Point(0, num);
					if (this.chkBotView.Checked)
					{
						GetVassalArmyInfo_ReturnType vassalCacheInfo = VassalsOverview.GetVassalCacheInfo(vassalInfo.villageID);
						if (vassalCacheInfo != null)
						{
							int numPeasants = vassalCacheInfo.numStationedTroops_Peasants + vassalCacheInfo.numAttackingTroops_Peasants + vassalCacheInfo.numEnrouteTroops_Peasants;
							int numArchers = vassalCacheInfo.numStationedTroops_Archers + vassalCacheInfo.numAttackingTroops_Archers + vassalCacheInfo.numEnrouteTroops_Archers;
							int numPikemen = vassalCacheInfo.numStationedTroops_Pikemen + vassalCacheInfo.numAttackingTroops_Pikemen + vassalCacheInfo.numEnrouteTroops_Pikemen;
							int numSwordsmen = vassalCacheInfo.numStationedTroops_Swordsmen + vassalCacheInfo.numAttackingTroops_Swordsmen + vassalCacheInfo.numEnrouteTroops_Swordsmen;
							int numCatapults = vassalCacheInfo.numStationedTroops_Catapults + vassalCacheInfo.numAttackingTroops_Catapults + vassalCacheInfo.numEnrouteTroops_Catapults;
							armyLine.init(num2, this, vassalInfo.yourVillageID, vassalInfo.villageID, vassalInfo.honourPerSecond, numPeasants, numArchers, numPikemen, numSwordsmen, numCatapults, vassalInfo.vassalPlayerName);
						}
						else
						{
							armyLine.init(num2, this, vassalInfo.yourVillageID, vassalInfo.villageID, vassalInfo.honourPerSecond, -1, -1, -1, -1, -1, vassalInfo.vassalPlayerName);
						}
					}
					else
					{
						armyLine.init(num2, this, vassalInfo.yourVillageID, vassalInfo.villageID, vassalInfo.honourPerSecond, vassalInfo.stationed_Peasants, vassalInfo.stationed_Archers, vassalInfo.stationed_Pikemen, vassalInfo.stationed_Swordsmen, vassalInfo.stationed_Catapults, vassalInfo.vassalPlayerName);
					}
					this.vassalScrollArea.addControl(armyLine);
					num += armyLine.Height;
					this.lineList.Add(armyLine);
					num2++;
				}
			}
			this.vassalScrollArea.Size = new Size(this.vassalScrollArea.Width, num);
			if (num < this.vassalScrollBar.Height)
			{
				this.vassalScrollBar.Visible = false;
			}
			else
			{
				this.vassalScrollBar.Visible = true;
				this.vassalScrollBar.NumVisibleLines = this.vassalScrollBar.Height;
				this.vassalScrollBar.Max = num - this.vassalScrollBar.Height;
			}
			this.vassalScrollArea.invalidate();
			this.vassalScrollBar.invalidate();
			this.backgroundImage.invalidate();
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x0006DC74 File Offset: 0x0006BE74
		public void breakVassalage(int yourVillageID, int villageID)
		{
			this.villageIDRef = villageID;
			this.yourVillageIDRef = yourVillageID;
			DialogResult dialogResult = MyMessageBox.Show(SK.Text("VassalControlPanel_BreakVassalage_Warning", "Breaking from your vassal will mean any troops stationed there will be lost."), SK.Text("VassalControlPanel_BreakVassalage", "Break Vassalage?"), MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				this.BreakVassalage();
			}
		}

		// Token: 0x0600059C RID: 1436 RVA: 0x0006DCC0 File Offset: 0x0006BEC0
		private void BreakVassalage()
		{
			RemoteServices.Instance.set_BreakVassalage_UserCallBack(new RemoteServices.BreakVassalage_UserCallBack(this.breakVassalageCallBack));
			RemoteServices.Instance.BreakVassalage(this.yourVillageIDRef, this.villageIDRef);
			GameEngine.Instance.World.breakVassal(this.yourVillageIDRef, this.villageIDRef);
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x0000AF08 File Offset: 0x00009108
		public void breakVassalageCallBack(BreakVassalage_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.cachedVassalInfo = returnData.vassals;
				this.reAddVassals();
				GameEngine.Instance.World.updateUserVassals();
			}
			CursorManager.SetCursor(CursorManager.CursorType.Default, InterfaceMgr.Instance.ParentForm);
		}

		// Token: 0x0600059E RID: 1438 RVA: 0x0000AF43 File Offset: 0x00009143
		private void closeClick()
		{
			InterfaceMgr.Instance.initVillageTab();
			InterfaceMgr.Instance.setVillageTabSubMode(8);
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x0000AF5A File Offset: 0x0000915A
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x060005A0 RID: 1440 RVA: 0x0000AF6A File Offset: 0x0000916A
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x060005A1 RID: 1441 RVA: 0x0000AF7A File Offset: 0x0000917A
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x060005A2 RID: 1442 RVA: 0x0000AF8C File Offset: 0x0000918C
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x0000AF99 File Offset: 0x00009199
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closing();
		}

		// Token: 0x060005A4 RID: 1444 RVA: 0x0000AFB3 File Offset: 0x000091B3
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x060005A5 RID: 1445 RVA: 0x0000AFC0 File Offset: 0x000091C0
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x060005A6 RID: 1446 RVA: 0x0000AFCD File Offset: 0x000091CD
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060005A7 RID: 1447 RVA: 0x0006DD14 File Offset: 0x0006BF14
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
			base.Name = "AllVassalsPanel";
			this.MaximumSize = new Size(992, 10000);
			this.MinimumSize = new Size(992, 566);
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x040006DD RID: 1757
		public static AllVassalsPanel instance;

		// Token: 0x040006DE RID: 1758
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x040006DF RID: 1759
		private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040006E0 RID: 1760
		private CustomSelfDrawPanel.CSDImage backgroundLeftEdge = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040006E1 RID: 1761
		private CustomSelfDrawPanel.CSDLabel parishNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040006E2 RID: 1762
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x040006E3 RID: 1763
		private CustomSelfDrawPanel.CSDImage divider1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040006E4 RID: 1764
		private CustomSelfDrawPanel.CSDImage divider2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040006E5 RID: 1765
		private CustomSelfDrawPanel.CSDLabel yourVassalsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040006E6 RID: 1766
		private CustomSelfDrawPanel.CSDLabel outGoingFromLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040006E7 RID: 1767
		private CustomSelfDrawPanel.CSDVertScrollBar vassalScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x040006E8 RID: 1768
		private CustomSelfDrawPanel.CSDArea vassalScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040006E9 RID: 1769
		private CustomSelfDrawPanel.CSDImage smallPeasantImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040006EA RID: 1770
		private CustomSelfDrawPanel.CSDImage smallPeasantImage2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040006EB RID: 1771
		private CustomSelfDrawPanel.CSDButton btnClose = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040006EC RID: 1772
		private int blockYSize;

		// Token: 0x040006ED RID: 1773
		private VassalInfo liegeLordInfo = new VassalInfo();

		// Token: 0x040006EE RID: 1774
		private VassalInfo[] cachedVassalInfo;

		// Token: 0x040006EF RID: 1775
		private List<AllVassalsPanel.ArmyLine> lineList = new List<AllVassalsPanel.ArmyLine>();

		// Token: 0x040006F0 RID: 1776
		private CustomSelfDrawPanel.CSDCheckBox chkBotView = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x040006F1 RID: 1777
		private static bool BotViewEnabled;

		// Token: 0x040006F2 RID: 1778
		private int villageIDRef;

		// Token: 0x040006F3 RID: 1779
		private int yourVillageIDRef;

		// Token: 0x040006F4 RID: 1780
		private MyMessageBoxPopUp PopUpRef;

		// Token: 0x040006F5 RID: 1781
		private DockableControl dockableControl;

		// Token: 0x040006F6 RID: 1782
		private IContainer components;

		// Token: 0x040006F7 RID: 1783
		private Panel focusPanel;

		// Token: 0x020000CA RID: 202
		public class ArmyLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x060005A8 RID: 1448 RVA: 0x0006DE00 File Offset: 0x0006C000
			public void init(int position, AllVassalsPanel parent, int yourVillageID, int villageID, double honourPerSecond, int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults, string username)
			{
				this.m_parent = parent;
				this.m_position = position;
				this.m_villageID = villageID;
				this.m_yourVillageID = yourVillageID;
				this.ClipVisible = true;
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
				this.lblYourVillage.Text = GameEngine.Instance.World.getVillageNameOrType(this.m_yourVillageID);
				this.lblYourVillage.Color = global::ARGBColors.Black;
				this.lblYourVillage.RolloverColor = global::ARGBColors.White;
				this.lblYourVillage.Position = new Point(9, 0);
				this.lblYourVillage.Size = new Size(290, this.backgroundImage.Height);
				this.lblYourVillage.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblYourVillage.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.lblYourVillage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lblYourVillage_Click), "AllVassalsPanel_village");
				this.backgroundImage.addControl(this.lblYourVillage);
				this.lblVillage.Text = GameEngine.Instance.World.getVillageNameOrType(villageID);
				if (username.Length > 0)
				{
					CustomSelfDrawPanel.CSDLabel csdlabel = this.lblVillage;
					csdlabel.Text = csdlabel.Text + " (" + username + ")";
				}
				this.lblVillage.Color = global::ARGBColors.Black;
				this.lblVillage.RolloverColor = global::ARGBColors.White;
				this.lblVillage.Position = new Point(279, 0);
				this.lblVillage.Size = new Size(290, this.backgroundImage.Height);
				this.lblVillage.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblVillage.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.lblVillage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lblVillage_Click), "AllVassalsPanel_other_village");
				this.backgroundImage.addControl(this.lblVillage);
				this.lblPeasants.Text = numPeasants.ToString();
				this.lblPeasants.Color = global::ARGBColors.Black;
				this.lblPeasants.RolloverColor = global::ARGBColors.White;
				this.lblPeasants.Position = new Point(585, 0);
				this.lblPeasants.Size = new Size(55, this.backgroundImage.Height);
				this.lblPeasants.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblPeasants.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.lblPeasants.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.troopClick), "AllVassalsPanel_troops");
				this.backgroundImage.addControl(this.lblPeasants);
				this.lblArchers.Text = numArchers.ToString();
				this.lblArchers.Color = global::ARGBColors.Black;
				this.lblArchers.RolloverColor = global::ARGBColors.White;
				this.lblArchers.Position = new Point(645, 0);
				this.lblArchers.Size = new Size(55, this.backgroundImage.Height);
				this.lblArchers.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblArchers.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.lblArchers.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.troopClick), "AllVassalsPanel_troops");
				this.backgroundImage.addControl(this.lblArchers);
				this.lblPikemen.Text = numPikemen.ToString();
				this.lblPikemen.Color = global::ARGBColors.Black;
				this.lblPikemen.RolloverColor = global::ARGBColors.White;
				this.lblPikemen.Position = new Point(705, 0);
				this.lblPikemen.Size = new Size(55, this.backgroundImage.Height);
				this.lblPikemen.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblPikemen.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.lblPikemen.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.troopClick), "AllVassalsPanel_troops");
				this.backgroundImage.addControl(this.lblPikemen);
				this.lblSwordsmen.Text = numSwordsmen.ToString();
				this.lblSwordsmen.Color = global::ARGBColors.Black;
				this.lblSwordsmen.RolloverColor = global::ARGBColors.White;
				this.lblSwordsmen.Position = new Point(765, 0);
				this.lblSwordsmen.Size = new Size(55, this.backgroundImage.Height);
				this.lblSwordsmen.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblSwordsmen.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.lblSwordsmen.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.troopClick), "AllVassalsPanel_troops");
				this.backgroundImage.addControl(this.lblSwordsmen);
				this.lblCatapults.Text = numCatapults.ToString();
				this.lblCatapults.Color = global::ARGBColors.Black;
				this.lblCatapults.RolloverColor = global::ARGBColors.White;
				this.lblCatapults.Position = new Point(825, 0);
				this.lblCatapults.Size = new Size(55, this.backgroundImage.Height);
				this.lblCatapults.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblCatapults.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.lblCatapults.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.troopClick), "AllVassalsPanel_troops");
				this.backgroundImage.addControl(this.lblCatapults);
				if (numPeasants == -1)
				{
					this.lblArchers.Visible = false;
					this.lblPikemen.Visible = false;
					this.lblSwordsmen.Visible = false;
					this.lblCatapults.Visible = false;
					this.lblPeasants.Text = LNG.Print("Load");
					this.lblPeasants.setClickDelegate(delegate()
					{
						this.lblPeasants.Text = "Wait...";
						VassalsOverview.QuickLoadVassal(this, villageID);
					}, "AllVassalsPanel_troops");
					this.backgroundImage.addControl(this.lblPeasants);
				}
				base.invalidate();
			}

			// Token: 0x060005A9 RID: 1449 RVA: 0x0006E48C File Offset: 0x0006C68C
			public void update(int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults)
			{
				this.lblArchers.Visible = true;
				this.lblPikemen.Visible = true;
				this.lblSwordsmen.Visible = true;
				this.lblCatapults.Visible = true;
				this.lblPeasants.Text = numPeasants.ToString();
				this.lblArchers.Text = numArchers.ToString();
				this.lblPikemen.Text = numPikemen.ToString();
				this.lblSwordsmen.Text = numSwordsmen.ToString();
				this.lblCatapults.Text = numCatapults.ToString();
				base.invalidate();
			}

			// Token: 0x060005AA RID: 1450 RVA: 0x0006E52C File Offset: 0x0006C72C
			private void lblYourVillage_Click()
			{
				if (this.m_yourVillageID >= 0)
				{
					InterfaceMgr.Instance.selectUserVillage(this.m_yourVillageID, false);
					GameEngine.Instance.SkipVillageTab();
					InterfaceMgr.Instance.getMainTabBar().changeTab(9);
					InterfaceMgr.Instance.getMainTabBar().changeTab(1);
					InterfaceMgr.Instance.setVillageTabSubMode(8);
				}
			}

			// Token: 0x060005AB RID: 1451 RVA: 0x0006E58C File Offset: 0x0006C78C
			private void lblVillage_Click()
			{
				if (this.m_villageID >= 0)
				{
					Point villageLocation = GameEngine.Instance.World.getVillageLocation(this.m_villageID);
					InterfaceMgr.Instance.changeTab(9);
					InterfaceMgr.Instance.changeTab(0);
					InterfaceMgr.Instance.closeParishPanel();
					GameEngine.Instance.World.startMultiStageZoom(10000.0, (double)villageLocation.X, (double)villageLocation.Y);
					InterfaceMgr.Instance.displaySelectedVillagePanel(this.m_villageID, false, true, true, false);
				}
			}

			// Token: 0x060005AC RID: 1452 RVA: 0x0006E618 File Offset: 0x0006C818
			private void troopClick()
			{
				if (this.m_villageID >= 0)
				{
					InterfaceMgr.Instance.selectUserVillage(this.m_yourVillageID, false);
					GameEngine.Instance.SkipVillageTab();
					InterfaceMgr.Instance.getMainTabBar().changeTab(9);
					InterfaceMgr.Instance.getMainTabBar().changeTab(1);
					InterfaceMgr.Instance.setVassalArmiesVillage(this.m_villageID);
					InterfaceMgr.Instance.setVillageTabSubMode(15);
				}
			}

			// Token: 0x040006F8 RID: 1784
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040006F9 RID: 1785
			private CustomSelfDrawPanel.CSDLabel lblVillage = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040006FA RID: 1786
			private CustomSelfDrawPanel.CSDLabel lblYourVillage = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040006FB RID: 1787
			private CustomSelfDrawPanel.CSDLabel lblPeasants = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040006FC RID: 1788
			private CustomSelfDrawPanel.CSDLabel lblArchers = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040006FD RID: 1789
			private CustomSelfDrawPanel.CSDLabel lblPikemen = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040006FE RID: 1790
			private CustomSelfDrawPanel.CSDLabel lblSwordsmen = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040006FF RID: 1791
			private CustomSelfDrawPanel.CSDLabel lblCatapults = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000700 RID: 1792
			private int m_position = -1000;

			// Token: 0x04000701 RID: 1793
			private AllVassalsPanel m_parent;

			// Token: 0x04000702 RID: 1794
			private int m_villageID = -1;

			// Token: 0x04000703 RID: 1795
			private int m_yourVillageID = -1;
		}
	}
}
