using System;

namespace BusinessLight.Domain
{
    public class DateTimeRange : Range<DateTime?>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Range{T}"/> class.
        /// </summary>
        /// <param name="from">
        /// The from.
        /// </param>
        /// <param name="to">
        /// The to.
        /// </param>
        public DateTimeRange(DateTime? @from, DateTime? to) 
            : base(@from, to)
        {
        }
    }
}