using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algebra
{
    public class Variable
    {
        private float _value;
        private string _name;
        public Variable(string name, float value)
        {
            _name = name;
            _value = value;
        }

        public string Name
        {
            get { return _name; }
        }

        public float Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
