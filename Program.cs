using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace part_7_the_77
{

    //WORK ON ENSURING THAT NO INVALID THINGS CANT BE TYPED
    internal class Program
    {
        public static System.Timers.Timer randcolour = new System.Timers.Timer();
        public static ConsoleKeyInfo cki = new ConsoleKeyInfo();
        public static Random generator = new Random();
        public static List<string> Lshopping = new List<string>();
        public static List<int> Lrandom = new List<int>();
        public static string[] main = { "{After getting shot by the joke monkey, you fell into a deep sleep]",
            "[Memories of... something... begin flooding into your brain...]",
            "Which would you like to view (#)? ",
            "That is an invalid option.  Please select a valid option."};
        public static string[] memory = {
            "1. Shopping list",
            "2. Random list  ",
            "3. Neither      "};
        public static string[] shopping = {"Here is your shopping list:",
            "1. Carrot ",
            "2. Beet   ",
            "3. Celery ",
            "4. Radish ",
            "5. Cabbage"};
        public static string[] soption =
        {
             "1. Remove item by index   ",
             "2. Remove item by name    ",
             "3. Search for item by name",
             "4. Add an item            ",
             "5. Sort the list          ",
             "6. Clear the list         ",
             "7. Quit                   "
        };
        public static string[] srandom = { "Please enter a minimum and a maximum integer: ", //0
        "This is an invalid integer.  Enter real integers.", //1
        "Please select an option (#).  ", //2
        "This is an invalid option.  Enter a valid option.", //3
        "Please enter a value to remove.  ", //4
        "That is an invalid value.  Please enter a valid value", //5
        "Please enter a value to add.  ", //6
        "Press the S key to see the smallest value, and press the L key to see the greatest value.  ", //7
        "That is not a valid key!  Press a valid key.", //8
        "Please enter a value whose occurrancy is a subject of intrigue.  ", //9
        };
        public static string[] roption =
        {
            "Quit                                                ", //0
            "Sort the list                                       ", //1
            "Make a new list of random numbers                   ", //2
            "Remove a number (by value)                          ", //3
            "Add a value to the list                             ", //4
            "Count the number of occurances of a specified number", //5
            "Print the smallest or largest value                 ", //6
            "Print the sum and average of the numbers in the list", //7
            "Determine the most frequently occuring value(s)     ", //8
        };
        public static string[] svalues = { "", "" };
        public static int[] values = { 0, 0 };
        public static int max, min, rmval, adval;
        public static string neither = "[You swiftly return to a dreamless sleep]";
        public static string write, invalid, srmval, sadval;
        public static bool space = true, chosen = false, binvalid = false, quieres = true, input = false, rchosen = false, pain = true, rpain = true, parse;
        public static int rvalue;
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            for (int i = 0; i < 2; i++)
            {
                write = main[i];
                Write();
            }

            while (!chosen)
            {
                Console.ForegroundColor = ConsoleColor.White;
                quieres = true;
                while (quieres)
                {
                    for (int i = 0; i < memory[0].Length; i++)
                    {
                        if (i < memory[0].Length)
                        {
                            if (i == 0)
                                Console.SetCursorPosition(0 + i, Console.CursorTop);
                            else
                                    Console.SetCursorPosition(0 + i, Console.CursorTop - 4);
                            Console.Write(memory[0][i]);
                        }

                        if (i < memory[1].Length)
                        {
                            Console.SetCursorPosition(0 + i, Console.CursorTop + 2);
                            Console.Write(memory[1][i]);
                        }

                        if (i < memory[2].Length)
                        {
                            Console.SetCursorPosition(0 + i, Console.CursorTop + 2);
                            Console.Write(memory[2][i]);
                        }
                        Thread.Sleep(15);
                        if (i == memory[0].Length - 1)
                            quieres = false;
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("");
                space = false;
                write = main[2];
                Write();
                pain = true;
                while (pain)
                {
                    Console.CursorLeft = main[2].Length;
                    space = true;
                    Console.CursorVisible = true;
                    cki = Console.ReadKey();
                    Console.CursorVisible = false;
                    if (binvalid)
                    {
                        Console.SetCursorPosition(0, Console.CursorTop + 1);
                        invalid = main[3];
                        Invalid();
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                    }
                    binvalid = false;
                    if (cki.Key == ConsoleKey.D1)
                    {
                        ShoppingL();
                        pain = false;
                    }
                    else if (cki.Key == ConsoleKey.D2)
                    {
                        RandomL();
                        pain = false;
                    }
                    else if (cki.Key == ConsoleKey.D3)
                    {
                        Neither();
                        pain = false;
                    }
                    else
                    {
                        Console.CursorTop -= 1;
                        write = main[3];
                        Write();
                        invalid = " ";
                        Console.SetCursorPosition(main[2].Length, Console.CursorTop - 3);
                        Invalid();
                        binvalid = true;
                    }
                }
            }
        }

        public static void ShoppingL()
        {

        }

        public static void RandomL()
        {
            Thread.Sleep(200);
            randcolour.Elapsed += new ElapsedEventHandler(Colors);
            randcolour.Interval = 10;
            randcolour.Enabled = true;
            Console.WriteLine("");
            Console.WriteLine("");
            space = false;
            write = srandom[0];
            Write();
            space = true;
            input = false;

            while (!input)
            {
                Console.CursorVisible = true;
                svalues[0] = Console.ReadLine();
                Console.CursorVisible = false;
                parse = int.TryParse(svalues[0], out values[0]);
                if (parse)
                {
                    if (binvalid)
                    {
                        invalid = srandom[1];
                        Invalid();
                    }
                    binvalid = false;
                    Console.SetCursorPosition((srandom[0].Length + svalues[0].Length + 1), Console.CursorTop - 1);
                    Console.CursorVisible = true;
                    svalues[1] = Console.ReadLine();
                    Console.CursorVisible = false;
                    parse = int.TryParse(svalues[1], out values[1]);
                    if (!parse)
                    {
                        write = srandom[1];
                        Write();
                        Console.SetCursorPosition(srandom[0].Length, Console.CursorTop - 3);
                        invalid = svalues[0] + svalues[1] + " ";
                        Invalid();
                        Console.CursorLeft = srandom[0].Length;
                        binvalid = true;
                    }
                    else
                        if (svalues[1] == svalues[0])
                    {
                        write = srandom[1];
                        Write();
                        Console.SetCursorPosition(srandom[0].Length, Console.CursorTop - 3);
                        invalid = svalues[0] + svalues[1] + " ";
                        Invalid();
                        Console.CursorLeft = srandom[0].Length;
                        binvalid = true;
                    }
                        else
                        input = true;
                }
                else
                {
                    write = srandom[1];
                    Write();
                    Console.SetCursorPosition(srandom[0].Length, Console.CursorTop - 3);
                    invalid = svalues[0] + svalues[1] + " ";
                    Invalid();
                    Console.CursorLeft = srandom[0].Length;
                    binvalid = true;
                }
            }
            if (binvalid)
            {
                invalid = srandom[1];
                Invalid();
            }
            binvalid = false;
            Console.WriteLine("");
            if (values[0] > values[1])
            {
                max = values[0];
                min = values[1];
            }
            else if (values[0] < values[1])
            {
                max = values[1];
                min = values[0];
            }

            for (int i = 0; i < 25; i++)
            {
                Lrandom.Add(generator.Next(min, max + 1));
                if (i == 24)
                {
                    space = true;
                    write = Lrandom[i].ToString() + ".";
                }
                else
                {
                    space = false;
                    write = Lrandom[i].ToString() + ", ";
                }
                Write();
                Thread.Sleep(15);
            }
            rchosen = false;
            while (!rchosen)
            {
                space = false;
                quieres = true;
                while (quieres)
                {
                    for (int i = 0; i < roption[0].Length + 3; i++)
                    {
                        //1
                        if (i == 0)
                            Console.SetCursorPosition(0 + i, Console.CursorTop);
                        else
                            Console.SetCursorPosition(0 + i, Console.CursorTop - 8);
                        Console.Write(("0. " + roption[0])[i]);
                        //2
                        Console.SetCursorPosition(0 + i, Console.CursorTop + 1);
                        Console.Write(("1. " + roption[1])[i]);
                        //3
                        Console.SetCursorPosition(0 + i, Console.CursorTop + 1);
                        Console.Write(("2. " + roption[2])[i]);
                        //4
                        Console.SetCursorPosition(0 + i, Console.CursorTop + 1);
                        Console.Write(("3. " + roption[3])[i]);
                        //5
                        Console.SetCursorPosition(0 + i, Console.CursorTop + 1);
                        Console.Write(("4. " + roption[4])[i]);
                        //6
                        Console.SetCursorPosition(0 + i, Console.CursorTop + 1);
                        Console.Write(("5. " + roption[5])[i]);
                        //7
                        Console.SetCursorPosition(0 + i, Console.CursorTop + 1);
                        Console.Write(("6. " + roption[6])[i]);
                        //8
                        Console.SetCursorPosition(0 + i, Console.CursorTop + 1);
                        Console.Write(("7. " + roption[7])[i]);
                        //9
                        Console.SetCursorPosition(0 + i, Console.CursorTop + 1);
                        Console.Write(("8. " + roption[8])[i]);

                        Thread.Sleep(15);
                        if (i == memory[0].Length - 1)
                            quieres = false;
                    }
                }

                Console.WriteLine("");
                Console.WriteLine("");
                write = srandom[2];
                Write();
                rpain = true;
                while (rpain)
                {
                    Console.CursorLeft = srandom[2].Length;
                    space = true;
                    Console.CursorVisible = true;
                    cki = Console.ReadKey();
                    Console.CursorVisible = false;
                    if (binvalid)
                    {
                        Console.SetCursorPosition(0, Console.CursorTop + 1);
                        invalid = srandom[3];
                        Invalid();
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                    }
                    binvalid = false;
                    if (cki.Key == ConsoleKey.D1)
                    {
                        RSort();
                        rpain = false;
                    }
                    else if (cki.Key == ConsoleKey.D2)
                    {
                        RNewList();
                        rpain = false;
                    }
                    else if (cki.Key == ConsoleKey.D3)
                    {
                        RRmvVal();
                        rpain = false;
                    }
                    else if (cki.Key == ConsoleKey.D4)
                    {
                        RAddVal();
                        rpain = false;
                    }
                    else if (cki.Key == ConsoleKey.D5)
                    {
                        RSmlLrg();
                        rpain = false;
                    }
                    else if (cki.Key == ConsoleKey.D6)
                    {
                        RSumAvg();
                        rpain = false;
                    }
                    else if (cki.Key == ConsoleKey.D7)
                    {
                        RFreq();
                        rpain = false;
                    }
                    else if (cki.Key == ConsoleKey.D8)
                    {
                        ROccur();
                        rpain = false;
                    }
                    else
                    {
                        Console.CursorTop -= 1;
                        write = main[3];
                        Write();
                        invalid = " ";
                        Console.SetCursorPosition(main[2].Length, Console.CursorTop - 3);
                        Invalid();
                        binvalid = true;
                    }
                }
            }

        }
        public static void RSort()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Lrandom.Sort();

            for (int i = 0; i < Lrandom.Count; i++)
            {
                if (i == Lrandom.Count - 1)
                {
                    space = true;
                    write = Lrandom[i].ToString() + ".";
                }
                else
                {
                    space = false;
                    write = Lrandom[i].ToString() + ", ";
                }
                Write();
                Thread.Sleep(15);
            }
        }
        public static void RNewList()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            space = false;
            write = srandom[0];
            Write();
            space = true;
            input = false;

            while (!input)
            {
                Console.CursorVisible = true;
                svalues[0] = Console.ReadLine();
                Console.CursorVisible = false;
                parse = int.TryParse(svalues[0], out values[0]);
                if (parse)
                {
                    if (binvalid)
                    {
                        invalid = srandom[1];
                        Invalid();
                    }
                    binvalid = false;
                    Console.SetCursorPosition((srandom[0].Length + svalues[0].Length + 1), Console.CursorTop - 1);
                    Console.CursorVisible = true;
                    svalues[1] = Console.ReadLine();
                    Console.CursorVisible = false;
                    parse = int.TryParse(svalues[1], out values[1]);
                    if (!parse)
                    {
                        write = srandom[1];
                        Write();
                        Console.SetCursorPosition(srandom[0].Length, Console.CursorTop - 3);
                        invalid = svalues[0] + svalues[1] + " ";
                        Invalid();
                        Console.CursorLeft = srandom[0].Length;
                        binvalid = true;
                    }
                    else
                        if (svalues[1] == svalues[0])
                    {
                        write = srandom[1];
                        Write();
                        Console.SetCursorPosition(srandom[0].Length, Console.CursorTop - 3);
                        invalid = svalues[0] + svalues[1] + " ";
                        Invalid();
                        Console.CursorLeft = srandom[0].Length;
                        binvalid = true;
                    }
                    else
                        input = true;
                }
                else
                {
                    write = srandom[1];
                    Write();
                    Console.SetCursorPosition(srandom[0].Length, Console.CursorTop - 3);
                    invalid = svalues[0] + svalues[1] + " ";
                    Invalid();
                    Console.CursorLeft = srandom[0].Length;
                    binvalid = true;
                }
            }
            if (binvalid)
            {
                invalid = srandom[1];
                Invalid();
            }
            binvalid = false;
            Console.WriteLine("");
            if (values[0] > values[1])
            {
                max = values[0];
                min = values[1];
            }
            else if (values[0] < values[1])
            {
                max = values[1];
                min = values[0];
            }

            for (int i = 0; i < 25; i++)
            {
                Lrandom[i] = generator.Next(min, max + 1);
                if (i == 24)
                {
                    space = true;
                    write = Lrandom[i].ToString() + ".";
                }
                else
                {
                    space = false;
                    write = Lrandom[i].ToString() + ", ";
                }
                Write();
                Thread.Sleep(15);
            }
        }
        public static void RRmvVal()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            space = false;
            write = srandom[4];
            Write();
            space = true;
            input = false;


            while (!input)
            {
                Console.CursorVisible = true;
                srmval = Console.ReadLine();
                Console.CursorVisible = false;
                parse = int.TryParse(srmval, out rmval);
                if (binvalid)
                {
                    invalid = srandom[5];
                    Invalid();
                }
                Console.CursorLeft = 0;
                binvalid = false;
                if (parse)
                {
                    input = true;
                    string removed = $"Removed all instances of {rmval}.";
                    string nremoved = $"The value {rmval} was not found.";
                    int verif = Lrandom.Count;
                    for (int i = 0; i < Lrandom.Count; i++)
                    {
                        if (Lrandom[i] == rmval)
                        {
                            Lrandom.RemoveAt(i);
                        }
                    }
                    Debug.WriteLine(verif);
                    Debug.WriteLine(Lrandom.Count);
                    if (verif != Lrandom.Count)
                    {
                        write = removed;
                        Write();
                    }
                    else
                    {
                        write = nremoved;
                        Write();
                    }
                }
                else
                {
                    write = srandom[5];
                    Write();
                    binvalid = true;
                    Console.SetCursorPosition(srandom[4].Length, Console.CursorTop - 3);
                    invalid = srmval;
                    Invalid();
                    Console.CursorLeft = srandom[4].Length;
                }
            }
        }
        public static void RAddVal()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            space = false;
            write = srandom[6];
            Write();
            space = true;
            input = false;


            while (!input)
            {
                Console.CursorVisible = true;
                sadval = Console.ReadLine();
                Console.CursorVisible = false;
                parse = int.TryParse(sadval, out adval);
                if (binvalid)
                {
                    invalid = srandom[5];
                    Invalid();
                }
                Console.CursorLeft = 0;
                binvalid = false;
                if (parse)
                {
                    input = true;
                    string added = $"Added value {adval} to the list.";
                    Lrandom.Add(adval);
                    write = added;
                    Write();
                }
                else
                {
                    write = srandom[5];
                    Write();
                    binvalid = true;
                    Console.SetCursorPosition(srandom[6].Length, Console.CursorTop - 3);
                    invalid = sadval;
                    Invalid();
                    Console.CursorLeft = srandom[6].Length;
                }
            }
        }
        public static void RSmlLrg()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            space = false;
            write = srandom[7];
            Write();
            space = true;

            input = false;
            while (!input)
            {
                Console.CursorLeft = srandom[7].Length;
                Console.CursorVisible = true;
                cki = Console.ReadKey();
                Console.CursorVisible = false;
                if (binvalid)
                {
                    Console.SetCursorPosition(0, Console.CursorTop + 1);
                    invalid = srandom[8];
                    Invalid();
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                }
                binvalid = false;
                if (cki.Key == ConsoleKey.S)
                {
                    input = true;
                    int smlval , newval;
                    Lrandom.Sort();
                    smlval = Math.Abs(Lrandom[0]);
                    for (int i = 1; i < Lrandom.Count; i++)
                    {
                        newval = Math.Abs(Lrandom[i]);
                        if (smlval >= newval)
                            smlval = newval;
                    }

                    string smallest = $"The smallest value in the list is {smlval}.";
                    write = smallest;
                    Write();
                }
                else if (cki.Key == ConsoleKey.L)
                {
                    input = true;
                    int lrgval, newval;
                    Lrandom.Sort();
                    lrgval = Math.Abs(Lrandom[0]);
                    for (int i = 1; i < Lrandom.Count; i++)
                    {
                        newval = Math.Abs(Lrandom[i]);
                        if (lrgval <= newval)
                            lrgval = newval;
                    }

                    string largest = $"The smallest value in the list is {lrgval}.";
                    write = largest;
                    Write();
                }
                else
                {
                    Console.CursorTop -= 1;
                    write = srandom[8];
                    Write();
                    invalid = " ";
                    Console.SetCursorPosition(srandom[7].Length, Console.CursorTop - 3);
                    Invalid();
                    binvalid = true;
                }
            }
        }
        public static void RSumAvg()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            int sum = 0;
            double avg;
            for (int i = 0; i < Lrandom.Count; i++)
            {
                sum = sum + Lrandom[i];
            }
            avg = sum / Lrandom.Count;

            string avgsum = $"The sum of the values in the list is {sum}, and the average of the values in the list is {avg}.";
            write = avgsum;
            Write();
        }
        public static void RFreq()
        {
            
        }
        public static void ROccur()
        {
            Console.WriteLine("");
            Console.WriteLine("");

            write = srandom[9];
            Write();

        }

        public static void Neither()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            write = neither;
            Write();
            Thread.Sleep(3000);
            Environment.Exit(0);
        }

        public static void Write()
        {
            for (int i = 0; i < write.Length; i++)
            {
                Console.Write(write[i]);
                Thread.Sleep(15);
            }
            Thread.Sleep(300);

            if (space)
            {
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }

        public static void Invalid()
        {
            for (int i = 0; i < invalid.Length; i++)
            {
                Console.Write(" ");
            }
        }

        public static void Colors(object source, ElapsedEventArgs e)
        {
            int color;
            Random generator = new Random();
            color = generator.Next(1, 16);
            switch (color)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case 7:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case 8:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case 9:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case 10:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case 11:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 12:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case 13:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 14:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 15:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }
        }

    }

}
