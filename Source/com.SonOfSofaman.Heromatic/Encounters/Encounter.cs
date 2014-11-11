using System.Collections.Generic;
using System.Linq;

namespace com.SonOfSofaman.Heromatic.Encounters
{
	public abstract class Encounter
	{
		public GameState GameState { get; private set; }
		public string Name { get; protected set; }
		public List<Character> Characters { get; protected set; }
		protected IEncounterResolver Resolver { get; set; }

		public Encounter(GameState gameState)
		{
			this.GameState = GameState;
			this.Name = string.Empty;
			this.Characters = new List<Character>();
			this.Resolver = null;
		}

		public override string ToString()
		{
			return this.Name;
		}

		public void Resolve()
		{
			this.Resolver.Resolve(this);
		}
	}
}
