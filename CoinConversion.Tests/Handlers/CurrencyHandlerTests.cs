using CoinConversion.Domain.Commands;
using CoinConversion.Domain.Handlers;
using CoinConversion.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoinConversion.Tests.Handlers
{
    [TestClass]
    public class CurrencyHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenNotExistisCurrency()
        {
            var handle = new CurrencyHandler(new FakeCurrencyRepository());
            var command = new CreateCurrencyCommand();
            command.Amount = 10;
            command.CurrencyOrigin = "AAA";
            command.CurrencyDestination = "BBB";

            handle.Handle(command);
            Assert.AreEqual(false, handle.Valid);
        }
    }
}