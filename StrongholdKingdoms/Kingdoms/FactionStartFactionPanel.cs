using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020001D3 RID: 467
	public class FactionStartFactionPanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06001199 RID: 4505 RVA: 0x00129BD0 File Offset: 0x00127DD0
		public FactionStartFactionPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x0600119A RID: 4506 RVA: 0x00129DB4 File Offset: 0x00127FB4
		public void init(bool resized)
		{
			int height = base.Height;
			FactionStartFactionPanel.instance = this;
			base.clearControls();
			this.sidebar.addSideBar(5, this);
			this.mainBackgroundImage.FillColor = Color.FromArgb(134, 153, 165);
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = new Size(base.Width - 200, height);
			base.addControl(this.mainBackgroundImage);
			this.backgroundFade.Image = GFXLibrary.background_top;
			this.backgroundFade.Position = new Point(0, 0);
			this.backgroundFade.Size = new Size(base.Width - 200, this.backgroundFade.Image.Height);
			this.mainBackgroundImage.addControl(this.backgroundFade);
			this.bar1.Image = GFXLibrary.lineitem_strip_01_dark;
			this.bar1.Position = new Point(30, 20);
			this.mainBackgroundImage.addControl(this.bar1);
			this.bar2.Image = GFXLibrary.lineitem_strip_01_light;
			this.bar2.Position = new Point(30, 80);
			this.mainBackgroundImage.addControl(this.bar2);
			this.bar3.Image = GFXLibrary.lineitem_strip_01_dark;
			this.bar3.Position = new Point(30, 140);
			this.mainBackgroundImage.addControl(this.bar3);
			this.nameLabel.Text = SK.Text("CreateFactionPopup_Faction_Name", "Faction Name");
			this.nameLabel.Color = global::ARGBColors.Black;
			this.nameLabel.Position = new Point(20, 0);
			this.nameLabel.Size = new Size(600, this.bar1.Height);
			this.nameLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.nameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.bar1.addControl(this.nameLabel);
			this.nameLabelInfo.Text = SK.Text("CreateFactionPopup_Faction_Name_Length", "(between 4 - 49 characters)");
			this.nameLabelInfo.Color = Color.FromArgb(64, 64, 64);
			this.nameLabelInfo.Position = new Point(225, 26);
			this.nameLabelInfo.Size = new Size(600, 40);
			this.nameLabelInfo.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.nameLabelInfo.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.bar1.addControl(this.nameLabelInfo);
			this.abbrvLabel.Text = SK.Text("CreateFactionPopup_Faction_Short_Name", "Faction Short Name");
			this.abbrvLabel.Color = global::ARGBColors.Black;
			this.abbrvLabel.Position = new Point(20, 0);
			this.abbrvLabel.Size = new Size(600, this.bar1.Height);
			this.abbrvLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.abbrvLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.bar2.addControl(this.abbrvLabel);
			this.abbrvLabelInfo.Text = SK.Text("CreateFactionPopup_Faction_Short_Name_Length", "(between 4 - 10 characters)");
			this.abbrvLabelInfo.Color = Color.FromArgb(64, 64, 64);
			this.abbrvLabelInfo.Position = new Point(225, 26);
			this.abbrvLabelInfo.Size = new Size(600, 40);
			this.abbrvLabelInfo.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.abbrvLabelInfo.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.bar2.addControl(this.abbrvLabelInfo);
			this.mottoLabel.Text = SK.Text("CreateFactionPopup_Faction_Motto", "Faction Motto");
			this.mottoLabel.Color = global::ARGBColors.Black;
			this.mottoLabel.Position = new Point(20, 0);
			this.mottoLabel.Size = new Size(600, this.bar3.Height);
			this.mottoLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.mottoLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.bar3.addControl(this.mottoLabel);
			this.mottoLabelInfo.Text = SK.Text("CreateFactionPopup_Faction_Motto_Length", "(between 4 - 49 characters)");
			this.mottoLabelInfo.Color = Color.FromArgb(64, 64, 64);
			this.mottoLabelInfo.Position = new Point(225, 26);
			this.mottoLabelInfo.Size = new Size(600, 40);
			this.mottoLabelInfo.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.mottoLabelInfo.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.bar3.addControl(this.mottoLabelInfo);
			if (FactionStartFactionPanel.StartFaction)
			{
				InterfaceMgr.Instance.setVillageHeading(SK.Text("FactionInvites_Start_Faction", "Start New Faction"));
			}
			else
			{
				InterfaceMgr.Instance.setVillageHeading(SK.Text("FactionInvites_Edit_Faction", "Edit Faction Details"));
			}
			this.createButton.ImageNorm = GFXLibrary.misc_button_blue_210wide_normal;
			this.createButton.ImageOver = GFXLibrary.misc_button_blue_210wide_over;
			this.createButton.ImageClick = GFXLibrary.misc_button_blue_210wide_pushed;
			this.createButton.Position = new Point(291, 520);
			if (FactionStartFactionPanel.StartFaction)
			{
				this.createButton.Text.Text = SK.Text("CreateFactionPopup_Create", "Create");
			}
			else
			{
				this.createButton.Text.Text = SK.Text("FactionInvites_Apply_Changes", "Apply Changes");
			}
			this.createButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.createButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.createButton.TextYOffset = -3;
			this.createButton.Text.Color = global::ARGBColors.Black;
			if (!resized)
			{
				this.createButton.Enabled = false;
				this.createButton.Visible = true;
			}
			this.createButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.createClick), "FactionStartFactionPanel_create");
			this.mainBackgroundImage.addControl(this.createButton);
			this.selectedFlag.Position = new Point(276, 230);
			this.mainBackgroundImage.addControl(this.selectedFlag);
			this.flagMinus1.Position = new Point(166, 260);
			this.flagMinus1.Scale = 0.5;
			this.flagMinus1.ClickArea = new Rectangle(0, 0, GFXLibrary.factionFlags[0].Width / 2, GFXLibrary.factionFlags[0].Height / 2);
			this.flagMinus1.Visible = false;
			this.flagMinus1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.flagDec), "FactionStartFactionPanel_change");
			this.mainBackgroundImage.addControl(this.flagMinus1);
			this.flagMinus2.Position = new Point(46, 260);
			this.flagMinus2.Scale = 0.5;
			this.flagMinus2.ClickArea = new Rectangle(0, 0, GFXLibrary.factionFlags[0].Width / 2, GFXLibrary.factionFlags[0].Height / 2);
			this.flagMinus2.Visible = false;
			this.flagMinus2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.flagDec2), "FactionStartFactionPanel_change");
			this.mainBackgroundImage.addControl(this.flagMinus2);
			this.flagPlus1.Position = new Point(506, 260);
			this.flagPlus1.Scale = 0.5;
			this.flagPlus1.ClickArea = new Rectangle(0, 0, GFXLibrary.factionFlags[0].Width / 2, GFXLibrary.factionFlags[0].Height / 2);
			this.flagPlus1.Visible = false;
			this.flagPlus1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.flagInc), "FactionStartFactionPanel_change");
			this.mainBackgroundImage.addControl(this.flagPlus1);
			this.flagPlus2.Position = new Point(626, 260);
			this.flagPlus2.Scale = 0.5;
			this.flagPlus2.ClickArea = new Rectangle(0, 0, GFXLibrary.factionFlags[0].Width / 2, GFXLibrary.factionFlags[0].Height / 2);
			this.flagPlus2.Visible = false;
			this.flagPlus2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.flagInc2), "FactionStartFactionPanel_change");
			this.mainBackgroundImage.addControl(this.flagPlus2);
			this.flagPlusButton.ImageNorm = GFXLibrary.arrow_button_right_normal;
			this.flagPlusButton.ImageOver = GFXLibrary.arrow_button_right_over;
			this.flagPlusButton.ImageClick = GFXLibrary.arrow_button_right_pushed;
			this.flagPlusButton.Position = new Point(746, 269);
			this.flagPlusButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.flagInc), "FactionStartFactionPanel_change");
			this.mainBackgroundImage.addControl(this.flagPlusButton);
			this.flagMinusButton.ImageNorm = GFXLibrary.arrow_button_left_normal;
			this.flagMinusButton.ImageOver = GFXLibrary.arrow_button_left_over;
			this.flagMinusButton.ImageClick = GFXLibrary.arrow_button_left_pushed;
			this.flagMinusButton.Position = new Point(2, 269);
			this.flagMinusButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.flagDec), "FactionStartFactionPanel_change");
			this.mainBackgroundImage.addControl(this.flagMinusButton);
			this.inset1.Image = GFXLibrary.faction_inset;
			this.inset1.Position = new Point(7, 374);
			this.mainBackgroundImage.addControl(this.inset1);
			this.inset2.Image = GFXLibrary.faction_inset;
			this.inset2.Position = new Point(207, 374);
			this.mainBackgroundImage.addControl(this.inset2);
			this.inset3.Image = GFXLibrary.faction_inset;
			this.inset3.Position = new Point(407, 374);
			this.mainBackgroundImage.addControl(this.inset3);
			this.inset4.Image = GFXLibrary.faction_inset;
			this.inset4.Position = new Point(607, 374);
			this.mainBackgroundImage.addControl(this.inset4);
			for (int i = 0; i < 32; i++)
			{
				this.colours1[i] = new CustomSelfDrawPanel.CSDFill();
				this.colours1[i].Position = new Point(17 + i % 8 * 20, 400 + i / 8 * 20);
				this.colours1[i].FillColor = FactionData.getColour(i);
				this.colours1[i].Size = new Size(20, 20);
				this.colours1[i].Data = i;
				this.colours1[i].setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.colours1clicked), "FactionStartFactionPanel_colours");
				this.mainBackgroundImage.addControl(this.colours1[i]);
			}
			for (int j = 0; j < 32; j++)
			{
				this.colours2[j] = new CustomSelfDrawPanel.CSDFill();
				this.colours2[j].Position = new Point(217 + j % 8 * 20, 400 + j / 8 * 20);
				this.colours2[j].FillColor = FactionData.getColour(j);
				this.colours2[j].Size = new Size(20, 20);
				this.colours2[j].Data = j;
				this.colours2[j].setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.colours2clicked), "FactionStartFactionPanel_colours");
				this.mainBackgroundImage.addControl(this.colours2[j]);
			}
			for (int k = 0; k < 32; k++)
			{
				this.colours3[k] = new CustomSelfDrawPanel.CSDFill();
				this.colours3[k].Position = new Point(417 + k % 8 * 20, 400 + k / 8 * 20);
				this.colours3[k].FillColor = FactionData.getColour(k);
				this.colours3[k].Size = new Size(20, 20);
				this.colours3[k].Data = k;
				this.colours3[k].setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.colours3clicked), "FactionStartFactionPanel_colours");
				this.mainBackgroundImage.addControl(this.colours3[k]);
			}
			for (int l = 0; l < 32; l++)
			{
				this.colours4[l] = new CustomSelfDrawPanel.CSDFill();
				this.colours4[l].Position = new Point(617 + l % 8 * 20, 400 + l / 8 * 20);
				this.colours4[l].FillColor = FactionData.getColour(l);
				this.colours4[l].Size = new Size(20, 20);
				this.colours4[l].Data = l;
				this.colours4[l].setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.colours4clicked), "FactionStartFactionPanel_colours");
				this.mainBackgroundImage.addControl(this.colours4[l]);
			}
			this.selectedColour1.LineColor = global::ARGBColors.Black;
			this.selectedColour1.Size = new Size(20, 20);
			this.mainBackgroundImage.addControl(this.selectedColour1);
			this.selectedColour2.LineColor = global::ARGBColors.Black;
			this.selectedColour2.Size = new Size(20, 20);
			this.mainBackgroundImage.addControl(this.selectedColour2);
			this.selectedColour3.LineColor = global::ARGBColors.Black;
			this.selectedColour3.Size = new Size(20, 20);
			this.mainBackgroundImage.addControl(this.selectedColour3);
			this.selectedColour4.LineColor = global::ARGBColors.Black;
			this.selectedColour4.Size = new Size(20, 20);
			this.mainBackgroundImage.addControl(this.selectedColour4);
			this.colour1Label.Text = SK.Text("FactionFlags_colour1", "Colour 1");
			this.colour1Label.Color = global::ARGBColors.Black;
			this.colour1Label.Position = new Point(17, 375);
			this.colour1Label.Size = new Size(160, 25);
			this.colour1Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.colour1Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.mainBackgroundImage.addControl(this.colour1Label);
			this.colour2Label.Text = SK.Text("FactionFlags_colour2", "Colour 2");
			this.colour2Label.Color = global::ARGBColors.Black;
			this.colour2Label.Position = new Point(217, 375);
			this.colour2Label.Size = new Size(160, 25);
			this.colour2Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.colour2Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.mainBackgroundImage.addControl(this.colour2Label);
			this.colour3Label.Text = SK.Text("FactionFlags_colour3", "Colour 3");
			this.colour3Label.Color = global::ARGBColors.Black;
			this.colour3Label.Position = new Point(417, 375);
			this.colour3Label.Size = new Size(160, 25);
			this.colour3Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.colour3Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.mainBackgroundImage.addControl(this.colour3Label);
			this.colour4Label.Text = SK.Text("FactionFlags_colour4", "Colour 4");
			this.colour4Label.Color = global::ARGBColors.Black;
			this.colour4Label.Position = new Point(617, 375);
			this.colour4Label.Size = new Size(160, 25);
			this.colour4Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.colour4Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.mainBackgroundImage.addControl(this.colour4Label);
			if (!resized)
			{
				if (FactionStartFactionPanel.StartFaction)
				{
					this.tbFactionName.Text = "";
					this.tbFactionShortName.Text = "";
					this.tbMotto.Text = "";
					this.factionFlagData = FactionData.createFlagData(1, 9, 15, 4, 28);
				}
				else
				{
					this.tbFactionName.Text = GameEngine.Instance.World.YourFaction.factionName;
					this.tbFactionShortName.Text = GameEngine.Instance.World.YourFaction.factionNameAbrv;
					this.tbMotto.Text = GameEngine.Instance.World.YourFaction.factionMotto;
					this.factionFlagData = GameEngine.Instance.World.YourFaction.flagData;
					if (this.factionFlagData <= 0)
					{
						this.factionFlagData = FactionData.createFlagData(1, 9, 15, 4, 28);
					}
				}
			}
			this.updateFlags(null, 0);
			if (GameEngine.Instance.World.getRank() < GameEngine.Instance.LocalWorldData.Faction_CreateAtLevel - 1)
			{
				if (GameEngine.Instance.LocalWorldData.Faction_CreateAtLevel == 12)
				{
					this.rankNeededLabel.Text = SK.Text("FactionsPanel_Rank_Needed_12", "You don't currently have the required Rank (12) to create a Faction.");
				}
				else
				{
					this.rankNeededLabel.Text = SK.Text("FactionsPanel_Rank_Needed", "You don't currently have the required Rank (14) to create a Faction.");
				}
				this.rankNeededLabel.Color = global::ARGBColors.Black;
				this.rankNeededLabel.Position = new Point(0, 190);
				this.rankNeededLabel.Size = new Size(this.mainBackgroundImage.Size.Width, 40);
				this.rankNeededLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				this.rankNeededLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.mainBackgroundImage.addControl(this.rankNeededLabel);
				this.createButton.Visible = false;
				this.tbFactionName.Enabled = false;
				this.tbFactionShortName.Enabled = false;
				this.tbMotto.Enabled = false;
				this.flagPlusButton.Enabled = false;
				this.flagMinusButton.Enabled = false;
				this.clicksActive = false;
				for (int m = 0; m < 32; m++)
				{
					this.colours1[m].FillColor = Color.FromArgb(128, this.colours1[m].FillColor);
					this.colours2[m].FillColor = Color.FromArgb(128, this.colours2[m].FillColor);
					this.colours3[m].FillColor = Color.FromArgb(128, this.colours3[m].FillColor);
					this.colours4[m].FillColor = Color.FromArgb(128, this.colours4[m].FillColor);
				}
				this.inset1.Alpha = 0.3f;
				this.inset2.Alpha = 0.3f;
				this.inset3.Alpha = 0.3f;
				this.inset4.Alpha = 0.3f;
				this.flagMinus1.Alpha = 0.3f;
				this.flagMinus2.Alpha = 0.3f;
				this.flagPlus1.Alpha = 0.3f;
				this.flagPlus2.Alpha = 0.3f;
				int num = 0;
				int colour = 0;
				int colour2 = 0;
				int colour3 = 0;
				int colour4 = 0;
				FactionData.getFlagData(this.factionFlagData, ref num, ref colour, ref colour2, ref colour3, ref colour4);
				ColorMap[] colourMap = FactionData.getColourMap(colour, colour2, colour3, colour4, 100);
				this.selectedFlag.ColourMap = colourMap;
				this.flagMinus2.ColourMap = colourMap;
				this.flagMinus1.ColourMap = colourMap;
				this.flagPlus1.ColourMap = colourMap;
				this.flagPlus2.ColourMap = colourMap;
			}
			else
			{
				this.createButton.Visible = true;
				this.tbFactionName.Enabled = true;
				this.tbFactionShortName.Enabled = true;
				this.tbMotto.Enabled = true;
				this.flagPlusButton.Enabled = true;
				this.flagMinusButton.Enabled = true;
				this.clicksActive = true;
				this.inset1.Alpha = 1f;
				this.inset2.Alpha = 1f;
				this.inset3.Alpha = 1f;
				this.inset4.Alpha = 1f;
				this.flagMinus1.Alpha = 1f;
				this.flagMinus2.Alpha = 1f;
				this.flagPlus1.Alpha = 1f;
				this.flagPlus2.Alpha = 1f;
			}
			if (!resized)
			{
				CustomSelfDrawPanel.FactionPanelSideBar.downloadCurrentFactionInfo();
			}
			if (GameEngine.Instance.World.WorldEnded)
			{
				this.createButton.Visible = false;
			}
		}

		// Token: 0x0600119B RID: 4507 RVA: 0x0012B388 File Offset: 0x00129588
		public void update()
		{
			this.sidebar.update();
			if (this.tbFactionShortName.Text.Length > 3 && this.tbFactionName.Text.Length > 3 && this.tbMotto.Text.Length > 3 && StringValidation.isValidGameString(this.tbFactionShortName.Text) && StringValidation.notAllSpaces(this.tbFactionShortName.Text) && StringValidation.isValidGameString(this.tbFactionName.Text) && StringValidation.notAllSpaces(this.tbFactionName.Text))
			{
				this.createButton.Enabled = true;
				return;
			}
			this.createButton.Enabled = false;
		}

		// Token: 0x0600119C RID: 4508 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void logout()
		{
		}

		// Token: 0x0600119D RID: 4509 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void closing()
		{
		}

		// Token: 0x0600119E RID: 4510 RVA: 0x0012B43C File Offset: 0x0012963C
		public void createClick()
		{
			if (this.tbFactionShortName.Text.Length > 3 && this.tbFactionName.Text.Length > 3 && this.tbMotto.Text.Length > 3 && StringValidation.isValidGameString(this.tbFactionShortName.Text) && StringValidation.notAllSpaces(this.tbFactionShortName.Text) && StringValidation.isValidGameString(this.tbFactionName.Text) && StringValidation.notAllSpaces(this.tbFactionName.Text))
			{
				this.createFaction(this.tbFactionName.Text, this.tbFactionShortName.Text, this.tbMotto.Text);
			}
		}

		// Token: 0x0600119F RID: 4511 RVA: 0x0012B4F8 File Offset: 0x001296F8
		public void createFaction(string factionName, string factionNameAbrv, string factionMotto)
		{
			this.createButton.Enabled = false;
			if (FactionStartFactionPanel.StartFaction)
			{
				RemoteServices.Instance.set_CreateFaction_UserCallBack(new RemoteServices.CreateFaction_UserCallBack(this.createFactionCallback));
				RemoteServices.Instance.CreateFaction(factionName, factionNameAbrv, factionMotto, this.factionFlagData);
				return;
			}
			RemoteServices.Instance.set_ChangeFactionMotto_UserCallBack(new RemoteServices.ChangeFactionMotto_UserCallBack(this.changeFactionMottoCallback));
			RemoteServices.Instance.ChangeFactionMotto(factionName, factionNameAbrv, factionMotto, this.factionFlagData);
		}

		// Token: 0x060011A0 RID: 4512 RVA: 0x0012B56C File Offset: 0x0012976C
		public void changeFactionMottoCallback(ChangeFactionMotto_ReturnType returnData)
		{
			if (returnData.yourFaction != null)
			{
				GameEngine.Instance.World.YourFaction = returnData.yourFaction;
			}
			if (returnData.Success)
			{
				if (returnData.yourFaction != null)
				{
					InterfaceMgr.Instance.setVillageTabSubMode(46, false);
					return;
				}
			}
			else
			{
				MyMessageBox.Show(ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID), SK.Text("FactionsPanel_Faction_Edit_Error", "Faction Edit Error"));
				this.createButton.Enabled = true;
			}
		}

		// Token: 0x060011A1 RID: 4513 RVA: 0x0012B5E8 File Offset: 0x001297E8
		public void createFactionCallback(CreateFaction_ReturnType returnData)
		{
			if (returnData.Success && returnData.yourFaction != null)
			{
				RemoteServices.Instance.UserFactionID = returnData.yourFaction.factionID;
				GameEngine.Instance.World.YourFaction = returnData.yourFaction;
				GameEngine.Instance.World.FactionMembers = returnData.members;
				GameEngine.Instance.World.FactionAllies = null;
				GameEngine.Instance.World.FactionEnemies = null;
				GameEngine.Instance.World.HouseAllies = null;
				GameEngine.Instance.World.HouseEnemies = null;
				InterfaceMgr.Instance.getFactionTabBar().forceChangeTab(1);
				GameEngine.Instance.World.LastUpdatedCrowns = DateTime.MinValue;
				return;
			}
			MyMessageBox.Show(ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID), SK.Text("FactionsPanel_Faction_Create_Error", "Faction Create Error"));
			this.createButton.Enabled = true;
		}

		// Token: 0x060011A2 RID: 4514 RVA: 0x0012B6E4 File Offset: 0x001298E4
		private void tbFactionName_TextChanged(object sender, EventArgs e)
		{
			if (this.tbFactionShortName.Text.Length > 3 && this.tbFactionName.Text.Length > 3 && this.tbMotto.Text.Length > 3 && StringValidation.isValidGameString(this.tbFactionShortName.Text) && StringValidation.notAllSpaces(this.tbFactionShortName.Text) && StringValidation.isValidGameString(this.tbFactionName.Text) && StringValidation.notAllSpaces(this.tbFactionName.Text))
			{
				this.createButton.Enabled = true;
				return;
			}
			this.createButton.Enabled = false;
		}

		// Token: 0x060011A3 RID: 4515 RVA: 0x0012B78C File Offset: 0x0012998C
		public void updateFlags(CustomSelfDrawPanel.CSDFill fill, int fillBoxNumber)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			FactionData.getFlagData(this.factionFlagData, ref num, ref num2, ref num3, ref num4, ref num5);
			if (num == 0)
			{
				num = 1;
			}
			if (num - 2 >= 1)
			{
				this.flagMinus2.Visible = true;
				this.flagMinus2.Image = GFXLibrary.factionFlags[num - 2];
			}
			else
			{
				this.flagMinus2.Visible = true;
				this.flagMinus2.Image = GFXLibrary.factionFlags[num - 2 + 63];
			}
			if (num - 1 >= 1)
			{
				this.flagMinus1.Visible = true;
				this.flagMinus1.Image = GFXLibrary.factionFlags[num - 1];
			}
			else
			{
				this.flagMinus1.Visible = true;
				this.flagMinus1.Image = GFXLibrary.factionFlags[num - 1 + 63];
			}
			if (num + 1 < GFXLibrary.factionFlags.Length)
			{
				this.flagPlus1.Visible = true;
				this.flagPlus1.Image = GFXLibrary.factionFlags[num + 1];
			}
			else
			{
				this.flagPlus1.Visible = true;
				this.flagPlus1.Image = GFXLibrary.factionFlags[num + 1 - 63];
			}
			if (num + 2 < GFXLibrary.factionFlags.Length)
			{
				this.flagPlus2.Visible = true;
				this.flagPlus2.Image = GFXLibrary.factionFlags[num + 2];
			}
			else
			{
				this.flagPlus2.Visible = true;
				this.flagPlus2.Image = GFXLibrary.factionFlags[num + 2 - 63];
			}
			this.selectedFlag.Image = GFXLibrary.factionFlags[num];
			ColorMap[] colourMap = FactionData.getColourMap(num2, num3, num4, num5, 255);
			this.selectedFlag.ColourMap = colourMap;
			this.flagMinus2.ColourMap = colourMap;
			this.flagMinus1.ColourMap = colourMap;
			this.flagPlus1.ColourMap = colourMap;
			this.flagPlus2.ColourMap = colourMap;
			this.selectedColour1.Position = this.colours1[num2].Position;
			this.selectedColour2.Position = this.colours2[num3].Position;
			this.selectedColour3.Position = this.colours3[num4].Position;
			this.selectedColour4.Position = this.colours4[num5].Position;
			this.selectedColour1.LineColor = global::ARGBColors.Black;
			this.selectedColour2.LineColor = global::ARGBColors.Black;
			this.selectedColour3.LineColor = global::ARGBColors.Black;
			this.selectedColour4.LineColor = global::ARGBColors.Black;
			if (num2 <= 11)
			{
				if (num2 != 1 && num2 != 11)
				{
					goto IL_2C2;
				}
			}
			else if (num2 - 14 > 1 && num2 != 22 && num2 - 25 > 2)
			{
				goto IL_2C2;
			}
			this.selectedColour1.LineColor = global::ARGBColors.White;
			IL_2C2:
			if (num3 <= 11)
			{
				if (num3 != 1 && num3 != 11)
				{
					goto IL_2F5;
				}
			}
			else if (num3 - 14 > 1 && num3 != 22 && num3 - 25 > 2)
			{
				goto IL_2F5;
			}
			this.selectedColour2.LineColor = global::ARGBColors.White;
			IL_2F5:
			if (num4 <= 11)
			{
				if (num4 != 1 && num4 != 11)
				{
					goto IL_328;
				}
			}
			else if (num4 - 14 > 1 && num4 != 22 && num4 - 25 > 2)
			{
				goto IL_328;
			}
			this.selectedColour3.LineColor = global::ARGBColors.White;
			IL_328:
			if (num5 <= 11)
			{
				if (num5 != 1 && num5 != 11)
				{
					goto IL_361;
				}
			}
			else if (num5 - 14 > 1 && num5 != 22 && num5 - 25 > 2)
			{
				goto IL_361;
			}
			this.selectedColour4.LineColor = global::ARGBColors.White;
			IL_361:
			base.Invalidate();
		}

		// Token: 0x060011A4 RID: 4516 RVA: 0x0012BB00 File Offset: 0x00129D00
		private void flagInc()
		{
			if (this.clicksActive)
			{
				this.createButton.Enabled = true;
				int num = 0;
				int colour = 0;
				int colour2 = 0;
				int colour3 = 0;
				int colour4 = 0;
				FactionData.getFlagData(this.factionFlagData, ref num, ref colour, ref colour2, ref colour3, ref colour4);
				if (num == 0)
				{
					num = 1;
				}
				num++;
				if (num >= 64)
				{
					num = 1;
				}
				this.factionFlagData = FactionData.createFlagData(num, colour, colour2, colour3, colour4);
				this.updateFlags(null, 0);
			}
		}

		// Token: 0x060011A5 RID: 4517 RVA: 0x0012BB6C File Offset: 0x00129D6C
		private void flagInc2()
		{
			if (this.clicksActive)
			{
				this.createButton.Enabled = true;
				int num = 0;
				int colour = 0;
				int colour2 = 0;
				int colour3 = 0;
				int colour4 = 0;
				FactionData.getFlagData(this.factionFlagData, ref num, ref colour, ref colour2, ref colour3, ref colour4);
				if (num == 0)
				{
					num = 1;
				}
				num += 2;
				if (num >= 64)
				{
					num -= 63;
				}
				this.factionFlagData = FactionData.createFlagData(num, colour, colour2, colour3, colour4);
				this.updateFlags(null, 0);
			}
		}

		// Token: 0x060011A6 RID: 4518 RVA: 0x0012BBDC File Offset: 0x00129DDC
		private void flagDec()
		{
			if (this.clicksActive)
			{
				this.createButton.Enabled = true;
				int num = 0;
				int colour = 0;
				int colour2 = 0;
				int colour3 = 0;
				int colour4 = 0;
				FactionData.getFlagData(this.factionFlagData, ref num, ref colour, ref colour2, ref colour3, ref colour4);
				if (num == 0)
				{
					num = 1;
				}
				num--;
				if (num < 1)
				{
					num = 63;
				}
				this.factionFlagData = FactionData.createFlagData(num, colour, colour2, colour3, colour4);
				this.updateFlags(null, 0);
			}
		}

		// Token: 0x060011A7 RID: 4519 RVA: 0x0012BC48 File Offset: 0x00129E48
		private void flagDec2()
		{
			if (this.clicksActive)
			{
				this.createButton.Enabled = true;
				int num = 0;
				int colour = 0;
				int colour2 = 0;
				int colour3 = 0;
				int colour4 = 0;
				FactionData.getFlagData(this.factionFlagData, ref num, ref colour, ref colour2, ref colour3, ref colour4);
				if (num == 0)
				{
					num = 1;
				}
				num -= 2;
				if (num < 1)
				{
					num += 63;
				}
				this.factionFlagData = FactionData.createFlagData(num, colour, colour2, colour3, colour4);
				this.updateFlags(null, 0);
			}
		}

		// Token: 0x060011A8 RID: 4520 RVA: 0x0012BCB4 File Offset: 0x00129EB4
		private void colours1clicked()
		{
			if (this.clicksActive)
			{
				this.createButton.Enabled = true;
				int data = this.ClickedControl.Data;
				int flag = 0;
				int num = 0;
				int colour = 0;
				int colour2 = 0;
				int colour3 = 0;
				FactionData.getFlagData(this.factionFlagData, ref flag, ref num, ref colour, ref colour2, ref colour3);
				this.factionFlagData = FactionData.createFlagData(flag, data, colour, colour2, colour3);
				this.updateFlags(this.colours1[data], 1);
			}
		}

		// Token: 0x060011A9 RID: 4521 RVA: 0x0012BD24 File Offset: 0x00129F24
		private void colours2clicked()
		{
			if (this.clicksActive)
			{
				this.createButton.Enabled = true;
				int data = this.ClickedControl.Data;
				int flag = 0;
				int colour = 0;
				int num = 0;
				int colour2 = 0;
				int colour3 = 0;
				FactionData.getFlagData(this.factionFlagData, ref flag, ref colour, ref num, ref colour2, ref colour3);
				this.factionFlagData = FactionData.createFlagData(flag, colour, data, colour2, colour3);
				this.updateFlags(this.colours2[data], 2);
			}
		}

		// Token: 0x060011AA RID: 4522 RVA: 0x0012BD94 File Offset: 0x00129F94
		private void colours3clicked()
		{
			if (this.clicksActive)
			{
				this.createButton.Enabled = true;
				int data = this.ClickedControl.Data;
				int flag = 0;
				int colour = 0;
				int colour2 = 0;
				int num = 0;
				int colour3 = 0;
				FactionData.getFlagData(this.factionFlagData, ref flag, ref colour, ref colour2, ref num, ref colour3);
				this.factionFlagData = FactionData.createFlagData(flag, colour, colour2, data, colour3);
				this.updateFlags(this.colours3[data], 3);
			}
		}

		// Token: 0x060011AB RID: 4523 RVA: 0x0012BE04 File Offset: 0x0012A004
		private void colours4clicked()
		{
			if (this.clicksActive)
			{
				this.createButton.Enabled = true;
				int data = this.ClickedControl.Data;
				int flag = 0;
				int colour = 0;
				int colour2 = 0;
				int colour3 = 0;
				int num = 0;
				FactionData.getFlagData(this.factionFlagData, ref flag, ref colour, ref colour2, ref colour3, ref num);
				this.factionFlagData = FactionData.createFlagData(flag, colour, colour2, colour3, data);
				this.updateFlags(this.colours4[data], 4);
			}
		}

		// Token: 0x060011AC RID: 4524 RVA: 0x00013433 File Offset: 0x00011633
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x060011AD RID: 4525 RVA: 0x00013443 File Offset: 0x00011643
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x060011AE RID: 4526 RVA: 0x00013453 File Offset: 0x00011653
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x060011AF RID: 4527 RVA: 0x00013465 File Offset: 0x00011665
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x060011B0 RID: 4528 RVA: 0x00013472 File Offset: 0x00011672
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closing();
		}

		// Token: 0x060011B1 RID: 4529 RVA: 0x0001348C File Offset: 0x0001168C
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x060011B2 RID: 4530 RVA: 0x00013499 File Offset: 0x00011699
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x060011B3 RID: 4531 RVA: 0x000134A6 File Offset: 0x000116A6
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060011B4 RID: 4532 RVA: 0x0012BE74 File Offset: 0x0012A074
		private void InitializeComponent()
		{
			this.tbMotto = new TextBox();
			this.tbFactionShortName = new TextBox();
			this.tbFactionName = new TextBox();
			base.SuspendLayout();
			this.tbMotto.Location = new Point(258, 146);
			this.tbMotto.MaxLength = 49;
			this.tbMotto.Name = "tbMotto";
			this.tbMotto.Size = new Size(237, 20);
			this.tbMotto.TabIndex = 5;
			this.tbMotto.TextChanged += this.tbFactionName_TextChanged;
			this.tbFactionShortName.Location = new Point(258, 86);
			this.tbFactionShortName.MaxLength = 10;
			this.tbFactionShortName.Name = "tbFactionShortName";
			this.tbFactionShortName.Size = new Size(121, 20);
			this.tbFactionShortName.TabIndex = 4;
			this.tbFactionShortName.TextChanged += this.tbFactionName_TextChanged;
			this.tbFactionName.Location = new Point(258, 26);
			this.tbFactionName.MaxLength = 49;
			this.tbFactionName.Name = "tbFactionName";
			this.tbFactionName.Size = new Size(237, 20);
			this.tbFactionName.TabIndex = 3;
			this.tbFactionName.TextChanged += this.tbFactionName_TextChanged;
			base.AutoScaleMode = AutoScaleMode.None;
			base.Controls.Add(this.tbMotto);
			base.Controls.Add(this.tbFactionShortName);
			base.Controls.Add(this.tbFactionName);
			this.MaximumSize = new Size(992, 10000);
			this.MinimumSize = new Size(992, 566);
			base.Name = "FactionStartFactionPanel";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040017D5 RID: 6101
		public const int PANEL_ID = 47;

		// Token: 0x040017D6 RID: 6102
		public static FactionStartFactionPanel instance = null;

		// Token: 0x040017D7 RID: 6103
		public static bool StartFaction = true;

		// Token: 0x040017D8 RID: 6104
		private CustomSelfDrawPanel.CSDFill mainBackgroundImage = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x040017D9 RID: 6105
		private CustomSelfDrawPanel.CSDImage backgroundFade = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040017DA RID: 6106
		private CustomSelfDrawPanel.CSDImage bar1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040017DB RID: 6107
		private CustomSelfDrawPanel.CSDImage bar2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040017DC RID: 6108
		private CustomSelfDrawPanel.CSDImage bar3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040017DD RID: 6109
		private CustomSelfDrawPanel.CSDLabel nameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040017DE RID: 6110
		private CustomSelfDrawPanel.CSDLabel nameLabelInfo = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040017DF RID: 6111
		private CustomSelfDrawPanel.CSDLabel abbrvLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040017E0 RID: 6112
		private CustomSelfDrawPanel.CSDLabel abbrvLabelInfo = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040017E1 RID: 6113
		private CustomSelfDrawPanel.CSDLabel mottoLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040017E2 RID: 6114
		private CustomSelfDrawPanel.CSDLabel mottoLabelInfo = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040017E3 RID: 6115
		private CustomSelfDrawPanel.CSDLabel rankNeededLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040017E4 RID: 6116
		private CustomSelfDrawPanel.CSDLabel rankNeededLabelValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040017E5 RID: 6117
		private CustomSelfDrawPanel.CSDButton createButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040017E6 RID: 6118
		private CustomSelfDrawPanel.CSDButton flagPlusButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040017E7 RID: 6119
		private CustomSelfDrawPanel.CSDButton flagMinusButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040017E8 RID: 6120
		private CustomSelfDrawPanel.CSDFactionFlagImage selectedFlag = new CustomSelfDrawPanel.CSDFactionFlagImage();

		// Token: 0x040017E9 RID: 6121
		private CustomSelfDrawPanel.CSDFactionFlagImage flagMinus1 = new CustomSelfDrawPanel.CSDFactionFlagImage();

		// Token: 0x040017EA RID: 6122
		private CustomSelfDrawPanel.CSDFactionFlagImage flagMinus2 = new CustomSelfDrawPanel.CSDFactionFlagImage();

		// Token: 0x040017EB RID: 6123
		private CustomSelfDrawPanel.CSDFactionFlagImage flagPlus1 = new CustomSelfDrawPanel.CSDFactionFlagImage();

		// Token: 0x040017EC RID: 6124
		private CustomSelfDrawPanel.CSDFactionFlagImage flagPlus2 = new CustomSelfDrawPanel.CSDFactionFlagImage();

		// Token: 0x040017ED RID: 6125
		private int factionFlagData;

		// Token: 0x040017EE RID: 6126
		private CustomSelfDrawPanel.CSDFill[] colours1 = new CustomSelfDrawPanel.CSDFill[32];

		// Token: 0x040017EF RID: 6127
		private CustomSelfDrawPanel.CSDFill[] colours2 = new CustomSelfDrawPanel.CSDFill[32];

		// Token: 0x040017F0 RID: 6128
		private CustomSelfDrawPanel.CSDFill[] colours3 = new CustomSelfDrawPanel.CSDFill[32];

		// Token: 0x040017F1 RID: 6129
		private CustomSelfDrawPanel.CSDFill[] colours4 = new CustomSelfDrawPanel.CSDFill[32];

		// Token: 0x040017F2 RID: 6130
		private CustomSelfDrawPanel.CSDRectangle selectedColour1 = new CustomSelfDrawPanel.CSDRectangle();

		// Token: 0x040017F3 RID: 6131
		private CustomSelfDrawPanel.CSDRectangle selectedColour2 = new CustomSelfDrawPanel.CSDRectangle();

		// Token: 0x040017F4 RID: 6132
		private CustomSelfDrawPanel.CSDRectangle selectedColour3 = new CustomSelfDrawPanel.CSDRectangle();

		// Token: 0x040017F5 RID: 6133
		private CustomSelfDrawPanel.CSDRectangle selectedColour4 = new CustomSelfDrawPanel.CSDRectangle();

		// Token: 0x040017F6 RID: 6134
		private CustomSelfDrawPanel.CSDLabel colour1Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040017F7 RID: 6135
		private CustomSelfDrawPanel.CSDLabel colour2Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040017F8 RID: 6136
		private CustomSelfDrawPanel.CSDLabel colour3Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040017F9 RID: 6137
		private CustomSelfDrawPanel.CSDLabel colour4Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040017FA RID: 6138
		private CustomSelfDrawPanel.CSDImage inset1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040017FB RID: 6139
		private CustomSelfDrawPanel.CSDImage inset2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040017FC RID: 6140
		private CustomSelfDrawPanel.CSDImage inset3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040017FD RID: 6141
		private CustomSelfDrawPanel.CSDImage inset4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040017FE RID: 6142
		private bool clicksActive = true;

		// Token: 0x040017FF RID: 6143
		private CustomSelfDrawPanel.FactionPanelSideBar sidebar = new CustomSelfDrawPanel.FactionPanelSideBar();

		// Token: 0x04001800 RID: 6144
		private DockableControl dockableControl;

		// Token: 0x04001801 RID: 6145
		private IContainer components;

		// Token: 0x04001802 RID: 6146
		private TextBox tbMotto;

		// Token: 0x04001803 RID: 6147
		private TextBox tbFactionShortName;

		// Token: 0x04001804 RID: 6148
		private TextBox tbFactionName;
	}
}
