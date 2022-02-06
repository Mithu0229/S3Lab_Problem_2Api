using Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public interface IBuildingService
    {
        Task<List<Building>> GetBuildings();
    }
}
