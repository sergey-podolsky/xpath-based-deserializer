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
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;

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
            return this.Deserialize(XDocument.Load(xmlUri.AbsoluteUri));
        }

        /// <summary>
        /// Deserializes object from XML
        /// </summary>
        /// <param name="xml">XML to deserialize from</param>
        /// <returns>Deserialized object</returns>
        public virtual object Deserialize(string xml)
        {
            return this.Deserialize(XDocument.Parse(xml));
        }

        /// <summary>
        /// Deserializes object from <see cref="XDocument"/>
        /// </summary>
        /// <param name="document">XML to deserialize from</param>
        /// <returns>Deserialized object</returns>
        public virtual object Deserialize(XDocument document)
        {
            return this.Deserialize(document.Root);
        }

        /// <summary>
        /// Deserializes object from <see cref="XElement"/>
        /// </summary>
        /// <param name="element">XML to deserialize from</param>
        /// <returns>Deserialized object</returns>
        public virtual object Deserialize(XElement element)
        {
            var obj = Activator.CreateInstance(this.type);
            var properties = this.type.GetProperties();
            foreach (var propertyInfo in properties)
            {
                var attributes = propertyInfo.GetCustomAttributes(typeof(XmlItemAttribute), false);
                if (attributes.Any())
                {
                    var evaluateIterator = (IEnumerable<object>)element.XPathEvaluate(propertyInfo.Name);
                    var xelement = (XElement)evaluateIterator.Single();
                    var value = xelement.Value;
                    propertyInfo.SetValue(obj, value, null);
                }
            }

            return obj;
        }
    }
}