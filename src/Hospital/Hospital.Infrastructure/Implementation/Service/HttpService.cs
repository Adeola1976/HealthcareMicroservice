using Hospital.Application.Interface.Service;
using Hospital.Domain.DTOs.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Infrastructure.Implementation.Service
{
    public  class HttpService : IHttpService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ILogger<HttpService> _logger;

        public HttpService(IHttpClientFactory clientFactory, IConfiguration configuration,
            IHttpContextAccessor httpContext, ILogger<HttpService> logger)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
            _httpContext = httpContext;
            _logger = logger;
        }

        public async Task<T> SendPostRequest<T, U>(PostRequest<U> request)
        {
            var client = _clientFactory.CreateClient();
            var message = new HttpRequestMessage();
            message.RequestUri = new Uri(request.Url);
            message.Method = HttpMethod.Post;
            message.Headers.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Clear();
            //client.DefaultRequestHeaders.Add("X-CID", clientSecretKey);
            var data = JsonConvert.SerializeObject(request.Data);
            _logger.LogInformation("Sending POST request to {Url} with Body {data}", message.RequestUri, data);
            message.Content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.SendAsync(message);
            var content = await response.Content.ReadAsStringAsync();
            _logger.LogInformation("Response from {Url} is {response}", message.RequestUri, content);
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
