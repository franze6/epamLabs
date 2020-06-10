using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Person
    {
        public string Name { get; set; }
        public event Program.OnCame OnCame;
        public event Program.OnLeave OnLeave;


        public void Came()
        {
            OnCame?.Invoke(this, DateTime.Now);
        }
        public void Leave()
        {
            OnLeave?.Invoke(this);
        }
        public void SayHello(Person p, DateTime time)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string text;
            if (time.Hour < 12)
            {
                text = "Доброе утро";
            }
            else if (time.Hour < 17)
            {
                text = "Добрый день";
            }
            else
            {
                text = "Добрый вечер";
            }

            Console.WriteLine($"[{this.Name}]:{text}, {p.Name}!");
        }
        public void SayBye(Person p)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Пока, {p.Name}, сказал {this.Name}!");
        }
    }
}
