using System.Linq;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CatalogBrandRepository : ICatalogBrandRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogBrandRepository> _logger;

    public CatalogBrandRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogBrandRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<int?> Add(string brand)
    {
        var item = await _dbContext.AddAsync(new CatalogBrand { Brand = brand });

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<int?> Update(int id, string brand)
    {
        var item = await _dbContext.CatalogBrands.FirstOrDefaultAsync(x => x.Id == id);

        if (item != null)
        {
            item.Brand = brand;
            await _dbContext.SaveChangesAsync();

            return item.Id;
        }

        return default(int?);
    }

    public async Task Remove(int id)
    {
        var item = await _dbContext.CatalogBrands.FirstOrDefaultAsync(x => x.Id == id);

        if (item != null)
        {
            _dbContext.CatalogBrands.Remove(item);
        }

        await _dbContext.SaveChangesAsync();
    }

    public async Task<PaginatedItems<CatalogBrand>> GetBrandsAsync(int pageIndex, int pageSize)
    {
        var totalItems = await _dbContext.CatalogBrands
            .LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogBrands
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .OrderBy(c => c.Brand)
            .ToListAsync();

        return new PaginatedItems<CatalogBrand>() { TotalCount = totalItems, Data = itemsOnPage };
    }
}