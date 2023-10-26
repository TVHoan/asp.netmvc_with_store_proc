using System;
using System.Threading.Tasks;

namespace netmvc.Dto.Base
{
    public interface ICudRepository<TEntity,TInputCreate,TInputUpdate,TInputDelte>: IDisposable where  TEntity: new()
    {
        Task<int> Create(TInputCreate input);

        Task<int> Update(TInputUpdate input);

        Task<int> Delete(TInputDelte input);

    }
}