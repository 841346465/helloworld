using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using MODEL.ORM;

namespace MODEL {
	[PrimaryKey("id", autoIncrement = true)]
	public class company {
		#region 数据
		//[DisplayName("主键")]
		[Visable(false)]
		public string id { get; set; }

		[DisplayName("保安从业单位")]
		public string sg_company_name { get; set; }

		[DisplayName("许可证号")]
		public string liscence { get; set; }

		[DisplayName("法定代表人")]
		public string legal_representative { get; set; }

		[DisplayName("审批年份")]
		public string Approval_of_the_year { get; set; }

		[Visable(false)]
		[DisplayName("服务范围")]
		public string service_area { get; set; }

		[Visable(false)]
		[DisplayName("是否跨区域")]
		public bool is_across_zone { get; set; }

		[DisplayName("注册地")]
		[Visable(false)]
		public string Registered_Address { get; set; }

		[DisplayName("办公场所")]
		[Visable(false)]
		public string business_address { get; set; }

		[DisplayName("注册资金")]
		public string registered_capital { get; set; }

		[Visable(false)]
		[DisplayName("分公司")]
		public string branch_office { get; set; }

		[Visable(false)]
		[DisplayName("管理层人员")]
		public string management_layer { get; set; }

		[DisplayName("联系方式")]
		public string phone { get; set; }

		[Visable(false)]
		[DisplayName("公司员工总数")]
		public int allstaff_num { get; set; }

		[Visable(false)]
		[DisplayName("管理人员数")]
		public int administrator_num { get; set; }

		[Visable(false)]
		[DisplayName("保安员数量")]
		public int Security_Officer_num { get; set; }

		[Visable(false)]
		[DisplayName("服务单位名称")]
		public string Security_Officer_name { get; set; }
		#endregion
	}
}
