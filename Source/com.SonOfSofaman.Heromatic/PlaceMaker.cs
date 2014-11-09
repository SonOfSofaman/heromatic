using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.SonOfSofaman.Heromatic
{
	public class PlaceMaker
	{
		public static Place MakePlace(Random RNG)
		{
			Place result = new Place(NameGenerator.GeneratePlaceName(RNG));
			result.Fondness = 0.5;
			Dictionary<Direction, Route> routes = PlaceMaker.MakeRoutes(RNG, result);
			foreach (Direction direction in routes.Keys)
			{
				Route route = routes[direction];
				result.Routes.Add(direction, route);
			}

			return result;
		}

		private static Dictionary<Direction, Route> MakeRoutes(Random RNG, Place place)
		{
			Dictionary<Direction, Route> result;

			result = new Dictionary<Direction, Route>();
			bool done = false;
			do
			{
				for (int index = 0; index < 8; index++)
				{
					if (RNG.NextDouble() <= 0.25)
					{
						Direction direction = (Direction)index;
						if (!result.ContainsKey(direction))
						{
							Route route = new Route(direction, null);
							result.Add(direction, route);
						}
					}
				}
				done = (result.Count >= 2);
			} while (!done);

			return result;
		}
	}
}
