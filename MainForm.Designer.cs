namespace WinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxLanguages = new System.Windows.Forms.ListBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBoxUpdate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNewLanguage = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxLanguages
            // 
            this.listBoxLanguages.FormattingEnabled = true;
            this.listBoxLanguages.ItemHeight = 15;
            this.listBoxLanguages.Location = new System.Drawing.Point(190, 120);
            this.listBoxLanguages.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxLanguages.Name = "listBoxLanguages";
            this.listBoxLanguages.Size = new System.Drawing.Size(207, 139);
            this.listBoxLanguages.TabIndex = 0;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(3, 50);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(519, 30);
            this.buttonUpdate.TabIndex = 2;
            this.buttonUpdate.Text = "Обновить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBoxUpdate);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.buttonUpdate);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(528, 85);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Обновление";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBoxUpdate
            // 
            this.textBoxUpdate.Location = new System.Drawing.Point(3, 22);
            this.textBoxUpdate.Name = "textBoxUpdate";
            this.textBoxUpdate.Size = new System.Drawing.Size(518, 23);
            this.textBoxUpdate.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(491, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Выберите язык из списка, нажмите на него, а затем напишите его измененный вариант" +
    "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBoxNewLanguage);
            this.tabPage1.Controls.Add(this.buttonAdd);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(528, 85);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Добавление";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Напишите название нового языка, а затем нажмите кнопку добавления";
            // 
            // textBoxNewLanguage
            // 
            this.textBoxNewLanguage.Location = new System.Drawing.Point(3, 18);
            this.textBoxNewLanguage.Name = "textBoxNewLanguage";
            this.textBoxNewLanguage.Size = new System.Drawing.Size(519, 23);
            this.textBoxNewLanguage.TabIndex = 4;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(2, 49);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(519, 28);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 2;
            this.tabControl1.Size = new System.Drawing.Size(536, 113);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.buttonDelete);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(528, 85);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Удаление";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(4, 32);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(519, 30);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(340, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Выберите язык из списка, а затем нажмите кнопку удаления";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 280);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.listBoxLanguages);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Список Языков";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxLanguages;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNewLanguage;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox textBoxUpdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label label3;
    }
}

