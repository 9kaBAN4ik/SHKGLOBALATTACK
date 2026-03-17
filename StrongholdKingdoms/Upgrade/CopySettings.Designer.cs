namespace Upgrade
{
	// Token: 0x0200001D RID: 29
	public partial class CopySettings : global::System.Windows.Forms.Form
	{
		// Token: 0x0600015A RID: 346 RVA: 0x00008BFC File Offset: 0x00006DFC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600015B RID: 347 RVA: 0x0003F124 File Offset: 0x0003D324
		private void InitializeComponent()
		{
			this.listBox_Modules = new global::System.Windows.Forms.ListBox();
			this.listBox_Villages = new global::System.Windows.Forms.ListBox();
			this.comboBox_Villages = new global::System.Windows.Forms.ComboBox();
			this.button_Copy = new global::System.Windows.Forms.Button();
			this.checkBox_Modules = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Villages = new global::System.Windows.Forms.CheckBox();
			this.checkBox_saveSettings = new global::System.Windows.Forms.CheckBox();
			base.SuspendLayout();
			this.listBox_Modules.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.listBox_Modules.FormattingEnabled = true;
			this.listBox_Modules.Location = new global::System.Drawing.Point(12, 34);
			this.listBox_Modules.Name = "listBox_Modules";
			this.listBox_Modules.SelectionMode = global::System.Windows.Forms.SelectionMode.MultiSimple;
			this.listBox_Modules.Size = new global::System.Drawing.Size(135, 199);
			this.listBox_Modules.TabIndex = 0;
			this.listBox_Villages.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.listBox_Villages.FormattingEnabled = true;
			this.listBox_Villages.Location = new global::System.Drawing.Point(296, 34);
			this.listBox_Villages.Name = "listBox_Villages";
			this.listBox_Villages.SelectionMode = global::System.Windows.Forms.SelectionMode.MultiSimple;
			this.listBox_Villages.Size = new global::System.Drawing.Size(156, 329);
			this.listBox_Villages.TabIndex = 1;
			this.comboBox_Villages.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_Villages.FormattingEnabled = true;
			this.comboBox_Villages.Location = new global::System.Drawing.Point(153, 34);
			this.comboBox_Villages.Name = "comboBox_Villages";
			this.comboBox_Villages.Size = new global::System.Drawing.Size(137, 21);
			this.comboBox_Villages.TabIndex = 2;
			this.button_Copy.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.button_Copy.Location = new global::System.Drawing.Point(12, 327);
			this.button_Copy.Name = "button_Copy";
			this.button_Copy.Size = new global::System.Drawing.Size(86, 31);
			this.button_Copy.TabIndex = 3;
			this.button_Copy.Text = "Copy";
			this.button_Copy.UseVisualStyleBackColor = true;
			this.button_Copy.Click += new global::System.EventHandler(this.button_Copy_Click);
			this.checkBox_Modules.AutoSize = true;
			this.checkBox_Modules.Location = new global::System.Drawing.Point(133, 12);
			this.checkBox_Modules.Name = "checkBox_Modules";
			this.checkBox_Modules.Size = new global::System.Drawing.Size(15, 14);
			this.checkBox_Modules.TabIndex = 4;
			this.checkBox_Modules.UseVisualStyleBackColor = true;
			this.checkBox_Modules.CheckedChanged += new global::System.EventHandler(this.checkBox_Modules_CheckedChanged);
			this.checkBox_Villages.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.checkBox_Villages.AutoSize = true;
			this.checkBox_Villages.Location = new global::System.Drawing.Point(437, 12);
			this.checkBox_Villages.Name = "checkBox_Villages";
			this.checkBox_Villages.Size = new global::System.Drawing.Size(15, 14);
			this.checkBox_Villages.TabIndex = 5;
			this.checkBox_Villages.UseVisualStyleBackColor = true;
			this.checkBox_Villages.CheckedChanged += new global::System.EventHandler(this.checkBox_Villages_CheckedChanged);
			this.checkBox_saveSettings.AutoSize = true;
			this.checkBox_saveSettings.Location = new global::System.Drawing.Point(13, 304);
			this.checkBox_saveSettings.Name = "checkBox_saveSettings";
			this.checkBox_saveSettings.Size = new global::System.Drawing.Size(152, 17);
			this.checkBox_saveSettings.TabIndex = 6;
			this.checkBox_saveSettings.Text = "Save (Rewrite old settings)";
			this.checkBox_saveSettings.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(462, 370);
			base.Controls.Add(this.checkBox_saveSettings);
			base.Controls.Add(this.checkBox_Villages);
			base.Controls.Add(this.checkBox_Modules);
			base.Controls.Add(this.button_Copy);
			base.Controls.Add(this.comboBox_Villages);
			base.Controls.Add(this.listBox_Villages);
			base.Controls.Add(this.listBox_Modules);
			base.Name = "CopySettings";
			this.Text = "CopySettings v2.0";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040002AB RID: 683
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040002AC RID: 684
		private global::System.Windows.Forms.ListBox listBox_Modules;

		// Token: 0x040002AD RID: 685
		private global::System.Windows.Forms.ListBox listBox_Villages;

		// Token: 0x040002AE RID: 686
		private global::System.Windows.Forms.ComboBox comboBox_Villages;

		// Token: 0x040002AF RID: 687
		private global::System.Windows.Forms.Button button_Copy;

		// Token: 0x040002B0 RID: 688
		private global::System.Windows.Forms.CheckBox checkBox_Modules;

		// Token: 0x040002B1 RID: 689
		private global::System.Windows.Forms.CheckBox checkBox_Villages;

		// Token: 0x040002B2 RID: 690
		private global::System.Windows.Forms.CheckBox checkBox_saveSettings;
	}
}
