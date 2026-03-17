namespace Kingdoms
{
	// Token: 0x0200046B RID: 1131
	public partial class RenameVillagePopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x060028DA RID: 10458 RVA: 0x0001E28B File Offset: 0x0001C48B
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060028DB RID: 10459 RVA: 0x001EE250 File Offset: 0x001EC450
		private void InitializeComponent()
		{
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.tbOldName = new global::System.Windows.Forms.TextBox();
			this.tbNewName = new global::System.Windows.Forms.TextBox();
			this.btnOK = new global::Kingdoms.BitmapButton();
			this.btnCancel = new global::Kingdoms.BitmapButton();
			this.label3 = new global::System.Windows.Forms.Label();
			this.btnHistory = new global::Kingdoms.BitmapButton();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.BackColor = global::System.Drawing.Color.FromArgb(0, 255, 255, 255);
			this.label1.Location = new global::System.Drawing.Point(16, 51);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(73, 13);
			this.label1.TabIndex = 10;
			this.label1.Text = "Original Name";
			this.label2.AutoSize = true;
			this.label2.BackColor = global::System.Drawing.Color.FromArgb(0, 255, 255, 255);
			this.label2.Location = new global::System.Drawing.Point(16, 87);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(60, 13);
			this.label2.TabIndex = 11;
			this.label2.Text = "New Name";
			this.tbOldName.BackColor = global::System.Drawing.Color.FromArgb(159, 180, 193);
			this.tbOldName.ForeColor = global::ARGBColors.Black;
			this.tbOldName.Location = new global::System.Drawing.Point(122, 48);
			this.tbOldName.Name = "tbOldName";
			this.tbOldName.ReadOnly = true;
			this.tbOldName.Size = new global::System.Drawing.Size(144, 20);
			this.tbOldName.TabIndex = 4;
			this.tbNewName.BackColor = global::System.Drawing.Color.FromArgb(235, 240, 243);
			this.tbNewName.ForeColor = global::ARGBColors.Black;
			this.tbNewName.Location = new global::System.Drawing.Point(122, 84);
			this.tbNewName.MaxLength = 32;
			this.tbNewName.Name = "tbNewName";
			this.tbNewName.Size = new global::System.Drawing.Size(144, 20);
			this.tbNewName.TabIndex = 1;
			this.tbNewName.TextChanged += new global::System.EventHandler(this.tbNewName_TextChanged);
			this.tbNewName.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.tbNewName_KeyPress);
			this.btnOK.BackColor = global::System.Drawing.Color.FromArgb(203, 215, 223);
			this.btnOK.BorderColor = global::System.Drawing.Color.FromArgb(0, 0, 139);
			this.btnOK.BorderDrawing = true;
			this.btnOK.FocusRectangleEnabled = false;
			this.btnOK.Image = null;
			this.btnOK.ImageBorderColor = global::System.Drawing.Color.FromArgb(210, 105, 30);
			this.btnOK.ImageBorderEnabled = true;
			this.btnOK.ImageDropShadow = true;
			this.btnOK.ImageFocused = null;
			this.btnOK.ImageInactive = null;
			this.btnOK.ImageMouseOver = null;
			this.btnOK.ImageNormal = null;
			this.btnOK.ImagePressed = null;
			this.btnOK.InnerBorderColor = global::System.Drawing.Color.FromArgb(211, 211, 211);
			this.btnOK.InnerBorderColor_Focus = global::System.Drawing.Color.FromArgb(173, 216, 230);
			this.btnOK.InnerBorderColor_MouseOver = global::System.Drawing.Color.FromArgb(255, 215, 0);
			this.btnOK.Location = new global::System.Drawing.Point(301, 48);
			this.btnOK.Name = "btnOK";
			this.btnOK.OffsetPressedContent = true;
			this.btnOK.Padding2 = 5;
			this.btnOK.Size = new global::System.Drawing.Size(79, 20);
			this.btnOK.StretchImage = false;
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.TextDropShadow = false;
			this.btnOK.UseVisualStyleBackColor = false;
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.btnCancel.BackColor = global::System.Drawing.Color.FromArgb(203, 215, 223);
			this.btnCancel.BorderColor = global::System.Drawing.Color.FromArgb(0, 0, 139);
			this.btnCancel.BorderDrawing = true;
			this.btnCancel.FocusRectangleEnabled = false;
			this.btnCancel.Image = null;
			this.btnCancel.ImageBorderColor = global::System.Drawing.Color.FromArgb(210, 105, 30);
			this.btnCancel.ImageBorderEnabled = true;
			this.btnCancel.ImageDropShadow = true;
			this.btnCancel.ImageFocused = null;
			this.btnCancel.ImageInactive = null;
			this.btnCancel.ImageMouseOver = null;
			this.btnCancel.ImageNormal = null;
			this.btnCancel.ImagePressed = null;
			this.btnCancel.InnerBorderColor = global::System.Drawing.Color.FromArgb(211, 211, 211);
			this.btnCancel.InnerBorderColor_Focus = global::System.Drawing.Color.FromArgb(173, 216, 230);
			this.btnCancel.InnerBorderColor_MouseOver = global::System.Drawing.Color.FromArgb(255, 215, 0);
			this.btnCancel.Location = new global::System.Drawing.Point(301, 84);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.OffsetPressedContent = true;
			this.btnCancel.Padding2 = 5;
			this.btnCancel.Size = new global::System.Drawing.Size(79, 20);
			this.btnCancel.StretchImage = false;
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.TextDropShadow = false;
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.label3.AutoSize = true;
			this.label3.BackColor = global::System.Drawing.Color.FromArgb(0, 255, 255, 255);
			this.label3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.FromArgb(255, 255, 255);
			this.label3.Location = new global::System.Drawing.Point(179, 7);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(0, 16);
			this.label3.TabIndex = 9;
			this.btnHistory.BackColor = global::System.Drawing.Color.FromArgb(203, 215, 223);
			this.btnHistory.BorderColor = global::System.Drawing.Color.FromArgb(0, 0, 139);
			this.btnHistory.BorderDrawing = true;
			this.btnHistory.FocusRectangleEnabled = false;
			this.btnHistory.Image = null;
			this.btnHistory.ImageBorderColor = global::System.Drawing.Color.FromArgb(210, 105, 30);
			this.btnHistory.ImageBorderEnabled = true;
			this.btnHistory.ImageDropShadow = true;
			this.btnHistory.ImageFocused = null;
			this.btnHistory.ImageInactive = null;
			this.btnHistory.ImageMouseOver = null;
			this.btnHistory.ImageNormal = null;
			this.btnHistory.ImagePressed = null;
			this.btnHistory.InnerBorderColor = global::System.Drawing.Color.FromArgb(211, 211, 211);
			this.btnHistory.InnerBorderColor_Focus = global::System.Drawing.Color.FromArgb(173, 216, 230);
			this.btnHistory.InnerBorderColor_MouseOver = global::System.Drawing.Color.FromArgb(255, 215, 0);
			this.btnHistory.Location = new global::System.Drawing.Point(301, 103);
			this.btnHistory.Name = "btnHistory";
			this.btnHistory.OffsetPressedContent = true;
			this.btnHistory.Padding2 = 5;
			this.btnHistory.Size = new global::System.Drawing.Size(79, 20);
			this.btnHistory.StretchImage = false;
			this.btnHistory.TabIndex = 13;
			this.btnHistory.Text = "History";
			this.btnHistory.TextDropShadow = false;
			this.btnHistory.UseVisualStyleBackColor = false;
			this.btnHistory.Visible = false;
			this.btnHistory.Click += new global::System.EventHandler(this.btnHistory_Click);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::System.Drawing.Color.FromArgb(159, 180, 193);
			base.ClientSize = new global::System.Drawing.Size(400 * global::Kingdoms.InterfaceMgr.UIScale, 123 * global::Kingdoms.InterfaceMgr.UIScale);
			base.Controls.Add(this.btnHistory);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.tbNewName);
			base.Controls.Add(this.tbOldName);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.Name = "RenameVillagePopup";
			base.ShowBar = true;
			base.ShowClose = true;
			base.Controls.SetChildIndex(this.label1, 0);
			base.Controls.SetChildIndex(this.label2, 0);
			base.Controls.SetChildIndex(this.tbOldName, 0);
			base.Controls.SetChildIndex(this.tbNewName, 0);
			base.Controls.SetChildIndex(this.btnOK, 0);
			base.Controls.SetChildIndex(this.btnCancel, 0);
			base.Controls.SetChildIndex(this.btnHistory, 0);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040031DF RID: 12767
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040031E0 RID: 12768
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040031E1 RID: 12769
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040031E2 RID: 12770
		private global::System.Windows.Forms.TextBox tbOldName;

		// Token: 0x040031E3 RID: 12771
		private global::System.Windows.Forms.TextBox tbNewName;

		// Token: 0x040031E4 RID: 12772
		private global::Kingdoms.BitmapButton btnOK;

		// Token: 0x040031E5 RID: 12773
		private global::Kingdoms.BitmapButton btnCancel;

		// Token: 0x040031E6 RID: 12774
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040031E7 RID: 12775
		private global::Kingdoms.BitmapButton btnHistory;
	}
}
