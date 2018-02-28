using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace model
{
    public class guard
    {
        #region  数据
        [DisplayName("姓名")]
        public string name { get; set; }
        [DisplayName("电话号码")]
        public string phone { get; set; }
        [DisplayName("保安员证号 ")]
        public string certificate_num { get; set; }
        [DisplayName("服务区域 ")]
        public string service_area { get; set; }
        [DisplayName("身份证号")]
        public string ID_card { get; set; }
        [DisplayName("原部队")]
        public string army { get; set; }
        [DisplayName("奖励及惩罚")]
        public string r_and_p { get; set; }
        [DisplayName("现地址 ")]
        public string address { get; set; }
        [DisplayName("户口所在地")]
        public string Hukou { get; set; }
        [DisplayName("联系方式" )]
        public string contact_way { get; set; }
        [DisplayName("政治面貌")]
        public string political_status { get; set; }
        [DisplayName("所属保安公司")]
        public string part_of_company { get; set; }
        [DisplayName("服务客户单位")]
        public string serviceunit { get; set; }
        [DisplayName("身高体重")]
        public string h_and_w { get; set; }
        [DisplayName("性别")]
        public string sex { get; set; }
        [DisplayName("是否专业军人")]
        public string soldier { get; set; }
        [DisplayName("核发年份")]
        public string approve_time{ get; set; }
        [DisplayName("出生日期 ")]
        public string date_of_birth { get; set; }
        [DisplayName("专业技能 ")]
        public string major_skill { get; set; }
        [DisplayName("培训记录")]
        public string dtraining_record { get; set; }
        #endregion
  

        DBhelper.MySQLconnection conn = new DBhelper.MySQLconnection();
        public void Insert()
        {
            string insertsql = string.Format(sql.GuardInsert, name, phone, certificate_num, service_area, ID_card, army, r_and_p,
                address, Hukou, contact_way, political_status, part_of_company, serviceunit, h_and_w, sex, soldier, approve_time, date_of_birth,
                major_skill, dtraining_record);

            conn.OpenConnection();
            conn.ExecuteNonQuery(insertsql);
            conn.CloseConnection(); 

        }

        public List<guard> Querylist()
        {
            List<guard> returnlist = new List<guard>();

            conn.OpenConnection();
            MySql.Data.MySqlClient.MySqlDataReader reader = conn.GetReader(sql.GuardQueryList);
            while (reader.Read()) ;
            {
                returnlist.Add(new guard()
                {
                    name = reader["name"].ToString(),
                    name = reader["name"].ToString(),
                    name = reader["name"].ToString(),
                    name = reader["name"].ToString(),
                    name = reader["name"].ToString(),
                    name = reader["name"].ToString(),
                    name = reader["name"].ToString(),
                    name = reader["name"].ToString(),
                    name = reader["name"].ToString(),
                    name = reader["name"].ToString(),
                    name = reader["name"].ToString(),
                    name = reader["name"].ToString(),
                    name = reader["name"].ToString(),
                    name = reader["name"].ToString(),
                    name = reader["name"].ToString(),
                    name = reader["name"].ToString(),
                    name = reader["name"].ToString(),
                    name = reader["name"].ToString(),
                    name = reader["name"].ToString(),
                    name = reader["name"].ToString(),
                    phone,
                    certificate_num,
                    service_area,
                    ID_card,
                    army,
                    r_and_p,
                    address,
                    Hukou,
                    contact_way,
                    political_status,
                    part_of_company,
                    serviceunit,
                    h_and_w,
                    sex,
                    soldier,
                    approve_time,
                    date_of_birth,
                    major_skill,
                    dtraining_record


                }





            }
        }












    }
}
