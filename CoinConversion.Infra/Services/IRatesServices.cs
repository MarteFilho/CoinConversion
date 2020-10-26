using System.Threading.Tasks;
using CoinConversion.Domain.Entities;
using Refit;

namespace CoinConversion.Infra.Services
{
    public interface IRatesServices
    {
        [Get("/latest?base={coinorigin}")]
        Task<RatesResponse> GetRatesWithBaseAsync(string coinorigin);
        [Get("/latest")]
        Task<RatesResponse> GetRatesAsync();
    }
}