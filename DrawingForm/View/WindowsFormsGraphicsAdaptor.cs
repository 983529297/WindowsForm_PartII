using DrawingModel;
using System.Drawing;

namespace DrawingForm.PresentationModel
{
    class WindowsFormsGraphicsAdaptor : IGraphics
    {
        Graphics _graphics;
        const float FIVE = 5;
        const float TWO = 2.5f;

        public WindowsFormsGraphicsAdaptor(Graphics graphics)
        {
            this._graphics = graphics;
        }

        //清除
        public void ClearAll()
        {
            // OnPaint時會自動清除畫面，因此不需實作
        }

        //畫線
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        //畫線
        public void DrawLineShape(double x1, double y1, double x2, double y2)
        {
            if (x2 - x1 < 0)
            {
                double set = x1;
                x1 = x2;
                x2 = set;
            }
            if (y2 - y1 < 0)
            {
                double set = y1;
                y1 = y2;
                y2 = set;
            }
            DrawCircleShape(x1, x2, y1, y2);
        }

        //畫矩形
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            if (x2 - x1 < 0)
            {
                double set = x1;
                x1 = x2;
                x2 = set;
            }
            if (y2 - y1 < 0)
            {
                double set = y1;
                y1 = y2;
                y2 = set;
            }
            SolidBrush mySolidBrush = new SolidBrush(Color.White);
            _graphics.FillRectangle(mySolidBrush, (float)x1, (float)y1, (float)(x2 - x1), (float)(y2 - y1));
            _graphics.DrawRectangle(Pens.Black, (float)x1, (float)y1, (float)(x2 - x1), (float)(y2 - y1));
        }

        //畫矩形
        public void DrawRectangleShape(double x1, double y1, double x2, double y2)
        {
            if (x2 - x1 < 0)
            {
                double set = x1;
                x1 = x2;
                x2 = set;
            }
            if (y2 - y1 < 0)
            {
                double set = y1;
                y1 = y2;
                y2 = set;
            }
            DrawCircleShape(x1, x2, y1, y2);
        }

        //畫橢圓
        public void DrawEllipse(double x1, double y1, double x2, double y2)
        {
            SolidBrush mySolidBrush = new SolidBrush(Color.AliceBlue);
            _graphics.FillEllipse(mySolidBrush, (float)x1, (float)y1, (float)(x2 - x1), (float)(y2 - y1));
            _graphics.DrawEllipse(Pens.Black, (float)x1, (float)y1, (float)(x2 - x1), (float)(y2 - y1));
        }

        //畫橢圓
        public void DrawEllipseShape(double x1, double y1, double x2, double y2)
        {
            if (x2 - x1 < 0)
            {
                double set = x1;
                x1 = x2;
                x2 = set;
            }
            if (y2 - y1 < 0)
            {
                double set = y1;
                y1 = y2;
                y2 = set;
            }
            DrawCircleShape(x1, x2, y1, y2);
        }

        //座標
        private void DrawCircleShape(double x1, double x2, double y1, double y2)
        {
            Pen pen = new Pen(Color.Red);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            _graphics.DrawRectangle(pen, (float)x1, (float)y1, (float)(x2 - x1), (float)(y2 - y1));

            SolidBrush mySolidBrush = new SolidBrush(Color.White);
            _graphics.FillEllipse(mySolidBrush, (float)x1 - TWO, (float)y1 - TWO, (float)(FIVE), (float)(FIVE));
            _graphics.DrawEllipse(Pens.Black, (float)x1 - TWO, (float)y1 - TWO, (float)(FIVE), (float)(FIVE));
            _graphics.FillEllipse(mySolidBrush, (float)x2 - TWO, (float)y2 - TWO, (float)(FIVE), (float)(FIVE));
            _graphics.DrawEllipse(Pens.Black, (float)x2 - TWO, (float)y2 - TWO, (float)(FIVE), (float)(FIVE));
            _graphics.FillEllipse(mySolidBrush, (float)x1 - TWO, (float)y2 - TWO, (float)(FIVE), (float)(FIVE));
            _graphics.DrawEllipse(Pens.Black, (float)x1 - TWO, (float)y2 - TWO, (float)(FIVE), (float)(FIVE));
            _graphics.FillEllipse(mySolidBrush, (float)x2 - TWO, (float)y1 - TWO, (float)(FIVE), (float)(FIVE));
            _graphics.DrawEllipse(Pens.Black, (float)x2 - TWO, (float)y1 - TWO, (float)(FIVE), (float)(FIVE));
        }
    }
}
