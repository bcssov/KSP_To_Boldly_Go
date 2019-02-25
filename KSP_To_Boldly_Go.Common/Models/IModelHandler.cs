// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 02-25-2019
//
// Last Modified By : Mario
// Last Modified On : 02-25-2019
// ***********************************************************************
// <copyright file="IModelHandler.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

namespace KSP_To_Boldly_Go.Common.Models
{
    /// <summary>
    /// Interface IModelHandler
    /// </summary>
    public interface IModelHandler
    {
        #region Methods

        /// <summary>
        /// Creates the collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>T.</returns>
        T CreateCollection<T>() where T : IEnumerable<IKopernicusObject>;

        /// <summary>
        /// Creates the collection.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>IEnumerable&lt;IKopernicusObject&gt;.</returns>
        IEnumerable<IKopernicusObject> CreateCollection(Type type);

        /// <summary>
        /// Creates the model.
        /// </summary>
        /// <param name="typeName">Name of the type.</param>
        /// <returns>IKopernicusObject.</returns>
        IKopernicusObject CreateModel(string typeName);

        /// <summary>
        /// Creates the model.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>IKopernicusObject.</returns>
        IKopernicusObject CreateModel(Type type);

        /// <summary>
        /// Creates the model.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>T.</returns>
        T CreateModel<T>() where T : IKopernicusObject;

        /// <summary>
        /// Creates the model from json.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns>IKopernicusObject.</returns>
        IKopernicusObject CreateModelFromJSON(string json);

        /// <summary>
        /// Gets the ordered root object names.
        /// </summary>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        IEnumerable<string> GetOrderedRootObjectNames();

        #endregion Methods
    }
}