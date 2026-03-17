using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x02000281 RID: 641
	public partial class PresetEditPopup : MyFormBase
	{
		// Token: 0x06001CC5 RID: 7365 RVA: 0x0001C2D2 File Offset: 0x0001A4D2
		public PresetEditPopup()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06001CC6 RID: 7366 RVA: 0x001C2CD0 File Offset: 0x001C0ED0
		public void init(PresetLine line)
		{
			this.customPanel.init(this, line);
			string text = this.Text = (base.Title = SK.Text("Preset_Rename", "Rename"));
			this.tbInput.Text = line.GetName();
			this.tbInput.MaxLength = 48;
		}

		// Token: 0x06001CC7 RID: 7367 RVA: 0x0001C2F5 File Offset: 0x0001A4F5
		private void tbInput_TextChanged(object sender, EventArgs e)
		{
			this.customPanel.setName(((TextBox)sender).Text);
		}

		// Token: 0x06001CC8 RID: 7368 RVA: 0x0001C30D File Offset: 0x0001A50D
		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			base.Close();
		}

		// Token: 0x06001CC9 RID: 7369 RVA: 0x0001C31C File Offset: 0x0001A51C
		private void tbInput_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				this.customPanel.renameClick();
				e.Handled = true;
				return;
			}
			if (!StringValidation.isValidChar(e.KeyChar))
			{
				e.Handled = true;
			}
		}
	}
}
