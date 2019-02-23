// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 02-23-2019
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
using KSP_To_Boldly_Go.Common.Models;
using KSP_To_Boldly_Go.Common.Serializers;
using KSP_To_Boldly_Go.Common.Validators;
using KSP_To_Boldly_Go.DIConfig;
using Newtonsoft.Json;

namespace KSP_To_Boldly_Go.Forms
{
    /// <summary>
    /// Class DeveloperToolsForm.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class DeveloperToolsForm : Form
    {
        #region Fields

        /// <summary>
        /// The configuration
        /// </summary>
        private Configuration config;

        /// <summary>
        /// The initial title
        /// </summary>
        private string initialTitle = string.Empty;

        /// <summary>
        /// The model
        /// </summary>
        private IKopernicusObject model = null;

        /// <summary>
        /// The path
        /// </summary>
        private string path = string.Empty;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DeveloperToolsForm" /> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public DeveloperToolsForm(Configuration config)
        {
            InitializeComponent();
            this.config = config;
            initialTitle = Text;
            pgData.PropertySort = PropertySort.Alphabetical;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Handles the Click event of the closeToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
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
                    var kopernicusObject = ModelManager.GetKoperniusObjectFromJson(contents);
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
                model = ModelManager.GetKoperniusObjectFromJson(contents);
                if (model != null)
                {
                    UpdateModelPath();
                    pgData.SelectedObject = model;
                    Text = string.Format("{0}: {1}", initialTitle, Path.GetFileName(path));
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
            var form = DIResolver.Get<NewObjectForm>();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                var instance = ModelManager.GetKopernicusObjectFromType(form.SelectedType);
                pgData.SelectedObject = instance;
                model = instance;
                Text = string.Format("{0}: {1}", initialTitle, form.SelectedType);
                path = string.Empty;
                UpdateModelPath();
            }
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
                        Text = string.Format("{0}: {1}", initialTitle, Path.GetFileName(path));
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
                    var serializer = new KopernicusSerializer(Constants.SerializationHashCode.GetHashCode());
                    serializer.Serialize(model, ms);
                    var output = Encoding.ASCII.GetString(ms.ToArray());
                    var form = DIResolver.Get<GenericOutputForm>();
                    form.SetContent(string.Format(Constants.SerializationFormTitle, path), output);
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
            var validationResults = ValidatorManager.ValidateModels(kopernicusObjects);
            var form = DIResolver.Get<GenericOutputForm>();
            form.SetContent(string.Format(Constants.ValidationResults, config.JsonConfigPath), string.Join(Environment.NewLine, validationResults));
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
            /// The json extension
            /// </summary>
            public const string JSONExtension = "*.json";

            /// <summary>
            /// The serialization form title
            /// </summary>
            public const string SerializationFormTitle = "Serialization Test Output: {0}";

            /// <summary>
            /// The serialization hash code
            /// </summary>
            public const string SerializationHashCode = "To Boldly Go";

            /// <summary>
            /// The validation results
            /// </summary>
            public const string ValidationResults = "Validation Results: {0}";

            #endregion Fields
        }

        #endregion Classes
    }
}