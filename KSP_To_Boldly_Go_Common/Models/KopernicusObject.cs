// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go_Common
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 01-21-2017
// ***********************************************************************
// <copyright file="KopernicusObject.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using KSP_To_Boldly_Go_Common.Serializers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace KSP_To_Boldly_Go_Common.Models
{
    /// <summary>
    /// Class KopernicusObject.
    /// </summary>
    /// <seealso cref="System.ComponentModel.ICustomTypeDescriptor" />
    /// <seealso cref="KSP_To_Boldly_Go_Common.Models.IKopernicusObject" />
    public class KopernicusObject : IKopernicusObject, ICustomTypeDescriptor
    {
        #region Fields

        /// <summary>
        /// The show internal properties
        /// </summary>
        private bool _showInternalProperties = false;

        /// <summary>
        /// The hide properties
        /// </summary>
        private string[] hideProperties = new string[] { "Order", "Type", "ShowInternalProperties" };

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>The header.</value>
        [KopernicusSerializegnore]
        [Description("Kopernicus node header. Internal program property.")]
        public string Header
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>The order.</value>
        [JsonProperty("$order")]
        [KopernicusSerializegnore]
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
        [KopernicusSerializegnore]
        [Description("Used to initialize correct type. Internal program property.")]
        [ReadOnly(true)]
        public string Type
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

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
        private PropertyDescriptorCollection FilterProperties(PropertyDescriptorCollection properties, string[] ignoreProperties)
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

        #endregion Methods
    }
}