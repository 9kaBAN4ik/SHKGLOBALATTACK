namespace Kingdoms
{
	// Token: 0x020001DC RID: 476
	public partial class FormationPopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x06001202 RID: 4610 RVA: 0x00013984 File Offset: 0x00011B84
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001203 RID: 4611 RVA: 0x0012EA58 File Offset: 0x0012CC58
		private void InitializeComponent()
		{
			this.customPanel = new global::Kingdoms.FormationPanel();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.txtSelected = new global::System.Windows.Forms.TextBox();
			this.txtSaveName = new global::System.Windows.Forms.TextBox();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.customPanel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.customPanel.ClickThru = false;
			this.customPanel.Location = new global::System.Drawing.Point(0, 34);
			this.customPanel.Name = "customPanel";
			this.customPanel.PanelActive = true;
			this.customPanel.Size = base.Size;
			this.customPanel.StoredGraphics = null;
			this.customPanel.TabIndex = 99;
			this.txtSaveName.BackColor = global::ARGBColors.White;
			this.txtSaveName.ForeColor = global::ARGBColors.Black;
			this.txtSaveName.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSaveName.Name = "txtSaveName";
			this.txtSaveName.Size = new global::System.Drawing.Size(160, 20);
			this.txtSaveName.Location = new global::System.Drawing.Point(36, 381);
			this.txtSaveName.TabIndex = 1;
			this.txtSaveName.TextChanged += new global::System.EventHandler(this.txtSaveName_TextChanged);
			this.txtSaveName.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.txtSaveName_KeyPress);
			this.txtSelected.BackColor = global::ARGBColors.White;
			this.txtSelected.ForeColor = global::ARGBColors.Black;
			this.txtSelected.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSelected.Size = new global::System.Drawing.Size(160, 20);
			this.txtSelected.Location = new global::System.Drawing.Point(270, 381);
			this.txtSelected.Name = "txtSelected";
			this.txtSelected.TabIndex = 23;
			this.pictureBox1.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Center;
			this.pictureBox1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Location = new global::System.Drawing.Point(23, 179);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(235, 150);
			this.pictureBox1.TabIndex = 14;
			this.pictureBox1.TabStop = false;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(700 * global::Kingdoms.InterfaceMgr.UIScale, 450 * global::Kingdoms.InterfaceMgr.UIScale);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.txtSelected);
			base.Controls.Add(this.txtSaveName);
			base.Controls.Add(this.customPanel);
			this.DoubleBuffered = true;
			base.Name = "FormationPopup";
			base.ShowClose = true;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Manage Formations";
			base.TransparencyKey = global::ARGBColors.Fuchsia;
			base.Controls.SetChildIndex(this.txtSaveName, 0);
			base.Controls.SetChildIndex(this.txtSelected, 0);
			base.Controls.SetChildIndex(this.pictureBox1, 0);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04001850 RID: 6224
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04001851 RID: 6225
		private global::System.Windows.Forms.TextBox txtSaveName;

		// Token: 0x04001852 RID: 6226
		private global::System.Windows.Forms.TextBox txtSelected;

		// Token: 0x04001853 RID: 6227
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04001854 RID: 6228
		private global::Kingdoms.FormationPanel customPanel;
	}
}
