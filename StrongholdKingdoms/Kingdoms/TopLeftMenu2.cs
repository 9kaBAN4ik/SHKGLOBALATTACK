using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x0200049C RID: 1180
	public class TopLeftMenu2 : CustomSelfDrawPanel
	{
		// Token: 0x06002B1B RID: 11035 RVA: 0x0001FAE0 File Offset: 0x0001DCE0
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002B1C RID: 11036 RVA: 0x00221284 File Offset: 0x0021F484
		private void InitializeComponent()
		{
			new ComponentResourceManager(typeof(TopLeftMenu2));
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			base.Name = "TopLeftMenu2";
			base.Size = new Size(527, 120);
			base.ResumeLayout(false);
		}

		// Token: 0x06002B1D RID: 11037 RVA: 0x002212D4 File Offset: 0x0021F4D4
		public TopLeftMenu2()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06002B1E RID: 11038 RVA: 0x002213EC File Offset: 0x0021F5EC
		public void init()
		{
			base.clearControls();
			this.mainBackgroundImage.Image = GFXLibrary.interface_bar_top_left_empty;
			this.mainBackgroundImage.Position = new Point(0, 0);
			base.addControl(this.mainBackgroundImage);
			this.panelConnectorImage.Image = GFXLibrary.menubar_connecter_left;
			this.panelConnectorImage.Position = new Point(353, 0);
			base.addControl(this.panelConnectorImage);
			this.controlsArea.Position = new Point(0, 0);
			this.controlsArea.Size = base.Size;
			base.addControl(this.controlsArea);
			Image playerShieldImage = GameEngine.Instance.World.getPlayerShieldImage(69, 77);
			if (playerShieldImage != null)
			{
				this.shieldImage.Image = playerShieldImage;
				this.shieldImage.Position = new Point(2, 2);
				this.shieldImage.CustomTooltipID = 4015;
				this.shieldImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.imgRealShield_Click));
				this.controlsArea.addControl(this.shieldImage);
			}
			this.SetFaithPoints(0.0);
			this.secondAgeImage.Image = GFXLibrary.secondAgeLogo;
			this.secondAgeImage.Visible = false;
			this.secondAgeImage.CustomTooltipID = 8;
			this.secondAgeImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.secondAgeImage_Click));
			this.controlsArea.addControl(this.secondAgeImage);
			this.userNameLabel.Position = new Point(103, 0);
			this.userNameLabel.Size = new Size(224, 18);
			this.userNameLabel.Font = FontManager.GetFont("Microsoft Sans Serif", 12f);
			this.userNameLabel.Color = global::ARGBColors.Black;
			this.userNameLabel.CustomTooltipID = 2;
			this.controlsArea.addControl(this.userNameLabel);
			this.currentGoldLabel.Position = new Point(130, 64);
			this.currentGoldLabel.Size = new Size(80, 18);
			this.currentGoldLabel.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.currentGoldLabel.Color = global::ARGBColors.White;
			this.currentGoldLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.currentGoldLabel.CustomTooltipID = 5;
			this.controlsArea.addControl(this.currentGoldLabel);
			this.currentGoldToolTip.Position = new Point(90, 64);
			this.currentGoldToolTip.Size = new Size(40, 18);
			this.currentGoldToolTip.CustomTooltipID = 5;
			this.controlsArea.addControl(this.currentGoldToolTip);
			this.currentHonourLabel.Position = new Point(130, 40);
			this.currentHonourLabel.Size = new Size(80, 18);
			this.currentHonourLabel.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.currentHonourLabel.Color = global::ARGBColors.White;
			this.currentHonourLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.currentHonourLabel.CustomTooltipID = 4;
			this.controlsArea.addControl(this.currentHonourLabel);
			this.currentHonourToolTip.Position = new Point(90, 40);
			this.currentHonourToolTip.Size = new Size(40, 18);
			this.currentHonourToolTip.CustomTooltipID = 4;
			this.controlsArea.addControl(this.currentHonourToolTip);
			this.rankLabel.Position = new Point(104, 16);
			this.rankLabel.Size = new Size(224, 23);
			this.rankLabel.Font = FontManager.GetFont("Microsoft Sans Serif", 9f);
			this.rankLabel.Color = global::ARGBColors.Black;
			this.rankLabel.CustomTooltipID = 3;
			this.controlsArea.addControl(this.rankLabel);
			this.pointsLabel.Position = new Point(263, 40);
			this.pointsLabel.Size = new Size(80, 18);
			this.pointsLabel.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.pointsLabel.Color = global::ARGBColors.White;
			this.pointsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.pointsLabel.CustomTooltipID = 7;
			this.controlsArea.addControl(this.pointsLabel);
			this.pointsToolTip.Position = new Point(223, 40);
			this.pointsToolTip.Size = new Size(40, 18);
			this.pointsToolTip.CustomTooltipID = 7;
			this.controlsArea.addControl(this.pointsToolTip);
			this.faithPointsLabel.Position = new Point(263, 64);
			this.faithPointsLabel.Color = global::ARGBColors.White;
			this.faithPointsLabel.Size = new Size(57, 18);
			this.faithPointsLabel.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.faithPointsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.faithPointsLabel.CustomTooltipID = 6;
			this.controlsArea.addControl(this.faithPointsLabel);
			this.faithpointsToolTip.Position = new Point(223, 64);
			this.faithpointsToolTip.Size = new Size(40, 18);
			this.faithpointsToolTip.CustomTooltipID = 6;
			this.controlsArea.addControl(this.faithpointsToolTip);
			this.cardsButton.Position = new Point(354, 0);
			this.cardsButton.CustomTooltipID = 1;
			this.cardsButton.ClickArea = new Rectangle(37, 0, 136, 81);
			this.cardsButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.cardsClick));
			this.controlsArea.addControl(this.cardsButton);
			this.cardsButtonOverlay.Position = new Point(354, 0);
			this.cardsButtonOverlay.Alpha = 0f;
			this.cardsButtonOverlay.Visible = false;
			this.controlsArea.addControl(this.cardsButtonOverlay);
			this.gameDateLabel.Text = "";
			this.gameDateLabel.Position = new Point(6 + this.cardsButton.Position.X, 4 + this.cardsButton.Position.Y);
			this.gameDateLabel.Size = new Size(162, 18);
			this.gameDateLabel.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.gameDateLabel.Color = global::ARGBColors.Black;
			if (GameEngine.Instance.LocalWorldData != null && GameEngine.Instance.LocalWorldData.Alternate_Ruleset == 1)
			{
				this.gameDateLabel.CustomTooltipID = 11;
			}
			else
			{
				this.gameDateLabel.CustomTooltipID = 0;
			}
			this.gameDateLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.controlsArea.addControl(this.gameDateLabel);
			this.resize();
			this.contextTabBar.Position = new Point(0, 88);
			this.contextTabBar.Size = new Size(530, 32);
			this.contextTabBar.Visible = true;
			this.controlsArea.addControl(this.contextTabBar);
			this.villageInfoBar.init();
			this.villageInfoBar.Position = new Point(0, 0);
			this.villageInfoBar.Size = new Size(530, 32);
			this.villageInfoBar.Visible = false;
			this.contextTabBar.addControl(this.villageInfoBar);
			this.castleInfoBar.init();
			this.castleInfoBar.Position = new Point(0, 0);
			this.castleInfoBar.Size = new Size(530, 32);
			this.castleInfoBar.Visible = false;
			this.contextTabBar.addControl(this.castleInfoBar);
			InterfaceMgr.Instance.setVillageInfoBar(this.villageInfoBar, this.castleInfoBar);
		}

		// Token: 0x06002B1F RID: 11039 RVA: 0x00221BEC File Offset: 0x0021FDEC
		public void update()
		{
			this.alphaPulse += 10;
			if (this.alphaPulse > 511)
			{
				this.alphaPulse -= 511;
			}
			if (GameEngine.Instance.cardsManager.ShowPremiumOfferAlert())
			{
				int num = this.alphaPulse;
				if (num > 255)
				{
					num = 511 - num;
				}
				this.cardsButtonOverlay.Visible = true;
				this.cardsButtonOverlay.Alpha = (float)num / 255f;
				this.cardsButtonOverlay.invalidate();
			}
		}

		// Token: 0x06002B20 RID: 11040 RVA: 0x0001FAFF File Offset: 0x0001DCFF
		private void cardsClick()
		{
			GameEngine.Instance.playInterfaceSound("WorldMap_cards_opened_from_screen_top");
			InterfaceMgr.Instance.openPlayCardsWindow(0);
		}

		// Token: 0x06002B21 RID: 11041 RVA: 0x0001FB1C File Offset: 0x0001DD1C
		public void setUserName(string userName)
		{
			this.userNameLabel.Text = userName;
		}

		// Token: 0x06002B22 RID: 11042 RVA: 0x00221C7C File Offset: 0x0021FE7C
		public void setRank(int rank)
		{
			this.rankLabel.Text = Rankings.getRankingName(rank, RemoteServices.Instance.UserAvatar.male) + " (" + (rank + 1).ToString() + ")";
		}

		// Token: 0x06002B23 RID: 11043 RVA: 0x0001FB2A File Offset: 0x0001DD2A
		public void setServerTime(string serverTime)
		{
			this.gameDateLabel.Text = serverTime;
		}

		// Token: 0x06002B24 RID: 11044 RVA: 0x0001FB38 File Offset: 0x0001DD38
		public string getServerTime()
		{
			return this.gameDateLabel.Text;
		}

		// Token: 0x06002B25 RID: 11045 RVA: 0x00221CC4 File Offset: 0x0021FEC4
		public void setGold(double newGold)
		{
			if (newGold > 9.223372036854776E+18)
			{
				newGold = 9.223372036854776E+18;
			}
			NumberFormatInfo nfi = GameEngine.NFI;
			this.currentGoldLabel.Text = ((long)newGold).ToString("N", nfi);
		}

		// Token: 0x06002B26 RID: 11046 RVA: 0x00221D0C File Offset: 0x0021FF0C
		public void setHonour(double newHonour, int rank)
		{
			if (newHonour > 9.223372036854776E+18)
			{
				newHonour = 9.223372036854776E+18;
			}
			NumberFormatInfo nfi = GameEngine.NFI;
			this.currentHonourLabel.Text = ((long)newHonour).ToString("N", nfi);
		}

		// Token: 0x06002B27 RID: 11047 RVA: 0x00221D54 File Offset: 0x0021FF54
		public void SetFaithPoints(double points)
		{
			try
			{
				if (points > 2147483647.0)
				{
					points = 2147483647.0;
				}
				NumberFormatInfo nfi = GameEngine.NFI;
				int num = (int)points;
				if (num == 0 && (GameEngine.Instance.World.UserResearchData == null || GameEngine.Instance.World.UserResearchData.Research_Theology == 0))
				{
					this.faithPointsLabel.Text = "";
					this.mainBackgroundImage.Image = GFXLibrary.interface_bar_top_left_empty;
					this.faithPointsLabel.Visible = false;
				}
				else
				{
					this.faithPointsLabel.Text = num.ToString("N", nfi);
					this.mainBackgroundImage.Image = GFXLibrary.menubar_left_faith;
					this.faithPointsLabel.Visible = true;
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06002B28 RID: 11048 RVA: 0x00221E2C File Offset: 0x0022002C
		public void setPoints(int points)
		{
			NumberFormatInfo nfi = GameEngine.NFI;
			this.pointsLabel.Text = points.ToString("N", nfi);
		}

		// Token: 0x06002B29 RID: 11049 RVA: 0x00221E58 File Offset: 0x00220058
		public void setCards(CardData cardData)
		{
			bool flag = false;
			if (cardData.premiumCard != 0)
			{
				flag = true;
			}
			if (flag)
			{
				this.cardsButton.ImageNorm = GFXLibrary.menubar_middle_gold;
				this.cardsButton.ImageOver = GFXLibrary.menubar_middle_gold_over;
				this.cardsButton.ImageClick = GFXLibrary.menubar_middle_gold_over;
				this.cardsButtonOverlay.Image = GFXLibrary.menubar_middle_gold_offer;
				return;
			}
			this.cardsButton.ImageNorm = GFXLibrary.menubar_middle;
			this.cardsButton.ImageOver = GFXLibrary.menubar_middle_over;
			this.cardsButton.ImageClick = GFXLibrary.menubar_middle_over;
			this.cardsButtonOverlay.Image = GFXLibrary.menubar_middle_offer;
		}

		// Token: 0x06002B2A RID: 11050 RVA: 0x00221F20 File Offset: 0x00220120
		public int getCardAreaXPos()
		{
			return this.cardsButton.Position.X;
		}

		// Token: 0x06002B2B RID: 11051 RVA: 0x00221F40 File Offset: 0x00220140
		private void imgRealShield_Click()
		{
			GameEngine.Instance.playInterfaceSound("TopLeftMenu_ShieldClicked");
			string fileName = string.Concat(new string[]
			{
				URLs.shieldDesignerURL,
				"?webtoken=",
				RemoteServices.Instance.WebToken,
				"&lang=",
				Program.mySettings.LanguageIdent.ToLower()
			});
			Process.Start(fileName);
		}

		// Token: 0x06002B2C RID: 11052 RVA: 0x00221FA8 File Offset: 0x002201A8
		public void resize()
		{
			this.cardsButton.Position = new Point(base.Width - this.cardsButton.Width, 0);
			this.cardsButtonOverlay.Position = new Point(base.Width - this.cardsButton.Width, 0);
			this.gameDateLabel.Position = new Point(6 + this.cardsButton.Position.X, 4 + this.cardsButton.Position.Y);
			int num = base.Width - this.mainBackgroundImage.Image.Width - 172;
			if (num < 1)
			{
				num = 1;
			}
			this.panelConnectorImage.Size = new Size(num, this.panelConnectorImage.Image.Size.Height);
			this.updateSecondAgeImage();
			this.controlsArea.Size = base.Size;
			this.cardsButton.invalidate();
			this.cardsButtonOverlay.invalidate();
			this.gameDateLabel.invalidate();
		}

		// Token: 0x06002B2D RID: 11053 RVA: 0x002220BC File Offset: 0x002202BC
		private void updateSecondAgeImage()
		{
			if (GameEngine.Instance.World.SecondAgeWorld || (GameEngine.Instance.LocalWorldData != null && GameEngine.Instance.LocalWorldData.Alternate_Ruleset == 1))
			{
				if (GameEngine.Instance.LocalWorldData != null && GameEngine.Instance.LocalWorldData.Alternate_Ruleset == 1)
				{
					this.secondAgeImage.Image = GFXLibrary.dominationWorldLogo;
					this.secondAgeImage.CustomTooltipID = 10;
				}
				else if (GameEngine.Instance.World.SeventhAgeWorld || GameEngine.Instance.World.WorldEnded)
				{
					this.secondAgeImage.Image = GFXLibrary.seventhAgeLogo;
					this.secondAgeImage.CustomTooltipID = 15;
				}
				else if (GameEngine.Instance.World.SixthAgeWorld)
				{
					this.secondAgeImage.Image = GFXLibrary.sixthAgeLogo;
					this.secondAgeImage.CustomTooltipID = 14;
				}
				else if (GameEngine.Instance.World.FifthAgeWorld)
				{
					this.secondAgeImage.Image = GFXLibrary.fifthAgeLogo;
					this.secondAgeImage.CustomTooltipID = 13;
				}
				else if (GameEngine.Instance.World.FourthAgeWorld)
				{
					this.secondAgeImage.Image = GFXLibrary.fourthAgeLogo;
					this.secondAgeImage.CustomTooltipID = 12;
				}
				else if (GameEngine.Instance.World.ThirdAgeWorld)
				{
					this.secondAgeImage.Image = GFXLibrary.thirdAgeLogo;
					this.secondAgeImage.CustomTooltipID = 9;
				}
				else if (GameEngine.Instance.World.SecondAgeWorld)
				{
					this.secondAgeImage.Image = GFXLibrary.secondAgeLogo;
					this.secondAgeImage.CustomTooltipID = 8;
				}
				int cardAreaXPos = this.getCardAreaXPos();
				if (cardAreaXPos > 491)
				{
					this.secondAgeImage.Size = new Size(137, 72);
					this.secondAgeImage.Position = new Point((cardAreaXPos - 354 - 137) / 2 + 1 + 353, 9);
					this.secondAgeImage.Visible = true;
				}
				else
				{
					this.secondAgeImage.Visible = false;
				}
			}
			else
			{
				this.secondAgeImage.Visible = false;
			}
			this.secondAgeImage.invalidate();
			this.panelConnectorImage.invalidate();
		}

		// Token: 0x06002B2E RID: 11054 RVA: 0x00222328 File Offset: 0x00220528
		private void secondAgeImage_Click()
		{
			if (GameEngine.Instance.LocalWorldData != null && GameEngine.Instance.LocalWorldData.Alternate_Ruleset == 1)
			{
				GameEngine.Instance.openLostVillage(10);
				return;
			}
			if (GameEngine.Instance.World.WorldEnded)
			{
				GameEngine.Instance.openWorldsEnd();
				return;
			}
			if (GameEngine.Instance.World.SeventhAgeWorld)
			{
				GameEngine.Instance.openLostVillage(7);
				return;
			}
			if (GameEngine.Instance.World.SixthAgeWorld)
			{
				GameEngine.Instance.openLostVillage(6);
				return;
			}
			if (GameEngine.Instance.World.FifthAgeWorld)
			{
				GameEngine.Instance.openLostVillage(5);
				return;
			}
			if (GameEngine.Instance.World.FourthAgeWorld)
			{
				GameEngine.Instance.openLostVillage(4);
				return;
			}
			if (GameEngine.Instance.World.ThirdAgeWorld)
			{
				GameEngine.Instance.openLostVillage(3);
				return;
			}
			GameEngine.Instance.openLostVillage(2);
		}

		// Token: 0x06002B2F RID: 11055 RVA: 0x0001FB45 File Offset: 0x0001DD45
		public VillageInfoBar2 getVillageInfoBar()
		{
			return this.villageInfoBar;
		}

		// Token: 0x06002B30 RID: 11056 RVA: 0x0001FB4D File Offset: 0x0001DD4D
		public void setContextBarVisible(bool state)
		{
			this.contextTabBar.Visible = state;
		}

		// Token: 0x06002B31 RID: 11057 RVA: 0x0001FB5B File Offset: 0x0001DD5B
		public bool contextBarVisible()
		{
			return this.contextTabBar.Visible;
		}

		// Token: 0x040035D5 RID: 13781
		private IContainer components;

		// Token: 0x040035D6 RID: 13782
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040035D7 RID: 13783
		private CustomSelfDrawPanel.CSDImage panelConnectorImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040035D8 RID: 13784
		private CustomSelfDrawPanel.CSDArea controlsArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040035D9 RID: 13785
		private CustomSelfDrawPanel.CSDImage shieldImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040035DA RID: 13786
		private CustomSelfDrawPanel.CSDImage secondAgeImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040035DB RID: 13787
		private CustomSelfDrawPanel.CSDLabel userNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040035DC RID: 13788
		private CustomSelfDrawPanel.CSDLabel currentGoldLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040035DD RID: 13789
		private CustomSelfDrawPanel.CSDLabel currentHonourLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040035DE RID: 13790
		private CustomSelfDrawPanel.CSDLabel rankLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040035DF RID: 13791
		private CustomSelfDrawPanel.CSDLabel pointsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040035E0 RID: 13792
		private CustomSelfDrawPanel.CSDLabel faithPointsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040035E1 RID: 13793
		private CustomSelfDrawPanel.CSDLabel gameDateLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040035E2 RID: 13794
		private CustomSelfDrawPanel.CSDButton cardsButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040035E3 RID: 13795
		private CustomSelfDrawPanel.CSDImage cardsButtonOverlay = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040035E4 RID: 13796
		private CustomSelfDrawPanel.CSDArea currentGoldToolTip = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040035E5 RID: 13797
		private CustomSelfDrawPanel.CSDArea currentHonourToolTip = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040035E6 RID: 13798
		private CustomSelfDrawPanel.CSDArea pointsToolTip = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040035E7 RID: 13799
		private CustomSelfDrawPanel.CSDArea faithpointsToolTip = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040035E8 RID: 13800
		private VillageInfoBar2 villageInfoBar = new VillageInfoBar2();

		// Token: 0x040035E9 RID: 13801
		private CastleInfoBar2 castleInfoBar = new CastleInfoBar2();

		// Token: 0x040035EA RID: 13802
		private CustomSelfDrawPanel.CSDArea contextTabBar = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040035EB RID: 13803
		private int alphaPulse = 255;
	}
}
