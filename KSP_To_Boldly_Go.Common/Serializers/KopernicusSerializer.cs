// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 02-25-2019
// ***********************************************************************
// <copyright file="KopernicusSerializer.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using KSP_To_Boldly_Go.Common.Extensions;
using KSP_To_Boldly_Go.Common.Models;

/// <summary>
/// The Serializers namespace.
/// </summary>
namespace KSP_To_Boldly_Go.Common.Serializers
{
    /// <summary>
    /// Class KopernicusSerializer.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Common.Serializers.IKopernicusSerializer" />
    public class KopernicusSerializer : IKopernicusSerializer
    {
        #region Fields

        /// <summary>
        /// The seed
        /// </summary>
        private int _seed;

        /// <summary>
        /// The random
        /// </summary>
        private Random random;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KopernicusSerializer" /> class.
        /// </summary>
        /// <param name="handlerFactory">The handler factory.</param>
        public KopernicusSerializer(IHandlerFactory handlerFactory)
        {
            HandlerFactory = handlerFactory;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the seed.
        /// </summary>
        /// <value>The seed.</value>
        public int Seed
        {
            get
            {
                return _seed;
            }
            set
            {
                if (value != _seed)
                {
                    random = new Random(_seed);
                }
                _seed = value;
            }
        }

        /// <summary>
        /// Gets or sets the handler factory.
        /// </summary>
        /// <value>The handler factory.</value>
        protected IHandlerFactory HandlerFactory { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Serializes the specified object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <param name="serializationStream">The serialization stream.</param>
        public void Serialize<T>(T obj, Stream serializationStream) where T : IKopernicusObject
        {
            using (var stream = new StreamWriter(serializationStream))
            {
                if (obj is IKopernicusObject)
                {
                    var kopernicusObject = (IKopernicusObject)obj;
                    if (kopernicusObject.IsEmpty())
                    {
                        return;
                    }
                }
                var header = obj.Header;
                if (!string.IsNullOrWhiteSpace(header))
                {
                    stream.WriteLine(header);
                }
                stream.WriteLine("{");
                WriteStream(stream, obj, 0);
                stream.WriteLine("}");
                stream.Flush();
            }
        }

        /// <summary>
        /// Appends the line.
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <param name="tabIndent">The tab indent.</param>
        /// <param name="format">The format.</param>
        /// <param name="values">The values.</param>
        private void AppendLine(StringBuilder sb, int tabIndent, string format, params string[] values)
        {
            for (int i = 0; i < tabIndent; i++)
            {
                sb.Append("\t");
            }
            if (values.Count() > 0)
            {
                sb.AppendFormat(format + Environment.NewLine, values);
            }
            else
            {
                sb.AppendLine(format);
            }
        }

        /// <summary>
        /// Writes the stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="obj">The object.</param>
        /// <param name="tabIndent">The tab indent.</param>
        private void WriteStream(StreamWriter stream, object obj, int tabIndent)
        {
            tabIndent++;
            var properties = obj.GetType().GetProperties();
            // Skip properties with ignore attribute
            foreach (var property in properties.Where(p => p.GetCustomAttributes(typeof(KopernicusSerializeIgnoreAttribute), true).Count() == 0 && p.CanRead))
            {
                if (typeof(IEnumerable<IKopernicusObject>).IsAssignableFrom(property.PropertyType))
                {
                    var col = property.GetValue(obj, null) as IEnumerable;
                    if (col != null && col.GetCount() > 0)
                    {
                        List<IKopernicusObject> kopernicusObjects = new List<IKopernicusObject>();
                        foreach (var item in col)
                        {
                            kopernicusObjects.Add((IKopernicusObject)item);
                        }
                        if (!kopernicusObjects.All(p => p.IsEmpty()))
                        {
                            // Write starting bracket
                            var sb = new StringBuilder();
                            AppendLine(sb, tabIndent, "{0}", property.Name);
                            AppendLine(sb, tabIndent, "{");
                            stream.Write(sb.ToString());
                            foreach (var listItem in kopernicusObjects)
                            {
                                if (!listItem.IsEmpty())
                                {
                                    sb = new StringBuilder();
                                    if (!string.IsNullOrWhiteSpace(listItem.Header))
                                    {
                                        AppendLine(sb, tabIndent + 1, "{0}", listItem.Header);
                                    }
                                    else
                                    {
                                        AppendLine(sb, tabIndent + 1, "{0}", listItem.ToString());
                                    }
                                    AppendLine(sb, tabIndent + 1, "{");
                                    stream.Write(sb.ToString());
                                    WriteStream(stream, listItem, tabIndent + 1);
                                    sb = new StringBuilder();
                                    AppendLine(sb, tabIndent + 1, "}");
                                    stream.Write(sb.ToString());
                                }
                            }
                            // Write closing bracket
                            sb = new StringBuilder();
                            AppendLine(sb, tabIndent, "}");
                            stream.Write(sb.ToString());
                        }
                    }
                }
                else
                {
                    var propValue = property.GetValue(obj);
                    if (propValue != null)
                    {
                        if (typeof(IKopernicusObject).IsAssignableFrom(property.PropertyType))
                        {
                            var kopernicusObject = (IKopernicusObject)propValue;
                            if (!kopernicusObject.IsEmpty())
                            {
                                // Write starting bracket
                                var sb = new StringBuilder();
                                if (propValue is IKopernicusObject && !string.IsNullOrWhiteSpace(((IKopernicusObject)propValue).Header))
                                {
                                    AppendLine(sb, tabIndent, "{0}", ((IKopernicusObject)propValue).Header);
                                }
                                else
                                {
                                    AppendLine(sb, tabIndent, "{0}", property.Name);
                                }
                                AppendLine(sb, tabIndent, "{");
                                // Dump what we have so far
                                stream.Write(sb.ToString());
                                WriteStream(stream, propValue, tabIndent);
                                // Write closing bracket
                                sb = new StringBuilder();
                                AppendLine(sb, tabIndent, "}");
                                stream.Write(sb.ToString());
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(propValue.ToString()))
                            {
                                var sb = new StringBuilder();
                                // Check if any converter can convert this type, if not assume some "simple" value
                                var converter = HandlerFactory.CreateConverterHandler().CreateConverter(propValue.GetType());
                                if (converter != null)
                                {
                                    AppendLine(sb, tabIndent, "{0} = {1}", property.Name, converter.ToString(propValue, random));
                                }
                                else
                                {
                                    AppendLine(sb, tabIndent, "{0} = {1}", property.Name, propValue.ToString());
                                }
                                stream.Write(sb.ToString());
                            }
                        }
                    }
                }
            }
        }

        #endregion Methods
    }
}