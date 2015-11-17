using System.Collections.Generic;
using System.Linq;
using BusinessLight.Domain;
using FizzWare.NBuilder;

namespace BusinessLight.Tests.Common.Helpers
{
    public static class DataHelper
    {
        public static T CreateNew<T>() where T : UniqueEntity
        {
            return Builder<T>.CreateNew().Build();
        }

        public static List<T> CreateNewList<T>(int size) where T : UniqueEntity
        {
            return Builder<T>.CreateListOfSize(size).Build().ToList();
        }
    }
}
