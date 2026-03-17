using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020001A4 RID: 420
	public class EmptyVillagePanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06001005 RID: 4101 RVA: 0x00117A64 File Offset: 0x00115C64
		public EmptyVillagePanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SelfDrawBackground = true;
		}

		// Token: 0x06001006 RID: 4102 RVA: 0x00117B98 File Offset: 0x00115D98
		public void init(int villageID)
		{
			if (GameEngine.Instance.LocalWorldData.AIWorld)
			{
				switch (GameEngine.Instance.World.getSpecial(villageID))
				{
				case 7:
				case 9:
				case 11:
				case 13:
					this.wasAiShort = true;
					base.Size = new Size(199, 213);
					goto IL_A8;
				}
				this.wasAiShort = false;
				base.Size = new Size(199, 273);
			}
			else if (this.wasAiShort)
			{
				this.wasAiShort = false;
				base.Size = new Size(199, 273);
			}
			IL_A8:
			this.wasTall = this.isTallTreasureChestPanel(villageID);
			int num = 0;
			if (this.wasTall)
			{
				num = 60;
			}
			base.clearControls();
			CustomSelfDrawPanel.CSDImage csdimage = this.backGround_AI.init(this.wasTall, 10000);
			base.addControl(this.backGround_AI);
			this.attackButton_AI = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.ATTACK);
			this.attackButton_AI.Position = new Point(64, 79 + num);
			this.attackButton_AI.CustomTooltipID = 2411;
			this.attackButton_AI.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnAttack_Click), "EmptyVillagePanel2_attack");
			csdimage.addControl(this.attackButton_AI);
			this.scoutButton_AI = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.SCOUT);
			this.scoutButton_AI.Position = new Point(99, 79 + num);
			this.scoutButton_AI.CustomTooltipID = 2412;
			this.scoutButton_AI.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnScout_Click), "EmptyVillagePanel2_scout");
			csdimage.addControl(this.scoutButton_AI);
			this.castleButton_AI = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.LAST_REPORT);
			this.castleButton_AI.Position = new Point(80, 47 + num);
			this.castleButton_AI.CustomTooltipID = 2445;
			this.castleButton_AI.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castleClick), "EmptyVillagePanel2_castle");
			csdimage.addControl(this.castleButton_AI);
			this.treasureCastleTimeoutLabel.Text = "";
			this.treasureCastleTimeoutLabel.Color = global::ARGBColors.Black;
			this.treasureCastleTimeoutLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
			this.treasureCastleTimeoutLabel.Position = new Point(10, 50);
			this.treasureCastleTimeoutLabel.Size = new Size(csdimage.Width - 20, 80);
			this.treasureCastleTimeoutLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.treasureCastleTimeoutLabel.Visible = false;
			csdimage.addControl(this.treasureCastleTimeoutLabel);
			if (!this.wasTall)
			{
				csdimage.Image = GFXLibrary.mrhp_world_panel_132;
			}
			csdimage = this.backGround_Enemy.init(false, 10000);
			base.addControl(this.backGround_Enemy);
			this.backGround_Enemy.hideBackground();
			this.invasionLabel.Text = "";
			this.invasionLabel.Color = global::ARGBColors.Black;
			this.invasionLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.invasionLabel.Position = new Point(57, 33);
			this.invasionLabel.Size = new Size(this.backGround_Enemy.Width - 20, 80);
			this.invasionLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.invasionLabel.Visible = false;
			this.backGround_Enemy.addControl(this.invasionLabel);
			csdimage = this.backGround_Resources.init(false, 10000);
			base.addControl(this.backGround_Resources);
			this.scoutButton_Resources = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.SCOUT);
			this.scoutButton_Resources.Position = new Point(80, 49);
			this.scoutButton_Resources.Enabled = false;
			this.scoutButton_Resources.CustomTooltipID = 2443;
			this.scoutButton_Resources.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnScout_Click), "EmptyVillagePanel2_scout_stash");
			csdimage.addControl(this.scoutButton_Resources);
			csdimage = this.backGround_Charter.init(true, 10000);
			base.addControl(this.backGround_Charter);
			this.charterLabel.Text = SK.Text("EmptyVillagePanel_Cost", "Cost to found this village");
			this.charterLabel.Color = global::ARGBColors.Black;
			this.charterLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
			this.charterLabel.Position = new Point(0, 42);
			this.charterLabel.Size = new Size(csdimage.Width, 40);
			this.charterLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			csdimage.addControl(this.charterLabel);
			this.goldImage.Image = GFXLibrary.com_32_money;
			this.goldImage.Position = new Point(105, 58);
			csdimage.addControl(this.goldImage);
			this.goldLabel.Text = "0,000,000";
			this.goldLabel.Color = global::ARGBColors.Black;
			this.goldLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
			this.goldLabel.Position = new Point(0, 66);
			this.goldLabel.Size = new Size(100, 40);
			this.goldLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			csdimage.addControl(this.goldLabel);
			this.honourImage.Image = GFXLibrary.com_32_honour;
			this.honourImage.Position = new Point(105, 98);
			csdimage.addControl(this.honourImage);
			this.honourLabel.Text = "0,000,000";
			this.honourLabel.Color = global::ARGBColors.Black;
			this.honourLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
			this.honourLabel.Position = new Point(0, 106);
			this.honourLabel.Size = new Size(100, 40);
			this.honourLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			csdimage.addControl(this.honourLabel);
			this.travelTimeDescLabel.Text = SK.Text("EmptyVillagePanel_TravelTime", "Time to reach this Charter");
			this.travelTimeDescLabel.Color = global::ARGBColors.Black;
			this.travelTimeDescLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
			this.travelTimeDescLabel.Position = new Point(0, 148);
			this.travelTimeDescLabel.Size = new Size(csdimage.Width, 40);
			this.travelTimeDescLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			csdimage.addControl(this.travelTimeDescLabel);
			this.travelTimeLabel.Text = "0:00";
			this.travelTimeLabel.Color = global::ARGBColors.Black;
			this.travelTimeLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
			this.travelTimeLabel.Position = new Point(0, 177);
			this.travelTimeLabel.Size = new Size(100, 40);
			this.travelTimeLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			csdimage.addControl(this.travelTimeLabel);
			this.travelImage.Image = GFXLibrary.wl_moving_unit_icons[32];
			this.travelImage.Position = new Point(105, 161);
			csdimage.addControl(this.travelImage);
			this.seaConditionsImage.Image = GFXLibrary.sea_conditions[0];
			this.seaConditionsImage.Position = new Point(165, 183);
			this.seaConditionsImage.Visible = false;
			this.seaConditionsImage.Scale = 0.8999999761581421;
			csdimage.addControl(this.seaConditionsImage);
			this.buyVillageButton.ImageNorm = GFXLibrary.mrhp_button_150x25[0];
			this.buyVillageButton.ImageOver = GFXLibrary.mrhp_button_150x25[1];
			this.buyVillageButton.ImageClick = GFXLibrary.mrhp_button_150x25[2];
			this.buyVillageButton.Position = new Point(26, 215);
			this.buyVillageButton.Text.Text = SK.Text("EmptyVillagePanel_Buy_Village", "Purchase");
			this.buyVillageButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.buyVillageButton.TextYOffset = -3;
			this.buyVillageButton.Text.Color = global::ARGBColors.Black;
			this.buyVillageButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnBuyVillage_Click), "EmptyVillagePanel2_buy_village");
			csdimage.addControl(this.buyVillageButton);
		}

		// Token: 0x06001007 RID: 4103 RVA: 0x00118410 File Offset: 0x00116610
		public void update()
		{
			this.backGround_AI.update();
			this.backGround_Charter.update();
			this.backGround_Enemy.update();
			this.backGround_Resources.update();
			this.buyVillageButton.CustomTooltipID = 0;
			if (GameEngine.Instance.World.canUserOwnMoreVillages() && GameEngine.Instance.World.isUserVillage(InterfaceMgr.Instance.getSelectedMenuVillage()) && !GameEngine.Instance.World.isCapital(InterfaceMgr.Instance.getSelectedMenuVillage()))
			{
				if (!this.buyVillageButton.Active)
				{
					this.buyVillageButton.invalidate();
				}
				this.buyVillageButton.Active = true;
				this.buyVillageButton.Alpha = 1f;
			}
			else
			{
				if (this.buyVillageButton.Active)
				{
					this.buyVillageButton.invalidate();
				}
				this.buyVillageButton.Active = false;
				this.buyVillageButton.Alpha = 0.2f;
				if (!GameEngine.Instance.World.canUserOwnMoreVillages())
				{
					if (GameEngine.Instance.World.numVillagesAllowed() <= 1 && GameEngine.Instance.World.getRank() + 1 < 12)
					{
						this.buyVillageButton.CustomTooltipID = 2506;
					}
					else
					{
						this.buyVillageButton.CustomTooltipID = 2504;
					}
				}
				else if (!GameEngine.Instance.World.isUserVillage(InterfaceMgr.Instance.getSelectedMenuVillage()) || GameEngine.Instance.World.isCapital(InterfaceMgr.Instance.getSelectedMenuVillage()))
				{
					this.buyVillageButton.CustomTooltipID = 2505;
				}
			}
			this.updateTreasureCastleTimeout();
			if (this.special)
			{
				WorldMap.SpecialVillageCache specialVillageData = GameEngine.Instance.World.getSpecialVillageData(this.m_selectedVillage, false);
				if (this.lastData != specialVillageData)
				{
					this.updateSpecialData(specialVillageData);
				}
			}
			double num = this.storedPreCardDistance * CardTypes.getArmySpeed(GameEngine.Instance.cardsManager.UserCardData);
			num = GameEngine.Instance.World.adjustIfIslandTravel(num, InterfaceMgr.Instance.getSelectedMenuVillage(), this.m_selectedVillage);
			if (this.lastDist != num)
			{
				this.lastDist = num;
				string text = VillageMap.createBuildTimeString((int)num);
				this.travelTimeLabel.Text = text;
				this.travelTimeLabel.CustomTooltipID = 20000;
				this.travelTimeLabel.CustomTooltipData = (int)num;
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
			if (GameEngine.Instance.World.WorldEnded)
			{
				this.buyVillageButton.Visible = false;
			}
		}

		// Token: 0x06001008 RID: 4104 RVA: 0x001186C8 File Offset: 0x001168C8
		private bool isTallTreasureChestPanel(int villageID)
		{
			if (GameEngine.Instance.World.isSpecial(villageID) && GameEngine.Instance.World.isAttackableSpecial(villageID))
			{
				int type = GameEngine.Instance.World.getSpecial(villageID);
				if (SpecialVillageTypes.IS_TREASURE_CASTLE(type))
				{
					TimeSpan timeSpan = VillageMap.getCurrentServerTime() - GameEngine.Instance.World.getLastTreasureCastleAttackTime();
					int treasureCastle_AttackGap = WorldMap.TreasureCastle_AttackGap;
					if (timeSpan.TotalSeconds < (double)treasureCastle_AttackGap)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06001009 RID: 4105 RVA: 0x00118740 File Offset: 0x00116940
		private void updateTreasureCastleTimeout()
		{
			if (!GameEngine.Instance.World.isSpecial(this.m_selectedVillage) || !GameEngine.Instance.World.isAttackableSpecial(this.m_selectedVillage))
			{
				return;
			}
			TimeSpan timeSpan = VillageMap.getCurrentServerTime() - GameEngine.Instance.World.getLastTreasureCastleAttackTime();
			int treasureCastle_AttackGap = WorldMap.TreasureCastle_AttackGap;
			if (timeSpan.TotalSeconds < (double)treasureCastle_AttackGap)
			{
				this.treasureCastleTimeoutLabel.TextDiffOnly = SK.Text("EmptyVillage_NextAttackAvailable", "Next Attack Available in") + " " + VillageMap.createBuildTimeString(treasureCastle_AttackGap - (int)timeSpan.TotalSeconds);
				return;
			}
			this.treasureCastleTimeoutLabel.TextDiffOnly = "";
			if (this.treasureCastleTimeoutLabel.Visible && !GameEngine.Instance.World.isCapital(InterfaceMgr.Instance.OwnSelectedVillage))
			{
				this.attackButton_AI.Enabled = true;
			}
		}

		// Token: 0x0600100A RID: 4106 RVA: 0x00118820 File Offset: 0x00116A20
		public void updateEmptyVillageText(int selectedVillage)
		{
			bool flag = false;
			bool flag2 = false;
			if (GameEngine.Instance.World.isSpecial(selectedVillage) && GameEngine.Instance.World.isAttackableSpecial(selectedVillage))
			{
				bool flag3 = this.isTallTreasureChestPanel(selectedVillage);
				if (flag3 != this.wasTall)
				{
					this.init(selectedVillage);
					flag = true;
				}
				flag2 = flag3;
			}
			if (!flag && GameEngine.Instance.LocalWorldData.AIWorld)
			{
				bool flag4;
				switch (GameEngine.Instance.World.getSpecial(selectedVillage))
				{
				case 7:
				case 9:
				case 11:
				case 13:
					flag4 = true;
					goto IL_9F;
				}
				flag4 = false;
				IL_9F:
				if (flag4 != this.wasAiShort)
				{
					this.init(selectedVillage);
				}
			}
			NumberFormatInfo nfi = GameEngine.NFI;
			this.m_selectedVillage = selectedVillage;
			this.buyVillageButton.Enabled = true;
			this.attackButton_AI.Enabled = true;
			this.scoutButton_AI.Enabled = true;
			this.scoutButton_Resources.Enabled = true;
			this.treasureCastleTimeoutLabel.Visible = false;
			this.backGround_AI.Visible = false;
			this.backGround_Enemy.Visible = false;
			this.backGround_Resources.Visible = false;
			this.backGround_Charter.Visible = false;
			this.special = false;
			this.invasionLabel.Visible = false;
			this.seaConditionsImage.Visible = false;
			this.backGround_AI.removeWikiLink(this.wikiLink);
			this.wikiLink = null;
			int num = GameEngine.Instance.World.getSpecial(selectedVillage);
			if (SpecialVillageTypes.IS_ROYAL_TOWER(num))
			{
				this.wikiLink = this.backGround_AI.addWikiLink(54);
			}
			else if (SpecialVillageTypes.IS_TREASURE_CASTLE(num))
			{
				this.wikiLink = this.backGround_AI.addWikiLink(49);
			}
			else if (num == 15 || num == 17)
			{
				this.wikiLink = this.backGround_AI.addWikiLink(50);
			}
			if (GameEngine.Instance.World.isSpecial(selectedVillage))
			{
				bool flag5 = true;
				this.special = true;
				if (!GameEngine.Instance.World.isAttackableSpecial(selectedVillage))
				{
					if (num >= 100 && num <= 199)
					{
						this.backGround_Resources.Visible = true;
						this.backGround_Resources.updateHeading(GameEngine.Instance.World.getVillageNameOrType(selectedVillage));
						this.backGround_Resources.updatePanelTypeFromVillageID(selectedVillage);
						this.scoutButton_Resources.Enabled = false;
					}
					else
					{
						this.backGround_Enemy.Visible = true;
						if (num == 30)
						{
							switch (GameEngine.Instance.World.getAIInvasionMarkerState(selectedVillage))
							{
							case 0:
								this.backGround_Enemy.updateHeading(SK.Text("Invasion_None", "No Invasion Sighted"));
								break;
							case 1:
							{
								this.backGround_Enemy.updateHeading(SK.Text("Invasion_Planned", "Invasion Sighted"));
								DateTime nextAIInvasionDate = GameEngine.Instance.World.getNextAIInvasionDate(selectedVillage);
								if (nextAIInvasionDate != DateTime.MinValue)
								{
									TimeSpan timeSpan = nextAIInvasionDate - VillageMap.getCurrentServerTime();
									this.invasionLabel.Visible = true;
									this.invasionLabel.Text = VillageMap.createBuildTimeString((int)timeSpan.TotalSeconds);
								}
								break;
							}
							case 2:
								this.backGround_Enemy.updateHeading(SK.Text("Invasion_Inprogress", "Invasion In Progress"));
								break;
							}
						}
						else
						{
							this.backGround_Enemy.updateHeading(GameEngine.Instance.World.getVillageNameOrType(selectedVillage));
						}
						this.backGround_Enemy.updatePanelTypeFromVillageID(selectedVillage);
					}
				}
				else
				{
					this.backGround_AI.Visible = true;
					this.backGround_AI.updateHeading(GameEngine.Instance.World.getVillageNameOrType(selectedVillage));
					this.backGround_AI.updatePanelTypeFromVillageID(selectedVillage);
					if (SpecialVillageTypes.IS_TREASURE_CASTLE(num))
					{
						if (GameEngine.Instance.World.isCapital(InterfaceMgr.Instance.OwnSelectedVillage))
						{
							this.attackButton_AI.Enabled = false;
						}
						if (flag2)
						{
							this.updateTreasureCastleTimeout();
							this.treasureCastleTimeoutLabel.Visible = true;
							this.attackButton_AI.Enabled = false;
						}
					}
					else if (SpecialVillageTypes.IS_ROYAL_TOWER(num) && GameEngine.Instance.World.isCapital(InterfaceMgr.Instance.OwnSelectedVillage))
					{
						this.attackButton_AI.Enabled = false;
					}
					if (GameEngine.Instance.World.isHeretic())
					{
						switch (num)
						{
						case 7:
						case 9:
						case 11:
						case 13:
							this.attackButton_AI.Enabled = false;
							this.scoutButton_AI.Enabled = false;
							flag5 = false;
							break;
						}
					}
				}
				if (!GameEngine.Instance.World.isScoutableSpecial(selectedVillage) || GameEngine.Instance.World.isCapital(InterfaceMgr.Instance.OwnSelectedVillage) || !flag5)
				{
					this.scoutButton_AI.Enabled = false;
					this.scoutButton_Resources.Enabled = false;
					return;
				}
				this.scoutButton_AI.Enabled = true;
				this.scoutButton_Resources.Enabled = true;
				return;
			}
			else
			{
				this.backGround_Charter.Visible = true;
				this.backGround_Charter.updateHeading(SK.Text("EmptyVillagePanel_Available_Village", "New Village Charter"));
				this.backGround_Charter.updatePanelTypeFromVillageID(selectedVillage);
				this.backGround_Charter.stretchBackground();
				base.Parent.Invalidate();
				double num2 = GameEngine.Instance.LocalWorldData.villageGoldCost;
				double num3 = GameEngine.Instance.World.calcVillageDistance(InterfaceMgr.Instance.getSelectedMenuVillage(), selectedVillage) * GameEngine.Instance.LocalWorldData.villageCostDistanceMultiplier;
				num2 *= num3 + 1.0;
				int num4 = GameEngine.Instance.World.numVillagesOwned();
				int num5 = (int)num2;
				num5 *= num4;
				num2 = (double)num5;
				this.goldLabel.Text = ((int)num2).ToString("N", nfi);
				WorldData localWorldData = GameEngine.Instance.LocalWorldData;
				Point villageLocation = GameEngine.Instance.World.getVillageLocation(InterfaceMgr.Instance.OwnSelectedVillage);
				Point villageLocation2 = GameEngine.Instance.World.getVillageLocation(selectedVillage);
				double num6 = (double)((villageLocation.X - villageLocation2.X) * (villageLocation.X - villageLocation2.X) + (villageLocation.Y - villageLocation2.Y) * (villageLocation.Y - villageLocation2.Y));
				num6 = Math.Sqrt(num6);
				num6 = (this.storedPreCardDistance = num6 * (localWorldData.CaptainsMoveSpeed * localWorldData.gamePlaySpeed * ResearchData.CaptainTimes[(int)GameEngine.Instance.World.UserResearchData.Research_Courtiers])) * CardTypes.getArmySpeed(GameEngine.Instance.cardsManager.UserCardData);
				num6 = (this.lastDist = GameEngine.Instance.World.adjustIfIslandTravel(num6, InterfaceMgr.Instance.OwnSelectedVillage, selectedVillage));
				string text = VillageMap.createBuildTimeString((int)num6);
				this.travelTimeLabel.Text = text;
				this.travelTimeLabel.CustomTooltipID = 20000;
				this.travelTimeLabel.CustomTooltipData = (int)num6;
				int num7 = 0;
				if (GameEngine.Instance.LocalWorldData.Alternate_Ruleset != 1)
				{
					num7 = ResearchData.getVillageBuyHonourCost(num4);
					if (num7 > 0 && GameEngine.Instance.World.FourthAgeWorld && num4 < GameEngine.Instance.World.MostAge4Villages)
					{
						num7 = 0;
					}
				}
				if (GameEngine.Instance.World.isIslandTravel(InterfaceMgr.Instance.OwnSelectedVillage, selectedVillage))
				{
					int num8 = GameEngine.Instance.World.SpecialSeaConditionsData + 4;
					if (num8 < 0)
					{
						num8 = 0;
					}
					else if (num8 >= 9)
					{
						num8 = 8;
					}
					this.seaConditionsImage.Visible = true;
					this.seaConditionsImage.Image = GFXLibrary.sea_conditions[num8];
					this.seaConditionsImage.CustomTooltipID = 23000 + num8;
				}
				if (num7 > 0)
				{
					this.honourImage.Visible = true;
					this.honourLabel.Visible = true;
					this.honourLabel.Text = num7.ToString("N", nfi);
					return;
				}
				this.honourImage.Visible = false;
				this.honourLabel.Visible = false;
				return;
			}
		}

		// Token: 0x0600100B RID: 4107 RVA: 0x00119010 File Offset: 0x00117210
		public void updateSpecialData(WorldMap.SpecialVillageCache specialData)
		{
			string text = "";
			this.lastData = specialData;
			if (specialData != null && specialData.resourceType > 0 && specialData.resourceLevel > 0)
			{
				NumberFormatInfo nfi = GameEngine.NFI;
				text = specialData.resourceLevel.ToString("N", nfi);
			}
			if (text.Length > 0)
			{
				this.backGround_Resources.updateSubHeading(text);
			}
			else
			{
				this.backGround_Resources.updateSubHeading("");
				this.scoutButton_Resources.Enabled = false;
			}
			if (!GameEngine.Instance.World.isCapital(InterfaceMgr.Instance.OwnSelectedVillage))
			{
				this.scoutButton_Resources.Enabled = true;
				return;
			}
			this.scoutButton_Resources.Enabled = false;
		}

		// Token: 0x0600100C RID: 4108 RVA: 0x00011BF1 File Offset: 0x0000FDF1
		public void forceDisable()
		{
			this.buyVillageButton.Enabled = false;
			this.attackButton_AI.Enabled = false;
			this.scoutButton_AI.Enabled = false;
			this.scoutButton_Resources.Enabled = false;
		}

		// Token: 0x0600100D RID: 4109 RVA: 0x001190C0 File Offset: 0x001172C0
		private void btnBuyVillage_Click()
		{
			if (!this.buyVillageButton.Active)
			{
				return;
			}
			if (!GameEngine.Instance.World.canUserOwnMoreVillages() || !GameEngine.Instance.World.isUserVillage(InterfaceMgr.Instance.getSelectedMenuVillage()))
			{
				MyMessageBox.Show(SK.Text("EmptyVillagePanel_No_More_Villages", "You cannot own more villages."), SK.Text("EmptyVillagePanel_Buy_Village_Error", "Buy Village Error"));
				return;
			}
			int selectedVillage = InterfaceMgr.Instance.SelectedVillage;
			if (selectedVillage < 0)
			{
				MyMessageBox.Show(SK.Text("EmptyVillagePanel_Not_Enough_Gold", "Not enough gold"), SK.Text("EmptyVillagePanel_Buy_Village_Error", "Buy Village Error"));
				return;
			}
			double num = GameEngine.Instance.LocalWorldData.villageGoldCost;
			double num2 = GameEngine.Instance.World.calcVillageDistance(InterfaceMgr.Instance.getSelectedMenuVillage(), selectedVillage) * GameEngine.Instance.LocalWorldData.villageCostDistanceMultiplier;
			num *= num2 + 1.0;
			if (GameEngine.Instance.World.getCurrentGold() < num)
			{
				MyMessageBox.Show(SK.Text("EmptyVillagePanel_Not_Enough_Gold", "Not enough gold"), SK.Text("EmptyVillagePanel_Buy_Village_Error", "Buy Village Error"));
				return;
			}
			int num3 = 0;
			if (GameEngine.Instance.LocalWorldData.Alternate_Ruleset != 1)
			{
				num3 = ResearchData.getVillageBuyHonourCost(GameEngine.Instance.World.numVillagesOwned());
				if (num3 > 0 && GameEngine.Instance.World.FourthAgeWorld && GameEngine.Instance.World.numVillagesOwned() < GameEngine.Instance.World.MostAge4Villages)
				{
					num3 = 0;
				}
			}
			if (num3 <= 0 || GameEngine.Instance.World.getCurrentHonour() >= (double)num3)
			{
				InterfaceMgr.Instance.openBuyVillageWindow(selectedVillage, true);
				return;
			}
			MyMessageBox.Show(SK.Text("EmptyVillagePanel_Not_Enough_Honour", "Not enough honour"), SK.Text("EmptyVillagePanel_Buy_Village_Error", "Buy Village Error"));
		}

		// Token: 0x0600100E RID: 4110 RVA: 0x00119294 File Offset: 0x00117494
		private void btnAttack_Click()
		{
			if (InterfaceMgr.Instance.SelectedVillage >= 0)
			{
				int selectedVillage = InterfaceMgr.Instance.SelectedVillage;
				GameEngine.Instance.preAttackSetup(InterfaceMgr.Instance.OwnSelectedVillage, InterfaceMgr.Instance.OwnSelectedVillage, selectedVillage);
			}
		}

		// Token: 0x0600100F RID: 4111 RVA: 0x00011C23 File Offset: 0x0000FE23
		private void btnScout_Click()
		{
			if (InterfaceMgr.Instance.SelectedVillage >= 0)
			{
				InterfaceMgr.Instance.openScoutPopupWindow(InterfaceMgr.Instance.SelectedVillage, true);
			}
		}

		// Token: 0x06001010 RID: 4112 RVA: 0x00011C48 File Offset: 0x0000FE48
		private void castleClick()
		{
			RemoteServices.Instance.set_ViewCastle_UserCallBack(new RemoteServices.ViewCastle_UserCallBack(this.viewCastleCallback));
			RemoteServices.Instance.ViewCastle_Village(InterfaceMgr.Instance.SelectedVillage);
		}

		// Token: 0x06001011 RID: 4113 RVA: 0x001192D8 File Offset: 0x001174D8
		public void viewCastleCallback(ViewCastle_ReturnType returnData)
		{
			if (returnData.Success)
			{
				int num = GameEngine.Instance.World.getSpecial(InterfaceMgr.Instance.SelectedVillage);
				this.closeControl(true);
				InterfaceMgr.Instance.getMainTabBar().selectDummyTab(6);
				int villageID = returnData.villageID;
				int campMode = 0;
				if (num != 3)
				{
					if (num == 5)
					{
						campMode = 2;
						villageID = -3;
					}
				}
				else
				{
					campMode = 1;
					villageID = -2;
				}
				GameEngine.Instance.InitCastleView(returnData.castleMapSnapshot, returnData.castleTroopsSnapshot, returnData.keepLevel, campMode, returnData.defencesLevel, villageID, returnData.landType);
				CastleMapBattlePanel2.fromWorld();
				InterfaceMgr.Instance.castleBattleTimes(returnData.lastCastleTime, returnData.lastTroopTime);
			}
		}

		// Token: 0x06001012 RID: 4114 RVA: 0x00011C74 File Offset: 0x0000FE74
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06001013 RID: 4115 RVA: 0x00011C84 File Offset: 0x0000FE84
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06001014 RID: 4116 RVA: 0x00011C94 File Offset: 0x0000FE94
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06001015 RID: 4117 RVA: 0x00011CA6 File Offset: 0x0000FEA6
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06001016 RID: 4118 RVA: 0x00011CB3 File Offset: 0x0000FEB3
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x06001017 RID: 4119 RVA: 0x00011CC1 File Offset: 0x0000FEC1
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06001018 RID: 4120 RVA: 0x00011CCE File Offset: 0x0000FECE
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06001019 RID: 4121 RVA: 0x00011CDB File Offset: 0x0000FEDB
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600101A RID: 4122 RVA: 0x00119388 File Offset: 0x00117588
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Name = "EmptyVillagePanel2";
			base.Size = new Size(199, 273);
			base.ResumeLayout(false);
		}

		// Token: 0x0400161C RID: 5660
		private CustomSelfDrawPanel.MRHP_Background backGround_AI = new CustomSelfDrawPanel.MRHP_Background();

		// Token: 0x0400161D RID: 5661
		private CustomSelfDrawPanel.CSDButton attackButton_AI = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400161E RID: 5662
		private CustomSelfDrawPanel.CSDButton scoutButton_AI = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400161F RID: 5663
		private CustomSelfDrawPanel.CSDButton castleButton_AI = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001620 RID: 5664
		private CustomSelfDrawPanel.CSDLabel treasureCastleTimeoutLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001621 RID: 5665
		private CustomSelfDrawPanel.MRHP_Background backGround_Enemy = new CustomSelfDrawPanel.MRHP_Background();

		// Token: 0x04001622 RID: 5666
		private CustomSelfDrawPanel.MRHP_Background backGround_Resources = new CustomSelfDrawPanel.MRHP_Background();

		// Token: 0x04001623 RID: 5667
		private CustomSelfDrawPanel.CSDButton scoutButton_Resources = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001624 RID: 5668
		private CustomSelfDrawPanel.MRHP_Background backGround_Charter = new CustomSelfDrawPanel.MRHP_Background();

		// Token: 0x04001625 RID: 5669
		private CustomSelfDrawPanel.CSDLabel charterLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001626 RID: 5670
		private CustomSelfDrawPanel.CSDImage goldImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001627 RID: 5671
		private CustomSelfDrawPanel.CSDImage honourImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001628 RID: 5672
		private CustomSelfDrawPanel.CSDLabel goldLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001629 RID: 5673
		private CustomSelfDrawPanel.CSDLabel honourLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400162A RID: 5674
		private CustomSelfDrawPanel.CSDLabel travelTimeDescLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400162B RID: 5675
		private CustomSelfDrawPanel.CSDLabel travelTimeLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400162C RID: 5676
		private CustomSelfDrawPanel.CSDImage travelImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400162D RID: 5677
		private CustomSelfDrawPanel.CSDImage seaConditionsImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400162E RID: 5678
		private CustomSelfDrawPanel.CSDLabel invasionLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400162F RID: 5679
		private CustomSelfDrawPanel.WikiLinkControl wikiLink;

		// Token: 0x04001630 RID: 5680
		private CustomSelfDrawPanel.CSDButton buyVillageButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001631 RID: 5681
		private bool wasTall = true;

		// Token: 0x04001632 RID: 5682
		private bool wasAiShort;

		// Token: 0x04001633 RID: 5683
		private double storedPreCardDistance;

		// Token: 0x04001634 RID: 5684
		private double lastDist = -1.0;

		// Token: 0x04001635 RID: 5685
		private int m_selectedVillage = -1;

		// Token: 0x04001636 RID: 5686
		private bool special;

		// Token: 0x04001637 RID: 5687
		private WorldMap.SpecialVillageCache lastData;

		// Token: 0x04001638 RID: 5688
		private DockableControl dockableControl;

		// Token: 0x04001639 RID: 5689
		private IContainer components;
	}
}
