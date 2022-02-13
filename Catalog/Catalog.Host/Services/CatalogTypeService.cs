using Catalog.Host.Data;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogTypeService : BaseDataService<ApplicationDbContext>, ICatalogTypeService
{
    private readonly ICatalogTypeRepository _catalogTypeRepository;

    public CatalogTypeService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogTypeRepository catalogTypeRepository)
        : base(dbContextWrapper, logger)
    {
        _catalogTypeRepository = catalogTypeRepository;
    }

    public Task<int?> Add(string type)
    {
        return ExecuteSafeAsync(() => _catalogTypeRepository.Add(type));
    }

    public Task<int?> Update(int id, string type)
    {
        return ExecuteSafeAsync(() => _catalogTypeRepository.Update(id, type));
    }

    public Task Remove(int id)
    {
        return ExecuteSafeAsync(() => _catalogTypeRepository.Remove(id));
    }
}