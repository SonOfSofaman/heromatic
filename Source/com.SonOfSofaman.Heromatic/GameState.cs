using System.Collections.Generic;

using com.SonOfSofaman.Heromatic.Encounters;

namespace com.SonOfSofaman.Heromatic
{
	public class GameState
	{
		public Character Character { get; private set; }
		public List<Place> Places { get; private set; }
		public List<Encounter> Encounters { get; private set; }

		public GameState(Character character)
		{
			this.Character = character;
			this.Places = new List<Place>();
			this.Places.Add(character.Home);
			this.Encounters = new List<Encounter>();
		}
	}
}
