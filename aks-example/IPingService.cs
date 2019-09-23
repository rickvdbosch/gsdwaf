using System.Threading;
using System.Threading.Tasks;

namespace AksExample
{ 
    public interface IPingService
    {
        Task<string> Ping(CancellationToken cancellationToken);
    }
}