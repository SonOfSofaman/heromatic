using System;

namespace com.SonOfSofaman.Heromatic.Encounters
{
	public abstract class EncounterBuilder
	{
		protected Random RNG;
		protected GameState GameState;
		public EncounterBuilderEventHandler EncounterBuilderEvent { get; set; }

		protected EncounterBuilder(Random rng, GameState gameState)
		{
			this.RNG = rng;
			this.GameState = gameState;
		}

		protected virtual void OnEncounterBuilderEvent(string message)
		{
			EncounterBuilderEventHandler encounterBuilderEventHandler = this.EncounterBuilderEvent;
			if (encounterBuilderEventHandler != null) encounterBuilderEventHandler(this, new EncounterBuilderEventArgs(message));
		}

		public abstract void BuildEncounter();
		public abstract Encounter GetEncounter();
	}
}
