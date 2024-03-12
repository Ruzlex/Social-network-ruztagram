using System.Collections.Concurrent;
using Domain.Entities;
using Domain.Interfaces;

namespace Infastracted.Data;

public class PostRepository: IStorePost
{
    private readonly ConcurrentDictionary<Guid[], Post[]> Connection = new();
    private readonly ConcurrentDictionary<Guid, Post> Connection1 = new();
    
    public async Task<Post[]> GetAllAsync(Guid[] guids)
    {
        if (Connection.TryGetValue(guids, out var posts))
        {
            return posts;
        }
        
        throw new Exception("Ошибка получения постов! Посты отсутствуют");
    }

    public async Task<Guid> AddPost(Post post)
    {
        return Guid.NewGuid();
    }

    public async Task<string> DeletePostAsync(Guid id)
    {
        if (Connection1.TryGetValue(id, out var post))
        {
            Connection1.Remove(id, out post);
        }
        throw new Exception("Ошибка удаления поста! Пост отсутствует");
    }
}