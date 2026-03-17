using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020000E5 RID: 229
	public class BPForgottenPasswordPanel : CustomSelfDrawPanel
	{
		// Token: 0x060006EF RID: 1775 RVA: 0x0008FD24 File Offset: 0x0008DF24
		public BPForgottenPasswordPanel()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.clearControls();
			CustomSelfDrawPanel.CSDButton csdbutton = new CustomSelfDrawPanel.CSDButton();
			csdbutton.ImageNorm = GFXLibrary.misc_button_blue_210wide_normal;
			csdbutton.ImageOver = GFXLibrary.misc_button_blue_210wide_over;
			csdbutton.ImageClick = GFXLibrary.misc_button_blue_210wide_pushed;
			csdbutton.Position = new Point(300, 0);
			csdbutton.Text.Text = SK.Text("LOGIN_ForgottenPassword", "Forgotten Password");
			csdbutton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			csdbutton.Text.Color = global::ARGBColors.Black;
			csdbutton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.forgottenClicked));
			base.addControl(csdbutton);
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x0008FDF0 File Offset: 0x0008DFF0
		private void forgottenClicked()
		{
			try
			{
				new Process
				{
					StartInfo = 
					{
						FileName = "https://login.strongholdkingdoms.com/bigpoint/changepass.php?lang=" + Program.mySettings.LanguageIdent
					}
				}.Start();
			}
			catch (Exception)
			{
			}
		}
	}
}
