// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeTree.cs" company="Sergey Podolsky">
//   Copyright (c) Sergey Podolsky. All rights reserved.
// </copyright>
// <summary>
//   Defines the TypeTree type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XPathBasedDeserializer
{
    using System;

    /// <summary>
    /// Contains type inheritance hierarchy
    /// </summary>
    /// <typeparam name="T">Type of the data associated data with each type in the hierarchy</typeparam>
    internal class TypeTree<T>
    {
        /// <summary>
        /// Adds given type with associated data into the type hierarchy
        /// </summary>
        /// <param name="type">Type to insert</param>
        /// <param name="data">Associated data</param>
        public void Add(Type type, T data)
        {
        }

        /// <summary>
        /// Gets data associated with given type or with the nearest parent type in the hierarchy
        /// </summary>
        /// <param name="type">Type of the hierarchy</param>
        /// <returns>Associated data</returns>
        public T GetNearestParent(Type type)
        {
            return default(T);
        }
    }
}