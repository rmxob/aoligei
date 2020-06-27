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
namespace 对战模拟
{
    public partial class explore : Form
    {
        public explore()
        {
            InitializeComponent();
        }
        SqlConnection sql = new SqlConnection("server=.;database=红凯;uid=sa;pwd=123456");
        private void explore_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            label1.Parent = pictureBox2;
           
            label2.BackColor = Color.Transparent;
            label2.Parent = pictureBox2;
            pictureBox2.Image = Image.FromFile("背景2.jpg");
          panel1.Visible = false;

        }
        public int ququ_hp, ququ_wuli, grade,person_hp,person_wuli;

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void explore_FormClosing(object sender, FormClosingEventArgs e)
        {
         
        }

        private void explore_FormClosed(object sender, FormClosedEventArgs e)
        {
            PERSON pERSON = new PERSON();
            int xy = pERSON.Tiqu_person_grade();
     Form1.form1.label1.Text = "人物属性\r\n名字：红凯 等级 : " + Convert.ToString(xy) + "\r\n血量 : " + Convert.ToString(pERSON.Tiqu_change_hp()) + "\r\n攻击力 ： " + Convert.ToString(pERSON.Tiqu_person_wuli())+"\r\n";

            Form1.form1.label1.Text += "金钱：" + pERSON.Tiqu_person_money();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            PERSON pERSON = new PERSON();
            try
            {
                pERSON.add_money("小蛐蛐");
            }
            catch

            {
                MessageBox.Show("           ");
            }


        }

        private void button2_Click_2(object sender, EventArgs e)
        {
        }

        private void button2_Click_3(object sender, EventArgs e)
        {
            ATTACK aTTACK = new ATTACK();
            aTTACK.bag_add("小蛐蛐的腿");

        }

        public string equipment;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                richTextBox1.Text += "小蛐蛐，一级，攻击力一，击败掉落：小蛐蛐的腿，小蛐蛐精元等\r\n";
               
