using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace File_Function
{
    internal class Program
    {
        public List<string> ReturnNonRepeatedLine(string path)
        {
            string line;
            List<string> listofnonrepeatedmember = new List<string>();
            using (StreamReader sr = new StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string line1 = line.Trim();
                    if (listofnonrepeatedmember.Contains(line1))
                    {
                        Console.WriteLine("line repeated");
                    }
                    else
                    {
                        listofnonrepeatedmember.Add(line1);
                    }
                }
            }
            return listofnonrepeatedmember;
        }
        public Dictionary<string, string> ReturnDictionary(List<string> listofnonrepeatedmember)
        {
            Dictionary<string, string> stateDictionary = new Dictionary<string, string>();
            foreach (var item in listofnonrepeatedmember)
            {
                string state = item.Substring(112, 4);

                if (!stateDictionary.ContainsKey(state))
                {
                    stateDictionary.Add(state, item);
                }
                else
                {
                    stateDictionary[state] = stateDictionary[state] + "\n" + item;
                }
            }
            return stateDictionary;
        }

        public void SaveRecord(Dictionary<string, string> stateDictionary)
        {
            foreach (var item in stateDictionary)
            {
                if (!File.Exists(item.Key + ".csv"))
                {
                    FileStream fileStream = File.Create((item.Key + ".csv"));
                    Console.WriteLine(item.Key + "file created");
                    fileStream.Close();
                }

                //Console.WriteLine(item.Key);

                //Console.WriteLine(item.Value.GetType());
                string[] record = item.Value.Split('\n');

                foreach (var lineElement in record)
                {

                    Console.WriteLine(lineElement);

                    //parse from item.value

                    string id = lineElement.Substring(0, 12);
                    //Console.WriteLine(id);

                    string lastname = lineElement.Substring(12, 25);
                    //Console.WriteLine(lastname);

                    string firstname = lineElement.Substring(37, 25);
                    //Console.WriteLine(firstname);

                    string address = lineElement.Substring(62, 30);
                    //Console.WriteLine(address);

                    string city = lineElement.Substring(92, 20);
                    //Console.WriteLine(city);

                    string state = lineElement.Substring(112, 4);
                    //Console.WriteLine(state);

                    string zip = lineElement.Substring(116, 5);
                    //Console.WriteLine(zip);

                    using (StreamWriter sw = new StreamWriter((state + ".csv"), true))
                    {
                        sw.WriteLine(id + ", " + firstname + ", " + lastname + ", " + address + ", " + city + ", " + zip);
                        sw.Close();
                    }
                }

                //Console.WriteLine(item.Key);
                //Console.WriteLine(item.Value);

            }
            Console.WriteLine("save record");

        }


        public static void Main(string[] args)
        {
            string path = @"C:\Users\amritbista\source\repos\File Function\Members.txt";

            Program program = new Program(); // Creating Object

            List<string> listofnonrepeateditem = new List<string>();
            listofnonrepeateditem = program.ReturnNonRepeatedLine(path);

            Dictionary<string, string> stateDictionary = new Dictionary<string, string>();
            stateDictionary = program.ReturnDictionary(listofnonrepeateditem);

            program.SaveRecord(stateDictionary);
            Console.ReadLine();
        }
    }
}
