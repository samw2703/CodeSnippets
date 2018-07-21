using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CodeSnippets
{
    public partial class FormAddEditLanguage : Form
    {
        public FormAddEditLanguage()
        {
            InitializeComponent();
        }

        public FormAddEditLanguage(AddEditFormState addEditFormState)
        {
            InitializeComponent();
        }
    }

    public enum AddEditFormState
    {
        Add = 0,
        Edit = 1
    }
}
