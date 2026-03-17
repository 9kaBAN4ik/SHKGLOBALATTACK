using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020004AF RID: 1199
	public class UserDiplomacyPanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06002BEA RID: 11242 RVA: 0x000203E1 File Offset: 0x0001E5E1
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06002BEB RID: 11243 RVA: 0x000203F1 File Offset: 0x0001E5F1
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06002BEC RID: 11244 RVA: 0x00020401 File Offset: 0x0001E601
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06002BED RID: 11245 RVA: 0x00020413 File Offset: 0x0001E613
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06002BEE RID: 11246 RVA: 0x00020420 File Offset: 0x0001E620
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closing();
		}

		// Token: 0x06002BEF RID: 11247 RVA: 0x0002043A File Offset: 0x0001E63A
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06002BF0 RID: 11248 RVA: 0x00020447 File Offset: 0x0001E647
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06002BF1 RID: 11249 RVA: 0x00020454 File Offset: 0x0001E654
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002BF2 RID: 11250 RVA: 0x0022C0B8 File Offset: 0x0022A2B8
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.MaximumSize = new Size(992, 10000);
			this.MinimumSize = new Size(992, 566);
			base.Name = "UserDiplomacyPanel";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x06002BF3 RID: 11251 RVA: 0x0022C124 File Offset: 0x0022A324
		public UserDiplomacyPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06002BF4 RID: 11252 RVA: 0x0022C1E4 File Offset: 0x0022A3E4
		public void init(bool resized)
		{
			int height = base.Height;
			this.blockYSize = height / 2;
			UserDiplomacyPanel.instance = this;
			base.clearControls();
			this.loadDiplomacyData();
			this.mainBackgroundImage.FillColor = Color.FromArgb(134, 153, 165);
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = new Size(base.Width, height);
			base.addControl(this.mainBackgroundImage);
			this.backgroundFade.Image = GFXLibrary.background_top;
			this.backgroundFade.Position = new Point(0, 0);
			this.backgroundFade.Size = new Size(base.Width, this.backgroundFade.Image.Height);
			this.mainBackgroundImage.addControl(this.backgroundFade);
			this.headerLabelsImage.Size = new Size(base.Width - 25 - 23, 28);
			this.headerLabelsImage.Position = new Point(25, 5);
			this.mainBackgroundImage.addControl(this.headerLabelsImage);
			this.headerLabelsImage.Create(GFXLibrary.mail2_field_bar_mail_left, GFXLibrary.mail2_field_bar_mail_middle, GFXLibrary.mail2_field_bar_mail_right);
			this.headerLabelsImage2.Size = new Size(base.Width - 25 - 23, 28);
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
			this.alliesScrollArea.Size = new Size(915, this.blockYSize - 40 - 10);
			this.alliesScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(915, this.blockYSize - 40 - 10));
			this.mainBackgroundImage.addControl(this.alliesScrollArea);
			this.mouseWheelOverlay1.Position = this.alliesScrollArea.Position;
			this.mouseWheelOverlay1.Size = this.alliesScrollArea.Size;
			this.mouseWheelOverlay1.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mouseWheelMoved1));
			this.mainBackgroundImage.addControl(this.mouseWheelOverlay1);
			int value = this.alliesScrollBar.Value;
			this.alliesScrollBar.Position = new Point(933, 40);
			this.alliesScrollBar.Size = new Size(24, this.blockYSize - 40 - 10);
			this.mainBackgroundImage.addControl(this.alliesScrollBar);
			this.alliesScrollBar.Value = 0;
			this.alliesScrollBar.Max = 100;
			this.alliesScrollBar.NumVisibleLines = 25;
			this.alliesScrollBar.Create(null, null, null, GFXLibrary._24wide_thumb_top, GFXLibrary._24wide_thumb_middle, GFXLibrary._24wide_thumb_bottom);
			this.alliesScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.wallScrollBarMoved));
			this.enemiesScrollArea.Position = new Point(25, 35 + this.blockYSize + 5);
			this.enemiesScrollArea.Size = new Size(915, this.blockYSize - 40 - 10);
			this.enemiesScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(915, this.blockYSize - 40 - 10));
			this.mainBackgroundImage.addControl(this.enemiesScrollArea);
			this.mouseWheelOverlay2.Position = this.enemiesScrollArea.Position;
			this.mouseWheelOverlay2.Size = this.enemiesScrollArea.Size;
			this.mouseWheelOverlay2.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mouseWheelMoved2));
			this.mainBackgroundImage.addControl(this.mouseWheelOverlay2);
			int value2 = this.enemiesScrollBar.Value;
			this.enemiesScrollBar.Position = new Point(933, 35 + this.blockYSize + 5);
			this.enemiesScrollBar.Size = new Size(24, this.blockYSize - 40 - 10);
			this.mainBackgroundImage.addControl(this.enemiesScrollBar);
			this.enemiesScrollBar.Value = 0;
			this.enemiesScrollBar.Max = 100;
			this.enemiesScrollBar.NumVisibleLines = 25;
			this.enemiesScrollBar.Create(null, null, null, GFXLibrary._24wide_thumb_top, GFXLibrary._24wide_thumb_middle, GFXLibrary._24wide_thumb_bottom);
			this.enemiesScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.incomingWallScrollBarMoved));
			this.addPlayers();
		}

		// Token: 0x06002BF5 RID: 11253 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x06002BF6 RID: 11254 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void logout()
		{
		}

		// Token: 0x06002BF7 RID: 11255 RVA: 0x0022C804 File Offset: 0x0022AA04
		private void wallScrollBarMoved()
		{
			int value = this.alliesScrollBar.Value;
			this.alliesScrollArea.Position = new Point(this.alliesScrollArea.X, 40 - value);
			this.alliesScrollArea.ClipRect = new Rectangle(this.alliesScrollArea.ClipRect.X, value, this.alliesScrollArea.ClipRect.Width, this.alliesScrollArea.ClipRect.Height);
			this.alliesScrollArea.invalidate();
			this.alliesScrollBar.invalidate();
		}

		// Token: 0x06002BF8 RID: 11256 RVA: 0x00020473 File Offset: 0x0001E673
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

		// Token: 0x06002BF9 RID: 11257 RVA: 0x0022C89C File Offset: 0x0022AA9C
		private void incomingWallScrollBarMoved()
		{
			int value = this.enemiesScrollBar.Value;
			this.enemiesScrollArea.Position = new Point(this.enemiesScrollArea.X, 35 + this.blockYSize + 5 - value);
			this.enemiesScrollArea.ClipRect = new Rectangle(this.enemiesScrollArea.ClipRect.X, value, this.enemiesScrollArea.ClipRect.Width, this.enemiesScrollArea.ClipRect.Height);
			this.enemiesScrollArea.invalidate();
			this.enemiesScrollBar.invalidate();
		}

		// Token: 0x06002BFA RID: 11258 RVA: 0x000204A5 File Offset: 0x0001E6A5
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

		// Token: 0x06002BFB RID: 11259 RVA: 0x0000ADE9 File Offset: 0x00008FE9
		public void closing()
		{
			InterfaceMgr.Instance.closeDonatePopup();
		}

		// Token: 0x06002BFC RID: 11260 RVA: 0x0022C940 File Offset: 0x0022AB40
		public void addPlayers()
		{
			this.alliesScrollArea.clearControls();
			this.enemiesScrollArea.clearControls();
			int num = 0;
			int num2 = 2;
			List<UserRelationship> userRelations = GameEngine.Instance.World.UserRelations;
			int num3 = 0;
			int num4 = 0;
			foreach (UserRelationship userRelationship in userRelations)
			{
				if (userRelationship.friendly)
				{
					UserDiplomacyPanel.UserAllianceLine userAllianceLine = new UserDiplomacyPanel.UserAllianceLine();
					if (num != 0)
					{
						num += 5;
					}
					userAllianceLine.Position = new Point(0, num);
					userAllianceLine.init(userRelationship.userName, userRelationship.userID, num3, true, this);
					this.alliesScrollArea.addControl(userAllianceLine);
					num += userAllianceLine.Height;
					num3++;
				}
				else
				{
					UserDiplomacyPanel.UserAllianceLine userAllianceLine2 = new UserDiplomacyPanel.UserAllianceLine();
					if (num2 != 0)
					{
						num2 += 5;
					}
					userAllianceLine2.Position = new Point(0, num2);
					userAllianceLine2.init(userRelationship.userName, userRelationship.userID, num4, false, this);
					this.enemiesScrollArea.addControl(userAllianceLine2);
					num2 += userAllianceLine2.Height;
					num4++;
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
			this.enemiesScrollArea.Size = new Size(this.enemiesScrollArea.Width, num2);
			if (num2 < this.enemiesScrollBar.Height)
			{
				this.enemiesScrollBar.Visible = false;
			}
			else
			{
				this.enemiesScrollBar.Visible = true;
				this.enemiesScrollBar.NumVisibleLines = this.enemiesScrollBar.Height;
				this.enemiesScrollBar.Max = num2 - this.enemiesScrollBar.Height;
			}
			this.enemiesScrollArea.invalidate();
			this.enemiesScrollBar.invalidate();
			this.update();
			base.Invalidate();
		}

		// Token: 0x06002BFD RID: 11261 RVA: 0x0022CB88 File Offset: 0x0022AD88
		private void loadDiplomacyData()
		{
			string settingsPath = GameEngine.getSettingsPath(false);
			try
			{
				FileStream fileStream = new FileStream(string.Concat(new string[]
				{
					settingsPath,
					"\\DiplomacyDataW",
					GameEngine.Instance.World.GetGlobalWorldID().ToString(),
					"U",
					RemoteServices.Instance.UserID.ToString(),
					".dat"
				}), FileMode.Open);
				BinaryReader binaryReader = new BinaryReader(fileStream);
				byte[] b = new byte[16];
				b = binaryReader.ReadBytes(16);
				Guid value = new Guid(b);
				if (RemoteServices.Instance.WorldGUID.CompareTo(value) != 0)
				{
					binaryReader.Close();
					fileStream.Close();
				}
				else
				{
					UserDiplomacyPanel.customNotes.Clear();
					for (int i = 0; i < GameEngine.Instance.World.UserRelations.Count; i++)
					{
						UserDiplomacyPanel.customNotes.Add(binaryReader.ReadString());
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x040036AE RID: 13998
		public const int PANEL_ID = 60;

		// Token: 0x040036AF RID: 13999
		private DockableControl dockableControl;

		// Token: 0x040036B0 RID: 14000
		private IContainer components;

		// Token: 0x040036B1 RID: 14001
		public static UserDiplomacyPanel instance = null;

		// Token: 0x040036B2 RID: 14002
		private CustomSelfDrawPanel.CSDFill mainBackgroundImage = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x040036B3 RID: 14003
		private CustomSelfDrawPanel.CSDImage backgroundFade = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040036B4 RID: 14004
		private CustomSelfDrawPanel.CSDLabel titleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040036B5 RID: 14005
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x040036B6 RID: 14006
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage2 = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x040036B7 RID: 14007
		private CustomSelfDrawPanel.CSDVertScrollBar alliesScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x040036B8 RID: 14008
		private CustomSelfDrawPanel.CSDArea alliesScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040036B9 RID: 14009
		private CustomSelfDrawPanel.CSDControl mouseWheelOverlay1 = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x040036BA RID: 14010
		private CustomSelfDrawPanel.CSDVertScrollBar enemiesScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x040036BB RID: 14011
		private CustomSelfDrawPanel.CSDArea enemiesScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040036BC RID: 14012
		private CustomSelfDrawPanel.CSDControl mouseWheelOverlay2 = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x040036BD RID: 14013
		private CustomSelfDrawPanel.CSDLabel alliesLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040036BE RID: 14014
		private CustomSelfDrawPanel.CSDLabel enemiesLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040036BF RID: 14015
		private static List<string> customNotes = new List<string>();

		// Token: 0x040036C0 RID: 14016
		private int blockYSize;

		// Token: 0x020004B0 RID: 1200
		public class UserAllianceLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06002BFF RID: 11263 RVA: 0x0022CC98 File Offset: 0x0022AE98
			public void init(string username, int userID, int position, bool ally, UserDiplomacyPanel parent)
			{
				this.m_parent = parent;
				this.m_position = position;
				this.m_userID = userID;
				this.clearControls();
				if ((position & 1) == 0)
				{
					this.backgroundImage.Image = GFXLibrary.lineitem_strip_02_light;
				}
				else
				{
					this.backgroundImage.Image = GFXLibrary.lineitem_strip_02_dark;
				}
				this.backgroundImage.Position = new Point(40, 0);
				this.backgroundImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.userClick));
				base.addControl(this.backgroundImage);
				this.Size = this.backgroundImage.Size;
				this.shieldImage.Image = GameEngine.Instance.World.getWorldShield(userID, 25, 28);
				if (this.shieldImage.Image != null)
				{
					this.shieldImage.Position = new Point(0, 0);
					this.shieldImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.userClick));
					base.addControl(this.shieldImage);
				}
				this.factionName.Text = username;
				this.factionName.Color = global::ARGBColors.Black;
				this.factionName.Position = new Point(9, 0);
				this.factionName.Size = new Size(500, this.backgroundImage.Height);
				this.factionName.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.factionName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.factionName.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.userClick));
				this.backgroundImage.addControl(this.factionName);
				this.trash.ImageNorm = GFXLibrary.trashcan_normal;
				this.trash.ImageOver = GFXLibrary.trashcan_over;
				this.trash.ImageClick = GFXLibrary.trashcan_clicked;
				this.trash.Position = new Point(830, 4);
				this.trash.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.deleteClicked), "FactionNewForumPanel_delete_thread");
				this.trash.CustomTooltipID = 3102;
				this.backgroundImage.addControl(this.trash);
				this.playerNotesButton.ImageNormAndOver = GFXLibrary.faction_pen;
				this.playerNotesButton.Position = new Point(800, 4);
				this.playerNotesButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.setNote), "Set_Player_Notes");
				this.playerNotesButton.CustomTooltipID = 3103;
				this.backgroundImage.addControl(this.playerNotesButton);
				this.playerNotes.Text = "";
				this.playerNotes.Color = global::ARGBColors.Black;
				this.playerNotes.Position = new Point(this.factionName.Position.X + 240, 4);
				this.playerNotes.Size = new Size(500, this.backgroundImage.Height);
				this.playerNotes.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.playerNotes.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.backgroundImage.addControl(this.playerNotes);
				this.divider.Position = new Point(this.playerNotes.Position.X - 5, 5);
				this.divider.Height = this.backgroundImage.Height - 10;
				this.divider.Width = 0;
				this.divider.LineColor = global::ARGBColors.Black;
				this.backgroundImage.addControl(this.divider);
				foreach (string text in UserDiplomacyPanel.customNotes)
				{
					string[] array = text.Split(new char[]
					{
						'#'
					});
					if (array[0] == username && array[1] == GameEngine.Instance.World.GetGlobalWorldID().ToString())
					{
						this.playerNotes.Text = array[2];
						if (array.Length > 3)
						{
							for (int i = 3; i < array.Length; i++)
							{
								CustomSelfDrawPanel.CSDLabel csdlabel = this.playerNotes;
								csdlabel.Text = csdlabel.Text + "#" + array[i];
							}
						}
					}
				}
			}

			// Token: 0x06002C00 RID: 11264 RVA: 0x00007CE0 File Offset: 0x00005EE0
			public void update()
			{
			}

			// Token: 0x06002C01 RID: 11265 RVA: 0x0022D110 File Offset: 0x0022B310
			private void userClick()
			{
				GameEngine.Instance.playInterfaceSound("FactionDiplomacyPanel_faction_clicked");
				InterfaceMgr.Instance.changeTab(0);
				WorldMap.CachedUserInfo cachedUserInfo = new WorldMap.CachedUserInfo();
				cachedUserInfo.userID = this.m_userID;
				InterfaceMgr.Instance.showUserInfoScreen(cachedUserInfo);
			}

			// Token: 0x06002C02 RID: 11266 RVA: 0x000204E9 File Offset: 0x0001E6E9
			private void deleteClicked()
			{
				GameEngine.Instance.World.setUserRelationship(this.m_userID, 0, "");
				RemoteServices.Instance.CreateUserRelationship(this.m_userID, 0);
				this.m_parent.init(true);
			}

			// Token: 0x06002C03 RID: 11267 RVA: 0x0022D154 File Offset: 0x0022B354
			private void setNote()
			{
				InterfaceMgr.Instance.setFloatingTextSentDelegate(new InterfaceMgr.FloatingTextSent(this.setText));
				Point point = this.m_parent.PointToScreen(new Point(this.playerNotes.getPanelPosition().X, this.playerNotes.getPanelPosition().Y + 4));
				FloatingInputText.openDisband(point.X, point.Y, this.playerNotes.Text, InterfaceMgr.Instance.ParentForm);
			}

			// Token: 0x06002C04 RID: 11268 RVA: 0x0022D1D8 File Offset: 0x0022B3D8
			private void setText(string str)
			{
				this.playerNotes.Text = str;
				bool flag = false;
				string text = string.Concat(new string[]
				{
					this.factionName.Text,
					"#",
					GameEngine.Instance.World.GetGlobalWorldID().ToString(),
					"#",
					str
				});
				for (int i = 0; i < UserDiplomacyPanel.customNotes.Count; i++)
				{
					string[] array = UserDiplomacyPanel.customNotes[i].Split(new char[]
					{
						'#'
					});
					if (array[0] == this.factionName.Text)
					{
						UserDiplomacyPanel.customNotes[i] = text;
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					UserDiplomacyPanel.customNotes.Add(text);
				}
				this.saveDiplomacyData();
			}

			// Token: 0x06002C05 RID: 11269 RVA: 0x0022D2A8 File Offset: 0x0022B4A8
			private void saveDiplomacyData()
			{
				string settingsPath = GameEngine.getSettingsPath(true);
				try
				{
					FileInfo fileInfo = new FileInfo(string.Concat(new string[]
					{
						settingsPath,
						"\\DiplomacyDataW",
						GameEngine.Instance.World.GetGlobalWorldID().ToString(),
						"U",
						RemoteServices.Instance.UserID.ToString(),
						".dat"
					}));
					fileInfo.IsReadOnly = false;
				}
				catch (Exception)
				{
				}
				try
				{
					FileStream fileStream = new FileStream(string.Concat(new string[]
					{
						settingsPath,
						"\\DiplomacyDataW",
						GameEngine.Instance.World.GetGlobalWorldID().ToString(),
						"U",
						RemoteServices.Instance.UserID.ToString(),
						".dat"
					}), FileMode.Create);
					BinaryWriter binaryWriter = new BinaryWriter(fileStream);
					byte[] buffer = RemoteServices.Instance.WorldGUID.ToByteArray();
					binaryWriter.Write(buffer, 0, 16);
					for (int i = 0; i < UserDiplomacyPanel.customNotes.Count; i++)
					{
						binaryWriter.Write(UserDiplomacyPanel.customNotes[i]);
					}
					binaryWriter.Close();
					fileStream.Close();
				}
				catch (Exception)
				{
				}
			}

			// Token: 0x040036C1 RID: 14017
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040036C2 RID: 14018
			private CustomSelfDrawPanel.CSDLabel factionName = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040036C3 RID: 14019
			private int m_position = -1000;

			// Token: 0x040036C4 RID: 14020
			private int m_userID = -1;

			// Token: 0x040036C5 RID: 14021
			private CustomSelfDrawPanel.CSDImage shieldImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040036C6 RID: 14022
			private CustomSelfDrawPanel.CSDButton trash = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040036C7 RID: 14023
			private CustomSelfDrawPanel.CSDButton playerNotesButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040036C8 RID: 14024
			private CustomSelfDrawPanel.CSDLine divider = new CustomSelfDrawPanel.CSDLine();

			// Token: 0x040036C9 RID: 14025
			private CustomSelfDrawPanel.CSDLabel playerNotes = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040036CA RID: 14026
			private UserDiplomacyPanel m_parent;
		}
	}
}
