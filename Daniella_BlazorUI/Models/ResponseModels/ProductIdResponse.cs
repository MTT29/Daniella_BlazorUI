namespace Daniella_BlazorUI.Models.ResponseModels
{

    public class ProductIdResponse
    {
        /// <summary>
        /// The list of productids
        /// </summary>
        public List<string> productIds { get; set; }

        /// <summary>
        /// The count of pages depend on the call
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// The current page 
        /// </summary>
        public int CurrentPage { get; set; }
    }

}
