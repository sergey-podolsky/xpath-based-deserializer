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

        public void Convert(object xpathResult, ref object obj)
        {
            obj = obj ?? Activator.CreateInstance(this.type);
            var element = (XElement)xpathResult;

            var properties = this.type.GetProperties();
            foreach (var propertyInfo in properties)
            {
                var attributes = propertyInfo.GetCustomAttributes(typeof(XmlItemAttribute), false);
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