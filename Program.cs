using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_07
{
    class Program
    {
        static void Main(string[] args)
        {
            /// Разработать ежедневник.
            /// В ежедневнике реализовать возможность 
            /// - создания
            /// - удаления
            /// - реактирования 
            /// записей
            /// 
            /// В отдельной записи должно быть не менее пяти полей
            /// 
            /// Реализовать возможность 
            /// - Загрузки даннах из файла
            /// - Выгрузки даннах в файл
            /// - Добавления данных в текущий ежедневник из выбранного файла
            /// - Импорт записей по выбранному диапазону дат
            /// - Упорядочивания записей ежедневника по выбранному полю
            /// 

            string path = @"data.csv";
            string path1 = @"data1.csv";
            DateTime start = new DateTime(2020, 03, 01);
            DateTime end = new DateTime(2020, 11, 12);
            bool srav;


            Calendar newcal = new Calendar(path);

            //newcal.PrintCal();

            //newcal.LoadNew(path1);

            //newcal.SortByPriority();
            //newcal.SortByDate();
            //newcal.SortByPlace();
            srav = start < end;
            Console.WriteLine($"{srav}");

            newcal.ExportByDate(start, end, path1);


            
           
            newcal.PrintCal();

            //newcal.Save(path);



            // Console.Write(newcal.CalList.Length);


            Console.ReadKey();


        }
    }
}
