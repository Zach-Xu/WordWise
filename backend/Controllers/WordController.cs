using backend.Entity.Word;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/words")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private readonly IWordService wordService;

        public WordController(IWordService wordService)
        {
            this.wordService = wordService;
        }

        [HttpPost]
        public async Task<ResponseResult<WordRecord>> CreateWordRecord(WordDto wordDto)
        {
            WordRecord wordRecord = await wordService.CreateWordRecordAsync(wordDto);
            return new ResponseResult<WordRecord>(StatusCodes.Status200OK, wordRecord, "Create word record successfully!");
        }

        [HttpGet]
        public async Task<ResponseResult<WordRecord[]>> GetWordRecords([FromQuery]DateTime date, [FromQuery]Language language = Language.Chinese)
        {
            WordRecord[] wordRecords = await wordService.GetWordRecordsByDateAndLanguageAsync(date, language);
            return new ResponseResult<WordRecord[]>(StatusCodes.Status200OK, wordRecords, $"Fetch words on {date} successfully");
        }

    }
}
