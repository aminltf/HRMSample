namespace HRM.Application.Common.Interfaces.Services.Identity;

public interface ICurrentUserService
{
    Guid? UserId { get; }
    string UserName { get; }
    string Role { get; }
}
