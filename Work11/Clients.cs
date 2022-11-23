using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work11
{
    public class Clients
    {
        /// <summary>
        /// Создание клиента
        /// </summary>
        /// <param name="Familiya">Фамилия</param>
        /// <param name="Name">Имя</param>
        /// <param name="Othestvo">Отчество</param>
        ///  <param name="Phone">Номер телефона</param>
        ///   <param name="Pasport">Серия, номер паспорта</param>
        public Clients(string Familiya, string Name, string Othestvo, string Phone, string Pasport)
        {
            this.familiya = Familiya;
            this.name = Name;
            this.othestvo = Othestvo;
            this.phone = Phone;
            this.pasport = Pasport;
        }

        private string familiya; // Поле Фамилия
        private string name;  // Поле Имя
        private string othestvo; // Поле Отчество
        private string phone; // Поле Номер телефона
        private string pasport; // Поле Серия, номер паспорта

        
        #region Методы

        public string PrintAll()
        {
            return $"{this.familiya,15} {this.name,15} {this.othestvo,15} {this.phone,15} {this.pasport,10}";
        }

        #endregion

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Familiya { get { return this.familiya; } }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get { return this.name; } }

        /// <summary>
        /// Отчество
        /// </summary>
        public string Othestvo { get { return this.othestvo; } }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get { return this.phone; } }

        /// <summary>
        /// Паспорт
        /// </summary>
        public string Pasport { get { return this.pasport; } }

    }
}

