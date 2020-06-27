using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections;
using System.Data;

namespace 对战模拟
{ 
    class SKILL
    {
        SqlConnection sql = new SqlConnection(@"server=.;database=红凯;uid=sa;pwd=123456");
             public string[] a = new string[4];
        public int skill_weili;
        public string[] Tiqu_Skill_name()//列表化为技能
        {   
            sql.Open();
           // int i = 0;
            string skill_name = "select skill_name from skill ";         
            DataTable b = new DataTable();
          SqlDataAdapter adapter = new SqlDataAdapter(skill_name, sql);
         adapter.Fill(b);
            for(int i=0;i<4;i++)
            {
            a[i] =  (String)b.Rows[i]["skill_name"];

            }
            sql.Close();
            return a;
        }
        public  int Tiqu_Skill_weili(string skill_name)
        {
            sql.Open();
            string strsql_hp = "select skill_weili from skill where  skill_name ='"+skill_name+"'";
            SqlCommand Tiqu_person_hp_command = new SqlCommand(strsql_hp, sql);
            SqlDataReader Tiqu_person_hp_reader = Tiqu_person_hp_command.ExecuteReader();
            while (Tiqu_person_hp_reader.Read())
            {
               skill_weili = Tiqu_person_hp_reader.GetInt32(Tiqu_person_hp_reader.GetOrdinal("skill_weili"));
            }
            sql.Close();
            Tiqu_person_hp_reader.Close();
            return skill_weili;
        }//提取技能威力
    }
}
