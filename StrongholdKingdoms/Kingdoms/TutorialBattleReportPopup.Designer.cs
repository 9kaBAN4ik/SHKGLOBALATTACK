namespace Kingdoms
{
	// Token: 0x020004A5 RID: 1189
	public partial class TutorialBattleReportPopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x06002B8C RID: 11148 RVA: 0x00020021 File Offset: 0x0001E221
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002B8D RID: 11149 RVA: 0x002248AC File Offset: 0x00222AAC
		private void InitializeComponent()
		{
			this.btnViewReport = new global::Kingdoms.BitmapButton();
			this.label3 = new global::System.Windows.Forms.Label();
			this.lblMessage = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.btnViewReport.BackColor = global::System.Drawing.Color.FromArgb(203, 215, 223);
			this.btnViewReport.BorderColor = global::ARGBColors.DarkBlue;
			this.btnViewReport.BorderDrawing = true;
			this.btnViewReport.FocusRectangleEnabled = false;
			this.btnViewReport.Image = null;
			this.btnViewReport.ImageBorderColor = global::ARGBColors.Chocolate;
			this.btnViewReport.ImageBorderEnabled = true;
			this.btnViewReport.ImageDropShadow = true;
			this.btnViewReport.ImageFocused = null;
			this.btnViewReport.ImageInactive = null;
			this.btnViewReport.ImageMouseOver = null;
			this.btnViewReport.ImageNormal = null;
			this.btnViewReport.ImagePressed = null;
			this.btnViewReport.InnerBorderColor = global::ARGBColors.LightGray;
			this.btnViewReport.InnerBorderColor_Focus = global::ARGBColors.LightBlue;
			this.btnViewReport.InnerBorderColor_MouseOver = global::ARGBColors.Gold;
			this.btnViewReport.Location = new global::System.Drawing.Point(115, 130);
			this.btnViewReport.Name = "btnViewReport";
			this.btnViewReport.OffsetPressedContent = true;
			this.btnViewReport.Padding2 = 5;
			this.btnViewReport.Size = new global::System.Drawing.Size(201, 39);
			this.btnViewReport.StretchImage = false;
			this.btnViewReport.TabIndex = 2;
			this.btnViewReport.Text = "View Report";
			this.btnViewReport.TextDropShadow = false;
			this.btnViewReport.UseVisualStyleBackColor = false;
			this.btnViewReport.Click += new global::System.EventHandler(this.btnOK_Click);
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
			this.lblMessage.Size = new global::System.Drawing.Size(406, 77);
			this.lblMessage.TabIndex = 13;
			this.lblMessage.Text = "label1";
			this.lblMessage.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::System.Drawing.Color.FromArgb(159, 180, 193);
			base.ClientSize = new global::System.Drawing.Size(430 * global::Kingdoms.InterfaceMgr.UIScale, 218 * global::Kingdoms.InterfaceMgr.UIScale);
			base.Controls.Add(this.lblMessage);
			base.Controls.Add(this.btnViewReport);
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.Name = "TutorialBattleReportPopup";
			base.ShowClose = true;
			base.Controls.SetChildIndex(this.btnViewReport, 0);
			base.Controls.SetChildIndex(this.lblMessage, 0);
			base.ResumeLayout(false);
		}

		// Token: 0x0400361F RID: 13855
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04003620 RID: 13856
		private global::Kingdoms.BitmapButton btnViewReport;

		// Token: 0x04003621 RID: 13857
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04003622 RID: 13858
		private global::System.Windows.Forms.Label lblMessage;
	}
}
