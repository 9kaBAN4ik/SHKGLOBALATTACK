namespace Kingdoms
{
	// Token: 0x020001D9 RID: 473
	public partial class FloatingInputText : global::System.Windows.Forms.Form
	{
		// Token: 0x060011DA RID: 4570 RVA: 0x00013717 File Offset: 0x00011917
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060011DB RID: 4571 RVA: 0x0012C770 File Offset: 0x0012A970
		private void InitializeComponent()
		{
			this.textBox1 = new global::System.Windows.Forms.TextBox();
			base.SuspendLayout();
			this.textBox1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.textBox1.BackColor = global::System.Drawing.Color.FromArgb(61, 38, 22);
			this.textBox1.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.textBox1.ForeColor = global::System.Drawing.Color.FromArgb(196, 161, 85);
			this.textBox1.Location = new global::System.Drawing.Point(0, 3);
			this.textBox1.MaxLength = 140;
			this.textBox1.Size = new global::System.Drawing.Size(500, 13);
			this.textBox1.TabIndex = 0;
			this.textBox1.TextChanged += new global::System.EventHandler(this.textBox1_TextChanged);
			this.textBox1.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::System.Drawing.Color.FromArgb(61, 38, 22);
			base.ClientSize = new global::System.Drawing.Size(500, 19);
			base.ControlBox = false;
			base.Controls.Add(this.textBox1);
			this.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			this.MaximumSize = new global::System.Drawing.Size(500, 19);
			this.MinimumSize = new global::System.Drawing.Size(500, 19);
			base.Name = "FloatingInputText";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "FloatingInputText";
			base.Deactivate += new global::System.EventHandler(this.FloatingInputText_Deactivate);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400181D RID: 6173
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400181E RID: 6174
		private global::System.Windows.Forms.TextBox textBox1;
	}
}
