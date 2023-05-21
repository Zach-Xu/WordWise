using backend.Entity.Word;
using DeepL;

namespace backend.Utils.Impl
{
    public class LanguageMapper : ILanguageMapper
    {
        private readonly Dictionary<Language, string> languageCodeMap;

        public LanguageMapper()
        {
            languageCodeMap = new Dictionary<Language, string>
            {
                { Language.Bulgarian, LanguageCode.Bulgarian },
                { Language.Czech, LanguageCode.Czech },
                { Language.Danish, LanguageCode.Danish },
                { Language.German, LanguageCode.German },
                { Language.Greek, LanguageCode.Greek },
                { Language.English, LanguageCode.English },
                { Language.Spanish, LanguageCode.Spanish },
                { Language.Estonian, LanguageCode.Estonian },
                { Language.Finnish, LanguageCode.Finnish },
                { Language.French, LanguageCode.French },
                { Language.Hungarian, LanguageCode.Hungarian },
                { Language.Indonesian, LanguageCode.Indonesian },
                { Language.Italian, LanguageCode.Italian },
                { Language.Japanese, LanguageCode.Japanese },
                { Language.Korean, LanguageCode.Korean },
                { Language.Lithuanian, LanguageCode.Lithuanian },
                { Language.Latvian, LanguageCode.Latvian },
                { Language.NorwegianBokmal, LanguageCode.Norwegian },
                { Language.Dutch, LanguageCode.Dutch },
                { Language.Polish, LanguageCode.Polish },
                { Language.Portuguese, LanguageCode.Portuguese },
                { Language.Romanian, LanguageCode.Romanian },
                { Language.Russian, LanguageCode.Russian },
                { Language.Slovak, LanguageCode.Slovak },
                { Language.Slovenian, LanguageCode.Slovenian },
                { Language.Swedish, LanguageCode.Swedish },
                { Language.Turkish, LanguageCode.Turkish },
                { Language.Ukrainian, LanguageCode.Ukrainian },
                { Language.Chinese, LanguageCode.Chinese }
            };
        }

        public string GetLanguageCode(Language language)
        {
            return languageCodeMap.TryGetValue(language, out var languageCode)
                ? languageCode
                : string.Empty;
        }
    }
}
