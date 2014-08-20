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
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;

    /// <summary>
    /// Deserializes objects from XML documents.
    /// </summary>
    public class XmlDeserializer
    {
        /// <summary>
        /// Deserializes object from <see cref="XDocument"/>
        /// </summary>
        /// <typeparam name="T">Type of the object to deserialize</typeparam>
        /// <param name="document">XML to deserialize from</param>
        /// <returns>Deserialized object</returns>
        public T Deserialize<T>(XDocument document) where T : new()
        {
            return this.Deserialize<T>(document.Root);
        }

        /// <summary>
        /// Deserializes object from <see cref="XElement"/>
        /// </summary>
        /// <typeparam name="T">Type of the object to deserialize</typeparam>
        /// <param name="element">XML to deserialize from</param>
        /// <returns>Deserialized object</returns>
        public T Deserialize<T>(XElement element) where T : new()
        {
            var obj = new T();
            var properties = typeof(T).GetProperties();
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