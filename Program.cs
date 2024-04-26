
using System;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
public class Task
{
    string text;
    public Task(string text)
    {
        this.text = text;
    }
}
public class Task_2 : Task
{
    string text;
    public Task_2(string text) : base(text)
    {
        this.text = text;
    }
    public override string ToString()
    {
        return text;
    }
    public string ReverseWords()
    {
        StringBuilder result = new StringBuilder();
        string[] words = text.Split(' ');

        int wordIndex = 0;
        foreach (char c in text)
        {
            if (char.IsLetterOrDigit(c))
            {
                result.Insert(result.Length - wordIndex, c);
            }
            else
            {
                result.Append(c);
                wordIndex = 0;
            }

            if (wordIndex < words.Length )
            {
                result.Append(' ');
                wordIndex++;
            }

            wordIndex++;
        }

        return result.ToString();
    }
}
class Program
{
    static void Main()
    {
        Console.WriteLine("Ввести текст:");
        Task_2 processor = new Task_2(Console.ReadLine());
        string reversedText = processor.ReverseWords();
        Console.WriteLine("Перевернутый текст:");
        Console.WriteLine(reversedText.ToString());

        Console.WriteLine("Ввести два слова через пробел:");
        string inputText = Console.ReadLine();

        Task_1 finder = new Task_1(inputText);
        finder.FindCommonLetters();


        //TestFolderManager manager = new TestFolderManager();

        //manager.CreateTaskFile(1, "{\"task\": \"One\"}");
        //manager.CreateTaskFile(2, "{\"task\": \"Two\"}");


    }
    class Task_1 : Task
    {
        string word1;
        string word2;
        string text;
        public Task_1(string Text) : base(Text)
        {
            this.text = Text;
            string[] words = Text.Split(' ');

            if (words.Length != 2)
            {
                Console.WriteLine("Не два слова введено");
                return;
            }

            word1 = words[0];
            word2 = words[1];
        }
        public override string ToString()
        {
            return text;
        }

        public void FindCommonLetters()
        {
            var commonLetters = word1.Intersect(word2);

            foreach (char letter in commonLetters)
            {
                Console.Write(letter + "\n");
            }
        }
    }

    //class TestFolderManager
    //{
    //    private string desktopPath;
    //    private string testFolderPath;

    //    public TestFolderManager()
    //    {
    //        desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    //        testFolderPath = Path.Combine(desktopPath, "Test");

    //        if (!Directory.Exists(testFolderPath))
    //        {
    //            Directory.CreateDirectory(testFolderPath);
    //        }
    //    }

    //    public void CreateTaskFile(int taskId, string taskData)
    //    {
    //        string taskFilePath = Path.Combine(testFolderPath, "task_" + taskId + ".json");

    //        if (File.Exists(taskFilePath))
    //        {
    //            string existingData = File.ReadAllText(taskFilePath);
    //            Console.WriteLine("Data from existing file " + Path.GetFileName(taskFilePath) + ": " + existingData);
    //        }
    //        else
    //        {
    //            File.WriteAllText(taskFilePath, taskData);
    //            Console.WriteLine(Path.GetFileName(taskFilePath) + taskData);
    //        }
    //    }
    //}
}