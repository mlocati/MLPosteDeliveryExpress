using System;
using System.Collections.Generic;
using System.Linq;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class Service
    {
        private static readonly object Lock = new();

        public readonly Type Type;
        private readonly IService EmptyInstance;
        public string Code { get => this.EmptyInstance.Code; }
        public string Name { get => this.EmptyInstance.Name; }
        public ServiceFlags Flags { get => this.EmptyInstance.Flags; }

        private Service(Type type, IService emptyInstance)
        {
            this.Type = type;
            this.EmptyInstance = emptyInstance;
        }

        public IService Create(params object[] args)
        {
            var instance = Activator.CreateInstance(this.Type, args) as IService;
            if (instance == null)
            {
                throw new Exception("This shouldn't happen");
            }
            return instance;
        }

        private static IReadOnlyList<Service>? _all = null;

        public static IReadOnlyList<Service> All
        {
            get
            {
                if (Service._all == null)
                {
                    lock (Lock)
                    {
                        Service._all ??= new List<Service>(Service.Dictionary.Values).AsReadOnly();
                    }
                }
                return Service._all;
            }
        }

        public static Service? GetByCode(string code)
        {
            return Service.Dictionary.ContainsKey(code) ? Service.Dictionary[code] : null;
        }

        private static Dictionary<string, Service>? _dictionary = null;

        private static Dictionary<string, Service> Dictionary
        {
            get
            {
                if (Service._dictionary == null)
                {
                    lock (Lock)
                    {
                        Service._dictionary ??= Service.BuildDictionary();
                    }
                }
                return Service._dictionary;
            }
        }

        private static Dictionary<string, Service> BuildDictionary()
        {
            var dictionary = new Dictionary<string, Service>();
            var itype = typeof(IService);
            var types = itype.Assembly.GetTypes().Where(p => itype.IsAssignableFrom(p) && !p.IsAbstract && !p.IsInterface);
            foreach (var type in types)
            {
                if (Activator.CreateInstance(type, true) is not IService emptyInstance)
                {
                    throw new Exception($"The IService {type.Name} isn't actually an IService?");
                }
                var service = new Service(type, emptyInstance);
                if (dictionary.ContainsKey(service.Code))
                {
                    throw new Exception($"The IService {type.Name} and the IService {dictionary[service.Code].Type.Name} share the same code ({service.Code})");
                }
                dictionary.Add(service.Code, service);
            }
            return dictionary;
        }
    }
}