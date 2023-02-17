using MLPosteDeliveryExpress.Json.Converter;
using System;
using System.Collections.Generic;

namespace MLPosteDeliveryExpress.Waybill.Request
{
    [System.Text.Json.Serialization.JsonConverter(typeof(WaybillDataServicesConverter))]
    public class WaybillDataServices : IEquatable<WaybillDataServices>
    {
        private readonly Dictionary<string, Services.IService> RegisteredServices = new();

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

        public bool Equals(WaybillDataServices? other)
        {
            if (other == null)
            {
                return false;
            }
            if (this.RegisteredServices.Count != other.RegisteredServices.Count)
            {
                return false;
            }
            foreach (var kv in this.RegisteredServices)
            {
                if (!other.RegisteredServices.ContainsKey(kv.Key))
                {
                    return false;
                }
                var otherService = other.RegisteredServices[kv.Key];
                if (!otherService.Equals(kv.Value))
                {
                    return false;
                }
            }

            return true;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as WaybillDataServices);
        }

        public override int GetHashCode()
        {
            return this.RegisteredServices.GetHashCode();
        }
    }
}