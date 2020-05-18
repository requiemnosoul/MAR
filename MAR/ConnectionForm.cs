using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MAR
{
    public partial class ConnectionForm : Form
    {
        public ConnectionForm()
        {
            InitializeComponent();
        }

        private void connButton_Click(object sender, EventArgs e)
        {
            connection(textBox1.Text,textBox2.Text,textBox3.Text,textBox4.Text);
        }

        void connection(string serv, string login, string pass, string database)
        {
            string myConnectionString = $"Server={serv}; Uid={login}; Pwd={pass}; Database = {database}";
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            try
            {
                conn.Open();
                MessageBox.Show("Ok");
                Form main = new MainForm(serv,login,pass,database);
                main.Show();
                Hide();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}