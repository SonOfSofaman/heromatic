using System;

namespace com.SonOfSofaman.Heromatic
{
	public class CharacterEventArgs : EventArgs
	{
		public string Message { get; private set; }

		public CharacterEventArgs(string message)
		{
			this.Message = message;
		}
	}
}
