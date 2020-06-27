using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 对战模拟
{
    class ATTACK
    {
        SqlConnection sql = new SqlConnection("server=.;database=红凯;uid=sa;pwd=123456");
        public void bag_add(string goods)//检查并插入背包中

        {
            sql.Open();
            string bag_check = "select *from bag where bag_name = '" + goods + "'";
            SqlCommand command_bagcheck = new SqlCommand(bag_check, sql);
            SqlDataReader reader = command_bagcheck.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                string bag_add = "update bag set number+=1 where bag_name ='" + goods+"'";
                SqlCommand command_bagadd = new SqlCommand(bag_add, sql);
                try
                {
                    command_bagadd.ExecuteNonQuery();

                }
                catch
                {
                    MessageBox.Show("更新物品数量失败");
                }
                finally
                {
                    sql.Close();
                  
                }
            }
            else
            {
                reader.Close();
                string bag_insert = "insert into bag values ('" + goods + "'," + 1 + ")";
                SqlCommand command_insert = new SqlCommand(bag_insert, sql);
                try
                {
                    command_insert.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("插入物品失败");
                }
                finally
                {
                    sql.Close();
                }
            }
        }
        public void hp_reflash(int xue )//道具的回血
        {
            sql.Open();

            PERSON person1 = new PERSON();
            int hp = person1.Tiqu_person_hp();
            int change_hp = person1.Tiqu_change_hp();
            if(xue+change_hp<hp)
            {
                int he = xue + change_hp;
                string blood_return = "update person set change_hp+= " +he;
                SqlCommand blood_command = new SqlCommand(blood_return, sql);
                try
                {
                    blood_command.ExecuteNonQuery();
                   
                }
                catch
                {
                    MessageBox.Show("执行回血语句失败");
                }
                finally
                {
                    sql.Close();
                }
            }
            else
            {
                string blood_return = "update person set  change_hp= " + hp;
                SqlCommand blood_command = new SqlCommand(blood_return, sql);
                try
                {
                    blood_command.ExecuteNonQuery();

                }
                catch
                {
                    MessageBox.Show("语句失败");
                }
                finally
                {
                    sql.Close();
                }
            }

        }
        public void wuli_add(int wuli)//武力的增加
        {
            sql.Open();

            string wuli1 = "update  person set wuli +="+wuli;
            SqlCommand wuli_command = new SqlCommand(wuli1,sql);
           try
            {
                wuli_command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("道具增武失败");
            }
            finally
            {
                 sql.Close();
            }
        }
        public  void items_delete(string itemsname)
        {
            sql.Open();
            string delete = "update bag set number -=1 where bag_name= '" + itemsname + "'";
            SqlCommand command = new SqlCommand(delete, sql);
            try
            {

                command.ExecuteNonQuery();
            }
            catch

            {
                MessageBox.Show("减少物品数量失败");

            }
            finally
            {
                sql.Close();
            }


        }//使用物品后数量减少
    }
}
