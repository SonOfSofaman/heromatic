using System;

namespace com.SonOfSofaman.Heromatic.CLI
{
	class Program
	{
		internal static Random RNG { get; private set; }

		static void Main(string[] args)
		{
			Parameters parameters = new Parameters(args);
			if (parameters.Valid)
			{
				Program.RNG = new Random(parameters.Seed);

				Character character = CharacterBuilder.Construct(parameters.ManualCharacterName, parameters.CharacterName);

				Console.WriteLine("{0} begins a life of adventure!", character.Name);
			}
			else
			{
				Console.WriteLine("SYNTAX:\n\n\theromatic {{seed}}\n\n\twhere\n\n\t{{seed}} between {0} and {1}, inclusive.", Int32.MinValue, Int32.MaxValue);
			}
		}
	}
}
