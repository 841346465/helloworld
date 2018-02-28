using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace framework {
	class node {
		[DisplayName("菜单ID")]
		public uint id { get; set; }
		[DisplayName("菜单名称")]
		public string name { get; set; }
		[DisplayName("父级主键")]
		public uint parentId {get;set;}
		[DisplayName("dll名称")]
		public string dllName { get; set; }
		[DisplayName("类名")]
		public string fieldName { get; set; }
		[DisplayName("顺序号")]
		public uint order { get; set; }
	}
}
