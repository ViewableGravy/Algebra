using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algebra
{
    public class AllVariables
    {
        public List<Variable> _variables = new List<Variable>();
        public AllVariables()
        {

        }

        public void CreateVariable(string name, float val)
        {
            Variable newVar = new Variable(name,val);
            _variables.Add(newVar);
        }
    }
}
