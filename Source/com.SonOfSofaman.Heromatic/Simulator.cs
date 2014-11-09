using System;

namespace com.SonOfSofaman.Heromatic
{
	public class Simulator
	{
		private Random RNG;
		private GameState GameState;
		private ulong TurnIndex;
		public SimulatorEventHandler SimulatorEvent { get; set; }

		public Simulator(Random rng, GameState gameState)
		{
			this.RNG = rng;
			this.GameState = gameState;
			this.TurnIndex = 0UL;
		}

		protected virtual void OnSimulatorEvent(string message)
		{
			SimulatorEventHandler simulatorEventHandler = this.SimulatorEvent;
			if (simulatorEventHandler != null) simulatorEventHandler(this, new SimulatorEventArgs(this.TurnIndex, message));
		}

		public void Run()
		{
			this.OnSimulatorEvent(String.Format("{0} begins a life of adventure in {1}!", this.GameState.Character.Name, this.GameState.Character.Home.Name));

			bool done = false;
			while (!done)
			{
				done = this.NextTurn();
			}
		}

		private bool NextTurn()
		{
			// Step 1: Resolve any encounters
			// TODO: Implement an encounter generator and resolver. The result of any encounter may affect a character's fondness of place in which the encounter took place.

			// Step 2: Move (or stay)
			// TODO: Base this decision on the character's fondness for a place.
			switch (this.RNG.Next(4))
			{
				case 0:
				{
					this.OnSimulatorEvent("Stays put. He likes it here.");
					break;
				}
				default:
				{
					this.OnSimulatorEvent("Moves somewhere else.");
					break;
				}
			}

			this.TurnIndex++;
			return (this.TurnIndex >= 10UL);
		}
	}
}
