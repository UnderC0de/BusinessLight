using System;
using System.Globalization;
using System.Threading;

namespace BusinessLight.Core.Localization
{
    public class LocalizationContext : IDisposable
    {
        private readonly CultureInfo _previousCulture;
        private readonly CultureInfo _previousUiCulture;

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

            _previousCulture = Thread.CurrentThread.CurrentCulture;
            _previousUiCulture = Thread.CurrentThread.CurrentUICulture;

            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newUiCulture;
        }

        public void Dispose()
        {
            Thread.CurrentThread.CurrentCulture = _previousCulture;
            Thread.CurrentThread.CurrentUICulture = _previousUiCulture;
        }

        private static CultureInfo CreateSpecificCulture(string culture)
        {
            return string.IsNullOrWhiteSpace(culture) ? null : CultureInfo.CreateSpecificCulture(culture);
        }
    }
}
