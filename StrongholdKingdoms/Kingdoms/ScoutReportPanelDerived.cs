using System;
using System.Drawing;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x0200047D RID: 1149
	internal class ScoutReportPanelDerived : GenericReportPanelBasic
	{
		// Token: 0x060029BE RID: 10686 RVA: 0x002044DC File Offset: 0x002026DC
		public override void init(IDockableControl parent, Size size, object back)
		{
			base.init(parent, size, back);
			this.btnViewCastle.ImageNorm = GFXLibrary.button_132_normal;
			this.btnViewCastle.ImageOver = GFXLibrary.button_132_over;
			this.btnViewCastle.ImageClick = GFXLibrary.button_132_in;
			this.btnViewCastle.setSizeToImage();
			this.btnViewCastle.Position = new Point(this.btnForward.Position.X, this.btnUtility.Position.Y - this.btnViewCastle.Height - 2);
			this.btnViewCastle.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.btnViewCastle.TextYOffset = -2;
			this.btnViewCastle.Text.Color = global::ARGBColors.Black;
			this.btnViewCastle.Enabled = true;
			this.btnViewCastle.Visible = false;
			this.btnViewCastle.Text.Text = SK.Text("Reports_View_Castle", "View Castle");
			this.btnViewCastle.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.viewCastleClick), "Reports_View_Castle");
			this.btnUtility.Text.Text = SK.Text("Reports_Show_On_Map", "Show On Map");
			this.lblResult.Color = global::ARGBColors.Black;
			this.lblResult.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
			this.lblResult.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.lblResult.Position = new Point(20, this.lblSecondaryText.Rectangle.Bottom);
			this.lblResult.Size = new Size(base.Width - 40, 26);
			this.lblDate.Y = this.lblResult.Rectangle.Bottom;
			this.lblScouts.Text = SK.Text("GENERIC_Scouts", "Scouts");
			this.lblScouts.Color = global::ARGBColors.Black;
			this.lblScouts.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.lblScouts.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.lblScouts.Position = new Point(this.borderOffset, this.lblDate.Rectangle.Bottom + 5);
			this.lblScouts.Size = new Size(base.Width - this.borderOffset * 2, 26);
			this.lblScouts.Visible = false;
			this.lblWolves.Color = global::ARGBColors.Black;
			this.lblWolves.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.lblWolves.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.lblWolves.Position = new Point(this.borderOffset, this.lblScouts.Y + 30);
			this.lblWolves.Size = new Size(base.Width - this.borderOffset * 2, 26);
			this.lblWolves.Visible = false;
			this.lblHonour.Color = global::ARGBColors.Black;
			this.lblHonour.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.lblHonour.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.lblHonour.Position = new Point(this.borderOffset, this.btnDelete.Y);
			this.lblHonour.Size = new Size(base.Width - this.borderOffset * 2, 26);
			this.lblHonour.Visible = false;
			if (base.hasBackground())
			{
				this.imgBackground.addControl(this.lblScouts);
				this.imgBackground.addControl(this.lblResult);
				this.imgBackground.addControl(this.btnViewCastle);
				this.imgBackground.addControl(this.lblHonour);
				this.imgBackground.addControl(this.lblWolves);
				return;
			}
			base.addControl(this.lblScouts);
			base.addControl(this.lblResult);
			base.addControl(this.btnViewCastle);
			base.addControl(this.lblHonour);
			base.addControl(this.lblWolves);
		}

		// Token: 0x060029BF RID: 10687 RVA: 0x0020491C File Offset: 0x00202B1C
		public override void setData(GetReport_ReturnType returnData)
		{
			base.setData(returnData);
			bool flag = true;
			bool flag2 = false;
			this.lblResult.Text = SK.Text("GENERIC_The_Attacker_Wins", "The Attacker Wins");
			short reportType = returnData.reportType;
			if (reportType <= 57)
			{
				switch (reportType)
				{
				case 21:
				case 26:
				case 27:
					break;
				case 22:
				{
					this.btnViewCastle.Visible = false;
					if (returnData.otherUser.Length == 0)
					{
						this.lblMainText.Text = SK.Text("GENERIC_An_Unknown_Player", "An Unknown Player");
					}
					else
					{
						this.lblMainText.Text = returnData.otherUser;
					}
					CustomSelfDrawPanel.CSDLabel lblMainText = this.lblMainText;
					lblMainText.Text = lblMainText.Text + " (" + GameEngine.Instance.World.getVillageName(returnData.attackingVillage) + ")";
					this.lblSubTitle.Text = SK.Text("Reports_Scouts_Out", "Scouts");
					if (returnData.otherUser.Length == 0)
					{
						this.lblSecondaryText.Text = SK.Text("GENERIC_An_Empty_Village", "An empty village");
					}
					else
					{
						this.lblSecondaryText.Text = this.reportOwner + " (" + GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + ")";
					}
					if (!returnData.successStatus)
					{
						this.lblResult.Text = SK.Text("GENERIC_The_Defender_Wins", "The Defender Wins");
						goto IL_6E0;
					}
					goto IL_6E0;
				}
				case 23:
					this.lblMainText.Text = this.reportOwner + " (" + GameEngine.Instance.World.getVillageName(returnData.attackingVillage) + ")";
					this.lblSubTitle.Text = SK.Text("Reports_Forages", "Forages");
					this.lblResult.Visible = false;
					if (returnData.genericData6 > 0)
					{
						this.lblResult.Text = SK.Text("SeasonalBonus", "Seasonal Bonus");
						this.lblResult.Visible = true;
						this.lblDate.Y -= 50;
						this.lblHonour.Y -= 50;
						this.lblResult.Y += 35;
						this.lblResult.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
						int genericData = returnData.genericData6;
						if (genericData != 2)
						{
							if (genericData != 3)
							{
								this.lblScouts.Text = SK.Text("REPORTS_SeasonalWheelSpins1", "Tier 1 Wheel Spin");
							}
							else
							{
								this.lblScouts.Text = SK.Text("REPORTS_SeasonalWheelSpins3", "Tier 3 Wheel Spin");
							}
						}
						else
						{
							this.lblScouts.Text = SK.Text("REPORTS_SeasonalWheelSpins2", "Tier 2 Wheel Spin");
						}
						this.lblScouts.Position = this.lblResult.Position;
						this.lblScouts.Y += 22;
						this.lblScouts.Size = this.lblResult.Size;
						this.lblScouts.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
						this.lblScouts.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
						this.lblScouts.Visible = true;
						flag = false;
						flag2 = true;
						goto IL_6E0;
					}
					goto IL_6E0;
				case 24:
				case 25:
					goto IL_6E0;
				default:
					if (reportType - 54 > 3)
					{
						goto IL_6E0;
					}
					break;
				}
			}
			else if (reportType - 121 > 1 && reportType != 126 && reportType != 133)
			{
				goto IL_6E0;
			}
			this.lblMainText.Text = this.reportOwner + " (" + GameEngine.Instance.World.getVillageName(returnData.attackingVillage) + ")";
			this.lblSubTitle.Text = SK.Text("Reports_Scouts_Out", "Scouts");
			if (returnData.otherUser.Length == 0)
			{
				if (returnData.reportType == 21)
				{
					if (returnData.defendingVillage < 0)
					{
						this.lblSecondaryText.Text = SK.Text("GENERIC_An_Empty_Village", "An empty village");
					}
					else
					{
						this.lblSecondaryText.Text = GameEngine.Instance.World.getVillageName(returnData.defendingVillage);
					}
				}
				else if (returnData.reportType == 26)
				{
					this.lblSecondaryText.Text = SK.Text("GENERIC_A_Bandit_Camp", "A Bandit Camp");
				}
				else if (returnData.reportType == 27)
				{
					this.lblSecondaryText.Text = SK.Text("GENERIC_A_Wolf_Lair", "A Wolf Lair");
				}
				else if (returnData.reportType == 54)
				{
					this.lblSecondaryText.Text = SK.Text("GENERIC_Rats_Castle", "Rat's Castle");
				}
				else if (returnData.reportType == 55)
				{
					this.lblSecondaryText.Text = SK.Text("GENERIC_Snakes_Castle", "Snake's Castle");
				}
				else if (returnData.reportType == 56)
				{
					this.lblSecondaryText.Text = SK.Text("GENERIC_Pigs_Castle", "Pig's Castle");
				}
				else if (returnData.reportType == 57)
				{
					this.lblSecondaryText.Text = SK.Text("GENERIC_Wolfs_Castle", "Wolf's Castle");
				}
				else if (returnData.reportType == 121)
				{
					this.lblSecondaryText.Text = SK.Text("GENERIC_Paladin_Castle", "Paladin's Castle");
				}
				else if (returnData.reportType == 122)
				{
					this.lblSecondaryText.Text = SK.Text("GENERIC_Paladin_Castle", "Paladin's Castle");
				}
				else if (returnData.reportType == 133)
				{
					this.lblSecondaryText.Text = SK.Text("CommonDataTypes_Royal_Tower", "Royal Tower");
				}
				else if (returnData.reportType == 126)
				{
					this.lblSecondaryText.Text = string.Concat(new string[]
					{
						SK.Text("GENERIC_Treasure_Castle", "Treasure Castle"),
						" ",
						SK.Text("GENERIC_TREASURE_CASTLE_LEVEL", "Level"),
						" : ",
						(returnData.genericData31 + 1).ToString()
					});
					this.lblScouts.Position = new Point(0, this.lblDate.Rectangle.Bottom + 5);
					this.lblScouts.Size = new Size(base.Width, 26);
					this.lblScouts.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
					this.lblScouts.Text = SK.Text("GENERIC_Treasure_Chests", "Treasure Chests") + " : " + returnData.genericData32.ToString();
					this.lblScouts.Visible = true;
					flag = false;
				}
			}
			else
			{
				this.lblSecondaryText.Text = returnData.otherUser + " (" + GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + ")";
			}
			if (!returnData.successStatus)
			{
				this.lblResult.Text = SK.Text("GENERIC_The_Defender_Wins", "The Defender Wins");
				this.btnViewCastle.Visible = false;
			}
			IL_6E0:
			if (returnData.reportType == 27 && returnData.genericData6 > 0)
			{
				this.lblWolves.Text = SK.Text("GENERIC_Wolves", "Wolves") + " " + returnData.genericData6.ToString();
				this.lblWolves.Visible = true;
			}
			if (returnData.defendingVillage >= 0)
			{
				this.mapTarget = GameEngine.Instance.World.getVillageLocation(returnData.defendingVillage);
				this.targetZoomLevel = 10000.0;
				this.btnUtility.Visible = true;
			}
			else
			{
				this.btnUtility.Visible = false;
			}
			if (returnData.genericData3 >= 100 && returnData.genericData3 <= 199)
			{
				this.btnViewCastle.Visible = false;
				if (!flag2)
				{
					this.lblScouts.Visible = false;
				}
				this.lblSecondaryText.Text = SpecialVillageTypes.getName(returnData.genericData3 - 100 + 100, Program.mySettings.LanguageIdent);
				switch (returnData.genericData3)
				{
				case 106:
					this.imgFurther.Image = GFXLibrary.com_32_wood;
					break;
				case 107:
					this.imgFurther.Image = GFXLibrary.com_32_stone;
					break;
				case 108:
					this.imgFurther.Image = GFXLibrary.com_32_iron;
					break;
				case 109:
					this.imgFurther.Image = GFXLibrary.com_32_pitch;
					break;
				case 112:
					this.imgFurther.Image = GFXLibrary.com_32_ale;
					break;
				case 113:
					this.imgFurther.Image = GFXLibrary.com_32_apples;
					break;
				case 114:
					this.imgFurther.Image = GFXLibrary.com_32_bread;
					break;
				case 115:
					this.imgFurther.Image = GFXLibrary.com_32_veg;
					break;
				case 116:
					this.imgFurther.Image = GFXLibrary.com_32_meat;
					break;
				case 117:
					this.imgFurther.Image = GFXLibrary.com_32_cheese;
					break;
				case 118:
					this.imgFurther.Image = GFXLibrary.com_32_fish;
					break;
				case 119:
					this.imgFurther.Image = GFXLibrary.com_32_clothing;
					break;
				case 121:
					this.imgFurther.Image = GFXLibrary.com_32_furniture;
					break;
				case 122:
					this.imgFurther.Image = GFXLibrary.com_32_venison;
					break;
				case 123:
					this.imgFurther.Image = GFXLibrary.com_32_salt;
					break;
				case 124:
					this.imgFurther.Image = GFXLibrary.com_32_spice;
					break;
				case 125:
					this.imgFurther.Image = GFXLibrary.com_32_silk;
					break;
				case 126:
					this.imgFurther.Image = GFXLibrary.com_32_metalwork;
					break;
				case 128:
					this.imgFurther.Image = GFXLibrary.com_32_pikes;
					break;
				case 129:
					this.imgFurther.Image = GFXLibrary.com_32_bows;
					break;
				case 130:
					this.imgFurther.Image = GFXLibrary.com_32_swords;
					break;
				case 131:
					this.imgFurther.Image = GFXLibrary.com_32_armour;
					break;
				case 132:
					this.imgFurther.Image = GFXLibrary.com_32_catapults;
					break;
				case 133:
					this.imgFurther.Image = GFXLibrary.com_32_wine;
					break;
				}
				this.imgFurther.setSizeToImage();
				this.imgFurther.Position = new Point(base.Width / 2 - this.imgFurther.Width, this.btnForward.Position.Y);
				this.lblFurther.Text = returnData.genericData4.ToString("N", this.nfi);
				this.lblFurther.Position = new Point(base.Width / 2, this.btnForward.Position.Y);
				this.lblFurther.Size = new Size(base.Width / 2, 26);
				this.lblFurther.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				base.showFurtherInfo();
				if (returnData.genericData5 > 0)
				{
					this.lblHonour.Text = SK.Text("GENERIC_Honour", "Honour") + " : " + returnData.genericData5.ToString();
					this.lblHonour.Visible = true;
				}
			}
			else
			{
				this.lblFurther.Visible = false;
				if (flag)
				{
					this.lblScouts.Text = string.Concat(new string[]
					{
						SK.Text("GENERIC_Scouts", "Scouts"),
						" ",
						returnData.genericData2.ToString("N", this.nfi),
						"/",
						returnData.genericData1.ToString("N", this.nfi)
					});
					this.lblScouts.Visible = true;
				}
				if (returnData.reportType != 39)
				{
					this.btnViewCastle.Visible = true;
				}
				this.imgFurther.Visible = false;
			}
			this.lblMainText.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.attackerDoubleClick), "Reports_Attacker_DClick");
			this.lblSecondaryText.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.defenderDoubleClick), "Reports_Defender_DClick");
		}

		// Token: 0x060029C0 RID: 10688 RVA: 0x002055CC File Offset: 0x002037CC
		protected override void utilityClick()
		{
			if (this.mapTarget.X != -1)
			{
				GameEngine.Instance.playInterfaceSound("ReportsGeneric_goto_map");
				InterfaceMgr.Instance.changeTab(0);
				GameEngine.Instance.World.startMultiStageZoom(this.targetZoomLevel, (double)this.mapTarget.X, (double)this.mapTarget.Y);
				this.m_parent.closeControl(true);
				InterfaceMgr.Instance.reactiveMainWindow();
			}
		}

		// Token: 0x060029C1 RID: 10689 RVA: 0x0001EB56 File Offset: 0x0001CD56
		private void viewCastleClick()
		{
			GameEngine.Instance.playInterfaceSound("ScoutReportPanel_view_castle");
			RemoteServices.Instance.set_ViewCastle_UserCallBack(new RemoteServices.ViewCastle_UserCallBack(this.viewCastleCallback));
			RemoteServices.Instance.ViewCastle_Report(this.reportID);
		}

		// Token: 0x060029C2 RID: 10690 RVA: 0x00205644 File Offset: 0x00203844
		private void viewCastleCallback(ViewCastle_ReturnType returnData)
		{
			if (returnData.Success && (returnData.castleMapSnapshot != null || returnData.castleTroopsSnapshot != null))
			{
				this.m_parent.closeControl(true);
				InterfaceMgr.Instance.getMainTabBar().selectDummyTab(6);
				InterfaceMgr.Instance.reactiveMainWindow();
				int villageID = -1;
				int campMode = 0;
				if (this.m_returnData != null)
				{
					if (this.m_returnData.reportType == 26)
					{
						campMode = 1;
						villageID = -2;
					}
					else if (this.m_returnData.reportType == 27)
					{
						campMode = 2;
						villageID = -3;
					}
					else if (this.m_returnData.reportType == 21 && this.m_returnData.otherUser.Length == 0)
					{
						villageID = -4;
					}
					else if (this.m_returnData.reportType == 54)
					{
						campMode = 0;
						villageID = -5;
					}
					else if (this.m_returnData.reportType == 55)
					{
						campMode = 0;
						villageID = -6;
					}
					else if (this.m_returnData.reportType == 56)
					{
						campMode = 0;
						villageID = -7;
					}
					else if (this.m_returnData.reportType == 57)
					{
						campMode = 0;
						villageID = -8;
					}
					else if (this.m_returnData.reportType == 121)
					{
						campMode = 0;
						villageID = -9;
					}
					else if (this.m_returnData.reportType == 122)
					{
						campMode = 0;
						villageID = -10;
					}
					else if (this.m_returnData.reportType == 126)
					{
						campMode = 0;
						villageID = -11;
					}
					else if (this.m_returnData.reportType == 133)
					{
						campMode = 0;
						villageID = -12;
					}
					else
					{
						villageID = returnData.villageID;
					}
				}
				GameEngine.Instance.InitCastleView(returnData.castleMapSnapshot, returnData.castleTroopsSnapshot, returnData.keepLevel, campMode, returnData.defencesLevel, villageID, returnData.landType);
				InterfaceMgr.Instance.castleBattleTimes(returnData.lastCastleTime, returnData.lastTroopTime);
				return;
			}
			MyMessageBox.Show(SK.Text("ReportsPanel_No_Longer_Valid", "The target for this scout report is no longer valid."), SK.Text("ReportsPanel_Scout_Report", "Scout Report"));
		}

		// Token: 0x060029C3 RID: 10691 RVA: 0x00076AA0 File Offset: 0x00074CA0
		private void attackerDoubleClick()
		{
			if (this.m_returnData != null)
			{
				Point villageLocation = GameEngine.Instance.World.getVillageLocation(this.m_returnData.attackingVillage);
				double targetZoom = 10000.0;
				if (villageLocation.X != -1)
				{
					GameEngine.Instance.playInterfaceSound("ReportsGeneric_goto_map");
					InterfaceMgr.Instance.changeTab(0);
					GameEngine.Instance.World.startMultiStageZoom(targetZoom, (double)villageLocation.X, (double)villageLocation.Y);
					this.m_parent.closeControl(true);
					InterfaceMgr.Instance.reactiveMainWindow();
					InterfaceMgr.Instance.displaySelectedVillagePanel(this.m_returnData.attackingVillage, false, true, false, false);
				}
			}
		}

		// Token: 0x060029C4 RID: 10692 RVA: 0x00076B50 File Offset: 0x00074D50
		private void defenderDoubleClick()
		{
			if (this.m_returnData != null)
			{
				Point villageLocation = GameEngine.Instance.World.getVillageLocation(this.m_returnData.defendingVillage);
				double targetZoom = 10000.0;
				if (villageLocation.X != -1)
				{
					GameEngine.Instance.playInterfaceSound("ReportsGeneric_goto_map");
					InterfaceMgr.Instance.changeTab(0);
					GameEngine.Instance.World.startMultiStageZoom(targetZoom, (double)villageLocation.X, (double)villageLocation.Y);
					this.m_parent.closeControl(true);
					InterfaceMgr.Instance.reactiveMainWindow();
					InterfaceMgr.Instance.displaySelectedVillagePanel(this.m_returnData.defendingVillage, false, true, false, false);
				}
			}
		}

		// Token: 0x0400336A RID: 13162
		private CustomSelfDrawPanel.CSDButton btnViewCastle = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400336B RID: 13163
		private CustomSelfDrawPanel.CSDLabel lblResult = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400336C RID: 13164
		private CustomSelfDrawPanel.CSDLabel lblScouts = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400336D RID: 13165
		private CustomSelfDrawPanel.CSDLabel lblHonour = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400336E RID: 13166
		private CustomSelfDrawPanel.CSDLabel lblWolves = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400336F RID: 13167
		private Point mapTarget = new Point(-1, -1);

		// Token: 0x04003370 RID: 13168
		private double targetZoomLevel;
	}
}
