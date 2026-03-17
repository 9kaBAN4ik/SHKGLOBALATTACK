using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Properties
{
	// Token: 0x020000B0 RID: 176
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000481 RID: 1153 RVA: 0x00007CD8 File Offset: 0x00005ED8
		internal Resources()
		{
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000482 RID: 1154 RVA: 0x0005E240 File Offset: 0x0005C440
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					ResourceManager resourceManager = new ResourceManager("Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000483 RID: 1155 RVA: 0x0000A23B File Offset: 0x0000843B
		// (set) Token: 0x06000484 RID: 1156 RVA: 0x0000A242 File Offset: 0x00008442
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x0400059E RID: 1438
		private static ResourceManager resourceMan;

		// Token: 0x0400059F RID: 1439
		private static CultureInfo resourceCulture;
	}
}
