using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x020000D1 RID: 209
	public partial class AttackReportsResourcesPanel : MyFormBase
	{
		// Token: 0x060005E9 RID: 1513 RVA: 0x0000B1D9 File Offset: 0x000093D9
		public AttackReportsResourcesPanel()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x000788A8 File Offset: 0x00076AA8
		public void setResources(GetReport_ReturnType data)
		{
			string text = this.Text = (base.Title = SK.Text("GENERIC_Resources", "Resources"));
			this.img1.Visible = false;
			this.img2.Visible = false;
			this.img3.Visible = false;
			this.img4.Visible = false;
			this.img5.Visible = false;
			this.img6.Visible = false;
			this.img7.Visible = false;
			this.img8.Visible = false;
			this.lblResource1.Visible = false;
			this.lblResource2.Visible = false;
			this.lblResource3.Visible = false;
			this.lblResource4.Visible = false;
			this.lblResource5.Visible = false;
			this.lblResource6.Visible = false;
			this.lblResource7.Visible = false;
			this.lblResource8.Visible = false;
			switch (data.genericData30)
			{
			case 2:
				this.img1.Visible = true;
				this.lblResource1.Visible = true;
				this.img1.BackgroundImage = GFXLibrary.com_32_wood;
				this.lblResource1.Text = data.genericData22.ToString();
				this.img2.Visible = true;
				this.lblResource2.Visible = true;
				this.img2.BackgroundImage = GFXLibrary.com_32_stone;
				this.lblResource2.Text = data.genericData23.ToString();
				this.img3.Visible = true;
				this.lblResource3.Visible = true;
				this.img3.BackgroundImage = GFXLibrary.com_32_iron;
				this.lblResource3.Text = data.genericData24.ToString();
				this.img4.Visible = true;
				this.lblResource4.Visible = true;
				this.img4.BackgroundImage = GFXLibrary.com_32_pitch;
				this.lblResource4.Text = data.genericData25.ToString();
				return;
			case 3:
				break;
			case 4:
				this.img1.Visible = true;
				this.lblResource1.Visible = true;
				this.img1.BackgroundImage = GFXLibrary.com_32_apples;
				this.lblResource1.Text = data.genericData22.ToString();
				this.img2.Visible = true;
				this.lblResource2.Visible = true;
				this.img2.BackgroundImage = GFXLibrary.com_32_bread;
				this.lblResource2.Text = data.genericData23.ToString();
				this.img3.Visible = true;
				this.lblResource3.Visible = true;
				this.img3.BackgroundImage = GFXLibrary.com_32_cheese;
				this.lblResource3.Text = data.genericData24.ToString();
				this.img4.Visible = true;
				this.lblResource4.Visible = true;
				this.img4.BackgroundImage = GFXLibrary.com_32_meat;
				this.lblResource4.Text = data.genericData25.ToString();
				this.img5.Visible = true;
				this.lblResource5.Visible = true;
				this.img5.BackgroundImage = GFXLibrary.com_32_fish;
				this.lblResource5.Text = data.genericData26.ToString();
				this.img6.Visible = true;
				this.lblResource6.Visible = true;
				this.img6.BackgroundImage = GFXLibrary.com_32_veg;
				this.lblResource6.Text = data.genericData27.ToString();
				return;
			case 5:
				this.img1.Visible = true;
				this.lblResource1.Visible = true;
				this.img1.BackgroundImage = GFXLibrary.com_32_furniture;
				this.lblResource1.Text = data.genericData22.ToString();
				this.img2.Visible = true;
				this.lblResource2.Visible = true;
				this.img2.BackgroundImage = GFXLibrary.com_32_clothing;
				this.lblResource2.Text = data.genericData23.ToString();
				this.img3.Visible = true;
				this.lblResource3.Visible = true;
				this.img3.BackgroundImage = GFXLibrary.com_32_venison;
				this.lblResource3.Text = data.genericData24.ToString();
				this.img4.Visible = true;
				this.lblResource4.Visible = true;
				this.img4.BackgroundImage = GFXLibrary.com_32_wine;
				this.lblResource4.Text = data.genericData25.ToString();
				this.img5.Visible = true;
				this.lblResource5.Visible = true;
				this.img5.BackgroundImage = GFXLibrary.com_32_salt;
				this.lblResource5.Text = data.genericData26.ToString();
				this.img6.Visible = true;
				this.lblResource6.Visible = true;
				this.img6.BackgroundImage = GFXLibrary.com_32_metalwork;
				this.lblResource6.Text = data.genericData27.ToString();
				this.img7.Visible = true;
				this.lblResource7.Visible = true;
				this.img7.BackgroundImage = GFXLibrary.com_32_spice;
				this.lblResource7.Text = data.genericData28.ToString();
				this.img8.Visible = true;
				this.lblResource8.Visible = true;
				this.img8.BackgroundImage = GFXLibrary.com_32_silk;
				this.lblResource8.Text = data.genericData29.ToString();
				return;
			case 6:
				this.img1.Visible = true;
				this.lblResource1.Visible = true;
				this.img1.BackgroundImage = GFXLibrary.com_32_ale;
				this.lblResource1.Text = data.genericData22.ToString();
				return;
			case 7:
				this.img1.Visible = true;
				this.lblResource1.Visible = true;
				this.img1.BackgroundImage = GFXLibrary.com_32_bows;
				this.lblResource1.Text = data.genericData22.ToString();
				this.img2.Visible = true;
				this.lblResource2.Visible = true;
				this.img2.BackgroundImage = GFXLibrary.com_32_pikes;
				this.lblResource2.Text = data.genericData23.ToString();
				this.img3.Visible = true;
				this.lblResource3.Visible = true;
				this.img3.BackgroundImage = GFXLibrary.com_32_swords;
				this.lblResource3.Text = data.genericData24.ToString();
				this.img4.Visible = true;
				this.lblResource4.Visible = true;
				this.img4.BackgroundImage = GFXLibrary.com_32_armour;
				this.lblResource4.Text = data.genericData25.ToString();
				this.img5.Visible = true;
				this.lblResource5.Visible = true;
				this.img5.BackgroundImage = GFXLibrary.com_32_catapults;
				this.lblResource5.Text = data.genericData26.ToString();
				break;
			default:
				return;
			}
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x0000B1FC File Offset: 0x000093FC
		private void btnClose_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("ReportsGeneric_close");
			base.Close();
		}
	}
}
