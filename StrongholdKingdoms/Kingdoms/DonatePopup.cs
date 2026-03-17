using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020001A0 RID: 416
	public partial class DonatePopup : Form
	{
		// Token: 0x06000FED RID: 4077 RVA: 0x00011A56 File Offset: 0x0000FC56
		public DonatePopup()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06000FEE RID: 4078 RVA: 0x00011A79 File Offset: 0x0000FC79
		public void setText(ParishWallDetailInfo_ReturnType returnData)
		{
			this.donatePanel.setText(returnData, this);
		}

		// Token: 0x06000FEF RID: 4079 RVA: 0x0011735C File Offset: 0x0011555C
		public void showWindow(bool doShow)
		{
			this.Text = SK.Text("DonatePopup_Donation", "Donation");
			InterfaceMgr.Instance.setCurrentDonatePopup(this);
			if (doShow)
			{
				Form parentForm = InterfaceMgr.Instance.ParentForm;
				base.Show(parentForm);
			}
		}

		// Token: 0x06000FF0 RID: 4080 RVA: 0x001173A0 File Offset: 0x001155A0
		public static void CreateDonatePopup(Point location, ParishWallDetailInfo_ReturnType returnData)
		{
			bool doShow = false;
			DonatePopup donatePopup = InterfaceMgr.Instance.getDonatePopup();
			if (donatePopup == null)
			{
				donatePopup = new DonatePopup();
				doShow = true;
			}
			else if (!donatePopup.Created || !donatePopup.Visible)
			{
				doShow = true;
			}
			donatePopup.setText(returnData);
			donatePopup.updateLocation(location);
			donatePopup.showWindow(doShow);
		}

		// Token: 0x06000FF1 RID: 4081 RVA: 0x001173F0 File Offset: 0x001155F0
		public void updateLocation(Point location)
		{
			int num = location.X;
			int num2 = location.Y - 20;
			Screen screen = Screen.FromPoint(location);
			int num3 = num + base.Width;
			if (num3 > screen.WorkingArea.Width + screen.WorkingArea.X)
			{
				num = screen.WorkingArea.Width + screen.WorkingArea.X - base.Width;
			}
			int num4 = num2 + base.Height;
			if (num4 > screen.WorkingArea.Height + screen.WorkingArea.Y)
			{
				num2 = screen.WorkingArea.Height + screen.WorkingArea.Y - base.Height;
			}
			base.Location = new Point(num, num2);
		}
	}
}
