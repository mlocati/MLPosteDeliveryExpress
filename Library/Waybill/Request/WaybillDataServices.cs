using MLPosteDeliveryExpress.Json.Converter;
using System.Collections.Generic;

namespace MLPosteDeliveryExpress.Waybill.Request
{
    [System.Text.Json.Serialization.JsonConverter(typeof(WaybillDataServicesConverter))]
    public class WaybillDataServices
    {
        private Dictionary<string, Services.IService> RegisteredServices = new();

        public WaybillDataServices()
        { }

        public void Add(params Services.IService[] services)
        {
            foreach (var service in services)
            {
                this.RegisteredServices.Add(service.Code, service);
            }
        }

        public bool Has(Services.IService service)
        {
            return this.RegisteredServices.ContainsKey(service.Code);
        }

        public void Remove(Services.IService service)
        {
            if (this.Has(service))
            {
                this.RegisteredServices.Remove(service.Code);
            }
        }

        public ICollection<Services.IService> GetAll()
        {
            return this.RegisteredServices.Values;
        }
    }
}