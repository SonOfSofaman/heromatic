using System;

namespace com.SonOfSofaman.Heromatic.Encounters
{
	public class NOPEncounterBuilder : EncounterBuilder
	{
		private Encounter Encounter;

		public NOPEncounterBuilder(Random rng, GameState gameState)
			: base(rng, gameState)
		{
		}
	
		public override void BuildEncounter()
		{
			// TODO:
			// Choose an encounter type based on the current location.
			// Highly populated places that are highly civilized are more likely to yield a friendly encounter.
			// Perhaps a merchant looking to trade goods, or a craftsman willing to provide skill training.
			// Places with lower population and/or less civilized denizens are more likely to yield a hostile encounter.
			// In the wilderness one is more likely to encounter wild animals and other beasties.
			this.Encounter = new Encounter(this.GameState, "some inconsequential vermin", new NOPEncounterResolver());
			this.OnEncounterBuilderEvent(string.Format("{0} has encountered {1}.", this.GameState.Character, this.Encounter));
		}

		public override Encounter GetEncounter()
		{
			return this.Encounter;
		}
	}
}
