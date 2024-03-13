using Domain.Entities;

namespace Services.Interfaces;

public interface ICreatePost
{
    Task<Post[]> GetPostListAsync(Guid[] guids);
    
    Task<Guid> CreatePostAsync(Post post);
    
    Task<string> DelPostAsync(Guid id);
}