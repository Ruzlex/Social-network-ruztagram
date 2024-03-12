using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.Interfaces;

namespace Api.Controllers;

public record PostRequest
{
    public required Guid UserId { get; init; }
    
    public required string Title { get; init; }
    
    public required DateTime PublicDate { get; init; }
    
    public required string Content { get; init; }
    
    public int LikeCount { get; init; }
}

public record PostListResponse
{
    public required PostResponse[] PostList { get; init; }
}

public record PostResponse
{

    [JsonProperty("id")]
    public required Guid Id { get;  init; }
    

    [JsonProperty("userId")]
    public required Guid UserId { get; init; }
    
    [JsonProperty("userName")]
    public required UserNameResponse UserName { get; init; }

    [JsonProperty("title")]
    public required string Title { get; init; }
    
    [JsonProperty("publicDate")]
    public required DateTime PublicDate { get; init; }

    [JsonProperty("content")]
    public required string Content { get; init; }
    
    [JsonProperty("likeCount")]
    public int LikeCount { get; init; }
}

public record UserNameResponse
{
    public required string Name { get; init; }
}

[Route("ruztagram/post")]
public class PostController: ControllerBase
{
    private readonly ICreatePost _createPost;

    public PostController(ICreatePost createPost)
    {
        _createPost = createPost;
    }
    
    [HttpGet]
    [ProducesResponseType<PostListResponse>(200)]
    public async Task<IActionResult> GetPostListAsync(Guid[] guids)
    {
        var res = await _createPost.GetPostListAsync(guids);
        
        var response = new PostListResponse
        {
            PostList = res.Select(value => new PostResponse
            {
                Id = value.Id,
                UserId = value.UserId,
                UserName = new UserNameResponse
                {
                    Name = value.UserName.Name
                },
                Title = value.Title,
                PublicDate = value.PublicDate,
                Content = value.Content
            }).ToArray()
        };
        
        return Ok(response);
    }
    
    [HttpPost]
    [ProducesResponseType(200)]
    public async Task<ActionResult> CreatePostAsync([FromBody] PostRequest request)
    {
        await _createPost.CreatePostAsync(new Post
        {
            UserId = request.UserId,
            Title = request.Title,
            Content = request.Content,
            PublicDate = DateTime.Now
        });
        return Ok();
    }

    [HttpDelete]
    [ProducesResponseType(200)]
    public async Task<IActionResult> DeletePostAsync()
    {
        await _createPost.DelPostAsync(new Guid());
        return Ok();
    }
}