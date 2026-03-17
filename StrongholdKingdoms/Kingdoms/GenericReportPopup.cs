using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020001E7 RID: 487
	public class GenericReportPopup : UserControl, IDockableControl
	{
		// Token: 0x060012E8 RID: 4840 RVA: 0x00139AB0 File Offset: 0x00137CB0
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent, false, Color.FromArgb(224, 234, 245), Color.FromArgb(191, 201, 211));
		}

		// Token: 0x060012E9 RID: 4841 RVA: 0x0001425D File Offset: 0x0001245D
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x060012EA RID: 4842 RVA: 0x0001426D File Offset: 0x0001246D
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y, true);
		}

		// Token: 0x060012EB RID: 4843 RVA: 0x00014280 File Offset: 0x00012480
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x060012EC RID: 4844 RVA: 0x0001428D File Offset: 0x0001248D
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x060012ED RID: 4845 RVA: 0x0001429B File Offset: 0x0001249B
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x060012EE RID: 4846 RVA: 0x000142A8 File Offset: 0x000124A8
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x060012EF RID: 4847 RVA: 0x000142B5 File Offset: 0x000124B5
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060012F0 RID: 4848 RVA: 0x00139AF4 File Offset: 0x00137CF4
		private void InitializeComponent(GenericReportPanelBasic contentPanel)
		{
			if (contentPanel == null)
			{
				this.customPanel = new GenericReportPanelBasic();
			}
			else
			{
				this.customPanel = contentPanel;
			}
			base.Size = this.customPanel.Size;
			base.SuspendLayout();
			this.customPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.customPanel.ClickThru = false;
			this.customPanel.Location = new Point(0, 2);
			this.customPanel.Name = "customPanel";
			this.customPanel.PanelActive = true;
			this.customPanel.StoredGraphics = null;
			this.customPanel.TabIndex = 99;
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.BorderStyle = BorderStyle.None;
			base.Name = "ReligiousReportPanel";
			this.customPanel.Size = base.Size;
			base.Controls.Add(this.customPanel);
			base.ResumeLayout(false);
		}

		// Token: 0x060012F1 RID: 4849 RVA: 0x000142D4 File Offset: 0x000124D4
		public GenericReportPopup()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent(null);
		}

		// Token: 0x060012F2 RID: 4850 RVA: 0x000142EF File Offset: 0x000124EF
		public GenericReportPopup(GenericReportPanelBasic contentPanel)
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent(contentPanel);
		}

		// Token: 0x060012F3 RID: 4851 RVA: 0x0001430A File Offset: 0x0001250A
		public void setData(GetReport_ReturnType returnData)
		{
			this.customPanel.init(this, base.Size, null);
			this.customPanel.setData(returnData);
		}

		// Token: 0x04001967 RID: 6503
		private DockableControl dockableControl;

		// Token: 0x04001968 RID: 6504
		private IContainer components;

		// Token: 0x04001969 RID: 6505
		private Panel panel1;

		// Token: 0x0400196A RID: 6506
		private GenericReportPanelBasic customPanel;
	}
}
