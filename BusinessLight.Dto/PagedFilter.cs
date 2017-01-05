
namespace BusinessLight.Dto
{
    public abstract class PagedFilter : IPagedFilter
    {
     

        protected PagedFilter()
        {
            PageNumber = Costants.DefaultPageNumber;
            PageSize = Costants.DefaultPageSize;
        }

        public int PageNumber
        {
            get;
            set;
        }

        public int PageSize
        {
            get;
            set;
        }
    }
}