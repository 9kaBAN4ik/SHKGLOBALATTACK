using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x0200019D RID: 413
	public class DockWindow
	{
		// Token: 0x06000FDC RID: 4060 RVA: 0x0001198D File Offset: 0x0000FB8D
		public DockWindow(ContainerControl parent)
		{
			this.parentControl = parent;
		}

		// Token: 0x06000FDD RID: 4061 RVA: 0x00116748 File Offset: 0x00114948
		public void AddControl(UserControl control, int x, int y)
		{
			this.parentControl.SuspendLayout();
			control.Location = new Point(x, y);
			this.parentControl.Controls.Add(control);
			this.parentControl.ResumeLayout(false);
			this.parentControl.PerformLayout();
		}

		// Token: 0x06000FDE RID: 4062 RVA: 0x0001199C File Offset: 0x0000FB9C
		public void RemoveControl(UserControl control)
		{
			this.parentControl.Controls.Remove(control);
		}

		// Token: 0x04001603 RID: 5635
		private ContainerControl parentControl;
	}
}
