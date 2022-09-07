using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7_Skillbox
{
    public struct Worker
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор для выгрузки данных
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="CurrentDateTime"></param>
        /// <param name="FullName"></param>
        /// <param name="Age"></param>
        /// <param name="Height"></param>
        /// <param name="DateOfBirth"></param>
        /// <param name="PlaceOfBirth"></param>
        public Worker(string ID, string CurrentDateTime, string FullName, string Age, string Height, string DateOfBirth, string PlaceOfBirth)
        {
            this.ID = int.Parse(ID);
            this.CurrentDateTime = DateTime.Parse(CurrentDateTime);
            this.FullName = FullName;
            this.Age = Convert.ToInt32(Age);
            this.Height =Convert.ToInt32(Height);
            this.DateOfBirth = DateTime.Parse(DateOfBirth);
            this.PlaceOfBirth = PlaceOfBirth;
        }

        /// <summary>
        /// Конструктор для создания новой записи
        /// </summary>
        /// <param name="FullName"></param>
        /// <param name="Height"></param>
        /// <param name="DateOfBirth"></param>
        /// <param name="PlaceOfBirth"></param>
        public Worker(string FullName, int Height, DateTime DateOfBirth, string PlaceOfBirth):
            this("0", DateTime.Now.ToString(), FullName, "0", Height.ToString(), DateOfBirth.ToShortDateString(), PlaceOfBirth)
        {
            int Age = DateTime.Today.Year - DateOfBirth.Year;
        }
        #endregion

        #region Автосвойства

        public int ID { get; private set; }

        public DateTime CurrentDateTime { get; private set; }
        public string FullName { get; set; }

        public int Age { get; set; }

        public double Height { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PlaceOfBirth { get; set; }
        #endregion

        #region Методы

        public string Print()
        {
            return $"ID: {ID} CurrentDateTime: {CurrentDateTime} FullName: {FullName} Age: {Age} Height: {Height} Date of birth: {DateOfBirth} Place of birth: {PlaceOfBirth}";
        }
        #endregion
    }
}
