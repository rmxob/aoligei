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
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;
using 对战模拟.Properties;
namespace 对战模拟
{
  
    public partial class Form1 : Form
    {  public static Form1 form1;
        public Form1()
        {
            InitializeComponent();
            form1 = this;
        }

        public static uint SND_ASYNC = 0x0001;
        public static uint SND_FILENAME = 0x00020000;
        [DllImport("winmm.dll")]
        public static extern uint mciSendString(string lpstrCommand,
        string lpstrReturnString, uint uReturnLength, uint hWndCallback);
        public void Play()
        {

            mciSendString(@"close temp_alias", null, 0, 0);
            mciSendString(@"open ""音乐.mp3"" alias temp_alias", null, 0, 0);
            mciSendString("play temp_alias repeat", null, 0, 0);
          
        }
        public MUSIC music = new MUSIC();
        private void Form1_Load(object sender, EventArgs e)
        {
          
            Form1 a = new Form1();      
            music.PlayMusic(); 
            label1.BackColor = Color.Transparent;
            label1.Parent = pictureBox1;
            progressBar1.Visible = false;
            Image picture1 = Resources.背景;
            pictureBox1.Image = picture1;
          //  pictureBox2.Image = Image.FromFile("剑士.jpg");
            PERSON pERSON = new PERSON();
            int xy = pERSON.Tiqu_person_grade();
            label1.Text = "人物属性\r\n名字：红凯 等级 : "+Convert.ToString(xy)+"\r\n血量 : "+Convert.ToString(pERSON.Tiqu_change_hp())+"\r\n攻击力 ： "+ Convert.ToString(pERSON.Tiqu_person_wuli())+"\r\n";
            label1.Text += "金钱：" + pERSON.Tiqu_person_money();
        }
          SqlConnection sql = new SqlConnection("server=.;database=红凯;uid=sa;pwd=123456");
          public int personhp = 10, personwuli = 3, pethp = 9, petwuli = 1;


        public int person_hp;//函数用的定义
        
        private void button1_Click(object sender, EventArgs e)
        {
          
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            explore explore = new explore();
            explore.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Maximum = 10;
          //  progressBar1.Value = 0;
            progressBar1.Minimum = 0;
         for(int i=progressBar1.Minimum;i<=progressBar1.Maximum;i++)
            {
                System.Threading.Thread.Sleep(100);
                progressBar1.Value = i;
                this.Refresh();
            }
            PERSON pERSON = new PERSON();
            pERSON.blood_return();
          
            int xy = pERSON.Tiqu_person_grade();
            label1.Text = "人物属性\r\n名字：红凯 等级 : " + Convert.ToString(xy) + "\r\n血量 : " + Convert.ToString(pERSON.Tiqu_person_hp()) + "\r\n攻击力 ： " + Convert.ToString(pERSON.Tiqu_person_wuli())+"\r\n";
            label1.Text += "金钱：" + pERSON.Tiqu_person_money();
            MessageBox.Show("恢复成功", "提示");
           
            progressBar1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bag bag = new bag();
            bag.Show();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            shop shop = new shop();
            shop.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            monster_change a = new monster_change();
            a.Show();
        }

        public int ququhp,ququwuli,grade;
        public string equipment;
        private void button2_Click(object sender, EventArgs e)
        {
            

        }
    }
}
