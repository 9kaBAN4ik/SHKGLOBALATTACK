using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms;
using Upgrade.Services;

namespace Upgrade
{
	// Token: 0x0200002D RID: 45
	public partial class RouteEditor : Form
	{
		// Token: 0x060001CA RID: 458 RVA: 0x00044780 File Offset: 0x00042980
		internal RouteEditor(IEnumerable<string> listOfVillages, SaveTradeRouteDel2 createTradeRouteDel, DataGridViewRow route = null, int routeIndex = -1)
		{
			this.InitializeComponent();
			this.Translate();
			foreach (string item in listOfVillages)
			{
				this.listBox_From.Items.Add(item);
				this.listBox_To.Items.Add(item);
			}
			foreach (int buildingType in TradeService.tradeTypeId)
			{
				this.listBox_Res.Items.Add(VillageBuildingsData.getResourceNames(buildingType));
			}
			this._createTradeRouteDel = createTradeRouteDel;
			this._routeIndex = routeIndex;
			if (route != null)
			{
				this.InitEditing(route, routeIndex == -1);
			}
			else
			{
				this.Text = this.Text + " " + LNG.Print("New Route");
			}
			for (int j = 0; j < this.contextMenuStrip_SenderQuickSelector.Items.Count; j++)
			{
				ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)this.contextMenuStrip_SenderQuickSelector.Items[j];
				toolStripMenuItem.CheckOnClick = true;
				ToolStripMenuItem toolStripMenuItem2 = (ToolStripMenuItem)this.contextMenuStrip_ReceiverQuickSelector.Items[j];
				toolStripMenuItem2.CheckOnClick = true;
				if (j > 0 && j < 11)
				{
					toolStripMenuItem.Click += this.selectAllVillagesOfType_Click;
					toolStripMenuItem2.Click += this.selectAllVillagesOfType_Click;
				}
			}
			for (int k = 0; k < this.contextMenuStrip_ResourcesQuickSelector.Items.Count; k++)
			{
				ToolStripMenuItem toolStripMenuItem3 = (ToolStripMenuItem)this.contextMenuStrip_ResourcesQuickSelector.Items[k];
				toolStripMenuItem3.CheckOnClick = true;
			}
		}

		// Token: 0x060001CB RID: 459 RVA: 0x0000904B File Offset: 0x0000724B
		private void Translate()
		{
			LNG.TranslateSecondaryForms(this);
			this.Text = LNG.Print(this.Text) + this.Version;
		}

		// Token: 0x060001CC RID: 460 RVA: 0x00044948 File Offset: 0x00042B48
		private void button_Save_Click(object sender, EventArgs e)
		{
			this.UpdateTradeRoute();
			if (!this.IsRouteValid())
			{
				return;
			}
			this._createTradeRouteDel(this.CurrentRoute, this.GetTradeRouteRow(), this._routeIndex);
			MessageBox.Show("Route \"" + this.textBox_Name.Text + "\" is saved:)");
		}

		// Token: 0x060001CD RID: 461 RVA: 0x000449A4 File Offset: 0x00042BA4
		private bool IsRouteValid()
		{
			string text = string.Empty;
			bool flag = true;
			if (this.listBox_From.SelectedItems.Count == 0)
			{
				text = "Select at least 1 village in \"From\" section";
				this.listBox_From.BackColor = SystemColors.HotTrack;
				flag = false;
			}
			if (this.listBox_To.SelectedItems.Count == 0)
			{
				text = "Select at least 1 village in \"To\" section";
				this.listBox_To.BackColor = SystemColors.HotTrack;
				flag = false;
			}
			if (this.listBox_Res.SelectedItems.Count == 0)
			{
				text = LNG.Print("Select at least 1 resource");
				this.listBox_Res.BackColor = SystemColors.HotTrack;
				flag = false;
			}
			if (this.numericUpDown_SendMax.Value == 0m)
			{
				text = "Send Maximum can't be 0.";
				this.numericUpDown_SendMax.BackColor = SystemColors.HotTrack;
				flag = false;
			}
			if (this.listBox_From.SelectedItems.Count == 1 && this.listBox_To.SelectedItems.Count == 1 && this.listBox_From.SelectedIndex == this.listBox_To.SelectedIndex)
			{
				text = "\"From\" and \"To\" have 1 same village.";
				this.listBox_From.BackColor = (this.listBox_To.BackColor = SystemColors.HotTrack);
				flag = false;
			}
			if (this.listBox_Trips.Items.Count == 0)
			{
				text = LNG.Print("This route won't do anything. Please change your settings (increase distance limit or something else)");
				flag = false;
			}
			if (!flag)
			{
				MessageBox.Show(text, SK.Text("GENERIC_Error", "Error"));
			}
			return flag;
		}

