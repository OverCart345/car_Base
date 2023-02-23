using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace menuOld
{
    internal class marka
    {
        private enum Alpha {Marco = 1, Back = 2 };
        private const int button_count = 2;
        private Alpha current_Button;
        List<Car> car_List;

        private string[] button_Name = new string[button_count];

        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////
        /// </summary>
        public marka(List<Car> car_List)
        {
            current_Button = Alpha.Marco;
            this.car_List = car_List;

            button_Name[0] = " Ввести марку ";
            button_Name[1] = " Назад ";

            Start();

        }

        private void Start()
        {
            Console.Clear();
            int down = 1;

            Console.SetCursorPosition(2, down); down += 2;
            Console.WriteLine("Выборка машин заданной марки");
           

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

        private void Mark() 
        {
            Console.Clear();


            string marka;
            int down = 1;

            Console.SetCursorPosition(2, down); down += 2;
            Console.Write("Введите марку машины: ");
            marka = Console.ReadLine();

            Console.SetCursorPosition(2, down++);

            bool yes = false;

            for (int i = 0; i < car_List.Count; i++)
            {
                if (car_List[i].Model == marka)
                {
                    if (!yes)
                        Console.WriteLine($"Машины марки {marka}:");
                    yes = true;
                    Console.SetCursorPosition(2, down++);
                    Console.WriteLine($"{car_List[i].Model + ' ' + car_List[i].Color + ' ' + car_List[i].Year.ToString()}");
                }

            }
            if (!yes) Console.WriteLine($"Не найдено машин марки {marka}");

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

                    if (current_Button - 1 >= Alpha.Marco)
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
                        case Alpha.Marco: Mark(); break;
                        case Alpha.Back: MainScreen mainM = new MainScreen(car_List); break;
                       

                    }
                }



            } while (true);

        }

    }
}
