// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 02-26-2019
// ***********************************************************************
// <copyright file="KopernicusObject.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using KSP_To_Boldly_Go.Common.Extensions;
using KSP_To_Boldly_Go.Common.Serializers;
using Newtonsoft.Json;
using PropertyChanged;

/// <summary>
/// The Models namespace.
/// </summary>
namespace KSP_To_Boldly_Go.Common.Models
{
    /// <summary>
    /// Class KopernicusObject.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Common.Models.IKopernicusObject" />
    /// <seealso cref="System.ComponentModel.ICustomTypeDescriptor" />
    [AddINotifyPropertyChangedInterface]
    public abstract class KopernicusObject : IKopernicusObject, ICustomTypeDescriptor
    {
        #region Fields

        /// <summary>
        /// The internal properties
        /// </summary>
        protected static List<string> internalProperties;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        [JsonIgnore]
        [KopernicusSerializeIgnore]
        [DoNotSetChanged]
        public string FileName
        {
            get;
            set;
        }

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
        /// Gets or sets a value indicating whether this instance is changed.
        /// </summary>
        /// <value><c>true</c> if this instance is changed; otherwise, <c>false</c>.</value>
        [JsonIgnore]
        [KopernicusSerializeIgnore]
        [Browsable(false)]
        public bool IsChanged { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>The order.</value>
        [JsonProperty("$order")]
        [KopernicusSerializeIgnore]
        [DoNotSetChanged]
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
        [DoNotSetChanged]
        public bool ShowInternalProperties { get; set; } = false;

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("$objectType")]
        [KopernicusSerializeIgnore]
        [DoNotSetChanged]
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
        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        /// <summary>
        /// Returns the name of this instance of a component.
        /// </summary>
        /// <returns>The name of the object, or null if the object does not have a name.</returns>
        public string GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        /// <summary>
        /// Returns a type converter for this instance of a component.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.TypeConverter" /> that is the converter for this object, or null if there is no <see cref="T:System.ComponentModel.TypeConverter" /> for this object.</returns>
        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        /// <summary>
        /// Returns the default event for this instance of a component.
        /// </summary>
        /// <returns>An <see cref="T:System.ComponentModel.EventDescriptor" /> that represents the default event for this object, or null if this object does not have events.</returns>
        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        /// <summary>
        /// Returns the default property for this instance of a component.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.PropertyDescriptor" /> that represents the default property for this object, or null if this object does not have properties.</returns>
        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        /// <summary>
        /// Returns an editor of the specified type for this instance of a component.
        /// </summary>
        /// <param name="editorBaseType">A <see cref="T:System.Type" /> that represents the editor for this object.</param>
        /// <returns>An <see cref="T:System.Object" /> of the specified type that is the editor for this object, or null if the editor cannot be found.</returns>
        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        /// <summary>
        /// Returns the events for this instance of a component.
        /// </summary>
        /// <returns>An <see cref="T:System.ComponentModel.EventDescriptorCollection" /> that represents the events for this component instance.</returns>
        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        /// <summary>
        /// Returns the events for this instance of a component using the specified attribute array as a filter.
        /// </summary>
        /// <param name="attributes">An array of type <see cref="T:System.Attribute" /> that is used as a filter.</param>
        /// <returns>An <see cref="T:System.ComponentModel.EventDescriptorCollection" /> that represents the filtered events for this component instance.</returns>
        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        /// <summary>
        /// Returns the properties for this instance of a component.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.PropertyDescriptorCollection" /> that represents the properties for this component instance.</returns>
        public PropertyDescriptorCollection GetProperties()
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(this, true);

            if (!ShowInternalProperties)
            {
                return FilterProperties(properties, Constants.HiddenInternalProperties);
            }
            return FilterProperties(properties, Constants.PartialHiddenInternalProperties);
        }

        /// <summary>
        /// Returns the properties for this instance of a component using the attribute array as a filter.
        /// </summary>
        /// <param name="attributes">An array of type <see cref="T:System.Attribute" /> that is used as a filter.</param>
        /// <returns>A <see cref="T:System.ComponentModel.PropertyDescriptorCollection" /> that represents the filtered properties for this component instance.</returns>
        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(this, attributes, true);

