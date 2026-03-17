using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020001A5 RID: 421
	public class EndofTheWorldPanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x0600101B RID: 4123 RVA: 0x001193D4 File Offset: 0x001175D4
		public EndofTheWorldPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x0600101C RID: 4124 RVA: 0x001194F8 File Offset: 0x001176F8
		public void init(bool resized)
		{
			GameEngine.Instance.setNextFactionPage(-1);
			int height = base.Height;
			EndofTheWorldPanel.instance = this;
			base.clearControls();
			this.avatarAdded = false;
			this.buttonLanguageValue = 0;
			string languageIdent = Program.mySettings.LanguageIdent;
			if (languageIdent != null)
			{
				uint num = PrivateImplementationDetails.ComputeStringHash(languageIdent);
				if (num <= 1194886160U)
				{
					if (num <= 1162757945U)
					{
						if (num != 1092248970U)
						{
							if (num == 1162757945U)
							{
								if (languageIdent == "pl")
								{
									this.buttonLanguageValue = 6;
								}
							}
						}
						else if (languageIdent == "en")
						{
							this.buttonLanguageValue = 0;
						}
					}
					else if (num != 1176137065U)
					{
						if (num == 1194886160U)
						{
							if (languageIdent == "it")
							{
								this.buttonLanguageValue = 8;
							}
						}
					}
					else if (languageIdent == "es")
					{
						this.buttonLanguageValue = 2;
					}
				}
				else if (num <= 1213488160U)
				{
					if (num != 1195724803U)
					{
						if (num == 1213488160U)
						{
							if (languageIdent == "ru")
							{
								this.buttonLanguageValue = 1;
							}
						}
					}
					else if (languageIdent == "tr")
					{
						this.buttonLanguageValue = 4;
					}
				}
				else if (num != 1461901041U)
				{
					if (num != 1545391778U)
					{
						if (num == 1565420801U)
						{
							if (languageIdent == "pt")
							{
								this.buttonLanguageValue = 5;
							}
						}
					}
					else if (languageIdent == "de")
					{
						this.buttonLanguageValue = 3;
					}
				}
				else if (languageIdent == "fr")
				{
					this.buttonLanguageValue = 7;
				}
			}
			this.buttonLanguageValue *= 3;
			this.mainBackgroundImage.FillColor = Color.FromArgb(134, 153, 165);
			this.mainBackgroundImage.Position = new Point(256, 0);
			this.mainBackgroundImage.Size = new Size(368, height);
			base.addControl(this.mainBackgroundImage);
			this.backgroundFade.Image = GFXLibrary.background_top;
			this.backgroundFade.Position = new Point(0, 0);
			this.backgroundFade.Size = new Size(this.mainBackgroundImage.Width, this.backgroundFade.Image.Height);
			this.mainBackgroundImage.addControl(this.backgroundFade);
			this.headerLabelsImage.Size = new Size(this.mainBackgroundImage.Width - 5 - 5, 28);
			this.headerLabelsImage.Position = new Point(5, 9);
			this.mainBackgroundImage.addControl(this.headerLabelsImage);
			this.headerLabelsImage.Create(GFXLibrary.mail2_field_bar_mail_left, GFXLibrary.mail2_field_bar_mail_middle, GFXLibrary.mail2_field_bar_mail_right);
			this.houseLabel.Text = SK.Text("STATS_CATEGORY_TITLE_HOUSE", "House");
			this.houseLabel.Color = global::ARGBColors.Black;
			this.houseLabel.Position = new Point(9, -2);
			this.houseLabel.Size = new Size(323, this.headerLabelsImage.Height);
			this.houseLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.houseLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.houseLabel);
			this.playersLabel.Text = SK.Text("EndOfWorld_TowersOwned", "Royal Towers Owned");
			this.playersLabel.Color = global::ARGBColors.Black;
			this.playersLabel.Position = new Point(0, -2);
			this.playersLabel.Size = new Size(this.headerLabelsImage.Width - 12, this.headerLabelsImage.Height);
			this.playersLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.playersLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.headerLabelsImage.addControl(this.playersLabel);
			this.leftImage.Image = GFXLibrary.eow_left;
			this.leftImage.Position = new Point(0, 0);
			base.addControl(this.leftImage);
			this.gloryButton.Position = new Point(77, 23);
			this.gloryButton.ImageNorm = GFXLibrary.eow_toggle[0];
			this.gloryButton.ImageOver = GFXLibrary.eow_toggle[1];
			this.gloryButton.ImageClick = GFXLibrary.eow_toggle[2];
			this.gloryButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.gloryClick), "Glory_view_result");
			this.leftImage.addControl(this.gloryButton);
			this.rightImage.Image = GFXLibrary.eow_right;
			this.rightImage.Position = new Point(624, 0);
			base.addControl(this.rightImage);
			this.EndTheWorldButton.Position = new Point(73, 216);
			this.EndTheWorldButton.ImageNorm = GFXLibrary.eow_buttons[1 + this.buttonLanguageValue];
			this.EndTheWorldButton.ImageOver = GFXLibrary.eow_buttons[1 + this.buttonLanguageValue];
			this.EndTheWorldButton.ImageClick = GFXLibrary.eow_buttons[1 + this.buttonLanguageValue];
			this.EndTheWorldButton.CustomTooltipID = 1750;
			this.EndTheWorldButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.endWorldClick), "Glory_view_result");
			this.rightImage.addControl(this.EndTheWorldButton);
			if (!GameEngine.Instance.World.WorldEnded)
			{
				this.EndTheWorldButton.Visible = true;
			}
			else
			{
				this.EndTheWorldButton.Visible = false;
			}
			this.buttonActive = false;
			InterfaceMgr.Instance.setVillageHeading(SK.Text("EndOfWorld_EndOfWorld", "The End of the World"));
			this.wallScrollArea.Position = new Point(5, 38);
			this.wallScrollArea.Size = new Size(this.mainBackgroundImage.Width - 27, height - 38);
			this.wallScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(this.mainBackgroundImage.Width - 27, height - 38));
			this.mainBackgroundImage.addControl(this.wallScrollArea);
			this.mouseWheelOverlay.Position = this.wallScrollArea.Position;
			this.mouseWheelOverlay.Size = this.wallScrollArea.Size;
			this.mouseWheelOverlay.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mouseWheelMoved));
			this.mainBackgroundImage.addControl(this.mouseWheelOverlay);
			int value = this.wallScrollBar.Value;
			this.wallScrollBar.Visible = false;
			this.wallScrollBar.Position = new Point(this.mainBackgroundImage.Width - 27, 38);
			this.wallScrollBar.Size = new Size(24, height - 38);
			this.mainBackgroundImage.addControl(this.wallScrollBar);
			this.wallScrollBar.Value = 0;
			this.wallScrollBar.Max = 100;
			this.wallScrollBar.NumVisibleLines = 25;
			this.wallScrollBar.Create(null, null, null, GFXLibrary._24wide_thumb_top, GFXLibrary._24wide_thumb_middle, GFXLibrary._24wide_thumb_bottom);
			this.wallScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.wallScrollBarMoved));
			this.addFactions();
			if (GameEngine.Instance.World.WorldEnded)
			{
				this.downloadEOWData();
			}
		}

		// Token: 0x0600101D RID: 4125 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x0600101E RID: 4126 RVA: 0x00011CFA File Offset: 0x0000FEFA
		private void downloadEOWData()
		{
			if (WorldsEndPanel.cachedData == null)
			{
				RemoteServices.Instance.set_EndOfTheWorldStats_UserCallBack(new RemoteServices.EndOfTheWorldStats_UserCallBack(this.endOfTheWorldCallback));
				RemoteServices.Instance.EndOfTheWorldStats();
				return;
			}
			this.displayEOWData();
		}

		// Token: 0x0600101F RID: 4127 RVA: 0x00011D2A File Offset: 0x0000FF2A
		private void endOfTheWorldCallback(EndOfTheWorldStats_ReturnType returnData)
		{
			if (returnData.Success)
			{
				WorldsEndPanel.cachedData = returnData;
				this.displayEOWData();
			}
		}

		// Token: 0x06001020 RID: 4128 RVA: 0x00119CB8 File Offset: 0x00117EB8
		private void displayEOWData()
		{
			GameEngine.Instance.World.WorldEnded = true;
			this.EndTheWorldButton.Visible = false;
			if (!this.avatarAdded)
			{
				this.avatarAdded = true;
				if (EndofTheWorldPanel.lastCreatedAvatar != null)
				{
					EndofTheWorldPanel.lastCreatedAvatar.Dispose();
				}
				EndofTheWorldPanel.lastCreatedAvatar = (this.avatarImage.Image = Avatar.CreateAvatar(WorldsEndPanel.cachedData.globalData.m_avatarData, 350, global::ARGBColors.Transparent, true));
				this.avatarImage.Position = new Point(46, 45);
				this.rightImage.addControl(this.avatarImage);
				this.shieldImage.Image = GameEngine.Instance.World.getWorldShieldOrBlank(WorldsEndPanel.cachedData.globalData.winningUser, 140, 156);
				if (this.shieldImage.Image != null)
				{
					this.shieldImage.Position = new Point(177, 59);
					this.rightImage.addControl(this.shieldImage);
				}
				this.houseImage.Image = GFXLibrary.house_circles_large[WorldsEndPanel.cachedData.globalData.winningHouse - 1];
				this.houseImage.Position = new Point(180, 273);
				this.rightImage.addControl(this.houseImage);
				this.paperImage.Image = GFXLibrary.eow_right_paper;
				this.paperImage.Position = new Point(37, 406);
				this.rightImage.addControl(this.paperImage);
				this.eowInfo1Label.Text = SK.Text("eow_House_Marshall", "House Marshall");
				this.eowInfo1Label.Color = global::ARGBColors.Black;
				this.eowInfo1Label.Position = new Point(50, 415);
				this.eowInfo1Label.Size = new Size(275, 40);
				this.eowInfo1Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				this.eowInfo1Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.rightImage.addControl(this.eowInfo1Label);
				this.eowInfo1aLabel.Text = WorldsEndPanel.cachedData.globalData.winnerUsername;
				this.eowInfo1aLabel.Color = global::ARGBColors.Black;
				this.eowInfo1aLabel.Position = new Point(50, 436);
				this.eowInfo1aLabel.Size = new Size(275, 40);
				this.eowInfo1aLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Bold);
				this.eowInfo1aLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.rightImage.addControl(this.eowInfo1aLabel);
				int num = (int)(WorldsEndPanel.cachedData.globalData.endTime - GameEngine.Instance.World.m_worldStartDate).TotalDays;
				this.eowInfo2Label.Text = SK.Text("eow_ended_the_world", "Ended the World on");
				this.eowInfo2Label.Color = global::ARGBColors.Black;
				this.eowInfo2Label.Position = new Point(50, 470);
				this.eowInfo2Label.Size = new Size(275, 40);
				this.eowInfo2Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				this.eowInfo2Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.rightImage.addControl(this.eowInfo2Label);
				this.eowInfo3Label.Text = string.Concat(new string[]
				{
					SK.Text("MENU_Day_X", "Day"),
					" ",
					num.ToString(),
					"    ",
					WorldsEndPanel.cachedData.globalData.endTime.ToShortDateString(),
					" : ",
					WorldsEndPanel.cachedData.globalData.endTime.ToShortTimeString()
				});
				this.eowInfo3Label.Color = global::ARGBColors.Black;
				this.eowInfo3Label.Position = new Point(50, 495);
				this.eowInfo3Label.Size = new Size(275, 60);
				this.eowInfo3Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				this.eowInfo3Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.rightImage.addControl(this.eowInfo3Label);
			}
		}

		// Token: 0x06001021 RID: 4129 RVA: 0x0011A120 File Offset: 0x00118320
		private void wallScrollBarMoved()
		{
			int value = this.wallScrollBar.Value;
			this.wallScrollArea.Position = new Point(this.wallScrollArea.X, 38 - value);
			this.wallScrollArea.ClipRect = new Rectangle(this.wallScrollArea.ClipRect.X, value, this.wallScrollArea.ClipRect.Width, this.wallScrollArea.ClipRect.Height);
			this.wallScrollArea.invalidate();
			this.wallScrollBar.invalidate();
		}

		// Token: 0x06001022 RID: 4130 RVA: 0x00011D40 File Offset: 0x0000FF40
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

		// Token: 0x06001023 RID: 4131 RVA: 0x0000ADE9 File Offset: 0x00008FE9
		public void closing()
		{
			InterfaceMgr.Instance.closeDonatePopup();
		}

		// Token: 0x06001024 RID: 4132 RVA: 0x00011D72 File Offset: 0x0000FF72
		public void gloryClick()
		{
			InterfaceMgr.Instance.setVillageTabSubMode(22, false);
		}

		// Token: 0x06001025 RID: 4133 RVA: 0x0011A1B8 File Offset: 0x001183B8
		public void endWorldClick()
		{
			if (this.buttonActive)
			{
				DialogResult dialogResult = MyMessageBox.Show(SK.Text("FORUMS_Are_You_Sure", "Are you sure?"), SK.Text("EOW_End_World", "End World"), MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					this.doEndWorldClick();
				}
			}
		}

		// Token: 0x06001026 RID: 4134 RVA: 0x00011D81 File Offset: 0x0000FF81
		public void doEndWorldClick()
		{
			if (this.buttonActive)
			{
				this.buttonActive = false;
				RemoteServices.Instance.set_EndWorld_UserCallBack(new RemoteServices.EndWorld_UserCallBack(this.endWorldCallback));
				RemoteServices.Instance.EndWorld();
			}
		}

		// Token: 0x06001027 RID: 4135 RVA: 0x00011DB2 File Offset: 0x0000FFB2
		public void endWorldCallback(EndWorld_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.EndTheWorldButton.Visible = false;
				this.downloadEOWData();
				return;
			}
			this.buttonActive = true;
		}

		// Token: 0x06001028 RID: 4136 RVA: 0x0011A1FC File Offset: 0x001183FC
		public void addFactions()
		{
			FactionData yourFaction = GameEngine.Instance.World.YourFaction;
			int num = 0;
			if (yourFaction != null)
			{
				num = yourFaction.houseID;
			}
			this.wallScrollArea.clearControls();
			int num2 = 0;
			this.lineList.Clear();
			int num3 = -1;
			List<EndofTheWorldPanel.TowerSortClass> list = new List<EndofTheWorldPanel.TowerSortClass>();
			int[] royalTowerCounts = GameEngine.Instance.World.getRoyalTowerCounts();
			int num4 = 0;
			HouseData[] houseInfo = GameEngine.Instance.World.HouseInfo;
			for (int i = 0; i < 21; i++)
			{
				if (royalTowerCounts[i] > 0)
				{
					list.Add(new EndofTheWorldPanel.TowerSortClass
					{
						houseID = i,
						count = royalTowerCounts[i]
					});
					num3 = i;
				}
			}
			foreach (EndofTheWorldPanel.TowerSortClass towerSortClass in list)
			{
				EndofTheWorldPanel.RoyalTowerLine royalTowerLine = new EndofTheWorldPanel.RoyalTowerLine();
				if (num2 != 0)
				{
					num2 += 5;
				}
				royalTowerLine.Position = new Point(0, num2);
				HouseData houseData = houseInfo[towerSortClass.houseID];
				royalTowerLine.init(houseData, num, towerSortClass.count, num4, this);
				this.wallScrollArea.addControl(royalTowerLine);
				num2 += royalTowerLine.Height;
				this.lineList.Add(royalTowerLine);
				num4++;
			}
			this.wallScrollArea.Size = new Size(this.wallScrollArea.Width, num2);
			if (num2 < this.wallScrollBar.Height)
			{
				this.wallScrollBar.Visible = false;
			}
			else
			{
				this.wallScrollBar.Visible = true;
				this.wallScrollBar.NumVisibleLines = this.wallScrollBar.Height;
				this.wallScrollBar.Max = num2 - this.wallScrollBar.Height;
			}
			this.wallScrollArea.invalidate();
			this.wallScrollBar.invalidate();
			if (!GameEngine.Instance.World.WorldEnded)
			{
				this.buttonActive = false;
				if (list.Count == 1 && num3 > 0 && num3 == num)
				{
					HouseData houseData2 = houseInfo[num];
					if (houseData2 != null && houseData2.leaderUserID == RemoteServices.Instance.UserID)
					{
						this.EndTheWorldButton.ImageNorm = GFXLibrary.eow_buttons[this.buttonLanguageValue];
						this.EndTheWorldButton.ImageOver = GFXLibrary.eow_buttons[this.buttonLanguageValue];
						this.EndTheWorldButton.ImageClick = GFXLibrary.eow_buttons[2 + this.buttonLanguageValue];
						this.EndTheWorldButton.CustomTooltipID = 1751;
						this.EndTheWorldButton.CustomTooltipData = num;
						this.buttonActive = true;
					}
				}
			}
			this.update();
			base.Invalidate();
		}

		// Token: 0x06001029 RID: 4137 RVA: 0x00011DD6 File Offset: 0x0000FFD6
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x0600102A RID: 4138 RVA: 0x00011DE6 File Offset: 0x0000FFE6
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x0600102B RID: 4139 RVA: 0x00011DF6 File Offset: 0x0000FFF6
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x0600102C RID: 4140 RVA: 0x00011E08 File Offset: 0x00010008
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x0600102D RID: 4141 RVA: 0x00011E15 File Offset: 0x00010015
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closing();
		}

		// Token: 0x0600102E RID: 4142 RVA: 0x00011E2F File Offset: 0x0001002F
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x0600102F RID: 4143 RVA: 0x00011E3C File Offset: 0x0001003C
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06001030 RID: 4144 RVA: 0x00011E49 File Offset: 0x00010049
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001031 RID: 4145 RVA: 0x0011A4B4 File Offset: 0x001186B4
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.MaximumSize = new Size(992, 566);
			this.MinimumSize = new Size(992, 566);
			base.Name = "EndofTheWorldPanel";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x0400163A RID: 5690
		public const int PANEL_ID = 65;

		// Token: 0x0400163B RID: 5691
		public static EndofTheWorldPanel instance;

		// Token: 0x0400163C RID: 5692
		private CustomSelfDrawPanel.CSDFill mainBackgroundImage = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x0400163D RID: 5693
		private CustomSelfDrawPanel.CSDImage backgroundFade = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400163E RID: 5694
		private CustomSelfDrawPanel.CSDLabel titleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400163F RID: 5695
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04001640 RID: 5696
		private CustomSelfDrawPanel.CSDLabel houseLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001641 RID: 5697
		private CustomSelfDrawPanel.CSDLabel playersLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001642 RID: 5698
		private CustomSelfDrawPanel.CSDVertScrollBar wallScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04001643 RID: 5699
		private CustomSelfDrawPanel.CSDArea wallScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04001644 RID: 5700
		private CustomSelfDrawPanel.CSDControl mouseWheelOverlay = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x04001645 RID: 5701
		private CustomSelfDrawPanel.CSDImage leftImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001646 RID: 5702
		private CustomSelfDrawPanel.CSDButton gloryButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001647 RID: 5703
		private CustomSelfDrawPanel.CSDImage rightImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001648 RID: 5704
		private CustomSelfDrawPanel.CSDButton EndTheWorldButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001649 RID: 5705
		private static Image lastCreatedAvatar;

		// Token: 0x0400164A RID: 5706
		private CustomSelfDrawPanel.CSDImage shieldImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400164B RID: 5707
		private CustomSelfDrawPanel.CSDImage houseImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400164C RID: 5708
		private CustomSelfDrawPanel.CSDImage paperImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400164D RID: 5709
		private CustomSelfDrawPanel.CSDLabel eowInfo1Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400164E RID: 5710
		private CustomSelfDrawPanel.CSDLabel eowInfo1aLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400164F RID: 5711
		private CustomSelfDrawPanel.CSDLabel eowInfo2Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001650 RID: 5712
		private CustomSelfDrawPanel.CSDLabel eowInfo3Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001651 RID: 5713
		private CustomSelfDrawPanel.CSDImage avatarImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001652 RID: 5714
		private bool avatarAdded;

		// Token: 0x04001653 RID: 5715
		private bool buttonActive;

		// Token: 0x04001654 RID: 5716
		private int buttonLanguageValue;

		// Token: 0x04001655 RID: 5717
		private List<EndofTheWorldPanel.RoyalTowerLine> lineList = new List<EndofTheWorldPanel.RoyalTowerLine>();

		// Token: 0x04001656 RID: 5718
		private DockableControl dockableControl;

		// Token: 0x04001657 RID: 5719
		private IContainer components;

		// Token: 0x020001A6 RID: 422
		private class TowerSortClass
		{
			// Token: 0x04001658 RID: 5720
			public int houseID;

			// Token: 0x04001659 RID: 5721
			public int count;
		}

		// Token: 0x020001A7 RID: 423
		public class RoyalTowerLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06001033 RID: 4147 RVA: 0x0011A520 File Offset: 0x00118720
			public void init(HouseData houseData, int yourHouseID, int royalTowers, int position, EndofTheWorldPanel parent)
			{
				this.m_parent = parent;
				this.m_position = position;
				this.m_houseData = houseData;
				this.clearControls();
				if ((position & 1) == 0)
				{
					this.backgroundImage.Image = GFXLibrary.lineitem_strip_02_light;
				}
				else
				{
					this.backgroundImage.Image = GFXLibrary.lineitem_strip_02_dark;
				}
				this.backgroundImage.Position = new Point(0, 0);
				this.backgroundImage.Size = new Size(this.backgroundImage.Size.Width, 51);
				base.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
				base.addControl(this.backgroundImage);
				this.Size = this.backgroundImage.Size;
				if (houseData.houseID > 0)
				{
					this.houseImage.Image = GFXLibrary.house_circles_medium[houseData.houseID - 1];
					this.houseImage.Position = new Point(5, 0);
					this.houseImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
					this.houseImage.CustomTooltipID = 2308;
					this.houseImage.CustomTooltipData = houseData.houseID;
					this.backgroundImage.addControl(this.houseImage);
				}
				NumberFormatInfo nfi = GameEngine.NFI;
				Color color = global::ARGBColors.Black;
				if (houseData.houseID == yourHouseID)
				{
					color = global::ARGBColors.Yellow;
				}
				this.houseName.Text = SK.Text("STATS_CATEGORY_TITLE_HOUSE", "House") + " " + houseData.houseID.ToString();
				this.houseName.Color = color;
				this.houseName.Position = new Point(64, 5);
				this.houseName.Size = new Size(280, this.backgroundImage.Height);
				this.houseName.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.houseName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.houseName.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
				this.backgroundImage.addControl(this.houseName);
				if (houseData.houseID > 0)
				{
					this.houseMotto.Text = "\"" + CustomTooltipManager.getHouseMotto(houseData.houseID) + "\"";
					this.houseMotto.Color = color;
					this.houseMotto.Position = new Point(64, 30);
					this.houseMotto.Size = new Size(280, this.backgroundImage.Height);
					this.houseMotto.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
					this.houseMotto.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
					this.houseMotto.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
					this.backgroundImage.addControl(this.houseMotto);
				}
				else
				{
					this.houseName.Text = SK.Text("eow_UnclaimedTowers", "Unclaimed Towers");
					this.houseName.Position = new Point(64, 18);
				}
				this.numPlayersLabel.Text = royalTowers.ToString();
				this.numPlayersLabel.Color = global::ARGBColors.Black;
				this.numPlayersLabel.Position = new Point(222, 0);
				this.numPlayersLabel.Size = new Size(100, this.backgroundImage.Height);
				this.numPlayersLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.numPlayersLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.numPlayersLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickedLine));
				this.backgroundImage.addControl(this.numPlayersLabel);
				base.invalidate();
			}

			// Token: 0x06001034 RID: 4148 RVA: 0x00007CE0 File Offset: 0x00005EE0
			public void update()
			{
			}

			// Token: 0x06001035 RID: 4149 RVA: 0x00011E68 File Offset: 0x00010068
			public void clickedLine()
			{
				GameEngine.Instance.playInterfaceSound("HouseListPanel_faction");
				if (this.m_houseData.houseID > 0)
				{
					InterfaceMgr.Instance.showHousePanel(this.m_houseData.houseID);
				}
			}

			// Token: 0x0400165A RID: 5722
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x0400165B RID: 5723
			private CustomSelfDrawPanel.CSDImage houseImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x0400165C RID: 5724
			private CustomSelfDrawPanel.CSDLabel houseName = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400165D RID: 5725
			private CustomSelfDrawPanel.CSDLabel houseMotto = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400165E RID: 5726
			private CustomSelfDrawPanel.CSDLabel numPlayersLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400165F RID: 5727
			private int m_position = -1000;

			// Token: 0x04001660 RID: 5728
			private HouseData m_houseData;

			// Token: 0x04001661 RID: 5729
			private EndofTheWorldPanel m_parent;
		}
	}
}
