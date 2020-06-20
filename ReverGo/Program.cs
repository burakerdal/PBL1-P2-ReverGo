using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverGo
{
    class Program
    {
        static void HelloUser() {
            Console.Clear();
            Console.Write("                 Hello User, Welcome to the ReverGo");
            System.Threading.Thread.Sleep(100);
            Console.Write(".");
            System.Threading.Thread.Sleep(200);
            Console.Write(".");
            System.Threading.Thread.Sleep(400);
            Console.Write(".");
            System.Threading.Thread.Sleep(800);
            Console.Write(".");
            System.Threading.Thread.Sleep(1000);
        }
        static void ShowMenu() {
            
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("************************************ MENU *********************************");
                Console.Write("Press 1 for 1x16 board game | Press 2 for 8x8 board game | Press 3 for Exit");
            Console.WriteLine("");
        }
        static void DisplayBoard1(int[] one_dimensional_board, int round,int computer_score, int player_score) {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("  0 0 0 0 0 0 0 0 0 1 1 1 1 1 1 1");
            Console.WriteLine("  1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6");
            Console.WriteLine("+ - - - - - - - - - - - - - - - - +         Round: " + round);
                Console.Write("| ");
            for (int i = 0; i < one_dimensional_board.Length; i++){

                if (i > 3 && i < 12) {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else{
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                if (one_dimensional_board[i] == 0) {
                    Console.Write(". ");
                }
                else if (one_dimensional_board[i] == 1){
                    Console.Write("o ");
                }
                else if (one_dimensional_board[i] == 2){
                    Console.Write("x ");
                }


            }
            Console.WriteLine("|         Computer: " + computer_score);
            Console.WriteLine("+ - - - - - - - - - - - - - - - - +         Human: " + player_score);
        }
        static void DisplayBoard2(int[,] two_dimensional_board, int round, int computer_score, int human_score) {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("    1 2 3 4 5 6 7 8");
            Console.WriteLine("  + - - - - - - - - +");
            for (int i = 0; i < two_dimensional_board.GetLength(0); i++)
            {
                Console.Write((i + 1) + " | ");
                for (int j = 0; j < two_dimensional_board.GetLength(1); j++)
                {                    
                        if ((i > 1 && i <= 5) && (j > 1 && j <= 5))
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }

                    if (two_dimensional_board[i, j] == 0)
                    {
                        Console.Write(". ");
                    }
                    else if (two_dimensional_board[i, j] == 1)
                    {
                        Console.Write("o ");
                    }
                    else if (two_dimensional_board[i, j] == 2)
                    {
                        Console.Write("x ");
                    }

                }
                if (i == 2)
                    Console.Write("|           Round: " + round);
                else if (i == 3)
                    Console.Write("|           Computer: " + computer_score);
                else if (i == 4)
                    Console.Write("|           Human: " + human_score);
                else
                    Console.Write("|");

                Console.WriteLine();
            }
            Console.WriteLine("  + - - - - - - - - +");
        }
        static void Game1(bool game1, int[] one_dimensional_board, int computer_count, int human_count, int round) {
            Random rnd = new Random();
            while (game1)
            {
                /*
                Console.Write("Your move: ");
                String humanmove = Console.ReadLine();
                int newHumanMove = 0;

                while (!int.TryParse(humanmove, out newHumanMove) || (newHumanMove>16) || (newHumanMove < 1)) {
                  
                    Console.Write("Wrong input! Your move again: ");
                    humanmove = Console.ReadLine();
                    
                }
                if (round == 1)
                {
                    while (!int.TryParse(humanmove, out newHumanMove) || newHumanMove < 5 || newHumanMove > 12)
                    {
                        Console.WriteLine("Your first move should be 5 between 12");
                        Console.Write("Your move again: ");
                        humanmove = Console.ReadLine();
                    }
                    //one_dimensional_board[newHumanMove-1] = 1;

                }
                else {
                   
                }*/








                Console.Write("Your move: ");
                int human_move = Convert.ToInt16(Console.ReadLine());
                while (human_move > 16 || human_move < 0)
                {
                    Console.WriteLine("Wrong Move1!");
                    human_move = Convert.ToInt16(Console.ReadLine());
                }
                bool human_flag = true;
                human_move = human_move - 1;
                while (human_flag)
                {
                    int count = 0;

                    if (one_dimensional_board[human_move] != 0)
                    {
                        Console.WriteLine("Wrong Move2!");
                        count = 1;
                    }
                    if ((human_move == 0 || human_move == 1) && 
                        (one_dimensional_board[human_move + 1] == 0 && one_dimensional_board[human_move + 2] == 0) )
                    {
                        Console.WriteLine("Wrong Move3!");
                        count = 1;
                    }
                   
                    if ((human_move == 14 || human_move == 15) && 
                        (one_dimensional_board[human_move - 1] == 0 && one_dimensional_board[human_move - 2] == 0))
                    {
                        Console.WriteLine("Wrong Move5!");
                        count = 1;
                    }
                   
                    if (((human_move > 1 && human_move < 4)||(human_move > 11 && human_move < 14)) &&
                        one_dimensional_board[human_move + 1] == 0 && one_dimensional_board[human_move + 2] == 0 &&
                        one_dimensional_board[human_move - 1] == 0 && one_dimensional_board[human_move - 2] == 0)
                    {
                        Console.WriteLine("Wrong Move7!");
                        count = 1;
                    }
                    
                    if (count == 0)
                        human_flag = false;
                    else if (count == 1)
                    {
                        
                        Console.WriteLine("Your move againn: ");
                        human_move = Convert.ToInt16(Console.ReadLine());
                        human_move--;
                        Console.WriteLine();
                    }

                }
                //Console.Clear();
                one_dimensional_board[human_move] = 1;
                int human_first_left = 20;
                int human_first_right = 20;
                int human_left_count = 0;
                int human_right_count = 0;
                for (int i = human_move - 1; i >= 0; i--)
                {
                    if (one_dimensional_board[i] == 1)
                    {
                        human_first_left = i;
                        break;
                    }
                }
                for (int i = human_move + 1; i < 16; i++)
                {
                    if (one_dimensional_board[i] == 1)
                    {
                        human_first_right = i;
                        break;
                    }
                }
                if (human_first_left != 20)
                {
                    for (int i = human_first_left + 1; i < human_move; i++)
                    {
                        if (one_dimensional_board[i] == 2)
                            human_left_count++;
                    }
                    if (human_left_count == (human_move - human_first_left - 1))
                    {
                        for (int i = human_first_left + 1; i < human_move; i++)
                            one_dimensional_board[i] = 1;
                    }
                }
                if (human_first_right != 20)
                {
                    for (int i = human_move + 1; i < human_first_right; i++)
                    {
                        if (one_dimensional_board[i] == 2)
                            human_right_count++;
                    }
                    if (human_right_count == (human_first_right - human_move - 1))
                    {
                        for (int i = human_move + 1; i < human_first_right; i++)
                            one_dimensional_board[i] = 1;
                    }
                }
                for (int i = 0; i < 16; i++)
                {
                    if (one_dimensional_board[i] == 1)
                        human_count++;
                    else if (one_dimensional_board[i] == 2)
                        computer_count++;
                }

                DisplayBoard1(one_dimensional_board, round, computer_count, human_count);

                Console.WriteLine("Press 'Enter' for computer move");
                Console.ReadLine();
                //Console.Clear();

                computer_count = 0;
                human_count = 0;
                int ai_count = 0;
                int max = 0;
                int max_position = 20;
                for (int i = 0; i < 16; i++)
                {
                    if (one_dimensional_board[i] == 2)
                    {
                        if (i < 14)
                        {
                            for (int j = i + 1; j < 15; j++)
                            {
                                if (one_dimensional_board[j] == 1)
                                    ai_count++;
                                else if (one_dimensional_board[j] == 2)
                                    break;
                                else
                                {
                                    if (ai_count > max)
                                    {
                                        max = ai_count;
                                        max_position = i + ai_count + 1;
                                    }
                                    break;
                                }
                            }
                            ai_count = 0;
                        }
                        if (i > 1)
                        {
                            for (int j = i - 1; j >= 0; j--)
                            {
                                if (one_dimensional_board[j] == 1)
                                    ai_count++;
                                else if (one_dimensional_board[j] == 2)
                                    break;
                                else
                                {
                                    if (ai_count > max)
                                    {
                                        max = ai_count;
                                        max_position = i - ai_count - 1;
                                    }
                                    break;
                                }
                            }
                            ai_count = 0;
                        }

                    }
                }
                bool computer_flag = true;
                int computer_move = 0;
                if (max_position != 20)
                {
                    computer_flag = false;
                    computer_move = max_position;
                }
                else
                {
                    computer_move = rnd.Next(1, 16);
                }
                while (computer_flag)
                {
                    int count = 0;
                    if (computer_move > 15)
                        count = 1;
                    if (one_dimensional_board[computer_move] == 1 || one_dimensional_board[computer_move] == 2)
                        count = 1;
                    if (computer_move == 0 && one_dimensional_board[1] != 1 && one_dimensional_board[2] != 1 && one_dimensional_board[1] != 2 && one_dimensional_board[2] != 2)
                        count = 1;
                    if (computer_move == 1 && one_dimensional_board[0] != 1 && one_dimensional_board[2] != 1 && one_dimensional_board[3] != 1 && one_dimensional_board[0] != 2 && one_dimensional_board[2] != 2 && one_dimensional_board[3] != 2)
                        count = 1;
                    if (computer_move == 14 && one_dimensional_board[15] != 1 && one_dimensional_board[13] != 1 && one_dimensional_board[12] != 1 && one_dimensional_board[15] != 2 && one_dimensional_board[13] != 2 && one_dimensional_board[12] != 2)
                        count = 1;
                    if (computer_move == 15 && one_dimensional_board[14] != 1 && one_dimensional_board[13] != 1 && one_dimensional_board[14] != 2 && one_dimensional_board[13] != 2)
                        count = 1;
                    if (computer_move > 1 && computer_move < 4 &&
                        one_dimensional_board[computer_move + 1] != 1 &&
                        one_dimensional_board[computer_move + 2] != 1 &&
                        one_dimensional_board[computer_move - 1] != 1 &&
                        one_dimensional_board[computer_move - 2] != 1 &&
                        one_dimensional_board[computer_move + 1] != 2 &&
                        one_dimensional_board[computer_move + 2] != 2 &&
                        one_dimensional_board[computer_move - 1] != 2 &&
                        one_dimensional_board[computer_move - 2] != 2)
                        count = 1;
                    if (computer_move > 11 && computer_move < 14 &&
                        one_dimensional_board[computer_move + 1] != 1 &&
                        one_dimensional_board[computer_move + 2] != 1 &&
                        one_dimensional_board[computer_move - 1] != 1 &&
                        one_dimensional_board[computer_move - 2] != 1 &&
                        one_dimensional_board[computer_move + 1] != 2 &&
                        one_dimensional_board[computer_move + 2] != 2 &&
                        one_dimensional_board[computer_move - 1] != 2 &&
                        one_dimensional_board[computer_move - 2] != 2)
                        count = 1;
                    if (count == 0)
                        computer_flag = false;
                    else if (count == 1)
                        computer_move = rnd.Next(0, 16);
                }
                one_dimensional_board[computer_move] = 2;
                int computer_first_left = 20;
                int computer_first_right = 20;
                int computer_left_count = 0;
                int computer_right_count = 0;
                for (int i = computer_move - 1; i >= 0; i--)
                {
                    if (one_dimensional_board[i] == 2)
                    {
                        computer_first_left = i;
                        break;
                    }
                }
                for (int i = computer_move + 1; i < 16; i++)
                {
                    if (one_dimensional_board[i] == 2)
                    {
                        computer_first_right = i;
                        break;
                    }
                }
                if (computer_first_left != 20)
                {
                    for (int i = computer_first_left + 1; i < computer_move; i++)
                    {
                        if (one_dimensional_board[i] == 1)
                            computer_left_count++;
                    }
                    if (computer_left_count == (computer_move - computer_first_left - 1))
                    {
                        for (int i = computer_first_left + 1; i < computer_move; i++)
                            one_dimensional_board[i] = 2;
                    }

                }
                if (computer_first_right != 20)
                {
                    for (int i = computer_move + 1; i < computer_first_right; i++)
                    {
                        if (one_dimensional_board[i] == 1)
                            computer_right_count++;
                    }
                    if (computer_right_count == (computer_first_right - computer_move - 1))
                    {
                        for (int i = computer_move + 1; i < computer_first_right; i++)
                            one_dimensional_board[i] = 2;
                    }
                }
                for (int i = 0; i < 16; i++)
                {
                    if (one_dimensional_board[i] == 1)
                        human_count++;
                    else if (one_dimensional_board[i] == 2)
                        computer_count++;
                }
                round++;
                DisplayBoard1(one_dimensional_board, round, computer_count, human_count);

                human_count = 0;
                computer_count = 0;
                int board_count = 0;
                for (int i = 0; i < 16; i++)
                {
                    if (one_dimensional_board[i] == 0)
                        break;
                    else
                        board_count++;
                }
                if (board_count == 16)
                    game1 = false;

            }
        }
        static void Game2(bool game2, int[,] two_dimensional_board, int computer_score, int human_score, int round) {
            Random rnd = new Random();
            while (game2)
            {
                Console.Write("Enter x,y : ");
                char coordSplit = ',';
                string reader = Console.ReadLine();

                string[] coordinates = reader.Split(coordSplit);

                int human_move_y = Convert.ToInt16(coordinates[0]);
                int human_move_x = Convert.ToInt16(coordinates[1]);
   
                Console.WriteLine();

                bool human_flag = true;
                human_move_x--;
                human_move_y--;
                if (human_move_x > 1 && human_move_x < 6 && human_move_y > 1 && human_move_y < 6 && two_dimensional_board[human_move_x, human_move_y] != 1 && two_dimensional_board[human_move_x, human_move_y] != 2)
                    human_flag = false;
                while (human_flag)
                {
                    int count = 0;
                    if (two_dimensional_board[human_move_x, human_move_y] == 1 || two_dimensional_board[human_move_x, human_move_y] == 2)
                    {
                        Console.WriteLine("Wrong Move");
                        count = 1;
                    }

                    int min_distance = 20;
                    for (int i = 0; i < two_dimensional_board.GetLength(0); i++)
                    {
                        for (int j = 0; j < two_dimensional_board.GetLength(1); j++)
                        {
                            if (two_dimensional_board[i, j] == 1 || two_dimensional_board[i, j] == 2)
                            {
                                int dif_x = Math.Abs(i - human_move_x);
                                int dif_y = Math.Abs(j - human_move_y);
                                int distance = (dif_x * dif_x) + (dif_y * dif_y);
                                if (distance < min_distance)
                                    min_distance = distance;
                            }
                        }


                    }
                    if (min_distance > 8)
                    {
                        count = 1;
                    }
                    if (count == 0)
                        human_flag = false;
                    else
                    {
                        Console.WriteLine("Wrong Move");
                        Console.Write("Enter x,y : ");                   
                        reader = Console.ReadLine();
                        string[] coordinates2 = reader.Split(coordSplit);
                        human_move_y = Convert.ToInt16(coordinates2[0]);
                        human_move_x = Convert.ToInt16(coordinates2[1]);
                        human_move_x--;
                        human_move_y--;
                        Console.WriteLine();
                        if (human_move_x > 1 && human_move_x < 6 && human_move_y > 1 && human_move_y < 6 && two_dimensional_board[human_move_x, human_move_y] != 1 && two_dimensional_board[human_move_x, human_move_y] != 2)
                            human_flag = false;
                    }

                }
                Console.Clear();
                two_dimensional_board[human_move_x, human_move_y] = 1;
                int human_first_left = 20;
                int human_first_right = 20;
                int human_first_up = 20;
                int human_first_down = 20;
                int human_first_upper_right_x = 20;
                int human_first_upper_right_y = 20;
                int human_first_upper_left_x = 20;
                int human_first_upper_left_y = 20;
                int human_first_lower_right_x = 20;
                int human_first_lower_right_y = 20;
                int human_first_lower_left_x = 20;
                int human_first_lower_left_y = 20;
                int human_left_count = 0;
                int human_right_count = 0;
                int human_up_count = 0;
                int human_down_count = 0;
                int human_upper_right_count = 0;
                int human_upper_left_count = 0;
                int human_lower_right_count = 0;
                int human_lower_left_count = 0;
                for (int i = human_move_y - 1; i >= 0; i--)
                {
                    if (two_dimensional_board[human_move_x, i] == 1)
                    {
                        human_first_left = i;
                        break;
                    }
                }
                for (int i = human_move_y + 1; i < 8; i++)
                {
                    if (two_dimensional_board[human_move_x, i] == 1)
                    {
                        human_first_right = i;
                        break;
                    }
                }
                if (human_first_left != 20)
                {
                    for (int i = human_first_left + 1; i < human_move_y; i++)
                    {
                        if (two_dimensional_board[human_move_x, i] == 2)
                            human_left_count++;
                    }
                    if (human_left_count == (human_move_y - human_first_left - 1))
                    {
                        for (int i = human_first_left + 1; i < human_move_y; i++)
                            two_dimensional_board[human_move_x, i] = 1;
                    }
                }
                if (human_first_right != 20)
                {
                    for (int i = human_move_y + 1; i < human_first_right; i++)
                    {
                        if (two_dimensional_board[human_move_x, i] == 2)
                            human_right_count++;
                    }
                    if (human_right_count == (human_first_right - human_move_y - 1))
                    {
                        for (int i = human_move_y + 1; i < human_first_right; i++)
                            two_dimensional_board[human_move_x, i] = 1;
                    }
                }
                for (int i = human_move_x - 1; i >= 0; i--)
                {
                    if (two_dimensional_board[i, human_move_y] == 1)
                    {
                        human_first_up = i;
                        break;
                    }
                }
                for (int i = human_move_x + 1; i < 8; i++)
                {
                    if (two_dimensional_board[i, human_move_y] == 1)
                    {
                        human_first_down = i;
                        break;
                    }
                }
                if (human_first_up != 20)
                {
                    for (int i = human_first_up + 1; i < human_move_x; i++)
                    {
                        if (two_dimensional_board[i, human_move_y] == 2)
                            human_up_count++;
                    }
                    if (human_up_count == (human_move_x - human_first_up - 1))
                    {
                        for (int i = human_first_up + 1; i < human_move_x; i++)
                            two_dimensional_board[i, human_move_y] = 1;
                    }
                }
                if (human_first_down != 20)
                {
                    for (int i = human_first_down - 1; i > human_move_x; i--)
                    {
                        if (two_dimensional_board[i, human_move_y] == 2)
                            human_down_count++;
                    }
                    if (human_down_count == (human_first_down - human_move_x - 1))
                    {
                        for (int i = human_first_down - 1; i > human_move_x; i--)
                            two_dimensional_board[i, human_move_y] = 1;
                    }
                }
                int a = human_move_x - 1;
                int b = human_move_y - 1;
                while (a >= 0 && b >= 0)
                {
                    if (two_dimensional_board[a, b] == 1)
                    {
                        human_first_upper_left_x = a;
                        human_first_upper_left_y = b;
                        break;
                    }
                    a--;
                    b--;
                }
                if (human_first_upper_left_x != 20 && human_first_upper_left_y != 20)
                {
                    a++;
                    b++;
                    while (a != human_move_x && b != human_move_y)
                    {
                        if (two_dimensional_board[a, b] == 2)
                            human_upper_left_count++;
                        a++;
                        b++;
                    }
                    if (human_upper_left_count == (human_move_x - human_first_upper_left_x - 1))
                    {
                        a = human_first_upper_left_x + 1;
                        b = human_first_upper_left_y + 1;
                        for (int i = 0; i < human_upper_left_count; i++)
                        {
                            two_dimensional_board[a, b] = 1;
                            a++;
                            b++;
                        }
                    }
                }
                a = human_move_x - 1;
                b = human_move_y + 1;
                while (a >= 0 && b <= 7)
                {
                    if (two_dimensional_board[a, b] == 1)
                    {
                        human_first_upper_right_x = a;
                        human_first_upper_right_y = b;
                        break;
                    }
                    a--;
                    b++;
                }
                if (human_first_upper_right_x != 20 && human_first_upper_right_y != 20)
                {
                    a++;
                    b--;
                    while (a != human_move_x && b != human_move_y)
                    {
                        if (two_dimensional_board[a, b] == 2)
                            human_upper_right_count++;
                        a++;
                        b--;
                    }
                    if (human_upper_right_count == (human_move_x - human_first_upper_right_x - 1))
                    {
                        a = human_first_upper_right_x + 1;
                        b = human_first_upper_right_y - 1;
                        for (int i = 0; i < human_upper_right_count; i++)
                        {
                            two_dimensional_board[a, b] = 1;
                            a++;
                            b--;
                        }
                    }
                }
                a = human_move_x + 1;
                b = human_move_y + 1;
                while (a <= 7 && b <= 7)
                {
                    if (two_dimensional_board[a, b] == 1)
                    {
                        human_first_lower_right_x = a;
                        human_first_lower_right_y = b;
                        break;
                    }
                    a++;
                    b++;
                }
                if (human_first_lower_right_x != 20 && human_first_lower_right_y != 20)
                {
                    a--;
                    b--;
                    while (a != human_move_x && b != human_move_y)
                    {
                        if (two_dimensional_board[a, b] == 2)
                            human_lower_right_count++;
                        a--;
                        b--;
                    }
                    if (human_lower_right_count == (human_first_lower_right_x - human_move_x - 1))
                    {
                        a = human_first_lower_right_x - 1;
                        b = human_first_lower_right_y - 1;
                        for (int i = 0; i < human_lower_right_count; i++)
                        {
                            two_dimensional_board[a, b] = 1;
                            a--;
                            b--;
                        }
                    }
                }
                a = human_move_x + 1;
                b = human_move_y - 1;
                while (a <= 7 && b >= 0)
                {
                    if (two_dimensional_board[a, b] == 1)
                    {
                        human_first_lower_left_x = a;
                        human_first_lower_left_y = b;
                        break;
                    }
                    a++;
                    b--;
                }
                if (human_first_lower_left_x != 20 && human_first_lower_left_y != 20)
                {
                    a--;
                    b++;
                    while (a != human_move_x && b != human_move_y)
                    {
                        if (two_dimensional_board[a, b] == 2)
                            human_lower_left_count++;
                        a--;
                        b++;
                    }
                    if (human_lower_left_count == (human_first_lower_left_x - human_move_x - 1))
                    {
                        a = human_first_lower_left_x - 1;
                        b = human_first_lower_left_y + 1;
                        for (int i = 0; i < human_lower_left_count; i++)
                        {
                            two_dimensional_board[a, b] = 1;
                            a--;
                            b++;
                        }
                    }
                }
                for (int i = 0; i < two_dimensional_board.GetLength(0); i++)
                {
                    for (int j = 0; j < two_dimensional_board.GetLength(1); j++)
                    {
                        if (two_dimensional_board[i, j] == 1)
                            human_score++;
                        else if (two_dimensional_board[i, j] == 2)
                            computer_score++;
                    }
                }
                DisplayBoard2(two_dimensional_board, round, computer_score, human_score);

                human_score = 0;
                computer_score = 0;
                round++;
                Console.WriteLine("Press 'Enter' for Computer Move");
                Console.ReadLine();
                Console.Clear();
                int computer_move_x = 0;
                int computer_move_y = 0;
                bool computer_flag = true;
                int max = 0;
                int max_x = 0;
                int max_y = 0;
                for (int i = 0; i < two_dimensional_board.GetLength(0); i++)
                {
                    for (int j = 0; j < two_dimensional_board.GetLength(1); j++)
                    {
                        int computer_first_left_check = 20;
                        int computer_first_right_check = 20;
                        int computer_first_up_check = 20;
                        int computer_first_down_check = 20;
                        int computer_first_upper_right_x_check = 20;
                        int computer_first_upper_right_y_check = 20;
                        int computer_first_upper_left_x_check = 20;
                        int computer_first_upper_left_y_check = 20;
                        int computer_first_lower_right_x_check = 20;
                        int computer_first_lower_right_y_check = 20;
                        int computer_first_lower_left_x_check = 20;
                        int computer_first_lower_left_y_check = 20;
                        int computer_left_count_check = 0;
                        int computer_right_count_check = 0;
                        int computer_up_count_check = 0;
                        int computer_down_count_check = 0;
                        int computer_upper_right_count_check = 0;
                        int computer_upper_left_count_check = 0;
                        int computer_lower_right_count_check = 0;
                        int computer_lower_left_count_check = 0;
                        if (two_dimensional_board[i, j] == 0)
                        {
                            for (int k = j - 1; k >= 0; k--)
                            {
                                if (two_dimensional_board[i, k] == 2)
                                {
                                    computer_first_left_check = k;
                                    break;
                                }
                                else if (two_dimensional_board[i, k] == 0)
                                    break;
                            }
                            for (int k = j + 1; k < 8; k++)
                            {
                                if (two_dimensional_board[i, k] == 2)
                                {
                                    computer_first_right_check = k;
                                    break;
                                }
                                else if (two_dimensional_board[i, k] == 0)
                                    break;
                            }
                            if (computer_first_left_check != 20)
                            {
                                for (int k = computer_first_left_check + 1; k < j; k++)
                                {
                                    if (two_dimensional_board[i, k] == 1)
                                        computer_left_count_check++;
                                }
                            }
                            if (computer_first_right_check != 20)
                            {
                                for (int k = j + 1; k < computer_first_right_check; k++)
                                {
                                    if (two_dimensional_board[i, k] == 1)
                                        computer_right_count_check++;
                                }
                            }
                            for (int k = i - 1; k >= 0; k--)
                            {
                                if (two_dimensional_board[k, j] == 2)
                                {
                                    computer_first_up_check = k;
                                    break;
                                }
                                else if (two_dimensional_board[k, j] == 0)
                                    break;
                            }
                            for (int k = i + 1; k < 8; k++)
                            {
                                if (two_dimensional_board[k, j] == 2)
                                {
                                    computer_first_down_check = k;
                                    break;
                                }
                                else if (two_dimensional_board[k, j] == 0)
                                    break;
                            }
                            if (computer_first_up_check != 20)
                            {
                                for (int k = computer_first_up_check + 1; k < i; k++)
                                {
                                    if (two_dimensional_board[k, j] == 1)
                                        computer_up_count_check++;
                                }
                            }
                            if (computer_first_down_check != 20)
                            {
                                for (int k = computer_first_down_check - 1; k > i; k--)
                                {
                                    if (two_dimensional_board[k, j] == 1)
                                        computer_down_count_check++;
                                }
                            }
                            a = i - 1;
                            b = j - 1;
                            while (a >= 0 && b >= 0)
                            {
                                if (two_dimensional_board[a, b] == 2)
                                {
                                    computer_first_upper_left_x_check = a;
                                    computer_first_upper_left_y_check = b;
                                    break;
                                }
                                else if (two_dimensional_board[a, b] == 0)
                                    break;
                                a--;
                                b--;
                            }
                            if (computer_first_upper_left_x_check != 20 && computer_first_upper_left_y_check != 20)
                            {
                                a++;
                                b++;
                                while (a != i && b != j)
                                {
                                    if (two_dimensional_board[a, b] == 1)
                                        computer_upper_left_count_check++;
                                    a++;
                                    b++;
                                }
                            }
                            a = i - 1;
                            b = j + 1;
                            while (a >= 0 && b <= 7)
                            {
                                if (two_dimensional_board[a, b] == 2)
                                {
                                    computer_first_upper_right_x_check = a;
                                    computer_first_upper_right_y_check = b;
                                    break;
                                }
                                else if (two_dimensional_board[a, b] == 0)
                                    break;
                                a--;
                                b++;
                            }
                            if (computer_first_upper_right_x_check != 20 && computer_first_upper_right_y_check != 20)
                            {
                                a++;
                                b--;
                                while (a != i && b != j)
                                {
                                    if (two_dimensional_board[a, b] == 1)
                                        computer_upper_right_count_check++;
                                    a++;
                                    b--;
                                }
                            }
                            a = i + 1;
                            b = j + 1;
                            while (a <= 7 && b <= 7)
                            {
                                if (two_dimensional_board[a, b] == 2)
                                {
                                    computer_first_lower_right_x_check = a;
                                    computer_first_lower_right_y_check = b;
                                    break;
                                }
                                else if (two_dimensional_board[a, b] == 0)
                                    break;
                                a++;
                                b++;
                            }
                            if (computer_first_lower_right_x_check != 20 && computer_first_lower_right_y_check != 20)
                            {
                                a--;
                                b--;
                                while (a != i && b != j)
                                {
                                    if (two_dimensional_board[a, b] == 1)
                                        computer_lower_right_count_check++;
                                    a--;
                                    b--;
                                }
                            }
                            a = i + 1;
                            b = j - 1;
                            while (a <= 7 && b >= 0)
                            {
                                if (two_dimensional_board[a, b] == 2)
                                {
                                    computer_first_lower_left_x_check = a;
                                    computer_first_lower_left_y_check = b;
                                    break;
                                }
                                else if (two_dimensional_board[a, b] == 0)
                                    break;
                                a++;
                                b--;
                            }
                            if (computer_first_lower_left_x_check != 20 && computer_first_lower_left_y_check != 20)
                            {
                                a--;
                                b++;
                                while (a != i && b != j)
                                {
                                    if (two_dimensional_board[a, b] == 1)
                                        computer_lower_left_count_check++;
                                    a--;
                                    b++;
                                }
                            }
                            int computer_check_count = computer_left_count_check + computer_lower_left_count_check +
                                computer_lower_right_count_check + computer_right_count_check +
                                computer_up_count_check + computer_upper_left_count_check +
                                computer_upper_right_count_check + computer_down_count_check;
                            if (computer_check_count >= max)
                            {
                                max = computer_check_count;
                                max_x = i;
                                max_y = j;
                            }
                        }
                    }
                }
                if (max != 0)
                {
                    computer_move_x = max_x;
                    computer_move_y = max_y;
                    computer_flag = false;
                }
                else
                {
                    computer_move_x = rnd.Next(0, 8);
                    computer_move_y = rnd.Next(0, 8);
                }

                if (computer_move_x > 1 && computer_move_x < 6 && computer_move_y > 1 && computer_move_y < 6 && two_dimensional_board[computer_move_x, computer_move_y] != 1 && two_dimensional_board[computer_move_x, computer_move_y] != 2)
                    computer_flag = false;
                while (computer_flag)
                {
                    int count = 0;
                    if (two_dimensional_board[computer_move_x, computer_move_y] == 1 || two_dimensional_board[computer_move_x, computer_move_y] == 2)
                        count = 1;


                    int min_distance = 20;
                    for (int i = 0; i < two_dimensional_board.GetLength(0); i++)
                    {
                        for (int j = 0; j < two_dimensional_board.GetLength(1); j++)
                        {
                            if (two_dimensional_board[i, j] == 1 || two_dimensional_board[i, j] == 2)
                            {
                                int dif_x = Math.Abs(i - computer_move_x);
                                int dif_y = Math.Abs(j - computer_move_y);
                                int distance = (dif_x * dif_x) + (dif_y * dif_y);
                                if (distance < min_distance)
                                    min_distance = distance;
                            }
                        }


                    }
                    if (min_distance > 8)
                        count = 1;
                    if (count == 0)
                        computer_flag = false;
                    else
                    {
                        computer_move_x = rnd.Next(0, 8);
                        computer_move_y = rnd.Next(0, 8);
                    }

                }
                two_dimensional_board[computer_move_x, computer_move_y] = 2;
                int computer_first_left = 20;
                int computer_first_right = 20;
                int computer_first_up = 20;
                int computer_first_down = 20;
                int computer_first_upper_right_x = 20;
                int computer_first_upper_right_y = 20;
                int computer_first_upper_left_x = 20;
                int computer_first_upper_left_y = 20;
                int computer_first_lower_right_x = 20;
                int computer_first_lower_right_y = 20;
                int computer_first_lower_left_x = 20;
                int computer_first_lower_left_y = 20;
                int computer_left_count = 0;
                int computer_right_count = 0;
                int computer_up_count = 0;
                int computer_down_count = 0;
                int computer_upper_right_count = 0;
                int computer_upper_left_count = 0;
                int computer_lower_right_count = 0;
                int computer_lower_left_count = 0;
                for (int i = computer_move_y - 1; i >= 0; i--)
                {
                    if (two_dimensional_board[computer_move_x, i] == 2)
                    {
                        computer_first_left = i;
                        break;
                    }
                }
                for (int i = computer_move_y + 1; i < 8; i++)
                {
                    if (two_dimensional_board[computer_move_x, i] == 2)
                    {
                        computer_first_right = i;
                        break;
                    }
                }
                if (computer_first_left != 20)
                {
                    for (int i = computer_first_left + 1; i < computer_move_y; i++)
                    {
                        if (two_dimensional_board[computer_move_x, i] == 1)
                            computer_left_count++;
                    }
                    if (computer_left_count == (computer_move_y - computer_first_left - 1))
                    {
                        for (int i = computer_first_left + 1; i < computer_move_y; i++)
                            two_dimensional_board[computer_move_x, i] = 2;
                    }
                }
                if (computer_first_right != 20)
                {
                    for (int i = computer_move_y + 1; i < computer_first_right; i++)
                    {
                        if (two_dimensional_board[computer_move_x, i] == 1)
                            computer_right_count++;
                    }
                    if (computer_right_count == (computer_first_right - computer_move_y - 1))
                    {
                        for (int i = computer_move_y + 1; i < computer_first_right; i++)
                            two_dimensional_board[computer_move_x, i] = 2;
                    }
                }
                for (int i = computer_move_x - 1; i >= 0; i--)
                {
                    if (two_dimensional_board[i, computer_move_y] == 2)
                    {
                        computer_first_up = i;
                        break;
                    }
                }
                for (int i = computer_move_x + 1; i < 8; i++)
                {
                    if (two_dimensional_board[i, computer_move_y] == 2)
                    {
                        computer_first_down = i;
                        break;
                    }
                }
                if (computer_first_up != 20)
                {
                    for (int i = computer_first_up + 1; i < computer_move_x; i++)
                    {
                        if (two_dimensional_board[i, computer_move_y] == 1)
                            computer_up_count++;
                    }
                    if (computer_up_count == (computer_move_x - computer_first_up - 1))
                    {
                        for (int i = computer_first_up + 1; i < computer_move_x; i++)
                            two_dimensional_board[i, computer_move_y] = 2;
                    }
                }
                if (computer_first_down != 20)
                {
                    for (int i = computer_first_down - 1; i > computer_move_x; i--)
                    {
                        if (two_dimensional_board[i, computer_move_y] == 1)
                            computer_down_count++;
                    }
                    if (computer_down_count == (computer_first_down - computer_move_x - 1))
                    {
                        for (int i = computer_first_down - 1; i > computer_move_x; i--)
                            two_dimensional_board[i, computer_move_y] = 2;
                    }
                }
                a = computer_move_x - 1;
                b = computer_move_y - 1;
                while (a >= 0 && b >= 0)
                {
                    if (two_dimensional_board[a, b] == 2)
                    {
                        computer_first_upper_left_x = a;
                        computer_first_upper_left_y = b;
                        break;
                    }
                    a--;
                    b--;
                }
                if (computer_first_upper_left_x != 20 && computer_first_upper_left_y != 20)
                {
                    a++;
                    b++;
                    while (a != computer_move_x && b != computer_move_y)
                    {
                        if (two_dimensional_board[a, b] == 1)
                            computer_upper_left_count++;
                        a++;
                        b++;
                    }
                    if (computer_upper_left_count == (computer_move_x - computer_first_upper_left_x - 1))
                    {
                        a = computer_first_upper_left_x + 1;
                        b = computer_first_upper_left_y + 1;
                        for (int i = 0; i < computer_upper_left_count; i++)
                        {
                            two_dimensional_board[a, b] = 2;
                            a++;
                            b++;
                        }
                    }
                }
                a = computer_move_x - 1;
                b = computer_move_y + 1;
                while (a >= 0 && b <= 7)
                {
                    if (two_dimensional_board[a, b] == 2)
                    {
                        computer_first_upper_right_x = a;
                        computer_first_upper_right_y = b;
                        break;
                    }
                    a--;
                    b++;
                }
                if (computer_first_upper_right_x != 20 && computer_first_upper_right_y != 20)
                {
                    a++;
                    b--;
                    while (a != computer_move_x && b != computer_move_y)
                    {
                        if (two_dimensional_board[a, b] == 1)
                            computer_upper_right_count++;
                        a++;
                        b--;
                    }
                    if (computer_upper_right_count == (computer_move_x - computer_first_upper_right_x - 1))
                    {
                        a = computer_first_upper_right_x + 1;
                        b = computer_first_upper_right_y - 1;
                        for (int i = 0; i < computer_upper_right_count; i++)
                        {
                            two_dimensional_board[a, b] = 2;
                            a++;
                            b--;
                        }
                    }
                }
                a = computer_move_x + 1;
                b = computer_move_y + 1;
                while (a <= 7 && b <= 7)
                {
                    if (two_dimensional_board[a, b] == 2)
                    {
                        computer_first_lower_right_x = a;
                        computer_first_lower_right_y = b;
                        break;
                    }
                    a++;
                    b++;
                }
                if (computer_first_lower_right_x != 20 && computer_first_lower_right_y != 20)
                {
                    a--;
                    b--;
                    while (a != computer_move_x && b != computer_move_y)
                    {
                        if (two_dimensional_board[a, b] == 1)
                            computer_lower_right_count++;
                        a--;
                        b--;
                    }
                    if (computer_lower_right_count == (computer_first_lower_right_x - computer_move_x - 1))
                    {
                        a = computer_first_lower_right_x - 1;
                        b = computer_first_lower_right_y - 1;
                        for (int i = 0; i < computer_lower_right_count; i++)
                        {
                            two_dimensional_board[a, b] = 2;
                            a--;
                            b--;
                        }
                    }
                }
                a = computer_move_x + 1;
                b = computer_move_y - 1;
                while (a <= 7 && b >= 0)
                {
                    if (two_dimensional_board[a, b] == 2)
                    {
                        computer_first_lower_left_x = a;
                        computer_first_lower_left_y = b;
                        break;
                    }
                    a++;
                    b--;
                }
                if (computer_first_lower_left_x != 20 && computer_first_lower_left_y != 20)
                {
                    a--;
                    b++;
                    while (a != computer_move_x && b != computer_move_y)
                    {
                        if (two_dimensional_board[a, b] == 1)
                            computer_lower_left_count++;
                        a--;
                        b++;
                    }
                    if (computer_lower_left_count == (computer_first_lower_left_x - computer_move_x - 1))
                    {
                        a = computer_first_lower_left_x - 1;
                        b = computer_first_lower_left_y + 1;
                        for (int i = 0; i < computer_lower_left_count; i++)
                        {
                            two_dimensional_board[a, b] = 2;
                            a--;
                            b++;
                        }
                    }
                }
                for (int i = 0; i < two_dimensional_board.GetLength(0); i++)
                {
                    for (int j = 0; j < two_dimensional_board.GetLength(1); j++)
                    {
                        if (two_dimensional_board[i, j] == 1)
                            human_score++;
                        else if (two_dimensional_board[i, j] == 2)
                            computer_score++;
                    }
                }
                DisplayBoard2(two_dimensional_board, round, computer_score, human_score);

                human_score = 0;
                computer_score = 0;
                round++;
                if (round == 65)
                    break;
            }
        }
        static void Result1(int[] one_dimensional_board, int computer_count, int human_count) {
            for (int i = 0; i < 16; i++)
            {
                if (one_dimensional_board[i] == 1)
                    human_count++;
                else if (one_dimensional_board[i] == 2)
                    computer_count++;
            }


            if (human_count > computer_count)
            {
                Console.WriteLine("YOU WON!");
            }
            else if (computer_count > human_count)
            {
                Console.WriteLine("YOU LOSE!");
            }
            else
            {
                Console.WriteLine("TIE!");
            }
        }
        static void Result2(int[,] two_dimensional_board, int computer_score, int human_score) {
            for (int i = 0; i < two_dimensional_board.GetLength(0); i++)
            {
                for (int j = 0; j < two_dimensional_board.GetLength(1); j++)
                {
                    if (two_dimensional_board[i, j] == 1)
                        human_score++;
                    else if (two_dimensional_board[i, j] == 2)
                        computer_score++;
                }
            }
            if (human_score > computer_score)
                Console.WriteLine("YOU WIN!");

            else if (computer_score > human_score)
                Console.WriteLine("YOU LOSE!");
            else
                Console.WriteLine("TIE");
        }

        
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            int[] one_dimensional_board = new int[16];
            int[,] two_dimensional_board = new int[8, 8];

            bool mainGame = true;

            bool game1;
            bool game2;

            HelloUser();
            ShowMenu();
            int option = -1;
            Console.Write("Your choice:");
            String a = Console.ReadLine();
            while (!a.Equals("1") && !a.Equals("2") && !a.Equals("3")) {
                Console.Clear();
                ShowMenu();
                Console.Write("Wrong Option! \n Your choice again:");
                a = Console.ReadLine();
            }
            option = Convert.ToInt32(a);
            
            

            while (mainGame) {
                switch (option)
                {
                    case 1:
                        {
                            int round = 1;
                            int computer_count = 0;
                            int human_count = 0;

                            DisplayBoard1(one_dimensional_board, round, computer_count, human_count);

                            game1 = true;

                            Game1(game1, one_dimensional_board, computer_count, human_count, round);

                            Result1(one_dimensional_board, computer_count, human_count);

                            for (int i = 0; i < one_dimensional_board.Length; i++)
                            {
                                one_dimensional_board[i] = 0;
                            }
                            game1 = false;
                            round = 1;
                            human_count = 0;
                            computer_count = 0;


                            Console.WriteLine("Play Again? (Y/N)");
                            string answer = Console.ReadLine();
                            if (answer.Equals("y", StringComparison.OrdinalIgnoreCase))
                            {
                                game1 = true;
                            }
                            else if (answer.Equals("n", StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine("Go to Main Menu? (Y/N)");
                                string answer2 = Console.ReadLine();
                               
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Clear();
                                if (answer2.Equals("y", StringComparison.OrdinalIgnoreCase))
                                {
                                    ShowMenu();
                                    Console.Write("Your choice:");
                                    option = Convert.ToInt32(Console.ReadLine());
                                }

                                else if (answer2.Equals("n", StringComparison.OrdinalIgnoreCase))
                                {
                                    mainGame = false;
                                    Console.WriteLine("OK. Good bye!");
                                    Console.WriteLine("You can press ENTER for exit");
                                }
                                
                            }

                            break;
                        }
                    case 2:
                        {

                            int round = 1;
                            int human_score = 0;
                            int computer_score = 0;

                            DisplayBoard2(two_dimensional_board, round, computer_score, human_score);

                            game2 = true;

                            Game2(game2, two_dimensional_board, computer_score, human_score, round);

                            Result2(two_dimensional_board, computer_score, human_score);

                            for (int i = 0; i < two_dimensional_board.GetLength(0); i++)
                            {
                                for (int j = 0; j < two_dimensional_board.GetLength(1); j++)
                                {
                                    two_dimensional_board[i, j] = 0;
                                }
                            }

                            game2 = false;
                            computer_score = 0;
                            human_score = 0;
                            round = 1;

                            Console.WriteLine("Play Again? (Y/N)");
                            string answer = Console.ReadLine();
                            if (answer.Equals("y", StringComparison.OrdinalIgnoreCase))
                            {
                                game2 = true;
                            }
                            else if (answer.Equals("n", StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine("Go to Main Menu? (Y/N)");
                                string answer2 = Console.ReadLine();
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Clear();
                                if (answer2.Equals("y", StringComparison.OrdinalIgnoreCase))
                                {
                                    ShowMenu();
                                    Console.Write("Your choice:");
                                    option = Convert.ToInt32(Console.ReadLine());
                                }

                                else if (answer2.Equals("n", StringComparison.OrdinalIgnoreCase))
                                {
                                    mainGame = false;
                                    Console.WriteLine("OK. Good bye!");
                                    Console.WriteLine("You can press ENTER for exit");
                                }

                            }

                            break;
                        }
                    case 3:
                        mainGame = false;
                        Console.WriteLine("Press ENTER for exit");
                        break;
                    default:
                        Console.WriteLine("Wrong Option!");
                        break;
                }
            }
            


            Console.ReadLine();
           
        }

    }
}