                pictureBox1.Image = Image.FromFile("小蛐蛐.jpg");
            }
            if (comboBox1.SelectedIndex == 1)
            {
                richTextBox1.Text += "小蚂蚁，二级，攻击力二，击败掉落：小米粒等\r\n";

                pictureBox1.Image = Image.FromFile("小蚂蚁.jpg");
            }
            if (comboBox1.SelectedIndex == 2)
            {
                richTextBox1.Text += "大蜘蛛，三级，攻击力五，击败掉落：大蜘蛛精元等\r\n";

                pictureBox1.Image = Image.FromFile("小蜘蛛.jpeg");
            }
            if (comboBox1.SelectedIndex == 3)
            {
                richTextBox1.Text += "小青蛙，四级，攻击力七，击败掉落：小蝌蚪等\r\n";

                pictureBox1.Image = Image.FromFile("小青蛙.jpg");
            }
            if (comboBox1.SelectedIndex == 4)
            {
                richTextBox1.Text += "小青蛇，五级，攻击力八，击败掉落：蛇的内胆等\r\n";

                pictureBox1.Image = Image.FromFile("小青蛇.jpg");
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)//游标到底
        {
           // richTextBox1.AppendText(" ");
            richTextBox1.ScrollToCaret();
            this.richTextBox1.Focus();
            this.richTextBox1.Select(this.richTextBox1.TextLength, 0);
            this.richTextBox1.ScrollToCaret();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            PERSON person1 = new PERSON();
            MONSTER monster1 = new MONSTER();
            if (comboBox1.SelectedIndex == 0)
            {
             if(person1.attack(comboBox1.SelectedItem.ToString()) ==1)
             {
                richTextBox1.Text += "战斗成功，您获得了经验值："+Convert.ToString(monster1.Tiqu_monster_experience(comboBox1.SelectedItem.ToString()))+"\r\n"+"您目前的等级为:"+Convert.ToString(person1.Tiqu_person_grade())+"\r\n";
                    richTextBox1.Text += "您的血量还剩余：" + Convert.ToString(person1.Tiqu_change_hp())+"\r\n";
                    richTextBox1.Text += "您获得金钱：" + Convert.ToString(monster1.Tiqu_monster_money(comboBox1.SelectedItem.ToString()))+ "\r\n";
                    if (monster1.Tiqu_monster_equipment(comboBox1.SelectedItem.ToString()) != null)
                        richTextBox1.Text += "恭喜您获得了装备" + monster1.Tiqu_monster_equipment(comboBox1.SelectedItem.ToString())+"\r\n";
                    else
                    {

                        richTextBox1.Text += "战斗结束，您什么也没有获得\r\n";
                    }
             }
            else
            {
                richTextBox1.Text += "战斗失败，人物已死亡，请回城复活\r\n";
            }
            }
            if (comboBox1.SelectedIndex ==1)
            {
                if (person1.attack(comboBox1.SelectedItem.ToString()) == 1)
                {
                    richTextBox1.Text += "战斗成功，您获得了经验值：" + Convert.ToString(monster1.Tiqu_monster_experience(comboBox1.SelectedItem.ToString())) + "\r\n" + "您目前的等级为:" + Convert.ToString(person1.Tiqu_person_grade()) + "\r\n";
                    richTextBox1.Text += "您的血量还剩余：" + Convert.ToString(person1.Tiqu_change_hp()) + "\r\n";
                    richTextBox1.Text += "您获得金钱：" + Convert.ToString(monster1.Tiqu_monster_money(comboBox1.SelectedItem.ToString())) + "\r\n";
                    if (monster1.Tiqu_monster_equipment(comboBox1.SelectedItem.ToString()) != null)
                        richTextBox1.Text += "恭喜您获得了装备" + monster1.Tiqu_monster_equipment(comboBox1.SelectedItem.ToString()) + "\r\n";
                    else
                    {

                        richTextBox1.Text += "战斗结束，您什么也没有获得\r\n";
                    }
                }
                else
                {
                    richTextBox1.Text += "战斗失败，人物已死亡，请回城复活\r\n";
                }
            }
            if (comboBox1.SelectedIndex == 2)
            {
                if (person1.attack(comboBox1.SelectedItem.ToString()) == 1)
                {
                    richTextBox1.Text += "战斗成功，您获得了经验值：" + Convert.ToString(monster1.Tiqu_monster_experience(comboBox1.SelectedItem.ToString())) + "\r\n" + "您目前的等级为:" + Convert.ToString(person1.Tiqu_person_grade()) + "\r\n";
                    richTextBox1.Text += "您的血量还剩余：" + Convert.ToString(person1.Tiqu_change_hp()) + "\r\n";
                    richTextBox1.Text += "您获得金钱：" + Convert.ToString(monster1.Tiqu_monster_money(comboBox1.SelectedItem.ToString())) + "\r\n";
                    if (monster1.Tiqu_monster_equipment(comboBox1.SelectedItem.ToString()) != null)
                        richTextBox1.Text += "恭喜您获得了装备" + monster1.Tiqu_monster_equipment(comboBox1.SelectedItem.ToString()) + "\r\n";
                    else
                    {

                        richTextBox1.Text += "战斗结束，您什么也没有获得\r\n";
                    }
                }
                else
                {
                    richTextBox1.Text += "战斗失败，人物已死亡，请回城复活\r\n";
                }
            }
            if (comboBox1.SelectedIndex == 3)
            {
                if (person1.attack(comboBox1.SelectedItem.ToString()) == 1)
                {
                    richTextBox1.Text += "战斗成功，您获得了经验值：" + Convert.ToString(monster1.Tiqu_monster_experience(comboBox1.SelectedItem.ToString())) + "\r\n" + "您目前的等级为:" + Convert.ToString(person1.Tiqu_person_grade()) + "\r\n";
                    richTextBox1.Text += "您的血量还剩余：" + Convert.ToString(person1.Tiqu_change_hp()) + "\r\n";
                    richTextBox1.Text += "您获得金钱：" + Convert.ToString(monster1.Tiqu_monster_money(comboBox1.SelectedItem.ToString())) + "\r\n";
                    if (monster1.Tiqu_monster_equipment(comboBox1.SelectedItem.ToString()) != null)
                        richTextBox1.Text += "恭喜您获得了装备" + monster1.Tiqu_monster_equipment(comboBox1.SelectedItem.ToString()) + "\r\n";
                    else
                    {

                        richTextBox1.Text += "战斗结束，您什么也没有获得\r\n";
                    }
                }
                else
                {
                    richTextBox1.Text += "战斗失败，人物已死亡，请回城复活\r\n";
                }
            }
            if (comboBox1.SelectedIndex == 4)
            {
                if (person1.attack(comboBox1.SelectedItem.ToString()) == 1)
                {
                    richTextBox1.Text += "战斗成功，您获得了经验值：" + Convert.ToString(monster1.Tiqu_monster_experience(comboBox1.SelectedItem.ToString())) + "\r\n" + "您目前的等级为:" + Convert.ToString(person1.Tiqu_person_grade()) + "\r\n";
                    richTextBox1.Text += "您的血量还剩余：" + Convert.ToString(person1.Tiqu_change_hp()) + "\r\n";
                    richTextBox1.Text += "您获得金钱：" + Convert.ToString(monster1.Tiqu_monster_money(comboBox1.SelectedItem.ToString())) + "\r\n";
                    if (monster1.Tiqu_monster_equipment(comboBox1.SelectedItem.ToString()) != null)
                        richTextBox1.Text += "恭喜您获得了装备" + monster1.Tiqu_monster_equipment(comboBox1.SelectedItem.ToString()) + "\r\n";
                    else
                    {

                        richTextBox1.Text += "战斗结束，您什么也没有获得\r\n";
                    }
                }
                else
                {
                    richTextBox1.Text += "战斗失败，人物已死亡，请回城复活\r\n";
                }
            }//战斗过程1代码合集

            if (comboBox2.SelectedIndex == 0)
            {
                if (person1.attack(comboBox2.SelectedItem.ToString()) == 1)
                {
                    richTextBox1.Text += "战斗成功，您获得了经验值：" + Convert.ToString(monster1.Tiqu_monster_experience(comboBox2.SelectedItem.ToString())) + "\r\n" + "您目前的等级为:" + Convert.ToString(person1.Tiqu_person_grade()) + "\r\n";
                    richTextBox1.Text += "您的血量还剩余：" + Convert.ToString(person1.Tiqu_change_hp()) + "\r\n";
                    richTextBox1.Text += "您获得金钱：" + Convert.ToString(monster1.Tiqu_monster_money(comboBox2.SelectedItem.ToString())) + "\r\n";
                    if (monster1.Tiqu_monster_equipment(comboBox2.SelectedItem.ToString()) != null)
                        richTextBox1.Text += "恭喜您获得了装备" + monster1.Tiqu_monster_equipment(comboBox2.SelectedItem.ToString()) + "\r\n";
                    else
                    {

                        richTextBox1.Text += "战斗结束，您什么也没有获得\r\n";
                    }
                }
                else
                {
                    richTextBox1.Text += "战斗失败，人物已死亡，请回城复活\r\n";
                }
            }
            if (comboBox2.SelectedIndex == 1)
            {
                if (person1.attack(comboBox2.SelectedItem.ToString()) == 1)
                {
                    richTextBox1.Text += "战斗成功，您获得了经验值：" + Convert.ToString(monster1.Tiqu_monster_experience(comboBox2.SelectedItem.ToString())) + "\r\n" + "您目前的等级为:" + Convert.ToString(person1.Tiqu_person_grade()) + "\r\n";
                    richTextBox1.Text += "您的血量还剩余：" + Convert.ToString(person1.Tiqu_change_hp()) + "\r\n";
                    richTextBox1.Text += "您获得金钱：" + Convert.ToString(monster1.Tiqu_monster_money(comboBox2.SelectedItem.ToString())) + "\r\n";
                    if (monster1.Tiqu_monster_equipment(comboBox2.SelectedItem.ToString()) != null)
                        richTextBox1.Text += "恭喜您获得了装备" + monster1.Tiqu_monster_equipment(comboBox2.SelectedItem.ToString()) + "\r\n";
                    else
                    {

                        richTextBox1.Text += "战斗结束，您什么也没有获得\r\n";
                    }
                }
                else
                {
                    richTextBox1.Text += "战斗失败，人物已死亡，请回城复活\r\n";
                }
            }
            if (comboBox2.SelectedIndex == 2)
            {
                if (person1.attack(comboBox2.SelectedItem.ToString()) == 1)
                {
                    richTextBox1.Text += "战斗成功，您获得了经验值：" + Convert.ToString(monster1.Tiqu_monster_experience(comboBox2.SelectedItem.ToString())) + "\r\n" + "您目前的等级为:" + Convert.ToString(person1.Tiqu_person_grade()) + "\r\n";
                    richTextBox1.Text += "您的血量还剩余：" + Convert.ToString(person1.Tiqu_change_hp()) + "\r\n";
                    richTextBox1.Text += "您获得金钱：" + Convert.ToString(monster1.Tiqu_monster_money(comboBox2.SelectedItem.ToString())) + "\r\n";
                    if (monster1.Tiqu_monster_equipment(comboBox2.SelectedItem.ToString()) != null)
                        richTextBox1.Text += "恭喜您获得了装备" + monster1.Tiqu_monster_equipment(comboBox2.SelectedItem.ToString()) + "\r\n";
                    else
                    {

                        richTextBox1.Text += "战斗结束，您什么也没有获得\r\n";
                    }
                }
                else
                {
                    richTextBox1.Text += "战斗失败，人物已死亡，请回城复活\r\n";
                }
            }
            if (comboBox2.SelectedIndex == 3)
            {
                if (person1.attack(comboBox2.SelectedItem.ToString()) == 1)
                {
                    richTextBox1.Text += "战斗成功，您获得了经验值：" + Convert.ToString(monster1.Tiqu_monster_experience(comboBox2.SelectedItem.ToString())) + "\r\n" + "您目前的等级为:" + Convert.ToString(person1.Tiqu_person_grade()) + "\r\n";
                    richTextBox1.Text += "您的血量还剩余：" + Convert.ToString(person1.Tiqu_change_hp()) + "\r\n";
                    richTextBox1.Text += "您获得金钱：" + Convert.ToString(monster1.Tiqu_monster_money(comboBox2.SelectedItem.ToString())) + "\r\n";
                    if (monster1.Tiqu_monster_equipment(comboBox2.SelectedItem.ToString()) != null)
                        richTextBox1.Text += "恭喜您获得了装备" + monster1.Tiqu_monster_equipment(comboBox2.SelectedItem.ToString()) + "\r\n";
                    else
                    {

                        richTextBox1.Text += "战斗结束，您什么也没有获得\r\n";
                    }
                }
                else
                {
                    richTextBox1.Text += "战斗失败，人物已死亡，请回城复活\r\n";
                }
            }
            if (comboBox2.SelectedIndex == 4)
            {
                if (person1.attack(comboBox2.SelectedItem.ToString()) == 1)
                {
                    richTextBox1.Text += "战斗成功，您获得了经验值：" + Convert.ToString(monster1.Tiqu_monster_experience(comboBox2.SelectedItem.ToString())) + "\r\n" + "您目前的等级为:" + Convert.ToString(person1.Tiqu_person_grade()) + "\r\n";
                    richTextBox1.Text += "您的血量还剩余：" + Convert.ToString(person1.Tiqu_change_hp()) + "\r\n";
                    richTextBox1.Text += "您获得金钱：" + Convert.ToString(monster1.Tiqu_monster_money(comboBox2.SelectedItem.ToString())) + "\r\n";
                    if (monster1.Tiqu_monster_equipment(comboBox2.SelectedItem.ToString()) != null)
                        richTextBox1.Text += "恭喜您获得了装备" + monster1.Tiqu_monster_equipment(comboBox2.SelectedItem.ToString()) + "\r\n";
                    else
                    {

                        richTextBox1.Text += "战斗结束，您什么也没有获得\r\n";
                    }
                }
                else
                {
                    richTextBox1.Text += "战斗失败，人物已死亡，请回城复活\r\n";
                }
            }//战斗过程2代码合集




        }
    }
}
