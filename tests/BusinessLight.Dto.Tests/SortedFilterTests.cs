using BusinessLight.Tests.Common.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace BusinessLight.Dto.Tests
{
    [TestClass]
    public class SortedFilterTests
    {
        [TestMethod]
        public void CanCreate()
        {
            var pagedFilter = new FishSortedFilter();
            pagedFilter.IsAscending.Should().Be.EqualTo(Costants.DefaultIsAscending);
            pagedFilter.SortField.Should().Be.EqualTo(Costants.DefaultSortField);
            pagedFilter.IsAscending = false;
            pagedFilter.SortField = "Name";
            pagedFilter.IsAscending.Should().Be.False();
            pagedFilter.SortField.Should().Be.EqualTo("Name");
        }
    }
}