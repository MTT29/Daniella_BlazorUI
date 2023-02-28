namespace Daniella_BlazorUI.Models.ResponseModels
{
    public class UpdateResponse
    {
        public int All { get; set; }
        public int Rejected { get; set; }
        public int Unique { get; set; }
        public int New { get; set; }
        public int Modified { get; set; }
        public int Classified { get; set; }
        public int Reclassified { get; set; }
        public int DeletedClassifications { get; set; }
        public int DeletedRelatedProducts { get; set; }
        public int CreatedRelatedProducts { get; set; }
        public int LimitExceeded { get; set; }
        public ApiStatisticsOptions Options { get; set; }
    }
    public class ApiStatisticsOptions
    {
        public string New { get; set; }
        public string Existing { get; set; }
        public bool Empty { get; set; }
    }
}
