using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Upgrade
{
	// Token: 0x0200001D RID: 29
	public partial class CopySettings : Form
	{
		// Token: 0x06000156 RID: 342 RVA: 0x0003EEF4 File Offset: 0x0003D0F4
		public CopySettings(CopySettingsDel del, IEnumerable<string> listOfModules, IEnumerable<string> listOfVillages, int moduleToSelect, int villageToSelect)
		{
			this.InitializeComponent();
			this._del = del;
			foreach (string item in listOfModules)
			{
				this.listBox_Modules.Items.Add(item);
			}
			foreach (string item2 in listOfVillages)
			{
				this.comboBox_Villages.Items.Add(item2);
				this.listBox_Villages.Items.Add(item2);
			}
			this.comboBox_Villages.SelectedIndex = 0;
			if (moduleToSelect != -1)
			{
				this.listBox_Modules.SetSelected(moduleToSelect, true);
			}
			if (villageToSelect != -1)
			{
				if (listOfModules.Contains("Predator"))
				{
					this.comboBox_Villages.SelectedIndex = villageToSelect;
					return;
				}
				for (int i = 0; i < this.comboBox_Villages.Items.Count; i++)
				{
					if (ControlForm.GetId(this.comboBox_Villages.Items[i].ToString()) == villageToSelect)
					{
						this.comboBox_Villages.SelectedIndex = i;
						return;
					}
				}
			}
		}

		// Token: 0x06000157 RID: 343 RVA: 0x0003F03C File Offset: 0x0003D23C
		private void button_Copy_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure?", "", MessageBoxButtons.OK) == DialogResult.OK)
			{
				this._del(this.listBox_Modules.SelectedItems.Cast<string>(), this.comboBox_Villages.SelectedItem.ToString(), this.listBox_Villages.SelectedItems.Cast<string>(), this.checkBox_saveSettings.Checked);
			}
		}

		// Token: 0x06000158 RID: 344 RVA: 0x0003F0A4 File Offset: 0x0003D2A4
		private void checkBox_Modules_CheckedChanged(object sender, EventArgs e)
		{
			for (int i = 0; i < this.listBox_Modules.Items.Count; i++)
			{
				this.listBox_Modules.SetSelected(i, this.checkBox_Modules.Checked);
			}
		}

		// Token: 0x06000159 RID: 345 RVA: 0x0003F0E4 File Offset: 0x0003D2E4
		private void checkBox_Villages_CheckedChanged(object sender, EventArgs e)
		{
			for (int i = 0; i < this.listBox_Villages.Items.Count; i++)
			{
				this.listBox_Villages.SetSelected(i, this.checkBox_Villages.Checked);
			}
		}

		// Token: 0x040002AA RID: 682
		private CopySettingsDel _del;
	}
}
