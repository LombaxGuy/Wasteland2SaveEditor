namespace Wasteland2SaveEditor.Extensions
{
    public static class StringExtensions
    {
        public static string GetBetween(this string originalString, string startString, string endString)
        {
            int startIndex = originalString.IndexOf(startString) + startString.Length;
            int endIndex = originalString.IndexOf(endString);

            return originalString.Substring(startIndex, endIndex - startIndex);
        }

        public static string InsertBetween(this string originalString, string startString, string endString, string betweenValue, bool overwrite = true)
        {
            int startIndex = originalString.IndexOf(startString) + startString.Length;
            int endIndex = originalString.IndexOf(endString);

            if (overwrite)
            {
                originalString = originalString.Remove(startIndex, endIndex - startIndex);
            }

            return originalString.Insert(startIndex, betweenValue);
        }

        public static string Replace(this string originalString, string newValue, params string[] stringsToReplace)
        {
            foreach (var item in stringsToReplace)
            {
                originalString = originalString.Replace(item, newValue);
            }

            return originalString;
        }

        public static string TrimStart(this string originalString, string stringToRemove)
        {
            if (originalString.StartsWith(stringToRemove))
            {
                return originalString.Remove(0, stringToRemove.Length);
            }
            else
            {
                return originalString;
            }
        }

        public static string TrimEnd(this string originalString, string stringToRemove)
        {
            if (originalString.EndsWith(stringToRemove))
            {
                return originalString.Remove(originalString.Length - stringToRemove.Length);
            }
            else
            {
                return originalString;
            }
        }

        public static string Trim(this string originalString, string stringToRemove)
        {
            string trimmedString = originalString;

            trimmedString = trimmedString.TrimStart(stringToRemove);
            trimmedString = trimmedString.TrimEnd(stringToRemove);

            return trimmedString;
        }

        public static string CapitalizeFirstLetter(this string originalString)
        {
            return originalString[0].ToString().ToUpper() + originalString.Remove(0, 1);
        }

        public static string InsertSpaces(this string originalString)
        {
            if (string.IsNullOrWhiteSpace(originalString))
            {
                return originalString;
            }

            string newString = originalString[0].ToString();

            for (int i = 1; i < originalString.Length; i++)
            {
                if (char.IsUpper(originalString[i]) && originalString[i - 1] != ' ')
                {
                    newString += " ";
                }

                newString += originalString[i];
            }

            return newString;
        }
    }
}
