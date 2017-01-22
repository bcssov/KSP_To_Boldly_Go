// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 01-20-2017
// ***********************************************************************
// <copyright file="KSPSerializer.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using KSP_To_Boldly_Go.Common.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace KSP_To_Boldly_Go.Common.Serializers
{
    /// <summary>
    /// Class KopernicusSerializer.
    /// </summary>
    public class KopernicusSerializer
    {
        #region Methods

        /// <summary>
        /// Serializes the specified serialization stream.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The graph.</param>
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
        /// <param name="obj">The graph.</param>
        /// <param name="tabIndent">The tab indent.</param>
        private void WriteStream(StreamWriter stream, object obj, int tabIndent)
        {
            tabIndent++;
            var properties = obj.GetType().GetProperties();
            // Skip properties with ignore attribute
            foreach (var property in properties.Where(p => p.GetCustomAttributes(typeof(KopernicusSerializegnoreAttribute), true).Count() == 0 && p.CanRead))
            {
                if (typeof(IEnumerable<IKopernicusObject>).IsAssignableFrom(property.PropertyType))
                {
                    var col = property.GetValue(obj, null) as IEnumerable;
                    if (col != null && col.GetCount() > 0)
                    {
                        List<IKopernicusObject> kopernicusObjects = new List<IKopernicusObject>();
                        foreach (var item in col)
                        {
                            kopernicusObjects.Add((KopernicusObject)item);
                        }
                        if (!kopernicusObjects.All(p => p.IsEmpty()))
                        {
                            // Write starting bracket
                            var sb = new StringBuilder();
                            AppendLine(sb, tabIndent, "{0}", property.Name);
                            AppendLine(sb, tabIndent, "{");
                            stream.Write(sb.ToString());
                            foreach (var listItem in col)
                            {
                                sb = new StringBuilder();
                                AppendLine(sb, tabIndent + 1, "{0}", ((IKopernicusObject)listItem).Header);
                                AppendLine(sb, tabIndent + 1, "{");
                                stream.Write(sb.ToString());
                                WriteStream(stream, listItem, tabIndent + 1);
                                sb = new StringBuilder();
                                AppendLine(sb, tabIndent + 1, "}");
                                stream.Write(sb.ToString());
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
                                // TODO: Color special handling. Might need refactoring in the future...
                                if (propValue is Color)
                                {
                                    var color = ((Color)propValue);
                                    var sb = new StringBuilder();
                                    AppendLine(sb, tabIndent, "{0} = {1}", property.Name, color.ToConfigString());
                                    stream.Write(sb.ToString());
                                }
                                else
                                {
                                    var sb = new StringBuilder();
                                    AppendLine(sb, tabIndent, "{0} = {1}", property.Name, propValue.ToString());
                                    stream.Write(sb.ToString());
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion Methods
    }
}