namespace KSP_To_Boldly_Go.Forms
{
    partial class ColorSelectorForm
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
            this.pbMin = new System.Windows.Forms.PictureBox();
            this.pbMax = new System.Windows.Forms.PictureBox();
            this.btnMin = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnMax = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnOk = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnCancel = new MaterialSkin.Controls.MaterialRaisedButton();
            this.minColor = new KSP_To_Boldly_Go.Common.UI.ColorDialog();
            this.maxColor = new KSP_To_Boldly_Go.Common.UI.ColorDialog();
            this.txtMin = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtMax = new MaterialSkin.Controls.MaterialSingleLineTextField();
            ((System.ComponentModel.ISupportInitialize)(this.pbMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMax)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMin
            // 
            this.pbMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbMin.Location = new System.Drawing.Point(12, 68);
            this.pbMin.Name = "pbMin";
            this.pbMin.Size = new System.Drawing.Size(158, 57);
            this.pbMin.TabIndex = 0;
            this.pbMin.TabStop = false;
            // 
            // pbMax
            // 
            this.pbMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbMax.Location = new System.Drawing.Point(266, 68);
            this.pbMax.Name = "pbMax";
            this.pbMax.Size = new System.Drawing.Size(158, 57);
            this.pbMax.TabIndex = 1;
            this.pbMax.TabStop = false;
            // 
            // btnMin
            // 
            this.btnMin.AutoSize = false;
            this.btnMin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.btnMin.Depth = 0;
            this.btnMin.Icon = null;
            this.btnMin.Location = new System.Drawing.Point(12, 167);
            this.btnMin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMin.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMin.Name = "btnMin";
            this.btnMin.Primary = false;
            this.btnMin.Size = new System.Drawing.Size(158, 36);
            this.btnMin.TabIndex = 2;
            this.btnMin.Text = "Change";
            this.btnMin.UseVisualStyleBackColor = true;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnMax
            // 
            this.btnMax.AutoSize = false;
            this.btnMax.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.btnMax.Depth = 0;
            this.btnMax.Icon = null;
            this.btnMax.Location = new System.Drawing.Point(266, 167);
            this.btnMax.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMax.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMax.Name = "btnMax";
            this.btnMax.Primary = false;
            this.btnMax.Size = new System.Drawing.Size(158, 36);
            this.btnMax.TabIndex = 3;
            this.btnMax.Text = "Change";
            this.btnMax.UseVisualStyleBackColor = true;
            this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = false;
            this.btnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.btnOk.Depth = 0;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Icon = null;
            this.btnOk.Location = new System.Drawing.Point(12, 227);
            this.btnOk.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOk.Name = "btnOk";
            this.btnOk.Primary = true;
            this.btnOk.Size = new System.Drawing.Size(158, 36);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = false;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.btnCancel.Depth = 0;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(266, 227);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Primary = true;
            this.btnCancel.Size = new System.Drawing.Size(158, 36);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // minColor
            // 
            this.minColor.Title = "";
            // 
            // maxColor
            // 
            this.maxColor.Title = "";
            // 
            // txtMin
            // 
            this.txtMin.Depth = 0;
            this.txtMin.Enabled = false;
            this.txtMin.Hint = "";
            this.txtMin.Location = new System.Drawing.Point(12, 137);
            this.txtMin.MaxLength = 32767;
            this.txtMin.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtMin.Name = "txtMin";
            this.txtMin.PasswordChar = '\0';
            this.txtMin.SelectedText = "";
            this.txtMin.SelectionLength = 0;
            this.txtMin.SelectionStart = 0;
            this.txtMin.Size = new System.Drawing.Size(158, 25);
            this.txtMin.TabIndex = 6;
            this.txtMin.TabStop = false;
            this.txtMin.UseSystemPasswordChar = false;
            // 
            // txtMax
            // 
            this.txtMax.Depth = 0;
            this.txtMax.Enabled = false;
            this.txtMax.Hint = "";
            this.txtMax.Location = new System.Drawing.Point(266, 137);
            this.txtMax.MaxLength = 32767;
            this.txtMax.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtMax.Name = "txtMax";
            this.txtMax.PasswordChar = '\0';
            this.txtMax.SelectedText = "";
            this.txtMax.SelectionLength = 0;
            this.txtMax.SelectionStart = 0;
            this.txtMax.Size = new System.Drawing.Size(158, 25);
            this.txtMax.TabIndex = 7;
            this.txtMax.TabStop = false;
            this.txtMax.UseSystemPasswordChar = false;
            // 
            // ColorSelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 276);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnMax);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.pbMax);
            this.Controls.Add(this.pbMin);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ColorSelectorForm";
            this.Text = "Color Selector";
            ((System.ComponentModel.ISupportInitialize)(this.pbMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMax)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMin;
        private System.Windows.Forms.PictureBox pbMax;
        private MaterialSkin.Controls.MaterialFlatButton btnMin;
        private MaterialSkin.Controls.MaterialFlatButton btnMax;
        private MaterialSkin.Controls.MaterialRaisedButton btnOk;
        private MaterialSkin.Controls.MaterialRaisedButton btnCancel;
        private Common.UI.ColorDialog minColor;
        private Common.UI.ColorDialog maxColor;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtMin;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtMax;
    }
}