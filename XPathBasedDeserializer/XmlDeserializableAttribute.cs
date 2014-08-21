// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlDeserializableAttribute.cs" company="Sergey Podolsky">
//   Copyright (c) Sergey Podolsky. All rights reserved.
// </copyright>
// <summary>
//   Defines the XmlDeserializableAttribute type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XPathBasedDeserializer
{
    using System;

    /// <summary>
    /// Base class for all project attributes
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public abstract class XmlDeserializableAttribute : Attribute
    {
    }
}