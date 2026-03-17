using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Kingdoms;
using Properties;

namespace Upgrade.Services
{
	// Token: 0x0200006D RID: 109
	internal class MonitorService : ABaseService
	{
		// Token: 0x06000327 RID: 807 RVA: 0x00050A7C File Offset: 0x0004EC7C
		internal bool IsConnectionRelevant()
		{
			Config config = DX.GetConfig();
			return config != null && (DateTime.Now - config.Checked).TotalMilliseconds < (double)(this.DefaultInterval * this.IntervalMultiplier);
		}

		// Token: 0x06000328 RID: 808 RVA: 0x000099A8 File Offset: 0x00007BA8
		public MonitorService(Log log, ListBox subScriptions, ControlForm formToMonitor) : base(log)
		{
			this._subScriptions = subScriptions;
			this._formToMonitor = formToMonitor;
		}

		// Token: 0x06000329 RID: 809 RVA: 0x00050ABC File Offset: 0x0004ECBC
		public override void ConcreteAction()
		{
			Config config = DX.GetConfig();
			if (config != null)
			{
				double totalMilliseconds = (DateTime.Now - config.Checked).TotalMilliseconds;
				if (totalMilliseconds < (double)base.Interval)
				{
					int num = (int)(((double)base.Interval - totalMilliseconds) / (double)this.IntervalMultiplier);
					if (num == 0)
					{
						num = 1;
					}
					base.Interval = num;
					this.UpdateSubscriptions(config.Settings);
					if (LNG._isEnglishSelected)
					{
						this.DisplaySubscriptions(false);
					}
					return;
				}
			}
			base.Interval = this.DefaultInterval;
			string text = string.Empty;
			try
			{
				text = Settings.Default.UserContactEmail;
			}
			catch (ConfigurationErrorsException ex)
			{
				ABaseService.ProcessOldSettings(ex);
			}
			catch (Exception ex2)
			{
				ABaseService.MessageBoxNonModal(ex2.Message, LNG.Print("Error on reading contact email"));
			}
			string text2 = Program.mySettings.Username;
			if (string.IsNullOrEmpty(text2))
			{
				text2 = text;
			}
			string text3 = ProfileLoginWindow.LoggedInViaFacebook ? this.GetAccountDetails() : string.Empty;
			if (string.IsNullOrEmpty(text2) && string.IsNullOrEmpty(text3))
			{
				this.Log("Error! Can not retrieve Bot subscription. Please specify contact email and restart the game.", ControlForm.Tab.Main, true);
				return;
			}
			text2 = text2.Trim();
			string url = string.Concat(new string[]
			{
				"vlc=",
				DX.Encode(")VQ#%(m8rbM#Q(U#%89u"),
				"&qjd=",
				DX.Encode(RemoteServices.Instance.UserName),
				"&me=s&bed=",
				DX.Encode("!@)C91i90vi09vi"),
				"&xpg=",
				DX.Encode(text2),
				"&utta=",
				DX.Encode("9.8.5"),
				"&hbr=",
				DX.Encode(text.Trim()),
				"&fbe=",
				DX.Encode(text3),
				"&mac=",
				DX.AuthorizedMAC
			});
			string msg = base.MonitorAttacks(url, ControlForm.Tab.Main);
			if (msg.Contains("If you"))
			{
				new Thread(delegate()
				{
					MessageBox.Show(LNG.Print(msg));
				}).Start();
				Process.Start("https://shkbot.site");
				this.ApplySub(text2, text3, string.Empty);
				this.DisableAll();
				CacheSub.Encrypt();
				return;
			}
			bool flag = true;
			if (string.IsNullOrEmpty(msg))
			{
				msg = CacheSub.Load();
				flag = false;
			}
			if (!string.IsNullOrEmpty(msg))
			{
				this.ApplySub(text2, text3, msg);
				if (flag)
				{
					CacheSub.Encrypt();
				}
			}
		}

		// Token: 0x0600032A RID: 810 RVA: 0x00050D4C File Offset: 0x0004EF4C
		internal void Load()
		{
			string text = CacheSub.Load();
			if (!string.IsNullOrEmpty(text))
			{
				this.ApplySub(string.Empty, string.Empty, text);
			}
		}

		// Token: 0x0600032B RID: 811 RVA: 0x00050D78 File Offset: 0x0004EF78
		private void ApplySub(string email, string fbEmail, string msg)
		{
			List<string> list = msg.Split(new char[]
			{
				','
			}).ToList<string>();
			DX.Configs.RemoveAll((Config c) => c.Alias == RemoteServices.Instance.UserName);
			DX.Configs.Add(new Config(RemoteServices.Instance.UserName, ProfileLoginWindow.LoggedInViaFacebook ? fbEmail : email, list, DateTime.Now));
			this.UpdateSubscriptions(list);
			this.DisplaySubscriptions(true);
			if (!DX.SnoozeUpdates)
			{
				this.ProcessVersionNumber(list);
			}
		}

