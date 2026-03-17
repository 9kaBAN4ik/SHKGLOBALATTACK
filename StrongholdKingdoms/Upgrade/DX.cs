using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms;

namespace Upgrade
{
	// Token: 0x0200001F RID: 31
	internal class DX
	{
		// Token: 0x0600015D RID: 349 RVA: 0x00008C1B File Offset: 0x00006E1B
		internal static Config GetConfig()
		{
			return DX.Configs.FirstOrDefault((Config c) => c.Alias == RemoteServices.Instance.UserName);
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00008C46 File Offset: 0x00006E46
		internal static string GetConnectionInfo(string macAddress)
		{
			return string.Concat(new string[]
			{
				"9kaban4ikBot:\nYour Mac Address: ",
				macAddress,
				"\nYour IP Address: ",
				DX.GetPublicIP(),
				"Click me to change"
			});
		}

		// Token: 0x0600015F RID: 351 RVA: 0x0003F584 File Offset: 0x0003D784
		internal static string GetPublicIP()
		{
			string result;
			try
			{
				string text = DX.WebClient.DownloadString("http://icanhazip.com/");
				result = text;
			}
			catch (Exception ex)
			{
				DX.ShowErrorMessage(ex);
				result = "unknown\n";
			}
			return result;
		}

		// Token: 0x06000160 RID: 352 RVA: 0x0003F5C8 File Offset: 0x0003D7C8
		public static string Encode(string param)
		{
			byte[] bytes = Encoding.Unicode.GetBytes(param);
			return Convert.ToBase64String(bytes);
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00008C77 File Offset: 0x00006E77
		public static List<int> GetListOfIds(string setting)
		{
			return setting.Split(DX.SplitSymbol, StringSplitOptions.RemoveEmptyEntries).ToList<string>().ConvertAll<int>((string x) => int.Parse(x));
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00008CAE File Offset: 0x00006EAE
		public static string GetStringOfIds(IEnumerable<int> listOfIds)
		{
			return string.Join(",", (from x in listOfIds
			select x.ToString()).ToArray<string>());
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00008CE4 File Offset: 0x00006EE4
		public static int GetCap(int resourceType)
		{
			return (int)(GameEngine.Instance.World.UserResearchData.getResourceCap(GameEngine.Instance.LocalWorldData, resourceType, false) * CardTypes.getResourceCapMultiplier(resourceType, GameEngine.Instance.cardsManager.UserCardData));
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00008D1D File Offset: 0x00006F1D
		public static void ShowErrorMessage(Exception ex)
		{
			MessageBox.Show(ex.Source + " " + ex.StackTrace, ex.Message);
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00008D41 File Offset: 0x00006F41
		internal static void CloseBotWindow()
		{
			if (DX.ControlForm != null)
			{
				DX.ControlForm.IsProgrammaticClosing = true;
				DX.ControlForm.Close();
				DX.ControlForm = null;
			}
		}

		// Token: 0x06000166 RID: 358 RVA: 0x0003F5E8 File Offset: 0x0003D7E8
		internal static void ImportLeaderBoardInfo(LeaderboardDataMainClass line)
		{
			if (line.userID == RemoteServices.Instance.UserID)
			{
				DX.ControlForm.FiltersService.OurRank = Math.Abs(line.rank);
			}
			DX.Info.RemoveAll((LeaderBoardShortData u) => u.userID == line.userID);
			DX.Info.Add(new LeaderBoardShortData
			{
				userID = line.userID,
				userName = line.userName,
				numPoints = line.numPoints,
				rank = Math.Abs(line.rank)
			});
		}

		// Token: 0x06000167 RID: 359 RVA: 0x0003F6A8 File Offset: 0x0003D8A8
		internal static void ImportLeaderBoardInfo(string userName, int userID)
		{
			DX.Info.RemoveAll((LeaderBoardShortData u) => u.userID == userID);
			DX.Info.Add(new LeaderBoardShortData
			{
				userID = userID,
				userName = userName
			});
		}

		// Token: 0x040002B7 RID: 695
		public static ControlForm ControlForm;

		// Token: 0x040002B8 RID: 696
		public static bool SnoozeUpdates;

		// Token: 0x040002B9 RID: 697
		internal static string OverrideMAC;

		// Token: 0x040002BA RID: 698
		internal static string AuthorizedMAC;

		// Token: 0x040002BB RID: 699
		internal static List<Config> Configs = new List<Config>();

		// Token: 0x040002BC RID: 700
		internal static DateTime Origin = new DateTime(2019, 6, 13, 0, 0, 0, 0, DateTimeKind.Utc);

		// Token: 0x040002BD RID: 701
		internal static WebClient WebClient = new WebClient();

		// Token: 0x040002BE RID: 702
		private static readonly char[] SplitSymbol = new char[]
		{
			','
		};

		// Token: 0x040002BF RID: 703
		internal static readonly List<LeaderBoardShortData> Info = new List<LeaderBoardShortData>();
	}
}
