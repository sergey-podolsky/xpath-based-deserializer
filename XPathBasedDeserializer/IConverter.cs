// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConverter.cs" company="Sergey Podolsky">
//   Copyright (c) Sergey Podolsky. All rights reserved.
// </copyright>
// <summary>
//   Defines the IConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XPathBasedDeserializer
{
    using System.Xml.Linq;

    /// <summary>
    /// Converts XPath query result to object
    /// </summary>
    public interface IConverter
    {
        /// <summary>
        /// Converts result of XPath query evaluation to object of target type
        /// </summary>
        /// <param name="obj">Object to convert to</param>
        void Convert(XNode node, XmlDeserializableAttribute attribute, string name, ref object obj);
    }
}