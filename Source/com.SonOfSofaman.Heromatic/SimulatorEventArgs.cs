using System;

namespace com.SonOfSofaman.Heromatic
{
	public class SimulatorEventArgs : EventArgs
	{
		public ulong TurnIndex { get; private set; }
		public string Message { get; private set; }

		public SimulatorEventArgs(ulong turnIndex, string message)
		{
			this.TurnIndex = turnIndex;
			this.Message = message;
		}
	}
}
