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
				Console.Clear();

				Random RNG = new Random(parameters.Seed);
				GameState gameState = GameStateBuilder.Construct(RNG, parameters.ManualCharacterName, parameters.CharacterName);
				gameState.Character.CharacterEvent += (object sender, CharacterEventArgs e) => { Console.WriteLine("\t{0}", e.Message); };
				Simulator simulator = new Simulator(RNG, gameState);
				simulator.SimulatorEvent += (object sender, SimulatorEventArgs e) => { Console.WriteLine("{0}\t{1}", e.TurnIndex, e.Message); };
				simulator.Run();
			}
			else
			{
				Console.WriteLine("SYNTAX:\n\n\theromatic {{seed}}\n\n\twhere\n\n\t{{seed}} between {0} and {1}, inclusive.", Int32.MinValue, Int32.MaxValue);
			}
		}
	}
}
