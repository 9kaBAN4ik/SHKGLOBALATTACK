using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x0200021E RID: 542
	public class MailAttachmentPopup : UserControl, IDockableControl
	{
		// Token: 0x060016D4 RID: 5844 RVA: 0x000180E0 File Offset: 0x000162E0
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent, true);
		}

		// Token: 0x060016D5 RID: 5845 RVA: 0x000180F1 File Offset: 0x000162F1
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x060016D6 RID: 5846 RVA: 0x00018101 File Offset: 0x00016301
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y, true);
		}

		// Token: 0x060016D7 RID: 5847 RVA: 0x00018114 File Offset: 0x00016314
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x060016D8 RID: 5848 RVA: 0x00018121 File Offset: 0x00016321
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x060016D9 RID: 5849 RVA: 0x0001812F File Offset: 0x0001632F
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x060016DA RID: 5850 RVA: 0x0001813C File Offset: 0x0001633C
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x060016DB RID: 5851 RVA: 0x00018149 File Offset: 0x00016349
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060016DC RID: 5852 RVA: 0x0016AE1C File Offset: 0x0016901C
		private void InitializeComponent()
		{
			this.components = new Container();
			this.customPanel = new MailAttachmentPanel();
			this.tbPlayerInput = new TextBox();
			this.tbRegionInput = new TextBox();
			base.AutoScaleMode = AutoScaleMode.Font;
			base.SuspendLayout();
			base.Size = new Size(217 * InterfaceMgr.UIScale, 430 * InterfaceMgr.UIScale);
			this.tbPlayerInput.BackColor = Color.FromArgb(247, 252, 254);
			this.tbPlayerInput.ForeColor = global::ARGBColors.Black;
			this.tbPlayerInput.Location = new Point(27, 85);
			this.tbPlayerInput.MaxLength = 50;
			this.tbPlayerInput.Name = "tbPlayerInput";
			this.tbPlayerInput.Size = new Size(160, 20);
			this.tbPlayerInput.TabIndex = 11;
			this.tbPlayerInput.TextChanged += this.tbFindInput_TextChanged;
			this.tbPlayerInput.KeyUp += this.tbFindInput_KeyUp;
			this.tbPlayerInput.KeyPress += this.tbFindInput_KeyPress;
			this.tbPlayerInput.Visible = false;
			this.tbRegionInput.BackColor = Color.FromArgb(247, 252, 254);
			this.tbRegionInput.ForeColor = global::ARGBColors.Black;
			this.tbRegionInput.Location = new Point(27, 85);
			this.tbRegionInput.MaxLength = 50;
			this.tbRegionInput.Name = "tbRegionInput";
			this.tbRegionInput.Size = new Size(160, 20);
			this.tbRegionInput.TabIndex = 12;
			this.tbRegionInput.TextChanged += this.tbFindInput_TextChanged;
			this.tbRegionInput.KeyUp += this.tbFindInput_KeyUp;
			this.tbRegionInput.KeyPress += this.tbFindInput_KeyPress;
			this.tbRegionInput.Visible = false;
			this.customPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.customPanel.ClickThru = false;
			this.customPanel.Location = new Point(0, 0);
			this.customPanel.Name = "customPanel";
			this.customPanel.PanelActive = true;
			this.customPanel.StoredGraphics = null;
			this.customPanel.TabIndex = 99;
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.BorderStyle = BorderStyle.None;
			base.Name = "ReligiousReportPanel";
			base.Controls.Add(this.tbPlayerInput);
			base.Controls.Add(this.tbRegionInput);
			base.Controls.Add(this.customPanel);
			base.ResumeLayout(false);
		}

		// Token: 0x060016DD RID: 5853 RVA: 0x00018168 File Offset: 0x00016368
		public MailAttachmentPopup(MailScreen mailParent)
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			this.customPanel.init(base.Size, this, mailParent);
		}

		// Token: 0x060016DE RID: 5854 RVA: 0x00018195 File Offset: 0x00016395
		public void clearContents(bool includeLinks)
		{
			if (this.customPanel != null)
			{
				this.customPanel.clearContents(includeLinks);
			}
			this.tbPlayerInput.Text = "";
			this.tbRegionInput.Text = "";
		}

		// Token: 0x060016DF RID: 5855 RVA: 0x000181CB File Offset: 0x000163CB
		public void setReadOnly(bool value)
		{
			if (this.customPanel != null)
			{
				this.customPanel.setReadOnly(value);
			}
		}

		// Token: 0x060016E0 RID: 5856 RVA: 0x000181E1 File Offset: 0x000163E1
		public List<MailLink> getLinks()
		{
			if (this.customPanel == null)
			{
				return new List<MailLink>();
			}
			return this.customPanel.linkList;
		}

		// Token: 0x060016E1 RID: 5857 RVA: 0x000181FC File Offset: 0x000163FC
		public void SetLinks(List<MailLink> inputList, bool readOnly)
		{
			if (this.customPanel != null)
			{
				this.customPanel.linkList = inputList;
				this.customPanel.setReadOnly(readOnly);
				this.customPanel.initCurrentAttachments();
			}
		}

		// Token: 0x060016E2 RID: 5858 RVA: 0x0016B0EC File Offset: 0x001692EC
		public void setTextBoxVisible(int type)
		{
			if (type == 1)
			{
				this.tbPlayerInput.Visible = true;
				this.tbRegionInput.Visible = false;
				return;
			}
			if (type != 3)
			{
				this.tbPlayerInput.Visible = false;
				this.tbRegionInput.Visible = false;
				return;
			}
			this.tbPlayerInput.Visible = false;
			this.tbRegionInput.Visible = true;
		}

		// Token: 0x060016E3 RID: 5859 RVA: 0x00018229 File Offset: 0x00016429
		public void update()
		{
			this.updateSearch();
		}

		// Token: 0x060016E4 RID: 5860 RVA: 0x0016B14C File Offset: 0x0016934C
		private void updateSearch()
		{
			string text = "";
			bool flag = false;
			if (this.tbPlayerInput.Visible)
			{
				text = this.tbPlayerInput.Text;
			}
			else if (this.tbRegionInput.Visible)
			{
				flag = true;
				text = this.tbRegionInput.Text;
			}
			if (this.lastUpdateTime == 0.0)
			{
				return;
			}
			double currentMilliseconds = DXTimer.GetCurrentMilliseconds();
			if (currentMilliseconds - this.lastUpdateTime <= 1000.0)
			{
				return;
			}
			if (text.Length == 0)
			{
				this.lastUpdateTime = 0.0;
				return;
			}
			if (((text.Length != 1 && text.Length != 2) || currentMilliseconds - this.lastUpdateTime <= 2000.0) && text.Length <= 2)
			{
				return;
			}
			this.lastUpdateTime = 0.0;
			if (this.customPanel != null)
			{
				if (flag)
				{
					this.customPanel.searchRegionUpdateCallback(text);
					return;
				}
				this.customPanel.searchPlayerUpdateCallback(text);
			}
		}

		// Token: 0x060016E5 RID: 5861 RVA: 0x00018231 File Offset: 0x00016431
		private void tbFindInput_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				e.Handled = true;
			}
		}

		// Token: 0x060016E6 RID: 5862 RVA: 0x00018244 File Offset: 0x00016444
		private void tbFindInput_KeyUp(object sender, KeyEventArgs e)
		{
			this.lastUpdateTime = DXTimer.GetCurrentMilliseconds();
		}

		// Token: 0x060016E7 RID: 5863 RVA: 0x00018244 File Offset: 0x00016444
		private void tbFindInput_TextChanged(object sender, EventArgs e)
		{
			this.lastUpdateTime = DXTimer.GetCurrentMilliseconds();
		}

		// Token: 0x0400272B RID: 10027
		private DockableControl dockableControl;

		// Token: 0x0400272C RID: 10028
		private IContainer components;

		// Token: 0x0400272D RID: 10029
		private MailAttachmentPanel customPanel;

		// Token: 0x0400272E RID: 10030
		private TextBox tbPlayerInput;

		// Token: 0x0400272F RID: 10031
		private TextBox tbRegionInput;

		// Token: 0x04002730 RID: 10032
		private double lastUpdateTime;
	}
}
