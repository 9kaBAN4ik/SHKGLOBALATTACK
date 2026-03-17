using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x020001E9 RID: 489
	public class GloryPanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06001376 RID: 4982 RVA: 0x00149658 File Offset: 0x00147858
		public GloryPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06001377 RID: 4983 RVA: 0x00149E7C File Offset: 0x0014807C
		public void init()
		{
			this.secondAge = GameEngine.Instance.World.SecondAgeWorld;
			this.thirdAge = GameEngine.Instance.World.ThirdAgeWorld;
			this.sixthAge = GameEngine.Instance.World.SixthAgeWorld;
			int num = 100;
			int num2 = 1000;
			int num3 = 10000;
			int num4 = 100000;
			int num5 = 1000000;
			if (GameEngine.Instance.LocalWorldData.AIWorld)
			{
				num = 1000;
				num2 = 10000;
				num3 = 100000;
				num4 = 1000000;
				num5 = GameEngine.Instance.World.aiWorldGloryWinLevel;
			}
			else if (!GameEngine.Instance.LocalWorldData.EraWorld)
			{
				if (GameEngine.Instance.LocalWorldData.Alternate_Ruleset == 1)
				{
					num = 1000;
					num2 = 10000;
					num3 = 100000;
					num4 = 1000000;
					num5 = 50000000;
				}
				else if (this.thirdAge && !this.sixthAge)
				{
					num = 1000;
					num2 = 10000;
					num3 = 100000;
					num4 = 1000000;
					num5 = 4000000;
				}
				if (GameEngine.Instance.World.GetGlobalWorldID() >= 1200 && GameEngine.Instance.World.GetGlobalWorldID() <= 1201 && !this.secondAge)
				{
					if (!this.thirdAge || this.sixthAge)
					{
						num = 1000;
						num2 = 10000;
						num3 = 100000;
						num4 = 1000000;
						num5 = 5000000;
					}
					else
					{
						num = 1000;
						num2 = 10000;
						num3 = 100000;
						num4 = 1000000;
						num5 = 20000000;
					}
				}
			}
			else if (GameEngine.Instance.LocalWorldData.Alternate_Ruleset == 1)
			{
				num = 1000;
				num2 = 10000;
				num3 = 100000;
				num4 = 1000000;
				num5 = 50000000;
			}
			else
			{
				int num6 = 0;
				if (GameEngine.Instance.World.SecondAgeWorld)
				{
					num6++;
				}
				if (GameEngine.Instance.World.ThirdAgeWorld)
				{
					num6++;
				}
				if (GameEngine.Instance.World.FourthAgeWorld)
				{
					num6++;
				}
				if (GameEngine.Instance.World.FifthAgeWorld)
				{
					num6++;
				}
				if (GameEngine.Instance.World.SixthAgeWorld)
				{
					num6++;
				}
				if (GameEngine.Instance.World.SeventhAgeWorld)
				{
					num6++;
				}
				bool highCountryCount = false;
				int globalWorldID = GameEngine.Instance.World.GetGlobalWorldID();
				if (globalWorldID >= 1200 && globalWorldID <= 1299)
				{
					highCountryCount = true;
				}
				else if (globalWorldID >= 700 && globalWorldID <= 799)
				{
					highCountryCount = true;
				}
				num5 = VillageBuildingsData.getEraWorldGloryLimits(num6, highCountryCount, globalWorldID);
				if (num5 <= 100000)
				{
					num = 10;
					num2 = 100;
					num3 = 1000;
					num4 = 10000;
				}
			}
			if (GameEngine.Instance.World.testGloryPointsUpdate())
			{
				RemoteServices.Instance.set_GetHouseGloryPoints_UserCallBack(new RemoteServices.GetHouseGloryPoints_UserCallBack(this.GetHouseGloryPointsCallBack));
				RemoteServices.Instance.GetHouseGloryPoints();
			}
			int num7 = 0;
			int num8 = 0;
			for (int i = 0; i < 20; i++)
			{
				if (!GameEngine.Instance.World.HouseInfo[i + 1].loser)
				{
					this.lastHousePoints[i, 0] = GameEngine.Instance.World.HouseGloryPoints[i + 1];
					if (this.lastHousePoints[i, 0] > num7)
					{
						num7 = this.lastHousePoints[i, 0];
					}
				}
				else
				{
					this.lastHousePoints[i, 0] = -1;
					num8++;
				}
				this.lastHousePoints[i, 1] = i;
			}
			for (int j = 0; j < 19; j++)
			{
				for (int k = 0; k < 19; k++)
				{
					if (this.lastHousePoints[k, 0] < this.lastHousePoints[k + 1, 0])
					{
						int num9 = this.lastHousePoints[k, 0];
						this.lastHousePoints[k, 0] = this.lastHousePoints[k + 1, 0];
						this.lastHousePoints[k + 1, 0] = num9;
						num9 = this.lastHousePoints[k, 1];
						this.lastHousePoints[k, 1] = this.lastHousePoints[k + 1, 1];
						this.lastHousePoints[k + 1, 1] = num9;
					}
				}
			}
			base.clearControls();
			this.mainBackgroundImage.Image = GFXLibrary.glory_background;
			this.mainBackgroundImage.Width = 1600;
			this.mainBackgroundImage.Height = 1024;
			int width = base.Width;
			int num10 = base.Height;
			this.mainBackgroundImage.Position = new Point((width - 1600) / 2, -(1024 - num10));
			base.addControl(this.mainBackgroundImage);
			this.viewableArea.Position = new Point((1600 - width) / 2, 1024 - num10);
			this.viewableArea.Size = new Size(base.Size.Width, base.Size.Height - 50);
			this.mainBackgroundImage.addControl(this.viewableArea);
			int num11 = 25;
			num10 -= 50;
			CustomSelfDrawPanel.WikiLinkControl.init(this.viewableArea, 22, new Point(base.Width - 38, 26));
			if (GameEngine.Instance.World.HouseGloryRoundData != null && GameEngine.Instance.World.HouseGloryRoundData.winnerHouseID > 0)
			{
				this.gloryWinnerButton.Position = new Point(this.viewableArea.Width - 200 - 15 - 30, num11);
				this.gloryWinnerButton.Size = new Size(200, 38);
				this.gloryWinnerButton.Text.Text = SK.Text("TEMP_ViewWinner", "Last Glory Round Result");
				this.gloryWinnerButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				if (Program.mySettings.LanguageIdent == "it")
				{
					this.gloryWinnerButton.Text.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
				}
				else
				{
					this.gloryWinnerButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				}
				this.gloryWinnerButton.TextYOffset = -1;
				this.gloryWinnerButton.Text.Color = global::ARGBColors.Black;
				this.gloryWinnerButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.gloryWinnerClick), "Glory_view_result");
				this.viewableArea.addControl(this.gloryWinnerButton);
				this.gloryWinnerButton.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
				this.gloryWinnerButton.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
			}
			int num12 = 0;
			if (GameEngine.Instance.World.SeventhAgeWorld && !GameEngine.Instance.LocalWorldData.AIWorld)
			{
				this.endOfTheWorldButton.Position = new Point(77, num11 + 5);
				this.endOfTheWorldButton.ImageNorm = GFXLibrary.eow_toggle[3];
				this.endOfTheWorldButton.ImageOver = GFXLibrary.eow_toggle[4];
				this.endOfTheWorldButton.ImageClick = GFXLibrary.eow_toggle[5];
				this.endOfTheWorldButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.viewEndWorldPanelClick), "Glory_view_result");
				this.viewableArea.addControl(this.endOfTheWorldButton);
				num12 = this.endOfTheWorldButton.ImageNorm.Size.Height;
			}
			if (GameEngine.Instance.LocalWorldData.EraWorld && GameEngine.Instance.World.HouseGloryPoints.Length > 21)
			{
				this.eraStarText.Text = (5 - GameEngine.Instance.World.HouseGloryPoints[21]).ToString() + " / 5";
				this.eraStarText.Color = global::ARGBColors.White;
				this.eraStarText.DropShadowColor = global::ARGBColors.Black;
				this.eraStarText.Position = new Point(59, num11 + 5 + num12);
				this.eraStarText.Size = new Size(50, 20);
				this.eraStarText.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				this.eraStarText.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.eraStarText.CustomTooltipID = 1730;
				this.viewableArea.addControl(this.eraStarText);
				this.eraStar.Image = GFXLibrary.glory_star_large;
				this.eraStar.Position = new Point(114, num11 + 5 + num12);
				this.eraStar.CustomTooltipID = 1730;
				this.viewableArea.addControl(this.eraStar);
			}
			if (!GameEngine.Instance.World.gotPlaybackData())
			{
				this.retrieveGameStats();
			}
			this.playbackCountryButton.Position = new Point(this.viewableArea.Width - 200 - 15 - 30, num11 + 40);
			this.playbackCountryButton.Size = new Size(200, 38);
			this.playbackCountryButton.Text.Text = SK.Text("GLORY_PLAY_COUNTRY", "Show Country History");
			this.playbackCountryButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			if (Program.mySettings.LanguageIdent == "it")
			{
				this.playbackCountryButton.Text.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
			}
			else
			{
				this.playbackCountryButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			}
			this.playbackCountryButton.TextYOffset = -1;
			this.playbackCountryButton.Text.Color = global::ARGBColors.Black;
			this.playbackCountryButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.playbackCountryClick), "playback_country");
			this.viewableArea.addControl(this.playbackCountryButton);
			this.playbackCountryButton.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
			this.playbackCountryButton.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
			this.playbackProvinceButton.Position = new Point(this.viewableArea.Width - 200 - 15 - 30, num11 + 82);
			this.playbackProvinceButton.Size = new Size(200, 38);
			this.playbackProvinceButton.Text.Text = SK.Text("GLORY_PLAY_PROVINCE", "Show Province History");
			this.playbackProvinceButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			if (Program.mySettings.LanguageIdent == "it")
			{
				this.playbackProvinceButton.Text.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
			}
			else
			{
				this.playbackProvinceButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			}
			this.playbackProvinceButton.TextYOffset = -1;
			this.playbackProvinceButton.Text.Color = global::ARGBColors.Black;
			this.playbackProvinceButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.playbackProvinceClick), "playback_province");
			this.viewableArea.addControl(this.playbackProvinceButton);
			this.playbackProvinceButton.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
			this.playbackProvinceButton.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
			this.gloryValuesButton.Position = new Point(this.viewableArea.Width - 200 - 15 - 30, num11 + 82 + 42);
			this.gloryValuesButton.Size = new Size(200, 38);
			this.gloryValuesButton.Text.Text = SK.Text("GLORY_VALUES", "Glory Values");
			this.gloryValuesButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.gloryValuesButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.gloryValuesButton.TextYOffset = -1;
			this.gloryValuesButton.Text.Color = global::ARGBColors.Black;
			this.gloryValuesButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.gloryValuesClick), "playback_province");
			this.viewableArea.addControl(this.gloryValuesButton);
			this.gloryValuesButton.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
			this.gloryValuesButton.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
			if (num7 >= num5)
			{
				DateTime currentServerTime = VillageMap.getCurrentServerTime();
				DateTime dateTime = new DateTime(currentServerTime.Year, currentServerTime.Month, currentServerTime.Day, 8, 0, 0);
				if (currentServerTime > dateTime)
				{
					dateTime = dateTime.AddDays(1.0);
				}
				int num13 = (int)(dateTime - currentServerTime).TotalHours;
				string text = SK.Text("GloryPanel_EndingSoon", "Glory Round Ending Soon");
				if (num13 > 1)
				{
					string text2 = text;
					text = string.Concat(new string[]
					{
						text2,
						" ( ",
						SK.Text("GloryPanel_Approximately", "Approximately"),
						" : ",
						num13.ToString(),
						" "
					});
					text = text + SK.Text("Reports_Hours", "hours") + " )";
				}
				this.gloryRoundEnding.Text = text;
				this.gloryRoundEnding.Color = global::ARGBColors.White;
				this.gloryRoundEnding.DropShadowColor = global::ARGBColors.Black;
				this.gloryRoundEnding.Position = new Point(100, 2);
				this.gloryRoundEnding.Size = new Size(700, 20);
				this.gloryRoundEnding.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				this.gloryRoundEnding.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_LEFT;
				this.viewableArea.addControl(this.gloryRoundEnding);
			}
			this.scaleVertLine.Position = new Point(65, num11);
			this.scaleVertLine.Size = new Size(0, num10 - num11);
			this.scaleVertLine.LineColor = global::ARGBColors.Black;
			this.viewableArea.addControl(this.scaleVertLine);
			this.scaleMark0LineS.Position = new Point(59, num10 - 1);
			this.scaleMark0LineS.Size = new Size(6, 0);
			this.scaleMark0LineS.LineColor = global::ARGBColors.Black;
			this.viewableArea.addControl(this.scaleMark0LineS);
			int num14 = (num10 - num11) * this.markPositionPercents[1] / 100;
			this.scaleMark100Line.Position = new Point(59, num10 - num14);
			this.scaleMark100Line.Size = new Size(6, 0);
			this.scaleMark100Line.LineColor = global::ARGBColors.Black;
			this.viewableArea.addControl(this.scaleMark100Line);
			num14 = (num10 - num11) * (this.markPositionPercents[1] + this.markPositionPercents[2]) / 100;
			this.scaleMark1000Line.Position = new Point(59, num10 - num14);
			this.scaleMark1000Line.Size = new Size(6, 0);
			this.scaleMark1000Line.LineColor = global::ARGBColors.Black;
			this.viewableArea.addControl(this.scaleMark1000Line);
			num14 = (num10 - num11) * (this.markPositionPercents[1] + this.markPositionPercents[2] + this.markPositionPercents[3]) / 100;
			this.scaleMark10000Line.Position = new Point(59, num10 - num14);
			this.scaleMark10000Line.Size = new Size(6, 0);
			this.scaleMark10000Line.LineColor = global::ARGBColors.Black;
			this.viewableArea.addControl(this.scaleMark10000Line);
			num14 = (num10 - num11) * (this.markPositionPercents[1] + this.markPositionPercents[2] + this.markPositionPercents[3] + this.markPositionPercents[4]) / 100;
			this.scaleMark100000Line.Position = new Point(59, num10 - num14);
			this.scaleMark100000Line.Size = new Size(6, 0);
			this.scaleMark100000Line.LineColor = global::ARGBColors.Black;
			this.viewableArea.addControl(this.scaleMark100000Line);
			num14 = num10 - num11;
			this.scaleMark1000000Line.Position = new Point(59, num10 - num14);
			this.scaleMark1000000Line.Size = new Size(6, 0);
			this.scaleMark1000000Line.LineColor = global::ARGBColors.Black;
			this.viewableArea.addControl(this.scaleMark1000000Line);
			this.scaleVertLineS.Position = new Point(64, num11 - 1);
			this.scaleVertLineS.Size = new Size(0, num10 - num11);
			this.scaleVertLineS.LineColor = global::ARGBColors.White;
			this.viewableArea.addControl(this.scaleVertLineS);
			this.topLineS.Position = new Point(66, num11 - 1);
			this.topLineS.Size = new Size(base.Width - 65 - 1, 0);
			this.topLineS.LineColor = global::ARGBColors.Yellow;
			this.viewableArea.addControl(this.topLineS);
			this.bottomLineS.Position = new Point(66, num10 - 1);
			this.bottomLineS.Size = new Size(base.Width - 65 - 1, 0);
			this.bottomLineS.LineColor = global::ARGBColors.Yellow;
			this.viewableArea.addControl(this.bottomLineS);
			this.scaleMark0Line.Position = new Point(58, num10 - 1 - 1);
			this.scaleMark0Line.Size = new Size(6, 0);
			this.scaleMark0Line.LineColor = global::ARGBColors.White;
			this.viewableArea.addControl(this.scaleMark0Line);
			this.bandYPos0 = num10;
			this.mark0Label.Text = "0";
			this.mark0Label.Color = global::ARGBColors.White;
			this.mark0Label.DropShadowColor = global::ARGBColors.Black;
			this.mark0Label.Position = new Point(0, num10 - 20 + 2);
			this.mark0Label.Size = new Size(59, 20);
			this.mark0Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.mark0Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_RIGHT;
			this.viewableArea.addControl(this.mark0Label);
			num14 = (num10 - num11) * this.markPositionPercents[1] / 100;
			this.bandYPos100 = this.bandYPos0 - num14;
			this.scaleMark100LineS.Position = new Point(58, num10 - num14 - 1);
			this.scaleMark100LineS.Size = new Size(6, 0);
			this.scaleMark100LineS.LineColor = global::ARGBColors.White;
			this.viewableArea.addControl(this.scaleMark100LineS);
			this.mark100Label.Text = num.ToString();
			this.mark100Label.Color = global::ARGBColors.White;
			this.mark100Label.DropShadowColor = global::ARGBColors.Black;
			this.mark100Label.Position = new Point(0, num10 - num14 - 9);
			this.mark100Label.Size = new Size(59, 20);
			this.mark100Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.mark100Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_RIGHT;
			this.viewableArea.addControl(this.mark100Label);
			num14 = (num10 - num11) * (this.markPositionPercents[1] + this.markPositionPercents[2]) / 100;
			this.bandYPos1000 = this.bandYPos0 - num14;
			this.scaleMark1000LineS.Position = new Point(58, num10 - num14 - 1);
			this.scaleMark1000LineS.Size = new Size(6, 0);
			this.scaleMark1000LineS.LineColor = global::ARGBColors.White;
			this.viewableArea.addControl(this.scaleMark1000LineS);
			this.mark1000Label.Text = num2.ToString();
			this.mark1000Label.Color = global::ARGBColors.White;
			this.mark1000Label.DropShadowColor = global::ARGBColors.Black;
			this.mark1000Label.Position = new Point(0, num10 - num14 - 9);
			this.mark1000Label.Size = new Size(59, 20);
			this.mark1000Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.mark1000Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_RIGHT;
			this.viewableArea.addControl(this.mark1000Label);
			num14 = (num10 - num11) * (this.markPositionPercents[1] + this.markPositionPercents[2] + this.markPositionPercents[3]) / 100;
			this.bandYPos10000 = this.bandYPos0 - num14;
			this.scaleMark10000LineS.Position = new Point(58, num10 - num14 - 1);
			this.scaleMark10000LineS.Size = new Size(6, 0);
			this.scaleMark10000LineS.LineColor = global::ARGBColors.White;
			this.viewableArea.addControl(this.scaleMark10000LineS);
			this.mark10000Label.Text = num3.ToString();
			this.mark10000Label.Color = global::ARGBColors.White;
			this.mark10000Label.DropShadowColor = global::ARGBColors.Black;
			this.mark10000Label.Position = new Point(0, num10 - num14 - 9);
			this.mark10000Label.Size = new Size(59, 20);
			this.mark10000Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.mark10000Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_RIGHT;
			this.viewableArea.addControl(this.mark10000Label);
			num14 = (num10 - num11) * (this.markPositionPercents[1] + this.markPositionPercents[2] + this.markPositionPercents[3] + this.markPositionPercents[4]) / 100;
			this.bandYPos100000 = this.bandYPos0 - num14;
			this.scaleMark100000LineS.Position = new Point(58, num10 - num14 - 1);
			this.scaleMark100000LineS.Size = new Size(6, 0);
			this.scaleMark100000LineS.LineColor = global::ARGBColors.White;
			this.viewableArea.addControl(this.scaleMark100000LineS);
			this.mark100000Label.Text = num4.ToString();
			this.mark100000Label.Color = global::ARGBColors.White;
			this.mark100000Label.DropShadowColor = global::ARGBColors.Black;
			this.mark100000Label.Position = new Point(0, num10 - num14 - 9);
			this.mark100000Label.Size = new Size(59, 20);
			this.mark100000Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.mark100000Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_RIGHT;
			this.viewableArea.addControl(this.mark100000Label);
			num14 = num10 - num11;
			this.bandYPos1000000 = this.bandYPos0 - num14;
			this.scaleMark1000000LineS.Position = new Point(58, num10 - num14 - 1);
			this.scaleMark1000000LineS.Size = new Size(6, 0);
			this.scaleMark1000000LineS.LineColor = global::ARGBColors.White;
			this.viewableArea.addControl(this.scaleMark1000000LineS);
			this.mark1000000Label.Text = num5.ToString();
			this.mark1000000Label.Color = global::ARGBColors.White;
			this.mark1000000Label.DropShadowColor = global::ARGBColors.Black;
			if (num5 >= 10000000)
			{
				this.mark1000000Label.Position = new Point(-11, num10 - num14 - 9);
				this.mark1000000Label.Size = new Size(69, 20);
			}
			else
			{
				this.mark1000000Label.Position = new Point(0, num10 - num14 - 9);
				this.mark1000000Label.Size = new Size(59, 20);
			}
			this.mark1000000Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.mark1000000Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_RIGHT;
			this.viewableArea.addControl(this.mark1000000Label);
			int num15 = base.Width - 65 - 5 - 5;
			num15 += num8 * 45;
			this.makeSizes();
			int num16 = 14;
			for (int l = 0; l < 15; l++)
			{
				if (num15 < this.filledBands[l][20])
				{
					num16 = l - 1;
					break;
				}
			}
			int num17 = 70;
			int num18 = num8 / 2;
			int num19 = 20 - (num8 - num18);
			for (int m = num18; m < num19; m++)
			{
				int num20 = this.lastHousePoints[this.readOrder[m], 1] + 1;
				int num21 = this.lastHousePoints[this.readOrder[m], 0];
				int customTooltipData = num21;
				int num22;
				if (num21 < num)
				{
					num22 = this.bandYPos0;
					num21 = num21;
					num21 *= this.bandYPos0 - this.bandYPos100;
					num21 /= num;
					num22 -= num21;
				}
				else if (num21 < num2)
				{
					num22 = this.bandYPos100;
					num21 -= num;
					num21 *= this.bandYPos100 - this.bandYPos1000;
					num21 /= num2 - num;
					num22 -= num21;
				}
				else if (num21 < num3)
				{
					num22 = this.bandYPos1000;
					num21 -= num2;
					num21 *= this.bandYPos1000 - this.bandYPos10000;
					num21 /= num3 - num2;
					num22 -= num21;
				}
				else if (num21 < num4)
				{
					num22 = this.bandYPos10000;
					num21 -= num3;
					num21 *= this.bandYPos10000 - this.bandYPos100000;
					num21 /= num4 - num3;
					num22 -= num21;
				}
				else if (num21 < num5)
				{
					num22 = this.bandYPos100000;
					num21 -= num4;
					num21 *= this.bandYPos100000 - this.bandYPos1000000;
					num21 /= num5 - num4;
					num22 -= num21;
				}
				else
				{
					num22 = this.bandYPos1000000;
				}
				int num23 = this.filledBands[num16][this.readOrder[m]];
				CustomSelfDrawPanel.CSDImage flagImage = this.getFlagImage(m);
				flagImage.Position = new Point(num17, num22);
				CustomSelfDrawPanel.CSDImage flagpoleImage = this.getFlagpoleImage(m);
				int num24 = GameEngine.Instance.World.HouseInfo[num20].numVictories;
				int num25 = num24;
				if (num24 > 5)
				{
					num24 = 5;
				}
				BaseImage b = null;
				int num26 = 0;
				int num27 = 0;
				int num28 = 0;
				int num29 = num17;
				switch (num23)
				{
				case 0:
					flagpoleImage.Position = new Point(num17 + 11 + 1, num22 + 500);
					num17 += 45;
					flagImage.Width = 45;
					flagImage.Height = 575;
					flagImage.Image = GFXLibrary.glory_flags_small[num20 - 1];
					flagpoleImage.Image = GFXLibrary.glory_thin_pole;
					b = GFXLibrary.glory_star_small;
					num26 = 14;
					num27 = 9;
					num28 = 4;
					break;
				case 1:
					flagpoleImage.Position = new Point(num17 + 19, num22 + 500);
					num17 += 60;
					flagImage.Width = 60;
					flagImage.Height = 600;
					flagImage.Image = GFXLibrary.glory_flags_med[num20 - 1];
					flagpoleImage.Image = GFXLibrary.glory_thin_pole;
					b = GFXLibrary.glory_star_small;
					num26 = 20;
					num27 = 12;
					num28 = 4;
					break;
				case 2:
					flagpoleImage.Position = new Point(num17 + 30 - 5, num22 + 500);
					num17 += 90;
					flagImage.Width = 90;
					flagImage.Height = 600;
					flagImage.Image = GFXLibrary.glory_flags_large[num20 - 1];
					flagpoleImage.Image = GFXLibrary.glory_thick_pole;
					b = GFXLibrary.glory_star_large;
					num26 = 29;
					num27 = 16;
					num28 = 7;
					break;
				case 3:
					flagpoleImage.Position = new Point(num17 + 40 - 6, num22 + 500);
					num17 += 110;
					flagImage.Width = 110;
					flagImage.Height = 600;
					flagImage.Image = GFXLibrary.glory_flags_largest[num20 - 1];
					flagpoleImage.Image = GFXLibrary.glory_thick_pole;
					b = GFXLibrary.glory_star_large;
					num26 = 39;
					num27 = 20;
					num28 = 7;
					break;
				}
				flagImage.CustomTooltipID = 1700 + num20 - 1;
				flagImage.CustomTooltipData = customTooltipData;
				flagImage.Data = num20;
				flagImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.viewHouse), "GloryPanel_view_house");
				this.viewableArea.addControl(flagpoleImage);
				this.viewableArea.addControl(flagImage);
				for (int n = 0; n < num24; n++)
				{
					CustomSelfDrawPanel.CSDImage star = this.getStar(num20 - 1, n);
					star.Image = b;
					star.Position = new Point(num29 + num26 + this.starSteps[n] * num27, num22 - num28);
					this.viewableArea.addControl(star);
					CustomSelfDrawPanel.CSDImage csdimage = star;
					int num30 = 5;
					int num31 = 5;
					while (num30 < 100)
					{
						if (n + num30 + 1 <= num25)
						{
							CustomSelfDrawPanel.CSDImage csdimage2 = new CustomSelfDrawPanel.CSDImage();
							csdimage2.Image = b;
							csdimage2.Position = new Point(num31, -8);
							csdimage.addControl(csdimage2);
							csdimage = csdimage2;
						}
						num30 += 5;
						num31 *= -1;
					}
				}
			}
			base.Invalidate();
		}

		// Token: 0x06001378 RID: 4984 RVA: 0x0014BC58 File Offset: 0x00149E58
		public void makeSizes()
		{
			if (this.bandsMade)
			{
				return;
			}
			this.bandsMade = true;
			for (int i = 0; i < this.bands.Length; i += 4)
			{
				int num = this.bands[i];
				int num2 = this.bands[i + 1];
				int num3 = this.bands[i + 2];
				int num4 = this.bands[i + 3];
				int[] array = new int[21];
				int num5 = 0;
				int num6 = 0;
				for (int j = 0; j < num; j++)
				{
					array[num5++] = 3;
					num6 += 110;
				}
				for (int k = 0; k < num2; k++)
				{
					array[num5++] = 2;
					num6 += 90;
				}
				for (int l = 0; l < num3; l++)
				{
					array[num5++] = 1;
					num6 += 60;
				}
				for (int m = 0; m < num4; m++)
				{
					array[num5++] = 0;
					num6 += 45;
				}
				array[num5] = num6;
				this.filledBands[i / 4] = array;
			}
		}

		// Token: 0x06001379 RID: 4985 RVA: 0x0014BD64 File Offset: 0x00149F64
		public CustomSelfDrawPanel.CSDImage getFlagImage(int flag)
		{
			switch (flag)
			{
			case 0:
				return this.flagImage0;
			case 1:
				return this.flagImage1;
			case 2:
				return this.flagImage2;
			case 3:
				return this.flagImage3;
			case 4:
				return this.flagImage4;
			case 5:
				return this.flagImage5;
			case 6:
				return this.flagImage6;
			case 7:
				return this.flagImage7;
			case 8:
				return this.flagImage8;
			case 9:
				return this.flagImage9;
			case 10:
				return this.flagImage10;
			case 11:
				return this.flagImage11;
			case 12:
				return this.flagImage12;
			case 13:
				return this.flagImage13;
			case 14:
				return this.flagImage14;
			case 15:
				return this.flagImage15;
			case 16:
				return this.flagImage16;
			case 17:
				return this.flagImage17;
			case 18:
				return this.flagImage18;
			case 19:
				return this.flagImage19;
			default:
				return this.flagImage0;
			}
		}

		// Token: 0x0600137A RID: 4986 RVA: 0x0014BE60 File Offset: 0x0014A060
		public CustomSelfDrawPanel.CSDImage getFlagpoleImage(int flag)
		{
			switch (flag)
			{
			case 0:
				return this.flagpoleImage0;
			case 1:
				return this.flagpoleImage1;
			case 2:
				return this.flagpoleImage2;
			case 3:
				return this.flagpoleImage3;
			case 4:
				return this.flagpoleImage4;
			case 5:
				return this.flagpoleImage5;
			case 6:
				return this.flagpoleImage6;
			case 7:
				return this.flagpoleImage7;
			case 8:
				return this.flagpoleImage8;
			case 9:
				return this.flagpoleImage9;
			case 10:
				return this.flagpoleImage10;
			case 11:
				return this.flagpoleImage11;
			case 12:
				return this.flagpoleImage12;
			case 13:
				return this.flagpoleImage13;
			case 14:
				return this.flagpoleImage14;
			case 15:
				return this.flagpoleImage15;
			case 16:
				return this.flagpoleImage16;
			case 17:
				return this.flagpoleImage17;
			case 18:
				return this.flagpoleImage18;
			case 19:
				return this.flagpoleImage19;
			default:
				return this.flagpoleImage0;
			}
		}

		// Token: 0x0600137B RID: 4987 RVA: 0x0014BF5C File Offset: 0x0014A15C
		public CustomSelfDrawPanel.CSDImage getStar(int flag, int star)
		{
			switch (flag)
			{
			case 0:
				switch (star)
				{
				case 0:
					return this.flag0ImageStar1;
				case 1:
					return this.flag0ImageStar2;
				case 2:
					return this.flag0ImageStar3;
				case 3:
					return this.flag0ImageStar4;
				case 4:
					return this.flag0ImageStar5;
				}
				break;
			case 1:
				switch (star)
				{
				case 0:
					return this.flag1ImageStar1;
				case 1:
					return this.flag1ImageStar2;
				case 2:
					return this.flag1ImageStar3;
				case 3:
					return this.flag1ImageStar4;
				case 4:
					return this.flag1ImageStar5;
				}
				break;
			case 2:
				switch (star)
				{
				case 0:
					return this.flag2ImageStar1;
				case 1:
					return this.flag2ImageStar2;
				case 2:
					return this.flag2ImageStar3;
				case 3:
					return this.flag2ImageStar4;
				case 4:
					return this.flag2ImageStar5;
				}
				break;
			case 3:
				switch (star)
				{
				case 0:
					return this.flag3ImageStar1;
				case 1:
					return this.flag3ImageStar2;
				case 2:
					return this.flag3ImageStar3;
				case 3:
					return this.flag3ImageStar4;
				case 4:
					return this.flag3ImageStar5;
				}
				break;
			case 4:
				switch (star)
				{
				case 0:
					return this.flag4ImageStar1;
				case 1:
					return this.flag4ImageStar2;
				case 2:
					return this.flag4ImageStar3;
				case 3:
					return this.flag4ImageStar4;
				case 4:
					return this.flag4ImageStar5;
				}
				break;
			case 5:
				switch (star)
				{
				case 0:
					return this.flag5ImageStar1;
				case 1:
					return this.flag5ImageStar2;
				case 2:
					return this.flag5ImageStar3;
				case 3:
					return this.flag5ImageStar4;
				case 4:
					return this.flag5ImageStar5;
				}
				break;
			case 6:
				switch (star)
				{
				case 0:
					return this.flag6ImageStar1;
				case 1:
					return this.flag6ImageStar2;
				case 2:
					return this.flag6ImageStar3;
				case 3:
					return this.flag6ImageStar4;
				case 4:
					return this.flag6ImageStar5;
				}
				break;
			case 7:
				switch (star)
				{
				case 0:
					return this.flag7ImageStar1;
				case 1:
					return this.flag7ImageStar2;
				case 2:
					return this.flag7ImageStar3;
				case 3:
					return this.flag7ImageStar4;
				case 4:
					return this.flag7ImageStar5;
				}
				break;
			case 8:
				switch (star)
				{
				case 0:
					return this.flag8ImageStar1;
				case 1:
					return this.flag8ImageStar2;
				case 2:
					return this.flag8ImageStar3;
				case 3:
					return this.flag8ImageStar4;
				case 4:
					return this.flag8ImageStar5;
				}
				break;
			case 9:
				switch (star)
				{
				case 0:
					return this.flag9ImageStar1;
				case 1:
					return this.flag9ImageStar2;
				case 2:
					return this.flag9ImageStar3;
				case 3:
					return this.flag9ImageStar4;
				case 4:
					return this.flag9ImageStar5;
				}
				break;
			case 10:
				switch (star)
				{
				case 0:
					return this.flag10ImageStar1;
				case 1:
					return this.flag10ImageStar2;
				case 2:
					return this.flag10ImageStar3;
				case 3:
					return this.flag10ImageStar4;
				case 4:
					return this.flag10ImageStar5;
				}
				break;
			case 11:
				switch (star)
				{
				case 0:
					return this.flag11ImageStar1;
				case 1:
					return this.flag11ImageStar2;
				case 2:
					return this.flag11ImageStar3;
				case 3:
					return this.flag11ImageStar4;
				case 4:
					return this.flag11ImageStar5;
				}
				break;
			case 12:
				switch (star)
				{
				case 0:
					return this.flag12ImageStar1;
				case 1:
					return this.flag12ImageStar2;
				case 2:
					return this.flag12ImageStar3;
				case 3:
					return this.flag12ImageStar4;
				case 4:
					return this.flag12ImageStar5;
				}
				break;
			case 13:
				switch (star)
				{
				case 0:
					return this.flag13ImageStar1;
				case 1:
					return this.flag13ImageStar2;
				case 2:
					return this.flag13ImageStar3;
				case 3:
					return this.flag13ImageStar4;
				case 4:
					return this.flag13ImageStar5;
				}
				break;
			case 14:
				switch (star)
				{
				case 0:
					return this.flag14ImageStar1;
				case 1:
					return this.flag14ImageStar2;
				case 2:
					return this.flag14ImageStar3;
				case 3:
					return this.flag14ImageStar4;
				case 4:
					return this.flag14ImageStar5;
				}
				break;
			case 15:
				switch (star)
				{
				case 0:
					return this.flag15ImageStar1;
				case 1:
					return this.flag15ImageStar2;
				case 2:
					return this.flag15ImageStar3;
				case 3:
					return this.flag15ImageStar4;
				case 4:
					return this.flag15ImageStar5;
				}
				break;
			case 16:
				switch (star)
				{
				case 0:
					return this.flag16ImageStar1;
				case 1:
					return this.flag16ImageStar2;
				case 2:
					return this.flag16ImageStar3;
				case 3:
					return this.flag16ImageStar4;
				case 4:
					return this.flag16ImageStar5;
				}
				break;
			case 17:
				switch (star)
				{
				case 0:
					return this.flag17ImageStar1;
				case 1:
					return this.flag17ImageStar2;
				case 2:
					return this.flag17ImageStar3;
				case 3:
					return this.flag17ImageStar4;
				case 4:
					return this.flag17ImageStar5;
				}
				break;
			case 18:
				switch (star)
				{
				case 0:
					return this.flag18ImageStar1;
				case 1:
					return this.flag18ImageStar2;
				case 2:
					return this.flag18ImageStar3;
				case 3:
					return this.flag18ImageStar4;
				case 4:
					return this.flag18ImageStar5;
				}
				break;
			case 19:
				switch (star)
				{
				case 0:
					return this.flag19ImageStar1;
				case 1:
					return this.flag19ImageStar2;
				case 2:
					return this.flag19ImageStar3;
				case 3:
					return this.flag19ImageStar4;
				case 4:
					return this.flag19ImageStar5;
				}
				break;
			}
			return this.flag0ImageStar1;
		}

		// Token: 0x0600137C RID: 4988 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x0600137D RID: 4989 RVA: 0x00015383 File Offset: 0x00013583
		public void GetHouseGloryPointsCallBack(GetHouseGloryPoints_ReturnType returnData)
		{
			if (returnData.Success)
			{
				GameEngine.Instance.World.HouseGloryPoints = returnData.gloryPoints;
				GameEngine.Instance.World.HouseGloryRoundData = returnData.gloryRoundData;
				this.init();
			}
		}

		// Token: 0x0600137E RID: 4990 RVA: 0x0014C4EC File Offset: 0x0014A6EC
		public void viewHouse()
		{
			if (this.ClickedControl != null)
			{
				int data = this.ClickedControl.Data;
				InterfaceMgr.Instance.showHousePanel(data);
			}
		}

		// Token: 0x0600137F RID: 4991 RVA: 0x000153BD File Offset: 0x000135BD
		public void gloryWinnerClick()
		{
			InterfaceMgr.Instance.openGloryVictoryPopup();
		}

		// Token: 0x06001380 RID: 4992 RVA: 0x000153C9 File Offset: 0x000135C9
		public void viewEndWorldPanelClick()
		{
			InterfaceMgr.Instance.setVillageTabSubMode(65, false);
		}

		// Token: 0x06001381 RID: 4993 RVA: 0x000153D8 File Offset: 0x000135D8
		public void playbackCountryClick()
		{
			this.playbackIsCountry = true;
			if (GameEngine.Instance.World.gotPlaybackData())
			{
				GameEngine.Instance.World.playbackCountries();
				return;
			}
			this.awaitingPlayback = true;
			this.retrieveGameStats();
		}

		// Token: 0x06001382 RID: 4994 RVA: 0x0001540F File Offset: 0x0001360F
		public void playbackProvinceClick()
		{
			this.playbackIsCountry = false;
			if (GameEngine.Instance.World.gotPlaybackData())
			{
				GameEngine.Instance.World.playbackProvinces();
				return;
			}
			this.awaitingPlayback = true;
			this.retrieveGameStats();
		}

		// Token: 0x06001383 RID: 4995 RVA: 0x00015446 File Offset: 0x00013646
		public void gloryValuesClick()
		{
			InterfaceMgr.Instance.openGloryValuesPopup();
		}

		// Token: 0x06001384 RID: 4996 RVA: 0x00015452 File Offset: 0x00013652
		public void retrieveGameStats()
		{
			if (!this.bAwaitingStats)
			{
				this.bAwaitingStats = true;
				RemoteServices.Instance.set_RetrieveStats2_UserCallBack(new RemoteServices.RetrieveStats2_UserCallBack(this.retrieveStatsCallback2));
				RemoteServices.Instance.RetrieveStats2();
			}
		}

		// Token: 0x06001385 RID: 4997 RVA: 0x0014C518 File Offset: 0x0014A718
		public void retrieveStatsCallback2(RetrieveStats2_ReturnType returnData)
		{
			if (returnData.Success && returnData.mapHistoryData != null)
			{
				RetrieveStats_ReturnType retrieveStats_ReturnType = new RetrieveStats_ReturnType();
				retrieveStats_ReturnType.Success = true;
				retrieveStats_ReturnType.worldStartTime = returnData.worldStartTime;
				retrieveStats_ReturnType.mapHistory = new List<WorldHouseHistoryItem>();
				for (int i = 0; i < returnData.mapHistoryData.Length; i += 7)
				{
					WorldHouseHistoryItem worldHouseHistoryItem = new WorldHouseHistoryItem();
					worldHouseHistoryItem.houseID = (int)returnData.mapHistoryData[i];
					if (returnData.mapHistoryData[i + 1] == 255 && returnData.mapHistoryData[i + 2] == 255)
					{
						worldHouseHistoryItem.provinceID = -1;
					}
					else
					{
						worldHouseHistoryItem.provinceID = (int)returnData.mapHistoryData[i + 1] * 256 + (int)returnData.mapHistoryData[i + 2];
					}
					if (returnData.mapHistoryData[i + 3] == 255 && returnData.mapHistoryData[i + 4] == 255)
					{
						worldHouseHistoryItem.countryID = -1;
					}
					else
					{
						worldHouseHistoryItem.countryID = (int)returnData.mapHistoryData[i + 3] * 256 + (int)returnData.mapHistoryData[i + 4];
					}
					int num = (int)returnData.mapHistoryData[i + 5] * 256 + (int)returnData.mapHistoryData[i + 6];
					worldHouseHistoryItem.date = returnData.worldStartTime.AddDays((double)num);
					retrieveStats_ReturnType.mapHistory.Add(worldHouseHistoryItem);
				}
				this.retrieveStatsCallback(retrieveStats_ReturnType);
			}
			this.bAwaitingStats = false;
		}

		// Token: 0x06001386 RID: 4998 RVA: 0x0014C670 File Offset: 0x0014A870
		public void retrieveStatsCallback(RetrieveStats_ReturnType returnData)
		{
			if (returnData.Success && returnData.mapHistory != null)
			{
				GameEngine.Instance.World.setPlaybackData(returnData.mapHistory, returnData.worldStartTime);
				if (this.awaitingPlayback)
				{
					this.awaitingPlayback = false;
					if (this.playbackIsCountry)
					{
						GameEngine.Instance.World.playbackCountries();
					}
					else
					{
						GameEngine.Instance.World.playbackProvinces();
					}
				}
			}
			this.bAwaitingStats = false;
		}

		// Token: 0x06001387 RID: 4999 RVA: 0x00015483 File Offset: 0x00013683
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06001388 RID: 5000 RVA: 0x00015493 File Offset: 0x00013693
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06001389 RID: 5001 RVA: 0x000154A3 File Offset: 0x000136A3
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x0600138A RID: 5002 RVA: 0x000154B5 File Offset: 0x000136B5
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x0600138B RID: 5003 RVA: 0x000154C2 File Offset: 0x000136C2
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
		}

		// Token: 0x0600138C RID: 5004 RVA: 0x000154D6 File Offset: 0x000136D6
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x0600138D RID: 5005 RVA: 0x000154E3 File Offset: 0x000136E3
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x0600138E RID: 5006 RVA: 0x000154F0 File Offset: 0x000136F0
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600138F RID: 5007 RVA: 0x0014C6E8 File Offset: 0x0014A8E8
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.MaximumSize = new Size(1600, 1024);
			this.MinimumSize = new Size(992, 566);
			base.Name = "GloryPanel";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x040023C3 RID: 9155
		private const int VERT_XPOS = 65;

		// Token: 0x040023C4 RID: 9156
		private const int VERT_XPOS2 = 59;

		// Token: 0x040023C5 RID: 9157
		private const int VERT_XPOS3 = 59;

		// Token: 0x040023C6 RID: 9158
		private const int NUM_BANDS = 15;

		// Token: 0x040023C7 RID: 9159
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040023C8 RID: 9160
		private CustomSelfDrawPanel.CSDArea viewableArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040023C9 RID: 9161
		private CustomSelfDrawPanel.CSDLine scaleVertLine = new CustomSelfDrawPanel.CSDLine();

		// Token: 0x040023CA RID: 9162
		private CustomSelfDrawPanel.CSDLine scaleMark0Line = new CustomSelfDrawPanel.CSDLine();

		// Token: 0x040023CB RID: 9163
		private CustomSelfDrawPanel.CSDLine scaleMark100Line = new CustomSelfDrawPanel.CSDLine();

		// Token: 0x040023CC RID: 9164
		private CustomSelfDrawPanel.CSDLine scaleMark1000Line = new CustomSelfDrawPanel.CSDLine();

		// Token: 0x040023CD RID: 9165
		private CustomSelfDrawPanel.CSDLine scaleMark10000Line = new CustomSelfDrawPanel.CSDLine();

		// Token: 0x040023CE RID: 9166
		private CustomSelfDrawPanel.CSDLine scaleMark100000Line = new CustomSelfDrawPanel.CSDLine();

		// Token: 0x040023CF RID: 9167
		private CustomSelfDrawPanel.CSDLine scaleMark1000000Line = new CustomSelfDrawPanel.CSDLine();

		// Token: 0x040023D0 RID: 9168
		private CustomSelfDrawPanel.CSDLine topLine = new CustomSelfDrawPanel.CSDLine();

		// Token: 0x040023D1 RID: 9169
		private CustomSelfDrawPanel.CSDLine bottomLine = new CustomSelfDrawPanel.CSDLine();

		// Token: 0x040023D2 RID: 9170
		private CustomSelfDrawPanel.CSDLine scaleVertLineS = new CustomSelfDrawPanel.CSDLine();

		// Token: 0x040023D3 RID: 9171
		private CustomSelfDrawPanel.CSDLine scaleMark0LineS = new CustomSelfDrawPanel.CSDLine();

		// Token: 0x040023D4 RID: 9172
		private CustomSelfDrawPanel.CSDLine scaleMark100LineS = new CustomSelfDrawPanel.CSDLine();

		// Token: 0x040023D5 RID: 9173
		private CustomSelfDrawPanel.CSDLine scaleMark1000LineS = new CustomSelfDrawPanel.CSDLine();

		// Token: 0x040023D6 RID: 9174
		private CustomSelfDrawPanel.CSDLine scaleMark10000LineS = new CustomSelfDrawPanel.CSDLine();

		// Token: 0x040023D7 RID: 9175
		private CustomSelfDrawPanel.CSDLine scaleMark100000LineS = new CustomSelfDrawPanel.CSDLine();

		// Token: 0x040023D8 RID: 9176
		private CustomSelfDrawPanel.CSDLine scaleMark1000000LineS = new CustomSelfDrawPanel.CSDLine();

		// Token: 0x040023D9 RID: 9177
		private CustomSelfDrawPanel.CSDLine topLineS = new CustomSelfDrawPanel.CSDLine();

		// Token: 0x040023DA RID: 9178
		private CustomSelfDrawPanel.CSDLine bottomLineS = new CustomSelfDrawPanel.CSDLine();

		// Token: 0x040023DB RID: 9179
		private CustomSelfDrawPanel.CSDLabel mark0Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040023DC RID: 9180
		private CustomSelfDrawPanel.CSDLabel mark100Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040023DD RID: 9181
		private CustomSelfDrawPanel.CSDLabel mark1000Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040023DE RID: 9182
		private CustomSelfDrawPanel.CSDLabel mark10000Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040023DF RID: 9183
		private CustomSelfDrawPanel.CSDLabel mark100000Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040023E0 RID: 9184
		private CustomSelfDrawPanel.CSDLabel mark1000000Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040023E1 RID: 9185
		private CustomSelfDrawPanel.CSDImage flagImage0 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040023E2 RID: 9186
		private CustomSelfDrawPanel.CSDImage flagImage1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040023E3 RID: 9187
		private CustomSelfDrawPanel.CSDImage flagImage2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040023E4 RID: 9188
		private CustomSelfDrawPanel.CSDImage flagImage3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040023E5 RID: 9189
		private CustomSelfDrawPanel.CSDImage flagImage4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040023E6 RID: 9190
		private CustomSelfDrawPanel.CSDImage flagImage5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040023E7 RID: 9191
		private CustomSelfDrawPanel.CSDImage flagImage6 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040023E8 RID: 9192
		private CustomSelfDrawPanel.CSDImage flagImage7 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040023E9 RID: 9193
		private CustomSelfDrawPanel.CSDImage flagImage8 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040023EA RID: 9194
		private CustomSelfDrawPanel.CSDImage flagImage9 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040023EB RID: 9195
		private CustomSelfDrawPanel.CSDImage flagImage10 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040023EC RID: 9196
		private CustomSelfDrawPanel.CSDImage flagImage11 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040023ED RID: 9197
		private CustomSelfDrawPanel.CSDImage flagImage12 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040023EE RID: 9198
		private CustomSelfDrawPanel.CSDImage flagImage13 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040023EF RID: 9199
		private CustomSelfDrawPanel.CSDImage flagImage14 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040023F0 RID: 9200
		private CustomSelfDrawPanel.CSDImage flagImage15 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040023F1 RID: 9201
		private CustomSelfDrawPanel.CSDImage flagImage16 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040023F2 RID: 9202
		private CustomSelfDrawPanel.CSDImage flagImage17 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040023F3 RID: 9203
		private CustomSelfDrawPanel.CSDImage flagImage18 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040023F4 RID: 9204
		private CustomSelfDrawPanel.CSDImage flagImage19 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040023F5 RID: 9205
		private CustomSelfDrawPanel.CSDImage flagpoleImage0 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040023F6 RID: 9206
		private CustomSelfDrawPanel.CSDImage flagpoleImage1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040023F7 RID: 9207
		private CustomSelfDrawPanel.CSDImage flagpoleImage2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040023F8 RID: 9208
		private CustomSelfDrawPanel.CSDImage flagpoleImage3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040023F9 RID: 9209
		private CustomSelfDrawPanel.CSDImage flagpoleImage4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040023FA RID: 9210
		private CustomSelfDrawPanel.CSDImage flagpoleImage5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040023FB RID: 9211
		private CustomSelfDrawPanel.CSDImage flagpoleImage6 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040023FC RID: 9212
		private CustomSelfDrawPanel.CSDImage flagpoleImage7 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040023FD RID: 9213
		private CustomSelfDrawPanel.CSDImage flagpoleImage8 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040023FE RID: 9214
		private CustomSelfDrawPanel.CSDImage flagpoleImage9 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040023FF RID: 9215
		private CustomSelfDrawPanel.CSDImage flagpoleImage10 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002400 RID: 9216
		private CustomSelfDrawPanel.CSDImage flagpoleImage11 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002401 RID: 9217
		private CustomSelfDrawPanel.CSDImage flagpoleImage12 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002402 RID: 9218
		private CustomSelfDrawPanel.CSDImage flagpoleImage13 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002403 RID: 9219
		private CustomSelfDrawPanel.CSDImage flagpoleImage14 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002404 RID: 9220
		private CustomSelfDrawPanel.CSDImage flagpoleImage15 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002405 RID: 9221
		private CustomSelfDrawPanel.CSDImage flagpoleImage16 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002406 RID: 9222
		private CustomSelfDrawPanel.CSDImage flagpoleImage17 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002407 RID: 9223
		private CustomSelfDrawPanel.CSDImage flagpoleImage18 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002408 RID: 9224
		private CustomSelfDrawPanel.CSDImage flagpoleImage19 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002409 RID: 9225
		private CustomSelfDrawPanel.CSDImage flag0ImageStar1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400240A RID: 9226
		private CustomSelfDrawPanel.CSDImage flag0ImageStar2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400240B RID: 9227
		private CustomSelfDrawPanel.CSDImage flag0ImageStar3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400240C RID: 9228
		private CustomSelfDrawPanel.CSDImage flag0ImageStar4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400240D RID: 9229
		private CustomSelfDrawPanel.CSDImage flag0ImageStar5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400240E RID: 9230
		private CustomSelfDrawPanel.CSDImage flag1ImageStar1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400240F RID: 9231
		private CustomSelfDrawPanel.CSDImage flag1ImageStar2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002410 RID: 9232
		private CustomSelfDrawPanel.CSDImage flag1ImageStar3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002411 RID: 9233
		private CustomSelfDrawPanel.CSDImage flag1ImageStar4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002412 RID: 9234
		private CustomSelfDrawPanel.CSDImage flag1ImageStar5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002413 RID: 9235
		private CustomSelfDrawPanel.CSDImage flag2ImageStar1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002414 RID: 9236
		private CustomSelfDrawPanel.CSDImage flag2ImageStar2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002415 RID: 9237
		private CustomSelfDrawPanel.CSDImage flag2ImageStar3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002416 RID: 9238
		private CustomSelfDrawPanel.CSDImage flag2ImageStar4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002417 RID: 9239
		private CustomSelfDrawPanel.CSDImage flag2ImageStar5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002418 RID: 9240
		private CustomSelfDrawPanel.CSDImage flag3ImageStar1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002419 RID: 9241
		private CustomSelfDrawPanel.CSDImage flag3ImageStar2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400241A RID: 9242
		private CustomSelfDrawPanel.CSDImage flag3ImageStar3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400241B RID: 9243
		private CustomSelfDrawPanel.CSDImage flag3ImageStar4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400241C RID: 9244
		private CustomSelfDrawPanel.CSDImage flag3ImageStar5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400241D RID: 9245
		private CustomSelfDrawPanel.CSDImage flag4ImageStar1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400241E RID: 9246
		private CustomSelfDrawPanel.CSDImage flag4ImageStar2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400241F RID: 9247
		private CustomSelfDrawPanel.CSDImage flag4ImageStar3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002420 RID: 9248
		private CustomSelfDrawPanel.CSDImage flag4ImageStar4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002421 RID: 9249
		private CustomSelfDrawPanel.CSDImage flag4ImageStar5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002422 RID: 9250
		private CustomSelfDrawPanel.CSDImage flag5ImageStar1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002423 RID: 9251
		private CustomSelfDrawPanel.CSDImage flag5ImageStar2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002424 RID: 9252
		private CustomSelfDrawPanel.CSDImage flag5ImageStar3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002425 RID: 9253
		private CustomSelfDrawPanel.CSDImage flag5ImageStar4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002426 RID: 9254
		private CustomSelfDrawPanel.CSDImage flag5ImageStar5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002427 RID: 9255
		private CustomSelfDrawPanel.CSDImage flag6ImageStar1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002428 RID: 9256
		private CustomSelfDrawPanel.CSDImage flag6ImageStar2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002429 RID: 9257
		private CustomSelfDrawPanel.CSDImage flag6ImageStar3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400242A RID: 9258
		private CustomSelfDrawPanel.CSDImage flag6ImageStar4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400242B RID: 9259
		private CustomSelfDrawPanel.CSDImage flag6ImageStar5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400242C RID: 9260
		private CustomSelfDrawPanel.CSDImage flag7ImageStar1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400242D RID: 9261
		private CustomSelfDrawPanel.CSDImage flag7ImageStar2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400242E RID: 9262
		private CustomSelfDrawPanel.CSDImage flag7ImageStar3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400242F RID: 9263
		private CustomSelfDrawPanel.CSDImage flag7ImageStar4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002430 RID: 9264
		private CustomSelfDrawPanel.CSDImage flag7ImageStar5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002431 RID: 9265
		private CustomSelfDrawPanel.CSDImage flag8ImageStar1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002432 RID: 9266
		private CustomSelfDrawPanel.CSDImage flag8ImageStar2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002433 RID: 9267
		private CustomSelfDrawPanel.CSDImage flag8ImageStar3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002434 RID: 9268
		private CustomSelfDrawPanel.CSDImage flag8ImageStar4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002435 RID: 9269
		private CustomSelfDrawPanel.CSDImage flag8ImageStar5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002436 RID: 9270
		private CustomSelfDrawPanel.CSDImage flag9ImageStar1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002437 RID: 9271
		private CustomSelfDrawPanel.CSDImage flag9ImageStar2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002438 RID: 9272
		private CustomSelfDrawPanel.CSDImage flag9ImageStar3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002439 RID: 9273
		private CustomSelfDrawPanel.CSDImage flag9ImageStar4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400243A RID: 9274
		private CustomSelfDrawPanel.CSDImage flag9ImageStar5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400243B RID: 9275
		private CustomSelfDrawPanel.CSDImage flag10ImageStar1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400243C RID: 9276
		private CustomSelfDrawPanel.CSDImage flag10ImageStar2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400243D RID: 9277
		private CustomSelfDrawPanel.CSDImage flag10ImageStar3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400243E RID: 9278
		private CustomSelfDrawPanel.CSDImage flag10ImageStar4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400243F RID: 9279
		private CustomSelfDrawPanel.CSDImage flag10ImageStar5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002440 RID: 9280
		private CustomSelfDrawPanel.CSDImage flag11ImageStar1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002441 RID: 9281
		private CustomSelfDrawPanel.CSDImage flag11ImageStar2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002442 RID: 9282
		private CustomSelfDrawPanel.CSDImage flag11ImageStar3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002443 RID: 9283
		private CustomSelfDrawPanel.CSDImage flag11ImageStar4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002444 RID: 9284
		private CustomSelfDrawPanel.CSDImage flag11ImageStar5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002445 RID: 9285
		private CustomSelfDrawPanel.CSDImage flag12ImageStar1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002446 RID: 9286
		private CustomSelfDrawPanel.CSDImage flag12ImageStar2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002447 RID: 9287
		private CustomSelfDrawPanel.CSDImage flag12ImageStar3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002448 RID: 9288
		private CustomSelfDrawPanel.CSDImage flag12ImageStar4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002449 RID: 9289
		private CustomSelfDrawPanel.CSDImage flag12ImageStar5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400244A RID: 9290
		private CustomSelfDrawPanel.CSDImage flag13ImageStar1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400244B RID: 9291
		private CustomSelfDrawPanel.CSDImage flag13ImageStar2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400244C RID: 9292
		private CustomSelfDrawPanel.CSDImage flag13ImageStar3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400244D RID: 9293
		private CustomSelfDrawPanel.CSDImage flag13ImageStar4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400244E RID: 9294
		private CustomSelfDrawPanel.CSDImage flag13ImageStar5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400244F RID: 9295
		private CustomSelfDrawPanel.CSDImage flag14ImageStar1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002450 RID: 9296
		private CustomSelfDrawPanel.CSDImage flag14ImageStar2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002451 RID: 9297
		private CustomSelfDrawPanel.CSDImage flag14ImageStar3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002452 RID: 9298
		private CustomSelfDrawPanel.CSDImage flag14ImageStar4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002453 RID: 9299
		private CustomSelfDrawPanel.CSDImage flag14ImageStar5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002454 RID: 9300
		private CustomSelfDrawPanel.CSDImage flag15ImageStar1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002455 RID: 9301
		private CustomSelfDrawPanel.CSDImage flag15ImageStar2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002456 RID: 9302
		private CustomSelfDrawPanel.CSDImage flag15ImageStar3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002457 RID: 9303
		private CustomSelfDrawPanel.CSDImage flag15ImageStar4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002458 RID: 9304
		private CustomSelfDrawPanel.CSDImage flag15ImageStar5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002459 RID: 9305
		private CustomSelfDrawPanel.CSDImage flag16ImageStar1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400245A RID: 9306
		private CustomSelfDrawPanel.CSDImage flag16ImageStar2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400245B RID: 9307
		private CustomSelfDrawPanel.CSDImage flag16ImageStar3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400245C RID: 9308
		private CustomSelfDrawPanel.CSDImage flag16ImageStar4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400245D RID: 9309
		private CustomSelfDrawPanel.CSDImage flag16ImageStar5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400245E RID: 9310
		private CustomSelfDrawPanel.CSDImage flag17ImageStar1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400245F RID: 9311
		private CustomSelfDrawPanel.CSDImage flag17ImageStar2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002460 RID: 9312
		private CustomSelfDrawPanel.CSDImage flag17ImageStar3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002461 RID: 9313
		private CustomSelfDrawPanel.CSDImage flag17ImageStar4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002462 RID: 9314
		private CustomSelfDrawPanel.CSDImage flag17ImageStar5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002463 RID: 9315
		private CustomSelfDrawPanel.CSDImage flag18ImageStar1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002464 RID: 9316
		private CustomSelfDrawPanel.CSDImage flag18ImageStar2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002465 RID: 9317
		private CustomSelfDrawPanel.CSDImage flag18ImageStar3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002466 RID: 9318
		private CustomSelfDrawPanel.CSDImage flag18ImageStar4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002467 RID: 9319
		private CustomSelfDrawPanel.CSDImage flag18ImageStar5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002468 RID: 9320
		private CustomSelfDrawPanel.CSDImage flag19ImageStar1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002469 RID: 9321
		private CustomSelfDrawPanel.CSDImage flag19ImageStar2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400246A RID: 9322
		private CustomSelfDrawPanel.CSDImage flag19ImageStar3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400246B RID: 9323
		private CustomSelfDrawPanel.CSDImage flag19ImageStar4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400246C RID: 9324
		private CustomSelfDrawPanel.CSDImage flag19ImageStar5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400246D RID: 9325
		private CustomSelfDrawPanel.CSDButton gloryWinnerButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400246E RID: 9326
		private CustomSelfDrawPanel.CSDButton playbackCountryButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400246F RID: 9327
		private CustomSelfDrawPanel.CSDButton playbackProvinceButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002470 RID: 9328
		private CustomSelfDrawPanel.CSDButton gloryValuesButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002471 RID: 9329
		private CustomSelfDrawPanel.CSDButton endOfTheWorldButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002472 RID: 9330
		private CustomSelfDrawPanel.CSDLabel gloryRoundEnding = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002473 RID: 9331
		private CustomSelfDrawPanel.CSDImage eraStar = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002474 RID: 9332
		private CustomSelfDrawPanel.CSDLabel eraStarText = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002475 RID: 9333
		private int[] markPositionPercents = new int[]
		{
			0,
			10,
			15,
			20,
			25,
			30
		};

		// Token: 0x04002476 RID: 9334
		private int bandYPos0;

		// Token: 0x04002477 RID: 9335
		private int bandYPos100;

		// Token: 0x04002478 RID: 9336
		private int bandYPos1000;

		// Token: 0x04002479 RID: 9337
		private int bandYPos10000;

		// Token: 0x0400247A RID: 9338
		private int bandYPos100000;

		// Token: 0x0400247B RID: 9339
		private int bandYPos1000000;

		// Token: 0x0400247C RID: 9340
		private bool awaitingPlayback;

		// Token: 0x0400247D RID: 9341
		private bool playbackIsCountry;

		// Token: 0x0400247E RID: 9342
		private int[,] lastHousePoints = new int[20, 2];

		// Token: 0x0400247F RID: 9343
		private int[] starSteps = new int[]
		{
			0,
			-1,
			1,
			-2,
			2
		};

		// Token: 0x04002480 RID: 9344
		private bool secondAge;

		// Token: 0x04002481 RID: 9345
		private bool thirdAge;

		// Token: 0x04002482 RID: 9346
		private bool sixthAge;

		// Token: 0x04002483 RID: 9347
		private int[] bands = new int[]
		{
			0,
			0,
			1,
			19,
			0,
			0,
			2,
			18,
			0,
			1,
			1,
			18,
			0,
			1,
			2,
			17,
			0,
			1,
			3,
			16,
			0,
			1,
			4,
			15,
			0,
			1,
			5,
			14,
			0,
			1,
			6,
			13,
			0,
			2,
			6,
			12,
			1,
			2,
			6,
			11,
			1,
			3,
			6,
			10,
			1,
			4,
			6,
			9,
			1,
			5,
			6,
			8,
			1,
			6,
			6,
			7,
			2,
			6,
			6,
			6
		};

		// Token: 0x04002484 RID: 9348
		private int[][] filledBands = new int[15][];

		// Token: 0x04002485 RID: 9349
		private bool bandsMade;

		// Token: 0x04002486 RID: 9350
		private int[] readOrder = new int[]
		{
			18,
			16,
			14,
			12,
			10,
			8,
			6,
			4,
			2,
			0,
			1,
			3,
			5,
			7,
			9,
			11,
			13,
			15,
			17,
			19
		};

		// Token: 0x04002487 RID: 9351
		private bool bAwaitingStats;

		// Token: 0x04002488 RID: 9352
		private DockableControl dockableControl;

		// Token: 0x04002489 RID: 9353
		private IContainer components;
	}
}
