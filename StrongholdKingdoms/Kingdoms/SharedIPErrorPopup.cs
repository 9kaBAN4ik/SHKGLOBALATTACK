using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x0200048C RID: 1164
	public partial class SharedIPErrorPopup : MyFormBase
	{
		// Token: 0x06002A57 RID: 10839 RVA: 0x0001F1F6 File Offset: 0x0001D3F6
		public SharedIPErrorPopup()
		{
			this.InitializeComponent();
			this.lblExplanation.Font = FontManager.GetFont("Microsoft Sans Serif", 9f, FontStyle.Regular);
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06002A58 RID: 10840 RVA: 0x0020F3C4 File Offset: 0x0020D5C4
		public void init(string explanation)
		{
			this.linkLabelMoreInfo.Text = SK.Text("SharedIPErrorPopup_More_Info", "Click Here for More Information");
			this.btnOK.Text = SK.Text("GENERIC_OK", "OK");
			string text = this.Text = (base.Title = SK.Text("SharedIPErrorPopup_Shared_Connwectin", "Shared Connection Detected"));
			this.lblExplanation.Text = explanation;
		}

		// Token: 0x06002A59 RID: 10841 RVA: 0x0020F434 File Offset: 0x0020D634
		private void linkLabelMoreInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process process = new Process();
			string languageIdent = Program.mySettings.LanguageIdent;
			if (languageIdent != null)
			{
				uint num = PrivateImplementationDetails.ComputeStringHash(languageIdent);
				if (num <= 1195724803U)
				{
					if (num <= 1176137065U)
					{
						if (num != 1162757945U)
						{
							if (num == 1176137065U)
							{
								if (languageIdent == "es")
								{
									process.StartInfo.FileName = "https://strongholdkingdoms-es.gamepedia.com/Compartir_IP";
									goto IL_1E4;
								}
							}
						}
						else if (languageIdent == "pl")
						{
							process.StartInfo.FileName = "https://strongholdkingdoms-pl.gamepedia.com/Wsp%C3%B3%C5%82u%C5%BCytkowanie_adresu_IP";
							goto IL_1E4;
						}
					}
					else if (num != 1194886160U)
					{
						if (num == 1195724803U)
						{
							if (languageIdent == "tr")
							{
								process.StartInfo.FileName = "https://strongholdkingdoms-tr.gamepedia.com/IP_Payla%C5%9F%C4%B1m%C4%B1";
								goto IL_1E4;
							}
						}
					}
					else if (languageIdent == "it")
					{
						process.StartInfo.FileName = "https://strongholdkingdoms-it.gamepedia.com/A_proposito_di_Stronghold_Kingdoms";
						goto IL_1E4;
					}
				}
				else if (num <= 1461901041U)
				{
					if (num != 1213488160U)
					{
						if (num == 1461901041U)
						{
							if (languageIdent == "fr")
							{
								process.StartInfo.FileName = "https://strongholdkingdoms-fr.gamepedia.com/Adresse_IP_Partag%C3%A9e";
								goto IL_1E4;
							}
						}
					}
					else if (languageIdent == "ru")
					{
						process.StartInfo.FileName = "https://strongholdkingdoms-ru.gamepedia.com/%D0%A0%D0%B0%D0%B7%D0%B4%D0%B5%D0%BB%D0%B5%D0%BD%D0%B8%D0%B5_IP";
						goto IL_1E4;
					}
				}
				else if (num != 1545391778U)
				{
					if (num == 1565420801U)
					{
						if (languageIdent == "pt")
						{
							process.StartInfo.FileName = "https://strongholdkingdoms-pt.gamepedia.com/Compartilhamento_de_IP";
							goto IL_1E4;
						}
					}
				}
				else if (languageIdent == "de")
				{
					process.StartInfo.FileName = "https://strongholdkingdoms-de.gamepedia.com/Gemeinsame_IP-Adressen";
					goto IL_1E4;
				}
			}
			process.StartInfo.FileName = "https://strongholdkingdoms.gamepedia.com/IP_Sharing";
			IL_1E4:
			process.Start();
		}

		// Token: 0x06002A5A RID: 10842 RVA: 0x0001F234 File Offset: 0x0001D434
		private void btnOK_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("SharedIPErrorPopup_close");
			base.Close();
		}

		// Token: 0x06002A5B RID: 10843 RVA: 0x0020F62C File Offset: 0x0020D82C
		public static void showSharedIPPopup(string explanation)
		{
			SharedIPErrorPopup sharedIPErrorPopup = new SharedIPErrorPopup();
			sharedIPErrorPopup.init(explanation);
			sharedIPErrorPopup.ShowDialog();
			sharedIPErrorPopup.Dispose();
		}
	}
}
