using System;

public class Hra
{
    public int SkoreHrac { get; set; }

    public int SkoreNepritel { get; set; }

    public Random generatorVoleb = new Random();

    public Hra()
    {
        SkoreHrac = 0;
        SkoreNepritel = 0;
    }

    public void start()
    {
        while (true)
        {
            Console.Clear();
            menu();
            ConsoleKeyInfo Klavesa = Console.ReadKey();
            Console.WriteLine();

            int volbaHrace = 0;
            int volbaNepritel = generatorVoleb.Next(1, 4);

            if (Klavesa.Key == ConsoleKey.NumPad1)
            {
                volbaHrace = 1;
                souboj(volbaHrace, volbaNepritel);
            }
            else if (Klavesa.Key == ConsoleKey.NumPad2)
            {
                volbaHrace = 2;
                souboj(volbaHrace, volbaNepritel);

            }
            else if (Klavesa.Key == ConsoleKey.NumPad3)
            {
                volbaHrace = 3;
                souboj(volbaHrace, volbaNepritel);

            }
            else
            {
                Console.WriteLine("Neplatná volba!");
            }

            Thread.Sleep(500);
            if(this.SkoreHrac >= 5)
            {
                Console.Clear();
                Console.WriteLine("Vyhrál jsi!");
                break;
            }
            else if(this.SkoreNepritel >= 5)
            {
                Console.Clear();
                Console.WriteLine("Prohrál jsi!");
                break;

            }

        }

    }

    public void souboj(int volbaHrace, int volbaNepritel)
    {
        string nepritelVec = "";

        if(volbaHrace == 1)
        {
            nepritelVec = "kámen";
        }
        else if(volbaHrace == 2)
        {
            nepritelVec = "nůžky";
        }
        else
        {
            nepritelVec = "papír";
        }

        if (volbaHrace == volbaNepritel)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Remmíza!, nepřítel zlovil: " + nepritelVec);
        }
        else if ((volbaHrace == 1 && volbaNepritel == 2) || (volbaHrace == 2 && volbaNepritel == 3) || (volbaHrace == 3 && volbaNepritel == 1))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Výhra!, nepřítel zlovil: " + nepritelVec);
            this.SkoreHrac += 1;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Prohra!, nepřítel zlovil: " + nepritelVec);
            this.SkoreNepritel += 1;
        }
        Console.ResetColor();
    }

    public void menu()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Hrač: " + this.SkoreHrac);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Nepřítel: " + this.SkoreNepritel);
        Console.ResetColor();
        Console.WriteLine("---------------");
        Console.WriteLine("Kolo hráče:");
        Console.WriteLine("1 - kámen");
        Console.WriteLine("2 - nůžky");
        Console.WriteLine("3 - papír");
        Console.WriteLine("---------------");
    }

}

class Program
{
    static void Main(string[] args)
    {


        Hra h = new Hra();
        h.start();

        Console.ReadLine();
    }
}
