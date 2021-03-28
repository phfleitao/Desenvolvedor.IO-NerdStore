using EventStore.ClientAPI;
using Microsoft.Extensions.Configuration;
using System;

namespace EventSourcing
{
    public class EventStoreService : IEventStoreService
    {
        private readonly IEventStoreConnection _connection;

        public EventStoreService(IConfiguration configuration)
        {
            //ERRO NA VERSÃO DO EVENT STORE
            //_connection = EventStoreConnection.Create(configuration.GetConnectionString("EventStoreConnection"));
            //_connection.ConnectAsync();
        }

        public IEventStoreConnection GetConnection()
        {
            return _connection;
        }
    }
}