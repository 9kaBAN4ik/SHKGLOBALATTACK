namespace Kingdoms
{
	// Token: 0x020000B7 RID: 183
	public partial class AdminStatsPopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x06000502 RID: 1282 RVA: 0x0000AA1F File Offset: 0x00008C1F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x00060244 File Offset: 0x0005E444
		private void InitializeComponent()
		{
			this.btnClose = new global::Kingdoms.BitmapButton();
			this.label1 = new global::System.Windows.Forms.Label();
			this.lblNumUsersLoggedIn = new global::System.Windows.Forms.Label();
			this.lblLast7 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.lblLast3 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.lblLast24 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.lblNumActiveUsers = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.btnClose.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnClose.BorderColor = global::ARGBColors.DarkBlue;
			this.btnClose.BorderDrawing = true;
			this.btnClose.FocusRectangleEnabled = false;
			this.btnClose.Image = null;
			this.btnClose.ImageBorderColor = global::ARGBColors.Chocolate;
			this.btnClose.ImageBorderEnabled = true;
			this.btnClose.ImageDropShadow = true;
			this.btnClose.ImageFocused = null;
			this.btnClose.ImageInactive = null;
			this.btnClose.ImageMouseOver = null;
			this.btnClose.ImageNormal = null;
			this.btnClose.ImagePressed = null;
			this.btnClose.InnerBorderColor = global::ARGBColors.LightGray;
			this.btnClose.InnerBorderColor_Focus = global::ARGBColors.LightBlue;
			this.btnClose.InnerBorderColor_MouseOver = global::ARGBColors.Gold;
			this.btnClose.Location = new global::System.Drawing.Point(233, 187);
			this.btnClose.Name = "btnClose";
			this.btnClose.OffsetPressedContent = true;
			this.btnClose.Padding2 = 5;
			this.btnClose.Size = new global::System.Drawing.Size(75, 23);
			this.btnClose.StretchImage = false;
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "Close";
			this.btnClose.TextDropShadow = false;
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.label1.AutoSize = true;
			this.label1.BackColor = global::ARGBColors.Transparent;
			this.label1.Location = new global::System.Drawing.Point(21, 42);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(109, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Spare Feedin Villages";
			this.lblNumUsersLoggedIn.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.lblNumUsersLoggedIn.BackColor = global::ARGBColors.Transparent;
			this.lblNumUsersLoggedIn.Location = new global::System.Drawing.Point(249, 42);
			this.lblNumUsersLoggedIn.Name = "lblNumUsersLoggedIn";
			this.lblNumUsersLoggedIn.Size = new global::System.Drawing.Size(43, 13);
			this.lblNumUsersLoggedIn.TabIndex = 2;
			this.lblNumUsersLoggedIn.Text = "0";
			this.lblNumUsersLoggedIn.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.lblLast7.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.lblLast7.BackColor = global::ARGBColors.Transparent;
			this.lblLast7.Location = new global::System.Drawing.Point(249, 162);
			this.lblLast7.Name = "lblLast7";
			this.lblLast7.Size = new global::System.Drawing.Size(43, 13);
			this.lblLast7.TabIndex = 4;
			this.lblLast7.Text = "0";
			this.lblLast7.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label3.AutoSize = true;
			this.label3.BackColor = global::ARGBColors.Transparent;
			this.label3.Location = new global::System.Drawing.Point(21, 162);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(196, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Number of Users Logged In Last 7 Days";
			this.lblLast3.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.lblLast3.BackColor = global::ARGBColors.Transparent;
			this.lblLast3.Location = new global::System.Drawing.Point(249, 132);
			this.lblLast3.Name = "lblLast3";
			this.lblLast3.Size = new global::System.Drawing.Size(43, 13);
			this.lblLast3.TabIndex = 6;
			this.lblLast3.Text = "0";
			this.lblLast3.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label5.AutoSize = true;
			this.label5.BackColor = global::ARGBColors.Transparent;
			this.label5.Location = new global::System.Drawing.Point(21, 132);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(196, 13);
			this.label5.TabIndex = 5;
			this.label5.Text = "Number of Users Logged In Last 3 Days";
			this.lblLast24.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.lblLast24.BackColor = global::ARGBColors.Transparent;
			this.lblLast24.Location = new global::System.Drawing.Point(249, 102);
			this.lblLast24.Name = "lblLast24";
			this.lblLast24.Size = new global::System.Drawing.Size(43, 13);
			this.lblLast24.TabIndex = 8;
			this.lblLast24.Text = "0";
			this.lblLast24.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label7.AutoSize = true;
			this.label7.BackColor = global::ARGBColors.Transparent;
			this.label7.Location = new global::System.Drawing.Point(21, 102);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(206, 13);
			this.label7.TabIndex = 7;
			this.label7.Text = "Number of Users Logged In Last 24 Hours";
			this.lblNumActiveUsers.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.lblNumActiveUsers.BackColor = global::ARGBColors.Transparent;
			this.lblNumActiveUsers.Location = new global::System.Drawing.Point(249, 72);
			this.lblNumActiveUsers.Name = "lblNumActiveUsers";
			this.lblNumActiveUsers.Size = new global::System.Drawing.Size(43, 13);
			this.lblNumActiveUsers.TabIndex = 10;
			this.lblNumActiveUsers.Text = "0";
			this.lblNumActiveUsers.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label4.AutoSize = true;
			this.label4.BackColor = global::ARGBColors.Transparent;
			this.label4.Location = new global::System.Drawing.Point(21, 72);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(163, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Number of Users Currently Active";
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(320, 220);
			base.Controls.Add(this.lblNumActiveUsers);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.lblLast24);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.lblLast3);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.lblLast7);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.lblNumUsersLoggedIn);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.btnClose);
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.Name = "AdminStatsPopup";
			base.ShowClose = true;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Admin Info";
			base.Controls.SetChildIndex(this.btnClose, 0);
			base.Controls.SetChildIndex(this.label1, 0);
			base.Controls.SetChildIndex(this.lblNumUsersLoggedIn, 0);
			base.Controls.SetChildIndex(this.label3, 0);
			base.Controls.SetChildIndex(this.lblLast7, 0);
			base.Controls.SetChildIndex(this.label5, 0);
			base.Controls.SetChildIndex(this.lblLast3, 0);
			base.Controls.SetChildIndex(this.label7, 0);
			base.Controls.SetChildIndex(this.lblLast24, 0);
			base.Controls.SetChildIndex(this.label4, 0);
			base.Controls.SetChildIndex(this.lblNumActiveUsers, 0);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040005C4 RID: 1476
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040005C5 RID: 1477
		private global::Kingdoms.BitmapButton btnClose;

		// Token: 0x040005C6 RID: 1478
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040005C7 RID: 1479
		private global::System.Windows.Forms.Label lblNumUsersLoggedIn;

		// Token: 0x040005C8 RID: 1480
		private global::System.Windows.Forms.Label lblLast7;

		// Token: 0x040005C9 RID: 1481
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040005CA RID: 1482
		private global::System.Windows.Forms.Label lblLast3;

		// Token: 0x040005CB RID: 1483
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040005CC RID: 1484
		private global::System.Windows.Forms.Label lblLast24;

		// Token: 0x040005CD RID: 1485
		private global::System.Windows.Forms.Label label7;

		// Token: 0x040005CE RID: 1486
		private global::System.Windows.Forms.Label lblNumActiveUsers;

		// Token: 0x040005CF RID: 1487
		private global::System.Windows.Forms.Label label4;
	}
}
