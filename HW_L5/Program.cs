

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите строку текста:");
        string input = Console.ReadLine();

        while (true)
        {
            Console.WriteLine("\nМеню выбора действий:");
            Console.WriteLine("1. Найти слова, содержащие максимальное количество цифр.");
            Console.WriteLine("2. Найти самое длинное слово и определить, сколько раз оно встретилось в тексте.");
            Console.WriteLine("3. Заменить цифры от 0 до 9 на слова «ноль», «один», …, «девять».");
            Console.WriteLine("4. Выйти из программы.");

            Console.Write("Выберите действие (1-4): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    FindWordsWithMaxDigits(input);
                    break;
                case "2":
                    FindLongestWordAndCount(input);
                    break;
                case "3":
                    ReplaceDigitsWithWords(ref input);
                    Console.WriteLine($"Текст после замены цифр: {input}");
                    break;
                default:
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    break;
            }
        }
    }

    static void FindWordsWithMaxDigits(string text)
    {
        string[] words = text.Split(new char[] { ' ', ',', '.', '!', '?', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
        int maxDigitsCount = 0;
        foreach (var word in words)
        {
            int digitsCount = CountDigits(word);
            if (digitsCount > maxDigitsCount)
                maxDigitsCount = digitsCount;
        }

        Console.WriteLine($"Слова с максимальным количеством цифр ({maxDigitsCount}):");
        foreach (var word in words)
        {
            if (CountDigits(word) == maxDigitsCount)
                Console.WriteLine(word);
        }
    }

    static int CountDigits(string word)
    {
        int count = 0;
        foreach (char c in word)
        {
            if (char.IsDigit(c))
                count++;
        }
        return count;
    }

    static void FindLongestWordAndCount(string text)
    {
        string[] words = text.Split(new char[] { ' ', ',', '.', '!', '?', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
        string longestWord = "";
        int longestWordCount = 0;
        foreach (var word in words)
        {
            int count = 0;
            foreach (var w in words)
            {
                if (w == word)
                    count++;
            }
            if (word.Length > longestWord.Length || (word.Length == longestWord.Length && count > longestWordCount))
            {
                longestWord = word;
                longestWordCount = count;
            }
        }

        if (!string.IsNullOrEmpty(longestWord))
        {
            Console.WriteLine($"Самое длинное слово: {longestWord}");
            Console.WriteLine($"Количество повторений: {longestWordCount}");
        }
        else
        {
            Console.WriteLine("Текст не содержит слов.");
        }
    }

    static void ReplaceDigitsWithWords(ref string text)
    {
        string[] digitWords = { "ноль", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };

        for (int i = 0; i < 10; i++)
        {
            text = text.Replace(i.ToString(), digitWords[i]);
        }
    }
}