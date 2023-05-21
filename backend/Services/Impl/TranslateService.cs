using backend.Entity.Word;
using backend.Utils;
using DeepL;

namespace backend.Services.Impl
{
    public class TranslateService : ITranslateService
    {
        private readonly ITranslator translator;
        private readonly ILanguageMapper languageMapper;

        public TranslateService(ITranslator translator, ILanguageMapper languageMapper)
        {
            this.translator = translator;
            this.languageMapper = languageMapper;
        }

        /// <summary>
        /// Translate English word to targeted language
        /// </summary>
        /// <param name="word">English word</param>
        /// <param name="language">target language</param>
        /// <returns></returns>
        public async Task<Translation> TranslateWordAsync(string word, Language language)
        {
            string languageCode = languageMapper.GetLanguageCode(language);
            if (string.IsNullOrEmpty(languageCode))
            {
                throw new Exception("Target language currently is not supported");
            }
            var translatedText = await translator.TranslateTextAsync(
                word,
                LanguageCode.English,
                languageCode
            );
            return new Translation(language, translatedText.Text);   
        }
    }
}
