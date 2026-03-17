namespace Kingdoms
{
	// Token: 0x02000241 RID: 577
	public partial class MenuPopup : global::System.Windows.Forms.Form
	{
		// Token: 0x060019A9 RID: 6569 RVA: 0x00019E4C File Offset: 0x0001804C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060019AA RID: 6570 RVA: 0x00199DC4 File Offset: 0x00197FC4
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(1000, 24);
			base.ControlBox = false;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			this.MinimumSize = new global::System.Drawing.Size(10, 10);
			base.Name = "MenuPopup";
			base.Opacity = 0.95;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "MenuPopup";
			base.MouseEnter += new global::System.EventHandler(this.MenuPopup_MouseEnter);
			base.MouseLeave += new global::System.EventHandler(this.MenuPopup_MouseLeave);
			base.ResumeLayout(false);
		}

		// Token: 0x04002A43 RID: 10819
		private global::System.ComponentModel.IContainer components;
	}
}
