using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.SonOfSofaman.Heromatic
{
	public class GameStateBuilder
	{
		public static GameState Construct(Random RNG, bool manualCharacterName, string characterName)
		{
			Place home = new Place(NameGenerator.GeneratePlaceName(RNG));
			home.Fondness = RNG.NextDouble();
			Character character = CharacterBuilder.Construct(RNG, manualCharacterName, characterName, home);

			GameState result = new GameState(character);
			result.Places.Add(home);
			return result;
		}
	}
}
