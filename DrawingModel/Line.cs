using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Line : Shape
    {
        //double _x1;
        //double _y1;
        //double _x2;
        //double _y2;
        const int TWO = 2;
        const int THREE = 3;
        Model _model;
        public Line(Model model)
        {
            _model = model;
        }
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

        //設定左上
        public override void SetLeftUp(double x1, double y1)
        {
            double[] set = _model.CheckLinePress((float)x1, (float)y1);
            if (set.Length == 0)
                _model._isPressed = false;
            else
            {
                SetPosition(set);
                //this._x1 = (set[0] + set[TWO]) / TWO;
                //this._y1 = (set[1] + set[THREE]) / TWO;
            }
        }

        //function
        private void SetPosition(double[] set)
        {
            this._x1 = (set[0] + set[TWO]) / TWO;
            this._y1 = (set[1] + set[THREE]) / TWO;
        }

        //function
        private void SetPositionTwo(double[] set)
        {
            this._x2 = (set[0] + set[TWO]) / TWO;
            this._y2 = (set[1] + set[THREE]) / TWO;
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
            double[] set = _model.CheckLinePress((float)_x2, (float)_y2);
            if (!(set.Length == 0))
            {
                CallCommandSecond();
                //_model.CallCommand();
                SetPositionTwo(set);
                //this._x2 = (set[0] + set[TWO]) / TWO;
                //this._y2 = (set[1] + set[THREE]) / TWO;
            }    
        }

        //function
        private void CallCommandSecond()
        {
            _model.CallCommand();
        }

        //畫圖
        public override void Drawed(IGraphics graphics)
        {
            //_model._line.Add(this);
            //if (_model._isPressed)
            graphics.DrawLine(_x1, _y1, _x2, _y2);
        }

        //draw
        public override void DrawLine(IGraphics graphics)
        {
        }

        //畫圖
        public override void DrawShape(IGraphics graphics)
        {
            graphics.DrawLineShape(_x1, _y1, _x2, _y2);
        }

        //產生新的
        public override Shape CreateNew()
        {
            Line item = new Line(_model);
            return item;
        }

        //產生新的
        public override Shape Copy()
        {
            Line item = new Line(_model);
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
        public override bool CheckType()
        {
            return false;
        }

        //move
        public override void Move(float first, float second)
        {
            if (GetMovedCheck() != this)
            {
                if (GetMovedCheck().CheckContain((float)_x1, (float)_y1))
                {
                    _x1 = _x1 + first;
                    _y1 = _y1 + second;
                }
                else
                {
                    _x2 = _x2 + first;
                    _y2 = _y2 + second;
                }
            }
        }

        //move
        private Shape GetMovedCheck()
        {
            return _model._moved;
        }
    }
}
