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
        }
    }
}
