namespace Kingdoms
{
	// Token: 0x02000197 RID: 407
	public partial class DebugPopup : global::System.Windows.Forms.Form
	{
		// Token: 0x06000FB6 RID: 4022 RVA: 0x00011717 File Offset: 0x0000F917
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000FB7 RID: 4023 RVA: 0x00114690 File Offset: 0x00112890
		private void InitializeComponent()
		{
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.lblNetworkDataSent = new global::System.Windows.Forms.Label();
			this.lblNetworkDataReceived = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.lblAverageRTT = new global::System.Windows.Forms.Label();
			this.lblAverageLongRTT = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.lblTimeouts = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.lblAverageShortRTT = new global::System.Windows.Forms.Label();
			this.label9 = new global::System.Windows.Forms.Label();
			this.lblShortCount = new global::System.Windows.Forms.Label();
			this.lblLongCount = new global::System.Windows.Forms.Label();
			this.tbDetailedLogging = new global::System.Windows.Forms.TextBox();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(12, 26);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(98, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Network Data Sent";
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(12, 51);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(122, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Network Data Received";
			this.lblNetworkDataSent.AutoSize = true;
			this.lblNetworkDataSent.Location = new global::System.Drawing.Point(139, 26);
			this.lblNetworkDataSent.Name = "lblNetworkDataSent";
			this.lblNetworkDataSent.Size = new global::System.Drawing.Size(13, 13);
			this.lblNetworkDataSent.TabIndex = 2;
			this.lblNetworkDataSent.Text = "0";
			this.lblNetworkDataReceived.AutoSize = true;
			this.lblNetworkDataReceived.Location = new global::System.Drawing.Point(139, 51);
			this.lblNetworkDataReceived.Name = "lblNetworkDataReceived";
			this.lblNetworkDataReceived.Size = new global::System.Drawing.Size(13, 13);
			this.lblNetworkDataReceived.TabIndex = 3;
			this.lblNetworkDataReceived.Text = "0";
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(12, 76);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(72, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Average RTT";
			this.lblAverageRTT.AutoSize = true;
			this.lblAverageRTT.Location = new global::System.Drawing.Point(139, 76);
			this.lblAverageRTT.Name = "lblAverageRTT";
			this.lblAverageRTT.Size = new global::System.Drawing.Size(13, 13);
			this.lblAverageRTT.TabIndex = 5;
			this.lblAverageRTT.Text = "0";
			this.lblAverageLongRTT.AutoSize = true;
			this.lblAverageLongRTT.Location = new global::System.Drawing.Point(139, 127);
			this.lblAverageLongRTT.Name = "lblAverageLongRTT";
			this.lblAverageLongRTT.Size = new global::System.Drawing.Size(13, 13);
			this.lblAverageLongRTT.TabIndex = 7;
			this.lblAverageLongRTT.Text = "0";
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(12, 127);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(99, 13);
			this.label5.TabIndex = 6;
			this.label5.Text = "Average Long RTT";
			this.lblTimeouts.AutoSize = true;
			this.lblTimeouts.Location = new global::System.Drawing.Point(139, 155);
			this.lblTimeouts.Name = "lblTimeouts";
			this.lblTimeouts.Size = new global::System.Drawing.Size(13, 13);
			this.lblTimeouts.TabIndex = 9;
			this.lblTimeouts.Text = "0";
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(12, 155);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(50, 13);
			this.label7.TabIndex = 8;
			this.label7.Text = "Timeouts";
			this.lblAverageShortRTT.AutoSize = true;
			this.lblAverageShortRTT.Location = new global::System.Drawing.Point(139, 102);
			this.lblAverageShortRTT.Name = "lblAverageShortRTT";
			this.lblAverageShortRTT.Size = new global::System.Drawing.Size(13, 13);
			this.lblAverageShortRTT.TabIndex = 11;
			this.lblAverageShortRTT.Text = "0";
			this.label9.AutoSize = true;
			this.label9.Location = new global::System.Drawing.Point(12, 102);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(100, 13);
			this.label9.TabIndex = 10;
			this.label9.Text = "Average Short RTT";
			this.lblShortCount.AutoSize = true;
			this.lblShortCount.Location = new global::System.Drawing.Point(242, 102);
			this.lblShortCount.Name = "lblShortCount";
			this.lblShortCount.Size = new global::System.Drawing.Size(13, 13);
			this.lblShortCount.TabIndex = 13;
			this.lblShortCount.Text = "0";
			this.lblLongCount.AutoSize = true;
			this.lblLongCount.Location = new global::System.Drawing.Point(242, 127);
			this.lblLongCount.Name = "lblLongCount";
			this.lblLongCount.Size = new global::System.Drawing.Size(13, 13);
			this.lblLongCount.TabIndex = 12;
			this.lblLongCount.Text = "0";
			this.tbDetailedLogging.Location = new global::System.Drawing.Point(12, 184);
			this.tbDetailedLogging.Multiline = true;
			this.tbDetailedLogging.Name = "tbDetailedLogging";
			this.tbDetailedLogging.ReadOnly = true;
			this.tbDetailedLogging.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
			this.tbDetailedLogging.Size = new global::System.Drawing.Size(295, 136);
			this.tbDetailedLogging.TabIndex = 14;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(319, 332);
			base.Controls.Add(this.tbDetailedLogging);
			base.Controls.Add(this.lblShortCount);
			base.Controls.Add(this.lblLongCount);
			base.Controls.Add(this.lblAverageShortRTT);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.lblTimeouts);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.lblAverageLongRTT);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.lblAverageRTT);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.lblNetworkDataReceived);
			base.Controls.Add(this.lblNetworkDataSent);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Name = "DebugPopup";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Debug";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040015D2 RID: 5586
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040015D3 RID: 5587
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040015D4 RID: 5588
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040015D5 RID: 5589
		private global::System.Windows.Forms.Label lblNetworkDataSent;

		// Token: 0x040015D6 RID: 5590
		private global::System.Windows.Forms.Label lblNetworkDataReceived;

		// Token: 0x040015D7 RID: 5591
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040015D8 RID: 5592
		private global::System.Windows.Forms.Label lblAverageRTT;

		// Token: 0x040015D9 RID: 5593
		private global::System.Windows.Forms.Label lblAverageLongRTT;

		// Token: 0x040015DA RID: 5594
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040015DB RID: 5595
		private global::System.Windows.Forms.Label lblTimeouts;

		// Token: 0x040015DC RID: 5596
		private global::System.Windows.Forms.Label label7;

		// Token: 0x040015DD RID: 5597
		private global::System.Windows.Forms.Label lblAverageShortRTT;

		// Token: 0x040015DE RID: 5598
		private global::System.Windows.Forms.Label label9;

		// Token: 0x040015DF RID: 5599
		private global::System.Windows.Forms.Label lblShortCount;

		// Token: 0x040015E0 RID: 5600
		private global::System.Windows.Forms.Label lblLongCount;

		// Token: 0x040015E1 RID: 5601
		private global::System.Windows.Forms.TextBox tbDetailedLogging;
	}
}
