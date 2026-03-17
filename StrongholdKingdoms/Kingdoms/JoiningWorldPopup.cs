using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x0200020B RID: 523
	public partial class JoiningWorldPopup : MyFormBase
	{
		// Token: 0x06001630 RID: 5680 RVA: 0x00017832 File Offset: 0x00015A32
		public JoiningWorldPopup()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06001631 RID: 5681 RVA: 0x0015FC2C File Offset: 0x0015DE2C
		public void init(int county, string country)
		{
			if (county >= 0)
			{
				this.label1.Text = SK.Text("JoiningWorldPopup_Find_Village", "Trying to Find Village in :");
				this.lblCounty.Text = GameEngine.Instance.World.getCountyName(county);
			}
			else
			{
				this.label1.Text = SK.Text("JoiningWorldPopup_Find_Village2", "Trying to Find Village");
				this.lblCounty.Text = "";
			}
			this.label2.Text = SK.Text("JoiningWorldPopup_Please_Wait", "Please wait, this may take a few moments.");
			string text = this.Text = (base.Title = SK.Text("JoiningWorldPopup_Finding_Village", "Finding Village"));
		}
	}
}
