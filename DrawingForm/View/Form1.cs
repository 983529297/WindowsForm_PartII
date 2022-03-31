using DrawingModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingForm
{
    public partial class Form1 : Form
    {
        DrawingModel.Model _model;
        Panel _canvas = new DoubleBufferedPanel();
        DrawingModel.Shape _item;
        presentationModel.PresentationForm _presentation = new presentationModel.PresentationForm();
        const string SELECT = "Select ";
        const string OPERATOR = ": ";
        const int FOUR = 400;
        const int TWO = 2;
        const int THREE = 3;
        const int FIVE = 4;
        bool _isPress;
        const string FOLDER_TYPE = @"application/vnd.google-apps.folder";
        const string FILE = "CSV_test_out.csv";
        const string CONTENT_TYPE = "text/csv";
        const string LOAD = "載入";
        const string SAVE = "儲存";
        const string OPERATOR1 = ".";
        const string OPERATOR2 = ",";
        const string OPERATOR4 = "./";
        DrawingModel.GoogleDriveService _service;
        DrawingModel.SimpleFactory _factory;
        DrawingModel.PageFunction _function;

        public Form1(DrawingModel.Model model)
        {
            const string APPLICATION_NAME = "DrawAnywhere";
            const string CLIENT_SECRET_FILE_NAME = "clientSecret.json";
            InitializeComponent();
            _canvas.Dock = DockStyle.Fill;
            _canvas.BackColor = Color.LightYellow;
            _canvas.MouseDown += HandleCanvasPointerPressed;
            _canvas.MouseUp += HandleCanvasPointerReleased;
            _canvas.MouseMove += HandleCanvasPointerMoved;
            _canvas.MouseClick += HandleCanvasClick;
            _canvas.Paint += HandleCanvasPaint;
            Controls.Add(_canvas);
            _model = model;
            _model._modelChanged += HandleModelChanged;
            _redo.Enabled = false;
            _undo.Enabled = false;
            _isPress = false;
            _service = new DrawingModel.GoogleDriveService(APPLICATION_NAME, CLIENT_SECRET_FILE_NAME);
            _factory = new SimpleFactory(_model);
            _function = new PageFunction(_model);
        }

        //按clear
        public void HandleClearButtonClick(object sender, System.EventArgs e)
        {
            _model.Clear();
            _presentation.IsAllTrue();
            _presentation.Draw = false;
            DoRefresh();
        }

        //控制滑鼠點擊
        public void HandleCanvasClick(object sender, MouseEventArgs e)
        {
            string set = "";
            if (!_presentation.Draw)
                set = _model.HaveShape(e.X, e.Y);
            if (set != "")
            {
                _position.Visible = true;
                _position.Location = new Point(FOUR, _position.Location.Y);
                _position.Text = SELECT + OPERATOR + set;
            }else
                _position.Visible = false;
        }

        //控制滑鼠點擊
        public void HandleCanvasPointerPressed(object sender, MouseEventArgs e)
        {
            if (_presentation.Draw)
                _model.PressdPointer(e.X, e.Y, _item);
            else if (_model.CheckShape(e.X, e.Y))
            {
                SetFirstPoint(e.X, e.Y);
                _isPress = true;
            }
        }

        //firstpoint
        private void SetFirstPoint(float first, float second)
        {
            _model.SetFirstPoint(first, second);
        }

        //控制滑鼠放開
        public void HandleCanvasPointerReleased(object sender, MouseEventArgs e)
        {
            if (_presentation.Draw)
            {
                _model.ReleasedPointer(e.X, e.Y, _item);
                CallAllTrue();
                _presentation.Draw = false;
                DoRefresh();
            }
            else
            {
                _model.CallCommandMoved();
                _isPress = false;
                DoRefresh();
            }
        }

        //function
        private void CallAllTrue()
        {
            _presentation.IsAllTrue();
        }

        //控制滑鼠移動
        public void HandleCanvasPointerMoved(object sender, MouseEventArgs e)
        {
            if (_presentation.Draw)
                _model.MovedPointer(e.X, e.Y, _item);
            else if (_isPress)
            {
                _model.SetPointMoved(e.X, e.Y);
            }
        }

        // e.Graphics物件是Paint事件帶進來的，只能在當次Paint使用
        // 而Adaptor又直接使用e.Graphics，因此，Adaptor不能重複使用
        // 每次都要重新new
        //控制paint
        public void HandleCanvasPaint(object sender, PaintEventArgs e)
        {
            _model.Draw(new PresentationModel.WindowsFormsGraphicsAdaptor(e.Graphics));
        }

        //控制model
        public void HandleModelChanged()
        {
            _redo.Enabled = _model.IsRedoEnabled;
            _undo.Enabled = _model.IsUndoEnabled;
            Invalidate(true);
        }

        //按rectangle
        private void ClickRectangle(object sender, System.EventArgs e)
        {
            _item = _factory.CreateShape(0);
            _presentation.IsRectangleFalse();
            _presentation.Draw = true;
            DoRefresh();
        }

        //按ellipse
        private void ClickEllipse(object sender, System.EventArgs e)
        {
            _item = _factory.CreateShape(1);
            _presentation.IsEllipseFalse();
            _presentation.Draw = true;
            DoRefresh();
        }

        //Line
        private void ClickLine(object sender, System.EventArgs e)
        {
            _item = _factory.CreateShape(TWO);
            _presentation.IsLineFalse();
            _presentation.Draw = true;
            DoRefresh();
        }

        //refresh
        private void DoRefresh()
        {
            _rectangle.Enabled = _presentation.IsRectangle;
            _ellipse.Enabled = _presentation.IsEllipse;
            _line.Enabled = _presentation.IsLine;
            _redo.Enabled = _model.IsRedoEnabled;
            _undo.Enabled = _model.IsUndoEnabled;
        }

        //redo
        private void ClickRedo(object sender, System.EventArgs e)
        {
            _model.Redo();
            HandleModelChanged();
        }

        //undo
        private void ClickUndo(object sender, System.EventArgs e)
        {
            _model.Undo();
            HandleModelChanged();
        }

        //save
        async private void ClickSave(object sender, System.EventArgs e)
        {
            Check form = new Check(SAVE);
            if (form.ShowDialog() == DialogResult.Yes)
            {
                form.Close();
                Cursor = Cursors.WaitCursor;
                WriteFile();
                Cursor = Cursors.Arrow;
                await Task.Factory.StartNew(() => SaveRecord());
            }
            else
                form.Close();
        }

        //save
        private void SaveRecord()
        {
            List<Google.Apis.Drive.v2.Data.File> rootFiles = _service.ListRootFileAndFolder();
            rootFiles.RemoveAll(removeItem =>
            {
                return removeItem.MimeType == FOLDER_TYPE;
            });
            for (int i = 0; i < rootFiles.Count; i++)
                if (GetRootFileCount(rootFiles[i]) == FILE)
                {
                    List<Google.Apis.Drive.v2.Data.File> fileList = GetListRootFileCount();//_service.ListRootFileAndFolder();
                    Google.Apis.Drive.v2.Data.File foundFile = fileList.Find(item => 
                    {
                        return item.Title == FILE; 
                    });
                    UpdateFile(foundFile);//_service.UpdateFile(FILE, foundFile.Id, CONTENT_TYPE);
                    return;
                }
            _service.UploadFile(FILE, CONTENT_TYPE);
        }

        //update
        private void UpdateFile(Google.Apis.Drive.v2.Data.File foundFile)
        {
            _service.UpdateFile(FILE, foundFile.Id, CONTENT_TYPE);
        }

        //list
        private List<Google.Apis.Drive.v2.Data.File> GetListRootFileCount()
        {
            return _service.ListRootFileAndFolder();
        }

        //count
        private string GetRootFileCount(Google.Apis.Drive.v2.Data.File rootFiles)
        {
            return rootFiles.Title;
        }

        //save
        private void WriteFile()
        {
            _function.WriteFile();
        }

        //load
        private void ClickLoad(object sender, System.EventArgs e)
        {
            Check form = new Check(LOAD);
            if (form.ShowDialog() == DialogResult.Yes)
            {
                form.Close();
                LoadRecord();
            }
            else
                form.Close();
            Cursor = Cursors.Arrow;
        }

        //load
        private void LoadRecord()
        {
            Cursor = Cursors.WaitCursor;
            List<Google.Apis.Drive.v2.Data.File> rootFiles = _service.ListRootFileAndFolder();
            rootFiles.RemoveAll(removeItem =>
            {
                return removeItem.MimeType == FOLDER_TYPE;
            });
            for (int i = 0; i < rootFiles.Count; i++)
                if (GetRootFileCount(rootFiles[i]) == FILE)
                {
                    Google.Apis.Drive.v2.Data.File selectedFile = GetRootFile(rootFiles, i);// rootFiles[i];// as Google.Apis.Drive.v2.Data.File;
                    DownloadFile(selectedFile);
                    ReadFile();
                }
        }

        //download
        private void DownloadFile(Google.Apis.Drive.v2.Data.File selectedFile)
        {
            _service.DownloadFile(selectedFile, OPERATOR4);
        }

        //rootfile
        private Google.Apis.Drive.v2.Data.File GetRootFile(List<Google.Apis.Drive.v2.Data.File> rootFile, int first)
        {
            return rootFile[first];
        }

        //read
        private void ReadFile()
        {
            var reader = new StreamReader(File.OpenRead(FILE));

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(OPERATOR.ToCharArray());
                
                for (int i = 0; i < values.Length; i++)
                {
                    var value = values[i].Split(OPERATOR2.ToCharArray());
                    //Create(value[0].ToString(), Convert.ToDouble(value[1]), Convert.ToDouble(value[TWO]), Convert.ToDouble(value[THREE]), Convert.ToDouble(value[FIVE]));
                    Create(value);
                }
            }
            reader.Close();
        }

        //create
        private void Create(string[] value)
        {
            _item = _function.Create(value);
            _item.SetLeftUp(Convert.ToDouble(value[1]), Convert.ToDouble(value[TWO]));
            _item.SetRightDown(Convert.ToDouble(value[THREE]), Convert.ToDouble(value[FIVE]));
            _model._lines.Add(_item);
            Invalidate(true);
        }
    }
}
