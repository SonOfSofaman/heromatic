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
			"cv",
			"cvc",
			"cvcv",
			"cvvc",
			"cvrc",
			"cvrcv",
			"cvrcvr",
			"cvrcvc",
			"cvrcvrc",
			"cvcrv",
			"cvcr",

			"vc",
			"vcv",
			"vcvc",
			"vcvcv",

			"cv vc",
			"cvc vcv",
			"cv vcvcv",
			"cvvc cv",
			"cvvc vc",
			"cvcv cvc",
			"cvvc cvvc",
			"cvrc cvrc",

			"c'cv",
			"c'cvv",
			"c'cvc",
		};

		/*
			{geog0} of {random}
		*/
		private static string[] geog0 =
		{
			"Hills",
			"Valley",
			"Plains",
			"Forest",
			"Steppes",
		};
		/*
			{random} {geog1}
		*/
		private static string[] geog1 =
		{
			"Hills",
			"Valley",
			"Plain",
			"Forest",
			"Tundra",
			"Steppes",
			"Brook",
			"Lake",
		};
		/*
			{geog2} {random}
		*/
		private static string[] geog2 =
		{
			"Mount",
			"Lake",
		};

		private static string[] formats =
		{
			"{random}",
			"{random}",
			"{random}",

			"{geog0} of {random}",
			"{random} {geog1}",
			"{geog2} {random}",
		};

		public static string GenerateRandomProperNoun(Random RNG)
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

		public static string GeneratePlaceName(Random RNG)
		{
			string result;

			result = formats[RNG.Next(formats.Length)];
			result = result.Replace("{geog0}", geog0[RNG.Next(geog0.Length)]);
			result = result.Replace("{geog1}", geog1[RNG.Next(geog1.Length)]);
			result = result.Replace("{geog2}", geog2[RNG.Next(geog2.Length)]);
			result = result.Replace("{random}", GenerateRandomProperNoun(RNG));

			return result;
		}
	}
}
