using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using NerdStore.Core.Data.EventSourcing;
using NerdStore.Core.Messages;
using Newtonsoft.Json;

namespace EventSourcing
{
    public class EventSourcingRepository : IEventSourcingRepository
    {
        private readonly IEventStoreService _eventStoreService;

        public EventSourcingRepository(IEventStoreService eventStoreService)
        {
            _eventStoreService = eventStoreService;
        }

        public async Task SalvarEvento<TEvent>(TEvent evento) where TEvent : Event
        {
            //var conn = _eventStoreService.GetConnection();
            //await conn.AppendToStreamAsync(
            //    evento.AggregateId.ToString(),
            //    ExpectedVersion.Any,
            //    FormatarEvento(evento));


            //ERRO - TRATAMENTO TEMPORARIO
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<StoredEvent>> ObterEventos(Guid aggregateId)
        {
            //var eventos = await _eventStoreService.GetConnection()
            //    .ReadStreamEventsForwardAsync(aggregateId.ToString(), 0, 500, false);

            //var listaEventos = new List<StoredEvent>();

            //foreach (var resolvedEvent in eventos.Events)
            //{
            //    var dataEncoded = Encoding.UTF8.GetString(resolvedEvent.Event.Data);
            //    var jsonData = JsonConvert.DeserializeObject<BaseEvent>(dataEncoded);

            //    var evento = new StoredEvent(
            //        resolvedEvent.Event.EventId,
            //        resolvedEvent.Event.EventType,
            //        jsonData.Timestamp,
            //        dataEncoded);

            //    listaEventos.Add(evento);
            //}
            //return listaEventos.OrderBy(e => e.DataOcorrencia);

            
            //ERRO - TRATAMENTO TEMPORARIO (MOCK)
            var listaEventos = new List<StoredEvent>();

            for (int i = 0; i < 7; i++)
            {
                var evento = new StoredEvent(
                    Guid.NewGuid(),
                    "TipoEvento",
                    DateTime.Now,
                    "Object Data: " + i.ToString());

                listaEventos.Add(evento);
            }
            return listaEventos.OrderBy(e => e.DataOcorrencia);
        }

        private static IEnumerable<EventData> FormatarEvento<TEvent>(TEvent evento) where TEvent : Event
        {
            var eventoFormatado = new EventData(
                Guid.NewGuid(),
                evento.MessageType,
                true,
                Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(evento)),
                null);
            yield return eventoFormatado;
        }
    }

    internal class BaseEvent
    {
        public DateTime Timestamp { get; set; }
    }
}