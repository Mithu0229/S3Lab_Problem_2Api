using Data.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using System.Threading.Tasks;

namespace S3Lab_Problem_2Api.Controllers
{
    public class ReadingController : CommonController
    {
        private readonly IReadingService _readingService;
        public ReadingController(IReadingService readingService)
        {
            _readingService = readingService;
        }

        [HttpPost]
        public ActionResult GetReading([FromBody] ReadPassModel model)
        {
            var results = _readingService.GetReadings(model);

            ReadModelList models = new ReadModelList();

            foreach (var item in results)
            {
                models.Values.Add(item.Value);
                models.TimeStamps.Add(item.TimeStamp);
            }

            if (models != null)
            {
                return Ok(models);
            }

            return BadRequest("No list here.");
        }

        [HttpGet]
        public ActionResult InsertDate()
        {
            var count = _readingService.InsertData();
            return Ok(count);
        }


    }
}
