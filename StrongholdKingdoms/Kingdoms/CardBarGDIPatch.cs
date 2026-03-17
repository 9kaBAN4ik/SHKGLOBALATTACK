using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x0200010D RID: 269
	public class CardBarGDIPatch : CustomSelfDrawPanel
	{
		// Token: 0x06000893 RID: 2195 RVA: 0x0000D051 File Offset: 0x0000B251
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x000B5990 File Offset: 0x000B3B90
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.None;
			base.Name = "CardBarGDIPatch";
			base.Size = new Size(600, 55);
			base.ResumeLayout(false);
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x0000D070 File Offset: 0x0000B270
		public CardBarGDIPatch()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x0000D089 File Offset: 0x0000B289
		public void init(int cardSection)
		{
			base.clearControls();
			this.cardbar.Position = new Point(0, 0);
			base.addControl(this.cardbar);
			this.cardbar.init(cardSection);
		}

		// Token: 0x06000897 RID: 2199 RVA: 0x0000D0BB File Offset: 0x0000B2BB
		public void update()
		{
			this.cardbar.update();
		}

		// Token: 0x04000C2D RID: 3117
		private IContainer components;

		// Token: 0x04000C2E RID: 3118
		private CardBarGDI cardbar = new CardBarGDI();
	}
}
