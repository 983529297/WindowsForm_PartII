using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    interface ICommand
    {
        //redo
        void Execute();
        //undo
        void DoNoExecute();
        //do
        void SetMove(double first, double second);
        //clear
        //void Clear();
    }
}
