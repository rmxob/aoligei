using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace 对战模拟
{
    class MONSTER
    {
        SqlConnection sql = new SqlConnection("server=.;database=红凯;uid=sa;pwd=123456");
        public int monster_hp,monster_wuli,monster_experience;
        public string monster_equipment;
        public int monster_money;
        public int Tiqu_monster_hp(string monster_name)//提取怪物hp
        {
            sql.Open();
            string strsql_hp = "select hp from monster where name ='" + monster_name + "'";
            SqlCommand Tiqu_monster_hp_command = new SqlCommand(strsql_hp, sql);
            SqlDataReader Tiqu_monster_hp_reader = Tiqu_monster_hp_command.ExecuteReader();
            while (Tiqu_monster_hp_reader.Read())
            {
               monster_hp = Tiqu_monster_hp_reader.GetInt32(Tiqu_monster_hp_reader.GetOrdinal("hp"));
            }
            sql.Close();
            Tiqu_monster_hp_reader.Close();
            return monster_hp;
        }
        public int Tiqu_monster_wuli(string monster_name)//提取怪物攻击力
        {
            sql.Open();
            string strsql_wuli = "select wuli from monster where name ='" + monster_name + "'";
            SqlCommand Tiqu_monster_wuli_command = new SqlCommand(strsql_wuli, sql);
            SqlDataReader Tiqu_monster_money_reader = Tiqu_monster_wuli_command.ExecuteReader();
            while (Tiqu_monster_money_reader.Read())
            {
                monster_wuli = Tiqu_monster_money_reader.GetInt32(Tiqu_monster_money_reader.GetOrdinal("wuli"));
            }
            sql.Close();
            Tiqu_monster_money_reader.Close();
            return monster_wuli;
        }
        public string Tiqu_monster_equipment(string monster_name)//提取怪物装备
        {
            sql.Open();
            string strsql_equipment = "select equipment from monster where name ='" + monster_name + "'";
            SqlCommand Tiqu_monster_equipment_command = new SqlCommand(strsql_equipment, sql);
            SqlDataReader Tiqu_monster_equipment_reader = Tiqu_monster_equipment_command.ExecuteReader();
            while (Tiqu_monster_equipment_reader.Read())
            {
                monster_equipment = Tiqu_monster_equipment_reader.GetString(Tiqu_monster_equipment_reader.GetOrdinal("equipment"));
            }
            sql.Close();
            Tiqu_monster_equipment_reader.Close();
            Random random = new Random();
            int n = random.Next(1, 10);//运用随机数，让掉落的装备具有随机性
            if(n==6)
            {
             return monster_equipment;
            }
            else
            {
                return null;
            }
           
        }
        public int Tiqu_monster_experience(string monster_name)//提取战胜怪物获得的经验
        {
            sql.Open();
            string  strsql_experience = "select experience from monster where name ='"+monster_name+"'";
            SqlCommand Tiqu_monster_experience_command = new SqlCommand(strsql_experience, sql);
            SqlDataReader Tiqu_monster_experience_reader = Tiqu_monster_experience_command.ExecuteReader();
            while (Tiqu_monster_experience_reader.Read())
            {
                monster_experience = Tiqu_monster_experience_reader.GetInt32(Tiqu_monster_experience_reader.GetOrdinal("experience"));
            }
            sql.Close();
            Tiqu_monster_experience_reader.Close();
            return monster_experience;
        }
        public int Tiqu_monster_money(string monster_name)//提取战胜怪物所得金钱
        {
            sql.Open();
            string strsql_money = "select monster_money from monster where name ='" + monster_name + "'";
            SqlCommand Tiqu_monster_wuli_command = new SqlCommand(strsql_money, sql);
            SqlDataReader Tiqu_monster_money_reader = Tiqu_monster_wuli_command.ExecuteReader();
            while (Tiqu_monster_money_reader.Read())
            {
                monster_money = Tiqu_monster_money_reader.GetInt32(Tiqu_monster_money_reader.GetOrdinal("monster_money"));
            }
            sql.Close();
            Tiqu_monster_money_reader.Close();
            return monster_money;
        }
    }
}
