using WinForms.Repositories;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.CodeDom.Compiler;

namespace WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateLanguatesListAsync();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddLanguageAsync();
        }

        private async void updateLanguatesListAsync()
        {
            this.listBoxLanguages.Items.Clear();
            this.listBoxLanguages.Items.Add("Loading...");

            List<Language> languages = await LanguagesRepository.All();

            this.listBoxLanguages.Items.Clear();
            languages.ForEach(l => this.listBoxLanguages.Items.Add(l.Title));
        }

        private async void AddLanguageAsync() 
        {
            if (String.IsNullOrEmpty(this.textBoxNewLanguage.Text)) 
            {
                return;
            }

            Language language = new Language();
            language.Title = this.textBoxNewLanguage.Text;

            bool success = await LanguagesRepository.Add(language);

            if (success) 
            {
                updateLanguatesListAsync();
            }
        }
        private async void UpdateLanguageAsync()
        {
            if (String.IsNullOrEmpty(this.textBoxUpdate.Text))
            {
                return;
            }
            
            List<Language> languages = await LanguagesRepository.All();
            Language Update = new Language();
            languages.ForEach(x=> 
            { 
                if (x.Title == (string)listBoxLanguages.SelectedItem) 
                {
                    Update.Id = x.Id;
                    Update.Title = textBoxUpdate.Text;
                }
            } );

            bool success = await LanguagesRepository.Update(Update);

            if (success)
            {
                updateLanguatesListAsync();
            }
        }

        private async void DeleteLanguageAsync()
        {
            //if (String.IsNullOrEmpty(this.textBoxNewLanguage.Text))
            //{
            //    return;
            //}

            List<Language> languages = await LanguagesRepository.All();
            Language Update = new Language();
            languages.ForEach(x =>
            {
                if (x.Title == (string)listBoxLanguages.SelectedItem)
                {
                    Update.Id = x.Id;
                }
            });

            bool success = await LanguagesRepository.Delete(Update.Id);

            if (success)
            {
                updateLanguatesListAsync();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            UpdateLanguageAsync();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteLanguageAsync();
        }
    }
}
