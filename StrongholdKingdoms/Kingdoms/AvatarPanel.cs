using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020000DA RID: 218
	public class AvatarPanel : UserControl
	{
		// Token: 0x0600065B RID: 1627 RVA: 0x0000B58E File Offset: 0x0000978E
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x0000B5AD File Offset: 0x000097AD
		private void InitializeComponent()
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x0000B5B6 File Offset: 0x000097B6
		public AvatarPanel()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x0000B5D6 File Offset: 0x000097D6
		public void update(AvatarData data)
		{
			this.avatarData = data;
			this.forceRedraw = true;
			this.Refresh();
		}

		// Token: 0x0600065F RID: 1631 RVA: 0x00083F88 File Offset: 0x00082188
		protected override void OnPaint(PaintEventArgs e)
		{
			if (this._backBuffer == null || this.forceRedraw)
			{
				if (this._backBuffer == null)
				{
					this._backBuffer = new Bitmap(154, 500);
				}
				this.forceRedraw = false;
				Avatar.CreateAvatar(this.avatarData, this._backBuffer);
			}
			if (e != null)
			{
				e.Graphics.DrawImageUnscaled(this._backBuffer, 0, 0);
			}
		}

		// Token: 0x06000660 RID: 1632 RVA: 0x00007CE0 File Offset: 0x00005EE0
		protected override void OnPaintBackground(PaintEventArgs e)
		{
		}

		// Token: 0x04000855 RID: 2133
		private IContainer components;

		// Token: 0x04000856 RID: 2134
		public AvatarData avatarData = new AvatarData();

		// Token: 0x04000857 RID: 2135
		private Bitmap _backBuffer;

		// Token: 0x04000858 RID: 2136
		public bool forceRedraw = true;
	}
}
