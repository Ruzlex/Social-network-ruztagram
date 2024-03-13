using CoreLib.HttpServiceV2.Services.Interfaces;
using ExampleCore.HttpLogic.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProfileConnectionLib.ConnectionServices.DtoModels.CheckUserExists;
using ProfileConnectionLib.ConnectionServices.DtoModels.UserNameLists;
using ProfileConnectionLib.ConnectionServices.Interfaces;

namespace ProfileConnectionLib.ConnectionServices;

public class ProfileConnectionService : IProfileConnectionServcie
{
    private readonly IHttpRequestService _httpClientFactory;

    public ProfileConnectionService(IConfiguration configuration, IServiceProvider serviceProvider)
    {
        if (configuration.GetSection("dsgf").Value == "http")
        {
            _httpClientFactory = serviceProvider.GetRequiredService<IHttpRequestService>();
        }
    }
    public async Task<UserNameListProfileApiResponse[]> GetUserNameListAsync(UserNameListProfileApiRequest request)
    {
        var data = new HttpRequestData()
        {
            Uri = new Uri("http://localhost:5136/public/user/info"),
            Method = HttpMethod.Get,
            ContentType = ContentType.ApplicationJson,
            Body = request
        };

        var user = await _httpClientFactory.SendRequestAsync<UserNameListProfileApiResponse[]>(data);

        return user.Body;
    }
    
    public async Task<CheckUserExistProfileApiResponse> CheckUserExistAsync(CheckUserExistProfileApiRequest checkUserExistProfileApiRequest)
    {
        
        var data = new HttpRequestData()
        {
            Uri = new Uri("http://localhost:5136/public/user/exist"),
            Method = HttpMethod.Post,
            ContentType = ContentType.ApplicationJson,
            Body = checkUserExistProfileApiRequest
        };
        var user = await _httpClientFactory.SendRequestAsync<CheckUserExistProfileApiResponse>(data);
        
        return user.Body.UserId != Guid.Empty ? user.Body : throw new Exception("Пользователь не найден");
    }
}
