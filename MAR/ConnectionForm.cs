using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MAR
{
    public partial class ConnectionForm : Form
    {
        private string sql = 
            "SELECT name, name_position, data_start_r, data_end_r, name_is, short_name_is, name_method FROM face JOIN employee_role, position, access_rights, inf_s, access_method WHERE (id_f = kod_f_e) AND (id_p = kod_p_e) AND (id_e = kod_e_r) AND (id_is = kod_is_r) AND (id_m = kod_m_r)";
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
                MessageBox.Show("Подключено");
                Form main = new MainForm(serv,login,pass,database, myCommand(sql));
                main.Show();
                Hide();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            DataTable myCommand(string sql)
            {
                MySqlCommand cmd = new MySqlCommand(sql,conn);
                DataTable dt = new DataTable();
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dt.Load(dr);
                    }
                }
                conn.Close();
                return dt;
            }
        }
    }
}