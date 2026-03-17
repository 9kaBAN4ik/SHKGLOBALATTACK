namespace Kingdoms
{
	// Token: 0x02000212 RID: 530
	public partial class LoggingOutPopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x06001653 RID: 5715 RVA: 0x00017A3B File Offset: 0x00015C3B
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001654 RID: 5716 RVA: 0x001604F4 File Offset: 0x0015E6F4
		private void InitializeComponent()
		{
			this.label1 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.label1.BackColor = global::ARGBColors.Transparent;
			this.label1.Location = new global::System.Drawing.Point(55, 37);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(250, 35);
			this.label1.TabIndex = 0;
			this.label1.Text = "Please wait....";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(361, 80);
			base.Controls.Add(this.label1);
			base.Name = "LoggingOutPopup";
			this.Text = "Logging Out";
			base.TopMost = true;
			base.Controls.SetChildIndex(this.label1, 0);
			base.ResumeLayout(false);
		}

		// Token: 0x04002698 RID: 9880
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04002699 RID: 9881
		private global::System.Windows.Forms.Label label1;
	}
}
