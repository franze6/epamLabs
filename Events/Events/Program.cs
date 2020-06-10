using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {
        public delegate void OnCame(Person p, DateTime time);
        public delegate void OnLeave(Person p);
        static void Main(string[] args)
        {
            List<Person> listPersons = new List<Person>();
            listPersons.Add(new Person { Name = "Кирилл" });
            listPersons.Add(new Person { Name = "Никита" });
            listPersons.Add(new Person { Name = "Юля" });
            listPersons.Add(new Person { Name = "Илюха" });
            Office office = new Office(listPersons);
            foreach (var p in listPersons)
            {
                p.Came();
            }
            foreach (var p in listPersons)
            {
                p.Leave();
            }

            Console.ReadKey();
        }
    }
}
