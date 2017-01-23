// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 01-22-2017
// ***********************************************************************
// <copyright file="DeveloperToolsForm.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using KSP_To_Boldly_Go.Common.Models;
using KSP_To_Boldly_Go.Common.Serializers;
using Newtonsoft.Json;
using System;
using System.IO;
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
        private object model = null;

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
        /// Handles the Click event of the serializeTestToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void serializeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (model != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    // for test purposes we use year this project was started in :)
                    var serializer = new KopernicusSerializer(2017);
                    serializer.Serialize((IKopernicusObject)model, ms);
                    var output = Encoding.ASCII.GetString(ms.ToArray());
                    var form = new SerializationTestOutputForm(output);
                    form.ShowDialog(this);
                    form.Dispose();
                }
            }
        }

        #endregion Methods
    }
}