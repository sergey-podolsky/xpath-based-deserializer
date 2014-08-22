using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPathBasedDeserializer
{
    using System.Xml.Linq;
    using System.Xml.XPath;

    public abstract class XmlEntryConverter : IConverter
    {
        public void Convert(XNode node, XmlDeserializableAttribute attribute, string name, ref object obj)
        {
            var result = node.XPathEvaluate(name);
            if (result == null)
            {
                throw new Exception("XPath query returned null");
            }

            var objects = result as IEnumerable<object>;
            if (objects.Any())
            {
                object value = objects != null ? objects.Single() : result;
                this.Convert(value, ref obj);
            }
        }

        public abstract void Convert(object source, ref object target);
    }
}
