using System;

namespace Kingdoms
{
	// Token: 0x0200047A RID: 1146
	internal static class Rot13
	{
		// Token: 0x060029AA RID: 10666 RVA: 0x00202858 File Offset: 0x00200A58
		public static string Transform(string value)
		{
			char[] array = value.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				int num = (int)array[i];
				if (num - 97 > 12)
				{
					if (num - 110 <= 12)
					{
						num -= 13;
					}
					else if (num - 65 > 12)
					{
						if (num - 78 <= 12)
						{
							num -= 13;
						}
					}
					else
					{
						num += 13;
					}
				}
				else
				{
					num += 13;
				}
				array[i] = (char)num;
			}
			return new string(array);
		}
	}
}
