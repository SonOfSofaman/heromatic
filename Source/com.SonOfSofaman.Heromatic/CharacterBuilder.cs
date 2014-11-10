using System;

namespace com.SonOfSofaman.Heromatic
{
	public class CharacterBuilder
	{
		public static Character Construct(Random RNG, bool manualCharacterName, string providedCharacterName, Place home)
		{
			string name = manualCharacterName ? providedCharacterName : NameGenerator.GenerateRandomProperNoun(RNG);
			double startingAge = 16.0 + RNG.NextDouble() * 5 + RNG.NextDouble() * 5;
			return new Character(name, home, startingAge);
		}
	}
}
