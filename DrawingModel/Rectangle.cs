using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Rectangle : Shape
    {
        //public double _x1;
        //public double _y1;
        //public double _x2;
        //public double _y2;
        public double _x1
        {
            get; set;
        }
        public double _x2
        {
            get; set;
        }
        public double _y1
        {
            get; set;
        }
        public double _y2
        {
            get; set;
        }

        Model _model;
        public Rectangle(Model model)
        {
            _model = model;
        }

        //設定左上
        public override void SetLeftUp(double x1, double y1)
        {
            this._x1 = x1;
            this._y1 = y1;
        }

        //設定右下
        public override void SetRightDown(double x2, double y2)
        {
            this._x2 = x2;
            this._y2 = y2;
        }

        //callcmd
        public override void CallCommand()
        {
            _model.CallCommand();
        }

        //畫圖
        public override void Drawed(IGraphics graphics)
        {
            //Shape temp = this;
            _model._line.Add(this);
            if (_model._isPressed)
                graphics.DrawRectangle(_x1, _y1, _x2, _y2);
        }

        //draw
        public override void DrawLine(IGraphics graphics)
        {
            graphics.DrawRectangle(_x1, _y1, _x2, _y2);
        }

        //畫圖
        public override void DrawShape(IGraphics graphics)
        {
            graphics.DrawRectangleShape(_x1, _y1, _x2, _y2);
        }

        //產生新的
        public override Shape CreateNew()
        {
            Rectangle item = new Rectangle(_model);
            return item;
        }

        //產生新的
        public override Shape Copy()
        {
            Rectangle item = new Rectangle(_model);
            item.SetLeftUp(_x1, _y1);
            item.SetRightDown(_x2, _y2);
            return item;
        }

        //存在
        public override bool CheckContain(float first, float second)
        {
            if ((first - _x1) * (first - _x2) < 0 && (second - _y1) * (second - _y2) < 0)
                return true;
            else
                return false;
        }

        //存在
        public override double[] GetPosition()
        {
            double[] set = { _x1, _y1, _x2, _y2 };
            return set;
        }

        //move
        public override void Move(float first, float second)
        {
            _x1 = _x1 + first;
            _x2 = _x2 + first;
            _y1 = _y1 + second;
            _y2 = _y2 + second;
        }

        //move
        public override bool CheckType()
        {
            return true;
        }
    }
}
