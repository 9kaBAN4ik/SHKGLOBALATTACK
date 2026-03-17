namespace Kingdoms
{
	// Token: 0x0200047F RID: 1151
	public partial class SearchForVillagePopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x060029E2 RID: 10722 RVA: 0x0001ECC6 File Offset: 0x0001CEC6
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060029E3 RID: 10723 RVA: 0x00205E88 File Offset: 0x00204088
		private void InitializeComponent()
		{
			this.lblSearchByName = new global::System.Windows.Forms.Label();
			this.tbSearchName = new global::System.Windows.Forms.TextBox();
			this.btnCancel = new global::Kingdoms.BitmapButton();
			this.label3 = new global::System.Windows.Forms.Label();
			this.tbVillageID = new global::System.Windows.Forms.TextBox();
			this.lblSearchByID = new global::System.Windows.Forms.Label();
			this.listBoxVillages = new global::System.Windows.Forms.ListBox();
			this.btnSearchByName = new global::Kingdoms.BitmapButton();
			this.btnSearchByID = new global::Kingdoms.BitmapButton();
			base.SuspendLayout();
			this.lblSearchByName.BackColor = global::System.Drawing.Color.FromArgb(0, 255, 255, 255);
			this.lblSearchByName.ForeColor = global::ARGBColors.Black;
			this.lblSearchByName.Location = new global::System.Drawing.Point(12, 41);
			this.lblSearchByName.Name = "lblSearchByName";
			this.lblSearchByName.Size = new global::System.Drawing.Size(140, 40);
			this.lblSearchByName.TabIndex = 11;
			this.lblSearchByName.Text = "Search By Name";
			this.lblSearchByName.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.tbSearchName.BackColor = global::System.Drawing.Color.FromArgb(235, 240, 243);
			this.tbSearchName.ForeColor = global::ARGBColors.Black;
			this.tbSearchName.Location = new global::System.Drawing.Point(158, 49);
			this.tbSearchName.MaxLength = 32;
			this.tbSearchName.Name = "tbSearchName";
			this.tbSearchName.Size = new global::System.Drawing.Size(155, 20);
			this.tbSearchName.TabIndex = 1;
			this.tbSearchName.TextChanged += new global::System.EventHandler(this.tbNewName_TextChanged);
			this.tbSearchName.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.tbSearchName_KeyUp);
			this.tbSearchName.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.tbSearchName_KeyPress);
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
			this.btnCancel.Location = new global::System.Drawing.Point(322, 355);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.OffsetPressedContent = true;
			this.btnCancel.Padding2 = 5;
			this.btnCancel.Size = new global::System.Drawing.Size(122, 32);
			this.btnCancel.StretchImage = false;
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Close";
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
			this.tbVillageID.BackColor = global::System.Drawing.Color.FromArgb(235, 240, 243);
			this.tbVillageID.Location = new global::System.Drawing.Point(158, 84);
			this.tbVillageID.MaxLength = 32;
			this.tbVillageID.Name = "tbVillageID";
			this.tbVillageID.Size = new global::System.Drawing.Size(155, 20);
			this.tbVillageID.TabIndex = 13;
			this.tbVillageID.TextChanged += new global::System.EventHandler(this.tbVillageID_TextChanged);
			this.tbVillageID.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.tbVillageID_KeyUp);
			this.tbVillageID.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.tbVillageID_KeyPress);
			this.lblSearchByID.BackColor = global::System.Drawing.Color.FromArgb(0, 255, 255, 255);
			this.lblSearchByID.ForeColor = global::ARGBColors.Black;
			this.lblSearchByID.Location = new global::System.Drawing.Point(12, 75);
			this.lblSearchByID.Name = "lblSearchByID";
			this.lblSearchByID.Size = new global::System.Drawing.Size(140, 40);
			this.lblSearchByID.TabIndex = 14;
			this.lblSearchByID.Text = "Search By VillageID";
			this.lblSearchByID.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.listBoxVillages.BackColor = global::ARGBColors.White;
			this.listBoxVillages.ForeColor = global::ARGBColors.Black;
			this.listBoxVillages.FormattingEnabled = true;
			this.listBoxVillages.Location = new global::System.Drawing.Point(34, 117);
			this.listBoxVillages.Name = "listBoxVillages";
			this.listBoxVillages.Size = new global::System.Drawing.Size(385, 225);
			this.listBoxVillages.TabIndex = 15;
			this.listBoxVillages.DoubleClick += new global::System.EventHandler(this.listBoxVillages_DoubleClick);
			this.btnSearchByName.BackColor = global::System.Drawing.Color.FromArgb(203, 215, 223);
			this.btnSearchByName.BorderColor = global::System.Drawing.Color.FromArgb(0, 0, 139);
			this.btnSearchByName.BorderDrawing = true;
			this.btnSearchByName.FocusRectangleEnabled = false;
			this.btnSearchByName.Image = null;
			this.btnSearchByName.ImageBorderColor = global::System.Drawing.Color.FromArgb(210, 105, 30);
			this.btnSearchByName.ImageBorderEnabled = true;
			this.btnSearchByName.ImageDropShadow = true;
			this.btnSearchByName.ImageFocused = null;
			this.btnSearchByName.ImageInactive = null;
			this.btnSearchByName.ImageMouseOver = null;
			this.btnSearchByName.ImageNormal = null;
			this.btnSearchByName.ImagePressed = null;
			this.btnSearchByName.InnerBorderColor = global::System.Drawing.Color.FromArgb(211, 211, 211);
			this.btnSearchByName.InnerBorderColor_Focus = global::System.Drawing.Color.FromArgb(173, 216, 230);
			this.btnSearchByName.InnerBorderColor_MouseOver = global::System.Drawing.Color.FromArgb(255, 215, 0);
			this.btnSearchByName.Location = new global::System.Drawing.Point(331, 49);
			this.btnSearchByName.Name = "btnSearchByName";
			this.btnSearchByName.OffsetPressedContent = true;
			this.btnSearchByName.Padding2 = 5;
			this.btnSearchByName.Size = new global::System.Drawing.Size(113, 21);
			this.btnSearchByName.StretchImage = false;
			this.btnSearchByName.TabIndex = 16;
			this.btnSearchByName.Text = "Search";
			this.btnSearchByName.TextDropShadow = false;
			this.btnSearchByName.UseVisualStyleBackColor = false;
			this.btnSearchByName.Click += new global::System.EventHandler(this.btnSearchByName_Click);
			this.btnSearchByID.BackColor = global::System.Drawing.Color.FromArgb(203, 215, 223);
			this.btnSearchByID.BorderColor = global::System.Drawing.Color.FromArgb(0, 0, 139);
			this.btnSearchByID.BorderDrawing = true;
			this.btnSearchByID.FocusRectangleEnabled = false;
			this.btnSearchByID.Image = null;
			this.btnSearchByID.ImageBorderColor = global::System.Drawing.Color.FromArgb(210, 105, 30);
			this.btnSearchByID.ImageBorderEnabled = true;
			this.btnSearchByID.ImageDropShadow = true;
			this.btnSearchByID.ImageFocused = null;
			this.btnSearchByID.ImageInactive = null;
			this.btnSearchByID.ImageMouseOver = null;
			this.btnSearchByID.ImageNormal = null;
			this.btnSearchByID.ImagePressed = null;
			this.btnSearchByID.InnerBorderColor = global::System.Drawing.Color.FromArgb(211, 211, 211);
			this.btnSearchByID.InnerBorderColor_Focus = global::System.Drawing.Color.FromArgb(173, 216, 230);
			this.btnSearchByID.InnerBorderColor_MouseOver = global::System.Drawing.Color.FromArgb(255, 215, 0);
			this.btnSearchByID.Location = new global::System.Drawing.Point(331, 83);
			this.btnSearchByID.Name = "btnSearchByID";
			this.btnSearchByID.OffsetPressedContent = true;
			this.btnSearchByID.Padding2 = 5;
			this.btnSearchByID.Size = new global::System.Drawing.Size(113, 21);
			this.btnSearchByID.StretchImage = false;
			this.btnSearchByID.TabIndex = 17;
			this.btnSearchByID.Text = "Search";
			this.btnSearchByID.TextDropShadow = false;
			this.btnSearchByID.UseVisualStyleBackColor = false;
			this.btnSearchByID.Click += new global::System.EventHandler(this.btnSearchByID_Click);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::System.Drawing.Color.FromArgb(159, 180, 193);
			base.ClientSize = new global::System.Drawing.Size(456 * global::Kingdoms.InterfaceMgr.UIScale, 399 * global::Kingdoms.InterfaceMgr.UIScale);
			base.Controls.Add(this.btnSearchByID);
			base.Controls.Add(this.btnSearchByName);
			base.Controls.Add(this.listBoxVillages);
			base.Controls.Add(this.tbVillageID);
			base.Controls.Add(this.lblSearchByID);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.tbSearchName);
			base.Controls.Add(this.lblSearchByName);
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.Name = "SearchForVillagePopup";
			base.ShowBar = true;
			base.ShowClose = true;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			base.Controls.SetChildIndex(this.lblSearchByName, 0);
			base.Controls.SetChildIndex(this.tbSearchName, 0);
			base.Controls.SetChildIndex(this.btnCancel, 0);
			base.Controls.SetChildIndex(this.lblSearchByID, 0);
			base.Controls.SetChildIndex(this.tbVillageID, 0);
			base.Controls.SetChildIndex(this.listBoxVillages, 0);
			base.Controls.SetChildIndex(this.btnSearchByName, 0);
			base.Controls.SetChildIndex(this.btnSearchByID, 0);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04003377 RID: 13175
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04003378 RID: 13176
		private global::System.Windows.Forms.Label lblSearchByName;

		// Token: 0x04003379 RID: 13177
		private global::System.Windows.Forms.TextBox tbSearchName;

		// Token: 0x0400337A RID: 13178
		private global::Kingdoms.BitmapButton btnCancel;

		// Token: 0x0400337B RID: 13179
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400337C RID: 13180
		private global::System.Windows.Forms.TextBox tbVillageID;

		// Token: 0x0400337D RID: 13181
		private global::System.Windows.Forms.Label lblSearchByID;

		// Token: 0x0400337E RID: 13182
		private global::System.Windows.Forms.ListBox listBoxVillages;

		// Token: 0x0400337F RID: 13183
		private global::Kingdoms.BitmapButton btnSearchByName;

		// Token: 0x04003380 RID: 13184
		private global::Kingdoms.BitmapButton btnSearchByID;
	}
}
