using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020001EA RID: 490
	public class GloryVictoryPanel : CustomSelfDrawPanel
	{
		// Token: 0x06001390 RID: 5008 RVA: 0x0001550F File Offset: 0x0001370F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001391 RID: 5009 RVA: 0x0001552E File Offset: 0x0001372E
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.None;
		}

		// Token: 0x06001392 RID: 5010 RVA: 0x0014C754 File Offset: 0x0014A954
		public GloryVictoryPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06001393 RID: 5011 RVA: 0x0014C88C File Offset: 0x0014AA8C
		public void init(Form parent)
		{
			this.m_parent = parent;
			base.clearControls();
			this.mainBackgroundImage.Image = GFXLibrary.mail2_mail_panel_middle_middle;
			this.mainBackgroundImage.ClipRect = new Rectangle(default(Point), base.Size);
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = base.Size;
			base.addControl(this.mainBackgroundImage);
			this.overlayImage.Image = GFXLibrary.char_achievementOverlay;
			this.overlayImage.Position = new Point(0, 0);
			this.mainBackgroundImage.addControl(this.overlayImage);
			this.closeButton.ImageNorm = GFXLibrary.int_button_close_normal;
			this.closeButton.ImageOver = GFXLibrary.int_button_close_over;
			this.closeButton.ImageClick = GFXLibrary.int_button_close_in;
			this.closeButton.Position = new Point(base.Width - 40, 0);
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "GloryResultPanel_close");
			this.overlayImage.addControl(this.closeButton);
			int num = 55;
			this.headerLabel.Text = SK.Text("Glory_Glory_Victor", "Last Glory Round Result");
			this.headerLabel.Position = new Point(0, 0);
			this.headerLabel.Size = new Size(base.Width, 30);
			this.headerLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.headerLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.headerLabel.Color = global::ARGBColors.White;
			this.headerLabel.RolloverColor = global::ARGBColors.Yellow;
			this.headerLabel.DropShadowColor = global::ARGBColors.Black;
			this.overlayImage.addControl(this.headerLabel);
			GloryRoundData houseGloryRoundData = GameEngine.Instance.World.HouseGloryRoundData;
			int num2 = (int)(houseGloryRoundData.victoryTime - GameEngine.Instance.World.m_worldStartDate).TotalDays;
			this.dayLabel.Text = SK.Text("MENU_Day_X", "Day") + " " + num2.ToString();
			this.dayLabel.Position = new Point(0, 28);
			this.dayLabel.Size = new Size(base.Width - 25, 30);
			this.dayLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.dayLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.dayLabel.Color = global::ARGBColors.White;
			this.dayLabel.RolloverColor = global::ARGBColors.Yellow;
			this.dayLabel.DropShadowColor = global::ARGBColors.Black;
			this.overlayImage.addControl(this.dayLabel);
			this.victoriousHouseLabel.Text = SK.Text("Glory_Victorious_House", "Victorious House") + " - " + houseGloryRoundData.winnerHouseID.ToString();
			this.victoriousHouseLabel.Position = new Point(0, num);
			this.victoriousHouseLabel.Size = new Size(base.Width, 20);
			this.victoriousHouseLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.victoriousHouseLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.victoriousHouseLabel.Color = global::ARGBColors.White;
			this.victoriousHouseLabel.RolloverColor = global::ARGBColors.Yellow;
			this.victoriousHouseLabel.DropShadowColor = global::ARGBColors.Black;
			this.victoriousHouseLabel.Data = houseGloryRoundData.winnerHouseID;
			this.victoriousHouseLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.houseClicked), "GloryResult_winning_house");
			this.overlayImage.addControl(this.victoriousHouseLabel);
			this.leadByLabel.Text = SK.Text("Glory_Lead_By", "Lead By");
			this.leadByLabel.Position = new Point(0, num + 20 - 2);
			this.leadByLabel.Size = new Size(base.Width, 20);
			this.leadByLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.leadByLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.leadByLabel.Color = global::ARGBColors.White;
			this.leadByLabel.DropShadowColor = global::ARGBColors.Black;
			this.overlayImage.addControl(this.leadByLabel);
			this.leaderNameLabel.Text = houseGloryRoundData.marshallName;
			this.leaderNameLabel.Position = new Point(0, num + 40);
			this.leaderNameLabel.Size = new Size(base.Width, 20);
			this.leaderNameLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.leaderNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.leaderNameLabel.Color = global::ARGBColors.White;
			this.leaderNameLabel.RolloverColor = global::ARGBColors.Yellow;
			this.leaderNameLabel.DropShadowColor = global::ARGBColors.Black;
			this.leaderNameLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.playerClicked), "GloryResult_winning_player");
			this.overlayImage.addControl(this.leaderNameLabel);
			this.ofLabel.Text = SK.Text("Glory_Of", "Of");
			if (this.ofLabel.Text == "/")
			{
				this.ofLabel.Text = "";
			}
			this.ofLabel.Position = new Point(0, num + 60 - 2);
			this.ofLabel.Size = new Size(base.Width, 20);
			this.ofLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.ofLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.ofLabel.Color = global::ARGBColors.White;
			this.ofLabel.DropShadowColor = global::ARGBColors.Black;
			this.overlayImage.addControl(this.ofLabel);
			this.factionNameLabel.Text = houseGloryRoundData.factionName;
			this.factionNameLabel.Position = new Point(0, num + 80);
			this.factionNameLabel.Size = new Size(base.Width, 20);
			this.factionNameLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.factionNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.factionNameLabel.Color = global::ARGBColors.White;
			this.factionNameLabel.RolloverColor = global::ARGBColors.Yellow;
			this.factionNameLabel.DropShadowColor = global::ARGBColors.Black;
			this.factionNameLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.factionClicked), "GloryResult_winning_faction");
			this.overlayImage.addControl(this.factionNameLabel);
			this.starsLabel.Text = SK.Text("Glory_CurrentStars", "Current Stars") + " : " + houseGloryRoundData.numStars.ToString();
			this.starsLabel.Position = new Point(0, num + 120);
			this.starsLabel.Size = new Size(base.Width, 20);
			this.starsLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
			this.starsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.starsLabel.Color = global::ARGBColors.White;
			this.starsLabel.DropShadowColor = global::ARGBColors.Black;
			this.overlayImage.addControl(this.starsLabel);
			int num3 = num + 160;
			if (houseGloryRoundData.houseEliminated1 > 0 || houseGloryRoundData.houseEliminated2 > 0)
			{
				this.eliminatedLabel.Text = SK.Text("Glory_Houses_Eliminated", "Houses Eliminated");
				this.eliminatedLabel.Position = new Point(0, num3);
				this.eliminatedLabel.Size = new Size(base.Width, 20);
				this.eliminatedLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
				this.eliminatedLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.eliminatedLabel.Color = global::ARGBColors.White;
				this.eliminatedLabel.DropShadowColor = global::ARGBColors.Black;
				this.overlayImage.addControl(this.eliminatedLabel);
				num3 += 25;
				if (houseGloryRoundData.houseEliminated1 > 0)
				{
					this.eliminatedHouse1Label.Text = SK.Text("STATS_CATEGORY_TITLE_HOUSE", "House") + houseGloryRoundData.houseEliminated1.ToString();
					this.eliminatedHouse1Label.Position = new Point(0, num3);
					this.eliminatedHouse1Label.Size = new Size(base.Width, 20);
					this.eliminatedHouse1Label.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
					this.eliminatedHouse1Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.eliminatedHouse1Label.Color = global::ARGBColors.White;
					this.eliminatedHouse1Label.RolloverColor = global::ARGBColors.Yellow;
					this.eliminatedHouse1Label.DropShadowColor = global::ARGBColors.Black;
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
					this.eliminatedHouse2Label.Color = global::ARGBColors.White;
					this.eliminatedHouse2Label.RolloverColor = global::ARGBColors.Yellow;
					this.eliminatedHouse2Label.DropShadowColor = global::ARGBColors.Black;
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
				this.lostStarsLabel.Color = global::ARGBColors.White;
				this.lostStarsLabel.DropShadowColor = global::ARGBColors.Black;
				this.overlayImage.addControl(this.lostStarsLabel);
				num3 += 25;
				if (houseGloryRoundData.houseLostStar1 > 0)
				{
					this.lostStarsHouse1Label.Text = SK.Text("STATS_CATEGORY_TITLE_HOUSE", "House") + houseGloryRoundData.houseLostStar1.ToString();
					this.lostStarsHouse1Label.Position = new Point(0, num3);
					this.lostStarsHouse1Label.Size = new Size(base.Width, 20);
					this.lostStarsHouse1Label.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
					this.lostStarsHouse1Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.lostStarsHouse1Label.Color = global::ARGBColors.White;
					this.lostStarsHouse1Label.RolloverColor = global::ARGBColors.Yellow;
					this.lostStarsHouse1Label.DropShadowColor = global::ARGBColors.Black;
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
					this.lostStarsHouse2Label.Color = global::ARGBColors.White;
					this.lostStarsHouse2Label.RolloverColor = global::ARGBColors.Yellow;
					this.lostStarsHouse2Label.DropShadowColor = global::ARGBColors.Black;
					this.lostStarsHouse2Label.Data = houseGloryRoundData.houseLostStar2;
					this.lostStarsHouse2Label.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.houseClicked), "GloryResult_house_losing_star");
					this.overlayImage.addControl(this.lostStarsHouse2Label);
					num3 += 20;
				}
				num3 += 10;
			}
		}

		// Token: 0x06001394 RID: 5012 RVA: 0x00015542 File Offset: 0x00013742
		private void closeClick()
		{
			this.m_parent.Close();
		}

		// Token: 0x06001395 RID: 5013 RVA: 0x0014D564 File Offset: 0x0014B764
		private void houseClicked()
		{
			InterfaceMgr.Instance.closeGloryVictoryWindowPopup();
			CustomSelfDrawPanel.CSDControl clickedControl = this.ClickedControl;
			int data = clickedControl.Data;
			InterfaceMgr.Instance.showHousePanel(data);
		}

		// Token: 0x06001396 RID: 5014 RVA: 0x0014D594 File Offset: 0x0014B794
		private void playerClicked()
		{
			InterfaceMgr.Instance.closeGloryVictoryWindowPopup();
			InterfaceMgr.Instance.changeTab(0);
			GloryRoundData houseGloryRoundData = GameEngine.Instance.World.HouseGloryRoundData;
			WorldMap.CachedUserInfo cachedUserInfo = new WorldMap.CachedUserInfo();
			cachedUserInfo.userID = houseGloryRoundData.marshallUserID;
			InterfaceMgr.Instance.showUserInfoScreen(cachedUserInfo);
		}

		// Token: 0x06001397 RID: 5015 RVA: 0x0014D5E4 File Offset: 0x0014B7E4
		private void factionClicked()
		{
			InterfaceMgr.Instance.closeGloryVictoryWindowPopup();
			GloryRoundData houseGloryRoundData = GameEngine.Instance.World.HouseGloryRoundData;
			InterfaceMgr.Instance.showFactionPanel(houseGloryRoundData.factionID);
		}

		// Token: 0x06001398 RID: 5016 RVA: 0x0014D61C File Offset: 0x0014B81C
		public void initValues(Form parent)
		{
			this.m_parent = parent;
			base.clearControls();
			this.mainBackgroundImage.Image = GFXLibrary.mail2_mail_panel_middle_middle;
			this.mainBackgroundImage.ClipRect = new Rectangle(default(Point), base.Size);
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = base.Size;
			base.addControl(this.mainBackgroundImage);
			this.overlayImage.Image = GFXLibrary.char_achievementOverlay;
			this.overlayImage.Position = new Point(0, 0);
			this.mainBackgroundImage.addControl(this.overlayImage);
			this.closeButton.ImageNorm = GFXLibrary.int_button_close_normal;
			this.closeButton.ImageOver = GFXLibrary.int_button_close_over;
			this.closeButton.ImageClick = GFXLibrary.int_button_close_in;
			this.closeButton.Position = new Point(base.Width - 40, 0);
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "GloryResultPanel_close");
			this.overlayImage.addControl(this.closeButton);
			int num = 70;
			this.headerLabel.Text = SK.Text("GLORY_VALUES", "Glory Values");
			this.headerLabel.Position = new Point(0, 0);
			this.headerLabel.Size = new Size(base.Width, 30);
			this.headerLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.headerLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.headerLabel.Color = global::ARGBColors.White;
			this.headerLabel.DropShadowColor = global::ARGBColors.Black;
			this.overlayImage.addControl(this.headerLabel);
			NumberFormatInfo nfi = GameEngine.NFI;
			this.parishLabel.Text = SK.Text("GENERIC_Parish", "Parish");
			this.parishLabel.Position = new Point(60, num + 30);
			this.parishLabel.Size = new Size(base.Width - 60, 20);
			this.parishLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
			this.parishLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.parishLabel.Color = global::ARGBColors.White;
			this.parishLabel.DropShadowColor = global::ARGBColors.Black;
			this.overlayImage.addControl(this.parishLabel);
			this.parishValueLabel.Text = GameEngine.Instance.LocalWorldData.ParishGloryPoints.ToString("N", nfi);
			this.parishValueLabel.Position = new Point(0, num + 30);
			this.parishValueLabel.Size = new Size(base.Width - 60, 20);
			this.parishValueLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.parishValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.parishValueLabel.Color = global::ARGBColors.White;
			this.parishValueLabel.DropShadowColor = global::ARGBColors.Black;
			this.overlayImage.addControl(this.parishValueLabel);
			this.countyLabel.Text = SK.Text("GENERIC_County", "County");
			this.countyLabel.Position = new Point(60, num + 70);
			this.countyLabel.Size = new Size(base.Width - 60, 20);
			this.countyLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
			this.countyLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.countyLabel.Color = global::ARGBColors.White;
			this.countyLabel.DropShadowColor = global::ARGBColors.Black;
			this.overlayImage.addControl(this.countyLabel);
			this.countyValueLabel.Text = GameEngine.Instance.LocalWorldData.CountyGloryPoints.ToString("N", nfi);
			this.countyValueLabel.Position = new Point(0, num + 70);
			this.countyValueLabel.Size = new Size(base.Width - 60, 20);
			this.countyValueLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.countyValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.countyValueLabel.Color = global::ARGBColors.White;
			this.countyValueLabel.DropShadowColor = global::ARGBColors.Black;
			this.overlayImage.addControl(this.countyValueLabel);
			this.provinceLabel.Text = SK.Text("GENERIC_Province", "Province");
			this.provinceLabel.Position = new Point(60, num + 110);
			this.provinceLabel.Size = new Size(base.Width - 60, 20);
			this.provinceLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
			this.provinceLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.provinceLabel.Color = global::ARGBColors.White;
			this.provinceLabel.DropShadowColor = global::ARGBColors.Black;
			this.overlayImage.addControl(this.provinceLabel);
			this.provinceValueLabel.Text = GameEngine.Instance.LocalWorldData.ProvinceGloryPoints.ToString("N", nfi);
			this.provinceValueLabel.Position = new Point(0, num + 110);
			this.provinceValueLabel.Size = new Size(base.Width - 60, 20);
			this.provinceValueLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.provinceValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.provinceValueLabel.Color = global::ARGBColors.White;
			this.provinceValueLabel.DropShadowColor = global::ARGBColors.Black;
			this.overlayImage.addControl(this.provinceValueLabel);
			this.countryLabel.Text = SK.Text("GENERIC_Country", "Country");
			this.countryLabel.Position = new Point(60, num + 150);
			this.countryLabel.Size = new Size(base.Width - 60, 20);
			this.countryLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
			this.countryLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.countryLabel.Color = global::ARGBColors.White;
			this.countryLabel.DropShadowColor = global::ARGBColors.Black;
			this.overlayImage.addControl(this.countryLabel);
			this.countryValueLabel.Text = GameEngine.Instance.LocalWorldData.Country1GloryPoints.ToString("N", nfi);
			this.countryValueLabel.Position = new Point(0, num + 150);
			this.countryValueLabel.Size = new Size(base.Width - 60, 20);
			this.countryValueLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.countryValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.countryValueLabel.Color = global::ARGBColors.White;
			this.countryValueLabel.DropShadowColor = global::ARGBColors.Black;
			this.overlayImage.addControl(this.countryValueLabel);
		}

		// Token: 0x0400248A RID: 9354
		private IContainer components;

		// Token: 0x0400248B RID: 9355
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400248C RID: 9356
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400248D RID: 9357
		private CustomSelfDrawPanel.CSDImage overlayImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400248E RID: 9358
		private CustomSelfDrawPanel.CSDLabel headerLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400248F RID: 9359
		private CustomSelfDrawPanel.CSDLabel dayLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002490 RID: 9360
		private CustomSelfDrawPanel.CSDLabel victoriousHouseLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002491 RID: 9361
		private CustomSelfDrawPanel.CSDLabel leadByLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002492 RID: 9362
		private CustomSelfDrawPanel.CSDLabel leaderNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002493 RID: 9363
		private CustomSelfDrawPanel.CSDLabel ofLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002494 RID: 9364
		private CustomSelfDrawPanel.CSDLabel factionNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002495 RID: 9365
		private CustomSelfDrawPanel.CSDLabel starsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002496 RID: 9366
		private CustomSelfDrawPanel.CSDLabel eliminatedLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002497 RID: 9367
		private CustomSelfDrawPanel.CSDLabel eliminatedHouse1Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002498 RID: 9368
		private CustomSelfDrawPanel.CSDLabel eliminatedHouse2Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002499 RID: 9369
		private CustomSelfDrawPanel.CSDLabel lostStarsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400249A RID: 9370
		private CustomSelfDrawPanel.CSDLabel lostStarsHouse1Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400249B RID: 9371
		private CustomSelfDrawPanel.CSDLabel lostStarsHouse2Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400249C RID: 9372
		private CustomSelfDrawPanel.CSDLabel parishLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400249D RID: 9373
		private CustomSelfDrawPanel.CSDLabel parishValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400249E RID: 9374
		private CustomSelfDrawPanel.CSDLabel countyLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400249F RID: 9375
		private CustomSelfDrawPanel.CSDLabel countyValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024A0 RID: 9376
		private CustomSelfDrawPanel.CSDLabel provinceLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024A1 RID: 9377
		private CustomSelfDrawPanel.CSDLabel provinceValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024A2 RID: 9378
		private CustomSelfDrawPanel.CSDLabel countryLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024A3 RID: 9379
		private CustomSelfDrawPanel.CSDLabel countryValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024A4 RID: 9380
		private Form m_parent;
	}
}
