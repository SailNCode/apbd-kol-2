using Kolos2.Data;
using Microsoft.EntityFrameworkCore;

namespace Kolos2.Repositories;

public class TransactionHandler
{
    private readonly DatabaseContext _context;

    public TransactionHandler(DatabaseContext context)
    {
        this._context = context;
    }

    public async Task BeginTransactionAsync()
    {
        await _context.Database.BeginTransactionAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        await _context.Database.RollbackTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        await _context.Database.CommitTransactionAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}