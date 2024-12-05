namespace MyDemos
{
    public static class StringCompare
    {
        public static bool CompareOrdinal(this string input, string valueToCompare)
        {
            return input.Equals(valueToCompare, StringComparison.Ordinal);
        }
    }
}
