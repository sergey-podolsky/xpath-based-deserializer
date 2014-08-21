// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlDeserializer{T}.cs" company="Sergey Podolsky">
//   Copyright (c) Sergey Podolsky. All rights reserved.
// </copyright>
// <summary>
//   The generic xml.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XPathBasedDeserializer
{
    using System;
    using System.Xml.Linq;

    /// <summary>
    /// Deserializes objects from XML documents
    /// </summary>
    /// <typeparam name="T">Type of the object to deserialize</typeparam>
    public class XmlDeserializer<T>
    {
        /// <summary>
        /// Non-generic instance of <see cref="XmlDeserializer"/>
        /// </summary>
        private readonly XmlDeserializer xmlDeserializer = new XmlDeserializer(typeof(T));

        /// <summary>
        /// Deserializes object from XML accessible by given URI
        /// </summary>
        /// <param name="xmlUri">URI of the XML to deserialize from</param>
        /// <returns>Deserialized object</returns>
        public virtual T Deserialize(Uri xmlUri)
        {
            return (T)this.xmlDeserializer.Deserialize(xmlUri);
        }

        /// <summary>
        /// Deserializes object from XML accessible by given URI
        /// </summary>
        /// <param name="xmlUri">URI of the XML to deserialize from</param>
        /// <param name="obj">Object instance to deserialize</param>
        public virtual void Deserialize(Uri xmlUri, ref T obj)
        {
            object box = obj;
            this.xmlDeserializer.Deserialize(xmlUri, ref box);
            obj = (T)box;
        }

        /// <summary>
        /// Deserializes object from XML
        /// </summary>
        /// <param name="xml">XML to deserialize from</param>
        /// <returns>Deserialized object</returns>
        public virtual T Deserialize(string xml)
        {
            return (T)this.xmlDeserializer.Deserialize(xml);
        }

        /// <summary>
        /// Deserializes object from XML
        /// </summary>
        /// <param name="xml">XML to deserialize from</param>
        /// <param name="obj">Object instance to deserialize</param>
        public virtual void Deserialize(string xml, ref T obj)
        {
            object box = obj;
            this.xmlDeserializer.Deserialize(xml, ref box);
            obj = (T)box;
        }

        /// <summary>
        /// Deserializes object from <see cref="XDocument"/>
        /// </summary>
        /// <param name="document">XML to deserialize from</param>
        /// <returns>Deserialized object</returns>
        public virtual T Deserialize(XDocument document)
        {
            return (T)this.xmlDeserializer.Deserialize(document);
        }

        /// <summary>
        /// Deserializes object from <see cref="XDocument"/>
        /// </summary>
        /// <param name="document">XML to deserialize from</param>
        /// <param name="obj">Object instance to deserialize</param>
        public virtual void Deserialize(XDocument document, ref T obj)
        {
            object box = obj;
            this.xmlDeserializer.Deserialize(document, ref box);
            obj = (T)box;
        }

        /// <summary>
        /// Deserializes object from <see cref="XElement"/>
        /// </summary>
        /// <param name="element">XML to deserialize from</param>
        /// <returns>Deserialized object</returns>
        public virtual T Deserialize(XElement element)
        {
            return (T)this.xmlDeserializer.Deserialize(element);
        }

        /// <summary>
        /// Deserializes object from <see cref="XElement"/>
        /// </summary>
        /// <param name="element">XML to deserialize from</param>
        /// <param name="obj">Object instance to deserialize</param>
        public virtual void Deserialize(XElement element, ref T obj)
        {
            object box = obj;
            this.xmlDeserializer.Deserialize(element, ref box);
            obj = (T)box;
        }
    }
}