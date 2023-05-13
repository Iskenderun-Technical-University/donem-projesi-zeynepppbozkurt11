using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace halstok
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("data source=ZEYNEP\\SQLEXPRESS;Initial Catalog=halstok;Integrated Security=true");
        private void verilerigörüntüle()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("select *from hal", baglan);
            SqlDataReader oku=komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle= new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["meyvead"].ToString());
                ekle.SubItems.Add(oku["meyvesirketi"].ToString());
                ekle.SubItems.Add(oku["meyvekilogrami"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            verilerigörüntüle();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Insert into hal(id,meyvead,meyvesirketi,meyvekilogrami)values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigörüntüle() ;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            

        }
        int id = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("delete from hal where id=(" + id + ")", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigörüntüle();    

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update hal set id='"+textBox1.Text.ToString()+"',meyvead='"+textBox2.Text.ToString()+"',meyvesirketi='"+textBox3.Text.ToString()+"',meyvekilogrami='"+textBox4.Text.ToString()+"'where id="+id+"",baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigörüntüle();
        }
    }
}
