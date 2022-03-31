using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public abstract class State
    {
        //call
        public abstract void CallCommand(Model model, Shape hint, bool check);
    }
}
