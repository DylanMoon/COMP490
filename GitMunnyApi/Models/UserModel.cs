namespace GitMunnyApi.Models;

public sealed class UserModel
{
    public Guid Id { get; init; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}