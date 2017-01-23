// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 01-23-2017
// ***********************************************************************
// <copyright file="KopernicusObject.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using KSP_To_Boldly_Go.Common.Extensions;
using KSP_To_Boldly_Go.Common.Serializers;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace KSP_To_Boldly_Go.Common.Models
{
    /// <summary>
    /// Class KopernicusObject.
    /// </summary>
    /// <seealso cref="System.ComponentModel.ICustomTypeDescriptor" />
    /// <seealso cref="KSP_To_Boldly_Go.Common.Models.IKopernicusObject" />
    public abstract class KopernicusObject : IKopernicusObject, ICustomTypeDescriptor
    {
        #region Fields

        /// <summary>
        /// The hide properties
        /// </summary>
        protected static readonly string[] hideProperties = new string[] { "Order", "Type", "ShowInternalProperties" };

        /// <summary>
        /// The show internal properties
        /// </summary>
        protected bool _showInternalProperties = false;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KopernicusObject"/> class.
        /// </summary>
        public KopernicusObject()
        {
            Initialize();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>The header.</value>
        [KopernicusSerializeIgnore]
        [Description("Kopernicus node header. Internal program property.")]
        public virtual string Header
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>The order.</value>
        [JsonProperty("$order")]
        [KopernicusSerializeIgnore]
        [Description("Determines in which order the config is serialized. Internal program property.")]
        public int Order
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show internal properties].
        /// </summary>
        /// <value><c>true</c> if [show internal properties]; otherwise, <c>false</c>.</value>
        [JsonIgnore]
        [KopernicusSerializeIgnore]
        public bool ShowInternalProperties
        {
            get
            {
                return _showInternalProperties;
            }
            set
            {
                _showInternalProperties = value;
            }
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("$objectType")]
        [KopernicusSerializeIgnore]
        [Description("Used to initialize correct type. Internal program property.")]
        [ReadOnly(true)]
        public string Type
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        protected abstract string GetObjectName();

        public override string ToString()
        {
            return string.IsNullOrWhiteSpace(Header) ? GetObjectName() : Header;
        }

        /// <summary>
        /// Returns a collection of custom attributes for this instance of a component.
        /// </summary>
        /// <returns>An <see cref="T:System.ComponentModel.AttributeCollection" /> containing the attributes for this object.</returns>
        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        /// <summary>
        /// Returns the class name of this instance of a component.
        /// </summary>
        /// <returns>The class name of the object, or null if the class does not have a name.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        /// <summary>
        /// Returns the name of this instance of a component.
        /// </summary>
        /// <returns>The name of the object, or null if the object does not have a name.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        /// <summary>
        /// Returns a type converter for this instance of a component.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.TypeConverter" /> that is the converter for this object, or null if there is no <see cref="T:System.ComponentModel.TypeConverter" /> for this object.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        /// <summary>
        /// Returns the default event for this instance of a component.
        /// </summary>
        /// <returns>An <see cref="T:System.ComponentModel.EventDescriptor" /> that represents the default event for this object, or null if this object does not have events.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        /// <summary>
        /// Returns the default property for this instance of a component.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.PropertyDescriptor" /> that represents the default property for this object, or null if this object does not have properties.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        /// <summary>
        /// Returns an editor of the specified type for this instance of a component.
        /// </summary>
        /// <param name="editorBaseType">A <see cref="T:System.Type" /> that represents the editor for this object.</param>
        /// <returns>An <see cref="T:System.Object" /> of the specified type that is the editor for this object, or null if the editor cannot be found.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        /// <summary>
        /// Returns the events for this instance of a component.
        /// </summary>
        /// <returns>An <see cref="T:System.ComponentModel.EventDescriptorCollection" /> that represents the events for this component instance.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        /// <summary>
        /// Returns the events for this instance of a component using the specified attribute array as a filter.
        /// </summary>
        /// <param name="attributes">An array of type <see cref="T:System.Attribute" /> that is used as a filter.</param>
        /// <returns>An <see cref="T:System.ComponentModel.EventDescriptorCollection" /> that represents the filtered events for this component instance.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        /// <summary>
        /// Returns the properties for this instance of a component.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.PropertyDescriptorCollection" /> that represents the properties for this component instance.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public PropertyDescriptorCollection GetProperties()
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(this, true);

            if (!ShowInternalProperties)
            {
                return FilterProperties(properties, hideProperties);
            }
            return FilterProperties(properties, new string[] { "ShowInternalProperties" });
        }

        /// <summary>
        /// Returns the properties for this instance of a component using the attribute array as a filter.
        /// </summary>
        /// <param name="attributes">An array of type <see cref="T:System.Attribute" /> that is used as a filter.</param>
        /// <returns>A <see cref="T:System.ComponentModel.PropertyDescriptorCollection" /> that represents the filtered properties for this component instance.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(this, attributes, true);

            if (!ShowInternalProperties)
            {
                return FilterProperties(properties, hideProperties);
            }
            return FilterProperties(properties, new string[] { "ShowInternalProperties" });
        }

        /// <summary>
        /// Returns an object that contains the property described by the specified property descriptor.
        /// </summary>
        /// <param name="pd">A <see cref="T:System.ComponentModel.PropertyDescriptor" /> that represents the property whose owner is to be found.</param>
        /// <returns>An <see cref="T:System.Object" /> that represents the owner of the specified property.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }

        /// <summary>
        /// Determines whether this instance is empty.
        /// </summary>
        /// <returns><c>true</c> if this instance is empty; otherwise, <c>false</c>.</returns>
        public virtual bool IsEmpty()
        {
            // Ignore inbuilt properties, as we know that they are used for internal use
            var inbuiltProperties = typeof(IKopernicusObject).GetProperties().Select(p => p.Name);
            var properties = GetType().GetProperties();
            Dictionary<string, bool> results = new Dictionary<string, bool>();
            foreach (var property in properties.Where(p => !inbuiltProperties.Contains(p.Name) && p.CanRead))
            {
                if ((typeof(IEnumerable<IKopernicusObject>).IsAssignableFrom(property.PropertyType)))
                {
                    var col = property.GetValue(this, null) as IEnumerable;
                    if (col == null || col.GetCount() == 0)
                    {
                        results.Add(property.Name, false);
                    }
                    else
                    {
                        List<bool> colResults = new List<bool>();
                        foreach (var item in col)
                        {
                            colResults.Add(((IKopernicusObject)item).IsEmpty());
                        }
                        results.Add(property.Name, !colResults.All(p => p == true));
                    }
                }
                else
                {
                    if (!(typeof(IKopernicusObject).IsAssignableFrom(property.PropertyType)))
                    {
                        var propValue = property.GetValue(this);
                        if (propValue == null || string.IsNullOrWhiteSpace(propValue.ToString()))
                        {
                            results.Add(property.Name, false);
                        }
                        else
                        {
                            results.Add(property.Name, true);
                        }
                    }
                    else
                    {
                        var propValue = property.GetValue(this);
                        if (propValue == null)
                        {
                            results.Add(property.Name, false);
                        }
                        else
                        {
                            results.Add(property.Name, !((IKopernicusObject)propValue).IsEmpty());
                        }
                    }
                }
            }
            var result = results.Select(p => p.Value).All(p => p == false);
            return result;
        }

        /// <summary>
        /// Shoulds the serialize order.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeOrder()
        {
            return ShowInternalProperties;
        }

        /// <summary>
        /// Shoulds the type of the serialize.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeType()
        {
            return ShowInternalProperties;
        }

        /// <summary>
        /// Filters the properties.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <param name="ignoreProperties">The ignore properties.</param>
        /// <returns>PropertyDescriptorCollection.</returns>
        protected virtual PropertyDescriptorCollection FilterProperties(PropertyDescriptorCollection properties, string[] ignoreProperties)
        {
            List<PropertyDescriptor> validProperties = new List<PropertyDescriptor>();
            foreach (PropertyDescriptor property in properties)
            {
                if (!ignoreProperties.Any(p => p.Equals(property.Name)))
                {
                    validProperties.Add(property);
                }
            }
            return new PropertyDescriptorCollection(validProperties.ToArray());
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        protected virtual void Initialize()
        {
            foreach (var property in GetType().GetProperties())
            {
                if (typeof(IEnumerable<IKopernicusObject>).IsAssignableFrom(property.PropertyType))
                {
                    var generic = property.PropertyType.GetGenericArguments().First();
                    var instance = Activator.CreateInstance(typeof(List<>).MakeGenericType(generic));
                    property.SetValue(this, instance, null);
                }
                else if (typeof(IKopernicusObject).IsAssignableFrom(property.PropertyType))
                {
                    var instance = Activator.CreateInstance(property.PropertyType);
                    property.SetValue(this, instance);
                }
            }
        }

        #endregion Methods
    }
}