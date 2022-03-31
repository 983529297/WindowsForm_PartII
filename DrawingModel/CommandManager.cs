using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class CommandManager
    {
        Stack<ICommand> _undo = new Stack<ICommand>();
        Stack<ICommand> _redo = new Stack<ICommand>();
        const string SET1 = "Cannot Undo exception\n";
        const string SET2 = "Cannot Redo exception\n";
        //double _movedX;
        //double _movedY;
        //do
        public void Execute(ICommand command)
        {
            command.Execute();
            _undo.Push(command);
            _redo.Clear();
        }

        //do
        public void ExecuteMove(ICommand command, double moveX, double moveY)
        {
            command.Execute();
            command.SetMove(moveX, moveY);
            //_movedX = moveX;
            //_movedY = moveY;
            _undo.Push(command);
            _redo.Clear();
        }

        //undo
        public void Undo()
        {
            if (_undo.Count <= 0)
                throw new Exception(SET1);
            ICommand command = _undo.Pop();
            _redo.Push(command);
            command.DoNoExecute();
        }

        //redo
        public void Redo()
        {
            if (_redo.Count <= 0)
                throw new Exception(SET2);
            ICommand command = _redo.Pop();
            _undo.Push(command);
            command.Execute();
        }

        //clear
        public void Clear()
        {
            _undo.Clear();
            _redo.Clear();
        }

        public bool IsRedoEnabled
        {
            get
            {
                return _redo.Count != 0;
            }
        }

        public bool IsUndoEnabled
        {
            get
            {
                return _undo.Count != 0;
            }
        }
    }
}
