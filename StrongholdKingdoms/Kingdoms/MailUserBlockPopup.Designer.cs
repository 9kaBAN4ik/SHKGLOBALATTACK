namespace Kingdoms
{
	// Token: 0x0200022A RID: 554
	public partial class MailUserBlockPopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x060017FF RID: 6143 RVA: 0x00018EBE File Offset: 0x000170BE
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001800 RID: 6144 RVA: 0x0017BBC4 File Offset: 0x00179DC4
		private void InitializeComponent()
		{
			this.listBoxSearch = new global::System.Windows.Forms.ListBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.btnClose = new global::Kingdoms.BitmapButton();
			this.btnRemoveBlock = new global::Kingdoms.BitmapButton();
			this.cbAggressive = new global::System.Windows.Forms.CheckBox();
			base.SuspendLayout();
			this.listBoxSearch.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.listBoxSearch.BackColor = global::ARGBColors.White;
			this.listBoxSearch.ForeColor = global::ARGBColors.Black;
			this.listBoxSearch.FormattingEnabled = true;
			this.listBoxSearch.Location = new global::System.Drawing.Point(14, 48);
			this.listBoxSearch.Name = "listBoxSearch";
			this.listBoxSearch.Size = new global::System.Drawing.Size(366, 251);
			this.listBoxSearch.TabIndex = 11;
			this.listBoxSearch.SelectedIndexChanged += new global::System.EventHandler(this.listBoxSearch_SelectedIndexChanged);
			this.listBoxSearch.DoubleClick += new global::System.EventHandler(this.listBoxSearch_DoubleClick);
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
			this.btnClose.Location = new global::System.Drawing.Point(271, 369);
			this.btnClose.Name = "btnClose";
			this.btnClose.OffsetPressedContent = true;
			this.btnClose.Padding2 = 5;
			this.btnClose.Size = new global::System.Drawing.Size(110, 27);
			this.btnClose.StretchImage = false;
			this.btnClose.TabIndex = 17;
			this.btnClose.Text = "Close";
			this.btnClose.TextDropShadow = false;
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.btnRemoveBlock.BorderColor = global::System.Drawing.Color.FromArgb(0, 0, 139);
			this.btnRemoveBlock.BorderDrawing = true;
			this.btnRemoveBlock.FocusRectangleEnabled = false;
			this.btnRemoveBlock.Image = null;
			this.btnRemoveBlock.ImageBorderColor = global::System.Drawing.Color.FromArgb(210, 105, 30);
			this.btnRemoveBlock.ImageBorderEnabled = true;
			this.btnRemoveBlock.ImageDropShadow = true;
			this.btnRemoveBlock.ImageFocused = null;
			this.btnRemoveBlock.ImageInactive = null;
			this.btnRemoveBlock.ImageMouseOver = null;
			this.btnRemoveBlock.ImageNormal = null;
			this.btnRemoveBlock.ImagePressed = null;
			this.btnRemoveBlock.InnerBorderColor = global::System.Drawing.Color.FromArgb(211, 211, 211);
			this.btnRemoveBlock.InnerBorderColor_Focus = global::System.Drawing.Color.FromArgb(173, 216, 230);
			this.btnRemoveBlock.InnerBorderColor_MouseOver = global::System.Drawing.Color.FromArgb(255, 215, 0);
			this.btnRemoveBlock.Location = new global::System.Drawing.Point(116, 305);
			this.btnRemoveBlock.Name = "btnRemoveBlock";
			this.btnRemoveBlock.OffsetPressedContent = true;
			this.btnRemoveBlock.Padding2 = 5;
			this.btnRemoveBlock.Size = new global::System.Drawing.Size(161, 27);
			this.btnRemoveBlock.StretchImage = false;
			this.btnRemoveBlock.TabIndex = 23;
			this.btnRemoveBlock.Text = "Remove Block";
			this.btnRemoveBlock.TextDropShadow = false;
			this.btnRemoveBlock.UseVisualStyleBackColor = true;
			this.btnRemoveBlock.Click += new global::System.EventHandler(this.btnRemoveBlock_Click);
			this.cbAggressive.AutoSize = true;
			this.cbAggressive.BackColor = global::System.Drawing.Color.FromArgb(0, 255, 255, 255);
			this.cbAggressive.ForeColor = global::ARGBColors.Black;
			this.cbAggressive.Location = new global::System.Drawing.Point(59, 341);
			this.cbAggressive.Name = "cbAggressive";
			this.cbAggressive.Size = new global::System.Drawing.Size(80, 17);
			this.cbAggressive.TabIndex = 24;
			this.cbAggressive.Text = "checkBox1";
			this.cbAggressive.UseVisualStyleBackColor = false;
			this.cbAggressive.CheckedChanged += new global::System.EventHandler(this.cbAggressive_CheckedChanged);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(393 * global::Kingdoms.InterfaceMgr.UIScale, 408 * global::Kingdoms.InterfaceMgr.UIScale);
			base.Controls.Add(this.cbAggressive);
			base.Controls.Add(this.btnRemoveBlock);
			base.Controls.Add(this.btnClose);
			base.Controls.Add(this.listBoxSearch);
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.Name = "MailUserBlockPopup";
			base.ShowBar = true;
			base.ShowClose = true;
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Add Users";
			base.TopMost = true;
			base.Controls.SetChildIndex(this.listBoxSearch, 0);
			base.Controls.SetChildIndex(this.btnClose, 0);
			base.Controls.SetChildIndex(this.btnRemoveBlock, 0);
			base.Controls.SetChildIndex(this.cbAggressive, 0);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040028A1 RID: 10401
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040028A2 RID: 10402
		private global::System.Windows.Forms.ListBox listBoxSearch;

		// Token: 0x040028A3 RID: 10403
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040028A4 RID: 10404
		private global::Kingdoms.BitmapButton btnClose;

		// Token: 0x040028A5 RID: 10405
		private global::Kingdoms.BitmapButton btnRemoveBlock;

		// Token: 0x040028A6 RID: 10406
		private global::System.Windows.Forms.CheckBox cbAggressive;
	}
}
