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
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
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
            var element = new XElement("EmptyClass");

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
            var element = new XElement("EmptyStruct");

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
            var element = XElement.Parse("<ClassWithProperty><Property>value</Property></ClassWithProperty>");

            // Act
            var xmlDeserializer = new XmlDeserializer();
            var obj = xmlDeserializer.Deserialize<TestClasses.ClassWithProperty>(element);

            // Assert
            Assert.AreEqual("value", obj.Property);
        }

        public void DeserializesFromXDocument()
        {
            // Arrange
            var document = XDocument.Parse("<ClassWithProperty><Property>value</Property></ClassWithProperty>");

            // Act
            var xmlDeserializer = new XmlDeserializer();
            var obj = xmlDeserializer.Deserialize<TestClasses.ClassWithProperty>(document);

            // Assert
            Assert.AreEqual("value", obj.Property);
        }

        [TestMethod]
        public void DeserializesFromXml()
        {
            // Arrange
            const string Xml = "<ClassWithProperty><Property>value</Property></ClassWithProperty>";

            // Act
            var xmlDeserializer = new XmlDeserializer();
            var obj = xmlDeserializer.Deserialize<TestClasses.ClassWithProperty>(Xml);

            // Assert
            Assert.AreEqual("value", obj.Property);
        }

        [TestMethod]
        public void DeserializesFromUri()
        {
            // Arrange
            var xmlPath = Path.GetFullPath("TestXmlFiles/ClassWithProperty.xml");
            var xmlUri = new Uri(xmlPath);

            // Act
            var xmlDeserializer = new XmlDeserializer();
            var obj = xmlDeserializer.Deserialize<TestClasses.ClassWithProperty>(xmlUri);

            // Assert
            Assert.AreEqual("value", obj.Property);
        }
    }
}