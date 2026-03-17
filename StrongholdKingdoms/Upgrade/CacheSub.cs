using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Kingdoms;
using Upgrade.Services;

namespace Upgrade
{
	// Token: 0x02000012 RID: 18
	internal class CacheSub
	{
		// Token: 0x0600002C RID: 44 RVA: 0x000274A4 File Offset: 0x000256A4
		private static string GetFilePath()
		{
			string path = Path.Combine(ControlForm.SettingsFolder, RemoteServices.Instance.UserName);
			return Path.Combine(path, "key.bin");
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000274D4 File Offset: 0x000256D4
		private static byte[] GetFile()
		{
			string filePath = CacheSub.GetFilePath();
			byte[] result = null;
			if (File.Exists(filePath))
			{
				result = File.ReadAllBytes(filePath);
			}
			else
			{
				MessageBox.Show(filePath, LNG.Print("File doesn't exist"));
			}
			return result;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x0002750C File Offset: 0x0002570C
		private static string Decrypt()
		{
			byte[] file = CacheSub.GetFile();
			if (file == null)
			{
				return string.Empty;
			}
			CacheSub.rsa.FromXmlString(CacheSub._privateKey);
			byte[] bytes = CacheSub.rsa.Decrypt(file, false);
			return CacheSub._encoder.GetString(bytes);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00027550 File Offset: 0x00025750
		internal static string Load()
		{
			ControlForm controlForm = DX.ControlForm;
			if (controlForm == null || controlForm.GetService<MonitorService>().IsConnectionRelevant())
			{
				MessageBox.Show(LNG.Print("Reconnection is not required"));
				return string.Empty;
			}
			string text = CacheSub.Decrypt();
			if (string.IsNullOrEmpty(text))
			{
				return string.Empty;
			}
			string[] array = text.Split(new char[]
			{
				','
			});
			if (array.Length == 0 || array[0] != RemoteServices.Instance.UserName)
			{
				MessageBox.Show(LNG.Print("Incorrect file"));
				return string.Empty;
			}
			List<string> list = new List<string>();
			int num = 1;
			while (num < array.Length && !(array[num] == "Version"))
			{
				if (DateTime.Parse(array[num + 1]) > DateTime.Now)
				{
					list.Add(array[num]);
					list.Add(array[num + 1]);
				}
				num += 2;
			}
			return string.Join(",", list.ToArray());
		}

		// Token: 0x06000030 RID: 48 RVA: 0x0002763C File Offset: 0x0002583C
		private static string DataToCache()
		{
			Config config = DX.GetConfig();
			if (config == null || config.Settings == null || config.Settings.Count == 0)
			{
				return string.Empty;
			}
			return config.Alias + "," + string.Join(",", config.Settings.ToArray());
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00027694 File Offset: 0x00025894
		public static void Encrypt()
		{
			CacheSub.rsa.FromXmlString(CacheSub._publicKey);
			byte[] bytes = CacheSub._encoder.GetBytes(CacheSub.DataToCache());
			byte[] bytes2 = CacheSub.rsa.Encrypt(bytes, false).ToArray<byte>();
			string filePath = CacheSub.GetFilePath();
			File.WriteAllBytes(filePath, bytes2);
			DX.ControlForm.Log(LNG.Print("Settings are saved to") + " account folder", ControlForm.Tab.Main, false);
		}

		// Token: 0x04000064 RID: 100
		private static string _privateKey = "<RSAKeyValue><Modulus>oan44ujy3f7AICKGFgmWbEHOzLiF3Uvfix5dxrxDJ0IHKJr/Npn+sHKSCaJMBSALkrUQSm2lBTGxMYFcLKxGBr3ulw4ZEwRKYxdk/wfwJvXtMRODcj6eztekBhJ7xSFchalo7/e0EBgUeHoZzlml+vZnly3ZCcObf4uYT1IKExa5sJfidTx31Hyq84gTqDd+6jy6s3r1PIxA0DbXZ13O1iLkG30jFNN9n7DU0pofwWx6mQy4QoyRGDyhDUPCr6v0QckcXLuc8lFyARc/8tAlPT0vGiPr8/q37XfDXxxpVr6jNXVQkol2WLJt0MT0QK0Tp5Uyjx9y9iXsoO0vJPnaJ3HUV0K97Qwdq1Rlk5dAS+Qv8gb6b5/XUNUlL0aTbeKUG/oCEAIlPWb+OaNgKSZ0MkO155lqDUOFt2NrKCEwALoRB+3jYmcLbk2+f4cGwYLDoYE+3qICRnVlRMivblCvolzPbh8UknfWd4MQfW1/tj/1qYbwsijOK6804DkMCdclQ5JXbp5f35EijUoZO1a4/80bbED0RLBYcrs2ADWvlDcQEV85tuWyeiyNTrGRiNqDBsBAvxl5QuzrDxjbWZpiv7LZoCFc10Wy5Z3DJ3JyseHfVUhCv2P1NXy6bp2tv6E4HKyE2CQx+yEZ2EsZ3G1SCOY96wi8tDG+Kb4jXHeW4O0=</Modulus><Exponent>AQAB</Exponent><P>3KjSeVILwHnrEpDEFHtw86g9f4dHJfc7iZf/hV34TGVgTo9XMUhYehqo8+e4TAZ2FM+WhVD205D0qP6r/a7JB5IX3fpzG4vH6JXnz9w+VaOZrUjfD9GYlUOUedP3yFniKOlwgAEzERGPDiZXobrcBx/6gecl0dFY0MjrqHFO6Eqq4eYByxXVfQ0LLOJ3W0v8JD8Dm2Ppk9EjAULpMRfmT3UiWnTxHeBjUQZHYhKu3AHaVg0STaosQYxg7E5syFOxqtGIGBzAnF8LVNV10e+nWPPxGblvhcpTcXDmA9S3zeHm4ER2TMeXJitR0DERtLRo7x6kQ3ka8f3trA1dBiB7rw==</P><Q>u45L/QKSEWwihFv6oZ9S2M8HkMOn2HMeSpRxJiFBKTv3Mo1R3Tk4aiKZtaN9eldYz10XyGgAV6KJvbZ0YS/yAcyF0z7Yko57kVvBFLidpO8RtZFaJdFdB/+hVjuidSMVDfJfNZ81ibKeg/Ngz489siKrVF3/MiVVsyx3lvPdntt1MnP+MexmMzoYQwCt6QDLv8qrynJ0YqsnMGaZDwv2MZg0PXro8bowTxE9yKYU2sw8bg/yZoKVcB4wdDu6P1ityMkDaCUA7zxBHd48PvWkAXBGdpn4+cxGXLUrEKrHFZ3YjlTna/10rR58kfQkElHsbLIc7UeSNiS+Ptqg/t+IIw==</Q><DP>qVjjl3qRTFoFQE1cPv/x0v4mnI4823Vf+xxtXXSeEDupawF1gHwucx+s1OvctHQtAZHDynM1y28vZdd2Ng6DeEz2BkWlO9nORcFulEdKi70wPx5zGxfXy45/D/TO8LOS76Ug0wyYnZvlN43TqWrYXJt9TV8R1nKdgDcDLVYwofRUK2SzsaIDI6L0FbGEusuZKlQ2N3a5l9lkzR4GC8h02DxkbhnbxvskHdX8yNbf3jeJ0orbpkFZD8FlzVXvBNu+ugNvOFowtJH5B1V/w+vyekFVo1F+tqZt3d0wmnYRzm92Gl5QkGKJrSCH/Ij8NrxS4Fma5bG3LUudsXLcFsytPw==</DP><DQ>GoMS2sDyROQ0POGDnDUZUOxy9VOy9jXPols5Y1pwC5QebVbsq4jbIKWjdLmXkyOluio+omWRJtIjBl40NUjBvN9cS3AmzRC3BuUhdfxizF2+8xuI0q+1ptvLwpTLciNzZnVMYBgRSVWmcqCEntJwti2QamyfFkeQxbMTdJMkUMBU4LzkwcnY6ITdyRrfeoBSTNopToS/TvNCpuTZ3fai5n/NYqNtKj5XddXKFgLkD8mvAR/f8/2hgifCUavft/ShHDDN+nrAlxC9Y6t2eK/gbxOf4kQBnc3yZEh3vfNmEPgvFG+MBwfc5lvY4AjS0IQkF3lV/XSQhnbLLbdZ6q1OYQ==</DQ><InverseQ>cMrBSe12Kz79dLeCxRjnBZ7PqiXRscvlCsc1azVRG+Z0Cu9mUX5LmeCC1lrzxqV1sznGWpDrClcA6UOkTqMYIt2Ak1U/5FkVgI+QeGfI2CRFDkNUCTMZr0TBNwNHkguE48mHFtpxN/fmokmfD4LrUJrrS5PlXhjLw0Rge3kRxqMP5MLuFpQ378CgtoAkq3J0T3Y2tu9N0TYd4RejhT7zGOyIAZB1VMk1LH1mX4Vl41lBzHHU4m3gDnSRauWMkAd/GJvSTtJsKP259sBtj9xuWwDILPVUEkq6o+VwKiR23khW5RVw7W1Y1evvg3zsz69lVP73NwjfPrDVCb3+90E8tg==</InverseQ><D>KRnjsxzykkowYnskh/nMCp34i8fmEMs3fFEuGlbG4/Y/h61QcXtZa1bVlilzFmJ9TsFF8QZLTDTEDggLfTgXXaNwQ2tMKK+QkfziqoxEHEOuGCoT4znUelYM15ZfbVD8Cud1TH03hFf67F5urS3Rqyp2T9NSOM9Ie3bsNE5xTUUb1K/o3VGQTa+cbuoLxVrGo5rpBLSgINKvr8Ahp6AL9BlO0UZRYvwaFj2I/jo9FJoV2U+IkTLXuMfBUnQFzU/0e707vr/cOSdHyss0cPFGZnllvkmftZnqpS8rtsSsa2dwayj2YSsdsZM7pDZOuxrFwneGMSkXu0kNDiT/NXFoavMWq9gcdg4hEbOYQtczCZSuWRsmp5di8rGGjD81Ndb1Kcpq2G/dDwD3OlNuNqoZRw6E/tIlpa5tSRvG09Ytf4Ba+/OMctZ2SiMrEu6d8nNbr1cu03foC8/HaPMA/5QZ77VoaL/6zqHsAmyG8LIGl1MPtEJ4exwAxUv3ijiWmfG6tjVT94qDGiUS46ic06O/a7+PyOoUghKCzLObynJhIUXfD8mXF9Q+o1jWoXPtLMHVQKZkFwGmH70Gum/gBPGT+Ihb60zCbBWx5jkyZu90WbrcLEQVT4wkGYSbJ+S2o7MYamxRsAAb5ANufvaBLNVerbjl5BuLceaZZ7YKhAqyHGk=</D></RSAKeyValue>";

		// Token: 0x04000065 RID: 101
		private static string _publicKey = "<RSAKeyValue><Modulus>oan44ujy3f7AICKGFgmWbEHOzLiF3Uvfix5dxrxDJ0IHKJr/Npn+sHKSCaJMBSALkrUQSm2lBTGxMYFcLKxGBr3ulw4ZEwRKYxdk/wfwJvXtMRODcj6eztekBhJ7xSFchalo7/e0EBgUeHoZzlml+vZnly3ZCcObf4uYT1IKExa5sJfidTx31Hyq84gTqDd+6jy6s3r1PIxA0DbXZ13O1iLkG30jFNN9n7DU0pofwWx6mQy4QoyRGDyhDUPCr6v0QckcXLuc8lFyARc/8tAlPT0vGiPr8/q37XfDXxxpVr6jNXVQkol2WLJt0MT0QK0Tp5Uyjx9y9iXsoO0vJPnaJ3HUV0K97Qwdq1Rlk5dAS+Qv8gb6b5/XUNUlL0aTbeKUG/oCEAIlPWb+OaNgKSZ0MkO155lqDUOFt2NrKCEwALoRB+3jYmcLbk2+f4cGwYLDoYE+3qICRnVlRMivblCvolzPbh8UknfWd4MQfW1/tj/1qYbwsijOK6804DkMCdclQ5JXbp5f35EijUoZO1a4/80bbED0RLBYcrs2ADWvlDcQEV85tuWyeiyNTrGRiNqDBsBAvxl5QuzrDxjbWZpiv7LZoCFc10Wy5Z3DJ3JyseHfVUhCv2P1NXy6bp2tv6E4HKyE2CQx+yEZ2EsZ3G1SCOY96wi8tDG+Kb4jXHeW4O0=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

		// Token: 0x04000066 RID: 102
		private static UnicodeEncoding _encoder = new UnicodeEncoding();

		// Token: 0x04000067 RID: 103
		private static RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(4096);
	}
}
