namespace com.SonOfSofaman.Heromatic
{
	public class Route
	{
		private static ulong NextID = 0UL;
		public ulong ID { get; private set; }
		public Direction Direction { get; private set; }
		public Place Destination { get; set; }

		public Route(Direction direction, Place destination)
		{
			this.ID = Route.NextID++;
			this.Direction = direction;
			this.Destination = destination;
		}
	}
}
