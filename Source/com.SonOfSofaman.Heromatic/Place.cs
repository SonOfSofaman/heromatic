using System.Collections.Generic;

namespace com.SonOfSofaman.Heromatic
{
	public class Place
	{
		public string Name { get; private set; }
		public Fondness Fondness { get; set; }
		public Dictionary<Direction, Route> Routes { get; private set; }
		public ulong Visits { get; private set; }

		public Place(string name)
		{
			this.Name = name;
			this.Fondness = 0.0;
			this.Routes = new Dictionary<Direction, Route>();
			this.Visits = 0UL;
		}

		public void Visit()
		{
			this.Visits++;
		}
	}
}
