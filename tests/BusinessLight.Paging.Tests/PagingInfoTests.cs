using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace BusinessLight.Paging.Tests
{
    [TestClass]
    public class PagingInfoTests
    {
        [TestMethod]
        public void GivenAListPagingInfoShouldBeCorrects()
        {
            var pagingInfo = new PagingInfo(0, 25, 100);
            pagingInfo.TotalItemCount.Should().Be.EqualTo(100);
            pagingInfo.PageCount.Should().Be.EqualTo(4);
            pagingInfo.FirstItemOnPage.Should().Be.EqualTo(0);
            pagingInfo.LastItemOnPage.Should().Be.EqualTo(24);
            pagingInfo.HasPreviousPage.Should().Be.False();
            pagingInfo.HasNextPage.Should().Be.True();
            pagingInfo.PageNumber.Should().Be.EqualTo(0);
            pagingInfo.PageSize.Should().Be.EqualTo(25);
            pagingInfo.IsFirstPage.Should().Be.True();
            pagingInfo.IsLastPage.Should().Be.False();
        }
    }
}
