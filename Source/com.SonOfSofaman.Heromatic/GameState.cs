using System.Collections.Generic;

namespace com.SonOfSofaman.Heromatic
{
	public class GameState
	{
		public Character Character { get; private set; }
		public List<Place> Places { get; private set; }

		public GameState(Character character)
		{
			this.Character = character;
			this.Places = new List<Place>();
			this.Places.Add(character.Home);
		}
	}
}
