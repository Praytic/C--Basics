using System;
using System.Linq;

namespace TextCorrectionChecker {

    public static class CustomHandler {
        
        private static readonly char[] StartSentenceLetter = " ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
        private static readonly char[] AvailableSeparators = " ,.–—;\n\r".ToCharArray();
        private static readonly string[] EndSentence = { "...", ".", "!", "?", "\n", "\r\n" };
        private static readonly string[] FormattedSeparators = { "", " ", ", ", "; ", " – ", ", – ", " — ", ", — " };

        public static void CreateNativeCode() {
            CheckText("Make native code. Ok?");
        }

        public static bool CheckText(string textcase) {
            return NiceText(textcase);
        }


        private static bool NiceText(string text) {
            // Обычный split не подойдет, так как нужно сохранять разделитель, а regex нельзя использовать
            int index = 0;
            while (index < text.Length)
            {
                // Ищем символ конца текущего предложения
                int nextIndex = text.IndexOfAny(new[]{'!', '.', '?'}, index);
                // Если знака конца не нашлось, значит это последнее предложение и оно не корректное
                if (nextIndex == -1)
                {
                    return false;
                }
                // Ищем символ начала следующего предложения
                int lastIndex = text.IndexOfAny(StartSentenceLetter, nextIndex);
                if (lastIndex == -1)
                {
                    lastIndex = text.Length;
                }
                // Выделяем предложение
                string sentence = text.Substring(index, lastIndex - index);
                if (NiceSentence(sentence))
                {
                    return true;
                }
                index = lastIndex + 1;
            }
            // Проверка на хотябы одно красивое предложение
            return false;
        }

        private static bool NiceSentence(string sentence) {
            string[] words = sentence
                .Split(AvailableSeparators, StringSplitOptions.RemoveEmptyEntries);
            string[] separators = sentence
                .Split(words.ToArray(), StringSplitOptions.None);
            // Проверка на первую букву первого слова
            if (words.Length == 0 || !char.IsUpper(words[0][0]))
            {
                return false;
            }
            // Проверка на конец предложения среди вариаций EndSentence
            if (!EndSentence.Contains(separators.Last()))
            {
                return false;
            }
            // Проверка на знаки между словами
            if (!separators
                .Take(separators.Length - 1)
                .All(x => FormattedSeparators.Contains(x)))
            {
                return false;
            }
            // Проверка слов в предложении
            if (!words.All(NiceWord))
            {
                return false;
            }
            return true;
        }
        
        private static bool NiceWord(string word) {
            // Проверка на регистр букв и на аббревиатуру
            if (!word.EndsWith(word.Substring(1).ToLower()) &&
                word.ToUpper() != word)
            {
                return false;
            }
            // Проверка на корректное тире
            if (word.Count(x => x == '-') > 1)
            {
                return false;
            }
            // Проверка на количество букв между тире
            if (word.IndexOf('-') != -1 &&
                (word.IndexOf('-') <= 1 || 
                 word.IndexOf('-') >= word.Length - 2))
            {
                return false;
            }
            // Аббревиатура не может быть составным словом
            if (word.ToUpper() == word &&
                word.Contains('-'))
            {
                return false;
            }
            return true;
        }
    }
}