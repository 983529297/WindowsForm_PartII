using DrawingModel;
using System;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace DrawingApp.View
{
    // Windows Store App的繪圖方式採用"物件"模型(與Windows Forms完全不同)
    // 當繪圖時，必須先建立"圖形物件"，再將"圖形物件"加入畫布的Children，此後該圖形就會被畫出來
    // 由於畫布管理其Children，因此有以下優缺點
    //   優點：畫布可以自行處理OnPaint()，而使用者則省掉處理OnPaint()的麻煩
    //   缺點：繪圖時必須先建立"圖形物件"；清除某圖形時，必須刪除Children中對應的物件
    class WindowsStoreGraphicsAdaptor : IGraphics
    {
        Canvas _canvas;
        double _x1;
        double _x2;
        double _y1;
        double _y2;
        const float TWO = 2.5f;
        const float SEVEN = 7;
        const float FIVE = 3;

        public WindowsStoreGraphicsAdaptor(Canvas canvas)
        {
            this._canvas = canvas;
        }

        //清除
        public void ClearAll()
        {
            // 清除Children也就清除畫布
            _canvas.Children.Clear();
        }

        //畫線
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            // 先建立圖形物件
            Windows.UI.Xaml.Shapes.Line line = new Windows.UI.Xaml.Shapes.Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.Stroke = new SolidColorBrush(Colors.Black);
            // 將圖形物件加入Children
            _canvas.Children.Add(line);
        }

        //畫線
        public void DrawLineShape(double x1, double y1, double x2, double y2)
        {
            /*
            // 先建立圖形物件
            Windows.UI.Xaml.Shapes.Line line = new Windows.UI.Xaml.Shapes.Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.Stroke = new SolidColorBrush(Colors.Red);
            // 將圖形物件加入Children
            _canvas.Children.Add(line);
            DrawCircleShape(x1, y1);
            DrawCircleShape(x2, y2);*/
            DrawShape(x1, y1, x2, y2);
        }

        //畫矩形
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            Windows.UI.Xaml.Shapes.Rectangle rectangle = new Windows.UI.Xaml.Shapes.Rectangle();
            ChangePosition(x1, y1, x2, y2);
            rectangle.Height = this._y2 - this._y1;
            rectangle.Width = this._x2 - this._x1;
            rectangle.Stroke = new SolidColorBrush(Colors.Black);
            rectangle.Fill = new SolidColorBrush(Colors.Pink);
            Canvas.SetLeft(rectangle, this._x1);
            Canvas.SetTop(rectangle, this._y1);
            _canvas.Children.Add(rectangle);
        }

        //畫矩形
        public void DrawRectangleShape(double x1, double y1, double x2, double y2)
        {
            DrawShape(x1, y1, x2, y2);
        }

        //畫橢圓
        public void DrawEllipse(double x1, double y1, double x2, double y2)
        {
            Windows.UI.Xaml.Shapes.Ellipse ellipse = new Windows.UI.Xaml.Shapes.Ellipse();
            ChangePosition(x1, y1, x2, y2);
            ellipse.Height = this._y2 - this._y1;
            ellipse.Width = this._x2 - this._x1;
            ellipse.Stroke = new SolidColorBrush(Colors.Black);
            ellipse.Fill = new SolidColorBrush(Colors.Wheat);
            Canvas.SetLeft(ellipse, this._x1);
            Canvas.SetTop(ellipse, this._y1);
            _canvas.Children.Add(ellipse);
        }

        //畫橢圓
        public void DrawEllipseShape(double x1, double y1, double x2, double y2)
        {
            DrawShape(x1, y1, x2, y2);
        }

        //比較
        private void ChangePosition(double x1, double y1, double x2, double y2)
        {
            this._x1 = x1;
            this._x2 = x2;
            this._y1 = y1;
            this._y2 = y2;
            if (x2 - x1 < 0)
            {
                this._x1 = x2;
                this._x2 = x1;
            }
            if (y2 - y1 < 0)
            {
                this._y1 = y2;
                this._y2 = y1;
            }
        }

        //shape
        private void DrawShape(double x1, double y1, double x2, double y2)
        {
            Windows.UI.Xaml.Shapes.Rectangle rectangle = new Windows.UI.Xaml.Shapes.Rectangle();
            ChangePosition(x1, y1, x2, y2);
            rectangle.Height = this._y2 - this._y1;
            rectangle.Width = this._x2 - this._x1;
            rectangle.Stroke = new SolidColorBrush(Colors.Red);
            rectangle.StrokeThickness = FIVE;
            rectangle.StrokeDashArray = new DoubleCollection()
            {
                FIVE
            };
            Canvas.SetLeft(rectangle, this._x1);
            Canvas.SetTop(rectangle, this._y1);
            _canvas.Children.Add(rectangle);
            DrawCircleShape(_x1, _y1);
            DrawCircleShape(_x2, _y2);
            DrawCircleShape(_x2, _y1);
            DrawCircleShape(_x1, _y2);
        }

        //座標
        private void DrawCircleShape(double x1, double y1)
        {
            Windows.UI.Xaml.Shapes.Ellipse ellipse = new Windows.UI.Xaml.Shapes.Ellipse();
            ellipse.Height = SEVEN;
            ellipse.Width = SEVEN;
            ellipse.Stroke = new SolidColorBrush(Colors.Black);
            ellipse.Fill = new SolidColorBrush(Colors.Wheat);
            Canvas.SetLeft(ellipse, x1 - TWO);
            Canvas.SetTop(ellipse, y1 - TWO);
            _canvas.Children.Add(ellipse);
        }
    }
}