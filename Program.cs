using System;
static class Hello
{

    //задание 3.4

    public class Program
    {
        public class Sportsmen
        {
            string name;
            double resultss;
            public Sportsmen(string name_, double results_)
            {
                name = name_;
                resultss = results_;
            }
            public double GetResult()
            {
                return resultss;
            }
            public string Name { get { return name; } }
            public double Resultss { get { return resultss; } }
            public void InfoP()
            {
                Console.WriteLine($"имя: {Name} результат: {resultss} ");
            }
            public static Sportsmen[] AllGroup(Sportsmen[] group1, Sportsmen[] group2)
            {
                Sportsmen[] group = new Sportsmen[group1.Length + group2.Length];
                for (int i = 0; i < group1.Length; i++)
                {
                    group[i] = group1[i];   
                }
                for (int i = 0;i < group2.Length; i++)
                {
                    group[i + group2.Length] = group2[i];
                }
                return group;
            }

            public static Sportsmen[] MergeSort(Sportsmen[] array)
            {
                if (array.Length < 2)
                {
                    return array;
                }

                int mid = array.Length / 2;
                Sportsmen[] left = new Sportsmen[mid];
                Sportsmen[] right = new Sportsmen[array.Length - mid];

                for (int i = 0; i < mid; i++)
                {
                    left[i] = array[i];
                }
                for (int i = mid; i < array.Length; i++)
                {
                    right[i - mid] = array[i];
                }
                MergeSort(left); MergeSort(right);
                Merge(array, left, right);
                return array;
            }

            public static void Merge(Sportsmen[] targetarray, Sportsmen[] array1, Sportsmen[] array2)
            {
                int array1minindex = 0;
                int array2minindex = 0;

                int targetarrayminindex = 0;

                if (array1[array1minindex].resultss >= array2[array2minindex].resultss)
                {
                    targetarray[targetarrayminindex] = array1[array1minindex];
                    array1minindex++;
                }
                else
                {
                    targetarray[targetarrayminindex] = array2[array2minindex];
                    array2minindex++;
                }
                targetarrayminindex++;

                while (array1minindex < array1.Length)
                {
                    targetarray[targetarrayminindex] = (array1[array1minindex]);
                    array1minindex++;
                    targetarrayminindex++;
                }

                while (array2minindex < array2.Length)
                {
                    targetarray[targetarrayminindex] = (array2[array2minindex]);
                    array2minindex++;
                    targetarrayminindex++;
                }
            }
        }

        class Mskiers : Sportsmen
        {
            int result;
            public Mskiers(string name_, int results_) : base(name_, results_)
            {
                result = results_;
            }

        }

        class Wskiers : Mskiers
        {
            int results;
            public Wskiers(string name_, int results_) : base(name_, results_)
            {
                results = results_;
            }
        }

        static void Sort(Sportsmen[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                for (int j = i; j < list.Length; j++)
                    if (list[i].GetResult() < list[j].GetResult())
                    {
                        Sportsmen person_now = list[j]; // меняем игроков 
                        list[j] = list[i];
                        list[i] = person_now;
                    }
            }
        }
        public static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            Mskiers[] group1 = new Mskiers[n1];
            Wskiers[] group2 = new Wskiers[n2];
            //Sportsmen[] allgroup = Program.Sportsmen.AllGroup(group1, group2);

            for (int i = 0; i < n1; i++)
            {
                string name_ = Console.ReadLine();
                int result_ = int.Parse(Console.ReadLine());

                Mskiers Person = new Mskiers(name_, result_);

                group1[i] = Person;
                //allgroup[i] = Person;
            }

            for (int i = 0; i < n2; i++)
            {
                string name_ = Console.ReadLine();
                int result_ = int.Parse(Console.ReadLine());

                Wskiers Person = new Wskiers(name_, result_);

                group2[i] = Person;
                //allgroup[i + n1] = Person;
            }

            Sort(group1);
            Sort(group2);
            Sportsmen[] allgroup = Program.Sportsmen.AllGroup(group1, group2);
            allgroup = Program.Sportsmen.MergeSort(allgroup);

            Console.WriteLine("1 группа:");
            for (int i = 0; i < n1; i++)
            {
                Console.Write($"{i + 1} место:"); ;
                group1[i].InfoP();
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("2 группа:");
            for (int i = 0; i < n2; i++)
            {
                Console.Write($"{i + 1} место:"); ;
                group2[i].InfoP();
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Все участники:");
            for (int i = 0; i < n1 + n2; i++)
            {
                Console.Write($"{i + 1} место:"); ;
                allgroup[i].InfoP();
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}