using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// 空白頁項目範本已記錄在 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x404

namespace DrawingApp
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DrawingModel.Model _model;
        DrawingModel.IGraphics _graphics;
        DrawingModel.Shape _item;
        presentationModel.PresentationApp _presentation = new presentationModel.PresentationApp();
        const int ONE = 1000;
        const int TWO = 650;
        const int THREE = 100;
        const string SELECT = "Select ";
        const string OPERATOR = ": ";
        bool _isPress;
        const string FOLDER_TYPE = @"application/vnd.google-apps.folder";
        const string FILE = "./CSV_test_out.csv";
        const string CONTENT_TYPE = "text/csv";
        const string CONTINUE1 = "是否繼續";
        const string CONTINUE2 = "是否繼續執行載入";
        const string CONTINUE3 = "是否繼續執行儲存";
        const string YES = "Yes";
        const string CANCEL = "Cancel";
        const string LOAD = "載入";
        const string SAVE = "儲存";
        const string RECTANGLE = "Rectangle";
        const string ELLIPSE = "Ellipse";
        const string OPERATOR1 = ".";
        const string OPERATOR2 = ",";
        const string OPERATOR3 = "\r\n";
        const int FIVE = 4;
        const string OPERATOR4 = "./";
        //DrawingModel.GoogleDriveService _service;
        DrawingModel.PageFunction _function;
        DrawingModel.SimpleFactory _factory;

        public MainPage()
        {
            //const string APPLICATION_NAME = "DrawAnywhere";
            //const string CLIENT_SECRET_FILE_NAME = "clientSecret.json";
            this.InitializeComponent();
            // Model
            _model = new DrawingModel.Model();
            // Note: 重複使用_igraphics物件
            _graphics = new View.WindowsStoreGraphicsAdaptor(_canvas);
            // Events
            _canvas.PointerPressed += HandleCanvasPointerPressed;
            _canvas.PointerReleased += HandleCanvasPointerReleased;
            _canvas.PointerMoved += HandleCanvasPointerMoved;
            _model._modelChanged += HandleModelChanged;
            _redo.IsEnabled = false;
            _undo.IsEnabled = false;
            _isPress = false;
            _factory = new DrawingModel.SimpleFactory(_model);
            _function = new DrawingModel.PageFunction(_model);
            //_service = new DrawingModel.GoogleDriveService(APPLICATION_NAME, CLIENT_SECRET_FILE_NAME);
        }

        //清除
        private void ClickClear(object sender, RoutedEventArgs e)
        {
            _model.Clear();
            _presentation.IsAllTrue();
            _presentation.Draw = false;
            DoRefresh();
        }

        //按滑鼠

        public void HandleCanvasPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (_presentation.Draw)
                _model.PressdPointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y, _item);
            else
            {
                if (_model.CheckShape((float)e.GetCurrentPoint(_canvas).Position.X, (float)e.GetCurrentPoint(_canvas).Position.Y))
                {
                    SetFirstPoint((float)e.GetCurrentPoint(_canvas).Position.X, (float)e.GetCurrentPoint(_canvas).Position.Y);
                    _isPress = true;
                }
                //SetPosition((float)e.GetCurrentPoint(_canvas).Position.X, (float)e.GetCurrentPoint(_canvas).Position.Y);
            }
        }

        //position
        private void SetPosition(float first, float second)
        {
            string set = _model.HaveShape(first, second);
            if (set != "")
            {
                _position.Visibility = Visibility.Visible;
                _position.Margin = new Thickness(ONE, TWO, THREE, THREE);
                _position.Text = SELECT + OPERATOR + set;
            }
            else
                _position.Visibility = Visibility.Collapsed;
        }

        //firstpoint
        private void SetFirstPoint(float first, float second)
        {
            _model.SetFirstPoint(first, second);
        }

        //放開滑鼠
        public void HandleCanvasPointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (_presentation.Draw)
            {
                _model.ReleasedPointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y, _item);
                //_item = _item.CreateNew();
                CallAllTrue();
                //_presentation.IsAllTrue();
                _presentation.Draw = false;
                DoRefresh();
            }
            else
            {
                _model.CallCommandMoved();
                _isPress = false;
                HandleModelChanged();
                SetPosition((float)e.GetCurrentPoint(_canvas).Position.X, (float)e.GetCurrentPoint(_canvas).Position.Y);
            }
        }

        //function
        private void CallAllTrue()
        {
            _presentation.IsAllTrue();
        }

        //移動滑鼠
        public void HandleCanvasPointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (_presentation.Draw)
                _model.MovedPointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y, _item);
            else if (_isPress)
            {
                _model.SetPointMoved((float)e.GetCurrentPoint(_canvas).Position.X, (float)e.GetCurrentPoint(_canvas).Position.Y);
            }
        }

        //提醒
        public void HandleModelChanged()
        {
            _redo.IsEnabled = _model.IsRedoEnabled;
            _undo.IsEnabled = _model.IsUndoEnabled;
            _model.Draw(_graphics);
        }

        //按rectangle
        private void ClickRectangle(object sender, RoutedEventArgs e)
        {
            _item = _factory.CreateShape(0);
            _presentation.IsRectangleFalse();
            _presentation.Draw = true;
            DoRefresh();
        }

        //按ellipse
        private void ClickEllipse(object sender, RoutedEventArgs e)
        {
            _item = _factory.CreateShape(1);
            _presentation.IsEllipseFalse();
            _presentation.Draw = true;
            DoRefresh();
        }

        //按Line
        private void ClickLine(object sender, RoutedEventArgs e)
        {
            _item = _factory.CreateShape(TWO);
            _presentation.IsLineFalse();
            _presentation.Draw = true;
            DoRefresh();
        }

        //refresh
        private void DoRefresh()
        {
            _rectangle.IsEnabled = _presentation.IsRectangle;
            _ellipse.IsEnabled = _presentation.IsEllipse;
            _line.IsEnabled = _presentation.IsLine;
        }

        //redo
        private void ClickRedo(object sender, RoutedEventArgs e)
        {
            _model.Redo();
            HandleModelChanged();
        }

        //indo
        private void ClickUndo(object sender, RoutedEventArgs e)
        {
            _model.Undo();
            HandleModelChanged();
        }

        //save
        /*private void SaveRecord()
        {
            List<Google.Apis.Drive.v2.Data.File> rootFiles = _service.ListRootFileAndFolder();
            rootFiles.RemoveAll(removeItem =>
            {
                return removeItem.MimeType == FOLDER_TYPE;
            });
            for (int i = 0; i < rootFiles.Count; i++)
                if (GetRootFileCount(rootFiles[i]) == FILE)
                {
                    List<Google.Apis.Drive.v2.Data.File> fileList = GetListRootFileCount(); //_service.ListRootFileAndFolder();
                    Google.Apis.Drive.v2.Data.File foundFile = fileList.Find(item =>
                    {
                        return item.Title == FILE;
                    });
                    UpdateFile(foundFile); //_service.UpdateFile(FILE, foundFile.Id, CONTENT_TYPE);
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
            HandleModelChanged();
        }*/

        //load
        private async void ClickLoad(object sender, RoutedEventArgs e)
        {
            ContentDialog deleteFileDialog = new ContentDialog 
            { 
                Title = CONTINUE1, Content = CONTINUE2, PrimaryButtonText = YES, CloseButtonText = CANCEL };
            ContentDialogResult result = await deleteFileDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                //LoadRecord();
                _function.Replace();
                HandleModelChanged();

            }
        }

        //load
        /*private void LoadRecord()
        {
            List<Google.Apis.Drive.v2.Data.File> rootFiles = _service.ListRootFileAndFolder();
            rootFiles.RemoveAll(removeItem =>
            {
                return removeItem.MimeType == FOLDER_TYPE;
            });
            for (int i = 0; i < rootFiles.Count; i++)
                if (GetRootFileCount(rootFiles[i]) == FILE)
                {
                    Google.Apis.Drive.v2.Data.File selectedFile = GetRootFile(rootFiles, i); //rootFiles[i];// as Google.Apis.Drive.v2.Data.File;
                    DownloadFile(selectedFile); //_service.DownloadFile(selectedFile, OPERATOR4);
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
        }*/

        //save
        private async void ClickSave(object sender, RoutedEventArgs e)
        {
            ContentDialog deleteFileDialog = new ContentDialog
            { 
                Title = CONTINUE1, Content = CONTINUE3, PrimaryButtonText = YES, CloseButtonText = CANCEL };
            ContentDialogResult result = await deleteFileDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                //WriteFile();
                //await Task.Factory.StartNew(() => SaveRecord());
                await Task.Factory.StartNew(() => Copy()); 
            }
        }

        //copy
        private void Copy()
        {
            _function.Copy();
        }
    }
}
