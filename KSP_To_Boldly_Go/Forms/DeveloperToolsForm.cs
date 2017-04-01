// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 04-01-2017
// ***********************************************************************
// <copyright file="DeveloperToolsForm.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using KSP_To_Boldly_Go.Common.Models;
using KSP_To_Boldly_Go.Common.Serializers;
using KSP_To_Boldly_Go.Common.Validators;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        public DeveloperToolsForm()
        {
            InitializeComponent();
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
            var files = Directory.EnumerateFileSystemEntries(Configuration.JsonConfigPath, "*.json", SearchOption.AllDirectories);
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
            openFileDialog1.InitialDirectory = Configuration.JsonConfigPath;
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
            var form = new NewObjectForm();
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
                    saveFileDialog1.InitialDirectory = Configuration.JsonConfigPath;
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
                    var serializer = new KopernicusSerializer("To Boldly Go".GetHashCode());
                    serializer.Serialize(model, ms);
                    var output = Encoding.ASCII.GetString(ms.ToArray());
                    var form = new GenericOutputForm(string.Format("Serialization Test Output: {0}", path), output);
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
            var form = new GenericOutputForm(string.Format("Validation Results: {0}", Configuration.JsonConfigPath), string.Join(Environment.NewLine, validationResults));
            form.ShowDialog(this);
            form.Dispose();
        }

        #endregion Methods
    }
}