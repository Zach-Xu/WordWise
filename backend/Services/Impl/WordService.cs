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
            // return word record if such word was previous already translated into targeted language
            var existedRecord = await wordRepo.GetWordRecordByWordAndLanguage(wordDto.Word, wordDto.Language);
            if(existedRecord != null)
            {
                // increase the frequency by 1
                existedRecord.Frequency++;
                wordRepo.UpdateEntities();
                return existedRecord;
            }

            // otherwise translate the word and save it to the database
            var translation = await translateService.TranslateWordAsync(wordDto.Word, wordDto.Language);
            WordRecord wordRecord = new()
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
