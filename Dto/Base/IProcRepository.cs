using System.Threading.Tasks;

namespace netmvc.Dto.Base
{
    public interface IProcRepository
    {
        Task<int> ExcuteProc<TInput>(TInput input, string ProcName);
    }
}