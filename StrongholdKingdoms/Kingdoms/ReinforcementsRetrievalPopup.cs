using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x020002B4 RID: 692
	public partial class ReinforcementsRetrievalPopup : MyFormBase
	{
		// Token: 0x06001EEC RID: 7916 RVA: 0x0001D737 File Offset: 0x0001B937
		public ReinforcementsRetrievalPopup()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06001EED RID: 7917 RVA: 0x001DC910 File Offset: 0x001DAB10
		public void init(VillageReinforcementsPanel2 p, long reinforcementID, int totalPeasants, int totalArchers, int totalPikemen, int totalSwordsmen, int totalCatapults)
		{
			this.btnRetrieve.Text = SK.Text("ReinforcementsRetrieval_Retrieve", "Retrieve");
			this.btnAll.Text = SK.Text("ReinforcementsRetrieval_Select_All", "Select All");
			this.btnCancel.Text = SK.Text("GENERIC_Cancel", "Cancel");
			this.label2.Text = SK.Text("GENERIC_Peasants", "Peasants");
			this.label3.Text = SK.Text("GENERIC_Archers", "Archers");
			this.label5.Text = SK.Text("GENERIC_Pikemen", "Pikemen");
			this.label7.Text = SK.Text("GENERIC_Swordsmens", "Swordsmen");
			this.label9.Text = SK.Text("GENERIC_Catapults", "Catapults");
			string text = base.Title = (this.Text = SK.Text("ReinforcementsRetrieval_Retrieve_Reinforcements", "Retrieve Reinforcements"));
			this.parent = p;
			this.reinfID = reinforcementID;
			this.numPeasants = totalPeasants;
			this.numArchers = totalArchers;
			this.numPikemen = totalPikemen;
			this.numSwordsmen = totalSwordsmen;
			this.numCatapults = totalCatapults;
			this.drawing = false;
			this.tbPeasants.Value = 0;
			this.tbPeasants.Maximum = Math.Max(this.numPeasants, 0);
			this.tbPeasants.Value = this.tbPeasants.Maximum;
			this.tbArchers.Value = 0;
			this.tbArchers.Maximum = Math.Max(this.numArchers, 0);
			this.tbArchers.Value = this.tbArchers.Maximum;
			this.tbPikemen.Value = 0;
			this.tbPikemen.Maximum = Math.Max(this.numPikemen, 0);
			this.tbPikemen.Value = this.tbPikemen.Maximum;
			this.tbSwordsmen.Value = 0;
			this.tbSwordsmen.Maximum = Math.Max(this.numSwordsmen, 0);
			this.tbSwordsmen.Value = this.tbSwordsmen.Maximum;
			this.tbCatapults.Value = 0;
			this.tbCatapults.Maximum = Math.Max(this.numCatapults, 0);
			this.tbCatapults.Value = this.tbCatapults.Maximum;
			this.drawing = true;
			this.updateText();
		}

		// Token: 0x06001EEE RID: 7918 RVA: 0x001DCB78 File Offset: 0x001DAD78
		private void btnRetrieve_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("ReinforcementsRetrievalPopup_retrieve");
			bool flag = true;
			if (this.tbPeasants.Value != this.numPeasants || this.tbArchers.Value != this.numArchers || this.tbPikemen.Value != this.numPikemen || this.tbSwordsmen.Value != this.numSwordsmen || this.tbCatapults.Value != this.numCatapults)
			{
				flag = false;
			}
			if (flag)
			{
				RemoteServices.Instance.ReturnReinforcements(this.reinfID);
			}
			else
			{
				RemoteServices.Instance.ReturnReinforcements(this.reinfID, this.tbPeasants.Value, this.tbArchers.Value, this.tbPikemen.Value, this.tbSwordsmen.Value, this.tbCatapults.Value);
			}
			base.Close();
		}

		// Token: 0x06001EEF RID: 7919 RVA: 0x001DCC5C File Offset: 0x001DAE5C
		private void updateText()
		{
			if (this.drawing)
			{
				this.lblPeasants.Text = this.tbPeasants.Value.ToString() + "/" + this.numPeasants.ToString();
				this.lblArchers.Text = this.tbArchers.Value.ToString() + "/" + this.numArchers.ToString();
				this.lblPikemen.Text = this.tbPikemen.Value.ToString() + "/" + this.numPikemen.ToString();
				this.lblSwordsmen.Text = this.tbSwordsmen.Value.ToString() + "/" + this.numSwordsmen.ToString();
				this.lblCatapults.Text = this.tbCatapults.Value.ToString() + "/" + this.numCatapults.ToString();
			}
		}

		// Token: 0x06001EF0 RID: 7920 RVA: 0x0001D769 File Offset: 0x0001B969
		private void btnCancel_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("ReinforcementsRetrievalPopup_cancel");
			base.Close();
		}

		// Token: 0x06001EF1 RID: 7921 RVA: 0x001DCD74 File Offset: 0x001DAF74
		private void btnAll_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("ReinforcementsRetrievalPopup_all");
			this.drawing = false;
			this.tbPeasants.Value = this.numPeasants;
			this.tbArchers.Value = this.numArchers;
			this.tbPikemen.Value = this.numPikemen;
			this.tbSwordsmen.Value = this.numSwordsmen;
			this.tbCatapults.Value = this.numCatapults;
			this.drawing = true;
			this.updateText();
		}

		// Token: 0x06001EF2 RID: 7922 RVA: 0x0001D780 File Offset: 0x0001B980
		private void tbPeasants_ValueChanged(object sender, EventArgs e)
		{
			this.updateText();
		}

		// Token: 0x06001EF3 RID: 7923 RVA: 0x0001D780 File Offset: 0x0001B980
		private void tbArchers_ValueChanged(object sender, EventArgs e)
		{
			this.updateText();
		}

		// Token: 0x06001EF4 RID: 7924 RVA: 0x0001D780 File Offset: 0x0001B980
		private void tbPikemen_ValueChanged(object sender, EventArgs e)
		{
			this.updateText();
		}

		// Token: 0x06001EF5 RID: 7925 RVA: 0x0001D780 File Offset: 0x0001B980
		private void tbSwordsmen_ValueChanged(object sender, EventArgs e)
		{
			this.updateText();
		}

		// Token: 0x06001EF6 RID: 7926 RVA: 0x0001D780 File Offset: 0x0001B980
		private void tbCatapults_ValueChanged(object sender, EventArgs e)
		{
			this.updateText();
		}

		// Token: 0x04002FCF RID: 12239
		private VillageReinforcementsPanel2 parent;

		// Token: 0x04002FD0 RID: 12240
		private long reinfID = -1L;

		// Token: 0x04002FD1 RID: 12241
		private int numPeasants;

		// Token: 0x04002FD2 RID: 12242
		private int numArchers;

		// Token: 0x04002FD3 RID: 12243
		private int numPikemen;

		// Token: 0x04002FD4 RID: 12244
		private int numSwordsmen;

		// Token: 0x04002FD5 RID: 12245
		private int numCatapults;

		// Token: 0x04002FD6 RID: 12246
		private bool drawing = true;
	}
}
