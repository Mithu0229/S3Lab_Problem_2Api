using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Common
{
    public class ReadPassModel
    {
        public int BuildingId { get; set; }
        public int PObjectId { get; set; }
        public int DataFieldId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
