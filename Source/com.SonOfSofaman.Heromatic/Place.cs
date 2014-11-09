namespace com.SonOfSofaman.Heromatic
{
	public class Place
	{
		public string Name { get; private set; }
		public Fondness Fondness { get; set; }

		public Place(string name)
		{
			this.Name = name;
			this.Fondness = 0.0;
		}
	}
}
