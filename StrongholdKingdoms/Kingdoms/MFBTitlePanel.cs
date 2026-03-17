using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x02000244 RID: 580
	public class MFBTitlePanel : CustomSelfDrawPanel
	{
		// Token: 0x060019B3 RID: 6579 RVA: 0x00019E6B File Offset: 0x0001806B
		public MFBTitlePanel()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x060019B4 RID: 6580 RVA: 0x00199E74 File Offset: 0x00198074
		public void init(int width)
		{
			if (width != this.lastWidth && GFXLibrary.messageboxtop_left != null)
			{
				this.lastWidth = width;
				base.SuspendLayout();
				base.AutoScaleMode = AutoScaleMode.None;
				this.BackColor = global::ARGBColors.Transparent;
				base.Size = new Size(width, 30);
				base.ResumeLayout(false);
				base.clearControls();
				CustomSelfDrawPanel.CSDHorzExtendingPanel csdhorzExtendingPanel = new CustomSelfDrawPanel.CSDHorzExtendingPanel();
				csdhorzExtendingPanel.Position = new Point(0, 0);
				csdhorzExtendingPanel.Size = new Size(width, 30);
				base.addControl(csdhorzExtendingPanel);
				csdhorzExtendingPanel.Create(GFXLibrary.messageboxtop_left, GFXLibrary.messageboxtop_middle, GFXLibrary.messageboxtop_right);
			}
		}

		// Token: 0x04002A44 RID: 10820
		private int lastWidth = -1;
	}
}
