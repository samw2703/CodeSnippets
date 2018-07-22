using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeSnippets
{
    public partial class FormAddEditLanguage : Form
    {
        private List<Language> _languages; 

        public FormAddEditLanguage()
        {
            InitializeComponent();
        }

        public FormAddEditLanguage(AddEditFormState addEditFormState)
        {
            InitializeComponent();
        }

        private async Task<List<Language>> GetLanguages()
        {
            var languageDatabaseMethods = new LanguageDatabaseMethods();
            return await languageDatabaseMethods.Get();
        }

        private async void FormAddEditLanguage_Load(object sender, EventArgs e)
        {
            _languages = await GetLanguages();
            foreach (var language in _languages)
            {
                listBoxLanguages.Items.Add(language.Value);
            }
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxLanguage.Text == string.Empty)
                return;

            var langauge = new Language
            {
                Value = textBoxLanguage.Text.Trim()
            };
            var languageDatabaseMethods = new LanguageDatabaseMethods();
            await languageDatabaseMethods.Post(langauge);
            FormAddEditLanguage_Load(new Object(), new EventArgs());
            listBoxLanguages.Items.Clear();
        }
    }

    public enum AddEditFormState
    {
        Add = 0,
        Edit = 1
    }
}
