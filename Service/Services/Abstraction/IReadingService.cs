using Data.Common;
using Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public interface IReadingService
    {
       List<ReadModel> GetReadings(ReadPassModel model);
    }
}
