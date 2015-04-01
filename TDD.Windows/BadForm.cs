using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
    public partial class BadForm : Form
    {
        public BadForm()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=CodeFirst;Integrated Security=True;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from book where title like %" + searchTextbox.Text + "%", conn);
            SqlDataReader r = cmd.ExecuteReader();
            mainGridView.DataSource = r;
        }
    }
}
