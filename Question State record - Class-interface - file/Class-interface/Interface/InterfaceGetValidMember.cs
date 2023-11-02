using Class_interface.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_interface.Interface
{
    interface Ivalid
    {
        List<ClassMember> GetValid(List<ClassMember> memberlist);
    }
}