﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using KeyEventArgs = System.Windows.Forms.KeyEventArgs;

namespace CodeSnippets
{
    public partial class FormMain : Form
    {
        private List<Language> _languages;
        private List<Snippet> _snippets;
        private List<Snippet> _filteredSnippets;
        private string _typedString;
        private int _keyIndex;
        private Snippet _currentSnippet;

        public FormMain()
        {
            InitializeComponent();
            _languages = new List<Language>();
            _snippets = new List<Snippet>();
            _filteredSnippets = new List<Snippet>();
            _currentSnippet = new Snippet();
        }

        private async Task PopulateLanguageDropdown()
        {
            comboBoxLanguage.Items.Clear();
            _languages = await GetLanguages();
            foreach (var language in _languages)
            {
                comboBoxLanguage.Items.Add(language.Value);
            }
        }

        private async Task<List<Language>> GetLanguages()
        {
            var languageDatabaseMethods = new LanguageDatabaseMethods();
            return await languageDatabaseMethods.Get();
        }

        private async void FormMain_Load(object sender, EventArgs e)
        {
            await PopulateLanguageDropdown();
        }

        private void textBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                e.IsInputKey = true;
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (_filteredSnippets.Count == 0)
                return;
            else if (KeyboardHelper.IsKeyDown(Key.LeftCtrl) && e.KeyCode == Keys.Tab)
            {
                RemoveThing();
                DisplayValue();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Tab)
            {
                RemoveThing();
                DisplayKey(_keyIndex);
                _keyIndex = ++_keyIndex % _filteredSnippets.Count;
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (KeyboardHelper.IsKeyALetter(e.KeyCode))
            {
                _typedString += e.KeyCode.ToString();
                _filteredSnippets = _snippets
                    .Where(x => x.Key.ToLower().Contains(_typedString.ToLower()))
                    .ToList();
            }
            else if (e.KeyCode == Keys.ControlKey)
                return;
            else
            {
                Reset();
            }
        }

        private void Reset()
        {
            _filteredSnippets = new List<Snippet>();
            _currentSnippet = new Snippet();
            _keyIndex = 0;
            _typedString = string.Empty;
        }

        private void DisplayValue()
        {
            textBox.Text = textBox.Text.Insert(textBox.SelectionStart, _currentSnippet.Value);
            textBox.SelectionStart += _currentSnippet.Value.Length;
        }

        private void DisplayKey(int index)
        {
            _currentSnippet = _filteredSnippets[index];
            textBox.Text = textBox.Text.Insert(textBox.SelectionStart, _currentSnippet.Key);
            textBox.SelectionStart += _currentSnippet.Key.Length;
        }

        private void RemoveThing()
        {
            var cursorIndex = textBox.SelectionStart;
            var endIndex = cursorIndex;
            while (cursorIndex != 0 && !Char.IsWhiteSpace(textBox.Text[cursorIndex - 1]))
            {
                cursorIndex--;
            }
            textBox.Text = textBox.Text.Remove(cursorIndex, endIndex - cursorIndex);
            textBox.SelectionStart = cursorIndex;
        }

        private async void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = (ComboBox) sender;
            var selectedLanaguage = _languages.Single(x => x.Value.ToLower() == comboBox.SelectedItem.ToString().ToLower());
            var snippetDatabaseMethods = new SnippetDatabaseMethods();
            _snippets = await snippetDatabaseMethods.GetForLanguage(selectedLanaguage);
        }

        private async void buttonNewLanguage_Click(object sender, EventArgs e)
        {
            var formAddEditLanguage = new FormAddEditLanguage();
            formAddEditLanguage.LanguageAddedOrEdited += async (s, ev) => await PopulateLanguageDropdown();
            formAddEditLanguage.Show();
        }

        private void buttonNewSnippet_Click(object sender, EventArgs e)
        {
            var formAddEditSnippet = new FormAddEditSnippet();
            formAddEditSnippet.Show();
        }
    }

    public static class KeyboardHelper
    {
        private static readonly IEnumerable<Keys> _letterKeys = new List<Keys>
        {
            Keys.A,
            Keys.B,
            Keys.C,
            Keys.D,
            Keys.E,
            Keys.F,
            Keys.G,
            Keys.H,
            Keys.I,
            Keys.J,
            Keys.K,
            Keys.L,
            Keys.M,
            Keys.N,
            Keys.O,
            Keys.P,
            Keys.Q,
            Keys.R,
            Keys.S,
            Keys.T,
            Keys.U,
            Keys.V,
            Keys.W,
            Keys.X,
            Keys.Y,
            Keys.Z
        }.AsEnumerable(); 

        public static bool IsKeyDown(Key key)
        {
            return Keyboard.IsKeyDown(key);
        }

        public static bool IsKeyALetter(Keys key)
        {
            return _letterKeys.Contains(key);
        }
    }
}
