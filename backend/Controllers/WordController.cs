using backend.Entity.Word;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private readonly IWordService wordService;

        public WordController(IWordService wordService)
        {
            this.wordService = wordService;
        }

        [HttpPost]
        [Route("/wordrecord")]
        public async Task<ResponseResult<WordRecord>> CreateWordRecord(WordDto wordDto)
        {
            WordRecord wordRecord = await wordService.CreateWordRecordAsync(wordDto);
            return new ResponseResult<WordRecord>(Ok().StatusCode, wordRecord, "Create word record successfully!");
        }

    }
}
