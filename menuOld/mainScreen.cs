using menuOld;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace menuOld
{


    internal class MainScreen
    {
        
        private enum Alpha { But1 = 1, But2 = 2, But3 = 3, But4 = 4, But5 = 5};
        const int button_count = 5;
        private Alpha current_Button;

        private string[] button_Name = new string[button_count];

        private int[] massa = new int[2 * (Console.WindowWidth * 2 + Console.WindowHeight)];

        private List<Car> car_List;

        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////
        /// </summary>

        public MainScreen(List<Car> car_List)
        {
            Console.CursorVisible = false;

            current_Button = Alpha.But1;
            this.car_List = car_List;

            button_Name[0] = " Ввод данных ";
            button_Name[1] = " Выборка машин с одним владельцем ";
            button_Name[2] = " Выборка машин моложе заданного года ";
            button_Name[3] = " Выборка машин заданной марки ";
            button_Name[4] = " Выход ";


           

            Start();


        }

        private void Start()
        {
            Console.Clear();

            int down = 2 * (button_count - 2);

            for (int i = 0; i < button_count; i++)
            {
                int centerX = (Console.WindowWidth / 2) - (button_Name[i].Length / 2);
                int centerY = (Console.WindowHeight / 2) - down;

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



                down -= 2;
            }


            Choise();
        }

        private void ERROR_01() 
        {
            Console.Clear();
            Console.CursorVisible = false;

            Console.SetCursorPosition(2, 1);
            Console.WriteLine("Необходимо ввести данные хотя бы об одной машине! ");

            Console.SetCursorPosition(2, 3);
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

                    if (current_Button - 1 >= Alpha.But1)
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
                    if (current_Button != Alpha.But5 && car_List.Count == 0 && current_Button != Alpha.But1)
                    {
                        ERROR_01();
                    }
                    else
                    {
                        switch (current_Button)
                        {
                            case Alpha.But1: input_Cars MNF = new input_Cars(car_List); break;
                            case Alpha.But2: one_Owner er = new one_Owner(car_List); break;
                            case Alpha.But3: years z1 = new years(car_List); break;
                            case Alpha.But4: marka athor = new marka(car_List); break;
                            case Alpha.But5: Environment.Exit(1); break;
                        }
                    }
                }



            } while (chose_Button.Key != ConsoleKey.Escape);

        }

    }
}

