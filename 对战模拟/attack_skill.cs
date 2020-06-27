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
using CCWin.SkinClass;

namespace 对战模拟
{
    public partial class attack_skill : Form
    {
        public attack_skill()
        {
            InitializeComponent();
        }
        SqlConnection sql = new SqlConnection("server=.;database=红凯;uid=sa;pwd=123456");
        PERSON person = new PERSON();
        MONSTER monster = new MONSTER();
        ATTACK bag = new ATTACK();
        public int monster_hp ;
        public string  monster_select;
        public int monster_experience,monster_money;
        public int person_changehp, monster_wuli;
        public string monster_equipment;
       
        private void attack_skill_Load(object sender, EventArgs e)
        {
              SKILL skill = new SKILL();
              string[] a = skill.Tiqu_Skill_name();
            if (monster_change.now_form.comboBox1.SelectedIndex >= 0)
            { monster_select = (string)monster_change.now_form.comboBox1.SelectedItem; }
            else if (monster_change.now_form.comboBox2.SelectedIndex >= 0)
            { monster_select = (string)monster_change.now_form.comboBox2.SelectedItem; }
            else if (monster_change.now_form.comboBox3.SelectedIndex >= 0)
            { monster_select = (string)monster_change.now_form.comboBox3.SelectedItem; }
            monster_hp = monster.Tiqu_monster_hp(monster_select);
            label3.Text ="怪物血量 ：" +Convert.ToString( monster.Tiqu_monster_hp(monster_select));
            label2.Text ="人物血量 : "+ Convert.ToString(person.Tiqu_change_hp());
            button1.Text =a[0];
            button2.Text = a[1];
            button3.Text = a[2];
            button4.Text = a[3];
            monster_experience = monster.Tiqu_monster_experience(monster_select);
            monster_equipment = monster.Tiqu_monster_equipment(monster_equipment);
            monster_money = monster.Tiqu_monster_money(monster_select);
            person_changehp = person.Tiqu_change_hp();
            monster_wuli = monster.Tiqu_monster_wuli(monster_select);
          Form1.form1.music.PlayMusic1();//战斗音乐
          
                pictureBox1.Image = Image.FromFile("战斗背景.jpg");
            skinPictureBox1.Image = Image.FromFile("头像.png");
           skinPictureBox2.Image = Image.FromFile("小青蛙.png");
           skinPictureBox3.Image = Image.FromFile("1.jpg");
           skill2.Image = Image.FromFile("skill2.gif");
           skill3.Image = Image.FromFile("skill3.gif");//图片载入 
            pictureBox2.Image = Image.FromFile("怪物攻击特效.gif");
            pictureBox2.Visible = false;
              skill1.Visible = false;
           skinPictureBox3.Visible = true;
            skill2.Visible = false;
            skill3.Visible = false;
            skill4.Visible = false;
            timer2.Enabled = false;
            timer3.Enabled = false;//控件的可见性                     
                                          
                 label2.BackColor = Color.Transparent;
            label2.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;
            label3.Parent = pictureBox1;
            skinPictureBox1.BackColor = Color.Transparent;
            skinPictureBox1.Parent = pictureBox1;
            skinPictureBox2.BackColor = Color.Transparent;
            skinPictureBox2.Parent = pictureBox1;//美化
           //美化

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            skinPictureBox3.Visible = false;
         
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            skinPictureBox1.Location = new System.Drawing.Point(360, 112);              
            skill2.Visible = true;
            timer2.Enabled = false;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            skinPictureBox1.Location = new System.Drawing.Point(12, 112);
            
            skill2.Visible = false;
            timer6.Enabled = true;
            timer3.Enabled = false;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(monster_hp>0)
            {
            SKILL skill = new SKILL();
            int skill_weili = skill.Tiqu_Skill_weili(button2.Text);
            label3.Text = "怪物血量 ：" + Convert.ToString( monster_hp - skill_weili);
            monster_hp -= skill_weili;
            timer2.Enabled = true;
            timer3.Enabled = true;
           
            }
            else
            {
                if(monster_equipment!=null)
                {
                    MessageBox.Show("战斗胜利，恭喜您获得经验 : " + monster_experience + " 获得装备 : " + monster_equipment + " 获得金钱 : " + monster_money, "战斗胜利！");
                    bag.bag_add(monster_equipment);
                }
                else
                {
                    MessageBox.Show("战斗胜利，恭喜您获得经验 : "  + monster_experience + " 获得金钱 : " + monster_money, " 战斗胜利！");
                }
                person.add_money(monster_select);
                person.add_experience(monster_select);
                monster_change change = new monster_change();
                change.Show();
                this.Close();
                
            }
           
            

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            skinPictureBox1.Location = new System.Drawing.Point(135, 112);
            skill3.Visible = true;
            timer4.Enabled = false;
           
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            skinPictureBox1.Location = new System.Drawing.Point(12, 112);  
            skill3.Visible = false;
            timer5.Enabled = false;
            timer6.Enabled = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer4.Enabled = true;
            timer5.Enabled = true;
        }

        private void skill3_Click(object sender, EventArgs e)
        {

        }

        private void skinPictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer6_Tick(object sender, EventArgs e)
        {
           skinPictureBox2.Location = new System.Drawing.Point(230,175);
            label2.Text = "人物血量 ：" + Convert.ToString(person_changehp - monster_wuli);
            pictureBox2.Visible = true;
            timer7.Enabled = true;
            timer6.Enabled = false;      
        }

      
        private void timer7_Tick_2(object sender, EventArgs e)
        {
            skinPictureBox2.Location = new System.Drawing.Point(550, 175);
            timer7.Enabled = false;
            pictureBox2.Visible = false;
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
