﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Utility
{
    public class GenericResponse<T>
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public bool IsSuccessful { get; set; }
        public T Data { get; set; }
    }
}
