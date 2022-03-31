using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class DrawCommand : ICommand
    {
        Shape _item;
        Model _model;
        bool _mode;
        double _moveX;
        double _moveY;

        public DrawCommand(Model model, Shape item, bool mode)
        {
            _item = item;
            _model = model;
            _mode = mode;
        }

        //do
        public void SetMove(double first, double second)
        {
            _moveX = first;
            _moveY = second;
        }

        //redo
        public void Execute()
        {
            if (!_mode)
                _model.DrawShape(_item);
            else
                _model.MovePosition(_item, _moveX, _moveY);
        }

        //undo
        public void DoNoExecute()
        {
            if (!_mode)
                _model.DeleteShape();
            else
                _model.MovePosition(_item, (-_moveX), (-_moveY));
        }
    }
}
