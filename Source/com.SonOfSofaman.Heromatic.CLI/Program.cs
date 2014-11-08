using System;

namespace com.SonOfSofaman.Heromatic.CLI
{
	class Program
	{
		static void Main(string[] args)
		{
			Parameters parameters = new Parameters(args);
			if (parameters.Valid)
			{
				int seed = parameters.Seed;
			}
			else
			{
				Console.WriteLine("SYNTAX:\n\n\theromatic {{seed}}\n\n\twhere\n\n\t{{seed}} between {0} and {1}, inclusive.", Int32.MinValue, Int32.MaxValue);
			}
		}
	}
}
