using FreePlace.API.Shared.Domain.Models;
using FreePlace.API.Shared.Domain.Services.Communication;

namespace FreePlace.API.Shared.Domain.Services;

public interface IUserService
{
    Task<IEnumerable<User>> ListAsync();
    Task<UserResponse> SaveAsync(User user);
    Task<UserResponse> UpdateAsync(int id, User user);
    Task<UserResponse> DeleteAsync(int id);
}