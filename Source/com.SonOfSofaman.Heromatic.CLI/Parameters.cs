using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace com.SonOfSofaman.Heromatic.CLI
{
	public class Parameters
	{
		public bool Valid { get; private set; }
		public int Seed { get; private set; }

		public Parameters(string[] args)
		{
			this.Valid = false;
			this.Seed = 0;

			List<ParameterMatcher> parameterMatchers = new List<ParameterMatcher>();
			parameterMatchers.Add(new ParameterMatcher("^(?<seed>[-+]?[0-9]+)$", true, this.SetSeed));

			foreach (string arg in args)
			{
				foreach (ParameterMatcher parameterMatcher in parameterMatchers.Where(pm => pm.Satisfied == false))
				{
					if (parameterMatcher.Compare(arg))
					{
						parameterMatcher.Satisfied = true;
						break;
					}
				}
			}

			this.Valid = parameterMatchers.All(pm => pm.Required && pm.Satisfied);
		}

		private void SetSeed(Match match)
		{
			int seed;
			this.Valid &= Int32.TryParse(match.Groups["seed"].Value, out seed);
			this.Seed = seed;
		}

		class ParameterMatcher
		{
			private Regex Regex;
			public bool Required { get; private set; }
			private SetterDelegate Setter;
			public bool Satisfied { get; set; }

			public ParameterMatcher(string pattern, bool required, SetterDelegate setter)
			{
				this.Regex = new Regex(pattern, RegexOptions.IgnoreCase);
				this.Required = required;
				this.Setter = setter;
				this.Satisfied = false;
			}

			public bool Compare(string arg)
			{
				Match match = this.Regex.Match(arg);
				if (match.Success && this.Setter != null) this.Setter(match);
				return match.Success;
			}
		}

		delegate void SetterDelegate(Match match);
	}
}
