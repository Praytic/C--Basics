using System;

namespace UniversityStudy.ProgClasses {

	class Part2 {

		static void ArrayAddValue(int[] a, ref int n, int newElement, int m) {

			for (int i = n; i >= m; i--) {
				a[i] = a[i - 1];
			}
			n++;
			a[m] = newElement;
		}

		static public void Prac6_II_3() {

			int n = General.ReadValue<int>();
			double[] a = General.ReadArray<double>(n);
			double maxValue = (n == 0) ? 0 : a[0];
			for (int i = 0; i < n; i++) {
				if (a[i] > maxValue) {
					maxValue = a[i];
				}
			}
			for (int i = 0; i < n; i++) {
				if (a[i] == maxValue) {
					a[i] = 0;
				}
			}
			for (int i = 0; i < n; i++) {
				Console.Write("{0} ", a[i]);
			}
		}

		static public void Prac6_V_6() {

			int n = General.ReadValue<int>();
			int[] a = General.ReadArray<int>(n);
			int number = 0;
			for (; number < n; number++) {
				if (a[number] < 0) {
					int newElement = General.ReadValue<int>();
					ArrayAddValue(a, ref n, newElement, number);
					break;
				}
			}
			General.WriteArray<int>(a, n);
		}
	}
}
