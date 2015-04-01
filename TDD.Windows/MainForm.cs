using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDD.Services.Library;
using TDD.Services.Library.IoC;
using TDD.Services.Library.TransportObjects;

namespace TDD.Windows
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            BookController c = new BookController();
            mainGridView.DataSource = c.Search(searchTextbox.Text);
        }
    }
}
