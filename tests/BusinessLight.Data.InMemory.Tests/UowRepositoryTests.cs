using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BusinessLight.Tests.Common.Entities;
using BusinessLight.Tests.Common.Specifications;
using FizzWare.NBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace BusinessLight.Data.InMemory.Tests
{
    using System.Threading.Tasks;

    [TestClass]
    public class UowRepositoryTests
    {
        private readonly ArrayList _arrayList = new ArrayList();

        public UowRepositoryTests()
        {
            var fishes = Builder<Fish>.CreateListOfSize(5).Build().ToList();
            var cats = Builder<Cat>.CreateListOfSize(10).Build().ToList();
            _arrayList.AddRange(fishes);
            _arrayList.AddRange(cats);
        }

        [TestMethod]
        public async Task CanQuery()
        {
            using (var unitOfWork = new InMemoryUnitOfWork(_arrayList))
            {
                var countFish = (await unitOfWork.Repository.QueryAsync<Fish>()).Count();
                var countCat = (await unitOfWork.Repository.QueryAsync<Cat>()).Count();
                countFish.Should().Be.EqualTo(5);
                countCat.Should().Be.EqualTo(10);
            }
        }

        [TestMethod]
        public async Task CanApplyQuery()
        {
            using (var unitOfWork = new InMemoryUnitOfWork(_arrayList))
            {
                var countFish = (await unitOfWork.Repository.QueryAsync<Fish>()).Count();
                var queryFish = (await unitOfWork.Repository.IsSatisfiedByAsync(new SearchFishSpecification("Na"))).ToList();
                queryFish.Count.Should().Be.EqualTo(countFish);
                queryFish = (await unitOfWork.Repository.IsSatisfiedByAsync(new SearchFishSpecification(string.Empty))).ToList();
                queryFish.Count.Should().Be.EqualTo(countFish);
                queryFish = (await unitOfWork.Repository.IsSatisfiedByAsync(new SearchFishSpecification("notexistingname"))).ToList();
                queryFish.Count.Should().Be.EqualTo(0);
            }
        }

        [TestMethod]
        public async Task CanApplySortedQuery()
        {
            using (var unitOfWork = new InMemoryUnitOfWork(_arrayList))
            {
                var allFishes = (await unitOfWork.Repository.QueryAsync<Fish>()).OrderBy(x => x.Color).ToList();
                var queryFishes = (await unitOfWork.Repository.IsSatisfiedByAsync(new SearchFishSortedSpecification("Na", "Color", true))).ToList();
                queryFishes.Count.Should().Be.EqualTo(allFishes.Count);
                
                for (var i = 0; i < queryFishes.Count; i++)
                {
                    var fish = allFishes.ElementAt(i);
                    var queryFish = queryFishes.ElementAt(i);
                    fish.Name.Should().Be.EqualTo(queryFish.Name);
                    fish.Color.Should().Be.EqualTo(queryFish.Color);
                    fish.Should().Be.EqualTo(queryFish);
                }


                allFishes = (await unitOfWork.Repository.QueryAsync<Fish>()).OrderByDescending(x => x.Color).ToList();
                queryFishes = (await unitOfWork.Repository.IsSatisfiedByAsync(new SearchFishSortedSpecification("Na", "Color", false))).ToList();
                queryFishes.Count.Should().Be.EqualTo(allFishes.Count);
                for (var i = 0; i < queryFishes.Count; i++)
                {
                    var fish = allFishes.ElementAt(i);
                    var queryFish = queryFishes.ElementAt(i);
                    fish.Name.Should().Be.EqualTo(queryFish.Name);
                    fish.Color.Should().Be.EqualTo(queryFish.Color);
                    fish.Should().Be.EqualTo(queryFish);
                }
            }
        }

        [TestMethod]
        public async Task CanAdd()
        {
            using (var unitOfWork = new InMemoryUnitOfWork(_arrayList))
            {
                var countFish = (await unitOfWork.Repository.QueryAsync<Fish>()).Count();
                await unitOfWork.Repository.AddAsync(new Fish());
                await unitOfWork.CommitAsync();
                var newCountFish = (await unitOfWork.Repository.QueryAsync<Fish>()).Count();
                newCountFish.Should().Be.EqualTo(countFish + 1);
            }
        }

        [TestMethod]
        public async Task CanRemove()
        {
            using (var unitOfWork = new InMemoryUnitOfWork(_arrayList))
            {
                var countFish = (await unitOfWork.Repository.QueryAsync<Fish>()).Count();
                await unitOfWork.Repository.RemoveAsync((await unitOfWork.Repository.QueryAsync<Fish>()).First());
                await unitOfWork.CommitAsync();
                var newCountFish = (await unitOfWork.Repository.QueryAsync<Fish>()).Count();
                newCountFish.Should().Be.EqualTo(countFish - 1);
            }
        }

        [TestMethod]
        public async Task CanUpdate()
        {
            using (var unitOfWork = new InMemoryUnitOfWork(_arrayList))
            {
                var fish =  (await unitOfWork.Repository.QueryAsync<Fish>()).First();
                fish.Name.Should().Not.Be.EqualTo("NewName");
                fish.Name = "NewName";
                await unitOfWork.Repository.UpdateAsync(fish);
                await unitOfWork.CommitAsync();
                var updatedFish = (await unitOfWork.Repository.QueryAsync<Fish>()).First(x => x.Id == fish.Id);
                updatedFish.Name.Should().Be.EqualTo("NewName");
            }
        }
    }
}
