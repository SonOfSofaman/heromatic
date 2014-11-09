using System;

namespace com.SonOfSofaman.Heromatic
{
	public class GameStateBuilder
	{
		public static GameState Construct(Random RNG, bool manualCharacterName, string characterName)
		{
			Place home = PlaceMaker.MakePlace(RNG);
			home.Fondness = RNG.NextDouble();
			Character character = CharacterBuilder.Construct(RNG, manualCharacterName, characterName, home);

			GameState result = new GameState(character);
			result.Places.Add(home);
			return result;
		}
	}
}
