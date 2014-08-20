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
    using System.Diagnostics.CodeAnalysis;

    internal static class TestClasses
    {
        [XmlDeserializable]
        internal class EmptyClass
        {
        }

        [XmlDeserializable]
        internal class EmptyStruct
        {
        }

        [XmlDeserializable]
        internal class ClassWithStringPropertyWithoutXPath
        {
            [XmlItem]
            public string StringProperty { get; protected set; }
        }
    }
}