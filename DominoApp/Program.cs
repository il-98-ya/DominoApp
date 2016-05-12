using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoApp
{
    class Program
    {
        static public List<String> Dominos = new List<string>();
        static public List<String> DominoPlayer1 = new List<string>();
        static public List<String> DominoPlayer2 = new List<string>();
        static Random random = new Random();


        static void Main(string[] args)
        {
            StartGame();
        }
        static void StartGame()
        {
            Console.WriteLine("Добро пожаловать в Domino v1.0");
            Console.WriteLine("Напишите 'Start' чтобы начать или 'Exit' чтобы выйти!");

            string CurrentCommand = null;
            while (CurrentCommand != "Start" || CurrentCommand != "Exit")
            {
                CurrentCommand = Console.ReadLine();
                if (CurrentCommand == "Start")
                {
                    Console.WriteLine("Приятной игры!");
                    Razdat();
                    break;
                }
                if (CurrentCommand == "Exit")
                {
                    Console.WriteLine("До свидания");
                    Console.ReadKey();
                    break;
                }
                if (CurrentCommand == "Help")
                {
                    Console.WriteLine("Напишите 'Start' чтобы начать или 'Exit' чтобы выйти!");
                }
                if (CurrentCommand != "Help")
                {
                    Console.WriteLine("Неопознанная команда, попробуйте еще раз или напишите 'Help' для помощи!");
                }
            }
        }
        static void Razdat()
        {
            Dominos.Add("0x0");
            Dominos.Add("0x1");
            Dominos.Add("0x2");
            Dominos.Add("0x3");
            Dominos.Add("0x4");
            Dominos.Add("0x5");
            Dominos.Add("0x6");
            Dominos.Add("1x1");
            Dominos.Add("1x2");
            Dominos.Add("1x3");
            Dominos.Add("1x4");
            Dominos.Add("1x5");
            Dominos.Add("1x6");
            Dominos.Add("2x2");
            Dominos.Add("2x3");
            Dominos.Add("2x4");
            Dominos.Add("2x5");
            Dominos.Add("2x6");
            Dominos.Add("3x3");
            Dominos.Add("3x4");
            Dominos.Add("3x5");
            Dominos.Add("3x6");
            Dominos.Add("4x4");
            Dominos.Add("4x5");
            Dominos.Add("4x6");
            Dominos.Add("5x5");
            Dominos.Add("5x6");
            Dominos.Add("6x6");
            int MaxIndex=27;
            for(int i=0; i<7;i++)
            {
                int index = random.Next(0, MaxIndex);
                DominoPlayer1.Add(Dominos[index]);
                Dominos.RemoveAt(index);
                MaxIndex--;
            }
            for (int i = 0; i < 7; i++)
            {
                int index = random.Next(0, MaxIndex);
                DominoPlayer2.Add(Dominos[index]);
                Dominos.RemoveAt(index);
                MaxIndex--;
            }
            WhoFirst();
        }
        static int MaxParaFirstPlayer;
        static int MaxParaSecondPlayer;
        static int Max1=0;
        static int Max2 = 0;
        static void WhoFirst()
        {
            foreach (string s in DominoPlayer1)
            {
                if(int.Parse(s[0].ToString())==int.Parse(s[2].ToString()))
                {
                    MaxParaFirstPlayer = int.Parse(s[0].ToString());
                    if(MaxParaFirstPlayer>Max1)
                    {
                        Max1 = MaxParaFirstPlayer;
                    }
                }
            }
            foreach (string s in DominoPlayer2)
            {
                if (int.Parse(s[0].ToString()) == int.Parse(s[2].ToString()))
                {
                    MaxParaSecondPlayer = int.Parse(s[0].ToString());
                    if (MaxParaSecondPlayer > Max2)
                    {
                        Max2 = MaxParaSecondPlayer;
                    }
                }
            }
            if(Max1>Max2)
            {
                Console.WriteLine("Ходит 1 игрок и его пара "+Max1+"x"+Max1);
                Player1();
                return;
            }
            else
            {
                Console.WriteLine("Ходит 2 игрок и его пара " + Max2 + "x" + Max2);
                Player2();
                return;
            }
        }
        static bool IsFirstStep=true;

        static void Player2()
        {
            string CurrentCommand = null;
            Console.WriteLine("Ходит игрок 2");
            while (true)
            {
                if (IsFirstStep)
                {
                    Console.WriteLine("Это первый ход, вы можете ходить как хотите! Для справки напишите 'Help' или 'Dominoes' чтобы увидеть свои кости");
                    Console.WriteLine("Напишите номер кости, которую хотите выложить:");
                    CurrentCommand = Console.ReadLine();
                    if (CurrentCommand == "Help")
                    {
                        Console.WriteLine("Введите кость которую хотите выложить, например '0x0', английской раскладкой");

                    }
                    if (CurrentCommand == "Dominoes")
                    {
                        Console.WriteLine("Ваши кости");
                        foreach (string s in DominoPlayer2)
                        {
                            Console.WriteLine(s);
                        }
                        Player2();
                        return;
                    }
                    if (DominoPlayer1.Contains(CurrentCommand))
                    {
                        Table = CurrentCommand.Split('x');
                        IsFirstStep = false;
                        DominoPlayer1.Remove(CurrentCommand);
                        Player1();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Такой кости у вас нет, напишите 'Dominoes' чтобы увидеть список всех своих костей или 'Add' чтобы взять кость с базара");
                        Player2();
                        return;
                    }
                    Player1();
                }
                else
                {
                    if(DominoPlayer2.Count<=0)
                    {
                        Win("Игрок 2 победил!");
                        return; 
                    }
                    Console.WriteLine("Напишите номер кости, которую хотите выложить:");
                    CurrentCommand = Console.ReadLine();

                    if (CurrentCommand == "Add")
                    {
                        if (Dominos.Count > 0)
                        {
                            int i = random.Next(0, Dominos.Count);
                            DominoPlayer2.Add(Dominos[i]);
                            Console.WriteLine("Кость " + Dominos[i] + " Добавлена");
                            Dominos.RemoveAt(i);
                        }
                    }
                    if (CurrentCommand == "Help")
                    {
                        Console.WriteLine("Введите кость которую хотите выложить, например '0x0', английской раскладкой");

                    }
                    if (CurrentCommand == "Dominoes")
                    {
                        Console.WriteLine("Ваши кости");
                        foreach (string s in DominoPlayer2)
                        {
                            Console.WriteLine(s);
                        }
                        Player2();
                        return;
                    }
                    if (DominoPlayer2.Contains(CurrentCommand))
                    {
                        for (int k = 0; k < Table.Length; k++)
                        {
                            if (Table[k] == CurrentCommand.Split('x')[0])
                            {
                                DominoPlayer2.Remove(CurrentCommand);
                                Table[k] = CurrentCommand.Split('x')[1];
                                Player1();
                                return;
                            }
                            else if (Table[k] == CurrentCommand.Split('x')[1])
                            {
                                DominoPlayer2.Remove(CurrentCommand);
                                Table[k] = CurrentCommand.Split('x')[0];
                                Player1();
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Эта кость не подходит, выберете другую кость!");
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("Такой кости у вас нет, напишите 'Dominoes' чтобы увидеть список всех своих костей или 'Add' чтобы взять кость с базара");
                        Player2();
                        return;
                    }
                    Player2();

                }
                Console.WriteLine("Ходит 2 игрок: \nДля справки напишите Help");
                CurrentCommand = Console.ReadLine();

                if (CurrentCommand == "Help")
                {
                    Console.WriteLine("Введите кость которую хотите выложить, например '0x0', английской раскладкой");
                }

            }
        }
        static void Win(string text)
        {
            Console.WriteLine(text);
            Console.WriteLine("Нажмите любую клавишу чтобы начать сначала");
            Console.ReadKey();
            StartGame();
        }
        static void Player1()
        {
            if (DominoPlayer1.Count <= 0)
            {
                Win("Игрок 1 победил!");
                return;
            }
            string CurrentCommand = null;
            Console.WriteLine("Ходит игрок 1");
            while(true)
            {
                if (IsFirstStep)
                {
                    Console.WriteLine("Это первый ход, вы можете ходить как хотите! Для справки напишите 'Help' или 'Dominoes' чтобы увидеть свои кости");
                    Console.WriteLine("Напишите номер кости, которую хотите выложить:");
                    CurrentCommand = Console.ReadLine();
                    if(CurrentCommand == "Help")
                    {
                        Console.WriteLine("Введите кость которую хотите выложить, например '0x0', английской раскладкой");

                    }
                    if (CurrentCommand == "Dominoes")
                    {
                        Console.WriteLine("Ваши кости");
                        foreach(string s in DominoPlayer1)
                        {
                            Console.WriteLine(s);
                        }
                        Player1();
                        return;
                    }
                    if (DominoPlayer1.Contains(CurrentCommand))
                    {
                        Table = CurrentCommand.Split('x');
                        IsFirstStep = false;
                        DominoPlayer1.Remove(CurrentCommand);
                        Player2();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Такой кости у вас нет, напишите 'Dominoes' чтобы увидеть список всех своих костей или 'Add' чтобы взять кость с базара");
                        Player1();
                        return;
                    }
                    Player2();
                }
                else
                {
                    Console.WriteLine("Напишите номер кости, которую хотите выложить:");
                    CurrentCommand = Console.ReadLine();

                    if (CurrentCommand == "Add")
                    {
                        if (Dominos.Count > 0)
                        {
                            int i = random.Next(0, Dominos.Count);
                            DominoPlayer1.Add(Dominos[i]);
                            Console.WriteLine("Кость " + Dominos[i] + " Добавлена");
                            Dominos.RemoveAt(i);
                        }
                    }
                    if (CurrentCommand == "Help")
                    {
                        Console.WriteLine("Введите кость которую хотите выложить, например '0x0', английской раскладкой");

                    }
                    if (CurrentCommand == "Dominoes")
                    {
                        Console.WriteLine("Ваши кости");
                        foreach (string s in DominoPlayer1)
                        {
                            Console.WriteLine(s);
                        }
                        Player1();
                        return;
                    }
                    if (DominoPlayer1.Contains(CurrentCommand))
                    {
                        for(int k=0; k<Table.Length;k++)
                        {
                            if(Table[k]==CurrentCommand.Split('x')[0])
                            {
                                DominoPlayer1.Remove(CurrentCommand);
                                Table[k] = CurrentCommand.Split('x')[1];
                                Player2();
                                return;
                            }
                            else if (Table[k] == CurrentCommand.Split('x')[1])
                            {
                                DominoPlayer1.Remove(CurrentCommand);
                                Table[k] = CurrentCommand.Split('x')[0];
                                Player2();
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Эта кость не подходит, выберете другую кость!");
                            }
                            
                        }
                    }
                    else
                    {
                        Console.WriteLine("Такой кости у вас нет, напишите 'Dominoes' чтобы увидеть список всех своих костей или 'Add' чтобы взять кость с базара");
                        Player1();
                        return;
                    }
                    Player2();

                }
                Console.WriteLine("Ходит 1 игрок: \nДля справки напишите Help");
                CurrentCommand = Console.ReadLine();

                if (CurrentCommand == "Help")
                {
                    Console.WriteLine("Введите кость которую хотите выложить, например '0x0', английской раскладкой");
                }

            }
        }
        static string[] Table=null;
    }
}
