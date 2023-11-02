using Constructor_Injection.Implementation;
using Constructor_Injection.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor_Injection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IMETHOD method = new Class2();

            #region
            /*
            In this program,OperatorClass constructor takes interface object and calles the member function of class that 
            inherits the interface

            */
            #endregion
            //IMETHOD method = new Class1(); 


            OperatorClass obj = new OperatorClass(method);
            obj.Get();
            Console.ReadKey();
        }
    }
}
