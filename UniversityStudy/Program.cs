using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using UniversityStudy.ProgClasses;

namespace UniversityStudy {

	static class Program {

		static void Main(string[] args) {

<<<<<<< HEAD
			General.Initiate();
			ConsoleInterface.MainLoop();
			General.Dispose();
=======
			//Part1.Prac4_VI_19();
			//Part1.Prac4_VII_4();
			//Part1.Prac5_II_17();
			//Part1.Prac5_IV_4();
			//Part1.Prac5_V_2();
			//Part2.Prac6_II_3();
			//Part2.Prac6_V_6();
            //Part3.Prac6_IV_15();
            Part3.Prac6_VI_2();

			if (args.Length != 0) {
				Type parts = typeof(Part1);
				MethodInfo method = parts.GetMethod(args[0]);
				Part1 tasks = new Part1();
				method.Invoke(tasks, null);
			}
>>>>>>> origin/master
		}
	}
}
