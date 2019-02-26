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
            this.btnMin = new System.Windows.Forms.Button();
            this.btnMax = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.minColor = new KSP_To_Boldly_Go.Common.UI.ColorDialog();
            this.maxColor = new KSP_To_Boldly_Go.Common.UI.ColorDialog();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.txtMax = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMax)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMin
            // 
            this.pbMin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbMin.Location = new System.Drawing.Point(12, 68);
            this.pbMin.Name = "pbMin";
            this.pbMin.Size = new System.Drawing.Size(158, 57);
            this.pbMin.TabIndex = 0;
            this.pbMin.TabStop = false;
            // 
            // pbMax
            // 
            this.pbMax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbMax.Location = new System.Drawing.Point(266, 68);
            this.pbMax.Name = "pbMax";
            this.pbMax.Size = new System.Drawing.Size(158, 57);
            this.pbMax.TabIndex = 1;
            this.pbMax.TabStop = false;
            // 
            // btnMin
            // 
            this.btnMin.Location = new System.Drawing.Point(12, 167);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(158, 35);
            this.btnMin.TabIndex = 2;
            this.btnMin.Text = "Change";
            this.btnMin.UseVisualStyleBackColor = true;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnMax
            // 
            this.btnMax.Location = new System.Drawing.Point(266, 167);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(158, 35);
            this.btnMax.TabIndex = 3;
            this.btnMax.Text = "Change";
            this.btnMax.UseVisualStyleBackColor = true;
            this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(12, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 35);
            this.button1.TabIndex = 4;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(235, 227);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(189, 35);
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
            this.txtMin.Location = new System.Drawing.Point(12, 137);
            this.txtMin.Name = "txtMin";
            this.txtMin.ReadOnly = true;
            this.txtMin.Size = new System.Drawing.Size(158, 24);
            this.txtMin.TabIndex = 6;
            this.txtMin.TabStop = false;
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(266, 137);
            this.txtMax.Name = "txtMax";
            this.txtMax.ReadOnly = true;
            this.txtMax.Size = new System.Drawing.Size(158, 24);
            this.txtMax.TabIndex = 7;
            this.txtMax.TabStop = false;
            // 
            // ColorSelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 276);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.button1);
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMin;
        private System.Windows.Forms.PictureBox pbMax;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Button btnMax;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCancel;
        private Common.UI.ColorDialog minColor;
        private Common.UI.ColorDialog maxColor;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.TextBox txtMax;
    }
}