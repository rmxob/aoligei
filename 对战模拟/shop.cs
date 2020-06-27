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
    public partial class shop : Form
    {
        public shop()
        {
            InitializeComponent();
        }
        SqlConnection sql = new SqlConnection("server=.;database=红凯;uid=sa;pwd=123456");
        private void shop_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("商人.jpeg");
            sql.Open();
            string str = " select *from shop ";
            DataTable b = new DataTable();

            SqlDataAdapter c = new SqlDataAdapter(str, sql);
            c.Fill(b);
          
            dataGridView1.DataSource = b;
            sql.Close();
        }      
        public string shop_item;
        private void button1_Click(object sender, EventArgs e)
        {
            SSHOP shop = new SSHOP();           
            ATTACK aTTACK = new ATTACK();
                sql.Open();
                int ID = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex)+1;                            
                string shopcheck = "select *from shop where shop_id=" + ID;
                SqlCommand command_shop = new SqlCommand(shopcheck, sql);
                SqlDataReader reader = command_shop.ExecuteReader();
                while (reader.Read())
                {
                    shop_item = reader.GetString(reader.GetOrdinal("itemname"));
                }
                reader.Close();
            if (shop.losemoney(shop_item)==1)
            {
               aTTACK.bag_add(shop_item);
               MessageBox.Show("购买成功", "恭喜您");

            }
            else

            {
                MessageBox.Show("您的金钱不够哦");
            }
                
                sql.Close();
            
         
         
        }

        private void shop_FormClosing(object sender, FormClosingEventArgs e)
        {
            PERSON pERSON = new PERSON();
            int xy = pERSON.Tiqu_person_grade();
            Form1.form1.label1.Text = "人物属性\r\n名字：红凯 等级 : " + Convert.ToString(xy) + "\r\n血量 : " + Convert.ToString(pERSON.Tiqu_person_hp()) + "\r\n攻击力 ： " + Convert.ToString(pERSON.Tiqu_person_wuli()) + "\r\n";
            Form1.form1.label1.Text += "金钱：" + pERSON.Tiqu_person_money();
        }
    }
}
