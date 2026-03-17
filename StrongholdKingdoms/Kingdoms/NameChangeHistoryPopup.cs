using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x0200024E RID: 590
	public partial class NameChangeHistoryPopup : MyFormBase
	{
		// Token: 0x06001A1F RID: 6687 RVA: 0x0001A2E9 File Offset: 0x000184E9
		public NameChangeHistoryPopup()
		{
			this.InitializeComponent();
		}

		// Token: 0x06001A20 RID: 6688 RVA: 0x0019D834 File Offset: 0x0019BA34
		public void importData(string[] names, int parishID)
		{
			string text = this.Text = (base.Title = "Parish Name History : " + parishID.ToString());
			for (int i = 0; i < names.Length; i += 2)
			{
				NameChangeHistoryPopup.HistoryItem historyItem = new NameChangeHistoryPopup.HistoryItem();
				historyItem.name = names[i];
				historyItem.userguid = names[i + 1];
				this.listBox1.Items.Add(historyItem);
			}
		}

		// Token: 0x06001A21 RID: 6689 RVA: 0x00009024 File Offset: 0x00007224
		private void btnOK_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0200024F RID: 591
		private class HistoryItem
		{
			// Token: 0x06001A24 RID: 6692 RVA: 0x0001A316 File Offset: 0x00018516
			public override string ToString()
			{
				return string.Format("{0,-50}{1, -32}", this.name, this.userguid);
			}

			// Token: 0x04002ADE RID: 10974
			public string name = "";

			// Token: 0x04002ADF RID: 10975
			public string userguid = "";
		}
	}
}
