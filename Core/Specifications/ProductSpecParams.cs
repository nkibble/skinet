namespace Core.Specifications
{
    public class ProductSpecParams
    {

        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 6;
        public int PageSize 
        {
            get => _pageSize;
            // Don't allow a page size to be greater than our max setting (50):
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        private string _search;
        public string Search 
        {
            get => _search;
            set => _search = value.ToLower();
        }

        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public string Sort { get; set; }

    }
}