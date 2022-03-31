using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public abstract class Shape
    {
        //設定左上
        public abstract void SetLeftUp(double x1, double y1);

        //設定右下
        public abstract void SetRightDown(double x2, double y2);

        //畫圖
        public abstract void Drawed(IGraphics graphics);

        //畫圖
        public abstract void DrawLine(IGraphics graphics);

        //畫圖
        public abstract void DrawShape(IGraphics graphics);

        //座標
        public abstract double[] GetPosition();

        //產生新的
        public abstract Shape CreateNew();

        //產生新的
        public abstract Shape Copy();

        //存在
        public abstract bool CheckContain(float first, float second);

        //cmd
        public abstract void CallCommand();

        //move
        public abstract void Move(float first, float second);

        //move
        public abstract bool CheckType();
    }
}
