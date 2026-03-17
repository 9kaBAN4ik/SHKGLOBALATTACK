using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x0200019A RID: 410
	public partial class DisbandTroopsPopup : MyFormBase
	{
		// Token: 0x06000FC7 RID: 4039 RVA: 0x000117F5 File Offset: 0x0000F9F5
		public DisbandTroopsPopup()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06000FC8 RID: 4040 RVA: 0x00116024 File Offset: 0x00114224
		public void init(int troopType)
		{
			string text = this.Text = (base.Title = SK.Text("GENERIC_Disband", "Disband"));
			this.customPanel.init(this, troopType, true);
		}

		// Token: 0x040015F1 RID: 5617
		private int m_troopType = -1;
	}
}
