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

namespace 对战模拟
{
    public partial class bag : Form
    {
        public bag()
        {
            InitializeComponent();
        }
        public SqlConnection sql = new SqlConnection("server=.;database=红凯;uid=sa;pwd=123456");
        private void bag_Load(object sender, EventArgs e)
        {
            sql.Open();
            skinPictureBox1.Image = Image.FromFile("背包.jpg");
            string str = " select *from bag ";
            DataTable b = new DataTable();
            SqlDataAdapter c = new SqlDataAdapter(str, sql);
            c.Fill(b);
            dataGridView1.DataSource = b;
            sql.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

          string a= Convert.ToString(dataGridView1.CurrentCell.Value);
            SSHOP shop = new SSHOP();
           

            try
            {
                shop.useitems(a);
                MessageBox.Show("使用物品成功");
                    
                sql.Open();
                skinPictureBox1.Image = Image.FromFile("背包.jpg");
                string str = " select *from bag ";
                DataTable b = new DataTable();
                SqlDataAdapter c = new SqlDataAdapter(str, sql);
                c.Fill(b);
                dataGridView1.DataSource = b;
                sql.Close();
            }
            catch
            {
                MessageBox.Show("使用物品失败");
            }
           

        }
        private void bag_Leave(object sender, EventArgs e)
        {

        }

        private void bag_FormClosing(object sender, FormClosingEventArgs e)
        {
            PERSON pERSON = new PERSON();
            int xy = pERSON.Tiqu_person_grade();
            Form1.form1.label1.Text = "人物属性\r\n名字：红凯 等级 : " + Convert.ToString(xy) + "\r\n血量 : " + Convert.ToString(pERSON.Tiqu_change_hp()) + "\r\n攻击力 ： " + Convert.ToString(pERSON.Tiqu_person_wuli()) + "\r\n";

        }
    }
}
