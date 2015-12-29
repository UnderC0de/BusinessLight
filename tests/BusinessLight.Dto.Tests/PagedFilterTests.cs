using BusinessLight.Tests.Common.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace BusinessLight.Dto.Tests
{
    [TestClass]
    public class PagedFilterTests
    {
        [TestMethod]
        public void CanCreate()
        {
            var pagedFilter = new FishPagedFilter();
            pagedFilter.PageSize.Should().Be.EqualTo(Costants.DefaultPageSize);
            pagedFilter.PageNumber.Should().Be.EqualTo(Costants.DefaultPageNumber);
            pagedFilter.PageSize = 5;
            pagedFilter.PageNumber = 15;
            pagedFilter.PageSize.Should().Be.EqualTo(5);
            pagedFilter.PageNumber.Should().Be.EqualTo(15);
        }
    }
}
