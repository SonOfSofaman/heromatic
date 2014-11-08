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
				Random RNG = new Random(parameters.Seed);
				GameState gameState = GameStateBuilder.Construct(RNG, parameters.ManualCharacterName, parameters.CharacterName);

				Console.Clear();
				Console.WriteLine("{0} begins a life of adventure in {1}!", gameState.Character.Name, gameState.Character.Home.Name);
			}
			else
			{
				Console.WriteLine("SYNTAX:\n\n\theromatic {{seed}}\n\n\twhere\n\n\t{{seed}} between {0} and {1}, inclusive.", Int32.MinValue, Int32.MaxValue);
			}
		}
	}
}
