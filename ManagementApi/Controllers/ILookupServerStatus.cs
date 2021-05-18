using System.Threading.Tasks;

namespace ManagementApi.Controllers
{
    public interface ILookupServerStatus
    {
        Task<StatusResponse> GetMyStatus();
    }
}