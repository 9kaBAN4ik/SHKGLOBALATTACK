using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x020000F4 RID: 244
	public partial class BuyCrownsPopup : MyFormBase
	{
		// Token: 0x06000752 RID: 1874 RVA: 0x000968C4 File Offset: 0x00094AC4
		public BuyCrownsPopup()
		{
			this.InitializeComponent();
			this.lblMessage.Font = FontManager.GetFont("Arial", 9.75f, FontStyle.Regular);
			base.Title = (this.Text = SK.Text("BuyCardsPanel_Low_Crowns", "Crown stocks are too low m'lord"));
			this.btnBuyCrowns.Text = SK.Text("BuyCrownsPanel_Buy_Crowns", "Buy Crowns");
			this.btnBuyCrowns.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
		}

		// Token: 0x06000753 RID: 1875 RVA: 0x0009694C File Offset: 0x00094B4C
		public void init(int numCrownsNeeded, Form parent)
		{
			this.m_parent = parent;
			this.lblMessage.Text = string.Concat(new string[]
			{
				SK.Text("BuyCardsPanel_Cannot_Afford", "You cannot afford this."),
				Environment.NewLine,
				Environment.NewLine,
				SK.Text("BuyCardsPanel_Extra_Crowns_Needed", "Extra Crowns Needed"),
				" : ",
				numCrownsNeeded.ToString()
			});
		}

		// Token: 0x06000754 RID: 1876 RVA: 0x0000C0B1 File Offset: 0x0000A2B1
		private void btnOK_Click(object sender, EventArgs e)
		{
			((PlayCardsWindow)this.m_parent).GetCrowns();
			base.Close();
		}

		// Token: 0x040009A7 RID: 2471
		private Form m_parent;
	}
}
