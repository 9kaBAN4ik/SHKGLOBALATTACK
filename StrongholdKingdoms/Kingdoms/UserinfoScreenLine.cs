using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020004BB RID: 1211
	public class UserinfoScreenLine : UserControl
	{
		// Token: 0x06002CB6 RID: 11446 RVA: 0x00020CEA File Offset: 0x0001EEEA
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002CB7 RID: 11447 RVA: 0x0023A938 File Offset: 0x00238B38
		private void InitializeComponent()
		{
			this.lblName = new Label();
			base.SuspendLayout();
			this.lblName.Location = new Point(3, 7);
			this.lblName.Name = "lblName";
			this.lblName.Size = new Size(313, 19);
			this.lblName.TabIndex = 3;
			this.lblName.Text = "Name";
			this.lblName.Click += this.lblName_DoubleClick;
			base.AutoScaleMode = AutoScaleMode.None;
			base.Controls.Add(this.lblName);
			base.Name = "UserinfoScreenLine";
			base.Size = new Size(316, 30);
			base.Click += this.UserinfoScreenLine_DoubleClick;
			base.ResumeLayout(false);
		}

		// Token: 0x06002CB8 RID: 11448 RVA: 0x00020D09 File Offset: 0x0001EF09
		public UserinfoScreenLine()
		{
			this.InitializeComponent();
		}

		// Token: 0x06002CB9 RID: 11449 RVA: 0x0023AA10 File Offset: 0x00238C10
		public void init(string villageName, int villageID)
		{
			this.m_villageID = villageID;
			this.lblName.Text = villageName;
			if (GameEngine.Instance.World.isRegionCapital(villageID))
			{
				Label label = this.lblName;
				label.Text = label.Text + " - (" + SK.Text("UserinfoScreenLine_Parish_Steward", "Parish Steward") + ")";
				return;
			}
			if (GameEngine.Instance.World.isCountyCapital(villageID))
			{
				Label label2 = this.lblName;
				label2.Text = label2.Text + " - (" + SK.Text("UserinfoScreenLine_County_Sheriff", "County Sheriff") + ")";
				return;
			}
			if (GameEngine.Instance.World.isProvinceCapital(villageID))
			{
				Label label3 = this.lblName;
				label3.Text = label3.Text + " - (" + SK.Text("UserinfoScreenLine_Province_Governor", "Province Governor") + ")";
				return;
			}
			if (GameEngine.Instance.World.isCountryCapital(villageID))
			{
				Label label4 = this.lblName;
				label4.Text = label4.Text + " - (" + SK.Text("UserinfoScreenLine_King", "King") + ")";
			}
		}

		// Token: 0x06002CBA RID: 11450 RVA: 0x00009262 File Offset: 0x00007462
		public bool update()
		{
			return false;
		}

		// Token: 0x06002CBB RID: 11451 RVA: 0x0023AB40 File Offset: 0x00238D40
		private void UserinfoScreenLine_DoubleClick(object sender, EventArgs e)
		{
			if (this.m_villageID >= 0)
			{
				if (RemoteServices.Instance.Admin && GameEngine.shiftPressed)
				{
					AGUR agur = new AGUR();
					agur.init(this.m_villageID);
					agur.Show(InterfaceMgr.Instance.ParentForm);
					return;
				}
				GameEngine.Instance.playInterfaceSound("UserinfoScreenLine_village");
				Point villageLocation = GameEngine.Instance.World.getVillageLocation(this.m_villageID);
				InterfaceMgr.Instance.closeParishPanel();
				GameEngine.Instance.World.startMultiStageZoom(10000.0, (double)villageLocation.X, (double)villageLocation.Y);
				InterfaceMgr.Instance.displaySelectedVillagePanel(this.m_villageID, false, true, true, false);
			}
		}

		// Token: 0x06002CBC RID: 11452 RVA: 0x0023AB40 File Offset: 0x00238D40
		private void lblName_DoubleClick(object sender, EventArgs e)
		{
			if (this.m_villageID >= 0)
			{
				if (RemoteServices.Instance.Admin && GameEngine.shiftPressed)
				{
					AGUR agur = new AGUR();
					agur.init(this.m_villageID);
					agur.Show(InterfaceMgr.Instance.ParentForm);
					return;
				}
				GameEngine.Instance.playInterfaceSound("UserinfoScreenLine_village");
				Point villageLocation = GameEngine.Instance.World.getVillageLocation(this.m_villageID);
				InterfaceMgr.Instance.closeParishPanel();
				GameEngine.Instance.World.startMultiStageZoom(10000.0, (double)villageLocation.X, (double)villageLocation.Y);
				InterfaceMgr.Instance.displaySelectedVillagePanel(this.m_villageID, false, true, true, false);
			}
		}

		// Token: 0x040037BA RID: 14266
		private IContainer components;

		// Token: 0x040037BB RID: 14267
		private Label lblName;

		// Token: 0x040037BC RID: 14268
		private int m_villageID = -1;
	}
}
