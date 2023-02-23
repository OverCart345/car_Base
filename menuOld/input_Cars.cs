using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace menuOld
{

    internal class input_Cars
    {
        private double a;
        private double b;
        private int n;
        

        private double[] X;
        private double[] Fx1;
        private double[] Fx2;

        private List<Car> car_List;

        private enum Alpha { Input = 1, Back = 2 };
        private const int BUTTON_COUNT = 2;
        private Alpha current_Button;

        private string[] button_Name = new string[BUTTON_COUNT];

        public input_Cars(List<Car> car_List)
        {
            this.car_List = car_List;
            current_Button = Alpha.Input;

            button_Name[0] = $" Ввести данные о машине ";
            button_Name[1] = " Назад ";
            


            Start();

        }

        private void Start()
        {
            Console.Clear();

            Console.SetCursorPosition(2, 1);
            Console.WriteLine($"Сейчас в базе данных {car_List.Count} машин");
           
            int down = 4;

            for (int i = 0; i < BUTTON_COUNT; i++)
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

        private void TableF() 
        {
            Console.Clear();

            string car_Info;

            string pers_Exit = "f";
            int n = 0;
            int down = 1;

           List<Owner> ownerList = new List<Owner>();
            Console.SetCursorPosition(2, down++);
            Console.Write("Введите данные о машине через пробел(марка, цвет, год выпуска): ");
            Console.SetCursorPosition(2, down++);
            car_Info = Console.ReadLine();

            string[] prop = car_Info.Split();

            Car car = new Car(prop[0], prop[1], prop[2], ownerList);
            car_List.Add(car);

            do
           {


                Console.SetCursorPosition(2, ++down); down++;
                Console.Write($"Введите информацию о водителе {++n} через пробел(Имя, год покупки, год продажи):");
                Console.SetCursorPosition(2, down++);
                string[] tags = Console.ReadLine().Split();
               Owner owner = new Owner(tags[0], tags[1], tags[2]);
               ownerList.Add(owner);

              

                Console.SetCursorPosition(2, ++down); down += 2;
                Console.Write("Ввести данные о следующем водителе(д/н)?: ");
               pers_Exit = Console.ReadLine();

           } while (pers_Exit != "н");



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

                    if ((int)current_Button - 1 >= 1)
                    {
                        current_Button--;
                        Start();
                    }
                }

                if (chose_Button.Key == ConsoleKey.DownArrow)
                {
                    if ((int)current_Button + 1 <= BUTTON_COUNT)
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
                        case Alpha.Input: TableF(); break;

                    }
                }



            } while (true);

        }

    }
}
