using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Program
    {
        
        static void Main(string[] args)
        {

            #region List
            /*
            //lists are dynamically assigned
            //using System.Collections.Generic 


            //create list of type string named car 
            //parameter inside (....) are used to initialize the list car 
            
            List<string> car = new List<string>();

            // add element in list
            car.Add("Ford");
            car.Add("Suzuki");
            car.Add("car3");
            car.Add("Ford");

            //insert in index no () element (...) 
            car.Insert(2, "Car 4");

            //find if list car contains element(...) returns boolean type
            bool containsFord = car.Contains("Ford");
            Console.WriteLine("the list contains Ford is: "+containsFord);

            //sort element of list in ascending order
            car.Sort(); 

            //sort element of list in descending order
            car.Reverse();

            //clear all element of list
            //car.Clear();

            //convert list to array
            string[] cararray = car.ToArray();

            Console.WriteLine(cararray.Length);
            foreach (var item in cararray)

            {

                Console.WriteLine(item);
            }
            Console.WriteLine(car.Count());
            Console.WriteLine(car.IndexOf("Ford"));

            Console.WriteLine(car.LastIndexOf("Ford"));

            */
            #endregion

            #region Dictionary

            /*
            // can store any type of data
            // Keys must be unique and cannot be null.
            //Values can be null or duplicate.
            //values are accessed by dictionaryname[key]

            //using System.Collections.Generic - header is required to use them

            Dictionary<string,int> items = new Dictionary<string,int>();

            items.Add("soap", 500);
            items.Add("hat", 1000);
            items.Add("bat", 1500);

            //to update the value
            items["bat"]=2000;

            //to remove items of the list
            //items.Clear();

            Console.WriteLine("dictionary contains bat: "+ items.ContainsKey("bat"));

            foreach (KeyValuePair<string, int> item in items)
            {
                //Console.WriteLine(item);

                Console.WriteLine("Key: {0}  ,Value: {1}", item.Key, item.Value);
            }


            */
            #endregion

            #region Set
            /*
            HashSet<string> newset = new HashSet<string>();
            no duplicate
            newset.Add("hello world");
            newset.Add("lorem");
            newset.Add("lorem2");
            Console.WriteLine(newset.Contains("lorem"));

            foreach (var item in newset)
            {
                Console.WriteLine(item);
            }
            */
            #endregion

            List<dynamic> list = new List<dynamic>();

            list.Add(1);
            list.Add(2);
            list.Add("Ramesh");
            string[] arr = { "c", "res" };
            list.Add(arr);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Dictionary<dynamic,dynamic> dict = new Dictionary<dynamic,dynamic>();
            dict.Add(1, 2);
            dict.Add(2, "Ram");
            dict.Add(3, arr);

            foreach (var item in dict)
            {
                Console.WriteLine(item);
            }


            Console.ReadKey();
        }
    }
}
