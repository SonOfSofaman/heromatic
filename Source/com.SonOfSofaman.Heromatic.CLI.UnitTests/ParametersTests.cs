using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace com.SonOfSofaman.Heromatic.CLI.UnitTests
{
	[TestClass]
	public class ParametersTests
	{
		[TestMethod]
		public void ctor_EmptyArray_ReturnsInvalid()
		{
			Parameters parameters = new Parameters(new string[] { });
			Assert.AreEqual(false, parameters.Valid);
		}

		[TestMethod]
		public void ctor_NonIntegerAlpha_ReturnsInvalid()
		{
			Parameters parameters = new Parameters(new string[] { "abc" });
			Assert.AreEqual(false, parameters.Valid);
		}

		[TestMethod]
		public void ctor_NonIntegerDigits_ReturnsInvalid()
		{
			Parameters parameters = new Parameters(new string[] { "0+1-2" });
			Assert.AreEqual(false, parameters.Valid);
		}

		[TestMethod]
		public void ctor_Zero_ReturnsValid()
		{
			Parameters parameters = new Parameters(new string[] { "0" });
			Assert.AreEqual(true, parameters.Valid);
		}

		[TestMethod]
		public void ctor_Integer_ReturnsValid()
		{
			Parameters parameters = new Parameters(new string[] { "10" });
			Assert.AreEqual(true, parameters.Valid);
		}

		[TestMethod]
		public void ctor_PosInteger_ReturnsValid()
		{
			Parameters parameters = new Parameters(new string[] { "+10" });
			Assert.AreEqual(true, parameters.Valid);
		}

		[TestMethod]
		public void ctor_NegInteger_ReturnsValid()
		{
			Parameters parameters = new Parameters(new string[] { "-10" });
			Assert.AreEqual(true, parameters.Valid);
		}
	}
}
