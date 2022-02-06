using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using System.Threading.Tasks;

namespace S3Lab_Problem_2Api.Controllers
{
    public class DataFieldController : CommonController
    {
        private readonly IDataFieldService _dataFieldService;
        public DataFieldController(IDataFieldService dataFieldService)
        {
            _dataFieldService = dataFieldService;
        }

        [HttpGet]
        public async Task<ActionResult> GetDataFields()
        {
            var results = await _dataFieldService.GetDataFields();

            if(results != null)
            {
                return Ok(results);
            }
            return NotFound();
        }
    }
}
