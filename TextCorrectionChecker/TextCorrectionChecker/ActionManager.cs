using System;
using System.Diagnostics;
using System.IO;

namespace TextCorrectionChecker {

    public static class ActionManager {

        public static string[] Testcases = new string[5];
        public static void Initialize() {
            // Перед проверкой времени работы стоит один раз пройтись по функциям для того, чтобы создать нативный код
            CustomHandler.CreateNativeCode();
            RegexHandler.CreateNativeCode();
            for (var i = 0; i < Testcases.Length; i++) {
                Testcases[i] = new StreamReader(@"../../testcase" + (i + 1) + @".txt").ReadToEnd();
            }
        }

        public static void RunTests() {
            StreamWriter results = new StreamWriter(@"../../results.txt");
            bool testcaseResult;
            results.WriteLine("-------------- Custom Handler\n");
            for (var i = 0; i < Testcases.Length; i++)
            {
                var sw = Stopwatch.StartNew();
                testcaseResult = CustomHandler.CheckText(Testcases[i]);
                sw.Stop();
                results.Write("Testcase N{0}: {1}\n" +
                              "Solution runtime summary: {2} ticks ({3} ms)\n\n",
                              i + 1, testcaseResult, sw.ElapsedTicks, sw.ElapsedMilliseconds);
            }

            results.WriteLine("-------------- Regex Handler\n");
            for (var i = 0; i < Testcases.Length; i++) {
                var sw = Stopwatch.StartNew();
                testcaseResult = RegexHandler.CheckText(Testcases[i]);
                sw.Stop();
                results.Write("Testcase N{0}: {1}\n" +
                              "Solution runtime summary: {2} ticks ({3} ms)\n\n",
                              i + 1, testcaseResult, sw.ElapsedTicks, sw.ElapsedMilliseconds);
            }

            results.Close();
        }
    }
}