namespace Kingdoms
{
	// Token: 0x020000B2 RID: 178
	public partial class AboutPopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x060004DA RID: 1242 RVA: 0x0000A82A File Offset: 0x00008A2A
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x0005E27C File Offset: 0x0005C47C
		private void InitializeComponent()
		{
			int num = 0;
			int num2 = 0;
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.linkLabel1 = new global::System.Windows.Forms.LinkLabel();
			this.lblVersionNumber = new global::System.Windows.Forms.Label();
			this.lblCredits = new global::System.Windows.Forms.LinkLabel();
			this.lblSlimDX = new global::System.Windows.Forms.Label();
			this.lblGeckFX = new global::System.Windows.Forms.Label();
			this.lblXMLRPC = new global::System.Windows.Forms.Label();
			this.lblZLIB = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.label1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.label1.BackColor = global::ARGBColors.Transparent;
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 14f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(14 - num2, 50);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(337 + num, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Stronghold Kingdoms";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.label2.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.label2.BackColor = global::ARGBColors.Transparent;
			this.label2.Location = new global::System.Drawing.Point(14 - num2, 83);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(337 + num, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "(c)2010 Firefly Studios Ltd";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.linkLabel1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.linkLabel1.BackColor = global::ARGBColors.Transparent;
			this.linkLabel1.Location = new global::System.Drawing.Point(12, 282);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new global::System.Drawing.Size(337 + num, 13);
			this.linkLabel1.TabIndex = 2;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "www.strongholdkingdoms.com";
			this.linkLabel1.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.linkLabel1.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			this.lblVersionNumber.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.lblVersionNumber.BackColor = global::ARGBColors.Transparent;
			this.lblVersionNumber.Location = new global::System.Drawing.Point(13 - num2, 313);
			this.lblVersionNumber.Name = "lblVersionNumber";
			this.lblVersionNumber.Size = new global::System.Drawing.Size(337 + num, 13);
			this.lblVersionNumber.TabIndex = 6;
			this.lblVersionNumber.Text = "1.1.1.1";
			this.lblVersionNumber.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.lblCredits.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.lblCredits.BackColor = global::ARGBColors.Transparent;
			this.lblCredits.Location = new global::System.Drawing.Point(12, 251);
			this.lblCredits.Name = "lblCredits";
			this.lblCredits.Size = new global::System.Drawing.Size(337 + num, 13);
			this.lblCredits.TabIndex = 12;
			this.lblCredits.TabStop = true;
			this.lblCredits.Text = "Credits";
			this.lblCredits.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.lblCredits.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCredits_LinkClicked);
			this.lblSlimDX.AutoSize = true;
			this.lblSlimDX.BackColor = global::ARGBColors.Transparent;
			this.lblSlimDX.Location = new global::System.Drawing.Point(67 - num2, 118);
			this.lblSlimDX.Name = "lblSlimDX";
			this.lblSlimDX.Size = new global::System.Drawing.Size(226 + num, 13);
			this.lblSlimDX.TabIndex = 13;
			this.lblSlimDX.Text = "SlimDX Copyright (c) 2007-2010 SlimDX Group";
			this.lblGeckFX.AutoSize = true;
			this.lblGeckFX.BackColor = global::ARGBColors.Transparent;
			this.lblGeckFX.Location = new global::System.Drawing.Point(63 - num2, 144);
			this.lblGeckFX.Name = "lblGeckFX";
			this.lblGeckFX.Size = new global::System.Drawing.Size(234 + num, 13);
			this.lblGeckFX.TabIndex = 14;
			this.lblGeckFX.Text = "GeckoFX Copyright © 2008 Skybound Software";
			this.lblXMLRPC.AutoSize = true;
			this.lblXMLRPC.BackColor = global::ARGBColors.Transparent;
			this.lblXMLRPC.Location = new global::System.Drawing.Point(63 - num2, 170);
			this.lblXMLRPC.Name = "lblXMLRPC";
			this.lblXMLRPC.Size = new global::System.Drawing.Size(234 + num, 13);
			this.lblXMLRPC.TabIndex = 15;
			this.lblXMLRPC.Text = "XML-RPC.NET Copyright (c) 2006 Charles Cook";
			this.lblZLIB.AutoSize = true;
			this.lblZLIB.BackColor = global::ARGBColors.Transparent;
			this.lblZLIB.Location = new global::System.Drawing.Point(35 - num2, 196);
			this.lblZLIB.Name = "lblZLIB";
			this.lblZLIB.Size = new global::System.Drawing.Size(291 + num, 13);
			this.lblZLIB.TabIndex = 16;
			this.lblZLIB.Text = "zlib Copyright (C) 1995-2004 Jean-loup Gailly and Mark Adler";
			this.label4.AutoSize = true;
			this.label4.BackColor = global::ARGBColors.Transparent;
			this.label4.Location = new global::System.Drawing.Point(74 - num2, 222);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(212 + num, 13);
			this.label4.TabIndex = 17;
			this.label4.Text = "NAudio Copyright (C) 2007 Ray Molenkamp";
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(361 * global::Kingdoms.InterfaceMgr.UIScale, 335 * global::Kingdoms.InterfaceMgr.UIScale);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.lblZLIB);
			base.Controls.Add(this.lblXMLRPC);
			base.Controls.Add(this.lblGeckFX);
			base.Controls.Add(this.lblSlimDX);
			base.Controls.Add(this.lblCredits);
			base.Controls.Add(this.lblVersionNumber);
			base.Controls.Add(this.linkLabel1);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "AboutPopup";
			base.ShowClose = true;
			base.ShowIcon = false;
			this.Text = "About Stronghold Kingdoms";
			base.Controls.SetChildIndex(this.label1, 0);
			base.Controls.SetChildIndex(this.label2, 0);
			base.Controls.SetChildIndex(this.linkLabel1, 0);
			base.Controls.SetChildIndex(this.lblVersionNumber, 0);
			base.Controls.SetChildIndex(this.lblCredits, 0);
			base.Controls.SetChildIndex(this.lblSlimDX, 0);
			base.Controls.SetChildIndex(this.lblGeckFX, 0);
			base.Controls.SetChildIndex(this.lblXMLRPC, 0);
			base.Controls.SetChildIndex(this.lblZLIB, 0);
			base.Controls.SetChildIndex(this.label4, 0);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040005A1 RID: 1441
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040005A2 RID: 1442
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040005A3 RID: 1443
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040005A4 RID: 1444
		private global::System.Windows.Forms.LinkLabel linkLabel1;

		// Token: 0x040005A5 RID: 1445
		private global::System.Windows.Forms.Label lblVersionNumber;

		// Token: 0x040005A6 RID: 1446
		private global::System.Windows.Forms.LinkLabel lblCredits;

		// Token: 0x040005A7 RID: 1447
		private global::System.Windows.Forms.Label lblSlimDX;

		// Token: 0x040005A8 RID: 1448
		private global::System.Windows.Forms.Label lblGeckFX;

		// Token: 0x040005A9 RID: 1449
		private global::System.Windows.Forms.Label lblXMLRPC;

		// Token: 0x040005AA RID: 1450
		private global::System.Windows.Forms.Label lblZLIB;

		// Token: 0x040005AB RID: 1451
		private global::System.Windows.Forms.Label label4;
	}
}
