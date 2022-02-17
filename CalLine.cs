using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_07
{
    struct CalLine
    {
        #region Конструктор
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DayDate">День</param>
        /// <param name="Work">Задачи</param>
        /// <param name="Place">Место</param>
        /// <param name="Priority">Приоритет</param>
        /// <param name="Comment">Комментарий</param>
        public CalLine(DateTime DayDate, string Work, string Place, int Priority, string Comment)
        {
            this.dayDate = DayDate;
            this.work = Work;
            this.place = Place;
            this.priority = Priority;
            this.comment = Comment;
        }
        #endregion

        #region Свойства полей
        /// <summary>
        /// Дата
        /// </summary>
        public DateTime DayDate { get { return this.dayDate; } set { this.dayDate = value; } }

        /// <summary>
        /// Поле описания задачи
        /// </summary>
        public string Work { get { return this.work; } set { this.work = value; } }

        /// <summary>
        /// Поле описания места
        /// </summary>
        public string Place { get { return this.place; } set { this.place = value; } }

        /// <summary>
        /// Поле приоритета задачи
        /// </summary>
        public int Priority { get { return this.priority; } set { this.priority = value; } }

        /// <summary>
        /// Поле комментария к задаче
        /// </summary>
        public string Comment { get { return this.comment; } set { this.comment = value; } }
        #endregion


        #region поля
        /// <summary>
        /// Приоритет задачи
        /// </summary>
        private int priority;

        /// <summary>
        /// Дата мероприятия в календаре
        /// </summary>
        private DateTime dayDate;


        /// <summary>
        /// Описание дел на день
        /// </summary>
        private string work;


        /// <summary>
        /// Место проведеения
        /// </summary>
        private string place;


        /// <summary>
        /// Комментарий к делу
        /// </summary>
        private string comment;
        #endregion


        public string Print()
        {
           // string NewDate = DayDate.ToString("yyyy.MM.dd");
            return $"Дата {DayDate:d} Дело {Work} Место {Place} Приоритет {Priority} Комментарий {Comment}";
        }
    }
}
