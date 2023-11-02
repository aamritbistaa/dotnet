using Class_interface.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_interface.Implementation
{
    internal class ClassWrite : ClassGetValid, IWrite
    {
        public void Write(List<ClassMember> validMemberList)
        {
            foreach (var item in validMemberList)
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
            }
        }
    }
}
