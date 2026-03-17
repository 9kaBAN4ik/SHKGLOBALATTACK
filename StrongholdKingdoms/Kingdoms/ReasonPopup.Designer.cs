namespace Kingdoms
{
	// Token: 0x020002B1 RID: 689
	public partial class ReasonPopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x06001EDE RID: 7902 RVA: 0x0001D66E File Offset: 0x0001B86E
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001EDF RID: 7903 RVA: 0x001DC1DC File Offset: 0x001DA3DC
		private void InitializeComponent()
		{
			new global::System.ComponentModel.ComponentResourceManager(typeof(global::Kingdoms.ReasonPopup));
			this.btnOK = new global::Kingdoms.BitmapButton();
			this.btnCancel = new global::Kingdoms.BitmapButton();
			this.tbReason = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.btnOK.BackColor = global::System.Drawing.Color.FromArgb(203, 215, 223);
			this.btnOK.Location = new global::System.Drawing.Point(272, 124);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = false;
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.btnCancel.BackColor = global::System.Drawing.Color.FromArgb(203, 215, 223);
			this.btnCancel.Location = new global::System.Drawing.Point(20, 124);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.tbReason.BackColor = global::System.Drawing.Color.FromArgb(235, 240, 243);
			this.tbReason.Location = new global::System.Drawing.Point(31, 64);
			this.tbReason.Multiline = true;
			this.tbReason.Name = "tbReason";
			this.tbReason.Size = new global::System.Drawing.Size(303, 46);
			this.tbReason.TabIndex = 0;
			this.label1.AutoSize = true;
			this.label1.BackColor = global::ARGBColors.Transparent;
			this.label1.Location = new global::System.Drawing.Point(20, 40);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(142, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Enter Reason For this Action";
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(361, 158);
			base.ControlBox = false;
			base.Controls.Add(this.label1);
			base.Controls.Add(this.tbReason);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.Name = "ReasonPopup";
			base.ShowIcon = false;
			this.Text = "Reason";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04002FC4 RID: 12228
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04002FC5 RID: 12229
		private global::Kingdoms.BitmapButton btnOK;

		// Token: 0x04002FC6 RID: 12230
		private global::Kingdoms.BitmapButton btnCancel;

		// Token: 0x04002FC7 RID: 12231
		private global::System.Windows.Forms.TextBox tbReason;

		// Token: 0x04002FC8 RID: 12232
		private global::System.Windows.Forms.Label label1;
	}
}
