using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collectionMy
{
    class Program
    {
        List<Persons> p = new List<Persons>();
        static void Main(string[] args)
        {
            UserList<int, string, Persons> list = new UserList<int, string, Persons>();
            int t = 20;
            string n = "Jack";
            for (int i = 0; i < 20; i++)
            {
                list.Add(i, i.ToString(),new Persons()
                {
                    Age = t + i,
                    Name = n + " " + t
                });
            }

            Console.WriteLine("Вывод коллекции");
            foreach (var item in list)
            {
                Console.WriteLine(String.Format("IdKey {0}, NameKey {1}, Имя персоны {2}, Возраст персоны {3}", 
                    item.Key.Id, item.Key.Name, item.Value.Name, item.Value.Age));
            }

            Console.WriteLine("\n\n");
            Console.WriteLine("Получение по KeyId в данном случае это 4");
            foreach (KeyValuePair<UserKey<int, string>, Persons> item in list.GetById(4))
            {
                Console.WriteLine(String.Format("IdKey {0}, NameKey {1}, Имя персоны {2}, Возраст персоны {3}",
                    item.Key.Id, item.Key.Name, item.Value.Name, item.Value.Age));
            }

            Console.WriteLine("\n\n");
            Console.WriteLine("Получение по KeyName в данном случае это 5");
            foreach (KeyValuePair<UserKey<int, string>, Persons> item in list.GetByName(5.ToString()))
            {
                Console.WriteLine(String.Format("IdKey {0}, NameKey {1}, Имя персоны {2}, Возраст персоны {3}",
                    item.Key.Id, item.Key.Name, item.Value.Name, item.Value.Age));
            }
            Console.ReadKey();
        }
    }
}