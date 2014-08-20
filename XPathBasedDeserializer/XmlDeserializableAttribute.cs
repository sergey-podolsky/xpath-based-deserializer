// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlDeserializableAttribute.cs" company="Sergey Podolsky">
//   Copyright (c) Sergey Podolsky. All rights reserved.
// </copyright>
// <summary>
//   AssemblyInfo.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XPathBasedDeserializer
{
    using System;

    /// <summary>
    /// Annotates class as deserializable
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class XmlDeserializableAttribute : Attribute
    {
    }
}