		// Token: 0x060001CE RID: 462 RVA: 0x00044B08 File Offset: 0x00042D08
		private void InitEditing(DataGridViewRow route, bool isCopying)
		{
			string text = route.Cells[0].Value.ToString();
			if (isCopying)
			{
				this.textBox_Name.Text = text + " - Copy";
				this.Text = this.Text + " Copy \"" + text + "\"";
			}
			else
			{
				this.textBox_Name.Text = text;
				this.Text = this.Text + " Edit \"" + text + "\"";
			}
			this.checkBox_Enable.Checked = (bool)route.Cells[1].Value;
			this.SelectListBoxItems(route.Cells[2], this.listBox_From);
			this.SelectListBoxItems(route.Cells[3], this.listBox_To);
			this.SelectListBoxItems(route.Cells[4], this.listBox_Res);
			this.numericUpDown_MinKeep.Value = int.Parse(route.Cells[5].Value.ToString());
			this.numericUpDown_MaxMerchantsPerTransaction.Value = int.Parse(route.Cells[6].Value.ToString());
			this.numericUpDown_SendMax.Value = int.Parse(route.Cells[7].Value.ToString());
			this.checkBox_IsDistanceLimited.Checked = (bool)route.Cells[8].Value;
			this.numericUpDown_maxDistanceLimit.Value = int.Parse(route.Cells[9].Value.ToString());
		}

