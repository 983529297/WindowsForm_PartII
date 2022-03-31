using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class PageFunction
    {
        Model _model;
        const string OPERATOR1 = ".";
        const string OPERATOR2 = ",";
        const string OPERATOR3 = "\r\n";
        const int FIVE = 4;
        const string OPERATOR4 = "./";
        const string FILE = "./CSV_test_out.csv";
        const string RECTANGLE = "Rectangle";
        const string ELLIPSE = "Ellipse";
        const int TWO = 2;
        const int THREE = 3;
        const string CONTENT_TYPE = "text/csv";
        const string FOLDER_TYPE = @"application/vnd.google-apps.folder";
        List<Shape> _lines = new List<Shape>();

        public PageFunction(Model model)
        {
            _model = model;
        }

        //save
        public void WriteFile()
        {
            using (FileStream FS_test = new FileStream(FILE, FileMode.Create, FileAccess.ReadWrite))
                using (StreamWriter SW_test2 = new StreamWriter(FS_test))
                {
                    for (int i = 0; i < _model._lines.Count; i = i + 1)
                    {
                        string tmp_s = "";
                        tmp_s = tmp_s + GetLineType(i).Split(OPERATOR1.ToCharArray())[1] + OPERATOR2;
                        for (int j = 0; j < FIVE; j = j + 1)
                            tmp_s = tmp_s + _model._lines[i].GetPosition()[j].ToString() + OPERATOR2;
                        tmp_s = tmp_s + OPERATOR3;
                        SW_test2.Write(tmp_s);
                    }
                    SW_test2.Flush();
                    SW_test2.Close();
                    FS_test.Close();
                }
        }

        //type
        private string GetLineType(int first)
        {
            return _model._lines[first].GetType().ToString();
        }

        //create
        public Shape Create(string[] value)
        {
            if (value[0].ToString() == RECTANGLE)
                return new DrawingModel.Rectangle(_model);
            else if (value[0].ToString() == ELLIPSE)
                return new DrawingModel.Ellipse(_model);
            else
                return new DrawingModel.Line(_model);
        }

        //copy
        public void Copy()
        {
            this._lines.Clear();
            for (int i = 0; i < GetNumber(); i++)
                this._lines.Add(_model._lines[i].Copy());
        }

        //get
        private int GetNumber()
        {
            return _model.GetListNumber();
        }

        //copy
        public void Replace()
        {
            for (int i = 0; i < this._lines.Count(); i++)
                _model._lines.Add(this._lines[i]);
        }
    }
}
