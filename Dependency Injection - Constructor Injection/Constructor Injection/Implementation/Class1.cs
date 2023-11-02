using Constructor_Injection.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor_Injection.Implementation
{
    public class Class1: IMETHOD
    {
        public void Get()
        {
            Console.WriteLine("Hello from class1");
        }
    }
}
