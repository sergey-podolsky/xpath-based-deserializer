// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlDeserializerTests.cs" company="Sergey Podolsky">
//   Copyright (c) Sergey Podolsky. All rights reserved.
// </copyright>
// <summary>
//   AssemblyInfo.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XPathBasedDeserializer.Tests
{
    using System.Diagnostics.CodeAnalysis;
    using System.Xml.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Contains <see cref="XmlDeserializer"/> tests
    /// </summary>
    [TestClass]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not relevant for test methods")]
    public class XmlDeserializerTests
    {
        [TestMethod]
        public void DeserializesClass()
        {
            // Arrange
            var element = new XElement("root");

            // Act
            var xmlDeserializer = new XmlDeserializer();
            var obj = xmlDeserializer.Deserialize<TestClasses.EmptyClass>(element);

            // Assert
            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public void DeserializesStruct()
        {
            // Arrannge
            var element = new XElement("root");

            // Act
            var xmlDeserializer = new XmlDeserializer();
            var obj = xmlDeserializer.Deserialize<TestClasses.EmptyStruct>(element);

            // Assert
            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public void DeserializesFromXElement()
        {
            // Arrange
            var element = XElement.Parse("<root><StringProperty>content</StringProperty></root>");

            // Act
            var xmlDeserializer = new XmlDeserializer();
            var obj = xmlDeserializer.Deserialize<TestClasses.ClassWithStringPropertyWithoutXPath>(element);

            // Assert
            Assert.AreEqual("content", obj.StringProperty);
        }

        public void DeserializesFromXDocument()
        {
            // Arrange
            var document = XDocument.Parse("<root><StringProperty>content</StringProperty></root>");

            // Act
            var xmlDeserializer = new XmlDeserializer();
            var obj = xmlDeserializer.Deserialize<TestClasses.ClassWithStringPropertyWithoutXPath>(document);

            // Assert
            Assert.AreEqual("content", obj.StringProperty);
        }

        [TestMethod]
        public void VerifiesXmlRoot()
        {
            // TODO: Add root property to XmlDeserializable
            Assert.Fail();
        }
    }
}