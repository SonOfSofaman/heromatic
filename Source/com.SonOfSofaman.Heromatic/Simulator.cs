using System;
using System.Collections.Generic;
using System.Linq;

using com.SonOfSofaman.Heromatic.Encounters;

namespace com.SonOfSofaman.Heromatic
{
	public class Simulator
	{
		private Random RNG;
		private GameState GameState;
		private ulong TurnIndex;
		public SimulatorEventHandler SimulatorEvent { get; set; }
		private EncounterBuilder EncounterBuilder;

		public Simulator(Random rng, GameState gameState)
		{
			this.RNG = rng;
			this.GameState = gameState;
			this.TurnIndex = 0UL;
			this.EncounterBuilder = new EncounterBuilder(rng, gameState);
			this.EncounterBuilder.EncounterBuilderEvent += (object sender, EncounterBuilderEventArgs e) => { this.OnSimulatorEvent(e.Message); };
		}

		protected virtual void OnSimulatorEvent(string message)
		{
			SimulatorEventHandler simulatorEventHandler = this.SimulatorEvent;
			if (simulatorEventHandler != null) simulatorEventHandler(this, new SimulatorEventArgs(this.TurnIndex, message));
		}

		public void Run()
		{
			this.OnSimulatorEvent(string.Format("{0} begins a life of adventure in {1}, a place of which he is {2} fond.", this.GameState.Character, this.GameState.Character.Home.Name, this.GameState.Character.Home.Fondness));

			bool done = false;
			while (!done)
			{
				done = this.NextTurn();
			}
		}

		private bool NextTurn()
		{
			// Step 1: Resolve any encounters
			if (this.RNG.NextDouble() < 0.1)
			{
				Encounter encounter = this.EncounterBuilder.Construct();
				encounter.Resolve();
				this.GameState.Encounters.Add(encounter);
			}

			// Step 2: Move (or stay)
			Place place = this.GameState.Character.CurrentPlace;
			if (this.RNG.NextDouble() < place.Fondness)
			{
				this.OnSimulatorEvent(string.Format("{0} stays awhile in {1}.", this.GameState.Character, this.GameState.Character.CurrentPlace.Name));
			}
			else
			{
				Place currentPlace = this.GameState.Character.CurrentPlace;
				int routeIndex = RNG.Next(currentPlace.Routes.Count);
				List<Direction> directions = currentPlace.Routes.Keys.ToList();
				Direction directionToNextPlace = directions[routeIndex];
				Route routeToNextPlace = currentPlace.Routes[directionToNextPlace];
				bool isANewPlace = false;

				if (routeToNextPlace.Destination == null)
				{
					Direction reciprocal = (Direction)(((int)directionToNextPlace + 4) % 8);
					Place newPlace = PlaceMaker.MakePlace(this.RNG);
					this.GameState.Places.Add(newPlace);
					routeToNextPlace.Destination = newPlace;
					newPlace.Routes[reciprocal] = new Route(reciprocal, currentPlace);
					isANewPlace = true;
				}
				this.GameState.Character.Visit(routeToNextPlace.Destination);
				string placeMemo = isANewPlace ? ", a place he has never been to before." : ".";
				this.OnSimulatorEvent(string.Format("{0} travels to {1}{2}", this.GameState.Character, this.GameState.Character.CurrentPlace.Name, placeMemo));
			}

			// Step 3: Update the character
			double before = Math.Floor(this.GameState.Character.Age);
			this.GameState.Character.NextTurn();
			double after = Math.Floor(this.GameState.Character.Age);
			if (after > before)
			{
				this.OnSimulatorEvent(string.Format("{0} celebrates his {1} birthday!", this.GameState.Character, after.ToEnglishOrdinal()));
			}

			this.TurnIndex++;
			return (this.TurnIndex >= 100UL);
		}
	}
}
