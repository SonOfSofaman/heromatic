namespace com.SonOfSofaman.Heromatic.Encounters
{
	public class NOPEncounter : Encounter
	{
		public NOPEncounter(GameState gameState) : base(gameState)
		{
			this.Name = "some inconsequential vermin";
			this.Resolver = new NOPResolver();
		}
	}
}
