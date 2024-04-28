using System;
using System.Collections.Generic;
class Program
{

    // задание номер 8

    abstract class Task
    {
        public Task(string text) { }
        protected string print = "";
        protected abstract void ParseText(string text);
        public override string ToString()
        {
            return print;
        }
        protected virtual string Print(string text)
        {
            return text;
        }
        protected string result;

        class Task_8 : Task
        {
            string formattedText;
            public Task_8(string text) : base(text)
            {
                this.formattedText = FormatText(text);
            }
            public override string ToString()
            {
                return formattedText;
            }
            private string FormatText(string text)
            {
                string[] words = text.Split();
                List<string> lines = new List<string>();
                string line = "";
                foreach (string word in words)
                {
                    if (line.Length + word.Length > 50)
                    {
                        line = line.Remove(line.Length - 1);
                        lines.Add(line);
                        line = "";
                    }
                    line += word + " ";
                }
                line = line.Remove(line.Length - 1);
                lines.Add(line);
                lines = AddSpaces(lines);

                string formattedText = "";
                foreach (string l in lines)
                {
                    formattedText += l + "\n";
                }
                return formattedText;
            }
            private List<string> AddSpaces(List<string> lines)
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    string[] words = lines[i].Split(" ");
                    int remainingSpaces = 50 - lines[i].Length;
                    int spacesToAdd = remainingSpaces / (words.Length - 1);
                    int extraSpaces = remainingSpaces % (words.Length - 1);
                    for (int j = 0; j < words.Length - 1; j++)
                    {
                        for (int k = 0; k < spacesToAdd + 1; k++)
                        {
                            words[j] += " ";
                        }
                        if (extraSpaces > 0)
                        {
                            words[j] += " ";
                            extraSpaces = extraSpaces - 1;
                        }
                    }
                    lines[i] = string.Join("", words);
                }
                return lines;
            }

