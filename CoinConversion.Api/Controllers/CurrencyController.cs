using System.Threading.Tasks;
using CoinConversion.Domain.Commands;
using CoinConversion.Domain.Handlers;
using CoinConversion.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoinConversion.Api.Controllers
{
    [Route("v1/currency")]
    public class CurrencyController : ControllerBase
    {
        private readonly CurrencyHandler _handler;
        private readonly ICurrencyRepository _repository;
        private CommandResult _result = new CommandResult();
        public CurrencyController(CurrencyHandler handler, ICurrencyRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCurrencyCommand command)
        {
            _result = (CommandResult)await _handler.Handle(command);
            return Ok(_result);
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetCurrencies());
        }
    }
}