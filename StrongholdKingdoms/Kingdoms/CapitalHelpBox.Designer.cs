namespace Kingdoms
{
	// Token: 0x02000104 RID: 260
	public partial class CapitalHelpBox : global::Kingdoms.MyFormBase
	{
		// Token: 0x0600080D RID: 2061 RVA: 0x0000CAC2 File Offset: 0x0000ACC2
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600080E RID: 2062 RVA: 0x000AAFE8 File Offset: 0x000A91E8
		private void InitializeComponent()
		{
			new global::System.ComponentModel.ComponentResourceManager(typeof(global::Kingdoms.CapitalHelpBox));
			this.btnClose = new global::System.Windows.Forms.Button();
			this.lblBuildingType = new global::System.Windows.Forms.Label();
			this.lblHelpText = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.btnClose.BackColor = global::System.Drawing.Color.FromArgb(203, 215, 223);
			this.btnClose.Location = new global::System.Drawing.Point(274, 239);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.lblBuildingType.BackColor = global::ARGBColors.Transparent;
			this.lblBuildingType.Location = new global::System.Drawing.Point(13, 46);
			this.lblBuildingType.Name = "lblBuildingType";
			this.lblBuildingType.Size = new global::System.Drawing.Size(335, 22);
			this.lblBuildingType.TabIndex = 1;
			this.lblBuildingType.Text = "label1";
			this.lblHelpText.BackColor = global::ARGBColors.Transparent;
			this.lblHelpText.Location = new global::System.Drawing.Point(13, 82);
			this.lblHelpText.Name = "lblHelpText";
			this.lblHelpText.Size = new global::System.Drawing.Size(335, 144);
			this.lblHelpText.TabIndex = 2;
			this.lblHelpText.Text = "label2";
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(361 * global::Kingdoms.InterfaceMgr.UIScale, 274 * global::Kingdoms.InterfaceMgr.UIScale);
			base.Controls.Add(this.lblHelpText);
			base.Controls.Add(this.lblBuildingType);
			base.Controls.Add(this.btnClose);
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "CapitalHelpBox";
			base.ShowClose = false;
			base.ShowIcon = false;
			this.Text = "Help";
			base.Controls.SetChildIndex(this.btnClose, 0);
			base.Controls.SetChildIndex(this.lblBuildingType, 0);
			base.Controls.SetChildIndex(this.lblHelpText, 0);
			base.ResumeLayout(false);
		}

		// Token: 0x04000B58 RID: 2904
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000B59 RID: 2905
		private global::System.Windows.Forms.Button btnClose;

		// Token: 0x04000B5A RID: 2906
		private global::System.Windows.Forms.Label lblBuildingType;

		// Token: 0x04000B5B RID: 2907
		private global::System.Windows.Forms.Label lblHelpText;
	}
}
