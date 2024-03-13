namespace ProfileConnectionLib.ConnectionServices.DtoModels.UserNameLists;

public record UserNameListProfileApiResponse
{
    public required Guid UserId { get; init; }
    
    public required string Name { get; init; }
}
