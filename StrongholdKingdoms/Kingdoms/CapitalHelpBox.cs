using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x02000104 RID: 260
	public partial class CapitalHelpBox : MyFormBase
	{
		// Token: 0x06000808 RID: 2056 RVA: 0x000AAF28 File Offset: 0x000A9128
		public static void openHelpBox(int buildingType)
		{
			if (CapitalHelpBox.helpBox == null || !CapitalHelpBox.helpBox.Visible)
			{
				CapitalHelpBox.helpBox = new CapitalHelpBox();
			}
			CapitalHelpBox.helpBox.init(buildingType);
			CapitalHelpBox.helpBox.Show();
			CapitalHelpBox.helpBox.TopMost = true;
			CapitalHelpBox.helpBox.TopMost = false;
		}

		// Token: 0x06000809 RID: 2057 RVA: 0x0000CA6F File Offset: 0x0000AC6F
		public static void closeHelpBox()
		{
			if (CapitalHelpBox.helpBox != null)
			{
				CapitalHelpBox.helpBox.Close();
				CapitalHelpBox.helpBox = null;
			}
		}

		// Token: 0x0600080A RID: 2058 RVA: 0x000AAF80 File Offset: 0x000A9180
		public CapitalHelpBox()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.lblBuildingType.Font = FontManager.GetFont("Microsoft Sans Serif", 9f, FontStyle.Bold);
			this.Text = (base.Title = SK.Text("MENU_Help", "Help"));
		}

		// Token: 0x0600080B RID: 2059 RVA: 0x0000CA88 File Offset: 0x0000AC88
		public void init(int buildingType)
		{
			this.lblBuildingType.Text = VillageBuildingsData.getBuildingName(buildingType);
			this.lblHelpText.Text = VillageBuildingsData.getCapitalBuildingHelpText(buildingType);
		}

		// Token: 0x0600080C RID: 2060 RVA: 0x0000CAAC File Offset: 0x0000ACAC
		private void btnClose_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("CapitalHelpBox_Close");
			CapitalHelpBox.closeHelpBox();
		}

		// Token: 0x04000B57 RID: 2903
		public static CapitalHelpBox helpBox;
	}
}
