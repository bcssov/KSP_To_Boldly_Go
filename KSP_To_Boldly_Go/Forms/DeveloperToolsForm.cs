// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 02-26-2019
// ***********************************************************************
// <copyright file="DeveloperToolsForm.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KSP_To_Boldly_Go.Common;
using KSP_To_Boldly_Go.Common.Models;
using KSP_To_Boldly_Go.Common.Serializers;
using Newtonsoft.Json;

namespace KSP_To_Boldly_Go.Forms
{
    /// <summary>
    /// Class DeveloperToolsForm.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Forms.BaseMaterialForm" />
    public partial class DeveloperToolsForm : BaseMaterialForm
    {
        #region Fields

        /// <summary>
        /// The configuration
        /// </summary>
        private IConfiguration config;

        /// <summary>
        /// The form handler
        /// </summary>
        private IFormHandler formHandler;

        /// <summary>
        /// The handler factory
        /// </summary>
        private IHandlerFactory handlerFactory;

        /// <summary>
        /// The initial title
        /// </summary>
        private string initialTitle = string.Empty;

        /// <summary>
        /// The is dirty
        /// </summary>
        private bool isDirty = false;

        /// <summary>
        /// The model
        /// </summary>
        private IKopernicusObject model = null;

        /// <summary>
        /// The path
        /// </summary>
        private string path = string.Empty;

        /// <summary>
        /// The serializer
        /// </summary>
        private IKopernicusSerializer serializer;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DeveloperToolsForm" /> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="formHandler">The form handler.</param>
        /// <param name="serializer">The serializer.</param>
        /// <param name="handlerFactory">The handler factory.</param>
        public DeveloperToolsForm(IConfiguration config, IFormHandler formHandler, IKopernicusSerializer serializer, IHandlerFactory handlerFactory)
        {
            InitializeComponent();
            this.config = config;
            this.formHandler = formHandler;
            this.serializer = serializer;
            this.handlerFactory = handlerFactory;
            initialTitle = Text;
            pgData.PropertySort = PropertySort.Alphabetical;
            pgData.PropertyValueChanged += PgData_PropertyValueChanged;
            FormClosing += DeveloperToolsForm_FormClosing;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Checks the state of the model.
        /// </summary>
        private void CheckModelState()
        {
            isDirty = model.IsDirty();
            if (isDirty)
            {
                Text = $"{Text}*";
            }
        }

        /// <summary>
        /// Handles the Click event of the closeToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times", Justification = "Already checking if can dispose, code analysis is playing dumb!")]
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            if (!IsDisposed && !Disposing)
            {
                Dispose();
            }
        }

