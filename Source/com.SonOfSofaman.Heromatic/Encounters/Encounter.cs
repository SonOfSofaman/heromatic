using System.Collections.Generic;
using System.Linq;

namespace com.SonOfSofaman.Heromatic.Encounters
{
	public class Encounter
	{
		public GameState GameState { get; private set; }
		public string Name { get; protected set; }
		public List<Character> Characters { get; protected set; }
		protected IEncounterResolver Resolver { get; set; }
		public EncounterEventHandler EncounterEvent { get; set; }

		public Encounter(GameState gameState, string name, IEncounterResolver resolver)
		{
			this.GameState = gameState;
			this.Name = name;
			this.Characters = new List<Character>();
			this.Resolver = resolver;
			this.EncounterEvent = null;
		}

		protected virtual void OnEncounterEvent(string message)
		{
			EncounterEventHandler encounterEventHandler = this.EncounterEvent;
			if (encounterEventHandler != null) encounterEventHandler(this, new EncounterEventArgs(message));
		}

		public override string ToString()
		{
			return this.Name;
		}

		public void Resolve()
		{
			this.Resolver.Resolve(this);
			this.OnEncounterEvent("encounter resolved.");
		}
	}
}
