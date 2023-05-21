using backend.Entity.Word;
using backend.Models;
using backend.Repository;

namespace backend.Services
{
    public class WordService : IWordService
    {
        private readonly WordRepository wordRepo;
        private readonly ITranslateService translateService;

        public WordService(WordRepository wordRepo, ITranslateService translateService)
        {
            this.wordRepo = wordRepo;
            this.translateService = translateService;
        }

        public async Task<WordRecord> CreateWordRecordAsync(WordDto wordDto)
        {
            var translation = await translateService.TranslateWordAsync(wordDto.Word, wordDto.Language);
            WordRecord wordRecord = new WordRecord
            {
                EnglishWord = wordDto.Word,
                Translation = translation           
            };

            return await wordRepo.CreateWordRecordAsnyc(wordRecord);
        }

        public Task<WordRecord[]> GetWordRecordsAsync(int pageNum, int pageSize)
        {
            return wordRepo.GetWordRecordsAsync(pageNum, pageSize);
        }

        public Task<WordRecord[]> GetWordRecordsByDateAndLanguageAsync(DateTime date, Language language)
        {
            return wordRepo.GetWordRecordsByDateAndLanguageAsync(date, language);
        }

        public Task<WordRecord[]> GetWordRecordsByDateAsync(DateTime date)
        {
            return wordRepo.GetWordRecordsByDateAsync(date);
        }
    }
}