        /// <summary>
        /// Handles the FormClosing event of the DeveloperToolsForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs" /> instance containing the event data.</param>
        private void DeveloperToolsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isDirty)
            {
                var form = formHandler.GetFormOrDefault<YesNoForm>();
                form.SetContent(Constants.ChangesNotSavedTitle, Constants.ChangesNotSavedMessage);
                if (form.ShowDialog(this) == DialogResult.Yes)
                {
                    e.Cancel = true;
                }
                form.Close();
                form.Dispose();
            }
        }

        /// <summary>
        /// Gets the kopernicus objects from directory.
        /// </summary>
        /// <returns>List&lt;IKopernicusObject&gt;.</returns>
        private List<IKopernicusObject> GetKopernicusObjectsFromDirectory()
        {
            var files = Directory.EnumerateFileSystemEntries(config.JsonConfigPath, Constants.JSONExtension, SearchOption.AllDirectories);
            if (files != null && files.Count() > 0)
            {
                List<IKopernicusObject> kopernicusObjects = new List<IKopernicusObject>();
                foreach (var file in files)
                {
                    var contents = File.ReadAllText(file);
                    var kopernicusObject = handlerFactory.CreateModelHandler().CreateModelFromJSON(contents);
                    kopernicusObject.FileName = file;
                    kopernicusObjects.Add(kopernicusObject);
                }
                return kopernicusObjects;
            }
            return null;
        }

        /// <summary>
        /// Handles the Click event of the getNextOrderToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void getNextOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<IKopernicusObject> kopernicusObjects = GetKopernicusObjectsFromDirectory();
            if (kopernicusObjects != null && kopernicusObjects.Count > 0)
            {
                if (model != null)
                {
                    model.Order = kopernicusObjects.OrderByDescending(p => p.Order).First().Order + 1;
                    pgData.Refresh();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the loadToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = config.JsonConfigPath;
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                var contents = File.ReadAllText(path);
                model = handlerFactory.CreateModelHandler().CreateModelFromJSON(contents);
                if (model != null)
                {
                    UpdateModelPath();
                    pgData.SelectedObject = model;
                    Text = $"{initialTitle} : {Path.GetFileName(path)}";
                    CheckModelState();
                }
                else
                {
                    Text = initialTitle;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the newToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = formHandler.GetFormOrDefault<NewObjectForm>();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                var instance = handlerFactory.CreateModelHandler().CreateModel(form.SelectedType);
                pgData.SelectedObject = instance;
                model = instance;
                Text = $"{initialTitle} : {form.SelectedType}";
                path = string.Empty;
                UpdateModelPath();
                CheckModelState();
            }
        }

        /// <summary>
        /// Handles the PropertyValueChanged event of the PgData control.
        /// </summary>
        /// <param name="s">The source of the event.</param>
        /// <param name="e">The <see cref="PropertyValueChangedEventArgs" /> instance containing the event data.</param>
        private void PgData_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            CheckModelState();
        }

        /// <summary>
        /// Handles the Click event of the saveToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (model != null)
            {
                if (string.IsNullOrWhiteSpace(path))
                {
                    saveFileDialog1.InitialDirectory = config.JsonConfigPath;
                    if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
                    {
                        path = saveFileDialog1.FileName;
                        UpdateModelPath();
                        Text = $"{initialTitle} : {Path.GetFileName(path)}";
                        File.WriteAllText(path, JsonConvert.SerializeObject(model));
                    }
                }
                else
                {
                    File.WriteAllText(path, JsonConvert.SerializeObject(model));
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the serializeTestToolStripMenuItem1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void serializeTestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (model != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    serializer.Seed = Constants.SerializationHashCode.GetHashCode();
                    serializer.Serialize(model, ms);
                    var output = Encoding.ASCII.GetString(ms.ToArray());
                    var form = formHandler.GetFormOrDefault<GenericOutputForm>();
                    form.SetContent($"{Constants.SerializationFormTitle} : {path}", output);
                    form.ShowDialog(this);
                    form.Dispose();
                }
            }
        }

        /// <summary>
        /// Updates the model path.
        /// </summary>
        private void UpdateModelPath()
        {
            model.FileName = path;
        }

        /// <summary>
        /// Handles the Click event of the validateConfigsToolStripMenuItem1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void validateConfigsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<IKopernicusObject> kopernicusObjects = GetKopernicusObjectsFromDirectory();
            var handler = handlerFactory.CreateValidationHandler();
            var validationResults = handler.Validate(kopernicusObjects);
            var isValid = handler.ValidateResults(validationResults);
            var form = formHandler.GetFormOrDefault<GenericOutputForm>();
            form.SetContent(Constants.ValidationResults, $"Directory: {config.JsonConfigPath}{Environment.NewLine}Is Valid: {isValid}{Environment.NewLine}{Environment.NewLine}{handler.FormatMessages(validationResults)}");
            form.ShowDialog(this);
            form.Dispose();
        }

        #endregion Methods

        #region Classes

        /// <summary>
        /// Class Constants.
        /// </summary>
        private class Constants
        {
            #region Fields

            /// <summary>
            /// The changes not saved message
            /// </summary>
            public const string ChangesNotSavedMessage = "Changes haven't been saved. Do you want to cancel the closing operation?";

            /// <summary>
            /// The changes not saved title
            /// </summary>
            public const string ChangesNotSavedTitle = "Not Saved";

            /// <summary>
            /// The json extension
            /// </summary>
            public const string JSONExtension = "*.json";

            /// <summary>
            /// The serialization form title
            /// </summary>
            public const string SerializationFormTitle = "Serialization Test Output";

            /// <summary>
            /// The serialization hash code
            /// </summary>
            public const string SerializationHashCode = "To Boldly Go";

            /// <summary>
            /// The validation results
            /// </summary>
            public const string ValidationResults = "Validation Results";

            #endregion Fields
        }

        #endregion Classes
    }
}