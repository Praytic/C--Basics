using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityStudy.ProgClasses {

	class Lecture {

		public static void Third_Max() {

			int[] arr = General.ReadArray<int>();
			int[] res = arr;
			Array.Sort(res);
			if (res.Length > 2) {
				General.outfile.WriteLine("Third max: " + res[res.Length - 3]);
			}
		}
	}
}
