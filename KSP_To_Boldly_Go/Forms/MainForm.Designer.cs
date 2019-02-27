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
            this.btnDevMode = new KSP_To_Boldly_Go.Controls.FlatMaterialButton();
            this.cbTheme = new MaterialSkin.Controls.MaterialComboBox();
            this.SuspendLayout();
            // 
            // btnDevMode
            // 
            this.btnDevMode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDevMode.Depth = 0;
            this.btnDevMode.Icon = null;
            this.btnDevMode.Location = new System.Drawing.Point(451, 73);
            this.btnDevMode.Margin = new System.Windows.Forms.Padding(4);
            this.btnDevMode.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDevMode.Name = "btnDevMode";
            this.btnDevMode.Primary = false;
            this.btnDevMode.Size = new System.Drawing.Size(112, 32);
            this.btnDevMode.TabIndex = 0;
            this.btnDevMode.Text = "Dev Editor";
            this.btnDevMode.UseVisualStyleBackColor = true;
            this.btnDevMode.Visible = false;
            this.btnDevMode.Click += new System.EventHandler(this.btnDevMode_Click);
            // 
            // cbTheme
            // 
            this.cbTheme.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbTheme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.cbTheme.Depth = 0;
            this.cbTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cbTheme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbTheme.FormattingEnabled = true;
            this.cbTheme.Location = new System.Drawing.Point(12, 77);
            this.cbTheme.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbTheme.Name = "cbTheme";
            this.cbTheme.Size = new System.Drawing.Size(190, 24);
            this.cbTheme.TabIndex = 1;
            this.cbTheme.SelectedIndexChanged += new System.EventHandler(this.cbTheme_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 250);
            this.Controls.Add(this.cbTheme);
            this.Controls.Add(this.btnDevMode);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "To Boldly Go";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.FlatMaterialButton btnDevMode;
        private MaterialSkin.Controls.MaterialComboBox cbTheme;
    }
}

