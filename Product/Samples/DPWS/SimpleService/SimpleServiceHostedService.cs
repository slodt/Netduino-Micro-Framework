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
using System.Text;
using System.Xml;
using Dpws.Device;
using Dpws.Device.Services;
using Ws.Services;
using Ws.Services.WsaAddressing;
using Ws.Services.Xml;
using Ws.Services.Binding;
using Ws.Services.Soap;

namespace schemas.example.org.SimpleService
{
    
    
    public class SimpleService : DpwsHostedService
    {
        
        private ISimpleService m_service;
        
        public SimpleService(ISimpleService service, ProtocolVersion version) : 
                base(version)
        {
            // Set the service implementation properties
            m_service = service;

            // Set base service properties
            ServiceNamespace = new WsXmlNamespace("sim", "http://schemas.example.org/SimpleService");
            ServiceID = "urn:uuid:5b0dd589-9f8c-4c23-b797-01ca3092b1ed";
            ServiceTypeName = "SimpleService";

            // Add service types here
            ServiceOperations.Add(new WsServiceOperation("http://schemas.example.org/SimpleService", "OneWay"));
            ServiceOperations.Add(new WsServiceOperation("http://schemas.example.org/SimpleService", "TwoWay"));
            ServiceOperations.Add(new WsServiceOperation("http://schemas.example.org/SimpleService", "TypeCheck"));
            ServiceOperations.Add(new WsServiceOperation("http://schemas.example.org/SimpleService", "AnyCheck"));

            // Add event sources here
        }
        
        public virtual WsMessage OneWay(WsMessage request)
        {
            // Build request object
            OneWayRequestDataContractSerializer reqDcs;
            reqDcs = new OneWayRequestDataContractSerializer("OneWayRequest", "http://schemas.example.org/SimpleService");
            OneWayRequest req;
            req = ((OneWayRequest)(reqDcs.ReadObject(request.Reader)));
            request.Reader.Dispose();
            request.Reader = null;

            // Call service operation to process request.
            m_service.OneWay(req);

            // Return a OneWayResponse message for oneway messages
            return WsMessage.CreateOneWayResponse();
        }
        
        public virtual WsMessage TwoWay(WsMessage request)
        {
            // Build request object
            TwoWayRequestDataContractSerializer reqDcs;
            reqDcs = new TwoWayRequestDataContractSerializer("TwoWayRequest", "http://schemas.example.org/SimpleService");
            TwoWayRequest req;
            req = ((TwoWayRequest)(reqDcs.ReadObject(request.Reader)));
            request.Reader.Dispose();
            request.Reader = null;

            // Create response object
            // Call service operation to process request and return response.
            TwoWayResponse resp;
            resp = m_service.TwoWay(req);

            // Create response header
            WsWsaHeader respHeader = new WsWsaHeader("http://schemas.example.org/SimpleService/TwoWayResponse", request.Header.MessageID, m_version.AnonymousUri, null, null, null);
            WsMessage response = new WsMessage(respHeader, resp, WsPrefix.Wsdp);

            // Create response serializer
            TwoWayResponseDataContractSerializer respDcs;
            respDcs = new TwoWayResponseDataContractSerializer("TwoWayResponse", "http://schemas.example.org/SimpleService");
            response.Serializer = respDcs;
            return response;
        }
        
        public virtual WsMessage TypeCheck(WsMessage request)
        {
            // Build request object
            TypeCheckRequestDataContractSerializer reqDcs;
            reqDcs = new TypeCheckRequestDataContractSerializer("TypeCheckRequest", "http://schemas.example.org/SimpleService");
            TypeCheckRequest req;
            req = ((TypeCheckRequest)(reqDcs.ReadObject(request.Reader)));
            request.Reader.Dispose();
            request.Reader = null;

            // Create response object
            // Call service operation to process request and return response.
            TypeCheckResponse resp;
            resp = m_service.TypeCheck(req);

            // Create response header
            WsWsaHeader respHeader = new WsWsaHeader("http://schemas.example.org/SimpleService/TypeCheckResponse", request.Header.MessageID, m_version.AnonymousUri, null, null, null);
            WsMessage response = new WsMessage(respHeader, resp, WsPrefix.Wsdp);

            // Create response serializer
            TypeCheckResponseDataContractSerializer respDcs;
            respDcs = new TypeCheckResponseDataContractSerializer("TypeCheckResponse", "http://schemas.example.org/SimpleService");
            response.Serializer = respDcs;
            return response;
        }
        
        public virtual WsMessage AnyCheck(WsMessage request)
        {
            // Build request object
            AnyCheckRequestDataContractSerializer reqDcs;
            reqDcs = new AnyCheckRequestDataContractSerializer("AnyCheckRequest", "http://schemas.example.org/SimpleService");
            AnyCheckRequest req;
            req = ((AnyCheckRequest)(reqDcs.ReadObject(request.Reader)));
            request.Reader.Dispose();
            request.Reader = null;

            // Create response object
            // Call service operation to process request and return response.
            AnyCheckResponse resp;
            resp = m_service.AnyCheck(req);

            // Create response header
            WsWsaHeader respHeader = new WsWsaHeader("http://schemas.example.org/SimpleService/AnyCheckResponse", request.Header.MessageID, m_version.AnonymousUri, null, null, null);
            WsMessage response = new WsMessage(respHeader, resp, WsPrefix.Wsdp);

            // Create response serializer
            AnyCheckResponseDataContractSerializer respDcs;
            respDcs = new AnyCheckResponseDataContractSerializer("AnyCheckResponse", "http://schemas.example.org/SimpleService");
            response.Serializer = respDcs;
            return response;
        }
    }
}
