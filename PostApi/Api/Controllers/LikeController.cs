using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.Interfaces;

namespace Api.Controllers;

public record LikeCountResponse
{
    public required int LikeCount { get; init; }
}

public record LikeCountRequest
{
    [JsonProperty("likes")]
    public required int LikeCount { get; init; }
}

[Route("ruztagram/post/likes")]
public class LikeController: ControllerBase
{
    private readonly ILikeService _likeService;

    public LikeController(ILikeService likeService)
    {
        _likeService = likeService;
    }
    
    [HttpGet("like-count")]
    [ProducesResponseType<LikeCountResponse>(200)]
    public async Task<IActionResult> GetLikesCountServiceAsync(LikeCounter likeCounter, Post post)
    {
        var res = await _likeService.GetLikesCountServiceAsync(likeCounter, post);
        
        var response = new LikeCountResponse
        {
            LikeCount = post.LikeCount
        };
        
        return Ok(response);
    }
    
    [HttpPatch("like-plus")]
    [ProducesResponseType(200)]
    public async Task<ActionResult> AddPlusOneLikeServiceAsync([FromBody] PostRequest request)
    {
        await _likeService.AddPlusOneLikeServiceAsync(new LikeCounter());
        return Ok();
    }
    
    [HttpDelete("like-minus")]
    [ProducesResponseType(200)]
    public async Task<ActionResult> DelMinusOneLikeServiceAsync([FromBody] PostRequest request)
    {
        await _likeService.DelMinusOneLikeServiceAsync(new LikeCounter());
        return Ok();
    }
    
}