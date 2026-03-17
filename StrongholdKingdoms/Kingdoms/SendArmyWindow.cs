using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000486 RID: 1158
	public partial class SendArmyWindow : Form
	{
		// Token: 0x06002A26 RID: 10790 RVA: 0x0001F013 File Offset: 0x0001D213
		public SendArmyWindow()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06002A27 RID: 10791 RVA: 0x0020B2B0 File Offset: 0x002094B0
		public void init(int parentFromVillage, int fromVillageID, int toVillageID, string villageName, double distance, BattleHonourData honourData, bool gotCaptain, CastleMapAttackerSetupPanel parent)
		{
			this.sendArmyPanel.init(parentFromVillage, fromVillageID, toVillageID, villageName, distance, honourData, gotCaptain, parent);
		}

		// Token: 0x06002A28 RID: 10792 RVA: 0x0001F036 File Offset: 0x0001D236
		public void update()
		{
			this.sendArmyPanel.update();
		}

		// Token: 0x06002A29 RID: 10793 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void villageLoaded(int villageID)
		{
		}

		// Token: 0x06002A2A RID: 10794 RVA: 0x0020B2D8 File Offset: 0x002094D8
		private void SendArmyWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseReason closeReason = e.CloseReason;
			if (closeReason == CloseReason.UserClosing && !this.closing)
			{
				this.closing = true;
				InterfaceMgr.Instance.closeLaunchAttackPopup();
			}
		}

		// Token: 0x040033DF RID: 13279
		private bool closing;
	}
}
