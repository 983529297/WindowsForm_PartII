using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class SimpleFactory
    {
        Model _model;

        public SimpleFactory(Model model)
        {
            _model = model;
        }

        //create
        public Shape CreateShape(int item)
        {
            if (item == 0)
                return new Rectangle(_model);
            else if (item == 1)
                return new Ellipse(_model);
            else
                return new Line(_model);
        }
    }
}
