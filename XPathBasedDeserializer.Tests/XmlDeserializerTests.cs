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
        public void DeserializesEmptyClass()
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
        public void DeserializesEmptyStruct()
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
            var xml = File.ReadAllText(TestClasses.StructWithTwoProperties.XmlFile);
            var element = XElement.Parse(xml);

            // Act
            var xmlDeserializer = new XmlDeserializer<TestClasses.StructWithTwoProperties>();
            var obj = xmlDeserializer.Deserialize(element);

            // Assert
            Assert.AreEqual("overridden", obj.Property1);
            Assert.IsNull(obj.Property2);
        }

        [TestMethod]
        public void DeserializesFromXElementExistingInstace()
        {
            // Arrange
            var xml = File.ReadAllText(TestClasses.StructWithTwoProperties.XmlFile);
            var element = XElement.Parse(xml);
            var obj = new TestClasses.StructWithTwoProperties("value1", "value2");

            // Act
            var xmlDeserializer = new XmlDeserializer<TestClasses.StructWithTwoProperties>();
            xmlDeserializer.Deserialize(element, ref obj);

            // Assert
            Assert.AreEqual("overridden", obj.Property1);
            Assert.AreEqual("value2", obj.Property2);
        }

        public void DeserializesFromXDocument()
        {
            // Arrange
            var xml = File.ReadAllText(TestClasses.StructWithTwoProperties.XmlFile);
            var document = XDocument.Parse(xml);

            // Act
            var xmlDeserializer = new XmlDeserializer<TestClasses.StructWithTwoProperties>();
            var obj = xmlDeserializer.Deserialize(document);

            // Assert
            Assert.AreEqual("overridden", obj.Property1);
            Assert.IsNull(obj.Property2);
        }

        public void DeserializesFromXDocumentExistingInstance()
        {
            // Arrange
            var xml = File.ReadAllText(TestClasses.StructWithTwoProperties.XmlFile);
            var document = XDocument.Parse(xml);
            var obj = new TestClasses.StructWithTwoProperties("value1", "value2");

            // Act
            var xmlDeserializer = new XmlDeserializer<TestClasses.StructWithTwoProperties>();
            xmlDeserializer.Deserialize(document, ref obj);

            // Assert
            Assert.AreEqual("overridden", obj.Property1);
            Assert.AreEqual("value2", obj.Property2);
        }

        [TestMethod]
        public void DeserializesFromXml()
        {
            // Arrange
            var xml = File.ReadAllText(TestClasses.StructWithTwoProperties.XmlFile);

            // Act
            var xmlDeserializer = new XmlDeserializer<TestClasses.StructWithTwoProperties>();
            var obj = xmlDeserializer.Deserialize(xml);

            // Assert
            Assert.AreEqual("overridden", obj.Property1);
            Assert.IsNull(obj.Property2);
        }

        [TestMethod]
        public void DeserializesFromXmlExistingInstance()
        {
            // Arrange
            var xml = File.ReadAllText(TestClasses.StructWithTwoProperties.XmlFile);
            var obj = new TestClasses.StructWithTwoProperties("value1", "value2");

            // Act
            var xmlDeserializer = new XmlDeserializer<TestClasses.StructWithTwoProperties>();
            xmlDeserializer.Deserialize(xml, ref obj);

            // Assert
            Assert.AreEqual("overridden", obj.Property1);
            Assert.AreEqual("value2", obj.Property2);
        }

        [TestMethod]
        public void DeserializesFromUri()
        {
            // Arrange
            var xmlPath = Path.GetFullPath("TestXmlFiles/StructWithTwoProperties.xml");
            var xmlUri = new Uri(xmlPath);

            // Act
            var xmlDeserializer = new XmlDeserializer<TestClasses.StructWithTwoProperties>();
            var obj = xmlDeserializer.Deserialize(xmlUri);

            // Assert
            Assert.AreEqual("overridden", obj.Property1);
            Assert.IsNull(obj.Property2);
        }

        [TestMethod]
        public void DeserializesFromUriExistingInstance()
        {
            // Arrange
            var xmlPath = Path.GetFullPath("TestXmlFiles/StructWithTwoProperties.xml");
            var xmlUri = new Uri(xmlPath);
            var obj = new TestClasses.StructWithTwoProperties("value1", "value2");

            // Act
            var xmlDeserializer = new XmlDeserializer<TestClasses.StructWithTwoProperties>();
            xmlDeserializer.Deserialize(xmlUri, ref obj);

            // Assert
            Assert.AreEqual("overridden", obj.Property1);
            Assert.AreEqual("value2", obj.Property2);
        }
    }
}