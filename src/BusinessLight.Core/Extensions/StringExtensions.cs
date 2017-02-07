namespace BusinessLight.Core.Extensions
{
    public static class StringExtensions
    {
        public static string Truncate(this string value, int maxLength, string elipses = "...")
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            return value.Length <= maxLength ? value : value.Substring(0, maxLength) + elipses;
        }
    }
}
