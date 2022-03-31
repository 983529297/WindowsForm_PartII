using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class PointerState : State
    {
        CommandManager _commandManager;

        public PointerState(CommandManager commandManager)
        {
            _commandManager = commandManager;
        }

        //call
        public override void CallCommand(Model model, Shape hint, bool check)
        {

        }
    }
}
