using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;
using Upgrade;

namespace Kingdoms
{
	// Token: 0x02000487 RID: 1159
	public class SendMonkPanel : CustomSelfDrawPanel
	{
		// Token: 0x06002A2B RID: 10795 RVA: 0x0001F043 File Offset: 0x0001D243
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002A2C RID: 10796 RVA: 0x0001F062 File Offset: 0x0001D262
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.None;
		}

		// Token: 0x06002A2D RID: 10797 RVA: 0x0020B30C File Offset: 0x0020950C
		public SendMonkPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06002A2E RID: 10798 RVA: 0x0020B528 File Offset: 0x00209728
		public void init(int villageID)
		{
			this.m_selectedVillage = villageID;
			this.m_ownVillage = InterfaceMgr.Instance.OwnSelectedVillage;
			base.clearControls();
			int y = 39;
			this.mainBackgroundImage.Image = GFXLibrary.body_background_canvas;
			this.mainBackgroundImage.ClipRect = new Rectangle(default(Point), base.Size);
			this.mainBackgroundImage.Position = new Point(0, y);
			this.mainBackgroundImage.Size = base.Size;
			this.mainBackgroundImage.Tile = true;
			base.addControl(this.mainBackgroundImage);
			this.backgroundBottomEdge.Image = GFXLibrary.popup_border_bottom;
			this.backgroundBottomEdge.Position = new Point(0, base.Height - 2);
			base.addControl(this.backgroundBottomEdge);
			this.backgroundRightEdge.Image = GFXLibrary.popup_border_rhs;
			this.backgroundRightEdge.Position = new Point(base.Width - 2, y);
			base.addControl(this.backgroundRightEdge);
			this.closeButton.ImageNorm = GFXLibrary.int_button_close_normal;
			this.closeButton.ImageOver = GFXLibrary.int_button_close_over;
			this.closeButton.ImageClick = GFXLibrary.int_button_close_in;
			this.closeButton.Position = new Point(659, 5);
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "SendMonkPanel_close");
			this.titleImage.addControl(this.closeButton);
			CustomSelfDrawPanel.WikiLinkControl.init(this.titleImage, 35, new Point(609, 5));
			this.cardbar.Position = new Point(0, 4);
			this.mainBackgroundImage.addControl(this.cardbar);
			this.cardbar.init(8);
			this.gfxImage.Image = GFXLibrary.illustration_monks;
			this.gfxImage.Position = new Point(25, 77);
			this.mainBackgroundImage.addControl(this.gfxImage);
			this.sliderImage.Position = new Point(37, 304);
			this.sliderImage.Margin = new Rectangle(32, 63, 32, 25);
			this.sliderImage.Value = 0;
			this.sliderImage.Max = 0;
			this.sliderImage.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.tracksMoved));
			this.mainBackgroundImage.addControl(this.sliderImage);
			this.sliderImage.Create(GFXLibrary.monk_screen_slider, GFXLibrary.scout_screen_slider_bar, GFXLibrary.scout_screen_slider_bar, GFXLibrary.scout_screen_slider_bar, GFXLibrary.scout_screen_slider_bar, GFXLibrary.scout_screen_slider_bar);
			this.arrowImage.Image = GFXLibrary.scout_screen_arrowbox;
			this.arrowImage.Position = new Point(219, 304);
			this.mainBackgroundImage.addControl(this.arrowImage);
			this.buttonIndentImage.Image = GFXLibrary.monk_screen_buttongroup_inset;
			this.buttonIndentImage.Position = new Point(503, 77);
			this.mainBackgroundImage.addControl(this.buttonIndentImage);
			this.influenceIndent.Image = GFXLibrary.monk_screen_playerlist_inset;
			this.influenceIndent.Position = new Point(25, 77);
			this.influenceIndent.Visible = false;
			this.mainBackgroundImage.addControl(this.influenceIndent);
			this.villageActionLabel.Text = GameEngine.Instance.World.getVillageNameOrType(villageID);
			this.villageActionLabel.Color = global::ARGBColors.White;
			this.villageActionLabel.DropShadowColor = global::ARGBColors.Black;
			this.villageActionLabel.Position = new Point(36, 243);
			this.villageActionLabel.Size = new Size(430, 30);
			this.villageActionLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
			this.villageActionLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundImage.addControl(this.villageActionLabel);
			this.tooltipLabel.Text = "";
			this.tooltipLabel.Color = global::ARGBColors.White;
			this.tooltipLabel.DropShadowColor = global::ARGBColors.Black;
			this.tooltipLabel.Position = new Point(36, 270);
			this.tooltipLabel.Size = new Size(430, 32);
			this.tooltipLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.tooltipLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.mainBackgroundImage.addControl(this.tooltipLabel);
			this.costLabel.Text = SK.Text("SendMonksPanel_Faith_Points_Cost", "Faith Points Cost");
			this.costLabel.Color = global::ARGBColors.White;
			this.costLabel.DropShadowColor = global::ARGBColors.Black;
			this.costLabel.Position = new Point(452, 358);
			this.costLabel.Size = new Size(180, 32);
			this.costLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.costLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.mainBackgroundImage.addControl(this.costLabel);
			this.costValueLabel.Text = "0";
			this.costValueLabel.Color = Color.FromArgb(18, 255, 0);
			this.costValueLabel.DropShadowColor = global::ARGBColors.Black;
			this.costValueLabel.Position = new Point(635, 358);
			this.costValueLabel.Size = new Size(60, 32);
			this.costValueLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.costValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainBackgroundImage.addControl(this.costValueLabel);
			this.numLabel.Text = "";
			this.numLabel.Color = global::ARGBColors.White;
			this.numLabel.DropShadowColor = global::ARGBColors.Black;
			this.numLabel.Position = new Point(63, 23);
			this.numLabel.Size = new Size(59, 24);
			this.numLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
			this.numLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.sliderImage.addControl(this.numLabel);
			this.timeLabel.Text = "00:00:00";
			this.timeLabel.Color = global::ARGBColors.White;
			this.timeLabel.DropShadowColor = global::ARGBColors.Black;
			this.timeLabel.Position = new Point(-28, 23);
			this.timeLabel.Size = new Size(191, 24);
			this.timeLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.timeLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.arrowImage.addControl(this.timeLabel);
			this.updateButtons(-1);
			this.actionButton1.Position = new Point(48, 4);
			this.actionButton1.Data = 2;
			this.actionButton1.CustomTooltipID = 2000;
			this.actionButton1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.changeCommand), "SendMonkPanel_influence");
			this.buttonIndentImage.addControl(this.actionButton1);
			this.actionButton2.Position = new Point(14, 62);
			this.actionButton2.Data = 4;
			this.actionButton2.CustomTooltipID = 2003;
			this.actionButton2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.changeCommand), "SendMonkPanel_interdicts");
			this.buttonIndentImage.addControl(this.actionButton2);
			this.actionButton3.Position = new Point(88, 62);
			this.actionButton3.Data = 5;
			this.actionButton3.CustomTooltipID = 2004;
			this.actionButton3.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.changeCommand), "SendMonkPanel_restoration");
			this.buttonIndentImage.addControl(this.actionButton3);
			this.actionButton4.Position = new Point(14, 129);
			this.actionButton4.Data = 1;
			this.actionButton4.CustomTooltipID = 2001;
			this.actionButton4.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.changeCommand), "SendMonkPanel_blessing");
			this.buttonIndentImage.addControl(this.actionButton4);
			this.actionButton5.Position = new Point(88, 129);
			this.actionButton5.Data = 3;
			this.actionButton5.CustomTooltipID = 2002;
			this.actionButton5.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.changeCommand), "SendMonkPanel_inquistion");
			this.buttonIndentImage.addControl(this.actionButton5);
			this.actionButton6.Position = new Point(14, 196);
			this.actionButton6.Data = 6;
			this.actionButton6.CustomTooltipID = 2005;
			this.actionButton6.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.changeCommand), "SendMonkPanel_absolution");
			this.buttonIndentImage.addControl(this.actionButton6);
			this.actionButton7.Position = new Point(88, 196);
			this.actionButton7.Data = 7;
			this.actionButton7.CustomTooltipID = 2006;
			this.actionButton7.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.changeCommand), "SendMonkPanel_excommunication");
			this.buttonIndentImage.addControl(this.actionButton7);
			int special = GameEngine.Instance.World.getSpecial(villageID);
			int num;
			switch (special)
			{
			case 3:
			case 4:
				num = 24;
				goto IL_D40;
			case 5:
			case 6:
				num = 25;
				goto IL_D40;
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
				num = 28;
				goto IL_D40;
			case 15:
			case 16:
			case 17:
			case 18:
				num = 53;
				goto IL_D40;
			case 19:
			case 20:
			case 21:
			case 22:
			case 23:
			case 24:
			case 25:
			case 26:
			case 27:
			case 28:
			case 29:
			case 30:
			case 31:
			case 32:
			case 33:
			case 34:
			case 35:
			case 36:
			case 37:
			case 38:
			case 39:
			case 91:
			case 92:
			case 93:
			case 94:
			case 95:
			case 96:
			case 97:
			case 98:
			case 99:
			case 101:
			case 102:
			case 103:
			case 104:
			case 105:
			case 110:
			case 111:
			case 120:
			case 127:
			case 128:
			case 129:
			case 130:
			case 131:
			case 132:
				break;
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
				num = 54;
				goto IL_D40;
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
				num = 55;
				goto IL_D40;
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
				num = 56;
				goto IL_D40;
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
				num = 57;
				goto IL_D40;
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
				num = 58;
				goto IL_D40;
			case 100:
				num = 29;
				goto IL_D40;
			case 106:
				num = 30;
				goto IL_D40;
			case 107:
				num = 31;
				goto IL_D40;
			case 108:
				num = 33;
				goto IL_D40;
			case 109:
				num = 32;
				goto IL_D40;
			case 112:
				num = 34;
				goto IL_D40;
			case 113:
				num = 35;
				goto IL_D40;
			case 114:
				num = 36;
				goto IL_D40;
			case 115:
				num = 41;
				goto IL_D40;
			case 116:
				num = 37;
				goto IL_D40;
			case 117:
				num = 40;
				goto IL_D40;
			case 118:
				num = 42;
				goto IL_D40;
			case 119:
				num = 45;
				goto IL_D40;
			case 121:
				num = 44;
				goto IL_D40;
			case 122:
				num = 38;
				goto IL_D40;
			case 123:
				num = 43;
				goto IL_D40;
			case 124:
				num = 46;
				goto IL_D40;
			case 125:
				num = 47;
				goto IL_D40;
			case 126:
				num = 48;
				goto IL_D40;
			case 133:
				num = 39;
				goto IL_D40;
			default:
				if (special - 200 <= 20)
				{
					num = 65;
					goto IL_D40;
				}
				break;
			}
			num = ((!GameEngine.Instance.World.isRegionCapital(villageID)) ? ((!GameEngine.Instance.World.isCountyCapital(villageID)) ? ((!GameEngine.Instance.World.isProvinceCapital(villageID)) ? ((!GameEngine.Instance.World.isCountryCapital(villageID)) ? GameEngine.Instance.World.getVillageSize(villageID) : 52) : 51) : 50) : 49);
			IL_D40:
			this.targetImage.Image = GFXLibrary.scout_screen_icons[num];
			this.targetImage.Position = new Point(181, 5);
			this.arrowImage.addControl(this.targetImage);
			this.scrollArea.Position = new Point(25, 36);
			this.scrollArea.Size = new Size(385, 300);
			this.scrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(385, 300));
			this.influenceIndent.addControl(this.scrollArea);
			this.mouseWheelOverlay.Position = this.scrollArea.Position;
			this.mouseWheelOverlay.Size = this.scrollArea.Size;
			this.mouseWheelOverlay.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mouseWheelMoved));
			this.influenceIndent.addControl(this.mouseWheelOverlay);
			this.scrollBar.Position = new Point(423, 47);
			this.scrollBar.Size = new Size(32, 288);
			this.influenceIndent.addControl(this.scrollBar);
			this.scrollBar.Value = 0;
			this.scrollBar.Max = 0;
			this.scrollBar.NumVisibleLines = 300;
			this.scrollBar.Create(null, null, null, GFXLibrary.scroll_thumb_top, GFXLibrary.scroll_thumb_mid, GFXLibrary.scroll_thumb_bottom);
			this.scrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.scrollBarMoved));
			this.closeInfluenceButton.ImageNorm = GFXLibrary.int_button_close_normal;
			this.closeInfluenceButton.ImageOver = GFXLibrary.int_button_close_over;
			this.closeInfluenceButton.ImageClick = GFXLibrary.int_button_close_in;
			this.closeInfluenceButton.Position = new Point(415, 1);
			this.closeInfluenceButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeInfluenceClick), "SendMonkPanel_close_influence");
			this.influenceIndent.addControl(this.closeInfluenceButton);
			this.positiveButton.ImageNorm = GFXLibrary.monk_screen_button_array[0];
			this.positiveButton.ImageOver = GFXLibrary.monk_screen_button_array[2];
			this.positiveButton.ImageClick = GFXLibrary.monk_screen_button_array[4];
			this.positiveButton.Position = new Point(350, 6);
			this.positiveButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.positiveClick), "SendMonkPanel_influence_positive");
			this.influenceIndent.addControl(this.positiveButton);
			this.negativeButton.ImageNorm = GFXLibrary.monk_screen_button_array[1];
			this.negativeButton.ImageOver = GFXLibrary.monk_screen_button_array[3];
			this.negativeButton.ImageClick = GFXLibrary.monk_screen_button_array[5];
			this.negativeButton.Position = new Point(380, 6);
			this.negativeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.negativeClick), "SendMonkPanel_influence_negative");
			this.influenceIndent.addControl(this.negativeButton);
			this.influenceHeaderLabel.Text = SK.Text("SendMonksPanel_Select_positive", "Select Player to Positively Influence");
			this.influenceHeaderLabel.Color = global::ARGBColors.White;
			this.influenceHeaderLabel.DropShadowColor = global::ARGBColors.Black;
			this.influenceHeaderLabel.Position = new Point(15, 4);
			this.influenceHeaderLabel.Size = new Size(338, 28);
			this.influenceHeaderLabel.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.influenceHeaderLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.influenceIndent.addControl(this.influenceHeaderLabel);
			WorldData localWorldData = GameEngine.Instance.LocalWorldData;
			Point villageLocation = GameEngine.Instance.World.getVillageLocation(InterfaceMgr.Instance.OwnSelectedVillage);
			Point villageLocation2 = GameEngine.Instance.World.getVillageLocation(villageID);
			int x = villageLocation.X;
			int y2 = villageLocation.Y;
			int x2 = villageLocation2.X;
			int y3 = villageLocation2.Y;
			double num2 = (double)((x - x2) * (x - x2) + (y2 - y3) * (y2 - y3));
			num2 = Math.Sqrt(num2);
			num2 *= GameEngine.Instance.LocalWorldData.PriestMoveSpeed * GameEngine.Instance.LocalWorldData.gamePlaySpeed;
			num2 = (this.storedPreCardDistance = GameEngine.Instance.World.UserResearchData.adjustPriestTimes(num2)) * CardTypes.adjustMonkSpeed(GameEngine.Instance.cardsManager.UserCardData);
			num2 = GameEngine.Instance.World.adjustIfIslandTravel(num2, this.m_ownVillage, this.m_selectedVillage);
			string text = VillageMap.createBuildTimeString((int)num2);
			this.timeLabel.Text = text;
			this.timeLabel.CustomTooltipID = 20000;
			this.timeLabel.CustomTooltipData = (int)num2;
			this.launchButton.ImageNorm = GFXLibrary.button_with_inset_normal;
			this.launchButton.ImageOver = GFXLibrary.button_with_inset_over;
			this.launchButton.ImageClick = GFXLibrary.button_with_inset_pushed;
			this.launchButton.Position = new Point(520, 377);
			this.launchButton.Text.Text = SK.Text("ScoutPopup_Go", "Go");
			this.launchButton.Text.Font = FontManager.GetFont("Arial", 16f, FontStyle.Regular);
			this.launchButton.TextYOffset = 1;
			this.launchButton.Text.Color = global::ARGBColors.Black;
			this.launchButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.launch), "SendMonkPanel_launch");
			this.launchButton.Enabled = false;
			this.mainBackgroundImage.addControl(this.launchButton);
			this.targetCapital = false;
			bool flag = GameEngine.Instance.World.isCapital(this.m_selectedVillage);
			bool flag2 = false;
			if (flag)
			{
				this.targetCapital = true;
				if (GameEngine.Instance.World.isRegionCapital(this.m_selectedVillage))
				{
					flag2 = true;
				}
			}
			if (flag)
			{
				if (GameEngine.Instance.World.UserResearchData.Research_Confirmation > 0 && flag2)
				{
					this.actionButton5.Enabled = true;
				}
				else
				{
					this.actionButton5.Enabled = false;
				}
				if (GameEngine.Instance.World.UserResearchData.Research_Marriage > 0 && flag2)
				{
					this.actionButton4.Enabled = true;
				}
				else
				{
					this.actionButton4.Enabled = false;
				}
				if (GameEngine.Instance.World.UserResearchData.Research_Baptism > 0 && flag2)
				{
					this.actionButton3.Enabled = true;
				}
				else
				{
					this.actionButton3.Enabled = false;
				}
				if (GameEngine.Instance.World.UserResearchData.Research_Ordination <= 0 || (!flag2 && ((!GameEngine.Instance.World.SecondAgeWorld && GameEngine.Instance.LocalWorldData.Alternate_Ruleset != 1) || !GameEngine.Instance.World.isCountyCapital(this.m_selectedVillage))))
				{
					ControlForm controlForm = DX.ControlForm;
					if (controlForm == null || !controlForm.IsExclusive)
					{
						this.actionButton1.Enabled = false;
						goto IL_14A0;
					}
				}
				this.actionButton1.Enabled = true;
				IL_14A0:
				this.actionButton6.Enabled = false;
				this.actionButton7.Enabled = false;
			}
			else
			{
				this.actionButton5.Enabled = false;
				this.actionButton4.Enabled = false;
				this.actionButton3.Enabled = false;
				this.actionButton1.Enabled = false;
				if (GameEngine.Instance.World.UserResearchData.Research_Confession > 0 && this.m_ownVillage != this.m_selectedVillage)
				{
					this.actionButton6.Enabled = true;
				}
				else
				{
					this.actionButton6.Enabled = false;
				}
				if (GameEngine.Instance.World.UserResearchData.Research_ExtremeUnction > 0 && this.m_ownVillage != this.m_selectedVillage)
				{
					this.actionButton7.Enabled = true;
				}
				else
				{
					this.actionButton7.Enabled = false;
				}
			}
			if (GameEngine.Instance.LocalWorldData.Alternate_Ruleset == 1)
			{
				this.actionButton2.Enabled = false;
			}
			else if (GameEngine.Instance.World.UserResearchData.Research_Eucharist > 0)
			{
				this.actionButton2.Enabled = true;
			}
			else
			{
				this.actionButton2.Enabled = false;
			}
			this.titleImage.Image = GFXLibrary.popup_title_bar;
			this.titleImage.Position = new Point(0, 0);
			base.addControl(this.titleImage);
			this.titleLabel.Text = SK.Text("GENERIC_Send_Monks", "Send Monks");
			this.titleLabel.Color = global::ARGBColors.White;
			this.titleLabel.DropShadowColor = global::ARGBColors.Black;
			this.titleLabel.Position = new Point(20, 5);
			this.titleLabel.Size = new Size(base.Width, 32);
			this.titleLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Bold);
			this.titleLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.titleImage.addControl(this.titleLabel);
			this.closeButton.ImageNorm = GFXLibrary.int_button_close_normal;
			this.closeButton.ImageOver = GFXLibrary.int_button_close_over;
			this.closeButton.ImageClick = GFXLibrary.int_button_close_in;
			this.closeButton.Position = new Point(659, 5);
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "SendMonkPanel_close");
			this.titleImage.addControl(this.closeButton);
			if (GameEngine.Instance.World.isIslandTravel(this.m_selectedVillage, this.m_ownVillage))
			{
				int num3 = GameEngine.Instance.World.SpecialSeaConditionsData + 4;
				if (num3 < 0)
				{
					num3 = 0;
				}
				else if (num3 >= 9)
				{
					num3 = 8;
				}
				this.seaConditionsImage.Image = GFXLibrary.sea_conditions[num3];
				this.seaConditionsImage.Position = new Point(269, 360);
				this.seaConditionsImage.CustomTooltipID = 23000 + num3;
				this.mainBackgroundImage.addControl(this.seaConditionsImage);
			}
			RemoteServices.Instance.set_GetExcommunicationStatus_UserCallBack(new RemoteServices.GetExcommunicationStatus_UserCallBack(this.getExcommunicationStatusCallback));
			RemoteServices.Instance.GetExcommunicationStatus(this.m_ownVillage, this.m_selectedVillage);
			if (flag)
			{
				if (GameEngine.Instance.World.isRegionCapital(this.m_selectedVillage))
				{
					RemoteServices.Instance.set_GetParishMembersList_UserCallBack(new RemoteServices.GetParishMembersList_UserCallBack(this.getParishMembersListCallback));
					RemoteServices.Instance.GetParishMembersList(this.m_selectedVillage);
				}
				else if (GameEngine.Instance.World.isCountyCapital(this.m_selectedVillage))
				{
					RemoteServices.Instance.set_GetCountyElectionInfo_UserCallBack(new RemoteServices.GetCountyElectionInfo_UserCallBack(this.getCountyElectionInfoCallback));
					RemoteServices.Instance.GetCountyElectionInfo(this.m_selectedVillage);
				}
			}
			if (GameEngine.Instance.getVillage(this.m_ownVillage) != null)
			{
				this.onVillageLoadUpdate(this.m_ownVillage, true);
				return;
			}
			GameEngine.Instance.downloadCurrentVillage();
		}

		// Token: 0x06002A2F RID: 10799 RVA: 0x0020CDB4 File Offset: 0x0020AFB4
		public void onVillageLoadUpdate(int villageID, bool initial)
		{
			if (this.inLaunch || this.m_ownVillage != villageID || GameEngine.Instance.getVillage(this.m_ownVillage) == null)
			{
				return;
			}
			int num = 0;
			GameEngine.Instance.World.countVillagePeople(this.m_ownVillage, 4, ref num);
			if (!GameEngine.Instance.World.userResearchData.canCreateMonks())
			{
				num = 0;
			}
			this.maxMonks = num;
			if (initial)
			{
				if (num > 0)
				{
					if (!this.excommunicated)
					{
						this.launchButton.Enabled = true;
						this.launchAllowed = true;
					}
					else
					{
						this.launchButton.Enabled = false;
					}
					this.sliderImage.Max = num - 1;
					this.sliderImage.Value = 0;
					this.sliderEnabled = true;
				}
				else
				{
					this.sliderImage.Value = 0;
					this.sliderImage.Max = 0;
					this.sliderEnabled = false;
					this.launchButton.Enabled = false;
				}
				base.Invalidate();
				this.tracksMoved();
			}
			else if (num != this.lastMax)
			{
				if (num > this.lastMax)
				{
					this.sliderImage.Max = num - 1;
					if (this.lastMax <= 0)
					{
						this.sliderImage.Value = num - 1;
					}
				}
				else
				{
					int num2 = this.sliderImage.Value + 1;
					if (num2 > num)
					{
						this.sliderImage.Value = num - 1;
						this.sliderImage.Max = num - 1;
					}
					else
					{
						this.sliderImage.Max = num - 1;
					}
				}
				if (num == 0 || this.excommunicated)
				{
					this.launchButton.Enabled = false;
				}
				else
				{
					this.launchButton.Enabled = true;
					this.launchAllowed = true;
				}
				this.sliderEnabled = this.launchButton.Enabled;
				base.Invalidate();
				this.tracksMoved();
			}
			this.lastMax = num;
			this.addPlayers();
		}

		// Token: 0x06002A30 RID: 10800 RVA: 0x0020CF84 File Offset: 0x0020B184
		public void changeCommand()
		{
			if (this.ClickedControl != null)
			{
				CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
				int data = csdbutton.Data;
				this.updateButtons(data);
			}
		}

		// Token: 0x06002A31 RID: 10801 RVA: 0x0020CFB4 File Offset: 0x0020B1B4
		public void updateButtons(int type)
		{
			this.currentCommand = type;
			this.actionButton1.ImageNorm = GFXLibrary.monk_screen_button_array_75x75[0];
			this.actionButton1.ImageOver = GFXLibrary.monk_screen_button_array_75x75[7];
			this.actionButton2.ImageNorm = GFXLibrary.monk_screen_button_array_75x75[1];
			this.actionButton2.ImageOver = GFXLibrary.monk_screen_button_array_75x75[8];
			this.actionButton3.ImageNorm = GFXLibrary.monk_screen_button_array_75x75[2];
			this.actionButton3.ImageOver = GFXLibrary.monk_screen_button_array_75x75[9];
			this.actionButton4.ImageNorm = GFXLibrary.monk_screen_button_array_75x75[3];
			this.actionButton4.ImageOver = GFXLibrary.monk_screen_button_array_75x75[10];
			this.actionButton5.ImageNorm = GFXLibrary.monk_screen_button_array_75x75[4];
			this.actionButton5.ImageOver = GFXLibrary.monk_screen_button_array_75x75[11];
			this.actionButton6.ImageNorm = GFXLibrary.monk_screen_button_array_75x75[5];
			this.actionButton6.ImageOver = GFXLibrary.monk_screen_button_array_75x75[12];
			this.actionButton7.ImageNorm = GFXLibrary.monk_screen_button_array_75x75[6];
			this.actionButton7.ImageOver = GFXLibrary.monk_screen_button_array_75x75[13];
			bool visible = this.influenceIndent.Visible;
			this.influenceIndent.Visible = false;
			this.gfxImage.Visible = true;
			this.sliderImage.Visible = true;
			this.arrowImage.Visible = true;
			this.tooltipLabel.Visible = true;
			this.villageActionLabel.Visible = true;
			switch (type)
			{
			case 1:
				this.actionButton4.ImageNorm = GFXLibrary.monk_screen_button_array_75x75[17];
				this.actionButton4.ImageOver = GFXLibrary.monk_screen_button_array_75x75[24];
				this.villageActionLabel.Text = SK.Text("VillageMapPanel_Blessing", "Blessing") + " : " + GameEngine.Instance.World.getVillageNameOrType(this.m_selectedVillage);
				break;
			case 2:
			case 8:
			{
				this.actionButton1.ImageNorm = GFXLibrary.monk_screen_button_array_75x75[14];
				this.actionButton1.ImageOver = GFXLibrary.monk_screen_button_array_75x75[21];
				if ((this.currentCommand != 2 && this.currentCommand != 8) || !visible)
				{
					this.influenceIndent.Visible = true;
					this.gfxImage.Visible = false;
					this.sliderImage.Visible = false;
					this.arrowImage.Visible = false;
					this.tooltipLabel.Visible = false;
					this.villageActionLabel.Visible = false;
				}
				if (this.positiveInfluence)
				{
					this.villageActionLabel.Text = SK.Text("SendMonksPanel_Positive_Influence", "Positive Influence") + " : " + GameEngine.Instance.World.getVillageNameOrType(this.m_selectedVillage);
					this.influenceHeaderLabel.Text = SK.Text("SendMonksPanel_Select_positive", "Select Player to Positively Influence");
				}
				else
				{
					this.villageActionLabel.Text = SK.Text("SendMonksPanel_Negative_Influencs", "Negative Influence") + " : " + GameEngine.Instance.World.getVillageNameOrType(this.m_selectedVillage);
					this.influenceHeaderLabel.Text = SK.Text("SendMonksPanel_Select_negative", "Select Player to Negatively Influence");
				}
				int num = this.sliderImage.Value + 1;
				if (this.maxMonks == 0)
				{
					num = 0;
				}
				int influenceMultipier = CardTypes.getInfluenceMultipier(GameEngine.Instance.cardsManager.UserCardData);
				int num2 = influenceMultipier * num;
				CustomSelfDrawPanel.CSDLabel csdlabel = this.influenceHeaderLabel;
				csdlabel.Text = csdlabel.Text + " (" + num2.ToString() + " ";
				if (num2 != 1)
				{
					CustomSelfDrawPanel.CSDLabel csdlabel2 = this.influenceHeaderLabel;
					csdlabel2.Text += SK.Text("SendMonksPanel_X_Votes", "votes");
				}
				else
				{
					CustomSelfDrawPanel.CSDLabel csdlabel3 = this.influenceHeaderLabel;
					csdlabel3.Text += SK.Text("SendMonksPanel_X_Vote", "vote");
				}
				CustomSelfDrawPanel.CSDLabel csdlabel4 = this.influenceHeaderLabel;
				csdlabel4.Text += ")";
				break;
			}
			case 3:
				this.actionButton5.ImageNorm = GFXLibrary.monk_screen_button_array_75x75[18];
				this.actionButton5.ImageOver = GFXLibrary.monk_screen_button_array_75x75[25];
				this.villageActionLabel.Text = SK.Text("VillageMapPanel_Inquisition", "Inquisition") + " : " + GameEngine.Instance.World.getVillageNameOrType(this.m_selectedVillage);
				break;
			case 4:
				this.actionButton2.ImageNorm = GFXLibrary.monk_screen_button_array_75x75[15];
				this.actionButton2.ImageOver = GFXLibrary.monk_screen_button_array_75x75[22];
				this.villageActionLabel.Text = SK.Text("SendMonksPanel_Interdiction", "Interdiction") + " : " + GameEngine.Instance.World.getVillageNameOrType(this.m_selectedVillage);
				break;
			case 5:
				this.actionButton3.ImageNorm = GFXLibrary.monk_screen_button_array_75x75[16];
				this.actionButton3.ImageOver = GFXLibrary.monk_screen_button_array_75x75[23];
				this.villageActionLabel.Text = SK.Text("SendMonksPanel_Restoration", "Restoration") + " : " + GameEngine.Instance.World.getVillageNameOrType(this.m_selectedVillage);
				break;
			case 6:
				this.actionButton6.ImageNorm = GFXLibrary.monk_screen_button_array_75x75[19];
				this.actionButton6.ImageOver = GFXLibrary.monk_screen_button_array_75x75[26];
				this.villageActionLabel.Text = SK.Text("SendMonksPanel_Absolution", "Absolution") + " : " + GameEngine.Instance.World.getVillageNameOrType(this.m_selectedVillage);
				break;
			case 7:
				this.actionButton7.ImageNorm = GFXLibrary.monk_screen_button_array_75x75[20];
				this.actionButton7.ImageOver = GFXLibrary.monk_screen_button_array_75x75[27];
				this.villageActionLabel.Text = SK.Text("SendMonksPanel_Excommnunication", "Excommunication") + " : " + GameEngine.Instance.World.getVillageNameOrType(this.m_selectedVillage);
				break;
			}
			this.updatePointsCost();
		}

		// Token: 0x06002A32 RID: 10802 RVA: 0x0020D62C File Offset: 0x0020B82C
		private void updatePointsCost()
		{
			int num = 0;
			int num2 = this.sliderImage.Value + 1;
			if (this.maxMonks == 0)
			{
				num2 = 0;
			}
			NumberFormatInfo nfi = GameEngine.NFI;
			switch (this.currentCommand)
			{
			case 1:
				num = GameEngine.Instance.LocalWorldData.MonkCommandPointsCost_Blessings;
				if (!this.excommunicated)
				{
					int num3 = (int)GameEngine.Instance.World.UserResearchData.Research_Marriage;
					if (num3 < 1)
					{
						num3 = 1;
					}
					double num4 = (double)ResearchData.blessingTimes[num3];
					num4 *= CardTypes.getBlessingMultipier(GameEngine.Instance.cardsManager.UserCardData);
					this.tooltipLabel.Text = string.Concat(new string[]
					{
						SK.Text("SendMonksPanel_Increase_Popularity", "Increase Popularity within the Parish by :"),
						num2.ToString(),
						" (",
						SK.Text("TOOLTIP_CARD_DURATION", "Duration"),
						" : ",
						num4.ToString("N", nfi),
						" ",
						SK.Text("ResearchEffect_X_Hours", "hours"),
						")"
					});
				}
				break;
			case 2:
			case 8:
				num = GameEngine.Instance.LocalWorldData.MonkCommandPointsCost_Influence;
				if (GameEngine.Instance.World.isCountyCapital(this.m_selectedVillage))
				{
					num *= 2;
				}
				if (!this.excommunicated)
				{
					int influenceMultipier = CardTypes.getInfluenceMultipier(GameEngine.Instance.cardsManager.UserCardData);
					int num5 = influenceMultipier * num2;
					if (num5 != 1)
					{
						this.tooltipLabel.Text = string.Concat(new string[]
						{
							SK.Text("SendMonksPanel_Send_Influence", "Influence Election by :"),
							" ",
							num5.ToString(),
							" ",
							SK.Text("SendMonksPanel_X_Votes", "votes")
						});
					}
					else
					{
						this.tooltipLabel.Text = string.Concat(new string[]
						{
							SK.Text("SendMonksPanel_Send_Influence", "Influence Election by :"),
							" ",
							num5.ToString(),
							" ",
							SK.Text("SendMonksPanel_X_Vote", "vote")
						});
					}
				}
				break;
			case 3:
				num = GameEngine.Instance.LocalWorldData.MonkCommandPointsCost_Inquisition;
				if (!this.excommunicated)
				{
					int num6 = (int)GameEngine.Instance.World.UserResearchData.Research_Confirmation;
					if (num6 < 1)
					{
						num6 = 1;
					}
					double num7 = (double)ResearchData.confirmationTimes[num6];
					num7 *= CardTypes.getInquisitionMultipier(GameEngine.Instance.cardsManager.UserCardData);
					this.tooltipLabel.Text = string.Concat(new string[]
					{
						SK.Text("SendMonksPanel_Descrease_Popularity", "Decrease Popularity within the Parish by :"),
						num2.ToString(),
						" (",
						SK.Text("TOOLTIP_CARD_DURATION", "Duration"),
						" : ",
						num7.ToString("N", nfi),
						" ",
						SK.Text("ResearchEffect_X_Hours", "hours"),
						")"
					});
				}
				break;
			case 4:
				num = GameEngine.Instance.LocalWorldData.MonkCommandPointsCost_Interdicts;
				if (!this.excommunicated)
				{
					int currentLevel = num2 * 4;
					currentLevel = CardTypes.adjustInterdictionLevel(GameEngine.Instance.cardsManager.UserCardData, currentLevel);
					this.tooltipLabel.Text = string.Concat(new string[]
					{
						SK.Text("SendMonksPanel_Protect", "Protect the Village from attack for :"),
						" ",
						currentLevel.ToString(),
						" ",
						SK.Text("ResearchEffect_X_Hours", "hours")
					});
				}
				num = ((!this.targetCapital) ? TradingCalcs.adjustInterdictionCostByTargetRank(num, this.targetUserRank, GameEngine.Instance.World.SecondAgeWorld) : (num * 10));
				break;
			case 5:
				num = GameEngine.Instance.LocalWorldData.MonkCommandPointsCost_Restoration;
				if (!this.excommunicated)
				{
					int num8 = (int)GameEngine.Instance.World.UserResearchData.Research_Baptism;
					if (num8 < 1)
					{
						num8 = 1;
					}
					int currentLevel2 = num2 * ResearchData.baptismRestoreAmount[num8];
					currentLevel2 = CardTypes.adjustRestorationLevel(GameEngine.Instance.cardsManager.UserCardData, currentLevel2);
					this.tooltipLabel.Text = SK.Text("SendMonksPanel_Remove_Disease", "Points of Disease healed :") + " " + currentLevel2.ToString();
				}
				break;
			case 6:
				num = GameEngine.Instance.LocalWorldData.MonkCommandPointsCost_Absolution;
				if (!this.excommunicated)
				{
					int num9 = (int)GameEngine.Instance.World.UserResearchData.Research_Confession;
					if (num9 < 1)
					{
						num9 = 1;
					}
					double currentLevel3 = (double)(ResearchData.confessionTimes[num9] * num2);
					currentLevel3 = CardTypes.adjustAbsolutionLevel(GameEngine.Instance.cardsManager.UserCardData, currentLevel3);
					this.tooltipLabel.Text = string.Concat(new string[]
					{
						SK.Text("SendMonksPanel_Reduce_Excommunication", "Reduce Excommunication Time in Village by :"),
						" ",
						currentLevel3.ToString("N", nfi),
						" ",
						SK.Text("ResearchEffect_X_Hours", "hours")
					});
				}
				break;
			case 7:
				num = GameEngine.Instance.LocalWorldData.MonkCommandPointsCost_Excommunication;
				if (!this.excommunicated)
				{
					int num10 = (int)GameEngine.Instance.World.UserResearchData.Research_ExtremeUnction;
					if (num10 < 1)
					{
						num10 = 1;
					}
					double currentLevel4 = (double)(ResearchData.extremeUnctionTimes[num10] * num2);
					currentLevel4 = CardTypes.adjustExcommunicationLevel(GameEngine.Instance.cardsManager.UserCardData, currentLevel4);
					this.tooltipLabel.Text = string.Concat(new string[]
					{
						SK.Text("SendMonksPanel_Remove_Powers", "Remove Church powers from the Village for :"),
						" ",
						currentLevel4.ToString("N", nfi),
						" ",
						SK.Text("ResearchEffect_X_Hours", "hours")
					});
				}
				break;
			}
			num = (this.currentPointsCost = num * num2);
			this.costValueLabel.Text = num.ToString();
			if ((double)num > GameEngine.Instance.World.getCurrentFaithPoints())
			{
				this.costValueLabel.Color = Color.FromArgb(252, 0, 12);
				this.launchButton.Enabled = false;
				return;
			}
			this.costValueLabel.Color = Color.FromArgb(18, 255, 0);
			if (this.launchAllowed && num > 0 && !this.excommunicated)
			{
				this.launchButton.Enabled = true;
				return;
			}
			this.launchButton.Enabled = false;
		}

		// Token: 0x06002A33 RID: 10803 RVA: 0x0020DCC0 File Offset: 0x0020BEC0
		public void update()
		{
			this.cardbar.update();
			this.onVillageLoadUpdate(this.m_ownVillage, false);
			this.numLabel.Text = this.numLabel.Text;
			if (this.excommunicated)
			{
				DateTime currentServerTime = VillageMap.getCurrentServerTime();
				int num = (int)(this.excommunicationTime - currentServerTime).TotalSeconds;
				if (num < -5)
				{
					this.excommunicated = false;
					this.init(this.m_selectedVillage);
				}
				else
				{
					if (num < 0)
					{
						num = 0;
					}
					this.tooltipLabel.Text = string.Concat(new string[]
					{
						SK.Text("SendMonksPanel_You_Are_Excommunicated", "You are Excommunicated, you cannot issue any commands."),
						" ",
						SK.Text("SendMonksPanel_Excommunication_Expires_in", "Excommunication Expires in"),
						" : ",
						VillageMap.createBuildTimeString(num)
					});
				}
			}
			double num2 = this.storedPreCardDistance * CardTypes.adjustMonkSpeed(GameEngine.Instance.cardsManager.UserCardData);
			num2 = GameEngine.Instance.World.adjustIfIslandTravel(num2, this.m_ownVillage, this.m_selectedVillage);
			if ((int)num2 != this.timeLabel.CustomTooltipData)
			{
				string text = VillageMap.createBuildTimeString((int)num2);
				this.timeLabel.Text = text;
				this.timeLabel.CustomTooltipData = (int)num2;
				int num3 = GameEngine.Instance.World.SpecialSeaConditionsData + 4;
				if (num3 < 0)
				{
					num3 = 0;
				}
				else if (num3 >= 9)
				{
					num3 = 8;
				}
				this.seaConditionsImage.Image = GFXLibrary.sea_conditions[num3];
				this.seaConditionsImage.CustomTooltipID = 23000 + num3;
			}
		}

		// Token: 0x06002A34 RID: 10804 RVA: 0x0020DE54 File Offset: 0x0020C054
		private void tracksMoved()
		{
			if (this.sliderEnabled)
			{
				this.numLabel.Text = (this.sliderImage.Value + 1).ToString();
			}
			else
			{
				this.numLabel.Text = "0";
			}
			this.updatePointsCost();
		}

		// Token: 0x06002A35 RID: 10805 RVA: 0x0001F076 File Offset: 0x0001D276
		private void closeClick()
		{
			InterfaceMgr.Instance.displaySelectedVillagePanel(this.m_selectedVillage, false, true, false, false);
			InterfaceMgr.Instance.closeSendMonkWindow();
			InterfaceMgr.Instance.ParentForm.TopMost = true;
			InterfaceMgr.Instance.ParentForm.TopMost = false;
		}

		// Token: 0x06002A36 RID: 10806 RVA: 0x0020DEA4 File Offset: 0x0020C0A4
		private void launch()
		{
			if (this.sliderEnabled && (!this.inLaunch || (DateTime.Now - this.lastLaunchTime).TotalSeconds >= 20.0))
			{
				this.inLaunch = true;
				this.lastLaunchTime = DateTime.Now;
				if (this.sendMonks())
				{
					this.launchButton.Enabled = false;
					this.closeButton.Enabled = false;
					CursorManager.SetCursor(CursorManager.CursorType.WaitCursor, base.ParentForm);
					return;
				}
				this.inLaunch = false;
			}
		}

		// Token: 0x06002A37 RID: 10807 RVA: 0x0020DF2C File Offset: 0x0020C12C
		public bool sendMonks()
		{
			int num = this.sliderImage.Value + 1;
			if (num <= 0)
			{
				return false;
			}
			int data = -1;
			if (this.currentCommand == 2 && this.votedUser < 0)
			{
				return false;
			}
			if (this.currentCommand == 2)
			{
				if (!this.positiveInfluence)
				{
					this.currentCommand = 8;
				}
				data = this.votedUser;
			}
			if (this.currentCommand == 2)
			{
				using (List<ParishMember>.Enumerator enumerator = this.parishMembers.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ParishMember parishMember = enumerator.Current;
						if (parishMember.userID == this.votedUser)
						{
							if (parishMember.numVotesReceived + num <= this.voteCap)
							{
								break;
							}
							MessageBoxButtons buts = MessageBoxButtons.YesNo;
							DialogResult dialogResult = MyMessageBox.Show(SK.Text("SendMonksPanel_Are_You_Sure_positive", "Are you sure? This Positive Influence may waste monks."), SK.Text("SendMonksPanel_Confirm_Influence", "Confirm Influence"), buts);
							if (dialogResult == DialogResult.Yes)
							{
								break;
							}
							return false;
						}
					}
					goto IL_177;
				}
			}
			if (this.currentCommand == 8)
			{
				foreach (ParishMember parishMember2 in this.parishMembers)
				{
					if (parishMember2.userID == this.votedUser)
					{
						if (parishMember2.numVotesReceived - num >= 0)
						{
							break;
						}
						MessageBoxButtons buts2 = MessageBoxButtons.YesNo;
						DialogResult dialogResult2 = MyMessageBox.Show(SK.Text("SendMonksPanel_Are_You_Sure_Negative", "Are you sure? This Negative Influence may waste monks."), SK.Text("SendMonksPanel_Confirm_Influence", "Confirm Influence"), buts2);
						if (dialogResult2 == DialogResult.Yes)
						{
							break;
						}
						return false;
					}
				}
			}
			IL_177:
			RemoteServices.Instance.set_SendPeople_UserCallBack(new RemoteServices.SendPeople_UserCallBack(this.sendPeopleCallback));
			RemoteServices.Instance.SendPeople(this.m_ownVillage, this.m_selectedVillage, 4, num, this.currentCommand, data);
			AllVillagesPanel.travellersChanged();
			return true;
		}

		// Token: 0x06002A38 RID: 10808 RVA: 0x0020E10C File Offset: 0x0020C30C
		public void sendPeopleCallback(SendPeople_ReturnType returnData)
		{
			try
			{
				if (returnData.Success)
				{
					GameEngine.Instance.World.importOrphanedPeople(returnData.people, returnData.currentTime, -2);
					GameEngine.Instance.World.setFaithPointsData(returnData.currentFaithPointsLevel, returnData.currentFaithPointsRate);
					InterfaceMgr.Instance.getMainTabBar().changeTab(9);
					InterfaceMgr.Instance.getMainTabBar().changeTab(0);
					InterfaceMgr.Instance.displaySelectedVillagePanel(this.m_selectedVillage, false, true, false, false);
					InterfaceMgr.Instance.closeMonksPanel();
				}
				else
				{
					CursorManager.SetCursor(CursorManager.CursorType.Default, base.ParentForm);
					if (returnData.m_errorCode == ErrorCodes.ErrorCode.PEOPLE_INTERDICT_RANK_TOO_HIGH)
					{
						MyMessageBox.Show(SK.Text("SendMonksPanel_Rank_Too_High", "The Target Village Rank is too high."), SK.Text("GENERIC_Error", "Error"));
					}
					this.inLaunch = false;
					this.closeButton.Enabled = true;
					this.updatePointsCost();
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06002A39 RID: 10809 RVA: 0x0020E204 File Offset: 0x0020C404
		public void getExcommunicationStatusCallback(GetExcommunicationStatus_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.targetUserRank = returnData.targetUserRank;
				this.excommunicated = returnData.excommunicated;
				this.excommunicationTime = returnData.excommunicationTime;
				if (this.excommunicated)
				{
					this.launchButton.Enabled = false;
					this.updateButtons(-1);
					this.tooltipLabel.Text = SK.Text("SendMonksPanel_You_Are_Excommunicated", "You are Excommunicated, you cannot issue any commands.") + " " + SK.Text("SendMonksPanel_Excommunication_Expires_in", "Excommunication Expires in") + " :";
				}
			}
		}

		// Token: 0x06002A3A RID: 10810 RVA: 0x0020E290 File Offset: 0x0020C490
		public void getParishMembersListCallback(GetParishMembersList_ReturnType returnData)
		{
			if (returnData.Success)
			{
				if (this.parishMembers == null)
				{
					this.parishMembers = new List<ParishMember>();
				}
				else
				{
					this.parishMembers.Clear();
				}
				if (returnData.parishMembers != null)
				{
					this.parishMembers.AddRange(returnData.parishMembers);
				}
				this.parishMembers.Sort(this.parishMemberComparer);
				if (this.parishMembers.Count > 0)
				{
					this.votedUser = this.parishMembers[0].userID;
				}
				this.voteCap = returnData.voteCap;
				this.addPlayers();
			}
		}

		// Token: 0x06002A3B RID: 10811 RVA: 0x0020E32C File Offset: 0x0020C52C
		public void getCountyElectionInfoCallback(GetCountyElectionInfo_ReturnType returnData)
		{
			if (returnData.Success)
			{
				if (this.parishMembers == null)
				{
					this.parishMembers = new List<ParishMember>();
				}
				else
				{
					this.parishMembers.Clear();
				}
				if (returnData.countyMembers != null)
				{
					this.parishMembers.AddRange(returnData.countyMembers);
				}
				this.parishMembers.Sort(this.parishMemberComparer);
				if (this.parishMembers.Count > 0)
				{
					this.votedUser = this.parishMembers[0].userID;
				}
				this.voteCap = returnData.voteCap;
				this.addPlayers();
			}
		}

		// Token: 0x06002A3C RID: 10812 RVA: 0x0020E3C8 File Offset: 0x0020C5C8
		public void addPlayers()
		{
			this.scrollArea.clearControls();
			this.lineList.Clear();
			int num = 0;
			this.scrollBar.Visible = false;
			if (this.parishMembers != null)
			{
				foreach (ParishMember parishMember in this.parishMembers)
				{
					if (num != 0)
					{
						CustomSelfDrawPanel.CSDLine csdline = new CustomSelfDrawPanel.CSDLine();
						csdline.Position = new Point(0, num - 1);
						csdline.LineColor = Color.FromArgb(60, 60, 60);
						csdline.Size = new Size(385, 0);
						this.scrollArea.addControl(csdline);
					}
					SendMonkPanel.MonkVoteLine monkVoteLine = new SendMonkPanel.MonkVoteLine();
					monkVoteLine.Position = new Point(0, num);
					monkVoteLine.init(parishMember.userName, parishMember.userID, parishMember.rank, parishMember.points, true, parishMember.numSpareVotes, parishMember.numVotesReceived, parishMember.factionID, this.votedUser, this);
					this.scrollArea.addControl(monkVoteLine);
					num += monkVoteLine.Height;
					this.lineList.Add(monkVoteLine);
				}
				if (num > 300)
				{
					this.scrollBar.Visible = true;
					this.scrollBar.Max = num - 300;
				}
			}
			this.scrollArea.invalidate();
			this.influenceIndent.invalidate();
		}

		// Token: 0x06002A3D RID: 10813 RVA: 0x0020E53C File Offset: 0x0020C73C
		private void scrollBarMoved()
		{
			int value = this.scrollBar.Value;
			this.scrollArea.Position = new Point(this.scrollArea.X, 36 - value);
			this.scrollArea.ClipRect = new Rectangle(this.scrollArea.ClipRect.X, value, this.scrollArea.ClipRect.Width, this.scrollArea.ClipRect.Height);
			this.scrollArea.invalidate();
			this.influenceIndent.invalidate();
		}

		// Token: 0x06002A3E RID: 10814 RVA: 0x0001F0B6 File Offset: 0x0001D2B6
		private void mouseWheelMoved(int delta)
		{
			if (delta < 0)
			{
				this.scrollBar.scrollDown(6);
				return;
			}
			if (delta > 0)
			{
				this.scrollBar.scrollUp(6);
			}
		}

		// Token: 0x06002A3F RID: 10815 RVA: 0x0020E5D4 File Offset: 0x0020C7D4
		private void positiveClick()
		{
			this.positiveInfluence = true;
			this.villageActionLabel.Text = SK.Text("SendMonksPanel_Positive_Influence", "Positive Influence") + " : " + GameEngine.Instance.World.getVillageNameOrType(this.m_selectedVillage);
			this.influenceHeaderLabel.Text = SK.Text("SendMonksPanel_Select_positive", "Select Player to Positively Influence");
			int num = this.sliderImage.Value + 1;
			if (this.maxMonks == 0)
			{
				num = 0;
			}
			int influenceMultipier = CardTypes.getInfluenceMultipier(GameEngine.Instance.cardsManager.UserCardData);
			int num2 = influenceMultipier * num;
			CustomSelfDrawPanel.CSDLabel csdlabel = this.influenceHeaderLabel;
			csdlabel.Text = csdlabel.Text + " (" + num2.ToString() + " ";
			if (num2 != 1)
			{
				CustomSelfDrawPanel.CSDLabel csdlabel2 = this.influenceHeaderLabel;
				csdlabel2.Text += SK.Text("SendMonksPanel_X_Votes", "votes");
			}
			else
			{
				CustomSelfDrawPanel.CSDLabel csdlabel3 = this.influenceHeaderLabel;
				csdlabel3.Text += SK.Text("SendMonksPanel_X_Vote", "vote");
			}
			CustomSelfDrawPanel.CSDLabel csdlabel4 = this.influenceHeaderLabel;
			csdlabel4.Text += ")";
		}

		// Token: 0x06002A40 RID: 10816 RVA: 0x0020E700 File Offset: 0x0020C900
		private void negativeClick()
		{
			this.positiveInfluence = false;
			this.villageActionLabel.Text = SK.Text("SendMonksPanel_Negative_Influence", "Negative Influence") + " : " + GameEngine.Instance.World.getVillageNameOrType(this.m_selectedVillage);
			this.influenceHeaderLabel.Text = SK.Text("SendMonksPanel_Select_negative", "Select Player to Negatively Influence");
			int num = this.sliderImage.Value + 1;
			if (this.maxMonks == 0)
			{
				num = 0;
			}
			int influenceMultipier = CardTypes.getInfluenceMultipier(GameEngine.Instance.cardsManager.UserCardData);
			int num2 = influenceMultipier * num;
			CustomSelfDrawPanel.CSDLabel csdlabel = this.influenceHeaderLabel;
			csdlabel.Text = csdlabel.Text + " (" + num2.ToString() + " ";
			if (num2 != 1)
			{
				CustomSelfDrawPanel.CSDLabel csdlabel2 = this.influenceHeaderLabel;
				csdlabel2.Text += SK.Text("SendMonksPanel_X_Votes", "votes");
			}
			else
			{
				CustomSelfDrawPanel.CSDLabel csdlabel3 = this.influenceHeaderLabel;
				csdlabel3.Text += SK.Text("SendMonksPanel_X_Vote", "vote");
			}
			CustomSelfDrawPanel.CSDLabel csdlabel4 = this.influenceHeaderLabel;
			csdlabel4.Text += ")";
		}

		// Token: 0x06002A41 RID: 10817 RVA: 0x0001F0D9 File Offset: 0x0001D2D9
		private void closeInfluenceClick()
		{
			this.updateButtons(this.currentCommand);
		}

		// Token: 0x06002A42 RID: 10818 RVA: 0x0020E82C File Offset: 0x0020CA2C
		public void radioClicked(int clickedUserID)
		{
			this.votedUser = clickedUserID;
			foreach (SendMonkPanel.MonkVoteLine monkVoteLine in this.lineList)
			{
				monkVoteLine.setState(this.votedUser);
			}
		}

		// Token: 0x040033E0 RID: 13280
		private IContainer components;

		// Token: 0x040033E1 RID: 13281
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040033E2 RID: 13282
		private CardBarGDI cardbar = new CardBarGDI();

		// Token: 0x040033E3 RID: 13283
		private CustomSelfDrawPanel.CSDImage titleImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040033E4 RID: 13284
		private CustomSelfDrawPanel.CSDLabel titleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040033E5 RID: 13285
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040033E6 RID: 13286
		private CustomSelfDrawPanel.CSDImage backgroundRightEdge = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040033E7 RID: 13287
		private CustomSelfDrawPanel.CSDImage backgroundBottomEdge = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040033E8 RID: 13288
		private CustomSelfDrawPanel.CSDImage gfxImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040033E9 RID: 13289
		private CustomSelfDrawPanel.CSDImage arrowImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040033EA RID: 13290
		private CustomSelfDrawPanel.CSDImage targetImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040033EB RID: 13291
		private CustomSelfDrawPanel.CSDImage buttonIndentImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040033EC RID: 13292
		private CustomSelfDrawPanel.CSDImage influenceIndent = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040033ED RID: 13293
		private CustomSelfDrawPanel.CSDLabel villageActionLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040033EE RID: 13294
		private CustomSelfDrawPanel.CSDLabel numLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040033EF RID: 13295
		private CustomSelfDrawPanel.CSDLabel timeLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040033F0 RID: 13296
		private CustomSelfDrawPanel.CSDLabel tooltipLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040033F1 RID: 13297
		private CustomSelfDrawPanel.CSDLabel costLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040033F2 RID: 13298
		private CustomSelfDrawPanel.CSDLabel costValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040033F3 RID: 13299
		private CustomSelfDrawPanel.CSDButton launchButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040033F4 RID: 13300
		private CustomSelfDrawPanel.CSDTrackBar sliderImage = new CustomSelfDrawPanel.CSDTrackBar();

		// Token: 0x040033F5 RID: 13301
		private CustomSelfDrawPanel.CSDButton actionButton1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040033F6 RID: 13302
		private CustomSelfDrawPanel.CSDButton actionButton2 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040033F7 RID: 13303
		private CustomSelfDrawPanel.CSDButton actionButton3 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040033F8 RID: 13304
		private CustomSelfDrawPanel.CSDButton actionButton4 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040033F9 RID: 13305
		private CustomSelfDrawPanel.CSDButton actionButton5 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040033FA RID: 13306
		private CustomSelfDrawPanel.CSDButton actionButton6 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040033FB RID: 13307
		private CustomSelfDrawPanel.CSDButton actionButton7 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040033FC RID: 13308
		private CustomSelfDrawPanel.CSDVertScrollBar scrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x040033FD RID: 13309
		private CustomSelfDrawPanel.CSDArea scrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040033FE RID: 13310
		private CustomSelfDrawPanel.CSDControl mouseWheelOverlay = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x040033FF RID: 13311
		private CustomSelfDrawPanel.CSDButton closeInfluenceButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003400 RID: 13312
		private CustomSelfDrawPanel.CSDButton positiveButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003401 RID: 13313
		private CustomSelfDrawPanel.CSDButton negativeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003402 RID: 13314
		private CustomSelfDrawPanel.CSDLabel influenceHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003403 RID: 13315
		private CustomSelfDrawPanel.CSDImage seaConditionsImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003404 RID: 13316
		private int m_selectedVillage = -1;

		// Token: 0x04003405 RID: 13317
		private int m_ownVillage = -1;

		// Token: 0x04003406 RID: 13318
		private bool targetCapital;

		// Token: 0x04003407 RID: 13319
		private bool excommunicated;

		// Token: 0x04003408 RID: 13320
		private int targetUserRank = -1;

		// Token: 0x04003409 RID: 13321
		private DateTime excommunicationTime = DateTime.MinValue;

		// Token: 0x0400340A RID: 13322
		private int voteCap = 100000;

		// Token: 0x0400340B RID: 13323
		private int votedUser = -1;

		// Token: 0x0400340C RID: 13324
		private int currentPointsCost;

		// Token: 0x0400340D RID: 13325
		private bool positiveInfluence = true;

		// Token: 0x0400340E RID: 13326
		private List<ParishMember> parishMembers = new List<ParishMember>();

		// Token: 0x0400340F RID: 13327
		private int maxMonks;

		// Token: 0x04003410 RID: 13328
		private double storedPreCardDistance;

		// Token: 0x04003411 RID: 13329
		private int lastMax = -1;

		// Token: 0x04003412 RID: 13330
		private bool sliderEnabled;

		// Token: 0x04003413 RID: 13331
		private bool launchAllowed;

		// Token: 0x04003414 RID: 13332
		private int currentCommand = -1;

		// Token: 0x04003415 RID: 13333
		private bool inLaunch;

		// Token: 0x04003416 RID: 13334
		private DateTime lastLaunchTime = DateTime.MinValue;

		// Token: 0x04003417 RID: 13335
		private List<SendMonkPanel.MonkVoteLine> lineList = new List<SendMonkPanel.MonkVoteLine>();

		// Token: 0x04003418 RID: 13336
		private SendMonkPanel.ParishMemberComparer parishMemberComparer = new SendMonkPanel.ParishMemberComparer();

		// Token: 0x02000488 RID: 1160
		public class ParishMemberComparer : IComparer<ParishMember>
		{
			// Token: 0x06002A43 RID: 10819 RVA: 0x0001F0E7 File Offset: 0x0001D2E7
			public int Compare(ParishMember x, ParishMember y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return 0;
					}
					return -1;
				}
				else
				{
					if (y == null)
					{
						return 1;
					}
					if (x.numVotesReceived < y.numVotesReceived)
					{
						return 1;
					}
					if (x.numVotesReceived > y.numVotesReceived)
					{
						return -1;
					}
					return 0;
				}
			}
		}

		// Token: 0x02000489 RID: 1161
		public class MonkVoteLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06002A45 RID: 10821 RVA: 0x0020E88C File Offset: 0x0020CA8C
			public void init(string playerName, int userID, int rank, int points, bool votingAllowed, int numSpareVotes, int numReceivedVotes, int factionID, int votedUser, SendMonkPanel parent)
			{
				this.Size = new Size(385, 25);
				this.m_parent = parent;
				this.m_userID = userID;
				this.m_factionID = factionID;
				this.m_votingAllowed = votingAllowed;
				base.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.radioClicked));
				if (votedUser != userID)
				{
					this.radioButton.ImageNorm = GFXLibrary.radio_green[2];
					this.radioButton.ImageOver = GFXLibrary.radio_green[1];
					this.radioButton.ImageClick = GFXLibrary.radio_green[1];
					this.radioButton.Active = true;
				}
				else
				{
					this.radioButton.ImageNorm = GFXLibrary.radio_green[0];
					this.radioButton.ImageOver = GFXLibrary.radio_green[0];
					this.radioButton.ImageClick = GFXLibrary.radio_green[0];
					this.radioButton.Active = false;
				}
				this.radioButton.Position = new Point(0, 2);
				this.radioButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.radioClicked));
				base.addControl(this.radioButton);
				this.nameLabel.Text = "";
				this.nameLabel.Color = global::ARGBColors.White;
				this.nameLabel.Position = new Point(20, 0);
				this.nameLabel.Size = new Size(175, 25);
				this.nameLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.nameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.nameLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.radioClicked));
				base.addControl(this.nameLabel);
				this.factionLabel.Color = global::ARGBColors.White;
				this.factionLabel.Position = new Point(200, 0);
				this.factionLabel.Size = new Size(150, 25);
				this.factionLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.factionLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.factionLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.radioClicked));
				base.addControl(this.factionLabel);
				this.votesLabel.Color = global::ARGBColors.White;
				this.votesLabel.Position = new Point(350, 0);
				this.votesLabel.Size = new Size(35, 25);
				this.votesLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.votesLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.votesLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.radioClicked));
				base.addControl(this.votesLabel);
				ControlForm controlForm = DX.ControlForm;
				if (controlForm != null && controlForm.IsExclusive)
				{
					this.nameLabel.Text = string.Format("{0} ({1})", playerName, numSpareVotes);
				}
				else
				{
					this.nameLabel.Text = playerName;
				}
				NumberFormatInfo nfi = GameEngine.NFI;
				this.votesLabel.Text = numReceivedVotes.ToString("N", nfi);
				if (factionID >= 0)
				{
					FactionData faction = GameEngine.Instance.World.getFaction(factionID);
					if (faction != null)
					{
						this.factionLabel.Text = faction.factionNameAbrv;
					}
					else
					{
						this.factionLabel.Text = "";
					}
				}
				else
				{
					this.factionLabel.Text = "";
				}
				base.invalidate();
			}

			// Token: 0x06002A46 RID: 10822 RVA: 0x00007CE0 File Offset: 0x00005EE0
			public void update()
			{
			}

			// Token: 0x06002A47 RID: 10823 RVA: 0x0020EC0C File Offset: 0x0020CE0C
			public void setState(int selectedUserID)
			{
				if (selectedUserID != this.m_userID)
				{
					this.radioButton.ImageNorm = GFXLibrary.radio_green[2];
					this.radioButton.ImageOver = GFXLibrary.radio_green[1];
					this.radioButton.ImageClick = GFXLibrary.radio_green[1];
					this.radioButton.Active = true;
					return;
				}
				this.radioButton.ImageNorm = GFXLibrary.radio_green[0];
				this.radioButton.ImageOver = GFXLibrary.radio_green[0];
				this.radioButton.ImageClick = GFXLibrary.radio_green[0];
				this.radioButton.Active = false;
			}

			// Token: 0x06002A48 RID: 10824 RVA: 0x0001F119 File Offset: 0x0001D319
			public void radioClicked()
			{
				if (this.radioButton.Active && this.m_parent != null)
				{
					GameEngine.Instance.playInterfaceSound("SendMonkPanel_select_village");
					this.m_parent.radioClicked(this.m_userID);
				}
			}

			// Token: 0x06002A49 RID: 10825 RVA: 0x00007CE0 File Offset: 0x00005EE0
			public void lineClicked()
			{
			}

			// Token: 0x04003419 RID: 13337
			private CustomSelfDrawPanel.CSDLabel nameLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400341A RID: 13338
			private CustomSelfDrawPanel.CSDLabel factionLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400341B RID: 13339
			private CustomSelfDrawPanel.CSDLabel votesLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400341C RID: 13340
			private CustomSelfDrawPanel.CSDButton radioButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x0400341D RID: 13341
			private SendMonkPanel m_parent;

			// Token: 0x0400341E RID: 13342
			private int m_userID = -1;

			// Token: 0x0400341F RID: 13343
			private int m_factionID = -1;

			// Token: 0x04003420 RID: 13344
			private bool m_votingAllowed;
		}
	}
}
