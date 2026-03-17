namespace Kingdoms
{
	// Token: 0x02000277 RID: 631
	public partial class PlayCardsWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x06001C65 RID: 7269 RVA: 0x0001BDDE File Offset: 0x00019FDE
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001C66 RID: 7270 RVA: 0x001BBE70 File Offset: 0x001BA070
		private void InitializeComponent()
		{
			new global::System.ComponentModel.ComponentResourceManager(typeof(global::Kingdoms.PlayCardsWindow));
			this.currentPanel = new global::Kingdoms.PlayCardsPanel();
			this.tbSearchBox = new global::System.Windows.Forms.TextBox();
			base.SuspendLayout();
			this.currentPanel.Location = new global::System.Drawing.Point(0, 0);
			this.currentPanel.Name = "cardPanel";
			this.currentPanel.Size = new global::System.Drawing.Size(1000, 600);
			this.currentPanel.StoredGraphics = null;
			this.currentPanel.TabIndex = 0;
			this.tbSearchBox.Name = "tbSearchBox";
			this.tbSearchBox.Location = new global::System.Drawing.Point(770, 7);
			this.tbSearchBox.Size = new global::System.Drawing.Size(160, 20);
			this.tbSearchBox.TabIndex = 1;
			this.tbSearchBox.TextChanged += new global::System.EventHandler(this.tbSearchBox_TextChanged);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(1000, 600);
			base.ControlBox = false;
			base.Controls.Add(this.currentPanel);
			base.Controls.Add(this.tbSearchBox);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "PlayCardsWindow";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "PlayCardsWindow";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.PlayCardsWindow_FormClosing);
			base.ResumeLayout(false);
		}

		// Token: 0x04002D21 RID: 11553
		private global::Kingdoms.CustomSelfDrawPanel currentPanel;

		// Token: 0x04002D33 RID: 11571
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04002D34 RID: 11572
		public global::System.Windows.Forms.TextBox tbSearchBox;
	}
}
