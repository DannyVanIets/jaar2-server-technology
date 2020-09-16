using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutingWithDynamicController
{
    public class TranslationDatabase
    {
        private static Dictionary<string, Dictionary<string, string>> Translations = new Dictionary<string, Dictionary<string, string>>
        {
            {
                "en", new Dictionary<string, string>
                {
                    { "books", "books" },
                    { "list", "list" }
                }
            },
            {
                "de", new Dictionary<string, string>
                {
                    { "bücher", "books" },
                    { "liste", "list" }
                }
            },
            {
                "nl", new Dictionary<string, string>
                {
                    { "boeken", "books" },
                    { "lijst", "list" }
                }
            },
        };

        public async Task<string> Resolve(string lang, string value)
        {
            var normalizedLang = lang.ToLowerInvariant();
            var normalizedValue = value.ToLowerInvariant();
            if (Translations.ContainsKey(normalizedLang) && Translations[normalizedLang].ContainsKey(normalizedValue))
            {
                return Translations[normalizedLang][normalizedValue];
            }

            return null;
        }
    }
}
