using netmvc.Dto.Base;
namespace netmvc.Dto.Post
{
    public interface IPostRepository: ICudRepository<Models.Post,PostInputDto,PostInputUpdate,PostInputDelete>
    {
        
    }
}