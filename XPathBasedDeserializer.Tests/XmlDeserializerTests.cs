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
    using System.IO;
    using System.Xml.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Contains <see cref="XmlDeserializer"/> tests
    /// </summary>
    [TestClass]
    public class XmlDeserializerTests
    {
        [TestMethod]
        public void DeserializesClass()
        {
            // Arrange
            var element = new XElement("EmptyClass");

            // Act
            var xmlDeserializer = new XmlDeserializer<TestClasses.EmptyClass>();
            var obj = xmlDeserializer.Deserialize(element);

            // Assert
            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public void DeserializesStruct()
        {
            // Arrannge
            var element = new XElement("EmptyStruct");

            // Act
            var xmlDeserializer = new XmlDeserializer<TestClasses.EmptyStruct>();
            var obj = xmlDeserializer.Deserialize(element);

            // Assert
            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public void DeserializesFromXElement()
        {
            // Arrange
            var element = XElement.Parse("<ClassWithProperty><Property>value</Property></ClassWithProperty>");

            // Act
            var xmlDeserializer = new XmlDeserializer<TestClasses.ClassWithProperty>();
            var obj = xmlDeserializer.Deserialize(element);

            // Assert
            Assert.AreEqual("value", obj.Property);
        }

        public void DeserializesFromXDocument()
        {
            // Arrange
            var document = XDocument.Parse("<ClassWithProperty><Property>value</Property></ClassWithProperty>");

            // Act
            var xmlDeserializer = new XmlDeserializer<TestClasses.ClassWithProperty>();
            var obj = xmlDeserializer.Deserialize(document);

            // Assert
            Assert.AreEqual("value", obj.Property);
        }

        [TestMethod]
        public void DeserializesFromXml()
        {
            // Arrange
            const string Xml = "<ClassWithProperty><Property>value</Property></ClassWithProperty>";

            // Act
            var xmlDeserializer = new XmlDeserializer<TestClasses.ClassWithProperty>();
            var obj = xmlDeserializer.Deserialize(Xml);

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
            var xmlDeserializer = new XmlDeserializer<TestClasses.ClassWithProperty>();
            var obj = xmlDeserializer.Deserialize(xmlUri);

            // Assert
            Assert.AreEqual("value", obj.Property);
        }
    }
}