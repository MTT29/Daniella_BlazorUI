using Daniella_BlazorUI.Models.Common;
using Daniella_BlazorUI.Models.ResponseModels;
using MudBlazor;
using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace Daniella_BlazorUI.Services.ProductService
{
    public class ProductService : IProductService
    {
        private string companyName = "XYZ";

        private string baseauth = "Basic";
        private string baseAuth_value = "XYZ:password";

        private string apiPrefix = " https://daniella.etim-mapper.com/api/";

        private readonly HttpClient httpClient;
        private readonly ILogToFileService logToFileService;

        public event Action ProductChanged;

        /// <summary>
        /// Message to notify  user if something went wrong
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The list of products
        /// </summary>
        public List<string> Products { get; set; }

        /// <summary>
        /// The current page 
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// The count of all pages 
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClient"></param>
        public ProductService(HttpClient httpClient, ILogToFileService logToFileService)
        {
            this.httpClient = httpClient;
            this.logToFileService = logToFileService;
        }


        /// <summary>
        /// Get produc Ids
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="supplierId"></param>
        /// <param name="produtcsPerPage"></param>
        /// <param name="pagenumber"></param>
        /// <returns></returns>
        public async Task GetProductIds(string productId, string supplierId, int pagenumber, int produtcsPerPage = 10)
        {
            AddHeader(httpClient);
            var endpoint = $"https://daniella.etim-mapper.com/api/XYZ/products/filter?only-ids=true&limit={produtcsPerPage}&page={pagenumber}";

            var queryParams = new
            {
                productId = productId,
                supplierId = supplierId,
            };

            try
            {

                HttpResponseMessage response = await httpClient.PostAsJsonAsync($"{endpoint}", queryParams);
                if (response != null)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var productResponse = await response.Content.ReadFromJsonAsync<ProductDetails>();



                    }
                }
            }
            catch (Exception)
            {
                logToFileService.LogError("GetProducIds call  is unsuccessful");
            }


        }

        /// <summary>
        /// Get producdetails based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProductDetails> GetProduct(string id)
        {
            AddHeader(httpClient);
            var endpoint = $"https://daniella.etim-mapper.com/api/XYZ/products";

            var queryParams = new
            {
                productId = id,

            };

            try
            {

                HttpResponseMessage response = await httpClient.PostAsJsonAsync($"{endpoint}", queryParams);
                if (response != null)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var productResponse = await response.Content.ReadFromJsonAsync<ProductDetails>();

                        return productResponse;

                    }
                }
            }
            catch (Exception)
            {
                logToFileService.LogError("GetProduct call  is unsuccessful");
                return null;

            }
            return null;

        }



        public async Task UpdateProduct(ProductDetails product)
        {
            AddHeader(httpClient);
            var endpoint = $"https://daniella.etim-mapper.com/api/XYZ/products";


            try
            {

                HttpResponseMessage response = await httpClient.PostAsJsonAsync($"{endpoint}", product);
                if (response != null)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var productResponse = await response.Content.ReadFromJsonAsync<UpdateResponse>();

                    }
                }
            }
            catch (Exception)
            {
                logToFileService.LogError("Update  call  is unsuccessful");
            

            }
       
        }







        /// <summary>
        /// Add a baseauthentication to the header of request
        /// </summary>
        /// <param name="client"></param>
        private void AddHeader(HttpClient client)
        {
            var convertedValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(baseAuth_value));


            client.DefaultRequestHeaders.Add(baseauth, convertedValue);
        }

    }     
}
