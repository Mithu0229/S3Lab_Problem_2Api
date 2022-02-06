using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using System.Threading.Tasks;

namespace S3Lab_Problem_2Api.Controllers
{
    
    public class PObjectController : CommonController
    {
        private readonly IObjectService _objectService;
        public PObjectController(IObjectService objectService)
        {
            _objectService = objectService;
        }

        [HttpGet]
        public async Task<ActionResult> GetPObjects()
        {
            var results = await _objectService.GetPObjects();
            if (results != null)
            {
                return Ok(results);
            }
            return NotFound();
           
        }

    }
}
