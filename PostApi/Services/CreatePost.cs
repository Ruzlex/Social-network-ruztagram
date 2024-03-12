using Domain.Entities;
using Domain.Interfaces;
using Services.Interfaces;

namespace Services;

public class CreatePost: ICreatePost
{
    private readonly IStorePost _storePost;
    
    public CreatePost(IStorePost storePost)
    {
        _storePost = storePost;
    }
    
    public async Task<Post[]> GetPostListAsync(Guid[] guids)
    {
        var postList = await _storePost.GetAllAsync(guids);
        return postList;
    }

    public async Task<Guid> CreatePostAsync(Post post)
    {
        var create = await _storePost.AddPost(post);
        return create;
    }

    public async Task<string> DelPostAsync(Guid id)
    {
        var postDeleting = await _storePost.DeletePostAsync(id);
        return postDeleting;
    }
}