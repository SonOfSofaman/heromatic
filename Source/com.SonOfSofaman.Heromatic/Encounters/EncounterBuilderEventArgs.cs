namespace com.SonOfSofaman.Heromatic.Encounters
{
	public class EncounterBuilderEventArgs
	{
		public string Message { get; private set; }

		public EncounterBuilderEventArgs(string message)
		{
			this.Message = message;
		}
	}
}
