namespace KSP_To_Boldly_Go.Forms
{
    partial class YesNoForm
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
            this.btnYes = new KSP_To_Boldly_Go.Controls.RaisedMaterialButton();
            this.btnNo = new KSP_To_Boldly_Go.Controls.RaisedMaterialButton();
            this.labMessage = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // btnYes
            // 
            this.btnYes.Depth = 0;
            this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnYes.Icon = null;
            this.btnYes.Location = new System.Drawing.Point(4, 172);
            this.btnYes.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnYes.Name = "btnYes";
            this.btnYes.Primary = true;
            this.btnYes.Size = new System.Drawing.Size(119, 31);
            this.btnYes.TabIndex = 0;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = true;
            // 
            // btnNo
            // 
            this.btnNo.Depth = 0;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNo.Icon = null;
            this.btnNo.Location = new System.Drawing.Point(163, 172);
            this.btnNo.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNo.Name = "btnNo";
            this.btnNo.Primary = true;
            this.btnNo.Size = new System.Drawing.Size(119, 31);
            this.btnNo.TabIndex = 1;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = true;
            // 
            // labMessage
            // 
            this.labMessage.Depth = 0;
            this.labMessage.Font = new System.Drawing.Font("Roboto", 11F);
            this.labMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labMessage.Location = new System.Drawing.Point(4, 69);
            this.labMessage.MouseState = MaterialSkin.MouseState.HOVER;
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(278, 89);
            this.labMessage.TabIndex = 3;
            // 
            // YesNoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 208);
            this.Controls.Add(this.labMessage);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "YesNoForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.RaisedMaterialButton btnYes;
        private Controls.RaisedMaterialButton btnNo;
        private MaterialSkin.Controls.MaterialLabel labMessage;
    }
}