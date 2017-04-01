// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 04-01-2017
// ***********************************************************************
// <copyright file="ModelResolver.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace KSP_To_Boldly_Go.Common.Models
{
    /// <summary>
    /// Class ModelManager.
    /// </summary>
    public static class ModelManager
    {
        #region Fields

        /// <summary>
        /// The model namespace
        /// </summary>
        private static readonly string modelNamespace = typeof(ModelManager).Namespace;

        /// <summary>
        /// The root objects
        /// </summary>
        private static List<string> rootObjects = null;

        #endregion Fields

        #region Methods

        /// <summary>
        /// Gets the type of the kopernicus object from.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>IKopernicusObject.</returns>
        public static IKopernicusObject GetKopernicusObjectFromType(string type)
        {
            var className = string.Format("{0}.{1}", modelNamespace, type);
            var instance = (IKopernicusObject)Activator.CreateInstance(Type.GetType(className));
            instance.ShowInternalProperties = true;
            instance.Type = type;
            return instance;
        }

        /// <summary>
        /// Gets the kopernius object from json.
        /// </summary>
        /// <param name="jsonContent">Content of the json.</param>
        /// <returns>IKopernicusObject.</returns>
        public static IKopernicusObject GetKoperniusObjectFromJson(string jsonContent)
        {
            if (!string.IsNullOrWhiteSpace(jsonContent))
            {
                var obj = JsonConvert.DeserializeObject<KopernicusInfo>(jsonContent);
                if (obj != null)
                {
                    var className = string.Format("{0}.{1}", modelNamespace, obj.Type);
                    var result = (IKopernicusObject)JsonConvert.DeserializeObject(jsonContent, Type.GetType(className));
                    result.ShowInternalProperties = true;
                    return result;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the list of kopernicus objects.
        /// </summary>
        /// <returns>List&lt;System.String&gt;.</returns>
        public static List<string> GetListOfKopernicusObjects()
        {
            if (rootObjects == null)
            {
                var objects = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IKopernicusRootObject))).ToList();
                rootObjects = objects.OrderBy(p => ((ObjectOrderAttribute)p.GetCustomAttribute(typeof(ObjectOrderAttribute), true)).Order).Select(p => p.Name).ToList();
            }
            return rootObjects;
        }

        #endregion Methods
    }
}