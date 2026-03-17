using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x02000476 RID: 1142
	public class ReportTabBar : UserControl, IDockableControl
	{
		// Token: 0x06002957 RID: 10583 RVA: 0x0001E6AC File Offset: 0x0001C8AC
		public ReportTabBar()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
		}

		// Token: 0x06002958 RID: 10584 RVA: 0x0001E6C6 File Offset: 0x0001C8C6
		private void tabPage1_Enter(object sender, EventArgs e)
		{
			InterfaceMgr.Instance.switchReportTabs(0);
		}

		// Token: 0x06002959 RID: 10585 RVA: 0x0001E6D3 File Offset: 0x0001C8D3
		private void tabPage2_Enter(object sender, EventArgs e)
		{
			InterfaceMgr.Instance.switchReportTabs(1);
		}

		// Token: 0x0600295A RID: 10586 RVA: 0x0001E6E0 File Offset: 0x0001C8E0
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x0600295B RID: 10587 RVA: 0x0001E6F0 File Offset: 0x0001C8F0
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x0600295C RID: 10588 RVA: 0x0001E700 File Offset: 0x0001C900
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x0600295D RID: 10589 RVA: 0x0001E712 File Offset: 0x0001C912
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x0600295E RID: 10590 RVA: 0x0001E71F File Offset: 0x0001C91F
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x0600295F RID: 10591 RVA: 0x0001E72D File Offset: 0x0001C92D
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06002960 RID: 10592 RVA: 0x0001E73A File Offset: 0x0001C93A
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06002961 RID: 10593 RVA: 0x0001E747 File Offset: 0x0001C947
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002962 RID: 10594 RVA: 0x001F7D50 File Offset: 0x001F5F50
		private void InitializeComponent()
		{
			this.reportTabControl = new TabControl();
			this.tabPage1 = new TabPage();
			this.tabPage2 = new TabPage();
			this.reportTabControl.SuspendLayout();
			base.SuspendLayout();
			this.reportTabControl.Controls.Add(this.tabPage1);
			this.reportTabControl.Controls.Add(this.tabPage2);
			this.reportTabControl.Location = new Point(0, 13);
			this.reportTabControl.Name = "reportTabControl";
			this.reportTabControl.SelectedIndex = 0;
			this.reportTabControl.Size = new Size(403, 21);
			this.reportTabControl.TabIndex = 0;
			this.tabPage1.Location = new Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new Padding(3);
			this.tabPage1.Size = new Size(395, 0);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Reports";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.tabPage1.Enter += this.tabPage1_Enter;
			this.tabPage2.Location = new Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new Padding(3);
			this.tabPage2.Size = new Size(395, 0);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "History";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.tabPage2.Enter += this.tabPage2_Enter;
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Controls.Add(this.reportTabControl);
			base.Name = "ReportTabBar";
			base.Size = new Size(992, 32);
			this.reportTabControl.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04003265 RID: 12901
		private DockableControl dockableControl;

		// Token: 0x04003266 RID: 12902
		private IContainer components;

		// Token: 0x04003267 RID: 12903
		public TabControl reportTabControl;

		// Token: 0x04003268 RID: 12904
		private TabPage tabPage1;

		// Token: 0x04003269 RID: 12905
		private TabPage tabPage2;
	}
}
