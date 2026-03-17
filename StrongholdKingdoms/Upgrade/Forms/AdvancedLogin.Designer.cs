namespace Upgrade.Forms
{
	// Token: 0x020000AF RID: 175
	public partial class AdvancedLogin : global::System.Windows.Forms.Form
	{
		// Token: 0x0600047F RID: 1151 RVA: 0x0000A21C File Offset: 0x0000841C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x0005D6A0 File Offset: 0x0005B8A0
		private void InitializeComponent()
		{
			this.label1 = new global::System.Windows.Forms.Label();
			this.textBox_email = new global::System.Windows.Forms.TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.textBox_password = new global::System.Windows.Forms.TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.textBox_MAC = new global::System.Windows.Forms.TextBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.textBox_proxyIP = new global::System.Windows.Forms.TextBox();
			this.textBox_proxyPort = new global::System.Windows.Forms.TextBox();
			this.textBox_proxyUser = new global::System.Windows.Forms.TextBox();
			this.label7 = new global::System.Windows.Forms.Label();
			this.textBox_proxyPass = new global::System.Windows.Forms.TextBox();
			this.button1 = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.label8 = new global::System.Windows.Forms.Label();
			this.label9 = new global::System.Windows.Forms.Label();
			this.button3 = new global::System.Windows.Forms.Button();
			this.label10 = new global::System.Windows.Forms.Label();
			this.button4 = new global::System.Windows.Forms.Button();
			this.checkBox_ShowOnStartup = new global::System.Windows.Forms.CheckBox();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(8, 26);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(32, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Email";
			this.textBox_email.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.textBox_email.Location = new global::System.Drawing.Point(11, 42);
			this.textBox_email.Name = "textBox_email";
			this.textBox_email.Size = new global::System.Drawing.Size(156, 20);
			this.textBox_email.TabIndex = 1;
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(8, 65);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(53, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Password";
			this.textBox_password.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.textBox_password.Location = new global::System.Drawing.Point(11, 81);
			this.textBox_password.Name = "textBox_password";
			this.textBox_password.Size = new global::System.Drawing.Size(156, 20);
			this.textBox_password.TabIndex = 3;
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(8, 104);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(204, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "MAC Address (in format: 012345ABCDEF)";
			this.textBox_MAC.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.textBox_MAC.Location = new global::System.Drawing.Point(11, 120);
			this.textBox_MAC.Name = "textBox_MAC";
			this.textBox_MAC.Size = new global::System.Drawing.Size(156, 20);
			this.textBox_MAC.TabIndex = 5;
			this.textBox_MAC.TextChanged += new global::System.EventHandler(this.textBox_MAC_TextChanged);
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(8, 143);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(46, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Proxy IP";
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(8, 182);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(55, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Proxy Port";
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(8, 221);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(84, 13);
			this.label6.TabIndex = 8;
			this.label6.Text = "Proxy Username";
			this.textBox_proxyIP.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.textBox_proxyIP.Location = new global::System.Drawing.Point(11, 159);
			this.textBox_proxyIP.Name = "textBox_proxyIP";
			this.textBox_proxyIP.Size = new global::System.Drawing.Size(156, 20);
			this.textBox_proxyIP.TabIndex = 9;
			this.textBox_proxyPort.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.textBox_proxyPort.Location = new global::System.Drawing.Point(11, 198);
			this.textBox_proxyPort.Name = "textBox_proxyPort";
			this.textBox_proxyPort.Size = new global::System.Drawing.Size(156, 20);
			this.textBox_proxyPort.TabIndex = 10;
			this.textBox_proxyUser.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.textBox_proxyUser.Location = new global::System.Drawing.Point(11, 237);
			this.textBox_proxyUser.Name = "textBox_proxyUser";
			this.textBox_proxyUser.Size = new global::System.Drawing.Size(156, 20);
			this.textBox_proxyUser.TabIndex = 11;
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(8, 260);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(82, 13);
			this.label7.TabIndex = 12;
			this.label7.Text = "Proxy Password";
			this.textBox_proxyPass.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.textBox_proxyPass.Location = new global::System.Drawing.Point(11, 276);
			this.textBox_proxyPass.Name = "textBox_proxyPass";
			this.textBox_proxyPass.Size = new global::System.Drawing.Size(156, 20);
			this.textBox_proxyPass.TabIndex = 13;
			this.button1.Location = new global::System.Drawing.Point(11, 331);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(75, 23);
			this.button1.TabIndex = 14;
			this.button1.Text = "Save";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button_save_Click);
			this.button2.Location = new global::System.Drawing.Point(92, 331);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(75, 23);
			this.button2.TabIndex = 15;
			this.button2.Text = "Load";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new global::System.EventHandler(this.button_load_Click);
			this.label8.AutoSize = true;
			this.label8.Location = new global::System.Drawing.Point(8, 357);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(300, 13);
			this.label8.TabIndex = 16;
			this.label8.Text = "Every account ideally should have its own unique IP and MAC";
			this.label9.AutoSize = true;
			this.label9.Location = new global::System.Drawing.Point(8, 370);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(190, 13);
			this.label9.TabIndex = 17;
			this.label9.Text = "Non of this information is sent to author";
			this.button3.Location = new global::System.Drawing.Point(11, 302);
			this.button3.Name = "button3";
			this.button3.Size = new global::System.Drawing.Size(75, 23);
			this.button3.TabIndex = 18;
			this.button3.Text = "Test";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new global::System.EventHandler(this.button_test_Click);
			this.label10.Location = new global::System.Drawing.Point(8, 383);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(236, 75);
			this.label10.TabIndex = 19;
			this.label10.Text = "This form should help You to play with new account in case if the old account is banned. Multi-accounting is not allowed according to game rules. There is no guarantee that you will not get banned!";
			this.button4.Location = new global::System.Drawing.Point(92, 302);
			this.button4.Name = "button4";
			this.button4.Size = new global::System.Drawing.Size(75, 23);
			this.button4.TabIndex = 20;
			this.button4.Text = "Apply";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new global::System.EventHandler(this.button_apply_Click);
			this.checkBox_ShowOnStartup.AutoSize = true;
			this.checkBox_ShowOnStartup.Location = new global::System.Drawing.Point(11, 6);
			this.checkBox_ShowOnStartup.Name = "checkBox_ShowOnStartup";
			this.checkBox_ShowOnStartup.Size = new global::System.Drawing.Size(162, 17);
			this.checkBox_ShowOnStartup.TabIndex = 21;
			this.checkBox_ShowOnStartup.Text = "Show this form on game start";
			this.checkBox_ShowOnStartup.UseVisualStyleBackColor = true;
			this.checkBox_ShowOnStartup.CheckedChanged += new global::System.EventHandler(this.checkBox_ShowOnStartup_CheckedChanged);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(338, 469);
			base.Controls.Add(this.checkBox_ShowOnStartup);
			base.Controls.Add(this.button4);
			base.Controls.Add(this.label10);
			base.Controls.Add(this.button3);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.textBox_proxyPass);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.textBox_proxyUser);
			base.Controls.Add(this.textBox_proxyPort);
			base.Controls.Add(this.textBox_proxyIP);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.textBox_MAC);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.textBox_password);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.textBox_email);
			base.Controls.Add(this.label1);
			base.MaximizeBox = false;
			this.MinimumSize = new global::System.Drawing.Size(354, 489);
			base.Name = "AdvancedLogin";
			this.Text = "Advanced Login (test version)";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000587 RID: 1415
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000588 RID: 1416
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000589 RID: 1417
		private global::System.Windows.Forms.TextBox textBox_email;

		// Token: 0x0400058A RID: 1418
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400058B RID: 1419
		private global::System.Windows.Forms.TextBox textBox_password;

		// Token: 0x0400058C RID: 1420
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400058D RID: 1421
		private global::System.Windows.Forms.TextBox textBox_MAC;

		// Token: 0x0400058E RID: 1422
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400058F RID: 1423
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000590 RID: 1424
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000591 RID: 1425
		private global::System.Windows.Forms.TextBox textBox_proxyIP;

		// Token: 0x04000592 RID: 1426
		private global::System.Windows.Forms.TextBox textBox_proxyPort;

		// Token: 0x04000593 RID: 1427
		private global::System.Windows.Forms.TextBox textBox_proxyUser;

		// Token: 0x04000594 RID: 1428
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000595 RID: 1429
		private global::System.Windows.Forms.TextBox textBox_proxyPass;

		// Token: 0x04000596 RID: 1430
		private global::System.Windows.Forms.Button button1;

		// Token: 0x04000597 RID: 1431
		private global::System.Windows.Forms.Button button2;

		// Token: 0x04000598 RID: 1432
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000599 RID: 1433
		private global::System.Windows.Forms.Label label9;

		// Token: 0x0400059A RID: 1434
		private global::System.Windows.Forms.Button button3;

		// Token: 0x0400059B RID: 1435
		private global::System.Windows.Forms.Label label10;

		// Token: 0x0400059C RID: 1436
		private global::System.Windows.Forms.Button button4;

		// Token: 0x0400059D RID: 1437
		private global::System.Windows.Forms.CheckBox checkBox_ShowOnStartup;
	}
}
