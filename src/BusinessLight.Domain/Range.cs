namespace BusinessLight.Domain
{
    public abstract class Range<T>
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
        protected Range(T from, T to)
        {
            From = from;
            To = to;
        }

        /// <summary>
        /// Gets or sets the from.
        /// </summary>
        public T From
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the to.
        /// </summary>
        public T To
        {
            get;
            set;
        }
    }
}
