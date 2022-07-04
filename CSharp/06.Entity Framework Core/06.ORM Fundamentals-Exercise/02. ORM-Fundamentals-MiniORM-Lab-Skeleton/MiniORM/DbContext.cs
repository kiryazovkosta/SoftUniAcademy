namespace MiniORM
{
	using System;

	// TODO: Create your DbContext class here.
	public class DbContext
    {
		internal static readonly Type[] AllowedSqlTypes =
{
			typeof(string),
			typeof(int),
			typeof(uint),
			typeof(long),
			typeof(ulong),
			typeof(decimal),
			typeof(bool),
			typeof(DateTime)
		};
	}
}