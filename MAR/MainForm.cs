using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MAR
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void addRights_Click(object sender, EventArgs e)
        {
            
        }

        public void AddRights()
        {
            string secondName = textBox1.Text, firstName = textBox2.Text, middleName = textBox3.Text;
            string infSys = comboBox1.Text;
            
            
        }
    }
}