using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections;
namespace 对战模拟
{
    class SSHOP
    {
        SqlConnection sql = new SqlConnection("server=.;database=红凯;uid=sa;pwd=123456");
        public int shop_money,num,sum=0;
        public string all;
      List<string> a = new List<string>() ;
        ArrayList b = new ArrayList();
      
        public int Tiqu_shop_money(string shop_name)//提取商店物品金钱
        {
            sql.Open();
            string strsql_money = "select money from shop where itemname ='" + shop_name + "'";
            SqlCommand Tiqu_shop_wuli_command = new SqlCommand(strsql_money, sql);
            SqlDataReader Tiqu_shop_money_reader = Tiqu_shop_wuli_command.ExecuteReader();
            while (Tiqu_shop_money_reader.Read())
            {
                shop_money = Tiqu_shop_money_reader.GetInt32(Tiqu_shop_money_reader.GetOrdinal("money"));
            }
            sql.Close();
            Tiqu_shop_money_reader.Close();
            return shop_money;
        }

        public int losemoney(string shop_name)//购买物品减少金钱
        {
            SSHOP shop1 = new SSHOP();
            PERSON person = new PERSON();
            int allmoney = person.Tiqu_person_money();
            int lose_money = shop1.Tiqu_shop_money(shop_name);
            if(allmoney>=lose_money)
            {
              sql.Open();
            string lose_money1 = "update person set person_money-="+lose_money;
            SqlCommand command_losemoney = new SqlCommand(lose_money1, sql);
            try
            {
                command_losemoney.ExecuteNonQuery();

            }
            catch
            {
                MessageBox.Show("减少金钱失败");
            }
            finally
            {
                sql.Close();
                  
            }
              return 1;
            }
            else
            {

                return 0;
            }
            
           
        }

        public void useitems(string shop_name)//商城物品的使用
        {
            sql.Open();
            string use = "select  * from shop where itemname ='" + shop_name + "'";
            SqlCommand use_item = new SqlCommand(use, sql);
            SqlDataReader read = use_item.ExecuteReader();
            while (read.Read())
            {

                all = read.GetString(read.GetOrdinal("function"));
            }
            read.Close();
            string[] s1 = all.Split('_');
            string s11 = s1[0];
            string s12 = s1[1];
            PERSON person1 = new PERSON();
            
            if (s11 == "hp")
            {
                ATTACK bag = new ATTACK();
                bag.hp_reflash(Convert.ToInt32(s12));
                bag.items_delete(shop_name);
            }
            if(s11=="wuli")
            {
                ATTACK bag = new ATTACK();
                bag.wuli_add(Convert.ToInt32(s12));
                bag.items_delete(shop_name);
            }


        }

    }
}
