using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x02000213 RID: 531
	public class LoginHistoryPanelLine : UserControl
	{
		// Token: 0x06001655 RID: 5717 RVA: 0x00017A5A File Offset: 0x00015C5A
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001656 RID: 5718 RVA: 0x001605E8 File Offset: 0x0015E7E8
		private void InitializeComponent()
		{
			this.lblIP = new Label();
			this.lblLoginTime = new Label();
			this.lblDuration = new Label();
			base.SuspendLayout();
			this.lblIP.Location = new Point(3, 0);
			this.lblIP.Name = "lblIP";
			this.lblIP.Size = new Size(104, 15);
			this.lblIP.TabIndex = 0;
			this.lblIP.Text = "255.255.255.255";
			this.lblLoginTime.Location = new Point(113, 0);
			this.lblLoginTime.Name = "lblLoginTime";
			this.lblLoginTime.Size = new Size(197, 15);
			this.lblLoginTime.TabIndex = 1;
			this.lblLoginTime.Text = "label1";
			this.lblDuration.Location = new Point(316, 0);
			this.lblDuration.Name = "lblDuration";
			this.lblDuration.Size = new Size(91, 15);
			this.lblDuration.TabIndex = 2;
			this.lblDuration.Text = "label1";
			this.lblDuration.TextAlign = ContentAlignment.TopRight;
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.White;
			base.Controls.Add(this.lblDuration);
			base.Controls.Add(this.lblLoginTime);
			base.Controls.Add(this.lblIP);
			base.Name = "LoginHistoryPanelLine";
			base.Size = new Size(410, 18);
			base.ResumeLayout(false);
		}

		// Token: 0x06001657 RID: 5719 RVA: 0x00017A79 File Offset: 0x00015C79
		public LoginHistoryPanelLine()
		{
			this.InitializeComponent();
		}

		// Token: 0x06001658 RID: 5720 RVA: 0x00160790 File Offset: 0x0015E990
		public void init(string ipAddr, DateTime lastTime, TimeSpan duration)
		{
			this.lblIP.Text = ipAddr;
			this.lblLoginTime.Text = lastTime.ToShortTimeString() + "  -  " + lastTime.ToLongDateString();
			if (duration != TimeSpan.MinValue)
			{
				this.lblDuration.Text = VillageMap.createBuildTimeString((int)duration.TotalSeconds);
				return;
			}
			this.lblDuration.Text = "";
		}

		// Token: 0x0400269A RID: 9882
		private IContainer components;

		// Token: 0x0400269B RID: 9883
		private Label lblIP;

		// Token: 0x0400269C RID: 9884
		private Label lblLoginTime;

		// Token: 0x0400269D RID: 9885
		private Label lblDuration;
	}
}
