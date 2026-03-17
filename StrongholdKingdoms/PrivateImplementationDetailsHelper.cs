using System;

// Helper class to replace compiler-generated PrivateImplementationDetails
internal static class PrivateImplementationDetails
{
	public static uint ComputeStringHash(string s)
	{
		if (s == null)
		{
			return 0U;
		}
		uint num = 2166136261U;
		for (int i = 0; i < s.Length; i++)
		{
			num = ((uint)s[i] ^ num) * 16777619U;
		}
		return num;
	}
}
