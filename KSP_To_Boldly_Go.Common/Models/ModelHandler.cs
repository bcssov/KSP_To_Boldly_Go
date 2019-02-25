// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 02-25-2019
//
// Last Modified By : Mario
// Last Modified On : 02-25-2019
// ***********************************************************************
// <copyright file="ModelHandler.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace KSP_To_Boldly_Go.Common.Models
{
    /// <summary>
    /// Class ModelHandler.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Common.Models.IModelHandler" />
    public class ModelHandler : IModelHandler
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelHandler"/> class.
        /// </summary>
        /// <param name="kopernicusObjects">The kopernicus objects.</param>
        /// <param name="kopernicusRootObjects">The kopernicus root objects.</param>
        public ModelHandler(IEnumerable<IKopernicusObject> kopernicusObjects, IEnumerable<IKopernicusRootObject> kopernicusRootObjects)
        {
            KopernicusObjects = kopernicusObjects;
            KopernicusRootObjects = kopernicusRootObjects;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the kopernicus objects.
        /// </summary>
        /// <value>The kopernicus objects.</value>
        protected IEnumerable<IKopernicusObject> KopernicusObjects { get; set; }

        /// <summary>
        /// Gets or sets the kopernicus root objects.
        /// </summary>
        /// <value>The kopernicus root objects.</value>
        protected IEnumerable<IKopernicusRootObject> KopernicusRootObjects { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Creates the collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>T.</returns>
        public T CreateCollection<T>() where T : IEnumerable<IKopernicusObject> => (T)CreateCollection(typeof(T));

        /// <summary>
        /// Creates the collection.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>IEnumerable&lt;IKopernicusObject&gt;.</returns>
        /// <exception cref="ArgumentException">Invalid type.</exception>
        public IEnumerable<IKopernicusObject> CreateCollection(Type type)
        {
            if (!typeof(IEnumerable<IKopernicusObject>).IsAssignableFrom(type))
            {
                throw new ArgumentException("Invalid type.");
            }
            var genericArgs = type.GetGenericArguments().Single();
            var instance = Activator.CreateInstance(typeof(List<>).MakeGenericType(genericArgs));
            return (IEnumerable<IKopernicusObject>)instance;
        }

        /// <summary>
        /// Creates the model.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>T.</returns>
        public T CreateModel<T>() where T : IKopernicusObject => (T)CreateModel(typeof(T));

        /// <summary>
        /// Creates the model.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>IKopernicusObject.</returns>
        /// <exception cref="ArgumentException">Invalid type.</exception>
        public IKopernicusObject CreateModel(Type type)
        {
            if (!typeof(IKopernicusObject).IsAssignableFrom(type))
            {
                throw new ArgumentException("Invalid type.");
            }
            return (IKopernicusObject)DependencyInjection.DIContainer.Container.GetInstance(type);
        }

        /// <summary>
        /// Creates the model.
        /// </summary>
        /// <param name="typeName">Name of the type.</param>
        /// <returns>IKopernicusObject.</returns>
        public IKopernicusObject CreateModel(string typeName)
        {
            var type = KopernicusObjects.FirstOrDefault(p => p.GetType().Name == typeName).GetType();
            var instance = CreateModel(type);
            instance.ShowInternalProperties = true;
            instance.Type = typeName;
            return instance;
        }

        /// <summary>
        /// Creates the model from json.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns>IKopernicusObject.</returns>
        public IKopernicusObject CreateModelFromJSON(string json)
        {
            if (!string.IsNullOrWhiteSpace(json))
            {
                var obj = JsonConvert.DeserializeObject<KopernicusInfo>(json);
                if (obj != null)
                {
                    var type = KopernicusObjects.FirstOrDefault(p => p.GetType().Name == obj.Type).GetType();
                    var instance = (IKopernicusObject)JsonConvert.DeserializeObject(json, type);
                    instance.ShowInternalProperties = true;
                    return instance;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the ordered root object names.
        /// </summary>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        public IEnumerable<string> GetOrderedRootObjectNames()
        {
            return KopernicusRootObjects.OrderBy(p => ((ObjectOrderAttribute)p.GetType().GetCustomAttribute(typeof(ObjectOrderAttribute), true)).Order).Select(p => p.GetType().Name);
        }

        #endregion Methods
    }
}