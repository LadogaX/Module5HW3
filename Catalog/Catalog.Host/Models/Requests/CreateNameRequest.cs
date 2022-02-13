namespace Catalog.Host.Models.Requests
{
    public class CreateNameRequest : PaginatedItemsRequest
    {
        public string Name { get; set; } = null!;
    }
}
