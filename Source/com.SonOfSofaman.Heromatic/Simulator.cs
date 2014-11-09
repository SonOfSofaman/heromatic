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
			this.OnSimulatorEvent(String.Format("{0} begins a life of adventure in {1}, a place of which he is {2} fond.", this.GameState.Character.Name, this.GameState.Character.Home.Name, this.GameState.Character.Home.Fondness));

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
			Place place = this.GameState.Character.CurrentPlace;
			if (this.RNG.NextDouble() < place.Fondness)
			{
				this.OnSimulatorEvent("Stays put. He likes it here.");
			}
			else
			{
				this.OnSimulatorEvent("Moves somewhere else.");
			}

			this.TurnIndex++;
			return (this.TurnIndex >= 10UL);
		}
	}
}
