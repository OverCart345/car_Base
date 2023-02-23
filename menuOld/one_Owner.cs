using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace menuOld
{
    internal class one_Owner
    {
        private const double exp = 0.001;
        private double a;
        private double b;
        private double func;
        List<Car> car_List;

        private enum Alpha { Back = 1};
        private const int button_count = 1;
        private Alpha current_Button;

        private string[] button_Name = new string[button_count];

        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////
        /// </summary>

        public one_Owner(List<Car> car_List) 
        {
            this.car_List= car_List;

            current_Button = Alpha.Back;

            button_Name[0] = " Назад ";


            Start();

        }

        private void Start()
        {
            Console.Clear();

            int down = 1;

            Console.SetCursorPosition(2, down);
            Console.WriteLine($"Машины с одним владельцем: ");
            down += 2;

            for (int i =0;i<car_List.Count;i++)
            {
                if (car_List[i].OwnersLen == 1)
                {
                    Console.SetCursorPosition(2, down++);
                    Console.WriteLine($"{car_List[i].Model + ' ' + car_List[i].Color + ' ' + car_List[i].Year.ToString()}");
                }
              
            }

            down += 2;

            for (int i = 0; i < button_count; i++)
            {
              
                int centerX = 3;
                int centerY = down;

                int eValue = (int)current_Button;

                Console.SetCursorPosition(centerX, centerY);
                if (eValue == i + 1)
                {
                    Console.Write(button_Name[i], Console.BackgroundColor = ConsoleColor.White,
                    Console.ForegroundColor = ConsoleColor.Black);
                }
                else
                {
                    Console.Write(button_Name[i], Console.BackgroundColor = ConsoleColor.Black,
                    Console.ForegroundColor = ConsoleColor.White);
                }

                down += 2;
            }

            Choise();

        }

        private void Choise()
        {
            ConsoleKeyInfo chose_Button;

            Console.ResetColor();

            do
            {
                chose_Button = Console.ReadKey(true);

                if (chose_Button.Key == ConsoleKey.UpArrow)
                {

                    if (current_Button - 1 >= Alpha.Back)
                    {
                        current_Button--;
                        Start();
                    }
                }

                if (chose_Button.Key == ConsoleKey.DownArrow)
                {
                    if ((int)current_Button + 1 <= button_count)
                    {
                        current_Button++;
                        Start();
                    }
                }

                if (chose_Button.Key == ConsoleKey.Enter)
                {
                    switch (current_Button)
                    {
                      case Alpha.Back: MainScreen mainM = new MainScreen(car_List); break;
                    }
                }



            } while (true);

        }

    }
}
