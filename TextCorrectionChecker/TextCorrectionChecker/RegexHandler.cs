using System.Linq;
using System.Text.RegularExpressions;

namespace TextCorrectionChecker {

    public static class RegexHandler {

        public static void CreateNativeCode() {
            CheckText("Make native code. Ok?");
        }

        public static bool CheckText(string textcase) {
            string[] sentences = new Regex(@"(?<=[\.!\?])\s+").Split(textcase);
            foreach (string sentence in sentences)
            {
                string[] words = new Regex(@"[^A-Za-z\-]+")
                    .Split(sentence)
                    .Where(x => x != "")
                    .ToArray();
                string[] separators = new Regex(@"[A-Za-z\-]+")
                    .Split(sentence)
                    .Where(x => x != "")
                    .ToArray();
                // Проверка на корректность разделителей
                if (separators
                    .Take(separators.Length - 1)
                    .Any(x => !new Regex(@"^[;,\s][\s(\–\s)(\—\s)]?")
                        .IsMatch(x))) 
                {
                    continue;
                }
                // Проверка последних символов
                if (!new Regex(@"^(\.{3}|[\.\?!])$")
                        .IsMatch(separators.Last()))
                {
                    continue;
                }
                // Проверка на корректность слов
                if (words
                    .Skip(1)
                    .Any(x => !new Regex(@"^([A-Z][A-Z]*|[A-Za-z]([a-z]+(\-[a-z]{2,})?)?)$")
                        .IsMatch(x))) 
                {
                    continue;
                }
                // Проверка первого слова
                if (new Regex(@"^([A-Z][A-Z]*|[A-Z]([a-z]+(\-[a-z]{2,})?)?)$")
                        .IsMatch(words.First()))
                {
                    return true;
                }
            }

            return false;
        }
    }
}