		// Token: 0x0600032C RID: 812 RVA: 0x00050E0C File Offset: 0x0004F00C
		private string GetAccountDetails()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.Add("UserGUID", RemoteServices.Instance.UserGuid.ToString().Replace("-", ""));
			dictionary.Add("ClientLanguage", Program.mySettings.LanguageIdent.ToLower());
			dictionary.Add("NewLoginScreen", "1");
			dictionary.Add("SessionGUID", RemoteServices.Instance.SessionGuid.ToString().Replace("-", ""));
			string text = string.Empty;
			foreach (KeyValuePair<string, string> keyValuePair in dictionary)
			{
				if (text != string.Empty)
				{
					text += "&";
				}
				text = text + keyValuePair.Key + "=" + keyValuePair.Value;
			}
			byte[] bytes = Encoding.UTF8.GetBytes(text);
			string text2 = string.Empty;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://login.strongholdkingdoms.com/kingdoms/account.php");
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;
				httpWebRequest.Method = "POST";
				httpWebRequest.ContentLength = (long)bytes.Length;
				httpWebRequest.ContentType = "application/x-www-form-urlencoded";
				Stream requestStream = httpWebRequest.GetRequestStream();
				requestStream.Write(bytes, 0, bytes.Length);
				requestStream.Close();
				using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
				{
					using (Stream responseStream = httpWebResponse.GetResponseStream())
					{
						using (StreamReader streamReader = new StreamReader(responseStream))
						{
							text2 = streamReader.ReadToEnd();
						}
					}
				}
			}
			catch (Exception ex)
			{
				ControlForm controlForm = DX.ControlForm;
				if (controlForm != null)
				{
					controlForm.Log(string.Concat(new string[]
					{
						"Unknown SHK error: ",
						ex.Message,
						" ",
						ex.Source,
						" ",
						ex.StackTrace
					}), ControlForm.Tab.Main, false);
				}
				return text2;
			}
			string text3 = "<input type='email' id='accountEmail' value='";
			string value = "' disabled='disabled' />";
			int num = text2.IndexOf(text3) + text3.Length;
			int num2 = text2.IndexOf(value);
			string text4 = text2.Substring(num, num2 - num);
			this.Log(LNG.Print("Retrieved Facebook email") + ": " + text4, ControlForm.Tab.Main, false);
			return text4.Trim();
		}

		// Token: 0x0600032D RID: 813 RVA: 0x000510D4 File Offset: 0x0004F2D4
		private void ProcessVersionNumber(List<string> mods)
		{
			int num = mods.IndexOf("Version");
			if (num == -1)
			{
				this.Log("Error checking updates. Latest version is not received.", ControlForm.Tab.Main, true);
				return;
			}
			if (num + 1 > mods.Count)
			{
				this.Log("Error checking updates. Latest version Number is not received.", ControlForm.Tab.Main, true);
				return;
			}
			if (MonitorService.IsHigherVersion(mods[num + 1], "9.8.5"))
			{
				new Thread(delegate()
				{
				}).Start();
			}
		}

		// Token: 0x0600032E RID: 814 RVA: 0x00051160 File Offset: 0x0004F360
		private void DisableAll()
		{
			foreach (ABaseService abaseService in this._formToMonitor.Services)
			{
				if (abaseService.Name != "Monitor Service")
				{
					abaseService.IsSubscribed = false;
				}
			}
			this._formToMonitor.FiltersService.IsSubscribed = false;
			this._formToMonitor.CastleRepairService.IsSubscribed = false;
			this._formToMonitor.TimedAttacksService.IsSubscribed = false;
			this._subScriptions.Items.Clear();
		}

		// Token: 0x0600032F RID: 815 RVA: 0x00051210 File Offset: 0x0004F410
		internal void UpdateSubscriptions(List<string> mods)
		{
			bool flag = mods.Contains("All");
			List<string> list = new List<string>
			{
				"Download Villages",
				"Monitor Service",
				"Free Monitor",
				"Feed"
			};
			foreach (ABaseService abaseService in this._formToMonitor.Services)
			{
				if (!list.Contains(abaseService.Name))
				{
					abaseService.IsSubscribed = (flag || mods.Contains(abaseService.Name));
				}
			}
			this._formToMonitor.FiltersService.IsSubscribed = (flag || mods.Contains("Filters"));
			this._formToMonitor.TimedAttacksService.IsSubscribed = (flag || mods.Contains("Timed Attacks"));
			this._formToMonitor.CastleRepairService.IsSubscribed = (flag || mods.Contains("Castle Repair"));
			this._formToMonitor.IsExclusive = mods.Contains("Exclusive");
		}

		// Token: 0x06000330 RID: 816 RVA: 0x00051340 File Offset: 0x0004F540
		public void DisplaySubscriptions(bool showReminder = false)
		{
			Config config = DX.GetConfig();
			if (config == null)
			{
				return;
			}
			List<string> settings = config.Settings;
			this._subScriptions.Items.Clear();
			if (settings.Count == 0)
			{
				return;
			}
			string endsWith = "-" + Program.mySettings.languageIdent.ToUpper();
			CultureInfo cultureInfo = (from c in CultureInfo.GetCultures(CultureTypes.AllCultures)
			where c.Name.EndsWith(endsWith)
			select c).FirstOrDefault<CultureInfo>();
			List<string> list = new List<string>();
			for (int i = 0; i < settings.Count; i++)
			{
				string text = settings[i++];
				if (!(text == "Version"))
				{
					if (text == "All")
					{
						text += " features";
					}
					text = LNG.Print(text);
					DateTime d;
					if (i < settings.Count && DateTime.TryParse(settings[i], out d))
					{
						string arg = (cultureInfo != null) ? d.ToString(cultureInfo.DateTimeFormat.LongDatePattern, cultureInfo) : d.ToLongDateString();
						double totalDays = (d - DateTime.Now).TotalDays;
						text += string.Format(" ({0}) ({1} {2})", arg, (int)totalDays, LNG.Print("days left"));
						if (totalDays < 3.0)
						{
							list.Add(text);
						}
					}
					else
					{
						text += " (end date unknown)";
					}
					this._subScriptions.Items.Add(text);
				}
			}
			if (showReminder && list.Any<string>())
			{
				ABaseService.MessageBoxNonModal(string.Join(Environment.NewLine, list.ToArray()), LNG.Print("Ending subscriptions"));
			}
		}

		// Token: 0x06000331 RID: 817 RVA: 0x00051504 File Offset: 0x0004F704
		internal static bool IsHigherVersion(string receivedVersion, string currentVersion)
		{
			bool result = false;
			string[] array = receivedVersion.Split(new char[]
			{
				'.'
			});
			string[] array2 = currentVersion.Split(new char[]
			{
				'.'
			});
			for (int i = 0; i < array.Length; i++)
			{
				int num = int.Parse(array[i]);
				if (i >= array2.Length)
				{
					result = true;
					break;
				}
				int num2 = int.Parse(array2[i]);
				if (num > num2)
				{
					result = true;
					break;
				}
				if (num < num2)
				{
					break;
				}
			}
			return result;
		}

		// Token: 0x06000332 RID: 818 RVA: 0x00051574 File Offset: 0x0004F774
		private void PromptUpdate(string receivedVersion)
		{
			DialogResult dialogResult = MessageBox.Show(string.Concat(new string[]
			{
				LNG.Print("Download new version?"),
				"\n\n",
				LNG.Print("Yes - Update"),
				"\n\n",
				LNG.Print("No - Close this window and Stop asking"),
				"\n\n",
				LNG.Print("Cancel - Close this window")
			}), LNG.Print("New version of Bot available") + ": " + receivedVersion, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			if (dialogResult != DialogResult.Yes)
			{
				if (dialogResult == DialogResult.No)
				{
					DX.SnoozeUpdates = true;
				}
				return;
			}
			DialogResult dialogResult2 = MessageBox.Show(LNG.Print("OK - Game will shut down and restart") + "\n\n" + LNG.Print("Cancel - Go to download page"), LNG.Print("Try automatic update?"), MessageBoxButtons.OKCancel);
			if (dialogResult2 == DialogResult.OK)
			{
				AutoUpdates.StartAutomaticUpdate(receivedVersion);
				return;
			}
			Process.Start(ControlForm.linkToDownload);
		}

		// Token: 0x06000333 RID: 819 RVA: 0x000099BF File Offset: 0x00007BBF
		internal override void TranslateUI()
		{
			this.DisplaySubscriptions(false);
		}

		// Token: 0x0400047B RID: 1147
		private ListBox _subScriptions;

		// Token: 0x0400047C RID: 1148
		private ControlForm _formToMonitor;

		// Token: 0x0400047D RID: 1149
		internal int DefaultInterval;
	}
}
