// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go_Common
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 01-20-2017
// ***********************************************************************
// <copyright file="ModelResolver.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;

namespace KSP_To_Boldly_Go_Common.Models
{
    /// <summary>
    /// Class ModelResolver.
    /// </summary>
    public static class ModelResolver
    {
        #region Fields

        /// <summary>
        /// The model namespace
        /// </summary>
        private static readonly string modelNamespace = typeof(ModelResolver).Namespace;

        #endregion Fields

        #region Methods

        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <param name="jsonContent">Content of the json.</param>
        /// <returns>System.Object.</returns>
        public static object GetModel(string jsonContent)
        {
            if (!string.IsNullOrWhiteSpace(jsonContent))
            {
                var obj = JsonConvert.DeserializeObject<KopernicusObject>(jsonContent);
                if (obj != null)
                {
                    var className = string.Format("{0}.{1}", modelNamespace, obj.Type);
                    var result = JsonConvert.DeserializeObject(jsonContent, Type.GetType(className));
                    ((KopernicusObject)result).ShowInternalProperties = true;
                    return result;
                }
            }
            return null;
        }

        #endregion Methods
    }
}