/* Part1 class contains following tasks:
 * Practice 4 - VI(19), VII(4)
 * Practive 5 - II(17), IV(4), V(2)
 * 
 * Part2 class contains following tasks:
 * Practive 6 - II(3), V(6)
 * 
 * Part3 class contains following tasks:
 * Practive 6 - IV(15), VI(2)
 */

using System;

namespace UniversityStudy {

	class General {

		public static System.IO.StreamReader infile;
		public static System.IO.StreamWriter outfile;

		public static T[] ReadArray<T>() {

			string[] scan = infile.ReadLine().Split(' ');
			T[] a = new T[scan.Length * 2];
			for (int i = 0; i < scan.Length; i++) {
				a[i] = (T)Convert.ChangeType(scan[i], typeof(T));
			}
			return a;
		}

		public static T[] ReadArray<T>(int n) {

			string[] scan = infile.ReadLine().Split(' ');
			T[] a = new T[n * 2];
			for (int i = 0; i < n; i++) {
				a[i] = (T)Convert.ChangeType(scan[i], typeof(T));
			}
			return a;
		}

		public static T ReadValue<T>() {

			T a = (T)Convert.ChangeType(infile.ReadLine(), typeof(T));
			return a;
		}

		public static void WriteArray<T>(T[] arr, int n) {

			for (int i = 0; i < n; i++) {
				outfile.Write("{0} ", arr[i]);
			}
			outfile.Write("\n");
		}

		public static void WriteValue<T>(T value) {

			outfile.Write("{0}\n", value);
		}

		public static void Dispose() {

			infile.Close();
			outfile.Close();
		}

		public static void Initiate() {

			infile = new System.IO.StreamReader(@"../../CodeResources/input.txt");
			outfile = new System.IO.StreamWriter(@"../../CodeResources/output.txt");
		}
	}
}
