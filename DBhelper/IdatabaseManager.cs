using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace DBhelper {
	interface IdatabaseManager {
		DbTransaction dbTransaction { get; set; }

		System.Data.Common.DbConnection dbConnection { get; set; }


	}
}
