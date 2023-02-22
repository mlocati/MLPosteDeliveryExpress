using System;
using System.Collections.Generic;
using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public abstract class DeliveryToNode<T> : ServiceWithStringParameters<T> where T : class, IService
    {
        public readonly string Node;

        public readonly string NodeName;

        protected DeliveryToNode(string node, string nodeName)
        {
            if (node.Trim().Length == 0)
            {
                throw new ArgumentNullException(nameof(node));
            }
            this.Node = node;
            this.NodeName = nodeName;
        }

#pragma warning disable IDE0060 // Remove unused parameter
        public void Serialize(Utf8JsonWriter writer, JsonSerializerOptions options)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            this.WriteDictionary(
                writer,
                new KeyValuePair<string, string>("node", this.Node),
                new KeyValuePair<string, string>("name", this.NodeName)
            );
        }

        protected static string[] UnserializeValue(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            var dictionary = ReadDictionary(ref reader, options);
            var node = dictionary.Pop("node");
            var nodeName = dictionary.Pop("name");
            dictionary.CheckEmpty();
            return new[] { node, nodeName };
        }

        public abstract bool Equals(T other);

        public bool Equals(IService? other)
        {
            if (other is not T sameClassOther)
            {
                return false;
            }
            return this.Equals(sameClassOther);
        }
    }
}