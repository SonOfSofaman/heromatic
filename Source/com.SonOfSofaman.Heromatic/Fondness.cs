namespace com.SonOfSofaman.Heromatic
{
	public struct Fondness
	{
		private double FondnessPercentage;

		public Fondness(double fondnessPercentage)
		{
			this.FondnessPercentage = fondnessPercentage;
		}

		static public implicit operator Fondness(double fondnessPercentage)
		{
			return new Fondness(fondnessPercentage);
		}

		public static bool operator <(Fondness a, Fondness b)
		{
			return a.FondnessPercentage < b.FondnessPercentage;
		}

		public static bool operator >(Fondness a, Fondness b)
		{
			return a.FondnessPercentage > b.FondnessPercentage;
		}

		public static bool operator <=(Fondness a, Fondness b)
		{
			return a.FondnessPercentage <= b.FondnessPercentage;
		}

		public static bool operator >=(Fondness a, Fondness b)
		{
			return a.FondnessPercentage >= b.FondnessPercentage;
		}

		public override string ToString()
		{
			if (this.FondnessPercentage <= 0.0)
			{
				return "not at all";
			}
			else if (this.FondnessPercentage < 0.5)
			{
				return "not";
			}
			else if (this.FondnessPercentage < 0.7)
			{
				return "somewhat";
			}
			else if (this.FondnessPercentage < 0.9)
			{
				return "quite";
			}
			else
			{
				return "very";
			}
		}
	}
}
