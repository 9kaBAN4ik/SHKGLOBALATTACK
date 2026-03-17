using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020001BB RID: 443
	public class FactionInvitePanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06001099 RID: 4249 RVA: 0x00012319 File Offset: 0x00010519
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x0600109A RID: 4250 RVA: 0x00012329 File Offset: 0x00010529
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x0600109B RID: 4251 RVA: 0x00012339 File Offset: 0x00010539
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x0600109C RID: 4252 RVA: 0x0001234B File Offset: 0x0001054B
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x0600109D RID: 4253 RVA: 0x00012358 File Offset: 0x00010558
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closing();
		}

		// Token: 0x0600109E RID: 4254 RVA: 0x00012372 File Offset: 0x00010572
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x0600109F RID: 4255 RVA: 0x0001237F File Offset: 0x0001057F
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x060010A0 RID: 4256 RVA: 0x0001238C File Offset: 0x0001058C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060010A1 RID: 4257 RVA: 0x0011D624 File Offset: 0x0011B824
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.MaximumSize = new Size(992, 10000);
			this.MinimumSize = new Size(992, 566);
			base.Name = "FactionInvitePanel";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x060010A2 RID: 4258 RVA: 0x0011D690 File Offset: 0x0011B890
		public FactionInvitePanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x060010A3 RID: 4259 RVA: 0x0011D77C File Offset: 0x0011B97C
		public void init(bool resized)
		{
			int height = base.Height;
			this.blockYSize = height / 2;
			FactionInvitePanel.instance = this;
			base.clearControls();
			this.sidebar.addSideBar(0, this);
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
			this.playerNameLabel.Text = SK.Text("FactionsPanel_Users", "Invites");
			this.playerNameLabel.Color = global::ARGBColors.Black;
			this.playerNameLabel.Position = new Point(9, -2);
			this.playerNameLabel.Size = new Size(323, this.headerLabelsImage.Height);
			this.playerNameLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.playerNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.playerNameLabel);
			this.headerLabelsImage2.Size = new Size(base.Width - 25 - 23 - 200, 28);
			this.headerLabelsImage2.Position = new Point(25, this.blockYSize);
			this.mainBackgroundImage.addControl(this.headerLabelsImage2);
			this.headerLabelsImage2.Create(GFXLibrary.mail2_field_bar_mail_left, GFXLibrary.mail2_field_bar_mail_middle, GFXLibrary.mail2_field_bar_mail_right);
			this.applicationsNameLabel.Text = SK.Text("FactionInvites_Applications", "Applications");
			this.applicationsNameLabel.Color = global::ARGBColors.Black;
			this.applicationsNameLabel.Position = new Point(9, -2);
			this.applicationsNameLabel.Size = new Size(323, this.headerLabelsImage.Height);
			this.applicationsNameLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.applicationsNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage2.addControl(this.applicationsNameLabel);
			InterfaceMgr.Instance.setVillageHeading(SK.Text("FactionInvites_Faction_Invites", "Faction Invites"));
			this.wallScrollArea.Position = new Point(25, 38);
			this.wallScrollArea.Size = new Size(705, this.blockYSize - 50);
			this.wallScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(705, this.blockYSize - 50));
			this.mainBackgroundImage.addControl(this.wallScrollArea);
			this.mouseWheelOverlay.Position = this.wallScrollArea.Position;
			this.mouseWheelOverlay.Size = this.wallScrollArea.Size;
			this.mouseWheelOverlay.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mouseWheelMoved));
			this.mainBackgroundImage.addControl(this.mouseWheelOverlay);
			int value = this.wallScrollBar.Value;
			this.wallScrollBar.Visible = false;
			this.wallScrollBar.Position = new Point(733, 38);
			this.wallScrollBar.Size = new Size(24, this.blockYSize - 50);
			this.mainBackgroundImage.addControl(this.wallScrollBar);
			this.wallScrollBar.Value = 0;
			this.wallScrollBar.Max = 100;
			this.wallScrollBar.NumVisibleLines = 25;
			this.wallScrollBar.Create(null, null, null, GFXLibrary._24wide_thumb_top, GFXLibrary._24wide_thumb_middle, GFXLibrary._24wide_thumb_bottom);
			this.wallScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.wallScrollBarMoved));
			this.appScrollArea.Position = new Point(25, 38 + this.blockYSize);
			this.appScrollArea.Size = new Size(705, this.blockYSize - 50);
			this.appScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(705, this.blockYSize - 50));
			this.mainBackgroundImage.addControl(this.appScrollArea);
			this.appMouseWheelOverlay.Position = this.appScrollArea.Position;
			this.appMouseWheelOverlay.Size = this.appScrollArea.Size;
			this.appMouseWheelOverlay.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.appMouseWheelMoved));
			this.mainBackgroundImage.addControl(this.appMouseWheelOverlay);
			int value2 = this.appScrollBar.Value;
			this.appScrollBar.Visible = false;
			this.appScrollBar.Position = new Point(733, 38 + this.blockYSize);
			this.appScrollBar.Size = new Size(24, this.blockYSize - 50);
			this.mainBackgroundImage.addControl(this.appScrollBar);
			this.appScrollBar.Value = 0;
			this.appScrollBar.Max = 100;
			this.appScrollBar.NumVisibleLines = 25;
			this.appScrollBar.Create(null, null, null, GFXLibrary._24wide_thumb_top, GFXLibrary._24wide_thumb_middle, GFXLibrary._24wide_thumb_bottom);
			this.appScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.appScrollBarMoved));
			if (GameEngine.Instance.World.getRank() < 6)
			{
				this.rankLabel.Text = SK.Text("FACTION_INVITE_rank", "You don't currently have the required Rank (7) to join a Faction.");
				this.rankLabel.Color = global::ARGBColors.Black;
				this.rankLabel.Position = new Point(0, 50);
				this.rankLabel.Size = this.wallScrollArea.Size;
				this.rankLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				this.rankLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.mainBackgroundImage.addControl(this.rankLabel);
			}
			if (!resized)
			{
				CustomSelfDrawPanel.FactionPanelSideBar.downloadCurrentFactionInfo();
			}
			this.addPlayers();
		}

		// Token: 0x060010A4 RID: 4260 RVA: 0x000123AB File Offset: 0x000105AB
		public void update()
		{
			this.sidebar.update();
		}

		// Token: 0x060010A5 RID: 4261 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void logout()
		{
		}

		// Token: 0x060010A6 RID: 4262 RVA: 0x0011DE64 File Offset: 0x0011C064
		private void wallScrollBarMoved()
		{
			int value = this.wallScrollBar.Value;
			this.wallScrollArea.Position = new Point(this.wallScrollArea.X, 38 - value);
			this.wallScrollArea.ClipRect = new Rectangle(this.wallScrollArea.ClipRect.X, value, this.wallScrollArea.ClipRect.Width, this.wallScrollArea.ClipRect.Height);
			this.wallScrollArea.invalidate();
			this.wallScrollBar.invalidate();
		}

		// Token: 0x060010A7 RID: 4263 RVA: 0x000123B8 File Offset: 0x000105B8
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

		// Token: 0x060010A8 RID: 4264 RVA: 0x0011DEFC File Offset: 0x0011C0FC
		private void appScrollBarMoved()
		{
			int value = this.appScrollBar.Value;
			this.appScrollArea.Position = new Point(this.appScrollArea.X, 38 + this.blockYSize - value);
			this.appScrollArea.ClipRect = new Rectangle(this.appScrollArea.ClipRect.X, value, this.appScrollArea.ClipRect.Width, this.wallScrollArea.ClipRect.Height);
			this.appScrollArea.invalidate();
			this.appScrollBar.invalidate();
		}

		// Token: 0x060010A9 RID: 4265 RVA: 0x000123EA File Offset: 0x000105EA
		private void appMouseWheelMoved(int delta)
		{
			if (this.appScrollBar.Visible)
			{
				if (delta < 0)
				{
					this.appScrollBar.scrollDown(40);
					return;
				}
				if (delta > 0)
				{
					this.appScrollBar.scrollUp(40);
				}
			}
		}

		// Token: 0x060010AA RID: 4266 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void closing()
		{
		}

		// Token: 0x060010AB RID: 4267 RVA: 0x0011DF9C File Offset: 0x0011C19C
		public void addPlayers()
		{
			this.wallScrollArea.clearControls();
			this.appScrollArea.clearControls();
			int num = 0;
			int num2 = 0;
			this.lineList.Clear();
			this.lineList2.Clear();
			if (GameEngine.Instance.World.getRank() >= 6)
			{
				int num3 = 0;
				FactionInviteData[] factionInvites = GameEngine.Instance.World.FactionInvites;
				if (factionInvites != null)
				{
					FactionInviteData[] array = factionInvites;
					foreach (FactionInviteData factionInviteData in array)
					{
						FactionData faction = GameEngine.Instance.World.getFaction(factionInviteData.factionID);
						if (faction != null)
						{
							FactionInvitePanel.FactionInviteLine factionInviteLine = new FactionInvitePanel.FactionInviteLine();
							if (num != 0)
							{
								num += 5;
							}
							factionInviteLine.Position = new Point(0, num);
							factionInviteLine.init(faction, num3, this, true);
							this.wallScrollArea.addControl(factionInviteLine);
							num += factionInviteLine.Height;
							this.lineList.Add(factionInviteLine);
							num3++;
						}
					}
				}
				int num4 = 0;
				List<FactionInviteData> factionApplications = GameEngine.Instance.World.FactionApplications;
				if (factionApplications != null)
				{
					foreach (FactionInviteData factionInviteData2 in factionApplications)
					{
						FactionData faction2 = GameEngine.Instance.World.getFaction(factionInviteData2.factionID);
						if (faction2 != null)
						{
							FactionInvitePanel.FactionInviteLine factionInviteLine2 = new FactionInvitePanel.FactionInviteLine();
							if (num2 != 0)
							{
								num2 += 5;
							}
							factionInviteLine2.Position = new Point(0, num2);
							factionInviteLine2.init(faction2, num4, this, false);
							this.appScrollArea.addControl(factionInviteLine2);
							num2 += factionInviteLine2.Height;
							this.lineList2.Add(factionInviteLine2);
							num4++;
						}
					}
				}
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
			this.appScrollArea.Size = new Size(this.appScrollArea.Width, num2);
			if (num < this.appScrollBar.Height)
			{
				this.appScrollBar.Visible = false;
			}
			else
			{
				this.appScrollBar.Visible = true;
				this.appScrollBar.NumVisibleLines = this.appScrollBar.Height;
				this.appScrollBar.Max = num2 - this.appScrollBar.Height;
			}
			this.appScrollArea.invalidate();
			this.appScrollBar.invalidate();
			this.update();
			base.Invalidate();
		}

		// Token: 0x040016B3 RID: 5811
		public const int PANEL_ID = 41;

		// Token: 0x040016B4 RID: 5812
		private DockableControl dockableControl;

		// Token: 0x040016B5 RID: 5813
		private IContainer components;

		// Token: 0x040016B6 RID: 5814
		public static FactionInvitePanel instance;

		// Token: 0x040016B7 RID: 5815
		private CustomSelfDrawPanel.CSDFill mainBackgroundImage = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x040016B8 RID: 5816
		private CustomSelfDrawPanel.CSDImage backgroundFade = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040016B9 RID: 5817
		private CustomSelfDrawPanel.CSDLabel titleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040016BA RID: 5818
		private CustomSelfDrawPanel.CSDLabel playerNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040016BB RID: 5819
		private CustomSelfDrawPanel.CSDLabel applicationsNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040016BC RID: 5820
		private CustomSelfDrawPanel.CSDLabel rankLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040016BD RID: 5821
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x040016BE RID: 5822
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage2 = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x040016BF RID: 5823
		private CustomSelfDrawPanel.CSDVertScrollBar wallScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x040016C0 RID: 5824
		private CustomSelfDrawPanel.CSDArea wallScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040016C1 RID: 5825
		private CustomSelfDrawPanel.CSDControl mouseWheelOverlay = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x040016C2 RID: 5826
		private CustomSelfDrawPanel.CSDVertScrollBar appScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x040016C3 RID: 5827
		private CustomSelfDrawPanel.CSDArea appScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040016C4 RID: 5828
		private CustomSelfDrawPanel.CSDControl appMouseWheelOverlay = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x040016C5 RID: 5829
		private int blockYSize;

		// Token: 0x040016C6 RID: 5830
		private CustomSelfDrawPanel.FactionPanelSideBar sidebar = new CustomSelfDrawPanel.FactionPanelSideBar();

		// Token: 0x040016C7 RID: 5831
		private List<FactionInvitePanel.FactionInviteLine> lineList = new List<FactionInvitePanel.FactionInviteLine>();

		// Token: 0x040016C8 RID: 5832
		private List<FactionInvitePanel.FactionInviteLine> lineList2 = new List<FactionInvitePanel.FactionInviteLine>();

		// Token: 0x020001BC RID: 444
		public class FactionInviteLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x060010AC RID: 4268 RVA: 0x0011E27C File Offset: 0x0011C47C
			public void init(FactionData factionData, int position, FactionInvitePanel parent, bool invite)
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
				base.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
				base.addControl(this.backgroundImage);
				this.Size = this.backgroundImage.Size;
				this.flagImage.createFromFlagData(factionData.flagData);
				this.flagImage.Position = new Point(0, 0);
				this.flagImage.Scale = 0.25;
				this.flagImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
				base.addControl(this.flagImage);
				NumberFormatInfo nfi = GameEngine.NFI;
				this.playerName.Text = factionData.factionName;
				this.playerName.Color = global::ARGBColors.Black;
				this.playerName.Position = new Point(9, 0);
				this.playerName.Size = new Size(280, this.backgroundImage.Height);
				this.playerName.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.playerName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.playerName.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
				this.backgroundImage.addControl(this.playerName);
				if (!GameEngine.Instance.World.WorldEnded)
				{
					if (invite)
					{
						if (RemoteServices.Instance.UserFactionID < 0)
						{
							this.acceptButton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
							this.acceptButton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
							this.acceptButton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
							this.acceptButton.Position = new Point(350, 0);
							this.acceptButton.Text.Text = SK.Text("FactionInviteLine_Accept", "Accept");
							this.acceptButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
							this.acceptButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
							this.acceptButton.TextYOffset = -3;
							this.acceptButton.Text.Color = global::ARGBColors.Black;
							this.acceptButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.acceptClicked), "FactionInvitePanel_accept_clicked");
							this.backgroundImage.addControl(this.acceptButton);
						}
						this.declineButton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
						this.declineButton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
						this.declineButton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
						this.declineButton.Position = new Point(500, 0);
						this.declineButton.Text.Text = SK.Text("FactionInviteLine_Decline", "Decline");
						this.declineButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
						this.declineButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
						this.declineButton.TextYOffset = -3;
						this.declineButton.Text.Color = global::ARGBColors.Black;
						this.declineButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.declineClicked), "FactionInvitePanel_declined_clicked");
						this.backgroundImage.addControl(this.declineButton);
					}
					else
					{
						this.declineButton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
						this.declineButton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
						this.declineButton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
						this.declineButton.Position = new Point(500, 0);
						this.declineButton.Text.Text = SK.Text("GENERIC_Cancel", "Cancel");
						this.declineButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
						this.declineButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
						this.declineButton.TextYOffset = -3;
						this.declineButton.Text.Color = global::ARGBColors.Black;
						this.declineButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.appCancelClicked), "FactionInvitePanel_declined_clicked");
						this.backgroundImage.addControl(this.declineButton);
					}
				}
				base.invalidate();
			}

			// Token: 0x060010AD RID: 4269 RVA: 0x00007CE0 File Offset: 0x00005EE0
			public void update()
			{
			}

			// Token: 0x060010AE RID: 4270 RVA: 0x0001241C File Offset: 0x0001061C
			public void clickedLine()
			{
				GameEngine.Instance.playInterfaceSound("FactionInvitePanel_faction_clicked");
				InterfaceMgr.Instance.showFactionPanel(this.m_factionData.factionID);
			}

			// Token: 0x060010AF RID: 4271 RVA: 0x0011E72C File Offset: 0x0011C92C
			public void declineClicked()
			{
				this.declineButton.Enabled = false;
				this.acceptButton.Enabled = false;
				RemoteServices.Instance.set_FactionReplyToInvite_UserCallBack(new RemoteServices.FactionReplyToInvite_UserCallBack(this.factionReplyToInviteCallback));
				RemoteServices.Instance.FactionReplyToInvite(this.m_factionData.factionID, false);
			}

			// Token: 0x060010B0 RID: 4272 RVA: 0x0011E780 File Offset: 0x0011C980
			public void acceptClicked()
			{
				this.declineButton.Enabled = false;
				this.acceptButton.Enabled = false;
				RemoteServices.Instance.set_FactionReplyToInvite_UserCallBack(new RemoteServices.FactionReplyToInvite_UserCallBack(this.factionReplyToInviteCallback));
				RemoteServices.Instance.FactionReplyToInvite(this.m_factionData.factionID, true);
			}

			// Token: 0x060010B1 RID: 4273 RVA: 0x0011E7D4 File Offset: 0x0011C9D4
			public void factionReplyToInviteCallback(FactionReplyToInvite_ReturnType returnData)
			{
				if (returnData.m_errorCode == ErrorCodes.ErrorCode.FACTION_FULL)
				{
					MyMessageBox.Show(SK.Text("FactionsPanel_Faction_Full", "The Faction is full."), SK.Text("GENERIC_Error", "Error"));
				}
				if (returnData.Success)
				{
					GameEngine.Instance.World.FactionMembers = returnData.members;
					GameEngine.Instance.World.YourFaction = returnData.yourFaction;
					GameEngine.Instance.World.FactionInvites = returnData.invites;
					GameEngine.Instance.World.FactionApplications = returnData.applications;
					if (returnData.yourFaction != null)
					{
						GameEngine.Instance.World.updateYourVillageFactions(returnData.yourFaction.factionID);
						if (returnData.decline)
						{
							this.m_parent.init(false);
							return;
						}
						GameEngine.Instance.World.FactionAllies = returnData.yourAllies;
						GameEngine.Instance.World.FactionEnemies = returnData.yourEnemies;
						GameEngine.Instance.World.HouseAllies = returnData.yourHouseAllies;
						GameEngine.Instance.World.HouseEnemies = returnData.yourHouseEnemies;
					}
					else
					{
						GameEngine.Instance.World.updateYourVillageFactions(-1);
					}
					GameEngine.Instance.World.LastUpdatedCrowns = DateTime.MinValue;
					InterfaceMgr.Instance.getFactionTabBar().forceChangeTab(1);
					return;
				}
				this.declineButton.Enabled = true;
				this.acceptButton.Enabled = true;
			}

			// Token: 0x060010B2 RID: 4274 RVA: 0x00012442 File Offset: 0x00010642
			public void appCancelClicked()
			{
				this.declineButton.Enabled = false;
				RemoteServices.Instance.set_FactionApplication_UserCallBack(new RemoteServices.FactionApplication_UserCallBack(this.factionApplicationCallback));
				RemoteServices.Instance.FactionApplicationCancel(this.m_factionData.factionID);
			}

			// Token: 0x060010B3 RID: 4275 RVA: 0x0011E94C File Offset: 0x0011CB4C
			public void factionApplicationCallback(FactionApplication_ReturnType returnData)
			{
				if (returnData.Success)
				{
					GameEngine.Instance.World.FactionInvites = returnData.invites;
					GameEngine.Instance.World.FactionApplications = returnData.applications;
					this.m_parent.init(false);
					return;
				}
				this.declineButton.Enabled = true;
			}

			// Token: 0x040016C9 RID: 5833
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040016CA RID: 5834
			private CustomSelfDrawPanel.CSDLabel playerName = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040016CB RID: 5835
			private CustomSelfDrawPanel.CSDButton acceptButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040016CC RID: 5836
			private CustomSelfDrawPanel.CSDButton declineButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040016CD RID: 5837
			private CustomSelfDrawPanel.CSDFactionFlagImage flagImage = new CustomSelfDrawPanel.CSDFactionFlagImage();

			// Token: 0x040016CE RID: 5838
			private int m_position = -1000;

			// Token: 0x040016CF RID: 5839
			private FactionData m_factionData;

			// Token: 0x040016D0 RID: 5840
			private FactionInvitePanel m_parent;
		}
	}
}
