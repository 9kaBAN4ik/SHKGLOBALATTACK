using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Kingdoms
{
	// Token: 0x0200012D RID: 301
	public class Censor
	{
		// Token: 0x06000B0F RID: 2831 RVA: 0x0000E3A7 File Offset: 0x0000C5A7
		public Censor(IEnumerable<string> censoredWords)
		{
			if (censoredWords == null)
			{
				throw new ArgumentNullException("censoredWords");
			}
			this.CensoredWords = new List<string>(censoredWords);
		}

		// Token: 0x06000B10 RID: 2832 RVA: 0x000E04A0 File Offset: 0x000DE6A0
		public string CensorText(string text)
		{
			if (text == null)
			{
				throw new ArgumentNullException("text");
			}
			string text2 = text;
			foreach (string wildcardSearch in this.CensoredWords)
			{
				string pattern = this.ToRegexPattern(wildcardSearch);
				text2 = Regex.Replace(text2, pattern, new MatchEvaluator(Censor.StarCensoredMatch), RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
			}
			return text2;
		}

		// Token: 0x06000B11 RID: 2833 RVA: 0x000E0518 File Offset: 0x000DE718
		private static string StarCensoredMatch(Match m)
		{
			string value = m.Captures[0].Value;
			return new string('*', value.Length);
		}

		// Token: 0x06000B12 RID: 2834 RVA: 0x000E0544 File Offset: 0x000DE744
		private string ToRegexPattern(string wildcardSearch)
		{
			string text = Regex.Escape(wildcardSearch);
			text = text.Replace("\\*", ".*?");
			text = text.Replace("\\?", ".");
			if (text.StartsWith(".*?"))
			{
				text = text.Substring(3);
				text = "(^\\b)*?" + text;
				return "(^\\b)*?" + text + "\\b";
			}
			return "\\b" + text + "\\b";
		}

		// Token: 0x04000F4A RID: 3914
		public IList<string> CensoredWords;
	}
}
