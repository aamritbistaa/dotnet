using Class_interface.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_interface.Implementation
{
    internal class ClassGetValid: ClassRead, Ivalid
    {
        public List<ClassMember> GetValid(List<ClassMember> memberlist) {
            Console.WriteLine("Get valid member list");
            List<ClassMember> validMemberList = new List<ClassMember>();

            foreach (var item in memberlist)
            {
             
                if (validMemberList.Count == 0)
                {
                    validMemberList.Add(item);
                }
                else
                {
                    bool containsitem1 = false;

                    foreach (var item1 in validMemberList)
                    {
                        if (item1.firstname == item.firstname)
                        {
                            containsitem1 = true;
                            item.id = item1.id;
                            item.firstname = item1.firstname;
                            item.lastname = item1.lastname;
                            item.address = item1.address;
                            item.city = item1.city;
                            item.state = item1.state;
                            item.zip = item1.zip;

                            Console.WriteLine("list contains item");
                        }
                    }

                    if (containsitem1 == false)
                    {
                        validMemberList.Add(item);
                    }
                }
            }
            return validMemberList;
        }
    }
}
