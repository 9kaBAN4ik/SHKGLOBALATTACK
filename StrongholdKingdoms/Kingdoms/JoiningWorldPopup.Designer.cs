namespace Kingdoms
{
	// Token: 0x0200020B RID: 523
	public partial class JoiningWorldPopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x06001632 RID: 5682 RVA: 0x00017855 File Offset: 0x00015A55
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001633 RID: 5683 RVA: 0x0015FCDC File Offset: 0x0015DEDC
		private void InitializeComponent()
		{
			new global::System.ComponentModel.ComponentResourceManager(typeof(global::Kingdoms.JoiningWorldPopup));
			this.label1 = new global::System.Windows.Forms.Label();
			this.lblCounty = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.label1.BackColor = global::ARGBColors.Transparent;
			this.label1.Location = new global::System.Drawing.Point(28, 52);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(305, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Trying to Find Village in";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.lblCounty.BackColor = global::ARGBColors.Transparent;
			this.lblCounty.Location = new global::System.Drawing.Point(28, 76);
			this.lblCounty.Name = "lblCounty";
			this.lblCounty.Size = new global::System.Drawing.Size(305, 20);
			this.lblCounty.TabIndex = 1;
			this.lblCounty.Text = "County";
			this.lblCounty.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.label2.BackColor = global::ARGBColors.Transparent;
			this.label2.Location = new global::System.Drawing.Point(28, 101);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(305, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "Please wait, this may take a few moments.";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(361 * global::Kingdoms.InterfaceMgr.UIScale, 139 * global::Kingdoms.InterfaceMgr.UIScale);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.lblCounty);
			base.Controls.Add(this.label1);
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.Name = "JoiningWorldPopup";
			this.Text = "Finding Village";
			base.Controls.SetChildIndex(this.label1, 0);
			base.Controls.SetChildIndex(this.lblCounty, 0);
			base.Controls.SetChildIndex(this.label2, 0);
			base.ResumeLayout(false);
		}

		// Token: 0x0400267D RID: 9853
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400267E RID: 9854
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400267F RID: 9855
		private global::System.Windows.Forms.Label lblCounty;

		// Token: 0x04002680 RID: 9856
		private global::System.Windows.Forms.Label label2;
	}
}
