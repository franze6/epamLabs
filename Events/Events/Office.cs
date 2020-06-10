using System;
using System.Collections.Generic;

namespace Events
{
    delegate void SayHello(Person p, DateTime time);
    delegate void SayBye(Person p);
    class Office
    {
        private SayHello helloList;
        private SayBye byeList;

        public Office(List<Person> persons)
        {
            foreach (var p in persons)
            {
                p.OnCame += OnCameHandler;
                p.OnLeave += OnLeaveHandler;
            }
        }

        private void OnCameHandler(Person p, DateTime time)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"--Сотрудник {p.Name} пришёл");
            helloList?.Invoke(p, time);

            helloList += p.SayHello;
            byeList += p.SayBye;
        }

        private void OnLeaveHandler(Person p)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"--Сотрудник {p.Name} ушёл");
            helloList -= p.SayHello;
            byeList -= p.SayBye;
            byeList?.Invoke(p);
        }

    }
}
