using System;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000287 RID: 647
	public class PresetPanel : CustomSelfDrawPanel
	{
		// Token: 0x06001D07 RID: 7431 RVA: 0x001C4834 File Offset: 0x001C2A34
		public PresetPanel()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06001D08 RID: 7432 RVA: 0x001C48C8 File Offset: 0x001C2AC8
		public void init(PresetPopup parent, PresetType type)
		{
			this.m_parent = parent;
			this.m_type = type;
			base.Size = this.m_parent.Size;
			this.BackColor = global::ARGBColors.Transparent;
			CustomSelfDrawPanel.CSDImage csdimage = new CustomSelfDrawPanel.CSDImage();
			csdimage.Alpha = 0.1f;
			csdimage.Scale = 5.0;
			csdimage.Position = new Point(0, 0);
			csdimage.Size = base.Size;
			base.addControl(csdimage);
			this.insetImage.Size = new Size(base.Width - 40, base.Height - 140);
			this.insetImage.Position = new Point(20, 40);
			csdimage.addControl(this.insetImage);
			this.insetImage.Create(GFXLibrary.quest_9sclice_grey_inset_top_left, GFXLibrary.quest_9sclice_grey_inset_top_mid, GFXLibrary.quest_9sclice_grey_inset_top_right, GFXLibrary.quest_9sclice_grey_inset_mid_left, GFXLibrary.quest_9sclice_grey_inset_mid_mid, GFXLibrary.quest_9sclice_grey_inset_mid_right, GFXLibrary.quest_9sclice_grey_inset_bottom_left, GFXLibrary.quest_9sclice_grey_inset_bottom_mid, GFXLibrary.quest_9sclice_grey_inset_bottom_right);
			this.presetsScrollArea.Position = new Point(this.insetImage.X + 10, this.insetImage.Y + 10);
			this.presetsScrollArea.Size = new Size(this.insetImage.Width - 40, this.insetImage.Height - 20);
			this.presetsScrollArea.ClipRect = new Rectangle(new Point(0, 0), this.presetsScrollArea.Size);
			csdimage.addControl(this.presetsScrollArea);
			int value = this.presetsScrollBar.Value;
			this.presetsScrollBar.Size = new Size(24, this.presetsScrollArea.Height + 3);
			this.presetsScrollBar.Position = new Point(this.insetImage.Position.X + this.insetImage.Width - (this.insetImage.Width - this.presetsScrollArea.Width) / 2 - this.presetsScrollBar.Width / 2, this.insetImage.Position.Y + 10);
			csdimage.addControl(this.presetsScrollBar);
			this.presetsScrollBar.Value = 0;
			this.presetsScrollBar.Create(null, null, null, GFXLibrary._24wide_thumb_top, GFXLibrary._24wide_thumb_middle, GFXLibrary._24wide_thumb_bottom);
			this.presetsScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.presetsScrollBarMoved));
			this.mouseWheelOverlay.Position = this.presetsScrollArea.Position;
			this.mouseWheelOverlay.Size = this.presetsScrollArea.Size;
			this.mouseWheelOverlay.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.onMouseWheelMoved));
			csdimage.addControl(this.mouseWheelOverlay);
			this.presetInfoArea.Position = new Point(this.insetImage.X + 10, this.insetImage.Y + 10);
			this.presetInfoArea.Size = new Size(this.insetImage.Width - 40, this.insetImage.Height - 20);
			csdimage.addControl(this.presetInfoArea);
			this.presetInfoArea.Visible = false;
			this.existingLabel.Text = SK.Text("Preset_Saved_Title", "Saved Presets");
			this.existingLabel.Color = global::ARGBColors.Black;
			this.existingLabel.Size = new Size(this.insetImage.Width, 20);
			this.existingLabel.Position = new Point(this.insetImage.X, this.insetImage.Y - this.existingLabel.Height - 2);
			this.existingLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.existingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			csdimage.addControl(this.existingLabel);
			PresetManager.Instance.GenerateFromMap(this.m_type);
			this.uploadButton.ImageNorm = GFXLibrary.preset_upload;
			this.uploadButton.ImageOver = GFXLibrary.preset_upload_over;
			this.uploadButton.ImageClick = GFXLibrary.preset_upload_down;
			this.uploadButton.setSizeToImage();
			this.uploadButton.Position = new Point(base.Width / 2 - this.uploadButton.Width / 2, this.insetImage.Rectangle.Bottom + 10);
			this.uploadButton.Text.Text = SK.Text("Preset_Upload", "Save to Cloud");
			this.uploadButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.uploadButton.TextYOffset = -2;
			this.uploadButton.Text.Color = global::ARGBColors.Black;
			this.uploadButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.uploadClick));
			this.uploadButton.Enabled = PresetManager.Instance.LocalChangesAvailable;
			csdimage.addControl(this.uploadButton);
			this.loadingLabel.Text = SK.Text("Preset_Loading_data", "Retrieving Cloud Data");
			this.loadingLabel.Color = global::ARGBColors.White;
			this.loadingLabel.Size = new Size(this.insetImage.Width, 20);
			this.loadingLabel.Position = new Point(this.insetImage.X, (this.insetImage.Y + this.insetImage.Rectangle.Bottom) / 2);
			this.loadingLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.loadingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			csdimage.addControl(this.loadingLabel);
			this.importButton.ImageNorm = GFXLibrary.button_132_normal;
			this.importButton.ImageOver = GFXLibrary.button_132_over;
			this.importButton.ImageClick = GFXLibrary.button_132_in;
			this.importButton.setSizeToImage();
			this.importButton.Position = new Point((this.uploadButton.Rectangle.Right + base.Width) / 2 - this.importButton.Width / 2, this.uploadButton.Y + this.uploadButton.Height / 2 - this.importButton.Height / 2);
			this.importButton.Text.Text = SK.Text("Preset_Import", "Import Formations");
			this.importButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.importButton.TextYOffset = -2;
			this.importButton.Text.Color = global::ARGBColors.Black;
			this.importButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.importClick));
			this.importButton.Enabled = true;
			if (PresetManager.Instance.IsDataReady)
			{
				this.processImport();
				this.initLines();
				this.uploadButton.Visible = true;
				this.importButton.Visible = (PresetManager.Instance.ShowPresetImport && !PresetManager.Instance.ImportComplete);
				this.loadingLabel.Visible = false;
			}
			else
			{
				this.uploadButton.Visible = false;
				this.importButton.Visible = false;
				this.loadingLabel.Visible = true;
			}
			base.Invalidate();
		}

		// Token: 0x06001D09 RID: 7433 RVA: 0x001C5068 File Offset: 0x001C3268
		public void initLines()
		{
			this.presetsScrollArea.Controls.Clear();
			if (PresetManager.Instance.LocalChangesAvailable)
			{
				this.uploadButton.Enabled = true;
			}
			PresetLine selectedLine = null;
			int num = 0;
			int highestAvailableSlot = PresetManager.Instance.GetHighestAvailableSlot(this.m_type);
			for (int i = 0; i < highestAvailableSlot; i++)
			{
				if (num > 0)
				{
					num += 5;
				}
				PresetLine presetLine = new PresetLine();
				presetLine.init(this, i + 1, this.m_type);
				presetLine.Position = new Point(0, num);
				this.presetsScrollArea.addControl(presetLine);
				num += presetLine.Height;
				if (i == 0)
				{
					this.mouseWheelDelta = presetLine.Height + 5;
					selectedLine = presetLine;
				}
			}
			if (num < this.presetsScrollArea.Height)
			{
				this.presetsScrollBar.Visible = false;
			}
			else
			{
				this.presetsScrollBar.Visible = true;
				this.presetsScrollBar.NumVisibleLines = this.presetsScrollBar.Height;
				this.presetsScrollBar.Max = num - this.presetsScrollBar.Height;
				this.presetsScrollBar.invalidateXtra();
			}
			this.SetSelectedLine(selectedLine);
		}

		// Token: 0x06001D0A RID: 7434 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void processImport()
		{
		}

		// Token: 0x06001D0B RID: 7435 RVA: 0x0001C55C File Offset: 0x0001A75C
		public void onClose()
		{
			if (GameEngine.Instance.GameDisplayModeSubMode == GameEngine.GameDisplaySubModes.SUBMODE_PREVIEW)
			{
				GameEngine.Instance.villageTabChange(1);
				InterfaceMgr.Instance.initCastleTab();
			}
			this.closeRenamePopup();
		}

		// Token: 0x06001D0C RID: 7436 RVA: 0x0001C586 File Offset: 0x0001A786
		private void onMouseWheelMoved(int delta)
		{
			if (delta < 0)
			{
				this.presetsScrollBar.scrollDown(this.mouseWheelDelta);
				return;
			}
			if (delta > 0)
			{
				this.presetsScrollBar.scrollUp(this.mouseWheelDelta);
			}
		}

		// Token: 0x06001D0D RID: 7437 RVA: 0x001C5180 File Offset: 0x001C3380
		private void presetsScrollBarMoved()
		{
			int value = this.presetsScrollBar.Value;
			this.presetsScrollArea.Position = new Point(this.presetsScrollArea.X, this.insetImage.Y + 10 - value);
			this.presetsScrollArea.ClipRect = new Rectangle(this.presetsScrollArea.ClipRect.X, value, this.presetsScrollArea.ClipRect.Width, this.presetsScrollArea.ClipRect.Height);
			this.presetsScrollArea.invalidate();
			this.presetsScrollBar.invalidate();
			this.insetImage.invalidate();
		}

		// Token: 0x06001D0E RID: 7438 RVA: 0x0001C5B3 File Offset: 0x0001A7B3
		public void SetSelectedLine(PresetLine line)
		{
			if (this.m_selectedLine != null)
			{
				this.m_selectedLine.onDeselect();
			}
			this.m_selectedLine = line;
			if (this.m_selectedLine != null)
			{
				this.m_selectedLine.onSelect();
			}
		}

		// Token: 0x06001D0F RID: 7439 RVA: 0x001C5230 File Offset: 0x001C3430
		private void uploadClick()
		{
			this.uploadButton.Enabled = false;
			PresetManager.Instance.SendPresetsToServer(this);
			foreach (CustomSelfDrawPanel.CSDControl csdcontrol in this.presetsScrollArea.Controls)
			{
				csdcontrol.Enabled = false;
			}
		}

		// Token: 0x06001D10 RID: 7440 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void onLogout()
		{
		}

		// Token: 0x06001D11 RID: 7441 RVA: 0x001C52A0 File Offset: 0x001C34A0
		private void importClick()
		{
			int legacyCount = PresetManager.Instance.getLegacyCount(this.m_type);
			if (legacyCount > PresetManager.Instance.GetFreeSlotCount(this.m_type))
			{
				string text = SK.Text("Presets_Confirm_Delete1", "The number of saved formations");
				text = text + " (" + legacyCount.ToString() + ") ";
				text += SK.Text("Presets_Confirm_Delete2", "exceeds the number of available slots");
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" (",
					PresetManager.Instance.GetFreeSlotCount(this.m_type).ToString(),
					") ",
					Environment.NewLine,
					Environment.NewLine
				});
				text += SK.Text("Presets_Confirm_Delete3", "You must delete saved formations before importing. Do this now?");
				if (MyMessageBox.Show(text, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					InterfaceMgr.Instance.closePresetPopup();
					InterfaceMgr.Instance.openFormationPopup();
				}
				return;
			}
			if (PresetManager.Instance.transferLegacy(this.m_type))
			{
				string txtMessage = SK.Text("Presets_Import_Success", "Formations successfully imported");
				MyMessageBox.Show(txtMessage);
				PresetManager.Instance.ShowPresetImport = false;
				PresetManager.Instance.ImportComplete = true;
				this.importButton.Visible = false;
				this.initLines();
				base.Invalidate();
				return;
			}
			string txtMessage2 = SK.Text("Presets_Import_Failure", "Formation import failed");
			MyMessageBox.Show(txtMessage2);
		}

		// Token: 0x06001D12 RID: 7442 RVA: 0x0001C5E3 File Offset: 0x0001A7E3
		private void debugClick()
		{
			InterfaceMgr.Instance.openFormationPopup();
		}

		// Token: 0x06001D13 RID: 7443 RVA: 0x001C540C File Offset: 0x001C360C
		public void onRename(PresetLine line)
		{
			if (this.OverControl != null)
			{
				CustomSelfDrawPanel.CSDControl overControl = this.OverControl;
				int data = overControl.Data;
				this.closeRenamePopup();
				this.m_renamePopup = new PresetEditPopup();
				this.m_renamePopup.init(line);
				this.m_renamePopup.Show();
			}
		}

		// Token: 0x06001D14 RID: 7444 RVA: 0x001C5458 File Offset: 0x001C3658
		public void closeRenamePopup()
		{
			if (this.m_renamePopup != null)
			{
				if (this.m_renamePopup.Created)
				{
					this.m_renamePopup.Close();
				}
				this.m_renamePopup = null;
				if (PresetManager.Instance.LocalChangesAvailable)
				{
					this.uploadButton.Enabled = true;
				}
			}
		}

		// Token: 0x06001D15 RID: 7445 RVA: 0x001C54A4 File Offset: 0x001C36A4
		public void onServerResponse(bool success)
		{
			if (success)
			{
				this.uploadButton.Visible = true;
				this.loadingLabel.Visible = false;
				this.processImport();
				if (PresetManager.Instance.ShowPresetImport)
				{
					this.importButton.Visible = true;
				}
				this.initLines();
				base.Invalidate();
				return;
			}
			this.loadingLabel.Text = SK.Text("Preset_Cannot_Load", "Unable to Access Cloud Data");
		}

		// Token: 0x06001D16 RID: 7446 RVA: 0x001C5514 File Offset: 0x001C3714
		public void onUploadComplete(bool success)
		{
			foreach (CustomSelfDrawPanel.CSDControl csdcontrol in this.presetsScrollArea.Controls)
			{
				csdcontrol.Enabled = true;
			}
			if (!success)
			{
				MyMessageBox.Show(SK.Text("Preset_Upload_Failed", "Failed to Upload Data to cloud"));
				this.uploadButton.Enabled = true;
				return;
			}
			MyMessageBox.Show(SK.Text("Preset_Upload_Complete", "Presets saved to the cloud"));
			this.uploadButton.Enabled = false;
		}

		// Token: 0x06001D17 RID: 7447 RVA: 0x001C55B4 File Offset: 0x001C37B4
		public void showPresetInfo(CastleMapPreset preset)
		{
			this.presetsScrollArea.Visible = false;
			this.showScrollbar = this.presetsScrollBar.Visible;
			this.presetsScrollBar.Visible = false;
			this.presetInfoArea.Visible = true;
			this.presetInfoArea.clearControls();
			BasePreviewPanel basePreviewPanel = null;
			switch (preset.Type)
			{
			case PresetType.TROOP_ATTACK:
				basePreviewPanel = new AttackTroopPreviewPanel();
				break;
			case PresetType.TROOP_DEFEND:
				basePreviewPanel = new DefenseTroopPreviewPanel();
				break;
			case PresetType.INFRASTRUCTURE:
				basePreviewPanel = new CastlePreviewPanel();
				break;
			}
			basePreviewPanel.Position = new Point(5, 5);
			basePreviewPanel.init(preset, this.insetImage);
			basePreviewPanel.CloseCallback = new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.hidePresetInfo);
			this.presetInfoArea.addControl(basePreviewPanel);
			base.Invalidate();
		}

		// Token: 0x06001D18 RID: 7448 RVA: 0x0001C5F0 File Offset: 0x0001A7F0
		private void hidePresetInfo()
		{
			this.presetsScrollArea.Visible = true;
			this.presetsScrollBar.Visible = this.showScrollbar;
			this.presetInfoArea.Visible = false;
			base.Invalidate();
		}

		// Token: 0x04002DD1 RID: 11729
		private PresetPopup m_parent;

		// Token: 0x04002DD2 RID: 11730
		private PresetType m_type;

		// Token: 0x04002DD3 RID: 11731
		private CustomSelfDrawPanel.CSDLabel existingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002DD4 RID: 11732
		private CustomSelfDrawPanel.CSDLabel loadingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002DD5 RID: 11733
		private PresetLine m_selectedLine;

		// Token: 0x04002DD6 RID: 11734
		private CustomSelfDrawPanel.CSDArea presetsScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002DD7 RID: 11735
		private CustomSelfDrawPanel.CSDVertScrollBar presetsScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04002DD8 RID: 11736
		private CustomSelfDrawPanel.CSDExtendingPanel insetImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04002DD9 RID: 11737
		private CustomSelfDrawPanel.CSDControl mouseWheelOverlay = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x04002DDA RID: 11738
		private int mouseWheelDelta = 40;

		// Token: 0x04002DDB RID: 11739
		private CustomSelfDrawPanel.CSDArea presetInfoArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002DDC RID: 11740
		private CustomSelfDrawPanel.CSDButton uploadButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002DDD RID: 11741
		private CustomSelfDrawPanel.CSDButton importButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002DDE RID: 11742
		private PresetEditPopup m_renamePopup;

		// Token: 0x04002DDF RID: 11743
		private bool showScrollbar = true;
	}
}
