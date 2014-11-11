namespace com.SonOfSofaman.Heromatic
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
