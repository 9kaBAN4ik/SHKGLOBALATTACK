using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x0200047B RID: 1147
	public class ScoutPopupPanel : CustomSelfDrawPanel
	{
		// Token: 0x060029AB RID: 10667 RVA: 0x002028C4 File Offset: 0x00200AC4
		public ScoutPopupPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x060029AC RID: 10668 RVA: 0x002029F0 File Offset: 0x00200BF0
		public void init(int villageID, bool reset)
		{
			Color white = global::ARGBColors.White;
			Color black = global::ARGBColors.Black;
			Color white2 = global::ARGBColors.White;
			this.m_selectedVillage = villageID;
			this.m_ownVillage = InterfaceMgr.Instance.OwnSelectedVillage;
			base.clearControls();
			this.mainBackgroundImage.Image = GFXLibrary.body_background_canvas;
			int num = 39;
			this.mainBackgroundImage.ClipRect = new Rectangle(default(Point), base.Size);
			this.mainBackgroundImage.Position = new Point(0, num);
			this.mainBackgroundImage.Size = new Size(base.Size.Width, base.Size.Height - num);
			this.mainBackgroundImage.Tile = true;
			base.addControl(this.mainBackgroundImage);
			this.backgroundBottomEdge.Image = GFXLibrary.popup_border_bottom;
			this.backgroundBottomEdge.Position = new Point(0, base.Height - 2);
			base.addControl(this.backgroundBottomEdge);
			this.backgroundRightEdge.Image = GFXLibrary.popup_border_rhs;
			this.backgroundRightEdge.Position = new Point(base.Width - 2, num);
			base.addControl(this.backgroundRightEdge);
			this.cardbar.Position = new Point(0, 4);
			this.mainBackgroundImage.addControl(this.cardbar);
			this.cardbar.init(7);
			this.gfxImage.Image = GFXLibrary.scout_screen_illustration_01;
			this.gfxImage.Position = new Point(20, 71);
			this.mainBackgroundImage.addControl(this.gfxImage);
			this.sliderImage.Position = new Point(44, 284);
			this.sliderImage.Margin = new Rectangle(32, 63, 32, 25);
			this.sliderImage.Value = 0;
			this.sliderImage.Max = 0;
			this.sliderImage.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.tracksMoved));
			this.mainBackgroundImage.addControl(this.sliderImage);
			this.sliderImage.Create(GFXLibrary.scout_screen_slider, GFXLibrary.scout_screen_slider_bar, GFXLibrary.scout_screen_slider_bar, GFXLibrary.scout_screen_slider_bar, GFXLibrary.scout_screen_slider_bar, GFXLibrary.scout_screen_slider_bar);
			this.arrowImage.Image = GFXLibrary.scout_screen_arrowbox;
			this.arrowImage.Position = new Point(238, 284);
			this.mainBackgroundImage.addControl(this.arrowImage);
			this.scoutingLabel.Text = SK.Text("ScoutPopup_Scouting_Target", "Scouting") + " '" + GameEngine.Instance.World.getVillageNameOrType(villageID) + "'";
			this.scoutingLabel.Color = white;
			this.scoutingLabel.DropShadowColor = black;
			this.scoutingLabel.Font = FontManager.GetFont("Arial", 16f, FontStyle.Regular);
			this.scoutingLabel.Position = new Point(0, 243);
			this.scoutingLabel.Size = new Size(700, 30);
			this.scoutingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundImage.addControl(this.scoutingLabel);
			if (AttackTargetsPanel.isFavourite(this.m_selectedVillage))
			{
				this.targetVillageFavourite.ImageNorm = GFXLibrary.star_market_1;
				this.targetVillageFavourite.CustomTooltipID = 2107;
			}
			else
			{
				this.targetVillageFavourite.ImageNorm = GFXLibrary.star_market_3;
				this.targetVillageFavourite.CustomTooltipID = 2018;
			}
			this.targetVillageFavourite.OverBrighten = true;
			this.targetVillageFavourite.Position = new Point(650, 244);
			this.targetVillageFavourite.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageFavouriteClicked));
			this.targetVillageFavourite.Data = 0;
			this.mainBackgroundImage.addControl(this.targetVillageFavourite);
			this.numLabel.Text = "";
			this.numLabel.Color = white;
			this.numLabel.DropShadowColor = black;
			this.numLabel.Position = new Point(63, 23);
			this.numLabel.Size = new Size(59, 24);
			this.numLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
			this.numLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.sliderImage.addControl(this.numLabel);
			this.timeLabel.Text = "00:00:00";
			this.timeLabel.Color = white;
			this.timeLabel.DropShadowColor = black;
			this.timeLabel.Position = new Point(-28, 23);
			this.timeLabel.Size = new Size(191, 24);
			this.timeLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.timeLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.arrowImage.addControl(this.timeLabel);
			int special = GameEngine.Instance.World.getSpecial(villageID);
			int num2;
			switch (special)
			{
			case 3:
			case 4:
				num2 = 24;
				goto IL_A1C;
			case 5:
			case 6:
				num2 = 25;
				goto IL_A1C;
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
				num2 = 28;
				goto IL_A1C;
			case 15:
			case 16:
			case 17:
			case 18:
				num2 = 53;
				goto IL_A1C;
			case 40:
			case 41:
			case 42:
			case 43:
			case 44:
			case 45:
			case 46:
			case 47:
			case 48:
			case 49:
			case 50:
				num2 = 54;
				goto IL_A1C;
			case 51:
			case 52:
			case 53:
			case 54:
			case 55:
			case 56:
			case 57:
			case 58:
			case 59:
			case 60:
				num2 = 55;
				goto IL_A1C;
			case 61:
			case 62:
			case 63:
			case 64:
			case 65:
			case 66:
			case 67:
			case 68:
			case 69:
			case 70:
				num2 = 56;
				goto IL_A1C;
			case 71:
			case 72:
			case 73:
			case 74:
			case 75:
			case 76:
			case 77:
			case 78:
			case 79:
			case 80:
				num2 = 57;
				goto IL_A1C;
			case 81:
			case 82:
			case 83:
			case 84:
			case 85:
			case 86:
			case 87:
			case 88:
			case 89:
			case 90:
				num2 = 58;
				goto IL_A1C;
			case 100:
				num2 = (HolidayPeriods.xmas(VillageMap.getCurrentServerTime()) ? 59 : 29);
				goto IL_A1C;
			case 106:
				num2 = 30;
				goto IL_A1C;
			case 107:
				num2 = 31;
				goto IL_A1C;
			case 108:
				num2 = 33;
				goto IL_A1C;
			case 109:
				num2 = 32;
				goto IL_A1C;
			case 112:
				num2 = 34;
				goto IL_A1C;
			case 113:
				num2 = 35;
				goto IL_A1C;
			case 114:
				num2 = 36;
				goto IL_A1C;
			case 115:
				num2 = 41;
				goto IL_A1C;
			case 116:
				num2 = 37;
				goto IL_A1C;
			case 117:
				num2 = 40;
				goto IL_A1C;
			case 118:
				num2 = 42;
				goto IL_A1C;
			case 119:
				num2 = 45;
				goto IL_A1C;
			case 121:
				num2 = 44;
				goto IL_A1C;
			case 122:
				num2 = 38;
				goto IL_A1C;
			case 123:
				num2 = 43;
				goto IL_A1C;
			case 124:
				num2 = 46;
				goto IL_A1C;
			case 125:
				num2 = 47;
				goto IL_A1C;
			case 126:
				num2 = 48;
				goto IL_A1C;
			case 128:
				num2 = 61;
				goto IL_A1C;
			case 129:
				num2 = 60;
				goto IL_A1C;
			case 130:
				num2 = 62;
				goto IL_A1C;
			case 131:
				num2 = 63;
				goto IL_A1C;
			case 132:
				num2 = 64;
				goto IL_A1C;
			case 133:
				num2 = 39;
				goto IL_A1C;
			case 200:
			case 201:
			case 202:
			case 203:
			case 204:
			case 205:
			case 206:
			case 207:
			case 208:
			case 209:
			case 210:
			case 211:
			case 212:
			case 213:
			case 214:
			case 215:
			case 216:
			case 217:
			case 218:
			case 219:
			case 220:
				num2 = 65;
				goto IL_A1C;
			}
			num2 = ((!GameEngine.Instance.World.isRegionCapital(villageID)) ? ((!GameEngine.Instance.World.isCountyCapital(villageID)) ? ((!GameEngine.Instance.World.isProvinceCapital(villageID)) ? ((!GameEngine.Instance.World.isCountryCapital(villageID)) ? GameEngine.Instance.World.getVillageSize(villageID) : 52) : 51) : 50) : 49);
			IL_A1C:
			this.targetImage.Image = GFXLibrary.scout_screen_icons[num2];
			this.targetImage.Position = new Point(181, 5);
			this.arrowImage.addControl(this.targetImage);
			switch (special)
			{
			case 106:
			case 107:
			case 108:
			case 109:
			case 112:
			case 113:
			case 114:
			case 115:
			case 116:
			case 117:
			case 118:
			case 119:
			case 121:
			case 122:
			case 123:
			case 124:
			case 125:
			case 126:
			case 128:
			case 129:
			case 130:
			case 131:
			case 132:
			case 133:
			{
				WorldMap.SpecialVillageCache specialVillageData = GameEngine.Instance.World.getSpecialVillageData(villageID, false);
				if (specialVillageData != null)
				{
					NumberFormatInfo nfi = GameEngine.NFI;
					CustomSelfDrawPanel.CSDLabel csdlabel = new CustomSelfDrawPanel.CSDLabel();
					csdlabel.Text = specialVillageData.resourceLevel.ToString("N", nfi);
					csdlabel.Position = new Point(158, 85);
					csdlabel.Size = new Size(150, 20);
					csdlabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					csdlabel.Color = white;
					csdlabel.DropShadowColor = black;
					csdlabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
					this.arrowImage.addControl(csdlabel);
					int num3 = GameEngine.Instance.LocalWorldData.ScoutResourceCarryLevel;
					int research_Foraging = (int)GameEngine.Instance.World.UserResearchData.Research_Foraging;
					num3 = CardTypes.adjustForagingLevel(GameEngine.Instance.cardsManager.UserCardData, num3);
					num3 = num3 * ResearchData.foragingResearch[research_Foraging] / 2;
					switch (special)
					{
					case 119:
					case 121:
					case 122:
					case 123:
					case 124:
					case 125:
					case 126:
					case 128:
					case 129:
					case 130:
					case 131:
					case 132:
					case 133:
						num3 /= 10;
						break;
					}
					this.m_carryLevel = num3;
					this.scoutCarryingLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
					this.scoutCarryingLabel.Color = white;
					this.scoutCarryingLabel.DropShadowColor = black;
					this.scoutCarryingLabel.Text = this.m_carryLevel.ToString("N", nfi);
					this.scoutCarryingLabel.Position = new Point(0, 90);
					this.scoutCarryingLabel.Size = new Size(this.sliderImage.Width, 20);
					this.scoutCarryingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.sliderImage.addControl(this.scoutCarryingLabel);
				}
				break;
			}
			}
			WorldData localWorldData = GameEngine.Instance.LocalWorldData;
			Point villageLocation = GameEngine.Instance.World.getVillageLocation(InterfaceMgr.Instance.OwnSelectedVillage);
			Point villageLocation2 = GameEngine.Instance.World.getVillageLocation(villageID);
			int x = villageLocation.X;
			int y = villageLocation.Y;
			int x2 = villageLocation2.X;
			int y2 = villageLocation2.Y;
			double num4 = (double)((x - x2) * (x - x2) + (y - y2) * (y - y2));
			num4 = Math.Sqrt(num4);
			num4 = (this.storedPreCardDistance = num4 * (localWorldData.ScoutsMoveSpeed * localWorldData.gamePlaySpeed * ResearchData.ScoutTimes[(int)GameEngine.Instance.World.UserResearchData.Research_Horsemanship]));
			num4 = GameEngine.Instance.World.adjustIfIslandTravel(num4, this.m_ownVillage, this.m_selectedVillage);
			num4 *= CardTypes.getScoutSpeed(GameEngine.Instance.cardsManager.UserCardData);
			string text = VillageMap.createBuildTimeString((int)num4);
			this.timeLabel.Text = text;
			this.timeLabel.CustomTooltipID = 20000;
			this.timeLabel.CustomTooltipData = (int)num4;
			this.launchButton.ImageNorm = GFXLibrary.button_with_inset_normal;
			this.launchButton.ImageOver = GFXLibrary.button_with_inset_over;
			this.launchButton.ImageClick = GFXLibrary.button_with_inset_pushed;
			this.launchButton.Position = new Point(520, 324);
			this.launchButton.Text.Text = SK.Text("ScoutPopup_Go", "Go");
			this.launchButton.Text.Font = FontManager.GetFont("Arial", 16f, FontStyle.Regular);
			this.launchButton.TextYOffset = 1;
			this.launchButton.Text.Color = global::ARGBColors.Black;
			this.launchButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.launch), "ScoutPopupPanel_launch");
			this.launchButton.Enabled = false;
			this.mainBackgroundImage.addControl(this.launchButton);
			this.scoutHonourLabel.Text = "";
			this.scoutHonourLabel.Visible = false;
			this.scoutHonourLabel.Font = FontManager.GetFont("Arial", 11f, FontStyle.Regular);
			this.scoutHonourLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.scoutHonourLabel.Color = white;
			this.scoutHonourLabel.DropShadowColor = black;
			this.scoutHonourLabel.Position = new Point(0, 410);
			this.scoutHonourLabel.Size = new Size(700, 30);
			this.mainBackgroundImage.addControl(this.scoutHonourLabel);
			if (special >= 100 && special <= 199)
			{
				this.scoutHonourLabel.Text = SK.Text("ScoutPopup_No_Honour_Stash_Out_Of_Range", "No Honour will be received, the stash is out of range.");
			}
			else if (special == 5)
			{
				this.scoutHonourLabel.Text = SK.Text("ScoutPopup_No_Honour_Wolf_Lair_Out_Of_Range", "No Honour will be received, the Wolf Lair is out of range.");
			}
			else if (special == 3)
			{
				this.scoutHonourLabel.Text = SK.Text("ScoutPopup_No_Honour_Bandit_Camp_Out_Of_Range", "No Honour will be received, the Bandit Camp is out of range.");
			}
			else if (special == 7 || special == 9 || special == 11 || special == 13)
			{
				this.scoutHonourLabel.Text = SK.Text("ScoutPopup_No_Honour_AI_castle_Out_Of_Range", "No Honour will be received, the AI Castle is out of range.");
			}
			else if (special == 15 || special == 17 || SpecialVillageTypes.IS_TREASURE_CASTLE(special))
			{
				this.scoutHonourLabel.Text = SK.Text("LaunchAttackPopup_Paladin_No_Honour", "No honour will be received for destroying this type of AI castle");
			}
			else
			{
				this.scoutHonourLabel.Text = SK.Text("ScoutPopup_No_Honour_Village_Out_Of_Range", "No Honour will be received, the village is out of range.");
			}
			this.scoutHonourLabel.Visible = (GameEngine.Instance.World.isScoutHonourOutOfRange(InterfaceMgr.Instance.OwnSelectedVillage, villageID) && (special <= 100 || special > 199));
			this.titleImage.Image = GFXLibrary.popup_title_bar;
			this.titleImage.Position = new Point(0, 0);
			base.addControl(this.titleImage);
			this.titleLabel.Text = SK.Text("OwnVillagePanel_Send_Out_Scouts", "Send Out Scouts");
			this.titleLabel.Color = Color.FromArgb(255, 255, 255);
			this.titleLabel.DropShadowColor = black;
			this.titleLabel.Position = new Point(20, 5);
			this.titleLabel.Size = new Size(base.Width, 32);
			this.titleLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Bold);
			this.titleLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.titleImage.addControl(this.titleLabel);
			this.closeButton.ImageNorm = GFXLibrary.int_button_close_normal;
			this.closeButton.ImageOver = GFXLibrary.int_button_close_over;
			this.closeButton.ImageClick = GFXLibrary.int_button_close_in;
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "ScoutPopupPanel_close");
			this.closeButton.Position = new Point(659, 5);
			this.titleImage.addControl(this.closeButton);
			if (GameEngine.Instance.World.isIslandTravel(this.m_selectedVillage, this.m_ownVillage))
			{
				int num5 = GameEngine.Instance.World.SpecialSeaConditionsData + 4;
				if (num5 < 0)
				{
					num5 = 0;
				}
				else if (num5 >= 9)
				{
					num5 = 8;
				}
				this.seaConditionsImage.Image = GFXLibrary.sea_conditions[num5];
				this.seaConditionsImage.Position = new Point(290, 340);
				this.seaConditionsImage.CustomTooltipID = 23000 + num5;
				this.mainBackgroundImage.addControl(this.seaConditionsImage);
			}
			CustomSelfDrawPanel.WikiLinkControl.init(this.titleImage, 34, new Point(609, 5));
			if (GameEngine.Instance.getVillage(this.m_ownVillage) != null)
			{
				this.onVillageLoadUpdate(this.m_ownVillage, true);
				return;
			}
			GameEngine.Instance.downloadCurrentVillage();
		}

		// Token: 0x060029AD RID: 10669 RVA: 0x00203CD4 File Offset: 0x00201ED4
		public void onVillageLoadUpdate(int villageID, bool initial)
		{
			if (this.inLaunch || this.m_ownVillage != villageID || GameEngine.Instance.getVillage(this.m_ownVillage) == null)
			{
				return;
			}
			VillageMap village = GameEngine.Instance.getVillage(this.m_ownVillage);
			if (initial)
			{
				if (village.m_numScouts > 0)
				{
					this.launchButton.Enabled = true;
					this.sliderImage.Max = village.m_numScouts - 1;
					this.sliderImage.Value = village.m_numScouts - 1;
					this.sliderEnabled = true;
				}
				else
				{
					this.sliderImage.Value = 0;
					this.sliderImage.Max = 0;
					this.sliderEnabled = false;
				}
				base.Invalidate();
				this.tracksMoved();
			}
			else if (village.m_numScouts != this.lastMax)
			{
				if (village.m_numScouts > this.lastMax)
				{
					this.sliderImage.Max = village.m_numScouts - 1;
					if (this.lastMax == 0)
					{
						this.sliderImage.Value = village.m_numScouts - 1;
					}
				}
				else
				{
					int num = this.sliderImage.Value + 1;
					if (num > village.m_numScouts)
					{
						this.sliderImage.Value = village.m_numScouts - 1;
						this.sliderImage.Max = village.m_numScouts - 1;
					}
					else
					{
						this.sliderImage.Max = village.m_numScouts - 1;
					}
				}
				if (village.m_numScouts == 0)
				{
					this.launchButton.Enabled = false;
				}
				else
				{
					this.launchButton.Enabled = true;
				}
				this.sliderEnabled = this.launchButton.Enabled;
				base.Invalidate();
				this.tracksMoved();
			}
			this.lastMax = village.m_numScouts;
		}

		// Token: 0x060029AE RID: 10670 RVA: 0x00203E7C File Offset: 0x0020207C
		public void update()
		{
			this.cardbar.update();
			this.onVillageLoadUpdate(this.m_ownVillage, false);
			this.numLabel.Text = this.numLabel.Text;
			double num = this.storedPreCardDistance * CardTypes.getScoutSpeed(GameEngine.Instance.cardsManager.UserCardData);
			num = GameEngine.Instance.World.adjustIfIslandTravel(num, this.m_ownVillage, this.m_selectedVillage);
			if ((int)num != this.timeLabel.CustomTooltipData)
			{
				string text = VillageMap.createBuildTimeString((int)num);
				this.timeLabel.Text = text;
				this.timeLabel.CustomTooltipID = 20000;
				this.timeLabel.CustomTooltipData = (int)num;
				int num2 = GameEngine.Instance.World.SpecialSeaConditionsData + 4;
				if (num2 < 0)
				{
					num2 = 0;
				}
				else if (num2 >= 9)
				{
					num2 = 8;
				}
				this.seaConditionsImage.Image = GFXLibrary.sea_conditions[num2];
				this.seaConditionsImage.CustomTooltipID = 23000 + num2;
			}
		}

		// Token: 0x060029AF RID: 10671 RVA: 0x00203F7C File Offset: 0x0020217C
		private void tracksMoved()
		{
			if (this.sliderEnabled)
			{
				this.numLabel.Text = (this.sliderImage.Value + 1).ToString();
				NumberFormatInfo nfi = GameEngine.NFI;
				this.scoutCarryingLabel.Text = (this.m_carryLevel * (this.sliderImage.Value + 1)).ToString("N", nfi);
				return;
			}
			this.numLabel.Text = "0";
			this.scoutCarryingLabel.Text = "";
		}

		// Token: 0x060029B0 RID: 10672 RVA: 0x0001EA3D File Offset: 0x0001CC3D
		private void closeClick()
		{
			InterfaceMgr.Instance.displaySelectedVillagePanel(this.m_selectedVillage, false, true, false, false);
			InterfaceMgr.Instance.closeScoutPopupWindow();
			InterfaceMgr.Instance.ParentForm.TopMost = true;
			InterfaceMgr.Instance.ParentForm.TopMost = false;
		}

		// Token: 0x060029B1 RID: 10673 RVA: 0x00204008 File Offset: 0x00202208
		private void launch()
		{
			if (this.sliderEnabled && (!this.inLaunch || (DateTime.Now - this.lastLaunchTime).TotalSeconds >= 20.0))
			{
				this.inLaunch = true;
				this.lastLaunchTime = DateTime.Now;
				int num = this.sliderImage.Value + 1;
				this.aiworld_Scout_ID_ownVillage = this.m_ownVillage;
				this.aiworld_Scout_ID_selectedVillage = this.m_selectedVillage;
				this.aiworld_Scout_ID_numScouts = num;
				RemoteServices.Instance.set_SendScouts_UserCallBack(new RemoteServices.SendScouts_UserCallBack(this.sendScoutsCallback));
				RemoteServices.Instance.SendScouts(this.m_ownVillage, this.m_selectedVillage, num);
				AllVillagesPanel.travellersChanged();
				VillageMap village = GameEngine.Instance.getVillage(this.m_ownVillage);
				if (village != null)
				{
					village.addTroops(0, 0, 0, 0, 0, -num);
				}
				this.launchButton.Enabled = false;
				this.closeButton.Enabled = false;
				CursorManager.SetCursor(CursorManager.CursorType.WaitCursor, base.ParentForm);
			}
		}

		// Token: 0x060029B2 RID: 10674 RVA: 0x0001EA7D File Offset: 0x0001CC7D
		public void cancelInterdictionCallback(CancelInterdiction_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.inLaunch = true;
				this.closeButton.Enabled = false;
				RemoteServices.Instance.SendScouts(this.aiworld_Scout_ID_ownVillage, this.aiworld_Scout_ID_selectedVillage, this.aiworld_Scout_ID_numScouts);
			}
		}

		// Token: 0x060029B3 RID: 10675 RVA: 0x00204108 File Offset: 0x00202308
		public void sendScoutsCallback(SendScouts_ReturnType returnData)
		{
			CursorManager.SetCursor(CursorManager.CursorType.Default, base.ParentForm);
			this.inLaunch = false;
			if (returnData.Success || returnData.m_errorCode != ErrorCodes.ErrorCode.ATTACKING_VILLAGE_INTERDICT_PROTECTED)
			{
				this.closeButton.Enabled = true;
				if (returnData.Success)
				{
					ArmyReturnData[] armyReturnData = new ArmyReturnData[]
					{
						returnData.armyData
					};
					GameEngine.Instance.World.doGetArmyData(armyReturnData, null, false);
					GameEngine.Instance.World.addExistingArmy(returnData.armyData.armyID);
					InterfaceMgr.Instance.displaySelectedVillagePanel(this.m_ownVillage, false, false, false, false);
					InterfaceMgr.Instance.closeScoutPopupWindow();
					if (returnData.cardData != null)
					{
						GameEngine.Instance.cardsManager.UserCardData = returnData.cardData;
					}
					AttackTargetsPanel.addRecent(returnData.targetVillage);
				}
				if (returnData.numScoutsNotTaken > 0)
				{
					VillageMap village = GameEngine.Instance.getVillage(returnData.sourceVillage);
					if (village != null)
					{
						village.addTroops(0, 0, 0, 0, 0, returnData.numScoutsNotTaken);
					}
					if (!returnData.Success)
					{
						this.launchButton.Enabled = false;
					}
				}
				if (returnData.Success)
				{
					InterfaceMgr.Instance.displaySelectedVillagePanel(this.m_selectedVillage, false, true, false, false);
					InterfaceMgr.Instance.closeScoutPopupWindow();
				}
				return;
			}
			MessageBoxButtons buts = MessageBoxButtons.YesNo;
			DialogResult dialogResult = MyMessageBox.Show(SK.Text("GameEngine_Currently_Interdited", "You are currently Interdiction protected") + "\n" + SK.Text("GameEngine_CancelProtection", "Do you wish to cancel this protection?"), SK.Text("GENERIC_Protected", "You Are Protected"), buts);
			if (dialogResult == DialogResult.Yes)
			{
				RemoteServices.Instance.set_CancelInterdiction_UserCallBack(new RemoteServices.CancelInterdiction_UserCallBack(this.cancelInterdictionCallback));
				RemoteServices.Instance.CancelInterdiction(-returnData.sourceVillage);
				return;
			}
			if (returnData.numScoutsNotTaken > 0)
			{
				VillageMap village2 = GameEngine.Instance.getVillage(returnData.sourceVillage);
				if (village2 != null)
				{
					village2.addTroops(0, 0, 0, 0, 0, returnData.numScoutsNotTaken);
				}
			}
			InterfaceMgr.Instance.closeScoutPopupWindow();
			InterfaceMgr.Instance.getMainTabBar().changeTab(9);
			InterfaceMgr.Instance.getMainTabBar().changeTab(0);
		}

		// Token: 0x060029B4 RID: 10676 RVA: 0x0020430C File Offset: 0x0020250C
		private void villageFavouriteClicked()
		{
			if (AttackTargetsPanel.isFavourite(this.m_selectedVillage))
			{
				AttackTargetsPanel.removeFavourite(this.m_selectedVillage);
				this.targetVillageFavourite.ImageNorm = GFXLibrary.star_market_3;
				this.targetVillageFavourite.CustomTooltipID = 2018;
				return;
			}
			AttackTargetsPanel.addFavourite(this.m_selectedVillage);
			this.targetVillageFavourite.ImageNorm = GFXLibrary.star_market_1;
			this.targetVillageFavourite.CustomTooltipID = 2107;
		}

		// Token: 0x060029B5 RID: 10677 RVA: 0x0001EAB6 File Offset: 0x0001CCB6
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060029B6 RID: 10678 RVA: 0x0001EAD5 File Offset: 0x0001CCD5
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.None;
		}

		// Token: 0x04003347 RID: 13127
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003348 RID: 13128
		private CardBarGDI cardbar = new CardBarGDI();

		// Token: 0x04003349 RID: 13129
		private CustomSelfDrawPanel.CSDImage titleImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400334A RID: 13130
		private CustomSelfDrawPanel.CSDLabel titleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400334B RID: 13131
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400334C RID: 13132
		private CustomSelfDrawPanel.CSDImage backgroundRightEdge = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400334D RID: 13133
		private CustomSelfDrawPanel.CSDImage backgroundBottomEdge = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400334E RID: 13134
		private CustomSelfDrawPanel.CSDImage gfxImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400334F RID: 13135
		private CustomSelfDrawPanel.CSDImage arrowImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003350 RID: 13136
		private CustomSelfDrawPanel.CSDImage targetImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003351 RID: 13137
		private CustomSelfDrawPanel.CSDButton targetVillageFavourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003352 RID: 13138
		private CustomSelfDrawPanel.CSDLabel scoutingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003353 RID: 13139
		private CustomSelfDrawPanel.CSDLabel numLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003354 RID: 13140
		private CustomSelfDrawPanel.CSDLabel timeLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003355 RID: 13141
		private CustomSelfDrawPanel.CSDLabel scoutHonourLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003356 RID: 13142
		private CustomSelfDrawPanel.CSDLabel scoutCarryingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003357 RID: 13143
		private CustomSelfDrawPanel.CSDButton launchButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003358 RID: 13144
		private CustomSelfDrawPanel.CSDTrackBar sliderImage = new CustomSelfDrawPanel.CSDTrackBar();

		// Token: 0x04003359 RID: 13145
		private CustomSelfDrawPanel.CSDImage seaConditionsImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400335A RID: 13146
		private double storedPreCardDistance;

		// Token: 0x0400335B RID: 13147
		private int m_selectedVillage = -1;

		// Token: 0x0400335C RID: 13148
		private int m_ownVillage = -1;

		// Token: 0x0400335D RID: 13149
		private int m_carryLevel;

		// Token: 0x0400335E RID: 13150
		private int lastMax = -1;

		// Token: 0x0400335F RID: 13151
		private bool sliderEnabled;

		// Token: 0x04003360 RID: 13152
		private int lastSliderAmount;

		// Token: 0x04003361 RID: 13153
		private int aiworld_Scout_ID_ownVillage = -1;

		// Token: 0x04003362 RID: 13154
		private int aiworld_Scout_ID_selectedVillage = -1;

		// Token: 0x04003363 RID: 13155
		private int aiworld_Scout_ID_numScouts = -1;

		// Token: 0x04003364 RID: 13156
		private bool inLaunch;

		// Token: 0x04003365 RID: 13157
		private DateTime lastLaunchTime = DateTime.MinValue;

		// Token: 0x04003366 RID: 13158
		private IContainer components;
	}
}
