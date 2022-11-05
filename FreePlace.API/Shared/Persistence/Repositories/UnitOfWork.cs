using FreePlace.API.Shared.Persistence.Contexts;

namespace FreePlace.API.Shared.Persistence.Repositories;

public class UnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}