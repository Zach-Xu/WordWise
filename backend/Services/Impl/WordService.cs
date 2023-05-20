using backend.Entity.Word;
using backend.Repository;

namespace backend.Services
{
    public class WordService : IWordService
    {
        private readonly WordRepository wordRepo;

        public WordService(WordRepository wordRepo)
        {
            this.wordRepo = wordRepo;
        }

        public Task<WordRecord> CreateWordRecordAsync(WordRecord wordRecord)
        {
            return wordRepo.CreateWordRecordAsnyc(wordRecord);
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
