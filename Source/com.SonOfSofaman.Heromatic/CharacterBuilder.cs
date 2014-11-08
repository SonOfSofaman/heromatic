namespace com.SonOfSofaman.Heromatic
{
	public class CharacterBuilder
	{
		public static Character Construct(bool manualCharacterName, string characterName)
		{
			Character result = new Character(manualCharacterName ? characterName : "{generated name goes here}");

			return result;
		}
	}
}
