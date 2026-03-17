using System;
using System.Net;
using System.Net.Mail;
using Upgrade.Services;

namespace Upgrade
{
	// Token: 0x02000026 RID: 38
	public class MailService
	{
		// Token: 0x0600018B RID: 395 RVA: 0x0004096C File Offset: 0x0003EB6C
		public static string SendMail(string fromEmail, string fromPw, string toEmail, string subject, string info)
		{
			MailService.SmtpClient.Credentials = new NetworkCredential(fromEmail, fromPw);
			int num = 0;
			bool flag = true;
			string result;
			do
			{
				num++;
				try
				{
					MailService.SmtpClient.Send(fromEmail, toEmail, subject, info);
					result = string.Format("Email sent from {0} to {1}. Attempt: {2}", fromEmail, toEmail, num);
				}
				catch (Exception ex)
				{
					flag = false;
					result = string.Concat(new string[]
					{
						"Email was not sent. Error: ",
						ex.Message,
						" ",
						ex.Source,
						" ",
						ex.StackTrace
					});
					ABaseService.ReportError(ex, ControlForm.Tab.Radar);
				}
			}
			while (!flag && num < 5);
			return result;
		}

		// Token: 0x040002D8 RID: 728
		private static SmtpClient SmtpClient = new SmtpClient("smtp.gmail.com", 587)
		{
			EnableSsl = true,
			DeliveryMethod = SmtpDeliveryMethod.Network,
			UseDefaultCredentials = false
		};
	}
}
