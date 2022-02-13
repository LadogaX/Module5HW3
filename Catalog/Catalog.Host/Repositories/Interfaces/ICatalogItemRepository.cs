using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogItemRepository
{
    Task<PaginatedItems<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize);
    Task<int?> Add(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
    Task<PaginatedItems<CatalogItem>> GetByIdAsync(int id);
    Task<PaginatedItems<CatalogItem>> GetByBrandAsync(int pageIndex, int pageSize, string nameBrand);
    Task<PaginatedItems<CatalogItem>> GetByTypeAsync(int pageIndex, int pageSize, string nameType);

    Task Remove(int id);
    Task<int?> Update(int id, string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
}