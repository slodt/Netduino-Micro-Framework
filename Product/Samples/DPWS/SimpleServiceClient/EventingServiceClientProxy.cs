//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     .NET Micro Framework MFSvcUtil.Exe
//     Runtime Version:2.0.00001.0001
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System;
using System.Xml;
using Dpws.Client;
using Dpws.Client.Discovery;
using Dpws.Client.Eventing;
using Ws.Services;
using Ws.Services.Utilities;
using Ws.Services.Binding;
using Ws.Services.Soap;
using Ws.Services.WsaAddressing;
using Ws.Services.Xml;

namespace schemas.example.org.EventingService
{
    
    
    public class EventingServiceClientProxy : DpwsClient
    {
        
        private IEventingServiceCallback m_eventHandler = null;
        
        public DpwsServiceTypes EventSources = new DpwsServiceTypes();
        
        private IRequestChannel m_requestChannel = null;
        
        public EventingServiceClientProxy(Binding binding, ProtocolVersion version, IEventingServiceCallback callbackHandler) : 
                base(binding, version)
        {
            // Set the client callback implementation property
            m_eventHandler = callbackHandler;

            // Set client endpoint address
            m_requestChannel = m_localBinding.CreateClientChannel(new ClientBindingContext(m_version));

            // Add client callback operations and event source types
            ServiceOperations.Add(new WsServiceOperation("http://schemas.example.org/EventingService", "SimpleEvent"));
            EventSources.Add(new DpwsServiceType("SimpleEvent", "http://schemas.example.org/EventingService"));
            ServiceOperations.Add(new WsServiceOperation("http://schemas.example.org/EventingService", "IntegerEvent"));
            EventSources.Add(new DpwsServiceType("IntegerEvent", "http://schemas.example.org/EventingService"));

            // Add eventing SubscriptionEnd ServiceOperations. By default Subscription End call back to this client
            ServiceOperations.Add(new WsServiceOperation(WsWellKnownUri.WseNamespaceUri, "SubscriptionEnd"));

            this.StartEventListeners();
        }
        
        public virtual WsMessage SimpleEvent(WsMessage request)
        {
            // Build request object
            SimpleEventRequestDataContractSerializer reqDcs;
            reqDcs = new SimpleEventRequestDataContractSerializer("SimpleEventRequest", "http://schemas.example.org/EventingService");
            SimpleEventRequest req;
            req = ((SimpleEventRequest)(reqDcs.ReadObject(request.Reader)));
            request.Reader.Dispose();
            request.Reader = null;

            // Call service operation to process request.
            m_eventHandler.SimpleEvent(req);

            // Return OneWayResponse message for event callback messages
            return WsMessage.CreateOneWayResponse();
        }
        
        public virtual WsMessage IntegerEvent(WsMessage request)
        {
            // Build request object
            IntegerEventRequestDataContractSerializer reqDcs;
            reqDcs = new IntegerEventRequestDataContractSerializer("IntegerEventRequest", "http://schemas.example.org/EventingService");
            IntegerEventRequest req;
            req = ((IntegerEventRequest)(reqDcs.ReadObject(request.Reader)));
            request.Reader.Dispose();
            request.Reader = null;

            // Call service operation to process request.
            m_eventHandler.IntegerEvent(req);

            // Return OneWayResponse message for event callback messages
            return WsMessage.CreateOneWayResponse();
        }
    }
}
