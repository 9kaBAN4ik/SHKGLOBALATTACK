using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x0200047C RID: 1148
	public partial class ScoutPopupWindow : Form
	{
		// Token: 0x060029B7 RID: 10679 RVA: 0x0001EAE9 File Offset: 0x0001CCE9
		public ScoutPopupWindow()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x060029B8 RID: 10680 RVA: 0x0001EB0C File Offset: 0x0001CD0C
		public void init(int villageID, bool reset)
		{
			this.scoutPopupPanel.init(villageID, reset);
		}

		// Token: 0x060029B9 RID: 10681 RVA: 0x0001EB1B File Offset: 0x0001CD1B
		public void update()
		{
			this.scoutPopupPanel.update();
		}

		// Token: 0x060029BA RID: 10682 RVA: 0x0001EB28 File Offset: 0x0001CD28
		public void villageLoaded(int villageID)
		{
			this.scoutPopupPanel.onVillageLoadUpdate(villageID, true);
		}

		// Token: 0x060029BB RID: 10683 RVA: 0x00204388 File Offset: 0x00202588
		private void ScoutPopupPanel_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseReason closeReason = e.CloseReason;
			if (closeReason == CloseReason.UserClosing && !this.closing)
			{
				this.closing = true;
				InterfaceMgr.Instance.closeScoutPopupWindow();
			}
		}

		// Token: 0x04003367 RID: 13159
		private bool closing;
	}
}
