using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogTypeRepository
    {
        Task<int?> Add(string type);
        Task<PaginatedItems<CatalogType>> GetTypesAsync(int pageIndex, int pageSize);
        Task Remove(int id);
        Task<int?> Update(int id, string type);
    }
}