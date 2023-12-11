
namespace Tyuiu.ShunanovKE.Sprint7.Project.V1
{
    partial class FormMain
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
            this.panelUp_SKE = new System.Windows.Forms.Panel();
            this.buttonAbout_SKE = new System.Windows.Forms.Button();
            this.panelUp_SKE.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelUp_SKE
            // 
            this.panelUp_SKE.Controls.Add(this.buttonAbout_SKE);
            this.panelUp_SKE.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUp_SKE.Location = new System.Drawing.Point(0, 0);
            this.panelUp_SKE.Name = "panelUp_SKE";
            this.panelUp_SKE.Size = new System.Drawing.Size(800, 100);
            this.panelUp_SKE.TabIndex = 0;
            // 
            // buttonAbout_SKE
            // 
            this.buttonAbout_SKE.Location = new System.Drawing.Point(713, 12);
            this.buttonAbout_SKE.Name = "buttonAbout_SKE";
            this.buttonAbout_SKE.Size = new System.Drawing.Size(75, 23);
            this.buttonAbout_SKE.TabIndex = 0;
            this.buttonAbout_SKE.Text = "Справка";
            this.buttonAbout_SKE.UseVisualStyleBackColor = true;
            this.buttonAbout_SKE.Click += new System.EventHandler(this.buttonAbout_SKE_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelUp_SKE);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.panelUp_SKE.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelUp_SKE;
        private System.Windows.Forms.Button buttonAbout_SKE;
    }
}

