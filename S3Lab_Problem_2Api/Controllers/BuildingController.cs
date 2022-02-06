using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using System.Threading.Tasks;

namespace S3Lab_Problem_2Api.Controllers
{
    public class BuildingController : CommonController
    {
        private readonly IBuildingService _buildingService;
       
        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpGet]
        public async Task<ActionResult> GetBuildings()
        {
            var buildings = await _buildingService.GetBuildings();

            if (buildings != null)
            {
                return Ok(buildings);
            }
            return NotFound();
        }
    }
}
