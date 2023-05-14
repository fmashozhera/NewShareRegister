using ShareRegister.Application.Interfaces.Common;

namespace ShareRegister.Data.Common;
public class UnitOfWOrk : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWOrk(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
