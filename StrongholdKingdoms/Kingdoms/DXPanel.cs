using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x020001A2 RID: 418
	public class DXPanel : Panel
	{
		// Token: 0x06000FFB RID: 4091 RVA: 0x00011B6E File Offset: 0x0000FD6E
		public DXPanel()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.Opaque | ControlStyles.AllPaintingInWmPaint, true);
			this.BackColor = global::ARGBColors.Black;
			this.resizing = false;
		}

		// Token: 0x06000FFC RID: 4092 RVA: 0x001175D8 File Offset: 0x001157D8
		protected override void OnPaint(PaintEventArgs e)
		{
			if (GameEngine.Instance != null)
			{
				if (!DXPanel.skipPaint && this.allowDraw)
				{
					this.allowDraw = false;
					GameEngine.Instance.OnPaintCallback();
				}
				DXPanel.skipPaint = false;
				return;
			}
			Pen pen = new Pen(global::ARGBColors.Black);
			e.Graphics.DrawRectangle(pen, e.ClipRectangle);
			pen.Dispose();
		}

		// Token: 0x06000FFD RID: 4093 RVA: 0x00011B94 File Offset: 0x0000FD94
		public void AllowDraw()
		{
			this.allowDraw = true;
		}

		// Token: 0x06000FFE RID: 4094 RVA: 0x00007CE0 File Offset: 0x00005EE0
		protected override void OnResize(EventArgs e)
		{
		}

		// Token: 0x06000FFF RID: 4095 RVA: 0x00117638 File Offset: 0x00115838
		protected override void OnSizeChanged(EventArgs e)
		{
			if (base.Size.Width != 0 && base.Size.Height != 0)
			{
				if (base.Visible)
				{
					base.Visible = false;
					base.OnSizeChanged(e);
					base.Visible = true;
					return;
				}
				base.OnSizeChanged(e);
			}
		}

		// Token: 0x04001614 RID: 5652
		public bool resizing;

		// Token: 0x04001615 RID: 5653
		public bool allowDraw;

		// Token: 0x04001616 RID: 5654
		public static bool skipPaint;
	}
}
