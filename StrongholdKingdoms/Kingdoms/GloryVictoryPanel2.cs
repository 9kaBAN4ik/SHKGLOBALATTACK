using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020001EB RID: 491
	public class GloryVictoryPanel2 : CustomSelfDrawPanel
	{
		// Token: 0x06001399 RID: 5017 RVA: 0x0014DD44 File Offset: 0x0014BF44
		public GloryVictoryPanel2()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x0600139A RID: 5018 RVA: 0x0014DE94 File Offset: 0x0014C094
		public void init(Form parent)
		{
			this.m_parent = parent;
			base.clearControls();
			this.mainBackgroundImage.Image = GFXLibrary.mail2_mail_panel_middle_middle;
			this.mainBackgroundImage.ClipRect = new Rectangle(default(Point), base.Size);
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = base.Size;
			base.addControl(this.mainBackgroundImage);
			this.overlayImage.Position = new Point(0, 0);
			this.overlayImage.Size = this.mainBackgroundImage.Size;
			this.overlayImage.Create(GFXLibrary._9sclice_generic_top_left, GFXLibrary._9sclice_generic_top_mid, GFXLibrary._9sclice_generic_top_right, GFXLibrary._9sclice_generic_mid_left, GFXLibrary._9sclice_generic_mid_mid, GFXLibrary._9sclice_generic_mid_right, GFXLibrary._9sclice_generic_bottom_left, GFXLibrary._9sclice_generic_bottom_mid, GFXLibrary._9sclice_generic_bottom_right);
			this.mainBackgroundImage.addControl(this.overlayImage);
			this.closeButton.ImageNorm = GFXLibrary.button_132_normal;
			this.closeButton.ImageOver = GFXLibrary.button_132_over;
			this.closeButton.ImageClick = GFXLibrary.button_132_in;
			this.closeButton.setSizeToImage();
			this.closeButton.Text.Text = SK.Text("GENERIC_Close", "Close");
			this.closeButton.Position = new Point(base.Width / 2 - this.closeButton.Width / 2, base.Height - this.closeButton.Height - 15);
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "GloryResultPanel_close");
			this.overlayImage.addControl(this.closeButton);
			int y = 65;
			this.headerLabel.Text = SK.Text("Glory_Glory_Victor", "Last Glory Round Result");
			this.headerLabel.Position = new Point(0, 20);
			this.headerLabel.Size = new Size(base.Width, 30);
			this.headerLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.headerLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.headerLabel.Color = global::ARGBColors.Black;
			this.overlayImage.addControl(this.headerLabel);
			GloryRoundData houseGloryRoundData = GameEngine.Instance.World.HouseGloryRoundData;
			int num = 0;
			if (houseGloryRoundData.winnerHouseID > 0)
			{
				num = houseGloryRoundData.winnerHouseID - 1;
			}
			this.leftFlag.Image = GFXLibrary.glory_flags_largest[num];
			this.leftFlag.setSizeToImage();
			this.leftFlag.Height = base.Height - 15;
			this.leftFlag.Width -= 35;
			this.leftFlag.Position = new Point(15, 15);
			this.overlayImage.addControl(this.leftFlag);
			this.rightFlag.Image = GFXLibrary.glory_flags_largest[num];
			this.rightFlag.setSizeToImage();
			this.rightFlag.Height = base.Height - 15;
			this.rightFlag.Width -= 35;
			this.rightFlag.Position = new Point(base.Width - this.rightFlag.Width - 5, 15);
			this.overlayImage.addControl(this.rightFlag);
			int num2 = (int)(houseGloryRoundData.victoryTime - GameEngine.Instance.World.m_worldStartDate).TotalDays;
			this.dayLabel.Text = SK.Text("MENU_Day_X", "Day") + " " + num2.ToString();
			this.dayLabel.Position = new Point(0, 38);
			this.dayLabel.Size = new Size(base.Width, 28);
			this.dayLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.dayLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.dayLabel.Color = global::ARGBColors.DarkGray;
			this.overlayImage.addControl(this.dayLabel);
			this.victoriousHouseLabel.Text = SK.Text("Glory_Victorious_House", "Victorious House");
			this.victoriousHouseLabel.Position = new Point(0, y);
			this.victoriousHouseLabel.Size = new Size(base.Width, 20);
			this.victoriousHouseLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.victoriousHouseLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.victoriousHouseLabel.Color = global::ARGBColors.Black;
			this.overlayImage.addControl(this.victoriousHouseLabel);
			CustomSelfDrawPanel.CSDImage csdimage = new CustomSelfDrawPanel.CSDImage();
			csdimage.Image = GFXLibrary.contestTrumpetLeftSmall;
			csdimage.setSizeToImage();
			csdimage.Position = new Point(this.leftFlag.Rectangle.Right + 10, this.victoriousHouseLabel.Y);
			this.overlayImage.addControl(csdimage);
			CustomSelfDrawPanel.CSDImage csdimage2 = new CustomSelfDrawPanel.CSDImage();
			csdimage2.Image = GFXLibrary.contestTrumpetRightSmall;
			csdimage2.setSizeToImage();
			csdimage2.Position = new Point(this.rightFlag.X - csdimage2.Width - 10, this.victoriousHouseLabel.Y);
			this.overlayImage.addControl(csdimage2);
			CustomSelfDrawPanel.CSDLabel csdlabel = new CustomSelfDrawPanel.CSDLabel();
			csdlabel.Text = houseGloryRoundData.winnerHouseID.ToString();
			csdlabel.Position = new Point(0, this.victoriousHouseLabel.Rectangle.Bottom);
			csdlabel.Size = new Size(base.Width, 55);
			csdlabel.Font = FontManager.GetFont("Arial", 40f, FontStyle.Bold);
			csdlabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			csdlabel.Color = global::ARGBColors.Black;
			csdlabel.RolloverColor = global::ARGBColors.Blue;
			this.victoriousHouseLabel.DropShadowColor = global::ARGBColors.White;
			csdlabel.Data = houseGloryRoundData.winnerHouseID;
			csdlabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.houseClicked), "GloryResult_winning_house");
			this.overlayImage.addControl(csdlabel);
			this.leadByLabel.Text = SK.Text("Glory_Lead_By", "Lead By");
			this.leadByLabel.Position = new Point(0, csdlabel.Rectangle.Bottom);
			this.leadByLabel.Size = new Size(base.Width, 15);
			this.leadByLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.leadByLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.leadByLabel.Color = global::ARGBColors.Black;
			this.overlayImage.addControl(this.leadByLabel);
			this.leaderNameLabel.Text = houseGloryRoundData.marshallName;
			this.leaderNameLabel.Position = new Point(0, this.leadByLabel.Rectangle.Bottom + 4);
			this.leaderNameLabel.Size = new Size(base.Width, 20);
			this.leaderNameLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.leaderNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.leaderNameLabel.Color = global::ARGBColors.Black;
			this.leaderNameLabel.RolloverColor = global::ARGBColors.Blue;
			this.leaderNameLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.playerClicked), "GloryResult_winning_player");
			this.overlayImage.addControl(this.leaderNameLabel);
			this.ofLabel.Text = SK.Text("Glory_Of", "Of");
			if (this.ofLabel.Text == "/")
			{
				this.ofLabel.Text = "";
			}
			this.ofLabel.Position = new Point(0, this.leaderNameLabel.Rectangle.Bottom + 2);
			this.ofLabel.Size = new Size(base.Width, 20);
			this.ofLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.ofLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.ofLabel.Color = global::ARGBColors.Black;
			this.overlayImage.addControl(this.ofLabel);
			this.factionNameLabel.Text = houseGloryRoundData.factionName;
			this.factionNameLabel.Position = new Point(0, this.ofLabel.Rectangle.Bottom + 2);
			this.factionNameLabel.Size = new Size(base.Width, 20);
			this.factionNameLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.factionNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.factionNameLabel.Color = global::ARGBColors.Black;
			this.factionNameLabel.RolloverColor = global::ARGBColors.Blue;
			this.factionNameLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.factionClicked), "GloryResult_winning_faction");
			this.overlayImage.addControl(this.factionNameLabel);
			GameEngine.Instance.World.getAllFactions();
			CustomSelfDrawPanel.CSDFactionFlagImage csdfactionFlagImage = new CustomSelfDrawPanel.CSDFactionFlagImage();
			csdfactionFlagImage.Scale = 0.5;
			csdfactionFlagImage.Position = new Point(base.Width / 2 - csdfactionFlagImage.Width / 4, this.factionNameLabel.Rectangle.Bottom);
			this.starsLabel.Text = SK.Text("Glory_CurrentStars", "Current Stars") + " : " + houseGloryRoundData.numStars.ToString();
			this.starsLabel.Position = new Point(0, csdfactionFlagImage.Y + csdfactionFlagImage.Height / 2 + 10);
			this.starsLabel.Size = new Size(base.Width, 20);
			this.starsLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
			this.starsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.starsLabel.Color = global::ARGBColors.Black;
			this.overlayImage.addControl(this.starsLabel);
			int num3 = this.starsLabel.Rectangle.Bottom + 10;
			if (houseGloryRoundData.houseEliminated1 > 0 || houseGloryRoundData.houseEliminated2 > 0)
			{
				this.eliminatedLabel.Text = SK.Text("Glory_Houses_Eliminated", "Houses Eliminated");
				this.eliminatedLabel.Position = new Point(0, num3);
				this.eliminatedLabel.Size = new Size(base.Width, 20);
				this.eliminatedLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
				this.eliminatedLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.eliminatedLabel.Color = global::ARGBColors.Black;
				this.overlayImage.addControl(this.eliminatedLabel);
				num3 += 25;
				if (houseGloryRoundData.houseEliminated1 > 0)
				{
					this.eliminatedHouse1Label.Text = SK.Text("STATS_CATEGORY_TITLE_HOUSE", "House") + houseGloryRoundData.houseEliminated1.ToString();
					this.eliminatedHouse1Label.Position = new Point(0, num3);
					this.eliminatedHouse1Label.Size = new Size(base.Width, 20);
					this.eliminatedHouse1Label.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
					this.eliminatedHouse1Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.eliminatedHouse1Label.Color = global::ARGBColors.Black;
					this.eliminatedHouse1Label.RolloverColor = global::ARGBColors.Blue;
					this.eliminatedHouse1Label.Data = houseGloryRoundData.houseEliminated1;
					this.eliminatedHouse1Label.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.houseClicked), "GloryResult_eliminated_house");
					this.overlayImage.addControl(this.eliminatedHouse1Label);
					num3 += 20;
				}
				if (houseGloryRoundData.houseEliminated2 > 0)
				{
					this.eliminatedHouse2Label.Text = SK.Text("STATS_CATEGORY_TITLE_HOUSE", "House") + houseGloryRoundData.houseEliminated2.ToString();
					this.eliminatedHouse2Label.Position = new Point(0, num3);
					this.eliminatedHouse2Label.Size = new Size(base.Width, 20);
					this.eliminatedHouse2Label.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
					this.eliminatedHouse2Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.eliminatedHouse2Label.Color = global::ARGBColors.Black;
					this.eliminatedHouse2Label.RolloverColor = global::ARGBColors.Blue;
					this.eliminatedHouse2Label.Data = houseGloryRoundData.houseEliminated2;
					this.eliminatedHouse2Label.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.houseClicked), "GloryResult_eliminated_house");
					this.overlayImage.addControl(this.eliminatedHouse2Label);
					num3 += 20;
				}
				num3 += 10;
			}
			if (houseGloryRoundData.houseLostStar1 > 0 || houseGloryRoundData.houseLostStar2 > 0)
			{
				this.lostStarsLabel.Text = SK.Text("Glory_Lost_a_Star", "Lost a Star");
				this.lostStarsLabel.Position = new Point(0, num3);
				this.lostStarsLabel.Size = new Size(base.Width, 20);
				this.lostStarsLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
				this.lostStarsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.lostStarsLabel.Color = global::ARGBColors.Black;
				this.overlayImage.addControl(this.lostStarsLabel);
				num3 += 25;
				if (houseGloryRoundData.houseLostStar1 > 0)
				{
					this.lostStarsHouse1Label.Text = SK.Text("STATS_CATEGORY_TITLE_HOUSE", "House") + houseGloryRoundData.houseLostStar1.ToString();
					this.lostStarsHouse1Label.Position = new Point(0, num3);
					this.lostStarsHouse1Label.Size = new Size(base.Width, 20);
					this.lostStarsHouse1Label.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
					this.lostStarsHouse1Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.lostStarsHouse1Label.Color = global::ARGBColors.Black;
					this.lostStarsHouse1Label.RolloverColor = global::ARGBColors.Blue;
					this.lostStarsHouse1Label.Data = houseGloryRoundData.houseLostStar1;
					this.lostStarsHouse1Label.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.houseClicked), "GloryResult_house_losing_star");
					this.overlayImage.addControl(this.lostStarsHouse1Label);
					num3 += 20;
				}
				if (houseGloryRoundData.houseLostStar2 > 0)
				{
					this.lostStarsHouse2Label.Text = SK.Text("STATS_CATEGORY_TITLE_HOUSE", "House") + houseGloryRoundData.houseLostStar2.ToString();
					this.lostStarsHouse2Label.Position = new Point(0, num3);
					this.lostStarsHouse2Label.Size = new Size(base.Width, 20);
					this.lostStarsHouse2Label.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
					this.lostStarsHouse2Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.lostStarsHouse2Label.Color = global::ARGBColors.Black;
					this.lostStarsHouse2Label.RolloverColor = global::ARGBColors.Blue;
					this.lostStarsHouse2Label.Data = houseGloryRoundData.houseLostStar2;
					this.lostStarsHouse2Label.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.houseClicked), "GloryResult_house_losing_star");
					this.overlayImage.addControl(this.lostStarsHouse2Label);
					num3 += 20;
				}
				num3 += 10;
			}
			CustomSelfDrawPanel.WikiLinkControl.init(this.overlayImage, 22, new Point(this.rightFlag.X - 40, 15));
		}

		// Token: 0x0600139B RID: 5019 RVA: 0x0001554F File Offset: 0x0001374F
		private void closeClick()
		{
			this.m_parent.Close();
		}

		// Token: 0x0600139C RID: 5020 RVA: 0x0014D564 File Offset: 0x0014B764
		private void houseClicked()
		{
			InterfaceMgr.Instance.closeGloryVictoryWindowPopup();
			CustomSelfDrawPanel.CSDControl clickedControl = this.ClickedControl;
			int data = clickedControl.Data;
			InterfaceMgr.Instance.showHousePanel(data);
		}

		// Token: 0x0600139D RID: 5021 RVA: 0x0014D594 File Offset: 0x0014B794
		private void playerClicked()
		{
			InterfaceMgr.Instance.closeGloryVictoryWindowPopup();
			InterfaceMgr.Instance.changeTab(0);
			GloryRoundData houseGloryRoundData = GameEngine.Instance.World.HouseGloryRoundData;
			WorldMap.CachedUserInfo cachedUserInfo = new WorldMap.CachedUserInfo();
			cachedUserInfo.userID = houseGloryRoundData.marshallUserID;
			InterfaceMgr.Instance.showUserInfoScreen(cachedUserInfo);
		}

		// Token: 0x0600139E RID: 5022 RVA: 0x0014D5E4 File Offset: 0x0014B7E4
		private void factionClicked()
		{
			InterfaceMgr.Instance.closeGloryVictoryWindowPopup();
			GloryRoundData houseGloryRoundData = GameEngine.Instance.World.HouseGloryRoundData;
			InterfaceMgr.Instance.showFactionPanel(houseGloryRoundData.factionID);
		}

		// Token: 0x0600139F RID: 5023 RVA: 0x0014EE38 File Offset: 0x0014D038
		public void initValues(Form parent)
		{
			this.m_parent = parent;
			base.clearControls();
			this.mainBackgroundImage.Image = GFXLibrary.mail2_mail_panel_middle_middle;
			this.mainBackgroundImage.ClipRect = new Rectangle(default(Point), base.Size);
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = base.Size;
			base.addControl(this.mainBackgroundImage);
			this.overlayImage.Position = new Point(0, 0);
			this.overlayImage.Size = this.mainBackgroundImage.Size;
			this.overlayImage.Create(GFXLibrary._9sclice_generic_top_left, GFXLibrary._9sclice_generic_top_mid, GFXLibrary._9sclice_generic_top_right, GFXLibrary._9sclice_generic_mid_left, GFXLibrary._9sclice_generic_mid_mid, GFXLibrary._9sclice_generic_mid_right, GFXLibrary._9sclice_generic_bottom_left, GFXLibrary._9sclice_generic_bottom_mid, GFXLibrary._9sclice_generic_bottom_right);
			this.mainBackgroundImage.addControl(this.overlayImage);
			this.closeButton.ImageNorm = GFXLibrary.button_132_normal;
			this.closeButton.ImageOver = GFXLibrary.button_132_over;
			this.closeButton.ImageClick = GFXLibrary.button_132_in;
			this.closeButton.setSizeToImage();
			this.closeButton.Text.Text = SK.Text("GENERIC_Close", "Close");
			this.closeButton.Position = new Point(base.Width / 2 - this.closeButton.Width / 2, base.Height - this.closeButton.Height - 15);
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "GloryResultPanel_close");
			this.overlayImage.addControl(this.closeButton);
			int num = 70;
			this.headerLabel.Text = SK.Text("GLORY_VALUES", "Glory Values");
			this.headerLabel.Position = new Point(0, 0);
			this.headerLabel.Size = new Size(base.Width, 50);
			this.headerLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.headerLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.headerLabel.Color = global::ARGBColors.Black;
			this.overlayImage.addControl(this.headerLabel);
			NumberFormatInfo nfi = GameEngine.NFI;
			this.parishLabel.Text = SK.Text("GENERIC_Parish", "Parish");
			this.parishLabel.Position = new Point(60, num + 30);
			this.parishLabel.Size = new Size(base.Width - 60, 20);
			this.parishLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
			this.parishLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.parishLabel.Color = global::ARGBColors.Black;
			this.overlayImage.addControl(this.parishLabel);
			this.parishValueLabel.Text = GameEngine.Instance.LocalWorldData.ParishGloryPoints.ToString("N", nfi);
			this.parishValueLabel.Position = new Point(0, num + 30);
			this.parishValueLabel.Size = new Size(base.Width - 60, 20);
			this.parishValueLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.parishValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.parishValueLabel.Color = global::ARGBColors.Black;
			this.overlayImage.addControl(this.parishValueLabel);
			this.countyLabel.Text = SK.Text("GENERIC_County", "County");
			this.countyLabel.Position = new Point(60, num + 70);
			this.countyLabel.Size = new Size(base.Width - 60, 20);
			this.countyLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
			this.countyLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.countyLabel.Color = global::ARGBColors.Black;
			this.overlayImage.addControl(this.countyLabel);
			this.countyValueLabel.Text = GameEngine.Instance.LocalWorldData.CountyGloryPoints.ToString("N", nfi);
			this.countyValueLabel.Position = new Point(0, num + 70);
			this.countyValueLabel.Size = new Size(base.Width - 60, 20);
			this.countyValueLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.countyValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.countyValueLabel.Color = global::ARGBColors.Black;
			this.overlayImage.addControl(this.countyValueLabel);
			this.provinceLabel.Text = SK.Text("GENERIC_Province", "Province");
			this.provinceLabel.Position = new Point(60, num + 110);
			this.provinceLabel.Size = new Size(base.Width - 60, 20);
			this.provinceLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
			this.provinceLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.provinceLabel.Color = global::ARGBColors.Black;
			this.overlayImage.addControl(this.provinceLabel);
			this.provinceValueLabel.Text = GameEngine.Instance.LocalWorldData.ProvinceGloryPoints.ToString("N", nfi);
			this.provinceValueLabel.Position = new Point(0, num + 110);
			this.provinceValueLabel.Size = new Size(base.Width - 60, 20);
			this.provinceValueLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.provinceValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.provinceValueLabel.Color = global::ARGBColors.Black;
			this.overlayImage.addControl(this.provinceValueLabel);
			this.countryLabel.Text = SK.Text("GENERIC_Country", "Country");
			this.countryLabel.Position = new Point(60, num + 150);
			this.countryLabel.Size = new Size(base.Width - 60, 20);
			this.countryLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
			this.countryLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.countryLabel.Color = global::ARGBColors.Black;
			this.overlayImage.addControl(this.countryLabel);
			this.countryValueLabel.Text = GameEngine.Instance.LocalWorldData.Country1GloryPoints.ToString("N", nfi);
			this.countryValueLabel.Position = new Point(0, num + 150);
			this.countryValueLabel.Size = new Size(base.Width - 60, 20);
			this.countryValueLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.countryValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.countryValueLabel.Color = global::ARGBColors.Black;
			this.overlayImage.addControl(this.countryValueLabel);
		}

		// Token: 0x060013A0 RID: 5024 RVA: 0x0001555C File Offset: 0x0001375C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060013A1 RID: 5025 RVA: 0x0001557B File Offset: 0x0001377B
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.None;
		}

		// Token: 0x040024A5 RID: 9381
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040024A6 RID: 9382
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040024A7 RID: 9383
		private CustomSelfDrawPanel.CSDExtendingPanel overlayImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x040024A8 RID: 9384
		private CustomSelfDrawPanel.CSDLabel headerLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024A9 RID: 9385
		private CustomSelfDrawPanel.CSDLabel dayLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024AA RID: 9386
		private CustomSelfDrawPanel.CSDLabel victoriousHouseLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024AB RID: 9387
		private CustomSelfDrawPanel.CSDLabel leadByLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024AC RID: 9388
		private CustomSelfDrawPanel.CSDLabel leaderNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024AD RID: 9389
		private CustomSelfDrawPanel.CSDLabel ofLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024AE RID: 9390
		private CustomSelfDrawPanel.CSDLabel factionNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024AF RID: 9391
		private CustomSelfDrawPanel.CSDLabel starsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024B0 RID: 9392
		private CustomSelfDrawPanel.CSDLabel eliminatedLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024B1 RID: 9393
		private CustomSelfDrawPanel.CSDLabel eliminatedHouse1Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024B2 RID: 9394
		private CustomSelfDrawPanel.CSDLabel eliminatedHouse2Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024B3 RID: 9395
		private CustomSelfDrawPanel.CSDLabel lostStarsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024B4 RID: 9396
		private CustomSelfDrawPanel.CSDLabel lostStarsHouse1Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024B5 RID: 9397
		private CustomSelfDrawPanel.CSDLabel lostStarsHouse2Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024B6 RID: 9398
		private CustomSelfDrawPanel.CSDLabel parishLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024B7 RID: 9399
		private CustomSelfDrawPanel.CSDLabel parishValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024B8 RID: 9400
		private CustomSelfDrawPanel.CSDLabel countyLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024B9 RID: 9401
		private CustomSelfDrawPanel.CSDLabel countyValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024BA RID: 9402
		private CustomSelfDrawPanel.CSDLabel provinceLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024BB RID: 9403
		private CustomSelfDrawPanel.CSDLabel provinceValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024BC RID: 9404
		private CustomSelfDrawPanel.CSDLabel countryLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024BD RID: 9405
		private CustomSelfDrawPanel.CSDLabel countryValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024BE RID: 9406
		private CustomSelfDrawPanel.CSDImage leftFlag = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040024BF RID: 9407
		private CustomSelfDrawPanel.CSDImage rightFlag = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040024C0 RID: 9408
		private Form m_parent;

		// Token: 0x040024C1 RID: 9409
		private IContainer components;
	}
}
