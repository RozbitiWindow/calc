using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.IO;
using CalculatorApp;


class Program
{
    static List<string> historieScore = new List<string>(); // game list
    static List<string> calcScore = new List<string>(); // calc list
    static int savehistory = 1; //ukladat historii
    static int trueOrFlase = 0;
    static int exiting123 = 0;
    static int snakespeed = 200; //snake "Ishow" speed
    static int secretModeUnlocked = 0;
    static int rangeOfLastNumber = 100;
    static int showNumber = 0;
    static int RollTheDice = 0;
    static int firstnumberunlocked = 0;
    static int minigamesunlocked = 0;
    static int confirmExits = 1;


    static void Main()
    {
        OutputWriter outputWriter = new OutputWriter();
        LogoWriter logoWriter = new LogoWriter();
        Calc calc = new Calc();
        InputReader inputReader = new InputReader();
        outputWriter.WriteLine("Starting . . .", ConsoleColor.Green);

        string ver = "1.2.7"; // everything was made by RozbitiOkno 24.11.2025 

        // HEADER
        int repete = 0;
        double percentage = 0;
        while (repete != 10) 
        {
            Console.Clear();
            logoWriter.WriteLogo();
            percentage += 8.5;
            outputWriter.WriteLine("[----- " + percentage + "% -----]", ConsoleColor.Green);
            if (percentage > 50)
            {
                outputWriter.WriteLine("Loading modules . . .", ConsoleColor.Green);
            }
            Thread.Sleep(400);

            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
            {
                break;
            }
            repete++;

        }

        while (true)
        {
            Console.Clear();
            outputWriter.WriteLine("=== " + DateTime.Now + " ===", ConsoleColor.Red);
            outputWriter.WriteLine("RozitiOkno operators v." + ver, ConsoleColor.Red);
            outputWriter.WriteLine("=============================", ConsoleColor.Red);

            // MAIN MENU

            outputWriter.WriteLine("1  →  Calculations", ConsoleColor.Green);
            outputWriter.WriteLine("2  →  Random numbers", ConsoleColor.Green);
            outputWriter.WriteLine("3  →  Unit converter", ConsoleColor.Green);
            outputWriter.WriteLine("4  →  Play minigames", ConsoleColor.Green);
            outputWriter.WriteLine("5  →  See history", ConsoleColor.Green);
            outputWriter.WriteLine("6  →  Timer", ConsoleColor.Green);
            outputWriter.WriteLine("7  →  StopWatch", ConsoleColor.Green);
            outputWriter.WriteLine("8  →  ^,√ ", ConsoleColor.Green);
            outputWriter.WriteLine("9  →  Roll the dice", ConsoleColor.Green);
            outputWriter.WriteLine("10 →  achivments", ConsoleColor.Green);
            outputWriter.WriteLine("11 →  Settings", ConsoleColor.Green);
            outputWriter.WriteLine("0  →  exit", ConsoleColor.Green);
            string whattodoLine;
            outputWriter.Write("Your choice: ", ConsoleColor.DarkRed);
            whattodoLine = Console.ReadLine() ?? string.Empty;
            double whattodo = double.TryParse(whattodoLine, out var wt) ? wt : double.NaN;

            if (whattodo != 0 && whattodo != 1 && whattodo != 2 && whattodo != 3 && whattodo != 4 && whattodo != 5 && whattodo != 111 && whattodo != 67 && whattodo != 420 && whattodo != 1337 && whattodo != 6 && whattodo != 7 && whattodo != 8 && whattodo != 9 && whattodo != 10 && whattodo != 11)
            {
                outputWriter.WriteError("ERROR: Not a number or invalid number!");
            }

            if (whattodo == 0) //----------EXIT-------------//
            {
                outputWriter.WriteLine("Exiting contains removing all your stuff like history, settings and else do you want to continue? (y/n)", ConsoleColor.Red);
                outputWriter.Write("Continue? (y/n) ", ConsoleColor.DarkRed);
                string doyouwanttocontinue = inputReader.ReadString() ?? string.Empty;
                if (doyouwanttocontinue == "y" || doyouwanttocontinue == "Y")
                {
                    outputWriter.WriteLine("Exiting . . .", ConsoleColor.Red);
                    Console.Clear();
                    logoWriter.WriteLogo();
                    return;
                }
                if (doyouwanttocontinue == "n" || doyouwanttocontinue == "N")
                {
                    continue;
                }
                if (doyouwanttocontinue != "n" || doyouwanttocontinue != "N" || doyouwanttocontinue != "Y" || doyouwanttocontinue != "y")
                {
                    outputWriter.WriteError("Invalid option! (relocating in 3 sec.)");
                    Thread.Sleep(3000);
                    continue;
                }
            }
            //okamzity exit 
            else if (whattodo == 111) //mozna upravit na lepší číslo idk
            {
                outputWriter.WriteLine("Immediate termination and non-saving of things . . .", ConsoleColor.Red);
                Thread.Sleep(1000);
                outputWriter.WriteLine("Exiting . . .", ConsoleColor.Red);
                return;

            }


            // ------------------------- CALCULATOR ------------------------- //
            if (whattodo == 1)
            {
                Console.Clear();
                firstnumberunlocked = 1;
                outputWriter.WriteLine("=== Calculator v." + ver + " ===", ConsoleColor.Red);

                outputWriter.WriteLine("Enter first number, second number, operation (+,-,*,/)", ConsoleColor.Green);
                outputWriter.Write("First number: ");
                double a = inputReader.ReadDouble();
                outputWriter.Write("Second number: ");
                double b = inputReader.ReadDouble();
                outputWriter.Write("Operation (+,-,*,/): ");
                string oper = inputReader.ReadString();
                double result = 0;
                switch (oper)
                {
                    case "+":
                        {
                            result = calc.Calc_Secti(a, b);
                            break;
                        }
                    case "-":
                        {
                            result = calc.Calc_Odecti(a, b);
                            break;
                        }
                    case "*":
                        {
                            result = calc.Calc_Vynasob(a, b);
                            break;
                        }
                    case "/":
                        {
                            result = calc.Calc_Vydel(a, b);
                            break;
                        }
                }
                outputWriter.WriteSuccess("Your result is: " + result);
                outputWriter.WriteLine("Thanks for using RozbitiOkno calculator " + ver);
                if (savehistory == 1)
                {
                    string calczaznam = $"Calculator (simple): {a} {oper} {b} = {result} - Date: {DateTime.Now}";
                    calcScore.Add(calczaznam);
                }
            }

            // ------------------------- RANDOM NUMBERS ------------------------- //
            else if (whattodo == 2)
            {
                Console.Clear();

                Console.Clear();
                Random rng = new Random();
                outputWriter.WriteLine("=== Random Number Generator ===", ConsoleColor.Red);
                outputWriter.WriteLine("Enter FROM number and TO number", ConsoleColor.Green);
                outputWriter.Write("Your choice (FROM number): ", ConsoleColor.DarkRed);
                int from = inputReader.ReadInt();
                outputWriter.Write("Your choice (TO number): ", ConsoleColor.DarkRed);
                int to = inputReader.ReadInt();
                int rndNum = rng.Next(from, to + 1);
                outputWriter.WriteSuccess("Your number is " + rndNum);

                if (savehistory == 1)
                {
                    string calczaznam = $"RNG (numbers): from: {from} to: {to} genereted: {rndNum}   - Date: {DateTime.Now}"; //add do history numbers
                    calcScore.Add(calczaznam);
                }


                outputWriter.WriteLine("Thanks for using RNG " + ver);

            }

            // ------------------------- UNIT CONVERTER ------------------------- //
            else if (whattodo == 3)
            {
                Console.Clear();
                outputWriter.WriteLine("=== Unit Converter v." + ver + " ===", ConsoleColor.Red);

                outputWriter.WriteLine("1 → KM to M  | 2 → M to CM  | 3 → CM to MM", ConsoleColor.Green);
                outputWriter.WriteLine("4 → M to KM  | 5 → CM to M  | 6 → MM to CM", ConsoleColor.Green);
                outputWriter.WriteLine("7 → T to KG  | 8 → KG to G  | 9 → G to mG", ConsoleColor.Green);
                outputWriter.WriteLine("10 → KG to T | 11 → G to KG | 12 → mG to G", ConsoleColor.Green);
                outputWriter.Write("Your choice: ", ConsoleColor.DarkRed);
                int unitChoice = int.Parse(Console.ReadLine() ?? "0");

                outputWriter.WriteLine("How much units do you want to convert?", ConsoleColor.Green);
                outputWriter.Write("Your choice: ", ConsoleColor.DarkRed);
                double HOWMUCH = double.Parse(Console.ReadLine() ?? "0");

                double RESULT = unitChoice switch
                {
                    1 => HOWMUCH * 1000,
                    2 => HOWMUCH * 100,
                    3 => HOWMUCH * 10,
                    4 => HOWMUCH / 1000,
                    5 => HOWMUCH / 100,
                    6 => HOWMUCH / 10,
                    7 => HOWMUCH * 1000,
                    8 => HOWMUCH * 1000,
                    9 => HOWMUCH * 1000,
                    10 => HOWMUCH / 1000,
                    11 => HOWMUCH / 1000,
                    12 => HOWMUCH / 1000,
                    _ => double.NaN
                };


                outputWriter.WriteLine("Result: " + RESULT);
            }

            // ------------------------- MINIGAMES ------------------------- //
            else if (whattodo == 4)
            {
                Console.Clear();
                minigamesunlocked = 1;
                outputWriter.WriteLine("==== Minigames v." + ver + " ====", ConsoleColor.Red);
                outputWriter.WriteLine("1 → Guess the number", ConsoleColor.Green);
                outputWriter.WriteLine("2 → Snake the game", ConsoleColor.Green);
                outputWriter.Write("Your choice: ", ConsoleColor.DarkRed);
                int whatminigame = int.Parse(Console.ReadLine() ?? "0");

                // ---------- GUESS THE NUMBER ---------- //
                int attemps = 0;
                if (whatminigame == 1)
                {
                    Console.Clear();
                    outputWriter.WriteLine("Guess the number between 1-" + rangeOfLastNumber + "!", ConsoleColor.Green);
                    Random random = new Random();
                    int number = random.Next(1, rangeOfLastNumber + 1);

                    while (true)
                    {
                        if (showNumber == 1)
                        {
                            outputWriter.WriteLine("Generated number: " + number, ConsoleColor.DarkRed);
                            outputWriter.Write("Your choice: ", ConsoleColor.DarkRed);
                        }
                        else
                        {
                            outputWriter.Write("Your choice: ", ConsoleColor.DarkRed);
                        }

                        if (!int.TryParse(Console.ReadLine(), out int guess))
                        {
                            outputWriter.WriteError("Not a number!");
                            continue;
                        }

                        if (guess == number)
                        {
                            outputWriter.WriteLine("Correct!", ConsoleColor.Green);
                            outputWriter.WriteLine("You have " + attemps + " attemps!", ConsoleColor.Green);

                            if (attemps < 1 || attemps == 1)
                            {
                                outputWriter.WriteLine("EXTREM SCORE!", ConsoleColor.DarkRed);
                            }
                            else if (attemps < 5)
                            {
                                outputWriter.WriteLine("Good score!", ConsoleColor.DarkRed);
                            }
                            else if (attemps < 7)
                            {
                                outputWriter.WriteLine("Normal score", ConsoleColor.DarkRed);
                            }
                            else if (attemps < 12)
                            {
                                outputWriter.WriteLine("Its good but not good !?", ConsoleColor.DarkRed);
                            }
                            else if (attemps > 12)
                            {
                                outputWriter.WriteLine("Very bad !", ConsoleColor.DarkRed);
                            }

                            break;
                        }

                        else if (guess > number)
                        {
                            outputWriter.WriteLine("Lower!", ConsoleColor.Yellow);
                            attemps++;
                        }
                        else
                        {
                            outputWriter.WriteLine("Higher!", ConsoleColor.Yellow);
                            attemps++;
                        }

                    }

                    if (savehistory == 1)
                    {
                        string zaznam = $"Guess the number: Attemps: {attemps} - Date: {DateTime.Now}";
                        historieScore.Add(zaznam);
                    }
                    outputWriter.WriteLine("Thanks for playing!", ConsoleColor.Green);

                }

                // ---------- SNAKE ---------- //
                else if (whatminigame == 2)
                {
                    int width = 30;
                    int height = 15;
                    int score = 0;
                    Console.CursorVisible = false;

                    List<(int x, int y)> snake = new List<(int x, int y)> { (width / 2, height / 2) };
                    Random rng = new Random();
                    (int x, int y) food = (rng.Next(width), rng.Next(height));
                    ConsoleKey direction = ConsoleKey.RightArrow;

                    while (true)
                    {
                        if (Console.KeyAvailable)
                        {
                            var key = Console.ReadKey(true).Key;
                            switch (key)
                            {
                                case ConsoleKey.UpArrow:
                                    if (direction != ConsoleKey.DownArrow) direction = ConsoleKey.UpArrow; break;
                                case ConsoleKey.DownArrow:
                                    if (direction != ConsoleKey.UpArrow) direction = ConsoleKey.DownArrow; break;
                                case ConsoleKey.LeftArrow:
                                    if (direction != ConsoleKey.RightArrow) direction = ConsoleKey.LeftArrow; break;
                                case ConsoleKey.RightArrow:
                                    if (direction != ConsoleKey.LeftArrow) direction = ConsoleKey.RightArrow; break;
                            }
                        }

                        var head = snake[0];
                        (int x, int y) newHead = head;
                        switch (direction)
                        {
                            case ConsoleKey.UpArrow: newHead.y--; break;
                            case ConsoleKey.DownArrow: newHead.y++; break;
                            case ConsoleKey.LeftArrow: newHead.x--; break;
                            case ConsoleKey.RightArrow: newHead.x++; break;
                        }

                        if (newHead.x < 0 || newHead.x >= width || newHead.y < 0 || newHead.y >= height || snake.Contains(newHead))
                        {
                            Console.Clear();

                            outputWriter.WriteLine("GAME OVER!", ConsoleColor.Red);
                            outputWriter.WriteLine("Score: " + score);

                            if (savehistory == 1)
                            {
                                string zaznam = $"Snake the game: score: {score} - Date: {DateTime.Now}";
                                historieScore.Add(zaznam);
                            }


                            break;
                        }

                        snake.Insert(0, newHead);

                        if (newHead == food)
                        {
                            score++;
                            do { food = (rng.Next(width), rng.Next(height)); }
                            while (snake.Contains(food));
                        }
                        else snake.RemoveAt(snake.Count - 1);

                        Console.SetCursorPosition(0, 0);
                        for (int y = 0; y < height; y++)
                        {
                            for (int x = 0; x < width; x++)
                            {
                                if (snake.Contains((x, y))) { outputWriter.Write("O", ConsoleColor.Green); }
                                else if (food == (x, y)) { outputWriter.Write("X", ConsoleColor.Red); }
                                else outputWriter.Write(" ");
                            }
                            outputWriter.WriteLine("");
                        }
                        outputWriter.WriteLine("Score: " + score, ConsoleColor.Yellow);
                        Thread.Sleep(snakespeed); //rychlost snake
                    }
                    outputWriter.WriteLine("Press ENTER to exit Snake...", ConsoleColor.Green);
                    Console.ReadLine();
                }
            }
            //----------------------historie-------------------------//
            if (whattodo == 5)
            {
                Console.Clear();
                outputWriter.WriteLine("1 → Gaming history", ConsoleColor.Green);
                outputWriter.WriteLine("2 → Calc history", ConsoleColor.Green);
                outputWriter.Write("Your choice: ", ConsoleColor.DarkRed);
                double historyofnig = double.Parse(Console.ReadLine() ?? "0");

                if (historyofnig == 1) //gaming history
                {
                    Console.Clear();
                    outputWriter.WriteLine("=== Gaming history ===", ConsoleColor.Red);
                    outputWriter.WriteLine("");

                    if (historieScore.Count == 0)
                    {
                        outputWriter.WriteLine("Nothing there . . .", ConsoleColor.Yellow);
                    }
                    foreach (string zaznam in historieScore)
                    {
                        outputWriter.WriteLine(zaznam);
                        outputWriter.WriteLine("");
                    }
                }

                if (historyofnig == 2) //calc history
                {
                    Console.Clear();
                    outputWriter.WriteLine("=== Calculations history ===", ConsoleColor.Red);
                    outputWriter.WriteLine("");
                    if (calcScore.Count == 0)
                    {
                        outputWriter.WriteLine("Nothing there . . .", ConsoleColor.Yellow);
                    }
                    foreach (string calczaznam in calcScore)
                    {
                        outputWriter.WriteLine(calczaznam);
                        outputWriter.WriteLine("");
                    }
                }

                if (historyofnig != 1 && historyofnig != 2) //invalid options
                {
                    outputWriter.WriteError("Invalid option! - " + historyofnig + " - try something else!");
                }

            }
            //----------------------SECREETS-------------------------//
            if (whattodo == 1337)
            {
                outputWriter.WriteLine("What a hacker here!", ConsoleColor.Red);
            }
            if (whattodo == 420)
            {
                outputWriter.WriteLine("By BrokenWindowGameDev", ConsoleColor.Red);
            }
            if (whattodo == 67)
            {
                outputWriter.WriteLine("NOT FUNNY, too late!", ConsoleColor.Red);
            }

            //----------------------TIMER a STOPWATCH-----------------//
            if (whattodo == 6)
            {

                outputWriter.WriteLine("=== Timer ===");

                outputWriter.WriteLine("How many seconds (s)");

                outputWriter.Write("Your choice: ");
                int seconds = int.Parse(Console.ReadLine());


                for (int i = seconds; i > 0; i--)
                {
                    outputWriter.WriteLine($"Remaning: {i} s");
                    Thread.Sleep(1000);
                    Console.Clear();
                }

                outputWriter.WriteLine("Time's up!");

            }

            if (whattodo == 7) //stopwatch
            {
                Console.Clear();

                outputWriter.WriteLine("=== stopwatch ===");

                outputWriter.WriteLine("Press enter whenever do you want to start stopwatch");
                Console.ReadLine();
                Stopwatch stopky1 = new Stopwatch();
                stopky1.Start();
                while (true)
                {

                    Console.Clear();


                    outputWriter.WriteLine("Press Enter to stop stopwatch");
                    outputWriter.WriteLine(stopky1.Elapsed.ToString(@"hh\:mm\:ss\.fff"));


                    if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                        break;

                    Thread.Sleep(100);
                }

                stopky1.Stop();
                outputWriter.WriteLine("");

                outputWriter.WriteLine("Final time: " + stopky1.Elapsed);
                outputWriter.WriteLine("");


            }

            //----------------odmocnina a mocnina -----------------------//
            if (whattodo == 8)
            {
                Console.Clear();

                outputWriter.WriteLine("=== ^ and √ ===");

                outputWriter.WriteLine("1 → ^");
                outputWriter.WriteLine("2 → √");
                outputWriter.WriteLine("What do you want to use ");

                outputWriter.Write("Your choice (1/2): ");

                int operationOrNot = int.Parse(Console.ReadLine());

                //if (operationOrNot != 1 || operationOrNot != 2)
                //{
                //    outputWriter.WriteLine("NOT VALID NUMBER!");
                //}
                double NumberToBeFirst = 0;
                double NumberToBeSecond = 0;
                double vysledek = 0;


                if (operationOrNot == 1)
                {

                    outputWriter.WriteLine("Enter your first number to ^");

                    outputWriter.Write("Your choice (1,2,3): ", ConsoleColor.DarkRed);
                    NumberToBeFirst = double.Parse(Console.ReadLine() ?? "0");

                    outputWriter.WriteLine("Enter your second number");

                    outputWriter.Write("Your choice (1,2,3): ");
                    NumberToBeSecond = double.Parse(Console.ReadLine());
                    vysledek = Math.Pow(NumberToBeFirst, NumberToBeSecond);


                    outputWriter.WriteLine($"{NumberToBeFirst} ^ {NumberToBeSecond} = {vysledek}"); //vysledek mocniny



                }

                string calczaznam = $"^: from: {NumberToBeFirst} by: {NumberToBeSecond} is: {vysledek} - Date: {DateTime.Now}"; //add do history 
                calcScore.Add(calczaznam);

                double NotANumber = 0;
                double odemocnina = 0;

                if (operationOrNot == 2)
                {

                    outputWriter.WriteLine("Enter your number to √");
                    outputWriter.Write("Your choice (1,2,3): ");
                    NotANumber = double.Parse(Console.ReadLine());
                    odemocnina = Math.Sqrt(NotANumber);
                    outputWriter.WriteLine("Squr of " + NotANumber + " is " + odemocnina);

                }

                calczaznam = $"√: from: {NotANumber} is: {odemocnina} - Date: {DateTime.Now}"; //add do history 
                calcScore.Add(calczaznam);

            }

            //--------------SETTINGS-------------------//        

            if (whattodo == 11) //FIXed
            {
                exiting123 = 0;

                while (exiting123 == 0)
                {
                    Console.Clear();
                    outputWriter.WriteLine("=== Settings ===");


                    if (savehistory == 1) //ukladat historifing
                    {

                        outputWriter.Write("\n1 → save history -");

                        outputWriter.WriteLine(" TRUE");

                    }
                    else
                    {

                        outputWriter.Write("\n1 → save history -");

                        outputWriter.WriteLine(" FALSE");

                    }


                    outputWriter.WriteLine("2 → Clear history");
                    outputWriter.WriteLine("3 → Change snake speed");
                    outputWriter.WriteLine("4 → Guess the number - range");
                    outputWriter.WriteLine("5 → Export history to .txt file");
                    outputWriter.WriteLine("6 → Upload history from .txt file");
                    if (confirmExits == 1)
                    {

                        outputWriter.Write("7 → Confirm exits -");

                        outputWriter.Write(" TRUE ");

                        outputWriter.WriteLine("- (program exit not improved!)");
                    }
                    else
                    {

                        outputWriter.Write("7 → Confirm exits -");

                        outputWriter.Write(" FALSE ");

                        outputWriter.WriteLine("- (program exit not improved!)");
                    }
                    outputWriter.WriteLine("0 → Exit"); //exit sem snad slepej nebo CO ???

                    if (secretModeUnlocked == 1)
                    {
                        outputWriter.WriteLine("999 → Reset all / debug mode");
                        outputWriter.WriteLine("998 → Show right number in Guess the number");
                    }


                    outputWriter.Write("Your choice: ");


                    trueOrFlase = int.Parse(Console.ReadLine()); //urcovaní zmeny

                    if (trueOrFlase == 0) //exit
                    {
                        if (confirmExits == 1)
                        {

                            outputWriter.WriteLine("Are you sure, you want exit settings? (y/n)");

                            outputWriter.Write("Your choice: ");

                            string AreYouSure = Console.ReadLine();



                            if (AreYouSure == "y")
                            {
                                outputWriter.WriteLine("Saving changes and exiting . . .");
                                exiting123 = 1;
                                Thread.Sleep(1000);
                            }

                            else if (AreYouSure == "n")
                            {
                                Console.Clear();
                                outputWriter.WriteLine("OK, cancled!");
                            }

                            else
                            {
                                Console.Clear();

                                outputWriter.WriteLine("Invalid operation, cancled!");
                                Thread.Sleep(1000);

                            }
                        }
                        else
                        {
                            outputWriter.WriteLine("Saving changes and exiting . . .");
                            exiting123 = 1;
                            Thread.Sleep(1000);
                        }


                    }

                    if (trueOrFlase == 1) //zmena ukládání historie
                    {
                        if (savehistory == 1)
                        {
                            savehistory = 0;
                        }
                        else
                        {
                            savehistory = 1;
                        }
                    }

                    if (trueOrFlase == 2)
                    {
                        historieScore.Clear();
                        calcScore.Clear();
                        Console.Clear();
                        outputWriter.WriteLine("History cleared");
                        Thread.Sleep(1000);
                    }

                    if (trueOrFlase == 3)
                    {

                        outputWriter.WriteLine("What speed do the Snake the game need? (only full numbers!)");
                        outputWriter.WriteLine("Original speed is 200ms");

                        outputWriter.WriteLine("fast ← 200 → slow");

                        outputWriter.Write("Your choice: ");

                        snakespeed = int.Parse(Console.ReadLine());

                        outputWriter.WriteLine("\nSnake speed is now " + snakespeed);

                        Thread.Sleep(1000);
                    }

                    if (trueOrFlase == 555) //secret mode
                    {
                        secretModeUnlocked = 1;
                        Console.Clear();
                        outputWriter.WriteLine("Secret mode unlocked!");
                        Thread.Sleep(1000);
                    }

                    if (trueOrFlase == 999 && secretModeUnlocked == 1)
                    {
                        Console.Clear();

                        outputWriter.WriteLine("Your all stuff like history and settings will be removed! (y/n)");

                        string nevim = Console.ReadLine();
                        if (nevim == "y")
                        {
                            outputWriter.WriteLine("Reseting all saved things . . ."); //reset vecí
                            historieScore.Clear();
                            calcScore.Clear();
                            snakespeed = 200;
                            rangeOfLastNumber = 100;
                            showNumber = 0;

                            outputWriter.WriteLine("Everything was reseted");
                            Thread.Sleep(1000);
                        }

                        else if (nevim == "n")
                        {
                            outputWriter.WriteLine("OK, cancled!");
                            Thread.Sleep(1000);
                        }

                        else
                        {

                            outputWriter.WriteLine("Invalid operation! - " + nevim);

                        }

                    }

                    if (trueOrFlase == 4)
                    {
                        Console.Clear();

                        outputWriter.WriteLine("What range is good for you?");

                        outputWriter.WriteLine("1 → 1-100 - easy");
                        outputWriter.WriteLine("2 → 1-500 - harder");
                        outputWriter.WriteLine("3 → 1-1000 - hard");
                        outputWriter.WriteLine("4 → 1-10000 - extrem");

                        outputWriter.Write("Your choice: ");

                        string rangethenumber = Console.ReadLine();

                        switch (rangethenumber)
                        {
                            case "1":
                                {
                                    rangeOfLastNumber = 100;
                                    break;
                                }
                            case "2":
                                {
                                    rangeOfLastNumber = 500;
                                    break;
                                }
                            case "3":
                                {
                                    rangeOfLastNumber = 1000;
                                    break;
                                }
                            case "4":
                                {
                                    rangeOfLastNumber = 10000;
                                    break;
                                }

                        }
                        outputWriter.WriteLine("Range is now to " + rangeOfLastNumber);
                        Thread.Sleep(1000);
                    }

                    if (trueOrFlase == 998 && secretModeUnlocked == 1)
                    {
                        showNumber = 1;
                        Console.Clear();
                        outputWriter.WriteLine("Number will be shown");
                        Thread.Sleep(1000);
                    }

                    if (trueOrFlase == 5)
                    {
                        Console.Clear();

                        outputWriter.WriteLine("=== Export history ===");
                        outputWriter.WriteLine("");

                        outputWriter.WriteLine("What name should be named your .txt history? (leave blanc for standard name)");

                        outputWriter.Write("Your choice: ");

                        string NameForHistory = Console.ReadLine();
                        if (NameForHistory == "")
                        {
                            NameForHistory = "History_from_R.O._app";
                        }

                        string fileName = NameForHistory + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".txt";

                        using (StreamWriter writer = new StreamWriter(fileName))
                        {
                            writer.WriteLine("=== GAMING HISTORY ===");
                            writer.WriteLine("");

                            if (historieScore.Count == 0)
                            {
                                writer.WriteLine("No gaming history.");
                            }

                            else
                            {
                                foreach (string zaznam in historieScore)
                                    writer.WriteLine(zaznam);
                            }

                            writer.WriteLine("");
                            writer.WriteLine("=== CALC HISTORY ===");
                            writer.WriteLine("");

                            if (calcScore.Count == 0)
                                writer.WriteLine("No calc history.");
                            else
                                foreach (string calczaznam in calcScore)
                                    writer.WriteLine(calczaznam);
                        }





                        outputWriter.WriteLine("History exported!");
                        outputWriter.WriteLine("File name: " + fileName);
                        outputWriter.WriteLine("Exported to same folder as this app (~/home/~/calc/" + fileName + "/)");
                        outputWriter.WriteLine("Gaming records: " + historieScore.Count);
                        outputWriter.WriteLine("Calc records: " + calcScore.Count);

                        outputWriter.WriteLine("Press enter to continue . . .");
                        Console.ReadLine();


                    }

                    if (trueOrFlase == 6)
                    {
                        Console.Clear();
                        outputWriter.WriteLine("Comming soon!");
                        Thread.Sleep(1000);
                    }

                    if (trueOrFlase == 7)
                    {
                        Console.Clear();

                        outputWriter.WriteLine("Are you sure, you want to turn off exit confirmation? (y/n)");

                        outputWriter.Write("Your option: ");
                        string areyourealysure = Console.ReadLine();
                        if (areyourealysure == "y")
                        {

                            outputWriter.WriteLine("Are you realy sure? (y/n)");

                            outputWriter.Write("Your option: ");
                            string areyourealysureFUCK = Console.ReadLine();
                            if (areyourealysureFUCK == "y")
                            {
                                confirmExits = 0;

                                outputWriter.WriteLine("Allright you got it ");
                                Thread.Sleep(1500);
                            }
                            if (areyourealysureFUCK == "n")
                            {
                                confirmExits = 1;

                                outputWriter.WriteLine("Now you will need to confirm exit everywhere!");
                                Thread.Sleep(1500);
                            }
                            else
                            {
                                outputWriter.WriteLine("Invalid option!");
                                outputWriter.WriteLine("Leaving last option");
                            }
                        }
                        if (areyourealysure == "n")
                        {
                            outputWriter.WriteLine("I though so . . .");
                            confirmExits = 1;

                            outputWriter.WriteLine("Now you will need to confirm exit everywhere!");
                            Thread.Sleep(1500);
                        }
                        else
                        {
                            outputWriter.WriteLine("Invalid option!");
                        }

                    }

                }







            }

            if (whattodo == 9)
            {
                Console.Clear();

                outputWriter.WriteLine("=== Roll the dice ===");

                outputWriter.WriteLine("\nSelect what number range will you use? (1-6)");


                outputWriter.WriteLine("1 → 1-2");
                outputWriter.WriteLine("2 → 1-3");
                outputWriter.WriteLine("3 → 1-4");
                outputWriter.WriteLine("4 → 1-5");
                outputWriter.WriteLine("5 → 1-6");

                outputWriter.Write("Your choice: ");


                int choice = int.Parse(Console.ReadLine());

                Random rnd = new Random();
                int result = 0;

                switch (choice)
                {
                    case 1:
                        result = rnd.Next(1, 3); // 1–2
                        break;
                    case 2:
                        result = rnd.Next(1, 4); // 1–3
                        break;
                    case 3:
                        result = rnd.Next(1, 5); // 1–4
                        break;
                    case 4:
                        result = rnd.Next(1, 6); // 1–5
                        break;
                    case 5:
                        result = rnd.Next(1, 7); // 1–6
                        break;
                    default:
                        outputWriter.WriteLine("Invalid choice");
                        return;
                }

                outputWriter.WriteLine($"You rolled: {result}");
            }


            //---------------achivments------------------//
            if (whattodo == 10)
            {
                Console.Clear();

                outputWriter.WriteLine("=== Adchivments ===");


                if (firstnumberunlocked == 1)
                {
                    outputWriter.WriteLine("\nFirst number - UNLOCKED");

                    outputWriter.WriteLine("Calculate first number using calculator!");
                }
                else
                {
                    outputWriter.WriteLine("\nFirst number - not found :-(");

                    outputWriter.WriteLine("Calculate first number using calculator!");
                }
                outputWriter.WriteLine("\n");

                if (minigamesunlocked == 1)
                {

                    outputWriter.WriteLine("Play time! - UNLOCKED");

                    outputWriter.WriteLine("\nPlay minigame for first time");
                }
                else
                {

                    outputWriter.WriteLine("Play time! - not found :-(");

                    outputWriter.WriteLine("Play minigame for first time");
                }
                outputWriter.WriteLine("\n");




                outputWriter.WriteLine("--------------------------------------------");
            }


            outputWriter.WriteLine("See more on https://github.com/RozbitiWindow");

            outputWriter.Write("Press ENTER to exit...");
            Console.ReadLine();

            outputWriter.WriteLine("Thanks for using RozbitiOkno operators!");

            continue;
        }

    }

}


