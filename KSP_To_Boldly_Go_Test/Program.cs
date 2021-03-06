﻿// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go_Test
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 01-20-2017
// ***********************************************************************
// <copyright file="Program.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using KSP_To_Boldly_Go_Common.Utlities;
using System;
using System.IO;
using System.Reflection;

namespace KSP_To_Boldly_Go_Test
{
    /// <summary>
    /// Class Program.
    /// </summary>
    internal class Program
    {
        #region Methods

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        private static void Main(string[] args)
        {
            var path = System.IO.Path.Combine(System.IO.Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "output.cfg");
            var fs = new FileStream(path, FileMode.Create);
            var serializer = new KopernicusSerializer();
            serializer.Serialize<KopernicusMain>(new KopernicusMain(), fs);
        }

        #endregion Methods
    }
}