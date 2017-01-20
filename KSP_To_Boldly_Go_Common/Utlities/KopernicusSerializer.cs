// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go_Common
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
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace KSP_To_Boldly_Go_Common.Utlities
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
                var header = obj.Header;
                if (!string.IsNullOrWhiteSpace(header.ToString()))
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
            // Skip configurable headers
            foreach (var property in properties.Where(p => p.PropertyType != typeof(KopernicusHeader)))
            {
                if (property.CanRead)
                {
                    var value = property.GetValue(obj);
                    if (value != null)
                    {
                        if (property.PropertyType.IsClass && !(property.PropertyType.IsPrimitive || property.PropertyType.Equals(typeof(string)) || property.PropertyType.Equals(typeof(DateTime))))
                        {
                            // Write starting bracket
                            var sb = new StringBuilder();
                            if (value is IKopernicusObject && !string.IsNullOrWhiteSpace(((IKopernicusObject)value).Header))
                            {
                                AppendLine(sb, tabIndent, "{0}", ((IKopernicusObject)value).Header.ToString());
                            }
                            else
                            {
                                AppendLine(sb, tabIndent, "{0}", property.Name);
                            }
                            AppendLine(sb, tabIndent, "{");
                            // Dump what we have so far
                            stream.Write(sb.ToString());
                            WriteStream(stream, value, tabIndent);
                            // Write closing bracket
                            sb = new StringBuilder();
                            AppendLine(sb, tabIndent, "}");
                            stream.Write(sb.ToString());
                        }
                        else
                        {
                            if (!(value is KopernicusHeader) && !string.IsNullOrWhiteSpace(value.ToString()))
                            {
                                // TODO: Color special handling. Might need refactoring in the future...
                                if (value is Color)
                                {
                                    var c = ((Color)value);
                                    var sb = new StringBuilder();
                                    AppendLine(sb, tabIndent, "{0} = {1}", property.Name, c.ToConfigString());
                                    stream.Write(sb.ToString());
                                }
                                else
                                {
                                    var sb = new StringBuilder();
                                    AppendLine(sb, tabIndent, "{0} = {1}", property.Name, value.ToString());
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