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
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;

    internal class ObjectConverter : XmlEntryConverter
    {
        private Type type;

        public ObjectConverter(Type type)
        {
            this.type = type;
        }

        public override void Convert(object xpathEvaluateResult, ref object obj)
        {
            obj = obj ?? Activator.CreateInstance(this.type);
            var node = (XNode)xpathEvaluateResult;
            var properties = this.type.GetProperties();
            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(typeof(XmlDeserializableAttribute), false);
                if (attributes.Any())
                {
                    object nestedObj = property.GetValue(obj, null);
                    new StringConverter().Convert(node, (XmlDeserializableAttribute)attributes.Single(), property.Name, ref nestedObj);
                    property.SetValue(obj, nestedObj, null);
                }
            }
        }
    }
}