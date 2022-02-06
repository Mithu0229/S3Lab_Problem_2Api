using Data.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using System.Threading.Tasks;

namespace S3Lab_Problem_2Api.Controllers
{
    public class ReadingController : CommonController
    {
        private readonly IBuildingService _buildingService;
        private readonly IDataFieldService _dataFieldService;
        private readonly IReadingService _readingService;
        private readonly IObjectService _objectService;
        public ReadingController(IBuildingService buildingService, IObjectService objectService, IDataFieldService dataFieldService, IReadingService readingService)
        {
            _buildingService = buildingService;
            _dataFieldService = dataFieldService;
            _objectService = objectService;
            _readingService = readingService;
        }

        [HttpPost]
        public ActionResult GetReading([FromBody] ReadPassModel model)
        {
            var buildings =  _readingService.GetReadings(model);

            ReadModelList models = new ReadModelList();
            foreach (var item in buildings)
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

    }
}
