// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectConverter.cs" company="Sergey Podolsky">
//   Copyright (c) Sergey Podolsky. All rights reserved.
// </copyright>
// <summary>
//   Defines the ObjectConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XPathBasedDeserializer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;

    internal class ObjectConverter : IConverter
    {
        private Type type;

        public ObjectConverter(Type type)
        {
            this.type = type;
        }

        public void Convert(XContainer container, XmlDeserializableAttribute attribute, string name, ref object obj)
        {
            obj = obj ?? Activator.CreateInstance(this.type);
            var element = container.Element(name);

            var properties = this.type.GetProperties();
            foreach (var propertyInfo in properties)
            {
                var attributes = propertyInfo.GetCustomAttributes(typeof(XmlDeserializableAttribute), false);
                if (attributes.Any())
                {
                    var values = ((IEnumerable<object>)element.XPathEvaluate(propertyInfo.Name)).ToList();
                    if (values.Any())
                    {
                        var xelement = (XElement)values.Single();
                        var value = xelement.Value;
                        propertyInfo.SetValue(obj, value, null);
                    }
                }
            }
        }
    }
}