		// Token: 0x060001CF RID: 463 RVA: 0x00044CC4 File Offset: 0x00042EC4
		private void UpdateTradeRoute()
		{
			List<int> list = new List<int>();
			for (int i = 0; i < TradeService.tradeTypeId.Length; i++)
			{
				if (this.listBox_Res.GetSelected(i))
				{
					list.Add((int)TradeService.tradeTypeId[i]);
				}
			}
			this.CurrentRoute = TradeService.OptimizeRoute(new TradeRoute(this.textBox_Name.Text, this.checkBox_Enable.Checked, (from string x in this.listBox_From.SelectedItems
			select ControlForm.GetId(x)).ToList<int>(), (from string x in this.listBox_To.SelectedItems
			select ControlForm.GetId(x)).ToList<int>(), list, (int)this.numericUpDown_MinKeep.Value, (int)this.numericUpDown_MaxMerchantsPerTransaction.Value, (int)this.numericUpDown_SendMax.Value, this.checkBox_IsDistanceLimited.Checked, (int)this.numericUpDown_maxDistanceLimit.Value));
			this.RecalcTrips();
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x00044DF0 File Offset: 0x00042FF0
		internal object[] GetTradeRouteRow()
		{
			return new object[]
			{
				this.textBox_Name.Text,
				this.checkBox_Enable.Checked,
				string.Join(",", this.listBox_From.SelectedItems.Cast<string>().ToArray<string>()),
				string.Join(",", this.listBox_To.SelectedItems.Cast<string>().ToArray<string>()),
				string.Join(",", this.listBox_Res.SelectedItems.Cast<string>().ToArray<string>()),
				(int)this.numericUpDown_MinKeep.Value,
				(int)this.numericUpDown_MaxMerchantsPerTransaction.Value,
				(int)this.numericUpDown_SendMax.Value,
				this.checkBox_IsDistanceLimited.Checked,
				(int)this.numericUpDown_maxDistanceLimit.Value
			};
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x00044F00 File Offset: 0x00043100
		private void SelectListBoxItems(DataGridViewCell cell, ListBox listBox)
		{
			string[] source = cell.Value.ToString().Split(new char[]
			{
				','
			});
			for (int i = 0; i < listBox.Items.Count; i++)
			{
				if (source.Contains(listBox.Items[i].ToString()))
				{
					listBox.SetSelected(i, true);
				}
			}
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x00044F60 File Offset: 0x00043160
		private void button_InvertSelection_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.listBox_From.Items.Count; i++)
			{
				bool selected = this.listBox_From.GetSelected(i);
				bool selected2 = this.listBox_To.GetSelected(i);
				this.listBox_From.SetSelected(i, selected2);
				this.listBox_To.SetSelected(i, selected);
			}
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x0000906F File Offset: 0x0000726F
		private void listBox_To_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.RecalcMaxDistance();
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x0000906F File Offset: 0x0000726F
		private void listBox_From_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.RecalcMaxDistance();
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x00044FBC File Offset: 0x000431BC
		private void RecalcMaxDistance()
		{
			if (this.listBox_From.SelectedItems.Count == 0 || this.listBox_To.SelectedItems.Count == 0)
			{
				this.label_maxDistanceFromValue.Text = (this.label_maxDistanceToValue.Text = (this.label_maxDistanceValue.Text = (this.label_maxDistanceTimeValue.Text = LNG.Print("no data"))));
				return;
			}
			double num = double.MinValue;
			string text = string.Empty;
			string text2 = string.Empty;
			int from = 0;
			int to = 0;
			foreach (object obj in this.listBox_From.SelectedItems)
			{
				string text3 = (string)obj;
				foreach (object obj2 in this.listBox_To.SelectedItems)
				{
					string text4 = (string)obj2;
					if (!(text3 == text4))
					{
						int id = ControlForm.GetId(text3);
						int id2 = ControlForm.GetId(text4);
						double distance = GameEngine.Instance.World.getDistance(id, id2);
						if (distance > num)
						{
							num = distance;
							text = text3;
							text2 = text4;
							from = id;
							to = id2;
						}
					}
				}
			}
			this.label_maxDistanceFromValue.Text = text;
			this.label_maxDistanceToValue.Text = text2;
			this.label_maxDistanceValue.Text = ((int)num).ToString();
			this.label_maxDistanceTimeValue.Text = this.GetMerchantTimeFromDistance(num, from, to);
			this.UpdateTradeRoute();
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x00045184 File Offset: 0x00043384
		private void RecalcTrips()
		{
			this.listBox_Trips.Items.Clear();
			using (List<int>.Enumerator enumerator = this.CurrentRoute.From.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int sender = enumerator.Current;
					if (this.CurrentRoute.SortedRecipients[sender].Count<int>() != 0)
					{
						this.listBox_Trips.Items.Add(GameEngine.Instance.World.getVillageName(sender) + " => " + string.Join(",", (from sr in this.CurrentRoute.SortedRecipients[sender]
						select GameEngine.Instance.World.getVillageName(sr) + " (" + this.GetMerchantTimeFromDistance(GameEngine.Instance.World.getDistance(sr, sender), sr, sender) + ")").ToArray<string>()));
					}
				}
			}
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x00045280 File Offset: 0x00043480
		private string GetMerchantTimeFromDistance(double distance, int from, int to)
		{
			WorldData localWorldData = GameEngine.Instance.LocalWorldData;
			if (localWorldData != null)
			{
				distance *= localWorldData.traderMoveSpeed * localWorldData.gamePlaySpeed;
				distance = GameEngine.Instance.World.UserResearchData.adjustTradeTimes(distance);
				distance *= CardTypes.cards_adjustTradeTimes(GameEngine.Instance.cardsManager.UserCardData);
				distance = CardTypes.cards_adjustTradeTimesCompleteContract(GameEngine.Instance.cardsManager.UserCardData, distance);
				distance = GameEngine.Instance.World.adjustIfIslandTravel(distance, from, to);
			}
			return VillageMap.createBuildTimeString((int)distance);
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x00045310 File Offset: 0x00043510
		private void checkBox_FromAll_CheckedChanged(object sender, EventArgs e)
		{
			for (int i = 0; i < this.listBox_From.Items.Count; i++)
			{
				this.listBox_From.SetSelected(i, this.checkBox_FromAll.Checked);
			}
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x00045350 File Offset: 0x00043550
		private void checkBox_ToAll_CheckedChanged(object sender, EventArgs e)
		{
			for (int i = 0; i < this.listBox_To.Items.Count; i++)
			{
				this.listBox_To.SetSelected(i, this.checkBox_ToAll.Checked);
			}
		}

		// Token: 0x060001DA RID: 474 RVA: 0x00045390 File Offset: 0x00043590
		private void checkBox_AllRes_CheckedChanged(object sender, EventArgs e)
		{
			for (int i = 0; i < this.listBox_Res.Items.Count; i++)
			{
				this.listBox_Res.SetSelected(i, this.checkBox_AllRes.Checked);
			}
		}

		// Token: 0x060001DB RID: 475 RVA: 0x000453D0 File Offset: 0x000435D0
		private void SelectAllVillagesOfType(ListBox villagesList, bool contains, bool setSelected, params int[] selectedTypes)
		{
			for (int i = 0; i < villagesList.Items.Count; i++)
			{
				string item = villagesList.Items[i].ToString();
				int id = ControlForm.GetId(item);
				int villageTerrainType = GameEngine.Instance.World.getVillageTerrainType(id);
				if (contains)
				{
					if (selectedTypes.Contains(villageTerrainType))
					{
						villagesList.SetSelected(i, setSelected);
					}
				}
				else if (!selectedTypes.Contains(villageTerrainType))
				{
					villagesList.SetSelected(i, setSelected);
				}
			}
		}

		// Token: 0x060001DC RID: 476 RVA: 0x00045448 File Offset: 0x00043648
		private void selectAllVillagesOfType_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			ContextMenuStrip contextMenuStrip = (ContextMenuStrip)toolStripMenuItem.Owner;
			int num = contextMenuStrip.Items.IndexOf(toolStripMenuItem) - 1;
			this.SelectAllVillagesOfType((ListBox)contextMenuStrip.SourceControl, true, toolStripMenuItem.Checked, new int[]
			{
				num
			});
		}

		// Token: 0x060001DD RID: 477 RVA: 0x0004549C File Offset: 0x0004369C
		private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			ContextMenuStrip contextMenuStrip = (ContextMenuStrip)toolStripMenuItem.Owner;
			this.SelectAllVillagesOfType((ListBox)contextMenuStrip.SourceControl, false, toolStripMenuItem.Checked, new int[]
			{
				-100500
			});
		}

		// Token: 0x060001DE RID: 478 RVA: 0x000454E4 File Offset: 0x000436E4
		private void allIronProducingVillagesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			ContextMenuStrip contextMenuStrip = (ContextMenuStrip)toolStripMenuItem.Owner;
			this.SelectAllVillagesOfType((ListBox)contextMenuStrip.SourceControl, true, toolStripMenuItem.Checked, new int[]
			{
				0,
				1,
				4
			});
		}

		// Token: 0x060001DF RID: 479 RVA: 0x0004552C File Offset: 0x0004372C
		private void allNonIronVillagesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			ContextMenuStrip contextMenuStrip = (ContextMenuStrip)toolStripMenuItem.Owner;
			this.SelectAllVillagesOfType((ListBox)contextMenuStrip.SourceControl, false, toolStripMenuItem.Checked, new int[]
			{
				0,
				1,
				4
			});
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x00045574 File Offset: 0x00043774
		private void allPitchProduingVillagesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			ContextMenuStrip contextMenuStrip = (ContextMenuStrip)toolStripMenuItem.Owner;
			this.SelectAllVillagesOfType((ListBox)contextMenuStrip.SourceControl, true, toolStripMenuItem.Checked, new int[]
			{
				1,
				6
			});
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x000455BC File Offset: 0x000437BC
		private void allNonPitchVillagesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			ContextMenuStrip contextMenuStrip = (ContextMenuStrip)toolStripMenuItem.Owner;
			this.SelectAllVillagesOfType((ListBox)contextMenuStrip.SourceControl, false, toolStripMenuItem.Checked, new int[]
			{
				1,
				6
			});
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x00045604 File Offset: 0x00043804
		private void allFishProducingVillagesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			ContextMenuStrip contextMenuStrip = (ContextMenuStrip)toolStripMenuItem.Owner;
			this.SelectAllVillagesOfType((ListBox)contextMenuStrip.SourceControl, true, toolStripMenuItem.Checked, new int[]
			{
				2,
				3
			});
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x0004564C File Offset: 0x0004384C
		private void allNonFishVillagesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			ContextMenuStrip contextMenuStrip = (ContextMenuStrip)toolStripMenuItem.Owner;
			this.SelectAllVillagesOfType((ListBox)contextMenuStrip.SourceControl, false, toolStripMenuItem.Checked, new int[]
			{
				2,
				3
			});
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x00045694 File Offset: 0x00043894
		private void vegetablesBreadLowlandPlainsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			ContextMenuStrip contextMenuStrip = (ContextMenuStrip)toolStripMenuItem.Owner;
			this.SelectAllVillagesOfType((ListBox)contextMenuStrip.SourceControl, true, toolStripMenuItem.Checked, new int[]
			{
				0,
				7
			});
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x000456D8 File Offset: 0x000438D8
		private void allNonVegetablesAndNonBreadVillagesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			ContextMenuStrip contextMenuStrip = (ContextMenuStrip)toolStripMenuItem.Owner;
			this.SelectAllVillagesOfType((ListBox)contextMenuStrip.SourceControl, false, toolStripMenuItem.Checked, new int[]
			{
				0,
				7
			});
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x0004571C File Offset: 0x0004391C
		private void allBanquetValleySideSaltPanRiver1River2ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			ContextMenuStrip contextMenuStrip = (ContextMenuStrip)toolStripMenuItem.Owner;
			this.SelectAllVillagesOfType((ListBox)contextMenuStrip.SourceControl, true, toolStripMenuItem.Checked, new int[]
			{
				2,
				3,
				5,
				8
			});
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00045768 File Offset: 0x00043968
		private void selectAllToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			this.SelectResources(toolStripMenuItem.Checked, 0, this.listBox_Res.Items.Count);
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x0004579C File Offset: 0x0004399C
		private void selectAllStockpileGoodsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			this.SelectResources(toolStripMenuItem.Checked, 0, 4);
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x000457C0 File Offset: 0x000439C0
		private void selectAllFoodToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			this.SelectResources(toolStripMenuItem.Checked, 5, 11);
		}

		// Token: 0x060001EA RID: 490 RVA: 0x000457E4 File Offset: 0x000439E4
		private void selectAllBanquetsGoodsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			this.SelectResources(toolStripMenuItem.Checked, 11, 19);
		}

