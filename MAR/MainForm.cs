using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MAR
{
    public partial class MainForm : Form
    {
        private string serv, login, pass, db;
        public MainForm(string serv1, string login1, string pass1, string db1)
        {
            InitializeComponent();
            serv = serv1;
            login = login1;
            pass = pass1;
            db = db1;
        }

        private void addRights_Click(object sender, EventArgs e)
        {
            
        }

        public void AddRights()
        {
            string secondName = textBox1.Text, firstName = textBox2.Text, middleName = textBox3.Text;
            string infSys = comboBox1.Text;
            
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (tabControl1.SelectedIndex == 3)
                MessageBox.Show("Enter 3");*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //tabControl1_SelectedIndexChanged();
        }
    }
}