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
    public class DataFieldService : IDataFieldService
    {
        private readonly ExmDBContext _db;
        public DataFieldService(ExmDBContext db)
        {
            _db = db;
        }
        public async Task<List<DataField>> GetDataFields()
        {
            var results = await _db.DataFields.ToListAsync();
            return results;
        }
    }
}
