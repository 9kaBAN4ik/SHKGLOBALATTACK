namespace Kingdoms
{
	// Token: 0x02000158 RID: 344
	public partial class CreateVacationWindow : global::Kingdoms.MyFormBase
	{
		// Token: 0x06000CE6 RID: 3302 RVA: 0x0000F992 File Offset: 0x0000DB92
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000CE7 RID: 3303 RVA: 0x000F5378 File Offset: 0x000F3578
		private void InitializeComponent()
		{
			this.trackNumDays = new global::System.Windows.Forms.TrackBar();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.lblDuration = new global::System.Windows.Forms.Label();
			this.lblNumberVacationLabel = new global::System.Windows.Forms.Label();
			this.lblNumAvailable = new global::System.Windows.Forms.Label();
			this.btnStartVacation = new global::Kingdoms.BitmapButton();
			this.btnCancel = new global::Kingdoms.BitmapButton();
			this.lblDurationValue = new global::System.Windows.Forms.Label();
			this.lblDays = new global::System.Windows.Forms.Label();
			this.lblExplanation = new global::System.Windows.Forms.Label();
			((global::System.ComponentModel.ISupportInitialize)this.trackNumDays).BeginInit();
			base.SuspendLayout();
			this.trackNumDays.AutoSize = false;
			this.trackNumDays.BackColor = global::System.Drawing.Color.FromArgb(137, 155, 167);
			this.trackNumDays.LargeChange = 1;
			this.trackNumDays.Location = new global::System.Drawing.Point(102, 187);
			this.trackNumDays.Maximum = 15;
			this.trackNumDays.Minimum = 3;
			this.trackNumDays.Name = "trackNumDays";
			this.trackNumDays.Size = new global::System.Drawing.Size(223, 45);
			this.trackNumDays.TabIndex = 13;
			this.trackNumDays.Value = 3;
			this.trackNumDays.ValueChanged += new global::System.EventHandler(this.trackNumDays_ValueChanged);
			this.label1.AutoSize = true;
			this.label1.BackColor = global::ARGBColors.Transparent;
			this.label1.ForeColor = global::ARGBColors.Black;
			this.label1.Location = new global::System.Drawing.Point(109, 235);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(13, 13);
			this.label1.TabIndex = 14;
			this.label1.Text = "3";
			this.label2.AutoSize = true;
			this.label2.BackColor = global::ARGBColors.Transparent;
			this.label2.ForeColor = global::ARGBColors.Black;
			this.label2.Location = new global::System.Drawing.Point(303, 237);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(19, 13);
			this.label2.TabIndex = 15;
			this.label2.Text = "15";
			this.lblDuration.BackColor = global::ARGBColors.Transparent;
			this.lblDuration.ForeColor = global::ARGBColors.Black;
			this.lblDuration.Location = new global::System.Drawing.Point(102, 162);
			this.lblDuration.Name = "lblDuration";
			this.lblDuration.Size = new global::System.Drawing.Size(223, 13);
			this.lblDuration.TabIndex = 16;
			this.lblDuration.Text = "Vacation Duration";
			this.lblDuration.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.lblNumberVacationLabel.BackColor = global::ARGBColors.Transparent;
			this.lblNumberVacationLabel.ForeColor = global::ARGBColors.Black;
			this.lblNumberVacationLabel.Location = new global::System.Drawing.Point(1, 97);
			this.lblNumberVacationLabel.Name = "lblNumberVacationLabel";
			this.lblNumberVacationLabel.Size = new global::System.Drawing.Size(422, 21);
			this.lblNumberVacationLabel.TabIndex = 17;
			this.lblNumberVacationLabel.Text = "Number of Vacations Available";
			this.lblNumberVacationLabel.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.lblNumAvailable.BackColor = global::ARGBColors.Transparent;
			this.lblNumAvailable.ForeColor = global::ARGBColors.Black;
			this.lblNumAvailable.Location = new global::System.Drawing.Point(1, 121);
			this.lblNumAvailable.Name = "lblNumAvailable";
			this.lblNumAvailable.Size = new global::System.Drawing.Size(422, 21);
			this.lblNumAvailable.TabIndex = 18;
			this.lblNumAvailable.Text = "0";
			this.lblNumAvailable.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.btnStartVacation.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnStartVacation.BackColor = global::System.Drawing.Color.FromArgb(203, 215, 223);
			this.btnStartVacation.BorderColor = global::ARGBColors.DarkBlue;
			this.btnStartVacation.BorderDrawing = true;
			this.btnStartVacation.FocusRectangleEnabled = false;
			this.btnStartVacation.Image = null;
			this.btnStartVacation.ImageBorderColor = global::ARGBColors.Chocolate;
			this.btnStartVacation.ImageBorderEnabled = true;
			this.btnStartVacation.ImageDropShadow = true;
			this.btnStartVacation.ImageFocused = null;
			this.btnStartVacation.ImageInactive = null;
			this.btnStartVacation.ImageMouseOver = null;
			this.btnStartVacation.ImageNormal = null;
			this.btnStartVacation.ImagePressed = null;
			this.btnStartVacation.InnerBorderColor = global::ARGBColors.LightGray;
			this.btnStartVacation.InnerBorderColor_Focus = global::ARGBColors.LightBlue;
			this.btnStartVacation.InnerBorderColor_MouseOver = global::ARGBColors.Gold;
			this.btnStartVacation.Location = new global::System.Drawing.Point(283, 264);
			this.btnStartVacation.Name = "btnStartVacation";
			this.btnStartVacation.OffsetPressedContent = true;
			this.btnStartVacation.Padding2 = 5;
			this.btnStartVacation.Size = new global::System.Drawing.Size(129, 26);
			this.btnStartVacation.StretchImage = false;
			this.btnStartVacation.TabIndex = 20;
			this.btnStartVacation.Text = "Start Vacation";
			this.btnStartVacation.TextDropShadow = false;
			this.btnStartVacation.UseVisualStyleBackColor = false;
			this.btnStartVacation.Click += new global::System.EventHandler(this.btnStartVacation_Click);
			this.btnCancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnCancel.BackColor = global::System.Drawing.Color.FromArgb(203, 215, 223);
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
			this.btnCancel.Location = new global::System.Drawing.Point(14, 264);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.OffsetPressedContent = true;
			this.btnCancel.Padding2 = 5;
			this.btnCancel.Size = new global::System.Drawing.Size(79, 26);
			this.btnCancel.StretchImage = false;
			this.btnCancel.TabIndex = 19;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.TextDropShadow = false;
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.lblDurationValue.AutoSize = true;
			this.lblDurationValue.BackColor = global::ARGBColors.Transparent;
			this.lblDurationValue.ForeColor = global::ARGBColors.Black;
			this.lblDurationValue.Location = new global::System.Drawing.Point(341, 195);
			this.lblDurationValue.Name = "lblDurationValue";
			this.lblDurationValue.Size = new global::System.Drawing.Size(19, 13);
			this.lblDurationValue.TabIndex = 21;
			this.lblDurationValue.Text = "15";
			this.lblDays.BackColor = global::ARGBColors.Transparent;
			this.lblDays.ForeColor = global::ARGBColors.Black;
			this.lblDays.Location = new global::System.Drawing.Point(128, 237);
			this.lblDays.Name = "lblDays";
			this.lblDays.Size = new global::System.Drawing.Size(173, 13);
			this.lblDays.TabIndex = 22;
			this.lblDays.Text = "Days";
			this.lblDays.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.lblExplanation.BackColor = global::ARGBColors.Transparent;
			this.lblExplanation.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold);
			this.lblExplanation.ForeColor = global::ARGBColors.Black;
			this.lblExplanation.Location = new global::System.Drawing.Point(35, 34);
			this.lblExplanation.Name = "lblExplanation";
			this.lblExplanation.Size = new global::System.Drawing.Size(358, 63);
			this.lblExplanation.TabIndex = 23;
			this.lblExplanation.Text = "Explanation";
			this.lblExplanation.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::System.Drawing.Color.FromArgb(128, 145, 156);
			base.ClientSize = new global::System.Drawing.Size(424, 302);
			base.Controls.Add(this.lblExplanation);
			base.Controls.Add(this.lblDays);
			base.Controls.Add(this.lblDurationValue);
			base.Controls.Add(this.btnStartVacation);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.lblNumAvailable);
			base.Controls.Add(this.lblNumberVacationLabel);
			base.Controls.Add(this.lblDuration);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.trackNumDays);
			base.Controls.Add(this.label1);
			base.Name = "CreateVacationWindow";
			base.ShowClose = true;
			this.Text = "CreateVacationWindow";
			base.Controls.SetChildIndex(this.label1, 0);
			base.Controls.SetChildIndex(this.trackNumDays, 0);
			base.Controls.SetChildIndex(this.label2, 0);
			base.Controls.SetChildIndex(this.lblDuration, 0);
			base.Controls.SetChildIndex(this.lblNumberVacationLabel, 0);
			base.Controls.SetChildIndex(this.lblNumAvailable, 0);
			base.Controls.SetChildIndex(this.btnCancel, 0);
			base.Controls.SetChildIndex(this.btnStartVacation, 0);
			base.Controls.SetChildIndex(this.lblDurationValue, 0);
			base.Controls.SetChildIndex(this.lblDays, 0);
			base.Controls.SetChildIndex(this.lblExplanation, 0);
			((global::System.ComponentModel.ISupportInitialize)this.trackNumDays).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04001130 RID: 4400
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04001131 RID: 4401
		private global::System.Windows.Forms.TrackBar trackNumDays;

		// Token: 0x04001132 RID: 4402
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04001133 RID: 4403
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04001134 RID: 4404
		private global::System.Windows.Forms.Label lblDuration;

		// Token: 0x04001135 RID: 4405
		private global::System.Windows.Forms.Label lblNumberVacationLabel;

		// Token: 0x04001136 RID: 4406
		private global::System.Windows.Forms.Label lblNumAvailable;

		// Token: 0x04001137 RID: 4407
		private global::Kingdoms.BitmapButton btnStartVacation;

		// Token: 0x04001138 RID: 4408
		private global::Kingdoms.BitmapButton btnCancel;

		// Token: 0x04001139 RID: 4409
		private global::System.Windows.Forms.Label lblDurationValue;

		// Token: 0x0400113A RID: 4410
		private global::System.Windows.Forms.Label lblDays;

		// Token: 0x0400113B RID: 4411
		private global::System.Windows.Forms.Label lblExplanation;
	}
}
