using Class_interface.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Class_interface.Implementation
{
    internal class ClassRead:IRead
    {
        public ClassRead() {
            Console.WriteLine("Read class object created");
        }
        public List<ClassMember> Read(string path) 
        {
            List<ClassMember> memberlist = new List<ClassMember>();

            string line;
            string id, firstname, lastname, address, city, state, zip;
            ClassMember obj;

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

                    obj = new ClassMember(id, firstname, lastname, address, city, state, zip);
                    memberlist.Add(obj);
                    //object created
                }
            }
            return memberlist;
        }
    }
}