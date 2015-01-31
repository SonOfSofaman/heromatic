using System;

namespace com.SonOfSofaman.Heromatic
{
	public class Character
	{
		public string Name { get; private set; }
		public Place Home { get; private set; }
		public Place CurrentPlace { get; set; }
		public double Age { get; private set; }
		public CharacterEventHandler CharacterEvent { get; set; }

		public Character(string name, Place home, double startingAge)
		{
			this.Name = name;
			this.Home = home;
			this.CurrentPlace = home;
			this.Age = startingAge;
		}

		protected virtual void OnCharacterEvent(string message)
		{
			CharacterEventHandler characterEventHandler = this.CharacterEvent;
			if (characterEventHandler != null) characterEventHandler(this, new CharacterEventArgs(message));
		}

		public override string ToString()
		{
			return string.Format("{0} [{1:F2}]", this.Name, this.Age);
		}

		public void Visit(Place place)
		{
			this.CurrentPlace = place;
			this.CurrentPlace.Visit();
		}

		public void NextTurn()
		{
			this.AlterAge(1.0 / 365.0);
		}

		public void ArtificiallyAge(double artificialAgeDelta)
		{
			this.AlterAge(artificialAgeDelta);
			this.OnCharacterEvent(string.Format("{0} has been aged.", this.Name));
		}

		private void AlterAge(double ageDelta)
		{
			double before = Math.Floor(this.Age);

			this.Age += ageDelta;

			double after = Math.Floor(this.Age);
			if (after > before)
			{
				this.OnCharacterEvent(string.Format("{0} celebrates his {1} birthday!", this.Name, after.ToEnglishOrdinal()));
			}
		}
	}
}
