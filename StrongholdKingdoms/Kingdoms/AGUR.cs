using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x020000BF RID: 191
	public partial class AGUR : Form
	{
		// Token: 0x06000540 RID: 1344 RVA: 0x0000AD26 File Offset: 0x00008F26
		public AGUR()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x00063B98 File Offset: 0x00061D98
		public void init(int villageID)
		{
			this.m_villageID = villageID;
			this.Text = "Give Resources To : " + GameEngine.Instance.World.getVillageName(this.m_villageID);
			if (GameEngine.Instance.World.isCapital(this.m_villageID))
			{
				this.btnGiveResources.Enabled = false;
			}
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x00009024 File Offset: 0x00007224
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x00063BF4 File Offset: 0x00061DF4
		private void btnGiveResources_Click(object sender, EventArgs e)
		{
			int int32FromString = UserInfoScreen2.getInt32FromString(this.tbAmount.Text);
			if (int32FromString > 0 && int32FromString <= 100000)
			{
				int num = 0;
				if (this.rbWood.Checked)
				{
					num = 6;
				}
				if (this.rbStone.Checked)
				{
					num = 7;
				}
				if (this.rbIron.Checked)
				{
					num = 8;
				}
				if (this.rbPitch.Checked)
				{
					num = 9;
				}
				if (this.rbAle.Checked)
				{
					num = 12;
				}
				if (this.rbApples.Checked)
				{
					num = 13;
				}
				if (this.rbBread.Checked)
				{
					num = 14;
				}
				if (this.rbMeat.Checked)
				{
					num = 16;
				}
				if (this.rbCheese.Checked)
				{
					num = 17;
				}
				if (this.rbVeg.Checked)
				{
					num = 15;
				}
				if (this.rbFish.Checked)
				{
					num = 18;
				}
				if (this.rbBows.Checked)
				{
					num = 29;
				}
				if (this.rbPikes.Checked)
				{
					num = 28;
				}
				if (this.rbSwords.Checked)
				{
					num = 30;
				}
				if (this.rbArmour.Checked)
				{
					num = 31;
				}
				if (this.rbCatapults.Checked)
				{
					num = 32;
				}
				if (this.rbVenison.Checked)
				{
					num = 22;
				}
				if (this.rbClothes.Checked)
				{
					num = 19;
				}
				if (this.rbFurniture.Checked)
				{
					num = 21;
				}
				if (this.rbMetalware.Checked)
				{
					num = 26;
				}
				if (this.rbSalt.Checked)
				{
					num = 23;
				}
				if (this.rbWine.Checked)
				{
					num = 33;
				}
				if (this.rbSpices.Checked)
				{
					num = 24;
				}
				if (this.rbSilk.Checked)
				{
					num = 25;
				}
				if (num != 0)
				{
					this.sendCommandToServer(1000 + num, int32FromString);
				}
			}
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x0000AD46 File Offset: 0x00008F46
		public void setReasonString(string reasonString)
		{
			this.m_reasonString = reasonString;
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x00063DB4 File Offset: 0x00061FB4
		private void sendCommandToServer(int command, int duration)
		{
			if (!RemoteServices.Instance.Admin)
			{
				MyMessageBox.Show("Command not sent", "Admin Error");
				return;
			}
			this.m_reasonString = "";
			ReasonPopup reasonPopup = new ReasonPopup();
			reasonPopup.initResources(this, command - 1000);
			reasonPopup.ShowDialog();
			if (this.m_reasonString.Length > 0)
			{
				RemoteServices.Instance.SendCommands(this.m_villageID, command, duration, this.m_reasonString);
				base.Close();
				return;
			}
			MyMessageBox.Show("Not reason given", "Admin Error");
		}

		// Token: 0x04000607 RID: 1543
		private int m_villageID = -1;

		// Token: 0x04000608 RID: 1544
		private string m_reasonString = "";
	}
}
