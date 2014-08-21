// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestClasses.cs" company="Sergey Podolsky">
//   Copyright (c) Sergey Podolsky. All rights reserved.
// </copyright>
// <summary>
//   AssemblyInfo.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XPathBasedDeserializer.Tests
{
    internal static class TestClasses
    {
        [XmlEntry]
        internal struct EmptyStruct
        {    
        }

        [XmlEntry]
        internal struct StructWithTwoProperties
        {
            public const string XmlFile = "TestXmlFiles/StructWithTwoProperties.xml";

            public StructWithTwoProperties(string property1, string property2) : this()
            {
                this.Property1 = property1;
                this.Property2 = property2;
            }

            [XmlEntry]
            public string Property1 { get; private set; }

            [XmlEntry]
            public string Property2 { get; private set; }
        }

        [XmlEntry]
        internal class EmptyClass
        {
        }
    }
}