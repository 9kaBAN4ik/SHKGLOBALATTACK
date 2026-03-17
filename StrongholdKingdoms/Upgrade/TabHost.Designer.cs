namespace Upgrade
{
	// Token: 0x02000024 RID: 36
	public partial class TabHost : global::System.Windows.Forms.Form
	{
		// Token: 0x0600017C RID: 380 RVA: 0x00008E0A File Offset: 0x0000700A
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600017D RID: 381 RVA: 0x0003FCAC File Offset: 0x0003DEAC
		private void InitializeComponent()
		{
			this.tabControl1 = new global::System.Windows.Forms.TabControl();
			this.label_TabHostTip = new global::System.Windows.Forms.Label();
			this.checkBox_TabHostKeepOnTop = new global::System.Windows.Forms.CheckBox();
			base.SuspendLayout();
			this.tabControl1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.tabControl1.Location = new global::System.Drawing.Point(3, 33);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new global::System.Drawing.Size(564, 670);
			this.tabControl1.TabIndex = 0;
			this.label_TabHostTip.AutoSize = true;
			this.label_TabHostTip.Location = new global::System.Drawing.Point(12, 9);
			this.label_TabHostTip.Name = "label_TabHostTip";
			this.label_TabHostTip.Size = new global::System.Drawing.Size(192, 13);
			this.label_TabHostTip.TabIndex = 1;
			this.label_TabHostTip.Text = "Closing the window brings the tab back";
			this.checkBox_TabHostKeepOnTop.AutoSize = true;
			this.checkBox_TabHostKeepOnTop.Location = new global::System.Drawing.Point(375, 9);
			this.checkBox_TabHostKeepOnTop.Name = "checkBox_TabHostKeepOnTop";
			this.checkBox_TabHostKeepOnTop.Size = new global::System.Drawing.Size(86, 17);
			this.checkBox_TabHostKeepOnTop.TabIndex = 2;
			this.checkBox_TabHostKeepOnTop.Text = "Stay On Top";
			this.checkBox_TabHostKeepOnTop.UseVisualStyleBackColor = true;
			this.checkBox_TabHostKeepOnTop.CheckedChanged += new global::System.EventHandler(this.checkBox_TabHostKeepOnTop_CheckedChanged);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(564, 703);
			base.Controls.Add(this.checkBox_TabHostKeepOnTop);
			base.Controls.Add(this.label_TabHostTip);
			base.Controls.Add(this.tabControl1);
			this.MinimumSize = new global::System.Drawing.Size(580, 742);
			base.Name = "TabHost";
			this.Text = "TabHost";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.TabHost_FormClosing);
			base.Load += new global::System.EventHandler(this.TabHost_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040002C9 RID: 713
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040002CA RID: 714
		internal global::System.Windows.Forms.TabControl tabControl1;

		// Token: 0x040002CB RID: 715
		private global::System.Windows.Forms.Label label_TabHostTip;

		// Token: 0x040002CC RID: 716
		private global::System.Windows.Forms.CheckBox checkBox_TabHostKeepOnTop;
	}
}
