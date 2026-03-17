using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Kingdoms.AssetIcons.RankAnims
{
	// Token: 0x0200052E RID: 1326
	[CompilerGenerated]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
	[DebuggerNonUserCode]
	internal class RankAnims
	{
		// Token: 0x17000579 RID: 1401
		// (get) Token: 0x060036AA RID: 13994 RVA: 0x002B4EB0 File Offset: 0x002B30B0
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (RankAnims.resourceMan == null)
				{
					RankAnims.resourceMan = new ResourceManager("Kingdoms.AssetIcons.RankAnims.RankAnims", typeof(RankAnims).Assembly);
				}
				return RankAnims.resourceMan;
			}
		}

		// Token: 0x1700057A RID: 1402
		// (get) Token: 0x060036AB RID: 13995 RVA: 0x0002541F File Offset: 0x0002361F
		// (set) Token: 0x060036AC RID: 13996 RVA: 0x00025426 File Offset: 0x00023626
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return RankAnims.resourceCulture;
			}
			set
			{
				RankAnims.resourceCulture = value;
			}
		}

		// Token: 0x1700057B RID: 1403
		// (get) Token: 0x060036AD RID: 13997 RVA: 0x002B4EEC File Offset: 0x002B30EC
		internal static Bitmap crown_prince
		{
			get
			{
				object @object = RankAnims.ResourceManager.GetObject("crown_prince", RankAnims.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x1700057C RID: 1404
		// (get) Token: 0x060036AE RID: 13998 RVA: 0x002B4F14 File Offset: 0x002B3114
		internal static Bitmap lords
		{
			get
			{
				object @object = RankAnims.ResourceManager.GetObject("lords", RankAnims.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x1700057D RID: 1405
		// (get) Token: 0x060036AF RID: 13999 RVA: 0x002B4F3C File Offset: 0x002B313C
		internal static byte[] lords_uv
		{
			get
			{
				object @object = RankAnims.ResourceManager.GetObject("lords_uv", RankAnims.resourceCulture);
				return (byte[])@object;
			}
		}

		// Token: 0x060036B0 RID: 14000 RVA: 0x00007CD8 File Offset: 0x00005ED8
		internal RankAnims()
		{
		}

		// Token: 0x04004108 RID: 16648
		private static ResourceManager resourceMan;

		// Token: 0x04004109 RID: 16649
		private static CultureInfo resourceCulture;
	}
}
