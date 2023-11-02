using Constructor_Injection.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor_Injection.Implementation
{
    public class OperatorClass
    {
        private IMETHOD method;
        public OperatorClass(IMETHOD method)
        { this.method = method; }
        public void Get()
        {
            method.Get();
        }
    }
}
