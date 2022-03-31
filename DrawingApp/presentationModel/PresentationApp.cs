using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.presentationModel
{
    public class PresentationApp
    {
        public bool IsRectangle
        {
            get; set;
        }
        public bool IsEllipse
        {
            get; set;
        }
        public bool IsLine
        {
            get; set;
        }
        public bool Draw
        {
            get; set;
        }

        public PresentationApp()
        {
            Draw = false;
        }

        //change
        public void IsRectangleFalse()
        {
            IsEllipse = true;
            IsRectangle = false;
            IsLine = true;
        }

        //change
        public void IsEllipseFalse()
        {
            IsEllipse = false;
            IsLine = true;
            IsRectangle = true;
        }

        //change
        public void IsLineFalse()
        {
            IsEllipse = true;
            IsRectangle = true;
            IsLine = false;
        }

        //change
        public void IsAllTrue()
        {
            IsEllipse = true;
            IsLine = true;
            IsRectangle = true;
        }
    }
}
