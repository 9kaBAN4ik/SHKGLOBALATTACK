using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Upgrade
{
	// Token: 0x02000024 RID: 36
	public partial class TabHost : Form
	{
		// Token: 0x06000177 RID: 375 RVA: 0x0003FAC4 File Offset: 0x0003DCC4
		public TabHost(TabPage tab, TabControl tabControl)
		{
			this.InitializeComponent();
			this.label_TabHostTip.Text = LNG.Print("Closing the window brings the tab back");
			this.checkBox_TabHostKeepOnTop.Text = LNG.Print("Stay On Top");
			base.Size = tabControl.Parent.Size;
			this.Text = tab.Text;
			this.tabPosition = tabControl.TabPages.IndexOf(tab);
			this.tabControl1.TabPages.Add(tab);
			this._tab = tab;
			this._parent = tabControl;
		}

		// Token: 0x06000178 RID: 376 RVA: 0x0003FB58 File Offset: 0x0003DD58
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			ControlForm controlForm = (ControlForm)this._parent.Parent;
			if (keyData != (Keys.LButton | Keys.MButton | Keys.Space | Keys.Control))
			{
				if (keyData != (Keys.LButton | Keys.RButton | Keys.MButton | Keys.Space | Keys.Control))
				{
					if (keyData == (Keys)196675)
					{
						controlForm.button_CopySettings_Click(null, EventArgs.Empty);
					}
				}
				else
				{
					if (this.tabControl1.SelectedTab.Name == "tabPage_Trade")
					{
						controlForm.button_TradeNextVillage_Click(null, EventArgs.Empty);
						return true;
					}
					if (this.tabControl1.SelectedTab.Name == "tabPage_Scouting")
					{
						controlForm.button_ScoutingNextVillage_Click(null, EventArgs.Empty);
						return true;
					}
					if (this.tabControl1.SelectedTab.Name == "tabPage_Villagelayout")
					{
						controlForm.button_nextLayout_Click(null, EventArgs.Empty);
						return true;
					}
				}
			}
			else
			{
				if (this.tabControl1.SelectedTab.Name == "tabPage_Trade")
				{
					controlForm.button_TradePreviousVillage_Click(null, EventArgs.Empty);
					return true;
				}
				if (this.tabControl1.SelectedTab.Name == "tabPage_Scouting")
				{
					controlForm.button_ScoutingPreviousVillage_Click(null, EventArgs.Empty);
					return true;
				}
				if (this.tabControl1.SelectedTab.Name == "tabPage_Villagelayout")
				{
					controlForm.button_previousLayout_Click(null, EventArgs.Empty);
					return true;
				}
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00008DBE File Offset: 0x00006FBE
		private void TabHost_FormClosing(object sender, FormClosingEventArgs e)
		{
			this._parent.TabPages.Insert(this.tabPosition, this._tab);
			this._parent = null;
			this._tab = null;
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00008DEA File Offset: 0x00006FEA
		private void TabHost_Load(object sender, EventArgs e)
		{
			base.Location = Cursor.Position;
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00008DF7 File Offset: 0x00006FF7
		private void checkBox_TabHostKeepOnTop_CheckedChanged(object sender, EventArgs e)
		{
			base.TopMost = this.checkBox_TabHostKeepOnTop.Checked;
		}

		// Token: 0x040002C6 RID: 710
		private TabPage _tab;

		// Token: 0x040002C7 RID: 711
		private TabControl _parent;

		// Token: 0x040002C8 RID: 712
		private int tabPosition;
	}
}
