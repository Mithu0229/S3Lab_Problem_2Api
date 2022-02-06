using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entites
{
    public class Reading
    {
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public Building Building { get; set; }
        public int PObjectId { get; set; }
        public PObject PObject { get; set; }

        public int DataFieldId { get; set; }
        public DataField DataField { get; set; }

        public decimal Value { get; set; }
        public DateTime TimeStamp { get; set; }

    }
}
