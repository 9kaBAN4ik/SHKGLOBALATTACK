using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x020000E0 RID: 224
	public partial class BattleResultPopup : MyFormBase
	{
		// Token: 0x0600068F RID: 1679 RVA: 0x0008AF4C File Offset: 0x0008914C
		public BattleResultPopup()
		{
			this.InitializeComponent();
			this.lblHonour.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.lblSpoils.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.lblTargetVillageNameAndInfo.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.lblDate.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.lblResult.Font = FontManager.GetFont("Microsoft Sans Serif", 12f);
			this.lblAttackType.Font = FontManager.GetFont("Microsoft Sans Serif", 16f);
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x0008B020 File Offset: 0x00089220
		public void init(bool attackerVictory, BattleTroopNumbers startingTroops, BattleTroopNumbers endingTroops, int attackType, int villageID, GetReport_ReturnType returnData, CastleMapBattlePanel2 parent)
		{
			base.ShowClose = false;
			this.lblVillageName.Text = SK.Text("BattleResultPopup_Village_Name", "Village Name");
			this.lblAttackType.Text = SK.Text("GENERIC_Attack_Type", "Attack Type");
			this.btnClose.Text = SK.Text("GENERIC_Close", "Close");
			this.btnMinimise.Text = SK.Text("BattleResultPopup_Minimise", "Minimise");
			this.label1.Text = SK.Text("GENERIC_Peasants", "Peasants");
			this.label2.Text = SK.Text("GENERIC_Archers", "Archers");
			this.label3.Text = SK.Text("GENERIC_Pikemen", "Pikemen");
			this.label4.Text = SK.Text("GENERIC_Swordsmen", "Swordsmen");
			this.label11.Text = SK.Text("GENERIC_Attackers", "Attackers");
			this.label12.Text = SK.Text("GENERIC_Defenders", "Defenders");
			this.label6.Text = SK.Text("GENERIC_Catapults", "Catapults");
			this.label5.Text = SK.Text("GENERIC_Captains", "Captains");
			this.lblWolves.Text = SK.Text("GENERIC_Wolves", "Wolves");
			this.btnShowResources.Text = SK.Text("GENERIC_Show_Resources", "Show Resources");
			this.lblHonour.Text = SK.Text("GENERIC_Honour", "Honour");
			this.lblSpoils.Text = SK.Text("GENERIC_Honour", "Honour");
			this.lblResult.Text = SK.Text("BattleResultPopup_Defender_won", "The Defender Won");
			string text = base.Title = (this.Text = SK.Text("BattleResultPopup_Battle_Results", "Battle Results"));
			this.showPostTutorialThingy = false;
			if (returnData == null)
			{
				returnData = new GetReport_ReturnType();
				returnData.successStatus = true;
				returnData.genericData11 = 24;
				returnData.reportType = 79;
				returnData.genericData20 = -1;
				returnData.reportTime = DateTime.Now;
				List<int> userVillageIDList = GameEngine.Instance.World.getUserVillageIDList();
				if (userVillageIDList.Count > 0)
				{
					returnData.defendingVillage = userVillageIDList[0];
				}
				this.showPostTutorialThingy = true;
			}
			BattleResultPopup.m_parent = parent;
			this.m_villageID = villageID;
			this.m_reportReturnData = returnData;
			this.lblAttackersPeasants.Text = endingTroops.numAttackingPeasants.ToString() + "/" + startingTroops.numAttackingPeasants.ToString() + "\n";
			this.lblAttackersArchers.Text = endingTroops.numAttackingArchers.ToString() + "/" + startingTroops.numAttackingArchers.ToString() + "\n";
			this.lblAttackersPikemen.Text = endingTroops.numAttackingPikemen.ToString() + "/" + startingTroops.numAttackingPikemen.ToString() + "\n";
			this.lblAttackersSwordsmen.Text = endingTroops.numAttackingSwordsmen.ToString() + "/" + startingTroops.numAttackingSwordsmen.ToString() + "\n";
			if (!attackerVictory && endingTroops.numAttackingPeasants == 0 && endingTroops.numAttackingArchers == 0 && endingTroops.numAttackingPikemen == 0 && endingTroops.numAttackingSwordsmen == 0)
			{
				endingTroops.numAttackingCatapults = 0;
			}
			this.lblAttackersCatapults.Text = endingTroops.numAttackingCatapults.ToString() + "/" + startingTroops.numAttackingCatapults.ToString() + "\n";
			this.lblAttackersCaptains.Text = endingTroops.numAttackingCaptains.ToString() + "/" + startingTroops.numAttackingCaptains.ToString() + "\n";
			this.lblDefendersPeasants.Text = endingTroops.numDefendingPeasants.ToString() + "/" + startingTroops.numDefendingPeasants.ToString() + "\n";
			this.lblDefendersArchers.Text = endingTroops.numDefendingArchers.ToString() + "/" + startingTroops.numDefendingArchers.ToString() + "\n";
			this.lblDefendersPikemen.Text = endingTroops.numDefendingPikemen.ToString() + "/" + startingTroops.numDefendingPikemen.ToString() + "\n";
			this.lblDefendersSwordsmen.Text = endingTroops.numDefendingSwordsmen.ToString() + "/" + startingTroops.numDefendingSwordsmen.ToString();
			this.lblDefendersCaptains.Text = endingTroops.numDefendingCaptains.ToString() + "/" + startingTroops.numDefendingCaptains.ToString();
			if (returnData.reportType == 24)
			{
				this.lblVillageName.Text = SK.Text("GENERIC_Bandit_Camp", "Bandit Camp");
				this.lblAttackType.Text = "";
			}
			else if (returnData.reportType == 25)
			{
				this.lblVillageName.Text = SK.Text("GENERIC_Wolf_Camp", "Wolf Lair");
				this.lblWolves.Visible = true;
				this.lblDefendersArchers.Visible = false;
				this.lblDefendersPikemen.Visible = false;
				this.lblDefendersSwordsmen.Visible = false;
				this.lblDefendersCaptains.Visible = false;
				this.lblDefendersPeasants.Text = endingTroops.numDefendingSwordsmen.ToString() + "/" + startingTroops.numDefendingSwordsmen.ToString();
				this.lblAttackType.Text = "";
			}
			else if (returnData.reportType == 58)
			{
				this.lblVillageName.Text = SK.Text("GENERIC_Rats_Castle", "Rat's Castle");
				this.lblAttackType.Text = "";
			}
			else if (returnData.reportType == 59)
			{
				this.lblVillageName.Text = SK.Text("GENERIC_Snakes_Castle", "Snake's Castle");
				this.lblAttackType.Text = "";
			}
			else if (returnData.reportType == 60)
			{
				this.lblVillageName.Text = SK.Text("GENERIC_Pigs_Castle", "Pig's Castle");
				this.lblAttackType.Text = "";
			}
			else if (returnData.reportType == 61)
			{
				this.lblVillageName.Text = SK.Text("GENERIC_Wolfs_Castle", "Wolf's Castle");
				this.lblAttackType.Text = "";
			}
			else if (returnData.reportType == 123)
			{
				this.lblVillageName.Text = SK.Text("GENERIC_Paladin_Castle", "Paladin's Castle");
				this.lblAttackType.Text = "";
			}
			else if (returnData.reportType == 124)
			{
				this.lblVillageName.Text = SK.Text("GENERIC_Paladin_Castle", "Paladin's Castle");
				this.lblAttackType.Text = "";
			}
			else if (returnData.reportType == 125)
			{
				this.lblVillageName.Text = string.Concat(new string[]
				{
					SK.Text("GENERIC_Treasure_Castle", "Treasure Castle"),
					" ",
					SK.Text("GENERIC_TREASURE_CASTLE_LEVEL", "Level"),
					" : ",
					(returnData.genericData31 + 1).ToString()
				});
				this.lblAttackType.Text = "";
			}
			else if (returnData.reportType == 132)
			{
				this.lblVillageName.Text = SK.Text("CommonDataTypes_Royal_Tower", "Royal Tower");
				this.lblAttackType.Text = "";
			}
			else
			{
				this.lblVillageName.Text = GameEngine.Instance.World.getVillageName(villageID);
				this.lblAttackType.Text = CastlesCommon.getAttackTypeLabel(attackType);
			}
			if (returnData == null)
			{
				returnData = new GetReport_ReturnType();
			}
			string otherUser = returnData.otherUser;
			string text2 = SK.Text("GENERIC_The_Attacker_Wins", "The Attacker Wins");
			string text3 = "";
			NumberFormatInfo nfi = GameEngine.NFI;
			string text4 = returnData.reportAboutUser;
			if (text4 == null || text4.Length == 0)
			{
				text4 = RemoteServices.Instance.UserName;
			}
			this.btnShowResources.Visible = false;
			short reportType = returnData.reportType;
			string str;
			if (reportType <= 61)
			{
				if (reportType <= 3)
				{
					if (reportType != 1)
					{
						if (reportType != 3)
						{
							goto IL_1734;
						}
						goto IL_10D8;
					}
					else
					{
						str = text4 + " (" + GameEngine.Instance.World.getVillageName(returnData.attackingVillage) + ")";
						if (otherUser.Length == 0)
						{
							SK.Text("GENERIC_An_Empty_Village", "An empty village");
						}
						else
						{
							otherUser = otherUser + " (" + GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + ")";
						}
						this.lblSpoils.Text = "";
						if (!returnData.successStatus)
						{
							text2 = SK.Text("GENERIC_The_Defender_Wins", "The Defender Wins");
						}
						else if (returnData.genericData20 == 0 && returnData.genericData21 >= 0)
						{
							text3 = ((returnData.genericData30 != 11 && returnData.genericData30 != 13) ? (GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + " - " + SK.Text("GENERIC_Captured", "Captured")) : (GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + " - " + SK.Text("GENERIC_Successfully_Attacked", "Successfully attacked")));
						}
						else if (returnData.genericData20 == 10 && returnData.genericData21 >= 0)
						{
							text3 = GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + " - " + SK.Text("GENERIC_Made_a_Vassal", "Made a vassal");
						}
						else if (returnData.genericData20 == 5 && returnData.genericData21 >= 0)
						{
							text3 = GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + " - " + SK.Text("GENERIC_Has_Been_Razed", "Has been razed");
						}
						else if (returnData.genericData20 == 6)
						{
							text3 = GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + " - " + SK.Text("GENERIC_Has_Been_Raided", "Has been raided");
							this.lblSpoils.Text = returnData.genericData21.ToString("N", nfi) + " " + SK.Text("GENERIC_Gold_Raided", "Gold raided");
						}
						else
						{
							text3 = GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + " - " + SK.Text("GENERIC_Successfully_Attacked", "Successfully attacked");
						}
						if (returnData.genericData11 < 0)
						{
							this.lblHonour.Text = SK.Text("GENERIC_Honour_Cost", "Honour Cost") + " : " + (-returnData.genericData11).ToString("N", nfi);
						}
						else
						{
							this.lblHonour.Text = SK.Text("GENERIC_Honour", "Honour") + " : " + returnData.genericData11.ToString("N", nfi);
						}
						if (returnData.genericData20 == 0)
						{
							goto IL_1734;
						}
						if (returnData.genericData20 == 2)
						{
							int num = returnData.genericData22 + returnData.genericData23 + returnData.genericData24 + returnData.genericData25 + returnData.genericData26 + returnData.genericData27 + returnData.genericData28 + returnData.genericData29;
							this.lblSpoils.Text = num.ToString("N", nfi) + " " + SK.Text("GENERIC_Resources_Taken", "Resources taken");
							this.btnShowResources.Visible = true;
							goto IL_1734;
						}
						if (returnData.genericData20 > 1000)
						{
							if (returnData.genericData22 >= 0)
							{
								this.lblSpoils.Text = VillageBuildingsData.getBuildingName(returnData.genericData22);
							}
							if (returnData.genericData23 >= 0)
							{
								Label label = this.lblSpoils;
								label.Text = label.Text + ", " + VillageBuildingsData.getBuildingName(returnData.genericData23);
							}
							if (returnData.genericData24 >= 0)
							{
								Label label2 = this.lblSpoils;
								label2.Text = label2.Text + ", " + VillageBuildingsData.getBuildingName(returnData.genericData24);
							}
							if (returnData.genericData25 >= 0)
							{
								Label label3 = this.lblSpoils;
								label3.Text = label3.Text + ", " + VillageBuildingsData.getBuildingName(returnData.genericData25);
							}
							if (returnData.genericData26 >= 0)
							{
								Label label4 = this.lblSpoils;
								label4.Text = label4.Text + ", " + VillageBuildingsData.getBuildingName(returnData.genericData26);
							}
							if (returnData.genericData27 >= 0)
							{
								Label label5 = this.lblSpoils;
								label5.Text = label5.Text + ", " + VillageBuildingsData.getBuildingName(returnData.genericData27);
							}
							if (returnData.genericData28 >= 0)
							{
								Label label6 = this.lblSpoils;
								label6.Text = label6.Text + ", " + VillageBuildingsData.getBuildingName(returnData.genericData28);
							}
							if (returnData.genericData29 >= 0)
							{
								Label label7 = this.lblSpoils;
								label7.Text = label7.Text + ", " + VillageBuildingsData.getBuildingName(returnData.genericData29);
							}
							Label label8 = this.lblSpoils;
							label8.Text = label8.Text + " - " + SK.Text("GENERIC_Destroyed", "Destroyed");
							goto IL_1734;
						}
						if (returnData.genericData20 == 1000)
						{
							this.lblSpoils.Text = SK.Text("GENERIC_No_Destroyable_Buildings", "There were no destroyable buildings.");
							goto IL_1734;
						}
						if (returnData.genericData20 == 1)
						{
							this.lblSpoils.Text = SK.Text("GENERIC_Attack_Failed", "This attack failed.");
							goto IL_1734;
						}
						goto IL_1734;
					}
				}
				else if (reportType - 24 > 1 && reportType - 58 > 3)
				{
					goto IL_1734;
				}
			}
			else if (reportType <= 79)
			{
				if (reportType - 62 > 3 && reportType != 79)
				{
					goto IL_1734;
				}
				goto IL_10D8;
			}
			else if (reportType - 123 > 2 && reportType != 132)
			{
				goto IL_1734;
			}
			str = text4 + " (" + GameEngine.Instance.World.getVillageName(returnData.attackingVillage) + ")";
			short reportType2 = returnData.reportType;
			if (reportType2 <= 25)
			{
				if (reportType2 != 24)
				{
					if (reportType2 == 25)
					{
						SK.Text("GENERIC_A_Wolf_Lair", "A Wolf Lair");
					}
				}
				else
				{
					SK.Text("GENERIC_A_Bandit_Camp", "A Bandit Camp");
				}
			}
			else
			{
				switch (reportType2)
				{
				case 58:
					SK.Text("GENERIC_Rats_Castle", "Rat's Castle");
					break;
				case 59:
					SK.Text("GENERIC_Snakes_Castle", "Snake's Castle");
					break;
				case 60:
					SK.Text("GENERIC_Pigs_Castle", "Pig's Castle");
					break;
				case 61:
					SK.Text("GENERIC_Wolfs_Castle", "Wolf's Castle");
					break;
				default:
					switch (reportType2)
					{
					case 123:
						SK.Text("GENERIC_Paladin_Castle", "Paladin's Castle");
						break;
					case 124:
						SK.Text("GENERIC_Paladin_Castle", "Paladin's Castle");
						break;
					case 125:
						SK.Text("GENERIC_Treasure_Castle", "Treasure Castle");
						break;
					default:
						if (reportType2 == 132)
						{
							SK.Text("CommonDataTypes_Royal_Tower", "Royal Tower");
						}
						break;
					}
					break;
				}
			}
			this.lblSpoils.Text = "";
			this.lblHonour.Text = SK.Text("GENERIC_Honour", "Honour") + " : " + returnData.genericData11.ToString("N", nfi);
			if (!returnData.successStatus)
			{
				text2 = SK.Text("GENERIC_The_Defender_Wins", "The Defender Wins");
			}
			else if (returnData.reportType == 125 && returnData.genericData20 >= 700 && returnData.genericData20 < 710)
			{
				this.lblHonour.Text = "";
				switch (returnData.genericData20)
				{
				case 700:
					text3 = SK.Text("REPORTS_TreasureWheelSpins1", "Treasure Found : Tier 1 Wheel Spin");
					break;
				case 701:
					text3 = SK.Text("REPORTS_TreasureWheelSpins2", "Treasure Found : Tier 2 Wheel Spin");
					break;
				case 702:
					text3 = SK.Text("REPORTS_TreasureWheelSpins3", "Treasure Found : Tier 3 Wheel Spin");
					break;
				case 703:
					text3 = SK.Text("REPORTS_TreasureWheelSpins4", "Treasure Found : Tier 4 Wheel Spin");
					break;
				case 704:
					text3 = SK.Text("REPORTS_TreasureWheelSpins5", "Treasure Found : Tier 5 Wheel Spin");
					break;
				}
			}
			if (returnData.genericData21 != 1)
			{
				goto IL_1734;
			}
			goto IL_1734;
			IL_10D8:
			this.lblSpoils.Text = "";
			this.lblHonour.Text = "";
			if (returnData.reportType == 3)
			{
				str = ((otherUser.Length != 0) ? otherUser : SK.Text("GENERIC_An_Unknown_Player", "An Unknown Player"));
				str = str + " (" + GameEngine.Instance.World.getVillageName(returnData.attackingVillage) + ")";
			}
			else
			{
				short reportType3 = returnData.reportType;
				switch (reportType3)
				{
				case 62:
					str = SK.Text("GENERIC_CharacterName_Rat", "Rat");
					break;
				case 63:
					str = SK.Text("GENERIC_CharacterName_Snake", "Snake");
					break;
				case 64:
					str = SK.Text("GENERIC_CharacterName_Pig", "Pig");
					break;
				case 65:
					str = SK.Text("GENERIC_CharacterName_Wolf", "Wolf");
					break;
				default:
					if (reportType3 == 79)
					{
						str = SK.Text("GENERIC_CharacterName_The_Enemy", "The Enemy");
					}
					break;
				}
			}
			if (returnData.genericData11 < 0)
			{
				this.lblHonour.Text = SK.Text("GENERIC_Honour_Cost", "Honour Cost") + " : " + (-returnData.genericData11).ToString("N", nfi);
			}
			else
			{
				this.lblHonour.Text = SK.Text("GENERIC_Honour", "Honour") + " : " + returnData.genericData11.ToString("N", nfi);
			}
			if (otherUser.Length == 0)
			{
				SK.Text("GENERIC_An_Empty_Village", "An empty village");
			}
			else
			{
				text4 = text4 + " (" + GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + ")";
			}
			if (returnData.successStatus)
			{
				text2 = SK.Text("GENERIC_The_Defender_Wins", "The Defender Wins");
			}
			else if (returnData.genericData20 == 0 && returnData.genericData21 >= 0)
			{
				text3 = ((returnData.genericData30 != 11 && returnData.genericData30 != 13) ? (GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + " - " + SK.Text("GENERIC_Captured", "Captured")) : (GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + " - " + SK.Text("GENERIC_Was_Attacked", "Was attacked")));
			}
			else if (returnData.genericData20 == 10 && returnData.genericData21 >= 0)
			{
				text3 = GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + " - " + SK.Text("GENERIC_Made_a_Vassal", "Made a vassal");
			}
			else if (returnData.genericData20 == 5 && returnData.genericData21 >= 0)
			{
				text3 = GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + " - " + SK.Text("GENERIC_Has_Been_Razed", "Has been razed");
			}
			else if (returnData.genericData20 == 6)
			{
				text3 = GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + " - " + SK.Text("GENERIC_Has_Been_Raided", "Has been raided");
				this.lblSpoils.Text = returnData.genericData21.ToString("N", nfi) + " " + SK.Text("GENERIC_Gold_Raided", "Gold raided");
			}
			else
			{
				text3 = GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + " - " + SK.Text("GENERIC_Was_Attacked", "Was attacked");
			}
			if (returnData.genericData20 == 2)
			{
				int num2 = returnData.genericData22 + returnData.genericData23 + returnData.genericData24 + returnData.genericData25 + returnData.genericData26 + returnData.genericData27 + returnData.genericData28 + returnData.genericData29;
				this.lblSpoils.Text = num2.ToString("N", nfi) + " " + SK.Text("GENERIC_Resources_Lost", "Resources lost");
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
					Label label9 = this.lblSpoils;
					label9.Text = label9.Text + ", " + VillageBuildingsData.getBuildingName(returnData.genericData23);
				}
				if (returnData.genericData24 >= 0)
				{
					Label label10 = this.lblSpoils;
					label10.Text = label10.Text + ", " + VillageBuildingsData.getBuildingName(returnData.genericData24);
				}
				if (returnData.genericData25 >= 0)
				{
					Label label11 = this.lblSpoils;
					label11.Text = label11.Text + ", " + VillageBuildingsData.getBuildingName(returnData.genericData25);
				}
				if (returnData.genericData26 >= 0)
				{
					Label label12 = this.lblSpoils;
					label12.Text = label12.Text + ", " + VillageBuildingsData.getBuildingName(returnData.genericData26);
				}
				if (returnData.genericData27 >= 0)
				{
					Label label13 = this.lblSpoils;
					label13.Text = label13.Text + ", " + VillageBuildingsData.getBuildingName(returnData.genericData27);
				}
				if (returnData.genericData28 >= 0)
				{
					Label label14 = this.lblSpoils;
					label14.Text = label14.Text + ", " + VillageBuildingsData.getBuildingName(returnData.genericData28);
				}
				if (returnData.genericData29 >= 0)
				{
					Label label15 = this.lblSpoils;
					label15.Text = label15.Text + ", " + VillageBuildingsData.getBuildingName(returnData.genericData29);
				}
				Label label16 = this.lblSpoils;
				label16.Text = label16.Text + " - " + SK.Text("GENERIC_Destroyed", "Destroyed");
			}
			else if (returnData.genericData20 == 1000)
			{
				this.lblSpoils.Text = SK.Text("GENERIC_You_Had_No_buildings_Destroyed", "You had no buildings that could be destroyed.");
			}
			else if (returnData.genericData20 == 1)
			{
				this.lblSpoils.Text = SK.Text("GENERIC_The_Attack_Failed", "The attack failed.");
			}
			IL_1734:
			this.lblResult.Text = text2;
			this.lblDate.Text = returnData.reportTime.ToString();
			this.lblTargetVillageNameAndInfo.Text = text3;
			this.lblDate.Text = this.m_reportReturnData.reportTime.ToString();
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x0008C7AC File Offset: 0x0008A9AC
		private void btnClose_Click(object sender, EventArgs e)
		{
			if (this.showPostTutorialThingy)
			{
				CastleMapBattlePanel2.fromReports = false;
			}
			if (BattleResultPopup.resourcesPanel != null && !BattleResultPopup.resourcesPanel.Created)
			{
				BattleResultPopup.resourcesPanel.Close();
				BattleResultPopup.resourcesPanel = null;
			}
			base.Close();
			BattleResultPopup.m_parent.closePopup(true, this.showPostTutorialThingy);
		}

		// Token: 0x06000692 RID: 1682 RVA: 0x0008C804 File Offset: 0x0008AA04
		private void btnMinimise_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("BattleResultPopup_close");
			if (BattleResultPopup.resourcesPanel != null && !BattleResultPopup.resourcesPanel.Created)
			{
				BattleResultPopup.resourcesPanel.Close();
				BattleResultPopup.resourcesPanel = null;
			}
			BattleResultPopup.m_parent.closePopup(false, false);
			base.Close();
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x0008C858 File Offset: 0x0008AA58
		private void btnShowResources_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("BattleResultPopup_resources");
			if (BattleResultPopup.resourcesPanel != null && !BattleResultPopup.resourcesPanel.Created)
			{
				BattleResultPopup.resourcesPanel.Close();
				BattleResultPopup.resourcesPanel = null;
			}
			BattleResultPopup.resourcesPanel = new AttackReportsResourcesPanel();
			BattleResultPopup.resourcesPanel.setResources(this.m_reportReturnData);
			BattleResultPopup.resourcesPanel.Show();
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void BattleResultPopup_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x040008DF RID: 2271
		private static CastleMapBattlePanel2 m_parent;

		// Token: 0x040008E0 RID: 2272
		private int m_villageID = -1;

		// Token: 0x040008E1 RID: 2273
		private GetReport_ReturnType m_reportReturnData;

		// Token: 0x040008E2 RID: 2274
		private bool showPostTutorialThingy;

		// Token: 0x040008E3 RID: 2275
		private static AttackReportsResourcesPanel resourcesPanel;
	}
}
