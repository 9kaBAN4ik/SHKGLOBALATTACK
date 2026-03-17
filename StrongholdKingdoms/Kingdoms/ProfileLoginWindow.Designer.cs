namespace Kingdoms
{
	// Token: 0x02000292 RID: 658
	public partial class ProfileLoginWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x06001DDA RID: 7642 RVA: 0x0001CBC4 File Offset: 0x0001ADC4
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001DDB RID: 7643 RVA: 0x001D0CE4 File Offset: 0x001CEEE4
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Kingdoms.ProfileLoginWindow));
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.browserServerNews = new global::Kingdoms.KingdomsBrowserGecko();
			this.pnlTabs = new global::Kingdoms.NoDrawPanel();
			this.pnlFeedback = new global::Kingdoms.NoDrawPanel();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.btnExit = new global::System.Windows.Forms.Button();
			this.geckoWebBrowser1 = new global::Kingdoms.KingdomsBrowserGecko();
			this.label1 = new global::System.Windows.Forms.Label();
			this.pnlWorlds = new global::Kingdoms.NoDrawPanel();
			this.pnlLogin = new global::Kingdoms.NoDrawPanel();
			this.panel1.SuspendLayout();
			this.pnlFeedback.SuspendLayout();
			base.SuspendLayout();
			this.panel1.BackColor = global::ARGBColors.White;
			this.panel1.Controls.Add(this.browserServerNews);
			this.panel1.Controls.Add(this.pnlTabs);
			this.panel1.Controls.Add(this.pnlFeedback);
			this.panel1.Controls.Add(this.geckoWebBrowser1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(930, 632);
			this.panel1.TabIndex = 280;
			this.browserServerNews.Location = new global::System.Drawing.Point(658, 439);
			this.browserServerNews.MinimumSize = new global::System.Drawing.Size(20, 20);
			this.browserServerNews.Name = "browserServerNews";
			this.browserServerNews.Size = new global::System.Drawing.Size(270, 161);
			this.browserServerNews.TabIndex = 283;
			this.browserServerNews.TabStop = false;
			this.pnlTabs.Location = new global::System.Drawing.Point(0, 0);
			this.pnlTabs.MaximumSize = new global::System.Drawing.Size(658, 39);
			this.pnlTabs.MinimumSize = new global::System.Drawing.Size(658, 39);
			this.pnlTabs.Name = "pnlTabs";
			this.pnlTabs.Size = new global::System.Drawing.Size(658, 39);
			this.pnlTabs.TabIndex = 281;
			this.pnlFeedback.Controls.Add(this.panel2);
			this.pnlFeedback.Controls.Add(this.btnExit);
			this.pnlFeedback.Location = new global::System.Drawing.Point(0, 600);
			this.pnlFeedback.MaximumSize = new global::System.Drawing.Size(930, 32);
			this.pnlFeedback.MinimumSize = new global::System.Drawing.Size(930, 32);
			this.pnlFeedback.Name = "pnlFeedback";
			this.pnlFeedback.Size = new global::System.Drawing.Size(930, 32);
			this.pnlFeedback.TabIndex = 282;
			this.panel2.BackColor = global::ARGBColors.Black;
			this.panel2.Location = new global::System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(930, 1);
			this.panel2.TabIndex = 274;
			this.btnExit.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnExit.Location = new global::System.Drawing.Point(841, 5);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new global::System.Drawing.Size(76, 23);
			this.btnExit.TabIndex = 269;
			this.btnExit.Text = "Exit";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Visible = false;
			this.btnExit.Click += new global::System.EventHandler(this.btnExit_Click);
			this.geckoWebBrowser1.Location = new global::System.Drawing.Point(0, 39);
			this.geckoWebBrowser1.MinimumSize = new global::System.Drawing.Size(20, 20);
			this.geckoWebBrowser1.Name = "geckoWebBrowser1";
			this.geckoWebBrowser1.Size = new global::System.Drawing.Size(658, 561);
			this.geckoWebBrowser1.TabIndex = 279;
			this.geckoWebBrowser1.TabStop = false;
			this.geckoWebBrowser1.ClientFeedback += new global::Kingdoms.ClientFedbackEventHandler(this.geckoWebBrowser1_ClientFeedback);
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::ARGBColors.DarkRed;
			this.label1.Location = new global::System.Drawing.Point(7, 50);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(219, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Connecting to News Server...";
			this.pnlWorlds.BackColor = global::ARGBColors.White;
			this.pnlWorlds.Location = new global::System.Drawing.Point(658, 232);
			this.pnlWorlds.MaximumSize = new global::System.Drawing.Size(270, 207);
			this.pnlWorlds.MinimumSize = new global::System.Drawing.Size(270, 207);
			this.pnlWorlds.Name = "pnlWorlds";
			this.pnlWorlds.Size = new global::System.Drawing.Size(270, 207);
			this.pnlWorlds.TabIndex = 282;
			this.pnlLogin.BackColor = global::ARGBColors.White;
			this.pnlLogin.Location = new global::System.Drawing.Point(658, 0);
			this.pnlLogin.MaximumSize = new global::System.Drawing.Size(270, 232);
			this.pnlLogin.MinimumSize = new global::System.Drawing.Size(270, 232);
			this.pnlLogin.Name = "pnlLogin";
			this.pnlLogin.Size = new global::System.Drawing.Size(270, 300);
			this.pnlLogin.TabIndex = 283;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::ARGBColors.White;
			base.ClientSize = new global::System.Drawing.Size(928, 632);
			base.Controls.Add(this.pnlWorlds);
			base.Controls.Add(this.pnlLogin);
			base.Controls.Add(this.panel1);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ProfileLoginWindow";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ProfileLoginWindow";
			base.Load += new global::System.EventHandler(this.ProfileLoginWindow_Load);
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.ProfileLoginWindow_FormClosed);
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.ProfileLoginWindow_FormClosing);
			base.LocationChanged += new global::System.EventHandler(this.ProfileLoginWindow_LocationChanged);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.pnlFeedback.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04002E9C RID: 11932
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04002E9D RID: 11933
		private global::System.Windows.Forms.Button btnExit;

		// Token: 0x04002E9E RID: 11934
		private global::Kingdoms.KingdomsBrowserGecko geckoWebBrowser1;

		// Token: 0x04002E9F RID: 11935
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04002EA0 RID: 11936
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04002EA1 RID: 11937
		private global::Kingdoms.NoDrawPanel pnlTabs;

		// Token: 0x04002EA2 RID: 11938
		private global::Kingdoms.NoDrawPanel pnlFeedback;

		// Token: 0x04002EA3 RID: 11939
		private global::Kingdoms.NoDrawPanel pnlWorlds;

		// Token: 0x04002EA4 RID: 11940
		private global::Kingdoms.NoDrawPanel pnlLogin;

		// Token: 0x04002EA5 RID: 11941
		private global::Kingdoms.KingdomsBrowserGecko browserServerNews;

		// Token: 0x04002EA6 RID: 11942
		private global::System.Windows.Forms.Panel panel2;
	}
}
