namespace com.SonOfSofaman.Heromatic
{
	public class Character
	{
		public string Name { get; private set; }
		public Place Home { get; private set; }

		public Character(string name, Place home)
		{
			this.Name = name;
			this.Home = home;
		}
	}
}
