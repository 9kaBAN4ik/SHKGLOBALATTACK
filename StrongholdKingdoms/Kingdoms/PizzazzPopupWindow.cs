using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x02000273 RID: 627
	public partial class PizzazzPopupWindow : Form
	{
		// Token: 0x06001BF0 RID: 7152 RVA: 0x0001BA67 File Offset: 0x00019C67
		public PizzazzPopupWindow()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06001BF1 RID: 7153 RVA: 0x001B3718 File Offset: 0x001B1918
		public static void showPizzazzTutorial(int stage)
		{
			int num = -1;
			switch (stage)
			{
			case 2:
				num = 1;
				break;
			case 3:
				num = 2;
				break;
			case 4:
			case 9:
				break;
			case 5:
				num = 3;
				break;
			case 6:
				num = 4;
				break;
			case 7:
				num = 5;
				break;
			case 8:
				num = 6;
				break;
			case 10:
				num = 9;
				break;
			case 11:
				num = 10;
				break;
			case 12:
				num = 2;
				break;
			default:
				if (stage != 102)
				{
					if (stage == 103)
					{
						num = 8;
					}
				}
				else
				{
					num = 7;
				}
				break;
			}
			if (num != -1)
			{
				PizzazzPopupWindow.showPizzazz(num);
			}
		}

		// Token: 0x06001BF2 RID: 7154 RVA: 0x001B37A0 File Offset: 0x001B19A0
		public static void showPizzazz(int pizzazzImage)
		{
			if (PizzazzPopupWindow.Instance == null)
			{
				PizzazzPopupWindow.Instance = new PizzazzPopupWindow();
				PizzazzPopupWindow.Instance.init(pizzazzImage);
				Form parentForm = InterfaceMgr.Instance.ParentForm;
				PizzazzPopupWindow.Instance.Location = new Point(parentForm.Location.X + parentForm.Width / 2 - PizzazzPopupWindow.Instance.Width / 2, parentForm.Location.Y + parentForm.Height / 2 - PizzazzPopupWindow.Instance.Height / 2 - 20);
				PizzazzPopupWindow.Instance.Show(parentForm);
			}
		}

		// Token: 0x06001BF3 RID: 7155 RVA: 0x0001BA8A File Offset: 0x00019C8A
		public static void updatePizzazz()
		{
			if (PizzazzPopupWindow.Instance != null)
			{
				PizzazzPopupWindow.Instance.update();
			}
		}

		// Token: 0x06001BF4 RID: 7156 RVA: 0x0001BA9D File Offset: 0x00019C9D
		public static void closePizzazz()
		{
			if (PizzazzPopupWindow.Instance != null)
			{
				Sound.stopVillageEnvironmentalExceptWorld();
				PizzazzPopupWindow.Instance.Close();
				PizzazzPopupWindow.Instance = null;
			}
		}

		// Token: 0x06001BF5 RID: 7157 RVA: 0x0001BABB File Offset: 0x00019CBB
		public void init(int pizzazzImage)
		{
			this.pizzazzPopupPanel.init(pizzazzImage);
		}

		// Token: 0x06001BF6 RID: 7158 RVA: 0x0001BAC9 File Offset: 0x00019CC9
		public void update()
		{
			this.pizzazzPopupPanel.update();
		}

		// Token: 0x06001BF7 RID: 7159 RVA: 0x0001BAD6 File Offset: 0x00019CD6
		private void pizzazzPopupPanel_MouseClick(object sender, MouseEventArgs e)
		{
			PizzazzPopupWindow.closePizzazz();
		}

		// Token: 0x04002CD8 RID: 11480
		private static PizzazzPopupWindow Instance;
	}
}
