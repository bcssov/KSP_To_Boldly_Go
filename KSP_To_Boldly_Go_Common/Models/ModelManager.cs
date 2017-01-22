// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go_Common
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 01-22-2017
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

namespace KSP_To_Boldly_Go_Common.Models
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

        #endregion Fields

        #region Methods

        /// <summary>
        /// Gets the type of the kopernicus object from.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        public static object GetKopernicusObjectFromType(string type)
        {
            var className = string.Format("{0}.{1}", modelNamespace, type);
            var instance = CreateKopernicusObject(Type.GetType(className));
            ((KopernicusObject)instance).ShowInternalProperties = true;
            ((KopernicusObject)instance).Type = type;
            return instance;
        }

        /// <summary>
        /// Gets the kopernius object model.
        /// </summary>
        /// <param name="jsonContent">Content of the json.</param>
        /// <returns>System.Object.</returns>
        public static object GetKoperniusObjectModel(string jsonContent)
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

        /// <summary>
        /// Gets the list of kopernicus object.
        /// </summary>
        /// <returns>List&lt;System.String&gt;.</returns>
        public static List<string> GetListOfKopernicusObject()
        {
            var objects = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IKopernicusObject)) && t.Name != "KopernicusObject").Select(p => p.Name).ToList();
            return objects;
        }

        /// <summary>
        /// Creates the kopernicus object.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        private static object CreateKopernicusObject(Type type)
        {
            var instance = Activator.CreateInstance(type);
            foreach (var property in type.GetProperties())
            {
                if (property.PropertyType.IsClass && !(property.PropertyType.IsPrimitive || property.PropertyType.Equals(typeof(string)) || property.PropertyType.Equals(typeof(DateTime))))
                {
                    var childInstance = CreateKopernicusObject(property.PropertyType);
                    property.SetValue(instance, childInstance);
                }
            }
            return instance;
        }

        #endregion Methods
    }
}