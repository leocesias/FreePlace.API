using FreePlace.API.Shared.Persistence.Contexts;
using FreePlace.API.Shared.Services.Communication;

namespace FreePlace.API.Shared.Domain.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}