            if (!ShowInternalProperties)
            {
                return FilterProperties(properties, Constants.HiddenInternalProperties);
            }
            return FilterProperties(properties, Constants.PartialHiddenInternalProperties);
        }

        /// <summary>
        /// Returns an object that contains the property described by the specified property descriptor.
        /// </summary>
        /// <param name="pd">A <see cref="T:System.ComponentModel.PropertyDescriptor" /> that represents the property whose owner is to be found.</param>
        /// <returns>An <see cref="T:System.Object" /> that represents the owner of the specified property.</returns>
        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public virtual void Initialize()
        {
            var handler = DependencyInjection.DIContainer.Container.GetInstance<IModelHandler>();
            foreach (var property in GetType().GetProperties())
            {
                if (typeof(IEnumerable<IKopernicusObject>).IsAssignableFrom(property.PropertyType))
                {
                    var col = property.GetValue(this, null) as IEnumerable;
                    if (col == null)
                    {
                        var instance = handler.CreateCollection(property.PropertyType);
                        foreach (var item in instance)
                        {
                            item.Initialize();
                        }
                        property.SetValue(this, instance, null);
                    }
                }
                else if (typeof(IKopernicusObject).IsAssignableFrom(property.PropertyType))
                {
                    var propValue = property.GetValue(this);
                    if (propValue == null)
                    {
                        var instance = handler.CreateModel(property.PropertyType);
                        instance.Initialize();
                        property.SetValue(this, instance);
                    }
                }
            }
        }

        /// <summary>
        /// Determines whether this instance is dirty.
        /// </summary>
        /// <returns><c>true</c> if this instance is dirty; otherwise, <c>false</c>.</returns>
        public virtual bool IsDirty()
        {
            var results = new List<bool>();
            foreach (var property in GetType().GetProperties())
            {
                if (typeof(IEnumerable<IKopernicusObject>).IsAssignableFrom(property.PropertyType))
                {
                    var col = property.GetValue(this, null) as IEnumerable;
                    if (col?.GetCount() > 0)
                    {
                        foreach (var item in col)
                        {
                            results.Add(((IKopernicusObject)item).IsDirty());
                        }
                    }
                }
                else if (typeof(IKopernicusObject).IsAssignableFrom(property.PropertyType))
                {
                    var propValue = property.GetValue(this);
                    results.Add(!((IKopernicusObject)propValue).IsDirty());
                }
            }
            return results.Count() == 0 ? false : results.All(p => p == true);
        }

        /// <summary>
        /// Determines whether this instance is empty.
        /// </summary>
        /// <returns><c>true</c> if this instance is empty; otherwise, <c>false</c>.</returns>
        public virtual bool IsEmpty()
        {
            // Ignore inbuilt properties, as we know that they are used for internal use
            if (internalProperties == null || internalProperties.Count() == 0)
            {
                internalProperties = new List<string>();
                internalProperties.AddRange(typeof(IKopernicusObject).GetProperties().Where(p => p.Name != Constants.Header).Select(p => p.Name));
            }
            var properties = GetType().GetProperties();
            Dictionary<string, bool> results = new Dictionary<string, bool>();
            foreach (var property in properties.Where(p => !internalProperties.Contains(p.Name) && p.CanRead))
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
        /// Sets the dirty flag.
        /// </summary>
        /// <param name="isDirty">if set to <c>true</c> [is dirty].</param>
        public virtual void SetDirtyFlag(bool isDirty)
        {
            foreach (var property in GetType().GetProperties())
            {
                if (typeof(IEnumerable<IKopernicusObject>).IsAssignableFrom(property.PropertyType))
                {
                    var col = property.GetValue(this, null) as IEnumerable;
                    if (col?.GetCount() > 0)
                    {
                        foreach (var item in col)
                        {
                            if (item != null)
                            {
                                ((IKopernicusObject)item).SetDirtyFlag(isDirty);
                            }
                        }
                    }
                }
                else if (typeof(IKopernicusObject).IsAssignableFrom(property.PropertyType))
                {
                    var propValue = property.GetValue(this);
                    if (propValue != null)
                    {
                        ((IKopernicusObject)propValue).SetDirtyFlag(isDirty);
                    }
                }
            }
            IsChanged = isDirty;
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
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return string.IsNullOrWhiteSpace(Header) ? GetObjectName() : Header;
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
        /// Gets the name of the object.
        /// </summary>
        /// <returns>System.String.</returns>
        protected abstract string GetObjectName();

        #endregion Methods

        #region Classes

        /// <summary>
        /// Class Constants.
        /// </summary>
        protected class Constants
        {
            #region Fields

            /// <summary>
            /// The header
            /// </summary>
            public const string Header = "Header";

            /// <summary>
            /// The hidden internal properties
            /// </summary>
            public static readonly string[] HiddenInternalProperties = new string[] { "Order", "Type", "ShowInternalProperties", "FileName" };

            /// <summary>
            /// The partial hidden internal properties
            /// </summary>
            public static readonly string[] PartialHiddenInternalProperties = new string[] { "ShowInternalProperties", "FileName" };

            #endregion Fields
        }

        #endregion Classes
    }
}