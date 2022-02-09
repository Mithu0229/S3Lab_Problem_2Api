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
    public class ObjectService : IObjectService
    {
        private readonly ExmDBContext _db;
        public ObjectService(ExmDBContext db)
        {
            _db = db;
        }
        
        public async Task<List<PObject>> GetPObjects()
        {
            try
            {
                var results = await _db.PObjects.ToListAsync();
                return results;
            }
            catch (Exception ex)
            {
                //log here
                throw;
            }
        }
    }
}
