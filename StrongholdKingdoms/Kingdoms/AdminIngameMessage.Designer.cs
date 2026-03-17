namespace Kingdoms
{
	// Token: 0x020000B6 RID: 182
	public partial class AdminIngameMessage : global::Kingdoms.MyFormBase
	{
		// Token: 0x060004FC RID: 1276 RVA: 0x0000A9D7 File Offset: 0x00008BD7
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x0005FE90 File Offset: 0x0005E090
		private void InitializeComponent()
		{
			new global::System.ComponentModel.ComponentResourceManager(typeof(global::Kingdoms.AdminIngameMessage));
			this.tbMaintenanceMessage = new global::System.Windows.Forms.TextBox();
			this.btnSend = new global::Kingdoms.BitmapButton();
			this.btnCancel = new global::Kingdoms.BitmapButton();
			this.tbDuration = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.tbMaintenanceMessage.Location = new global::System.Drawing.Point(12, 23);
			this.tbMaintenanceMessage.Multiline = true;
			this.tbMaintenanceMessage.Name = "tbMaintenanceMessage";
			this.tbMaintenanceMessage.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
			this.tbMaintenanceMessage.Size = new global::System.Drawing.Size(450, 321);
			this.tbMaintenanceMessage.TabIndex = 0;
			this.btnSend.Location = new global::System.Drawing.Point(387, 360);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new global::System.Drawing.Size(75, 23);
			this.btnSend.TabIndex = 1;
			this.btnSend.Text = "Send";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new global::System.EventHandler(this.btnSend_Click);
			this.btnCancel.Location = new global::System.Drawing.Point(306, 360);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.tbDuration.Location = new global::System.Drawing.Point(12, 360);
			this.tbDuration.Name = "tbDuration";
			this.tbDuration.Size = new global::System.Drawing.Size(100, 20);
			this.tbDuration.TabIndex = 3;
			this.tbDuration.Text = "5";
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(118, 365);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(144, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Message Duration in Minutes";
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(474, 395);
			base.ControlBox = false;
			base.Controls.Add(this.label1);
			base.Controls.Add(this.tbDuration);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnSend);
			base.Controls.Add(this.tbMaintenanceMessage);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.Name = "AdminIngameMessage";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Admin Ingame Message";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040005BE RID: 1470
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040005BF RID: 1471
		private global::System.Windows.Forms.TextBox tbMaintenanceMessage;

		// Token: 0x040005C0 RID: 1472
		private global::Kingdoms.BitmapButton btnSend;

		// Token: 0x040005C1 RID: 1473
		private global::Kingdoms.BitmapButton btnCancel;

		// Token: 0x040005C2 RID: 1474
		private global::System.Windows.Forms.TextBox tbDuration;

		// Token: 0x040005C3 RID: 1475
		private global::System.Windows.Forms.Label label1;
	}
}
