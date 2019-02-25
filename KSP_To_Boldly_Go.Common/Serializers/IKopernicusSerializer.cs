// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 02-24-2019
//
// Last Modified By : Mario
// Last Modified On : 02-24-2019
// ***********************************************************************
// <copyright file="IKopernicusSerializer.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.IO;
using KSP_To_Boldly_Go.Common.Models;

namespace KSP_To_Boldly_Go.Common.Serializers
{
    /// <summary>
    /// Interface IKopernicusSerializer
    /// </summary>
    public interface IKopernicusSerializer
    {
        #region Properties

        /// <summary>
        /// Gets or sets the seed.
        /// </summary>
        /// <value>The seed.</value>
        int Seed { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Serializes the specified object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <param name="serializationStream">The serialization stream.</param>
        void Serialize<T>(T obj, Stream serializationStream) where T : IKopernicusObject;

        #endregion Methods
    }
}