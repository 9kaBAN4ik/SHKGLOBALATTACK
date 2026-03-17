namespace Kingdoms
{
	// Token: 0x02000214 RID: 532
	public partial class LoginHistoryPopup : global::System.Windows.Forms.Form
	{
		// Token: 0x0600165D RID: 5725 RVA: 0x00017AEC File Offset: 0x00015CEC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600165E RID: 5726 RVA: 0x001608CC File Offset: 0x0015EACC
		private void InitializeComponent()
		{
			this.btnClose = new global::System.Windows.Forms.Button();
			this.pnlList = new global::System.Windows.Forms.Panel();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.btnClose.Location = new global::System.Drawing.Point(368, 352);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.pnlList.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.pnlList.AutoScroll = true;
			this.pnlList.BackColor = global::ARGBColors.White;
			this.pnlList.Location = new global::System.Drawing.Point(12, 37);
			this.pnlList.Name = "pnlList";
			this.pnlList.Size = new global::System.Drawing.Size(431, 300);
			this.pnlList.TabIndex = 1;
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(12, 21);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(58, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "IP Address";
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(121, 21);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(59, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Login Time";
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(365, 21);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(47, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Duration";
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(455, 387);
			base.ControlBox = false;
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.pnlList);
			base.Controls.Add(this.btnClose);
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.Name = "LoginHistoryPopup";
			this.Text = "Login History";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400269F RID: 9887
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040026A0 RID: 9888
		private global::System.Windows.Forms.Button btnClose;

		// Token: 0x040026A1 RID: 9889
		private global::System.Windows.Forms.Panel pnlList;

		// Token: 0x040026A2 RID: 9890
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040026A3 RID: 9891
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040026A4 RID: 9892
		private global::System.Windows.Forms.Label label3;
	}
}
