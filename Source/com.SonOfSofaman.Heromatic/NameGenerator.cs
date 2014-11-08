using System;
using System.Text;

namespace com.SonOfSofaman.Heromatic
{
	class NameGenerator
	{
		private static string Vowels = "aaaaaaeeeeeeeeeeeeeeiioouy";
		private static string Consonants = "bbbbbccccddddfffgghhjklllllllllmmmmmmmmmnnnnnnnnnpppqrrrrsssssssssssssssstttvwxz";
		private static string[] Patterns =
		{
			"cvc",
			"cvcv",

			"cvrc",
			"cvcr",

			"cvcv cvc",

			"c'cvc",
		};

		public static string GenerateCharacterName(Random RNG)
		{
			StringBuilder builder = new StringBuilder();
			bool capitalizeThisCharacter = true;
			bool capitalizeNextCharacter = false;
			char newCharacter = '\0';
			char lastCharacter = '\0';
			string pattern = Patterns[RNG.Next(Patterns.Length)];
			foreach (char token in pattern)
			{
				switch (token)
				{
					case 'v':
					{
						newCharacter = Vowels[RNG.Next(Vowels.Length)];
						break;
					}
					case 'c':
					{
						newCharacter = Consonants[RNG.Next(Consonants.Length)];
						break;
					}
					case 'r':
					{
						newCharacter = lastCharacter;
						break;
					}
					case ' ':
					{
						switch (RNG.Next(3))
						{
							case 0:
							{
								newCharacter = '-';
								capitalizeNextCharacter = false;
								break;
							}
							case 1:
							{
								newCharacter = '\'';
								capitalizeNextCharacter = true;
								break;
							}
							default:
							{
								newCharacter = ' ';
								capitalizeNextCharacter = true;
								break;
							}
						}
						break;
					}
					default:
					{
						newCharacter = token;
						capitalizeNextCharacter = true;
						break;
					}
				}
				builder.Append(capitalizeThisCharacter ? newCharacter.ToString().ToUpper() : newCharacter.ToString());
				lastCharacter = newCharacter;
				capitalizeThisCharacter = capitalizeNextCharacter;
				capitalizeNextCharacter = false;
			}

			return builder.ToString();
		}
	}
}
