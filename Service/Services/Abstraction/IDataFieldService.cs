﻿using Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public interface IDataFieldService
    {
       Task< List<DataField>> GetDataFields();
    }
}
