using System.Threading.Tasks;

namespace DependencyInjectionExample.Example04
{
    public interface IPingInvokeService
    {
        Task InvokePing();
    }
}