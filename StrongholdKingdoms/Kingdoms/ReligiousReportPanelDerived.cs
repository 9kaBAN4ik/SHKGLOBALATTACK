using System;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020002B6 RID: 694
	internal class ReligiousReportPanelDerived : GenericReportPanelBasic
	{
		// Token: 0x06001F08 RID: 7944 RVA: 0x001DE118 File Offset: 0x001DC318
		public override void setData(GetReport_ReturnType returnData)
		{
			base.setData(returnData);
			short reportType = returnData.reportType;
			switch (reportType)
			{
			case 66:
			{
				CustomSelfDrawPanel.CSDLabel lblMainText = this.lblMainText;
				lblMainText.Text = lblMainText.Text + " (" + GameEngine.Instance.World.getVillageName(returnData.attackingVillage) + ")";
				this.lblSubTitle.Text = SK.Text("Reports_Has_Influenced_Voting", "Has Influenced Voting at");
				this.lblSecondaryText.Text = GameEngine.Instance.World.getVillageName(returnData.defendingVillage);
				break;
			}
			case 67:
			{
				CustomSelfDrawPanel.CSDLabel lblMainText2 = this.lblMainText;
				lblMainText2.Text = lblMainText2.Text + " (" + GameEngine.Instance.World.getVillageName(returnData.attackingVillage) + ")";
				this.lblSubTitle.Text = SK.Text("Reports_Removed_Disease", "Has Removed Disease From");
				this.lblSecondaryText.Text = GameEngine.Instance.World.getVillageName(returnData.defendingVillage);
				break;
			}
			case 68:
			{
				CustomSelfDrawPanel.CSDLabel lblMainText3 = this.lblMainText;
				lblMainText3.Text = lblMainText3.Text + " (" + GameEngine.Instance.World.getVillageName(returnData.attackingVillage) + ")";
				this.lblSubTitle.Text = SK.Text("Reports_Has_Interdicted", "Has Interdict Protected");
				this.lblSecondaryText.Text = returnData.otherUser + " (" + GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + ")";
				break;
			}
			case 69:
			{
				CustomSelfDrawPanel.CSDLabel lblMainText4 = this.lblMainText;
				lblMainText4.Text = lblMainText4.Text + " (" + GameEngine.Instance.World.getVillageName(returnData.attackingVillage) + ")";
				this.lblSubTitle.Text = SK.Text("Reports_Has_Inquisited", "Has Inquisited");
				this.lblSecondaryText.Text = GameEngine.Instance.World.getVillageName(returnData.defendingVillage);
				break;
			}
			case 70:
			{
				CustomSelfDrawPanel.CSDLabel lblMainText5 = this.lblMainText;
				lblMainText5.Text = lblMainText5.Text + " (" + GameEngine.Instance.World.getVillageName(returnData.attackingVillage) + ")";
				this.lblSubTitle.Text = SK.Text("Reports_Has_Excommunicated", "Has Excommunicated");
				this.lblSecondaryText.Text = returnData.otherUser + " (" + GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + ")";
				break;
			}
			case 71:
			{
				CustomSelfDrawPanel.CSDLabel lblMainText6 = this.lblMainText;
				lblMainText6.Text = lblMainText6.Text + " (" + GameEngine.Instance.World.getVillageName(returnData.attackingVillage) + ")";
				this.lblSubTitle.Text = SK.Text("Reports_Has_Absolved", "Has Absolved");
				this.lblSecondaryText.Text = returnData.otherUser + " (" + GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + ")";
				break;
			}
			case 72:
			{
				CustomSelfDrawPanel.CSDLabel lblMainText7 = this.lblMainText;
				lblMainText7.Text = lblMainText7.Text + " (" + GameEngine.Instance.World.getVillageName(returnData.attackingVillage) + ")";
				this.lblSubTitle.Text = SK.Text("Reports_Has_Blessed", "Has Blessed");
				this.lblSecondaryText.Text = GameEngine.Instance.World.getVillageName(returnData.defendingVillage);
				break;
			}
			default:
				if (reportType != 91)
				{
					switch (reportType)
					{
					case 103:
						this.lblMainText.Text = returnData.otherUser + " (" + GameEngine.Instance.World.getVillageName(returnData.attackingVillage) + ")";
						this.lblSubTitle.Text = SK.Text("Reports_Has_Absolved", "Has Absolved");
						this.lblSecondaryText.Text = this.reportOwner + " (" + GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + ")";
						break;
					case 104:
						this.lblMainText.Text = returnData.otherUser + " (" + GameEngine.Instance.World.getVillageName(returnData.attackingVillage) + ")";
						this.lblSubTitle.Text = SK.Text("Reports_Has_Inquisited", "Has Inquisited");
						this.lblSecondaryText.Text = GameEngine.Instance.World.getVillageName(returnData.defendingVillage);
						break;
					case 105:
						this.lblMainText.Text = returnData.otherUser + " (" + GameEngine.Instance.World.getVillageName(returnData.attackingVillage) + ")";
						this.lblSubTitle.Text = SK.Text("Reports_Has_Interdicted", "Has Interdict Protected");
						this.lblSecondaryText.Text = this.reportOwner + " (" + GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + ")";
						break;
					case 106:
						this.lblMainText.Text = GameEngine.Instance.World.getVillageName(returnData.defendingVillage);
						if (returnData.genericData1 == 0)
						{
							this.lblSubTitle.Text = SK.Text("Reports_Interdiction_Has_Ended", "Interdiction Has Ended");
						}
						else
						{
							this.lblSubTitle.Text = SK.Text("Reports_Interdiction_Termination", "Interdiction Was Terminated");
						}
						break;
					}
				}
				else
				{
					this.lblMainText.Text = returnData.otherUser + " (" + GameEngine.Instance.World.getVillageName(returnData.attackingVillage) + ")";
					this.lblSubTitle.Text = SK.Text("Reports_Has_Excommunicated", "Has Excommunicated");
					this.lblSecondaryText.Text = this.reportOwner + " (" + GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + ")";
				}
				break;
			}
			this.initFurtherInfo();
		}

		// Token: 0x06001F09 RID: 7945 RVA: 0x001DE778 File Offset: 0x001DC978
		private void initFurtherInfo()
		{
			short reportType = this.m_returnData.reportType;
			switch (reportType)
			{
			case 66:
				if (this.m_returnData.genericData1 > 0)
				{
					if (this.m_returnData.genericData1 != 1)
					{
						this.lblFurther.Text = string.Concat(new string[]
						{
							SK.Text("Reports_Votes_Given", "Votes Given"),
							" : ",
							this.m_returnData.otherUser,
							" (",
							this.m_returnData.genericData1.ToString(),
							" ",
							SK.Text("Reports_Votes", "Votes"),
							")"
						});
						goto IL_81B;
					}
					this.lblFurther.Text = string.Concat(new string[]
					{
						SK.Text("Reports_Votes_Given", "Votes Given"),
						" : ",
						this.m_returnData.otherUser,
						" (",
						SK.Text("Reports_1_Vote", "1 Vote"),
						")"
					});
					goto IL_81B;
				}
				else
				{
					if (this.m_returnData.genericData1 != -1)
					{
						this.lblFurther.Text = string.Concat(new string[]
						{
							SK.Text("Reports_Votes_Lost", "Votes Lost"),
							" : ",
							this.m_returnData.otherUser,
							" (",
							(-this.m_returnData.genericData1).ToString(),
							" ",
							SK.Text("Reports_Votes", "Votes"),
							")"
						});
						goto IL_81B;
					}
					this.lblFurther.Text = string.Concat(new string[]
					{
						SK.Text("Reports_Votes_Lost", "Votes Lost"),
						" : ",
						this.m_returnData.otherUser,
						" (",
						SK.Text("Reports_1_Vote", "1 Vote"),
						")"
					});
					goto IL_81B;
				}
				break;
			case 67:
			{
				this.lblFurther.Text = SK.Text("Reports_Disease_Points_Removed", "Disease points removed") + " : " + this.m_returnData.genericData1.ToString();
				CustomSelfDrawPanel.CSDLabel lblFurther = this.lblFurther;
				lblFurther.Text = lblFurther.Text + Environment.NewLine + Environment.NewLine;
				if (this.m_returnData.genericData1 > 0)
				{
					CustomSelfDrawPanel.CSDLabel lblFurther2 = this.lblFurther;
					lblFurther2.Text = lblFurther2.Text + SK.Text("GENERIC_Honour", "Honour") + " : " + (this.m_returnData.genericData1 * GameEngine.Instance.LocalWorldData.HonourForClearingDisease).ToString("N", this.nfi);
					goto IL_81B;
				}
				goto IL_81B;
			}
			case 68:
				goto IL_6AF;
			case 69:
				goto IL_27F;
			case 70:
				goto IL_3C1;
			case 71:
				break;
			case 72:
				if (this.m_returnData.genericData2 != 10)
				{
					string text = (this.m_returnData.genericData2 % 10 != 0) ? ((double)this.m_returnData.genericData2 / 10.0).ToString() : (this.m_returnData.genericData2 / 10).ToString();
					this.lblFurther.Text = string.Concat(new string[]
					{
						SK.Text("Reports_Popularity_Bonus", "Popularity Bonus"),
						" : ",
						this.m_returnData.genericData1.ToString(),
						" (",
						text,
						" ",
						SK.Text("Reports_Hours", "hours"),
						")"
					});
					goto IL_81B;
				}
				this.lblFurther.Text = string.Concat(new string[]
				{
					SK.Text("Reports_Popularity_Bonus", "Popularity Bonus"),
					" : ",
					this.m_returnData.genericData1.ToString(),
					" (",
					SK.Text("Reports_1_hour", "1 hour"),
					")"
				});
				goto IL_81B;
			default:
				if (reportType == 91)
				{
					goto IL_3C1;
				}
				switch (reportType)
				{
				case 103:
					break;
				case 104:
					goto IL_27F;
				case 105:
					goto IL_6AF;
				default:
					goto IL_81B;
				}
				break;
			}
			if (this.m_returnData.genericData1 != 10)
			{
				string text2 = (this.m_returnData.genericData1 % 10 != 0) ? ((double)this.m_returnData.genericData1 / 10.0).ToString() : (this.m_returnData.genericData1 / 10).ToString();
				this.lblFurther.Text = string.Concat(new string[]
				{
					SK.Text("Reports_Absolution", "Absolution"),
					" : ",
					text2,
					" ",
					SK.Text("Reports_Hours", "hours")
				});
				goto IL_81B;
			}
			this.lblFurther.Text = SK.Text("Reports_Absolution", "Absolution") + " : " + SK.Text("Reports_1_hour", "1 hour");
			goto IL_81B;
			IL_27F:
			if (this.m_returnData.genericData2 != 10)
			{
				string text3 = (this.m_returnData.genericData2 % 10 != 0) ? ((double)this.m_returnData.genericData2 / 10.0).ToString() : (this.m_returnData.genericData2 / 10).ToString();
				this.lblFurther.Text = string.Concat(new string[]
				{
					SK.Text("Reports_Popularity_Penalty", "Popularity Penalty"),
					" : ",
					this.m_returnData.genericData1.ToString(),
					" (",
					text3,
					" ",
					SK.Text("Reports_Hours", "hours"),
					")"
				});
				goto IL_81B;
			}
			this.lblFurther.Text = string.Concat(new string[]
			{
				SK.Text("Reports_Popularity_Penalty", "Popularity Penalty"),
				" : ",
				this.m_returnData.genericData1.ToString(),
				" (",
				SK.Text("Reports_1_hour", "1 hour"),
				")"
			});
			goto IL_81B;
			IL_3C1:
			if (this.m_returnData.genericData1 != 10)
			{
				string text4 = (this.m_returnData.genericData1 % 10 != 0) ? ((double)this.m_returnData.genericData1 / 10.0).ToString() : (this.m_returnData.genericData1 / 10).ToString();
				this.lblFurther.Text = string.Concat(new string[]
				{
					SK.Text("Reports_Excommunication", "Excommunication"),
					" : ",
					text4,
					" ",
					SK.Text("Reports_Hours", "hours")
				});
				goto IL_81B;
			}
			this.lblFurther.Text = SK.Text("Reports_Excommunication", "Excommunication") + " : " + SK.Text("Reports_1_hour", "1 hour");
			goto IL_81B;
			IL_6AF:
			if (this.m_returnData.genericData1 != 1)
			{
				this.lblFurther.Text = string.Concat(new string[]
				{
					SK.Text("Reports_Protection", "Protection"),
					" : ",
					this.m_returnData.genericData1.ToString(),
					" ",
					SK.Text("Reports_Hours", "hours")
				});
			}
			else
			{
				this.lblFurther.Text = SK.Text("Reports_Protection", "Protection") + " : " + SK.Text("Reports_1_hour", "1 hour");
			}
			IL_81B:
			base.showFurtherInfo();
		}
	}
}
