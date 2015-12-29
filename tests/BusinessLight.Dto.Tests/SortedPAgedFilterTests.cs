using BusinessLight.Tests.Common.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace BusinessLight.Dto.Tests
{
    [TestClass]
    public class SortedPAgedFilterTests
    {
        [TestMethod]
        public void CanCreate()
        {
            var pagedFilter = new FishSortedPagedFilter();
            pagedFilter.PageSize.Should().Be.EqualTo(Costants.DefaultPageSize);
            pagedFilter.PageNumber.Should().Be.EqualTo(Costants.DefaultPageNumber);
            pagedFilter.PageSize = 5;
            pagedFilter.PageNumber = 15;
            pagedFilter.PageSize.Should().Be.EqualTo(5);
            pagedFilter.PageNumber.Should().Be.EqualTo(15);
            pagedFilter.IsAscending.Should().Be.EqualTo(Costants.DefaultIsAscending);
            pagedFilter.SortField.Should().Be.EqualTo(Costants.DefaultSortField);
            pagedFilter.IsAscending = false;
            pagedFilter.SortField = "Name";
            pagedFilter.IsAscending.Should().Be.False();
            pagedFilter.SortField.Should().Be.EqualTo("Name");
        }
    }
}