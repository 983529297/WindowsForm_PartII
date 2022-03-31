using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public interface IGraphics
    {
        //清空
        void ClearAll();
        //畫線
        void DrawLine(double x1, double y1, double x2, double y2);

        //畫線
        void DrawLineShape(double x1, double y1, double x2, double y2);
        //化矩形
        void DrawRectangle(double x1, double y1, double x2, double y2);

        //化矩形
        void DrawRectangleShape(double x1, double y1, double x2, double y2);

        //畫橢圓
        void DrawEllipse(double x1, double y1, double x2, double y2);

        //畫橢圓
        void DrawEllipseShape(double x1, double y1, double x2, double y2);
    }
}