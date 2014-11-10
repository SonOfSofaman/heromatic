namespace com.SonOfSofaman.Heromatic
{
	static class OrdinalExtensions
	{
		public static string ToEnglishOrdinal(this int number)
		{
			string suffix;

			if (number <= 0)
			{
				suffix = string.Empty;
			}
			else if (number >= 11 && number <= 13)
			{
				suffix = "th";
			}
			else
			{
				switch (number % 10)
				{
					case 1:
					{
						suffix = "st";
						break;
					}
					case 2:
					{
						suffix = "nd";
						break;
					}
					case 3:
					{
						suffix = "rd";
						break;
					}
					default:
					{
						suffix = "th";
						break;
					}
				}
			}

			return string.Format("{0}{1}", number, suffix);
		}

		public static string ToEnglishOrdinal(this double number)
		{
			return ToEnglishOrdinal((int)number);
		}
	}
}
