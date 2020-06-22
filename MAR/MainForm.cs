using System;
using System.Data;
using System.IO;
using System.Text;
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
            AddRights();
        }

        public void AddRights()
        {
            string method = "";
            if (readChBox.Checked)
                method += "Read ";
            if (writeChBox.Checked)
                method += "Write ";
            if (deleteChBox.Checked)
                method += "Delete";
            if (checkBox1.Checked)
                method = "Заблокирован";
            string secondName = textBox1.Text, firstName = textBox2.Text, middleName = textBox3.Text;
            string infSys = comboBox1.Text;
            
            DataTable dataTable = (DataTable)dataGridView1.DataSource;
            DataRow drToAdd = dataTable.NewRow();
            drToAdd["name"] = secondName +" "+ firstName +" "+ middleName;
            drToAdd["name_position"] = textBox13.Text;
            drToAdd["data_start_r"] = dateTimePicker1.Value.ToShortDateString().ToString();
            drToAdd["data_end_r"] = dateTimePicker2.Value.ToShortDateString().ToString();
            drToAdd["name_is"] = infSys;
            drToAdd["short_name_is"] = infSys;
            drToAdd["name_method"] = method;
            bool b = true;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (dataTable.Rows[i]["name"].ToString() == secondName + " " + firstName + " " + middleName)
                {
                    dataTable.Rows[i]["name_method"] = method;
                    b = false;
                    break;
                }
            }
            if(b)
                dataTable.Rows.Add(drToAdd);
            dataTable.AcceptChanges();
            dataGridView1.Refresh();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 3)
                Width = dataGridView1.Location.X + dataGridView1.Width + 20;
            else
                Width = widthStd;
            if(tabControl1.SelectedIndex == 2)
                zayav();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form rep = new report();
            rep.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "" &&
                textBox5.Text != "" &&
                textBox6.Text != "" &&
                textBox7.Text != "" &&
                textBox8.Text != "" &&
                textBox9.Text != "" &&
                textBox10.Text != "" &&
                textBox11.Text != "" &&
                textBox12.Text != "" &&
                comboBox2.Text != "")
            {
                using (StreamWriter sw = new StreamWriter(@"log.txt", true))
                {
                    sw.WriteLine();
                    sw.WriteLine("Name:"+textBox4.Text + " " + textBox5.Text + " " + textBox6.Text + " " + textBox10.Text);
                    sw.WriteLine(textBox7.Text);
                    sw.WriteLine(textBox8.Text);
                    sw.WriteLine(textBox9.Text);
                    sw.WriteLine("Index:" + textBox10.Text);
                    sw.WriteLine(textBox11.Text);
                    sw.WriteLine(textBox12.Text);
                    sw.WriteLine(comboBox2.Text);
                    MessageBox.Show("Добавлено!");
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            zayav();
        }

        void zayav()
        {
            using (StreamReader sr = new StreamReader(@"log.txt"))
            {
                dataGridView2.Rows.Clear();
                int a = 0;
                while (!sr.EndOfStream)
                {
                    string st = sr.ReadLine();
                    if (st.StartsWith("Name:"))
                    {
                        var temp = st.Split(' ');
                        temp[temp.Length - 1] = "";
                        dataGridView2.Rows.Add();
                        dataGridView2.Rows[a].Cells[0].Value = "Заявка " + (a + 1);
                        dataGridView2.Rows[a].Cells[1].Value = string.Join(" ", temp).Substring(5);
                        dataGridView2.Rows[a].Cells[2].Value = st.Substring(st.LastIndexOf(' ')).TrimStart();
                        a++;
                    }
                }
            }
            dataGridView2.Refresh();
        }
    }
}