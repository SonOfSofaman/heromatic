using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace com.SonOfSofaman.Heromatic.CLI
{
	public class Parameters
	{
		public bool Valid { get; private set; }
		private int _Seed;
		public int Seed { get { return this._Seed; } }
		private string _CharacterName;
		public string CharacterName { get { return this.Valid ? this._CharacterName : null; } set { this._CharacterName = value; } }
		public bool ManualCharacterName { get { return this.CharacterName != null; } }

		public Parameters(string[] args)
		{
			this.Valid = false;
			this._Seed = 0;
			this._CharacterName = null;

			List<ParameterMatcher> parameterMatchers = new List<ParameterMatcher>();
			parameterMatchers.Add(new ParameterMatcher("^(?<seed>[-+]?[0-9]+)$", true, this.SetSeed));
			parameterMatchers.Add(new ParameterMatcher("^(?<name>[^\\s]+)$", false, this.SetCharacterName));

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

			this.Valid = parameterMatchers.All(pm => pm.Required && pm.Satisfied || !pm.Required);
		}

		private void SetSeed(Match match)
		{
			this.Valid &= Int32.TryParse(match.Groups["seed"].Value, out this._Seed);
		}

		private void SetCharacterName(Match match)
		{
			this.CharacterName = match.Groups["name"].Value;
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
