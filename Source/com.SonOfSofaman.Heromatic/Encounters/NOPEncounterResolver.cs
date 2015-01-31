namespace com.SonOfSofaman.Heromatic.Encounters
{
	public class NOPEncounterResolver : IEncounterResolver
	{
		public void Resolve(Encounter encounter)
		{
			// The inconsequential vermin have articially aged the character a tiny bit
			encounter.GameState.Character.ArtificiallyAge(10.0 / 365.0);
		}
	}
}
