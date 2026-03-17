using System;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000282 RID: 642
	public class PresetLine : CustomSelfDrawPanel.CSDControl
	{
		// Token: 0x06001CCC RID: 7372 RVA: 0x0001C36E File Offset: 0x0001A56E
		public CastleMapPreset GetPreset()
		{
			return this.m_preset;
		}

		// Token: 0x06001CCD RID: 7373 RVA: 0x001C2F40 File Offset: 0x001C1140
		public void init(PresetPanel parent, int slotID, PresetType type)
		{
			this.m_parent = parent;
			this.m_preset = PresetManager.Instance.GetPreset(type, slotID);
			bool flag = false;
			if (this.m_preset == null)
			{
				flag = true;
				this.m_preset = new CastleMapPreset("", DateTime.Now, type, 0);
				this.m_preset.SlotID = slotID;
				this.deployButton.Visible = false;
				this.deleteButton.Visible = false;
				this.renameButton.Visible = false;
				this.infoButton.Visible = false;
			}
			this.m_slotID = slotID;
			this.clearControls();
			this.backgroundImage.Image = GFXLibrary.quest_screen_bar1;
			this.backgroundImage.Position = new Point(0, 0);
			this.backgroundImage.Size = new Size(this.m_parent.Width - 100, this.backgroundImage.Height * 4 / 3);
			base.addControl(this.backgroundImage);
			this.Size = new Size(this.m_parent.Width - 80, this.backgroundImage.Height);
			this.nameLabel.Text = this.m_preset.Name;
			this.nameLabel.Color = global::ARGBColors.Black;
			this.nameLabel.Position = new Point(5, 0);
			this.nameLabel.Size = new Size(this.backgroundImage.Width / 2, this.backgroundImage.Height);
			this.nameLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.nameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.backgroundImage.addControl(this.nameLabel);
			this.deployButton.ImageNorm = GFXLibrary.preset_castle_in;
			this.deployButton.ImageOver = GFXLibrary.preset_castle_in_over;
			this.deployButton.ImageClick = GFXLibrary.preset_castle_in_down;
			this.deployButton.setSizeToImage();
			this.deployButton.Size = new Size(this.deployButton.Width * 3 / 4, this.deployButton.Height * 3 / 4);
			this.deployButton.Position = new Point(base.Width * 3 / 5, base.Height / 2 - this.deployButton.Height / 2);
			this.deployButton.CustomTooltipID = 225;
			this.deployButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.deployClick));
			this.backgroundImage.addControl(this.deployButton);
			this.memoriseButton.ImageNorm = GFXLibrary.preset_castle_out;
			this.memoriseButton.ImageOver = GFXLibrary.preset_castle_out_over;
			this.memoriseButton.ImageClick = GFXLibrary.preset_castle_out_down;
			this.memoriseButton.setSizeToImage();
			if (flag)
			{
				this.memoriseButton.setSizeToImage();
				this.memoriseButton.Position = new Point(10, base.Height / 2 - this.memoriseButton.Height / 2);
			}
			else
			{
				this.memoriseButton.Size = new Size(this.memoriseButton.Width * 3 / 4, this.memoriseButton.Height * 3 / 4);
				this.memoriseButton.Position = new Point(this.deployButton.Rectangle.Right, this.deployButton.Y);
			}
			this.memoriseButton.CustomTooltipID = 224;
			this.memoriseButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.memoriseClick));
			this.backgroundImage.addControl(this.memoriseButton);
			int right = this.memoriseButton.Rectangle.Right;
			this.infoButton.ImageNorm = GFXLibrary.preset_info;
			this.infoButton.ImageOver = GFXLibrary.preset_info_over;
			this.infoButton.ImageClick = GFXLibrary.preset_info_down;
			this.infoButton.setSizeToImage();
			this.infoButton.Size = new Size(this.infoButton.Width * 2 / 3, this.infoButton.Height * 2 / 3);
			this.infoButton.Position = new Point(this.memoriseButton.Rectangle.Right + 5, base.Height / 2 - this.infoButton.Height / 2);
			this.infoButton.CustomTooltipID = 228;
			this.infoButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.infoClick));
			this.backgroundImage.addControl(this.infoButton);
			right = this.infoButton.Rectangle.Right;
			this.renameButton.ImageNorm = GFXLibrary.preset_rename;
			this.renameButton.ImageOver = GFXLibrary.preset_rename_over;
			this.renameButton.ImageClick = GFXLibrary.preset_rename_down;
			this.renameButton.setSizeToImage();
			this.renameButton.Size = new Size(this.renameButton.Width * 3 / 4, this.renameButton.Height * 3 / 4);
			this.renameButton.Position = new Point(right, this.memoriseButton.Y);
			this.renameButton.CustomTooltipID = 226;
			this.renameButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.renameClick));
			this.backgroundImage.addControl(this.renameButton);
			this.deleteButton.ImageNorm = GFXLibrary.preset_delete;
			this.deleteButton.ImageOver = GFXLibrary.preset_delete_over;
			this.deleteButton.ImageClick = GFXLibrary.preset_delete_down;
			this.deleteButton.setSizeToImage();
			this.deleteButton.Size = new Size(this.deleteButton.Width * 3 / 4, this.deleteButton.Height * 3 / 4);
			this.deleteButton.Position = new Point(this.renameButton.Rectangle.Right + 2, base.Height / 2 - this.deleteButton.Height / 2);
			this.deleteButton.CustomTooltipID = 227;
			this.deleteButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.deleteClick));
			this.backgroundImage.addControl(this.deleteButton);
			bool flag2 = true;
			int selectedMenuVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
			if (GameEngine.Instance.World.isCapital(selectedMenuVillage) && !GameEngine.Instance.World.isUserVillage(selectedMenuVillage))
			{
				flag2 = false;
			}
			this.deployButton.Enabled = (flag2 && this.m_preset.CanDeploy());
			base.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.onClick));
		}

		// Token: 0x06001CCE RID: 7374 RVA: 0x001C3614 File Offset: 0x001C1814
		public void onSelect()
		{
			this.selected = true;
			this.backgroundImage.Image = GFXLibrary.quest_screen_bar2;
			this.backgroundImage.Size = new Size(this.m_parent.Width - 100, this.backgroundImage.Height * 4 / 3);
			base.invalidate();
		}

		// Token: 0x06001CCF RID: 7375 RVA: 0x001C3670 File Offset: 0x001C1870
		public bool onDeselect()
		{
			this.selected = false;
			this.backgroundImage.Image = GFXLibrary.quest_screen_bar1;
			this.backgroundImage.Size = new Size(this.m_parent.Width - 100, this.backgroundImage.Height * 4 / 3);
			base.invalidate();
			return true;
		}

		// Token: 0x06001CD0 RID: 7376 RVA: 0x0001C376 File Offset: 0x0001A576
		private void onClick()
		{
			if (!this.selected)
			{
				this.m_parent.SetSelectedLine(this);
			}
		}

		// Token: 0x06001CD1 RID: 7377 RVA: 0x001C36D0 File Offset: 0x001C18D0
		private void onDelete()
		{
			PresetType type = this.m_preset.Type;
			this.m_preset = new CastleMapPreset("", DateTime.Now, type, 0);
			this.nameLabel.Text = "";
			this.deleteButton.Visible = false;
			this.deployButton.Visible = false;
			this.renameButton.Visible = false;
			this.infoButton.Visible = false;
			this.m_parent.initLines();
		}

		// Token: 0x06001CD2 RID: 7378 RVA: 0x001C374C File Offset: 0x001C194C
		public void onNameChange(string newName)
		{
			if (!newName.Equals(this.m_preset.Name))
			{
				this.nameLabel.Text = newName;
				this.nameLabel.invalidate();
				this.m_preset.Name = newName;
				PresetManager.Instance.UpdatePreset(this.m_preset);
				this.m_parent.initLines();
				base.invalidate();
			}
		}

		// Token: 0x06001CD3 RID: 7379 RVA: 0x0001C38C File Offset: 0x0001A58C
		public string GetName()
		{
			return this.nameLabel.Text;
		}

		// Token: 0x06001CD4 RID: 7380 RVA: 0x0001C399 File Offset: 0x0001A599
		private void deployClick()
		{
			this.onClick();
			PresetManager.Instance.DeployToMap(this.m_preset);
			PresetManager.Instance.GenerateFromMap(this.m_preset.Type);
		}

		// Token: 0x06001CD5 RID: 7381 RVA: 0x001C37B4 File Offset: 0x001C19B4
		private void memoriseClick()
		{
			if (PresetManager.Instance.CurrentElementCount() == 0)
			{
				return;
			}
			this.onClick();
			PresetManager.Instance.CopyCurrentToPreset(this.m_preset);
			if (this.m_preset.ElementCount > 0)
			{
				this.deployButton.Visible = true;
				this.deleteButton.Visible = true;
				this.renameButton.Visible = true;
				this.infoButton.Visible = true;
				if (this.m_preset.Name.Trim().Length == 0)
				{
					this.m_parent.onRename(this);
				}
				PresetManager.Instance.UpdatePreset(this.m_preset);
				this.m_parent.initLines();
			}
		}

		// Token: 0x06001CD6 RID: 7382 RVA: 0x0001C3C6 File Offset: 0x0001A5C6
		private void renameClick()
		{
			this.onClick();
			this.m_parent.onRename(this);
		}

		// Token: 0x06001CD7 RID: 7383 RVA: 0x001C3864 File Offset: 0x001C1A64
		private void deleteClick()
		{
			this.onClick();
			string txtMessage = SK.Text("Preset_Delete_Warning", "Are you sure you want to delete this preset?");
			string txtTitle = SK.Text("Preset_Delete_Title", "Delete Preset");
			if (MyMessageBox.Show(txtMessage, txtTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				PresetManager.Instance.DeletePreset(this.m_preset.Type, this.m_preset.SlotID);
				this.onDelete();
			}
		}

		// Token: 0x06001CD8 RID: 7384 RVA: 0x0001C3DA File Offset: 0x0001A5DA
		private void infoClick()
		{
			this.m_parent.showPresetInfo(this.m_preset);
		}

		// Token: 0x04002DB4 RID: 11700
		private CastleMapPreset m_preset;

		// Token: 0x04002DB5 RID: 11701
		private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002DB6 RID: 11702
		private CustomSelfDrawPanel.CSDLabel nameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002DB7 RID: 11703
		private CustomSelfDrawPanel.CSDButton deployButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002DB8 RID: 11704
		private CustomSelfDrawPanel.CSDButton memoriseButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002DB9 RID: 11705
		private CustomSelfDrawPanel.CSDButton renameButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002DBA RID: 11706
		private CustomSelfDrawPanel.CSDButton deleteButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002DBB RID: 11707
		private CustomSelfDrawPanel.CSDButton infoButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002DBC RID: 11708
		private PresetPanel m_parent;

		// Token: 0x04002DBD RID: 11709
		private bool selected;

		// Token: 0x04002DBE RID: 11710
		private int m_slotID;
	}
}
