using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogService
{
    Task<PaginatedItemsResponse<CatalogItemDto>> GetCatalogItemsAsync(int pageSize, int pageIndex);

    Task<PaginatedItemsResponse<CatalogItemDto>> GetCatalogByIdAsync(int id);

    Task<PaginatedItemsResponse<CatalogItemDto>> GetCatalogByBrandAsync(int pageSize, int pageIndex, string nameBrand);

    Task<PaginatedItemsResponse<CatalogItemDto>> GetCatalogByTypeAsync(int pageSize, int pageIndex, string nameType);

    Task<PaginatedItemsResponse<CatalogBrandDto>> GetBrandsAsync(int pageSize, int pageIndex);

    Task<PaginatedItemsResponse<CatalogTypeDto>> GetTypesAsync(int pageSize, int pageIndex);
}