using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Common
{
    public class ReadModel
    {
        public decimal Value { get; set; }
        public decimal TimeStamp { get; set; }
    }

    public class ReadModelList
    {
        public List<decimal> Values { get; set; } = new List<decimal>();
        public List<decimal> TimeStamps { get; set; } = new List<decimal>();
    }
}
