using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Upgrade.Services
{
	// Token: 0x0200003A RID: 58
	internal class AutoUpdates
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000221 RID: 545 RVA: 0x00009243 File Offset: 0x00007443
		internal static string UpdaterExeFile
		{
			get
			{
				return Application.StartupPath + "/updater.exe";
			}
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00009254 File Offset: 0x00007454
		internal static void ProcessUpdater()
		{
			if (AutoUpdates.CheckUpdater())
			{
				AutoUpdates.DownloadUpdater();
			}
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00009262 File Offset: 0x00007462
		internal static bool ProcessGame()
		{
			return false;
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00048910 File Offset: 0x00046B10
		internal static bool CheckUpdater()
		{
			string address = "http://mytestdomain.website/auto/versions.txt";
			string receivedVersion;
			try
			{
				string text = DX.WebClient.DownloadString(address);
				string[] array = text.Split(new char[]
				{
					';'
				});
				receivedVersion = array[0];
				AutoUpdates.receivedGameVersion = array[1];
			}
			catch (Exception ex)
			{
				DX.ShowErrorMessage(ex);
				return false;
			}
			if (!File.Exists(AutoUpdates.UpdaterExeFile))
			{
				return true;
			}
			string updaterVersion = AutoUpdates.GetUpdaterVersion();
			return MonitorService.IsHigherVersion(receivedVersion, updaterVersion);
		}

		// Token: 0x06000225 RID: 549 RVA: 0x00048990 File Offset: 0x00046B90
		private static string GetUpdaterVersion()
		{
			FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(AutoUpdates.UpdaterExeFile);
			return versionInfo.ProductVersion;
		}

		// Token: 0x06000226 RID: 550 RVA: 0x000489B0 File Offset: 0x00046BB0
		internal static void DownloadUpdater()
		{
			string address = "http://mytestdomain.website/auto/updater.exe";
			try
			{
				DX.WebClient.DownloadFile(address, "updater.exe");
			}
			catch (Exception ex)
			{
				DX.ShowErrorMessage(ex);
			}
		}

		// Token: 0x06000227 RID: 551 RVA: 0x000489F0 File Offset: 0x00046BF0
		internal static bool StartAutomaticUpdate(string receivedGameVersion)
		{
			bool result;
			try
			{
				if (!File.Exists(AutoUpdates.UpdaterExeFile))
				{
					result = false;
				}
				else
				{
					Process.Start(new ProcessStartInfo(AutoUpdates.UpdaterExeFile)
					{
						Arguments = "http://mytestdomain.website " + receivedGameVersion
					});
					result = true;
				}
			}
			catch (Exception ex)
			{
				DX.ShowErrorMessage(ex);
				result = false;
			}
			return result;
		}

		// Token: 0x040003B2 RID: 946
		private static string receivedGameVersion;
	}
}
