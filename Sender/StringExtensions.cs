using System;

namespace Sender
{
    public static class StringExtensions
    {
        public static bool Contains(this String str, String substring,
            StringComparison comp)
        {
            if (substring == null)
                throw new ArgumentNullException("substring",
                    "substring cannot be null.");
            return str.IndexOf(substring, comp) >= 0;
        }
    }
}
