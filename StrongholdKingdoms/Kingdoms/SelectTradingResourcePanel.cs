using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x02000483 RID: 1155
	public class SelectTradingResourcePanel : CustomSelfDrawPanel
	{
		// Token: 0x06002A0B RID: 10763 RVA: 0x0001EECE File Offset: 0x0001D0CE
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002A0C RID: 10764 RVA: 0x002079F0 File Offset: 0x00205BF0
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.White;
			base.Name = "SelectTradingResourcePanel";
			base.Size = new Size(600, 55);
			base.ResumeLayout(false);
		}

		// Token: 0x06002A0D RID: 10765 RVA: 0x0001EEED File Offset: 0x0001D0ED
		public SelectTradingResourcePanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06002A0E RID: 10766 RVA: 0x00207A50 File Offset: 0x00205C50
		public void init(int currentResource, SelectTradingResourcePopup parentWindow, LogoutPanel logoutParent)
		{
			this.m_parentWindow = parentWindow;
			this.m_logoutParent = logoutParent;
			base.clearControls();
			int num = 12;
			this.backgroundImage.Size = new Size(624, 324);
			base.addControl(new CustomSelfDrawPanel.CSDFill
			{
				Position = new Point(0, 0),
				Size = new Size(num, this.backgroundImage.Height),
				FillColor = Color.FromArgb(255, 0, 255)
			});
			base.addControl(new CustomSelfDrawPanel.CSDFill
			{
				Position = new Point(this.backgroundImage.Width - num, 0),
				Size = new Size(num, this.backgroundImage.Height),
				FillColor = Color.FromArgb(255, 0, 255)
			});
			base.addControl(new CustomSelfDrawPanel.CSDFill
			{
				Position = new Point(0, 0),
				Size = new Size(this.backgroundImage.Width, num),
				FillColor = Color.FromArgb(255, 0, 255)
			});
			base.addControl(new CustomSelfDrawPanel.CSDFill
			{
				Position = new Point(0, this.backgroundImage.Height - num),
				Size = new Size(this.backgroundImage.Width, num),
				FillColor = Color.FromArgb(255, 0, 255)
			});
			this.backgroundImage.Position = new Point(0, 0);
			base.addControl(this.backgroundImage);
			this.backgroundImage.Create(GFXLibrary.parishwall_solid_rounded_rectangle_tan_upper_left, GFXLibrary.parishwall_solid_rounded_rectangle_tan_upper_middle, GFXLibrary.parishwall_solid_rounded_rectangle_tan_upper_right, GFXLibrary.parishwall_solid_rounded_rectangle_tan_middle_left, GFXLibrary.parishwall_solid_rounded_rectangle_tan_middle_middle, GFXLibrary.parishwall_solid_rounded_rectangle_tan_middle_right, GFXLibrary.parishwall_solid_rounded_rectangle_tan_bottom_left, GFXLibrary.parishwall_solid_rounded_rectangle_tan_bottom_middle, GFXLibrary.parishwall_solid_rounded_rectangle_tan_bottom_right);
			int num2 = 75;
			CustomSelfDrawPanel.ResourceButton resourceButton = new CustomSelfDrawPanel.ResourceButton();
			resourceButton.Position = new Point(num, num);
			resourceButton.init(6, logoutParent);
			this.backgroundImage.addControl(resourceButton);
			CustomSelfDrawPanel.ResourceButton resourceButton2 = new CustomSelfDrawPanel.ResourceButton();
			resourceButton2.Position = new Point(num + num2, num);
			resourceButton2.init(7, logoutParent);
			this.backgroundImage.addControl(resourceButton2);
			CustomSelfDrawPanel.ResourceButton resourceButton3 = new CustomSelfDrawPanel.ResourceButton();
			resourceButton3.Position = new Point(num + num2 * 2, num);
			resourceButton3.init(8, logoutParent);
			this.backgroundImage.addControl(resourceButton3);
			CustomSelfDrawPanel.ResourceButton resourceButton4 = new CustomSelfDrawPanel.ResourceButton();
			resourceButton4.Position = new Point(num + num2 * 3, num);
			resourceButton4.init(9, logoutParent);
			this.backgroundImage.addControl(resourceButton4);
			CustomSelfDrawPanel.ResourceButton resourceButton5 = new CustomSelfDrawPanel.ResourceButton();
			resourceButton5.Position = new Point(num, num + num2);
			resourceButton5.init(13, logoutParent);
			this.backgroundImage.addControl(resourceButton5);
			CustomSelfDrawPanel.ResourceButton resourceButton6 = new CustomSelfDrawPanel.ResourceButton();
			resourceButton6.Position = new Point(num + num2, num + num2);
			resourceButton6.init(17, logoutParent);
			this.backgroundImage.addControl(resourceButton6);
			CustomSelfDrawPanel.ResourceButton resourceButton7 = new CustomSelfDrawPanel.ResourceButton();
			resourceButton7.Position = new Point(num + num2 * 2, num + num2);
			resourceButton7.init(16, logoutParent);
			this.backgroundImage.addControl(resourceButton7);
			CustomSelfDrawPanel.ResourceButton resourceButton8 = new CustomSelfDrawPanel.ResourceButton();
			resourceButton8.Position = new Point(num + num2 * 3, num + num2);
			resourceButton8.init(14, logoutParent);
			this.backgroundImage.addControl(resourceButton8);
			CustomSelfDrawPanel.ResourceButton resourceButton9 = new CustomSelfDrawPanel.ResourceButton();
			resourceButton9.Position = new Point(num + num2 * 4, num + num2);
			resourceButton9.init(15, logoutParent);
			this.backgroundImage.addControl(resourceButton9);
			CustomSelfDrawPanel.ResourceButton resourceButton10 = new CustomSelfDrawPanel.ResourceButton();
			resourceButton10.Position = new Point(num + num2 * 5, num + num2);
			resourceButton10.init(18, logoutParent);
			this.backgroundImage.addControl(resourceButton10);
			CustomSelfDrawPanel.ResourceButton resourceButton11 = new CustomSelfDrawPanel.ResourceButton();
			resourceButton11.Position = new Point(num + num2 * 7, num + num2);
			resourceButton11.init(12, logoutParent);
			this.backgroundImage.addControl(resourceButton11);
			CustomSelfDrawPanel.ResourceButton resourceButton12 = new CustomSelfDrawPanel.ResourceButton();
			resourceButton12.Position = new Point(num, num + num2 * 2);
			resourceButton12.init(22, logoutParent);
			this.backgroundImage.addControl(resourceButton12);
			CustomSelfDrawPanel.ResourceButton resourceButton13 = new CustomSelfDrawPanel.ResourceButton();
			resourceButton13.Position = new Point(num + num2, num + num2 * 2);
			resourceButton13.init(21, logoutParent);
			this.backgroundImage.addControl(resourceButton13);
			CustomSelfDrawPanel.ResourceButton resourceButton14 = new CustomSelfDrawPanel.ResourceButton();
			resourceButton14.Position = new Point(num + num2 * 2, num + num2 * 2);
			resourceButton14.init(26, logoutParent);
			this.backgroundImage.addControl(resourceButton14);
			CustomSelfDrawPanel.ResourceButton resourceButton15 = new CustomSelfDrawPanel.ResourceButton();
			resourceButton15.Position = new Point(num + num2 * 3, num + num2 * 2);
			resourceButton15.init(19, logoutParent);
			this.backgroundImage.addControl(resourceButton15);
			CustomSelfDrawPanel.ResourceButton resourceButton16 = new CustomSelfDrawPanel.ResourceButton();
			resourceButton16.Position = new Point(num + num2 * 4, num + num2 * 2);
			resourceButton16.init(33, logoutParent);
			this.backgroundImage.addControl(resourceButton16);
			CustomSelfDrawPanel.ResourceButton resourceButton17 = new CustomSelfDrawPanel.ResourceButton();
			resourceButton17.Position = new Point(num + num2 * 5, num + num2 * 2);
			resourceButton17.init(23, logoutParent);
			this.backgroundImage.addControl(resourceButton17);
			CustomSelfDrawPanel.ResourceButton resourceButton18 = new CustomSelfDrawPanel.ResourceButton();
			resourceButton18.Position = new Point(num + num2 * 6, num + num2 * 2);
			resourceButton18.init(24, logoutParent);
			this.backgroundImage.addControl(resourceButton18);
			CustomSelfDrawPanel.ResourceButton resourceButton19 = new CustomSelfDrawPanel.ResourceButton();
			resourceButton19.Position = new Point(num + num2 * 7, num + num2 * 2);
			resourceButton19.init(25, logoutParent);
			this.backgroundImage.addControl(resourceButton19);
			CustomSelfDrawPanel.ResourceButton resourceButton20 = new CustomSelfDrawPanel.ResourceButton();
			resourceButton20.Position = new Point(num, num + num2 * 3);
			resourceButton20.init(29, logoutParent);
			this.backgroundImage.addControl(resourceButton20);
			CustomSelfDrawPanel.ResourceButton resourceButton21 = new CustomSelfDrawPanel.ResourceButton();
			resourceButton21.Position = new Point(num + num2, num + num2 * 3);
			resourceButton21.init(28, logoutParent);
			this.backgroundImage.addControl(resourceButton21);
			CustomSelfDrawPanel.ResourceButton resourceButton22 = new CustomSelfDrawPanel.ResourceButton();
			resourceButton22.Position = new Point(num + num2 * 2, num + num2 * 3);
			resourceButton22.init(31, logoutParent);
			this.backgroundImage.addControl(resourceButton22);
			CustomSelfDrawPanel.ResourceButton resourceButton23 = new CustomSelfDrawPanel.ResourceButton();
			resourceButton23.Position = new Point(num + num2 * 3, num + num2 * 3);
			resourceButton23.init(30, logoutParent);
			this.backgroundImage.addControl(resourceButton23);
			CustomSelfDrawPanel.ResourceButton resourceButton24 = new CustomSelfDrawPanel.ResourceButton();
			resourceButton24.Position = new Point(num + num2 * 4, num + num2 * 3);
			resourceButton24.init(32, logoutParent);
			this.backgroundImage.addControl(resourceButton24);
			parentWindow.Size = this.backgroundImage.Size;
			base.Invalidate();
			parentWindow.Invalidate();
		}

		// Token: 0x06002A0F RID: 10767 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x0400339B RID: 13211
		private IContainer components;

		// Token: 0x0400339C RID: 13212
		private CustomSelfDrawPanel.CSDExtendingPanel backgroundImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x0400339D RID: 13213
		private SelectTradingResourcePopup m_parentWindow;

		// Token: 0x0400339E RID: 13214
		private LogoutPanel m_logoutParent;
	}
}
