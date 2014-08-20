// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlItemAttribute.cs" company="Sergey Podolsky">
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
    /// Annotates field or property as deserializable
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class XmlItemAttribute : Attribute
    {
    }
}