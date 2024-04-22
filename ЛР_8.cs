using System;

class Program
{

    // задание номер 8

    abstract class Task
    {
        public Task(string text) { }
        protected abstract void ParseText(string text);
    }

    class Task8 : Task
    {
        private string _text;
        public Task8(string text) : base(text)
        {
            _text = text;
        }

        public static string FormatText(string text)
        {
            int maxLength = 50;
            int currentLength = 0;
            string result = "";

            string[] words = text.Split(' ');

            foreach (string word in words)
            {
                if (currentLength + word.Length > maxLength)
                {
                    result = result.TrimEnd() + '\n';
                    currentLength = 0;
                }

                result += word + " ";
                currentLength += word.Length + 1;
            }
            return result.TrimEnd();
        }

        protected override void ParseText(string text)
        {
            // Добавить необходимую логику для разбора текста, если это требуется
        }
    }


    static void Main()
    {
        string text = "После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии. Анализ данных показал, что основной участник разрушения лесного покрова – человеческая деятельность. За последние десятилетия рост объема вырубки достиг критических показателей. Главными факторами, способствующими этому, являются промышленные рубки, производство древесины, расширение сельскохозяйственных угодий и незаконная добыча древесины. Это приводит к серьезным экологическим последствиям, таким как потеря биоразнообразия, ухудшение климата и угроза вымирания многих видов животных и растений.";
        Console.WriteLine(Task8.FormatText(text));
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
    //        Console.WriteLine("Текст, переформатированный по таблице: " + text);
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
    //        Console.WriteLine("Текст, переформатированный обратно по таблице: " + text);
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
    //    Task12 textProcessor = new Task12("Двигатель самолета это сложная инженерная конструкция, обеспечивающая подъем, управление и движение в воздухе. Он состоит из множества компонентов, каждый из которых играет важную роль в общей работе механизма. Внутреннее устройство двигателя включает в себя компрессор, камеру сгорания, турбину и системы управления и охлаждения. Принцип работы основан на воздушно-топливной смеси, которая подвергается сжатию, воспламенению и расширению, обеспечивая движение воздушного судна.");
    //    textProcessor.ProcessText();
    //}

    //class Task12 : Task
    //{
    //    string text;
    //    public Task12(string text) : base(text)
    //    {
    //        this.text = text;
    //    }

    //    public void ProcessText()
    //    {
    //        string text_ = text;
    //        string text_copy = text_;
    //        string[] t = new string[] { ",", ".", "?", "!" };
    //        for (int i = 0; i < t.Length; i++)
    //        {
    //            text_ = text_.Replace(t[i], "");
    //        }
    //        string[] words = text_.Split(" ");

    //        string[] wordss = new string[words.Length];
    //        int[] count_kolvo_word = new int[words.Length];

    //        int j = 0;
    //        for (int i = 0; i < words.Length; i++)
    //        {
    //            bool flag = false;
    //            string new_words = words[i];
    //            for (int j2 = 0; j2 < wordss.Length; j2++)
    //            {
    //                if (wordss[j2] == new_words)
    //                {
    //                    count_kolvo_word[j2] += 1;
    //                    flag = true;
    //                    break;
    //                }
    //            }
    //            if (flag == false)
    //            {
    //                wordss[j] = new_words;
    //                count_kolvo_word[j] = 1;
    //                j++;
    //            }
    //        }

    //        for (int i = 0; i < count_kolvo_word.Length; i++)
    //        {
    //            for (int j2 = i; j2 < count_kolvo_word.Length; j2++)
    //            {
    //                if (count_kolvo_word[i] < count_kolvo_word[j2])
    //                {
    //                    int old = count_kolvo_word[j2];
    //                    count_kolvo_word[j2] = count_kolvo_word[i];
    //                    count_kolvo_word[i] = old;
    //                    string p = wordss[j2];
    //                    wordss[j2] = wordss[i];
    //                    wordss[i] = p;
    //                }
    //            }
    //        }
    //        wordss = wordss[0..j];
    //        count_kolvo_word = count_kolvo_word[0..j];

    //        string[,] kode = new string[2, 5] { { wordss[0], wordss[1], wordss[2], wordss[3], wordss[4] }, { "$", "@", "%", "#", "~" } };

    //        Console.WriteLine("Таблица кодов:");
    //        for (int i = 0; i < 5; i++)
    //        {
    //            Console.WriteLine($"{kode[0, i]} - {kode[1, i]}");
    //        }
    //        Console.WriteLine();

    //        Console.WriteLine("Пары и их количество:");

    //        for (int i = 0; i < count_kolvo_word.Length; i++)
    //        {
    //            Console.WriteLine($"Слово: {wordss[i]} ,количество: {count_kolvo_word[i]}");
    //        }
    //        Console.WriteLine();

    //        for (int i = 0; i < 5; i++)
    //        {
    //            text_copy = text_copy.Replace(kode[0, i], kode[1, i]);
    //        }
    //        Console.WriteLine();
    //    }

    //    protected override void ParseText(string text)
    //    {
    //    }
    //}

    // задание номер 13
    //class Task13 : Task
    //{
    //    string text;

    //    public Task13(string text) : base(text)
    //    {
    //        this.text = text;
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
    //    Console.WriteLine("Введите текст:");
    //    Task13 charCounter = new Task13("Двигатель самолета – это сложная инженерная конструкция, обеспечивающая подъем, управление и движение в воздухе. Он состоит из множества компонентов, каждый из которых играет важную роль в общей работе механизма. Внутреннее устройство двигателя включает в себя компрессор, камеру сгорания, турбину и системы управления и охлаждения. Принцип работы основан на воздушно-топливной смеси, которая подвергается сжатию, воспламенению и расширению, обеспечивая движение воздушного судна.");
    //    charCounter.CountChars();
    //}

    // задание номер 15

    //class Task15 : Task
    //{
    //    private string text;
    //    public Task15(string text) : base(text)
    //    {
    //        this.text = text;
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
    //            text = text.Replace(t[i], "");
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
    //        Console.WriteLine(sum);
    //    }

    //    protected override void ParseText(string text) { }
    //}

    //static void Main(string[] args)
    //{
    //    Console.WriteLine("Введите текст:");
    //    Task15 text = new Task15("1 июля 2015 года Греция объявила о дефолте по государственному долгу, став первой развитой страной в истории, которая не смогла выплатить свои долговые обязательства в полном объеме. Сумма дефолта составила порядка 1,6 миллиарда евро. Этому предшествовали долгие переговоры с международными кредиторами, такими как Международный валютный фонд (МВФ), Европейский центральный банк (ЕЦБ) и Европейская комиссия (ЕК), о программах финансовой помощи и реструктуризации долга. Основными причинами дефолта стали недостаточная эффективность реформ, направленных на улучшение финансовой стабильности страны, а также политическая нестабильность, что вызвало потерю доверия со стороны международных инвесторов и кредиторов. Последствия дефолта оказались глубокими и долгосрочными: сокращение кредитного рейтинга страны, увеличение затрат на заемный капитал, рост стоимости заимствований и утрата доверия со стороны международных инвесторов.");
    //    text.Process();
    //}
}