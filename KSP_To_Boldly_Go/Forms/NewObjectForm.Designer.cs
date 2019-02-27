namespace KSP_To_Boldly_Go.Forms
{
    partial class NewObjectForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbList = new System.Windows.Forms.ComboBox();
            this.btnOk = new Controls.RaisedMaterialButton();
            this.btnCancel = new Controls.RaisedMaterialButton();
            this.SuspendLayout();
            // 
            // cbList
            // 
            this.cbList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbList.FormattingEnabled = true;
            this.cbList.Location = new System.Drawing.Point(13, 74);
            this.cbList.Margin = new System.Windows.Forms.Padding(4);
            this.cbList.Name = "cbList";
            this.cbList.Size = new System.Drawing.Size(395, 26);
            this.cbList.TabIndex = 0;
            this.cbList.SelectedIndexChanged += new System.EventHandler(this.cbList_SelectedIndexChanged);
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = false;
            this.btnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.btnOk.Depth = 0;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Icon = null;
            this.btnOk.Location = new System.Drawing.Point(13, 119);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOk.Name = "btnOk";
            this.btnOk.Primary = true;
            this.btnOk.Size = new System.Drawing.Size(175, 36);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = false;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.btnCancel.Depth = 0;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(233, 119);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Primary = true;
            this.btnCancel.Size = new System.Drawing.Size(175, 36);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // NewObjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 168);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cbList);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "NewObjectForm";
            this.Text = "Select object type";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbList;
        private Controls.RaisedMaterialButton btnOk;
        private Controls.RaisedMaterialButton btnCancel;
    }
}