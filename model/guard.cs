using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MODEL.ORM;

namespace MODEL {
    [PrimaryKey("id", autoIncrement = true)]
    public class guard {
        #region  数据
        //[DisplayName("主键")]
		[Visable(false)]
        public string id { get; set; }

        [DisplayName("姓名")]
		public string name { get; set; }

		[Visable(false)]
		[DisplayName("电话号码")]
		public string phone { get; set; }
		[DisplayName("保安员证号 ")]
		public string certificate_num { get; set; }

		[Visable(false)]
		[DisplayName("服务区域 ")]
		public string service_area { get; set; }
		[DisplayName("身份证号")]
		public string ID_card { get; set; }

		[Visable(false)]
		[DisplayName("原部队")]
		public string army { get; set; }

		[Visable(false)]
		[DisplayName("奖励及惩罚")]
		public string r_and_p { get; set; }

		[Visable(false)]
		[DisplayName("现地址 ")]
		public string address { get; set; }

		[Visable(false)]
		[DisplayName("户口所在地")]
		public string Hukou { get; set; }

		[Visable(false)]
		[DisplayName("联系方式")]
		public string contact_way { get; set; }

		[DisplayName("政治面貌")]
		public string political_status { get; set; }

		[DisplayName("所属保安从业单位")]
		public string part_of_company { get; set; }

		[Visable(false)]
		[DisplayName("服务客户单位")]
		public string serviceunit { get; set; }

		[Visable(false)]
		[DisplayName("身高体重")]
		public string h_and_w { get; set; }

		[DisplayName("性别")]
		public string sex { get; set; }

		[Visable(false)]
		[DisplayName("是否专业军人")]
		public string soldier { get; set; }

		[Visable(false)]
		[DisplayName("核发年份")]
		public DateTime approve_time { get; set; }

		[Visable(false)]
		[DisplayName("出生日期 ")]
		public DateTime date_of_birth { get; set; }

		[Visable(false)]
		[DisplayName("专业技能 ")]
		public string major_skill { get; set; }

		[Visable(false)]
		[DisplayName("培训记录")]
		public string training_record { get; set; }

		[Visable(false)]
		[DisplayName("从业轨迹")]
		public string carrier_history { get; set; }

		[Visable(false)]
		//[DisplayName("照片的base64编码")]
		public string base64FromImage { get; set; }
		#endregion
	}
}

