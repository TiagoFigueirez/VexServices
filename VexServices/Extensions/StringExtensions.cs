using System.Text.RegularExpressions;

namespace VexServices.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Retorna o texto entre parênteses na string.
        /// Exemplo: "Natureza (1234)" → "1234"
        /// </summary>
        public static string GetValueBetweenParentheses(this string value)
        {
            if(string.IsNullOrWhiteSpace(value)) 
                return string.Empty;

            var match = Regex.Match(value, @"\((.*?)\)");
            return match.Success ? match.Groups[1].Value.Trim() : string.Empty;
        }
    }
}
