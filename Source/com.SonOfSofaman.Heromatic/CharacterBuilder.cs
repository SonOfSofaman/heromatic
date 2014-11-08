using System;

namespace com.SonOfSofaman.Heromatic
{
	public class CharacterBuilder
	{
		public static Character Construct(Random RNG, bool manualCharacterName, string providedCharacterName, Place home)
		{
			string name = manualCharacterName ? providedCharacterName : NameGenerator.GenerateRandomProperNoun(RNG);
			return new Character(name, home);
		}
	}
}
