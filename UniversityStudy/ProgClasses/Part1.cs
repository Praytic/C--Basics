using System;

namespace UniversityStudy {

	class Part1 {

		static bool BI(int a) {
			if (a != 0) return true;
			else return false;
		}

		static int GCD(int a, int b) {
			return BI(b) ? GCD(b, a % b) : a;
		}

		static double NItem(double b1, double q, int n) {
			return (n != 1) ? q * NItem(b1, q, n - 1) : b1;
		}

		static double NSum(double b1, double q, int n) {
			return (n != 1) ? b1 + NSum(b1 * q, q, n - 1) : b1;
		}

        static void Sequence(int n) {

            if (n != 0)
                Sequence(n - 1);
            else
                return;

            for (int i = 0; i < n; i++) {
                Console.Write("{0} ", n);
            }
            Console.Write("\n");
        }

        static public void Prac5_IV_4() {

			int a, b;
			a = General.ReadValue<int>();
			b = General.ReadValue<int>();

			Console.WriteLine("GCD result: {0}", GCD(a, b));
		}

		static public void Prac5_V_2() {

			double b1, q;
			int n;
			b1 = General.ReadValue<double>();
			q = General.ReadValue<double>();
			n = General.ReadValue<int>();
			Console.WriteLine("N-item: {0}", NItem(b1, q, n));
			Console.WriteLine("N-sum: {0}", NSum(b1, q, n));
		}

		static public void Prac5_II_17() {

			int a, b;
			a = General.ReadValue<int>();
			b = General.ReadValue<int>();
			int NOD = GCD(a, b);

			if (b / NOD != 1)
				Console.WriteLine("{0}/{1}", a / NOD, b / NOD);
			else
				Console.WriteLine("{0}", a / NOD);
		}

		static public void Prac4_VI_19() {

			int a, b;
			a = General.ReadValue<int>();
			b = General.ReadValue<int>();

			int deva = Math.Min(a, 2), devb = Math.Min(b, 2);
			for (int i = 2; i * i <= a; i++) {
				if (a % i == 0) deva += 2;
			}
			for (int i = 2; i * i <= b; i++) {
				if (b % i == 0) devb += 2;
			}
			if (deva > devb)
				Console.WriteLine("First {0}", deva);
			else if (deva < devb)
				Console.WriteLine("Second {0}", devb);
			else
				Console.WriteLine("Equal {0} {1}", deva, devb);
		}

		static public void Prac4_VII_4() {

			int a, b, c;
			a = General.ReadValue<int>();
			b = General.ReadValue<int>();
			c = General.ReadValue<int>();

			for (int i = a; i <= b; i++) {
				int devsum = 1 + i;
				for (int j = 2; j * j <= i; j++) {
					if (i % j == 0) devsum += j + i / j;
					if (i / j == j) devsum -= j;
				}
				if (devsum % c == 0)
					Console.Write("{0} ({1}) ", i, devsum);
			}
		}
	}
}
