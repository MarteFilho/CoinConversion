using System.Threading.Tasks;
using CoinConversion.Domain.Commands;
using CoinConversion.Domain.Entities;
using CoinConversion.Domain.Repositories;
using CoinConversion.Domain.ValueObjects;
using Flunt.Notifications;

namespace CoinConversion.Domain.Handlers
{
    public class CurrencyHandler : Notifiable, IHandler<CreateCurrencyCommand>
    {
        private readonly ICurrencyRepository _repository;
        public CurrencyHandler(ICurrencyRepository repository)
        {
            _repository = repository;
        }
        public async Task<ICommandResult> Handle(CreateCurrencyCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandResult(400, false, "Favor revisar os dados para conversão!", command.Notifications);

            //VOs
            var amount = new Amount(command.Amount);
            var currencyOrigin = new Coin(command.CurrencyOrigin);
            var currencyDestination = new Coin(command.CurrencyDestination);

            bool existis = await _repository.ExistisCurrencies(currencyOrigin, currencyDestination);
            if (existis == false)
            {
                AddNotification("CurrencyOrigin, CurrencyDestination", "Moedas não existem!");
                return new CommandResult(400, false, "Favor revisar as moedas digitadas, pois uma ou mais não existem!", null);
            }
            //Entity
            var currency = new Currency(amount, currencyOrigin, currencyDestination);

            AddNotifications(amount, currencyOrigin, currencyDestination, currency);

            if (Invalid)
                return new CommandResult(400, false, "Favor revisar os dados para conversão!", Notifications);

            return await _repository.Convert(currency);
        }
    }
}