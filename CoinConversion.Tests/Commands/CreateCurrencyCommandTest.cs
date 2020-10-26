using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoinConversion.Domain.Commands;

namespace CoinConversion.Tests
{
    [TestClass]
    public class CreateCurrencyCommandTest
    {
        [TestMethod]
        public void ShouldReturnErrorWhenHadAmountAndCurrenciesIsInvalid()
        {
            var command = new CreateCurrencyCommand();
            command.Validate();
            Assert.AreEqual(false, command.Valid);
        }
    }
}
