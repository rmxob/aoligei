using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 对战模拟
{
    public partial class monster_change : Form
    {
        public static monster_change now_form;
        public monster_change()
        {
            InitializeComponent();
            now_form = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            attack_skill a = new attack_skill();
            a.Show();
            this.Hide();


        }

        private void monster_change_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("背景2.jpg");
            label1.BackColor = Color.Transparent;
            label1.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;
            label2.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;
            label3.Parent = pictureBox1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if ((comboBox1.SelectedIndex >=0) || (comboBox2.SelectedIndex >=0)||( comboBox3.SelectedIndex >=0))
            {
            attack_skill attack_ = new attack_skill();
            this.Hide();
            attack_.Show();
            }
            else
            {
                MessageBox.Show("请选择你要挑战的对象");              
            }
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
