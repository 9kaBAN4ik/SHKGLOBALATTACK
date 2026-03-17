using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020001B9 RID: 441
	public class FactionDiplomacyPanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06001082 RID: 4226 RVA: 0x0011C94C File Offset: 0x0011AB4C
		public FactionDiplomacyPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06001083 RID: 4227 RVA: 0x0011CA18 File Offset: 0x0011AC18
		public void init(bool resized)
		{
			int height = base.Height;
			this.blockYSize = height / 2;
			FactionDiplomacyPanel.instance = this;
			base.clearControls();
			this.sidebar.addSideBar(4, this);
			this.mainBackgroundImage.FillColor = Color.FromArgb(134, 153, 165);
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = new Size(base.Width - 200, height);
			base.addControl(this.mainBackgroundImage);
			this.backgroundFade.Image = GFXLibrary.background_top;
			this.backgroundFade.Position = new Point(0, 0);
			this.backgroundFade.Size = new Size(base.Width - 200, this.backgroundFade.Image.Height);
			this.mainBackgroundImage.addControl(this.backgroundFade);
			this.headerLabelsImage.Size = new Size(base.Width - 25 - 23 - 200, 28);
			this.headerLabelsImage.Position = new Point(25, 5);
			this.mainBackgroundImage.addControl(this.headerLabelsImage);
			this.headerLabelsImage.Create(GFXLibrary.mail2_field_bar_mail_left, GFXLibrary.mail2_field_bar_mail_middle, GFXLibrary.mail2_field_bar_mail_right);
			this.headerLabelsImage2.Size = new Size(base.Width - 25 - 23 - 200, 28);
			this.headerLabelsImage2.Position = new Point(25, this.blockYSize + 5);
			this.mainBackgroundImage.addControl(this.headerLabelsImage2);
			this.headerLabelsImage2.Create(GFXLibrary.mail2_field_bar_mail_left, GFXLibrary.mail2_field_bar_mail_middle, GFXLibrary.mail2_field_bar_mail_right);
			this.alliesLabel.Text = SK.Text("FactionDiplomacy_Allies", "Allies");
			this.alliesLabel.Color = global::ARGBColors.Black;
			this.alliesLabel.Position = new Point(9, -2);
			this.alliesLabel.Size = new Size(323, this.headerLabelsImage.Height);
			this.alliesLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.alliesLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.alliesLabel);
			this.enemiesLabel.Text = SK.Text("FactionDiplomacy_Enemies", "Enemies");
			this.enemiesLabel.Color = global::ARGBColors.Black;
			this.enemiesLabel.Position = new Point(9, -2);
			this.enemiesLabel.Size = new Size(323, this.headerLabelsImage.Height);
			this.enemiesLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.enemiesLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage2.addControl(this.enemiesLabel);
			InterfaceMgr.Instance.setVillageHeading(SK.Text("AllArmiesPanel_Diplomacy", "Diplomacy"));
			this.alliesScrollArea.Position = new Point(25, 40);
			this.alliesScrollArea.Size = new Size(715, this.blockYSize - 40 - 10);
			this.alliesScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(915, this.blockYSize - 40 - 10));
			this.mainBackgroundImage.addControl(this.alliesScrollArea);
			this.mouseWheelOverlay1.Position = this.alliesScrollArea.Position;
			this.mouseWheelOverlay1.Size = this.alliesScrollArea.Size;
			this.mouseWheelOverlay1.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mouseWheelMoved1));
			this.mainBackgroundImage.addControl(this.mouseWheelOverlay1);
			int value = this.alliesScrollBar.Value;
			this.alliesScrollBar.Position = new Point(733, 40);
			this.alliesScrollBar.Size = new Size(24, this.blockYSize - 40 - 10);
			this.mainBackgroundImage.addControl(this.alliesScrollBar);
			this.alliesScrollBar.Value = 0;
			this.alliesScrollBar.Max = 100;
			this.alliesScrollBar.NumVisibleLines = 25;
			this.alliesScrollBar.Create(null, null, null, GFXLibrary._24wide_thumb_top, GFXLibrary._24wide_thumb_middle, GFXLibrary._24wide_thumb_bottom);
			this.alliesScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.wallScrollBarMoved));
			this.enemiesScrollArea.Position = new Point(25, 35 + this.blockYSize + 5);
			this.enemiesScrollArea.Size = new Size(715, this.blockYSize - 40 - 10);
			this.enemiesScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(915, this.blockYSize - 40 - 10));
			this.mainBackgroundImage.addControl(this.enemiesScrollArea);
			this.mouseWheelOverlay2.Position = this.enemiesScrollArea.Position;
			this.mouseWheelOverlay2.Size = this.enemiesScrollArea.Size;
			this.mouseWheelOverlay2.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mouseWheelMoved2));
			this.mainBackgroundImage.addControl(this.mouseWheelOverlay2);
			int value2 = this.enemiesScrollBar.Value;
			this.enemiesScrollBar.Position = new Point(733, 35 + this.blockYSize + 5);
			this.enemiesScrollBar.Size = new Size(24, this.blockYSize - 40 - 10);
			this.mainBackgroundImage.addControl(this.enemiesScrollBar);
			this.enemiesScrollBar.Value = 0;
			this.enemiesScrollBar.Max = 100;
			this.enemiesScrollBar.NumVisibleLines = 25;
			this.enemiesScrollBar.Create(null, null, null, GFXLibrary._24wide_thumb_top, GFXLibrary._24wide_thumb_middle, GFXLibrary._24wide_thumb_bottom);
			this.enemiesScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.incomingWallScrollBarMoved));
			if (!resized)
			{
				CustomSelfDrawPanel.FactionPanelSideBar.downloadCurrentFactionInfo();
			}
			this.addPlayers();
		}

		// Token: 0x06001084 RID: 4228 RVA: 0x000121B4 File Offset: 0x000103B4
		public void update()
		{
			this.sidebar.update();
		}

		// Token: 0x06001085 RID: 4229 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void logout()
		{
		}

		// Token: 0x06001086 RID: 4230 RVA: 0x0011D060 File Offset: 0x0011B260
		private void wallScrollBarMoved()
		{
			int value = this.alliesScrollBar.Value;
			this.alliesScrollArea.Position = new Point(this.alliesScrollArea.X, 40 - value);
			this.alliesScrollArea.ClipRect = new Rectangle(this.alliesScrollArea.ClipRect.X, value, this.alliesScrollArea.ClipRect.Width, this.alliesScrollArea.ClipRect.Height);
			this.alliesScrollArea.invalidate();
			this.alliesScrollBar.invalidate();
		}

		// Token: 0x06001087 RID: 4231 RVA: 0x000121C1 File Offset: 0x000103C1
		private void mouseWheelMoved1(int delta)
		{
			if (this.alliesScrollBar.Visible)
			{
				if (delta < 0)
				{
					this.alliesScrollBar.scrollDown(40);
					return;
				}
				if (delta > 0)
				{
					this.alliesScrollBar.scrollUp(40);
				}
			}
		}

		// Token: 0x06001088 RID: 4232 RVA: 0x0011D0F8 File Offset: 0x0011B2F8
		private void incomingWallScrollBarMoved()
		{
			int value = this.enemiesScrollBar.Value;
			this.enemiesScrollArea.Position = new Point(this.enemiesScrollArea.X, 35 + this.blockYSize + 5 - value);
			this.enemiesScrollArea.ClipRect = new Rectangle(this.enemiesScrollArea.ClipRect.X, value, this.enemiesScrollArea.ClipRect.Width, this.enemiesScrollArea.ClipRect.Height);
			this.enemiesScrollArea.invalidate();
			this.enemiesScrollBar.invalidate();
		}

		// Token: 0x06001089 RID: 4233 RVA: 0x000121F3 File Offset: 0x000103F3
		private void mouseWheelMoved2(int delta)
		{
			if (this.enemiesScrollBar.Visible)
			{
				if (delta < 0)
				{
					this.enemiesScrollBar.scrollDown(40);
					return;
				}
				if (delta > 0)
				{
					this.enemiesScrollBar.scrollUp(40);
				}
			}
		}

		// Token: 0x0600108A RID: 4234 RVA: 0x0000ADE9 File Offset: 0x00008FE9
		public void closing()
		{
			InterfaceMgr.Instance.closeDonatePopup();
		}

		// Token: 0x0600108B RID: 4235 RVA: 0x0011D19C File Offset: 0x0011B39C
		public void addPlayers()
		{
			this.alliesScrollArea.clearControls();
			this.enemiesScrollArea.clearControls();
			int num = 0;
			int num2 = 0;
			int[] factionAllies = GameEngine.Instance.World.FactionAllies;
			if (factionAllies != null)
			{
				int[] array = factionAllies;
				foreach (int factionID in array)
				{
					FactionData faction = GameEngine.Instance.World.getFaction(factionID);
					if (faction != null && faction.active)
					{
						FactionDiplomacyPanel.FactionsAllianceLine factionsAllianceLine = new FactionDiplomacyPanel.FactionsAllianceLine();
						if (num != 0)
						{
							num += 5;
						}
						factionsAllianceLine.Position = new Point(0, num);
						factionsAllianceLine.init(faction, num2, true, this);
						this.alliesScrollArea.addControl(factionsAllianceLine);
						num += factionsAllianceLine.Height;
						num2++;
					}
				}
			}
			this.alliesScrollArea.Size = new Size(this.alliesScrollArea.Width, num);
			if (num < this.alliesScrollBar.Height)
			{
				this.alliesScrollBar.Visible = false;
			}
			else
			{
				this.alliesScrollBar.Visible = true;
				this.alliesScrollBar.NumVisibleLines = this.alliesScrollBar.Height;
				this.alliesScrollBar.Max = num - this.alliesScrollBar.Height;
			}
			this.alliesScrollArea.invalidate();
			this.alliesScrollBar.invalidate();
			num = 0;
			int[] factionEnemies = GameEngine.Instance.World.FactionEnemies;
			if (factionEnemies != null)
			{
				int[] array3 = factionEnemies;
				foreach (int factionID2 in array3)
				{
					FactionData faction2 = GameEngine.Instance.World.getFaction(factionID2);
					if (faction2 != null && faction2.active)
					{
						FactionDiplomacyPanel.FactionsAllianceLine factionsAllianceLine2 = new FactionDiplomacyPanel.FactionsAllianceLine();
						if (num != 0)
						{
							num += 5;
						}
						factionsAllianceLine2.Position = new Point(0, num);
						factionsAllianceLine2.init(faction2, num2, false, this);
						this.enemiesScrollArea.addControl(factionsAllianceLine2);
						num += factionsAllianceLine2.Height;
						num2++;
					}
				}
			}
			this.enemiesScrollArea.Size = new Size(this.enemiesScrollArea.Width, num);
			if (num < this.enemiesScrollBar.Height)
			{
				this.enemiesScrollBar.Visible = false;
			}
			else
			{
				this.enemiesScrollBar.Visible = true;
				this.enemiesScrollBar.NumVisibleLines = this.enemiesScrollBar.Height;
				this.enemiesScrollBar.Max = num - this.enemiesScrollBar.Height;
			}
			this.enemiesScrollArea.invalidate();
			this.enemiesScrollBar.invalidate();
			this.update();
			base.Invalidate();
		}

		// Token: 0x0600108C RID: 4236 RVA: 0x00012225 File Offset: 0x00010425
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x0600108D RID: 4237 RVA: 0x00012235 File Offset: 0x00010435
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x0600108E RID: 4238 RVA: 0x00012245 File Offset: 0x00010445
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x0600108F RID: 4239 RVA: 0x00012257 File Offset: 0x00010457
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06001090 RID: 4240 RVA: 0x00012264 File Offset: 0x00010464
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closing();
		}

		// Token: 0x06001091 RID: 4241 RVA: 0x0001227E File Offset: 0x0001047E
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06001092 RID: 4242 RVA: 0x0001228B File Offset: 0x0001048B
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06001093 RID: 4243 RVA: 0x00012298 File Offset: 0x00010498
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001094 RID: 4244 RVA: 0x0011D418 File Offset: 0x0011B618
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.MaximumSize = new Size(992, 10000);
			this.MinimumSize = new Size(992, 566);
			base.Name = "FactionDiplomacyPanel";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x0400169A RID: 5786
		public const int PANEL_ID = 44;

		// Token: 0x0400169B RID: 5787
		public static FactionDiplomacyPanel instance;

		// Token: 0x0400169C RID: 5788
		private CustomSelfDrawPanel.CSDFill mainBackgroundImage = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x0400169D RID: 5789
		private CustomSelfDrawPanel.CSDImage backgroundFade = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400169E RID: 5790
		private CustomSelfDrawPanel.CSDLabel titleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400169F RID: 5791
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x040016A0 RID: 5792
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage2 = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x040016A1 RID: 5793
		private CustomSelfDrawPanel.CSDVertScrollBar alliesScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x040016A2 RID: 5794
		private CustomSelfDrawPanel.CSDArea alliesScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040016A3 RID: 5795
		private CustomSelfDrawPanel.CSDControl mouseWheelOverlay1 = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x040016A4 RID: 5796
		private CustomSelfDrawPanel.CSDVertScrollBar enemiesScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x040016A5 RID: 5797
		private CustomSelfDrawPanel.CSDArea enemiesScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040016A6 RID: 5798
		private CustomSelfDrawPanel.CSDControl mouseWheelOverlay2 = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x040016A7 RID: 5799
		private CustomSelfDrawPanel.CSDLabel alliesLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040016A8 RID: 5800
		private CustomSelfDrawPanel.CSDLabel enemiesLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040016A9 RID: 5801
		private int blockYSize;

		// Token: 0x040016AA RID: 5802
		private CustomSelfDrawPanel.FactionPanelSideBar sidebar = new CustomSelfDrawPanel.FactionPanelSideBar();

		// Token: 0x040016AB RID: 5803
		private DockableControl dockableControl;

		// Token: 0x040016AC RID: 5804
		private IContainer components;

		// Token: 0x020001BA RID: 442
		public class FactionsAllianceLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06001095 RID: 4245 RVA: 0x0011D484 File Offset: 0x0011B684
			public void init(FactionData factionData, int position, bool ally, FactionDiplomacyPanel parent)
			{
				this.m_parent = parent;
				this.m_position = position;
				this.m_factionData = factionData;
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
				this.backgroundImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.factionClick));
				base.addControl(this.backgroundImage);
				this.Size = this.backgroundImage.Size;
				this.flagImage.createFromFlagData(factionData.flagData);
				this.flagImage.Position = new Point(0, 0);
				this.flagImage.Scale = 0.25;
				this.flagImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.factionClick));
				base.addControl(this.flagImage);
				this.factionName.Text = factionData.factionName;
				this.factionName.Color = global::ARGBColors.Black;
				this.factionName.Position = new Point(9, 0);
				this.factionName.Size = new Size(500, this.backgroundImage.Height);
				this.factionName.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.factionName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.factionName.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.factionClick));
				this.backgroundImage.addControl(this.factionName);
			}

			// Token: 0x06001096 RID: 4246 RVA: 0x00007CE0 File Offset: 0x00005EE0
			public void update()
			{
			}

			// Token: 0x06001097 RID: 4247 RVA: 0x000122B7 File Offset: 0x000104B7
			private void factionClick()
			{
				if (this.m_factionData != null)
				{
					GameEngine.Instance.playInterfaceSound("FactionDiplomacyPanel_faction_clicked");
					InterfaceMgr.Instance.showFactionPanel(this.m_factionData.factionID);
				}
			}

			// Token: 0x040016AD RID: 5805
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040016AE RID: 5806
			private CustomSelfDrawPanel.CSDLabel factionName = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040016AF RID: 5807
			private int m_position = -1000;

			// Token: 0x040016B0 RID: 5808
			private FactionData m_factionData;

			// Token: 0x040016B1 RID: 5809
			private CustomSelfDrawPanel.CSDFactionFlagImage flagImage = new CustomSelfDrawPanel.CSDFactionFlagImage();

			// Token: 0x040016B2 RID: 5810
			private FactionDiplomacyPanel m_parent;
		}
	}
}
