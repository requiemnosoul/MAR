using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MAR
{
    public partial class MainForm : Form
    {
        private string serv, login, pass, db;
        private int widthStd;

        public MainForm(string serv1, string login1, string pass1, string db1, DataTable dt)
        {
            InitializeComponent();
            serv = serv1;
            login = login1;
            pass = pass1;
            db = db1;
            widthStd = Width;
            dataGridView1.DataSource = dt;
            dataGridView1.Height = dataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible) +
                                   dataGridView1.ColumnHeadersHeight;
            dataGridView1.Width = dataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) +
                                   dataGridView1.RowHeadersWidth;
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
            if (tabControl1.SelectedIndex == 3)
                Width = dataGridView1.Location.X + dataGridView1.Width + 20;
            else
                Width = widthStd;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //tabControl1_SelectedIndexChanged();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}