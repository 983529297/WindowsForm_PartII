using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class DrawingState : State
    {
        CommandManager _commandManager;
        public DrawingState(CommandManager commandManager)
        {
            _commandManager = commandManager;
        }

        //call
        public override void CallCommand(Model model, Shape hint, bool check)
        {
            _commandManager.Execute(new DrawCommand(model, hint, false));
        }

    }
}