		// Token: 0x060001EB RID: 491 RVA: 0x00045808 File Offset: 0x00043A08
		private void selectAllWeaponsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			this.SelectResources(toolStripMenuItem.Checked, 19, this.listBox_Res.Items.Count);
		}

		// Token: 0x060001EC RID: 492 RVA: 0x0004583C File Offset: 0x00043A3C
		private void SelectResources(bool isSelected, int start, int end)
		{
			for (int i = start; i < end; i++)
			{
				this.listBox_Res.SetSelected(i, isSelected);
			}
		}

		// Token: 0x060001ED RID: 493 RVA: 0x00009077 File Offset: 0x00007277
		private void checkBox_IsDistanceLimited_CheckedChanged(object sender, EventArgs e)
		{
			this.UpdateTradeRoute();
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00009077 File Offset: 0x00007277
		private void numericUpDown_maxDistanceLimit_ValueChanged(object sender, EventArgs e)
		{
			this.UpdateTradeRoute();
		}

		// Token: 0x04000334 RID: 820
		private string Version = " v3.0";

		// Token: 0x04000335 RID: 821
		private TradeRoute CurrentRoute;

		// Token: 0x04000336 RID: 822
		private SaveTradeRouteDel2 _createTradeRouteDel;

		// Token: 0x04000337 RID: 823
		private int _routeIndex;
	}
}
