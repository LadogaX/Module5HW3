using System.Linq;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CatalogTypeRepository : ICatalogTypeRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogTypeRepository> _logger;

    public CatalogTypeRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogTypeRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<int?> Add(string type)
    {
        var item = await _dbContext.AddAsync(new CatalogType { Type = type });

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<int?> Update(int id, string type)
    {
        var item = await _dbContext.CatalogTypes.FirstOrDefaultAsync(x => x.Id == id);

        if (item != null)
        {
            item.Type = type;
            await _dbContext.SaveChangesAsync();

            return item.Id;
        }

        return default(int?);
    }

    public async Task Remove(int id)
    {
        var item = await _dbContext.CatalogTypes.FirstOrDefaultAsync(x => x.Id == id);

        if (item != null)
        {
            _dbContext.CatalogTypes.Remove(item);
        }

        await _dbContext.SaveChangesAsync();
    }

    public async Task<PaginatedItems<CatalogType>> GetTypesAsync(int pageIndex, int pageSize)
    {
        var totalItems = await _dbContext.CatalogTypes
            .LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogTypes
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .OrderBy(c => c.Type)
            .ToListAsync();

        return new PaginatedItems<CatalogType>() { TotalCount = totalItems, Data = itemsOnPage };
    }
}