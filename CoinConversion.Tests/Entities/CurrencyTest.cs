using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoinConversion.Domain.ValueObjects;
using CoinConversion.Domain.Entities;

namespace CoinConversion.Tests
{
    [TestClass]
    public class CurrencyTest
    {
        private readonly Coin _coinusd;
        private readonly Coin _coinbrl;
        private readonly Amount _amountvalid;
        private readonly Amount _amountinvalid;

        public CurrencyTest()
        {
            _coinbrl = new Coin("BRL");
            _coinusd = new Coin("USD");
            _amountvalid = new Amount(5);
            _amountinvalid = new Amount(0);
        }

        [TestMethod]
        public void ShouldReturnOkWhenHadCurrencyValid()
        {
            var currency = new Currency(_amountvalid, _coinbrl, _coinusd);
            Assert.IsTrue(currency.Valid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadAmountInvalid()
        {
            Currency currency = new Currency(_amountinvalid, _coinbrl, _coinusd);
            Assert.IsTrue(currency.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadSomesCurrencys()
        {
            Currency currency = new Currency(_amountvalid, _coinbrl, _coinbrl);
            Assert.IsTrue(currency.Invalid);
        }
    }
}
