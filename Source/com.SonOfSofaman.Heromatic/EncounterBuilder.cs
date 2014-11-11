using System;

using com.SonOfSofaman.Heromatic.Encounters;

namespace com.SonOfSofaman.Heromatic
{
	public class EncounterBuilder
	{
		private Random RNG;
		private GameState GameState;
		public EncounterBuilderEventHandler EncounterBuilderEvent { get; set; } 

		public EncounterBuilder(Random rng, GameState gameState)
		{
			this.RNG = rng;
			this.GameState = gameState;
			this.EncounterBuilderEvent = null;
		}

		protected virtual void OnEncounterBuilderEvent(string message)
		{
			EncounterBuilderEventHandler encounterBuilderEventHandler = this.EncounterBuilderEvent;
			if (encounterBuilderEventHandler != null) encounterBuilderEventHandler(this, new EncounterBuilderEventArgs(message));
		}

		public Encounter Construct()
		{
			// TODO:
			// Choose an encounter type based on the current location.
			// Highly populated places that are highly civilized are more likely to yield a friendly encounter.
			// Perhaps a merchant looking to trade goods, or a craftsman willing to provide skill training.
			// Places with lower population and/or less civilized denizens are more likely to yield a hostile encounter.
			// In the wilderness one is more likely to encounter wild animals and other beasties.
			Encounter encounter = new NOPEncounter(this.GameState);
			this.OnEncounterBuilderEvent(string.Format("{0} has encountered {1}", this.GameState.Character, encounter));

			return encounter;
		}
	}
}
