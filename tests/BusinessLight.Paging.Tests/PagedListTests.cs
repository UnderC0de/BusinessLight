using System;
using System.Linq;
using BusinessLight.Tests.Common.Entities;
using FizzWare.NBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace BusinessLight.Paging.Tests
{
    [TestClass]
    public class PagedListTests
    {

        [TestMethod]
        public void CanCreatePagedListFromQueryable()
        {
            var items = 1000;
            var pageSize = 15;
            var fishes = Builder<Fish>.CreateListOfSize(items).Build().AsQueryable();

            var pagedList = new PagedList<Fish>(fishes, 0, pageSize);
            pagedList.PagingInfo.PageNumber.Should().Be.EqualTo(0);
            pagedList.Result.Should().Have.Count.EqualTo(pageSize);
            pagedList.PagingInfo.HasPreviousPage.Should().Be.False();
            pagedList.PagingInfo.HasNextPage.Should().Be.True();
            pagedList.PagingInfo.IsFirstPage.Should().Be.True();
            pagedList.PagingInfo.IsLastPage.Should().Be.False();
            pagedList.PagingInfo.TotalItemCount.Should().Be.EqualTo(items);
            pagedList.PagingInfo.PageCount.Should().Be.EqualTo(items/pageSize + 1);

            pagedList = new PagedList<Fish>(fishes, 1, pageSize);
            pagedList.PagingInfo.PageNumber.Should().Be.EqualTo(1);
            pagedList.Result.Should().Have.Count.EqualTo(pageSize);
            pagedList.PagingInfo.HasPreviousPage.Should().Be.True();
            pagedList.PagingInfo.HasNextPage.Should().Be.True();
            pagedList.PagingInfo.IsFirstPage.Should().Be.False();
            pagedList.PagingInfo.IsLastPage.Should().Be.False();
            pagedList.PagingInfo.TotalItemCount.Should().Be.EqualTo(items);
            pagedList.PagingInfo.PageCount.Should().Be.EqualTo(items / pageSize + 1);
        }

        [TestMethod]
        public void CanCreatePagedListFromNullSource()
        {
            var pageSize = 15;

            var pagedList = new PagedList<Fish>(null, 0, pageSize);
            pagedList.PagingInfo.PageNumber.Should().Be.EqualTo(0);
            pagedList.Result.Should().Have.Count.EqualTo(0);
            pagedList.PagingInfo.HasPreviousPage.Should().Be.False();
            pagedList.PagingInfo.HasNextPage.Should().Be.False();
            pagedList.PagingInfo.IsFirstPage.Should().Be.True();
            pagedList.PagingInfo.IsLastPage.Should().Be.False();
            pagedList.PagingInfo.TotalItemCount.Should().Be.EqualTo(0);
            pagedList.PagingInfo.PageCount.Should().Be.EqualTo(0);

            pagedList = new PagedList<Fish>(null, 1, pageSize);
            pagedList.PagingInfo.PageNumber.Should().Be.EqualTo(1);
            pagedList.Result.Should().Have.Count.EqualTo(0);
            pagedList.PagingInfo.HasPreviousPage.Should().Be.True();
            pagedList.PagingInfo.HasNextPage.Should().Be.False();
            pagedList.PagingInfo.IsFirstPage.Should().Be.False();
            pagedList.PagingInfo.IsLastPage.Should().Be.False();
            pagedList.PagingInfo.TotalItemCount.Should().Be.EqualTo(0);
            pagedList.PagingInfo.PageCount.Should().Be.EqualTo(0);
        }

        [TestMethod]
        public void CanCreatePagedList()
        {
            new PagedList<Fish>().Should().Not.Be.Null();
        }

        [TestMethod]
        public void CannotCreatePagedListWithInvalidArgs()
        {
            var fishes = Builder<Fish>.CreateListOfSize(3).Build().AsQueryable();

            new Action(() => new PagedList<Fish>(fishes, -1, -1))
                .Should()
                .Throw<ArgumentOutOfRangeException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be
                .EqualTo("pageNumber");

            new Action(() => new PagedList<Fish>(fishes, 1, -1))
                .Should()
                .Throw<ArgumentOutOfRangeException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be
                .EqualTo("pageSize");
        }
    }
}
