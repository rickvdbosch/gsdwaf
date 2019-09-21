using System.Threading;
using System.Threading.Tasks;

namespace DependencyInjectionExample.Example01
{
    public interface IPingService
    {
        Task<string> Ping(CancellationToken cancellationToken);
    }
}