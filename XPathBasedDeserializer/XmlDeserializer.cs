// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlDeserializer.cs" company="Sergey Podolsky">
//   Copyright (c) Sergey Podolsky. All rights reserved.
// </copyright>
// <summary>
//   AssemblyInfo.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XPathBasedDeserializer
{
    using System;
    using System.Xml.Linq;

    /// <summary>
    /// Deserializes objects from XML documents
    /// </summary>
    public class XmlDeserializer
    {
        /// <summary>
        /// Type of the object to deserialize
        /// </summary>
        private readonly Type type;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlDeserializer"/> class.
        /// </summary>
        /// <param name="type">Type of the object to deserialize</param>
        public XmlDeserializer(Type type)
        {
            this.type = type;
        }

        /// <summary>
        /// Deserializes object from XML accessible by given URI
        /// </summary>
        /// <param name="xmlUri">URI of the XML to deserialize from</param>
        /// <returns>Deserialized object</returns>
        public virtual object Deserialize(Uri xmlUri)
        {
            object obj = null;
            this.Deserialize(xmlUri, ref obj);
            return obj;
        }

        /// <summary>
        /// Deserializes object from XML accessible by given URI
        /// </summary>
        /// <param name="xmlUri">URI of the XML to deserialize from</param>
        /// <param name="obj">Object instance to deserialize</param>
        public virtual void Deserialize(Uri xmlUri, ref object obj)
        {
            this.Deserialize(XDocument.Load(xmlUri.AbsoluteUri), ref obj);
        }

        /// <summary>
        /// Deserializes object from XML
        /// </summary>
        /// <param name="xml">XML to deserialize from</param>
        /// <returns>Deserialized object</returns>
        public virtual object Deserialize(string xml)
        {
            object obj = null;
            this.Deserialize(xml, ref obj);
            return obj;
        }

        /// <summary>
        /// Deserializes object from XML
        /// </summary>
        /// <param name="xml">XML to deserialize from</param>
        /// <param name="obj">Object instance to deserialize</param>
        public virtual void Deserialize(string xml, ref object obj)
        {
            this.Deserialize(XDocument.Parse(xml), ref obj);
        }

        /// <summary>
        /// Deserializes object from <see cref="XDocument"/>
        /// </summary>
        /// <param name="document">XML to deserialize from</param>
        /// <returns>Deserialized object</returns>
        public virtual object Deserialize(XDocument document)
        {
            object obj = null;
            this.Deserialize(document, ref obj);
            return obj;
        }

        /// <summary>
        /// Deserializes object from <see cref="XDocument"/>
        /// </summary>
        /// <param name="document">XML to deserialize from</param>
        /// <param name="obj">Object instance to deserialize</param>
        public virtual void Deserialize(XDocument document, ref object obj)
        {
            this.Deserialize(document.Root, ref obj);
        }

        /// <summary>
        /// Deserializes object from <see cref="XElement"/>
        /// </summary>
        /// <param name="element">XML to deserialize from</param>
        /// <returns>Deserialized object</returns>
        public virtual object Deserialize(XElement element)
        {
            object obj = null;
            this.Deserialize(element, ref obj);
            return obj;
        }

        /// <summary>
        /// Deserializes object from <see cref="XElement"/>
        /// </summary>
        /// <param name="element">XML to deserialize from</param>
        /// <param name="obj">Object instance to deserialize</param>
        public virtual void Deserialize(XElement element, ref object obj)
        {
            var objectConverter = new ObjectConverter(this.type);
            objectConverter.Convert(element, ref obj);
        }
    }
}