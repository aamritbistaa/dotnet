using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_injection
{
    #region singleton class
    // only one instance of the Upload class is created and shared throughout the application
    class Upload
    {
        public Upload() { }
        private static Upload _instance;

        private static readonly object _lock = new object();

        public static Upload Instance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Upload();
                    }
                }
            }

            return _instance;

        }

    }

    #endregion

    #region Constructor injection

    // uses interfaces (IEmp) and classes (C1, C2) to show constructor injection.
    // loader class takes an instance of IEmp through its constructor.
    /*
    public interface IEmp
    {
        void Print();
    }
    public class C1 : IEmp
    {
        public void Print()
        {
            Console.WriteLine("Class C1 ");
        }
    }

    public class C2 : IEmp
    {
        public void Print()
        {
            Console.WriteLine("Class C2");
        }
    }
    //Create instance of IEmp
    public class Loader
    {
        private IEmp _emp;
        public Loader(IEmp emp)
        {
            _emp = emp;
        }
        public void Print()
        {
            _emp.Print();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            C1 o1 = new C1();
            Loader l = new Loader(o1);
            l.Print();

            C2 o2 = new C2();
            //passing the dependency from o2 to l
            l = new Loader(o2);
            l.Print();

            Console.ReadKey();
        }

    }
    */

    #endregion


    #region Method injection
    // uses interfaces (IClass) and classes (C1, C2) to show method injection.
    // The C3 class takes an instance of IClass as an argument in its method.
    /*
    public interface IClass
    {
        void Print();
    }

    class C1:IClass
    {
        public void Print() {
            Console.WriteLine("Hello Class C1");
        }
    }

    class C2 : IClass
    {
        public void Print()
        {
            Console.WriteLine("Hello Class C2");
        }
    }


    //instance of interface
    public class C3
    {
        //private IClass _classobj;
        public void Print(IClass classobj)
        {
            classobj.Print();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            C1 c1 = new C1();
            C2 c2 = new C2();

            C3 c3 = new C3();
            c3.Print(c1);

            c3.Print(c2);

            Console.ReadKey();
        }
    }

    */
    #endregion


    #region Property Injection
    //C3 class has a property called obj, which is set to an instance of IntClass,
    //which allows for property-based dependency injection.
    /*
    public interface IntClass
    {
        void Print();
    }

    public class C1 : IntClass
    {
        public void Print() {
            Console.WriteLine("Class 1 says hello");
        }
    }

    public class C2 : IntClass
    {

        public void Print()
        {
            Console.WriteLine("Class 2 says hello");
        }
    }

    public class C3
    {
        private IntClass _obj;
        public IntClass obj
        {
            set { _obj = value; }
        }
        public void Print()
        {
            _obj.Print();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            C3 c3 = new C3();


            C1 c1 = new C1();
            c3.obj = c1;
            c3.Print();

            C2 c2 = new C2();
            c3.obj = c2;
            c3.Print();

            Console.ReadKey();
        }
    }


    */
    #endregion

    #region interface injection
    //interfaces (Iclass and Iclass2) and classes (Service and Independency) to showcase interface-based dependency injection.
    //Independency class takes an instance of Iclass through its Client method.
    public interface Iclass
    {
        string Print();
    }

    public class Service : Iclass
    {

        public string Print() {

            return "hello from service";
        }
    }

    interface Iclass2
    {
        void Client(Iclass sub);
    }
    public class Independency : Iclass2
    {
        Iclass _sub;
        public void Client(Iclass sub)
        {
            _sub = sub;
            Console.WriteLine(_sub.Print());
        }
    }

    internal class Program
    {
        public static void Main() {
        Independency inA = new Independency();
        Service servo = new Service();
            inA.Client(servo);

            Console.ReadLine();
        }
    }




    #endregion




}
