using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020004B1 RID: 1201
	public class UserInfoPanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06002C07 RID: 11271 RVA: 0x00020523 File Offset: 0x0001E723
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06002C08 RID: 11272 RVA: 0x00020533 File Offset: 0x0001E733
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06002C09 RID: 11273 RVA: 0x00020543 File Offset: 0x0001E743
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06002C0A RID: 11274 RVA: 0x00020555 File Offset: 0x0001E755
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06002C0B RID: 11275 RVA: 0x00020562 File Offset: 0x0001E762
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			this.closing();
		}

		// Token: 0x06002C0C RID: 11276 RVA: 0x00020576 File Offset: 0x0001E776
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06002C0D RID: 11277 RVA: 0x00020583 File Offset: 0x0001E783
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06002C0E RID: 11278 RVA: 0x00020590 File Offset: 0x0001E790
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002C0F RID: 11279 RVA: 0x0022D47C File Offset: 0x0022B67C
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Name = "UserInfoPanel2";
			base.Size = new Size(200, 378);
			base.ResumeLayout(false);
		}

		// Token: 0x06002C10 RID: 11280 RVA: 0x0022D4C8 File Offset: 0x0022B6C8
		public UserInfoPanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SelfDrawBackground = true;
		}

		// Token: 0x06002C11 RID: 11281 RVA: 0x0022D590 File Offset: 0x0022B790
		public void init()
		{
			this.lastShieldUserID = -1;
			base.clearControls();
			this.avatarBackImage.Image = GFXLibrary.mrhp_avatar_frame_background;
			this.avatarBackImage.Position = new Point(0, 110);
			base.addControl(this.avatarBackImage);
			this.avatarImage.Image = null;
			this.avatarImage.Visible = false;
			this.avatarImage.Position = new Point(71, 113);
			this.background.Image = GFXLibrary.mrhp_avatar_frame;
			this.background.Position = new Point(0, 0);
			base.addControl(this.avatarImage);
			base.addControl(this.background);
			this.flagImage.createFromFlagData(0);
			this.flagImage.Position = new Point(136, 48);
			this.flagImage.Scale = 0.25;
			this.flagImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.factionClicked), "UserInfoPanel2_faction_flag");
			this.flagImage.Visible = false;
			this.flagImage.CustomTooltipID = 2501;
			this.background.addControl(this.flagImage);
			this.houseImage.Image = null;
			this.houseImage.Position = new Point(15, 38);
			this.houseImage.Visible = false;
			this.houseImage.CustomTooltipID = 2307;
			this.houseImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.houseClicked), "UserInfoPanel2_house");
			this.background.addControl(this.houseImage);
			this.shieldImage.Image = null;
			this.shieldImage.Position = new Point(74, 31);
			this.shieldImage.Visible = false;
			this.background.addControl(this.shieldImage);
			this.nameLabel.Text = "";
			this.nameLabel.Color = global::ARGBColors.Black;
			this.nameLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.nameLabel.Position = new Point(8, 79);
			this.nameLabel.Size = new Size(this.background.Width - 12, 45);
			this.nameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.nameLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.nameClicked), "UserInfoPanel2_name");
			this.background.addControl(this.nameLabel);
			this.rankLabel.Text = "";
			this.rankLabel.Color = global::ARGBColors.Black;
			this.rankLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.rankLabel.Position = new Point(8, 317);
			this.rankLabel.Size = new Size(this.background.Width - 12, 20);
			this.rankLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.background.addControl(this.rankLabel);
			this.pointsLabel.Text = "";
			this.pointsLabel.Color = global::ARGBColors.Black;
			this.pointsLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
			this.pointsLabel.Position = new Point(8, 330);
			this.pointsLabel.Size = new Size(this.background.Width - 12, 20);
			this.pointsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.background.addControl(this.pointsLabel);
			this.moreInfo.ImageNorm = GFXLibrary.mrhp_button_more_info_solid[0];
			this.moreInfo.ImageOver = GFXLibrary.mrhp_button_more_info_solid[1];
			this.moreInfo.Position = new Point((200 - this.moreInfo.ImageNorm.Width) / 2 + 6, 353);
			this.moreInfo.MoveOnClick = true;
			this.moreInfo.Text.Text = SK.Text("UserInfo_MoreInfo", "More Info");
			if (Program.mySettings.LanguageIdent == "it" || Program.mySettings.LanguageIdent == "tr" || Program.mySettings.LanguageIdent == "pt")
			{
				this.moreInfo.Text.Font = FontManager.GetFont("Arial", 7.5f, FontStyle.Bold);
			}
			else
			{
				this.moreInfo.Text.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
			}
			this.moreInfo.TextYOffset = -3;
			this.moreInfo.Text.Position = new Point(-3, 0);
			this.moreInfo.Text.Color = global::ARGBColors.Black;
			this.moreInfo.Text.DropShadowColor = Color.FromArgb(60, 90, 100);
			this.moreInfo.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.nameClicked), "UserInfoPanel2_more_info");
			this.background.addControl(this.moreInfo);
			this.mailToButton.ImageNorm = GFXLibrary.mrhp_button_envelope[0];
			this.mailToButton.ImageOver = GFXLibrary.mrhp_button_envelope[1];
			this.mailToButton.ImageClick = GFXLibrary.mrhp_button_envelope[2];
			this.mailToButton.Position = new Point(157, 259);
			this.mailToButton.CustomTooltipID = 2502;
			this.mailToButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.mailToClick), "UserInfoPanel2_mail_to");
			this.background.addControl(this.mailToButton);
			this.lastFlagData = -1;
		}

		// Token: 0x06002C12 RID: 11282 RVA: 0x0022DB64 File Offset: 0x0022BD64
		public void updateVillageInfo(WorldMap.VillageRolloverInfo villageInfo, WorldMap.CachedUserInfo userInfo)
		{
			CustomTooltipManager.UserInfo = userInfo;
			this.m_userInfo = userInfo;
			this.pointsLabel.CustomTooltipID = 0;
			this.rankLabel.CustomTooltipID = 0;
			if (userInfo != null)
			{
				this.pointsLabel.CustomTooltipID = 2503;
				this.rankLabel.CustomTooltipID = 2503;
				NumberFormatInfo nfi = GameEngine.NFI;
				this.nameLabel.TextDiffOnly = userInfo.userName;
				if (userInfo.avatarData != null)
				{
					this.rankLabel.TextDiffOnly = Rankings.getRankingName(userInfo.rank, userInfo.avatarData.male);
				}
				else
				{
					this.rankLabel.TextDiffOnly = Rankings.getRankingName(userInfo.rank);
				}
				if (userInfo.userID != this.lastShieldUserID)
				{
					this.lastShieldUserID = userInfo.userID;
					this.shieldImage.Image = GameEngine.Instance.World.getWorldShieldOrBlank(userInfo.userID, 47, 54);
					if (this.shieldImage.Image != null)
					{
						GameEngine.Instance.World.showShieldUser(this.lastShieldUserID);
						this.shieldImage.Visible = true;
					}
					else
					{
						this.shieldImage.Visible = false;
					}
				}
				if (userInfo.factionID >= 0)
				{
					FactionData faction = GameEngine.Instance.World.getFaction(userInfo.factionID);
					if (faction != null)
					{
						if (this.lastFlagData != faction.flagData)
						{
							this.flagImage.createFromFlagData(faction.flagData);
						}
						this.flagImage.CustomTooltipData = faction.factionID;
						this.flagImage.Visible = true;
						if (faction.houseID > 0)
						{
							Image image = this.houseImage.Image = (this.houseImage.Image = GFXLibrary.house_circles_medium[faction.houseID - 1]);
							this.houseImage.CustomTooltipData = faction.houseID;
							this.houseImage.Visible = true;
						}
						else
						{
							this.houseImage.Visible = false;
						}
					}
					else
					{
						this.flagImage.Visible = false;
						this.houseImage.Visible = false;
					}
				}
				else
				{
					this.flagImage.Visible = false;
					this.houseImage.Visible = false;
				}
				this.avatarImage.Image = userInfo.avatarBitmap;
				this.avatarImage.Visible = true;
				int num = userInfo.numVillages;
				if (GameEngine.Instance.LocalWorldData.AIWorld)
				{
					switch (userInfo.userID)
					{
					case 1:
						num = GameEngine.Instance.World.countRatsCastles();
						break;
					case 2:
						num = GameEngine.Instance.World.countSnakesCastles();
						break;
					case 3:
						num = GameEngine.Instance.World.countPigsCastles();
						break;
					case 4:
						num = GameEngine.Instance.World.countWolfsCastles();
						break;
					}
				}
				this.pointsLabel.TextDiffOnly = SK.Text("GENERIC_Villages", "Villages") + " : " + num.ToString("N", nfi);
				this.lastUserID = userInfo.userID;
				return;
			}
			this.avatarImage.Visible = false;
			this.rankLabel.TextDiffOnly = "";
			this.nameLabel.TextDiffOnly = "";
			this.pointsLabel.TextDiffOnly = "";
		}

		// Token: 0x06002C13 RID: 11283 RVA: 0x000205AF File Offset: 0x0001E7AF
		private void closing()
		{
			GameEngine.Instance.World.showShieldUser(-1);
		}

		// Token: 0x06002C14 RID: 11284 RVA: 0x0022DEA8 File Offset: 0x0022C0A8
		private void mailToClick()
		{
			if (this.m_userInfo != null && this.m_userInfo.userID >= 0)
			{
				int userID = this.m_userInfo.userID;
				string userName = this.m_userInfo.userName;
				InterfaceMgr.Instance.getMainTabBar().selectDummyTab(21);
				InterfaceMgr.Instance.mailTo(userID, userName);
			}
		}

		// Token: 0x06002C15 RID: 11285 RVA: 0x000205C1 File Offset: 0x0001E7C1
		private void nameClicked()
		{
			if (this.m_userInfo != null)
			{
				InterfaceMgr.Instance.showUserInfoScreen(this.m_userInfo);
			}
		}

		// Token: 0x06002C16 RID: 11286 RVA: 0x000205DB File Offset: 0x0001E7DB
		private void factionClicked()
		{
			if (this.m_userInfo != null && this.m_userInfo.factionID >= 0)
			{
				InterfaceMgr.Instance.showFactionPanel(this.m_userInfo.factionID);
			}
		}

		// Token: 0x06002C17 RID: 11287 RVA: 0x0022DF00 File Offset: 0x0022C100
		private void houseClicked()
		{
			if (this.m_userInfo != null && this.m_userInfo.factionID >= 0)
			{
				FactionData faction = GameEngine.Instance.World.getFaction(this.m_userInfo.factionID);
				if (faction != null)
				{
					InterfaceMgr.Instance.showHousePanel(faction.houseID);
				}
			}
		}

		// Token: 0x040036CB RID: 14027
		private DockableControl dockableControl;

		// Token: 0x040036CC RID: 14028
		private IContainer components;

		// Token: 0x040036CD RID: 14029
		private CustomSelfDrawPanel.CSDImage background = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040036CE RID: 14030
		private CustomSelfDrawPanel.CSDImage avatarImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040036CF RID: 14031
		private CustomSelfDrawPanel.CSDImage avatarBackImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040036D0 RID: 14032
		private CustomSelfDrawPanel.CSDLabel nameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040036D1 RID: 14033
		private CustomSelfDrawPanel.CSDLabel rankLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040036D2 RID: 14034
		private CustomSelfDrawPanel.CSDLabel pointsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040036D3 RID: 14035
		private CustomSelfDrawPanel.CSDImage houseImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040036D4 RID: 14036
		private CustomSelfDrawPanel.CSDImage shieldImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040036D5 RID: 14037
		private CustomSelfDrawPanel.CSDButton moreInfo = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040036D6 RID: 14038
		private CustomSelfDrawPanel.CSDButton mailToButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040036D7 RID: 14039
		private CustomSelfDrawPanel.CSDFactionFlagImage flagImage = new CustomSelfDrawPanel.CSDFactionFlagImage();

		// Token: 0x040036D8 RID: 14040
		private int lastShieldUserID = -1;

		// Token: 0x040036D9 RID: 14041
		private int lastFlagData = -1;

		// Token: 0x040036DA RID: 14042
		private int lastUserID = -1;

		// Token: 0x040036DB RID: 14043
		private WorldMap.CachedUserInfo m_userInfo;

		// Token: 0x040036DC RID: 14044
		public Bitmap avatarBitmap;
	}
}
