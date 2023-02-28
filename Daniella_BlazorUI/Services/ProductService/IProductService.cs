using Daniella_BlazorUI.Models.Common;
using Daniella_BlazorUI.Models.ResponseModels;

namespace Daniella_BlazorUI.Services.ProductService
{
    public interface IProductService
    {
        event Action ProductChanged;

        List<string> Products {get;set;}

        string   Message { get; set; }

        int CurrentPage { get; set; }

        int PageCount { get; set; }

        public Task GetProductIds(string productId, string supplierId, int pagenumber, int produtcsPerPage = 10);

        public Task<ProductDetails> GetProduct(string id);

        public Task UpdateProduct(ProductDetails product);

        //Task<Product> UpdatProductAsync(string productId);

    }

}
