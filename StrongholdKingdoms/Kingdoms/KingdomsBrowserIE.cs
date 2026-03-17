using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x0200020D RID: 525
	public class KingdomsBrowserIE : WebBrowser
	{
		// Token: 0x170001AE RID: 430
		// (get) Token: 0x0600163F RID: 5695 RVA: 0x000178F8 File Offset: 0x00015AF8
		public bool HasResponse
		{
			get
			{
				return this.PageValues.Count > 0;
			}
		}

		// Token: 0x06001640 RID: 5696 RVA: 0x00017908 File Offset: 0x00015B08
		protected override void OnNavigated(WebBrowserNavigatedEventArgs e)
		{
			this.GetPageValues();
			base.OnNavigated(e);
		}

		// Token: 0x06001641 RID: 5697 RVA: 0x00160190 File Offset: 0x0015E390
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
			byte[] bytes = Encoding.UTF8.GetBytes(text);
			base.Navigate(url, string.Empty, bytes, KingdomsBrowserIE.PostContentType + Environment.NewLine);
		}

		// Token: 0x06001642 RID: 5698 RVA: 0x00160234 File Offset: 0x0015E434
		private void GetPageValues()
		{
			this.PageValues = new Dictionary<string, string>();
			HtmlElement elementById = base.Document.GetElementById("ClientFeedbackDIV");
			if (elementById != null)
			{
				HtmlElementCollection elementsByTagName = elementById.GetElementsByTagName("input");
				foreach (object obj in elementsByTagName)
				{
					HtmlElement htmlElement = (HtmlElement)obj;
					this.PageValues.Add(new KeyValuePair<string, string>(htmlElement.Id, htmlElement.GetAttribute("value")));
				}
			}
		}

		// Token: 0x06001643 RID: 5699 RVA: 0x00017917 File Offset: 0x00015B17
		public string GetPageValueByID(string id)
		{
			return base.Document.GetElementById(id).GetAttribute("value");
		}

		// Token: 0x04002685 RID: 9861
		public static string PostContentType = "Content-Type: application/x-www-form-urlencoded";

		// Token: 0x04002686 RID: 9862
		public IDictionary<string, string> PageValues;
	}
}
