using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms;

namespace Upgrade.Services
{
	// Token: 0x02000038 RID: 56
	public abstract class ABaseService : ASubscribed
	{
		// Token: 0x06000213 RID: 531 RVA: 0x00048434 File Offset: 0x00046634
		internal bool ShouldRun()
		{
			return base.Enabled && base.IsSubscribed && !this.Exiting.WaitOne(0) && (DateTime.Now - this.LastRan).TotalMilliseconds > (double)this.Interval && (!this.NeedsToSleep || !WorkCycle.ShouldModuleSleep());
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000214 RID: 532 RVA: 0x000091DA File Offset: 0x000073DA
		// (set) Token: 0x06000215 RID: 533 RVA: 0x000091E2 File Offset: 0x000073E2
		public int Interval
		{
			get
			{
				return this._interval;
			}
			set
			{
				this._interval = value * this.IntervalMultiplier;
			}
		}

		// Token: 0x06000216 RID: 534 RVA: 0x000091F2 File Offset: 0x000073F2
		public ABaseService(Log log)
		{
			this.Log = log;
			this.SelectedVillages = new List<int>();
		}

		// Token: 0x06000217 RID: 535
		public abstract void ConcreteAction();

		// Token: 0x06000218 RID: 536 RVA: 0x00048494 File Offset: 0x00046694
		public void Action(object online)
		{
			while ((bool)online && !GameEngine.Instance.World.isDownloadComplete())
			{
				Thread.Sleep(500);
			}
			do
			{
				if (!base.Enabled || !base.IsSubscribed)
				{
					this.ModuleSleep.WaitOne();
				}
				else
				{
					if (!this.NeedsToSleep || !WorkCycle.ShouldModuleSleep())
					{
						try
						{
							this.ConcreteAction();
						}
						catch (Exception ex)
						{
							ABaseService.ReportError(ex, ControlForm.Tab.Main);
						}
					}
					this.Exiting.WaitOne(this.Interval);
				}
			}
			while (!this.Exiting.WaitOne(0));
			this.Log(LNG.Print(Thread.CurrentThread.Name) + " " + LNG.Print("module switched off"), ControlForm.Tab.Main, false);
		}

		// Token: 0x06000219 RID: 537 RVA: 0x00048568 File Offset: 0x00046768
		public static void ReportError(Exception ex, ControlForm.Tab logTab = ControlForm.Tab.Main)
		{
			if (ex == null || DX.ControlForm == null)
			{
				return;
			}
			string text = string.Concat(new string[]
			{
				"ERROR! ",
				ex.Message,
				" ",
				ex.Source,
				" ",
				ex.StackTrace
			});
			DX.ControlForm.Log(text, logTab, true);
			if (ex.InnerException != null)
			{
				Exception innerException = ex.InnerException;
				string text2 = string.Concat(new string[]
				{
					"ERROR! ",
					innerException.Message,
					" ",
					innerException.Source,
					" ",
					innerException.StackTrace
				});
				DX.ControlForm.Log(text2, logTab, true);
			}
		}

		// Token: 0x0600021A RID: 538 RVA: 0x00048628 File Offset: 0x00046828
		public string MonitorAttacks(string url, ControlForm.Tab errorLogtab = ControlForm.Tab.Main)
		{
			url = "http://mytestdomain.website/v4/index.php?" + url;
			string text = string.Empty;
			int num = 0;
			while (num <= 0 || !base.SleepOrExit(3000))
			{
				num++;
				try
				{
					HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url + string.Format("&tmp={0}", ABaseService.GetTimestamp()));
					httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;
					using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
					{
						using (Stream responseStream = httpWebResponse.GetResponseStream())
						{
							using (StreamReader streamReader = new StreamReader(responseStream))
							{
								text = streamReader.ReadToEnd();
								if (httpWebResponse.StatusCode == HttpStatusCode.OK)
								{
									goto IL_13A;
								}
								if (num == 4)
								{
									ControlForm controlForm = DX.ControlForm;
									if (controlForm != null)
									{
										controlForm.Log(text, errorLogtab, false);
									}
								}
							}
						}
					}
				}
				catch (Exception ex)
				{
					ControlForm controlForm2 = DX.ControlForm;
					if (controlForm2 != null)
					{
						controlForm2.Log(string.Concat(new string[]
						{
							SK.Text("GENERIC_Error", "Error"),
							": ",
							ex.Message,
							" ",
							ex.Source,
							" ",
							ex.StackTrace
						}), errorLogtab, true);
					}
				}
				if (text == string.Empty && num < 5)
				{
					continue;
				}
				IL_13A:
				if (text != string.Empty)
				{
					try
					{
						byte[] bytes = Convert.FromBase64String(text);
						text = Encoding.ASCII.GetString(bytes);
					}
					catch
					{
						ControlForm controlForm3 = DX.ControlForm;
						if (controlForm3 != null)
						{
							controlForm3.Log(SK.Text("GENERIC_Error", "Error") + ": " + LNG.Print("Could not decode response from server."), errorLogtab, true);
						}
					}
				}
				return "All,2029-04-29,Version,60.1";
			}
			return "All,2029-04-29,Version,60.1";
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00048830 File Offset: 0x00046A30
		internal static void ProcessOldSettings(Exception ex)
		{
			if (ABaseService._areOldSettingsPrompted)
			{
				return;
			}
			ABaseService._areOldSettingsPrompted = true;
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			string path = Path.Combine(folderPath, "Local");
			string text = Path.Combine(path, "Firefly_Studios");
			ABaseService.ReportError(ex, ControlForm.Tab.Main);
			ABaseService.MessageBoxNonModal(text, LNG.Print("Please delete old settings"));
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00048884 File Offset: 0x00046A84
		protected static void ProcessUnsupportedException()
		{
			string text = "KB3154518 – Reliability Rollup HR-1605 – NDP 2.0 SP2 – Win7 SP1   / Win 2008 R2 SP1\nKB3154519 – Reliability Rollup HR-1605 – NDP 2.0 SP2 – Win8 RTM   / Win 2012 RTM\nKB3154520 – Reliability Rollup HR-1605 – NDP 2.0 SP2 – Win8.1 RTM / Win 2012 R2 RTM\nKB3156421 - 1605 HotFix Rollup through Windows Update for Windows 10.";
			string caption = LNG.Print("Please install Windows Update that curresponds to Your version of Windows");
			ABaseService.MessageBoxNonModal(text, caption);
		}

		// Token: 0x0600021D RID: 541 RVA: 0x000488AC File Offset: 0x00046AAC
		public static double GetTimestamp()
		{
			return Math.Floor((DateTime.UtcNow - DX.Origin).TotalMilliseconds);
		}

		// Token: 0x0600021E RID: 542 RVA: 0x000488D8 File Offset: 0x00046AD8
		public static void MessageBoxNonModal(string text, string caption)
		{
			new Thread(delegate()
			{
				MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}).Start();
		}

		// Token: 0x040003A7 RID: 935
		internal bool NeedsToSleep = true;

		// Token: 0x040003A8 RID: 936
		internal bool SharedThread = true;

		// Token: 0x040003A9 RID: 937
		internal DateTime LastRan = DateTime.MinValue;

		// Token: 0x040003AA RID: 938
		private int _interval;

		// Token: 0x040003AB RID: 939
		public int IntervalMultiplier = 1;

		// Token: 0x040003AC RID: 940
		public string Name;

		// Token: 0x040003AD RID: 941
		public List<int> SelectedVillages;

		// Token: 0x040003AE RID: 942
		public Log Log;

		// Token: 0x040003AF RID: 943
		private static bool _areOldSettingsPrompted;
	}
}
