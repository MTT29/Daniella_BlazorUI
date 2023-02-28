using Microsoft.AspNetCore.Identity;

namespace Daniella_BlazorUI.Models.Common
{
    public class ProductDetails
    {
        /// <summary>
        /// ProductId
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Hu DescriptionShort
        /// </summary>
        public string DescriptionShort { get; set; }

        /// <summary>
        /// BrandnName
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// HU SupplierDescpritoion 
        /// </summary>
        public string SupplierDescriptionShort { get; set; }

        /// <summary>
        /// ETIM Class Id
        /// </summary>
        public string ClassId { get; set; }

        /// <summary>
        /// ETIM Description - overallinformation
        /// </summary>
        public string OverallInformationEtimDescription { get; set; }

        /// <summary>
        /// Product Status - overallInformation
        /// </summary>
        public string  OverallInformationStatus  { get; set; }
    }
}

