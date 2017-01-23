// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-23-2017
//
// Last Modified By : Mario
// Last Modified On : 01-23-2017
// ***********************************************************************
// <copyright file="CollectionEditor.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Windows.Forms;

namespace KSP_To_Boldly_Go.Common.UI
{
    /// <summary>
    /// KSP_To_Boldly_Go CollectionEditor.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.CollectionEditor" />
    public class CollectionEditor : System.ComponentModel.Design.CollectionEditor
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionEditor"/> class.
        /// </summary>
        /// <param name="type">The type of the collection for this editor to edit.</param>
        public CollectionEditor(Type type) : base(type)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Creates a new form to display and edit the current collection.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.Design.CollectionEditor.CollectionForm" /> to provide as the user interface for editing the collection.</returns>
        protected override CollectionForm CreateCollectionForm()
        {
            var collectionForm = base.CreateCollectionForm();

            var layout = collectionForm.Controls[0] as TableLayoutPanel;
            if (layout != null)
            {
                foreach (var item in layout.Controls)
                {
                    if (item is PropertyGrid)
                    {
                        ((PropertyGrid)item).PropertySort = PropertySort.Alphabetical;
                        ((PropertyGrid)item).ToolbarVisible = false;
                    }
                }
            }
            return collectionForm;
        }

        #endregion Methods
    }
}