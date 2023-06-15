    using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Class_FIle
{
    internal class Program
    {
        class Member
        {
            public string id { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
            public string address { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string zip { get; set; }

            public Member(string id, string firstname, string lastname, string address, string city, string state, string zip)
            {
                Console.WriteLine("member object created");
                this.id = id;
                this.firstname = firstname;
                this.lastname = lastname;    
                this.address = address;
                this.city = city;
                this.state = state;
                this.zip = zip;
                WriteFile();
            }


            public void WriteFile()
            {
                //Console.WriteLine(id+ firstname+ lastname+ address+ city+ state+ zip);
                if (!File.Exists(state + ".csv"))
                {
                    FileStream fileStream = File.Create((state + ".csv"));
                    Console.WriteLine(state + "file created");
                    fileStream.Close();
                }
                using (StreamWriter sw = new StreamWriter((state + ".csv"), true))
                {
                    sw.WriteLine(id + ", " + firstname + ", " + lastname + ", " + address + ", " + city + ", " + zip);
                    sw.Close();
                }
                //check if file exist
                //check state of each object (this.state)
                //open that state file 
                //write the content
                //(id,firstname,lastname,address,city,state,zip)

            }

        }


       
    class Readfile
        {
            //List<Member> memberlist = new List<Member>();
            List<Array> memberlist = new List<Array>();
            public Readfile(string path) {

                Console.WriteLine("constructor read file elements");
                string line;
                string id,firstname,lastname,address,city,state,zip;

                Member obj;

                using (StreamReader sr = new StreamReader(path))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        line = line.Trim();
                        //Console.WriteLine(line);

                        //id
                        id = line.Substring(0, 12).Trim();
                        id = id.Trim();
                        //Console.WriteLine(id);

                        //lastname
                        lastname = line.Substring(12, 25);
                        lastname = lastname.Trim();
                        //Console.WriteLine(lastname);

                        //firstname
                        firstname = line.Substring(27, 25);
                        firstname = firstname.Trim();
                        //Console.WriteLine(firstname);

                        //address
                        address = line.Substring(52, 30);
                        address = address.Trim();
                        //Console.WriteLine(address);

                        //city
                        city = line.Substring(82, 20).Trim();
                        city = city.Trim();
                        //Console.WriteLine(city);

                        //state
                        state = line.Substring(112, 4);
                        state = state.Trim();
                        //Console.WriteLine(state);

                        //zip
                        zip = line.Substring(116, 5);
                        zip = zip.Trim();
                        //Console.WriteLine(zip);

                        //create object - i number of object - dynamic type of array[list]
                        //initialize each object with (id,lastname,firstname,address,city,state,zip)

                        string[] memberlistitem = {id,lastname,firstname,address,city,state,zip };


                        memberlist.Add(memberlistitem);
                        //obj = new Member(id, firstname,lastname,address, city, state,zip);
                        //object created
                        //memberlist.Add(obj);
                    }
                }

                //to remove duplicate entry of memberlist

                Console.WriteLine(memberlist.Distinct().ToList());

                foreach (Array item in memberlist)
                {
                    Console.WriteLine(item.GetValue(0));

                    foreach (var item1 in item)
                    {
                        Console.WriteLine(item1);
                    }


                }

            }
        }
        static void Main(string[] args)
        {
            string path = @"C:\Users\amritbista\source\repos\Class FIle\Members.txt";

            Readfile objR = new Readfile(path);
            

            Console.ReadKey();
        }
    }
}
