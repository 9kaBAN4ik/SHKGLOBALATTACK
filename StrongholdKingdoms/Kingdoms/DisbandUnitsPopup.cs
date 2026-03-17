using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x0200019B RID: 411
	public partial class DisbandUnitsPopup : MyFormBase
	{
		// Token: 0x06000FCB RID: 4043 RVA: 0x0001183E File Offset: 0x0000FA3E
		public DisbandUnitsPopup()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06000FCC RID: 4044 RVA: 0x0011617C File Offset: 0x0011437C
		public void init(int troopType)
		{
			string text = this.Text = (base.Title = SK.Text("GENERIC_Disband", "Disband"));
			this.customPanel.init(this, troopType, false);
		}
	}
}
