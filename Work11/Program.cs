using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace Work11
{
    internal class Program
    {
        /// <summary>
        /// Метод сериализации PhoneBook
        /// </summary>
        /// <param name="СoncreteClients">Экземпляр для сериализации</param>
        /// <param name="Path">Путь к файлу</param>
        static void SerializeClients(Clients СoncreteClients, string Path)
        {           
            // Создаем сериализатор на основе указанного типа
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Clients));
            XElement myClients = new XElement("Clients");

            XElement myFamiliya = new XElement("Familiya");
            myFamiliya.Add(СoncreteClients.Familiya);

            XElement myName = new XElement("Name");
            myName.Add(СoncreteClients.Name);

            XElement myOthestvo = new XElement("Othestvo");
            myOthestvo.Add(СoncreteClients.Othestvo);
                        
            XElement myPhone = new XElement("Phone");
            myPhone.Add(СoncreteClients.Phone);

            XElement myPasport = new XElement("Pasport");
            myPasport.Add(СoncreteClients.Pasport);

            //XAttribute name = new XAttribute("name", СoncreteClients.FIO);

            myClients.Add(myFamiliya, myName, myOthestvo, myPhone, myPasport);
            

            myClients.Save(Path);

            // Создаем поток для сохранения данных
            Stream fStream = new FileStream(Path, FileMode.Create, FileAccess.Write);

            // Запускаем процесс сериализации
            xmlSerializer.Serialize(fStream, СoncreteClients);

            // Закрываем поток
            fStream.Close();


        }
        /// <summary>
        /// Метод десериализации PhoneBook
        /// </summary>
        /// 
        /// <param name="Path">Путь к файлу</param>
        static Clients DeserializeClients(string Path)
        {
            Clients tempClients = new Clients("","","","","");
            // Создаем сериализатор на основе указанного типа 
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Clients));

            // Создаем поток для чтения данных
            Stream fStream = new FileStream(Path, FileMode.Open, FileAccess.Read);

            // Запускаем процесс десериализации
            tempClients = xmlSerializer.Deserialize(fStream) as Clients;

            // Закрываем поток
            fStream.Close();

            // Возвращаем результат
            return tempClients;

            //string xml = System.IO.File.ReadAllText("_phone1.xml");

            //var col = XDocument.Parse(xml)
            //                    .Descendants("Person")
            //                    .ToList();
            //foreach (var item in col)
            //{
            //    Console.WriteLine($"{item}");
            //}

        }

        /// <summary>
        /// Метод сериализации List<Worker >
        /// </summary>
        /// <param name="СoncreteClientsList">Коллекция для сериализации</param>
        /// <param name="Path">Путь к файлу</param>
        static void SerializeClientsList(List<Clients> СoncreteClientsList, string Path)
        {
            // Создаем сериализатор на основе указанного типа 
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Clients>));

            // Создаем поток для сохранения данных
            Stream fStream = new FileStream(Path, FileMode.Create, FileAccess.Write);

            // Запускаем процесс сериализации
            xmlSerializer.Serialize(fStream, СoncreteClientsList);

            // Закрываем поток
            fStream.Close();
        }

        /// <summary>
        /// Метод десериализации Worker
        /// </summary>
        /// <param name="tempClientsList">Экземпляр для сериализации</param>
        /// <param name="Path">Путь к файлу</param>
        static List<Clients> DeserializeClientsList(string Path)
        {
            List<Clients> tempClientsList = new List<Clients>();
            // Создаем сериализатор на основе указанного типа 
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Clients>));

            // Создаем поток для чтения данных
            Stream fStream = new FileStream(Path, FileMode.Open, FileAccess.Read);

            // Запускаем процесс десериализации
            tempClientsList = xmlSerializer.Deserialize(fStream) as List<Clients>;

            // Закрываем поток
            fStream.Close();

            // Возвращаем результат
            return tempClientsList;
        }

        static void Main(string[] args)
        {
            Clients clients1 = new Clients("Куршнева","Алина","Сергеевна","8906436","2233-45678");
            //Clients clients2 = new Clients("", "", "", "", "");
            #region Выбираем сотрудника для входа 
            Console.WriteLine("Здравствуйте, с какими правами доступа вы хотите войти в программу?");
            Console.WriteLine("Введите 1 чтобы войти как консультант");

            string Login = Console.ReadLine();
            if (Login == "1")
            {
                Console.WriteLine("Вы вошли как консультант");
            }
            #endregion

            #region Clients

            
            Console.WriteLine(clients1.PrintAll());

            SerializeClients(clients1, "_Alina.xml");

            Clients clients2 = DeserializeClients("_Alina.xml");
            Console.WriteLine(clients2.PrintAll());

            #endregion

            #region List<Clients>

            List<Clients> list = new List<Clients>();

            for (uint i = 1; i <= 5; i++)
            {
                list.Add(new Clients($"Имя_{i}", $"Фамилия_{i}", $"Отчество_{i}", $"Номер_{i}", $"Паспорт_{i}"));
            }

            SerializeClientsList(list, "_listWorker.xml");

            list = DeserializeClientsList("_listWorker.xml");

            foreach (Clients client in list)
            {
                client.PrintAll();
            }

            #endregion

            Console.ReadKey();
        }
    }
}
