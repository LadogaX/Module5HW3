using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogBrandRepository
    {
        Task<int?> Add(string brand);
        Task<PaginatedItems<CatalogBrand>> GetBrandsAsync(int pageIndex, int pageSize);
        Task Remove(int id);
        Task<int?> Update(int id, string brand);
    }
}