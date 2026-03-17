using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000288 RID: 648
	public partial class PresetPopup : MyFormBase
	{
		// Token: 0x06001D19 RID: 7449 RVA: 0x001C5674 File Offset: 0x001C3874
		public PresetPopup(PresetType type)
		{
			this.InitializeComponent();
			this.closeCallback = new MyFormBase.MFBClose(this.closeFunction);
			base.Title = SK.Text("CastleMapPanel_Presets", "Manage Presets");
			if (type - PresetType.TROOP_ATTACK > 1)
			{
				if (type == PresetType.INFRASTRUCTURE)
				{
					base.Title = SK.Text("CastleMapPanel_Castle_Preset_Title", "Save your castle design online");
				}
			}
			else
			{
				base.Title = SK.Text("CastleMapPanel_Troop_Preset_Title", "Save your troop setup online");
			}
			this.customPanel.init(this, type);
		}

		// Token: 0x06001D1A RID: 7450 RVA: 0x0001C621 File Offset: 0x0001A821
		private void closeFunction()
		{
			this.customPanel.onClose();
			InterfaceMgr.Instance.closePresetPopup();
		}

		// Token: 0x06001D1B RID: 7451 RVA: 0x0001C638 File Offset: 0x0001A838
		public PresetPanel GetPanel()
		{
			return this.customPanel;
		}
	}
}
