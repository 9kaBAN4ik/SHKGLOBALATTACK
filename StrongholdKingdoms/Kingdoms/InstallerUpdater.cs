using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Cache;

namespace Kingdoms
{
	// Token: 0x02000207 RID: 519
	public class InstallerUpdater
	{
		// Token: 0x06001451 RID: 5201 RVA: 0x0015A414 File Offset: 0x00158614
		public static string downloadSelfUpdater(Uri uri)
		{
			WebClient webClient = new WebClient();
			RequestCachePolicy requestCachePolicy = webClient.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
			string text = Path.GetTempPath() + Path.GetFileName(uri.AbsolutePath);
			try
			{
				webClient.DownloadFile(uri, text);
				return text;
			}
			catch (Exception)
			{
			}
			return "";
		}

		// Token: 0x06001452 RID: 5202 RVA: 0x0015A478 File Offset: 0x00158678
		public static bool runInstaller(string path)
		{
			string fileName = Path.GetFileName(path);
			path = Path.GetDirectoryName(path);
			Process process = new Process();
			process.StartInfo = new ProcessStartInfo(fileName);
			process.StartInfo.WorkingDirectory = path;
			process.Start();
			return true;
		}
	}
}
