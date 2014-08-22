using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPathBasedDeserializer
{
    using System.Xml.Linq;
    using System.Xml.XPath;

    class StringConverter : XmlEntryConverter
    {
        public override void Convert(object source, ref object target)
        {
            target = ((XElement)source).Value;
        }
    }
}
