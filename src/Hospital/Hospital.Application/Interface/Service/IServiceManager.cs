﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Application.Interface.Service
{
    public interface IServiceManager
    {
        IHospitalService HospitalService { get; }
    }
}
