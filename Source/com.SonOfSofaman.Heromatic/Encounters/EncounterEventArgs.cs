namespace com.SonOfSofaman.Heromatic.Encounters
{
	public class EncounterEventArgs
	{
		public string Message { get; private set; }

		public EncounterEventArgs(string message)
		{
			this.Message = message;
		}
	}
}
