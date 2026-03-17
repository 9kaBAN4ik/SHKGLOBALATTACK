using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x020000B2 RID: 178
	public partial class AboutPopup : MyFormBase
	{
		// Token: 0x060004DC RID: 1244 RVA: 0x0005EA34 File Offset: 0x0005CC34
		public AboutPopup()
		{
			this.InitializeComponent();
			this.label1.Font = FontManager.GetFont("Microsoft Sans Serif", 14f, FontStyle.Regular);
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			base.ShowClose = true;
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x0005EA84 File Offset: 0x0005CC84
		public void init()
		{
			this.label1.Text = SK.Text("About_Stronghold_Kingdoms", "Stronghold Kingdoms");
			this.label2.Text = SK.Text("About_Firefly", "(c)2010 Firefly Studios Ltd");
			this.lblCredits.Text = SK.Text("About_Credits", "Credits");
			string text = this.Text = (base.Title = SK.Text("About_About_Stronghold_Kingdoms", "About Stronghold Kingdoms"));
			this.lblSlimDX.Text = SK.Text("About_Copyright_SlimDX", "SlimDX Copyright (c) 2007-2010 SlimDX Group");
			this.lblGeckFX.Text = SK.Text("About_Copyright_GeckoFX", "GeckoFX Copyright (c) 2008 Skybound Software");
			this.lblXMLRPC.Text = SK.Text("About_Copyright_XMLRPC", "XML-RPC.NET Copyright (c) 2006 Charles Cook");
			this.lblZLIB.Text = SK.Text("About_Copyright_XLIB", "zlib Copyright (C) 1995-2004 Jean-loup Gailly and Mark Adler");
			string startupPath = Application.StartupPath;
			string[] array = Regex.Split(startupPath, "\\\\");
			if (array.Length != 0)
			{
				this.lblVersionNumber.Visible = true;
				this.lblVersionNumber.Text = SK.Text("About_Version", "Version") + " : " + array[array.Length - 1];
			}
			if (Program.mySettings.LanguageIdent == "de")
			{
				this.linkLabel1.Text = "de.strongholdkingdoms.com";
				return;
			}
			if (Program.mySettings.LanguageIdent == "fr")
			{
				this.linkLabel1.Text = "fr.strongholdkingdoms.com";
				return;
			}
			if (Program.mySettings.LanguageIdent == "ru")
			{
				this.linkLabel1.Text = "ru.strongholdkingdoms.com";
				return;
			}
			if (Program.mySettings.LanguageIdent == "es")
			{
				this.linkLabel1.Text = "es.strongholdkingdoms.com";
				return;
			}
			if (Program.mySettings.LanguageIdent == "pl")
			{
				this.linkLabel1.Text = "pl.strongholdkingdoms.com";
				return;
			}
			if (Program.mySettings.LanguageIdent == "tr")
			{
				this.linkLabel1.Text = "tr.strongholdkingdoms.com";
				return;
			}
			if (Program.mySettings.LanguageIdent == "it")
			{
				this.linkLabel1.Text = "it.strongholdkingdoms.com";
				return;
			}
			if (Program.mySettings.LanguageIdent == "pt")
			{
				this.linkLabel1.Text = "pt.strongholdkingdoms.com";
				return;
			}
			this.linkLabel1.Text = "www.strongholdkingdoms.com";
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x0005ED00 File Offset: 0x0005CF00
		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string fileName = (Program.mySettings.LanguageIdent == "de") ? "https://de.strongholdkingdoms.com" : ((Program.mySettings.LanguageIdent == "fr") ? "https://fr.strongholdkingdoms.com" : ((Program.mySettings.LanguageIdent == "ru") ? "https://ru.strongholdkingdoms.com" : ((Program.mySettings.LanguageIdent == "es") ? "https://es.strongholdkingdoms.com" : ((Program.mySettings.LanguageIdent == "pl") ? "https://pl.strongholdkingdoms.com" : ((Program.mySettings.LanguageIdent == "tr") ? "https://tr.strongholdkingdoms.com" : ((Program.mySettings.LanguageIdent == "it") ? "https://it.strongholdkingdoms.com" : ((!(Program.mySettings.LanguageIdent == "pt")) ? "https://www.strongholdkingdoms.com" : "https://pt.strongholdkingdoms.com")))))));
			new Process
			{
				StartInfo = 
				{
					FileName = fileName
				}
			}.Start();
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x0005EE20 File Offset: 0x0005D020
		private void lblCredits_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string fileName = (Program.mySettings.LanguageIdent == "de") ? "https://strongholdkingdoms-de.gamepedia.com/%C3%9Cber_Stronghold_Kingdoms#Mitwirkende" : ((Program.mySettings.LanguageIdent == "fr") ? "https://strongholdkingdoms-fr.gamepedia.com/%C3%80_propos_de_Stronghold_Kingdoms#Credits" : ((Program.mySettings.LanguageIdent == "ru") ? "https://strongholdkingdoms-ru.gamepedia.com/%D0%9E%D0%B1_%D0%B8%D0%B3%D1%80%D0%B5_Stronghold_Kingdoms#Credits" : ((Program.mySettings.LanguageIdent == "es") ? "https://strongholdkingdoms-es.gamepedia.com/Acerca_de_Stronghold_Kingdoms#credits" : ((Program.mySettings.LanguageIdent == "pl") ? "https://strongholdkingdoms-pl.gamepedia.com/O_grze_Stronghold_Kingdoms" : ((Program.mySettings.LanguageIdent == "tr") ? "https://strongholdkingdoms-tr.gamepedia.com/Stronghold_Kingdoms_Hakk%C4%B1nda" : ((Program.mySettings.LanguageIdent == "it") ? "https://strongholdkingdoms-it.gamepedia.com/Condivisione_dell%E2%80%99IP" : ((!(Program.mySettings.LanguageIdent == "pt")) ? "https://strongholdkingdoms.gamepedia.com/About_Stronghold_Kingdoms#Credits" : "https://strongholdkingdoms-pt.gamepedia.com/Sobre_o_Stronghold_Kingdoms")))))));
			new Process
			{
				StartInfo = 
				{
					FileName = fileName
				}
			}.Start();
		}
	}
}
