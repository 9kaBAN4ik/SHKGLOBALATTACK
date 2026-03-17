using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Gecko;
using Gecko.Events;
using Gecko.IO;

namespace Kingdoms
{
	// Token: 0x0200020C RID: 524
	public class KingdomsBrowserGecko : GeckoWebBrowser
	{
		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06001634 RID: 5684 RVA: 0x00017874 File Offset: 0x00015A74
		public bool HasResponse
		{
			get
			{
				return this.PageValues.Count > 0;
			}
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06001635 RID: 5685 RVA: 0x0015FF34 File Offset: 0x0015E134
		// (remove) Token: 0x06001636 RID: 5686 RVA: 0x0015FF6C File Offset: 0x0015E16C
		public event ClientFedbackEventHandler ClientFeedback;

		// Token: 0x06001637 RID: 5687 RVA: 0x00017884 File Offset: 0x00015A84
		protected virtual void OnClientFeedback(EventArgs e)
		{
			if (this.ClientFeedback != null)
			{
				this.ClientFeedback(this, e);
			}
		}

		// Token: 0x06001638 RID: 5688 RVA: 0x0001789B File Offset: 0x00015A9B
		protected override void OnStatusTextChanged(EventArgs e)
		{
			if (base.StatusText == "GiveClientFeedback")
			{
				this.GetPageValues();
				if (this.HasResponse)
				{
					this.OnClientFeedback(e);
				}
			}
			base.OnStatusTextChanged(e);
		}

		// Token: 0x06001639 RID: 5689 RVA: 0x0015FFA4 File Offset: 0x0015E1A4
		protected override void OnDocumentCompleted(GeckoDocumentCompletedEventArgs e)
		{
			this.GetPageValues();
			this.OnClientFeedback(e);
			base.OnDocumentCompleted(e);
			string query = base.Url.Query;
			if (query.Contains("&url"))
			{
				string[] array = query.Split(new string[]
				{
					"&url="
				}, StringSplitOptions.None);
				new Process
				{
					StartInfo = 
					{
						FileName = array[1]
					}
				}.Start();
			}
		}

		// Token: 0x0600163A RID: 5690 RVA: 0x000178CB File Offset: 0x00015ACB
		public void Navigate(Uri url)
		{
			base.Navigate(url.AbsoluteUri);
		}

		// Token: 0x0600163B RID: 5691 RVA: 0x00160010 File Offset: 0x0015E210
		public void Navigate(Uri url, IDictionary<string, string> postVars)
		{
			string text = string.Empty;
			foreach (KeyValuePair<string, string> keyValuePair in postVars)
			{
				if (text != string.Empty)
				{
					text += "&";
				}
				text = text + keyValuePair.Key + "=" + keyValuePair.Value;
			}
			Encoding.UTF8.GetBytes(text);
			MimeInputStream mimeInputStream = MimeInputStream.Create();
			mimeInputStream.AddHeader("Content-Type", "application/x-www-form-urlencoded");
			mimeInputStream.AddContentLength = true;
			mimeInputStream.SetData(text);
			base.Navigate(url.AbsoluteUri, GeckoLoadFlags.None, null, mimeInputStream);
		}

		// Token: 0x0600163C RID: 5692 RVA: 0x001600CC File Offset: 0x0015E2CC
		private void GetPageValues()
		{
			if (this.PageValues != null)
			{
				this.PageValues.Clear();
			}
			else
			{
				this.PageValues = new Dictionary<string, string>();
			}
			string[] array = base.Document.Cookie.Split(new char[]
			{
				';'
			});
			if (array.Length == 0)
			{
				return;
			}
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (text.Trim().StartsWith("KingdomsFeedback_", true, null))
				{
					string[] array4 = text.Split(new char[]
					{
						'='
					});
					if (array4.Length == 2)
					{
						this.PageValues.Add(new KeyValuePair<string, string>(array4[0].Trim().Remove(0, "KingdomsFeedback_".Length), array4[1]));
					}
				}
			}
		}

		// Token: 0x04002681 RID: 9857
		public List<object> imageObjects = new List<object>();

		// Token: 0x04002682 RID: 9858
		public static string PostContentType = "Content-Type: application/x-www-form-urlencoded";

		// Token: 0x04002683 RID: 9859
		public IDictionary<string, string> PageValues;
	}
}
