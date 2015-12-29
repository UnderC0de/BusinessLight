using System.ComponentModel.DataAnnotations;

namespace BusinessLight.Dto
{
    public abstract class SortedFilter : ISortedFilter
    {
        protected SortedFilter()
        {
            SortField = Costants.DefaultSortField;
            IsAscending = Costants.DefaultIsAscending;
        }

        [Display(Name = "Sort field")]
        public string SortField
        {
            get;
            set;
        }

        [Display(Name = "Is ascending")]
        public bool IsAscending
        {
            get;
            set;
        }
    }
}