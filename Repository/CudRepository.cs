using System;
using System.Threading.Tasks;
using netmvc.Dto.Base;

namespace netmvc.Repository
{
    public class CudRepository<TEntity,TInputCreate,TInputUpdate,TInputDelte> where TEntity:new()

    {
        private ProcRepository _procRepository = new ProcRepository();
        private TEntity entity { get; } = new TEntity();
        
        public async Task<int> Create(TInputCreate input)
        {
            string className = entity.GetType().Name;
            return await _procRepository.ExcuteProc<TInputCreate>(input, "dbo." + className + "_Insert");
        }
        public async Task<int> Update(TInputUpdate input)
        {
            string className = entity.GetType().Name;
            return await _procRepository.ExcuteProc<TInputUpdate>(input, "dbo." + className + "_Update");
        }
        public async Task<int> Delete(TInputDelte input)
        {   
            string className = entity.GetType().Name;
            return await _procRepository.ExcuteProc<TInputDelte>(input, "dbo." + className + "_Delete");
        }

        public void Dispose()
        {
        }
    }
}