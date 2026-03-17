namespace Kingdoms
{
	// Token: 0x0200022B RID: 555
	public partial class MailUserPopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x0600180A RID: 6154 RVA: 0x00018F95 File Offset: 0x00017195
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600180B RID: 6155 RVA: 0x0017C4E8 File Offset: 0x0017A6E8
		private void InitializeComponent()
		{
			this.textBoxNewRecipient = new global::System.Windows.Forms.TextBox();
			this.btnAdd = new global::Kingdoms.BitmapButton();
			this.listBoxSearch = new global::System.Windows.Forms.ListBox();
			this.listBoxRecent = new global::System.Windows.Forms.ListBox();
			this.listBoxFavourites = new global::System.Windows.Forms.ListBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.btnClose = new global::Kingdoms.BitmapButton();
			this.label4 = new global::System.Windows.Forms.Label();
			this.listBoxRecipients = new global::System.Windows.Forms.ListBox();
			this.btnAddToFavourites = new global::Kingdoms.BitmapButton();
			this.btnSearch = new global::Kingdoms.BitmapButton();
			this.btnCancel = new global::Kingdoms.BitmapButton();
			this.btnRemoveFromFavourites = new global::Kingdoms.BitmapButton();
			this.label5 = new global::System.Windows.Forms.Label();
			this.btnRemove = new global::Kingdoms.BitmapButton();
			base.SuspendLayout();
			this.textBoxNewRecipient.BackColor = global::ARGBColors.White;
			this.textBoxNewRecipient.ForeColor = global::ARGBColors.Black;
			this.textBoxNewRecipient.Location = new global::System.Drawing.Point(215, 66);
			this.textBoxNewRecipient.Name = "textBoxNewRecipient";
			this.textBoxNewRecipient.Size = new global::System.Drawing.Size(160, 20);
			this.textBoxNewRecipient.TabIndex = 10;
			this.textBoxNewRecipient.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.textBoxNewRecipient_KeyUp);
			this.textBoxNewRecipient.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.textBoxNewRecipient_KeyPress);
			this.btnAdd.BorderColor = global::System.Drawing.Color.FromArgb(0, 0, 139);
			this.btnAdd.BorderDrawing = true;
			this.btnAdd.FocusRectangleEnabled = false;
			this.btnAdd.Image = null;
			this.btnAdd.ImageBorderColor = global::System.Drawing.Color.FromArgb(210, 105, 30);
			this.btnAdd.ImageBorderEnabled = true;
			this.btnAdd.ImageDropShadow = true;
			this.btnAdd.ImageFocused = null;
			this.btnAdd.ImageInactive = null;
			this.btnAdd.ImageMouseOver = null;
			this.btnAdd.ImageNormal = null;
			this.btnAdd.ImagePressed = null;
			this.btnAdd.InnerBorderColor = global::System.Drawing.Color.FromArgb(211, 211, 211);
			this.btnAdd.InnerBorderColor_Focus = global::System.Drawing.Color.FromArgb(173, 216, 230);
			this.btnAdd.InnerBorderColor_MouseOver = global::System.Drawing.Color.FromArgb(255, 215, 0);
			this.btnAdd.Location = new global::System.Drawing.Point(12, 323);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.OffsetPressedContent = true;
			this.btnAdd.Padding2 = 5;
			this.btnAdd.Size = new global::System.Drawing.Size(160, 27);
			this.btnAdd.StretchImage = false;
			this.btnAdd.TabIndex = 9;
			this.btnAdd.Text = "Add";
			this.btnAdd.TextDropShadow = false;
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new global::System.EventHandler(this.btnAdd_Click);
			this.listBoxSearch.FormattingEnabled = true;
			this.listBoxSearch.Location = new global::System.Drawing.Point(215, 131);
			this.listBoxSearch.Name = "listBoxSearch";
			this.listBoxSearch.Size = new global::System.Drawing.Size(160, 186);
			this.listBoxSearch.TabIndex = 11;
			this.listBoxSearch.SelectedIndexChanged += new global::System.EventHandler(this.listBoxSearch_SelectedIndexChanged);
			this.listBoxSearch.DoubleClick += new global::System.EventHandler(this.listBoxSearch_DoubleClick);
			this.listBoxRecent.BackColor = global::ARGBColors.White;
			this.listBoxRecent.ForeColor = global::ARGBColors.Black;
			this.listBoxRecent.FormattingEnabled = true;
			this.listBoxRecent.Location = new global::System.Drawing.Point(547, 66);
			this.listBoxRecent.Name = "listBoxRecent";
			this.listBoxRecent.Size = new global::System.Drawing.Size(160, 251);
			this.listBoxRecent.TabIndex = 12;
			this.listBoxRecent.SelectedIndexChanged += new global::System.EventHandler(this.listBoxRecent_SelectedIndexChanged);
			this.listBoxRecent.DoubleClick += new global::System.EventHandler(this.listBoxRecent_DoubleClick);
			this.listBoxFavourites.BackColor = global::ARGBColors.White;
			this.listBoxFavourites.ForeColor = global::ARGBColors.Black;
			this.listBoxFavourites.FormattingEnabled = true;
			this.listBoxFavourites.Location = new global::System.Drawing.Point(381, 66);
			this.listBoxFavourites.Name = "listBoxFavourites";
			this.listBoxFavourites.Size = new global::System.Drawing.Size(160, 251);
			this.listBoxFavourites.TabIndex = 13;
			this.listBoxFavourites.SelectedIndexChanged += new global::System.EventHandler(this.listBoxFavourites_SelectedIndexChanged);
			this.listBoxFavourites.DoubleClick += new global::System.EventHandler(this.listBoxFavourites_DoubleClick);
			this.label1.AutoSize = true;
			this.label1.BackColor = global::System.Drawing.Color.FromArgb(0, 255, 255, 255);
			this.label1.Location = new global::System.Drawing.Point(544, 50);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(42, 13);
			this.label1.TabIndex = 14;
			this.label1.Text = "Recent";
			this.label2.AutoSize = true;
			this.label2.BackColor = global::System.Drawing.Color.FromArgb(0, 255, 255, 255);
			this.label2.Location = new global::System.Drawing.Point(378, 50);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(56, 13);
			this.label2.TabIndex = 15;
			this.label2.Text = "Favourites";
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(7, 76);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(79, 13);
			this.label3.TabIndex = 16;
			this.label3.Text = "Search Results";
			this.btnClose.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnClose.BorderColor = global::System.Drawing.Color.FromArgb(0, 0, 139);
			this.btnClose.BorderDrawing = true;
			this.btnClose.FocusRectangleEnabled = false;
			this.btnClose.Image = null;
			this.btnClose.ImageBorderColor = global::System.Drawing.Color.FromArgb(210, 105, 30);
			this.btnClose.ImageBorderEnabled = true;
			this.btnClose.ImageDropShadow = true;
			this.btnClose.ImageFocused = null;
			this.btnClose.ImageInactive = null;
			this.btnClose.ImageMouseOver = null;
			this.btnClose.ImageNormal = null;
			this.btnClose.ImagePressed = null;
			this.btnClose.InnerBorderColor = global::System.Drawing.Color.FromArgb(211, 211, 211);
			this.btnClose.InnerBorderColor_Focus = global::System.Drawing.Color.FromArgb(173, 216, 230);
			this.btnClose.InnerBorderColor_MouseOver = global::System.Drawing.Color.FromArgb(255, 215, 0);
			this.btnClose.Location = new global::System.Drawing.Point(547, 323);
			this.btnClose.Name = "btnClose";
			this.btnClose.OffsetPressedContent = true;
			this.btnClose.Padding2 = 5;
			this.btnClose.Size = new global::System.Drawing.Size(160, 27);
			this.btnClose.StretchImage = false;
			this.btnClose.TabIndex = 17;
			this.btnClose.Text = "Close";
			this.btnClose.TextDropShadow = false;
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.label4.AutoSize = true;
			this.label4.BackColor = global::System.Drawing.Color.FromArgb(0, 255, 255, 255);
			this.label4.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.Location = new global::System.Drawing.Point(9, 46);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(67, 13);
			this.label4.TabIndex = 19;
			this.label4.Text = "Recipients";
			this.listBoxRecipients.BackColor = global::ARGBColors.White;
			this.listBoxRecipients.FormattingEnabled = true;
			this.listBoxRecipients.Location = new global::System.Drawing.Point(12, 66);
			this.listBoxRecipients.Name = "listBoxRecipients";
			this.listBoxRecipients.Size = new global::System.Drawing.Size(160, 251);
			this.listBoxRecipients.TabIndex = 18;
			this.listBoxRecipients.SelectedIndexChanged += new global::System.EventHandler(this.listBoxRecipients_SelectedIndexChanged);
			this.listBoxRecipients.DoubleClick += new global::System.EventHandler(this.listBoxRecipients_DoubleClick);
			this.btnAddToFavourites.BorderColor = global::System.Drawing.Color.FromArgb(0, 0, 139);
			this.btnAddToFavourites.BorderDrawing = true;
			this.btnAddToFavourites.FocusRectangleEnabled = false;
			this.btnAddToFavourites.Image = null;
			this.btnAddToFavourites.ImageBorderColor = global::System.Drawing.Color.FromArgb(210, 105, 30);
			this.btnAddToFavourites.ImageBorderEnabled = true;
			this.btnAddToFavourites.ImageDropShadow = true;
			this.btnAddToFavourites.ImageFocused = null;
			this.btnAddToFavourites.ImageInactive = null;
			this.btnAddToFavourites.ImageMouseOver = null;
			this.btnAddToFavourites.ImageNormal = null;
			this.btnAddToFavourites.ImagePressed = null;
			this.btnAddToFavourites.InnerBorderColor = global::System.Drawing.Color.FromArgb(211, 211, 211);
			this.btnAddToFavourites.InnerBorderColor_Focus = global::System.Drawing.Color.FromArgb(173, 216, 230);
			this.btnAddToFavourites.InnerBorderColor_MouseOver = global::System.Drawing.Color.FromArgb(255, 215, 0);
			this.btnAddToFavourites.Location = new global::System.Drawing.Point(381, 323);
			this.btnAddToFavourites.Name = "btnAddToFavourites";
			this.btnAddToFavourites.OffsetPressedContent = true;
			this.btnAddToFavourites.Padding2 = 5;
			this.btnAddToFavourites.Size = new global::System.Drawing.Size(160, 27);
			this.btnAddToFavourites.StretchImage = false;
			this.btnAddToFavourites.TabIndex = 20;
			this.btnAddToFavourites.Text = "Add to Favourites";
			this.btnAddToFavourites.TextDropShadow = false;
			this.btnAddToFavourites.UseVisualStyleBackColor = true;
			this.btnAddToFavourites.Click += new global::System.EventHandler(this.btnAddToFavourites_Click);
			this.btnSearch.BorderColor = global::System.Drawing.Color.FromArgb(0, 0, 139);
			this.btnSearch.BorderDrawing = true;
			this.btnSearch.FocusRectangleEnabled = false;
			this.btnSearch.Image = null;
			this.btnSearch.ImageBorderColor = global::System.Drawing.Color.FromArgb(210, 105, 30);
			this.btnSearch.ImageBorderEnabled = true;
			this.btnSearch.ImageDropShadow = true;
			this.btnSearch.ImageFocused = null;
			this.btnSearch.ImageInactive = null;
			this.btnSearch.ImageMouseOver = null;
			this.btnSearch.ImageNormal = null;
			this.btnSearch.ImagePressed = null;
			this.btnSearch.InnerBorderColor = global::System.Drawing.Color.FromArgb(211, 211, 211);
			this.btnSearch.InnerBorderColor_Focus = global::System.Drawing.Color.FromArgb(173, 216, 230);
			this.btnSearch.InnerBorderColor_MouseOver = global::System.Drawing.Color.FromArgb(255, 215, 0);
			this.btnSearch.Location = new global::System.Drawing.Point(215, 92);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.OffsetPressedContent = true;
			this.btnSearch.Padding2 = 5;
			this.btnSearch.Size = new global::System.Drawing.Size(160, 27);
			this.btnSearch.StretchImage = false;
			this.btnSearch.TabIndex = 21;
			this.btnSearch.Text = "Search";
			this.btnSearch.TextDropShadow = false;
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new global::System.EventHandler(this.btnSearch_Click);
			this.btnCancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
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
			this.btnCancel.Location = new global::System.Drawing.Point(547, 356);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.OffsetPressedContent = true;
			this.btnCancel.Padding2 = 5;
			this.btnCancel.Size = new global::System.Drawing.Size(159, 27);
			this.btnCancel.StretchImage = false;
			this.btnCancel.TabIndex = 22;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.TextDropShadow = false;
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnRemoveFromFavourites.BorderColor = global::System.Drawing.Color.FromArgb(0, 0, 139);
			this.btnRemoveFromFavourites.BorderDrawing = true;
			this.btnRemoveFromFavourites.FocusRectangleEnabled = false;
			this.btnRemoveFromFavourites.Image = null;
			this.btnRemoveFromFavourites.ImageBorderColor = global::System.Drawing.Color.FromArgb(210, 105, 30);
			this.btnRemoveFromFavourites.ImageBorderEnabled = true;
			this.btnRemoveFromFavourites.ImageDropShadow = true;
			this.btnRemoveFromFavourites.ImageFocused = null;
			this.btnRemoveFromFavourites.ImageInactive = null;
			this.btnRemoveFromFavourites.ImageMouseOver = null;
			this.btnRemoveFromFavourites.ImageNormal = null;
			this.btnRemoveFromFavourites.ImagePressed = null;
			this.btnRemoveFromFavourites.InnerBorderColor = global::System.Drawing.Color.FromArgb(211, 211, 211);
			this.btnRemoveFromFavourites.InnerBorderColor_Focus = global::System.Drawing.Color.FromArgb(173, 216, 230);
			this.btnRemoveFromFavourites.InnerBorderColor_MouseOver = global::System.Drawing.Color.FromArgb(255, 215, 0);
			this.btnRemoveFromFavourites.Location = new global::System.Drawing.Point(381, 356);
			this.btnRemoveFromFavourites.Name = "btnRemoveFromFavourites";
			this.btnRemoveFromFavourites.OffsetPressedContent = true;
			this.btnRemoveFromFavourites.Padding2 = 5;
			this.btnRemoveFromFavourites.Size = new global::System.Drawing.Size(160, 27);
			this.btnRemoveFromFavourites.StretchImage = false;
			this.btnRemoveFromFavourites.TabIndex = 23;
			this.btnRemoveFromFavourites.Text = "Remove from Favourites";
			this.btnRemoveFromFavourites.TextDropShadow = false;
			this.btnRemoveFromFavourites.UseVisualStyleBackColor = true;
			this.btnRemoveFromFavourites.Click += new global::System.EventHandler(this.btnRemoveFromFavourites_Click);
			this.label5.AutoSize = true;
			this.label5.BackColor = global::System.Drawing.Color.FromArgb(0, 255, 255, 255);
			this.label5.Location = new global::System.Drawing.Point(212, 50);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(119, 13);
			this.label5.TabIndex = 15;
			this.label5.Text = "Search for Player Name";
			this.btnRemove.BorderColor = global::System.Drawing.Color.FromArgb(0, 0, 139);
			this.btnRemove.BorderDrawing = true;
			this.btnRemove.FocusRectangleEnabled = false;
			this.btnRemove.Image = null;
			this.btnRemove.ImageBorderColor = global::System.Drawing.Color.FromArgb(210, 105, 30);
			this.btnRemove.ImageBorderEnabled = true;
			this.btnRemove.ImageDropShadow = true;
			this.btnRemove.ImageFocused = null;
			this.btnRemove.ImageInactive = null;
			this.btnRemove.ImageMouseOver = null;
			this.btnRemove.ImageNormal = null;
			this.btnRemove.ImagePressed = null;
			this.btnRemove.InnerBorderColor = global::System.Drawing.Color.FromArgb(211, 211, 211);
			this.btnRemove.InnerBorderColor_Focus = global::System.Drawing.Color.FromArgb(173, 216, 230);
			this.btnRemove.InnerBorderColor_MouseOver = global::System.Drawing.Color.FromArgb(255, 215, 0);
			this.btnRemove.Location = new global::System.Drawing.Point(12, 356);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.OffsetPressedContent = true;
			this.btnRemove.Padding2 = 5;
			this.btnRemove.Size = new global::System.Drawing.Size(160, 27);
			this.btnRemove.StretchImage = false;
			this.btnRemove.TabIndex = 24;
			this.btnRemove.Text = "Remove";
			this.btnRemove.TextDropShadow = false;
			this.btnRemove.UseVisualStyleBackColor = true;
			this.btnRemove.Click += new global::System.EventHandler(this.btnRemove_Click);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(718, 391);
			base.Controls.Add(this.btnRemove);
			base.Controls.Add(this.btnRemoveFromFavourites);
			base.Controls.Add(this.btnSearch);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.listBoxRecipients);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.listBoxFavourites);
			base.Controls.Add(this.listBoxRecent);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.btnAddToFavourites);
			base.Controls.Add(this.textBoxNewRecipient);
			base.Controls.Add(this.listBoxSearch);
			base.Controls.Add(this.btnClose);
			base.Controls.Add(this.btnAdd);
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.Name = "MailUserPopup";
			base.ShowBar = true;
			base.ShowClose = true;
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Add Users";
			base.TopMost = true;
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.MailUserPopup_FormClosing);
			base.Controls.SetChildIndex(this.btnAdd, 0);
			base.Controls.SetChildIndex(this.btnClose, 0);
			base.Controls.SetChildIndex(this.listBoxSearch, 0);
			base.Controls.SetChildIndex(this.textBoxNewRecipient, 0);
			base.Controls.SetChildIndex(this.btnAddToFavourites, 0);
			base.Controls.SetChildIndex(this.label5, 0);
			base.Controls.SetChildIndex(this.listBoxRecent, 0);
			base.Controls.SetChildIndex(this.listBoxFavourites, 0);
			base.Controls.SetChildIndex(this.label1, 0);
			base.Controls.SetChildIndex(this.btnCancel, 0);
			base.Controls.SetChildIndex(this.label2, 0);
			base.Controls.SetChildIndex(this.listBoxRecipients, 0);
			base.Controls.SetChildIndex(this.label4, 0);
			base.Controls.SetChildIndex(this.btnSearch, 0);
			base.Controls.SetChildIndex(this.btnRemoveFromFavourites, 0);
			base.Controls.SetChildIndex(this.btnRemove, 0);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040028A9 RID: 10409
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040028AA RID: 10410
		private global::System.Windows.Forms.TextBox textBoxNewRecipient;

		// Token: 0x040028AB RID: 10411
		private global::Kingdoms.BitmapButton btnAdd;

		// Token: 0x040028AC RID: 10412
		private global::System.Windows.Forms.ListBox listBoxSearch;

		// Token: 0x040028AD RID: 10413
		private global::System.Windows.Forms.ListBox listBoxRecent;

		// Token: 0x040028AE RID: 10414
		private global::System.Windows.Forms.ListBox listBoxFavourites;

		// Token: 0x040028AF RID: 10415
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040028B0 RID: 10416
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040028B1 RID: 10417
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040028B2 RID: 10418
		private global::Kingdoms.BitmapButton btnClose;

		// Token: 0x040028B3 RID: 10419
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040028B4 RID: 10420
		private global::System.Windows.Forms.ListBox listBoxRecipients;

		// Token: 0x040028B5 RID: 10421
		private global::Kingdoms.BitmapButton btnAddToFavourites;

		// Token: 0x040028B6 RID: 10422
		private global::Kingdoms.BitmapButton btnSearch;

		// Token: 0x040028B7 RID: 10423
		private global::Kingdoms.BitmapButton btnCancel;

		// Token: 0x040028B8 RID: 10424
		private global::Kingdoms.BitmapButton btnRemoveFromFavourites;

		// Token: 0x040028B9 RID: 10425
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040028BA RID: 10426
		private global::Kingdoms.BitmapButton btnRemove;
	}
}
