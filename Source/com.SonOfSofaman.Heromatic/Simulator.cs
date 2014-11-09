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
			this.OnSimulatorEvent(String.Format("Turn #{0}", this.TurnIndex));
			this.TurnIndex++;
			return (this.TurnIndex >= 10UL);
		}
	}
}
