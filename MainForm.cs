using WinForms.Repositories;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
    }
}
