namespace Kingdoms
{
	// Token: 0x020002B4 RID: 692
	public partial class ReinforcementsRetrievalPopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x06001EF7 RID: 7927 RVA: 0x0001D788 File Offset: 0x0001B988
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001EF8 RID: 7928 RVA: 0x001DCDFC File Offset: 0x001DAFFC
		private void InitializeComponent()
		{
			this.btnRetrieve = new global::Kingdoms.BitmapButton();
			this.btnAll = new global::Kingdoms.BitmapButton();
			this.btnCancel = new global::Kingdoms.BitmapButton();
			this.tbPeasants = new global::System.Windows.Forms.TrackBar();
			this.lblPeasants = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.lblArchers = new global::System.Windows.Forms.Label();
			this.tbArchers = new global::System.Windows.Forms.TrackBar();
			this.label5 = new global::System.Windows.Forms.Label();
			this.lblPikemen = new global::System.Windows.Forms.Label();
			this.tbPikemen = new global::System.Windows.Forms.TrackBar();
			this.label7 = new global::System.Windows.Forms.Label();
			this.lblSwordsmen = new global::System.Windows.Forms.Label();
			this.tbSwordsmen = new global::System.Windows.Forms.TrackBar();
			this.label9 = new global::System.Windows.Forms.Label();
			this.lblCatapults = new global::System.Windows.Forms.Label();
			this.tbCatapults = new global::System.Windows.Forms.TrackBar();
			((global::System.ComponentModel.ISupportInitialize)this.tbPeasants).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.tbArchers).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.tbPikemen).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.tbSwordsmen).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.tbCatapults).BeginInit();
			base.SuspendLayout();
			this.btnRetrieve.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.btnRetrieve.BorderColor = global::ARGBColors.DarkBlue;
			this.btnRetrieve.BorderDrawing = true;
			this.btnRetrieve.FocusRectangleEnabled = false;
			this.btnRetrieve.Image = null;
			this.btnRetrieve.ImageBorderColor = global::ARGBColors.Chocolate;
			this.btnRetrieve.ImageBorderEnabled = true;
			this.btnRetrieve.ImageDropShadow = true;
			this.btnRetrieve.ImageFocused = null;
			this.btnRetrieve.ImageInactive = null;
			this.btnRetrieve.ImageMouseOver = null;
			this.btnRetrieve.ImageNormal = null;
			this.btnRetrieve.ImagePressed = null;
			this.btnRetrieve.InnerBorderColor = global::ARGBColors.LightGray;
			this.btnRetrieve.InnerBorderColor_Focus = global::ARGBColors.LightBlue;
			this.btnRetrieve.InnerBorderColor_MouseOver = global::ARGBColors.Gold;
			this.btnRetrieve.Location = new global::System.Drawing.Point(268, 323);
			this.btnRetrieve.Name = "btnRetrieve";
			this.btnRetrieve.OffsetPressedContent = true;
			this.btnRetrieve.Padding2 = 5;
			this.btnRetrieve.Size = new global::System.Drawing.Size(90, 30);
			this.btnRetrieve.StretchImage = false;
			this.btnRetrieve.TabIndex = 56;
			this.btnRetrieve.Text = "Retrieve";
			this.btnRetrieve.TextDropShadow = false;
			this.btnRetrieve.UseVisualStyleBackColor = true;
			this.btnRetrieve.Click += new global::System.EventHandler(this.btnRetrieve_Click);
			this.btnAll.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.btnAll.BorderColor = global::ARGBColors.DarkBlue;
			this.btnAll.BorderDrawing = true;
			this.btnAll.FocusRectangleEnabled = false;
			this.btnAll.Image = null;
			this.btnAll.ImageBorderColor = global::ARGBColors.Chocolate;
			this.btnAll.ImageBorderEnabled = true;
			this.btnAll.ImageDropShadow = true;
			this.btnAll.ImageFocused = null;
			this.btnAll.ImageInactive = null;
			this.btnAll.ImageMouseOver = null;
			this.btnAll.ImageNormal = null;
			this.btnAll.ImagePressed = null;
			this.btnAll.InnerBorderColor = global::ARGBColors.LightGray;
			this.btnAll.InnerBorderColor_Focus = global::ARGBColors.LightBlue;
			this.btnAll.InnerBorderColor_MouseOver = global::ARGBColors.Gold;
			this.btnAll.Location = new global::System.Drawing.Point(140, 323);
			this.btnAll.Name = "btnAll";
			this.btnAll.OffsetPressedContent = true;
			this.btnAll.Padding2 = 5;
			this.btnAll.Size = new global::System.Drawing.Size(90, 30);
			this.btnAll.StretchImage = false;
			this.btnAll.TabIndex = 57;
			this.btnAll.Text = "Select All";
			this.btnAll.TextDropShadow = false;
			this.btnAll.UseVisualStyleBackColor = true;
			this.btnAll.Click += new global::System.EventHandler(this.btnAll_Click);
			this.btnCancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.btnCancel.BorderColor = global::ARGBColors.DarkBlue;
			this.btnCancel.BorderDrawing = true;
			this.btnCancel.FocusRectangleEnabled = false;
			this.btnCancel.Image = null;
			this.btnCancel.ImageBorderColor = global::ARGBColors.Chocolate;
			this.btnCancel.ImageBorderEnabled = true;
			this.btnCancel.ImageDropShadow = true;
			this.btnCancel.ImageFocused = null;
			this.btnCancel.ImageInactive = null;
			this.btnCancel.ImageMouseOver = null;
			this.btnCancel.ImageNormal = null;
			this.btnCancel.ImagePressed = null;
			this.btnCancel.InnerBorderColor = global::ARGBColors.LightGray;
			this.btnCancel.InnerBorderColor_Focus = global::ARGBColors.LightBlue;
			this.btnCancel.InnerBorderColor_MouseOver = global::ARGBColors.Gold;
			this.btnCancel.Location = new global::System.Drawing.Point(12, 323);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.OffsetPressedContent = true;
			this.btnCancel.Padding2 = 5;
			this.btnCancel.Size = new global::System.Drawing.Size(90, 30);
			this.btnCancel.StretchImage = false;
			this.btnCancel.TabIndex = 58;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.TextDropShadow = false;
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.tbPeasants.BackColor = global::System.Drawing.Color.FromArgb(99, 112, 121);
			this.tbPeasants.Location = new global::System.Drawing.Point(80, 43);
			this.tbPeasants.Name = "tbPeasants";
			this.tbPeasants.Size = new global::System.Drawing.Size(198, 45);
			this.tbPeasants.TabIndex = 59;
			this.tbPeasants.ValueChanged += new global::System.EventHandler(this.tbPeasants_ValueChanged);
			this.lblPeasants.BackColor = global::ARGBColors.Transparent;
			this.lblPeasants.Location = new global::System.Drawing.Point(276, 60);
			this.lblPeasants.Name = "lblPeasants";
			this.lblPeasants.Size = new global::System.Drawing.Size(82, 28);
			this.lblPeasants.TabIndex = 60;
			this.lblPeasants.Text = "0/0";
			this.lblPeasants.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label2.AutoSize = true;
			this.label2.BackColor = global::ARGBColors.Transparent;
			this.label2.Location = new global::System.Drawing.Point(12, 60);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(51, 13);
			this.label2.TabIndex = 61;
			this.label2.Text = "Peasants";
			this.label3.AutoSize = true;
			this.label3.BackColor = global::ARGBColors.Transparent;
			this.label3.Location = new global::System.Drawing.Point(12, 111);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(43, 13);
			this.label3.TabIndex = 64;
			this.label3.Text = "Archers";
			this.lblArchers.BackColor = global::ARGBColors.Transparent;
			this.lblArchers.Location = new global::System.Drawing.Point(276, 111);
			this.lblArchers.Name = "lblArchers";
			this.lblArchers.Size = new global::System.Drawing.Size(82, 28);
			this.lblArchers.TabIndex = 63;
			this.lblArchers.Text = "0/0";
			this.lblArchers.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.tbArchers.BackColor = global::System.Drawing.Color.FromArgb(109, 124, 133);
			this.tbArchers.Location = new global::System.Drawing.Point(80, 94);
			this.tbArchers.Name = "tbArchers";
			this.tbArchers.Size = new global::System.Drawing.Size(198, 45);
			this.tbArchers.TabIndex = 62;
			this.tbArchers.ValueChanged += new global::System.EventHandler(this.tbArchers_ValueChanged);
			this.label5.AutoSize = true;
			this.label5.BackColor = global::ARGBColors.Transparent;
			this.label5.Location = new global::System.Drawing.Point(12, 162);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(48, 13);
			this.label5.TabIndex = 67;
			this.label5.Text = "Pikemen";
			this.lblPikemen.BackColor = global::ARGBColors.Transparent;
			this.lblPikemen.Location = new global::System.Drawing.Point(276, 162);
			this.lblPikemen.Name = "lblPikemen";
			this.lblPikemen.Size = new global::System.Drawing.Size(82, 28);
			this.lblPikemen.TabIndex = 66;
			this.lblPikemen.Text = "0/0";
			this.lblPikemen.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.tbPikemen.BackColor = global::System.Drawing.Color.FromArgb(121, 137, 148);
			this.tbPikemen.Location = new global::System.Drawing.Point(80, 145);
			this.tbPikemen.Name = "tbPikemen";
			this.tbPikemen.Size = new global::System.Drawing.Size(198, 45);
			this.tbPikemen.TabIndex = 65;
			this.tbPikemen.ValueChanged += new global::System.EventHandler(this.tbPikemen_ValueChanged);
			this.label7.AutoSize = true;
			this.label7.BackColor = global::ARGBColors.Transparent;
			this.label7.Location = new global::System.Drawing.Point(12, 213);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(62, 13);
			this.label7.TabIndex = 70;
			this.label7.Text = "Swordsmen";
			this.lblSwordsmen.BackColor = global::ARGBColors.Transparent;
			this.lblSwordsmen.Location = new global::System.Drawing.Point(276, 213);
			this.lblSwordsmen.Name = "lblSwordsmen";
			this.lblSwordsmen.Size = new global::System.Drawing.Size(82, 28);
			this.lblSwordsmen.TabIndex = 69;
			this.lblSwordsmen.Text = "0/0";
			this.lblSwordsmen.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.tbSwordsmen.BackColor = global::System.Drawing.Color.FromArgb(130, 147, 158);
			this.tbSwordsmen.Location = new global::System.Drawing.Point(80, 196);
			this.tbSwordsmen.Name = "tbSwordsmen";
			this.tbSwordsmen.Size = new global::System.Drawing.Size(198, 45);
			this.tbSwordsmen.TabIndex = 68;
			this.tbSwordsmen.ValueChanged += new global::System.EventHandler(this.tbSwordsmen_ValueChanged);
			this.label9.AutoSize = true;
			this.label9.BackColor = global::ARGBColors.Transparent;
			this.label9.Location = new global::System.Drawing.Point(12, 264);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(51, 13);
			this.label9.TabIndex = 73;
			this.label9.Text = "Catapults";
			this.lblCatapults.BackColor = global::ARGBColors.Transparent;
			this.lblCatapults.Location = new global::System.Drawing.Point(276, 264);
			this.lblCatapults.Name = "lblCatapults";
			this.lblCatapults.Size = new global::System.Drawing.Size(82, 28);
			this.lblCatapults.TabIndex = 72;
			this.lblCatapults.Text = "0/0";
			this.lblCatapults.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.tbCatapults.BackColor = global::System.Drawing.Color.FromArgb(140, 159, 170);
			this.tbCatapults.Location = new global::System.Drawing.Point(80, 247);
			this.tbCatapults.Name = "tbCatapults";
			this.tbCatapults.Size = new global::System.Drawing.Size(198, 45);
			this.tbCatapults.TabIndex = 71;
			this.tbCatapults.ValueChanged += new global::System.EventHandler(this.tbCatapults_ValueChanged);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(370, 365);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.lblCatapults);
			base.Controls.Add(this.tbCatapults);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.lblSwordsmen);
			base.Controls.Add(this.tbSwordsmen);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.lblPikemen);
			base.Controls.Add(this.tbPikemen);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.lblArchers);
			base.Controls.Add(this.tbArchers);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.lblPeasants);
			base.Controls.Add(this.tbPeasants);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnAll);
			base.Controls.Add(this.btnRetrieve);
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.Name = "ReinforcementsRetrievalPopup";
			base.ShowClose = true;
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Retrieve Reinforcements";
			base.Controls.SetChildIndex(this.btnRetrieve, 0);
			base.Controls.SetChildIndex(this.btnAll, 0);
			base.Controls.SetChildIndex(this.btnCancel, 0);
			base.Controls.SetChildIndex(this.tbPeasants, 0);
			base.Controls.SetChildIndex(this.lblPeasants, 0);
			base.Controls.SetChildIndex(this.label2, 0);
			base.Controls.SetChildIndex(this.tbArchers, 0);
			base.Controls.SetChildIndex(this.lblArchers, 0);
			base.Controls.SetChildIndex(this.label3, 0);
			base.Controls.SetChildIndex(this.tbPikemen, 0);
			base.Controls.SetChildIndex(this.lblPikemen, 0);
			base.Controls.SetChildIndex(this.label5, 0);
			base.Controls.SetChildIndex(this.tbSwordsmen, 0);
			base.Controls.SetChildIndex(this.lblSwordsmen, 0);
			base.Controls.SetChildIndex(this.label7, 0);
			base.Controls.SetChildIndex(this.tbCatapults, 0);
			base.Controls.SetChildIndex(this.lblCatapults, 0);
			base.Controls.SetChildIndex(this.label9, 0);
			((global::System.ComponentModel.ISupportInitialize)this.tbPeasants).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.tbArchers).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.tbPikemen).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.tbSwordsmen).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.tbCatapults).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04002FD7 RID: 12247
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04002FD8 RID: 12248
		private global::Kingdoms.BitmapButton btnRetrieve;

		// Token: 0x04002FD9 RID: 12249
		private global::Kingdoms.BitmapButton btnAll;

		// Token: 0x04002FDA RID: 12250
		private global::Kingdoms.BitmapButton btnCancel;

		// Token: 0x04002FDB RID: 12251
		private global::System.Windows.Forms.TrackBar tbPeasants;

		// Token: 0x04002FDC RID: 12252
		private global::System.Windows.Forms.Label lblPeasants;

		// Token: 0x04002FDD RID: 12253
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04002FDE RID: 12254
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04002FDF RID: 12255
		private global::System.Windows.Forms.Label lblArchers;

		// Token: 0x04002FE0 RID: 12256
		private global::System.Windows.Forms.TrackBar tbArchers;

		// Token: 0x04002FE1 RID: 12257
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04002FE2 RID: 12258
		private global::System.Windows.Forms.Label lblPikemen;

		// Token: 0x04002FE3 RID: 12259
		private global::System.Windows.Forms.TrackBar tbPikemen;

		// Token: 0x04002FE4 RID: 12260
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04002FE5 RID: 12261
		private global::System.Windows.Forms.Label lblSwordsmen;

		// Token: 0x04002FE6 RID: 12262
		private global::System.Windows.Forms.TrackBar tbSwordsmen;

		// Token: 0x04002FE7 RID: 12263
		private global::System.Windows.Forms.Label label9;

		// Token: 0x04002FE8 RID: 12264
		private global::System.Windows.Forms.Label lblCatapults;

		// Token: 0x04002FE9 RID: 12265
		private global::System.Windows.Forms.TrackBar tbCatapults;
	}
}
