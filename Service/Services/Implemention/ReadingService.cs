using Data.Common;
using Data.Data;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ReadingService : IReadingService
    {
        private readonly ExmDBContext _db;
        public ReadingService(ExmDBContext db)
        {
            _db = db;
        }

        public  List<ReadModel> GetReadings(ReadPassModel model)
        {
            try
            {
                var buildings = _db.Readings.AsQueryable()
               .Where(x => x.BuildingId == model.BuildingId && x.PObjectId == model.PObjectId && x.DataFieldId == model.DataFieldId
                && x.TimeStamp >= model.FromDate && x.TimeStamp <= model.ToDate
                ).AsParallel();
                var result = buildings.Select(x => new ReadModel { Value = x.Value, TimeStamp = x.TimeStamp.Hour }).OrderBy(x=>x.TimeStamp).ToList();
                return result;
            }
            catch (Exception ex)
            {
                //log here
                throw;
            }
           
        }
    }
}
