using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace BusinessLight.Domain.Tests
{
    [TestClass]
    public class DateTimeRangeTests
    {
        [TestMethod]
        public void CanCreateDateTimeRange()
        {
            var date1 = new DateTime(2016,02,01);
            var date2 = new DateTime(2016, 02, 15);
            var dateTimeRange = new DateTimeRange(date1, date2);
            dateTimeRange.From.Should().Be.EqualTo(date1);
            dateTimeRange.To.Should().Be.EqualTo(date2);
        }
    }
}
