using System;
using System.Drawing;

namespace Kingdoms
{
	// Token: 0x020000DF RID: 223
	public class BasePreviewPanel : CustomSelfDrawPanel.CSDControl
	{
		// Token: 0x06000689 RID: 1673 RVA: 0x0008AC58 File Offset: 0x00088E58
		public void init(CastleMapPreset preset, CustomSelfDrawPanel.CSDControl parentControl)
		{
			this.m_preset = preset;
			CastleMap.PopulateBasicInfo(preset);
			this.Size = new Size(parentControl.Width - 20, parentControl.Height - 20);
			CustomSelfDrawPanel.CSDButton csdbutton = new CustomSelfDrawPanel.CSDButton();
			csdbutton.ImageNorm = GFXLibrary.preset_list;
			csdbutton.ImageOver = GFXLibrary.preset_list_over;
			csdbutton.ImageClick = GFXLibrary.preset_list_down;
			csdbutton.setSizeToImage();
			csdbutton.Position = new Point(base.Width - csdbutton.Width, -5);
			csdbutton.CustomTooltipID = 229;
			csdbutton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick));
			base.addControl(csdbutton);
			CustomSelfDrawPanel.CSDButton csdbutton2 = new CustomSelfDrawPanel.CSDButton();
			csdbutton2.ImageNorm = GFXLibrary.preset_castle_in;
			csdbutton2.ImageOver = GFXLibrary.preset_castle_in_over;
			csdbutton2.ImageClick = GFXLibrary.preset_castle_in_down;
			csdbutton2.setSizeToImage();
			csdbutton2.Position = new Point(csdbutton.X - csdbutton2.Width - 5, csdbutton.Y - 5);
			csdbutton2.CustomTooltipID = 225;
			csdbutton2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.deployClick));
			base.addControl(csdbutton2);
			CustomSelfDrawPanel.CSDButton csdbutton3 = new CustomSelfDrawPanel.CSDButton();
			csdbutton3.ImageNorm = GFXLibrary.preset_info;
			csdbutton3.ImageOver = GFXLibrary.preset_info_over;
			csdbutton3.ImageClick = GFXLibrary.preset_info_down;
			csdbutton3.setSizeToImage();
			csdbutton3.Position = new Point(csdbutton2.X - csdbutton3.Width - 5, csdbutton.Y);
			csdbutton3.CustomTooltipID = 240;
			csdbutton3.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.previewClick));
			if (this.m_preset.Type != PresetType.TROOP_ATTACK)
			{
				base.addControl(csdbutton3);
			}
			base.addControl(new CustomSelfDrawPanel.CSDLabel
			{
				Text = preset.Name,
				Color = global::ARGBColors.Black,
				Position = new Point(5, csdbutton.Y),
				Size = new Size(base.Width * 2 / 4, csdbutton.Height),
				Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold),
				Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT
			});
			this.populateRequirements();
			csdbutton2.Enabled = preset.CanDeploy();
			this.previewClick();
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x0008AEA0 File Offset: 0x000890A0
		private void closeClick()
		{
			if (GameEngine.Instance.GameDisplayModeSubMode == GameEngine.GameDisplaySubModes.SUBMODE_PREVIEW)
			{
				GameEngine.Instance.villageTabChange(1);
				InterfaceMgr.Instance.initCastleTab();
			}
			this.parent.removeControl(this);
			if (this.CloseCallback != null)
			{
				this.CloseCallback();
			}
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x0008AEF0 File Offset: 0x000890F0
		private void deployClick()
		{
			if (this.m_preset != null)
			{
				if (GameEngine.Instance.GameDisplayModeSubMode == GameEngine.GameDisplaySubModes.SUBMODE_PREVIEW)
				{
					GameEngine.Instance.villageTabChange(1);
					InterfaceMgr.Instance.initCastleTab();
				}
				PresetManager.Instance.DeployToMap(this.m_preset);
				PresetManager.Instance.GenerateFromMap(this.m_preset.Type);
			}
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x00007CE0 File Offset: 0x00005EE0
		protected virtual void previewClick()
		{
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x00007CE0 File Offset: 0x00005EE0
		protected virtual void populateRequirements()
		{
		}

		// Token: 0x040008DD RID: 2269
		protected CastleMapPreset m_preset;

		// Token: 0x040008DE RID: 2270
		public CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate CloseCallback;
	}
}
