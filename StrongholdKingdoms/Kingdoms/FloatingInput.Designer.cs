namespace Kingdoms
{
	// Token: 0x020001D8 RID: 472
	public partial class FloatingInput : global::System.Windows.Forms.Form
	{
		// Token: 0x060011CF RID: 4559 RVA: 0x00013633 File Offset: 0x00011833
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060011D0 RID: 4560 RVA: 0x0012C390 File Offset: 0x0012A590
		private void InitializeComponent()
		{
			this.textBox1 = new global::System.Windows.Forms.TextBox();
			base.SuspendLayout();
			this.textBox1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.textBox1.BackColor = global::System.Drawing.Color.FromArgb(61, 38, 22);
			this.textBox1.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.textBox1.ForeColor = global::System.Drawing.Color.FromArgb(196, 161, 85);
			this.textBox1.Location = new global::System.Drawing.Point(0, 3);
			this.textBox1.MaxLength = 10;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new global::System.Drawing.Size(105, 13);
			this.textBox1.TabIndex = 0;
			this.textBox1.TextChanged += new global::System.EventHandler(this.textBox1_TextChanged);
			this.textBox1.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::System.Drawing.Color.FromArgb(61, 38, 22);
			base.ClientSize = new global::System.Drawing.Size(105, 19);
			base.ControlBox = false;
			base.Controls.Add(this.textBox1);
			this.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			this.MaximumSize = new global::System.Drawing.Size(105, 19);
			this.MinimumSize = new global::System.Drawing.Size(105, 19);
			base.Name = "FloatingInput";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "FloatingInput";
			base.Deactivate += new global::System.EventHandler(this.FloatingInput_Deactivate);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04001817 RID: 6167
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04001818 RID: 6168
		private global::System.Windows.Forms.TextBox textBox1;
	}
}
