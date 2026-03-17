namespace Kingdoms
{
	// Token: 0x0200048C RID: 1164
	public partial class SharedIPErrorPopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x06002A5C RID: 10844 RVA: 0x0001F24B File Offset: 0x0001D44B
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002A5D RID: 10845 RVA: 0x0020F654 File Offset: 0x0020D854
		private void InitializeComponent()
		{
			this.lblExplanation = new global::System.Windows.Forms.Label();
			this.linkLabelMoreInfo = new global::System.Windows.Forms.LinkLabel();
			this.btnOK = new global::Kingdoms.BitmapButton();
			base.SuspendLayout();
			this.lblExplanation.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.lblExplanation.BackColor = global::ARGBColors.Transparent;
			this.lblExplanation.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblExplanation.Location = new global::System.Drawing.Point(8, 39);
			this.lblExplanation.Name = "lblExplanation";
			this.lblExplanation.Size = new global::System.Drawing.Size(345, 76);
			this.lblExplanation.TabIndex = 0;
			this.lblExplanation.Text = "label1";
			this.linkLabelMoreInfo.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.linkLabelMoreInfo.BackColor = global::ARGBColors.Transparent;
			this.linkLabelMoreInfo.Location = new global::System.Drawing.Point(12, 134);
			this.linkLabelMoreInfo.Name = "linkLabelMoreInfo";
			this.linkLabelMoreInfo.Size = new global::System.Drawing.Size(189, 13);
			this.linkLabelMoreInfo.TabIndex = 3;
			this.linkLabelMoreInfo.TabStop = true;
			this.linkLabelMoreInfo.Text = "Click Here for More Information";
			this.linkLabelMoreInfo.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabelMoreInfo.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelMoreInfo_LinkClicked);
			this.btnOK.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnOK.BackColor = global::System.Drawing.Color.FromArgb(203, 215, 223);
			this.btnOK.Location = new global::System.Drawing.Point(272, 126);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = false;
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(361, 153);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.linkLabelMoreInfo);
			base.Controls.Add(this.lblExplanation);
			base.Name = "SharedIPErrorPopup";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			this.Text = "Shared Connection Detected";
			base.Controls.SetChildIndex(this.lblExplanation, 0);
			base.Controls.SetChildIndex(this.linkLabelMoreInfo, 0);
			base.Controls.SetChildIndex(this.btnOK, 0);
			base.ResumeLayout(false);
		}

		// Token: 0x04003429 RID: 13353
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400342A RID: 13354
		private global::System.Windows.Forms.Label lblExplanation;

		// Token: 0x0400342B RID: 13355
		private global::System.Windows.Forms.LinkLabel linkLabelMoreInfo;

		// Token: 0x0400342C RID: 13356
		private global::Kingdoms.BitmapButton btnOK;
	}
}
