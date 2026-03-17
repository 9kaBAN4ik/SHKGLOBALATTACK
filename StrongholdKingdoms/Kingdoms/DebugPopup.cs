using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CompressedSink;

namespace Kingdoms
{
	// Token: 0x02000197 RID: 407
	public partial class DebugPopup : Form
	{
		// Token: 0x06000FB4 RID: 4020 RVA: 0x000116F4 File Offset: 0x0000F8F4
		public DebugPopup()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06000FB5 RID: 4021 RVA: 0x00114438 File Offset: 0x00112638
		public void run()
		{
			string text = string.Concat(new string[]
			{
				CompressedClientSink.realDataSent.ToString(),
				" (",
				CompressedClientSink.rawDataSent.ToString(),
				") Pkts: ",
				CompressedClientSink.packetsSent.ToString()
			});
			string text2 = string.Concat(new string[]
			{
				CompressedClientSink.rawDataReceived.ToString(),
				" (",
				(CompressedClientSink.realDataReceived - CompressedClientSink.midDataReceived).ToString(),
				"/",
				CompressedClientSink.realDataReceived.ToString(),
				") Pkts: ",
				CompressedClientSink.packetsReceived.ToString()
			});
			this.lblNetworkDataSent.Text = text;
			this.lblNetworkDataReceived.Text = text2;
			this.lblAverageRTT.Text = ((int)RemoteServices.Instance.RTTAverageTime).ToString();
			this.lblAverageShortRTT.Text = ((int)RemoteServices.Instance.RTTAverageShortTime).ToString();
			this.lblAverageLongRTT.Text = ((int)RemoteServices.Instance.RTTAverageLongTime).ToString();
			this.lblTimeouts.Text = RemoteServices.Instance.RTTTimeOuts.ToString();
			this.lblShortCount.Text = RemoteServices.Instance.RTTAverageShortCount.ToString();
			this.lblLongCount.Text = RemoteServices.Instance.RTTAverageLongCount.ToString();
			List<RemoteServices.RTT_Log_data> detailedLogging = RemoteServices.Instance.getDetailedLogging();
			if (this.lastNumLines != detailedLogging.Count)
			{
				bool flag = true;
				StringBuilder stringBuilder = new StringBuilder();
				try
				{
					foreach (RemoteServices.RTT_Log_data rtt_Log_data in detailedLogging)
					{
						string text3 = rtt_Log_data.packetType.Name + "               ";
						text3 = ((rtt_Log_data.time >= 0) ? (text3 + rtt_Log_data.time.ToString()) : (text3 + "TimeOut"));
						stringBuilder.AppendLine(text3);
					}
				}
				catch (Exception)
				{
					flag = false;
				}
				if (flag)
				{
					this.tbDetailedLogging.Text = stringBuilder.ToString();
					this.lastNumLines = detailedLogging.Count;
				}
			}
		}

		// Token: 0x040015D1 RID: 5585
		public int lastNumLines;
	}
}
