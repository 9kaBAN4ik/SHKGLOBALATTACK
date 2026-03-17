namespace Kingdoms
{
	// Token: 0x020002A8 RID: 680
	public partial class QuestRewardPopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x06001E8C RID: 7820 RVA: 0x0001D290 File Offset: 0x0001B490
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001E8D RID: 7821 RVA: 0x001D7A38 File Offset: 0x001D5C38
		private void InitializeComponent()
		{
			this.btnOK = new global::Kingdoms.BitmapButton();
			this.label1 = new global::System.Windows.Forms.Label();
			this.lblReward = new global::System.Windows.Forms.Label();
			this.lblInfo = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.btnOK.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnOK.BorderColor = global::ARGBColors.DarkBlue;
			this.btnOK.BorderDrawing = true;
			this.btnOK.FocusRectangleEnabled = false;
			this.btnOK.Image = null;
			this.btnOK.ImageBorderColor = global::ARGBColors.Chocolate;
			this.btnOK.ImageBorderEnabled = true;
			this.btnOK.ImageDropShadow = true;
			this.btnOK.ImageFocused = null;
			this.btnOK.ImageInactive = null;
			this.btnOK.ImageMouseOver = null;
			this.btnOK.ImageNormal = null;
			this.btnOK.ImagePressed = null;
			this.btnOK.InnerBorderColor = global::ARGBColors.LightGray;
			this.btnOK.InnerBorderColor_Focus = global::ARGBColors.LightBlue;
			this.btnOK.InnerBorderColor_MouseOver = global::ARGBColors.Gold;
			this.btnOK.Location = new global::System.Drawing.Point(293, 206);
			this.btnOK.Name = "btnOK";
			this.btnOK.OffsetPressedContent = true;
			this.btnOK.Padding2 = 5;
			this.btnOK.Size = new global::System.Drawing.Size(75, 23);
			this.btnOK.StretchImage = false;
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.TextDropShadow = false;
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.label1.AutoSize = true;
			this.label1.BackColor = global::ARGBColors.Transparent;
			this.label1.Location = new global::System.Drawing.Point(12, 50);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(53, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Reward : ";
			this.lblReward.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.lblReward.BackColor = global::ARGBColors.Transparent;
			this.lblReward.Location = new global::System.Drawing.Point(71, 50);
			this.lblReward.Name = "lblReward";
			this.lblReward.Size = new global::System.Drawing.Size(297, 116);
			this.lblReward.TabIndex = 2;
			this.lblReward.Text = "...";
			this.lblInfo.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.lblInfo.BackColor = global::ARGBColors.Transparent;
			this.lblInfo.Location = new global::System.Drawing.Point(12, 116);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new global::System.Drawing.Size(356, 83);
			this.lblInfo.TabIndex = 3;
			this.lblInfo.Text = "....";
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(380, 237);
			base.Controls.Add(this.lblInfo);
			base.Controls.Add(this.lblReward);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.btnOK);
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.Name = "QuestRewardPopup";
			base.ShowClose = true;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Quest Reward";
			base.Controls.SetChildIndex(this.btnOK, 0);
			base.Controls.SetChildIndex(this.label1, 0);
			base.Controls.SetChildIndex(this.lblReward, 0);
			base.Controls.SetChildIndex(this.lblInfo, 0);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04002F51 RID: 12113
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04002F52 RID: 12114
		private global::Kingdoms.BitmapButton btnOK;

		// Token: 0x04002F53 RID: 12115
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04002F54 RID: 12116
		private global::System.Windows.Forms.Label lblReward;

		// Token: 0x04002F55 RID: 12117
		private global::System.Windows.Forms.Label lblInfo;
	}
}
