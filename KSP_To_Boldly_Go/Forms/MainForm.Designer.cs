namespace KSP_To_Boldly_Go.Forms
{
    partial class MainForm
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
            this.btnDevMode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDevMode
            // 
            this.btnDevMode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDevMode.Location = new System.Drawing.Point(209, 17);
            this.btnDevMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDevMode.Name = "btnDevMode";
            this.btnDevMode.Size = new System.Drawing.Size(112, 32);
            this.btnDevMode.TabIndex = 0;
            this.btnDevMode.Text = "Dev Editor";
            this.btnDevMode.UseVisualStyleBackColor = true;
            this.btnDevMode.Visible = false;
            this.btnDevMode.Click += new System.EventHandler(this.btnDevMode_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 250);
            this.Controls.Add(this.btnDevMode);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "To Boldly Go";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDevMode;
    }
}

