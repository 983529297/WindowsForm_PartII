using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class DrawingLineState : State
    {
        CommandManager _commandManager;
        public DrawingLineState(CommandManager commandManager)
        {
            _commandManager = commandManager;
        }

        //call
        public override void CallCommand(Model model, Shape hint, bool check)
        {
            if (check)//(check && model._moveX != 0 && model._moveY != 0)
            {
                _commandManager.ExecuteMove(new DrawCommand(model, model._moved, true), model._moveX, model._moveY);
                model._moveX = 0;
                model._moveY = 0;
            }
        }
    }
}
