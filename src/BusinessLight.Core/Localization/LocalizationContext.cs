namespace BusinessLight.Core.Localization
{
    using System;
    using System.Globalization;
    using System.Threading;

    public class LocalizationContext : IDisposable
    {
        private readonly CultureInfo previousCulture;
        private readonly CultureInfo previousUiCulture;

        public LocalizationContext(string newCulture, string newUiCulture = null)
            : this(CreateSpecificCulture(newCulture), CreateSpecificCulture(newUiCulture))
        {
        }

        public LocalizationContext(CultureInfo newCulture, CultureInfo newUiCulture = null)
        {
            if (newCulture == null)
            {
                throw new ArgumentNullException(nameof(newCulture));
            }

            if (newUiCulture == null)
            {
                newUiCulture = newCulture;
            }

            this.previousCulture = Thread.CurrentThread.CurrentCulture;
            this.previousUiCulture = Thread.CurrentThread.CurrentUICulture;

            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newUiCulture;
        }

        public void Dispose()
        {
            Thread.CurrentThread.CurrentCulture = this.previousCulture;
            Thread.CurrentThread.CurrentUICulture = this.previousUiCulture;
        }

        private static CultureInfo CreateSpecificCulture(string culture)
        {
            return string.IsNullOrWhiteSpace(culture) ? null : CultureInfo.CreateSpecificCulture(culture);
        }
    }
}
