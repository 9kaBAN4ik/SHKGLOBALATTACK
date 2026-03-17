using System;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using StatTracking;

namespace Kingdoms
{
	// Token: 0x020000CF RID: 207
	internal class AttackReportPanelDerived : GenericReportPanelBasic
	{
		// Token: 0x060005D5 RID: 1493 RVA: 0x00074504 File Offset: 0x00072704
		public AttackReportPanelDerived()
		{
			base.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.Size = new Size(580, 600);
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x000745FC File Offset: 0x000727FC
		public override void init(IDockableControl parent, Size size, object back)
		{
			base.init(parent, size, back);
			this.btnViewBattle.ImageNorm = GFXLibrary.button_132_normal;
			this.btnViewBattle.ImageOver = GFXLibrary.button_132_over;
			this.btnViewBattle.ImageClick = GFXLibrary.button_132_in;
			this.btnViewBattle.setSizeToImage();
			this.btnViewBattle.Position = new Point(base.Width / 2 - this.btnViewBattle.Width / 2, this.btnClose.Y);
			this.btnViewBattle.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.btnViewBattle.TextYOffset = -2;
			this.btnViewBattle.Text.Color = global::ARGBColors.Black;
			this.btnViewBattle.Enabled = true;
			this.btnViewBattle.Visible = true;
			this.btnViewBattle.Text.Text = SK.Text("Reports_View_Battle", "View Battle");
			this.btnViewBattle.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.viewBattleClick), "Reports_View_Battle");
			this.btnViewResult.ImageNorm = GFXLibrary.button_132_normal;
			this.btnViewResult.ImageOver = GFXLibrary.button_132_over;
			this.btnViewResult.ImageClick = GFXLibrary.button_132_in;
			this.btnViewResult.setSizeToImage();
			this.btnViewResult.Position = new Point(base.Width / 2 - this.btnViewResult.Width / 2, this.btnDelete.Y);
			this.btnViewResult.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.btnViewResult.TextYOffset = -2;
			this.btnViewResult.Text.Color = global::ARGBColors.Black;
			this.btnViewResult.Enabled = true;
			this.btnViewResult.Visible = true;
			this.btnViewResult.Text.Text = SK.Text("Reports_View_Reports", "View Result");
			this.btnViewResult.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.viewResultClick), "Reports_View_Result");
			this.btnShowResources.ImageNorm = GFXLibrary.button_132_normal;
			this.btnShowResources.ImageOver = GFXLibrary.button_132_over;
			this.btnShowResources.ImageClick = GFXLibrary.button_132_in;
			this.btnShowResources.setSizeToImage();
			this.btnShowResources.Position = new Point(base.Width / 2 - this.btnViewResult.Width / 2, this.btnDelete.Y);
			this.btnShowResources.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.btnShowResources.TextYOffset = -2;
			this.btnShowResources.Text.Color = global::ARGBColors.Black;
			this.btnShowResources.Enabled = true;
			this.btnShowResources.Visible = false;
			this.btnShowResources.Text.Text = SK.Text("Reports_Show_Resources", "Show Resources");
			this.btnShowResources.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.showResourcesClick), "Reports_Show_Resources");
			this.btnUtility.Text.Text = SK.Text("Reports_Show_On_Map", "Show On Map");
			this.btnUtility.Visible = true;
			this.lblResult.Text = "";
			this.lblResult.Color = global::ARGBColors.Black;
			this.lblResult.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
			this.lblResult.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.lblResult.Position = new Point(0, this.lblSecondaryText.Rectangle.Bottom);
			this.lblResult.Size = new Size(base.Width, 26);
			this.lblDate.Y = this.lblResult.Rectangle.Bottom;
			string header = SK.Text("GENERIC_Attackers", "Attackers");
			this.attackerValuesPanel = new ReportBattleValuesPanel(this, new Size(this.btnClose.X - this.btnForward.Rectangle.Right - 4, 180));
			this.attackerValuesPanel.Position = new Point(this.btnForward.X, this.lblDate.Rectangle.Bottom);
			this.attackerValuesPanel.init(header, true, true);
			header = SK.Text("GENERIC_Defenders", "Defenders");
			this.defenderValuesPanel = new ReportBattleValuesPanel(this, new Size(this.btnClose.X - this.btnForward.Rectangle.Right - 4, 180));
			this.defenderValuesPanel.Position = new Point(this.btnClose.Rectangle.Right - 2 - this.defenderValuesPanel.Width, this.lblDate.Rectangle.Bottom);
			this.defenderValuesPanel.init(header, true, false);
			this.lblSpoils.Text = "";
			this.lblSpoils.Color = global::ARGBColors.Black;
			this.lblSpoils.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.lblSpoils.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.lblSpoils.Position = new Point(0, this.attackerValuesPanel.Rectangle.Bottom);
			this.lblSpoils.Size = new Size(base.Width, 26);
			this.lblTargetVillageInfo.Text = "";
			this.lblTargetVillageInfo.Color = global::ARGBColors.Black;
			this.lblTargetVillageInfo.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.lblTargetVillageInfo.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.lblTargetVillageInfo.Position = new Point(0, this.lblSpoils.Rectangle.Bottom);
			this.lblTargetVillageInfo.Size = new Size(base.Width, 26);
			this.lblHonour.Text = "";
			this.lblHonour.Color = global::ARGBColors.Black;
			this.lblHonour.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.lblHonour.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.lblHonour.Position = new Point(0, this.lblTargetVillageInfo.Rectangle.Bottom);
			this.lblHonour.Size = new Size(base.Width, 26);
			this.lblFlagCaptured.Text = "";
			this.lblFlagCaptured.Color = global::ARGBColors.Black;
			this.lblFlagCaptured.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.lblFlagCaptured.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.lblFlagCaptured.Position = new Point(0, this.lblHonour.Rectangle.Bottom);
			this.lblFlagCaptured.Size = new Size(base.Width, 26);
			this.resourcesPanel.Size = this.attackerValuesPanel.Size;
			this.resourcesPanel.Width *= 2;
			this.resourcesPanel.Position = this.attackerValuesPanel.Position;
			this.resourcesPanel.X = base.Width / 2 - this.resourcesPanel.Width / 2;
			this.resourcesPanel.init();
			this.resourcesPanel.Visible = false;
			if (base.hasBackground())
			{
				this.imgBackground.addControl(this.attackerValuesPanel);
				this.imgBackground.addControl(this.defenderValuesPanel);
				this.imgBackground.addControl(this.btnViewBattle);
				this.imgBackground.addControl(this.btnViewResult);
				this.imgBackground.addControl(this.btnShowResources);
				this.imgBackground.addControl(this.lblResult);
				this.imgBackground.addControl(this.lblSpoils);
				this.imgBackground.addControl(this.lblTargetVillageInfo);
				this.imgBackground.addControl(this.lblHonour);
				this.imgBackground.addControl(this.lblFlagCaptured);
				this.imgBackground.addControl(this.resourcesPanel);
				return;
			}
			base.addControl(this.attackerValuesPanel);
			base.addControl(this.defenderValuesPanel);
			base.addControl(this.btnViewBattle);
			base.addControl(this.btnViewResult);
			base.addControl(this.btnShowResources);
			base.addControl(this.lblResult);
			base.addControl(this.lblSpoils);
			base.addControl(this.lblTargetVillageInfo);
			base.addControl(this.lblHonour);
			base.addControl(this.lblFlagCaptured);
			base.addControl(this.resourcesPanel);
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x0000B1A0 File Offset: 0x000093A0
		public override void setData(GetReport_ReturnType returnData)
		{
			base.setData(returnData);
			this.setData(returnData, true);
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x00074EF8 File Offset: 0x000730F8
		private void setData(GetReport_ReturnType returnData, bool updateForwarding)
		{
			if (!this.m_returnData.snapshotAvailable)
			{
				this.m_returnData.wasAlreadyRead = true;
			}
			this.lblResult.Text = SK.Text("GENERIC_The_Attacker_Wins", "The Attacker Wins");
			this.attackerValuesPanel.setData(this.m_returnData, true);
			this.defenderValuesPanel.setData(this.m_returnData, false);
			bool flag = false;
			this.setCapitalFlags(returnData, out this.fromCapital, out this.toCapital);
			short reportType = returnData.reportType;
			if (reportType <= 61)
			{
				if (reportType <= 3)
				{
					if (reportType != 1)
					{
						if (reportType != 3)
						{
							goto IL_1408;
						}
						goto IL_CB1;
					}
					else
					{
						if (!this.fromCapital)
						{
							CustomSelfDrawPanel.CSDLabel lblMainText = this.lblMainText;
							lblMainText.Text = lblMainText.Text + " (" + GameEngine.Instance.World.getVillageName(returnData.attackingVillage) + ")";
						}
						else
						{
							this.lblMainText.Text = this.reportOwner;
						}
						this.lblSubTitle.Text = SK.Text("Reports_Attacks_Village", "Attacks");
						if (returnData.otherUser.Length == 0)
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
						else
						{
							this.lblSecondaryText.Text = returnData.otherUser + " (" + GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + ")";
						}
						this.lblSpoils.Text = "";
						if (!returnData.successStatus)
						{
							this.lblResult.Text = SK.Text("GENERIC_The_Defender_Wins", "The Defender Wins");
						}
						else if (returnData.genericData20 == 0 && returnData.genericData21 >= 0)
						{
							if (returnData.genericData30 == 11 || returnData.genericData30 == 13)
							{
								this.lblTargetVillageInfo.Text = GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + " - " + SK.Text("GENERIC_Successfully_Attacked", "Successfully attacked");
							}
							else
							{
								this.lblTargetVillageInfo.Text = GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + " - " + SK.Text("GENERIC_Captured", "Captured");
							}
						}
						else if (returnData.genericData20 == 10 && returnData.genericData21 >= 0)
						{
							this.lblTargetVillageInfo.Text = GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + " - " + SK.Text("GENERIC_Made_a_Vassal", "Made a vassal");
						}
						else if (returnData.genericData20 == 5 && returnData.genericData21 >= 0)
						{
							this.lblTargetVillageInfo.Text = GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + " - " + SK.Text("GENERIC_Has_Been_Razed", "Has been razed");
						}
						else if (returnData.genericData20 == 6)
						{
							this.lblTargetVillageInfo.Text = GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + " - " + SK.Text("GENERIC_Has_Been_Raided", "Has been raided");
							this.lblSpoils.Text = returnData.genericData21.ToString("N", this.nfi) + " " + SK.Text("GENERIC_Gold_Raided", "Gold raided");
						}
						else if (returnData.genericData20 == 0 && returnData.genericData21 == -25)
						{
							this.lblTargetVillageInfo.Text = SK.Text("GENERIC_Peacetime_Fail", "Attack Failed, village under Peace Time");
						}
						else
						{
							this.lblTargetVillageInfo.Text = GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + " - " + SK.Text("GENERIC_Successfully_Attacked", "Successfully attacked");
						}
						if (returnData.genericData11 < 0)
						{
							this.lblHonour.Text = SK.Text("GENERIC_Honour_Cost", "Honour Cost") + " : " + (-returnData.genericData11).ToString("N", this.nfi);
						}
						else
						{
							this.lblHonour.Text = SK.Text("GENERIC_Honour", "Honour") + " : " + returnData.genericData11.ToString("N", this.nfi);
						}
						if (returnData.genericData20 == 0)
						{
							goto IL_1408;
						}
						if (returnData.genericData20 == 2)
						{
							int num = returnData.genericData22 + returnData.genericData23 + returnData.genericData24 + returnData.genericData25 + returnData.genericData26 + returnData.genericData27 + returnData.genericData28 + returnData.genericData29;
							this.lblSpoils.Text = num.ToString("N", this.nfi) + " " + SK.Text("GENERIC_Resources_Taken", "Resources taken");
							this.btnShowResources.Visible = true;
							goto IL_1408;
						}
						if (returnData.genericData20 >= 500 && returnData.genericData20 < 1000)
						{
							goto IL_1408;
						}
						if (returnData.genericData20 > 1000)
						{
							if (returnData.genericData22 >= 0)
							{
								this.lblSpoils.Text = VillageBuildingsData.getBuildingName(returnData.genericData22);
							}
							if (returnData.genericData23 >= 0)
							{
								CustomSelfDrawPanel.CSDLabel csdlabel = this.lblSpoils;
								csdlabel.Text = csdlabel.Text + ", " + VillageBuildingsData.getBuildingName(returnData.genericData23);
							}
							if (returnData.genericData24 >= 0)
							{
								CustomSelfDrawPanel.CSDLabel csdlabel2 = this.lblSpoils;
								csdlabel2.Text = csdlabel2.Text + ", " + VillageBuildingsData.getBuildingName(returnData.genericData24);
							}
							if (returnData.genericData25 >= 0)
							{
								CustomSelfDrawPanel.CSDLabel csdlabel3 = this.lblSpoils;
								csdlabel3.Text = csdlabel3.Text + ", " + VillageBuildingsData.getBuildingName(returnData.genericData25);
							}
							if (returnData.genericData26 >= 0)
							{
								CustomSelfDrawPanel.CSDLabel csdlabel4 = this.lblSpoils;
								csdlabel4.Text = csdlabel4.Text + ", " + VillageBuildingsData.getBuildingName(returnData.genericData26);
							}
							if (returnData.genericData27 >= 0)
							{
								CustomSelfDrawPanel.CSDLabel csdlabel5 = this.lblSpoils;
								csdlabel5.Text = csdlabel5.Text + ", " + VillageBuildingsData.getBuildingName(returnData.genericData27);
							}
							if (returnData.genericData28 >= 0)
							{
								CustomSelfDrawPanel.CSDLabel csdlabel6 = this.lblSpoils;
								csdlabel6.Text = csdlabel6.Text + ", " + VillageBuildingsData.getBuildingName(returnData.genericData28);
							}
							if (returnData.genericData29 >= 0)
							{
								CustomSelfDrawPanel.CSDLabel csdlabel7 = this.lblSpoils;
								csdlabel7.Text = csdlabel7.Text + ", " + VillageBuildingsData.getBuildingName(returnData.genericData29);
							}
							CustomSelfDrawPanel.CSDLabel csdlabel8 = this.lblSpoils;
							csdlabel8.Text = csdlabel8.Text + " - " + SK.Text("GENERIC_Destroyed", "Destroyed");
							goto IL_1408;
						}
						if (returnData.genericData20 == 1000)
						{
							this.lblSpoils.Text = SK.Text("GENERIC_No_Destroyable_Buildings", "There were no destroyable buildings.");
							goto IL_1408;
						}
						if (returnData.genericData20 == 1)
						{
							this.lblSpoils.Text = SK.Text("GENERIC_Attack_Failed", "This attack failed.");
							goto IL_1408;
						}
						goto IL_1408;
					}
				}
				else if (reportType - 24 > 1 && reportType - 58 > 3)
				{
					goto IL_1408;
				}
			}
			else if (reportType <= 79)
			{
				if (reportType - 62 > 3 && reportType != 79)
				{
					goto IL_1408;
				}
				goto IL_CB1;
			}
			else if (reportType - 123 > 2 && reportType != 132)
			{
				goto IL_1408;
			}
			if (!this.fromCapital)
			{
				CustomSelfDrawPanel.CSDLabel lblMainText2 = this.lblMainText;
				lblMainText2.Text = lblMainText2.Text + " (" + GameEngine.Instance.World.getVillageName(returnData.attackingVillage) + ")";
			}
			else
			{
				this.lblMainText.Text = this.reportOwner;
			}
			this.lblSubTitle.Text = SK.Text("Reports_Attacks_Village", "Attacks");
			short reportType2 = returnData.reportType;
			if (reportType2 <= 25)
			{
				if (reportType2 != 24)
				{
					if (reportType2 == 25)
					{
						this.lblSecondaryText.Text = SK.Text("GENERIC_A_Wolf_Lair", "A Wolf Lair");
					}
				}
				else
				{
					this.lblSecondaryText.Text = SK.Text("GENERIC_A_Bandit_Camp", "A Bandit Camp");
				}
			}
			else
			{
				switch (reportType2)
				{
				case 58:
					this.lblSecondaryText.Text = SK.Text("GENERIC_Rats_Castle", "Rat's Castle");
					break;
				case 59:
					this.lblSecondaryText.Text = SK.Text("GENERIC_Snakes_Castle", "Snake's Castle");
					break;
				case 60:
					this.lblSecondaryText.Text = SK.Text("GENERIC_Pigs_Castle", "Pig's Castle");
					break;
				case 61:
					this.lblSecondaryText.Text = SK.Text("GENERIC_Wolfs_Castle", "Wolf's Castle");
					break;
				default:
					switch (reportType2)
					{
					case 123:
						this.lblSecondaryText.Text = SK.Text("GENERIC_Paladin_Castle", "Paladin's Castle");
						break;
					case 124:
						this.lblSecondaryText.Text = SK.Text("GENERIC_Paladin_Castle", "Paladin's Castle");
						break;
					case 125:
						this.lblSecondaryText.Text = string.Concat(new string[]
						{
							SK.Text("GENERIC_Treasure_Castle", "Treasure Castle"),
							" ",
							SK.Text("GENERIC_TREASURE_CASTLE_LEVEL", "Level"),
							" : ",
							(returnData.genericData31 + 1).ToString()
						});
						if (returnData.genericData29 >= 100 && returnData.wasAlreadyRead)
						{
							this.defenderValuesPanel.addChests(returnData.genericData29 - 100);
						}
						break;
					default:
						if (reportType2 == 132)
						{
							this.lblSecondaryText.Text = SK.Text("CommonDataTypes_Royal_Tower", "Royal Tower");
						}
						break;
					}
					break;
				}
			}
			this.lblSpoils.Text = "";
			this.lblHonour.Text = SK.Text("GENERIC_Honour", "Honour") + " : " + returnData.genericData11.ToString("N", this.nfi);
			if (!returnData.successStatus)
			{
				this.lblResult.Text = SK.Text("GENERIC_The_Defender_Wins", "The Defender Wins");
			}
			else
			{
				if (GameEngine.Instance.LocalWorldData.AIWorld && returnData.genericData20 == 0 && returnData.genericData21 >= 0 && returnData.genericData30 == 1)
				{
					this.lblTargetVillageInfo.Text = this.lblSecondaryText.Text + " - " + SK.Text("GENERIC_Captured", "Captured");
				}
				if (returnData.reportType == 125 && returnData.genericData20 >= 700 && returnData.genericData20 < 710)
				{
					this.lblHonour.Text = "";
					switch (returnData.genericData20)
					{
					case 700:
						this.lblTargetVillageInfo.Text = SK.Text("REPORTS_TreasureWheelSpins1", "Treasure Found : Tier 1 Wheel Spin");
						this.imgWheelPrize.Image = GFXLibrary.wheel_report_icons[0];
						break;
					case 701:
						this.lblTargetVillageInfo.Text = SK.Text("REPORTS_TreasureWheelSpins2", "Treasure Found : Tier 2 Wheel Spin");
						this.imgWheelPrize.Image = GFXLibrary.wheel_report_icons[1];
						break;
					case 702:
						this.lblTargetVillageInfo.Text = SK.Text("REPORTS_TreasureWheelSpins3", "Treasure Found : Tier 3 Wheel Spin");
						this.imgWheelPrize.Image = GFXLibrary.wheel_report_icons[2];
						break;
					case 703:
						this.lblTargetVillageInfo.Text = SK.Text("REPORTS_TreasureWheelSpins4", "Treasure Found : Tier 4 Wheel Spin");
						this.imgWheelPrize.Image = GFXLibrary.wheel_report_icons[3];
						break;
					case 704:
						this.lblTargetVillageInfo.Text = SK.Text("REPORTS_TreasureWheelSpins5", "Treasure Found : Tier 5 Wheel Spin");
						this.imgWheelPrize.Image = GFXLibrary.wheel_report_icons[4];
						break;
					}
					this.imgWheelPrize.Position = new Point(225, 430);
					if (base.hasBackground())
					{
						this.imgBackground.addControl(this.imgWheelPrize);
					}
					else
					{
						base.addControl(this.imgWheelPrize);
					}
				}
			}
			if (returnData.genericData21 != 1 || (returnData.genericData20 >= 700 && returnData.genericData20 < 710))
			{
				goto IL_1408;
			}
			if (!returnData.wasAlreadyRead)
			{
				this.viewResultFunction(false);
				return;
			}
			flag = true;
			goto IL_1408;
			IL_CB1:
			this.lblSpoils.Text = "";
			if (returnData.reportType == 3)
			{
				if (returnData.otherUser.Length == 0)
				{
					this.lblMainText.Text = SK.Text("GENERIC_An_Unknown_Player", "An Unknown Player");
				}
				else
				{
					this.lblMainText.Text = returnData.otherUser;
				}
				CustomSelfDrawPanel.CSDLabel lblMainText3 = this.lblMainText;
				lblMainText3.Text = lblMainText3.Text + " (" + GameEngine.Instance.World.getVillageName(returnData.attackingVillage) + ")";
			}
			else
			{
				short reportType3 = returnData.reportType;
				switch (reportType3)
				{
				case 62:
					this.lblMainText.Text = SK.Text("GENERIC_CharacterName_Rat", "Rat");
					break;
				case 63:
					this.lblMainText.Text = SK.Text("GENERIC_CharacterName_Snake", "Snake");
					break;
				case 64:
					this.lblMainText.Text = SK.Text("GENERIC_CharacterName_Pig", "Pig");
					break;
				case 65:
					this.lblMainText.Text = SK.Text("GENERIC_CharacterName_Wolf", "Wolf");
					break;
				default:
					if (reportType3 == 79)
					{
						this.lblMainText.Text = SK.Text("GENERIC_CharacterName_The_Enemy", "The Enemy");
					}
					break;
				}
			}
			if (returnData.genericData11 < 0)
			{
				this.lblHonour.Text = SK.Text("GENERIC_Honour_Cost", "Honour Cost") + " : " + (-returnData.genericData11).ToString("N", this.nfi);
			}
			else
			{
				this.lblHonour.Text = SK.Text("GENERIC_Honour", "Honour") + " : " + returnData.genericData11.ToString("N", this.nfi);
			}
			this.lblSubTitle.Text = SK.Text("Reports_Attacks_Village", "Attacks");
			if (this.toCapital)
			{
				this.lblSecondaryText.Text = this.reportOwner;
			}
			else if (this.reportOwner.Length == 0)
			{
				this.lblSecondaryText.Text = SK.Text("GENERIC_An_Empty_Village", "An empty village");
			}
			else
			{
				this.lblSecondaryText.Text = this.reportOwner + " (" + GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + ")";
			}
			if (returnData.successStatus)
			{
				this.lblResult.Text = SK.Text("GENERIC_The_Defender_Wins", "The Defender Wins");
			}
			else if (returnData.genericData20 == 0 && returnData.genericData21 >= 0)
			{
				if (returnData.genericData30 == 11 || returnData.genericData30 == 13)
				{
					this.lblTargetVillageInfo.Text = GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + " - " + SK.Text("GENERIC_Was_Attacked", "Was attacked");
				}
				else
				{
					this.lblTargetVillageInfo.Text = GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + " - " + SK.Text("GENERIC_Captured", "Captured");
				}
			}
			else if (returnData.genericData20 == 10 && returnData.genericData21 >= 0)
			{
				this.lblTargetVillageInfo.Text = GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + " - " + SK.Text("GENERIC_Made_a_Vassal", "Made a vassal");
			}
			else if (returnData.genericData20 == 5 && returnData.genericData21 >= 0)
			{
				this.lblTargetVillageInfo.Text = GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + " - " + SK.Text("GENERIC_Has_Been_Razed", "Has been razed");
			}
			else if (returnData.genericData20 == 6)
			{
				this.lblTargetVillageInfo.Text = GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + " - " + SK.Text("GENERIC_Has_Been_Raided", "Has been raided");
				this.lblSpoils.Text = returnData.genericData21.ToString("N", this.nfi) + " " + SK.Text("GENERIC_Gold_Raided", "Gold raided");
			}
			else if (returnData.genericData20 == 0 && returnData.genericData21 == -25)
			{
				this.lblTargetVillageInfo.Text = SK.Text("GENERIC_Peacetime_Fail", "Attack Failed, village under Peace Time");
			}
			else
			{
				this.lblTargetVillageInfo.Text = GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + " - " + SK.Text("GENERIC_Was_Attacked", "Was attacked");
			}
			if (returnData.genericData20 == 2)
			{
				int num2 = returnData.genericData22 + returnData.genericData23 + returnData.genericData24 + returnData.genericData25 + returnData.genericData26 + returnData.genericData27 + returnData.genericData28 + returnData.genericData29;
				this.lblSpoils.Text = num2.ToString("N", this.nfi) + " " + SK.Text("GENERIC_Resources_Lost", "Resources lost");
				this.btnShowResources.Visible = true;
			}
			else if (returnData.genericData20 > 1000)
			{
				if (returnData.genericData22 >= 0)
				{
					this.lblSpoils.Text = VillageBuildingsData.getBuildingName(returnData.genericData22);
				}
				if (returnData.genericData23 >= 0)
				{
					CustomSelfDrawPanel.CSDLabel csdlabel9 = this.lblSpoils;
					csdlabel9.Text = csdlabel9.Text + ", " + VillageBuildingsData.getBuildingName(returnData.genericData23);
				}
				if (returnData.genericData24 >= 0)
				{
					CustomSelfDrawPanel.CSDLabel csdlabel10 = this.lblSpoils;
					csdlabel10.Text = csdlabel10.Text + ", " + VillageBuildingsData.getBuildingName(returnData.genericData24);
				}
				if (returnData.genericData25 >= 0)
				{
					CustomSelfDrawPanel.CSDLabel csdlabel11 = this.lblSpoils;
					csdlabel11.Text = csdlabel11.Text + ", " + VillageBuildingsData.getBuildingName(returnData.genericData25);
				}
				if (returnData.genericData26 >= 0)
				{
					CustomSelfDrawPanel.CSDLabel csdlabel12 = this.lblSpoils;
					csdlabel12.Text = csdlabel12.Text + ", " + VillageBuildingsData.getBuildingName(returnData.genericData26);
				}
				if (returnData.genericData27 >= 0)
				{
					CustomSelfDrawPanel.CSDLabel csdlabel13 = this.lblSpoils;
					csdlabel13.Text = csdlabel13.Text + ", " + VillageBuildingsData.getBuildingName(returnData.genericData27);
				}
				if (returnData.genericData28 >= 0)
				{
					CustomSelfDrawPanel.CSDLabel csdlabel14 = this.lblSpoils;
					csdlabel14.Text = csdlabel14.Text + ", " + VillageBuildingsData.getBuildingName(returnData.genericData28);
				}
				if (returnData.genericData29 >= 0)
				{
					CustomSelfDrawPanel.CSDLabel csdlabel15 = this.lblSpoils;
					csdlabel15.Text = csdlabel15.Text + ", " + VillageBuildingsData.getBuildingName(returnData.genericData29);
				}
				CustomSelfDrawPanel.CSDLabel csdlabel16 = this.lblSpoils;
				csdlabel16.Text = csdlabel16.Text + " - " + SK.Text("GENERIC_Destroyed", "Destroyed");
			}
			else if (returnData.genericData20 == 1000)
			{
				this.lblSpoils.Text = SK.Text("GENERIC_You_Had_No_buildings_Destroyed", "You had no buildings that could be destroyed.");
			}
			else if (returnData.genericData20 == 1)
			{
				this.lblSpoils.Text = SK.Text("GENERIC_The_Attack_Failed", "The attack failed.");
			}
			IL_1408:
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
			if (!returnData.wasAlreadyRead)
			{
				this.lblResult.Text = "";
				this.btnShowResources.Visible = false;
				this.lblSpoils.Text = "";
				this.lblTargetVillageInfo.Text = "";
				this.lblHonour.Text = "";
				this.btnViewResult.Visible = true;
				this.imgWheelPrize.Visible = false;
			}
			else
			{
				this.btnViewResult.Visible = false;
				this.imgWheelPrize.Visible = true;
			}
			if (!returnData.snapshotAvailable)
			{
				this.btnViewBattle.Visible = false;
			}
			else
			{
				this.btnViewBattle.Visible = true;
			}
			if (flag)
			{
				this.btnViewBattle.Visible = false;
				this.btnViewResult.Visible = false;
				this.lblHonour.Visible = false;
				this.lblSpoils.Visible = false;
				short reportType4 = returnData.reportType;
				if (reportType4 <= 25)
				{
					if (reportType4 != 24)
					{
						if (reportType4 == 25)
						{
							this.lblTargetVillageInfo.Text = SK.Text("Reports_Wolf_Lair_Cleared", "The Wolf Lair had already been cleared.");
						}
					}
					else
					{
						this.lblTargetVillageInfo.Text = SK.Text("Reports_Bandit_Camp_Cleared", "The Bandit Camp had already been cleared.");
					}
				}
				else if (reportType4 - 58 <= 3 || reportType4 - 123 <= 2 || reportType4 == 132)
				{
					this.lblTargetVillageInfo.Text = SK.Text("Reports_Castle_Cleared", "The Castle had already been cleared.");
				}
				if (returnData.genericData31 >= 10000)
				{
					this.lblFlagCaptured.Visible = true;
				}
			}
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x000764DC File Offset: 0x000746DC
		private void setCapitalFlags(GetReport_ReturnType returnData, out bool fromCap, out bool toCap)
		{
			fromCap = false;
			toCap = false;
			short reportType = returnData.reportType;
			if (reportType <= 61)
			{
				if (reportType <= 3)
				{
					if (reportType != 1)
					{
						if (reportType != 3)
						{
							return;
						}
						goto IL_8E;
					}
				}
				else if (reportType - 24 > 1 && reportType - 58 > 3)
				{
					return;
				}
			}
			else if (reportType <= 79)
			{
				if (reportType - 62 > 3 && reportType != 79)
				{
					return;
				}
				goto IL_8E;
			}
			else if (reportType - 123 > 2 && reportType != 132)
			{
				return;
			}
			if (returnData.attackingVillage >= 0 && GameEngine.Instance.World.isRegionCapital(returnData.attackingVillage))
			{
				this.reportOwner = GameEngine.Instance.World.getParishNameFromVillageID(returnData.attackingVillage);
				fromCap = true;
				return;
			}
			return;
			IL_8E:
			if (returnData.defendingVillage >= 0 && GameEngine.Instance.World.isRegionCapital(returnData.defendingVillage))
			{
				this.reportOwner = GameEngine.Instance.World.getParishNameFromVillageID(returnData.defendingVillage);
				toCap = true;
			}
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x000765B8 File Offset: 0x000747B8
		private void initResourceArea(GetReport_ReturnType returnData)
		{
			this.areaResources.Size = new Size(this.attackerValuesPanel.Width * 2, this.attackerValuesPanel.Height);
			this.areaResources.Position = new Point(base.Width / 2 - this.areaResources.Width / 2, this.attackerValuesPanel.Y);
			CustomSelfDrawPanel.CSDLine csdline = new CustomSelfDrawPanel.CSDLine();
			csdline.Position = new Point(1, 1);
			csdline.Size = new Size(this.areaResources.Width - 2, 0);
			CustomSelfDrawPanel.CSDLine csdline2 = new CustomSelfDrawPanel.CSDLine();
			csdline2.Position = new Point(1, this.areaResources.Height - 1);
			csdline2.Size = new Size(this.areaResources.Width, 0);
			this.areaResources.addControl(csdline);
			this.areaResources.addControl(csdline2);
			this.areaResources.Visible = false;
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x000766A4 File Offset: 0x000748A4
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

		// Token: 0x060005DC RID: 1500 RVA: 0x0000B1B1 File Offset: 0x000093B1
		protected void viewResultClick()
		{
			this.viewResultFunction(true);
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x0007671C File Offset: 0x0007491C
		private void viewResultFunction(bool playSound)
		{
			if (playSound)
			{
				if (this.m_returnData.successStatus)
				{
					GameEngine.Instance.playInterfaceSound("AttackReportPanel_view_result_win");
				}
				else
				{
					GameEngine.Instance.playInterfaceSound("AttackReportPanel_view_result_lose");
				}
			}
			this.m_returnData.wasAlreadyRead = true;
			this.setData(this.m_returnData, false);
			InterfaceMgr.Instance.setReportAlreadyRead(this.m_returnData.reportID);
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x00076788 File Offset: 0x00074988
		private void showResourcesClick()
		{
			GameEngine.Instance.playInterfaceSound("AttackReportPanel_show_resources");
			this.resourcesPanel.Visible = !this.resourcesPanel.Visible;
			this.attackerValuesPanel.Visible = !this.attackerValuesPanel.Visible;
			this.defenderValuesPanel.Visible = !this.defenderValuesPanel.Visible;
			if (this.resourcesPanel.Visible)
			{
				this.btnShowResources.Text.Text = SK.Text("Reports_Hide_Resources", "Hide Resources");
				this.resourcesPanel.setData(this.m_returnData);
				return;
			}
			this.btnShowResources.Text.Text = SK.Text("Reports_Show_Resources", "Show Resources");
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x0007684C File Offset: 0x00074A4C
		protected void viewBattleClick()
		{
			GameEngine.Instance.playInterfaceSound("AttackReportPanel_view_battle");
			ViewBattle_ReturnType viewBattle_ReturnType = (ViewBattle_ReturnType)InterfaceMgr.Instance.getReportData(this.reportID);
			if (viewBattle_ReturnType == null)
			{
				RemoteServices.Instance.set_ViewBattle_UserCallBack(new RemoteServices.ViewBattle_UserCallBack(this.viewBattleCallback));
				RemoteServices.Instance.ViewBattle(this.reportID);
				return;
			}
			DateTime now = DateTime.Now;
			if ((now - this.lastViewTime).TotalSeconds > 2.0)
			{
				this.lastViewTime = now;
				StatTrackingClient.Instance().ActivateTrigger(5, null);
				this.viewBattle(viewBattle_ReturnType);
			}
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x000768E8 File Offset: 0x00074AE8
		private void viewBattleCallback(ViewBattle_ReturnType returnData)
		{
			if (returnData.Success && this.m_returnData != null)
			{
				InterfaceMgr.Instance.setReportAlreadyRead(this.m_returnData.reportID);
				InterfaceMgr.Instance.setReportData(returnData, this.m_returnData.reportID);
				this.viewBattle(returnData);
				return;
			}
			this.m_returnData.snapshotAvailable = false;
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x00076944 File Offset: 0x00074B44
		private void viewBattle(ViewBattle_ReturnType returnData)
		{
			this.m_parent.closeControl(true);
			InterfaceMgr.Instance.reactiveMainWindow();
			InterfaceMgr.Instance.getMainTabBar().selectDummyTab(6);
			int campMode = 0;
			if (this.m_returnData.reportType == 24)
			{
				campMode = 1;
			}
			else if (this.m_returnData.reportType == 25)
			{
				campMode = 2;
			}
			int num = -1;
			int num2 = -1;
			int num3 = -1;
			switch (this.m_returnData.genericData30)
			{
			case 2:
			case 4:
			case 5:
			case 6:
			case 7:
				num = this.m_returnData.genericData31;
				if (num > 9999)
				{
					num -= 10000;
				}
				break;
			case 3:
				num2 = this.m_returnData.genericData31;
				if (num2 > 9999)
				{
					num2 -= 10000;
				}
				break;
			case 12:
				num3 = this.m_returnData.genericData31;
				if (num3 > 9999)
				{
					num3 -= 10000;
				}
				break;
			}
			Sound.playBattleMusic();
			GameEngine.Instance.InitBattle(returnData.castleMapSnapshot, returnData.damageMapSnapshot, returnData.castleTroopsSnapshot, returnData.attackMapSnapshot, returnData.keepLevel, returnData.defenderResearchData, returnData.attackerResearchData, campMode, num, num2, num3, this.m_returnData.genericData30, this.m_returnData.defendingVillage, this.m_returnData, returnData.landType);
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x00076AA0 File Offset: 0x00074CA0
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

		// Token: 0x060005E3 RID: 1507 RVA: 0x00076B50 File Offset: 0x00074D50
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

		// Token: 0x0400076A RID: 1898
		protected CustomSelfDrawPanel.CSDButton btnViewBattle = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400076B RID: 1899
		protected CustomSelfDrawPanel.CSDButton btnShowResources = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400076C RID: 1900
		protected CustomSelfDrawPanel.CSDButton btnViewResult = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400076D RID: 1901
		protected CustomSelfDrawPanel.CSDLabel lblResult = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400076E RID: 1902
		protected CustomSelfDrawPanel.CSDLabel lblSpoils = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400076F RID: 1903
		protected CustomSelfDrawPanel.CSDLabel lblTargetVillageInfo = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000770 RID: 1904
		protected CustomSelfDrawPanel.CSDLabel lblHonour = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000771 RID: 1905
		protected CustomSelfDrawPanel.CSDLabel lblFlagCaptured = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000772 RID: 1906
		private CustomSelfDrawPanel.CSDArea areaResources = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000773 RID: 1907
		private CustomSelfDrawPanel.CSDImage imgWheelPrize = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000774 RID: 1908
		private ReportBattleValuesPanel attackerValuesPanel;

		// Token: 0x04000775 RID: 1909
		private ReportBattleValuesPanel defenderValuesPanel;

		// Token: 0x04000776 RID: 1910
		private AttackReportPanelDerived.ReportResourcePanel resourcesPanel = new AttackReportPanelDerived.ReportResourcePanel();

		// Token: 0x04000777 RID: 1911
		private Point mapTarget = new Point(-1, -1);

		// Token: 0x04000778 RID: 1912
		private double targetZoomLevel;

		// Token: 0x04000779 RID: 1913
		private DateTime lastViewTime = DateTime.MinValue;

		// Token: 0x0400077A RID: 1914
		protected bool fromCapital;

		// Token: 0x0400077B RID: 1915
		protected bool toCapital;

		// Token: 0x0400077C RID: 1916
		protected TroopCount attackersInitial = new TroopCount();

		// Token: 0x0400077D RID: 1917
		protected TroopCount attackersRemaining = new TroopCount();

		// Token: 0x0400077E RID: 1918
		protected TroopCount defendersInitial = new TroopCount();

		// Token: 0x0400077F RID: 1919
		protected TroopCount defendersRemaining = new TroopCount();

		// Token: 0x020000D0 RID: 208
		private class ReportResourcePanel : CustomSelfDrawPanel.CSDArea
		{
			// Token: 0x060005E4 RID: 1508 RVA: 0x00076C00 File Offset: 0x00074E00
			public void init()
			{
				this.lblHeader.Text = SK.Text("GENERIC_Resources", "Resources");
				this.lblHeader.Color = global::ARGBColors.Black;
				this.lblHeader.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.lblHeader.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.lblHeader.Position = new Point(0, 0);
				this.lblHeader.Size = new Size(base.Width, 24);
				this.imgResource1.Image = GFXLibrary.com_32_wood_DS;
				this.imgResource1.setSizeToImage();
				this.imgResource1.Position = new Point(base.Width / 2 - 80 - this.imgResource1.Width, this.lblHeader.Rectangle.Bottom + 5);
				this.imgResource2.Size = this.imgResource1.Size;
				this.imgResource2.Position = new Point(base.Width / 2 + 80, this.lblHeader.Rectangle.Bottom + 5);
				this.imgResource3.Size = this.imgResource1.Size;
				this.imgResource3.Position = new Point(this.imgResource1.X, this.imgResource1.Rectangle.Bottom + 2);
				this.imgResource4.Size = this.imgResource1.Size;
				this.imgResource4.Position = new Point(this.imgResource2.X, this.imgResource2.Rectangle.Bottom + 2);
				this.imgResource5.Size = this.imgResource1.Size;
				this.imgResource5.Position = new Point(this.imgResource1.X, this.imgResource3.Rectangle.Bottom + 2);
				this.imgResource6.Size = this.imgResource1.Size;
				this.imgResource6.Position = new Point(this.imgResource2.X, this.imgResource4.Rectangle.Bottom + 2);
				this.imgResource7.Size = this.imgResource1.Size;
				this.imgResource7.Position = new Point(this.imgResource1.X, this.imgResource5.Rectangle.Bottom + 2);
				this.imgResource8.Size = this.imgResource1.Size;
				this.imgResource8.Position = new Point(this.imgResource2.X, this.imgResource6.Rectangle.Bottom + 2);
				this.lblResource1.Text = "";
				this.lblResource1.Color = global::ARGBColors.Black;
				this.lblResource1.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.lblResource1.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.lblResource1.Position = new Point(this.imgResource1.Rectangle.Right + 2, this.imgResource1.Y);
				this.lblResource1.Size = new Size(base.Width / 2 - this.lblResource1.X, this.imgResource1.Height);
				this.lblResource2.Text = "";
				this.lblResource2.Color = global::ARGBColors.Black;
				this.lblResource2.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.lblResource2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.lblResource2.Position = new Point(base.Width / 2, this.imgResource2.Y);
				this.lblResource2.Size = new Size(base.Width / 2 - this.lblResource1.X, this.imgResource1.Height);
				this.lblResource3.Text = "";
				this.lblResource3.Color = global::ARGBColors.Black;
				this.lblResource3.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.lblResource3.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.lblResource3.Position = new Point(this.imgResource1.Rectangle.Right + 2, this.imgResource3.Y);
				this.lblResource3.Size = new Size(base.Width / 2 - this.lblResource1.X, this.imgResource1.Height);
				this.lblResource4.Text = "";
				this.lblResource4.Color = global::ARGBColors.Black;
				this.lblResource4.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.lblResource4.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.lblResource4.Position = new Point(base.Width / 2, this.imgResource4.Y);
				this.lblResource4.Size = new Size(base.Width / 2 - this.lblResource1.X, this.imgResource1.Height);
				this.lblResource5.Text = "";
				this.lblResource5.Color = global::ARGBColors.Black;
				this.lblResource5.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.lblResource5.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.lblResource5.Position = new Point(this.imgResource1.Rectangle.Right + 2, this.imgResource5.Y);
				this.lblResource5.Size = new Size(base.Width / 2 - this.lblResource1.X, this.imgResource1.Height);
				this.lblResource6.Text = "";
				this.lblResource6.Color = global::ARGBColors.Black;
				this.lblResource6.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.lblResource6.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.lblResource6.Position = new Point(base.Width / 2, this.imgResource6.Y);
				this.lblResource6.Size = new Size(base.Width / 2 - this.lblResource1.X, this.imgResource1.Height);
				this.lblResource7.Text = "";
				this.lblResource7.Color = global::ARGBColors.Black;
				this.lblResource7.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.lblResource7.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.lblResource7.Position = new Point(this.imgResource1.Rectangle.Right + 2, this.imgResource7.Y);
				this.lblResource7.Size = new Size(base.Width / 2 - this.lblResource1.X, this.imgResource1.Height);
				this.lblResource8.Text = "";
				this.lblResource8.Color = global::ARGBColors.Black;
				this.lblResource8.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.lblResource8.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.lblResource8.Position = new Point(base.Width / 2, this.imgResource8.Y);
				this.lblResource8.Size = new Size(base.Width / 2 - this.lblResource1.X, this.imgResource1.Height);
				base.addControl(this.lblHeader);
				base.addControl(this.imgResource1);
				base.addControl(this.lblResource1);
				base.addControl(this.imgResource2);
				base.addControl(this.lblResource2);
				base.addControl(this.imgResource3);
				base.addControl(this.lblResource3);
				base.addControl(this.imgResource4);
				base.addControl(this.lblResource4);
				base.addControl(this.imgResource5);
				base.addControl(this.lblResource5);
				base.addControl(this.imgResource6);
				base.addControl(this.lblResource6);
				base.addControl(this.imgResource7);
				base.addControl(this.lblResource7);
				base.addControl(this.imgResource8);
				base.addControl(this.lblResource8);
				foreach (CustomSelfDrawPanel.CSDControl csdcontrol in base.Controls)
				{
					csdcontrol.Visible = false;
				}
			}

			// Token: 0x060005E5 RID: 1509 RVA: 0x000774DC File Offset: 0x000756DC
			public void setData(GetReport_ReturnType data)
			{
				this.lblHeader.Visible = true;
				switch (data.genericData30)
				{
				case 2:
					this.imgResource1.Image = GFXLibrary.com_32_wood_DS;
					this.lblResource1.Text = data.genericData22.ToString();
					this.lblResource1.Visible = true;
					this.imgResource1.Visible = true;
					this.imgResource2.Image = GFXLibrary.com_32_stone_DS;
					this.lblResource2.Text = data.genericData23.ToString();
					this.lblResource2.Visible = true;
					this.imgResource2.Visible = true;
					this.imgResource3.Image = GFXLibrary.com_32_iron_DS;
					this.lblResource3.Text = data.genericData24.ToString();
					this.lblResource3.Visible = true;
					this.imgResource3.Visible = true;
					this.imgResource4.Image = GFXLibrary.com_32_pitch_DS;
					this.lblResource4.Text = data.genericData25.ToString();
					this.lblResource4.Visible = true;
					this.imgResource4.Visible = true;
					return;
				case 3:
					break;
				case 4:
					this.imgResource1.Image = GFXLibrary.com_32_apples_DS;
					this.lblResource1.Text = data.genericData22.ToString();
					this.imgResource1.Visible = true;
					this.lblResource1.Visible = true;
					this.imgResource2.Image = GFXLibrary.com_32_bread_DS;
					this.lblResource2.Text = data.genericData23.ToString();
					this.imgResource2.Visible = true;
					this.lblResource2.Visible = true;
					this.imgResource3.Image = GFXLibrary.com_32_cheese_DS;
					this.lblResource3.Text = data.genericData24.ToString();
					this.imgResource3.Visible = true;
					this.lblResource3.Visible = true;
					this.imgResource4.Image = GFXLibrary.com_32_meat_DS;
					this.lblResource4.Text = data.genericData25.ToString();
					this.imgResource4.Visible = true;
					this.lblResource4.Visible = true;
					this.imgResource5.Image = GFXLibrary.com_32_fish_DS;
					this.lblResource5.Text = data.genericData26.ToString();
					this.imgResource5.Visible = true;
					this.lblResource5.Visible = true;
					this.imgResource6.Image = GFXLibrary.com_32_veg_DS;
					this.lblResource6.Text = data.genericData27.ToString();
					this.imgResource6.Visible = true;
					this.lblResource6.Visible = true;
					return;
				case 5:
					this.imgResource1.Image = GFXLibrary.com_32_furniture_DS;
					this.lblResource1.Text = data.genericData22.ToString();
					this.imgResource1.Visible = true;
					this.lblResource1.Visible = true;
					this.imgResource2.Image = GFXLibrary.com_32_clothes_DS;
					this.lblResource2.Text = data.genericData23.ToString();
					this.imgResource2.Visible = true;
					this.lblResource2.Visible = true;
					this.imgResource3.Image = GFXLibrary.com_32_venison_DS;
					this.lblResource3.Text = data.genericData24.ToString();
					this.imgResource3.Visible = true;
					this.lblResource3.Visible = true;
					this.imgResource4.Image = GFXLibrary.com_32_wine_DS;
					this.lblResource4.Text = data.genericData25.ToString();
					this.imgResource4.Visible = true;
					this.lblResource4.Visible = true;
					this.imgResource5.Image = GFXLibrary.com_32_salt_DS;
					this.lblResource5.Text = data.genericData26.ToString();
					this.imgResource5.Visible = true;
					this.lblResource5.Visible = true;
					this.imgResource6.Image = GFXLibrary.com_32_metalware_DS;
					this.lblResource6.Text = data.genericData27.ToString();
					this.imgResource6.Visible = true;
					this.lblResource6.Visible = true;
					this.imgResource7.Image = GFXLibrary.com_32_spices_DS;
					this.lblResource7.Text = data.genericData28.ToString();
					this.imgResource7.Visible = true;
					this.lblResource7.Visible = true;
					this.imgResource8.Image = GFXLibrary.com_32_silk_DS;
					this.lblResource8.Text = data.genericData29.ToString();
					this.imgResource8.Visible = true;
					this.lblResource8.Visible = true;
					return;
				case 6:
					this.imgResource1.Image = GFXLibrary.com_32_ale_DS;
					this.lblResource1.Text = data.genericData22.ToString();
					this.imgResource1.Visible = true;
					this.lblResource1.Visible = true;
					return;
				case 7:
					this.imgResource1.Image = GFXLibrary.com_32_bows_DS;
					this.lblResource1.Text = data.genericData22.ToString();
					this.imgResource1.Visible = true;
					this.lblResource1.Visible = true;
					this.imgResource2.Image = GFXLibrary.com_32_pikes_DS;
					this.lblResource2.Text = data.genericData23.ToString();
					this.imgResource2.Visible = true;
					this.lblResource2.Visible = true;
					this.imgResource3.Image = GFXLibrary.com_32_swords_DS;
					this.lblResource3.Text = data.genericData24.ToString();
					this.imgResource3.Visible = true;
					this.lblResource3.Visible = true;
					this.imgResource4.Image = GFXLibrary.com_32_armour_DS;
					this.lblResource4.Text = data.genericData25.ToString();
					this.imgResource4.Visible = true;
					this.lblResource4.Visible = true;
					this.imgResource5.Image = GFXLibrary.com_32_catapults_DS;
					this.lblResource5.Text = data.genericData26.ToString();
					this.imgResource5.Visible = true;
					this.lblResource5.Visible = true;
					break;
				default:
					return;
				}
			}

			// Token: 0x04000780 RID: 1920
			private CustomSelfDrawPanel.CSDLabel lblHeader = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000781 RID: 1921
			private CustomSelfDrawPanel.CSDLabel lblResource1 = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000782 RID: 1922
			private CustomSelfDrawPanel.CSDLabel lblResource2 = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000783 RID: 1923
			private CustomSelfDrawPanel.CSDLabel lblResource3 = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000784 RID: 1924
			private CustomSelfDrawPanel.CSDLabel lblResource4 = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000785 RID: 1925
			private CustomSelfDrawPanel.CSDLabel lblResource5 = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000786 RID: 1926
			private CustomSelfDrawPanel.CSDLabel lblResource6 = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000787 RID: 1927
			private CustomSelfDrawPanel.CSDLabel lblResource7 = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000788 RID: 1928
			private CustomSelfDrawPanel.CSDLabel lblResource8 = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000789 RID: 1929
			private CustomSelfDrawPanel.CSDImage imgResource1 = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x0400078A RID: 1930
			private CustomSelfDrawPanel.CSDImage imgResource2 = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x0400078B RID: 1931
			private CustomSelfDrawPanel.CSDImage imgResource3 = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x0400078C RID: 1932
			private CustomSelfDrawPanel.CSDImage imgResource4 = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x0400078D RID: 1933
			private CustomSelfDrawPanel.CSDImage imgResource5 = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x0400078E RID: 1934
			private CustomSelfDrawPanel.CSDImage imgResource6 = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x0400078F RID: 1935
			private CustomSelfDrawPanel.CSDImage imgResource7 = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04000790 RID: 1936
			private CustomSelfDrawPanel.CSDImage imgResource8 = new CustomSelfDrawPanel.CSDImage();
		}
	}
}
