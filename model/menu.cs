using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model {

	[Table("menu")]
	[PrimaryKey("id", autoIncrement = true)]
	public class menu : ICloneable {

		[DisplayName("菜单ID")]
		[Column("id")]
		public uint id { get; set; }

		[DisplayName("菜单名称")]
		[Column("name")]
		public string name { get; set; }

		[DisplayName("父级主键")]
		[Column("parentId")]
		public uint parentId { get; set; }

		[DisplayName("dll名称")]
		[Column("dllName")]
		public string dllName { get; set; }

		[DisplayName("类名")]
		[Column("fieldName")]
		public string fieldName { get; set; }

		[DisplayName("顺序号")]
		[Column("showOrder")]
		public uint showOrder { get; set; }

		public object Clone() {
			return this.MemberwiseClone();
		}
	}
}
