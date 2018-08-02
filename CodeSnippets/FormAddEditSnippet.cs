using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeSnippets
{
    public partial class FormAddEditSnippet : Form
    {
        private IEnumerable<Language> _languages;
        private Language _selectedLanguage;
        private List<Snippet> _snippetsForChosenLanguage;

        public FormAddEditSnippet()
        {
            _languages = new List<Language>();
            _selectedLanguage = new Language();
            _snippetsForChosenLanguage = new List<Snippet>();
            InitializeComponent();
        }

        public event EventHandler SnippetAddedOrEdited;

        protected virtual void OnSnippetAddedOrEdited(EventArgs e)
        {
            if (SnippetAddedOrEdited != null)
                SnippetAddedOrEdited(this, e);
        }

        private async void FormAddEditSnippet_Load(object sender, EventArgs e)
        {
            await GetLanguages();
            PopulateComboBoxLanguages();
        }

        private async Task GetLanguages()
        {
            var languageDatabaseMethods = new LanguageDatabaseMethods();
            _languages = await languageDatabaseMethods.Get();
        }

        private void PopulateComboBoxLanguages()
        {
            foreach (var language in _languages)
            {
                comboBoxLanguages.Items.Add(language.Value);
            }
        }

        private async void comboBoxLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            _selectedLanguage = _languages.Single(x => x.Value.ToLower() == comboBox.SelectedItem.ToString().ToLower());
            await GetSnippetsForChosenLanguage();
            PopulateListBoxSnippets();
        }

        private async Task GetSnippetsForChosenLanguage()
        {
            var snippetDatabaseMethods = new SnippetDatabaseMethods();
            _snippetsForChosenLanguage = await snippetDatabaseMethods.GetForLanguage(_selectedLanguage);
        }

        private void PopulateListBoxSnippets()
        {
            foreach (var snippet in _snippetsForChosenLanguage)
            {
                listBoxSnippets.Items.Add(snippet.Key);
            }
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxKey.Text == string.Empty || textBoxValue.Text == string.Empty)
                return;

            var snippet = new Snippet()
            {
                LanguageId = _selectedLanguage.Id,
                Key = textBoxKey.Text.Trim(),
                Value = textBoxValue.Text.Trim()
            };
            var snippetDatabaseMethods = new SnippetDatabaseMethods();
            await snippetDatabaseMethods.Post(snippet);
        }
    }
}
