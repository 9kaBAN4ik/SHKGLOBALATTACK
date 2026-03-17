using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020001DC RID: 476
	public partial class FormationPopup : MyFormBase
	{
		// Token: 0x06001204 RID: 4612 RVA: 0x0012EDA4 File Offset: 0x0012CFA4
		public FormationPopup()
		{
			this.InitializeComponent();
			GameEngine.Instance.CastleAttackerSetup.updateOldAttackSetupFilenames();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			base.Title = SK.Text("CastleMapPanel_Manage_Formations", "Manage Formations");
			this.closeCallback = new MyFormBase.MFBClose(this.closeFunction);
			this.pictureBox1.BackgroundImage = GFXLibrary.formations_img;
			this.customPanel.init(this);
			this.pictureBox1.Visible = false;
		}

		// Token: 0x06001205 RID: 4613 RVA: 0x000139A3 File Offset: 0x00011BA3
		public string getCreateText()
		{
			return this.txtSaveName.Text;
		}

		// Token: 0x06001206 RID: 4614 RVA: 0x000139B0 File Offset: 0x00011BB0
		public void setCreateText(string newText)
		{
			this.txtSaveName.Text = newText;
		}

		// Token: 0x06001207 RID: 4615 RVA: 0x000139BE File Offset: 0x00011BBE
		public string getSelectedText()
		{
			return this.txtSelected.Text;
		}

		// Token: 0x06001208 RID: 4616 RVA: 0x000139CB File Offset: 0x00011BCB
		public void setSelectedText(string newText)
		{
			this.txtSelected.Text = newText;
		}

		// Token: 0x06001209 RID: 4617 RVA: 0x000139D9 File Offset: 0x00011BD9
		private void saveFormation()
		{
			if (GameEngine.Instance.CastleAttackerSetup != null)
			{
				GameEngine.Instance.CastleAttackerSetup.memoriseAttackSetup(this.saveName);
			}
		}

		// Token: 0x0600120A RID: 4618 RVA: 0x000139FD File Offset: 0x00011BFD
		private void closeFunction()
		{
			InterfaceMgr.Instance.closeFormationPopup();
		}

		// Token: 0x0600120B RID: 4619 RVA: 0x0012EE40 File Offset: 0x0012D040
		private void txtSaveName_TextChanged(object sender, EventArgs e)
		{
			if (this.txtSaveName.Text.Length != 0)
			{
				string text = this.txtSaveName.Text;
				char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
				char[] array = invalidFileNameChars;
				foreach (char oldChar in array)
				{
					text = text.Replace(oldChar, ' ');
				}
				if (text != this.txtSaveName.Text)
				{
					this.txtSaveName.Text = text;
				}
			}
		}

		// Token: 0x0600120C RID: 4620 RVA: 0x0012EEB8 File Offset: 0x0012D0B8
		private void txtSaveName_KeyPress(object sender, KeyPressEventArgs e)
		{
			char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
			char keyChar = e.KeyChar;
			if (keyChar == '\b')
			{
				return;
			}
			foreach (char c in invalidFileNameChars)
			{
				if (keyChar == c)
				{
					e.Handled = true;
					return;
				}
			}
		}

		// Token: 0x04001855 RID: 6229
		private string saveName = "";
	}
}
