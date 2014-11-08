using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace com.SonOfSofaman.Heromatic.CLI.UnitTests
{
	[TestClass]
	public class ParametersTests
	{
		[TestMethod]
		public void ctor_EmptyArray()
		{
			Parameters parameters = new Parameters(new string[] { });
			Assert.AreEqual(false, parameters.Valid);
			Assert.AreEqual(0, parameters.Seed);
			Assert.AreEqual(false, parameters.ManualCharacterName);
			Assert.AreEqual(null, parameters.CharacterName);
		}

		[TestMethod]
		public void ctor_NonIntegerAlpha_NoName()
		{
			Parameters parameters = new Parameters(new string[] { "abc" });
			Assert.AreEqual(false, parameters.Valid);
			Assert.AreEqual(0, parameters.Seed);
			Assert.AreEqual(false, parameters.ManualCharacterName);
			Assert.AreEqual(null, parameters.CharacterName);
		}

		[TestMethod]
		public void ctor_NonIntegerDigits_NoName()
		{
			Parameters parameters = new Parameters(new string[] { "0+1-2" });
			Assert.AreEqual(false, parameters.Valid);
			Assert.AreEqual(0, parameters.Seed);
			Assert.AreEqual(false, parameters.ManualCharacterName);
			Assert.AreEqual(null, parameters.CharacterName);
		}

		[TestMethod]
		public void ctor_Zero_NoName()
		{
			Parameters parameters = new Parameters(new string[] { "0" });
			Assert.AreEqual(true, parameters.Valid);
			Assert.AreEqual(0, parameters.Seed);
			Assert.AreEqual(false, parameters.ManualCharacterName);
			Assert.AreEqual(null, parameters.CharacterName);
		}

		[TestMethod]
		public void ctor_Integer_NoName()
		{
			Parameters parameters = new Parameters(new string[] { "10" });
			Assert.AreEqual(true, parameters.Valid);
			Assert.AreEqual(10, parameters.Seed);
			Assert.AreEqual(false, parameters.ManualCharacterName);
			Assert.AreEqual(null, parameters.CharacterName);
		}

		[TestMethod]
		public void ctor_PosInteger_NoName()
		{
			Parameters parameters = new Parameters(new string[] { "+10" });
			Assert.AreEqual(true, parameters.Valid);
			Assert.AreEqual(10, parameters.Seed);
			Assert.AreEqual(false, parameters.ManualCharacterName);
			Assert.AreEqual(null, parameters.CharacterName);
		}

		[TestMethod]
		public void ctor_NegInteger_NoName()
		{
			Parameters parameters = new Parameters(new string[] { "-10" });
			Assert.AreEqual(true, parameters.Valid);
			Assert.AreEqual(-10, parameters.Seed);
			Assert.AreEqual(false, parameters.ManualCharacterName);
			Assert.AreEqual(null, parameters.CharacterName);
		}

		[TestMethod]
		public void ctor_NonIntegerAlpha_WithName()
		{
			Parameters parameters = new Parameters(new string[] { "abc", "Bob" });
			Assert.AreEqual(false, parameters.Valid);
			Assert.AreEqual(0, parameters.Seed);
			Assert.AreEqual(false, parameters.ManualCharacterName);
			Assert.AreEqual(null, parameters.CharacterName);
		}

		[TestMethod]
		public void ctor_NonIntegerDigits_WithName()
		{
			Parameters parameters = new Parameters(new string[] { "0+1-2", "Bob" });
			Assert.AreEqual(false, parameters.Valid);
			Assert.AreEqual(0, parameters.Seed);
			Assert.AreEqual(false, parameters.ManualCharacterName);
			Assert.AreEqual(null, parameters.CharacterName);
		}

		[TestMethod]
		public void ctor_Zero_WithName()
		{
			Parameters parameters = new Parameters(new string[] { "0", "Bob" });
			Assert.AreEqual(true, parameters.Valid);
			Assert.AreEqual(0, parameters.Seed);
			Assert.AreEqual(true, parameters.ManualCharacterName);
			Assert.AreEqual("Bob", parameters.CharacterName);
		}

		[TestMethod]
		public void ctor_Integer_WithName()
		{
			Parameters parameters = new Parameters(new string[] { "10", "Bob" });
			Assert.AreEqual(true, parameters.Valid);
			Assert.AreEqual(10, parameters.Seed);
			Assert.AreEqual(true, parameters.ManualCharacterName);
			Assert.AreEqual("Bob", parameters.CharacterName);
		}

		[TestMethod]
		public void ctor_PosInteger_WithName()
		{
			Parameters parameters = new Parameters(new string[] { "+10", "Bob" });
			Assert.AreEqual(true, parameters.Valid);
			Assert.AreEqual(10, parameters.Seed);
			Assert.AreEqual(true, parameters.ManualCharacterName);
			Assert.AreEqual("Bob", parameters.CharacterName);
		}

		[TestMethod]
		public void ctor_NegInteger_WithName()
		{
			Parameters parameters = new Parameters(new string[] { "-10", "Bob" });
			Assert.AreEqual(true, parameters.Valid);
			Assert.AreEqual(-10, parameters.Seed);
			Assert.AreEqual(true, parameters.ManualCharacterName);
			Assert.AreEqual("Bob", parameters.CharacterName);
		}

	}
}
