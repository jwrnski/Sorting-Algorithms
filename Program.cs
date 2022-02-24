using System;

namespace Sortowanie
{
    class Program
    {
        public static void Start()
        {
            Console.Write("Insert array size> ");
            int size = int.Parse(Console.ReadLine());
            Console.Write("Insert lower limit of randomized numbers> ");
            int lower = int.Parse(Console.ReadLine());
            Console.Write("Insert upper limit of randomized numbers> ");
            int upper = int.Parse(Console.ReadLine());
            Console.Write("Would you like to print the array? [Y/n]");
            char decision = char.Parse(Console.ReadLine());
            bool print = false;
            switch (decision)
            {
                case 'y':
                    print = true;
                    makeArray(size, lower, upper, print);
                    break;
                case 'n':
                    makeArray(size, lower, upper, print);
                    break;
            }
        }
        public static void makeArray(int size, int lower, int upper, bool print)
        {
            int[] tab = new int[size];
            Random numbers = new Random();
            for(int c=0; c<size; c++)
            {
                int num = numbers.Next(lower, upper);
                tab[c] = num;
            }
            if (print)
            {
                for(int i=0; i<size; i++)
                {
                    Console.Write(tab[i] + " ");
                }
            }
            sortingAlgs(tab);
        }
        public static void sortingAlgs(int[] tab)
        {
            Console.WriteLine("\nChoose a sorting algorithm: ");
            Console.WriteLine("\n1. Gnome sort\n2. Bubble sort\n3. Selection sort\n4. Bogosort\n");
            int pos = 0; 
            try
            {
                pos = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Value must be a number.");
            }
            switch (pos)
            {
                case 1:
                    Console.WriteLine("You have choosen Gnome sort.");
                    Gnome(tab);
                    break;
                case 2:
                    Console.WriteLine("You have choosen Bubble sort.");
                    Bubble(tab);
                    break;
                case 3:
                    Console.WriteLine("You have choosen Selection sort.");
                    Select(tab);
                    break;
                case 4:
                    Console.WriteLine("You have choosen Bogosort. Good luck.");
                    Bogo(tab);
                    break;
                
            }
        }
        public static void Gnome(int[] tab)
        {
            int p=0, temp;
            while (p < tab.Length - 1)
            {
                if (tab[p] > tab[p + 1])
                {
                    temp = tab[p + 1];
                    tab[p + 1] = tab[p];
                    tab[p] = temp;

                    if (p > 0)
                    {
                        p -= 1;
                    }
                }
                else
                {
                    p += 1;
                }
            }
            Print(tab);
        }
        public static void Bubble(int[] tab)
        {
            int temp;
            for (int i = 0; i < tab.Length; i++)
            {
                for (int j = 0; j < tab.Length - (1 + i); j++)
                {
                    if (tab[j] < tab[j + 1])
                    {
                        temp = tab[j + 1];
                        tab[j + 1] = tab[j];
                        tab[j] = temp;
                    }
                }               
            }
            Print(tab);
        }
        public static void Select(int[] tab)
        {
            int poz;
            for (int n = 0; n < tab.Length; n++)
            {
                poz = n;
                for (int i = n + 1; i < tab.Length; i++)
                {
                    if (tab[i] < tab[poz])
                    {
                        poz = i;
                        int temp;
                        temp = tab[n];
                        tab[n] = tab[poz];
                        tab[poz] = temp;
                    }
                }              
            }
            Print(tab);
        }
        public static void Bogo(int[] tab)
        {
            bool gotowe;
            int r = tab.Length;
            for (; ; )
            {
                gotowe = true;
                for (int i = 0; i < tab.Length - 1; i++)
                {
                    if (tab[i] > tab[i + 1])
                    {
                        gotowe = false;
                        break;
                    }
                }
                if (gotowe) break;
                Random num = new Random();
                for (int i = r - 1; i > 0; --i)
                {
                    int x = num.Next(0, r);
                    int temp;
                    temp = tab[i];
                    tab[i] = tab[x];
                    tab[x] = temp;
                }
            }
            Print(tab);
        }
        public static void Print(int[] tab)
        {
            int size = tab.Length;
            for(int c=0; c<size; c++)
            {
                Console.Write(tab[c] + " ");
            }
            Console.WriteLine("\nWould you like to repeat? [Y/n]");
            char repeat = char.Parse(Console.ReadLine());
            if (repeat == 'y') Start();
            else Environment.Exit(0);
        }
        static void Main(string[] args)
        {
            Start();
        }
    }
}
