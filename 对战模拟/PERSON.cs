using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace 对战模拟
{
    class PERSON
    {
        SqlConnection sql = new SqlConnection("server=.;database=红凯;uid=sa;pwd=123456");
        public int person_hp,person_grade,person_wuli,change_hp;

        public int Tiqu_person_hp()//提取人物hp
        {
            sql.Open();
            string strsql_hp = "select hp from person where name ='红凯'";
            SqlCommand Tiqu_person_hp_command = new SqlCommand(strsql_hp, sql);
            SqlDataReader Tiqu_person_hp_reader = Tiqu_person_hp_command.ExecuteReader();
            while (Tiqu_person_hp_reader.Read())
            {
                person_hp = Tiqu_person_hp_reader.GetInt32(Tiqu_person_hp_reader.GetOrdinal("hp"));
            }
            sql.Close();
            Tiqu_person_hp_reader.Close();
            return person_hp;
        }
        public int Tiqu_person_grade()//提取人物等级
        {
            sql.Open();
            string strsql_grade = "select grade from person where name ='红凯'";
            SqlCommand Tiqu_person_grade_command = new SqlCommand(strsql_grade, sql);
            SqlDataReader Tiqu_person_grade_reader = Tiqu_person_grade_command.ExecuteReader();
            while (Tiqu_person_grade_reader.Read())
            {
                person_grade = Tiqu_person_grade_reader.GetInt32(Tiqu_person_grade_reader.GetOrdinal("grade"));
            }
            sql.Close();
            Tiqu_person_grade_reader.Close();
            return person_grade;
        }
        public int Tiqu_person_wuli()//提取人物攻击力
        {
            sql.Open();
            string strsql_wuli = "select wuli from person where name ='红凯'";
            SqlCommand Tiqu_person_wuli_command = new SqlCommand(strsql_wuli, sql);
            SqlDataReader Tiqu_person_wuli_reader = Tiqu_person_wuli_command.ExecuteReader();
            while (Tiqu_person_wuli_reader.Read())
            {
                person_wuli = Tiqu_person_wuli_reader.GetInt32(Tiqu_person_wuli_reader.GetOrdinal("wuli"));
            }
            sql.Close();
            Tiqu_person_wuli_reader.Close();
            return person_wuli;
        }
        public int attack(string monster_name)//战斗
        {
           
            MONSTER mONSTER = new MONSTER();
            int person_hp, person_wuli, monster_wuli, monster_hp;
            person_hp = Tiqu_change_hp();
            if(person_hp>0)//战斗之前先判断血量
            {
               person_wuli = Tiqu_person_wuli();
               monster_hp = mONSTER.Tiqu_monster_hp(monster_name);
               monster_wuli = mONSTER.Tiqu_monster_wuli(monster_name);
            while (monster_hp >= 0 && person_hp >= 0)
            {
                monster_hp -= person_wuli;
                person_hp -= monster_wuli;
              
                if (monster_hp <= 0)//战斗胜利
                { 
                    sql.Open();
                    string attack = "update person set change_hp= " + person_hp;
                    SqlCommand attack_person = new SqlCommand(attack, sql);
                    string experience_add = "update person set Empirical= Empirical +" + mONSTER.Tiqu_monster_experience(monster_name);
                    SqlCommand experience = new SqlCommand(experience_add, sql);
                    try
                    {
                         attack_person.ExecuteNonQuery();
                         experience.ExecuteNonQuery();
                         PERSON pERSON = new PERSON();
                         pERSON.add_money(monster_name);
                         string equpiment= mONSTER.Tiqu_monster_equipment(monster_name);
                            if (equpiment != null)
                            {
                                ATTACK aTTACK = new ATTACK();
                                aTTACK.bag_add(equpiment);

                            }
                        } 
                    catch
                    {
                        MessageBox.Show("执行语句失败");
                    }
                    finally
                    {
                        sql.Close();
                    }
                    break;
                }            
                else if(person_hp<=0)
                {
                        sql.Open();                      
                        string attack_lose = "update person set change_hp= 0 ";
                        SqlCommand dead = new SqlCommand(attack_lose, sql);
                        try
                        {
                          dead.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("死亡失败");
                        }
                        finally
                        {
                            sql.Close();
                        }
                        
                       
                 return 0;
                }                                                      
            }
            return 1; 
            }
            else
            {
                return 0;
            }
          
            
        }
        public void blood_return()//回城恢复血量
        {
            sql.Open();
            PERSON pERSON = new PERSON();
            string blood_return = "update person set change_hp= "+500;
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
        public  void add_money(string monster_name)//增加人物金钱
        {
            sql.Open();
            MONSTER mONSTER = new MONSTER();
            int money = mONSTER.Tiqu_monster_money(monster_name);
            string money_add = "update person set person_money+=" + money;
            SqlCommand command_money_add = new SqlCommand(money_add, sql);
            try
            {
                command_money_add.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("增加金钱失败");
             
            }
            finally
            {
                sql.Close();
            }
           
        }
        public void add_experience(string monster_name)//增加人物金钱
        {
            sql.Open();
            MONSTER mONSTER = new MONSTER();
            int experience = mONSTER.Tiqu_monster_experience(monster_name);
            string money_add = "update person set Empirical+=" +experience;
            SqlCommand command_money_add = new SqlCommand(money_add, sql);
            try
            {
                command_money_add.ExecuteNonQuery();
               
            }
            catch
            {
                MessageBox.Show("增加经验失败");

            }
            finally
            {
                sql.Close();
            }

        }
        public int person_money;
        public int Tiqu_person_money()//提取人物金钱
        {
            sql.Open();
            string strsql_money = "select person_money from person where name ='红凯'";
            SqlCommand Tiqu_person_money_command = new SqlCommand(strsql_money, sql);
            SqlDataReader Tiqu_person_money_reader = Tiqu_person_money_command.ExecuteReader();
            while (Tiqu_person_money_reader.Read())
            {
                person_money= Tiqu_person_money_reader.GetInt32(Tiqu_person_money_reader.GetOrdinal("person_money"));
            }
            sql.Close();
            Tiqu_person_money_reader.Close();
            return person_money;
        }
        public int Tiqu_change_hp()//提取人物change_hp
        {
            sql.Open();
            string strsql_hp = "select change_hp from person where name ='红凯'";
            SqlCommand Tiqu_change_hp_command = new SqlCommand(strsql_hp, sql);
            SqlDataReader Tiqu_change_hp_reader = Tiqu_change_hp_command.ExecuteReader();
            while (Tiqu_change_hp_reader.Read())
            {
                change_hp = Tiqu_change_hp_reader.GetInt32(Tiqu_change_hp_reader.GetOrdinal("change_hp"));
            }
            sql.Close();
            Tiqu_change_hp_reader.Close();
            return change_hp;
        }
        public bool skill_attack()
        {

            return true;
        }
        public void chang_person_changehp(int hp)
        {
            sql.Open();
            PERSON pERSON = new PERSON();
            int x = pERSON.Tiqu_change_hp();
            string changehp = "update person set change_hp-=" + hp;
            SqlCommand changhp = new SqlCommand(changehp,sql);
            try
            {

            }
            catch
                {

            }

        }
        

    }
}
