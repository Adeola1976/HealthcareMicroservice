using Microsoft.Extensions.Configuration;
using Hospital.Application.Interface.Service;
using Hospital.Domain.DTOs.Request;
using Microsoft.AspNetCore.Connections;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Hospital.Infrastructure.Implementation.Service
{
    public class MessageBusClient : IMessageBusClient
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<MessageBusClient> _logger;
        private IConnection _connection;
        private IModel _channel;

        public MessageBusClient(IConfiguration configuration, ILogger<MessageBusClient> logger)
        {
            try
            {
                _configuration = configuration;
                _logger = logger;
                InitialRabbitMQ();
            }

            catch(Exception ex) 
            {
                _logger.LogError($"Error occurred while connecting to a message bus. ERR MESSAGE {ex.Message}");
                Console.WriteLine($"Error occurred while connecting to a message bus. ERR MESSAGE {ex.Message}");
            }
           
        }

        private void InitialRabbitMQ()
        {
            var factory = new ConnectionFactory()
            {
                HostName = $"{_configuration.GetSection("RabbitMq")["Host"]}",
                Port = int.Parse($"{_configuration.GetSection("RabbitMq")["Port"]}")
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: $"{_configuration.GetSection("RabbitMq")["Exchange"]}", type: ExchangeType.Fanout);
            _connection.ConnectionShutdown += RabbitMQConnectionShutDown;
            _logger.LogError($"Connected to Rabbit MQ successfully");
            Console.WriteLine($"Connected to Rabbit MQ successfully");
        }
        public void PulishHospitalMessage(HospitalPublishedDto hospitalPublishedDto)
        {
            var message = JsonSerializer.Serialize(hospitalPublishedDto);
            if(_channel.IsOpen)
            {
                SendMessage(message);
              //  Dispose();
            }


        }

        private void RabbitMQConnectionShutDown(object sender, ShutdownEventArgs e)
        {
            _logger.LogError($"Rabbit MQ  server connection is being shut down");
            Console.WriteLine($"Rabbit MQ  server connection is being shut down");
        }

        private void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: $"{_configuration.GetSection("RabbitMq")["Exchange"]}",
                                   routingKey:"",
                                   basicProperties:null,
                                   body: body);
            _logger.LogError($"Your Message is being sent to the message bus");
            Console.WriteLine($"Your Message is being sent to the message bus");
        }

        private void Dispose()
        {
            _logger.LogError($"Dispose our connection");
            Console.WriteLine($"Dispose our connection");
            if (_channel.IsOpen)
            {
                _channel.Close();
            }
        }
    }
}
