using System.Threading.Tasks;
using CoinConversion.Domain.Commands;

namespace CoinConversion.Domain.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}