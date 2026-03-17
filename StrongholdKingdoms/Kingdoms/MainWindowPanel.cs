using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x02000232 RID: 562
	public class MainWindowPanel : UserControl, IDockWindow
	{
		// Token: 0x06001897 RID: 6295 RVA: 0x000194A5 File Offset: 0x000176A5
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001898 RID: 6296 RVA: 0x0018278C File Offset: 0x0018098C
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Black;
			base.Name = "MainWindowPanel";
			base.Size = new Size(439, 407);
			base.ResumeLayout(false);
		}

		// Token: 0x06001899 RID: 6297 RVA: 0x000194C4 File Offset: 0x000176C4
		public void AddControl(UserControl control, int x, int y)
		{
			this.dockWindow.AddControl(control, x, y);
		}

		// Token: 0x0600189A RID: 6298 RVA: 0x000194D4 File Offset: 0x000176D4
		public void RemoveControl(UserControl control)
		{
			this.dockWindow.RemoveControl(control);
		}

		// Token: 0x0600189B RID: 6299 RVA: 0x000194E2 File Offset: 0x000176E2
		public MainWindowPanel()
		{
			this.dockWindow = new DockWindow(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint, true);
		}

		// Token: 0x0600189C RID: 6300 RVA: 0x0001950B File Offset: 0x0001770B
		public void doDraw(bool allowDraw)
		{
			this.m_allowDraw = allowDraw;
		}

		// Token: 0x0600189D RID: 6301 RVA: 0x00007CE0 File Offset: 0x00005EE0
		protected override void OnPaint(PaintEventArgs e)
		{
		}

		// Token: 0x0600189E RID: 6302 RVA: 0x00019514 File Offset: 0x00017714
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			if (this.m_allowDraw)
			{
				base.OnPaintBackground(e);
			}
		}

		// Token: 0x040028F5 RID: 10485
		private IContainer components;

		// Token: 0x040028F6 RID: 10486
		private DockWindow dockWindow;

		// Token: 0x040028F7 RID: 10487
		private bool m_allowDraw = true;
	}
}
