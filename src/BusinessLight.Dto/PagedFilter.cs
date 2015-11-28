namespace BusinessLight.Dto
{
    public abstract class PagedFilter
    {
        protected PagedFilter()
        {
            PageNumber = 0;
            PageSize = 20;
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