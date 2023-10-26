using netmvc.Dto.Post;
using netmvc.Models;

namespace netmvc.Repository
{
    public class PostRepository: CudRepository<Post,PostInputDto,PostInputUpdate,PostInputDelete>,IPostRepository
    {
        
    }
}