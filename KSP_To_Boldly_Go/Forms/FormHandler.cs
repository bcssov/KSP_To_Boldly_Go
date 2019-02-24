// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 02-23-2019
//
// Last Modified By : Mario
// Last Modified On : 02-24-2019
// ***********************************************************************
// <copyright file="FormOpener.cs" company="Mario">
//     Copyright ©  2017-2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using KSP_To_Boldly_Go.DependencyInjection;

/// <summary>
/// The Forms namespace.
/// </summary>
namespace KSP_To_Boldly_Go.Forms
{
    /// <summary>
    /// Class FormHandler.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Forms.IFormHandler" />
    public class FormHandler : IFormHandler
    {
        #region Fields

        /// <summary>
        /// The manager
        /// </summary>
        private FormManager manager;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FormHandler"/> class.
        /// </summary>
        public FormHandler()
        {
            manager = new FormManager();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Creates the form.
        /// </summary>
        /// <typeparam name="TForm">The type of the t form.</typeparam>
        /// <returns>TForm.</returns>
        public TForm CreateForm<TForm>() where TForm : Form
        {
            var form = DIContainer.Container.GetInstance<TForm>();
            manager.AddForm(form.GetType(), form);
            form.Closed += (s, e) =>
            {
                manager.RemoveForm(form.GetType());
            };
            return form;
        }

        /// <summary>
        /// Gets the form or default.
        /// </summary>
        /// <typeparam name="TForm">The type of the t form.</typeparam>
        /// <returns>TForm.</returns>
        public TForm GetFormOrDefault<TForm>() where TForm : Form
        {
            var form = GetOpenForm<TForm>();
            if (form == null)
            {
                form = CreateForm<TForm>();
            }
            return form;
        }

        /// <summary>
        /// Gets the open form.
        /// </summary>
        /// <typeparam name="TForm">The type of the t form.</typeparam>
        /// <returns>TForm.</returns>
        public TForm GetOpenForm<TForm>() where TForm : Form
        {
            var form = manager.GetForm(typeof(TForm));
            if (form == null)
            {
                return null;
            }
            return (TForm)form.Form;
        }

        #endregion Methods

        #region Classes

        /// <summary>
        /// Class FormManager.
        /// </summary>
        private class FormManager
        {
            #region Fields

            /// <summary>
            /// The forms lock
            /// </summary>
            private readonly object formsLock = new object { };

            /// <summary>
            /// The open forms
            /// </summary>
            private readonly List<OpenForm> openForms;

            #endregion Fields

            #region Constructors

            /// <summary>
            /// Initializes a new instance of the <see cref="FormManager"/> class.
            /// </summary>
            public FormManager()
            {
                openForms = new List<OpenForm>();
            }

            #endregion Constructors

            #region Methods

            /// <summary>
            /// Adds the form.
            /// </summary>
            /// <param name="type">The type.</param>
            /// <param name="form">The form.</param>
            public void AddForm(Type type, Form form)
            {
                lock (formsLock)
                {
                    var existingForm = GetForm(type);
                    if (existingForm != null)
                    {
                        openForms.Remove(existingForm);
                        existingForm.Form.Dispose();
                    }
                    openForms.Add(new OpenForm()
                    {
                        Form = form,
                        Type = type
                    });
                }
            }

            /// <summary>
            /// Gets the form.
            /// </summary>
            /// <param name="type">The type.</param>
            /// <returns>OpenForm.</returns>
            public OpenForm GetForm(Type type)
            {
                return openForms.SingleOrDefault(p => p.Type == type);
            }

            /// <summary>
            /// Removes the form.
            /// </summary>
            /// <param name="type">The type.</param>
            public void RemoveForm(Type type)
            {
                lock (formsLock)
                {
                    var existingForm = GetForm(type);
                    if (existingForm != null)
                    {
                        openForms.Remove(existingForm);
                    }
                }
            }

            #endregion Methods
        }

        /// <summary>
        /// Class OpenForm.
        /// </summary>
        private class OpenForm
        {
            #region Properties

            /// <summary>
            /// Gets or sets the form.
            /// </summary>
            /// <value>The form.</value>
            public Form Form { get; set; }

            /// <summary>
            /// Gets or sets the type.
            /// </summary>
            /// <value>The type.</value>
            public Type Type { get; set; }

            #endregion Properties
        }

        #endregion Classes
    }
}