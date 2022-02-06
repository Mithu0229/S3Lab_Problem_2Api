using Data.Data;
using Data.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly ExmDBContext _db;
        public BuildingService(ExmDBContext db)
        {
            _db = db;
        }
        public async Task<List<Building>> GetBuildings()
        {
            var results = await _db.Buildings.ToListAsync();
            return results;
        }
    }
}
