using System;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000280 RID: 640
	public class PresetEditPanel : CustomSelfDrawPanel
	{
		// Token: 0x06001CBF RID: 7359 RVA: 0x0001C24A File Offset: 0x0001A44A
		public PresetEditPanel()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06001CC0 RID: 7360 RVA: 0x001C2A00 File Offset: 0x001C0C00
		public void init(MyFormBase parent, PresetLine line)
		{
			this.m_parent = parent;
			this.m_line = line;
			base.Size = this.m_parent.Size;
			this.BackColor = global::ARGBColors.Transparent;
			this.nameLabel.Text = SK.Text("Preset_Name", "Preset Name");
			this.nameLabel.Color = global::ARGBColors.Black;
			this.nameLabel.Size = new Size(base.Width, 28);
			this.nameLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.nameLabel.Position = new Point(0, 15);
			this.nameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			base.addControl(this.nameLabel);
			this.renameButton.ImageNorm = GFXLibrary.button_132_normal;
			this.renameButton.ImageOver = GFXLibrary.button_132_over;
			this.renameButton.ImageClick = GFXLibrary.button_132_in;
			this.renameButton.setSizeToImage();
			this.renameButton.Position = new Point(base.Width / 4 - this.renameButton.Width / 2, base.Height / 2 - this.renameButton.Height / 2 + 10);
			this.renameButton.Text.Text = SK.Text("GENERIC_OK", "OK");
			this.renameButton.TextYOffset = -2;
			this.renameButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.renameClick));
			base.addControl(this.renameButton);
			this.cancelButton.ImageNorm = GFXLibrary.button_132_normal;
			this.cancelButton.ImageOver = GFXLibrary.button_132_over;
			this.cancelButton.ImageClick = GFXLibrary.button_132_in;
			this.cancelButton.setSizeToImage();
			this.cancelButton.Position = new Point(base.Width * 3 / 4 - this.cancelButton.Width / 2, base.Height / 2 - this.cancelButton.Height / 2 + 10);
			this.cancelButton.Text.Text = SK.Text("GENERIC_Cancel", "Cancel");
			this.cancelButton.TextYOffset = -2;
			this.cancelButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.cancelClick));
			base.addControl(this.cancelButton);
		}

		// Token: 0x06001CC1 RID: 7361 RVA: 0x0001C27F File Offset: 0x0001A47F
		public void renameClick()
		{
			if (this.m_name == null)
			{
				this.m_name = "";
			}
			this.m_line.onNameChange(this.m_name);
			this.m_parent.Close();
			this.verifyName();
		}

		// Token: 0x06001CC2 RID: 7362 RVA: 0x0001C2B6 File Offset: 0x0001A4B6
		private void cancelClick()
		{
			this.m_parent.Close();
			this.verifyName();
		}

		// Token: 0x06001CC3 RID: 7363 RVA: 0x001C2C74 File Offset: 0x001C0E74
		private void verifyName()
		{
			if (this.m_line != null && this.m_line.GetPreset().Name.Trim().Length == 0 && this.m_line.GetPreset().ElementCount > 0)
			{
				string txtMessage = SK.Text("Preset_Name_Warning", "Warning: Preset will be renamed if a valid name is not provided");
				MyMessageBox.Show(txtMessage);
			}
		}

		// Token: 0x06001CC4 RID: 7364 RVA: 0x0001C2C9 File Offset: 0x0001A4C9
		public void setName(string name)
		{
			this.m_name = name;
		}

		// Token: 0x04002DAB RID: 11691
		private CustomSelfDrawPanel.CSDLabel nameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002DAC RID: 11692
		private CustomSelfDrawPanel.CSDButton renameButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002DAD RID: 11693
		private CustomSelfDrawPanel.CSDButton cancelButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002DAE RID: 11694
		private PresetLine m_line;

		// Token: 0x04002DAF RID: 11695
		private MyFormBase m_parent;

		// Token: 0x04002DB0 RID: 11696
		private string m_name;
	}
}
