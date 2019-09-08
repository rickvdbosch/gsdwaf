using System.Threading;
using System.Threading.Tasks;

namespace BasicDi
{
    public interface IPingService
    {
        Task<string> Ping(CancellationToken cancellationToken);
    }
}