            protected override void ParseText(string text) { }
        }

        static void Main()
        {
            Task_8 text = new Task_8("После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии. Анализ данных показал, что основной участник разрушения лесного покрова – человеческая деятельность. За последние десятилетия рост объема вырубки достиг критических показателей. Главными факторами, способствующими этому, являются промышленные рубки, производство древесины, расширение сельскохозяйственных угодий и незаконная добыча древесины. Это приводит к серьезным экологическим последствиям, таким как потеря биоразнообразия, ухудшение климата и угроза вымирания многих видов животных и растений.");
            Console.WriteLine(text);
        }



        // задание номер 9 + 10

        //class Task9 : Task

        //{
        //    string text;
        //    string[] para;
        //    int[] count_kolvo_para;

        //    public Task9(string text) : base(text)
        //    {
        //        this.text = text;
        //        this.para = new string[text.Length - 1];
        //        this.count_kolvo_para = new int[text.Length - 1];
        //    }
        //    public override string ToString()
        //    {
        //        return text;
        //    }

        //    public void ProcessText()
        //    {
        //        int j = 0;
        //        for (int i = 0; i < text.Length - 1; i++)
        //        {
        //            bool flag = false;
        //            string new_para = text.Substring(i, 2);
        //            for (int j2 = 0; j2 < para.Length; j2++)
        //            {
        //                if (para[j2] == new_para)
        //                {
        //                    count_kolvo_para[j2] += 1;
        //                    flag = true;
        //                    break;
        //                }
        //            }
        //            if (flag == false)
        //            {
        //                para[j] = new_para;
        //                count_kolvo_para[j] = 1;
        //                j++;
        //            }
        //        }
        //        para = para[0..j];
        //        count_kolvo_para = count_kolvo_para[0..j];

        //        SortParaByCount();

        //        PrintParaCount();

        //        PrintFormatText(PrintNewText(text));
        //    }

        //    private string[,] PrintNewText(string text)
        //    {
        //        string[,] kode = new string[2, 5] { { para[0], para[1], para[2], para[3], para[4] }, { "$", "@", "%", "#", "~" } };

        //        for (int i = 0; i < 5; i++)
        //        {
        //            text = text.Replace(kode[0, i], kode[1, i]);
        //            Console.WriteLine($"{kode[0, i]} - {kode[1, i]}");
        //        }
        //        Console.WriteLine("Текст, переформатированный по таблице: " + text.ToString());
        //        return kode;
        //    }

        //    private void SortParaByCount()
        //    {
        //        for (int i = 0; i < count_kolvo_para.Length; i++)
        //        {
        //            for (int j2 = i; j2 < count_kolvo_para.Length; j2++)
        //                if (count_kolvo_para[i] < count_kolvo_para[j2])
        //                {
        //                    int old = count_kolvo_para[j2];
        //                    count_kolvo_para[j2] = count_kolvo_para[i];
        //                    count_kolvo_para[i] = old;
        //                    string p = para[j2];
        //                    para[j2] = para[i];
        //                    para[i] = p;
        //                }
        //        }
        //    }

        //    private void PrintParaCount()
        //    {
        //        for (int i = 0; i < count_kolvo_para.Length; i++)
        //        {
        //            Console.WriteLine($"пара {para[i]} количество {count_kolvo_para[i]}");
        //        }
        //    }

        //    // для 10 задачи:
        //    private void PrintFormatText(string[,] kode)
        //    {
        //        for (int i = 0; i < 5; i++)
        //        {
        //            text = text.Replace(kode[1, i], kode[0, i]);
        //        }
        //        Console.WriteLine("Текст, переформатированный обратно по таблице: " + text.ToString());
        //    }

        //    protected override void ParseText(string text) { }
        //}

        //static void Main(string[] args)
        //{
        //    Task9 textProcessor = new Task9("Двигатель самолета это сложная инженерная конструкция, обеспечивающая подъем, управление и движение в воздухе. Он состоит из множества компонентов, каждый из которых играет важную роль в общей работе механизма. Внутреннее устройство двигателя включает в себя компрессор, камеру сгорания, турбину и системы управления и охлаждения. Принцип работы основан на воздушно-топливной смеси, которая подвергается сжатию, воспламенению и расширению, обеспечивая движение воздушного судна.");
        //    textProcessor.ProcessText();
        //}

        // задание номер 12

        //static void Main(string[] args)
        //{
        //    Task12 textProcessor = new Task12("Двигатель самолета это это это сложная инженерная конструкция, обеспечивающая подъем, управление и движение в воздухе. Он состоит из множества компонентов, каждый из которых играет важную роль в общей работе механизма. Внутреннее устройство двигателя включает в себя компрессор, камеру сгорания, турбину и системы управления и охлаждения. Принцип работы основан на воздушно-топливной смеси, которая подвергается сжатию, воспламенению и расширению, обеспечивая движение воздушного судна.");
        //    textProcessor.ProcessText();
        //    Console.WriteLine(textProcessor.ToString());
        //}


        //class Task12 : Task
        //{
        //    string text;
        //    public Task12(string text) : base(text)
        //    {
        //        this.text = text;
        //    }
        //    public override string ToString()
        //    {
        //        return text;
        //    }

        //    public void ProcessText()
        //    {
        //        string Text = RemovePunctuation(text);
        //        string[] words = Text.Split(" ");
        //        (string[] uniqueWords, int[] wordCounts) = CountUniqueWords(words);
        //        GenerateCodeTable(uniqueWords, wordCounts);

        //        string RemovePunctuation(string text) // убираем символы из строки
        //        {
        //            string[] punctuation = { ",", ".", "?", "!" };
        //            string result = text;
        //            foreach (string symbol in punctuation)
        //            {
        //                result = result.Replace(symbol, "");
        //            }
        //            return result;
        //        }

        //        (string[], int[]) CountUniqueWords(string[] words) // заполняем массивы кол-ва слов + сами слова
        //        {
        //            string[] uniqueWords = new string[words.Length];
        //            int[] wordCounts = new int[words.Length];

        //            int j = 0;
        //            for (int i = 0; i < words.Length; i++)
        //            {
        //                bool flag = false;
        //                string currentWord = words[i];
        //                for (int j2 = 0; j2 < uniqueWords.Length; j2++)
        //                {
        //                    if (uniqueWords[j2] == currentWord)
        //                    {
        //                        wordCounts[j2] += 1;
        //                        flag = true;
        //                        break;
        //                    }
        //                }
        //                if (!flag)
        //                {
        //                    uniqueWords[j] = currentWord;
        //                    wordCounts[j] = 1;
        //                    j++;
        //                }
        //            }

        //            Array.Resize(ref uniqueWords, j); // оставляет только первые 5 нам нужных элементов
        //            Array.Resize(ref wordCounts, j);

        //            return (uniqueWords, wordCounts);
        //        }

        //        void GenerateCodeTable(string[] words, int[] counts) // создает кодовую таблицу табличку 2:5
        //        {
        //            string[,] codeTable = new string[2, 5];

        //            for (int i = 0; i < Math.Min(5, words.Length); i++)
        //            {
        //                codeTable[0, i] = words[i];
        //                codeTable[1, i] = i < 5 ? new string("$@%#~"[i], 1) : ""; // Генерация кодов
        //            }

        //            ApplyCodesToText(codeTable);
        //        }

        //        void ApplyCodesToText(string[,] codeTable) // переобразует текст обратно к нормальному виду
        //        {
        //            string processedText = text;
        //            for (int i = 0; i < 5; i++)
        //            {
        //                processedText = processedText.Replace(codeTable[1, i], codeTable[0, i]);
        //            }
        //            Console.WriteLine();
        //            this.text = processedText;
        //        }
        //    }
        //    protected override void ParseText(string text) { }
        //}

        // задание номер 13
        //class Task13 : Task
        //{
        //    string text;

        //    public Task13(string text) : base(text)
        //    {
        //        this.text = text;
        //    }
        //    public override string ToString()
        //    {
        //        return text;
        //    }

        //    public void CountChars()
        //    {
        //        string[] words = text.Split(' ');
        //        char[] chars = new char[words.Length];
        //        int[] countKolvoWord = new int[words.Length];

        //        int j = 0;
        //        for (int i = 0; i < words.Length; i++)
        //        {
        //            bool flag = false;
        //            char newChar = char.ToLower(words[i][0]);
        //            for (int j2 = 0; j2 < chars.Length; j2++)
        //            {
        //                if (chars[j2] == newChar)
        //                {
        //                    countKolvoWord[j2] += 1;
        //                    flag = true;
        //                    break;
        //                }
        //            }
        //            if (!flag)
        //            {
        //                chars[j] = newChar;
        //                countKolvoWord[j] = 1;
        //                j++;
        //            }
        //        }
        //        chars = chars[0..j];
        //        countKolvoWord = countKolvoWord[0..j];

        //        for (int i = 0; i < chars.Length; i++)
        //        {
        //            Console.WriteLine($"{100 * countKolvoWord[i] / words.Length} - {chars[i]}");
        //        }
        //        Console.WriteLine();
        //    }
        //    protected override void ParseText(string text) { }
        //}
        //static void Main(string[] args)
        //{
        //    Task13 charCounter = new Task13("Двигатель самолета – это сложная инженерная конструкция, обеспечивающая подъем, управление и движение в воздухе. Он состоит из множества компонентов, каждый из которых играет важную роль в общей работе механизма. Внутреннее устройство двигателя включает в себя компрессор, камеру сгорания, турбину и системы управления и охлаждения. Принцип работы основан на воздушно-топливной смеси, которая подвергается сжатию, воспламенению и расширению, обеспечивая движение воздушного судна.");
        //    charCounter.CountChars();
        //}

        // задание номер 15

        //class Task15 : Task
        //{
        //    private string text;
        //    private int sum;
        //    public Task15(string text) : base(text)
        //    {
        //        this.text = text;
        //    }
        //    public override string ToString()
        //    {
        //        return $"{sum}";
        //    }

        //    public void Process()
        //    {
        //        Remove();
        //        SumOfNumbers();
        //    }
        //    public void Remove()
        //    {
        //        string[] t = new string[] { ",", ".", "?", "!", "-" };
        //        for (int i = 0; i < t.Length; i++)
        //        {
        //            text = text.Replace(t[i], " ");
        //        }
        //    }

        //    public void SumOfNumbers()
        //    {
        //        int sum = 0;
        //        string[] words = text.Split(' ');

        //        foreach (string word in words)
        //        {
        //            if (int.TryParse(word, out int number))
        //            {
        //                sum += number;
        //            }
        //        }
        //        this.sum = sum;
        //    }
        //    protected override void ParseText(string text) { }
        //}

        //static void Main(string[] args)
        //{
        //    Task15 text = new Task15("1 июля 2015 года Греция объявила о дефолте по государственному долгу, став первой развитой страной в истории, которая не смогла выплатить свои долговые обязательства в полном объеме. Сумма дефолта составила порядка 1,6 миллиарда евро. Этому предшествовали долгие переговоры с международными кредиторами, такими как Международный валютный фонд (МВФ), Европейский центральный банк (ЕЦБ) и Европейская комиссия (ЕК), о программах финансовой помощи и реструктуризации долга. Основными причинами дефолта стали недостаточная эффективность реформ, направленных на улучшение финансовой стабильности страны, а также политическая нестабильность, что вызвало потерю доверия со стороны международных инвесторов и кредиторов. Последствия дефолта оказались глубокими и долгосрочными: сокращение кредитного рейтинга страны, увеличение затрат на заемный капитал, рост стоимости заимствований и утрата доверия со стороны международных инвесторов.");
        //    text.Process();
        //    Console.WriteLine("Сумма: " + text.ToString());
        //}
    }
}