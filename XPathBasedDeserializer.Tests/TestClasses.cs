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
        [XmlDeserializable]
        internal struct EmptyStruct
        {    
        }

        [XmlDeserializable]
        internal struct StructWithTwoProperties
        {
            public StructWithTwoProperties(string property1, string property2) : this()
            {
                this.Property1 = property1;
                this.Property2 = property2;
            }

            [XmlItem]
            public string Property1 { get; private set; }

            [XmlItem]
            public string Property2 { get; private set; }
        }

        [XmlDeserializable]
        internal class EmptyClass
        {
        }

        [XmlDeserializable]
        internal class ClassWithProperty
        {
            [XmlItem]
            public string Property { get; protected set; }
        }
    }
}