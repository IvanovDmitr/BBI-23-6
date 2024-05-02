using System;
using System.Collections.Generic;
class Program
{
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

    }
    static void Main(string[] args)
    {
        Task12 textProcessor = new Task12("Двигатель самолета это это это сложная инженерная конструкция, обеспечивающая подъем, управление и движение в воздухе. Он состоит из множества компонентов, каждый из которых играет важную роль в общей работе механизма. Внутреннее устройство двигателя включает в себя компрессор, камеру сгорания, турбину и системы управления и охлаждения. Принцип работы основан на воздушно-топливной смеси, которая подвергается сжатию, воспламенению и расширению, обеспечивая движение воздушного судна.");
        textProcessor.ProcessText();
        Console.WriteLine(textProcessor.ToString());
    }

    class Task12 : Task
    {
        string text;
        public Task12(string text) : base(text)
        {
            this.text = text;
        }
        public override string ToString()
        {
            return text;
        }

        public void ProcessText()
        {
            string Text = RemovePunctuation(text);
            string[] words = Text.Split(" ");
            NewWords mostFamous = CountUniqueWords(words);
            GenerateCodeTable(mostFamous);

            string RemovePunctuation(string text) // убираем символы из строки
            {
                string[] punctuation = { ",", ".", "?", "!" };
                string result = text;
                foreach (string symbol in punctuation)
                {
                    result = result.Replace(symbol, "");
                }
                return result;
            }

            NewWords CountUniqueWords(string[] words) // структура для хранения и подсчета самых часто встречающихся слов
            {
                Dictionary<string, int> wordCounts = new Dictionary<string, int>();

                foreach (string word in words)
                {
                    if (wordCounts.ContainsKey(word))
                    {
                        wordCounts[word]++;
                    }
                    else
                    {
                        wordCounts[word] = 1;
                    }
                }

                NewWords mostFamous = new NewWords()
                {
                    Words = wordCounts.Keys.ToArray(),
                    Counts = wordCounts.Values.ToArray()
                };

                Array.Sort(mostFamous.Counts, mostFamous.Words);
                Array.Reverse(mostFamous.Counts);
                Array.Reverse(mostFamous.Words);

                return mostFamous;
            }

            void GenerateCodeTable(NewWords mostFamous) // создает кодовую таблицу табличку
            {
                string[,] codeTable = new string[2, 5];

                for (int i = 0; i < Math.Min(5, mostFamous.Words.Length); i++)
                {
                    codeTable[0, i] = mostFamous.Words[i];
                    codeTable[1, i] = i < 5 ? new string("$@%#~"[i], 1) : ""; // генерация кодов
                }

                ApplyCodesToText(codeTable);
            }

            void ApplyCodesToText(string[,] codeTable) // переобразует текст обратно к нормальному виду
            {
                string processedText = text;
                for (int i = 0; i < 5; i++)
                {
                    processedText = processedText.Replace(codeTable[1, i], codeTable[0, i]);
                }
                Console.WriteLine();
                text = processedText;
            }
        }
        protected override void ParseText(string text) { }
    }

    struct NewWords
    {
        public string[] Words;
        public int[] Counts;
    }
}