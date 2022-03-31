using System.Collections.Generic;

namespace DrawingModel
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        const string OPERATOR1 = ".";
        const string OPERATOR2 = ",";
        const string OPERATOR3 = "(";
        const string OPERATOR4 = ")";
        const int TWO = 2;
        const int THREE = 3;
        CommandManager _commandManager = new CommandManager();
        List<Shape> _temp = new List<Shape>();
        List<Shape> _moveLine = new List<Shape>();
        Shape _hint;
        double _startPointX;
        double _startPointY;
        double _firstPoint;
        double _secondPoint;
        State _drawing;
        State _drawingLine;
        State _pointer;

        public List<Shape> _lines
        {
            get; set;
        }
        public Shape _moved
        {
            get; set;
        }
        public double _firstPointX
        {
            get;set;
        }
        public double _firstPointY
        {
            get;set;
        }
        public double _moveX
        {
            get; set;
        }
        public double _moveY
        {
            get; set;
        }
        public bool _isPressed
        {
            get; set;
        }

        public List<Shape> _line
        {
            get; set;
        }

        public Model()
        {
            this._lines = new List<Shape>();
            _isPressed = false;
            _line = new List<Shape>();
            _drawing = new DrawingState(_commandManager);
            _drawingLine = new DrawingLineState(_commandManager);
            _pointer = new PointerState(_commandManager);
        }

        //count
        public int GetListNumber()
        {
            return _lines.Count;
        }

        //按下滑鼠
        public void PressdPointer(double first, double second, Shape item)
        {
            if (first > 0 && second > 0)
            {
                _isPressed = true;
                _firstPointX = first;
                _firstPointY = second;
                item.SetLeftUp(_firstPointX, _firstPointY);
                _hint = item;
            }
        }

        //移動滑鼠
        public void MovedPointer(double first, double second, Shape item)
        {
            if (_isPressed)
            {
                item.SetRightDown(first, second);
                _hint = item;
                NotifyModelChanged();
            }
        }

        //放開滑鼠
        public void ReleasedPointer(double first, double second, Shape item)
        {
            if (_isPressed)
            {
                _isPressed = false;
                _hint = item;
                _hint.SetRightDown(first, second);
                _hint.CallCommand();
                NotifyModelChanged();
            }
        }

        //cmd
        public void CallCommand()
        {
            _drawing.CallCommand(this, _hint, false);
        } 

        //清除
        public void Clear()
        {
            _isPressed = false;
            _lines.Clear();
            _commandManager.Clear();
            NotifyModelChanged();
        }

        //畫
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (Shape aLine in _lines)
                aLine.Drawed(graphics);
            foreach (Shape aLine in _line)
                aLine.DrawLine(graphics);
            if (_isPressed)
                _hint.Drawed(graphics);
            foreach (Shape aShape in _temp)
                aShape.DrawShape(graphics);
            _temp.Clear();
            _line.Clear();
        }

        //畫
        public double[] CheckLinePress(float first, float second)
        {
            double[] no = new double[0];
            foreach (Shape aLine in _lines)
                if (aLine.CheckContain(first, second))
                {
                    double[] set = DoGetPosition(aLine);//aLine.GetPosition();
                    return set;
                }
            return no;
        }

        //function
        private double[] DoGetPosition(Shape aLine)
        {
            double[] set = aLine.GetPosition();
            return set;
        }

        //畫
        public string HaveShape(float first, float second)
        {
            string set = "";
            foreach (Shape aLine in _lines)
                if (aLine.CheckContain(first, second))
                {
                    double[] position = DoGetPosition(aLine);//aLine.GetPosition();
                    CreateShape(aLine);
                    set = set + aLine.GetType().ToString().Split(OPERATOR1.ToCharArray())[1] + OPERATOR3 + ((int)position[0]).ToString() + OPERATOR2 + ((int)position[1]).ToString() + OPERATOR2 + ((int)position[TWO]).ToString() + OPERATOR2 + ((int)position[THREE]).ToString() + OPERATOR4;
                }
            NotifyModelChanged();
            return set;
        }

        //check
        public bool CheckShape(float first, float second)
        {
            foreach (Shape aLine in _lines)
                if (aLine.CheckContain(first, second))
                {
                    _moved = aLine;
                    if (IsCheckType(_moved))
                        foreach (Shape Line in _lines)
                            if ((CheckContain(_moved, Line, 0, 1) || CheckContain(_moved, Line, TWO, THREE)) && !IsCheckType(Line))//_moved.CheckContain((float)Line.GetPosition()[0], (float)Line.GetPosition()[1]) || _moved.CheckContain((float)Line.GetPosition()[TWO], (float)Line.GetPosition()[THREE]))
                                _moveLine.Add(Line);
                    return true;
                }
            return false;
        }

        //check
        private bool IsCheckType(Shape item)
        {
            if (item != null)
                return item.CheckType();
            return false;
        }

        //起點
        public void SetFirstPoint(float first, float second)
        {
            _startPointX = first;
            _startPointY = second;
            _firstPoint = first;
            _secondPoint = second;
        }

        //起點
        public void SetPointMoved(float first, float second)
        {
            float moveX = first - (float)_firstPoint;
            float moveY = second - (float)_secondPoint;
            _moved.Move(moveX, moveY);
            foreach (Shape Line in _moveLine)
                Line.Move(moveX, moveY);
            _firstPoint = first;
            _secondPoint = second;
            _moveX = first - _startPointX;
            _moveY = second - _startPointY;
            NotifyModelChanged();
        }

        //move
        public void MovePosition(Shape item, double first, double second)
        {
            foreach (Shape Line in _lines)
                if (CheckContain(item, Line, 0, 1) || CheckContain(item, Line, TWO, THREE))//item.CheckContain(GetPosition(Line, 0), GetPosition(Line, 1)) || item.CheckContain(GetPosition(Line, TWO), GetPosition(Line, THREE)))
                    _moveLine.Add(Line);
            _moved = item;
            foreach (Shape Line in _moveLine)
                Line.Move((float)first, (float)second);
            item.Move((float)first, (float)second);
            _moveLine.Clear();
        }

        //check
        private float GetPosition(Shape item, int number)
        {
            return (float)item.GetPosition()[number];
        }

        //check
        private bool CheckContain(Shape item, Shape line, int first, int second)
        {
            if (item.CheckContain(GetPosition(line, first), GetPosition(line, second)))
                return true;
            else
                return false;
        }

        //cmd
        public void CallCommandMoved()
        {
            _drawingLine.CallCommand(this, _hint, IsCheckType(_moved) && _moveX != 0 && _moveY != 0);
            _moveLine.Clear();
            /*if (IsCheckType(_moved) && _moveX != 0 && _moveY != 0)
            {
                _commandManager.ExecuteMove(new DrawCommand(this, _moved, true), _moveX, _moveY);
                _moveX = 0;
                _moveY = 0;
                _moveLine.Clear();
            }*/
        }

        //畫
        public void CreateShape(Shape item)
        {
            Shape hint = item.CreateNew();
            double[] position = item.GetPosition();
            SetPosition(hint, position);
            _temp.Add(hint);
        }

        //function
        private void SetPosition(Shape hint, double[] position)
        {
            hint.SetLeftUp(position[0], position[1]);
            hint.SetRightDown(position[TWO], position[THREE]);
        }

        //提醒
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }
        
        //畫圖
        public void DrawShape(Shape item)
        {
            _lines.Add(item);
        }

        //刪圖
        public void DeleteShape()
        {
            _lines.RemoveAt(_lines.Count - 1);
        }

        //undo
        public void Undo()
        {
            _commandManager.Undo();
        }

        //redo
        public void Redo()
        {
            _commandManager.Redo();
        }

        public bool IsRedoEnabled
        {
            get
            {
                return _commandManager.IsRedoEnabled;
            }
        }

        public bool IsUndoEnabled
        {
            get
            {
                return _commandManager.IsUndoEnabled;
            }
        }
    }
}
