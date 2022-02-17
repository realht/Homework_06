using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_07
{
    struct Calendar
    {
        public CalLine[] CalList; //Задаем массив в котором будут все строки календаря
        int index;
        private string path; //путь к файлу с данными
        

        /// <summary>
        /// При создании нового календаря загружает данные из файла
        /// </summary>
        /// <param name="Path">путь к файлу данных</param>
        public Calendar(string Path)
        {
            this.path = Path;
            this.index = 0;
            this.CalList = new CalLine[5];

            this.Load(path);

        }

        /// <summary>
        /// Печатает весь массив строк календаря
        /// </summary>
        public void PrintCal()
        {
            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(this.CalList[i].Print());
            }
        
        }

        /// <summary>
        /// Расширяет список строк календаря
        /// </summary>
        private void Resize(bool NeedMoreString)
        {
            if (NeedMoreString)
            {
                Array.Resize(ref this.CalList, this.CalList.Length + 10);
            }
            
        }

        /// <summary>
        /// Добавление новой записи в календарь
        /// </summary>
        /// <param name="Line">Типизированная запись календаря</param>
        public void Add(CalLine Line)
        {
            this.Resize(index >= this.CalList.Length);
            this.CalList[index] = Line;
            index++;
        }

        /// <summary>
        /// Метод сортировки по полю Приоритет
        /// </summary>
        public void SortByPriority()
        {

            //Обрезаем массив по числу элементов
            Array.Resize(ref CalList, this.index);

            /*Сортировка Указывается Структура 
             * следом экземпляр структура
             * в скобках название перееменных
             * через название переменных в метод CompareTo передаются сравнивыемые значения */

            Array.Sort<CalLine>(CalList, (x, y) => x.Priority.CompareTo(y.Priority));
        }

        /// <summary>
        /// Сортировка по дате
        /// Описание идентично методу выше
        /// </summary>
        public void SortByDate()
        {
            Array.Resize(ref CalList, this.index);
            Array.Sort<CalLine>(CalList, (x, y) => x.DayDate.CompareTo(y.DayDate));
        }

        public void SortByPlace()
        {
            Array.Resize(ref CalList, this.index);
            Array.Sort<CalLine>(CalList, (x, y) => x.Place.CompareTo(y.Place));
        }

        /// <summary>
        /// Метод экспорта записей ограниченных временем в файл
        /// </summary>
        /// <param name="Begin">Дата начала</param>
        /// <param name="End">Дата окончания</param>
        /// <param name="SaveTo">Место сохраненя файла</param>
        public void ExportByDate(DateTime Begin, DateTime End, string SaveTo)
        {   
            Array.Resize(ref CalList, this.index); //обрезается массив по числу строк
            Array.Sort<CalLine>(CalList, (x, y) => x.DayDate.CompareTo(y.DayDate)); //Сортируется массив по дате
            int startPos = 0, endPos = 0, numbExp;
            string expString;

            for (int i = 0; i < this.index; i++) //поиск начальной точки экспорта
            {
                if (CalList[i].DayDate >= Begin)
                { startPos = i; break; }
            }

            for (int i = 0; i < this.index; i++) //поиск конечной точки экспорта
            {
                if (CalList[i].DayDate >= End)
                { endPos = i; break; }
            }

            numbExp = endPos - startPos; //расчет колва строчек экспорта
    
            CalLine[] ExpArray = new CalLine[numbExp]; //создаем новый массив размером в кол-во необходимых строк
            Array.ConstrainedCopy(CalList, startPos, ExpArray, 0, numbExp); //копирует экземпляр в новый массив
            
            //экспортируем все в файл
            for (int i = 0; i < endPos - startPos; i++)
            {
                expString = String.Format("{0}\t{1}\t{2}\t{3}\t{4}",
                    ExpArray[i].DayDate,
                    ExpArray[i].Work,
                    ExpArray[i].Place,
                    ExpArray[i].Priority,
                    ExpArray[i].Comment);
                File.AppendAllText(SaveTo, $"{expString}\n");
            }



        }


        /// <summary>
        /// Сохраняет текущий календарь в файл
        /// </summary>
        /// <param name="Path"></param>
        public void Save(string Path)
        {
            string temp;
            for (int i = 0; i < this.index; i++)
            {
                temp = String.Format("{0}\t{1}\t{2}\t{3}\t{4}",
                    this.CalList[i].DayDate,
                    this.CalList[i].Work,
                    this.CalList[i].Place,
                    this.CalList[i].Priority,
                    this.CalList[i].Comment);
                File.AppendAllText(Path, $"{temp}\n");
            }
        }

        /// <summary>
        /// Добавляет строки в текущий календарь
        /// </summary>
        /// <param name="path"></param>
        private void Load(string path)
        {
            using (StreamReader read = new StreamReader(path))
            {
                while (!read.EndOfStream)
                {
                    string[] info = read.ReadLine().Split('\t');
                    Add(new CalLine(Convert.ToDateTime(info[0]), info[1], info[2], Convert.ToInt32(info[3]), info[4]));
                }
            }
        }

        /// <summary>
        /// Загружает календарь из файла
        /// </summary>
        /// <param name="path"></param>
        public void LoadNew(string path)
        {
            this.index = 0;
            using (StreamReader read = new StreamReader(path))
            {
                while (!read.EndOfStream)
                {
                    string[] info = read.ReadLine().Split('\t');
                    Add(new CalLine(Convert.ToDateTime(info[0]), info[1], info[2], Convert.ToInt32(info[3]), info[4]));
                }
            }
        }

    }
}
