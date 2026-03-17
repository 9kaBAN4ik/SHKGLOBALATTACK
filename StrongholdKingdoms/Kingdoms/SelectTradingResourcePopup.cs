using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x02000484 RID: 1156
	public partial class SelectTradingResourcePopup : Form
	{
		// Token: 0x06002A10 RID: 10768 RVA: 0x0001EF12 File Offset: 0x0001D112
		public SelectTradingResourcePopup()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06002A11 RID: 10769 RVA: 0x0001EF35 File Offset: 0x0001D135
		public void init(int currentResource, Point parentLocation, LogoutPanel parent, LogoutOptionsWindow2 parentWindow)
		{
			this.m_parent = parent;
			this.m_parentWindow = parentWindow;
			this.selectTradingResourcePanel.init(currentResource, this, this.m_parent);
			this.updateLocation(parentLocation);
			base.Show(this.m_parentWindow);
		}

		// Token: 0x06002A12 RID: 10770 RVA: 0x001173F0 File Offset: 0x001155F0
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

		// Token: 0x0400339F RID: 13215
		private LogoutPanel m_parent;

		// Token: 0x040033A0 RID: 13216
		private LogoutOptionsWindow2 m_parentWindow;
	}
}
