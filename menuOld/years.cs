using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace menuOld
{
    internal class years
    {
        private double a;
        private double b;
        private int n;
        List<Car> car_List;

        private enum Alpha { Year = 1, Back = 2};
        private const int button_count = 2;
        private Alpha current_Button;

        private string[] button_Name = new string[button_count];

        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////
        /// </summary>

        public years(List<Car> car_List) 
        {
            current_Button = Alpha.Year;
            this.car_List= car_List;

            button_Name[0] = " Ввести год ";
            button_Name[1] = " Назад ";


            Start();

        }
        private void Start() 
        {
            Console.Clear();

            Console.SetCursorPosition(2, 1);
            Console.WriteLine("Выборка машин моложе заданного года");
            //Console.SetCursorPosition(2, 2);
            //Console.WriteLine($"среди {car_List.Count} машин, имеющихся в базе данных");
            int down = 3;

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

        private void Input_Intervals()
        {
            Console.Clear();

            int year;
            int down = 1;

            Console.SetCursorPosition(2, down); down += 2;
            Console.Write("Введите год: ");
            year = Convert.ToInt32(Console.ReadLine());

            Console.SetCursorPosition(2, down++);
            
            bool yes = false;

            for (int i = 0; i < car_List.Count; i++)
            {
                if (car_List[i].Year < year)
                {
                    if(!yes)
                        Console.WriteLine($"Машины моложе {year} года:");
                    yes = true;
                    Console.SetCursorPosition(2, down++);
                    Console.WriteLine($"{car_List[i].Model + ' ' + car_List[i].Color + ' ' + car_List[i].Year.ToString()}");
                }

            }
            if(!yes) Console.WriteLine($"Не найдено машин моложе {year} года");

            Console.SetCursorPosition(2, ++down);
            Console.WriteLine(" Для продолжение нажмите на любую кнопку ", Console.BackgroundColor = ConsoleColor.White,
                Console.ForegroundColor = ConsoleColor.Black);

            Console.ReadKey();
            Console.ResetColor();
            Start();
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

                    if (current_Button - 1 >= Alpha.Year)
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
                        default: Input_Intervals(); break;

                    }
                }



            } while (true);

        }
    }
}
