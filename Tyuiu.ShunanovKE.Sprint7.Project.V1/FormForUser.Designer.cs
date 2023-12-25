
namespace Tyuiu.ShunanovKE.Sprint7.Project.V1
{
    partial class FormForUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormForUser));
            this.labelIntro_SKE = new System.Windows.Forms.Label();
            this.labelOpening_SKE = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelIntro_SKE
            // 
            this.labelIntro_SKE.AutoSize = true;
            this.labelIntro_SKE.Location = new System.Drawing.Point(12, 24);
            this.labelIntro_SKE.Name = "labelIntro_SKE";
            this.labelIntro_SKE.Size = new System.Drawing.Size(540, 13);
            this.labelIntro_SKE.TabIndex = 0;
            this.labelIntro_SKE.Text = "Данный проект создан для чтения, редактирования и сортировки данных о авторемонтн" +
    "ых мастерских.";
            // 
            // labelOpening_SKE
            // 
            this.labelOpening_SKE.AutoSize = true;
            this.labelOpening_SKE.Location = new System.Drawing.Point(12, 80);
            this.labelOpening_SKE.Name = "labelOpening_SKE";
            this.labelOpening_SKE.Size = new System.Drawing.Size(346, 117);
            this.labelOpening_SKE.TabIndex = 1;
            this.labelOpening_SKE.Text = resources.GetString("labelOpening_SKE.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(278, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Раздел \"Добавить автомастерскую\"";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Входные данные";
            // 
            // FormForUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 624);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelOpening_SKE);
            this.Controls.Add(this.labelIntro_SKE);
            this.Name = "FormForUser";
            this.Text = "Руководство пользователя";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelIntro_SKE;
        private System.Windows.Forms.Label labelOpening_SKE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}