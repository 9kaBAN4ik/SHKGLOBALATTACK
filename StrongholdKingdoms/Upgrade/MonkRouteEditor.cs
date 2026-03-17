using System;
using System.Collections;
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
	// Token: 0x02000028 RID: 40
	public partial class MonkRouteEditor : Form
	{
		// Token: 0x0600018D RID: 397 RVA: 0x00040A1C File Offset: 0x0003EC1C
		internal MonkRouteEditor(IEnumerable<string> listOfVillages, SaveMonkRouteDel createMonkRouteDel, MonkRoute currentRoute = null, int routeIndex = -1)
		{
			this.InitializeComponent();
			this.Translate();
			foreach (string item in listOfVillages)
			{
				this.listBox_villages.Items.Add(item);
			}
			this._createRouteDel = createMonkRouteDel;
			this.CurrentRoute = currentRoute;
			this._routeIndex = routeIndex;
			if (currentRoute != null)
			{
				this.InitEditing(currentRoute, routeIndex == -1);
				return;
			}
			this.Text += LNG.Print(" New Route");
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00040AD8 File Offset: 0x0003ECD8
		private void Translate()
		{
			LNG.TranslateSecondaryForms(this);
			this.comboBox_command.Items.AddRange(new object[]
			{
				SK.Text("SendMonksPanel_Interdiction", "Interdiction"),
				SK.Text("SendMonksPanel_Restoration", "Restoration"),
				SK.Text("VillageMapPanel_Blessing", "Blessing"),
				SK.Text("VillageMapPanel_Inquisition", "Inquisition"),
				SK.Text("SendMonksPanel_Absolution", "Absolution"),
				SK.Text("SendMonksPanel_Excommnunication", "Excommunication")
			});
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00040B70 File Offset: 0x0003ED70
		private void InitEditing(MonkRoute route, bool isCopying)
		{
			string name = route.Name;
			if (isCopying)
			{
				this.textBox_name.Text = name + " - Copy";
				this.Text = this.Text + " Copy \"" + name + "\"";
			}
			else
			{
				this.textBox_name.Text = name;
				this.Text = this.Text + " Edit \"" + name + "\"";
			}
			this.checkBox_routeEnabled.Checked = route.Enabled;
			for (int i = 0; i < this.listBox_villages.Items.Count; i++)
			{
				if (route.From.Contains(ControlForm.GetId(this.listBox_villages.Items[i].ToString())))
				{
					this.listBox_villages.SetSelected(i, true);
				}
			}
			this._targetCapitals = (from x in route.To
			where GameEngine.Instance.World.isRegionCapital(x)
			select x).ToList<int>();
			ListBox.ObjectCollection items = this.listBox_targetParishes.Items;
			object[] items2 = (from x in this._targetCapitals
			select GameEngine.Instance.World.getVillageName(x)).ToArray<string>();
			items.AddRange(items2);
			this._targetVillages = (from x in route.To
			where GameEngine.Instance.World.IsPlayerVillage(x)
			select x).ToList<int>();
			ListBox.ObjectCollection items3 = this.listBox_targetVillages.Items;
			items2 = (from x in this._targetVillages
			select GameEngine.Instance.World.getVillageName(x)).ToArray<string>();
			items3.AddRange(items2);
			this.comboBox_command.SelectedIndex = route.Command;
			this.comboBox_stopCondition.SelectedIndex = route.StopConditionType;
			this.numericUpDown_ExtraParameter.Value = route.ExtraParameter;
			this.CurrentProgress = route.CurrentProgress;
			this.checkBox_IsDistanceLimited.Checked = route.IsDistanceLimited;
			this.numericUpDown_maxDistanceLimit.Value = route.DistanceLimit;
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00040D9C File Offset: 0x0003EF9C
		private void UpdateRoute()
		{
			this.CurrentRoute = MonkService.OptimizeRoute(new MonkRoute(this.textBox_name.Text, this.checkBox_routeEnabled.Checked, this.GetListOfSelectedVillages(), this.GetCurrentTargets(), this.comboBox_command.SelectedIndex, this.comboBox_stopCondition.SelectedIndex, (int)this.numericUpDown_ExtraParameter.Value, this.CurrentProgress, this.checkBox_IsDistanceLimited.Checked, (int)this.numericUpDown_maxDistanceLimit.Value));
			this.RecalcTrips();
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00040E28 File Offset: 0x0003F028
		internal object[] GetRouteRow()
		{
			return new object[]
			{
				this.textBox_name.Text,
				this.checkBox_routeEnabled.Checked,
				string.Join(",", this.listBox_villages.SelectedItems.Cast<string>().ToArray<string>()),
				string.Join(",", this.listBox_targetParishes.Items.Cast<string>().Concat(this.listBox_targetVillages.Items.Cast<string>()).ToArray<string>()),
				this.comboBox_command.SelectedItem,
				this.comboBox_stopCondition.SelectedItem,
				(int)this.numericUpDown_ExtraParameter.Value,
				this.checkBox_IsDistanceLimited.Checked,
				(int)this.numericUpDown_maxDistanceLimit.Value
			};
		}

		// Token: 0x06000192 RID: 402 RVA: 0x00040F18 File Offset: 0x0003F118
		private void ComboBox_command_SelectedIndexChanged(object sender, EventArgs e)
		{
			int selectedIndex = this.comboBox_command.SelectedIndex;
			if (selectedIndex == 1 || selectedIndex == 2 || selectedIndex == 3)
			{
				this.groupBox_targetParishes.Visible = true;
				this.groupBox_targetVillages.Visible = false;
			}
			else if (selectedIndex == 0)
			{
				this.groupBox_targetParishes.Visible = true;
				this.groupBox_targetVillages.Visible = true;
			}
			else
			{
				this.groupBox_targetParishes.Visible = false;
				this.groupBox_targetVillages.Visible = true;
			}
			this.FillStopConditions((Command)selectedIndex);
			this.label_ExtraParameter.Visible = false;
			this.numericUpDown_ExtraParameter.Visible = false;
			this.label_specificStopCondition.Visible = false;
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00040FB8 File Offset: 0x0003F1B8
		private void FillStopConditions(Command command)
		{
			this.label_stopCondition.Visible = true;
			this.comboBox_stopCondition.Visible = true;
			this.comboBox_stopCondition.Items.Clear();
			this.comboBox_stopCondition.Items.Add(MonkService.StopConditions[0]);
			this.comboBox_stopCondition.Items.Add(MonkService.StopConditions[1]);
			if (command == Command.Excommunication)
			{
				return;
			}
			this.comboBox_stopCondition.Items.Add(MonkService.StopConditions[2]);
			this.label_specificStopCondition.Text = MonkService.StopConditionsDescription[(int)command];
		}

		// Token: 0x06000194 RID: 404 RVA: 0x0004104C File Offset: 0x0003F24C
		private void ComboBox_stopCondition_SelectedIndexChanged(object sender, EventArgs e)
		{
			int selectedIndex = this.comboBox_stopCondition.SelectedIndex;
			if (selectedIndex > 0)
			{
				this.label_ExtraParameter.Visible = true;
				this.numericUpDown_ExtraParameter.Visible = true;
				this.label_specificStopCondition.Visible = (selectedIndex == 2);
				return;
			}
			this.label_ExtraParameter.Visible = false;
			this.numericUpDown_ExtraParameter.Visible = false;
			this.label_specificStopCondition.Visible = false;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x000410B8 File Offset: 0x0003F2B8
		private void Button_addParish_Click(object sender, EventArgs e)
		{
			try
			{
				int num;
				if (string.IsNullOrEmpty(this.textBox_capitalId.Text))
				{
					MyMessageBox.Show(LNG.Print("Please specify Capital ID"));
				}
				else if (!int.TryParse(this.textBox_capitalId.Text, out num))
				{
					MyMessageBox.Show(LNG.Print("Only numbers 0-9!"));
				}
				else if (!GameEngine.Instance.World.isRegionCapital(num))
				{
					MyMessageBox.Show(LNG.Print("Please add only Parish Capitals IDs"));
				}
				else if (this._targetCapitals.Contains(num))
				{
					MyMessageBox.Show(LNG.Print("Capital is already added"));
				}
				else
				{
					this._targetCapitals.Add(num);
					this.listBox_targetParishes.Items.Add(GameEngine.Instance.World.getVillageName(num));
					this.RecalcMaxDistance();
				}
			}
			catch (Exception ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.Monks);
			}
		}

		// Token: 0x06000196 RID: 406 RVA: 0x000411AC File Offset: 0x0003F3AC
		private void Button_addVillage_Click(object sender, EventArgs e)
		{
			try
			{
				int num;
				if (string.IsNullOrEmpty(this.textBox_villageId.Text))
				{
					MyMessageBox.Show(LNG.Print("Please specify the village ID"));
				}
				else if (!int.TryParse(this.textBox_villageId.Text, out num))
				{
					MyMessageBox.Show(LNG.Print("Only numbers 0-9!"));
				}
				else if (!GameEngine.Instance.World.IsPlayerVillage(num))
				{
					MyMessageBox.Show(LNG.Print("Please add only Village IDs"));
				}
				else if (this._targetVillages.Contains(num))
				{
					MyMessageBox.Show(LNG.Print("Village is already added"));
				}
				else
				{
					this._targetVillages.Add(num);
					this.listBox_targetVillages.Items.Add(GameEngine.Instance.World.getVillageName(num));
					this.RecalcMaxDistance();
				}
			}
			catch (Exception ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.Monks);
			}
		}

		// Token: 0x06000197 RID: 407 RVA: 0x000412A0 File Offset: 0x0003F4A0
		private void Button_addMyParishes_Click(object sender, EventArgs e)
		{
			foreach (int num in GameEngine.Instance.World.getListOfUserParishCapitals())
			{
				if (!this._targetCapitals.Contains(num))
				{
					this._targetCapitals.Add(num);
					this.listBox_targetParishes.Items.Add(GameEngine.Instance.World.getVillageName(num));
				}
			}
			this.RecalcMaxDistance();
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00041338 File Offset: 0x0003F538
		private void Button_addMyVIllages_Click(object sender, EventArgs e)
		{
			foreach (int num in GameEngine.Instance.World.getListOfUserVillages())
			{
				if (!this._targetVillages.Contains(num))
				{
					this._targetVillages.Add(num);
					this.listBox_targetVillages.Items.Add(GameEngine.Instance.World.getVillageName(num));
				}
			}
			this.RecalcMaxDistance();
		}

		// Token: 0x06000199 RID: 409 RVA: 0x000413D0 File Offset: 0x0003F5D0
		private void Button_addParishesImIn_Click(object sender, EventArgs e)
		{
			List<int> listOfUserParishes = GameEngine.Instance.World.getListOfUserParishes();
			IEnumerable<int> enumerable = from x in listOfUserParishes
			select GameEngine.Instance.World.getParishCapital(x);
			foreach (int num in enumerable)
			{
				if (!this._targetCapitals.Contains(num))
				{
					this._targetCapitals.Add(num);
					this.listBox_targetParishes.Items.Add(GameEngine.Instance.World.getVillageName(num));
				}
			}
			this.RecalcMaxDistance();
		}

		// Token: 0x0600019A RID: 410 RVA: 0x00008E64 File Offset: 0x00007064
		private void Button_clearParishes_Click(object sender, EventArgs e)
		{
			if (DialogResult.OK == MessageBox.Show(LNG.Print("Are you sure?"), LNG.Print("Remove all items?"), MessageBoxButtons.OKCancel))
			{
				this._targetCapitals.Clear();
				this.listBox_targetParishes.Items.Clear();
			}
			this.RecalcMaxDistance();
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00008EA4 File Offset: 0x000070A4
		private void Button_clearTargetVillages_Click(object sender, EventArgs e)
		{
			if (DialogResult.OK == MessageBox.Show(LNG.Print("Are you sure?"), LNG.Print("Remove all items?"), MessageBoxButtons.OKCancel))
			{
				this._targetVillages.Clear();
				this.listBox_targetVillages.Items.Clear();
			}
			this.RecalcMaxDistance();
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00008EE4 File Offset: 0x000070E4
		private IEnumerable<int> GetListOfSelectedVillages()
		{
			foreach (object obj in this.listBox_villages.SelectedItems)
			{
				yield return ControlForm.GetId(obj.ToString());
			}
			IEnumerator enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00041488 File Offset: 0x0003F688
		private void Button_addParishesInRange_Click(object sender, EventArgs e)
		{
			try
			{
				WorldMap world = GameEngine.Instance.World;
				IEnumerable<VillageData> enumerable = from v in world.VillageList
				where v.regionCapital
				select v;
				double num = (double)this.numericUpDown_parishesRange.Value;
				num *= num;
				foreach (int villageID in this.GetListOfSelectedVillages())
				{
					Point villageLocation = world.getVillageLocation(villageID);
					foreach (VillageData villageData in enumerable)
					{
						double num2 = (double)GameEngine.Instance.World.getSquareDistance(villageLocation.X, villageLocation.Y, villageData.id);
						if (num2 <= num && !this._targetCapitals.Contains(villageData.id))
						{
							this._targetCapitals.Add(villageData.id);
							this.listBox_targetParishes.Items.Add(villageData.villageName);
						}
					}
				}
				this.RecalcMaxDistance();
			}
			catch (Exception ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.Monks);
			}
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00041610 File Offset: 0x0003F810
		private void Button_addVillagesInRange_Click(object sender, EventArgs e)
		{
			try
			{
				WorldMap world = GameEngine.Instance.World;
				double num = (double)this.numericUpDown_villagesRange.Value;
				num *= num;
				List<int> list = new List<int>();
				foreach (object obj in this.listBox_villages.SelectedItems)
				{
					list.Add(ControlForm.GetId(obj.ToString()));
				}
				foreach (int villageID in list)
				{
					Point villageLocation = world.getVillageLocation(villageID);
					foreach (VillageData villageData in world.VillageList)
					{
						if (world.IsPlayerVillage(villageData.id))
						{
							double num2 = (double)world.getSquareDistance(villageLocation.X, villageLocation.Y, villageData.id);
							if (num2 <= num && !this._targetVillages.Contains(villageData.id))
							{
								this._targetVillages.Add(villageData.id);
								this.listBox_targetVillages.Items.Add(villageData.villageName);
							}
						}
					}
				}
				this.RecalcMaxDistance();
			}
			catch (Exception ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.Monks);
			}
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00008EF4 File Offset: 0x000070F4
		private void ListBox_villages_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.RecalcMaxDistance();
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00008EF4 File Offset: 0x000070F4
		private void GroupBox_targetParishes_VisibleChanged(object sender, EventArgs e)
		{
			this.RecalcMaxDistance();
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00008EF4 File Offset: 0x000070F4
		private void GroupBox_targetVillages_VisibleChanged(object sender, EventArgs e)
		{
			this.RecalcMaxDistance();
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x000417C4 File Offset: 0x0003F9C4
		private List<int> GetCurrentTargets()
		{
			List<int> list = new List<int>();
			if (this.groupBox_targetParishes.Visible)
			{
				list.AddRange(this._targetCapitals);
			}
			if (this.groupBox_targetVillages.Visible)
			{
				list.AddRange(this._targetVillages);
			}
			return list;
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x0004180C File Offset: 0x0003FA0C
		private void RecalcMaxDistance()
		{
			List<int> currentTargets = this.GetCurrentTargets();
			if (this.listBox_villages.SelectedItems.Count == 0 || currentTargets.Count == 0)
			{
				this.label_maxDistanceFromValue.Text = (this.label_maxDistanceToValue.Text = (this.label_maxDistanceValue.Text = (this.label_maxDistanceTimeValue.Text = LNG.Print("no data"))));
				return;
			}
			double num = double.MinValue;
			string text = string.Empty;
			string text2 = string.Empty;
			int from = 0;
			int to = 0;
			foreach (object obj in this.listBox_villages.SelectedItems)
			{
				string text3 = (string)obj;
				foreach (int num2 in currentTargets)
				{
					int id = ControlForm.GetId(text3);
					if (id != num2)
					{
						double distance = GameEngine.Instance.World.getDistance(id, num2);
						if (distance > num && (!this.checkBox_IsDistanceLimited.Checked || distance < (double)this.numericUpDown_maxDistanceLimit.Value))
						{
							num = distance;
							text = text3;
							text2 = GameEngine.Instance.World.getVillageName(num2);
							from = id;
							to = num2;
						}
					}
				}
			}
			this.label_maxDistanceFromValue.Text = text;
			this.label_maxDistanceToValue.Text = text2;
			this.label_maxDistanceValue.Text = ((int)num).ToString();
			this.label_maxDistanceTimeValue.Text = this.GetMonkTimeFromDistance(num, from, to);
			this.UpdateRoute();
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x000419E4 File Offset: 0x0003FBE4
		private string GetMonkTimeFromDistance(double distance, int from, int to)
		{
			WorldData localWorldData = GameEngine.Instance.LocalWorldData;
			if (localWorldData != null)
			{
				distance *= localWorldData.PriestMoveSpeed * localWorldData.gamePlaySpeed;
				distance = GameEngine.Instance.World.UserResearchData.adjustPriestTimes(distance);
				distance *= CardTypes.adjustMonkSpeed(GameEngine.Instance.cardsManager.UserCardData);
				distance = GameEngine.Instance.World.adjustIfIslandTravel(distance, from, to);
			}
			return VillageMap.createBuildTimeString((int)distance);
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x00041A5C File Offset: 0x0003FC5C
		private void ListBox_targetParishes_DoubleClick(object sender, EventArgs e)
		{
			if (this.listBox_targetParishes.SelectedIndex == -1)
			{
				return;
			}
			this._targetCapitals.Remove(ControlForm.GetId(this.listBox_targetParishes.SelectedItem.ToString()));
			this.listBox_targetParishes.Items.RemoveAt(this.listBox_targetParishes.SelectedIndex);
			this.RecalcMaxDistance();
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x00041ABC File Offset: 0x0003FCBC
		private void ListBox_targetVillages_DoubleClick(object sender, EventArgs e)
		{
			if (this.listBox_targetVillages.SelectedIndex == -1)
			{
				return;
			}
			this._targetVillages.Remove(ControlForm.GetId(this.listBox_targetVillages.SelectedItem.ToString()));
			this.listBox_targetVillages.Items.RemoveAt(this.listBox_targetVillages.SelectedIndex);
			this.RecalcMaxDistance();
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x00041B1C File Offset: 0x0003FD1C
		private void CheckBox_allVillages_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.checkBox_allVillages.Checked;
			for (int i = 0; i < this.listBox_villages.Items.Count; i++)
			{
				this.listBox_villages.SetSelected(i, @checked);
			}
			this.RecalcMaxDistance();
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x00041B64 File Offset: 0x0003FD64
		private string IsRouteValid()
		{
			if (this.listBox_villages.SelectedItems.Count == 0)
			{
				return "Select at least 1 village in \"Monking villages\" section";
			}
			if (this.comboBox_command.SelectedIndex == -1)
			{
				return "Specify Monk Command";
			}
			if (this.comboBox_stopCondition.SelectedIndex == -1)
			{
				return "Specify Stop Condition";
			}
			if (this.listBox_Trips.Items.Count == 0)
			{
				return "This route won't do anything. Please change your settings (increase distance limit or something else)";
			}
			return string.Empty;
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00041BD0 File Offset: 0x0003FDD0
		private void Button_SaveMonkRoute_Click(object sender, EventArgs e)
		{
			this.UpdateRoute();
			string text = this.IsRouteValid();
			if (text != string.Empty)
			{
				MessageBox.Show(LNG.Print(text));
				return;
			}
			this._createRouteDel(this.CurrentRoute, this.GetRouteRow(), this._routeIndex);
			MessageBox.Show(LNG.Print("Route is saved") + ": \"" + this.textBox_name.Text + "\"");
		}

		// Token: 0x060001AA RID: 426 RVA: 0x00041C4C File Offset: 0x0003FE4C
		private void RecalcTrips()
		{
			this.listBox_Trips.Items.Clear();
			using (IEnumerator<int> enumerator = this.CurrentRoute.From.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int sender = enumerator.Current;
					if (this.CurrentRoute.SortedRecipients[sender].Count<int>() != 0)
					{
						this.listBox_Trips.Items.Add(GameEngine.Instance.World.getVillageName(sender) + " => " + string.Join(",", (from sr in this.CurrentRoute.SortedRecipients[sender]
						select GameEngine.Instance.World.getVillageName(sr) + " (" + this.GetMonkTimeFromDistance(GameEngine.Instance.World.getDistance(sr, sender), sr, sender) + ")").ToArray<string>()));
					}
				}
			}
		}

		// Token: 0x060001AB RID: 427 RVA: 0x00008EF4 File Offset: 0x000070F4
		private void CheckBox_IsDistanceLimited_CheckedChanged(object sender, EventArgs e)
		{
			this.RecalcMaxDistance();
		}

		// Token: 0x060001AC RID: 428 RVA: 0x00008EF4 File Offset: 0x000070F4
		private void NumericUpDown_maxDistanceLimit_ValueChanged(object sender, EventArgs e)
		{
			this.RecalcMaxDistance();
		}

		// Token: 0x060001AD RID: 429 RVA: 0x00008EFC File Offset: 0x000070FC
		private void NumericUpDown_parishesRange_ValueChanged(object sender, EventArgs e)
		{
			if (this.numericUpDown_parishesRange.Value > this.numericUpDown_maxDistanceLimit.Value)
			{
				this.numericUpDown_maxDistanceLimit.Value = this.numericUpDown_parishesRange.Value;
			}
		}

		// Token: 0x060001AE RID: 430 RVA: 0x00008F31 File Offset: 0x00007131
		private void NumericUpDown_villagesRange_ValueChanged(object sender, EventArgs e)
		{
			if (this.numericUpDown_villagesRange.Value > this.numericUpDown_maxDistanceLimit.Value)
			{
				this.numericUpDown_maxDistanceLimit.Value = this.numericUpDown_villagesRange.Value;
			}
		}

		// Token: 0x040002E0 RID: 736
		private MonkRoute CurrentRoute;

		// Token: 0x040002E1 RID: 737
		private SaveMonkRouteDel _createRouteDel;

		// Token: 0x040002E2 RID: 738
		private int _routeIndex;

		// Token: 0x040002E3 RID: 739
		private List<int> _targetCapitals = new List<int>();

		// Token: 0x040002E4 RID: 740
		private List<int> _targetVillages = new List<int>();

		// Token: 0x040002E5 RID: 741
		private Dictionary<int, int> CurrentProgress;
	}
}
