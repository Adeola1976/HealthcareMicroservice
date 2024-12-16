using Hospital.Domain.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Application.Interface.Service
{
    public interface  IHttpService
    {
        Task<T> SendPostRequest<T, U>(PostRequest<U> request);
    }
}
