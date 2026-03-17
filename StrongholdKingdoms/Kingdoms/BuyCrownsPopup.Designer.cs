namespace Kingdoms
{
	// Token: 0x020000F4 RID: 244
	public partial class BuyCrownsPopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x06000750 RID: 1872 RVA: 0x0000C092 File Offset: 0x0000A292
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000751 RID: 1873 RVA: 0x0009654C File Offset: 0x0009474C
		private void InitializeComponent()
		{
			this.btnBuyCrowns = new global::Kingdoms.BitmapButton();
			this.label3 = new global::System.Windows.Forms.Label();
			this.lblMessage = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.btnBuyCrowns.BackColor = global::System.Drawing.Color.FromArgb(203, 215, 223);
			this.btnBuyCrowns.BorderColor = global::ARGBColors.DarkBlue;
			this.btnBuyCrowns.BorderDrawing = true;
			this.btnBuyCrowns.FocusRectangleEnabled = false;
			this.btnBuyCrowns.Image = null;
			this.btnBuyCrowns.ImageBorderColor = global::ARGBColors.Chocolate;
			this.btnBuyCrowns.ImageBorderEnabled = true;
			this.btnBuyCrowns.ImageDropShadow = true;
			this.btnBuyCrowns.ImageFocused = null;
			this.btnBuyCrowns.ImageInactive = null;
			this.btnBuyCrowns.ImageMouseOver = null;
			this.btnBuyCrowns.ImageNormal = null;
			this.btnBuyCrowns.ImagePressed = null;
			this.btnBuyCrowns.InnerBorderColor = global::ARGBColors.LightGray;
			this.btnBuyCrowns.InnerBorderColor_Focus = global::ARGBColors.LightBlue;
			this.btnBuyCrowns.InnerBorderColor_MouseOver = global::ARGBColors.Gold;
			this.btnBuyCrowns.Location = new global::System.Drawing.Point(115, 121);
			this.btnBuyCrowns.Name = "btnBuyCrowns";
			this.btnBuyCrowns.OffsetPressedContent = true;
			this.btnBuyCrowns.Padding2 = 5;
			this.btnBuyCrowns.Size = new global::System.Drawing.Size(201, 39);
			this.btnBuyCrowns.StretchImage = false;
			this.btnBuyCrowns.TabIndex = 2;
			this.btnBuyCrowns.Text = "Buy Crowns";
			this.btnBuyCrowns.TextDropShadow = false;
			this.btnBuyCrowns.UseVisualStyleBackColor = false;
			this.btnBuyCrowns.Click += new global::System.EventHandler(this.btnOK_Click);
			this.label3.AutoSize = true;
			this.label3.BackColor = global::ARGBColors.Transparent;
			this.label3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::ARGBColors.White;
			this.label3.Location = new global::System.Drawing.Point(179, 7);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(0, 16);
			this.label3.TabIndex = 9;
			this.lblMessage.BackColor = global::ARGBColors.Transparent;
			this.lblMessage.Location = new global::System.Drawing.Point(12, 44);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Size = new global::System.Drawing.Size(406, 65);
			this.lblMessage.TabIndex = 13;
			this.lblMessage.Text = "label1";
			this.lblMessage.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::System.Drawing.Color.FromArgb(159, 180, 193);
			base.ClientSize = new global::System.Drawing.Size(430 * global::Kingdoms.InterfaceMgr.UIScale, 199 * global::Kingdoms.InterfaceMgr.UIScale);
			base.Controls.Add(this.lblMessage);
			base.Controls.Add(this.btnBuyCrowns);
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.Name = "BuyCrownsPopup";
			base.ShowClose = true;
			base.Controls.SetChildIndex(this.btnBuyCrowns, 0);
			base.Controls.SetChildIndex(this.lblMessage, 0);
			base.ResumeLayout(false);
		}

		// Token: 0x040009A3 RID: 2467
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040009A4 RID: 2468
		private global::Kingdoms.BitmapButton btnBuyCrowns;

		// Token: 0x040009A5 RID: 2469
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040009A6 RID: 2470
		private global::System.Windows.Forms.Label lblMessage;
	}
}
