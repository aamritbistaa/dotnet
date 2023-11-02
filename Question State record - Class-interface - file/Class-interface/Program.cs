using Class_interface.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_interface
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string path = @"C:\Users\amritbista\source\repos\Class FIle\Members.txt";

            //Get all member list
            //List<ClassMember> memberlist = new List<ClassMember>();
            //ClassRead Readobj = new ClassRead();
            //memberlist = Readobj.Read(path);

            //Get Valid member list
            //List<ClassMember> validMemberList = new List<ClassMember>();
            //ClassGetValid validobj = new ClassGetValid();
            //validMemberList = validobj.GetValid(memberlist);

            //write files
            //ClassWrite Writeobj = new ClassWrite();
            //Writeobj.Write(validMemberList);

            //Writeobj.Write(validobj.GetValid(Readobj.Read(path)));

            ClassWrite obj=new ClassWrite();
            obj.Write(obj.GetValid(obj.Read(path)));
                      
            Console.ReadKey();
        }
    }
}
