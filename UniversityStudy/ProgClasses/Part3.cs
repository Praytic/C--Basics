using System;

namespace UniversityStudy.ProgClasses {

	class Part3 {

		static void ArrayAddArray(int[][] a, ref int n, int m, int[] pasteArray, int number) {

            for (int k = n; k > number; k--) {
				for (int l = 0; l < m; l++) {
					a[l][k] = a[l][k - 1];
				}
            }
            n++;
            for (int i = 0; i < m; i++) {
                a[i][number + 1] = pasteArray[i];
            }
        }

		public static void Prac6_IV_15() {

			int n;
			int k1, k2;
			n = General.ReadValue<int>();
			k1 = General.ReadValue<int>();
			k2 = General.ReadValue<int>();

			int[][] arr2d = new int[n][];
			for (int i = 0; i < n; i++) {
				arr2d[i] = General.ReadArray<int>(n);
			}

			long[] arrResult = new long[n];
			for (int i = 0; i < n; i++) {
				long mul = 1;
				for (int j = k1 - 1; j < k2; j++) {
					mul *= arr2d[j][i];
				}
				arrResult[i] = mul;
			}
			General.WriteArray<long>(arrResult, n);
		}

		public static void Prac6_VI_2() {

			int n, m;
			n = General.ReadValue<int>();
			m = n;
			int[] pasteArray = General.ReadArray<int>(n);

			int[][] arr2d = new int[n][];
			for (int i = 0; i < n; i++) {
				arr2d[i] = General.ReadArray<int>(n);
			}
			for (int i = 0; i < n; i++) {
				bool flag = true;
				for (int j = 0; j < m; j++) {
					if (arr2d[j][i] < 0) flag = false;
				}
				if (!flag) {
					ArrayAddArray(arr2d, ref n, m, pasteArray, i);
					i++;
				}
			}
			for (int i = 0; i < m; i++) {
				General.WriteArray<int>(arr2d[i], n);
			}
		}
	}
}
