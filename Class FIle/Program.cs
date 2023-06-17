using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Class_FIle
{
    //load file members.txt
    //parse id firstname lastname state zip 
    //list creation (contains repetation of data)
    //dictionary creation with key as firstname  and items of Members type  asvalue
    //new list from dictionary value
    //write to csv
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
                //Console.WriteLine("member object created");
                this.id = id;
                this.firstname = firstname;
                this.lastname = lastname;
                this.address = address;
                this.city = city;
                this.state = state;
                this.zip = zip;
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
            List<Member> memberlist = new List<Member>();
            Dictionary<string, Member> memberDictionary = new Dictionary<string, Member>();
            List<Member> validMembersList = new List<Member>();





            public Readfile(string path)
            {
                string line;
                string id, firstname, lastname, address, city, state, zip;
                Member obj;

                using (StreamReader sr = new StreamReader(path))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        line = line.Trim();

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

                        obj = new Member(id, firstname, lastname, address, city, state, zip);
                        memberlist.Add(obj);
                        //object created
                    }
                }
                //getValidMembers(memberlist);
                #region eliminate duplicate 
                //to remove duplicate entry of memberlist
                foreach (var item in memberlist)
                {
                    if (memberDictionary.ContainsKey(item.firstname))
                    {
                        Console.WriteLine("item repeated");
                        memberDictionary[item.firstname] = item;
                    }
                    else
                    {
                    memberDictionary.Add(item.firstname, item);
                    }
                }

                Console.WriteLine(memberDictionary.Count);


                foreach (var item in memberDictionary)
                {
                    //Console.WriteLine(item.Key);
                    //Console.WriteLine(item.Value.firstname);
                    validMembersList.Add(item.Value);
                }


                WriteFile(validMembersList);


                #endregion
            }



            public void WriteFile(List<Member> validmemberlist)
            {
                foreach (var item in validmemberlist)
                {
                    var id = item.id;
                    var firstname = item.firstname;
                    var lastname = item.lastname;
                    var address = item.address;
                    var city = item.city;
                    var state = item.state;
                    var zip = item.zip;
                    
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

        }
        static void Main(string[] args)
        {
            string path = @"C:\Users\amritbista\source\repos\Class FIle\Members.txt";
            Readfile objR = new Readfile(path);
            Console.ReadKey();
        }
    }
}
