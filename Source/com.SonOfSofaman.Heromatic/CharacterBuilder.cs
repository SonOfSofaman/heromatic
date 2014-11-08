using System;

namespace com.SonOfSofaman.Heromatic
{
	public class CharacterBuilder
	{
		public static Character Construct(Random RNG, bool manualCharacterName, string characterName)
		{
			Character result = new Character(manualCharacterName ? characterName : NameGenerator.GenerateCharacterName(RNG));

			return result;
		}
	}
}
