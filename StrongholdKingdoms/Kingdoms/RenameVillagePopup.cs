using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x0200046B RID: 1131
	public partial class RenameVillagePopup : MyFormBase
	{
		// Token: 0x060028CF RID: 10447 RVA: 0x0001E21B File Offset: 0x0001C41B
		public RenameVillagePopup()
		{
			this.InitializeComponent();
		}

		// Token: 0x060028D0 RID: 10448 RVA: 0x001EDFB4 File Offset: 0x001EC1B4
		public void setVillageID(int villageID, string oldName)
		{
			this.parishNameMode = false;
			this.label1.Text = SK.Text("ReinforcementsRetrieval_Original_Name", "Original Name");
			this.label2.Text = SK.Text("ReinforcementsRetrieval_New_Name", "New Name");
			this.btnOK.Text = SK.Text("GENERIC_OK", "OK");
			this.btnCancel.Text = SK.Text("GENERIC_Cancel", "Cancel");
			string text = this.Text = (base.Title = SK.Text("ReinforcementsRetrieval_Rename_Village", "Rename Village"));
			this.m_villageID = villageID;
			this.tbOldName.Text = oldName;
			this.tbNewName.Text = oldName;
			this.btnOK.Enabled = false;
		}

		// Token: 0x060028D1 RID: 10449 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void setParishVillageID(int villageID, string oldName)
		{
		}

		// Token: 0x060028D2 RID: 10450 RVA: 0x0001E230 File Offset: 0x0001C430
		private void btnCancel_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("RenameVillagePopup_cancel");
			base.Close();
		}

		// Token: 0x060028D3 RID: 10451 RVA: 0x001EE080 File Offset: 0x001EC280
		private void btnOK_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("RenameVillagePopup_rename");
			if (this.tbNewName.Text.Length > 0 && this.tbNewName.Text.Length <= 32 && StringValidation.isValidGameString(this.tbNewName.Text) && StringValidation.notAllSpaces(this.tbNewName.Text) && this.tbNewName.Text != this.tbOldName.Text)
			{
				if (this.m_villageID >= 0 && !this.parishNameMode)
				{
					RemoteServices.Instance.set_VillageRename_UserCallBack(new RemoteServices.VillageRename_UserCallBack(this.testCallback));
					RemoteServices.Instance.VillageRename(this.m_villageID, this.tbNewName.Text);
				}
				base.Close();
			}
		}

		// Token: 0x060028D4 RID: 10452 RVA: 0x001EE154 File Offset: 0x001EC354
		public void testCallback(VillageRename_ReturnType returnData)
		{
			if (returnData.Success)
			{
				GameEngine.Instance.World.setVillageName(returnData.villageID, returnData.renamedName);
				if (InterfaceMgr.Instance.getSelectedMenuVillage() == returnData.villageID)
				{
					InterfaceMgr.Instance.getTopRightMenu().setSelectedVillageName(returnData.renamedName, false);
				}
			}
		}

		// Token: 0x060028D5 RID: 10453 RVA: 0x0001E247 File Offset: 0x0001C447
		private void tbNewName_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == 13)
			{
				this.btnOK_Click(sender, e);
			}
		}

		// Token: 0x060028D6 RID: 10454 RVA: 0x0001E25B File Offset: 0x0001C45B
		private void tbNewName_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				this.btnOK_Click(sender, e);
				e.Handled = true;
				return;
			}
			if (!StringValidation.isValidChar(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		// Token: 0x060028D7 RID: 10455 RVA: 0x001EE1AC File Offset: 0x001EC3AC
		private void tbNewName_TextChanged(object sender, EventArgs e)
		{
			if (this.tbNewName.Text.Length > 0 && this.tbNewName.Text.Length <= 32 && StringValidation.isValidGameString(this.tbNewName.Text) && StringValidation.notAllSpaces(this.tbNewName.Text))
			{
				this.btnOK.Enabled = true;
				return;
			}
			this.btnOK.Enabled = false;
		}

		// Token: 0x060028D8 RID: 10456 RVA: 0x001EE220 File Offset: 0x001EC420
		private bool notAllSpaces(string name)
		{
			foreach (char c in name)
			{
				if (c != ' ')
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060028D9 RID: 10457 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void btnHistory_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x040031DD RID: 12765
		private int m_villageID = -1;

		// Token: 0x040031DE RID: 12766
		private bool parishNameMode;
	}
}
