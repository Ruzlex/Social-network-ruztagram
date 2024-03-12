using Domain.Entities;

namespace Domain.Interfaces;

public interface IStorePost
{
    Task<Post[]> GetAllAsync(Guid[] guids);
    
    Task<Guid> AddPost(Post post);
    
    Task<string> DeletePostAsync(Guid id);
}