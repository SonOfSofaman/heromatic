using System;

namespace com.SonOfSofaman.Heromatic
{
	public class Character
	{
		public string Name { get; private set; }
		public Place Home { get; private set; }
		public Place CurrentPlace { get; set; }
		public double Age { get; private set; }

		public Character(string name, Place home, double startingAge)
		{
			this.Name = name;
			this.Home = home;
			this.CurrentPlace = home;
			this.Age = startingAge;
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
			this.Age += (1.0 / 365.0);
		}
	}
}
