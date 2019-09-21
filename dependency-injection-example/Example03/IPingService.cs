using System.Threading;
using System.Threading.Tasks;

namespace DependencyInjectionExample.Example03
{ 
    public interface IPingService
    {
        Task<string> Ping(CancellationToken cancellationToken);
    }
}